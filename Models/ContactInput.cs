using System.ComponentModel.DataAnnotations;

namespace TheBookCave.Models
{
    public class ContactInput
    {
        [Required(ErrorMessage = "Recipient is required")]
        public string Recipient {get; set; }
        [Required(ErrorMessage = "Subject is required")]
        public string Stubject { get; set;}
        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }
    }
}