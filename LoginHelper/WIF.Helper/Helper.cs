using System;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Web;
using System.Xml;
using System.IdentityModel;
using System.IdentityModel.Protocols.WSTrust;
using System.Xml.Linq;
using System.Linq;

namespace SUKUL.WIF.Helper
{
    /// <summary>
    /// This Helper class will be called in the ExecutingWebRequest event of the ClientContext object to attach an ADFS cookie to the context
    /// to allow authenticated calls to succeed.
    /// <example>
    /// ClientContext ctx = new ClientContext(webUrl);
    /// ctx.ExecutingWebRequest += new EventHandler<WebRequestEventArgs>(ctx_ExecutingWebRequest);
    /// void ctx_ExecutingWebRequest(object sender, WebRequestEventArgs e)
    ///    {
    ///        try
    ///        {
    ///            e.WebRequestExecutor.WebRequest.CookieContainer = Helper.AttachCookie(txtWctx.Text, txtWtrealm.Text, txtWreply.Text, txtcorpStsUrl.Text, txtUserId.Text,
    ///                  txtPassword.Text); 
    ///        ...
    /// </example>
    /// <author>Shailen Sukul</author>
    /// <date>Jul 29 2010</date>
    /// </summary>
    public class Helper
    {
        public const string Issue = "http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue";
        public const string wsse = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";
        public const string wsu = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd";
        public const string userAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)";

        /* Store the cookie in a static container */
        private static CookieContainer _cc = null;
        /* Store the current wtrealm so that the cookie can be invalidated when the realm changes */
        private static string _wtrealm = string.Empty;

        static HttpWebRequest CreateRequest(string url)
        {
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = new CookieContainer();
            request.AllowAutoRedirect = false; // Do NOT automatically redirect
            request.UserAgent = userAgent;
            return request;
        }

        public static void InValidateCookie()
        {
            _cc = null;
        }
        /// <summary>
        /// This will locate the FedAuth cookie, add it to the cookie container and return it.
        /// </summary>
        /// <param name="wctx"></param>
        /// <param name="wtrealm"></param>
        /// <param name="wreply"></param>
        /// <param name="stsUrl"></param>
        /// <param name="userid"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static CookieContainer AttachCookie(string wctx, string wtrealm, string wreply, string stsUrl, string userid, string password)
        {
            if (_cc == null || wtrealm != _wtrealm)
            {
                try
                {
                    _wtrealm = wtrealm;
                    _cc = new CookieContainer();
                    //Cookie samlAuth = new Cookie("FedAuth", Helper.GetFedAuthCookie(wctx, wtrealm, wreply, corpStsUrl, userid, password));
//                    Cookie samlAuth = new Cookie("FedAuth", Helper.GetFedAuthCookie(wctx, wtrealm, wreply, corpStsUrl, userid, password));                    
                    Helper.GetFedAuthCookie(wctx, wtrealm, wreply, stsUrl, userid, password);
                    //samlAuth.Expires = DateTime.Now.AddHours(1);
                    //samlAuth.Path = "/";
                    //samlAuth.Secure = true;
                    //samlAuth.HttpOnly = true;
                    //Uri samlUri = new Uri(wtrealm);
                    //samlAuth.Domain = samlUri.Host;
                   // _cc.Add(samlAuth);

                }
                catch
                {
                    /* Invalidate Cookie */
                    InValidateCookie();
                    throw;
                }
            }
            return _cc;
        }

