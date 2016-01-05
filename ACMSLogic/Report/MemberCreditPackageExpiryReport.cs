using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ACMSLogic.Report
{
	/// <summary>
	/// Summary description for MemberPackageExpiry.
	/// </summary>
	public class MemberCreditPackageExpiryReport : DevExpress.XtraReports.UI.XtraReport
	{
		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
		private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
		private DevExpress.XtraReports.UI.XRLabel xrLabel2;
		private DevExpress.XtraReports.UI.XRLabel xrlblMembershipID;
		private DevExpress.XtraReports.UI.XRLabel xrlblMemberName;
		private DevExpress.XtraReports.UI.XRLabel xrLabel3;
		private DevExpress.XtraReports.UI.XRLabel xrLabel1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel6;
		private DevExpress.XtraReports.UI.XRLabel xrLabel7;
		private DevExpress.XtraReports.UI.XRLabel xrlblPackageID;
		private DevExpress.XtraReports.UI.XRLabel xrlblBalance;
		private DevExpress.XtraReports.UI.XRLabel xrlblExpiryDate;
		private DevExpress.XtraReports.UI.XRLabel xrlblPackageCode;
		private DevExpress.XtraReports.UI.XRLabel xrLabel10;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MemberCreditPackageExpiryReport()
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
			xrlblMemberName.DataBindings.Clear();
			xrlblMembershipID.DataBindings.Clear();
			xrlblPackageCode.DataBindings.Clear();
			xrlblPackageID.DataBindings.Clear();
			xrlblBalance.DataBindings.Clear();
			xrlblExpiryDate.DataBindings.Clear();

			xrlblMemberName.DataBindings.Add("Text", DataSource, "MemberName");
			xrlblMembershipID.DataBindings.Add("Text", DataSource, "strMembershipID");
			xrlblPackageCode.DataBindings.Add("Text", DataSource, "strCreditPackageCode");
			xrlblPackageID.DataBindings.Add("Text", DataSource, "nCreditPackageID");
			xrlblBalance.DataBindings.Add("Text", DataSource, "Balance");
			xrlblExpiryDate.DataBindings.Add("Text", DataSource, "dtExpiryDate", "{0:dd/MM/yyyy}");
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
			this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrlblPackageCode = new DevExpress.XtraReports.UI.XRLabel();
			this.xrlblExpiryDate = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrlblBalance = new DevExpress.XtraReports.UI.XRLabel();
			this.xrlblPackageID = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrlblMemberName = new DevExpress.XtraReports.UI.XRLabel();
			this.xrlblMembershipID = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
			this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
			this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																						this.xrLabel10,
																						this.xrlblPackageCode,
																						this.xrlblExpiryDate,
																						this.xrLabel7,
																						this.xrLabel6,
																						this.xrlblBalance,
																						this.xrlblPackageID,
																						this.xrLabel1,
																						this.xrLabel3,
																						this.xrlblMemberName,
																						this.xrlblMembershipID,
																						this.xrLabel2});
			this.Detail.Height = 193;
			this.Detail.Name = "Detail";
			// 
			// xrLabel10
			// 
			this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel10.Location = new System.Drawing.Point(17, 92);
			this.xrLabel10.Name = "xrLabel10";
			this.xrLabel10.ParentStyleUsing.UseFont = false;
			this.xrLabel10.Size = new System.Drawing.Size(123, 25);
			this.xrLabel10.Text = "Credit Package:";
			// 
			// xrlblPackageCode
			// 
			this.xrlblPackageCode.Location = new System.Drawing.Point(158, 92);
			this.xrlblPackageCode.Name = "xrlblPackageCode";
			this.xrlblPackageCode.Size = new System.Drawing.Size(150, 23);
			// 
			// xrlblExpiryDate
			// 
			this.xrlblExpiryDate.Location = new System.Drawing.Point(158, 150);
			this.xrlblExpiryDate.Name = "xrlblExpiryDate";
			this.xrlblExpiryDate.Size = new System.Drawing.Size(150, 23);
			// 
			// xrLabel7
			// 
			this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel7.Location = new System.Drawing.Point(17, 150);
			this.xrLabel7.Name = "xrLabel7";
			this.xrLabel7.ParentStyleUsing.UseFont = false;
			this.xrLabel7.Size = new System.Drawing.Size(123, 25);
			this.xrLabel7.Text = "Expiry Date:";
			// 
			// xrLabel6
			// 
			this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel6.Location = new System.Drawing.Point(17, 121);
			this.xrLabel6.Name = "xrLabel6";
			this.xrLabel6.ParentStyleUsing.UseFont = false;
			this.xrLabel6.Size = new System.Drawing.Size(123, 25);
			this.xrLabel6.Text = "Balance:";
			// 
			// xrlblBalance
			// 
			this.xrlblBalance.Location = new System.Drawing.Point(158, 121);
			this.xrlblBalance.Name = "xrlblBalance";
			this.xrlblBalance.Size = new System.Drawing.Size(150, 23);
			// 
			// xrlblPackageID
			// 
			this.xrlblPackageID.Location = new System.Drawing.Point(158, 62);
			this.xrlblPackageID.Name = "xrlblPackageID";
			this.xrlblPackageID.Size = new System.Drawing.Size(150, 23);
			// 
			// xrLabel1
			// 
			this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel1.Location = new System.Drawing.Point(17, 62);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.ParentStyleUsing.UseFont = false;
			this.xrLabel1.Size = new System.Drawing.Size(123, 25);
			this.xrLabel1.Text = "Cr Package ID:";
			// 
			// xrLabel3
			// 
			this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel3.Location = new System.Drawing.Point(17, 33);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.ParentStyleUsing.UseFont = false;
			this.xrLabel3.Size = new System.Drawing.Size(123, 25);
			this.xrLabel3.Text = "Member Name:";
			// 
			// xrlblMemberName
			// 
			this.xrlblMemberName.Location = new System.Drawing.Point(158, 33);
			this.xrlblMemberName.Name = "xrlblMemberName";
			this.xrlblMemberName.Size = new System.Drawing.Size(150, 23);
			this.xrlblMemberName.Text = "xrlblMemberName";
			// 
			// xrlblMembershipID
			// 
			this.xrlblMembershipID.Location = new System.Drawing.Point(158, 4);
			this.xrlblMembershipID.Name = "xrlblMembershipID";
			this.xrlblMembershipID.Size = new System.Drawing.Size(150, 23);
			this.xrlblMembershipID.Text = "xrlblMembershipID";
			// 
			// xrLabel2
			// 
			this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel2.Location = new System.Drawing.Point(17, 4);
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
			this.PageFooter.Height = 0;
			this.PageFooter.Name = "PageFooter";
			// 
			// MemberPackageExpiryReport
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
																		 this.Detail,
																		 this.PageHeader,
																		 this.PageFooter});
			this.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
			this.PageHeight = 500;
			this.PageWidth = 350;
			this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion
	}
}

