using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories {
    public class HelpRepo {
        private DataContext _db;

        public HelpRepo() {
            _db = new DataContext();
        }
        public List<HelpListViewModel> GetHelp(int hid) {
            var help = (from h in _db.Helps
                                where h.Id == hid
                                select new HelpListViewModel {
                                Id = h.Id,
                                AnswerEN = h.AnswerEN,
                                AnswerIS = h.AnswerIS,
                                GenreId = h.GenreId,
                                Question = h.Question
                                }).ToList();
            return help;
        }
        public List<HelpListViewModel> GetAllHelps() {
            var help = (from h in _db.Helps
                                select new HelpListViewModel {
                                Id = h.Id,
                                AnswerEN = h.AnswerEN,
                                AnswerIS = h.AnswerIS,
                                GenreId = h.GenreId,
                                Question = h.Question
                                }).ToList();
            return help;
        }        public bool updateHelp(int hid) {
            // linq update
            return true;
        }
        public bool deleteHelp(int hid) {
            // linq delete
            return true;
        }
        public bool createHelp() {
            // linq insert
            return true;
        }
    }
}