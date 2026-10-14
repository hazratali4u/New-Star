using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;
using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

public partial class Forms_RptCustomerInvoiceReport : System.Web.UI.Page
{
    protected void btnViewExcel_Click(object sender, EventArgs e)
    {
        DataSet set;
        string str = "0";
        string str2 = "0";
        foreach (GridViewRow row in this.Grid_users.Rows)
        {
            CheckBox box = (CheckBox)row.Cells[0].FindControl("ChbCustomer");
            if (box.Checked)
            {
                str = str + "," + row.Cells[1].Text;
                str2 = str2 + "," + row.Cells[2].Text;
            }
        }
        new DataSetToExcel();
        DocumentPrintController controller = new DocumentPrintController();
        if (this.RblCustomer.SelectedIndex == 0)
        {
            set = controller.SelectBillCustomerDetail(int.Parse(this.DrpPrincipal.SelectedValue.ToString()), str, this.drpDistributor.SelectedValue.ToString(), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), 0);
        }
        else
        {
            set = controller.SelectBillCustomerDetail(int.Parse(this.DrpPrincipal.SelectedValue.ToString()), str, str2, DateTime.Parse(this.txtStartDate.Text), DateTime.Parse(this.txtEndDate.Text), 1);
        }
        string fileName = Configuration.GetAppInstallationPath() + @"\CustomerBillWiseSale.xls";
        DataSetToExcel.exportToExcel(set, fileName, "RptBillCustomerReport");
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

    protected void BtnViewPdf_Click(object sender, EventArgs e)
    {
        string str = "0";
        string str2 = "0";
        if (this.RblCustomer.SelectedIndex == 0)
        {
            DataSet dataSet = new DocumentPrintController().SelectBillCustomerDetail(int.Parse(this.DrpPrincipal.SelectedValue.ToString()), str, this.drpDistributor.SelectedValue.ToString(), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), 0);
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpBillCustomerWiseReport report = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpBillCustomerWiseReport();
            report.SetDataSource(dataSet);
            report.Refresh();
            report.SetParameterValue("PRINCIPAL", this.DrpPrincipal.SelectedItem.Text);
            report.SetParameterValue("FROM_DATE", this.txtStartDate.Text);
            report.SetParameterValue("TO_DATE", this.txtEndDate.Text);
            this.Session.Add("CrpReport", report);
            this.Session.Add("ReportType", 0);
            string str3 = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str3 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type type = base.GetType();
            this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
        }
        else
        {
            foreach (GridViewRow row in this.Grid_users.Rows)
            {
                CheckBox box = (CheckBox)row.Cells[0].FindControl("ChbCustomer");
                if (box.Checked)
                {
                    str = str + "," + row.Cells[1].Text;
                    str2 = str2 + "," + row.Cells[2].Text;
                }
            }
            DataSet set2 = new DocumentPrintController().SelectBillCustomerDetail(int.Parse(this.DrpPrincipal.SelectedValue.ToString()), str, str2, DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"), 1);
            SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpBillCustomerWiseReport report2 = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportsCrpBillCustomerWiseReport();
            report2.SetDataSource(set2);
            report2.Refresh();
            report2.SetParameterValue("PRINCIPAL", this.DrpPrincipal.SelectedItem.Text);
            report2.SetParameterValue("FROM_DATE", this.txtStartDate.Text);
            report2.SetParameterValue("TO_DATE", this.txtEndDate.Text);
            this.Session.Add("CrpReport", report2);
            this.Session.Add("ReportType", 0);
            string str5 = "'Default.aspx'";
            string str6 = "<script language='JavaScript' type='text/javascript'> window.open(" + str5 + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type type2 = base.GetType();
            this.Page.ClientScript.RegisterStartupScript(type2, "OpenWindow", str6);
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        DataTable table = new CustomerDataController().RptSelectCustomer(int.Parse(this.Session["UserId"].ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), this.ddSearchType.SelectedValue.ToString(), this.txtSeach.Text);
        this.Grid_users.DataSource = table;
        this.Grid_users.DataBind();
    }

    private void LoadDistributor()
    {
        this.drpDistributor.Items.Clear();
        if (this.RblCustomer.SelectedIndex == 1)
        {
            DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            this.drpDistributor.Items.Add(new ListItem("All", "0"));
            clsWebFormUtil.FillDropDownList(this.drpDistributor, table, 0, 2);
        }
        else
        {
            DataTable table2 = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.drpDistributor, table2, 0, 2);
        }
    }

    private void LoadPrincipal()
    {
        DataTable table = new SKUPriceDetailController().SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, table, 0, 1);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadPrincipal();
            this.LoadDistributor();
            this.txtStartDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
            this.txtEndDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
        }
    }

    protected void RblCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadDistributor();
    }
}