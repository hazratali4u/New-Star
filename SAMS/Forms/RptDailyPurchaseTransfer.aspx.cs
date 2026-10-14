using System;
using System.Data;
using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;

public partial class Forms_RptDailyPurchaseTransfer : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        DocumentPrintController controller = new DocumentPrintController();
        DataSet dataSet = null;
        controller.SelectReportTitle(int.Parse(this.drpDistributor.SelectedValue.ToString()));
        new DataControl();
        dataSet = controller.SelectPurchaseTransferStock(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.DrpDocumentType.SelectedValue.ToString()));
        SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpDailyPurchaseTransfer transfer = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpDailyPurchaseTransfer();
        transfer.SetDataSource(dataSet);
        transfer.Refresh();
        transfer.SetParameterValue("FROM_DATE", DateTime.Parse(this.txtStartDate.Text));
        transfer.SetParameterValue("TO_DATE", DateTime.Parse(this.txtEndDate.Text));
        transfer.SetParameterValue("PRINCIPAL", this.DrpPrincipal.SelectedItem.Text);
        transfer.SetParameterValue("LOCATION", this.drpDistributor.SelectedItem.Text);
        transfer.SetParameterValue("ReportTitle", "Date Wise " + this.DrpDocumentType.SelectedItem.Text + " Report");
        this.Session.Add("ReportType", 1);
        this.Session.Add("CrpReport", transfer);
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
        dataSet = controller.SelectPurchaseTransferStock(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.DrpDocumentType.SelectedValue.ToString()));
        SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpDailyPurchaseTransfer transfer = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpDailyPurchaseTransfer();
        transfer.SetDataSource(dataSet);
        transfer.Refresh();
        transfer.SetParameterValue("FROM_DATE", DateTime.Parse(this.txtStartDate.Text));
        transfer.SetParameterValue("TO_DATE", DateTime.Parse(this.txtEndDate.Text));
        transfer.SetParameterValue("PRINCIPAL", this.DrpPrincipal.SelectedItem.Text);
        transfer.SetParameterValue("LOCATION", this.drpDistributor.SelectedItem.Text);
        transfer.SetParameterValue("ReportTitle", "Date Wise " + this.DrpDocumentType.SelectedItem.Text + " Report");
        this.Session.Add("ReportType", 0);
        this.Session.Add("CrpReport", transfer);
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
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, table, 0, 1);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadPrincipal();
            Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            this.txtStartDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            this.txtEndDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }
}