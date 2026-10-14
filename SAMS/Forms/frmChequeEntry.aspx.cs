using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmChequeEntry : System.Web.UI.Page
{    
    protected void Button1_Click(object sender, EventArgs e)
    {
        DateTime now;
        ChequeEntryController controller = new ChequeEntryController();
        if (this.txtStartDate.Text.Length == 10)
        {
            now = DateTime.Parse(ConvertDate.British_To_American(this.txtStartDate.Text));
        }
        else
        {
            now = DateTime.Now;
        }
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
        }
        else
        {
            if (this.Button1.Text == "Save")
            {
                if (this.DrpStatus.SelectedIndex == 0)
                {
                    this.HFChqueProcessId.Value = controller.InsertChequeEntry(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), long.Parse(this.DrpCustomer.SelectedValue.ToString()), this.txtChequeNo.Text, this.txtBankName.Text, now, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), Constants.DateNullValue, Constants.DateNullValue, decimal.Parse(this.txtAmount.Text), int.Parse(this.DrpStatus.SelectedValue.ToString()), DateTime.Now, this.DrpChequeType.SelectedIndex, this.txtSlipNo.Text, this.txtRemarks.Text, long.Parse(this.DrpBankAccount.SelectedValue.ToString()), int.Parse(this.DrpDeliveryMan.SelectedValue.ToString()));
                    foreach (GridViewRow row2 in this.GrdCredit.Rows)
                    {
                        CheckBox box2 = (CheckBox)row2.Cells[0].FindControl("ChbIsAssigned");
                        if (box2.Checked)
                        {
                            controller.InsertChequeEntryInvoice(long.Parse(this.HFChqueProcessId.Value), long.Parse(row2.Cells[1].Text));
                        }
                    }
                }
            }
            else if ((int.Parse(this.DrpStatus.SelectedValue.ToString()) == 0x20f) && (this.txtReceivedDate.Text == DateTime.Parse(this.Session["CurrentWorkDate"].ToString()).ToString("dd/MM/yyyy")))
            {
                controller.UpdateChequeEntry(long.Parse(this.HFChqueProcessId.Value), int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), long.Parse(this.DrpCustomer.SelectedValue.ToString()), this.txtChequeNo.Text, this.txtBankName.Text, now, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), Constants.DateNullValue, Constants.DateNullValue, decimal.Parse(this.txtAmount.Text), int.Parse(this.DrpStatus.SelectedValue.ToString()), Constants.DateNullValue, this.txtSlipNo.Text, this.DrpChequeType.SelectedIndex, this.txtRemarks.Text, (long)int.Parse(this.DrpBankAccount.SelectedValue.ToString()), int.Parse(this.DrpDeliveryMan.SelectedValue.ToString()));
                controller.SelectChequeEntryInvoice(long.Parse(this.HFChqueProcessId.Value), 1);
                foreach (GridViewRow row3 in this.GrdCredit.Rows)
                {
                    CheckBox box3 = (CheckBox)row3.Cells[0].FindControl("ChbIsAssigned");
                    if (box3.Checked)
                    {
                        controller.InsertChequeEntryInvoice(long.Parse(this.HFChqueProcessId.Value), long.Parse(row3.Cells[1].Text));
                    }
                }
            }
            else if ((int.Parse(this.DrpStatus.SelectedValue.ToString()) == 0x210) || (int.Parse(this.DrpStatus.SelectedValue.ToString()) == 0x214))
            {
                controller.UpdateChequeEntry(long.Parse(this.HFChqueProcessId.Value), -2147483648, -2147483648, -9223372036854775808L, null, null, Constants.DateNullValue, Constants.DateNullValue, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), Constants.DateNullValue, -79228162514264337593543950335M, int.Parse(this.DrpStatus.SelectedValue.ToString()), Constants.DateNullValue, this.txtSlipNo.Text, this.DrpChequeType.SelectedIndex, this.txtRemarks.Text, (long)int.Parse(this.DrpBankAccount.SelectedValue.ToString()), int.Parse(this.DrpDeliveryMan.SelectedValue.ToString()));
            }
            else if ((int.Parse(this.DrpStatus.SelectedValue.ToString()) == 530) || (int.Parse(this.DrpStatus.SelectedValue.ToString()) == 0x213))
            {
                controller.UpdateChequeEntry(long.Parse(this.HFChqueProcessId.Value), -2147483648, -2147483648, -9223372036854775808L, null, null, Constants.DateNullValue, Constants.DateNullValue, Constants.DateNullValue, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), -79228162514264337593543950335M, int.Parse(this.DrpStatus.SelectedValue.ToString()), Constants.DateNullValue, this.txtSlipNo.Text, this.DrpChequeType.SelectedIndex, this.txtRemarks.Text, long.Parse(this.DrpBankAccount.SelectedValue.ToString()), int.Parse(this.DrpDeliveryMan.SelectedValue.ToString()));
            }
            else if (int.Parse(this.DrpStatus.SelectedValue.ToString()) == 0x211)
            {
                controller.UpdateChequeEntry(long.Parse(this.HFChqueProcessId.Value), -2147483648, -2147483648, -9223372036854775808L, null, null, Constants.DateNullValue, Constants.DateNullValue, Constants.DateNullValue, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), -79228162514264337593543950335M, int.Parse(this.DrpStatus.SelectedValue.ToString()), Constants.DateNullValue, this.txtSlipNo.Text, this.DrpChequeType.SelectedIndex, this.txtRemarks.Text, long.Parse(this.DrpBankAccount.SelectedValue.ToString()), int.Parse(this.DrpDeliveryMan.SelectedValue.ToString()));
                controller.SelectChequeEntryInvoice(long.Parse(this.HFChqueProcessId.Value), 1);
                foreach (GridViewRow row4 in this.GrdCredit.Rows)
                {
                    CheckBox box4 = (CheckBox)row4.Cells[0].FindControl("ChbIsAssigned");
                    if (box4.Checked)
                    {
                        controller.InsertChequeEntryInvoice(long.Parse(this.HFChqueProcessId.Value), long.Parse(row4.Cells[1].Text));
                    }
                }
                this.ChequeRealization();
                this.LoadData();
                this.SelectCreditInvoice();
            }
            this.ClearAll();
            this.LoadReceviedCheque();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        this.ClearAll();
    }

    protected void Button21_Click(object sender, EventArgs e)
    {
        DataTable table = (DataTable)this.Session["dt"];
        switch (this.ddSearchType.SelectedIndex)
        {
            case 1:
                table.DefaultView.RowFilter = this.ddSearchType.SelectedValue.ToString() + " like '%" + this.txtSeach.Text + "%'";
                break;

            case 2:
                table.DefaultView.RowFilter = this.ddSearchType.SelectedValue.ToString() + " like '%" + this.txtSeach.Text + "%'";
                break;

            case 3:
                table.DefaultView.RowFilter = this.ddSearchType.SelectedValue.ToString() + " like '%" + this.txtSeach.Text + "%'";
                break;

            case 4:
                table.DefaultView.RowFilter = this.ddSearchType.SelectedValue.ToString() + " like '%" + this.txtSeach.Text + "%'";
                break;

            default:
                table.DefaultView.RowFilter = "CHEQUE_NO like '%%'";
                break;
        }
        this.GrdOrder.DataSource = table.DefaultView;
        this.GrdOrder.DataBind();
    }

    private void ChequeRealization()
    {
        LedgerController controller = new LedgerController();
        string s = controller.SelectLedgerMaxDocumentId(15, int.Parse(this.drpDistributor.SelectedValue.ToString()));
        decimal num = decimal.Parse(this.txtAmount.Text);
        if (this.DrpChequeType.SelectedIndex == 0)
        {
            foreach (GridViewRow row in this.GrdCredit.Rows)
            {
                CheckBox box = (CheckBox)row.Cells[0].FindControl("ChbIsAssigned");
                if (box.Checked)
                {
                    if (decimal.Parse(row.Cells[3].Text) >= num)
                    {
                        controller.PostingCash_Bank_Account(15, long.Parse(s), 0x6bL, int.Parse(this.drpDistributor.SelectedValue.ToString()), 0M, num, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), "Cheque Realization-" + this.txtChequeNo.Text + "-" + this.txtStartDate.Text, DateTime.Now, int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), this.txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(row.Cells[1].Text), 13, this.txtSlipNo.Text, Constants.DateNullValue, 0x12, this.DrpDeliveryMan.SelectedValue.ToString());
                        controller.PostingCash_Bank_Account(15, long.Parse(s), long.Parse(this.DrpBankAccount.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), num, 0M, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), "Cheque Realization-" + this.txtChequeNo.Text + "-" + this.txtStartDate.Text, DateTime.Now, int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), this.txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(row.Cells[1].Text), 13, this.txtSlipNo.Text, Constants.DateNullValue, 0x12, this.DrpDeliveryMan.SelectedValue.ToString());
                        num = decimal.Parse(row.Cells[3].Text) - num;
                        controller.UpdateSaleInvoice(long.Parse(row.Cells[1].Text), int.Parse(this.drpDistributor.SelectedValue.ToString()), num);
                        break;
                    }
                    if (decimal.Parse(row.Cells[3].Text) <= num)
                    {
                        controller.PostingCash_Bank_Account(15, long.Parse(s), 0x6bL, int.Parse(this.drpDistributor.SelectedValue.ToString()), 0M, decimal.Parse(row.Cells[3].Text), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), "Cheque Realization-" + this.txtChequeNo.Text + "-" + this.txtStartDate.Text, DateTime.Now, int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), this.txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(row.Cells[1].Text), 13, this.txtSlipNo.Text, Constants.DateNullValue, 0x12, this.DrpDeliveryMan.SelectedValue.ToString());
                        controller.PostingCash_Bank_Account(15, long.Parse(s), long.Parse(this.DrpBankAccount.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), decimal.Parse(row.Cells[3].Text), 0M, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), "Cheque Realization-" + this.txtChequeNo.Text + "-" + this.txtStartDate.Text, DateTime.Now, int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), this.txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(row.Cells[1].Text), 13, this.txtSlipNo.Text, Constants.DateNullValue, 0x12, this.DrpDeliveryMan.SelectedValue.ToString());
                        num -= decimal.Parse(row.Cells[3].Text);
                        controller.UpdateSaleInvoice(long.Parse(row.Cells[1].Text), int.Parse(this.drpDistributor.SelectedValue.ToString()), 0M);
                    }
                }
            }
        }
        else
        {
            controller.PostingCash_Bank_Account(15, long.Parse(s), 0x6bL, int.Parse(this.drpDistributor.SelectedValue.ToString()), 0M, decimal.Parse(this.txtAmount.Text), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), "Cheque Advance", DateTime.Now, int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), this.txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), -9223372036854775808L, -2147483648, this.txtSlipNo.Text, Constants.DateNullValue, 20, "");
            controller.PostingCash_Bank_Account(15, long.Parse(s), 0x145L, int.Parse(this.drpDistributor.SelectedValue.ToString()), decimal.Parse(this.txtAmount.Text), 0M, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), "Cheque Advance", DateTime.Now, int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), this.txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), -9223372036854775808L, -2147483648, this.txtSlipNo.Text, Constants.DateNullValue, 20, "");
        }
    }

    private void ClearAll()
    {
        this.txtChequeNo.Text = "";
        this.txtAmount.Text = "";
        this.txtBankName.Text = "";
        this.txtStartDate.Text = "";
        this.Button1.Text = "Save";
        this.txtReceivedDate.Text = "";
        this.txtSlipNo.Text = "";
        this.txtRemarks.Text = "";
    }

    protected void DrpCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectCreditInvoice();
    }

    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadArea();
        this.LoadData();
        this.SelectCreditInvoice();
        this.LoadReceviedCheque();
    }

    protected void DrpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadData();
        this.SelectCreditInvoice();
        this.LoadReceviedCheque();
    }

    protected void DrpRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadData();
        this.SelectCreditInvoice();
    }

    protected void DrpStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.Button1.Text == "Save")
        {
            this.LoadReceviedCheque();
        }
    }

    protected void GrdOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        new ChequeEntryController().DeleteChequeEntry(long.Parse(this.GrdOrder.Rows[e.RowIndex].Cells[0].Text));
        this.LoadReceviedCheque();
    }

    protected void GrdOrder_RowEditing(object sender, GridViewEditEventArgs e)
    {
        ChequeEntryController controller = new ChequeEntryController();
        this.HFChqueProcessId.Value = this.GrdOrder.Rows[e.NewEditIndex].Cells[0].Text;
        this.DrpRoute.SelectedValue = this.GrdOrder.Rows[e.NewEditIndex].Cells[11].Text;
        this.LoadData();
        this.DrpCustomer.SelectedValue = this.GrdOrder.Rows[e.NewEditIndex].Cells[1].Text;
        this.txtChequeNo.Text = this.GrdOrder.Rows[e.NewEditIndex].Cells[3].Text;
        this.txtBankName.Text = this.GrdOrder.Rows[e.NewEditIndex].Cells[4].Text;
        this.txtStartDate.Text = this.GrdOrder.Rows[e.NewEditIndex].Cells[5].Text;
        this.txtReceivedDate.Text = this.GrdOrder.Rows[e.NewEditIndex].Cells[6].Text;
        this.txtAmount.Text = this.GrdOrder.Rows[e.NewEditIndex].Cells[8].Text;
        this.txtSlipNo.Text = this.GrdOrder.Rows[e.NewEditIndex].Cells[9].Text;
        this.txtRemarks.Text = this.GrdOrder.Rows[e.NewEditIndex].Cells[10].Text;
        this.DrpBankAccount.SelectedValue = this.GrdOrder.Rows[e.NewEditIndex].Cells[13].Text;
        this.DrpDeliveryMan.SelectedValue = this.GrdOrder.Rows[e.NewEditIndex].Cells[14].Text;
        this.Button1.Text = "Update";
        this.SelectCreditInvoice();
        DataTable table = controller.SelectChequeEntryInvoice(long.Parse(this.HFChqueProcessId.Value), 0);
        foreach (GridViewRow row in this.GrdCredit.Rows)
        {
            foreach (DataRow row2 in table.Rows)
            {
                if (long.Parse(row.Cells[1].Text) == long.Parse(row2["SALE_INVOICE_ID"].ToString()))
                {
                    CheckBox box = (CheckBox)row.Cells[0].FindControl("ChbIsAssigned");
                    box.Checked = true;
                }
            }
        }
    }

    private void LoadAccountHead()
    {
        Configuration.GetAccountHead();
        DataTable table = new AccountHeadController().SelectAccountHead(0x5e, long.Parse(Configuration.BankDefaultType));
        clsWebFormUtil.FillDropDownList(this.DrpBankAccount, table, 0, 4, true);
    }

    private void LoadArea()
    {
        DataTable table = new DistributorAreaController().SelectDist_Area(-9223372036854775808L, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.drpDistributor.SelectedValue.ToString()), -2147483648, null, null);
        clsWebFormUtil.FillDropDownList(this.DrpRoute, table, 0, 6, true);
    }

    private void LoadData()
    {
        CustomerDataController controller = new CustomerDataController();
        if (this.DrpChequeType.SelectedIndex == 1)
        {
            DataTable table = controller.SelectPrincipalCustomer(int.Parse(this.drpDistributor.SelectedValue.ToString()), -2147483648, -2147483648, int.Parse(this.DrpPrincipal.SelectedValue.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpCustomer, table, 0, 4, true);
            this.DrpRoute.Enabled = true;
            this.Panel1.Enabled = false;
        }
        else if (this.drpDistributor.Items.Count > 0)
        {
            DataTable table2 = controller.SelectCreditPendingInvoice(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), -2147483648L, -2147483648);
            clsWebFormUtil.FillDropDownList(this.DrpCustomer, table2, 0, 1, true);
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

    private void LoadPrincipal()
    {
        DataTable table = new SKUPriceDetailController().SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, table, 0, 1, true);
    }

    private void LoadReceviedCheque()
    {
        int num = 0x211;
        if (this.DrpStatus.SelectedValue.ToString() != num.ToString())
        {
            DataTable table = new ChequeEntryController().SelectChequeEntry(int.Parse(this.DrpStatus.SelectedValue.ToString()), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), this.DrpChequeType.SelectedIndex);
            this.Session.Add("dt", table);
            this.GrdOrder.DataSource = table;
            this.GrdOrder.DataBind();
        }
        else
        {
            this.GrdOrder.DataSource = null;
            this.GrdOrder.DataBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            int num = 0x20f;
            this.DrpStatus.Items.Add(new ListItem("Cheque Received", num.ToString()));
            int num2 = 0x210;
            this.DrpStatus.Items.Add(new ListItem("Cheque Deposit", num2.ToString()));
            int num3 = 0x211;
            this.DrpStatus.Items.Add(new ListItem("Cheque Realize", num3.ToString()));
            int num4 = 530;
            this.DrpStatus.Items.Add(new ListItem("Cheque Bounce", num4.ToString()));
            int num5 = 0x213;
            this.DrpStatus.Items.Add(new ListItem("Cheque Cancel", num5.ToString()));
            int num6 = 0x214;
            this.DrpStatus.Items.Add(new ListItem("Cheque Hold", num6.ToString()));
            this.LoadAccountHead();
            this.LoadPrincipal();
            this.LoadDistributor();
            this.LoadArea();
            this.LoadData();
            this.SelectCreditInvoice();
            this.LoadReceviedCheque();
            this.LoadDeliveryman();
            this.Button1.Attributes.Add("onclick", "return ValidateForm();");
        }
    }

    private void SelectCreditInvoice()
    {
        CustomerDataController controller = new CustomerDataController();
        this.GrdCredit.DataSource = null;
        if (this.DrpCustomer.Items.Count > 0)
        {
            DataTable table = controller.SelectCreditPendingInvoice(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), long.Parse(this.DrpCustomer.SelectedValue.ToString()), 0);
            this.GrdCredit.DataSource = table;
            this.GrdCredit.DataBind();
        }
    }
}