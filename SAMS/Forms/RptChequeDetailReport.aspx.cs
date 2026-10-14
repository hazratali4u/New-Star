using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Forms_RptChequeDetailReport : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        DocumentPrintController controller = new DocumentPrintController();
        SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpChequeDetailReport report = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpChequeDetailReport();
        DataSet dataSet = controller.SelectCustomerCreditReport(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), int.Parse(this.DrpRoute.SelectedValue.ToString()), int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.drpChannelType.SelectedValue.ToString()), int.Parse(this.DrpStatus.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text), DateTime.Parse(this.txtEndDate.Text), int.Parse(this.Session["UserId"].ToString()), this.RbReportFilter.SelectedIndex);
        report.SetDataSource(dataSet);
        report.Refresh();
        report.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
        report.SetParameterValue("from_date", this.txtStartDate.Text);
        report.SetParameterValue("To_date", this.txtEndDate.Text);
        this.Session.Add("CrpReport", report);
        this.Session.Add("ReportType", 0);
        string str = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type type = base.GetType();
        this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        DocumentPrintController controller = new DocumentPrintController();
        SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpChequeDetailReport2 report = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpChequeDetailReport2();
        DataSet dataSet = controller.SelectCustomerCreditReport(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), int.Parse(this.DrpRoute.SelectedValue.ToString()), int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.drpChannelType.SelectedValue.ToString()), int.Parse(this.DrpStatus.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text), DateTime.Parse(this.txtEndDate.Text), int.Parse(this.Session["UserId"].ToString()), this.RbReportFilter.SelectedIndex);
        report.SetDataSource(dataSet);
        report.Refresh();
        report.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
        report.SetParameterValue("from_date", this.txtStartDate.Text);
        report.SetParameterValue("To_date", this.txtEndDate.Text);
        this.Session.Add("CrpReport", report);
        this.Session.Add("ReportType", 0);
        string str = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type type = base.GetType();
        this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
    }

    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadArea();
        this.LoadData();
    }

    protected void DrpRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadData();
    }

    private void LoadArea()
    {
        if (this.drpDistributor.Items.Count > 0)
        {
            this.DrpRoute.Items.Clear();
            DataTable table = new DistributorAreaController().SelectDist_Area(-9223372036854775808L, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.drpDistributor.SelectedValue.ToString()), -2147483648, null, null);
            int num = -2147483648;
            this.DrpRoute.Items.Add(new ListItem("All", num.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpRoute, table, 0, 6);
        }
        else
        {
            this.DrpRoute.Items.Clear();
        }
    }

    private void LoadChannelType()
    {
        DataTable table = new SLASHCodesController().SelectSlashCodes(-2147483648, null, 0x2e, null, -2147483648, bool.Parse("True"));
        int num = -2147483648;
        this.drpChannelType.Items.Add(new ListItem("All", num.ToString()));
        clsWebFormUtil.FillDropDownList(this.drpChannelType, table, 0, 2);
    }

    private void LoadData()
    {
        if ((this.drpDistributor.Items.Count > 0) && (this.DrpRoute.Items.Count > 0))
        {
            this.DrpCustomer.Items.Clear();
            DataTable table = new CustomerDataController().SelectAllCustomer(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpRoute.SelectedValue.ToString()), -2147483648);
            int num = -2147483648;
            this.DrpCustomer.Items.Add(new ListItem("All", num.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpCustomer, table, 0, 3, false);
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
        int num = -2147483648;
        this.DrpPrincipal.Items.Add(new ListItem("All", num.ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, table, 0, 1);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            int num = -2147483648;
            this.DrpStatus.Items.Add(new ListItem("All", num.ToString()));
            int num2 = 0x20f;
            this.DrpStatus.Items.Add(new ListItem("Cheque Received", num2.ToString()));
            int num3 = 0x210;
            this.DrpStatus.Items.Add(new ListItem("Cheque Depsoit", num3.ToString()));
            int num4 = 0x211;
            this.DrpStatus.Items.Add(new ListItem("Cheque Realize", num4.ToString()));
            int num5 = 530;
            this.DrpStatus.Items.Add(new ListItem("Cheque Bounce", num5.ToString()));
            int num6 = 0x214;
            this.DrpStatus.Items.Add(new ListItem("Cheque Hold", num6.ToString()));
            int num7 = -2147483648;
            this.DrpCustomer.Items.Add(new ListItem("All", num7.ToString()));
            this.LoadPrincipal();
            this.LoadDistributor();
            this.LoadArea();
            this.LoadChannelType();
            this.LoadData();
            Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            this.txtStartDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            this.txtEndDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }
}