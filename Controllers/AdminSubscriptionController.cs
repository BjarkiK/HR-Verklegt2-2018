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
    public class AdminSubscriptionController : Controller
    {
        private AdminSubscriptionService _adminSubscriptionService;

        public AdminSubscriptionController() {
            _adminSubscriptionService = new AdminSubscriptionService();
        }
        public IActionResult index()
        {
            var subscriptionList = _adminSubscriptionService.getAllSubscription();
            return View(subscriptionList);
        }

        [HttpPost]
        public IActionResult index(string searchString)
        {
            var searchResult = _adminSubscriptionService.getSearchResult(searchString);
            if (searchResult == null) {
                return View("NotFound");
            }
            return View(searchResult);
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

        public IActionResult AddSubscription()
        {
            return View();
        }

        [HttpPost]
		public ActionResult AddSubscription(SubscriptionListViewModel subscription) {
			if (ModelState.IsValid) {
				_adminSubscriptionService.CreateSubscription(subscription);
				return RedirectToAction("Index");
			}
            Console.WriteLine("CreateNotValid");
			return View(subscription);
		}
    }
}
