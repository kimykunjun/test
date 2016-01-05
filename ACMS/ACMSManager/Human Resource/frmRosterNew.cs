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
	/// Summary description for frmRosterNew.
	/// </summary>
	public class frmRosterNew : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		Do.Employee employee;
		Do.TerminalUser terminalUser; 
		User oUser;
		private System.Windows.Forms.Label lblBranch;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.ImageComboBoxEdit cbBranch;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblStartTime;
		private DevExpress.XtraEditors.TimeEdit dtEndTime;
		private DevExpress.XtraEditors.TimeEdit dtStartTime;
		private DevExpress.XtraEditors.SimpleButton btnSave;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.ImageComboBoxEdit cbEmployee;
		private DevExpress.XtraEditors.DateEdit dtDate;
		private System.Windows.Forms.Label lbldate;
		private System.Windows.Forms.Label lblRemarks;
		private DevExpress.XtraEditors.MemoEdit txtRemarks;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private string BRANCH="";
		

		public frmRosterNew(string br)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			BRANCH = br;
			

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
			this.lblBranch = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.txtRemarks = new DevExpress.XtraEditors.MemoEdit();
			this.lblRemarks = new System.Windows.Forms.Label();
			this.lbldate = new System.Windows.Forms.Label();
			this.dtDate = new DevExpress.XtraEditors.DateEdit();
			this.label3 = new System.Windows.Forms.Label();
			this.cbEmployee = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.cbBranch = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.lblStartTime = new System.Windows.Forms.Label();
			this.dtEndTime = new DevExpress.XtraEditors.TimeEdit();
			this.dtStartTime = new DevExpress.XtraEditors.TimeEdit();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbEmployee.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbBranch.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEndTime.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtStartTime.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// lblBranch
			// 
			this.lblBranch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblBranch.Location = new System.Drawing.Point(-58, 142);
			this.lblBranch.Name = "lblBranch";
			this.lblBranch.Size = new System.Drawing.Size(58, 16);
			this.lblBranch.TabIndex = 186;
			this.lblBranch.Text = "Branch";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(16, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(112, 16);
			this.label4.TabIndex = 191;
			this.label4.Text = "New Roster";
			// 
			// groupControl1
			// 
			this.groupControl1.Controls.Add(this.txtRemarks);
			this.groupControl1.Controls.Add(this.lblRemarks);
			this.groupControl1.Controls.Add(this.lbldate);
			this.groupControl1.Controls.Add(this.dtDate);
			this.groupControl1.Controls.Add(this.label3);
			this.groupControl1.Controls.Add(this.cbEmployee);
			this.groupControl1.Controls.Add(this.label2);
			this.groupControl1.Controls.Add(this.cbBranch);
			this.groupControl1.Controls.Add(this.label1);
			this.groupControl1.Controls.Add(this.lblStartTime);
			this.groupControl1.Controls.Add(this.dtEndTime);
			this.groupControl1.Controls.Add(this.dtStartTime);
			this.groupControl1.Location = new System.Drawing.Point(16, 32);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.ShowCaption = false;
			this.groupControl1.Size = new System.Drawing.Size(280, 256);
			this.groupControl1.TabIndex = 192;
			this.groupControl1.Text = "groupControl1";
			// 
			// txtRemarks
			// 
			this.txtRemarks.EditValue = "";
			this.txtRemarks.Location = new System.Drawing.Point(16, 184);
			this.txtRemarks.Name = "txtRemarks";
			// 
			// txtRemarks.Properties
			// 
			this.txtRemarks.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.txtRemarks.Size = new System.Drawing.Size(232, 64);
			this.txtRemarks.TabIndex = 6;
			// 
			// lblRemarks
			// 
			this.lblRemarks.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblRemarks.Location = new System.Drawing.Point(16, 168);
			this.lblRemarks.Name = "lblRemarks";
			this.lblRemarks.Size = new System.Drawing.Size(80, 16);
			this.lblRemarks.TabIndex = 201;
			this.lblRemarks.Text = "Remarks";
			// 
			// lbldate
			// 
			this.lbldate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbldate.Location = new System.Drawing.Point(16, 80);
			this.lbldate.Name = "lbldate";
			this.lbldate.Size = new System.Drawing.Size(80, 16);
			this.lbldate.TabIndex = 200;
			this.lbldate.Text = "Date";
			// 
			// dtDate
			// 
			this.dtDate.EditValue = null;
			this.dtDate.Location = new System.Drawing.Point(104, 80);
			this.dtDate.Name = "dtDate";
			// 
			// dtDate.Properties
			// 
			this.dtDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.dtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																										   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dtDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.dtDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.dtDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
			this.dtDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.dtDate.Properties.Mask.EditMask = "dd/MM/yyyy";
			this.dtDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			this.dtDate.Size = new System.Drawing.Size(100, 22);
			this.dtDate.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(16, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 16);
			this.label3.TabIndex = 198;
			this.label3.Text = "Employee";
			// 
			// cbEmployee
			// 
			this.cbEmployee.Location = new System.Drawing.Point(104, 48);
			this.cbEmployee.Name = "cbEmployee";
			// 
			// cbEmployee.Properties
			// 
			this.cbEmployee.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.cbEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cbEmployee.Size = new System.Drawing.Size(144, 22);
			this.cbEmployee.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(16, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 196;
			this.label2.Text = "Branch";
			// 
			// cbBranch
			// 
			this.cbBranch.Location = new System.Drawing.Point(104, 16);
			this.cbBranch.Name = "cbBranch";
			// 
			// cbBranch.Properties
			// 
			this.cbBranch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.cbBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cbBranch.Size = new System.Drawing.Size(144, 22);
			this.cbBranch.TabIndex = 1;
			this.cbBranch.SelectedIndexChanged += new System.EventHandler(this.cbBranch_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(144, 112);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 194;
			this.label1.Text = "End Time";
			// 
			// lblStartTime
			// 
			this.lblStartTime.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblStartTime.Location = new System.Drawing.Point(16, 112);
			this.lblStartTime.Name = "lblStartTime";
			this.lblStartTime.Size = new System.Drawing.Size(80, 16);
			this.lblStartTime.TabIndex = 193;
			this.lblStartTime.Text = "Start Time";
			// 
			// dtEndTime
			// 
			this.dtEndTime.EditValue = null;
			this.dtEndTime.Location = new System.Drawing.Point(144, 136);
			this.dtEndTime.Name = "dtEndTime";
			// 
			// dtEndTime.Properties
			// 
			this.dtEndTime.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.dtEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton()});
			this.dtEndTime.Properties.DisplayFormat.FormatString = "hh:mm tt";
			this.dtEndTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.dtEndTime.Properties.EditFormat.FormatString = "hh:mm tt";
			this.dtEndTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.dtEndTime.Size = new System.Drawing.Size(104, 22);
			this.dtEndTime.TabIndex = 5;
			// 
			// dtStartTime
			// 
			this.dtStartTime.EditValue = null;
			this.dtStartTime.Location = new System.Drawing.Point(16, 136);
			this.dtStartTime.Name = "dtStartTime";
			// 
			// dtStartTime.Properties
			// 
			this.dtStartTime.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.dtStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton()});
			this.dtStartTime.Properties.DisplayFormat.FormatString = "hh:mm tt";
			this.dtStartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.dtStartTime.Properties.EditFormat.FormatString = "hh:mm tt";
			this.dtStartTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.dtStartTime.Size = new System.Drawing.Size(104, 22);
			this.dtStartTime.TabIndex = 4;
			// 
			// btnSave
			// 
			this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSave.Appearance.Options.UseFont = true;
			this.btnSave.Location = new System.Drawing.Point(128, 296);
			this.btnSave.LookAndFeel.UseDefaultLookAndFeel = false;
			this.btnSave.Name = "btnSave";
			this.btnSave.TabIndex = 7;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancel.Appearance.Options.UseFont = true;
			this.btnCancel.Location = new System.Drawing.Point(208, 296);
			this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmRosterNew
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(306, 327);
			this.Controls.Add(this.groupControl1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lblBranch);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmRosterNew";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add New Roster";
			this.Load += new System.EventHandler(this.frmRosterNew_Load);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbEmployee.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbBranch.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEndTime.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtStartTime.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region
		private void initRoster()
		{
		}
		#endregion

		#region common
		private string ConvertToDateTime(object target)
		{
			if (target.ToString() == "" )
				return null;
			else
				return Convert.ToDateTime(target).ToString();
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

		private void init()
		{
			string strSQL;
			strSQL = "select * from tblBranch where nBrStatusID=1 ";
			comboBind(cbBranch,strSQL,"strBranchName","strBranchCode");
			cbBranch.EditValue = BRANCH;
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			int output;
			output = 0;

			if(employee.CanAccess("AM_INSERT_ROSTER",terminalUser.Branch.Id))
			{
				if(employee.CanAccess("AM_INSERT_TODAYROSTER",terminalUser.Branch.Id)==true && System.Convert.ToDateTime(dtDate.EditValue) <= DateTime.Today)
				{
					if (employee.Id == ConvertToInt(cbEmployee.EditValue)) 
					{
						MessageBox.Show("You can't edit your own today roster");
						return;
					}
				}
                else if (employee.CanAccess("AM_INSERT_TODAYROSTER", terminalUser.Branch.Id) == false && System.Convert.ToDateTime(dtDate.EditValue) <= DateTime.Today)
				{
					MessageBox.Show("You cannot insert today or previous roster.");
					return;
				}
				
				try			
				{
					if (dtStartTime.EditValue == null || dtEndTime.EditValue == null)
					{
						MessageBox.Show("Must Key in Start Time and End Time");
					}
					else
					{
						if ( TimeRangeValidation())
						{
						int yy,mm,dd,hh,min,ss;
						yy= Convert.ToDateTime(dtDate.EditValue).Year;
						mm= Convert.ToDateTime(dtDate.EditValue).Month;
						dd= Convert.ToDateTime(dtDate.EditValue).Day;

						hh = Convert.ToDateTime(dtStartTime.EditValue).Hour;
						min = Convert.ToDateTime(dtStartTime.EditValue).Minute;
						ss = Convert.ToDateTime(dtStartTime.EditValue).Second;

						DateTime dt1= new DateTime(yy,mm,dd,hh,min,ss);

						hh = Convert.ToDateTime(dtEndTime.EditValue).Hour;
						min = Convert.ToDateTime(dtEndTime.EditValue).Minute;
						ss = Convert.ToDateTime(dtEndTime.EditValue).Second;
						DateTime dt2= new DateTime(yy,mm,dd,hh,min,ss);
							try
							{
								SqlHelper.ExecuteNonQuery(connection,"In_tblRoster",
									new SqlParameter("@retval",output),
									new SqlParameter("@cmd","I"),
									new SqlParameter("@nRosterID",1),
									new SqlParameter("@dtDate",ConvertToDateTime(dtDate.EditValue)),
									new SqlParameter("@dtStartTime",dt1),
									new SqlParameter("@dtEndTime",dt2),
									new SqlParameter("@strBranchCode",cbBranch.EditValue.ToString()),
									new SqlParameter("@nEmployeeID",ConvertToInt(cbEmployee.EditValue)),
									new SqlParameter("@strRemarks",txtRemarks.EditValue.ToString()));
							}
							catch (Exception)
							{
								return;
							}

							MessageBox.Show("Record Inserted");
							//modInitForms.fManager.RefreshRoster();
							this.Activate();
						}
						else	
							MessageBox.Show("Time Range was overlapped with others record");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			else
			{
				MessageBox.Show("You don't have sufficient right to insert new roster for this staff");
			}
			
			//this.ParentForm.Refresh();
			

		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			modInitForms.fManager.RefreshRoster();
			this.Dispose();
		}
		private bool TimeRangeValidation()
		{
			DataSet _ds = new DataSet();

			string strSQL;
			strSQL = "select convert(varchar,dtStartTime,108),* from tblRoster where nEmployeeID='" + cbEmployee.EditValue.ToString() + "' and convert(varchar,dtDate,111)='" + Convert.ToDateTime(dtDate.EditValue).ToString("yyyy/MM/dd") + "' and ('" + Convert.ToDateTime(dtStartTime.EditValue).AddSeconds(1).ToString("hh:mm:ss") + "' between convert(varchar,dtStartTime,108) and convert(varchar,dtEndTime,108)";
			strSQL = strSQL + " or '" + Convert.ToDateTime(dtEndTime.EditValue).AddSeconds(-1).ToString("hh:mm:ss") + "' between convert(varchar,dtStartTime,108) and convert(varchar,dtEndTime,108) )" ;
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			if ( _ds.Tables["table"].Rows.Count > 0 )
			{
				return false;
			}
			else
			{
				return true;
			}
		
		

		}

		private void frmRosterNew_Load(object sender, System.EventArgs e)
		{
			init();
		}

		private void cbBranch_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string strSQL;
			strSQL = "select A.nEmployeeID,B.strEmployeeName from tblEmployeeBranchRights A join tblEmployee B on A.nEmployeeID=B.nEmployeeID where B.nStatusID=1 and A.strBranchCode='" + cbBranch.EditValue.ToString() + "' order by strEmployeeName";
			comboBind(cbEmployee,strSQL,"strEmployeeName","nEmployeeID");
		}
	}
}
