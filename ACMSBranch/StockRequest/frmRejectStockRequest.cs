using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


////using Rp = Acms.Core.Repository;
////using Fc = Acms.Core.Factory;
using Acms.Core.Domain;
using DevExpress.XtraEditors.Controls;

namespace ACMS.ACMSBranch.StockRequest
{
	/// <summary>
	/// Summary description for frmRejectStockRequest.
	/// </summary>
	public class frmRejectStockRequest : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.MemoEdit txtRemarks;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.TextEdit txtBranchFrom;
		private DevExpress.XtraEditors.TextEdit txtStockRequestNo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private bool isEdit =false;
		private string _stockRequestNo;
		private DevExpress.XtraEditors.SimpleButton Reject_Btn;
		private Acms.Core.Domain.Employee employee;
		private Acms.Core.Domain.TerminalUser terminalUser;
		private string _branchFrom;

		public frmRejectStockRequest()
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

		public string BranchFrom
		{
			set{_branchFrom=value;}
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

		public void BindEdit()
		{
			this.txtBranchFrom.Text=_branchFrom;
			this.txtStockRequestNo.Enabled=false;
			this.txtBranchFrom.Enabled=false;
		}

		public void BindPage()
		{
			
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
			this.txtRemarks = new DevExpress.XtraEditors.MemoEdit();
			this.label3 = new System.Windows.Forms.Label();
			this.txtBranchFrom = new DevExpress.XtraEditors.TextEdit();
			this.Reject_Btn = new DevExpress.XtraEditors.SimpleButton();
			this.txtStockRequestNo = new DevExpress.XtraEditors.TextEdit();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtBranchFrom.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtStockRequestNo.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// txtRemarks
			// 
			this.txtRemarks.EditValue = "";
			this.txtRemarks.Location = new System.Drawing.Point(104, 54);
			this.txtRemarks.Name = "txtRemarks";
			// 
			// txtRemarks.Properties
			// 
			this.txtRemarks.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.txtRemarks.Size = new System.Drawing.Size(328, 96);
			this.txtRemarks.TabIndex = 68;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 54);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 67;
			this.label3.Text = "Remarks *";
			// 
			// txtBranchFrom
			// 
			this.txtBranchFrom.EditValue = "";
			this.txtBranchFrom.Location = new System.Drawing.Point(104, 30);
			this.txtBranchFrom.Name = "txtBranchFrom";
			// 
			// txtBranchFrom.Properties
			// 
			this.txtBranchFrom.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.txtBranchFrom.Size = new System.Drawing.Size(144, 20);
			this.txtBranchFrom.TabIndex = 66;
			// 
			// Reject_Btn
			// 
			this.Reject_Btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.Reject_Btn.Location = new System.Drawing.Point(104, 156);
			this.Reject_Btn.Name = "Reject_Btn";
			this.Reject_Btn.TabIndex = 64;
			this.Reject_Btn.Text = "Reject";
			this.Reject_Btn.Click += new System.EventHandler(this.Process_Btn_Click);
			// 
			// txtStockRequestNo
			// 
			this.txtStockRequestNo.EditValue = "";
			this.txtStockRequestNo.Location = new System.Drawing.Point(104, 8);
			this.txtStockRequestNo.Name = "txtStockRequestNo";
			// 
			// txtStockRequestNo.Properties
			// 
			this.txtStockRequestNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.txtStockRequestNo.Size = new System.Drawing.Size(48, 20);
			this.txtStockRequestNo.TabIndex = 63;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 23);
			this.label4.TabIndex = 61;
			this.label4.Text = "StockRequestNo";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 30);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 16);
			this.label5.TabIndex = 62;
			this.label5.Text = "Branch From";
			// 
			// frmRejectStockRequest
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(442, 185);
			this.Controls.Add(this.txtRemarks);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtBranchFrom);
			this.Controls.Add(this.Reject_Btn);
			this.Controls.Add(this.txtStockRequestNo);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmRejectStockRequest";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Reject StockRequest";
			((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtBranchFrom.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtStockRequestNo.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void Process_Btn_Click(object sender, System.EventArgs e)
		{
			//Update stock request status
			if(this.txtRemarks.Text=="")
			{
				ACMS.Utils.UI.ShowErrorMessage(this,"Please enter reason for rejection","Error");
			}
			else
			{
				ACMSLogic.StockRequest.StockRequest stockRequest = new ACMSLogic.StockRequest.StockRequest();
				stockRequest.RejectStockRequest(Convert.ToInt32(StockRequestNo),2,this.txtRemarks.Text);
				ACMSLogic.AuditTrail.AuditTrail audit = new ACMSLogic.AuditTrail.AuditTrail();
				audit.SaveAuditTrail(7,"Reject Stock Request Status No "+this.StockRequestNo,"Stock Request",this.employee.Id);

			
//				Fc.StockRequestFactory srf = new Fc.StockRequestFactory();
//				Hashtable htStockRequest = new Hashtable();
//				htStockRequest.Add("Id",StockRequestNo);
//			
//				//int
//				htStockRequest.Add("nStatusID",2);
//
//				htStockRequest.Add("strRemarks",this.txtRemarks.Text);
//			
//				srf.MakeUpdateStockRequest(htStockRequest);
//			
//				SaveAuditTrail("Reject Stock Request Status No "+this.StockRequestNo,"Stock Request",this.employee.Id);
//			
				MessageBox.Show("Record Has Been Updated", "Save");

				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void SaveAuditTrail(string strReference,string strAuditEntry,int employeeId)
		{
			//ACMS.Util.AuditTrail at = new ACMS.Util.AuditTrail();
			//at.SaveAuditTrail(strReference,strAuditEntry,employeeId);
		}

		
	}
}
