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
	public class ClassComponent : System.Windows.Forms.UserControl
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public System.Windows.Forms.Label lblClassInstructor;
		public System.Windows.Forms.Label lblClassName;
		public System.Windows.Forms.Label lblClassTime;
		public System.Windows.Forms.Panel panelClassComponent;
		public System.Windows.Forms.Label lblClassHall;
        public System.Windows.Forms.Label lblPeriod;
        public System.Windows.Forms.Label lblClassScheduleID;
		private DataTable _cs;
		private int _dy;
		private string _br;
		private string _cn;
		private string _start;
		private int _hall;
        private int _csid;
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
		public String Branch
		{
			get
			{
				return _br;
			}
			set
			{
				_br = value;
			}
		}
		public int Day
		{
			get
			{
				return _dy;
			}
			set
			{
				_dy = value;
			}
		}
		public String ClassName
		{
			get
			{
				return _cn;
			}
			set
			{
				_cn = value;
			}
		}

		public string StartTime
		{
			get
			{
				return _start;
			}
			set
			{
				_start = value;
			}
		}

		public int ClassHall
		{
			get
			{
				return _hall;
			}
			set
			{
				_hall = value;
			}
		}

        public int ClassScheduleID
        {
            get
            {
                return _csid;
            }
            set
            {
                _csid = value;
            }
        }


		public ClassComponent()
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
			this.lblClassInstructor = new System.Windows.Forms.Label();
			this.lblClassName = new System.Windows.Forms.Label();
			this.lblClassTime = new System.Windows.Forms.Label();
			this.panelClassComponent = new System.Windows.Forms.Panel();
			this.lblClassHall = new System.Windows.Forms.Label();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.lblClassScheduleID = new System.Windows.Forms.Label();
			this.panelClassComponent.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblClassInstructor
			// 
			this.lblClassInstructor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblClassInstructor.BackColor = System.Drawing.Color.PaleGreen;
			this.lblClassInstructor.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblClassInstructor.ForeColor = System.Drawing.Color.Black;
			this.lblClassInstructor.Location = new System.Drawing.Point(0, 36);
			this.lblClassInstructor.Name = "lblClassInstructor";
			this.lblClassInstructor.Size = new System.Drawing.Size(96, 12);
			this.lblClassInstructor.TabIndex = 4;
			this.lblClassInstructor.Text = "AGNES KOH";
			this.lblClassInstructor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblClassInstructor.Click += new System.EventHandler(this.lblClassInstructor_Click);
			// 
			// lblClassName
			// 
			this.lblClassName.BackColor = System.Drawing.Color.PaleGreen;
			this.lblClassName.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblClassName.Location = new System.Drawing.Point(0, 24);
			this.lblClassName.Name = "lblClassName";
			this.lblClassName.Size = new System.Drawing.Size(96, 12);
			this.lblClassName.TabIndex = 3;
			this.lblClassName.Text = "YOGA";
			this.lblClassName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblClassName.Click += new System.EventHandler(this.lblClassName_Click);
			// 
			// lblClassTime
			// 
			this.lblClassTime.BackColor = System.Drawing.Color.PaleGreen;
			this.lblClassTime.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblClassTime.Location = new System.Drawing.Point(0, 12);
			this.lblClassTime.Name = "lblClassTime";
			this.lblClassTime.Size = new System.Drawing.Size(96, 12);
			this.lblClassTime.TabIndex = 2;
			this.lblClassTime.Text = "10:30 pm - 11:30 pm";
			this.lblClassTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblClassTime.Click += new System.EventHandler(this.lblClassTime_Click);
			// 
			// panelClassComponent
			// 
			this.panelClassComponent.BackColor = System.Drawing.Color.Gray;
			this.panelClassComponent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelClassComponent.Controls.Add(this.lblClassHall);
            this.panelClassComponent.Controls.Add(this.lblPeriod);
			this.panelClassComponent.Controls.Add(this.lblClassInstructor);
			this.panelClassComponent.Controls.Add(this.lblClassName);
			this.panelClassComponent.Controls.Add(this.lblClassTime);
			this.panelClassComponent.Location = new System.Drawing.Point(0, 0);
			this.panelClassComponent.Name = "panelClassComponent";
			this.panelClassComponent.Size = new System.Drawing.Size(97, 48);
			this.panelClassComponent.TabIndex = 1;
			// 
			// lblClassHall
			// 
			this.lblClassHall.BackColor = System.Drawing.Color.PaleGreen;
			this.lblClassHall.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblClassHall.Location = new System.Drawing.Point(0, 12);
			this.lblClassHall.Name = "lblClassHall";
			this.lblClassHall.Size = new System.Drawing.Size(96, 12);
			this.lblClassHall.TabIndex = 5;
			this.lblClassHall.Text = "Hall 1";
            this.lblClassHall.Visible = false;
			this.lblClassHall.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblClassHall.Click += new System.EventHandler(this.lblClassHall_Click);
            // 
            // lblPeriod
            // 
            this.lblPeriod.BackColor = System.Drawing.Color.PaleGreen;
            this.lblPeriod.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.lblPeriod.Location = new System.Drawing.Point(0, 0);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(96, 12);
            this.lblPeriod.TabIndex = 5;
            this.lblPeriod.Text = "";
            this.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPeriod.Click += new System.EventHandler(this.lblPeriod_Click);
            // 
            // lblClassScheduleID
            // 
            this.lblClassScheduleID.BackColor = System.Drawing.Color.PaleGreen;
            this.lblClassScheduleID.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.lblClassScheduleID.Location = new System.Drawing.Point(0, 12);
            this.lblClassScheduleID.Name = "lblClassScheduleID";
            this.lblClassScheduleID.Size = new System.Drawing.Size(96, 12);
            this.lblClassScheduleID.TabIndex = 5;
            this.lblClassScheduleID.Text = "";
            this.lblClassScheduleID.Visible = false;
            this.lblClassScheduleID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClassScheduleID.Click += new System.EventHandler(this.lblPeriod_Click);
			// 
			// ClassComponent
			// 
			this.BackColor = System.Drawing.Color.Silver;
			this.Controls.Add(this.panelClassComponent);
			this.Name = "ClassComponent";
			this.Size = new System.Drawing.Size(97, 50);
			this.panelClassComponent.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void init(DataTable _dtClassSchedule)
		{
			//this.lblClassTime.DataBindings.Add("Text",_dtClassSchedule,"dtStartTime");
            //this.lblClassName.DataBindings.Add("Text",_dtClassSchedule,"strClassCode");
			//this.lblClassInstructor.DataBindings.Add("Text",_dtClassSchedule,"nInstructorID");
			this.ClassSchedule = _dtClassSchedule;
		}

		private void lblClassTime_Click(object sender, System.EventArgs e)
		{
			OnClick(e);
		}

		protected override void OnClick(EventArgs e)
		{
			ClassName = lblClassName.Text.ToString();
			ClassHall = Convert.ToInt32(lblClassHall.Text.ToString().Replace("Hall ","") );
            ClassScheduleID = Convert.ToInt32(lblClassScheduleID.Text.ToString());
			//StartTime = Convert.ToDateTime(lblClassTime.Text);
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

		private void lblClassHall_Click(object sender, System.EventArgs e)
		{
			OnClick(e);
		}

        private void lblPeriod_Click(object sender, System.EventArgs e)
        {
            OnClick(e);
        }
	}

}
