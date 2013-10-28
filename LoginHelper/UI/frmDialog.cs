using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ADFS_Test
{
    public partial class frmDialog : Form
    {
        public frmDialog(string message, string title) : this()
        {
            this.Text = title;
            txtMessage.Text = message;
        }

        public frmDialog()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
