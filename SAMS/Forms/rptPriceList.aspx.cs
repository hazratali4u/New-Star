using System;
using System.Data;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;

public partial class Forms_rptPriceList : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            DocumentPrintController controller = new DocumentPrintController();
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPriceList list = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPriceList();
            DataSet dataSet = null;
            dataSet = controller.PriceList(int.Parse(this.drpPrincipal.SelectedValue.ToString()), int.Parse(this.DrpCatagory.SelectedValue.ToString()), int.Parse(this.DrpDistributor.SelectedValue.ToString()));
            list.SetDataSource(dataSet);
            list.Refresh();
            list.SetParameterValue("Principal", this.drpPrincipal.SelectedItem.Text.ToString());
            list.SetParameterValue("Branch", this.DrpDistributor.SelectedItem.Text.ToString());
            this.Session.Add("CrpReport", list);
            this.Session.Add("ReportType", 1);
            string str = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
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
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPriceList list = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpPriceList();
            DataSet dataSet = null;
            dataSet = controller.PriceList(int.Parse(this.drpPrincipal.SelectedValue.ToString()), int.Parse(this.DrpCatagory.SelectedValue.ToString()), int.Parse(this.DrpDistributor.SelectedValue.ToString()));
            list.SetDataSource(dataSet);
            list.Refresh();
            list.SetParameterValue("Principal", this.drpPrincipal.SelectedItem.Text.ToString());
            list.SetParameterValue("Branch", this.DrpDistributor.SelectedItem.Text.ToString());
            this.Session.Add("CrpReport", list);
            this.Session.Add("ReportType", 0);
            string str = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type type = base.GetType();
            this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
        }
        catch (Exception exception)
        {
            exception.ToString();
        }
    }

    protected void drpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.DrpCatagory.Items.Clear();
        this.LoadCatagory();
    }

    protected void LoadCatagory()
    {
        SkuHierarchyController controller = new SkuHierarchyController();
        DataTable table = new DataView(controller.SelectSkuHierarchyView(5, int.Parse(this.Session["CompanyId"].ToString()))) { RowFilter = "Company_id = " + Convert.ToInt32(this.drpPrincipal.SelectedValue.ToString()) }.ToTable();
        int num = -2147483648;
        this.DrpCatagory.Items.Add(new ListItem("All", num.ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpCatagory, table, "Category_Id", "Category_Name");
    }

    private void LoadDistributor()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpDistributor, table, 0, 2, true);
    }

    protected void LoadPrincipal()
    {
        try
        {
            DataTable table = new SKUPriceDetailController().SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
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
            this.LoadDistributor();
            this.LoadPrincipal();
            this.LoadCatagory();
        }
    }
}