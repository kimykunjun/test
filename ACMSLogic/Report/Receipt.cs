using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;
using System.Reflection;

using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.IO;
using ACMSDAL;
using ACMSLogic;
using ACMS.Utils;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Threading; 

namespace ACMSLogic.Report
{
	/// <summary>
	/// Summary description for Receipt.
	/// </summary>
	public class Receipt : DevExpress.XtraReports.UI.XtraReport
    {
        private DetailBand Detail;
        private XRLabel xrLabel29;
        private XRLabel xrLabel28;
        private XRLabel xrLabel1;
        private DetailReportBand DetailReport1;
        private DetailBand Detail1;
        private XRLabel xrLabel43;
        private XRLabel xrLabel16;
        private XRLabel xrLabel15;
  
        private GroupHeaderBand ppGroupHeaderBand1;
        private XRLabel xrLabel21;
        private XRLine xrLine2;
        private XRLabel xrLabel25;
        private XRLabel xrLabel10;
        private DetailBand ppDetailBand1;
        private XRLabel xrLabel14;
        private XRPanel xrPanel1;
        private XRLabel xrLabel17;
        private XRLabel xrLabel42;
        private XRLabel xrLabel44;
        private XRLabel xrLabel13;
        private XRLabel xrLabel11;
        private XRLabel xrLabel4;
        private ReportFooterBand ReportFooter;
        private XRLabel xrLabel22;
        private XRLabel xrLabel41;
        private XRLabel xrLabel12;
        private XRLine xrLine3;
        private XRLabel xrLabel30;
        private XRLabel xrLabel27;
        private XRLabel xrLabel26;
        private XRLabel xrLabel24;
        private XRLabel xrLabel23;
        private XRLabel xrLabel20;
        private XRLabel xrLabel18;
        private XRLabel xrLabel19;
        private DetailReportBand DetailReport;
        private ReportFooterBand ReportFooter1;
        private XRLabel xrLabel7;
        private XRLabel xrLabel6;
        private XRLabel xrLabel31;
        private DetailBand Detail3;
        private XRLabel xrLabel45;
        private XRLabel xrLabel46;
        private DetailBand DetailBand1;
        private XRLine xrLine1;
        private XRLabel xrLabel9;
        private XRLabel xrLabel33;
        private XRLabel xrLabel3;
        private XRLabel xrLabel39;
        private XRLabel xrLabel37;
        private XRLabel xrLabel32;
        private XRLabel xrLabel2;
        private DetailReportBand DetailReport3;
        private ReportHeaderBand HeaderBand1;
        private XRLabel xrLabel8;
        private XRLabel xrLabel38;
        private XRLabel xrLabel34;
        private XRLabel xrLabel5;
        private XRLabel xrLabelstrMemberName;
        private XRLabel xrLabelMembershipID;
        private DetailReportBand ppChildReport1;
        private XRLabel xrLabel49;
        private XRLabel xrLabel48;
        private XRLabel xrVoidDetail;
        private XRPictureBox xrPictureBox1;
        private DetailReportBand DetailReport2;
        private DetailBand Detail2;
        private XRLabel xrLabel54;
        private XRLabel xrLabel55;
        private XRLabel xrLabel56;
        private ReportHeaderBand ReportHeader;
        private XRLabel xrLabel53;
        private XRLabel xrLabel52;
        private XRLabel xrLabel51;
        private XRLabel xrLabel50;
        private XRLine xrLine5;
        private DetailReportBand DetailReport4;
        private DetailBand Detail4;
        private ReportFooterBand ReportFooter3;
        private XRLabel xrLabel35;
        private XRLabel xrLabel36;
        private XRLine xrLine4;
        private XRLabel xrLabel40;
        private XRLabel xrLabel47;
        private XRLabel xrLabel57;
        private XRLabel xrLabel58;
        //private XtraReportSerialization.dataSet1 dataSet1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Receipt()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Receipt));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.DetailReport1 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel43 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.ppGroupHeaderBand1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.ppDetailBand1 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel42 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel44 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel58 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel57 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.ReportFooter1 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrVoidDetail = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel49 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel48 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.Detail3 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel45 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
            this.DetailBand1 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.DetailReport3 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.HeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelstrMemberName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelMembershipID = new DevExpress.XtraReports.UI.XRLabel();
            this.ppChildReport1 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.DetailReport2 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail2 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel56 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel55 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel54 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel53 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel52 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel51 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel50 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.DetailReport4 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail4 = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportFooter3 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel47 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel29,
            this.xrLabel28});
            this.Detail.Font = new System.Drawing.Font("Arial", 8.5F);
            this.Detail.Height = 18;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel29
            // 
            this.xrLabel29.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.Receipt_ReceiptPayment_Relation.mAmount", "{0:$0.00}")});
            this.xrLabel29.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel29.Location = new System.Drawing.Point(208, 0);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.Size = new System.Drawing.Size(92, 17);
            this.xrLabel29.Text = "xrLabel29";
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel28
            // 
            this.xrLabel28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.Receipt_ReceiptPayment_Relation.strPaymentCode", "")});
            this.xrLabel28.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel28.Location = new System.Drawing.Point(25, 0);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.Size = new System.Drawing.Size(158, 17);
            this.xrLabel28.Text = "xrLabel28";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel1.Location = new System.Drawing.Point(27, 127);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.Size = new System.Drawing.Size(92, 17);
            this.xrLabel1.Text = "Membership ID:";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // DetailReport1
            // 
            this.DetailReport1.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1});
            this.DetailReport1.DataMember = "TblReceipt.Receipt_ReceiptFreebie_Relation";
            this.DetailReport1.Level = 2;
            this.DetailReport1.Name = "DetailReport1";
            this.DetailReport1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.DetailReport1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Detail1
            // 
            this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel43,
            this.xrLabel16,
            this.xrLabel15});
            this.Detail1.Height = 25;
            this.Detail1.Name = "Detail1";
            this.Detail1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel43
            // 
            this.xrLabel43.Location = new System.Drawing.Point(25, 0);
            this.xrLabel43.Name = "xrLabel43";
            this.xrLabel43.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel43.Size = new System.Drawing.Size(83, 25);
            this.xrLabel43.Text = "Free Product :";
            this.xrLabel43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel16
            // 
            this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.Receipt_ReceiptFreebie_Relation.strDescription", "")});
            this.xrLabel16.Location = new System.Drawing.Point(108, 0);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.Size = new System.Drawing.Size(283, 25);
            this.xrLabel16.Text = "xrLabel16";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel15
            // 
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.Receipt_ReceiptFreebie_Relation.strItemCode", "")});
            this.xrLabel15.Location = new System.Drawing.Point(392, 0);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.Size = new System.Drawing.Size(100, 25);
            this.xrLabel15.Text = "xrLabel15";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrLabel15.Visible = false;
            // 
            // ppGroupHeaderBand1
            // 
            this.ppGroupHeaderBand1.Font = new System.Drawing.Font("Arial", 8.5F);
            this.ppGroupHeaderBand1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("strReceiptNo", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.ppGroupHeaderBand1.Height = 0;
            this.ppGroupHeaderBand1.Name = "ppGroupHeaderBand1";
            this.ppGroupHeaderBand1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ppGroupHeaderBand1.RepeatEveryPage = true;
            this.ppGroupHeaderBand1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel21
            // 
            this.xrLabel21.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel21.Location = new System.Drawing.Point(25, 92);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.Size = new System.Drawing.Size(92, 17);
            this.xrLabel21.Text = "Total Payable:";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLine2
            // 
            this.xrLine2.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrLine2.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.xrLine2.Location = new System.Drawing.Point(8, 117);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLine2.Size = new System.Drawing.Size(334, 8);
            // 
            // xrLabel25
            // 
            this.xrLabel25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.mNettAmount", "{0:$0.00}")});
            this.xrLabel25.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel25.Location = new System.Drawing.Point(208, 58);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.Size = new System.Drawing.Size(100, 14);
            this.xrLabel25.Text = "xrLabel25";
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel10
            // 
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.Receipt_ReceiptEntries_Relation.nQuantity", "")});
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel10.Location = new System.Drawing.Point(25, 0);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.Size = new System.Drawing.Size(17, 17);
            this.xrLabel10.Text = "xrLabel10";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ppDetailBand1
            // 
            this.ppDetailBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel14,
            this.xrPanel1,
            this.xrLabel13,
            this.xrLabel11,
            this.xrLabel10});
            this.ppDetailBand1.Font = new System.Drawing.Font("Arial", 8.5F);
            this.ppDetailBand1.Height = 47;
            this.ppDetailBand1.Name = "ppDetailBand1";
            this.ppDetailBand1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ppDetailBand1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel14
            // 
            this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.Receipt_ReceiptEntries_Relation.strFreebieCode", "")});
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel14.Location = new System.Drawing.Point(208, 33);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.Size = new System.Drawing.Size(117, 14);
            this.xrLabel14.Text = "xrLabel14";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPanel1
            // 
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel17,
            this.xrLabel42,
            this.xrLabel44});
            this.xrPanel1.Location = new System.Drawing.Point(192, 17);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrPanel1.Size = new System.Drawing.Size(141, 16);
            // 
            // xrLabel17
            // 
            this.xrLabel17.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.xrLabel17.Location = new System.Drawing.Point(58, 0);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.Size = new System.Drawing.Size(8, 25);
            this.xrLabel17.Text = ")";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel42
            // 
            this.xrLabel42.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.xrLabel42.Location = new System.Drawing.Point(0, 0);
            this.xrLabel42.Name = "xrLabel42";
            this.xrLabel42.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel42.Size = new System.Drawing.Size(16, 25);
            this.xrLabel42.Text = "($";
            this.xrLabel42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel44
            // 
            this.xrLabel44.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.Receipt_ReceiptEntries_Relation.DiscountAmt", "")});
            this.xrLabel44.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel44.Location = new System.Drawing.Point(17, 0);
            this.xrLabel44.Name = "xrLabel44";
            this.xrLabel44.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel44.Size = new System.Drawing.Size(41, 16);
            this.xrLabel44.Text = "ItemdiscountAmt";
            this.xrLabel44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel13
            // 
            this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.Receipt_ReceiptEntries_Relation.mUnitPrice", "{0:$0.00}")});
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel13.Location = new System.Drawing.Point(208, 0);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.Size = new System.Drawing.Size(116, 15);
            this.xrLabel13.Text = "xrLabel13";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.Receipt_ReceiptEntries_Relation.strDescription", "")});
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel11.Location = new System.Drawing.Point(42, 0);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.Size = new System.Drawing.Size(141, 19);
            this.xrLabel11.Text = "xrLabel11";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel4.Location = new System.Drawing.Point(27, 160);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.Size = new System.Drawing.Size(83, 17);
            this.xrLabel4.Text = "Cashier ID:";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel58,
            this.xrLabel57,
            this.xrLabel22,
            this.xrLabel41,
            this.xrLabel12,
            this.xrLine3,
            this.xrLine2,
            this.xrLabel30,
            this.xrLabel27,
            this.xrLabel26,
            this.xrLabel25,
            this.xrLabel24,
            this.xrLabel23,
            this.xrLabel21,
            this.xrLabel20,
            this.xrLabel18,
            this.xrLabel19});
            this.ReportFooter.Font = new System.Drawing.Font("Arial", 8.5F);
            this.ReportFooter.Height = 142;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel58
            // 
            this.xrLabel58.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.Receipt_Deposit_Relation.TotalDeposit", "{0:$0.00}")});
            this.xrLabel58.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel58.Location = new System.Drawing.Point(208, 25);
            this.xrLabel58.Name = "xrLabel58";
            this.xrLabel58.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel58.Size = new System.Drawing.Size(100, 16);
            this.xrLabel58.Text = "xrLabel24";
            this.xrLabel58.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel57
            // 
            this.xrLabel57.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel57.Location = new System.Drawing.Point(25, 25);
            this.xrLabel57.Name = "xrLabel57";
            this.xrLabel57.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel57.Size = new System.Drawing.Size(83, 17);
            this.xrLabel57.Text = "Deposit :";
            this.xrLabel57.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel22
            // 
            this.xrLabel22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.mSubTotal", "{0:$0.00}")});
            this.xrLabel22.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel22.Location = new System.Drawing.Point(208, 8);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.Size = new System.Drawing.Size(116, 17);
            this.xrLabel22.Text = "xrLabel22";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel41
            // 
            this.xrLabel41.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.GstTax", "")});
            this.xrLabel41.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel41.Location = new System.Drawing.Point(25, 75);
            this.xrLabel41.Name = "xrLabel41";
            this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel41.Size = new System.Drawing.Size(17, 16);
            this.xrLabel41.Text = "xrLabel41";
            this.xrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel12.Location = new System.Drawing.Point(25, 8);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.Size = new System.Drawing.Size(75, 17);
            this.xrLabel12.Text = "SubTotal:";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLine3
            // 
            this.xrLine3.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrLine3.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.xrLine3.Location = new System.Drawing.Point(8, 0);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLine3.Size = new System.Drawing.Size(334, 8);
            // 
            // xrLabel30
            // 
            this.xrLabel30.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel30.Location = new System.Drawing.Point(25, 125);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel30.Size = new System.Drawing.Size(92, 17);
            this.xrLabel30.Text = "TENDERED:";
            this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel27
            // 
            this.xrLabel27.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.mTotalAmount", "{0:$0.00}")});
            this.xrLabel27.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel27.Location = new System.Drawing.Point(208, 92);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.Size = new System.Drawing.Size(100, 23);
            this.xrLabel27.Text = "xrLabel27";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel26
            // 
            this.xrLabel26.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.mGSTAmount", "{0:$0.00}")});
            this.xrLabel26.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel26.Location = new System.Drawing.Point(208, 75);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.Size = new System.Drawing.Size(100, 16);
            this.xrLabel26.Text = "xrLabel26";
            this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel24
            // 
            this.xrLabel24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.DiscountAmt", "{0:$0.00}")});
            this.xrLabel24.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel24.Location = new System.Drawing.Point(208, 42);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.Size = new System.Drawing.Size(100, 16);
            this.xrLabel24.Text = "xrLabel24";
            this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel23
            // 
            this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.strFreebieCode", "")});
            this.xrLabel23.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel23.Location = new System.Drawing.Point(117, 42);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.Size = new System.Drawing.Size(91, 16);
            this.xrLabel23.Text = "xrLabel23";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel20
            // 
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel20.Location = new System.Drawing.Point(42, 75);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.Size = new System.Drawing.Size(67, 17);
            this.xrLabel20.Text = "% GST:";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel18
            // 
            this.xrLabel18.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel18.Location = new System.Drawing.Point(25, 42);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.Size = new System.Drawing.Size(83, 17);
            this.xrLabel18.Text = "Bill Discount:";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel19
            // 
            this.xrLabel19.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel19.Location = new System.Drawing.Point(25, 58);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.Size = new System.Drawing.Size(75, 17);
            this.xrLabel19.Text = "Nett Value:";
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.ReportFooter1});
            this.DetailReport.DataMember = "TblReceipt.Receipt_ReceiptPayment_Relation";
            this.DetailReport.Font = new System.Drawing.Font("Arial", 8.5F);
            this.DetailReport.Level = 1;
            this.DetailReport.Name = "DetailReport";
            this.DetailReport.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.DetailReport.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportFooter1
            // 
            this.ReportFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrVoidDetail,
            this.xrLabel49,
            this.xrLabel48,
            this.xrLabel7,
            this.xrLabel6});
            this.ReportFooter1.Font = new System.Drawing.Font("Arial", 8.5F);
            this.ReportFooter1.Height = 69;
            this.ReportFooter1.Name = "ReportFooter1";
            this.ReportFooter1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportFooter1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.ReportFooter1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.ReportFooter1_BeforePrint);
            // 
            // xrVoidDetail
            // 
            this.xrVoidDetail.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrVoidDetail.Location = new System.Drawing.Point(27, 40);
            this.xrVoidDetail.Multiline = true;
            this.xrVoidDetail.Name = "xrVoidDetail";
            this.xrVoidDetail.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrVoidDetail.Size = new System.Drawing.Size(183, 17);
            this.xrVoidDetail.Text = "Name:\r\n\r\nSignature:\r\n\r\nReason:\r\n\r\nAuthorized by:";
            this.xrVoidDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel49
            // 
            this.xrLabel49.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.mOutstandingAmount", "{0:$0.00}")});
            this.xrLabel49.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel49.Location = new System.Drawing.Point(208, 17);
            this.xrLabel49.Name = "xrLabel49";
            this.xrLabel49.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel49.Size = new System.Drawing.Size(75, 17);
            this.xrLabel49.Text = "xrLabel36";
            this.xrLabel49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel48
            // 
            this.xrLabel48.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel48.Location = new System.Drawing.Point(25, 17);
            this.xrLabel48.Name = "xrLabel48";
            this.xrLabel48.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel48.Size = new System.Drawing.Size(183, 17);
            this.xrLabel48.Text = "OutStanding Amount :";
            this.xrLabel48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel7.Location = new System.Drawing.Point(25, 0);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.Size = new System.Drawing.Size(183, 17);
            this.xrLabel7.Text = "GST Collected For this Bill:";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.GSTPaid", "{0:$0.00}")});
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel6.Location = new System.Drawing.Point(207, 0);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.Size = new System.Drawing.Size(75, 17);
            this.xrLabel6.Text = "xrLabel36";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel31
            // 
            this.xrLabel31.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblBranch.strHeader1", "")});
            this.xrLabel31.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel31.Location = new System.Drawing.Point(27, 33);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel31.Size = new System.Drawing.Size(317, 17);
            this.xrLabel31.Text = "xrLabel31";
            this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Detail3
            // 
            this.Detail3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel45,
            this.xrLabel46});
            this.Detail3.Height = 25;
            this.Detail3.Name = "Detail3";
            // 
            // xrLabel45
            // 
            this.xrLabel45.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.Receipt_FreePackage_Relation.strDescription", "")});
            this.xrLabel45.Location = new System.Drawing.Point(108, 0);
            this.xrLabel45.Name = "xrLabel45";
            this.xrLabel45.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel45.Size = new System.Drawing.Size(284, 25);
            this.xrLabel45.Text = "xrLabel45";
            this.xrLabel45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel46
            // 
            this.xrLabel46.Location = new System.Drawing.Point(25, 0);
            this.xrLabel46.Name = "xrLabel46";
            this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel46.Size = new System.Drawing.Size(100, 25);
            this.xrLabel46.Text = "Free Package :";
            this.xrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // DetailBand1
            // 
            this.DetailBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine1,
            this.xrLabel9});
            this.DetailBand1.Font = new System.Drawing.Font("Arial", 8.5F);
            this.DetailBand1.Height = 25;
            this.DetailBand1.Name = "DetailBand1";
            this.DetailBand1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.DetailBand1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLine1
            // 
            this.xrLine1.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrLine1.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.xrLine1.Location = new System.Drawing.Point(8, 17);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLine1.Size = new System.Drawing.Size(334, 8);
            // 
            // xrLabel9
            // 
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.strReceiptNo", "")});
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel9.Location = new System.Drawing.Point(42, 0);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.Size = new System.Drawing.Size(100, 17);
            this.xrLabel9.Text = "xrLabel9";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrLabel9.Visible = false;
            // 
            // xrLabel33
            // 
            this.xrLabel33.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblBranch.strHeader3", "")});
            this.xrLabel33.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel33.Location = new System.Drawing.Point(27, 67);
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.Size = new System.Drawing.Size(317, 16);
            this.xrLabel33.Text = "xrLabel33";
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.nSalespersonID", "")});
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel3.Location = new System.Drawing.Point(120, 140);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.Size = new System.Drawing.Size(108, 19);
            this.xrLabel3.Text = "xrLabel3";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel39
            // 
            this.xrLabel39.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.strReceiptNo", "")});
            this.xrLabel39.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel39.Location = new System.Drawing.Point(33, 173);
            this.xrLabel39.Name = "xrLabel39";
            this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel39.Size = new System.Drawing.Size(75, 17);
            this.xrLabel39.Text = "xrLabel6";
            this.xrLabel39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel37
            // 
            this.xrLabel37.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.dtDate", "{0:dddd, dd MMMM yyyy}")});
            this.xrLabel37.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel37.Location = new System.Drawing.Point(107, 173);
            this.xrLabel37.Name = "xrLabel37";
            this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel37.Size = new System.Drawing.Size(234, 17);
            this.xrLabel37.Text = "xrLabel37";
            this.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel32
            // 
            this.xrLabel32.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblBranch.strHeader2", "")});
            this.xrLabel32.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel32.Location = new System.Drawing.Point(27, 53);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel32.Size = new System.Drawing.Size(317, 17);
            this.xrLabel32.Text = "xrLabel32";
            this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel2.Location = new System.Drawing.Point(27, 140);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.Size = new System.Drawing.Size(92, 17);
            this.xrLabel2.Text = "Salesperson ID:";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // DetailReport3
            // 
            this.DetailReport3.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail3});
            this.DetailReport3.DataMember = "TblReceipt.Receipt_FreePackage_Relation";
            this.DetailReport3.Level = 3;
            this.DetailReport3.Name = "DetailReport3";
            // 
            // HeaderBand1
            // 
            this.HeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox1,
            this.xrLabel8,
            this.xrLabel39,
            this.xrLabel38,
            this.xrLabel37,
            this.xrLabel34,
            this.xrLabel33,
            this.xrLabel32,
            this.xrLabel31,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabelstrMemberName,
            this.xrLabelMembershipID,
            this.xrLabel1});
            this.HeaderBand1.Font = new System.Drawing.Font("Arial", 8.5F);
            this.HeaderBand1.Height = 190;
            this.HeaderBand1.Name = "HeaderBand1";
            this.HeaderBand1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.HeaderBand1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.HeaderBand1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.HeaderBand1_BeforePrint);
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.Location = new System.Drawing.Point(127, 0);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.Size = new System.Drawing.Size(65, 30);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.AutoSize;
            // 
            // xrLabel8
            // 
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblBranch.strHeader5", "")});
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel8.Location = new System.Drawing.Point(27, 100);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.Size = new System.Drawing.Size(317, 17);
            this.xrLabel8.Text = "xrLabel8";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel38
            // 
            this.xrLabel38.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.xrLabel38.Location = new System.Drawing.Point(27, 173);
            this.xrLabel38.Name = "xrLabel38";
            this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel38.Size = new System.Drawing.Size(17, 17);
            this.xrLabel38.Text = "#";
            this.xrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel34
            // 
            this.xrLabel34.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblBranch.strHeader4", "")});
            this.xrLabel34.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel34.Location = new System.Drawing.Point(27, 80);
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel34.Size = new System.Drawing.Size(317, 17);
            this.xrLabel34.Text = "xrLabel34";
            this.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.nCashierID", "")});
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel5.Location = new System.Drawing.Point(120, 160);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.Size = new System.Drawing.Size(83, 19);
            this.xrLabel5.Text = "xrLabel5";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabelstrMemberName
            // 
            this.xrLabelstrMemberName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.strMemberName", "")});
            this.xrLabelstrMemberName.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabelstrMemberName.Location = new System.Drawing.Point(183, 127);
            this.xrLabelstrMemberName.Name = "xrLabelstrMemberName";
            this.xrLabelstrMemberName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelstrMemberName.Size = new System.Drawing.Size(159, 17);
            this.xrLabelstrMemberName.Text = "Member Name";
            this.xrLabelstrMemberName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabelMembershipID
            // 
            this.xrLabelMembershipID.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.strMembershipID", "")});
            this.xrLabelMembershipID.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabelMembershipID.Location = new System.Drawing.Point(120, 127);
            this.xrLabelMembershipID.Name = "xrLabelMembershipID";
            this.xrLabelMembershipID.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelMembershipID.Size = new System.Drawing.Size(67, 17);
            this.xrLabelMembershipID.Text = "xrLabelMembershipID";
            this.xrLabelMembershipID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ppChildReport1
            // 
            this.ppChildReport1.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.ppDetailBand1,
            this.ReportFooter});
            this.ppChildReport1.DataMember = "TblReceipt.Receipt_ReceiptEntries_Relation";
            this.ppChildReport1.Font = new System.Drawing.Font("Arial", 8.5F);
            this.ppChildReport1.Name = "ppChildReport1";
            this.ppChildReport1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ppChildReport1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // DetailReport2
            // 
            this.DetailReport2.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail2,
            this.ReportHeader});
            this.DetailReport2.DataMember = "TblReceipt.Receipt_PaymentPlan_Relation";
            this.DetailReport2.Level = 4;
            this.DetailReport2.Name = "DetailReport2";
            this.DetailReport2.PrintOnEmptyDataSource = false;
            // 
            // Detail2
            // 
            this.Detail2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel56,
            this.xrLabel55,
            this.xrLabel54});
            this.Detail2.Height = 17;
            this.Detail2.Name = "Detail2";
            // 
            // xrLabel56
            // 
            this.xrLabel56.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.Receipt_PaymentPlan_Relation.dtDueDate", "")});
            this.xrLabel56.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel56.Location = new System.Drawing.Point(183, 0);
            this.xrLabel56.Name = "xrLabel56";
            this.xrLabel56.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel56.Size = new System.Drawing.Size(117, 17);
            this.xrLabel56.StylePriority.UseTextAlignment = false;
            this.xrLabel56.Text = "xrLabel15";
            this.xrLabel56.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel55
            // 
            this.xrLabel55.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.Receipt_PaymentPlan_Relation.AmtPayable", "")});
            this.xrLabel55.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel55.Location = new System.Drawing.Point(67, 0);
            this.xrLabel55.Name = "xrLabel55";
            this.xrLabel55.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel55.Size = new System.Drawing.Size(92, 17);
            this.xrLabel55.StylePriority.UseTextAlignment = false;
            this.xrLabel55.Text = "xrLabel15";
            this.xrLabel55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel54
            // 
            this.xrLabel54.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.Receipt_PaymentPlan_Relation.OrderNo", "")});
            this.xrLabel54.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel54.Location = new System.Drawing.Point(25, 0);
            this.xrLabel54.Name = "xrLabel54";
            this.xrLabel54.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel54.Size = new System.Drawing.Size(25, 17);
            this.xrLabel54.StylePriority.UseTextAlignment = false;
            this.xrLabel54.Text = "xrLabel15";
            this.xrLabel54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel53,
            this.xrLabel52,
            this.xrLabel51,
            this.xrLabel50,
            this.xrLine5});
            this.ReportHeader.Height = 42;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel53
            // 
            this.xrLabel53.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel53.Location = new System.Drawing.Point(183, 25);
            this.xrLabel53.Name = "xrLabel53";
            this.xrLabel53.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel53.Size = new System.Drawing.Size(117, 17);
            this.xrLabel53.StylePriority.UseTextAlignment = false;
            this.xrLabel53.Text = "Due Date";
            this.xrLabel53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel52
            // 
            this.xrLabel52.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel52.Location = new System.Drawing.Point(67, 25);
            this.xrLabel52.Name = "xrLabel52";
            this.xrLabel52.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel52.Size = new System.Drawing.Size(92, 17);
            this.xrLabel52.StylePriority.UseTextAlignment = false;
            this.xrLabel52.Text = "Amount Payable";
            this.xrLabel52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel51
            // 
            this.xrLabel51.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel51.Location = new System.Drawing.Point(25, 25);
            this.xrLabel51.Name = "xrLabel51";
            this.xrLabel51.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel51.Size = new System.Drawing.Size(25, 17);
            this.xrLabel51.StylePriority.UseTextAlignment = false;
            this.xrLabel51.Text = "No";
            this.xrLabel51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel50
            // 
            this.xrLabel50.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel50.Location = new System.Drawing.Point(25, 8);
            this.xrLabel50.Name = "xrLabel50";
            this.xrLabel50.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel50.Size = new System.Drawing.Size(183, 17);
            this.xrLabel50.Text = "PAYMENT PLAN :";
            this.xrLabel50.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLine5
            // 
            this.xrLine5.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrLine5.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.xrLine5.Location = new System.Drawing.Point(8, 0);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLine5.Size = new System.Drawing.Size(334, 8);
            // 
            // DetailReport4
            // 
            this.DetailReport4.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail4,
            this.ReportFooter3});
            this.DetailReport4.Level = 5;
            this.DetailReport4.Name = "DetailReport4";
            // 
            // Detail4
            // 
            this.Detail4.Height = 0;
            this.Detail4.Name = "Detail4";
            this.Detail4.Visible = false;
            // 
            // ReportFooter3
            // 
            this.ReportFooter3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel35,
            this.xrLabel36,
            this.xrLine4,
            this.xrLabel40,
            this.xrLabel47});
            this.ReportFooter3.Name = "ReportFooter3";
            // 
            // xrLabel35
            // 
            this.xrLabel35.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel35.Location = new System.Drawing.Point(25, 25);
            this.xrLabel35.Name = "xrLabel35";
            this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel35.Size = new System.Drawing.Size(200, 17);
            this.xrLabel35.Text = "BALANCE REWARDS POINTS: ";
            this.xrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel36
            // 
            this.xrLabel36.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TblReceipt.RewardPoint", "")});
            this.xrLabel36.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel36.Location = new System.Drawing.Point(208, 25);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel36.Size = new System.Drawing.Size(100, 17);
            this.xrLabel36.Text = "xrLabel36";
            this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLine4
            // 
            this.xrLine4.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrLine4.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.xrLine4.Location = new System.Drawing.Point(8, 8);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLine4.Size = new System.Drawing.Size(334, 8);
            // 
            // xrLabel40
            // 
            this.xrLabel40.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel40.Location = new System.Drawing.Point(25, 75);
            this.xrLabel40.Multiline = true;
            this.xrLabel40.Name = "xrLabel40";
            this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel40.Size = new System.Drawing.Size(242, 17);
            this.xrLabel40.Text = "Amore Fitness, the winner of 2012 Singapore Prestige Brand Awards (Established Br" +
                "ands) brings together its strengths in Fitness and Holistic Spa to bring you a c" +
                "omplete wellness experience.";
            this.xrLabel40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel47
            // 
            this.xrLabel47.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblBranch.strFooter1", "")});
            this.xrLabel47.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel47.Location = new System.Drawing.Point(25, 50);
            this.xrLabel47.Multiline = true;
            this.xrLabel47.Name = "xrLabel47";
            this.xrLabel47.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel47.Size = new System.Drawing.Size(242, 17);
            this.xrLabel47.Text = "xrLabel34";
            this.xrLabel47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Receipt
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.DetailBand1,
            this.HeaderBand1,
            this.ppGroupHeaderBand1,
            this.ppChildReport1,
            this.DetailReport,
            this.DetailReport1,
            this.DetailReport3,
            this.DetailReport2,
            this.DetailReport4});
            this.DataMember = "TblReceipt";
            this.Margins = new System.Drawing.Printing.Margins(0, 48, 0, 12);
            this.PageHeight = 1500;
            this.PageWidth = 544;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.PreviewRowCount = 100;
            this.Version = "8.3";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion

