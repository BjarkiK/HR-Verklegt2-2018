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
        public IActionResult EditSubscription(int id) {
			var subscription = _adminSubscriptionService.getSubscription(id);
            if(!subscription.Any()) {
                return RedirectToAction("subscriptionNotFound");
            }
			return View(subscription.First());

        }
        [HttpPost]
        public ActionResult EditSubscription(SubscriptionListViewModel subscription) {
           	if (ModelState.IsValid) {
				_adminSubscriptionService.updateSubscription(subscription);
				return RedirectToAction("index");
			}
			return View(subscription);
        }
        public IActionResult subscriptionNotFound() {
            return View();
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
