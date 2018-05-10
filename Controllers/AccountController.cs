using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using authentication_repo.Models;
using authentication_repo.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheBookCave.Models.ViewModels;

namespace authentication_repo.Controllers
{
    public class AccountController : Controller
    {
        //meðmæla breytur
        private readonly SignInManager<ApplicationUser> _signInMager;
        private readonly UserManager<ApplicationUser> _userManger;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager) {
            _signInMager =  signInManager;
            _userManger =  userManager;
        }

        [Authorize]        
        public async Task<IActionResult> index() {
            var user = await _userManger.GetUserAsync(User);
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
            Console.WriteLine(user.LastName);
            user.FirstName = profile.FirstName;
            user.LastName = profile.LastName;
            user.Picture = profile.Picture;
            await _userManger.UpdateAsync(user);

            return RedirectToAction("index");
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

                await _userManger.AddToRoleAsync(user, "user");
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
