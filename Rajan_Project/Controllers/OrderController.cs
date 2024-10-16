using Microsoft.AspNetCore.Mvc;
using Rajan_Project.Models;
using Razorpay.Api;

namespace Rajan_Project.Controllers
{
    public class OrderController : Controller
    {
        //[BindProperty]
        ////public OrderEntity _orderdetails { get; set; }
        public IActionResult InitiateOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InitiateOrder(OrderEntity _orderdetails)
        {
            if(ModelState.IsValid)
            {
                string key = "rzp_test_TCPadqlXFXnRG9";
                string secret = "eF4tlaI3b7QxoAHmqquHw234";

                Random _random = new Random();
                string Transaction_id = _random.Next(0, 10000).ToString();

                Dictionary<string, object> input = new Dictionary<string, object>();
                input.Add("amount", Convert.ToDecimal(_orderdetails.TotalAmmount) * 100); // this amount should be same as transaction amount
                input.Add("currency", "INR");
                input.Add("receipt", "Transaction_id");

                RazorpayClient client = new RazorpayClient(key, secret);
                Razorpay.Api.Order order = client.Order.Create(input);
                ViewBag.orderid = order["id"].ToString();

                return View("Payment", _orderdetails);
            }
            else
            {
                TempData["Error Message"] = "Please Check All Field";
            }
            return View();
        }

        public IActionResult Payment(string razorpay_payment_id, string razorpay_order_id,string razorpay_signature)
        {
            Dictionary<string,string> attribute = new Dictionary<string,string>();
            attribute.Add("razorpay_payment_id", razorpay_payment_id);
            attribute.Add("razorpay_order_id", razorpay_order_id);
            attribute.Add("razorpay_signature", razorpay_signature);

            Utils.verifyPaymentSignature(attribute);

            PaymentData paydata = new PaymentData();
            paydata.Transaction_Id = razorpay_payment_id;
            paydata.Order_ID = razorpay_order_id;

            return View("PaymentSuccess", paydata);
        }
    }
}
