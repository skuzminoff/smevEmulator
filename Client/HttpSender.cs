using System.IO;
using System.Net;
using System.Xml.Linq;

namespace Grad.Smev.SmevEmulator.Client
{
    public class HttpSender
    {
        public XDocument Send(string envelope, string wsdlUri, string soapAction)
        {
            XDocument response = new XDocument();
            HttpWebRequest wr = CreateSoapRequest(wsdlUri, soapAction);

            using (Stream stream = wr.GetRequestStream())
            {
                using (StreamWriter sw = new StreamWriter(stream))
                {
                    sw.Write(envelope);
                }
            }

            HttpWebResponse res;
            try
            {
                res = (HttpWebResponse)wr.GetResponse();
            }
            catch (WebException ex)
            {
                res = (HttpWebResponse)ex.Response;
            }

            using (StreamReader sr = new StreamReader(res.GetResponseStream()))
            {
                string text = sr.ReadToEnd();
                response = XDocument.Parse(text);
            }

            return response;
        }

        //public XDocument Send(string envelope, string wsdlUri, SoapActionTypes soapActionType)
        //{
        //    XDocument response = new XDocument();

        //    HttpWebRequest wr = CreateSoapRequest(wsdlUri, _getSoapAction(soapActionType));

        //    using (Stream stream = wr.GetRequestStream())
        //    {
        //        using (StreamWriter sw = new StreamWriter(stream))
        //        {
        //            sw.Write(envelope);
        //        }
        //    }

        //    HttpWebResponse res;
        //    try
        //    {
        //        res = (HttpWebResponse)wr.GetResponse();
        //    }
        //    catch (WebException ex)
        //    {
        //        res = (HttpWebResponse)ex.Response;
        //    }

        //    using (StreamReader sr = new StreamReader(res.GetResponseStream()))
        //    {
        //        string text = sr.ReadToEnd();
        //        response = XDocument.Parse(text);
        //    }

        //    return response;
        //}

        private HttpWebRequest CreateSoapRequest(string uri, string soapAction)
        {
            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(uri);
           // wr.Headers.Add("SOAPAction", soapAction);
            wr.ContentType = "application/xml;charset=\"utf-8\"";
            wr.Accept = "application/xml";
            wr.Method = "POST";
            wr.KeepAlive = true;
            return wr;
        }

        //private string _getSoapAction(SoapActionTypes soapActionType)
        //{
        //    if (soapActionType == SoapActionTypes.Ack)
        //        return ConfigurationManager.SoapActions.Ack;
        //    if (soapActionType == SoapActionTypes.GetIncomingStatistics)
        //        return ConfigurationManager.SoapActions.GetIncomingQueueStatistics;
        //    if (soapActionType == SoapActionTypes.GetRequest)
        //        return ConfigurationManager.SoapActions.GetRequest;
        //    if (soapActionType == SoapActionTypes.GetResponse)
        //        return ConfigurationManager.SoapActions.GetResponse;
        //    if (soapActionType == SoapActionTypes.SendRequest)
        //        return ConfigurationManager.SoapActions.SendRequest;
        //    if (soapActionType == SoapActionTypes.SendResponse)
        //        return ConfigurationManager.SoapActions.SendResponse;

        //    return null;
        //}
    }
}
