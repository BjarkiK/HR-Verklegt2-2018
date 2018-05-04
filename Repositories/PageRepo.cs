using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories {
    public class PageRepo {
        private DataContext _db;

        public PageRepo() {
            _db = new DataContext();
        }
        public string getLanguage(int lid) {
            // Óviss með virkni í þessu
            return null;
        }
        // Ekki alveg 100% á hvaða tilgangi update delete og create hefur í language heldur..
    }
}