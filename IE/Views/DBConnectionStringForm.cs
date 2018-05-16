using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IE.Views
{
    public partial class DBConnectionStringForm : Form
    {
        public string dbName { get; set; }
        public SqlConnectionStringBuilder ConnectionStringBuilder { get; set; }

        public DBConnectionStringForm(string dbName)
        {
            this.dbName = dbName;
            InitializeComponent();
        }

        private void DBConnectionStringForm_Load(object sender, EventArgs e)
        {
            FillControls();
        }

        private void FillControls()
        {
            var connectionString = "";
            connectionString = ConfigurationManager.ConnectionStrings[dbName + "ConnectionString"].ConnectionString;
            var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

            if (!connectionStringBuilder.IntegratedSecurity)
            {
                txtUserID.Text = connectionStringBuilder.UserID;
                txtPassword.Text = connectionStringBuilder.Password;
            }
            txtDatabase.Text = connectionStringBuilder.InitialCatalog;
            txtDataSource.Text = connectionStringBuilder.DataSource;

            chkUserID.Checked = !connectionStringBuilder.IntegratedSecurity;


        }

        private void chkUserID_CheckedChanged(object sender, EventArgs e)
        {
            txtUserID.Enabled = txtPassword.Enabled = chkUserID.Enabled;
        }

        private void ChangeControlsStatus(bool status)
        {
            pbarConnectionCheck.Visible = status;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            var connectionString = "";

            Helpers.ConfigurationTools.UpdateConnectionString(dbName + "ConnectionString", txtDataSource.Text, txtDatabase.Text, !chkUserID.Checked, txtUserID.Text, txtPassword.Text);
            RefreshConnectionString(dbName);
            connectionString = ConfigurationManager.ConnectionStrings[dbName + "ConnectionString"].ConnectionString;

            ChangeControlsStatus(true);
            var userIDchecked = chkUserID.Checked;


            connectionString = ConfigurationManager.ConnectionStrings[dbName + "ConnectionString"].ConnectionString;
            var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
            connectionStringBuilder.InitialCatalog = "master";

            var connected = await CheckDbConnection(connectionStringBuilder);
            chkUserID.Checked = userIDchecked;

            ChangeControlsStatus(false);

            if (!connected)
            {
                MessageBox.Show("تنظیمات ارتباطی اشتباه است، لطفا مقادیر را بررسی نمایید", "پیام سیستم");
            }
            else
            {
                MessageBox.Show("اتصال برقرار شد", "پیام سیستم");
                DialogResult = DialogResult.OK;
            }

        }

        private void RefreshConnectionString(string db)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[dbName + "ConnectionString"].ConnectionString;
            ConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
            dbName = ConnectionStringBuilder.InitialCatalog;
            ConnectionStringBuilder.InitialCatalog = "master";
        }

        private async Task<bool> CheckDbConnection(string db)
        {
            
                var connectionString = ConfigurationManager.ConnectionStrings[dbName+"ConnectionString"].ConnectionString;
                var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
                connectionStringBuilder.InitialCatalog = "master";


                if (!await CheckDbConnection(connectionStringBuilder))
                {
                    var DBSettingForm = new DBConnectionStringForm(dbName);

                    var result = DBSettingForm.ShowDialog();
                    if (result != DialogResult.OK)
                        return false;
                }
            
            return true;
        }

        public async Task<bool> CheckDbConnection(SqlConnectionStringBuilder con)
        {
            try
            {
                using (var connection = new SqlConnection(con.ConnectionString))
                {
                    await connection.OpenAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
