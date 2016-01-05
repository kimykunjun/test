using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ACMS.ACMSManager
{
	/// <summary>
	/// Summary description for frmMD_SalesCommission.
	/// </summary>
	public class frmMD_SalesCommission : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.GroupControl groupCtrlMd_Service;
		private DevExpress.XtraEditors.GroupControl groupHdrMd_Service;
		private System.Windows.Forms.Label hdrMd_Service;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMD_SalesCommission()
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
			this.groupCtrlMd_Service = new DevExpress.XtraEditors.GroupControl();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.groupHdrMd_Service = new DevExpress.XtraEditors.GroupControl();
			this.hdrMd_Service = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.groupCtrlMd_Service)).BeginInit();
			this.groupCtrlMd_Service.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupHdrMd_Service)).BeginInit();
			this.groupHdrMd_Service.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupCtrlMd_Service
			// 
			this.groupCtrlMd_Service.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.groupCtrlMd_Service.Controls.Add(this.label2);
			this.groupCtrlMd_Service.Controls.Add(this.label1);
			this.groupCtrlMd_Service.Controls.Add(this.label31);
			this.groupCtrlMd_Service.Controls.Add(this.label28);
			this.groupCtrlMd_Service.Controls.Add(this.label27);
			this.groupCtrlMd_Service.Controls.Add(this.label26);
			this.groupCtrlMd_Service.Controls.Add(this.label22);
			this.groupCtrlMd_Service.Controls.Add(this.label21);
			this.groupCtrlMd_Service.Controls.Add(this.label19);
			this.groupCtrlMd_Service.Controls.Add(this.label18);
			this.groupCtrlMd_Service.Location = new System.Drawing.Point(0, 32);
			this.groupCtrlMd_Service.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.groupCtrlMd_Service.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupCtrlMd_Service.Name = "groupCtrlMd_Service";
			this.groupCtrlMd_Service.Size = new System.Drawing.Size(312, 288);
			this.groupCtrlMd_Service.TabIndex = 6;
			this.groupCtrlMd_Service.Text = "groupControl1";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.White;
			this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(16, 232);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(280, 16);
			this.label2.TabIndex = 142;
			this.label2.Text = "PTPCIT : PT Package Individual Target";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.White;
			this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 112);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(280, 16);
			this.label1.TabIndex = 141;
			this.label1.Text = "PTPCBT : PT Package Branch Target";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label31
			// 
			this.label31.BackColor = System.Drawing.Color.White;
			this.label31.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label31.Location = new System.Drawing.Point(16, 208);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(280, 16);
			this.label31.TabIndex = 124;
			this.label31.Text = "SPDIT   : SPA Product Individual Target";
			this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label28
			// 
			this.label28.BackColor = System.Drawing.Color.White;
			this.label28.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label28.Location = new System.Drawing.Point(16, 184);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(280, 16);
			this.label28.TabIndex = 123;
			this.label28.Text = "SPCIT   : SPA Package Individual Target";
			this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label27
			// 
			this.label27.BackColor = System.Drawing.Color.White;
			this.label27.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label27.Location = new System.Drawing.Point(16, 160);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(280, 16);
			this.label27.TabIndex = 122;
			this.label27.Text = "FPDIT   : Fitness Product Individual Target";
			this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label26
			// 
			this.label26.BackColor = System.Drawing.Color.White;
			this.label26.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label26.Location = new System.Drawing.Point(16, 136);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(280, 16);
			this.label26.TabIndex = 121;
			this.label26.Text = "FPCIT    : Fitness Package Individual Target";
			this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label22
			// 
			this.label22.BackColor = System.Drawing.Color.White;
			this.label22.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label22.Location = new System.Drawing.Point(16, 88);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(280, 16);
			this.label22.TabIndex = 120;
			this.label22.Text = "SPDBT  : SPA Product Branch Target";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label21
			// 
			this.label21.BackColor = System.Drawing.Color.White;
			this.label21.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label21.Location = new System.Drawing.Point(16, 64);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(280, 16);
			this.label21.TabIndex = 119;
			this.label21.Text = "SPCBT  : SPA Package Branch Target";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label19
			// 
			this.label19.BackColor = System.Drawing.Color.White;
			this.label19.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label19.Location = new System.Drawing.Point(16, 40);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(280, 16);
			this.label19.TabIndex = 118;
			this.label19.Text = "FPDBT  : Fitness Product Branch Target";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label18
			// 
			this.label18.BackColor = System.Drawing.Color.White;
			this.label18.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label18.Location = new System.Drawing.Point(16, 16);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(280, 16);
			this.label18.TabIndex = 117;
			this.label18.Text = "FPCBT  : Fitness Package Branch Target";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupHdrMd_Service
			// 
			this.groupHdrMd_Service.Appearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.groupHdrMd_Service.Appearance.Options.UseBackColor = true;
			this.groupHdrMd_Service.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.groupHdrMd_Service.Controls.Add(this.hdrMd_Service);
			this.groupHdrMd_Service.Location = new System.Drawing.Point(0, 0);
			this.groupHdrMd_Service.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.groupHdrMd_Service.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupHdrMd_Service.Name = "groupHdrMd_Service";
			this.groupHdrMd_Service.Size = new System.Drawing.Size(312, 32);
			this.groupHdrMd_Service.TabIndex = 5;
			this.groupHdrMd_Service.Text = "groupControl1";
			// 
			// hdrMd_Service
			// 
			this.hdrMd_Service.BackColor = System.Drawing.Color.Transparent;
			this.hdrMd_Service.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.hdrMd_Service.Location = new System.Drawing.Point(8, 8);
			this.hdrMd_Service.Name = "hdrMd_Service";
			this.hdrMd_Service.Size = new System.Drawing.Size(304, 23);
			this.hdrMd_Service.TabIndex = 1;
			this.hdrMd_Service.Text = "AMORE SALES COMMISSION LEGEND";
			this.hdrMd_Service.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmMD_SalesCommission
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(312, 293);
			this.Controls.Add(this.groupCtrlMd_Service);
			this.Controls.Add(this.groupHdrMd_Service);
			this.Name = "frmMD_SalesCommission";
			this.Text = "Sales Commision";
			((System.ComponentModel.ISupportInitialize)(this.groupCtrlMd_Service)).EndInit();
			this.groupCtrlMd_Service.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupHdrMd_Service)).EndInit();
			this.groupHdrMd_Service.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
