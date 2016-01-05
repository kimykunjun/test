using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using DevExpress.XtraReports.UI;

namespace ACMSLogic.Report
{
	/// <summary>
	/// Summary description for ClassAttendanceReport.
	/// </summary>
	public class ClassAttendanceReport : DevExpress.XtraReports.UI.XtraReport
	{
		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.XRLabel xrLabel1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel2;
		private DevExpress.XtraReports.UI.XRLabel xrLabel7;
		private DevExpress.XtraReports.UI.XRLabel xrLabel8;
		private DevExpress.XtraReports.UI.XRLabel xrLabel9;
		private DevExpress.XtraReports.UI.XRLabel xrlblMemberIDList;
		private DevExpress.XtraReports.UI.XRLabel xrlblVerified;
		private DevExpress.XtraReports.UI.XRLabel xrlblStanding;
		private DevExpress.XtraReports.UI.XRLabel xrlblIntructor;
		private DevExpress.XtraReports.UI.XRLabel xrlblClassCode;
		private DevExpress.XtraReports.UI.XRLabel xrlblClassTime;
		private DevExpress.XtraReports.UI.XRLabel xrlblClassDate;
		private DevExpress.XtraReports.UI.XRLabel xrlblBranchCode;
		private DevExpress.XtraReports.UI.XRLabel xrLabel3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ClassAttendanceReport()
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

