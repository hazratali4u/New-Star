using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Forms_rptbookingsupplymonitoring : System.Web.UI.Page
{
    protected void btnViewExcel(object sender, EventArgs e)
    {
        this.ShowReport(1);
    }

    protected void btnViewPDF_Click(object sender, EventArgs e)
    {
        this.ShowReport(0);
    }

    protected void DrpLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadSalesForce();
        this.LoadDeliveryman();
    }

    protected void drpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadSalesForce();
    }

    private void LoadDeliveryman()
    {
        this.DrpDeliveryMan.Items.Clear();
        if (this.DrpLocation.Items.Count > 0)
        {
            DataTable table = new Distributor_UserController().SelectSaleForceAssignedArea(0x24, int.Parse(this.DrpLocation.SelectedValue.ToString()), -2147483648, int.Parse(this.Session["CompanyId"].ToString()));
            int num = -2147483648;
            this.DrpDeliveryMan.Items.Add(new ListItem("All", num.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpDeliveryMan, table, 0, 3);
        }
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
            this.drpPrincipal.DataSource = table;
            this.drpPrincipal.DataTextField = "Company_Name";
            this.drpPrincipal.DataValueField = "Company_Id";
            this.drpPrincipal.DataBind();
        }
        catch (Exception exception)
        {
            exception.ToString();
        }
    }

    protected void LoadSalesForce()
    {
        DataTable table = new Distributor_UserController().SelectSaleForceAssignedArea(0x23, int.Parse(this.DrpLocation.SelectedValue.ToString()), -2147483648, int.Parse(this.Session["CompanyId"].ToString()));
        if (table.Rows.Count > 0)
        {
            this.drpSaleForce.Items.Clear();
            this.drpSaleForce.Items.Add(new ListItem("All", "0"));
            clsWebFormUtil.FillDropDownList(this.drpSaleForce, table, "USER_ID", "USER_NAME");
        }
        else
        {
            this.drpSaleForce.Items.Clear();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadPrincipal();
            this.LoadLocation();
            this.LoadSalesForce();
            this.LoadDeliveryman();
            this.txtFromDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
            this.txtToDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
        }
    }

    private void ShowReport(int p_Report_Type)
    {
        try
        {
            DocumentPrintController controller = new DocumentPrintController();
            if (this.DrpReportType.SelectedIndex == 0)
            {
                DataTable table = new DocumentPrintController().SelectReportTitle(int.Parse(this.DrpLocation.SelectedValue.ToString()));
                string str = null;
                string str2 = null;
                DataSet dataSet = new DataSet();
                SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpBookingSupplyMonitoring monitoring = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpBookingSupplyMonitoring();
                DateTime time = DateTime.Parse(this.txtFromDate.Text);
                DateTime time2 = DateTime.Parse(this.txtToDate.Text);
                str = time.ToShortDateString();
                str2 = time2.ToShortDateString();
                dataSet = controller.BookingVsExecution(int.Parse(this.drpPrincipal.SelectedValue.ToString()), int.Parse(this.DrpLocation.SelectedValue.ToString()), int.Parse(this.drpSaleForce.SelectedValue.ToString()), Convert.ToInt32(this.DrpDeliveryMan.SelectedValue), Convert.ToDateTime(str + " 00:00:00"), Convert.ToDateTime(str2 + " 00:00:00"));
                monitoring.SetDataSource(dataSet);
                monitoring.Refresh();
                monitoring.SetParameterValue("Branch", this.DrpLocation.SelectedItem.Text.ToString());
                monitoring.SetParameterValue("Principal", this.drpPrincipal.SelectedItem.Text.ToString());
                monitoring.SetParameterValue("FromDate", this.txtFromDate.Text);
                monitoring.SetParameterValue("ToDate", this.txtToDate.Text);
                monitoring.SetParameterValue("OrderBooker", this.drpSaleForce.SelectedItem.Text.ToString());
                monitoring.SetParameterValue("DELIVERYMAN", this.DrpDeliveryMan.SelectedItem.Text);
                monitoring.SetParameterValue("CompanyName", table.Rows[0]["COMPANY_NAME"].ToString());
                this.Session.Add("CrpReport", monitoring);
                this.Session.Add("ReportType", p_Report_Type);
                string str3 = "'Default.aspx'";
                string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str3 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type type = base.GetType();
                this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
            }
            else
            {
                DataTable table2 = new DocumentPrintController().SelectReportTitle(int.Parse(this.DrpLocation.SelectedValue.ToString()));
                string str5 = null;
                string str6 = null;
                DataSet set2 = new DataSet();
                SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpBookingVsExecutionSKUWise wise = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpBookingVsExecutionSKUWise();
                DateTime time3 = DateTime.Parse(this.txtFromDate.Text);
                DateTime time4 = DateTime.Parse(this.txtToDate.Text);
                str5 = time3.ToShortDateString();
                str6 = time4.ToShortDateString();
                if (this.DrpReportType.SelectedIndex == 3)
                {
                    set2 = controller.SKUWiseBookingVsExecution(int.Parse(this.drpPrincipal.SelectedValue.ToString()), int.Parse(this.DrpLocation.SelectedValue.ToString()), int.Parse(this.drpSaleForce.SelectedValue.ToString()), Convert.ToInt32(this.DrpDeliveryMan.SelectedValue), Convert.ToDateTime(str5 + " 00:00:00"), Convert.ToDateTime(str6 + " 00:00:00"), -2147483648);
                }
                else
                {
                    set2 = controller.SKUWiseBookingVsExecution(int.Parse(this.drpPrincipal.SelectedValue.ToString()), int.Parse(this.DrpLocation.SelectedValue.ToString()), int.Parse(this.drpSaleForce.SelectedValue.ToString()), Convert.ToInt32(this.DrpDeliveryMan.SelectedValue), Convert.ToDateTime(str5 + " 00:00:00"), Convert.ToDateTime(str6 + " 00:00:00"), 0);
                }
                wise.SetDataSource(set2);
                wise.Refresh();
                wise.SetParameterValue("Branch", this.DrpLocation.SelectedItem.Text.ToString());
                wise.SetParameterValue("Principal", this.drpPrincipal.SelectedItem.Text.ToString());
                wise.SetParameterValue("FromDate", this.txtFromDate.Text);
                wise.SetParameterValue("ToDate", this.txtToDate.Text);
                wise.SetParameterValue("OrderBooker", this.drpSaleForce.SelectedItem.Text.ToString());
                wise.SetParameterValue("DELIVERYMAN", this.DrpDeliveryMan.SelectedItem.Text);
                wise.SetParameterValue("CompanyName", table2.Rows[0]["COMPANY_NAME"].ToString());
                if (this.DrpReportType.SelectedIndex == 1)
                {
                    wise.SetParameterValue("ReportTitle", "(Units)");
                }
                else if (this.DrpReportType.SelectedIndex == 2)
                {
                    wise.SetParameterValue("ReportTitle", "(Cartons)");
                }
                else if (this.DrpReportType.SelectedIndex == 3)
                {
                    wise.SetParameterValue("ReportTitle", "(Values)");
                }
                this.Session.Add("CrpReport", wise);
                this.Session.Add("ReportType", p_Report_Type);
                string str7 = "'Default.aspx'";
                string str8 = "<script language='JavaScript' type='text/javascript'> window.open(" + str7 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type type2 = base.GetType();
                this.Page.ClientScript.RegisterStartupScript(type2, "OpenWindow", str8);
            }
        }
        catch (Exception exception)
        {
            exception.ToString();
        }
    }
}