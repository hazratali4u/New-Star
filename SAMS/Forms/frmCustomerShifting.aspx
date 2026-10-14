<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmCustomerShifting.aspx.cs" Inherits="Forms_frmCustomerShifting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" runat="Server">
    <script language="javascript" type="text/javascript">

        function CheckBoxListSelect() {
            var chkBoxList = document.getElementById('<%= ChbAreaList.ClientID %>');
            var chkBox = document.getElementById('<%= ChbSelectAll.ClientID %>');
            if (chkBox.checked == true) {
                var chkBoxCount = chkBoxList.getElementsByTagName("input");

                for (var i = 0; i < chkBoxCount.length; i++) {
                    chkBoxCount[i].checked = true;
                }
            }
            else {
                var chkBoxCount = chkBoxList.getElementsByTagName("input");

                for (var i = 0; i < chkBoxCount.length; i++) {
                    chkBoxCount[i].checked = false;
                }
            }

        }
 
    </script>
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table>
                                <tbody>
                                    <tr>
                                        <td align="left" style="height: 25px">
                                            <strong>
                                                <asp:Label ID="Label1" runat="server" Width="82px" Text="From Locaton" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="height: 10px">
                                            <asp:DropDownList ID="drpfromDistributor" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="drpfromDistributor_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 25px">
                                            <strong>
                                                <asp:Label ID="Label11" runat="server" Width="88px" Text="From Route" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="height: 25px">
                                            <asp:DropDownList ID="DrpfromRoute" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="DrpfromRoute_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 25px">
                                            <strong>
                                                <asp:Label ID="Label2" runat="server" CssClass="lblbox" Text="To Location" Width="80px"></asp:Label></strong>
                                        </td>
                                        <td style="height: 25px">
                                            <asp:DropDownList ID="DrptoDistributor" runat="server" Width="200px" CssClass="DropList"
                                                OnSelectedIndexChanged="DrptoDistributor_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 25px">
                                            <strong>
                                                <asp:Label ID="Label3" runat="server" CssClass="lblbox" Text="To Route" Width="62px"></asp:Label></strong>
                                        </td>
                                        <td style="height: 25px">
                                            <asp:DropDownList ID="drptoRoute" runat="server" Width="200px" CssClass="DropList">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td align="left" rowspan="1">
                                        &nbsp;<asp:CheckBox ID="ChbSelectAll" runat="server" Text="Select All" onclick="CheckBoxListSelect()" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" rowspan="3">
                                        <asp:Panel ID="Panel1" runat="server" BackColor="White" BorderColor="Silver" BorderStyle="Groove"
                                            BorderWidth="1px" Height="200px" ScrollBars="Vertical" Width="300px">
                                            <asp:CheckBoxList ID="ChbAreaList" runat="server">
                                            </asp:CheckBoxList>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                            <asp:Button ID="btnSave" runat="server" Font-Size="8pt" OnClick="btnSave_Click" Text="Shift"
                                ValidationGroup="vg" Width="82px" CssClass="btn" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
