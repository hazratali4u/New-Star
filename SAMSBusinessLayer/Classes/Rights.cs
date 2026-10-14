namespace SAMS.BusinessLayer.Classes
{
    using System;

    public class Rights
    {
        private bool m_CanAdd;
        private bool m_CanDelete;
        private bool m_CanUpdate;
        private bool m_CanView;
        private int m_ModuleID;
        private string m_ModuleName;
        private int m_RoleID;
        private string m_RoleName;

        public Rights()
        {
        }

        public Rights(int RID, string RName, bool CView, bool CAdd, bool CUpdate, bool CDelete, int MID, string MName)
        {
            this.m_RoleID = RID;
            this.m_RoleName = RName;
            this.m_CanView = CView;
            this.m_CanAdd = CAdd;
            this.m_CanUpdate = CUpdate;
            this.m_CanDelete = CDelete;
            this.m_ModuleID = MID;
            this.m_ModuleName = MName;
        }

        public bool CanAdd
        {
            get
            {
                return this.m_CanAdd;
            }
        }

        public bool CanDelete
        {
            get
            {
                return this.m_CanDelete;
            }
        }

        public bool CanUpdate
        {
            get
            {
                return this.m_CanUpdate;
            }
        }

        public bool CanView
        {
            get
            {
                return this.m_CanView;
            }
        }

        public int ModuleID
        {
            get
            {
                return this.m_ModuleID;
            }
        }

        public string ModuleName
        {
            get
            {
                return this.m_ModuleName;
            }
        }

        public int RoleID
        {
            get
            {
                return this.m_RoleID;
            }
        }

        public string RoleName
        {
            get
            {
                return this.m_RoleName;
            }
        }
    }
}

