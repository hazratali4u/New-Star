using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Forms_RptLedgerReport : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
    }

    protected void Button2_Click1(object sender, EventArgs e)
    {
        DataRow[] rowArray = ((DataTable)this.Session["dtHead"]).Select("ACCOUNT_CODE  = '" + this.txtAccountCode.Text + "'");
        DocumentPrintController controller = new DocumentPrintController();
        DataSet dataSet = null;
        if (rowArray.Length > 0)
        {
            long num = long.Parse(rowArray[0]["ACCOUNT_HEAD_ID"].ToString());
            new DataControl();
            dataSet = controller.GeneralLedger_View(int.Parse(this.DrpPrincipal.SelectedValue.ToString()), num, int.Parse(this.drpDistributor.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), this.rbPosted.SelectedIndex);
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpLedgerView view = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpLedgerView();
            view.SetDataSource(dataSet);
            view.Refresh();
            view.SetParameterValue("CompanyName", "Friends Distribution Management");
            view.SetParameterValue("FromDate", DateTime.Parse(this.txtStartDate.Text));
            view.SetParameterValue("To_date", DateTime.Parse(this.txtEndDate.Text));
            view.SetParameterValue("Location", this.drpDistributor.SelectedItem.Text);
            view.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
            this.Session.Add("CrpReport", view);
            this.Session.Add("ReportType", 0);
            string str = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type type = base.GetType();
            this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
        }
    }

    private void LoadAccountDetail()
    {
        DataTable table = new AccountHeadController().SelectAccountHead(0x5e, -9223372036854775808L);
        clsWebFormUtil.FillListBox(this.LstAccountHead, table, "ACCOUNT_HEAD", "ACCOUNT_HEAD", true);
        this.Session.Add("dtHead", table);
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
            this.LoadPrincipal();
            this.LoadDistributor();
            this.LoadAccountDetail();
            Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            this.txtStartDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            this.txtEndDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }
}