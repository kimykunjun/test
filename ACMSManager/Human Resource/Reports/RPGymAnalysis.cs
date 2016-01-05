using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

namespace ACMS.ACMSManager.Reports
{
	/// <summary>
	/// Summary description for RPGymAnalysis.
	/// </summary>
	public class RPGymAnalysis : DevExpress.XtraEditors.XtraForm
	{
		private string connectionString;
		private SqlConnection connection;
		private System.Windows.Forms.Label label63;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.SimpleButton btnReset;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
		private bool isFinishBind = false;
		private int EmployeeId;
		private DevExpress.XtraEditors.DateEdit DateFrom;
		private DevExpress.XtraEditors.DateEdit DateTo;
		private DevExpress.XtraEditors.TimeEdit TimeFrom;
		private DevExpress.XtraEditors.TimeEdit TimeTo;
		private DevExpress.XtraPivotGrid.PivotGridControl gvGymAnalysis;
		private DevExpress.XtraEditors.HyperLinkEdit PRINT1;
		private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
		private System.ComponentModel.IContainer components;

		public RPGymAnalysis(int empId)
		{
			//
			// Required for Windows Form Designer support
			//
			EmployeeId = empId;
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
			this.components = new System.ComponentModel.Container();
			this.gvGymAnalysis = new DevExpress.XtraPivotGrid.PivotGridControl();
			this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.DateFrom = new DevExpress.XtraEditors.DateEdit();
			this.DateTo = new DevExpress.XtraEditors.DateEdit();
			this.TimeFrom = new DevExpress.XtraEditors.TimeEdit();
			this.TimeTo = new DevExpress.XtraEditors.TimeEdit();
			this.label63 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnReset = new DevExpress.XtraEditors.SimpleButton();
			this.PRINT1 = new DevExpress.XtraEditors.HyperLinkEdit();
			this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
			this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
			((System.ComponentModel.ISupportInitialize)(this.gvGymAnalysis)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DateTo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TimeFrom.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TimeTo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
			this.SuspendLayout();
			// 
			// gvGymAnalysis
			// 
			this.gvGymAnalysis.Cursor = System.Windows.Forms.Cursors.Default;
			this.gvGymAnalysis.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.gvGymAnalysis.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
																								 this.pivotGridField1,
																								 this.pivotGridField2,
																								 this.pivotGridField3});
			this.gvGymAnalysis.Location = new System.Drawing.Point(0, 38);
			this.gvGymAnalysis.Name = "gvGymAnalysis";
			this.gvGymAnalysis.OptionsCustomization.AllowDrag = false;
			this.gvGymAnalysis.OptionsCustomization.AllowFilter = false;
			this.gvGymAnalysis.OptionsCustomization.AllowSort = false;
			this.gvGymAnalysis.OptionsView.ShowDataHeaders = false;
			this.gvGymAnalysis.OptionsView.ShowFilterHeaders = false;
			this.gvGymAnalysis.Size = new System.Drawing.Size(962, 448);
			this.gvGymAnalysis.TabIndex = 0;
			// 
			// pivotGridField1
			// 
			this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.pivotGridField1.AreaIndex = 0;
			this.pivotGridField1.FieldName = "nClassInstanceID";
			this.pivotGridField1.Name = "pivotGridField1";
			this.pivotGridField1.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
			// 
			// pivotGridField2
			// 
			this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
			this.pivotGridField2.AreaIndex = 0;
			this.pivotGridField2.Caption = "Branch";
			this.pivotGridField2.FieldName = "strBranchCode";
			this.pivotGridField2.Name = "pivotGridField2";
			// 
			// pivotGridField3
			// 
			this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField3.AreaIndex = 0;
			this.pivotGridField3.Caption = "Date";
			this.pivotGridField3.FieldName = "dtDate";
			this.pivotGridField3.Name = "pivotGridField3";
			this.pivotGridField3.ValueFormat.FormatString = "MM/dd/yyyy";
			this.pivotGridField3.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			// 
			// DateFrom
			// 
			this.DateFrom.EditValue = null;
			this.DateFrom.Location = new System.Drawing.Point(80, 8);
			this.DateFrom.Name = "DateFrom";
			// 
			// DateFrom.Properties
			// 
			this.DateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.DateFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.DateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.DateFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
			this.DateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.DateFrom.Properties.Mask.EditMask = "dd/MM/yyyy";
			this.DateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			this.DateFrom.TabIndex = 1;
			// 
			// DateTo
			// 
			this.DateTo.EditValue = null;
			this.DateTo.Location = new System.Drawing.Point(256, 8);
			this.DateTo.Name = "DateTo";
			// 
			// DateTo.Properties
			// 
			this.DateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.DateTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.DateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.DateTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
			this.DateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.DateTo.Properties.Mask.EditMask = "dd/MM/yyyy";
			this.DateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			this.DateTo.TabIndex = 2;
			// 
			// TimeFrom
			// 
			this.TimeFrom.EditValue = new System.DateTime(2006, 8, 23, 0, 0, 0, 0);
			this.TimeFrom.Location = new System.Drawing.Point(456, 8);
			this.TimeFrom.Name = "TimeFrom";
			// 
			// TimeFrom.Properties
			// 
			this.TimeFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											 new DevExpress.XtraEditors.Controls.EditorButton()});
			this.TimeFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			this.TimeFrom.TabIndex = 3;
			// 
			// TimeTo
			// 
			this.TimeTo.EditValue = new System.DateTime(2006, 8, 23, 0, 0, 0, 0);
			this.TimeTo.Location = new System.Drawing.Point(624, 8);
			this.TimeTo.Name = "TimeTo";
			// 
			// TimeTo.Properties
			// 
			this.TimeTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										   new DevExpress.XtraEditors.Controls.EditorButton()});
			this.TimeTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			this.TimeTo.TabIndex = 4;
			// 
			// label63
			// 
			this.label63.BackColor = System.Drawing.Color.Transparent;
			this.label63.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label63.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label63.Location = new System.Drawing.Point(8, 8);
			this.label63.Name = "label63";
			this.label63.Size = new System.Drawing.Size(64, 16);
			this.label63.TabIndex = 37;
			this.label63.Text = "Date From";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(200, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 38;
			this.label1.Text = "Date To";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label2.Location = new System.Drawing.Point(384, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 39;
			this.label2.Text = "Time From";
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label3.Location = new System.Drawing.Point(568, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 16);
			this.label3.TabIndex = 40;
			this.label3.Text = "Time To";
			// 
			// btnReset
			// 
			this.btnReset.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnReset.Appearance.Options.UseFont = true;
			this.btnReset.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnReset.Location = new System.Drawing.Point(792, 8);
			this.btnReset.LookAndFeel.UseDefaultLookAndFeel = false;
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(72, 24);
			this.btnReset.TabIndex = 216;
			this.btnReset.Text = "Generate";
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// PRINT1
			// 
			this.PRINT1.EditValue = "PRINT";
			this.PRINT1.Location = new System.Drawing.Point(880, 16);
			this.PRINT1.Name = "PRINT1";
			// 
			// PRINT1.Properties
			// 
			this.PRINT1.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.PRINT1.Properties.Appearance.Options.UseBackColor = true;
			this.PRINT1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.PRINT1.Size = new System.Drawing.Size(40, 18);
			this.PRINT1.TabIndex = 217;
			this.PRINT1.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.PRINT1_OpenLink);
			// 
			// printingSystem1
			// 
			this.printingSystem1.Links.AddRange(new object[] {
																 this.printableComponentLink1});
			// 
			// printableComponentLink1
			// 
			this.printableComponentLink1.Component = this.gvGymAnalysis;
			this.printableComponentLink1.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(new DevExpress.XtraPrinting.PageHeaderArea(new string[] {
																																									 "GYM ANALYSIS REPORT",
																																									 "",
																																									 "[Date Printed] [Time Printed]"}, new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), DevExpress.XtraPrinting.BrickAlignment.Near), new DevExpress.XtraPrinting.PageFooterArea(new string[] {
																																																																																																																																  "",
																																																																																																																																  "",
																																																																																																																																  "[Page # of Pages #]"}, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134))), DevExpress.XtraPrinting.BrickAlignment.Near));
			this.printableComponentLink1.PrintingSystem = this.printingSystem1;
			// 
			// RPGymAnalysis
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(962, 486);
			this.Controls.Add(this.PRINT1);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label63);
			this.Controls.Add(this.TimeTo);
			this.Controls.Add(this.TimeFrom);
			this.Controls.Add(this.DateTo);
			this.Controls.Add(this.DateFrom);
			this.Controls.Add(this.gvGymAnalysis);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "RPGymAnalysis";
			this.Text = "Gym Analysis";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.RPGymAnalysis_Load);
			((System.ComponentModel.ISupportInitialize)(this.gvGymAnalysis)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DateTo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TimeFrom.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TimeTo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void RPGymAnalysis_Load(object sender, System.EventArgs e)
		{
			isFinishBind = false;
			DateFrom.EditValue = DateTime.Now.Date;//string.Format("{0:dd/MM/yyyy}",Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year));
			DateTo.EditValue = DateTime.Now.Date;
			isFinishBind = true;
			LoadReport();
		}

		private void LoadReport()
		{
			if (!isFinishBind)
				return;
			//up_LeaveReport

			SqlCommand myCmd = new SqlCommand("up_get_gymAnalysis", connection);
			myCmd.CommandType = CommandType.StoredProcedure;
			myCmd.Parameters.Add("@dtDate", string.Format("{0:yyyy-MM-dd}",DateFrom.EditValue)); 
			myCmd.Parameters.Add("@dtEndDate", string.Format("{0:yyyy-MM-dd}",DateTo.EditValue)); 
			myCmd.Parameters.Add("@dtStartTime", string.Format("{0:HH:mm:ss}",TimeFrom.EditValue)); 
			myCmd.Parameters.Add("@dtEndTime", string.Format("{0:HH:mm:ss}",TimeTo.EditValue)); 
	
			SqlDataAdapter adpGym = new SqlDataAdapter(myCmd); 

			//connection.Open(); 

			DataSet _ds = new DataSet("Gym"); 
			adpGym.Fill(_ds, "Gym"); 

			gvGymAnalysis.DataSource = _ds.Tables["Gym"];

		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			LoadReport();
		}

		private void PRINT1_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
		{
			printableComponentLink1.CreateDocument();
			printableComponentLink1.PrintingSystem.Print();
		}
	}
}

