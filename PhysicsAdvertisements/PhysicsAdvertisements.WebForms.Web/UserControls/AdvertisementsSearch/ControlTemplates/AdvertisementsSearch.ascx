<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdvertisementsSearch.ascx.cs" Inherits="PhysicsAdvertisements.WebForms.Web.UserControls.AdvertisementsSearch.ControlTemplates.AdvertisementsSearch" %>



<div class="advertisements-search">
    <ul>       
        <li>
            <ul>
                <li>Physics areas</li>
                <li>
                    <asp:DropDownList ID="PhysicsAreaControl" runat="server"></asp:DropDownList>
                </li>
            </ul>
        </li>
        <li>
            <ul>
                <li>Category</li>
                <li>
                    <asp:DropDownList ID="CategoryControl" runat="server"></asp:DropDownList>
                </li>
            </ul>
        </li>
        <li>
            <ul>
                <li></li>
                <li>
                    <asp:Button ID="SearchBtn" runat="server" Text="Button" OnClick="SearchBtn_Click" CssClass="btn btn-default" />
                </li>
            </ul>
        </li>
    </ul>

</div>
