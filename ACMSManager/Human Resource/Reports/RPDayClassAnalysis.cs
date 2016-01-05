using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using DevExpress.XtraPivotGrid;

namespace ACMS.ACMSManager.Reports
{
	/// <summary>
	/// Summary description for RPClassAnalysis.
	/// </summary>
	public class RPDayClassAnalysis : System.Windows.Forms.Form
	{
		public DateTime dateSun, dateMon, dateTue, dateWed, dateThu, dateFri, dateSat;
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private System.Windows.Forms.Panel panelFri;
		private System.Windows.Forms.Panel panelThu;
		private System.Windows.Forms.Panel panelWed;
		private System.Windows.Forms.Panel panelTue;
		private System.Windows.Forms.Panel panelMon;
		private System.Windows.Forms.Label lblFRI;
		private System.Windows.Forms.Panel panelFriday;
		private System.Windows.Forms.Label txtFriday;
		private System.Windows.Forms.Panel panelThursday;
		private System.Windows.Forms.Label lblThu;
		private System.Windows.Forms.Label txtThur;
		private System.Windows.Forms.Panel panelWednesday;
		private System.Windows.Forms.Label lblWED;
		private System.Windows.Forms.Label txtWED;
		private System.Windows.Forms.Panel panelSunday;
		private System.Windows.Forms.Label lblSUN;
		private System.Windows.Forms.Label txtSunday;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label lblTUE;
		private System.Windows.Forms.Label txtTUE;
		private System.Windows.Forms.Panel panelMonday;
		private System.Windows.Forms.Label lblMon;
		private System.Windows.Forms.Label txtMonday;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private int WeekNo, Week_Day, YearNo;
		private ACMS.Control.DayClassReportComponent classComponent1;
		private string currentDay;
		private int EmployeeId;
		private string strBranch;
		private System.Windows.Forms.Panel panelSun;
		private bool isFinishBindInit;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.MonthCalendar dtDate;
		private DataTable _dtClassSchedule;


