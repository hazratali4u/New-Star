using System;
using System.Data;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;

public partial class Forms_RptMonthlySales : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        DocumentPrintController controller = new DocumentPrintController();
        new DataControl();
        DataSet dataSet = controller.SelectCustomerMonthlySales(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.DrpCategory.SelectedValue.ToString()), int.Parse(this.DrpRoute.SelectedValue.ToString()), int.Parse(this.drpChannelType.SelectedValue.ToString()), this.DrpReportType.SelectedIndex);
        SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCustomerMonthlySales sales = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCustomerMonthlySales();
        sales.SetDataSource(dataSet);
        sales.Refresh();
        sales.SetParameterValue("Distributor_Name", this.drpDistributor.SelectedItem.Text);
        sales.SetParameterValue("FROM_DATE", DateTime.Parse(this.txtStartDate.Text));
        sales.SetParameterValue("TO_DATE", DateTime.Parse(this.txtEndDate.Text));
        sales.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
        sales.SetParameterValue("Area", this.DrpRoute.SelectedItem.Text);
        sales.SetParameterValue("ChannelType", this.drpChannelType.SelectedItem.Text);
        sales.SetParameterValue("ReportType", "Customer Monthly " + this.DrpReportType.SelectedItem.Text + " Report(Value)");
        this.Session.Add("CrpReport", sales);
        this.Session.Add("ReportType", 1);
        string str = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type type = base.GetType();
        this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        DocumentPrintController controller = new DocumentPrintController();
        new DataControl();
        DataSet dataSet = controller.SelectCustomerMonthlySales(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.DrpCategory.SelectedValue.ToString()), int.Parse(this.DrpRoute.SelectedValue.ToString()), int.Parse(this.drpChannelType.SelectedValue.ToString()), this.DrpReportType.SelectedIndex);
        SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCustomerMonthlySales sales = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCustomerMonthlySales();
        sales.SetDataSource(dataSet);
        sales.Refresh();
        sales.SetParameterValue("Distributor_Name", this.drpDistributor.SelectedItem.Text);
        sales.SetParameterValue("FROM_DATE", DateTime.Parse(this.txtStartDate.Text));
        sales.SetParameterValue("TO_DATE", DateTime.Parse(this.txtEndDate.Text));
        sales.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
        sales.SetParameterValue("Area", this.DrpRoute.SelectedItem.Text);
        sales.SetParameterValue("ChannelType", this.drpChannelType.SelectedItem.Text);
        sales.SetParameterValue("ReportType", "Customer Monthly " + this.DrpReportType.SelectedItem.Text + " Report");
        this.Session.Add("CrpReport", sales);
        this.Session.Add("ReportType", 0);
        string str = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type type = base.GetType();
        this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
    }

    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadArea();
    }

    protected void DrpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadCategory();
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

    private void LoadCategory()
    {
        this.DrpCategory.Items.Clear();
        DataTable table = new SkuHierarchyController().SelectDTSkuHierarchy01(2, int.Parse(this.DrpPrincipal.SelectedValue.ToString()), -2147483648, -2147483648, -2147483648, int.Parse(this.Session["CompanyId"].ToString()));
        int num = -2147483648;
        this.DrpCategory.Items.Add(new ListItem("All", num.ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpCategory, table, "Category_Id", "Category_Name");
    }

    private void LoadChannelType()
    {
        DataTable table = new SLASHCodesController().SelectSlashCodes(-2147483648, null, 0x2e, null, -2147483648, bool.Parse("True"));
        int num = -2147483648;
        this.drpChannelType.Items.Add(new ListItem("All", num.ToString()));
        clsWebFormUtil.FillDropDownList(this.drpChannelType, table, 0, 2);
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
        if (!this.Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadPrincipal();
            this.LoadArea();
            this.LoadChannelType();
            this.LoadCategory();
            Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            this.txtStartDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            this.txtEndDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }
}