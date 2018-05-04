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
    public class AccountController : Controller
    {
        //private AccountService _accountService;

        public AccountController() {
            //_accountService = new AccountService();
        }
        public IActionResult Index()
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
        public bool signup() 
        {
            //_accountService.createUser();
            return true;
        }
    }
}
