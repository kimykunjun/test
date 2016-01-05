using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
////using Rp = Acms.Core.Repository;
////using Fc = Acms.Core.Factory;
using Acms.Core.Domain;
//using Acms.Core.DataAccess;
using ACMSLogic;
using System.Data.SqlClient;
using ACMS.Utils;

using DevExpress.XtraEditors.Controls;

namespace ACMS.ACMSBranch.PromotionAdjustment
{
	/// <summary>
	/// Summary description for frmNewInterBranchTransfer.
	/// </summary>
	public class frmNewPromotionAdjustment : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private System.Windows.Forms.Label label3;

			
		private Acms.Core.Domain.Employee employee;
		private Acms.Core.Domain.TerminalUser terminalUser;
		private string strBranchCode;
		private string nEntryID="0";
		private string panel;
		
		
		private System.Windows.Forms.Label txtPromotionCode;
		private DevExpress.XtraEditors.TextEdit textEdit1;
		private DevExpress.XtraEditors.TextEdit textEdit2;
		
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;

		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmNewPromotionAdjustment()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public void InitData(string type,string strPromotionCode,string strBranchCode,string strReceiptNo,string nEntryID,string panel)
		{
			this.strBranchCode=strBranchCode;
			this.nEntryID=nEntryID;
			this.panel=panel;
			if(this.nEntryID=="")
				this.nEntryID="0";
			BindPage(type,strPromotionCode,strBranchCode,strReceiptNo);
			
		}

		

		public Employee Employee
		{
			set{employee=value;}
		}

		public TerminalUser TerminalUser
		{
			set{terminalUser=value;}
		}

		

