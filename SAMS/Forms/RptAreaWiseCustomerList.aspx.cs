using System;
using System.Data;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;

public partial class Forms_RptAreaWiseCustomerList : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        DocumentPrintController controller = new DocumentPrintController();
        DataTable table = controller.SelectReportTitle(int.Parse(this.drpDistributor.SelectedValue.ToString()));
        SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCustomerList list = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCustomerList();
        DataSet dataSet = null;
        dataSet = controller.SelectPrincipalWiseCustomer(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpRoute.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), int.Parse(this.DrpTown.SelectedValue.ToString()), this.CheckBox1.Checked);
        list.SetDataSource(dataSet);
        list.Refresh();
        list.SetParameterValue("CompanyName", table.Rows[0]["COMPANY_NAME"].ToString());
        list.SetParameterValue("DISTRIBUTOR_NAME", this.drpDistributor.SelectedItem.Text);
        this.Session.Add("CrpReport", list);
        this.Session.Add("ReportType", 1);
        string str = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type type = base.GetType();
        this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        DocumentPrintController controller = new DocumentPrintController();
        DataTable table = controller.SelectReportTitle(int.Parse(this.drpDistributor.SelectedValue.ToString()));
        SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCustomerList list = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCustomerList();
        DataSet dataSet = null;
        dataSet = controller.SelectPrincipalWiseCustomer(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpRoute.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), int.Parse(this.DrpTown.SelectedValue.ToString()), this.CheckBox1.Checked);
        list.SetDataSource(dataSet);
        list.Refresh();
        list.SetParameterValue("CompanyName", table.Rows[0]["COMPANY_NAME"].ToString());
        list.SetParameterValue("DISTRIBUTOR_NAME", this.drpDistributor.SelectedItem.Text);
        this.Session.Add("CrpReport", list);
        this.Session.Add("ReportType", 0);
        string str = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type type = base.GetType();
        this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
    }

    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadTown();
        this.LoadArea();
    }

    private void LoadArea()
    {
        if ((this.drpDistributor.Items.Count > 0) && (this.DrpTown.Items.Count > 0))
        {
            this.DrpRoute.Items.Clear();
            DataTable table = new DistributorAreaController().SelectDist_Area(-9223372036854775808L, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpTown.SelectedValue.ToString()), null, null);
            int num = -2147483648;
            this.DrpRoute.Items.Add(new ListItem("All", num.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpRoute, table, 0, 6);
        }
    }

    private void LoadChannelType()
    {
        DataTable table = new SLASHCodesController().SelectSlashCodes(-2147483648, null, 0x2e, null, -2147483648, bool.Parse("True"));
        int num = -2147483648;
        this.DrpPrincipal.Items.Add(new ListItem("All", num.ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, table, 0, 2);
    }

    private void LoadDistributor()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, table, 0, 2, true);
    }

    private void LoadTown()
    {
        if (this.drpDistributor.Items.Count > 0)
        {
            this.DrpTown.Items.Clear();
            DataTable table = new GeoHierarchyController().SelectGeoHierarchy(int.Parse(this.drpDistributor.SelectedValue.ToString()));
            int num = -2147483648;
            this.DrpTown.Items.Add(new ListItem("All", num.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpTown, table, 0, 1);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadTown();
            this.LoadArea();
            this.LoadChannelType();
        }
    }
}