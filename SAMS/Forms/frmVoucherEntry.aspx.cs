using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmVoucherEntry : System.Web.UI.Page
{
    private DataTable dtVoucher;
    private static int RowId = -1;
    
    protected void btnDone_Click(object sender, EventArgs e)
    {
        LedgerController controller = new LedgerController();
        new DataControl();
        this.dtVoucher = (DataTable)this.Session["dtVoucher"];
        DataTable table = (DataTable)this.Session["dtHead"];
        decimal num = 0M;
        decimal num2 = 0M;
        foreach (DataRow row in this.dtVoucher.Rows)
        {
            num += decimal.Parse(row["DEBIT"].ToString());
            num2 += decimal.Parse(row["CREDIT"].ToString());
        }
        if (num != num2)
        {
            if (this.drpBanks.SelectedItem.Text == "N/A")
            {
                ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert('Wrong Entry');", true);
                return;
            }
            decimal num3 = num - num2;
            if (num3 > 0M)
            {
                DataRow row2 = this.dtVoucher.NewRow();
                DataRow[] rowArray = table.Select("ACCOUNT_HEAD_ID  = " + this.drpBanks.SelectedValue.ToString());
                row2["Ledger_ID"] = Constants.LongNullValue.ToString();
                row2["ACCOUNT_HEAD_ID"] = rowArray[0]["ACCOUNT_HEAD_ID"];
                row2["ACCOUNT_CODE"] = rowArray[0]["ACCOUNT_CODE"];
                row2["ACCOUNT_NAME"] = rowArray[0]["ACCOUNT_NAME"];
                row2["REMARKS"] = this.txtAccountDes.Text;
                row2["CREDIT"] = num3;
                row2["DEBIT"] = 0;
                this.dtVoucher.Rows.Add(row2);
            }
            else if (num3 < 0M)
            {
                DataRow row3 = this.dtVoucher.NewRow();
                DataRow[] rowArray2 = table.Select("ACCOUNT_HEAD_ID  = " + this.drpBanks.SelectedValue.ToString());
                row3["Ledger_ID"] = Constants.LongNullValue.ToString();
                row3["ACCOUNT_HEAD_ID"] = rowArray2[0]["ACCOUNT_HEAD_ID"];
                row3["ACCOUNT_CODE"] = rowArray2[0]["ACCOUNT_CODE"];
                row3["ACCOUNT_NAME"] = rowArray2[0]["ACCOUNT_NAME"];
                row3["REMARKS"] = this.txtAccountDes.Text;
                row3["CREDIT"] = 0;
                row3["DEBIT"] = -num3;
                this.dtVoucher.Rows.Add(row3);
            }
        }
        if (this.txtVoucherDate.Text.Length < 10)
        {
            ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert('Must Enter Voucher Date');", true);
        }
        else
        {
            DateTime dateNullValue;
            DateTime time2 = DateTime.Parse(ConvertDate.British_To_American(this.txtVoucherDate.Text));
            if (this.txtChequeDate.Text.Length == 10)
            {
                dateNullValue = DateTime.Parse(ConvertDate.British_To_American(this.txtChequeDate.Text));
            }
            else
            {
                dateNullValue = Constants.DateNullValue;
            }
            this.dtVoucher = (DataTable)this.Session["dtVoucher"];
            string str = controller.SelectMaxVoucherId(int.Parse(this.DrpVoucherType.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), time2);
            if (controller.Add_Voucher(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), str, int.Parse(this.DrpVoucherType.SelectedValue.ToString()), time2, int.Parse(this.DrpPaymentMode.SelectedValue.ToString()), this.txtpayeesName.Text, this.txtRemarks.Text, dateNullValue, this.txtChequeNo.Text, this.dtVoucher, int.Parse(this.Session["UserId"].ToString())))
            {
                ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert('Voucher No : " + str + " has been Saved');", true);
                this.ClearAll();
            }
            else
            {
                ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert('Some error occur contact System Administrator');", true);
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        decimal d = 0M;
        decimal num2 = 0M;
        DataControl control = new DataControl();
        DataTable table = (DataTable)this.Session["dtHead"];
        this.dtVoucher = (DataTable)this.Session["dtVoucher"];
        DataRow[] rowArray = table.Select("ACCOUNT_CODE  = '" + this.txtAccountCode.Text + "'");
        if (rowArray.Length > 0)
        {
            if (RowId >= 0)
            {
                DataRow row = this.dtVoucher.Rows[RowId];
                row["ACCOUNT_HEAD_ID"] = rowArray[0]["ACCOUNT_HEAD_ID"];
                row["ACCOUNT_CODE"] = rowArray[0]["ACCOUNT_CODE"];
                row["ACCOUNT_NAME"] = rowArray[0]["ACCOUNT_NAME"];
                row["DEBIT"] = decimal.Parse(control.chkNull_0(this.txtDebitAmount.Text));
                row["CREDIT"] = decimal.Parse(control.chkNull_0(this.txtCreditAmount.Text));
                row["REMARKS"] = this.txtAccountDes.Text;
            }
            else
            {
                DataRow row2 = this.dtVoucher.NewRow();
                row2["Ledger_ID"] = Constants.LongNullValue.ToString();
                row2["ACCOUNT_HEAD_ID"] = rowArray[0]["ACCOUNT_HEAD_ID"];
                row2["ACCOUNT_CODE"] = rowArray[0]["ACCOUNT_CODE"];
                row2["ACCOUNT_NAME"] = rowArray[0]["ACCOUNT_NAME"];
                row2["DEBIT"] = decimal.Parse(control.chkNull_0(this.txtDebitAmount.Text));
                row2["CREDIT"] = decimal.Parse(control.chkNull_0(this.txtCreditAmount.Text));
                row2["REMARKS"] = this.txtAccountDes.Text;
                this.dtVoucher.Rows.Add(row2);
            }
        }
        foreach (DataRow row3 in this.dtVoucher.Rows)
        {
            d += decimal.Parse(row3["DEBIT"].ToString());
            num2 += decimal.Parse(row3["CREDIT"].ToString());
        }
        this.txtTotalDebit.Text = decimal.Round(d, 0).ToString();
        this.txtTotalCredit.Text = decimal.Round(num2, 0).ToString();
        this.txtAccountCode.Text = "";
        this.txtAccountName.Text = "";
        this.txtDebitAmount.Text = "";
        this.txtCreditAmount.Text = "";
        RowId = -1;
        this.GrdOrder.DataSource = this.dtVoucher;
        this.GrdOrder.DataBind();
        this.Session.Add("dtVoucher", this.dtVoucher);
        ScriptManager.GetCurrent(this.Page).SetFocus(this.txtAccountCode);
    }

    private void ClearAll()
    {
        this.txtTotalCredit.Text = "0";
        this.txtTotalDebit.Text = "0";
        this.txtAccountCode.Text = "";
        this.txtAccountName.Text = "";
        this.txtRemarks.Text = "";
        this.txtChequeDate.Text = "";
        this.txtChequeNo.Text = "";
        this.txtDebitAmount.Text = "";
        this.txtCreditAmount.Text = "";
        this.txtAccountDes.Text = "";
        this.GrdOrder.DataSource = null;
        this.GrdOrder.DataBind();
        this.Session.Remove("dtVoucher");
        this.CreatTable();
        this.txtpayeesName.Text = "";
        this.drpDistributor.Enabled = true;
        this.DrpVoucherType.Enabled = true;
    }

    private void CreatTable()
    {
        this.dtVoucher = new DataTable();
        this.dtVoucher.Columns.Add("LEDGER_ID", typeof(long));
        this.dtVoucher.Columns.Add("Account_Head_Id", typeof(long));
        this.dtVoucher.Columns.Add("Account_Code", typeof(string));
        this.dtVoucher.Columns.Add("Account_Name", typeof(string));
        this.dtVoucher.Columns.Add("Debit", typeof(decimal));
        this.dtVoucher.Columns.Add("Credit", typeof(decimal));
        this.dtVoucher.Columns.Add("Remarks", typeof(string));
        this.dtVoucher.Columns.Add("InvoiceNo", typeof(string));
        this.Session.Add("dtVoucher", this.dtVoucher);
    }

    protected void DrpVoucherType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.DrpVoucherType.SelectedIndex == 2)
        {
            this.lblChequeNo.Text = "Invoice No";
            this.lblChequedate.Text = "Invoice Date";
        }
        else
        {
            this.lblChequeNo.Text = "Cheque No";
            this.lblChequedate.Text = "Cheque Date";
        }
        this.ClearAll();
        this.LoadAccountHead();
    }

    protected void GrdOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[3].Text = this.txtTotalDebit.Text;
            e.Row.Cells[4].Text = this.txtTotalCredit.Text;
        }
    }

    protected void GrdOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        decimal num = 0M;
        decimal num2 = new decimal(0);
        this.dtVoucher = (DataTable)this.Session["dtVoucher"];
        this.dtVoucher.Rows.RemoveAt(e.RowIndex);
        foreach (DataRow row in this.dtVoucher.Rows)
        {
            num += decimal.Parse(row["DEBIT"].ToString());
            num2 += decimal.Parse(row["CREDIT"].ToString());
        }
        this.txtTotalDebit.Text = num.ToString();
        this.txtTotalCredit.Text = num2.ToString();
        this.GrdOrder.DataSource = this.dtVoucher;
        this.GrdOrder.DataBind();
        RowId = -1;
    }

    protected void GrdOrder_RowEditing(object sender, GridViewEditEventArgs e)
    {
        RowId = e.NewEditIndex;
        this.txtAccountCode.Text = this.GrdOrder.Rows[e.NewEditIndex].Cells[1].Text;
        this.txtAccountDes.Text = this.GrdOrder.Rows[e.NewEditIndex].Cells[2].Text;
        this.txtAccountName.Text = this.GrdOrder.Rows[e.NewEditIndex].Cells[5].Text;
        this.txtDebitAmount.Text = this.GrdOrder.Rows[e.NewEditIndex].Cells[3].Text;
        this.txtCreditAmount.Text = this.GrdOrder.Rows[e.NewEditIndex].Cells[4].Text;
    }

    private void LoadAccountDetail()
    {
        DataTable table = new AccountHeadController().SelectAccountHead(0x5e, -9223372036854775808L);
        clsWebFormUtil.FillListBox(this.LstAccountHead, table, "ACCOUNT_HEAD", "ACCOUNT_HEAD", true);
        this.Session.Add("dtHead", table);
    }

    private void LoadAccountHead()
    {
        Configuration.GetAccountHead();
        if (this.DrpVoucherType.SelectedIndex == 0)
        {
            DataTable table = new AccountHeadController().SelectAccountHead(0x5e, long.Parse(Configuration.CashDefaultType));
            clsWebFormUtil.FillDropDownList(this.drpBanks, table, 0, 4, true);
        }
        else if (this.DrpVoucherType.SelectedIndex == 1)
        {
            DataTable table2 = new AccountHeadController().SelectAccountHead(0x5e, long.Parse(Configuration.BankDefaultType));
            clsWebFormUtil.FillDropDownList(this.drpBanks, table2, 0, 4, true);
        }
        else
        {
            this.drpBanks.Items.Clear();
            int num = -2147483648;
            this.drpBanks.Items.Add(new ListItem("N/A", num.ToString()));
        }
    }

    private void LoadDistributor()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, table, 0, 2, true);
    }

    private void LoadPrincipal()
    {
        DataTable table = new SKUPriceDetailController().SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        this.DrpPrincipal.Items.Add(new ListItem("General Entry", "0"));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, table, 0, 1);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadAccountDetail();
            this.LoadPrincipal();
            this.CreatTable();
            this.LoadAccountHead();
            this.txtVoucherDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.btnSave.Attributes.Add("onclick", "return ValidateForm();");
            RowId = -1;
        }
    }
}