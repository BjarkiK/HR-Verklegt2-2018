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
    public class AdminSubscriptionController : Controller
    {
        private AdminSubscriptionService _adminSubscriptionService;

        public AdminSubscriptionController() {
            _adminSubscriptionService = new AdminSubscriptionService();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult subscriptionListDisplay()
        {
            var subscriptionList = _adminSubscriptionService.getAllSubscription();
            return View(subscriptionList);
        }
        public IActionResult subscriptionDetails(int id)
        {
            var subscription = _adminSubscriptionService.getSubscription(id);
            return View(subscription);
        }
        public void subscriptionUpdate(int sid)
        {
            //_adminSubscriptionService.updateSubscription(sid);
        }
        public void createSubscription()
        {
            //_adminSubscriptionService.createSubscription();
        }
    }
}