		public RPDayClassAnalysis(int empId, string strBranchCode)
		{
			//
			// Required for Windows Form Designer support
			//
			EmployeeId = empId;
			strBranch=strBranchCode;			
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.panelSun = new System.Windows.Forms.Panel();
			this.panelMonday = new System.Windows.Forms.Panel();
			this.lblMon = new System.Windows.Forms.Label();
			this.txtMonday = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.lblTUE = new System.Windows.Forms.Label();
			this.txtTUE = new System.Windows.Forms.Label();
			this.panelFriday = new System.Windows.Forms.Panel();
			this.lblFRI = new System.Windows.Forms.Label();
			this.txtFriday = new System.Windows.Forms.Label();
			this.panelFri = new System.Windows.Forms.Panel();
			this.panelThu = new System.Windows.Forms.Panel();
			this.panelWed = new System.Windows.Forms.Panel();
			this.panelTue = new System.Windows.Forms.Panel();
			this.panelMon = new System.Windows.Forms.Panel();
			this.panelWednesday = new System.Windows.Forms.Panel();
			this.lblWED = new System.Windows.Forms.Label();
			this.txtWED = new System.Windows.Forms.Label();
			this.panelThursday = new System.Windows.Forms.Panel();
			this.lblThu = new System.Windows.Forms.Label();
			this.txtThur = new System.Windows.Forms.Label();
			this.panelSunday = new System.Windows.Forms.Panel();
			this.lblSUN = new System.Windows.Forms.Label();
			this.txtSunday = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dtDate = new System.Windows.Forms.MonthCalendar();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			this.panelMonday.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panelFriday.SuspendLayout();
			this.panelWednesday.SuspendLayout();
			this.panelThursday.SuspendLayout();
			this.panelSunday.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupControl1
			// 
			this.groupControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.groupControl1.Appearance.Options.UseBackColor = true;
			this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.groupControl1.Controls.Add(this.panelSun);
			this.groupControl1.Controls.Add(this.panelMonday);
			this.groupControl1.Controls.Add(this.panel4);
			this.groupControl1.Controls.Add(this.panelFriday);
			this.groupControl1.Controls.Add(this.panelFri);
			this.groupControl1.Controls.Add(this.panelThu);
			this.groupControl1.Controls.Add(this.panelWed);
			this.groupControl1.Controls.Add(this.panelTue);
			this.groupControl1.Controls.Add(this.panelMon);
			this.groupControl1.Controls.Add(this.panelWednesday);
			this.groupControl1.Controls.Add(this.panelThursday);
			this.groupControl1.Controls.Add(this.panelSunday);
			this.groupControl1.Location = new System.Drawing.Point(0, 136);
			this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.ShowCaption = false;
			this.groupControl1.Size = new System.Drawing.Size(784, 552);
			this.groupControl1.TabIndex = 32;
			// 
			// panelSun
			// 
			this.panelSun.BackColor = System.Drawing.Color.Transparent;
			this.panelSun.Location = new System.Drawing.Point(8, 56);
			this.panelSun.Name = "panelSun";
			this.panelSun.Size = new System.Drawing.Size(128, 480);
			this.panelSun.TabIndex = 55;
			// 
			// panelMonday
			// 
			this.panelMonday.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panelMonday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelMonday.Controls.Add(this.lblMon);
			this.panelMonday.Controls.Add(this.txtMonday);
			this.panelMonday.Location = new System.Drawing.Point(136, 24);
			this.panelMonday.Name = "panelMonday";
			this.panelMonday.Size = new System.Drawing.Size(128, 32);
			this.panelMonday.TabIndex = 54;
			// 
			// lblMon
			// 
			this.lblMon.BackColor = System.Drawing.Color.PowderBlue;
			this.lblMon.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMon.Location = new System.Drawing.Point(0, 0);
			this.lblMon.Name = "lblMon";
			this.lblMon.Size = new System.Drawing.Size(128, 16);
			this.lblMon.TabIndex = 1;
			this.lblMon.Text = "PM";
			this.lblMon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtMonday
			// 
			this.txtMonday.BackColor = System.Drawing.Color.PowderBlue;
			this.txtMonday.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtMonday.Location = new System.Drawing.Point(0, 16);
			this.txtMonday.Name = "txtMonday";
			this.txtMonday.Size = new System.Drawing.Size(128, 16);
			this.txtMonday.TabIndex = 2;
			this.txtMonday.Text = "17/6/2005";
			this.txtMonday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Controls.Add(this.lblTUE);
			this.panel4.Controls.Add(this.txtTUE);
			this.panel4.Location = new System.Drawing.Point(264, 24);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(128, 32);
			this.panel4.TabIndex = 52;
			// 
			// lblTUE
			// 
			this.lblTUE.BackColor = System.Drawing.Color.PowderBlue;
			this.lblTUE.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTUE.Location = new System.Drawing.Point(0, 0);
			this.lblTUE.Name = "lblTUE";
			this.lblTUE.Size = new System.Drawing.Size(128, 16);
			this.lblTUE.TabIndex = 1;
			this.lblTUE.Text = "WL";
			this.lblTUE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtTUE
			// 
			this.txtTUE.BackColor = System.Drawing.Color.PowderBlue;
			this.txtTUE.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtTUE.Location = new System.Drawing.Point(0, 16);
			this.txtTUE.Name = "txtTUE";
			this.txtTUE.Size = new System.Drawing.Size(128, 16);
			this.txtTUE.TabIndex = 2;
			this.txtTUE.Text = "17/6/2005";
			this.txtTUE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panelFriday
			// 
			this.panelFriday.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panelFriday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelFriday.Controls.Add(this.lblFRI);
			this.panelFriday.Controls.Add(this.txtFriday);
			this.panelFriday.Location = new System.Drawing.Point(648, 24);
			this.panelFriday.Name = "panelFriday";
			this.panelFriday.Size = new System.Drawing.Size(128, 32);
			this.panelFriday.TabIndex = 48;
			// 
			// lblFRI
			// 
			this.lblFRI.BackColor = System.Drawing.Color.PowderBlue;
			this.lblFRI.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblFRI.Location = new System.Drawing.Point(0, 0);
			this.lblFRI.Name = "lblFRI";
			this.lblFRI.Size = new System.Drawing.Size(128, 16);
			this.lblFRI.TabIndex = 1;
			this.lblFRI.Text = "EP";
			this.lblFRI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtFriday
			// 
			this.txtFriday.BackColor = System.Drawing.Color.PowderBlue;
			this.txtFriday.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtFriday.Location = new System.Drawing.Point(0, 16);
			this.txtFriday.Name = "txtFriday";
			this.txtFriday.Size = new System.Drawing.Size(128, 16);
			this.txtFriday.TabIndex = 2;
			this.txtFriday.Text = "17/6/2005";
			this.txtFriday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panelFri
			// 
			this.panelFri.BackColor = System.Drawing.Color.Transparent;
			this.panelFri.Location = new System.Drawing.Point(648, 56);
			this.panelFri.Name = "panelFri";
			this.panelFri.Size = new System.Drawing.Size(128, 480);
			this.panelFri.TabIndex = 37;
			// 
			// panelThu
			// 
			this.panelThu.BackColor = System.Drawing.Color.Transparent;
			this.panelThu.Location = new System.Drawing.Point(520, 56);
			this.panelThu.Name = "panelThu";
			this.panelThu.Size = new System.Drawing.Size(128, 480);
			this.panelThu.TabIndex = 36;
			// 
			// panelWed
			// 
			this.panelWed.BackColor = System.Drawing.Color.Transparent;
			this.panelWed.Location = new System.Drawing.Point(392, 56);
			this.panelWed.Name = "panelWed";
			this.panelWed.Size = new System.Drawing.Size(128, 480);
			this.panelWed.TabIndex = 35;
			// 
			// panelTue
			// 
			this.panelTue.BackColor = System.Drawing.Color.Transparent;
			this.panelTue.Location = new System.Drawing.Point(264, 56);
			this.panelTue.Name = "panelTue";
			this.panelTue.Size = new System.Drawing.Size(128, 480);
			this.panelTue.TabIndex = 34;
			// 
			// panelMon
			// 
			this.panelMon.BackColor = System.Drawing.Color.Transparent;
			this.panelMon.Location = new System.Drawing.Point(136, 56);
			this.panelMon.Name = "panelMon";
			this.panelMon.Size = new System.Drawing.Size(128, 480);
			this.panelMon.TabIndex = 33;
			// 
			// panelWednesday
			// 
			this.panelWednesday.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panelWednesday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelWednesday.Controls.Add(this.lblWED);
			this.panelWednesday.Controls.Add(this.txtWED);
			this.panelWednesday.Location = new System.Drawing.Point(392, 24);
			this.panelWednesday.Name = "panelWednesday";
			this.panelWednesday.Size = new System.Drawing.Size(128, 32);
			this.panelWednesday.TabIndex = 51;
			// 
			// lblWED
			// 
			this.lblWED.BackColor = System.Drawing.Color.PowderBlue;
			this.lblWED.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblWED.Location = new System.Drawing.Point(0, 0);
			this.lblWED.Name = "lblWED";
			this.lblWED.Size = new System.Drawing.Size(128, 16);
			this.lblWED.TabIndex = 1;
			this.lblWED.Text = "HM";
			this.lblWED.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtWED
			// 
			this.txtWED.BackColor = System.Drawing.Color.PowderBlue;
			this.txtWED.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtWED.Location = new System.Drawing.Point(0, 16);
			this.txtWED.Name = "txtWED";
			this.txtWED.Size = new System.Drawing.Size(128, 16);
			this.txtWED.TabIndex = 2;
			this.txtWED.Text = "17/6/2005";
			this.txtWED.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panelThursday
			// 
			this.panelThursday.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panelThursday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelThursday.Controls.Add(this.lblThu);
			this.panelThursday.Controls.Add(this.txtThur);
			this.panelThursday.Location = new System.Drawing.Point(520, 24);
			this.panelThursday.Name = "panelThursday";
			this.panelThursday.Size = new System.Drawing.Size(128, 32);
			this.panelThursday.TabIndex = 51;
			// 
			// lblThu
			// 
			this.lblThu.BackColor = System.Drawing.Color.PowderBlue;
			this.lblThu.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblThu.Location = new System.Drawing.Point(0, 0);
			this.lblThu.Name = "lblThu";
			this.lblThu.Size = new System.Drawing.Size(128, 16);
			this.lblThu.TabIndex = 1;
			this.lblThu.Text = "JP";
			this.lblThu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtThur
			// 
			this.txtThur.BackColor = System.Drawing.Color.PowderBlue;
			this.txtThur.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtThur.Location = new System.Drawing.Point(0, 16);
			this.txtThur.Name = "txtThur";
			this.txtThur.Size = new System.Drawing.Size(128, 16);
			this.txtThur.TabIndex = 2;
			this.txtThur.Text = "17/6/2005";
			this.txtThur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panelSunday
			// 
			this.panelSunday.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panelSunday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelSunday.Controls.Add(this.lblSUN);
			this.panelSunday.Controls.Add(this.txtSunday);
			this.panelSunday.Location = new System.Drawing.Point(8, 24);
			this.panelSunday.Name = "panelSunday";
			this.panelSunday.Size = new System.Drawing.Size(128, 32);
			this.panelSunday.TabIndex = 52;
			// 
			// lblSUN
			// 
			this.lblSUN.BackColor = System.Drawing.Color.PowderBlue;
			this.lblSUN.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblSUN.Location = new System.Drawing.Point(0, 0);
			this.lblSUN.Name = "lblSUN";
			this.lblSUN.Size = new System.Drawing.Size(128, 16);
			this.lblSUN.TabIndex = 1;
			this.lblSUN.Text = "BJ";
			this.lblSUN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtSunday
			// 
			this.txtSunday.BackColor = System.Drawing.Color.PowderBlue;
			this.txtSunday.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtSunday.Location = new System.Drawing.Point(0, 16);
			this.txtSunday.Name = "txtSunday";
			this.txtSunday.Size = new System.Drawing.Size(128, 16);
			this.txtSunday.TabIndex = 2;
			this.txtSunday.Text = "17/6/2005";
			this.txtSunday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dtDate);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(784, 136);
			this.groupBox1.TabIndex = 59;
			this.groupBox1.TabStop = false;
			// 
			// dtDate
			// 
			this.dtDate.Location = new System.Drawing.Point(72, 0);
			this.dtDate.Name = "dtDate";
			this.dtDate.TabIndex = 56;
			this.dtDate.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(8, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 40);
			this.label2.TabIndex = 52;
			this.label2.Text = "Date";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RPDayClassAnalysis
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(945, 592);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "RPDayClassAnalysis";
			this.Text = "Class Analysis";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.RPDayClassAnalysis_Load);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			this.panelMonday.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panelFriday.ResumeLayout(false);
			this.panelWednesday.ResumeLayout(false);
			this.panelThursday.ResumeLayout(false);
			this.panelSunday.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void RPDayClassAnalysis_Load(object sender, System.EventArgs e)
		{
			dtDate.SelectionStart = DateTime.Now.Date;
			isFinishBindInit = false;
			//BindBranch();
			isFinishBindInit = true;
			//cmbBranch.SelectedText="BJ";
			ScheduleHeader();
			RetrieveRecordFromDB();			
			LoadScheduleDetail();
			
		}

