using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ACMS
{
	/// <summary>
	/// Summary description for FormNewExtension.
	/// </summary>
	public class FormUpdateMemberPackageExtension : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;

		private int myExtensionID;
		private ACMSLogic.MemberPackage myMemberPackage;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtLeaveType;
		private DataTable myDataTable;
		private DevExpress.XtraEditors.DateEdit dtEdtLeaveStartDate;
		private DevExpress.XtraEditors.DateEdit dtEdtLeaveEndDate;
		private DevExpress.XtraEditors.DateEdit dtEdtNewExpiry;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormUpdateMemberPackageExtension(ACMSLogic.MemberPackage memberPackage, int nExtensionID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myExtensionID= nExtensionID;
			myMemberPackage = memberPackage;
			label6.Text = "Update Extension ID : " + myExtensionID; 

			Init();
		}

		private void Init()
		{
			dtEdtLeaveEndDate.DateTime = DateTime.Now.Date;
			dtEdtLeaveStartDate.DateTime = DateTime.Now.Date;
			dtEdtNewExpiry.DateTime = DateTime.Now.Date;
			InitLookupEdit();
			BindData();
		}

		public DataTable PackageExtensionTable
		{
			get { return myDataTable; }
		}

		public DateTime NewExpiryDate
		{
			get { return dtEdtNewExpiry.DateTime; }
		}

		public int NLeaveTypeID
		{
			get
			{
				if (lkpEdtLeaveType.EditValue == null)
					return -1;

				return ACMS.Convert.ToInt32(lkpEdtLeaveType.EditValue);
			}
		}

		private void InitLookupEdit()
		{
			new ACMS.XtraUtils.LookupEditBuilder.MemberPackageLeaveTypeLookupEditBuilder(lkpEdtLeaveType.Properties);
		}

		private void BindData()
		{
			myDataTable = myMemberPackage.GetExtensionHistoryBaseExtensionID(myExtensionID);

			lkpEdtLeaveType.DataBindings.Clear();
			lkpEdtLeaveType.DataBindings.Add("EditValue", myDataTable, "nReasonID");
			dtEdtLeaveEndDate.DataBindings.Clear();
			dtEdtLeaveEndDate.DataBindings.Add("EditValue", myDataTable, "dtEndDate");
			dtEdtLeaveStartDate.DataBindings.Clear();
			dtEdtLeaveStartDate.DataBindings.Add("EditValue", myDataTable, "dtStartDate");
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
		this.label3 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.lkpEdtLeaveType = new DevExpress.XtraEditors.LookUpEdit();
		this.dtEdtLeaveStartDate = new DevExpress.XtraEditors.DateEdit();
		this.dtEdtLeaveEndDate = new DevExpress.XtraEditors.DateEdit();
		this.dtEdtNewExpiry = new DevExpress.XtraEditors.DateEdit();
		this.label6 = new System.Windows.Forms.Label();
		this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
		((System.ComponentModel.ISupportInitialize)(this.lkpEdtLeaveType.Properties)).BeginInit();
		((System.ComponentModel.ISupportInitialize)(this.dtEdtLeaveStartDate.Properties)).BeginInit();
		((System.ComponentModel.ISupportInitialize)(this.dtEdtLeaveEndDate.Properties)).BeginInit();
		((System.ComponentModel.ISupportInitialize)(this.dtEdtNewExpiry.Properties)).BeginInit();
		this.SuspendLayout();
		// 
		// label1
		// 
		this.label1.Location = new System.Drawing.Point(10, 32);
		this.label1.Name = "label1";
		this.label1.TabIndex = 0;
		this.label1.Text = "Leave Type";
		// 
		// label2
		// 
		this.label2.Location = new System.Drawing.Point(10, 64);
		this.label2.Name = "label2";
		this.label2.TabIndex = 1;
		this.label2.Text = "Leave Start Date";
		// 
		// label3
		// 
		this.label3.Location = new System.Drawing.Point(10, 96);
		this.label3.Name = "label3";
		this.label3.TabIndex = 2;
		this.label3.Text = "Leave End Date";
		// 
		// label4
		// 
		this.label4.Location = new System.Drawing.Point(10, 128);
		this.label4.Name = "label4";
		this.label4.TabIndex = 3;
		this.label4.Text = "New Expiry";
		// 
		// lkpEdtLeaveType
		// 
		this.lkpEdtLeaveType.EditValue = "";
		this.lkpEdtLeaveType.Location = new System.Drawing.Point(118, 32);
		this.lkpEdtLeaveType.Name = "lkpEdtLeaveType";
		// 
		// lkpEdtLeaveType.Properties
		// 
		this.lkpEdtLeaveType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
		this.lkpEdtLeaveType.Size = new System.Drawing.Size(216, 20);
		this.lkpEdtLeaveType.TabIndex = 6;
		this.lkpEdtLeaveType.EditValueChanged += new System.EventHandler(this.lkpEdtLeaveType_EditValueChanged);
		// 
		// dtEdtLeaveStartDate
		// 
		this.dtEdtLeaveStartDate.EditValue = new System.DateTime(2005, 11, 15, 0, 0, 0, 0);
		this.dtEdtLeaveStartDate.Location = new System.Drawing.Point(118, 64);
		this.dtEdtLeaveStartDate.Name = "dtEdtLeaveStartDate";
		// 
		// dtEdtLeaveStartDate.Properties
		// 
		this.dtEdtLeaveStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
		this.dtEdtLeaveStartDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
		this.dtEdtLeaveStartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.dtEdtLeaveStartDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
		this.dtEdtLeaveStartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.dtEdtLeaveStartDate.Size = new System.Drawing.Size(172, 20);
		this.dtEdtLeaveStartDate.TabIndex = 7;
		// 
		// dtEdtLeaveEndDate
		// 
		this.dtEdtLeaveEndDate.EditValue = new System.DateTime(2005, 11, 15, 0, 0, 0, 0);
		this.dtEdtLeaveEndDate.Location = new System.Drawing.Point(118, 96);
		this.dtEdtLeaveEndDate.Name = "dtEdtLeaveEndDate";
		// 
		// dtEdtLeaveEndDate.Properties
		// 
		this.dtEdtLeaveEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
		this.dtEdtLeaveEndDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
		this.dtEdtLeaveEndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.dtEdtLeaveEndDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
		this.dtEdtLeaveEndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.dtEdtLeaveEndDate.Size = new System.Drawing.Size(172, 20);
		this.dtEdtLeaveEndDate.TabIndex = 8;
		// 
		// dtEdtNewExpiry
		// 
		this.dtEdtNewExpiry.EditValue = new System.DateTime(2005, 11, 15, 0, 0, 0, 0);
		this.dtEdtNewExpiry.Location = new System.Drawing.Point(118, 128);
		this.dtEdtNewExpiry.Name = "dtEdtNewExpiry";
		// 
		// dtEdtNewExpiry.Properties
		// 
		this.dtEdtNewExpiry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
		this.dtEdtNewExpiry.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
		this.dtEdtNewExpiry.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.dtEdtNewExpiry.Properties.EditFormat.FormatString = "dd/MM/yyyy";
		this.dtEdtNewExpiry.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.dtEdtNewExpiry.Size = new System.Drawing.Size(172, 20);
		this.dtEdtNewExpiry.TabIndex = 9;
		// 
		// label6
		// 
		this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
		this.label6.Location = new System.Drawing.Point(10, 4);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(384, 20);
		this.label6.TabIndex = 49;
		this.label6.Text = "label6";
		// 
		// simpleButtonCancel
		// 
		this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButtonCancel.Location = new System.Drawing.Point(316, 160);
		this.simpleButtonCancel.Name = "simpleButtonCancel";
		this.simpleButtonCancel.TabIndex = 51;
		this.simpleButtonCancel.Text = "Cancel";
		// 
		// simpleButtonOK
		// 
		this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.simpleButtonOK.Location = new System.Drawing.Point(212, 160);
		this.simpleButtonOK.Name = "simpleButtonOK";
		this.simpleButtonOK.TabIndex = 50;
		this.simpleButtonOK.Text = "OK";
		this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
		// 
		// FormUpdateMemberPackageExtension
		// 
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(402, 200);
		this.Controls.Add(this.simpleButtonCancel);
		this.Controls.Add(this.simpleButtonOK);
		this.Controls.Add(this.label6);
		this.Controls.Add(this.dtEdtNewExpiry);
		this.Controls.Add(this.dtEdtLeaveEndDate);
		this.Controls.Add(this.dtEdtLeaveStartDate);
		this.Controls.Add(this.lkpEdtLeaveType);
		this.Controls.Add(this.label4);
		this.Controls.Add(this.label3);
		this.Controls.Add(this.label2);
		this.Controls.Add(this.label1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "FormUpdateMemberPackageExtension";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		((System.ComponentModel.ISupportInitialize)(this.lkpEdtLeaveType.Properties)).EndInit();
		((System.ComponentModel.ISupportInitialize)(this.dtEdtLeaveStartDate.Properties)).EndInit();
		((System.ComponentModel.ISupportInitialize)(this.dtEdtLeaveEndDate.Properties)).EndInit();
		((System.ComponentModel.ISupportInitialize)(this.dtEdtNewExpiry.Properties)).EndInit();
		this.ResumeLayout(false);

	}
		#endregion

		private void lkpEdtLeaveType_EditValueChanged(object sender, System.EventArgs e)
		{
			if (ACMS.Convert.ToInt32(lkpEdtLeaveType.EditValue) == 0)
			{
				dtEdtNewExpiry.Enabled = true;
			}
			else
			{
				dtEdtNewExpiry.Enabled = false;
			}
		}

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
			if (lkpEdtLeaveType.Text.Length == 0)
			{
				MessageBox.Show(this, "Please select a Leave Type.");
				this.DialogResult = DialogResult.None;
				return;
			}

			
			if (lkpEdtLeaveType.Text != "0")
			{
				if (DateTime.Compare(dtEdtLeaveStartDate.DateTime.Date, dtEdtLeaveEndDate.DateTime.Date) > 0 ||
					DateTime.Compare(dtEdtLeaveStartDate.DateTime.Date, dtEdtLeaveEndDate.DateTime.Date) == 0)
				//if (dtEdtLeaveStartDate.DateTime.Date >= dtEdtLeaveEndDate.DateTime.Date)
				{
					MessageBox.Show(this, "Start Date must earlier than end date");
					this.DialogResult = DialogResult.None;
					return;
				}
			}

			this.BindingContext[myDataTable].EndCurrentEdit();
		}
	}
}
