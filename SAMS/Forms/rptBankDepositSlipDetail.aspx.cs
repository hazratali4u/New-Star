using System;
using System.Data;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;

public partial class Forms_rptBankDepositSlipDetail : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            DocumentPrintController controller = new DocumentPrintController();
            string str = null;
            string str2 = null;
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpBankDepositSlipDetail detail = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpBankDepositSlipDetail();
            DataSet dataSet = null;
            DateTime time = DateTime.Parse(this.txtFromDate.Text);
            DateTime time2 = DateTime.Parse(this.txtToDate.Text);
            str = time.ToShortDateString();
            str2 = time2.ToShortDateString();
            dataSet = controller.BankDepositSlipDetail(int.Parse(this.drpPrincipal.SelectedValue.ToString()), int.Parse(this.DrpLocation.SelectedValue.ToString()), Convert.ToDateTime(str + " 00:00:00"), Convert.ToDateTime(str2 + " 00:00:00"), Convert.ToInt32(this.drpAccount.SelectedValue.ToString()));
            detail.SetDataSource(dataSet);
            detail.Refresh();
            detail.SetParameterValue("Principal", this.drpPrincipal.SelectedItem.Text.ToString());
            detail.SetParameterValue("Branch", this.DrpLocation.SelectedItem.Text.ToString());
            detail.SetParameterValue("FromDate", this.txtFromDate.Text);
            detail.SetParameterValue("ToDate", this.txtToDate.Text);
            detail.SetParameterValue("Account", this.drpAccount.SelectedItem.Text.ToString());
            this.Session.Add("CrpReport", detail);
            this.Session.Add("ReportType", 1);
            string str3 = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str3 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type type = base.GetType();
            this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
        }
        catch (Exception exception)
        {
            exception.ToString();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            DocumentPrintController controller = new DocumentPrintController();
            string str = null;
            string str2 = null;
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpBankDepositSlipDetail detail = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpBankDepositSlipDetail();
            DataSet dataSet = null;
            DateTime time = DateTime.Parse(this.txtFromDate.Text);
            DateTime time2 = DateTime.Parse(this.txtToDate.Text);
            str = time.ToShortDateString();
            str2 = time2.ToShortDateString();
            dataSet = controller.BankDepositSlipDetail(int.Parse(this.drpPrincipal.SelectedValue.ToString()), int.Parse(this.DrpLocation.SelectedValue.ToString()), Convert.ToDateTime(str + " 00:00:00"), Convert.ToDateTime(str2 + " 00:00:00"), Convert.ToInt32(this.drpAccount.SelectedValue.ToString()));
            detail.SetDataSource(dataSet);
            detail.Refresh();
            detail.SetParameterValue("Principal", this.drpPrincipal.SelectedItem.Text.ToString());
            detail.SetParameterValue("Branch", this.DrpLocation.SelectedItem.Text.ToString());
            detail.SetParameterValue("FromDate", this.txtFromDate.Text);
            detail.SetParameterValue("ToDate", this.txtToDate.Text);
            detail.SetParameterValue("Account", this.drpAccount.SelectedItem.Text.ToString());
            this.Session.Add("CrpReport", detail);
            this.Session.Add("ReportType", 0);
            string str3 = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str3 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type type = base.GetType();
            this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
        }
        catch (Exception exception)
        {
            exception.ToString();
        }
    }

    protected void LoadAccount()
    {
        DataTable table = new AccountHeadController().SelectAccountHead(0x5e, 0x2bL);
        this.drpAccount.Items.Add(new ListItem("All", "0"));
        clsWebFormUtil.FillDropDownList(this.drpAccount, table, 0, 4, false);
    }

    protected void LoadLocation()
    {
        try
        {
            DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            this.DrpLocation.DataSource = table;
            this.DrpLocation.DataTextField = "DISTRIBUTOR_NAME";
            this.DrpLocation.DataValueField = "DISTRIBUTOR_ID";
            this.DrpLocation.DataBind();
        }
        catch (Exception exception)
        {
            exception.ToString();
        }
    }

    protected void LoadPrincipal()
    {
        try
        {
            DataTable table = new SKUPriceDetailController().SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            this.drpPrincipal.Items.Add(new ListItem("All", "0"));
            clsWebFormUtil.FillDropDownList(this.drpPrincipal, table, "Company_Id", "Company_Name");
        }
        catch (Exception exception)
        {
            exception.ToString();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadPrincipal();
            this.LoadLocation();
            this.LoadAccount();
            this.txtFromDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
            this.txtToDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
        }
    }
}