//		public void HideFields(bool discAmt)
//		{
//			if (discAmt==false){
//				this.xrLabel18.Visible=false; 	}
//			else
//			{
//				this.xrLabel18.Visible=true; 	}
//			
//		}

		
		private void xrLabel39_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
		
		}

		private void xrLabel37_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
		
		}

		private void xrLabel38_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
		
		}

		private void ppDetailBand1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			if (GetCurrentColumnValue("DiscountAmt").ToString()=="0" || GetCurrentColumnValue("DiscountAmt").ToString()=="" )
			{
				this.xrLabel18.Visible=false; 	}
			else
			{
				this.xrLabel18.Visible=true; 	
			}
						
			if (ppChildReport1.GetCurrentColumnValue("DiscountAmt").ToString()=="0" || ppChildReport1.GetCurrentColumnValue("DiscountAmt").ToString()=="") // might return null value
					xrPanel1.Visible = false;
			else
				xrPanel1.Visible = true;
		
		}

        private void ReportFooter1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (GetCurrentColumnValue("mOutstandingAmount").ToString() == "0.0000" || GetCurrentColumnValue("mOutstandingAmount").ToString() == "0" || GetCurrentColumnValue("mOutstandingAmount").ToString() == "")
            {
                this.xrLabel48.Visible = false;
                this.xrLabel49.Visible = false;
            }
            else
            {
                this.xrLabel48.Visible = true;
                this.xrLabel49.Visible = true;
            }
            if (GetCurrentColumnValue("fVoid").ToString() == "True")
            {
                xrVoidDetail.Visible = true;                
            }
            else
            {                
                xrVoidDetail.Visible = false;                
            }
        }

        private void HeaderBand1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (GetCurrentColumnValue("fVoid").ToString() == "True")
            {
                xrPictureBox1.Visible = true;
            }
            else
            {
                xrPictureBox1.Visible = false;
            }
        }     

	}
}

