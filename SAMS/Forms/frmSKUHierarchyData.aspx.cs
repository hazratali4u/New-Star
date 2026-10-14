using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmSKUHierarchyData : System.Web.UI.Page
{
    private static int BrandId;
    private static int CategoryId;
    private static int DivisionId;
    private SkuHierarchyController mController = new SkuHierarchyController();
    private static int PrincipalId;

    protected void btnSaveBrand_Click(object sender, EventArgs e)
    {
        GrdBrand.EditIndex = -1;
        this.lblErrorMsgBrand.Text = "";
        if (this.btnSaveBrand.Text == "New")
        {
            this.txtBrandCode.Text = this.GetAutoCode("BN", 0);
            this.txtBrandName.Enabled = true;
            this.txtBrandName.Focus();
            this.btnSaveBrand.Text = "Save";
            ScriptManager.GetCurrent(this.Page).SetFocus(this.ddBrandCategory);
        }
        else if (this.btnSaveBrand.Text == "Save")
        {
            if (this.txtBrandName.Text.Length == 0)
            {
                this.lblErrorMsgBrand.Text = "Must Enter Brand";
            }
            else
            {
                this.mController.InsertHierarchy(60, int.Parse(this.ddBrandCategory.SelectedValue.ToString()), this.txtBrandCode.Text, this.txtBrandName.Text, null, true, int.Parse(this.Session["CompanyId"].ToString()));
                this.SetAutoCode("BN", long.Parse(this.txtBrandCode.Text.Substring(2)));
                this.btnSaveBrand.Text = "New";
                this.txtBrandCode.Text = "";
                this.txtBrandName.Text = "";
                this.txtBrandName.Enabled = false;
                this.LoadBrand();
                this.lblErrorMsgBrand.Text = "";
            }
        }
        else if (this.btnSaveBrand.Text == "Update")
        {
            if (this.txtBrandName.Text.Length == 0)
            {
                this.lblErrorMsgBrand.Text = "Must Enter Brand";
            }
            else
            {
                this.mController.UpdateHierarchy(60, BrandId, int.Parse(this.ddBrandCategory.SelectedValue.ToString()), this.txtBrandCode.Text, this.txtBrandName.Text, null, true, int.Parse(this.Session["CompanyId"].ToString()));
                this.btnSaveBrand.Text = "New";
                this.txtBrandCode.Text = "";
                this.txtBrandName.Text = "";
                this.txtBrandName.Enabled = false;
                this.LoadBrand();
            }
        }
    }

    protected void btnSaveCategory_Click(object sender, EventArgs e)
    {
        GrdCategory.EditIndex = -1;
        this.lblErrorMsgCategory.Text = "";
        if (this.btnSaveCategory.Text == "New")
        {
            this.txtCategoryCode.Text = this.GetAutoCode("CA", 0);
            this.txtCategoryName.Enabled = true;
            this.txtCategoryName.Focus();
            this.btnSaveCategory.Text = "Save";
            ScriptManager.GetCurrent(this.Page).SetFocus(this.ddCategoryDivision);
        }
        else if (this.btnSaveCategory.Text == "Save")
        {
            if (this.txtCategoryName.Text.Length <= 0)
            {
                this.lblErrorMsgCategory.Text = "Must Enter Category";
            }
            else
            {
                this.mController.InsertHierarchy(0x3b, int.Parse(this.ddCategoryDivision.SelectedValue.ToString()), this.txtCategoryCode.Text, this.txtCategoryName.Text, null, true, int.Parse(this.Session["CompanyId"].ToString()));
                this.SetAutoCode("CA", long.Parse(this.txtCategoryCode.Text.Substring(2)));
                this.btnSaveCategory.Text = "New";
                this.txtCategoryCode.Text = "";
                this.txtCategoryName.Text = "";
                this.txtCategoryName.Enabled = false;
                this.LoadCategroy();
                this.lblErrorMsgCategory.Text = "";
            }
        }
        else if (this.btnSaveCategory.Text == "Update")
        {
            if (this.txtCategoryName.Text.Length <= 0)
            {
                this.lblErrorMsgCategory.Text = "Must Enter Category";
            }
            else
            {
                this.mController.UpdateHierarchy(0x3b, CategoryId, int.Parse(this.ddCategoryDivision.SelectedValue.ToString()), this.txtCategoryCode.Text, this.txtCategoryName.Text, null, true, int.Parse(this.Session["CompanyId"].ToString()));
                this.btnSaveCategory.Text = "New";
                this.txtCategoryCode.Text = "";
                this.txtCategoryName.Text = "";
                this.txtCategoryName.Enabled = false;
                this.LoadCategroy();
            }
        }
    }

    protected void btnSaveDivison_Click(object sender, EventArgs e)
    {
        GrdDivision.EditIndex = -1;
        if (this.btnSaveDivison.Text == "New")
        {
            this.txtDivisionCode.Text = this.GetAutoCode("DV", 0);
            this.txtDivisionName.Enabled = true;
            this.txtDivisionName.Focus();
            this.btnSaveDivison.Text = "Save";
            ScriptManager.GetCurrent(this.Page).SetFocus(this.dddivisonPrincipal);
        }
        else if (this.btnSaveDivison.Text == "Save")
        {
            if (this.txtDivisionName.Text.Length == 0)
            {
                this.lblErrorMsgDivsion.Text = "Must Entry Division Name";
            }
            else
            {
                this.mController.InsertHierarchy(0x3a, int.Parse(this.dddivisonPrincipal.SelectedValue.ToString()), this.txtDivisionCode.Text, this.txtDivisionName.Text, null, true, int.Parse(this.Session["CompanyId"].ToString()));
                this.SetAutoCode("DV", long.Parse(this.txtDivisionCode.Text.Substring(2)));
                this.btnSaveDivison.Text = "New";
                this.txtDivisionCode.Text = "";
                this.txtDivisionName.Text = "";
                this.txtDivisionName.Enabled = false;
                this.LoadDivision();
                this.lblErrorMsgDivsion.Text = "";
            }
        }
        else if (this.btnSaveDivison.Text == "Update")
        {
            if (this.txtDivisionName.Text.Length == 0)
            {
                this.lblErrorMsgDivsion.Text = "Must Enter Division Name";
            }
            else
            {
                this.mController.UpdateHierarchy(0x3a, DivisionId, int.Parse(this.dddivisonPrincipal.SelectedValue.ToString()), this.txtDivisionCode.Text, this.txtDivisionName.Text, null, true, int.Parse(this.Session["CompanyId"].ToString()));
                this.btnSaveDivison.Text = "New";
                this.txtDivisionName.Text = "";
                this.txtDivisionName.Text = "";
                this.txtDivisionName.Enabled = false;
                this.LoadDivision();
            }
        }
    }

    protected void btnSavePrincipal_Click(object sender, EventArgs e)
    {
        GrdPrincipal.EditIndex = -1;
        this.lblErrorMsg.Text = "";
        if (this.btnSavePrincipal.Text == "New")
        {
            this.txtPrincipalCode.Text = this.GetAutoCode("SC", 0);
            this.txtPrincipalName.Enabled = true;
            this.txtPrincipalName.Focus();
            this.btnSavePrincipal.Text = "Save";
            ScriptManager.GetCurrent(this.Page).SetFocus(this.txtPrincipalName);
        }
        else if (this.btnSavePrincipal.Text == "Save")
        {
            if (this.txtPrincipalName.Text.Length == 0)
            {
                this.lblErrorMsg.Text = "Must Enter Principal Name";
            }
            else
            {
                this.mController.InsertHierarchy(0x39, -2147483648, this.txtPrincipalCode.Text, this.txtPrincipalName.Text, null, true, int.Parse(this.Session["CompanyId"].ToString()), this.ChIsMunalDiscount.Checked);
                this.SetAutoCode("SC", long.Parse(this.txtPrincipalCode.Text.Substring(2)));
                this.btnSavePrincipal.Text = "New";
                this.txtPrincipalCode.Text = "";
                this.txtPrincipalName.Text = "";
                this.txtPrincipalName.Enabled = false;
                this.LoadPrincipal();
            }
        }
        else if (this.btnSavePrincipal.Text == "Update")
        {
            if (this.txtPrincipalName.Text.Length == 0)
            {
                this.lblErrorMsg.Text = "Must Enter Principal Name";
            }
            else
            {
                this.mController.UpdateHierarchy(0x39, PrincipalId, -2147483648, this.txtPrincipalCode.Text, this.txtPrincipalName.Text, null, true, int.Parse(this.Session["CompanyId"].ToString()), this.ChIsMunalDiscount.Checked);
                this.btnSavePrincipal.Text = "New";
                this.txtPrincipalCode.Text = "";
                this.txtPrincipalName.Text = "";
                this.txtPrincipalName.Enabled = false;
                this.LoadPrincipal();
            }
        }
    }

    protected void ddBrandCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadBrand();
    }

    protected void ddCategoryDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadCategroy();
    }

    protected void dddivisonPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadDivision();
    }

    protected void DrpBrandDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadBrandCategory();
        this.LoadBrand();
    }

    protected void DrpBrandPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadBrandDivision();
        this.LoadBrandCategory();
        this.LoadBrand();
    }

    protected void DrpCategoryPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadCategoryDivision();
        this.LoadCategroy();
    }

    private string GetAutoCode(string PreeFix, int CodeType)
    {
        SETTINGS_TABLE_Controller controller = new SETTINGS_TABLE_Controller();
        return controller.GetAutoCode(PreeFix, CodeType, -9223372036854775808L);
    }

    protected void GrdBrand_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GrdBrand.PageIndex = e.NewPageIndex;
        this.LoadBrand();
    }

    protected void GrdBrand_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SkuController controller = new SkuController();
        BrandId = int.Parse(this.GrdBrand.Rows[e.RowIndex].Cells[0].Text);
        if (controller.SelectSkuInfo(-2147483648, -2147483648, -2147483648, BrandId, -2147483648).Rows.Count > 0)
        {
            this.lblErrorMsgBrand.Text = "Wrong Command: first delete associated SKUS";
        }
        else
        {
            this.mController.UpdateHierarchy(60, BrandId, -2147483648, null, null, null, false, int.Parse(this.Session["CompanyId"].ToString()));
            this.LoadBrand();
        }
    }

    protected void GrdBrand_RowEditing(object sender, GridViewEditEventArgs e)
    {
        BrandId = int.Parse(this.GrdBrand.Rows[e.NewEditIndex].Cells[0].Text);
        this.txtBrandCode.Text = this.GrdBrand.Rows[e.NewEditIndex].Cells[1].Text;
        this.txtBrandName.Text = this.GrdBrand.Rows[e.NewEditIndex].Cells[2].Text;
        this.txtBrandName.Enabled = true;
        this.btnSaveBrand.Text = "Update";
    }

    protected void GrdCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GrdCategory.PageIndex = e.NewPageIndex;
        this.LoadCategroy();
    }

    protected void GrdCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        CategoryId = int.Parse(this.GrdCategory.Rows[e.RowIndex].Cells[0].Text);
        if (this.mController.SelectSkuHierarchy(60, CategoryId).Rows.Count > 0)
        {
            this.lblErrorMsgCategory.Text = "Wrong Command: first delete associated Brand";
        }
        else
        {
            this.mController.UpdateHierarchy(0x3b, CategoryId, -2147483648, null, null, null, false, int.Parse(this.Session["CompanyId"].ToString()));
            this.LoadCategroy();
        }
    }

    protected void GrdCategory_RowEditing(object sender, GridViewEditEventArgs e)
    {
        CategoryId = int.Parse(this.GrdCategory.Rows[e.NewEditIndex].Cells[0].Text);
        this.txtCategoryCode.Text = this.GrdCategory.Rows[e.NewEditIndex].Cells[1].Text;
        this.txtCategoryName.Text = this.GrdCategory.Rows[e.NewEditIndex].Cells[2].Text;
        this.txtCategoryName.Enabled = true;
        this.btnSaveCategory.Text = "Update";
    }

    protected void GrdDivision_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GrdDivision.PageIndex = e.NewPageIndex;
        this.LoadDivision();
    }

    protected void GrdDivision_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DivisionId = int.Parse(this.GrdDivision.Rows[e.RowIndex].Cells[0].Text);
        if (this.mController.SelectSkuHierarchy(0x3b, DivisionId).Rows.Count > 0)
        {
            this.lblErrorMsgDivsion.Text = "Wrong Command: first delete associated category";
        }
        else
        {
            this.mController.UpdateHierarchy(0x3a, DivisionId, -2147483648, null, null, null, false, int.Parse(this.Session["CompanyId"].ToString()));
            this.LoadDivision();
            this.lblErrorMsgDivsion.Text = "";
        }
    }

    protected void GrdDivision_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DivisionId = int.Parse(this.GrdDivision.Rows[e.NewEditIndex].Cells[0].Text);
        this.txtDivisionCode.Text = this.GrdDivision.Rows[e.NewEditIndex].Cells[1].Text;
        this.txtDivisionName.Text = this.GrdDivision.Rows[e.NewEditIndex].Cells[2].Text;
        this.txtDivisionName.Enabled = true;
        this.btnSaveDivison.Text = "Update";
    }

    protected void GrdPrincipal_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GrdPrincipal.PageIndex = e.NewPageIndex;
        this.LoadPrincipal();
    }

    protected void GrdPrincipal_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        PrincipalId = int.Parse(this.GrdPrincipal.Rows[e.RowIndex].Cells[0].Text);
        if (this.mController.SelectSkuHierarchy(0x3a, PrincipalId).Rows.Count > 0)
        {
            this.lblErrorMsg.Text = "Wrong Command: first delete associated division";
        }
        else
        {
            this.mController.UpdateHierarchy(0x39, PrincipalId, -2147483648, null, null, null, false, int.Parse(this.Session["CompanyId"].ToString()));
            this.LoadPrincipal();
            this.lblErrorMsg.Text = "";
        }
    }

    protected void GrdPrincipal_RowEditing(object sender, GridViewEditEventArgs e)
    {
        PrincipalId = int.Parse(this.GrdPrincipal.Rows[e.NewEditIndex].Cells[0].Text);
        this.txtPrincipalCode.Text = this.GrdPrincipal.Rows[e.NewEditIndex].Cells[1].Text;
        this.txtPrincipalName.Text = this.GrdPrincipal.Rows[e.NewEditIndex].Cells[2].Text;
        this.txtPrincipalName.Enabled = true;
        this.btnSavePrincipal.Text = "Update";
    }

    private void LoadBrand()
    {
        if (this.ddBrandCategory.Items.Count > 0)
        {
            DataTable table = this.mController.SelectSkuHierarchy(60, -2147483648, int.Parse(this.ddBrandCategory.SelectedValue.ToString()), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
            this.GrdBrand.DataSource = table;
            this.GrdBrand.Columns[0].Visible = true;
            this.GrdBrand.DataBind();
            this.GrdBrand.Columns[0].Visible = false;
        }
    }

    private void LoadBrandCategory()
    {
        if (this.DrpBrandDivision.Items.Count > 0)
        {
            DataTable table = this.mController.SelectSkuHierarchy(0x3b, -2147483648, int.Parse(this.DrpBrandDivision.SelectedValue.ToString()), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.ddBrandCategory, table, 0, 3, true);
        }
    }

    private void LoadBrandDivision()
    {
        if (this.DrpBrandPrincipal.Items.Count > 0)
        {
            DataTable table = this.mController.SelectSkuHierarchy(0x3a, -2147483648, int.Parse(this.DrpBrandPrincipal.SelectedValue.ToString()), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpBrandDivision, table, 0, 3, true);
        }
    }

    private void LoadCategoryDivision()
    {
        DataTable table = this.mController.SelectSkuHierarchy(0x3a, -2147483648, int.Parse(this.DrpCategoryPrincipal.SelectedValue.ToString()), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.ddCategoryDivision, table, 0, 3, true);
    }

    private void LoadCategroy()
    {
        if (this.ddCategoryDivision.Items.Count > 0)
        {
            DataTable table = this.mController.SelectSkuHierarchy(0x3b, -2147483648, int.Parse(this.ddCategoryDivision.SelectedValue.ToString()), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
            this.GrdCategory.DataSource = table;
            this.GrdCategory.Columns[0].Visible = true;
            this.GrdCategory.DataBind();
            this.GrdCategory.Columns[0].Visible = false;
        }
    }

    private void LoadDivision()
    {
        DataTable table = this.mController.SelectSkuHierarchy(0x3a, -2147483648, int.Parse(this.dddivisonPrincipal.SelectedValue.ToString()), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
        this.GrdDivision.DataSource = table;
        this.GrdDivision.Columns[0].Visible = true;
        this.GrdDivision.DataBind();
        this.GrdDivision.Columns[0].Visible = false;
    }

    private void LoadPrincipal()
    {
        DataTable table = this.mController.SelectSkuHierarchy(0x39, int.Parse(this.Session["CompanyId"].ToString()));
        this.GrdPrincipal.DataSource = table;
        this.GrdPrincipal.Columns[0].Visible = true;
        this.GrdPrincipal.DataBind();
        this.GrdPrincipal.Columns[0].Visible = false;
        clsWebFormUtil.FillDropDownList(this.dddivisonPrincipal, table, 0, 3, true);
        clsWebFormUtil.FillDropDownList(this.DrpCategoryPrincipal, table, 0, 3, true);
        clsWebFormUtil.FillDropDownList(this.DrpBrandPrincipal, table, 0, 3, true);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.LoadPrincipal();
            this.LoadDivision();
            this.LoadCategoryDivision();
            this.LoadBrandDivision();
            this.LoadCategroy();
            this.LoadBrandCategory();
            this.LoadBrand();            
        }
    }

    private void SetAutoCode(string PreeFix, long CValue)
    {
        new SETTINGS_TABLE_Controller().GetAutoCode(PreeFix, 1, CValue);
    }
}