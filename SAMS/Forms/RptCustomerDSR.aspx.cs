using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;

public partial class Forms_RptCustomerDSR : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        DocumentPrintController controller = new DocumentPrintController();
        DataSet dataSet = null;
        controller.SelectReportTitle(int.Parse(this.drpDistributor.SelectedValue.ToString()));
        if (this.RbReportType.SelectedIndex == 0)
        {
            new DataControl();
            dataSet = controller.SelectCustomerDSRProDuctWise(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.Session["UserId"].ToString()), int.Parse(this.DrpRoute.SelectedValue.ToString()), int.Parse(this.drpChannelType.SelectedValue.ToString()), this.DrpReportType.SelectedIndex, int.Parse(this.DrpSaleForce.SelectedValue.ToString()));
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCustomerProductWiseDSR edsr = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCustomerProductWiseDSR();
            edsr.SetDataSource(dataSet);
            edsr.Refresh();
            edsr.SetParameterValue("Distributor_Name", this.drpDistributor.SelectedItem.Text);
            edsr.SetParameterValue("FROM_DATE", DateTime.Parse(this.txtStartDate.Text));
            edsr.SetParameterValue("TO_DATE", DateTime.Parse(this.txtEndDate.Text));
            edsr.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
            edsr.SetParameterValue("Area", this.DrpRoute.SelectedItem.Text);
            edsr.SetParameterValue("ChannelType", this.drpChannelType.SelectedItem.Text);
            edsr.SetParameterValue("ReportType", "Customer " + this.DrpReportType.SelectedItem.Text + " Report (Product Wise)");
            this.Session.Add("CrpReport", edsr);
            this.Session.Add("ReportType", 1);
            string str = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type type = base.GetType();
            this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
        }
        else
        {
            new DataSetToExcel();
            new DataControl();
            dataSet = controller.SelectCustomerDSRValueWise(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.Session["UserId"].ToString()), int.Parse(this.DrpRoute.SelectedValue.ToString()), int.Parse(this.drpChannelType.SelectedValue.ToString()), this.CheckBox1.Checked, int.Parse(this.DrpSaleForce.SelectedValue.ToString()));
            string fileName = Configuration.GetAppInstallationPath() + @"\CustomerDSR.xls";
            DataSetToExcel.exportToExcel(dataSet, fileName, "CUSTOMER_TRANSCTIONDETAIL");
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
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        DocumentPrintController controller = new DocumentPrintController();
        DataSet dataSet = null;
        controller.SelectReportTitle(int.Parse(this.drpDistributor.SelectedValue.ToString()));
        if (this.RbReportType.SelectedIndex == 0)
        {
            new DataControl();
            dataSet = controller.SelectCustomerDSRProDuctWise(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.Session["UserId"].ToString()), int.Parse(this.DrpRoute.SelectedValue.ToString()), int.Parse(this.drpChannelType.SelectedValue.ToString()), this.DrpReportType.SelectedIndex, int.Parse(this.DrpSaleForce.SelectedValue.ToString()));
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCustomerProductWiseDSR edsr = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCustomerProductWiseDSR();
            edsr.SetDataSource(dataSet);
            edsr.Refresh();
            edsr.SetParameterValue("Distributor_Name", this.drpDistributor.SelectedItem.Text);
            edsr.SetParameterValue("FROM_DATE", DateTime.Parse(this.txtStartDate.Text));
            edsr.SetParameterValue("TO_DATE", DateTime.Parse(this.txtEndDate.Text));
            edsr.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
            edsr.SetParameterValue("Area", this.DrpRoute.SelectedItem.Text);
            edsr.SetParameterValue("ChannelType", this.drpChannelType.SelectedItem.Text);
            edsr.SetParameterValue("ReportType", "Customer " + this.DrpReportType.SelectedItem.Text + " Report (Product Wise)");
            this.Session.Add("CrpReport", edsr);
            this.Session.Add("ReportType", 0);
            string str = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type type = base.GetType();
            this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
        }
        else
        {
            new DataControl();
            dataSet = controller.SelectCustomerDSRValueWise(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.Session["UserId"].ToString()), int.Parse(this.DrpRoute.SelectedValue.ToString()), int.Parse(this.drpChannelType.SelectedValue.ToString()), this.CheckBox1.Checked, int.Parse(this.DrpSaleForce.SelectedValue.ToString()));
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCustomerDSR rdsr = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpCustomerDSR();
            rdsr.SetDataSource(dataSet);
            rdsr.Refresh();
            rdsr.SetParameterValue("Distributor_Name", this.drpDistributor.SelectedItem.Text);
            rdsr.SetParameterValue("FROM_DATE", DateTime.Parse(this.txtStartDate.Text));
            rdsr.SetParameterValue("TO_DATE", DateTime.Parse(this.txtEndDate.Text));
            rdsr.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
            rdsr.SetParameterValue("Area", this.DrpRoute.SelectedItem.Text);
            rdsr.SetParameterValue("ChannelType", this.drpChannelType.SelectedItem.Text);
            rdsr.SetParameterValue("SaleForce", this.DrpSaleForce.SelectedItem.Text);
            this.Session.Add("CrpReport", rdsr);
            this.Session.Add("ReportType", 0);
            string str3 = "'Default.aspx'";
            string str4 = "<script language='JavaScript' type='text/javascript'> window.open(" + str3 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type type2 = base.GetType();
            this.Page.ClientScript.RegisterStartupScript(type2, "OpenWindow", str4);
        }
    }

    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadArea();
        this.LoadDeliveryman();
    }

    protected void DrpRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
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

    private void LoadChannelType()
    {
        DataTable table = new SLASHCodesController().SelectSlashCodes(-2147483648, null, 0x2e, null, -2147483648, bool.Parse("True"));
        int num = -2147483648;
        this.drpChannelType.Items.Add(new ListItem("All", num.ToString()));
        clsWebFormUtil.FillDropDownList(this.drpChannelType, table, 0, 2);
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
            this.LoadChannelType();
            this.LoadDeliveryman();
            Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            this.txtStartDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            this.txtEndDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }

    protected void RbReportType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.RbReportType.SelectedIndex == 0)
        {
            this.DrpReportType.Enabled = true;
            this.CheckBox1.Enabled = false;
        }
        else
        {
            this.DrpReportType.Enabled = false;
            this.CheckBox1.Enabled = true;
        }
    }
}