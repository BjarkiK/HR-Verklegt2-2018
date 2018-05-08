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
    public class AdminUserController : Controller
    {
        private AdminUserService _adminUserService;

        public AdminUserController() {
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
        public IActionResult EditUser(string id) {
			var user = _adminUserService.getUser(id);
            if(!user.Any()) {
                return RedirectToAction("userNotFound");
            }
			return View(user.First());

        }
        [HttpPost]
        public ActionResult EditUser(UserListViewModel user) {
           	if (ModelState.IsValid) {
				_adminUserService.updateUser(user);
				return RedirectToAction("index");
			}
			return View(user);
        }

        public IActionResult userNotFound() {
            return View();
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
		public ActionResult AddUser(UserListViewModel user) {
			if (ModelState.IsValid) {
				_adminUserService.CreateUser(user);
				return RedirectToAction("Index");
			}
            Console.WriteLine("CreateNotValid");
			return View(user);
		}
    }
}
