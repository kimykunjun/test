using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ACMS.ACMSStaff.Report
{
	/// <summary>
	/// Summary description for ReportMemo.
	/// </summary>
	public class ReportMemo : DevExpress.XtraReports.UI.XtraReport
	{
		private DevExpress.XtraReports.UI.DetailBand detailBand1;
		private DevExpress.XtraReports.UI.DetailReportBand DetailReport1;
		private DevExpress.XtraReports.UI.DetailBand Detail1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel2;
		private DevExpress.XtraReports.UI.XRLabel xrLabel1;
		private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
		private DevExpress.XtraReports.UI.XRLine xrLine5;
		private DevExpress.XtraReports.UI.XRLine xrLine4;
		private DevExpress.XtraReports.UI.XRLabel xrLabel5;
		private DevExpress.XtraReports.UI.XRLabel xrLabel6;
		private DevExpress.XtraReports.UI.DetailReportBand DetailReport;
		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.XRLine xrLine2;
		private DevExpress.XtraReports.UI.XRLabel xrLabel10;
		private DevExpress.XtraReports.UI.XRLabel xrLabel4;
		private DevExpress.XtraReports.UI.XRLabel xrLabel3;
		private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader1;
		private DevExpress.XtraReports.UI.XRLine xrLine3;
		private DevExpress.XtraReports.UI.XRLabel xrLabel9;
		private DevExpress.XtraReports.UI.XRLabel xrLabel8;
		private DevExpress.XtraReports.UI.XRLabel xrLabel7;
		private DevExpress.XtraReports.UI.XRLine xrLine1;
		private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
		private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
		private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
		private DevExpress.XtraReports.UI.XRLabel xrLabel22;
		private DevExpress.XtraReports.UI.XRLabel xrLabel21;
		private DevExpress.XtraReports.UI.XRLabel xrLabel20;
		private DevExpress.XtraReports.UI.XRLabel xrLabel19;
		private DevExpress.XtraReports.UI.XRLabel xrLabel18;
		private DevExpress.XtraReports.UI.XRLabel xrLabel17;
		private DevExpress.XtraReports.UI.XRLabel xrLabel16;
		private DevExpress.XtraReports.UI.XRLabel xrLabel15;
		private DevExpress.XtraReports.UI.XRLabel xrLabel14;
		private DevExpress.XtraReports.UI.XRLabel xrLabel13;
		private DevExpress.XtraReports.UI.XRLabel xrLabel12;
		private DevExpress.XtraReports.UI.XRLabel xrLabel11;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ReportMemo()
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
			this.detailBand1 = new DevExpress.XtraReports.UI.DetailBand();
			this.DetailReport1 = new DevExpress.XtraReports.UI.DetailReportBand();
			this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
			this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
			this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
			this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
			this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
			this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
			this.Detail = new DevExpress.XtraReports.UI.DetailBand();
			this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
			this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
			this.ReportHeader1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
			this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
			this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
			this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
			this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
			this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
			this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// detailBand1
			// 
			this.detailBand1.Height = 0;
			this.detailBand1.Name = "detailBand1";
			// 
			// DetailReport1
			// 
			this.DetailReport1.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
																					   this.Detail1,
																					   this.ReportHeader});
			this.DetailReport1.DataMember = "Recipient";
			this.DetailReport1.Name = "DetailReport1";
			// 
			// Detail1
			// 
			this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																						 this.xrLabel2,
																						 this.xrLabel1});
			this.Detail1.Height = 25;
			this.Detail1.Name = "Detail1";
			// 
			// xrLabel2
			// 
			this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							  new DevExpress.XtraReports.UI.XRBinding("Text", null, "Recipient.Type", "")});
			this.xrLabel2.Location = new System.Drawing.Point(8, 0);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.Size = new System.Drawing.Size(167, 25);
			this.xrLabel2.Text = "xrLabel2";
			// 
			// xrLabel1
			// 
			this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							  new DevExpress.XtraReports.UI.XRBinding("Text", null, "Recipient.Receipient", "")});
			this.xrLabel1.Location = new System.Drawing.Point(175, 0);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.Size = new System.Drawing.Size(475, 25);
			this.xrLabel1.Text = "xrLabel1";
			// 
			// ReportHeader
			// 
			this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																							  this.xrLine5,
																							  this.xrLine4,
																							  this.xrLabel5,
																							  this.xrLabel6});
			this.ReportHeader.Height = 34;
			this.ReportHeader.Name = "ReportHeader";
			// 
			// xrLine5
			// 
			this.xrLine5.Location = new System.Drawing.Point(0, 25);
			this.xrLine5.Name = "xrLine5";
			this.xrLine5.Size = new System.Drawing.Size(650, 8);
			// 
			// xrLine4
			// 
			this.xrLine4.Location = new System.Drawing.Point(0, 0);
			this.xrLine4.Name = "xrLine4";
			this.xrLine4.Size = new System.Drawing.Size(650, 8);
			// 
			// xrLabel5
			// 
			this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel5.Location = new System.Drawing.Point(8, 8);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.ParentStyleUsing.UseFont = false;
			this.xrLabel5.Size = new System.Drawing.Size(167, 17);
			this.xrLabel5.Text = "Type (Ind/Group/Branch)";
			// 
			// xrLabel6
			// 
			this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel6.Location = new System.Drawing.Point(175, 8);
			this.xrLabel6.Name = "xrLabel6";
			this.xrLabel6.ParentStyleUsing.UseFont = false;
			this.xrLabel6.Size = new System.Drawing.Size(467, 17);
			this.xrLabel6.Text = "Recipient (Group/Branch/Department/EmployeeID)";
			// 
			// DetailReport
			// 
			this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
																					  this.Detail,
																					  this.ReportHeader1});
			this.DetailReport.DataMember = "Replies";
			this.DetailReport.Name = "DetailReport";
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																						this.xrLine2,
																						this.xrLabel10,
																						this.xrLabel4,
																						this.xrLabel3});
			this.Detail.Height = 70;
			this.Detail.Name = "Detail";
			// 
			// xrLine2
			// 
			this.xrLine2.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
			this.xrLine2.Location = new System.Drawing.Point(0, 50);
			this.xrLine2.Name = "xrLine2";
			this.xrLine2.Size = new System.Drawing.Size(650, 8);
			// 
			// xrLabel10
			// 
			this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "Replies.strMessage", "")});
			this.xrLabel10.Location = new System.Drawing.Point(8, 25);
			this.xrLabel10.Name = "xrLabel10";
			this.xrLabel10.Size = new System.Drawing.Size(642, 25);
			this.xrLabel10.Text = "xrLabel10";
			// 
			// xrLabel4
			// 
			this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							  new DevExpress.XtraReports.UI.XRBinding("Text", null, "Replies.strEmployeeName", "")});
			this.xrLabel4.Location = new System.Drawing.Point(175, 0);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.Size = new System.Drawing.Size(475, 25);
			this.xrLabel4.Text = "xrLabel4";
			// 
			// xrLabel3
			// 
			this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							  new DevExpress.XtraReports.UI.XRBinding("Text", null, "Replies.dtDate", "")});
			this.xrLabel3.Location = new System.Drawing.Point(8, 0);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.Size = new System.Drawing.Size(167, 25);
			this.xrLabel3.Text = "xrLabel3";
			// 
			// ReportHeader1
			// 
			this.ReportHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																							   this.xrLine3,
																							   this.xrLabel9,
																							   this.xrLabel8,
																							   this.xrLabel7,
																							   this.xrLine1});
			this.ReportHeader1.Height = 50;
			this.ReportHeader1.Name = "ReportHeader1";
			// 
			// xrLine3
			// 
			this.xrLine3.Location = new System.Drawing.Point(0, 42);
			this.xrLine3.Name = "xrLine3";
			this.xrLine3.Size = new System.Drawing.Size(650, 8);
			// 
			// xrLabel9
			// 
			this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel9.Location = new System.Drawing.Point(8, 25);
			this.xrLabel9.Name = "xrLabel9";
			this.xrLabel9.ParentStyleUsing.UseFont = false;
			this.xrLabel9.Size = new System.Drawing.Size(167, 17);
			this.xrLabel9.Text = "Message";
			// 
			// xrLabel8
			// 
			this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel8.Location = new System.Drawing.Point(175, 8);
			this.xrLabel8.Name = "xrLabel8";
			this.xrLabel8.ParentStyleUsing.UseFont = false;
			this.xrLabel8.Size = new System.Drawing.Size(366, 17);
			this.xrLabel8.Text = "Employee Name";
			// 
			// xrLabel7
			// 
			this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel7.Location = new System.Drawing.Point(8, 8);
			this.xrLabel7.Name = "xrLabel7";
			this.xrLabel7.ParentStyleUsing.UseFont = false;
			this.xrLabel7.Size = new System.Drawing.Size(167, 17);
			this.xrLabel7.Text = "Date";
			// 
			// xrLine1
			// 
			this.xrLine1.Location = new System.Drawing.Point(0, 1);
			this.xrLine1.Name = "xrLine1";
			this.xrLine1.Size = new System.Drawing.Size(650, 8);
			// 
			// BottomMargin
			// 
			this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																							  this.xrPageInfo1});
			this.BottomMargin.Height = 27;
			this.BottomMargin.Name = "BottomMargin";
			// 
			// xrPageInfo1
			// 
			this.xrPageInfo1.Format = "Page : {0 } / {1}";
			this.xrPageInfo1.Location = new System.Drawing.Point(550, 0);
			this.xrPageInfo1.Name = "xrPageInfo1";
			this.xrPageInfo1.Size = new System.Drawing.Size(100, 25);
			// 
			// PageHeader
			// 
			this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																							this.xrLabel22,
																							this.xrLabel21,
																							this.xrLabel20,
																							this.xrLabel19,
																							this.xrLabel18,
																							this.xrLabel17,
																							this.xrLabel16,
																							this.xrLabel15,
																							this.xrLabel14,
																							this.xrLabel13,
																							this.xrLabel12,
																							this.xrLabel11});
			this.PageHeader.Height = 169;
			this.PageHeader.Name = "PageHeader";
			// 
			// xrLabel22
			// 
			this.xrLabel22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "Memo.nMemoID", "")});
			this.xrLabel22.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
			this.xrLabel22.Location = new System.Drawing.Point(325, 8);
			this.xrLabel22.Name = "xrLabel22";
			this.xrLabel22.ParentStyleUsing.UseFont = false;
			this.xrLabel22.Size = new System.Drawing.Size(142, 25);
			this.xrLabel22.Text = "xrLabel22";
			// 
			// xrLabel21
			// 
			this.xrLabel21.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
			this.xrLabel21.Location = new System.Drawing.Point(225, 8);
			this.xrLabel21.Name = "xrLabel21";
			this.xrLabel21.ParentStyleUsing.UseFont = false;
			this.xrLabel21.Size = new System.Drawing.Size(100, 25);
			this.xrLabel21.Text = "Mail ID:";
			// 
			// xrLabel20
			// 
			this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel20.Location = new System.Drawing.Point(8, 100);
			this.xrLabel20.Name = "xrLabel20";
			this.xrLabel20.ParentStyleUsing.UseFont = false;
			this.xrLabel20.Size = new System.Drawing.Size(50, 17);
			this.xrLabel20.Text = "Title:";
			// 
			// xrLabel19
			// 
			this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel19.Location = new System.Drawing.Point(8, 75);
			this.xrLabel19.Name = "xrLabel19";
			this.xrLabel19.ParentStyleUsing.UseFont = false;
			this.xrLabel19.Size = new System.Drawing.Size(50, 17);
			this.xrLabel19.Text = "Status:";
			// 
			// xrLabel18
			// 
			this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel18.Location = new System.Drawing.Point(8, 125);
			this.xrLabel18.Name = "xrLabel18";
			this.xrLabel18.ParentStyleUsing.UseFont = false;
			this.xrLabel18.Size = new System.Drawing.Size(67, 17);
			this.xrLabel18.Text = "Message:";
			// 
			// xrLabel17
			// 
			this.xrLabel17.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel17.Location = new System.Drawing.Point(217, 50);
			this.xrLabel17.Name = "xrLabel17";
			this.xrLabel17.ParentStyleUsing.UseFont = false;
			this.xrLabel17.Size = new System.Drawing.Size(108, 17);
			this.xrLabel17.Text = "Employee Name:";
			// 
			// xrLabel16
			// 
			this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel16.Location = new System.Drawing.Point(8, 50);
			this.xrLabel16.Name = "xrLabel16";
			this.xrLabel16.ParentStyleUsing.UseFont = false;
			this.xrLabel16.Size = new System.Drawing.Size(42, 17);
			this.xrLabel16.Text = "Date:";
			// 
			// xrLabel15
			// 
			this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "Memo.strMessage", "")});
			this.xrLabel15.Location = new System.Drawing.Point(8, 142);
			this.xrLabel15.Name = "xrLabel15";
			this.xrLabel15.Size = new System.Drawing.Size(642, 25);
			this.xrLabel15.Text = "xrLabel15";
			// 
			// xrLabel14
			// 
			this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "Memo.strStatus", "")});
			this.xrLabel14.Location = new System.Drawing.Point(58, 75);
			this.xrLabel14.Name = "xrLabel14";
			this.xrLabel14.Size = new System.Drawing.Size(117, 25);
			this.xrLabel14.Text = "xrLabel14";
			// 
			// xrLabel13
			// 
			this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "Memo.strTitle", "")});
			this.xrLabel13.Location = new System.Drawing.Point(58, 100);
			this.xrLabel13.Name = "xrLabel13";
			this.xrLabel13.Size = new System.Drawing.Size(592, 25);
			this.xrLabel13.Text = "xrLabel13";
			// 
			// xrLabel12
			// 
			this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "Memo.strEmployeeName", "")});
			this.xrLabel12.Location = new System.Drawing.Point(325, 50);
			this.xrLabel12.Name = "xrLabel12";
			this.xrLabel12.Size = new System.Drawing.Size(325, 25);
			this.xrLabel12.Text = "xrLabel12";
			// 
			// xrLabel11
			// 
			this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "Memo.dtDate", "")});
			this.xrLabel11.Location = new System.Drawing.Point(58, 50);
			this.xrLabel11.Name = "xrLabel11";
			this.xrLabel11.Size = new System.Drawing.Size(159, 25);
			this.xrLabel11.Text = "xrLabel11";
			// 
			// ReportMemo
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
																		 this.detailBand1,
																		 this.DetailReport1,
																		 this.DetailReport,
																		 this.BottomMargin,
																		 this.PageHeader});
			this.Margins = new System.Drawing.Printing.Margins(100, 100, 100, 27);
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion
	}
}

