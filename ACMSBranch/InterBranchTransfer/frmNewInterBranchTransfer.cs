using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
//using Rp = Acms.Core.Repository;
//using Fc = Acms.Core.Factory;
using Acms.Core.Domain;
using DevExpress.XtraEditors.Controls;
using ACMS.Utils;
using ACMSLogic;
using System.Data.SqlClient;
using ACMS.ACMSBranch.StockRequest;

namespace ACMS.ACMSBranch.InterBranchTransfer
{
	/// <summary>
	/// Summary description for frmNewInterBranchTransfer.
	/// </summary>
	public class frmNewInterBranchTransfer : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraEditors.LookUpEdit lkBranchTo;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label txtDate;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.DateEdit dateEdit1;
		private DevExpress.XtraEditors.SimpleButton simpleButton3;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;

				
		private bool isEdit = false;
		private bool canSave = true;
		private bool canAdd = true;
		private int inValidQuantityRow = 0;
		ArrayList validStrItemCodeList = null;
		private Acms.Core.Domain.Employee employee;
		private Acms.Core.Domain.TerminalUser terminalUser;
		private int nIBTNo;
		private DevExpress.XtraEditors.MemoEdit txtRemarks;
		private DevExpress.XtraEditors.SimpleButton simpleButton4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;

		DataTable dt;
		public frmNewInterBranchTransfer()
		{
			
			dt = new DataTable();
			dt.Columns.Add("strItemCode");
			dt.Columns.Add("nQuantity");
			InitializeComponent();

		}

		public void InitData()
		{
			BindPage();
			LoadProductList();
		}

		public int NIBTNo
		{
			set{nIBTNo=value;}
			get{return nIBTNo;}
		}

		public Employee Employee
		{
			set{employee=value;}
		}

		public TerminalUser TerminalUser
		{
			set{terminalUser=value;}
		}

		public bool IsEdit
		{
			set{isEdit=value;}
			get{return isEdit;}
		}

		private void BindPage()
		{
			this.dateEdit1.Properties.Enabled=false;
			this.dateEdit1.EditValue = DateTime.Today.ToShortDateString();
			
			//Rp.StockRequestRepository srr = new Rp.StockRequestRepository();
			//IList listBranchTo = srr.GetListByDomainAndExcludeById(typeof(Branch),this.terminalUser.Branch.Id);

			ACMSLogic.StockRequest.StockRequest stockRequest = new ACMSLogic.StockRequest.StockRequest();

			this.lkBranchTo.Properties.DataSource = stockRequest.GetListByDomainAndExcludeById(this.terminalUser.Branch.Id);

			//this.lkBranchTo.Properties.DataSource = listBranchTo;
			//this.lkBranchTo.Properties.ValueMember = "Id";
			//this.lkBranchTo.Properties.DisplayMember = "StrBranchName";

			this.lkBranchTo.Properties.ValueMember = "strBranchCode";
			this.lkBranchTo.Properties.DisplayMember = "strBranchName";
			this.lkBranchTo.EditValue="Select Branch";
			this.lkBranchTo.Text="Select Branch";

			

			//add two columns in the dropdown
			LookUpColumnInfoCollection coll = lkBranchTo.Properties.Columns;
			//a column to display values of the ProductID field
//			coll.Add(new LookUpColumnInfo("Id","Branch Code",2));
//			//a column to display values of the ProductName field
//			coll.Add(new LookUpColumnInfo("StrBranchName","Branch Name",50));

			coll.Add(new LookUpColumnInfo("strBranchCode","Branch Code",2));
			//a column to display values of the ProductName field
			coll.Add(new LookUpColumnInfo("strBranchName","Branch Name",50));


			//set column widths according to their contents
			lkBranchTo.Properties.BestFit();
			//specify the total dropdown width
			lkBranchTo.Properties.PopupWidth = 300;

			//enable auto completion search mode
			//lkBranchTo.Properties.SearchMode = SearchMode.AutoComplete;
			//the column against which to perform the search
			lkBranchTo.Properties.AutoSearchColumnIndex = 0;


			if(this.gridView1.DataRowCount==0)
			{
				DataRow dr = dt.NewRow();
				dr["strItemCode"]="Select Product";
				dr["nQuantity"]="0";
				dt.Rows.Add(dr);
				this.gridControl1.DataSource = dt;
			}

		}
		
