# SendSMSFromTwilio
This is a ASP.Net Web Application to send SMS using Twilio API and Email using SendGrid API

To send SMS to any Phone Number, follow the steps

1) Clone the Repo
`git clone https://github.com/meghnaparsan/SendSMSFromTwilio.git`

<<<<<<< HEAD
## Twilio
1) Create a [Twilio Account](https://www.twilio.com/console) and get a Phone Number. (Trial Account provides one Phone Number for free)
2) From the Twilio console, get the AccountSID and AuthToken.

## SendGrid
1) Create a [SendGrid Account](https://app.sendgrid.com/).
2) Authenticate the [Sender Email](https://app.sendgrid.com/settings/sender_auth)

## Send SMS and Email
1) Create two files in the Project root Directory
=======
2) Create a Twilio Account and get a Phone Number. (Trial Account provides one Phone Number for free)
3) From the Twilio console, get the AccountSID and AuthToken.
4) Create a SendGrid Account, and complete the "SenderAuthentication"
5) Create two files in the Project root Directory
>>>>>>> 1313de85088181f9ce95d92b8f84ae3594dafab9
  - appsettings.Development.json
  - appsettings.json
  
 In both the files, add the following code.
 ```
 {
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },

  "AppVariables": {
    "AccountSID": "YOUR-ACCOUNT-SID",
    "AuthToken": "YOUR-AUTH-TOKEN",
<<<<<<< HEAD
    "ApiKey": "SENG-GRID-API-KEY",
    "PhoneNumber": "TWILIO-NUMBER",
    "SenderEmail": "SENDER-EMAIL",
    "ReceiverEmail": "RECEIVER-EMAIL"
=======
    "ApiKey": "YOUR-API-KEY" 
>>>>>>> 1313de85088181f9ce95d92b8f84ae3594dafab9
  }
}
 ```
 
 2) To run the project -> `dotnet run`
