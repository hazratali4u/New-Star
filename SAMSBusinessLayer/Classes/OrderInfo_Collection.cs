namespace SAMS.BusinessLayer.Classes
{
    using System;

    public class OrderInfo_Collection
    {
        private long m_AreaID;
        private int m_CustomerTypeByWork;
        private bool m_IsNewOrder;
        private int m_OrderStatusId;
        private string m_SelectedCustomerId;

        public long Area_ID
        {
            get
            {
                return this.m_AreaID;
            }
            set
            {
                this.m_AreaID = value;
            }
        }

        public int CustomerTypeByWork
        {
            get
            {
                return this.m_CustomerTypeByWork;
            }
            set
            {
                this.m_CustomerTypeByWork = value;
            }
        }

        public bool IsNewOrder
        {
            get
            {
                return this.m_IsNewOrder;
            }
            set
            {
                this.m_IsNewOrder = value;
            }
        }

        public int OrderStatusId
        {
            get
            {
                return this.m_OrderStatusId;
            }
            set
            {
                this.m_OrderStatusId = value;
            }
        }

        public string SelectedCustomerId
        {
            get
            {
                return this.m_SelectedCustomerId;
            }
            set
            {
                this.m_SelectedCustomerId = value;
            }
        }
    }
}

