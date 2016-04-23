<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdvertisementsSearch.ascx.cs" Inherits="PhysicsAdvertisements.WebForms.Web.UserControls.AdvertisementsSearch.ControlTemplates.AdvertisementsSearch" %>



<div class="advertisements-search">
    <table>
        <tr>
            <td>
                <ul>
                    <li>Physics areas: </li>
                    <li>
                        <asp:DropDownList ID="PhysicsAreaControl" runat="server" CssClass="combo-box"></asp:DropDownList>
                    </li>
                </ul>
            </td>
            <td>
                <ul>
                    <li>Category: </li>
                    <li>
                        <asp:DropDownList ID="CategoryControl" runat="server" CssClass="combo-box"></asp:DropDownList>
                    </li>
                </ul>
            </td>
            <td>
                <ul>
                    <%--<li></li>--%>
                    <li>
                        <asp:Button ID="SearchBtn" runat="server" Text="Search" OnClick="SearchBtn_Click" CssClass="btn btn-default SearchBtn" />
                    </li>
                </ul>
            </td>
        </tr>
    </table>

</div>
