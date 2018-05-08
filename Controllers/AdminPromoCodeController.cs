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
    public class AdminPromoCodeController : Controller
    {
        private AdminPromoCodeService _adminPromoCodeService;

        public AdminPromoCodeController() {
            _adminPromoCodeService = new AdminPromoCodeService();
        }
        public IActionResult index()
        {
            var promoCodeList = _adminPromoCodeService.getAllPromoCode();
            return View(promoCodeList);
        }

        [HttpPost]
        public IActionResult index(string searchString)
        {
            var searchResult = _adminPromoCodeService.getSearchResult(searchString);
            if (searchResult == null) {
                return View("NotFound");
            }
            return View(searchResult);
        }
        public IActionResult promoCodeListDisplay()
        {
            var promoCodeList = _adminPromoCodeService.getAllPromoCode();
            Console.WriteLine(promoCodeList.First().Description);
            return View(promoCodeList);
        }
        public IActionResult promoCodeDetails(int id)
        {
            var promoCode = _adminPromoCodeService.getPromoCode(id);
            return View(promoCode);
        }
        public IActionResult EditPromoCode(int id) {
			var promoCode = _adminPromoCodeService.getPromoCode(id);
            if(!promoCode.Any()) {
                return RedirectToAction("promoCodeNotFound");
            }
			return View(promoCode.First());

        }
        [HttpPost]
        public ActionResult EditPromoCode(PromoCodeListViewModel promoCode) {
           	if (ModelState.IsValid) {
				_adminPromoCodeService.updatePromoCode(promoCode);
				return RedirectToAction("index");
			}
			return View(promoCode);
        }
        public IActionResult promoCodeNotFound() {
            return View();
        }

        public IActionResult AddPromoCode()
        {
            return View();
        }

        [HttpPost]
		public ActionResult AddPromoCode(PromoCodeListViewModel promoCode) {
			if (ModelState.IsValid) {
				_adminPromoCodeService.CreatePromocode(promoCode);
				return RedirectToAction("Index");
			}
            Console.WriteLine("CreateNotValid");
			return View(promoCode);
		}
    }
}
