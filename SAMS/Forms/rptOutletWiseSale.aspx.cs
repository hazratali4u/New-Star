using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;
using System;
using System.Data;

public partial class Forms_rptOutletWiseSale : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            DocumentPrintController controller = new DocumentPrintController();
            DateTime time = DateTime.Parse(this.txtFromDate.Text);
            DateTime time2 = DateTime.Parse(this.txtToDate.Text);
            string str = time.ToShortDateString();
            string str2 = time2.ToShortDateString();
            string str3 = null;
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpOutletwiseSale sale = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpOutletwiseSale();
            DataSet dataSet = null;
            for (int i = 0; i < this.ListCatagory.Items.Count; i++)
            {
                if (this.ListCatagory.Items[i].Selected)
                {
                    str3 = str3 + this.ListCatagory.Items[i].Value.ToString() + ",";
                }
            }
            dataSet = controller.OutletWiseSale(int.Parse(this.drpPrincipal.SelectedValue.ToString()), Convert.ToInt32(this.DrpLocation.SelectedValue.ToString()), Convert.ToDateTime(str + " 00:00:00"), Convert.ToDateTime(str2 + " 00:00:00"), str3);
            sale.SetDataSource(dataSet);
            sale.Refresh();
            sale.SetParameterValue("Principal", this.drpPrincipal.SelectedItem.Text.ToString());
            sale.SetParameterValue("Branch", this.DrpLocation.SelectedItem.Text.ToString());
            sale.SetParameterValue("FromDate", this.txtFromDate.Text);
            sale.SetParameterValue("ToDate", this.txtToDate.Text);
            this.Session.Add("CrpReport", sale);
            this.Session.Add("ReportType", 1);
            string str4 = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str4 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
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
            DateTime time = DateTime.Parse(this.txtFromDate.Text);
            DateTime time2 = DateTime.Parse(this.txtToDate.Text);
            string str = time.ToShortDateString();
            string str2 = time2.ToShortDateString();
            string str3 = null;
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpOutletwiseSale sale = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpOutletwiseSale();
            DataSet dataSet = null;
            for (int i = 0; i < this.ListCatagory.Items.Count; i++)
            {
                if (this.ListCatagory.Items[i].Selected)
                {
                    str3 = str3 + this.ListCatagory.Items[i].Value.ToString() + ",";
                }
            }
            dataSet = controller.OutletWiseSale(int.Parse(this.drpPrincipal.SelectedValue.ToString()), Convert.ToInt32(this.DrpLocation.SelectedValue.ToString()), Convert.ToDateTime(str + " 00:00:00"), Convert.ToDateTime(str2 + " 00:00:00"), str3);
            sale.SetDataSource(dataSet);
            sale.Refresh();
            sale.SetParameterValue("Principal", this.drpPrincipal.SelectedItem.Text.ToString());
            sale.SetParameterValue("Branch", this.DrpLocation.SelectedItem.Text.ToString());
            sale.SetParameterValue("FromDate", this.txtFromDate.Text);
            sale.SetParameterValue("ToDate", this.txtToDate.Text);
            this.Session.Add("CrpReport", sale);
            this.Session.Add("ReportType", 0);
            string str4 = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str4 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type type = base.GetType();
            this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
        }
        catch (Exception exception)
        {
            exception.ToString();
        }
    }

    protected void ChbAllLocationType_CheckedChanged(object sender, EventArgs e)
    {
        this.CheckAll();
    }

    protected void CheckAll()
    {
        if (this.ChbAllCatagories.Checked)
        {
            for (int i = 0; i < this.ListCatagory.Items.Count; i++)
            {
                this.ListCatagory.Items[i].Selected = true;
            }
        }
        else
        {
            for (int j = 0; j < this.ListCatagory.Items.Count; j++)
            {
                this.ListCatagory.Items[j].Selected = false;
            }
        }
    }

    protected void drpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ListCatagory.Items.Clear();
        this.LoadCatagory();
    }

    protected void LoadCatagory()
    {
        SkuHierarchyController controller = new SkuHierarchyController();
        DataTable table = new DataView(controller.SelectSkuHierarchyView(5, int.Parse(this.Session["CompanyId"].ToString()))) { RowFilter = "Company_id = " + Convert.ToInt32(this.drpPrincipal.SelectedValue.ToString()) }.ToTable();
        clsWebFormUtil.FillListBox(this.ListCatagory, table, 4, 6);
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
            this.LoadCatagory();
            this.LoadLocation();
            DateTime time = (DateTime)this.Session["CurrentWorkDate"];
            this.txtFromDate.Text = time.ToString("dd-MMM-yyyy");
            this.txtToDate.Text = time.ToString("dd-MMM-yyyy");
        }
    }
}