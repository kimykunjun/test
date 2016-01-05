using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Acms.Core.Domain;
using ACMSLogic;


namespace ACMS.ACMSBranch.SalonUse
{
	/// <summary>
	/// Summary description for frmDeleteSalonUse.
	/// </summary>
	public class frmDeleteSalonUse : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraEditors.TextEdit textQuantity;
		private DevExpress.XtraEditors.TextEdit textBranchCode;
		private DevExpress.XtraEditors.TextEdit textItemCode;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.MemoEdit txtRemarks;
		private System.Windows.Forms.Label label4;

		private Acms.Core.Domain.Employee employee;
		private Acms.Core.Domain.TerminalUser terminalUser;
		private string itemCode;
		private string quantity;
		private string referenceNo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDeleteSalonUse()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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

		public Employee Employee
		{
			set{employee=value;}
		}

		public TerminalUser TerminalUser
		{
			set{terminalUser=value;}
		}

		public string ItemCode
		{
			set{itemCode=value;}
		}

		public string Quantity
		{
			set{quantity=value;}
			get{return quantity.Replace("-","");}
		}

		public string ReferenceNo
		{
			set{referenceNo=value;}
			get{return referenceNo;}
		}

		public void BindData()
		{
			this.textBranchCode.Enabled=false;
			this.textItemCode.Enabled=false;
			this.textBranchCode.Text=this.terminalUser.Branch.Id;
			this.textItemCode.Text=itemCode;
			this.textQuantity.Text=Quantity;
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.textQuantity = new DevExpress.XtraEditors.TextEdit();
			this.textBranchCode = new DevExpress.XtraEditors.TextEdit();
			this.textItemCode = new DevExpress.XtraEditors.TextEdit();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtRemarks = new DevExpress.XtraEditors.MemoEdit();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.textQuantity.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBranchCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textItemCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// simpleButton1
			// 
			this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
			this.simpleButton1.Location = new System.Drawing.Point(112, 160);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.TabIndex = 13;
			this.simpleButton1.Text = "Delete";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// textQuantity
			// 
			this.textQuantity.EditValue = "";
			this.textQuantity.Enabled = false;
			this.textQuantity.Location = new System.Drawing.Point(112, 60);
			this.textQuantity.Name = "textQuantity";
			// 
			// textQuantity.Properties
			// 
			this.textQuantity.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.textQuantity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.textQuantity.Size = new System.Drawing.Size(75, 20);
			this.textQuantity.TabIndex = 12;
			// 
			// textBranchCode
			// 
			this.textBranchCode.EditValue = "";
			this.textBranchCode.Enabled = false;
			this.textBranchCode.Location = new System.Drawing.Point(112, 36);
			this.textBranchCode.Name = "textBranchCode";
			// 
			// textBranchCode.Properties
			// 
			this.textBranchCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.textBranchCode.Size = new System.Drawing.Size(75, 20);
			this.textBranchCode.TabIndex = 11;
			// 
			// textItemCode
			// 
			this.textItemCode.EditValue = "";
			this.textItemCode.Enabled = false;
			this.textItemCode.Location = new System.Drawing.Point(112, 12);
			this.textItemCode.Name = "textItemCode";
			// 
			// textItemCode.Properties
			// 
			this.textItemCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.textItemCode.Size = new System.Drawing.Size(75, 20);
			this.textItemCode.TabIndex = 10;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 60);
			this.label3.Name = "label3";
			this.label3.TabIndex = 9;
			this.label3.Text = "Quantity";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 36);
			this.label2.Name = "label2";
			this.label2.TabIndex = 8;
			this.label2.Text = "Branch Code";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 12);
			this.label1.Name = "label1";
			this.label1.TabIndex = 7;
			this.label1.Text = "Item Code";
			// 
			// txtRemarks
			// 
			this.txtRemarks.EditValue = "";
			this.txtRemarks.Location = new System.Drawing.Point(112, 88);
			this.txtRemarks.Name = "txtRemarks";
			// 
			// txtRemarks.Properties
			// 
			this.txtRemarks.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.txtRemarks.Size = new System.Drawing.Size(224, 64);
			this.txtRemarks.TabIndex = 69;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 23);
			this.label4.TabIndex = 70;
			this.label4.Text = "Reason";
			// 
			// frmDeleteSalonUse
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(346, 191);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtRemarks);
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.textQuantity);
			this.Controls.Add(this.textBranchCode);
			this.Controls.Add(this.textItemCode);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmDeleteSalonUse";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Delete Salon Use";
			((System.ComponentModel.ISupportInitialize)(this.textQuantity.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBranchCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textItemCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			ACMSLogic.StockInventory.SalonUse salonUse = new ACMSLogic.StockInventory.SalonUse();
			salonUse.DeleteSalonUse(this.ReferenceNo,this.terminalUser.Branch.Id,itemCode,Convert.ToInt32(Quantity),this.employee.Id,"Delete Salon Use",this.txtRemarks.Text,7);
			MessageBox.Show("Record has been deleted","Delete");
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
