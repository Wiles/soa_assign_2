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
        private Dictionary<string, configurationServicesService> services = new Dictionary<string, configurationServicesService>();
        private Dictionary<string, configurationServicesServiceMethod> methods = new Dictionary<string, configurationServicesServiceMethod>();

        public mainForm()
        {
            String xmlPath = "C:\\Users\\samuel\\workspace\\soa_assign_2\\xml\\config.xml";
            InitializeComponent();

            XmlSerializer serializer = new XmlSerializer(typeof(configuration));
            configuration resultingMessage = (configuration)serializer.Deserialize(new StreamReader(xmlPath));

            foreach( configurationServicesService service in  resultingMessage.Items[0].service)
            {
                cmboBoxServiceList.Items.Add(service.name);
                services.Add(service.name, service);
            }

        }

        private void cmboBoxServiceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(services.ContainsKey((string)cmboBoxServiceList.SelectedItem)) {
                configurationServicesService service = services[(string)cmboBoxServiceList.SelectedItem];
                cmboBoxMethodList.Items.Clear();
                methods.Clear();
                foreach ( configurationServicesServiceMethod method in service.method) 
                {
                    cmboBoxMethodList.Items.Add(method.method_name);
                    methods.Add(method.method_name, method);
                }
            }
        }
    }
}
