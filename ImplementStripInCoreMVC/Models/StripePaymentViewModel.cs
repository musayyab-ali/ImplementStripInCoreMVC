namespace ImplementStripInCoreMVC.Models
{
    public class StripePaymentViewModel
    {
        public string PaymentIntentId { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
    }
}
