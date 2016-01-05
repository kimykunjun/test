using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using ACMS.Utils;

namespace ACMS.ACMSBranch.OpenCarton
{
	/// <summary>
	/// Summary description for OpenCarton.
	/// </summary>
	public class OpenCarton : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.TextEdit textItemCode;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraEditors.TextEdit txtOpeningBalance;
		private DevExpress.XtraEditors.TextEdit txtOpenCarton;

		private string strProductCode;
		private string strBranchCode;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OpenCarton()
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textItemCode = new DevExpress.XtraEditors.TextEdit();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			this.txtOpeningBalance = new DevExpress.XtraEditors.TextEdit();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.txtOpenCarton = new DevExpress.XtraEditors.TextEdit();
			((System.ComponentModel.ISupportInitialize)(this.textItemCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOpeningBalance.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOpenCarton.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Opening Balance";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(184, 32);
			this.label2.TabIndex = 1;
			this.label2.Text = "No of Open Carton (24 per Carton)";
			// 
			// textItemCode
			// 
			this.textItemCode.EditValue = "";
			this.textItemCode.Enabled = false;
			this.textItemCode.Location = new System.Drawing.Point(108, -34);
			this.textItemCode.Name = "textItemCode";
			// 
			// textItemCode.Properties
			// 
			this.textItemCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.textItemCode.Size = new System.Drawing.Size(75, 20);
			this.textItemCode.TabIndex = 14;
			// 
			// simpleButton2
			// 
			this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
			this.simpleButton2.Location = new System.Drawing.Point(64, 80);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.TabIndex = 17;
			this.simpleButton2.Text = "Add";
			this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
			// 
			// txtOpeningBalance
			// 
			this.txtOpeningBalance.EditValue = "";
			this.txtOpeningBalance.Enabled = false;
			this.txtOpeningBalance.Location = new System.Drawing.Point(200, 8);
			this.txtOpeningBalance.Name = "txtOpeningBalance";
			// 
			// txtOpeningBalance.Properties
			// 
			this.txtOpeningBalance.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.txtOpeningBalance.Size = new System.Drawing.Size(104, 20);
			this.txtOpeningBalance.TabIndex = 16;
			// 
			// simpleButton1
			// 
			this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
			this.simpleButton1.Location = new System.Drawing.Point(152, 80);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.TabIndex = 18;
			this.simpleButton1.Text = "Cancel";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// txtOpenCarton
			// 
			this.txtOpenCarton.EditValue = "";
			this.txtOpenCarton.Location = new System.Drawing.Point(200, 40);
			this.txtOpenCarton.Name = "txtOpenCarton";
			// 
			// txtOpenCarton.Properties
			// 
			this.txtOpenCarton.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.txtOpenCarton.Size = new System.Drawing.Size(64, 20);
			this.txtOpenCarton.TabIndex = 19;
			// 
			// OpenCarton
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(322, 120);
			this.Controls.Add(this.txtOpenCarton);
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.simpleButton2);
			this.Controls.Add(this.txtOpeningBalance);
			this.Controls.Add(this.textItemCode);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OpenCarton";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Open Carton";
			((System.ComponentModel.ISupportInitialize)(this.textItemCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOpeningBalance.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOpenCarton.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public bool BindData(string strProductCode,string strBranchCode)
		{
			this.strBranchCode=strBranchCode;
			this.strProductCode=strProductCode;
			ACMSLogic.OpenCarton.OpenCarton openCarton = new ACMSLogic.OpenCarton.OpenCarton();
			DataSet ds = openCarton.FindCurrentProductBalance(strProductCode,strBranchCode);
			if(ds!=null)
			{
				if(ds.Tables[0].Rows.Count==1)
				{
					DataTable dt = ds.Tables[0];
					this.txtOpeningBalance.Text = dt.Rows[0]["nQuantity"].ToString();
					return true;
				}
				else
				{
					UI.ShowWarningMessage(this,"No Record Found","No Record");
					return false;
				}
			}
			return false;
		}

		private void simpleButton2_Click(object sender, System.EventArgs e)
		{
			ACMSLogic.OpenCarton.OpenCarton openCarton = new ACMSLogic.OpenCarton.OpenCarton();
			try
			{
				int nquantity=Convert.ToInt32(this.txtOpenCarton.Text) * 24;
				DataSet ds = openCarton.AddProduct(strProductCode,strBranchCode,nquantity);
				if(ds!=null)
				{
					if(ds.Tables.Count==1)
					{
						DataTable dt = ds.Tables[0];
						string totalBalance = "Total Balance For Mineral Water = "+dt.Rows[0]["nQuantity"].ToString();
						UI.ShowMessage(this,totalBalance);
						this.DialogResult = DialogResult.OK;
						this.Close();
					}
				}
			}
			catch(Exception err)
			{
				UI.ShowErrorMessage(this,err.Message.ToString(),"Error");
			}
			
			
		}

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
