using SAMS.BusinessLayer.Classes;
using System;
using System.Data;
using System.Text;

public partial class Forms_PageMaster : System.Web.UI.MasterPage
{
    private DistributorController CtlDist = new DistributorController();
    
    private string GetBreadCrumb(int ModuleID)
    {
        StringBuilder builder = new StringBuilder();
        if (base.Request.QueryString["LevelID"] != null)
        {
            DataTable breadCrumb = this.CtlDist.GetBreadCrumb(Convert.ToInt32(base.Request.QueryString["LevelID"]));
            builder.Append("<div>");
            builder.Append("<a href=\"Home.aspx\">");
            builder.Append("Home");
            builder.Append("</a>");
            if ((breadCrumb != null) && (breadCrumb.Rows.Count > 0))
            {
                if ((breadCrumb.Rows[0]["ID2"].ToString() != "") && (breadCrumb.Rows[0]["TYPE_ID2"].ToString() != "11"))
                {
                    if (breadCrumb.Rows[0]["TYPE_ID2"].ToString() == "12")
                    {
                        builder.Append("<a href=\"Level.aspx?LevelID=" + breadCrumb.Rows[0]["ID2"] + "&LevelType=1\">");
                    }
                    else if (breadCrumb.Rows[0]["TYPE_ID2"].ToString() == "14")
                    {
                        builder.Append(string.Concat(new object[] { "<a href=\"", breadCrumb.Rows[0]["KEY2"], "?LevelID=", breadCrumb.Rows[0]["ID2"], "&LevelType=3\">" }));
                    }
                    else
                    {
                        builder.Append("<a href=\"Level2.aspx?LevelID=" + breadCrumb.Rows[0]["ID4"] + "&LevelType=2\">");
                    }
                    builder.Append(breadCrumb.Rows[0]["DESCRIPTION2"].ToString());
                    builder.Append("</a>");
                }
                if ((breadCrumb.Rows[0]["ID3"].ToString() != "") && (breadCrumb.Rows[0]["TYPE_ID3"].ToString() != "11"))
                {
                    if (breadCrumb.Rows[0]["TYPE_ID3"].ToString() == "12")
                    {
                        builder.Append("<a href=\"Level.aspx?LevelID=" + breadCrumb.Rows[0]["ID3"] + "&LevelType=1\">");
                    }
                    else if (breadCrumb.Rows[0]["TYPE_ID3"].ToString() == "14")
                    {
                        builder.Append(string.Concat(new object[] { "<a href=\"", breadCrumb.Rows[0]["KEY3"], "?LevelID=", breadCrumb.Rows[0]["ID3"], "&LevelType=3\">" }));
                    }
                    else
                    {
                        builder.Append("<a href=\"Level2.aspx?LevelID=" + breadCrumb.Rows[0]["ID3"] + "&LevelType=2\">");
                    }
                    builder.Append(breadCrumb.Rows[0]["DESCRIPTION3"].ToString());
                    builder.Append("</a>");
                }
                if ((breadCrumb.Rows[0]["ID4"].ToString() != "") && (breadCrumb.Rows[0]["TYPE_ID4"].ToString() != "11"))
                {
                    if (breadCrumb.Rows[0]["TYPE_ID4"].ToString() == "12")
                    {
                        builder.Append("<a href=\"Level.aspx?LevelID=" + breadCrumb.Rows[0]["ID4"] + "&LevelType=1\">");
                    }
                    else if (breadCrumb.Rows[0]["TYPE_ID4"].ToString() == "14")
                    {
                        builder.Append(string.Concat(new object[] { "<a href=\"", breadCrumb.Rows[0]["KEY4"], "?LevelID=", breadCrumb.Rows[0]["ID4"], "&LevelType=3\">" }));
                    }
                    else
                    {
                        builder.Append("<a href=\"Level2.aspx?LevelID=" + breadCrumb.Rows[0]["ID4"] + "&LevelType=2\">");
                    }
                    builder.Append(breadCrumb.Rows[0]["DESCRIPTION4"]);
                    builder.Append("</a>");
                }
            }
            builder.Append("</div>");
        }
        return builder.ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BreadCum.Text = this.GetBreadCrumb(0);
        }
    }
}
