using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ACMS.ACMSBranch.StockInventory
{
	/// <summary>
	/// Summary description for frmBinNo.
	/// </summary>
	public class frmBinNo : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private DevExpress.XtraEditors.TextEdit txtBranchCode;
		private DevExpress.XtraEditors.TextEdit txtBinNo;
		private DevExpress.XtraEditors.TextEdit txtProductCode;
		private System.Windows.Forms.Label label3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmBinNo(string strBranchCode,string strProductCode,string binNo)
		{
			//
			// Required for Windows Form Designer support
			//
			
			InitializeComponent();
			txtBranchCode.Text=strBranchCode;
			txtBinNo.Text=binNo;
			txtProductCode.Text = strProductCode;

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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtBranchCode = new DevExpress.XtraEditors.TextEdit();
			this.txtBinNo = new DevExpress.XtraEditors.TextEdit();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			this.txtProductCode = new DevExpress.XtraEditors.TextEdit();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.txtBranchCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtBinNo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtProductCode.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "Branch Code";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 72);
			this.label2.Name = "label2";
			this.label2.TabIndex = 1;
			this.label2.Text = "Bin No";
			// 
			// txtBranchCode
			// 
			this.txtBranchCode.EditValue = "";
			this.txtBranchCode.Enabled = false;
			this.txtBranchCode.Location = new System.Drawing.Point(112, 8);
			this.txtBranchCode.Name = "txtBranchCode";
			this.txtBranchCode.Size = new System.Drawing.Size(128, 20);
			this.txtBranchCode.TabIndex = 59;
			// 
			// txtBinNo
			// 
			this.txtBinNo.EditValue = "";
			this.txtBinNo.Location = new System.Drawing.Point(112, 72);
			this.txtBinNo.Name = "txtBinNo";
			this.txtBinNo.Size = new System.Drawing.Size(40, 20);
			this.txtBinNo.TabIndex = 60;
			// 
			// simpleButton1
			// 
			this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.simpleButton1.Location = new System.Drawing.Point(112, 104);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.TabIndex = 61;
			this.simpleButton1.Text = "Save";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// simpleButton2
			// 
			this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.simpleButton2.Location = new System.Drawing.Point(192, 104);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.TabIndex = 62;
			this.simpleButton2.Text = "Cancel";
			this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
			// 
			// txtProductCode
			// 
			this.txtProductCode.EditValue = "";
			this.txtProductCode.Enabled = false;
			this.txtProductCode.Location = new System.Drawing.Point(112, 40);
			this.txtProductCode.Name = "txtProductCode";
			this.txtProductCode.Size = new System.Drawing.Size(128, 20);
			this.txtProductCode.TabIndex = 64;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 40);
			this.label3.Name = "label3";
			this.label3.TabIndex = 63;
			this.label3.Text = "Product Code";
			// 
			// frmBinNo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(282, 135);
			this.Controls.Add(this.txtProductCode);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.simpleButton2);
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.txtBinNo);
			this.Controls.Add(this.txtBranchCode);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmBinNo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Edit Bin No";
			((System.ComponentModel.ISupportInitialize)(this.txtBranchCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtBinNo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtProductCode.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			ACMSLogic.StockInventory.BinNo binNo = new ACMSLogic.StockInventory.BinNo();
			if(binNo.UpdateBinNo(this.txtBranchCode.Text,this.txtProductCode.Text,this.txtBinNo.Text))
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void simpleButton2_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
