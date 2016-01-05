using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using ACMSDAL;
using ACMSLogic;
using ACMS.ACMSBranch;
using System.Configuration;

namespace ACMS
{
	/// <summary>
	/// Summary description for FormNewServiceSession.
	/// </summary>
	public class FormNewServiceSessionSPA_IPL : System.Windows.Forms.Form
	{
		private ACMS.XtraUtils.LookupEditBuilder.TherapistForCommisionLookupEditBuilder myTherapistLookupEditBuilder;
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

        private int myPackageBalance;
		private int myPackageID;
		private string myMemberShipID;
        private int myPackageCategoryID;
        private string myPackageCode;
        private bool myIsFromCreditUsage;
        private DataTable mydtServiceUtilization;
		private DataTable mydtSessionID;
        private string myKeyData;
		private DevExpress.XtraEditors.DateEdit dtEdtStartTime;
		private DevExpress.XtraEditors.DateEdit dtEditDate;
		User oUser;
        private DevExpress.XtraEditors.DateEdit dtTreatment;
        private Label label6;
        private Label label7;
        private NumericUpDown txtQuantity;
        private TextBox txtRemark;
        private Label label8;
		private Label lblPackageCode;
        private Label label9;
        private Label lblPackageDesc;
        private Label label11;
        private Label label10;
        private Label lblPackageID;
        private Label lblCurrentPackageBalance;
        private Label label13;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public FormNewServiceSessionSPA_IPL(int tmpCurrentPackageBalance, int nPackageID, ACMSLogic.User User, string CurrentMembershipID, int MemberPackageCategoryID, string MemberPackageStrPackageCode,
                                                bool IsFromCreditUsage)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			oUser= User;
			label3.Text = "Appointment Time";
			label4.Text = "Therapist";
			checkEdit1.Visible = false;
			myPackageID = nPackageID;
            lblPackageID.Text = nPackageID.ToString();
			myMemberShipID = CurrentMembershipID;
            myPackageCategoryID = MemberPackageCategoryID;
            myPackageCode = MemberPackageStrPackageCode;
            lblPackageCode.Text = MemberPackageStrPackageCode;
            lblCurrentPackageBalance.Text = tmpCurrentPackageBalance.ToString();
            myIsFromCreditUsage = IsFromCreditUsage;


            TblPackage package = new TblPackage();
            lblPackageDesc.Text = package.GetPackageDescription(MemberPackageStrPackageCode);
            //lblPackageDesc.Text = "QI SPA 10 X INDIAN HEAD MASSAGE X 30 MIN BACK MASSAGE (10 SESSIONS)";
			lkpEdtServiceCode.Enabled = true;
			this.Text = "New Spa & IPL Package Attendance";
		
			dtEditDate.DateTime = DateTime.Now.Date;
			dtEdtStartTime.DateTime = DateTime.Now.Date;
            dtTreatment.DateTime = DateTime.Now.Date;
			Init();
			
			if (myIsFromCreditUsage)
            {
                dtEditDate.DateTime = DateTime.Today.Date;
                lkpEdtBranchCode.EditValue = ACMSLogic.User.BranchCode;
                dtTreatment.DateTime = DateTime.Today.Date;

                //dtEditDate.Properties.ReadOnly = true;
                //lkpEdtBranchCode.Properties.ReadOnly = true;
                //dtTreatment.Properties.ReadOnly = true;
            }
		}

		private void Init()
		{
			myTherapistLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.TherapistForCommisionLookupEditBuilder(lkpEdtEmployeeID.Properties, "");
			myBranchCodeLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.BranchCodeLookupEditBuilder2(lkpEdtBranchCode.Properties);
			myServiceCodeLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.ServiceCodeLookupEditBuilder2(lkpEdtServiceCode.Properties, myPackageID); 
		}
		
		public DataTable dtServiceUtilization
        {
            get { return mydtServiceUtilization; }
        }
		
		public DataTable dtSessionID
        {
            get { return mydtSessionID; }
        }

        public int FormPackageBalance
        {
            get { return myPackageBalance; }
        }

        public string FormKeyData
        {
            get { return myKeyData; }
        }

		public int TherapistID
		{
			get {return ACMS.Convert.ToInt32(lkpEdtEmployeeID.EditValue);}
		}

