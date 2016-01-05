using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Data.OleDb;
using ACMS.Utils;


namespace ACMS.ACMSManager.MasterData
{
	/// <summary>
	/// Summary description for frmReward.
	/// </summary>
	public class frmReward : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;

		private DevExpress.XtraEditors.GroupControl grpMDLeaveTop;
		private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;
		private DevExpress.XtraEditors.GroupControl groupControl2;
		private DevExpress.XtraEditors.GroupControl grpMDPromotionBelow2;
		private DevExpress.XtraEditors.GroupControl groupControl3;
		private DevExpress.XtraEditors.SimpleButton btnBranch_Del;
		private DevExpress.XtraEditors.SimpleButton btnBranch_DelAll;
		private DevExpress.XtraEditors.SimpleButton btnBranch_AddAll;
		private DevExpress.XtraEditors.SimpleButton btnBranch_Add;
		private DevExpress.XtraGrid.GridControl gridBranch2;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraGrid.GridControl gridBranch;
		private DevExpress.XtraGrid.Views.Grid.GridView gvBranch2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn34;
		private DevExpress.XtraGrid.Views.Grid.GridView gvBranch;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
		private DevExpress.XtraTab.XtraTabControl TabRewards;
		private DevExpress.XtraTab.XtraTabPage tabReward_Issue;
		private DevExpress.XtraTab.XtraTabPage tabReward_Catalogue;
		internal DevExpress.XtraEditors.SimpleButton btn_Del;
		internal DevExpress.XtraEditors.SimpleButton Btn_Add;
		private DevExpress.XtraEditors.GroupControl groupControl4;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.GroupControl grpMDRewardBelow;

		private DataTable dtRewardIssue;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn strRewardsCode;
		private DevExpress.XtraGrid.Columns.GridColumn strDescription;
		private DevExpress.XtraGrid.Columns.GridColumn dRewardsPercent;
		private DevExpress.XtraGrid.Columns.GridColumn dRewardsValue;
		private DevExpress.XtraGrid.Columns.GridColumn dtValidStart;
		private DevExpress.XtraGrid.Columns.GridColumn dtValidEnd;
		private DevExpress.XtraGrid.Columns.GridColumn nSalesCategoryID;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_LookupSalesCategory;
		private DevExpress.XtraGrid.Columns.GridColumn nTypeID;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox Type_ComboBox;
		private DevExpress.XtraGrid.GridControl gridControl2;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_LookupRewardItem;
		internal DevExpress.XtraEditors.TextEdit txtSearch;
		internal DevExpress.XtraEditors.SimpleButton btn_Search;
		private System.Windows.Forms.Panel panelReward;
		private DataTable dtRewardCatalogue;



