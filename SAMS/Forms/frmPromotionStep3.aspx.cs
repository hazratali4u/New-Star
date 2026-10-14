using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Forms_frmPromotionStep3 : System.Web.UI.Page
{
    protected void btnBack_Click(object sender, EventArgs e)
    {
        this.Session.Add("Flow", "b");
        base.Response.Redirect("frmPromotionStep2.aspx?LevelType=3&LevelID=" + base.Request.QueryString["LevelID"].ToString());
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        base.Response.Redirect("frmPromotionStep1.aspx?LevelType=3&LevelID=" + base.Request.QueryString["LevelID"].ToString());
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            SchemeCollection_Controller controller = new SchemeCollection_Controller();
            controller = (SchemeCollection_Controller)this.Session["SchCtrl"];
            Promotion_Collection n_s = controller.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0);
            n_s.ObjPromotionForCol_Cntrl = new PromotionForCollection_Controller();
            for (int i = 0; i < this.chklDistributors.Items.Count; i++)
            {
                if (this.chklDistributors.Items[i].Selected)
                {
                    PromotionFor_Collection r_s = new PromotionFor_Collection();
                    r_s.Dist_ID = (int)this.Session["DISTRIBUTOR_ID"];
                    r_s.Assigned_Dist_ID = int.Parse(this.chklDistributors.Items[i].Value);
                    n_s.ObjPromotionForCol_Cntrl.Add(r_s);
                }
            }
            if (n_s.ObjPromotionForCol_Cntrl.Count == 0)
            {
                this.lblErrorMessage.Text = "Must Select at least one Distributors";
            }
            else
            {
                n_s.ObjPromotionCustTypeCol_Cntrl = new PromotionCustTypeColl_Controller();
                for (int j = 0; j < this.chklCustomerType.Items.Count; j++)
                {
                    if (this.chklCustomerType.Items[j].Selected)
                    {
                        PromotionCustomerType_Collection e_s = new PromotionCustomerType_Collection
                        {
                            Dist_ID = (int)this.Session["DISTRIBUTOR_ID"],
                            Customer_Type_ID = int.Parse(this.chklCustomerType.Items[j].Value)
                        };
                        n_s.ObjPromotionCustTypeCol_Cntrl.Add(e_s);
                    }
                }
                if (n_s.ObjPromotionCustTypeCol_Cntrl.Count == 0)
                {
                    this.lblErrorMessage.Text = "Must select at one Customer Type";
                }
                else
                {
                    n_s.ObjPromotionVolClassCol_Cntrl = new PromotionCustVolclassColl_Controller();
                    for (int k = 0; k < this.ChbVolumClass.Items.Count; k++)
                    {
                        if (this.ChbVolumClass.Items[k].Selected)
                        {
                            PromotionCustomerVolClass_Collection s_s = new PromotionCustomerVolClass_Collection
                            {
                                Dist_ID = (int)this.Session["DISTRIBUTOR_ID"],
                                Customer_VolClass_ID = int.Parse(this.ChbVolumClass.Items[k].Value)
                            };
                            n_s.ObjPromotionVolClassCol_Cntrl.Add(s_s);
                        }
                    }
                    if (n_s.ObjPromotionVolClassCol_Cntrl.Count == 0)
                    {
                        this.lblErrorMessage.Text = "Must select at one Customer Volume Class";
                    }
                    else
                    {
                        n_s.ObjPromotionForCustCol_Cntrl = new PromotionForCustColl_Controller();
                        this.Session.Add("SchCtrl", controller);
                        this.Session.Add("Flow", "f");
                        if (this.rBtnBasketPromotion.Checked)
                        {
                            base.Response.Redirect("frmPromotionWizardStep3Basket.aspx?LevelType=3&LevelID=" + base.Request.QueryString["LevelID"].ToString(), true);
                        }
                        if (this.rBtnSlabPromotion.Checked)
                        {
                            base.Response.Redirect("frmPromotionWizardStep3Slab.aspx?LevelType=3&LevelID=" + base.Request.QueryString["LevelID"].ToString(), true);
                        }
                    }
                }
            }
        }
        catch (Exception exception)
        {
            this.lblErrorMessage.Text = exception.Message;
        }
    }

    protected void ChbAllLocationType_CheckedChanged(object sender, EventArgs e)
    {
        bool flag = this.ChbAllLocationType.Checked;
        foreach (ListItem item in this.ChbDistributorType.Items)
        {
            item.Selected = flag;
            this.GetDistributor();
        }
    }

    protected void ChbAllVolumeClass_CheckedChanged(object sender, EventArgs e)
    {
        bool flag = this.ChbAllVolumeClass.Checked;
        foreach (ListItem item in this.ChbVolumClass.Items)
        {
            item.Selected = flag;
        }
    }

    protected void ChbDistributorType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetDistributor();
    }

    protected void chkSelectAllCustomerType_CheckedChanged(object sender, EventArgs e)
    {
        bool flag = this.chkSelectAllCustomerType.Checked;
        foreach (ListItem item in this.chklCustomerType.Items)
        {
            item.Selected = flag;
        }
    }

    protected void chkSelectAllDistributors_CheckedChanged(object sender, EventArgs e)
    {
        bool flag = this.chkSelectAllDistributors.Checked;
        foreach (ListItem item in this.chklDistributors.Items)
        {
            item.Selected = flag;
        }
    }

    private void FillPromotionInfo()
    {
        DataTable table = new DataTable();
        table.Columns.Add("distributor_id", Type.GetType("System.String"));
        table.Columns.Add("subzone_id", Type.GetType("System.String"));
        string s = (string)this.Session["PromotionId"];
        PromotionController controller = new PromotionController();
        DataTable promotionDistributors = controller.GetPromotionDistributors(long.Parse(s));
        for (int i = 0; i < promotionDistributors.Rows.Count; i++)
        {
            int num2 = int.Parse(promotionDistributors.Rows[i]["ASSIGNED_DISTRIBUTOR_ID"].ToString());
            DataTable distributorHierarchy = controller.GetDistributorHierarchy(num2);
            for (int num3 = 0; num3 < distributorHierarchy.Rows.Count; num3++)
            {
                DataRow row = table.NewRow();
                row["subzone_id"] = distributorHierarchy.Rows[num3]["subzone_id"].ToString();
                row["distributor_id"] = distributorHierarchy.Rows[num3]["distributor_id"].ToString();
                table.Rows.Add(row);
            }
        }
        DataTable promotionCustomerType = controller.GetPromotionCustomerType(long.Parse(s));
        for (int j = 0; j < promotionCustomerType.Rows.Count; j++)
        {
            int num5 = int.Parse(promotionCustomerType.Rows[j]["CUSTOMER_TYPE_ID"].ToString());
            for (int num6 = 0; num6 < this.chklCustomerType.Items.Count; num6++)
            {
                if ((int.Parse(this.chklCustomerType.Items[num6].Value) == num5) && !this.chklCustomerType.Items[num6].Selected)
                {
                    this.chklCustomerType.Items[num6].Selected = true;
                    break;
                }
            }
        }
        DataTable promotionCustomerVolumeClass = controller.GetPromotionCustomerVolumeClass(long.Parse(s));
        for (int k = 0; k < promotionCustomerVolumeClass.Rows.Count; k++)
        {
            int num8 = int.Parse(promotionCustomerVolumeClass.Rows[k]["CUSTOMER_VOLUMECLASS_ID"].ToString());
            for (int num9 = 0; num9 < this.ChbVolumClass.Items.Count; num9++)
            {
                if ((int.Parse(this.ChbVolumClass.Items[num9].Value) == num8) && !this.ChbVolumClass.Items[num9].Selected)
                {
                    this.ChbVolumClass.Items[num9].Selected = true;
                    break;
                }
            }
        }
        for (int m = 0; m < table.Rows.Count; m++)
        {
            int num11 = Convert.ToInt32(table.Rows[m]["subzone_id"].ToString());
            for (int num12 = 0; num12 < this.ChbDistributorType.Items.Count; num12++)
            {
                if ((int.Parse(this.ChbDistributorType.Items[num12].Value) == num11) && !this.ChbDistributorType.Items[num12].Selected)
                {
                    this.ChbDistributorType.Items[num12].Selected = true;
                    this.ChbDistributorType_SelectedIndexChanged(null, null);
                    break;
                }
            }
        }
        for (int n = 0; n < table.Rows.Count; n++)
        {
            int num14 = Convert.ToInt32(table.Rows[n]["distributor_id"].ToString());
            for (int num15 = 0; num15 < this.chklDistributors.Items.Count; num15++)
            {
                if ((int.Parse(this.chklDistributors.Items[num15].Value) == num14) && !this.chklDistributors.Items[num15].Selected)
                {
                    this.chklDistributors.Items[num15].Selected = true;
                    break;
                }
            }
        }
        DataTable basketMaster = new PromotionController().GetBasketMaster(long.Parse(s));
        bool flag = false;
        foreach (DataRow row2 in basketMaster.Rows)
        {
            flag = bool.Parse(row2["IS_BASKET"].ToString());
        }
        if (flag)
        {
            this.rBtnSlabPromotion.Checked = false;
            this.rBtnSlabPromotion.Enabled = false;
            this.rBtnBasketPromotion.Checked = true;
        }
        else if (!flag)
        {
            this.rBtnBasketPromotion.Checked = false;
            this.rBtnBasketPromotion.Enabled = false;
            this.rBtnSlabPromotion.Checked = true;
        }
    }

    private void GetDistributor()
    {
        this.chklDistributors.Items.Clear();
        DistributorController controller = new DistributorController();
        foreach (ListItem item in this.ChbDistributorType.Items)
        {
            if (item.Selected && (int.Parse(item.Value.ToString()) > 0))
            {
                DataTable table = controller.SelectDistributorInfo(-2147483648, int.Parse(this.Session["UserId"].ToString()), int.Parse(item.Value.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
                clsWebFormUtil.FillListBox(this.chklDistributors, table, 0, 2);
            }
        }
    }

    private void GetDistributorType()
    {
        DataTable table = new DistributorController().SelectDistributorTypeInfo(-2147483648);
        clsWebFormUtil.FillListBox(this.ChbDistributorType, table, 0, 2);
    }

    private void LoadPromotionCollection()
    {
        SchemeCollection_Controller controller = new SchemeCollection_Controller();
        controller = (SchemeCollection_Controller)this.Session["SchCtrl"];
        DataTable table = new DataTable();
        table.Columns.Add("distributor_id", Type.GetType("System.String"));
        table.Columns.Add("subzone_id", Type.GetType("System.String"));
        PromotionController controller2 = new PromotionController();
        PromotionForCollection_Controller controller3 = controller.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjPromotionForCol_Cntrl;
        for (int i = 0; i < controller3.Count; i++)
        {
            int num2 = controller3.Get(i).Assigned_Dist_ID;
            DataTable distributorHierarchy = controller2.GetDistributorHierarchy(num2);
            if (distributorHierarchy.Rows.Count > 0)
            {
                for (int num3 = 0; num3 < distributorHierarchy.Rows.Count; num3++)
                {
                    DataRow row = table.NewRow();
                    row["subzone_id"] = distributorHierarchy.Rows[num3]["subzone_id"].ToString();
                    row["distributor_id"] = distributorHierarchy.Rows[num3]["distributor_id"].ToString();
                    table.Rows.Add(row);
                }
            }
        }
        PromotionCustTypeColl_Controller controller4 = controller.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjPromotionCustTypeCol_Cntrl;
        for (int j = 0; j < controller4.Count; j++)
        {
            int num5 = controller4.Get(j).Customer_Type_ID;
            for (int num6 = 0; num6 < this.chklCustomerType.Items.Count; num6++)
            {
                if (int.Parse(this.chklCustomerType.Items[num6].Value) == num5)
                {
                    this.chklCustomerType.Items[num6].Selected = true;
                    break;
                }
            }
        }
        PromotionCustVolclassColl_Controller controller5 = controller.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjPromotionVolClassCol_Cntrl;
        for (int k = 0; k < controller5.Count; k++)
        {
            int num8 = controller5.Get(k).Customer_VolClass_ID;
            for (int num9 = 0; num9 < this.chklCustomerType.Items.Count; num9++)
            {
                if (int.Parse(this.ChbVolumClass.Items[num9].Value) == num8)
                {
                    this.ChbVolumClass.Items[num9].Selected = true;
                    break;
                }
            }
        }
        for (int m = 0; m < table.Rows.Count; m++)
        {
            int num11 = Convert.ToInt32(table.Rows[m]["subzone_id"].ToString());
            for (int num12 = 0; num12 < this.ChbDistributorType.Items.Count; num12++)
            {
                if ((int.Parse(this.ChbDistributorType.Items[num12].Value) == num11) && !this.ChbDistributorType.Items[num12].Selected)
                {
                    this.ChbDistributorType.Items[num12].Selected = true;
                    this.ChbDistributorType_SelectedIndexChanged(null, null);
                    break;
                }
            }
        }
        for (int n = 0; n < table.Rows.Count; n++)
        {
            int num14 = Convert.ToInt32(table.Rows[n]["distributor_id"].ToString());
            for (int num15 = 0; num15 < this.chklDistributors.Items.Count; num15++)
            {
                if ((int.Parse(this.chklDistributors.Items[num15].Value) == num14) && !this.chklDistributors.Items[num15].Selected)
                {
                    this.chklDistributors.Items[num15].Selected = true;
                    break;
                }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.GetDistributorType();
            this.Populate_VolumeClass();
            this.Populate_CustomerType();
            string str = (string)this.Session["Flow"];
            if ((bool)this.Session["IsEdit"])
            {
                switch (str)
                {
                    case "f":
                        this.FillPromotionInfo();
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

    private void Populate_CustomerType()
    {
        DataTable table = new SLASHCodesController().SelectSlashCodes(-2147483648, null, 0x2e, null, -2147483648, true);
        clsWebFormUtil.FillListBox(this.chklCustomerType, table, 0, 2);
    }

    private void Populate_VolumeClass()
    {
        DataTable table = new SLASHCodesController().SelectSlashCodes(-2147483648, null, 0x30, null, -2147483648, true);
        clsWebFormUtil.FillListBox(this.ChbVolumClass, table, 0, 2);
    }
}