using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ACMS.ACMSPOS2
{
	/// <summary>
	/// Summary description for FormLockerAction.
	/// </summary>
	public class FormLockerAction : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.SimpleButton sBtnReturnLocker;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private DevExpress.XtraEditors.SimpleButton sBtnExtendLocker;
		private DevExpress.XtraEditors.SimpleButton sBtnNewLocker;
		private ACMSLogic.POS myPOS;

		public FormLockerAction(ACMSLogic.POS pos)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myPOS = pos;

			if (myPOS.POSLockerAction == ACMSLogic.POS.LockerAction.New)
			{
				sBtnExtendLocker.Enabled = false;
				sBtnReturnLocker.Enabled = false;
			}
			else if (myPOS.POSLockerAction == ACMSLogic.POS.LockerAction.Extend)
			{
				sBtnNewLocker.Enabled = false;
				sBtnReturnLocker.Enabled = false;
			}
			else if (myPOS.POSLockerAction == ACMSLogic.POS.LockerAction.Return)
			{
				sBtnExtendLocker.Enabled = false;
				sBtnNewLocker.Enabled = false;
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
			this.sBtnNewLocker = new DevExpress.XtraEditors.SimpleButton();
			this.sBtnReturnLocker = new DevExpress.XtraEditors.SimpleButton();
			this.sBtnExtendLocker = new DevExpress.XtraEditors.SimpleButton();
			this.SuspendLayout();
			// 
			// sBtnNewLocker
			// 
			this.sBtnNewLocker.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
			this.sBtnNewLocker.Appearance.Options.UseFont = true;
			this.sBtnNewLocker.Location = new System.Drawing.Point(12, 24);
			this.sBtnNewLocker.Name = "sBtnNewLocker";
			this.sBtnNewLocker.Size = new System.Drawing.Size(144, 48);
			this.sBtnNewLocker.TabIndex = 0;
			this.sBtnNewLocker.Text = "New Locker(s)";
			this.sBtnNewLocker.Click += new System.EventHandler(this.sBtnNew_ExtendLocker_Click);
			// 
			// sBtnReturnLocker
			// 
			this.sBtnReturnLocker.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
			this.sBtnReturnLocker.Appearance.Options.UseFont = true;
			this.sBtnReturnLocker.Location = new System.Drawing.Point(330, 24);
			this.sBtnReturnLocker.Name = "sBtnReturnLocker";
			this.sBtnReturnLocker.Size = new System.Drawing.Size(160, 48);
			this.sBtnReturnLocker.TabIndex = 1;
			this.sBtnReturnLocker.Text = "Return Locker(s)";
			this.sBtnReturnLocker.Click += new System.EventHandler(this.sBtnReturnLocker_Click);
			// 
			// sBtnExtendLocker
			// 
			this.sBtnExtendLocker.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
			this.sBtnExtendLocker.Appearance.Options.UseFont = true;
			this.sBtnExtendLocker.Location = new System.Drawing.Point(164, 24);
			this.sBtnExtendLocker.Name = "sBtnExtendLocker";
			this.sBtnExtendLocker.Size = new System.Drawing.Size(160, 48);
			this.sBtnExtendLocker.TabIndex = 2;
			this.sBtnExtendLocker.Text = "Extend Locker(s)";
			this.sBtnExtendLocker.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// FormLockerAction
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(500, 94);
			this.Controls.Add(this.sBtnExtendLocker);
			this.Controls.Add(this.sBtnReturnLocker);
			this.Controls.Add(this.sBtnNewLocker);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormLockerAction";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Locker Action";
			this.ResumeLayout(false);

		}
		#endregion

		private void sBtnNew_ExtendLocker_Click(object sender, System.EventArgs e)
		{
//			if (myPOS.ReceiptItemsTable.Rows.Count > 0)
//			{
//				MessageBox.Show(this, "Only one action is allow per receipt.");
//				return;
//			}
			
			myPOS.POSLockerAction = ACMSLogic.POS.LockerAction.New;
			ACMS.ACMSPOS2.FormNewLocker frm = new FormNewLocker(myPOS);
			this.Close();
			frm.ShowDialog();
		}

		private void sBtnReturnLocker_Click(object sender, System.EventArgs e)
		{
			myPOS.POSLockerAction = ACMSLogic.POS.LockerAction.Return;
			ACMS.ACMSPOS2.FormReturnLocker frm = new FormReturnLocker(myPOS);
			this.Close();
			frm.ShowDialog();	
		}

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			myPOS.POSLockerAction = ACMSLogic.POS.LockerAction.Extend;
			ACMS.ACMSPOS2.FormExtendLocker frm = new FormExtendLocker(myPOS);
			this.Close();
			frm.ShowDialog();
		}
	}
}
