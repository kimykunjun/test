using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ACMS.Utils;

namespace ACMS.ACMSBranch
{
	/// <summary>
	/// Summary description for frmDeleteMember.
	/// </summary>
	public class frmDeleteMember : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.MemoEdit memoedtRemark;
		private DevExpress.XtraEditors.SimpleButton sbtnCancel;
		private DevExpress.XtraEditors.SimpleButton sbtnDelete;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public string StrRemarks
		{
			get {return memoedtRemark.EditValue.ToString();}
		}

		public frmDeleteMember(string strDeleteMembershipID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.Text = String.Format(this.Text, strDeleteMembershipID);
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
			this.memoedtRemark = new DevExpress.XtraEditors.MemoEdit();
			this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnDelete = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.memoedtRemark.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(10, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(274, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Are you sure you want to delete?";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// memoedtRemark
			// 
			this.memoedtRemark.EditValue = "";
			this.memoedtRemark.Location = new System.Drawing.Point(14, 40);
			this.memoedtRemark.Name = "memoedtRemark";
			// 
			// memoedtRemark.Properties
			// 
			this.memoedtRemark.Properties.MaxLength = 255;
			this.memoedtRemark.Size = new System.Drawing.Size(266, 142);
			this.memoedtRemark.TabIndex = 0;
			// 
			// sbtnCancel
			// 
			this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sbtnCancel.Location = new System.Drawing.Point(206, 190);
			this.sbtnCancel.Name = "sbtnCancel";
			this.sbtnCancel.TabIndex = 2;
			this.sbtnCancel.Text = "Cancel";
			this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
			// 
			// sbtnDelete
			// 
			this.sbtnDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnDelete.Location = new System.Drawing.Point(122, 190);
			this.sbtnDelete.Name = "sbtnDelete";
			this.sbtnDelete.TabIndex = 1;
			this.sbtnDelete.Text = "Delete";
			this.sbtnDelete.Click += new System.EventHandler(this.sbtnDelete_Click);
			// 
			// frmDeleteMember
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.sbtnCancel;
			this.ClientSize = new System.Drawing.Size(292, 220);
			this.Controls.Add(this.sbtnCancel);
			this.Controls.Add(this.sbtnDelete);
			this.Controls.Add(this.memoedtRemark);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmDeleteMember";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Delete Member - {0}";
			((System.ComponentModel.ISupportInitialize)(this.memoedtRemark.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void sbtnCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void sbtnDelete_Click(object sender, System.EventArgs e)
		{
			if (memoedtRemark.EditValue.ToString().Length == 0)
			{
				UI.ShowErrorMessage(this, "Please fill in Remark field.", "Error");
				memoedtRemark.Focus();
				DialogResult = DialogResult.None;
				return;
			}
			else
			{
				DialogResult = DialogResult.OK;
			}
		}
	}
}
