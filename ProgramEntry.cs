using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Xml;
using System.Xml.Serialization;
namespace soa_assign_II
{
    static class ProgramEntry
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new mainForm());
            Dictionary<string, configurationServicesService> _services = new Dictionary<string, configurationServicesService>();
            try
            {
                //String xmlPath = @"C:\Users\samuel\workspace\soa_assign_2\xml\config.xml";
                String xmlPath = @"D:\Users\Stephen\Documents\Visual Studio 2012\Projects\SOAII\xml\config.xml";

                XmlSerializer serializer = new XmlSerializer(typeof(configuration));
                configuration resultingMessage = (configuration)serializer.Deserialize(new StreamReader(xmlPath));

                foreach (configurationServicesService service in resultingMessage.Items[0].service)
                {
                //    cmboBoxServiceList.Items.Add(service.name);
                    _services.Add(service.name, service);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Failed to parse config file. " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Application.Run(new mainForm(_services));
        }
    }
}
