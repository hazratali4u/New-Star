using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Forms_frmSKUData : System.Web.UI.Page
{
    private DataControl dc = new DataControl();
    private DataTable m_dt;
    private static int m_sku_id;
    private DataTable m_SKUDt;
    private SKUsController mController = new SKUsController();
    private SkuHierarchyController mHer_Controller = new SkuHierarchyController();

    protected void btnSave_Click(object sender, EventArgs e)
    {
        grdSKUData.EditIndex = -1;
        bool flag = true;
        if (this.txtpacksize.Text.Length <= 0)
        {
            this.lblErrorMsg.Text = "Must Enter SKU Packsize";
        }
        else if (this.txtskucode.Text.Length <= 0)
        {
            this.lblErrorMsg.Text = "Must Enter SKU Code";
        }
        else if (this.txtskuname.Text.Length <= 0)
        {
            this.lblErrorMsg.Text = "Must Enter SKU Name";
        }
        else
        {
            if (this.btnSave.Text == "Save")
            {
                this.mController.InsertSKUS(flag, true, char.Parse(this.DrpSKUTaxType.SelectedValue.ToString()), int.Parse(this.ddskuPrincipal.SelectedValue.ToString()), int.Parse(this.ddskudivision.SelectedValue.ToString()), int.Parse(this.ddskucategory.SelectedValue.ToString()), int.Parse(this.ddskuBrand.SelectedValue.ToString()), -2147483648, 0M, 0M, short.Parse(this.dc.chkNull_0(this.txtunitincase.Text)), this.txtskucode.Text.ToUpper(), this.txtskuname.Text, null, this.txtpacksize.Text, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
                this.CLearAll();
            }
            else if (this.btnSave.Text == "Update")
            {
                this.mController.UpdateSKUS(flag, true, char.Parse(this.DrpSKUTaxType.SelectedValue.ToString()), int.Parse(this.ddskuPrincipal.SelectedValue.ToString()), int.Parse(this.ddskudivision.SelectedValue.ToString()), int.Parse(this.ddskucategory.SelectedValue.ToString()), int.Parse(this.ddskuBrand.SelectedValue.ToString()), -2147483648, 0M, 0M, short.Parse(this.dc.chkNull_0(this.txtunitincase.Text)), m_sku_id, this.txtskucode.Text.ToUpper(), this.txtskuname.Text, null, this.txtpacksize.Text, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
                this.CLearAll();
            }
            this.LoadData();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        this.LoadGrid();
    }

    private void CLearAll()
    {
        this.txtpacksize.Text = "";
        this.txtskucode.Text = "";
        this.txtunitincase.Text = "";
        this.txtskuname.Text = "";
        this.btnSave.Text = "Save";
        this.LoadData();
        this.LoadGrid();
    }

    protected void ddskucategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Populate_drpSKUBrand();
        this.LoadData();
        this.LoadGrid();
    }

    protected void ddskudivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Populate_drpSKUCategory();
        this.Populate_drpSKUBrand();
        this.LoadData();
        this.LoadGrid();
    }

    protected void ddskuPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Populate_drpSKUDivisions();
        this.Populate_drpSKUCategory();
        this.Populate_drpSKUBrand();
        this.LoadData();
        this.LoadGrid();
    }

    protected void grdSKUData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.grdSKUData.PageIndex = e.NewPageIndex;
        this.LoadGrid();
    }

    protected void grdSKUData_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        bool flag = bool.Parse(this.grdSKUData.Rows[e.RowIndex].Cells[14].Text);
        this.mController.UpdateSKUS(flag, false, '\0', -2147483648, -2147483648, -2147483648, -2147483648, -2147483648, -79228162514264337593543950335M, -79228162514264337593543950335M, -32768, int.Parse(this.grdSKUData.Rows[e.RowIndex].Cells[4].Text), null, null, null, null, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        this.LoadData();
        this.LoadGrid();
    }

    protected void grdSKUData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.ddskuPrincipal.SelectedValue = this.grdSKUData.Rows[e.NewEditIndex].Cells[0].Text;
        this.Populate_drpSKUDivisions();
        this.ddskudivision.SelectedValue = this.grdSKUData.Rows[e.NewEditIndex].Cells[1].Text;
        this.Populate_drpSKUCategory();
        this.ddskucategory.SelectedValue = this.grdSKUData.Rows[e.NewEditIndex].Cells[2].Text;
        this.Populate_drpSKUBrand();
        this.ddskuBrand.SelectedValue = this.grdSKUData.Rows[e.NewEditIndex].Cells[3].Text;
        m_sku_id = int.Parse(this.grdSKUData.Rows[e.NewEditIndex].Cells[4].Text);
        this.txtskucode.Text = this.grdSKUData.Rows[e.NewEditIndex].Cells[9].Text;
        this.txtskuname.Text = this.grdSKUData.Rows[e.NewEditIndex].Cells[10].Text;
        this.txtpacksize.Text = this.grdSKUData.Rows[e.NewEditIndex].Cells[11].Text;
        this.txtunitincase.Text = this.grdSKUData.Rows[e.NewEditIndex].Cells[12].Text;
        this.btnSave.Text = "Update";
    }

    private void LoadData()
    {
        this.m_SKUDt = new SkuController().SelectSkuInfo(int.Parse(this.ddskuPrincipal.SelectedValue.ToString()), int.Parse(this.ddskudivision.SelectedValue.ToString()), int.Parse(this.ddskucategory.SelectedValue.ToString()), -2147483648, int.Parse(this.Session["CompanyId"].ToString()));
        this.Session.Add("m_SKUDt", this.m_SKUDt);
    }

    private void LoadGrid()
    {
        this.m_SKUDt = (DataTable)this.Session["m_SKUDt"];
        switch (this.ddSearchType.SelectedIndex)
        {
            case 1:
                this.m_SKUDt.DefaultView.RowFilter = this.ddSearchType.SelectedValue.ToString() + " like '%" + this.txtSeach.Text + "%'";
                break;

            case 2:
                this.m_SKUDt.DefaultView.RowFilter = this.ddSearchType.SelectedValue.ToString() + " like '%" + this.txtSeach.Text + "%'";
                break;

            case 3:
                this.m_SKUDt.DefaultView.RowFilter = this.ddSearchType.SelectedValue.ToString() + " like '%" + this.txtSeach.Text + "%'";
                break;

            case 4:
                this.m_SKUDt.DefaultView.RowFilter = this.ddSearchType.SelectedValue.ToString() + " like '%" + this.txtSeach.Text + "%'";
                break;

            default:
                this.m_SKUDt.DefaultView.RowFilter = "SKU_CODE like '%%'";
                break;
        }
        this.grdSKUData.DataSource = this.m_SKUDt.DefaultView;
        this.grdSKUData.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.Populate_drpSKUCompany();
            this.Populate_drpSKUDivisions();
            this.Populate_drpSKUCategory();
            this.Populate_drpSKUBrand();
            this.LoadData();
            this.LoadGrid();
        }
    }

    private void Populate_drpSKUBrand()
    {
        if (this.ddskucategory.Items.Count > 0)
        {
            string s = this.ddskucategory.SelectedItem.Value;
            if (int.Parse(s) > 0)
            {
                this.m_dt = this.mHer_Controller.SelectSkuHierarchy(60, -2147483648, int.Parse(s), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
                clsWebFormUtil.FillDropDownList(this.ddskuBrand, this.m_dt, 0, 3, true);
            }
        }
        else
        {
            this.ddskuBrand.Items.Clear();
        }
    }

    private void Populate_drpSKUCategory()
    {
        if (this.ddskudivision.Items.Count > 0)
        {
            string s = this.ddskudivision.SelectedItem.Value;
            if (int.Parse(s) > 0)
            {
                this.m_dt = this.mHer_Controller.SelectSkuHierarchy(0x3b, -2147483648, int.Parse(s), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
                clsWebFormUtil.FillDropDownList(this.ddskucategory, this.m_dt, 0, 3, true);
            }
        }
        else
        {
            this.ddskucategory.Items.Clear();
        }
    }

    private void Populate_drpSKUCompany()
    {
        this.m_dt = this.mHer_Controller.SelectSkuHierarchy(0x39, -2147483648, -2147483648, null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.ddskuPrincipal, this.m_dt, 0, 3, true);
    }

    private void Populate_drpSKUDivisions()
    {
        if (this.ddskuPrincipal.Items.Count > 0)
        {
            string s = this.ddskuPrincipal.SelectedItem.Value;
            if (int.Parse(s) > 0)
            {
                this.m_dt = this.mHer_Controller.SelectSkuHierarchy(0x3a, -2147483648, int.Parse(s), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
                clsWebFormUtil.FillDropDownList(this.ddskudivision, this.m_dt, 0, 3, true);
            }
        }
        else
        {
            this.ddskudivision.Items.Clear();
        }
    }
}