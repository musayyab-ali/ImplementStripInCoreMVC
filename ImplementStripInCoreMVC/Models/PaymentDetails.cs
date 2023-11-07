namespace ImplementStripInCoreMVC.Models
{
    public class PaymentDetails
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public double amount { get; set; }
        public int amount_capturable { get; set; }
        public AmountDetails amount_details { get; set; }
        public int amount_received { get; set; }
        public object application { get; set; }
        public object application_fee_amount { get; set; }
        public object automatic_payment_methods { get; set; }
        public object canceled_at { get; set; }
        public object cancellation_reason { get; set; }
        public string capture_method { get; set; }
        public string client_secret { get; set; }
        public string confirmation_method { get; set; }
        public int created { get; set; }
        public string currency { get; set; }
        public object customer { get; set; }
        public object description { get; set; }
        public object invoice { get; set; }
        public object last_payment_error { get; set; }
        public string latest_charge { get; set; }
        public bool livemode { get; set; }
        public Metadata metadata { get; set; }
        public object next_action { get; set; }
        public object on_behalf_of { get; set; }
        public string payment_method { get; set; }
        public PaymentMethodOptions payment_method_options { get; set; }
        public List<string> payment_method_types { get; set; }
        public object processing { get; set; }
        public object receipt_email { get; set; }
        public object review { get; set; }
        public object setup_future_usage { get; set; }
        public object shipping { get; set; }
        public object source { get; set; }
        public object statement_descriptor { get; set; }
        public object statement_descriptor_suffix { get; set; }
        public string status { get; set; }
        public object transfer_data { get; set; }
        public object transfer_group { get; set; }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class AmountDetails
        {
            public Tip tip { get; set; }
        }

        public class Card
        {
            public object capture_method { get; set; }
            public object installments { get; set; }
            public object mandate_options { get; set; }
            public object network { get; set; }
            public string request_three_d_secure { get; set; }
            public object setup_future_usage { get; set; }
            public object statement_descriptor_suffix_kana { get; set; }
            public object statement_descriptor_suffix_kanji { get; set; }
        }

        public class Metadata
        {
        }

        public class PaymentMethodOptions
        {
            public object acss_debit { get; set; }
            public object affirm { get; set; }
            public object afterpay_clearpay { get; set; }
            public object alipay { get; set; }
            public object au_becs_debit { get; set; }
            public object bacs_debit { get; set; }
            public object bancontact { get; set; }
            public object blik { get; set; }
            public object boleto { get; set; }
            public Card card { get; set; }
            public object card_present { get; set; }
            public object cashapp { get; set; }
            public object customer_balance { get; set; }
            public object eps { get; set; }
            public object fpx { get; set; }
            public object giropay { get; set; }
            public object grabpay { get; set; }
            public object ideal { get; set; }
            public object interac_present { get; set; }
            public object klarna { get; set; }
            public object konbini { get; set; }
            public object link { get; set; }
            public object oxxo { get; set; }
            public object p24 { get; set; }
            public object paynow { get; set; }
            public object paypal { get; set; }
            public object pix { get; set; }
            public object promptpay { get; set; }
            public object sepa_debit { get; set; }
            public object sofort { get; set; }
            public object us_bank_account { get; set; }
            public object wechat_pay { get; set; }
            public object zip { get; set; }
        }

        public class Tip
        {
            public int amount { get; set; }
        }


    }
}
