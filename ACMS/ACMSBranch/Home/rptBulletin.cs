using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ACMS.ACMSBranch.Home
{
	/// <summary>
	/// Summary description for rptBulletin.
	/// </summary>
	public class rptBulletin : DevExpress.XtraReports.UI.XtraReport
	{
		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
		private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
		private DevExpress.XtraReports.UI.XRLabel xrLabel1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel2;
		private DevExpress.XtraReports.UI.XRLabel xrLabel3;
		private DevExpress.XtraReports.UI.XRLabel xrLabel4;
		private DevExpress.XtraReports.UI.XRLabel xrLabel5;
		private DevExpress.XtraReports.UI.XRLabel xrLabel6;
		public DevExpress.XtraReports.UI.XRLabel xrLabel7;
		public DevExpress.XtraReports.UI.XRLabel xrLabel8;
		public DevExpress.XtraReports.UI.XRLabel xrLabel9;
		public DevExpress.XtraReports.UI.XRLabel xrLabel10;
		public DevExpress.XtraReports.UI.XRLabel xrLabel11;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptBulletin()
		{
			//
			// Required for Designer support
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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
			this.Detail = new DevExpress.XtraReports.UI.DetailBand();
			this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
			this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																						this.xrLabel11,
																						this.xrLabel10,
																						this.xrLabel9,
																						this.xrLabel8,
																						this.xrLabel7,
																						this.xrLabel6,
																						this.xrLabel5,
																						this.xrLabel4,
																						this.xrLabel3,
																						this.xrLabel2,
																						this.xrLabel1});
			this.Detail.Height = 328;
			this.Detail.Name = "Detail";
			// 
			// xrLabel11
			// 
			this.xrLabel11.Location = new System.Drawing.Point(175, 183);
			this.xrLabel11.Name = "xrLabel11";
			this.xrLabel11.ParentStyleUsing.UseBorders = false;
			this.xrLabel11.Size = new System.Drawing.Size(442, 142);
			this.xrLabel11.Text = "xrLabel10";
			// 
			// xrLabel10
			// 
			this.xrLabel10.Location = new System.Drawing.Point(175, 150);
			this.xrLabel10.Name = "xrLabel10";
			this.xrLabel10.ParentStyleUsing.UseBorders = false;
			this.xrLabel10.Size = new System.Drawing.Size(442, 25);
			this.xrLabel10.Text = "xrLabel10";
			// 
			// xrLabel9
			// 
			this.xrLabel9.Location = new System.Drawing.Point(175, 117);
			this.xrLabel9.Name = "xrLabel9";
			this.xrLabel9.ParentStyleUsing.UseBorders = false;
			this.xrLabel9.Size = new System.Drawing.Size(442, 25);
			this.xrLabel9.Text = "xrLabel9";
			// 
			// xrLabel8
			// 
			this.xrLabel8.Location = new System.Drawing.Point(175, 83);
			this.xrLabel8.Name = "xrLabel8";
			this.xrLabel8.ParentStyleUsing.UseBorders = false;
			this.xrLabel8.Size = new System.Drawing.Size(233, 25);
			this.xrLabel8.Text = "xrLabel8";
			// 
			// xrLabel7
			// 
			this.xrLabel7.Location = new System.Drawing.Point(175, 50);
			this.xrLabel7.Name = "xrLabel7";
			this.xrLabel7.ParentStyleUsing.UseBorders = false;
			this.xrLabel7.Size = new System.Drawing.Size(233, 25);
			xrSummary1.FormatString = "{0:dd/MM/yyyy hh:mm:ss tt}";
			this.xrLabel7.Summary = xrSummary1;
			// 
			// xrLabel6
			// 
			this.xrLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel6.Location = new System.Drawing.Point(58, 183);
			this.xrLabel6.Name = "xrLabel6";
			this.xrLabel6.ParentStyleUsing.UseFont = false;
			this.xrLabel6.Size = new System.Drawing.Size(100, 25);
			this.xrLabel6.Text = "Message";
			// 
			// xrLabel5
			// 
			this.xrLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel5.Location = new System.Drawing.Point(58, 150);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.ParentStyleUsing.UseFont = false;
			this.xrLabel5.Size = new System.Drawing.Size(100, 25);
			this.xrLabel5.Text = "Recipient";
			// 
			// xrLabel4
			// 
			this.xrLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel4.Location = new System.Drawing.Point(58, 117);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.ParentStyleUsing.UseFont = false;
			this.xrLabel4.Size = new System.Drawing.Size(100, 25);
			this.xrLabel4.Text = "Subject";
			// 
			// xrLabel3
			// 
			this.xrLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel3.Location = new System.Drawing.Point(58, 83);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.ParentStyleUsing.UseFont = false;
			this.xrLabel3.Size = new System.Drawing.Size(100, 25);
			this.xrLabel3.Text = "Author";
			// 
			// xrLabel2
			// 
			this.xrLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel2.Location = new System.Drawing.Point(58, 50);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.ParentStyleUsing.UseFont = false;
			this.xrLabel2.Size = new System.Drawing.Size(100, 25);
			this.xrLabel2.Text = "Date Time";
			// 
			// xrLabel1
			// 
			this.xrLabel1.BackColor = System.Drawing.SystemColors.Control;
			this.xrLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel1.Location = new System.Drawing.Point(25, 8);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.ParentStyleUsing.UseBackColor = false;
			this.xrLabel1.ParentStyleUsing.UseFont = false;
			this.xrLabel1.Size = new System.Drawing.Size(617, 25);
			this.xrLabel1.Text = "Bulletin";
			// 
			// PageHeader
			// 
			this.PageHeader.Height = 0;
			this.PageHeader.Name = "PageHeader";
			// 
			// PageFooter
			// 
			this.PageFooter.Height = 3;
			this.PageFooter.Name = "PageFooter";
			// 
			// rptBulletin
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
																		 this.Detail,
																		 this.PageHeader,
																		 this.PageFooter});
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion
	}
}

