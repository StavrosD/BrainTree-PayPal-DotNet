Public Class Fail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        if Not IsPostBack
            dim myHttpContext = HttpContext.Current
            BasketId.Text = myHttpContext.Items("basketId").ToString() 'You may use any variables stored when you initiated the payment to complete the order. 
        End If
    End Sub

End Class