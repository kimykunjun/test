using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ACMS
{
	/// <summary>
	/// Summary description for FormSpaBooking.
	/// </summary>
	public class FormSpaBooking : System.Windows.Forms.Form
	{
		private ACMS.SpaBookingControl spaBooking1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormSpaBooking()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			spaBooking1.Init(false);
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
			this.spaBooking1 = new ACMS.SpaBookingControl();
			this.SuspendLayout();
			// 
			// spaBooking1
			// 
			this.spaBooking1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spaBooking1.Location = new System.Drawing.Point(0, 0);
			this.spaBooking1.Name = "spaBooking1";
			this.spaBooking1.Size = new System.Drawing.Size(928, 518);
			this.spaBooking1.SpaBooking = null;
			this.spaBooking1.StrBranchCode = "";
			this.spaBooking1.TabIndex = 0;
			// 
			// FormSpaBooking
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(928, 518);
			this.Controls.Add(this.spaBooking1);
			this.Name = "FormSpaBooking";
			this.Text = "FormSpaBooking";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
