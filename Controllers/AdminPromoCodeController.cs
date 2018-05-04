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
        //private AdminPromoCodeService _adminPromoCodeService;

        public AdminPromoCodeController() {
            //_adminPromoCodeService = new AdminPromoCodeService();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult promoCodesDisplay()
        {
            /*var promoCodeList = _adminPromoCodeService.getAllPromoCodes();
            return View(subscriptionList);*/
            return View();
        }
        public IActionResult promoCodesDetails(int pcid)
        {
            /*var promoCode = _adminPromoCodeService.getPromoCode(pcid);
            return View(promoCode);*/
            return View();
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
