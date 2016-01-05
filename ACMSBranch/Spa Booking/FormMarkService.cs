using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ACMS
{
	/// <summary>
	/// Summary description for FormMarkService.
	/// </summary>
	public class FormMarkService : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.DateEdit dtEditDate;
		internal System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.DateEdit dtEdtStartTime;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtTherapist;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtPackageID;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtServiceCode;
		internal DevExpress.XtraEditors.MemoEdit MemoEditRemark;
		internal System.Windows.Forms.Label Label42;
		internal System.Windows.Forms.Label Label31;
		internal System.Windows.Forms.Label Label33;
		internal System.Windows.Forms.Label Label34;
		internal System.Windows.Forms.Label Label35;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private DevExpress.XtraEditors.SimpleButton SimpleButton56;
		private ACMSLogic.SpaBooking mySpaBooking;
		private int myServiceSessionID;
		private DataTable myDataTable;
		private string myMembershipID;
		private string myServiceSessionBranchCode;
		private DevExpress.XtraEditors.DateEdit dtEdtEndTime;
		internal System.Windows.Forms.Label Label36;
		internal System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		private ACMS.XtraUtils.LookupEditBuilder.TherapistForCommisionLookupEditBuilder myTherapistLookupEditBuilder;
		private ACMS.XtraUtils.LookupEditBuilder.ServiceCodeLookupEditBuilder2 myServiceCodeLookupEditBuilder;
		private ACMS.ucMemberID ucMemberID1;
		//private ACMS.XtraUtils.LookupEditBuilder.MemberIDLookupEditBuilder2 myMemberIDLookupEditBuilder;
		
		private ACMS.XtraUtils.LookupEditBuilder.MemberPackageLookupEditBuilder2 myMemberPackageIDLookupEditBuilder;
		
		public FormMarkService(ACMSLogic.SpaBooking spaBooking, int nServiceSessionID, 
			string strMembershipID, string serviceSessionBranchCode)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myServiceSessionBranchCode = serviceSessionBranchCode;
			myMembershipID = strMembershipID;
			mySpaBooking = spaBooking;
			ucMemberID1.StrBranchCode = ACMSLogic.User.BranchCode;
			ucMemberID1.EditValueChanged += new ACMSLogic.Common.EditValueChangedDelegate(UcMemberEditValueChanged);
			myServiceSessionID = nServiceSessionID;
			InitLookupEdit();
			BindData();
			
		}

		private void UcMemberEditValueChanged(string strMembershipID)
		{
			myMemberPackageIDLookupEditBuilder.Refresh(strMembershipID);

			if (lkpEdtPackageID.Text.Length == 0)
			{
				myServiceCodeLookupEditBuilder.Refresh(-1);
			}
		}

		private void BindData()
		{
			myDataTable = mySpaBooking.GetServiceSession(myServiceSessionID);

			myDataTable.Rows[0]["nStatusID"] = 5;
			myDataTable.Rows[0]["nMarkedByID"] = ACMSLogic.User.EmployeeID;
			myDataTable.Rows[0]["nEmployeeID"] = ACMSLogic.User.EmployeeID;
			myDataTable.Rows[0]["dtLastEditDate"] = DateTime.Now;
 
			lkpEdtTherapist.DataBindings.Clear();
			dtEdtEndTime.DataBindings.Clear();
			lkpEdtPackageID.DataBindings.Clear();
			dtEdtStartTime.DataBindings.Clear();
			lkpEdtServiceCode.DataBindings.Clear();
			MemoEditRemark.DataBindings.Clear();
			dtEditDate.DataBindings.Clear();
			ucMemberID1.DataBindings.Clear();
			ucMemberID1.DataBindings.Add("EditValue", myDataTable, "strMembershipID");
			dtEditDate.DataBindings.Add("EditValue", myDataTable, "dtDate");
			lkpEdtTherapist.DataBindings.Add("EditValue", myDataTable, "nServiceEmployeeID");
			dtEdtEndTime.DataBindings.Add("EditValue", myDataTable, "dtEndTime");
			lkpEdtPackageID.DataBindings.Add("EditValue", myDataTable, "nPackageID");
			dtEdtStartTime.DataBindings.Add("EditValue", myDataTable, "dtStartTime");
			lkpEdtServiceCode.DataBindings.Add("EditValue", myDataTable, "strServiceCode");
			MemoEditRemark.DataBindings.Add("EditValue", myDataTable, "strRemarks");
		}
		
		private void InitLookupEdit()
		{
			myTherapistLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.TherapistForCommisionLookupEditBuilder(lkpEdtTherapist.Properties, myServiceSessionBranchCode);
			//myBranchCodeLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.BranchCodeLookupEditBuilder2(lkpEdtBranchCode.Properties);
			myServiceCodeLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.ServiceCodeLookupEditBuilder2(lkpEdtServiceCode.Properties, ""); 
			myMemberPackageIDLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.MemberPackageLookupEditBuilder2(lkpEdtPackageID.Properties, true, myMembershipID);
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
			this.dtEditDate = new DevExpress.XtraEditors.DateEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.dtEdtStartTime = new DevExpress.XtraEditors.DateEdit();
			this.lkpEdtTherapist = new DevExpress.XtraEditors.LookUpEdit();
			this.lkpEdtPackageID = new DevExpress.XtraEditors.LookUpEdit();
			this.lkpEdtServiceCode = new DevExpress.XtraEditors.LookUpEdit();
			this.MemoEditRemark = new DevExpress.XtraEditors.MemoEdit();
			this.Label42 = new System.Windows.Forms.Label();
			this.Label31 = new System.Windows.Forms.Label();
			this.Label33 = new System.Windows.Forms.Label();
			this.Label34 = new System.Windows.Forms.Label();
			this.Label35 = new System.Windows.Forms.Label();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			this.SimpleButton56 = new DevExpress.XtraEditors.SimpleButton();
			this.dtEdtEndTime = new DevExpress.XtraEditors.DateEdit();
			this.Label36 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.ucMemberID1 = new ACMS.ucMemberID();
			((System.ComponentModel.ISupportInitialize)(this.dtEditDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEdtStartTime.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtTherapist.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtPackageID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtServiceCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MemoEditRemark.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEdtEndTime.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// dtEditDate
			// 
			this.dtEditDate.EditValue = new System.DateTime(2006, 1, 1, 0, 0, 0, 0);
			this.dtEditDate.Location = new System.Drawing.Point(96, 98);
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
			this.dtEditDate.Properties.ReadOnly = true;
			this.dtEditDate.Size = new System.Drawing.Size(232, 20);
			this.dtEditDate.TabIndex = 52;
			this.dtEditDate.EditValueChanged += new System.EventHandler(this.dtEditDate_EditValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(16, 98);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 18);
			this.label2.TabIndex = 51;
			this.label2.Text = "Date";
			// 
			// dtEdtStartTime
			// 
			this.dtEdtStartTime.EditValue = new System.DateTime(2006, 1, 1, 0, 0, 0, 0);
			this.dtEdtStartTime.Location = new System.Drawing.Point(96, 120);
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
			this.dtEdtStartTime.TabIndex = 49;
			// 
			// lkpEdtTherapist
			// 
			this.lkpEdtTherapist.EditValue = "";
			this.lkpEdtTherapist.Location = new System.Drawing.Point(96, 32);
			this.lkpEdtTherapist.Name = "lkpEdtTherapist";
			// 
			// lkpEdtTherapist.Properties
			// 
			this.lkpEdtTherapist.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtTherapist.Properties.ReadOnly = true;
			this.lkpEdtTherapist.Size = new System.Drawing.Size(232, 20);
			this.lkpEdtTherapist.TabIndex = 48;
			// 
			// lkpEdtPackageID
			// 
			this.lkpEdtPackageID.EditValue = "";
			this.lkpEdtPackageID.Location = new System.Drawing.Point(96, 54);
			this.lkpEdtPackageID.Name = "lkpEdtPackageID";
			// 
			// lkpEdtPackageID.Properties
			// 
			this.lkpEdtPackageID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtPackageID.Properties.NullText = "";
			this.lkpEdtPackageID.Size = new System.Drawing.Size(232, 20);
			this.lkpEdtPackageID.TabIndex = 45;
			this.lkpEdtPackageID.EditValueChanged += new System.EventHandler(this.lkpEdtPackageID_EditValueChanged);
			// 
			// lkpEdtServiceCode
			// 
			this.lkpEdtServiceCode.EditValue = "";
			this.lkpEdtServiceCode.Location = new System.Drawing.Point(96, 76);
			this.lkpEdtServiceCode.Name = "lkpEdtServiceCode";
			// 
			// lkpEdtServiceCode.Properties
			// 
			this.lkpEdtServiceCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtServiceCode.Size = new System.Drawing.Size(232, 20);
			this.lkpEdtServiceCode.TabIndex = 44;
			// 
			// MemoEditRemark
			// 
			this.MemoEditRemark.EditValue = "";
			this.MemoEditRemark.Location = new System.Drawing.Point(96, 168);
			this.MemoEditRemark.Name = "MemoEditRemark";
			// 
			// MemoEditRemark.Properties
			// 
			this.MemoEditRemark.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MemoEditRemark.Properties.Appearance.Options.UseFont = true;
			this.MemoEditRemark.Properties.ReadOnly = true;
			this.MemoEditRemark.Size = new System.Drawing.Size(232, 64);
			this.MemoEditRemark.TabIndex = 43;
			// 
			// Label42
			// 
			this.Label42.AutoSize = true;
			this.Label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label42.Location = new System.Drawing.Point(16, 170);
			this.Label42.Name = "Label42";
			this.Label42.Size = new System.Drawing.Size(60, 18);
			this.Label42.TabIndex = 42;
			this.Label42.Text = "Remarks";
			// 
			// Label31
			// 
			this.Label31.AutoSize = true;
			this.Label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label31.Location = new System.Drawing.Point(16, 120);
			this.Label31.Name = "Label31";
			this.Label31.Size = new System.Drawing.Size(69, 18);
			this.Label31.TabIndex = 40;
			this.Label31.Text = "Start Time";
			// 
			// Label33
			// 
			this.Label33.AutoSize = true;
			this.Label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label33.Location = new System.Drawing.Point(16, 76);
			this.Label33.Name = "Label33";
			this.Label33.Size = new System.Drawing.Size(51, 18);
			this.Label33.TabIndex = 39;
			this.Label33.Text = "Service";
			// 
			// Label34
			// 
			this.Label34.AutoSize = true;
			this.Label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label34.Location = new System.Drawing.Point(16, 54);
			this.Label34.Name = "Label34";
			this.Label34.Size = new System.Drawing.Size(76, 18);
			this.Label34.TabIndex = 38;
			this.Label34.Text = "Package ID";
			// 
			// Label35
			// 
			this.Label35.AutoSize = true;
			this.Label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label35.Location = new System.Drawing.Point(16, 32);
			this.Label35.Name = "Label35";
			this.Label35.Size = new System.Drawing.Size(63, 18);
			this.Label35.TabIndex = 37;
			this.Label35.Text = "Therapist";
			// 
			// simpleButton2
			// 
			this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButton2.Location = new System.Drawing.Point(252, 244);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.TabIndex = 54;
			this.simpleButton2.Text = "Cancel";
			// 
			// SimpleButton56
			// 
			this.SimpleButton56.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.SimpleButton56.Location = new System.Drawing.Point(164, 244);
			this.SimpleButton56.Name = "SimpleButton56";
			this.SimpleButton56.TabIndex = 53;
			this.SimpleButton56.Text = "Save";
			this.SimpleButton56.Click += new System.EventHandler(this.SimpleButton56_Click);
			// 
			// dtEdtEndTime
			// 
			this.dtEdtEndTime.EditValue = new System.DateTime(2006, 1, 1, 0, 0, 0, 0);
			this.dtEdtEndTime.Location = new System.Drawing.Point(96, 144);
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
			this.dtEdtEndTime.TabIndex = 56;
			// 
			// Label36
			// 
			this.Label36.AutoSize = true;
			this.Label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label36.Location = new System.Drawing.Point(16, 144);
			this.Label36.Name = "Label36";
			this.Label36.Size = new System.Drawing.Size(64, 18);
			this.Label36.TabIndex = 55;
			this.Label36.Text = "End Time";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 18);
			this.label1.TabIndex = 58;
			this.label1.Text = "Member ID";
			// 
			// ucMemberID1
			// 
			this.ucMemberID1.EditValue = "";
			this.ucMemberID1.EditValueChanged = null;
			this.ucMemberID1.Location = new System.Drawing.Point(98, 8);
			this.ucMemberID1.Name = "ucMemberID1";
			this.ucMemberID1.Size = new System.Drawing.Size(182, 20);
			this.ucMemberID1.StrBranchCode = null;
			this.ucMemberID1.TabIndex = 59;
			// 
			// FormMarkService
			// 
			this.AcceptButton = this.SimpleButton56;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.simpleButton2;
			this.ClientSize = new System.Drawing.Size(344, 286);
			this.Controls.Add(this.ucMemberID1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dtEdtEndTime);
			this.Controls.Add(this.Label36);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.Label42);
			this.Controls.Add(this.Label31);
			this.Controls.Add(this.Label33);
			this.Controls.Add(this.Label34);
			this.Controls.Add(this.Label35);
			this.Controls.Add(this.simpleButton2);
			this.Controls.Add(this.SimpleButton56);
			this.Controls.Add(this.dtEditDate);
			this.Controls.Add(this.dtEdtStartTime);
			this.Controls.Add(this.lkpEdtTherapist);
			this.Controls.Add(this.lkpEdtPackageID);
			this.Controls.Add(this.lkpEdtServiceCode);
			this.Controls.Add(this.MemoEditRemark);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormMarkService";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Mark Service";
			((System.ComponentModel.ISupportInitialize)(this.dtEditDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEdtStartTime.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtTherapist.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtPackageID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtServiceCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MemoEditRemark.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEdtEndTime.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void SimpleButton56_Click(object sender, System.EventArgs e)
		{
			this.BindingContext[myDataTable].EndCurrentEdit();
			
			if (ucMemberID1.EditValue.ToString() == "") 
			{
				MessageBox.Show(this, "Please key in member id.");
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
			else if (dtEdtStartTime.DateTime >= dtEdtEndTime.DateTime)
			{
				MessageBox.Show(this, "End Time must later than start time.");
				this.DialogResult = DialogResult.None;
				return;
			}

			DataRow masterRow = myDataTable.Rows[0];
			int nPackageID = ACMS.Convert.ToInt32(masterRow["nPackageID"]);
			string strServiceCode = masterRow["strServiceCode"].ToString();
			int nServiceEmployeeID = ACMS.Convert.ToInt32(masterRow["nServiceEmployeeID"]);
			DateTime dtDate = ACMS.Convert.ToDateTime(masterRow["dtDate"]);
			DateTime dtStartTime = ACMS.Convert.ToDateTime(masterRow["dtStartTime"]);
			DateTime dtEndTime = ACMS.Convert.ToDateTime(masterRow["dtEndTime"]);
			string strBranchCode = masterRow["strBranchCode"].ToString();
			string remark = masterRow["strRemarks"].ToString();
			try
			{
				mySpaBooking.MarkService(myServiceSessionID, dtDate, dtStartTime, dtEndTime, 
					strBranchCode, nPackageID, strServiceCode, nServiceEmployeeID, remark);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message);
			}
		}

		private void lkpEdtPackageID_EditValueChanged(object sender, System.EventArgs e)
		{
			if (lkpEdtPackageID.EditValue != null && myServiceCodeLookupEditBuilder != null)
			{
				myServiceCodeLookupEditBuilder.Refresh(ACMS.Convert.ToInt32(lkpEdtPackageID.EditValue));
			}
		}

		private void dtEditDate_EditValueChanged(object sender, System.EventArgs e)
		{
			
			DateTime dtstart = new DateTime(dtEditDate.DateTime.Year, dtEditDate.DateTime.Month, dtEditDate.DateTime.Day, 
				dtEdtStartTime.DateTime.Hour, dtEdtStartTime.DateTime.Minute, dtEdtStartTime.DateTime.Second);

			DateTime dtend = new DateTime(dtEditDate.DateTime.Year, dtEditDate.DateTime.Month, dtEditDate.DateTime.Day, 
				dtEdtEndTime.DateTime.Hour, dtEdtEndTime.DateTime.Minute, dtEdtEndTime.DateTime.Second);
			
			dtEdtStartTime.DateTime = dtstart;

			dtEdtEndTime.DateTime = dtend;
		}

	}
}
