using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml;
using System.IO;

namespace soa_assign_II
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            ParseXML();
            InitializeComponent();



        }

        private void ParseXML(string path = @"..\..\xml\config.xml")
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            XmlReader reader = XmlReader.Create(fs);

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        switch (reader.Name)
                        {
                            case "service":
                                continue;
                            case "method":
                                continue;
                            case "parameter":
                                continue;
                            default: continue;
                        }
                    default: continue;
                }
            }



        }

        private void cmboBoxServiceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            XmlDocument configFile = new XmlDocument();
            configFile.Load(@"..\..\xml\config.xml");

            XmlNodeList services = configFile.GetElementsByTagName("service");
            foreach (XmlNode node in services)
            {
                XmlNodeList child = node.ChildNodes;
                foreach (XmlNode childNode in child)
                {
                    cmboBoxServiceList.Items.Add(childNode.Name.ToString());
                }
            }
        }
    }
}
