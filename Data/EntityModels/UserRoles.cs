using System.ComponentModel.DataAnnotations;

namespace TheBookCave.Data.EntityModels {
        public class UserRoles 
        {
            private string _id;
            [Key]
            public string UserdId
            {
                get { return _id; }
            }

            public string RoleId { get; set; }

        }
}
