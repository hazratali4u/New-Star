<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmChangePassword.aspx.cs" Inherits="Forms_frmChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeadPage" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPage" runat="Server">
    <script language="JavaScript" type="text/javascript">

        function ValidatePassword() {

            var strCurrentPassword;
            var strNewPassword;
            var strChangePassword;

            strCurrentPassword = document.getElementById('<%=txtCurrentPassword.ClientID%>').value;
            if (strCurrentPassword == null || strCurrentPassword.length == 0) {
                alert('Must Enter Current Password ');
                return false;
            }
            strNewPassword = document.getElementById('<%=txtNewPassword.ClientID%>').value;
            if (strNewPassword == null || strNewPassword.length == 0) {
                alert('Must Enter New Password ');
                return false;
            }
            strChangePassword = document.getElementById('<%=txtConfirmNewPassword.ClientID%>').value;
            if (strChangePassword == null || strChangePassword.length == 0) {
                alert('Must Enter Confirm New Password ');
                return false;
            }
            if (strNewPassword == strChangePassword) {
                return true;
            }
            else {
                alert('New Password does not match');
                return false;
            }

            return true;
        }
        function ValidateCurrentPassword() {
            alert('Current Password is wrong ');
            return true;
        } 
    </script>
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table style="height: 117px">
                                <tbody>
                                    <tr>
                                        <td style="height: 12px" align="left" colspan="4">
                                            <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True" Width="312px"></asp:Label>
                                        </td>
                                        <td style="width: 1px; height: 12px" align="left" colspan="1">
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
                                            <asp:Label ID="Label2" runat="server" Width="122px" Text="Current Password" CssClass="lblbox"></asp:Label>
                                        </td>
                                        <td style="width: 1px" align="left">
                                        </td>
                                        <td style="width: 203px; height: 25px" align="left">
                                            <asp:TextBox ID="txtCurrentPassword" runat="server" Width="153px" CssClass="txtBox"
                                                MaxLength="20" TextMode="Password"></asp:TextBox>
                                        </td>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                        <td style="width: 29px; height: 25px" align="left">
                                            <asp:Label ID="lbltoLocation" runat="server" Width="121px" Text="New Password" CssClass="lblbox"></asp:Label>
                                        </td>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                        <td style="width: 203px; height: 25px" align="left">
                                            <asp:TextBox ID="txtNewPassword" runat="server" Width="153px" CssClass="txtBox" MaxLength="20"
                                                TextMode="Password"></asp:TextBox>
                                        </td>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                        <td style="width: 29px; height: 25px" align="left">
                                            <asp:Label ID="Label1" runat="server" Width="143px" Text="Confirm New Password" CssClass="lblbox"></asp:Label>
                                        </td>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                        <td style="width: 203px; height: 25px" align="left">
                                            <asp:TextBox ID="txtConfirmNewPassword" runat="server" Width="153px" CssClass="txtBox"
                                                MaxLength="20" TextMode="Password"></asp:TextBox>
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
                            &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="btnSave" runat="server" Font-Size="8pt"
                                Text="Save" Width="71px" OnClick="btnSave_Click1" />
                            <asp:Button ID="btnCancel" runat="server" Font-Size="8pt" Text="Cancel" Width="71px"
                                OnClick="btnCancel_Click" />
                            &nbsp;
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    &nbsp;
                    <asp:TextBox ID="hiddenPassword" runat="server" Visible="False" Width="97px"></asp:TextBox>
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;<br />
                    &nbsp;&nbsp; &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
