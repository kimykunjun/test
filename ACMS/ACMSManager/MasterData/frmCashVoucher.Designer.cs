using System.Windows.Forms;
using DevExpress.XtraEditors;
namespace ACMS.ACMSManager.MasterData
{
    partial class frmCashVoucher
    {
        private System.Windows.Forms.ImageList imageList1;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        internal GroupControl groupCashVoucher;
        private System.ComponentModel.IContainer components;
        internal SimpleButton btnCashVoucherImport;
        private PictureBox pbSelect;
        private TextEdit txtFilePath;
        private Label label9;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox cmbStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_BranchCode;
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
            this.pbSelect = new System.Windows.Forms.PictureBox();
            this.txtFilePath = new DevExpress.XtraEditors.TextEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCashVoucherImport = new DevExpress.XtraEditors.SimpleButton();
            this.groupCashVoucher = new DevExpress.XtraEditors.GroupControl();
            this.cmbStatus = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.lk_BranchCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCashVoucher));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.grpMDCashVoucherTop = new DevExpress.XtraEditors.GroupControl();
            this.Searchpanel = new System.Windows.Forms.Panel();
            this.btn_Search = new DevExpress.XtraEditors.SimpleButton();
            this.txtSearch = new DevExpress.XtraEditors.TextEdit();
            this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Del = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlMd_CashVoucher = new DevExpress.XtraGrid.GridControl();
            this.gridViewMdCashVoucher = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnSV1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSV2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSV3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSV4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSV5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSV6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSV7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSV8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSV9 = new DevExpress.XtraGrid.Columns.GridColumn();            
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnSV10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSV11 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grpMDCashVoucherTop)).BeginInit();
            this.grpMDCashVoucherTop.SuspendLayout();
            this.Searchpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_CashVoucher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMdCashVoucher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_BranchCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupCashVoucher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilePath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, ""); 
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            // 
            // grpMDCashVoucherTop
            // 
            this.grpMDCashVoucherTop.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.grpMDCashVoucherTop.Appearance.Options.UseBackColor = true;
            this.grpMDCashVoucherTop.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMDCashVoucherTop.AppearanceCaption.Options.UseFont = true;
            this.grpMDCashVoucherTop.Controls.Add(this.Searchpanel);            
            this.grpMDCashVoucherTop.Controls.Add(this.gridControlMd_CashVoucher);
            this.grpMDCashVoucherTop.Controls.Add(this.groupCashVoucher);
            this.grpMDCashVoucherTop.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grpMDCashVoucherTop.Location = new System.Drawing.Point(10, 0);
            this.grpMDCashVoucherTop.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.grpMDCashVoucherTop.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpMDCashVoucherTop.Name = "grpMDCashVoucherTop";
            this.grpMDCashVoucherTop.Size = new System.Drawing.Size(980, 592);
            this.grpMDCashVoucherTop.TabIndex = 91;
            this.grpMDCashVoucherTop.Text = "Cash Voucher";
            // 
            // Searchpanel
            // 
            this.Searchpanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Searchpanel.Controls.Add(btn_Add);
            this.Searchpanel.Controls.Add(btn_Del);
            this.Searchpanel.Controls.Add(this.btn_Search);
            this.Searchpanel.Controls.Add(this.txtSearch);
            this.Searchpanel.Location = new System.Drawing.Point(614, 48);
            this.Searchpanel.Name = "Searchpanel";
            this.Searchpanel.Size = new System.Drawing.Size(557, 27);
            this.Searchpanel.TabIndex = 152;
            // 
            // btn_Search
            // 
            this.btn_Search.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_Search.Appearance.Options.UseFont = true;
            this.btn_Search.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btn_Search.Location = new System.Drawing.Point(470, 0);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(68, 23);
            this.btn_Search.TabIndex = 137;
            this.btn_Search.Text = "Search";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.EditValue = "";
            this.txtSearch.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSearch.Location = new System.Drawing.Point(278, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Properties.Appearance.Options.UseFont = true;
            this.txtSearch.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtSearch.Size = new System.Drawing.Size(183, 23);
            this.txtSearch.TabIndex = 136;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btn_Add
            //             
            this.btn_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Appearance.Options.UseFont = true;
            this.btn_Add.Appearance.Options.UseTextOptions = true;
            this.btn_Add.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btn_Add.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btn_Add.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btn_Add.ImageIndex = 0;
            this.btn_Add.ImageList = this.imageList1;
            this.btn_Add.ImeMode = System.Windows.Forms.ImeMode.On;
            this.btn_Add.Location = new System.Drawing.Point(10, 0);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(45, 18);
            this.btn_Add.TabIndex = 132;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Del
            // 
            this.btn_Del.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Del.Appearance.Options.UseFont = true;
            this.btn_Del.Appearance.Options.UseTextOptions = true;
            this.btn_Del.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btn_Del.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btn_Del.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btn_Del.ImageIndex = 1;
            this.btn_Del.ImageList = this.imageList1;
            this.btn_Del.Location = new System.Drawing.Point(58, 0);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(45, 18);
            this.btn_Del.TabIndex = 131;
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // gridControlMd_CashVoucher
            // 
            this.gridControlMd_CashVoucher.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControlMd_CashVoucher.Location = new System.Drawing.Point(2, 342);
            this.gridControlMd_CashVoucher.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControlMd_CashVoucher.MainView = this.gridViewMdCashVoucher;
            this.gridControlMd_CashVoucher.Name = "gridControlMd_CashVoucher";
            this.gridControlMd_CashVoucher.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,this.lk_BranchCode});
            this.gridControlMd_CashVoucher.Size = new System.Drawing.Size(998, 420);
            this.gridControlMd_CashVoucher.TabIndex = 19;
            this.gridControlMd_CashVoucher.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMdCashVoucher});
            // 
            // lk_BranchCode
            // 
            this.lk_BranchCode.AutoHeight = false;
            this.lk_BranchCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_BranchCode.Name = "lk_BranchCode";
            // 
            // gridViewMdCashVoucher
            // 
            this.gridViewMdCashVoucher.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnSV1,
            this.gridColumnSV2,
            this.gridColumnSV3,
            this.gridColumnSV4,
            this.gridColumnSV5,
            this.gridColumnSV6,
            this.gridColumnSV7,
            this.gridColumnSV8,
            this.gridColumnSV9,
            this.gridColumnSV10,
            this.gridColumnSV11
            });
            this.gridViewMdCashVoucher.GridControl = this.gridControlMd_CashVoucher;
            this.gridViewMdCashVoucher.Name = "gridViewMdCashVoucher";
            this.gridViewMdCashVoucher.OptionsCustomization.AllowFilter = false;
            this.gridViewMdCashVoucher.OptionsCustomization.AllowSort = false;
            this.gridViewMdCashVoucher.OptionsView.ShowGroupPanel = false;
            this.gridViewMdCashVoucher.LostFocus += new System.EventHandler(this.gridViewMdCashVoucher_LostFocus);
            // 
            // gridColumnSV1
            // 
            this.gridColumnSV1.Caption = "SN";
            this.gridColumnSV1.FieldName = "strSN";
            this.gridColumnSV1.Name = "gridColumnSV1";
            this.gridColumnSV1.Visible = true;
            this.gridColumnSV1.VisibleIndex = 0;
            this.gridColumnSV1.Width = 93;
            // 
            // gridColumnSV2
            // 
            this.gridColumnSV2.Caption = "Description";
            this.gridColumnSV2.FieldName = "strDescription";
            this.gridColumnSV2.Name = "gridColumnSV2";
            this.gridColumnSV2.Visible = true;
            this.gridColumnSV2.VisibleIndex = 1;
            this.gridColumnSV2.Width = 93;
            // 
            // gridColumnSV3
            // 
            this.gridColumnSV3.Caption = "Description 2";
            this.gridColumnSV3.FieldName = "strDescription2";
            this.gridColumnSV3.Name = "gridColumnSV3";
            this.gridColumnSV3.Visible = true;
            this.gridColumnSV3.VisibleIndex = 2;
            this.gridColumnSV3.Width = 93;
            // 
            // gridColumnSV4
            // 
            this.gridColumnSV4.Caption = "Status";
            this.gridColumnSV4.FieldName = "nStatusID";
            this.gridColumnSV4.Name = "gridColumnSV4";
            this.gridColumnSV4.Visible = true;
            this.gridColumnSV4.VisibleIndex = 3;
            this.gridColumnSV4.Width = 93;
            // 
            // gridColumnSV5
            // 
            this.gridColumnSV5.Caption = "Start Date";
            this.gridColumnSV5.FieldName = "dtStartDate";
            this.gridColumnSV5.Name = "gridColumnSV5";
            this.gridColumnSV5.Visible = true;
            this.gridColumnSV5.VisibleIndex = 4;
            this.gridColumnSV5.Width = 93;
            // 
            // gridColumnSV6
            // 
            this.gridColumnSV6.Caption = "Expiry Date";
            this.gridColumnSV6.FieldName = "dtExpiryDate";
            this.gridColumnSV6.Name = "gridColumnSV6";
            this.gridColumnSV6.Visible = true;
            this.gridColumnSV6.VisibleIndex = 5;
            this.gridColumnSV6.Width = 93;
            // 
            // gridColumnSV7
            // 
            this.gridColumnSV7.Caption = "Cash Value";
            this.gridColumnSV7.FieldName = "mValue";
            this.gridColumnSV7.Name = "gridColumnSV7";
            this.gridColumnSV7.Visible = true;
            this.gridColumnSV7.VisibleIndex = 6;
            this.gridColumnSV7.Width = 93;
            // 
            // gridColumnSV8
            // 
            this.gridColumnSV8.Caption = "Branch Code";
            this.gridColumnSV8.ColumnEdit = this.lk_BranchCode;
            this.gridColumnSV8.FieldName = "strBranchCode";
            this.gridColumnSV8.Name = "gridColumnSV8";
            this.gridColumnSV8.Visible = true;
            this.gridColumnSV8.VisibleIndex = 7;
            this.gridColumnSV8.Width = 102;
            // 
            // gridColumnSV11
            // 
            this.gridColumnSV11.Caption = "Terminal ID";
            this.gridColumnSV11.FieldName = "nTerminalID";
            this.gridColumnSV11.Name = "gridColumnSV11";
            this.gridColumnSV11.Visible = true;
            this.gridColumnSV11.VisibleIndex = 8;
            this.gridColumnSV11.Width = 93;
            // 
            // gridColumnSV9
            // 
            this.gridColumnSV9.Caption = "Cash Voucher Type";
            this.gridColumnSV9.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.gridColumnSV9.FieldName = "nCashVoucherTypeID";
            this.gridColumnSV9.Name = "gridColumnSV9";
            this.gridColumnSV9.Visible = true;
            this.gridColumnSV9.VisibleIndex = 8;
            this.gridColumnSV9.Width = 94;
            // 
            // cmbStatus
            // 
            this.cmbStatus.AutoHeight = false;
            this.cmbStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbStatus.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Active", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Deleted", 1, -1)});
            this.cmbStatus.Name = "cmbStatus";
            // 
            // groupCashVoucher
            // 
            this.groupCashVoucher.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupCashVoucher.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupCashVoucher.Appearance.Options.UseBackColor = true;
            this.groupCashVoucher.Controls.Add(this.pbSelect);
            this.groupCashVoucher.Controls.Add(this.txtFilePath);
            this.groupCashVoucher.Controls.Add(this.label9);
            this.groupCashVoucher.Controls.Add(this.btnCashVoucherImport);
            this.groupCashVoucher.ImeMode = System.Windows.Forms.ImeMode.On;
            this.groupCashVoucher.Location = new System.Drawing.Point(10, 647);
            this.groupCashVoucher.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupCashVoucher.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupCashVoucher.Name = "groupCashVoucher";
            this.groupCashVoucher.Size = new System.Drawing.Size(980, 110);
            this.groupCashVoucher.TabIndex = 19;
            this.groupCashVoucher.Text = "Cash Voucher Import";
            // 
            // pbSelect
            // 
            this.pbSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSelect.ErrorImage = global::ACMS.Properties.Resources.open_file_icon;
            this.pbSelect.Image = global::ACMS.Properties.Resources.open_file_icon;
            this.pbSelect.InitialImage = global::ACMS.Properties.Resources.open_file_icon;
            this.pbSelect.Location = new System.Drawing.Point(573, 42);
            this.pbSelect.Name = "pbSelect";
            this.pbSelect.Size = new System.Drawing.Size(20, 20);
            this.pbSelect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSelect.TabIndex = 36;
            this.pbSelect.TabStop = false;
            this.pbSelect.Click += new System.EventHandler(this.pbSelect_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.EditValue = "";
            this.txtFilePath.Location = new System.Drawing.Point(266, 43);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Properties.MaxLength = 255;
            this.txtFilePath.Properties.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(301, 20);
            this.txtFilePath.TabIndex = 35;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(125, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 16);
            this.label9.TabIndex = 34;
            this.label9.Text = "Select file to upload";
            // 
            // btnCashVoucherImport
            // 
            this.btnCashVoucherImport.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCashVoucherImport.Appearance.Options.UseFont = true;
            this.btnCashVoucherImport.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnCashVoucherImport.Location = new System.Drawing.Point(521, 69);
            this.btnCashVoucherImport.Name = "btnCashVoucherImport";
            this.btnCashVoucherImport.Size = new System.Drawing.Size(72, 18);
            this.btnCashVoucherImport.TabIndex = 12;
            this.btnCashVoucherImport.Text = "Import";
            this.btnCashVoucherImport.Click += new System.EventHandler(this.btnCashVoucherImport_Click);
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // gridColumnSV10
            // 
            this.gridColumnSV10.Caption = "Sell?";
            this.gridColumnSV10.FieldName = "fSell";
            this.gridColumnSV10.Name = "gridColumnSV10";
            this.gridColumnSV10.Visible = true;
            this.gridColumnSV10.VisibleIndex = 9;
            this.gridColumnSV10.Width = 88;
            // 
            // frmCashVoucher
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1000, 560);
            this.Controls.Add(this.grpMDCashVoucherTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCashVoucher";
            this.Text = "frmCashVoucher";
            this.Load += new System.EventHandler(this.frmCashVoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpMDCashVoucherTop)).EndInit();
            this.grpMDCashVoucherTop.ResumeLayout(false);
            this.Searchpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMd_CashVoucher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMdCashVoucher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_BranchCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupCashVoucher)).EndInit();
            this.groupCashVoucher.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilePath.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpMDCashVoucherTop;
        private System.Windows.Forms.Panel Searchpanel;
        internal DevExpress.XtraEditors.SimpleButton btn_Search;
        internal DevExpress.XtraEditors.TextEdit txtSearch;
        internal DevExpress.XtraEditors.SimpleButton btn_Add;
        internal DevExpress.XtraEditors.SimpleButton btn_Del;
        private DevExpress.XtraGrid.GridControl gridControlMd_CashVoucher;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMdCashVoucher;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSV1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSV2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSV3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSV4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSV5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSV6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSV7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSV8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSV9;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSV10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSV11;

    }
}