using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System.Xml;
using System.Xml.Serialization;

namespace soa_assign_II
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            String xmlPath = "C:\\Users\\samuel\\workspace\\soa_assign_2\\xml\\config.xml";
            InitializeComponent();

            XmlSerializer serializer = new XmlSerializer(typeof(configuration));
            configuration resultingMessage = (configuration)serializer.Deserialize(new StreamReader(xmlPath));

            object[] services = resultingMessage.Items;

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
