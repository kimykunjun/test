using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Data;

namespace ACMS
{
	/// <summary>
	/// Summary description for frmMD_PackageGroupAdd.
	/// </summary>
	public class frmMD_PackageGroupAdd : System.Windows.Forms.Form
	{
		private int nCategoryID;
		private string connectionString;
		private SqlConnection connection;
		private System.Windows.Forms.Label mdPKG_lblStrPackageCategory;
		private DevExpress.XtraEditors.TextEdit mdPKG_txtStrPackageCode;
		private DevExpress.XtraEditors.SimpleButton btnPackageGrpCancel;
		private DevExpress.XtraEditors.SimpleButton btnPackageGrpUpdate;
		private DevExpress.XtraEditors.TextEdit mdPKG_txtMListPrice;
		private DevExpress.XtraEditors.TextEdit mdPKG_txtStrDescription;
		private DevExpress.XtraEditors.DateEdit mdPKG_dtValidEnd;
		private DevExpress.XtraEditors.DateEdit mdPKG_dtValidStart;
		private System.Windows.Forms.Label mdPKG_lbldtValidEnd;
		private System.Windows.Forms.Label mdPKG_lbldtValidStart;
		private System.Windows.Forms.Label mdPKG_lblMListPrice;
		private System.Windows.Forms.Label mdPKG_lblStrDescription;
		private System.Windows.Forms.Label mdPKG_lblStrPackageCode;
		private DevExpress.XtraEditors.TextEdit PackageCategory;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMD_PackageGroupAdd(int CategoryID)
		{
			//
			// Required for Windows Form Designer support
			//
			nCategoryID = CategoryID;
			InitializeComponent();
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
		
			string strSQL = "select * from tblCategory Where nCategoryID = '" + nCategoryID + "'";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt; 
			dt = _ds.Tables["Table"];

			PackageCategory.EditValue = dt.Rows[0]["strDescription"];

	
//			DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox properties = PackageCategory.Properties;
//			properties.Items.BeginUpdate();
//			properties.Items.Clear();
//
//			foreach(DataRow dr in _ds.Tables["Table"].Rows)
//			{
//				//Initialize each item with the display text, value and image index
//				properties.Items.Add( new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr["strDescription"].ToString(), dr["nCategoryID"].ToString(),-1));
//			}
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
			this.mdPKG_lblStrPackageCategory = new System.Windows.Forms.Label();
			this.mdPKG_txtStrPackageCode = new DevExpress.XtraEditors.TextEdit();
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
			this.PackageCategory = new DevExpress.XtraEditors.TextEdit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtStrPackageCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtMListPrice.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtStrDescription.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_dtValidEnd.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_dtValidStart.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PackageCategory.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// mdPKG_lblStrPackageCategory
			// 
			this.mdPKG_lblStrPackageCategory.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lblStrPackageCategory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lblStrPackageCategory.Location = new System.Drawing.Point(256, 24);
			this.mdPKG_lblStrPackageCategory.Name = "mdPKG_lblStrPackageCategory";
			this.mdPKG_lblStrPackageCategory.Size = new System.Drawing.Size(112, 16);
			this.mdPKG_lblStrPackageCategory.TabIndex = 179;
			this.mdPKG_lblStrPackageCategory.Text = "Package Category";
			this.mdPKG_lblStrPackageCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mdPKG_txtStrPackageCode
			// 
			this.mdPKG_txtStrPackageCode.EditValue = "";
			this.mdPKG_txtStrPackageCode.Location = new System.Drawing.Point(152, 24);
			this.mdPKG_txtStrPackageCode.Name = "mdPKG_txtStrPackageCode";
			// 
			// mdPKG_txtStrPackageCode.Properties
			// 
			this.mdPKG_txtStrPackageCode.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdPKG_txtStrPackageCode.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdPKG_txtStrPackageCode.Size = new System.Drawing.Size(88, 20);
			this.mdPKG_txtStrPackageCode.TabIndex = 177;
			// 
			// btnPackageGrpCancel
			// 
			this.btnPackageGrpCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnPackageGrpCancel.Location = new System.Drawing.Point(120, 160);
			this.btnPackageGrpCancel.Name = "btnPackageGrpCancel";
			this.btnPackageGrpCancel.Size = new System.Drawing.Size(64, 24);
			this.btnPackageGrpCancel.TabIndex = 175;
			this.btnPackageGrpCancel.Text = "Cancel";
			// 
			// btnPackageGrpUpdate
			// 
			this.btnPackageGrpUpdate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnPackageGrpUpdate.Location = new System.Drawing.Point(48, 160);
			this.btnPackageGrpUpdate.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.btnPackageGrpUpdate.LookAndFeel.UseDefaultLookAndFeel = false;
			this.btnPackageGrpUpdate.Name = "btnPackageGrpUpdate";
			this.btnPackageGrpUpdate.Size = new System.Drawing.Size(64, 24);
			this.btnPackageGrpUpdate.TabIndex = 174;
			this.btnPackageGrpUpdate.Text = "Save";
			this.btnPackageGrpUpdate.Click += new System.EventHandler(this.btnPackageGrpUpdate_Click);
			// 
			// mdPKG_txtMListPrice
			// 
			this.mdPKG_txtMListPrice.EditValue = "";
			this.mdPKG_txtMListPrice.Location = new System.Drawing.Point(152, 72);
			this.mdPKG_txtMListPrice.Name = "mdPKG_txtMListPrice";
			// 
			// mdPKG_txtMListPrice.Properties
			// 
			this.mdPKG_txtMListPrice.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdPKG_txtMListPrice.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdPKG_txtMListPrice.Properties.Mask.EditMask = "#####0.00";
			this.mdPKG_txtMListPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.mdPKG_txtMListPrice.Size = new System.Drawing.Size(64, 20);
			this.mdPKG_txtMListPrice.TabIndex = 173;
			// 
			// mdPKG_txtStrDescription
			// 
			this.mdPKG_txtStrDescription.EditValue = "";
			this.mdPKG_txtStrDescription.Location = new System.Drawing.Point(152, 48);
			this.mdPKG_txtStrDescription.Name = "mdPKG_txtStrDescription";
			// 
			// mdPKG_txtStrDescription.Properties
			// 
			this.mdPKG_txtStrDescription.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdPKG_txtStrDescription.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdPKG_txtStrDescription.Size = new System.Drawing.Size(416, 20);
			this.mdPKG_txtStrDescription.TabIndex = 172;
			// 
			// mdPKG_dtValidEnd
			// 
			this.mdPKG_dtValidEnd.EditValue = new System.DateTime(2005, 12, 28, 0, 0, 0, 0);
			this.mdPKG_dtValidEnd.Location = new System.Drawing.Point(152, 120);
			this.mdPKG_dtValidEnd.Name = "mdPKG_dtValidEnd";
			// 
			// mdPKG_dtValidEnd.Properties
			// 
			this.mdPKG_dtValidEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.mdPKG_dtValidEnd.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdPKG_dtValidEnd.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdPKG_dtValidEnd.Size = new System.Drawing.Size(88, 20);
			this.mdPKG_dtValidEnd.TabIndex = 171;
			// 
			// mdPKG_dtValidStart
			// 
			this.mdPKG_dtValidStart.EditValue = new System.DateTime(2005, 12, 28, 0, 0, 0, 0);
			this.mdPKG_dtValidStart.Location = new System.Drawing.Point(152, 96);
			this.mdPKG_dtValidStart.Name = "mdPKG_dtValidStart";
			// 
			// mdPKG_dtValidStart.Properties
			// 
			this.mdPKG_dtValidStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.mdPKG_dtValidStart.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdPKG_dtValidStart.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdPKG_dtValidStart.Size = new System.Drawing.Size(88, 20);
			this.mdPKG_dtValidStart.TabIndex = 170;
			// 
			// mdPKG_lbldtValidEnd
			// 
			this.mdPKG_lbldtValidEnd.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lbldtValidEnd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lbldtValidEnd.Location = new System.Drawing.Point(8, 120);
			this.mdPKG_lbldtValidEnd.Name = "mdPKG_lbldtValidEnd";
			this.mdPKG_lbldtValidEnd.Size = new System.Drawing.Size(120, 16);
			this.mdPKG_lbldtValidEnd.TabIndex = 169;
			this.mdPKG_lbldtValidEnd.Text = "Effective End Date";
			this.mdPKG_lbldtValidEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mdPKG_lbldtValidStart
			// 
			this.mdPKG_lbldtValidStart.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lbldtValidStart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lbldtValidStart.Location = new System.Drawing.Point(8, 96);
			this.mdPKG_lbldtValidStart.Name = "mdPKG_lbldtValidStart";
			this.mdPKG_lbldtValidStart.Size = new System.Drawing.Size(120, 16);
			this.mdPKG_lbldtValidStart.TabIndex = 168;
			this.mdPKG_lbldtValidStart.Text = "Effective Start Start";
			this.mdPKG_lbldtValidStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mdPKG_lblMListPrice
			// 
			this.mdPKG_lblMListPrice.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lblMListPrice.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lblMListPrice.Location = new System.Drawing.Point(8, 72);
			this.mdPKG_lblMListPrice.Name = "mdPKG_lblMListPrice";
			this.mdPKG_lblMListPrice.Size = new System.Drawing.Size(120, 16);
			this.mdPKG_lblMListPrice.TabIndex = 167;
			this.mdPKG_lblMListPrice.Text = "Package Group Price";
			this.mdPKG_lblMListPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mdPKG_lblStrDescription
			// 
			this.mdPKG_lblStrDescription.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lblStrDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lblStrDescription.Location = new System.Drawing.Point(8, 48);
			this.mdPKG_lblStrDescription.Name = "mdPKG_lblStrDescription";
			this.mdPKG_lblStrDescription.Size = new System.Drawing.Size(88, 16);
			this.mdPKG_lblStrDescription.TabIndex = 166;
			this.mdPKG_lblStrDescription.Text = "Description";
			this.mdPKG_lblStrDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mdPKG_lblStrPackageCode
			// 
			this.mdPKG_lblStrPackageCode.BackColor = System.Drawing.Color.Transparent;
			this.mdPKG_lblStrPackageCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdPKG_lblStrPackageCode.Location = new System.Drawing.Point(8, 24);
			this.mdPKG_lblStrPackageCode.Name = "mdPKG_lblStrPackageCode";
			this.mdPKG_lblStrPackageCode.Size = new System.Drawing.Size(128, 16);
			this.mdPKG_lblStrPackageCode.TabIndex = 165;
			this.mdPKG_lblStrPackageCode.Text = "Package Group Code";
			this.mdPKG_lblStrPackageCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PackageCategory
			// 
			this.PackageCategory.EditValue = "";
			this.PackageCategory.Location = new System.Drawing.Point(384, 24);
			this.PackageCategory.Name = "PackageCategory";
			// 
			// PackageCategory.Properties
			// 
			this.PackageCategory.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.PackageCategory.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.PackageCategory.Properties.ReadOnly = true;
			this.PackageCategory.Size = new System.Drawing.Size(128, 20);
			this.PackageCategory.TabIndex = 180;
			// 
			// frmMD_PackageGroupAdd
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(576, 222);
			this.Controls.Add(this.PackageCategory);
			this.Controls.Add(this.mdPKG_lblStrPackageCategory);
			this.Controls.Add(this.mdPKG_txtStrPackageCode);
			this.Controls.Add(this.btnPackageGrpCancel);
			this.Controls.Add(this.btnPackageGrpUpdate);
			this.Controls.Add(this.mdPKG_txtMListPrice);
			this.Controls.Add(this.mdPKG_txtStrDescription);
			this.Controls.Add(this.mdPKG_dtValidEnd);
			this.Controls.Add(this.mdPKG_dtValidStart);
			this.Controls.Add(this.mdPKG_lbldtValidEnd);
			this.Controls.Add(this.mdPKG_lbldtValidStart);
			this.Controls.Add(this.mdPKG_lblMListPrice);
			this.Controls.Add(this.mdPKG_lblStrDescription);
			this.Controls.Add(this.mdPKG_lblStrPackageCode);
			this.Name = "frmMD_PackageGroupAdd";
			this.Text = "Package Group Add";
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtStrPackageCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtMListPrice.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_txtStrDescription.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_dtValidEnd.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdPKG_dtValidStart.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PackageCategory.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnPackageGrpUpdate_Click(object sender, System.EventArgs e)
		{
			int output;
			output = 0;

			SqlHelper.ExecuteNonQuery(connection,"up_TblPackageGroup",
				new SqlParameter("@retval",output),
				new SqlParameter("@cmd","I"),
				new SqlParameter("@strPackageGroupCode",this.mdPKG_txtStrPackageCode.EditValue.ToString()),
				new SqlParameter("@strDescription",this.mdPKG_txtStrDescription.EditValue.ToString()),
				new SqlParameter("@mListPrice",this.mdPKG_txtMListPrice.EditValue.ToString()),
				new SqlParameter("@nCategoryID",nCategoryID),
				new SqlParameter("@dtValidStart",this.mdPKG_dtValidStart.EditValue.ToString()),
				new SqlParameter("@dtValidEnd",this.mdPKG_dtValidEnd.EditValue.ToString())
				);
			this.Dispose();
		}
	}
}
