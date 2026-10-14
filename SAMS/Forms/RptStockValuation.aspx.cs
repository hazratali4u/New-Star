using System;
using System.Data;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;

public partial class Forms_RptStockValuation : System.Web.UI.Page
{
    protected void btnViewExcel_Click(object sender, EventArgs e)
    {
        this.ShowReport(1);
    }

    protected void btnViewPDF_Click(object sender, EventArgs e)
    {
        this.ShowReport(0);
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
            this.txtEndDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }

    private void ShowReport(int p_Report_Type)
    {
        DocumentPrintController controller = new DocumentPrintController();
        DataTable table = controller.SelectReportTitle(int.Parse(this.drpDistributor.SelectedValue.ToString()));
        DataSet dataSet = controller.SelectStockValuation(DateTime.Parse(this.txtEndDate.Text), int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), int.Parse(this.Session["UserId"].ToString()), this.rblReportType.SelectedIndex);
        if (this.rblReportType.SelectedValue == "0")
        {
            if (this.drpDistributor.SelectedItem.Text == "All")
            {
                SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpStockValuationDetailAllLocations locations = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpStockValuationDetailAllLocations();
                locations.SetDataSource(dataSet);
                locations.Refresh();
                locations.SetParameterValue("division", this.drpDistributor.SelectedItem.Text);
                locations.SetParameterValue("todate", this.txtEndDate.Text);
                locations.SetParameterValue("CompanyName", table.Rows[0]["COMPANY_NAME"].ToString());
                locations.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
                this.Session.Add("CrpReport", locations);
                this.Session.Add("ReportType", p_Report_Type);
                string str = "'Default.aspx'";
                string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type type = base.GetType();
                this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
            }
            else
            {
                SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpStockValuationDetailSingleLocations locations2 = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpStockValuationDetailSingleLocations();
                locations2.SetDataSource(dataSet);
                locations2.Refresh();
                locations2.SetParameterValue("division", this.drpDistributor.SelectedItem.Text);
                locations2.SetParameterValue("todate", this.txtEndDate.Text);
                locations2.SetParameterValue("CompanyName", table.Rows[0]["COMPANY_NAME"].ToString());
                locations2.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
                this.Session.Add("CrpReport", locations2);
                this.Session.Add("ReportType", p_Report_Type);
                string str3 = "'Default.aspx'";
                string str4 = "<script language='JavaScript' type='text/javascript'> window.open(" + str3 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type type2 = base.GetType();
                this.Page.ClientScript.RegisterStartupScript(type2, "OpenWindow", str4);
            }
        }
        else
        {
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpStockValuationSummary summary = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpStockValuationSummary();
            summary.SetDataSource(dataSet);
            summary.Refresh();
            summary.SetParameterValue("division", this.drpDistributor.SelectedItem.Text);
            summary.SetParameterValue("todate", this.txtEndDate.Text);
            summary.SetParameterValue("CompanyName", table.Rows[0]["COMPANY_NAME"].ToString());
            this.Session.Add("CrpReport", summary);
            this.Session.Add("ReportType", p_Report_Type);
            string str5 = "'Default.aspx'";
            string str6 = "<script language='JavaScript' type='text/javascript'> window.open(" + str5 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type type3 = base.GetType();
            this.Page.ClientScript.RegisterStartupScript(type3, "OpenWindow", str6);
        }
    }
}