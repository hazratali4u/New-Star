using System;
using System.Data;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmPromotionStep2 : System.Web.UI.Page
{
    protected void btnNext_Click(object sender, EventArgs e)
    {
        this.Collection();
    }

    protected void btnPromotion_Click(object sender, EventArgs e)
    {
        base.Response.Redirect("frmPromotionStep1.aspx?LevelType=3&LevelID=" + base.Request.QueryString["LevelID"].ToString());
    }

    protected void Collection()
    {
        try
        {
            SchemeCollection_Controller controller = new SchemeCollection_Controller();
            Scheme_Collection e_s = new Scheme_Collection();
            if (this.rBtnExisting.Checked)
            {
                clsListItems[] itemsArray1 = (clsListItems[])this.Session["SchemeListItems"];
                e_s.Scheme_ID = Convert.ToInt32(this.drpExisting.SelectedValue.ToString());
            }
            else
            {
                e_s.Scheme_ID = 0;
            }
            if (this.rBtnExisting.Checked)
            {
                e_s.Scheme_Code = this.drpExisting.SelectedValue;
                e_s.Scheme_Desc = this.drpExisting.SelectedValue;
            }
            else if (this.rBtnNew.Checked)
            {
                e_s.Scheme_Code = this.txtNew.Text;
                e_s.Scheme_Desc = this.txtNew.Text;
            }
            controller.Add(e_s);
            Promotion_Collection n_s = new Promotion_Collection();
            n_s.Dist_ID = (int)this.Session["DISTRIBUTOR_ID"];
            if (int.Parse(this.rdbbtncheck.SelectedItem.Value.ToString()) == 0)
            {
                n_s.Promotion_For = false;
            }
            else if (int.Parse(this.rdbbtncheck.SelectedItem.Value.ToString()) == 1)
            {
                n_s.Promotion_For = true;
            }
            n_s.Promotion_Code = this.txtPromotionName.Text;
            n_s.Promotion_Desc = this.txtPromotionDescription.Text;
            n_s.Claimable = this.chkClaimable.Checked;
            n_s.Start_Date = Convert.ToDateTime(this.txtStartDate.Text);
            if (this.txtEndDate.Text == "")
            {
                n_s.End_Date = DateTime.MaxValue;
            }
            else
            {
                n_s.End_Date = Convert.ToDateTime(this.txtEndDate.Text);
            }
            n_s.Is_Active = true;
            n_s.Promotion_Type = int.Parse(this.DrpPrincipal.SelectedValue.ToString());
            if (this.chkScheme.SelectedIndex == 0)
            {
                n_s.Is_Scheme = false;
            }
            else
            {
                n_s.Is_Scheme = true;
            }
            e_s.ObjPromotionCol_Cntrl = new PromotionCollections_Controller();
            e_s.ObjPromotionCol_Cntrl.Add_PCol(n_s);
            this.Session.Add("SchCtrl", controller);
            this.Session.Add("flow", "f");
        }
        catch (Exception)
        {
        }
        string str = this.DrpPrincipal.SelectedValue.ToString();
        this.Session.Add("PrincipalId", str);
        base.Response.Redirect("frmPromotionStep3.aspx?LevelType=3&LevelID=" + base.Request.QueryString["LevelID"].ToString());
    }

    protected void drpExisting_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void DrpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void FillClonePromotion()
    {
        this.rBtnNew.Checked = false;
        this.txtNew.Enabled = false;
        this.txtNew.CssClass = "inputtxtDisable";
        this.drpExisting.Enabled = true;
        this.rBtnExisting.Checked = true;
        string s = (string)this.Session["PromotionId"];
        DataTable table = new PromotionController().SelectPromotionWithSchemeInfo(int.Parse(this.Session["DISTRIBUTOR_ID"].ToString()), int.Parse(s));
        if (table.Rows.Count > 0)
        {
            this.drpExisting.SelectedValue = table.Rows[0]["SCHEME_ID"].ToString();
            this.txtPromotionName.Text = table.Rows[0]["Promotion_code"].ToString();
            this.txtPromotionDescription.Text = table.Rows[0]["Promotion_Desc"].ToString();
            this.txtStartDate.Text = DateTime.Parse(table.Rows[0]["Start_Date"].ToString()).ToString("dd-MMM-yyyy");
            this.txtEndDate.Text = DateTime.Parse(table.Rows[0]["End_Date"].ToString()).ToString("dd-MMM-yyyy");
            for (int i = 0; i < this.DrpPrincipal.Items.Count; i++)
            {
                if (this.DrpPrincipal.Items[i].Value == table.Rows[0]["PROMOTION_TYPE"].ToString())
                {
                    this.DrpPrincipal.Items[i].Selected = true;
                }
            }
            if (!bool.Parse(table.Rows[0]["is_Scheme"].ToString()))
            {
                this.chkScheme.Items[0].Selected = true;
            }
            else
            {
                this.chkScheme.Items[1].Selected = true;
            }
            if (!bool.Parse(table.Rows[0]["CLAIMABLE"].ToString()))
            {
                this.chkClaimable.Checked = false;
            }
            if (bool.Parse(table.Rows[0]["PROMOTION_FOR"].ToString()))
            {
                this.rdbbtncheck.Items[1].Selected = true;
            }
            else if (!bool.Parse(table.Rows[0]["PROMOTION_FOR"].ToString()))
            {
                this.rdbbtncheck.Items[0].Selected = true;
            }
            for (int j = 0; j < this.drpExisting.Items.Count; j++)
            {
                if (this.drpExisting.Items[j].Value == table.Rows[0]["Scheme_Code"].ToString())
                {
                    this.drpExisting.SelectedIndex = j;
                    return;
                }
            }
        }
    }

    private void LoadPromotionCollection()
    {
        SchemeCollection_Controller controller = new SchemeCollection_Controller();
        controller = (SchemeCollection_Controller)this.Session["SchCtrl"];
        this.txtPromotionName.Text = controller.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).Promotion_Code;
        this.txtPromotionDescription.Text = controller.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).Promotion_Desc;
        this.txtStartDate.Text = controller.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).Start_Date.ToString("dd/MM/yyyy");
        this.txtEndDate.Text = controller.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).End_Date.ToString("dd/MM/yyyy");
        if (!controller.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).Is_Scheme)
        {
            this.chkScheme.Items[0].Selected = true;
        }
        else if (controller.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).Is_Scheme)
        {
            this.chkScheme.Items[1].Selected = true;
        }
        if (controller.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).Claimable)
        {
            this.chkClaimable.Checked = true;
        }
        else if (!controller.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).Claimable)
        {
            this.chkClaimable.Checked = false;
        }
        bool flag = controller.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).Promotion_For;
        if (flag)
        {
            this.rdbbtncheck.Items[1].Selected = true;
        }
        else if (!flag)
        {
            this.rdbbtncheck.Items[0].Selected = true;
        }
        if (controller.Get(0).Scheme_ID == 0)
        {
            this.rBtnExisting.Checked = false;
            this.drpExisting.Enabled = false;
            this.rBtnNew.Checked = true;
            this.txtNew.Enabled = true;
            this.txtNew.CssClass = "txtBox";
            this.txtNew.Text = controller.Get(0).Scheme_Code;
        }
        else
        {
            string str = controller.Get(0).Scheme_Code;
            this.txtNew.Enabled = false;
            this.txtNew.CssClass = "inputtxtDisable";
            this.rBtnNew.Checked = false;
            this.rBtnExisting.Checked = true;
            this.drpExisting.Enabled = true;
            for (int i = 0; i < this.drpExisting.Items.Count; i++)
            {
                if (this.drpExisting.Items[i].Value == str)
                {
                    this.drpExisting.SelectedIndex = i;
                    return;
                }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            DataTable table = new SchemeController().SelectScheme(-2147483648, -2147483648, null, null, Constants.DateNullValue);
            int count = table.Rows.Count;
            this.btnNext.Attributes.Add("onclick", "return ValidateForm()");
            this.Populate_drpSKUCompany();
            if (table.Rows.Count != 0)
            {
                this.drpExisting.DataSource = table;
                this.drpExisting.DataTextField = "SCHEME_CODE";
                this.drpExisting.DataValueField = "SCHEME_ID";
                this.drpExisting.DataBind();
            }
            string str = (string)this.Session["Flow"];
            if (this.Session["IsEdit"] != null)
            {
                if ((bool)this.Session["IsEdit"])
                {
                    switch (str)
                    {
                        case "f":
                            this.FillClonePromotion();
                            return;

                        case "b":
                            this.LoadPromotionCollection();
                            return;
                    }
                }
                else if (str == "b")
                {
                    this.LoadPromotionCollection();
                }
            }
        }
    }

    private void Populate_drpSKUCompany()
    {
        DataTable table = new SKUPriceDetailController().SelectDataPrice(-2147483648, -2147483648, -2147483648, -2147483648, -2147483648, int.Parse(this.Session["UserId"].ToString()), -2147483648, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, table, 0, 1, true);
    }

    protected void rBtnExisting_CheckedChanged(object sender, EventArgs e)
    {
        if (this.rBtnExisting.Checked)
        {
            this.txtNew.Enabled = false;
            this.txtNew.Text = null;
            this.drpExisting.Enabled = true;
            this.rBtnNew.Checked = false;
        }
        else if (!this.rBtnExisting.Checked)
        {
            this.txtNew.Enabled = true;
            this.drpExisting.Enabled = false;
        }
    }

    protected void rBtnNew_CheckedChanged(object sender, EventArgs e)
    {
        if (!this.rBtnNew.Checked)
        {
            this.txtNew.Enabled = false;
            this.drpExisting.Enabled = true;
        }
        else if (this.rBtnNew.Checked)
        {
            this.txtNew.Enabled = true;
            this.drpExisting.Enabled = false;
            this.rBtnExisting.Checked = false;
        }
    }
}