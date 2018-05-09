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
    public class FrontPageController : Controller
    {
        private BookService _bookService;
        private AuthorService _authorService;
        private FrontPageViewModel _frontPageViewModel;

        public FrontPageController() {
            _bookService = new BookService();
            _authorService = new AuthorService();
            _frontPageViewModel = new FrontPageViewModel();
        }
        public IActionResult index() {
            top10Books();
            newestBooks();
            return View(_frontPageViewModel);
        }
        public IActionResult signUp() {
            return View();
        }
        private void top10Books()  {
            _frontPageViewModel.Top10 = _bookService.getTop10Books();
        }
        private void newestBooks() {
            _frontPageViewModel.Newest =  _bookService.getNewestBooks(10);
        }
    }
}
