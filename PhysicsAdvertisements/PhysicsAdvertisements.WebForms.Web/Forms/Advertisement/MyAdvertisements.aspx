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
        <uc1:AdvertisementsSearch runat="server" ID="AdvertisementsSearchControl" />
    </div>

    <div class="container user-data">
        <br />
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <h3>My advertisements</h3>
            <hr />
            <uc1:UserMenu runat="server" ID="UserMenu" />

            <style>
                .user-img {
                    height: 100px;
                    width: 100px;
                }

                .personal-data, .contact-data{
                    list-style-type: none;
                    padding: 0px;
                }

             
            </style>

            <asp:GridView ID="MyAdvertisementsGridViewControl" 
                AutoGenerateColumns="false" runat="server" CssClass="table table-responsive" OnRowDeleting="MyAdvertisementsGridViewControl_RowDeleting">

                <Columns>
                    <asp:BoundField DataField="AddedDate" HeaderText="Added date" ItemStyle-Width="100"/>

                    <asp:TemplateField HeaderText="Exhibitor's image" ItemStyle-Width="120">
                        <ItemTemplate>
                            <asp:Image ID="UserImage" runat="server" ImageUrl='<%# Bind("UserImageUrl") %>' style="height:100px; width:100px;" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Exhibitor's personal data">
                        <ItemTemplate>
                            <asp:BulletedList ID="BulletedList1" runat="server" DataSource='<%# Bind("FullNameAndAge") %>' CssClass="personal-data"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    <%--Advertisement data--%>
                    <asp:BoundField DataField="AdvertisementId" Visible="false" />

                    <asp:BoundField DataField="AdvertisementPhysicsArea" HeaderText="Physics area" />
                    <asp:BoundField DataField="AdvertisementCategory" HeaderText="Category" />
                    <asp:BoundField DataField="AdvertisementTitle" HeaderText="Title" />
                    <asp:BoundField DataField="AdvertisementContent" HeaderText="Content" />
                    

                    <asp:TemplateField HeaderText="Exhibitor's contact data" >
                        <ItemTemplate>
                            <asp:BulletedList ID="BulletedList1s" runat="server" DataSource='<%# Bind("ContactData") %>' CssClass="contact-data"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <asp:CommandField ButtonType="Button" ShowDeleteButton="true"/>
                   
                </Columns>
            </asp:GridView>

        </div>


    </div>

</asp:Content>
