using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;

public partial class Forms_rptTransferIn : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.DrpReportType.SelectedIndex == 2)
            {
                DocumentPrintController controller = new DocumentPrintController();
                string val = null;
                string text = null;
                string str3 = null;
                SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpTransferInOutValues values = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpTransferInOutValues();
                DateTime time = DateTime.Parse(this.txtFromDate.Text);
                DateTime time2 = DateTime.Parse(this.txtToDate.Text);
                val = time.ToShortDateString();
                text = time2.ToShortDateString();
                DataSet dataSet = controller.TransferInOutValue(int.Parse(this.drpPrincipal.SelectedValue.ToString()), int.Parse(this.DrpLocation.SelectedValue.ToString()), Convert.ToDateTime(val + " 00:00:00"), Convert.ToDateTime(text + " 00:00:00"), this.RbTransferType.SelectedItem.Text, int.Parse(this.Session["UserId"].ToString()));
                values.SetDataSource(dataSet);
                values.Refresh();
                val = this.txtFromDate.Text;
                text = this.txtToDate.Text;
                if (this.RbTransferType.SelectedItem.Text == "Transfer In")
                {
                    str3 = "Branch Transfer In Report value wise";
                }
                else
                {
                    str3 = "Branch Transfer Out Report value wise";
                }
                values.SetParameterValue("FromDate", val);
                values.SetParameterValue("ToDate", text);
                values.SetParameterValue("Principal", this.drpPrincipal.SelectedItem.Text.ToString());
                values.SetParameterValue("TransferTo_FromHeader", str3);
                this.Session.Add("CrpReport", values);
                this.Session.Add("ReportType", 1);
                string str4 = "'Default.aspx'";
                string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str4 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type type = base.GetType();
                this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
            }
            else
            {
                DocumentPrintController controller2 = new DocumentPrintController();
                string str6 = null;
                string str7 = null;
                string str8 = null;
                string str9 = null;
                SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpTransferIn @in = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpTransferIn();
                DateTime time3 = DateTime.Parse(this.txtFromDate.Text);
                DateTime time4 = DateTime.Parse(this.txtToDate.Text);
                str6 = time3.ToShortDateString();
                str7 = time4.ToShortDateString();
                DataSet set2 = controller2.TransferIn(int.Parse(this.drpPrincipal.SelectedValue.ToString()), int.Parse(this.DrpLocation.SelectedValue.ToString()), Convert.ToDateTime(str6 + " 00:00:00"), Convert.ToDateTime(str7 + " 00:00:00"), this.RbTransferType.SelectedItem.Text, this.DrpReportType.SelectedIndex);
                @in.SetDataSource(set2);
                @in.Refresh();
                @in.SetParameterValue("BranchName", this.DrpLocation.SelectedItem.Text.ToString());
                str6 = this.txtFromDate.Text;
                str7 = this.txtToDate.Text;
                if (this.RbTransferType.SelectedItem.Text == "Transfer In")
                {
                    str8 = "Branch Transfer In Report";
                    str9 = "Transfer From";
                }
                else
                {
                    str8 = "Branch Transfer Out Report";
                    str9 = "Transfer To";
                }
                @in.SetParameterValue("FromDate", str6);
                @in.SetParameterValue("ToDate", str7);
                @in.SetParameterValue("TransferType", str8);
                @in.SetParameterValue("Principal", this.drpPrincipal.SelectedItem.Text.ToString());
                @in.SetParameterValue("TransferTo_FromHeader", str9);
                this.Session.Add("CrpReport", @in);
                this.Session.Add("ReportType", 1);
                string str10 = "'Default.aspx'";
                string str11 = "<script language='JavaScript' type='text/javascript'> window.open(" + str10 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type type2 = base.GetType();
                this.Page.ClientScript.RegisterStartupScript(type2, "OpenWindow", str11);
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
            if (this.DrpReportType.SelectedIndex == 2)
            {
                DocumentPrintController controller = new DocumentPrintController();
                string val = null;
                string text = null;
                string str3 = null;
                SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpTransferInOutValues values = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpTransferInOutValues();
                DateTime time = DateTime.Parse(this.txtFromDate.Text);
                DateTime time2 = DateTime.Parse(this.txtToDate.Text);
                val = time.ToShortDateString();
                text = time2.ToShortDateString();
                DataSet dataSet = controller.TransferInOutValue(int.Parse(this.drpPrincipal.SelectedValue.ToString()), int.Parse(this.DrpLocation.SelectedValue.ToString()), Convert.ToDateTime(val + " 00:00:00"), Convert.ToDateTime(text + " 00:00:00"), this.RbTransferType.SelectedItem.Text, int.Parse(this.Session["UserId"].ToString()));
                values.SetDataSource(dataSet);
                values.Refresh();
                val = this.txtFromDate.Text;
                text = this.txtToDate.Text;
                if (this.RbTransferType.SelectedItem.Text == "Transfer In")
                {
                    str3 = "Branch Transfer In Report value wise";
                }
                else
                {
                    str3 = "Branch Transfer Out Report value wise";
                }
                values.SetParameterValue("FromDate", val);
                values.SetParameterValue("ToDate", text);
                values.SetParameterValue("Principal", this.drpPrincipal.SelectedItem.Text.ToString());
                values.SetParameterValue("TransferTo_FromHeader", str3);
                this.Session.Add("CrpReport", values);
                this.Session.Add("ReportType", 0);
                string str4 = "'Default.aspx'";
                string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str4 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type type = base.GetType();
                this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
            }
            else
            {
                DocumentPrintController controller2 = new DocumentPrintController();
                string str6 = null;
                string str7 = null;
                string str8 = null;
                string str9 = null;
                SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpTransferIn @in = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpTransferIn();
                DateTime time3 = DateTime.Parse(this.txtFromDate.Text);
                DateTime time4 = DateTime.Parse(this.txtToDate.Text);
                str6 = time3.ToShortDateString();
                str7 = time4.ToShortDateString();
                DataSet set2 = controller2.TransferIn(int.Parse(this.drpPrincipal.SelectedValue.ToString()), int.Parse(this.DrpLocation.SelectedValue.ToString()), Convert.ToDateTime(str6 + " 00:00:00"), Convert.ToDateTime(str7 + " 00:00:00"), this.RbTransferType.SelectedItem.Text, this.DrpReportType.SelectedIndex);
                @in.SetDataSource(set2);
                @in.Refresh();
                @in.SetParameterValue("BranchName", this.DrpLocation.SelectedItem.Text.ToString());
                str6 = this.txtFromDate.Text;
                str7 = this.txtToDate.Text;
                if (this.RbTransferType.SelectedItem.Text == "Transfer In")
                {
                    str8 = "Branch Transfer In Report";
                    str9 = "Transfer From";
                }
                else
                {
                    str8 = "Branch Transfer Out Report";
                    str9 = "Transfer To";
                }
                @in.SetParameterValue("FromDate", str6);
                @in.SetParameterValue("ToDate", str7);
                @in.SetParameterValue("TransferType", str8);
                @in.SetParameterValue("Principal", this.drpPrincipal.SelectedItem.Text.ToString());
                @in.SetParameterValue("TransferTo_FromHeader", str9);
                this.Session.Add("CrpReport", @in);
                this.Session.Add("ReportType", 0);
                string str10 = "'Default.aspx'";
                string str11 = "<script language='JavaScript' type='text/javascript'> window.open(" + str10 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type type2 = base.GetType();
                this.Page.ClientScript.RegisterStartupScript(type2, "OpenWindow", str11);
            }
        }
        catch (Exception exception)
        {
            exception.ToString();
        }
    }

    protected void DrpReportType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadLocation();
    }

    protected void ImgToDate_Click(object sender, ImageClickEventArgs e)
    {
    }

    protected void LoadLocation()
    {
        this.DrpLocation.Items.Clear();
        if (this.DrpReportType.SelectedIndex == 2)
        {
            DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            int num = -2147483648;
            this.DrpLocation.Items.Add(new ListItem("All", num.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpLocation, table, 0, 2);
        }
        else
        {
            DataTable table2 = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpLocation, table2, 0, 2);
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadPrincipal();
            this.LoadLocation();
            this.txtFromDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
            this.txtToDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
        }
    }
}