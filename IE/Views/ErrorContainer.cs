using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IE.Views
{
    public partial class ErrorContainer : Form
    {
        string message;
        public ErrorContainer(string message)
        {
            this.message = message;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ErrorContainer_Load(object sender, EventArgs e)
        {
            txtMessage.Text = message;
        }
    }
}
