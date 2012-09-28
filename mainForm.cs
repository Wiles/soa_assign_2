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
using System.Xml.Serialization;

namespace soa_assign_II
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();

            XmlSerializer serializer = new XmlSerializer(typeof(services));
            services resultingMessage = (services)serializer.Deserialize(new StreamReader(xmlPath));

            Services = resultingMessage.Items;

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
