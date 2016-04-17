<%@ Page Language="C#" MasterPageFile="../Shared/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PhysicsAdvertisements.WebForms.Web.Forms.Home.Home" %>

<%@ Register Src="~/UserControls/AdvertisementsSearch/ControlTemplates/AdvertisementsSearch.ascx" TagPrefix="uc1" TagName="AdvertisementsSearch" %>


<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <link href="../../App_Styles/Home/Home.css" rel="stylesheet" />
    <link href="../../UserControls/AdvertisementsSearch/Layouts/AdvertisementsSearch.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="mainContent" runat="server">

    <h1>Home page</h1>
    <uc1:AdvertisementsSearch runat="server" ID="AdvertisementsSearch" OnSearchBtn_Click_Event="SearchBtn_Click_Event" />

    <div class="feedback-form">
        <ul>
            <li>
                Send us feedback. Write about what you like or don't in our web application.
            </li>
            <li>
                <asp:TextBox runat="server" ID="FeedbackContentControl" Height="90px" TextMode="MultiLine" CssClass="FeedbackContentControl"></asp:TextBox>
            </li>
            <li>
                <asp:Button runat="server" ID="SendFeedbackControl" Text="Send Feedback" OnClick="SendFeedbackControl_Click" CssClass="btn btn-default"></asp:Button>
            </li>
        </ul>
    </div>
</asp:Content>

