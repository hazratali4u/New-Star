<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmAccountHead.aspx.cs" Inherits="Forms_frmAccountHead" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" runat="Server">
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table width="100%">
                                <tbody>
                                    <tr>
                                        <td colspan="2">
                                            <strong>
                                                <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></strong>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td style="width: 11px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 121px">
                                            <strong>
                                                <asp:Label ID="Label1" runat="server" Width="150px" Text="Main Account Type " CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddAccountType" runat="server" Width="250px" CssClass="DropList"
                                                OnSelectedIndexChanged="ddAccountType_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                            <asp:TextBox ID="txtAtypeCode" runat="server" Visible="False" Width="62px" CssClass="txtBox "
                                                MaxLength="2"></asp:TextBox>
                                            <asp:TextBox ID="txtAtypeName" runat="server" CssClass="txtBox " Visible="False"
                                                Width="170px"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                        <td style="height: 25px">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                        <td>
                                            <asp:Button CssClass="btn" ID="btnAccountType" OnClick="btnAccountType_Click" runat="server"
                                                Width="125px" Font-Size="8pt" Text="New Account Type"></asp:Button>
                                        </td>
                                        <td style="width: 11px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 121px; height: 35px">
                                            <strong>
                                                <asp:Label ID="Label2" runat="server" Width="150px" Text="Sub Account Type" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="height: 35px">
                                            <asp:DropDownList ID="ddAccountSubType" runat="server" Width="250px" CssClass="DropList"
                                                OnSelectedIndexChanged="ddAccountSubType_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                            <asp:TextBox ID="txtASubTypeCode" runat="server" Visible="False" Width="62px" CssClass="txtBox "
                                                MaxLength="2"></asp:TextBox>
                                            <asp:TextBox ID="txtSubTypeName" runat="server" CssClass="txtBox " Visible="False"
                                                Width="170px"></asp:TextBox>
                                        </td>
                                        <td style="height: 35px">
                                        </td>
                                        <td style="height: 35px">
                                        </td>
                                        <td style="height: 35px">
                                            <asp:Button CssClass="btn" ID="btnAccountSubType" OnClick="btnAccountSubType_Click"
                                                runat="server" Width="125px" Font-Size="8pt" Text="New Sub Type"></asp:Button>
                                        </td>
                                        <td style="width: 11px; height: 35px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 121px">
                                            <strong>
                                                <asp:Label ID="Label4" runat="server" Width="150px" Text="Detail Account Type" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpAccountTypeDetail" runat="server" Width="250px" CssClass="DropList"
                                                OnSelectedIndexChanged="drpAccountTypeDetail_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                            <asp:TextBox ID="txtADetailTypeCode" runat="server" Visible="False" Width="62px"
                                                CssClass="txtBox " MaxLength="2"></asp:TextBox>
                                            <asp:TextBox ID="txtDetailTypeName" runat="server" CssClass="txtBox " Visible="False"
                                                Width="170px"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                        <td style="height: 25px">
                                        </td>
                                        <td>
                                            <asp:Button CssClass="btn" ID="btnAccountDetailType" runat="server" Width="125px"
                                                Font-Size="8pt" Text="New Detail Type" OnClick="btnAccountDetailType_Click">
                                            </asp:Button>
                                        </td>
                                        <td style="width: 11px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 121px">
                                            <strong>
                                                <asp:Label ID="Label3" runat="server" Width="109px" Text="Account Head" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAccountCode" runat="server" Width="62px" CssClass="txtBox " MaxLength="4"></asp:TextBox>
                                            <asp:TextBox ID="txtAccountHead" runat="server" CssClass="txtBox " Width="170px"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                        <td style="height: 25px">
                                        </td>
                                        <td>
                                        </td>
                                        <td style="width: 11px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 121px">
                                        </td>
                                        <td style="width: 169px; height: 26px">
                                            <asp:CheckBox ID="ChbIsactive" runat="server" Checked="True" Text="Is Active" />
                                        </td>
                                        <td style="height: 26px">
                                        </td>
                                        <td style="height: 26px">
                                        </td>
                                        <td style="height: 26px">
                                        </td>
                                        <td style="width: 11px; height: 26px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 121px">
                                        </td>
                                        <td align="left">
                                            <asp:Button CssClass="btn" ID="btnSave" OnClick="btnSave_Click" runat="server" Width="94px"
                                                Font-Size="8pt" Text="New"></asp:Button>
                                            <asp:Button CssClass="btn" ID="btnCancel" OnClick="btnCancel_Click" runat="server"
                                                Width="94px" Font-Size="8pt" Text="Cancel"></asp:Button>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td style="width: 11px">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    &nbsp;
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridAccountHead" runat="server" Width="100%" ForeColor="SteelBlue"
                    CssClass="gridRow2" OnRowEditing="GridAccountHead_RowEditing" AutoGenerateColumns="False"
                    BackColor="White" HorizontalAlign="Center" BorderColor="White">
                    <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                        PreviousPageText="Previous"></PagerSettings>
                    <RowStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" ForeColor="Black">
                    </RowStyle>
                    <Columns>
                        <asp:BoundField DataField="Account_TypeId" HeaderText="Account_TypeId">
                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                            <ItemStyle CssClass="hiddencol"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="AccountSub_TypeId" HeaderText="AccountSub_TypeId">
                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                            <ItemStyle CssClass="hiddencol"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="AccountDetail_TypeId" HeaderText="AccountDetail_TypeId">
                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                            <ItemStyle CssClass="hiddencol"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="ACCOUNT_HEAD_ID" HeaderText="ACCOUNT_HEAD_ID">
                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                            <ItemStyle CssClass="hiddencol"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Account_Type" HeaderText="Account Type">
                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Account_SubType" HeaderText="Sub Type">
                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="AccountDetail_Type" HeaderText="Account Detail">
                            <HeaderStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></HeaderStyle>
                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Account_Name" HeaderText="Account Name">
                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                        </asp:BoundField>
                        <asp:CommandField ShowEditButton="True" HeaderText="Edit">
                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                        </asp:CommandField>
                    </Columns>
                    <FooterStyle BackColor="White"></FooterStyle>
                    <PagerStyle BackColor="Transparent"></PagerStyle>
                    <HeaderStyle CssClass="tblhead" ForeColor="White"></HeaderStyle>
                    <AlternatingRowStyle CssClass="GridAlternateRowStyle"></AlternatingRowStyle>
                </asp:GridView>
                <div style="z-index: 101; left: 429px; width: 100px; position: absolute; top: 431px;
                    height: 100px">
                    <asp:Panel ID="Panel1" runat="server">
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                            <ProgressTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" Height="30px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                                    Width="32px" />
                                Wait Updated
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </asp:Panel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
