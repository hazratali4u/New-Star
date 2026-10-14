using System;
using System.Data;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;

public partial class Forms_RptPhysicalStockTaking : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            DocumentPrintController controller = new DocumentPrintController();
            string str = null;
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPhysicalStockTaking taking = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPhysicalStockTaking();
            DataSet dataSet = null;
            str = DateTime.Parse(this.txtFromDate.Text).ToShortDateString();
            dataSet = controller.PhysicalStockTaking(int.Parse(this.drpPrincipal.SelectedValue.ToString()), int.Parse(this.DrpLocation.SelectedValue.ToString()), Convert.ToDateTime(str + " 00:00:00"));
            taking.SetDataSource(dataSet);
            taking.Refresh();
            taking.SetParameterValue("Principal", this.drpPrincipal.SelectedItem.Text.ToString());
            taking.SetParameterValue("Branch", this.DrpLocation.SelectedItem.Text.ToString());
            taking.SetParameterValue("FromDate", this.txtFromDate.Text);
            this.Session.Add("CrpReport", taking);
            this.Session.Add("ReportType", 1);
            string str2 = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str2 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
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
            if (this.RblType.SelectedIndex == 0)
            {
                DocumentPrintController controller = new DocumentPrintController();
                string str = null;
                SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPhysicalStockTaking taking = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPhysicalStockTaking();
                DataSet dataSet = null;
                str = DateTime.Parse(this.txtFromDate.Text).ToShortDateString();
                dataSet = controller.PhysicalStockTaking(int.Parse(this.drpPrincipal.SelectedValue.ToString()), int.Parse(this.DrpLocation.SelectedValue.ToString()), Convert.ToDateTime(str + " 00:00:00"));
                taking.SetDataSource(dataSet);
                taking.Refresh();
                taking.SetParameterValue("Principal", this.drpPrincipal.SelectedItem.Text.ToString());
                taking.SetParameterValue("Branch", this.DrpLocation.SelectedItem.Text.ToString());
                taking.SetParameterValue("FromDate", this.txtFromDate.Text);
                this.Session.Add("CrpReport", taking);
                this.Session.Add("ReportType", 0);
                string str2 = "'Default.aspx'";
                string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str2 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type type = base.GetType();
                this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
            }
            else
            {
                DocumentPrintController controller2 = new DocumentPrintController();
                string str4 = null;
                SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsRptPhysicalStockSummary summary = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsRptPhysicalStockSummary();
                DataSet set2 = null;
                str4 = DateTime.Parse(this.txtFromDate.Text).ToShortDateString();
                set2 = controller2.PhysicalStockTakingValueWise(int.Parse(this.drpPrincipal.SelectedValue.ToString()), int.Parse(this.DrpLocation.SelectedValue.ToString()), Convert.ToDateTime(str4 + " 00:00:00"), int.Parse(this.Session["UserId"].ToString()));
                summary.SetDataSource(set2);
                summary.Refresh();
                summary.SetParameterValue("FromDate", this.txtFromDate.Text);
                this.Session.Add("CrpReport", summary);
                this.Session.Add("ReportType", 0);
                string str5 = "'Default.aspx'";
                string str6 = "<script language='JavaScript' type='text/javascript'> window.open(" + str5 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type type2 = base.GetType();
                this.Page.ClientScript.RegisterStartupScript(type2, "OpenWindow", str6);
            }
        }
        catch (Exception exception)
        {
            exception.ToString();
        }
    }

    protected void LoadLocation()
    {
        try
        {
            this.DrpLocation.Items.Clear();
            if (this.RblType.SelectedIndex == 0)
            {
                DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
                clsWebFormUtil.FillDropDownList(this.DrpLocation, table, "DISTRIBUTOR_ID", "DISTRIBUTOR_NAME");
            }
            else
            {
                DataTable table2 = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
                int num = -2147483648;
                this.DrpLocation.Items.Add(new ListItem("All", num.ToString()));
                clsWebFormUtil.FillDropDownList(this.DrpLocation, table2, "DISTRIBUTOR_ID", "DISTRIBUTOR_NAME");
            }
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
            this.drpPrincipal.Items.Clear();
            if (this.RblType.SelectedIndex == 0)
            {
                DataTable table = new SKUPriceDetailController().SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
                clsWebFormUtil.FillDropDownList(this.drpPrincipal, table, "Company_Id", "Company_Name");
            }
            else
            {
                DataTable table2 = new SKUPriceDetailController().SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
                int num = -2147483648;
                this.drpPrincipal.Items.Add(new ListItem("All", num.ToString()));
                clsWebFormUtil.FillDropDownList(this.drpPrincipal, table2, "Company_Id", "Company_Name");
            }
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
            this.txtFromDate.Text = Convert.ToDateTime(this.Session["CurrentWorkDate"]).ToString("dd-MMM-yyyy");
        }
    }

    protected void RblType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadPrincipal();
        this.LoadLocation();
    }
}