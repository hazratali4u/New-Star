<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmTownAssignment.aspx.cs" Inherits="Forms_frmTownAssignment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" runat="Server">
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table>
                                <tbody>
                                    <tr>
                                        <td colspan="2" align="left">
                                            <strong>
                                                <asp:Label ID="lblmsg" runat="server" Visible="False" Width="175px" ForeColor="Red"></asp:Label></strong>&nbsp;
                                        </td>
                                        <td style="height: 17px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 25px;" align="left">
                                            <strong>
                                                <asp:Label ID="Label1" runat="server" Width="58px" Text="Locaton" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="drpDistributor" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="height: 10px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 25px;" align="left">
                                            <strong>
                                                <asp:Label ID="Label11" runat="server" Width="56px" Text="Region" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddRegion" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddRegion_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 25px" align="left">
                                            <strong>
                                                <asp:Label ID="Label2" runat="server" Width="43px" Text="Zone" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddZone" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddZone_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 25px" align="left">
                                            <strong>
                                                <asp:Label ID="Label3" runat="server" Width="51px" Text="Territory" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddTerritory" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddTerritory_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td style="width: 100px" rowspan="1">
                                        <strong>
                                            <asp:Label ID="Label4" runat="server" Width="142px" Text="Unassigned Town" CssClass="lblbox"></asp:Label></strong>
                                    </td>
                                    <td style="width: 102px" valign="bottom" align="center">
                                    </td>
                                    <td style="width: 102px" rowspan="1">
                                        <strong>
                                            <asp:Label ID="Label6" runat="server" Text="Assigned Town"></asp:Label></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                        <asp:ListBox ID="lstUnAssignTown" runat="server" Width="150px" Height="200px"></asp:ListBox>
                                    </td>
                                    <td valign="middle" align="center">
                                        <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Width="30px" Font-Size="8pt"
                                            Text=">" CssClass="btn" />
                                        <br />
                                        <br />
                                        <asp:Button ID="Button3" OnClick="Button3_Click" runat="server" Width="30px" Font-Size="8pt"
                                            Text=">>" CssClass="btn" />
                                        <br />
                                        <br />
                                        <asp:Button ID="Button4" OnClick="Button4_Click" runat="server" Width="30px" Font-Size="8pt"
                                            Text="<<" CssClass="btn" />
                                        <br />
                                        <br />
                                        <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" Width="30px" Font-Size="8pt"
                                            Text="<" CssClass="btn" />
                                    </td>
                                    <td style="width: 102px">
                                        <asp:ListBox ID="lstAssignTown" runat="server" Width="150px" Height="200px"></asp:ListBox>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
