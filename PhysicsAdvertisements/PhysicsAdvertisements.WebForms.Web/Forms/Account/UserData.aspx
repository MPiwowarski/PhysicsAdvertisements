<%@ Page Language="C#" MasterPageFile="../Shared/Site.Master" AutoEventWireup="true" CodeBehind="UserData.aspx.cs" Inherits="PhysicsAdvertisements.WebForms.Web.Forms.Account.UserData" %>

<%@ Register Src="~/UserControls/AdvertisementsSearch/ControlTemplates/AdvertisementsSearch.ascx" TagPrefix="uc1" TagName="AdvertisementsSearch" %>
<%@ Register Src="~/UserControls/UserMenu/ControlTemplates/UserMenu.ascx" TagPrefix="uc1" TagName="UserMenu" %>



<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <link href="../../UserControls/AdvertisementsSearch/Layouts/AdvertisementsSearch_UserPanel.css" rel="stylesheet" />
    <link href="../../App_Styles/Account/UserData.css" rel="stylesheet" />
    <link href="../../UserControls/UserMenu/Layouts/UserMenu.css" rel="stylesheet" />
    <title>User data</title>
</asp:Content>

<%--https://developer.mozilla.org/en-US/docs/Web/Security/Securing_your_site/Turning_off_form_autocompletion--%>
<asp:Content ID="MainContent" ContentPlaceHolderID="mainContent" runat="server">
    <div class="container">
        <br />
        <uc1:AdvertisementsSearch runat="server" ID="AdvertisementsSearch" />
    </div>

    <div class="container user-data">
        <br />
        <div class="col-xs-12 col-sm-8 col-md-8 col-lg-8">
            <h3>User data</h3>
            <hr />
            <uc1:UserMenu runat="server" ID="UserMenu" />



            <div class="row">
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <label>Login</label>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <asp:TextBox autocomplete="nope" ID="LoginControl" runat="server" CssClass="form-control" placeholder="Login" ></asp:TextBox>
                </div>
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <validatable:DataAnnotationValidator ID="LoginValidatorControl" runat="server"  ControlToValidate="LoginControl" Display="Dynamic"
                        PropertyToValidate="Login" OnInit="GetTypeName" Text="" CssClass="validation-label" />
                </div>
            </div>

            <div class="row">
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <label>Password</label>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <asp:TextBox autocomplete="nope" ID="PasswordControl" runat="server"  CssClass="form-control" placeholder="Password" type="password" ></asp:TextBox>
                </div>
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <validatable:DataAnnotationValidator ID="PasswordValidatorControl" runat="server" ControlToValidate="PasswordControl" Display="Dynamic"
                        PropertyToValidate="Password" OnInit="GetTypeName" Text="" CssClass="validation-label" />
                </div>
            </div>

            <div class="row">
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <label>Password confirmation</label>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <asp:TextBox ID="PasswordConfirmationControl" runat="server" CssClass="form-control" placeholder="Confirm password" type="password" ></asp:TextBox>
                </div>
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <validatable:DataAnnotationValidator ID="PasswordConfirmationValidatorControl" runat="server" ControlToValidate="PasswordConfirmationControl" Display="Dynamic"
                        PropertyToValidate="PasswordConfirmation" OnInit="GetTypeName" Text="" CssClass="validation-label" />
                </div>
            </div>

            <div class="row">
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <label>Name</label>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <asp:TextBox ID="NameControl" runat="server" CssClass="form-control" placeholder="Name"></asp:TextBox>
                </div>
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <validatable:DataAnnotationValidator ID="NameValidatorControl" runat="server" ControlToValidate="NameControl" Display="Dynamic"
                        PropertyToValidate="Name" OnInit="GetTypeName" Text="" CssClass="validation-label" />
                </div>
            </div>

            <div class="row">
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <label>Surname</label>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <asp:TextBox ID="SurnameControl" runat="server" CssClass="form-control" placeholder="Surname"></asp:TextBox>
                </div>
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <validatable:DataAnnotationValidator ID="SurnameValidatorControl" runat="server" ControlToValidate="SurnameControl" Display="Dynamic"
                        PropertyToValidate="Surname" OnInit="GetTypeName" Text="" CssClass="validation-label" />
                </div>
            </div>


            <div class="row">
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <label>Birthday</label>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <asp:TextBox ID="BirthdayControl" runat="server" CssClass="form-control datepicker" placeholder="Birthday"></asp:TextBox>
                </div>
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <validatable:DataAnnotationValidator ID="BirthdayValidatorControl" runat="server" ControlToValidate="BirthdayControl" Display="Dynamic"
                        PropertyToValidate="Birthday" OnInit="GetTypeName" Text="" CssClass="validation-label" />
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
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <validatable:DataAnnotationValidator ID="GenderValidatorControl" runat="server" ControlToValidate="GenderControl" Display="Dynamic"
                        PropertyToValidate="Gender" OnInit="GetTypeName" Text="" CssClass="validation-label" />
                </div>
            </div>

            <div class="row">
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <label>Phone number</label>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <asp:TextBox ID="PhoneNumberControl" runat="server" CssClass="form-control" placeholder="Phone number"></asp:TextBox>
                </div>
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <validatable:DataAnnotationValidator ID="PhoneNumberValidatorControl" runat="server" ControlToValidate="PhoneNumberControl" Display="Dynamic"
                        PropertyToValidate="PhoneNumber" OnInit="GetTypeName" Text="" CssClass="validation-label" />
                </div>
            </div>

            <div class="row">
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <label>Email</label>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <asp:TextBox ID="EmailControl" runat="server" CssClass="form-control" placeholder="Email" type="email"></asp:TextBox>
                </div>
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <validatable:DataAnnotationValidator ID="EmailValidatorControl" runat="server" ControlToValidate="EmailControl" Display="Dynamic"
                        PropertyToValidate="Email" OnInit="GetTypeName" Text="" CssClass="validation-label" />
                </div>
            </div>



            <div class="row">
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <asp:Button ID="SubmitControl" runat="server" Text="Save changes" CssClass="btn btn-primary submit" OnClick="SubmitControl_Click" CausesValidation="True" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <asp:Label ID="StatusControl" runat="server" Text=""></asp:Label>

                </div>
            </div>
        </div>



        <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
            <h3>Enjoy!</h3>
            <hr />
            
            <div style="width:350px; height:540px; border:red 1px solid;">

            </div>
            
           <%-- <img src="../../App_Images/Account/Register%20banner.png" class="img-responsive" alt="Register banner" />--%>
        </div>
    </div>
    <script src="../../App_Scripts/Account/DatePicker.js"></script>
</asp:Content>