		public frmReward()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
	
		}

		private void frmReward_Load(object sender, System.EventArgs e)
		{
			initRewardIssue();
			initRewardCatalogue();
		}

		public void CreateCmdsAndUpdate(string mySelectQuery,DataTable myTableName) 
		{
			SqlConnection myConn = new SqlConnection(connectionString);
			SqlDataAdapter myDataAdapter = new SqlDataAdapter();
			myDataAdapter.SelectCommand=new SqlCommand(mySelectQuery, myConn);
			SqlCommandBuilder custCB = new SqlCommandBuilder(myDataAdapter);

			myConn.Open();
			DataSet custDS = new DataSet();
			myDataAdapter.Fill(custDS);

			//code to modify data in dataset here
			myDataAdapter.Update(myTableName);
			myConn.Close();
		}


	private void grpMDRewardBelow_control(object sender, System.EventArgs e)
	{
		if (TabRewards.SelectedTabPage.Text == "Points Issue")
		{
			grpMDRewardBelow.Visible=true;
			panelReward.Visible=true;
		}
		else	
		{ 	
			grpMDRewardBelow.Visible=false;
			panelReward.Visible=false;
		}

	}

		#region Catalogue

		private void initRewardCatalogue()
		{
//			DataSet _ds = new DataSet();
//			string strSQL;
//
//			strSQL = "select strProductCode,strDescription from tblproduct A where  A.dtValidStart <= getdate()and A.dtValidEnd >= getdate() AND A.nStatus = 1 order by strdescription	";
//			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
//			DataTable dt = _ds.Tables["table"];
//			
//			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
//			
//			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strProductCode","Product ID",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
//			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
//		
//			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_LookupRewardItem,dt,col,"strDescription","strProductCode","Product ID");
			mdRewardCatalogueInit();

			}


		private void mdRewardCatalogueInit()
		{
			string strSQL;
			strSQL = "select * from tblrewardsCatalogue";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtRewardCatalogue = _ds.Tables["table"];
			gridControl2.DataSource = dtRewardCatalogue;
		}



		private void Del_RewardCatalogue(object sender, System.EventArgs e)
		{
			DataRow row = this.gridView2.GetDataRow(gridView2.FocusedRowHandle);
			if (row != null)
			{
				if (AddNew)
				{
					AddNew = false;
					gridView2.DeleteRow(gridView1.FocusedRowHandle);
				}
				else
				{

					DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Item Code = " + row["strItemCode"].ToString(),
						"Delete?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						try
						{
							SqlHelper.ExecuteNonQuery(connection,"del_RewardItemType",
								new SqlParameter("@strClassCode",row["strItemCode"].ToString() )
								);
						}
						catch(Exception ex)
						{
							MessageBox.Show(ex.Message ,"Delete Process Failed");
							return;
						}
						MessageBox.Show("Record Deleted Successfully","Message");
					}
					mdRewardCatalogueInit();
				}
			}
		}

		private void gridView2_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridView2.GetDataRow(gridView2.FocusedRowHandle);
			
			string strSQL = "Select * from TblRewardsCatalogue";
			if (AddNew)
			{
				if( CheckClassTypeField(row))
				{
					this.gridControl2.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtRewardCatalogue);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message ,"Delete Process Failed");
						return;
					}
					AddNew = false;
				}
			}
			else
			{
				this.gridView2.CloseEditor();
				gridView2.UpdateCurrentRow();
				CreateCmdsAndUpdate(strSQL,dtRewardCatalogue);
			}
		}

		
		#endregion

	#region Issue
		
		private void initRewardIssue()
		{
			DataSet _ds = new DataSet();
			string strSQL;

			strSQL = "select * from tblSalesCategory";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
			
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nSalesCategoryID","Sales Category Id",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
		
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_LookupSalesCategory,dt,col,"strDescription","nSalesCategoryID","Sales Category");
			
			mdRewardIssueInit();
			LoadBranch();
		}

		private void mdRewardIssueInit()
		{
			string strSQL;
			strSQL = "select * from tblrewards where strRewardsCode like '%" + txtSearch.Text + "%' or  strDescription like '%" + txtSearch.Text +"%'";

			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtRewardIssue = _ds.Tables["table"];
			gridControl1.DataSource = dtRewardIssue;
		}

		private void btn_Add_Click(object sender, System.EventArgs e)
		{
			AddNew = true;
						
			if (TabRewards.SelectedTabPage.Text == "Points Issue")
			{
				DataRow dr = dtRewardIssue.NewRow();
				dtRewardIssue.Rows.Add(dr);
				this.gridControl1.Refresh();
				this.gridView1.FocusedRowHandle = dtRewardIssue.Rows.Count - 1;
				
			}
			else 
			{
				frmReward_Add myRewardform;
				myRewardform = new frmReward_Add();
				myRewardform.ShowDialog();
				mdRewardCatalogueInit();
		//		DataRow dr = dtRewardCatalogue.NewRow();
		//		dtRewardCatalogue.Rows.Add(dr);
		//		this.gridControl2.Refresh();
		//		this.gridView2.FocusedRowHandle = dtRewardCatalogue.Rows.Count - 1;
			}
		}


		private void Del_PtsIssue(object sender, System.EventArgs e)
		{
				DataRow row = this.gridView1.GetDataRow(gridView1.FocusedRowHandle);
			if (row != null)
			{
				if (AddNew)
				{
					AddNew = false;
					gridView1.DeleteRow(gridView1.FocusedRowHandle);
				}
				else
				{

					DialogResult result = MessageBox.Show(this, "Do you really want to delete record with Reward Code = " + row["strRewardsCode"].ToString(),
						"Delete?", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						try
						{
							SqlHelper.ExecuteNonQuery(connection,"del_RewardType",
								new SqlParameter("@strClassCode",row["strRewardsCode"].ToString() )
								);
						}
						catch(Exception ex)
						{
							MessageBox.Show(ex.Message ,"Delete Process Failed");
							return;
						}
						MessageBox.Show("Record Deleted Successfully","Message");
					}
					mdRewardIssueInit();
				}
			}
		}

		private void btn_Del_Click(object sender, System.EventArgs e)
		{
			if (TabRewards.SelectedTabPage.Text == "Points Issue"){
				Del_PtsIssue(sender,e);}
			else{
				Del_RewardCatalogue(sender,e);}
		}

