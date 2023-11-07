using ImplementStripInCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stripe;
using Stripe.Checkout;
using System.Diagnostics;

namespace ImplementStripInCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly SessionService _sessionService;
        private readonly PaymentIntentService _paymentIntentService;

        public HomeController(ILogger<HomeController> logger, SessionService sessionService, PaymentIntentService paymentIntentService, IConfiguration configuration)
        {
            _logger = logger;
            _sessionService = sessionService;
            _paymentIntentService = paymentIntentService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CheckOutPaymentWithStripe(string amount)
        {
            StripeConfiguration.ApiKey = _configuration["StripeOptions:SecretKey"];

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData=new SessionLineItemPriceDataOptions
                        {
                            Currency = "usd",
                            UnitAmount = Convert.ToInt32(amount) * 100,
                            ProductData=new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "Test Case",
                                Description = "Test CaseTest CaseTest CaseTest Case",
                                Images= new List<string> { "https://thewowstyle.com/wp-content/uploads/2015/01/nature-images..jpg" }
                            }
                        },
                        Quantity=1,
                    }
                },
                Mode = "payment",
                SuccessUrl = "add your success url here",
                CancelUrl = "add your cancel url here "
            };

            var service = new SessionService();
            var session = service.Create(options);
            HttpContext.Session.SetString("SessionID", session.Id);
            TempData["sessionId"] = session.Id;

            return Redirect(session.Url);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult IncompletePayment()
        {

            return View();
        }

        public IActionResult FailedPayment()
        {
            string errorMessage = Request.Query["error_message"];


            ViewData["ErrorMessage"] = errorMessage;

            return View();
        }
        public IActionResult CanceledPayment()
        {
            return View("Index");
        }

        public async Task<IActionResult> SuccessfulPayment()
        {
            string sessionId = TempData["sessionId"] as string;

            var service = new SessionService();
            Session session = service.Get(sessionId);

            string paymentStatus = session.PaymentStatus.ToLower();
            string paymentIntentId = paymentStatus == "paid" ? await GetPaymentIntentIdAsync(session) : null;

            var viewModel = new StripePaymentViewModel
            {
                PaymentIntentId = paymentIntentId,
                Currency = session.Currency,
                Amount = paymentStatus == "paid" ? (decimal)session.AmountTotal / 100 : 0
            };

            var viewModelList = new List<StripePaymentViewModel> { viewModel };
            return View(viewModelList);
        }



        private async Task<string> GetPaymentIntentIdAsync(Session session)
        {
            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = await paymentIntentService.GetAsync(session.PaymentIntentId);

            return paymentIntent.Id;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}