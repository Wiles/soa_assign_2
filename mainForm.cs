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
using System.Net;
using System.Xml.Linq;

using System.Xml;
using System.Xml.Serialization;

namespace soa_assign_II
{
    public partial class mainForm : Form
    {
        private Dictionary<string, configurationServicesService> _services = new Dictionary<string, configurationServicesService>();
        private Dictionary<string, configurationServicesServiceMethod> _methods = new Dictionary<string, configurationServicesServiceMethod>();
        private Dictionary<configurationServicesServiceMethodParameter, TextBox> _parameters = new Dictionary<configurationServicesServiceMethodParameter, TextBox>();

        public mainForm()
        {
            try
            {
                //String xmlPath = @"C:\Users\samuel\workspace\soa_assign_2\xml\config.xml";
                String xmlPath = @"D:\Users\Stephen\Documents\Visual Studio 2012\Projects\SOAII\xml\config.xml";
                InitializeComponent();

                XmlSerializer serializer = new XmlSerializer(typeof(configuration));
                configuration resultingMessage = (configuration)serializer.Deserialize(new StreamReader(xmlPath));

                foreach (configurationServicesService service in resultingMessage.Items[0].service)
                {
                    cmboBoxServiceList.Items.Add(service.name);
                    this._services.Add(service.name, service);
                }
            }
            catch (Exception exc) 
            {
                MessageBox.Show("Failed to parse config file. " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void cmboBoxServiceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._methods.Clear();
            cmboBoxMethodList.SelectedIndex = -1;
            cmboBoxMethodList.Items.Clear();
            if (this._services.ContainsKey((string)cmboBoxServiceList.SelectedItem))
            {
                configurationServicesService service = this._services[(string)cmboBoxServiceList.SelectedItem];
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
            if (cmboBoxMethodList.SelectedItem != null && this._methods.ContainsKey((string)cmboBoxMethodList.SelectedItem)) 
            {
                foreach (configurationServicesServiceMethodParameter parameter in this._methods[(string)cmboBoxMethodList.SelectedItem].request) 
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
            tvResults.Nodes.Clear();
            try
            {
                string URL = "";
                string nameSpace = "";
                string method = "";
                Dictionary<string, string> parameters = new Dictionary<string, string>();

                if (this._services.ContainsKey((string)cmboBoxServiceList.SelectedItem))
                {
                    configurationServicesService service = this._services[(string)cmboBoxServiceList.SelectedItem];
                    nameSpace = service.target_namespace;
                    URL = service.service_URL;
                }

                if (this._methods.ContainsKey((string)cmboBoxMethodList.SelectedItem))
                {
                    method = (string)cmboBoxMethodList.SelectedItem;
                }

                foreach (KeyValuePair<configurationServicesServiceMethodParameter, TextBox> prms in this._parameters)
                {
                    String tempValue = (String)prms.Value.Text;
                    String tempName = (String)prms.Value.Name;

                    switch (prms.Key.type)
                    {
                        case ("string"):
                            //Nothing to do here
                            break;
                        case ("boolean"):
                            bool b = new bool();
                            if (!Boolean.TryParse(tempValue, out b))
                            {
                                MessageBox.Show("Failed to read value for parameter " + tempName + " value should be either true or false.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            break;
                        case ("int"):
                            Int64 i = new Int64();
                            if (!Int64.TryParse(tempValue, out i))
                            {
                                MessageBox.Show("Failed to read value for parameter " + tempName + " value should be an Integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            break;
                        case ("double"):
                            Double d = new Double();
                            if (!Double.TryParse(tempValue, out d))
                            {
                                MessageBox.Show("Failed to read value for parameter " + tempName + " value should be a Double.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            break;
                        default:
                            //Unknown type no additional validation done
                            break;
                    }
                    parameters.Add(tempName, tempValue);
                }
                SoapRequest soapRequest = new SoapRequest(URL, nameSpace, method, parameters);
                try
                {
                    string result = soapRequest.CallWebService();
                    txtResult.Text = result;
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(result);

                    TreeNode newNode = CreateNode(doc.SelectSingleNode("//*[local-name()='Body']"));
                    tvResults.Nodes.Add(newNode);
                    tvResults.ExpandAll();
                    tvResults.SelectedNode = newNode;
                }
                catch (WebException ex)
                {
                    MessageBox.Show("Request returned error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
            catch (Exception ex) 
            {
                MessageBox.Show("Error handling request: " + ex.Message , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TreeNode CreateNode(XmlNode nodes)
        {   
            if (nodes.ChildNodes.Count == 0)
            {
                return new TreeNode(nodes.InnerText);
            }
            else
            {
                List<TreeNode> nodesList = new List<TreeNode>();
                foreach ( XmlNode node in nodes)
                {
                    nodesList.Add(CreateNode(node));
                }
                return new TreeNode(nodes.Name, nodesList.ToArray());
            }
        }
    }
}