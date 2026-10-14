using System;
using System.Data;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;

public partial class Forms_frmLedgerViewData : System.Web.UI.Page
{    
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        LedgerController controller = new LedgerController();
        foreach (GridViewRow row in this.GrdLedger.Rows)
        {
            CheckBox box = (CheckBox)row.Cells[0].FindControl("ChbSelect");
            if (box.Checked)
            {
                controller.PostSelectVoucher(int.Parse(this.drpDistributor.SelectedValue.ToString()), row.Cells[1].Text, int.Parse(row.Cells[4].Text), 1, DateTime.Parse(row.Cells[5].Text));
            }
        }
        DataTable table = controller.SelectUnPostVoucherNo(int.Parse(this.DrpVoucherType.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), bool.Parse(this.RbdList.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"));
        this.GrdLedger.DataSource = table;
        this.GrdLedger.DataBind();
    }

    protected void btnPost_Click(object sender, EventArgs e)
    {
        LedgerController controller = new LedgerController();
        foreach (GridViewRow row in this.GrdLedger.Rows)
        {
            CheckBox box = (CheckBox)row.Cells[0].FindControl("ChbSelect");
            if (box.Checked)
            {
                controller.PostSelectVoucher(int.Parse(this.drpDistributor.SelectedValue.ToString()), row.Cells[1].Text, int.Parse(row.Cells[4].Text), 0, DateTime.Parse(row.Cells[5].Text));
            }
        }
        DataTable table = controller.SelectUnPostVoucherNo(int.Parse(this.DrpVoucherType.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), bool.Parse(this.RbdList.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"));
        this.GrdLedger.DataSource = table;
        this.GrdLedger.DataBind();
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        DataTable table = new LedgerController().SelectUnPostVoucherNo(int.Parse(this.DrpVoucherType.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), bool.Parse(this.RbdList.SelectedValue.ToString()), DateTime.Parse(this.txtStartDate.Text + " 00:00:00"), DateTime.Parse(this.txtEndDate.Text + " 23:59:59"));
        this.GrdLedger.DataSource = table;
        this.GrdLedger.DataBind();
    }

    protected void ChbSelect_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in this.GrdLedger.Rows)
        {
            CheckBox box = (CheckBox)row.Cells[0].FindControl("ChbSelect");
            box.Checked = true;
        }
    }

    protected void GrdLedger_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        this.Session.Add("VoucherNo", this.GrdLedger.Rows[e.RowIndex].Cells[1].Text);
        this.Session.Add("DistributorId", this.drpDistributor.SelectedValue.ToString());
        this.Session.Add("VoucherTypeId", this.DrpVoucherType.SelectedValue.ToString());
        base.Response.Redirect("~/Forms/frmVoucherEditing.aspx?Status=" + false);
    }

    protected void GrdLedger_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DocumentPrintController controller = new DocumentPrintController();
        SAMSBusinessLayer.Reports.SAMSBusinessLayerReportscrpVoucherView view = new SAMSBusinessLayer.Reports.SAMSBusinessLayerReportscrpVoucherView();
        DataSet dataSet = null;
        DataTable table = controller.SelectReportTitle(int.Parse(this.drpDistributor.SelectedValue.ToString()));
        dataSet = controller.SelectUnpostVoucherForPrint(int.Parse(this.drpDistributor.SelectedValue.ToString()), this.GrdLedger.Rows[e.NewEditIndex].Cells[1].Text, int.Parse(this.DrpVoucherType.SelectedValue.ToString()));
        view.SetDataSource(dataSet);
        view.Refresh();
        view.SetParameterValue("Company_Name", table.Rows[0]["COMPANY_NAME"].ToString());
        view.SetParameterValue("DISTRIBUTOR_NAME", table.Rows[0]["DISTRIBUTOR_NAME"].ToString());
        this.Session.Add("CrpReport", view);
        this.Session.Add("ReportType", 0);
        string str = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + str + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type type = base.GetType();
        this.Page.ClientScript.RegisterStartupScript(type, "OpenWindow", script);
    }

    private void LoadDistributor()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, table, 0, 2, true);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadDistributor();
            this.btnView.Attributes.Add("onclick", "return ValidateForm();");
            Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            this.txtStartDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            this.txtEndDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }

    protected void RbdList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.RbdList.SelectedIndex == 1)
        {
            this.btnDelete.Enabled = false;
            this.btnPost.Enabled = false;
        }
        else
        {
            this.btnDelete.Enabled = true;
            this.btnPost.Enabled = true;
        }
    }
}