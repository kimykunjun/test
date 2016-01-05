using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

namespace ACMS.ACMSManager
{
	/// <summary>
	/// Summary description for frmMd_Package.
	/// </summary>
	public class frmMd_Package : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;

		private DevExpress.XtraEditors.GroupControl groupHdrMd_Promotion;
		private DevExpress.XtraEditors.GroupControl grpMDPackageBelow1;
		private System.Windows.Forms.Label hdrMd_Package;
		private System.Windows.Forms.Label mdPKG_lblNStatus;
		private System.Windows.Forms.Label mdPKG_lblNWarrantyMonths;
		private System.Windows.Forms.Label mdPKG_lvlNValidMonths;
		private System.Windows.Forms.Label mdPKG_lbldtValidEnd;
		private System.Windows.Forms.Label mdPKG_lbldtValidStart;
		private System.Windows.Forms.Label mdPKG_lblMBaseUnitPrice;
		private System.Windows.Forms.Label mdPKG_lblNPackageDuration;
		private System.Windows.Forms.Label mdPKG_lblNMaxSession;
		private System.Windows.Forms.Label mdPKG_lblMListPrice;
		private System.Windows.Forms.Label mdPKG_lblStrReceiptDesc;
		private System.Windows.Forms.Label mdPKG_lblStrDescription;
		private System.Windows.Forms.Label mdPKG_lblStrPackageCode;
		private DevExpress.XtraEditors.PanelControl grpMDPackageBelow2;
		private DevExpress.XtraEditors.CheckEdit mdPKG_fGIRO;
		private DevExpress.XtraEditors.CheckEdit mdPKG_fPeak;
		private DevExpress.XtraEditors.CheckEdit mdPKG_fNoRestrictionUpgrade;
		private DevExpress.XtraEditors.DateEdit mdPKG_dtValidStart;
		private DevExpress.XtraEditors.DateEdit mdPKG_dtValidEnd;
		private DevExpress.XtraEditors.TextEdit mdPKG_txtStrDescription;
		private DevExpress.XtraEditors.TextEdit mdPKG_txtStrReceiptDesc;
		private DevExpress.XtraEditors.TextEdit mdPKG_txtMListPrice;
		private DevExpress.XtraEditors.TextEdit mdPKG_txtNValidMonths;
		private DevExpress.XtraEditors.TextEdit mdPKG_txtNWarrantyMonths;
		private DevExpress.XtraEditors.TextEdit mdPKG_txtNMaxSession;
		private DevExpress.XtraEditors.TextEdit mdPKG_txtMBaseUnitPrice;
		private DevExpress.XtraEditors.TextEdit mdPKG_txtNPackageDuration;
		private DevExpress.XtraEditors.ImageComboBoxEdit mdPKG_cbNStatus;
		private DevExpress.XtraEditors.TextEdit mdPKG_txtStrPackageCode;
		private DevExpress.XtraEditors.CheckEdit mdPKG_fStudentPackage;
		private DevExpress.XtraEditors.SimpleButton btnPackageDelete;
		private DevExpress.XtraEditors.SimpleButton btnPackageCancel;
		private DevExpress.XtraEditors.SimpleButton btnPackageUpdate;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		char cmd;
		private System.Windows.Forms.Label mdPKG_lblStrPackageCategory;
		private DevExpress.XtraEditors.TextEdit mdpkg_txtNCategoryID;
		
		public char command
		{
			get
			{
				return cmd;
			}
			set
			{
				cmd = value;
			}
		}


		private DataTable _pkg;
		public DataTable dtPackage
		{
			get
			{
				return _pkg;
			}
			set
			{
				_pkg = value;
			}
		}


		public frmMd_Package(char cmd)
		{
			//
			// Required for Windows Form Designer support
			//
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);

