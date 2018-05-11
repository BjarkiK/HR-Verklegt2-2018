using System.ComponentModel.DataAnnotations;

namespace TheBookCave.Data.EntityModels {
    public class PromoCode {
        public int Id { get; set; }
        // The promo code it self
        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; }
        // How much discount this promo code gives.
        [Required(ErrorMessage = "Discount is required")]
        public int Discount { get; set; }
        // Discription af the promo code.
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        // Determines if the promi code can be used or not.
        public bool Published { get; set; }
    }
}