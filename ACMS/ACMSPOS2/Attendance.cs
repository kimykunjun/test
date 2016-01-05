using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data;
using Acms.Core;


namespace ACMS.ACMSPOS2
{
	/// <summary>
	/// Summary description for Attendance.
	/// </summary>
	public class Attendance : DevExpress.XtraEditors.XtraForm
	{
		private DevExpress.XtraScheduler.UI.MonthEdit monthEdit1;
		private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
		private DevExpress.XtraGrid.GridControl gridCalendar;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewCalendar;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private System.Windows.Forms.Label lblMonth;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk_Select;
		private DevExpress.XtraEditors.SimpleButton btn_Save;
		private System.Windows.Forms.Label lblDay;
		private DevExpress.XtraEditors.ComboBoxEdit cmbDay;
		private System.ComponentModel.IContainer components;

		public Attendance()
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
			this.components = new System.ComponentModel.Container();
			this.monthEdit1 = new DevExpress.XtraScheduler.UI.MonthEdit();
			this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
			this.gridCalendar = new DevExpress.XtraGrid.GridControl();
			this.gridViewCalendar = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.chk_Select = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lblMonth = new System.Windows.Forms.Label();
			this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
			this.lblDay = new System.Windows.Forms.Label();
			this.cmbDay = new DevExpress.XtraEditors.ComboBoxEdit();
			((System.ComponentModel.ISupportInitialize)(this.monthEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridCalendar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewCalendar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_Select)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbDay.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// monthEdit1
			// 
			this.monthEdit1.Location = new System.Drawing.Point(80, 48);
			this.monthEdit1.Name = "monthEdit1";
			// 
			// monthEdit1.Properties
			// 
			this.monthEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.monthEdit1.TabIndex = 0;
			// 
			// gridCalendar
			// 
			this.gridCalendar.Anchor = System.Windows.Forms.AnchorStyles.Left;
			// 
			// gridCalendar.EmbeddedNavigator
			// 
			this.gridCalendar.EmbeddedNavigator.Name = "";
			this.gridCalendar.Location = new System.Drawing.Point(0, 88);
			this.gridCalendar.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.gridCalendar.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridCalendar.MainView = this.gridViewCalendar;
			this.gridCalendar.Name = "gridCalendar";
			this.gridCalendar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												  this.chk_Select});
			this.gridCalendar.Size = new System.Drawing.Size(496, 176);
			this.gridCalendar.TabIndex = 180;
			this.gridCalendar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridViewCalendar});
			// 
			// gridViewCalendar
			// 
			this.gridViewCalendar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									this.gridColumn2,
																									this.gridColumn3,
																									this.gridColumn4});
			this.gridViewCalendar.GridControl = this.gridCalendar;
			this.gridViewCalendar.Name = "gridViewCalendar";
			this.gridViewCalendar.OptionsBehavior.Editable = false;
			this.gridViewCalendar.OptionsCustomization.AllowFilter = false;
			this.gridViewCalendar.OptionsCustomization.AllowSort = false;
			this.gridViewCalendar.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Date";
			this.gridColumn2.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.gridColumn2.FieldName = "dtDate";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 0;
			this.gridColumn2.Width = 147;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Select";
			this.gridColumn3.ColumnEdit = this.chk_Select;
			this.gridColumn3.DisplayFormat.FormatString = "hh:mm tt";
			this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.gridColumn3.FieldName = "chkSelect";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 1;
			this.gridColumn3.Width = 59;
			// 
			// chk_Select
			// 
			this.chk_Select.AutoHeight = false;
			this.chk_Select.Name = "chk_Select";
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Remarks";
			this.gridColumn4.FieldName = "strRemarks";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 2;
			this.gridColumn4.Width = 276;
			// 
			// lblMonth
			// 
			this.lblMonth.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMonth.Location = new System.Drawing.Point(0, 48);
			this.lblMonth.Name = "lblMonth";
			this.lblMonth.Size = new System.Drawing.Size(80, 23);
			this.lblMonth.TabIndex = 181;
			this.lblMonth.Text = "Month";
			// 
			// btn_Save
			// 
			this.btn_Save.Location = new System.Drawing.Point(392, 280);
			this.btn_Save.Name = "btn_Save";
			this.btn_Save.TabIndex = 182;
			this.btn_Save.Text = "Save";
			// 
			// lblDay
			// 
			this.lblDay.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDay.Location = new System.Drawing.Point(0, 16);
			this.lblDay.Name = "lblDay";
			this.lblDay.Size = new System.Drawing.Size(56, 23);
			this.lblDay.TabIndex = 184;
			this.lblDay.Text = "Day";
			// 
			// cmbDay
			// 
			this.cmbDay.EditValue = "";
			this.cmbDay.Location = new System.Drawing.Point(80, 16);
			this.cmbDay.Name = "cmbDay";
			// 
			// cmbDay.Properties
			// 
			this.cmbDay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbDay.Properties.Items.AddRange(new object[] {
																   "Monday",
																   "Tuesday",
																   "Wednesday",
																   "Thursday",
																   "Friday",
																   "Saturday",
																   "Sunday"});
			this.cmbDay.TabIndex = 185;
			// 
			// Attendance
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(576, 350);
			this.Controls.Add(this.cmbDay);
			this.Controls.Add(this.lblDay);
			this.Controls.Add(this.btn_Save);
			this.Controls.Add(this.lblMonth);
			this.Controls.Add(this.gridCalendar);
			this.Controls.Add(this.monthEdit1);
			this.Name = "Attendance";
			this.Text = "Attendance Calendar";
			this.Load += new System.EventHandler(this.Attendance_Load);
			((System.ComponentModel.ISupportInitialize)(this.monthEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridCalendar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewCalendar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chk_Select)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbDay.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void Attendance_Load(object sender, System.EventArgs e)
		{
		load_Calendar();
			cmbDay.Properties.Items.Add("Monday");
			cmbDay.Properties.Items.Add("Tuesday");
			cmbDay.Properties.Items.Add("Wednesday");
			cmbDay.Properties.Items.Add("Thursday");
			cmbDay.Properties.Items.Add("Friday");
			cmbDay.Properties.Items.Add("Saturday");
			cmbDay.Properties.Items.Add("Sunday");
			cmbDay.SelectedIndex=0;
		}

		private void load_Calendar()
		{
			DataSet Attend = new DataSet();
			DataTable ds = Attend.Tables.Add("AttendTable");

			DataColumn column;
			DataRow row;
 
			// Create new DataColumn, set DataType, 
			// ColumnName and add to DataTable.    
			column = new DataColumn();
			column.DataType = System.Type.GetType("System.DateTime");
			column.ColumnName = "dtDate";
			//column.ReadOnly = true;
			column.Unique = true;
			// Add the Column to the DataColumnCollection.
			ds.Columns.Add(column);

			column = new DataColumn();
			column.DataType = System.Type.GetType("System.Boolean");
			column.ColumnName = "chkSelect";
			//column.ReadOnly = true;
			// Add the Column to the DataColumnCollection.
			ds.Columns.Add(column);

		
			column = new DataColumn();
			column.DataType = System.Type.GetType("System.String");
			column.ColumnName = "strRemarks";
			//column.AutoIncrement = false;
			//column.ReadOnly = false;
			//column.Unique = false;
			// Add the column to the table.
			ds.Columns.Add(column);

//			ds.Columns.Add("dtDate");
//			ds.Columns.Add("chkSelect");
//			ds.Columns.Add("strRemarks");
//			
			gridCalendar.DataSource=ds;

			DateTime dtdateFrom,dtdateTo;
			monthEdit1.EditValue=DateTime.Today.Month;


			dtdateFrom=new DateTime(2006,ACMS.Convert.ToDBInt32(monthEdit1.EditValue),1,0,0,0,1);
			dtdateTo=dtdateFrom.AddMonths(1);

			for (DateTime dtdateCount= dtdateFrom; dtdateCount< dtdateTo; dtdateCount.AddDays(1))
			{
				//cmbDay.EditValue.ToString()
				if  (dtdateCount.DayOfWeek.ToString()=="Monday")
				{
					row = ds.NewRow();
					row["dtDate"] = dtdateCount;
					row["chkSelect"] = 1;
					ds.Rows.Add(row);
				}
					dtdateCount=dtdateCount.AddDays(1);
			}
		}

		
			
			//gridViewCalendar.AddNewRow();


			///TblClassAttendance classAttendance = new TblClassAttendance();

//			classAttendance.MainConnectionProvider = connProvider;
			
			
//			DataTable attendedClassTable = classAttendance.GetAllClassAttendancesBasePackageID(wantToUpgrade_nPackageID, pos.StrMembershipID, pos.StrBranchCode);
					

		}

