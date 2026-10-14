using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;

public partial class Forms_RptStockReconcilationn : System.Web.UI.Page
{
    protected void btnViewExcel_Click(object sender, EventArgs e)
    {
        DocumentPrintController controller = new DocumentPrintController();
        RptInventoryController controller2 = new RptInventoryController();
        SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsStockReConsilation consilation = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsStockReConsilation();
        DataTable table = controller.SelectReportTitle(int.Parse(this.drpDistributor.SelectedValue.ToString()));
        DataSet dataSet = controller2.SelectPrincipalStockReconcilation(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text), DateTime.Parse(this.txtEndDate.Text), int.Parse(this.Session["UserId"].ToString()), this.ddlType.SelectedIndex, Convert.ToInt32(this.rblRate.SelectedValue));
        consilation.SetDataSource(dataSet);
        consilation.Refresh();
        consilation.SetParameterValue("division", this.drpDistributor.SelectedItem.Text);
        consilation.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
        consilation.SetParameterValue("fromdate", this.txtStartDate.Text);
        consilation.SetParameterValue("todate", this.txtEndDate.Text);
        consilation.SetParameterValue("CompanyName", table.Rows[0]["COMPANY_NAME"].ToString());
        consilation.SetParameterValue("Price", this.rblRate.SelectedItem.Text);
        consilation.SetParameterValue("ReportType", "Stock Reconciliation Report ( " + this.ddlType.SelectedItem.Text + " )");
        string fileName = Configuration.GetAppInstallationPath() + @"\ExportedFile.xls";
        consilation.SetDatabaseLogon("sa", "Laislabonitamac2065");
        consilation.ExportToDisk(ExportFormatType.Excel, fileName);
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
        RptInventoryController controller2 = new RptInventoryController();
        SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsStockReConsilation consilation = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsStockReConsilation();
        DataTable table = controller.SelectReportTitle(int.Parse(this.drpDistributor.SelectedValue.ToString()));
        DataSet dataSet = controller2.SelectPrincipalStockReconcilation(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text), DateTime.Parse(this.txtEndDate.Text), int.Parse(this.Session["UserId"].ToString()), this.ddlType.SelectedIndex, Convert.ToInt32(this.rblRate.SelectedValue));
        consilation.SetDataSource(dataSet);
        consilation.Refresh();
        consilation.SetParameterValue("division", this.drpDistributor.SelectedItem.Text);
        consilation.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
        consilation.SetParameterValue("fromdate", this.txtStartDate.Text);
        consilation.SetParameterValue("todate", this.txtEndDate.Text);
        consilation.SetParameterValue("CompanyName", table.Rows[0]["COMPANY_NAME"].ToString());
        consilation.SetParameterValue("Price", this.rblRate.SelectedItem.Text);
        consilation.SetParameterValue("ReportType", "Stock Reconciliation Report ( " + this.ddlType.SelectedItem.Text + " )");
        this.Session.Add("CrpReport", consilation);
        this.Session.Add("ReportType", 0);
        string str = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type type = base.GetType();
        this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
    }

    private void LoadDistributor()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        int num = -2147483648;
        this.drpDistributor.Items.Add(new ListItem("All", num.ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, table, 0, 2);
    }

    private void LoadPrincipal()
    {
        DataTable table = new SKUPriceDetailController().SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        int num = -2147483648;
        this.DrpPrincipal.Items.Add(new ListItem("All", num.ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, table, 0, 1);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadPrincipal();
            Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            this.txtStartDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            this.txtEndDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }
}