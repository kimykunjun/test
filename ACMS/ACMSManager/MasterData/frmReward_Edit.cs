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
	/// Summary description for frmReward_Edit.
	/// </summary>
	public class frmReward_Edit : DevExpress.XtraEditors.XtraForm
	{
		private string connectionString;
		private SqlConnection connection;
		private ACMS.Utils.Common myCommon;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.TextEdit rewardDesc;
		private DevExpress.XtraEditors.LookUpEdit luedtItem;
		private DevExpress.XtraEditors.ComboBoxEdit cmb_Type;
		private DevExpress.XtraEditors.DateEdit dtValidEnd;
		private DevExpress.XtraEditors.DateEdit dtValidStart;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.TextEdit dRewardsPoints;
		private System.Windows.Forms.Label label6;
		internal DevExpress.XtraEditors.SimpleButton btnClose;
		private System.Windows.Forms.Label label1;
		internal DevExpress.XtraEditors.SimpleButton btnSave;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label CreditCard;
		private int pkItemCode;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmReward_Edit(int ItemCode)
		{
			InitializeComponent();
			myCommon = new ACMS.Utils.Common();

			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
			
			pkItemCode=ItemCode;

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
			this.label3 = new System.Windows.Forms.Label();
			this.rewardDesc = new DevExpress.XtraEditors.TextEdit();
			this.luedtItem = new DevExpress.XtraEditors.LookUpEdit();
			this.cmb_Type = new DevExpress.XtraEditors.ComboBoxEdit();
			this.dtValidEnd = new DevExpress.XtraEditors.DateEdit();
			this.dtValidStart = new DevExpress.XtraEditors.DateEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.dRewardsPoints = new DevExpress.XtraEditors.TextEdit();
			this.label6 = new System.Windows.Forms.Label();
			this.btnClose = new DevExpress.XtraEditors.SimpleButton();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.label4 = new System.Windows.Forms.Label();
			this.CreditCard = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.rewardDesc.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtItem.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmb_Type.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtValidEnd.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtValidStart.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dRewardsPoints.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(24, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(120, 23);
			this.label3.TabIndex = 215;
			this.label3.Text = "Description";
			// 
			// rewardDesc
			// 
			this.rewardDesc.EditValue = "";
			this.rewardDesc.Location = new System.Drawing.Point(168, 64);
			this.rewardDesc.Name = "rewardDesc";
			this.rewardDesc.Size = new System.Drawing.Size(240, 20);
			this.rewardDesc.TabIndex = 214;
			// 
			// luedtItem
			// 
			this.luedtItem.Location = new System.Drawing.Point(168, 40);
			this.luedtItem.Name = "luedtItem";
			// 
			// luedtItem.Properties
			// 
			this.luedtItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.luedtItem.Properties.NullText = "";
			this.luedtItem.Size = new System.Drawing.Size(240, 20);
			this.luedtItem.TabIndex = 213;
			// 
			// cmb_Type
			// 
			this.cmb_Type.EditValue = "";
			this.cmb_Type.Location = new System.Drawing.Point(168, 16);
			this.cmb_Type.Name = "cmb_Type";
			// 
			// cmb_Type.Properties
			// 
			this.cmb_Type.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmb_Type.Size = new System.Drawing.Size(240, 20);
			this.cmb_Type.TabIndex = 212;
			this.cmb_Type.SelectedIndexChanged += new System.EventHandler(this.load_cmbType);
			// 
			// dtValidEnd
			// 
			this.dtValidEnd.EditValue = null;
			this.dtValidEnd.Location = new System.Drawing.Point(168, 136);
			this.dtValidEnd.Name = "dtValidEnd";
			// 
			// dtValidEnd.Properties
			// 
			this.dtValidEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dtValidEnd.Size = new System.Drawing.Size(240, 20);
			this.dtValidEnd.TabIndex = 211;
			// 
			// dtValidStart
			// 
			this.dtValidStart.EditValue = null;
			this.dtValidStart.Location = new System.Drawing.Point(168, 112);
			this.dtValidStart.Name = "dtValidStart";
			// 
			// dtValidStart.Properties
			// 
			this.dtValidStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dtValidStart.Size = new System.Drawing.Size(240, 20);
			this.dtValidStart.TabIndex = 210;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(24, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 23);
			this.label2.TabIndex = 209;
			this.label2.Text = "Item Type";
			// 
			// dRewardsPoints
			// 
			this.dRewardsPoints.EditValue = "0";
			this.dRewardsPoints.Location = new System.Drawing.Point(168, 88);
			this.dRewardsPoints.Name = "dRewardsPoints";
			this.dRewardsPoints.Size = new System.Drawing.Size(240, 20);
			this.dRewardsPoints.TabIndex = 208;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(24, 88);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(112, 23);
			this.label6.TabIndex = 207;
			this.label6.Text = "Points";
			// 
			// btnClose
			// 
			this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnClose.Location = new System.Drawing.Point(216, 176);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(72, 20);
			this.btnClose.TabIndex = 206;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(24, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 23);
			this.label1.TabIndex = 205;
			this.label1.Text = "Item Code";
			// 
			// btnSave
			// 
			this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnSave.Location = new System.Drawing.Point(96, 176);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(72, 20);
			this.btnSave.TabIndex = 204;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(24, 112);
			this.label4.Name = "label4";
			this.label4.TabIndex = 203;
			this.label4.Text = "Start Date";
			// 
			// CreditCard
			// 
			this.CreditCard.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CreditCard.Location = new System.Drawing.Point(24, 136);
			this.CreditCard.Name = "CreditCard";
			this.CreditCard.Size = new System.Drawing.Size(112, 23);
			this.CreditCard.TabIndex = 202;
			this.CreditCard.Text = "Till";
			// 
			// frmReward_Edit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(448, 222);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.rewardDesc);
			this.Controls.Add(this.luedtItem);
			this.Controls.Add(this.cmb_Type);
			this.Controls.Add(this.dtValidEnd);
			this.Controls.Add(this.dtValidStart);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dRewardsPoints);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.CreditCard);
			this.Name = "frmReward_Edit";
			this.Text = "Reward Catalogue Edit";
			this.Load += new System.EventHandler(this.frmReward_Edit_Load);
			((System.ComponentModel.ISupportInitialize)(this.rewardDesc.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtItem.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmb_Type.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtValidEnd.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtValidStart.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dRewardsPoints.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmReward_Edit_Load(object sender, System.EventArgs e)
		{
			cmb_Type.Properties.Items.Add("Product");
			cmb_Type.Properties.Items.Add("Package");
			cmb_Type.Properties.Items.Add("Service");
			

			DataSet _ds = new DataSet();
			DataTable dt = _ds.Tables["table"];
			_ds = new DataSet();
		
			string strSQL = "Select * from TblRewardsCatalogue Where pkItemCode =" + pkItemCode + "";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];

			cmb_Type.SelectedIndex=Convert.ToInt16(dt.Rows[0]["nRewardType"]);
			luedtItem.EditValue=dt.Rows[0]["strItemCode"];
			rewardDesc.EditValue =dt.Rows[0]["strDescription"];
			dRewardsPoints.EditValue=dt.Rows[0]["dRewardsPoints"];
			dtValidStart.EditValue=dt.Rows[0]["dtValidStart"];
			dtValidEnd.EditValue=dt.Rows[0]["dtValidEnd"];

			Init_cmb_Type();
			//luedtItemPromotion.EditValue = dt.Rows[0]["strPromotionCode"];
			//CategoryTypeID.EditValue = dt.Rows[0]["nCategoryTypeID"];
			//GroupID.EditValue = dt.Rows[0]["nGroupID"];

			//BindCode(CategoryTypeID.EditValue.ToString(),GroupID.EditValue.ToString());
			//this.luedtCode.EditValue = dt.Rows[0]["strCode"];
	
		}

		private void Init_cmb_Type()
		{
			DataSet _ds = new DataSet();
			string strSQL;

			string strType=cmb_Type.Text;

			strSQL = "select str" + strType + "Code , strDescription from Tbl" + strType + "";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];

			luedtItem.Properties.DataSource = "";
			luedtItem.Properties.Columns.Clear();
			
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
		
			
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("str" + strType + "Code","Code",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.luedtItem.Properties, dt, col, "strDescription", "str" + strType + "Code", strType);

		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			string[] col = {"nRewardType","strItemCode","strDescription","dRewardsPoints","dtValidStart","dtValidEnd"};
			object[] val = {cmb_Type.SelectedIndex,luedtItem.EditValue.ToString(),rewardDesc.Text.ToString(),dRewardsPoints.Text.ToString(),dtValidStart.EditValue,dtValidEnd.EditValue};
			myCommon.Update("TblRewardsCatalogue",col,val,"pkItemCode=" + pkItemCode + "");
			
			this.Close();

		}

		private void load_cmbType(object sender, System.EventArgs e)
		{
			Init_cmb_Type();
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
				this.Dispose();
		}
	}
}

