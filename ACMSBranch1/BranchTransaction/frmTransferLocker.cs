using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using Do = Acms.Core.Domain;
using ACMSLogic;
using ACMS.Utils;

namespace ACMS.ACMSBranch.BranchTransaction
{
	/// <summary>
	/// Summary description for frmTransferLocker.
	/// </summary>
	public class frmTransferLocker : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		//private static Do.Employee employee;
		//private static Do.TerminalUser terminalUser; 
		private static User oUser;
		internal DevExpress.XtraEditors.SimpleButton btnTransfer;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		internal DevExpress.XtraGrid.GridControl gridLocker;
		internal DevExpress.XtraGrid.Views.Grid.GridView GridViewLocker;
		internal DevExpress.XtraGrid.Columns.GridColumn nLockerNo;
		internal DevExpress.XtraGrid.Columns.GridColumn strMembershipID;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn239;
		private DevExpress.XtraGrid.Columns.GridColumn strRemarks;
		private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit3;
		private DevExpress.XtraEditors.Repository.RepositoryItemMRUEdit repositoryItemMRUEdit1;
		private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
		private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
		private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
		internal DevExpress.XtraEditors.SimpleButton btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private int LockerId;
		private static string MemberId;
		private static string BranchCode;

		public frmTransferLocker(int LocId,string memId,string br)
		{
			//
			// Required for Windows Form Designer support
			//
			BranchCode = br;
			MemberId = memId;
			LockerId = LocId;
			InitializeComponent();
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);

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
			this.btnTransfer = new DevExpress.XtraEditors.SimpleButton();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.gridLocker = new DevExpress.XtraGrid.GridControl();
			this.GridViewLocker = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.nLockerNo = new DevExpress.XtraGrid.Columns.GridColumn();
			this.strMembershipID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
			this.GridColumn239 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.strRemarks = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
			this.repositoryItemMRUEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMRUEdit();
			this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
			this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
			this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridLocker)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewLocker)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMRUEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnTransfer
			// 
			this.btnTransfer.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnTransfer.Appearance.Options.UseFont = true;
			this.btnTransfer.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnTransfer.Location = new System.Drawing.Point(392, 8);
			this.btnTransfer.Name = "btnTransfer";
			this.btnTransfer.Size = new System.Drawing.Size(68, 20);
			this.btnTransfer.TabIndex = 11;
			this.btnTransfer.Text = "Transfer";
			this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
			// 
			// groupControl1
			// 
			this.groupControl1.Controls.Add(this.gridLocker);
			this.groupControl1.Location = new System.Drawing.Point(8, 32);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(552, 224);
			this.groupControl1.TabIndex = 12;
			// 
			// gridLocker
			// 
			this.gridLocker.Dock = System.Windows.Forms.DockStyle.Bottom;
			// 
			// gridLocker.EmbeddedNavigator
			// 
			this.gridLocker.EmbeddedNavigator.Name = "";
			this.gridLocker.Location = new System.Drawing.Point(4, 12);
			this.gridLocker.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridLocker.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridLocker.LookAndFeel.UseWindowsXPTheme = false;
			this.gridLocker.MainView = this.GridViewLocker;
			this.gridLocker.Name = "gridLocker";
			this.gridLocker.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												this.repositoryItemMRUEdit1,
																												this.repositoryItemMemoEdit1,
																												this.repositoryItemMemoEdit2,
																												this.repositoryItemDateEdit1,
																												this.repositoryItemMemoEdit3,
																												this.repositoryItemDateEdit2});
			this.gridLocker.Size = new System.Drawing.Size(544, 208);
			this.gridLocker.TabIndex = 10;
			this.gridLocker.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									  this.GridViewLocker});
			// 
			// GridViewLocker
			// 
			this.GridViewLocker.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																								  this.nLockerNo,
																								  this.strMembershipID,
																								  this.gridColumn1,
																								  this.GridColumn239,
																								  this.strRemarks});
			this.GridViewLocker.GridControl = this.gridLocker;
			this.GridViewLocker.Name = "GridViewLocker";
			this.GridViewLocker.OptionsCustomization.AllowFilter = false;
			this.GridViewLocker.OptionsCustomization.AllowGroup = false;
			this.GridViewLocker.OptionsCustomization.AllowSort = false;
			this.GridViewLocker.OptionsView.ShowGroupPanel = false;
			// 
			// nLockerNo
			// 
			this.nLockerNo.Caption = "Locker No";
			this.nLockerNo.FieldName = "nLockerNo";
			this.nLockerNo.Name = "nLockerNo";
			this.nLockerNo.OptionsColumn.AllowEdit = false;
			this.nLockerNo.Visible = true;
			this.nLockerNo.VisibleIndex = 0;
			this.nLockerNo.Width = 146;
			// 
			// strMembershipID
			// 
			this.strMembershipID.Caption = "Membership ID";
			this.strMembershipID.FieldName = "strMembershipID";
			this.strMembershipID.Name = "strMembershipID";
			this.strMembershipID.OptionsColumn.AllowEdit = false;
			this.strMembershipID.Visible = true;
			this.strMembershipID.VisibleIndex = 1;
			this.strMembershipID.Width = 196;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Expiry Date";
			this.gridColumn1.ColumnEdit = this.repositoryItemDateEdit2;
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 2;
			this.gridColumn1.Width = 159;
			// 
			// repositoryItemDateEdit2
			// 
			this.repositoryItemDateEdit2.AutoHeight = false;
			this.repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
			// 
			// GridColumn239
			// 
			this.GridColumn239.Caption = "Status";
			this.GridColumn239.FieldName = "Status";
			this.GridColumn239.Name = "GridColumn239";
			this.GridColumn239.OptionsColumn.AllowEdit = false;
			this.GridColumn239.Visible = true;
			this.GridColumn239.VisibleIndex = 3;
			this.GridColumn239.Width = 193;
			// 
			// strRemarks
			// 
			this.strRemarks.Caption = "Remark";
			this.strRemarks.ColumnEdit = this.repositoryItemMemoEdit3;
			this.strRemarks.FieldName = "strRemarks";
			this.strRemarks.Name = "strRemarks";
			this.strRemarks.Visible = true;
			this.strRemarks.VisibleIndex = 4;
			this.strRemarks.Width = 273;
			// 
			// repositoryItemMemoEdit3
			// 
			this.repositoryItemMemoEdit3.Name = "repositoryItemMemoEdit3";
			// 
			// repositoryItemMRUEdit1
			// 
			this.repositoryItemMRUEdit1.AutoHeight = false;
			this.repositoryItemMRUEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemMRUEdit1.Name = "repositoryItemMRUEdit1";
			// 
			// repositoryItemMemoEdit1
			// 
			this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
			// 
			// repositoryItemMemoEdit2
			// 
			this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
			// 
			// repositoryItemDateEdit1
			// 
			this.repositoryItemDateEdit1.AutoHeight = false;
			this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
			// 
			// btnCancel
			// 
			this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancel.Appearance.Options.UseFont = true;
			this.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnCancel.Location = new System.Drawing.Point(472, 8);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(68, 20);
			this.btnCancel.TabIndex = 13;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmTransferLocker
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(568, 269);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.groupControl1);
			this.Controls.Add(this.btnTransfer);
			this.Name = "frmTransferLocker";
			this.Text = "Transfer";
			this.Load += new System.EventHandler(this.frmTransferLocker_Load);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridLocker)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridViewLocker)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMRUEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public void initData (ACMSLogic.User User)
		{
			oUser = User;
			MemberRecord myMemberRecord = new MemberRecord(oUser.StrBranchCode());
		}

		private void frmTransferLocker_Load(object sender, System.EventArgs e)
		{
			LoadLockerAvailable();
		}

		

		private void LoadLockerAvailable()
		{
		
				DataSet _ds = new DataSet();
						
				string strSQL = "up_get_Locker '" + oUser.StrBranchCode().ToString() + "',2";

				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			
				this.gridLocker.DataSource = _ds.Tables["table"];

		}

		private void btnTransfer_Click(object sender, System.EventArgs e)
		{
			if (GridViewLocker.RowCount > 0)
			{
				
				DataRow dr = this.GridViewLocker.GetDataRow(this.GridViewLocker.FocusedRowHandle);
			
				int output;
				output = 0;
			
				SqlHelper.ExecuteNonQuery(connection,"up_TransferLocker",
					new SqlParameter("@retval",output),
					new SqlParameter("@strBranchCode",BranchCode),
					new SqlParameter("@LockerNo",Convert.ToInt32(dr["nLockerNo"])),
					new SqlParameter("@strMembershipID",MemberId),
					new SqlParameter("@LockerNo",LockerId),
					new SqlParameter("@nEmployeeID",oUser.NEmployeeID())
				);

				MessageBox.Show("Locker Transferred..","Transfer");

				this.Dispose();
			}
			else
			{
				MessageBox.Show("There is no locker to be transferred.","Transfer");
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}


	}
}
