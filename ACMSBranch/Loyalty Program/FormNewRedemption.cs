using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ACMS
{
	/// <summary>
	/// Summary description for FormNewRedemption.
	/// </summary>
	public class FormNewRedemption : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
		private System.Windows.Forms.Label label1;
		private decimal myDMemberTotalPoint = 0;
		private int myDTransactionID;
		private ACMS.XtraUtils.LookupEditBuilder.RewardsCatalogueLookupEditBuilder myRewardCatalogueLookupeditBuilder;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormNewRedemption(string strMembershipID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			ACMSDAL.TblRewardsTransaction sqlRewardTrans = new ACMSDAL.TblRewardsTransaction();
			myDMemberTotalPoint = sqlRewardTrans.GetMemberLoyaltyPoint(strMembershipID);
			myDTransactionID = sqlRewardTrans.GetMemberRedemptionID (strMembershipID);

			myRewardCatalogueLookupeditBuilder = new ACMS.XtraUtils.LookupEditBuilder.RewardsCatalogueLookupEditBuilder(lookUpEdit1.Properties, myDMemberTotalPoint);
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

		public string ItemCode
		{
			get 
			{
				return lookUpEdit1.Text;
			}
		}

		public decimal ItemPoint
		{
			get 
			{
				if (lookUpEdit1.Text.Trim() != "")
					return ACMS.Convert.ToDecimal(lookUpEdit1.GetColumnValue("dRewardsPoints"));
				else
					return 0;
			}
		}

		public decimal MemberTotalPoint
		{
			get { return myDMemberTotalPoint; }
		}

		public int MemberTransactionID
		{
			get { return myDTransactionID; }
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
			this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// simpleButtonCancel
			// 
			this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButtonCancel.Location = new System.Drawing.Point(184, 56);
			this.simpleButtonCancel.Name = "simpleButtonCancel";
			this.simpleButtonCancel.TabIndex = 48;
			this.simpleButtonCancel.Text = "Cancel";
			// 
			// simpleButtonOK
			// 
			this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButtonOK.Location = new System.Drawing.Point(80, 56);
			this.simpleButtonOK.Name = "simpleButtonOK";
			this.simpleButtonOK.TabIndex = 47;
			this.simpleButtonOK.Text = "OK";
			this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
			// 
			// lookUpEdit1
			// 
			this.lookUpEdit1.EditValue = "";
			this.lookUpEdit1.Location = new System.Drawing.Point(80, 8);
			this.lookUpEdit1.Name = "lookUpEdit1";
			// 
			// lookUpEdit1.Properties
			// 
			this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lookUpEdit1.Size = new System.Drawing.Size(208, 20);
			this.lookUpEdit1.TabIndex = 49;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 50;
			this.label1.Text = "Item Code";
			// 
			// FormNewRedemption
			// 
			this.AcceptButton = this.simpleButtonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.simpleButtonCancel;
			this.ClientSize = new System.Drawing.Size(328, 94);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lookUpEdit1);
			this.Controls.Add(this.simpleButtonCancel);
			this.Controls.Add(this.simpleButtonOK);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormNewRedemption";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Redemption";
			((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
			if (lookUpEdit1.Text.Length == 0)
			{
				MessageBox.Show(this, "Please select an Item.");
				this.DialogResult = DialogResult.None;
				lookUpEdit1.Focus();
				return;
			}
		}
	}
}
