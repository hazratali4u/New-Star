using System;
using System.Data;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;

public partial class Forms_rptbankdeposit : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        DocumentPrintController controller = new DocumentPrintController();
        DataSet dataSet = null;
        controller.SelectReportTitle(int.Parse(this.drpDistributor.SelectedValue.ToString()));
        new DataControl();
        dataSet = controller.SelectDailyBankDeposit(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.Session["UserId"].ToString()));
        SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpDailyBankDeposit deposit = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpDailyBankDeposit();
        deposit.SetDataSource(dataSet);
        deposit.Refresh();
        deposit.SetParameterValue("FROM_DATE", DateTime.Parse(this.txtStartDate.Text));
        deposit.SetParameterValue("TO_DATE", DateTime.Parse(this.txtEndDate.Text));
        deposit.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
        this.Session.Add("ReportType", 1);
        this.Session.Add("CrpReport", deposit);
        string str = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type type = base.GetType();
        this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        DocumentPrintController controller = new DocumentPrintController();
        DataSet dataSet = null;
        controller.SelectReportTitle(int.Parse(this.drpDistributor.SelectedValue.ToString()));
        new DataControl();
        dataSet = controller.SelectDailyBankDeposit(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.Session["UserId"].ToString()));
        SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpDailyBankDeposit deposit = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpDailyBankDeposit();
        deposit.SetDataSource(dataSet);
        deposit.Refresh();
        deposit.SetParameterValue("FROM_DATE", DateTime.Parse(this.txtStartDate.Text));
        deposit.SetParameterValue("TO_DATE", DateTime.Parse(this.txtEndDate.Text));
        deposit.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
        this.Session.Add("ReportType", 0);
        this.Session.Add("CrpReport", deposit);
        string str = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type type = base.GetType();
        this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
    }

    private void LoadDistributor()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, table, 0, 2, true);
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
        if (!base.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadPrincipal();
            Configuration.SystemCurrentDateTime =(DateTime)this.Session["CurrentWorkDate"];
            this.txtStartDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            this.txtEndDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }
}