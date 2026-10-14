using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmCustomerRelization : System.Web.UI.Page
{    
    private void AdvanceReturn()
    {
        LedgerController controller = new LedgerController();
        new CustomerDataController();
        string s = controller.SelectLedgerMaxDocumentId(14, int.Parse(this.drpDistributor.SelectedValue.ToString()));
        controller.PostingCash_Bank_Account(14, long.Parse(s), long.Parse(Configuration.AccountReceivable), int.Parse(this.drpDistributor.SelectedValue.ToString()), decimal.Parse(this.txtAmount.Text), 0M, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), this.txtRemarks.Text, DateTime.Now, int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), this.txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), -9223372036854775808L, -2147483648, this.txtSlipNo.Text, Constants.DateNullValue, 0x1d, "");
        controller.PostingCash_Bank_Account(14, long.Parse(s), long.Parse(this.DrpAccountDetail.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), 0M, decimal.Parse(this.txtAmount.Text), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), this.txtRemarks.Text, DateTime.Now, int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), this.txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), -9223372036854775808L, -2147483648, this.txtSlipNo.Text, Constants.DateNullValue, 0x1d, "");
    }

    private void BankDeposit()
    {
        LedgerController controller = new LedgerController();
        string s = controller.SelectLedgerMaxDocumentId(15, int.Parse(this.drpDistributor.SelectedValue.ToString()));
        controller.PostingCash_Bank_Account(15, long.Parse(s), long.Parse(Configuration.CashDefault), int.Parse(this.drpDistributor.SelectedValue.ToString()), 0M, decimal.Parse(this.txtAmount.Text), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), this.txtRemarks.Text, DateTime.Now, -2147483648, int.Parse(this.DrpPrincipal.SelectedValue.ToString()), this.txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), -9223372036854775808L, -2147483648, this.txtSlipNo.Text, Constants.DateNullValue, 0x16, "");
        controller.PostingCash_Bank_Account(15, long.Parse(s), long.Parse(this.DrpAccountDetail.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), decimal.Parse(this.txtAmount.Text), 0M, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), this.txtRemarks.Text, DateTime.Now, -2147483648, int.Parse(this.DrpPrincipal.SelectedValue.ToString()), this.txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), -9223372036854775808L, -2147483648, this.txtSlipNo.Text, Constants.DateNullValue, 0x16, "");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.DrpAccountType.SelectedIndex != 0)
        {
            if (this.DrpAccountType.SelectedIndex == 1)
            {
                this.BankDeposit();
            }
            else
            {
                this.IncomeTax();
                this.SelectCreditInvoice();
            }
        }
        else
        {
            int num = -2147483648;
            foreach (GridViewRow row in this.GrdCredit.Rows)
            {
                CheckBox box = (CheckBox)row.Cells[0].FindControl("ChbIsAssigned");
                if (box.Checked)
                {
                    num++;
                    break;
                }
            }
            if (num == -2147483648)
            {
                ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert('Must Select Invoice');", true);
                return;
            }
            this.CashRealization();
            this.SelectCreditInvoice();
        }
        this.ClearAll();
        this.LoadGrid();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
    }

    private void CashAdvance()
    {
        LedgerController controller = new LedgerController();
        new CustomerDataController();
        string s = controller.SelectLedgerMaxDocumentId(14, int.Parse(this.drpDistributor.SelectedValue.ToString()));
        controller.PostingCash_Bank_Account(14, long.Parse(s), long.Parse(this.DrpAccountDetail.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), decimal.Parse(this.txtAmount.Text), 0M, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), this.txtRemarks.Text, DateTime.Now, -1, int.Parse(this.DrpPrincipal.SelectedValue.ToString()), this.txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), 0L, 0, null, Constants.DateNullValue, 0x15, this.DrpDeliveryMan.SelectedValue.ToString());
    }

    private void CashRealization()
    {
        LedgerController controller = new LedgerController();
        string s = controller.SelectLedgerMaxDocumentId(14, int.Parse(this.drpDistributor.SelectedValue.ToString()));
        decimal num = decimal.Parse(this.txtAmount.Text);
        foreach (GridViewRow row in this.GrdCredit.Rows)
        {
            CheckBox box = (CheckBox)row.Cells[0].FindControl("ChbIsAssigned");
            if (box.Checked)
            {
                if (decimal.Parse(row.Cells[3].Text) >= num)
                {
                    controller.PostingCash_Bank_Account(14, long.Parse(s), long.Parse(Configuration.AccountReceivable), int.Parse(this.drpDistributor.SelectedValue.ToString()), 0M, num, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), this.txtRemarks.Text, DateTime.Now, int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), this.txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(row.Cells[1].Text), 13, this.txtSlipNo.Text, Constants.DateNullValue, 0x13, this.DrpDeliveryMan.SelectedValue.ToString());
                    controller.PostingCash_Bank_Account(14, long.Parse(s), long.Parse(this.DrpAccountDetail.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), num, 0M, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), this.txtRemarks.Text, DateTime.Now, int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), this.txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(row.Cells[1].Text), 13, this.txtSlipNo.Text, Constants.DateNullValue, 0x13, this.DrpDeliveryMan.SelectedValue.ToString());
                    num = decimal.Parse(row.Cells[3].Text) - num;
                    controller.UpdateSaleInvoice(long.Parse(row.Cells[1].Text), int.Parse(this.drpDistributor.SelectedValue.ToString()), num);
                    break;
                }
                if (decimal.Parse(row.Cells[3].Text) <= num)
                {
                    controller.PostingCash_Bank_Account(14, long.Parse(s), long.Parse(Configuration.AccountReceivable), int.Parse(this.drpDistributor.SelectedValue.ToString()), 0M, decimal.Parse(row.Cells[3].Text), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), this.txtRemarks.Text, DateTime.Now, int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), this.txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(row.Cells[1].Text), 13, this.txtSlipNo.Text, Constants.DateNullValue, 0x13, this.DrpDeliveryMan.SelectedValue.ToString());
                    controller.PostingCash_Bank_Account(14, long.Parse(s), long.Parse(this.DrpAccountDetail.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), decimal.Parse(row.Cells[3].Text), 0M, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), this.txtRemarks.Text, DateTime.Now, int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), this.txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(row.Cells[1].Text), 13, this.txtSlipNo.Text, Constants.DateNullValue, 0x13, this.DrpDeliveryMan.SelectedValue.ToString());
                    num -= decimal.Parse(row.Cells[3].Text);
                    controller.UpdateSaleInvoice(long.Parse(row.Cells[1].Text), int.Parse(this.drpDistributor.SelectedValue.ToString()), 0M);
                }
            }
        }
    }

    private void ChequeAdvance()
    {
        LedgerController controller = new LedgerController();
        new CustomerDataController();
        string s = controller.SelectLedgerMaxDocumentId(15, int.Parse(this.drpDistributor.SelectedValue.ToString()));
        controller.PostingCash_Bank_Account(15, long.Parse(s), long.Parse(Configuration.AccountReceivable), int.Parse(this.drpDistributor.SelectedValue.ToString()), 0M, decimal.Parse(this.txtAmount.Text), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), this.txtRemarks.Text, DateTime.Now, int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), this.txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), -9223372036854775808L, -2147483648, this.txtSlipNo.Text, Constants.DateNullValue, 20, "");
        controller.PostingCash_Bank_Account(15, long.Parse(s), long.Parse(this.DrpAccountDetail.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), decimal.Parse(this.txtAmount.Text), 0M, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), this.txtRemarks.Text, DateTime.Now, int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), this.txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), -9223372036854775808L, -2147483648, this.txtSlipNo.Text, Constants.DateNullValue, 20, "");
    }

    private void ChequeRealization()
    {
        LedgerController controller = new LedgerController();
        string s = controller.SelectLedgerMaxDocumentId(15, int.Parse(this.drpDistributor.SelectedValue.ToString()));
        decimal num = decimal.Parse(this.txtAmount.Text);
        foreach (GridViewRow row in this.GrdCredit.Rows)
        {
            CheckBox box = (CheckBox)row.Cells[0].FindControl("ChbIsAssigned");
            if (box.Checked)
            {
                if (decimal.Parse(row.Cells[3].Text) >= num)
                {
                    controller.PostingCash_Bank_Account(15, long.Parse(s), long.Parse(Configuration.AccountReceivable), int.Parse(this.drpDistributor.SelectedValue.ToString()), 0M, num, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), this.txtRemarks.Text, DateTime.Now, int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), this.txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(row.Cells[1].Text), 13, this.txtSlipNo.Text, Constants.DateNullValue, 0x12, this.DrpDeliveryMan.SelectedValue.ToString());
                    controller.PostingCash_Bank_Account(15, long.Parse(s), long.Parse(this.DrpAccountDetail.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), num, 0M, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), this.txtRemarks.Text, DateTime.Now, int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), this.txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(row.Cells[1].Text), 13, this.txtSlipNo.Text, Constants.DateNullValue, 0x12, this.DrpDeliveryMan.SelectedValue.ToString());
                    num = decimal.Parse(row.Cells[3].Text) - num;
                    controller.UpdateSaleInvoice(long.Parse(row.Cells[1].Text), int.Parse(this.drpDistributor.SelectedValue.ToString()), num);
                    break;
                }
                if (decimal.Parse(row.Cells[3].Text) <= num)
                {
                    controller.PostingCash_Bank_Account(15, long.Parse(s), long.Parse(Configuration.AccountReceivable), int.Parse(this.drpDistributor.SelectedValue.ToString()), 0M, decimal.Parse(row.Cells[3].Text), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), this.txtRemarks.Text, DateTime.Now, int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), this.txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(row.Cells[1].Text), 13, this.txtSlipNo.Text, Constants.DateNullValue, 0x12, this.DrpDeliveryMan.SelectedValue.ToString());
                    controller.PostingCash_Bank_Account(15, long.Parse(s), long.Parse(this.DrpAccountDetail.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), decimal.Parse(row.Cells[3].Text), 0M, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), this.txtRemarks.Text, DateTime.Now, int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), this.txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(row.Cells[1].Text), 13, this.txtSlipNo.Text, Constants.DateNullValue, 0x12, this.DrpDeliveryMan.SelectedValue.ToString());
                    num -= decimal.Parse(row.Cells[3].Text);
                    controller.UpdateSaleInvoice(long.Parse(row.Cells[1].Text), int.Parse(this.drpDistributor.SelectedValue.ToString()), 0M);
                }
            }
        }
    }

    private void ClearAll()
    {
        this.txtChequeNo.Text = "";
        this.txtAmount.Text = "";
        this.txtRemarks.Text = "";
        this.txtSlipNo.Text = "";
    }

    protected void DrpAccountDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGrid();
    }

    protected void DrpAccountType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadAccountHead();
        this.LoadGrid();
    }

    protected void DrpAccountType_SelectedIndexChanged1(object sender, EventArgs e)
    {
        this.LoadAccountHead();
        this.LoadGrid();
        if (this.DrpAccountType.SelectedIndex == 1)
        {
            this.Panel1.Visible = false;
            this.DrpRoute.Enabled = false;
            this.DrpDeliveryMan.Enabled = false;
            this.DrpCustomer.Enabled = false;
        }
        else
        {
            this.LoadArea();
            this.LoadData();
            this.SelectCreditInvoice();
            this.Panel1.Visible = true;
            this.DrpDeliveryMan.Enabled = true;
            this.DrpCustomer.Enabled = true;
        }
    }

    protected void DrpCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectCreditInvoice();
    }

    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadArea();
        this.LoadData();
        this.LoadGrid();
        this.LoadDeliveryman();
    }

    protected void DrpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadData();
        this.SelectCreditInvoice();
    }

    protected void DrpRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadData();
        this.SelectCreditInvoice();
    }

    protected void DrpTranType_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void GrdOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        LedgerController controller = new LedgerController();
        DataControl control = new DataControl();
        controller.DeleteCashBankTransction(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(control.chkNull_0(this.GrdOrder.Rows[e.RowIndex].Cells[2].Text)), (long)int.Parse(control.chkNull_0(this.GrdOrder.Rows[e.RowIndex].Cells[7].Text)), long.Parse(control.chkNull_0(this.GrdOrder.Rows[e.RowIndex].Cells[5].Text.Replace("&nbsp;", ""))), decimal.Parse(control.chkNull_0(this.GrdOrder.Rows[e.RowIndex].Cells[8].Text)));
        this.LoadGrid();
        this.SelectCreditInvoice();
    }

    private void IncomeTax()
    {
        LedgerController controller = new LedgerController();
        string s = controller.SelectLedgerMaxDocumentId(0x10, int.Parse(this.drpDistributor.SelectedValue.ToString()));
        decimal num = decimal.Parse(this.txtAmount.Text);
        foreach (GridViewRow row in this.GrdCredit.Rows)
        {
            CheckBox box = (CheckBox)row.Cells[0].FindControl("ChbIsAssigned");
            if (box.Checked)
            {
                if (decimal.Parse(row.Cells[3].Text) >= num)
                {
                    controller.PostingCash_Bank_Account(0x10, long.Parse(s), long.Parse(Configuration.AccountReceivable), int.Parse(this.drpDistributor.SelectedValue.ToString()), 0M, num, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), this.txtRemarks.Text, DateTime.Now, int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), this.txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(row.Cells[1].Text), 13, this.txtSlipNo.Text, Constants.DateNullValue, int.Parse(this.DrpAccountType.SelectedValue.ToString()), this.DrpDeliveryMan.SelectedValue.ToString());
                    controller.PostingCash_Bank_Account(0x10, long.Parse(s), long.Parse(this.DrpAccountDetail.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), num, 0M, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), this.txtRemarks.Text, DateTime.Now, int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), this.txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(row.Cells[1].Text), 13, this.txtSlipNo.Text, Constants.DateNullValue, int.Parse(this.DrpAccountType.SelectedValue.ToString()), this.DrpDeliveryMan.SelectedValue.ToString());
                    num = decimal.Parse(row.Cells[3].Text) - num;
                    controller.UpdateSaleInvoice(long.Parse(row.Cells[1].Text), int.Parse(this.drpDistributor.SelectedValue.ToString()), num);
                    break;
                }
                if (decimal.Parse(row.Cells[3].Text) <= num)
                {
                    controller.PostingCash_Bank_Account(0x10, long.Parse(s), long.Parse(Configuration.AccountReceivable), int.Parse(this.drpDistributor.SelectedValue.ToString()), 0M, decimal.Parse(row.Cells[3].Text), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), this.txtRemarks.Text, DateTime.Now, int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), this.txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(row.Cells[1].Text), 13, this.txtSlipNo.Text, Constants.DateNullValue, int.Parse(this.DrpAccountType.SelectedValue.ToString()), this.DrpDeliveryMan.SelectedValue.ToString());
                    controller.PostingCash_Bank_Account(0x10, long.Parse(s), long.Parse(this.DrpAccountDetail.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), decimal.Parse(row.Cells[3].Text), 0M, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), this.txtRemarks.Text, DateTime.Now, int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), this.txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(row.Cells[1].Text), 13, this.txtSlipNo.Text, Constants.DateNullValue, int.Parse(this.DrpAccountType.SelectedValue.ToString()), this.DrpDeliveryMan.SelectedValue.ToString());
                    num -= decimal.Parse(row.Cells[3].Text);
                    controller.UpdateSaleInvoice(long.Parse(row.Cells[1].Text), int.Parse(this.drpDistributor.SelectedValue.ToString()), 0M);
                }
            }
        }
    }

    private void LoadAccountHead()
    {
        if (this.DrpAccountType.SelectedIndex == 0)
        {
            DataTable table = new AccountHeadController().SelectAccountHead(0x5e, long.Parse(Configuration.CashDefaultType));
            clsWebFormUtil.FillDropDownList(this.DrpAccountDetail, table, 0, 4, true);
        }
        else if (this.DrpAccountType.SelectedIndex == 2)
        {
            this.DrpAccountDetail.Items.Clear();
            this.DrpAccountDetail.Items.Add(new ListItem("Tax Deducted By Parties", "127"));
        }
        else
        {
            DataTable table2 = new AccountHeadController().SelectAccountHead(0x5e, long.Parse(Configuration.BankDefaultType));
            clsWebFormUtil.FillDropDownList(this.DrpAccountDetail, table2, 0, 4, true);
        }
    }

    private void LoadArea()
    {
        if (this.DrpAccountType.SelectedIndex == 1)
        {
            this.DrpRoute.Items.Clear();
            this.DrpRoute.Enabled = false;
        }
        else
        {
            DataTable table = new DistributorAreaController().SelectDist_Area(-9223372036854775808L, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.drpDistributor.SelectedValue.ToString()), -2147483648, null, null);
            clsWebFormUtil.FillDropDownList(this.DrpRoute, table, 0, 6, true);
            this.DrpRoute.Enabled = true;
        }
    }

    private void LoadData()
    {
        if (this.drpDistributor.Items.Count > 0)
        {
            CustomerDataController controller = new CustomerDataController();
            if (((this.DrpAccountType.SelectedIndex == 0) || (this.DrpAccountType.SelectedIndex == 3)) || (this.DrpAccountType.SelectedIndex == 4))
            {
                DataTable table = controller.SelectCreditPendingInvoice(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), -9223372036854775808L, -2147483648);
                clsWebFormUtil.FillDropDownList(this.DrpCustomer, table, 0, 1, true);
            }
            else if (((this.DrpAccountType.SelectedIndex == 1) || (this.DrpAccountType.SelectedIndex == 5)) || (this.DrpAccountType.SelectedIndex == 7))
            {
                DataTable table2 = controller.SelectPrincipalCustomer(int.Parse(this.drpDistributor.SelectedValue.ToString()), -2147483648, -2147483648, int.Parse(this.DrpPrincipal.SelectedValue.ToString()));
                clsWebFormUtil.FillDropDownList(this.DrpCustomer, table2, 0, 4, true);
            }
        }
    }

    private void LoadDeliveryman()
    {
        if (this.drpDistributor.Items.Count > 0)
        {
            DataTable table = new Distributor_UserController().SelectSaleForceAssignedArea(int.Parse(this.drpDistributor.SelectedValue.ToString()), -2147483648, int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpDeliveryMan, table, 0, 3, true);
        }
    }

    private void LoadDistributor()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, table, 0, 2, true);
    }

    private void LoadGrid()
    {
        if (this.drpDistributor.Items.Count > 0)
        {
            DataTable table = new LedgerController().SelectBankCashTransction(int.Parse(this.drpDistributor.SelectedValue.ToString()), -2147483648, int.Parse(this.DrpAccountType.SelectedValue.ToString()), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            this.GrdOrder.DataSource = table;
            this.GrdOrder.DataBind();
        }
    }

    private void LoadPrincipal()
    {
        DataTable table = new SKUPriceDetailController().SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, table, 0, 1, true);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            Configuration.GetAccountHead();
            this.LoadPrincipal();
            this.LoadDistributor();
            this.LoadArea();
            this.LoadData();
            this.LoadAccountHead();
            this.LoadGrid();
            this.LoadDeliveryman();
            this.SelectCreditInvoice();
            this.Button1.Attributes.Add("onclick", "return ValidateForm();");
        }
    }

    private void SelectCreditInvoice()
    {
        CustomerDataController controller = new CustomerDataController();
        if (this.DrpCustomer.Items.Count > 0)
        {
            DataTable table = controller.SelectCreditPendingInvoice(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), long.Parse(this.DrpCustomer.SelectedValue.ToString()), 0);
            this.GrdCredit.DataSource = table;
            this.GrdCredit.DataBind();
        }
    }
}