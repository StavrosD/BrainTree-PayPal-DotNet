# Braintree-Paypal working example for C# and VB.NET

I could not find a working example for PayPal and Braintree integration with ASP.NET webforms so I made one.
There are many posts on every forum with people having problems with this integration. The paypal script intercepts the normal .net page flow and it is impossible to complete a transaction.

This project has the minimum code needed to do the job. It is mostly for proof of concept but it works 100% fine!

The latest Braintree 
## How it works

It is impossible to complete a transaction in a single page.

The solution is simple: When the paypal script posts the payment_token_nonce to the page, I intercept the normal page flow with **Server.Transfer** to transfer the workflow to a new page (**ProcessPayment.aspx**).
	
Server.Transfer terminates execution of the current page and starts execution of a new page.

Then I execude the transaction without the problem caused by the PayPal and asp.net scripts.

After the transaction is complete, Success.aspx or Fail.aspx is executed.

## Getting Started

There are two projects, one for C# and one for VB.NET.
Right click on the project you want to run and select "Set as startup project."


### Prerequisites

1. PayPal account.
2. Braintree account.
3. The PayPal account is linked to the Braintree account.
4. ![API keys](https://articles.Braintreepayments.com/control-panel/important-gateway-credentials#api-credentials)

## Installation

Before you run the project you should initialize the BraintreeGateway with your API credentials. 

 myBraintreeGateway = New BraintreeGateway With {
                .Environment = Environment.SANDBOX,
                .MerchantId = "replace_with_your_merchand_id",
                .PublicKey = "replace_with_your_public_key",
                .PrivateKey = "replace_with_your_private_key"
                }

## Author

**[Stavros Dimopoulos](https://github.com/StavrosD) **

[My LinkedIn profile](https://www.linkedin.com/in/stavrosdim/)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Donation

It's my first open source projet.

I've seen this button many times, I do not know how it works but I guess it is not a bad idea to have it in my project repo ;-)

[![Support via PayPal](support_paypal.svg)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=K94L2LGP4CWBL&source=url)