		private void BindPage(string type,string strPromotionCode,string strBranchCode,string strReceiptNo)
		{
			
			this.textEdit2.Enabled=false;
			this.textEdit1.Enabled=false;
			simpleButton1.Enabled=true;
			this.textEdit1.Text=strPromotionCode;
			this.textEdit2.Text=strReceiptNo;

			DataSet ds = null;
			ACMSLogic.Promotion.Promotion promotion = new ACMSLogic.Promotion.Promotion();
			ds = promotion.FindPromotionByPromotionCode(strPromotionCode,strBranchCode,strReceiptNo,type,panel);
			
		
			if(ds!=null)
			{
				if(ds.Tables.Count>0)
				{
					if(ds.Tables[0].Rows.Count>0)
					{
						if(type=="View")
						{
							foreach(DataRow dr in ds.Tables[0].Rows)
							{
								dr["OutStock"]=true;
							}
							this.gridView1.OptionsBehavior.Editable=false;
						}
						this.simpleButton1.Enabled=false;
						this.gridControl1.DataSource=ds.Tables[0];
					}
					else
					{
						this.simpleButton1.Enabled=false;
					}
				}
				else
				{
					UI.ShowErrorMessage(this,"No record(s) found","Error");
				}

			}

			
			
//			
//			DevExpress.XtraGrid.Columns.GridColumn col3 = gridView1.Columns.ColumnByFieldName("OutStock");
//
//
//			for(int i=0;i<this.gridView1.DataRowCount;i++)
//			{
//				this.gridView1.g
//			}
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
			this.txtPromotionCode = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
			this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
			this.SuspendLayout();
			// 
			// simpleButton1
			// 
			this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.simpleButton1.Enabled = false;
			this.simpleButton1.Location = new System.Drawing.Point(120, 306);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.TabIndex = 51;
			this.simpleButton1.Text = "Save";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// txtPromotionCode
			// 
			this.txtPromotionCode.Location = new System.Drawing.Point(8, 8);
			this.txtPromotionCode.Name = "txtPromotionCode";
			this.txtPromotionCode.Size = new System.Drawing.Size(112, 23);
			this.txtPromotionCode.TabIndex = 39;
			this.txtPromotionCode.Text = "Promotion Code";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 23);
			this.label3.TabIndex = 42;
			this.label3.Text = "ReceiptNo";
			// 
			// textEdit1
			// 
			this.textEdit1.EditValue = "";
			this.textEdit1.Location = new System.Drawing.Point(120, 8);
			this.textEdit1.Name = "textEdit1";
			// 
			// textEdit1.Properties
			// 
			this.textEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.textEdit1.Size = new System.Drawing.Size(104, 20);
			this.textEdit1.TabIndex = 52;
			// 
			// textEdit2
			// 
			this.textEdit2.EditValue = "";
			this.textEdit2.Location = new System.Drawing.Point(120, 32);
			this.textEdit2.Name = "textEdit2";
			// 
			// textEdit2.Properties
			// 
			this.textEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.textEdit2.Size = new System.Drawing.Size(104, 20);
			this.textEdit2.TabIndex = 53;
			// 
			// gridControl1
			// 
			// 
			// gridControl1.EmbeddedNavigator
			// 
			this.gridControl1.EmbeddedNavigator.Name = "";
			this.gridControl1.Location = new System.Drawing.Point(120, 60);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												  this.repositoryItemCheckEdit2});
			this.gridControl1.Size = new System.Drawing.Size(456, 234);
			this.gridControl1.TabIndex = 55;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn1,
																							 this.gridColumn3,
																							 this.gridColumn2,
																							 this.gridColumn4});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Item Code";
			this.gridColumn1.FieldName = "strItemCode";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Promotion Code";
			this.gridColumn3.FieldName = "strPromotionCode";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 1;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "OutStock";
			this.gridColumn2.ColumnEdit = this.repositoryItemCheckEdit2;
			this.gridColumn2.FieldName = "OutStock";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 2;
			// 
			// repositoryItemCheckEdit2
			// 
			this.repositoryItemCheckEdit2.AutoHeight = false;
			this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
			this.repositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "PromotionType";
			this.gridColumn4.FieldName = "PromotionType";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 3;
			// 
			// simpleButton2
			// 
			this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.simpleButton2.Location = new System.Drawing.Point(204, 306);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.TabIndex = 56;
			this.simpleButton2.Text = "Cancel";
			this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
			// 
			// frmNewPromotionAdjustment
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(582, 335);
			this.Controls.Add(this.simpleButton2);
			this.Controls.Add(this.gridControl1);
			this.Controls.Add(this.textEdit2);
			this.Controls.Add(this.textEdit1);
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.txtPromotionCode);
			this.Controls.Add(this.label3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmNewPromotionAdjustment";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Adjustment";
			((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			bool isSave=false;
			bool isError=false;
			DevExpress.XtraGrid.Columns.GridColumn col1 = gridView1.Columns.ColumnByFieldName("strItemCode");
			DevExpress.XtraGrid.Columns.GridColumn col2 = gridView1.Columns.ColumnByFieldName("strPromotionCode");
			DevExpress.XtraGrid.Columns.GridColumn col3 = gridView1.Columns.ColumnByFieldName("OutStock");

			SqlConnection sqlcon = new SqlConnection(SqlHelperUtils.connectionString);
			sqlcon.Open();

			SqlTransaction tran = sqlcon.BeginTransaction();

			ACMSLogic.Promotion.Promotion promotion = new ACMSLogic.Promotion.Promotion();
			//promotion.DeleteAdjustmentPromotion(tran,this.textEdit2.Text,this.textEdit1.Text);

			for(int i=0;i<this.gridView1.DataRowCount;i++)
			{
				object cellValue1 = gridView1.GetRowCellValue(i, col1);
				object cellValue3 = gridView1.GetRowCellValue(i, col3);
				
				if(cellValue3!=null)
				{
					if(Convert.ToBoolean(cellValue3.ToString()))
					{
						
						if(promotion.UpdateAdjustmentPromotion(tran,this.textEdit2.Text,cellValue1.ToString(),this.textEdit1.Text,strBranchCode,Convert.ToInt32(nEntryID),panel))
						{
							isSave=true;
						}
						else
						{
							isError=false;
						}

					}
				}
			}
		
			if(isError)
			{
				Utils.UI.ShowMessage(this,"Some of the record cannot be saved into database. Please contact System Administrator!");
			}
			else
			{
				if(isSave)
					Utils.UI.ShowMessage(this,"Record Has Been Updated");

				tran.Commit();
			}
			
			this.DialogResult = DialogResult.OK;
			this.Close();

		}

		private void SaveAuditTrail(string strReference,string strAuditEntry,int employeeId)
		{
//			ACMS.Util.AuditTrail at = new ACMS.Util.AuditTrail();
//			at.SaveAuditTrail(strReference,strAuditEntry,employeeId);
			ACMSLogic.AuditTrail.AuditTrail auditTrail = new ACMSLogic.AuditTrail.AuditTrail();
			auditTrail.SaveAuditTrail(1,strReference,strAuditEntry,employeeId);

		}

		private void EditValueChanged(object sender, System.EventArgs e)
		{
//			
		}

		private void repositoryItemCheckEdit2_Click(object sender, EventArgs e)
		{
			DevExpress.XtraEditors.CheckEdit cd = sender as DevExpress.XtraEditors.CheckEdit;
			
			if(cd.Checked)
			{
				cd.Visible=true;
			}
			else
			{
				cd.Checked=true;
			}
		}

		private void repositoryItemCheckEdit2_CheckStateChanged(object sender, EventArgs e)
		{
			
		}

		private void simpleButton2_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