#endregion


		#region Branch

		private DataTable dtBranch;

		private void btnBranch_Add_Click(object sender, System.EventArgs e)
		{
			DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

			int[] rowsHandle = this.gvBranch.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gvBranch.GetDataRow(index);
				DataRow rNew = dtBranch.NewRow();
				rNew.BeginEdit();
				rNew["strRewardsCode"] = dr["strRewardsCode"];
				rNew["strBranchCode"] = rCopy["strBranchCode"];
				rNew["strBranchName"] = rCopy["strBranchName"];
				rNew.EndEdit();
				dtBranch.Rows.Add(rNew);
			}

			gvBranch.DeleteSelectedRows();
						
			try
			{
				string strSQL = "select strRewardsCode, strBranchCode from tblRewardsBranch Where strRewardsCode = '" + dr["strRewardsCode"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtBranch);
			}
			catch (Exception)
			{
				return;
			}
		}

		private void btnBranch_DelAll_Click(object sender, System.EventArgs e)
		{
			DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

			gvBranch.BeginDataUpdate();
			gvBranch2.BeginDataUpdate();
			DataTable dtTemp = (gvBranch.DataSource as DataView).Table;

			for (int i = dtBranch.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gvBranch2.GetDataRow(i);
				DataRow rNew = dtTemp.NewRow();
				rNew.BeginEdit();
				rNew["strBranchCode"] = rCopy["strBranchCode"];
				rNew["strBranchName"] = rCopy["strBranchName"];
				rNew.EndEdit();
				dtTemp.Rows.Add(rNew);
			}

			for (int i = dtBranch.Rows.Count - 1; i >= 0; i--)
			{
				if (dtBranch.Rows[i].RowState != DataRowState.Deleted)
					dtBranch.Rows[i].Delete();
			}

			gvBranch2.EndDataUpdate();
			gvBranch.EndDataUpdate();

			string strSQL = "select strRewardsCode, strBranchCode from tblRewardsBranch Where strRewardsCode = '" + dr["strRewardsCode"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtBranch);
		}

		private void btnBranch_AddAll_Click(object sender, System.EventArgs e)
		{
			gvBranch.BeginDataUpdate();
			gvBranch2.BeginDataUpdate();

			DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
			DataTable dtTemp = (gvBranch.DataSource as DataView).Table;
			//dtTemp.RejectChanges();
			dtTemp.AcceptChanges();

			for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gvBranch.GetDataRow(i);
				DataRow rNew = dtBranch.NewRow();
				rNew.BeginEdit();
				rNew["strRewardsCode"] = dr["strRewardsCode"];
				rNew["strBranchCode"] = rCopy["strBranchCode"];
				rNew["strBranchName"] = rCopy["strBranchName"];
				rNew.EndEdit();
				dtBranch.Rows.Add(rNew);
			}

			for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
			{
				if (dtTemp.Rows[i].RowState != DataRowState.Deleted)
					dtTemp.Rows[i].Delete();
			}

			gvBranch.EndDataUpdate();
			gvBranch2.EndDataUpdate();

			string strSQL = "select strRewardsCode, strBranchCode from tblRewardsBranch Where strRewardsCode = '" + dr["strRewardsCode"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtBranch);
		}

		private void btnBranch_Del_Click(object sender, System.EventArgs e)
		{
			DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

			int[] rowsHandle = gvBranch2.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			DataTable dtTemp = (gvBranch.DataSource as DataView).Table;
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gvBranch2.GetDataRow(index);
				DataRow rNew = dtTemp.NewRow();
				rNew.BeginEdit();
				rNew["strBranchCode"] = rCopy["strBranchCode"];
				rNew["strBranchName"] = rCopy["strBranchName"];
				rNew.EndEdit();
				dtTemp.Rows.Add(rNew);
			}
			gvBranch2.DeleteSelectedRows();

			try
			{
				string strSQL = "select strRewardsCode, strBranchCode from tblRewardsBranch Where strRewardsCode = '" + dr["strRewardsCode"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtBranch);
			}
			catch (Exception)
			{
				return;
			}
		}

		private void LoadBranch()
		{
			DataSet _ds;
			DataRow dr = this.gridView1.GetDataRow(this.gridView1.FocusedRowHandle);
			
			if (dr == null)
				return;

			string strSQL;
			strSQL = "select strBranchCode, strBranchName from TblBranch Where strBranchCode Not In (Select strBranchCode From tblRewardsBranch Where strRewardsCode = '" + dr["strRewardsCode"].ToString() + "')";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			this.gridBranch.DataSource = _ds.Tables["table"];
				
			strSQL = "select P.strRewardsCode, B.strBranchCode, strBranchName from tblRewardsBranch P Inner Join TblBranch B On B.strBranchCode = P.strBranchCode Where P.strRewardsCode = '" + dr["strRewardsCode"].ToString() + "'";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtBranch = _ds.Tables["table"];
			gridBranch2.DataSource = dtBranch;
		}
