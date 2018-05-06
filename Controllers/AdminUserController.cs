using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBookCave.Models;
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
            return View();
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
        public void userUpdate(string uid)
        {
            //_adminUserService.updateUser(uid);
        }
        public void addNewUser() 
        {
            //_adminUserService.createUser();
        }
    }
}
