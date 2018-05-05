using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories {
    public class UserGradeRepo {
        private DataContext _db;

        public UserGradeRepo() {
            _db = new DataContext();
        }
        public List<UserReviewListViewModel> getReviewBook(int rid) {
            var review = (from rev in _db.UserReviews 
                                where rev.Id == rid
                                select new UserReviewListViewModel {
                                Id = rev.Id,
                                BookId = rev.BookId,
                                Date = rev.Date,
                                Grade = rev.Grade,
                                Review = rev.Review,
                                UserId = rev.UserId
                                }).ToList();
            return review;
        }
        public List<UserReviewListViewModel> getAllReviewsBook(int bid) {
            var review = (from rev in _db.UserReviews
                                where rev.BookId == bid
                                select new UserReviewListViewModel {
                                Id = rev.Id,
                                BookId = rev.BookId,
                                Date = rev.Date,
                                Grade = rev.Grade,
                                Review = rev.Review,
                                UserId = rev.UserId
                                }).ToList();
            return review;
        }
        public bool updateReview(int rid) {
            // linq update
            return true;
        }
        public bool deleteReview(int rid) {
            // linq delete
            return true;
        }
        public bool createReview() {
            // linq insert
            return true;
        }
    }
}