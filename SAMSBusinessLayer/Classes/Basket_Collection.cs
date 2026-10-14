namespace SAMS.BusinessLayer.Classes
{
    using System;

    public class Basket_Collection
    {
        private long mBasket_ID;
        private int mBasket_On;
        private int mBasket_Selection;
        private int mDist_ID;
        private bool mIs_And;
        private bool mIs_Basket;
        private bool mIs_IsBundled;
        private bool mIs_Multiple;
        private long mPromotion_ID;
        private int mScheme_ID;
        private BasketDetailCollection_Controller objBasketDtlCol_Cntrlr;
        private PromotionOfferColl_Controller objPromotionOfferCol_Cntrl;

        public long Basket_ID
        {
            get
            {
                return this.mBasket_ID;
            }
            set
            {
                this.mBasket_ID = value;
            }
        }

        public int Basket_On
        {
            get
            {
                return this.mBasket_On;
            }
            set
            {
                this.mBasket_On = value;
            }
        }

        public int Basket_Selection
        {
            get
            {
                return this.mBasket_Selection;
            }
            set
            {
                this.mBasket_Selection = value;
            }
        }

        public int Dist_ID
        {
            get
            {
                return this.mDist_ID;
            }
            set
            {
                this.mDist_ID = value;
            }
        }

        public bool Is_And
        {
            get
            {
                return this.mIs_And;
            }
            set
            {
                this.mIs_And = value;
            }
        }

        public bool Is_Basket
        {
            get
            {
                return this.mIs_Basket;
            }
            set
            {
                this.mIs_Basket = value;
            }
        }

        public bool Is_Bundled
        {
            get
            {
                return this.mIs_IsBundled;
            }
            set
            {
                this.mIs_IsBundled = value;
            }
        }

        public bool Is_Multiple
        {
            get
            {
                return this.mIs_Multiple;
            }
            set
            {
                this.mIs_Multiple = value;
            }
        }

        public BasketDetailCollection_Controller ObjBasketDtlCol_Cntrlr
        {
            get
            {
                return this.objBasketDtlCol_Cntrlr;
            }
            set
            {
                this.objBasketDtlCol_Cntrlr = value;
            }
        }

        public PromotionOfferColl_Controller ObjPromotionOfferCol_Cntrl
        {
            get
            {
                return this.objPromotionOfferCol_Cntrl;
            }
            set
            {
                this.objPromotionOfferCol_Cntrl = value;
            }
        }

        public long Promotion_ID
        {
            get
            {
                return this.mPromotion_ID;
            }
            set
            {
                this.mPromotion_ID = value;
            }
        }

        public int Scheme_ID
        {
            get
            {
                return this.mScheme_ID;
            }
            set
            {
                this.mScheme_ID = value;
            }
        }
    }
}

