using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Forms_RptCreditAging : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet dataSet = new DocumentPrintController().GetCreditAgingReport(int.Parse(this.ddDistributorType.SelectedItem.Value), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.Session["UserId"].ToString()), this.rbtSotBy.SelectedIndex, DateTime.Parse(this.txtDocmentDate.Text + " 23:59:59"));
        SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCreditAgingReport report = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCreditAgingReport();
        report.SetDataSource(dataSet);
        report.Refresh();
        report.SetParameterValue("UptoDate", this.txtDocmentDate.Text);
        this.Session.Add("CrpReport", report);
        this.Session.Add("ReportType", 1);
        string str = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type type = base.GetType();
        this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        DataSet dataSet = new DocumentPrintController().GetCreditAgingReport(int.Parse(this.ddDistributorType.SelectedItem.Value), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.Session["UserId"].ToString()), this.rbtSotBy.SelectedIndex, DateTime.Parse(this.txtDocmentDate.Text + " 23:59:59"));
        SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCreditAgingReport report = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCreditAgingReport();
        report.SetDataSource(dataSet);
        report.Refresh();
        report.SetParameterValue("UptoDate", this.txtDocmentDate.Text);
        report.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
        this.Session.Add("CrpReport", report);
        this.Session.Add("ReportType", 0);
        string str = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type type = base.GetType();
        this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
    }

    protected void ddDistributorType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadAssingned();
    }

    private void DistributorType()
    {
        DataTable table = new DistributorController().SelectDistributorTypeInfo(-2147483648);
        clsWebFormUtil.FillDropDownList(this.ddDistributorType, table, 0, 2);
    }

    private void LoadAssingned()
    {
        if (this.ddDistributorType.Items.Count > 0)
        {
            this.drpDistributor.Items.Clear();
            if (this.rbtSotBy.SelectedIndex == 0)
            {
                DataTable table = new SAMSUserController().SelectUserAssignment(int.Parse(this.Session["UserId"].ToString()), int.Parse(this.ddDistributorType.SelectedValue.ToString()), 1, int.Parse(this.Session["CompanyId"].ToString()));
                int num = -2147483648;
                this.drpDistributor.Items.Add(new ListItem("All", num.ToString()));
                clsWebFormUtil.FillDropDownList(this.drpDistributor, table, 0, 1);
            }
            else
            {
                DataTable table2 = new SAMSUserController().SelectUserAssignment(int.Parse(this.Session["UserId"].ToString()), int.Parse(this.ddDistributorType.SelectedValue.ToString()), 1, int.Parse(this.Session["CompanyId"].ToString()));
                clsWebFormUtil.FillDropDownList(this.drpDistributor, table2, 0, 1);
            }
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
            this.DistributorType();
            this.LoadAssingned();
            this.LoadPrincipal();
            Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            this.txtDocmentDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }

    protected void rbtSotBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadAssingned();
    }
}