<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PhysicsAdvertisements.WebForms.Web.Forms.Account.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <link href="../../App_Styles/Account/Login.css" rel="stylesheet" />
    <title>Login</title>
</head>
<body>
    <div class="container">
        <form class="form-signin" runat="server">
            <h2 class="form-signin-heading">Please sign in</h2>
            <label class="sr-only" for="inputEmail">Email address</label>
            <input id="inputEmail" class="form-control" type="email" autofocus="" required="" placeholder="Email address" />
            <label class="sr-only" for="inputPassword">Password</label>
            <input id="inputPassword" class="form-control" type="password" required="" placeholder="Password" />
            <div class="checkbox">
                <label>
                    <input type="checkbox" value="remember-me" />
                    Remember me
                </label>
            </div>
            <button class="btn btn-lg btn-primary btn-block" type="submit">Sign in</button>
                       
            <a href="/Home" class="btn-link">Back to Home page</a>
        </form>
    </div>
</body>
</html>

