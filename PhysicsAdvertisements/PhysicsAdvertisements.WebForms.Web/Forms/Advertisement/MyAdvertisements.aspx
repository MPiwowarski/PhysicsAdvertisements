<%@ Page Language="C#" MasterPageFile="../Shared/Site.Master" AutoEventWireup="true" CodeBehind="MyAdvertisements.aspx.cs" Inherits="PhysicsAdvertisements.WebForms.Web.Forms.Advertisement.MyAdvertisements" %>

<%@ Register Src="~/UserControls/AdvertisementsSearch/ControlTemplates/AdvertisementsSearch.ascx" TagPrefix="uc1" TagName="AdvertisementsSearch" %>
<%@ Register Src="~/UserControls/UserMenu/ControlTemplates/UserMenu.ascx" TagPrefix="uc1" TagName="UserMenu" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <link href="../../UserControls/AdvertisementsSearch/Layouts/AdvertisementsSearch_UserPanel.css" rel="stylesheet" />
    <link href="../../UserControls/UserMenu/Layouts/UserMenu.css" rel="stylesheet" />
    <title>My advertisements</title>
</asp:Content>


<asp:Content ID="MainContent" ContentPlaceHolderID="mainContent" runat="server">
    <div class="container">
        <br />
        <uc1:AdvertisementsSearch runat="server" ID="AdvertisementsSearch" />
    </div>

    <div class="container user-data">
        <br />
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <h3>Create advertisement</h3>
            <hr />
            <uc1:UserMenu runat="server" ID="UserMenu" />


        </div>

      
    </div>

</asp:Content>