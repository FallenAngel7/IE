using DelphiEntities;
using IE.Entities;
using RahkaranEntities;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace IE
{
    public partial class Main : Form
    {
        IEContext ie;
        G3Context g3;
        DelphiEntities.LinQ.DelphiDataContext db;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            

            var iEConnectionString = ConfigurationManager.ConnectionStrings["IEConnectionString"].ConnectionString;
            ie = new IEContext(iEConnectionString);
            Database.SetInitializer<IEContext>(null);
            db = new DelphiEntities.LinQ.DelphiDataContext(ConfigurationManager.ConnectionStrings["DelphiConnectionString"].ConnectionString);
            g3 = new G3Context(ConfigurationManager.ConnectionStrings["Fin3ConnectionString"].ConnectionString);
            LoadDropDowns();
            reloadGridViews();
            this.FormClosed += Main_FormClosed;
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
            if(!await CheckSLs())
            {
                MessageBox.Show("درختواره حسابها مغایرت دارد / حساب معین", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(!await CheckDLs())
            }
        }

        private async Task<bool> CheckDLs()
        {
            lblStatus.Text = "در حال بررسی حسابهای تفصیلی";
            var dLTypes = ie.DLTypeMaps.ToList();                      
            foreach(var item in dLTypes)
            {
                var g3DlTypes = g3.DLTypes.Where(w => w.DLTypeID == item.Fin3DLTypeRef).ToList();
            }
            return true;
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
    }
}
