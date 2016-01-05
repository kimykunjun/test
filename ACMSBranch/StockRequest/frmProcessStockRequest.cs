using System;
using System.Drawing;
using System.Collections;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using ACMS.Utils;
//using Rp = Acms.Core.Repository;
//using Fc = Acms.Core.Factory;
using Acms.Core.Domain;
using DevExpress.XtraEditors.Controls;
using ACMSLogic;


namespace ACMS.ACMSBranch.StockRequest
{
	/// <summary>
	/// Summary description for frmProcessStockRequest.
	/// </summary>
	public class frmProcessStockRequest : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.LookUpEdit lkBranchTo;
		//private DevExpress.XtraEditors.TextEdit txtStockRequest;
		private System.Windows.Forms.Label txtDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.DateEdit dateEdit1;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private DevExpress.XtraEditors.TextEdit txtBranchFrom;
		private DevExpress.XtraEditors.TextEdit txtStockRequestNo;
		private DevExpress.XtraEditors.SimpleButton Delete_ProductList_Btn;
		private DevExpress.XtraEditors.SimpleButton Process_Btn;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.MemoEdit txtRemarks;

		private bool isEdit =false;
		private string _stockRequestNo;
		private string _strBranchCodeFrom;
		private Acms.Core.Domain.Employee employee;
		private Acms.Core.Domain.TerminalUser terminalUser;

		//private Acms.Core.Domain.StockRequest sr;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmProcessStockRequest()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}


		public Employee Employee
		{
			set{employee=value;}
		}

		public TerminalUser TerminalUser
		{
			set{terminalUser=value;}
		}

		public string StrBranchCodeFrom
		{
			set{_strBranchCodeFrom=value;}
		}

		public bool IsEdit
		{
			set{isEdit=value;}
			get{return isEdit;}
		}

		public string StockRequestNo
		{
			set
			{
				_stockRequestNo=value;
				this.txtStockRequestNo.Text=value;}
			get{return _stockRequestNo;}
		}

		public void LoadStockRequestDetail_Edit()
		{
//			Rp.StockRequestRepository srp = new Rp.StockRequestRepository();
//			Acms.Core.Domain.StockRequest sr = srp.GetStockRequestById(Convert.ToInt32(this.StockRequestNo));

//			this.sr=sr;
//			
//			this.txtBranchFrom.Text = sr.BranchFrom.Id;
			
			
			ACMSLogic.StockRequest.StockRequest stockRequest = new ACMSLogic.StockRequest.StockRequest();
			DataTable dt = stockRequest.GetStockRequestById(Convert.ToInt32(this.StockRequestNo));

			if(dt!=null)
			{
				this.GetStockRequestDetail();

				this.dateEdit1.EditValue = Convert.ToDateTime(dt.Rows[0]["dtDate"].ToString()).ToShortDateString();
				this.txtBranchFrom.Text = dt.Rows[0]["strBranchCodeTo"].ToString();
				this.txtStockRequestNo.Enabled=false;
				this.txtBranchFrom.Enabled=false;
			}



			GetStockRequestDetail();
		}

