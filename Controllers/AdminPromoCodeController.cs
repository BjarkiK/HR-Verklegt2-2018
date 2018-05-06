/*
        Virkar ekki. Database er vitlaust

 */

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
    public class AdminPromoCodeController : Controller
    {
        private AdminPromoCodeService _adminPromoCodeService;

        public AdminPromoCodeController() {
            _adminPromoCodeService = new AdminPromoCodeService();
        }
        public IActionResult index()
        {
            return View();
        }
        public IActionResult promoCodeListDisplay()
        {
            var promoCodeList = _adminPromoCodeService.getAllPromoCode();
            return View(promoCodeList);
        }
        public IActionResult promoCodeDetails(string id)
        {
            var promoCode = _adminPromoCodeService.getPromoCode(id);
            return View(promoCode);

        }
        public void updatePromoCode(int pcid)
        {
            //_adminPromoCodeService.updatePromoCode(pcid);
        }
        public void createPromoCode()
        {
            //_adminPromoCodeService.createPromoCode();
        }
    }
}
