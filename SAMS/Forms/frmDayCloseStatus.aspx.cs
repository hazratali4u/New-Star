using System;
using System.Data;
using System.Web.UI;
using SAMS.BusinessLayer.Classes;

public partial class Forms_frmDayCloseStatus : System.Web.UI.Page
{
    private DistributorController mController = new DistributorController();

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.Button1.Visible)
        {
            SAMSUserController controller = new SAMSUserController();
            if (!controller.UspDayClose(DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), int.Parse(this.Session["DISTRIBUTOR_ID"].ToString()), int.Parse(this.Session["UserID"].ToString())))
            {
                ScriptManager.RegisterStartupScript((Page)this, base.GetType(), "msg", "alert(' Some error in day Close Contact System Administrator');", true);
            }
            else
            {
                this.Session.Clear();
                base.Response.Redirect("~/Login.aspx?Status=" + false);
            }
        }
    }

    private void LastClosedDay(int UserId, int p_Distributor)
    {
        DataTable table = new SAMSUserController().SelectMaxDayClose(UserId, p_Distributor);
        if (table.Rows.Count > 0)
        {
            this.Session.Add("CurrentWorkDate", DateTime.Parse(table.Rows[0]["CLOSING_DATE"].ToString()));
            this.Button1.Visible = true;
        }
        else
        {
            this.Session.Add("CurrentWorkDate", DateTime.Now);
        }
        DataTable table2 = this.mController.MaxDayClose(int.Parse(this.Session["UserId"].ToString()));
        this.Grid_Hierarchy.DataSource = table2;
        this.Grid_Hierarchy.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.LastClosedDay(int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["Distributor_Id"].ToString()));
        }
    }
}