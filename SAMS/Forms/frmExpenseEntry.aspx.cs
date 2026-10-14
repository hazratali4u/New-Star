using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmExpenseEntry : System.Web.UI.Page
{    
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        DataControl control = new DataControl();
        DataTable table = (DataTable)this.Session["dtVoucher"];
        if (this.lblRowId.Text == "-1")
        {
            DataRow row = table.NewRow();
            row["ACCOUNT_HEAD_ID"] = this.DrpAccountHead.SelectedValue.ToString();
            row["ACCOUNT_NAME"] = this.DrpAccountHead.SelectedItem.Text;
            row["DEBIT"] = decimal.Parse(control.chkNull_0(this.txtAmount.Text));
            row["Credit"] = "0";
            row["REMARKS"] = this.txtRemarks.Text;
            table.Rows.Add(row);
        }
        else
        {
            DataRow row2 = table.Rows[int.Parse(this.lblRowId.Text)];
            row2["ACCOUNT_HEAD_ID"] = this.DrpAccountHead.SelectedValue.ToString();
            row2["ACCOUNT_NAME"] = this.DrpAccountHead.SelectedItem.Text;
            row2["DEBIT"] = decimal.Parse(control.chkNull_0(this.txtAmount.Text));
            row2["Credit"] = "0";
            row2["REMARKS"] = this.txtRemarks.Text;
        }
        this.GrdOrder.DataSource = table;
        this.GrdOrder.DataBind();
        this.txtAmount.Text = "";
        this.txtRemarks.Text = "";
        this.lblRowId.Text = "-1";
        ScriptManager.GetCurrent(this.Page).SetFocus(this.DrpAccountHead);
        decimal num = 0M;
        foreach (DataRow row3 in table.Rows)
        {
            num += decimal.Parse(row3["DEBIT"].ToString());
        }
        this.txtMainCash.Text = num.ToString();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        LedgerController controller = new LedgerController();
        Configuration.GetAccountHead();
        DataControl control = new DataControl();
        DataTable table = (DataTable)this.Session["dtVoucher"];
        if (table.Rows.Count > 0)
        {
            bool flag;
            string str;
            DataRow row = table.NewRow();
            row["ACCOUNT_HEAD_ID"] = Configuration.PeatyCash;
            row["ACCOUNT_NAME"] = "Peatty Cash";
            row["DEBIT"] = 0;
            row["Credit"] = decimal.Parse(control.chkNull_0(this.txtMainCash.Text));
            row["REMARKS"] = "Patty Cash Credit";
            table.Rows.Add(row);
            if (this.DrpVoucherNo.SelectedValue.ToString() == "0")
            {
                str = controller.SelectMaxVoucherId(0x10, int.Parse(this.drpDistributor.SelectedValue.ToString()), (DateTime)this.Session["CurrentWorkDate"]);
                flag = controller.Add_Voucher(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), str, 0x10, (DateTime)this.Session["CurrentWorkDate"], 0x1b, null, "Petty Voucher", Constants.DateNullValue, null, table, int.Parse(this.Session["UserId"].ToString()));
            }
            else
            {
                str = this.DrpVoucherNo.SelectedValue.ToString();
                flag = controller.Add_Voucher(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), str, 0x10, (DateTime)this.Session["CurrentWorkDate"], 0x1b, null, "Petty Voucher", Constants.DateNullValue, null, table, int.Parse(this.Session["UserId"].ToString()));
            }
            if (flag)
            {
                table.Rows.Clear();
                this.GrdOrder.DataSource = null;
                this.GrdOrder.DataBind();
                this.txtAmount.Text = "";
                this.txtRemarks.Text = "";
                this.lblRowId.Text = "-1";
                ScriptManager.GetCurrent(this.Page).SetFocus(this.DrpAccountHead);
                decimal num = 0M;
                foreach (DataRow row2 in table.Rows)
                {
                    num += decimal.Parse(row2["DEBIT"].ToString());
                }
                this.txtMainCash.Text = num.ToString();
                this.LoadVoucherNo();
            }
            else
            {
                ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert('Some Error in Voucher')", true);
            }
        }
    }

    private void CreatTable()
    {
        DataTable table = new DataTable();
        table.Columns.Add("Account_Head_Id", typeof(long));
        table.Columns.Add("Account_Code", typeof(string));
        table.Columns.Add("Account_Name", typeof(string));
        table.Columns.Add("Debit", typeof(decimal));
        table.Columns.Add("Credit", typeof(decimal));
        table.Columns.Add("Remarks", typeof(string));
        this.Session.Add("dtVoucher", table);
    }

    protected void DrpMasterHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadAccountHead();
    }

    protected void DrpVoucherNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        LedgerController controller = new LedgerController();
        DataTable table = (DataTable)this.Session["dtVoucher"];
        if (this.DrpVoucherNo.SelectedValue.ToString() != "0")
        {
            table = controller.SelectVoucherDetail(int.Parse(this.drpDistributor.SelectedValue.ToString()), this.DrpVoucherNo.SelectedValue.ToString(), 0x10);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (decimal.Parse(table.Rows[i]["CREDIT"].ToString()) > 0M)
                {
                    table.Rows.RemoveAt(i);
                }
            }
            this.Session.Add("dtVoucher", table);
            this.GrdOrder.DataSource = table;
            this.GrdOrder.DataBind();
        }
        else
        {
            table.Rows.Clear();
            this.GrdOrder.DataSource = null;
            this.GrdOrder.DataBind();
        }
        this.lblRowId.Text = "0";
        this.Session.Add("dtVoucher", table);
    }

    protected void GrdOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable table = (DataTable)this.Session["dtVoucher"];
        table.Rows.RemoveAt(e.RowIndex);
        this.GrdOrder.DataSource = table;
        this.GrdOrder.DataBind();
        this.lblRowId.Text = "-1";
        decimal num = 0M;
        foreach (DataRow row in table.Rows)
        {
            num += decimal.Parse(row["DEBIT"].ToString());
        }
        this.txtMainCash.Text = num.ToString();
    }

    protected void GrdOrder_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.lblRowId.Text = e.NewEditIndex.ToString();
        this.DrpAccountHead.SelectedValue = this.GrdOrder.Rows[e.NewEditIndex].Cells[0].Text;
        this.txtRemarks.Text = this.GrdOrder.Rows[e.NewEditIndex].Cells[2].Text;
        this.txtAmount.Text = this.GrdOrder.Rows[e.NewEditIndex].Cells[3].Text;
    }

    private void LoadAccountHead()
    {
        if (this.DrpMasterHead.Items.Count > 0)
        {
            DataTable table = new AccountHeadController().SelectAccountHead(0x5e, long.Parse(this.DrpMasterHead.SelectedValue.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpAccountHead, table, 0, 4, true);
        }
    }

    private void LoadAccountParent()
    {
        Configuration.GetAccountHead();
        DataTable table = new AccountHeadController().SelectAccountHead(0x5d, long.Parse(Configuration.ExpensDefaultType));
        clsWebFormUtil.FillDropDownList(this.DrpMasterHead, table, 0, 4, true);
    }

    private void LoadDistributor()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, table, 0, 2, true);
    }

    private void LoadPrincipal()
    {
        DataTable table = new SKUPriceDetailController().SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        this.DrpPrincipal.Items.Add(new ListItem("General Expense", "0"));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, table, 0, 1);
    }

    private void LoadVoucherNo()
    {
        DataTable table = new LedgerController().SelectVoucherNo((DateTime)this.Session["CurrentWorkDate"], int.Parse(this.drpDistributor.SelectedValue.ToString()), 0x10, int.Parse(this.Session["UserId"].ToString()), null);
        this.DrpVoucherNo.Items.Clear();
        this.DrpVoucherNo.Items.Add(new ListItem("New", "0"));
        clsWebFormUtil.FillDropDownList(this.DrpVoucherNo, table, 3, 3);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadAccountParent();
            this.LoadAccountHead();
            this.LoadPrincipal();
            this.CreatTable();
            this.LoadVoucherNo();
            this.btnAddNew.Attributes.Add("onclick", "return ValidateForm();");
            ScriptManager.GetCurrent(this.Page).SetFocus(this.drpDistributor);
            this.lblRowId.Text = "-1";
        }
    }
}