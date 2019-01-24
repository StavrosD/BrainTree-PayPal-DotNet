Imports Braintree
Public Class ProcessPayment
    Inherits System.Web.UI.Page
    Private PaymentMethodNonce As String
    Private myBrainTreeGateway As BraintreeGateway

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not IsNothing(PreviousPage) Then

                PaymentMethodNonce = PreviousPage.Request.Form("__EVENTARGUMENT")
                myBrainTreeGateway = New BraintreeGateway With {
                .Environment = Environment.SANDBOX,
                .MerchantId = "replace_with_your_merchand_id",
                .PublicKey = "replace_with_your_public_key",
                .PrivateKey = "replace_with_your_private_key"
        }
            Else ' if the page is opened in browser by the user and not by default.aspx
                Response.Redirect("Default.aspx.")
            End If
        Else  ' There is no control that could post back to this page. Only a hacking attemp could submit a postback.
            Response.Redirect("Default.aspx.")
        End If
        Pay()
    End Sub
    Private Sub Pay()
        Dim myTransactionOptionsPayPalRequest As New TransactionOptionsPayPalRequest With {
                .Description = "Sample for Braintree - PayPal payment by Stavros Dimopoulos RnD@sdim.gr"                  ', .CustomField = "PayPal custom field",            }                
                }

        Dim myTransactionOptionsRequest As New TransactionOptionsRequest With {
                .SubmitForSettlement = True'
                } '.PayPal = TransactionOptionsPayPalRequest


        Dim myTransactionRequest = New TransactionRequest With {
                .Amount = 100.00D, ' 1000 euro payment
                .PaymentMethodNonce = PaymentMethodNonce,
                .Options = myTransactionOptionsRequest '
                }

        Dim myResult As Result(Of Transaction)
        Try
            myResult = myBrainTreeGateway.Transaction.Sale(myTransactionRequest)
            dim myHttpContext = HttpContext.Current
            myHttpContext.Items.Add("result",myResult.Message) ' optional. You may store any variable.
            If myResult.IsSuccess() Then
                Server.Transfer("Success.aspx")
            Else
                Server.Transfer("Fail.aspx")
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)


        End Try
    End Sub
End Class