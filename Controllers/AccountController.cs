using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBookCave.Models;
using TheBookCave.Models.ViewModels;
using TheBookCave.Services;

namespace TheBookCave.Controllers
{
    public class AccountController : Controller
    {
        private AccountService _accountService;
        private AdminUserService _adminuserService;

        public AccountController() {
            _accountService = new AccountService();
            _adminuserService = new AdminUserService();
        }
        

        public IActionResult index()
        {
            return View();
        }
        public bool login(string email, string password) 
        {
            //_accountService.login();
            return true;
        }
        public bool logout() 
        {
            //_accountService.logout();
            return true;
        }
          public IActionResult signUp()
        {
            return View();
        }

        [HttpPost]
		public ActionResult signUp(UserListViewModel user) {
			if (ModelState.IsValid) {
				_adminuserService.createUser(user);
				return RedirectToAction("index");
			}
            Console.WriteLine("signUpNotValid");
			return View(user);
		}
    }
}
