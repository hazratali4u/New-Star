using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmAccountHead : System.Web.UI.Page
{
    private static long AccountDetailTypeId;
    private static long AccountHeadId;
    private static long AccountSubTypeId;
    private static long AccountTypeId;
    private AccountHeadController MController = new AccountHeadController();
    private static string strCode;

    protected void btnAccountDetailType_Click(object sender, EventArgs e)
    {
        GridAccountHead.EditIndex = -1;
        if (this.btnAccountDetailType.Text == "New Detail Type")
        {
            this.btnAccountDetailType.Text = "Save Detail Type";
            this.drpAccountTypeDetail.Visible = false;
            this.btnSave.Enabled = false;
            this.btnAccountType.Enabled = false;
            this.btnAccountSubType.Enabled = false;
            this.txtADetailTypeCode.Visible = true;
            this.txtDetailTypeName.Visible = true;
            this.drpAccountTypeDetail.Visible = false;
            this.txtADetailTypeCode.Text = this.GetAutoCode(0x5d, long.Parse(this.ddAccountSubType.SelectedValue.ToString()));
            ScriptManager.GetCurrent(this.Page).SetFocus(this.txtADetailTypeCode);
        }
        else if (this.btnAccountDetailType.Text == "Save Detail Type")
        {
            if ((this.ddAccountType.Items.Count > 0) && (this.ddAccountSubType.Items.Count > 0))
            {
                this.MController.InsertAccountHead(int.Parse(this.Session["CompanyId"].ToString()), true, DateTime.Now, Configuration.DistributorId, 0x5d, long.Parse(this.ddAccountSubType.SelectedValue.ToString()), this.txtDetailTypeName.Text, this.txtADetailTypeCode.Text);
                this.ClearAll();
                this.GetDetailAccountType();
            }
        }
        else if (this.btnAccountDetailType.Text == "Edit")
        {
            this.btnAccountDetailType.Text = "Update";
            this.txtADetailTypeCode.Text = this.drpAccountTypeDetail.SelectedItem.Text.Substring(0, 2);
            this.txtDetailTypeName.Text = this.drpAccountTypeDetail.SelectedItem.Text.Substring(3);
            AccountDetailTypeId = long.Parse(this.drpAccountTypeDetail.SelectedValue.ToString());
            this.btnAccountType.Enabled = false;
            this.btnAccountSubType.Enabled = false;
            this.btnSave.Enabled = false;
            this.txtADetailTypeCode.Visible = true;
            this.txtDetailTypeName.Visible = true;
            this.drpAccountTypeDetail.Visible = false;
            ScriptManager.GetCurrent(this.Page).SetFocus(this.txtADetailTypeCode);
        }
        else if (this.btnAccountDetailType.Text == "Update")
        {
            this.MController.UpdateAccountHead(AccountDetailTypeId, (long)int.Parse(this.Session["CompanyId"].ToString()), true, DateTime.Now, Configuration.DistributorId, 0x5d, -9223372036854775808L, this.txtDetailTypeName.Text, this.txtADetailTypeCode.Text);
            this.ClearAll();
            this.GetDetailAccountType();
            this.GetAccountHead();
        }
    }

    protected void btnAccountSubType_Click(object sender, EventArgs e)
    {
        GridAccountHead.EditIndex = -1;
        if (this.btnAccountSubType.Text == "New Sub Type")
        {
            this.btnAccountSubType.Text = "Save Sub Type";
            this.ddAccountSubType.Visible = false;
            this.btnSave.Enabled = false;
            this.btnAccountType.Enabled = false;
            this.btnAccountDetailType.Enabled = false;
            this.txtSubTypeName.Visible = true;
            this.txtASubTypeCode.Visible = true;
            this.txtASubTypeCode.Text = this.GetAutoCode(0x5c, long.Parse(this.ddAccountType.SelectedValue.ToString()));
            ScriptManager.GetCurrent(this.Page).SetFocus(this.txtASubTypeCode);
        }
        else if (this.btnAccountSubType.Text == "Save Sub Type")
        {
            if (this.ddAccountType.Items.Count > 0)
            {
                this.MController.InsertAccountHead(1, true, DateTime.Now, Configuration.DistributorId, 0x5c, long.Parse(this.ddAccountType.SelectedValue.ToString()), this.txtSubTypeName.Text, this.txtASubTypeCode.Text);
                this.ClearAll();
                this.GetSubAccountType();
            }
        }
        else if (this.btnAccountSubType.Text == "Edit")
        {
            this.btnAccountSubType.Text = "Update";
            this.txtASubTypeCode.Text = this.ddAccountSubType.SelectedItem.Text.Substring(0, 2);
            this.txtSubTypeName.Text = this.ddAccountSubType.SelectedItem.Text.Substring(3);
            AccountSubTypeId = long.Parse(this.ddAccountSubType.SelectedValue.ToString());
            this.btnAccountType.Enabled = false;
            this.btnSave.Enabled = false;
            this.txtSubTypeName.Visible = true;
            this.txtASubTypeCode.Visible = true;
            this.ddAccountSubType.Visible = false;
            ScriptManager.GetCurrent(this.Page).SetFocus(this.txtASubTypeCode);
        }
        else if (this.btnAccountSubType.Text == "Update")
        {
            this.MController.UpdateAccountHead(AccountSubTypeId, 1L, true, DateTime.Now, Configuration.DistributorId, 0x5c, -9223372036854775808L, this.txtSubTypeName.Text, this.txtASubTypeCode.Text);
            this.ClearAll();
            this.GetAccountType();
            this.GetAccountHead();
        }
    }

    protected void btnAccountType_Click(object sender, EventArgs e)
    {
        GridAccountHead.EditIndex = -1;
        if (this.btnAccountType.Text == "New Account Type")
        {
            this.btnAccountType.Text = "Save Account Type";
            this.btnAccountSubType.Enabled = false;
            this.btnSave.Enabled = false;
            this.txtAtypeName.Visible = true;
            this.txtAtypeCode.Visible = true;
            this.ddAccountType.Visible = false;
            this.btnAccountDetailType.Enabled = false;
            this.txtAtypeCode.Text = this.GetAutoCode(0x5b, -9223372036854775808L);
            ScriptManager.GetCurrent(this.Page).SetFocus(this.txtAtypeCode);
        }
        else if (this.btnAccountType.Text == "Save Account Type")
        {
            this.MController.InsertAccountHead(1, true, DateTime.Now, Configuration.DistributorId, 0x5b, -9223372036854775808L, this.txtAtypeName.Text, this.txtAtypeCode.Text);
            this.ClearAll();
            this.GetAccountType();
            this.GetAccountHead();
        }
        else if (this.btnAccountType.Text == "Edit")
        {
            this.btnAccountType.Text = "Update";
            this.txtAtypeCode.Text = this.ddAccountType.SelectedItem.Text.Substring(0, 2);
            this.txtAtypeName.Text = this.ddAccountType.SelectedItem.Text.Substring(3);
            AccountTypeId = long.Parse(this.ddAccountType.SelectedValue.ToString());
            this.btnAccountSubType.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnAccountDetailType.Enabled = false;
            this.txtAtypeName.Visible = true;
            this.txtAtypeCode.Visible = true;
            this.ddAccountType.Visible = false;
            ScriptManager.GetCurrent(this.Page).SetFocus(this.txtAtypeCode);
        }
        else if (this.btnAccountType.Text == "Update")
        {
            this.MController.UpdateAccountHead(AccountTypeId, 1L, true, DateTime.Now, Configuration.DistributorId, 0x5b, -9223372036854775808L, this.txtAtypeName.Text, this.txtAtypeCode.Text);
            this.ClearAll();
            this.GetAccountType();
            this.GetAccountHead();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        GridAccountHead.EditIndex = -1;
        this.ClearAll();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        GridAccountHead.EditIndex = -1;
        if (this.ddAccountType.Items.Count == 0)
        {
            this.lblErrorMsg.Text = "Select Account Type";
        }
        else if (this.ddAccountSubType.Items.Count == 0)
        {
            this.lblErrorMsg.Text = "Select Account Sub Type";
        }
        else if (this.btnSave.Text == "New")
        {
            this.btnSave.Text = "Save";
            this.txtAccountCode.Text = this.GetAutoCode(0x5e, (long)int.Parse(this.drpAccountTypeDetail.SelectedValue.ToString()));
            ScriptManager.GetCurrent(this.Page).SetFocus(this.txtAccountCode);
        }
        else if (this.btnSave.Text == "Save")
        {
            this.MController.InsertAccountHead(int.Parse(this.Session["CompanyId"].ToString()), true, DateTime.Now, int.Parse(this.Session["DISTRIBUTOR_ID"].ToString()), 0x5e, long.Parse(this.drpAccountTypeDetail.SelectedValue.ToString()), this.txtAccountHead.Text, this.ddAccountType.SelectedItem.Text.Substring(0, 2) + this.ddAccountSubType.SelectedItem.Text.Substring(0, 2) + this.drpAccountTypeDetail.SelectedItem.Text.Substring(0, 2) + this.txtAccountCode.Text);
            this.ClearAll();
            this.GetAccountHead();
        }
        else
        {
            this.MController.UpdateAccountHead(AccountHeadId, (long)int.Parse(this.Session["CompanyId"].ToString()), this.ChbIsactive.Checked, DateTime.Now, int.Parse(this.Session["DISTRIBUTOR_ID"].ToString()), 0x5e, (long)int.Parse(this.drpAccountTypeDetail.SelectedValue.ToString()), this.txtAccountHead.Text, this.ddAccountType.SelectedItem.Text.Substring(0, 2) + this.ddAccountSubType.SelectedItem.Text.Substring(0, 2) + this.drpAccountTypeDetail.SelectedItem.Text.Substring(0, 2) + this.txtAccountCode.Text);
            this.ClearAll();
            this.GetAccountHead();
        }
    }

    private void ClearAll()
    {
        this.btnAccountType.Text = "New Account Type";
        this.btnAccountSubType.Text = "New Sub Type";
        this.btnAccountDetailType.Text = "New Detail Type";
        this.btnSave.Text = "New";
        this.txtAtypeName.Text = "";
        this.txtAtypeCode.Text = "";
        this.txtASubTypeCode.Text = "";
        this.txtSubTypeName.Text = "";
        this.txtADetailTypeCode.Text = "";
        this.txtDetailTypeName.Text = "";
        this.txtAccountHead.Text = "";
        this.txtADetailTypeCode.Text = "";
        this.txtAccountCode.Text = "";
        this.ddAccountType.Visible = true;
        this.ddAccountSubType.Visible = true;
        this.drpAccountTypeDetail.Visible = true;
        this.btnSave.Enabled = true;
        this.btnAccountType.Enabled = true;
        this.btnAccountSubType.Enabled = true;
        this.btnAccountDetailType.Enabled = true;
        this.txtAtypeCode.Visible = false;
        this.txtAtypeName.Visible = false;
        this.txtASubTypeCode.Visible = false;
        this.txtSubTypeName.Visible = false;
        this.txtADetailTypeCode.Visible = false;
        this.txtDetailTypeName.Visible = false;
        this.ChbIsactive.Checked = true;
    }

    protected void ddAccountSubType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetDetailAccountType();
        this.GetAccountHead();
    }

    protected void ddAccountType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetSubAccountType();
        this.GetDetailAccountType();
        this.GetAccountHead();
    }

    protected void drpAccountTypeDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetAccountHead();
    }

    private void GetAccountHead()
    {
        if (this.drpAccountTypeDetail.Items.Count > 0)
        {
            DataTable table = this.MController.SelectAccountHead(int.Parse(this.Session["CompanyId"].ToString()), -2147483648, 0x5e, int.Parse(this.drpAccountTypeDetail.SelectedValue.ToString()));
            this.GridAccountHead.DataSource = table;
            this.GridAccountHead.DataBind();
        }
        else
        {
            this.GridAccountHead.DataSource = null;
            this.GridAccountHead.DataBind();
        }
    }

    private void GetAccountType()
    {
        DataTable table = this.MController.SelectAccountHead(0x5b, -9223372036854775808L);
        clsWebFormUtil.FillDropDownList(this.ddAccountType, table, 0, 10, true);
    }

    private string GetAutoCode(int CodeType, long CValue)
    {
        DataTable table = new DataView(this.MController.SelectAccountHead(CodeType, CValue)) { Sort = "ACCOUNT_CODE" }.ToTable();
        if (CodeType != 0x5e)
        {
            if (table.Rows.Count <= 0)
            {
                return "01";
            }
            int num = Convert.ToInt16(table.Rows[table.Rows.Count - 1]["ACCOUNT_CODE"].ToString()) + 1;
            if (num.ToString().Length == 1)
            {
                return ("0" + num.ToString());
            }
            return num.ToString();
        }
        if (table.Rows.Count <= 0)
        {
            return "0001";
        }
        int num2 = Convert.ToInt32(table.Rows[table.Rows.Count - 1]["ACCOUNT_CODE"].ToString().Substring(6, 4)) + 1;
        if (num2.ToString().Length == 1)
        {
            return ("000" + num2.ToString());
        }
        if (num2.ToString().Length == 2)
        {
            return ("00" + num2.ToString());
        }
        if (num2.ToString().Length == 3)
        {
            return ("0" + num2.ToString());
        }
        return num2.ToString();
    }

    private void GetDetailAccountType()
    {
        if (this.ddAccountSubType.Items.Count > 0)
        {
            DataTable table = this.MController.SelectAccountHead(0x5d, (long)int.Parse(this.ddAccountSubType.SelectedValue.ToString()));
            clsWebFormUtil.FillDropDownList(this.drpAccountTypeDetail, table, 0, 10, true);
        }
        else
        {
            this.drpAccountTypeDetail.Items.Clear();
        }
    }

    private void GetSubAccountType()
    {
        if (this.ddAccountType.Items.Count > 0)
        {
            DataTable table = this.MController.SelectAccountHead(0x5c, (long)int.Parse(this.ddAccountType.SelectedValue.ToString()));
            clsWebFormUtil.FillDropDownList(this.ddAccountSubType, table, 0, 10, true);
        }
        else
        {
            this.ddAccountSubType.Items.Clear();
        }
    }

    protected void GridAccountHead_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.ddAccountType.SelectedValue = this.GridAccountHead.Rows[e.NewEditIndex].Cells[0].Text;
        AccountTypeId = long.Parse(this.GridAccountHead.Rows[e.NewEditIndex].Cells[0].Text);
        AccountSubTypeId = long.Parse(this.GridAccountHead.Rows[e.NewEditIndex].Cells[1].Text);
        AccountDetailTypeId = long.Parse(this.GridAccountHead.Rows[e.NewEditIndex].Cells[2].Text);
        AccountHeadId = long.Parse(this.GridAccountHead.Rows[e.NewEditIndex].Cells[3].Text);
        this.GetSubAccountType();
        this.ddAccountSubType.SelectedValue = this.GridAccountHead.Rows[e.NewEditIndex].Cells[1].Text;
        this.GetDetailAccountType();
        this.drpAccountTypeDetail.SelectedValue = this.GridAccountHead.Rows[e.NewEditIndex].Cells[2].Text;
        this.txtAccountCode.Text = this.GridAccountHead.Rows[e.NewEditIndex].Cells[7].Text.Substring(6, 4);
        this.txtAccountHead.Text = this.GridAccountHead.Rows[e.NewEditIndex].Cells[7].Text.Substring(11);
        this.btnAccountSubType.Text = "Edit";
        this.btnAccountType.Text = "Edit";
        this.btnAccountDetailType.Text = "Edit";
        this.btnSave.Text = "Update";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.GetAccountType();
            this.GetSubAccountType();
            this.GetDetailAccountType();
            this.GetAccountHead();
        }
    }

    protected void txtASubTypeCode_TextChanged(object sender, EventArgs e)
    {
    }
}