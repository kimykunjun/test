using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

namespace ACMS.ACMSBranch.BranchTransaction
{
	/// <summary>
	/// Summary description for rptRoster.
	/// </summary>
	public class rptRoster : DevExpress.XtraReports.UI.XtraReport
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
		private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
		private DevExpress.XtraReports.UI.XRLabel xrLabel1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel2;
		private DevExpress.XtraReports.UI.XRLabel xrLabel4;
		private DevExpress.XtraReports.UI.XRLabel xrLabel5;
		private DevExpress.XtraReports.UI.XRLabel xrLabel6;
		private DevExpress.XtraReports.UI.XRLabel xrLabel7;
		private DevExpress.XtraReports.UI.XRLabel xrLabel8;
		private DevExpress.XtraReports.UI.XRLabel xrLabel9;
		private DevExpress.XtraReports.UI.XRLabel xrLabel10;
		public DevExpress.XtraReports.UI.XRLabel txtMonDate;
		public DevExpress.XtraReports.UI.XRLabel txtTueDate;
		public DevExpress.XtraReports.UI.XRLabel txtWedDate;
		public DevExpress.XtraReports.UI.XRLabel txtThuDate;
		public DevExpress.XtraReports.UI.XRLabel txtFriDate;
		public DevExpress.XtraReports.UI.XRLabel txtSatDate;
		public DevExpress.XtraReports.UI.XRLabel txtSunDate;
		public DevExpress.XtraReports.UI.XRLabel lblEmpID;
		public DevExpress.XtraReports.UI.XRLabel lblEmpName;
		public DevExpress.XtraReports.UI.XRLabel lblEmpDept;
		public DevExpress.XtraReports.UI.XRLabel TotalHourWrk;
		public DevExpress.XtraReports.UI.XRLabel MonSTime;
		public DevExpress.XtraReports.UI.XRLabel MonETime;
		public DevExpress.XtraReports.UI.XRLabel SunSTime;
		public DevExpress.XtraReports.UI.XRLabel ThuSTime;
		public DevExpress.XtraReports.UI.XRLabel WedSTime;
		public DevExpress.XtraReports.UI.XRLabel FriSTime;
		public DevExpress.XtraReports.UI.XRLabel SatSTime;
		public DevExpress.XtraReports.UI.XRLabel TueSTime;
		public DevExpress.XtraReports.UI.XRLabel WedETime;
		public DevExpress.XtraReports.UI.XRLabel FriETime;
		public DevExpress.XtraReports.UI.XRLabel SatETime;
		public DevExpress.XtraReports.UI.XRLabel TueETime;
		public DevExpress.XtraReports.UI.XRLabel SunETime;
		public DevExpress.XtraReports.UI.XRLabel ThuETime;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public rptRoster()
		{
			//
			// Required for Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
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
			this.ThuETime = new DevExpress.XtraReports.UI.XRLabel();
			this.SunETime = new DevExpress.XtraReports.UI.XRLabel();
			this.TueETime = new DevExpress.XtraReports.UI.XRLabel();
			this.SatETime = new DevExpress.XtraReports.UI.XRLabel();
			this.FriETime = new DevExpress.XtraReports.UI.XRLabel();
			this.WedETime = new DevExpress.XtraReports.UI.XRLabel();
			this.MonETime = new DevExpress.XtraReports.UI.XRLabel();
			this.lblEmpDept = new DevExpress.XtraReports.UI.XRLabel();
			this.lblEmpName = new DevExpress.XtraReports.UI.XRLabel();
			this.lblEmpID = new DevExpress.XtraReports.UI.XRLabel();
			this.SunSTime = new DevExpress.XtraReports.UI.XRLabel();
			this.ThuSTime = new DevExpress.XtraReports.UI.XRLabel();
			this.TotalHourWrk = new DevExpress.XtraReports.UI.XRLabel();
			this.WedSTime = new DevExpress.XtraReports.UI.XRLabel();
			this.FriSTime = new DevExpress.XtraReports.UI.XRLabel();
			this.SatSTime = new DevExpress.XtraReports.UI.XRLabel();
			this.TueSTime = new DevExpress.XtraReports.UI.XRLabel();
			this.MonSTime = new DevExpress.XtraReports.UI.XRLabel();
			this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
			this.txtSunDate = new DevExpress.XtraReports.UI.XRLabel();
			this.txtSatDate = new DevExpress.XtraReports.UI.XRLabel();
			this.txtFriDate = new DevExpress.XtraReports.UI.XRLabel();
			this.txtThuDate = new DevExpress.XtraReports.UI.XRLabel();
			this.txtWedDate = new DevExpress.XtraReports.UI.XRLabel();
			this.txtTueDate = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
			this.txtMonDate = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																						this.WedETime,
																						this.ThuETime,
																						this.SunETime,
																						this.TueETime,
																						this.SatETime,
																						this.FriETime,
																						this.MonETime,
																						this.lblEmpDept,
																						this.lblEmpName,
																						this.lblEmpID,
																						this.SunSTime,
																						this.ThuSTime,
																						this.TotalHourWrk,
																						this.WedSTime,
																						this.FriSTime,
																						this.SatSTime,
																						this.TueSTime,
																						this.MonSTime});
			this.Detail.Height = 50;
			this.Detail.Name = "Detail";
			this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
			// 
			// ThuETime
			// 
			this.ThuETime.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ThuETime.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
				| DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.ThuETime.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.ThuETime.Location = new System.Drawing.Point(371, 25);
			this.ThuETime.Name = "ThuETime";
			this.ThuETime.ParentStyleUsing.UseBackColor = false;
			this.ThuETime.ParentStyleUsing.UseBorders = false;
			this.ThuETime.ParentStyleUsing.UseFont = false;
			this.ThuETime.Size = new System.Drawing.Size(72, 25);
			this.ThuETime.Text = "THUR";
			this.ThuETime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			// 
			// SunETime
			// 
			this.SunETime.BackColor = System.Drawing.Color.WhiteSmoke;
			this.SunETime.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
				| DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.SunETime.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.SunETime.Location = new System.Drawing.Point(583, 25);
			this.SunETime.Name = "SunETime";
			this.SunETime.ParentStyleUsing.UseBackColor = false;
			this.SunETime.ParentStyleUsing.UseBorders = false;
			this.SunETime.ParentStyleUsing.UseFont = false;
			this.SunETime.Size = new System.Drawing.Size(72, 25);
			this.SunETime.Text = "SUN";
			this.SunETime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			// 
			// TueETime
			// 
			this.TueETime.BackColor = System.Drawing.Color.WhiteSmoke;
			this.TueETime.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
				| DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.TueETime.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.TueETime.Location = new System.Drawing.Point(230, 25);
			this.TueETime.Name = "TueETime";
			this.TueETime.ParentStyleUsing.UseBackColor = false;
			this.TueETime.ParentStyleUsing.UseBorders = false;
			this.TueETime.ParentStyleUsing.UseFont = false;
			this.TueETime.Size = new System.Drawing.Size(72, 25);
			this.TueETime.Text = "22-02-2006";
			this.TueETime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			// 
			// SatETime
			// 
			this.SatETime.BackColor = System.Drawing.Color.WhiteSmoke;
			this.SatETime.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
				| DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.SatETime.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.SatETime.Location = new System.Drawing.Point(514, 25);
			this.SatETime.Name = "SatETime";
			this.SatETime.ParentStyleUsing.UseBackColor = false;
			this.SatETime.ParentStyleUsing.UseBorders = false;
			this.SatETime.ParentStyleUsing.UseFont = false;
			this.SatETime.Size = new System.Drawing.Size(72, 25);
			this.SatETime.Text = "SAT";
			this.SatETime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			// 
			// FriETime
			// 
			this.FriETime.BackColor = System.Drawing.Color.WhiteSmoke;
			this.FriETime.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
				| DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.FriETime.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.FriETime.Location = new System.Drawing.Point(442, 25);
			this.FriETime.Name = "FriETime";
			this.FriETime.ParentStyleUsing.UseBackColor = false;
			this.FriETime.ParentStyleUsing.UseBorders = false;
			this.FriETime.ParentStyleUsing.UseFont = false;
			this.FriETime.Size = new System.Drawing.Size(72, 25);
			this.FriETime.Text = "FRI";
			this.FriETime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			// 
			// WedETime
			// 
			this.WedETime.BackColor = System.Drawing.Color.WhiteSmoke;
			this.WedETime.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
				| DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.WedETime.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.WedETime.Location = new System.Drawing.Point(300, 25);
			this.WedETime.Name = "WedETime";
			this.WedETime.ParentStyleUsing.UseBackColor = false;
			this.WedETime.ParentStyleUsing.UseBorders = false;
			this.WedETime.ParentStyleUsing.UseFont = false;
			this.WedETime.Size = new System.Drawing.Size(72, 25);
			this.WedETime.Text = "WED";
			this.WedETime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			// 
			// MonETime
			// 
			this.MonETime.BackColor = System.Drawing.Color.WhiteSmoke;
			this.MonETime.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
				| DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.MonETime.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.MonETime.Location = new System.Drawing.Point(158, 25);
			this.MonETime.Name = "MonETime";
			this.MonETime.ParentStyleUsing.UseBackColor = false;
			this.MonETime.ParentStyleUsing.UseBorders = false;
			this.MonETime.ParentStyleUsing.UseFont = false;
			this.MonETime.Size = new System.Drawing.Size(72, 25);
			this.MonETime.Text = "MON";
			this.MonETime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			// 
			// lblEmpDept
			// 
			this.lblEmpDept.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblEmpDept.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
				| DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.lblEmpDept.CanGrow = false;
			this.lblEmpDept.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.lblEmpDept.Location = new System.Drawing.Point(8, 33);
			this.lblEmpDept.Name = "lblEmpDept";
			this.lblEmpDept.ParentStyleUsing.UseBackColor = false;
			this.lblEmpDept.ParentStyleUsing.UseBorders = false;
			this.lblEmpDept.ParentStyleUsing.UseFont = false;
			this.lblEmpDept.Size = new System.Drawing.Size(150, 17);
			this.lblEmpDept.Text = "MON";
			this.lblEmpDept.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
			// 
			// lblEmpName
			// 
			this.lblEmpName.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblEmpName.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)));
			this.lblEmpName.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.lblEmpName.Location = new System.Drawing.Point(8, 17);
			this.lblEmpName.Name = "lblEmpName";
			this.lblEmpName.ParentStyleUsing.UseBackColor = false;
			this.lblEmpName.ParentStyleUsing.UseBorders = false;
			this.lblEmpName.ParentStyleUsing.UseFont = false;
			this.lblEmpName.Size = new System.Drawing.Size(150, 17);
			this.lblEmpName.Text = "KONG ";
			this.lblEmpName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
			// 
			// lblEmpID
			// 
			this.lblEmpID.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lblEmpID.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
				| DevExpress.XtraPrinting.BorderSide.Right)));
			this.lblEmpID.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.lblEmpID.Location = new System.Drawing.Point(8, 0);
			this.lblEmpID.Name = "lblEmpID";
			this.lblEmpID.ParentStyleUsing.UseBackColor = false;
			this.lblEmpID.ParentStyleUsing.UseBorders = false;
			this.lblEmpID.ParentStyleUsing.UseFont = false;
			this.lblEmpID.Size = new System.Drawing.Size(150, 17);
			this.lblEmpID.Text = "102";
			this.lblEmpID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
			// 
			// SunSTime
			// 
			this.SunSTime.BackColor = System.Drawing.Color.WhiteSmoke;
			this.SunSTime.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
				| DevExpress.XtraPrinting.BorderSide.Right)));
			this.SunSTime.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.SunSTime.Location = new System.Drawing.Point(583, 0);
			this.SunSTime.Name = "SunSTime";
			this.SunSTime.ParentStyleUsing.UseBackColor = false;
			this.SunSTime.ParentStyleUsing.UseBorders = false;
			this.SunSTime.ParentStyleUsing.UseFont = false;
			this.SunSTime.Size = new System.Drawing.Size(72, 25);
			this.SunSTime.Text = "SUN";
			this.SunSTime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
			// 
			// ThuSTime
			// 
			this.ThuSTime.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ThuSTime.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
				| DevExpress.XtraPrinting.BorderSide.Right)));
			this.ThuSTime.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.ThuSTime.Location = new System.Drawing.Point(371, 0);
			this.ThuSTime.Name = "ThuSTime";
			this.ThuSTime.ParentStyleUsing.UseBackColor = false;
			this.ThuSTime.ParentStyleUsing.UseBorders = false;
			this.ThuSTime.ParentStyleUsing.UseFont = false;
			this.ThuSTime.Size = new System.Drawing.Size(72, 25);
			this.ThuSTime.Text = "THUR";
			this.ThuSTime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
			// 
			// TotalHourWrk
			// 
			this.TotalHourWrk.BackColor = System.Drawing.Color.WhiteSmoke;
			this.TotalHourWrk.Borders = DevExpress.XtraPrinting.BorderSide.All;
			this.TotalHourWrk.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.TotalHourWrk.Location = new System.Drawing.Point(655, 0);
			this.TotalHourWrk.Name = "TotalHourWrk";
			this.TotalHourWrk.ParentStyleUsing.UseBackColor = false;
			this.TotalHourWrk.ParentStyleUsing.UseBorders = false;
			this.TotalHourWrk.ParentStyleUsing.UseFont = false;
			this.TotalHourWrk.Size = new System.Drawing.Size(72, 50);
			this.TotalHourWrk.Text = "TOTAL HOUR";
			this.TotalHourWrk.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// WedSTime
			// 
			this.WedSTime.BackColor = System.Drawing.Color.WhiteSmoke;
			this.WedSTime.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
				| DevExpress.XtraPrinting.BorderSide.Right)));
			this.WedSTime.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.WedSTime.Location = new System.Drawing.Point(300, 0);
			this.WedSTime.Name = "WedSTime";
			this.WedSTime.ParentStyleUsing.UseBackColor = false;
			this.WedSTime.ParentStyleUsing.UseBorders = false;
			this.WedSTime.ParentStyleUsing.UseFont = false;
			this.WedSTime.Size = new System.Drawing.Size(72, 25);
			this.WedSTime.Text = "WED";
			this.WedSTime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
			// 
			// FriSTime
			// 
			this.FriSTime.BackColor = System.Drawing.Color.WhiteSmoke;
			this.FriSTime.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
				| DevExpress.XtraPrinting.BorderSide.Right)));
			this.FriSTime.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.FriSTime.Location = new System.Drawing.Point(442, 0);
			this.FriSTime.Name = "FriSTime";
			this.FriSTime.ParentStyleUsing.UseBackColor = false;
			this.FriSTime.ParentStyleUsing.UseBorders = false;
			this.FriSTime.ParentStyleUsing.UseFont = false;
			this.FriSTime.Size = new System.Drawing.Size(72, 25);
			this.FriSTime.Text = "FRI";
			this.FriSTime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
			// 
			// SatSTime
			// 
			this.SatSTime.BackColor = System.Drawing.Color.WhiteSmoke;
			this.SatSTime.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
				| DevExpress.XtraPrinting.BorderSide.Right)));
			this.SatSTime.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.SatSTime.Location = new System.Drawing.Point(514, 0);
			this.SatSTime.Name = "SatSTime";
			this.SatSTime.ParentStyleUsing.UseBackColor = false;
			this.SatSTime.ParentStyleUsing.UseBorders = false;
			this.SatSTime.ParentStyleUsing.UseFont = false;
			this.SatSTime.Size = new System.Drawing.Size(72, 25);
			this.SatSTime.Text = "SAT";
			this.SatSTime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
			// 
			// TueSTime
			// 
			this.TueSTime.BackColor = System.Drawing.Color.WhiteSmoke;
			this.TueSTime.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
				| DevExpress.XtraPrinting.BorderSide.Right)));
			this.TueSTime.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.TueSTime.Location = new System.Drawing.Point(230, 0);
			this.TueSTime.Name = "TueSTime";
			this.TueSTime.ParentStyleUsing.UseBackColor = false;
			this.TueSTime.ParentStyleUsing.UseBorders = false;
			this.TueSTime.ParentStyleUsing.UseFont = false;
			this.TueSTime.Size = new System.Drawing.Size(72, 25);
			this.TueSTime.Text = "22-02-2006";
			this.TueSTime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
			// 
			// MonSTime
			// 
			this.MonSTime.BackColor = System.Drawing.Color.WhiteSmoke;
			this.MonSTime.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
				| DevExpress.XtraPrinting.BorderSide.Right)));
			this.MonSTime.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.MonSTime.Location = new System.Drawing.Point(158, 0);
			this.MonSTime.Name = "MonSTime";
			this.MonSTime.ParentStyleUsing.UseBackColor = false;
			this.MonSTime.ParentStyleUsing.UseBorders = false;
			this.MonSTime.ParentStyleUsing.UseFont = false;
			this.MonSTime.Size = new System.Drawing.Size(72, 25);
			this.MonSTime.Text = "MON";
			this.MonSTime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
			// 
			// PageHeader
			// 
			this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
																							this.txtSunDate,
																							this.txtSatDate,
																							this.txtFriDate,
																							this.txtThuDate,
																							this.txtWedDate,
																							this.txtTueDate,
																							this.xrLabel10,
																							this.xrLabel9,
																							this.xrLabel8,
																							this.xrLabel7,
																							this.xrLabel6,
																							this.xrLabel5,
																							this.xrLabel4,
																							this.txtMonDate,
																							this.xrLabel2,
																							this.xrLabel1});
			this.PageHeader.Height = 33;
			this.PageHeader.Name = "PageHeader";
			// 
			// txtSunDate
			// 
			this.txtSunDate.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtSunDate.Borders = DevExpress.XtraPrinting.BorderSide.All;
			this.txtSunDate.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.txtSunDate.Location = new System.Drawing.Point(583, 17);
			this.txtSunDate.Name = "txtSunDate";
			this.txtSunDate.ParentStyleUsing.UseBackColor = false;
			this.txtSunDate.ParentStyleUsing.UseBorders = false;
			this.txtSunDate.ParentStyleUsing.UseFont = false;
			this.txtSunDate.Size = new System.Drawing.Size(72, 16);
			this.txtSunDate.Text = "SUN";
			this.txtSunDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// txtSatDate
			// 
			this.txtSatDate.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtSatDate.Borders = DevExpress.XtraPrinting.BorderSide.All;
			this.txtSatDate.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.txtSatDate.Location = new System.Drawing.Point(514, 17);
			this.txtSatDate.Name = "txtSatDate";
			this.txtSatDate.ParentStyleUsing.UseBackColor = false;
			this.txtSatDate.ParentStyleUsing.UseBorders = false;
			this.txtSatDate.ParentStyleUsing.UseFont = false;
			this.txtSatDate.Size = new System.Drawing.Size(72, 16);
			this.txtSatDate.Text = "SAT";
			this.txtSatDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// txtFriDate
			// 
			this.txtFriDate.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtFriDate.Borders = DevExpress.XtraPrinting.BorderSide.All;
			this.txtFriDate.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.txtFriDate.Location = new System.Drawing.Point(442, 17);
			this.txtFriDate.Name = "txtFriDate";
			this.txtFriDate.ParentStyleUsing.UseBackColor = false;
			this.txtFriDate.ParentStyleUsing.UseBorders = false;
			this.txtFriDate.ParentStyleUsing.UseFont = false;
			this.txtFriDate.Size = new System.Drawing.Size(72, 16);
			this.txtFriDate.Text = "FRI";
			this.txtFriDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// txtThuDate
			// 
			this.txtThuDate.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtThuDate.Borders = DevExpress.XtraPrinting.BorderSide.All;
			this.txtThuDate.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.txtThuDate.Location = new System.Drawing.Point(371, 17);
			this.txtThuDate.Name = "txtThuDate";
			this.txtThuDate.ParentStyleUsing.UseBackColor = false;
			this.txtThuDate.ParentStyleUsing.UseBorders = false;
			this.txtThuDate.ParentStyleUsing.UseFont = false;
			this.txtThuDate.Size = new System.Drawing.Size(72, 16);
			this.txtThuDate.Text = "THUR";
			this.txtThuDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// txtWedDate
			// 
			this.txtWedDate.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtWedDate.Borders = DevExpress.XtraPrinting.BorderSide.All;
			this.txtWedDate.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.txtWedDate.Location = new System.Drawing.Point(300, 17);
			this.txtWedDate.Name = "txtWedDate";
			this.txtWedDate.ParentStyleUsing.UseBackColor = false;
			this.txtWedDate.ParentStyleUsing.UseBorders = false;
			this.txtWedDate.ParentStyleUsing.UseFont = false;
			this.txtWedDate.Size = new System.Drawing.Size(72, 16);
			this.txtWedDate.Text = "WED";
			this.txtWedDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// txtTueDate
			// 
			this.txtTueDate.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtTueDate.Borders = DevExpress.XtraPrinting.BorderSide.All;
			this.txtTueDate.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.txtTueDate.Location = new System.Drawing.Point(230, 17);
			this.txtTueDate.Name = "txtTueDate";
			this.txtTueDate.ParentStyleUsing.UseBackColor = false;
			this.txtTueDate.ParentStyleUsing.UseBorders = false;
			this.txtTueDate.ParentStyleUsing.UseFont = false;
			this.txtTueDate.Size = new System.Drawing.Size(72, 16);
			this.txtTueDate.Text = "22-02-2006";
			this.txtTueDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// xrLabel10
			// 
			this.xrLabel10.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.All;
			this.xrLabel10.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel10.Location = new System.Drawing.Point(655, 0);
			this.xrLabel10.Name = "xrLabel10";
			this.xrLabel10.ParentStyleUsing.UseBackColor = false;
			this.xrLabel10.ParentStyleUsing.UseBorders = false;
			this.xrLabel10.ParentStyleUsing.UseFont = false;
			this.xrLabel10.Size = new System.Drawing.Size(72, 33);
			this.xrLabel10.Text = "TOTAL HOUR";
			this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// xrLabel9
			// 
			this.xrLabel9.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xrLabel9.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
				| DevExpress.XtraPrinting.BorderSide.Right)));
			this.xrLabel9.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel9.Location = new System.Drawing.Point(583, 0);
			this.xrLabel9.Name = "xrLabel9";
			this.xrLabel9.ParentStyleUsing.UseBackColor = false;
			this.xrLabel9.ParentStyleUsing.UseBorders = false;
			this.xrLabel9.ParentStyleUsing.UseFont = false;
			this.xrLabel9.Size = new System.Drawing.Size(72, 17);
			this.xrLabel9.Text = "SUN";
			this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// xrLabel8
			// 
			this.xrLabel8.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xrLabel8.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
				| DevExpress.XtraPrinting.BorderSide.Right)));
			this.xrLabel8.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel8.Location = new System.Drawing.Point(514, 0);
			this.xrLabel8.Name = "xrLabel8";
			this.xrLabel8.ParentStyleUsing.UseBackColor = false;
			this.xrLabel8.ParentStyleUsing.UseBorders = false;
			this.xrLabel8.ParentStyleUsing.UseFont = false;
			this.xrLabel8.Size = new System.Drawing.Size(72, 17);
			this.xrLabel8.Text = "SAT";
			this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// xrLabel7
			// 
			this.xrLabel7.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xrLabel7.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
				| DevExpress.XtraPrinting.BorderSide.Right)));
			this.xrLabel7.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel7.Location = new System.Drawing.Point(442, 0);
			this.xrLabel7.Name = "xrLabel7";
			this.xrLabel7.ParentStyleUsing.UseBackColor = false;
			this.xrLabel7.ParentStyleUsing.UseBorders = false;
			this.xrLabel7.ParentStyleUsing.UseFont = false;
			this.xrLabel7.Size = new System.Drawing.Size(72, 17);
			this.xrLabel7.Text = "FRI";
			this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// xrLabel6
			// 
			this.xrLabel6.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xrLabel6.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
				| DevExpress.XtraPrinting.BorderSide.Right)));
			this.xrLabel6.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel6.Location = new System.Drawing.Point(371, 0);
			this.xrLabel6.Name = "xrLabel6";
			this.xrLabel6.ParentStyleUsing.UseBackColor = false;
			this.xrLabel6.ParentStyleUsing.UseBorders = false;
			this.xrLabel6.ParentStyleUsing.UseFont = false;
			this.xrLabel6.Size = new System.Drawing.Size(72, 17);
			this.xrLabel6.Text = "THU";
			this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// xrLabel5
			// 
			this.xrLabel5.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xrLabel5.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
				| DevExpress.XtraPrinting.BorderSide.Right)));
			this.xrLabel5.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel5.Location = new System.Drawing.Point(300, 0);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.ParentStyleUsing.UseBackColor = false;
			this.xrLabel5.ParentStyleUsing.UseBorders = false;
			this.xrLabel5.ParentStyleUsing.UseFont = false;
			this.xrLabel5.Size = new System.Drawing.Size(72, 17);
			this.xrLabel5.Text = "WED";
			this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// xrLabel4
			// 
			this.xrLabel4.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xrLabel4.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
				| DevExpress.XtraPrinting.BorderSide.Right)));
			this.xrLabel4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel4.Location = new System.Drawing.Point(230, 0);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.ParentStyleUsing.UseBackColor = false;
			this.xrLabel4.ParentStyleUsing.UseBorders = false;
			this.xrLabel4.ParentStyleUsing.UseFont = false;
			this.xrLabel4.Size = new System.Drawing.Size(72, 17);
			this.xrLabel4.Text = "TUE";
			this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// txtMonDate
			// 
			this.txtMonDate.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtMonDate.Borders = DevExpress.XtraPrinting.BorderSide.All;
			this.txtMonDate.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.txtMonDate.Location = new System.Drawing.Point(158, 17);
			this.txtMonDate.Name = "txtMonDate";
			this.txtMonDate.ParentStyleUsing.UseBackColor = false;
			this.txtMonDate.ParentStyleUsing.UseBorders = false;
			this.txtMonDate.ParentStyleUsing.UseFont = false;
			this.txtMonDate.Size = new System.Drawing.Size(72, 16);
			this.txtMonDate.Text = "MON";
			this.txtMonDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// xrLabel2
			// 
			this.xrLabel2.BackColor = System.Drawing.Color.WhiteSmoke;
			this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
				| DevExpress.XtraPrinting.BorderSide.Right)));
			this.xrLabel2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel2.Location = new System.Drawing.Point(158, 0);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.ParentStyleUsing.UseBackColor = false;
			this.xrLabel2.ParentStyleUsing.UseBorders = false;
			this.xrLabel2.ParentStyleUsing.UseFont = false;
			this.xrLabel2.Size = new System.Drawing.Size(72, 17);
			this.xrLabel2.Text = "MON";
			this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// xrLabel1
			// 
			this.xrLabel1.BackColor = System.Drawing.SystemColors.Control;
			this.xrLabel1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel1.Location = new System.Drawing.Point(8, 0);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.ParentStyleUsing.UseBackColor = false;
			this.xrLabel1.ParentStyleUsing.UseFont = false;
			this.xrLabel1.Size = new System.Drawing.Size(150, 33);
			this.xrLabel1.Text = "STAFF NAME / DATE";
			this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// PageFooter
			// 
			this.PageFooter.Height = 1;
			this.PageFooter.Name = "PageFooter";
			// 
			// rptRoster
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
																		 this.Detail,
																		 this.PageHeader,
																		 this.PageFooter});
			this.Margins = new System.Drawing.Printing.Margins(50, 50, 100, 10);
			this.PageHeight = 1169;
			this.PageWidth = 827;
			this.PaperKind = System.Drawing.Printing.PaperKind.A4;
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion

		private DataTable _roster;
		private DataTable _rosterDetl;
		public DataTable dtRoster
		{
			get
			{
				return _roster;
			}
			set
			{
				_roster = value;
			}
		}
		
		public DataTable dtRosterDetail
		{
			get
			{
				return _rosterDetl;
			}
			set
			{
				_rosterDetl = value;
			}
		}

		public void init()
		{
			//DataSet _ds;

			this.SuspendLayout();
			//int y=-1;
			foreach ( DataRow dr in dtRoster.Rows )
			{
			
				int i = Convert.ToInt32( dr["week_day"].ToString() );
				this.txtSunDate.Text = Convert.ToDateTime( dr["today"].ToString() ).AddDays(8-i).ToString("dd-MM-yyyy");
				this.txtMonDate.Text = Convert.ToDateTime( dr["today"].ToString() ).AddDays(2-i).ToString("dd-MM-yyyy");
				this.txtTueDate.Text = Convert.ToDateTime( dr["today"].ToString() ).AddDays(3-i).ToString("dd-MM-yyyy");
				this.txtWedDate.Text = Convert.ToDateTime( dr["today"].ToString() ).AddDays(4-i).ToString("dd-MM-yyyy");
				this.txtThuDate.Text = Convert.ToDateTime( dr["today"].ToString() ).AddDays(5-i).ToString("dd-MM-yyyy");
				this.txtFriDate.Text = Convert.ToDateTime( dr["today"].ToString() ).AddDays(6-i).ToString("dd-MM-yyyy");
				this.txtSatDate.Text = Convert.ToDateTime( dr["today"].ToString() ).AddDays(7-i).ToString("dd-MM-yyyy");
			}
/*
			panelRosterDetails.DataBindings.Clear();
			panelRosterDetails.Controls.Remove(ACMSRosterDetails1);	
			panelRosterDetails.Controls.Clear();

			foreach ( DataRow dr1 in dtRosterDetail.Rows )
			{
				this.ACMSRosterDetails1 = new ACMSRosterDetails();
				this.ACMSRosterDetails1.Location = new System.Drawing.Point(0, y);
				this.ACMSRosterDetails1.Name = "ACMSRosterDetails1";
				this.ACMSRosterDetails1.Size = new System.Drawing.Size(792, 54);
				this.ACMSRosterDetails1.TabIndex = 0;
				this.ACMSRosterDetails1.Click += new System.EventHandler(this._Click);
				y = y+55;
				this.ACMSRosterDetails1.year = dr1["rYear"].ToString();
				this.ACMSRosterDetails1.WeekNo = dr1["Week_No"].ToString();
				this.ACMSRosterDetails1.lblEmpID.Text = dr1["nEmployeeID"].ToString();
				this.ACMSRosterDetails1.lblEmpName.Text = dr1["strEmployeeName"].ToString();
				this.ACMSRosterDetails1.lblEmpDept.Text = "DEPT :" + dr1["DepartmentName"].ToString().ToUpper() + " (" + dr1["strJobPositionCode"].ToString() + ")";
				this.ACMSRosterDetails1.SunTime.Text = ConvertToTime(dr1["sunStartTime"]) + " " + ConvertToTime(dr1["sunEndTime"]);
				this.ACMSRosterDetails1.MonTime.Text = ConvertToTime(dr1["monStartTime"]) + " " + ConvertToTime(dr1["monEndTime"]);
				this.ACMSRosterDetails1.TueTime.Text = ConvertToTime(dr1["tueStartTime"]) + " " + ConvertToTime(dr1["tueEndTime"]) ;
				this.ACMSRosterDetails1.WedTime.Text = ConvertToTime(dr1["wedStartTime"]) + " " + ConvertToTime(dr1["wedEndTime"]);
				this.ACMSRosterDetails1.ThuTime.Text = ConvertToTime(dr1["thuStartTime"]) + " " + ConvertToTime(dr1["thuEndTime"]);
				this.ACMSRosterDetails1.FriTime.Text = ConvertToTime(dr1["friStartTime"]) + " " + ConvertToTime(dr1["friEndTime"]);
				this.ACMSRosterDetails1.SatTime.Text = ConvertToTime(dr1["satStartTime"]) + " " + ConvertToTime(dr1["satEndTime"]);
				this.ACMSRosterDetails1.TotalHourWrk.Text = dr1["totalHour"].ToString();
				this.ACMSRosterDetails1.panelStaffInfo.Visible = isShowStaffInfo;
				this.panelRosterDetails.Controls.Add(ACMSRosterDetails1);
				
				// To Set Grey Color for Multi Shift Roster
				// Monday
				_ds = new DataSet();
				string strSQL="select nRosterID from tblRoster where dtDate='" + dateMon.ToString("yyyy-MM-dd") + "' and nEmployeeID=" + Convert.ToInt32(dr1["nEmployeeID"]);
				SqlHelper.FillDataset(SqlHelperUtils.connectionString,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
				if (_ds.Tables[0].Rows.Count>1)
				{
					ACMSRosterDetails1.panelMON.BackColor = Color.Gray;
				}
				// Tuesday
				_ds = new DataSet();
				strSQL="select nRosterID from tblRoster where dtDate='" + dateTue.ToString("yyyy-MM-dd") + "' and nEmployeeID=" + Convert.ToInt32(dr1["nEmployeeID"]);
				SqlHelper.FillDataset(SqlHelperUtils.connectionString,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
				if (_ds.Tables[0].Rows.Count>1)
				{
					ACMSRosterDetails1.panelTUE.BackColor = Color.Gray;
				}
				// Wednersday
				_ds = new DataSet();
				strSQL="select nRosterID from tblRoster where dtDate='" + dateWed.ToString("yyyy-MM-dd") + "' and nEmployeeID=" + Convert.ToInt32(dr1["nEmployeeID"]);
				SqlHelper.FillDataset(SqlHelperUtils.connectionString,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
				if (_ds.Tables[0].Rows.Count>1)
				{
					ACMSRosterDetails1.panelWED.BackColor = Color.Gray;
				}
				// Thursday
				_ds = new DataSet();
				strSQL="select nRosterID from tblRoster where dtDate='" + dateThu.ToString("yyyy-MM-dd") + "' and nEmployeeID=" + Convert.ToInt32(dr1["nEmployeeID"]);
				SqlHelper.FillDataset(SqlHelperUtils.connectionString,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
				if (_ds.Tables[0].Rows.Count>1)
				{
					ACMSRosterDetails1.panelTHU.BackColor = Color.Gray;
				}
				// Friday
				_ds = new DataSet();
				strSQL="select nRosterID from tblRoster where dtDate='" + dateFri.ToString("yyyy-MM-dd") + "' and nEmployeeID=" + Convert.ToInt32(dr1["nEmployeeID"]);
				SqlHelper.FillDataset(SqlHelperUtils.connectionString,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
				if (_ds.Tables[0].Rows.Count>1)
				{
					ACMSRosterDetails1.panelFRI.BackColor = Color.Gray;
				}
				// Saturday
				_ds = new DataSet();
				strSQL="select nRosterID from tblRoster where dtDate='" + dateSat.ToString("yyyy-MM-dd") + "' and nEmployeeID=" + Convert.ToInt32(dr1["nEmployeeID"]);
				SqlHelper.FillDataset(SqlHelperUtils.connectionString,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
				if (_ds.Tables[0].Rows.Count>1)
				{
					ACMSRosterDetails1.panelSAT.BackColor = Color.Gray;
				}


				// Sunday
				_ds = new DataSet();
				strSQL="select nRosterID from tblRoster where dtDate='" + dateSun.ToString("yyyy-MM-dd") + "' and nEmployeeID=" + Convert.ToInt32(dr1["nEmployeeID"]);
				SqlHelper.FillDataset(SqlHelperUtils.connectionString,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
				if (_ds.Tables[0].Rows.Count>1)
				{
					ACMSRosterDetails1.panelSUN.BackColor = Color.Gray;
				}


				// To Display Leave Color on Roster
				if ( IsShowLeave )
				{
					DateTime startDate, endDate;
					startDate=dateMon;
					endDate = dateSun;

					_ds = new DataSet();

					SqlHelper.FillDataset(SqlHelperUtils.connectionString,CommandType.StoredProcedure,"pr_SelectLeave",_ds,new string[] {"table"}, 
						new SqlParameter("@ddtStartDate", startDate),
						new SqlParameter("@ddtEndDate", endDate),
						new SqlParameter("@inEmployeeID", Convert.ToInt32(dr1["nEmployeeID"]))
						);

					dtLeaveDetails = _ds.Tables[0];
						
					foreach(DataRow row in dtLeaveDetails.Rows)
					{
						SetLeaveColor(row);
					}
				}
			}

			if (dtRosterDetail.Rows.Count == 0)
			{
				this.ACMSRosterDetails1 = new ACMSRosterDetails();
				this.ACMSRosterDetails1.Location = new System.Drawing.Point(0, y);
				this.ACMSRosterDetails1.Name = "ACMSRosterDetails1";
				this.ACMSRosterDetails1.Size = new System.Drawing.Size(792, 54);
				this.ACMSRosterDetails1.TabIndex = 0;
				this.ACMSRosterDetails1.Click += new System.EventHandler(this._Click);
				y = y+55;
				this.ACMSRosterDetails1.year = year;
				this.ACMSRosterDetails1.WeekNo = weekNo;
				this.ACMSRosterDetails1.lblEmpID.Text = string.Empty;
				this.ACMSRosterDetails1.lblEmpName.Text = string.Empty;
				this.ACMSRosterDetails1.lblEmpDept.Text = string.Empty;
				this.ACMSRosterDetails1.SunTime.Text =string.Empty;
				this.ACMSRosterDetails1.MonTime.Text = string.Empty;
				this.ACMSRosterDetails1.TueTime.Text = string.Empty;
				this.ACMSRosterDetails1.WedTime.Text = string.Empty;
				this.ACMSRosterDetails1.ThuTime.Text = string.Empty;
				this.ACMSRosterDetails1.FriTime.Text = string.Empty;
				this.ACMSRosterDetails1.SatTime.Text = string.Empty;
				this.ACMSRosterDetails1.TotalHourWrk.Text = string.Empty;
				this.ACMSRosterDetails1.panelStaffInfo.Visible = false;
				this.panelRosterDetails.Controls.Add(this.ACMSRosterDetails1);
			}
			*/
			this.ResumeLayout();
		}

		private string ConvertToTime(object target)
		{
			if (target.ToString() == "" )
				return null;
			else
				return Convert.ToDateTime(target).ToShortTimeString();
		}

		private void SetLeaveColor(DataRow row)
		{
			/*
			DateTime dtStartTime = Convert.ToDateTime(row["dtStartTime"]);
			DateTime dtEndTime = Convert.ToDateTime(row["dtEndTime"]);
			DateTime dtStartDate = dtStartTime.Date;
			DateTime dtEndDate = dtEndTime.Date;

			int startWeekDay = (int)dtStartTime.DayOfWeek;
			int endWeekDay = (int)dtEndTime.DayOfWeek;
			bool isTimeOff = row["fTimeOff"] == DBNull.Value ? false : System.Convert.ToBoolean(row["fTimeOff"]);
			int nStatusID = Convert.ToInt32(row["nStatusID"]);
			bool isHalfDay = ACMS.Convert.ToBoolean(row["fFullDay"]) ? false : true;

			if (dateSun.Date >= dtStartDate && dateSun.Date <= dtEndDate) 
			{
				ACMSRosterDetails1.panelSUN.BackColor = LeaveColor(isTimeOff, nStatusID, isHalfDay);
				ACMSRosterDetails1.NLeaveIDSun = Convert.ToInt32(row["nLeaveID"]);
			}
			if (dateMon.Date >= dtStartDate.Date && dateMon.Date <= dtEndDate.Date) 
			{
				ACMSRosterDetails1.panelMON.BackColor = LeaveColor(isTimeOff, nStatusID, isHalfDay);
				ACMSRosterDetails1.NLeaveIDMon = Convert.ToInt32(row["nLeaveID"]);
			}
			if (dateTue.Date >= dtStartDate && dateTue.Date <= dtEndDate) 
			{
				ACMSRosterDetails1.panelTUE.BackColor = LeaveColor(isTimeOff, nStatusID, isHalfDay);
				ACMSRosterDetails1.NLeaveIDTue = Convert.ToInt32(row["nLeaveID"]);
			}
			if (dateWed.Date >= dtStartDate && dateWed.Date <= dtEndDate) 
			{
				ACMSRosterDetails1.panelWED.BackColor = LeaveColor(isTimeOff, nStatusID, isHalfDay);
				ACMSRosterDetails1.NLeaveIDWed = Convert.ToInt32(row["nLeaveID"]);
			}
			if (dateThu.Date >= dtStartDate && dateThu.Date <= dtEndDate) 
			{
				ACMSRosterDetails1.panelTHU.BackColor = LeaveColor(isTimeOff, nStatusID, isHalfDay);
				ACMSRosterDetails1.NLeaveIDThu = Convert.ToInt32(row["nLeaveID"]);
			}
			if (dateFri.Date >= dtStartDate && dateFri.Date <= dtEndDate) 
			{
				ACMSRosterDetails1.panelFRI.BackColor = LeaveColor(isTimeOff, nStatusID, isHalfDay);
				ACMSRosterDetails1.NLeaveIDFri = Convert.ToInt32(row["nLeaveID"]);
			}
			if (dateSat.Date >= dtStartDate && dateSat.Date <= dtEndDate) 
			{
				ACMSRosterDetails1.panelSAT.BackColor = LeaveColor(isTimeOff, nStatusID, isHalfDay);
				ACMSRosterDetails1.NLeaveIDSat = Convert.ToInt32(row["nLeaveID"]);
			}
			*/
		}

		private Color LeaveColor(bool fTimeOff, int nStatusID, bool isHalfDay)
		{
			if (nStatusID == 0)
				return Color.Red;
			else if (fTimeOff)
				return Color.LightBlue;
			else if (isHalfDay)
				return Color.Green;
			else 
				return Color.Yellow;
		}

		private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			/*
			DataTable dt = new DataTable();
			foreach( DataRow dr1 in dtRosterDetail.Rows)
			{
				lblEmpID.Text = dr1["nEmployeeID"].ToString();
				lblEmpName.Text = dr1["strEmployeeName"].ToString();
				lblEmpDept.Text = "DEPT :" + dr1["DepartmentName"].ToString().ToUpper() + " (" + dr1["strJobPositionCode"].ToString() + ")";
				SunTime.Text = ConvertToTime(dr1["sunStartTime"]) + " " + ConvertToTime(dr1["sunEndTime"]);
				MonTime.Text = ConvertToTime(dr1["monStartTime"]) + " " + ConvertToTime(dr1["monEndTime"]);
				TueTime.Text = ConvertToTime(dr1["tueStartTime"]) + " " + ConvertToTime(dr1["tueEndTime"]) ;
				WedTime.Text = ConvertToTime(dr1["wedStartTime"]) + " " + ConvertToTime(dr1["wedEndTime"]);
				ThuTime.Text = ConvertToTime(dr1["thuStartTime"]) + " " + ConvertToTime(dr1["thuEndTime"]);
				FriTime.Text = ConvertToTime(dr1["friStartTime"]) + " " + ConvertToTime(dr1["friEndTime"]);
				SatTime.Text = ConvertToTime(dr1["satStartTime"]) + " " + ConvertToTime(dr1["satEndTime"]);
				TotalHourWrk.Text = dr1["totalHour"].ToString();
			}
			*/

		}


	}
}

