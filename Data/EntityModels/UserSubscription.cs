/*
    Tening milli user og subscription
 */
using System;

namespace TheBookCave.Data.EntityModels {
    public class UserSubscription {
        // Might not need Id.
        public int Id { get; set; }
        // Path to user.
        public string UserId { get; set; }
        // path subscription.
        public int SubscriptionId { get; set; }
        // Date when subscripion was made.
        public DateTime Date { get; set; }

    }
}