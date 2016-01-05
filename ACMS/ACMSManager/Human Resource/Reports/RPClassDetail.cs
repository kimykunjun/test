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

namespace ACMS.ACMSManager.Reports
{
	/// <summary>
	/// Summary description for RPClassDetail.
	/// </summary>
	public class RPClassDetail : System.Windows.Forms.Form
	{
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.ImageComboBoxEdit cmbBranch;
        private DevExpress.XtraGrid.GridControl gridClassDetail;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public DateTime dateSun, dateMon, dateTue, dateWed, dateThu, dateFri, dateSat;
		private string connectionString;
		private SqlConnection connection;
		private int EmployeeId;
		private DevExpress.XtraEditors.TextEdit txtDay;
		private string ClassCode;
		private string strBranch;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private int nClassScheduleID;
		private ACMS.Control.ClassReportComponent Rcc;
		private ACMS.Control.ClassReportComponent2 Rcc2;
        private Label label3;
		private string fClassComponent;
        private DateTime dtClass;
        private bool fClass = false;
		public RPClassDetail(string nClassSchedule, string Dy,int nEmployeeID,ACMS.Control.ClassReportComponent Cc)
		{
			
			//
			// Required for Windows Form Designer support
			//
			fClassComponent ="1";
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
			InitializeComponent();
			
			switch(Dy)
			{
				case "1": txtDay.EditValue="Sunday";break;
				case "2": txtDay.EditValue="Monday";break;
				case "3": txtDay.EditValue="Tuesday";break;
				case "4": txtDay.EditValue="Wednesday";break;
				case "5": txtDay.EditValue="Thursday";break;
				case "6": txtDay.EditValue="Friday";break;
				case "7": txtDay.EditValue="Saturday";break;
			}
			
			Rcc = Cc;		
			nClassScheduleID=ACMS.Convert.ToInt32(nClassSchedule);
			modInitForms.fManager.Enabled = false;
			
			
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public RPClassDetail(string nClassSchedule, string Dy,int nEmployeeID,ACMS.Control.ClassReportComponent2 Cc)
		{
			
			//
			// Required for Windows Form Designer support
			//
			fClassComponent ="2";
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
			InitializeComponent();
			
			switch(Dy)
			{
				case "1": txtDay.EditValue="Sunday";break;
				case "2": txtDay.EditValue="Monday";break;
				case "3": txtDay.EditValue="Tuesday";break;
				case "4": txtDay.EditValue="Wednesday";break;
				case "5": txtDay.EditValue="Thursday";break;
				case "6": txtDay.EditValue="Friday";break;
				case "7": txtDay.EditValue="Saturday";break;
			}
			
			Rcc2 = Cc;           
			nClassScheduleID=ACMS.Convert.ToInt32(nClassSchedule);
			modInitForms.fManager.Enabled = false;
			
			
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        public RPClassDetail(int nClassSchedule, string Dy, DateTime dtClassDate)
        {

            //
            // Required for Windows Form Designer support
            //
            fClassComponent = "2";
            connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"];
            connection = new SqlConnection(connectionString);
            InitializeComponent();
            txtDay.EditValue = Dy;
            dtClass = dtClassDate;
            fClass = true;

            nClassScheduleID = nClassSchedule;
            modInitForms.fManager.Enabled = false;


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
            this.gridClassDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBranch = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.txtDay = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridClassDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridClassDetail
            // 
            this.gridClassDetail.DataMember = null;
            this.gridClassDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridClassDetail.EmbeddedNavigator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gridClassDetail.EmbeddedNavigator.Enabled = false;
            this.gridClassDetail.EmbeddedNavigator.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gridClassDetail.EmbeddedNavigator.Name = "";
            this.gridClassDetail.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.gridClassDetail.EmbeddedNavigator.TextStringFormat = null;
            this.gridClassDetail.EmbeddedNavigator.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Application;
            this.gridClassDetail.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gridClassDetail.Location = new System.Drawing.Point(0, 52);
            this.gridClassDetail.MainView = this.gridView1;
            this.gridClassDetail.Name = "gridClassDetail";
            this.gridClassDetail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridClassDetail.Size = new System.Drawing.Size(907, 417);
            this.gridClassDetail.TabIndex = 0;
            this.gridClassDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gridView1.GridControl = this.gridClassDetail;
            this.gridView1.GroupFormat = "";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Date";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "dtDate";
            this.gridColumn2.ImageIndex = 0;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.ToolTip = null;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 177;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn3.Caption = "No. of Attendees";
            this.gridColumn3.FieldName = "AttendanceNo";
            this.gridColumn3.ImageIndex = 0;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.ToolTip = null;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 101;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Instructor Name";
            this.gridColumn4.FieldName = "Instructor";
            this.gridColumn4.ImageIndex = 0;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.ToolTip = null;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 224;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Branch";
            this.gridColumn5.FieldName = "strBranchCode";
            this.gridColumn5.ImageIndex = 0;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.ToolTip = null;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 234;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Enabled = false;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(453, 234);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(0, 0);
            this.label2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(55, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Branch";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmbBranch
            // 
            this.cmbBranch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbBranch.Enabled = false;
            this.cmbBranch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbBranch.Location = new System.Drawing.Point(73, 7);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Properties.AutoHeight = false;
            this.cmbBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBranch.Properties.Mask.EditMask = null;
            this.cmbBranch.Properties.Mask.IgnoreMaskBlank = false;
            this.cmbBranch.Properties.Mask.SaveLiteral = false;
            this.cmbBranch.Properties.Mask.ShowPlaceHolders = false;
            this.cmbBranch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbBranch.Size = new System.Drawing.Size(105, 22);
            this.cmbBranch.TabIndex = 0;
            this.cmbBranch.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Application;
            this.cmbBranch.SelectedIndexChanged += new System.EventHandler(this.cmbBranch_SelectedIndexChanged);
            // 
            // txtDay
            // 
            this.txtDay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDay.Enabled = false;
            this.txtDay.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtDay.Location = new System.Drawing.Point(459, 8);
            this.txtDay.Name = "txtDay";
            this.txtDay.Properties.AutoHeight = false;
            this.txtDay.Properties.Mask.EditMask = null;
            this.txtDay.Properties.Mask.IgnoreMaskBlank = false;
            this.txtDay.Properties.Mask.SaveLiteral = false;
            this.txtDay.Properties.Mask.ShowPlaceHolders = false;
            this.txtDay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDay.Size = new System.Drawing.Size(100, 22);
            this.txtDay.TabIndex = 0;
            this.txtDay.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Application;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(420, 10);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(33, 22);
            this.label3.TabIndex = 1;
            this.label3.Text = "Day";
            // 
            // RPClassDetail
            // 
            this.ClientSize = new System.Drawing.Size(907, 469);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbBranch);
            this.Controls.Add(this.gridClassDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RPClassDetail";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Class Detail";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.RPClassDetail_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.RPClassDetail_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.gridClassDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDay.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void cmbBranch_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string strSQL;
			DataSet _ds;
			DataTable dt;

            if (fClass == true)
			strSQL = "up_get_ClassInstructorsDetail_dw "+nClassScheduleID + " , '" + dtClass+"'";
            else
            strSQL = "up_get_ClassInstructorsDetail " + nClassScheduleID;

			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
			DataView dv = new DataView(dt);
			
			if (cmbBranch.SelectedIndex >1 && cmbBranch.EditValue.ToString() != "" )
			{
				string Filter = " strBranchCode = '" + cmbBranch.EditValue + "'";
				dv.RowFilter = Filter;
			}
			gridClassDetail.DataSource = dv;

		}

		private void RPClassDetail_Load(object sender, System.EventArgs e)
		{
			BindBranch();
			cmbBranch.EditValue = strBranch;
			LoadDetail();
		}

		private void LoadDetail()
		{
			string strSQL;
			DataSet _ds;
			DataTable dt;

            if (fClass == true)
                strSQL = "up_get_ClassInstructorsDetail_dw " + nClassScheduleID + " , '" + dtClass + "'";
            else
                strSQL = "up_get_ClassInstructorsDetail " + nClassScheduleID;

			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
			DataView dv = new DataView(dt);
/*
			string Filter = " dtStartTime = '" + string.Format("{0:H:mm:ss}",Convert.ToDateTime(ClassTime.Time.ToShortTimeString())) + "'";
		
			if (cmbBranch.EditValue.ToString() != "")
				Filter += " And strBranchCode = '" + cmbBranch.EditValue + "'";

			if (txtDay.Text != "")
				Filter += " And nDay = " + txtDay.Text;

			dv.RowFilter = Filter;
			*/

			gridClassDetail.DataSource = dv;
	
		}

		private void BindBranch()
		{
			string strSQL = "Select strBranchCode,strBranchName from TblBranch Where nbrStatusID=1";//strBranchCode In (Select strBranchCode from tblemployeebranchrights Where nEmployeeId = " + EmployeeId + ")";

			comboBind(cmbBranch, strSQL, "strBranchName", "strBranchCode", true);
			cmbBranch.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem("- Please Select -",""));
			cmbBranch.SelectedIndex = 0;
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

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			LoadDetail();
		}

		private void RPClassDetail_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			modInitForms.fManager.Enabled = true;
			if(fClassComponent == "1")
			{
				Rcc.lblClassInstructor.BackColor = System.Drawing.Color.PaleGreen;
				Rcc.lblClassName.BackColor = System.Drawing.Color.PaleGreen;
				Rcc.lblClassTime.BackColor = System.Drawing.Color.PaleGreen;
			}
			
		}

        private void label1_Click(object sender, EventArgs e)
        {

        }

	}
}
