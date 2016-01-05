using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ACMS.ACMSManager
{
	/// <summary>
	/// Summary description for frmMemberCard.
	/// </summary>
	public class frmMemberCard : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.GroupControl groupControl2;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private System.Windows.Forms.Label labelDay;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraEditors.ImageComboBoxEdit comboBoxDay;
		private DevExpress.XtraEditors.ImageComboBoxEdit imageComboBoxEdit1;
		private DevExpress.XtraEditors.ImageComboBoxEdit imageComboBoxEdit2;
		private DevExpress.XtraEditors.TextEdit textEdit1;
		private DevExpress.XtraEditors.SimpleButton btnClassScheduleUpdate;
		private DevExpress.XtraEditors.SimpleButton btnMemberCardCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMemberCard()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
			this.label1 = new System.Windows.Forms.Label();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.btnClassScheduleUpdate = new DevExpress.XtraEditors.SimpleButton();
			this.btnMemberCardCancel = new DevExpress.XtraEditors.SimpleButton();
			this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
			this.imageComboBoxEdit2 = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.imageComboBoxEdit1 = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.comboBoxDay = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.labelDay = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
			this.groupControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit2.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxDay.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// groupControl2
			// 
			this.groupControl2.Appearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.groupControl2.Appearance.Options.UseBackColor = true;
			this.groupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.groupControl2.Controls.Add(this.label1);
			this.groupControl2.Location = new System.Drawing.Point(0, 0);
			this.groupControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.groupControl2.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupControl2.LookAndFeel.UseWindowsXPTheme = false;
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.Size = new System.Drawing.Size(344, 32);
			this.groupControl2.TabIndex = 55;
			this.groupControl2.Text = "groupControl2";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(328, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "AMORE MEMBER CARD PROCESSING";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupControl1
			// 
			this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.groupControl1.Controls.Add(this.btnClassScheduleUpdate);
			this.groupControl1.Controls.Add(this.btnMemberCardCancel);
			this.groupControl1.Controls.Add(this.textEdit1);
			this.groupControl1.Controls.Add(this.imageComboBoxEdit2);
			this.groupControl1.Controls.Add(this.imageComboBoxEdit1);
			this.groupControl1.Controls.Add(this.comboBoxDay);
			this.groupControl1.Controls.Add(this.label4);
			this.groupControl1.Controls.Add(this.label3);
			this.groupControl1.Controls.Add(this.label2);
			this.groupControl1.Controls.Add(this.labelDay);
			this.groupControl1.Location = new System.Drawing.Point(0, 32);
			this.groupControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(344, 176);
			this.groupControl1.TabIndex = 56;
			// 
			// btnClassScheduleUpdate
			// 
			this.btnClassScheduleUpdate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnClassScheduleUpdate.Location = new System.Drawing.Point(152, 136);
			this.btnClassScheduleUpdate.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.btnClassScheduleUpdate.LookAndFeel.UseDefaultLookAndFeel = false;
			this.btnClassScheduleUpdate.Name = "btnClassScheduleUpdate";
			this.btnClassScheduleUpdate.TabIndex = 90;
			this.btnClassScheduleUpdate.Text = "Save";
			// 
			// btnMemberCardCancel
			// 
			this.btnMemberCardCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnMemberCardCancel.Location = new System.Drawing.Point(232, 136);
			this.btnMemberCardCancel.Name = "btnMemberCardCancel";
			this.btnMemberCardCancel.TabIndex = 89;
			this.btnMemberCardCancel.Text = "Cancel";
			this.btnMemberCardCancel.Click += new System.EventHandler(this.btnMemberCardCancel_Click);
			// 
			// textEdit1
			// 
			this.textEdit1.EditValue = "textEdit1";
			this.textEdit1.Location = new System.Drawing.Point(200, 16);
			this.textEdit1.Name = "textEdit1";
			// 
			// textEdit1.Properties
			// 
			this.textEdit1.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.textEdit1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.textEdit1.Size = new System.Drawing.Size(104, 20);
			this.textEdit1.TabIndex = 88;
			// 
			// imageComboBoxEdit2
			// 
			this.imageComboBoxEdit2.EditValue = "imageComboBoxEdit1";
			this.imageComboBoxEdit2.Location = new System.Drawing.Point(200, 88);
			this.imageComboBoxEdit2.Name = "imageComboBoxEdit2";
			// 
			// imageComboBoxEdit2.Properties
			// 
			this.imageComboBoxEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.imageComboBoxEdit2.Properties.Items.AddRange(new object[] {
																			   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("SUNDAY", 0, -1),
																			   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("MONDAY", 1, -1),
																			   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("TUESDAY", 2, -1),
																			   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("WEDNERSDAY", 3, -1),
																			   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("THURSDAY", 4, -1),
																			   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("FRIDAY", 5, -1),
																			   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("SATURDAY", 6, -1)});
			this.imageComboBoxEdit2.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.imageComboBoxEdit2.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.imageComboBoxEdit2.Size = new System.Drawing.Size(104, 20);
			this.imageComboBoxEdit2.TabIndex = 87;
			// 
			// imageComboBoxEdit1
			// 
			this.imageComboBoxEdit1.EditValue = "imageComboBoxEdit1";
			this.imageComboBoxEdit1.Location = new System.Drawing.Point(200, 64);
			this.imageComboBoxEdit1.Name = "imageComboBoxEdit1";
			// 
			// imageComboBoxEdit1.Properties
			// 
			this.imageComboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.imageComboBoxEdit1.Properties.Items.AddRange(new object[] {
																			   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("SUNDAY", 0, -1),
																			   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("MONDAY", 1, -1),
																			   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("TUESDAY", 2, -1),
																			   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("WEDNERSDAY", 3, -1),
																			   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("THURSDAY", 4, -1),
																			   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("FRIDAY", 5, -1),
																			   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("SATURDAY", 6, -1)});
			this.imageComboBoxEdit1.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.imageComboBoxEdit1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.imageComboBoxEdit1.Size = new System.Drawing.Size(104, 20);
			this.imageComboBoxEdit1.TabIndex = 86;
			// 
			// comboBoxDay
			// 
			this.comboBoxDay.EditValue = "imageComboBoxEdit1";
			this.comboBoxDay.Location = new System.Drawing.Point(200, 40);
			this.comboBoxDay.Name = "comboBoxDay";
			// 
			// comboBoxDay.Properties
			// 
			this.comboBoxDay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxDay.Properties.Items.AddRange(new object[] {
																		new DevExpress.XtraEditors.Controls.ImageComboBoxItem("SUNDAY", 0, -1),
																		new DevExpress.XtraEditors.Controls.ImageComboBoxItem("MONDAY", 1, -1),
																		new DevExpress.XtraEditors.Controls.ImageComboBoxItem("TUESDAY", 2, -1),
																		new DevExpress.XtraEditors.Controls.ImageComboBoxItem("WEDNERSDAY", 3, -1),
																		new DevExpress.XtraEditors.Controls.ImageComboBoxItem("THURSDAY", 4, -1),
																		new DevExpress.XtraEditors.Controls.ImageComboBoxItem("FRIDAY", 5, -1),
																		new DevExpress.XtraEditors.Controls.ImageComboBoxItem("SATURDAY", 6, -1)});
			this.comboBoxDay.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.comboBoxDay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.comboBoxDay.Size = new System.Drawing.Size(104, 20);
			this.comboBoxDay.TabIndex = 85;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(48, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(112, 16);
			this.label4.TabIndex = 76;
			this.label4.Text = "Status";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(48, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 16);
			this.label3.TabIndex = 75;
			this.label3.Text = "Branch";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(48, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 16);
			this.label2.TabIndex = 74;
			this.label2.Text = "Membership ID";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelDay
			// 
			this.labelDay.BackColor = System.Drawing.Color.Transparent;
			this.labelDay.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelDay.Location = new System.Drawing.Point(48, 16);
			this.labelDay.Name = "labelDay";
			this.labelDay.Size = new System.Drawing.Size(112, 16);
			this.labelDay.TabIndex = 73;
			this.labelDay.Text = "Request ID";
			this.labelDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmMemberCard
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(344, 213);
			this.Controls.Add(this.groupControl1);
			this.Controls.Add(this.groupControl2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmMemberCard";
			this.Text = "Member Card Printing Processig ....";
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
			this.groupControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit2.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxDay.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnMemberCardCancel_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}
	}
}
