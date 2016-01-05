using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ACMS
{
	/// <summary>
	/// Summary description for FormNewNormalClassReservation.
	/// </summary>
	public class FormNewNormalClassReservation : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.PanelControl panelControl1;
		internal DevExpress.XtraGrid.GridControl GridControl19;
		internal DevExpress.XtraGrid.Views.Grid.GridView GridView20;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn127;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn135;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn136;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn138;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn139;
		private DevExpress.XtraEditors.PanelControl panelControl2;
		private DevExpress.XtraEditors.PanelControl panelControl3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.PanelControl panelControl4;
		private DevExpress.XtraEditors.TextEdit textEdit1;
		private DevExpress.XtraEditors.TextEdit textEdit2;
		private DevExpress.XtraEditors.TextEdit textEdit3;
		private DevExpress.XtraEditors.TextEdit textEdit4;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtMemberPackage;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private DevExpress.XtraEditors.PanelControl panelControl5;
		private System.Windows.Forms.Label label6;

		private ACMS.XtraUtils.LookupEditBuilder.MemberPackageLookupEditBuilder2 myMemberPackageLookupEditBuilder;
		//private ACMS.XtraUtils.LookupEditBuilder.MemberIDLookupEditBuilder myMemberIDLookupEditBuilder;
		private int myNClassInstanceID;
		private ACMSLogic.ClassAttendance myClassAttendance;
		private DataTable myClassReservationTable;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private int myPackageID = -1;
		private bool myIsNeedToVerifyMemberPackageLater = true;
		private string myMemberID = "";
		private ACMS.ucMemberID ucMemberID1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormNewNormalClassReservation(int nClassInstanceID, string strMembershipID,
			ACMSLogic.ClassAttendance classAttendance)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			
			myNClassInstanceID = nClassInstanceID;
			myClassAttendance = classAttendance;
			myClassReservationTable = myClassAttendance.ViewReservation(myNClassInstanceID);
			
			if (myClassReservationTable != null && myClassReservationTable.Rows.Count > 0)
			{
				GridControl19.DataSource = myClassReservationTable;
				DataRow[] uobReservations = myClassReservationTable.Select("fUOBBooking = 1", "", DataViewRowState.CurrentRows);
				textEdit3.Text = uobReservations.Length.ToString();

				DataRow[] normalReservations = myClassReservationTable.Select("fUOBBooking = 0", "", DataViewRowState.CurrentRows);
				textEdit2.Text = normalReservations.Length.ToString();

				textEdit4.Text = myClassReservationTable.Rows.Count.ToString();
			}
			
			ucMemberID1.StrBranchCode = ACMSLogic.User.BranchCode;
			ucMemberID1.EditValueChanged += new ACMSLogic.Common.EditValueChangedDelegate(UcMemberEditValueChanged);

			ACMSDAL.TblClassInstance classInstance = new ACMSDAL.TblClassInstance();
			classInstance.NClassInstanceID= myNClassInstanceID;
			DataTable table = classInstance.SelectOne();

			if (table == null || table.Rows.Count == 0)
				throw new Exception("Failed to reserve the non exist class.");
			textEdit1.Text = ACMS.Convert.ToInt32(classInstance.NMaxNo).ToString();

			Init();
			
			myMemberID = strMembershipID;

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public FormNewNormalClassReservation(int nClassInstanceID,
			ACMSLogic.ClassAttendance classAttendance)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			myNClassInstanceID = nClassInstanceID;
			myClassAttendance = classAttendance;
			myClassReservationTable = myClassAttendance.ViewReservation(myNClassInstanceID);
			
			if (myClassReservationTable != null && myClassReservationTable.Rows.Count > 0)
			{
				GridControl19.DataSource = myClassReservationTable;
				DataRow[] uobReservations = myClassReservationTable.Select("fUOBBooking = 1", "", DataViewRowState.CurrentRows);
				textEdit3.Text = uobReservations.Length.ToString();

				DataRow[] normalReservations = myClassReservationTable.Select("fUOBBooking = 0", "", DataViewRowState.CurrentRows);
				textEdit2.Text = normalReservations.Length.ToString();

				textEdit4.Text = myClassReservationTable.Rows.Count.ToString();
			}
			
			ucMemberID1.StrBranchCode = ACMSLogic.User.BranchCode;
			ucMemberID1.EditValueChanged += new ACMSLogic.Common.EditValueChangedDelegate(UcMemberEditValueChanged);

			ACMSDAL.TblClassInstance classInstance = new ACMSDAL.TblClassInstance();
			classInstance.NClassInstanceID= myNClassInstanceID;
			DataTable table = classInstance.SelectOne();

			if (table == null || table.Rows.Count == 0)
				throw new Exception("Failed to reserve the non exist class.");
			textEdit1.Text = ACMS.Convert.ToInt32(classInstance.NMaxNo).ToString();
		
			Init();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		
		private void Init()
		{
			myMemberPackageLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.MemberPackageLookupEditBuilder2(lkpEdtMemberPackage.Properties, false, "");
			//myMemberIDLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.MemberIDLookupEditBuilder(myMemberIDDataTable, lkpEdtMemberID.Properties);
		}

		public bool IsNeedToVerifyMemberPackage
		{
			get { return myIsNeedToVerifyMemberPackageLater;}	
		}

		public string MembershipID
		{
			get 
			{ 
				if (ucMemberID1.EditValue != null)
					return ucMemberID1.EditValue.ToString();
				else
					return "";
			}
		}

		public int MemberPackageID
		{
			get 
			{ 
				if (lkpEdtMemberPackage.Text != "")	
					return ACMS.Convert.ToInt32(lkpEdtMemberPackage.EditValue);
				else
					return myPackageID;
			}

			//get { return ACMS.Convert.ToInt32(lkpEdtMemberPackage.EditValue);}
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
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.ucMemberID1 = new ACMS.ucMemberID();
			this.label6 = new System.Windows.Forms.Label();
			this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
			this.lkpEdtMemberPackage = new DevExpress.XtraEditors.LookUpEdit();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.textEdit4 = new DevExpress.XtraEditors.TextEdit();
			this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
			this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
			this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
			this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
			this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
			this.GridControl19 = new DevExpress.XtraGrid.GridControl();
			this.GridView20 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.GridColumn127 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn135 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn136 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn138 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn139 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtMemberPackage.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
			this.panelControl3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.GridControl19)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridView20)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
			this.SuspendLayout();
			// 
			// panelControl1
			// 
			this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl1.Controls.Add(this.ucMemberID1);
			this.panelControl1.Controls.Add(this.label6);
			this.panelControl1.Controls.Add(this.panelControl5);
			this.panelControl1.Controls.Add(this.lkpEdtMemberPackage);
			this.panelControl1.Controls.Add(this.label4);
			this.panelControl1.Controls.Add(this.label5);
			this.panelControl1.Controls.Add(this.textEdit4);
			this.panelControl1.Controls.Add(this.textEdit3);
			this.panelControl1.Controls.Add(this.textEdit2);
			this.panelControl1.Controls.Add(this.textEdit1);
			this.panelControl1.Controls.Add(this.panelControl4);
			this.panelControl1.Controls.Add(this.label3);
			this.panelControl1.Controls.Add(this.label2);
			this.panelControl1.Controls.Add(this.label1);
			this.panelControl1.Controls.Add(this.panelControl3);
			this.panelControl1.Controls.Add(this.GridControl19);
			this.panelControl1.Controls.Add(this.panelControl2);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelControl1.Location = new System.Drawing.Point(0, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(662, 354);
			this.panelControl1.TabIndex = 0;
			this.panelControl1.Text = "panelControl1";
			// 
			// ucMemberID1
			// 
			this.ucMemberID1.EditValue = "";
			this.ucMemberID1.EditValueChanged = null;
			this.ucMemberID1.Location = new System.Drawing.Point(122, 290);
			this.ucMemberID1.Name = "ucMemberID1";
			this.ucMemberID1.Size = new System.Drawing.Size(182, 20);
			this.ucMemberID1.StrBranchCode = null;
			this.ucMemberID1.TabIndex = 49;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label6.Location = new System.Drawing.Point(14, 270);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(136, 16);
			this.label6.TabIndex = 48;
			this.label6.Text = "Make Reservation";
			// 
			// panelControl5
			// 
			this.panelControl5.Appearance.BackColor = System.Drawing.Color.Black;
			this.panelControl5.Appearance.Options.UseBackColor = true;
			this.panelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl5.Location = new System.Drawing.Point(2, 264);
			this.panelControl5.Name = "panelControl5";
			this.panelControl5.Size = new System.Drawing.Size(670, 3);
			this.panelControl5.TabIndex = 47;
			this.panelControl5.Text = "panelControl5";
			// 
			// lkpEdtMemberPackage
			// 
			this.lkpEdtMemberPackage.Location = new System.Drawing.Point(436, 290);
			this.lkpEdtMemberPackage.Name = "lkpEdtMemberPackage";
			// 
			// lkpEdtMemberPackage.Properties
			// 
			this.lkpEdtMemberPackage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtMemberPackage.Size = new System.Drawing.Size(204, 20);
			this.lkpEdtMemberPackage.TabIndex = 46;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(332, 290);
			this.label4.Name = "label4";
			this.label4.TabIndex = 44;
			this.label4.Text = "Member Package";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 290);
			this.label5.Name = "label5";
			this.label5.TabIndex = 43;
			this.label5.Text = "Member ID";
			// 
			// textEdit4
			// 
			this.textEdit4.EditValue = "0";
			this.textEdit4.Location = new System.Drawing.Point(314, 236);
			this.textEdit4.Name = "textEdit4";
			// 
			// textEdit4.Properties
			// 
			this.textEdit4.Properties.ReadOnly = true;
			this.textEdit4.Size = new System.Drawing.Size(75, 20);
			this.textEdit4.TabIndex = 15;
			// 
			// textEdit3
			// 
			this.textEdit3.EditValue = "0";
			this.textEdit3.Location = new System.Drawing.Point(314, 202);
			this.textEdit3.Name = "textEdit3";
			// 
			// textEdit3.Properties
			// 
			this.textEdit3.Properties.ReadOnly = true;
			this.textEdit3.Size = new System.Drawing.Size(75, 20);
			this.textEdit3.TabIndex = 14;
			// 
			// textEdit2
			// 
			this.textEdit2.EditValue = "0";
			this.textEdit2.Location = new System.Drawing.Point(314, 174);
			this.textEdit2.Name = "textEdit2";
			// 
			// textEdit2.Properties
			// 
			this.textEdit2.Properties.ReadOnly = true;
			this.textEdit2.Size = new System.Drawing.Size(75, 20);
			this.textEdit2.TabIndex = 13;
			// 
			// textEdit1
			// 
			this.textEdit1.EditValue = "textEdit1";
			this.textEdit1.Location = new System.Drawing.Point(84, 174);
			this.textEdit1.Name = "textEdit1";
			// 
			// textEdit1.Properties
			// 
			this.textEdit1.Properties.ReadOnly = true;
			this.textEdit1.Size = new System.Drawing.Size(75, 20);
			this.textEdit1.TabIndex = 12;
			// 
			// panelControl4
			// 
			this.panelControl4.Appearance.BackColor = System.Drawing.Color.Black;
			this.panelControl4.Appearance.Options.UseBackColor = true;
			this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl4.Location = new System.Drawing.Point(172, 230);
			this.panelControl4.Name = "panelControl4";
			this.panelControl4.Size = new System.Drawing.Size(224, 2);
			this.panelControl4.TabIndex = 11;
			this.panelControl4.Text = "panelControl4";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(172, 204);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(138, 23);
			this.label3.TabIndex = 10;
			this.label3.Text = "Total UOB Reservation ";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(172, 174);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(138, 23);
			this.label2.TabIndex = 9;
			this.label2.Text = "Total Normal Reservation";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(14, 174);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 23);
			this.label1.TabIndex = 8;
			this.label1.Text = "Class Limit";
			// 
			// panelControl3
			// 
			this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl3.Controls.Add(this.simpleButtonCancel);
			this.panelControl3.Controls.Add(this.simpleButtonOK);
			this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelControl3.Location = new System.Drawing.Point(0, 320);
			this.panelControl3.Name = "panelControl3";
			this.panelControl3.Size = new System.Drawing.Size(662, 34);
			this.panelControl3.TabIndex = 7;
			this.panelControl3.Text = "panelControl3";
			// 
			// simpleButtonCancel
			// 
			this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButtonCancel.Location = new System.Drawing.Point(566, 6);
			this.simpleButtonCancel.Name = "simpleButtonCancel";
			this.simpleButtonCancel.TabIndex = 48;
			this.simpleButtonCancel.Text = "Cancel";
			// 
			// simpleButtonOK
			// 
			this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButtonOK.Location = new System.Drawing.Point(478, 6);
			this.simpleButtonOK.Name = "simpleButtonOK";
			this.simpleButtonOK.TabIndex = 47;
			this.simpleButtonOK.Text = "OK";
			this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
			// 
			// GridControl19
			// 
			this.GridControl19.Dock = System.Windows.Forms.DockStyle.Top;
			// 
			// GridControl19.EmbeddedNavigator
			// 
			this.GridControl19.EmbeddedNavigator.Name = "";
			this.GridControl19.Location = new System.Drawing.Point(0, 24);
			this.GridControl19.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.GridControl19.LookAndFeel.UseDefaultLookAndFeel = false;
			this.GridControl19.LookAndFeel.UseWindowsXPTheme = false;
			this.GridControl19.MainView = this.GridView20;
			this.GridControl19.Name = "GridControl19";
			this.GridControl19.Size = new System.Drawing.Size(662, 142);
			this.GridControl19.TabIndex = 5;
			this.GridControl19.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										 this.GridView20});
			// 
			// GridView20
			// 
			this.GridView20.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							  this.GridColumn127,
																							  this.GridColumn135,
																							  this.GridColumn136,
																							  this.GridColumn138,
																							  this.GridColumn139,
																							  this.gridColumn1});
			this.GridView20.GridControl = this.GridControl19;
			this.GridView20.Name = "GridView20";
			// 
			// GridColumn127
			// 
			this.GridColumn127.Caption = "M/ship ID";
			this.GridColumn127.FieldName = "strMembershipID";
			this.GridColumn127.Name = "GridColumn127";
			this.GridColumn127.OptionsColumn.AllowEdit = false;
			this.GridColumn127.OptionsColumn.AllowFocus = false;
			this.GridColumn127.OptionsColumn.ReadOnly = true;
			this.GridColumn127.Visible = true;
			this.GridColumn127.VisibleIndex = 0;
			this.GridColumn127.Width = 59;
			// 
			// GridColumn135
			// 
			this.GridColumn135.Caption = "Member Name";
			this.GridColumn135.FieldName = "strMemberName";
			this.GridColumn135.Name = "GridColumn135";
			this.GridColumn135.OptionsColumn.AllowEdit = false;
			this.GridColumn135.OptionsColumn.AllowFocus = false;
			this.GridColumn135.OptionsColumn.ReadOnly = true;
			this.GridColumn135.Visible = true;
			this.GridColumn135.VisibleIndex = 1;
			this.GridColumn135.Width = 105;
			// 
			// GridColumn136
			// 
			this.GridColumn136.Caption = "UOB Booking Flag";
			this.GridColumn136.FieldName = "fUOBBooking";
			this.GridColumn136.Name = "GridColumn136";
			this.GridColumn136.OptionsColumn.AllowEdit = false;
			this.GridColumn136.OptionsColumn.AllowFocus = false;
			this.GridColumn136.OptionsColumn.ReadOnly = true;
			this.GridColumn136.Visible = true;
			this.GridColumn136.VisibleIndex = 2;
			this.GridColumn136.Width = 113;
			// 
			// GridColumn138
			// 
			this.GridColumn138.Caption = "Reservation Date";
			this.GridColumn138.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.GridColumn138.FieldName = "dtLastEditDate";
			this.GridColumn138.Name = "GridColumn138";
			this.GridColumn138.OptionsColumn.AllowEdit = false;
			this.GridColumn138.OptionsColumn.AllowFocus = false;
			this.GridColumn138.OptionsColumn.ReadOnly = true;
			this.GridColumn138.Visible = true;
			this.GridColumn138.VisibleIndex = 3;
			this.GridColumn138.Width = 131;
			// 
			// GridColumn139
			// 
			this.GridColumn139.Caption = "Reserved By";
			this.GridColumn139.FieldName = "strReservedByName";
			this.GridColumn139.Name = "GridColumn139";
			this.GridColumn139.OptionsColumn.AllowEdit = false;
			this.GridColumn139.OptionsColumn.AllowFocus = false;
			this.GridColumn139.OptionsColumn.ReadOnly = true;
			this.GridColumn139.Visible = true;
			this.GridColumn139.VisibleIndex = 4;
			this.GridColumn139.Width = 124;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Member Package ID";
			this.gridColumn1.FieldName = "nPackageID";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsColumn.AllowEdit = false;
			this.gridColumn1.OptionsColumn.AllowFocus = false;
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 5;
			this.gridColumn1.Width = 109;
			// 
			// panelControl2
			// 
			this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl2.Location = new System.Drawing.Point(0, 0);
			this.panelControl2.Name = "panelControl2";
			this.panelControl2.Size = new System.Drawing.Size(662, 24);
			this.panelControl2.TabIndex = 6;
			this.panelControl2.Text = "panelControl2";
			// 
			// FormNewNormalClassReservation
			// 
			this.AcceptButton = this.simpleButtonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.simpleButtonCancel;
			this.ClientSize = new System.Drawing.Size(662, 354);
			this.Controls.Add(this.panelControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormNewNormalClassReservation";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "New Class Reservation";
			this.Load += new System.EventHandler(this.FormNewNormalClassReservation_Load);
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtMemberPackage.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
			this.panelControl3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.GridControl19)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridView20)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	
		private void UcMemberEditValueChanged(string strMembershipID)
		{
			myMemberPackageLookupEditBuilder.Refresh(strMembershipID);
		}

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
						
			if ( MembershipID.Length == 0)
			{
				MessageBox.Show("MembershipID cannot be empty."); 
				return;
			}
			else if(lkpEdtMemberPackage.Text.Length == 0)
			{
				ACMSLogic.MemberPackage.CreateUnlinkedMemberPackage(MembershipID, ref myPackageID);
				myIsNeedToVerifyMemberPackageLater = false;
				return;
			}	

			
//			if (lkpEdtMemberPackage.Text.Length == 0 || MembershipID.Length == 0)
//			{
//				DialogResult result = MessageBox.Show("No package was selected. Do you still want to reserve it? \n " + 
//					"(An unlinked record will be create if you click yes) ", "Warning", MessageBoxButtons.YesNo);
				
//				if (result == DialogResult.Yes)
//				{
//					ACMSLogic.MemberPackage.CreateUnlinkedMemberPackage(MembershipID, ref myPackageID);
//					myIsNeedToVerifyMemberPackageLater = false;
//					return;
//				}
//				else
//				{
//					this.DialogResult = DialogResult.None;
//					return;
//				}
//			}
		}

		private void FormNewNormalClassReservation_Load(object sender, System.EventArgs e)
		{
			if (myMemberID != "")
			{
				ucMemberID1.EditValue = myMemberID;
				myMemberPackageLookupEditBuilder.Refresh(myMemberID);
			}

			ucMemberID1.Focus();
		}

	}
}
