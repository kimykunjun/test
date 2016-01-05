using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ACMS
{
	/// <summary>
	/// Summary description for FormUpdateServiceSession.
	/// </summary>
	public class FormUpdateServiceSessionPT : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtEmployeeID;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtBranchCode;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private DevExpress.XtraEditors.DateEdit dtEdtStartTime;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtPackageID;
		private DevExpress.XtraEditors.DateEdit dtEditDate;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private ACMS.XtraUtils.LookupEditBuilder.PersonalTrainerLookupEditBuilder myPersonalTrainerLookupEditBuilder;
		private ACMS.XtraUtils.LookupEditBuilder.BranchCodeLookupEditBuilder2 myBranchCodeLookupEditBuilder;
		private ACMS.XtraUtils.LookupEditBuilder.MemberPackageIDLookupEditBuilder myMemberPackageIDLookupEditBuilder;
		private string myMembershipID;
		//private string myServiceCode;

		public FormUpdateServiceSessionPT(string strMembershipID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myMembershipID = strMembershipID;
			Init();
		}

		private void Init()
		{
			myPersonalTrainerLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.PersonalTrainerLookupEditBuilder(lkpEdtEmployeeID.Properties, "");
			myBranchCodeLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.BranchCodeLookupEditBuilder2(lkpEdtBranchCode.Properties);
			myMemberPackageIDLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.MemberPackageIDLookupEditBuilder(lkpEdtPackageID.Properties, myMembershipID, true, DateTime.Now);

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
			this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
			this.label4 = new System.Windows.Forms.Label();
			this.lkpEdtEmployeeID = new DevExpress.XtraEditors.LookUpEdit();
			this.lkpEdtBranchCode = new DevExpress.XtraEditors.LookUpEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lkpEdtPackageID = new DevExpress.XtraEditors.LookUpEdit();
			this.dtEdtStartTime = new DevExpress.XtraEditors.DateEdit();
			this.label3 = new System.Windows.Forms.Label();
			this.dtEditDate = new DevExpress.XtraEditors.DateEdit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtEmployeeID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtBranchCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtPackageID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEdtStartTime.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEditDate.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// simpleButtonCancel
			// 
			this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButtonCancel.Location = new System.Drawing.Point(188, 156);
			this.simpleButtonCancel.Name = "simpleButtonCancel";
			this.simpleButtonCancel.TabIndex = 53;
			this.simpleButtonCancel.Text = "Cancel";
			// 
			// simpleButtonOK
			// 
			this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButtonOK.Location = new System.Drawing.Point(98, 156);
			this.simpleButtonOK.Name = "simpleButtonOK";
			this.simpleButtonOK.TabIndex = 52;
			this.simpleButtonOK.Text = "OK";
			this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(8, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(93, 23);
			this.label4.TabIndex = 60;
			this.label4.Text = "Personal Trainer";
			// 
			// lkpEdtEmployeeID
			// 
			this.lkpEdtEmployeeID.EditValue = "";
			this.lkpEdtEmployeeID.Location = new System.Drawing.Point(124, 114);
			this.lkpEdtEmployeeID.Name = "lkpEdtEmployeeID";
			// 
			// lkpEdtEmployeeID.Properties
			// 
			this.lkpEdtEmployeeID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtEmployeeID.Size = new System.Drawing.Size(202, 20);
			this.lkpEdtEmployeeID.TabIndex = 59;
			this.lkpEdtEmployeeID.EditValueChanged += new System.EventHandler(this.lkpEdtEmployeeID_EditValueChanged);
			// 
			// lkpEdtBranchCode
			// 
			this.lkpEdtBranchCode.EditValue = "";
			this.lkpEdtBranchCode.Location = new System.Drawing.Point(124, 34);
			this.lkpEdtBranchCode.Name = "lkpEdtBranchCode";
			// 
			// lkpEdtBranchCode.Properties
			// 
			this.lkpEdtBranchCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtBranchCode.Size = new System.Drawing.Size(202, 20);
			this.lkpEdtBranchCode.TabIndex = 57;
			this.lkpEdtBranchCode.EditValueChanged += new System.EventHandler(this.lkpEdtBranchCode_EditValueChanged);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 34);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 55;
			this.label2.Text = "Branch";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 60);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 54;
			this.label1.Text = "Date";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(8, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 23);
			this.label5.TabIndex = 62;
			this.label5.Text = "Package ID";
			// 
			// lkpEdtPackageID
			// 
			this.lkpEdtPackageID.EditValue = "";
			this.lkpEdtPackageID.Location = new System.Drawing.Point(124, 8);
			this.lkpEdtPackageID.Name = "lkpEdtPackageID";
			// 
			// lkpEdtPackageID.Properties
			// 
			this.lkpEdtPackageID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtPackageID.Size = new System.Drawing.Size(202, 20);
			this.lkpEdtPackageID.TabIndex = 63;
			// 
			// dtEdtStartTime
			// 
			this.dtEdtStartTime.EditValue = new System.DateTime(2006, 1, 1, 0, 0, 0, 0);
			this.dtEdtStartTime.Location = new System.Drawing.Point(124, 88);
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
			this.dtEdtStartTime.Size = new System.Drawing.Size(202, 20);
			this.dtEdtStartTime.TabIndex = 65;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(8, 86);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(95, 23);
			this.label3.TabIndex = 64;
			this.label3.Text = "Session Time";
			// 
			// dtEditDate
			// 
			this.dtEditDate.EditValue = new System.DateTime(2005, 11, 23, 0, 0, 0, 0);
			this.dtEditDate.Location = new System.Drawing.Point(124, 60);
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
			this.dtEditDate.Size = new System.Drawing.Size(202, 20);
			this.dtEditDate.TabIndex = 66;
			this.dtEditDate.EditValueChanged += new System.EventHandler(this.dtEditDate_EditValueChanged);
			// 
			// FormUpdateServiceSessionPT
			// 
			this.AcceptButton = this.simpleButtonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.simpleButtonCancel;
			this.ClientSize = new System.Drawing.Size(334, 192);
			this.Controls.Add(this.dtEditDate);
			this.Controls.Add(this.dtEdtStartTime);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lkpEdtPackageID);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lkpEdtEmployeeID);
			this.Controls.Add(this.lkpEdtBranchCode);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.simpleButtonCancel);
			this.Controls.Add(this.simpleButtonOK);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormUpdateServiceSessionPT";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Update PT Package";
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtEmployeeID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtBranchCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtPackageID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEdtStartTime.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEditDate.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public int PersonalTrainerID
		{
			get {return ACMS.Convert.ToInt32(lkpEdtEmployeeID.EditValue);}
		}

		public DateTime Date
		{
			get {return dtEditDate.DateTime.Date;}
		}
		
		public string BranchCode
		{
			get {return lkpEdtBranchCode.EditValue.ToString();}
		}

		public DateTime StartTime
		{
			get { return dtEdtStartTime.DateTime; }
		}

		public int PackageID
		{
			get { return ACMS.Convert.ToInt32(lkpEdtPackageID.EditValue);}
		}

		private void lkpEdtBranchCode_EditValueChanged(object sender, System.EventArgs e)
		{
			if (lkpEdtBranchCode.EditValue != null)
			{
				myPersonalTrainerLookupEditBuilder.Refresh(lkpEdtBranchCode.EditValue.ToString());
			}
		}

		private void dtEditDate_EditValueChanged(object sender, System.EventArgs e)
		{
			DateTime dtstart = new DateTime(dtEditDate.DateTime.Year, dtEditDate.DateTime.Month, dtEditDate.DateTime.Day, 
				dtEdtStartTime.DateTime.Hour, dtEdtStartTime.DateTime.Minute, dtEdtStartTime.DateTime.Second);

			dtEdtStartTime.DateTime = dtstart;
		}

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
			if (DateTime.Compare(dtEdtStartTime.DateTime.Date, DateTime.Today.Date) < 0)
			{
				MessageBox.Show(this, "Invalid Date. Please choose other date.");
				this.DialogResult = DialogResult.None;
				return;
			}

			if (lkpEdtBranchCode.Text == "")
			{
				MessageBox.Show(this, "Please select a branch.");
				this.DialogResult   = DialogResult.None;
				return;
			}
			
			if (lkpEdtEmployeeID.Text == "")
			{
				MessageBox.Show(this, "Please select a therapist");
				this.DialogResult   = DialogResult.None;
				return;
			}
		}


		private void lkpEdtEmployeeID_EditValueChanged(object sender, System.EventArgs e)
		{
			if (lkpEdtEmployeeID.EditValue != null)
			{
				if (lkpEdtEmployeeID.Properties.DataSource != null)
				{
					DataTable table = (DataTable)lkpEdtEmployeeID.Properties.DataSource;
					DataRow[] rowList = table.Select("nEmployeeID = " + ACMS.Convert.ToInt32(lkpEdtEmployeeID.EditValue));
					
					if (rowList.Length > 0)
					{
						lkpEdtBranchCode.EditValue = rowList[0]["strBranchCode"].ToString();
					}
				}
			}
		}
	}
}
