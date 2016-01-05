using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ACMS
{
	/// <summary>
	/// Summary description for FormChangeClass.
	/// </summary>
	public class FormChangeClass : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		private DevExpress.XtraEditors.MemoEdit memoEdit1;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormChangeClass(int nClassInstanceID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			this.Text = string.Format("Please select a new class code for class ID : {0}", nClassInstanceID.ToString()); 
			Init();
		}


		private void Init()
		{
			ACMS.XtraUtils.LookupEditBuilder.ClassCodeLookupEditBuilder classCodeLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.ClassCodeLookupEditBuilder(lookUpEdit1.Properties);
			
		}

		public string ClassCode
		{
			get {return lookUpEdit1.EditValue.ToString();}
		}

		public string Remark
		{
			get { return memoEdit1.Text; }
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
			this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
			this.label1 = new System.Windows.Forms.Label();
			this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
			this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// panelControl1
			// 
			this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl1.Controls.Add(this.label2);
			this.panelControl1.Controls.Add(this.memoEdit1);
			this.panelControl1.Controls.Add(this.simpleButtonCancel);
			this.panelControl1.Controls.Add(this.simpleButtonOK);
			this.panelControl1.Controls.Add(this.label1);
			this.panelControl1.Controls.Add(this.lookUpEdit1);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelControl1.Location = new System.Drawing.Point(0, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(322, 226);
			this.panelControl1.TabIndex = 0;
			this.panelControl1.Text = "panelControl1";
			// 
			// simpleButtonCancel
			// 
			this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButtonCancel.Location = new System.Drawing.Point(228, 186);
			this.simpleButtonCancel.Name = "simpleButtonCancel";
			this.simpleButtonCancel.Size = new System.Drawing.Size(75, 26);
			this.simpleButtonCancel.TabIndex = 44;
			this.simpleButtonCancel.Text = "Cancel";
			// 
			// simpleButtonOK
			// 
			this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButtonOK.Location = new System.Drawing.Point(134, 186);
			this.simpleButtonOK.Name = "simpleButtonOK";
			this.simpleButtonOK.Size = new System.Drawing.Size(75, 26);
			this.simpleButtonOK.TabIndex = 43;
			this.simpleButtonOK.Text = "OK";
			this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(14, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Class Code";
			// 
			// lookUpEdit1
			// 
			this.lookUpEdit1.Location = new System.Drawing.Point(90, 16);
			this.lookUpEdit1.Name = "lookUpEdit1";
			// 
			// lookUpEdit1.Properties
			// 
			this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lookUpEdit1.Size = new System.Drawing.Size(220, 20);
			this.lookUpEdit1.TabIndex = 0;
			// 
			// memoEdit1
			// 
			this.memoEdit1.EditValue = "";
			this.memoEdit1.Location = new System.Drawing.Point(92, 48);
			this.memoEdit1.Name = "memoEdit1";
			// 
			// memoEdit1.Properties
			// 
			this.memoEdit1.Properties.MaxLength = 250;
			this.memoEdit1.Size = new System.Drawing.Size(216, 124);
			this.memoEdit1.TabIndex = 45;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(14, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 23);
			this.label2.TabIndex = 46;
			this.label2.Text = "Remark";
			// 
			// FormChangeClass
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(322, 226);
			this.Controls.Add(this.panelControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormChangeClass";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Please select a new class code";
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
			if (lookUpEdit1.EditValue == null) 
			{
				this.DialogResult = DialogResult.Cancel;
			}

			if (lookUpEdit1.EditValue.ToString().Length == 0)
			{
				MessageBox.Show("Please select a new class code");
				this.DialogResult = DialogResult.None;
				return;	
			}

			if (memoEdit1.Text.Length == 0)
			{	
				MessageBox.Show("Please write down the remark why you want to change this class to others class code.");
				this.DialogResult = DialogResult.None;
				return;
			}
		}
	}
}
