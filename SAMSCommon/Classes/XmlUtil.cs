namespace SAMS
{
    using System;
    using System.Xml;

    public class XmlUtil
    {
        private string m_nodeText;
        private string m_path;
        private XmlDocument xmlDoc;

        public XmlUtil()
        {
        }

        public XmlUtil(string p_path)
        {
            this.xmlDoc = new XmlDocument();
            this.xmlDoc.Load(p_path);
            this.Path = p_path;
        }

        public void CloseDocument()
        {
            if (this.xmlDoc != null)
            {
                this.xmlDoc = null;
            }
        }

        public void CreateNode(string p_nodeName, string p_nodeText)
        {
            XmlElement element;
            if (this.xmlDoc.HasChildNodes)
            {
                element = this.xmlDoc.CreateElement(p_nodeName);
                element.InnerText = p_nodeText;
                this.xmlDoc.DocumentElement.AppendChild(element);
                this.xmlDoc.Save(this.Path + "AppSettings.xml");
            }
            else
            {
                element = this.xmlDoc.CreateElement(p_nodeName);
                element.InnerText = p_nodeText;
                XmlNode node = this.xmlDoc.AppendChild(element);
                this.xmlDoc.Save(this.Path + "AppSettings.xml");
            }
        }

        public string GetNode(string p_nodeName)
        {
            if (p_nodeName.Equals(""))
            {
                this.m_nodeText = "Node name missing";
                return this.m_nodeText;
            }
            this.m_nodeText = "";
            if (this.xmlDoc.HasChildNodes)
            {
                if (this.xmlDoc.DocumentElement.HasChildNodes)
                {
                    XmlNode firstChild = this.xmlDoc.DocumentElement.FirstChild;
                    if (firstChild.Name == p_nodeName)
                    {
                        this.m_nodeText = firstChild.InnerText;
                    }
                    else
                    {
                        XmlNode lastChild = this.xmlDoc.DocumentElement.LastChild;
                        do
                        {
                            if ((firstChild == lastChild) && (firstChild.Name != p_nodeName))
                            {
                                this.m_nodeText = "";
                                return this.m_nodeText;
                            }
                            firstChild = firstChild.NextSibling;
                        }
                        while (firstChild.Name != p_nodeName);
                        this.m_nodeText = firstChild.InnerText;
                    }
                }
                return this.m_nodeText;
            }
            return (this.m_nodeText = "Invalid XML Document");
        }

        public void Save()
        {
            this.xmlDoc.Save(this.Path);
        }

        public void SetNode(string p_nodeName, string p_nodeText)
        {
            if ((!p_nodeName.Equals("") || !p_nodeText.Equals("")) && !p_nodeName.Equals(""))
            {
                if (this.xmlDoc.HasChildNodes)
                {
                    if (!this.xmlDoc.DocumentElement.HasChildNodes)
                    {
                        this.CreateNode(p_nodeName, p_nodeText);
                    }
                    else
                    {
                        XmlNode firstChild = this.xmlDoc.DocumentElement.FirstChild;
                        if (firstChild.Name == p_nodeName)
                        {
                            firstChild.InnerText = "";
                            firstChild.InnerText = p_nodeText;
                        }
                        else
                        {
                            XmlNode lastChild = this.xmlDoc.DocumentElement.LastChild;
                            do
                            {
                                if ((firstChild == lastChild) && (firstChild.Name != p_nodeName))
                                {
                                    this.CreateNode(p_nodeName, p_nodeText);
                                    return;
                                }
                                firstChild = firstChild.NextSibling;
                            }
                            while (firstChild.Name != p_nodeName);
                            if (firstChild.Name == p_nodeName)
                            {
                                firstChild.InnerText = "";
                                firstChild.InnerText = p_nodeText;
                            }
                        }
                    }
                }
                else
                {
                    this.CreateNode(p_nodeName, p_nodeText);
                }
            }
        }

        public string Path
        {
            get
            {
                return this.m_path;
            }
            set
            {
                this.m_path = value;
            }
        }
    }
}

