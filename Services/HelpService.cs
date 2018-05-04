using System.Collections.Generic;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services {
    public class HelpService {
        private HelpRepo _helpRepo;

        public HelpService(){
            _helpRepo = new HelpRepo();
        }
        public List<HelpListViewModel> GetHelpBySearch(string search){
            /*var help = _helpRepo.GetAllHelps();
            filter out where it matches search*/
            return null;
        }
        public List<HelpListViewModel> GetHelpByType(string type){
            /*var help = _helpRepo.GetAllHelps();
            and filter out where it matches type */
            return null;
        }
    }
}