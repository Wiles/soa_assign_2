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
        private Dictionary<configurationServicesServiceMethodParamter, TextBox> paramters = new Dictionary<configurationServicesServiceMethodParamter, TextBox>();

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
            if (services.ContainsKey((string)cmboBoxServiceList.SelectedItem))
            {
                configurationServicesService service = services[(string)cmboBoxServiceList.SelectedItem];
                cmboBoxMethodList.Items.Clear();
                foreach (configurationServicesServiceMethod method in service.method)
                {
                    cmboBoxMethodList.Items.Add(method.method_name);
                    methods.Add(method.method_name, method);
                }
            }
            else
            {
                methods.Clear();
            }

        }

        private void cmboBoxMethodList_SelectedIndexChanged(object sender, EventArgs e)
        {
            parameterPanel.Controls.Clear();
            if (methods.ContainsKey((string)cmboBoxMethodList.SelectedItem)) {
                foreach ( configurationServicesServiceMethodParamter parameter in methods[(string)cmboBoxMethodList.SelectedItem].request) {
                    Label l = new Label();
                    l.Text = parameter.name + " - " + parameter.type;
                    parameterPanel.Controls.Add(l);
                    TextBox t = new TextBox();
                    t.Width = parameterPanel.Width;
                    parameterPanel.Controls.Add(t);
                    paramters.Add(parameter, t);
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            configurationServicesService currentService = services[(string)cmboBoxServiceList.SelectedItem];
            configurationServicesServiceMethod currentMethod = methods[(string)cmboBoxMethodList.SelectedItem];
            Dictionary<configurationServicesServiceMethodParamter, string> currentParameters = new Dictionary<configurationServicesServiceMethodParamter, string> ();


            foreach (configurationServicesServiceMethodParamter parameter in methods[(string)cmboBoxMethodList.SelectedItem].request)
            {
                currentParameters.Add(parameter, paramters[parameter].Text);
                
            }

            //TODO validate parameters gainst their types
            //TODO build soap request
            //TODO send request
            //TODO parse response

        }
    }
}
