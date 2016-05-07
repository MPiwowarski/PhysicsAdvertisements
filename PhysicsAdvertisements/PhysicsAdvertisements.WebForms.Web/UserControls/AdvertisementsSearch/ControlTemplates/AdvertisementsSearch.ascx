<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdvertisementsSearch.ascx.cs" Inherits="PhysicsAdvertisements.WebForms.Web.UserControls.AdvertisementsSearch.ControlTemplates.AdvertisementsSearch" %>

<div class="row advertisements-search">
    <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
        <ul>
            <li>Physics areas: </li>
            <li>
                <asp:DropDownList ID="PhysicsAreaControl" runat="server" CssClass="combo-box"></asp:DropDownList>
            </li>
        </ul>
    </div>
    <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
        <ul>
            <li>Category: </li>
            <li>
                <asp:DropDownList ID="CategoryControl" runat="server" CssClass="combo-box"></asp:DropDownList>
            </li>
        </ul>
    </div>
    <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
        <ul>

            <li>
                <asp:Button ID="SearchBtnControl" runat="server" Text="Search" OnClick="SearchBtnControl_Click" CssClass="btn btn-success SearchBtn" />
            </li>
        </ul>
    </div>
</div>

<%--<div class="advertisements-search">
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
                   
                    <li>
                        <asp:Button ID="SearchBtn" runat="server" Text="Search" OnClick="SearchBtn_Click" CssClass="btn btn-default SearchBtn" />
                    </li>
                </ul>
            </td>
        </tr>
    </table>

</div>--%>
