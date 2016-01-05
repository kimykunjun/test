using System;
using System.Text;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using Do = Acms.Core.Domain;
using ACMSLogic;
using ACMS.Utils;
using System.Net;
using System.IO;
using System.Data.OleDb;

namespace ACMS.ACMSManager.Operation
{
    /// <summary>
    /// Summary description for frmMemberCardPhoto.
    /// </summary>
    public class frmMemberCardPhoto : System.Windows.Forms.Form
    {
        [DllImport("odbc32.dll")]
        private static extern short SQLAllocHandle(short hType, IntPtr inputHandle, out IntPtr outputHandle);
        [DllImport("odbc32.dll")]
        private static extern short SQLSetEnvAttr(IntPtr henv, int attribute, IntPtr valuePtr, int strLength);
        [DllImport("odbc32.dll")]
        private static extern short SQLFreeHandle(short hType, IntPtr handle);
        [DllImport("odbc32.dll", CharSet = CharSet.Ansi)]
        private static extern short SQLBrowseConnect(IntPtr hconn, StringBuilder inString,
            short inStringLength, StringBuilder outString, short outStringLength,
            out short outLengthNeeded);
        private ToolTip toolTip1;
        private const short SQL_HANDLE_ENV = 1;
        private const short SQL_HANDLE_DBC = 2;
        private const int SQL_ATTR_ODBC_VERSION = 200;
        private const int SQL_OV_ODBC3 = 3;
        private const short SQL_SUCCESS = 0;

        private const short SQL_NEED_DATA = 99;
        private const short DEFAULT_RESULT_SIZE = 1024;
        private const string SQL_DRIVER_STR = "DRIVER=SQL SERVER";
        private string gstrBranchCode;
        private string connectionString;
        private SqlConnection connection;
        private Do.Employee employee;
        private static Do.TerminalUser terminalUser;
        private static User oUser;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraTab.XtraTabControl xtraTab;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private DevExpress.XtraTab.XtraTabPage xtraTabMemberCardPhoto;
        private Label label1;
        internal DevExpress.XtraGrid.GridControl GridMemberCard;
        internal DevExpress.XtraGrid.Views.Grid.GridView gridViewMemberCard;
        internal DevExpress.XtraGrid.Columns.GridColumn gcCheck;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckSelection;
        private DevExpress.XtraGrid.Columns.GridColumn gcMemberPhotoID;
        internal DevExpress.XtraGrid.Columns.GridColumn gcMembershipID;
        internal DevExpress.XtraGrid.Columns.GridColumn gcMemberName;
        private DevExpress.XtraGrid.Columns.GridColumn gcRequestDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.SimpleButton btnMemberPhotoReject;
        private DevExpress.XtraEditors.SimpleButton btnMemberPhotoApprove;
        private DevExpress.XtraTab.XtraTabPage xtraTabPackageExtension;
        //private DevExpress.XtraEditors.PictureEdit pictureEdit2;
        private PictureBox pictureEdit2;
        private DevExpress.XtraEditors.SimpleButton btnPackageExtensionReject;
        private DevExpress.XtraEditors.SimpleButton btnPackageExtensionApprove;
        private Label label2;
        internal DevExpress.XtraGrid.GridControl GridPackageExtension;
        internal DevExpress.XtraGrid.Views.Grid.GridView gridViewPackageExtension;
        internal DevExpress.XtraGrid.Columns.GridColumn gcCheckExtension;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gcExtensionID;
        internal DevExpress.XtraGrid.Columns.GridColumn gcPackageCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreateDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox3;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox4;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gReason;
        private DevExpress.XtraGrid.Columns.GridColumn gcDayExtend;
        private DevExpress.XtraGrid.Columns.GridColumn gcMemberID;
        private DevExpress.XtraGrid.Columns.GridColumn gcStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcNewExpiryDate;
        private IContainer components;
        private Button btnRotate;
        private Button btnPhotoRotate;
        private static int CurrentLockerRowFocus;

