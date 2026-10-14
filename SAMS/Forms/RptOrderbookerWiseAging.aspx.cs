using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Forms_RptOrderbookerWiseAging : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        DocumentPrintController controller = new DocumentPrintController();
        DataControl control = new DataControl();
        SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCreditAgingOrderBookerWise wise = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCreditAgingOrderBookerWise();
        DataTable table = controller.SelectReportTitle(int.Parse(this.drpDistributor.SelectedValue.ToString()));
        DataSet dataSet = controller.SelectOrderBookerCreditAging(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtDocmentDate.Text), int.Parse(this.Session["UserId"].ToString()), int.Parse(this.DrpOrderBooker.SelectedValue.ToString()), int.Parse(control.chkNull_0(this.txtDays.Text)), this.RadioButtonList1.SelectedIndex);
        wise.SetDataSource(dataSet);
        wise.Refresh();
        wise.SetParameterValue("Distributor", this.drpDistributor.SelectedItem.Text);
        wise.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
        wise.SetParameterValue("Date", this.txtDocmentDate.Text);
        wise.SetParameterValue("DueDays", this.txtDays.Text);
        wise.SetParameterValue("CompanyName", table.Rows[0]["COMPANY_NAME"].ToString());
        this.Session.Add("CrpReport", wise);
        this.Session.Add("ReportType", 1);
        string str = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type type = base.GetType();
        this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        DocumentPrintController controller = new DocumentPrintController();
        SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCreditAgingOrderBookerWise wise = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCreditAgingOrderBookerWise();
        DataControl control = new DataControl();
        DataTable table = controller.SelectReportTitle(int.Parse(this.drpDistributor.SelectedValue.ToString()));
        DataSet dataSet = controller.SelectOrderBookerCreditAging(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtDocmentDate.Text), int.Parse(this.Session["UserId"].ToString()), int.Parse(this.DrpOrderBooker.SelectedValue.ToString()), int.Parse(control.chkNull_0(this.txtDays.Text)), this.RadioButtonList1.SelectedIndex);
        wise.SetDataSource(dataSet);
        wise.Refresh();
        wise.SetParameterValue("Distributor", this.drpDistributor.SelectedItem.Text);
        wise.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
        wise.SetParameterValue("Date", this.txtDocmentDate.Text);
        wise.SetParameterValue("DueDays", this.txtDays.Text);
        wise.SetParameterValue("CompanyName", table.Rows[0]["COMPANY_NAME"].ToString());
        this.Session.Add("CrpReport", wise);
        this.Session.Add("ReportType", 0);
        string str = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type type = base.GetType();
        this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
    }

    protected void ddDistributorType_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadOrderBooker();
    }

    private void LoadDistributor()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, table, 0, 2, true);
    }

    private void LoadOrderBooker()
    {
        if (this.drpDistributor.Items.Count > 0)
        {
            this.DrpOrderBooker.Items.Clear();
            DataTable table = new Distributor_UserController().SelectDistributorUser(0x23, int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            int num = -2147483648;
            this.DrpOrderBooker.Items.Add(new ListItem("All", num.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpOrderBooker, table, 0, 6);
        }
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
            this.LoadOrderBooker();
            Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            this.txtDocmentDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }
}