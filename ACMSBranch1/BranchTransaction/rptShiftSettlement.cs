using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ACMS.ACMSBranch.BranchTransaction
{
	/// <summary>
	/// Summary description for rptShiftSettlement.
	/// </summary>
	public class rptShiftSettlement : DevExpress.XtraReports.UI.XtraReport
	{
		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
		private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
		private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
		private DevExpress.XtraReports.UI.XRLabel xrLabel7;
		private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
		private DevExpress.XtraReports.UI.XRLine xrLine1;
		private DevExpress.XtraReports.UI.XRLine xrLine2;
		private DevExpress.XtraReports.UI.XRLabel xrLabel5;
		private DevExpress.XtraReports.UI.XRLabel xrLabel3;
		public DevExpress.XtraReports.UI.XRLabel fPaymentMode;
		public DevExpress.XtraReports.UI.XRLabel fAmount;
		public DevExpress.XtraReports.UI.XRLabel fBranch;
		public DevExpress.XtraReports.UI.XRLabel fTitle;
		public DevExpress.XtraReports.UI.XRLabel fDate;
		public DevExpress.XtraReports.UI.XRLabel fVerifyStaff;
		private DevExpress.XtraReports.UI.XRLabel xrLabel1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel2;
		private DevExpress.XtraReports.UI.XRLabel xrLabel4;
		public DevExpress.XtraReports.UI.XRLabel fMWBalance;
		public DevExpress.XtraReports.UI.XRLabel fLCKBalance;
		public DevExpress.XtraReports.UI.XRLabel xrLabel6;
		public DevExpress.XtraReports.UI.XRLabel fClosingStaff;
		public DevExpress.XtraReports.UI.XRLabel fTime;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptShiftSettlement()
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
			DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
			DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
			DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
			DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
			this.Detail = new DevExpress.XtraReports.UI.DetailBand();
			this.fAmount = new DevExpress.XtraReports.UI.XRLabel();
			this.fPaymentMode = new DevExpress.XtraReports.UI.XRLabel();
			this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
			this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
			this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
			this.fTime = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
			this.fTitle = new DevExpress.XtraReports.UI.XRLabel();
			this.fDate = new DevExpress.XtraReports.UI.XRLabel();
			this.fBranch = new DevExpress.XtraReports.UI.XRLabel();
			this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
			this.fClosingStaff = new DevExpress.XtraReports.UI.XRLabel();
			this.fLCKBalance = new DevExpress.XtraReports.UI.XRLabel();
			this.fMWBalance = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
			this.fVerifyStaff = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
			this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																						this.fAmount,
																						this.fPaymentMode});
			this.Detail.Height = 20;
			this.Detail.Name = "Detail";
			// 
			// fAmount
			// 
			this.fAmount.Font = new System.Drawing.Font("Arial", 8F);
			this.fAmount.Location = new System.Drawing.Point(197, 0);
			this.fAmount.Name = "fAmount";
			this.fAmount.ParentStyleUsing.UseFont = false;
			this.fAmount.Size = new System.Drawing.Size(83, 17);
			xrSummary1.FormatString = "{0:$0.00}";
			this.fAmount.Summary = xrSummary1;
			this.fAmount.Text = "xrLabel1";
			this.fAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
			// 
			// fPaymentMode
			// 
			this.fPaymentMode.Font = new System.Drawing.Font("Arial", 8F);
			this.fPaymentMode.Location = new System.Drawing.Point(22, 0);
			this.fPaymentMode.Name = "fPaymentMode";
			this.fPaymentMode.ParentStyleUsing.UseFont = false;
			this.fPaymentMode.Size = new System.Drawing.Size(175, 17);
			this.fPaymentMode.Text = "fPaymentMode";
			// 
			// PageHeader
			// 
			this.PageHeader.Height = 0;
			this.PageHeader.Name = "PageHeader";
			// 
			// PageFooter
			// 
			this.PageFooter.Height = 0;
			this.PageFooter.Name = "PageFooter";
			// 
			// ReportHeader
			// 
			this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																							  this.fTime,
																							  this.xrLabel6,
																							  this.xrLabel1,
																							  this.xrLabel7,
																							  this.fTitle,
																							  this.fDate,
																							  this.fBranch});
			this.ReportHeader.Height = 77;
			this.ReportHeader.Name = "ReportHeader";
			this.ReportHeader.ParentStyleUsing.UseFont = false;
			// 
			// fTime
			// 
			this.fTime.Font = new System.Drawing.Font("Arial", 8F);
			this.fTime.Location = new System.Drawing.Point(181, 42);
			this.fTime.Name = "fTime";
			this.fTime.ParentStyleUsing.UseFont = false;
			this.fTime.Size = new System.Drawing.Size(61, 17);
			xrSummary2.FormatString = "{0:hh:mm tt}";
			this.fTime.Summary = xrSummary2;
			this.fTime.Text = "09:00 AM";
			// 
			// xrLabel6
			// 
			this.xrLabel6.Font = new System.Drawing.Font("Arial", 8F);
			this.xrLabel6.Location = new System.Drawing.Point(11, 25);
			this.xrLabel6.Name = "xrLabel6";
			this.xrLabel6.ParentStyleUsing.UseFont = false;
			this.xrLabel6.Size = new System.Drawing.Size(234, 17);
			this.xrLabel6.Text = "SHIFT SETTLEMENT REPORT";
			// 
			// xrLabel1
			// 
			this.xrLabel1.Font = new System.Drawing.Font("Arial", 8F);
			this.xrLabel1.Location = new System.Drawing.Point(138, 42);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.ParentStyleUsing.UseFont = false;
			this.xrLabel1.Size = new System.Drawing.Size(42, 17);
			this.xrLabel1.Text = "TIME:";
			// 
			// xrLabel7
			// 
			this.xrLabel7.Font = new System.Drawing.Font("Arial", 8F);
			this.xrLabel7.Location = new System.Drawing.Point(11, 42);
			this.xrLabel7.Name = "xrLabel7";
			this.xrLabel7.ParentStyleUsing.UseFont = false;
			this.xrLabel7.Size = new System.Drawing.Size(42, 17);
			this.xrLabel7.Text = "DATE :";
			// 
			// fTitle
			// 
			this.fTitle.Font = new System.Drawing.Font("Arial", 8F);
			this.fTitle.Location = new System.Drawing.Point(11, 58);
			this.fTitle.Name = "fTitle";
			this.fTitle.ParentStyleUsing.UseFont = false;
			this.fTitle.Size = new System.Drawing.Size(234, 17);
			this.fTitle.Text = "SHIFT 1. T1 REPORT";
			// 
			// fDate
			// 
			this.fDate.Font = new System.Drawing.Font("Arial", 8F);
			this.fDate.Location = new System.Drawing.Point(54, 42);
			this.fDate.Name = "fDate";
			this.fDate.ParentStyleUsing.UseFont = false;
			this.fDate.Size = new System.Drawing.Size(83, 17);
			xrSummary3.FormatString = "{0:dd/MM/yyyy}";
			this.fDate.Summary = xrSummary3;
			this.fDate.Text = "11/02/2006";
			// 
			// fBranch
			// 
			this.fBranch.Font = new System.Drawing.Font("Arial", 8F);
			this.fBranch.Location = new System.Drawing.Point(12, 8);
			this.fBranch.Name = "fBranch";
			this.fBranch.ParentStyleUsing.UseFont = false;
			this.fBranch.Size = new System.Drawing.Size(234, 17);
			this.fBranch.Text = "AMORE FITNESS BRANCH HQ";
			// 
			// ReportFooter
			// 
			this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																							  this.fClosingStaff,
																							  this.fLCKBalance,
																							  this.fMWBalance,
																							  this.xrLabel4,
																							  this.xrLabel2,
																							  this.xrLabel3,
																							  this.xrLabel5,
																							  this.fVerifyStaff,
																							  this.xrLine2,
																							  this.xrLine1});
			this.ReportFooter.Height = 229;
			this.ReportFooter.Name = "ReportFooter";
			// 
			// fClosingStaff
			// 
			this.fClosingStaff.Font = new System.Drawing.Font("Arial", 8F);
			this.fClosingStaff.Location = new System.Drawing.Point(14, 125);
			this.fClosingStaff.Name = "fClosingStaff";
			this.fClosingStaff.ParentStyleUsing.UseFont = false;
			this.fClosingStaff.Size = new System.Drawing.Size(275, 17);
			this.fClosingStaff.Text = "xxxxxx";
			// 
			// fLCKBalance
			// 
			this.fLCKBalance.Font = new System.Drawing.Font("Arial", 8F);
			this.fLCKBalance.Location = new System.Drawing.Point(197, 25);
			this.fLCKBalance.Name = "fLCKBalance";
			this.fLCKBalance.ParentStyleUsing.UseFont = false;
			this.fLCKBalance.Size = new System.Drawing.Size(58, 17);
			xrSummary4.FormatString = "{0:$0.00}";
			this.fLCKBalance.Summary = xrSummary4;
			this.fLCKBalance.Text = "0";
			this.fLCKBalance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
			// 
			// fMWBalance
			// 
			this.fMWBalance.Font = new System.Drawing.Font("Arial", 8F);
			this.fMWBalance.Location = new System.Drawing.Point(197, 8);
			this.fMWBalance.Name = "fMWBalance";
			this.fMWBalance.ParentStyleUsing.UseFont = false;
			this.fMWBalance.Size = new System.Drawing.Size(58, 17);
			xrSummary5.FormatString = "{0:$0.00}";
			this.fMWBalance.Summary = xrSummary5;
			this.fMWBalance.Text = "0";
			this.fMWBalance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
			// 
			// xrLabel4
			// 
			this.xrLabel4.Font = new System.Drawing.Font("Arial", 8F);
			this.xrLabel4.Location = new System.Drawing.Point(14, 25);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.ParentStyleUsing.UseFont = false;
			this.xrLabel4.Size = new System.Drawing.Size(184, 17);
			this.xrLabel4.Text = "BALANCE OF LOCKER";
			// 
			// xrLabel2
			// 
			this.xrLabel2.Font = new System.Drawing.Font("Arial", 8F);
			this.xrLabel2.Location = new System.Drawing.Point(14, 8);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.ParentStyleUsing.UseFont = false;
			this.xrLabel2.Size = new System.Drawing.Size(184, 17);
			this.xrLabel2.Text = "BALANCE OF MINERAL WATER";
			// 
			// xrLabel3
			// 
			this.xrLabel3.Font = new System.Drawing.Font("Arial", 8F);
			this.xrLabel3.Location = new System.Drawing.Point(14, 108);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.ParentStyleUsing.UseFont = false;
			this.xrLabel3.Size = new System.Drawing.Size(175, 17);
			this.xrLabel3.Text = "MONEY DEPOSITED BY";
			// 
			// xrLabel5
			// 
			this.xrLabel5.Font = new System.Drawing.Font("Arial", 8F);
			this.xrLabel5.Location = new System.Drawing.Point(14, 192);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.ParentStyleUsing.UseFont = false;
			this.xrLabel5.Size = new System.Drawing.Size(175, 17);
			this.xrLabel5.Text = "VERIFIED BY";
			// 
			// fVerifyStaff
			// 
			this.fVerifyStaff.Font = new System.Drawing.Font("Arial", 8F);
			this.fVerifyStaff.Location = new System.Drawing.Point(14, 208);
			this.fVerifyStaff.Name = "fVerifyStaff";
			this.fVerifyStaff.ParentStyleUsing.UseFont = false;
			this.fVerifyStaff.Size = new System.Drawing.Size(275, 17);
			this.fVerifyStaff.Text = "XXX";
			// 
			// xrLine2
			// 
			this.xrLine2.Location = new System.Drawing.Point(14, 183);
			this.xrLine2.Name = "xrLine2";
			this.xrLine2.Size = new System.Drawing.Size(175, 8);
			// 
			// xrLine1
			// 
			this.xrLine1.Location = new System.Drawing.Point(14, 92);
			this.xrLine1.Name = "xrLine1";
			this.xrLine1.Size = new System.Drawing.Size(175, 8);
			// 
			// rptShiftSettlement
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
																		 this.Detail,
																		 this.PageHeader,
																		 this.PageFooter,
																		 this.ReportHeader,
																		 this.ReportFooter});
			this.Margins = new System.Drawing.Printing.Margins(0, 10, 10, 10);
			this.PageHeight = 1169;
			this.PageWidth = 310;
			this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		private void Load()
		{
			
		}
		#endregion
	}
}

