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
using ACMS.Utils;
using System.IO;
using System.Data.OleDb;

namespace ACMS.ACMSManager.Operation
{
	/// <summary>
	/// Summary description for frmMemberCard.
	/// </summary>
	public class frmMemberCard : System.Windows.Forms.Form
	{
		private static DataTable dt;
		private static DataRow dr;
		private string connectionString;
		private SqlConnection connection;
		private static Do.Employee employee;
		private static Do.TerminalUser terminalUser;
		internal DevExpress.XtraGrid.GridControl GridMemberCard;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn225;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn234;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn235;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
		private System.Windows.Forms.Label mcard_lblNStatusID;
		private DevExpress.XtraEditors.ImageComboBoxEdit cmbMemberCard;
		internal DevExpress.XtraEditors.SimpleButton btnMemberCard_Reprint;
		internal DevExpress.XtraEditors.SimpleButton btnMemberCard_Print;
		private static User oUser;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		internal DevExpress.XtraGrid.Views.Grid.GridView gridViewMemberCard;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
		private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;

		private static int MemberCardRowFocus;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraEditors.GroupControl grpMemberCardBelow;
		private DevExpress.XtraGrid.GridControl gcTransferMember;
		private DevExpress.XtraEditors.TextEdit txtMemberName;
		private DevExpress.XtraEditors.TextEdit txtMemberID;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraGrid.Views.Grid.GridView gvTransferMember;
		internal DevExpress.XtraEditors.SimpleButton btnCancelCard;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMemberCard()
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
			this.GridMemberCard = new DevExpress.XtraGrid.GridControl();
			this.gridViewMemberCard = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.GridColumn225 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn234 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn235 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
			this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
			this.mcard_lblNStatusID = new System.Windows.Forms.Label();
			this.cmbMemberCard = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.btnMemberCard_Reprint = new DevExpress.XtraEditors.SimpleButton();
			this.btnMemberCard_Print = new DevExpress.XtraEditors.SimpleButton();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.grpMemberCardBelow = new DevExpress.XtraEditors.GroupControl();
			this.gcTransferMember = new DevExpress.XtraGrid.GridControl();
			this.gvTransferMember = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.txtMemberName = new DevExpress.XtraEditors.TextEdit();
			this.txtMemberID = new DevExpress.XtraEditors.TextEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnCancelCard = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.GridMemberCard)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMemberCard)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbMemberCard.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpMemberCardBelow)).BeginInit();
			this.grpMemberCardBelow.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcTransferMember)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvTransferMember)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMemberName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMemberID.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// GridMemberCard
			// 
			// 
			// GridMemberCard.EmbeddedNavigator
			// 
			this.GridMemberCard.EmbeddedNavigator.Name = "";
			this.GridMemberCard.Location = new System.Drawing.Point(16, 64);
			this.GridMemberCard.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.GridMemberCard.LookAndFeel.UseDefaultLookAndFeel = false;
			this.GridMemberCard.LookAndFeel.UseWindowsXPTheme = false;
			this.GridMemberCard.MainView = this.gridViewMemberCard;
			this.GridMemberCard.Name = "GridMemberCard";
			this.GridMemberCard.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																													this.repositoryItemImageComboBox1,
																													this.repositoryItemImageComboBox2});
			this.GridMemberCard.Size = new System.Drawing.Size(936, 208);
			this.GridMemberCard.TabIndex = 8;
			this.GridMemberCard.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										  this.gridViewMemberCard});
			// 
			// gridViewMemberCard
			// 
			this.gridViewMemberCard.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									  this.GridColumn225,
																									  this.GridColumn234,
																									  this.GridColumn235,
																									  this.gridColumn25,
																									  this.gridColumn1});
			this.gridViewMemberCard.GridControl = this.GridMemberCard;
			this.gridViewMemberCard.Name = "gridViewMemberCard";
			this.gridViewMemberCard.OptionsCustomization.AllowColumnMoving = false;
			this.gridViewMemberCard.OptionsCustomization.AllowFilter = false;
			this.gridViewMemberCard.OptionsSelection.MultiSelect = true;
			this.gridViewMemberCard.OptionsView.ShowGroupPanel = false;
			this.gridViewMemberCard.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewMemberCard_FocusedRowChanged);
			this.gridViewMemberCard.LostFocus += new System.EventHandler(this.gridViewMemberCard_LostFocus);
			// 
			// GridColumn225
			// 
			this.GridColumn225.Caption = "Membership ID";
			this.GridColumn225.FieldName = "strMembershipID";
			this.GridColumn225.Name = "GridColumn225";
			this.GridColumn225.OptionsColumn.AllowEdit = false;
			this.GridColumn225.Visible = true;
			this.GridColumn225.VisibleIndex = 0;
			this.GridColumn225.Width = 117;
			// 
			// GridColumn234
			// 
			this.GridColumn234.Caption = "Member Name";
			this.GridColumn234.FieldName = "strMemberName";
			this.GridColumn234.Name = "GridColumn234";
			this.GridColumn234.OptionsColumn.AllowEdit = false;
			this.GridColumn234.Visible = true;
			this.GridColumn234.VisibleIndex = 1;
			this.GridColumn234.Width = 161;
			// 
			// GridColumn235
			// 
			this.GridColumn235.Caption = "Source Branch";
			this.GridColumn235.FieldName = "BranchFrom";
			this.GridColumn235.Name = "GridColumn235";
			this.GridColumn235.OptionsColumn.AllowEdit = false;
			this.GridColumn235.Width = 190;
			// 
			// gridColumn25
			// 
			this.gridColumn25.Caption = "Collection Branch";
			this.gridColumn25.FieldName = "strBranchCode";
			this.gridColumn25.Name = "gridColumn25";
			this.gridColumn25.OptionsColumn.AllowEdit = false;
			this.gridColumn25.Visible = true;
			this.gridColumn25.VisibleIndex = 2;
			this.gridColumn25.Width = 162;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Status";
			this.gridColumn1.ColumnEdit = this.repositoryItemImageComboBox1;
			this.gridColumn1.FieldName = "nStatusID";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 3;
			this.gridColumn1.Width = 189;
			// 
			// repositoryItemImageComboBox1
			// 
			this.repositoryItemImageComboBox1.AutoHeight = false;
			this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemImageComboBox1.Items.AddRange(new object[] {
																			  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Request Print", 0, -1),
																			  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Print in Progress", 1, -1),
																			  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("In Transit", 3, -1),
																			  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Card Received", 4, -1),
																			  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Card Issued", 5, -1),
																			  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Cancelled", 6, -1),
																			  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Transfer Request", 7, -1)});
			this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
			// 
			// repositoryItemImageComboBox2
			// 
			this.repositoryItemImageComboBox2.AutoHeight = false;
			this.repositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
			// 
			// mcard_lblNStatusID
			// 
			this.mcard_lblNStatusID.BackColor = System.Drawing.Color.Transparent;
			this.mcard_lblNStatusID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mcard_lblNStatusID.Location = new System.Drawing.Point(16, 40);
			this.mcard_lblNStatusID.Name = "mcard_lblNStatusID";
			this.mcard_lblNStatusID.Size = new System.Drawing.Size(56, 16);
			this.mcard_lblNStatusID.TabIndex = 122;
			this.mcard_lblNStatusID.Text = "Status";
			// 
			// cmbMemberCard
			// 
			this.cmbMemberCard.Location = new System.Drawing.Point(72, 32);
			this.cmbMemberCard.Name = "cmbMemberCard";
			// 
			// cmbMemberCard.Properties
			// 
			this.cmbMemberCard.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbMemberCard.Properties.Items.AddRange(new object[] {
																		  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Show All", null, -1),
																		  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Request Print", 0, -1),
																		  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Print in Progress", 1, -1),
																		  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("In Transit", 3, -1),
																		  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Card Received", 4, -1),
																		  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Card Issued", 5, -1),
																		  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Cancelled", 6, -1)});
			this.cmbMemberCard.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.cmbMemberCard.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.cmbMemberCard.Size = new System.Drawing.Size(160, 20);
			this.cmbMemberCard.TabIndex = 120;
			this.cmbMemberCard.SelectedIndexChanged += new System.EventHandler(this.cmbMemberCard_SelectedIndexChanged);
			// 
			// btnMemberCard_Reprint
			// 
			this.btnMemberCard_Reprint.Appearance.BackColor = System.Drawing.Color.LightGray;
			this.btnMemberCard_Reprint.Appearance.BorderColor = System.Drawing.Color.Black;
			this.btnMemberCard_Reprint.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnMemberCard_Reprint.Appearance.ForeColor = System.Drawing.Color.Black;
			this.btnMemberCard_Reprint.Appearance.Options.UseBackColor = true;
			this.btnMemberCard_Reprint.Appearance.Options.UseBorderColor = true;
			this.btnMemberCard_Reprint.Appearance.Options.UseFont = true;
			this.btnMemberCard_Reprint.Appearance.Options.UseForeColor = true;
			this.btnMemberCard_Reprint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnMemberCard_Reprint.Enabled = false;
			this.btnMemberCard_Reprint.Location = new System.Drawing.Point(384, 32);
			this.btnMemberCard_Reprint.Name = "btnMemberCard_Reprint";
			this.btnMemberCard_Reprint.Size = new System.Drawing.Size(140, 20);
			this.btnMemberCard_Reprint.TabIndex = 119;
			this.btnMemberCard_Reprint.Text = "Reprint Member Card";
			this.btnMemberCard_Reprint.Click += new System.EventHandler(this.btnMemberCard_Reprint_Click);
			// 
			// btnMemberCard_Print
			// 
			this.btnMemberCard_Print.Appearance.BackColor = System.Drawing.Color.LightGray;
			this.btnMemberCard_Print.Appearance.BorderColor = System.Drawing.Color.Black;
			this.btnMemberCard_Print.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnMemberCard_Print.Appearance.ForeColor = System.Drawing.Color.Black;
			this.btnMemberCard_Print.Appearance.Options.UseBackColor = true;
			this.btnMemberCard_Print.Appearance.Options.UseBorderColor = true;
			this.btnMemberCard_Print.Appearance.Options.UseFont = true;
			this.btnMemberCard_Print.Appearance.Options.UseForeColor = true;
			this.btnMemberCard_Print.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnMemberCard_Print.Enabled = false;
			this.btnMemberCard_Print.Location = new System.Drawing.Point(248, 32);
			this.btnMemberCard_Print.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.btnMemberCard_Print.Name = "btnMemberCard_Print";
			this.btnMemberCard_Print.Size = new System.Drawing.Size(128, 20);
			this.btnMemberCard_Print.TabIndex = 118;
			this.btnMemberCard_Print.Text = "Print Member Card";
			this.btnMemberCard_Print.Click += new System.EventHandler(this.btnMemberCard_Print_Click);
			// 
			// groupControl1
			// 
			this.groupControl1.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.groupControl1.Appearance.Options.UseBackColor = true;
			this.groupControl1.Controls.Add(this.btnCancelCard);
			this.groupControl1.Controls.Add(this.grpMemberCardBelow);
			this.groupControl1.Controls.Add(this.btnMemberCard_Reprint);
			this.groupControl1.Controls.Add(this.mcard_lblNStatusID);
			this.groupControl1.Controls.Add(this.cmbMemberCard);
			this.groupControl1.Controls.Add(this.btnMemberCard_Print);
			this.groupControl1.Controls.Add(this.GridMemberCard);
			this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl1.Location = new System.Drawing.Point(0, 0);
			this.groupControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(984, 541);
			this.groupControl1.TabIndex = 123;
			this.groupControl1.Text = "Member Card";
			// 
			// grpMemberCardBelow
			// 
			this.grpMemberCardBelow.Appearance.BackColor = System.Drawing.Color.White;
			this.grpMemberCardBelow.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.grpMemberCardBelow.Appearance.Options.UseBackColor = true;
			this.grpMemberCardBelow.Controls.Add(this.gcTransferMember);
			this.grpMemberCardBelow.Controls.Add(this.txtMemberName);
			this.grpMemberCardBelow.Controls.Add(this.txtMemberID);
			this.grpMemberCardBelow.Controls.Add(this.label2);
			this.grpMemberCardBelow.Controls.Add(this.label1);
			this.grpMemberCardBelow.Location = new System.Drawing.Point(16, 288);
			this.grpMemberCardBelow.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.grpMemberCardBelow.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpMemberCardBelow.LookAndFeel.UseWindowsXPTheme = false;
			this.grpMemberCardBelow.Name = "grpMemberCardBelow";
			this.grpMemberCardBelow.Size = new System.Drawing.Size(936, 224);
			this.grpMemberCardBelow.TabIndex = 123;
			this.grpMemberCardBelow.Text = "In Transit Member Card";
			// 
			// gcTransferMember
			// 
			this.gcTransferMember.Dock = System.Windows.Forms.DockStyle.Left;
			// 
			// gcTransferMember.EmbeddedNavigator
			// 
			this.gcTransferMember.EmbeddedNavigator.Name = "";
			this.gcTransferMember.Location = new System.Drawing.Point(2, 20);
			this.gcTransferMember.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.gcTransferMember.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gcTransferMember.MainView = this.gvTransferMember;
			this.gcTransferMember.Name = "gcTransferMember";
			this.gcTransferMember.Size = new System.Drawing.Size(398, 202);
			this.gcTransferMember.TabIndex = 6;
			this.gcTransferMember.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											this.gvTransferMember});
			// 
			// gvTransferMember
			// 
			this.gvTransferMember.GridControl = this.gcTransferMember;
			this.gvTransferMember.Name = "gvTransferMember";
			this.gvTransferMember.OptionsBehavior.Editable = false;
			this.gvTransferMember.OptionsCustomization.AllowColumnMoving = false;
			this.gvTransferMember.OptionsCustomization.AllowFilter = false;
			this.gvTransferMember.OptionsCustomization.AllowSort = false;
			this.gvTransferMember.OptionsView.ShowGroupPanel = false;
			// 
			// txtMemberName
			// 
			this.txtMemberName.EditValue = "";
			this.txtMemberName.Enabled = false;
			this.txtMemberName.Location = new System.Drawing.Point(536, 144);
			this.txtMemberName.Name = "txtMemberName";
			this.txtMemberName.Size = new System.Drawing.Size(224, 20);
			this.txtMemberName.TabIndex = 5;
			// 
			// txtMemberID
			// 
			this.txtMemberID.EditValue = "";
			this.txtMemberID.Enabled = false;
			this.txtMemberID.Location = new System.Drawing.Point(536, 96);
			this.txtMemberID.Name = "txtMemberID";
			// 
			// txtMemberID.Properties
			// 
			this.txtMemberID.Properties.Appearance.BackColor = System.Drawing.Color.LightBlue;
			this.txtMemberID.Properties.Appearance.Options.UseBackColor = true;
			this.txtMemberID.Size = new System.Drawing.Size(176, 20);
			this.txtMemberID.TabIndex = 4;
			this.txtMemberID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMemberID_KeyPress);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(432, 144);
			this.label2.Name = "label2";
			this.label2.TabIndex = 3;
			this.label2.Text = "Member Name";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(432, 96);
			this.label1.Name = "label1";
			this.label1.TabIndex = 2;
			this.label1.Text = "Member ID";
			// 
			// btnCancelCard
			// 
			this.btnCancelCard.Appearance.BackColor = System.Drawing.Color.LightGray;
			this.btnCancelCard.Appearance.BorderColor = System.Drawing.Color.Black;
			this.btnCancelCard.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancelCard.Appearance.ForeColor = System.Drawing.Color.Black;
			this.btnCancelCard.Appearance.Options.UseBackColor = true;
			this.btnCancelCard.Appearance.Options.UseBorderColor = true;
			this.btnCancelCard.Appearance.Options.UseFont = true;
			this.btnCancelCard.Appearance.Options.UseForeColor = true;
			this.btnCancelCard.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnCancelCard.Location = new System.Drawing.Point(544, 32);
			this.btnCancelCard.Name = "btnCancelCard";
			this.btnCancelCard.Size = new System.Drawing.Size(72, 20);
			this.btnCancelCard.TabIndex = 124;
			this.btnCancelCard.Text = "Cancel";
			this.btnCancelCard.Click += new System.EventHandler(this.btnCancelCard_Click);
			// 
			// frmMemberCard
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(984, 541);
			this.Controls.Add(this.groupControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmMemberCard";
			this.Text = "Member Card";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmMemberCard_Load);
			((System.ComponentModel.ISupportInitialize)(this.GridMemberCard)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewMemberCard)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbMemberCard.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grpMemberCardBelow)).EndInit();
			this.grpMemberCardBelow.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gcTransferMember)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvTransferMember)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMemberName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMemberID.Properties)).EndInit();
			this.ResumeLayout(false);

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

		#region Member card
		private void MemberCardInit()
		{
			DataSet _ds = new DataSet();
						
			//	string strSQL = "up_get_Membership '" + terminalUser.Branch.Id.ToString() + "'";

			string strSQL = "select tblCardRequest.*,strMemberName, tblMember.strCardBranchCode as BranchFrom from tblCardRequest Inner Join tblMember On TblMember.strMembershipID = tblCardRequest.strMembershipID";

			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			
			DataView dv = new DataView(_ds.Tables["Table"]);
			
			if (cmbMemberCard.EditValue != null)
				dv.RowFilter = " nStatusID = " + cmbMemberCard.EditValue;

			GridMemberCard.DataSource = dv;

		}

		private void cmbMemberCard_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			MemberCardInit();

			if (cmbMemberCard.EditValue != null)
			{
				if (cmbMemberCard.EditValue.ToString() == "0")
				{
					this.btnMemberCard_Print.Enabled = true;
					this.btnMemberCard_Reprint.Enabled = false;
				}
				else if (cmbMemberCard.EditValue.ToString() == "1")
				{
					this.btnMemberCard_Print.Enabled = false;
					this.btnMemberCard_Reprint.Enabled = true;
				}
				else
				{
					this.btnMemberCard_Print.Enabled = false;
					this.btnMemberCard_Reprint.Enabled = false;
				}
			
				if (cmbMemberCard.EditValue.ToString() == "1")
				{
					this.txtMemberID.Enabled = true;
				}
				else
				{
					this.txtMemberID.Enabled = false;
				}
			}
			else
			{
				this.btnMemberCard_Print.Enabled = false;
				this.btnMemberCard_Reprint.Enabled = false;
			}

			gcTransferMember.DataSource = null;
			this.txtMemberID.EditValue = "";
			this.txtMemberName.EditValue = "";

		}

		private void btnMemberCard_Print_Click(object sender, System.EventArgs e)
		{
			
			if (gridViewMemberCard.SelectedRowsCount != 0)
			{
			openFileDialog1.Filter = "Access Files ( *.mdb )| *.mdb"; 

			if(openFileDialog1.ShowDialog() == DialogResult.OK)
				{
					string s = openFileDialog1.FileName;

					OleDbConnection aConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + s);
					OleDbCommand aCommand = new OleDbCommand("Insert Into tblMemberCard(Membership_ID,Member_Name,Branch_ID) values (@Membership_ID,@Member_Name,@Branch_ID)", aConnection);
					aCommand.Connection = aConnection;
					aConnection.Open();
					DataRow row = gridViewMemberCard.GetDataRow(gridViewMemberCard.FocusedRowHandle);

					string MembershipId;
					string MembershipName;
					string BranchId;
					int Id;

					for(int i=0;i<gridViewMemberCard.SelectedRowsCount;i++)
					{
						Id = Convert.ToInt32(gridViewMemberCard.GetSelectedRows().GetValue(i));
						row = gridViewMemberCard.GetDataRow(gridViewMemberCard.GetRowHandle(Id));
						MembershipId = (row["strMembershipId"]).ToString();
						MembershipName = (row["strMemberName"]).ToString();
						BranchId = (row["strBranchCode"]).ToString();
						aCommand.Parameters.Add(new OleDbParameter("@Membership_ID",MembershipId));
						aCommand.Parameters.Add(new OleDbParameter("@Member_Name",MembershipName));
						aCommand.Parameters.Add(new OleDbParameter("@Branch_ID",BranchId));
						aCommand.ExecuteNonQuery();
						aCommand.Parameters.Clear();
				


						int output;
						output = 0;

						SqlHelper.ExecuteNonQuery(connection,"up_tblCardRequest",
							new SqlParameter("@retval",output),
							new SqlParameter("@nStatusID",1 ),
							new SqlParameter("@dtLastEditDate",DateTime.Now ),
							new SqlParameter("@nEmployeeID",((row["nEmployeeID"]).ToString()) == "" ? DBNull.Value.ToString() : (row["nEmployeeID"]).ToString()),
							new SqlParameter("@nRequestID",(row["nRequestID"]).ToString() )
							);
						//	cmdToExecute.Parameters.Add(new SqlParameter("@" + column[i], (value[i]==null) ? DBNull.Value : value[i])); 

						SqlHelper.ExecuteNonQuery(connection,"up_tblMember",
							new SqlParameter("@retval",output),
							new SqlParameter("@nCardStatusID",1 ),
							new SqlParameter("@strCardBranchCode", "HQ" ),
							new SqlParameter("@strMembershipID",MembershipId )
							);

					}
					MessageBox.Show("Print Successfully!","Print Message");
					MemberCardInit();
					aConnection.Close();
				}
			}
			else
			{
				MessageBox.Show("Please select at least one member!","Print Message");
			}

		}

		private void btnMemberCard_Reprint_Click(object sender, System.EventArgs e)
		{
			if (gridViewMemberCard.SelectedRowsCount != 0)
			{
				openFileDialog1.Filter = "Access Files ( *.mdb )| *.mdb"; 

				if(openFileDialog1.ShowDialog() == DialogResult.OK)
				{
					string s = openFileDialog1.FileName;

					OleDbConnection aConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + s);
					OleDbCommand aCommand = new OleDbCommand("Insert Into tblMemberCard(Membership_ID,Member_Name,Branch_ID) values (@Membership_ID,@Member_Name,@Branch_ID)", aConnection);
					aCommand.Connection = aConnection;
					aConnection.Open();
					DataRow row = gridViewMemberCard.GetDataRow(gridViewMemberCard.FocusedRowHandle);

					string MembershipId;
					string MembershipName;
					string BranchId;
					int Id;

					for(int i=0;i<gridViewMemberCard.SelectedRowsCount;i++)
					{
						Id = Convert.ToInt32(gridViewMemberCard.GetSelectedRows().GetValue(i));
						row = gridViewMemberCard.GetDataRow(gridViewMemberCard.GetRowHandle(Id));
					
						MembershipId = (row["strMembershipId"]).ToString();
						MembershipName = (row["strMemberName"]).ToString();
						BranchId = (row["strBranchCode"]).ToString();
						aCommand.Parameters.Add(new OleDbParameter("@Membership_ID",MembershipId));
						aCommand.Parameters.Add(new OleDbParameter("@Member_Name",MembershipName));
						aCommand.Parameters.Add(new OleDbParameter("@Branch_ID",BranchId));
						aCommand.ExecuteNonQuery();
						aCommand.Parameters.Clear();
				
						int output;
						output = 0;

						SqlHelper.ExecuteNonQuery(connection,"up_tblCardRequest",
							new SqlParameter("@retval",output),
							new SqlParameter("@nStatusID",0 ),
							new SqlParameter("@dtLastEditDate",DateTime.Now ),
							new SqlParameter("@nEmployeeID",((row["nEmployeeID"]).ToString()) == "" ? DBNull.Value.ToString() : (row["nEmployeeID"]).ToString()),
							new SqlParameter("@nRequestID",(row["nRequestID"]).ToString() )
							);
						//	cmdToExecute.Parameters.Add(new SqlParameter("@" + column[i], (value[i]==null) ? DBNull.Value : value[i])); 

						SqlHelper.ExecuteNonQuery(connection,"up_tblMember",
							new SqlParameter("@retval",output),
							new SqlParameter("@nCardStatusID",0 ),
							new SqlParameter("@strCardBranchCode", "HQ" ),
							new SqlParameter("@strMembershipID",MembershipId )
							);

			

					}
				
				MemberCardInit();
				{
					MessageBox.Show("Reprint successfully!","Reprint Status");}
					aConnection.Close();
				}
			}
			else
			{
		
				MessageBox.Show("Please select at least one member!","Reprint Status");

			}
		}

		private void btnMemberCard_Transfer_Click(object sender, System.EventArgs e)
		{
			/*
			if (memoEdit1.Text != "")
			{
				string Splitter = memoEdit1.Text.Replace("\r\n","/");
			
				string[]s = new string[4];

				s = Splitter.Split(new char[] {'/'});
			
				for(int x = 0; x < s.Length; x++)
				{

					int output;
					output = 0;
					SqlHelper.ExecuteNonQuery(connection,"up_Branch_CardRequest",
						new SqlParameter("@retval",output),
						new SqlParameter("@empID",employee.Id),
						new SqlParameter("@strMembershipID",s[x] )
						);
				
				
				}
				MemberCardInit();
			{MessageBox.Show("Update Successfully","Transfer Status");}
			}
			else
			{MessageBox.Show("Please enter at least one member Id","Transfer Status");}
			*/
		}

		private void btnMemberCard_Received_Click(object sender, System.EventArgs e)
		{
			/*	if (memoEdit1.Text != "")
				{
					string Splitter = memoEdit1.Text.Replace("\r\n","/");
			
					string[]s = new string[4];

					s = Splitter.Split(new char[] {'/'});
			
					for(int x = 0; x < s.Length; x++)
					{

						int output;
						output = 0;
						SqlHelper.ExecuteNonQuery(connection,"up_Branch_CardRequestReceived",
							new SqlParameter("@retval",output),
							new SqlParameter("@empID",employee.Id),
							new SqlParameter("@BranchCode",oUser.StrBranchCode()),
							new SqlParameter("@strMembershipID",s[x] )
							);
				
				
					}
					MemberCardInit();
				{MessageBox.Show("Update Successfully","Transfer Status");}
				}
				else
				{MessageBox.Show("Please enter at least one member Id","Transfer Status");}
				*/
		}

		#endregion

		private void txtMemberID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if ( txtMemberName.Text != "" )
			{
				txtMemberID.Text="";
				txtMemberName.Text="";
			}
			//MessageBox.Show(e.KeyChar.ToString());
			DataSet _ds,_ds2;
			string strSQL;

			if ( e.KeyChar == 13  )
			{
				if ( cmbMemberCard.EditValue != null && cmbMemberCard.EditValue.ToString() == "1" )
				{
					strSQL="select * from tblMember where nCardStatusID='1' and strMembershipID='" + txtMemberID.Text + "'";
					_ds = new DataSet();
					SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
					if ( _ds.Tables["table"].Rows.Count>0)
					{
						strSQL="select * from tblCardRequest where nStatusID='1' and strMembershipID='" + txtMemberID.Text + "'";
						_ds2 = new DataSet();
						SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds2,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
						if ( _ds2.Tables["table"].Rows.Count>0 )
						{
							int output;
							try
							{			
								output = 0;
								SqlHelper.ExecuteNonQuery(connection,"up_Branch_CardInTransit",
									new SqlParameter("@retval",output),
									new SqlParameter("@empID",employee.Id),
									new SqlParameter("@BranchCode",oUser.StrBranchCode()),
									new SqlParameter("@strMembershipID",txtMemberID.Text )
									);
								foreach( DataRow dr2 in _ds.Tables["table"].Rows )
								{
									txtMemberName.Text = dr2["strMemberName"].ToString();
									dr = dt.NewRow();
									dr[0] = txtMemberID.Text;
									dr[1] = dr2["strMemberName"];
									dr[2] = "In Transit";//"Card Received";
									dt.Rows.Add(dr);
								}
								gcTransferMember.DataSource = dt;
							}
							catch (Exception ex)
							{
								MessageBox.Show("Update Failed:" + ex.Message );
							}
						}
					}

				}
				//this.txtMemberID.EditValue = "";
				MemberCardInit();
			}
			
		}
		private void frmMemberCard_Load(object sender, System.EventArgs e)
		{
			MemberCardRowFocus = 0;
			MemberCardInit();
			dt = new DataTable();
			dt.Columns.Add("Membership ID");
			dt.Columns.Add("Member Name");
			dt.Columns.Add("Status");
			
			gcTransferMember.DataSource = dt;
		}

		private void gridViewMemberCard_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			
			
			
		}
		public void CreateCmdsAndUpdate(string mySelectQuery,DataRow myRow) 
		{
			int output;
			output = 0;

			SqlHelper.ExecuteNonQuery(connection,"up_tblCardRequest",
				new SqlParameter("@retval",output),
				new SqlParameter("@nStatusID",myRow["nStatusID"].ToString()),//gridViewMemberCard.GetRowCellValue(MemberCardRowFocus,"nStatusID")),
				new SqlParameter("@dtLastEditDate",DateTime.Now ),
				new SqlParameter("@nEmployeeID",((myRow["nEmployeeID"]).ToString()) == "" ? DBNull.Value.ToString() : (myRow["nEmployeeID"]).ToString()),
				new SqlParameter("@nRequestID",(myRow["nRequestID"]).ToString() )
				);
		}


		private void gridViewMemberCard_LostFocus(object sender, System.EventArgs e)
		{
			DataRow row = this.gridViewMemberCard.GetDataRow(gridViewMemberCard.FocusedRowHandle);			
			string strSQL = "Select * from tblCardRequest";

			gridViewMemberCard.CloseEditor();
			gridViewMemberCard.UpdateCurrentRow();
			CreateCmdsAndUpdate(strSQL,row);
			
		}


		private void btnCancelCard_Click(object sender, System.EventArgs e)
		{
			gridViewMemberCard.CloseEditor();
			gridViewMemberCard.UpdateCurrentRow();
			DataRow dr;
			dr = this.gridViewMemberCard.GetDataRow(gridViewMemberCard.FocusedRowHandle);
			
			int CurrentMemberCardRowFocus = gridViewMemberCard.FocusedRowHandle;

			//CurrentLockerRowFocus = GridViewLocker.FocusedRowHandle;
			if (this.gridViewMemberCard.RowCount > 0)
			{
				int output;
				output = 0;

				SqlHelper.ExecuteNonQuery(connection,"up_tblCardRequest",
					new SqlParameter("@retval",output),
					new SqlParameter("@nStatusID",6),//gridViewMemberCard.GetRowCellValue(MemberCardRowFocus,"nStatusID")),
					new SqlParameter("@dtLastEditDate",DateTime.Now ),
					new SqlParameter("@nEmployeeID",((dr["nEmployeeID"]).ToString()) == "" ? DBNull.Value.ToString() : (dr["nEmployeeID"]).ToString()),
					new SqlParameter("@nRequestID",(dr["nRequestID"]).ToString() )
					);

				MemberCardRowFocus = this.gridViewMemberCard.FocusedRowHandle;
				this.gridViewMemberCard.FocusedRowHandle = CurrentMemberCardRowFocus;
			}
		}
	}
}