using System.Collections.Generic;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;
using System.Linq;

namespace TheBookCave.Services {
    public class HelpService {
        private HelpRepo _helpRepo;
        private TypeRepo _typeRepo;

        public HelpService(){
            _helpRepo = new HelpRepo();
            _typeRepo = new TypeRepo();
        }
        public List<HelpListViewModel> getHelpBySearch(string search){
            /*var help = _helpRepo.GetAllHelps();
            filter out where it matches search*/
            return null;
        }
        public List<HelpListViewModel> getHelpByType(string type){
            var help = _helpRepo.getAllHelps();
            var typeVar = _typeRepo.getAllTypes();
            var result =    (from h in help
                            join t in typeVar
                            on h.TypeId equals t.Id
                            where t.TypeEn.ToLower() == type.ToLower()
                            select h).ToList();
            /*and filter out where it matches type */
            return result;
        }
    }
}