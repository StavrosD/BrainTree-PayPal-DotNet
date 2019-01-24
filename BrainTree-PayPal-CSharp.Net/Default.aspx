<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BrainTree_PayPal_CSharp.Net.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Load PayPal's checkout.js Library. -->
    <script src="https://www.paypalobjects.com/api/checkout.js" data-version-4 log-level="warn"></script>

    <!-- Load the client component. -->
    <script src="https://js.braintreegateway.com/web/3.42.0/js/client.min.js"></script>

    <!-- Load the PayPal Checkout component. -->
    <script src="https://js.braintreegateway.com/web/3.42.0/js/paypal-checkout.min.js"></script>
    
    <br/><br/>
    This is an example 
    <asp:Button ID="Button1" runat="server" Text="Button" ClientIDMode="Static" EnableViewState="True" Visible="False" />
    <div id="paypal-button"></div>
    <div id="dropin-container"></div>
    <script>
        // Create a client. //'sandbox_3zsf3q2g_replace_with_your_merchand_id'  
        braintree.client.create({
            authorization: '<%= ClientToken %>',
            container: '#dropin-container'
        }, function (clientErr, clientInstance) {
            // Stop if there was a problem creating the client.
            // This could happen if there is a network error or if the authorization
            // is invalid.
            if (clientErr) {
                console.error('Error creating client:', clientErr);
                return;
            }
            // Create a PayPal Checkout component.
            braintree.paypalCheckout.create({
                client: clientInstance
            }, function (paypalCheckoutErr, paypalCheckoutInstance) {

                // Stop if there was a problem creating PayPal Checkout.
                // This could happen if there was a network error or if it's incorrectly
                // configured.
                if (paypalCheckoutErr) {
                    console.error('Error creating PayPal Checkout:', paypalCheckoutErr);                    
                    return;
                }

                // Set up PayPal with the checkout.js library
                paypal.Button.render({
                    env: 'sandbox', // or 'sandbox'

                    payment: function () {
                        return paypalCheckoutInstance.createPayment({
                            // Your PayPal options here. For available options, see
                            // http://braintree.github.io/braintree-web/current/PayPalCheckout.html#createPayment
                            flow: 'checkout',
                            amount: '10.0',  //  We set the amount on the code but it also madatory to set here any value, otherwise we will get an error
                            currency: 'EUR',
                            intent: 'sale'
                        });
                    },

                    onAuthorize: function (data, actions) {
                        return paypalCheckoutInstance.tokenizePayment(data, function (err, payload) {
                            // Submit `payload.nonce` to your server.
                            var myForm = document.getElementById("form1");
                            document.getElementById('__EVENTTARGET').value = 'Button1';
                            document.getElementById('__EVENTARGUMENT').value = payload.nonce;
                            document.forms[0].submit();
                        });
                    },

                    onCancel: function (data) {
                        console.log('checkout.js payment cancelled', JSON.stringify(data, 0, 2));
                    },

                    onError: function (err) {
                        console.error('checkout.js error', err);
                    }
                }, '#paypal-button').then(function () {
                    // The PayPal button will be rendered in an html element with the id
                    // `paypal-button`. This function will be called when the PayPal button
                    // is set up and ready to be used.
                });

            });

        });


    </script>
</asp:Content>
