using System;
using System.Data;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;

public partial class Forms_frmRptReconcilation : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        DocumentPrintController controller = new DocumentPrintController();
        SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpReconciplationReport report = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpReconciplationReport();
        DataTable table = controller.SelectReportTitle(int.Parse(this.drpDistributor.SelectedValue.ToString()));
        DataSet dataSet = controller.SelectValueReconcilation(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.Session["UserId"].ToString()));
        report.SetDataSource(dataSet);
        report.Refresh();
        report.SetParameterValue("FromDate", this.txtStartDate.Text);
        report.SetParameterValue("ToDate", this.txtEndDate.Text);
        report.SetParameterValue("CompanyName", table.Rows[0]["COMPANY_NAME"].ToString());
        report.SetParameterValue("DayClosed", DateTime.Parse(this.Session["CurrentWorkDate"].ToString()).AddDays(-1.0));
        this.Session.Add("CrpReport", report);
        this.Session.Add("ReportType", 1);
        string str = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type type = base.GetType();
        this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        DocumentPrintController controller = new DocumentPrintController();
        SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpReconciplationReport report = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpReconciplationReport();
        DataTable table = controller.SelectReportTitle(int.Parse(this.drpDistributor.SelectedValue.ToString()));
        DataSet dataSet = controller.SelectValueReconcilation(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.Session["UserId"].ToString()));
        report.SetDataSource(dataSet);
        report.Refresh();
        report.SetParameterValue("FromDate", this.txtStartDate.Text);
        report.SetParameterValue("ToDate", this.txtEndDate.Text);
        report.SetParameterValue("CompanyName", table.Rows[0]["COMPANY_NAME"].ToString());
        report.SetParameterValue("DayClosed", DateTime.Parse(this.Session["CurrentWorkDate"].ToString()).AddDays(-1.0));
        this.Session.Add("CrpReport", report);
        this.Session.Add("ReportType", 0);
        string str = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type type = base.GetType();
        this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
    }

    private void LoadDistributor()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
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