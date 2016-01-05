using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using ACMSDAL;
using ACMSLogic;

namespace ACMS
{
	public class FormNewMemberCreditPackageExtension : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;

		private int myMemberCreditPackageID;
        private string myPurchaseDate;
        private string myStartDate;
        private string myExpiryDate;
        private int myStatusID;
        private int curEmployeeID;
        private string curMembershipID;
		private ACMSLogic.CreditAccount myMemberCreditPackage;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtLeaveType;
		private DataTable myDataTable;
		private DevExpress.XtraEditors.DateEdit dtEdtLeaveStartDate;
		private DevExpress.XtraEditors.DateEdit dtEdtLeaveEndDate;
		private DevExpress.XtraEditors.DateEdit dtEdtNewExpiry;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		private System.Windows.Forms.Label lblnewPackageExt;
		//private DataRow existPkg; //need to comment this out - not necessary
		private System.Windows.Forms.TextBox txtOther;
		private System.ComponentModel.Container components = null;

        public FormNewMemberCreditPackageExtension(int nCreditPackageID, string CurrentMembershipID, string dtPurchaseDate, string dtStartDate, string dtExpiryDate, int nStatusID) //Put in all info - Expiry Date
		{
			InitializeComponent();

            myMemberCreditPackageID = nCreditPackageID;
            myPurchaseDate = dtPurchaseDate;
            myStartDate = dtStartDate;
            myExpiryDate = dtExpiryDate;
            myStatusID = nStatusID;
            curEmployeeID = User.EmployeeID;
            curMembershipID = CurrentMembershipID;

            lblnewPackageExt.Text = "New Extension for Member Credit Package ID : " + myMemberCreditPackageID; 

			dtEdtLeaveEndDate.DateTime = DateTime.Now.Date;
			dtEdtLeaveStartDate.DateTime = DateTime.Now.Date;
			//dtEdtNewExpiry.DateTime = ACMS.Convert.ToDBDateTime(pkgdr["dtExpiryDate"]);

            Init();
		}

		private void Init()
		{
			InitLookupEdit();
			//BindData();
		}

		public DataTable CreditPackageExtensionTable
		{
			get { return myDataTable; }
		}

		public DateTime NewExpiryDate
		{
			get { return dtEdtNewExpiry.DateTime;}
        }

        public DateTime StartDate
        {
            get { return dtEdtLeaveStartDate.DateTime; }
        }

