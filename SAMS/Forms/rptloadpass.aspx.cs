using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Forms_rptloadpass : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.rblReport.SelectedIndex == 0)
            {
                DocumentPrintController controller = new DocumentPrintController();
                DataSet dataSet = null;
                dataSet = controller.LoadPass(int.Parse(this.drpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtFromDate.Text), int.Parse(this.DrpOrderBooker.SelectedValue.ToString()));
                SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpLoadPass pass = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpLoadPass();
                pass.SetDataSource(dataSet);
                pass.Refresh();
                pass.SetParameterValue("DeliveryManName", this.DrpOrderBooker.SelectedItem.Text.ToString());
                pass.SetParameterValue("Date", this.txtFromDate.Text);
                this.Session.Add("CrpReport", pass);
                this.Session.Add("ReportType", 1);
                string str = "'Default.aspx'";
                string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type type = base.GetType();
                this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
            }
            else
            {
                DocumentPrintController controller2 = new DocumentPrintController();
                DataSet set2 = null;
                set2 = controller2.LoadPass(int.Parse(this.drpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtFromDate.Text), int.Parse(this.drpPrincipal.SelectedValue.ToString()));
                SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpLoadPassDM sdm = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpLoadPassDM();
                sdm.SetDataSource(set2);
                sdm.Refresh();
                sdm.SetParameterValue("Principal", this.DrpOrderBooker.SelectedItem.Text.ToString());
                sdm.SetParameterValue("Date", this.txtFromDate.Text);
                this.Session.Add("CrpReport", sdm);
                this.Session.Add("ReportType", 1);
                string str3 = "'Default.aspx'";
                string str4 = "<script language='JavaScript' type='text/javascript'> window.open(" + str3 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type type2 = base.GetType();
                this.Page.ClientScript.RegisterStartupScript(type2, "OpenWindow", str4);
            }
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
            if (this.rblReport.SelectedIndex == 0)
            {
                DocumentPrintController controller = new DocumentPrintController();
                DataTable table = controller.SelectReportTitle(Convert.ToInt32(this.DrpLocation.SelectedValue));
                DataSet dataSet = null;
                dataSet = controller.LoadPass(int.Parse(this.drpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtFromDate.Text + " 00:00:00"), int.Parse(this.DrpOrderBooker.SelectedValue.ToString()));
                SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPrintDSR tdsr = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPrintDSR();
                tdsr.SetDataSource(dataSet);
                tdsr.Refresh();
                tdsr.SetParameterValue("SalemanName", this.DrpOrderBooker.SelectedItem.Text.ToString());
                tdsr.SetParameterValue("Date", this.txtFromDate.Text);
                tdsr.SetParameterValue("CompanyName", table.Rows[0]["COMPANY_NAME"].ToString());
                this.Session.Add("CrpReport", tdsr);
                this.Session.Add("ReportType", 0);
                string str = "'Default.aspx'";
                string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type type = base.GetType();
                this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
            }
            else
            {
                DocumentPrintController controller2 = new DocumentPrintController();
                DataTable table2 = controller2.SelectReportTitle(Convert.ToInt32(this.DrpLocation.SelectedValue));
                DataSet set2 = null;
                set2 = controller2.LoadPass(int.Parse(this.drpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.txtFromDate.Text + " 00:00:00"), -2147483648);
                SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpLoadPassDM sdm = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpLoadPassDM();
                sdm.SetDataSource(set2);
                sdm.Refresh();
                sdm.SetParameterValue("Principal", this.drpPrincipal.SelectedItem.Text.ToString());
                sdm.SetParameterValue("Date", this.txtFromDate.Text);
                sdm.SetParameterValue("CompanyName", table2.Rows[0]["COMPANY_NAME"].ToString());
                this.Session.Add("CrpReport", sdm);
                this.Session.Add("ReportType", 0);
                string str3 = "'Default.aspx'";
                string str4 = "<script language='JavaScript' type='text/javascript'> window.open(" + str3 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type type2 = base.GetType();
                this.Page.ClientScript.RegisterStartupScript(type2, "OpenWindow", str4);
            }
        }
        catch (Exception exception)
        {
            exception.ToString();
        }
    }

    protected void DrpLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadOrderBooker();
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

    private void LoadOrderBooker()
    {
        this.DrpOrderBooker.Items.Clear();
        if (this.DrpLocation.Items.Count > 0)
        {
            DataTable table = new Distributor_UserController().SelectSaleForceAssignedArea(int.Parse(this.DrpLocation.SelectedValue.ToString()), -2147483648, int.Parse(this.Session["CompanyId"].ToString()));
            int num = -2147483648;
            this.DrpOrderBooker.Items.Add(new ListItem("All", num.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpOrderBooker, table, 0, 3, true);
        }
    }

    protected void LoadPrincipal()
    {
        try
        {
            DataTable table = new SKUPriceDetailController().SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            int num = -2147483648;
            this.drpPrincipal.Items.Add(new ListItem("All", num.ToString()));
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
            this.LoadOrderBooker();
            Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            this.txtFromDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }

    protected void rblReport_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.rblReport.SelectedIndex == 0)
        {
            this.DrpOrderBooker.Visible = true;
            this.lblSalesMan.Visible = true;
        }
        else
        {
            this.DrpOrderBooker.Visible = false;
            this.lblSalesMan.Visible = false;
        }
    }
}