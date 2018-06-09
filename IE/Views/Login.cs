using IE.Entities;
using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using IE.Entities.HashTools;

namespace IE.Views
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var iEConnectionString = ConfigurationManager.ConnectionStrings["IEConnectionString"].ConnectionString;
            IEContext ie = new IEContext(iEConnectionString);
            var q = ie.Users.Where(w => w.UserName == txtUserName.Text).Count();
            if (q == 0)
            {
                MessageBox.Show("نام کاربری اشتباه است");
            }
            else
            {
                var user = ie.Users.Where(w => w.UserName == txtUserName.Text).Single();
                var current = new HashGenerator(txtPassword.Text);
                if (current.Hash() == user.Password)
                {

                    Main m = new IE.Main();
                    this.Hide();
                    m.ShowDialog();

                }
                else
                {
                    MessageBox.Show("رمز عبور اشتباه است");
                }
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { btnLogin_Click(sender, e); }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            var iEConnectionString = ConfigurationManager.ConnectionStrings["IEConnectionString"].ConnectionString;
            IEContext ie = new IEContext(iEConnectionString);
            var newHash = new HashGenerator("123");
            if (ie.Users.Count() == 0)
            {
                var newUser = new User();
                newUser.CreateDate = DateTime.Now;
                newUser.Password = newHash.Hash();
                newUser.UserName = "admin";
                ie.Users.Add(newUser);
                ie.SaveChanges();
            }
        }
    }
}
