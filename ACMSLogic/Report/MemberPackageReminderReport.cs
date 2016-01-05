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
	public class ReportClassAttendanceReminder : DevExpress.XtraReports.UI.XtraReport
	{
		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
		private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
		private DevExpress.XtraReports.UI.XRLabel xrLabel2;
		private DevExpress.XtraReports.UI.XRLabel xrLabel3;
		private DevExpress.XtraReports.UI.XRLabel xrLabel5;
		private DevExpress.XtraReports.UI.XRLabel xrLabel6;
		private DevExpress.XtraReports.UI.XRLabel xrLabel7;
		private DevExpress.XtraReports.UI.XRLabel xrlblPackageActivation;
		private DevExpress.XtraReports.UI.XRLabel xrlblBirthdayGreet;
		private DevExpress.XtraReports.UI.XRLabel xrlblMembershipID;
		private DevExpress.XtraReports.UI.XRLabel xrlblMemberName;
		private DevExpress.XtraReports.UI.XRLabel xrlblDaysToExpiry;
		private DevExpress.XtraReports.UI.XRLabel xrlblRemainingClasses;
		private DevExpress.XtraReports.UI.XRLabel xrlblPackageBalance;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ReportClassAttendanceReminder()
		{
			//
			// Required for Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public void CreateDataBindings()
		{
			xrlblBirthdayGreet.DataBindings.Clear();
			xrlblDaysToExpiry.DataBindings.Clear();
			xrlblMemberName.DataBindings.Clear();
			xrlblMembershipID.DataBindings.Clear();
			xrlblPackageActivation.DataBindings.Clear();
			xrlblPackageBalance.DataBindings.Clear();
			xrlblRemainingClasses.DataBindings.Clear();

			
			xrlblBirthdayGreet.DataBindings.Add("Text", DataSource, "Birthday");
			xrlblDaysToExpiry.DataBindings.Add("Text", DataSource, "AvailableDayToExpire");
			xrlblMemberName.DataBindings.Add("Text", DataSource, "MemberName");
			xrlblMembershipID.DataBindings.Add("Text", DataSource, "MemberID");
			xrlblPackageActivation.DataBindings.Add("Text", DataSource, "PackageActivation");
			xrlblPackageBalance.DataBindings.Add("Text", DataSource, "OutstandingBalance", "d2");
			xrlblRemainingClasses.DataBindings.Add("Text", DataSource, "ClassesLeft");
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
			this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrlblPackageActivation = new DevExpress.XtraReports.UI.XRLabel();
			this.xrlblPackageBalance = new DevExpress.XtraReports.UI.XRLabel();
			this.xrlblDaysToExpiry = new DevExpress.XtraReports.UI.XRLabel();
			this.xrlblRemainingClasses = new DevExpress.XtraReports.UI.XRLabel();
			this.xrlblBirthdayGreet = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrlblMemberName = new DevExpress.XtraReports.UI.XRLabel();
			this.xrlblMembershipID = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
			this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
			this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																						this.xrLabel7,
																						this.xrLabel6,
																						this.xrlblPackageActivation,
																						this.xrlblPackageBalance,
																						this.xrlblDaysToExpiry,
																						this.xrlblRemainingClasses,
																						this.xrlblBirthdayGreet,
																						this.xrLabel5,
																						this.xrlblMemberName,
																						this.xrlblMembershipID,
																						this.xrLabel3,
																						this.xrLabel2});
			this.Detail.Height = 294;
			this.Detail.Name = "Detail";
			// 
			// xrLabel7
			// 
			this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel7.Location = new System.Drawing.Point(8, 138);
			this.xrLabel7.Name = "xrLabel7";
			this.xrLabel7.ParentStyleUsing.UseFont = false;
			this.xrLabel7.Size = new System.Drawing.Size(138, 24);
			this.xrLabel7.Text = "Outstanding Balance:";
			// 
			// xrLabel6
			// 
			this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel6.Location = new System.Drawing.Point(8, 106);
			this.xrLabel6.Name = "xrLabel6";
			this.xrLabel6.ParentStyleUsing.UseFont = false;
			this.xrLabel6.Size = new System.Drawing.Size(123, 25);
			this.xrLabel6.Text = "Remaining Classes:";
			// 
			// xrlblPackageActivation
			// 
			this.xrlblPackageActivation.Location = new System.Drawing.Point(10, 173);
			this.xrlblPackageActivation.Name = "xrlblPackageActivation";
			this.xrlblPackageActivation.Size = new System.Drawing.Size(280, 23);
			// 
			// xrlblPackageBalance
			// 
			this.xrlblPackageBalance.Location = new System.Drawing.Point(150, 138);
			this.xrlblPackageBalance.Name = "xrlblPackageBalance";
			this.xrlblPackageBalance.Size = new System.Drawing.Size(150, 23);
			// 
			// xrlblDaysToExpiry
			// 
			this.xrlblDaysToExpiry.Location = new System.Drawing.Point(150, 75);
			this.xrlblDaysToExpiry.Name = "xrlblDaysToExpiry";
			this.xrlblDaysToExpiry.Size = new System.Drawing.Size(150, 23);
			// 
			// xrlblRemainingClasses
			// 
			this.xrlblRemainingClasses.Location = new System.Drawing.Point(150, 106);
			this.xrlblRemainingClasses.Name = "xrlblRemainingClasses";
			this.xrlblRemainingClasses.Size = new System.Drawing.Size(150, 23);
			// 
			// xrlblBirthdayGreet
			// 
			this.xrlblBirthdayGreet.Location = new System.Drawing.Point(10, 200);
			this.xrlblBirthdayGreet.Name = "xrlblBirthdayGreet";
			this.xrlblBirthdayGreet.Size = new System.Drawing.Size(280, 23);
			// 
			// xrLabel5
			// 
			this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel5.Location = new System.Drawing.Point(8, 75);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.ParentStyleUsing.UseFont = false;
			this.xrLabel5.Size = new System.Drawing.Size(123, 25);
			this.xrLabel5.Text = "Expiry Date:";
			// 
			// xrlblMemberName
			// 
			this.xrlblMemberName.Location = new System.Drawing.Point(150, 40);
			this.xrlblMemberName.Name = "xrlblMemberName";
			this.xrlblMemberName.Size = new System.Drawing.Size(150, 23);
			// 
			// xrlblMembershipID
			// 
			this.xrlblMembershipID.Location = new System.Drawing.Point(150, 6);
			this.xrlblMembershipID.Name = "xrlblMembershipID";
			this.xrlblMembershipID.Size = new System.Drawing.Size(150, 23);
			// 
			// xrLabel3
			// 
			this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel3.Location = new System.Drawing.Point(8, 40);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.ParentStyleUsing.UseFont = false;
			this.xrLabel3.Size = new System.Drawing.Size(123, 25);
			this.xrLabel3.Text = "Member Name:";
			// 
			// xrLabel2
			// 
			this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel2.Location = new System.Drawing.Point(8, 6);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.ParentStyleUsing.UseFont = false;
			this.xrLabel2.Size = new System.Drawing.Size(123, 25);
			this.xrLabel2.Text = "Membership ID:";
			// 
			// PageHeader
			// 
			this.PageHeader.Height = 0;
			this.PageHeader.Name = "PageHeader";
			// 
			// PageFooter
			// 
			this.PageFooter.Height = 28;
			this.PageFooter.Name = "PageFooter";
			// 
			// ReportClassAttendanceReminder
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
																		 this.Detail,
																		 this.PageHeader,
																		 this.PageFooter});
			this.Margins = new System.Drawing.Printing.Margins(100, 424, 100, 100);
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion
	}
}

