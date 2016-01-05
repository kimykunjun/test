using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using ACMSLogic;

namespace ACMS
{
	/// <summary>
	/// Summary description for FormNewServiceSession.
	/// </summary>
	public class FormNewServiceSessionPT : System.Windows.Forms.Form
	{
		private ACMS.XtraUtils.LookupEditBuilder.PersonalTrainerLookupEditBuilder myPersonalTrainerLookupEditBuilder;
		private ACMS.XtraUtils.LookupEditBuilder.BranchCodeLookupEditBuilder2 myBranchCodeLookupEditBuilder;
		private ACMS.XtraUtils.LookupEditBuilder.ServiceCodeLookupEditBuilder2 myServiceCodeLookupEditBuilder;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtBranchCode;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtServiceCode;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtEmployeeID;
		private DevExpress.XtraEditors.CheckEdit checkEdit1;
		User oUser;
		private int myPackageID;
		private DevExpress.XtraEditors.DateEdit dtEdtStartTime;
		private DevExpress.XtraEditors.DateEdit dtEditDate;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormNewServiceSessionPT(int nPackageID, ACMSLogic.User User)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			oUser= User;
			myPackageID = nPackageID;
			label3.Text = "Session Time";
			label4.Text = "Personal Trainer";
			lkpEdtServiceCode.Enabled = true;
			this.Text = "New PT Package Attendance";
			Init();
		}

		private void Init()
		{
			myPersonalTrainerLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.PersonalTrainerLookupEditBuilder(lkpEdtEmployeeID.Properties, "");
			myBranchCodeLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.BranchCodeLookupEditBuilder2(lkpEdtBranchCode.Properties);
			myServiceCodeLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.ServiceCodeLookupEditBuilder2(lkpEdtServiceCode.Properties, myPackageID); 
		}

		public int TherapistID
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

		public string ServiceCode
		{
			get {return lkpEdtServiceCode.EditValue.ToString(); }
		}

