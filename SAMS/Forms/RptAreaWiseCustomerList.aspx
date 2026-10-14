<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="RptAreaWiseCustomerList.aspx.cs" Inherits="Forms_RptAreaWiseCustomerList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <script language="JavaScript" type="text/javascript">
        function ValidateForm() {

            return true;
        }

    </script>
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td align="left" colspan="4">
                                        <strong>
                                            <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                    </td>
                                    <td align="left">
                                        <strong>
                                            <asp:Label ID="lbltoLocation" runat="server" CssClass="lblbox" Text="Location" Width="61px"></asp:Label></strong>
                                    </td>
                                    <td align="left">
                                    </td>
                                    <td style="height: 25px" align="left">
                                        <asp:DropDownList ID="drpDistributor" runat="server" Width="200px" CssClass="DropList"
                                            AutoPostBack="True" OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                    </td>
                                    <td align="left">
                                        <strong>
                                            <asp:Label ID="Label2" runat="server" CssClass="lblbox" Text="Town" Width="48px"></asp:Label></strong>
                                    </td>
                                    <td align="left">
                                    </td>
                                    <td align="left" style="height: 25px">
                                        <asp:DropDownList ID="DrpTown" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                    </td>
                                    <td align="left">
                                        <strong>
                                            <asp:Label ID="Label1" runat="server" CssClass="lblbox" Text="Route" Width="52px"></asp:Label></strong>
                                    </td>
                                    <td align="left">
                                    </td>
                                    <td align="left" style="height: 25px">
                                        <asp:DropDownList ID="DrpRoute" runat="server" Width="200px" CssClass="DropList"
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                    </td>
                                    <td align="left">
                                        <strong>
                                            <asp:Label ID="Label6" runat="server" CssClass="lblbox" Text="Channel Type" Width="100px"></asp:Label></strong>
                                    </td>
                                    <td align="left">
                                    </td>
                                    <td align="left" style="height: 25px">
                                        <asp:DropDownList ID="DrpPrincipal" runat="server" Width="200px" CssClass="DropList"
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                    </td>
                                    <td align="left">
                                    </td>
                                    <td align="left">
                                    </td>
                                    <td align="left" style="height: 25px">
                                        <asp:CheckBox ID="CheckBox1" runat="server" Text="Is Registered Customer" Width="174px" />
                                    </td>
                                </tr>
                            </table>
                            &nbsp;
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:Button ID="Button2" runat="server" CssClass="btn" Text="View PDF" OnClick="Button2_Click" />
                    &nbsp;
                    <asp:Button ID="Button1" runat="server" CssClass="btn" Text="View Excel" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