			InitializeComponent();
			this.command = cmd;

		}


		public frmMd_Package(char cmd, DataTable pkg)
		{
			//
			// Required for Windows Form Designer support
			//
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);

			InitializeComponent();
			this.command = cmd;
			this.dtPackage = pkg;
			init();

		}


        
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupHdrMd_Promotion = new DevExpress.XtraEditors.GroupControl();
			this.hdrMd_Package = new System.Windows.Forms.Label();
			this.grpMDPackageBelow1 = new DevExpress.XtraEditors.GroupControl();
			this.mdPKG_lblStrPackageCategory = new System.Windows.Forms.Label();
			this.mdpkg_txtNCategoryID = new DevExpress.XtraEditors.TextEdit();
			this.mdPKG_txtStrPackageCode = new DevExpress.XtraEditors.TextEdit();
			this.btnPackageDelete = new DevExpress.XtraEditors.SimpleButton();
			this.btnPackageCancel = new DevExpress.XtraEditors.SimpleButton();
			this.btnPackageUpdate = new DevExpress.XtraEditors.SimpleButton();
			this.mdPKG_cbNStatus = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.mdPKG_txtNPackageDuration = new DevExpress.XtraEditors.TextEdit();
			this.mdPKG_txtMBaseUnitPrice = new DevExpress.XtraEditors.TextEdit();
			this.mdPKG_txtNMaxSession = new DevExpress.XtraEditors.TextEdit();
			this.mdPKG_txtNWarrantyMonths = new DevExpress.XtraEditors.TextEdit();
			this.mdPKG_txtNValidMonths = new DevExpress.XtraEditors.TextEdit();
			this.mdPKG_txtMListPrice = new DevExpress.XtraEditors.TextEdit();
			this.mdPKG_txtStrReceiptDesc = new DevExpress.XtraEditors.TextEdit();
			this.mdPKG_txtStrDescription = new DevExpress.XtraEditors.TextEdit();
			this.mdPKG_dtValidEnd = new DevExpress.XtraEditors.DateEdit();
			this.mdPKG_dtValidStart = new DevExpress.XtraEditors.DateEdit();
			this.grpMDPackageBelow2 = new DevExpress.XtraEditors.PanelControl();
			this.mdPKG_fStudentPackage = new DevExpress.XtraEditors.CheckEdit();
			this.mdPKG_fNoRestrictionUpgrade = new DevExpress.XtraEditors.CheckEdit();
			this.mdPKG_fPeak = new DevExpress.XtraEditors.CheckEdit();
			this.mdPKG_fGIRO = new DevExpress.XtraEditors.CheckEdit();
			this.mdPKG_lblNStatus = new System.Windows.Forms.Label();
			this.mdPKG_lblNWarrantyMonths = new System.Windows.Forms.Label();
			this.mdPKG_lvlNValidMonths = new System.Windows.Forms.Label();
			this.mdPKG_lbldtValidEnd = new System.Windows.Forms.Label();
			this.mdPKG_lbldtValidStart = new System.Windows.Forms.Label();
			this.mdPKG_lblMBaseUnitPrice = new System.Windows.Forms.Label();
			this.mdPKG_lblNPackageDuration = new System.Windows.Forms.Label();
			this.mdPKG_lblNMaxSession = new System.Windows.Forms.Label();
			this.mdPKG_lblMListPrice = new System.Windows.Forms.Label();
			this.mdPKG_lblStrReceiptDesc = new System.Windows.Forms.Label();
			this.mdPKG_lblStrDescription = new System.Windows.Forms.Label();
			this.mdPKG_lblStrPackageCode = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.groupHdrMd_Promotion)).BeginInit();
			this.groupHdrMd_Promotion.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpMDPackageBelow1)).BeginInit();
			this.grpMDPackageBelow1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mdpkg_txtNCategoryID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtStrPackageCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_cbNStatus.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtNPackageDuration.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtMBaseUnitPrice.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtNMaxSession.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtNWarrantyMonths.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtNValidMonths.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtMListPrice.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtStrReceiptDesc.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtStrDescription.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_dtValidEnd.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_dtValidStart.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grpMDPackageBelow2)).BeginInit();
			this.grpMDPackageBelow2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_fStudentPackage.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_fNoRestrictionUpgrade.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_fPeak.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_fGIRO.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// groupHdrMd_Promotion
			// 
			this.groupHdrMd_Promotion.Appearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.groupHdrMd_Promotion.Appearance.Options.UseBackColor = true;
			this.groupHdrMd_Promotion.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.groupHdrMd_Promotion.Controls.Add(this.hdrMd_Package);
			this.groupHdrMd_Promotion.Location = new System.Drawing.Point(0, 0);
			this.groupHdrMd_Promotion.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.groupHdrMd_Promotion.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupHdrMd_Promotion.Name = "groupHdrMd_Promotion";
			this.groupHdrMd_Promotion.Size = new System.Drawing.Size(616, 32);
			this.groupHdrMd_Promotion.TabIndex = 5;
			this.groupHdrMd_Promotion.Text = "groupControl1";
			// 
			// hdrMd_Package
			// 
			this.hdrMd_Package.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.hdrMd_Package.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.hdrMd_Package.Location = new System.Drawing.Point(8, 8);
			this.hdrMd_Package.Name = "hdrMd_Package";
			this.hdrMd_Package.Size = new System.Drawing.Size(600, 23);
			this.hdrMd_Package.TabIndex = 1;
			this.hdrMd_Package.Text = "AMORE PACKAGE MASTER SETUP";
			this.hdrMd_Package.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// grpMDPackageBelow1
			// 
			this.grpMDPackageBelow1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_lblStrPackageCategory);
			this.grpMDPackageBelow1.Controls.Add(this.mdpkg_txtNCategoryID);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_txtStrPackageCode);
			this.grpMDPackageBelow1.Controls.Add(this.btnPackageDelete);
			this.grpMDPackageBelow1.Controls.Add(this.btnPackageCancel);
			this.grpMDPackageBelow1.Controls.Add(this.btnPackageUpdate);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_cbNStatus);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_txtNPackageDuration);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_txtMBaseUnitPrice);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_txtNMaxSession);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_txtNWarrantyMonths);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_txtNValidMonths);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_txtMListPrice);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_txtStrReceiptDesc);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_txtStrDescription);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_dtValidEnd);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_dtValidStart);
			this.grpMDPackageBelow1.Controls.Add(this.grpMDPackageBelow2);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_lblNStatus);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_lblNWarrantyMonths);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_lvlNValidMonths);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_lbldtValidEnd);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_lbldtValidStart);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_lblMBaseUnitPrice);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_lblNPackageDuration);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_lblNMaxSession);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_lblMListPrice);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_lblStrReceiptDesc);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_lblStrDescription);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_lblStrPackageCode);
			this.grpMDPackageBelow1.Location = new System.Drawing.Point(0, 32);
			this.grpMDPackageBelow1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.grpMDPackageBelow1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpMDPackageBelow1.Name = "grpMDPackageBelow1";
			this.grpMDPackageBelow1.ShowCaption = false;
			this.grpMDPackageBelow1.Size = new System.Drawing.Size(624, 328);
			this.grpMDPackageBelow1.TabIndex = 6;
			this.grpMDPackageBelow1.Text = "groupControl1";
			// 
			// mdPKG_lblStrPackageCategory
			// 
			this.mdPKG_lblStrPackageCategory.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lblStrPackageCategory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lblStrPackageCategory.Location = new System.Drawing.Point(264, 16);
			this.mdPKG_lblStrPackageCategory.Name = "mdPKG_lblStrPackageCategory";
			this.mdPKG_lblStrPackageCategory.Size = new System.Drawing.Size(112, 16);
			this.mdPKG_lblStrPackageCategory.TabIndex = 164;
			this.mdPKG_lblStrPackageCategory.Text = "Package Category";
			this.mdPKG_lblStrPackageCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mdpkg_txtNCategoryID
			// 
			this.mdpkg_txtNCategoryID.EditValue = "";
			this.mdpkg_txtNCategoryID.Location = new System.Drawing.Point(384, 16);
			this.mdpkg_txtNCategoryID.Name = "mdpkg_txtNCategoryID";
			// 
			// mdpkg_txtNCategoryID.Properties
			// 
			this.mdpkg_txtNCategoryID.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdpkg_txtNCategoryID.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdpkg_txtNCategoryID.Size = new System.Drawing.Size(104, 20);
			this.mdpkg_txtNCategoryID.TabIndex = 163;
			// 
			// mdPKG_txtStrPackageCode
			// 
			this.mdPKG_txtStrPackageCode.EditValue = "";
			this.mdPKG_txtStrPackageCode.Location = new System.Drawing.Point(144, 16);
			this.mdPKG_txtStrPackageCode.Name = "mdPKG_txtStrPackageCode";
			// 
			// mdPKG_txtStrPackageCode.Properties
			// 
			this.mdPKG_txtStrPackageCode.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdPKG_txtStrPackageCode.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdPKG_txtStrPackageCode.Size = new System.Drawing.Size(104, 20);
			this.mdPKG_txtStrPackageCode.TabIndex = 162;
			// 
			// btnPackageDelete
			// 
			this.btnPackageDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnPackageDelete.Location = new System.Drawing.Point(104, 240);
			this.btnPackageDelete.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.btnPackageDelete.LookAndFeel.UseDefaultLookAndFeel = false;
			this.btnPackageDelete.Name = "btnPackageDelete";
			this.btnPackageDelete.TabIndex = 161;
			this.btnPackageDelete.Text = "Delete";
			// 
			// btnPackageCancel
			// 
			this.btnPackageCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnPackageCancel.Location = new System.Drawing.Point(184, 240);
			this.btnPackageCancel.Name = "btnPackageCancel";
			this.btnPackageCancel.TabIndex = 160;
			this.btnPackageCancel.Text = "Cancel";
			this.btnPackageCancel.Click += new System.EventHandler(this.btnPackageCancel_Click);
			// 
			// btnPackageUpdate
			// 
			this.btnPackageUpdate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnPackageUpdate.Location = new System.Drawing.Point(24, 240);
			this.btnPackageUpdate.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.btnPackageUpdate.LookAndFeel.UseDefaultLookAndFeel = false;
			this.btnPackageUpdate.Name = "btnPackageUpdate";
			this.btnPackageUpdate.TabIndex = 159;
			this.btnPackageUpdate.Text = "Save";
			this.btnPackageUpdate.Click += new System.EventHandler(this.btnPackageUpdate_Click);
			// 
			// mdPKG_cbNStatus
			// 
			this.mdPKG_cbNStatus.EditValue = "imageComboBoxEdit2";
			this.mdPKG_cbNStatus.Location = new System.Drawing.Point(472, 136);
			this.mdPKG_cbNStatus.Name = "mdPKG_cbNStatus";
			// 
			// mdPKG_cbNStatus.Properties
			// 
			this.mdPKG_cbNStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.mdPKG_cbNStatus.Properties.Items.AddRange(new object[] {
																			new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Active", 1, -1),
																			new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Deleted", 2, -1)});
			this.mdPKG_cbNStatus.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdPKG_cbNStatus.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdPKG_cbNStatus.Size = new System.Drawing.Size(96, 20);
			this.mdPKG_cbNStatus.TabIndex = 158;
			// 
			// mdPKG_txtNPackageDuration
			// 
			this.mdPKG_txtNPackageDuration.EditValue = "";
			this.mdPKG_txtNPackageDuration.Location = new System.Drawing.Point(144, 160);
			this.mdPKG_txtNPackageDuration.Name = "mdPKG_txtNPackageDuration";
			// 
			// mdPKG_txtNPackageDuration.Properties
			// 
			this.mdPKG_txtNPackageDuration.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdPKG_txtNPackageDuration.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdPKG_txtNPackageDuration.Properties.Mask.EditMask = "#######0";
			this.mdPKG_txtNPackageDuration.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.mdPKG_txtNPackageDuration.Size = new System.Drawing.Size(75, 20);
			this.mdPKG_txtNPackageDuration.TabIndex = 157;
			// 
			// mdPKG_txtMBaseUnitPrice
			// 
			this.mdPKG_txtMBaseUnitPrice.EditValue = "";
			this.mdPKG_txtMBaseUnitPrice.Location = new System.Drawing.Point(216, 208);
			this.mdPKG_txtMBaseUnitPrice.Name = "mdPKG_txtMBaseUnitPrice";
			// 
			// mdPKG_txtMBaseUnitPrice.Properties
			// 
			this.mdPKG_txtMBaseUnitPrice.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdPKG_txtMBaseUnitPrice.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdPKG_txtMBaseUnitPrice.Properties.Mask.EditMask = "#####0.00";
			this.mdPKG_txtMBaseUnitPrice.Size = new System.Drawing.Size(75, 20);
			this.mdPKG_txtMBaseUnitPrice.TabIndex = 156;
			// 
			// mdPKG_txtNMaxSession
			// 
			this.mdPKG_txtNMaxSession.EditValue = "";
			this.mdPKG_txtNMaxSession.Location = new System.Drawing.Point(216, 184);
			this.mdPKG_txtNMaxSession.Name = "mdPKG_txtNMaxSession";
			// 
			// mdPKG_txtNMaxSession.Properties
			// 
			this.mdPKG_txtNMaxSession.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdPKG_txtNMaxSession.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdPKG_txtNMaxSession.Properties.Mask.EditMask = "###0";
			this.mdPKG_txtNMaxSession.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.mdPKG_txtNMaxSession.Size = new System.Drawing.Size(75, 20);
			this.mdPKG_txtNMaxSession.TabIndex = 155;
			// 
			// mdPKG_txtNWarrantyMonths
			// 
			this.mdPKG_txtNWarrantyMonths.EditValue = "";
			this.mdPKG_txtNWarrantyMonths.Location = new System.Drawing.Point(144, 136);
			this.mdPKG_txtNWarrantyMonths.Name = "mdPKG_txtNWarrantyMonths";
			// 
			// mdPKG_txtNWarrantyMonths.Properties
			// 
			this.mdPKG_txtNWarrantyMonths.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdPKG_txtNWarrantyMonths.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdPKG_txtNWarrantyMonths.Properties.Mask.EditMask = "#0";
			this.mdPKG_txtNWarrantyMonths.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.mdPKG_txtNWarrantyMonths.Size = new System.Drawing.Size(75, 20);
			this.mdPKG_txtNWarrantyMonths.TabIndex = 154;
			// 
			// mdPKG_txtNValidMonths
			// 
			this.mdPKG_txtNValidMonths.EditValue = "";
			this.mdPKG_txtNValidMonths.Location = new System.Drawing.Point(144, 112);
			this.mdPKG_txtNValidMonths.Name = "mdPKG_txtNValidMonths";
			// 
			// mdPKG_txtNValidMonths.Properties
			// 
			this.mdPKG_txtNValidMonths.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdPKG_txtNValidMonths.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdPKG_txtNValidMonths.Properties.Mask.EditMask = "#0";
			this.mdPKG_txtNValidMonths.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.mdPKG_txtNValidMonths.Size = new System.Drawing.Size(75, 20);
			this.mdPKG_txtNValidMonths.TabIndex = 153;
			// 
			// mdPKG_txtMListPrice
			// 
			this.mdPKG_txtMListPrice.EditValue = "";
			this.mdPKG_txtMListPrice.Location = new System.Drawing.Point(144, 88);
			this.mdPKG_txtMListPrice.Name = "mdPKG_txtMListPrice";
			// 
			// mdPKG_txtMListPrice.Properties
			// 
			this.mdPKG_txtMListPrice.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdPKG_txtMListPrice.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdPKG_txtMListPrice.Properties.Mask.EditMask = "#####0.00";
			this.mdPKG_txtMListPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.mdPKG_txtMListPrice.Size = new System.Drawing.Size(75, 20);
			this.mdPKG_txtMListPrice.TabIndex = 152;
			// 
			// mdPKG_txtStrReceiptDesc
			// 
			this.mdPKG_txtStrReceiptDesc.EditValue = "";
			this.mdPKG_txtStrReceiptDesc.Location = new System.Drawing.Point(144, 64);
			this.mdPKG_txtStrReceiptDesc.Name = "mdPKG_txtStrReceiptDesc";
			// 
			// mdPKG_txtStrReceiptDesc.Properties
			// 
			this.mdPKG_txtStrReceiptDesc.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdPKG_txtStrReceiptDesc.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdPKG_txtStrReceiptDesc.Size = new System.Drawing.Size(424, 20);
			this.mdPKG_txtStrReceiptDesc.TabIndex = 151;
			// 
			// mdPKG_txtStrDescription
			// 
			this.mdPKG_txtStrDescription.EditValue = "";
			this.mdPKG_txtStrDescription.Location = new System.Drawing.Point(144, 40);
			this.mdPKG_txtStrDescription.Name = "mdPKG_txtStrDescription";
			// 
			// mdPKG_txtStrDescription.Properties
			// 
			this.mdPKG_txtStrDescription.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdPKG_txtStrDescription.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdPKG_txtStrDescription.Size = new System.Drawing.Size(424, 20);
			this.mdPKG_txtStrDescription.TabIndex = 150;
			// 
			// mdPKG_dtValidEnd
			// 
			this.mdPKG_dtValidEnd.EditValue = new System.DateTime(2005, 12, 28, 0, 0, 0, 0);
			this.mdPKG_dtValidEnd.Location = new System.Drawing.Point(472, 112);
			this.mdPKG_dtValidEnd.Name = "mdPKG_dtValidEnd";
			// 
			// mdPKG_dtValidEnd.Properties
			// 
			this.mdPKG_dtValidEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.mdPKG_dtValidEnd.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdPKG_dtValidEnd.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdPKG_dtValidEnd.Size = new System.Drawing.Size(96, 20);
			this.mdPKG_dtValidEnd.TabIndex = 149;
			// 
			// mdPKG_dtValidStart
			// 
			this.mdPKG_dtValidStart.EditValue = new System.DateTime(2005, 12, 28, 0, 0, 0, 0);
			this.mdPKG_dtValidStart.Location = new System.Drawing.Point(472, 88);
			this.mdPKG_dtValidStart.Name = "mdPKG_dtValidStart";
			// 
			// mdPKG_dtValidStart.Properties
			// 
			this.mdPKG_dtValidStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.mdPKG_dtValidStart.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdPKG_dtValidStart.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdPKG_dtValidStart.Size = new System.Drawing.Size(96, 20);
			this.mdPKG_dtValidStart.TabIndex = 148;
			// 
			// grpMDPackageBelow2
			// 
			this.grpMDPackageBelow2.Controls.Add(this.mdPKG_fStudentPackage);
			this.grpMDPackageBelow2.Controls.Add(this.mdPKG_fNoRestrictionUpgrade);
			this.grpMDPackageBelow2.Controls.Add(this.mdPKG_fPeak);
			this.grpMDPackageBelow2.Controls.Add(this.mdPKG_fGIRO);
			this.grpMDPackageBelow2.Location = new System.Drawing.Point(336, 160);
			this.grpMDPackageBelow2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.grpMDPackageBelow2.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpMDPackageBelow2.Name = "grpMDPackageBelow2";
			this.grpMDPackageBelow2.Size = new System.Drawing.Size(232, 112);
			this.grpMDPackageBelow2.TabIndex = 146;
			this.grpMDPackageBelow2.Text = "panelControl2";
			// 
			// mdPKG_fStudentPackage
			// 
			this.mdPKG_fStudentPackage.Location = new System.Drawing.Point(8, 80);
			this.mdPKG_fStudentPackage.Name = "mdPKG_fStudentPackage";
			// 
			// mdPKG_fStudentPackage.Properties
			// 
			this.mdPKG_fStudentPackage.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_fStudentPackage.Properties.Appearance.Options.UseFont = true;
			this.mdPKG_fStudentPackage.Properties.Caption = "Student Package ?";
			this.mdPKG_fStudentPackage.Size = new System.Drawing.Size(184, 19);
			this.mdPKG_fStudentPackage.TabIndex = 3;
			// 
			// mdPKG_fNoRestrictionUpgrade
			// 
			this.mdPKG_fNoRestrictionUpgrade.Location = new System.Drawing.Point(8, 56);
			this.mdPKG_fNoRestrictionUpgrade.Name = "mdPKG_fNoRestrictionUpgrade";
			// 
			// mdPKG_fNoRestrictionUpgrade.Properties
			// 
			this.mdPKG_fNoRestrictionUpgrade.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_fNoRestrictionUpgrade.Properties.Appearance.Options.UseFont = true;
			this.mdPKG_fNoRestrictionUpgrade.Properties.Caption = "Allowed For Upgrading ?";
			this.mdPKG_fNoRestrictionUpgrade.Size = new System.Drawing.Size(184, 19);
			this.mdPKG_fNoRestrictionUpgrade.TabIndex = 2;
			// 
			// mdPKG_fPeak
			// 
			this.mdPKG_fPeak.Location = new System.Drawing.Point(8, 32);
			this.mdPKG_fPeak.Name = "mdPKG_fPeak";
			// 
			// mdPKG_fPeak.Properties
			// 
			this.mdPKG_fPeak.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_fPeak.Properties.Appearance.Options.UseFont = true;
			this.mdPKG_fPeak.Properties.Caption = "Allowed For Peak Period Used ?";
			this.mdPKG_fPeak.Size = new System.Drawing.Size(200, 19);
			this.mdPKG_fPeak.TabIndex = 1;
			// 
			// mdPKG_fGIRO
			// 
			this.mdPKG_fGIRO.Location = new System.Drawing.Point(8, 8);
			this.mdPKG_fGIRO.Name = "mdPKG_fGIRO";
			// 
			// mdPKG_fGIRO.Properties
			// 
			this.mdPKG_fGIRO.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_fGIRO.Properties.Appearance.Options.UseFont = true;
			this.mdPKG_fGIRO.Properties.Caption = "Allowed For Giro ?";
			this.mdPKG_fGIRO.Size = new System.Drawing.Size(120, 19);
			this.mdPKG_fGIRO.TabIndex = 0;
			// 
			// mdPKG_lblNStatus
			// 
			this.mdPKG_lblNStatus.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lblNStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lblNStatus.Location = new System.Drawing.Point(336, 136);
			this.mdPKG_lblNStatus.Name = "mdPKG_lblNStatus";
			this.mdPKG_lblNStatus.Size = new System.Drawing.Size(64, 16);
			this.mdPKG_lblNStatus.TabIndex = 145;
			this.mdPKG_lblNStatus.Text = "Status";
			this.mdPKG_lblNStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mdPKG_lblNWarrantyMonths
			// 
			this.mdPKG_lblNWarrantyMonths.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lblNWarrantyMonths.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lblNWarrantyMonths.Location = new System.Drawing.Point(24, 136);
			this.mdPKG_lblNWarrantyMonths.Name = "mdPKG_lblNWarrantyMonths";
			this.mdPKG_lblNWarrantyMonths.Size = new System.Drawing.Size(120, 16);
			this.mdPKG_lblNWarrantyMonths.TabIndex = 142;
			this.mdPKG_lblNWarrantyMonths.Text = "Warranty Month #";
			this.mdPKG_lblNWarrantyMonths.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mdPKG_lvlNValidMonths
			// 
			this.mdPKG_lvlNValidMonths.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lvlNValidMonths.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lvlNValidMonths.Location = new System.Drawing.Point(24, 112);
			this.mdPKG_lvlNValidMonths.Name = "mdPKG_lvlNValidMonths";
			this.mdPKG_lvlNValidMonths.Size = new System.Drawing.Size(120, 16);
			this.mdPKG_lvlNValidMonths.TabIndex = 141;
			this.mdPKG_lvlNValidMonths.Text = "Validity In Month";
			this.mdPKG_lvlNValidMonths.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mdPKG_lbldtValidEnd
			// 
			this.mdPKG_lbldtValidEnd.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lbldtValidEnd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lbldtValidEnd.Location = new System.Drawing.Point(336, 112);
			this.mdPKG_lbldtValidEnd.Name = "mdPKG_lbldtValidEnd";
			this.mdPKG_lbldtValidEnd.Size = new System.Drawing.Size(128, 16);
			this.mdPKG_lbldtValidEnd.TabIndex = 139;
			this.mdPKG_lbldtValidEnd.Text = "Effective End Date";
			this.mdPKG_lbldtValidEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mdPKG_lbldtValidStart
			// 
			this.mdPKG_lbldtValidStart.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lbldtValidStart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lbldtValidStart.Location = new System.Drawing.Point(336, 88);
			this.mdPKG_lbldtValidStart.Name = "mdPKG_lbldtValidStart";
			this.mdPKG_lbldtValidStart.Size = new System.Drawing.Size(128, 16);
			this.mdPKG_lbldtValidStart.TabIndex = 138;
			this.mdPKG_lbldtValidStart.Text = "Effective Start Start";
			this.mdPKG_lbldtValidStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mdPKG_lblMBaseUnitPrice
			// 
			this.mdPKG_lblMBaseUnitPrice.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lblMBaseUnitPrice.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lblMBaseUnitPrice.Location = new System.Drawing.Point(24, 208);
			this.mdPKG_lblMBaseUnitPrice.Name = "mdPKG_lblMBaseUnitPrice";
			this.mdPKG_lblMBaseUnitPrice.Size = new System.Drawing.Size(160, 16);
			this.mdPKG_lblMBaseUnitPrice.TabIndex = 137;
			this.mdPKG_lblMBaseUnitPrice.Text = "Base Unit Price Per Session";
			this.mdPKG_lblMBaseUnitPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mdPKG_lblNPackageDuration
			// 
			this.mdPKG_lblNPackageDuration.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lblNPackageDuration.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lblNPackageDuration.Location = new System.Drawing.Point(24, 160);
			this.mdPKG_lblNPackageDuration.Name = "mdPKG_lblNPackageDuration";
			this.mdPKG_lblNPackageDuration.Size = new System.Drawing.Size(120, 16);
			this.mdPKG_lblNPackageDuration.TabIndex = 136;
			this.mdPKG_lblNPackageDuration.Text = "Package Duration";
			this.mdPKG_lblNPackageDuration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mdPKG_lblNMaxSession
			// 
			this.mdPKG_lblNMaxSession.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lblNMaxSession.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lblNMaxSession.Location = new System.Drawing.Point(24, 184);
			this.mdPKG_lblNMaxSession.Name = "mdPKG_lblNMaxSession";
			this.mdPKG_lblNMaxSession.Size = new System.Drawing.Size(176, 16);
			this.mdPKG_lblNMaxSession.TabIndex = 135;
			this.mdPKG_lblNMaxSession.Text = "Max Session in one package";
			this.mdPKG_lblNMaxSession.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mdPKG_lblMListPrice
			// 
			this.mdPKG_lblMListPrice.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lblMListPrice.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lblMListPrice.Location = new System.Drawing.Point(24, 88);
			this.mdPKG_lblMListPrice.Name = "mdPKG_lblMListPrice";
			this.mdPKG_lblMListPrice.Size = new System.Drawing.Size(120, 16);
			this.mdPKG_lblMListPrice.TabIndex = 134;
			this.mdPKG_lblMListPrice.Text = "Package Price";
			this.mdPKG_lblMListPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mdPKG_lblStrReceiptDesc
			// 
			this.mdPKG_lblStrReceiptDesc.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lblStrReceiptDesc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lblStrReceiptDesc.Location = new System.Drawing.Point(24, 64);
			this.mdPKG_lblStrReceiptDesc.Name = "mdPKG_lblStrReceiptDesc";
			this.mdPKG_lblStrReceiptDesc.Size = new System.Drawing.Size(120, 16);
			this.mdPKG_lblStrReceiptDesc.TabIndex = 133;
			this.mdPKG_lblStrReceiptDesc.Text = "Receipt Description";
			this.mdPKG_lblStrReceiptDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mdPKG_lblStrDescription
			// 
			this.mdPKG_lblStrDescription.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lblStrDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lblStrDescription.Location = new System.Drawing.Point(24, 40);
			this.mdPKG_lblStrDescription.Name = "mdPKG_lblStrDescription";
			this.mdPKG_lblStrDescription.Size = new System.Drawing.Size(96, 16);
			this.mdPKG_lblStrDescription.TabIndex = 132;
			this.mdPKG_lblStrDescription.Text = "Description";
			this.mdPKG_lblStrDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mdPKG_lblStrPackageCode
			// 
			this.mdPKG_lblStrPackageCode.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lblStrPackageCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lblStrPackageCode.Location = new System.Drawing.Point(24, 16);
			this.mdPKG_lblStrPackageCode.Name = "mdPKG_lblStrPackageCode";
			this.mdPKG_lblStrPackageCode.Size = new System.Drawing.Size(96, 16);
			this.mdPKG_lblStrPackageCode.TabIndex = 131;
			this.mdPKG_lblStrPackageCode.Text = "Package Code";
			this.mdPKG_lblStrPackageCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmMd_Package
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(656, 349);
			this.Controls.Add(this.grpMDPackageBelow1);
			this.Controls.Add(this.groupHdrMd_Promotion);
			this.Name = "frmMd_Package";
			this.Text = "Package .....";
			((System.ComponentModel.ISupportInitialize)(this.groupHdrMd_Promotion)).EndInit();
			this.groupHdrMd_Promotion.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grpMDPackageBelow1)).EndInit();
			this.grpMDPackageBelow1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mdpkg_txtNCategoryID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtStrPackageCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_cbNStatus.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtNPackageDuration.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtMBaseUnitPrice.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtNMaxSession.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtNWarrantyMonths.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtNValidMonths.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtMListPrice.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtStrReceiptDesc.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtStrDescription.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_dtValidEnd.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_dtValidStart.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grpMDPackageBelow2)).EndInit();
			this.grpMDPackageBelow2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_fStudentPackage.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_fNoRestrictionUpgrade.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_fPeak.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_fGIRO.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void init()
		{
			clear();
			bind();
		}

		private void bind()
		{
			this.mdPKG_cbNStatus.DataBindings.Add("EditValue",dtPackage,"nStatus");
			this.mdPKG_dtValidEnd.DataBindings.Add("EditValue",dtPackage,"dtValidEnd");
			this.mdPKG_dtValidStart.DataBindings.Add("EditValue",dtPackage,"dtValidStart");
			this.mdPKG_fGIRO.DataBindings.Add("EditValue",dtPackage,"fGIRO");
			this.mdPKG_fNoRestrictionUpgrade.DataBindings.Add("EditValue",dtPackage,"fNoRestrictionUpgrade");
			this.mdPKG_fPeak.DataBindings.Add("EditValue",dtPackage,"fPeak");
			this.mdPKG_fStudentPackage.DataBindings.Add("EditValue",dtPackage,"fStudentPackage");
			this.mdPKG_txtMBaseUnitPrice.DataBindings.Add("EditValue",dtPackage,"MBaseUnitPrice");
			this.mdPKG_txtMListPrice.DataBindings.Add("EditValue",dtPackage,"mListPrice");
			this.mdPKG_txtNMaxSession.DataBindings.Add("EditValue",dtPackage,"nMaxSession");
			this.mdPKG_txtNPackageDuration.DataBindings.Add("EditValue",dtPackage,"nPackageDuration");
			this.mdPKG_txtNValidMonths.DataBindings.Add("EditValue",dtPackage,"nValidMonths");
			this.mdPKG_txtNWarrantyMonths.DataBindings.Add("EditValue",dtPackage,"nWarrantyMonths");
			this.mdPKG_txtStrDescription.DataBindings.Add("EditValue",dtPackage,"strDescription");
			this.mdPKG_txtStrPackageCode.DataBindings.Add("EditValue",dtPackage,"strPackageCode");
			this.mdPKG_txtStrReceiptDesc.DataBindings.Add("EditValue",dtPackage,"strReceiptDesc");
		}

		private void clear()
		{
			this.mdPKG_cbNStatus.Text = "";
			this.mdPKG_dtValidEnd.Text = "";
			this.mdPKG_dtValidStart.Text = "";
			this.mdPKG_fGIRO.Checked = false;
			this.mdPKG_fNoRestrictionUpgrade.Checked = false;
			this.mdPKG_fPeak.Checked = false;
			this.mdPKG_fStudentPackage.Checked = false;
			this.mdPKG_txtMBaseUnitPrice.Text = "";
			this.mdPKG_txtMListPrice.Text = "";
			this.mdPKG_txtNMaxSession.Text = "";
			this.mdPKG_txtNPackageDuration.Text = "";
			this.mdPKG_txtNValidMonths.Text = "";
			this.mdPKG_txtNWarrantyMonths.Text = "";
			this.mdPKG_txtStrDescription.Text = "";
			this.mdPKG_txtStrPackageCode.Text = "";
			this.mdPKG_txtStrReceiptDesc.Text = "";
		}

		private void btnPackageCancel_Click(object sender, System.EventArgs e)
		{
			this.Dispose(true);
		}

		private void btnPackageUpdate_Click(object sender, System.EventArgs e)
		{
			int output;
			output = 0;
			if (this.command=='I')
			{
				SqlHelper.ExecuteNonQuery(connection,"UP_tblPackage",
					new SqlParameter("@RET_VAL",output),
					new SqlParameter("@cmd","I"),
					new SqlParameter("@strPackageCode",this.mdPKG_txtStrPackageCode.EditValue.ToString() ),
					new SqlParameter("@strDescription",this.mdPKG_txtStrDescription.EditValue.ToString() ),
					new SqlParameter("@strReceiptDesc",this.mdPKG_txtStrReceiptDesc.EditValue.ToString() ),
					new SqlParameter("@mListPrice",Convert.ToDecimal(this.mdPKG_txtMListPrice.EditValue) ),
					new SqlParameter("@nMaxSession",Convert.ToInt32(this.mdPKG_txtNMaxSession.EditValue) ),
					new SqlParameter("@nPackageDuration",Convert.ToInt32(this.mdPKG_txtNPackageDuration.EditValue) ),
					new SqlParameter("@mBaseUnitPrice",Convert.ToDecimal(this.mdPKG_txtMBaseUnitPrice.EditValue) ),
					new SqlParameter("@dtValidStart",Convert.ToDateTime(this.mdPKG_dtValidStart.EditValue) ),
					new SqlParameter("@dtValidEnd",Convert.ToDateTime(this.mdPKG_dtValidEnd.EditValue) ),
					new SqlParameter("@fPeak",Convert.ToBoolean(this.mdPKG_fPeak.EditValue) ),
					new SqlParameter("@fStudentPackage",Convert.ToBoolean(this.mdPKG_fStudentPackage.EditValue) ),
					new SqlParameter("@nCategoryID",Convert.ToInt32(this.mdpkg_txtNCategoryID.EditValue) ),
					new SqlParameter("@nValidMonths",Convert.ToBoolean(this.mdPKG_txtNValidMonths.EditValue) ),
					new SqlParameter("@fGIRO",Convert.ToBoolean(this.mdPKG_fGIRO.EditValue) ),
					new SqlParameter("@fNoRestrictionUpgrade",Convert.ToBoolean(this.mdPKG_fNoRestrictionUpgrade.EditValue) ),
					new SqlParameter("@nStatus",Convert.ToInt32(this.mdPKG_cbNStatus.EditValue) )

					);


			}
		}
	}
}
