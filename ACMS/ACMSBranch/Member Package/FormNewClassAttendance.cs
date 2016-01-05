using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ACMSDAL;
using ACMSLogic;

namespace ACMS
{
	/// <summary>
	/// Summary description for FormNewAeroAndFitnessPackage.
	/// </summary>
	public class FormNewClassAttendanceInMembershipModule : System.Windows.Forms.Form
	{
		private string myPackageCode;
		private int myPackageID;
		private string myMemberShipID;
		private ACMS.XtraUtils.LookupEditBuilder.ClassInstanceLookupEditBuilder myClassInstantLookupEditBuilder;
		private ACMS.XtraUtils.LookupEditBuilder.BranchCodeLookupEditBuilder2 myBranchCodeLookupEditBuilder;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraEditors.DateEdit dateEdit1;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtClassInstant;
		private System.Windows.Forms.Label label5;
		private DevExpress.XtraEditors.CheckEdit checkEdit1;
		private System.Windows.Forms.Label label6;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtBranchCode;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.TextEdit txtEdtStartTime;
		private DevExpress.XtraEditors.TextEdit txtEdtEndTime;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		private DevExpress.XtraEditors.CheckEdit checkEditForgetCard;
		private System.Windows.Forms.Label label7;
		private DevExpress.XtraEditors.TimeEdit dtEndTime;
		private DevExpress.XtraEditors.TimeEdit dtStartTime;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormNewClassAttendanceInMembershipModule(string  strPackageCode, int nPackageID, string strMemberShipID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			myPackageCode = strPackageCode;
			myPackageID = nPackageID;
			myMemberShipID = strMemberShipID;
			Init();
		}

		private void Init()
		{
			dateEdit1.DateTime = DateTime.Now.Date;
			myClassInstantLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.ClassInstanceLookupEditBuilder(lkpEdtClassInstant.Properties);
			myBranchCodeLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.BranchCodeLookupEditBuilder2(lkpEdtBranchCode.Properties);
		}

		public int NClassInstanceID
		{
			get 
			{
				if (lkpEdtClassInstant.EditValue != null)
					return ACMS.Convert.ToInt32(lkpEdtClassInstant.EditValue);
				else 
					return -1;
			}
		}
		/// <summary>
		/// Add property to get branch id.
		/// </summary>
		public string strBranchID
		{
			get
			{
				if(lkpEdtBranchCode.EditValue != null)
					return lkpEdtBranchCode.Text.Trim();
				else
					return "";
			}
		}

		public bool IsGym
		{
			get
			{
				return checkEdit1.Checked;
			}
		}

		public bool Refunded
		{
			get { return !checkEditForgetCard.Checked; }
		}

		#region ====== Added By Albert ======
		/*
		 * To use gym attendance from frmBranch \ Member Package.
		 */
		public DateTime StartTime
		{
			get
			{
				return Convert.ToDateTime(dtStartTime.EditValue);
			}
		}

		public DateTime EndTime
		{
			get
			{
				return Convert.ToDateTime(dtEndTime.EditValue);
			}
		}

