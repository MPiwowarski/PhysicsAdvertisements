<%@ Page Language="C#" MasterPageFile="../Shared/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="PhysicsAdvertisements.WebForms.Web.Forms.Advertisement.Create" %>

<%@ Register Src="~/UserControls/AdvertisementsSearch/ControlTemplates/AdvertisementsSearch.ascx" TagPrefix="uc1" TagName="AdvertisementsSearch" %>
<%@ Register Src="~/UserControls/UserMenu/ControlTemplates/UserMenu.ascx" TagPrefix="uc1" TagName="UserMenu" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <link href="../../UserControls/AdvertisementsSearch/Layouts/AdvertisementsSearch_UserPanel.css" rel="stylesheet" />
    <link href="../../UserControls/UserMenu/Layouts/UserMenu.css" rel="stylesheet" />
    <title>Create advertisement</title>
</asp:Content>


<asp:Content ID="MainContent" ContentPlaceHolderID="mainContent" runat="server">
    <div class="container">
        <br />
        <uc1:AdvertisementsSearch runat="server" ID="AdvertisementsSearch" />
    </div>

    <div class="container user-data">
        <br />
        <div class="col-xs-12 col-sm-8 col-md-8 col-lg-8">
            <h3>Create advertisement</h3>
            <hr />
            <uc1:UserMenu runat="server" ID="UserMenu" />




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
