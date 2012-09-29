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
        private Dictionary<string, configurationServicesService> _services = new Dictionary<string, configurationServicesService>();
        private Dictionary<string, configurationServicesServiceMethod> _methods = new Dictionary<string, configurationServicesServiceMethod>();
        private Dictionary<configurationServicesServiceMethodParamter, TextBox> _parameters = new Dictionary<configurationServicesServiceMethodParamter, TextBox>();

        public mainForm()
        {
            String xmlPath = @"D:\Users\Stephen\Documents\Visual Studio 2012\Projects\SOAII\xml\config.xml";
            InitializeComponent();

            XmlSerializer serializer = new XmlSerializer(typeof(configuration));
            configuration resultingMessage = (configuration)serializer.Deserialize(new StreamReader(xmlPath));

            foreach( configurationServicesService service in  resultingMessage.Items[0].service)
            {
                cmboBoxServiceList.Items.Add(service.name);
                this._services.Add(service.name, service);
            }
        }

        private void cmboBoxServiceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._methods.Clear();
            if (this._services.ContainsKey((string)cmboBoxServiceList.SelectedItem))
            {
                configurationServicesService service = this._services[(string)cmboBoxServiceList.SelectedItem];
                cmboBoxMethodList.Items.Clear();
                foreach (configurationServicesServiceMethod method in service.method)
                {
                    cmboBoxMethodList.Items.Add(method.method_name);
                    this._methods.Add(method.method_name, method);
                }
            }
        }

        private void cmboBoxMethodList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._parameters.Clear();
            parameterPanel.Controls.Clear();
            if (this._methods.ContainsKey((string)cmboBoxMethodList.SelectedItem)) 
            {
                foreach (configurationServicesServiceMethodParamter parameter in this._methods[(string)cmboBoxMethodList.SelectedItem].request) 
                {
                    Label l = new Label();
                    l.Text = parameter.name;
                    parameterPanel.Controls.Add(l);

                    TextBox t = new TextBox();
                    t.Width = parameterPanel.Width;
                    t.Name = parameter.name;
                    parameterPanel.Controls.Add(t);
                    this._parameters.Add(parameter, t);
                }
            }
        }

        private void btnEngageService_Click(object sender, EventArgs e)
        {
            string URL = "";
            string nameSpace = "";
            string method = "";
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            if (this._services.ContainsKey((string)cmboBoxServiceList.SelectedItem))
            {
                configurationServicesService service = this._services[(string)cmboBoxServiceList.SelectedItem];
                nameSpace = service.service_URL;
                URL = service.xmlns_tns;
            }

            if (this._methods.ContainsKey((string)cmboBoxMethodList.SelectedItem))
            {
                method = (string)cmboBoxMethodList.SelectedItem;
            }

            foreach(KeyValuePair<configurationServicesServiceMethodParamter, TextBox> prms in this._parameters)
            {
                TextBox temp = (TextBox)prms.Value;
                parameters.Add(temp.Name, temp.Text);
            }
            SoapRequest soapRequest = new SoapRequest(URL, nameSpace, method, parameters);
            string result = soapRequest.CallWebService();
            txtResult.Text = result;
        }
    }
}