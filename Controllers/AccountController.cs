using System;
using System.IO;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using authentication_repo.Models;
using authentication_repo.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheBookCave.Models.ViewModels;
using TheBookCave.Services;

namespace authentication_repo.Controllers
{
    public class AccountController : Controller
    {
        //meðmæla breytur
        private readonly SignInManager<ApplicationUser> _signInMager;
        private readonly UserManager<ApplicationUser> _userManger;
        private UserService _userSerrvice;
        private UserRoleService _userRoleSerrvice;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager) {
            _signInMager =  signInManager;
            _userManger =  userManager;
            _userSerrvice = new UserService();
            _userRoleSerrvice = new UserRoleService();
        }

        [Authorize]        
        public async Task<IActionResult> index() {
            var user = await _userManger.GetUserAsync(User);
            var address = _userSerrvice.getUserAddresss(user.Id);
            var profile = new ProfileViewModel {UserName = user.UserName, Email = user.Email,
                                                FirstName = user.FirstName, LastName = user.LastName,
                                                Picture = user.Picture};
            return View(profile);
        }

        [Authorize]        
        public async Task<IActionResult> editProfile() {
            var user = await _userManger.GetUserAsync(User);
            var profile = new ProfileViewModel {UserName = user.UserName, Email = user.Email,
                                                FirstName = user.FirstName, LastName = user.LastName,
                                                Picture = user.Picture};
            return View(profile);
        }

        [Authorize]  
        [HttpPost]
        public async Task<IActionResult> editProfile(ProfileViewModel profile) {
            var user = await _userManger.GetUserAsync(User);

            user.FirstName = profile.FirstName;
            user.LastName = profile.LastName;
            await _userManger.UpdateAsync(user);
            return RedirectToAction("index");
        }

        [Authorize]  
        [HttpPost]
        public async Task editProfilePicture(string picture) {
            Console.WriteLine("ServerPicture");
            var user = await _userManger.GetUserAsync(User);
            user.Picture = picture;
            await _userManger.UpdateAsync(user);
        }

        // view tar sem fyllt er ut register
        public IActionResult Register() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model) {
            // Error handling
            if(!ModelState.IsValid) {
                return View();
            }
            // nyr user . Username og email verd tad sama
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, Picture = "/images/profile/profileImagePlaceholder.jpg" };
            //  Task til ad nota asynic
            // _userMangar byr til user i startup
            var result = await _userManger.CreateAsync(user, model.Password);

            if(result.Succeeded) {
                // user is succesfully registered
                // concatenated first and last name as fullname in claims
                await _userManger.AddClaimAsync(user, new Claim("Name", $"{model.FirstName} {model.LastName}"));

                await _userManger.AddToRoleAsync(user, "USER");
                // SignInAsync logar user in
                await _signInMager.SignInAsync(user,false);

                return RedirectToAction("index", "FrontPage");
            }

            return View();
        }

        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // async sem sign in user
        public async Task<IActionResult> Login(LoginViewModel model) {
            // Error handling
            if(!ModelState.IsValid){ 
                return View();
            }
            // if vidkomand sign in PasswordSignInAsync
            var result = await _signInMager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if ( result.Succeeded) {
               /* var user =  await _userManger.GetUserAsync(User);
                var userId = user.Id;
                var role = _userRoleSerrvice.getUsersRole(userId);
                Console.WriteLine(role);

                if(role == "ADMIN") {
                    return RedirectToAction("index", "AdmonOrderList");
                }*/
                return RedirectToAction("index", "FrontPage");
                // ADMIN return RedirectToAction("index", "AdmonOrderList");
            }
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // async request to log out
        public async Task<IActionResult> LogOut() {
            await _signInMager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
       
        public IActionResult accessDenied() {
            return View();
        }

        
    }
}
