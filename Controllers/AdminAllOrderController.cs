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
    public class AdminAllOrderController : Controller
    {
        private AdminOrderService _adminOrderService;

        public AdminAllOrderController() {
            _adminOrderService = new AdminOrderService();
        }
        public IActionResult index()
        {
            var orderList = _adminOrderService.getAllOrder();
            return View(orderList);
        }

        [HttpPost]
        public IActionResult index(string searchString)
        {
            var searchResult = _adminOrderService.getSearchResult(searchString);
            if (searchResult == null) {
                return View("NotFound");
            }
            return View(searchResult);
        }

        public IActionResult orderListDisplay()
        {
            var orderList = _adminOrderService.getAllOrder();
            return View(orderList);
        }
        public IActionResult Details(int id)
        {
            var order = _adminOrderService.getOrder(id);
            return View(order);
        }
        public IActionResult EditOrder(int id) {
			var order = _adminOrderService.getOrder(id);
            if(!order.Any()) {
                return RedirectToAction("orderNotFound");
            }
			return View(order.First());

        }
        [HttpPost]
        public ActionResult EditOrder(OrderListViewModel order) {
           	if (ModelState.IsValid) {
				_adminOrderService.updateOrder(order);
				return RedirectToAction("index");
			}
			return View(order);
        }

        public IActionResult orderNotFound() {
            return View();
        }


        public IActionResult AddOrder() {
            return View();
        }

        [HttpPost]
		public ActionResult AddOrder(OrderListViewModel order) {
			if (ModelState.IsValid) {
				_adminOrderService.CreateOrder(order);
				return RedirectToAction("Index");
			}
            Console.WriteLine("CreateNotValid");
			return View(order);
		}
    }
}
