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
            <div class="controls-container">
                <img  width="140" height="140" alt="Generic placeholder image" src="../../ecommerce-icon-set-freepik/New/login.png" />
                <h2 class="form-signin-heading">Please sign in</h2>
                <label class="sr-only" for="inputEmail">Email address</label>
                <%--<input id="inputEmail" class="form-control" type="email" autofocus="" required="" placeholder="Email address" />--%>
                <asp:TextBox ID="LoginControl" runat="server" CssClass="form-control"  placeholder="Login"></asp:TextBox>
                <label class="sr-only" for="inputPassword">Password</label>
               <%-- <input id="inputPassword" class="form-control" type="password" required="" placeholder="Password" />--%>
                <asp:TextBox ID="PasswordControl" runat="server" CssClass="form-control" type="password" placeholder="Password"></asp:TextBox>
                <div class="checkbox">
                    <label>
                        <input type="checkbox" value="remember-me" />
                        Remember me
                    </label>
                </div>
                <%--<button class="btn btn-lg btn-primary btn-block" type="submit">Sign in</button>--%>
                <asp:Button ID="SubmitControl" CssClass="btn btn-lg btn-primary btn-block" runat="server" Text="Sign in" OnClick="SubmitControl_Click" />
                <a href="/Home" class="btn-link">Back to Home page</a>

            </div>
        
            <div class="register">
                <a href="/Account/Register" class="btn-link">Create an account</a>
            </div>
        </form>
    </div>
</body>
</html>

