<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmDistributor.aspx.cs" Inherits="Forms_frmDistributor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <script language="JavaScript" type="text/javascript">
        function ValidateForm() {
            var str;
            str = document.getElementById('<%=txtDistributorCode.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Distributor Code');
                return false;
            }
            str = document.getElementById('<%=txtDistributorName.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Distributor Name');
                return false;
            }
            str = document.getElementById('<%=txtPhoneNo.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter phone');
                return false;
            }
            str = document.getElementById('<%=txtcontactperson.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Contact Person Name');
                return false;
            }

            str = document.getElementById('<%=txtAddress2.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Email Address');
                return false;
            }
            str = document.getElementById('<%=txtAddress1.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Address');
                return false;
            }
            str = document.getElementById('<%=txtpassword.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Fax No');
                return false;
            }
            return true;
        }
    </script>
    <div id="right_data">
        <table width="100%">
            <tr>
                <td style="width: 102px">
                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                        <ContentTemplate>
                            <table>
                                <tbody>
                                    <tr>
                                        <td style="height: 25px" align="left" colspan="4">
                                            <strong>
                                                <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></strong>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 25px" align="left">
                                            <strong>
                                                <asp:Label ID="Label3" runat="server" Width="83px" Text="Company" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="height: 25px">
                                            <asp:DropDownList ID="DrpCompanyName" runat="server" Width="209px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddDistributorType_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="height: 25px">
                                            &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                        <td style="height: 25px" align="left">
                                            <strong>
                                                <asp:Label ID="lbldesignationID" runat="server" Width="80px" Text="Location Type"
                                                    CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="height: 25px">
                                            <asp:DropDownList ID="ddDistributorType" runat="server" Width="208px" CssClass="DropList"
                                                OnSelectedIndexChanged="ddDistributorType_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 25px;" align="left">
                                            <strong>
                                                <asp:Label ID="Label1" runat="server" Width="77px" Text="Code" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="width: 200px">
                                            <asp:TextBox ID="txtDistributorCode" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox>
                                        </td>
                                        <td style="height: 25px">
                                        </td>
                                        <td align="left">
                                            <strong>
                                                <asp:Label ID="lblNickName" runat="server" Width="69px" Text="Name" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="height: 25px;">
                                            <asp:TextBox ID="txtDistributorName" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 25px;" align="left">
                                            <strong>
                                                <asp:Label ID="Label4" runat="server" Width="96px" Text="Contact Person" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="width: 200px">
                                            <asp:TextBox ID="txtcontactperson" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox>
                                        </td>
                                        <td style="height: 25px">
                                        </td>
                                        <td align="left">
                                            <strong>
                                                <asp:Label ID="lblPhNo" runat="server" Width="76px" Text="Phone No" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="height: 25px;">
                                            <asp:TextBox ID="txtPhoneNo" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 25px">
                                            <strong>
                                                <asp:Label ID="lblAddress2" runat="server" Width="80px" Text="Address" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td colspan="4" style="height: 25px">
                                            <asp:TextBox ID="txtAddress1" runat="server" Width="540px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 25px" align="left">
                                            <strong>
                                                <asp:Label ID="lblAddress1" runat="server" Width="91px" Text="Email Address" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="width: 200px; height: 26px">
                                            <asp:TextBox ID="txtAddress2" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox>
                                        </td>
                                        <td style="height: 25px">
                                        </td>
                                        <td style="height: 25px" align="left">
                                            <asp:CheckBox ID="CheckBox1" runat="server" Width="97px" Text="Is Registered" AutoPostBack="True"
                                                OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox>
                                        </td>
                                        <td style="height: 25px">
                                            <asp:TextBox ID="txtgstno" runat="server" Width="200px" CssClass="txtBox " Enabled="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 143px; height: 32px" align="left">
                                        </td>
                                        <td style="width: 200px; height: 32px">
                                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="84px" Font-Size="8pt"
                                                Text="Save" ValidationGroup="vg" CssClass="btn" />
                                            <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Width="83px" Font-Size="8pt"
                                                Text="Cancel" CssClass="btn" />
                                        </td>
                                        <td style="width: 1px; height: 32px">
                                        </td>
                                        <td style="height: 32px">
                                            <strong>
                                                <asp:Label ID="Label2" runat="server" Width="69px" Text="Fax No" Visible="False"></asp:Label></strong>
                                        </td>
                                        <td style="width: 237px; height: 32px">
                                            <asp:TextBox ID="txtpassword" runat="server" Width="200px" CssClass="txtBox " Visible="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="border-right: silver thin inset; border-top: silver thin inset; border-left: silver thin inset;
                    border-bottom: silver thin inset; background-color: silver">
                    <tbody>
                        <tr>
                            <td style="height: 21px" align="left">
                                <strong>
                                    <asp:Label ID="Label10" runat="server" Width="153px" Text="Select Searching Type"></asp:Label></strong>
                            </td>
                            <td style="width: 170px; height: 21px" align="left">
                                <asp:DropDownList ID="ddSearchType" runat="server" Width="200px" CssClass="DropList">
                                    <asp:ListItem Value="SKU_code">All Records</asp:ListItem>
                                    <asp:ListItem Value="Distributor_Code">Distributor Code</asp:ListItem>
                                    <asp:ListItem Value="Distributor_Name">Distributor Name</asp:ListItem>
                                    <asp:ListItem Value="Contact_Person">Contact Person</asp:ListItem>
                                    <asp:ListItem Value="CONTACT_NUMBER">Contact No</asp:ListItem>
                                    <asp:ListItem Value="TYPENAME">Distributor Type</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 224px; height: 21px" align="left">
                                <asp:TextBox ID="txtSeach" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox>
                            </td>
                            <td style="height: 21px" align="left" width="250">
                                <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" Width="85px" Font-Size="8pt"
                                    Text="Filter" CssClass="btn" />
                            </td>
                        </tr>
                    </tbody>
                </table>
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" Width="100%">
                    <asp:GridView ID="GridDistributor" runat="server" Width="99%" ForeColor="SteelBlue"
                        CssClass="gridRow2" AutoGenerateColumns="False" BackColor="White" BorderColor="White"
                        OnPageIndexChanging="GridDistributor_PageIndexChanging" OnRowEditing="GridDistributor_RowEditing"
                        HorizontalAlign="Center" OnRowDeleting="GridDistributor_RowDeleting">
                        <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                            PreviousPageText="Previous"></PagerSettings>
                        <RowStyle ForeColor="Black"></RowStyle>
                        <Columns>
                            <asp:BoundField DataField="DISTRIBUTOR_ID" HeaderText="DISTRIBUTOR_ID" Visible="False">
                            </asp:BoundField>
                            <asp:BoundField DataField="IS_REGISTERED" HeaderText="IS_REGISTERED" Visible="False">
                            </asp:BoundField>
                            <asp:BoundField DataField="SUBZONE_ID" HeaderText="SUBZONE_ID" Visible="False"></asp:BoundField>
                            <asp:BoundField DataField="ADDRESS2" HeaderText="ADDRESS2" Visible="False"></asp:BoundField>
                            <asp:BoundField DataField="DISTRIBUTOR_CODE" HeaderText="Code">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DISTRIBUTOR_NAME" HeaderText="Name">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TYPENAME" HeaderText="Type">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ADDRESS1" HeaderText="Address">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONTACT_PERSON" HeaderText="Cantact Person">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONTACT_NUMBER" HeaderText="Contact Number">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="GST_NUMBER" HeaderText="Gst Number">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="COMPANY_ID" HeaderText="COMPANY_ID" Visible="False">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:CommandField ShowEditButton="True" HeaderText="Edit"></asp:CommandField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CommandName="Delete"
                                        OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="White"></FooterStyle>
                        <PagerStyle BackColor="Transparent"></PagerStyle>
                        <HeaderStyle CssClass="tblhead" ForeColor="White"></HeaderStyle>
                        <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333">
                        </AlternatingRowStyle>
                    </asp:GridView>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