		public DateTime StartTime
		{
			get { return dtEdtStartTime.DateTime; }
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
			this.lkpEdtBranchCode = new DevExpress.XtraEditors.LookUpEdit();
			this.dtEditDate = new DevExpress.XtraEditors.DateEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lkpEdtEmployeeID = new DevExpress.XtraEditors.LookUpEdit();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lkpEdtServiceCode = new DevExpress.XtraEditors.LookUpEdit();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
			this.dtEdtStartTime = new DevExpress.XtraEditors.DateEdit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtBranchCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEditDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtEmployeeID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtServiceCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEdtStartTime.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// lkpEdtBranchCode
			// 
			this.lkpEdtBranchCode.EditValue = "";
			this.lkpEdtBranchCode.Location = new System.Drawing.Point(126, 48);
			this.lkpEdtBranchCode.Name = "lkpEdtBranchCode";
			// 
			// lkpEdtBranchCode.Properties
			// 
			this.lkpEdtBranchCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtBranchCode.Size = new System.Drawing.Size(202, 20);
			this.lkpEdtBranchCode.TabIndex = 9;
			this.lkpEdtBranchCode.EditValueChanged += new System.EventHandler(this.lkpEdtBranchCode_EditValueChanged);
			// 
			// dtEditDate
			// 
			this.dtEditDate.EditValue = new System.DateTime(2005, 11, 23, 0, 0, 0, 0);
			this.dtEditDate.Location = new System.Drawing.Point(126, 18);
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
			this.dtEditDate.TabIndex = 8;
			this.dtEditDate.EditValueChanged += new System.EventHandler(this.dateEdit1_EditValueChanged);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(5, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 7;
			this.label2.Text = "Branch";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(5, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 6;
			this.label1.Text = "Date";
			// 
			// lkpEdtEmployeeID
			// 
			this.lkpEdtEmployeeID.EditValue = "";
			this.lkpEdtEmployeeID.Location = new System.Drawing.Point(126, 108);
			this.lkpEdtEmployeeID.Name = "lkpEdtEmployeeID";
			// 
			// lkpEdtEmployeeID.Properties
			// 
			this.lkpEdtEmployeeID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtEmployeeID.Size = new System.Drawing.Size(202, 20);
			this.lkpEdtEmployeeID.TabIndex = 11;
			this.lkpEdtEmployeeID.EditValueChanged += new System.EventHandler(this.lkpEdtEmployeeID_EditValueChanged);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(5, 78);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(109, 23);
			this.label3.TabIndex = 10;
			this.label3.Text = "Session Time";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(6, 108);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(93, 23);
			this.label4.TabIndex = 12;
			this.label4.Text = "Personal Trainer";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(6, 138);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(93, 23);
			this.label5.TabIndex = 14;
			this.label5.Text = "Treatment";
			// 
			// lkpEdtServiceCode
			// 
			this.lkpEdtServiceCode.EditValue = "";
			this.lkpEdtServiceCode.Location = new System.Drawing.Point(126, 138);
			this.lkpEdtServiceCode.Name = "lkpEdtServiceCode";
			// 
			// lkpEdtServiceCode.Properties
			// 
			this.lkpEdtServiceCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtServiceCode.Size = new System.Drawing.Size(202, 20);
			this.lkpEdtServiceCode.TabIndex = 15;
			// 
			// simpleButton2
			// 
			this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButton2.Location = new System.Drawing.Point(162, 196);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.TabIndex = 17;
			this.simpleButton2.Text = "Cancel";
			// 
			// simpleButton1
			// 
			this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButton1.Location = new System.Drawing.Point(70, 196);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.TabIndex = 16;
			this.simpleButton1.Text = "Save";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// checkEdit1
			// 
			this.checkEdit1.Location = new System.Drawing.Point(128, 166);
			this.checkEdit1.Name = "checkEdit1";
			// 
			// checkEdit1.Properties
			// 
			this.checkEdit1.Properties.Caption = "Forfeit Column";
			this.checkEdit1.Size = new System.Drawing.Size(104, 18);
			this.checkEdit1.TabIndex = 18;
			this.checkEdit1.Visible = false;
			// 
			// dtEdtStartTime
			// 
			this.dtEdtStartTime.EditValue = new System.DateTime(2006, 1, 1, 0, 0, 0, 0);
			this.dtEdtStartTime.Location = new System.Drawing.Point(126, 76);
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
			this.dtEdtStartTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			this.dtEdtStartTime.Size = new System.Drawing.Size(202, 20);
			this.dtEdtStartTime.TabIndex = 35;
			// 
			// FormNewServiceSessionPT
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(338, 226);
			this.Controls.Add(this.dtEdtStartTime);
			this.Controls.Add(this.checkEdit1);
			this.Controls.Add(this.simpleButton2);
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.lkpEdtServiceCode);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lkpEdtEmployeeID);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lkpEdtBranchCode);
			this.Controls.Add(this.dtEditDate);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "FormNewServiceSessionPT";
			this.Load += new System.EventHandler(this.FormNewServiceSessionPT_Load);
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtBranchCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEditDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtEmployeeID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtServiceCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEdtStartTime.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void lkpEdtBranchCode_EditValueChanged(object sender, System.EventArgs e)
		{
			if (lkpEdtBranchCode.EditValue != null)
			{
				myPersonalTrainerLookupEditBuilder.Refresh(lkpEdtBranchCode.EditValue.ToString());
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
					
//					if (rowList.Length > 0)
//					{
//						lkpEdtBranchCode.EditValue = rowList[0]["strBranchCode"].ToString();
//					}
				}
			}
		}

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			if (DateTime.Compare(dtEdtStartTime.DateTime.Date, DateTime.Today.Date) < 0)
			{
				if (oUser.NRightsLevelID() >= 1003 &&  oUser.NRightsLevelID() <= 1004 )
				{
					MessageBox.Show(this, "Invalid Date. Pls choose other date.");
					this.DialogResult   = DialogResult.None;
					return;
				}
			}

			if (lkpEdtBranchCode.Text == "")
			{
				MessageBox.Show(this, "No Branch Selected.");
				this.DialogResult   = DialogResult.None;
				return;
			}

			if (lkpEdtEmployeeID.Text == "")
			{
				MessageBox.Show(this, "No Therapist Selected");
				this.DialogResult   = DialogResult.None;
				return;
			}

			if (lkpEdtServiceCode.Text == "")
			{
				MessageBox.Show(this, "No Treatment Selected.");
				this.DialogResult   = DialogResult.None;
				return;
			}
		}

		private void dateEdit1_EditValueChanged(object sender, System.EventArgs e)
		{
			
			DateTime dtstart = new DateTime(dtEditDate.DateTime.Year, dtEditDate.DateTime.Month, dtEditDate.DateTime.Day, 
				dtEdtStartTime.DateTime.Hour, dtEdtStartTime.DateTime.Minute, dtEdtStartTime.DateTime.Second);

			dtEdtStartTime.DateTime = dtstart;
		}

		private void FormNewServiceSessionPT_Load(object sender, System.EventArgs e)
		{
			dtEditDate.DateTime = DateTime.Today.Date;
			lkpEdtBranchCode.EditValue = ACMSLogic.User.BranchCode;
			dtEdtStartTime.DateTime = DateTime.Now;
		}
	}
}
 