        public frmMemberCardPhoto()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"];
            connection = new SqlConnection(connectionString);
            MemberCardInit();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.xtraTab = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabMemberCardPhoto = new DevExpress.XtraTab.XtraTabPage();
            this.btnPhotoRotate = new System.Windows.Forms.Button();
            this.btnMemberPhotoReject = new DevExpress.XtraEditors.SimpleButton();
            this.btnMemberPhotoApprove = new DevExpress.XtraEditors.SimpleButton();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.GridMemberCard = new DevExpress.XtraGrid.GridControl();
            this.gridViewMemberCard = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckSelection = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gcMemberPhotoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMembershipID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMemberName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRequestDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.xtraTabPackageExtension = new DevExpress.XtraTab.XtraTabPage();
            this.btnRotate = new System.Windows.Forms.Button();
            this.pictureEdit2 = new System.Windows.Forms.PictureBox();
            this.btnPackageExtensionReject = new DevExpress.XtraEditors.SimpleButton();
            this.btnPackageExtensionApprove = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.GridPackageExtension = new DevExpress.XtraGrid.GridControl();
            this.gridViewPackageExtension = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCheckExtension = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gcExtensionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMemberID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPackageCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gReason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDayExtend = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNewExpiryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemImageComboBox4 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemImageEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemPictureEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTab)).BeginInit();
            this.xtraTab.SuspendLayout();
            this.xtraTabMemberCardPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridMemberCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMemberCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            this.xtraTabPackageExtension.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridPackageExtension)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPackageExtension)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.xtraTab);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(912, 525);
            this.groupControl1.TabIndex = 124;
            this.groupControl1.Text = "Mobile App";
            // 
            // xtraTab
            // 
            this.xtraTab.Location = new System.Drawing.Point(8, 48);
            this.xtraTab.Name = "xtraTab";
            this.xtraTab.SelectedTabPage = this.xtraTabMemberCardPhoto;
            this.xtraTab.Size = new System.Drawing.Size(840, 442);
            this.xtraTab.TabIndex = 119;
            this.xtraTab.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabMemberCardPhoto,
            this.xtraTabPackageExtension});
            // 
            // xtraTabMemberCardPhoto
            // 
            this.xtraTabMemberCardPhoto.Controls.Add(this.btnPhotoRotate);
            this.xtraTabMemberCardPhoto.Controls.Add(this.btnMemberPhotoReject);
            this.xtraTabMemberCardPhoto.Controls.Add(this.btnMemberPhotoApprove);
            this.xtraTabMemberCardPhoto.Controls.Add(this.pictureEdit1);
            this.xtraTabMemberCardPhoto.Controls.Add(this.label1);
            this.xtraTabMemberCardPhoto.Controls.Add(this.GridMemberCard);
            this.xtraTabMemberCardPhoto.Name = "xtraTabMemberCardPhoto";
            this.xtraTabMemberCardPhoto.Size = new System.Drawing.Size(831, 411);
            this.xtraTabMemberCardPhoto.Text = "Photo Approval";
            // 
            // btnPhotoRotate
            // 
            this.btnPhotoRotate.Location = new System.Drawing.Point(629, 112);
            this.btnPhotoRotate.Name = "btnPhotoRotate";
            this.btnPhotoRotate.Size = new System.Drawing.Size(75, 23);
            this.btnPhotoRotate.TabIndex = 89;
            this.btnPhotoRotate.Text = "Rotate";
            this.btnPhotoRotate.UseVisualStyleBackColor = true;
            this.btnPhotoRotate.Click += new System.EventHandler(this.btnPhotoRotate_Click);
            // 
            // btnMemberPhotoReject
            // 
            this.btnMemberPhotoReject.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemberPhotoReject.Appearance.Options.UseFont = true;
            this.btnMemberPhotoReject.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnMemberPhotoReject.Location = new System.Drawing.Point(84, 340);
            this.btnMemberPhotoReject.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnMemberPhotoReject.Name = "btnMemberPhotoReject";
            this.btnMemberPhotoReject.Size = new System.Drawing.Size(75, 23);
            this.btnMemberPhotoReject.TabIndex = 83;
            this.btnMemberPhotoReject.Text = "Reject";
            this.btnMemberPhotoReject.Click += new System.EventHandler(this.btnMemberPhotoReject_Click);
            // 
            // btnMemberPhotoApprove
            // 
            this.btnMemberPhotoApprove.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemberPhotoApprove.Appearance.Options.UseFont = true;
            this.btnMemberPhotoApprove.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnMemberPhotoApprove.Location = new System.Drawing.Point(3, 340);
            this.btnMemberPhotoApprove.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnMemberPhotoApprove.Name = "btnMemberPhotoApprove";
            this.btnMemberPhotoApprove.Size = new System.Drawing.Size(75, 23);
            this.btnMemberPhotoApprove.TabIndex = 82;
            this.btnMemberPhotoApprove.Text = "Approve";
            this.btnMemberPhotoApprove.Click += new System.EventHandler(this.btnMemberPhotoApprove_Click);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Location = new System.Drawing.Point(710, 23);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(109, 112);
            this.pictureEdit1.TabIndex = 11;
            this.pictureEdit1.Click += new System.EventHandler(this.pictureEdit1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Pending Approval";
            // 
            // GridMemberCard
            // 
            this.GridMemberCard.Location = new System.Drawing.Point(3, 143);
            this.GridMemberCard.LookAndFeel.UseDefaultLookAndFeel = false;
            this.GridMemberCard.MainView = this.gridViewMemberCard;
            this.GridMemberCard.Name = "GridMemberCard";
            this.GridMemberCard.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckSelection,
            this.repositoryItemImageComboBox1,
            this.repositoryItemImageComboBox2,
            this.repositoryItemImageEdit1,
            this.repositoryItemPictureEdit1});
            this.GridMemberCard.Size = new System.Drawing.Size(816, 191);
            this.GridMemberCard.TabIndex = 9;
            this.GridMemberCard.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMemberCard});
            // 
            // gridViewMemberCard
            // 
            this.gridViewMemberCard.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCheck,
            this.gcMemberPhotoID,
            this.gcMembershipID,
            this.gcMemberName,
            this.gcRequestDate});
            this.gridViewMemberCard.GridControl = this.GridMemberCard;
            this.gridViewMemberCard.Name = "gridViewMemberCard";
            this.gridViewMemberCard.OptionsView.ShowGroupPanel = false;
            this.gridViewMemberCard.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewMemberCard_FocusedRowChanged);
            // 
            // gcCheck
            // 
            this.gcCheck.Caption = "Utl";
            this.gcCheck.ColumnEdit = this.repositoryItemCheckSelection;
            this.gcCheck.FieldName = "UtlCheck";
            this.gcCheck.Name = "gcCheck";
            this.gcCheck.OptionsColumn.ShowCaption = false;
            this.gcCheck.Visible = true;
            this.gcCheck.VisibleIndex = 0;
            this.gcCheck.Width = 25;
            // 
            // repositoryItemCheckSelection
            // 
            this.repositoryItemCheckSelection.AutoHeight = false;
            this.repositoryItemCheckSelection.Name = "repositoryItemCheckSelection";
            this.repositoryItemCheckSelection.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // gcMemberPhotoID
            // 
            this.gcMemberPhotoID.Caption = "ID";
            this.gcMemberPhotoID.FieldName = "nMemberPhotoID";
            this.gcMemberPhotoID.Name = "gcMemberPhotoID";
            this.gcMemberPhotoID.OptionsColumn.AllowEdit = false;
            this.gcMemberPhotoID.Visible = true;
            this.gcMemberPhotoID.VisibleIndex = 1;
            // 
            // gcMembershipID
            // 
            this.gcMembershipID.Caption = "Membership ID";
            this.gcMembershipID.FieldName = "strMembershipID";
            this.gcMembershipID.Name = "gcMembershipID";
            this.gcMembershipID.OptionsColumn.AllowEdit = false;
            this.gcMembershipID.Visible = true;
            this.gcMembershipID.VisibleIndex = 2;
            this.gcMembershipID.Width = 117;
            // 
            // gcMemberName
            // 
            this.gcMemberName.Caption = "Member Name";
            this.gcMemberName.FieldName = "strMemberName";
            this.gcMemberName.Name = "gcMemberName";
            this.gcMemberName.OptionsColumn.AllowEdit = false;
            this.gcMemberName.Visible = true;
            this.gcMemberName.VisibleIndex = 3;
            this.gcMemberName.Width = 161;
            // 
            // gcRequestDate
            // 
            this.gcRequestDate.Caption = "Request Date";
            this.gcRequestDate.FieldName = "dtUpload";
            this.gcRequestDate.Name = "gcRequestDate";
            this.gcRequestDate.OptionsColumn.AllowEdit = false;
            this.gcRequestDate.Visible = true;
            this.gcRequestDate.VisibleIndex = 4;
            this.gcRequestDate.Width = 162;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Request Print", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Print in Progress", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("In Transit", 3, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Card Received", 4, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Card Issued", 5, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Cancelled", 6, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Transfer Request", 7, -1)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // repositoryItemImageComboBox2
            // 
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            this.repositoryItemImageEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // xtraTabPackageExtension
            // 
            this.xtraTabPackageExtension.Controls.Add(this.btnRotate);
            this.xtraTabPackageExtension.Controls.Add(this.pictureEdit2);
            this.xtraTabPackageExtension.Controls.Add(this.btnPackageExtensionReject);
            this.xtraTabPackageExtension.Controls.Add(this.btnPackageExtensionApprove);
            this.xtraTabPackageExtension.Controls.Add(this.label2);
            this.xtraTabPackageExtension.Controls.Add(this.GridPackageExtension);
            this.xtraTabPackageExtension.Name = "xtraTabPackageExtension";
            this.xtraTabPackageExtension.Size = new System.Drawing.Size(831, 411);
            this.xtraTabPackageExtension.Text = "Package Extension Approval";
            // 
            // btnRotate
            // 
            this.btnRotate.Location = new System.Drawing.Point(597, 134);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(75, 23);
            this.btnRotate.TabIndex = 87;
            this.btnRotate.Text = "Rotate";
            this.btnRotate.UseVisualStyleBackColor = true;
            this.btnRotate.Click += new System.EventHandler(this.btnRotate_Click);
            // 
            // pictureEdit2
            // 
            this.pictureEdit2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureEdit2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureEdit2.Location = new System.Drawing.Point(690, 14);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Size = new System.Drawing.Size(123, 143);
            this.pictureEdit2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureEdit2.TabIndex = 86;
            this.pictureEdit2.TabStop = false;
            this.pictureEdit2.Click += new System.EventHandler(this.pictureEdit2_Click);
            // 
            // btnPackageExtensionReject
            // 
            this.btnPackageExtensionReject.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPackageExtensionReject.Appearance.Options.UseFont = true;
            this.btnPackageExtensionReject.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnPackageExtensionReject.Location = new System.Drawing.Point(88, 361);
            this.btnPackageExtensionReject.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPackageExtensionReject.Name = "btnPackageExtensionReject";
            this.btnPackageExtensionReject.Size = new System.Drawing.Size(75, 23);
            this.btnPackageExtensionReject.TabIndex = 85;
            this.btnPackageExtensionReject.Text = "Reject";
            this.btnPackageExtensionReject.Click += new System.EventHandler(this.btnPackageExtensionReject_Click);
            // 
            // btnPackageExtensionApprove
            // 
            this.btnPackageExtensionApprove.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPackageExtensionApprove.Appearance.Options.UseFont = true;
            this.btnPackageExtensionApprove.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnPackageExtensionApprove.Location = new System.Drawing.Point(7, 361);
            this.btnPackageExtensionApprove.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPackageExtensionApprove.Name = "btnPackageExtensionApprove";
            this.btnPackageExtensionApprove.Size = new System.Drawing.Size(75, 23);
            this.btnPackageExtensionApprove.TabIndex = 84;
            this.btnPackageExtensionApprove.Text = "Approve";
            this.btnPackageExtensionApprove.Click += new System.EventHandler(this.btnPackageExtensionApprove_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Pending Approval";
            // 
            // GridPackageExtension
            // 
            this.GridPackageExtension.Location = new System.Drawing.Point(7, 167);
            this.GridPackageExtension.LookAndFeel.UseDefaultLookAndFeel = false;
            this.GridPackageExtension.MainView = this.gridViewPackageExtension;
            this.GridPackageExtension.Name = "GridPackageExtension";
            this.GridPackageExtension.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemImageComboBox3,
            this.repositoryItemImageComboBox4,
            this.repositoryItemImageEdit2,
            this.repositoryItemPictureEdit2});
            this.GridPackageExtension.Size = new System.Drawing.Size(806, 188);
            this.GridPackageExtension.TabIndex = 10;
            this.GridPackageExtension.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPackageExtension});
            // 
            // gridViewPackageExtension
            // 
            this.gridViewPackageExtension.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCheckExtension,
            this.gcExtensionID,
            this.gcCreateDate,
            this.gcMemberID,
            this.gcPackageCode,
            this.gReason,
            this.gcDayExtend,
            this.gcStartDate,
            this.gcEndDate,
            this.gcNewExpiryDate});
            this.gridViewPackageExtension.GridControl = this.GridPackageExtension;
            this.gridViewPackageExtension.Name = "gridViewPackageExtension";
            this.gridViewPackageExtension.OptionsView.ShowGroupPanel = false;
            this.gridViewPackageExtension.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewPackageExtension_FocusedRowChanged);
            this.gridViewPackageExtension.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewPackageExtension_CellValueChanged);
            // 
            // gcCheckExtension
            // 
            this.gcCheckExtension.Caption = "Utl";
            this.gcCheckExtension.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gcCheckExtension.FieldName = "UtlCheck";
            this.gcCheckExtension.Name = "gcCheckExtension";
            this.gcCheckExtension.OptionsColumn.ShowCaption = false;
            this.gcCheckExtension.Visible = true;
            this.gcCheckExtension.VisibleIndex = 0;
            this.gcCheckExtension.Width = 22;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // gcExtensionID
            // 
            this.gcExtensionID.Caption = "extensionID";
            this.gcExtensionID.FieldName = "nExtensionID";
            this.gcExtensionID.Name = "gcExtensionID";
            this.gcExtensionID.OptionsColumn.AllowEdit = false;
            // 
            // gcCreateDate
            // 
            this.gcCreateDate.Caption = "Request Date";
            this.gcCreateDate.FieldName = "dtCreateDate";
            this.gcCreateDate.Name = "gcCreateDate";
            this.gcCreateDate.OptionsColumn.AllowEdit = false;
            this.gcCreateDate.Visible = true;
            this.gcCreateDate.VisibleIndex = 1;
            this.gcCreateDate.Width = 76;
            // 
            // gcMemberID
            // 
            this.gcMemberID.Caption = "Membership ID";
            this.gcMemberID.FieldName = "strMembershipID";
            this.gcMemberID.Name = "gcMemberID";
            this.gcMemberID.OptionsColumn.AllowEdit = false;
            this.gcMemberID.Visible = true;
            this.gcMemberID.VisibleIndex = 2;
            // 
            // gcPackageCode
            // 
            this.gcPackageCode.Caption = "Package Code";
            this.gcPackageCode.FieldName = "strPackageCode";
            this.gcPackageCode.Name = "gcPackageCode";
            this.gcPackageCode.OptionsColumn.AllowEdit = false;
            this.gcPackageCode.Visible = true;
            this.gcPackageCode.VisibleIndex = 3;
            this.gcPackageCode.Width = 148;
            // 
            // gReason
            // 
            this.gReason.Caption = "Reason";
            this.gReason.FieldName = "strDescription";
            this.gReason.Name = "gReason";
            this.gReason.OptionsColumn.AllowEdit = false;
            this.gReason.Visible = true;
            this.gReason.VisibleIndex = 4;
            this.gReason.Width = 140;
            // 
            // gcDayExtend
            // 
            this.gcDayExtend.Caption = "Days Extend";
            this.gcDayExtend.FieldName = "nDaysExtended";
            this.gcDayExtend.Name = "gcDayExtend";
            this.gcDayExtend.OptionsColumn.AllowEdit = false;
            this.gcDayExtend.Visible = true;
            this.gcDayExtend.VisibleIndex = 7;
            // 
            // gcStartDate
            // 
            this.gcStartDate.Caption = "Start Date";
            this.gcStartDate.FieldName = "dtStartDate";
            this.gcStartDate.Name = "gcStartDate";
            this.gcStartDate.Visible = true;
            this.gcStartDate.VisibleIndex = 5;
            // 
            // gcEndDate
            // 
            this.gcEndDate.Caption = "End Date";
            this.gcEndDate.FieldName = "dtEndDate";
            this.gcEndDate.Name = "gcEndDate";
            this.gcEndDate.Visible = true;
            this.gcEndDate.VisibleIndex = 6;
            // 
            // gcNewExpiryDate
            // 
            this.gcNewExpiryDate.Caption = "New Expiry Date";
            this.gcNewExpiryDate.Name = "gcNewExpiryDate";
            this.gcNewExpiryDate.OptionsColumn.AllowEdit = false;
            this.gcNewExpiryDate.Visible = true;
            this.gcNewExpiryDate.VisibleIndex = 8;
            // 
            // repositoryItemImageComboBox3
            // 
            this.repositoryItemImageComboBox3.AutoHeight = false;
            this.repositoryItemImageComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox3.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Request Print", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Print in Progress", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("In Transit", 3, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Card Received", 4, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Card Issued", 5, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Cancelled", 6, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Transfer Request", 7, -1)});
            this.repositoryItemImageComboBox3.Name = "repositoryItemImageComboBox3";
            // 
            // repositoryItemImageComboBox4
            // 
            this.repositoryItemImageComboBox4.AutoHeight = false;
            this.repositoryItemImageComboBox4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox4.Name = "repositoryItemImageComboBox4";
            // 
            // repositoryItemImageEdit2
            // 
            this.repositoryItemImageEdit2.AutoHeight = false;
            this.repositoryItemImageEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit2.Name = "repositoryItemImageEdit2";
            this.repositoryItemImageEdit2.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // repositoryItemPictureEdit2
            // 
            this.repositoryItemPictureEdit2.Name = "repositoryItemPictureEdit2";
            // 
            // frmMemberCardPhoto
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(912, 525);
            this.ControlBox = false;
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMemberCardPhoto";
            this.Text = "frmMemberCardPhoto";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTab)).EndInit();
            this.xtraTab.ResumeLayout(false);
            this.xtraTabMemberCardPhoto.ResumeLayout(false);
            this.xtraTabMemberCardPhoto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridMemberCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMemberCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            this.xtraTabPackageExtension.ResumeLayout(false);
            this.xtraTabPackageExtension.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridPackageExtension)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPackageExtension)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void MemberCardInit()
        {                        
            //ListMemberCardPhoto(User.BranchCode);
        }

        public void ListMemberCardPhoto(string strBranchCode)
        {
            gstrBranchCode = strBranchCode;
            DataSet _ds = new DataSet();

            string strSQL = "select mp.*,strMemberName from tblMemberPhoto mp join tblMember m on mp.strMembershipID=m.strMembershipID where nStatusID=0 and m.strBranchCode='" + strBranchCode + "'  ";

            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "Table" }, new SqlParameter("@strSQL", strSQL));

            DataColumn dc = new DataColumn("UtlCheck", System.Type.GetType("System.Boolean"));
            _ds.Tables["Table"].Columns.Add(dc);

            DataView dv = new DataView(_ds.Tables["Table"]);
            GridMemberCard.DataSource = null;
            GridMemberCard.DataSource = dv;
            
            _ds.Dispose();            
            //DataTable dtblSource = dv.ToTable();
            pictureEdit1.DataBindings.Clear();
            pictureEdit1.DataBindings.Add(new Binding("EditValue", dv.ToTable(), "imgPhoto"));
        }

        public void ListPackageExtensionRequest(string strBranchCode)
        {
            toolTip1.SetToolTip(pictureEdit2, "Click to enlarge picture");
            gstrBranchCode = strBranchCode;
            DataSet _ds2 = new DataSet();

            string strSQL2 = "select * from (select (case when p.nCategoryID=1 OR p.nCategoryID=8 then 'Fitness' when p.nCategoryID=4 OR p.nCategoryID=5 OR p.nCategoryID=6 or p.nCategoryID=9 then 'Spa' when p.nCategoryID=3 then 'Personal Training' end) as strPackageType, p.strDescription as strPackageDescription, mp.strMembershipID, nExtensionID,mp.strPackageCode,dtOldExpiry,dtNewExpiry,pe.dtStartDate,dtEndDate,nDaysExtended,per.strDescription,dtCreateDate,'Normal' as strType, Convert(VARBINARY,pe.imgPhoto) as imgPhoto " +
                                    "from tblpackageextension pe join tblMemberPackage mp on pe.nPackageID=mp.nPackageID join tblPackage p on p.strPackageCode=mp.strPackageCode join tblPackageExtensionReasonType per on per.nReasonID=pe.nReasonID " +
                                    "join tblMember m on mp.strMembershipID = m.strMembershipID " +
                                    "where pe.nStatusID=4  and strBranchCode='" + strBranchCode + "' union select 'Credit' as strPackageType, p.strDescription as strPackageDescription, mp.strMembershipID,nExtensionID,mp.strCreditPackageCode as strPackageCode,dtOldExpiry,dtNewExpiry,pe.dtStartDate,dtEndDate,nDaysExtended,per.strDescription,dtCreateDate,'Credit' as strType, Convert(VARBINARY,pe.imgPhoto) as imgPhoto " +
                                    "from tblcreditpackageextension pe join tblMemberCreditPackage mp on pe.nCreditPackageID=mp.nCreditPackageID join tblCreditPackage p on p.strCreditPackageCode=mp.strCreditPackageCode " +
                                    "join tblMember m on mp.strMembershipID = m.strMembershipID " +
                                     "join tblPackageExtensionReasonType per on per.nReasonID=pe.nReasonID where pe.nStatusID=4  and strBranchCode='" + strBranchCode + "') extensionTable order by dtCreateDate ";
                                   
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds2, new string[] { "Table" }, new SqlParameter("@strSQL", strSQL2));

            DataColumn dc = new DataColumn("UtlCheck", System.Type.GetType("System.Boolean"));
            _ds2.Tables["Table"].Columns.Add(dc);

            DataView dv2 = new DataView(_ds2.Tables["Table"]);

            this.GridPackageExtension.DataSource = dv2;
            //DataTable dtblSource2 = dv2.ToTable();
            _ds2.Dispose();
            pictureEdit2.DataBindings.Clear();
            //using (var ms = new MemoryStream((byte[])dtblSource2.Rows[0]["imgPhoto"]))
            //{
            //    pictureEdit2.Image = Image.FromStream(ms);
            //}
            pictureEdit2.DataBindings.Add(new Binding("Image", dv2.ToTable(), "imgPhoto",true));
        }

        Bitmap photoBitmap;
        private void gridViewMemberCard_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr;
            dr = this.gridViewMemberCard.GetDataRow(gridViewMemberCard.FocusedRowHandle);
            if (dr != null)
            {
                DataSet _ds = new DataSet();
                string strSQL = "select mp.*,strMemberName from tblMemberPhoto mp join tblMember m on mp.strMembershipID=m.strMembershipID where nMemberPhotoID=" + dr["nMemberPhotoID"];
                SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "Table" }, new SqlParameter("@strSQL", strSQL));

                DataTable dtblSource = _ds.Tables["Table"];
                pictureEdit1.DataBindings.Clear();
                using (var ms = new MemoryStream((byte[])dtblSource.Rows[0]["imgPhoto"]))
                {
                    pictureEdit1.Image = Image.FromStream(ms);
                    photoBitmap = new Bitmap(new MemoryStream((byte[])dtblSource.Rows[0]["imgPhoto"]));
                    ms.Dispose();
                }
                
                //Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                //System.IO.MemoryStream ms2= new System.IO.MemoryStream();

                //byte[] imgPhoto;

                //if (this.pictureEdit1.Image != null)
                //{
                //    int newWidth = 180;
                //    int newHeight = 180;

                //    if (pictureEdit1.Image.Width > newWidth || pictureEdit1.Image.Height > newHeight)
                //    {
                //        double widthRatio = (double)pictureEdit1.Image.Width / (double)newWidth;
                //        double heightRatio = (double)pictureEdit1.Image.Height / (double)newHeight;
                //        double ratio = Math.Max(widthRatio, heightRatio);
                //        newWidth = (int)(pictureEdit1.Image.Width / ratio);
                //        newHeight = (int)(pictureEdit1.Image.Height / ratio);
                //    }
                //    MessageBox.Show("1");
                //    pictureEdit1.Image.GetThumbnailImage(newWidth, newHeight, myCallback, IntPtr.Zero).Save(ms2, pictureEdit1.Image.RawFormat);
                //    MessageBox.Show("2");
                //    ms2.Dispose();
                //    pictureEdit1.DataBindings.Clear();
                //    imgPhoto = ms2.GetBuffer();
                //    using (var ms3 = new MemoryStream(imgPhoto))
                //    {
                //        pictureEdit1.Image = Image.FromStream(ms3);
                //        ms3.Dispose();                        
                //    }
                //    //auditRemarks = auditRemarks + "updated by " + oUser.NEmployeeID();
                //}
                //else
                //{
                //    imgPhoto = new Byte[0];
                //}
                //ms2.Dispose();
            }
        }

        Bitmap bitmap1;
        private void gridViewPackageExtension_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr2;
            dr2 = this.gridViewPackageExtension.GetDataRow(gridViewPackageExtension.FocusedRowHandle);
            if (dr2 != null)
            {
                DataSet _ds2 = new DataSet();
                string strSQL2 = "";
                if (dr2["strType"].ToString() == "Normal")
                    strSQL2 = "select imgPhoto from tblPackageExtension where nExtensionID=" + dr2["nExtensionID"];
                    //strSQL2 = "select nExtensionID,mp.strPackageCode,dtOldExpiry,dtNewExpiry,pe.dtStartDate,dtEndDate,nDaysExtended,per.strDescription,dtCreateDate,'Normal' as strType, pe.imgPhoto " +
                    //               "from tblpackageextension pe join tblMemberPackage mp on pe.nPackageID=mp.nPackageID join tblPackageExtensionReasonType per on per.nReasonID=pe.nReasonID " +
                    //               "join tblMember m on mp.strMembershipID = m.strMembershipID " +
                    //               "where pe.nStatusID=4  and nExtensionID="+dr2["nExtensionID"];
                else
                    strSQL2 = "select imgPhoto from tblCreditPackageExtension where nExtensionID=" + dr2["nExtensionID"];

                SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds2, new string[] { "Table" }, new SqlParameter("@strSQL", strSQL2));

                DataTable dtblSource2 = _ds2.Tables["Table"];
                pictureEdit2.DataBindings.Clear();

                using (var ms = new MemoryStream((byte[])dtblSource2.Rows[0]["imgPhoto"]))
                {
                    pictureEdit2.Image = Image.FromStream(ms);
                    bitmap1 = new Bitmap(new MemoryStream((byte[])dtblSource2.Rows[0]["imgPhoto"]));
                    ms.Dispose();
                }

               
                //pictureEdit2.DataBindings.Add(new Binding("Image", dtblSource2, "imgPhoto"));
                //gctrReplies.DataSource = dtblSource;
                //lastMemoIDForReplies = nMemoID;
            }
        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            Form test = new Form();
            test.AutoScroll = true;
            PictureBox PictureBox1 = new PictureBox();
            PictureBox1.Size = pictureEdit2.Image.Size;
            PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
            PictureBox1.Image = pictureEdit2.Image;
            test.Size = pictureEdit2.Image.Size;
            test.Controls.Add(PictureBox1);
            test.ShowDialog();
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            Form test = new Form();
            PictureBox PictureBox1 = new PictureBox();
            PictureBox1.Size = pictureEdit1.Image.Size;
            PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
            PictureBox1.Image = pictureEdit1.Image;
            test.Size = pictureEdit1.Image.Size;
            test.Controls.Add(PictureBox1);
            test.ShowDialog();
        }

        public void SetEmployeeRecord(Do.Employee employee)
        {
            this.employee = employee;
        }

        private bool ThumbnailCallback()
        {
            return false;
        }

        private void btnMemberPhotoApprove_Click(object sender, EventArgs e)
        {          
            
            if (!employee.HasRight("AB_APPROVE_PHOTO"))
            {
                MessageBox.Show(this, "You are not allow to perform this action.");
                return;
            }

            if (!UI.ShowYesNoMessage("Are you sure you want to approve these request(s)?"))
                return;
            bool allNoTick = true;
           
            try
            {
                for (int i = 0; i < this.gridViewMemberCard.RowCount; i++)
                {
                    int rowHandle = gridViewMemberCard.GetVisibleRowHandle(i);
                    DataRow row = gridViewMemberCard.GetDataRow(rowHandle);

                    if (gridViewMemberCard.IsDataRow(rowHandle))
                    {
                        if (gridViewMemberCard.GetRowCellValue(rowHandle, "UtlCheck").ToString().ToUpper() == "TRUE")
                        {
                            allNoTick = false;                            
                            if (ApproveRequest(Convert.ToInt32(gridViewMemberCard.GetRowCellValue(rowHandle, "nMemberPhotoID").ToString())))
                            {
                                //MemoryStream ms = new MemoryStream();
                                //pictureEdit1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                                //ms.ToArray();

                                //Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                                //System.IO.MemoryStream ms = new System.IO.MemoryStream();

                                //byte[] imgPhoto;
                                //imgPhoto = null;
                                //if (this.pictureEdit1.Image != null)
                                //{
                                //    int newWidth = 180;
                                //    int newHeight = 180;

                                //    if (pictureEdit1.Image.Width > newWidth || pictureEdit1.Image.Height > newHeight)
                                //    {
                                //        double widthRatio = (double)pictureEdit1.Image.Width / (double)newWidth;
                                //        double heightRatio = (double)pictureEdit1.Image.Height / (double)newHeight;
                                //        double ratio = Math.Max(widthRatio, heightRatio);
                                //        newWidth = (int)(pictureEdit1.Image.Width / ratio);
                                //        newHeight = (int)(pictureEdit1.Image.Height / ratio);
                                //    }
                                //    pictureEdit1.Image.GetThumbnailImage(newWidth, newHeight, myCallback, IntPtr.Zero).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                                //    imgPhoto = ms.GetBuffer();
                                //    ms.Dispose();
                                //}
                                //else
                                //{
                                //    imgPhoto = new Byte[0];
                                //    ms.Dispose();
                                //}                                
                                //UpdatePhoto(gridViewMemberCard.GetRowCellValue(rowHandle, "strMembershipID").ToString(), imgPhoto);
                                //imgPhoto = null;
                                PushNotification(gridViewMemberCard.GetRowCellValue(rowHandle, "strMembershipID").ToString(), "Your photo has been approved. You can now view it under 'Member' > 'My Profile'. We will notify you for collection of membership card once it's ready.");
                            }
                        }
                    }
                }
                if (allNoTick)
                {
                    MessageBox.Show(this, "Please tick at least one request to approve");
                    return;
                }
                ListMemberCardPhoto(gstrBranchCode);
                MessageBox.Show(this, "Request have been approved.");                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
             
        }

        private void btnMemberPhotoReject_Click(object sender, EventArgs e)
        {
            if (!employee.HasRight("AB_REJECT_PHOTO"))
            {
                MessageBox.Show(this, "You are not allow to perform this action.");
                return;
            }

            if (!UI.ShowYesNoMessage("Are you sure you want to reject these request(s)?"))
                return;
            bool allNoTick = true;

            try
            {
                for (int i = 0; i < this.gridViewMemberCard.RowCount; i++)
                {
                    int rowHandle = gridViewMemberCard.GetVisibleRowHandle(i);
                    DataRow row = gridViewMemberCard.GetDataRow(rowHandle);

                    if (gridViewMemberCard.IsDataRow(rowHandle))
                    {
                        if (gridViewMemberCard.GetRowCellValue(rowHandle, "UtlCheck").ToString().ToUpper() == "TRUE")
                        {
                            allNoTick = false;
                            if (RejectRequest(Convert.ToInt32(gridViewMemberCard.GetRowCellValue(rowHandle, "nMemberPhotoID").ToString())))
                            {
                                PushNotification(gridViewMemberCard.GetRowCellValue(rowHandle, "strMembershipID").ToString(), "Your photo has been declined. Kindly re-submit a new passport-sized photo for your Membership Card.");
                            }
                        }
                    }
                }
                if (allNoTick)
                {
                    MessageBox.Show(this, "Please tick at least one request to reject");
                    return;
                }
                ListMemberCardPhoto(gstrBranchCode);
                MessageBox.Show(this, "Request have been rejected.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        public bool ApproveRequest(int nMemberPhotoID)
        {
            try
            {
                SqlHelperUtils.ExecuteNonQuerySP("sp_tblMemberPhoto_Approve", new SqlParameter("@inMemberPhotoId", nMemberPhotoID),
                    SqlHelperUtils.paramErrorCode);
            }
            catch
            {
                throw;
            }
            return true;
        }

        public bool UpdatePhoto(string strMembershipID, byte[] imgPhoto)
        {
            try
            {
                SqlHelperUtils.ExecuteNonQuerySP("sp_tblMember_UpdateMemberPhoto", new SqlParameter("@sstrMembershipID", strMembershipID), new SqlParameter("@imgPhoto", imgPhoto),
                    SqlHelperUtils.paramErrorCode);
            }
            catch
            {
                throw;
            }
            return true;
        }

        public bool RejectRequest(int nMemberPhotoID)
        {
            try
            {
                SqlHelperUtils.ExecuteNonQuerySP("sp_tblMemberPhoto_Reject", new SqlParameter("@inMemberPhotoId", nMemberPhotoID),
                    SqlHelperUtils.paramErrorCode);
            }
            catch
            {
                throw;
            }
            return true;
        }

        public bool ApprovePackageExtensionRequest(int nExtensionID, string strType, DateTime getStartDate, DateTime getEndDate, int total)
        {
            try
            {
                SqlHelperUtils.ExecuteNonQuerySP("sp_PackageExtension_Approve", 
                    new SqlParameter("@inExtensionId", nExtensionID), 
                    new SqlParameter("@strType", strType),
                    new SqlParameter("@getStartDate", getStartDate),
                    new SqlParameter("@getEndDate", getEndDate),
                    new SqlParameter("@getDaysExtend", total),
                    SqlHelperUtils.paramErrorCode);                
            }
            catch
            {
                throw;
            }
            return true;
        }

        public static void PushNotification(string strMembershipID, string strMsgContent)
        {
            WebRequest request = WebRequest.Create("http://web.amorefitness.com:8080/amore_app/exec/exec_notification_modified/pushMember/" + strMembershipID + "/" + strMsgContent);
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.

            string postData = "memberid=" + strMembershipID + "&msg="+ strMsgContent;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();        
        }

        public bool RejectPackageExtensionRequest(int nExtensionID, string strType)
        {
            try
            {
                SqlHelperUtils.ExecuteNonQuerySP("sp_PackageExtension_Reject", new SqlParameter("@inExtensionId", nExtensionID), new SqlParameter("@strType", strType),
                    SqlHelperUtils.paramErrorCode);
            }
            catch
            {
                throw;
            }
            return true;
        }

        private void btnPackageExtensionApprove_Click(object sender, EventArgs e)
        {
            if (!employee.HasRight("AB_APPROVE_PHOTO"))
            {
                MessageBox.Show(this, "You are not allow to perform this action.");
                return;
            }

            if (!UI.ShowYesNoMessage("Are you sure you want to approve these request(s)?"))
                return;
            bool allNoTick = true;

            try
            {
                for (int i = 0; i < this.gridViewPackageExtension.RowCount; i++)
                {
                    int rowHandle = gridViewPackageExtension.GetVisibleRowHandle(i);
                    DataRow row = gridViewPackageExtension.GetDataRow(rowHandle);

                    if (gridViewPackageExtension.IsDataRow(rowHandle))
                    {
                        if (gridViewPackageExtension.GetRowCellValue(rowHandle, "UtlCheck").ToString().ToUpper() == "TRUE")
                        {
                            allNoTick = false;
                            if (ApprovePackageExtensionRequest(Convert.ToInt32(gridViewPackageExtension.GetRowCellValue(rowHandle, "nExtensionID").ToString()), gridViewPackageExtension.GetRowCellValue(rowHandle, "strType").ToString(), Convert.ToDateTime(gridViewPackageExtension.GetRowCellValue(rowHandle, "dtStartDate").ToString()), Convert.ToDateTime(gridViewPackageExtension.GetRowCellValue(rowHandle, "dtEndDate").ToString()), Convert.ToInt32(gridViewPackageExtension.GetRowCellValue(rowHandle, "nDaysExtended").ToString())))
                            {     
                           
                            }
                            //PushNotification(row["strMembershipID"].ToString(), "Your request for extension of " + row["strPackageType"].ToString() + " Package from " + Convert.ToDateTime(row["dtStartDate"]).ToString("dd-MM-yyyy") + " to " + Convert.ToDateTime(row["dtEndDate"]).ToString("dd-MM-yyyy") + " has been approved.");
                        }
                    }
                }
                if (allNoTick)
                {
                    MessageBox.Show(this, "Please tick at least one request to approve");
                    return;
                }
                ListPackageExtensionRequest(gstrBranchCode);
                MessageBox.Show(this, "Request have been approved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void btnPackageExtensionReject_Click(object sender, EventArgs e)
        {
            if (!employee.HasRight("AB_REJECT_PHOTO"))
            {
                MessageBox.Show(this, "You are not allow to perform this action.");
                return;
            }

            if (!UI.ShowYesNoMessage("Are you sure you want to reject these request(s)?"))
                return;
            bool allNoTick = true;

            try
            {
                for (int i = 0; i < this.gridViewPackageExtension.RowCount; i++)
                {
                    int rowHandle = gridViewPackageExtension.GetVisibleRowHandle(i);
                    DataRow row = gridViewPackageExtension.GetDataRow(rowHandle);

                    if (gridViewPackageExtension.IsDataRow(rowHandle))
                    {
                        if (gridViewPackageExtension.GetRowCellValue(rowHandle, "UtlCheck").ToString().ToUpper() == "TRUE")
                        {
                            allNoTick = false;

                            if (RejectPackageExtensionRequest(Convert.ToInt32(gridViewPackageExtension.GetRowCellValue(rowHandle, "nExtensionID").ToString()), gridViewPackageExtension.GetRowCellValue(rowHandle, "strType").ToString()))
                            {                                
                            }
                            PushNotification(row["strMembershipID"].ToString(), "Your request for extension of " + row["strPackageType"].ToString() + " Package from " + Convert.ToDateTime(row["dtStartDate"]).ToString("dd-MM-yyyy") + " to " + Convert.ToDateTime(row["dtEndDate"]).ToString("dd-MM-yyyy") + " has been rejected. Sorry for any inconvenience caused.");                            
                        }
                    }
                }
                if (allNoTick)
                {
                    MessageBox.Show(this, "Please tick at least one request to reject");
                    return;
                }
                ListPackageExtensionRequest(gstrBranchCode);
                MessageBox.Show(this, "Request have been rejected.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        DateTime getStartDate, getEndDate;
 

        private void gridViewPackageExtension_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "dtStartDate" || e.Column.FieldName == "dtEndDate")
            {
                gridViewPackageExtension.RefreshRow(e.RowHandle);

            //    CurrentLockerRowFocus = gridViewPackageExtension.FocusedRowHandle;

                if (this.gridViewPackageExtension.RowCount > 0)
                {
                    getStartDate = DateTime.Parse(gridViewPackageExtension.GetRowCellValue(e.RowHandle, "dtStartDate").ToString());

                    getEndDate = DateTime.Parse(gridViewPackageExtension.GetRowCellValue(e.RowHandle, "dtEndDate").ToString());

                    TimeSpan diff = getEndDate - getStartDate;
                int total = int.Parse(diff.TotalDays.ToString()) + 1;
                string totalDays = total.ToString();

                gridViewPackageExtension.SetRowCellValue(e.RowHandle, "nDaysExtended", totalDays);
                   
                }
           }
        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            if (bitmap1 != null)
            {
                bitmap1.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureEdit2.Image = bitmap1;
            }
            
        }

        private void btnPhotoRotate_Click(object sender, EventArgs e)
        {
            if (photoBitmap != null)
            {
                photoBitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureEdit1.Image = photoBitmap;
            }
        }

            
    
    
    }
}