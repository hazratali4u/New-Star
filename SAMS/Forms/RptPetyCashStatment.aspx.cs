using System;
using System.Data;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;

public partial class Forms_RptPetyCashStatment : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.RbReportType.SelectedIndex == 0)
        {
            DocumentPrintController controller = new DocumentPrintController();
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPetyCashSummary summary = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPetyCashSummary();
            DataSet dataSet = controller.SelectPetyCashStatment(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.Session["UserId"].ToString()));
            summary.SetDataSource(dataSet);
            summary.Refresh();
            summary.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
            summary.SetParameterValue("Distributor", this.drpDistributor.SelectedItem.Text);
            summary.SetParameterValue("FROM_DATE", this.txtStartDate.Text);
            summary.SetParameterValue("TO_DATE", this.txtEndDate.Text);
            this.Session.Add("CrpReport", summary);
            this.Session.Add("ReportType", 1);
            string str = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type type = base.GetType();
            this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
        }
        else
        {
            DocumentPrintController controller2 = new DocumentPrintController();
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPettyCaahSummery summery = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPettyCaahSummery();
            DataSet set2 = controller2.SelectPetyCashSummary(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.Session["UserId"].ToString()));
            summery.SetDataSource(set2);
            summery.Refresh();
            summery.SetParameterValue("FROM_DATE", this.txtStartDate.Text);
            summery.SetParameterValue("TO_DATE", this.txtEndDate.Text);
            this.Session.Add("CrpReport", summery);
            this.Session.Add("ReportType", 1);
            string str3 = "'Default.aspx'";
            string str4 = "<script language='JavaScript' type='text/javascript'> window.open(" + str3 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type type2 = base.GetType();
            this.Page.ClientScript.RegisterStartupScript(type2, "OpenWindow", str4);
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (this.RbReportType.SelectedIndex == 0)
        {
            DocumentPrintController controller = new DocumentPrintController();
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPetyCashSummary summary = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPetyCashSummary();
            DataSet dataSet = controller.SelectPetyCashStatment(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.Session["UserId"].ToString()));
            summary.SetDataSource(dataSet);
            summary.Refresh();
            summary.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
            summary.SetParameterValue("Distributor", this.drpDistributor.SelectedItem.Text);
            summary.SetParameterValue("FROM_DATE", this.txtStartDate.Text);
            summary.SetParameterValue("TO_DATE", this.txtEndDate.Text);
            this.Session.Add("CrpReport", summary);
            this.Session.Add("ReportType", 0);
            string str = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type type = base.GetType();
            this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
        }
        else
        {
            DocumentPrintController controller2 = new DocumentPrintController();
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPettyCaahSummery summery = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPettyCaahSummery();
            DataSet set2 = controller2.SelectPetyCashSummary(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.Session["UserId"].ToString()));
            summery.SetDataSource(set2);
            summery.Refresh();
            summery.SetParameterValue("FROM_DATE", this.txtStartDate.Text);
            summery.SetParameterValue("TO_DATE", this.txtEndDate.Text);
            this.Session.Add("CrpReport", summery);
            this.Session.Add("ReportType", 0);
            string str3 = "'Default.aspx'";
            string str4 = "<script language='JavaScript' type='text/javascript'> window.open(" + str3 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type type2 = base.GetType();
            this.Page.ClientScript.RegisterStartupScript(type2, "OpenWindow", str4);
        }
    }

    private void LoadDistributor()
    {
        this.drpDistributor.Items.Clear();
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        if (this.RbReportType.SelectedIndex == 1)
        {
            int num = -2147483648;
            this.drpDistributor.Items.Add(new ListItem("All", num.ToString()));
        }
        clsWebFormUtil.FillDropDownList(this.drpDistributor, table, 0, 2);
    }

    private void LoadPrincipal()
    {
        DataTable table = new SKUPriceDetailController().SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        int num = -2147483648;
        this.DrpPrincipal.Items.Add(new ListItem("All", num.ToString()));
        this.DrpPrincipal.Items.Add(new ListItem("General Expense", "0"));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, table, 0, 1);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadPrincipal();
            Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            this.txtStartDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            this.txtEndDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }

    protected void RbReportType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadDistributor();
    }
}