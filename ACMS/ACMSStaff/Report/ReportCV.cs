using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ACMS.ACMSStaff.Report
{
	/// <summary>
	/// Summary description for ReportCV.
	/// </summary>
	public class ReportCV : DevExpress.XtraReports.UI.XtraReport
	{
		private DevExpress.XtraReports.UI.DetailBand detailBand1;
		private DevExpress.XtraReports.UI.PageHeaderBand pageHeaderBand1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel45;
		private DevExpress.XtraReports.UI.XRLabel xrLabel44;
		private DevExpress.XtraReports.UI.XRLabel xrLabel43;
		private DevExpress.XtraReports.UI.XRLabel xrLabel42;
		private DevExpress.XtraReports.UI.XRLabel xrLabel41;
		private DevExpress.XtraReports.UI.XRLabel xrLabel40;
		private DevExpress.XtraReports.UI.XRLabel xrLabel29;
		private DevExpress.XtraReports.UI.XRLabel xrLabel28;
		private DevExpress.XtraReports.UI.XRLabel xrLabel27;
		private DevExpress.XtraReports.UI.XRLabel xrLabel26;
		private DevExpress.XtraReports.UI.XRLabel xrLabel25;
		private DevExpress.XtraReports.UI.XRLabel xrLabel24;
		private DevExpress.XtraReports.UI.XRLabel xrLabel23;
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
		private DevExpress.XtraReports.UI.XRLabel xrLabel10;
		private DevExpress.XtraReports.UI.XRLabel xrLabel9;
		private DevExpress.XtraReports.UI.XRLabel xrLabel8;
		private DevExpress.XtraReports.UI.XRLabel xrLabel7;
		private DevExpress.XtraReports.UI.XRLabel xrLabel6;
		private DevExpress.XtraReports.UI.XRLabel xrLabel5;
		private DevExpress.XtraReports.UI.XRLabel xrLabel4;
		private DevExpress.XtraReports.UI.XRLabel xrLabel2;
		private DevExpress.XtraReports.UI.XRLabel xrLabel3;
		private DevExpress.XtraReports.UI.XRLabel xrLabel1;
		private DevExpress.XtraReports.UI.DetailReportBand DetailReport;
		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.XRLabel xrLabel39;
		private DevExpress.XtraReports.UI.XRLabel xrLabel38;
		private DevExpress.XtraReports.UI.XRLabel xrLabel37;
		private DevExpress.XtraReports.UI.XRLabel xrLabel36;
		private DevExpress.XtraReports.UI.XRLabel xrLabel35;
		private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
		private DevExpress.XtraReports.UI.XRLine xrLine2;
		private DevExpress.XtraReports.UI.XRLabel xrLabel34;
		private DevExpress.XtraReports.UI.XRLabel xrLabel33;
		private DevExpress.XtraReports.UI.XRLabel xrLabel32;
		private DevExpress.XtraReports.UI.XRLabel xrLabel31;
		private DevExpress.XtraReports.UI.XRLabel xrLabel30;
		private DevExpress.XtraReports.UI.XRLine xrLine1;
		private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
		private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
		private DevExpress.XtraReports.UI.XRLine xrLine3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ReportCV()
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
			this.pageHeaderBand1 = new DevExpress.XtraReports.UI.PageHeaderBand();
			this.xrLabel45 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel44 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel43 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel42 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
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
			this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
			this.Detail = new DevExpress.XtraReports.UI.DetailBand();
			this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
			this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
			this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
			this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
			this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
			this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
			this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// detailBand1
			// 
			this.detailBand1.Height = 0;
			this.detailBand1.Name = "detailBand1";
			// 
			// pageHeaderBand1
			// 
			this.pageHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																								 this.xrLabel45,
																								 this.xrLabel44,
																								 this.xrLabel43,
																								 this.xrLabel42,
																								 this.xrLabel41,
																								 this.xrLabel40,
																								 this.xrLabel29,
																								 this.xrLabel28,
																								 this.xrLabel27,
																								 this.xrLabel26,
																								 this.xrLabel25,
																								 this.xrLabel24,
																								 this.xrLabel23,
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
																								 this.xrLabel11,
																								 this.xrLabel10,
																								 this.xrLabel9,
																								 this.xrLabel8,
																								 this.xrLabel7,
																								 this.xrLabel6,
																								 this.xrLabel5,
																								 this.xrLabel4,
																								 this.xrLabel2,
																								 this.xrLabel3,
																								 this.xrLabel1});
			this.pageHeaderBand1.Height = 388;
			this.pageHeaderBand1.Name = "pageHeaderBand1";
			// 
			// xrLabel45
			// 
			this.xrLabel45.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "CV.strDetails", "")});
			this.xrLabel45.Location = new System.Drawing.Point(117, 358);
			this.xrLabel45.Name = "xrLabel45";
			this.xrLabel45.Size = new System.Drawing.Size(533, 25);
			this.xrLabel45.Text = "xrLabel45";
			// 
			// xrLabel44
			// 
			this.xrLabel44.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel44.Location = new System.Drawing.Point(8, 358);
			this.xrLabel44.Name = "xrLabel44";
			this.xrLabel44.ParentStyleUsing.UseFont = false;
			this.xrLabel44.Size = new System.Drawing.Size(109, 25);
			this.xrLabel44.Text = "Summary of CV:";
			// 
			// xrLabel43
			// 
			this.xrLabel43.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "CV.strContactNumber", "")});
			this.xrLabel43.Location = new System.Drawing.Point(117, 117);
			this.xrLabel43.Name = "xrLabel43";
			this.xrLabel43.Size = new System.Drawing.Size(191, 25);
			this.xrLabel43.Text = "xrLabel43";
			// 
			// xrLabel42
			// 
			this.xrLabel42.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "CV.strEmailAddress", "")});
			this.xrLabel42.Location = new System.Drawing.Point(442, 117);
			this.xrLabel42.Name = "xrLabel42";
			this.xrLabel42.Size = new System.Drawing.Size(208, 25);
			this.xrLabel42.Text = "xrLabel42";
			// 
			// xrLabel41
			// 
			this.xrLabel41.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel41.Location = new System.Drawing.Point(317, 117);
			this.xrLabel41.Name = "xrLabel41";
			this.xrLabel41.ParentStyleUsing.UseFont = false;
			this.xrLabel41.Size = new System.Drawing.Size(125, 25);
			this.xrLabel41.Text = "Email Address:";
			// 
			// xrLabel40
			// 
			this.xrLabel40.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel40.Location = new System.Drawing.Point(8, 117);
			this.xrLabel40.Name = "xrLabel40";
			this.xrLabel40.ParentStyleUsing.UseFont = false;
			this.xrLabel40.Size = new System.Drawing.Size(109, 25);
			this.xrLabel40.Text = "Contact No:";
			// 
			// xrLabel29
			// 
			this.xrLabel29.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "CV.strStatus", "")});
			this.xrLabel29.Location = new System.Drawing.Point(117, 333);
			this.xrLabel29.Name = "xrLabel29";
			this.xrLabel29.Size = new System.Drawing.Size(400, 25);
			this.xrLabel29.Text = "xrLabel29";
			// 
			// xrLabel28
			// 
			this.xrLabel28.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel28.Location = new System.Drawing.Point(8, 333);
			this.xrLabel28.Name = "xrLabel28";
			this.xrLabel28.ParentStyleUsing.UseFont = false;
			this.xrLabel28.Size = new System.Drawing.Size(109, 25);
			this.xrLabel28.Text = "Status:";
			// 
			// xrLabel27
			// 
			this.xrLabel27.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "CV.dtLastEditDate", "")});
			this.xrLabel27.Location = new System.Drawing.Point(117, 308);
			this.xrLabel27.Name = "xrLabel27";
			this.xrLabel27.Size = new System.Drawing.Size(400, 25);
			this.xrLabel27.Text = "xrLabel27";
			// 
			// xrLabel26
			// 
			this.xrLabel26.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel26.Location = new System.Drawing.Point(8, 308);
			this.xrLabel26.Name = "xrLabel26";
			this.xrLabel26.ParentStyleUsing.UseFont = false;
			this.xrLabel26.Size = new System.Drawing.Size(109, 25);
			this.xrLabel26.Text = "Last update:";
			// 
			// xrLabel25
			// 
			this.xrLabel25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "CV.strDepartmentAssignedTo", "")});
			this.xrLabel25.Location = new System.Drawing.Point(117, 275);
			this.xrLabel25.Name = "xrLabel25";
			this.xrLabel25.Size = new System.Drawing.Size(533, 25);
			this.xrLabel25.Text = "xrLabel25";
			// 
			// xrLabel24
			// 
			this.xrLabel24.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel24.Location = new System.Drawing.Point(8, 275);
			this.xrLabel24.Name = "xrLabel24";
			this.xrLabel24.ParentStyleUsing.UseFont = false;
			this.xrLabel24.Size = new System.Drawing.Size(109, 33);
			this.xrLabel24.Text = "Department Assigned To:";
			// 
			// xrLabel23
			// 
			this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "CV.strSubmittedBy", "")});
			this.xrLabel23.Location = new System.Drawing.Point(117, 250);
			this.xrLabel23.Name = "xrLabel23";
			this.xrLabel23.Size = new System.Drawing.Size(533, 25);
			this.xrLabel23.Text = "xrLabel23";
			// 
			// xrLabel22
			// 
			this.xrLabel22.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel22.Location = new System.Drawing.Point(8, 250);
			this.xrLabel22.Name = "xrLabel22";
			this.xrLabel22.ParentStyleUsing.UseFont = false;
			this.xrLabel22.Size = new System.Drawing.Size(109, 25);
			this.xrLabel22.Text = "Submitted By:";
			// 
			// xrLabel21
			// 
			this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "CV.nStaffID", "")});
			this.xrLabel21.Location = new System.Drawing.Point(117, 225);
			this.xrLabel21.Name = "xrLabel21";
			this.xrLabel21.Size = new System.Drawing.Size(191, 25);
			this.xrLabel21.Text = "xrLabel21";
			// 
			// xrLabel20
			// 
			this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel20.Location = new System.Drawing.Point(8, 225);
			this.xrLabel20.Name = "xrLabel20";
			this.xrLabel20.ParentStyleUsing.UseFont = false;
			this.xrLabel20.Size = new System.Drawing.Size(109, 25);
			this.xrLabel20.Text = "Staff ID:";
			// 
			// xrLabel19
			// 
			this.xrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "CV.strSubject", "")});
			this.xrLabel19.Location = new System.Drawing.Point(117, 200);
			this.xrLabel19.Name = "xrLabel19";
			this.xrLabel19.Size = new System.Drawing.Size(533, 25);
			this.xrLabel19.Text = "xrLabel19";
			// 
			// xrLabel18
			// 
			this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel18.Location = new System.Drawing.Point(8, 200);
			this.xrLabel18.Name = "xrLabel18";
			this.xrLabel18.ParentStyleUsing.UseFont = false;
			this.xrLabel18.Size = new System.Drawing.Size(109, 25);
			this.xrLabel18.Text = "Subject:";
			// 
			// xrLabel17
			// 
			this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "CV.strCaseCategoryDescription", "")});
			this.xrLabel17.Location = new System.Drawing.Point(117, 175);
			this.xrLabel17.Name = "xrLabel17";
			this.xrLabel17.Size = new System.Drawing.Size(191, 25);
			this.xrLabel17.Text = "xrLabel17";
			// 
			// xrLabel16
			// 
			this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel16.Location = new System.Drawing.Point(8, 175);
			this.xrLabel16.Name = "xrLabel16";
			this.xrLabel16.ParentStyleUsing.UseFont = false;
			this.xrLabel16.Size = new System.Drawing.Size(109, 25);
			this.xrLabel16.Text = "Category:";
			// 
			// xrLabel15
			// 
			this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "CV.strCaseTypeDescription", "")});
			this.xrLabel15.Location = new System.Drawing.Point(442, 150);
			this.xrLabel15.Name = "xrLabel15";
			this.xrLabel15.Size = new System.Drawing.Size(208, 25);
			this.xrLabel15.Text = "xrLabel15";
			// 
			// xrLabel14
			// 
			this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel14.Location = new System.Drawing.Point(317, 150);
			this.xrLabel14.Name = "xrLabel14";
			this.xrLabel14.ParentStyleUsing.UseFont = false;
			this.xrLabel14.Size = new System.Drawing.Size(126, 25);
			this.xrLabel14.Text = "Type:";
			// 
			// xrLabel13
			// 
			this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel13.Location = new System.Drawing.Point(8, 150);
			this.xrLabel13.Name = "xrLabel13";
			this.xrLabel13.ParentStyleUsing.UseFont = false;
			this.xrLabel13.Size = new System.Drawing.Size(109, 25);
			this.xrLabel13.Text = "Department:";
			// 
			// xrLabel12
			// 
			this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "CV.strDepartmentDescription", "")});
			this.xrLabel12.Location = new System.Drawing.Point(117, 150);
			this.xrLabel12.Name = "xrLabel12";
			this.xrLabel12.Size = new System.Drawing.Size(191, 25);
			this.xrLabel12.Text = "xrLabel12";
			// 
			// xrLabel11
			// 
			this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "CV.strMembershipName", "")});
			this.xrLabel11.Location = new System.Drawing.Point(442, 92);
			this.xrLabel11.Name = "xrLabel11";
			this.xrLabel11.Size = new System.Drawing.Size(208, 25);
			this.xrLabel11.Text = "xrLabel11";
			// 
			// xrLabel10
			// 
			this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel10.Location = new System.Drawing.Point(317, 92);
			this.xrLabel10.Name = "xrLabel10";
			this.xrLabel10.ParentStyleUsing.UseFont = false;
			this.xrLabel10.Size = new System.Drawing.Size(126, 25);
			this.xrLabel10.Text = "Membership Name:";
			// 
			// xrLabel9
			// 
			this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							  new DevExpress.XtraReports.UI.XRBinding("Text", null, "CV.strMembershipID", "")});
			this.xrLabel9.Location = new System.Drawing.Point(117, 92);
			this.xrLabel9.Name = "xrLabel9";
			this.xrLabel9.Size = new System.Drawing.Size(117, 25);
			this.xrLabel9.Text = "xrLabel9";
			// 
			// xrLabel8
			// 
			this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel8.Location = new System.Drawing.Point(8, 92);
			this.xrLabel8.Name = "xrLabel8";
			this.xrLabel8.ParentStyleUsing.UseFont = false;
			this.xrLabel8.Size = new System.Drawing.Size(109, 25);
			this.xrLabel8.Text = "Membership ID:";
			// 
			// xrLabel7
			// 
			this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							  new DevExpress.XtraReports.UI.XRBinding("Text", null, "CV.strBranchCode", "")});
			this.xrLabel7.Location = new System.Drawing.Point(117, 67);
			this.xrLabel7.Name = "xrLabel7";
			this.xrLabel7.Size = new System.Drawing.Size(100, 25);
			this.xrLabel7.Text = "xrLabel7";
			// 
			// xrLabel6
			// 
			this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel6.Location = new System.Drawing.Point(8, 67);
			this.xrLabel6.Name = "xrLabel6";
			this.xrLabel6.ParentStyleUsing.UseFont = false;
			this.xrLabel6.Size = new System.Drawing.Size(92, 25);
			this.xrLabel6.Text = "Branch:";
			// 
			// xrLabel5
			// 
			this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							  new DevExpress.XtraReports.UI.XRBinding("Text", null, "CV.dtDate", "")});
			this.xrLabel5.Location = new System.Drawing.Point(417, 42);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.Size = new System.Drawing.Size(233, 25);
			this.xrLabel5.Text = "xrLabel5";
			// 
			// xrLabel4
			// 
			this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel4.Location = new System.Drawing.Point(317, 42);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.ParentStyleUsing.UseFont = false;
			this.xrLabel4.Size = new System.Drawing.Size(92, 25);
			this.xrLabel4.Text = "Date Received:";
			// 
			// xrLabel2
			// 
			this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							  new DevExpress.XtraReports.UI.XRBinding("Text", null, "CV.nCaseID", "")});
			this.xrLabel2.Location = new System.Drawing.Point(117, 42);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.Size = new System.Drawing.Size(100, 25);
			this.xrLabel2.Text = "xrLabel2";
			// 
			// xrLabel3
			// 
			this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel3.Location = new System.Drawing.Point(8, 42);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.ParentStyleUsing.UseFont = false;
			this.xrLabel3.Size = new System.Drawing.Size(59, 25);
			this.xrLabel3.Text = "Ref No:";
			// 
			// xrLabel1
			// 
			this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
			this.xrLabel1.Location = new System.Drawing.Point(250, 8);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.ParentStyleUsing.UseFont = false;
			this.xrLabel1.Size = new System.Drawing.Size(183, 25);
			this.xrLabel1.Text = "Customer Voice";
			// 
			// DetailReport
			// 
			this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
																					  this.Detail,
																					  this.ReportHeader});
			this.DetailReport.DataMember = "CVACTION";
			this.DetailReport.Name = "DetailReport";
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																						this.xrLine3,
																						this.xrLabel39,
																						this.xrLabel38,
																						this.xrLabel37,
																						this.xrLabel36,
																						this.xrLabel35});
			this.Detail.Height = 75;
			this.Detail.Name = "Detail";
			// 
			// xrLabel39
			// 
			this.xrLabel39.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "CVACTION.strActionDetails", "")});
			this.xrLabel39.Location = new System.Drawing.Point(8, 33);
			this.xrLabel39.Name = "xrLabel39";
			this.xrLabel39.Size = new System.Drawing.Size(634, 25);
			this.xrLabel39.Text = "xrLabel39";
			// 
			// xrLabel38
			// 
			this.xrLabel38.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "CVACTION.strActionTakenBy", "")});
			this.xrLabel38.Location = new System.Drawing.Point(408, 0);
			this.xrLabel38.Name = "xrLabel38";
			this.xrLabel38.Size = new System.Drawing.Size(234, 25);
			this.xrLabel38.Text = "xrLabel38";
			// 
			// xrLabel37
			// 
			this.xrLabel37.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "CVACTION.strMode", "")});
			this.xrLabel37.Location = new System.Drawing.Point(292, 0);
			this.xrLabel37.Name = "xrLabel37";
			this.xrLabel37.Size = new System.Drawing.Size(108, 25);
			this.xrLabel37.Text = "xrLabel37";
			// 
			// xrLabel36
			// 
			this.xrLabel36.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "CVACTION.dtDate", "")});
			this.xrLabel36.Location = new System.Drawing.Point(108, 0);
			this.xrLabel36.Name = "xrLabel36";
			this.xrLabel36.Size = new System.Drawing.Size(175, 25);
			this.xrLabel36.Text = "xrLabel36";
			// 
			// xrLabel35
			// 
			this.xrLabel35.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
																							   new DevExpress.XtraReports.UI.XRBinding("Text", null, "CVACTION.nActionID", "")});
			this.xrLabel35.Location = new System.Drawing.Point(8, 0);
			this.xrLabel35.Name = "xrLabel35";
			this.xrLabel35.Size = new System.Drawing.Size(92, 25);
			this.xrLabel35.Text = "xrLabel35";
			// 
			// ReportHeader
			// 
			this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																							  this.xrLine2,
																							  this.xrLabel34,
																							  this.xrLabel33,
																							  this.xrLabel32,
																							  this.xrLabel31,
																							  this.xrLabel30,
																							  this.xrLine1});
			this.ReportHeader.Height = 67;
			this.ReportHeader.Name = "ReportHeader";
			// 
			// xrLine2
			// 
			this.xrLine2.Location = new System.Drawing.Point(0, 58);
			this.xrLine2.Name = "xrLine2";
			this.xrLine2.Size = new System.Drawing.Size(650, 8);
			// 
			// xrLabel34
			// 
			this.xrLabel34.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel34.Location = new System.Drawing.Point(8, 33);
			this.xrLabel34.Name = "xrLabel34";
			this.xrLabel34.ParentStyleUsing.UseFont = false;
			this.xrLabel34.Size = new System.Drawing.Size(642, 25);
			this.xrLabel34.Text = "Action Taken";
			this.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			// 
			// xrLabel33
			// 
			this.xrLabel33.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel33.Location = new System.Drawing.Point(408, 8);
			this.xrLabel33.Name = "xrLabel33";
			this.xrLabel33.ParentStyleUsing.UseFont = false;
			this.xrLabel33.Size = new System.Drawing.Size(234, 25);
			this.xrLabel33.Text = "Action Taken By";
			// 
			// xrLabel32
			// 
			this.xrLabel32.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel32.Location = new System.Drawing.Point(292, 8);
			this.xrLabel32.Name = "xrLabel32";
			this.xrLabel32.ParentStyleUsing.UseFont = false;
			this.xrLabel32.Size = new System.Drawing.Size(108, 25);
			this.xrLabel32.Text = "Mode";
			// 
			// xrLabel31
			// 
			this.xrLabel31.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel31.Location = new System.Drawing.Point(108, 8);
			this.xrLabel31.Name = "xrLabel31";
			this.xrLabel31.ParentStyleUsing.UseFont = false;
			this.xrLabel31.Size = new System.Drawing.Size(175, 25);
			this.xrLabel31.Text = "Action Date Time";
			// 
			// xrLabel30
			// 
			this.xrLabel30.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel30.Location = new System.Drawing.Point(8, 8);
			this.xrLabel30.Name = "xrLabel30";
			this.xrLabel30.ParentStyleUsing.UseFont = false;
			this.xrLabel30.Size = new System.Drawing.Size(92, 25);
			this.xrLabel30.Text = "ID";
			// 
			// xrLine1
			// 
			this.xrLine1.Location = new System.Drawing.Point(0, 0);
			this.xrLine1.Name = "xrLine1";
			this.xrLine1.Size = new System.Drawing.Size(650, 8);
			// 
			// BottomMargin
			// 
			this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																							  this.xrPageInfo1});
			this.BottomMargin.Height = 36;
			this.BottomMargin.Name = "BottomMargin";
			// 
			// xrPageInfo1
			// 
			this.xrPageInfo1.Format = "Page : {0 } / {1}";
			this.xrPageInfo1.Location = new System.Drawing.Point(550, 0);
			this.xrPageInfo1.Name = "xrPageInfo1";
			this.xrPageInfo1.Size = new System.Drawing.Size(100, 25);
			// 
			// xrLine3
			// 
			this.xrLine3.Location = new System.Drawing.Point(0, 67);
			this.xrLine3.Name = "xrLine3";
			this.xrLine3.Size = new System.Drawing.Size(650, 8);
			// 
			// ReportCV
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
																		 this.detailBand1,
																		 this.pageHeaderBand1,
																		 this.DetailReport,
																		 this.BottomMargin});
			this.Margins = new System.Drawing.Printing.Margins(100, 100, 100, 36);
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion
	}
}

