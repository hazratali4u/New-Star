using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_RptCustomerSaleReport : System.Web.UI.Page
{
    protected void btnViewExcel_Click(object sender, EventArgs e)
    {
        DocumentPrintController controller = new DocumentPrintController();
        DataSet dataSet = null;
        DataTable table = controller.SelectReportTitle(int.Parse(this.drpDistributor.SelectedValue.ToString()));
        new DataControl();
        dataSet = controller.SelectCustomerSaleReport(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.Session["UserId"].ToString()), -2147483648, int.Parse(this.drpChannelType.SelectedValue.ToString()), false, int.Parse(this.DrpSaleForce.SelectedValue.ToString()));
        SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCustomerSaleReport report = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCustomerSaleReport();
        report.SetDataSource(dataSet);
        report.Refresh();
        report.SetParameterValue("Distributor_Name", this.drpDistributor.SelectedItem.Text);
        report.SetParameterValue("FROM_DATE", DateTime.Parse(this.txtStartDate.Text));
        report.SetParameterValue("TO_DATE", DateTime.Parse(this.txtEndDate.Text));
        report.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
        report.SetParameterValue("ChannelType", this.drpChannelType.SelectedItem.Text);
        report.SetParameterValue("CompanyName", table.Rows[0]["COMPANY_NAME"].ToString());
        report.SetParameterValue("OrderBooker", this.DrpSaleForce.SelectedItem.Text);
        string fileName = Configuration.GetAppInstallationPath() + @"\Exported.xls";
        report.SetDatabaseLogon("sa", "Laislabonitamac2065");
        report.ExportToDisk(ExportFormatType.Excel, fileName);
        FileInfo info = new FileInfo(fileName);
        if (info.Exists)
        {
            base.Response.Clear();
            base.Response.AddHeader("Content-Disposition", "attachment; filename=" + info.Name);
            base.Response.AddHeader("Content-Length", info.Length.ToString());
            base.Response.ContentType = "application/octet-stream";
            base.Response.WriteFile(info.FullName);
            base.Response.End();
        }
        else
        {
            base.Response.Write("This file does not exist.");
        }
    }

    protected void btnViewPDF_Click(object sender, EventArgs e)
    {
        DocumentPrintController controller = new DocumentPrintController();
        DataSet dataSet = null;
        DataTable table = controller.SelectReportTitle(int.Parse(this.drpDistributor.SelectedValue.ToString()));
        new DataControl();
        dataSet = controller.SelectCustomerSaleReport(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.Session["UserId"].ToString()), -2147483648, int.Parse(this.drpChannelType.SelectedValue.ToString()), false, int.Parse(this.DrpSaleForce.SelectedValue.ToString()));
        SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCustomerSaleReport report = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCustomerSaleReport();
        report.SetDataSource(dataSet);
        report.Refresh();
        report.SetParameterValue("Distributor_Name", this.drpDistributor.SelectedItem.Text);
        report.SetParameterValue("FROM_DATE", DateTime.Parse(this.txtStartDate.Text));
        report.SetParameterValue("TO_DATE", DateTime.Parse(this.txtEndDate.Text));
        report.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
        report.SetParameterValue("ChannelType", this.drpChannelType.SelectedItem.Text);
        report.SetParameterValue("CompanyName", table.Rows[0]["COMPANY_NAME"].ToString());
        report.SetParameterValue("OrderBooker", this.DrpSaleForce.SelectedItem.Text);
        this.Session.Add("CrpReport", report);
        this.Session.Add("ReportType", 0);
        string str = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type type = base.GetType();
        this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
    }

    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadDeliveryman();
    }

    private void LoadArea()
    {
    }

    private void LoadChannelType()
    {
        DataTable table = new SLASHCodesController().SelectSlashCodes(-2147483648, null, 0x2e, null, -2147483648, bool.Parse("True"));
        int num = -2147483648;
        this.drpChannelType.Items.Add(new ListItem("All", num.ToString()));
        clsWebFormUtil.FillDropDownList(this.drpChannelType, table, 0, 2);
    }

    private void LoadDeliveryman()
    {
        if (this.drpDistributor.Items.Count > 0)
        {
            this.DrpSaleForce.Items.Clear();
            DataTable table = new Distributor_UserController().SelectSaleForceAssignedArea(0x23, int.Parse(this.drpDistributor.SelectedValue.ToString()), -2147483648, int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpSaleForce, table, 0, 3);
        }
        else
        {
            this.DrpSaleForce.Items.Clear();
        }
    }

    private void LoadDistributor()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, table, 0, 2);
    }

    private void LoadPrincipal()
    {
        DataTable table = new SKUPriceDetailController().SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, table, 0, 1);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadPrincipal();
            this.LoadChannelType();
            this.LoadDeliveryman();
            Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            this.txtStartDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            this.txtEndDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }
}