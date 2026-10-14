using System;
using System.Data;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;

public partial class Forms_frmSalePersonDSR : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        DocumentPrintController controller = new DocumentPrintController();
        DataSet dataSet = null;
        controller.SelectReportTitle(int.Parse(this.drpDistributor.SelectedValue.ToString()));
        if (this.RbReportType.SelectedIndex == 0)
        {
            new DataControl();
            dataSet = controller.SelectSalePersonDSRProDuctWise(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.Session["UserId"].ToString()));
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpSaleReport_ProductWise wise = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpSaleReport_ProductWise();
            wise.SetDataSource(dataSet);
            wise.Refresh();
            wise.SetParameterValue("Distributor_Name", this.drpDistributor.SelectedItem.Text);
            wise.SetParameterValue("FROM_DATE", DateTime.Parse(this.txtStartDate.Text));
            wise.SetParameterValue("TO_DATE", DateTime.Parse(this.txtEndDate.Text));
            wise.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
            this.Session.Add("CrpReport", wise);
            this.Session.Add("ReportType", 1);
            string str = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type type = base.GetType();
            this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
        }
        else
        {
            new DataControl();
            dataSet = controller.SelectSalePersonDSR(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.Session["UserId"].ToString()));
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpSalePersonDSR2 ndsr = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpSalePersonDSR2();
            ndsr.SetDataSource(dataSet);
            ndsr.Refresh();
            ndsr.SetParameterValue("Distributor_Name", this.drpDistributor.SelectedItem.Text);
            ndsr.SetParameterValue("FROM_DATE", DateTime.Parse(this.txtStartDate.Text));
            ndsr.SetParameterValue("TO_DATE", DateTime.Parse(this.txtEndDate.Text));
            ndsr.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
            this.Session.Add("CrpReport", ndsr);
            this.Session.Add("ReportType", 1);
            string str3 = "'Default.aspx'";
            string str4 = "<script language='JavaScript' type='text/javascript'> window.open(" + str3 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type type2 = base.GetType();
            this.Page.ClientScript.RegisterStartupScript(type2, "OpenWindow", str4);
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        DocumentPrintController controller = new DocumentPrintController();
        DataSet dataSet = null;
        DataTable table = controller.SelectReportTitle(int.Parse(this.drpDistributor.SelectedValue.ToString()));
        if (this.RbReportType.SelectedIndex == 0)
        {
            if (this.DrpSaleForceType.SelectedIndex == 0)
            {
                new DataControl();
                dataSet = controller.SelectOrderBookerDSRProDuctWise(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.Session["UserId"].ToString()));
                SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpSaleReport_ProductWise wise = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpSaleReport_ProductWise();
                wise.SetDataSource(dataSet);
                wise.Refresh();
                wise.SetParameterValue("Distributor_Name", this.drpDistributor.SelectedItem.Text);
                wise.SetParameterValue("FROM_DATE", DateTime.Parse(this.txtStartDate.Text));
                wise.SetParameterValue("TO_DATE", DateTime.Parse(this.txtEndDate.Text));
                wise.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
                this.Session.Add("CrpReport", wise);
                this.Session.Add("ReportType", 0);
                string str = "'Default.aspx'";
                string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type type = base.GetType();
                this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
            }
            else
            {
                new DataControl();
                dataSet = controller.SelectSalePersonDSRProDuctWise(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.Session["UserId"].ToString()));
                SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpSaleReport_ProductWise wise2 = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpSaleReport_ProductWise();
                wise2.SetDataSource(dataSet);
                wise2.Refresh();
                wise2.SetParameterValue("Distributor_Name", this.drpDistributor.SelectedItem.Text);
                wise2.SetParameterValue("FROM_DATE", DateTime.Parse(this.txtStartDate.Text));
                wise2.SetParameterValue("TO_DATE", DateTime.Parse(this.txtEndDate.Text));
                wise2.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
                this.Session.Add("CrpReport", wise2);
                this.Session.Add("ReportType", 0);
                string str3 = "'Default.aspx'";
                string str4 = "<script language='JavaScript' type='text/javascript'> window.open(" + str3 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type type2 = base.GetType();
                this.Page.ClientScript.RegisterStartupScript(type2, "OpenWindow", str4);
            }
        }
        else if (this.DrpSaleForceType.SelectedIndex == 0)
        {
            new DataControl();
            dataSet = controller.SelectOrderBookerDSR(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.Session["UserId"].ToString()));
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpSalePersonDSR2 ndsr = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpSalePersonDSR2();
            ndsr.SetDataSource(dataSet);
            ndsr.Refresh();
            ndsr.SetParameterValue("Distributor_Name", this.drpDistributor.SelectedItem.Text);
            ndsr.SetParameterValue("FROM_DATE", DateTime.Parse(this.txtStartDate.Text));
            ndsr.SetParameterValue("TO_DATE", DateTime.Parse(this.txtEndDate.Text));
            ndsr.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
            ndsr.SetParameterValue("CompanyName", table.Rows[0]["COMPANY_NAME"].ToString());
            this.Session.Add("CrpReport", ndsr);
            this.Session.Add("ReportType", 0);
            string str5 = "'Default.aspx'";
            string str6 = "<script language='JavaScript' type='text/javascript'> window.open(" + str5 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type type3 = base.GetType();
            this.Page.ClientScript.RegisterStartupScript(type3, "OpenWindow", str6);
        }
        else
        {
            new DataControl();
            dataSet = controller.SelectSalePersonDSR(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), int.Parse(this.Session["UserId"].ToString()));
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpSalePersonDSR2 ndsr2 = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpSalePersonDSR2();
            ndsr2.SetDataSource(dataSet);
            ndsr2.Refresh();
            ndsr2.SetParameterValue("Distributor_Name", this.drpDistributor.SelectedItem.Text);
            ndsr2.SetParameterValue("FROM_DATE", DateTime.Parse(this.txtStartDate.Text));
            ndsr2.SetParameterValue("TO_DATE", DateTime.Parse(this.txtEndDate.Text));
            ndsr2.SetParameterValue("Principal", this.DrpPrincipal.SelectedItem.Text);
            ndsr2.SetParameterValue("CompanyName", table.Rows[0]["COMPANY_NAME"].ToString());
            this.Session.Add("CrpReport", ndsr2);
            this.Session.Add("ReportType", 0);
            string str7 = "'Default.aspx'";
            string str8 = "<script language='JavaScript' type='text/javascript'> window.open(" + str7 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type type4 = base.GetType();
            this.Page.ClientScript.RegisterStartupScript(type4, "OpenWindow", str8);
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
            Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            this.txtStartDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            this.txtEndDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }

}