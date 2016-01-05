using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ACMS
{
	/// <summary>
	/// Summary description for FormUpdateMemberCreditPackage.
	/// </summary>
	public class FormUpdateMemberCreditPackage : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.DateEdit dateEdit2;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormUpdateMemberCreditPackage(int nCreditPackageID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			label2.Text= string.Format("You can only update member credit Package's Expriry Date for this ID : {0}", nCreditPackageID.ToString());
			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			dateEdit2.DateTime = DateTime.Now.Date;
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

		public DateTime NewExpiryDate
		{
			get 
			{
				return dateEdit2.DateTime;
			}
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// dateEdit2
			// 
			this.dateEdit2.EditValue = new System.DateTime(2005, 12, 29, 0, 0, 0, 0);
			this.dateEdit2.Location = new System.Drawing.Point(134, 32);
			this.dateEdit2.Name = "dateEdit2";
			// 
			// dateEdit2.Properties
			// 
			this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit2.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.dateEdit2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dateEdit2.Properties.EditFormat.FormatString = "dd/MM/yyyy";
			this.dateEdit2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dateEdit2.Properties.Mask.EditMask = "dd/MM/yyyy";
			this.dateEdit2.Size = new System.Drawing.Size(196, 20);
			this.dateEdit2.TabIndex = 12;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(124, 28);
			this.label1.TabIndex = 13;
			this.label1.Text = "New Member\'s Credit Package Expiry Date";
			// 
			// simpleButtonCancel
			// 
			this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButtonCancel.Location = new System.Drawing.Point(232, 62);
			this.simpleButtonCancel.Name = "simpleButtonCancel";
			this.simpleButtonCancel.TabIndex = 51;
			this.simpleButtonCancel.Text = "Cancel";
			// 
			// simpleButtonOK
			// 
			this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButtonOK.Location = new System.Drawing.Point(128, 62);
			this.simpleButtonOK.Name = "simpleButtonOK";
			this.simpleButtonOK.TabIndex = 50;
			this.simpleButtonOK.Text = "OK";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(370, 23);
			this.label2.TabIndex = 52;
			this.label2.Text = "label2";
			// 
			// FormUpdateMemberCreditPackage
			// 
			this.AcceptButton = this.simpleButtonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.simpleButtonCancel;
			this.ClientSize = new System.Drawing.Size(390, 94);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.simpleButtonCancel);
			this.Controls.Add(this.simpleButtonOK);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dateEdit2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormUpdateMemberCreditPackage";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FormUpdateMemberCreditPackage";
			((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	}
}
