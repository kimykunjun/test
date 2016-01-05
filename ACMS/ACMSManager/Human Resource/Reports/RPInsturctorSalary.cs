using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using DevExpress.XtraPivotGrid;
using Do = Acms.Core.Domain;
using ACMSLogic;

namespace ACMS.ACMSManager.Reports
{
	/// <summary>
	/// Summary description for RPInsturctorSalary.
	/// </summary>
	public class RPInsturctorSalary : System.Windows.Forms.Form
	{
		//private Do.Employee employee;
		//private Do.TerminalUser terminalUser; 
		//User oUser;

		private string connectionString;
        private SqlConnection connection;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbMonth;
		private System.Windows.Forms.ComboBox cmbYear;
        private DevExpress.XtraEditors.ImageComboBoxEdit cmbInstructor;
        private Label label3;
        private DevExpress.XtraEditors.ImageComboBoxEdit cmbBranch;
        private Label label4;
        private bool isFinishBindInit;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RPInsturctorSalary()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//EmployeeID = empID;
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
            BindBranch();
            isFinishBindInit = true;
            LoadInstructor();
            cmbInstructor.SelectedIndex = 1;

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
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.cmbInstructor = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBranch = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInstructor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Year";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(199, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Month";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbMonth
            // 
            this.cmbMonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbMonth.Location = new System.Drawing.Point(257, 18);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(88, 21);
            this.cmbMonth.TabIndex = 3;
            this.cmbMonth.Text = "1";
            this.cmbMonth.SelectedValueChanged += new System.EventHandler(this.cmbMonth_SelectedValueChanged);
            // 
            // cmbYear
            // 
            this.cmbYear.Items.AddRange(new object[] {
            //"2000",
            //"2001",
            //"2002",
            //"2003",
            //"2004",
            //"2005",
            //"2006",
            //"2007",
            //"2008",
            //"2009",
            "2010",
            "2011",
            "2012",
            "2013"});
            this.cmbYear.Location = new System.Drawing.Point(56, 16);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(121, 21);
            this.cmbYear.TabIndex = 4;
            this.cmbYear.Text = "2012";
            this.cmbYear.SelectedValueChanged += new System.EventHandler(this.cmbYear_SelectedValueChanged);
            // 
            // cmbInstructor
            // 
            this.cmbInstructor.Location = new System.Drawing.Point(458, 19);
            this.cmbInstructor.Name = "cmbInstructor";
            this.cmbInstructor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbInstructor.Size = new System.Drawing.Size(160, 20);
            this.cmbInstructor.TabIndex = 54;
            this.cmbInstructor.SelectedValueChanged += new System.EventHandler(this.cmbInstructor_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(364, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 53;
            this.label3.Text = "Instructor";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbBranch
            // 
            this.cmbBranch.Location = new System.Drawing.Point(688, 16);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBranch.Size = new System.Drawing.Size(165, 20);
            this.cmbBranch.TabIndex = 55;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(624, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 40);
            this.label4.TabIndex = 56;
            this.label4.Text = "Branch";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.FormsUseDefaultLookAndFeel = false;
            this.gridControl1.Location = new System.Drawing.Point(11, 45);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1000, 512);
            this.gridControl1.TabIndex = 57;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "No.";
            this.gridColumn1.FieldName = "No";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Date";
            this.gridColumn2.FieldName = "dtdate";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Branch";
            this.gridColumn3.FieldName = "strBranchCode";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Start Time";
            this.gridColumn4.DisplayFormat.FormatString = "T";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "dtStartTime";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "End Time";
            this.gridColumn5.DisplayFormat.FormatString = "t";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn5.FieldName = "dtEndTime";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Class Code";
            this.gridColumn6.FieldName = "strClassCode";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Attendees";
            this.gridColumn7.FieldName = "Attendance";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Login Time";
            this.gridColumn8.DisplayFormat.FormatString = "t";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn8.FieldName = "dtInstructorLogin";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Fees";
            this.gridColumn9.FieldName = "mInstructorFees";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(881, 16);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 58;
            this.simpleButton1.Text = "Print";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // RPInsturctorSalary
            // 
            this.ClientSize = new System.Drawing.Size(968, 558);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.cmbBranch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbInstructor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RPInsturctorSalary";
            this.Text = "Instructor Salary Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RPInsturctorSalary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbInstructor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void RPInsturctorSalary_Load(object sender, System.EventArgs e)
		{
			
		}
        private void BindBranch()
        {
            isFinishBindInit = false;

            string strSQL = "Select strBranchCode,strBranchName from TblBranch where nBrStatusID = 1";

            comboBind(cmbBranch, strSQL, "strBranchName", "strBranchCode", true);
            cmbBranch.Properties.Items.Insert(0, new DevExpress.XtraEditors.Controls.ImageComboBoxItem("- Please Select -", ""));
            //cmbBranch.SelectedIndex = 0;
            isFinishBindInit = true;

        }

        private void LoadInstructor()
        {
            string strSQL = "Select nEmployeeID, strEmployeeName from TblEmployee Where fInstructor = 1 and nStatusID=1 order by strEmployeeName";

            comboBind(cmbInstructor, strSQL, "strEmployeeName", "nEmployeeID", true);
            //cmbInstructor.Properties.Items.Insert(0, new DevExpress.XtraEditors.Controls.ImageComboBoxItem("- Please Select -", ""));
            cmbInstructor.SelectedIndex = 1;
        }
        private void comboBind(DevExpress.XtraEditors.ImageComboBoxEdit control, string strSQL, string display, string strValue, bool fNum)
        {

            DataSet _ds = new DataSet();
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "Table" }, new SqlParameter("@strSQL", strSQL));
            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox properties = control.Properties;
            properties.Items.BeginUpdate();
            properties.Items.Clear();

