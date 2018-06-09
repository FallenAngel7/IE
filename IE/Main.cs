using IE.Entities;
using RahkaranEntities;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Net;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using VoucherWebService;

namespace IE
{
    public partial class Main : Form
    {
        IEContext ie;
        G3Context g3;
        DelphiEntities.LinQ.DelphiDataContext db;

        string g3Data;
        string ieData;
        string dbData;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            pBar.Visible = false;
            ConfigureDataContexts();
            LoadDropDowns();
            reloadGridViews();
            ConfigureDataSources();
            InsertDLRefToSgdb();
            ReloadConfigurations();
            this.FormClosed += Main_FormClosed;
        }

        private void ReloadConfigurations()
        {
            if (ie.Configurations.Where(w => w.Name == "sgPath").Count() == 0)
            {
                var q = new IE.Entities.Configuration();
                q.Description = "sgPath";
                q.Name = "sgPath";
                q.Value = txtSgPath.Text;
                ie.Configurations.Add(q);
                ie.SaveChanges();
            }
            else
            {
                var q = ie.Configurations.Where(w => w.Name == "sgPath").Single();
                q.Value = txtSgPath.Text;
                ie.SaveChanges();
            }

            if (ie.Configurations.Where(w => w.Name == "UserName").Count() == 0)
            {
                var q = new IE.Entities.Configuration();
                q.Description = "UserName";
                q.Name = "UserName";
                q.Value = txtUserName.Text.ToString();
                ie.Configurations.Add(q);
                ie.SaveChanges();
            }
            else
            {
                var q = ie.Configurations.Where(w => w.Name == "UserName").Single();
                q.Value = txtUserName.Text.ToString();
                ie.SaveChanges();
            }

            if (ie.Configurations.Where(w => w.Name == "Branch").Count() == 0)
            {
                var q = new IE.Entities.Configuration();
                q.Description = "Branch";
                q.Name = "Branch";
                q.Value = rddBranches.SelectedValue.ToString();
                ie.Configurations.Add(q);
                ie.SaveChanges();
            }
            else
            {
                //var q = ie.Configurations.Where(w => w.Name == "Branch").Single();
                //q.Value = rddBranches.SelectedValue.ToString();
                //ie.SaveChanges();
            }


            if (ie.Configurations.Where(w => w.Name == "Ledger").Count() == 0)
            {
                var q = new IE.Entities.Configuration();
                q.Description = "Ledger";
                q.Name = "Ledger";
                q.Value = rddLedgers.SelectedValue.ToString();
                ie.Configurations.Add(q);
                ie.SaveChanges();
            }
            else
            {
                //var q = ie.Configurations.Where(w => w.Name == "Ledger").Single();
                //q.Value = rddLedgers.SelectedValue.ToString();
                //ie.SaveChanges();
            }

            if (ie.Configurations.Where(w => w.Name == "Password").Count() == 0)
            {
                var q = new IE.Entities.Configuration();
                q.Description = "Password";
                q.Name = "Password";
                q.Value = txtPassword.Text.ToString();
                ie.Configurations.Add(q);
                ie.SaveChanges();
            }
            else
            {
                var q = ie.Configurations.Where(w => w.Name == "Password").Single();
                q.Value = q.Value = txtPassword.Text.ToString();
                ie.SaveChanges();
            }
        }

        private void InsertDLRefToSgdb()
        {
            SqlConnection dbSql = new SqlConnection(ConfigurationManager.ConnectionStrings["DelphiConnectionString"].ConnectionString);
            dbSql.Open();
            var cmd = new SqlCommand("IF OBJECT_ID('dbo.DLStore', 'U') IS NOT NULL DROP TABLE dbo.DLStore; ", dbSql);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("select * into dbo.DLStore from " + g3Data + ".Fin3.DL ", dbSql);
            cmd.ExecuteNonQuery();
            dbSql.Close();

        }

        private void ConfigureDataContexts()
        {
            var iEConnectionString = ConfigurationManager.ConnectionStrings["IEConnectionString"].ConnectionString;
            ie = new IEContext(iEConnectionString);
            Database.SetInitializer<IEContext>(null);
            db = new DelphiEntities.LinQ.DelphiDataContext(ConfigurationManager.ConnectionStrings["DelphiConnectionString"].ConnectionString);
            g3 = new G3Context(ConfigurationManager.ConnectionStrings["Fin3ConnectionString"].ConnectionString);

        }

        private void ConfigureDataSources()
        {
            SqlConnectionStringBuilder g3DataSqlConBuilder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["Fin3ConnectionString"].ConnectionString);
            g3Data = "[" + g3DataSqlConBuilder.DataSource + "].[" + g3DataSqlConBuilder.InitialCatalog + "]";

