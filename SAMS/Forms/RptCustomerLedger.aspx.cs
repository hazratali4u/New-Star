using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
using System;
using System.Data;

public partial class Forms_RptCustomerLedger : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        new DataControl();
        DataSet dataSet = new DocumentPrintController().CustomerLedger_View(int.Parse(this.DrpPrincipal.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpCustomer.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"));
        SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCustomerLedger ledger = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCustomerLedger();
        ledger.SetDataSource(dataSet);
        ledger.Refresh();
        ledger.SetParameterValue("CompanyName", "");
        ledger.SetParameterValue("FromDate", DateTime.Parse(this.txtStartDate.Text));
        ledger.SetParameterValue("To_date", DateTime.Parse(this.txtEndDate.Text));
        ledger.SetParameterValue("Location", this.drpDistributor.SelectedItem.Text);
        ledger.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
        ledger.SetParameterValue("Town_Name", this.DrpRoute.SelectedItem.Text);
        ledger.SetParameterValue("Customer", this.DrpCustomer.SelectedItem.Text);
        ledger.SetParameterValue("Op_Balance", this.LoadCustomerOpBalance());
        this.Session.Add("CrpReport", ledger);
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
        DataTable table = new DistributorAreaController().SelectDist_Area(-9223372036854775808L, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.drpDistributor.SelectedValue.ToString()), -2147483648, null, null);
        clsWebFormUtil.FillDropDownList(this.DrpRoute, table, 0, 6, true);
    }

    private decimal LoadCustomerOpBalance()
    {
        if ((this.drpDistributor.Items.Count > 0) && (this.DrpCustomer.Items.Count > 0))
        {
            CustomerDataController controller = new CustomerDataController();
            return decimal.Parse(controller.SelectPrincipalCustomerOpBalance(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpCustomer.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), int.Parse(this.DrpPrincipal.SelectedValue.ToString())).Rows[0][0].ToString());
        }
        return 0M;
    }

    private void LoadData()
    {
        if ((this.drpDistributor.Items.Count > 0) && (this.DrpRoute.Items.Count > 0))
        {
            DataTable table = new CustomerDataController().SelectAllCustomer(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpRoute.SelectedValue.ToString()), -2147483648);
            clsWebFormUtil.FillDropDownList(this.DrpCustomer, table, 0, 3, true);
        }
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadPrincipal();
            this.LoadDistributor();
            this.LoadArea();
            this.LoadData();
            Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            this.txtStartDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            this.txtEndDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }
}