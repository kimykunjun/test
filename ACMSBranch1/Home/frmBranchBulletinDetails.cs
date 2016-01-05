using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using ACMS.Utils;

namespace ACMS.ACMSBranch.Home
{
	/// <summary>
	/// Summary description for frmBranchBulletinDetails.
	/// </summary>
	public class frmBranchBulletinDetails : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraGrid.GridControl gcBulletinDetails;
		private DevExpress.XtraGrid.Views.Grid.GridView gvBulletinDetails;
		private DevExpress.XtraGrid.Columns.GridColumn gc1;
		private DevExpress.XtraGrid.Columns.GridColumn gc2;
		private DevExpress.XtraGrid.Columns.GridColumn gc3;
		internal DevExpress.XtraEditors.MemoEdit txtMemoBulletinMessage;
		private DevExpress.XtraEditors.TextEdit txtReplyPerson;
		internal System.Windows.Forms.Label Label41;
		internal System.Windows.Forms.Label lblReplyPerson;
		internal System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.SimpleButton btCancel;
		private DevExpress.XtraEditors.TextEdit txtDate;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmBranchBulletinDetails(string nMemoID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			string strSQL;

			strSQL = "select A.*,B.strEmployeeName from tblMemoBulletin A join tblEmployee B on A.nEmployeeID=B.nEmployeeID where A.nMemoID='" + nMemoID + "'";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			gcBulletinDetails.DataSource = _ds.Tables["table"];
			this.txtDate.DataBindings.Add("EditValue",_ds.Tables["table"],"dtDate");
			this.txtReplyPerson.DataBindings.Add("EditValue",_ds.Tables["table"],"strEmployeeName");
			this.txtMemoBulletinMessage.DataBindings.Add("EditValue",_ds.Tables["table"],"strMessage");
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
			this.gcBulletinDetails = new DevExpress.XtraGrid.GridControl();
			this.gvBulletinDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gc1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gc2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gc3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.txtReplyPerson = new DevExpress.XtraEditors.TextEdit();
			this.txtMemoBulletinMessage = new DevExpress.XtraEditors.MemoEdit();
			this.Label41 = new System.Windows.Forms.Label();
			this.lblReplyPerson = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btCancel = new DevExpress.XtraEditors.SimpleButton();
			this.txtDate = new DevExpress.XtraEditors.TextEdit();
			((System.ComponentModel.ISupportInitialize)(this.gcBulletinDetails)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvBulletinDetails)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtReplyPerson.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMemoBulletinMessage.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// gcBulletinDetails
			// 
			this.gcBulletinDetails.Dock = System.Windows.Forms.DockStyle.Top;
			// 
			// gcBulletinDetails.EmbeddedNavigator
			// 
			this.gcBulletinDetails.EmbeddedNavigator.Name = "";
			this.gcBulletinDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gcBulletinDetails.Location = new System.Drawing.Point(0, 0);
			this.gcBulletinDetails.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.gcBulletinDetails.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gcBulletinDetails.MainView = this.gvBulletinDetails;
			this.gcBulletinDetails.Name = "gcBulletinDetails";
			this.gcBulletinDetails.Size = new System.Drawing.Size(488, 200);
			this.gcBulletinDetails.TabIndex = 0;
			this.gcBulletinDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											 this.gvBulletinDetails});
			// 
			// gvBulletinDetails
			// 
			this.gvBulletinDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									 this.gc1,
																									 this.gc2,
																									 this.gc3});
			this.gvBulletinDetails.GridControl = this.gcBulletinDetails;
			this.gvBulletinDetails.Name = "gvBulletinDetails";
			this.gvBulletinDetails.OptionsBehavior.Editable = false;
			this.gvBulletinDetails.OptionsCustomization.AllowFilter = false;
			this.gvBulletinDetails.OptionsCustomization.AllowSort = false;
			this.gvBulletinDetails.OptionsView.ShowGroupPanel = false;
			// 
			// gc1
			// 
			this.gc1.Caption = "nMemoID";
			this.gc1.FieldName = "nMemoID";
			this.gc1.Name = "gc1";
			// 
			// gc2
			// 
			this.gc2.Caption = "Date Time";
			this.gc2.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt";
			this.gc2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.gc2.FieldName = "dtDate";
			this.gc2.Name = "gc2";
			this.gc2.Visible = true;
			this.gc2.VisibleIndex = 0;
			this.gc2.Width = 134;
			// 
			// gc3
			// 
			this.gc3.Caption = "Reply From";
			this.gc3.FieldName = "strEmployeeName";
			this.gc3.Name = "gc3";
			this.gc3.Visible = true;
			this.gc3.VisibleIndex = 1;
			this.gc3.Width = 337;
			// 
			// txtReplyPerson
			// 
			this.txtReplyPerson.EditValue = "";
			this.txtReplyPerson.Enabled = false;
			this.txtReplyPerson.Location = new System.Drawing.Point(112, 248);
			this.txtReplyPerson.Name = "txtReplyPerson";
			// 
			// txtReplyPerson.Properties
			// 
			this.txtReplyPerson.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtReplyPerson.Properties.Appearance.Options.UseFont = true;
			this.txtReplyPerson.Size = new System.Drawing.Size(152, 22);
			this.txtReplyPerson.TabIndex = 2;
			// 
			// txtMemoBulletinMessage
			// 
			this.txtMemoBulletinMessage.EditValue = "";
			this.txtMemoBulletinMessage.Enabled = false;
			this.txtMemoBulletinMessage.Location = new System.Drawing.Point(112, 280);
			this.txtMemoBulletinMessage.Name = "txtMemoBulletinMessage";
			// 
			// txtMemoBulletinMessage.Properties
			// 
			this.txtMemoBulletinMessage.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtMemoBulletinMessage.Properties.Appearance.Options.UseFont = true;
			this.txtMemoBulletinMessage.Size = new System.Drawing.Size(368, 112);
			this.txtMemoBulletinMessage.TabIndex = 12;
			// 
			// Label41
			// 
			this.Label41.Enabled = false;
			this.Label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label41.Location = new System.Drawing.Point(16, 216);
			this.Label41.Name = "Label41";
			this.Label41.Size = new System.Drawing.Size(88, 18);
			this.Label41.TabIndex = 13;
			this.Label41.Text = "Date Time";
			// 
			// lblReplyPerson
			// 
			this.lblReplyPerson.Enabled = false;
			this.lblReplyPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblReplyPerson.Location = new System.Drawing.Point(16, 248);
			this.lblReplyPerson.Name = "lblReplyPerson";
			this.lblReplyPerson.Size = new System.Drawing.Size(88, 18);
			this.lblReplyPerson.TabIndex = 14;
			this.lblReplyPerson.Text = "Reply By";
			// 
			// label2
			// 
			this.label2.Enabled = false;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(16, 280);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 18);
			this.label2.TabIndex = 15;
			this.label2.Text = "Message";
			// 
			// btCancel
			// 
			this.btCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btCancel.Appearance.Options.UseFont = true;
			this.btCancel.Location = new System.Drawing.Point(400, 400);
			this.btCancel.Name = "btCancel";
			this.btCancel.TabIndex = 16;
			this.btCancel.Text = "Cancel";
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			// 
			// txtDate
			// 
			this.txtDate.Location = new System.Drawing.Point(112, 216);
			this.txtDate.Name = "txtDate";
			// 
			// txtDate.Properties
			// 
			this.txtDate.Properties.Mask.EditMask = "G";
			this.txtDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.txtDate.Size = new System.Drawing.Size(152, 22);
			this.txtDate.TabIndex = 17;
			// 
			// frmBranchBulletinDetails
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(488, 429);
			this.Controls.Add(this.txtDate);
			this.Controls.Add(this.btCancel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblReplyPerson);
			this.Controls.Add(this.Label41);
			this.Controls.Add(this.txtMemoBulletinMessage);
			this.Controls.Add(this.txtReplyPerson);
			this.Controls.Add(this.gcBulletinDetails);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmBranchBulletinDetails";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Branch Bulletin Details";
			((System.ComponentModel.ISupportInitialize)(this.gcBulletinDetails)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvBulletinDetails)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtReplyPerson.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMemoBulletinMessage.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

	}
}