            try
            {
                foreach (DataRow dr in _ds.Tables["Table"].Rows)
                {
                    //Initialize each item with the display text, value and image index
                    properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr[display].ToString(), dr[strValue], -1));
                }
            }
            finally
            {
                properties.Items.EndUpdate();
            }
            //Select the first item
            control.SelectedIndex = 0;
        }
		private void BindReport()
		{
			string strSQL;
			DataSet _ds;
					
			// first previous two month sales
            strSQL = "Select CI.dtdate,CI.strBranchCode,CI.dtStartTime,CI.dtEndTime,CI.strClassCode,count(nAttendanceID) as Attendance,CI.dtInstructorLogin,CI.mInstructorFees";
            strSQL = strSQL + " from tblClassInstance CI left join tblClassAttendance CA on CI.nCLassInstanceID = CA.nCLassInstanceID";
            strSQL = strSQL + " where month(CI.dtDate) =" + cmbMonth.SelectedItem + " and year(CI.dtDate) =" + cmbYear.SelectedItem;
            strSQL = strSQL + " and (CA.nStatusID = 1 or CA.nStatusID = 4) and CI.nActualInstructorID =" + cmbInstructor.EditValue.ToString();
            strSQL = strSQL + " group by CI.dtDate,CI.strBranchCode,CI.dtStartTime,CI.dtEndTime,CI.strClassCode,CI.dtInstructorLogin,CI.mInstructorFees";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
            dt.Columns.Add("No", Type.GetType("System.Int32"));
            int i = 0;
            foreach (DataRow dr1 in dt.Rows)
            {
                i++;
                dr1["No"] = i;
            }

			DataView dv = new DataView(dt);
            gridControl1.DataSource = dv;

			//pivotGridControl1.DataSource = dv;
		}

        private void cmbInstructor_SelectedValueChanged(object sender, EventArgs e)
        {
            BindReport();
        }

        private void cmbYear_SelectedValueChanged(object sender, EventArgs e)
        {
            BindReport();
        }

        private void cmbMonth_SelectedValueChanged(object sender, EventArgs e)
        {
            BindReport();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridControl1.Print();
        }
	}
}
