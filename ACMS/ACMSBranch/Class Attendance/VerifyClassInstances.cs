using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ACMS
{
	/// <summary>
	/// Summary description for VerifyClassInstances.
	/// </summary>
	public class VerifyClassInstances : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.TextEdit textEditPW;
		private DevExpress.XtraEditors.TextEdit textEditUserID;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
		private DevExpress.XtraEditors.MemoEdit memoEdit1;
		private DevExpress.XtraEditors.CheckEdit checkEdit1;

		private ACMS.XtraUtils.LookupEditBuilder.EmployeeIDLookupEditBuilder myEmployeeIDLookupEditBuilder;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public VerifyClassInstances()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myEmployeeIDLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.EmployeeIDLookupEditBuilder(lookUpEdit1.Properties, true);
		}

		public int VerifierID
		{
			get { return ACMS.Convert.ToInt32(textEditUserID.Text); } 
		}

		public string Password
		{
			get 
			{
				if (textEditPW.EditValue != null)
					return textEditPW.EditValue.ToString();
				else 
					return "";
			}
		}

		public string Remark
		{
			get 
			{
				return memoEdit1.Text;
			}
		}
		
		public int StandingInstructorID
		{
			get
			{
				if (checkEdit1.Checked)
					return ACMS.Convert.ToInt32(lookUpEdit1.Text);
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
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
			this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
			this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textEditPW = new DevExpress.XtraEditors.TextEdit();
			this.textEditUserID = new DevExpress.XtraEditors.TextEdit();
			this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEditPW.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEditUserID.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// panelControl1
			// 
			this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl1.Controls.Add(this.checkEdit1);
			this.panelControl1.Controls.Add(this.memoEdit1);
			this.panelControl1.Controls.Add(this.lookUpEdit1);
			this.panelControl1.Controls.Add(this.label4);
			this.panelControl1.Controls.Add(this.label2);
			this.panelControl1.Controls.Add(this.label1);
			this.panelControl1.Controls.Add(this.textEditPW);
			this.panelControl1.Controls.Add(this.textEditUserID);
			this.panelControl1.Controls.Add(this.simpleButtonCancel);
			this.panelControl1.Controls.Add(this.simpleButtonOK);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelControl1.Location = new System.Drawing.Point(0, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(328, 268);
			this.panelControl1.TabIndex = 0;
			this.panelControl1.Text = "panelControl1";
			// 
			// checkEdit1
			// 
			this.checkEdit1.Location = new System.Drawing.Point(16, 82);
			this.checkEdit1.Name = "checkEdit1";
			// 
			// checkEdit1.Properties
			// 
			this.checkEdit1.Properties.Caption = "Standing Instructor";
			this.checkEdit1.Size = new System.Drawing.Size(118, 19);
			this.checkEdit1.TabIndex = 49;
			this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
			// 
			// memoEdit1
			// 
			this.memoEdit1.EditValue = "";
			this.memoEdit1.Location = new System.Drawing.Point(142, 110);
			this.memoEdit1.Name = "memoEdit1";
			this.memoEdit1.Size = new System.Drawing.Size(156, 110);
			this.memoEdit1.TabIndex = 3;
			// 
			// lookUpEdit1
			// 
			this.lookUpEdit1.Location = new System.Drawing.Point(142, 80);
			this.lookUpEdit1.Name = "lookUpEdit1";
			// 
			// lookUpEdit1.Properties
			// 
			this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lookUpEdit1.Size = new System.Drawing.Size(156, 20);
			this.lookUpEdit1.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 23);
			this.label4.TabIndex = 46;
			this.label4.Text = "Remark";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 23);
			this.label2.TabIndex = 42;
			this.label2.Text = "Password";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 41;
			this.label1.Text = "Verifier ID";
			// 
			// textEditPW
			// 
			this.textEditPW.EditValue = "";
			this.textEditPW.Location = new System.Drawing.Point(142, 50);
			this.textEditPW.Name = "textEditPW";
			// 
			// textEditPW.Properties
			// 
			this.textEditPW.Properties.PasswordChar = '*';
			this.textEditPW.Size = new System.Drawing.Size(156, 20);
			this.textEditPW.TabIndex = 1;
			// 
			// textEditUserID
			// 
			this.textEditUserID.EditValue = "";
			this.textEditUserID.Location = new System.Drawing.Point(142, 18);
			this.textEditUserID.Name = "textEditUserID";
			this.textEditUserID.Size = new System.Drawing.Size(156, 20);
			this.textEditUserID.TabIndex = 0;
			// 
			// simpleButtonCancel
			// 
			this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButtonCancel.Location = new System.Drawing.Point(174, 232);
			this.simpleButtonCancel.Name = "simpleButtonCancel";
			this.simpleButtonCancel.TabIndex = 38;
			this.simpleButtonCancel.Text = "Cancel";
			// 
			// simpleButtonOK
			// 
			this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButtonOK.Location = new System.Drawing.Point(70, 232);
			this.simpleButtonOK.Name = "simpleButtonOK";
			this.simpleButtonOK.TabIndex = 37;
			this.simpleButtonOK.Text = "OK";
			this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
			// 
			// VerifyClassInstances
			// 
			this.AcceptButton = this.simpleButtonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.simpleButtonCancel;
			this.ClientSize = new System.Drawing.Size(328, 268);
			this.Controls.Add(this.panelControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "VerifyClassInstances";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "VerifyClassInstances";
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEditPW.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEditUserID.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void checkEdit1_CheckedChanged(object sender, System.EventArgs e)
		{
			if (checkEdit1.Checked)
				lookUpEdit1.Enabled = true;
			else
				lookUpEdit1.Enabled = false;
		}
	}
}
