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
        public XRLabel fTotTrans;
        private XRLabel xrLabel8;
        public XRLabel fFreebieQty;
        public XRLabel fFreebie;
        public XRLabel fTotDisc;
        private XRLabel xrLabel14;
        public XRLabel fNoVoid;
        private XRLabel xrLabel12;
        public XRLabel fVoidAmt;
        private XRLabel xrLabel10;
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
            DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary9 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary10 = new DevExpress.XtraReports.UI.XRSummary();
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
            this.fFreebieQty = new DevExpress.XtraReports.UI.XRLabel();
            this.fFreebie = new DevExpress.XtraReports.UI.XRLabel();
            this.fTotDisc = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.fNoVoid = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.fVoidAmt = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.fTotTrans = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
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
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // fAmount
            // 
            this.fAmount.Font = new System.Drawing.Font("Arial", 8F);
            this.fAmount.Location = new System.Drawing.Point(197, 0);
            this.fAmount.Name = "fAmount";
            this.fAmount.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fAmount.Size = new System.Drawing.Size(77, 17);
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
            this.fPaymentMode.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fPaymentMode.Size = new System.Drawing.Size(175, 17);
            this.fPaymentMode.Text = "fPaymentMode";
            this.fPaymentMode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Height = 0;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.ReportHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.ReportHeader.Height = 77;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // fTime
            // 
            this.fTime.Font = new System.Drawing.Font("Arial", 8F);
            this.fTime.Location = new System.Drawing.Point(183, 42);
            this.fTime.Name = "fTime";
            this.fTime.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fTime.Size = new System.Drawing.Size(61, 17);
            xrSummary2.FormatString = "{0:hh:mm tt}";
            this.fTime.Summary = xrSummary2;
            this.fTime.Text = "09:00 AM";
            this.fTime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel6.Location = new System.Drawing.Point(15, 27);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.Size = new System.Drawing.Size(234, 17);
            this.xrLabel6.Text = "SHIFT SETTLEMENT REPORT";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel1.Location = new System.Drawing.Point(140, 42);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.Size = new System.Drawing.Size(42, 17);
            this.xrLabel1.Text = "TIME:";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel7.Location = new System.Drawing.Point(15, 42);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.Size = new System.Drawing.Size(42, 17);
            this.xrLabel7.Text = "DATE :";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // fTitle
            // 
            this.fTitle.Font = new System.Drawing.Font("Arial", 8F);
            this.fTitle.Location = new System.Drawing.Point(15, 58);
            this.fTitle.Name = "fTitle";
            this.fTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fTitle.Size = new System.Drawing.Size(234, 17);
            this.fTitle.Text = "SHIFT 1. T1 REPORT";
            this.fTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // fDate
            // 
            this.fDate.Font = new System.Drawing.Font("Arial", 8F);
            this.fDate.Location = new System.Drawing.Point(56, 42);
            this.fDate.Name = "fDate";
            this.fDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fDate.Size = new System.Drawing.Size(83, 17);
            xrSummary3.FormatString = "{0:dd/MM/yyyy}";
            this.fDate.Summary = xrSummary3;
            this.fDate.Text = "11/02/2006";
            this.fDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // fBranch
            // 
            this.fBranch.Font = new System.Drawing.Font("Arial", 8F);
            this.fBranch.Location = new System.Drawing.Point(15, 8);
            this.fBranch.Name = "fBranch";
            this.fBranch.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fBranch.Size = new System.Drawing.Size(232, 17);
            this.fBranch.Text = "AMORE FITNESS BRANCH HQ";
            this.fBranch.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.fFreebieQty,
            this.fFreebie,
            this.fTotDisc,
            this.xrLabel14,
            this.fNoVoid,
            this.xrLabel12,
            this.fVoidAmt,
            this.xrLabel10,
            this.fTotTrans,
            this.xrLabel8,
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
            this.ReportFooter.Height = 359;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // fFreebieQty
            // 
            this.fFreebieQty.Font = new System.Drawing.Font("Arial", 8F);
            this.fFreebieQty.Location = new System.Drawing.Point(218, 125);
            this.fFreebieQty.Multiline = true;
            this.fFreebieQty.Name = "fFreebieQty";
            this.fFreebieQty.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fFreebieQty.Size = new System.Drawing.Size(55, 17);
            xrSummary4.FormatString = "{0:$0.00}";
            this.fFreebieQty.Summary = xrSummary4;
            this.fFreebieQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // fFreebie
            // 
            this.fFreebie.Font = new System.Drawing.Font("Arial", 8F);
            this.fFreebie.Location = new System.Drawing.Point(26, 125);
            this.fFreebie.Multiline = true;
            this.fFreebie.Name = "fFreebie";
            this.fFreebie.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fFreebie.Size = new System.Drawing.Size(192, 17);
            this.fFreebie.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // fTotDisc
            // 
            this.fTotDisc.Font = new System.Drawing.Font("Arial", 8F);
            this.fTotDisc.Location = new System.Drawing.Point(197, 100);
            this.fTotDisc.Name = "fTotDisc";
            this.fTotDisc.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fTotDisc.Size = new System.Drawing.Size(77, 17);
            xrSummary5.FormatString = "{0:$0.00}";
            this.fTotDisc.Summary = xrSummary5;
            this.fTotDisc.Text = "0";
            this.fTotDisc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel14.Location = new System.Drawing.Point(22, 100);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.Size = new System.Drawing.Size(175, 17);
            this.xrLabel14.Text = "TOTAL DISCOUNT GIVEN";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // fNoVoid
            // 
            this.fNoVoid.Font = new System.Drawing.Font("Arial", 8F);
            this.fNoVoid.Location = new System.Drawing.Point(197, 83);
            this.fNoVoid.Name = "fNoVoid";
            this.fNoVoid.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fNoVoid.Size = new System.Drawing.Size(77, 17);
            xrSummary6.FormatString = "{0:$0.00}";
            this.fNoVoid.Summary = xrSummary6;
            this.fNoVoid.Text = "0";
            this.fNoVoid.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel12.Location = new System.Drawing.Point(22, 83);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.Size = new System.Drawing.Size(175, 17);
            this.xrLabel12.Text = "NO. OF RECEIPT VOID";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // fVoidAmt
            // 
            this.fVoidAmt.Font = new System.Drawing.Font("Arial", 8F);
            this.fVoidAmt.Location = new System.Drawing.Point(197, 67);
            this.fVoidAmt.Name = "fVoidAmt";
            this.fVoidAmt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fVoidAmt.Size = new System.Drawing.Size(77, 17);
            xrSummary7.FormatString = "{0:$0.00}";
            this.fVoidAmt.Summary = xrSummary7;
            this.fVoidAmt.Text = "0";
            this.fVoidAmt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel10.Location = new System.Drawing.Point(22, 67);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.Size = new System.Drawing.Size(175, 17);
            this.xrLabel10.Text = "VOID AMOUNT";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // fTotTrans
            // 
            this.fTotTrans.Font = new System.Drawing.Font("Arial", 8F);
            this.fTotTrans.Location = new System.Drawing.Point(197, 50);
            this.fTotTrans.Name = "fTotTrans";
            this.fTotTrans.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fTotTrans.Size = new System.Drawing.Size(77, 17);
            xrSummary8.FormatString = "{0:$0.00}";
            this.fTotTrans.Summary = xrSummary8;
            this.fTotTrans.Text = "0";
            this.fTotTrans.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel8.Location = new System.Drawing.Point(22, 50);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.Size = new System.Drawing.Size(175, 17);
            this.xrLabel8.Text = "TOTAL TRANSACTION";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // fClosingStaff
            // 
            this.fClosingStaff.Font = new System.Drawing.Font("Arial", 8F);
            this.fClosingStaff.Location = new System.Drawing.Point(17, 242);
            this.fClosingStaff.Name = "fClosingStaff";
            this.fClosingStaff.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fClosingStaff.Size = new System.Drawing.Size(275, 17);
            this.fClosingStaff.Text = "xxxxxx";
            this.fClosingStaff.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // fLCKBalance
            // 
            this.fLCKBalance.Font = new System.Drawing.Font("Arial", 8F);
            this.fLCKBalance.Location = new System.Drawing.Point(197, 25);
            this.fLCKBalance.Name = "fLCKBalance";
            this.fLCKBalance.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fLCKBalance.Size = new System.Drawing.Size(77, 17);
            xrSummary9.FormatString = "{0:$0.00}";
            this.fLCKBalance.Summary = xrSummary9;
            this.fLCKBalance.Text = "0";
            this.fLCKBalance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // fMWBalance
            // 
            this.fMWBalance.Font = new System.Drawing.Font("Arial", 8F);
            this.fMWBalance.Location = new System.Drawing.Point(197, 8);
            this.fMWBalance.Name = "fMWBalance";
            this.fMWBalance.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fMWBalance.Size = new System.Drawing.Size(77, 17);
            xrSummary10.FormatString = "{0:$0.00}";
            this.fMWBalance.Summary = xrSummary10;
            this.fMWBalance.Text = "0";
            this.fMWBalance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel4.Location = new System.Drawing.Point(22, 25);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.Size = new System.Drawing.Size(175, 17);
            this.xrLabel4.Text = "BALANCE OF LOCKER";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel2.Location = new System.Drawing.Point(22, 8);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.Size = new System.Drawing.Size(175, 17);
            this.xrLabel2.Text = "BALANCE OF MINERAL WATER";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel3.Location = new System.Drawing.Point(17, 225);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.Size = new System.Drawing.Size(175, 17);
            this.xrLabel3.Text = "MONEY DEPOSITED BY";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel5.Location = new System.Drawing.Point(17, 308);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.Size = new System.Drawing.Size(175, 17);
            this.xrLabel5.Text = "VERIFIED BY";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // fVerifyStaff
            // 
            this.fVerifyStaff.Font = new System.Drawing.Font("Arial", 8F);
            this.fVerifyStaff.Location = new System.Drawing.Point(17, 325);
            this.fVerifyStaff.Name = "fVerifyStaff";
            this.fVerifyStaff.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fVerifyStaff.Size = new System.Drawing.Size(275, 17);
            this.fVerifyStaff.Text = "XXX";
            this.fVerifyStaff.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLine2
            // 
            this.xrLine2.Location = new System.Drawing.Point(17, 300);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLine2.Size = new System.Drawing.Size(175, 8);
            // 
            // xrLine1
            // 
            this.xrLine1.Location = new System.Drawing.Point(17, 208);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
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
            this.Version = "8.3";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		private void Load()
		{
			
		}
		#endregion
	}
}

