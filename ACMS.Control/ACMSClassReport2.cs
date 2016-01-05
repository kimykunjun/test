using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using ACMS.Utils;

namespace ACMS.Control
{
	/// <summary>
	/// Summary description for ACMSClassReport2.
	/// </summary>
	public class ClassReportComponent2 : System.Windows.Forms.UserControl
	{
		private SqlConnection connection;
		private string connectionString;
		public System.Windows.Forms.Panel panelClassComponent;
		public System.Windows.Forms.Label lblClassTime;
		public System.Windows.Forms.Label lblClassName;
		public System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.Label lblLastFourWeekAttendance;
		public System.Windows.Forms.Label lblLastThreeWeekAttendance;
		public System.Windows.Forms.Label lblLastTwoWeekAttendance;
		public System.Windows.Forms.Label lblLastWeekAttendance;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public System.Windows.Forms.Label lblBranch;
		public System.Windows.Forms.Label lblTodayAttendance;
		public System.Windows.Forms.Label lblClassId;
		public System.Windows.Forms.Label lblnDay;
		public System.Windows.Forms.Label lblClassInstructor;
		public System.Windows.Forms.Label lblClassSchedule;
		private DataTable _cs;
		public DataTable ClassSchedule
		{
			get
			{
				return _cs;
			}
			set
			{
				_cs = value;
			}
		}