#endregion

		private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			LoadBranch();
		}

		private bool CheckClassTypeField(DataRow dr)
		{
			for (int a =0; a< dr.Table.Columns.Count; a++)
			{
				if (dr[a].ToString() == "")
					return false;
			}
			return true;
		}
		private bool CheckClassField(DataRow dr)
		{
			if (dr["nYearID"].ToString() == "")
				return false;

			return true;
		}
		private bool AddNew = false;
		private void gridView1_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridView1.GetDataRow(gridView1.FocusedRowHandle);
			
			string strSQL = "Select * from TblRewards";
			if (AddNew)
			{
				if( CheckClassTypeField(row))
				{
					this.gridControl1.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtRewardIssue);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message ,"Delete Process Failed");
						return;
					}
					AddNew = false;
				}
			}
			else
			{
				this.gridView1.CloseEditor();
				gridView1.UpdateCurrentRow();
				CreateCmdsAndUpdate(strSQL,dtRewardIssue);
			}
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmReward));
			this.grpMDLeaveTop = new DevExpress.XtraEditors.GroupControl();
			this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
			this.TabRewards = new DevExpress.XtraTab.XtraTabControl();
			this.tabReward_Issue = new DevExpress.XtraTab.XtraTabPage();
			this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.strRewardsCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.strDescription = new DevExpress.XtraGrid.Columns.GridColumn();
			this.dRewardsPercent = new DevExpress.XtraGrid.Columns.GridColumn();
			this.dRewardsValue = new DevExpress.XtraGrid.Columns.GridColumn();
			this.dtValidStart = new DevExpress.XtraGrid.Columns.GridColumn();
			this.dtValidEnd = new DevExpress.XtraGrid.Columns.GridColumn();
			this.nSalesCategoryID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_LookupSalesCategory = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.nTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.Type_ComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.grpMDRewardBelow = new DevExpress.XtraEditors.GroupControl();
			this.grpMDPromotionBelow2 = new DevExpress.XtraEditors.GroupControl();
			this.gridBranch2 = new DevExpress.XtraGrid.GridControl();
			this.gvBranch2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridBranch = new DevExpress.XtraGrid.GridControl();
			this.gvBranch = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.btnBranch_Add = new DevExpress.XtraEditors.SimpleButton();
			this.btnBranch_Del = new DevExpress.XtraEditors.SimpleButton();
			this.btnBranch_DelAll = new DevExpress.XtraEditors.SimpleButton();
			this.btnBranch_AddAll = new DevExpress.XtraEditors.SimpleButton();
			this.tabReward_Catalogue = new DevExpress.XtraTab.XtraTabPage();
			this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
			this.gridControl2 = new DevExpress.XtraGrid.GridControl();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_LookupRewardItem = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.panelReward = new System.Windows.Forms.Panel();
			this.txtSearch = new DevExpress.XtraEditors.TextEdit();
			this.btn_Search = new DevExpress.XtraEditors.SimpleButton();
			this.btn_Del = new DevExpress.XtraEditors.SimpleButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.Btn_Add = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.grpMDLeaveTop)).BeginInit();
			this.grpMDLeaveTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
			this.groupControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.TabRewards)).BeginInit();
			this.TabRewards.SuspendLayout();
			this.tabReward_Issue.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
			this.groupControl3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_LookupSalesCategory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Type_ComboBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grpMDRewardBelow)).BeginInit();
			this.grpMDRewardBelow.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpMDPromotionBelow2)).BeginInit();
			this.grpMDPromotionBelow2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridBranch2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvBranch2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridBranch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvBranch)).BeginInit();
			this.tabReward_Catalogue.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
			this.groupControl4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_LookupRewardItem)).BeginInit();
			this.panelReward.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// grpMDLeaveTop
			// 
			this.grpMDLeaveTop.Appearance.BackColor = System.Drawing.Color.White;
			this.grpMDLeaveTop.Appearance.Options.UseBackColor = true;
			this.grpMDLeaveTop.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.grpMDLeaveTop.AppearanceCaption.Options.UseFont = true;
			this.grpMDLeaveTop.Controls.Add(this.groupControl2);
			this.grpMDLeaveTop.ImeMode = System.Windows.Forms.ImeMode.On;
			this.grpMDLeaveTop.Location = new System.Drawing.Point(-4, -17);
			this.grpMDLeaveTop.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.grpMDLeaveTop.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpMDLeaveTop.LookAndFeel.UseWindowsXPTheme = false;
			this.grpMDLeaveTop.Name = "grpMDLeaveTop";
			this.grpMDLeaveTop.Size = new System.Drawing.Size(804, 505);
			this.grpMDLeaveTop.TabIndex = 90;
			this.grpMDLeaveTop.Text = "MASTER FILE";
			// 
			// groupControl2
			// 
			this.groupControl2.Appearance.BackColor = System.Drawing.Color.LightGray;
			this.groupControl2.Appearance.Options.UseBackColor = true;
			this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl2.AppearanceCaption.Options.UseFont = true;
			this.groupControl2.Controls.Add(this.TabRewards);
			this.groupControl2.Controls.Add(this.panelReward);
			this.groupControl2.Controls.Add(this.btn_Del);
			this.groupControl2.Controls.Add(this.Btn_Add);
			this.groupControl2.ImeMode = System.Windows.Forms.ImeMode.On;
			this.groupControl2.Location = new System.Drawing.Point(8, 16);
			this.groupControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.groupControl2.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupControl2.LookAndFeel.UseWindowsXPTheme = false;
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.Size = new System.Drawing.Size(784, 488);
			this.groupControl2.TabIndex = 139;
			this.groupControl2.Text = "Reward";
			// 
			// TabRewards
			// 
			this.TabRewards.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.TabRewards.AppearancePage.Header.Options.UseFont = true;
			this.TabRewards.Location = new System.Drawing.Point(8, 48);
			this.TabRewards.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.TabRewards.LookAndFeel.UseDefaultLookAndFeel = false;
			this.TabRewards.Name = "TabRewards";
			this.TabRewards.SelectedTabPage = this.tabReward_Issue;
			this.TabRewards.Size = new System.Drawing.Size(800, 440);
			this.TabRewards.TabIndex = 132;
			this.TabRewards.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
																					   this.tabReward_Issue,
																					   this.tabReward_Catalogue});
			this.TabRewards.Text = "xtraTabControl1";
			this.TabRewards.Click += new System.EventHandler(this.grpMDRewardBelow_control);
			// 
			// tabReward_Issue
			// 
			this.tabReward_Issue.Controls.Add(this.groupControl3);
			this.tabReward_Issue.Controls.Add(this.grpMDRewardBelow);
			this.tabReward_Issue.Name = "tabReward_Issue";
			this.tabReward_Issue.Size = new System.Drawing.Size(791, 409);
			this.tabReward_Issue.Text = "Points Issue";
			// 
			// groupControl3
			// 
			this.groupControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.groupControl3.Controls.Add(this.gridControl1);
			this.groupControl3.Controls.Add(this.label4);
			this.groupControl3.Location = new System.Drawing.Point(0, 0);
			this.groupControl3.Name = "groupControl3";
			this.groupControl3.Size = new System.Drawing.Size(760, 200);
			this.groupControl3.TabIndex = 88;
			this.groupControl3.Text = "groupControl1";
			// 
			// gridControl1
			// 
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Top;
			// 
			// gridControl1.EmbeddedNavigator
			// 
			this.gridControl1.EmbeddedNavigator.Name = "";
			this.gridControl1.Location = new System.Drawing.Point(0, 0);
			this.gridControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												  this.Type_ComboBox,
																												  this.lk_LookupSalesCategory});
			this.gridControl1.Size = new System.Drawing.Size(760, 188);
			this.gridControl1.TabIndex = 31;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.strRewardsCode,
																							 this.strDescription,
																							 this.dRewardsPercent,
																							 this.dRewardsValue,
																							 this.dtValidStart,
																							 this.dtValidEnd,
																							 this.nSalesCategoryID,
																							 this.nTypeID});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsCustomization.AllowSort = false;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
			this.gridView1.LostFocus += new System.EventHandler(this.gridView1_LostFocus);
			// 
			// strRewardsCode
			// 
			this.strRewardsCode.Caption = "Reward";
			this.strRewardsCode.FieldName = "strRewardsCode";
			this.strRewardsCode.Name = "strRewardsCode";
			this.strRewardsCode.Visible = true;
			this.strRewardsCode.VisibleIndex = 0;
			this.strRewardsCode.Width = 87;
			// 
			// strDescription
			// 
			this.strDescription.Caption = "Description";
			this.strDescription.FieldName = "strDescription";
			this.strDescription.Name = "strDescription";
			this.strDescription.Visible = true;
			this.strDescription.VisibleIndex = 1;
			this.strDescription.Width = 247;
			// 
			// dRewardsPercent
			// 
			this.dRewardsPercent.Caption = "Percent";
			this.dRewardsPercent.FieldName = "dRewardsPercent";
			this.dRewardsPercent.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.dRewardsPercent.Name = "dRewardsPercent";
			this.dRewardsPercent.Visible = true;
			this.dRewardsPercent.VisibleIndex = 2;
			this.dRewardsPercent.Width = 72;
			// 
			// dRewardsValue
			// 
			this.dRewardsValue.Caption = "Value";
			this.dRewardsValue.FieldName = "dRewardsValue";
			this.dRewardsValue.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.dRewardsValue.Name = "dRewardsValue";
			this.dRewardsValue.Visible = true;
			this.dRewardsValue.VisibleIndex = 3;
			this.dRewardsValue.Width = 60;
			// 
			// dtValidStart
			// 
			this.dtValidStart.Caption = "Start Date";
			this.dtValidStart.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.dtValidStart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dtValidStart.FieldName = "dtValidStart";
			this.dtValidStart.Name = "dtValidStart";
			this.dtValidStart.Visible = true;
			this.dtValidStart.VisibleIndex = 4;
			this.dtValidStart.Width = 87;
			// 
			// dtValidEnd
			// 
			this.dtValidEnd.Caption = "End Date";
			this.dtValidEnd.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.dtValidEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dtValidEnd.FieldName = "dtValidEnd";
			this.dtValidEnd.Name = "dtValidEnd";
			this.dtValidEnd.Visible = true;
			this.dtValidEnd.VisibleIndex = 5;
			this.dtValidEnd.Width = 64;
			// 
			// nSalesCategoryID
			// 
			this.nSalesCategoryID.Caption = "Sales Category";
			this.nSalesCategoryID.ColumnEdit = this.lk_LookupSalesCategory;
			this.nSalesCategoryID.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.nSalesCategoryID.FieldName = "nSalesCategoryID";
			this.nSalesCategoryID.Name = "nSalesCategoryID";
			this.nSalesCategoryID.Visible = true;
			this.nSalesCategoryID.VisibleIndex = 6;
			this.nSalesCategoryID.Width = 78;
			// 
			// lk_LookupSalesCategory
			// 
			this.lk_LookupSalesCategory.AutoHeight = false;
			this.lk_LookupSalesCategory.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_LookupSalesCategory.Name = "lk_LookupSalesCategory";
			// 
			// nTypeID
			// 
			this.nTypeID.Caption = "Type";
			this.nTypeID.ColumnEdit = this.Type_ComboBox;
			this.nTypeID.FieldName = "nTypeID";
			this.nTypeID.Name = "nTypeID";
			this.nTypeID.Visible = true;
			this.nTypeID.VisibleIndex = 7;
			this.nTypeID.Width = 51;
			// 
			// Type_ComboBox
			// 
			this.Type_ComboBox.AutoHeight = false;
			this.Type_ComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																									   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.Type_ComboBox.Items.AddRange(new object[] {
															   "0 ",
															   "1"});
			this.Type_ComboBox.Name = "Type_ComboBox";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(-116, -24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(86, 34);
			this.label4.TabIndex = 30;
			this.label4.Text = "Package Branch";
			// 
			// grpMDRewardBelow
			// 
			this.grpMDRewardBelow.Controls.Add(this.grpMDPromotionBelow2);
			this.grpMDRewardBelow.Location = new System.Drawing.Point(0, 200);
			this.grpMDRewardBelow.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.grpMDRewardBelow.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpMDRewardBelow.LookAndFeel.UseWindowsXPTheme = false;
			this.grpMDRewardBelow.Name = "grpMDRewardBelow";
			this.grpMDRewardBelow.Size = new System.Drawing.Size(784, 208);
			this.grpMDRewardBelow.TabIndex = 144;
			this.grpMDRewardBelow.Text = "Branch Reward";
			// 
			// grpMDPromotionBelow2
			// 
			this.grpMDPromotionBelow2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.grpMDPromotionBelow2.Controls.Add(this.gridBranch2);
			this.grpMDPromotionBelow2.Controls.Add(this.gridBranch);
			this.grpMDPromotionBelow2.Controls.Add(this.btnBranch_Add);
			this.grpMDPromotionBelow2.Controls.Add(this.btnBranch_Del);
			this.grpMDPromotionBelow2.Controls.Add(this.btnBranch_DelAll);
			this.grpMDPromotionBelow2.Controls.Add(this.btnBranch_AddAll);
			this.grpMDPromotionBelow2.Location = new System.Drawing.Point(8, 24);
			this.grpMDPromotionBelow2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.grpMDPromotionBelow2.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpMDPromotionBelow2.Name = "grpMDPromotionBelow2";
			this.grpMDPromotionBelow2.ShowCaption = false;
			this.grpMDPromotionBelow2.Size = new System.Drawing.Size(896, 224);
			this.grpMDPromotionBelow2.TabIndex = 6;
			this.grpMDPromotionBelow2.Text = "groupControl1";
			// 
			// gridBranch2
			// 
			// 
			// gridBranch2.EmbeddedNavigator
			// 
			this.gridBranch2.EmbeddedNavigator.Name = "";
			this.gridBranch2.Location = new System.Drawing.Point(416, 8);
			this.gridBranch2.MainView = this.gvBranch2;
			this.gridBranch2.Name = "gridBranch2";
			this.gridBranch2.Size = new System.Drawing.Size(336, 176);
			this.gridBranch2.TabIndex = 29;
			this.gridBranch2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									   this.gvBranch2});
			// 
			// gvBranch2
			// 
			this.gvBranch2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn33,
																							 this.gridColumn34});
			this.gvBranch2.GridControl = this.gridBranch2;
			this.gvBranch2.Name = "gvBranch2";
			this.gvBranch2.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvBranch2.OptionsBehavior.Editable = false;
			this.gvBranch2.OptionsCustomization.AllowFilter = false;
			this.gvBranch2.OptionsSelection.MultiSelect = true;
			this.gvBranch2.OptionsView.ShowGroupPanel = false;
			this.gvBranch2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																									  new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn33, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// gridColumn33
			// 
			this.gridColumn33.Caption = "Branch";
			this.gridColumn33.FieldName = "strBranchCode";
			this.gridColumn33.Name = "gridColumn33";
			this.gridColumn33.Visible = true;
			this.gridColumn33.VisibleIndex = 0;
			this.gridColumn33.Width = 107;
			// 
			// gridColumn34
			// 
			this.gridColumn34.Caption = "Branch Name";
			this.gridColumn34.FieldName = "strBranchName";
			this.gridColumn34.Name = "gridColumn34";
			this.gridColumn34.Visible = true;
			this.gridColumn34.VisibleIndex = 1;
			this.gridColumn34.Width = 231;
			// 
			// gridBranch
			// 
			// 
			// gridBranch.EmbeddedNavigator
			// 
			this.gridBranch.EmbeddedNavigator.Name = "";
			this.gridBranch.Location = new System.Drawing.Point(8, 8);
			this.gridBranch.MainView = this.gvBranch;
			this.gridBranch.Name = "gridBranch";
			this.gridBranch.Size = new System.Drawing.Size(360, 176);
			this.gridBranch.TabIndex = 24;
			this.gridBranch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									  this.gvBranch});
			// 
			// gvBranch
			// 
			this.gvBranch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							this.gridColumn35,
																							this.gridColumn36});
			this.gvBranch.GridControl = this.gridBranch;
			this.gvBranch.Name = "gvBranch";
			this.gvBranch.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvBranch.OptionsBehavior.Editable = false;
			this.gvBranch.OptionsCustomization.AllowFilter = false;
			this.gvBranch.OptionsSelection.MultiSelect = true;
			this.gvBranch.OptionsView.ShowGroupPanel = false;
			this.gvBranch.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																									 new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn35, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// gridColumn35
			// 
			this.gridColumn35.Caption = "Branch";
			this.gridColumn35.FieldName = "strBranchCode";
			this.gridColumn35.Name = "gridColumn35";
			this.gridColumn35.Visible = true;
			this.gridColumn35.VisibleIndex = 0;
			this.gridColumn35.Width = 105;
			// 
			// gridColumn36
			// 
			this.gridColumn36.Caption = "Branch Name";
			this.gridColumn36.FieldName = "strBranchName";
			this.gridColumn36.Name = "gridColumn36";
			this.gridColumn36.Visible = true;
			this.gridColumn36.VisibleIndex = 1;
			this.gridColumn36.Width = 241;
			// 
			// btnBranch_Add
			// 
			this.btnBranch_Add.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnBranch_Add.Location = new System.Drawing.Point(376, 32);
			this.btnBranch_Add.Name = "btnBranch_Add";
			this.btnBranch_Add.Size = new System.Drawing.Size(32, 24);
			this.btnBranch_Add.TabIndex = 25;
			this.btnBranch_Add.Text = ">";
			this.btnBranch_Add.Click += new System.EventHandler(this.btnBranch_Add_Click);
			// 
			// btnBranch_Del
			// 
			this.btnBranch_Del.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnBranch_Del.Location = new System.Drawing.Point(376, 128);
			this.btnBranch_Del.Name = "btnBranch_Del";
			this.btnBranch_Del.Size = new System.Drawing.Size(32, 24);
			this.btnBranch_Del.TabIndex = 28;
			this.btnBranch_Del.Text = "<";
			this.btnBranch_Del.Click += new System.EventHandler(this.btnBranch_Del_Click);
			// 
			// btnBranch_DelAll
			// 
			this.btnBranch_DelAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnBranch_DelAll.Location = new System.Drawing.Point(376, 64);
			this.btnBranch_DelAll.Name = "btnBranch_DelAll";
			this.btnBranch_DelAll.Size = new System.Drawing.Size(32, 24);
			this.btnBranch_DelAll.TabIndex = 27;
			this.btnBranch_DelAll.Text = "<<";
			this.btnBranch_DelAll.Click += new System.EventHandler(this.btnBranch_DelAll_Click);
			// 
			// btnBranch_AddAll
			// 
			this.btnBranch_AddAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnBranch_AddAll.Location = new System.Drawing.Point(376, 96);
			this.btnBranch_AddAll.Name = "btnBranch_AddAll";
			this.btnBranch_AddAll.Size = new System.Drawing.Size(32, 24);
			this.btnBranch_AddAll.TabIndex = 26;
			this.btnBranch_AddAll.Text = ">>";
			this.btnBranch_AddAll.Click += new System.EventHandler(this.btnBranch_AddAll_Click);
			// 
			// tabReward_Catalogue
			// 
			this.tabReward_Catalogue.Controls.Add(this.groupControl4);
			this.tabReward_Catalogue.Name = "tabReward_Catalogue";
			this.tabReward_Catalogue.Size = new System.Drawing.Size(791, 409);
			this.tabReward_Catalogue.Text = "Catalogue";
			// 
			// groupControl4
			// 
			this.groupControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.groupControl4.Controls.Add(this.gridControl2);
			this.groupControl4.Controls.Add(this.label1);
			this.groupControl4.Location = new System.Drawing.Point(0, 0);
			this.groupControl4.Name = "groupControl4";
			this.groupControl4.Size = new System.Drawing.Size(768, 408);
			this.groupControl4.TabIndex = 89;
			this.groupControl4.Text = "groupControl1";
			// 
			// gridControl2
			// 
			this.gridControl2.Dock = System.Windows.Forms.DockStyle.Top;
			// 
			// gridControl2.EmbeddedNavigator
			// 
			this.gridControl2.EmbeddedNavigator.Name = "";
			this.gridControl2.Location = new System.Drawing.Point(0, 0);
			this.gridControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControl2.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControl2.MainView = this.gridView2;
			this.gridControl2.Name = "gridControl2";
			this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												  this.lk_LookupRewardItem});
			this.gridControl2.Size = new System.Drawing.Size(768, 408);
			this.gridControl2.TabIndex = 31;
			this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView2});
			this.gridControl2.DoubleClick += new System.EventHandler(this.gridView2_DoubleClick);
			// 
			// gridView2
			// 
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn1,
																							 this.gridColumn2,
																							 this.gridColumn3,
																							 this.gridColumn5,
																							 this.gridColumn6});
			this.gridView2.GridControl = this.gridControl2;
			this.gridView2.Name = "gridView2";
			this.gridView2.OptionsBehavior.Editable = false;
			this.gridView2.OptionsCustomization.AllowFilter = false;
			this.gridView2.OptionsCustomization.AllowSort = false;
			this.gridView2.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Item";
			this.gridColumn1.FieldName = "strItemCode";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			this.gridColumn1.Width = 70;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Description";
			this.gridColumn2.FieldName = "strDescription";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			this.gridColumn2.Width = 361;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Points";
			this.gridColumn3.FieldName = "dRewardsPoints";
			this.gridColumn3.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 2;
			this.gridColumn3.Width = 89;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "Start Date";
			this.gridColumn5.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.gridColumn5.FieldName = "dtValidStart";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 3;
			this.gridColumn5.Width = 114;
			// 
			// gridColumn6
			// 
			this.gridColumn6.Caption = "End Date";
			this.gridColumn6.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.gridColumn6.FieldName = "dtValidEnd";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 4;
			this.gridColumn6.Width = 104;
			// 
			// lk_LookupRewardItem
			// 
			this.lk_LookupRewardItem.AutoHeight = false;
			this.lk_LookupRewardItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_LookupRewardItem.Name = "lk_LookupRewardItem";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(-116, -24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 34);
			this.label1.TabIndex = 30;
			this.label1.Text = "Package Branch";
			// 
			// panelReward
			// 
			this.panelReward.Controls.Add(this.txtSearch);
			this.panelReward.Controls.Add(this.btn_Search);
			this.panelReward.Location = new System.Drawing.Point(376, 16);
			this.panelReward.Name = "panelReward";
			this.panelReward.Size = new System.Drawing.Size(408, 32);
			this.panelReward.TabIndex = 146;
			// 
			// txtSearch
			// 
			this.txtSearch.EditValue = "";
			this.txtSearch.Location = new System.Drawing.Point(104, 8);
			this.txtSearch.Name = "txtSearch";
			// 
			// txtSearch.Properties
			// 
			this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtSearch.Properties.Appearance.Options.UseFont = true;
			this.txtSearch.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.txtSearch.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.txtSearch.Size = new System.Drawing.Size(176, 20);
			this.txtSearch.TabIndex = 144;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			// 
			// btn_Search
			// 
			this.btn_Search.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btn_Search.Appearance.Options.UseFont = true;
			this.btn_Search.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_Search.Location = new System.Drawing.Point(304, 8);
			this.btn_Search.Name = "btn_Search";
			this.btn_Search.Size = new System.Drawing.Size(56, 20);
			this.btn_Search.TabIndex = 145;
			this.btn_Search.Text = "Search";
			this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
			// 
			// btn_Del
			// 
			this.btn_Del.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn_Del.Appearance.Options.UseFont = true;
			this.btn_Del.Appearance.Options.UseTextOptions = true;
			this.btn_Del.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.btn_Del.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.btn_Del.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.btn_Del.ImageIndex = 1;
			this.btn_Del.ImageList = this.imageList1;
			this.btn_Del.Location = new System.Drawing.Point(48, 24);
			this.btn_Del.Name = "btn_Del";
			this.btn_Del.Size = new System.Drawing.Size(38, 16);
			this.btn_Del.TabIndex = 142;
			this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
			// 
			// Btn_Add
			// 
			this.Btn_Add.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Btn_Add.Appearance.Options.UseFont = true;
			this.Btn_Add.Appearance.Options.UseTextOptions = true;
			this.Btn_Add.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.Btn_Add.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.Btn_Add.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.Btn_Add.ImageIndex = 0;
			this.Btn_Add.ImageList = this.imageList1;
			this.Btn_Add.ImeMode = System.Windows.Forms.ImeMode.On;
			this.Btn_Add.Location = new System.Drawing.Point(8, 24);
			this.Btn_Add.Name = "Btn_Add";
			this.Btn_Add.Size = new System.Drawing.Size(38, 16);
			this.Btn_Add.TabIndex = 143;
			this.Btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
			// 
			// frmReward
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(808, 496);
			this.Controls.Add(this.grpMDLeaveTop);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmReward";
			this.Text = "Reward";
			this.Load += new System.EventHandler(this.frmReward_Load);
			((System.ComponentModel.ISupportInitialize)(this.grpMDLeaveTop)).EndInit();
			this.grpMDLeaveTop.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
			this.groupControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.TabRewards)).EndInit();
			this.TabRewards.ResumeLayout(false);
			this.tabReward_Issue.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
			this.groupControl3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_LookupSalesCategory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Type_ComboBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grpMDRewardBelow)).EndInit();
			this.grpMDRewardBelow.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grpMDPromotionBelow2)).EndInit();
			this.grpMDPromotionBelow2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridBranch2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvBranch2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridBranch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvBranch)).EndInit();
			this.tabReward_Catalogue.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
			this.groupControl4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_LookupRewardItem)).EndInit();
			this.panelReward.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btn_Search_Click(object sender, System.EventArgs e)
		{
			mdRewardIssueInit();
			LoadBranch();
		}

		private void txtSearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btn_Search_Click(sender,e);
			}
		}

		
		private void gridView2_DoubleClick(object sender, System.EventArgs e)
		{
			DataRow row = this.gridView2.GetDataRow(gridView2.FocusedRowHandle);

			frmReward_Edit myRewardform;
			myRewardform = new frmReward_Edit(Convert.ToInt32(row["pkItemCode"]));
			myRewardform.ShowDialog();
			mdRewardCatalogueInit();
		}
	}


}
