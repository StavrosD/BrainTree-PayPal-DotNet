Imports Braintree
Public Class _Default
    Inherits System.Web.UI.Page
    Public ClientToken As String
    Private myBrainTreeGateway As BraintreeGateway

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            myBrainTreeGateway = New BraintreeGateway With {
                .Environment = Environment.SANDBOX,
                .MerchantId = "replace_with_your_merchand_id",
                .PublicKey = "replace_with_your_public_key",
                .PrivateKey = "replace_with_your_private_key"
                }
            ClientToken = myBrainTreeGateway.ClientToken.Generate()
        Else
            dim myHttpContext = HttpContext.Current
            myHttpContext.Items.Add("basketId","example25") ' you may store variables such as the basketId in the httpContext
            Server.Transfer("ProcessPayment.aspx")
        End If
    End Sub
End Class