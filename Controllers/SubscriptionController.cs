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
    public class SubscriptionController : Controller
    {
        private SubscriptionService _subscriptionService;

        public SubscriptionController() {
            _subscriptionService = new SubscriptionService();
        }
        public IActionResult index()
        {
            return View();
        }
        public IActionResult subscriptionListDisplay()
        {
            var subscriptionList = _subscriptionService.getAllSubscriptions();
            return View(subscriptionList);
        }
    }
}
