using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Web;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using authentication_repo.Models;
using Microsoft.AspNetCore.Identity;
using TheBookCave.Models;
using TheBookCave.Services;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Controllers
{
    public class CheckoutController : Controller
    {
        private CartService _cartService;
        private OrderService _orderService;
        private AddressService _addressService;
        private readonly UserManager<ApplicationUser> _userManager;
        private string orderDetails;
        private int addressId;
        private int paymentId;

        public CheckoutController(UserManager<ApplicationUser> userManager) {
            _addressService = new AddressService();
            _cartService = new CartService();
            _orderService = new OrderService();
            _userManager = userManager;
        }
        public IActionResult index()
        {
            return View();
        }

        public ActionResult submitAddress(CheckoutViewModel checkoutInfo) {
<<<<<<< HEAD
            var userId =  User.Claims.ToArray()[0].Value;
=======
            var userId = _userManager.GetUserId(User);
>>>>>>> b7ffbf94205e1a09ca88cb5ca6327bc6d4a7b21d
            orderDetails = ("ADDRESS;" + checkoutInfo.Firstname + ";" + checkoutInfo.Email + ";" + checkoutInfo.Phone + ";" + checkoutInfo.Address1 + ";" + checkoutInfo.Address2 + ";" + checkoutInfo.CountryCode + ";" + checkoutInfo.Region + ";" + checkoutInfo.Zip);
            addressId = _addressService.createAddress(userId, checkoutInfo.Address1, checkoutInfo.Address2, checkoutInfo.CountryCode, checkoutInfo.Region, checkoutInfo.Zip, checkoutInfo.Phone);
            Response.Cookies.Append("TBCOrderDetails", addressId + ":" + orderDetails);
            if (addressId != 0) {
                return RedirectToAction("creditInfo");
            }
            return RedirectToAction("index");
        }
        public IActionResult creditInfo()
        {
            if (!unpackOrderCookie() || orderDetails == null || addressId == 0) {
                return RedirectToAction("index");
            }
            return View();
        }
        private bool unpackOrderCookie() {
            var orderCookie = Request.Cookies["TBCOrderDetails"];
            
            if (orderCookie == null) {
                return false;
            }

            string[] cookieContent = orderCookie.Split(':');
            addressId = Int32.Parse(cookieContent[0]);
            orderDetails = cookieContent[1];
            if (cookieContent.Length > 2) {
                paymentId = Int32.Parse(cookieContent[2]);    
            }
            return true;
        }
        public ActionResult submitPayment(PaymentDetailListViewModel paymentDetails) {
            // Expirydate to DateTime MM/yy virkni scrapped vegna tímaþröng -Ingi.
            var userId = _userManager.GetUserId(User);
            unpackOrderCookie();
            orderDetails = (orderDetails + ";PAYMENT;" + paymentDetails.NameOnCard + ";" + paymentDetails.CardNumber + ";" + paymentDetails.ExpiryDate + ";" + paymentDetails.CVC);
            paymentId = _orderService.savePaymentDetails(userId, paymentDetails.NameOnCard, paymentDetails.CardNumber, paymentDetails.ExpiryDate, paymentDetails.CVC, addressId);
            Response.Cookies.Delete("TBCOrderDetails");
            Response.Cookies.Append("TBCOrderDetails", addressId + ":" + orderDetails + ":" + paymentId);
            if (paymentId != 0) {
                return RedirectToAction("overview");
            }
            return RedirectToAction("creditInfo");
        }
        public IActionResult overview()
        {
            if (!unpackOrderCookie() || orderDetails == null || addressId == 0 || paymentId == 0) {
                return RedirectToAction("creditInfo");
            }
            var cartCookie = Request.Cookies["TBCbooksInCart"];
            var promoCookie = Request.Cookies["TBCPromoCode"];
            CheckoutOverviewViewModel overviewList = _orderService.getOrderOverview(orderDetails, cartCookie, promoCookie);

            return View(overviewList);
        }
        public IActionResult checkout() 
        {
            var userId = _userManager.GetUserId(User);
            if (!unpackOrderCookie() || orderDetails == null || addressId == 0 || paymentId == 0) {
                return RedirectToAction("index");
            }
            var cartCookie = Request.Cookies["TBCbooksInCart"];
            var promoCookie = Request.Cookies["TBCPromoCode"];
            _orderService.checkOut(userId, cartCookie, addressId, promoCookie);
            CheckoutOverviewViewModel overviewList = _orderService.getOrderOverview(orderDetails, cartCookie, promoCookie);
            Response.Cookies.Delete("TBCOrderDetails");
            Response.Cookies.Delete("TBCbooksInCart");
            Response.Cookies.Delete("TBCPromoCode");
            return View(overviewList);
        }

        private bool isLoggedIn() {
            return false;
        }
    }
}
