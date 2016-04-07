# B2C-WebApp-OpenIDConnect-DotNet-SUSI
Azure AD B2C has recently introduced a new type of [policy](https://azure.microsoft.com/documentation/articles/active-directory-b2c-reference-policies/) knows as the **Sign Up or Sign In policy**.  In a nutshell, a sign up or sign in policy allows users to sign-in with an existing account if they have one, or create a new one if it is their first time using the app.  Users can choose from the configured set of identity providers to create an account, including both social & local IDPs.  Using a sign up or sign in policy allows you to create a single button in your application for interacting with AAD B2C, instead of two (one for sign-up and another for sign-in).

If this is your first time experiementing with Azure AD B2C, we recommend starting with our developer guide located at [aka.ms/aadb2c](http://aka.ms/aadb2c).  If instead you would like to see how the sign up policy & the sign-in policy work in a two-button configuration, check out [this tutorial](https://azure.microsoft.com/documentation/articles/active-directory-b2c-devquickstarts-web-dotnet/).

## About the code

The code in this sample is a dead-simple ASP.NET 4.5 web application using the MVC 5 framework.  It performs the following functions:

- Allows the user to sign-up or sign-in using Azure AD B2C.
- Allows the user to reset their password using Azure AD B2C.
- Displays information about the user in the form of claims.
- Allows the user to sign out using Azure AD B2C.

ASP.NET web applications can leverage the OWIN middlware, which is a framework for pluggable modules that perform common services, such as authentication.  This web app uses the `Microsoft.Owin.Security.OpenIdConnect` package to interact with Azure AD B2C over the [OpenID Connect](http://openid.net/connect/) authentication protocol.  To learn more about OpenID Connect & the supported protocols in AAD B2C, see our [reference material](https://azure.microsoft.com/documentation/articles/active-directory-b2c-reference-protocols/).

Most of the interesting code in this sample is contained in the [`Startup.Auth.cs`](https://github.com/AzureADQuickStarts/B2C-WebApp-OpenIDConnect-DotNet-SUSI/blob/master/WebApp-B2C-DotNet/App_Start/Startup.Auth.cs) file.  This is where the OWIN authentication module is configured and the majority of interaction with Azure AD B2C occurs.

The [`AccountController.cs`](https://github.com/AzureADQuickStarts/B2C-WebApp-OpenIDConnect-DotNet-SUSI/blob/master/WebApp-B2C-DotNet/Controllers/AccountController.cs) file is where the OWIN authenticaion middleware is triggered.  The actions here are primarily our authentication button-click handlers.

The [`HomeController.cs`](https://github.com/AzureADQuickStarts/B2C-WebApp-OpenIDConnect-DotNet-SUSI/blob/master/WebApp-B2C-DotNet/Controllers/HomeController.cs) is very simple, but instructive in showing how to access user information in the form of claims.

Lastly, the classes in the [`PolicyAuthHelpers`](https://github.com/AzureADQuickStarts/B2C-WebApp-OpenIDConnect-DotNet-SUSI/tree/master/WebApp-B2C-DotNet/PolicyAuthHelpers) folder have been included as part of the sample code to make interacting with Azure AD B2C using the OWIN middleware a bit easier for ASP.NET developers.  They are not part of any official library, and can be used or modified at your discretion.

## Running the sample

To run the sample, you can simply clone (or download) the repo, open it in Visual Studio 2013 or 2015, build the solution, and hit F5.  It is currently configured to work against an example Azure AD B2C tenant, known as **fabrikamb2c.onmicrosoft.com**, using two pre-configured policies.  Once you have it running, you can try things out by performing sign-up & sign-in using any of the available identity providers.

To go further, we recommned replacing the config values in the [`web.config`](https://github.com/AzureADQuickStarts/B2C-WebApp-OpenIDConnect-DotNet-SUSI/blob/master/WebApp-B2C-DotNet/Web.config#L12-L17) with those of your own Azure AD B2C tenant.  You will need:

- Your own Azure AD B2C tenant, which can be created following [these steps](https://azure.microsoft.com/documentation/articles/active-directory-b2c-get-started/).
- A client ID registered in your tenant, which can be created following [these steps](https://azure.microsoft.com/documentation/articles/active-directory-b2c-app-registration/).
- Your own **Sign-Up or Sign-In** and **Password Reset** policies, which are described on [this page](https://azure.microsoft.com/documentation/articles/active-directory-b2c-reference-policies/#create-a-sign-up-or-sign-in-policy).
- You can leave both the `ida:RedirectUri` and the `ida:AadInstance` values exactly as is.

Once you've replaced the confg values with your own, you can use this application against your very own Azure AD B2C tenant!  Note that this code sample does not maintain any state or record (like a database) of users.  Instead, the user store is completely mastered in Azure AD B2C.  So, if you would like to see the list of users who have signed-up for your application, you must do so by looking in your B2C directory tenant in the Azure Management Portals.

Best of luck!  To learn more about Azure AD B2C please visit our developer guide [aka.ms/aadb2c](http://aka.ms/aadb2c).

#### Troubleshooting

Here are some common gotcha's that you might run into when trying to run this sample:

- When you download the sample,the default directory name can be fairly long.  Occasionally the path to certain files in the solution becomes too long for Visual Studio to handle.  If you get a build error of this nature, try shortenting the path to your solution by changing the directory names or moving it up a few levels.
- Occasinally you may experience build errors having to do with NuGet package restore.  If you do, try opening up the NuGet Package Manager and restoring any missing packages.  If worse comes to worst, deleting the `packages` directory and restoring once again usually solves the issue.
- If you come across an unhandled exception after clicking a button, it's typically caused by a misspell in your `web.config`.  Azure AD B2C & the OWIN middleware make heavy use of an OpenID Connect metadata endpoint, and retreiving information from this endpoint requires exactly correct spelling.  Make sure you've spelled your tenant name precisely (it should take the form `*.onmicrosoft.com`), and that your policies are correct as well (they should take the form `b2c_1_*`).
