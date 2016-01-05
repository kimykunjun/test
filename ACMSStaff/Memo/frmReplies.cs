using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ACMSDAL;
using ACMSLogic;
using ACMSLogic.Staff;
using ACMS.Utils;

namespace ACMS.ACMSStaff.Memo
{
	/// <summary>
	/// Summary description for frmReplies.
	/// </summary>
	public class frmReplies : System.Windows.Forms.Form
	{
		private int nBulletinID, nMemoID, nEmployeeID;
		private ACMSLogic.Staff.Memo myMemo;
		private ACMSLogic.Staff.MemoReplyAction myAction;
		private DataTable myTable;
		private DevExpress.XtraEditors.MemoEdit memoEdit1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.SimpleButton sbtnSave;
		private DevExpress.XtraEditors.SimpleButton sbtnCancel;
		private DevExpress.XtraEditors.DateEdit dateEdit1;
		private DevExpress.XtraEditors.LookUpEdit luedtEmployeeID;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmReplies(int nBulletinID, int nMemoID, int nEmployeeID, ACMSLogic.Staff.MemoReplyAction aAction)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			ACMS.XtraUtils.XtraEditors.SetDateEditFormat(this.Controls);
			this.nBulletinID = nBulletinID;
			this.nMemoID = nMemoID;
			this.nEmployeeID = nEmployeeID;
			myAction = aAction;
			this.Text = string.Format(this.Text, myAction.ToString());
			myMemo = new ACMSLogic.Staff.Memo();

			new ACMS.XtraUtils.LookupEditBuilder.EmployeeIDLookupEditBuilder(luedtEmployeeID.Properties);

			if (myAction != ACMSLogic.Staff.MemoReplyAction.Add)
			{
				myTable = myMemo.GetReply(nBulletinID);
				BindData();
			}
			else
			{
				dateEdit1.DateTime = DateTime.Now.Date;
				luedtEmployeeID.EditValue = nEmployeeID;
			}
			if (myAction == ACMSLogic.Staff.MemoReplyAction.View)
			{
				sbtnSave.Visible = false;
				memoEdit1.Properties.ReadOnly = true;
				sbtnCancel.Text = "Close";
			}
		}

		private void BindData()
		{
			dateEdit1.DataBindings.Clear();
			luedtEmployeeID.DataBindings.Clear();
			memoEdit1.DataBindings.Clear();

			dateEdit1.DataBindings.Add("EditValue", myTable, "dtDate");
			luedtEmployeeID.DataBindings.Add("EditValue", myTable, "nEmployeeID");
			memoEdit1.DataBindings.Add("EditValue", myTable, "strMessage");
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
			this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.sbtnSave = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
			this.luedtEmployeeID = new DevExpress.XtraEditors.LookUpEdit();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtEmployeeID.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// memoEdit1
			// 
			this.memoEdit1.EditValue = "";
			this.memoEdit1.Location = new System.Drawing.Point(98, 70);
			this.memoEdit1.Name = "memoEdit1";
			// 
			// memoEdit1.Properties
			// 
			this.memoEdit1.Properties.MaxLength = 1000;
			this.memoEdit1.Size = new System.Drawing.Size(460, 152);
			this.memoEdit1.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(22, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 18);
			this.label2.TabIndex = 6;
			this.label2.Text = "Message:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(22, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 18);
			this.label1.TabIndex = 4;
			this.label1.Text = "Date:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(22, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(74, 18);
			this.label3.TabIndex = 8;
			this.label3.Text = "Employee:";
			// 
			// sbtnSave
			// 
			this.sbtnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.sbtnSave.Location = new System.Drawing.Point(408, 234);
			this.sbtnSave.Name = "sbtnSave";
			this.sbtnSave.TabIndex = 3;
			this.sbtnSave.Text = "Save";
			this.sbtnSave.Click += new System.EventHandler(this.sbtnSave_Click);
			// 
			// sbtnCancel
			// 
			this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sbtnCancel.Location = new System.Drawing.Point(490, 234);
			this.sbtnCancel.Name = "sbtnCancel";
			this.sbtnCancel.TabIndex = 4;
			this.sbtnCancel.Text = "Cancel";
			this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
			// 
			// dateEdit1
			// 
			this.dateEdit1.EditValue = new System.DateTime(2005, 10, 21, 0, 0, 0, 0);
			this.dateEdit1.Location = new System.Drawing.Point(98, 12);
			this.dateEdit1.Name = "dateEdit1";
			// 
			// dateEdit1.Properties
			// 
			this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			this.dateEdit1.Properties.ReadOnly = true;
			this.dateEdit1.Size = new System.Drawing.Size(104, 20);
			this.dateEdit1.TabIndex = 0;
			// 
			// luedtEmployeeID
			// 
			this.luedtEmployeeID.Location = new System.Drawing.Point(98, 40);
			this.luedtEmployeeID.Name = "luedtEmployeeID";
			// 
			// luedtEmployeeID.Properties
			// 
			this.luedtEmployeeID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.luedtEmployeeID.Properties.ReadOnly = true;
			this.luedtEmployeeID.Size = new System.Drawing.Size(304, 20);
			this.luedtEmployeeID.TabIndex = 1;
			// 
			// frmReplies
			// 
			this.AcceptButton = this.sbtnSave;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.sbtnCancel;
			this.ClientSize = new System.Drawing.Size(574, 264);
			this.Controls.Add(this.luedtEmployeeID);
			this.Controls.Add(this.dateEdit1);
			this.Controls.Add(this.sbtnSave);
			this.Controls.Add(this.sbtnCancel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.memoEdit1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmReplies";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "{0} Reply";
			((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtEmployeeID.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void sbtnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private bool ValidationBeforeSave()
		{
			if (memoEdit1.Text.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please fill in message.");
				memoEdit1.Focus();
				return false;
			}

			return true;
		}

		private void sbtnSave_Click(object sender, System.EventArgs e)
		{
			if (!ValidationBeforeSave())
			{
				DialogResult = DialogResult.None;
				return;
			}

			if (myAction == ACMSLogic.Staff.MemoReplyAction.Add)
			{
				if (myMemo.SaveNewReply(nMemoID, nEmployeeID, memoEdit1.Text))
				{
					UI.ShowMessage(this, "Add new reply successfully.");
					DialogResult = DialogResult.OK;
				}
			}
			else
			{
				if (myMemo.UpdateReply(nBulletinID, nMemoID, memoEdit1.Text))
				{
					UI.ShowMessage(this, "Update reply successfully.");
					DialogResult = DialogResult.OK;
				}
			}
		}
	}
}
