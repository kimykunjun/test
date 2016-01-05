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
	public class DayClassReportComponent : System.Windows.Forms.UserControl
	{
		public System.Windows.Forms.Panel panelClassComponent;
		public System.Windows.Forms.Label lblClassTime;
		public System.Windows.Forms.Label lblClassInstructor;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public System.Windows.Forms.Label lblClassId;
		public System.Windows.Forms.Label lblnClassSchedule;
		public System.Windows.Forms.Label lblClassName;
		public System.Windows.Forms.Label lblTodayAttendance;
		public System.Windows.Forms.Label lblnDay;
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


		public DayClassReportComponent()
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
			this.lblnClassSchedule = new System.Windows.Forms.Label();
			this.lblClassId = new System.Windows.Forms.Label();
			this.lblnDay = new System.Windows.Forms.Label();
			this.panelClassComponent.SuspendLayout();
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
			this.panelClassComponent.Controls.Add(this.lblnClassSchedule);
			this.panelClassComponent.Location = new System.Drawing.Point(0, 0);
			this.panelClassComponent.Name = "panelClassComponent";
			this.panelClassComponent.Size = new System.Drawing.Size(136, 56);
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
			this.lblClassInstructor.Location = new System.Drawing.Point(-8, 32);
			this.lblClassInstructor.Name = "lblClassInstructor";
			this.lblClassInstructor.Size = new System.Drawing.Size(135, 24);
			this.lblClassInstructor.TabIndex = 4;
			this.lblClassInstructor.Text = "AGNES KOH";
			this.lblClassInstructor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblClassInstructor.Click += new System.EventHandler(this.lblClassInstructor_Click);
			// 
			// lblClassName
			// 
			this.lblClassName.BackColor = System.Drawing.Color.PaleGreen;
			this.lblClassName.Font = new System.Drawing.Font("Tahoma", 7F);
			this.lblClassName.Location = new System.Drawing.Point(-8, 16);
			this.lblClassName.Name = "lblClassName";
			this.lblClassName.Size = new System.Drawing.Size(136, 22);
			this.lblClassName.TabIndex = 3;
			this.lblClassName.Text = "YOGA";
			this.lblClassName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblClassName.Click += new System.EventHandler(this.lblClassName_Click);
			// 
			// lblClassTime
			// 
			this.lblClassTime.BackColor = System.Drawing.Color.PaleGreen;
			this.lblClassTime.Font = new System.Drawing.Font("Tahoma", 7F);
			this.lblClassTime.Location = new System.Drawing.Point(-8, 0);
			this.lblClassTime.Name = "lblClassTime";
			this.lblClassTime.Size = new System.Drawing.Size(144, 16);
			this.lblClassTime.TabIndex = 2;
			this.lblClassTime.Text = "10:30 pm";
			this.lblClassTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblClassTime.Click += new System.EventHandler(this.lblClassTime_Click);
			this.lblClassTime.Leave += new System.EventHandler(this.lblClassTime_Leave);
			// 
			// lblnClassSchedule
			// 
			this.lblnClassSchedule.Location = new System.Drawing.Point(0, 0);
			this.lblnClassSchedule.Name = "lblnClassSchedule";
			this.lblnClassSchedule.TabIndex = 11;
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
			// DayClassReportComponent
			// 
			this.BackColor = System.Drawing.Color.Silver;
			this.Controls.Add(this.lblnDay);
			this.Controls.Add(this.lblClassId);
			this.Controls.Add(this.panelClassComponent);
			this.Name = "DayClassReportComponent";
			this.Size = new System.Drawing.Size(128, 56);
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

		private void lblClassTime_Leave(object sender, System.EventArgs e)
		{
			
		}




		
		
		

	}
}
