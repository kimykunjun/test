using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace ACMS.Control
{
	/// <summary>
	/// Summary description for ACMSRosterDetails.
	/// </summary>
	public class ACMSRosterDetails : System.Windows.Forms.UserControl
	{
		//
		private int nLeaveID, nLeaveIDSun, nLeaveIDMon, nLeaveIDTue, nLeaveIDWed, nLeaveIDThu, nLeaveIDFri, nLeaveIDSat;
		private string wd;
		private string wk;
		private string yr;

		public System.Windows.Forms.Panel paneLSTAFF;
		public System.Windows.Forms.Panel panelStaffInfo;
		public System.Windows.Forms.Panel panelHour;
		public System.Windows.Forms.Label SunTime;
		public System.Windows.Forms.Label MonTime;
		public System.Windows.Forms.Label TueTime;
		public System.Windows.Forms.Label WedTime;
		public System.Windows.Forms.Label ThuTime;
		public System.Windows.Forms.Label FriTime;
		public System.Windows.Forms.Label SatTime;
		public System.Windows.Forms.Label TotalHourWrk;
		public System.Windows.Forms.Label lblEmpDept;
		public System.Windows.Forms.Label lblEmpName;
		public System.Windows.Forms.Label lblEmpID;
		private System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.Panel panelSAT;
		public System.Windows.Forms.Panel panelFRI;
		public System.Windows.Forms.Panel panelTHU;
		public System.Windows.Forms.Panel panelWED;
		public System.Windows.Forms.Panel panelTUE;
		public System.Windows.Forms.Panel panelMON;
		public System.Windows.Forms.Panel panelSUN;
		public System.Windows.Forms.Label lblJob;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ACMSRosterDetails()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.paneLSTAFF = new System.Windows.Forms.Panel();
			this.panelHour = new System.Windows.Forms.Panel();
			this.TotalHourWrk = new System.Windows.Forms.Label();
			this.panelSAT = new System.Windows.Forms.Panel();
			this.SatTime = new System.Windows.Forms.Label();
			this.panelFRI = new System.Windows.Forms.Panel();
			this.FriTime = new System.Windows.Forms.Label();
			this.panelTHU = new System.Windows.Forms.Panel();
			this.ThuTime = new System.Windows.Forms.Label();
			this.panelWED = new System.Windows.Forms.Panel();
			this.WedTime = new System.Windows.Forms.Label();
			this.panelTUE = new System.Windows.Forms.Panel();
			this.TueTime = new System.Windows.Forms.Label();
			this.panelMON = new System.Windows.Forms.Panel();
			this.MonTime = new System.Windows.Forms.Label();
			this.panelStaffInfo = new System.Windows.Forms.Panel();
			this.lblEmpID = new System.Windows.Forms.Label();
			this.lblEmpName = new System.Windows.Forms.Label();
			this.lblEmpDept = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panelSUN = new System.Windows.Forms.Panel();
			this.SunTime = new System.Windows.Forms.Label();
			this.lblJob = new System.Windows.Forms.Label();
			this.paneLSTAFF.SuspendLayout();
			this.panelHour.SuspendLayout();
			this.panelSAT.SuspendLayout();
			this.panelFRI.SuspendLayout();
			this.panelTHU.SuspendLayout();
			this.panelWED.SuspendLayout();
			this.panelTUE.SuspendLayout();
			this.panelMON.SuspendLayout();
			this.panelStaffInfo.SuspendLayout();
			this.panelSUN.SuspendLayout();
			this.SuspendLayout();
			// 
			// paneLSTAFF
			// 
			this.paneLSTAFF.BackColor = System.Drawing.Color.WhiteSmoke;
			this.paneLSTAFF.Controls.Add(this.panelHour);
			this.paneLSTAFF.Controls.Add(this.panelSAT);
			this.paneLSTAFF.Controls.Add(this.panelFRI);
			this.paneLSTAFF.Controls.Add(this.panelTHU);
			this.paneLSTAFF.Controls.Add(this.panelWED);
			this.paneLSTAFF.Controls.Add(this.panelTUE);
			this.paneLSTAFF.Controls.Add(this.panelMON);
			this.paneLSTAFF.Controls.Add(this.panelStaffInfo);
			this.paneLSTAFF.Controls.Add(this.panel1);
			this.paneLSTAFF.Controls.Add(this.panelSUN);
			this.paneLSTAFF.Location = new System.Drawing.Point(1, 1);
			this.paneLSTAFF.Name = "paneLSTAFF";
			this.paneLSTAFF.Size = new System.Drawing.Size(792, 63);
			this.paneLSTAFF.TabIndex = 36;
			// 
			// panelHour
			// 
			this.panelHour.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panelHour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelHour.Controls.Add(this.TotalHourWrk);
			this.panelHour.Location = new System.Drawing.Point(712, 0);
			this.panelHour.Name = "panelHour";
			this.panelHour.Size = new System.Drawing.Size(80, 52);
			this.panelHour.TabIndex = 26;
			// 
			// TotalHourWrk
			// 
			this.TotalHourWrk.BackColor = System.Drawing.Color.Transparent;
			this.TotalHourWrk.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.TotalHourWrk.Location = new System.Drawing.Point(2, 4);
			this.TotalHourWrk.Name = "TotalHourWrk";
			this.TotalHourWrk.Size = new System.Drawing.Size(80, 48);
			this.TotalHourWrk.TabIndex = 0;
			this.TotalHourWrk.Text = "10";
			this.TotalHourWrk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panelSAT
			// 
			this.panelSAT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelSAT.Controls.Add(this.SatTime);
			this.panelSAT.Location = new System.Drawing.Point(552, 0);
			this.panelSAT.Name = "panelSAT";
			this.panelSAT.Size = new System.Drawing.Size(80, 52);
			this.panelSAT.TabIndex = 25;
			// 
			// SatTime
			// 
			this.SatTime.BackColor = System.Drawing.Color.Transparent;
			this.SatTime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SatTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.SatTime.Location = new System.Drawing.Point(0, 0);
			this.SatTime.Name = "SatTime";
			this.SatTime.Size = new System.Drawing.Size(78, 50);
			this.SatTime.TabIndex = 7;
			this.SatTime.Text = "7:00 AM 9:00 PM";
			this.SatTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.SatTime.Click += new System.EventHandler(this.SatTime_Click);
			// 
			// panelFRI
			// 
			this.panelFRI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelFRI.Controls.Add(this.FriTime);
			this.panelFRI.Location = new System.Drawing.Point(472, 0);
			this.panelFRI.Name = "panelFRI";
			this.panelFRI.Size = new System.Drawing.Size(80, 52);
			this.panelFRI.TabIndex = 24;
			// 
			// FriTime
			// 
			this.FriTime.BackColor = System.Drawing.Color.Transparent;
			this.FriTime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FriTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FriTime.Location = new System.Drawing.Point(0, 0);
			this.FriTime.Name = "FriTime";
			this.FriTime.Size = new System.Drawing.Size(78, 50);
			this.FriTime.TabIndex = 7;
			this.FriTime.Text = "7:00 AM 9:00 PM";
			this.FriTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.FriTime.Click += new System.EventHandler(this.FriTime_Click);
			// 
			// panelTHU
			// 
			this.panelTHU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelTHU.Controls.Add(this.ThuTime);
			this.panelTHU.Location = new System.Drawing.Point(392, 0);
			this.panelTHU.Name = "panelTHU";
			this.panelTHU.Size = new System.Drawing.Size(80, 52);
			this.panelTHU.TabIndex = 23;
			// 
			// ThuTime
			// 
			this.ThuTime.BackColor = System.Drawing.Color.Transparent;
			this.ThuTime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ThuTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ThuTime.Location = new System.Drawing.Point(0, 0);
			this.ThuTime.Name = "ThuTime";
			this.ThuTime.Size = new System.Drawing.Size(78, 50);
			this.ThuTime.TabIndex = 7;
			this.ThuTime.Text = "7:00 AM 9:00 PM";
			this.ThuTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ThuTime.Click += new System.EventHandler(this.ThuTime_Click);
			// 
			// panelWED
			// 
			this.panelWED.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelWED.Controls.Add(this.WedTime);
			this.panelWED.Location = new System.Drawing.Point(312, 0);
			this.panelWED.Name = "panelWED";
			this.panelWED.Size = new System.Drawing.Size(80, 52);
			this.panelWED.TabIndex = 22;
			// 
			// WedTime
			// 
			this.WedTime.BackColor = System.Drawing.Color.Transparent;
			this.WedTime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.WedTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.WedTime.Location = new System.Drawing.Point(0, 0);
			this.WedTime.Name = "WedTime";
			this.WedTime.Size = new System.Drawing.Size(78, 50);
			this.WedTime.TabIndex = 7;
			this.WedTime.Text = "7:00 AM 9:00 PM";
			this.WedTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.WedTime.Click += new System.EventHandler(this.WedTime_Click);
			// 
			// panelTUE
			// 
			this.panelTUE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelTUE.Controls.Add(this.TueTime);
			this.panelTUE.Location = new System.Drawing.Point(232, 0);
			this.panelTUE.Name = "panelTUE";
			this.panelTUE.Size = new System.Drawing.Size(80, 52);
			this.panelTUE.TabIndex = 21;
			// 
			// TueTime
			// 
			this.TueTime.BackColor = System.Drawing.Color.Transparent;
			this.TueTime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TueTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.TueTime.Location = new System.Drawing.Point(0, 0);
			this.TueTime.Name = "TueTime";
			this.TueTime.Size = new System.Drawing.Size(78, 50);
			this.TueTime.TabIndex = 7;
			this.TueTime.Text = "7:00 AM 9:00 PM";
			this.TueTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.TueTime.Click += new System.EventHandler(this.TueTime_Click);
			// 
			// panelMON
			// 
			this.panelMON.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelMON.Controls.Add(this.MonTime);
			this.panelMON.Location = new System.Drawing.Point(152, 0);
			this.panelMON.Name = "panelMON";
			this.panelMON.Size = new System.Drawing.Size(80, 52);
			this.panelMON.TabIndex = 20;
			// 
			// MonTime
			// 
			this.MonTime.BackColor = System.Drawing.Color.Transparent;
			this.MonTime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MonTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MonTime.Location = new System.Drawing.Point(0, 0);
			this.MonTime.Name = "MonTime";
			this.MonTime.Size = new System.Drawing.Size(78, 50);
			this.MonTime.TabIndex = 7;
			this.MonTime.Text = "7:00 AM 9:00 PM";
			this.MonTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.MonTime.Click += new System.EventHandler(this.MonTime_Click);
			// 
			// panelStaffInfo
			// 
			this.panelStaffInfo.BackColor = System.Drawing.Color.LightGray;
			this.panelStaffInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelStaffInfo.Controls.Add(this.lblJob);
			this.panelStaffInfo.Controls.Add(this.lblEmpID);
			this.panelStaffInfo.Controls.Add(this.lblEmpName);
			this.panelStaffInfo.Controls.Add(this.lblEmpDept);
			this.panelStaffInfo.Location = new System.Drawing.Point(0, 0);
			this.panelStaffInfo.Name = "panelStaffInfo";
			this.panelStaffInfo.Size = new System.Drawing.Size(152, 52);
			this.panelStaffInfo.TabIndex = 18;
			// 
			// lblEmpID
			// 
			this.lblEmpID.BackColor = System.Drawing.Color.LightGray;
			this.lblEmpID.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblEmpID.Location = new System.Drawing.Point(0, 0);
			this.lblEmpID.Name = "lblEmpID";
			this.lblEmpID.Size = new System.Drawing.Size(48, 16);
			this.lblEmpID.TabIndex = 7;
			this.lblEmpID.Text = "MYS001";
			this.lblEmpID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblEmpName
			// 
			this.lblEmpName.BackColor = System.Drawing.Color.LightGray;
			this.lblEmpName.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblEmpName.Location = new System.Drawing.Point(0, 16);
			this.lblEmpName.Name = "lblEmpName";
			this.lblEmpName.Size = new System.Drawing.Size(152, 16);
			this.lblEmpName.TabIndex = 17;
			this.lblEmpName.Text = "MARY CHEW CHEAU YONG";
			this.lblEmpName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblEmpDept
			// 
			this.lblEmpDept.BackColor = System.Drawing.Color.LightGray;
			this.lblEmpDept.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblEmpDept.Location = new System.Drawing.Point(0, 32);
			this.lblEmpDept.Name = "lblEmpDept";
			this.lblEmpDept.Size = new System.Drawing.Size(152, 16);
			this.lblEmpDept.TabIndex = 16;
			this.lblEmpDept.Text = "DEPT: OPS (F)";
			this.lblEmpDept.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(152, 54);
			this.panel1.TabIndex = 27;
			// 
			// panelSUN
			// 
			this.panelSUN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelSUN.Controls.Add(this.SunTime);
			this.panelSUN.Location = new System.Drawing.Point(632, 0);
			this.panelSUN.Name = "panelSUN";
			this.panelSUN.Size = new System.Drawing.Size(80, 52);
			this.panelSUN.TabIndex = 19;
			// 
			// SunTime
			// 
			this.SunTime.BackColor = System.Drawing.Color.Transparent;
			this.SunTime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SunTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.SunTime.Location = new System.Drawing.Point(0, 0);
			this.SunTime.Name = "SunTime";
			this.SunTime.Size = new System.Drawing.Size(78, 50);
			this.SunTime.TabIndex = 6;
			this.SunTime.Text = "7:00 AM 9:00 PM";
			this.SunTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.SunTime.Click += new System.EventHandler(this.SunTime_Click);
			// 
			// lblJob
			// 
			this.lblJob.BackColor = System.Drawing.Color.LightGray;
			this.lblJob.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblJob.Location = new System.Drawing.Point(56, 0);
			this.lblJob.Name = "lblJob";
			this.lblJob.Size = new System.Drawing.Size(96, 16);
			this.lblJob.TabIndex = 18;
			this.lblJob.Text = "MYS001";
			this.lblJob.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ACMSRosterDetails
			// 
			this.Controls.Add(this.paneLSTAFF);
			this.Name = "ACMSRosterDetails";
			this.Size = new System.Drawing.Size(800, 56);
			this.paneLSTAFF.ResumeLayout(false);
			this.panelHour.ResumeLayout(false);
			this.panelSAT.ResumeLayout(false);
			this.panelFRI.ResumeLayout(false);
			this.panelTHU.ResumeLayout(false);
			this.panelWED.ResumeLayout(false);
			this.panelTUE.ResumeLayout(false);
			this.panelMON.ResumeLayout(false);
			this.panelStaffInfo.ResumeLayout(false);
			this.panelSUN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
		}

		private void SunTime_Click(object sender, System.EventArgs e)
		{
			WeekDay = "1";
			NLeaveID = nLeaveIDSun;
			OnClick(e);
		}

		private void MonTime_Click(object sender, System.EventArgs e)
		{
			WeekDay = "2";
			NLeaveID = nLeaveIDMon;
			OnClick(e);
		}

		private void TueTime_Click(object sender, System.EventArgs e)
		{
			WeekDay = "3";
			NLeaveID = nLeaveIDTue;
			OnClick(e);
		}

		private void WedTime_Click(object sender, System.EventArgs e)
		{
			WeekDay = "4";
			NLeaveID = nLeaveIDWed;
			OnClick(e);
		}

		private void ThuTime_Click(object sender, System.EventArgs e)
		{
			WeekDay = "5";
			NLeaveID = nLeaveIDThu;
			OnClick(e);
		}

		private void FriTime_Click(object sender, System.EventArgs e)
		{
			WeekDay = "6";
			NLeaveID = nLeaveIDFri;
			OnClick(e);
		}

		private void SatTime_Click(object sender, System.EventArgs e)
		{
			WeekDay = "7";
			NLeaveID = nLeaveIDSat;
			OnClick(e);
		}
	
		public string WeekDay
		{
			get
			{
				return wd;
			}
			set
			{
				wd = value;
			}
		}

		public string WeekNo
		{
			get
			{
				return wk;
			}
			set
			{
				wk = value;
			}
		}

		public string year
		{
			get
			{
				return yr;
			}
			set
			{
				yr = value;
			}

		}

		public int NLeaveID
		{
			get { return nLeaveID; }
			set { nLeaveID = value; }
		}

		public int NLeaveIDSat
		{
			get { return nLeaveIDSat; }
			set { nLeaveIDSat = value; }
		}

		public int NLeaveIDFri
		{
			get { return nLeaveIDFri; }
			set { nLeaveIDFri = value; }
		}

		public int NLeaveIDThu
		{
			get { return nLeaveIDThu; }
			set { nLeaveIDThu = value; }
		}

		public int NLeaveIDWed
		{
			get { return nLeaveIDWed; }
			set { nLeaveIDWed = value; }
		}

		public int NLeaveIDTue
		{
			get { return nLeaveIDTue; }
			set { nLeaveIDTue = value; }
		}

		public int NLeaveIDMon
		{
			get { return nLeaveIDMon; }
			set { nLeaveIDMon = value; }
		}

		public int NLeaveIDSun
		{
			get { return nLeaveIDSun; }
			set { nLeaveIDSun = value; }
		}
	}
}