		public DateTime AttendanceDate
		{
			get
			{
				return Convert.ToDateTime(dateEdit1.EditValue);
			}
		}
		#endregion
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.lkpEdtClassInstant = new DevExpress.XtraEditors.LookUpEdit();
            this.txtEdtStartTime = new DevExpress.XtraEditors.TextEdit();
            this.txtEdtEndTime = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.lkpEdtBranchCode = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.checkEditForgetCard = new DevExpress.XtraEditors.CheckEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.dtEndTime = new DevExpress.XtraEditors.TimeEdit();
            this.dtStartTime = new DevExpress.XtraEditors.TimeEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtClassInstant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtBranchCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditForgetCard.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Class";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Class Time";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = new System.DateTime(2005, 11, 23, 0, 0, 0, 0);
            this.dateEdit1.Location = new System.Drawing.Point(92, 20);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit1.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit1.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(210, 20);
            this.dateEdit1.TabIndex = 4;
            this.dateEdit1.EditValueChanged += new System.EventHandler(this.dateEdit1_EditValueChanged);
            // 
            // lkpEdtClassInstant
            // 
            this.lkpEdtClassInstant.Location = new System.Drawing.Point(92, 78);
            this.lkpEdtClassInstant.Name = "lkpEdtClassInstant";
            this.lkpEdtClassInstant.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpEdtClassInstant.Size = new System.Drawing.Size(210, 20);
            this.lkpEdtClassInstant.TabIndex = 6;
            this.lkpEdtClassInstant.EditValueChanged += new System.EventHandler(this.lkpEdtClassInstant_EditValueChanged);
            // 
            // txtEdtStartTime
            // 
            this.txtEdtStartTime.EditValue = "";
            this.txtEdtStartTime.Location = new System.Drawing.Point(94, 108);
            this.txtEdtStartTime.Name = "txtEdtStartTime";
            this.txtEdtStartTime.Properties.ReadOnly = true;
            this.txtEdtStartTime.Size = new System.Drawing.Size(90, 20);
            this.txtEdtStartTime.TabIndex = 7;
            // 
            // txtEdtEndTime
            // 
            this.txtEdtEndTime.EditValue = "";
            this.txtEdtEndTime.Location = new System.Drawing.Point(210, 108);
            this.txtEdtEndTime.Name = "txtEdtEndTime";
            this.txtEdtEndTime.Properties.ReadOnly = true;
            this.txtEdtEndTime.Size = new System.Drawing.Size(90, 20);
            this.txtEdtEndTime.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Is Gym";
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(96, 140);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "";
            this.checkEdit1.Size = new System.Drawing.Size(24, 19);
            this.checkEdit1.TabIndex = 12;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(188, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "To";
            // 
            // lkpEdtBranchCode
            // 
            this.lkpEdtBranchCode.Location = new System.Drawing.Point(92, 48);
            this.lkpEdtBranchCode.Name = "lkpEdtBranchCode";
            this.lkpEdtBranchCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpEdtBranchCode.Size = new System.Drawing.Size(210, 20);
            this.lkpEdtBranchCode.TabIndex = 5;
            this.lkpEdtBranchCode.EditValueChanged += new System.EventHandler(this.lkpEdtBranchCode_EditValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Branch";
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButtonCancel.Location = new System.Drawing.Point(180, 210);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonCancel.TabIndex = 46;
            this.simpleButtonCancel.Text = "Cancel";
            // 
            // simpleButtonOK
            // 
            //this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButtonOK.Location = new System.Drawing.Point(76, 210);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonOK.TabIndex = 45;
            this.simpleButtonOK.Text = "OK";
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
            // 
            // checkEditForgetCard
            // 
            this.checkEditForgetCard.Location = new System.Drawing.Point(96, 170);
            this.checkEditForgetCard.Name = "checkEditForgetCard";
            this.checkEditForgetCard.Properties.Caption = "";
            this.checkEditForgetCard.Size = new System.Drawing.Size(18, 19);
            this.checkEditForgetCard.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 23);
            this.label7.TabIndex = 48;
            this.label7.Text = "Forget Card";
            // 
            // dtEndTime
            // 
            this.dtEndTime.EditValue = null;
            this.dtEndTime.Location = new System.Drawing.Point(210, 108);
            this.dtEndTime.Name = "dtEndTime";
            this.dtEndTime.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dtEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtEndTime.Properties.DisplayFormat.FormatString = "hh:mm tt";
            this.dtEndTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtEndTime.Properties.EditFormat.FormatString = "hh:mm tt";
            this.dtEndTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtEndTime.Size = new System.Drawing.Size(90, 22);
            this.dtEndTime.TabIndex = 50;
            this.dtEndTime.Visible = false;
            // 
            // dtStartTime
            // 
            this.dtStartTime.EditValue = null;
            this.dtStartTime.Location = new System.Drawing.Point(93, 108);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dtStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtStartTime.Properties.DisplayFormat.FormatString = "hh:mm tt";
            this.dtStartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtStartTime.Properties.EditFormat.FormatString = "hh:mm tt";
            this.dtStartTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtStartTime.Size = new System.Drawing.Size(90, 22);
            this.dtStartTime.TabIndex = 49;
            this.dtStartTime.Visible = false;
            // 
            // FormNewClassAttendanceInMembershipModule
            // 
            this.AcceptButton = this.simpleButtonOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.simpleButtonCancel;
            this.ClientSize = new System.Drawing.Size(322, 250);
            this.Controls.Add(this.dtEndTime);
            this.Controls.Add(this.dtStartTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.checkEditForgetCard);
            this.Controls.Add(this.simpleButtonCancel);
            this.Controls.Add(this.simpleButtonOK);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEdtEndTime);
            this.Controls.Add(this.txtEdtStartTime);
            this.Controls.Add(this.lkpEdtClassInstant);
            this.Controls.Add(this.lkpEdtBranchCode);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewClassAttendanceInMembershipModule";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Fitness Package";
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtClassInstant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtBranchCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditForgetCard.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartTime.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void dateEdit1_EditValueChanged(object sender, System.EventArgs e)
		{
			if (dateEdit1.EditValue != null && lkpEdtBranchCode.EditValue != null)
			{
				myClassInstantLookupEditBuilder.Refresh(dateEdit1.DateTime, lkpEdtBranchCode.EditValue.ToString(), myPackageCode);
			}
		}

