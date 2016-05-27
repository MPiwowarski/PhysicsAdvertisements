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
         
                <asp:TextBox ID="LoginControl" runat="server" CssClass="form-control"  placeholder="Login"></asp:TextBox>
                 <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3" >
                    <validatable:dataannotationvalidator ID="LoginValidatorControl" runat="server" ControlToValidate="LoginControl" Display="Dynamic"
                     PropertyToValidate="Login" OnInit="GetTypeName" Text="" CssClass="validation-label"/>
                </div>
                <label class="sr-only" for="inputPassword">Password</label>
       
                <asp:TextBox ID="PasswordControl" runat="server" CssClass="form-control" type="password" placeholder="Password"></asp:TextBox>
                 <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3" >
                    <validatable:dataannotationvalidator ID="PasswordValidatorControl" runat="server" ControlToValidate="PasswordControl" Display="Dynamic"
                     PropertyToValidate="Password" OnInit="GetTypeName" Text="" CssClass="validation-label"/>
                </div>
                <div class="checkbox">
                    <label>
                        <input type="checkbox" value="remember-me" />
                        Remember me
                    </label>
                </div>
                <%--<button class="btn btn-lg btn-primary btn-block" type="submit">Sign in</button>--%>
                <asp:Button ID="SubmitControl" CssClass="btn btn-lg btn-primary btn-block" runat="server" Text="Sign in" OnClick="SubmitControl_Click" />
                <asp:Label ID="StatusControl" runat="server" Text="" ></asp:Label>
                <br />
                <a href="/Home" class="btn-link">Back to Home page</a>

            </div>
        
            <div class="register">
                <a href="/Account/Register" class="btn-link">Create an account</a>
            </div>
        </form>
    </div>
</body>
</html>

