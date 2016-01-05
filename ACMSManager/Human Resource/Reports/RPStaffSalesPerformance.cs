using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ACMS.ACMSManager.Human_Resource.Reports
{
	/// <summary>
	/// Summary description for RPStaffSalesPerformance.
	/// </summary>
	public class RPStaffSalesPerformance : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.LookUpEdit lookUpEdit2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label6;
		private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
		private DevExpress.XtraEditors.LookUpEdit luedtRPStaffSalesPerfmEmpID;
		private System.Windows.Forms.Label label7;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RPStaffSalesPerformance()
		{
			//
			// Required for Windows Form Designer support
			//
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
			this.lookUpEdit2 = new DevExpress.XtraEditors.LookUpEdit();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.luedtRPStaffSalesPerfmEmpID = new DevExpress.XtraEditors.LookUpEdit();
			this.label6 = new System.Windows.Forms.Label();
			this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
			this.label7 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtRPStaffSalesPerfmEmpID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
			this.SuspendLayout();
			// 
			// lookUpEdit2
			// 
			this.lookUpEdit2.Location = new System.Drawing.Point(96, 40);
			this.lookUpEdit2.Name = "lookUpEdit2";
			// 
			// lookUpEdit2.Properties
			// 
			this.lookUpEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lookUpEdit2.Size = new System.Drawing.Size(144, 20);
			this.lookUpEdit2.TabIndex = 22;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(16, 40);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 23);
			this.label5.TabIndex = 21;
			this.label5.Text = "Category";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(496, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 23);
			this.label4.TabIndex = 20;
			this.label4.Text = "Year";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(376, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 23);
			this.label3.TabIndex = 19;
			this.label3.Text = "Month";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(16, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 18;
			this.label2.Text = "Month";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(144, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 23);
			this.label1.TabIndex = 17;
			this.label1.Text = "Year";
			// 
			// luedtRPStaffSalesPerfmEmpID
			// 
			this.luedtRPStaffSalesPerfmEmpID.Location = new System.Drawing.Point(376, 40);
			this.luedtRPStaffSalesPerfmEmpID.Name = "luedtRPStaffSalesPerfmEmpID";
			// 
			// luedtRPStaffSalesPerfmEmpID.Properties
			// 
			this.luedtRPStaffSalesPerfmEmpID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.luedtRPStaffSalesPerfmEmpID.Size = new System.Drawing.Size(168, 20);
			this.luedtRPStaffSalesPerfmEmpID.TabIndex = 28;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(288, 40);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 23);
			this.label6.TabIndex = 27;
			this.label6.Text = "Employee";
			// 
			// pivotGridControl1
			// 
			this.pivotGridControl1.Cursor = System.Windows.Forms.Cursors.Default;
			this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pivotGridControl1.Location = new System.Drawing.Point(0, 78);
			this.pivotGridControl1.Name = "pivotGridControl1";
			this.pivotGridControl1.Size = new System.Drawing.Size(976, 384);
			this.pivotGridControl1.TabIndex = 29;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.Location = new System.Drawing.Point(264, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 23);
			this.label7.TabIndex = 30;
			this.label7.Text = "To";
			// 
			// RPStaffSalesPerformance
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(976, 462);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.pivotGridControl1);
			this.Controls.Add(this.luedtRPStaffSalesPerfmEmpID);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.lookUpEdit2);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "RPStaffSalesPerformance";
			this.Text = "Staff Sales Performance";
			this.Load += new System.EventHandler(this.RPStaffSalesPerformance_Load);
			((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.luedtRPStaffSalesPerfmEmpID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void RPStaffSalesPerformance_Load(object sender, System.EventArgs e)
		{
			new ACMS.XtraUtils.LookupEditBuilder.EmployeeIDLookupEditBuilder(luedtRPStaffSalesPerfmEmpID.Properties);
		}

		
	}
}
