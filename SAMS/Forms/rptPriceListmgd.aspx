<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="rptPriceListmgd.aspx.cs" Inherits="Forms_rptPriceListmgd" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="cphPage">
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table style="width: 273px; height: 68px" id="TABLE1" onclick="return TABLE1_onclick()">
                                <tbody>
                                    <tr>
                                        <td style="height: 15px" align="left" colspan="4">
                                            <strong>
                                                <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></strong>
                                        </td>
                                        <td style="width: 1px; height: 15px" align="left" colspan="1">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1px; height: 1px" align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1px" align="left">
                                        </td>
                                        <td style="width: 29px" align="left">
                                            <strong>
                                                <asp:Label ID="lblfromLocation" runat="server" CssClass="lblbox" Text="Location"
                                                    Width="60px"></asp:Label></strong>
                                        </td>
                                        <td style="width: 1px" align="left">
                                        </td>
                                        <td style="width: 203px; height: 25px" align="left">
                                            <asp:DropDownList ID="DrpDistributor" runat="server" AutoPostBack="True" CssClass="DropList"
                                                Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 1px; height: 25px">
                                        </td>
                                        <td align="left" style="width: 29px; height: 25px">
                                            <strong>
                                                <asp:Label ID="lbltoLocation" runat="server" Width="61px" Text="Principal" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="width: 1px; height: 25px">
                                        </td>
                                        <td align="left" style="width: 203px; height: 25px">
                                            <asp:DropDownList ID="drpPrincipal" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="drpPrincipal_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left" style="width: 1px; height: 25px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                        <td style="width: 29px; height: 25px" align="left">
                                            <strong>
                                                <asp:Label ID="Label1" runat="server" Width="59px" Text="Catagory" CssClass="lblbox"></asp:Label></strong><br />
                                        </td>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                        <td style="width: 203px; height: 25px" align="left">
                                            <asp:DropDownList ID="DrpCatagory" runat="server" Width="200px" CssClass="DropList">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            &nbsp;
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:Button ID="Button2" runat="server" Text="View PDF" CssClass="btn" OnClick="Button2_Click" />
                    <asp:Button ID="Button1" runat="server" Text="View Excel" CssClass="btn" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
