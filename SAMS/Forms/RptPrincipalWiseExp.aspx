<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="RptPrincipalWiseExp.aspx.cs" Inherits="Forms_RptPrincipalWiseExp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="ID" runat="server" ContentPlaceHolderID="cphPage">
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
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
                                        <td align="left">
                                        </td>
                                        <td align="left" style="width: 90px">
                                            <strong>
                                                <asp:Label ID="Label6" runat="server" CssClass="lblbox" Text="Report Type" Width="83px"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="width: 1px">
                                        </td>
                                        <td align="left" style="width: 204px; height: 25px">
                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                                <asp:ListItem Selected="True">Principal Wise Petty Report</asp:ListItem>
                                                <asp:ListItem>Branch Wise Petty Report</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td align="left" style="width: 1px; height: 25px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                        </td>
                                        <td style="width: 90px" align="left">
                                            <strong>
                                                <asp:Label ID="Label2" runat="server" Width="48px" Text="Location" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="width: 1px" align="left">
                                        </td>
                                        <td style="width: 204px; height: 25px" align="left">
                                            <asp:DropDownList ID="DrpLocation" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                        </td>
                                        <td style="width: 90px" align="left">
                                            <strong>
                                                <asp:Label ID="Label4" runat="server" Width="48px" Text="Principal" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="width: 1px" align="left">
                                        </td>
                                        <td style="width: 204px; height: 25px" align="left">
                                            <asp:DropDownList ID="drpPrincipal" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 2px" align="left">
                                        </td>
                                        <td style="width: 90px; height: 2px" align="left">
                                            <strong>
                                                <asp:Label ID="Label5" runat="server" Width="84px" Text="Account Head" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="width: 1px; height: 2px" align="left">
                                        </td>
                                        <td style="width: 204px; height: 2px" align="left">
                                            <asp:CheckBox ID="ChbAllAccountHead" runat="server" Text="All Account Head" AutoPostBack="True"
                                                OnCheckedChanged="ChbAllLocationType_CheckedChanged"></asp:CheckBox>
                                        </td>
                                        <td style="width: 1px; height: 2px" align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 2px" align="left">
                                        </td>
                                        <td style="height: 2px" align="left" colspan="3">
                                            <asp:Panel ID="Panel1" runat="server" Width="295px" Height="150px" ScrollBars="Vertical"
                                                BorderStyle="Groove" BorderWidth="1px">
                                                <asp:CheckBoxList ID="LstAccountHead" runat="server" AutoPostBack="True">
                                                </asp:CheckBoxList>
                                            </asp:Panel>
                                        </td>
                                        <td style="width: 1px; height: 2px" align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                        </td>
                                        <td style="width: 90px" align="left">
                                            <strong>
                                                <asp:Label ID="Label1" runat="server" Width="80px" Height="9px" Text="From Date"
                                                    CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="width: 1px" align="left">
                                        </td>
                                        <td style="width: 204px; height: 25px" align="left">
                                            <asp:TextBox ID="txtFromDate" runat="server" Width="150px" CssClass="txtBox" MaxLength="10"></asp:TextBox>
                                            <asp:ImageButton ID="ImgBntFromDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif">
                                            </asp:ImageButton>
                                        </td>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                        </td>
                                        <td style="width: 90px" align="left">
                                            <strong>
                                                <asp:Label ID="Label3" runat="server" Width="55px" Text="To Date" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="width: 1px" align="left">
                                        </td>
                                        <td style="width: 204px; height: 25px" align="left">
                                            <asp:TextBox ID="txtToDate" runat="server" Width="150px" CssClass="txtBox" MaxLength="10"></asp:TextBox>
                                            <asp:ImageButton ID="ImgBntToDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif">
                                            </asp:ImageButton>
                                        </td>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy"
                                EnableViewState="False" PopupButtonID="ImgBntFromDate" TargetControlID="txtFromDate">
                            </cc1:CalendarExtender>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy"
                                EnableViewState="False" PopupButtonID="ImgBntToDate" TargetControlID="txtToDate">
                            </cc1:CalendarExtender>
                            &nbsp;
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:Button ID="Button2" runat="server" Font-Size="8pt" Text="View PDF" Width="141px"
                        OnClick="Button2_Click" CssClass="button" />
                    <asp:Button ID="Button1" runat="server" Font-Size="8pt" Text="View Excel" Width="141px"
                        OnClick="Button1_Click" CssClass="button" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
