using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

namespace ACMS.ACMSBranch
	//namespace ACMS.ACMSBranch.MemberActivities
{
	/// <summary>
	/// Summary description for frmEditActivities.
	/// </summary>
	public class frmEditActivities : DevExpress.XtraEditors.XtraForm
	{
		private string connectionString;
		private SqlConnection connection;
		private ACMS.Utils.Common myCommon;
		private System.Windows.Forms.Label label6;
		internal DevExpress.XtraEditors.SimpleButton btnClose;
		private System.Windows.Forms.Label label1;
		internal DevExpress.XtraEditors.SimpleButton btnSave;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.TextEdit txt_ActDescription;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.TextEdit txt_ActHandicap;
		private DevExpress.XtraEditors.TextEdit txt_ActScore;
		private DevExpress.XtraEditors.TextEdit txt_ActHole;
		protected string strMembershipID;
		protected int nCourse;
		
		private DevExpress.XtraEditors.LookUpEdit lk_ActCourse;
		private DevExpress.XtraEditors.DateEdit txt_ActDate;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmEditActivities(string MembershipID,DateTime ADate, int Course)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			myCommon = new ACMS.Utils.Common();

			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
			
			strMembershipID=MembershipID;
			nCourse=Course;
			txt_ActDate.EditValue=ADate;

//			System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
//			string formats  = {"dd/MM/yyyy hh:mm tt", "dd/MM/yy hh:mm tt"};    
//			DateTime a = DateTime.ParseExact(ADate.ToString(), formats, System.Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.NoCurrentDateDefault);   
//						
//			MessageBox.Show(a.ToShortDateString());
//
//			
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
			this.label6 = new System.Windows.Forms.Label();
			this.btnClose = new DevExpress.XtraEditors.SimpleButton();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.label4 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txt_ActDescription = new DevExpress.XtraEditors.TextEdit();
			this.label3 = new System.Windows.Forms.Label();
			this.txt_ActHandicap = new DevExpress.XtraEditors.TextEdit();
			this.txt_ActScore = new DevExpress.XtraEditors.TextEdit();
			this.txt_ActHole = new DevExpress.XtraEditors.TextEdit();
			this.lk_ActCourse = new DevExpress.XtraEditors.LookUpEdit();
			this.txt_ActDate = new DevExpress.XtraEditors.DateEdit();
			((System.ComponentModel.ISupportInitialize)(this.txt_ActDescription.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txt_ActHandicap.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txt_ActScore.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txt_ActHole.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_ActCourse.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txt_ActDate.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.Location = new System.Drawing.Point(16, 72);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(112, 16);
			this.label6.TabIndex = 189;
			this.label6.Text = "Course";
			// 
			// btnClose
			// 
			this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnClose.Location = new System.Drawing.Point(216, 184);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(72, 20);
			this.btnClose.TabIndex = 203;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(16, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 16);
			this.label1.TabIndex = 187;
			this.label1.Text = "Description";
			// 
			// btnSave
			// 
			this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnSave.Location = new System.Drawing.Point(96, 184);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(72, 20);
			this.btnSave.TabIndex = 202;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(16, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 16);
			this.label4.TabIndex = 185;
			this.label4.Text = "No. of Holes";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label8.Location = new System.Drawing.Point(16, 120);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(112, 16);
			this.label8.TabIndex = 184;
			this.label8.Text = "Handicap";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(16, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 23);
			this.label2.TabIndex = 194;
			this.label2.Text = "Date";
			// 
			// txt_ActDescription
			// 
			this.txt_ActDescription.EditValue = "";
			this.txt_ActDescription.Location = new System.Drawing.Point(160, 48);
			this.txt_ActDescription.Name = "txt_ActDescription";
			this.txt_ActDescription.Size = new System.Drawing.Size(240, 20);
			this.txt_ActDescription.TabIndex = 197;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(16, 144);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 16);
			this.label3.TabIndex = 197;
			this.label3.Text = "Score";
			// 
			// txt_ActHandicap
			// 
			this.txt_ActHandicap.EditValue = "";
			this.txt_ActHandicap.Location = new System.Drawing.Point(160, 120);
			this.txt_ActHandicap.Name = "txt_ActHandicap";
			// 
			// txt_ActHandicap.Properties
			// 
			this.txt_ActHandicap.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.txt_ActHandicap.Size = new System.Drawing.Size(240, 20);
			this.txt_ActHandicap.TabIndex = 200;
			// 
			// txt_ActScore
			// 
			this.txt_ActScore.EditValue = "";
			this.txt_ActScore.Location = new System.Drawing.Point(160, 144);
			this.txt_ActScore.Name = "txt_ActScore";
			// 
			// txt_ActScore.Properties
			// 
			this.txt_ActScore.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.txt_ActScore.Size = new System.Drawing.Size(240, 20);
			this.txt_ActScore.TabIndex = 201;
			// 
			// txt_ActHole
			// 
			this.txt_ActHole.EditValue = "";
			this.txt_ActHole.Location = new System.Drawing.Point(160, 96);
			this.txt_ActHole.Name = "txt_ActHole";
			// 
			// txt_ActHole.Properties
			// 
			this.txt_ActHole.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.txt_ActHole.Size = new System.Drawing.Size(240, 20);
			this.txt_ActHole.TabIndex = 199;
			// 
			// lk_ActCourse
			// 
			this.lk_ActCourse.Enabled = false;
			this.lk_ActCourse.Location = new System.Drawing.Point(160, 72);
			this.lk_ActCourse.Name = "lk_ActCourse";
			// 
			// lk_ActCourse.Properties
			// 
			this.lk_ActCourse.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lk_ActCourse.Properties.Appearance.Options.UseBackColor = true;
			this.lk_ActCourse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_ActCourse.Properties.NullText = "";
			this.lk_ActCourse.Size = new System.Drawing.Size(240, 20);
			this.lk_ActCourse.TabIndex = 198;
			// 
			// txt_ActDate
			// 
			this.txt_ActDate.EditValue = null;
			this.txt_ActDate.Enabled = false;
			this.txt_ActDate.Location = new System.Drawing.Point(160, 24);
			this.txt_ActDate.Name = "txt_ActDate";
			// 
			// txt_ActDate.Properties
			// 
			this.txt_ActDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.txt_ActDate.Properties.Appearance.Options.UseBackColor = true;
			this.txt_ActDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.txt_ActDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.txt_ActDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.txt_ActDate.Size = new System.Drawing.Size(240, 20);
			this.txt_ActDate.TabIndex = 196;
			// 
			// frmEditActivities
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(448, 230);
			this.Controls.Add(this.txt_ActDate);
			this.Controls.Add(this.lk_ActCourse);
			this.Controls.Add(this.txt_ActHole);
			this.Controls.Add(this.txt_ActScore);
			this.Controls.Add(this.txt_ActHandicap);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txt_ActDescription);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label8);
			this.Name = "frmEditActivities";
			this.Text = "Update Activity";
			this.Load += new System.EventHandler(this.frmEditActivities_Load);
			((System.ComponentModel.ISupportInitialize)(this.txt_ActDescription.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txt_ActHandicap.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txt_ActScore.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txt_ActHole.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_ActCourse.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txt_ActDate.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmEditActivities_Load(object sender, System.EventArgs e)
		{
			DataSet _ds = new DataSet();
			string strSQL;

			strSQL = "select * from tblCourse where fValid=0";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
			
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nCourseID","Course ID",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);

			//new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.luedtItemPromotion.Properties, dt, col, "strDescription", "strPromotionCode", "Promotion");

			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_ActCourse.Properties,dt,col,"strDescription","nCourseID","Course Selection");		
			BindData();
		}

		private void BindData()
		{

			DataSet _ds;
			_ds = new DataSet();

			

			string strSQL = "Select * from TblMemberActivities Where strMembershipID= N'" + strMembershipID + "' And dtDate = convert(DateTime, '"+ txt_ActDate.EditValue.ToString() +"', 103) And nCourse=" + nCourse;
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];

//			txt_ActDate.EditValue=dtDate;
			txt_ActDescription.EditValue=dt.Rows[0]["strDescription"];
			lk_ActCourse.EditValue=dt.Rows[0]["nCourse"];
			txt_ActHole.EditValue=dt.Rows[0]["nHole"];
			txt_ActHandicap.EditValue=dt.Rows[0]["nHandicap"];
			txt_ActScore.EditValue=dt.Rows[0]["nScore"];
		}


		private void btnSave_Click(object sender, System.EventArgs e)
		{
				
			string[] col = {"strMembershipID","dtDate","strDescription","nCourse","nHole","nHandicap","nScore"};

			object[] val = {strMembershipID,txt_ActDate.EditValue,txt_ActDescription.Text,lk_ActCourse.EditValue.ToString(),txt_ActHole.Text,txt_ActHandicap.Text,txt_ActScore.Text};               
			try
			{
				myCommon.Update("TblMemberActivities",col,val,"strMembershipID= N'" + strMembershipID + "' And dtDate= convert(DateTime, '"+ txt_ActDate.EditValue.ToString() +"', 103) And nCourse=" + nCourse);
			}
			catch (Exception ex)
			{
			MessageBox.Show("Update Failed!, Error in values","Error");
			}
				this.Close();
		   
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

	}
}

