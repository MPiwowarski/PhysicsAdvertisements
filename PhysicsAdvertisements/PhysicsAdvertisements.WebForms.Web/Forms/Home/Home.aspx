<%@ Page Language="C#" MasterPageFile="../Shared/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PhysicsAdvertisements.WebForms.Web.Forms.Home.Home" %>
<%@ Register Src="~/UserControls/AdvertisementsSearch/ControlTemplates/AdvertisementsSearch.ascx" TagPrefix="uc1" TagName="AdvertisementsSearch" %>




<asp:Content ID="MainContent" ContentPlaceHolderID="mainContent" runat="server">
    
    <p>Home page</p>
    <uc1:AdvertisementsSearch runat="server" id="AdvertisementsSearch" OnSearchBtn_Click_Event="SearchBtn_Click_Event"/>
   

    <asp:TextBox runat="server" id="FeedbackContentControl" Height="90px" TextMode="MultiLine" Width="303px"></asp:TextBox>
    <asp:Button runat="server" id="SendFeedbackControl" Text="Send Feedback" OnClick="SendFeedbackControl_Click" CssClass="btn btn-default"></asp:Button>

</asp:Content>

