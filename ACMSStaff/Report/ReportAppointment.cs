using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ACMS.ACMSStaff.Report
{
	/// <summary>
	/// Summary description for ReportAppointment.
	/// </summary>
	public class ReportAppointment : DevExpress.XtraReports.UI.XtraReport
	{
		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
		private DevExpress.XtraReports.UI.XRLabel xrLabel1;
		private DevExpress.XtraReports.UI.XRTable xrTable1;
		private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
		private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
		private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
		private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
		private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
		private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
		private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
		private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
		private DevExpress.XtraReports.UI.XRTable xrTable2;
		private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
		private DevExpress.XtraReports.UI.XRTableCell xrTableCellDate;
		private DevExpress.XtraReports.UI.XRTableCell xrTableCellStartTime;
		private DevExpress.XtraReports.UI.XRTableCell xrTableCellEndTime;
		private DevExpress.XtraReports.UI.XRTableCell xrTableCellOrganization;
		private DevExpress.XtraReports.UI.XRTableCell xrTableCellContact;
		private DevExpress.XtraReports.UI.XRTableCell xrTableCellAppointmentType;
		private DevExpress.XtraReports.UI.XRTableCell xrTableCellRemarks;
		private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
		private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel2;
		private DevExpress.XtraReports.UI.XRLabel xrLabelName;
		private DevExpress.XtraReports.UI.XRLabel xrLabelID;
		private DevExpress.XtraReports.UI.XRLabel xrLabel3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ReportAppointment(int aEmployeeID, string aEmployeeName)
		{
			//
			// Required for Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			xrLabelID.Text = aEmployeeID.ToString();
			xrLabelName.Text = aEmployeeName;
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
			this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
			this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
			this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
			this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
			this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
			this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
			this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
			this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
			this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
			this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
			this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
			this.xrTableCellDate = new DevExpress.XtraReports.UI.XRTableCell();
			this.xrTableCellStartTime = new DevExpress.XtraReports.UI.XRTableCell();
			this.xrTableCellEndTime = new DevExpress.XtraReports.UI.XRTableCell();
			this.xrTableCellOrganization = new DevExpress.XtraReports.UI.XRTableCell();
			this.xrTableCellContact = new DevExpress.XtraReports.UI.XRTableCell();
			this.xrTableCellAppointmentType = new DevExpress.XtraReports.UI.XRTableCell();
			this.xrTableCellRemarks = new DevExpress.XtraReports.UI.XRTableCell();
			this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
			this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
			this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabelName = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabelID = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
			((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																						this.xrTable2});
			this.Detail.Height = 46;
			this.Detail.Name = "Detail";
			// 
			// PageHeader
			// 
			this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																							this.xrLabel3,
																							this.xrLabelID,
																							this.xrLabelName,
																							this.xrLabel2,
																							this.xrTable1,
																							this.xrLabel1});
			this.PageHeader.Height = 138;
			this.PageHeader.Name = "PageHeader";
			// 
			// xrLabel1
			// 
			this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
			this.xrLabel1.Location = new System.Drawing.Point(275, 8);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.ParentStyleUsing.UseFont = false;
			this.xrLabel1.Size = new System.Drawing.Size(375, 25);
			this.xrLabel1.Text = "Appointment Listing";
			this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			// 
			// xrTable1
			// 
			this.xrTable1.Location = new System.Drawing.Point(17, 108);
			this.xrTable1.Name = "xrTable1";
			this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
																					   this.xrTableRow1});
			this.xrTable1.Size = new System.Drawing.Size(866, 25);
			// 
			// xrTableRow1
			// 
			this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
																							this.xrTableCell7,
																							this.xrTableCell1,
																							this.xrTableCell6,
																							this.xrTableCell2,
																							this.xrTableCell3,
																							this.xrTableCell5,
																							this.xrTableCell4});
			this.xrTableRow1.Name = "xrTableRow1";
			this.xrTableRow1.Size = new System.Drawing.Size(866, 25);
			// 
			// xrTableCell1
			// 
			this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrTableCell1.Location = new System.Drawing.Point(133, 0);
			this.xrTableCell1.Name = "xrTableCell1";
			this.xrTableCell1.ParentStyleUsing.UseFont = false;
			this.xrTableCell1.Size = new System.Drawing.Size(86, 25);
			this.xrTableCell1.Text = "Start Time";
			// 
			// xrTableCell2
			// 
			this.xrTableCell2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrTableCell2.Location = new System.Drawing.Point(310, 0);
			this.xrTableCell2.Name = "xrTableCell2";
			this.xrTableCell2.ParentStyleUsing.UseFont = false;
			this.xrTableCell2.Size = new System.Drawing.Size(225, 25);
			this.xrTableCell2.Text = "Organization / Place of Appointment";
			// 
			// xrTableCell4
			// 
			this.xrTableCell4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrTableCell4.Location = new System.Drawing.Point(786, 0);
			this.xrTableCell4.Name = "xrTableCell4";
			this.xrTableCell4.ParentStyleUsing.UseFont = false;
			this.xrTableCell4.Size = new System.Drawing.Size(80, 25);
			this.xrTableCell4.Text = "Remarks";
			// 
			// xrTableCell3
			// 
			this.xrTableCell3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrTableCell3.Location = new System.Drawing.Point(535, 0);
			this.xrTableCell3.Name = "xrTableCell3";
			this.xrTableCell3.ParentStyleUsing.UseFont = false;
			this.xrTableCell3.Size = new System.Drawing.Size(135, 25);
			this.xrTableCell3.Text = "Contact";
			// 
			// xrTableCell5
			// 
			this.xrTableCell5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrTableCell5.Location = new System.Drawing.Point(670, 0);
			this.xrTableCell5.Name = "xrTableCell5";
			this.xrTableCell5.ParentStyleUsing.UseFont = false;
			this.xrTableCell5.Size = new System.Drawing.Size(116, 25);
			this.xrTableCell5.Text = "Appointment Type";
			// 
			// xrTableCell6
			// 
			this.xrTableCell6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrTableCell6.Location = new System.Drawing.Point(219, 0);
			this.xrTableCell6.Name = "xrTableCell6";
			this.xrTableCell6.ParentStyleUsing.UseFont = false;
			this.xrTableCell6.Size = new System.Drawing.Size(91, 25);
			this.xrTableCell6.Text = "End Time";
			// 
			// xrTableCell7
			// 
			this.xrTableCell7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrTableCell7.Location = new System.Drawing.Point(0, 0);
			this.xrTableCell7.Name = "xrTableCell7";
			this.xrTableCell7.ParentStyleUsing.UseFont = false;
			this.xrTableCell7.Size = new System.Drawing.Size(133, 25);
			this.xrTableCell7.Text = "Date";
			// 
			// xrTable2
			// 
			this.xrTable2.Location = new System.Drawing.Point(17, 8);
			this.xrTable2.Name = "xrTable2";
			this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
																					   this.xrTableRow2});
			this.xrTable2.Size = new System.Drawing.Size(866, 25);
			// 
			// xrTableRow2
			// 
			this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
																							this.xrTableCellDate,
																							this.xrTableCellStartTime,
																							this.xrTableCellEndTime,
																							this.xrTableCellOrganization,
																							this.xrTableCellContact,
																							this.xrTableCellAppointmentType,
																							this.xrTableCellRemarks});
			this.xrTableRow2.Name = "xrTableRow2";
			this.xrTableRow2.Size = new System.Drawing.Size(866, 25);
			// 
			// xrTableCellDate
			// 
			this.xrTableCellDate.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrTableCellDate.Location = new System.Drawing.Point(0, 0);
			this.xrTableCellDate.Name = "xrTableCellDate";
			this.xrTableCellDate.ParentStyleUsing.UseFont = false;
			this.xrTableCellDate.Size = new System.Drawing.Size(133, 25);
			this.xrTableCellDate.Text = "Date";
			// 
			// xrTableCellStartTime
			// 
			this.xrTableCellStartTime.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrTableCellStartTime.Location = new System.Drawing.Point(133, 0);
			this.xrTableCellStartTime.Name = "xrTableCellStartTime";
			this.xrTableCellStartTime.ParentStyleUsing.UseFont = false;
			this.xrTableCellStartTime.Size = new System.Drawing.Size(86, 25);
			this.xrTableCellStartTime.Text = "Start Time";
			// 
			// xrTableCellEndTime
			// 
			this.xrTableCellEndTime.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrTableCellEndTime.Location = new System.Drawing.Point(219, 0);
			this.xrTableCellEndTime.Name = "xrTableCellEndTime";
			this.xrTableCellEndTime.ParentStyleUsing.UseFont = false;
			this.xrTableCellEndTime.Size = new System.Drawing.Size(91, 25);
			this.xrTableCellEndTime.Text = "End Time";
			// 
			// xrTableCellOrganization
			// 
			this.xrTableCellOrganization.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrTableCellOrganization.Location = new System.Drawing.Point(310, 0);
			this.xrTableCellOrganization.Name = "xrTableCellOrganization";
			this.xrTableCellOrganization.ParentStyleUsing.UseFont = false;
			this.xrTableCellOrganization.Size = new System.Drawing.Size(225, 25);
			this.xrTableCellOrganization.Text = "Organization / Place of Appointment";
			// 
			// xrTableCellContact
			// 
			this.xrTableCellContact.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrTableCellContact.Location = new System.Drawing.Point(535, 0);
			this.xrTableCellContact.Name = "xrTableCellContact";
			this.xrTableCellContact.ParentStyleUsing.UseFont = false;
			this.xrTableCellContact.Size = new System.Drawing.Size(135, 25);
			this.xrTableCellContact.Text = "Contact";
			// 
			// xrTableCellAppointmentType
			// 
			this.xrTableCellAppointmentType.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrTableCellAppointmentType.Location = new System.Drawing.Point(670, 0);
			this.xrTableCellAppointmentType.Name = "xrTableCellAppointmentType";
			this.xrTableCellAppointmentType.ParentStyleUsing.UseFont = false;
			this.xrTableCellAppointmentType.Size = new System.Drawing.Size(116, 25);
			this.xrTableCellAppointmentType.Text = "Appointment Type";
			// 
			// xrTableCellRemarks
			// 
			this.xrTableCellRemarks.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrTableCellRemarks.Location = new System.Drawing.Point(786, 0);
			this.xrTableCellRemarks.Name = "xrTableCellRemarks";
			this.xrTableCellRemarks.ParentStyleUsing.UseFont = false;
			this.xrTableCellRemarks.Size = new System.Drawing.Size(80, 25);
			this.xrTableCellRemarks.Text = "Remarks";
			// 
			// BottomMargin
			// 
			this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																							  this.xrPageInfo1});
			this.BottomMargin.Height = 34;
			this.BottomMargin.Name = "BottomMargin";
			// 
			// xrPageInfo1
			// 
			this.xrPageInfo1.Format = "Page : {0 } / {1}";
			this.xrPageInfo1.Location = new System.Drawing.Point(783, 0);
			this.xrPageInfo1.Name = "xrPageInfo1";
			this.xrPageInfo1.Size = new System.Drawing.Size(100, 25);
			// 
			// xrLabel2
			// 
			this.xrLabel2.Location = new System.Drawing.Point(17, 50);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.Size = new System.Drawing.Size(100, 25);
			this.xrLabel2.Text = "Employee ID:";
			// 
			// xrLabelName
			// 
			this.xrLabelName.Location = new System.Drawing.Point(117, 75);
			this.xrLabelName.Name = "xrLabelName";
			this.xrLabelName.Size = new System.Drawing.Size(550, 25);
			this.xrLabelName.Text = "xrLabelName";
			// 
			// xrLabelID
			// 
			this.xrLabelID.Location = new System.Drawing.Point(117, 50);
			this.xrLabelID.Name = "xrLabelID";
			this.xrLabelID.Size = new System.Drawing.Size(283, 25);
			this.xrLabelID.Text = "xrLabelID";
			// 
			// xrLabel3
			// 
			this.xrLabel3.Location = new System.Drawing.Point(17, 75);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.Size = new System.Drawing.Size(100, 25);
			this.xrLabel3.Text = "Employee Name:";
			// 
			// ReportAppointment
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
																		 this.Detail,
																		 this.PageHeader,
																		 this.BottomMargin});
			this.Landscape = true;
			this.Margins = new System.Drawing.Printing.Margins(100, 100, 100, 34);
			((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion

		public void CreateDataBindings()
		{		
			xrTableCellDate.DataBindings.Add("Text", DataSource, "dtDate", "{0:dd/MM/yyyy}");
			xrTableCellStartTime.DataBindings.Add("Text", DataSource, "dtStartTime", "{0,T}");
			xrTableCellEndTime.DataBindings.Add("Text", DataSource, "dtEndTime", "{0:T}");
			xrTableCellOrganization.DataBindings.Add("Text", DataSource, "strOrganization");
			xrTableCellContact.DataBindings.Add("Text", DataSource, "strContact");;
			xrTableCellAppointmentType.DataBindings.Add("Text", DataSource, "nAppointmentTypeID");
			xrTableCellRemarks.DataBindings.Add("Text", DataSource, "strRemarks");
		}
	}
}

