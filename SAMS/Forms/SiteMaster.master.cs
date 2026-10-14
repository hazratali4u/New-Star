using SAMS.BusinessLayer.Classes;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Forms_SiteMaster : System.Web.UI.MasterPage
{
    private MenuController MenuCtl = new MenuController();
    
    protected void gvMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            base.Response.Redirect("Menu.aspx?mode=edit&LevelID=" + e.CommandArgument.ToString() + "&LevelType=1");
        }
        else if (e.CommandName == "view")
        {
            base.Response.Redirect("Level.aspx?LevelID=" + e.CommandArgument.ToString() + "&LevelType=1");
        }
        else if (e.CommandName == "delete")
        {
            if (this.MenuCtl.DeleteMenuLevel(Convert.ToInt32(e.CommandArgument)).Rows[0]["Message"].ToString() != "NO")
            {
                base.Response.Redirect("Home.aspx?");
            }
            else
            {
                base.Session.Add("Message", "Can not be deleted. This level has child levels.");
                base.Response.Redirect("Home.aspx?");
            }
        }
    }

    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int num = (int)base.Session["RoleID"];
            LinkButton button = (LinkButton)e.Row.FindControl("btnEdit");
            LinkButton button2 = (LinkButton)e.Row.FindControl("btnDelete");
            LinkButton button3 = (LinkButton)e.Row.FindControl("btnView");
            if (num != 1)
            {
                button.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                this.imgAddMenu.Visible = false;
            }
        }
    }

    protected void gvSubMenu1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            base.Response.Redirect("Menu.aspx?mode=edit&LevelID=" + e.CommandArgument.ToString() + "&LevelType=2");
        }
        else if (e.CommandName == "view")
        {
            base.Response.Redirect("Level2.aspx?LevelID=" + e.CommandArgument.ToString() + "&LevelType=2");
        }
        else if (e.CommandName == "delete")
        {
            DataTable table = this.MenuCtl.DeleteMenuLevel(Convert.ToInt32(e.CommandArgument));
            if (table.Rows[0]["Message"].ToString() != "NO")
            {
                if (base.Request.QueryString["LevelID"] != null)
                {
                    base.Response.Redirect("Home.aspx?LevelID=" + table.Rows[0]["Message"].ToString() + "&LevelType=" + base.Request.QueryString["LevelType"]);
                }
                else
                {
                    base.Response.Redirect("Home.aspx?");
                }
            }
            else
            {
                base.Session.Add("Message", "Can not be deleted. This level has child levels.");
                if (base.Request.QueryString["LevelID"] != null)
                {
                    base.Response.Redirect("Home.aspx?LevelID=" + base.Request.QueryString["LevelID"].ToString() + "&LevelType=" + base.Request.QueryString["LevelType"]);
                }
                else
                {
                    base.Response.Redirect("Home.aspx?");
                }
            }
        }
    }

    protected void gvSubMenu1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int num = (int)base.Session["RoleID"];
            LinkButton button = (LinkButton)e.Row.FindControl("btnEdit");
            LinkButton button2 = (LinkButton)e.Row.FindControl("btnDelete");
            LinkButton button3 = (LinkButton)e.Row.FindControl("btnView");
            if (num != 1)
            {
                button.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                this.imgAddMenu.Visible = false;
            }
        }
    }

    protected void gvSubMenu2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            base.Response.Redirect("Menu.aspx?mode=edit&LevelID=" + e.CommandArgument.ToString() + "&LevelType=3");
        }
        else if (e.CommandName == "view")
        {
            GridViewRow namingContainer = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
            int rowIndex = namingContainer.RowIndex;
            base.Response.Redirect(this.gvSubMenu2.DataKeys[rowIndex]["MODULE_ID"].ToString() + "?LevelType=3&LevelID=" + e.CommandArgument.ToString());
        }
        else if (e.CommandName == "delete")
        {
            DataTable table = this.MenuCtl.DeleteMenuLevel(Convert.ToInt32(e.CommandArgument));
            if (table.Rows[0]["Message"].ToString() != "NO")
            {
                if (base.Request.QueryString["LevelID"] != null)
                {
                    base.Response.Redirect("Home.aspx?LevelID=" + table.Rows[0]["Message"].ToString() + "&LevelType=" + base.Request.QueryString["LevelType"]);
                }
                else
                {
                    base.Response.Redirect("Home.aspx?");
                }
            }
            else
            {
                base.Session.Add("Message", "Can not be deleted. This level has child levels.");
                if (base.Request.QueryString["LevelID"] != null)
                {
                    base.Response.Redirect("Home.aspx?LevelID=" + base.Request.QueryString["LevelID"].ToString() + "&LevelType=" + base.Request.QueryString["LevelType"]);
                }
                else
                {
                    base.Response.Redirect("Home.aspx?");
                }
            }
        }
    }

    protected void gvSubMenu2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int num = (int)base.Session["RoleID"];
            LinkButton button = (LinkButton)e.Row.FindControl("btnEdit");
            LinkButton button2 = (LinkButton)e.Row.FindControl("btnDelete");
            if (num != 1)
            {
                button.Visible = false;
                button2.Visible = false;
                this.imgAddMenu.Visible = false;
            }
        }
    }

    protected void imgAddMenu_Click(object sender, EventArgs e)
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

    private void LoadMainMenu(int RoleID, int TypeID, int ModuleID)
    {
        DataTable table = new RoleManagementController().SelectRoleWiseModule(RoleID, TypeID, ModuleID);
        if (table != null)
        {
            this.gvMain.DataSource = table;
            this.gvMain.DataBind();
        }
    }

    private void LoadSubMenu1(int RoleID, int TypeID, int ModuleID)
    {
        DataTable table = new RoleManagementController().SelectRoleWiseModule(RoleID, TypeID, ModuleID);
        if (table != null)
        {
            this.gvSubMenu1.DataSource = table;
            this.gvSubMenu1.DataBind();
        }
    }

    private void LoadSubMenu2(int RoleID, int TypeID, int ModuleID)
    {
        DataTable table = new RoleManagementController().SelectRoleWiseModule(RoleID, TypeID, ModuleID);
        if (table != null)
        {
            this.gvSubMenu2.DataSource = table;
            this.gvSubMenu2.DataBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            int roleID = (int)base.Session["RoleID"];
            this.lblUser.Text = base.Session["UserName"].ToString();
            this.lblWorkingDate.Text = ((DateTime)base.Session["CurrentWorkDate"]).ToString("dd-MMM-yyyy");
            if (base.Request.QueryString["LevelType"] == null)
            {
                this.LoadMainMenu(roleID, 2, -2147483648);
            }
            else if (base.Request.QueryString["LevelType"].ToString() == "1")
            {
                this.gvMain.DataSource = null;
                this.gvMain.DataBind();
                this.gvSubMenu2.DataSource = null;
                this.gvSubMenu2.DataBind();
                this.LoadSubMenu1(roleID, 3, Convert.ToInt32(base.Request.QueryString["LevelID"]));
            }
            else if (base.Request.QueryString["LevelType"].ToString() == "2")
            {
                this.imgAddMenu.Visible = false;
                this.gvMain.DataSource = null;
                this.gvMain.DataBind();
                this.gvSubMenu1.DataSource = null;
                this.gvSubMenu1.DataBind();
                this.LoadSubMenu2(roleID, 4, Convert.ToInt32(base.Request.QueryString["LevelID"]));
            }
            else if (base.Request.QueryString["LevelType"].ToString() == "3")
            {
                this.imgAddMenu.Visible = false;
                this.gvMain.DataSource = null;
                this.gvMain.DataBind();
            }
        }
    }
}