        public DateTime EndDate
        {
            get { return dtEdtLeaveEndDate.DateTime; }
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
	
		/*private void BindData()
		{
			myDataTable = myMemberCreditPackage.NewExtensionHistory(myMemberCreditPackageID);

			lkpEdtLeaveType.DataBindings.Clear();
			lkpEdtLeaveType.DataBindings.Add("EditValue", myDataTable, "nReasonID");
			dtEdtLeaveEndDate.DataBindings.Clear();
			dtEdtLeaveEndDate.DataBindings.Add("EditValue", myDataTable, "dtEndDate");
			dtEdtLeaveStartDate.DataBindings.Clear();
			dtEdtLeaveStartDate.DataBindings.Add("EditValue", myDataTable, "dtStartDate");
			txtOther.DataBindings.Clear();
			txtOther.DataBindings.Add("Text", myDataTable, "strRemarks");
		}*/

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
            this.lblnewPackageExt = new System.Windows.Forms.Label();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.txtOther = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtLeaveType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtLeaveStartDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtLeaveStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtLeaveEndDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtLeaveEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtNewExpiry.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtNewExpiry.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Leave Type";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Leave Start Date";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Leave End Date";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Old Expiry Date";
            this.label4.Visible = false;
            // 
            // lkpEdtLeaveType
            // 
            this.lkpEdtLeaveType.EditValue = "";
            this.lkpEdtLeaveType.Location = new System.Drawing.Point(116, 132);
            this.lkpEdtLeaveType.Name = "lkpEdtLeaveType";
            this.lkpEdtLeaveType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                    new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpEdtLeaveType.Size = new System.Drawing.Size(216, 20);
            this.lkpEdtLeaveType.TabIndex = 0;
            this.lkpEdtLeaveType.EditValueChanged += new System.EventHandler(this.lkpEdtLeaveType_EditValueChanged);
            // 
            // dtEdtLeaveStartDate
            // 
            this.dtEdtLeaveStartDate.EditValue = new System.DateTime(2005, 11, 15, 0, 0, 0, 0);
            this.dtEdtLeaveStartDate.Location = new System.Drawing.Point(118, 32);
            this.dtEdtLeaveStartDate.Name = "dtEdtLeaveStartDate";
            this.dtEdtLeaveStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                    new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEdtLeaveStartDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtEdtLeaveStartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtEdtLeaveStartDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtEdtLeaveStartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtEdtLeaveStartDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                    new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtEdtLeaveStartDate.Size = new System.Drawing.Size(172, 20);
            this.dtEdtLeaveStartDate.TabIndex = 1;
            // 
            // dtEdtLeaveEndDate
            // 
            this.dtEdtLeaveEndDate.EditValue = new System.DateTime(2005, 11, 15, 0, 0, 0, 0);
            this.dtEdtLeaveEndDate.Location = new System.Drawing.Point(118, 64);
            this.dtEdtLeaveEndDate.Name = "dtEdtLeaveEndDate";
            this.dtEdtLeaveEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                    new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEdtLeaveEndDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtEdtLeaveEndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtEdtLeaveEndDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtEdtLeaveEndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtEdtLeaveEndDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                    new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtEdtLeaveEndDate.Size = new System.Drawing.Size(172, 20);
            this.dtEdtLeaveEndDate.TabIndex = 2;
            // 
            // dtEdtNewExpiry
            // 
            this.dtEdtNewExpiry.EditValue = new System.DateTime(2005, 11, 15, 0, 0, 0, 0);
            this.dtEdtNewExpiry.Enabled = false;
            this.dtEdtNewExpiry.Location = new System.Drawing.Point(118, 96);
            this.dtEdtNewExpiry.Name = "dtEdtNewExpiry";
            this.dtEdtNewExpiry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                    new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEdtNewExpiry.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtEdtNewExpiry.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtEdtNewExpiry.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtEdtNewExpiry.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtEdtNewExpiry.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                    new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtEdtNewExpiry.Size = new System.Drawing.Size(172, 20);
            this.dtEdtNewExpiry.TabIndex = 3;
            this.dtEdtNewExpiry.Visible = false;
            // 
            // lblnewPackageExt
            // 
            this.lblnewPackageExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblnewPackageExt.Location = new System.Drawing.Point(10, 4);
            this.lblnewPackageExt.Name = "lblnewPackageExt";
            this.lblnewPackageExt.Size = new System.Drawing.Size(384, 20);
            this.lblnewPackageExt.TabIndex = 49;
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButtonCancel.Location = new System.Drawing.Point(214, 232);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonCancel.TabIndex = 6;
            this.simpleButtonCancel.Text = "Cancel";
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButtonOK.Location = new System.Drawing.Point(134, 232);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonOK.TabIndex = 5;
            this.simpleButtonOK.Text = "OK";
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
            // 
            // txtOther
            // 
            this.txtOther.Enabled = false;
            this.txtOther.Location = new System.Drawing.Point(118, 164);
            this.txtOther.Multiline = true;
            this.txtOther.Name = "txtOther";
            this.txtOther.Size = new System.Drawing.Size(212, 56);
            this.txtOther.TabIndex = 50;
            // 
            // FormNewMemberPackageExtension
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(398, 272);
            this.Controls.Add(this.txtOther);
            this.Controls.Add(this.simpleButtonCancel);
            this.Controls.Add(this.simpleButtonOK);
            this.Controls.Add(this.lblnewPackageExt);
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
            this.Name = "FormNewMemberCreditPackageExtension";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Member Credit Package Extension";
            this.Load += new System.EventHandler(this.FormNewMemberCreditPackageExtension_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtLeaveType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtLeaveStartDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtLeaveStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtLeaveEndDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtLeaveEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtNewExpiry.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtNewExpiry.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

	    }
		#endregion

		private void lkpEdtLeaveType_EditValueChanged(object sender, System.EventArgs e)
		{
            if (lkpEdtLeaveType.Text == "OTHER")
            {
                txtOther.Enabled = true;
            }
            else
            {
                txtOther.Text = "";
                txtOther.Enabled = false;
            }

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
            //Must Select A Leave Type
			if (lkpEdtLeaveType.Text.Length == 0)
			{
				MessageBox.Show(this, "Please select a Leave Type.");
				this.DialogResult = DialogResult.None;
				return;
			}

            if (lkpEdtLeaveType.Text != "0")
            {
                //For Case Other Only, the End Date Selected must be later than the current Expiry Date
                if (lkpEdtLeaveType.Text == "OTHER")
                {
                    if (DateTime.Compare(dtEdtLeaveEndDate.DateTime.Date, ACMS.Convert.ToDBDateTime(myExpiryDate)) < 0)
                    {
                        MessageBox.Show(this, "New expiry date must be after current expiry date.", this.Text);
                        this.DialogResult = DialogResult.None;
                        return;
                    }

                    dtEdtLeaveStartDate.DateTime = ACMS.Convert.ToDBDateTime(myExpiryDate); //Need to Change this to refer to the expiry date passed in

                    //Remarks must not empty
                    if (txtOther.Text == "")
                    {
                        MessageBox.Show(this, "Remarks cannot be empty.", this.Text);
                        this.DialogResult = DialogResult.None;
                        return;
                    }

                }
                else
                {
                    //Empty remarks
                    txtOther.Text = "";
                }

                //Start Date Selected must be greater than the End Date Selected
                if (DateTime.Compare(dtEdtLeaveStartDate.DateTime.Date, dtEdtLeaveEndDate.DateTime.Date) > 0)
                {
                    MessageBox.Show(this, "Start Date must earlier than end date");
                    this.DialogResult = DialogResult.None;
                    return;
                }

                //Start Date Selected must be greater than Credit Package Start Date
                if ((DateTime.Compare(ACMS.Convert.ToDBDateTime(myStartDate), dtEdtLeaveStartDate.DateTime.Date) > 0
                    || DateTime.Compare(ACMS.Convert.ToDBDateTime(myStartDate), dtEdtLeaveStartDate.DateTime.Date) == 0)
                    && lkpEdtLeaveType.Text != "OTHER")
                {
                    MessageBox.Show(this, "Leave start date must be after package start date");
                    this.DialogResult = DialogResult.None;
                    return;
                }

                //Start Date cannot be later than the current Credit package expiry Date
                if (DateTime.Compare(dtEdtLeaveStartDate.DateTime.Date, ACMS.Convert.ToDBDateTime(myExpiryDate)) > 0)
                {
                    MessageBox.Show(this, "Extension Start Date cannot be later than Member's Credit Package Expiry Date.");
                    this.DialogResult = DialogResult.None;
                    return;
                }

                //Minimum 3 days extension
                if ((dtEdtLeaveEndDate.DateTime.Date - dtEdtLeaveStartDate.DateTime.Date).TotalDays < 3)
                {
                    MessageBox.Show(this, "Minimum extension of 3 days is required.");
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }

            //Get Extension history for current credit package
            TblCreditPackageExtension CreditPkgExtension = new TblCreditPackageExtension();          

            CreditPkgExtension.NCreditPackageID = myMemberCreditPackageID;
            DataTable dtCreditPkgExtension = CreditPkgExtension.SelectAllWnCreditPackageIDLogic();

            DateTime ExtStartDate = dtEdtLeaveStartDate.DateTime.Date;
            DateTime ExtEndDate = dtEdtLeaveEndDate.DateTime.Date;

            if (dtCreditPkgExtension != null && dtCreditPkgExtension.Rows.Count > 0)
            {
                int r;

                //Loop through the extension history for the selected credit package
                for (r = 0; r <= dtCreditPkgExtension.Rows.Count - 1; r++)
                {
                    //To See If Overlapped date in extension package
                    if (ExtStartDate < ACMS.Convert.ToDateTime(dtCreditPkgExtension.Rows[r]["dtEndDate"]) &&
                        ExtEndDate >= ACMS.Convert.ToDateTime(dtCreditPkgExtension.Rows[r]["dtStartDate"]) ||
                        (ExtEndDate < ExtStartDate))
                    {
                        MessageBox.Show(this, "Overlapped date in extension credit package.");
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                }
            }    

            try
            {
                //Create New Credit Package Extension
                TimeSpan nDaysExtend = Convert.ToDateTime(ExtEndDate).Subtract(Convert.ToDateTime(ExtStartDate));

                int nDaysExtended = Convert.ToInt32(nDaysExtend.TotalDays) + 1;
                DateTime dtOldExpiry = Convert.ToDateTime(myExpiryDate);
                DateTime dtNewExpiry = dtOldExpiry.AddDays(nDaysExtend.TotalDays + 1);
                DateTime dtCreateDate = System.DateTime.Now;
                DateTime dtStartDate = dtEdtLeaveStartDate.DateTime.Date;
                DateTime dtEndDate = dtEdtLeaveEndDate.DateTime.Date;
                int nStatusID = 0;
                int nReasonID = Convert.ToInt32(lkpEdtLeaveType.EditValue);
                string strRemarks = txtOther.Text.ToString();
                int nEmployeeID = curEmployeeID;
                int nCreditPackageID = myMemberCreditPackageID;

                

                SaveExtensionHistory(nCreditPackageID, curMembershipID, dtOldExpiry, dtNewExpiry, dtStartDate, dtEndDate,
                                            nDaysExtended, nStatusID, nReasonID, strRemarks, nEmployeeID, dtCreateDate);

            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.None;

                MessageBox.Show(this, ex.Message);
            }
		}

        private void SaveExtensionHistory(int nCreditPackageID, string strMembershipID, DateTime dtOldExpiry, DateTime dtNewExpiry, DateTime dtStartDate, DateTime dtEndDate, 
                                            int nDaysExtended, int nStatusID, int nReasonID, string strRemarks, int nEmployeeID, DateTime dtCreateDate)
		{
            int nCreditPackageStatusID = -1;

            if (DateTime.Compare(dtNewExpiry, DateTime.Now) > 0)
            {
                nCreditPackageStatusID = 0;
            }

            ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();

            TblMemberCreditPackage myMemberCreditPackage = new TblMemberCreditPackage();
            TblCreditPackageExtension myCreditPackageExtension = new TblCreditPackageExtension();

            myMemberCreditPackage.MainConnectionProvider = connProvider;
            myCreditPackageExtension.MainConnectionProvider = connProvider;

            connProvider.OpenConnection();
            connProvider.BeginTransaction("SaveCreditPackageExtension");

            try
            {
                //Update MemberCreditPackage - New Expiry Date & Status ID by nCreditPackageID                
                myMemberCreditPackage.MemberCreditPackage_ExtensionUpdate(nCreditPackageID, nCreditPackageStatusID, dtNewExpiry, strMembershipID);

                //Add Record to Credit Package Extension
                myCreditPackageExtension.NCreditPackageID = nCreditPackageID;
                myCreditPackageExtension.DtOldExpiry = dtOldExpiry;
                myCreditPackageExtension.DtNewExpiry = dtNewExpiry;
                myCreditPackageExtension.DtStartDate = dtStartDate;
                myCreditPackageExtension.DtEndDate = dtEndDate;
                myCreditPackageExtension.NDaysExtended = nDaysExtended;
                myCreditPackageExtension.NStatusID = nStatusID;
                myCreditPackageExtension.NReasonID = nReasonID;
                myCreditPackageExtension.StrRemarks = strRemarks;
                myCreditPackageExtension.NEmployeeID = nEmployeeID;

                myCreditPackageExtension.Insert();

                //Commit Transaction
                connProvider.CommitTransaction();
                //*** Remember to Disable the Update Expiry Button for Credit Packages
            }
            catch
            {
                //RollBack Transaction
                connProvider.RollbackTransaction("SaveCreditPackageExtension");
            }
            finally
            {
                //connProvider.CurrentTransaction.Dispose();
                //connProvider.DBConnection.Close();
                if (connProvider.CurrentTransaction != null)
                {
                    connProvider.CurrentTransaction.Dispose();
                }

                if (connProvider.DBConnection != null)
                {
                    if (connProvider.DBConnection.State == ConnectionState.Open)
                    {
                        connProvider.DBConnection.Close();
                    }
                }
                myMemberCreditPackage.MainConnactionIsCreatedLocal = true;
                myCreditPackageExtension.MainConnactionIsCreatedLocal = true;
            }
            
		}

        private void FormNewMemberCreditPackageExtension_Load(object sender, EventArgs e)
        {

        }
	}
}