        public int NQuantity
        {
            get { return ACMS.Convert.ToInt32(txtQuantity.Value); }
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

        public string SsRemark
        {
            get { return txtRemark.Text.ToString(); }
        }

		public DateTime StartTime
		{
			get { return dtEdtStartTime.DateTime; }
		}

        public DateTime TreatmentDate
        {
            get { return dtTreatment.DateTime; }
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
            this.dtTreatment = new DevExpress.XtraEditors.DateEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.NumericUpDown();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPackageCode = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblPackageDesc = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblPackageID = new System.Windows.Forms.Label();
            this.lblCurrentPackageBalance = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtBranchCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEditDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEditDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtEmployeeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtServiceCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtStartTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTreatment.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTreatment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lkpEdtBranchCode
            // 
            this.lkpEdtBranchCode.EditValue = "";
            this.lkpEdtBranchCode.Location = new System.Drawing.Point(120, 148);
            this.lkpEdtBranchCode.Name = "lkpEdtBranchCode";
            this.lkpEdtBranchCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpEdtBranchCode.Size = new System.Drawing.Size(202, 20);
            this.lkpEdtBranchCode.TabIndex = 9;
            this.lkpEdtBranchCode.EditValueChanged += new System.EventHandler(this.lkpEdtBranchCode_EditValueChanged);
            // 
            // dtEditDate
            // 
            this.dtEditDate.EditValue = new System.DateTime(2005, 11, 23, 0, 0, 0, 0);
            this.dtEditDate.Location = new System.Drawing.Point(120, 118);
            this.dtEditDate.Name = "dtEditDate";
            this.dtEditDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEditDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtEditDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtEditDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtEditDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtEditDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtEditDate.Size = new System.Drawing.Size(202, 20);
            this.dtEditDate.TabIndex = 8;
            this.dtEditDate.EditValueChanged += new System.EventHandler(this.dateEdit1_EditValueChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(5, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "Branch";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(5, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Date";
            // 
            // lkpEdtEmployeeID
            // 
            this.lkpEdtEmployeeID.EditValue = "";
            this.lkpEdtEmployeeID.Location = new System.Drawing.Point(120, 208);
            this.lkpEdtEmployeeID.Name = "lkpEdtEmployeeID";
            this.lkpEdtEmployeeID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpEdtEmployeeID.Size = new System.Drawing.Size(202, 20);
            this.lkpEdtEmployeeID.TabIndex = 11;
            this.lkpEdtEmployeeID.EditValueChanged += new System.EventHandler(this.lkpEdtEmployeeID_EditValueChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(5, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "Appoinment Time";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(6, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "Therapist";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(6, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "Treatment";
            // 
            // lkpEdtServiceCode
            // 
            this.lkpEdtServiceCode.EditValue = "";
            this.lkpEdtServiceCode.Location = new System.Drawing.Point(120, 238);
            this.lkpEdtServiceCode.Name = "lkpEdtServiceCode";
            this.lkpEdtServiceCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpEdtServiceCode.Size = new System.Drawing.Size(202, 20);
            this.lkpEdtServiceCode.TabIndex = 15;
            this.lkpEdtServiceCode.EditValueChanged += new System.EventHandler(this.lkpEdtServiceCode_EditValueChanged);
            // 
            // simpleButton2
            // 
            this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton2.Location = new System.Drawing.Point(194, 429);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 17;
            this.simpleButton2.Text = "Cancel";
            // 
            // simpleButton1
            // 
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButton1.Location = new System.Drawing.Point(97, 429);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 16;
            this.simpleButton1.Text = "Save";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(10, 392);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Forfeit Column";
            this.checkEdit1.Size = new System.Drawing.Size(104, 19);
            this.checkEdit1.TabIndex = 18;
            this.checkEdit1.Visible = false;
            // 
            // dtEdtStartTime
            // 
            this.dtEdtStartTime.EditValue = new System.DateTime(2006, 1, 1, 0, 0, 0, 0);
            this.dtEdtStartTime.Location = new System.Drawing.Point(120, 176);
            this.dtEdtStartTime.Name = "dtEdtStartTime";
            this.dtEdtStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null)});
            this.dtEdtStartTime.Properties.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm tt";
            this.dtEdtStartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtEdtStartTime.Properties.EditFormat.FormatString = "T";
            this.dtEdtStartTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtEdtStartTime.Properties.Mask.EditMask = "T";
            this.dtEdtStartTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtEdtStartTime.Size = new System.Drawing.Size(202, 20);
            this.dtEdtStartTime.TabIndex = 34;
            // 
            // dtTreatment
            // 
            this.dtTreatment.EditValue = new System.DateTime(2005, 11, 23, 0, 0, 0, 0);
            this.dtTreatment.Location = new System.Drawing.Point(120, 268);
            this.dtTreatment.Name = "dtTreatment";
            this.dtTreatment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTreatment.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtTreatment.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtTreatment.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtTreatment.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtTreatment.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtTreatment.Size = new System.Drawing.Size(202, 20);
            this.dtTreatment.TabIndex = 36;
            this.dtTreatment.EditValueChanged += new System.EventHandler(this.dtTreatment_EditValueChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(5, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 23);
            this.label6.TabIndex = 35;
            this.label6.Text = "Treatment Date";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(7, 366);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 23);
            this.label7.TabIndex = 37;
            this.label7.Text = "Quantity";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(120, 364);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(120, 20);
            this.txtQuantity.TabIndex = 38;
            this.txtQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(120, 304);
            this.txtRemark.MaxLength = 50;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(202, 45);
            this.txtRemark.TabIndex = 42;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(6, 307);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 23);
            this.label8.TabIndex = 41;
            this.label8.Text = "Remark";
            // 
            // lblPackageCode
            // 
            this.lblPackageCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPackageCode.Location = new System.Drawing.Point(120, 41);
            this.lblPackageCode.Name = "lblPackageCode";
            this.lblPackageCode.Size = new System.Drawing.Size(233, 23);
            this.lblPackageCode.TabIndex = 44;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(5, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 23);
            this.label9.TabIndex = 43;
            this.label9.Text = "Package Code";
            // 
            // lblPackageDesc
            // 
            this.lblPackageDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPackageDesc.Location = new System.Drawing.Point(120, 64);
            this.lblPackageDesc.Name = "lblPackageDesc";
            this.lblPackageDesc.Size = new System.Drawing.Size(233, 23);
            this.lblPackageDesc.TabIndex = 46;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(5, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 23);
            this.label11.TabIndex = 45;
            this.label11.Text = "Description";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(7, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 23);
            this.label10.TabIndex = 47;
            this.label10.Text = "Package ID";
            // 
            // lblPackageID
            // 
            this.lblPackageID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPackageID.Location = new System.Drawing.Point(120, 16);
            this.lblPackageID.Name = "lblPackageID";
            this.lblPackageID.Size = new System.Drawing.Size(233, 23);
            this.lblPackageID.TabIndex = 48;
            // 
            // lblCurrentPackageBalance
            // 
            this.lblCurrentPackageBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPackageBalance.Location = new System.Drawing.Point(120, 87);
            this.lblCurrentPackageBalance.Name = "lblCurrentPackageBalance";
            this.lblCurrentPackageBalance.Size = new System.Drawing.Size(233, 23);
            this.lblCurrentPackageBalance.TabIndex = 50;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(5, 87);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 23);
            this.label13.TabIndex = 49;
            this.label13.Text = "Package Balance";
            // 
            // FormNewServiceSessionSPA_IPL
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(365, 492);
            this.Controls.Add(this.lblCurrentPackageBalance);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblPackageID);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblPackageDesc);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblPackageCode);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtTreatment);
            this.Controls.Add(this.label6);
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewServiceSessionSPA_IPL";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Spa/ IPL Service";
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtBranchCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEditDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEditDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtEmployeeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtServiceCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtStartTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTreatment.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTreatment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void lkpEdtBranchCode_EditValueChanged(object sender, System.EventArgs e)
		{
			if (lkpEdtBranchCode.EditValue != null)
			{
				myTherapistLookupEditBuilder.Refresh(lkpEdtBranchCode.EditValue.ToString());
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
            //if (DateTime.Compare(dtEdtStartTime.DateTime.Date, DateTime.Today.Date) < 0)
            //{
            //    if (oUser.NRightsLevelID() >= 1003 &&  oUser.NRightsLevelID() <= 1004 )
            //    {
            //        MessageBox.Show(this, "Invalid Date. Pls choose other date.");
            //        this.DialogResult   = DialogResult.None;
            //        return;
            //    }

            //}

            if (lkpEdtBranchCode.Text == "")
            {
                MessageBox.Show(this, "Please select a branch.");
                this.DialogResult = DialogResult.None;
                //return;


            }
            else if (lkpEdtEmployeeID.Text == "")
            {
                MessageBox.Show(this, "Please select a therapist");
                this.DialogResult = DialogResult.None;
                //return;
            }
            else if (lkpEdtServiceCode.Text == "")
            {
                MessageBox.Show(this, "Please select a treatment.");
                this.DialogResult = DialogResult.None;
                //return;
            }
            else
            {
                try
                {
                    TblEmployee myTherapist = new TblEmployee();
                    myTherapist.NEmployeeID = this.TherapistID;
                    DataTable tblTherapist = myTherapist.SelectOne();
                    MemberPackage myMemPackage = new MemberPackage();
                    DataTable tblMemberPackageBalance = MemberPackage.CalculateMemberPackageBalance(this.ServiceCode, myMemberShipID, myPackageID);

                    myPackageBalance = (Convert.ToInt32(tblMemberPackageBalance.Rows[0]["Balance"].ToString()) - Convert.ToInt32(this.NQuantity));

                    string strBalance = myPackageBalance.ToString();
                    string strTherapist = tblTherapist.Rows[0]["strEmployeeName"].ToString();
                    string strDateTime = DateTime.Now.ToString("dd/MM/yyyy  hh:mm:ss tt");
                    string strDateTimeMM = DateTime.Now.ToString("dd/MM/yyyy  hh:mm tt");
                    string strExpiryDate = Convert.ToDateTime(tblMemberPackageBalance.Rows[0]["dtExpiryDate"]).ToString("dd/MM/yyyy");

                    //** Insert Signature eric 15052009
                    //==================================
                    string strSignatureID = "";
                    string strKeyData = "";
                    string strPdfExportPath = "";

                    //int mySessionID = 0; 

                    DataTable dtss = new DataTable();
                    dtss.Columns.Add("nSessionID", typeof(int));
                    dtss.Columns.Add("strMembershipID", typeof(string));
                    mydtSessionID = dtss;

                    //Key data format for Spa Service Utilisation
                    //MemberID|DateTime|ExpiryDate|Branch|Therapist|PkgCode|ServCode|Qty|Bal
                    strPdfExportPath = (string)ConfigurationSettings.AppSettings["SaveSpaServiceReceiptPath"].ToString() + "\\" + User.BranchCode + "\\" + myMemberShipID.Trim() + "_" + strDateTime.Replace(":", "").Replace(" ", "").Replace("/", "") + ".pdf";
                    strKeyData = myMemberShipID.Trim() + "|" + strExpiryDate + "|" + this.BranchCode + "|" + strTherapist + "|" + myPackageCode + "|" + this.ServiceCode + "|" + strBalance + "|" + this.NQuantity;

                    myKeyData = strKeyData;

                    if (myPackageCategoryID == 4 || myPackageCategoryID == 5 || myPackageCategoryID == 6 || myPackageCategoryID == 34)
                    {
                        MemberPackage myMemberPackage = new MemberPackage();

                        myMemberPackage.NewServiceSession(myPackageID, this.ServiceCode, myMemberShipID.Trim(),
                            this.TherapistID, this.BranchCode, this.Date, this.StartTime, this.TreatmentDate, strSignatureID,
                            System.Convert.ToInt32(this.NQuantity), false, myPackageCategoryID, strKeyData,
                            strPdfExportPath, ref mydtSessionID, this.SsRemark);
                    }
                    else
                    {
                        MemberPackage myMemberPackage = new MemberPackage();

                        myMemberPackage.NewServiceSession(myPackageID, this.ServiceCode, myMemberShipID.Trim(),
                            this.TherapistID, this.BranchCode, this.Date, this.StartTime, this.TreatmentDate, strSignatureID,
                            System.Convert.ToInt32(this.NQuantity), false, myPackageCategoryID, "", "", this.SsRemark);
                    }

                    bool outputPrint = false;

                    //Derek From Credit Package Usage Do not print
                    if (!myIsFromCreditUsage)
                    {
                        if (myPackageCategoryID == 4 || myPackageCategoryID == 5 || myPackageCategoryID == 6 || myPackageCategoryID == 34)
                        {
                            DigSignature frmSig = new DigSignature(strKeyData, "ServiceUtilisation", null, null, dtServiceUtilization);
                            DialogResult result1 = frmSig.ShowDialog();

                            if (result1 == DialogResult.OK)
                            {
                                strSignatureID = frmSig.ShowSignature();

                                //**DEREK Update Service Session Signature ID **
                                try
                                {
                                    foreach (DataRow row in mydtSessionID.Rows)
                                    {
                                        //Derek Need Fixing Here - Update only strSignatureID and strPdfExportPath
                                        TblServiceSession myServiceSessionSigPath = new TblServiceSession();

                                        if (strSignatureID.Trim() != "" && strSignatureID.Trim() != "300D0A300D0A")
                                        {
                                            myServiceSessionSigPath.UpdateServiceSessionSigPdfPath(strSignatureID, strKeyData, strPdfExportPath, Convert.ToInt32(row["nSessionID"]), myMemberShipID);
                                        }
                                        else
                                        {
                                            myServiceSessionSigPath.UpdateServiceSessionSigPdfPath(strPdfExportPath, Convert.ToInt32(row["nSessionID"]), myMemberShipID);
                                        }

                                    }
                                }
                                catch { }

                                outputPrint = true;

                                /*if (strSignatureID == null || strSignatureID == "")
                                {
                                    DialogResult yes = MessageBox.Show(this, "Member haven't signed on signature pad. Confirm to print?", "Warning", MessageBoxButtons.YesNo);
                                    if (yes == DialogResult.No)
                                        return;
                                }*/

                                //============================================ 
                                //InitMemberPackage(CurrentMembershipID);
                                //OnMemberPackageGridFocusRowChanged();
                            }

                            //OnPrintMemberPackageUsage(tblTherapist.Rows[0]["strEmployeeName"].ToString(), CurrentMembershipID, MemberPackageStrPackageCode, frm.ServiceCode, strBalance);//eric 18052009
                            //**Call Print Package A/C report                                                          
                            //rpt.PrintRpt(strSignatureID, CurrentMembershipID, strDateTime, frm.BranchCode, strTherapist, MemberPackageStrPackageCode, frm.ServiceCode, strBalance);

                            PackageAccountRpt rpt = new PackageAccountRpt();

                            rpt.PrintRpt("Therapist Name :", strSignatureID, strKeyData, myMemberShipID.Trim(), strDateTimeMM, strExpiryDate, this.BranchCode, strTherapist, myPackageCode, this.ServiceCode, strBalance, this.NQuantity);
                            rpt.ExportToPdf(strPdfExportPath);

                            if (outputPrint)
                            {
                                rpt.Print();
                            }

                        }
                    }
                    else
                    {
                        if (myPackageCategoryID == 4 || myPackageCategoryID == 5 || myPackageCategoryID == 6 || myPackageCategoryID == 34)
                        {
                            //Update DataTable
                            DataTable dt = new DataTable();
                            dt.Columns.Add("Caption", typeof(string));
                            dt.Columns.Add("MemberID", typeof(string));
                            dt.Columns.Add("DateTime", typeof(string));
                            dt.Columns.Add("ExpiryDate", typeof(string));
                            dt.Columns.Add("BranchCode", typeof(string));
                            dt.Columns.Add("StaffName", typeof(string));
                            dt.Columns.Add("PackageCode", typeof(string));
                            dt.Columns.Add("PackageDesc", typeof(string));//lblPackageDesc.Text
                            dt.Columns.Add("ServiceCode", typeof(string));
                            dt.Columns.Add("Balance", typeof(string));
                            dt.Columns.Add("Quantity", typeof(int));
                            //dt.Columns.Add("mySessionID", typeof(int));
                            //DEREK Need Fixing Here - Need A Different DataTable to Store SessionID

                            dt.Rows.Add("Therapist Name :", myMemberShipID.Trim(), strDateTimeMM, strExpiryDate, this.BranchCode, strTherapist, myPackageCode,
                                                    lblPackageDesc.Text.ToString(), this.ServiceCode, strBalance, this.NQuantity);

                            mydtServiceUtilization = dt;
                        }
                    }
                }

                catch (Exception ex)
                {
                    this.DialogResult = DialogResult.None;

                    MessageBox.Show(this, ex.Message);
                }
            }

        }

        private void dateEdit1_EditValueChanged(object sender, System.EventArgs e)
        {

            DateTime dtstart = new DateTime(dtEditDate.DateTime.Year, dtEditDate.DateTime.Month, dtEditDate.DateTime.Day,
                dtEdtStartTime.DateTime.Hour, dtEdtStartTime.DateTime.Minute, dtEdtStartTime.DateTime.Second);

            dtEdtStartTime.DateTime = dtstart;
        }

        private void lkpEdtServiceCode_EditValueChanged(object sender, System.EventArgs e)
        {

        }

        private void dtTreatment_EditValueChanged(object sender, EventArgs e)
        {


        }
    }
}
