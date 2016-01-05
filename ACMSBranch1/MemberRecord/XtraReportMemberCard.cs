using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ACMS.ACMSBranch
{
	/// <summary>
	/// Summary description for XtraReportMemberCard.
	/// </summary>
	public class XtraReportMemberCard : DevExpress.XtraReports.UI.XtraReport
	{
		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.XRBarCode xrBarCode2;
		private DevExpress.XtraReports.UI.XRLabel xrLabel3;
		private DevExpress.XtraReports.UI.XRLabel xrLabel2;
		private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public XtraReportMemberCard()
		{
			//
			// Required for Designer support
			//
			InitializeComponent();
			
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public void CreateBind()
		{
			xrPictureBox1.DataBindings.Add("Image", DataSource, "imgPhoto");	
			xrLabel1.DataBindings.Add("Text",DataSource, "strMembershipID");
			xrLabel2.DataBindings.Add("Text",DataSource, "strCardName");
			xrBarCode2.DataBindings.Add("Text",DataSource, "strMembershipID");
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
			DevExpress.XtraReports.UI.BarCode.XRCode128Generator xrCode128Generator1 = new DevExpress.XtraReports.UI.BarCode.XRCode128Generator();
			this.Detail = new DevExpress.XtraReports.UI.DetailBand();
			this.xrBarCode2 = new DevExpress.XtraReports.UI.XRBarCode();
			this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																						this.xrBarCode2,
																						this.xrLabel3,
																						this.xrLabel2,
																						this.xrPictureBox1,
																						this.xrLabel1});
			this.Detail.Height = 349;
			this.Detail.Name = "Detail";
			this.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
			this.Detail.ParentStyleUsing.UseBackColor = false;
			// 
			// xrBarCode2
			// 
			this.xrBarCode2.Alignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			this.xrBarCode2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																								new DevExpress.XtraReports.UI.XRBinding("Text", null, "strMembershipID", "")});
			this.xrBarCode2.Font = new System.Drawing.Font("Times New Roman", 8F);
			this.xrBarCode2.Location = new System.Drawing.Point(50, 227);
			this.xrBarCode2.Module = 1F;
			this.xrBarCode2.Name = "xrBarCode2";
			this.xrBarCode2.ParentStyleUsing.UseFont = false;
			this.xrBarCode2.Size = new System.Drawing.Size(233, 42);
			this.xrBarCode2.Symbology = xrCode128Generator1;
			// 
			// xrLabel3
			// 
			this.xrLabel3.Font = new System.Drawing.Font("Verdana", 8.25F);
			this.xrLabel3.Location = new System.Drawing.Point(0, 142);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.ParentStyleUsing.UseFont = false;
			this.xrLabel3.Size = new System.Drawing.Size(17, 17);
			this.xrLabel3.Text = ".";
			// 
			// xrLabel2
			// 
			this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							  new DevExpress.XtraReports.UI.XRBinding("Text", null, "strCardName", "")});
			this.xrLabel2.Font = new System.Drawing.Font("Arial", 9F);
			this.xrLabel2.Location = new System.Drawing.Point(11, 177);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.ParentStyleUsing.UseFont = false;
			this.xrLabel2.Size = new System.Drawing.Size(209, 19);
			this.xrLabel2.Text = "xrLabel2";
			// 
			// xrPictureBox1
			// 
			this.xrPictureBox1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																								   new DevExpress.XtraReports.UI.XRBinding("Image", null, "imgPhoto", "")});
			this.xrPictureBox1.Location = new System.Drawing.Point(22, 19);
			this.xrPictureBox1.Name = "xrPictureBox1";
			this.xrPictureBox1.Size = new System.Drawing.Size(99, 119);
			this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
			// 
			// xrLabel1
			// 
			this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							  new DevExpress.XtraReports.UI.XRBinding("Text", null, "strMembershipID", "")});
			this.xrLabel1.Font = new System.Drawing.Font("Verdana", 8.25F);
			this.xrLabel1.Location = new System.Drawing.Point(11, 162);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.ParentStyleUsing.UseFont = false;
			this.xrLabel1.Size = new System.Drawing.Size(209, 19);
			this.xrLabel1.Text = "xrLabel1";
			// 
			// XtraReportMemberCard
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
																		 this.Detail});
			this.Landscape = true;
			this.Margins = new System.Drawing.Printing.Margins(0, 0, 1, 0);
			this.PageHeight = 353;
			this.PageWidth = 214;
			this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
			this.PaperName = "CR-79";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion
	}
}

