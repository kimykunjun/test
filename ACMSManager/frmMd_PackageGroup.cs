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
	/// Summary description for frmMd_PackageGroup.
	/// </summary>
	public class frmMd_PackageGroup : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		char cmd;
		private DevExpress.XtraEditors.GroupControl grpMDPackageBelow1;
		private System.Windows.Forms.Label mdPKG_lblStrPackageCategory;
		private DevExpress.XtraEditors.TextEdit mdpkg_txtNCategoryID;
		private DevExpress.XtraEditors.TextEdit mdPKG_txtStrPackageCode;
		private DevExpress.XtraEditors.TextEdit mdPKG_txtMListPrice;
		private DevExpress.XtraEditors.TextEdit mdPKG_txtStrDescription;
		private DevExpress.XtraEditors.DateEdit mdPKG_dtValidEnd;
		private DevExpress.XtraEditors.DateEdit mdPKG_dtValidStart;
		private System.Windows.Forms.Label mdPKG_lbldtValidEnd;
		private System.Windows.Forms.Label mdPKG_lbldtValidStart;
		private System.Windows.Forms.Label mdPKG_lblMListPrice;
		private System.Windows.Forms.Label mdPKG_lblStrDescription;
		private System.Windows.Forms.Label mdPKG_lblStrPackageCode;
		private DevExpress.XtraEditors.GroupControl groupHdrMd_Promotion;
		private System.Windows.Forms.Label hdrMd_Package;
		private DevExpress.XtraEditors.SimpleButton btnPackageGrpDelete;
		private DevExpress.XtraEditors.SimpleButton btnPackageGrpCancel;
		private DevExpress.XtraEditors.SimpleButton btnPackageGrpUpdate;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

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
		public DataTable dtPackageGroup
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


		public frmMd_PackageGroup(char cmd)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.command = cmd;
			init();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public frmMd_PackageGroup(char cmd, DataTable pkg)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.command = cmd;
			this.command = cmd;
			this.dtPackageGroup = pkg;
			init();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
			this.grpMDPackageBelow1 = new DevExpress.XtraEditors.GroupControl();
			this.mdPKG_lblStrPackageCategory = new System.Windows.Forms.Label();
			this.mdpkg_txtNCategoryID = new DevExpress.XtraEditors.TextEdit();
			this.mdPKG_txtStrPackageCode = new DevExpress.XtraEditors.TextEdit();
			this.btnPackageGrpDelete = new DevExpress.XtraEditors.SimpleButton();
			this.btnPackageGrpCancel = new DevExpress.XtraEditors.SimpleButton();
			this.btnPackageGrpUpdate = new DevExpress.XtraEditors.SimpleButton();
			this.mdPKG_txtMListPrice = new DevExpress.XtraEditors.TextEdit();
			this.mdPKG_txtStrDescription = new DevExpress.XtraEditors.TextEdit();
			this.mdPKG_dtValidEnd = new DevExpress.XtraEditors.DateEdit();
			this.mdPKG_dtValidStart = new DevExpress.XtraEditors.DateEdit();
			this.mdPKG_lbldtValidEnd = new System.Windows.Forms.Label();
			this.mdPKG_lbldtValidStart = new System.Windows.Forms.Label();
			this.mdPKG_lblMListPrice = new System.Windows.Forms.Label();
			this.mdPKG_lblStrDescription = new System.Windows.Forms.Label();
			this.mdPKG_lblStrPackageCode = new System.Windows.Forms.Label();
			this.groupHdrMd_Promotion = new DevExpress.XtraEditors.GroupControl();
			this.hdrMd_Package = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.grpMDPackageBelow1)).BeginInit();
			this.grpMDPackageBelow1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mdpkg_txtNCategoryID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtStrPackageCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtMListPrice.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtStrDescription.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_dtValidEnd.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_dtValidStart.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupHdrMd_Promotion)).BeginInit();
			this.groupHdrMd_Promotion.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpMDPackageBelow1
			// 
			this.grpMDPackageBelow1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_lblStrPackageCategory);
			this.grpMDPackageBelow1.Controls.Add(this.mdpkg_txtNCategoryID);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_txtStrPackageCode);
			this.grpMDPackageBelow1.Controls.Add(this.btnPackageGrpDelete);
			this.grpMDPackageBelow1.Controls.Add(this.btnPackageGrpCancel);
			this.grpMDPackageBelow1.Controls.Add(this.btnPackageGrpUpdate);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_txtMListPrice);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_txtStrDescription);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_dtValidEnd);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_dtValidStart);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_lbldtValidEnd);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_lbldtValidStart);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_lblMListPrice);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_lblStrDescription);
			this.grpMDPackageBelow1.Controls.Add(this.mdPKG_lblStrPackageCode);
			this.grpMDPackageBelow1.Location = new System.Drawing.Point(0, 32);
			this.grpMDPackageBelow1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.grpMDPackageBelow1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpMDPackageBelow1.Name = "grpMDPackageBelow1";
			this.grpMDPackageBelow1.ShowCaption = false;
			this.grpMDPackageBelow1.Size = new System.Drawing.Size(616, 208);
			this.grpMDPackageBelow1.TabIndex = 8;
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
			this.mdPKG_txtStrPackageCode.Location = new System.Drawing.Point(160, 16);
			this.mdPKG_txtStrPackageCode.Name = "mdPKG_txtStrPackageCode";
			// 
			// mdPKG_txtStrPackageCode.Properties
			// 
			this.mdPKG_txtStrPackageCode.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdPKG_txtStrPackageCode.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdPKG_txtStrPackageCode.Size = new System.Drawing.Size(96, 20);
			this.mdPKG_txtStrPackageCode.TabIndex = 162;
			// 
			// btnPackageGrpDelete
			// 
			this.btnPackageGrpDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnPackageGrpDelete.Location = new System.Drawing.Point(104, 160);
			this.btnPackageGrpDelete.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.btnPackageGrpDelete.LookAndFeel.UseDefaultLookAndFeel = false;
			this.btnPackageGrpDelete.Name = "btnPackageGrpDelete";
			this.btnPackageGrpDelete.Size = new System.Drawing.Size(75, 24);
			this.btnPackageGrpDelete.TabIndex = 161;
			this.btnPackageGrpDelete.Text = "Delete";
			// 
			// btnPackageGrpCancel
			// 
			this.btnPackageGrpCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnPackageGrpCancel.Location = new System.Drawing.Point(184, 160);
			this.btnPackageGrpCancel.Name = "btnPackageGrpCancel";
			this.btnPackageGrpCancel.Size = new System.Drawing.Size(75, 24);
			this.btnPackageGrpCancel.TabIndex = 160;
			this.btnPackageGrpCancel.Text = "Cancel";
			// 
			// btnPackageGrpUpdate
			// 
			this.btnPackageGrpUpdate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnPackageGrpUpdate.Location = new System.Drawing.Point(24, 160);
			this.btnPackageGrpUpdate.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.btnPackageGrpUpdate.LookAndFeel.UseDefaultLookAndFeel = false;
			this.btnPackageGrpUpdate.Name = "btnPackageGrpUpdate";
			this.btnPackageGrpUpdate.Size = new System.Drawing.Size(75, 24);
			this.btnPackageGrpUpdate.TabIndex = 159;
			this.btnPackageGrpUpdate.Text = "Save";
			// 
			// mdPKG_txtMListPrice
			// 
			this.mdPKG_txtMListPrice.EditValue = "";
			this.mdPKG_txtMListPrice.Location = new System.Drawing.Point(160, 64);
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
			// mdPKG_txtStrDescription
			// 
			this.mdPKG_txtStrDescription.EditValue = "";
			this.mdPKG_txtStrDescription.Location = new System.Drawing.Point(160, 40);
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
			this.mdPKG_dtValidEnd.Location = new System.Drawing.Point(160, 112);
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
			this.mdPKG_dtValidStart.Location = new System.Drawing.Point(160, 88);
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
			// mdPKG_lbldtValidEnd
			// 
			this.mdPKG_lbldtValidEnd.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lbldtValidEnd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lbldtValidEnd.Location = new System.Drawing.Point(24, 112);
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
			this.mdPKG_lbldtValidStart.Location = new System.Drawing.Point(24, 88);
			this.mdPKG_lbldtValidStart.Name = "mdPKG_lbldtValidStart";
			this.mdPKG_lbldtValidStart.Size = new System.Drawing.Size(128, 16);
			this.mdPKG_lbldtValidStart.TabIndex = 138;
			this.mdPKG_lbldtValidStart.Text = "Effective Start Start";
			this.mdPKG_lbldtValidStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mdPKG_lblMListPrice
			// 
			this.mdPKG_lblMListPrice.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lblMListPrice.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lblMListPrice.Location = new System.Drawing.Point(24, 64);
			this.mdPKG_lblMListPrice.Name = "mdPKG_lblMListPrice";
			this.mdPKG_lblMListPrice.Size = new System.Drawing.Size(136, 16);
			this.mdPKG_lblMListPrice.TabIndex = 134;
			this.mdPKG_lblMListPrice.Text = "Package Group Price";
			this.mdPKG_lblMListPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			this.mdPKG_lblStrPackageCode.Size = new System.Drawing.Size(128, 16);
			this.mdPKG_lblStrPackageCode.TabIndex = 131;
			this.mdPKG_lblStrPackageCode.Text = "Package Group Code";
			this.mdPKG_lblStrPackageCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			this.groupHdrMd_Promotion.TabIndex = 7;
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
			this.hdrMd_Package.Text = "AMORE PACKAGE GROUP SETUP";
			this.hdrMd_Package.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmMd_PackageGroup
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(616, 237);
			this.Controls.Add(this.grpMDPackageBelow1);
			this.Controls.Add(this.groupHdrMd_Promotion);
			this.Name = "frmMd_PackageGroup";
			this.Text = "Package Group .....";
			((System.ComponentModel.ISupportInitialize)(this.grpMDPackageBelow1)).EndInit();
			this.grpMDPackageBelow1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mdpkg_txtNCategoryID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtStrPackageCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtMListPrice.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtStrDescription.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_dtValidEnd.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_dtValidStart.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupHdrMd_Promotion)).EndInit();
			this.groupHdrMd_Promotion.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		private void init()
		{
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);

			clear();
			bind();
		}

		private void bind()
		{
			this.mdPKG_dtValidEnd.DataBindings.Add("EditValue",dtPackageGroup,"dtValidEnd");
			this.mdPKG_dtValidStart.DataBindings.Add("EditValue",dtPackageGroup,"dtValidStart");
			this.mdPKG_txtMListPrice.DataBindings.Add("EditValue",dtPackageGroup,"mListPrice");
			this.mdpkg_txtNCategoryID.DataBindings.Add("EditValue",dtPackageGroup,"nCategoryID");
			this.mdPKG_txtStrDescription.DataBindings.Add("EditValue",dtPackageGroup,"strDescription");
			this.mdPKG_txtStrPackageCode.DataBindings.Add("EditValue",dtPackageGroup,"strPackageCode");
			
		}

		private void clear()
		{
			
			this.mdPKG_dtValidEnd.Text = "";
			this.mdPKG_dtValidStart.Text = "";
			this.mdpkg_txtNCategoryID.Text = "";
			this.mdPKG_txtMListPrice.Text = "";
			this.mdPKG_txtStrDescription.Text = "";
			this.mdPKG_txtStrPackageCode.Text = "";
			
		}
		#endregion
	}
}