		private void lkpEdtBranchCode_EditValueChanged(object sender, System.EventArgs e)
		{
			if (dateEdit1.EditValue != null && lkpEdtBranchCode.EditValue != null)
			{
				myClassInstantLookupEditBuilder.Refresh(dateEdit1.DateTime, lkpEdtBranchCode.EditValue.ToString(), myPackageCode);
			}
		}

		private void lkpEdtClassInstant_EditValueChanged(object sender, System.EventArgs e)
		{
			int nClassInstanceID = ACMS.Convert.ToInt32(lkpEdtClassInstant.EditValue);
			ACMSDAL.TblClassInstance clsInstance = new ACMSDAL.TblClassInstance();
			clsInstance.NClassInstanceID = nClassInstanceID;
			clsInstance.SelectOne();
			txtEdtStartTime.Text = clsInstance.DtStartTime.Value.ToShortTimeString();
			txtEdtEndTime.Text = clsInstance.DtEndTime.Value.ToShortTimeString();
		}

		private void checkEdit1_CheckedChanged(object sender, System.EventArgs e)
		{
			dtStartTime.Visible = true;
			dtEndTime.Visible =true;
		}

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.OK;  //DEREK

            if (this.NClassInstanceID != -1)
            {
                //myMemberPackage.NewClassAttendance(MemberPackagePackageID, currMembershipID, 
                TblClassInstance clsInstance = new TblClassInstance();
                clsInstance.NClassInstanceID = this.NClassInstanceID;
                clsInstance.SelectOne();
                int nType = this.IsGym ? 1 : 0;

                if (!ClassAttendance.VerifyMemberPackageAllowCertainClass(myPackageID, clsInstance.StrClassCode.Value))
                {
                    MessageBox.Show(this, "The package you wish to use is not allow to attend the class. Please use other package.");
                    //return;
                }
                else if (clsInstance.NActualInstructorID.IsNull)
                {
                    MessageBox.Show(this, "The Instructor has Not punch in yet.");
                    //return;
                }
                else
                {
                    try
                    {
                        //Edited by Albert on 20-Dec-06
                        //Change the User.BranchCode to frm.strBranchID.
                        //To get the branch id from the dialog form.

                        MemberPackage myMemberPackage = new MemberPackage();

                        myMemberPackage.NewClassAttendance(myPackageID, myMemberShipID, this.NClassInstanceID,
                            nType, this.strBranchID, clsInstance.DtDate.Value, clsInstance.DtStartTime.Value, clsInstance.DtEndTime.Value, this.Refunded);
   
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        this.DialogResult = DialogResult.None;

                        MessageBox.Show(this, ex.Message);
                    }
                }
            }
            else
            {
                try
                {
                    ClassAttendance myClassAttendance = new ClassAttendance();
                    myClassAttendance.MarkGymAttendance(myPackageID, myMemberShipID, this.AttendanceDate, this.StartTime, this.EndTime, true);

                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    this.DialogResult = DialogResult.None;

                    MessageBox.Show(this, ex.Message);
                }
            }
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }



	}
}
