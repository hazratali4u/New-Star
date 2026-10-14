using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;

public partial class Forms_RptSaleTradeChannel : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        new DataControl();
        DataSet set = new DocumentPrintController().SelectTradeChannelSale(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.Session["UserId"].ToString()), int.Parse(this.DrpRoute.SelectedValue.ToString()), int.Parse(this.DrpSaleForce.SelectedValue.ToString()));
        string fileName = Configuration.GetAppInstallationPath() + @"\TradeChanel.xls";
        DataSetToExcel.exportToExcel(set, fileName, "RptTradeChannelSaleDetail");
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
        new DataControl();
        DataSet dataSet = new DocumentPrintController().SelectTradeChannelSale(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.Session["UserId"].ToString()), int.Parse(this.DrpRoute.SelectedValue.ToString()), int.Parse(this.DrpSaleForce.SelectedValue.ToString()));
        SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpTradeChannelReport report = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpTradeChannelReport();
        report.SetDataSource(dataSet);
        report.Refresh();
        report.SetParameterValue("Distributor_Name", this.drpDistributor.SelectedItem.Text);
        report.SetParameterValue("FROM_DATE", DateTime.Parse(this.txtStartDate.Text));
        report.SetParameterValue("TO_DATE", DateTime.Parse(this.txtEndDate.Text));
        report.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
        report.SetParameterValue("Area", this.DrpRoute.SelectedItem.Text);
        report.SetParameterValue("SaleForce", this.DrpSaleForce.SelectedItem.Text);
        this.Session.Add("CrpReport", report);
        this.Session.Add("ReportType", 0);
        string str = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type type = base.GetType();
        this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
    }

    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadArea();
        this.LoadDeliveryman();
    }

    private void LoadArea()
    {
        if (this.drpDistributor.Items.Count > 0)
        {
            this.DrpRoute.Items.Clear();
            DataTable table = new DistributorAreaController().SelectDist_Area(-9223372036854775808L, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.drpDistributor.SelectedValue.ToString()), -2147483648, null, null);
            int num = -2147483648;
            this.DrpRoute.Items.Add(new ListItem("All", num.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpRoute, table, 0, 6);
        }
        else
        {
            this.DrpRoute.Items.Clear();
        }
    }

    private void LoadDeliveryman()
    {
        if (this.drpDistributor.Items.Count > 0)
        {
            this.DrpSaleForce.Items.Clear();
            DataTable table = new Distributor_UserController().SelectSaleForceAssignedArea(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpRoute.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            int num = -2147483648;
            this.DrpSaleForce.Items.Add(new ListItem("All", num.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpSaleForce, table, 0, 3);
        }
        else
        {
            this.DrpSaleForce.Items.Clear();
        }
    }

    private void LoadDistributor()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
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
        if (!base.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadPrincipal();
            this.LoadArea();
            this.LoadDeliveryman();
            Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            this.txtStartDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            this.txtEndDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }
}