		public void LoadIBTEdit()
		{
			//Rp.IBTRepository ir = new Rp.IBTRepository();
			//Acms.Core.Domain.IBT ibt = ir.GetIBTById(nIBTNo);
			ACMSLogic.InterBranchTransfer.InterBranchTransfer ibt = new ACMSLogic.InterBranchTransfer.InterBranchTransfer();
			DataTable dt = ibt.GetIBTById(nIBTNo);

			this.GetIBTDetail();

			this.dateEdit1.EditValue = Convert.ToDateTime(dt.Rows[0]["dtDate"].ToString()).ToShortDateString();//ibt.DtDate.ToShortDateString();
			this.lkBranchTo.EditValue = dt.Rows[0]["strBranchCodeTo"].ToString();//ibt.BranchTo.Id;
			this.txtRemarks.Text = dt.Rows[0]["strRemarks"].ToString();//ibt.StrRemarks;

			this.simpleButton1.Text="Update";
			this.simpleButton2.Text="Cancel";
			this.simpleButton2.Width = 75;
			//this.simpleButton3.Visible=false;
			
		}

		private void GetIBTDetail()
		{
//			Rp.IBTRepository ir = new Rp.IBTRepository();
//			IList list = ir.GetIBTDetailList(nIBTNo);
//			//IList list = ir.Find("from IBTEntry s left outer join s.Product_StrItemCode p where s.IBT.Id="+nIBTNo);
//
//			DataTable dt = new DataTable();
//			CSLA.Data.ObjectAdapter oa = new CSLA.Data.ObjectAdapter();
//			oa.Fill(dt,list);

			ACMSLogic.InterBranchTransfer.InterBranchTransfer ibt = new ACMSLogic.InterBranchTransfer.InterBranchTransfer();
			DataTable dt = ibt.GetIBTDetail(nIBTNo);
			this.gridControl1.DataSource = dt;
			this.gridView1.Columns[0].OptionsColumn.AllowEdit=false;
			this.lkBranchTo.Enabled=false;
			this.dateEdit1.Enabled=false;
			this.simpleButton4.Visible=false;
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
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.lkBranchTo = new DevExpress.XtraEditors.LookUpEdit();
			this.label6 = new System.Windows.Forms.Label();
			this.txtDate = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
			this.txtRemarks = new DevExpress.XtraEditors.MemoEdit();
			this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.lkBranchTo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
			this.SuspendLayout();
			// 
			// simpleButton1
			// 
			this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.simpleButton1.Location = new System.Drawing.Point(88, 176);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.TabIndex = 51;
			this.simpleButton1.Text = "Save";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// lkBranchTo
			// 
			this.lkBranchTo.Location = new System.Drawing.Point(88, 48);
			this.lkBranchTo.Name = "lkBranchTo";
			// 
			// lkBranchTo.Properties
			// 
			this.lkBranchTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkBranchTo.Properties.NullText = "";
			this.lkBranchTo.Size = new System.Drawing.Size(144, 20);
			this.lkBranchTo.TabIndex = 46;
			this.lkBranchTo.EditValueChanged += new System.EventHandler(this.BranchTo_EditValueChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 80);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 23);
			this.label6.TabIndex = 45;
			this.label6.Text = "Remarks";
			// 
			// txtDate
			// 
			this.txtDate.Location = new System.Drawing.Point(8, 16);
			this.txtDate.Name = "txtDate";
			this.txtDate.Size = new System.Drawing.Size(48, 23);
			this.txtDate.TabIndex = 39;
			this.txtDate.Text = "Date";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 42;
			this.label3.Text = "Branch To";
			// 
			// dateEdit1
			// 
			this.dateEdit1.EditValue = new System.DateTime(2005, 10, 28, 0, 0, 0, 0);
			this.dateEdit1.Location = new System.Drawing.Point(88, 16);
			this.dateEdit1.Name = "dateEdit1";
			// 
			// dateEdit1.Properties
			// 
			this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.dateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dateEdit1.Size = new System.Drawing.Size(88, 20);
			this.dateEdit1.TabIndex = 38;
			// 
			// txtRemarks
			// 
			this.txtRemarks.EditValue = "";
			this.txtRemarks.Location = new System.Drawing.Point(88, 80);
			this.txtRemarks.Name = "txtRemarks";
			this.txtRemarks.Size = new System.Drawing.Size(360, 80);
			this.txtRemarks.TabIndex = 53;
			// 
			// simpleButton3
			// 
			this.simpleButton3.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.simpleButton3.Location = new System.Drawing.Point(248, 176);
			this.simpleButton3.Name = "simpleButton3";
			this.simpleButton3.TabIndex = 56;
			this.simpleButton3.Text = "Delete";
			this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
			// 
			// simpleButton2
			// 
			this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.simpleButton2.Location = new System.Drawing.Point(168, 176);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.TabIndex = 55;
			this.simpleButton2.Text = "Add";
			this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
			// 
			// gridControl1
			// 
			// 
			// gridControl1.EmbeddedNavigator
			// 
			this.gridControl1.EmbeddedNavigator.Name = "";
			this.gridControl1.Location = new System.Drawing.Point(88, 208);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												  this.repositoryItemLookUpEdit1,
																												  this.repositoryItemTextEdit1});
			this.gridControl1.Size = new System.Drawing.Size(360, 200);
			this.gridControl1.TabIndex = 54;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn1,
																							 this.gridColumn3,
																							 this.gridColumn2});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.CheckIsModify);
			this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.CheckAvailableQuantity);
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Item Code";
			this.gridColumn1.ColumnEdit = this.repositoryItemLookUpEdit1;
			this.gridColumn1.FieldName = "strItemCode";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			// 
			// repositoryItemLookUpEdit1
			// 
			this.repositoryItemLookUpEdit1.AutoHeight = false;
			this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
			this.repositoryItemLookUpEdit1.NullText = "Select Product";
			// 
			// gridColumn3
			// 
			this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
			this.gridColumn3.Caption = "Quantity";
			this.gridColumn3.ColumnEdit = this.repositoryItemTextEdit1;
			this.gridColumn3.FieldName = "nQuantity";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 1;
			// 
			// repositoryItemTextEdit1
			// 
			this.repositoryItemTextEdit1.AutoHeight = false;
			this.repositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "nEntryID";
			this.gridColumn2.FieldName = "nEntryID";
			this.gridColumn2.Name = "gridColumn2";
			// 
			// simpleButton4
			// 
			this.simpleButton4.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.simpleButton4.Location = new System.Drawing.Point(328, 176);
			this.simpleButton4.Name = "simpleButton4";
			this.simpleButton4.TabIndex = 57;
			this.simpleButton4.Text = "Search";
			this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
			// 
			// frmNewInterBranchTransfer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(458, 418);
			this.Controls.Add(this.simpleButton4);
			this.Controls.Add(this.simpleButton3);
			this.Controls.Add(this.simpleButton2);
			this.Controls.Add(this.gridControl1);
			this.Controls.Add(this.txtRemarks);
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.lkBranchTo);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtDate);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.dateEdit1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmNewInterBranchTransfer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New InterBranchTransfer";
			((System.ComponentModel.ISupportInitialize)(this.lkBranchTo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

			try	
			{
				if (dr.Table.Rows.Count==0)
				{
					MessageBox.Show("Not allowed to Save Empty Entries","Warning");
					return;
				}
			}
			catch (Exception ex)
			{
				return;
			}

			SqlConnection sqlcon = new SqlConnection(SqlHelperUtils.connectionString);
			sqlcon.Open();

			SqlTransaction trans = sqlcon.BeginTransaction();

			if(this.lkBranchTo.EditValue.ToString()=="Select Branch" | this.lkBranchTo.EditValue.ToString()=="")
			{
				ACMS.Utils.UI.ShowErrorMessage(this,"Please select valid Branch Code","Error");

			}
			else if(canSave)
			{
				ACMSLogic.InterBranchTransfer.InterBranchTransfer ibts = new ACMSLogic.InterBranchTransfer.InterBranchTransfer();
				int nIBTNo = 0;

				//Hashtable htIBT = new Hashtable();
				//htint
				if(isEdit)
				{

					if(!ibts.UpdateIBT(trans,DateTime.Now,this.terminalUser.Branch.Id,this.lkBranchTo.EditValue.ToString(),0,this.employee.Id,DateTime.Now,this.txtRemarks.Text,this.nIBTNo))
					{
						trans.Rollback();
						sqlcon.Close();
						UI.ShowErrorMessage(this,"RollBack Transaction - Update IBT","Error");
						return;
					}
					ACMSLogic.AuditTrail.AuditTrail audit = new ACMSLogic.AuditTrail.AuditTrail();
					audit.SaveAuditTrail(trans,8,"Update IBT "+this.nIBTNo,"IBT",this.employee.Id);
					

				}
				else
				{
					nIBTNo = ibts.SaveIBT(trans,DateTime.Now,this.terminalUser.Branch.Id,this.lkBranchTo.EditValue.ToString(),0,this.employee.Id,DateTime.Now,this.txtRemarks.Text);
					ACMSLogic.AuditTrail.AuditTrail audit = new ACMSLogic.AuditTrail.AuditTrail();
					audit.SaveAuditTrail(trans,8,"Save IBT "+this.nIBTNo,"IBT",this.employee.Id);

					#region nHibernate Code
//					//DateTime
//					htIBT.Add("dtDate",DateTime.Now);
//					//int
//					//Status 0 - Pending Request
//					htIBT.Add("nStatusID",0);
//					//DateTime
//					htIBT.Add("dtLastEditDate",DateTime.Now);
//					//string
//					htIBT.Add("strRemarks",this.txtRemarks.Text);
//
//					//string
//					htIBT.Add("Branch_strBranchCodeFrom",this.terminalUser.Branch.Id);
//
//					//string
//					htIBT.Add("Branch_strBranchCodeTo",this.lkBranchTo.EditValue);
//
//					//int
//					htIBT.Add("Employee_nEmployeeID",this.employee.Id);
					#endregion
				}
				ArrayList ibtEntryList = new ArrayList();

				ArrayList ibtProductTransferList = new ArrayList();

				DevExpress.XtraGrid.Columns.GridColumn col1 = gridView1.Columns.ColumnByFieldName("strItemCode");
				DevExpress.XtraGrid.Columns.GridColumn col2 = gridView1.Columns.ColumnByFieldName("nQuantity");
				DevExpress.XtraGrid.Columns.GridColumn col3 = gridView1.Columns.ColumnByFieldName("nEntryID");
				for(int i=0;i<this.gridView1.DataRowCount;i++)
				{
					
					object cellValue1 = gridView1.GetRowCellValue(i, col1);
					object cellValue2 = gridView1.GetRowCellValue(i, col2);
					object cellValue3 = null;
					
					IBTProductTransfer ibt;
					int nEntryID = 0;
					
					string strProductCode = cellValue1.ToString();
					int quantity = Convert.ToInt32(cellValue2.ToString());

					if(isEdit)
					{
						cellValue3 = gridView1.GetRowCellValue(i, col3);
						nEntryID = Convert.ToInt32(cellValue3);
						ibt = new IBTProductTransfer(strProductCode,quantity,nEntryID);
					}
					else
					{
						ibt = new IBTProductTransfer(strProductCode,quantity);
					}

					if(ibtProductTransferList.Count==0)
					{
						ibtProductTransferList.Add(ibt);
					}
					else
					{
						bool duplicate=false;
						for(int _i=0;_i<ibtProductTransferList.Count;_i++)
						{
							IBTProductTransfer _ibt = ibtProductTransferList[_i] as IBTProductTransfer;

							if(strProductCode==_ibt.StrProductCode)
							{
								_ibt.Quantity=_ibt.Quantity+quantity;
								duplicate=true;
							}
						}

						if(!duplicate)
							ibtProductTransferList.Add(ibt);
					}
				}

				//Variable Hashtable
				//bool doubleCheckCanSave=true;
				

				if(isEdit)
				{

					foreach(IBTProductTransfer ibt in ibtProductTransferList)
					{

						if(!ibts.UpdateIBTEntries(trans,NIBTNo,ibt.StrProductCode,ibt.Quantity,this.terminalUser.Branch.Id,ibt.NEntryID))
						{
							trans.Rollback();
							sqlcon.Close();
							UI.ShowErrorMessage(this,"RollBack Transaction - Update IBTEntries","Error");
							return;
						}
					}
					ACMSLogic.AuditTrail.AuditTrail audit = new ACMSLogic.AuditTrail.AuditTrail();
					audit.SaveAuditTrail(trans,8,"Update IBTEntries "+NIBTNo,"IBTEntries",this.employee.Id);
					
					UI.ShowMessage(this,"Record Has Been Updated");
				}
				else
				{
					if(nIBTNo!=0)
					{
						foreach(IBTProductTransfer ibt in ibtProductTransferList)
						{
							if(!ibts.SaveIBTEntries(trans,nIBTNo,ibt.StrProductCode,ibt.Quantity,this.terminalUser.Branch.Id))
							{
								trans.Rollback();
								sqlcon.Close();
								UI.ShowErrorMessage(this,"RollBack Transaction - Update StockRequestEntries","Error");
								return;
							}
							#region nHibernate Code
							//					Hashtable htIBTEntries = new Hashtable();
							//
							//					htIBTEntries.Add("strItemCode",ibt.StrProductCode);
							//					//int
							//					htIBTEntries.Add("nQuantity",ibt.Quantity);
							//
							//					Rp.ProductRepository pr = new Rp.ProductRepository();
							//
							//					Acms.Core.Domain.ProductInventory pi = pr.CheckQuantityAvailable(ibt.StrProductCode,this.terminalUser.Branch.Id);
							//					if(pi!=null)
							//					{
							//				
							//						if(!pi.IsValidQuantityRequest(ibt.Quantity))
							//						{
							//							doubleCheckCanSave=false;
							//							//return;
							//						}
							//					}
							//
							//					ibtEntryList.Add(htIBTEntries);
							#endregion
						}
						ACMSLogic.AuditTrail.AuditTrail audit = new ACMSLogic.AuditTrail.AuditTrail();
						audit.SaveAuditTrail(trans,8,"Save IBTEntries "+NIBTNo,"IBTEntries",this.employee.Id);
					
					}
					UI.ShowMessage(this,"Record Has Been Saved");
				}


	

			}

			trans.Commit();
			sqlcon.Close();
			this.DialogResult = DialogResult.OK;
			
			
		}

		private void SaveAuditTrail(int nAuditTypeId,string strReference,string strAuditEntry,int employeeId)
		{
			//ACMS.Util.AuditTrail at = new ACMS.Util.AuditTrail();
			//at.SaveAuditTrail(strReference,strAuditEntry,employeeId);\
			ACMSLogic.AuditTrail.AuditTrail auditTrail = new ACMSLogic.AuditTrail.AuditTrail();
			auditTrail.SaveAuditTrail(nAuditTypeId,strReference,strAuditEntry,employeeId);

		}

		private void CheckAvailableQuantity(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
		{
			if(!isEdit)
			{
				DataRow row = this.gridView1.GetDataRow(gridView1.FocusedRowHandle);

				if(row["strItemCode"]!=null)
				{
					if(row["strItemCode"].ToString()!="Select Product")
					{
						string strProductCode = row["strItemCode"].ToString(); 
						int quantityRequest = Convert.ToInt32(row["nQuantity"].ToString()); 

			
						ACMSLogic.StockRequest.StockRequest stockRequest = new ACMSLogic.StockRequest.StockRequest();
						if(!stockRequest.GetAvailableQuantity(strProductCode,this.terminalUser.Branch.Id,quantityRequest))
						{
							UI.ShowErrorMessage(this,"Invalid Operation. Please change valid product quantity","Error");
							this.canSave=false;
							this.canAdd=false;
							inValidQuantityRow=gridView1.FocusedRowHandle;
						}
						else
						{
							this.canSave=true;
							this.canAdd=true;
						}
					}
					else
					{
						this.canSave=false;
					}
				}
				else
				{
					this.canSave=false;
				}
			}
			
		}

		private bool CheckDuplicate()
		{
			validStrItemCodeList = new ArrayList();

			DevExpress.XtraGrid.Columns.GridColumn col1 = gridView1.Columns.ColumnByFieldName("strItemCode");
			
			for(int i=0;i<this.gridView1.DataRowCount;i++)
			{
				object cellValue1 = gridView1.GetRowCellValue(i, col1);
				if(validStrItemCodeList.Count==0)
				{
					validStrItemCodeList.Add(cellValue1.ToString());
				}
				else
				{
					if(validStrItemCodeList.Contains(cellValue1.ToString()))
					{
						if (MessageBox.Show(this, "ItemCode already exist.Delete duplicate ItemCode?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
						{
							this.gridView1.DeleteRow(gridView1.FocusedRowHandle);
							canSave=false;
							//return false to discard save to database
							return true;
						}
						return false;
					}
					else
					{
						validStrItemCodeList.Add(cellValue1.ToString());
					}
				}
			}
			return true;
		}
		/// <summary>
		/// Add New IBT Detail
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void simpleButton2_Click(object sender, System.EventArgs e)
		{
			if(canAdd)
			{
				if(this.lkBranchTo.EditValue.ToString()=="Select Branch" |this.lkBranchTo.EditValue.ToString()=="" )
				{
					ACMS.Utils.UI.ShowErrorMessage(this,"Please select valid Branch Code","Error");

				}
				else if(this.simpleButton2.Text=="Cancel")
				{
					this.Close();
				}
				else
				{
				
					try
					{
						CheckAvailableQuantity(sender,null);
					}
					catch
					{
					}
					if(canSave)
					{
						int currentRow;
						currentRow = gridView1.FocusedRowHandle;
						if(currentRow < 0) 
							currentRow = gridView1.GetDataRowHandleByGroupRowHandle(currentRow);
						gridView1.AddNewRow();
			
						gridView1.ShowEditor();
					}
				}
			}
			else
			{
				UI.ShowErrorMessage(this,"Invalid Operation. Please change valid product quantity","Error");
			}
		}

		/// <summary>
		/// Delete IBT Detail
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void simpleButton3_Click(object sender, System.EventArgs e)
		{

			if (simpleButton1.Text=="Save")
			{
				this.gridView1.DeleteRow(gridView1.FocusedRowHandle);
				return;
			}
			else if (simpleButton1.Text=="Update")
			{
				DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

				if (dr.Table.Rows.Count==1)
				{
					MessageBox.Show("Not allow to Delete all entries","Warning");
					return;
				}
				if(this.lkBranchTo.EditValue.ToString()=="Select Branch" |this.lkBranchTo.EditValue.ToString()=="" )
				{
					ACMS.Utils.UI.ShowErrorMessage(this,"Please select valid Branch Code","Error");

				}
				else
				{
					if (MessageBox.Show(this, "Delete this Item? "+ dr[0].ToString(), "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
					{	
						SqlConnection sqlcon = new SqlConnection(SqlHelperUtils.connectionString);
						sqlcon.Open();

						SqlTransaction trans = sqlcon.BeginTransaction();
						ACMSLogic.InterBranchTransfer.InterBranchTransfer ibts = new ACMSLogic.InterBranchTransfer.InterBranchTransfer();


						if(ibts.DeleteIBTEntries(trans,NIBTNo,ACMS.Convert.ToDBInt32(dr["nEntryID"]),this.terminalUser.Branch.Id))
						{
							this.gridView1.DeleteRow(gridView1.FocusedRowHandle);
				
						}
						trans.Commit();
						sqlcon.Close();
						this.gridView1.RefreshData();
						//this.DialogResult = DialogResult.OK;
					}
				}
			}
		}

		private void CheckIsModify(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			if(e.Column.FieldName!="IsModify")
			{
				DevExpress.XtraGrid.Columns.GridColumn col = gridView1.Columns.ColumnByFieldName("IsModify");
				DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
				gridView1.SetFocusedRowCellValue(col,true);
				
			}
		}

		private void LoadProductList()
		{
			this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																													   new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strItemCode", "Product Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			
			ACMSLogic.StockRequest.StockRequest stockRequest = new ACMSLogic.StockRequest.StockRequest();

			this.repositoryItemLookUpEdit1.DataSource = stockRequest.GetProductByBranch(this.terminalUser.Branch.Id);//pr.GetProductByBranch(this.lkBranchTo.EditValue.ToString());
			
			
			this.repositoryItemLookUpEdit1.DisplayMember = "strItemCode";
			this.repositoryItemLookUpEdit1.ValueMember="strItemCode";
			this.repositoryItemLookUpEdit1.NullText="Select Product";

			LookUpColumnInfoCollection col2 = repositoryItemLookUpEdit1.Columns;
			//a column to display values of the ProductID field
			//a column to display values of the ProductName field
			//col2.Add(new LookUpColumnInfo("Id","Product Code",20));
			col2.Add(new LookUpColumnInfo("strBrand","Brand",50));
			col2.Add(new LookUpColumnInfo("strDescription","Description",50));
			col2.Add(new LookUpColumnInfo("strStyle","Style",50));
			col2.Add(new LookUpColumnInfo("strColor","Color",50));
			col2.Add(new LookUpColumnInfo("strSize","Size",50));
			col2.Add(new LookUpColumnInfo("nQuantity","Quantity",50));


			lkBranchTo.Properties.AutoSearchColumnIndex = 0;
			repositoryItemLookUpEdit1.BestFit();
			repositoryItemLookUpEdit1.PopupWidth = 600;
		}

		private void BranchTo_EditValueChanged(object sender, System.EventArgs e)
		{
//			Rp.ProductRepository pr = new Rp.ProductRepository();
//			this.repositoryItemLookUpEdit1.Columns.Clear();
//			this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
//																													   new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductId", "Product Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
//			IList list = pr.GetProductByBranch(this.terminalUser.Branch.Id);
//			this.repositoryItemLookUpEdit1.DataSource =  list;
//			if(isEdit)
//			{
//			
//				for(int i=0;i<this.gridView1.DataRowCount;i++)
//				{
//					bool isAvailable=false;
//					object cellValue1 = gridView1.GetRowCellValue(i, "ProductStrItemCode");
//				
//					foreach(ProductInventory pi in list)
//					{
//						if(pi.Product.Id == cellValue1.ToString())
//						{
//							isAvailable=true;
//							break;
//						}
//					}
//			
//					if(!isAvailable)
//					{
//						this.gridView1.DeleteRow(gridView1.FocusedRowHandle);
//					}
//				}
//				
//			}
//			
//			this.repositoryItemLookUpEdit1.DisplayMember = "ProductId";
//			this.repositoryItemLookUpEdit1.ValueMember="ProductId";
//
//			LookUpColumnInfoCollection col2 = repositoryItemLookUpEdit1.Columns;
//			//a column to display values of the ProductID field
//			//a column to display values of the ProductName field
//			//col2.Add(new LookUpColumnInfo("Id","Product Code",20));
//			col2.Add(new LookUpColumnInfo("StrBrand","Brand",50));
//			col2.Add(new LookUpColumnInfo("StrDescription","Description",50));
//			col2.Add(new LookUpColumnInfo("StrStyle","Style",50));
//			col2.Add(new LookUpColumnInfo("StrColor","Color",50));
//			col2.Add(new LookUpColumnInfo("StrSize","Size",50));
//			col2.Add(new LookUpColumnInfo("NQuantity","Quantity",50));
//
//
//			lkBranchTo.Properties.AutoSearchColumnIndex = 0;
//		
//			//repositoryItemLookUpEdit1.EditValueChanged += new EventHandler(repositoryItemLookUpEdit1_EditValueChanged);
//			repositoryItemLookUpEdit1.BestFit();
//			repositoryItemLookUpEdit1.PopupWidth = 500;
		}

		private void repositoryItemLookUpEdit1_EditValueChanged(object sender, EventArgs e)
		{
			DevExpress.XtraEditors.LookUpEdit repositoryItemLookUpEdit1 = sender as DevExpress.XtraEditors.LookUpEdit;
			
			//MessageBox.Show(repositoryItemLookUpEdit1.EditValue.ToString(),"A");
			for(int i=0;i<this.gridView1.DataRowCount;i++)
			{
				object cellValue1 = gridView1.GetRowCellValue(i, "ProductStrItemCode");
				
				if(repositoryItemLookUpEdit1.EditValue.ToString() == cellValue1.ToString())
				{
					MessageBox.Show("Item already added","Error");
					this.gridView1.DeleteRow(gridView1.FocusedRowHandle);
					break;
				}
				//				
			}
			
		}

		private void simpleButton4_Click(object sender, System.EventArgs e)
		{
			if(this.lkBranchTo.EditValue.ToString()=="Select Branch")
			{
				UI.ShowErrorMessage(this,"Please select Branch first","Error");
				this.lkBranchTo.Focus();
				return;
			}
			frmSearchProduct sp = new frmSearchProduct(this.lkBranchTo.EditValue.ToString());
			
			if (DialogResult.OK == sp.ShowDialog(this))
			{
				DataRow dr =null;
				int rowloop=0;

				if(this.gridView1.RowCount==1)
				{
					DataRow row = this.gridView1.GetDataRow(0);
					
					if(row!=null)
					{
						if(row[0].ToString()=="" | row[0].ToString()=="Select Product")
						{
							foreach(SearchProduct sps in sp.SearchProducts)
							{
								if(rowloop==0)
								{
									dr = dt.Rows[0];
									dr["strItemCode"]=sps.StrProductCode;
									dr["nQuantity"]=0;
								}
								else
								{
									AppendRow(dr,sps);
								}
								rowloop++;
							}
							
						}
						else
						{
							BuildRow(dr,sp);
						}
					}
				}
				else
				{
					BuildRow(dr,sp);
					
				}
				this.gridControl1.DataSource = dt;
			}
			sp.Dispose();
		}

		private void AppendRow(DataRow dr,SearchProduct sps)
		{
			dr = dt.NewRow();
			dr["strItemCode"]=sps.StrProductCode;
			dr["nQuantity"]=0;
			dt.Rows.Add(dr);
		}

		private void BuildRow(DataRow dr,frmSearchProduct sp)
		{
			foreach(SearchProduct sps in sp.SearchProducts)
			{
				dr = dt.NewRow();
				dr["strItemCode"]=sps.StrProductCode;
				dr["nQuantity"]=0;
				dt.Rows.Add(dr);
			}
		}
	}
}
