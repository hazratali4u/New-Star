using System;
using System.Data;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_RptVolumeSale : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            DocumentPrintController controller = new DocumentPrintController();
            string val = null;
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpVolumeSalesDetail detail = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpVolumeSalesDetail(); 
            DataSet dataSet = null;
            val = DateTime.Parse(this.txtDate.Text).ToShortDateString();
            dataSet = controller.SelectVolumeSale(int.Parse(this.drpPrincipal.SelectedValue.ToString()), int.Parse(this.DrpLocation.SelectedValue.ToString()), Convert.ToDateTime(val + " 00:00:00"), Convert.ToInt32(this.drpSaleForce.SelectedValue.ToString()));
            detail.SetDataSource(dataSet);
            detail.Refresh();
            detail.SetParameterValue("BranchName", this.DrpLocation.SelectedItem.Text.ToString());
            val = this.txtDate.Text;
            detail.SetParameterValue("Date", val);
            detail.SetParameterValue("TargetFor", this.drpSaleForce.SelectedItem.Text.ToString());
            this.Session.Add("CrpReport", detail);
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
            DocumentPrintController controller = new DocumentPrintController();
            string val = null;
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpVolumeSalesDetail detail = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpVolumeSalesDetail();
            DataSet dataSet = null;
            val = DateTime.Parse(this.txtDate.Text).ToShortDateString();
            dataSet = controller.SelectVolumeSale(int.Parse(this.drpPrincipal.SelectedValue.ToString()), int.Parse(this.DrpLocation.SelectedValue.ToString()), Convert.ToDateTime(val + " 00:00:00"), Convert.ToInt32(this.drpSaleForce.SelectedValue.ToString()));
            detail.SetDataSource(dataSet);
            detail.Refresh();
            detail.SetParameterValue("BranchName", this.DrpLocation.SelectedItem.Text.ToString());
            val = this.txtDate.Text;
            detail.SetParameterValue("Date", val);
            detail.SetParameterValue("TargetFor", this.drpSaleForce.SelectedItem.Text.ToString());
            this.Session.Add("CrpReport", detail);
            this.Session.Add("ReportType", 0);
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

    protected void DrpLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.drpSaleForce.Items.Clear();
        this.LoadSalesForce();
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
        DataTable table = new Distributor_UserController().SelectDistributorSalesForce(Convert.ToInt32(this.DrpLocation.SelectedValue.ToString()));
        if (table.Rows.Count > 0)
        {
            this.drpSaleForce.Items.Add(new ListItem("All", "0"));
            clsWebFormUtil.FillDropDownList(this.drpSaleForce, table, "USER_ID", "USER_NAME");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadPrincipal();
            this.LoadLocation();
            this.LoadSalesForce();
            this.txtDate.Text = ((DateTime)this.Session["CurrentWorkDate"]).ToString("dd-MMM-yyyy");
        }
    }
}