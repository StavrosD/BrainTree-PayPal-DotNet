using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrainTree_PayPal_CSharp.Net
{
    public partial class Fail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpContext httpContext = HttpContext.Current;
                BasketId.Text = httpContext.Items["basketId"].ToString(); // You may use any variables stored when you initiated the payment to complete the order. 
            }            
        }
    }
}