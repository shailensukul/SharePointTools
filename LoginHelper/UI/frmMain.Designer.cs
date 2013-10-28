namespace ADFS_Test
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWebUrl = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.pnlDetails = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStsUrl = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtWreply = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtWtrealm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWctx = new System.Windows.Forms.TextBox();
            this.btnInvoke = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdSP2010OnPremise = new System.Windows.Forms.RadioButton();
            this.rdOffice365 = new System.Windows.Forms.RadioButton();
            this.tpUserInfo = new System.Windows.Forms.ToolTip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(654, 376);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 34);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtWebUrl);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUserId);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(767, 130);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "Url:";
            this.tpUserInfo.SetToolTip(this.label1, "This is the target url for your SharePoint site. It can be a subsite url as well." +
        "");
            // 
            // txtWebUrl
            // 
            this.txtWebUrl.Location = new System.Drawing.Point(93, 92);
            this.txtWebUrl.Name = "txtWebUrl";
            this.txtWebUrl.Size = new System.Drawing.Size(487, 27);
            this.txtWebUrl.TabIndex = 9;
            this.tpUserInfo.SetToolTip(this.txtWebUrl, "This is the target url for your SharePoint site. It can be a subsite url as well." +
        "");
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(543, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 19);
            this.label13.TabIndex = 8;
            this.label13.Text = "Author:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(597, 21);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(163, 19);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://shailensukul.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(93, 54);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(226, 27);
            this.txtPassword.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "User Id:";
            this.tpUserInfo.SetToolTip(this.label2, "The user id used to log into your SharePoint site. It must have permissions to be" +
        " able query the listnames of your site for this example.");
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(93, 21);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(226, 27);
            this.txtUserId.TabIndex = 1;
            this.tpUserInfo.SetToolTip(this.txtUserId, "The user id used to log into your SharePoint site. It must have permissions to be" +
        " able query the listnames of your site for this example.");
            // 
            // pnlDetails
            // 
            this.pnlDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetails.Controls.Add(this.label8);
            this.pnlDetails.Controls.Add(this.txtStsUrl);
            this.pnlDetails.Controls.Add(this.label7);
            this.pnlDetails.Controls.Add(this.txtWreply);
            this.pnlDetails.Controls.Add(this.label6);
            this.pnlDetails.Controls.Add(this.txtWtrealm);
            this.pnlDetails.Controls.Add(this.label5);
            this.pnlDetails.Controls.Add(this.txtWctx);
            this.pnlDetails.Location = new System.Drawing.Point(6, 184);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(761, 164);
            this.pnlDetails.TabIndex = 6;
            this.pnlDetails.TabStop = false;
            this.pnlDetails.Text = "ADFS Details";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 19);
            this.label8.TabIndex = 9;
            this.label8.Text = "STS Role:";
            // 
            // txtStsUrl
            // 
            this.txtStsUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStsUrl.Location = new System.Drawing.Point(86, 122);
            this.txtStsUrl.Name = "txtStsUrl";
            this.txtStsUrl.Size = new System.Drawing.Size(668, 27);
            this.txtStsUrl.TabIndex = 3;
            this.tpUserInfo.SetToolTip(this.txtStsUrl, "This is the url to the STS provider which performs that authentication");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 19);
            this.label7.TabIndex = 7;
            this.label7.Text = "Wreply:";
            // 
            // txtWreply
            // 
            this.txtWreply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWreply.Location = new System.Drawing.Point(87, 89);
            this.txtWreply.Name = "txtWreply";
            this.txtWreply.Size = new System.Drawing.Size(668, 27);
            this.txtWreply.TabIndex = 2;
            this.tpUserInfo.SetToolTip(this.txtWreply, "This value MUST be a URL at the relying party to which responses MUST be directed" +
        "");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Wtrealm:";
            // 
            // txtWtrealm
            // 
            this.txtWtrealm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWtrealm.Location = new System.Drawing.Point(87, 56);
            this.txtWtrealm.Name = "txtWtrealm";
            this.txtWtrealm.Size = new System.Drawing.Size(668, 27);
            this.txtWtrealm.TabIndex = 1;
            this.tpUserInfo.SetToolTip(this.txtWtrealm, "this value MUST be a URI that the requestor IP/STS and the relying party have agr" +
        "eed to use to identify the security realm of the relying party in messages to th" +
        "e requestor IP/STS");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Wctx:";
            // 
            // txtWctx
            // 
            this.txtWctx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWctx.Location = new System.Drawing.Point(87, 23);
            this.txtWctx.Name = "txtWctx";
            this.txtWctx.Size = new System.Drawing.Size(668, 27);
            this.txtWctx.TabIndex = 0;
            this.tpUserInfo.SetToolTip(this.txtWctx, "This value is an opaque context that MAY be passed in the request by the relying " +
        "party");
            // 
            // btnInvoke
            // 
            this.btnInvoke.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvoke.Location = new System.Drawing.Point(532, 376);
            this.btnInvoke.Margin = new System.Windows.Forms.Padding(4);
            this.btnInvoke.Name = "btnInvoke";
            this.btnInvoke.Size = new System.Drawing.Size(100, 34);
            this.btnInvoke.TabIndex = 3;
            this.btnInvoke.Text = "&Invoke";
            this.btnInvoke.UseVisualStyleBackColor = true;
            this.btnInvoke.Click += new System.EventHandler(this.btnInvoke_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdSP2010OnPremise);
            this.groupBox2.Controls.Add(this.rdOffice365);
            this.groupBox2.Location = new System.Drawing.Point(12, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(748, 42);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sample";
            // 
            // rdSP2010OnPremise
            // 
            this.rdSP2010OnPremise.AutoSize = true;
            this.rdSP2010OnPremise.Location = new System.Drawing.Point(102, 19);
            this.rdSP2010OnPremise.Name = "rdSP2010OnPremise";
            this.rdSP2010OnPremise.Size = new System.Drawing.Size(211, 23);
            this.rdSP2010OnPremise.TabIndex = 1;
            this.rdSP2010OnPremise.TabStop = true;
            this.rdSP2010OnPremise.Text = "SharePoint 2010 On Premise";
            this.rdSP2010OnPremise.UseVisualStyleBackColor = true;
            this.rdSP2010OnPremise.CheckedChanged += new System.EventHandler(this.rdSP2010OnPremise_CheckedChanged);
            // 
            // rdOffice365
            // 
            this.rdOffice365.AutoSize = true;
            this.rdOffice365.Location = new System.Drawing.Point(6, 19);
            this.rdOffice365.Name = "rdOffice365";
            this.rdOffice365.Size = new System.Drawing.Size(90, 23);
            this.rdOffice365.TabIndex = 0;
            this.rdOffice365.TabStop = true;
            this.rdOffice365.Text = "Office365";
            this.rdOffice365.UseVisualStyleBackColor = true;
            this.rdOffice365.CheckedChanged += new System.EventHandler(this.rdOffice365_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 352);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 19);
            this.label4.TabIndex = 16;
            this.label4.Text = "For more information, refer to ";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(209, 352);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(373, 19);
            this.linkLabel2.TabIndex = 17;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "http://msdn.microsoft.com/en-us/library/cc236491.aspx";
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnInvoke;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(767, 423);
            this.ControlBox = false;
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnInvoke);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "ADFS Test - By Shailen Sukul http://shailen.sukul.org";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.GroupBox pnlDetails;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtWreply;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtWtrealm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtWctx;
        private System.Windows.Forms.Button btnInvoke;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtStsUrl;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWebUrl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdOffice365;
        private System.Windows.Forms.RadioButton rdSP2010OnPremise;
        private System.Windows.Forms.ToolTip tpUserInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}

