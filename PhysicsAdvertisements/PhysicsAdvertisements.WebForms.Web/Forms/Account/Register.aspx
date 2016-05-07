<%@ Page Language="C#" MasterPageFile="../Shared/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PhysicsAdvertisements.WebForms.Web.Forms.Account.Register" %>


<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <link href="../../App_Styles/Account/Register.css" rel="stylesheet" />
    <title>Register</title>
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="mainContent" runat="server">

    
    <div class="container register">
        <br />

        <div class="col-xs-12 col-sm-8 col-md-8 col-lg-8">
            <h3>Register and join us!</h3>
            <hr />

            <div class="row">
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <label>Login</label>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <asp:TextBox ID="LoginControl" runat="server" CssClass="form-control" placeholder="Login"></asp:TextBox>
                </div>
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3" >
                    <validatable:dataannotationvalidator ID="LoginValidatorControl" runat="server" ControlToValidate="LoginControl" Display="Dynamic"
                     PropertyToValidate="Login" OnInit="GetTypeName" Text="" CssClass="validation-label"/>
                </div>
            </div>

            <div class="row">
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <label>Password</label>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <asp:TextBox ID="PasswordControl" runat="server" CssClass="form-control" placeholder="Password" type="password"></asp:TextBox>
                </div>
                 <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3" >
                    <validatable:dataannotationvalidator ID="PasswordValidatorControl" runat="server" ControlToValidate="PasswordControl" Display="Dynamic"
                     PropertyToValidate="Password" OnInit="GetTypeName" Text="" CssClass="validation-label"/>
                </div>
            </div>

            <div class="row">
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <label>Password confirmation</label>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <asp:TextBox ID="PasswordConfirmationControl" runat="server" CssClass="form-control" placeholder="Confirm password" type="password"></asp:TextBox>
                </div>
                 <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3" >
                    <validatable:dataannotationvalidator ID="PasswordConfirmationValidatorControl" runat="server" ControlToValidate="PasswordConfirmationControl" Display="Dynamic"
                     PropertyToValidate="PasswordConfirmation" OnInit="GetTypeName" Text="" CssClass="validation-label"/>
                </div>
            </div>

            <div class="row">
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <label>Name</label>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <asp:TextBox ID="NameControl" runat="server" CssClass="form-control" placeholder="Name"></asp:TextBox>
                </div>
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3" >
                    <validatable:dataannotationvalidator ID="NameValidatorControl" runat="server" ControlToValidate="NameControl" Display="Dynamic"
                     PropertyToValidate="Name" OnInit="GetTypeName" Text="" CssClass="validation-label"/>
                </div>
            </div>

            <div class="row">
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <label>Surname</label>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <asp:TextBox ID="SurnameControl" runat="server" CssClass="form-control" placeholder="Surname"></asp:TextBox>
                </div>
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3" >
                    <validatable:dataannotationvalidator ID="SurnameValidatorControl" runat="server" ControlToValidate="SurnameControl" Display="Dynamic"
                     PropertyToValidate="Surname" OnInit="GetTypeName" Text="" CssClass="validation-label"/>
                </div>
            </div>
            

            <div class="row">
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <label>Birthday</label>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <asp:TextBox ID="BirthdayControl" runat="server" CssClass="form-control datepicker" placeholder="Birthday" ></asp:TextBox>
                </div>
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3" >
                    <validatable:dataannotationvalidator ID="BirthdayValidatorControl" runat="server" ControlToValidate="BirthdayControl" Display="Dynamic"
                     PropertyToValidate="Birthday" OnInit="GetTypeName" Text="" CssClass="validation-label"/>
                </div>
            </div>


            <%-- Sample DatePicker for tests only--%>
            <%-- <script src="//code.jquery.com/jquery-1.10.2.js"></script>--%>
            <%-- <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>--%>

            <%-- <script>
                $(function () {
                    $("#datepicker").datepicker();
                });
            </script>
            <p>Date: <input type="text" id="datepicker"></p>--%>

             <div class="row">
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <label>Gender</label>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <asp:RadioButtonList ID="GenderControl" runat="server" class="radio-button-list">
                        <asp:ListItem Value="0" Selected="True"> Male</asp:ListItem>
                        <asp:ListItem Value="1"> Female</asp:ListItem>
                        <asp:ListItem Value="2"> Other</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3" >
                    <validatable:dataannotationvalidator ID="GenderValidatorControl" runat="server" ControlToValidate="GenderControl" Display="Dynamic"
                     PropertyToValidate="Gender" OnInit="GetTypeName" Text="" CssClass="validation-label"/>
                </div>
            </div>

            <div class="row">
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <label>Phone number</label>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <asp:TextBox ID="PhoneNumberControl" runat="server" CssClass="form-control" placeholder="Phone number"></asp:TextBox>
                </div>
                 <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3" >
                    <validatable:dataannotationvalidator ID="PhoneNumberValidatorControl" runat="server" ControlToValidate="PhoneNumberControl" Display="Dynamic"
                     PropertyToValidate="PhoneNumber" OnInit="GetTypeName" Text="" CssClass="validation-label"/>
                </div>
            </div>

            <div class="row">
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <label>Email</label>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <asp:TextBox ID="EmailControl" runat="server" CssClass="form-control" placeholder="Email" type="email"></asp:TextBox>
                </div>
                 <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3" >
                    <validatable:dataannotationvalidator ID="EmailValidatorControl" runat="server" ControlToValidate="EmailControl" Display="Dynamic"
                     PropertyToValidate="Email" OnInit="GetTypeName" Text="" CssClass="validation-label"/>
                </div>
            </div>



            <div class="row">
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <asp:Button ID="SubmitControl" runat="server" Text="Register" CssClass="btn btn-primary submit" OnClick="SubmitControl_Click" CausesValidation="True" />                   
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <asp:Label ID="StatusControl" runat="server" Text="" CssClass="status-label" ></asp:Label>
                    
                </div>
            </div>
        </div>

        <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
             <h3>Check out!</h3>
            <hr />
            <img src="../../App_Images/Account/Register%20banner.png" class="img-responsive" alt="Register banner"/>
        </div>

    </div>

    <script src="../../App_Scripts/Account/DatePicker.js"></script>
</asp:Content>
