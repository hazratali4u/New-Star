using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Forms_frmInvoiceBuiltyDetail : System.Web.UI.Page
{
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        LedgerController controller = new LedgerController();
        Configuration.GetAccountHead();
        string s = controller.SelectLedgerMaxDocumentId(0x10, int.Parse(this.drpDistributor.SelectedValue.ToString()));
        controller.PostingCash_Bank_Account(0x10, long.Parse(s), long.Parse(Configuration.BuiltyExp.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), decimal.Parse(this.txtAmount.Text), 0M, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), this.txtRemarks.Text, DateTime.Now, int.Parse(this.DrpCustomer.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), null, int.Parse(this.Session["UserId"].ToString()), (long)int.Parse(this.DrpInvoiceNo.SelectedValue.ToString()), 13, null, Constants.DateNullValue, 30, this.DrpTransporter.SelectedValue.ToString());
        this.LoadGrid();
        this.txtAmount.Text = "";
        this.txtRemarks.Text = "";
    }

    protected void DrpCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable table = (DataTable)this.Session["dtCustomer"];
        this.DrpInvoiceNo.Items.Clear();
        DataRow[] rowArray = table.Select("Customer_id  = " + this.DrpCustomer.SelectedValue);
        for (int i = 0; i < rowArray.Length; i++)
        {
            this.DrpInvoiceNo.Items.Add(new ListItem(rowArray[i]["Sale_Invoice_Id"].ToString(), rowArray[i]["Sale_Invoice_Id"].ToString()));
        }
    }

    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadCustomer();
        this.LoadGrid();
    }

    protected void DrpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadCustomer();
    }

    protected void GrdOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        LedgerController controller = new LedgerController();
        DataControl control = new DataControl();
        controller.DeleteWareHouseLedger(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(control.chkNull_0(this.GrdOrder.Rows[e.RowIndex].Cells[2].Text)), (long)int.Parse(control.chkNull_0(this.GrdOrder.Rows[e.RowIndex].Cells[7].Text)), -9223372036854775808L, decimal.Parse(control.chkNull_0(this.GrdOrder.Rows[e.RowIndex].Cells[8].Text)));
        this.LoadGrid();
    }

    private void LoadCustomer()
    {
        if (this.drpDistributor.Items.Count > 0)
        {
            DataTable table = new CustomerDataController().SelectPrincipalCustomer(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpCustomer, table, 0, 4, true);
            if (table.Rows.Count > 0)
            {
                this.DrpInvoiceNo.Items.Clear();
                DataRow[] rowArray = table.Select("Customer_id  = " + this.DrpCustomer.SelectedValue);
                for (int i = 0; i < rowArray.Length; i++)
                {
                    this.DrpInvoiceNo.Items.Add(new ListItem(rowArray[i]["Sale_Invoice_Id"].ToString(), rowArray[i]["Sale_Invoice_Id"].ToString()));
                }
                this.Session.Add("dtCustomer", table);
            }
        }
        else
        {
            this.DrpCustomer.Items.Clear();
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
            DataTable table = new LedgerController().SelectBankCashTransction(int.Parse(this.drpDistributor.SelectedValue.ToString()), -2147483648, 30, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            this.GrdOrder.DataSource = table;
            this.GrdOrder.DataBind();
        }
    }

    private void LoadPrincipal()
    {
        DataTable table = new SKUPriceDetailController().SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, table, 0, 1);
    }

    private void LoadTransporter()
    {
        DataTable table = DistributorController.SelectTranspoter();
        clsWebFormUtil.FillDropDownList(this.DrpTransporter, table, 0, 1);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadPrincipal();
            this.LoadCustomer();
            this.LoadTransporter();
            this.LoadGrid();
        }
    }
}