using SAMS.BusinessLayer.Classes;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Forms_Menu : System.Web.UI.Page
{
    private MenuController MenuCtl = new MenuController();
    private RoleManagementController ObjRole = new RoleManagementController();

    private void AddLevel()
    {
        int num = 1;
        int num2 = 12;
        if (base.Request.QueryString["LevelID"] != null)
        {
            num = Convert.ToInt32(base.Request.QueryString["LevelID"]);
            num2 = 13;
        }
        if (this.MenuCtl.InsertMenuLevel(this.txtMenu.Text, num, num2))
        {
            if (base.Request.QueryString["LevelID"] != null)
            {
                base.Response.Redirect("Menu.aspx?LevelID=" + base.Request.QueryString["LevelID"] + "&LevelType=" + base.Request.QueryString["LevelType"]);
            }
            else
            {
                base.Response.Redirect("Menu.aspx?");
            }
        }
        else
        {
            this.lblError.Text = "Some error occured. Level not saved.";
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (base.Request.QueryString["mode"] != null)
        {
            this.EditLevel();
        }
        else
        {
            this.AddLevel();
        }
    }

    private void EditLevel()
    {
        if (this.MenuCtl.UpdateMenuLevel(Convert.ToInt32(this.hfModuleID.Value), this.txtMenu.Text, -2147483648, -2147483648))
        {
            foreach (GridViewRow row in this.gvMain.Rows)
            {
                GridView view = (GridView)row.FindControl("gvSubMenu");
                foreach (GridViewRow row2 in view.Rows)
                {
                    GridView view2 = (GridView)row2.FindControl("gvForms");
                    foreach (GridViewRow row3 in view2.Rows)
                    {
                        CheckBox box = (CheckBox)row3.FindControl("cbModule");
                        if (box.Checked)
                        {
                            HiddenField field = (HiddenField)row3.FindControl("hfMODULE_ID");
                            this.MenuCtl.UpdateMenuLevel(Convert.ToInt32(field.Value), null, Convert.ToInt32(this.hfModuleID.Value), -2147483648);
                        }
                    }
                }
            }
            base.Response.Redirect("Menu.aspx?mode=edit&LevelID=" + base.Request.QueryString["LevelID"] + "&LevelType=" + base.Request.QueryString["LevelType"]);
        }
        else
        {
            this.lblError.Text = "Some error occured. Level not updated.";
        }
    }

    protected void gvForms_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox box = (CheckBox)e.Row.FindControl("cbModule");
            HiddenField field = (HiddenField)e.Row.FindControl("hfParentID");
            if (field.Value == base.Request.QueryString["LevelID"].ToString())
            {
                box.Checked = true;
                box.Enabled = false;
            }
        }
    }

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView view = (GridView)e.Row.FindControl("gvSubMenu");
            int num = (int)this.Session["RoleID"];
            int num2 = Convert.ToInt32(((GridView)sender).DataKeys[e.Row.RowIndex].Value);
            DataTable table = this.ObjRole.SelectRoleWiseModule(num, 3, num2);
            if (table != null)
            {
                view.DataSource = table;
                view.DataBind();
            }
        }
    }

    protected void gvSubMenu_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView view = (GridView)e.Row.FindControl("gvForms");
            int num1 = (int)this.Session["RoleID"];
            int num = Convert.ToInt32(((GridView)sender).DataKeys[e.Row.RowIndex].Value);
            DataTable menuItem = this.MenuCtl.GetMenuItem(num);
            if (menuItem != null)
            {
                view.DataSource = menuItem;
                view.DataBind();
            }
        }
    }

    private void LoadMainMenu(int RoleID, int TypeID, int ModuleID)
    {
        DataTable table = new RoleManagementController().SelectRoleWiseModule(RoleID, TypeID, ModuleID);
        if (table != null)
        {
            this.gvMain.DataSource = table;
            this.gvMain.DataBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack && (base.Request.QueryString["mode"] != null))
        {
            DataTable table = this.MenuCtl.GetMenuLevel(Convert.ToInt32(base.Request.QueryString["LevelID"]), -2147483648, -2147483648);
            if (table.Rows.Count > 0)
            {
                this.txtMenu.Text = table.Rows[0]["MODULE_DESCRIPTION"].ToString();
                this.hfModuleID.Value = table.Rows[0]["MODULE_ID"].ToString();
                this.lblTitle.Text = "Edit Level";
            }
            if (base.Request.QueryString["LevelType"].ToString() == "2")
            {
                this.gvMain.Visible = true;
                this.lblFormTitle.Visible = true;
                int roleID = (int)this.Session["RoleID"];
                this.LoadMainMenu(roleID, 2, -2147483648);
            }
        }
    }
}