		public void CreateDataBindings()
		{
			xrlblBranchCode.DataBindings.Clear();	
			xrlblClassCode.DataBindings.Clear();
			xrlblClassDate.DataBindings.Clear();
			xrlblClassTime.DataBindings.Clear();
			xrlblIntructor.DataBindings.Clear();
			xrlblMemberIDList.DataBindings.Clear();
			xrlblStanding.DataBindings.Clear();
			xrlblVerified.DataBindings.Clear();

			xrlblBranchCode.DataBindings.Add("Text", DataSource, "strBranchCode");	
			xrlblClassCode.DataBindings.Add("Text", DataSource, "strClassCode");
			xrlblClassDate.DataBindings.Add("Text", DataSource, "dtDate", "{0:dd/MM/yyyy}");
			xrlblClassTime.DataBindings.Add("Text", DataSource, "dtStartTime", "{0:t}");
			xrlblIntructor.DataBindings.Add("Text", DataSource, "strActualInstructorName");
			//xrlblMemberIDList.DataBindings.Add("Text", DataSource, "MembershipIDList");
			xrlblStanding.DataBindings.Add("Text", DataSource, "strReplacementInstructorName");
			xrlblVerified.DataBindings.Add("Text", DataSource, "strReplacementVerifyName");
			
			DataTable tableSource = ((DataTable)DataSource);
			
			//

			string memberList = tableSource.Rows[0]["MembershipIDList"].ToString();
			string[] memberListArray = memberList.Split(new char[] {','});
			xrlblMemberIDList.Lines = memberListArray;
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Detail = new DevExpress.XtraReports.UI.DetailBand();
			this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrlblMemberIDList = new DevExpress.XtraReports.UI.XRLabel();
			this.xrlblVerified = new DevExpress.XtraReports.UI.XRLabel();
			this.xrlblStanding = new DevExpress.XtraReports.UI.XRLabel();
			this.xrlblIntructor = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrlblClassCode = new DevExpress.XtraReports.UI.XRLabel();
			this.xrlblClassTime = new DevExpress.XtraReports.UI.XRLabel();
			this.xrlblClassDate = new DevExpress.XtraReports.UI.XRLabel();
			this.xrlblBranchCode = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																						this.xrLabel3,
																						this.xrlblMemberIDList,
																						this.xrlblVerified,
																						this.xrlblStanding,
																						this.xrlblIntructor,
																						this.xrLabel9,
																						this.xrLabel8,
																						this.xrLabel7,
																						this.xrlblClassCode,
																						this.xrlblClassTime,
																						this.xrlblClassDate,
																						this.xrlblBranchCode,
																						this.xrLabel2,
																						this.xrLabel1});
			this.Detail.Height = 273;
			this.Detail.Name = "Detail";
			// 
			// xrLabel3
			// 
			this.xrLabel3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel3.Location = new System.Drawing.Point(12, 146);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.ParentStyleUsing.UseFont = false;
			this.xrLabel3.Size = new System.Drawing.Size(326, 16);
			this.xrLabel3.Text = "PLEASE FILE ATTENDANCE FOR A WEEK";
			// 
			// xrlblMemberIDList
			// 
			this.xrlblMemberIDList.CanShrink = true;
			this.xrlblMemberIDList.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrlblMemberIDList.KeepTogether = true;
			this.xrlblMemberIDList.Location = new System.Drawing.Point(12, 167);
			this.xrlblMemberIDList.Multiline = true;
			this.xrlblMemberIDList.Name = "xrlblMemberIDList";
			this.xrlblMemberIDList.ParentStyleUsing.UseFont = false;
			this.xrlblMemberIDList.Size = new System.Drawing.Size(371, 87);
			this.xrlblMemberIDList.Text = "xrLabel3";
			// 
			// xrlblVerified
			// 
			this.xrlblVerified.Font = new System.Drawing.Font("Arial", 8F);
			this.xrlblVerified.Location = new System.Drawing.Point(121, 112);
			this.xrlblVerified.Name = "xrlblVerified";
			this.xrlblVerified.ParentStyleUsing.UseFont = false;
			this.xrlblVerified.Size = new System.Drawing.Size(262, 26);
			// 
			// xrlblStanding
			// 
			this.xrlblStanding.Font = new System.Drawing.Font("Arial", 8F);
			this.xrlblStanding.Location = new System.Drawing.Point(121, 88);
			this.xrlblStanding.Name = "xrlblStanding";
			this.xrlblStanding.ParentStyleUsing.UseFont = false;
			this.xrlblStanding.Size = new System.Drawing.Size(262, 24);
			// 
			// xrlblIntructor
			// 
			this.xrlblIntructor.Font = new System.Drawing.Font("Arial", 8F);
			this.xrlblIntructor.Location = new System.Drawing.Point(121, 62);
			this.xrlblIntructor.Name = "xrlblIntructor";
			this.xrlblIntructor.ParentStyleUsing.UseFont = false;
			this.xrlblIntructor.Size = new System.Drawing.Size(262, 26);
			// 
			// xrLabel9
			// 
			this.xrLabel9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel9.Location = new System.Drawing.Point(12, 112);
			this.xrLabel9.Name = "xrLabel9";
			this.xrLabel9.ParentStyleUsing.UseFont = false;
			this.xrLabel9.Size = new System.Drawing.Size(100, 25);
			this.xrLabel9.Text = "VERIFIED BY:";
			// 
			// xrLabel8
			// 
			this.xrLabel8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel8.Location = new System.Drawing.Point(12, 88);
			this.xrLabel8.Name = "xrLabel8";
			this.xrLabel8.ParentStyleUsing.UseFont = false;
			this.xrLabel8.Size = new System.Drawing.Size(100, 25);
			this.xrLabel8.Text = "STANDING:";
			// 
			// xrLabel7
			// 
			this.xrLabel7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel7.Location = new System.Drawing.Point(12, 62);
			this.xrLabel7.Name = "xrLabel7";
			this.xrLabel7.ParentStyleUsing.UseFont = false;
			this.xrLabel7.Size = new System.Drawing.Size(100, 25);
			this.xrLabel7.Text = "INSTRUCTOR: ";
			// 
			// xrlblClassCode
			// 
			this.xrlblClassCode.Font = new System.Drawing.Font("Arial", 8F);
			this.xrlblClassCode.Location = new System.Drawing.Point(288, 33);
			this.xrlblClassCode.Name = "xrlblClassCode";
			this.xrlblClassCode.ParentStyleUsing.UseFont = false;
			this.xrlblClassCode.Size = new System.Drawing.Size(96, 26);
			// 
			// xrlblClassTime
			// 
			this.xrlblClassTime.Font = new System.Drawing.Font("Arial", 8F);
			this.xrlblClassTime.Location = new System.Drawing.Point(225, 33);
			this.xrlblClassTime.Name = "xrlblClassTime";
			this.xrlblClassTime.ParentStyleUsing.UseFont = false;
			this.xrlblClassTime.Size = new System.Drawing.Size(59, 25);
			// 
			// xrlblClassDate
			// 
			this.xrlblClassDate.Font = new System.Drawing.Font("Arial", 8F);
			this.xrlblClassDate.Location = new System.Drawing.Point(150, 33);
			this.xrlblClassDate.Name = "xrlblClassDate";
			this.xrlblClassDate.ParentStyleUsing.UseFont = false;
			this.xrlblClassDate.Size = new System.Drawing.Size(71, 25);
			// 
			// xrlblBranchCode
			// 
			this.xrlblBranchCode.Font = new System.Drawing.Font("Arial", 8F);
			this.xrlblBranchCode.Location = new System.Drawing.Point(92, 33);
			this.xrlblBranchCode.Name = "xrlblBranchCode";
			this.xrlblBranchCode.ParentStyleUsing.UseFont = false;
			this.xrlblBranchCode.Size = new System.Drawing.Size(54, 25);
			// 
			// xrLabel2
			// 
			this.xrLabel2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.xrLabel2.Location = new System.Drawing.Point(12, 33);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.ParentStyleUsing.UseFont = false;
			this.xrLabel2.Size = new System.Drawing.Size(76, 25);
			this.xrLabel2.Text = "BRANCH: ";
			// 
			// xrLabel1
			// 
			this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel1.Location = new System.Drawing.Point(12, 4);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.ParentStyleUsing.UseFont = false;
			this.xrLabel1.Size = new System.Drawing.Size(371, 21);
			this.xrLabel1.Text = "CLASS ATTENDANCE";
			// 
			// ClassAttendanceReport
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
																		 this.Detail});
			this.Margins = new System.Drawing.Printing.Margins(0, 21, 10, 10);
			this.PageHeight = 583;
			this.PageWidth = 405;
			this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion
	}
}

