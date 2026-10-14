using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmRollBackForm : System.Web.UI.Page
{    
    protected void btnGetOrder_Click(object sender, EventArgs e)
    {
        GrdOrder.EditIndex = -1;
        GrdCheque.EditIndex = -1;
        if (this.DrpDocumentType.SelectedIndex == 3)
        {
            this.LoadRollbackCheque();
            this.GrdOrder.Visible = false;
            this.GrdCheque.Visible = true;
        }
        else
        {
            this.GrdOrder.Visible = true;
            this.GrdCheque.Visible = false;
            this.LoadRollbackDocument();
        }
    }

    protected void btnPost_Click(object sender, EventArgs e)
    {
        GrdOrder.EditIndex = -1;
        GrdCheque.EditIndex = -1;
        if (this.DrpDocumentType.SelectedIndex == 3)
        {
            foreach (GridViewRow row in this.GrdCheque.Rows)
            {
                CheckBox box = (CheckBox)row.FindControl("ChbInvoice");
                if (box.Checked)
                {
                    ChequeEntryController controller = new ChequeEntryController();
                    new DataControl();
                    controller.RollbackChequeEntry(int.Parse(this.DrpPrincipal.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), row.Cells[6].Text, long.Parse(row.Cells[0].Text), long.Parse(row.Cells[5].Text));
                }
            }
            this.LoadRollbackCheque();
        }
        else
        {
            foreach (GridViewRow row2 in this.GrdOrder.Rows)
            {
                CheckBox box2 = (CheckBox)row2.FindControl("ChbInvoice");
                if (box2.Checked)
                {
                    OrderEntryController controller2 = new OrderEntryController();
                    new DataControl();
                    controller2.UpdateRollBackDocument(long.Parse(row2.Cells[4].Text), int.Parse(this.DrpDocumentType.SelectedValue.ToString()), int.Parse(this.DrpLenged.SelectedValue.ToString()));
                }
            }
            this.LoadRollbackDocument();
        }
    }

    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadPrincipal();
        this.LoadOrderBooker();
    }

    protected void DrpDocumentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadOrderBooker();
    }

    protected void DrpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadOrderBooker();
    }

    private void LoadDistributor()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, table, 0, 2, true);
    }

    private void LoadLegend()
    {
        DataTable table = new OrderEntryController().SelectLegend();
        clsWebFormUtil.FillDropDownList(this.DrpLenged, table, 0, 2, true);
    }

    private void LoadOrderBooker()
    {
        if (this.drpDistributor.Items.Count > 0)
        {
            DataTable table = new Distributor_UserController().SelectRollBackInvoiceSaleForce(int.Parse(this.DrpDocumentType.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpOrderBooker, table, 0, 1, true);
        }
        else
        {
            this.DrpOrderBooker.Items.Clear();
        }
    }

    private void LoadPrincipal()
    {
        DataTable table = new SKUPriceDetailController().SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, table, 0, 1, true);
    }

    private void LoadRollbackCheque()
    {
        DataTable table = new ChequeEntryController().SelectChequeEntry(0x211, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), 0);
        this.GrdCheque.DataSource = table;
        this.GrdCheque.DataBind();
    }

    private void LoadRollbackDocument()
    {
        DataTable table = new OrderEntryController().SelectRollBackDocument(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), int.Parse(this.DrpOrderBooker.SelectedValue.ToString()), int.Parse(this.DrpDocumentType.SelectedValue.ToString()), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        this.GrdOrder.DataSource = table;
        this.GrdOrder.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadPrincipal();
            this.LoadOrderBooker();
            this.LoadLegend();
        }
    }

}