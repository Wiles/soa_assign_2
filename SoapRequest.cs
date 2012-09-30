using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;
using System.Xml;

namespace soa_assign_II
{
    class SoapRequest
    {
        //The URL of the web service
        private string _url;
        private string _nameSpace;
        //The method you want to call
        private string _function;
        //The parameters
        private Dictionary<string, string> _parameters;

        public SoapRequest(string URL, string nameSpace, string function, Dictionary<string, string> parameters)
        {
            this._url = URL;
            this._nameSpace = nameSpace;
            this._function = function;
            this._parameters = parameters;
        }

        public string CallWebService()
        {
            //this._url = "http://footballpool.dataaccess.eu/data/info.wso";
            //this._action = "AllPlayerNames";

            XmlDocument soapEnvelopeXml = CreateSoapEnvelope();
            HttpWebRequest webRequest = CreateWebRequest(this._url, this._function);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            // begin async call to web request.
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            // suspend this thread until call is complete. display load screen here or something.
            asyncResult.AsyncWaitHandle.WaitOne();

            // get the response from the completed web request.
            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
            {
                soapResult = rd.ReadToEnd();
            }
            return soapResult;
        }

        private HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private XmlDocument CreateSoapEnvelope()
        {
            string soapEnvelope = "";
            soapEnvelope = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
                "<soap:Body>" +
                "<" + this._function.ToString().Replace(" ", string.Empty) + " xmlns=\"" + this._nameSpace + "\">";

            foreach (KeyValuePair<string, string> param in this._parameters)
            {
                soapEnvelope += "<" + param.Key.ToString().Replace(" ", string.Empty) + ">";
                soapEnvelope += param.Value;
                soapEnvelope += "</" + param.Key.ToString().Replace(" ", string.Empty) + ">";
            }
            soapEnvelope += "</" + this._function.ToString().Replace(" ", string.Empty) + ">";
            soapEnvelope += "</soap:Body></soap:Envelope>";

            XmlDocument soapEnvelop = new XmlDocument();
            soapEnvelop.LoadXml(soapEnvelope);
            return soapEnvelop;
        }

        private void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }
}
