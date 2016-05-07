<%@ Page Language="C#" MasterPageFile="../Shared/Site.Master" AutoEventWireup="true" CodeBehind="SearchResult.aspx.cs" Inherits="PhysicsAdvertisements.WebForms.Web.Forms.Advertisement.SearchResult" %>

<%@ Register Src="~/UserControls/AdvertisementsSearch/ControlTemplates/AdvertisementsSearch.ascx" TagPrefix="uc1" TagName="AdvertisementsSearch" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <link href="../../UserControls/AdvertisementsSearch/Layouts/AdvertisementsSearch_UserPanel.css" rel="stylesheet" />

    <title>Search result</title>
</asp:Content>


<asp:Content ID="MainContent" ContentPlaceHolderID="mainContent" runat="server">
    <div class="container">
        <h2>Search result</h2>
        <div class="container">
            <br />
            <uc1:AdvertisementsSearch runat="server" ID="AdvertisementsSearchControl" />
        </div>
        <hr />

        <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
            <asp:Label ID="StatusControl" runat="server" Text="" CssClass="status-label"></asp:Label>
        </div>
        <br />
        <br />
        <style>
            .user-img {
                height: 100px;
                width: 100px;
            }
            .personal-data, .contact-data {
                list-style-type: none;
                padding: 0px;
            }
        </style>

        <asp:GridView ID="SearchResultGridViewControl"
            AutoGenerateColumns="false" runat="server" CssClass="table table-responsive">

            <Columns>
                <asp:BoundField DataField="AddedDate" HeaderText="Added date" ItemStyle-Width="100" />

                <asp:TemplateField HeaderText="Exhibitor's image" ItemStyle-Width="120">
                    <ItemTemplate>
                        <asp:Image ID="UserImage" runat="server" ImageUrl='<%# Bind("UserImageUrl") %>' Style="height: 100px; width: 100px;" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Exhibitor's personal data">
                    <ItemTemplate>
                        <asp:BulletedList ID="BulletedList1" runat="server" DataSource='<%# Bind("FullNameAndAge") %>' CssClass="personal-data" />
                    </ItemTemplate>
                </asp:TemplateField>

                <%--Advertisement data--%>
                <asp:BoundField DataField="AdvertisementId" Visible="false" />

                <asp:BoundField DataField="AdvertisementPhysicsArea" HeaderText="Physics area" />
                <asp:BoundField DataField="AdvertisementCategory" HeaderText="Category" />
                <asp:BoundField DataField="AdvertisementTitle" HeaderText="Title" />
                <asp:BoundField DataField="AdvertisementContent" HeaderText="Content" />


                <asp:TemplateField HeaderText="Exhibitor's contact data">
                    <ItemTemplate>
                        <asp:BulletedList ID="BulletedList1s" runat="server" DataSource='<%# Bind("ContactData") %>' CssClass="contact-data" />
                    </ItemTemplate>
                </asp:TemplateField>


            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
