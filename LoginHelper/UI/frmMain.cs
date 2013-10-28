using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Microsoft.SharePoint.Client;
using SUKUL.WIF.Helper;

namespace ADFS_Test
{
    public partial class frmMain : System.Windows.Forms.Form
    {
        public frmMain()
        {
            InitializeComponent();
            rdOffice365.Checked = true;            
        }

        #region Main Code
        private void GetLists(string webUrl)
        {
            ClientContext ctx = new ClientContext(webUrl);
            ctx.Credentials = CredentialCache.DefaultCredentials;
            ctx.RequestTimeout = 30000;
            /* Configuire the handler that will pick up the authenticated cookie */
            ctx.ExecutingWebRequest += new EventHandler<WebRequestEventArgs>(ctx_ExecutingWebRequest);

            var web = ctx.Web;
            var lists = ctx.LoadQuery(web.Lists);
            /* Execute the query */
            ctx.ExecuteQuery();

            StringBuilder sb = new StringBuilder();
            sb.Append("Lists in " + webUrl + ":" + Environment.NewLine);
            sb.Append("---------------------------------------------------------------------" + Environment.NewLine);
            foreach (var list in lists)
            {
                sb.Append(list.Title + Environment.NewLine);
            }
            new frmDialog(sb.ToString(), "Success!!!").ShowDialog();
        }


        /// <summary>
        /// This is the piece of code where a typical end user developer will call the Helper dll to take care of the authentication
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ctx_ExecutingWebRequest(object sender, WebRequestEventArgs e)
        {
            try
            {
                e.WebRequestExecutor.WebRequest.CookieContainer = Helper.AttachCookie(
                                                                txtWctx.Text, 
                                                                txtWtrealm.Text, 
                                                                txtWreply.Text, 
                                                                txtStsUrl.Text, 
                                                                txtUserId.Text,
                      txtPassword.Text);
            }
            catch (Exception ex)
            {
                Helper.InValidateCookie();
                new frmDialog(ex.ToString(), "Error Setting Auth Cookie").ShowDialog();
            }
        }
        #endregion

        private void MockSharePoint2010Online()
        {
            //txtCorpUrl.Text = "login.microsoftonline.com/extSTS.srf";

            txtWebUrl.Text = "https://readify.sharepoint.com";
            txtWtrealm.Text = "urn:federation:MicrosoftOnline";
            txtWreply.Text = "https://readify.sharepoint.com/_forms/default.aspx?wa=wsignin1.0";
            txtUserId.Text = "shailen.sukul@readify.net";
            txtWctx.Text = "https://login.microsoftonline.com/login.srf";
            txtWctx.Text = string.Format(@"{0}/_layouts/Authenticate.aspx?Source=%2F", txtWebUrl.Text);
            //txtCorpUrl.Text = "sts.readifycloud.com/extSTS.srf";
            txtStsUrl.Text = "https://sts.readifycloud.com/adfs/services/trust/2005/usernamemixed";
        }
        private void MockSharePointOnline()
        {
            txtWebUrl.Text = "https://sokool.sharepoint.com";
            txtWtrealm.Text = "https://sokool.sharepoint.com";
            txtWreply.Text = "https://sokool.sharepoint.com/_forms/default.aspx?wa=wsignin1.0";
            txtUserId.Text = "shailen@sharepoint.sukul.org";
            txtWctx.Text = "https://login.microsoftonline.com/login.srf";
            txtStsUrl.Text = "https://login.microsoftonline.com/extSTS.srf";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public delegate void ButtonInvoke();
        //IAsyncResult ar;
        private void btnInvoke_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtWctx.Text.Trim().Equals(string.Empty) || txtWtrealm.Text.Trim().Equals(string.Empty) ||
                    txtWreply.Text.Trim().Equals(string.Empty) || txtStsUrl.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show(@"Enter all values for Wtcx, Wtreal, Wreply and STS Role. " + Environment.NewLine +
                    @"Hint: Fill in the Web Root url and the STS root url in the boxes below and click apply");
                    //txtSiteUrl.Focus();
                }
                else
                {
                    Invoke_ADFS();
                }
            }
            catch (Exception ex)
            {
                new frmDialog(ex.ToString(), "Error").ShowDialog();
            }

        }

        void Invoke_ADFS()
        {
            try
            {
                btnInvoke.Enabled = false;
                GetLists(txtWebUrl.Text);
            }
            catch (Exception ex)
            {
                new frmDialog(ex.ToString(), "Error").ShowDialog();
            }
            finally
            {
                btnInvoke.Enabled = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://shailen.sukul.org");
        }

        private void rdOffice365_CheckedChanged(object sender, EventArgs e)
        {
            MockSharePointOnline();
        }

        private void rdSP2010OnPremise_CheckedChanged(object sender, EventArgs e)
        {
            MockSharePoint2010Online();
        }


    }
}
