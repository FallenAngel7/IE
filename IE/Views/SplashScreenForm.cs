using FrameWork;
using IE.Entities;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.SqlClient;

namespace IE.Views
{
    public partial class SplashScreenForm : Form
    {
        public SplashScreenForm()
        {
            InitializeComponent();
        }

        private async void SplashScreenForm_Load(object sender, EventArgs e)
        {
            #region IE
            if (!await CheckDbConnection("IE"))
                DialogResult = DialogResult.Cancel;


            if (await CheckDatabase("IE"))
            {
                DialogResult = DialogResult.OK;
                //return;
            }
            else
                DialogResult = DialogResult.Cancel;
            #endregion 

            #region Fin3
            if (!await CheckDbConnection("Fin3"))
                DialogResult = DialogResult.Cancel;


            if (await CheckDatabase("Fin3"))
            {
                DialogResult = DialogResult.OK;
                return;
            }
            else
                DialogResult = DialogResult.Cancel;
            #endregion
        }

        private async Task<bool> CheckDatabase(string dbName)
        {
            lblStatus.Text = "در حال بررسی وجود دیتابیس!";
            var connectionString = "";
            connectionString = ConfigurationManager.ConnectionStrings[dbName + "ConnectionString"].ConnectionString;
            var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

            if (!await CheckDataBaseExists(connectionStringBuilder, dbName))
            {
                lblStatus.Text = "در حال ایجاد دیتابیس!";
                IEContext db = new IEContext(connectionString);
                if (dbName == "IE")
                {
                    if (!db.Database.CreateIfNotExists())
                        return false;
                    InsertAdminUser(db);
                }
                else return false;
            }
            return true;
        }

        private void InsertAdminUser(IEContext db)
        {
            db.Users.Add(new User()
            {
                UserID = 1,
                UserName = "Admin",
                Password = "123",
                CreateDate = DateTime.Now
            });
            db.SaveChanges();
        }

        private async Task<bool> CheckDbConnection(string dbName)
        {
            if (dbName == "IE")
                lblStatus.Text = "در حال بررسی ارتباط با سرور راهکاران...";
            else
                lblStatus.Text = "در حال بررسی ارتباط با سرور دلفی...";
            var connectionString = "";
            connectionString = ConfigurationManager.ConnectionStrings[dbName + "ConnectionString"].ConnectionString;
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

        public async Task<bool> CheckDataBaseExists(SqlConnectionStringBuilder con, string tempDbName)
        {
            con.InitialCatalog = "master";
            try
            {
                using (var connection = new SqlConnection(con.ConnectionString))
                {
                    await connection.OpenAsync();
                    var command = new SqlCommand("select count(*) from sys.databases where [name] = @dbname", connection);
                    command.Parameters.Add(new SqlParameter("@dbname", tempDbName));
                    var result = (int)await command.ExecuteScalarAsync();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
