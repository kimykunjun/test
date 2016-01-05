using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using ACMSDAL;
//using ACMSBLL = Acms.BLL;
using System.Data.SqlTypes;
using core = Acms.Core;

namespace ACMS.ACMSBranch.Home
{
	public class frmBranchBulletinReply : System.Windows.Forms.Form
	{
		//ACMSBLL.User oUser;
		core.Domain.Employee oUser;
		DateTime today;
		private System.Windows.Forms.TextBox txtMemoBulletinTitle;
		int nMemoID;
		
		#region " Windows Form Designer generated code "
		
		public frmBranchBulletinReply() {
			today = DateTime.Now;
			
			
			//This call is required by the Windows Form Designer.
			InitializeComponent();
			
			//Add any initialization after the InitializeComponent() call
			
		}
		
		//Form overrides dispose to clean up the component list.
		protected override void Dispose (bool disposing)
		{
			if (disposing)
			{
				if (!(components == null))
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		//Required by the Windows Form Designer
		private System.ComponentModel.Container components = null;
		
//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		internal DevExpress.XtraEditors.MemoEdit txtMemoBulletinMessage;
		internal System.Windows.Forms.Label Label37;
		internal System.Windows.Forms.Label Label40;
		internal DevExpress.XtraEditors.TextEdit txtMemoBulletinEmployeeName;
		internal System.Windows.Forms.Label Label41;
		internal DevExpress.XtraEditors.TextEdit txtMemoBulletinDate;
		internal DevExpress.XtraEditors.SimpleButton btnPost;
		internal DevExpress.XtraEditors.SimpleButton btnCancel;
		internal System.Windows.Forms.Label Label1;
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent ()
		{
			this.txtMemoBulletinMessage = new DevExpress.XtraEditors.MemoEdit();
			this.Label37 = new System.Windows.Forms.Label();
			this.Label40 = new System.Windows.Forms.Label();
			this.txtMemoBulletinEmployeeName = new DevExpress.XtraEditors.TextEdit();
			this.Label41 = new System.Windows.Forms.Label();
			this.txtMemoBulletinDate = new DevExpress.XtraEditors.TextEdit();
			this.btnPost = new DevExpress.XtraEditors.SimpleButton();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtMemoBulletinTitle = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.txtMemoBulletinMessage.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMemoBulletinEmployeeName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMemoBulletinDate.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// txtMemoBulletinMessage
			// 
			this.txtMemoBulletinMessage.EditValue = "";
			this.txtMemoBulletinMessage.Location = new System.Drawing.Point(96, 96);
			this.txtMemoBulletinMessage.Name = "txtMemoBulletinMessage";
			// 
			// txtMemoBulletinMessage.Properties
			// 
			this.txtMemoBulletinMessage.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtMemoBulletinMessage.Properties.Appearance.Options.UseFont = true;
			this.txtMemoBulletinMessage.Size = new System.Drawing.Size(296, 144);
			this.txtMemoBulletinMessage.TabIndex = 17;
			// 
			// Label37
			// 
			this.Label37.AutoSize = true;
			this.Label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label37.Location = new System.Drawing.Point(16, 104);
			this.Label37.Name = "Label37";
			this.Label37.Size = new System.Drawing.Size(61, 18);
			this.Label37.TabIndex = 16;
			this.Label37.Text = "Message";
			// 
			// Label40
			// 
			this.Label40.AutoSize = true;
			this.Label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label40.Location = new System.Drawing.Point(16, 64);
			this.Label40.Name = "Label40";
			this.Label40.Size = new System.Drawing.Size(46, 18);
			this.Label40.TabIndex = 15;
			this.Label40.Text = "Author";
			// 
			// txtMemoBulletinEmployeeName
			// 
			this.txtMemoBulletinEmployeeName.EditValue = "";
			this.txtMemoBulletinEmployeeName.Location = new System.Drawing.Point(96, 64);
			this.txtMemoBulletinEmployeeName.Name = "txtMemoBulletinEmployeeName";
			// 
			// txtMemoBulletinEmployeeName.Properties
			// 
			this.txtMemoBulletinEmployeeName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtMemoBulletinEmployeeName.Properties.Appearance.Options.UseFont = true;
			this.txtMemoBulletinEmployeeName.Properties.MaxLength = 19;
			this.txtMemoBulletinEmployeeName.Properties.ReadOnly = true;
			this.txtMemoBulletinEmployeeName.Size = new System.Drawing.Size(296, 24);
			this.txtMemoBulletinEmployeeName.TabIndex = 14;
			// 
			// Label41
			// 
			this.Label41.AutoSize = true;
			this.Label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label41.Location = new System.Drawing.Point(16, 40);
			this.Label41.Name = "Label41";
			this.Label41.Size = new System.Drawing.Size(69, 18);
			this.Label41.TabIndex = 13;
			this.Label41.Text = "Date Time";
			// 
			// txtMemoBulletinDate
			// 
			this.txtMemoBulletinDate.EditValue = "";
			this.txtMemoBulletinDate.Location = new System.Drawing.Point(96, 40);
			this.txtMemoBulletinDate.Name = "txtMemoBulletinDate";
			// 
			// txtMemoBulletinDate.Properties
			// 
			this.txtMemoBulletinDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtMemoBulletinDate.Properties.Appearance.Options.UseFont = true;
			this.txtMemoBulletinDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt";
			this.txtMemoBulletinDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.txtMemoBulletinDate.Properties.EditFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt";
			this.txtMemoBulletinDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.txtMemoBulletinDate.Properties.ReadOnly = true;
			this.txtMemoBulletinDate.Size = new System.Drawing.Size(296, 24);
			this.txtMemoBulletinDate.TabIndex = 12;
			// 
			// btnPost
			// 
			this.btnPost.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnPost.Location = new System.Drawing.Point(240, 248);
			this.btnPost.Name = "btnPost";
			this.btnPost.Size = new System.Drawing.Size(72, 20);
			this.btnPost.TabIndex = 18;
			this.btnPost.Text = "Post";
			this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnCancel.Location = new System.Drawing.Point(320, 248);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(72, 20);
			this.btnCancel.TabIndex = 19;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label1.Location = new System.Drawing.Point(16, 18);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(51, 18);
			this.Label1.TabIndex = 21;
			this.Label1.Text = "Subject";
			// 
			// txtMemoBulletinTitle
			// 
			this.txtMemoBulletinTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMemoBulletinTitle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtMemoBulletinTitle.Location = new System.Drawing.Point(96, 16);
			this.txtMemoBulletinTitle.Name = "txtMemoBulletinTitle";
			this.txtMemoBulletinTitle.Size = new System.Drawing.Size(296, 23);
			this.txtMemoBulletinTitle.TabIndex = 22;
			this.txtMemoBulletinTitle.Text = "";
			// 
			// frmBranchBulletinReply
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(426, 280);
			this.ControlBox = false;
			this.Controls.Add(this.txtMemoBulletinTitle);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.Label37);
			this.Controls.Add(this.Label40);
			this.Controls.Add(this.Label41);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnPost);
			this.Controls.Add(this.txtMemoBulletinMessage);
			this.Controls.Add(this.txtMemoBulletinEmployeeName);
			this.Controls.Add(this.txtMemoBulletinDate);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmBranchBulletinReply";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Bulletin Reply Form";
			this.Load += new System.EventHandler(this.frmBranchBulletinReply_Load);
			((System.ComponentModel.ISupportInitialize)(this.txtMemoBulletinMessage.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMemoBulletinEmployeeName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMemoBulletinDate.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		
		#endregion
		
		public void initData (core.Domain.Employee user, int MemoID)
		{
			oUser = user;
			nMemoID = MemoID;
		}
		
		
		private void frmBranchBulletinReply_Load (object sender, System.EventArgs e)
		{
			//modInitForms.fBranchBulletinReply = this;

			if(nMemoID == 0)
			{
				txtMemoBulletinTitle.Enabled = true;
				txtMemoBulletinDate.Text = today.ToString();
				txtMemoBulletinEmployeeName.Text = oUser.StrEmployeeName;
				//MessageBox.Show(txtMemoBulletinTitle.Enabled.ToString());
			}
			else
			{
				TblMemo oMemo = new TblMemo();
				oMemo.NMemoID = new SqlInt32(nMemoID);
				DataTable dtMemo = oMemo.SelectOne();
				DataRow drMemo = dtMemo.Rows[0];
				
				//init Variables
				txtMemoBulletinTitle.Text = "Re: " + drMemo[2].ToString();
				txtMemoBulletinTitle.Enabled = false;
				txtMemoBulletinDate.EditValue = today;
				txtMemoBulletinEmployeeName.Text = oUser.StrEmployeeName;
				txtMemoBulletinMessage.Text = "";
			}
		}
		
		private void btnCancel_Click (System.Object sender, System.EventArgs e)
		{
			this.Close();

			//modInitForms.fBranchBulletinReply = null;
		}
		
		private void btnPost_Click (System.Object sender, System.EventArgs e)
		{
			DateTime today = new DateTime();
			today = DateTime.Now;
			try
			{
			
					TblMemoBulletin oMemoBulletin = new TblMemoBulletin();
					oMemoBulletin.NMemoID = nMemoID;
					oMemoBulletin.SelectOne();
					oMemoBulletin.DtDate = new SqlDateTime(System.Convert.ToDateTime(today.ToString()));
					oMemoBulletin.NEmployeeID = new SqlInt32(oUser.Id);
			
					oMemoBulletin.StrMessage = new SqlString(txtMemoBulletinMessage.Text);
					oMemoBulletin.Insert();

					TblMemoRead tbMR = new TblMemoRead();
					tbMR.NMemoID = nMemoID;
					tbMR.NEmployeeID = new SqlInt32(oUser.Id);
					tbMR.DtDate = new SqlDateTime(System.Convert.ToDateTime(today.ToString()));
					tbMR.DeleteWnMemoEmpIDLogic();

					MessageBox.Show("Message posted successfully.");
				
	
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
			this.Close();

		}
	}
	
}
