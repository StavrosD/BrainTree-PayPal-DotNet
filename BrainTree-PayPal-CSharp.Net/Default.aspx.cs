using Braintree;
using System;
using System.Web;

namespace BrainTree_PayPal_CSharp.Net
{
    public partial class Default : System.Web.UI.Page
    {
        public string ClientToken;
        private BraintreeGateway braintreeGateway;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                braintreeGateway = new BraintreeGateway()
                {
                    Environment = Braintree.Environment.SANDBOX,
                    MerchantId = "replace_with_your_merchand_id",
                    PublicKey = "replace_with_your_public_key",
                    PrivateKey = "replace_with_your_private_key"
                };
                ClientToken = braintreeGateway.ClientToken.Generate();
            }
            else
            {
                HttpContext httpContext = HttpContext.Current;
                httpContext.Items.Add("basketId","example25");  // you may store variables such as the basketId in the httpContext
                Server.Transfer("ProcessPayment.aspx");
            }            
        }
    }
}