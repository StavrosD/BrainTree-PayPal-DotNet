using Braintree;
using System;
using System.Web;

namespace BrainTree_PayPal_CSharp.Net
{
    public partial class ProcessPayment : System.Web.UI.Page
    {
        private string paymentMethodNonce;
        private BraintreeGateway braintreeGateway;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!(null == PreviousPage))
                {
                    paymentMethodNonce = PreviousPage.Request.Form["__EVENTARGUMENT"].ToString();
                    braintreeGateway = new BraintreeGateway()
                    {
                        Environment = Braintree.Environment.SANDBOX,
                        MerchantId = "replace_with_your_merchand_id",
                        PublicKey = "replace_with_your_public_key",
                        PrivateKey = "replace_with_your_private_key"
                    };
                }
                else  // if the page is opened in browser by the user and not by default.aspx
                {
                    Response.Redirect("Default.aspx");
                }
            }
            else // There is no control that could post back to this page. Only a hacking attemp could submit a postback.
            {
                Response.Redirect("Default.aspx");
            }

            Pay();
        }

        private void Pay()
        {
            TransactionOptionsPayPalRequest transactionOptionsPayPalRequest = new TransactionOptionsPayPalRequest()
            {
                Description = "Sample for Braintree - Paypal payment by Stavros Dimopoulos  RnD@sdim.gr"
            };

            TransactionOptionsRequest transactionOptionsRequest = new TransactionOptionsRequest()
            {
                SubmitForSettlement = true
            };

            TransactionRequest transactionRequest = new TransactionRequest()
            {
                Amount = 100.00M,
                PaymentMethodNonce = paymentMethodNonce,
                Options = transactionOptionsRequest
            };

            Result<Transaction> myResult;
            try
            {
                myResult = braintreeGateway.Transaction.Sale(transactionRequest);
                HttpContext httpContext = HttpContext.Current;
                httpContext.Items.Add("result", myResult.Message); // optional. You may store any variable.
                if (myResult.IsSuccess())
                {                    
                    Server.Transfer("Success.aspx");
                }
                else
                { 
                    Server.Transfer("Fail.aspx");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }    
    }
    
    
}