using System;
namespace TheBookCave.Data.EntityModels {
    public class PaymentDetail {
        public int Id { get; set; }
        // Id of user ownong this payment detail.
        public string UserId { get; set; }
        // Id of address linked tho this payment detail.
        public int AddressId { get; set; }
        // Name printed on the card.
        public string NameOnCard { get; set; }
        // Cards expiry date.
        public DateTime ExpiryDate { get; set; }
        // Card number printed on card.
        public string CardNumber { get; set; }
        // The CVC printed on back of card.
        public int CVC { get; set; }

    }
}