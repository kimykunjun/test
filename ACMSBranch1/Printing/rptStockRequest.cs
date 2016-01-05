using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ACMS.ACMSBranch.Printing
{
	/// <summary>
	/// Summary description for rptStockRequest.
	/// </summary>
	public class rptStockRequest : DevExpress.XtraReports.UI.XtraReport
	{
		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.XRLine xrLine1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel27;
		private DevExpress.XtraReports.UI.XRLabel xrLabel25;
		private DevExpress.XtraReports.UI.XRLabel xrLabel23;
		private DevExpress.XtraReports.UI.XRLabel xrLabel21;
		private DevExpress.XtraReports.UI.XRLabel xrLabel19;
		private DevExpress.XtraReports.UI.XRLabel xrLabel17;
		private DevExpress.XtraReports.UI.XRLabel xrLabel5;
		private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
		private DevExpress.XtraReports.UI.XRLabel xrLabel15;
		private DevExpress.XtraReports.UI.XRLabel xrLabel14;
		private DevExpress.XtraReports.UI.XRLabel xrLabel13;
		private DevExpress.XtraReports.UI.XRLabel xrLabel9;
		private DevExpress.XtraReports.UI.XRLabel xrLabel1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel8;
		private DevExpress.XtraReports.UI.XRLabel xrLabel7;
		private DevExpress.XtraReports.UI.XRLabel xrLabel6;
		private DevExpress.XtraReports.UI.XRLabel xrLabel4;
		private DevExpress.XtraReports.UI.XRLabel xrLabel3;
		private DevExpress.XtraReports.UI.XRLabel xrLabel2;
		private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
		private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
		private DevExpress.XtraReports.UI.DetailReportBand DetailReport;
		private DevExpress.XtraReports.UI.DetailBand Detail1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel28;
		private DevExpress.XtraReports.UI.XRLabel xrLabel26;
		private DevExpress.XtraReports.UI.XRLabel xrLabel24;
		private DevExpress.XtraReports.UI.XRLabel xrLabel22;
		private DevExpress.XtraReports.UI.XRLabel xrLabel20;
		private DevExpress.XtraReports.UI.XRLabel xrLabel18;
		private DevExpress.XtraReports.UI.XRLabel xrLabel16;
		private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel11;
		private DevExpress.XtraReports.UI.XRLabel xrLabel10;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptStockRequest()
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
			this.Detail = new DevExpress.XtraReports.UI.DetailBand();
			this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
			this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
			this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
			this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
			this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
			this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
			this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
			this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
			this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
			this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
			this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																						this.xrLine1,
																						this.xrLabel27,
																						this.xrLabel25,
																						this.xrLabel23,
																						this.xrLabel21,
																						this.xrLabel19,
																						this.xrLabel17,
																						this.xrLabel5});
			this.Detail.Height = 25;
			this.Detail.Name = "Detail";
			// 
			// xrLine1
			// 
			this.xrLine1.Location = new System.Drawing.Point(8, 17);
			this.xrLine1.Name = "xrLine1";
			this.xrLine1.Size = new System.Drawing.Size(642, 8);
			// 
			// xrLabel27
			// 
			this.xrLabel27.Location = new System.Drawing.Point(592, 0);
			this.xrLabel27.Name = "xrLabel27";
			this.xrLabel27.Size = new System.Drawing.Size(58, 17);
			this.xrLabel27.Text = "QTY";
			// 
			// xrLabel25
			// 
			this.xrLabel25.Location = new System.Drawing.Point(467, 0);
			this.xrLabel25.Name = "xrLabel25";
			this.xrLabel25.Size = new System.Drawing.Size(125, 17);
			this.xrLabel25.Text = "DESCRIPTION";
			// 
			// xrLabel23
			// 
			this.xrLabel23.Location = new System.Drawing.Point(408, 0);
			this.xrLabel23.Name = "xrLabel23";
			this.xrLabel23.Size = new System.Drawing.Size(59, 17);
			this.xrLabel23.Text = "SIZE";
			// 
			// xrLabel21
			// 
			this.xrLabel21.Location = new System.Drawing.Point(308, 0);
			this.xrLabel21.Name = "xrLabel21";
			this.xrLabel21.Size = new System.Drawing.Size(100, 17);
			this.xrLabel21.Text = "COLOR";
			// 
			// xrLabel19
			// 
			this.xrLabel19.Location = new System.Drawing.Point(208, 0);
			this.xrLabel19.Name = "xrLabel19";
			this.xrLabel19.Size = new System.Drawing.Size(100, 17);
			this.xrLabel19.Text = "STYLE";
			// 
			// xrLabel17
			// 
			this.xrLabel17.Location = new System.Drawing.Point(108, 0);
			this.xrLabel17.Name = "xrLabel17";
			this.xrLabel17.Size = new System.Drawing.Size(100, 17);
			this.xrLabel17.Text = "BRAND";
			// 
			// xrLabel5
			// 
			this.xrLabel5.Location = new System.Drawing.Point(8, 0);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.Size = new System.Drawing.Size(100, 17);
			this.xrLabel5.Text = "ITEMCODE";
			// 
			// PageHeader
			// 
			this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																							this.xrLabel15,
																							this.xrLabel14,
																							this.xrLabel13,
																							this.xrLabel9,
																							this.xrLabel1,
																							this.xrLabel8,
																							this.xrLabel7,
																							this.xrLabel6,
																							this.xrLabel4,
																							this.xrLabel3,
																							this.xrLabel2});
			this.PageHeader.Height = 160;
			this.PageHeader.Name = "PageHeader";
			// 
			// xrLabel15
			// 
			this.xrLabel15.Location = new System.Drawing.Point(8, 125);
			this.xrLabel15.Name = "xrLabel15";
			this.xrLabel15.Size = new System.Drawing.Size(59, 25);
			this.xrLabel15.Text = "By:";
			// 
			// xrLabel14
			// 
			this.xrLabel14.Location = new System.Drawing.Point(292, 100);
			this.xrLabel14.Name = "xrLabel14";
			this.xrLabel14.Size = new System.Drawing.Size(59, 25);
			this.xrLabel14.Text = "To:";
			// 
			// xrLabel13
			// 
			this.xrLabel13.Location = new System.Drawing.Point(8, 100);
			this.xrLabel13.Name = "xrLabel13";
			this.xrLabel13.Size = new System.Drawing.Size(59, 25);
			this.xrLabel13.Text = "From:";
			// 
			// xrLabel9
			// 
			this.xrLabel9.Location = new System.Drawing.Point(8, 67);
			this.xrLabel9.Name = "xrLabel9";
			this.xrLabel9.Size = new System.Drawing.Size(59, 25);
			this.xrLabel9.Text = "Date:";
			// 
			// xrLabel1
			// 
			this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							  new DevExpress.XtraReports.UI.XRBinding("Text", null, "Table.Date", "{0:dd/MM/yyyy}")});
			this.xrLabel1.Location = new System.Drawing.Point(67, 67);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.Size = new System.Drawing.Size(191, 25);
			this.xrLabel1.Text = "xrLabel1";
			// 
			// xrLabel8
			// 
			this.xrLabel8.Location = new System.Drawing.Point(8, 42);
			this.xrLabel8.Name = "xrLabel8";
			this.xrLabel8.Size = new System.Drawing.Size(59, 25);
			this.xrLabel8.Text = "No:";
			// 
			// xrLabel7
			// 
			this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
			this.xrLabel7.Location = new System.Drawing.Point(8, 8);
			this.xrLabel7.Name = "xrLabel7";
			this.xrLabel7.ParentStyleUsing.UseFont = false;
			this.xrLabel7.Size = new System.Drawing.Size(200, 25);
			this.xrLabel7.Text = "STOCK REQUEST";
			// 
			// xrLabel6
			// 
			this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							  new DevExpress.XtraReports.UI.XRBinding("Text", null, "Table.ToBranch", "")});
			this.xrLabel6.Location = new System.Drawing.Point(350, 100);
			this.xrLabel6.Name = "xrLabel6";
			this.xrLabel6.Size = new System.Drawing.Size(100, 25);
			this.xrLabel6.Text = "xrLabel6";
			// 
			// xrLabel4
			// 
			this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							  new DevExpress.XtraReports.UI.XRBinding("Text", null, "Table.RequestNo", "")});
			this.xrLabel4.Location = new System.Drawing.Point(67, 42);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.Size = new System.Drawing.Size(141, 25);
			this.xrLabel4.Text = "xrLabel4";
			// 
			// xrLabel3
			// 
			this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							  new DevExpress.XtraReports.UI.XRBinding("Text", null, "Table.RequestedBy", "")});
			this.xrLabel3.Location = new System.Drawing.Point(67, 125);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.Size = new System.Drawing.Size(583, 25);
			this.xrLabel3.Text = "xrLabel3";
			// 
			// xrLabel2
			// 
			this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							  new DevExpress.XtraReports.UI.XRBinding("Text", null, "Table.FromBranch", "")});
			this.xrLabel2.Location = new System.Drawing.Point(67, 100);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.Size = new System.Drawing.Size(100, 25);
			this.xrLabel2.Text = "xrLabel2";
			// 
			// PageFooter
			// 
			this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																							this.xrPageInfo1});
			this.PageFooter.Height = 27;
			this.PageFooter.Name = "PageFooter";
			// 
			// xrPageInfo1
			// 
			this.xrPageInfo1.Format = "Page : {0 } / {1}";
			this.xrPageInfo1.Location = new System.Drawing.Point(550, 0);
			this.xrPageInfo1.Name = "xrPageInfo1";
			this.xrPageInfo1.Size = new System.Drawing.Size(100, 25);
			// 
			// DetailReport
			// 
			this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
																					  this.Detail1});
			this.DetailReport.DataMember = "StockRequestEntries";
			this.DetailReport.Name = "DetailReport";
			// 
			// Detail1
			// 
			this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																						 this.xrLabel28,
																						 this.xrLabel26,
																						 this.xrLabel24,
																						 this.xrLabel22,
																						 this.xrLabel20,
																						 this.xrLabel18,
																						 this.xrLabel16});
			this.Detail1.Height = 26;
			this.Detail1.Name = "Detail1";
			// 
			// xrLabel28
			// 
			this.xrLabel28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "StockRequestEntries.Quantity", "")});
			this.xrLabel28.Location = new System.Drawing.Point(592, 0);
			this.xrLabel28.Name = "xrLabel28";
			this.xrLabel28.Size = new System.Drawing.Size(58, 25);
			this.xrLabel28.Text = "xrLabel28";
			// 
			// xrLabel26
			// 
			this.xrLabel26.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "StockRequestEntries.Description", "")});
			this.xrLabel26.Location = new System.Drawing.Point(467, 0);
			this.xrLabel26.Name = "xrLabel26";
			this.xrLabel26.Size = new System.Drawing.Size(125, 25);
			this.xrLabel26.Text = "xrLabel26";
			// 
			// xrLabel24
			// 
			this.xrLabel24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "StockRequestEntries.Size", "")});
			this.xrLabel24.Location = new System.Drawing.Point(408, 0);
			this.xrLabel24.Name = "xrLabel24";
			this.xrLabel24.Size = new System.Drawing.Size(59, 25);
			this.xrLabel24.Text = "xrLabel24";
			// 
			// xrLabel22
			// 
			this.xrLabel22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "StockRequestEntries.Color", "")});
			this.xrLabel22.Location = new System.Drawing.Point(308, 0);
			this.xrLabel22.Name = "xrLabel22";
			this.xrLabel22.Size = new System.Drawing.Size(100, 25);
			this.xrLabel22.Text = "xrLabel22";
			// 
			// xrLabel20
			// 
			this.xrLabel20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "StockRequestEntries.Style", "")});
			this.xrLabel20.Location = new System.Drawing.Point(208, 0);
			this.xrLabel20.Name = "xrLabel20";
			this.xrLabel20.Size = new System.Drawing.Size(100, 25);
			this.xrLabel20.Text = "xrLabel20";
			// 
			// xrLabel18
			// 
			this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "StockRequestEntries.Brand", "")});
			this.xrLabel18.Location = new System.Drawing.Point(108, 0);
			this.xrLabel18.Name = "xrLabel18";
			this.xrLabel18.Size = new System.Drawing.Size(100, 25);
			this.xrLabel18.Text = "xrLabel18";
			// 
			// xrLabel16
			// 
			this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "StockRequestEntries.ItemCode", "")});
			this.xrLabel16.Location = new System.Drawing.Point(8, 0);
			this.xrLabel16.Name = "xrLabel16";
			this.xrLabel16.Size = new System.Drawing.Size(100, 25);
			this.xrLabel16.Text = "xrLabel16";
			// 
			// GroupFooter1
			// 
			this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																							  this.xrLabel11,
																							  this.xrLabel10});
			this.GroupFooter1.Height = 34;
			this.GroupFooter1.Name = "GroupFooter1";
			// 
			// xrLabel11
			// 
			this.xrLabel11.Location = new System.Drawing.Point(8, 8);
			this.xrLabel11.Name = "xrLabel11";
			this.xrLabel11.Size = new System.Drawing.Size(59, 25);
			this.xrLabel11.Text = "Remark:";
			// 
			// xrLabel10
			// 
			this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "StockRequest.Remark", "")});
			this.xrLabel10.Location = new System.Drawing.Point(67, 8);
			this.xrLabel10.Name = "xrLabel10";
			this.xrLabel10.Size = new System.Drawing.Size(100, 25);
			this.xrLabel10.Text = "xrLabel10";
			// 
			// rptStockRequest
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
																		 this.Detail,
																		 this.PageHeader,
																		 this.PageFooter,
																		 this.DetailReport,
																		 this.GroupFooter1});
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion
	}
}

