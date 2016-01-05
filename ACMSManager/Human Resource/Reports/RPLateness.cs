using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ACMSLogic;
using ACMS.Utils;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Data.OleDb;
using DevExpress.XtraGrid.Views.Grid;
using ACMS.XtraUtils.LookupEditBuilder;


namespace ACMS.ACMSManager.Reports
{
	/// <summary>
	/// Summary description for RPLateness.
	/// </summary>
	public class RPLateness : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		//private static Do.Employee employee;
		//private static Do.TerminalUser terminalUser; 
		private ACMS.Utils.Common myCommon;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraEditors.SimpleButton sbtnReset;
		private DevExpress.XtraEditors.ImageComboBoxEdit Year;
		private DevExpress.XtraGrid.GridControl gcRPLateness;
		private System.Windows.Forms.Label label7;
		private DevExpress.XtraEditors.SimpleButton btnReset;
		private DevExpress.XtraEditors.LookUpEdit lkEmployee;
		private bool isFinishBind = false;
		private DevExpress.XtraEditors.LookUpEdit lkBranch;
		private DevExpress.XtraEditors.ImageComboBoxEdit dMonth;
		private DevExpress.XtraEditors.ImageComboBoxEdit ToMonth;
		private DevExpress.XtraEditors.ImageComboBoxEdit ToYear;
		private int EmployeeId;
		private int empId;


		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RPLateness(int empId)
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.gcRPLateness = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lkEmployee = new DevExpress.XtraEditors.LookUpEdit();
			this.lkBranch = new DevExpress.XtraEditors.LookUpEdit();
			this.sbtnReset = new DevExpress.XtraEditors.SimpleButton();
			this.dMonth = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.Year = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.ToMonth = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.ToYear = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.label7 = new System.Windows.Forms.Label();
			this.btnReset = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.gcRPLateness)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkEmployee.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkBranch.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dMonth.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Year.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ToMonth.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ToYear.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(120, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Year";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "Month";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(256, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Month";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(368, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "Year";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(8, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 16);
			this.label5.TabIndex = 7;
			this.label5.Text = "Branch";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(136, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 16);
			this.label6.TabIndex = 8;
			this.label6.Text = "Employee";
			// 
			// gcRPLateness
			// 
			this.gcRPLateness.Dock = System.Windows.Forms.DockStyle.Bottom;
			// 
			// gcRPLateness.EmbeddedNavigator
			// 
			this.gcRPLateness.EmbeddedNavigator.Name = "";
			this.gcRPLateness.Location = new System.Drawing.Point(0, 94);
			this.gcRPLateness.MainView = this.gridView1;
			this.gcRPLateness.Name = "gcRPLateness";
			this.gcRPLateness.Size = new System.Drawing.Size(976, 368);
			this.gcRPLateness.TabIndex = 10;
			this.gcRPLateness.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn1,
																							 this.gridColumn2,
																							 this.gridColumn3,
																							 this.gridColumn4,
																							 this.gridColumn5,
																							 this.gridColumn6});
			this.gridView1.GridControl = this.gcRPLateness;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsBehavior.Editable = false;
			this.gridView1.OptionsCustomization.AllowColumnMoving = false;
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsCustomization.AllowSort = false;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Branch";
			this.gridColumn1.FieldName = "strBranchCode";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			this.gridColumn1.Width = 85;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Staff ID";
			this.gridColumn2.FieldName = "nEmployeeID";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			this.gridColumn2.Width = 100;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Name";
			this.gridColumn3.FieldName = "strEmployeeName";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 2;
			this.gridColumn3.Width = 89;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Year";
			this.gridColumn4.FieldName = "dYear";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 3;
			this.gridColumn4.Width = 107;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "Month";
			this.gridColumn5.FieldName = "MonDesc";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 4;
			this.gridColumn5.Width = 90;
			// 
			// gridColumn6
			// 
			this.gridColumn6.Caption = "Total Lateness (Minute)";
			this.gridColumn6.FieldName = "lateness";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 5;
			this.gridColumn6.Width = 93;
			// 
			// lkEmployee
			// 
			this.lkEmployee.Location = new System.Drawing.Point(208, 24);
			this.lkEmployee.Name = "lkEmployee";
			// 
			// lkEmployee.Properties
			// 
			this.lkEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkEmployee.Size = new System.Drawing.Size(80, 20);
			this.lkEmployee.TabIndex = 11;
			// 
			// lkBranch
			// 
			this.lkBranch.Location = new System.Drawing.Point(64, 24);
			this.lkBranch.Name = "lkBranch";
			// 
			// lkBranch.Properties
			// 
			this.lkBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkBranch.Size = new System.Drawing.Size(72, 20);
			this.lkBranch.TabIndex = 12;
			// 
			// sbtnReset
			// 
			this.sbtnReset.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sbtnReset.Appearance.Options.UseFont = true;
			this.sbtnReset.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnReset.Location = new System.Drawing.Point(296, 24);
			this.sbtnReset.LookAndFeel.UseDefaultLookAndFeel = false;
			this.sbtnReset.Name = "sbtnReset";
			this.sbtnReset.Size = new System.Drawing.Size(48, 16);
			this.sbtnReset.TabIndex = 177;
			this.sbtnReset.Text = "Enquiry";
			this.sbtnReset.Click += new System.EventHandler(this.sbtnReset_Click);
			// 
			// dMonth
			// 
			this.dMonth.EditValue = 1;
			this.dMonth.Location = new System.Drawing.Point(56, 0);
			this.dMonth.Name = "dMonth";
			// 
			// dMonth.Properties
			// 
			this.dMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dMonth.Properties.Items.AddRange(new object[] {
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("January", 1, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("February", 2, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("March", 3, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("April", 4, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("May", 5, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("June", 6, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("July", 7, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("August", 8, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("September", 9, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("October", 10, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("November", 11, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("December", 12, -1)});
			this.dMonth.Size = new System.Drawing.Size(64, 20);
			this.dMonth.TabIndex = 178;
			// 
			// Year
			// 
			this.Year.Location = new System.Drawing.Point(160, 0);
			this.Year.Name = "Year";
			// 
			// Year.Properties
			// 
			this.Year.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.Year.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.Year.Size = new System.Drawing.Size(72, 22);
			this.Year.TabIndex = 179;
			// 
			// ToMonth
			// 
			this.ToMonth.EditValue = 1;
			this.ToMonth.Location = new System.Drawing.Point(304, 0);
			this.ToMonth.Name = "ToMonth";
			// 
			// ToMonth.Properties
			// 
			this.ToMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.ToMonth.Properties.Items.AddRange(new object[] {
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("January", 1, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("February", 2, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("March", 3, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("April", 4, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("May", 5, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("June", 6, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("July", 7, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("August", 8, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("September", 9, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("October", 10, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("November", 11, -1),
																	new DevExpress.XtraEditors.Controls.ImageComboBoxItem("December", 12, -1)});
			this.ToMonth.Size = new System.Drawing.Size(64, 20);
			this.ToMonth.TabIndex = 180;
			// 
			// ToYear
			// 
			this.ToYear.Location = new System.Drawing.Point(408, 0);
			this.ToYear.Name = "ToYear";
			// 
			// ToYear.Properties
			// 
			this.ToYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.ToYear.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.ToYear.Size = new System.Drawing.Size(72, 22);
			this.ToYear.TabIndex = 181;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.Location = new System.Drawing.Point(232, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(24, 16);
			this.label7.TabIndex = 182;
			this.label7.Text = "To";
			// 
			// btnReset
			// 
			this.btnReset.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnReset.Appearance.Options.UseFont = true;
			this.btnReset.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnReset.Location = new System.Drawing.Point(352, 24);
			this.btnReset.LookAndFeel.UseDefaultLookAndFeel = false;
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(48, 16);
			this.btnReset.TabIndex = 183;
			this.btnReset.Text = "Reset";
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// RPLateness
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(976, 462);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.ToYear);
			this.Controls.Add(this.ToMonth);
			this.Controls.Add(this.Year);
			this.Controls.Add(this.dMonth);
			this.Controls.Add(this.sbtnReset);
			this.Controls.Add(this.lkBranch);
			this.Controls.Add(this.lkEmployee);
			this.Controls.Add(this.gcRPLateness);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "RPLateness";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Lateness";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.RPLateness_Load);
			((System.ComponentModel.ISupportInitialize)(this.gcRPLateness)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkEmployee.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkBranch.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dMonth.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Year.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ToMonth.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ToYear.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void RPLateness_Load(object sender, System.EventArgs e)
		{

			isFinishBind = false;
			ToMonth.SelectedIndex = 11;
			BindInit();
			isFinishBind = true;
			LoadLateness();
		}

		private void sbtnReset_Click(object sender, System.EventArgs e)
		{
			LoadLateness();
		}

		private void LoadLateness()
		{
			if (!isFinishBind)
			return;

			SqlCommand myCmd = new SqlCommand("up_LatenessReport", connection);
			myCmd.CommandType = CommandType.StoredProcedure;
			myCmd.Parameters.Add("@YearNo", Year.EditValue); 
			myCmd.Parameters.Add("@YearNo2", ToYear.EditValue); 
			myCmd.Parameters.Add("@Month", dMonth.EditValue); 
			myCmd.Parameters.Add("@Month2", ToMonth.EditValue); 
; 
			if (lkEmployee.EditValue != null && lkEmployee.EditValue.ToString() != "")
				myCmd.Parameters.Add("@nEmployeeID", lkEmployee.EditValue); 

			if (lkBranch.EditValue != null && lkBranch.EditValue.ToString() != "")
				myCmd.Parameters.Add("@strBranchCode", lkBranch.EditValue); 

			SqlDataAdapter adpLeave = new SqlDataAdapter(myCmd); 

			//connection.Open(); 

			DataSet _ds = new DataSet("lateness"); 
			adpLeave.Fill(_ds, "lateness"); 

			this.gcRPLateness.DataSource = _ds.Tables["lateness"];

		}

		private void BindInit()
		{
			myCommon = new ACMS.Utils.Common();
			DataTable dt; 

			dt = myCommon.ExecuteQuery("Select strBranchCode,strBranchName from tblBranch Where strBranchCode In (Select strBranchCode from tblemployeebranchrights Where nEmployeeId = " + EmployeeId + ")");
			new ManagerBranchCodeLookupEditBuilder(dt, this.lkBranch.Properties);

			dt = myCommon.ExecuteQuery("Select nEmployeeID, strEmployeeName from tblEmployee");
			new ManagerEmployeeIDLookupEditBuilder(dt, this.lkEmployee.Properties);

				string strSQL = "Select distinct datepart(year,dtDate) as nYearID from tblTimeCard order by datepart(year,dtDate) desc";

			comboBind(Year, strSQL, "nYearID", "nYearID", true);
			Year.SelectedIndex = 0;

			comboBind(ToYear, strSQL, "nYearID", "nYearID", true);
			ToYear.SelectedIndex = 0;
			
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


		private void btnReset_Click(object sender, System.EventArgs e)
		{
			dMonth.SelectedIndex = 0;
			Year.SelectedIndex = 0;
			ToMonth.SelectedIndex = 11;
			ToYear.SelectedIndex = 0;
			lkBranch.EditValue = null;
			lkEmployee.EditValue = null;
			LoadLateness();
		}

	
	}
}