		private void BindBranch()
		{
//			isFinishBindInit = false;
//
//			string strSQL = "Select strBranchCode,strBranchName from TblBranch Where strBranchCode In (Select strBranchCode from tblemployeebranchrights Where nEmployeeId = " + EmployeeId + ")";
//
//			comboBind(cmbBranch, strSQL, "strBranchName", "strBranchCode", true);
//			//cmbBranch.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem("- Please Select -",""));
//			//cmbBranch.SelectedIndex = 0;
//			isFinishBindInit = true;

		}

		private void comboBind(DevExpress.XtraEditors.ImageComboBoxEdit control,string strSQL,string display,string strValue,bool fNum)
		{
		
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox properties = control.Properties;
			properties.Items.BeginUpdate();
			properties.Items.Clear();

			try 
			{
				foreach(DataRow dr in _ds.Tables["Table"].Rows)
				{
					//Initialize each item with the display text, value and image index
					properties.Items.Add( new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr[display].ToString(), dr[strValue],-1));
				}
			}
			finally 
			{
				properties.Items.EndUpdate();
			}
			//Select the first item
			control.SelectedIndex = 0;
		}

		private void ScheduleHeader()
		{
			if (!isFinishBindInit)
				return;

//			string strSQL;
//			DataSet _ds;
//			DataTable dt;
//			string MMddyy;
//			
//			MMddyy =  string.Format("{0:MM-dd-yyyy}",Convert.ToDateTime( currentDay));
//
//			if (currentDay == "" || currentDay == null)
//			{
//				strSQL = "select getDate() as today,datepart(weekday,getDate()) as week_day,datepart(week,getDate()) as WeekNo,datepart(year,getDate()) as YearNo";
//			}
//			else
//			{
//				strSQL = "select '" + currentDay + "' as today,datepart(weekday,'" + MMddyy + "') as week_day,datepart(week,'" + MMddyy + "') as WeekNo";
//			}
//
//
//			_ds = new DataSet();
//			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
//			
//			dt = _ds.Tables["table"];
//			Week_Day = Convert.ToInt32(dt.Rows[0]["week_day"]);
//			currentDay = Convert.ToDateTime( dt.Rows[0]["today"].ToString() ).AddDays(1 - Week_Day).ToShortDateString();
//			WeekNo = Convert.ToInt32(dt.Rows[0]["WeekNo"]);
//			
//			if (WeekNo>52)WeekNo=1;
//		
//			if (YearNo == 0)
//				YearNo = Convert.ToInt32(dt.Rows[0]["YearNo"]);
//
//			foreach ( DataRow dr in dt.Rows )
//			{			
//				int i = Convert.ToInt32( dr["week_day"].ToString() );
				this.txtSunday.Text = dtDate.Text;
				this.txtMonday.Text = dtDate.Text;
				this.txtTUE.Text = dtDate.Text;
				this.txtWED.Text = dtDate.Text;
				this.txtThur.Text = dtDate.Text;
				this.txtFriday.Text =  dtDate.Text;
				//this.txtSAT.Text = Convert.ToDateTime( dr["today"].ToString() ).AddDays(7-i).ToString("dd-MM-yyyy");
//				dateSun = Convert.ToDateTime(dr["today"]).AddDays(1-i);
//				dateMon = Convert.ToDateTime(dr["today"]).AddDays(2-i);
//				dateTue = Convert.ToDateTime(dr["today"]).AddDays(3-i);
//				dateWed = Convert.ToDateTime(dr["today"]).AddDays(4-i);
//				dateThu = Convert.ToDateTime(dr["today"]).AddDays(5-i);
//				dateFri = Convert.ToDateTime(dr["today"]).AddDays(6-i);
//				dateSat = Convert.ToDateTime(dr["today"]).AddDays(7-i);
			//}
			
		}
		
		private void RetrieveRecordFromDB()
		{
			string strSQL = "up_get_DayClassAnalysisRpt @ClassDate = '" + Convert.ToDateTime(dtDate.SelectionEnd).ToString("dd-MMM-yyyy") + "'";

			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );

			 _dtClassSchedule = _ds.Tables["table"];

		}
		private void LoadScheduleDetail()
		{

			int BelowVal=5;

			panelMon.Controls.Clear();
			panelTue.Controls.Clear();
			panelWed.Controls.Clear();
			panelThu.Controls.Clear();
			panelFri.Controls.Clear();
			//panelSat.Controls.Clear();
			panelSun.Controls.Clear();

			int nMon,nTue,nWed,nThu,nFri,nSat,nSun;
			nMon = 2;
			nTue = 2;
			nWed = 2;
			nThu = 2;
			nFri = 2;
			nSat = 2;
			nSun = 2;
		
			int nDay = 0;
			this.SuspendLayout();
			panelSun.SuspendLayout();
			panelMon.SuspendLayout();
			panelTue.SuspendLayout();
			panelWed.SuspendLayout();
			panelThu.SuspendLayout();
			panelFri.SuspendLayout();
			//panelSat.SuspendLayout();
			
			
			DataView dvClass = new DataView(_dtClassSchedule);
//			if (cmbBranch.EditValue.ToString() != "")
				//dvClass.RowFilter = "dtDate='" + dtDate.Text + "'";
			foreach(DataRowView dr in dvClass)
			{
				if (dr["strBranchCode"].ToString()=="BJ")
				{

					this.classComponent1 = new ACMS.Control.DayClassReportComponent();
				
					// 
					// classComponent1
					// 
					this.classComponent1.BackColor = System.Drawing.Color.Silver;
					this.classComponent1.Location = new System.Drawing.Point(2, nMon);
					this.classComponent1.Name = "classComponent1";
					this.classComponent1.Size = new System.Drawing.Size(127, 50);
					this.classComponent1.TabIndex = 0;
					this.classComponent1.Click += new System.EventHandler(this._Click);
					this.classComponent1.lblClassTime.Text = string.Format("{0:hh:mm:tt}",Convert.ToDateTime(dr["dtStartTime"]));
					this.classComponent1.lblClassName.Text = dr["strClassCode"].ToString();
					this.classComponent1.lblClassInstructor.Text = dr["Instructor"].ToString();

					this.classComponent1.lblTodayAttendance.Text =  dr["ThisWeekNo"].ToString();
					this.classComponent1.lblnDay.Text =  dr["nDay"].ToString();
					this.classComponent1.lblnClassSchedule.Text=dr["nClassScheduleID"].ToString();


					if ((ACMS.Convert.ToInt32(dr["ThisWeekNo"]))<= BelowVal)
					{
							this.classComponent1.lblTodayAttendance.BackColor=System.Drawing.Color.Red;
					}

					this.panelSun.Controls.Add(this.classComponent1);
					nMon = nMon + 50;
					
				    panelSun.Height = nMon;

					if (nMon > nDay)
						nDay = nMon;

					
				}
					
				else if (dr["strBranchCode"].ToString()=="PM")
				{
			
					this.classComponent1 = new ACMS.Control.DayClassReportComponent();
					
					// 
					// classComponent1
					// 
					this.classComponent1.BackColor = System.Drawing.Color.Silver;
					this.classComponent1.Location = new System.Drawing.Point(2, nTue);
					this.classComponent1.Name = "classComponent1";
					this.classComponent1.Size = new System.Drawing.Size(127, 50);
					this.classComponent1.TabIndex = 0;
					this.classComponent1.Click += new System.EventHandler(this._Click);
					//this.classComponent1.lblClassId.Text = dr["nClassInstanceID"].ToString();
					this.classComponent1.lblClassTime.Text = string.Format("{0:hh:mm:tt}",Convert.ToDateTime(dr["dtStartTime"]));
					this.classComponent1.lblClassName.Text = dr["strClassCode"].ToString();
					this.classComponent1.lblClassInstructor.Text = dr["Instructor"].ToString();
//					this.classComponent1.lblLastFourWeekAttendance.Visible = false;
//					this.classComponent1.lblLastThreeWeekAttendance.Visible = false;
//					this.classComponent1.lblLastTwoWeekAttendance.Visible = false;
//					this.classComponent1.lblLastWeekAttendance.Visible = false;
					this.classComponent1.lblTodayAttendance.Text =  dr["ThisWeekNo"].ToString();
					this.classComponent1.lblnDay.Text =  dr["nDay"].ToString();
					this.classComponent1.lblnClassSchedule.Text=dr["nClassScheduleID"].ToString();

					if ((ACMS.Convert.ToInt32(dr["ThisWeekNo"]))<= BelowVal)
					{
						this.classComponent1.lblTodayAttendance.BackColor=System.Drawing.Color.Red;
					}


					this.panelMon.Controls.Add(this.classComponent1);
					nTue = nTue + 50;
			
					panelMon.Height = nTue;
					if (nTue > nDay)
						nDay = nTue;
			
		
				}
				else if (dr["strBranchCode"].ToString()=="WL")
				{
					
					this.classComponent1 = new ACMS.Control.DayClassReportComponent();
					
					// 
					// classComponent1
					// 
					this.classComponent1.BackColor = System.Drawing.Color.Silver;
					this.classComponent1.Location = new System.Drawing.Point(2, nWed);
					this.classComponent1.Name = "classComponent1";
					this.classComponent1.Size = new System.Drawing.Size(127, 50);
					this.classComponent1.TabIndex = 0;
					this.classComponent1.Click += new System.EventHandler(this._Click);
					//this.classComponent1.lblClassId.Text = dr["nClassInstanceID"].ToString();
					this.classComponent1.lblClassTime.Text = string.Format("{0:hh:mm:tt}",Convert.ToDateTime(dr["dtStartTime"]));
					this.classComponent1.lblClassName.Text = dr["strClassCode"].ToString();
					this.classComponent1.lblClassInstructor.Text = dr["Instructor"].ToString();

					this.classComponent1.lblTodayAttendance.Text =  dr["ThisWeekNo"].ToString();
					this.classComponent1.lblnDay.Text =  dr["nDay"].ToString();
					this.classComponent1.lblnClassSchedule.Text=dr["nClassScheduleID"].ToString();

					if ((ACMS.Convert.ToInt32(dr["ThisWeekNo"]))<= BelowVal)
					{
						this.classComponent1.lblTodayAttendance.BackColor=System.Drawing.Color.Red;
					}

					
					this.panelTue.Controls.Add(this.classComponent1);
					nWed = nWed + 50;
				
					panelTue.Height = nWed;

					if (nWed > nDay)
						nDay = nWed;
					
		
				}
				else if (dr["strBranchCode"].ToString()=="HM")
				{
					
					this.classComponent1 = new ACMS.Control.DayClassReportComponent();
					
					// 
					// classComponent1
					// 
					this.classComponent1.BackColor = System.Drawing.Color.Silver;
					this.classComponent1.Location = new System.Drawing.Point(2, nThu);
					this.classComponent1.Name = "classComponent1";
					this.classComponent1.Size = new System.Drawing.Size(127, 50);
					this.classComponent1.TabIndex = 0;
					this.classComponent1.Click += new System.EventHandler(this._Click);
					//this.classComponent1.lblClassId.Text = dr["nClassInstanceID"].ToString();
					this.classComponent1.lblClassTime.Text = string.Format("{0:hh:mm:tt}",Convert.ToDateTime(dr["dtStartTime"]));
					this.classComponent1.lblClassName.Text = dr["strClassCode"].ToString();
					this.classComponent1.lblClassInstructor.Text = dr["Instructor"].ToString();
					
					this.classComponent1.lblTodayAttendance.Text =  dr["ThisWeekNo"].ToString();
					this.classComponent1.lblnDay.Text =  dr["nDay"].ToString();
					this.classComponent1.lblnClassSchedule.Text=dr["nClassScheduleID"].ToString();

					if ((ACMS.Convert.ToInt32(dr["ThisWeekNo"]))<= BelowVal)
					{
						this.classComponent1.lblTodayAttendance.BackColor=System.Drawing.Color.Red;
					}

					this.panelWed.Controls.Add(this.classComponent1);
					nThu = nThu + 50;
					
					panelWed.Height = nThu;

					if (nThu > nDay)
						nDay = nThu;
					
		
				}
				else if (dr["strBranchCode"].ToString()=="JP")
				{
					
					this.classComponent1 = new ACMS.Control.DayClassReportComponent();
					// 
					// classComponent1
					// 
					this.classComponent1.BackColor = System.Drawing.Color.Silver;
					this.classComponent1.Location = new System.Drawing.Point(2, nFri);
					this.classComponent1.Name = "classComponent1";
					this.classComponent1.Size = new System.Drawing.Size(127, 50);
					this.classComponent1.TabIndex = 0;
					this.classComponent1.Click += new System.EventHandler(this._Click);
					//this.classComponent1.lblClassId.Text = dr["nClassInstanceID"].ToString();
					this.classComponent1.lblClassTime.Text = string.Format("{0:hh:mm:tt}",Convert.ToDateTime(dr["dtStartTime"]));
					this.classComponent1.lblClassName.Text = dr["strClassCode"].ToString();
					this.classComponent1.lblClassInstructor.Text = dr["Instructor"].ToString();
					
					this.classComponent1.lblTodayAttendance.Text =  dr["ThisWeekNo"].ToString();
					this.classComponent1.lblnDay.Text =  dr["nDay"].ToString();
					this.classComponent1.lblnClassSchedule.Text=dr["nClassScheduleID"].ToString();

				

					if ((ACMS.Convert.ToInt32(dr["ThisWeekNo"]))<= BelowVal)
					{
						this.classComponent1.lblTodayAttendance.BackColor=System.Drawing.Color.Red;
					}
					this.panelThu.Controls.Add(this.classComponent1);
					nFri = nFri + 50;

					panelThu.Height = nFri;

					if (nFri > nDay)
						nDay = nFri;
					
				
				}
				else if (dr["strBranchCode"].ToString()=="EP")
				{
					
					this.classComponent1 = new ACMS.Control.DayClassReportComponent();
					
					// 
					// classComponent1
					// 
					this.classComponent1.BackColor = System.Drawing.Color.Silver;
					this.classComponent1.Location = new System.Drawing.Point(2, nSat);
					this.classComponent1.Name = "classComponent1";
					this.classComponent1.Size = new System.Drawing.Size(127, 50);
					this.classComponent1.TabIndex = 0;
					this.classComponent1.Click += new System.EventHandler(this._Click);
					//this.classComponent1.lblClassId.Text = dr["nClassInstanceID"].ToString();
					this.classComponent1.lblClassTime.Text = string.Format("{0:hh:mm:tt}",Convert.ToDateTime(dr["dtStartTime"]));
					this.classComponent1.lblClassName.Text = dr["strClassCode"].ToString();
					this.classComponent1.lblClassInstructor.Text = dr["Instructor"].ToString();
				
					this.classComponent1.lblTodayAttendance.Text =  dr["ThisWeekNo"].ToString();
					this.classComponent1.lblnDay.Text =  dr["nDay"].ToString();
					this.classComponent1.lblnClassSchedule.Text=dr["nClassScheduleID"].ToString();

					
					if ((ACMS.Convert.ToInt32(dr["ThisWeekNo"]))<= BelowVal)
					{
						this.classComponent1.lblTodayAttendance.BackColor=System.Drawing.Color.Red;
					}
					this.panelFri.Controls.Add(this.classComponent1);
					nSat = nSat + 50;
					
					panelFri.Height = nSat;

					if (nSat > nDay)
						nDay = nSat;
					
		
				}
				else if (dr["nDay"].ToString()=="7")
				{
					
					this.classComponent1 = new ACMS.Control.DayClassReportComponent();
					// 
					// classComponent1
					// 
					this.classComponent1.BackColor = System.Drawing.Color.Silver;
					this.classComponent1.Location = new System.Drawing.Point(2, nSun);
					this.classComponent1.Name = "classComponent1";
					this.classComponent1.Size = new System.Drawing.Size(127, 50);
					this.classComponent1.TabIndex = 0;
					this.classComponent1.Click += new System.EventHandler(this._Click);
					//this.classComponent1.lblClassId.Text = dr["nClassInstanceID"].ToString();
					this.classComponent1.lblClassTime.Text = string.Format("{0:hh:mm:tt}",Convert.ToDateTime(dr["dtStartTime"]));
					this.classComponent1.lblClassName.Text = dr["strClassCode"].ToString();
					this.classComponent1.lblClassInstructor.Text = dr["Instructor"].ToString();
					
					this.classComponent1.lblTodayAttendance.Text =  dr["ThisWeekNo"].ToString();
					this.classComponent1.lblnDay.Text =  dr["nDay"].ToString();
					this.classComponent1.lblnClassSchedule.Text=dr["nClassScheduleID"].ToString();

					
					if ((ACMS.Convert.ToInt32(dr["ThisWeekNo"]))<= BelowVal)
					{
						this.classComponent1.lblTodayAttendance.BackColor=System.Drawing.Color.Red;
					}
					//this.panelSat.Controls.Add(this.classComponent1);
                    nSun = nSun + 50;
					
					//panelSat.Height = nSun;

					if (nSun > nDay)
						nDay = nSun;
					
				}
				

			}
			this.ResumeLayout();
			panelSun.ResumeLayout();
			panelMon.ResumeLayout();
			panelTue.ResumeLayout();
			panelWed.ResumeLayout();
			panelThu.ResumeLayout();
			panelFri.ResumeLayout();
			//panelSat.ResumeLayout();
		
			groupControl1.Height = nDay + 200;
			
			
		}

		private void _Click(object sender,System.EventArgs e)
		{
            //ACMS.Control.ClassReportComponent cc;
            //cc = (ACMS.Control.ClassReportComponent) sender;
            //cc.lblClassInstructor.BackColor = System.Drawing.Color.Gold;
            //cc.lblClassName.BackColor = System.Drawing.Color.Gold;
            //cc.lblClassTime.BackColor = System.Drawing.Color.Gold;

            //ACMSManager.Reports.RPClassDetail myform = new ACMSManager.Reports.RPClassDetail(cc.lblnClassSchedule.Text,cc.lblnDay.Text,EmployeeId,cc);

            //myform.Show();
		}

		private void btnNextWeek_Click(object sender, System.EventArgs e)
		{
            WeekNo = WeekNo + 1;
			int Year = Convert.ToDateTime(currentDay).Month;
			currentDay = Convert.ToDateTime(currentDay).AddDays(7).ToShortDateString();
			int Year2 = Convert.ToDateTime(currentDay).Month;
		
			if (Year == 12 && Year2 == 1)
				YearNo = YearNo + 1;

			//initRoster(target,comboBoxRoster.EditValue.ToString());
			ScheduleHeader();
			RetrieveRecordFromDB();
			
			LoadScheduleDetail();
		}

		private void btnPastWeek_Click(object sender, System.EventArgs e)
		{
			WeekNo = WeekNo - 1;
			int Year = Convert.ToDateTime(currentDay).Month;

			currentDay = Convert.ToDateTime(currentDay).AddDays(- 7).ToShortDateString();
			int Year2 = Convert.ToDateTime(currentDay).Month;
			
			if (Year == 1 && Year2 == 12)
				YearNo = YearNo - 1;


			ScheduleHeader();
			RetrieveRecordFromDB();
			LoadScheduleDetail();

		}

		private void cmbBranch_SelectedValueChanged(object sender, System.EventArgs e)
		{
			LoadScheduleDetail();
            		
		}


		private void monthCalendar1_DateChanged(object sender, System.Windows.Forms.DateRangeEventArgs e)
		{
			RetrieveRecordFromDB();
			ScheduleHeader();
			LoadScheduleDetail();
		}



		
	}
}