        /// <summary>
        /// Make an ADFS call to get the FedAuth cookie
        /// </summary>
        /// <param name="wctx"></param>
        /// <param name="wtrealm"></param>
        /// <param name="wreply"></param>
        /// <param name="stsUrl"></param>
        /// <param name="userid"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private static void GetFedAuthCookie(string wctx, string wtrealm, string wreply, string stsUrl, string userid, string password)
        {
            var sharepointSite = new
            {
                Wctx = wctx,
                Wtrealm = wtrealm,
                Wreply = wreply
            };
            string fedAuth = string.Empty;
            string rtFaToken = string.Empty;

            var credentials = new { Username = userid, Password = password };
            Cookie samlAuth = null;
            Cookie rtFa = null;
            //
            // Get token from STS
            // 
            string stsResponse = Helper.GetResponse(
                stsUrl,
                sharepointSite.Wtrealm,
                credentials.Username,
                credentials.Password);

            // parse the token response
            XDocument doc = XDocument.Parse(stsResponse);

            // get the security token
            string crypt = string.Empty;
            try
            {
                crypt = (from result in doc.Descendants()
                         where result.Name == XName.Get("BinarySecurityToken", wsse)
                         select result).FirstOrDefault().Value;
            }
            catch
            {
                crypt = (from result in doc.Descendants()
                         where result.Name == XName.Get("t:RequestedSecurityToken", wsse)
                         select result).FirstOrDefault().Value;
            }

            // get the token expiration
            var expires = Convert.ToDateTime((from result in doc.Descendants()
                          where result.Name == XName.Get("Expires", wsu)
                          select result).First().Value);

            //
            // Generate response to Sharepoint
            //
            string stringData = String.Format("wa=wsignin1.0&wctx={0}&wresult={1}",
                HttpUtility.UrlEncode(sharepointSite.Wctx),
                HttpUtility.UrlEncode(stsResponse));

            HttpWebRequest sharepointRequest = CreateRequest(sharepointSite.Wreply) as HttpWebRequest;
            
            sharepointRequest.Method = "POST";
            sharepointRequest.ContentType = "application/x-www-form-urlencoded";
            sharepointRequest.CookieContainer = new CookieContainer();
            sharepointRequest.AllowAutoRedirect = false; // This is important
            byte[] data = null;
            using (Stream newStream = sharepointRequest.GetRequestStream())
            {

                data = Encoding.UTF8.GetBytes(crypt);
                newStream.Write(data, 0, data.Length);
                newStream.Close();
            }

            samlAuth = new Cookie();
            rtFa = new Cookie();

            HttpWebResponse webResponse = sharepointRequest.GetResponse() as HttpWebResponse;
            // Handle redirect, added may 2011 for P-subscriptions
            if (webResponse.StatusCode == HttpStatusCode.MovedPermanently)
            {
                HttpWebRequest request2 = CreateRequest(webResponse.Headers["Location"]) as HttpWebRequest;
                using (Stream stream2 = request2.GetRequestStream())
                {
                    stream2.Write(data, 0, data.Length);
                    stream2.Close();

                    using (HttpWebResponse webResponse2 = request2.GetResponse() as HttpWebResponse)
                    {
                        fedAuth = webResponse2.Cookies["FedAuth"].Value;
                        samlAuth.Secure = request2.RequestUri.Scheme == "https";
                        samlAuth.Domain = request2.RequestUri.Host;
                        rtFaToken = webResponse2.Cookies["rtFa"].Value;                        
                        //ret.rtFa = webResponse2.Cookies["rtFa"].Value;
                        //ret.Host = request2.RequestUri;
                        //fedAuth = webResponse.Cookies["FedAuth"].Value;

                        // Set the rtFA (sign-out) cookie, added march 2011                       
                        rtFa.Secure = request2.RequestUri.Scheme == "https";
                        rtFa.Domain = request2.RequestUri.Host;                        
                    }
                }
            }
            else
            {
                fedAuth = webResponse.Cookies["FedAuth"].Value;
                samlAuth.Secure = sharepointRequest.RequestUri.Scheme == "https";
                samlAuth.Domain = sharepointRequest.Host;
                rtFaToken = webResponse.Cookies["rtFa"].Value;
                rtFa.Secure = sharepointRequest.RequestUri.Scheme == "https";
                rtFa.Domain = sharepointRequest.Host;
                
            }
            
            // large cookie may be chunked: FedAuth, FedAuth1, FedAuth2, etc
            // Need to get all chunks and send back.
           // samlAuth = new Cookie("FedAuth", fedAuth);
            samlAuth.Name = "FedAuth";
            samlAuth.HttpOnly = true;
            samlAuth.Value = fedAuth;
            samlAuth.Expires = expires;
            samlAuth.Path = "/";

            // Set the rtFA (sign-out) cookie, added march 2011  
            rtFa.Name = "rtFA";
            rtFa.Value = rtFaToken;
            rtFa.Expires = expires;
            rtFa.Path = "/";
            rtFa.HttpOnly = true;

            Uri samlUri = new Uri(wtrealm);
            samlAuth.Domain = samlUri.Host;
            _cc.Add(samlAuth);
            _cc.Add(rtFa);

        }

        /// <summary>
        /// Helper Method
        /// </summary>
        /// <param name="stsUrl"></param>
        /// <param name="realm"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private static string GetResponse(string stsUrl, string realm, string username, string password)
        {
            RequestSecurityToken rst = new RequestSecurityToken
            {
                RequestType = System.IdentityModel.Protocols.WSTrust.RequestTypes.Issue,
                AppliesTo = new EndpointReference(realm),
                //AppliesTo = new EndpointReference("urn:federation:MicrosoftOnline"),
                KeyType = System.IdentityModel.Protocols.WSTrust.KeyTypes.Bearer
            };
            WSTrustFeb2005RequestSerializer trustSerializer = new WSTrustFeb2005RequestSerializer();
            WSHttpBinding binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.TransportWithMessageCredential;
            binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
            binding.Security.Message.EstablishSecurityContext = false;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            
            EndpointAddress address = new EndpointAddress(stsUrl);
            using (WSTrustFeb2005ContractClient trustClient = new WSTrustFeb2005ContractClient(binding, address))
            {
                trustClient.ClientCredentials.UserName.UserName = username;
                trustClient.ClientCredentials.UserName.Password = password;
                Message response = trustClient.EndIssue(
                        trustClient.BeginIssue(
                                                Message.CreateMessage(
                                                    MessageVersion.Default,
                                                    Issue,
                                                    new RequestBodyWriter(trustSerializer, rst)
                                               ),
                                               null,
                                               null));
                trustClient.Close();

                using (XmlDictionaryReader reader = response.GetReaderAtBodyContents())
                {
                    return reader.ReadOuterXml();
                }
            }
        }
    }
}
