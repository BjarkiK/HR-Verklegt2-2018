using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using authentication_repo.Models;
using authentication_repo.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheBookCave.Models.ViewModels;
using TheBookCave.Services;
using TheBookCave.Data.EntityModels;

namespace authentication_repo.Controllers
{
    public class AccountController : Controller
    {
        //meðmæla breytur
        private readonly SignInManager<ApplicationUser> _signInMager;
        private readonly UserManager<ApplicationUser> _userManger;
        private UserService _userService;
        private OrderService  _orderService;
        private AddressService _addressService;
        private UserRoleService _userRoleService;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager) {
            _signInMager =  signInManager;
            _userManger =  userManager;
            _userService = new UserService();
            _orderService = new OrderService();
            _addressService = new AddressService();
            _userRoleService = new UserRoleService();

        }

        [Authorize]        
        public IActionResult index() {
            var profile = getProfile();
            return View(profile);
        }

        [Authorize]        
        public ActionResult editProfile() {
            var profile = getProfile();
            return View(profile);
        }
        public IActionResult orderHistory() {
            return View();
        }

        private ProfileViewModel getProfile() {
            var user = _userService.getUser(User.Claims.ToArray()[0].Value).First();
            var address = _addressService.getUserAddress(user.Id);
            var country = _addressService.getUserAddressCountry(address.CountryId);
            var countries = _addressService.getAllCountries();
            var favBooks = _userService.getFavoriteBooks(user.Id);
            var orders = (from o in _orderService.getUserOrder(user.Id)
                            select new Order {
                                AddressId = o.AddressId,
                                Date = o.Date,
                                Id = o.Id,
                                TypeId = o.TypeId,
                                UserId = o.UserId,
                            }).ToList();
            return new ProfileViewModel {UserName = user.UserName, Email = user.Email,
                                                FirstName = user.FirstName, LastName = user.LastName,
                                                Picture = user.Picture, PhoneNumber = user.PhoneNumber,
                                                Address = address, Orders = orders,
                                                Countries = countries, Country = country,
                                                FavoriteBooks = favBooks};
        }

        [Authorize]  
        [HttpPost]
        public async Task<IActionResult> editProfile(ProfileViewModel profile) {
            var user = await _userManger.GetUserAsync(User);
            Console.WriteLine(user);
            var address = _addressService.getUserAddress(user.Id);
            user.FirstName = profile.FirstName;
            user.LastName = profile.LastName;
            user.PhoneNumber = profile.PhoneNumber;
            await _userManger.UpdateAsync(user);
            Console.WriteLine(address.Id);
            address.Address1 = profile.Address.Address1;
            address.Address2 = profile.Address.Address2;
            var countryId = 0;
            Int32.TryParse(profile.Country, out countryId);
            address.CountryId = countryId;
            address.Region = profile.Address.Region;
            address.Zip = profile.Address.Zip;
            _addressService.updateAddress(address);
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
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, Picture = "/images/profile/profileImagePlaceholder.jpg"};
            _addressService.initialiceUserAddress(user.Id);
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
            

            if (result.Succeeded) {
                var userId = _userService.getUserIdByEmail(model.Email);
                var userRole = _userRoleService.getUsersRole(userId);
                if(userRole == "ADMIN"){
                    return RedirectToAction("index", "adminBook");
                }

                return RedirectToAction("index", "FrontPage");
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
