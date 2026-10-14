using CrystalDecisions.CrystalReports.Engine;
using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Forms_frmDocumentPrinting : System.Web.UI.Page
{
    protected void btnViewExcel_Click(object sender, EventArgs e)
    {
        DocumentPrintController controller = new DocumentPrintController();
        DataSet dataSet = null;
        DataTable table = controller.SelectReportTitle(int.Parse(this.drpDistributor.SelectedValue.ToString()));
        if (table.Rows.Count > 0)
        {
            if (this.DrpLedgerType.SelectedIndex == 3)
            {
                new DataControl();
                dataSet = controller.SelectDocumentforPrint(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpArea.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), 1, -9223372036854775808L, Convert.ToInt32(this.DrpPrintType.SelectedValue));
                ReportDocument document = new ReportDocument();
                SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpDeliveryChallan challan = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpDeliveryChallan();
                document = challan.OpenSubreport("Subreport1");
                challan.SetDataSource(dataSet);
                document.SetDataSource(dataSet);
                challan.Refresh();
                challan.SetParameterValue("COMPANY_NAME", this.ddlCompany.SelectedItem.Text);
                challan.SetParameterValue("CompanyAddress", "Branch Address: " + table.Rows[0]["ADDRESS1"].ToString());
                this.Session.Add("CrpReport", challan);
                this.Session.Add("ReportType", 1);
                string str = "'Default.aspx'";
                string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type type = base.GetType();
                this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
            }
            else if (this.DrpLedgerType.SelectedIndex == 4)
            {
                new DataControl();
                dataSet = controller.SelectDocumentforPrint(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpArea.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), 1, -9223372036854775808L, Convert.ToInt32(this.DrpPrintType.SelectedValue));
                SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPrintUSDInvoice invoice = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPrintUSDInvoice();
                invoice.SetDataSource(dataSet);
                invoice.Refresh();
                invoice.SetParameterValue("COMPANY_NAME", this.ddlCompany.SelectedItem.Text);
                invoice.SetParameterValue("CompanyAddress", "Branch Address: " + table.Rows[0]["ADDRESS1"].ToString());
                invoice.SetParameterValue("TAXREGISTERATION_NO", table.Rows[0]["GST_NUMBER"].ToString());
                invoice.SetParameterValue("DISTRIBUTOR_NAME", table.Rows[0]["DISTRIBUTOR_NAME"].ToString());
                this.Session.Add("CrpReport", invoice);
                this.Session.Add("ReportType", 1);
                string str3 = "'Default.aspx'";
                string str4 = "<script language='JavaScript' type='text/javascript'> window.open(" + str3 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type type2 = base.GetType();
                this.Page.ClientScript.RegisterStartupScript(type2, "OpenWindow", str4);
            }
            else
            {
                new DataControl();
                dataSet = controller.SelectDocumentforPrint(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpArea.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.DrpLedgerType.SelectedValue.ToString()), -9223372036854775808L, Convert.ToInt32(this.DrpPrintType.SelectedValue));
                ReportDocument document2 = new ReportDocument();
                SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPrintDocument document3 = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPrintDocument();
                document2 = document3.OpenSubreport("SUBREPORT1");
                document3.SetDataSource(dataSet);
                document2.SetDataSource(dataSet);
                document3.Refresh();
                document3.SetParameterValue("COMPANY_NAME", this.ddlCompany.SelectedItem.Text);
                document3.SetParameterValue("DISTRIBUTOR_NAME", table.Rows[0]["DISTRIBUTOR_NAME"].ToString());
                document3.SetParameterValue("Address", "Address: " + table.Rows[0]["ADDRESS1"].ToString());
                document3.SetParameterValue("EmailTo", table.Rows[0]["ADDRESS2"].ToString());
                document3.SetParameterValue("CONTACT_NUMBER", table.Rows[0]["CONTACT_NUMBER"].ToString());
                document3.SetParameterValue("NTN", "NTN #:" + table.Rows[0]["NTN_NO"].ToString());
                document3.SetParameterValue("PrintType", this.DrpPrintType.SelectedValue);
                this.Session.Add("CrpReport", document3);
                this.Session.Add("ReportType", 1);
                string str5 = "'Default.aspx'";
                string str6 = "<script language='JavaScript' type='text/javascript'> window.open(" + str5 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type type3 = base.GetType();
                this.Page.ClientScript.RegisterStartupScript(type3, "OpenWindow", str6);
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable table = null;
        DocumentPrintController controller = new DocumentPrintController();
        if (this.DrpLedgerType.SelectedIndex == 3)
        {
            table = controller.SelectDocumentforView(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpArea.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), 1);
        }
        else
        {
            table = controller.SelectDocumentforView(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpArea.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.DrpLedgerType.SelectedValue.ToString()));
        }
        this.GrdOrder.DataSource = table;
        this.GrdOrder.DataBind();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        DocumentPrintController controller = new DocumentPrintController();
        DataSet dataSet = null;
        DataTable table = controller.SelectReportTitle(int.Parse(this.drpDistributor.SelectedValue.ToString()));
        if (table.Rows.Count > 0)
        {
            if (this.DrpLedgerType.SelectedIndex == 3)
            {
                new DataControl();
                dataSet = controller.SelectDocumentforPrint(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpArea.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), 1, -9223372036854775808L, Convert.ToInt32(this.DrpPrintType.SelectedValue));
                ReportDocument document = new ReportDocument();
                SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpDeliveryChallan challan = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpDeliveryChallan();
                document = challan.OpenSubreport("Subreport1");
                challan.SetDataSource(dataSet);
                document.SetDataSource(dataSet);
                challan.Refresh();
                challan.SetParameterValue("COMPANY_NAME", this.ddlCompany.SelectedItem.Text);
                challan.SetParameterValue("CompanyAddress", "Branch Address: " + table.Rows[0]["ADDRESS1"].ToString());
                this.Session.Add("CrpReport", challan);
                this.Session.Add("ReportType", 0);
                string str = "'Default.aspx'";
                string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type type = base.GetType();
                this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
            }
            else if (this.DrpLedgerType.SelectedIndex == 4)
            {
                new DataControl();
                dataSet = controller.SelectDocumentforPrint(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpArea.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), 1, -9223372036854775808L, Convert.ToInt32(this.DrpPrintType.SelectedValue));
                SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPrintUSDInvoice invoice = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPrintUSDInvoice();
                invoice.SetDataSource(dataSet);
                invoice.Refresh();
                invoice.SetParameterValue("COMPANY_NAME", this.ddlCompany.SelectedItem.Text);
                invoice.SetParameterValue("CompanyAddress", "Branch Address: " + table.Rows[0]["ADDRESS1"].ToString());
                invoice.SetParameterValue("TAXREGISTERATION_NO", table.Rows[0]["GST_NUMBER"].ToString());
                invoice.SetParameterValue("DISTRIBUTOR_NAME", table.Rows[0]["DISTRIBUTOR_NAME"].ToString());
                this.Session.Add("CrpReport", invoice);
                this.Session.Add("ReportType", 0);
                string str3 = "'Default.aspx'";
                string str4 = "<script language='JavaScript' type='text/javascript'> window.open(" + str3 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type type2 = base.GetType();
                this.Page.ClientScript.RegisterStartupScript(type2, "OpenWindow", str4);
            }
            else
            {
                new DataControl();
                dataSet = controller.SelectDocumentforPrint(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpArea.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.DrpLedgerType.SelectedValue.ToString()), -9223372036854775808L, Convert.ToInt32(this.DrpPrintType.SelectedValue));
                ReportDocument document2 = new ReportDocument();
                SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPrintDocument document3 = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPrintDocument();
                document2 = document3.OpenSubreport("SUBREPORT1");
                document3.SetDataSource(dataSet);
                document2.SetDataSource(dataSet);
                document3.Refresh();
                document3.SetParameterValue("COMPANY_NAME", this.ddlCompany.SelectedItem.Text);
                document3.SetParameterValue("DISTRIBUTOR_NAME", table.Rows[0]["DISTRIBUTOR_NAME"].ToString());
                document3.SetParameterValue("Address", "Address: " + table.Rows[0]["ADDRESS1"].ToString());
                document3.SetParameterValue("EmailTo", table.Rows[0]["ADDRESS2"].ToString());
                document3.SetParameterValue("CONTACT_NUMBER", table.Rows[0]["CONTACT_NUMBER"].ToString());
                document3.SetParameterValue("NTN", "NTN #:" + table.Rows[0]["NTN_NO"].ToString());
                document3.SetParameterValue("PrintType", this.DrpPrintType.SelectedValue);
                this.Session.Add("CrpReport", document3);
                this.Session.Add("ReportType", 0);
                string str5 = "'Default.aspx'";
                string str6 = "<script language='JavaScript' type='text/javascript'> window.open(" + str5 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type type3 = base.GetType();
                this.Page.ClientScript.RegisterStartupScript(type3, "OpenWindow", str6);
            }
        }
    }

    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadSaleForce();
    }

    protected void DrpLedgerType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadSaleForce();
    }

    protected void DrpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadSaleForce();
    }

    protected void GrdOrder_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DocumentPrintController controller = new DocumentPrintController();
        DataSet dataSet = null;
        DataTable table = controller.SelectReportTitle(int.Parse(this.drpDistributor.SelectedValue.ToString()));
        if (table.Rows.Count > 0)
        {
            if (this.DrpLedgerType.SelectedIndex == 3)
            {
                new DataControl();
                dataSet = controller.SelectDocumentforPrint(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpArea.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), 1, long.Parse(this.GrdOrder.Rows[e.NewEditIndex].Cells[3].Text), Convert.ToInt32(this.DrpPrintType.SelectedValue));
                SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpDeliveryChallan challan = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpDeliveryChallan();
                challan.SetDataSource(dataSet);
                challan.Refresh();
                challan.SetParameterValue("CompanyAddress", "Branch Address: " + table.Rows[0]["ADDRESS1"].ToString());
                this.Session.Add("CrpReport", challan);
                this.Session.Add("ReportType", 0);
                string str = "'Default.aspx'";
                string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type type = base.GetType();
                this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
            }
            else
            {
                new DataControl();
                dataSet = controller.SelectDocumentforPrint(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpArea.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.DrpLedgerType.SelectedValue.ToString()), long.Parse(this.GrdOrder.Rows[e.NewEditIndex].Cells[3].Text), Convert.ToInt32(this.DrpPrintType.SelectedValue));
                ReportDocument document = new ReportDocument();
                SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPrintDocument document2 = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPrintDocument();
                document = document2.OpenSubreport("SUBREPORT1");
                document2.SetDataSource(dataSet);
                document.SetDataSource(dataSet);
                document2.Refresh();
                document2.SetParameterValue("COMPANY_NAME", this.ddlCompany.SelectedItem.Text);
                document2.SetParameterValue("DISTRIBUTOR_NAME", table.Rows[0]["DISTRIBUTOR_NAME"].ToString());
                this.Session.Add("CrpReport", document2);
                this.Session.Add("ReportType", 0);
                string str3 = "'Default.aspx'";
                string str4 = "<script language='JavaScript' type='text/javascript'> window.open(" + str3 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type type2 = base.GetType();
                this.Page.ClientScript.RegisterStartupScript(type2, "OpenWindow", str4);
            }
        }
    }

    private void LoadCompany()
    {
        DataTable table = new CompanyController().SelectCompany(-2147483648, -2147483648);
        clsWebFormUtil.FillDropDownList(this.ddlCompany, table, 0, 1);
    }

    private void LoadDistributor()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, table, 0, 2, true);
    }

    private void LoadPrincipal()
    {
        DataTable table = new SKUPriceDetailController().SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, table, 0, 1, true);
    }

    private void LoadSaleForce()
    {
        this.DrpArea.Items.Clear();
        DataTable table = new Distributor_UserController().SelectRollBackInvoiceSaleForce(int.Parse(this.DrpLedgerType.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()));
        int num = -2147483648;
        this.DrpArea.Items.Add(new ListItem("All", num.ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpArea, table, 0, 1);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadCompany();
            this.LoadDistributor();
            this.LoadPrincipal();
            this.LoadSaleForce();
            this.txtStartDate.Text = Convert.ToDateTime(Session["CurrentWorkDate"]).ToString("dd-MMM-yyyy");
            this.txtEndDate.Text = Convert.ToDateTime(Session["CurrentWorkDate"]).ToString("dd-MMM-yyyy");
        }
    }
}