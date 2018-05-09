using System.Collections.Generic;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;
using System.Linq;

namespace TheBookCave.Services {
    public class HelpService {
        private HelpRepo _helpRepo;
        private HelpTypeRepo _helpTypeRepo;

        public HelpService(){
            _helpRepo = new HelpRepo();
            _helpTypeRepo = new HelpTypeRepo();
        }
        public List<HelpListViewModel> getHelpBySearch(string search){
            var help = _helpRepo.getAllHelps();
            var typeVar = _helpTypeRepo.getAllTypes();
            var result =    (from h in help
                            join t in typeVar
                            on h.TypeId equals t.Id
                            where t.TypeEN.ToLower().Contains(search.ToLower())
                            select h).ToList();
            return result;
        }
        public List<HelpListViewModel> getHelpByType(string type){
            var help = _helpRepo.getAllHelps();
            var typeVar = _helpTypeRepo.getAllTypes();
            var result =    (from h in help
                            join t in typeVar
                            on h.TypeId equals t.Id
                            where t.TypeEN.ToLower() == type.ToLower()
                            select h).ToList();
            return result;
        }
    }
}