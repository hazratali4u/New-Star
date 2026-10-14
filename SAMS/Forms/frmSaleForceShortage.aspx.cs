using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Forms_frmSaleForceShortage : System.Web.UI.Page
{
    private static int pSaleShortId;
    
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        GrdOrder.EditIndex = -1;
        Distributor_UserController controller = new Distributor_UserController();
        if (this.btnAddNew.Text == "Save")
        {
            controller.InsertSalesForceShortage(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), int.Parse(this.DrpSaleForce.SelectedValue.ToString()), decimal.Parse(this.txtAmount.Text), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), this.txtRemarks.Text);
        }
        else
        {
            controller.UpdateSalesForceShortage(pSaleShortId, int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), int.Parse(this.DrpSaleForce.SelectedValue.ToString()), decimal.Parse(this.txtAmount.Text), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), this.txtRemarks.Text);
        }
        this.txtAmount.Text = "";
        this.txtRemarks.Text = "";
        this.LoadGrid();
    }

    protected void GrdOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }

    protected void GrdOrder_RowEditing(object sender, GridViewEditEventArgs e)
    {
        pSaleShortId = int.Parse(this.GrdOrder.Rows[e.NewEditIndex].Cells[0].Text);
        this.DrpSaleForce.SelectedValue = this.GrdOrder.Rows[e.NewEditIndex].Cells[1].Text;
        this.DrpPrincipal.SelectedValue = this.GrdOrder.Rows[e.NewEditIndex].Cells[2].Text;
        this.txtRemarks.Text = this.GrdOrder.Rows[e.NewEditIndex].Cells[5].Text;
        this.txtAmount.Text = this.GrdOrder.Rows[e.NewEditIndex].Cells[6].Text;
        this.btnAddNew.Text = "Update";
    }

    private void LoadDeliveryman()
    {
        if (this.drpDistributor.Items.Count > 0)
        {
            this.DrpSaleForce.Items.Clear();
            DataTable table = new Distributor_UserController().SelectSaleForceAssignedArea(int.Parse(this.drpDistributor.SelectedValue.ToString()), -2147483648, int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpSaleForce, table, 0, 3);
        }
        else
        {
            this.DrpSaleForce.Items.Clear();
        }
    }

    private void LoadDistributor()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, table, 0, 2);
    }

    private void LoadGrid()
    {
        DataTable table = new Distributor_UserController().SelectSalesForceShortage(int.Parse(this.drpDistributor.SelectedValue.ToString()), -2147483648, -2147483648, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        this.GrdOrder.DataSource = table;
        this.GrdOrder.DataBind();
    }

    private void LoadPrincipal()
    {
        DataTable table = new SKUPriceDetailController().SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, table, 0, 1);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadPrincipal();
            this.LoadDeliveryman();
            this.LoadGrid();
        }
    }
}