using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;
using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

public partial class Forms_frmCreditReportSummary : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        new DataSetToExcel();
        new DataControl();
        DataSet set = new DocumentPrintController().SelectPrincipalCreditDetail(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text), DateTime.Parse(this.txtEndDate.Text), int.Parse(this.Session["UserId"].ToString()), 0, int.Parse(this.DrpOrderBooker.SelectedValue.ToString()), int.Parse(this.DrpDeliveryMan.SelectedValue.ToString()));
        string fileName = Configuration.GetAppInstallationPath() + @"\CustomerDSR.xls";
        DataSetToExcel.exportToExcel(set, fileName, "RptCreditSummary");
        FileInfo info = new FileInfo(fileName);
        if (info.Exists)
        {
            base.Response.Clear();
            base.Response.AddHeader("Content-Disposition", "attachment; filename=" + info.Name);
            base.Response.AddHeader("Content-Length", info.Length.ToString());
            base.Response.ContentType = "application/octet-stream";
            base.Response.WriteFile(info.FullName);
            base.Response.End();
        }
        else
        {
            base.Response.Write("This file does not exist.");
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (this.rbtSotBy.SelectedIndex == 0)
        {
            DocumentPrintController controller = new DocumentPrintController();
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCustomerCreditSummary summary = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCustomerCreditSummary();
            DataSet dataSet = controller.SelectPrincipalCreditDetail(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text), DateTime.Parse(this.txtEndDate.Text), int.Parse(this.Session["UserId"].ToString()), 0, int.Parse(this.DrpOrderBooker.SelectedValue.ToString()), int.Parse(this.DrpDeliveryMan.SelectedValue.ToString()));
            summary.SetDataSource(dataSet);
            summary.Refresh();
            summary.SetParameterValue("Distributor", this.drpDistributor.SelectedItem.Text);
            summary.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
            summary.SetParameterValue("From_date", this.txtStartDate.Text);
            summary.SetParameterValue("To_Date", this.txtEndDate.Text);
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
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCustomerWiseSelling selling = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCustomerWiseSelling();
            DataSet set2 = controller2.SelectCustomerCreditCeiling(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), int.Parse(this.Session["UserId"].ToString()));
            selling.SetDataSource(set2);
            selling.Refresh();
            selling.SetParameterValue("Distributor", this.drpDistributor.SelectedItem.Text);
            selling.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
            this.Session.Add("CrpReport", selling);
            this.Session.Add("ReportType", 0);
            string str3 = "'Default.aspx'";
            string str4 = "<script language='JavaScript' type='text/javascript'> window.open(" + str3 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type type2 = base.GetType();
            this.Page.ClientScript.RegisterStartupScript(type2, "OpenWindow", str4);
        }
    }

    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadOrderBooker();
    }

    private void LoadDeliveryman()
    {
        if (this.drpDistributor.Items.Count > 0)
        {
            DataTable table = new Distributor_UserController().SelectSaleForceAssignedArea(int.Parse(this.drpDistributor.SelectedValue.ToString()), -2147483648, int.Parse(this.Session["CompanyId"].ToString()));
            int num = -2147483648;
            this.DrpDeliveryMan.Items.Add(new ListItem("All", num.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpDeliveryMan, table, 0, 3);
        }
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
            this.LoadDeliveryman();
            Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            this.txtStartDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            this.txtEndDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }
}