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
	/// Summary description for frmInventory.
	/// </summary>
	public class frmInventory : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraEditors.GroupControl groupControl3;
		private System.Windows.Forms.Label label4;
		internal DevExpress.XtraEditors.SimpleButton btn_Del;
		internal DevExpress.XtraEditors.SimpleButton Btn_Add;
		private DevExpress.XtraEditors.GroupControl groupControl4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ImageList imageList1;
		private DevExpress.XtraTab.XtraTabControl TabInventory;
		private DevExpress.XtraTab.XtraTabPage tabStock;
		private DevExpress.XtraTab.XtraTabPage tabBrand;
		private DevExpress.XtraTab.XtraTabPage tabStyle;
		private DevExpress.XtraTab.XtraTabPage tabColor;
		private DevExpress.XtraTab.XtraTabPage tabSize;
		private DevExpress.XtraTab.XtraTabPage tabType;
		private DevExpress.XtraEditors.GroupControl grpMDPromotionBelow2;
		private DevExpress.XtraGrid.GridControl gridBranch2;
		private DevExpress.XtraGrid.GridControl gridBranch;
		private DevExpress.XtraEditors.SimpleButton btnBranch_Add;
		private DevExpress.XtraEditors.SimpleButton btnBranch_Del;
		private DevExpress.XtraEditors.SimpleButton btnBranch_DelAll;
		private DevExpress.XtraEditors.SimpleButton btnBranch_AddAll;
		private DevExpress.XtraGrid.Views.Grid.GridView gvBranch2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn34;
		private DevExpress.XtraGrid.Views.Grid.GridView gvBranch;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
		private DevExpress.XtraEditors.GroupControl groupControlBrand;
		private DevExpress.XtraEditors.GroupControl grpMDProductBelow;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
		private DevExpress.XtraGrid.GridControl gridControlStock;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewStock;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk_Valid;
		private DevExpress.XtraGrid.GridControl gridControlBrand;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewBrand;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_LookupRewardItem;
		private DevExpress.XtraGrid.GridControl gridControlStyle;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewStyle;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
		private DevExpress.XtraGrid.GridControl gridControlColor;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewColor;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit3;
		private DevExpress.XtraGrid.GridControl gridControlSize;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewSize;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit4;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit5;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.GridControl gridControlType;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewType;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit6;
		private System.Windows.Forms.Panel Stockpanel;
		internal DevExpress.XtraEditors.TextEdit txtStockScr;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn nQuantity;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_Brand;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_Style;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_Color;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_Size;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_Type;
		internal DevExpress.XtraEditors.SimpleButton btn_Search;
		private System.ComponentModel.IContainer components;

		public frmInventory()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
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

		
		private void frmInventory_Load(object sender, System.EventArgs e)
		{
			initInventory();
			mdBrandInit();
			mdColorInit();
			mdStyleInit();
			mdSizeInit();
			mdTypeInit();

		}

		#region Inventory
		
		private void initInventory()
		{
			lk_Brand_Init();
			lk_Style_Init();
			lk_Color_Init();
			lk_Size_Init();
			lk_Type_Init();

			string strSQL_Inv = "select * from tblProduct";
			mdInventoryInit(strSQL_Inv);

			LoadBranch();
		}

		private void lk_Brand_Init()
		{
			DataSet _ds = new DataSet();
			string strSQL;
			
			strSQL = "select * from tblBrand";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
						
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
						
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBrandCode","Brand ID",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
					
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_Brand,dt,col,"strDescription","strBrandCode","Brand");
		}


		private void lk_Style_Init()
		{
			DataSet _ds = new DataSet();
			string strSQL;
			
			strSQL = "select * from tblStyle";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
						
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
						
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strStyleCode","Style ID",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
					
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_Style,dt,col,"strDescription","strStyleCode","Style");
		}

		
		private void lk_Size_Init()
		{
			DataSet _ds = new DataSet();
			string strSQL;
			
			strSQL = "select * from tblSize";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
						
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
						
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strSizeCode","Size ID",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
					
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_Size,dt,col,"strDescription","strSizeCode","Size");
		}

		
		private void lk_Color_Init()
		{
			DataSet _ds = new DataSet();
			string strSQL;
			
			strSQL = "select * from tblColor";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
						
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
						
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strColorCode","Color ID",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
					
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_Color,dt,col,"strDescription","strColorCode","Color");
		}

		
		private void lk_Type_Init()
		{
			DataSet _ds = new DataSet();
			string strSQL;
			
			strSQL = "select * from tblProductType";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
						
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
						
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nProductTypeID","Type ID",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
					
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_Type,dt,col,"strDescription","nProductTypeID","Type");
		}

		private DataTable dtInventory;
		private DataTable dtBrand;
		private DataTable dtStyle;
		private DataTable dtColor;
		private DataTable dtSize;
		private DataTable dtType;
		 
		private void mdInventoryInit(string strSQL)
		{
			
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtInventory = _ds.Tables["table"];
			gridControlStock.DataSource = dtInventory;
		}


		private void mdBrandInit()
		{
			string strSQL;
			strSQL = "select * from tblBrand";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtBrand = _ds.Tables["table"];
			gridControlBrand.DataSource = dtBrand;
		}

		
		private void mdColorInit()
		{
			string strSQL;
			strSQL = "select * from tblColor";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtColor = _ds.Tables["table"];
			gridControlColor.DataSource = dtColor;
		}

		private void mdSizeInit()
		{
			string strSQL;
			strSQL = "select * from tblSize";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtSize = _ds.Tables["table"];
			gridControlSize.DataSource = dtSize;
		}

		private void mdStyleInit()
		{
			string strSQL;
			strSQL = "select * from tblStyle";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtStyle = _ds.Tables["table"];
			gridControlStyle.DataSource = dtStyle;
		}

		private void mdTypeInit()
		{
			string strSQL;
			strSQL = "select * from tblProductType";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dtType = _ds.Tables["table"];
			gridControlType.DataSource = dtType;
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
		
		private void gridViewStock_Save(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewStock.GetDataRow(gridViewStock.FocusedRowHandle);
			
			string strSQL = "Select * from TblProduct";
			if (AddNew)
			{
				
				if( CheckClassTypeField(row))
				{
					this.gridControlStock.MainView.UpdateCurrentRow();
					try
					{
						CreateCmdsAndUpdate(strSQL,dtInventory);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message ,"Delete Process Failed");
						return;
					}
						SqlHelper.ExecuteNonQuery(connection,"Set_ProductInventory",
							new SqlParameter("@ProductCode",row[0].ToString()));

					AddNew = false;
				}
			}
			else
			{
				this.gridViewStock.CloseEditor();
				gridViewStock.UpdateCurrentRow();
				CreateCmdsAndUpdate(strSQL,dtInventory);


			//	strSQL = "select strProductCode, strBranchCode, nQuantity from tblProductInventory Where strProductCode = '" + row["strProductCode"].ToString() + "'";
			//	gridBranch2.Update();
			//	CreateCmdsAndUpdate(strSQL,dtBranch);
				//CreateCmdsAndUpdate(strSQL,dtBranch2);

			}
		}

		private void gridViewBrand_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewBrand.GetDataRow(gridViewBrand.FocusedRowHandle);
			
			string strSQL = "Select * from TblBrand";
			if (AddNew)
			{
				if( CheckClassTypeField(row))
				{
//					this.gridControlBrand.MainView.UpdateCurrentRow();
//					try
//					{
//						CreateCmdsAndUpdate(strSQL,dtBrand);
//					}
//					catch (Exception ex)
//					{
//						MessageBox.Show(ex.Message ,"Delete Process Failed");
//						return;
//					}
					AddNew = false;
				}
			}
			else
			{
				this.gridViewBrand.CloseEditor();
				gridViewBrand.UpdateCurrentRow();
				CreateCmdsAndUpdate(strSQL,dtBrand);
			}
		}

		private void gridViewColor_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewColor.GetDataRow(gridViewColor.FocusedRowHandle);
			
			string strSQL = "Select * from TblColor";
			if (AddNew)
			{
				if( CheckClassTypeField(row))
				{
//					this.gridControlColor.MainView.UpdateCurrentRow();
//					try
//					{
//						CreateCmdsAndUpdate(strSQL,dtColor);
//					}
//					catch (Exception ex)
//					{
//						MessageBox.Show(ex.Message ,"Delete Process Failed");
//						return;
//					}
					AddNew = false;
				}
			}
			else
			{
				this.gridViewColor.CloseEditor();
				gridViewColor.UpdateCurrentRow();
				CreateCmdsAndUpdate(strSQL,dtColor);
			}
		}

		private void gridViewStyle_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewStyle.GetDataRow(gridViewStyle.FocusedRowHandle);
			
			string strSQL = "Select * from TblStyle";
			if (AddNew)
			{
				if( CheckClassTypeField(row))
				{
//					this.gridControlStyle.MainView.UpdateCurrentRow();
//					try
//					{
//						CreateCmdsAndUpdate(strSQL,dtStyle);
//					}
//					catch (Exception ex)
//					{
//						MessageBox.Show(ex.Message ,"Delete Process Failed");
//						return;
//					}
					AddNew = false;
				}
			}
			else
			{
				this.gridViewStyle.CloseEditor();
				gridViewStyle.UpdateCurrentRow();
				CreateCmdsAndUpdate(strSQL,dtStyle);
			}
		}

		private void gridViewSize_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewSize.GetDataRow(gridViewSize.FocusedRowHandle);
			string strSQL = "Select * from TblSize";
			if (AddNew)
			{
				if( CheckClassTypeField(row))
				{
					AddNew = false;
				}
			}
			else
			{
				this.gridViewSize.CloseEditor();
				gridViewSize.UpdateCurrentRow();
				CreateCmdsAndUpdate(strSQL,dtSize);
			}
		}

		private void gridViewType_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewType.GetDataRow(gridViewType.FocusedRowHandle);
			
			string strSQL = "Select * from TblProductType";
			if (AddNew)
			{
				if( CheckClassTypeField(row))
				{
//					this.gridControlType.MainView.UpdateCurrentRow();
//					try
//					{
//						CreateCmdsAndUpdate(strSQL,dtType);
//					}
//					catch (Exception ex)
//					{
//						MessageBox.Show(ex.Message ,"Delete Process Failed");
//						return;
//					}
					AddNew = false;
				}
			}
			else
			{
				this.gridViewType.CloseEditor();
				gridViewType.UpdateCurrentRow();
				CreateCmdsAndUpdate(strSQL,dtType);
			}
		}

		private void gridViewStock_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			LoadBranch();
		}


		private void btn_Add_Click(object sender, System.EventArgs e)
		{
			AddNew = true;
			if (TabInventory.SelectedTabPage.Text == "Stock")
			{
				DataRow dr = dtInventory.NewRow();
				dtInventory.Rows.Add(dr);
				this.gridControlStock.Refresh();
				this.gridViewStock.FocusedRowHandle = dtInventory.Rows.Count - 1;
			}
			else if (TabInventory.SelectedTabPage.Text == "Brand")
			{
				DataRow dr = dtBrand.NewRow();
				dtBrand.Rows.Add(dr);
				this.gridControlBrand.Refresh();
				this.gridViewBrand.FocusedRowHandle = dtBrand.Rows.Count - 1;
			}
			else if (TabInventory.SelectedTabPage.Text == "Style")
			{
				DataRow dr = dtStyle.NewRow();
				dtStyle.Rows.Add(dr);
				this.gridControlStyle.Refresh();
				this.gridViewStyle.FocusedRowHandle = dtStyle.Rows.Count - 1;
			}
			else if (TabInventory.SelectedTabPage.Text == "Color")
			{
				DataRow dr = dtColor.NewRow();
				dtColor.Rows.Add(dr);
				this.gridControlColor.Refresh();
				this.gridViewColor.FocusedRowHandle = dtColor.Rows.Count - 1;
			}
			else if (TabInventory.SelectedTabPage.Text == "Size")
			{
				DataRow dr = dtSize.NewRow();
				dtSize.Rows.Add(dr);
				this.gridControlSize.Refresh();
				this.gridViewSize.FocusedRowHandle = dtSize.Rows.Count - 1;
			}
			else if (TabInventory.SelectedTabPage.Text == "Type")
			{
				DataRow dr = dtType.NewRow();
				dtType.Rows.Add(dr);
				this.gridControlType.Refresh();
				this.gridViewType.FocusedRowHandle = dtType.Rows.Count - 1;
			}

		}


		private void btn_Del_Click(object sender, System.EventArgs e){
			if (TabInventory.SelectedTabPage.Text == "Stock")
			{
				del_ProductItem(gridViewStock,dtInventory,1);
				initInventory();
			}
			else if (TabInventory.SelectedTabPage.Text == "Brand")
			{
				del_ProductItem(gridViewBrand,dtBrand,2);
				mdBrandInit();
			}
			else if (TabInventory.SelectedTabPage.Text == "Style")
			{
				del_ProductItem(gridViewStyle,dtStyle,3);
				mdStyleInit();
			}
			else if (TabInventory.SelectedTabPage.Text == "Color")
			{
				del_ProductItem(gridViewColor,dtColor,4);
				mdColorInit();
			}
			else if (TabInventory.SelectedTabPage.Text == "Size")
			{
				del_ProductItem(gridViewSize,dtSize,5);
				mdSizeInit();
			}
			else if (TabInventory.SelectedTabPage.Text == "Type")
			{
				del_ProductItem(gridViewType,dtType,6);
				mdTypeInit();
			}
			
            }

		private void del_ProductItem(DevExpress.XtraGrid.Views.Grid.GridView gridView,DataTable myTableName, int option)
			{
				DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);
				if (row != null)
				{
					if (AddNew)
					{
						AddNew = false;
						gridView.DeleteRow(gridView.FocusedRowHandle);
					}
					else
					{
						DialogResult result = MessageBox.Show(this, "Do you want to delete this record " + row[1].ToString(),
							"Delete?", MessageBoxButtons.YesNo);
						if (result == DialogResult.Yes)
						{
							try
							{
							SqlHelper.ExecuteNonQuery(connection,"del_ProductMaster",
							new SqlParameter("@DelCode",row[0].ToString()),
							new SqlParameter("@DelType",option)
							);
							}
							catch(Exception ex)
							{
								MessageBox.Show(ex.Message ,"Delete Process Failed");
								return;
							}
							MessageBox.Show("Record Deleted Successfully","Message");
						}
					}
				}
			}

		#endregion
		#region Branch

		private DataTable dtBranch;
		//private DataTable dtBranch2;


		private void btnBranch_Add_Click(object sender, System.EventArgs e)
		{
			DataRow dr = gridViewStock.GetDataRow(gridViewStock.FocusedRowHandle);

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
				rNew["strProductCode"] = dr["strProductCode"];
				rNew["strBranchCode"] = rCopy["strBranchCode"];
				rNew["strBranchName"] = rCopy["strBranchName"];
				rNew["nQuantity"] = rCopy["nQuantity"];
				rNew.EndEdit();
				dtBranch.Rows.Add(rNew);
			}

			gvBranch.DeleteSelectedRows();
						
			try
			{
				//string strSQL =  "select  A.strBranchCode, B.strBranchName, A.StrProductCode,C.nQuantity  from tblproductbranch ";
				//strSQL += " A left join tblbranch B on A.strbranchcode=B.strbranchcode, tblproductInventory C where B.strBranchCode=C.strBranchCode ";
				//strSQL += " and C.strProductCode ='" + dr["strProductCode"].ToString() + "' and A.strProductCode ='" + dr["strProductCode"].ToString() + "' ";
				//strSQL += " and A.strbranchcode in (select strbranchcode from tblbranch)";
				//		
				
				string strSQL = "select strProductCode, strBranchCode from tblProductBranch Where strProductCode = '" + dr["strProductCode"].ToString() + "'";
				CreateCmdsAndUpdate(strSQL,dtBranch);
			}
			catch (Exception)
			{
				return;
			}
		}

		private void btnBranch_DelAll_Click(object sender, System.EventArgs e)
		{
			DataRow dr = gridViewStock.GetDataRow(gridViewStock.FocusedRowHandle);

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
				rNew["nQuantity"] = rCopy["nQuantity"];
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

			string strSQL = "select strProductCode, strBranchCode from tblProductBranch Where strProductCode = '" + dr["strProductCode"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtBranch);
		}

		private void btnBranch_AddAll_Click(object sender, System.EventArgs e)
		{
			gvBranch.BeginDataUpdate();
			gvBranch2.BeginDataUpdate();

			DataRow dr = gridViewStock.GetDataRow(gridViewStock.FocusedRowHandle);
			DataTable dtTemp = (gvBranch.DataSource as DataView).Table;
			//dtTemp.RejectChanges();
			dtTemp.AcceptChanges();

			for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
			{
				DataRow rCopy = gvBranch.GetDataRow(i);
				DataRow rNew = dtBranch.NewRow();
				rNew.BeginEdit();
				rNew["strProductCode"] = dr["strProductCode"];
				rNew["strBranchCode"] = rCopy["strBranchCode"];
				rNew["strBranchName"] = rCopy["strBranchName"];
				rNew["nQuantity"] = rCopy["nQuantity"];
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

			string strSQL = "select strProductCode, strBranchCode from tblProductBranch Where strProductCode = '" + dr["strProductCode"].ToString() + "'";
			CreateCmdsAndUpdate(strSQL,dtBranch);
		}

		private void btnBranch_Del_Click(object sender, System.EventArgs e)
		{
			DataRow dr = gridViewStock.GetDataRow(gridViewStock.FocusedRowHandle);

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
				rNew["nQuantity"] = rCopy["nQuantity"];
				rNew.EndEdit();
				dtTemp.Rows.Add(rNew);
			}
			gvBranch2.DeleteSelectedRows();

			try
			{
				string strSQL = "select strProductCode, strBranchCode from tblProductBranch Where strProductCode = '" + dr["strProductCode"].ToString() + "'";
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
			DataRow dr = this.gridViewStock.GetDataRow(this.gridViewStock.FocusedRowHandle);

		//	DataRow row = this.gridViewStock.GetDataRow(gridViewStock.FocusedRowHandle);
		
			try
			{
				SqlHelper.ExecuteNonQuery(connection,"Set_ProductInventory",
					new SqlParameter("@ProductCode",dr[0].ToString()));
			}
			catch (Exception ex)
				{
						MessageBox.Show(ex.Message ,"Loading Process Failed");
						return;
				}
			
			
			if (dr == null)
				return;

			string strSQL;

			strSQL =  "select  A.strBranchCode, B.strBranchName, A.StrProductCode,A.nQuantity ";  
			strSQL += "from tblproductinventory  A left join tblbranch B on A.strbranchcode = B.strbranchcode where ";
			strSQL += "A.strProductCode ='" + dr["strProductCode"].ToString() + "' ";
			strSQL += "and B.strBranchCode Not In ";
			strSQL += "(Select strBranchCode From tblproductBranch Where ";
			strSQL += "strProductCode ='" + dr["strProductCode"].ToString() + "')";

			//	strSQL = "select strBranchCode, strBranchName from TblBranch Where strBranchCode Not In (Select strBranchCode From tblproductBranch Where strProductCode = '" + dr["strProductCode"].ToString() + "')";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			this.gridBranch.DataSource = _ds.Tables["table"];
		
			strSQL =  "select  A.strBranchCode, B.strBranchName, A.StrProductCode,C.nQuantity  from tblproductbranch ";
			strSQL += " A left join tblbranch B on A.strbranchcode=B.strbranchcode, tblproductInventory C where B.strBranchCode=C.strBranchCode ";
			strSQL += " and C.strProductCode ='" + dr["strProductCode"].ToString() + "' and A.strProductCode ='" + dr["strProductCode"].ToString() + "' ";
			strSQL += " and A.strbranchcode in (select strbranchcode from tblbranch)";
//			strSQL = "select P.strProductCode, B.strBranchCode, strBranchName from tblProductBranch P Inner Join TblBranch B On B.strBranchCode = P.strBranchCode Where P.strProductCode = '" + dr["strProductCode"].ToString() + "'";
			_ds = new DataSet();
			
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			
			dtBranch = _ds.Tables["table"];
			gridBranch2.DataSource = dtBranch;
		}
		#endregion

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmInventory));
			this.groupControlBrand = new DevExpress.XtraEditors.GroupControl();
			this.Stockpanel = new System.Windows.Forms.Panel();
			this.btn_Search = new DevExpress.XtraEditors.SimpleButton();
			this.txtStockScr = new DevExpress.XtraEditors.TextEdit();
			this.TabInventory = new DevExpress.XtraTab.XtraTabControl();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.tabStock = new DevExpress.XtraTab.XtraTabPage();
			this.grpMDProductBelow = new DevExpress.XtraEditors.GroupControl();
			this.grpMDPromotionBelow2 = new DevExpress.XtraEditors.GroupControl();
			this.gridBranch2 = new DevExpress.XtraGrid.GridControl();
			this.gvBranch2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.nQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridBranch = new DevExpress.XtraGrid.GridControl();
			this.gvBranch = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.btnBranch_Add = new DevExpress.XtraEditors.SimpleButton();
			this.btnBranch_Del = new DevExpress.XtraEditors.SimpleButton();
			this.btnBranch_DelAll = new DevExpress.XtraEditors.SimpleButton();
			this.btnBranch_AddAll = new DevExpress.XtraEditors.SimpleButton();
			this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
			this.gridControlStock = new DevExpress.XtraGrid.GridControl();
			this.gridViewStock = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_Brand = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_Style = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_Color = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_Size = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_Type = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.chk_Valid = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.label4 = new System.Windows.Forms.Label();
			this.tabBrand = new DevExpress.XtraTab.XtraTabPage();
			this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
			this.gridControlBrand = new DevExpress.XtraGrid.GridControl();
			this.gridViewBrand = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.lk_LookupRewardItem = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.tabStyle = new DevExpress.XtraTab.XtraTabPage();
			this.gridControlStyle = new DevExpress.XtraGrid.GridControl();
			this.gridViewStyle = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.tabColor = new DevExpress.XtraTab.XtraTabPage();
			this.gridControlColor = new DevExpress.XtraGrid.GridControl();
			this.gridViewColor = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.repositoryItemLookUpEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.tabSize = new DevExpress.XtraTab.XtraTabPage();
			this.gridControlSize = new DevExpress.XtraGrid.GridControl();
			this.gridViewSize = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.repositoryItemLookUpEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.tabType = new DevExpress.XtraTab.XtraTabPage();
			this.gridControlType = new DevExpress.XtraGrid.GridControl();
			this.gridViewType = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.repositoryItemLookUpEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.Btn_Add = new DevExpress.XtraEditors.SimpleButton();
			this.btn_Del = new DevExpress.XtraEditors.SimpleButton();
			this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.repositoryItemLookUpEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			((System.ComponentModel.ISupportInitialize)(this.groupControlBrand)).BeginInit();
			this.groupControlBrand.SuspendLayout();
			this.Stockpanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtStockScr.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TabInventory)).BeginInit();
			this.TabInventory.SuspendLayout();
			this.tabStock.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpMDProductBelow)).BeginInit();
			this.grpMDProductBelow.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpMDPromotionBelow2)).BeginInit();
			this.grpMDPromotionBelow2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridBranch2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvBranch2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridBranch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvBranch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
			this.groupControl3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControlStock)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewStock)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Brand)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Style)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Color)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Size)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Type)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_Valid)).BeginInit();
			this.tabBrand.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
			this.groupControl4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControlBrand)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewBrand)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_LookupRewardItem)).BeginInit();
			this.tabStyle.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControlStyle)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewStyle)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
			this.tabColor.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControlColor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewColor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).BeginInit();
			this.tabSize.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControlSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).BeginInit();
			this.tabType.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControlType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			this.SuspendLayout();
			// 
			// groupControlBrand
			// 
			this.groupControlBrand.Appearance.BackColor = System.Drawing.Color.LightGray;
			this.groupControlBrand.Appearance.Options.UseBackColor = true;
			this.groupControlBrand.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControlBrand.AppearanceCaption.Options.UseFont = true;
			this.groupControlBrand.Controls.Add(this.Stockpanel);
			this.groupControlBrand.Controls.Add(this.TabInventory);
			this.groupControlBrand.Controls.Add(this.Btn_Add);
			this.groupControlBrand.Controls.Add(this.btn_Del);
			this.groupControlBrand.ImeMode = System.Windows.Forms.ImeMode.On;
			this.groupControlBrand.Location = new System.Drawing.Point(0, 0);
			this.groupControlBrand.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.groupControlBrand.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupControlBrand.LookAndFeel.UseWindowsXPTheme = false;
			this.groupControlBrand.Name = "groupControlBrand";
			this.groupControlBrand.Size = new System.Drawing.Size(784, 488);
			this.groupControlBrand.TabIndex = 140;
			this.groupControlBrand.Text = "Inventory";
			// 
			// Stockpanel
			// 
			this.Stockpanel.BackColor = System.Drawing.Color.Transparent;
			this.Stockpanel.Controls.Add(this.btn_Search);
			this.Stockpanel.Controls.Add(this.txtStockScr);
			this.Stockpanel.Location = new System.Drawing.Point(296, 24);
			this.Stockpanel.Name = "Stockpanel";
			this.Stockpanel.Size = new System.Drawing.Size(456, 24);
			this.Stockpanel.TabIndex = 148;
			// 
			// btn_Search
			// 
			this.btn_Search.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btn_Search.Appearance.Options.UseFont = true;
			this.btn_Search.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_Search.Location = new System.Drawing.Point(392, 0);
			this.btn_Search.Name = "btn_Search";
			this.btn_Search.Size = new System.Drawing.Size(56, 20);
			this.btn_Search.TabIndex = 137;
			this.btn_Search.Text = "Search";
			this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
			// 
			// txtStockScr
			// 
			this.txtStockScr.EditValue = "";
			this.txtStockScr.Location = new System.Drawing.Point(232, 0);
			this.txtStockScr.Name = "txtStockScr";
			// 
			// txtStockScr.Properties
			// 
			this.txtStockScr.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtStockScr.Properties.Appearance.Options.UseFont = true;
			this.txtStockScr.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.txtStockScr.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.txtStockScr.Size = new System.Drawing.Size(152, 20);
			this.txtStockScr.TabIndex = 136;
			this.txtStockScr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			// 
			// TabInventory
			// 
			this.TabInventory.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.TabInventory.AppearancePage.Header.Options.UseFont = true;
			this.TabInventory.Images = this.imageList1;
			this.TabInventory.Location = new System.Drawing.Point(8, 48);
			this.TabInventory.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.TabInventory.LookAndFeel.UseDefaultLookAndFeel = false;
			this.TabInventory.Name = "TabInventory";
			this.TabInventory.SelectedTabPage = this.tabStock;
			this.TabInventory.Size = new System.Drawing.Size(768, 440);
			this.TabInventory.TabIndex = 132;
			this.TabInventory.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
																						 this.tabStock,
																						 this.tabBrand,
																						 this.tabStyle,
																						 this.tabColor,
																						 this.tabSize,
																						 this.tabType});
			this.TabInventory.Text = "xtraTabControl1";
			this.TabInventory.Click += new System.EventHandler(this.TabInventory_Click);
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
			// 
			// tabStock
			// 
			this.tabStock.Controls.Add(this.grpMDProductBelow);
			this.tabStock.Controls.Add(this.groupControl3);
			this.tabStock.Name = "tabStock";
			this.tabStock.Size = new System.Drawing.Size(762, 413);
			this.tabStock.Text = "Stock";
			// 
			// grpMDProductBelow
			// 
			this.grpMDProductBelow.Controls.Add(this.grpMDPromotionBelow2);
			this.grpMDProductBelow.Location = new System.Drawing.Point(0, 200);
			this.grpMDProductBelow.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.grpMDProductBelow.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpMDProductBelow.LookAndFeel.UseWindowsXPTheme = false;
			this.grpMDProductBelow.Name = "grpMDProductBelow";
			this.grpMDProductBelow.Size = new System.Drawing.Size(760, 208);
			this.grpMDProductBelow.TabIndex = 145;
			this.grpMDProductBelow.Text = "Branch Product";
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
			this.grpMDPromotionBelow2.Size = new System.Drawing.Size(744, 176);
			this.grpMDPromotionBelow2.TabIndex = 6;
			this.grpMDPromotionBelow2.Text = "groupControl1";
			// 
			// gridBranch2
			// 
			// 
			// gridBranch2.EmbeddedNavigator
			// 
			this.gridBranch2.EmbeddedNavigator.Name = "";
			this.gridBranch2.Location = new System.Drawing.Point(408, 8);
			this.gridBranch2.MainView = this.gvBranch2;
			this.gridBranch2.Name = "gridBranch2";
			this.gridBranch2.Size = new System.Drawing.Size(328, 160);
			this.gridBranch2.TabIndex = 29;
			this.gridBranch2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									   this.gvBranch2});
			// 
			// gvBranch2
			// 
			this.gvBranch2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn33,
																							 this.gridColumn34,
																							 this.nQuantity});
			this.gvBranch2.GridControl = this.gridBranch2;
			this.gvBranch2.Name = "gvBranch2";
			this.gvBranch2.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvBranch2.OptionsCustomization.AllowFilter = false;
			this.gvBranch2.OptionsSelection.MultiSelect = true;
			this.gvBranch2.OptionsView.ShowGroupPanel = false;
			this.gvBranch2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																									  new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn33, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.gvBranch2.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.Update_Quantity);
			// 
			// gridColumn33
			// 
			this.gridColumn33.Caption = "Branch";
			this.gridColumn33.FieldName = "strBranchCode";
			this.gridColumn33.Name = "gridColumn33";
			this.gridColumn33.OptionsColumn.AllowEdit = false;
			this.gridColumn33.Visible = true;
			this.gridColumn33.VisibleIndex = 0;
			this.gridColumn33.Width = 107;
			// 
			// gridColumn34
			// 
			this.gridColumn34.Caption = "Branch Name";
			this.gridColumn34.FieldName = "strBranchName";
			this.gridColumn34.Name = "gridColumn34";
			this.gridColumn34.OptionsColumn.AllowEdit = false;
			this.gridColumn34.Visible = true;
			this.gridColumn34.VisibleIndex = 1;
			this.gridColumn34.Width = 231;
			// 
			// nQuantity
			// 
			this.nQuantity.Caption = "Quantity";
			this.nQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.nQuantity.FieldName = "nQuantity";
			this.nQuantity.Name = "nQuantity";
			this.nQuantity.Visible = true;
			this.nQuantity.VisibleIndex = 2;
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
			this.gridBranch.Size = new System.Drawing.Size(344, 160);
			this.gridBranch.TabIndex = 24;
			this.gridBranch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									  this.gvBranch});
			// 
			// gvBranch
			// 
			this.gvBranch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							this.gridColumn35,
																							this.gridColumn36,
																							this.gridColumn1});
			this.gvBranch.GridControl = this.gridBranch;
			this.gvBranch.Name = "gvBranch";
			this.gvBranch.OptionsBehavior.AllowIncrementalSearch = true;
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
			this.gridColumn35.OptionsColumn.AllowEdit = false;
			this.gridColumn35.Visible = true;
			this.gridColumn35.VisibleIndex = 0;
			this.gridColumn35.Width = 105;
			// 
			// gridColumn36
			// 
			this.gridColumn36.Caption = "Branch Name";
			this.gridColumn36.FieldName = "strBranchName";
			this.gridColumn36.Name = "gridColumn36";
			this.gridColumn36.OptionsColumn.AllowEdit = false;
			this.gridColumn36.Visible = true;
			this.gridColumn36.VisibleIndex = 1;
			this.gridColumn36.Width = 241;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Quantity";
			this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn1.FieldName = "nQuantity";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsColumn.AllowEdit = false;
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 2;
			// 
			// btnBranch_Add
			// 
			this.btnBranch_Add.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnBranch_Add.Location = new System.Drawing.Point(360, 32);
			this.btnBranch_Add.Name = "btnBranch_Add";
			this.btnBranch_Add.Size = new System.Drawing.Size(32, 24);
			this.btnBranch_Add.TabIndex = 25;
			this.btnBranch_Add.Text = ">";
			this.btnBranch_Add.Click += new System.EventHandler(this.btnBranch_Add_Click);
			// 
			// btnBranch_Del
			// 
			this.btnBranch_Del.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnBranch_Del.Location = new System.Drawing.Point(360, 128);
			this.btnBranch_Del.Name = "btnBranch_Del";
			this.btnBranch_Del.Size = new System.Drawing.Size(32, 24);
			this.btnBranch_Del.TabIndex = 28;
			this.btnBranch_Del.Text = "<";
			this.btnBranch_Del.Click += new System.EventHandler(this.btnBranch_Del_Click);
			// 
			// btnBranch_DelAll
			// 
			this.btnBranch_DelAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnBranch_DelAll.Location = new System.Drawing.Point(360, 64);
			this.btnBranch_DelAll.Name = "btnBranch_DelAll";
			this.btnBranch_DelAll.Size = new System.Drawing.Size(32, 24);
			this.btnBranch_DelAll.TabIndex = 27;
			this.btnBranch_DelAll.Text = "<<";
			this.btnBranch_DelAll.Click += new System.EventHandler(this.btnBranch_DelAll_Click);
			// 
			// btnBranch_AddAll
			// 
			this.btnBranch_AddAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnBranch_AddAll.Location = new System.Drawing.Point(360, 96);
			this.btnBranch_AddAll.Name = "btnBranch_AddAll";
			this.btnBranch_AddAll.Size = new System.Drawing.Size(32, 24);
			this.btnBranch_AddAll.TabIndex = 26;
			this.btnBranch_AddAll.Text = ">>";
			this.btnBranch_AddAll.Click += new System.EventHandler(this.btnBranch_AddAll_Click);
			// 
			// groupControl3
			// 
			this.groupControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.groupControl3.Controls.Add(this.gridControlStock);
			this.groupControl3.Controls.Add(this.label4);
			this.groupControl3.Location = new System.Drawing.Point(0, 0);
			this.groupControl3.Name = "groupControl3";
			this.groupControl3.Size = new System.Drawing.Size(760, 192);
			this.groupControl3.TabIndex = 88;
			this.groupControl3.Text = "groupControl3";
			// 
			// gridControlStock
			// 
			this.gridControlStock.Dock = System.Windows.Forms.DockStyle.Top;
			// 
			// gridControlStock.EmbeddedNavigator
			// 
			this.gridControlStock.EmbeddedNavigator.Name = "";
			this.gridControlStock.Location = new System.Drawing.Point(0, 0);
			this.gridControlStock.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlStock.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControlStock.MainView = this.gridViewStock;
			this.gridControlStock.Name = "gridControlStock";
			this.gridControlStock.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																													  this.chk_Valid,
																													  this.lk_Brand,
																													  this.lk_Style,
																													  this.lk_Color,
																													  this.lk_Size,
																													  this.lk_Type});
			this.gridControlStock.Size = new System.Drawing.Size(760, 192);
			this.gridControlStock.TabIndex = 144;
			this.gridControlStock.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											this.gridViewStock});
			// 
			// gridViewStock
			// 
			this.gridViewStock.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																								 this.gridColumn4,
																								 this.gridColumn7,
																								 this.gridColumn8,
																								 this.gridColumn9,
																								 this.gridColumn10,
																								 this.gridColumn11,
																								 this.gridColumn15,
																								 this.gridColumn12,
																								 this.gridColumn13,
																								 this.gridColumn14,
																								 this.gridColumn16,
																								 this.gridColumn17});
			this.gridViewStock.GridControl = this.gridControlStock;
			this.gridViewStock.Name = "gridViewStock";
			this.gridViewStock.OptionsCustomization.AllowFilter = false;
			this.gridViewStock.OptionsCustomization.AllowSort = false;
			this.gridViewStock.OptionsView.ShowGroupPanel = false;
			this.gridViewStock.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewStock_FocusedRowChanged);
			this.gridViewStock.LostFocus += new System.EventHandler(this.gridViewStock_Save);
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Code";
			this.gridColumn4.FieldName = "strProductCode";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 0;
			this.gridColumn4.Width = 73;
			// 
			// gridColumn7
			// 
			this.gridColumn7.Caption = "Description";
			this.gridColumn7.FieldName = "strDescription";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 1;
			this.gridColumn7.Width = 200;
			// 
			// gridColumn8
			// 
			this.gridColumn8.Caption = "Brand";
			this.gridColumn8.ColumnEdit = this.lk_Brand;
			this.gridColumn8.FieldName = "strBrandCode";
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.Visible = true;
			this.gridColumn8.VisibleIndex = 2;
			this.gridColumn8.Width = 45;
			// 
			// lk_Brand
			// 
			this.lk_Brand.AutoHeight = false;
			this.lk_Brand.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																								  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_Brand.Name = "lk_Brand";
			// 
			// gridColumn9
			// 
			this.gridColumn9.Caption = "Style";
			this.gridColumn9.ColumnEdit = this.lk_Style;
			this.gridColumn9.FieldName = "strStyleCode";
			this.gridColumn9.Name = "gridColumn9";
			this.gridColumn9.Visible = true;
			this.gridColumn9.VisibleIndex = 3;
			this.gridColumn9.Width = 41;
			// 
			// lk_Style
			// 
			this.lk_Style.AutoHeight = false;
			this.lk_Style.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																								  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_Style.Name = "lk_Style";
			// 
			// gridColumn10
			// 
			this.gridColumn10.Caption = "Color";
			this.gridColumn10.ColumnEdit = this.lk_Color;
			this.gridColumn10.FieldName = "strColorCode";
			this.gridColumn10.Name = "gridColumn10";
			this.gridColumn10.Visible = true;
			this.gridColumn10.VisibleIndex = 4;
			this.gridColumn10.Width = 43;
			// 
			// lk_Color
			// 
			this.lk_Color.AutoHeight = false;
			this.lk_Color.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																								  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_Color.Name = "lk_Color";
			// 
			// gridColumn11
			// 
			this.gridColumn11.Caption = "Size";
			this.gridColumn11.ColumnEdit = this.lk_Size;
			this.gridColumn11.FieldName = "strSizeCode";
			this.gridColumn11.Name = "gridColumn11";
			this.gridColumn11.Visible = true;
			this.gridColumn11.VisibleIndex = 5;
			this.gridColumn11.Width = 33;
			// 
			// lk_Size
			// 
			this.lk_Size.AutoHeight = false;
			this.lk_Size.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																								 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_Size.Name = "lk_Size";
			// 
			// gridColumn15
			// 
			this.gridColumn15.Caption = "Type";
			this.gridColumn15.ColumnEdit = this.lk_Type;
			this.gridColumn15.FieldName = "nProductTypeId";
			this.gridColumn15.Name = "gridColumn15";
			this.gridColumn15.Visible = true;
			this.gridColumn15.VisibleIndex = 6;
			this.gridColumn15.Width = 37;
			// 
			// lk_Type
			// 
			this.lk_Type.AutoHeight = false;
			this.lk_Type.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																								 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_Type.Name = "lk_Type";
			// 
			// gridColumn12
			// 
			this.gridColumn12.Caption = "Start";
			this.gridColumn12.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.gridColumn12.FieldName = "dtValidStart";
			this.gridColumn12.Name = "gridColumn12";
			this.gridColumn12.Visible = true;
			this.gridColumn12.VisibleIndex = 7;
			this.gridColumn12.Width = 50;
			// 
			// gridColumn13
			// 
			this.gridColumn13.Caption = "End";
			this.gridColumn13.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.gridColumn13.FieldName = "dtValidEnd";
			this.gridColumn13.Name = "gridColumn13";
			this.gridColumn13.Visible = true;
			this.gridColumn13.VisibleIndex = 8;
			this.gridColumn13.Width = 54;
			// 
			// gridColumn14
			// 
			this.gridColumn14.Caption = "Category";
			this.gridColumn14.FieldName = "nCategoryID";
			this.gridColumn14.Name = "gridColumn14";
			this.gridColumn14.Visible = true;
			this.gridColumn14.VisibleIndex = 9;
			this.gridColumn14.Width = 58;
			// 
			// gridColumn16
			// 
			this.gridColumn16.Caption = "Unit Price";
			this.gridColumn16.FieldName = "mBaseUnitPrice";
			this.gridColumn16.Name = "gridColumn16";
			this.gridColumn16.Visible = true;
			this.gridColumn16.VisibleIndex = 10;
			this.gridColumn16.Width = 54;
			// 
			// gridColumn17
			// 
			this.gridColumn17.Caption = "Valid";
			this.gridColumn17.ColumnEdit = this.chk_Valid;
			this.gridColumn17.FieldName = "nStatus";
			this.gridColumn17.Name = "gridColumn17";
			this.gridColumn17.Visible = true;
			this.gridColumn17.VisibleIndex = 11;
			this.gridColumn17.Width = 74;
			// 
			// chk_Valid
			// 
			this.chk_Valid.AutoHeight = false;
			this.chk_Valid.Name = "chk_Valid";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(-116, -24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(108, 34);
			this.label4.TabIndex = 30;
			this.label4.Text = "Package Branch";
			// 
			// tabBrand
			// 
			this.tabBrand.Controls.Add(this.groupControl4);
			this.tabBrand.Name = "tabBrand";
			this.tabBrand.Size = new System.Drawing.Size(762, 413);
			this.tabBrand.Text = "Brand";
			// 
			// groupControl4
			// 
			this.groupControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.groupControl4.Controls.Add(this.gridControlBrand);
			this.groupControl4.Controls.Add(this.label1);
			this.groupControl4.Location = new System.Drawing.Point(0, 0);
			this.groupControl4.Name = "groupControl4";
			this.groupControl4.Size = new System.Drawing.Size(776, 400);
			this.groupControl4.TabIndex = 89;
			this.groupControl4.Text = "groupControl4";
			// 
			// gridControlBrand
			// 
			this.gridControlBrand.Dock = System.Windows.Forms.DockStyle.Top;
			// 
			// gridControlBrand.EmbeddedNavigator
			// 
			this.gridControlBrand.EmbeddedNavigator.Name = "";
			this.gridControlBrand.Location = new System.Drawing.Point(0, 0);
			this.gridControlBrand.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlBrand.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControlBrand.MainView = this.gridViewBrand;
			this.gridControlBrand.Name = "gridControlBrand";
			this.gridControlBrand.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																													  this.lk_LookupRewardItem});
			this.gridControlBrand.Size = new System.Drawing.Size(776, 392);
			this.gridControlBrand.TabIndex = 31;
			this.gridControlBrand.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											this.gridViewBrand});
			// 
			// gridViewBrand
			// 
			this.gridViewBrand.GridControl = this.gridControlBrand;
			this.gridViewBrand.Name = "gridViewBrand";
			this.gridViewBrand.OptionsCustomization.AllowFilter = false;
			this.gridViewBrand.OptionsCustomization.AllowSort = false;
			this.gridViewBrand.OptionsView.ShowGroupPanel = false;
			this.gridViewBrand.LostFocus += new System.EventHandler(this.gridViewBrand_LostFocus);
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
			this.label1.Size = new System.Drawing.Size(108, 34);
			this.label1.TabIndex = 30;
			this.label1.Text = "Package Branch";
			// 
			// tabStyle
			// 
			this.tabStyle.Controls.Add(this.gridControlStyle);
			this.tabStyle.Name = "tabStyle";
			this.tabStyle.Size = new System.Drawing.Size(762, 413);
			this.tabStyle.Text = "Style";
			// 
			// gridControlStyle
			// 
			this.gridControlStyle.Dock = System.Windows.Forms.DockStyle.Top;
			// 
			// gridControlStyle.EmbeddedNavigator
			// 
			this.gridControlStyle.EmbeddedNavigator.Name = "";
			this.gridControlStyle.Location = new System.Drawing.Point(0, 0);
			this.gridControlStyle.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlStyle.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControlStyle.MainView = this.gridViewStyle;
			this.gridControlStyle.Name = "gridControlStyle";
			this.gridControlStyle.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																													  this.repositoryItemLookUpEdit2});
			this.gridControlStyle.Size = new System.Drawing.Size(762, 408);
			this.gridControlStyle.TabIndex = 2;
			this.gridControlStyle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											this.gridViewStyle});
			// 
			// gridViewStyle
			// 
			this.gridViewStyle.GridControl = this.gridControlStyle;
			this.gridViewStyle.Name = "gridViewStyle";
			this.gridViewStyle.OptionsCustomization.AllowFilter = false;
			this.gridViewStyle.OptionsCustomization.AllowSort = false;
			this.gridViewStyle.OptionsView.ShowGroupPanel = false;
			this.gridViewStyle.LostFocus += new System.EventHandler(this.gridViewStyle_LostFocus);
			// 
			// repositoryItemLookUpEdit2
			// 
			this.repositoryItemLookUpEdit2.AutoHeight = false;
			this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
			// 
			// tabColor
			// 
			this.tabColor.Controls.Add(this.gridControlColor);
			this.tabColor.Name = "tabColor";
			this.tabColor.Size = new System.Drawing.Size(762, 413);
			this.tabColor.Text = "Color";
			// 
			// gridControlColor
			// 
			this.gridControlColor.Dock = System.Windows.Forms.DockStyle.Top;
			// 
			// gridControlColor.EmbeddedNavigator
			// 
			this.gridControlColor.EmbeddedNavigator.Name = "";
			this.gridControlColor.Location = new System.Drawing.Point(0, 0);
			this.gridControlColor.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlColor.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControlColor.MainView = this.gridViewColor;
			this.gridControlColor.Name = "gridControlColor";
			this.gridControlColor.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																													  this.repositoryItemLookUpEdit3});
			this.gridControlColor.Size = new System.Drawing.Size(762, 408);
			this.gridControlColor.TabIndex = 2;
			this.gridControlColor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											this.gridViewColor});
			// 
			// gridViewColor
			// 
			this.gridViewColor.GridControl = this.gridControlColor;
			this.gridViewColor.Name = "gridViewColor";
			this.gridViewColor.OptionsCustomization.AllowFilter = false;
			this.gridViewColor.OptionsCustomization.AllowSort = false;
			this.gridViewColor.OptionsView.ShowGroupPanel = false;
			this.gridViewColor.LostFocus += new System.EventHandler(this.gridViewColor_LostFocus);
			// 
			// repositoryItemLookUpEdit3
			// 
			this.repositoryItemLookUpEdit3.AutoHeight = false;
			this.repositoryItemLookUpEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemLookUpEdit3.Name = "repositoryItemLookUpEdit3";
			// 
			// tabSize
			// 
			this.tabSize.Controls.Add(this.gridControlSize);
			this.tabSize.Name = "tabSize";
			this.tabSize.Size = new System.Drawing.Size(762, 413);
			this.tabSize.Text = "Size";
			// 
			// gridControlSize
			// 
			this.gridControlSize.Dock = System.Windows.Forms.DockStyle.Top;
			// 
			// gridControlSize.EmbeddedNavigator
			// 
			this.gridControlSize.EmbeddedNavigator.Name = "";
			this.gridControlSize.Location = new System.Drawing.Point(0, 0);
			this.gridControlSize.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlSize.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControlSize.MainView = this.gridViewSize;
			this.gridControlSize.Name = "gridControlSize";
			this.gridControlSize.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																													 this.repositoryItemLookUpEdit4});
			this.gridControlSize.Size = new System.Drawing.Size(762, 408);
			this.gridControlSize.TabIndex = 2;
			this.gridControlSize.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										   this.gridViewSize});
			// 
			// gridViewSize
			// 
			this.gridViewSize.GridControl = this.gridControlSize;
			this.gridViewSize.Name = "gridViewSize";
			this.gridViewSize.OptionsCustomization.AllowFilter = false;
			this.gridViewSize.OptionsCustomization.AllowSort = false;
			this.gridViewSize.OptionsView.ShowGroupPanel = false;
			this.gridViewSize.LostFocus += new System.EventHandler(this.gridViewSize_LostFocus);
			// 
			// repositoryItemLookUpEdit4
			// 
			this.repositoryItemLookUpEdit4.AutoHeight = false;
			this.repositoryItemLookUpEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemLookUpEdit4.Name = "repositoryItemLookUpEdit4";
			// 
			// tabType
			// 
			this.tabType.Controls.Add(this.gridControlType);
			this.tabType.Name = "tabType";
			this.tabType.Size = new System.Drawing.Size(762, 413);
			this.tabType.Text = "Type";
			// 
			// gridControlType
			// 
			this.gridControlType.Dock = System.Windows.Forms.DockStyle.Top;
			// 
			// gridControlType.EmbeddedNavigator
			// 
			this.gridControlType.EmbeddedNavigator.Name = "";
			this.gridControlType.Location = new System.Drawing.Point(0, 0);
			this.gridControlType.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridControlType.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControlType.MainView = this.gridViewType;
			this.gridControlType.Name = "gridControlType";
			this.gridControlType.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																													 this.repositoryItemLookUpEdit6});
			this.gridControlType.Size = new System.Drawing.Size(762, 408);
			this.gridControlType.TabIndex = 3;
			this.gridControlType.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										   this.gridViewType});
			// 
			// gridViewType
			// 
			this.gridViewType.GridControl = this.gridControlType;
			this.gridViewType.Name = "gridViewType";
			this.gridViewType.OptionsCustomization.AllowFilter = false;
			this.gridViewType.OptionsCustomization.AllowSort = false;
			this.gridViewType.OptionsView.ShowGroupPanel = false;
			this.gridViewType.LostFocus += new System.EventHandler(this.gridViewType_LostFocus);
			// 
			// repositoryItemLookUpEdit6
			// 
			this.repositoryItemLookUpEdit6.AutoHeight = false;
			this.repositoryItemLookUpEdit6.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemLookUpEdit6.Name = "repositoryItemLookUpEdit6";
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
			// repositoryItemLookUpEdit1
			// 
			this.repositoryItemLookUpEdit1.AutoHeight = false;
			this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
			// 
			// repositoryItemLookUpEdit5
			// 
			this.repositoryItemLookUpEdit5.AutoHeight = false;
			this.repositoryItemLookUpEdit5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemLookUpEdit5.Name = "repositoryItemLookUpEdit5";
			// 
			// gridView2
			// 
			this.gridView2.GridControl = null;
			this.gridView2.Name = "gridView2";
			// 
			// frmInventory
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(784, 488);
			this.Controls.Add(this.groupControlBrand);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmInventory";
			this.Load += new System.EventHandler(this.frmInventory_Load);
			((System.ComponentModel.ISupportInitialize)(this.groupControlBrand)).EndInit();
			this.groupControlBrand.ResumeLayout(false);
			this.Stockpanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtStockScr.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TabInventory)).EndInit();
			this.TabInventory.ResumeLayout(false);
			this.tabStock.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grpMDProductBelow)).EndInit();
			this.grpMDProductBelow.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grpMDPromotionBelow2)).EndInit();
			this.grpMDPromotionBelow2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridBranch2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvBranch2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridBranch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvBranch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
			this.groupControl3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControlStock)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewStock)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Brand)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Style)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Color)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Size)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Type)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_Valid)).EndInit();
			this.tabBrand.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
			this.groupControl4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControlBrand)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewBrand)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_LookupRewardItem)).EndInit();
			this.tabStyle.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControlStyle)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewStyle)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
			this.tabColor.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControlColor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewColor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).EndInit();
			this.tabSize.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControlSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).EndInit();
			this.tabType.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControlType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void TabInventory_Click(object sender, System.EventArgs e)
		{
				if (TabInventory.SelectedTabPage.Text == "Stock")
				{
					grpMDProductBelow.Visible=true;
					Stockpanel.Visible=true;

					string strSQL_Inv = "select * from tblProduct";
					mdInventoryInit(strSQL_Inv);
				}
				else {
					grpMDProductBelow.Visible=false;
					Stockpanel.Visible=false;}
			}

		private void btn_Search_Click(object sender, System.EventArgs e)
		{
			string strSQL = "select * from tblProduct where strProductCode like '%" + txtStockScr.Text + "%' or  strDescription like '%" + txtStockScr.Text +"%'";
			mdInventoryInit(strSQL);
			LoadBranch();		
		}
	
		private void txtSearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btn_Search_Click(sender,e);
			}
		}
		
		private void Update_Quantity(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			DataRow dr = gridViewStock.GetDataRow(gridViewStock.FocusedRowHandle);

			DataRow br = gvBranch2.GetDataRow(gvBranch2.FocusedRowHandle);

			try
			{

				SqlHelper.ExecuteNonQuery(connection,"Up_ProductInventory",
					new SqlParameter("@ProductCode",dr["strProductCode"].ToString()),
					new SqlParameter("@BranchCode",br["strBranchCode"].ToString()),
					new SqlParameter("@Qty",br["nQuantity"].ToString()));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message ,"Quantity could not be updated");
				return;
			}
			
			}
	}

}
