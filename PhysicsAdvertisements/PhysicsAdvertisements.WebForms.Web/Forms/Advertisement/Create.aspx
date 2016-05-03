<%@ Page Language="C#" MasterPageFile="../Shared/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="PhysicsAdvertisements.WebForms.Web.Forms.Advertisement.Create" %>

<%@ Register Src="~/UserControls/AdvertisementsSearch/ControlTemplates/AdvertisementsSearch.ascx" TagPrefix="uc1" TagName="AdvertisementsSearch" %>
<%@ Register Src="~/UserControls/UserMenu/ControlTemplates/UserMenu.ascx" TagPrefix="uc1" TagName="UserMenu" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <link href="../../UserControls/AdvertisementsSearch/Layouts/AdvertisementsSearch_UserPanel.css" rel="stylesheet" />
    <link href="../../App_Styles/Advertisement/Create.css" rel="stylesheet" />
    <link href="../../UserControls/UserMenu/Layouts/UserMenu.css" rel="stylesheet" />


    <title>Create advertisement</title>
</asp:Content>


<asp:Content ID="MainContent" ContentPlaceHolderID="mainContent" runat="server">
    <div class="container">
        <br />
        <uc1:AdvertisementsSearch runat="server" ID="AdvertisementsSearch" />
    </div>

    <div class="container create">
        <br />
        <div class="col-xs-12 col-sm-8 col-md-8 col-lg-8">
            <h3>Create advertisement</h3>
            <hr />
            <uc1:UserMenu runat="server" ID="UserMenu" />

            <div class="row">
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <label>Title</label>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <asp:TextBox ID="TitleControl" runat="server" CssClass="form-control" placeholder="Title"></asp:TextBox>
                </div>
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3" >
                    <validatable:dataannotationvalidator ID="TitleValidatorControl" runat="server" ControlToValidate="TitleControl" Display="Dynamic"
                     PropertyToValidate="Title" OnInit="GetTypeName" Text="" CssClass="validation-label"/>
                </div>
            </div>

            <div class="row">
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <label>Physics area</label>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">                   
                    <asp:DropDownList ID="PhysicsAreaControl" runat="server" CssClass="form-control" type="PhysicsArea"></asp:DropDownList>
                </div>
                 <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3" >
                    <validatable:dataannotationvalidator ID="PhysicsAreaValidatorControl" runat="server" ControlToValidate="PhysicsAreaControl" Display="Dynamic"
                     PropertyToValidate="PhysicsArea" OnInit="GetTypeName" Text="" CssClass="validation-label"/>
                </div>
            </div>

             <div class="row">
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <label>Category</label>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <asp:DropDownList ID="CategoryControl" runat="server" CssClass="form-control" ></asp:DropDownList>
                </div>
                 <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3" >
                    <validatable:dataannotationvalidator ID="CategoryValidatorControl" runat="server" ControlToValidate="CategoryControl" Display="Dynamic"
                     PropertyToValidate="Category" OnInit="GetTypeName" Text="" CssClass="validation-label"/>
                </div>
            </div>

            <div class="row">
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    <label>Description</label>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <asp:TextBox ID="ContentControl" runat="server" CssClass="form-control" placeholder="Content" TextMode="MultiLine" style="resize: vertical; height:300px;"></asp:TextBox>
                </div>
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3" >
                    <validatable:dataannotationvalidator ID="ContentValidatorControl" runat="server" ControlToValidate="ContentControl" Display="Dynamic"
                     PropertyToValidate="Content" OnInit="GetTypeName" Text="" CssClass="validation-label"/>
                </div>
            </div>

             <div class="row">
                <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                    
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <asp:Button ID="SubmitControl" runat="server" Text="Add advertisement" CssClass="btn btn-primary submit" OnClick="SubmitControl_Click" CausesValidation="True" />                   
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
            <h3>Sample Header</h3>
            <hr />

            <div style="width: 350px; height: 540px; border: red 1px solid;">
            </div>

            <%-- <img src="../../App_Images/Account/Register%20banner.png" class="img-responsive" alt="Register banner" />--%>
        </div>
    </div>

</asp:Content>
