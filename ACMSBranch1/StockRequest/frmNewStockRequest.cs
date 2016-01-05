using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ACMSLogic;
using ACMS.Utils;
////using Rp = Acms.Core.Repository;
////using Fc = Acms.Core.Factory;
using System.Data.SqlClient;
using Acms.Core.Domain;
using DevExpress.XtraEditors.Controls;

namespace ACMS.ACMSBranch.StockRequest
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmNewStockRequest : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label txtDate;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.DateEdit dateEdit1;
		
		private bool isEdit = false;
		private bool canSave = true;
		private bool canAdd = true;
		private int inValidQuantityRow = 0;
		ArrayList validStrItemCodeList = null;
		private string _stockRequestNo;
		private Acms.Core.Domain.Employee employee;
		private Acms.Core.Domain.TerminalUser terminalUser;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraEditors.SimpleButton simpleButton3;
		private DevExpress.XtraEditors.LookUpEdit lkBranchTo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
		private DevExpress.XtraEditors.SimpleButton simpleButton4;


		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.TextEdit txtRequestedBy;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_Product;
		private DevExpress.XtraGrid.Columns.GridColumn rItem;
		private DevExpress.XtraGrid.Columns.GridColumn rQty;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_Style;
		private DevExpress.XtraEditors.SimpleButton btn_Add;
		private DevExpress.XtraEditors.SimpleButton btn_Save;
		DataTable dt;

		public frmNewStockRequest()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			dt = new DataTable();
			dt.Columns.Add("strItemCode");
			dt.Columns.Add("nQuantity");
			
		}

		public void InitData()
		{
			BindPage();
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

		public bool CanSave
		{
			set{canSave=value;}
			get{return canSave;}
		}

		public string StockRequestNo
		{
			set{_stockRequestNo=value;}
			//this.txtStockRequest.Text=value;}
			get{return _stockRequestNo;}
		}

		public void LoadStockRequestEdit()
		{
			ACMSLogic.StockRequest.StockRequest stockRequest = new ACMSLogic.StockRequest.StockRequest();
			DataTable dt = stockRequest.GetStockRequestById(Convert.ToInt32(this.StockRequestNo));

			if(dt!=null)
			{
				this.GetStockRequestDetail();

				this.dateEdit1.EditValue = Convert.ToDateTime(dt.Rows[0]["dtDate"].ToString()).ToShortDateString();
				this.lkBranchTo.EditValue = dt.Rows[0]["strBranchCodeTo"].ToString();
				this.txtRequestedBy.Text = dt.Rows[0]["strRemarks"].ToString();
			
			}
			
			this.btn_Save.Text="Update";
			this.btn_Add.Text="Cancel";
			this.btn_Add.Width = 75;
			this.simpleButton3.Visible=false;

			//Rp.StockRequestRepository srp = new Rp.StockRequestRepository();
			//Acms.Core.Domain.StockRequest sr = srp.GetStockRequestById(Convert.ToInt32(this.StockRequestNo));

			
		}

		private void BindPage()
		{
			this.dateEdit1.Text = DateTime.Today.ToShortDateString();
			
			//Rp.StockRequestRepository srr = new Rp.StockRequestRepository();
			//IList listBranchTo = srr.GetListByDomainAndExcludeById(typeof(Branch),this.terminalUser.Branch.Id);
			ACMSLogic.StockRequest.StockRequest stockRequest = new ACMSLogic.StockRequest.StockRequest();

			this.lkBranchTo.Properties.DataSource = stockRequest.GetListByDomainAndExcludeById(this.terminalUser.Branch.Id);
			this.lkBranchTo.Properties.ValueMember = "strBranchCode";
			this.lkBranchTo.Properties.DisplayMember = "strBranchName";
			this.lkBranchTo.EditValue="Select Branch";
			this.lkBranchTo.Text="Select Branch";

			//add two columns in the dropdown
			LookUpColumnInfoCollection coll = lkBranchTo.Properties.Columns;
			//a column to display values of the ProductID field
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

			#region Disable Code
			//TODO:Check Current Branch
			//IList listBranchTo = srr.GetListByRange(typeof(Branch),"SP");
			//this.lkBranchTo.Properties.DataSource = listBranchTo;
			//this.lkBranchTo.Properties.ValueMember = "Id";
			//this.lkBranchTo.Properties.DisplayMember = "StrBranchName";

			//add two columns in the dropdown
			//LookUpColumnInfoCollection col2 = lkBranchTo.Properties.Columns;
			//a column to display values of the ProductID field
			//col2.Add(new LookUpColumnInfo("Id","Id",2));
			//a column to display values of the ProductName field
			//col2.Add(new LookUpColumnInfo("StrBranchName","Branch Name",50));

			//set column widths according to their contents
			//lkBranchTo.Properties.BestFit();
			//specify the total dropdown width
			//lkBranchTo.Properties.PopupWidth = 300;

			//enable auto completion search mode
			//lkBranchTo.Properties.SearchMode = SearchMode.AutoComplete;
			//the column against which to perform the search
			//lkBranchTo.Properties.AutoSearchColumnIndex = 1;


			//IList listEmployee = srr.GetListByDomain(typeof(Employee));
			//this.lkRequestedBy.Properties.DataSource = listEmployee;
			//this.lkRequestedBy.Properties.DisplayMember = "StrEmployeeName";
			//this.lkRequestedBy.Properties.ValueMember = "Id";

			//add two columns in the dropdown
			//LookUpColumnInfoCollection col3 = lkRequestedBy.Properties.Columns;
			//a column to display values of the ProductID field
			//col3.Add(new LookUpColumnInfo("Id","Id",4));
			//a column to display values of the ProductName field
			//col3.Add(new LookUpColumnInfo("StrEmployeeName","Employee Name",50));

			//set column widths according to their contents
			//lkRequestedBy.Properties.BestFit();
			//specify the total dropdown width
			//lkRequestedBy.Properties.PopupWidth = 300;

			//enable auto completion search mode
			//lkRequestedBy.Properties.SearchMode = SearchMode.AutoComplete;
			//the column against which to perform the search
			//lkRequestedBy.Properties.AutoSearchColumnIndex = 1;

			//IList listIBT = srr.GetListByDomain(typeof(IBT));
			//this.lkIBT.Properties.DataSource = listIBT;
			//this.lkIBT.Properties.DisplayMember = "Id";
			//this.lkIBT.Properties.ValueMember = "Id";

			//add two columns in the dropdown
			//LookUpColumnInfoCollection col4 = lkIBT.Properties.Columns;
			//a column to display values of the ProductID field
			//col4.Add(new LookUpColumnInfo("Id"));
			

			//set column widths according to their contents
			//lkIBT.Properties.BestFit();
			

			//enable auto completion search mode
			//lkIBT.Properties.SearchMode = SearchMode.AutoComplete;
			//the column against which to perform the search
			//lkIBT.Properties.AutoSearchColumnIndex = 1;


			//ArrayList _stockRequestStatus = new ArrayList();
			//ACMS.Util.StockRequestStatus[] srs = (ACMS.Util.StockRequestStatus[])Enum.GetValues(typeof(ACMS.Util.StockRequestStatus));
			//this.lkStatus.Properties.DataSource = srs;
			#endregion
			
		}

		private void GetStockRequestDetail()
		{

			ACMSLogic.StockRequest.StockRequest stockRequest = new ACMSLogic.StockRequest.StockRequest();
			DataTable dt = stockRequest.GetStockRequestEntriesById(Convert.ToInt32(this.StockRequestNo));

			if(dt!=null)
			{
				this.gridControl1.DataSource = dt;
				this.gridView1.Columns[0].OptionsColumn.AllowEdit=false;
			}
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
			this.txtDate = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
			this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
			this.lkBranchTo = new DevExpress.XtraEditors.LookUpEdit();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.rItem = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_Product = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.rQty = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lk_Style = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
			this.label1 = new System.Windows.Forms.Label();
			this.txtRequestedBy = new DevExpress.XtraEditors.TextEdit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkBranchTo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Product)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Style)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtRequestedBy.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// txtDate
			// 
			this.txtDate.Location = new System.Drawing.Point(8, 16);
			this.txtDate.Name = "txtDate";
			this.txtDate.Size = new System.Drawing.Size(48, 23);
			this.txtDate.TabIndex = 18;
			this.txtDate.Text = "Date";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 22;
			this.label2.Text = "To Branch";
			// 
			// dateEdit1
			// 
			this.dateEdit1.EditValue = new System.DateTime(2005, 10, 28, 0, 0, 0, 0);
			this.dateEdit1.Location = new System.Drawing.Point(80, 12);
			this.dateEdit1.Name = "dateEdit1";
			// 
			// dateEdit1.Properties
			// 
			this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.dateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dateEdit1.Size = new System.Drawing.Size(104, 20);
			this.dateEdit1.TabIndex = 17;
			// 
			// btn_Save
			// 
			this.btn_Save.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_Save.Location = new System.Drawing.Point(30, 84);
			this.btn_Save.Name = "btn_Save";
			this.btn_Save.TabIndex = 36;
			this.btn_Save.Text = "Save";
			this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
			// 
			// lkBranchTo
			// 
			this.lkBranchTo.Location = new System.Drawing.Point(80, 42);
			this.lkBranchTo.Name = "lkBranchTo";
			// 
			// lkBranchTo.Properties
			// 
			this.lkBranchTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkBranchTo.Properties.NullText = "Select Branch";
			this.lkBranchTo.Size = new System.Drawing.Size(144, 20);
			this.lkBranchTo.TabIndex = 37;
			this.lkBranchTo.EditValueChanged += new System.EventHandler(this.BranchTo_EditValueChanged);
			// 
			// gridControl1
			// 
			// 
			// gridControl1.EmbeddedNavigator
			// 
			this.gridControl1.EmbeddedNavigator.Name = "";
			this.gridControl1.Location = new System.Drawing.Point(8, 132);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												  this.repositoryItemTextEdit1,
																												  this.lk_Product,
																												  this.lk_Style});
			this.gridControl1.Size = new System.Drawing.Size(424, 216);
			this.gridControl1.TabIndex = 38;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.rItem,
																							 this.rQty,
																							 this.gridColumn2});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			// 
			// rItem
			// 
			this.rItem.Caption = "Item Code";
			this.rItem.ColumnEdit = this.lk_Product;
			this.rItem.FieldName = "strItemCode";
			this.rItem.Name = "rItem";
			this.rItem.Visible = true;
			this.rItem.VisibleIndex = 0;
			this.rItem.Width = 120;
			// 
			// lk_Product
			// 
			this.lk_Product.AutoHeight = false;
			this.lk_Product.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																									new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_Product.Name = "lk_Product";
			// 
			// rQty
			// 
			this.rQty.Caption = "Quantity";
			this.rQty.ColumnEdit = this.repositoryItemTextEdit1;
			this.rQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.rQty.FieldName = "nQuantity";
			this.rQty.Name = "rQty";
			this.rQty.Visible = true;
			this.rQty.VisibleIndex = 1;
			this.rQty.Width = 198;
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
			// lk_Style
			// 
			this.lk_Style.AutoHeight = false;
			this.lk_Style.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																								  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_Style.Name = "lk_Style";
			// 
			// btn_Add
			// 
			this.btn_Add.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btn_Add.Location = new System.Drawing.Point(114, 84);
			this.btn_Add.Name = "btn_Add";
			this.btn_Add.TabIndex = 39;
			this.btn_Add.Text = "Add";
			this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
			// 
			// simpleButton3
			// 
			this.simpleButton3.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.simpleButton3.Location = new System.Drawing.Point(198, 84);
			this.simpleButton3.Name = "simpleButton3";
			this.simpleButton3.TabIndex = 40;
			this.simpleButton3.Text = "Delete";
			this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
			// 
			// simpleButton4
			// 
			this.simpleButton4.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.simpleButton4.Location = new System.Drawing.Point(282, 84);
			this.simpleButton4.Name = "simpleButton4";
			this.simpleButton4.TabIndex = 41;
			this.simpleButton4.Text = "Search";
			this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(246, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 23);
			this.label1.TabIndex = 42;
			this.label1.Text = "Request By";
			// 
			// txtRequestedBy
			// 
			this.txtRequestedBy.EditValue = "";
			this.txtRequestedBy.Location = new System.Drawing.Point(312, 42);
			this.txtRequestedBy.Name = "txtRequestedBy";
			// 
			// txtRequestedBy.Properties
			// 
			this.txtRequestedBy.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.txtRequestedBy.Size = new System.Drawing.Size(104, 20);
			this.txtRequestedBy.TabIndex = 43;
			// 
			// frmNewStockRequest
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(438, 353);
			this.Controls.Add(this.txtRequestedBy);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.simpleButton4);
			this.Controls.Add(this.simpleButton3);
			this.Controls.Add(this.btn_Add);
			this.Controls.Add(this.gridControl1);
			this.Controls.Add(this.lkBranchTo);
			this.Controls.Add(this.btn_Save);
			this.Controls.Add(this.txtDate);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dateEdit1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmNewStockRequest";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Stock Request";
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkBranchTo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Product)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_Style)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtRequestedBy.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btn_Save_Click(object sender, System.EventArgs e)
		{
		//	simpleButton2_Click(sender,e);

			//if (btn_Save.Text=="Update") 
				
				canSave=true;

			if(this.lkBranchTo.EditValue.ToString()=="Select Branch" |this.lkBranchTo.EditValue.ToString()=="" )
			{
				ACMS.Utils.UI.ShowErrorMessage(this,"Please select valid Branch Code","Error");

			}
			else
			{
				ACMSLogic.StockRequest.StockRequest stockRequest = new ACMSLogic.StockRequest.StockRequest();
				SqlConnection sqlcon = new SqlConnection(SqlHelperUtils.connectionString);
				sqlcon.Open();

				SqlTransaction trans = sqlcon.BeginTransaction();
				if(canSave)
				{
					int nStockRequestNo = 0;
					if(isEdit)
					{
						if(!stockRequest.EditStockRequest(trans,Convert.ToDateTime(this.dateEdit1.EditValue),this.lkBranchTo.EditValue.ToString(),this.employee.Id,DateTime.Today,Convert.ToInt32(StockRequestNo),this.txtRequestedBy.Text))
						{
							trans.Rollback();
							sqlcon.Close();
							UI.ShowErrorMessage(this,"RollBack Transaction - Update StockRequest","Error");
							return;
						}
					}
					else
					{
						try
						{
							nStockRequestNo = stockRequest.SaveStockRequest(trans,DateTime.Today,this.terminalUser.Branch.Id,this.lkBranchTo.EditValue.ToString(),0,this.employee.Id,DateTime.Today,0,this.txtRequestedBy.Text);
						}
						catch(Exception ex)
						{
							UI.ShowErrorMessage(this,ex.Message,"Error");
						}

							if(nStockRequestNo==0)
						{
							trans.Rollback();
							sqlcon.Close();
							UI.ShowErrorMessage(this,"RollBack Transaction - Insert StockRequest ","Error");
							return;
						}
					}

					DevExpress.XtraGrid.Columns.GridColumn col1 = gridView1.Columns.ColumnByFieldName("strItemCode");
									
					DevExpress.XtraGrid.Columns.GridColumn col2 = gridView1.Columns.ColumnByFieldName("nQuantity");
					
					DevExpress.XtraGrid.Columns.GridColumn col3 = gridView1.Columns.ColumnByFieldName("nEntryID");
					
					for(int i=0;i<this.gridView1.DataRowCount;i++)
					{
						object cellValue1 = gridView1.GetRowCellValue(i, col1);
						
						object cellValue2 = gridView1.GetRowCellValue(i, col2);
						object cellValue3 = gridView1.GetRowCellValue(i, col3);

						if(cellValue1.ToString()=="" | cellValue2.ToString()=="")
						{
							ACMS.Utils.UI.ShowErrorMessage(this,"Please enter valid Product Code and valid quantity","Error");
							canSave=false;
							return;
						}
						else
						{
							if(isEdit)
							{
								if(!stockRequest.UpdateStockRequestEntries(trans,Convert.ToInt32(cellValue3.ToString()),Convert.ToInt32(cellValue2.ToString()),cellValue1.ToString(),this.lkBranchTo.EditValue.ToString()))
								{
									trans.Rollback();
									sqlcon.Close();
									UI.ShowErrorMessage(this,"RollBack Transaction - Update StockRequestEntries","Error");
									return;
								}
							}
							else
							{
								if(!stockRequest.SaveStockRequestEntries(trans,nStockRequestNo,cellValue1.ToString(),Convert.ToInt32(cellValue2.ToString()),this.lkBranchTo.EditValue.ToString()))
								{
									trans.Rollback();
									sqlcon.Close();
									UI.ShowErrorMessage(this,"RollBack Transaction - Insert StockRequestEntries","Error");
									return;
								}
							}
						}
					}

					ACMSLogic.AuditTrail.AuditTrail audit = new ACMSLogic.AuditTrail.AuditTrail();
					if(isEdit)
					{
						if(!audit.SaveAuditTrail(trans,7,"Update Stock Request No "+StockRequestNo,"Stock Request",this.employee.Id))
						{
							trans.Rollback();
							sqlcon.Close();
							UI.ShowErrorMessage(this,"RollBack Transaction - Insert Audit","Error");
							return;
						}
						
						UI.ShowErrorMessage(this,"Record Has Been Updated", "Save");
						
					}
					else
					{
						if(!audit.SaveAuditTrail(trans,7,"Add New Stock Request No "+nStockRequestNo,"Stock Request",this.employee.Id))
						{
							trans.Rollback();
							sqlcon.Close();
							UI.ShowErrorMessage(this,"RollBack Transaction - Insert Audit","Error");
							return;
						}
						
						UI.ShowErrorMessage(this,"Record Has Been Saved", "Save");
						
					}
					trans.Commit();
					sqlcon.Close();
					this.DialogResult = DialogResult.OK;
					this.Close();
					canSave=true;
				}
				
				#region nHibernate Code
//				if(canSave)
//				{
//					//Variable Hashtable
//					Hashtable htStockRequest = new Hashtable();
//					//htint
//					if(isEdit)
//					{
//						htStockRequest.Add("Id",this.StockRequestNo);
//
//						htStockRequest.Add("Branch_strBranchCodeTo",this.lkBranchTo.EditValue.ToString());
//					}
//					else
//					{
//						//DateTime
//						htStockRequest.Add("dtDate",DateTime.Today);
//						//Add pending value
//						htStockRequest.Add("nStatusID",0);//this.lkStatus.Properties.ValueMember);
//						//DateTime
//						htStockRequest.Add("dtLastEditDate",DateTime.Today);
//
//						//string
//						//htStockRequest.Add("Branch_strBranchCodeFrom",this.lkBranchTo.EditValue.ToString());
//						htStockRequest.Add("Branch_strBranchCodeFrom",this.terminalUser.Branch.Id);
//
//						//string
//						//htStockRequest.Add("Branch_strBranchCodeTo",this.terminalUser.Branch.Id);
//						htStockRequest.Add("Branch_strBranchCodeTo",this.lkBranchTo.EditValue.ToString());
//			
//						//int
//						htStockRequest.Add("Employee_nEmployeeID",this.employee.Id);
//					}
//			
//					//int
//					//htStockRequest.Add("IBT_nIBTNo",this.lkIBT.EditValue.ToString());
//
//					ArrayList stockRequestList = new ArrayList();
//		
//					DevExpress.XtraGrid.Columns.GridColumn col1 = gridView1.Columns.ColumnByFieldName("ProductStrItemCode");
//					DevExpress.XtraGrid.Columns.GridColumn col2 = gridView1.Columns.ColumnByFieldName("NQuantity");
//
//					for(int i=0;i<this.gridView1.DataRowCount;i++)
//					{
//
//						object cellValue1 = gridView1.GetRowCellValue(i, "ProductStrItemCode");
//						object cellValue2 = gridView1.GetRowCellValue(i, col2);
//						if(cellValue1.ToString()=="" | cellValue2.ToString()=="")
//						{
//							ACMS.Utils.UI.ShowErrorMessage(this,"Please enter valid Product Code and valid quantity","Error");
//							canSave=false;
//							return;
//						}
//						else
//						{
//							Hashtable htStockRequestEntries = new Hashtable();
//
//							htStockRequestEntries.Add("Product_strItemCode",cellValue1.ToString());
//							//htStockRequestEntries.Add("Test_strProductCode",2);
//							//int
//							htStockRequestEntries.Add("nQuantity",cellValue2.ToString());
//
//							stockRequestList.Add(htStockRequestEntries);
//						}
//					}
//
//					//Object In ArrayList
//					htStockRequest.Add("StockRequestEntries",stockRequestList);
//
//					Fc.StockRequestFactory srf = new Fc.StockRequestFactory();
//
//					if(canSave)
//					{
//						try
//						{
//							if(!isEdit)
//							{
//								srf.MakeSaveStockRequest(htStockRequest);
//								SaveAuditTrail("Add New Stock Request","Stock Request",this.employee.Id);
//								MessageBox.Show("Record Has Been Saved", "Save");
//							}
//							else
//							{
//								srf.MakeUpdateStockRequest(htStockRequest);
//								SaveAuditTrail("Update Stock Request","Stock Request",this.employee.Id);
//								MessageBox.Show("Record Has Been Updated", "Updated");
//								isEdit=false;
//							}
//							this.DialogResult = DialogResult.OK;
//							this.Close();
//							canSave=true;
//						}
//						catch
//						{
//							ACMS.Utils.UI.ShowErrorMessage(this,"Please enter valid Product Code and valid Quantity","Error");
//						}
//					}
//					
//				}
//				else
//				{
//					ACMS.Utils.UI.ShowErrorMessage(this,"Please enter a valid quantity","Error");
//				}
				#endregion
			}
		}

		private void SaveAuditTrail(int nAuditTypeId,string strReference,string strAuditEntry,int employeeId)
		{
//			ACMS.Util.AuditTrail at = new ACMS.Util.AuditTrail();
//			at.SaveAuditTrail(strReference,strAuditEntry,employeeId);
			ACMSLogic.AuditTrail.AuditTrail auditTrail = new ACMSLogic.AuditTrail.AuditTrail();
			auditTrail.SaveAuditTrail(nAuditTypeId,strReference,strAuditEntry,employeeId);

		}

		

		private void btn_Add_Click(object sender, System.EventArgs e)
		{
			if(canAdd)
			{
				if(this.lkBranchTo.EditValue.ToString()=="" ) ACMS.Utils.UI.ShowErrorMessage(this,"Please select valid Branch Code","Error");
				
				else if(this.btn_Add.Text=="Cancel")this.Close();
				
				else
				{
					CheckAvailableQuantity(sender,null);						
					if(canSave)
					{
						int currentRow;
						currentRow = gridView1.FocusedRowHandle;
					//	if(currentRow < 0)
					//	{
							currentRow = gridView1.GetDataRowHandleByGroupRowHandle(currentRow);
							gridView1.AddNewRow();
							gridView1.ShowEditor();
				//		}
					}//can save
				}//end if
			}
			else
			{
				UI.ShowErrorMessage(this,"Invalid Operation. Please change valid product quantity","Error");
				//this.gridView1.MoveBy(inValidQuantityRow);
			}
			
		}

		private void simpleButton3_Click(object sender, System.EventArgs e)
		{
			if(this.lkBranchTo.EditValue.ToString()=="Select Branch" |this.lkBranchTo.EditValue.ToString()=="" )
			{
				ACMS.Utils.UI.ShowErrorMessage(this,"Please select valid Branch Code","Error");

			}
			else
			{
				if(gridView1.FocusedRowHandle==inValidQuantityRow)
				{
					this.canAdd=true;
					this.CanSave=true;
				}
				this.gridView1.DeleteRow(gridView1.FocusedRowHandle);
			}
		}

		

		private void CheckAvailableQuantity(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
		{
			if(!isEdit)
			{
				if(CheckDuplicate())
				{
					DataRow row = this.gridView1.GetDataRow(gridView1.FocusedRowHandle);

					if(row["strItemCode"].ToString().Length>0 && row["strItemCode"].ToString()!="Select Product")
					{
							string strProductCode = row["strItemCode"].ToString(); 
							int quantityRequest = Convert.ToInt32(row["nQuantity"].ToString()); 
		
							ACMSLogic.StockRequest.StockRequest stockRequest = new ACMSLogic.StockRequest.StockRequest();
							if(!stockRequest.GetAvailableQuantity(strProductCode,this.lkBranchTo.EditValue.ToString(),quantityRequest))
							{
								UI.ShowErrorMessage(this,"Quantity request exceeded Balance","Error");
								this.canSave=false;
								this.canAdd=false;
								inValidQuantityRow=gridView1.FocusedRowHandle;
							}
							else
							{
								this.canSave=true;
								this.canAdd=true;
								return;
							}
						}
					}
			}
			this.canSave=false;
		}

		private void BranchTo_EditValueChanged(object sender, System.EventArgs e)
		{
			
			this.lk_Product.Columns.Clear();
			//this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
			//																		   new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strItemCode", "Product Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
			lk_Product_Init();

			try
			{
				this.CheckAvailableQuantity(sender,null);
			}
			catch
			{
				//
			}
		}

		private void lk_Product_Init()
		{
	
			//DataSet _ds = new DataSet();
			ACMSLogic.StockRequest.StockRequest stockRequest = new ACMSLogic.StockRequest.StockRequest();
			
			//string strSQL = "select * from tblproduct";
			//SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			//_ds.Tables[0];
			DataTable dt = stockRequest.GetProductByBranch(this.lkBranchTo.EditValue.ToString());//pr.GetProductByBranch(this.lkBranchTo.EditValue.ToString());

			lk_Product.BestFit();
					
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[6];
						
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strItemCode","Item Code",50,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",50,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[2] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strStyle","Style",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[3] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strColor","Color",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[4] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strSize","Size",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[5] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nQuantity","Quantity",10,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);

			try
			{
				new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_Product,dt,col,"strItemCode","strItemCode","Item Code");
			}
			catch(Exception ex)
			{
				return;
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
