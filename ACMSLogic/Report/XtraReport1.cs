using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ACMSLogic.Report
{
	/// <summary>
	/// Summary description for XtraReport1.
	/// </summary>
	public class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
	{
		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
		private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
		private DevExpress.XtraReports.UI.XRLabel xrLabel1;
		private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
		private DevExpress.XtraReports.UI.DetailReportBand DetailReport;
		private DevExpress.XtraReports.UI.DetailBand Detail1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public XtraReport1()
		{
			//
			// Required for Designer support
			//
			InitializeComponent();
			xrLabel1.DataBindings.Add("Text", DataSource, "strMemberName");
			xrPictureBox1.DataBindings.Add("Image", DataSource, "imgPhoto");
			

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
			this.Detail = new DevExpress.XtraReports.UI.DetailBand();
			this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
			this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
			this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
			this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																						this.xrPictureBox1,
																						this.xrLabel1});
			this.Detail.Name = "Detail";
			// 
			// PageHeader
			// 
			this.PageHeader.Height = 30;
			this.PageHeader.Name = "PageHeader";
			// 
			// PageFooter
			// 
			this.PageFooter.Height = 30;
			this.PageFooter.Name = "PageFooter";
			// 
			// xrLabel1
			// 
			this.xrLabel1.Location = new System.Drawing.Point(92, 8);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.Size = new System.Drawing.Size(100, 25);
			this.xrLabel1.Text = "xrLabel1";
			// 
			// xrPictureBox1
			// 
			this.xrPictureBox1.Location = new System.Drawing.Point(92, 42);
			this.xrPictureBox1.Name = "xrPictureBox1";
			this.xrPictureBox1.Size = new System.Drawing.Size(100, 25);
			// 
			// DetailReport
			// 
			this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
																					  this.Detail1});
			this.DetailReport.Name = "DetailReport";
			// 
			// Detail1
			// 
			this.Detail1.Name = "Detail1";
			// 
			// XtraReport1
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
																		 this.Detail,
																		 this.PageHeader,
																		 this.PageFooter,
																		 this.DetailReport});
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion
	}
}

