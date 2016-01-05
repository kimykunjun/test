using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ACMS
{
	/// <summary>
	/// Summary description for FormNew_EditLocker.
	/// </summary>
	public class FormChangesReceiptSalesPerson : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.PanelControl pnlCtrlTop;
		private DevExpress.XtraEditors.PanelControl pnlCtrlCenter;
		private DevExpress.XtraEditors.PanelControl pnlCtrlBottom;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtSalesPersonID;
		internal System.Windows.Forms.Label Label4;
		private ACMS.XtraUtils.LookupEditBuilder.TherapistForPOSSalesLookupEditBuilder myEmployeeIDLookupBuilder;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormChangesReceiptSalesPerson()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myEmployeeIDLookupBuilder = new ACMS.XtraUtils.LookupEditBuilder.TherapistForPOSSalesLookupEditBuilder(lkpEdtSalesPersonID.Properties, "");
		}

		public int SalesPersonID
		{
			get 
			{ 
				if (lkpEdtSalesPersonID.EditValue != null)
					return ACMS.Convert.ToInt32(lkpEdtSalesPersonID.EditValue); 
				else
					return -1;
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
			this.pnlCtrlTop = new DevExpress.XtraEditors.PanelControl();
			this.pnlCtrlCenter = new DevExpress.XtraEditors.PanelControl();
			this.lkpEdtSalesPersonID = new DevExpress.XtraEditors.LookUpEdit();
			this.Label4 = new System.Windows.Forms.Label();
			this.pnlCtrlBottom = new DevExpress.XtraEditors.PanelControl();
			this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlTop)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlCenter)).BeginInit();
			this.pnlCtrlCenter.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtSalesPersonID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlBottom)).BeginInit();
			this.pnlCtrlBottom.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlCtrlTop
			// 
			this.pnlCtrlTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnlCtrlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlCtrlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlCtrlTop.Name = "pnlCtrlTop";
			this.pnlCtrlTop.Size = new System.Drawing.Size(550, 20);
			this.pnlCtrlTop.TabIndex = 0;
			this.pnlCtrlTop.Text = "panelControl1";
			// 
			// pnlCtrlCenter
			// 
			this.pnlCtrlCenter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnlCtrlCenter.Controls.Add(this.lkpEdtSalesPersonID);
			this.pnlCtrlCenter.Controls.Add(this.Label4);
			this.pnlCtrlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlCtrlCenter.Location = new System.Drawing.Point(0, 20);
			this.pnlCtrlCenter.Name = "pnlCtrlCenter";
			this.pnlCtrlCenter.Size = new System.Drawing.Size(550, 64);
			this.pnlCtrlCenter.TabIndex = 1;
			this.pnlCtrlCenter.Text = "panelControl2";
			// 
			// lkpEdtSalesPersonID
			// 
			this.lkpEdtSalesPersonID.EditValue = "";
			this.lkpEdtSalesPersonID.Location = new System.Drawing.Point(218, 20);
			this.lkpEdtSalesPersonID.Name = "lkpEdtSalesPersonID";
			// 
			// lkpEdtSalesPersonID.Properties
			// 
			this.lkpEdtSalesPersonID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
			this.lkpEdtSalesPersonID.Properties.Appearance.Options.UseFont = true;
			this.lkpEdtSalesPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtSalesPersonID.Size = new System.Drawing.Size(296, 23);
			this.lkpEdtSalesPersonID.TabIndex = 44;
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label4.Location = new System.Drawing.Point(6, 20);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(199, 25);
			this.Label4.TabIndex = 43;
			this.Label4.Text = "New Sales Person ID";
			// 
			// pnlCtrlBottom
			// 
			this.pnlCtrlBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnlCtrlBottom.Controls.Add(this.simpleButtonCancel);
			this.pnlCtrlBottom.Controls.Add(this.simpleButtonOK);
			this.pnlCtrlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlCtrlBottom.Location = new System.Drawing.Point(0, 84);
			this.pnlCtrlBottom.Name = "pnlCtrlBottom";
			this.pnlCtrlBottom.Size = new System.Drawing.Size(550, 42);
			this.pnlCtrlBottom.TabIndex = 2;
			this.pnlCtrlBottom.Text = "panelControl3";
			// 
			// simpleButtonCancel
			// 
			this.simpleButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButtonCancel.Location = new System.Drawing.Point(444, 10);
			this.simpleButtonCancel.Name = "simpleButtonCancel";
			this.simpleButtonCancel.TabIndex = 12;
			this.simpleButtonCancel.Text = "Cancel";
			// 
			// simpleButtonOK
			// 
			this.simpleButtonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButtonOK.Location = new System.Drawing.Point(358, 10);
			this.simpleButtonOK.Name = "simpleButtonOK";
			this.simpleButtonOK.TabIndex = 11;
			this.simpleButtonOK.Text = "OK";
			this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
			// 
			// FormChangesReceiptSalesPerson
			// 
			this.AcceptButton = this.simpleButtonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.simpleButtonCancel;
			this.ClientSize = new System.Drawing.Size(550, 126);
			this.Controls.Add(this.pnlCtrlCenter);
			this.Controls.Add(this.pnlCtrlTop);
			this.Controls.Add(this.pnlCtrlBottom);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormChangesReceiptSalesPerson";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Changes Sales Person ID";
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlTop)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlCenter)).EndInit();
			this.pnlCtrlCenter.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtSalesPersonID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlBottom)).EndInit();
			this.pnlCtrlBottom.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
			if (lkpEdtSalesPersonID.Text.Length == 0)
			{
				MessageBox.Show(this, "Please Select a New Sales Person.");
				this.DialogResult = DialogResult.None;

			}
		}
	}
}
