using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ACMS
{
	/// <summary>
	/// Summary description for FormNewSpaBooking.
	/// </summary>
	public class FormNewUOBSpaBooking : System.Windows.Forms.Form
	{
		internal DevExpress.XtraEditors.GroupControl GroupControl38;
		internal System.Windows.Forms.Label Label42;
		internal System.Windows.Forms.Label Label36;
		internal System.Windows.Forms.Label Label31;
		internal System.Windows.Forms.Label Label33;
		internal System.Windows.Forms.Label Label34;
		internal System.Windows.Forms.Label Label35;
		private ACMSLogic.SpaBooking mySpaBooking;
		internal DevExpress.XtraEditors.MemoEdit MemoEditRemark;
		private DataTable myDataTable;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtServiceCode;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtPackageID;
		private ACMS.XtraUtils.LookupEditBuilder.MemberPackageLookupEditBuilder2 myMemberPackageLookupBuilder;
		private ACMS.XtraUtils.LookupEditBuilder.ServiceCodeLookupEditBuilder2 myServiceCodeLookupBuilder;
		private ACMS.XtraUtils.LookupEditBuilder.TherapistForCommisionLookupEditBuilder myEmployeeIDLookupBuilder;
		private ACMS.XtraUtils.LookupEditBuilder.BranchCodeLookupEditBuilder2 myBranchCodeLookupEditBuilder;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtTherapist;
		private bool myIsWaitingList = false;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private DevExpress.XtraEditors.SimpleButton SimpleButton56;
		internal System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtMemberID;
		private DevExpress.XtraEditors.DateEdit dtEdtStartTime;
		private DevExpress.XtraEditors.DateEdit dtEdtEndTime;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.DateEdit dtEditDate;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtBranchCode;
		private System.Windows.Forms.Label label3;
		private System.ComponentModel.IContainer components = null;

		public FormNewUOBSpaBooking(ACMSLogic.SpaBooking spaBooking, bool isWaitingList)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			mySpaBooking = spaBooking;
			myIsWaitingList = isWaitingList;
			Init();
		}
		
		private void Init()
		{
			BindData();

			ACMSDAL.TblMember member = new ACMSDAL.TblMember();
			DataTable memberTable = member.SelectAll();
			ACMS.XtraUtils.LookupEditBuilder.MemberIDLookupEditBuilder myMemberIDLookupBuilder = new ACMS.XtraUtils.LookupEditBuilder.MemberIDLookupEditBuilder(memberTable, lkpEdtMemberID.Properties);
			myEmployeeIDLookupBuilder= new ACMS.XtraUtils.LookupEditBuilder.TherapistForCommisionLookupEditBuilder(lkpEdtTherapist.Properties, ACMSLogic.User.BranchCode);
			
			myMemberPackageLookupBuilder =
				new ACMS.XtraUtils.LookupEditBuilder.MemberPackageLookupEditBuilder2(lkpEdtPackageID.Properties, 
				true, "");
		
			myServiceCodeLookupBuilder = 
				new ACMS.XtraUtils.LookupEditBuilder.ServiceCodeLookupEditBuilder2(lkpEdtServiceCode.Properties, -1);

			myBranchCodeLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.BranchCodeLookupEditBuilder2(lkpEdtBranchCode.Properties);
			
		}

		private void BindData()
		{

			myDataTable = mySpaBooking.NewUOBSpaBooking();
			myDataTable.ColumnChanged +=new DataColumnChangeEventHandler(myDataTable_ColumnChanged);
			lkpEdtTherapist.DataBindings.Clear();
			dtEdtEndTime.DataBindings.Clear();
			lkpEdtPackageID.DataBindings.Clear();
			dtEdtStartTime.DataBindings.Clear();
			lkpEdtServiceCode.DataBindings.Clear();
			lkpEdtMemberID.DataBindings.Clear();
			MemoEditRemark.DataBindings.Clear();
			dtEditDate.DataBindings.Clear();
			dtEditDate.DataBindings.Add("EditValue", myDataTable, "dtDate");
			lkpEdtTherapist.DataBindings.Add("EditValue", myDataTable, "nServiceEmployeeID");
			dtEdtEndTime.DataBindings.Add("EditValue", myDataTable, "dtEndTime");
			lkpEdtPackageID.DataBindings.Add("EditValue", myDataTable, "nPackageID");
			dtEdtStartTime.DataBindings.Add("EditValue", myDataTable, "dtStartTime");
			lkpEdtServiceCode.DataBindings.Add("EditValue", myDataTable, "strServiceCode");
			lkpEdtMemberID.DataBindings.Add("EditValue", myDataTable, "strMembershipID");
			MemoEditRemark.DataBindings.Add("EditValue", myDataTable, "strRemarks");

			lkpEdtBranchCode.DataBindings.Clear();
			lkpEdtBranchCode.DataBindings.Add("EditValue", myDataTable, "strBranchCode");
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
			this.GroupControl38 = new DevExpress.XtraEditors.GroupControl();
			this.dtEditDate = new DevExpress.XtraEditors.DateEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.dtEdtEndTime = new DevExpress.XtraEditors.DateEdit();
			this.dtEdtStartTime = new DevExpress.XtraEditors.DateEdit();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			this.SimpleButton56 = new DevExpress.XtraEditors.SimpleButton();
			this.lkpEdtTherapist = new DevExpress.XtraEditors.LookUpEdit();
			this.lkpEdtMemberID = new DevExpress.XtraEditors.LookUpEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.lkpEdtPackageID = new DevExpress.XtraEditors.LookUpEdit();
			this.lkpEdtServiceCode = new DevExpress.XtraEditors.LookUpEdit();
			this.MemoEditRemark = new DevExpress.XtraEditors.MemoEdit();
			this.Label42 = new System.Windows.Forms.Label();
			this.Label36 = new System.Windows.Forms.Label();
			this.Label31 = new System.Windows.Forms.Label();
			this.Label33 = new System.Windows.Forms.Label();
			this.Label34 = new System.Windows.Forms.Label();
			this.Label35 = new System.Windows.Forms.Label();
			this.lkpEdtBranchCode = new DevExpress.XtraEditors.LookUpEdit();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.GroupControl38)).BeginInit();
			this.GroupControl38.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtEditDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEdtEndTime.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEdtStartTime.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtTherapist.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtMemberID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtPackageID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtServiceCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MemoEditRemark.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtBranchCode.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// GroupControl38
			// 
			this.GroupControl38.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.GroupControl38.Controls.Add(this.dtEditDate);
			this.GroupControl38.Controls.Add(this.label2);
			this.GroupControl38.Controls.Add(this.dtEdtEndTime);
			this.GroupControl38.Controls.Add(this.dtEdtStartTime);
			this.GroupControl38.Controls.Add(this.simpleButton2);
			this.GroupControl38.Controls.Add(this.SimpleButton56);
			this.GroupControl38.Controls.Add(this.lkpEdtTherapist);
			this.GroupControl38.Controls.Add(this.lkpEdtMemberID);
			this.GroupControl38.Controls.Add(this.label1);
			this.GroupControl38.Controls.Add(this.lkpEdtPackageID);
			this.GroupControl38.Controls.Add(this.lkpEdtServiceCode);
			this.GroupControl38.Controls.Add(this.MemoEditRemark);
			this.GroupControl38.Controls.Add(this.Label42);
			this.GroupControl38.Controls.Add(this.Label36);
			this.GroupControl38.Controls.Add(this.Label31);
			this.GroupControl38.Controls.Add(this.Label33);
			this.GroupControl38.Controls.Add(this.Label34);
			this.GroupControl38.Controls.Add(this.Label35);
			this.GroupControl38.Controls.Add(this.lkpEdtBranchCode);
			this.GroupControl38.Controls.Add(this.label3);
			this.GroupControl38.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GroupControl38.Location = new System.Drawing.Point(0, 0);
			this.GroupControl38.Name = "GroupControl38";
			this.GroupControl38.ShowCaption = false;
			this.GroupControl38.Size = new System.Drawing.Size(338, 314);
			this.GroupControl38.TabIndex = 1;
			this.GroupControl38.Text = "GroupControl1";
			// 
			// dtEditDate
			// 
			this.dtEditDate.EditValue = new System.DateTime(2006, 1, 1, 0, 0, 0, 0);
			this.dtEditDate.Location = new System.Drawing.Point(96, 124);
			this.dtEditDate.Name = "dtEditDate";
			// 
			// dtEditDate.Properties
			// 
			this.dtEditDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dtEditDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.dtEditDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dtEditDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
			this.dtEditDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dtEditDate.Properties.Mask.EditMask = "dd/MM/yyyy";
			this.dtEditDate.Size = new System.Drawing.Size(232, 20);
			this.dtEditDate.TabIndex = 36;
			this.dtEditDate.EditValueChanged += new System.EventHandler(this.dtEditDate_EditValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(16, 124);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 18);
			this.label2.TabIndex = 35;
			this.label2.Text = "Date";
			// 
			// dtEdtEndTime
			// 
			this.dtEdtEndTime.EditValue = new System.DateTime(2006, 1, 1, 0, 0, 0, 0);
			this.dtEdtEndTime.Location = new System.Drawing.Point(96, 168);
			this.dtEdtEndTime.Name = "dtEdtEndTime";
			// 
			// dtEdtEndTime.Properties
			// 
			this.dtEdtEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, null)});
			this.dtEdtEndTime.Properties.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm tt";
			this.dtEdtEndTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dtEdtEndTime.Properties.EditFormat.FormatString = "T";
			this.dtEdtEndTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dtEdtEndTime.Properties.Mask.EditMask = "T";
			this.dtEdtEndTime.Size = new System.Drawing.Size(232, 20);
			this.dtEdtEndTime.TabIndex = 34;
			// 
			// dtEdtStartTime
			// 
			this.dtEdtStartTime.EditValue = new System.DateTime(2006, 1, 1, 0, 0, 0, 0);
			this.dtEdtStartTime.Location = new System.Drawing.Point(96, 146);
			this.dtEdtStartTime.Name = "dtEdtStartTime";
			// 
			// dtEdtStartTime.Properties
			// 
			this.dtEdtStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, null)});
			this.dtEdtStartTime.Properties.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm tt";
			this.dtEdtStartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dtEdtStartTime.Properties.EditFormat.FormatString = "T";
			this.dtEdtStartTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dtEdtStartTime.Properties.Mask.EditMask = "T";
			this.dtEdtStartTime.Size = new System.Drawing.Size(232, 20);
			this.dtEdtStartTime.TabIndex = 33;
			// 
			// simpleButton2
			// 
			this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButton2.Location = new System.Drawing.Point(252, 278);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.TabIndex = 32;
			this.simpleButton2.Text = "Cancel";
			// 
			// SimpleButton56
			// 
			this.SimpleButton56.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.SimpleButton56.Location = new System.Drawing.Point(166, 278);
			this.SimpleButton56.Name = "SimpleButton56";
			this.SimpleButton56.TabIndex = 31;
			this.SimpleButton56.Text = "Save";
			this.SimpleButton56.Click += new System.EventHandler(this.SimpleButton56_Click_1);
			// 
			// lkpEdtTherapist
			// 
			this.lkpEdtTherapist.EditValue = "";
			this.lkpEdtTherapist.Location = new System.Drawing.Point(96, 58);
			this.lkpEdtTherapist.Name = "lkpEdtTherapist";
			// 
			// lkpEdtTherapist.Properties
			// 
			this.lkpEdtTherapist.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtTherapist.Size = new System.Drawing.Size(232, 20);
			this.lkpEdtTherapist.TabIndex = 30;
			// 
			// lkpEdtMemberID
			// 
			this.lkpEdtMemberID.EditValue = "";
			this.lkpEdtMemberID.Location = new System.Drawing.Point(96, 14);
			this.lkpEdtMemberID.Name = "lkpEdtMemberID";
			// 
			// lkpEdtMemberID.Properties
			// 
			this.lkpEdtMemberID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtMemberID.Size = new System.Drawing.Size(232, 20);
			this.lkpEdtMemberID.TabIndex = 29;
			this.lkpEdtMemberID.EditValueChanged += new System.EventHandler(this.lkpEdtMemberID_EditValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 18);
			this.label1.TabIndex = 28;
			this.label1.Text = "Member ID";
			// 
			// lkpEdtPackageID
			// 
			this.lkpEdtPackageID.EditValue = "";
			this.lkpEdtPackageID.Location = new System.Drawing.Point(96, 80);
			this.lkpEdtPackageID.Name = "lkpEdtPackageID";
			// 
			// lkpEdtPackageID.Properties
			// 
			this.lkpEdtPackageID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtPackageID.Size = new System.Drawing.Size(232, 20);
			this.lkpEdtPackageID.TabIndex = 27;
			this.lkpEdtPackageID.EditValueChanged += new System.EventHandler(this.lkpEdtPackageID_EditValueChanged);
			// 
			// lkpEdtServiceCode
			// 
			this.lkpEdtServiceCode.EditValue = "";
			this.lkpEdtServiceCode.Location = new System.Drawing.Point(96, 102);
			this.lkpEdtServiceCode.Name = "lkpEdtServiceCode";
			// 
			// lkpEdtServiceCode.Properties
			// 
			this.lkpEdtServiceCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtServiceCode.Size = new System.Drawing.Size(232, 20);
			this.lkpEdtServiceCode.TabIndex = 26;
			// 
			// MemoEditRemark
			// 
			this.MemoEditRemark.EditValue = "Remark Looking to what table?? Masking framework for dateTime no yet do";
			this.MemoEditRemark.Location = new System.Drawing.Point(96, 190);
			this.MemoEditRemark.Name = "MemoEditRemark";
			// 
			// MemoEditRemark.Properties
			// 
			this.MemoEditRemark.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MemoEditRemark.Properties.Appearance.Options.UseFont = true;
			this.MemoEditRemark.Size = new System.Drawing.Size(232, 64);
			this.MemoEditRemark.TabIndex = 24;
			// 
			// Label42
			// 
			this.Label42.AutoSize = true;
			this.Label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label42.Location = new System.Drawing.Point(16, 192);
			this.Label42.Name = "Label42";
			this.Label42.Size = new System.Drawing.Size(60, 18);
			this.Label42.TabIndex = 23;
			this.Label42.Text = "Remarks";
			// 
			// Label36
			// 
			this.Label36.AutoSize = true;
			this.Label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label36.Location = new System.Drawing.Point(16, 168);
			this.Label36.Name = "Label36";
			this.Label36.Size = new System.Drawing.Size(64, 18);
			this.Label36.TabIndex = 21;
			this.Label36.Text = "End Time";
			// 
			// Label31
			// 
			this.Label31.AutoSize = true;
			this.Label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label31.Location = new System.Drawing.Point(16, 146);
			this.Label31.Name = "Label31";
			this.Label31.Size = new System.Drawing.Size(69, 18);
			this.Label31.TabIndex = 19;
			this.Label31.Text = "Start Time";
			// 
			// Label33
			// 
			this.Label33.AutoSize = true;
			this.Label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label33.Location = new System.Drawing.Point(16, 102);
			this.Label33.Name = "Label33";
			this.Label33.Size = new System.Drawing.Size(51, 18);
			this.Label33.TabIndex = 17;
			this.Label33.Text = "Service";
			// 
			// Label34
			// 
			this.Label34.AutoSize = true;
			this.Label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label34.Location = new System.Drawing.Point(16, 80);
			this.Label34.Name = "Label34";
			this.Label34.Size = new System.Drawing.Size(76, 18);
			this.Label34.TabIndex = 15;
			this.Label34.Text = "Package ID";
			// 
			// Label35
			// 
			this.Label35.AutoSize = true;
			this.Label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label35.Location = new System.Drawing.Point(16, 58);
			this.Label35.Name = "Label35";
			this.Label35.Size = new System.Drawing.Size(63, 18);
			this.Label35.TabIndex = 13;
			this.Label35.Text = "Therapist";
			// 
			// lkpEdtBranchCode
			// 
			this.lkpEdtBranchCode.EditValue = "";
			this.lkpEdtBranchCode.Location = new System.Drawing.Point(96, 36);
			this.lkpEdtBranchCode.Name = "lkpEdtBranchCode";
			// 
			// lkpEdtBranchCode.Properties
			// 
			this.lkpEdtBranchCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtBranchCode.Properties.Enabled = false;
			this.lkpEdtBranchCode.Size = new System.Drawing.Size(232, 20);
			this.lkpEdtBranchCode.TabIndex = 59;
			this.lkpEdtBranchCode.EditValueChanged += new System.EventHandler(this.lkpEdtBranchCode_EditValueChanged);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(16, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 20);
			this.label3.TabIndex = 58;
			this.label3.Text = "Branch";
			// 
			// FormNewSpaBooking
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(338, 314);
			this.Controls.Add(this.GroupControl38);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormNewSpaBooking";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New UOB Spa Booking";
			((System.ComponentModel.ISupportInitialize)(this.GroupControl38)).EndInit();
			this.GroupControl38.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dtEditDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEdtEndTime.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEdtStartTime.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtTherapist.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtMemberID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtPackageID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtServiceCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MemoEditRemark.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtBranchCode.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void lkpEdtMemberID_EditValueChanged(object sender, System.EventArgs e)
		{
			if (myMemberPackageLookupBuilder != null)
				myMemberPackageLookupBuilder.Refresh(lkpEdtMemberID.EditValue.ToString());
		}

		private void myDataTable_ColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
			if (System.String.Compare(e.Column.ColumnName, "dtStartTime", true) == 0 )
			{
				try
				{
					DateTime startTime = ACMS.Convert.ToDateTime(e.Row["dtStartTime"]);
					e.Row["dtEndTime"] = startTime.AddMinutes(15);
					e.Row.EndEdit();
				}
				catch(InvalidCastException)
				{
					MessageBox.Show("Invalid Start Time");
				}
			}
		}

		private void SimpleButton56_Click_1(object sender, System.EventArgs e)
		{
			if (lkpEdtMemberID.Text == "") 
			{
				MessageBox.Show(this, "Please select a member id.");
				this.DialogResult = DialogResult.None;
				return;
			}
			else if (lkpEdtTherapist.Text == "")
			{
				MessageBox.Show(this, "Please select a therapist.");
				this.DialogResult = DialogResult.None;
				return;
			}
			else if(lkpEdtPackageID.Text == "") 
			{
				MessageBox.Show(this, "Please select a package ID.");
				this.DialogResult = DialogResult.None;
				return;
			}
			else if (lkpEdtServiceCode.Text == "")
			{
				MessageBox.Show(this, "Please select a service code.");
				this.DialogResult = DialogResult.None;
				return;
			}
//			else if (dtEdtStartTime.DateTime < DateTime.Now.m)
//			{
//				MessageBox.Show(this, "Please select a valid date or time.");
//				return;
//			}
//			else if (dtEdtStartTime.DateTime < dtEdtEndTime.DateTime)
//			{
//				MessageBox.Show(this, "Please select a valid date or time.");
//				return;
//			}
			
			this.BindingContext[myDataTable].EndCurrentEdit();

			try
			{
				mySpaBooking.Save(myDataTable, true);
				this.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				this.DialogResult = DialogResult.None;
				return;
			}
		}

		private void lkpEdtPackageID_EditValueChanged(object sender, System.EventArgs e)
		{
			if (myServiceCodeLookupBuilder != null)
				myServiceCodeLookupBuilder.Refresh(ACMS.Convert.ToInt32(lkpEdtPackageID.EditValue));
		}

		private void dtEditDate_EditValueChanged(object sender, System.EventArgs e)
		{	
			
			DateTime dtstart = new DateTime(dtEditDate.DateTime.Year, dtEditDate.DateTime.Month, dtEditDate.DateTime.Day, 
				dtEdtStartTime.DateTime.Hour, dtEdtStartTime.DateTime.Minute, dtEdtStartTime.DateTime.Second);

			DateTime dtend = new DateTime(dtEditDate.DateTime.Year, dtEditDate.DateTime.Month, dtEditDate.DateTime.Day, 
				dtEdtEndTime.DateTime.Hour, dtEdtEndTime.DateTime.Minute, dtEdtEndTime.DateTime.Second);

			dtEdtEndTime.DateTime = dtend;
			dtEdtStartTime.DateTime = dtstart;
		}

		private void lkpEdtBranchCode_EditValueChanged(object sender, System.EventArgs e)
		{
			if (myEmployeeIDLookupBuilder != null && lkpEdtBranchCode.EditValue != null)
			{
				myEmployeeIDLookupBuilder.Refresh(lkpEdtBranchCode.EditValue.ToString());
			}
		}
	}
}