            SqlConnectionStringBuilder ieDataSqlConBuilder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["IEConnectionString"].ConnectionString);
            ieData = "[" + ieDataSqlConBuilder.DataSource + "].[" + ieDataSqlConBuilder.InitialCatalog + "]";

            SqlConnectionStringBuilder dbDataSqlConBuilder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["DelphiConnectionString"].ConnectionString);
            dbData = "[" + dbDataSqlConBuilder.DataSource + "].[" + dbDataSqlConBuilder.InitialCatalog + "]";
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LoadDropDowns()
        {
            #region Rahkaran VoucherTypes                  
            Database.SetInitializer<G3Context>(null);
            rddFin3VoucherType.DataSource = g3.VoucherTypes.ToList();
            rddFin3VoucherType.DisplayMember = "Title";
            rddFin3VoucherType.ValueMember = "VoucherTypeID";
            rddFin3VoucherType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            rddFin3VoucherType.AutoCompleteDataSource = g3.VoucherTypes.ToList<VoucherType>();
            rddFin3VoucherType.AutoCompleteMode = AutoCompleteMode.Append;
            rddFin3VoucherType.Focus();
            #endregion

            #region Delphi VoucherTypes                 
            rddDelphiVoucherType.DataSource = db.AccVchTypes.ToList();
            rddDelphiVoucherType.DisplayMember = "Title";
            rddDelphiVoucherType.ValueMember = "Code";
            rddDelphiVoucherType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            rddDelphiVoucherType.AutoCompleteDataSource = db.AccVchTypes.ToList();
            rddDelphiVoucherType.AutoCompleteMode = AutoCompleteMode.Append;
            rddFin3VoucherType.Focus();
            #endregion            

            #region Delphi DLTypes            
            rddDelphiDLType.DataSource = db.DLViews.ToList();
            rddDelphiDLType.DisplayMember = "DLName";
            rddDelphiDLType.ValueMember = "DLType";
            rddDelphiDLType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            rddDelphiDLType.AutoCompleteDataSource = db.DLViews.ToList();
            rddDelphiDLType.AutoCompleteMode = AutoCompleteMode.Append;
            rddDelphiDLType.Focus();
            #endregion

            #region Rahkaran DLTypes 
            Database.SetInitializer<G3Context>(null);
            rddG3DLType.DataSource = g3.DLTypes.ToList();
            rddG3DLType.DisplayMember = "Title";
            rddG3DLType.ValueMember = "DLTypeID";
            rddG3DLType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            rddG3DLType.AutoCompleteDataSource = g3.DLTypes.ToList<DLType>();
            rddG3DLType.AutoCompleteMode = AutoCompleteMode.Append;
            #endregion

            #region Rahkaran FiscalYear
            if (ie.Configurations.Where(w => w.Name == "FiscalYear").Count() == 0)
            {
                Database.SetInitializer<G3Context>(null);
                rddFiscalYear.DataSource = g3.FiscalYears.ToList();
                rddFiscalYear.DisplayMember = "Title";
                rddFiscalYear.ValueMember = "FiscalYearID";
                rddFiscalYear.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
                rddFiscalYear.AutoCompleteDataSource = g3.FiscalYears.ToList<FiscalYear>();
                rddFiscalYear.AutoCompleteMode = AutoCompleteMode.Append;
            }
            else
            {
                var q = ie.Configurations.Where(w => w.Name == "FiscalYear").Single();
                rddFiscalYear.DisplayMember = q.Value;
                rddFiscalYear.Text = q.Value;
                rddFiscalYear.Enabled = false;
                //gb1.Enabled = false;
                //gb2.Enabled = false;
                //gb3.Enabled = false;

            }
            #endregion


            #region Rahkaran Branch 
            if (ie.Configurations.Where(w => w.Name == "Branch").Count() == 0)
            {
                Database.SetInitializer<G3Context>(null);
                rddBranches.DataSource = g3.Branches.ToList();
                rddBranches.DisplayMember = "Title";
                rddBranches.ValueMember = "BranchID";
                rddBranches.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
                rddBranches.AutoCompleteDataSource = g3.Branches.ToList<Branch>();
                rddBranches.AutoCompleteMode = AutoCompleteMode.Append;
            }
            else
            {
                var q = ie.Configurations.Where(w => w.Name == "Branch").Single();
                rddBranches.DisplayMember = q.Value;                
                gb1.Enabled = false;
            }
            #endregion

            #region Rahkaran Ledger 
            if (ie.Configurations.Where(w => w.Name == "Ledger").Count() == 0)
            {
                Database.SetInitializer<G3Context>(null);
                rddLedgers.DataSource = g3.Ledgers.ToList();
                rddLedgers.DisplayMember = "Title";
                rddLedgers.ValueMember = "LedgerID";
                rddLedgers.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
                rddLedgers.AutoCompleteDataSource = g3.Ledgers.ToList<Ledger>();
                rddLedgers.AutoCompleteMode = AutoCompleteMode.Append;
            }
            else
            {
                var q = ie.Configurations.Where(w => w.Name == "Ledger").Single();
                rddLedgers.DisplayMember = q.Value;                
                //gb1.Enabled = false;
            }
            #endregion



        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var voucherTypeMap = new VoucherTypeMap()
                {
                    CreationDate = DateTime.Now,
                    DelphiTitle = rddDelphiVoucherType.Text,
                    DelphiVoucherTypeRef = int.Parse(rddDelphiVoucherType.SelectedValue.ToString()),
                    Fin3Title = rddFin3VoucherType.Text,
                    Fin3VoucherTypeRef = int.Parse(rddFin3VoucherType.SelectedValue.ToString())
                };

                if (ie.VoucherTypeMaps.Count() != 0)
                {
                    if (ie.VoucherTypeMaps.Where(c => c.DelphiVoucherTypeRef == voucherTypeMap.DelphiVoucherTypeRef
                    && c.Fin3VoucherTypeRef == voucherTypeMap.Fin3VoucherTypeRef).ToList().Count == 0)
                    {
                        ie.VoucherTypeMaps.Add(voucherTypeMap);
                        ie.SaveChanges();
                        reloadGridViews();
                    }
                    else
                    {
                        MessageBox.Show("تکراری است", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    ie.VoucherTypeMaps.Add(voucherTypeMap);
                    ie.SaveChanges();
                    reloadGridViews();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("خطایی رخ داد ", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public void reloadGridViews()
        {

            gvVoucherTypeMap.DataSource = ie.VoucherTypeMaps.ToList();
            gvVoucherTypeMap.Refresh();

            gvDLTypeMap.DataSource = ie.DLTypeMaps.ToList();
            gvDLTypeMap.Refresh();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvVoucherTypeMap.SelectedRows.Count == 0)
                {
                    MessageBox.Show("لطفا رکورد مورد نظر را انتخاب کنید‍", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                }
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی رخ داد!", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddDLTypeMap_Click(object sender, EventArgs e)
        {
            try
            {
                var dLTypeMap = new DLTypeMap()
                {
                    DelphiDLTypeRef = int.Parse(rddDelphiDLType.SelectedValue.ToString()),
                    Fin3DLTypeRef = int.Parse(rddG3DLType.SelectedValue.ToString())
                };

                if (ie.DLTypeMaps.Count() != 0)
                {
                    if (ie.DLTypeMaps.Where(c => c.DelphiDLTypeRef == dLTypeMap.DelphiDLTypeRef
                    && c.Fin3DLTypeRef == dLTypeMap.Fin3DLTypeRef).ToList().Count == 0)
                    {
                        ie.DLTypeMaps.Add(dLTypeMap);
                        ie.SaveChanges();
                        reloadGridViews();
                    }
                    else
                    {
                        MessageBox.Show("تکراری است", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    ie.DLTypeMaps.Add(dLTypeMap);
                    ie.SaveChanges();
                    reloadGridViews();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("خطایی رخ داد ", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDeleteDLTypeMap_Click(object sender, EventArgs e)
        {

        }

        private async void btnExecute_Click(object sender, EventArgs e)
        {
            pBar.Visible = true;
            if (!await CheckSLs())
            {
                MessageBox.Show("درختواره حسابها مغایرت دارد / حساب معین", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!await CheckDLs())
                {
                    MessageBox.Show("در یکسان سازی حسابهای تفصیلی خطایی رخ داد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!await CheckVoucehrs())
                    {
                        MessageBox.Show("در یکسان سازی اسناد حسابداری خطایی رخ داد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async Task<bool> CheckVoucehrs()
        {
            try
            {
                lblStatus.Text = "در حال بررسی اسناد حسابداری";
                Cursor = Cursors.WaitCursor;
                if (ie.Configurations.Where(w => w.Name == "EstablishDate").Count() != 0)
                {
                    var q = ie.Configurations.Where(w => w.Name == "EstablishDate").Single();
                    DateTime estDate = ToMiladiDateString(q.Value);
                    var vouchers = db.AccVchHdrs.Where(w => w.VchDate > estDate).ToList();
                    List<DelphiEntities.LinQ.AccVchHdr> Final = new List<DelphiEntities.LinQ.AccVchHdr>();

                    foreach (var v in vouchers)
                    {
                        if (ie.VoucherTypeMaps.Where(w => w.DelphiVoucherTypeRef.ToString() == v.Ctgry.Trim()).Count() != 0)
                        {
                            if (ie.VoucherMaps.Where(w => w.DelphiVoucherRef == v.HdrVchID).Count() == 0)
                            {
                                Final.Add(v);
                            }
                        }
                    }

                    return ConvertToRahkaran(Final);

                }
                else
                {
                    MessageBox.Show("لطفا تاریخ استقرار ابزار را در بخش تنظیمات ثبت نمایید ", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor = Cursors.Default;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool ConvertToRahkaran(List<DelphiEntities.LinQ.AccVchHdr> final)
        {
            InsertVoucher vw = new InsertVoucher(txtSgPath.Text, g3, db, ie);
            vw.UserName = txtUserName.Text;
            vw.Password = txtPassword.Text;
            Cursor = Cursors.WaitCursor;
            var result = vw.InsertVoucherToSg3(final);
            Cursor = Cursors.Default;
            return result;
        }

        private async Task<bool> CheckDLs()
        {
            try
            {
                lblStatus.Text = "در حال بررسی حسابهای تفصیلی";
                Cursor = Cursors.WaitCursor;
                var Rqs = db.ExecuteQuery<DelphiEntities.LinQ.DLStore>
                 (
                   @"select * from dbo.DLStore
                   where Code collate SQL_Latin1_General_CP1256_CI_AS 
                   not in ( select RTRIM(Ltrim(Accnum)) from acc.DL )"
                 ).ToList();
                Cursor = Cursors.Default;
                foreach (var item in Rqs)
                {
                    var mapID = ie.DLTypeMaps.Where(w => w.Fin3DLTypeRef == item.DLTypeRef).Single().DelphiDLTypeRef;
                    var newDelphiDLRef = new DelphiEntities.LinQ.DL();
                    newDelphiDLRef.AccNum = item.Code;
                    newDelphiDLRef.Title = item.Title;
                    newDelphiDLRef.DLType = mapID;
                    db.DLs.InsertOnSubmit(newDelphiDLRef);
                    db.SubmitChanges();
                    InsertLogHistory(newDelphiDLRef.AccNum, 1);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void InsertLogHistory(string entity, int v)
        {
            var newLog = new IE.Entities.LogHistory();
            newLog.Date = DateTime.Now;
            if (v == 1)
            {
                newLog.Description = "انتقال تفصیلی از راهکاران به دلفی";
                newLog.EntiryRef = entity;
                newLog.EntityType = "انتقال تفصیلی";
            }
            else
            {
                newLog.Description = "انتقال سند از دلفی به دلفی";
                newLog.EntiryRef = entity;
                newLog.EntityType = "انتقال سند تسهیم هزینه";
            }
            ie.LogHistories.Add(newLog);
            ie.SaveChanges();
        }

        private async Task<bool> CheckSLs()
        {
            lblStatus.Text = "در حال بررسی درخت حسابها/ حساب معین";
            var q = db.SLs.Select(x => x.AccNum.Trim()).ToArray();
            var others = g3.SLs.Where(y => !q.Contains(y.Code)).ToList();
            if (others.Count > 0)
                return false;
            else
                return true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var establishDate = txtEstablishDate.Value.ToShortDateString();
                string establishDateMiladi = null;
                DateTime d = ToMiladiDateString(establishDate);
                establishDateMiladi = d.ToString();
                if (ie.Configurations.Where(w => w.Name == "EstablishDate").Count() == 0)
                {
                    var q = new IE.Entities.Configuration();
                    q.Description = "EstablishDate";
                    q.Name = "EstablishDate";
                    q.Value = establishDateMiladi.ToString();
                    ie.Configurations.Add(q);
                    ie.SaveChanges();
                }
                else
                {
                    var q = ie.Configurations.Where(w => w.Name == "EstablishDate").Single();
                    q.Value = establishDateMiladi.ToString();
                    ie.SaveChanges();
                }

                if (ie.Configurations.Where(w => w.Name == "FiscalYear").Count() == 0)
                {
                    var q = new IE.Entities.Configuration();
                    q.Description = "FiscalYear";
                    q.Name = "FiscalYear";
                    q.Value = rddFiscalYear.SelectedValue.ToString();
                    ie.Configurations.Add(q);
                    ie.SaveChanges();
                }


                MessageBox.Show("با موفقیت به روز رسانی شد");
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطایی رخ داد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private DateTime ToMiladiDateString(string DateString)
        {
            string dat = DateString;
            string sal = dat.Substring(0, 4);
            string mah = dat.Substring(5, 2);
            string roz = dat.Substring(8, 2);
            PersianCalendar pc = new PersianCalendar();
            return pc.ToDateTime(Convert.ToInt32(sal), Convert.ToInt32(mah), Convert.ToInt32(roz), 0, 0, 0, 0);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            gb1.Enabled = true;
            gb2.Enabled = true;
            gb3.Enabled = true;
            rddFiscalYear.Enabled = true;
            rddBranches.Enabled = true;

        }
    }
}
