using System;
using System.Drawing;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Acms.Core.Domain;
using ACMSLogic;
using ACMS.Utils;
using DevExpress.XtraEditors.Controls;

namespace ACMS.ACMSBranch.PromotionAdjustment
{
	/// <summary>
	/// Summary description for SearchPromotion.
	/// </summary>
	public class SearchPromotion : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SearchPromotion()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public void BindData(string strBranchCode)
		{
			DataSet ds = null;
			ACMSLogic.Promotion.Promotion promotion  = new ACMSLogic.Promotion.Promotion();
			ds = promotion.FindPromotionByBranch(strBranchCode);
			if(ds!=null)
			{
				if(ds.Tables.Count>0)
				{
					this.lookUpEdit1.Properties.DataSource = ds.Tables[0];
					this.lookUpEdit1.Properties.ValueMember = "strPromotionCode";
					this.lookUpEdit1.Properties.DisplayMember = "strPromotionCode";
					this.lookUpEdit1.Properties.BestFit();
					this.lookUpEdit1.Properties.PopupWidth = 350;
					
				}
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
			this.label1 = new System.Windows.Forms.Label();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "Promotion Code";
			// 
			// simpleButton2
			// 
			this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButton2.Location = new System.Drawing.Point(192, 40);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.TabIndex = 10;
			this.simpleButton2.Text = "Cancel";
			// 
			// lookUpEdit1
			// 
			this.lookUpEdit1.Location = new System.Drawing.Point(112, 8);
			this.lookUpEdit1.Name = "lookUpEdit1";
			// 
			// lookUpEdit1.Properties
			// 
			this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lookUpEdit1.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.lookUpEdit1.Properties.NullText = "";
			this.lookUpEdit1.Size = new System.Drawing.Size(152, 22);
			this.lookUpEdit1.TabIndex = 9;
			// 
			// simpleButton1
			// 
			this.simpleButton1.Location = new System.Drawing.Point(112, 40);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.TabIndex = 8;
			this.simpleButton1.Text = "Search";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// SearchPromotion
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(282, 71);
			this.Controls.Add(this.simpleButton2);
			this.Controls.Add(this.lookUpEdit1);
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SearchPromotion";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SearchPromotion";
			((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			if(this.lookUpEdit1.Text=="")
			{
				UI.ShowErrorMessage(this,"Please select Promotion Code","Error");
				return;
			}
			this.DialogResult = DialogResult.OK;
			
		}

		public string GetSelectedItem()
		{
			//UI.ShowMessage(this,this.lookUpEdit1.Text);
			return this.lookUpEdit1.Text;
		}
	}
}