		private void GetStockRequestDetail()
		{
			ACMSLogic.StockRequest.StockRequest stockRequest = new ACMSLogic.StockRequest.StockRequest();
			DataTable dt = stockRequest.GetStockRequestEntriesById(Convert.ToInt32(this.StockRequestNo));

			if(dt!=null)
			{
				this.gridControl1.DataSource = dt;
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
			this.lkBranchTo = new DevExpress.XtraEditors.LookUpEdit();
			this.txtDate = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
			this.Delete_ProductList_Btn = new DevExpress.XtraEditors.SimpleButton();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.Process_Btn = new DevExpress.XtraEditors.SimpleButton();
			this.txtStockRequestNo = new DevExpress.XtraEditors.TextEdit();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtBranchFrom = new DevExpress.XtraEditors.TextEdit();
			this.label3 = new System.Windows.Forms.Label();
			this.txtRemarks = new DevExpress.XtraEditors.MemoEdit();
			((System.ComponentModel.ISupportInitialize)(this.lkBranchTo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtStockRequestNo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtBranchFrom.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// lkBranchTo
			// 
			this.lkBranchTo.Location = new System.Drawing.Point(96, -32);
			this.lkBranchTo.Name = "lkBranchTo";
			// 
			// lkBranchTo.Properties
			// 
			this.lkBranchTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkBranchTo.Properties.NullText = "";
			this.lkBranchTo.Size = new System.Drawing.Size(144, 20);
			this.lkBranchTo.TabIndex = 47;
			// 
			// txtDate
			// 
			this.txtDate.Location = new System.Drawing.Point(-66, -64);
			this.txtDate.Name = "txtDate";
			this.txtDate.Size = new System.Drawing.Size(56, 31);
			this.txtDate.TabIndex = 42;
			this.txtDate.Text = "Date";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(174, -64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 31);
			this.label1.TabIndex = 43;
			this.label1.Text = "StockRequestNo";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, -32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 31);
			this.label2.TabIndex = 44;
			this.label2.Text = "Branch To";
			// 
			// dateEdit1
			// 
			this.dateEdit1.EditValue = new System.DateTime(2005, 10, 28, 0, 0, 0, 0);
			this.dateEdit1.Location = new System.Drawing.Point(6, -64);
			this.dateEdit1.Name = "dateEdit1";
			// 
			// dateEdit1.Properties
			// 
			this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit1.Size = new System.Drawing.Size(104, 20);
			this.dateEdit1.TabIndex = 41;
			// 
			// Delete_ProductList_Btn
			// 
			this.Delete_ProductList_Btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.Delete_ProductList_Btn.Location = new System.Drawing.Point(184, 168);
			this.Delete_ProductList_Btn.Name = "Delete_ProductList_Btn";
			this.Delete_ProductList_Btn.Size = new System.Drawing.Size(123, 23);
			this.Delete_ProductList_Btn.TabIndex = 57;
			this.Delete_ProductList_Btn.Text = "Delete Request Detail";
			this.Delete_ProductList_Btn.Click += new System.EventHandler(this.Delete_ProductList_Btn_Click);
			// 
			// gridControl1
			// 
			// 
			// gridControl1.EmbeddedNavigator
			// 
			this.gridControl1.EmbeddedNavigator.Name = "";
			this.gridControl1.Location = new System.Drawing.Point(8, 198);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												  this.repositoryItemLookUpEdit1});
			this.gridControl1.Size = new System.Drawing.Size(424, 216);
			this.gridControl1.TabIndex = 55;
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
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Item Code";
			this.gridColumn1.FieldName = "strItemCode";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsColumn.AllowEdit = false;
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Quantity";
			this.gridColumn3.FieldName = "nQuantity";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 1;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "nEntryId";
			this.gridColumn2.FieldName = "nEntryID";
			this.gridColumn2.Name = "gridColumn2";
			// 
			// repositoryItemLookUpEdit1
			// 
			this.repositoryItemLookUpEdit1.AutoHeight = false;
			this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
			// 
			// Process_Btn
			// 
			this.Process_Btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.Process_Btn.Location = new System.Drawing.Point(104, 168);
			this.Process_Btn.Name = "Process_Btn";
			this.Process_Btn.TabIndex = 53;
			this.Process_Btn.Text = "Process";
			this.Process_Btn.Click += new System.EventHandler(this.Process_Btn_Click);
			// 
			// txtStockRequestNo
			// 
			this.txtStockRequestNo.EditValue = "";
			this.txtStockRequestNo.Location = new System.Drawing.Point(104, 8);
			this.txtStockRequestNo.Name = "txtStockRequestNo";
			this.txtStockRequestNo.Size = new System.Drawing.Size(48, 20);
			this.txtStockRequestNo.TabIndex = 52;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 23);
			this.label4.TabIndex = 50;
			this.label4.Text = "StockRequestNo";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 36);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 16);
			this.label5.TabIndex = 51;
			this.label5.Text = "Branch From";
			// 
			// txtBranchFrom
			// 
			this.txtBranchFrom.EditValue = "";
			this.txtBranchFrom.Location = new System.Drawing.Point(104, 36);
			this.txtBranchFrom.Name = "txtBranchFrom";
			this.txtBranchFrom.Size = new System.Drawing.Size(144, 20);
			this.txtBranchFrom.TabIndex = 58;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 66);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 59;
			this.label3.Text = "Remarks";
			// 
			// txtRemarks
			// 
			this.txtRemarks.EditValue = "";
			this.txtRemarks.Location = new System.Drawing.Point(104, 66);
			this.txtRemarks.Name = "txtRemarks";
			this.txtRemarks.Size = new System.Drawing.Size(328, 96);
			this.txtRemarks.TabIndex = 60;
			// 
			// frmProcessStockRequest
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(442, 419);
			this.Controls.Add(this.txtRemarks);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtBranchFrom);
			this.Controls.Add(this.Delete_ProductList_Btn);
			this.Controls.Add(this.gridControl1);
			this.Controls.Add(this.Process_Btn);
			this.Controls.Add(this.txtStockRequestNo);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lkBranchTo);
			this.Controls.Add(this.txtDate);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dateEdit1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmProcessStockRequest";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Process Stock Request";
			((System.ComponentModel.ISupportInitialize)(this.lkBranchTo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtStockRequestNo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtBranchFrom.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void Process_Btn_Click(object sender, System.EventArgs e)
		{
			ACMSLogic.StockRequest.StockRequest stockRequest = new ACMSLogic.StockRequest.StockRequest();
			SqlConnection sqlcon = new SqlConnection(SqlHelperUtils.connectionString);
			sqlcon.Open();

			SqlTransaction trans = sqlcon.BeginTransaction();

			//string strBranchCodeFrom=this.terminalUser.Branch.Id;
			//string strBranchCodeTo=this._strBranchCodeTo;

			
			int IBTNo = stockRequest.ProcessStockRequest(trans,DateTime.Now,0,DateTime.Now,this.txtRemarks.Text,this.terminalUser.Branch.Id,this._strBranchCodeFrom,this.employee.Id);
			
			DevExpress.XtraGrid.Columns.GridColumn col1 = gridView1.Columns.ColumnByFieldName("strItemCode");
			DevExpress.XtraGrid.Columns.GridColumn col2 = gridView1.Columns.ColumnByFieldName("nQuantity");
			DevExpress.XtraGrid.Columns.GridColumn col3 = gridView1.Columns.ColumnByFieldName("nEntryID");
			
			for(int i=0;i<this.gridView1.DataRowCount;i++)
			{
				object cellValue1 = gridView1.GetRowCellValue(i, col1);
				object cellValue2 = gridView1.GetRowCellValue(i, col2);
				object cellValue3 = gridView1.GetRowCellValue(i, col3);
				if(!stockRequest.ProcessStockRequestEntries(trans,cellValue1.ToString(),Convert.ToInt32(cellValue2.ToString()),IBTNo,this.terminalUser.Branch.Id,Convert.ToInt32(cellValue3.ToString())))
				{
					int rowNumber =i+1;
					trans.Rollback();
					sqlcon.Close();
					UI.ShowErrorMessage(this,"RollBack Transaction - Process StockRequest :: Invalid Quantity For Product = "+cellValue1.ToString(),"Error");
					return;
				}

			}

			if(!stockRequest.UpdateStockRequestIBTNo(trans,IBTNo,Convert.ToInt32(this.StockRequestNo)))
			{
				trans.Rollback();
				sqlcon.Close();
				UI.ShowErrorMessage(this,"RollBack Transaction - Update StockRequest","Error");
				return;
			}

			
			ACMSLogic.AuditTrail.AuditTrail audit = new ACMSLogic.AuditTrail.AuditTrail();
			audit.SaveAuditTrail(trans,7,"Save Process IBT No "+IBTNo,"IBT",this.employee.Id);
			audit.SaveAuditTrail(trans,7,"Update Stock Request Status No "+this.StockRequestNo,"IBT",this.employee.Id);
			
			trans.Commit();
			sqlcon.Close();

			MessageBox.Show("Record Has Been Saved", "Save");

			this.DialogResult = DialogResult.OK;
			
			#region nHibernate Code
//			//Variable Hashtable
//			Hashtable htIBT = new Hashtable();
//			//htint
//			//htIBT.Add("Id","");
//			//DateTime
//			htIBT.Add("dtDate",DateTime.Now);
//			//int
//			//Status 0 - Pending Request
//			htIBT.Add("nStatusID",0);
//			//DateTime
//			htIBT.Add("dtLastEditDate",DateTime.Now);
//			//string
//			htIBT.Add("strRemarks",this.txtRemarks.Text);
//
//			//string
//			htIBT.Add("Branch_strBranchCodeFrom",this.terminalUser.Branch.Id);
//
//			//string
//			htIBT.Add("Branch_strBranchCodeTo",sr.BranchFrom.Id);
//
//			//int
//			htIBT.Add("Employee_nEmployeeID",this.employee.Id);
//
//			ArrayList ibtEntryList = new ArrayList();
//
//			DevExpress.XtraGrid.Columns.GridColumn col1 = gridView1.Columns.ColumnByFieldName("ProductStrItemCode");
//			DevExpress.XtraGrid.Columns.GridColumn col2 = gridView1.Columns.ColumnByFieldName("NQuantity");
//
//			for(int i=0;i<this.gridView1.DataRowCount;i++)
//			{
//
//				object cellValue1 = gridView1.GetRowCellValue(i, "ProductStrItemCode");
//				object cellValue2 = gridView1.GetRowCellValue(i, col2);
//				//Variable Hashtable
//				Hashtable htIBTEntries = new Hashtable();
//				//string
//				htIBTEntries.Add("strItemCode",cellValue1.ToString());
//				//int
//				htIBTEntries.Add("nQuantity",cellValue2.ToString());
//
//				ibtEntryList.Add(htIBTEntries);
//	
//				//Need to refactoring using Service Layer later
//				Rp.ProductRepository pr = new Rp.ProductRepository();
//				pr.UpdateProductInventoryQuantity(cellValue1.ToString(),this.terminalUser.Branch.Id,"VW",Convert.ToInt32(cellValue2.ToString()),0);
//
//			}
//
//			htIBT.Add("IBTEntries",ibtEntryList);
//
//			//Save IBT and IBTEntries
//			Fc.IBTFactory ifactory = new Fc.IBTFactory();
//			ifactory.MakeSaveIBT(htIBT);
//
//			//Update stock request status
//			Fc.StockRequestFactory srf = new Fc.StockRequestFactory();
//			Hashtable htStockRequest = new Hashtable();
//			htStockRequest.Add("Id",StockRequestNo);
//			
//			//int
//			htStockRequest.Add("nStatusID",1);
//
//			htStockRequest.Add("IBT_nIBTNo",Fc.IBTFactory.GetIBT.Id);
//			
//			srf.MakeUpdateStockRequest(htStockRequest);
//			
//			//Update ProductInventory for Virtual Warehouse
//			
//			
//
			#endregion
		}

		private void Delete_ProductList_Btn_Click(object sender, System.EventArgs e)
		{
			this.gridView1.DeleteRow(gridView1.FocusedRowHandle);
		}

		private void SaveAuditTrail(string strReference,string strAuditEntry,int employeeId)
		{
			//ACMS.Util.AuditTrail at = new ACMS.Util.AuditTrail();
			//at.SaveAuditTrail(strReference,strAuditEntry,employeeId);
		}
	}
}
