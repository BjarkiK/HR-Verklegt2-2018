using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using authentication_repo.Models;
using authentication_repo.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models;
using TheBookCave.Models.ViewModels;
using TheBookCave.Services;

namespace TheBookCave.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class AdminUserController : Controller
    {
        private AdminUserService _adminUserService;
         private readonly UserManager<ApplicationUser> _userManger;
         private readonly SignInManager<ApplicationUser> _signInMager;

    
        public AdminUserController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager) {
            _userManger =  userManager;
               _signInMager =  signInManager;
            _adminUserService = new AdminUserService();
        }
        
        public IActionResult index()
        {
            var userList = _adminUserService.getAllUsers();
            return View(userList);
        }

        [HttpPost]
        public IActionResult index(string searchString)
        {
            var searchResult = _adminUserService.getSearchResult(searchString);
            return View(searchResult);
        }


        public IActionResult userListDisplay()
        {
            var userList = _adminUserService.getAllUsers();
            return View(userList);
        }

        public IActionResult userDetails(string id)
        {
            var user = _adminUserService.getUser(id);
            return View(user);
        }
 

    /*
        public IActionResult editUser(string id) {
			var user = _userManger.FindByIdAsync(id);
			return View(user);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult editUser(UserListViewModel model) {
           
           	if (ModelState.IsValid) {
                   var user =   convertUserListViewModelToUser(model);
				_userManger.UpdateAsync(Email;
				return RedirectToAction("index");
			}
			return View(user);
        }
       */
      
         


        public IActionResult userNotFound() {
            return View();
        }

        public IActionResult addUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> addUser(RegisterViewModel model)
        {
            // Error handling
            if(!ModelState.IsValid){
                return View();
            }
            // nyr user . Username og email verd tad sama
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            //  Task til ad nota asynic
            // _userMangar byr til user i startup
            var result = await _userManger.CreateAsync(user, model.Password);

            if(result.Succeeded){
                // user is succesfully registered
                // concatenated first and last name as fullname in claims
                await _userManger.AddClaimAsync(user, new Claim("Name", $"{model.FirstName} {model.LastName}"));

                await _userManger.AddToRoleAsync(user, model.Role);
              //   await _signInMager.SignInAsync(user,false);

                return RedirectToAction("index", "AdminUser");
            }

            return View();
        }
    }
}
