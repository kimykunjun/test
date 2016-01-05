using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
////using Rp = Acms.Core.Repository;
////using Fc = Acms.Core.Factory;
using Acms.Core.Domain;
//using Acms.Core.DataAccess;
using ACMSLogic;
using ACMS.Utils;

namespace ACMS.ACMSBranch.SalonUse
{
	/// <summary>
	/// Summary description for frmNewSalonUse.
	/// </summary>
	public class frmNewSalonUse : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private Acms.Core.Domain.Employee employee;
		private Acms.Core.Domain.TerminalUser terminalUser;
		private DevExpress.XtraEditors.TextEdit textItemCode;
		private DevExpress.XtraEditors.TextEdit textBranchCode;
		private DevExpress.XtraEditors.TextEdit textQuantity;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private string itemCode;
		

		public frmNewSalonUse()
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

		
		public void BindData()
		{
			this.textBranchCode.Enabled=false;
			this.textItemCode.Enabled=false;
			this.textBranchCode.Text=this.terminalUser.Branch.Id;
			this.textItemCode.Text=itemCode;
			this.textQuantity.Text="1";
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
			this.label3 = new System.Windows.Forms.Label();
			this.textItemCode = new DevExpress.XtraEditors.TextEdit();
			this.textBranchCode = new DevExpress.XtraEditors.TextEdit();
			this.textQuantity = new DevExpress.XtraEditors.TextEdit();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.textItemCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBranchCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textQuantity.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 6);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "Item Code";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 30);
			this.label2.Name = "label2";
			this.label2.TabIndex = 1;
			this.label2.Text = "Branch Code";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 54);
			this.label3.Name = "label3";
			this.label3.TabIndex = 2;
			this.label3.Text = "Quantity";
			// 
			// textItemCode
			// 
			this.textItemCode.EditValue = "";
			this.textItemCode.Location = new System.Drawing.Point(108, 6);
			this.textItemCode.Name = "textItemCode";
			// 
			// textItemCode.Properties
			// 
			this.textItemCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.textItemCode.Size = new System.Drawing.Size(156, 20);
			this.textItemCode.TabIndex = 3;
			// 
			// textBranchCode
			// 
			this.textBranchCode.EditValue = "";
			this.textBranchCode.Location = new System.Drawing.Point(108, 30);
			this.textBranchCode.Name = "textBranchCode";
			// 
			// textBranchCode.Properties
			// 
			this.textBranchCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.textBranchCode.Size = new System.Drawing.Size(156, 20);
			this.textBranchCode.TabIndex = 4;
			// 
			// textQuantity
			// 
			this.textQuantity.EditValue = "";
			this.textQuantity.Location = new System.Drawing.Point(108, 54);
			this.textQuantity.Name = "textQuantity";
			// 
			// textQuantity.Properties
			// 
			this.textQuantity.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.textQuantity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.textQuantity.Size = new System.Drawing.Size(75, 20);
			this.textQuantity.TabIndex = 5;
			// 
			// simpleButton1
			// 
			this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
			this.simpleButton1.Location = new System.Drawing.Point(108, 78);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.TabIndex = 6;
			this.simpleButton1.Text = "Save";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// simpleButton2
			// 
			this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
			this.simpleButton2.Location = new System.Drawing.Point(192, 78);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.TabIndex = 7;
			this.simpleButton2.Text = "Cancel";
			this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
			// 
			// frmNewSalonUse
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(276, 113);
			this.Controls.Add(this.simpleButton2);
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
			this.Name = "frmNewSalonUse";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add New Salon Use";
			((System.ComponentModel.ISupportInitialize)(this.textItemCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBranchCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textQuantity.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			if(this.textQuantity.Text=="0" | this.textQuantity.Text=="")
			{
				ACMS.Utils.UI.ShowErrorMessage(this,"Please enter valid quantity","Error");
			}
			else
			{
				ACMSLogic.StockInventory.SalonUse salonUse = new ACMSLogic.StockInventory.SalonUse();
				if(salonUse.SaveSalonUse(DateTime.Now,Convert.ToInt32(this.textQuantity.Text),this.terminalUser.Branch.Id,this.textItemCode.Text,this.employee.Id))
				{
					MessageBox.Show("Record has been saved","Save");
					this.DialogResult = DialogResult.OK;
				}
				else
				{
					UI.ShowErrorMessage(this,"Cannot insert record","Error");
					this.DialogResult = DialogResult.Cancel;
				}
				
				this.Close();
			}
			
		}

		private void simpleButton2_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		
	}
}
