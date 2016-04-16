<%@ Page Language="C#" MasterPageFile="../Shared/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PhysicsAdvertisements.WebForms.Web.Forms.Home.Home" %>



<asp:Content ID="MainContent" ContentPlaceHolderID="mainContent" runat="server">
    
    <p>Home page</p>

   

    <asp:TextBox runat="server" id="FeedbackContentControl" Height="90px" TextMode="MultiLine" Width="303px"></asp:TextBox>
    <asp:Button runat="server" id="SendFeedbackControl" Text="Send Feedback" OnClick="SendFeedbackControl_Click" ></asp:Button>

</asp:Content>
