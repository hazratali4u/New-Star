<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="rptBankDepositSlipDetail.aspx.cs" Inherits="Forms_rptBankDepositSlipDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="cphPage">
    <div id="right_data">
        <table width="100%">
            <tr>
                <td style="height: 184px">
                </td>
                <td align="left" style="height: 184px">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table>
                                <tbody>
                                    <tr>
                                        <td align="left" colspan="4">
                                            <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td style="width: 1px" align="left" colspan="1">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1px; height: 1px" align="left">
                                        </td>
                                        <td style="height: 1px" align="left">
                                            <asp:Label ID="Label2" runat="server" Width="48px" Text="Location" CssClass="lblbox"></asp:Label>
                                        </td>
                                        <td style="width: 1px; height: 1px" align="left">
                                        </td>
                                        <td style="height: 1px" align="left">
                                            <asp:DropDownList ID="DrpLocation" runat="server" Width="210px" CssClass="DropList"
                                                AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 1px; height: 1px" align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1px" align="left">
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lbltoLocation" runat="server" CssClass="lblbox" Text="Principal" Width="61px"></asp:Label>
                                        </td>
                                        <td style="width: 1px" align="left">
                                        </td>
                                        <td style="height: 25px" align="left">
                                            <asp:DropDownList ID="drpPrincipal" runat="server" Width="210px" CssClass="DropList"
                                                AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                        <td style="height: 25px" align="left">
                                            <asp:Label ID="Label4" runat="server" Width="61px" Text="Account" CssClass="lblbox"></asp:Label>
                                        </td>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                        <td style="height: 25px" align="left">
                                            <asp:DropDownList ID="drpAccount" runat="server" Width="210px" CssClass="DropList"
                                                AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                        <td style="height: 25px" align="left">
                                            <asp:Label ID="Label1" runat="server" Width="70px" Text="From Date" CssClass="lblbox"></asp:Label>
                                        </td>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                        <td style="height: 25px" align="left">
                                            <asp:TextBox ID="txtFromDate" runat="server" Width="153px" CssClass="txtBox" MaxLength="10"></asp:TextBox>
                                            <asp:ImageButton ID="ImgBntFromCalc" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif">
                                            </asp:ImageButton>
                                        </td>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                        <td style="height: 25px" align="left">
                                            <asp:Label ID="Label3" runat="server" Width="70px" Text="To Date"></asp:Label>
                                        </td>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                        <td style="height: 25px" align="left">
                                            <asp:TextBox ID="txtToDate" runat="server" Width="153px" CssClass="txtBox" MaxLength="10"></asp:TextBox>
                                            <asp:ImageButton ID="ImgToDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif">
                                            </asp:ImageButton>
                                        </td>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" EnableViewState="False"
                                Format="dd-MMM-yyyy" PopupButtonID="ImgBntFromCalc" TargetControlID="txtFromDate">
                            </cc1:CalendarExtender>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" EnableViewState="False"
                                Format="dd-MMM-yyyy" PopupButtonID="ImgToDate" TargetControlID="txtToDate">
                            </cc1:CalendarExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                    <asp:Button ID="Button2" runat="server" Font-Size="8pt" Text="View PDF" Width="80"
                        CssClass="button" OnClick="Button2_Click" />
                    <asp:Button ID="Button1" runat="server" Font-Size="8pt" Text="View Excel" Width="80"
                        CssClass="button" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
