using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmBusinessType : System.Web.UI.Page
{
    private static int RefId;

    protected void btnSaveBusType_Click(object sender, EventArgs e)
    {
        GrdBusType.EditIndex = -1;
        SLASHCodesController controller = new SLASHCodesController();
        if (this.btnSaveBusType.Text == "New")
        {
            this.txtbustypeCode.Text = this.GetAutoCode("BS", 0, -9223372036854775808L);
            this.txtbustypeName.Enabled = true;
            this.txtbustypeName.Focus();
            this.btnSaveBusType.Text = "Save";
            ScriptManager.GetCurrent(this.Page).SetFocus(this.txtbustypeName);
        }
        else if (this.btnSaveBusType.Text == "Save")
        {
            if (this.txtbustypeName.Text.Length == 0)
            {
                this.lblErrorMsgDivsion.Text = "Must Entry Business Type";
            }
            else
            {
                controller.InsertSlashCodes(this.txtbustypeCode.Text, 0x2f, this.txtbustypeName.Text, 1, true);
                this.GetAutoCode("BS", 1, long.Parse(this.txtbustypeCode.Text.Substring(2)));
                this.LoadBusinessType();
                this.txtbustypeCode.Text = "";
                this.txtbustypeName.Text = "";
                this.txtbustypeName.Enabled = false;
                this.btnSaveBusType.Text = "New";
            }
        }
        else if (this.btnSaveBusType.Text == "Update")
        {
            controller.UpdateSlashCodes(RefId, null, 0x2f, this.txtbustypeName.Text, 1, true, Constants.DateNullValue);
            this.LoadBusinessType();
            this.txtbustypeCode.Text = "";
            this.txtbustypeName.Text = "";
            this.txtbustypeName.Enabled = false;
            this.btnSaveBusType.Text = "New";
        }
    }

    protected void btnSaveCategory_Click(object sender, EventArgs e)
    {
        GrdVolumeClass.EditIndex = -1;
        SLASHCodesController controller = new SLASHCodesController();
        if (this.btnSaveCategory.Text == "New")
        {
            this.txtCategoryCode.Text = this.GetAutoCode("VL", 0, -9223372036854775808L);
            this.txtCategoryName.Enabled = true;
            this.txtCategoryName.Focus();
            this.btnSaveCategory.Text = "Save";
            ScriptManager.GetCurrent(this.Page).SetFocus(this.txtCategoryName);
        }
        else if (this.btnSaveCategory.Text == "Save")
        {
            if (this.txtCategoryName.Text.Length == 0)
            {
                this.lblErrorMsgCategory.Text = "Must Entry Volume Class";
            }
            else
            {
                controller.InsertSlashCodes(this.txtCategoryCode.Text, 0x30, this.txtCategoryName.Text, 1, true);
                this.GetAutoCode("VL", 1, long.Parse(this.txtCategoryCode.Text.Substring(2)));
                this.LoadVolumClass();
                this.txtCategoryCode.Text = "";
                this.txtCategoryName.Text = "";
                this.txtCategoryName.Enabled = false;
                this.btnSaveCategory.Text = "New";
            }
        }
        else if (this.btnSaveCategory.Text == "Update")
        {
            controller.UpdateSlashCodes(RefId, null, 0x30, this.txtCategoryName.Text, 1, true, Constants.DateNullValue);
            this.LoadVolumClass();
            this.txtCategoryCode.Text = "";
            this.txtCategoryName.Text = "";
            this.txtCategoryName.Enabled = false;
            this.btnSaveCategory.Text = "New";
        }
    }

    protected void btnSaveChannelType_Click(object sender, EventArgs e)
    {
        grdChannelData.EditIndex = -1;
        SLASHCodesController controller = new SLASHCodesController();
        if (this.btnSaveChannelType.Text == "New")
        {
            this.txtChannelCode.Text = this.GetAutoCode("CH", 0, -9223372036854775808L);
            this.txtChannelName.Enabled = true;
            this.txtChannelName.Focus();
            this.btnSaveChannelType.Text = "Save";
            ScriptManager.GetCurrent(this.Page).SetFocus(this.txtChannelName);
        }
        else if (this.btnSaveChannelType.Text == "Save")
        {
            if (this.txtChannelName.Text.Length == 0)
            {
                this.lblErrorMsg.Text = "Must Entry Channel Name";
            }
            else
            {
                controller.InsertSlashCodes(this.txtChannelCode.Text, 0x2e, this.txtChannelName.Text, 1, true);
                this.GetAutoCode("CH", 1, long.Parse(this.txtChannelCode.Text.Substring(2)));
                this.LoadChannelType();
                this.txtChannelCode.Text = "";
                this.txtChannelName.Text = "";
                this.txtChannelName.Enabled = false;
                this.btnSaveChannelType.Text = "New";
                this.lblErrorMsg.Text = "";
            }
        }
        else if (this.btnSaveChannelType.Text == "Update")
        {
            controller.UpdateSlashCodes(RefId, null, 0x2e, this.txtChannelName.Text, 1, true, Constants.DateNullValue);
            this.LoadChannelType();
            this.txtChannelCode.Text = "";
            this.txtChannelName.Text = "";
            this.txtChannelName.Enabled = false;
            this.btnSaveChannelType.Text = "New";
        }
    }

    private string GetAutoCode(string PreeFix, int CodeType, long CValue)
    {
        SETTINGS_TABLE_Controller controller = new SETTINGS_TABLE_Controller();
        return controller.GetAutoCode(PreeFix, CodeType, CValue);
    }

    protected void GrdBusType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GrdBusType.PageIndex = e.NewPageIndex;
        this.LoadBusinessType();
    }

    protected void GrdBusType_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SLASHCodesController controller = new SLASHCodesController();
        RefId = int.Parse(this.GrdBusType.Rows[e.RowIndex].Cells[0].Text);
        controller.UpdateSlashCodes(RefId, null, 0x2f, null, 1, false, Constants.DateNullValue);
        this.LoadBusinessType();
    }

    protected void GrdBusType_RowEditing(object sender, GridViewEditEventArgs e)
    {
        RefId = int.Parse(this.GrdBusType.Rows[e.NewEditIndex].Cells[0].Text);
        this.txtbustypeCode.Text = this.GrdBusType.Rows[e.NewEditIndex].Cells[1].Text;
        this.txtbustypeName.Text = this.GrdBusType.Rows[e.NewEditIndex].Cells[2].Text;
        this.txtbustypeName.Enabled = true;
        this.btnSaveBusType.Text = "Update";
    }

    protected void grdChannelData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.grdChannelData.PageIndex = e.NewPageIndex;
        this.LoadChannelType();
    }

    protected void grdChannelData_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SLASHCodesController controller = new SLASHCodesController();
        RefId = int.Parse(this.grdChannelData.Rows[e.RowIndex].Cells[0].Text);
        controller.UpdateSlashCodes(RefId, null, 0x2e, null, 1, false, Constants.DateNullValue);
        this.LoadChannelType();
    }

    protected void grdChannelData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        RefId = int.Parse(this.grdChannelData.Rows[e.NewEditIndex].Cells[0].Text);
        this.txtChannelCode.Text = this.grdChannelData.Rows[e.NewEditIndex].Cells[1].Text;
        this.txtChannelName.Text = this.grdChannelData.Rows[e.NewEditIndex].Cells[2].Text;
        this.btnSaveChannelType.Text = "Update";
        this.txtChannelName.Enabled = true;
    }

    protected void GrdVolumeClass_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GrdVolumeClass.PageIndex = e.NewPageIndex;
        this.LoadVolumClass();
    }

    protected void GrdVolumeClass_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SLASHCodesController controller = new SLASHCodesController();
        RefId = int.Parse(this.GrdVolumeClass.Rows[e.RowIndex].Cells[0].Text);
        controller.UpdateSlashCodes(RefId, null, 0x30, null, 1, false, Constants.DateNullValue);
        this.LoadVolumClass();
    }

    protected void GrdVolumeClass_RowEditing(object sender, GridViewEditEventArgs e)
    {
        RefId = int.Parse(this.GrdVolumeClass.Rows[e.NewEditIndex].Cells[0].Text);
        this.txtCategoryCode.Text = this.GrdVolumeClass.Rows[e.NewEditIndex].Cells[1].Text;
        this.txtCategoryName.Text = this.GrdVolumeClass.Rows[e.NewEditIndex].Cells[2].Text;
        this.btnSaveCategory.Text = "Update";
        this.txtCategoryName.Enabled = true;
    }

    private void LoadBusinessType()
    {
        DataTable table = new SLASHCodesController().SelectSlashCodes(-2147483648, null, 0x2f, null, -2147483648, bool.Parse("True"));
        this.GrdBusType.DataSource = table.DefaultView;
        this.GrdBusType.DataBind();
    }

    private void LoadChannelType()
    {
        DataTable table = new SLASHCodesController().SelectSlashCodes(-2147483648, null, 0x2e, null, -2147483648, bool.Parse("True"));
        this.grdChannelData.DataSource = table.DefaultView;
        this.grdChannelData.DataBind();
    }

    private void LoadVolumClass()
    {
        DataTable table = new SLASHCodesController().SelectSlashCodes(-2147483648, null, 0x30, null, -2147483648, bool.Parse("True"));
        this.GrdVolumeClass.DataSource = table.DefaultView;
        this.GrdVolumeClass.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LoadChannelType();
            this.LoadBusinessType();
            this.LoadVolumClass();
        }
    }
}