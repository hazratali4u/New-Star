using System;
using System.Data;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmPromotionStep5 : System.Web.UI.Page
{
    protected void btnBack_Click(object sender, EventArgs e)
    {
        this.Session.Add("Flow", "b");
        base.Response.Redirect("frmPromotionWizardStep3Slab.aspx?LevelType=3&LevelID=" + base.Request.QueryString["LevelID"].ToString());
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.Session.Remove("Flow");
        if (this.Session["IsEdit"] != null)
        {
            this.Session.Remove("IsEdit");
            this.Session.Remove("PromotionId");
        }
        base.Response.Redirect("frmPromotionStep1.aspx?LevelType=3&LevelID=" + base.Request.QueryString["LevelID"].ToString());
    }

    protected void btnFinish_Click(object sender, EventArgs e)
    {
        try
        {
            SchemeCollection_Controller controller = new SchemeCollection_Controller();
            controller = (SchemeCollection_Controller)this.Session["SchCtrl"];
            int num = 0;
            if (controller.Get(0).Scheme_ID == 0)
            {
                SchemeController controller2 = new SchemeController();
                num = int.Parse(controller2.InsertScheme(controller.Get(0).Dist_ID, controller.Get(0).Scheme_Code, controller.Get(0).Scheme_Desc, DateTime.Now));
            }
            else
            {
                num = controller.Get(0).Scheme_ID;
            }
            Promotion_Collection n_s = controller.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0);
            PromotionController controller3 = new PromotionController();
            n_s.Promotion_Date = DateTime.Now;
            long num2 = long.Parse(controller3.InsertPromotion(num, n_s.Dist_ID, n_s.Promotion_Code, n_s.Promotion_Desc, n_s.Promotion_Date, n_s.Claimable, n_s.Start_Date, n_s.End_Date, n_s.Is_Active, n_s.Promotion_Type, n_s.Promotion_Selection, n_s.Is_Scheme, n_s.Promotion_For, int.Parse(this.Session["UserId"].ToString())));
            PromotionForAllController controller4 = new PromotionForAllController();
            for (int i = 0; i < n_s.ObjPromotionForCol_Cntrl.Count; i++)
            {
                PromotionFor_Collection r_s = n_s.ObjPromotionForCol_Cntrl.Get(i);
                controller4.InsertPromotionDist(num2, num, r_s.Dist_ID, r_s.Assigned_Dist_ID);
            }
            for (int j = 0; j < n_s.ObjPromotionCustTypeCol_Cntrl.Count; j++)
            {
                PromotionCustomerType_Collection e_s = n_s.ObjPromotionCustTypeCol_Cntrl.Get(j);
                controller4.InsertPromotionCustType(num2, e_s.Dist_ID, num, e_s.Customer_Type_ID);
            }
            for (int k = 0; k < n_s.ObjPromotionVolClassCol_Cntrl.Count; k++)
            {
                PromotionCustomerVolClass_Collection s_s = n_s.ObjPromotionVolClassCol_Cntrl.Get(k);
                controller4.InsertPromotionVolClass(num2, num, s_s.Dist_ID, s_s.Customer_VolClass_ID);
            }
            for (int m = 0; m < n_s.ObjBasketCol_Cntrl.Count; m++)
            {
                Basket_Collection t_s = controller.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjBasketCol_Cntrl.Get(m);
                BasketController controller5 = new BasketController();
                long num7 = long.Parse(controller5.InsertBasket(num2, num, t_s.Dist_ID, t_s.Is_Basket, t_s.Is_Bundled, t_s.Is_Multiple, t_s.Basket_On, t_s.Basket_Selection));
                if (t_s.Is_Basket)
                {
                    PromotionOffer_Collection r_s2 = t_s.ObjPromotionOfferCol_Cntrl.Get(0);
                    PromotionOfferController controller6 = new PromotionOfferController();
                    if ((r_s2.Discount != 0f) && (r_s2.Discount != float.MinValue))
                    {
                        r_s2.Offer_Value = decimal.Parse(r_s2.Discount.ToString());
                    }
                    controller6.InsertPromotionOffer(num7, num2, num, r_s2.Dist_ID, r_s2.BasketDetail_ID, r_s2.Quantity, r_s2.Offer_Value, r_s2.Discount, r_s2.Is_And, r_s2.SKU_ID, r_s2.UOM_ID);
                }
                for (int n = 0; n < t_s.ObjBasketDtlCol_Cntrlr.Count; n++)
                {
                    Basket_Detail_Collection l_s = t_s.ObjBasketDtlCol_Cntrlr.Get(n);
                    long num9 = long.Parse(controller5.InsertBasketDetail(num7, num2, num, l_s.Dist_ID, l_s.Min_Val, l_s.Max_Val, l_s.Multiple_Of, l_s.SKU_ID, l_s.SKUBrand_ID, l_s.SKUDiv_ID, l_s.SKUCatg_ID, l_s.SKUProductLine_ID, l_s.SKUGroup_ID, l_s.UOM_ID, l_s.SKUCompany_ID));
                    if (!t_s.Is_Basket)
                    {
                        PromotionOffer_Collection r_s3 = t_s.ObjPromotionOfferCol_Cntrl.Get(n);
                        new PromotionOfferController().InsertPromotionOffer(num7, num2, num, r_s3.Dist_ID, num9, r_s3.Quantity, r_s3.Offer_Value, r_s3.Discount, r_s3.Is_And, r_s3.SKU_ID, r_s3.UOM_ID);
                    }
                }
            }
            this.lblErrorMessage.Text = "Job Has Completed Successfully";
            this.btnFinish.Enabled = false;
            this.Session.Remove("Flow");
            this.Session.Remove("SchCtrl");
            this.txtSummary.Text = "";
            this.btnFinish.Enabled = false;
            this.btnBack.Enabled = false;
            if (this.Session["IsEdit"] != null)
            {
                this.Session.Remove("IsEdit");
                this.Session.Remove("PromotionId");
            }
        }
        catch (Exception exception)
        {
            this.lblErrorMessage.Text = exception.Message;
        }
    }

    protected DataTable CreateDataTable()
    {
        DataTable table = new DataTable();
        DataColumn column = new DataColumn("BASKET NO", Type.GetType("System.String"));
        table.Columns.Add(column);
        column = new DataColumn("SKU", Type.GetType("System.String"));
        table.Columns.Add(column);
        column = new DataColumn("UOM", Type.GetType("System.String"));
        table.Columns.Add(column);
        column = new DataColumn("Basket On", Type.GetType("System.String"));
        table.Columns.Add(column);
        column = new DataColumn("From", Type.GetType("System.String"));
        table.Columns.Add(column);
        column = new DataColumn("To", Type.GetType("System.String"));
        table.Columns.Add(column);
        column = new DataColumn("Discount", Type.GetType("System.String"));
        table.Columns.Add(column);
        column = new DataColumn("SKU Offer", Type.GetType("System.String"));
        table.Columns.Add(column);
        column = new DataColumn("SKU Quantity", Type.GetType("System.String"));
        table.Columns.Add(column);
        column = new DataColumn("Is_Multiple", Type.GetType("System.String"));
        table.Columns.Add(column);
        column = new DataColumn("Is_Bundled", Type.GetType("System.String"));
        table.Columns.Add(column);
        return table;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            DataTable table = new SkuController().SelectSkuData(-2147483648, int.Parse(this.Session["CompanyId"].ToString()));
            this.btnCancel.Attributes.Add("onclick", "return ConfirmCancel()");
            clsListItems[] itemsArray = new clsListItems[table.Rows.Count + 1];
            clsListItems[] itemsArray1 = (clsListItems[])this.Session["clsSKUGroupItems"];
            clsListItems[] itemsArray2 = (clsListItems[])this.Session["clsUOMItems"];
            clsDetailListItems[] itemsArray3 = (clsDetailListItems[])this.Session["DistributorListItems"];
            clsDetailListItems[] itemsArray4 = (clsDetailListItems[])this.Session["CustTypeListItems"];
            clsDetailListItems[] itemsArray5 = (clsDetailListItems[])this.Session["CustListItems"];
            itemsArray[0] = new clsListItems("ALL", "0");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                itemsArray[i + 1] = new clsListItems(row[2].ToString(), row[0].ToString());
            }
            this.Session.Add("clsSKUItems", itemsArray);
            DataTable table2 = new DataTable();
            DataColumn column = new DataColumn("BASKET NO", Type.GetType("System.String"));
            table2.Columns.Add(column);
            column = new DataColumn("SKU", Type.GetType("System.String"));
            table2.Columns.Add(column);
            column = new DataColumn("UOM", Type.GetType("System.String"));
            table2.Columns.Add(column);
            column = new DataColumn("Basket On", Type.GetType("System.String"));
            table2.Columns.Add(column);
            column = new DataColumn("From", Type.GetType("System.String"));
            table2.Columns.Add(column);
            column = new DataColumn("To", Type.GetType("System.String"));
            table2.Columns.Add(column);
            column = new DataColumn("Discount", Type.GetType("System.String"));
            table2.Columns.Add(column);
            column = new DataColumn("SKU Offer", Type.GetType("System.String"));
            table2.Columns.Add(column);
            column = new DataColumn("SKU Quantity", Type.GetType("System.String"));
            table2.Columns.Add(column);
            column = new DataColumn("Is_Multiple", Type.GetType("System.String"));
            table2.Columns.Add(column);
            column = new DataColumn("Is_Bundled", Type.GetType("System.String"));
            table2.Columns.Add(column);
            SchemeCollection_Controller controller2 = new SchemeCollection_Controller();
            controller2 = (SchemeCollection_Controller)this.Session["SchCtrl"];
            string str = "Scheme Code : " + controller2.Get(0).Scheme_Code + "\n\nPromotion Name : " + controller2.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).Promotion_Code + "\n\nPromotion For : \n\n";
            for (int j = 0; j < controller2.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjPromotionForCol_Cntrl.Count; j++)
            {
                long num3 = controller2.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjPromotionForCol_Cntrl.Get(j).Assigned_Dist_ID;
                DataTable table3 = new DistributorController().SelectDistributor(int.Parse(num3.ToString()));
                if (table3.Rows.Count > 0)
                {
                    str = str + table3.Rows[0]["DISTRIBUTOR_NAME"].ToString() + "\n";
                }
            }
            str = str + "\nPromotions for Customer type : \n\n";
            for (int k = 0; k < controller2.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjPromotionCustTypeCol_Cntrl.Count; k++)
            {
                long num5 = controller2.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjPromotionCustTypeCol_Cntrl.Get(k).Customer_Type_ID;
                DataTable table4 = new SLASHCodesController().SelectSlashCodes(int.Parse(num5.ToString()), null, 0x2e, null, -2147483648, true);
                if (table4.Rows.Count > 0)
                {
                    str = str + table4.Rows[0]["SLASH_DESC"].ToString() + "\n";
                }
            }
            BasketCollection_Controller controller5 = controller2.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjBasketCol_Cntrl;
            this.txtSummary.Text = str;
            if (controller5.Get(0).Is_Basket)
            {
                for (int m = 0; m < controller5.Count; m++)
                {
                    Basket_Collection t_s = controller2.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjBasketCol_Cntrl.Get(m);
                    int num7 = m + 1;
                    DataRow row2 = table2.NewRow();
                    row2["BASKET NO"] = "Basket # " + num7;
                    row2["SKU"] = "";
                    row2["UOM"] = "";
                    row2["Basket On"] = "";
                    row2["From"] = "";
                    row2["To"] = "";
                    if (t_s.ObjPromotionOfferCol_Cntrl.Get(0).Discount != float.MinValue)
                    {
                        row2["Discount"] = t_s.ObjPromotionOfferCol_Cntrl.Get(0).Discount.ToString() + " %";
                    }
                    else if (t_s.ObjPromotionOfferCol_Cntrl.Get(0).Offer_Value > 0M)
                    {
                        row2["Discount"] = t_s.ObjPromotionOfferCol_Cntrl.Get(0).Offer_Value.ToString() + " /-";
                    }
                    else
                    {
                        row2["Discount"] = "";
                    }
                    if (t_s.ObjPromotionOfferCol_Cntrl.Get(0).SKU_ID != -2147483648)
                    {
                        DataTable table5 = new SkuController().SelectSkuData(t_s.ObjPromotionOfferCol_Cntrl.Get(0).SKU_ID, int.Parse(this.Session["CompanyId"].ToString()));
                        if (table5.Rows.Count > 0)
                        {
                            row2["SKU Offer"] = table5.Rows[0]["SKU_Code"].ToString() + " - " + table5.Rows[0]["SKU_NAME"].ToString();
                        }
                    }
                    else
                    {
                        row2["SKU Offer"] = "";
                    }
                    if (t_s.ObjPromotionOfferCol_Cntrl.Get(0).Quantity != -2147483648)
                    {
                        row2["SKU Quantity"] = t_s.ObjPromotionOfferCol_Cntrl.Get(0).Quantity.ToString();
                    }
                    else
                    {
                        row2["SKU Quantity"] = "";
                    }
                    row2["Is_Multiple"] = t_s.Is_Multiple;
                    row2["Is_Bundled"] = t_s.Is_Bundled;
                    table2.Rows.Add(row2);
                    for (int n = 0; n < t_s.ObjBasketDtlCol_Cntrlr.Count; n++)
                    {
                        DataRow row3 = table2.NewRow();
                        row3["BASKET NO"] = "";
                        if (t_s.ObjBasketDtlCol_Cntrlr.Get(n).SKU_ID == -2147483648)
                        {
                            DataTable table6 = new SKUGroupController().SelectSKUGroup(t_s.ObjBasketDtlCol_Cntrlr.Get(n).SKUGroup_ID, null, int.Parse(this.Session["CompanyId"].ToString()));
                            if (table6.Rows.Count > 0)
                            {
                                row3["SKU"] = table6.Rows[0]["GROUP_NAME"].ToString();
                            }
                        }
                        else if (t_s.ObjBasketDtlCol_Cntrlr.Get(n).SKUGroup_ID == -2147483648)
                        {
                            DataTable table7 = new SkuController().SelectSkuData(t_s.ObjBasketDtlCol_Cntrlr.Get(n).SKU_ID, int.Parse(this.Session["CompanyId"].ToString()));
                            if (table7.Rows.Count > 0)
                            {
                                row3["SKU"] = table7.Rows[0]["SKU_Code"].ToString() + " - " + table7.Rows[0]["SKU_NAME"].ToString();
                            }
                        }
                        DataTable table8 = new SkuController().SelectUOMs(t_s.ObjBasketDtlCol_Cntrlr.Get(n).UOM_ID, null);
                        if (table8.Rows.Count > 0)
                        {
                            row3["UOM"] = table8.Rows[0]["UOM_DESC"].ToString();
                        }
                        if (t_s.Basket_On == 0x53)
                        {
                            row3["Basket On"] = "Amount";
                        }
                        else if (t_s.Basket_On == 0x52)
                        {
                            row3["Basket On"] = "Quantity";
                        }
                        row3["From"] = t_s.ObjBasketDtlCol_Cntrlr.Get(n).Min_Val.ToString();
                        row3["To"] = t_s.ObjBasketDtlCol_Cntrlr.Get(n).Max_Val.ToString();
                        row3["Discount"] = "";
                        row3["SKU Offer"] = "";
                        row3["SKU Quantity"] = "";
                        table2.Rows.Add(row3);
                    }
                }
                this.grdPromotion.DataSource = table2;
                this.grdPromotion.DataBind();
            }
            else
            {
                for (int num9 = 0; num9 < controller5.Count; num9++)
                {
                    Basket_Collection t_s2 = controller2.Get(0).ObjPromotionCol_Cntrl.Get_PCol(0).ObjBasketCol_Cntrl.Get(num9);
                    int num10 = num9 + 1;
                    DataRow row4 = table2.NewRow();
                    row4["BASKET NO"] = "Slab # " + num10;
                    row4["SKU"] = "";
                    row4["UOM"] = "";
                    row4["Basket On"] = "";
                    row4["From"] = "";
                    row4["To"] = "";
                    row4["Discount"] = "";
                    row4["SKU Offer"] = "";
                    row4["SKU Quantity"] = "";
                    row4["Is_Multiple"] = t_s2.Is_Multiple;
                    row4["Is_Bundled"] = t_s2.Is_And;
                    table2.Rows.Add(row4);
                    for (int num11 = 0; num11 < t_s2.ObjBasketDtlCol_Cntrlr.Count; num11++)
                    {
                        DataRow row5 = table2.NewRow();
                        row5["BASKET NO"] = "";
                        if (t_s2.ObjBasketDtlCol_Cntrlr.Get(num11).SKU_ID == -2147483648)
                        {
                            DataTable table9 = new SKUGroupController().SelectSKUGroup(t_s2.ObjBasketDtlCol_Cntrlr.Get(num11).SKUGroup_ID, null, int.Parse(this.Session["CompanyId"].ToString()));
                            if (table9.Rows.Count > 0)
                            {
                                row5["SKU"] = table9.Rows[0]["GROUP_NAME"].ToString();
                            }
                        }
                        else if (t_s2.ObjBasketDtlCol_Cntrlr.Get(num11).SKUGroup_ID == -2147483648)
                        {
                            DataTable table10 = new SkuController().SelectSkuData(t_s2.ObjBasketDtlCol_Cntrlr.Get(num11).SKU_ID, int.Parse(this.Session["CompanyId"].ToString()));
                            if (table10.Rows.Count > 0)
                            {
                                row5["SKU"] = table10.Rows[0]["SKU_Code"].ToString() + " - " + table10.Rows[0]["SKU_NAME"].ToString();
                            }
                        }
                        DataTable table11 = new SkuController().SelectUOMs(t_s2.ObjBasketDtlCol_Cntrlr.Get(num11).UOM_ID, null);
                        if (table11.Rows.Count > 0)
                        {
                            row5["UOM"] = table11.Rows[0]["UOM_DESC"].ToString();
                        }
                        if (t_s2.Basket_On == 0x53)
                        {
                            row5["Basket On"] = "Amount";
                        }
                        else if (t_s2.Basket_On == 0x52)
                        {
                            row5["Basket On"] = "Quantity";
                        }
                        row5["From"] = t_s2.ObjBasketDtlCol_Cntrlr.Get(num11).Min_Val.ToString();
                        row5["To"] = t_s2.ObjBasketDtlCol_Cntrlr.Get(num11).Max_Val.ToString();
                        if (t_s2.ObjPromotionOfferCol_Cntrl.Get(num11).Discount > 0f)
                        {
                            row5["Discount"] = t_s2.ObjPromotionOfferCol_Cntrl.Get(num11).Discount.ToString() + " %";
                        }
                        else if (t_s2.ObjPromotionOfferCol_Cntrl.Get(num11).Offer_Value > 0M)
                        {
                            row5["Discount"] = t_s2.ObjPromotionOfferCol_Cntrl.Get(num11).Offer_Value.ToString() + "/-";
                        }
                        else
                        {
                            row5["Discount"] = "";
                        }
                        if (t_s2.ObjPromotionOfferCol_Cntrl.Get(num11).SKU_ID != -2147483648)
                        {
                            DataTable table12 = new SkuController().SelectSkuData(t_s2.ObjPromotionOfferCol_Cntrl.Get(num11).SKU_ID, int.Parse(this.Session["CompanyId"].ToString()));
                            if (table12.Rows.Count > 0)
                            {
                                row5["SKU Offer"] = table12.Rows[0]["SKU_Code"].ToString() + " - " + table12.Rows[0]["SKU_NAME"].ToString();
                            }
                        }
                        else
                        {
                            row5["SKU Offer"] = "";
                        }
                        if (t_s2.ObjPromotionOfferCol_Cntrl.Get(num11).Quantity != -2147483648)
                        {
                            row5["SKU Quantity"] = t_s2.ObjPromotionOfferCol_Cntrl.Get(num11).Quantity.ToString();
                        }
                        else
                        {
                            row5["SKU Quantity"] = "";
                        }
                        table2.Rows.Add(row5);
                    }
                }
                this.grdPromotion.Columns[0].HeaderText = "Slab No";
                this.grdPromotion.Columns[5].HeaderText = "Slab On";
                this.grdPromotion.Columns[2].Visible = false;
                this.grdPromotion.DataSource = table2;
                this.grdPromotion.DataBind();
            }
        }
    }
}