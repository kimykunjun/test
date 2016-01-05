using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;


namespace ACMS.Control
{
	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
	public class ClassReportComponent : System.Windows.Forms.UserControl
	{
		public System.Windows.Forms.Panel panelClassComponent;
		public System.Windows.Forms.Label lblClassTime;
		public System.Windows.Forms.Label lblClassInstructor;
		public System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.Label lblLastFourWeekAttendance;
		public System.Windows.Forms.Label lblLastThreeWeekAttendance;
		public System.Windows.Forms.Label lblLastTwoWeekAttendance;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public System.Windows.Forms.Label lblClassId;
		public System.Windows.Forms.Label lblLastWeekAttendance;
		public System.Windows.Forms.Label lblClassName;
		public System.Windows.Forms.Label lblTodayAttendance;
		public System.Windows.Forms.Label lblnDay;
		public System.Windows.Forms.Label lblnClassSchedule;
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


		public ClassReportComponent()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			

			// TODO: Add any initialization after the InitComponent call

		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
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
			this.lblTodayAttendance = new System.Windows.Forms.Label();
			this.lblClassInstructor = new System.Windows.Forms.Label();
			this.lblClassName = new System.Windows.Forms.Label();
			this.lblClassTime = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblLastWeekAttendance = new System.Windows.Forms.Label();
			this.lblLastTwoWeekAttendance = new System.Windows.Forms.Label();
			this.lblLastThreeWeekAttendance = new System.Windows.Forms.Label();
			this.lblLastFourWeekAttendance = new System.Windows.Forms.Label();
			this.lblClassId = new System.Windows.Forms.Label();
			this.lblnDay = new System.Windows.Forms.Label();
			this.lblnClassSchedule = new System.Windows.Forms.Label();
			this.panelClassComponent.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelClassComponent
			// 
			this.panelClassComponent.BackColor = System.Drawing.Color.Gray;
			this.panelClassComponent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelClassComponent.Controls.Add(this.lblTodayAttendance);
			this.panelClassComponent.Controls.Add(this.lblClassInstructor);
			this.panelClassComponent.Controls.Add(this.lblClassName);
			this.panelClassComponent.Controls.Add(this.lblClassTime);
			this.panelClassComponent.Location = new System.Drawing.Point(0, 0);
			this.panelClassComponent.Name = "panelClassComponent";
			this.panelClassComponent.Size = new System.Drawing.Size(136, 36);
			this.panelClassComponent.TabIndex = 1;
			// 
			// lblTodayAttendance
			// 
			this.lblTodayAttendance.BackColor = System.Drawing.Color.Silver;
			this.lblTodayAttendance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTodayAttendance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTodayAttendance.Location = new System.Drawing.Point(96, 0);
			this.lblTodayAttendance.Name = "lblTodayAttendance";
			this.lblTodayAttendance.Size = new System.Drawing.Size(40, 16);
			this.lblTodayAttendance.TabIndex = 10;
			this.lblTodayAttendance.Text = "12";
			// 
			// lblClassInstructor
			// 
			this.lblClassInstructor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblClassInstructor.BackColor = System.Drawing.Color.PaleGreen;
			this.lblClassInstructor.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblClassInstructor.Location = new System.Drawing.Point(0, 20);
			this.lblClassInstructor.Name = "lblClassInstructor";
			this.lblClassInstructor.Size = new System.Drawing.Size(135, 12);
			this.lblClassInstructor.TabIndex = 4;
			this.lblClassInstructor.Text = "AGNES KOH";
			this.lblClassInstructor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblClassInstructor.Click += new System.EventHandler(this.lblClassInstructor_Click);
			// 
			// lblClassName
			// 
			this.lblClassName.BackColor = System.Drawing.Color.PaleGreen;
			this.lblClassName.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblClassName.Location = new System.Drawing.Point(0, 10);
			this.lblClassName.Name = "lblClassName";
			this.lblClassName.Size = new System.Drawing.Size(136, 10);
			this.lblClassName.TabIndex = 3;
			this.lblClassName.Text = "YOGA";
			this.lblClassName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblClassName.Click += new System.EventHandler(this.lblClassName_Click);
			// 
			// lblClassTime
			// 
			this.lblClassTime.BackColor = System.Drawing.Color.PaleGreen;
			this.lblClassTime.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblClassTime.Location = new System.Drawing.Point(-8, 0);
			this.lblClassTime.Name = "lblClassTime";
			this.lblClassTime.Size = new System.Drawing.Size(144, 10);
			this.lblClassTime.TabIndex = 2;
			this.lblClassTime.Text = "10:30 pm";
			this.lblClassTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblClassTime.Click += new System.EventHandler(this.lblClassTime_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(128)));
			this.panel1.Controls.Add(this.lblLastWeekAttendance);
			this.panel1.Controls.Add(this.lblLastTwoWeekAttendance);
			this.panel1.Controls.Add(this.lblLastThreeWeekAttendance);
			this.panel1.Controls.Add(this.lblLastFourWeekAttendance);
			this.panel1.Location = new System.Drawing.Point(0, 32);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(128, 16);
			this.panel1.TabIndex = 2;
			// 
			// lblLastWeekAttendance
			// 
			this.lblLastWeekAttendance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(224)), ((System.Byte)(192)));
			this.lblLastWeekAttendance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblLastWeekAttendance.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblLastWeekAttendance.Location = new System.Drawing.Point(96, 0);
			this.lblLastWeekAttendance.Name = "lblLastWeekAttendance";
			this.lblLastWeekAttendance.Size = new System.Drawing.Size(32, 16);
			this.lblLastWeekAttendance.TabIndex = 5;
			this.lblLastWeekAttendance.Text = "12";
			this.lblLastWeekAttendance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblLastTwoWeekAttendance
			// 
			this.lblLastTwoWeekAttendance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(224)), ((System.Byte)(192)));
			this.lblLastTwoWeekAttendance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblLastTwoWeekAttendance.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblLastTwoWeekAttendance.Location = new System.Drawing.Point(64, 0);
			this.lblLastTwoWeekAttendance.Name = "lblLastTwoWeekAttendance";
			this.lblLastTwoWeekAttendance.Size = new System.Drawing.Size(32, 16);
			this.lblLastTwoWeekAttendance.TabIndex = 4;
			this.lblLastTwoWeekAttendance.Text = "12";
			this.lblLastTwoWeekAttendance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblLastThreeWeekAttendance
			// 
			this.lblLastThreeWeekAttendance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(224)), ((System.Byte)(192)));
			this.lblLastThreeWeekAttendance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblLastThreeWeekAttendance.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblLastThreeWeekAttendance.Location = new System.Drawing.Point(32, 0);
			this.lblLastThreeWeekAttendance.Name = "lblLastThreeWeekAttendance";
			this.lblLastThreeWeekAttendance.Size = new System.Drawing.Size(32, 16);
			this.lblLastThreeWeekAttendance.TabIndex = 3;
			this.lblLastThreeWeekAttendance.Text = "12";
			this.lblLastThreeWeekAttendance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblLastFourWeekAttendance
			// 
			this.lblLastFourWeekAttendance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(224)), ((System.Byte)(192)));
			this.lblLastFourWeekAttendance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblLastFourWeekAttendance.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblLastFourWeekAttendance.Location = new System.Drawing.Point(0, 0);
			this.lblLastFourWeekAttendance.Name = "lblLastFourWeekAttendance";
			this.lblLastFourWeekAttendance.Size = new System.Drawing.Size(32, 16);
			this.lblLastFourWeekAttendance.TabIndex = 2;
			this.lblLastFourWeekAttendance.Text = "12";
			this.lblLastFourWeekAttendance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblClassId
			// 
			this.lblClassId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblClassId.BackColor = System.Drawing.Color.Transparent;
			this.lblClassId.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblClassId.Location = new System.Drawing.Point(8, 8);
			this.lblClassId.Name = "lblClassId";
			this.lblClassId.Size = new System.Drawing.Size(16, 16);
			this.lblClassId.TabIndex = 8;
			this.lblClassId.Text = "AGNES KOH";
			this.lblClassId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblClassId.Visible = false;
			// 
			// lblnDay
			// 
			this.lblnDay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblnDay.BackColor = System.Drawing.Color.Transparent;
			this.lblnDay.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblnDay.Location = new System.Drawing.Point(24, 8);
			this.lblnDay.Name = "lblnDay";
			this.lblnDay.Size = new System.Drawing.Size(16, 16);
			this.lblnDay.TabIndex = 10;
			this.lblnDay.Text = "AGNES KOH";
			this.lblnDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblnDay.Visible = false;
			// 
			// lblnClassSchedule
			// 
			this.lblnClassSchedule.Location = new System.Drawing.Point(40, 16);
			this.lblnClassSchedule.Name = "lblnClassSchedule";
			this.lblnClassSchedule.TabIndex = 11;
			this.lblnClassSchedule.Visible = false;
			// 
			// ClassReportComponent
			// 
			this.BackColor = System.Drawing.Color.Silver;
			this.Controls.Add(this.lblnClassSchedule);
			this.Controls.Add(this.lblnDay);
			this.Controls.Add(this.lblClassId);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panelClassComponent);
			this.Name = "ClassReportComponent";
			this.Size = new System.Drawing.Size(128, 50);
			this.panelClassComponent.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
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




		
		
		

	}
}