		public ClassReportComponent2()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);

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
			this.panelClassComponent = new System.Windows.Forms.Panel();
			this.lblClassInstructor = new System.Windows.Forms.Label();
			this.lblnDay = new System.Windows.Forms.Label();
			this.lblClassId = new System.Windows.Forms.Label();
			this.lblTodayAttendance = new System.Windows.Forms.Label();
			this.lblBranch = new System.Windows.Forms.Label();
			this.lblClassName = new System.Windows.Forms.Label();
			this.lblClassTime = new System.Windows.Forms.Label();
			this.lblClassSchedule = new System.Windows.Forms.Label();
			this.panelClassComponent.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelClassComponent
			// 
			this.panelClassComponent.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.panelClassComponent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelClassComponent.Controls.Add(this.lblClassSchedule);
			this.panelClassComponent.Controls.Add(this.lblClassInstructor);
			this.panelClassComponent.Controls.Add(this.lblnDay);
			this.panelClassComponent.Controls.Add(this.lblClassId);
			this.panelClassComponent.Controls.Add(this.lblTodayAttendance);
			this.panelClassComponent.Controls.Add(this.lblBranch);
			this.panelClassComponent.Controls.Add(this.lblClassName);
			this.panelClassComponent.Controls.Add(this.lblClassTime);
			this.panelClassComponent.Location = new System.Drawing.Point(0, 0);
			this.panelClassComponent.Name = "panelClassComponent";
			this.panelClassComponent.Size = new System.Drawing.Size(128, 48);
			this.panelClassComponent.TabIndex = 5;
			// 
			// lblClassInstructor
			// 
			this.lblClassInstructor.BackColor = System.Drawing.Color.Transparent;
			this.lblClassInstructor.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
			this.lblClassInstructor.Location = new System.Drawing.Point(0, 32);
			this.lblClassInstructor.Name = "lblClassInstructor";
			this.lblClassInstructor.Size = new System.Drawing.Size(120, 8);
			this.lblClassInstructor.TabIndex = 9;
			this.lblClassInstructor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblnDay
			// 
			this.lblnDay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblnDay.BackColor = System.Drawing.Color.Transparent;
			this.lblnDay.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblnDay.Location = new System.Drawing.Point(35, 15);
			this.lblnDay.Name = "lblnDay";
			this.lblnDay.Size = new System.Drawing.Size(21, 16);
			this.lblnDay.TabIndex = 8;
			this.lblnDay.Text = "AGNES KOH";
			this.lblnDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblnDay.Visible = false;
			// 
			// lblClassId
			// 
			this.lblClassId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblClassId.BackColor = System.Drawing.Color.Transparent;
			this.lblClassId.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblClassId.Location = new System.Drawing.Point(-16, 16);
			this.lblClassId.Name = "lblClassId";
			this.lblClassId.Size = new System.Drawing.Size(56, 16);
			this.lblClassId.TabIndex = 7;
			this.lblClassId.Text = "AGNES KOH";
			this.lblClassId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblClassId.Visible = false;
			// 
			// lblTodayAttendance
			// 
			this.lblTodayAttendance.BackColor = System.Drawing.Color.Silver;
			this.lblTodayAttendance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTodayAttendance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTodayAttendance.Location = new System.Drawing.Point(104, 0);
			this.lblTodayAttendance.Name = "lblTodayAttendance";
			this.lblTodayAttendance.Size = new System.Drawing.Size(24, 16);
			this.lblTodayAttendance.TabIndex = 6;
			this.lblTodayAttendance.Text = "12";
			this.lblTodayAttendance.Click += new System.EventHandler(this.lblTodayAttendance_Click);
			// 
			// lblBranch
			// 
			this.lblBranch.BackColor = System.Drawing.Color.Transparent;
			this.lblBranch.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblBranch.Location = new System.Drawing.Point(0, 0);
			this.lblBranch.Name = "lblBranch";
			this.lblBranch.Size = new System.Drawing.Size(128, 16);
			this.lblBranch.TabIndex = 5;
			this.lblBranch.Text = "Branch";
			this.lblBranch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblBranch.Click += new System.EventHandler(this.lblBranch_Click);
			// 
			// lblClassName
			// 
			this.lblClassName.BackColor = System.Drawing.Color.Transparent;
			this.lblClassName.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblClassName.Location = new System.Drawing.Point(-24, 24);
			this.lblClassName.Name = "lblClassName";
			this.lblClassName.Size = new System.Drawing.Size(176, 10);
			this.lblClassName.TabIndex = 3;
			this.lblClassName.Text = "YOGA";
			this.lblClassName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblClassName.Click += new System.EventHandler(this.lblClassName_Click);
			// 
			// lblClassTime
			// 
			this.lblClassTime.BackColor = System.Drawing.Color.Transparent;
			this.lblClassTime.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblClassTime.Location = new System.Drawing.Point(-16, 16);
			this.lblClassTime.Name = "lblClassTime";
			this.lblClassTime.Size = new System.Drawing.Size(160, 8);
			this.lblClassTime.TabIndex = 2;
			this.lblClassTime.Text = "10:30 pm";
			this.lblClassTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblClassTime.Click += new System.EventHandler(this.lblClassTime_Click);
			// 
			// lblClassSchedule
			// 
			this.lblClassSchedule.BackColor = System.Drawing.Color.Transparent;
			this.lblClassSchedule.Location = new System.Drawing.Point(0, 40);
			this.lblClassSchedule.Name = "lblClassSchedule";
			this.lblClassSchedule.TabIndex = 10;
			this.lblClassSchedule.Visible = false;
			// 
			// ClassReportComponent2
			// 
			this.Controls.Add(this.panelClassComponent);
			this.Name = "ClassReportComponent2";
			this.Size = new System.Drawing.Size(128, 48);
			this.panelClassComponent.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void init(DataTable _dtClassSchedule)
		{
			this.lblClassTime.DataBindings.Add("Text",_dtClassSchedule,"dtStartTime");
			this.lblClassName.DataBindings.Add("Text",_dtClassSchedule,"strClassCode");
			this.lblClassInstructor.DataBindings.Add("Text",_dtClassSchedule,"nInstructorID");
			//this.lblTodayAttendance.Text = Convert.ToString(TodayAttendance);
			//this.lblLastWeekAttendance.Text = Convert.ToString(LastWeekAttendance);
			//this.lblLastTwoWeekAttendance.Text = Convert.ToString(LastTwoWeekAttendance);
			//this.lblLastThreeWeekAttendance.Text = Convert.ToString(LastThreeWeekAttendance);
			this.ClassSchedule = _dtClassSchedule;
		}

//		private void mdInstructorInit()
//		{
//			DataSet _ds = new DataSet(); 
//			string strSQL = "select * from tblEmployee where nStatusID=1";
//			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
//			DataTable dt = _ds.Tables["Table"];
//
//			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
//			
//			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nEmployeeID","Employee Id",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
//			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strEmployeeName","Employee Name",30,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
//			
//			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lblClassInstructor.Properties, dt, col,"strEmployeeName","nEmployeeID","Employee");
//
////			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lblClassInstructor, dt, col,"strEmployeeName","nEmployeeID","Manager" );
//
//		}

		private void lblClassTime_Click(object sender, System.EventArgs e)
		{
			OnClick(e);
		}

		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
		}

		private void lblClassName_Click(object sender, System.EventArgs e)
		{
			OnClick(e);
		}

		private void lblClassInstructor_Click(object sender, System.EventArgs e)
		{
			OnClick(e);
		}

		private void lblTodayAttendance_Click(object sender, EventArgs e)
		{

		}

		private void lblBranch_Click(object sender, EventArgs e)
		{

		}
	}
}
