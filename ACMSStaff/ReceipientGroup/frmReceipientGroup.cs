using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ACMS.Utils;
using ACMSLogic;

namespace ACMS.ACMSStaff.ReceipientGroup
{
	/// <summary>
	/// Summary description for frmNewReceipientGroup.
	/// </summary>
	public class frmReceipientGroup : System.Windows.Forms.Form
	{
		private int nEmployeeID;
		private int nMemoGroupID;
		private string action;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.SimpleButton sbtnSave;
		private DevExpress.XtraEditors.SimpleButton sbtnCancel;
		private DevExpress.XtraEditors.TextEdit txtReceipentGroupCode;
		private DevExpress.XtraEditors.TextEdit txtDescription;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public string MemoGroupCode
		{
			set { txtReceipentGroupCode.Text = value; }
		}

		public string Description
		{
			set { txtDescription.Text = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="nEmployeeID"></param>
		/// <param name="nMemoGroupID">-1 is for New</param>
		/// <param name="action"></param>
		public frmReceipientGroup(int nEmployeeID, int nMemoGroupID, string action)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.nEmployeeID = nEmployeeID;
			this.nMemoGroupID = nMemoGroupID;
			this.Text = string.Format(this.Text, action);
			if (nMemoGroupID > -1)
			{
				this.Text = this.Text +"-ID:" +nMemoGroupID;
			}
			this.action = action;
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
			this.txtReceipentGroupCode = new DevExpress.XtraEditors.TextEdit();
			this.txtDescription = new DevExpress.XtraEditors.TextEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.sbtnSave = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.txtReceipentGroupCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(20, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 32);
			this.label1.TabIndex = 0;
			this.label1.Text = "Receipient Group Code:";
			// 
			// txtReceipentGroupCode
			// 
			this.txtReceipentGroupCode.EditValue = "";
			this.txtReceipentGroupCode.Location = new System.Drawing.Point(96, 22);
			this.txtReceipentGroupCode.Name = "txtReceipentGroupCode";
			this.txtReceipentGroupCode.Size = new System.Drawing.Size(174, 20);
			this.txtReceipentGroupCode.TabIndex = 0;
			// 
			// txtDescription
			// 
			this.txtDescription.EditValue = "";
			this.txtDescription.Location = new System.Drawing.Point(96, 54);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(351, 20);
			this.txtDescription.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(20, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Description:";
			// 
			// sbtnSave
			// 
			this.sbtnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.sbtnSave.Location = new System.Drawing.Point(300, 90);
			this.sbtnSave.Name = "sbtnSave";
			this.sbtnSave.TabIndex = 2;
			this.sbtnSave.Text = "Save";
			this.sbtnSave.Click += new System.EventHandler(this.sbtnSave_Click);
			// 
			// sbtnCancel
			// 
			this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sbtnCancel.Location = new System.Drawing.Point(382, 90);
			this.sbtnCancel.Name = "sbtnCancel";
			this.sbtnCancel.TabIndex = 3;
			this.sbtnCancel.Text = "Cancel";
			// 
			// frmReceipientGroup
			// 
			this.AcceptButton = this.sbtnSave;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.sbtnCancel;
			this.ClientSize = new System.Drawing.Size(466, 122);
			this.Controls.Add(this.sbtnSave);
			this.Controls.Add(this.sbtnCancel);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtReceipentGroupCode);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmReceipientGroup";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "{0} Receipient Group";
			((System.ComponentModel.ISupportInitialize)(this.txtReceipentGroupCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void sbtnSave_Click(object sender, System.EventArgs e)
		{
			if (txtReceipentGroupCode.Text.Length == 0)
			{
				UI.ShowErrorMessage("Please enter a Receipient Group Code.");
				txtReceipentGroupCode.Focus();
				DialogResult = DialogResult.None;
				return;
			}
			if (txtDescription.Text.Length == 0)
			{
				UI.ShowErrorMessage("Please enter a description.");
				txtDescription.Focus();
				DialogResult = DialogResult.None;
				return;
			}			

			ACMSLogic.Staff.ReceipientGroup myReceipientGroup = new ACMSLogic.Staff.ReceipientGroup();
			if (action == "New")
			{
				myReceipientGroup.NewReceipientGroup(txtReceipentGroupCode.Text, txtDescription.Text, nEmployeeID);
				DialogResult = DialogResult.OK;
			}
			else
			{
				myReceipientGroup.UpdateNewReceipientGroup(txtReceipentGroupCode.Text, txtDescription.Text, nMemoGroupID);
				DialogResult = DialogResult.OK;
			}
		}
	}
}
