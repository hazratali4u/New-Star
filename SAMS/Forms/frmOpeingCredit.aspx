<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmOpeingCredit.aspx.cs" Inherits="Forms_frmOpeingCredit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <script language="JavaScript" type="text/javascript">

        function ValidateForm() {
            var str;
            str = document.getElementById("<%= txtOutletCode.ClientID %>").value;
            if (str == null || str.length == 0) {
                alert('Must enter Outlet Code');
                return false;
            }
            str = document.getElementById("<%= txtOutletName.ClientID %>").value;
            if (str == null || str.length == 0) {
                alert('Must enter Outlet Code');
                return false;
            }
            str = document.getElementById("<%= txtAmount.ClientID %>").value;
            if (str == null || str.length == 0) {
                alert('Must Enter Amount');
                return false;
            }
            str = document.getElementById("<%= txtFromdate.ClientID %>").value;
            if (str == null || str.length <= 1) {
                alert('Must Enter Invoice Date');
                return false;
            }
        }
        function SearchList() {
            var l = document.getElementById('<%= ListCustomer.ClientID %>');
            var tb = document.getElementById('<%= txtOutletCode.ClientID %>');

            if (tb.value == "") {
                ClearSelection(l);
            }
            else {
                for (var i = 0; i < l.options.length; i++) {
                    if (l.options[i].value.toLowerCase().match(tb.value.toLowerCase())) {
                        l.options[i].selected = true;
                        return false;
                    }
                    else {
                        ClearSelection(l);
                    }
                }
            }
        }

        function SearchedCode() {
            var code;
            var str = document.getElementById("<%= ListCustomer.ClientID %>").value;
            var stroption = document.getElementById("<%= txtOutletCode.ClientID %>").value;
            if (str.length > 0) {
                code = str.substring(str.indexOf('| ') + 2);
                code = code.substring(0, code.indexOf('|') - 1);
                document.getElementById("<%= txtOutletCode.ClientID %>").value = 'OT' + code;
                document.getElementById("<%= txtOutletName.ClientID %>").value = str.substring(0, str.indexOf('|'));

            }
            ClearSelection(document.getElementById('<%= ListCustomer.ClientID %>'));

        }
        function SelectCode(e) {
            if (e.keyCode == 13) {
                var code;
                var str = document.getElementById("<%= ListCustomer.ClientID %>").value;
                code = str.substring(str.indexOf('| ') + 2);
                code = code.substring(0, code.indexOf('|') - 1);
                document.getElementById("<%= txtOutletCode.ClientID %>").value = 'OT' + code;
                document.getElementById("<%= txtOutletName.ClientID %>").value = str.substring(0, str.indexOf('|'));                
            }
        }
        function ClearSelection(lb) {
            lb.selectedIndex = -1;
        }
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        //Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
        prm.add_beginRequest(BeginRequestHandler);
        // Raised after an asynchronous postback is finished and control has been returned to the browser.
        prm.add_endRequest(EndRequestHandler);
        function BeginRequestHandler(sender, args) {
            //Shows the modal popup - the update progress
            var popup = $find('<%= modalPopup.ClientID %>');
            if (popup != null) {
                popup.show();
            }
        }

        function EndRequestHandler(sender, args) {
            //Hide the modal popup - the update progress
            var popup = $find('<%= modalPopup.ClientID %>');
            if (popup != null) {
                popup.hide();
            }
        }
    </script>
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
                        <ContentTemplate>
                            <div>
                                <asp:UpdateProgress ID="UpdateProgress" runat="server">
                                    <ProgressTemplate>
                                        <asp:ImageButton ID="ImageButton10" runat="server" Height="28px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                                            Width="31px" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <ajaxToolkit:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress"
                                    PopupControlID="UpdateProgress" BackgroundCssClass="modalBackground">
                                </ajaxToolkit:ModalPopupExtender>
                            </div>
                            <table>
                                <tbody>
                                    <tr>
                                        <td align="left" colspan="2">
                                            <strong>
                                                <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></strong>
                                        </td>
                                        <td align="left" colspan="1" style="width: 201px">
                                        </td>
                                        <td align="left" colspan="1">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <strong>
                                                <asp:Label ID="Label8" runat="server" CssClass="lblbox" Text="Principal" Width="89px"></asp:Label></strong>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="DrpPrincipal" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="DrpPrincipal_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left" style="width: 201px; height: 17px; text-align: right">
                                            <strong>
                                                <asp:Label ID="Label11" runat="server" CssClass="lblbox" Text="Route" Visible="true"
                                                    Width="66px"></asp:Label>
                                            </strong>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="DrpRoute" runat="server" Width="250px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="DrpRoute_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <strong>
                                                <asp:Label ID="lblfromLocation" runat="server" Width="94px" Text="Distributor" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="drpDistributor" runat="server" Width="200px" CssClass="DropList"
                                                OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left" style="width: 201px">
                                            <strong>
                                                <asp:Label ID="lblDocumentNo" runat="server" Width="32px" Text="" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td align="left" rowspan="10">
                                            <asp:ListBox ID="ListCustomer" onkeyup="SelectCode(event)" runat="server" Width="250px"
                                                Height="210px" CssClass="DropList"></asp:ListBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <strong>
                                                <asp:Label ID="Label2" runat="server" CssClass="lblbox" Text="Sale Force" Width="89px"></asp:Label></strong>
                                        </td>
                                        <td style="height: 13px">
                                            <asp:DropDownList ID="DrpDeliveryMan" runat="server" Width="200px" CssClass="DropList">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left" style="height: 13px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <strong>
                                                <asp:Label ID="Label1" runat="server" CssClass="lblbox" Text="Bill Date" Width="89px"></asp:Label></strong>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFromdate" runat="server" CssClass="txtBox" onkeyup="BlockFromDateKeyPress()"
                                                Style="text-align: justify" Width="180px" MaxLength="1" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:ImageButton ID="ImgBntFromCalc" runat="server" CausesValidation="False" Visible="false"
                                                ImageUrl="~/App_Themes/Granite/Images/date.gif" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="bottom">
                                            <strong>
                                                <asp:Label ID="Label4" runat="server" Width="100px" Text="Customer Code" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td align="left" valign="bottom">
                                            <strong>
                                                <asp:Label ID="Label3" runat="server" Width="120px" Text="Customer Name" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td align="left" valign="bottom">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <asp:TextBox ID="txtOutletCode" onkeyup="SearchList()" runat="server" Width="112px"
                                                CssClass="txtBox "></asp:TextBox>
                                        </td>
                                        <td valign="top">
                                            <asp:TextBox ID="txtOutletName" runat="server" Width="193px" ForeColor="Black" Font-Bold="True"
                                                CssClass="txtBox " Enabled="False"></asp:TextBox>
                                        </td>
                                        <td valign="top">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <strong>
                                                <asp:Label ID="Label6" runat="server" Width="74px" Text="Amount"></asp:Label>
                                            </strong>
                                        </td>
                                        <td style="width: 201px" valign="top" align="left">
                                            
                                        </td>
                                        <td align="left" valign="top">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <asp:TextBox ID="txtAmount" runat="server" Width="118px" ></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FTB_TXTCHQNO" runat="server" ValidChars=".0123456789"
                                                TargetControlID="txtAmount">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                        <td valign="top" align="left">
                                            
                                        </td>
                                        <td align="left" valign="top">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <strong>
                                                <asp:Label ID="Label9" runat="server" CssClass="lblbox" Text="Remarks" Width="73px"></asp:Label></strong>
                                        </td>
                                        <td align="left" valign="top">
                                        </td>
                                        <td align="left" valign="top">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="2" valign="top" style="height: 22px">
                                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox " Width="239px"></asp:TextBox>
                                        </td>
                                        <td align="left" valign="top" style="height: 22px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="2">
                                        </td>
                                        <td align="left" colspan="1">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 36px" align="left">
                                            <asp:Button AccessKey="S" ID="Button1" OnClick="Button1_Click" runat="server" Width="119px"
                                                Font-Size="8pt" Text="Save" CssClass="btn" />
                                        </td>
                                        <td style="width: 201px; height: 36px" valign="middle" align="left">
                                            <asp:Button AccessKey="C" ID="Button2" runat="server" Width="120px" Font-Size="8pt"
                                                Text="Cancel" OnClick="Button2_Click" CssClass="btn" />
                                        </td>
                                        <td align="left" style="width: 201px; height: 36px" valign="middle">
                                        </td>
                                        <td align="left" style="width: 201px; height: 36px" valign="middle">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                FilterType="Custom" ValidChars="0123456789." TargetControlID="txtAmount">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy"
                                PopupButtonID="ImgBntFromCalc" TargetControlID="txtFromdate">
                            </ajaxToolkit:CalendarExtender>
                            &nbsp;
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DrpRoute" EventName="SelectedIndexChanged">
                            </asp:AsyncPostBackTrigger>
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="border-right: silver thin inset; border-top: silver thin inset; border-left: silver thin inset;
                    width: 650px; border-bottom: silver thin inset">
                    <tbody>
                        <tr>
                            <td>
                                <asp:Panel ID="Panel12" runat="server" Height="200px" ScrollBars="Vertical" Width="750px">
                                    <asp:GridView ID="GrdOrder" runat="server" AutoGenerateColumns="False" BackColor="White"
                                        BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center"
                                        Width="728px">
                                        <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                            PreviousPageText="Previous" />
                                        <RowStyle ForeColor="Black" />
                                        <Columns>
                                            <asp:BoundField DataField="CUSTOMER_ID" HeaderText="CUSTOMER_ID">
                                                <HeaderStyle CssClass="hiddencol" />
                                                <ItemStyle CssClass="hiddencol" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PRINCIPAL_ID" HeaderText="PRINCIPAL_ID">
                                                <HeaderStyle CssClass="hiddencol" />
                                                <ItemStyle CssClass="hiddencol" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SKU_HIE_NAME" HeaderText="Principal">
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CUSTOMER_NAME" HeaderText="Customer">
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DOCUMENT_DATE" HeaderText="Invoice Date" DataFormatString="{0:dd-MMM-yyyy}">
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="MANUAL_INVOICE_ID" HeaderText="Invoice No">
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CURRENT_CREDIT_AMOUNT" HeaderText="Credit Amount">
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:BoundField>
                                        </Columns>
                                        <FooterStyle BackColor="White" />
                                        <PagerStyle BackColor="Transparent" />
                                        <HeaderStyle CssClass="tblhead" />
                                        <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
