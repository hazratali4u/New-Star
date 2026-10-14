using System;
using System.Data;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmSaleForceAreaAssignment : System.Web.UI.Page
{
    private Distributor_UserController UController = new Distributor_UserController();

    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.UController.UpdateSalesForceArea(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpSaleForce.SelectedValue.ToString()));
        for (int i = 0; i < this.ChbAreaList.Items.Count; i++)
        {
            if (this.ChbAreaList.Items[i].Selected)
            {
                this.UController.InsertSalesForceArea(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpSaleForce.SelectedValue.ToString()), int.Parse(this.ChbAreaList.Items[i].Value.ToString()));
            }
        }
        this.UController.UpdateSalesForcePrincipal(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpSaleForce.SelectedValue.ToString()));
        for (int j = 0; j < this.ChbPrincipal.Items.Count; j++)
        {
            if (this.ChbPrincipal.Items[j].Selected)
            {
                this.UController.InsertSalesForcePrincipal(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpSaleForce.SelectedValue.ToString()), int.Parse(this.ChbPrincipal.Items[j].Value.ToString()));
            }
        }
    }

    protected void DrpDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGrid();
        this.LoadAssisgned();
    }

    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGrid();
        this.LoadArea();
        this.LoadAssisgned();
    }

    protected void DrpSaleForce_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadAssisgned();
    }

    private void LoadArea()
    {
        if (this.drpDistributor.Items.Count > 0)
        {
            DataTable table = new DistributorAreaController().SelectDist_Area(-9223372036854775808L, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.drpDistributor.SelectedValue.ToString()), -2147483648, null, null);
            clsWebFormUtil.FillListBox(this.ChbAreaList, table, 0, 6, true);
        }
    }

    private void LoadAssisgned()
    {
        for (int i = 0; i < this.ChbAreaList.Items.Count; i++)
        {
            this.ChbAreaList.Items[i].Selected = false;
        }
        for (int j = 0; j < this.ChbPrincipal.Items.Count; j++)
        {
            this.ChbPrincipal.Items[j].Selected = false;
        }
        if (this.DrpSaleForce.Items.Count > 0)
        {
            DataTable table = this.UController.SelectSalesForceArea(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpSaleForce.SelectedValue.ToString()), -9223372036854775808L);
            for (int k = 0; k < table.Rows.Count; k++)
            {
                int num4 = int.Parse(table.Rows[k]["Area_Id"].ToString());
                for (int n = 0; n < this.ChbAreaList.Items.Count; n++)
                {
                    if (int.Parse(this.ChbAreaList.Items[n].Value) == num4)
                    {
                        this.ChbAreaList.Items[n].Selected = true;
                        break;
                    }
                }
            }
            DataTable table2 = this.UController.SelectSalesForcePrincipal(int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.DrpSaleForce.SelectedValue.ToString()), -2147483648);
            for (int m = 0; m < table2.Rows.Count; m++)
            {
                int num7 = int.Parse(table2.Rows[m]["PRINCIPAL_ID"].ToString());
                for (int num8 = 0; num8 < this.ChbPrincipal.Items.Count; num8++)
                {
                    if (int.Parse(this.ChbPrincipal.Items[num8].Value) == num7)
                    {
                        this.ChbPrincipal.Items[num8].Selected = true;
                        break;
                    }
                }
            }
        }
    }

    private void LoadDesignation()
    {
        DataTable table = new SLASHCodesController().SelectSlashCodes(-2147483648, null, 0x22, null, -2147483648, true);
        for (int i = 0; i < table.Rows.Count; i++)
        {
            if (((int.Parse(table.Rows[i]["REF_ID"].ToString()) == 0x23) || (int.Parse(table.Rows[i]["REF_ID"].ToString()) == 0x24)) || (int.Parse(table.Rows[i]["REF_ID"].ToString()) == 0x25))
            {
                this.DrpDesignation.Items.Add(new ListItem(table.Rows[i]["SLASH_DESC"].ToString(), table.Rows[i]["REF_ID"].ToString()));
            }
        }
    }

    private void LoadDISTRIBUTOR()
    {
        DataTable table = new DistributorController().SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, table, 0, 2, true);
    }

    protected void LoadGrid()
    {
        if ((this.drpDistributor.Items.Count > 0) && (this.DrpDesignation.Items.Count > 0))
        {
            DataTable table = this.UController.SelectDistributorUser(int.Parse(this.DrpDesignation.SelectedValue.ToString()), int.Parse(this.drpDistributor.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpSaleForce, table, 0, 6, true);
        }
    }

    private void LoadPrincipal()
    {
        DataTable table = new SKUPriceDetailController().SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillListBox(this.ChbPrincipal, table, 0, 1, true);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadDISTRIBUTOR();
            this.LoadDesignation();
            this.LoadGrid();
            this.LoadArea();
            this.LoadPrincipal();
            this.LoadAssisgned();
        }
    }
}