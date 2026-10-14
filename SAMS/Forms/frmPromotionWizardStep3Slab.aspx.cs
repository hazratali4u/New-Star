using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Forms_frmPromotionWizardStep3Slab : System.Web.UI.Page
{
    public DataTable dt;    
    public static int RowNo;
    public int SlabNo;

    protected void btnAddtoSlab_Click(object sender, EventArgs e)
    {
        DataRow row;
        this.dt = (DataTable)this.Session["dt"];
        if (this.btnAddtoSlab.Text == "Add To Slab")
        {
            this.SlabNo = (int)this.Session["SlabNo"];
            row = this.dt.NewRow();
            row["SLAB_NO"] = this.SlabNo.ToString();
            if (this.rbSKUHierarchy.Checked)
            {
                row["SKU"] = this.ddSKU.SelectedItem.Text;
                row["SKUID"] = this.ddSKU.SelectedItem.Value.ToString();
                row["SKUGROUPID"] = -2147483648;
            }
            else if (this.rbSKUGroup.Checked)
            {
                row["SKU"] = this.ddSKUSelectedGroup.SelectedItem.Text;
                row["SKUGROUPID"] = this.ddSKUSelectedGroup.SelectedItem.Value.ToString();
                row["SKUID"] = -2147483648;
            }
            row["UOM"] = "Piece";
            row["Slab On"] = this.ddSlabOn.SelectedItem.Text;
            row["From"] = this.txtFrom.Text;
            row["To"] = this.txtTo.Text;
            row["UOMID"] = "10";
            if (this.ddSlabOn.SelectedValue == "82")
            {
                row["Basket_on"] = 0x52;
            }
            else
            {
                row["Basket_on"] = 0x53;
            }
            if (this.chDiscount.Checked)
            {
                if (this.rbtnDiscount.SelectedIndex == 0)
                {
                    row["Discount"] = this.txtDiscountRate.Text + " %";
                    row["DiscountPercentage"] = this.txtDiscountRate.Text;
                    row["DiscountAmount"] = -79228162514264337593543950335M;
                }
                else
                {
                    row["Discount"] = this.txtDiscountAmount.Text + "/-";
                    row["DiscountAmount"] = this.txtDiscountAmount.Text;
                    row["DiscountPercentage"] = -3.402823E+38f;
                }
            }
            if (this.chSKU.Checked)
            {
                row["SKUOfferID"] = this.ddPromotionSKU.SelectedItem.Value;
                row["SKU Offer"] = this.ddPromotionSKU.SelectedItem.Text;
                row["SKU Quantity"] = this.txtPromotionQuantity.Text;
            }
            if (this.chIsMultiple.Checked)
            {
                row["Multiple_of"] = int.Parse(this.txtMultipleOf.Text).ToString();
            }
            else
            {
                row["Multiple_of"] = "0";
            }
            this.dt.Rows.Add(row);
            this.grdSlab.DataSource = this.dt;
            this.grdSlab.DataBind();
            this.Session.Add("dt", this.dt);
            this.OfferEmpty();
            bool flag = false;
            for (int i = 0; i < this.dt.Rows.Count; i++)
            {
                if (this.dt.Rows[i][0].ToString() == row[0].ToString())
                {
                    DataRow row2 = this.dt.Rows[i];
                    if (!flag)
                    {
                        row2["Is_Multiple"] = this.chIsMultiple.Checked.ToString();
                        flag = true;
                    }
                    else
                    {
                        row2["Is_Multiple"] = "";
                        if (this.rbSKUHierarchy.Checked)
                        {
                            row2["SKU"] = this.ddSKU.SelectedItem.Text;
                        }
                        else
                        {
                            row2["SKU"] = this.ddSKUSelectedGroup.SelectedItem.Text;
                        }
                        row2["Slab On"] = row["Slab On"];
                        row2["UOM"] = row["UOM"].ToString();
                    }
                    if (this.rbSKUHierarchy.Checked)
                    {
                        row2["SKUID"] = this.ddSKU.SelectedItem.Value.ToString();
                        row2["SKUGROUPID"] = -2147483648;
                    }
                    else if (this.rbSKUGroup.Checked)
                    {
                        row2["SKUGROUPID"] = this.ddSKUSelectedGroup.SelectedItem.Value.ToString();
                        row2["SKUID"] = -2147483648;
                    }
                    row2["Basket_On"] = row["Basket_on"];
                    row2["UOMID"] = row["UOMID"];
                }
            }
            this.dt.DefaultView.Sort = "Slab_NO";
            this.grdSlab.DataSource = this.dt.DefaultView;
            this.grdSlab.DataBind();
            this.Session.Add("dt", this.dt);
            this.OfferEmpty();
            this.btnAddtoSlab.Text = "Add To Slab";
            this.btnCreateNewSlab.Enabled = true;
            this.btnNext.Enabled = true;
        }
        else if (this.btnAddtoSlab.Text == "Update Slab")
        {
            this.dt.Rows[RowNo][0].ToString();
            row = this.dt.Rows[RowNo];
            row["UOM"] = "Piece";
            row["Slab On"] = this.ddSlabOn.SelectedItem.Text;
            row["From"] = this.txtFrom.Text;
            row["To"] = this.txtTo.Text;
            row["UOMID"] = "10";
            if (this.ddSlabOn.SelectedValue == "82")
            {
                this.dt.Rows[0]["Basket_on"] = 0x52;
            }
            else
            {
                this.dt.Rows[0]["Basket_on"] = 0x53;
            }
            if (this.chDiscount.Checked)
            {
                if (this.rbtnDiscount.SelectedIndex == 0)
                {
                    row["Discount"] = this.txtDiscountRate.Text + " %";
                    row["DiscountPercentage"] = this.txtDiscountRate.Text;
                    row["DiscountAmount"] = -79228162514264337593543950335M;
                }
                else
                {
                    row["DiscountAmount"] = this.txtDiscountAmount.Text;
                    row["Discount"] = this.txtDiscountAmount.Text + "/-";
                    row["DiscountPercentage"] = -3.402823E+38f;
                }
            }
            else
            {
                row["Discount"] = DBNull.Value;
                row["DiscountPercentage"] = DBNull.Value;
                row["DiscountAmount"] = DBNull.Value;
            }
            if (this.chSKU.Checked)
            {
                row["SKUOfferID"] = this.ddPromotionSKU.SelectedItem.Value;
                row["SKU Offer"] = this.ddPromotionSKU.SelectedItem.Text;
                row["SKU Quantity"] = this.txtPromotionQuantity.Text;
            }
            else
            {
                row["SKUOfferID"] = DBNull.Value;
                row["SKU Offer"] = DBNull.Value;
                row["SKU Quantity"] = DBNull.Value;
            }
            if (this.chIsMultiple.Checked)
            {
                row["Multiple_of"] = int.Parse(this.txtMultipleOf.Text).ToString();
            }
            else
            {
                row["Multiple_of"] = "0";
            }
            this.grdSlab.DataSource = this.dt;
            this.grdSlab.DataBind();
            this.Session.Add("dt", this.dt);
            this.OfferEmpty();
            this.btnAddtoSlab.Text = "Add To Slab";
            this.btnCreateNewSlab.Enabled = true;
            this.btnNext.Enabled = true;
        }
        else
        {
            row = this.dt.NewRow();
            row["SLAB_NO"] = int.Parse(this.btnAddtoSlab.Text.Substring(12));
            if (this.rbSKUHierarchy.Checked)
            {
                row["SKU"] = this.ddSKU.SelectedItem.Text;
                row["SKUID"] = this.ddSKU.SelectedItem.Value.ToString();
                row["SKUGROUPID"] = -2147483648;
            }
            else if (this.rbSKUGroup.Checked)
            {
                row["SKU"] = this.ddSKUSelectedGroup.SelectedItem.Text;
                row["SKUGROUPID"] = this.ddSKUSelectedGroup.SelectedItem.Value.ToString();
                row["SKUID"] = -2147483648;
            }
            row["UOM"] = "Piece";
            row["Slab On"] = this.ddSlabOn.SelectedItem.Text;
            row["From"] = this.txtFrom.Text;
            row["To"] = this.txtTo.Text;
            row["UOMID"] = "10";
            if (this.ddSlabOn.SelectedValue == "82")
            {
                row["Basket_on"] = 0x52;
            }
            else
            {
                row["Basket_on"] = 0x53;
            }
            if (this.chDiscount.Checked)
            {
                if (this.rbtnDiscount.SelectedIndex == 0)
                {
                    row["Discount"] = this.txtDiscountRate.Text + " %";
                    row["DiscountPercentage"] = this.txtDiscountRate.Text;
                    row["DiscountAmount"] = -79228162514264337593543950335M;
                }
                else
                {
                    row["Discount"] = this.txtDiscountAmount.Text + "/-";
                    row["DiscountAmount"] = this.txtDiscountAmount.Text;
                    row["DiscountPercentage"] = -3.402823E+38f;
                }
            }
            if (this.chSKU.Checked)
            {
                row["SKUOfferID"] = this.ddPromotionSKU.SelectedItem.Value;
                row["SKU Offer"] = this.ddPromotionSKU.SelectedItem.Text;
                row["SKU Quantity"] = this.txtPromotionQuantity.Text;
            }
            if (this.chIsMultiple.Checked)
            {
                row["Multiple_of"] = int.Parse(this.txtMultipleOf.Text).ToString();
            }
            else
            {
                row["Multiple_of"] = "0";
            }
            this.dt.Rows.Add(row);
            this.grdSlab.DataSource = this.dt;
            this.grdSlab.DataBind();
            this.Session.Add("dt", this.dt);
            this.OfferEmpty();
            bool flag2 = false;
            for (int j = 0; j < this.dt.Rows.Count; j++)
            {
                if (this.dt.Rows[j][0].ToString() == row[0].ToString())
                {
                    DataRow row3 = this.dt.Rows[j];
                    if (!flag2)
                    {
                        row3["Is_Multiple"] = this.chIsMultiple.Checked.ToString();
                        flag2 = true;
                    }
                    else
                    {
                        row3["Is_Multiple"] = "";
                        if (this.rbSKUHierarchy.Checked)
                        {
                            row3["SKU"] = this.ddSKU.SelectedItem.Text;
                        }
                        else
                        {
                            row3["SKU"] = this.ddSKUSelectedGroup.SelectedItem.Text;
                        }
                        row3["Slab On"] = row["Slab On"];
                        row3["UOM"] = row["UOM"].ToString();
                    }
                    if (this.rbSKUHierarchy.Checked)
                    {
                        row3["SKUID"] = this.ddSKU.SelectedItem.Value.ToString();
                        row3["SKUGROUPID"] = -2147483648;
                    }
                    else if (this.rbSKUGroup.Checked)
                    {
                        row3["SKUGROUPID"] = this.ddSKUSelectedGroup.SelectedItem.Value.ToString();
                        row3["SKUID"] = -2147483648;
                    }
                    row3["Basket_On"] = row["Basket_on"];
                    row3["UOMID"] = row["UOMID"];
                }
            }
            this.dt.DefaultView.Sort = "Slab_NO";
            this.grdSlab.DataSource = this.dt.DefaultView;
            this.grdSlab.DataBind();
            this.Session.Add("dt", this.dt);
            this.OfferEmpty();
            this.btnAddtoSlab.Text = "Add To Slab";
            this.btnCreateNewSlab.Enabled = true;
            this.btnNext.Enabled = true;
        }
        this.rbSKUHierarchy.Enabled = false;
        this.rbSKUGroup.Enabled = false;
        this.ddSKUCatagory.Enabled = false;
        this.ddSKUBrand.Enabled = false;
        this.ddSKU.Enabled = false;
        this.ddSKUSelectedGroup.Enabled = false;
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        this.Session.Add("Flow", "b");
        base.Response.Redirect("frmPromotionStep3.aspx?LevelType=3&LevelID=" + base.Request.QueryString["LevelID"].ToString());
    }

    protected void btnCreateNewSlab_Click(object sender, EventArgs e)
    {
        this.CreatNewSlab();
        this.rbSKUHierarchy.Enabled = true;
        this.rbSKUGroup.Enabled = true;
        this.ddSKUCatagory.Enabled = true;
        this.ddSKUBrand.Enabled = true;
        this.ddSKU.Enabled = true;
        this.ddSKUSelectedGroup.Enabled = true;
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        DataControl control = new DataControl();
        SchemeCollection_Controller controller = new SchemeCollection_Controller();
        controller = (SchemeCollection_Controller)this.Session["SchCtrl"];
        Promotion_Collection n_s = controller.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0);
        n_s.ObjBasketCol_Cntrl = new BasketCollection_Controller();
        Basket_Collection t_s = null;
        this.dt = (DataTable)this.Session["dt"];
        foreach (DataRowView view in this.dt.DefaultView)
        {
            if (!view[1].ToString().Trim().Equals(""))
            {
                t_s = new Basket_Collection();
                t_s.ObjPromotionOfferCol_Cntrl = new PromotionOfferColl_Controller();
                t_s.ObjBasketDtlCol_Cntrlr = new BasketDetailCollection_Controller();
                t_s.Is_Basket = false;
                t_s.Is_And = false;
                t_s.Dist_ID = (int)this.Session["DISTRIBUTOR_ID"];
                t_s.Basket_On = int.Parse(view["Basket_on"].ToString());
                t_s.Basket_ID = -9223372036854775808L;
                t_s.Basket_Selection = -2147483648;
                if (!view["Is_Multiple"].ToString().Equals(""))
                {
                    t_s.Is_Multiple = bool.Parse(view["Is_Multiple"].ToString());
                }
                n_s.ObjBasketCol_Cntrl.Add(t_s);
            }
            else
            {
                Basket_Detail_Collection l_s = new Basket_Detail_Collection();
                l_s.Dist_ID =(int)this.Session["DISTRIBUTOR_ID"];
                l_s.Min_Val = int.Parse(view["From"].ToString());
                l_s.Max_Val = int.Parse(view["To"].ToString());
                l_s.Multiple_Of = int.Parse(control.chkNull(view["Multiple_of"].ToString()));
                l_s.SKU_ID = int.Parse(control.chkNull(view["SKUID"].ToString()));
                l_s.SKUGroup_ID = int.Parse(control.chkNull(view["SKUGROUPID"].ToString()));
                l_s.UOM_ID = int.Parse(control.chkNull(view["UOMID"].ToString()));
                l_s.SKUCompany_ID = -2147483648;
                l_s.SKUDiv_ID = -2147483648;
                l_s.SKUCatg_ID = -2147483648;
                l_s.SKUBrand_ID = -2147483648;
                l_s.SKUProductLine_ID = -2147483648;
                t_s.ObjBasketDtlCol_Cntrlr.Add(l_s);
                PromotionOffer_Collection r_s = new PromotionOffer_Collection();
                r_s.Dist_ID = (int)this.Session["DISTRIBUTOR_ID"];
                r_s.Is_And = false;
                if (int.Parse(control.chkNull(view["SKUOfferID"].ToString())) > 0)
                {
                    r_s.SKU_ID = int.Parse(view["SKUOfferID"].ToString());
                }
                else
                {
                    r_s.SKU_ID = -2147483648;
                }
                r_s.UOM_ID = int.Parse(control.chkNull(view["UOMID"].ToString()));
                if (int.Parse(control.chkNull(view["SKU Quantity"].ToString())) > 0)
                {
                    r_s.Quantity = int.Parse(control.chkNull(view["SKU Quantity"].ToString()));
                }
                else
                {
                    r_s.Quantity = -2147483648;
                }
                if (float.Parse(control.chkNull_0(view["DiscountPercentage"].ToString())) > 0f)
                {
                    r_s.Discount = float.Parse(control.chkNull(view["DiscountPercentage"].ToString()));
                    r_s.Offer_Value = -79228162514264337593543950335M;
                }
                else
                {
                    r_s.Offer_Value = decimal.Parse(control.chkNull(view["DiscountAmount"].ToString()));
                    r_s.Discount = float.MinValue;
                }
                t_s.ObjPromotionOfferCol_Cntrl.Add(r_s);
            }
        }
        base.Response.Redirect("frmPromotionStep5.aspx?LevelType=3&LevelID=" + base.Request.QueryString["LevelID"].ToString());
        this.Session.Add("Flow", "f");
    }

    protected void chDiscount_CheckedChanged(object sender, EventArgs e)
    {
    }

    protected void chIsMultiple_CheckedChanged(object sender, EventArgs e)
    {
        if (this.chIsMultiple.Checked)
        {
            this.txtMultipleOf.Enabled = true;
            this.txtMultipleOf.Focus();
        }
        else
        {
            this.txtMultipleOf.Enabled = false;
            this.txtMultipleOf.Text = "";
        }
    }

    private void CloneSlabDetailData(DataTable dt1)
    {
        DataControl control = new DataControl();
        DataTable table = (DataTable)this.Session["dt"];
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            this.SlabNo = (int)this.Session["SlabNo"];
            DataRow row = table.NewRow();
            row["SLAB_NO"] = this.SlabNo.ToString();
            if (int.Parse(control.chkNull_0(dt1.Rows[i]["SKU_ID"].ToString())) > 0)
            {
                row["SKU"] = dt1.Rows[i]["sku_name"].ToString();
                row["SKUID"] = Convert.ToInt64(dt1.Rows[i]["sku_Id"].ToString());
                row["SKUGROUPID"] = -2147483648;
            }
            else
            {
                row["SKU"] = dt1.Rows[i]["GROUP_NAME"].ToString();
                row["SKUGROUPID"] = dt1.Rows[i]["SKU_GROUP_ID"].ToString();
                row["SKUID"] = -2147483648;
            }
            row["UOM"] = dt1.Rows[i]["UOM_DESC"].ToString();
            row["UOMID"] = dt1.Rows[i]["UOM_ID"].ToString();
            if (int.Parse(dt1.Rows[i]["BASKET_ON"].ToString()) == 0x52)
            {
                row["Slab On"] = "Quantity";
            }
            else
            {
                row["Slab On"] = "Amount";
            }
            row["From"] = Convert.ToInt64(dt1.Rows[i]["MIN_VAL"].ToString());
            row["To"] = Convert.ToInt64(dt1.Rows[i]["MAX_VAL"].ToString());
            if (int.Parse(dt1.Rows[i]["BASKET_ON"].ToString()) == 0x52)
            {
                row["Basket_on"] = 0x52;
            }
            else
            {
                row["Basket_on"] = 0x53;
            }
            if (decimal.Parse(control.chkNull_0(dt1.Rows[i]["DISCOUNT"].ToString())) > 0M)
            {
                row["Discount"] = dt1.Rows[i]["DISCOUNT"].ToString() + "%";
                row["DiscountPercentage"] = decimal.Parse(dt1.Rows[i]["DISCOUNT"].ToString());
                row["DiscountAmount"] = "";
            }
            else if (decimal.Parse(control.chkNull_0(dt1.Rows[i]["OFFER_VALUE"].ToString())) > 0M)
            {
                row["Discount"] = Math.Round(decimal.Parse(dt1.Rows[i]["OFFER_VALUE"].ToString()), 2) + "/-";
                row["DiscountAmount"] = decimal.Parse(dt1.Rows[i]["OFFER_VALUE"].ToString());
                row["DiscountPercentage"] = "";
            }
            if (decimal.Parse(control.chkNull_0(dt1.Rows[i]["OFFERSKUID"].ToString())) > 0M)
            {
                row["SKUOfferID"] = control.chkNull_0(dt1.Rows[i]["OFFERSKUID"].ToString());
                row["SKU Offer"] = control.chkNull_0(dt1.Rows[i]["OFFERSKUNAME"].ToString());
                row["SKU Quantity"] = control.chkNull_0(dt1.Rows[i]["QUANTITY"].ToString());
            }
            row["MULTIPLE_OF"] = dt1.Rows[i]["MULTIPLE_OF"].ToString();
            table.Rows.Add(row);
        }
        this.Session.Add("dt", table);
    }

    private void CreateSlabTable()
    {
        this.dt = new DataTable();
        DataColumn column = new DataColumn("SLAB_NO", Type.GetType("System.Int32"));
        this.dt.Columns.Add(column);
        column = new DataColumn("SLAB NO", Type.GetType("System.String"));
        this.dt.Columns.Add(column);
        column = new DataColumn("SKU", Type.GetType("System.String"));
        this.dt.Columns.Add(column);
        column = new DataColumn("SKUID", Type.GetType("System.String"));
        this.dt.Columns.Add(column);
        column = new DataColumn("SKUGROUPID", Type.GetType("System.String"));
        this.dt.Columns.Add(column);
        column = new DataColumn("UOM", Type.GetType("System.String"));
        this.dt.Columns.Add(column);
        column = new DataColumn("UOMID", Type.GetType("System.String"));
        this.dt.Columns.Add(column);
        column = new DataColumn("Slab On", Type.GetType("System.String"));
        this.dt.Columns.Add(column);
        column = new DataColumn("From", Type.GetType("System.String"));
        this.dt.Columns.Add(column);
        column = new DataColumn("To", Type.GetType("System.String"));
        this.dt.Columns.Add(column);
        column = new DataColumn("Discount", Type.GetType("System.String"));
        this.dt.Columns.Add(column);
        column = new DataColumn("SKU Offer", Type.GetType("System.String"));
        this.dt.Columns.Add(column);
        column = new DataColumn("SKU Quantity", Type.GetType("System.String"));
        this.dt.Columns.Add(column);
        column = new DataColumn("Is_Multiple", Type.GetType("System.String"));
        this.dt.Columns.Add(column);
        column = new DataColumn("Multiple_of", Type.GetType("System.String"));
        this.dt.Columns.Add(column);
        column = new DataColumn("Basket_on", Type.GetType("System.String"));
        this.dt.Columns.Add(column);
        column = new DataColumn("Edit", Type.GetType("System.String"));
        this.dt.Columns.Add(column);
        column = new DataColumn("Remove", Type.GetType("System.String"));
        this.dt.Columns.Add(column);
        column = new DataColumn("SKUOfferID", Type.GetType("System.String"));
        this.dt.Columns.Add(column);
        column = new DataColumn("DiscountPercentage", Type.GetType("System.String"));
        this.dt.Columns.Add(column);
        column = new DataColumn("DiscountAmount", Type.GetType("System.String"));
        this.dt.Columns.Add(column);
        this.Session.Add("dt", this.dt);
        this.Session.Add("SlabNo", this.SlabNo);
    }

    private void CreatNewSlab()
    {
        this.chIsMultiple.Enabled = true;
        this.ddSlabOn.Enabled = true;
        this.rbSKUHierarchy.Enabled = true;
        this.rbSKUGroup.Enabled = true;
        this.txtMultipleOf.Enabled = false;
        this.txtMultipleOf.Text = "";
        this.chIsMultiple.Checked = false;
        if (this.rbSKUGroup.Checked)
        {
            this.ddSKUSelectedGroup.Enabled = true;
        }
        if (this.rbSKUHierarchy.Checked)
        {
            this.ddSKUCatagory.Enabled = true;
            this.ddSKUBrand.Enabled = true;
            this.ddSKU.Enabled = true;
        }
        this.SlabNo = (int)this.Session["SlabNo"];
        this.dt = (DataTable)this.Session["dt"];
        this.SlabNo++;
        DataRow row = this.dt.NewRow();
        row["SLAB NO"] = "SLab # " + this.SlabNo;
        row["SLAB_NO"] = this.SlabNo.ToString();
        if (this.ddSlabOn.SelectedValue == "82")
        {
            row["Basket_on"] = 0x52;
        }
        else
        {
            row["Basket_on"] = 0x53;
        }
        if (this.chIsMultiple.Checked)
        {
            row["Is_Multiple"] = "true";
        }
        else
        {
            row["Is_Multiple"] = "false";
        }
        row["SKU"] = "";
        row["UOM"] = "";
        row["Slab On"] = "";
        row["From"] = "";
        row["To"] = "";
        row["Discount"] = "";
        row["SKU Offer"] = "";
        row["SKU Quantity"] = "";
        row["Remove"] = "";
        row["Edit"] = "";
        this.dt.Rows.Add(row);
        this.grdSlab.DataSource = this.dt;
        this.grdSlab.DataBind();
        this.Session.Add("dt", this.dt);
        this.Session.Add("SlabNo", this.SlabNo);
    }

    protected void ddPromotionCatagory_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadSKUs2();
    }

    protected void ddSKUBrand_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadSKUS();
    }

    protected void ddSKUCatagory_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadBrand();
        this.LoadSKUS();
    }

    protected void ddSKUCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void ddSKUDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void ddSlabOn_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.lblfromquantity.Text = "From " + this.ddSlabOn.SelectedItem.Text;
        this.lblToQuantity.Text = "To " + this.ddSlabOn.SelectedItem.Text;
    }

    protected void grdSlab_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int rowIndex = e.RowIndex;
            this.dt = (DataTable)this.Session["dt"];
            DataRowView view = this.dt.DefaultView[rowIndex];
            string str = view[0].ToString();
            string str2 = view[1].ToString();
            int num2 = this.dt.Rows.Count - 1;
            if (str2.Trim() != "")
            {
                for (int i = num2; i > 0; i--)
                {
                    if (this.dt.Rows[i][0].ToString().Trim() == str)
                    {
                        this.dt.Rows[i].Delete();
                    }
                }
            }
            else
            {
                view.Delete();
            }
            this.dt.AcceptChanges();
            this.Session.Add("dt", this.dt);
            this.LoadGrid();
        }
        catch (Exception)
        {
        }
    }

    protected void grdSlab_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DataControl control = new DataControl();
        this.dt = (DataTable)this.Session["dt"];
        DataRowView view = this.dt.DefaultView[e.NewEditIndex];
        RowNo = e.NewEditIndex;
        if (!view["Slab No"].ToString().Trim().Equals(""))
        {
            this.btnAddtoSlab.Text = "Add To Slab#" + view["Slab_No"].ToString();
            this.btnCreateNewSlab.Enabled = false;
            this.btnNext.Enabled = false;
            return;
        }
        if (int.Parse(control.chkNull_0(view["SKUID"].ToString())) <= 0)
        {
            for (int j = 0; j < this.ddSKUSelectedGroup.Items.Count; j++)
            {
                if (int.Parse(this.ddSKUSelectedGroup.Items[j].Value) == int.Parse(control.chkNull_0(view["SKUGROUPID"].ToString())))
                {
                    this.ddSKUSelectedGroup.SelectedIndex = j;
                    break;
                }
            }
        }
        else
        {
            for (int k = 0; k < this.ddSKU.Items.Count; k++)
            {
                if (int.Parse(this.ddSKU.Items[k].Value) == int.Parse(control.chkNull_0(view["SKUID"].ToString())))
                {
                    this.ddSKU.SelectedIndex = k;
                    break;
                }
            }
            this.rbSKUHierarchy.Checked = true;
            this.rbSKUGroup.Checked = false;
            this.ddSKU.Enabled = true;
            this.rbSKUGroup.Checked = false;
            this.ddSKUSelectedGroup.Enabled = false;
            goto Label_01C7;
        }
        this.rbSKUGroup.Checked = true;
        this.rbSKUHierarchy.Checked = false;
        this.ddSKUSelectedGroup.Enabled = true;
        this.rbSKUHierarchy.Enabled = false;
        this.ddSKU.Enabled = false;
    Label_01C7:
        this.txtMultipleOf.Text = view["Multiple_of"].ToString();
        if (int.Parse(control.chkNull_0(this.txtMultipleOf.Text)) > 0)
        {
            this.chIsMultiple.Checked = true;
            this.txtMultipleOf.Enabled = true;
        }
        else
        {
            this.chIsMultiple.Checked = false;
            this.txtMultipleOf.Enabled = false;
        }
        this.txtFrom.Text = view["From"].ToString();
        this.txtTo.Text = view["To"].ToString();
        this.ddSlabOn.SelectedValue = view["Basket_on"].ToString();
        if (decimal.Parse(control.chkNull_0(view["DiscountAmount"].ToString())) == 0M)
        {
            this.rbtnDiscount.SelectedIndex = 0;
            this.txtDiscountRate.Text = control.chkNull_0(view["DiscountPercentage"].ToString());
            this.txtDiscountRate.Enabled = true;
            this.txtDiscountAmount.Text = "";
        }
        else
        {
            this.rbtnDiscount.SelectedIndex = 1;
            this.txtDiscountAmount.Text = control.chkNull_0(view["DiscountAmount"].ToString());
            this.txtDiscountAmount.Enabled = true;
            this.txtDiscountRate.Text = "";
        }
        if (!view["Discount"].ToString().Trim().Equals(""))
        {
            this.chDiscount.Checked = true;
        }
        if (int.Parse(control.chkNull_0(view["SKU Quantity"].ToString())) > 0)
        {
            this.chSKU.Checked = true;
        }
        for (int i = 0; i < this.ddPromotionSKU.Items.Count; i++)
        {
            if (int.Parse(this.ddPromotionSKU.Items[i].Value) == int.Parse(control.chkNull_0(view["SKUOfferID"].ToString())))
            {
                this.ddPromotionSKU.SelectedIndex = i;
                break;
            }
        }
        this.txtPromotionQuantity.Text = control.chkNull_0(view["SKU Quantity"].ToString());
        this.btnAddtoSlab.Text = "Update Slab";
        this.btnCreateNewSlab.Enabled = false;
        this.btnNext.Enabled = false;
    }

    private void LoadBrand()
    {
        if (this.ddSKUCatagory.Items.Count > 0)
        {
            this.ddSKUBrand.Items.Clear();
            SkuHierarchyController controller = new SkuHierarchyController();
            DataTable table = new DataTable();
            table = controller.SelectDTSkuHierarchy(60, int.Parse(clsWebFormUtil.GetListItemKey(this.ddSKUCatagory)));
            clsWebFormUtil.FillDropDownList(this.ddSKUBrand, table, "SKU_HIE_ID", "SKU_HIE_NAME");
        }
    }

    private void LoadCategory()
    {
        string s = (string)this.Session["PrincipalId"];
        DataTable table = new SkuHierarchyController().SelectDTSkuHierarchy01(2, int.Parse(s), -2147483648, -2147483648, -2147483648, int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.ddSKUCatagory, table, "Category_Id", "Category_Name");
    }

    private void LoadCloneSlabData()
    {
        DataControl control = new DataControl();
        string s = (string)this.Session["PromotionId"];
        PromotionController controller = new PromotionController();
        this.dt = (DataTable)this.Session["dt"];
        this.SlabNo = (int)this.Session["SlabNo"];
        DataTable basketMaster = controller.GetBasketMaster(long.Parse(s));
        for (int i = 0; i < basketMaster.Rows.Count; i++)
        {
            this.SlabNo = (int)this.Session["SlabNo"];
            this.SlabNo++;
            DataRow row = this.dt.NewRow();
            row["SLAB NO"] = "SLab # " + this.SlabNo;
            row["SLAB_NO"] = this.SlabNo.ToString();
            if (int.Parse(control.chkNull_0(basketMaster.Rows[i]["Basket_On"].ToString())) == 0x52)
            {
                row["Basket_on"] = 0x52;
            }
            else
            {
                row["Basket_on"] = 0x53;
            }
            if (bool.Parse(basketMaster.Rows[i]["IS_MULTIPLE"].ToString()))
            {
                row["Is_Multiple"] = "true";
            }
            else
            {
                row["Is_Multiple"] = "false";
            }
            row["SKU"] = "";
            row["UOM"] = "";
            row["Slab On"] = "";
            row["From"] = "";
            row["To"] = "";
            row["Discount"] = "";
            row["SKU Offer"] = "";
            row["SKU Quantity"] = "";
            row["Remove"] = "";
            row["Edit"] = "";
            this.dt.Rows.Add(row);
            this.Session.Add("SlabNo", this.SlabNo);
            DataTable basketDetailForSlab = controller.GetBasketDetailForSlab(int.Parse(basketMaster.Rows[i]["BASKET_ID"].ToString()));
            this.CloneSlabDetailData(basketDetailForSlab);
        }
        this.grdSlab.DataSource = this.dt;
        this.grdSlab.DataBind();
        this.Session.Add("dt", this.dt);
    }

    private void LoadGrid()
    {
        this.dt = (DataTable)this.Session["dt"];
        this.grdSlab.DataSource = this.dt.DefaultView;
        this.grdSlab.DataBind();
    }

    private void LoadGroups()
    {
        DataTable table = new SKUGroupController().SelectSKUGroup(-2147483648, null, int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.ddSKUSelectedGroup, table, "SKU_GROUP_ID", "GROUP_NAME");
    }

    private void LoadPromotionCollection()
    {
        SchemeCollection_Controller controller = new SchemeCollection_Controller();
        controller = (SchemeCollection_Controller)this.Session["SchCtrl"];
        this.SlabNo = (int)this.Session["SlabNo"];
        BasketCollection_Controller controller2 = controller.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjBasketCol_Cntrl;
        this.dt = (DataTable)this.Session["dt"];
        for (int i = 0; i < controller2.Count; i++)
        {
            Basket_Collection t_s = controller.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjBasketCol_Cntrl.Get(i);
            DataRow row = this.dt.NewRow();
            this.SlabNo++;
            row["SLAB NO"] = "SLab # " + this.SlabNo;
            row["SLAB_NO"] = this.SlabNo.ToString();
            row["Basket_on"] = t_s.Basket_On;
            row["Is_Multiple"] = t_s.Is_Multiple;
            row["SKU"] = "";
            row["UOM"] = "";
            row["Slab On"] = "";
            row["From"] = "";
            row["To"] = "";
            row["Discount"] = "";
            row["SKU Offer"] = "";
            row["SKU Quantity"] = "";
            row["Remove"] = "";
            row["Edit"] = "";
            this.dt.Rows.Add(row);
            for (int j = 0; j < t_s.ObjBasketDtlCol_Cntrlr.Count; j++)
            {
                DataRow row2 = this.dt.NewRow();
                row2["SLAB NO"] = "";
                row2["SLAB_NO"] = this.SlabNo.ToString();
                if (t_s.ObjBasketDtlCol_Cntrlr.Get(j).SKU_ID == -2147483648)
                {
                    DataTable table = new SKUGroupController().SelectSKUGroup(t_s.ObjBasketDtlCol_Cntrlr.Get(j).SKUGroup_ID, null, int.Parse(this.Session["CompanyId"].ToString()));
                    if (table.Rows.Count > 0)
                    {
                        row2["SKU"] = table.Rows[0]["GROUP_NAME"].ToString();
                        row2["SKUGROUPID"] = t_s.ObjBasketDtlCol_Cntrlr.Get(j).SKUGroup_ID;
                        row2["SKUID"] = -2147483648;
                    }
                }
                else if (t_s.ObjBasketDtlCol_Cntrlr.Get(j).SKUGroup_ID == -2147483648)
                {
                    DataTable table2 = new SkuController().SelectSkuData(t_s.ObjBasketDtlCol_Cntrlr.Get(j).SKU_ID, int.Parse(this.Session["CompanyId"].ToString()));
                    if (table2.Rows.Count > 0)
                    {
                        row2["SKU"] = table2.Rows[0]["SKU_CODE"].ToString() + " - " + table2.Rows[0]["SKU_NAME"].ToString();
                        row2["SKUID"] = table2.Rows[0]["SKU_ID"].ToString();
                        row2["SKUGROUPID"] = -2147483648;
                    }
                }
                DataTable table3 = new SkuController().SelectUOMs(t_s.ObjBasketDtlCol_Cntrlr.Get(j).UOM_ID, null);
                if (table3.Rows.Count > 0)
                {
                    row2["UOM"] = table3.Rows[0]["UOM_DESC"].ToString();
                }
                if (t_s.Basket_On == 0x53)
                {
                    row2["Slab On"] = "Amount";
                }
                else if (t_s.Basket_On == 0x52)
                {
                    row2["Slab On"] = "Quantity";
                }
                row2["From"] = t_s.ObjBasketDtlCol_Cntrlr.Get(j).Min_Val.ToString();
                row2["To"] = t_s.ObjBasketDtlCol_Cntrlr.Get(j).Max_Val.ToString();
                row2["Multiple_Of"] = t_s.ObjBasketDtlCol_Cntrlr.Get(j).Multiple_Of.ToString();
                if (t_s.ObjPromotionOfferCol_Cntrl.Get(j).Discount > 0f)
                {
                    row2["Discount"] = t_s.ObjPromotionOfferCol_Cntrl.Get(j).Discount.ToString() + " %";
                    row2["DiscountPercentage"] = t_s.ObjPromotionOfferCol_Cntrl.Get(j).Discount.ToString();
                    row2["DiscountAmount"] = -79228162514264337593543950335M;
                }
                else if (t_s.ObjPromotionOfferCol_Cntrl.Get(j).Offer_Value > 0M)
                {
                    row2["Discount"] = t_s.ObjPromotionOfferCol_Cntrl.Get(j).Offer_Value.ToString() + "/-";
                    row2["DiscountAmount"] = t_s.ObjPromotionOfferCol_Cntrl.Get(j).Offer_Value.ToString();
                    row2["DiscountPercentage"] = -3.402823E+38f;
                }
                else
                {
                    row2["Discount"] = "";
                }
                if (t_s.ObjPromotionOfferCol_Cntrl.Get(j).SKU_ID != -2147483648)
                {
                    DataTable table4 = new SkuController().SelectSkuData(t_s.ObjPromotionOfferCol_Cntrl.Get(j).SKU_ID, int.Parse(this.Session["CompanyId"].ToString()));
                    if (table4.Rows.Count > 0)
                    {
                        row2["SKUOfferID"] = table4.Rows[0]["SKU_ID"].ToString();
                        row2["SKU Offer"] = table4.Rows[0]["SKU_CODE"].ToString() + " - " + table4.Rows[0]["SKU_NAME"].ToString();
                    }
                }
                else
                {
                    row2["SKUOfferID"] = -2147483648;
                    row2["SKU Offer"] = "";
                }
                if (t_s.ObjPromotionOfferCol_Cntrl.Get(j).Quantity != -2147483648)
                {
                    row2["SKU Quantity"] = t_s.ObjPromotionOfferCol_Cntrl.Get(j).Quantity.ToString();
                }
                else
                {
                    row2["SKU Quantity"] = "";
                }
                this.dt.Rows.Add(row2);
            }
            this.Session.Add("dt", this.dt);
            this.Session.Add("SlabNo", this.SlabNo);
        }
    }

    private void LoadSKUCategory2()
    {
        string s = (string)this.Session["PrincipalId"];
        DataTable table = new SkuHierarchyController().SelectDTSkuHierarchy01(2, int.Parse(s), -2147483648, -2147483648, -2147483648, int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.ddPromotionCatagory, table, "Category_Id", "Category_Name");
    }

    private void LoadSKUS()
    {
        if (this.ddSKUBrand.Items.Count > 0)
        {
            this.ddSKU.Items.Clear();
            SkuController controller = new SkuController();
            int num = -2147483648;
            int num2 = -2147483648;
            int num3 = int.Parse(clsWebFormUtil.GetListItemKey(this.ddSKUCatagory));
            int num4 = int.Parse(clsWebFormUtil.GetListItemKey(this.ddSKUBrand));
            this.dt = controller.SelectSkuInfo(num, num2, num3, num4, -2147483648);
            clsWebFormUtil.FillDropDownList(this.ddSKU, this.dt, "SKU_ID", "SKUDETAIL");
            this.ddSKU.SelectedIndex = 0;
        }
    }

    private void LoadSKUs2()
    {
        clsWebFormUtil.FillDropDownList(this.ddPromotionSKU, null);
        DataTable table = new SkuController().SelectSkuInfo(-2147483648, -2147483648, int.Parse(this.ddPromotionCatagory.SelectedItem.Value), -2147483648, -2147483648);
        clsWebFormUtil.FillDropDownList(this.ddPromotionSKU, table, "SKU_ID", "SKUDETAIL");
    }

    private void OfferEmpty()
    {
        this.chDiscount.Checked = false;
        this.txtDiscountAmount.Text = "";
        this.txtDiscountRate.Text = "";
        this.chSKU.Checked = false;
        this.ddPromotionCatagory.SelectedIndex = 0;
        this.txtPromotionQuantity.Text = "";
        this.txtMultipleOf.Text = "";
        this.txtFrom.Text = "";
        this.txtTo.Text = "";
        this.txtMultipleOf.Text = "";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.ddSKUSelectedGroup.Enabled = false;
            this.txtMultipleOf.Enabled = false;
            this.LoadCategory();
            this.LoadBrand();
            this.LoadSKUS();
            this.LoadGroups();
            this.LoadSKUCategory2();
            this.LoadSKUs2();
            this.CreateSlabTable();
            this.btnAddtoSlab.Attributes.Add("onclick", "return ValidateForm()");
            string str = (string)this.Session["Flow"];
            if (this.Session["IsEdit"] != null)
            {
                if ((bool)this.Session["IsEdit"])
                {
                    switch (str)
                    {
                        case "f":
                            this.LoadCloneSlabData();
                            this.btnNext.Enabled = true;
                            break;

                        case "b":
                            this.LoadPromotionCollection();
                            break;
                    }
                }
                else if (str == "b")
                {
                    this.LoadPromotionCollection();
                }
                else
                {
                    this.CreatNewSlab();
                }
            }
        }
        this.LoadGrid();
    }

    protected void rbDiscountAmount_CheckedChanged(object sender, EventArgs e)
    {
    }

    protected void rbSKUGroup_CheckedChanged(object sender, EventArgs e)
    {
        this.rbSKUGroup.Checked = true;
        this.ddSKUSelectedGroup.Enabled = true;
        this.rbSKUHierarchy.Checked = false;
        this.ddSKUCatagory.Enabled = false;
        this.ddSKUBrand.Enabled = false;
        this.ddSKU.Enabled = false;
    }

    protected void rbSKUHierarchy_CheckedChanged(object sender, EventArgs e)
    {
        this.rbSKUHierarchy.Checked = true;
        this.ddSKUCatagory.Enabled = true;
        this.ddSKUBrand.Enabled = true;
        this.ddSKU.Enabled = true;
        this.rbSKUGroup.Checked = false;
        this.ddSKUSelectedGroup.Enabled = false;
    }

    protected void rbtnDiscount_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.rbtnDiscount.SelectedIndex == 0)
        {
            this.txtDiscountAmount.Enabled = false;
            this.txtDiscountRate.Enabled = true;
        }
        else
        {
            this.txtDiscountAmount.Enabled = true;
            this.txtDiscountRate.Enabled = false;
        }
    }
}