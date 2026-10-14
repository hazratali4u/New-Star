using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_frmOrderEntryStep1 : System.Web.UI.Page
{    
    protected void btnGetOrder_Click(object sender, EventArgs e)
    {
        GrdOrder.EditIndex = -1;
        this.LoadPendingOrder();
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        if (((this.drpDistributor.Items.Count > 0) && (this.DrpPrincipal.Items.Count > 0)) && ((this.DrpRoute.Items.Count > 0) && (this.DrpDeliveryMan.Items.Count > 0)))
        {
            this.Session.Add("DistributorId", int.Parse(this.drpDistributor.SelectedValue.ToString()));
            this.Session.Add("PrincipalId", int.Parse(this.DrpPrincipal.SelectedValue.ToString()));
            this.Session.Add("AreaId", long.Parse(this.DrpRoute.SelectedValue.ToString()));
            this.Session.Add("Route", this.DrpRoute.SelectedItem.Text);
            this.Session.Add("SaleMan", this.DrpDeliveryMan.SelectedItem.Text);
            this.Session.Add("OrderDate", Convert.ToDateTime(this.txtToDate.Text).ToString("dd-MMM-yyyy"));
            this.Session.Add("UnitType", this.RbUnitType.SelectedIndex);
            if (this.DrpDocumentType.SelectedIndex == 0)
            {
                this.Session.Add("OrderNo", 0);
                this.Session.Add("OrderBookerId", int.Parse(this.DrpOrderBooker.SelectedValue.ToString()));
                this.Session.Add("DeliveryManId", int.Parse(this.DrpDeliveryMan.SelectedValue.ToString()));
            }
            else
            {
                this.Session.Add("OrderNo", -2);
                this.Session.Add("OrderBookerId", int.Parse(this.DrpOrderBooker.SelectedValue.ToString()));
                this.Session.Add("DeliveryManId", int.Parse(this.DrpDeliveryMan.SelectedValue.ToString()));
            }
            base.Response.Redirect(string.Concat(new object[] { "~/Forms/frmOrderEntry.aspx?Status=", false, "&LevelType=3&LevelID=", base.Request.QueryString["LevelID"].ToString() }));
        }
    }

    protected void btnPost_Click(object sender, EventArgs e)
    {
        new CustomerDataController();
        OrderEntryController controller = new OrderEntryController();
        DataControl control = new DataControl();
        this.GrdFreeSKU.Visible = false;
        foreach (GridViewRow row in this.GrdOrder.Rows)
        {
            CheckBox box = (CheckBox)row.FindControl("ChbInvoice");
            if (box.Checked)
            {
                if (Convert.ToDateTime(this.Session["CurrentWorkDate"]) >= Convert.ToDateTime(ConvertDate.British_To_American2(row.Cells[5].Text)))
                {
                    DataTable table;
                    if (int.Parse(this.ddSearchType.SelectedValue.ToString()) == 0xd6)
                    {
                        table = controller.ConvertOrder_to_Invoice(int.Parse(this.drpDistributor.SelectedValue.ToString()), long.Parse(row.Cells[0].Text), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), long.Parse(row.Cells[4].Text), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), decimal.Parse(control.chkNull_0(row.Cells[6].Text)), decimal.Parse(control.chkNull_0(row.Cells[7].Text)), decimal.Parse(control.chkNull_0(row.Cells[8].Text)), decimal.Parse(control.chkNull_0(row.Cells[9].Text)), decimal.Parse(control.chkNull_0(row.Cells[10].Text)), 0x70, 0xd6, int.Parse(this.Session["UserId"].ToString()), row.Cells[11].Text);
                        if (table.Columns.Count <= 1)
                        {
                            continue;
                        }
                        this.GrdFreeSKU.DataSource = table;
                        this.GrdFreeSKU.DataBind();
                        this.GrdFreeSKU.Visible = true;
                        this.LoadPendingOrder();
                    }
                    else
                    {
                        table = controller.ConvertOrder_to_Invoice(int.Parse(this.drpDistributor.SelectedValue.ToString()), long.Parse(row.Cells[0].Text), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), long.Parse(row.Cells[4].Text), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), decimal.Parse(control.chkNull_0(row.Cells[6].Text)), decimal.Parse(control.chkNull_0(row.Cells[7].Text)), decimal.Parse(control.chkNull_0(row.Cells[8].Text)), decimal.Parse(control.chkNull_0(row.Cells[9].Text)), decimal.Parse(control.chkNull_0(row.Cells[10].Text)), 0x70, 0xd7, int.Parse(this.Session["UserId"].ToString()), row.Cells[11].Text);
                        if (table.Columns.Count <= 1)
                        {
                            continue;
                        }
                        this.GrdFreeSKU.DataSource = table;
                        this.GrdFreeSKU.DataBind();
                        this.GrdFreeSKU.Visible = true;
                        this.LoadPendingOrder();
                    }
                    return;
                }
                ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert('Order Date Can not be greater than current working date');", true);
                break;
            }
        }
        this.LoadPendingOrder();
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (this.CheckBox1.Checked)
        {
            foreach (GridViewRow row in this.GrdOrder.Rows)
            {
                CheckBox box = (CheckBox)row.FindControl("ChbInvoice");
                box.Checked = true;
            }
        }
        else
        {
            foreach (GridViewRow row2 in this.GrdOrder.Rows)
            {
                CheckBox box2 = (CheckBox)row2.FindControl("ChbInvoice");
                box2.Checked = false;
            }
        }
    }

    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadArea();
        this.LoadOrderBooker();
        this.LoadDeliveryman();
    }

    protected void DrpDocumentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.DrpDocumentType.SelectedIndex == 0)
        {
            this.txtToDate.Text = DateTime.Parse(this.Session["CurrentWorkDate"].ToString()).AddDays(1.0).ToString("dd-MMM-yyyy");
        }
        else
        {
            this.txtToDate.Text = ((DateTime)this.Session["CurrentWorkDate"]).ToString("dd-MMM-yyyy");
        }
    }

    protected void DrpRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadOrderBooker();
        this.LoadDeliveryman();
    }

    private void LoadArea()
    {
        if (this.drpDistributor.Items.Count > 0)
        {
            DataTable table = new DistributorAreaController().SelectDist_Area(-9223372036854775808L, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.drpDistributor.SelectedValue.ToString()), -2147483648, null, null);
            clsWebFormUtil.FillDropDownList(this.DrpRoute, table, 0, 6, true);
        }
        else
        {
            this.DrpRoute.Items.Clear();
        }
    }

    private void LoadDeliveryman()
    {
        if ((this.drpDistributor.Items.Count > 0) && (this.DrpRoute.Items.Count > 0))
        {
            DataTable table = new Distributor_UserController().SelectSaleForceAssignedArea(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpRoute.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpDeliveryMan, table, 0, 3, true);
        }
        else
        {
            this.DrpDeliveryMan.Items.Clear();
        }
    }

    private void LoadDistributor()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, table, 0, 2, true);
    }

    private void LoadOrderBooker()
    {
        if ((this.drpDistributor.Items.Count > 0) && (this.DrpRoute.Items.Count > 0))
        {
            DataTable table = new Distributor_UserController().SelectSaleForceAssignedArea(0x23, int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpRoute.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpOrderBooker, table, 0, 3, true);
        }
        else
        {
            this.DrpOrderBooker.Items.Clear();
        }
    }

    private void LoadPendingOrder()
    {
        DataTable table = new OrderEntryController().SelectPendingOrder(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpRoute.SelectedValue.ToString()), int.Parse(this.DrpPrincipal.SelectedValue.ToString()), int.Parse(this.DrpOrderBooker.SelectedValue.ToString()), int.Parse(this.DrpDeliveryMan.SelectedValue.ToString()), 0x6f, int.Parse(this.ddSearchType.SelectedValue.ToString()), int.Parse(this.Session["UserId"].ToString()), Convert.ToDateTime(this.txtToDate.Text));
        this.GrdOrder.DataSource = table;
        this.GrdOrder.DataBind();
    }

    private void LoadPrincipal()
    {
        DataTable table = new SKUPriceDetailController().SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, table, 0, 1, true);
    }

    private void LoadSalePerson()
    {
        if ((this.drpDistributor.Items.Count > 0) && (this.DrpRoute.Items.Count > 0))
        {
            DataTable table = new Distributor_UserController().SelectSaleForceAssignedArea(0x25, int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpRoute.SelectedValue.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpDeliveryMan, table, 0, 3, true);
            clsWebFormUtil.FillDropDownList(this.DrpOrderBooker, table, 0, 3, true);
        }
        else
        {
            this.DrpDeliveryMan.Items.Clear();
            this.DrpOrderBooker.Items.Clear();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadArea();
            this.LoadOrderBooker();
            this.LoadDeliveryman();
            this.LoadPrincipal();
            this.txtToDate.Text = DateTime.Parse(this.Session["CurrentWorkDate"].ToString()).ToString("dd-MMM-yyyy");
        }
    }
}