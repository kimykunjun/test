using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ACMS.ACMSPOS2
{
	/// <summary>
	/// Summary description for FormMineralWaterClosingDayCount.
	/// </summary>
	public class FormMineralWaterClosingDayCount : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.CalcEdit calcEdit1;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormMineralWaterClosingDayCount()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public int Qty
		{
			get {return (int)calcEdit1.Value;}
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
			this.label1 = new System.Windows.Forms.Label();
			this.calcEdit1 = new DevExpress.XtraEditors.CalcEdit();
			this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.calcEdit1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(0, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(216, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Remaining Mineral Water ";
			// 
			// calcEdit1
			// 
			this.calcEdit1.Location = new System.Drawing.Point(224, 16);
			this.calcEdit1.Name = "calcEdit1";
			// 
			// calcEdit1.Properties
			// 
			this.calcEdit1.Properties.EditFormat.FormatString = "n";
			this.calcEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.calcEdit1.Properties.Mask.EditMask = "d4";
			this.calcEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.calcEdit1.Properties.Precision = 0;
			this.calcEdit1.Size = new System.Drawing.Size(176, 20);
			this.calcEdit1.TabIndex = 1;
			// 
			// simpleButtonCancel
			// 
			this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButtonCancel.Location = new System.Drawing.Point(208, 56);
			this.simpleButtonCancel.Name = "simpleButtonCancel";
			this.simpleButtonCancel.TabIndex = 16;
			this.simpleButtonCancel.Text = "Cancel";
			// 
			// simpleButtonOK
			// 
			this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButtonOK.Location = new System.Drawing.Point(120, 56);
			this.simpleButtonOK.Name = "simpleButtonOK";
			this.simpleButtonOK.TabIndex = 15;
			this.simpleButtonOK.Text = "OK";
			this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
			// 
			// FormMineralWaterClosingDayCount
			// 
			this.AcceptButton = this.simpleButtonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.simpleButtonCancel;
			this.ClientSize = new System.Drawing.Size(424, 86);
			this.Controls.Add(this.simpleButtonCancel);
			this.Controls.Add(this.simpleButtonOK);
			this.Controls.Add(this.calcEdit1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormMineralWaterClosingDayCount";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Remaining Mineral Water";
			((System.ComponentModel.ISupportInitialize)(this.calcEdit1.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
