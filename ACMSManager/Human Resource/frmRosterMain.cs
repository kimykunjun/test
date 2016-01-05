using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using Do = Acms.Core.Domain;
using ACMSLogic;

namespace ACMS.ACMSManager.Human_Resource
{
	/// <summary>
	/// Summary description for frmRosterMain.
	/// </summary>
	public class frmRosterMain : System.Windows.Forms.Form
	{
		public static string RosterBranch;
		private static Do.Employee employee;
		private static Do.TerminalUser terminalUser; 
		private static User oUser;
		//roster
		private int Week_Day;
		private string currentDay;
		public int WeekNo;
		private string _target;
		private string connectionString;
		private SqlConnection connection;
		private ACMS.Control.ACMSRosterHeader acmsRosterHeader1;
		private DevExpress.XtraEditors.GroupControl groupRoster;
		private DevExpress.XtraEditors.ImageComboBoxEdit comboBoxRoster;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		internal DevExpress.XtraEditors.SimpleButton btnNextWeek;
		internal DevExpress.XtraEditors.SimpleButton btnPastWeek;
		internal DevExpress.XtraEditors.SimpleButton btnPrint;
		internal DevExpress.XtraEditors.SimpleButton btnNew;
		private DevExpress.XtraEditors.GroupControl groupControl35;
		private System.Windows.Forms.Label label71;
		private System.Windows.Forms.Label label72;
		private System.Windows.Forms.Label label73;
		private System.Windows.Forms.Label label74;
		private System.Windows.Forms.Label label75;
		private System.Windows.Forms.Label label76;
		private System.Windows.Forms.Label label77;
		private System.Windows.Forms.Label label78;
		private DevExpress.XtraEditors.ImageComboBoxEdit comboBoxRosterCC;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.ImageComboBoxEdit cbYear;
		private System.Windows.Forms.Label label3;
        private Roster myRoster;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmRosterMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
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
			this.groupRoster = new DevExpress.XtraEditors.GroupControl();
			this.label3 = new System.Windows.Forms.Label();
			this.cbYear = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.comboBoxRosterCC = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.btnNew = new DevExpress.XtraEditors.SimpleButton();
			this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBoxRoster = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.groupControl35 = new DevExpress.XtraEditors.GroupControl();
			this.label71 = new System.Windows.Forms.Label();
			this.label72 = new System.Windows.Forms.Label();
			this.label73 = new System.Windows.Forms.Label();
			this.label74 = new System.Windows.Forms.Label();
			this.label75 = new System.Windows.Forms.Label();
			this.label76 = new System.Windows.Forms.Label();
			this.label77 = new System.Windows.Forms.Label();
			this.label78 = new System.Windows.Forms.Label();
			this.btnNextWeek = new DevExpress.XtraEditors.SimpleButton();
			this.btnPastWeek = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.groupRoster)).BeginInit();
			this.groupRoster.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cbYear.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxRosterCC.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxRoster.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl35)).BeginInit();
			this.groupControl35.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupRoster
			// 
			this.groupRoster.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.groupRoster.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.groupRoster.Appearance.Options.UseBackColor = true;
			this.groupRoster.Controls.Add(this.label3);
			this.groupRoster.Controls.Add(this.cbYear);
			this.groupRoster.Controls.Add(this.comboBoxRosterCC);
			this.groupRoster.Controls.Add(this.btnNew);
			this.groupRoster.Controls.Add(this.btnPrint);
			this.groupRoster.Controls.Add(this.label2);
			this.groupRoster.Controls.Add(this.comboBoxRoster);
			this.groupRoster.Controls.Add(this.label1);
			this.groupRoster.Controls.Add(this.groupControl1);
			this.groupRoster.Location = new System.Drawing.Point(8, 0);
			this.groupRoster.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.groupRoster.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupRoster.LookAndFeel.UseWindowsXPTheme = false;
			this.groupRoster.Name = "groupRoster";
			this.groupRoster.Size = new System.Drawing.Size(984, 570);
			this.groupRoster.TabIndex = 28;
			this.groupRoster.Text = "Roster";
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(800, 26);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 16);
			this.label3.TabIndex = 24;
			this.label3.Text = "Year";
			// 
			// cbYear
			// 
			this.cbYear.EditValue = 2008;
			this.cbYear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.cbYear.Location = new System.Drawing.Point(848, 24);
			this.cbYear.Name = "cbYear";
			// 
			// cbYear.Properties
			// 
			this.cbYear.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
			this.cbYear.Properties.Appearance.Options.UseBackColor = true;
			this.cbYear.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.cbYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cbYear.Properties.Items.AddRange(new object[] {
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2007", 2007, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2008", 2008, -1),
																   new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2009", 2009, -1)});
			this.cbYear.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.cbYear.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.cbYear.Size = new System.Drawing.Size(128, 22);
			this.cbYear.TabIndex = 23;
			// 
			// comboBoxRosterCC
			// 
			this.comboBoxRosterCC.EditValue = 0;
			this.comboBoxRosterCC.Location = new System.Drawing.Point(304, 32);
			this.comboBoxRosterCC.Name = "comboBoxRosterCC";
			// 
			// comboBoxRosterCC.Properties
			// 
			this.comboBoxRosterCC.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
			this.comboBoxRosterCC.Properties.Appearance.Options.UseBackColor = true;
			this.comboBoxRosterCC.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.comboBoxRosterCC.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxRosterCC.Properties.Items.AddRange(new object[] {
																			 new DevExpress.XtraEditors.Controls.ImageComboBoxItem("-- Select All --", 0, -1)});
			this.comboBoxRosterCC.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.comboBoxRosterCC.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.comboBoxRosterCC.Size = new System.Drawing.Size(128, 22);
			this.comboBoxRosterCC.TabIndex = 20;
			this.comboBoxRosterCC.SelectedValueChanged += new System.EventHandler(this.comboBoxRosterCC_SelectedValueChanged);
			// 
			// btnNew
			// 
			this.btnNew.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.btnNew.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnNew.Appearance.Options.UseBackColor = true;
			this.btnNew.Appearance.Options.UseFont = true;
			this.btnNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnNew.Location = new System.Drawing.Point(576, 32);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(80, 20);
			this.btnNew.TabIndex = 19;
			this.btnNew.Text = "New";
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// btnPrint
			// 
			this.btnPrint.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.btnPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnPrint.Appearance.Options.UseBackColor = true;
			this.btnPrint.Appearance.Options.UseFont = true;
			this.btnPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnPrint.Location = new System.Drawing.Point(488, 32);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(80, 20);
			this.btnPrint.TabIndex = 11;
			this.btnPrint.Text = "Print";
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(224, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 22;
			this.label2.Text = "Cost Center";
			// 
			// comboBoxRoster
			// 
			this.comboBoxRoster.EditValue = "imageComboBoxEdit3";
			this.comboBoxRoster.Location = new System.Drawing.Point(80, 32);
			this.comboBoxRoster.Name = "comboBoxRoster";
			// 
			// comboBoxRoster.Properties
			// 
			this.comboBoxRoster.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
			this.comboBoxRoster.Properties.Appearance.Options.UseBackColor = true;
			this.comboBoxRoster.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.comboBoxRoster.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxRoster.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.comboBoxRoster.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.comboBoxRoster.Size = new System.Drawing.Size(128, 22);
			this.comboBoxRoster.TabIndex = 19;
			this.comboBoxRoster.SelectedIndexChanged += new System.EventHandler(this.comboBoxRoster_SelectedValueChanged);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(24, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 21;
			this.label1.Text = "Branch";
			// 
			// groupControl1
			// 
			this.groupControl1.Controls.Add(this.groupControl35);
			this.groupControl1.Controls.Add(this.btnNextWeek);
			this.groupControl1.Controls.Add(this.btnPastWeek);
			this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupControl1.Location = new System.Drawing.Point(2, 56);
			this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(980, 512);
			this.groupControl1.TabIndex = 12;
			// 
			// groupControl35
			// 
			this.groupControl35.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.groupControl35.Appearance.ForeColor = System.Drawing.Color.Black;
			this.groupControl35.Appearance.Options.UseBackColor = true;
			this.groupControl35.Appearance.Options.UseForeColor = true;
			this.groupControl35.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupControl35.AppearanceCaption.Options.UseFont = true;
			this.groupControl35.Controls.Add(this.label71);
			this.groupControl35.Controls.Add(this.label72);
			this.groupControl35.Controls.Add(this.label73);
			this.groupControl35.Controls.Add(this.label74);
			this.groupControl35.Controls.Add(this.label75);
			this.groupControl35.Controls.Add(this.label76);
			this.groupControl35.Controls.Add(this.label77);
			this.groupControl35.Controls.Add(this.label78);
			this.groupControl35.Location = new System.Drawing.Point(824, 24);
			this.groupControl35.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupControl35.Name = "groupControl35";
			this.groupControl35.Size = new System.Drawing.Size(144, 168);
			this.groupControl35.TabIndex = 32;
			this.groupControl35.Text = "Legend";
			// 
			// label71
			// 
			this.label71.Location = new System.Drawing.Point(42, 120);
			this.label71.Name = "label71";
			this.label71.Size = new System.Drawing.Size(86, 16);
			this.label71.TabIndex = 7;
			this.label71.Text = "Time off";
			// 
			// label72
			// 
			this.label72.BackColor = System.Drawing.Color.Green;
			this.label72.Location = new System.Drawing.Point(10, 120);
			this.label72.Name = "label72";
			this.label72.Size = new System.Drawing.Size(26, 23);
			this.label72.TabIndex = 6;
			// 
			// label73
			// 
			this.label73.Location = new System.Drawing.Point(42, 93);
			this.label73.Name = "label73";
			this.label73.Size = new System.Drawing.Size(86, 16);
			this.label73.TabIndex = 5;
			this.label73.Text = "Full day leave";
			// 
			// label74
			// 
			this.label74.BackColor = System.Drawing.Color.LightBlue;
			this.label74.Location = new System.Drawing.Point(10, 89);
			this.label74.Name = "label74";
			this.label74.Size = new System.Drawing.Size(26, 23);
			this.label74.TabIndex = 4;
			// 
			// label75
			// 
			this.label75.Location = new System.Drawing.Point(42, 64);
			this.label75.Name = "label75";
			this.label75.Size = new System.Drawing.Size(86, 16);
			this.label75.TabIndex = 3;
			this.label75.Text = "Half day leave";
			// 
			// label76
			// 
			this.label76.BackColor = System.Drawing.Color.Yellow;
			this.label76.Location = new System.Drawing.Point(10, 56);
			this.label76.Name = "label76";
			this.label76.Size = new System.Drawing.Size(26, 23);
			this.label76.TabIndex = 2;
			// 
			// label77
			// 
			this.label77.Location = new System.Drawing.Point(40, 24);
			this.label77.Name = "label77";
			this.label77.Size = new System.Drawing.Size(94, 28);
			this.label77.TabIndex = 1;
			this.label77.Text = "Applied leave in pending status";
			// 
			// label78
			// 
			this.label78.BackColor = System.Drawing.Color.Red;
			this.label78.Location = new System.Drawing.Point(10, 22);
			this.label78.Name = "label78";
			this.label78.Size = new System.Drawing.Size(26, 23);
			this.label78.TabIndex = 0;
			// 
			// btnNextWeek
			// 
			this.btnNextWeek.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.btnNextWeek.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnNextWeek.Appearance.Options.UseBackColor = true;
			this.btnNextWeek.Appearance.Options.UseFont = true;
			this.btnNextWeek.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnNextWeek.Location = new System.Drawing.Point(712, 24);
			this.btnNextWeek.Name = "btnNextWeek";
			this.btnNextWeek.Size = new System.Drawing.Size(80, 20);
			this.btnNextWeek.TabIndex = 20;
			this.btnNextWeek.Text = "Next >>";
			this.btnNextWeek.Click += new System.EventHandler(this.btnNextWeek_Click);
			// 
			// btnPastWeek
			// 
			this.btnPastWeek.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.btnPastWeek.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnPastWeek.Appearance.Options.UseBackColor = true;
			this.btnPastWeek.Appearance.Options.UseFont = true;
			this.btnPastWeek.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnPastWeek.Location = new System.Drawing.Point(8, 24);
			this.btnPastWeek.Name = "btnPastWeek";
			this.btnPastWeek.Size = new System.Drawing.Size(80, 20);
			this.btnPastWeek.TabIndex = 19;
			this.btnPastWeek.Text = "<< Previous";
			this.btnPastWeek.Click += new System.EventHandler(this.btnPastWeek_Click);
			// 
			// frmRosterMain
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1000, 570);
			this.Controls.Add(this.groupRoster);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmRosterMain";
			this.Text = "frmRosterMain";
			this.Load += new System.EventHandler(this.frmRosterMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.groupRoster)).EndInit();
			this.groupRoster.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cbYear.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxRosterCC.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxRoster.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl35)).EndInit();
			this.groupControl35.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region security
		public void initData (ACMSLogic.User User)
		{
			oUser = User;
			MemberRecord myMemberRecord = new MemberRecord(oUser.StrBranchCode());
		}

		public void SetEmployeeRecord(Do.Employee emp)
		{
			employee = emp;
		}

		public void SetTerminalUser(Do.TerminalUser tu)
		{
			terminalUser = tu;

		}

		
		#endregion

		# region Roster

		private void initRoster(string target,string _value)
		{
			RosterBranch = comboBoxRoster.EditValue.ToString();
			if (target=="CC")
			{
				_value = comboBoxRosterCC.EditValue.ToString();
				RosterBranch = comboBoxRoster.EditValue.ToString();
			}
			

			string strSQL;
			DataSet _ds;
			if (currentDay == "" || currentDay == null)
			{
				strSQL = "select getDate() as today,datepart(weekday,getDate()) as week_day,datepart(week,getDate()) as WeekNo";
			}
			else
			{
				strSQL = "select '" + currentDay + "' as today,datepart(weekday,'" + currentDay + "') as week_day,datepart(week,'" + currentDay + "') as WeekNo";
			}
			
			try 
			{
				acmsRosterHeader1.DataBindings.Clear();
				acmsRosterHeader1.dtRoster = null;
				acmsRosterHeader1.dtRosterDetail = null;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			acmsRosterHeader1.dtRoster = _ds.Tables["table"];
			DataTable dt;
			dt = _ds.Tables["table"];
			Week_Day = Convert.ToInt32(dt.Rows[0]["week_day"]);
			currentDay = Convert.ToDateTime( dt.Rows[0]["today"].ToString() ).AddDays(1 - Week_Day).ToString("yyyy-MM-dd");
			WeekNo = Convert.ToInt32(dt.Rows[0]["WeekNo"]);
			
			string selectedYear = cbYear.EditValue.ToString();
			if (WeekNo==53 && selectedYear =="2008") 
			WeekNo=1;
            myRoster = new Roster();
            DataTable tblRosterDetail = myRoster.GetRosterDetail(WeekNo, target, _value, RosterBranch, System.Convert.ToInt32(cbYear.EditValue));          
           // _ds = new DataSet();
           // SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"up_get_RosterDetail",_ds,new string[] {"table"}, new SqlParameter("@weekNO"
           //, WeekNo),new SqlParameter("@target", target),new SqlParameter("@value", _value),new SqlParameter("@branchvalue", RosterBranch),
           //new SqlParameter("@nYear", cbYear.EditValue) );
			acmsRosterHeader1.IsShowLeave = true;
			//acmsRosterHeader1.dtRosterDetail = _ds.Tables["table"];
            acmsRosterHeader1.dtRosterDetail = tblRosterDetail;
			
			this.acmsRosterHeader1.init(true,"","");
		    acmsRosterHeader1.Refresh();
			
		}

		private void InitRostercmb()
		{
			this.acmsRosterHeader1 = new ACMS.Control.ACMSRosterHeader();
			this.groupControl1.Controls.Add(this.acmsRosterHeader1);

			// 
			// acmsRosterHeader1
			// 
			this.acmsRosterHeader1.dtRoster = null;
			this.acmsRosterHeader1.dtRosterDetail = null;
			this.acmsRosterHeader1.EmpID = null;
			this.acmsRosterHeader1.Location = new System.Drawing.Point(8, 48);
			this.acmsRosterHeader1.Name = "acmsRosterHeader1";
			this.acmsRosterHeader1.Size = new System.Drawing.Size(816, 408);
			this.acmsRosterHeader1.TabIndex = 21;
			this.acmsRosterHeader1.WeekDay = null;
			this.acmsRosterHeader1.WeekNo = null;
			this.acmsRosterHeader1.year = null;
			this.acmsRosterHeader1.Click += new System.EventHandler(this._click);

			Refresh_comboBoxRoster();
		}

		private void comboBoxRoster_SelectedValueChanged(object sender, System.EventArgs e)
		{
			target="DEPT";
			if(comboBoxRosterCC.SelectedIndex!=0)
			{
				target="CC";
				initRoster(target,comboBoxRosterCC.EditValue.ToString());
				return;
			}
			initRoster(target,comboBoxRoster.EditValue.ToString());
		}

		private void Refresh_comboBoxRoster()
		{
			string strSQL;
			strSQL = "select strBranchCode,REPLACE(strBranchName,CHAR(10),'') AS strBranchName from tblBranch Where nBrStatusID =1";
			comboBind(comboBoxRoster,strSQL,"strBranchName","strBranchCode");

			strSQL = "select nCostCenterId,REPLACE(strDescription,CHAR(10),'') as strDescription from tblCostCenter";
			comboBind(comboBoxRosterCC,strSQL,"strDescription","nCostCenterId",true);
			
			//comboBoxRoster.SelectedIndex = 0;
			comboBoxRoster.EditValue = terminalUser.Branch.Id;
		}

		private void _click(object sender, System.EventArgs e)
		{
			ACMS.Control.ACMSRosterHeader rh = new ACMS.Control.ACMSRosterHeader();
			rh = (ACMS.Control.ACMSRosterHeader) sender;

			string dtDate;

			if ( rh.WeekDay != "1")
			{

				dtDate = Convert.ToDateTime(currentDay).AddDays(Convert.ToInt32(rh.WeekDay) - 1).ToString("yyyy-MM-dd");
			}
			else
            {
				dtDate = Convert.ToDateTime(currentDay).AddDays((Convert.ToInt32(rh.WeekDay)+7) - 1).ToString("yyyy-MM-dd");
			}

			string strDate;
			strDate = Convert.ToDateTime(currentDay).AddDays(- 7).ToString("yyyy-MM-dd");
			
			frmRoster myform;
			ACMSLogic.User.BranchCode = terminalUser.Branch.Id;
			ACMSLogic.User.EmployeeID = employee.Id;
			if (employee.Department != null)
				ACMSLogic.User.DepartmentID = employee.Department.Id;
			if (employee.StrEmployeeName != null)
				ACMSLogic.User.EmployeeName = employee.StrEmployeeName;
			if (employee.JobPosition.Id != null)
				ACMSLogic.User.JobPositionCode = employee.JobPosition.Id;
			if (employee.RightsLevel != null)
				ACMSLogic.User.RightsLevelID = employee.RightsLevel.Id;
			ACMSLogic.User oUser = new User();
			myform = new frmRoster(rh.EmpID,dtDate);
			myform.SetEmployeeRecord(employee);
			myform.SetTerminalUser(terminalUser);
			myform.initData(oUser);
			myform.ShowDialog();
			myform.Dispose();
			initRoster(target,comboBoxRoster.EditValue.ToString());
		}

		private void getCalendar(string strDate)
		{
			string strSQL;
			DataSet _ds;

			acmsRosterHeader1.DataBindings.Clear();
			acmsRosterHeader1.dtRosterDetail.Clear();

			strSQL = "select '" + strDate + "' as today,datepart(weekday,'" + strDate + "') as week_day";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			acmsRosterHeader1.dtRoster = _ds.Tables["table"];
			DataTable dt;
			dt = _ds.Tables["table"];
			Week_Day = Convert.ToInt32(dt.Rows[0]["week_day"]);
			currentDay = Convert.ToDateTime( dt.Rows[0]["today"].ToString() ).AddDays(1 - Week_Day).ToString("yyyy-MM-dd");
			strSQL = "select * from fn_GetRoster()";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			acmsRosterHeader1.dtRosterDetail = _ds.Tables["table"];


		}

		private void btnPastWeek_Click(object sender, System.EventArgs e)
		{
			WeekNo = WeekNo - 1;
			currentDay = Convert.ToDateTime(currentDay).AddDays(- 7).ToString("yyyy-MM-dd");
			initRoster(target,comboBoxRoster.EditValue.ToString());
            return;
		}

		private void btnNextWeek_Click(object sender, System.EventArgs e)
		{
			WeekNo = WeekNo + 1;
			currentDay = Convert.ToDateTime(currentDay).AddDays(7).ToString("yyyy-MM-dd");
			initRoster(target,comboBoxRoster.EditValue.ToString());
            return;
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{/*
			System.Globalization.CultureInfo oldCI;
			oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
				
			Excel.ApplicationClass excel = new Excel.ApplicationClass();
			Excel.Workbook _workbook;
			int id = excel.LanguageSettings.get_LanguageID(Office.MsoAppLanguageID.msoLanguageIDUI);
			System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(id);

			excel.Visible = true;
			excel.UserControl = true;
			_workbook = excel.Application.Workbooks.Add(Type.Missing);


			DataSet _ds;
			_ds = new DataSet();

			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"up_get_RosterExport",_ds,new string[] {"table"}, new SqlParameter("@weekNO", WeekNo),new SqlParameter("@target", target),new SqlParameter("@value", comboBoxRoster.EditValue.ToString()) );

			DataTable table = _ds.Tables[0];
			int ColumnIndex=0; 
			
			foreach(DataColumn col in table.Columns)
			{   
				ColumnIndex++;
				excel.Application.Cells[1,ColumnIndex]=col.ColumnName;
			
			} 
			int rowIndex=0; 

			foreach(DataRow row in table.Rows) 
			{   
				
				rowIndex++;       
				ColumnIndex=0;
				if (row["EmployeeId"].ToString() == "")
				{
					rowIndex = rowIndex - 1; 
				}
				foreach(DataColumn col in table.Columns)         
				{  					
					ColumnIndex++;  
					if (row["EmployeeId"].ToString() == "")
					{
						switch (col.ColumnName.ToString())
						{
							case "Employee Name":
								excel.Cells[1,ColumnIndex] = row[col.ColumnName];   
								break;
							case "Sunday":
								excel.Cells[1,ColumnIndex] = col.ColumnName + " (" + row[col.ColumnName] + ")";   
								break;
							case "Monday":
								excel.Cells[1,ColumnIndex] = col.ColumnName + " (" + row[col.ColumnName] + ")";  
								break;
							case "Tuesday":
								excel.Cells[1,ColumnIndex] = col.ColumnName + " (" + row[col.ColumnName] + ")";    
								break;
							case "Wednesday":
								excel.Cells[1,ColumnIndex] = col.ColumnName + " (" + row[col.ColumnName] + ")";    
								break;
							case "Thursday":
								excel.Cells[1,ColumnIndex] = col.ColumnName + " (" + row[col.ColumnName] + ")";    
								break;
							case "Friday":
								excel.Cells[1,ColumnIndex] = col.ColumnName + " (" + row[col.ColumnName] + ")";    
								break;
							case "Saturday":
								excel.Cells[1,ColumnIndex] = col.ColumnName + " (" + row[col.ColumnName] + ")";   
								break;
						}
						
					}
					else 
					{
						excel.Cells[rowIndex+1,ColumnIndex] = row[col.ColumnName];      
					}
				}
							
			} 
			excel.Visible = true; 
		
			Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet; 
			Excel.Range _rng;
		
			_rng = ((Excel.Worksheet)excel.ActiveSheet).get_Range("B1", "L1");
			_rng.Font.Bold = true;
			_rng.EntireRow.Font.Bold = true;
			_rng.EntireRow.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

			worksheet.Columns.ColumnWidth = 20;
			worksheet.Activate();

			System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;	
			*/
			ACMS.ACMSBranch.BranchTransaction.rptRoster myRoster= new ACMS.ACMSBranch.BranchTransaction.rptRoster();
			string strSQL;
			DataSet _ds;
			if (currentDay == "" || currentDay == null)
			{
				strSQL = "select getDate() as today,datepart(weekday,getDate()) as week_day,datepart(week,getDate()) as WeekNo";
			}
			else
			{
				strSQL = "select '" + currentDay + "' as today,datepart(weekday,'" + currentDay + "') as week_day,datepart(week,'" + currentDay + "') as WeekNo";
			}
			
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );

			myRoster.dtRoster = _ds.Tables["table"];
			myRoster.init();

			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"up_get_RosterDetail",_ds,new string[] {"table"}, new SqlParameter("@weekNO", WeekNo),new SqlParameter("@target", target),new SqlParameter("@value", comboBoxRosterCC.EditValue),new SqlParameter("@branchvalue", RosterBranch),new SqlParameter("@nYear", cbYear.SelectedText) );
			myRoster.DataSource = _ds;
			myRoster.dtRosterDetail = _ds.Tables["table"];

			myRoster.lblEmpID.DataBindings.Add("Text",_ds,"nEmployeeID");
			myRoster.lblEmpName.DataBindings.Add("Text",_ds,"strEmployeeName");
			myRoster.lblEmpDept.DataBindings.Add("Text",_ds,"DEPT");
			myRoster.SunSTime.DataBindings.Add("Text",_ds,"sunStartTime","{0:hh:mm tt}");//]) + " " + ConvertToTime(dr1["sunEndTime"]);
			myRoster.SunETime.DataBindings.Add("Text",_ds,"sunEndTime","{0:hh:mm tt}");
			myRoster.MonSTime.DataBindings.Add("Text",_ds,"monStartTime","{0:hh:mm tt}");
			myRoster.MonETime.DataBindings.Add("Text",_ds,"monEndTime","{0:hh:mm tt}");
			myRoster.TueSTime.DataBindings.Add("Text",_ds,"tueStartTime","{0:hh:mm tt}");
			myRoster.TueETime.DataBindings.Add("Text",_ds,"tueEndTime","{0:hh:mm tt}");
			myRoster.WedSTime.DataBindings.Add("Text",_ds,"wedStartTime","{0:hh:mm tt}");
			myRoster.WedETime.DataBindings.Add("Text",_ds,"wedEndTime","{0:hh:mm tt}");
			myRoster.ThuSTime.DataBindings.Add("Text",_ds,"thuStartTime","{0:hh:mm tt}");
			myRoster.ThuETime.DataBindings.Add("Text",_ds,"thuEndTime","{0:hh:mm tt}");
			myRoster.FriSTime.DataBindings.Add("Text",_ds,"friStartTime","{0:hh:mm tt}");
			myRoster.FriETime.DataBindings.Add("Text",_ds,"friEndTime","{0:hh:mm tt}");
			myRoster.SatSTime.DataBindings.Add("Text",_ds,"satStartTime","{0:hh:mm tt}");
			myRoster.SatETime.DataBindings.Add("Text",_ds,"satEndTime","{0:hh:mm tt}");

			myRoster.TotalHourWrk.DataBindings.Add("Text",_ds,"totalHour");
			myRoster.ShowPreviewDialog();

		
			
		}


		# endregion

		#region common
		private string ConvertToDateTime(object target)
		{
			if (target.ToString() == "" )
				return null;
			else
				return Convert.ToDateTime(target).ToString("yyyy-MM-dd");
		}

		private int ConvertToInt(object target)
		{
			if (target.ToString() == "" )
				return 0;
			else
				return Convert.ToInt32(target);
		}
		
		private void comboBind(DevExpress.XtraEditors.ImageComboBoxEdit control,string strSQL,string display,string strValue)
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
					properties.Items.Add( new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr[display].ToString(), dr[strValue].ToString(),-1));
				}
			}
			finally 
			{
				properties.Items.EndUpdate();
			}
			//Select the first item
			control.SelectedIndex = 0;
		}

		private void comboBind(DevExpress.XtraEditors.ImageComboBoxEdit control,string strSQL,string display,string strValue,bool fNum)
		{
		
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox properties = control.Properties;
			properties.Items.BeginUpdate();
			properties.Items.Clear();
			properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem("-- Select All --",0,-1));
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
		

		#endregion

		public string target
		{
			get
			{
				return _target;
			}
			set
			{
				_target = value;
			}
		}


		private void frmRosterMain_Load(object sender, System.EventArgs e)
		{
			InitRostercmb();
		}

		private void btnNew_Click(object sender, System.EventArgs e)
		{
			ACMS.ACMSManager.Human_Resource.frmRosterNew myForm = new frmRosterNew(comboBoxRoster.EditValue.ToString());
			myForm.initData(oUser);
			myForm.SetEmployeeRecord(employee);
			myForm.SetTerminalUser(terminalUser);
			
			myForm.ShowDialog();
		}

		private void comboBoxRosterCC_SelectedValueChanged(object sender, System.EventArgs e)
		{
			target="CC";
			if(comboBoxRosterCC.SelectedIndex==0)
			{
				target="DEPT";
				initRoster(target,comboBoxRoster.EditValue.ToString());
				return;
			}
			initRoster(target,comboBoxRosterCC.EditValue.ToString());
		}
	}
}