//		private void MakeParentTable()
//		{
//			// Create a new DataTable.
//			System.Data.DataTable table = new DataTable("ParentTable");
//			// Declare variables for DataColumn and DataRow objects.
//			DataColumn column;
//			DataRow row;
// 
//			// Create new DataColumn, set DataType, 
//			// ColumnName and add to DataTable.    
//			column = new DataColumn();
//			column.DataType = System.Type.GetType("System.Int32");
//			column.ColumnName = "id";
//			column.ReadOnly = true;
//			column.Unique = true;
//			// Add the Column to the DataColumnCollection.
//			table.Columns.Add(column);
// 
//			// Create second column.
//			column = new DataColumn();
//			column.DataType = System.Type.GetType("System.String");
//			column.ColumnName = "ParentItem";
//			column.AutoIncrement = false;
//			column.Caption = "ParentItem";
//			column.ReadOnly = false;
//			column.Unique = false;
//			// Add the column to the table.
//			table.Columns.Add(column);
// 
//			// Make the ID column the primary key column.
//			DataColumn[] PrimaryKeyColumns = new DataColumn[1];
//			PrimaryKeyColumns[0] = table.Columns["id"];
//			table.PrimaryKey = PrimaryKeyColumns;
// 
//			// Instantiate the DataSet variable.
//			dataSet = new DataSet();
//			// Add the new DataTable to the DataSet.
//			dataSet.Tables.Add(table);
// 
//			// Create three new DataRow objects and add 
//			// them to the DataTable
//			for (int i = 0; i<= 2; i++)
//			{
//				row = table.NewRow();
//				row["id"] = i;
//				row["ParentItem"] = "ParentItem " + i;
//				table.Rows.Add(row);
//			}
//		}

	}

