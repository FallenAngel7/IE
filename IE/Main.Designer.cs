namespace IE
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rddDelphiVoucherType = new Telerik.WinControls.UI.RadDropDownList();
            this.rddFin3VoucherType = new Telerik.WinControls.UI.RadDropDownList();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gvVoucherTypeMap = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.gvDLTypeMap = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rddDelphiDLType = new Telerik.WinControls.UI.RadDropDownList();
            this.btnDeleteDLTypeMap = new System.Windows.Forms.Button();
            this.btnAddDLTypeMap = new System.Windows.Forms.Button();
            this.rddG3DLType = new Telerik.WinControls.UI.RadDropDownList();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rddDelphiVoucherType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rddFin3VoucherType)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvVoucherTypeMap)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDLTypeMap)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rddDelphiDLType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rddG3DLType)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // documentContainer1
            // 
            this.documentContainer1.Name = "documentContainer1";
            // 
            // 
            // 
            this.documentContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentContainer1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(2, 87);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(797, 397);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(789, 370);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "تطبیق انواع سند حسابداری";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rddDelphiVoucherType);
            this.groupBox1.Controls.Add(this.rddFin3VoucherType);
            this.groupBox1.Location = new System.Drawing.Point(13, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(768, 147);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تطبیق انواع سند حسابداری";
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::IE.Properties.Resources.Delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(287, 91);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDelete.Size = new System.Drawing.Size(120, 37);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "حذف تطبیق";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::IE.Properties.Resources.Add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(409, 91);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAdd.Size = new System.Drawing.Size(120, 37);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "اضافه";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(593, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "نوع سند در سیستم راهکاران";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(593, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "نوع سند در سیستم دلفی";
            // 
            // rddDelphiVoucherType
            // 
            this.rddDelphiVoucherType.Location = new System.Drawing.Point(287, 34);
            this.rddDelphiVoucherType.Name = "rddDelphiVoucherType";
            this.rddDelphiVoucherType.Size = new System.Drawing.Size(287, 20);
            this.rddDelphiVoucherType.TabIndex = 4;
            this.rddDelphiVoucherType.Text = "radDropDownList1";
            // 
            // rddFin3VoucherType
            // 
            this.rddFin3VoucherType.Location = new System.Drawing.Point(287, 65);
            this.rddFin3VoucherType.Name = "rddFin3VoucherType";
            this.rddFin3VoucherType.Size = new System.Drawing.Size(287, 20);
            this.rddFin3VoucherType.TabIndex = 5;
            this.rddFin3VoucherType.Text = "radDropDownList1";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.gvVoucherTypeMap);
            this.panel3.Location = new System.Drawing.Point(6, 172);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(777, 192);
            this.panel3.TabIndex = 1;
            // 
            // gvVoucherTypeMap
            // 
            this.gvVoucherTypeMap.AllowUserToAddRows = false;
            this.gvVoucherTypeMap.AllowUserToDeleteRows = false;
            this.gvVoucherTypeMap.BackgroundColor = System.Drawing.Color.White;
            this.gvVoucherTypeMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvVoucherTypeMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvVoucherTypeMap.Location = new System.Drawing.Point(0, 0);
            this.gvVoucherTypeMap.MultiSelect = false;
            this.gvVoucherTypeMap.Name = "gvVoucherTypeMap";
            this.gvVoucherTypeMap.ReadOnly = true;
            this.gvVoucherTypeMap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvVoucherTypeMap.Size = new System.Drawing.Size(773, 188);
            this.gvVoucherTypeMap.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(789, 370);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "تطبیق انواع حساب تفصیل";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.gvDLTypeMap);
            this.panel4.Location = new System.Drawing.Point(13, 172);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(768, 192);
            this.panel4.TabIndex = 7;
            // 
            // gvDLTypeMap
            // 
            this.gvDLTypeMap.AllowUserToAddRows = false;
            this.gvDLTypeMap.AllowUserToDeleteRows = false;
            this.gvDLTypeMap.BackgroundColor = System.Drawing.Color.White;
            this.gvDLTypeMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDLTypeMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDLTypeMap.Location = new System.Drawing.Point(0, 0);
            this.gvDLTypeMap.MultiSelect = false;
            this.gvDLTypeMap.Name = "gvDLTypeMap";
            this.gvDLTypeMap.ReadOnly = true;
            this.gvDLTypeMap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDLTypeMap.Size = new System.Drawing.Size(768, 192);
            this.gvDLTypeMap.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.rddDelphiDLType);
            this.groupBox2.Controls.Add(this.btnDeleteDLTypeMap);
            this.groupBox2.Controls.Add(this.btnAddDLTypeMap);
            this.groupBox2.Controls.Add(this.rddG3DLType);
            this.groupBox2.Location = new System.Drawing.Point(13, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(768, 147);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "تطبیق انواع حساب تفصیلی";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(593, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "نوع تفصیل در راهکاران";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(593, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "نوع تفصیل در دلفی";
            // 
            // rddDelphiDLType
            // 
            this.rddDelphiDLType.Location = new System.Drawing.Point(287, 34);
            this.rddDelphiDLType.Name = "rddDelphiDLType";
            this.rddDelphiDLType.Size = new System.Drawing.Size(287, 20);
            this.rddDelphiDLType.TabIndex = 4;
            this.rddDelphiDLType.Text = "radDropDownList1";
            // 
            // btnDeleteDLTypeMap
            // 
            this.btnDeleteDLTypeMap.Image = global::IE.Properties.Resources.Delete;
            this.btnDeleteDLTypeMap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteDLTypeMap.Location = new System.Drawing.Point(287, 91);
            this.btnDeleteDLTypeMap.Name = "btnDeleteDLTypeMap";
            this.btnDeleteDLTypeMap.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDeleteDLTypeMap.Size = new System.Drawing.Size(140, 37);
            this.btnDeleteDLTypeMap.TabIndex = 8;
            this.btnDeleteDLTypeMap.Text = "حذف تطبیق";
            this.btnDeleteDLTypeMap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteDLTypeMap.UseVisualStyleBackColor = true;
            this.btnDeleteDLTypeMap.Click += new System.EventHandler(this.btnDeleteDLTypeMap_Click);
            // 
            // btnAddDLTypeMap
            // 
            this.btnAddDLTypeMap.Image = global::IE.Properties.Resources.Add;
            this.btnAddDLTypeMap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddDLTypeMap.Location = new System.Drawing.Point(433, 91);
            this.btnAddDLTypeMap.Name = "btnAddDLTypeMap";
            this.btnAddDLTypeMap.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAddDLTypeMap.Size = new System.Drawing.Size(141, 37);
            this.btnAddDLTypeMap.TabIndex = 9;
            this.btnAddDLTypeMap.Text = "اضافه";
            this.btnAddDLTypeMap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddDLTypeMap.UseVisualStyleBackColor = true;
            this.btnAddDLTypeMap.Click += new System.EventHandler(this.btnAddDLTypeMap_Click);
            // 
            // rddG3DLType
            // 
            this.rddG3DLType.Location = new System.Drawing.Point(287, 65);
            this.rddG3DLType.Name = "rddG3DLType";
            this.rddG3DLType.Size = new System.Drawing.Size(287, 20);
            this.rddG3DLType.TabIndex = 5;
            this.rddG3DLType.Text = "radDropDownList1";
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 23);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(789, 370);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "   تنظیمات   ";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.lblStatus);
            this.panel2.Controls.Add(this.pBar);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnExecute);
            this.panel2.Location = new System.Drawing.Point(0, 491);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(860, 51);
            this.panel2.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Image = global::IE.Properties.Resources.if_Sign_Out_1295977;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(59, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExit.Size = new System.Drawing.Size(42, 43);
            this.btnExit.TabIndex = 0;
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExecute.Image = global::IE.Properties.Resources.if_lightning_go_36157;
            this.btnExecute.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExecute.Location = new System.Drawing.Point(10, 2);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(46, 43);
            this.btnExecute.TabIndex = 0;
            this.btnExecute.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::IE.Properties.Resources._11;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 84);
            this.panel1.TabIndex = 0;
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(105, 32);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(690, 10);
            this.pBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pBar.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(108, 13);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 14);
            this.lblStatus.TabIndex = 2;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(799, 540);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "صفحه اصلی";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rddDelphiVoucherType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rddFin3VoucherType)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvVoucherTypeMap)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvDLTypeMap)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rddDelphiDLType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rddG3DLType)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadDropDownList rddDelphiVoucherType;
        private Telerik.WinControls.UI.RadDropDownList rddFin3VoucherType;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView gvVoucherTypeMap;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDeleteDLTypeMap;
        private System.Windows.Forms.Button btnAddDLTypeMap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Telerik.WinControls.UI.RadDropDownList rddDelphiDLType;
        private Telerik.WinControls.UI.RadDropDownList rddG3DLType;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView gvDLTypeMap;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar pBar;
    }
}

