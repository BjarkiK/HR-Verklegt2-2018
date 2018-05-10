/*
        Only Admin role can use admin contoller
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheBookCave.Models;
using TheBookCave.Models.ViewModels;
using TheBookCave.Services;

namespace TheBookCave.Controllers
{
    [Authorize(Roles = "ADMIN")]
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
            return View(promoCodeList);
        }
        public IActionResult promoCodeDetails(int id)
        {
            var promoCode = _adminPromoCodeService.getPromoCode(id);
            return View(promoCode);
        }
        public IActionResult editPromoCode(int id) {
			var promoCode = _adminPromoCodeService.getPromoCode(id);
            if(!promoCode.Any()) {
                return RedirectToAction("promoCodeNotFound");
            }
			return View(promoCode.First());

        }
        [HttpPost]
        public ActionResult editPromoCode(PromoCodeListViewModel promoCode) {
           	if (ModelState.IsValid) {
				_adminPromoCodeService.updatePromoCode(promoCode);
				return RedirectToAction("index");
			}
			return View(promoCode);
        }
        public IActionResult promoCodeNotFound() {
            return View();
        }

        public IActionResult addPromoCode()
        {
            return View();
        }

        [HttpPost]
		public ActionResult addPromoCode(PromoCodeListViewModel promoCode) {
			if (ModelState.IsValid) {
				_adminPromoCodeService.createPromocode(promoCode);
				return RedirectToAction("Index");
			}
            Console.WriteLine("CreateNotValid");
			return View(promoCode);
		}
    }
}
