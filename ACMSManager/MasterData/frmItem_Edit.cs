using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

namespace ACMS.ACMSManager.MasterData
{
	/// <summary>
	/// Summary description for frmItem_Edit.
	/// </summary>
	public class frmItem_Edit : DevExpress.XtraEditors.XtraForm
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraEditors.ImageComboBoxEdit CategoryTypeID;
		private DevExpress.XtraEditors.ImageComboBoxEdit GroupID;
		private DevExpress.XtraEditors.LookUpEdit luedtCode;
		private DevExpress.XtraEditors.LookUpEdit luedtItemPromotion;
		private System.Windows.Forms.Label label6;
		internal DevExpress.XtraEditors.SimpleButton btnClose;
		private System.Windows.Forms.Label label1;
		internal DevExpress.XtraEditors.SimpleButton btnSave;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label CreditCard;
		private ACMS.Utils.Common myCommon;
		private string PromotionCode;
		private string Code;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmItem_Edit(string ProCode,string Co)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			myCommon = new ACMS.Utils.Common();

			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
			PromotionCode = ProCode;
			Code = Co;
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
			this.CategoryTypeID = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.GroupID = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.luedtCode = new DevExpress.XtraEditors.LookUpEdit();
			this.luedtItemPromotion = new DevExpress.XtraEditors.LookUpEdit();
			this.label6 = new System.Windows.Forms.Label();
			this.btnClose = new DevExpress.XtraEditors.SimpleButton();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.label4 = new System.Windows.Forms.Label();
			this.CreditCard = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.CategoryTypeID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GroupID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtItemPromotion.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// CategoryTypeID
			// 
			this.CategoryTypeID.Location = new System.Drawing.Point(152, 40);
			this.CategoryTypeID.Name = "CategoryTypeID";
			// 
			// CategoryTypeID.Properties
			// 
			this.CategoryTypeID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.CategoryTypeID.Properties.Items.AddRange(new object[] {
																		   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Item or product", 1, -1),
																		   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Package", 2, -1),
																		   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Package Group", 3, -1),
																		   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Credit Package", 4, -1)});
			this.CategoryTypeID.Size = new System.Drawing.Size(240, 20);
			this.CategoryTypeID.TabIndex = 193;
			this.CategoryTypeID.SelectedIndexChanged += new System.EventHandler(this.CategoryTypeID_SelectedIndexChanged);
			// 
			// GroupID
			// 
			this.GroupID.Location = new System.Drawing.Point(152, 64);
			this.GroupID.Name = "GroupID";
			// 
			// GroupID.Properties
			// 
			this.GroupID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.GroupID.Properties.Items.AddRange(new object[] {
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Item", 0, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Group", 1, -1)});
			this.GroupID.Size = new System.Drawing.Size(240, 20);
			this.GroupID.TabIndex = 192;
			this.GroupID.SelectedIndexChanged += new System.EventHandler(this.GroupID_SelectedIndexChanged);
			// 
			// luedtCode
			// 
			this.luedtCode.Location = new System.Drawing.Point(152, 88);
			this.luedtCode.Name = "luedtCode";
			// 
			// luedtCode.Properties
			// 
			this.luedtCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.luedtCode.Size = new System.Drawing.Size(240, 20);
			this.luedtCode.TabIndex = 191;
			// 
			// luedtItemPromotion
			// 
			this.luedtItemPromotion.Location = new System.Drawing.Point(152, 16);
			this.luedtItemPromotion.Name = "luedtItemPromotion";
			// 
			// luedtItemPromotion.Properties
			// 
			this.luedtItemPromotion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.luedtItemPromotion.Size = new System.Drawing.Size(240, 20);
			this.luedtItemPromotion.TabIndex = 190;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.Location = new System.Drawing.Point(8, 40);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(112, 23);
			this.label6.TabIndex = 189;
			this.label6.Text = "Category Type ID";
			// 
			// btnClose
			// 
			this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnClose.Location = new System.Drawing.Point(200, 136);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(72, 20);
			this.btnClose.TabIndex = 188;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 23);
			this.label1.TabIndex = 187;
			this.label1.Text = "Promotion Code";
			// 
			// btnSave
			// 
			this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnSave.Location = new System.Drawing.Point(112, 136);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(72, 20);
			this.btnSave.TabIndex = 186;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(8, 64);
			this.label4.Name = "label4";
			this.label4.TabIndex = 185;
			this.label4.Text = "Group ID";
			// 
			// CreditCard
			// 
			this.CreditCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.CreditCard.Location = new System.Drawing.Point(8, 88);
			this.CreditCard.Name = "CreditCard";
			this.CreditCard.Size = new System.Drawing.Size(112, 23);
			this.CreditCard.TabIndex = 184;
			this.CreditCard.Text = "Code";
			// 
			// frmItem_Edit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(400, 181);
			this.Controls.Add(this.CategoryTypeID);
			this.Controls.Add(this.GroupID);
			this.Controls.Add(this.luedtCode);
			this.Controls.Add(this.luedtItemPromotion);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.CreditCard);
			this.Name = "frmItem_Edit";
			this.Text = "Item Promotion Edit";
			this.Load += new System.EventHandler(this.frmItem_Edit_Load);
			((System.ComponentModel.ISupportInitialize)(this.CategoryTypeID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GroupID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtItemPromotion.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void BindCode(string CatID, string GroupID)
		{
			DataSet _ds = new DataSet();
			string strSQL;
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			luedtCode.Properties.DataSource = "";
			luedtCode.Properties.Columns.Clear();

			if (CatID == "1" && GroupID == "0")
			{
				strSQL = "select strProductCode as strCode, strDescription from TblProduct";
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
				DataTable dt = _ds.Tables["table"];
						
				col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strCode","Code",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				
				new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.luedtCode.Properties, dt, col, "strDescription", "strCode", "Product");
			}
			else if (CatID == "1" && GroupID == "1")
			{
				strSQL = "select nProductTypeID as strCode, strDescription from TblProductType";
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
				DataTable dt = _ds.Tables["table"];
			
				col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strCode","Product Type",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.luedtCode.Properties, dt, col, "strDescription", "strCode", "Product Type");
			}
			else if (CatID == "2" && GroupID == "0")
			{
				strSQL = "select strPackageCode as strCode, strDescription From tblPackage";
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
				DataTable dt = _ds.Tables["table"];
			
				col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strCode","Code",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.luedtCode.Properties, dt, col, "strDescription", "strCode", "Package");
			}
			else if (CatID == "2" && GroupID == "1")
			{
				strSQL = "select nCategoryID as strCode, strDescription From tblCategory";
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
				DataTable dt = _ds.Tables["table"];
			
				col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strCode","Code",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.luedtCode.Properties, dt, col, "strDescription", "strCode", "Package");
			}
			else if (CatID == "3" && GroupID == "0")
			{
				strSQL = "select strPackageGroupCode as strCode, strDescription From tblpackagegroup";
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
				DataTable dt = _ds.Tables["table"];
			
				col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strCode","Code",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.luedtCode.Properties, dt, col, "strDescription", "strCode", "Package Group");
			}
			else if (CatID == "3" && GroupID == "1")
			{
				strSQL = "select distinct tblpackagegroup.ncategoryid as strCode, tblpackagegroup.strDescription from tblpackagegroup Inner Join TblCategory On TblCategory.nCategoryID = TblPackageGroup.nCategoryID";
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
				DataTable dt = _ds.Tables["table"];
			
				col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strCode","Id",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.luedtCode.Properties, dt, col, "strDescription", "strCode", "Category");
			}
			else if (CatID == "4" && GroupID == "0")
			{
				strSQL = "select strCreditPackageCode as strCode, strDescription from tblcreditpackage";
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
				DataTable dt = _ds.Tables["table"];
			
				col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strCode","Code",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.luedtCode.Properties, dt, col, "strDescription", "strCode", "Credit Package");
			}
			else if (CatID == "4" && GroupID == "1")
			{
				strSQL = "select distinct tblCreditPackage.ncategoryid as strCode, tblCreditPackage.strDescription from tblCreditPackage Inner Join TblCategory On TblCategory.nCategoryID = tblCreditPackage.nCategoryID";
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
				DataTable dt = _ds.Tables["table"];
			
				col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strCode","Id",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
				new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.luedtCode.Properties, dt, col, "strDescription", "strCode", "Category");
			}
		}

		private void CategoryTypeID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (CategoryTypeID.EditValue != null && GroupID.EditValue != null)
				BindCode(CategoryTypeID.EditValue.ToString(),GroupID.EditValue.ToString());
		}

		private void GroupID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (CategoryTypeID.EditValue != null && GroupID.EditValue != null)
				BindCode(CategoryTypeID.EditValue.ToString(),GroupID.EditValue.ToString());
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			string[] col = {"strPromotionCode","nCategoryTypeID","nGroupID","strCode"};
			object[] val = {luedtItemPromotion.EditValue.ToString(),CategoryTypeID.EditValue.ToString(),GroupID.EditValue.ToString(),this.luedtCode.EditValue.ToString()};

			myCommon.Update("TblItemPromotion",col,val,"strPromotionCode = '" + PromotionCode + "' And strCode = '" + Code + "'");
			this.Close();
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void frmItem_Edit_Load(object sender, System.EventArgs e)
		{
			DataSet _ds = new DataSet();
			string strSQL;

			strSQL = "select strPromotionCode, strDescription from TblPromotion";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
			
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strPromotionCode","Code",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
		
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.luedtItemPromotion.Properties, dt, col, "strDescription", "strPromotionCode", "Promotion");
			
			_ds = new DataSet();
			strSQL = "Select * from TblItemPromotion Where strPromotionCode = '" + PromotionCode + "' And strCode = '" + Code + "'";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];

			luedtItemPromotion.EditValue = dt.Rows[0]["strPromotionCode"];
			CategoryTypeID.EditValue = dt.Rows[0]["nCategoryTypeID"];
			GroupID.EditValue = dt.Rows[0]["nGroupID"];

			BindCode(CategoryTypeID.EditValue.ToString(),GroupID.EditValue.ToString());
			this.luedtCode.EditValue = dt.Rows[0]["strCode"];

		}

		


	}
}

