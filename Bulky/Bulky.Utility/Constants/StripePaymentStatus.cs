namespace BulkyBook.Utility.Constants
{
    /// <summary>
    /// The payment status of the Checkout Session, one of paid, unpaid, or no_payment_required.
    /// https://stripe.com/docs/api/checkout/sessions/object#checkout_session_object-payment_status
    /// </summary>
    public static class StripePaymentStatus
    {
        /// <summary>
        /// The payment funds are available in your account.
        /// </summary>
        public const string Paid = "paid";

        /// <summary>
        /// The payment funds are not yet available in your account.
        /// </summary>
        public const string Unpaid = "unpaid";

        /// <summary>
        /// The payment is delayed to a future date, or the Checkout Session is in setup mode and doesn’t require a payment at 
        /// </summary>
        public const string NoPaymentRequired = "no_payment_required";
    }
}
