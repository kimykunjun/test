using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

namespace ACMS.ACMSManager.MasterData
{
	/// <summary>
	/// Summary description for frmCompany.
	/// </summary>
	public class frmCompany : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder myTax;
		private ACMS.XtraUtils.LookupEditBuilder.BankCodeLookupEditBuilder myBankCode;
		private ACMS.XtraUtils.LookupEditBuilder.BankBranchCodeLookupEditBuilder myBankBranchCode;
		

		private DevExpress.XtraEditors.GroupControl grpMdCompanyTop;
		private DevExpress.XtraTab.XtraTabControl tabCtrlMd_Company;
		private DevExpress.XtraTab.XtraTabPage tabMdComp_Bank;
		private DevExpress.XtraEditors.TextEdit mdComp_txtStrAccountNo;
		private DevExpress.XtraEditors.TextEdit mdComp_txtStrAccountName;
		private System.Windows.Forms.Label lblMdComp_BankAC_Num;
		private System.Windows.Forms.Label lblMdComp_BankBranchCode;
		private System.Windows.Forms.Label lblMdComp_BankACName;
		private System.Windows.Forms.Label lblMdComp_BankCode;
		private DevExpress.XtraTab.XtraTabPage tabComp_Payroll;
		private DevExpress.XtraEditors.TextEdit mdComp_txtStrCPFReferenceNo;
		private DevExpress.XtraEditors.TextEdit mdComp_txtStrCompanyID;
		private DevExpress.XtraEditors.TextEdit mdComp_txtStrCompanyCodeRef;
		private DevExpress.XtraEditors.TextEdit mdComp_txtStrBatchNo;
		private System.Windows.Forms.Label lblMdComp_CPFRef;
		private System.Windows.Forms.Label lblMdComp_ID;
		private System.Windows.Forms.Label lblMdComp_CodeRef;
		private System.Windows.Forms.Label lblMdComp_PayrBatchNo;
		private DevExpress.XtraTab.XtraTabPage tabComp_Class;
		private DevExpress.XtraEditors.TextEdit mdComp_txtMInstructorLateDeductionFee;
		private DevExpress.XtraEditors.TextEdit mdComp_txtNCancelBookingLimit;
		private System.Windows.Forms.Label lblMdComp_InstructorLateDeductionFee;
		private System.Windows.Forms.Label lblMdComp_CancelBookingLimit;
		private DevExpress.XtraTab.XtraTabPage tabComp_Member;
		private DevExpress.XtraEditors.TextEdit mdComp_txtNClassLeft;
		private DevExpress.XtraEditors.TextEdit mdComp_txtNDaysToExpire;
		private DevExpress.XtraEditors.TextEdit mdComp_txtNNonMembershipNo;
		private System.Windows.Forms.Label lblMdDesc;
		private System.Windows.Forms.Label lblMdComp_ClassLeft;
		private System.Windows.Forms.Label lblMdComp_DaysToExpire;
		private System.Windows.Forms.Label lblMdComp_NonMembershipNo;
		private DevExpress.XtraTab.XtraTabPage tabComp_Card;
		private DevExpress.XtraEditors.TextEdit mdComp_txtMRegistrationFees;
		private DevExpress.XtraEditors.TextEdit mdComp_txtMReplaceCardRate;
		private DevExpress.XtraEditors.TextEdit mdComp_txtMForgetCardRate;
		private System.Windows.Forms.Label lblMdComp_RegFee;
		private System.Windows.Forms.Label lblMdComp_ReplaceCardRate;
		private System.Windows.Forms.Label lblMdComp_ForgetCardRate;
		private DevExpress.XtraTab.XtraTabPage tabComp_UOB;
		private System.Windows.Forms.Label lblMdComp_ResetDate;
		private DevExpress.XtraEditors.TimeEdit mdComp_dtUOBWeekendPeakEnd;
		private DevExpress.XtraEditors.TimeEdit mdComp_dtUOBWeekdayPeakEnd;
		private DevExpress.XtraEditors.TimeEdit mdComp_dtUOBWeekendPeakStart;
		private DevExpress.XtraEditors.TimeEdit mdComp_dtUOBWeekdayPeakStart;
		private DevExpress.XtraEditors.TextEdit mdComp_txtNUOBMthlyBooking;
		private System.Windows.Forms.Label lblMdComp_UOBWeekendPeakEnd;
		private System.Windows.Forms.Label lblMdComp_UOBWeekendPeakStart;
		private System.Windows.Forms.Label lblMdComp_UOBWeekdayPeakEnd;
		private System.Windows.Forms.Label lblMdComp_UOBWeekdayPeakStart;
		private System.Windows.Forms.Label lblMdComp_UOBMthlyBooking;
		private DevExpress.XtraTab.XtraTabPage tabComp_Misc;
		private DevExpress.XtraEditors.SimpleButton btnMdComp_Directory2;
		private DevExpress.XtraEditors.SimpleButton btnMdComp_Directory1;
		private DevExpress.XtraEditors.TextEdit mdComp_txtNMaxCarryForwardLeaveCF;
		private DevExpress.XtraEditors.TextEdit mdComp_txtStrPayrollDir;
		private DevExpress.XtraEditors.TextEdit mdComp_txtStrBJReportBranch;
		private System.Windows.Forms.Label lblMdComp_LeaveCF;
		private System.Windows.Forms.Label lblMdComp_PayrollDir;
		private System.Windows.Forms.Label lblMdComp_BJReportBranch;
		private DevExpress.XtraEditors.TextEdit mdComp_txtStrCompanyName;
		private DevExpress.XtraEditors.TextEdit mdComp_txtStrCompanyCode;
		private System.Windows.Forms.Label lblMdComp_Tax;
		private System.Windows.Forms.Label lblMdCompany;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.LookUpEdit lk_MD_ComTax;
		private DevExpress.XtraEditors.LookUpEdit lk_MD_BankCode;
		private DevExpress.XtraEditors.LookUpEdit lk_MD_BankBranchCode;
		private DevExpress.XtraEditors.SimpleButton btnMd_BankCompSave;
		private DevExpress.XtraEditors.SimpleButton btnMd_PayrollCompSave;
		private DevExpress.XtraEditors.SimpleButton btnMd_ClassCompSave;
		private DevExpress.XtraEditors.SimpleButton btnMd_MemberCompSave;
		private DevExpress.XtraEditors.SimpleButton btnMd_CardCompSave;
		private DevExpress.XtraEditors.SimpleButton btnMd_UOBCompSave;
		private DevExpress.XtraEditors.SimpleButton btnMd_MiscCompSave;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.TextEdit EmployeeIdLastNo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCompany()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
			mdCompInit();
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
			this.grpMdCompanyTop = new DevExpress.XtraEditors.GroupControl();
			this.label2 = new System.Windows.Forms.Label();
			this.EmployeeIdLastNo = new DevExpress.XtraEditors.TextEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.tabCtrlMd_Company = new DevExpress.XtraTab.XtraTabControl();
			this.tabMdComp_Bank = new DevExpress.XtraTab.XtraTabPage();
			this.lk_MD_BankBranchCode = new DevExpress.XtraEditors.LookUpEdit();
			this.lk_MD_BankCode = new DevExpress.XtraEditors.LookUpEdit();
			this.mdComp_txtStrAccountNo = new DevExpress.XtraEditors.TextEdit();
			this.mdComp_txtStrAccountName = new DevExpress.XtraEditors.TextEdit();
			this.lblMdComp_BankAC_Num = new System.Windows.Forms.Label();
			this.lblMdComp_BankBranchCode = new System.Windows.Forms.Label();
			this.lblMdComp_BankACName = new System.Windows.Forms.Label();
			this.lblMdComp_BankCode = new System.Windows.Forms.Label();
			this.btnMd_BankCompSave = new DevExpress.XtraEditors.SimpleButton();
			this.tabComp_Payroll = new DevExpress.XtraTab.XtraTabPage();
			this.btnMd_PayrollCompSave = new DevExpress.XtraEditors.SimpleButton();
			this.mdComp_txtStrCPFReferenceNo = new DevExpress.XtraEditors.TextEdit();
			this.mdComp_txtStrCompanyID = new DevExpress.XtraEditors.TextEdit();
			this.mdComp_txtStrCompanyCodeRef = new DevExpress.XtraEditors.TextEdit();
			this.mdComp_txtStrBatchNo = new DevExpress.XtraEditors.TextEdit();
			this.lblMdComp_CPFRef = new System.Windows.Forms.Label();
			this.lblMdComp_ID = new System.Windows.Forms.Label();
			this.lblMdComp_CodeRef = new System.Windows.Forms.Label();
			this.lblMdComp_PayrBatchNo = new System.Windows.Forms.Label();
			this.tabComp_Class = new DevExpress.XtraTab.XtraTabPage();
			this.btnMd_ClassCompSave = new DevExpress.XtraEditors.SimpleButton();
			this.mdComp_txtMInstructorLateDeductionFee = new DevExpress.XtraEditors.TextEdit();
			this.mdComp_txtNCancelBookingLimit = new DevExpress.XtraEditors.TextEdit();
			this.lblMdComp_InstructorLateDeductionFee = new System.Windows.Forms.Label();
			this.lblMdComp_CancelBookingLimit = new System.Windows.Forms.Label();
			this.tabComp_Member = new DevExpress.XtraTab.XtraTabPage();
			this.btnMd_MemberCompSave = new DevExpress.XtraEditors.SimpleButton();
			this.mdComp_txtNClassLeft = new DevExpress.XtraEditors.TextEdit();
			this.mdComp_txtNDaysToExpire = new DevExpress.XtraEditors.TextEdit();
			this.mdComp_txtNNonMembershipNo = new DevExpress.XtraEditors.TextEdit();
			this.lblMdDesc = new System.Windows.Forms.Label();
			this.lblMdComp_ClassLeft = new System.Windows.Forms.Label();
			this.lblMdComp_DaysToExpire = new System.Windows.Forms.Label();
			this.lblMdComp_NonMembershipNo = new System.Windows.Forms.Label();
			this.tabComp_Card = new DevExpress.XtraTab.XtraTabPage();
			this.btnMd_CardCompSave = new DevExpress.XtraEditors.SimpleButton();
			this.mdComp_txtMRegistrationFees = new DevExpress.XtraEditors.TextEdit();
			this.mdComp_txtMReplaceCardRate = new DevExpress.XtraEditors.TextEdit();
			this.mdComp_txtMForgetCardRate = new DevExpress.XtraEditors.TextEdit();
			this.lblMdComp_RegFee = new System.Windows.Forms.Label();
			this.lblMdComp_ReplaceCardRate = new System.Windows.Forms.Label();
			this.lblMdComp_ForgetCardRate = new System.Windows.Forms.Label();
			this.tabComp_Misc = new DevExpress.XtraTab.XtraTabPage();
			this.btnMd_MiscCompSave = new DevExpress.XtraEditors.SimpleButton();
			this.btnMdComp_Directory2 = new DevExpress.XtraEditors.SimpleButton();
			this.btnMdComp_Directory1 = new DevExpress.XtraEditors.SimpleButton();
			this.mdComp_txtNMaxCarryForwardLeaveCF = new DevExpress.XtraEditors.TextEdit();
			this.mdComp_txtStrPayrollDir = new DevExpress.XtraEditors.TextEdit();
			this.mdComp_txtStrBJReportBranch = new DevExpress.XtraEditors.TextEdit();
			this.lblMdComp_LeaveCF = new System.Windows.Forms.Label();
			this.lblMdComp_PayrollDir = new System.Windows.Forms.Label();
			this.lblMdComp_BJReportBranch = new System.Windows.Forms.Label();
			this.tabComp_UOB = new DevExpress.XtraTab.XtraTabPage();
			this.btnMd_UOBCompSave = new DevExpress.XtraEditors.SimpleButton();
			this.lblMdComp_ResetDate = new System.Windows.Forms.Label();
			this.mdComp_dtUOBWeekendPeakEnd = new DevExpress.XtraEditors.TimeEdit();
			this.mdComp_dtUOBWeekdayPeakEnd = new DevExpress.XtraEditors.TimeEdit();
			this.mdComp_dtUOBWeekendPeakStart = new DevExpress.XtraEditors.TimeEdit();
			this.mdComp_dtUOBWeekdayPeakStart = new DevExpress.XtraEditors.TimeEdit();
			this.mdComp_txtNUOBMthlyBooking = new DevExpress.XtraEditors.TextEdit();
			this.lblMdComp_UOBWeekendPeakEnd = new System.Windows.Forms.Label();
			this.lblMdComp_UOBWeekendPeakStart = new System.Windows.Forms.Label();
			this.lblMdComp_UOBWeekdayPeakEnd = new System.Windows.Forms.Label();
			this.lblMdComp_UOBWeekdayPeakStart = new System.Windows.Forms.Label();
			this.lblMdComp_UOBMthlyBooking = new System.Windows.Forms.Label();
			this.mdComp_txtStrCompanyName = new DevExpress.XtraEditors.TextEdit();
			this.mdComp_txtStrCompanyCode = new DevExpress.XtraEditors.TextEdit();
			this.lblMdComp_Tax = new System.Windows.Forms.Label();
			this.lblMdCompany = new System.Windows.Forms.Label();
			this.lk_MD_ComTax = new DevExpress.XtraEditors.LookUpEdit();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			((System.ComponentModel.ISupportInitialize)(this.grpMdCompanyTop)).BeginInit();
			this.grpMdCompanyTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.EmployeeIdLastNo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tabCtrlMd_Company)).BeginInit();
			this.tabCtrlMd_Company.SuspendLayout();
			this.tabMdComp_Bank.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lk_MD_BankBranchCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_MD_BankCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtStrAccountNo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtStrAccountName.Properties)).BeginInit();
			this.tabComp_Payroll.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtStrCPFReferenceNo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtStrCompanyID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtStrCompanyCodeRef.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtStrBatchNo.Properties)).BeginInit();
			this.tabComp_Class.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtMInstructorLateDeductionFee.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtNCancelBookingLimit.Properties)).BeginInit();
			this.tabComp_Member.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtNClassLeft.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtNDaysToExpire.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtNNonMembershipNo.Properties)).BeginInit();
			this.tabComp_Card.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtMRegistrationFees.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtMReplaceCardRate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtMForgetCardRate.Properties)).BeginInit();
			this.tabComp_Misc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtNMaxCarryForwardLeaveCF.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtStrPayrollDir.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtStrBJReportBranch.Properties)).BeginInit();
			this.tabComp_UOB.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_dtUOBWeekendPeakEnd.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_dtUOBWeekdayPeakEnd.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_dtUOBWeekendPeakStart.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_dtUOBWeekdayPeakStart.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtNUOBMthlyBooking.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtStrCompanyName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtStrCompanyCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_MD_ComTax.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// grpMdCompanyTop
			// 
			this.grpMdCompanyTop.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.grpMdCompanyTop.Appearance.Options.UseBackColor = true;
			this.grpMdCompanyTop.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.grpMdCompanyTop.AppearanceCaption.Options.UseFont = true;
			this.grpMdCompanyTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.grpMdCompanyTop.Controls.Add(this.label2);
			this.grpMdCompanyTop.Controls.Add(this.EmployeeIdLastNo);
			this.grpMdCompanyTop.Controls.Add(this.label1);
			this.grpMdCompanyTop.Controls.Add(this.tabCtrlMd_Company);
			this.grpMdCompanyTop.Controls.Add(this.mdComp_txtStrCompanyName);
			this.grpMdCompanyTop.Controls.Add(this.mdComp_txtStrCompanyCode);
			this.grpMdCompanyTop.Controls.Add(this.lblMdComp_Tax);
			this.grpMdCompanyTop.Controls.Add(this.lblMdCompany);
			this.grpMdCompanyTop.Controls.Add(this.lk_MD_ComTax);
			this.grpMdCompanyTop.ImeMode = System.Windows.Forms.ImeMode.On;
			this.grpMdCompanyTop.Location = new System.Drawing.Point(8, 0);
			this.grpMdCompanyTop.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.grpMdCompanyTop.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpMdCompanyTop.LookAndFeel.UseWindowsXPTheme = false;
			this.grpMdCompanyTop.Name = "grpMdCompanyTop";
			this.grpMdCompanyTop.Size = new System.Drawing.Size(984, 568);
			this.grpMdCompanyTop.TabIndex = 27;
			this.grpMdCompanyTop.Text = "Company";
			this.grpMdCompanyTop.Click += new System.EventHandler(this.grpMdCompanyTop_Click);
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(24, 144);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 16);
			this.label2.TabIndex = 94;
			this.label2.Text = "Employee ID Last No";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// EmployeeIdLastNo
			// 
			this.EmployeeIdLastNo.EditValue = "";
			this.EmployeeIdLastNo.Location = new System.Drawing.Point(176, 144);
			this.EmployeeIdLastNo.Name = "EmployeeIdLastNo";
			// 
			// EmployeeIdLastNo.Properties
			// 
			this.EmployeeIdLastNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.EmployeeIdLastNo.Properties.Appearance.Options.UseFont = true;
			this.EmployeeIdLastNo.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.EmployeeIdLastNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.EmployeeIdLastNo.Properties.Mask.EditMask = "n0";
			this.EmployeeIdLastNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.EmployeeIdLastNo.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.EmployeeIdLastNo.Size = new System.Drawing.Size(72, 20);
			this.EmployeeIdLastNo.TabIndex = 93;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(24, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 16);
			this.label1.TabIndex = 92;
			this.label1.Text = "Company Name";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabCtrlMd_Company
			// 
			this.tabCtrlMd_Company.AppearancePage.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tabCtrlMd_Company.AppearancePage.Header.Options.UseFont = true;
			this.tabCtrlMd_Company.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tabCtrlMd_Company.Location = new System.Drawing.Point(8, 168);
			this.tabCtrlMd_Company.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.tabCtrlMd_Company.LookAndFeel.UseDefaultLookAndFeel = false;
			this.tabCtrlMd_Company.Name = "tabCtrlMd_Company";
			this.tabCtrlMd_Company.SelectedTabPage = this.tabMdComp_Bank;
			this.tabCtrlMd_Company.Size = new System.Drawing.Size(968, 248);
			this.tabCtrlMd_Company.TabIndex = 91;
			this.tabCtrlMd_Company.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
																							  this.tabMdComp_Bank,
																							  this.tabComp_Payroll,
																							  this.tabComp_Class,
																							  this.tabComp_Member,
																							  this.tabComp_Card,
																							  this.tabComp_Misc,
																							  this.tabComp_UOB});
			this.tabCtrlMd_Company.Text = "company";
			// 
			// tabMdComp_Bank
			// 
			this.tabMdComp_Bank.Appearance.PageClient.BackColor = System.Drawing.Color.LightGray;
			this.tabMdComp_Bank.Appearance.PageClient.Options.UseBackColor = true;
			this.tabMdComp_Bank.Controls.Add(this.lk_MD_BankBranchCode);
			this.tabMdComp_Bank.Controls.Add(this.lk_MD_BankCode);
			this.tabMdComp_Bank.Controls.Add(this.mdComp_txtStrAccountNo);
			this.tabMdComp_Bank.Controls.Add(this.mdComp_txtStrAccountName);
			this.tabMdComp_Bank.Controls.Add(this.lblMdComp_BankAC_Num);
			this.tabMdComp_Bank.Controls.Add(this.lblMdComp_BankBranchCode);
			this.tabMdComp_Bank.Controls.Add(this.lblMdComp_BankACName);
			this.tabMdComp_Bank.Controls.Add(this.lblMdComp_BankCode);
			this.tabMdComp_Bank.Controls.Add(this.btnMd_BankCompSave);
			this.tabMdComp_Bank.Name = "tabMdComp_Bank";
			this.tabMdComp_Bank.Size = new System.Drawing.Size(962, 219);
			this.tabMdComp_Bank.Text = "Bank";
			// 
			// lk_MD_BankBranchCode
			// 
			this.lk_MD_BankBranchCode.Location = new System.Drawing.Point(184, 64);
			this.lk_MD_BankBranchCode.Name = "lk_MD_BankBranchCode";
			// 
			// lk_MD_BankBranchCode.Properties
			// 
			this.lk_MD_BankBranchCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																														 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_MD_BankBranchCode.Size = new System.Drawing.Size(168, 20);
			this.lk_MD_BankBranchCode.TabIndex = 90;
			// 
			// lk_MD_BankCode
			// 
			this.lk_MD_BankCode.Location = new System.Drawing.Point(184, 32);
			this.lk_MD_BankCode.Name = "lk_MD_BankCode";
			// 
			// lk_MD_BankCode.Properties
			// 
			this.lk_MD_BankCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_MD_BankCode.Size = new System.Drawing.Size(168, 20);
			this.lk_MD_BankCode.TabIndex = 89;
			this.lk_MD_BankCode.EditValueChanged += new System.EventHandler(this.lk_MD_BankCode_EditValueChanged);
			// 
			// mdComp_txtStrAccountNo
			// 
			this.mdComp_txtStrAccountNo.EditValue = "";
			this.mdComp_txtStrAccountNo.Location = new System.Drawing.Point(184, 128);
			this.mdComp_txtStrAccountNo.Name = "mdComp_txtStrAccountNo";
			// 
			// mdComp_txtStrAccountNo.Properties
			// 
			this.mdComp_txtStrAccountNo.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdComp_txtStrAccountNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdComp_txtStrAccountNo.Size = new System.Drawing.Size(280, 20);
			this.mdComp_txtStrAccountNo.TabIndex = 85;
			// 
			// mdComp_txtStrAccountName
			// 
			this.mdComp_txtStrAccountName.EditValue = "";
			this.mdComp_txtStrAccountName.Location = new System.Drawing.Point(184, 96);
			this.mdComp_txtStrAccountName.Name = "mdComp_txtStrAccountName";
			// 
			// mdComp_txtStrAccountName.Properties
			// 
			this.mdComp_txtStrAccountName.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdComp_txtStrAccountName.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdComp_txtStrAccountName.Size = new System.Drawing.Size(280, 20);
			this.mdComp_txtStrAccountName.TabIndex = 84;
			// 
			// lblMdComp_BankAC_Num
			// 
			this.lblMdComp_BankAC_Num.BackColor = System.Drawing.Color.Transparent;
			this.lblMdComp_BankAC_Num.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdComp_BankAC_Num.Location = new System.Drawing.Point(40, 128);
			this.lblMdComp_BankAC_Num.Name = "lblMdComp_BankAC_Num";
			this.lblMdComp_BankAC_Num.Size = new System.Drawing.Size(136, 16);
			this.lblMdComp_BankAC_Num.TabIndex = 81;
			this.lblMdComp_BankAC_Num.Text = "Account Number";
			this.lblMdComp_BankAC_Num.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMdComp_BankBranchCode
			// 
			this.lblMdComp_BankBranchCode.BackColor = System.Drawing.Color.Transparent;
			this.lblMdComp_BankBranchCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdComp_BankBranchCode.Location = new System.Drawing.Point(40, 64);
			this.lblMdComp_BankBranchCode.Name = "lblMdComp_BankBranchCode";
			this.lblMdComp_BankBranchCode.Size = new System.Drawing.Size(136, 16);
			this.lblMdComp_BankBranchCode.TabIndex = 80;
			this.lblMdComp_BankBranchCode.Text = "Bank Branch Code";
			// 
			// lblMdComp_BankACName
			// 
			this.lblMdComp_BankACName.BackColor = System.Drawing.Color.Transparent;
			this.lblMdComp_BankACName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdComp_BankACName.Location = new System.Drawing.Point(40, 96);
			this.lblMdComp_BankACName.Name = "lblMdComp_BankACName";
			this.lblMdComp_BankACName.Size = new System.Drawing.Size(136, 16);
			this.lblMdComp_BankACName.TabIndex = 79;
			this.lblMdComp_BankACName.Text = "Account Name";
			this.lblMdComp_BankACName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMdComp_BankCode
			// 
			this.lblMdComp_BankCode.BackColor = System.Drawing.Color.Transparent;
			this.lblMdComp_BankCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdComp_BankCode.Location = new System.Drawing.Point(40, 32);
			this.lblMdComp_BankCode.Name = "lblMdComp_BankCode";
			this.lblMdComp_BankCode.Size = new System.Drawing.Size(136, 16);
			this.lblMdComp_BankCode.TabIndex = 78;
			this.lblMdComp_BankCode.Text = "Bank Code";
			// 
			// btnMd_BankCompSave
			// 
			this.btnMd_BankCompSave.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.btnMd_BankCompSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnMd_BankCompSave.Appearance.Options.UseBackColor = true;
			this.btnMd_BankCompSave.Appearance.Options.UseFont = true;
			this.btnMd_BankCompSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnMd_BankCompSave.Location = new System.Drawing.Point(8, 184);
			this.btnMd_BankCompSave.Name = "btnMd_BankCompSave";
			this.btnMd_BankCompSave.Size = new System.Drawing.Size(128, 20);
			this.btnMd_BankCompSave.TabIndex = 88;
			this.btnMd_BankCompSave.Text = "Update";
			this.btnMd_BankCompSave.Click += new System.EventHandler(this.btnMd_BankCompSave_Click);
			// 
			// tabComp_Payroll
			// 
			this.tabComp_Payroll.Appearance.PageClient.BackColor = System.Drawing.Color.LightGray;
			this.tabComp_Payroll.Appearance.PageClient.Options.UseBackColor = true;
			this.tabComp_Payroll.Controls.Add(this.btnMd_PayrollCompSave);
			this.tabComp_Payroll.Controls.Add(this.mdComp_txtStrCPFReferenceNo);
			this.tabComp_Payroll.Controls.Add(this.mdComp_txtStrCompanyID);
			this.tabComp_Payroll.Controls.Add(this.mdComp_txtStrCompanyCodeRef);
			this.tabComp_Payroll.Controls.Add(this.mdComp_txtStrBatchNo);
			this.tabComp_Payroll.Controls.Add(this.lblMdComp_CPFRef);
			this.tabComp_Payroll.Controls.Add(this.lblMdComp_ID);
			this.tabComp_Payroll.Controls.Add(this.lblMdComp_CodeRef);
			this.tabComp_Payroll.Controls.Add(this.lblMdComp_PayrBatchNo);
			this.tabComp_Payroll.Name = "tabComp_Payroll";
			this.tabComp_Payroll.Size = new System.Drawing.Size(962, 219);
			this.tabComp_Payroll.Text = "Payroll";
			// 
			// btnMd_PayrollCompSave
			// 
			this.btnMd_PayrollCompSave.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.btnMd_PayrollCompSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnMd_PayrollCompSave.Appearance.Options.UseBackColor = true;
			this.btnMd_PayrollCompSave.Appearance.Options.UseFont = true;
			this.btnMd_PayrollCompSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnMd_PayrollCompSave.Location = new System.Drawing.Point(8, 184);
			this.btnMd_PayrollCompSave.Name = "btnMd_PayrollCompSave";
			this.btnMd_PayrollCompSave.Size = new System.Drawing.Size(128, 20);
			this.btnMd_PayrollCompSave.TabIndex = 89;
			this.btnMd_PayrollCompSave.Text = "Update";
			this.btnMd_PayrollCompSave.Click += new System.EventHandler(this.btnMd_PayrollCompSave_Click);
			// 
			// mdComp_txtStrCPFReferenceNo
			// 
			this.mdComp_txtStrCPFReferenceNo.EditValue = "";
			this.mdComp_txtStrCPFReferenceNo.Location = new System.Drawing.Point(184, 128);
			this.mdComp_txtStrCPFReferenceNo.Name = "mdComp_txtStrCPFReferenceNo";
			// 
			// mdComp_txtStrCPFReferenceNo.Properties
			// 
			this.mdComp_txtStrCPFReferenceNo.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdComp_txtStrCPFReferenceNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdComp_txtStrCPFReferenceNo.Size = new System.Drawing.Size(280, 20);
			this.mdComp_txtStrCPFReferenceNo.TabIndex = 88;
			// 
			// mdComp_txtStrCompanyID
			// 
			this.mdComp_txtStrCompanyID.EditValue = "";
			this.mdComp_txtStrCompanyID.Location = new System.Drawing.Point(184, 96);
			this.mdComp_txtStrCompanyID.Name = "mdComp_txtStrCompanyID";
			// 
			// mdComp_txtStrCompanyID.Properties
			// 
			this.mdComp_txtStrCompanyID.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdComp_txtStrCompanyID.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdComp_txtStrCompanyID.Size = new System.Drawing.Size(280, 20);
			this.mdComp_txtStrCompanyID.TabIndex = 87;
			// 
			// mdComp_txtStrCompanyCodeRef
			// 
			this.mdComp_txtStrCompanyCodeRef.EditValue = "";
			this.mdComp_txtStrCompanyCodeRef.Location = new System.Drawing.Point(184, 64);
			this.mdComp_txtStrCompanyCodeRef.Name = "mdComp_txtStrCompanyCodeRef";
			// 
			// mdComp_txtStrCompanyCodeRef.Properties
			// 
			this.mdComp_txtStrCompanyCodeRef.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdComp_txtStrCompanyCodeRef.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdComp_txtStrCompanyCodeRef.Size = new System.Drawing.Size(280, 20);
			this.mdComp_txtStrCompanyCodeRef.TabIndex = 86;
			// 
			// mdComp_txtStrBatchNo
			// 
			this.mdComp_txtStrBatchNo.EditValue = "";
			this.mdComp_txtStrBatchNo.Location = new System.Drawing.Point(184, 32);
			this.mdComp_txtStrBatchNo.Name = "mdComp_txtStrBatchNo";
			// 
			// mdComp_txtStrBatchNo.Properties
			// 
			this.mdComp_txtStrBatchNo.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdComp_txtStrBatchNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdComp_txtStrBatchNo.Properties.Mask.EditMask = "f0";
			this.mdComp_txtStrBatchNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.mdComp_txtStrBatchNo.Size = new System.Drawing.Size(280, 20);
			this.mdComp_txtStrBatchNo.TabIndex = 85;
			// 
			// lblMdComp_CPFRef
			// 
			this.lblMdComp_CPFRef.BackColor = System.Drawing.Color.Transparent;
			this.lblMdComp_CPFRef.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdComp_CPFRef.Location = new System.Drawing.Point(32, 128);
			this.lblMdComp_CPFRef.Name = "lblMdComp_CPFRef";
			this.lblMdComp_CPFRef.Size = new System.Drawing.Size(144, 16);
			this.lblMdComp_CPFRef.TabIndex = 83;
			this.lblMdComp_CPFRef.Text = "CPF Ref #";
			this.lblMdComp_CPFRef.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMdComp_ID
			// 
			this.lblMdComp_ID.BackColor = System.Drawing.Color.Transparent;
			this.lblMdComp_ID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdComp_ID.Location = new System.Drawing.Point(32, 96);
			this.lblMdComp_ID.Name = "lblMdComp_ID";
			this.lblMdComp_ID.Size = new System.Drawing.Size(144, 16);
			this.lblMdComp_ID.TabIndex = 82;
			this.lblMdComp_ID.Text = "Company ID";
			this.lblMdComp_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMdComp_CodeRef
			// 
			this.lblMdComp_CodeRef.BackColor = System.Drawing.Color.Transparent;
			this.lblMdComp_CodeRef.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdComp_CodeRef.Location = new System.Drawing.Point(32, 64);
			this.lblMdComp_CodeRef.Name = "lblMdComp_CodeRef";
			this.lblMdComp_CodeRef.Size = new System.Drawing.Size(144, 16);
			this.lblMdComp_CodeRef.TabIndex = 81;
			this.lblMdComp_CodeRef.Text = "Company Code Ref #";
			this.lblMdComp_CodeRef.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMdComp_PayrBatchNo
			// 
			this.lblMdComp_PayrBatchNo.BackColor = System.Drawing.Color.Transparent;
			this.lblMdComp_PayrBatchNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdComp_PayrBatchNo.Location = new System.Drawing.Point(32, 32);
			this.lblMdComp_PayrBatchNo.Name = "lblMdComp_PayrBatchNo";
			this.lblMdComp_PayrBatchNo.Size = new System.Drawing.Size(144, 16);
			this.lblMdComp_PayrBatchNo.TabIndex = 80;
			this.lblMdComp_PayrBatchNo.Text = "Batch Number";
			this.lblMdComp_PayrBatchNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabComp_Class
			// 
			this.tabComp_Class.Appearance.PageClient.BackColor = System.Drawing.Color.LightGray;
			this.tabComp_Class.Appearance.PageClient.Options.UseBackColor = true;
			this.tabComp_Class.Controls.Add(this.btnMd_ClassCompSave);
			this.tabComp_Class.Controls.Add(this.mdComp_txtMInstructorLateDeductionFee);
			this.tabComp_Class.Controls.Add(this.mdComp_txtNCancelBookingLimit);
			this.tabComp_Class.Controls.Add(this.lblMdComp_InstructorLateDeductionFee);
			this.tabComp_Class.Controls.Add(this.lblMdComp_CancelBookingLimit);
			this.tabComp_Class.Name = "tabComp_Class";
			this.tabComp_Class.Size = new System.Drawing.Size(962, 219);
			this.tabComp_Class.Text = "Class";
			// 
			// btnMd_ClassCompSave
			// 
			this.btnMd_ClassCompSave.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.btnMd_ClassCompSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnMd_ClassCompSave.Appearance.Options.UseBackColor = true;
			this.btnMd_ClassCompSave.Appearance.Options.UseFont = true;
			this.btnMd_ClassCompSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnMd_ClassCompSave.Location = new System.Drawing.Point(8, 184);
			this.btnMd_ClassCompSave.Name = "btnMd_ClassCompSave";
			this.btnMd_ClassCompSave.Size = new System.Drawing.Size(128, 20);
			this.btnMd_ClassCompSave.TabIndex = 90;
			this.btnMd_ClassCompSave.Text = "Update";
			this.btnMd_ClassCompSave.Click += new System.EventHandler(this.btnMd_ClassCompSave_Click);
			// 
			// mdComp_txtMInstructorLateDeductionFee
			// 
			this.mdComp_txtMInstructorLateDeductionFee.EditValue = "";
			this.mdComp_txtMInstructorLateDeductionFee.Location = new System.Drawing.Point(264, 80);
			this.mdComp_txtMInstructorLateDeductionFee.Name = "mdComp_txtMInstructorLateDeductionFee";
			// 
			// mdComp_txtMInstructorLateDeductionFee.Properties
			// 
			this.mdComp_txtMInstructorLateDeductionFee.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdComp_txtMInstructorLateDeductionFee.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdComp_txtMInstructorLateDeductionFee.Properties.Mask.BeepOnError = true;
			this.mdComp_txtMInstructorLateDeductionFee.Properties.Mask.EditMask = "f0";
			this.mdComp_txtMInstructorLateDeductionFee.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.mdComp_txtMInstructorLateDeductionFee.Properties.MaxLength = 15;
			this.mdComp_txtMInstructorLateDeductionFee.Size = new System.Drawing.Size(136, 20);
			this.mdComp_txtMInstructorLateDeductionFee.TabIndex = 86;
			// 
			// mdComp_txtNCancelBookingLimit
			// 
			this.mdComp_txtNCancelBookingLimit.EditValue = "";
			this.mdComp_txtNCancelBookingLimit.Location = new System.Drawing.Point(264, 48);
			this.mdComp_txtNCancelBookingLimit.Name = "mdComp_txtNCancelBookingLimit";
			// 
			// mdComp_txtNCancelBookingLimit.Properties
			// 
			this.mdComp_txtNCancelBookingLimit.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdComp_txtNCancelBookingLimit.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdComp_txtNCancelBookingLimit.Properties.Mask.BeepOnError = true;
			this.mdComp_txtNCancelBookingLimit.Properties.Mask.EditMask = "f0";
			this.mdComp_txtNCancelBookingLimit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.mdComp_txtNCancelBookingLimit.Properties.MaxLength = 4;
			this.mdComp_txtNCancelBookingLimit.Size = new System.Drawing.Size(136, 20);
			this.mdComp_txtNCancelBookingLimit.TabIndex = 85;
			// 
			// lblMdComp_InstructorLateDeductionFee
			// 
			this.lblMdComp_InstructorLateDeductionFee.BackColor = System.Drawing.Color.Transparent;
			this.lblMdComp_InstructorLateDeductionFee.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdComp_InstructorLateDeductionFee.Location = new System.Drawing.Point(32, 80);
			this.lblMdComp_InstructorLateDeductionFee.Name = "lblMdComp_InstructorLateDeductionFee";
			this.lblMdComp_InstructorLateDeductionFee.Size = new System.Drawing.Size(224, 16);
			this.lblMdComp_InstructorLateDeductionFee.TabIndex = 83;
			this.lblMdComp_InstructorLateDeductionFee.Text = "Lateness Fee (Instructor)";
			this.lblMdComp_InstructorLateDeductionFee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMdComp_CancelBookingLimit
			// 
			this.lblMdComp_CancelBookingLimit.BackColor = System.Drawing.Color.Transparent;
			this.lblMdComp_CancelBookingLimit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdComp_CancelBookingLimit.Location = new System.Drawing.Point(32, 48);
			this.lblMdComp_CancelBookingLimit.Name = "lblMdComp_CancelBookingLimit";
			this.lblMdComp_CancelBookingLimit.Size = new System.Drawing.Size(256, 16);
			this.lblMdComp_CancelBookingLimit.TabIndex = 82;
			this.lblMdComp_CancelBookingLimit.Text = "Minimum Hour for Canceling Class";
			this.lblMdComp_CancelBookingLimit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabComp_Member
			// 
			this.tabComp_Member.Appearance.PageClient.BackColor = System.Drawing.Color.LightGray;
			this.tabComp_Member.Appearance.PageClient.Options.UseBackColor = true;
			this.tabComp_Member.Controls.Add(this.btnMd_MemberCompSave);
			this.tabComp_Member.Controls.Add(this.mdComp_txtNClassLeft);
			this.tabComp_Member.Controls.Add(this.mdComp_txtNDaysToExpire);
			this.tabComp_Member.Controls.Add(this.mdComp_txtNNonMembershipNo);
			this.tabComp_Member.Controls.Add(this.lblMdDesc);
			this.tabComp_Member.Controls.Add(this.lblMdComp_ClassLeft);
			this.tabComp_Member.Controls.Add(this.lblMdComp_DaysToExpire);
			this.tabComp_Member.Controls.Add(this.lblMdComp_NonMembershipNo);
			this.tabComp_Member.Name = "tabComp_Member";
			this.tabComp_Member.Size = new System.Drawing.Size(962, 219);
			this.tabComp_Member.Text = "Membership";
			// 
			// btnMd_MemberCompSave
			// 
			this.btnMd_MemberCompSave.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.btnMd_MemberCompSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnMd_MemberCompSave.Appearance.Options.UseBackColor = true;
			this.btnMd_MemberCompSave.Appearance.Options.UseFont = true;
			this.btnMd_MemberCompSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnMd_MemberCompSave.Location = new System.Drawing.Point(8, 184);
			this.btnMd_MemberCompSave.Name = "btnMd_MemberCompSave";
			this.btnMd_MemberCompSave.Size = new System.Drawing.Size(128, 20);
			this.btnMd_MemberCompSave.TabIndex = 90;
			this.btnMd_MemberCompSave.Text = "Update";
			this.btnMd_MemberCompSave.Click += new System.EventHandler(this.btnMd_MemberCompSave_Click);
			// 
			// mdComp_txtNClassLeft
			// 
			this.mdComp_txtNClassLeft.EditValue = "";
			this.mdComp_txtNClassLeft.Location = new System.Drawing.Point(304, 136);
			this.mdComp_txtNClassLeft.Name = "mdComp_txtNClassLeft";
			// 
			// mdComp_txtNClassLeft.Properties
			// 
			this.mdComp_txtNClassLeft.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdComp_txtNClassLeft.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdComp_txtNClassLeft.Properties.Mask.BeepOnError = true;
			this.mdComp_txtNClassLeft.Properties.Mask.EditMask = "f0";
			this.mdComp_txtNClassLeft.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.mdComp_txtNClassLeft.Size = new System.Drawing.Size(136, 20);
			this.mdComp_txtNClassLeft.TabIndex = 89;
			// 
			// mdComp_txtNDaysToExpire
			// 
			this.mdComp_txtNDaysToExpire.EditValue = "";
			this.mdComp_txtNDaysToExpire.Location = new System.Drawing.Point(304, 104);
			this.mdComp_txtNDaysToExpire.Name = "mdComp_txtNDaysToExpire";
			// 
			// mdComp_txtNDaysToExpire.Properties
			// 
			this.mdComp_txtNDaysToExpire.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdComp_txtNDaysToExpire.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdComp_txtNDaysToExpire.Properties.Mask.BeepOnError = true;
			this.mdComp_txtNDaysToExpire.Properties.Mask.EditMask = "f0";
			this.mdComp_txtNDaysToExpire.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.mdComp_txtNDaysToExpire.Size = new System.Drawing.Size(136, 20);
			this.mdComp_txtNDaysToExpire.TabIndex = 88;
			// 
			// mdComp_txtNNonMembershipNo
			// 
			this.mdComp_txtNNonMembershipNo.EditValue = "";
			this.mdComp_txtNNonMembershipNo.Location = new System.Drawing.Point(304, 40);
			this.mdComp_txtNNonMembershipNo.Name = "mdComp_txtNNonMembershipNo";
			// 
			// mdComp_txtNNonMembershipNo.Properties
			// 
			this.mdComp_txtNNonMembershipNo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.mdComp_txtNNonMembershipNo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.mdComp_txtNNonMembershipNo.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdComp_txtNNonMembershipNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdComp_txtNNonMembershipNo.Properties.Mask.EditMask = "f0";
			this.mdComp_txtNNonMembershipNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.mdComp_txtNNonMembershipNo.Size = new System.Drawing.Size(136, 20);
			this.mdComp_txtNNonMembershipNo.TabIndex = 87;
			// 
			// lblMdDesc
			// 
			this.lblMdDesc.BackColor = System.Drawing.Color.Transparent;
			this.lblMdDesc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdDesc.Location = new System.Drawing.Point(16, 72);
			this.lblMdDesc.Name = "lblMdDesc";
			this.lblMdDesc.Size = new System.Drawing.Size(272, 16);
			this.lblMdDesc.TabIndex = 86;
			this.lblMdDesc.Text = "Member Package is consider expired as : ";
			this.lblMdDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMdComp_ClassLeft
			// 
			this.lblMdComp_ClassLeft.BackColor = System.Drawing.Color.Transparent;
			this.lblMdComp_ClassLeft.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdComp_ClassLeft.Location = new System.Drawing.Point(16, 136);
			this.lblMdComp_ClassLeft.Name = "lblMdComp_ClassLeft";
			this.lblMdComp_ClassLeft.Size = new System.Drawing.Size(232, 16);
			this.lblMdComp_ClassLeft.TabIndex = 85;
			this.lblMdComp_ClassLeft.Text = "Number of Classes/Session Left";
			this.lblMdComp_ClassLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMdComp_DaysToExpire
			// 
			this.lblMdComp_DaysToExpire.BackColor = System.Drawing.Color.Transparent;
			this.lblMdComp_DaysToExpire.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdComp_DaysToExpire.Location = new System.Drawing.Point(16, 104);
			this.lblMdComp_DaysToExpire.Name = "lblMdComp_DaysToExpire";
			this.lblMdComp_DaysToExpire.Size = new System.Drawing.Size(232, 16);
			this.lblMdComp_DaysToExpire.TabIndex = 84;
			this.lblMdComp_DaysToExpire.Text = "Number of Days Left";
			this.lblMdComp_DaysToExpire.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMdComp_NonMembershipNo
			// 
			this.lblMdComp_NonMembershipNo.BackColor = System.Drawing.Color.Transparent;
			this.lblMdComp_NonMembershipNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdComp_NonMembershipNo.Location = new System.Drawing.Point(16, 40);
			this.lblMdComp_NonMembershipNo.Name = "lblMdComp_NonMembershipNo";
			this.lblMdComp_NonMembershipNo.Size = new System.Drawing.Size(264, 16);
			this.lblMdComp_NonMembershipNo.TabIndex = 83;
			this.lblMdComp_NonMembershipNo.Text = "Last non-membership number";
			this.lblMdComp_NonMembershipNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabComp_Card
			// 
			this.tabComp_Card.Appearance.PageClient.BackColor = System.Drawing.Color.LightGray;
			this.tabComp_Card.Appearance.PageClient.Options.UseBackColor = true;
			this.tabComp_Card.Controls.Add(this.btnMd_CardCompSave);
			this.tabComp_Card.Controls.Add(this.mdComp_txtMRegistrationFees);
			this.tabComp_Card.Controls.Add(this.mdComp_txtMReplaceCardRate);
			this.tabComp_Card.Controls.Add(this.mdComp_txtMForgetCardRate);
			this.tabComp_Card.Controls.Add(this.lblMdComp_RegFee);
			this.tabComp_Card.Controls.Add(this.lblMdComp_ReplaceCardRate);
			this.tabComp_Card.Controls.Add(this.lblMdComp_ForgetCardRate);
			this.tabComp_Card.Name = "tabComp_Card";
			this.tabComp_Card.Size = new System.Drawing.Size(962, 219);
			this.tabComp_Card.Text = "Card/Registration Fee";
			// 
			// btnMd_CardCompSave
			// 
			this.btnMd_CardCompSave.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.btnMd_CardCompSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnMd_CardCompSave.Appearance.Options.UseBackColor = true;
			this.btnMd_CardCompSave.Appearance.Options.UseFont = true;
			this.btnMd_CardCompSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnMd_CardCompSave.Location = new System.Drawing.Point(8, 184);
			this.btnMd_CardCompSave.Name = "btnMd_CardCompSave";
			this.btnMd_CardCompSave.Size = new System.Drawing.Size(128, 20);
			this.btnMd_CardCompSave.TabIndex = 91;
			this.btnMd_CardCompSave.Text = "Update";
			this.btnMd_CardCompSave.Click += new System.EventHandler(this.btnMd_CardCompSave_Click);
			// 
			// mdComp_txtMRegistrationFees
			// 
			this.mdComp_txtMRegistrationFees.EditValue = "";
			this.mdComp_txtMRegistrationFees.Location = new System.Drawing.Point(200, 96);
			this.mdComp_txtMRegistrationFees.Name = "mdComp_txtMRegistrationFees";
			// 
			// mdComp_txtMRegistrationFees.Properties
			// 
			this.mdComp_txtMRegistrationFees.Properties.DisplayFormat.FormatString = "c";
			this.mdComp_txtMRegistrationFees.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.mdComp_txtMRegistrationFees.Properties.EditFormat.FormatString = "c";
			this.mdComp_txtMRegistrationFees.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.mdComp_txtMRegistrationFees.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdComp_txtMRegistrationFees.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdComp_txtMRegistrationFees.Properties.Mask.EditMask = "c";
			this.mdComp_txtMRegistrationFees.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.mdComp_txtMRegistrationFees.Properties.MaxLength = 15;
			this.mdComp_txtMRegistrationFees.Size = new System.Drawing.Size(160, 20);
			this.mdComp_txtMRegistrationFees.TabIndex = 90;
			// 
			// mdComp_txtMReplaceCardRate
			// 
			this.mdComp_txtMReplaceCardRate.EditValue = "";
			this.mdComp_txtMReplaceCardRate.Location = new System.Drawing.Point(200, 64);
			this.mdComp_txtMReplaceCardRate.Name = "mdComp_txtMReplaceCardRate";
			// 
			// mdComp_txtMReplaceCardRate.Properties
			// 
			this.mdComp_txtMReplaceCardRate.Properties.DisplayFormat.FormatString = "c";
			this.mdComp_txtMReplaceCardRate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.mdComp_txtMReplaceCardRate.Properties.EditFormat.FormatString = "c";
			this.mdComp_txtMReplaceCardRate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.mdComp_txtMReplaceCardRate.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdComp_txtMReplaceCardRate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdComp_txtMReplaceCardRate.Properties.Mask.EditMask = "c";
			this.mdComp_txtMReplaceCardRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.mdComp_txtMReplaceCardRate.Properties.MaxLength = 15;
			this.mdComp_txtMReplaceCardRate.Size = new System.Drawing.Size(160, 20);
			this.mdComp_txtMReplaceCardRate.TabIndex = 89;
			// 
			// mdComp_txtMForgetCardRate
			// 
			this.mdComp_txtMForgetCardRate.EditValue = "";
			this.mdComp_txtMForgetCardRate.Location = new System.Drawing.Point(200, 32);
			this.mdComp_txtMForgetCardRate.Name = "mdComp_txtMForgetCardRate";
			// 
			// mdComp_txtMForgetCardRate.Properties
			// 
			this.mdComp_txtMForgetCardRate.Properties.DisplayFormat.FormatString = "c";
			this.mdComp_txtMForgetCardRate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.mdComp_txtMForgetCardRate.Properties.EditFormat.FormatString = "c";
			this.mdComp_txtMForgetCardRate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.mdComp_txtMForgetCardRate.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdComp_txtMForgetCardRate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdComp_txtMForgetCardRate.Properties.Mask.EditMask = "c";
			this.mdComp_txtMForgetCardRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.mdComp_txtMForgetCardRate.Properties.MaxLength = 15;
			this.mdComp_txtMForgetCardRate.Size = new System.Drawing.Size(160, 20);
			this.mdComp_txtMForgetCardRate.TabIndex = 88;
			// 
			// lblMdComp_RegFee
			// 
			this.lblMdComp_RegFee.BackColor = System.Drawing.Color.Transparent;
			this.lblMdComp_RegFee.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdComp_RegFee.Location = new System.Drawing.Point(40, 96);
			this.lblMdComp_RegFee.Name = "lblMdComp_RegFee";
			this.lblMdComp_RegFee.Size = new System.Drawing.Size(160, 16);
			this.lblMdComp_RegFee.TabIndex = 80;
			this.lblMdComp_RegFee.Text = "Registration Fee ($)";
			this.lblMdComp_RegFee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMdComp_ReplaceCardRate
			// 
			this.lblMdComp_ReplaceCardRate.BackColor = System.Drawing.Color.Transparent;
			this.lblMdComp_ReplaceCardRate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdComp_ReplaceCardRate.Location = new System.Drawing.Point(40, 64);
			this.lblMdComp_ReplaceCardRate.Name = "lblMdComp_ReplaceCardRate";
			this.lblMdComp_ReplaceCardRate.Size = new System.Drawing.Size(160, 16);
			this.lblMdComp_ReplaceCardRate.TabIndex = 79;
			this.lblMdComp_ReplaceCardRate.Text = "Replace Card Rate ($)";
			this.lblMdComp_ReplaceCardRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMdComp_ForgetCardRate
			// 
			this.lblMdComp_ForgetCardRate.BackColor = System.Drawing.Color.Transparent;
			this.lblMdComp_ForgetCardRate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdComp_ForgetCardRate.Location = new System.Drawing.Point(40, 32);
			this.lblMdComp_ForgetCardRate.Name = "lblMdComp_ForgetCardRate";
			this.lblMdComp_ForgetCardRate.Size = new System.Drawing.Size(160, 16);
			this.lblMdComp_ForgetCardRate.TabIndex = 78;
			this.lblMdComp_ForgetCardRate.Text = "Forget Card Rate ($)";
			this.lblMdComp_ForgetCardRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabComp_Misc
			// 
			this.tabComp_Misc.Appearance.PageClient.BackColor = System.Drawing.Color.LightGray;
			this.tabComp_Misc.Appearance.PageClient.Options.UseBackColor = true;
			this.tabComp_Misc.Controls.Add(this.btnMd_MiscCompSave);
			this.tabComp_Misc.Controls.Add(this.btnMdComp_Directory2);
			this.tabComp_Misc.Controls.Add(this.btnMdComp_Directory1);
			this.tabComp_Misc.Controls.Add(this.mdComp_txtNMaxCarryForwardLeaveCF);
			this.tabComp_Misc.Controls.Add(this.mdComp_txtStrPayrollDir);
			this.tabComp_Misc.Controls.Add(this.mdComp_txtStrBJReportBranch);
			this.tabComp_Misc.Controls.Add(this.lblMdComp_LeaveCF);
			this.tabComp_Misc.Controls.Add(this.lblMdComp_PayrollDir);
			this.tabComp_Misc.Controls.Add(this.lblMdComp_BJReportBranch);
			this.tabComp_Misc.Name = "tabComp_Misc";
			this.tabComp_Misc.Size = new System.Drawing.Size(962, 219);
			this.tabComp_Misc.Text = "Misc (Directory/Leave)";
			// 
			// btnMd_MiscCompSave
			// 
			this.btnMd_MiscCompSave.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.btnMd_MiscCompSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnMd_MiscCompSave.Appearance.Options.UseBackColor = true;
			this.btnMd_MiscCompSave.Appearance.Options.UseFont = true;
			this.btnMd_MiscCompSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnMd_MiscCompSave.Location = new System.Drawing.Point(8, 184);
			this.btnMd_MiscCompSave.Name = "btnMd_MiscCompSave";
			this.btnMd_MiscCompSave.Size = new System.Drawing.Size(128, 20);
			this.btnMd_MiscCompSave.TabIndex = 95;
			this.btnMd_MiscCompSave.Text = "Update";
			this.btnMd_MiscCompSave.Click += new System.EventHandler(this.btnMd_MiscCompSave_Click);
			// 
			// btnMdComp_Directory2
			// 
			this.btnMdComp_Directory2.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.btnMdComp_Directory2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnMdComp_Directory2.Appearance.Options.UseBackColor = true;
			this.btnMdComp_Directory2.Appearance.Options.UseFont = true;
			this.btnMdComp_Directory2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnMdComp_Directory2.Location = new System.Drawing.Point(520, 112);
			this.btnMdComp_Directory2.Name = "btnMdComp_Directory2";
			this.btnMdComp_Directory2.Size = new System.Drawing.Size(62, 20);
			this.btnMdComp_Directory2.TabIndex = 93;
			this.btnMdComp_Directory2.Text = "Browse";
			this.btnMdComp_Directory2.Click += new System.EventHandler(this.btnMdComp_Directory2_Click);
			// 
			// btnMdComp_Directory1
			// 
			this.btnMdComp_Directory1.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.btnMdComp_Directory1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnMdComp_Directory1.Appearance.Options.UseBackColor = true;
			this.btnMdComp_Directory1.Appearance.Options.UseFont = true;
			this.btnMdComp_Directory1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnMdComp_Directory1.Location = new System.Drawing.Point(520, 56);
			this.btnMdComp_Directory1.Name = "btnMdComp_Directory1";
			this.btnMdComp_Directory1.Size = new System.Drawing.Size(62, 20);
			this.btnMdComp_Directory1.TabIndex = 92;
			this.btnMdComp_Directory1.Text = "Browse";
			this.btnMdComp_Directory1.Click += new System.EventHandler(this.btnMdComp_Directory1_Click);
			// 
			// mdComp_txtNMaxCarryForwardLeaveCF
			// 
			this.mdComp_txtNMaxCarryForwardLeaveCF.EditValue = "";
			this.mdComp_txtNMaxCarryForwardLeaveCF.Location = new System.Drawing.Point(272, 136);
			this.mdComp_txtNMaxCarryForwardLeaveCF.Name = "mdComp_txtNMaxCarryForwardLeaveCF";
			// 
			// mdComp_txtNMaxCarryForwardLeaveCF.Properties
			// 
			this.mdComp_txtNMaxCarryForwardLeaveCF.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdComp_txtNMaxCarryForwardLeaveCF.Properties.Appearance.Options.UseFont = true;
			this.mdComp_txtNMaxCarryForwardLeaveCF.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdComp_txtNMaxCarryForwardLeaveCF.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdComp_txtNMaxCarryForwardLeaveCF.Properties.Mask.EditMask = "f0";
			this.mdComp_txtNMaxCarryForwardLeaveCF.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.mdComp_txtNMaxCarryForwardLeaveCF.Properties.MaxLength = 3;
			this.mdComp_txtNMaxCarryForwardLeaveCF.Size = new System.Drawing.Size(64, 22);
			this.mdComp_txtNMaxCarryForwardLeaveCF.TabIndex = 91;
			// 
			// mdComp_txtStrPayrollDir
			// 
			this.mdComp_txtStrPayrollDir.EditValue = "";
			this.mdComp_txtStrPayrollDir.Location = new System.Drawing.Point(32, 112);
			this.mdComp_txtStrPayrollDir.Name = "mdComp_txtStrPayrollDir";
			// 
			// mdComp_txtStrPayrollDir.Properties
			// 
			this.mdComp_txtStrPayrollDir.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.mdComp_txtStrPayrollDir.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdComp_txtStrPayrollDir.Properties.Appearance.Options.UseBackColor = true;
			this.mdComp_txtStrPayrollDir.Properties.Appearance.Options.UseFont = true;
			this.mdComp_txtStrPayrollDir.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdComp_txtStrPayrollDir.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdComp_txtStrPayrollDir.Size = new System.Drawing.Size(480, 22);
			this.mdComp_txtStrPayrollDir.TabIndex = 90;
			// 
			// mdComp_txtStrBJReportBranch
			// 
			this.mdComp_txtStrBJReportBranch.EditValue = "";
			this.mdComp_txtStrBJReportBranch.Location = new System.Drawing.Point(32, 56);
			this.mdComp_txtStrBJReportBranch.Name = "mdComp_txtStrBJReportBranch";
			// 
			// mdComp_txtStrBJReportBranch.Properties
			// 
			this.mdComp_txtStrBJReportBranch.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.mdComp_txtStrBJReportBranch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdComp_txtStrBJReportBranch.Properties.Appearance.Options.UseBackColor = true;
			this.mdComp_txtStrBJReportBranch.Properties.Appearance.Options.UseFont = true;
			this.mdComp_txtStrBJReportBranch.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdComp_txtStrBJReportBranch.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdComp_txtStrBJReportBranch.Size = new System.Drawing.Size(480, 22);
			this.mdComp_txtStrBJReportBranch.TabIndex = 89;
			// 
			// lblMdComp_LeaveCF
			// 
			this.lblMdComp_LeaveCF.BackColor = System.Drawing.Color.Transparent;
			this.lblMdComp_LeaveCF.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdComp_LeaveCF.Location = new System.Drawing.Point(32, 136);
			this.lblMdComp_LeaveCF.Name = "lblMdComp_LeaveCF";
			this.lblMdComp_LeaveCF.Size = new System.Drawing.Size(237, 16);
			this.lblMdComp_LeaveCF.TabIndex = 86;
			this.lblMdComp_LeaveCF.Text = "Number of leaves to carry forward";
			this.lblMdComp_LeaveCF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMdComp_PayrollDir
			// 
			this.lblMdComp_PayrollDir.BackColor = System.Drawing.Color.Transparent;
			this.lblMdComp_PayrollDir.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdComp_PayrollDir.Location = new System.Drawing.Point(32, 88);
			this.lblMdComp_PayrollDir.Name = "lblMdComp_PayrollDir";
			this.lblMdComp_PayrollDir.Size = new System.Drawing.Size(480, 16);
			this.lblMdComp_PayrollDir.TabIndex = 85;
			this.lblMdComp_PayrollDir.Text = "Directory where to write the Payroll Export File";
			this.lblMdComp_PayrollDir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMdComp_BJReportBranch
			// 
			this.lblMdComp_BJReportBranch.BackColor = System.Drawing.Color.Transparent;
			this.lblMdComp_BJReportBranch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdComp_BJReportBranch.Location = new System.Drawing.Point(32, 32);
			this.lblMdComp_BJReportBranch.Name = "lblMdComp_BJReportBranch";
			this.lblMdComp_BJReportBranch.Size = new System.Drawing.Size(480, 16);
			this.lblMdComp_BJReportBranch.TabIndex = 84;
			this.lblMdComp_BJReportBranch.Text = "Directory where to write the Sales for BJ branch";
			this.lblMdComp_BJReportBranch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabComp_UOB
			// 
			this.tabComp_UOB.Appearance.PageClient.BackColor = System.Drawing.Color.LightGray;
			this.tabComp_UOB.Appearance.PageClient.Options.UseBackColor = true;
			this.tabComp_UOB.Controls.Add(this.btnMd_UOBCompSave);
			this.tabComp_UOB.Controls.Add(this.lblMdComp_ResetDate);
			this.tabComp_UOB.Controls.Add(this.mdComp_dtUOBWeekendPeakEnd);
			this.tabComp_UOB.Controls.Add(this.mdComp_dtUOBWeekdayPeakEnd);
			this.tabComp_UOB.Controls.Add(this.mdComp_dtUOBWeekendPeakStart);
			this.tabComp_UOB.Controls.Add(this.mdComp_dtUOBWeekdayPeakStart);
			this.tabComp_UOB.Controls.Add(this.mdComp_txtNUOBMthlyBooking);
			this.tabComp_UOB.Controls.Add(this.lblMdComp_UOBWeekendPeakEnd);
			this.tabComp_UOB.Controls.Add(this.lblMdComp_UOBWeekendPeakStart);
			this.tabComp_UOB.Controls.Add(this.lblMdComp_UOBWeekdayPeakEnd);
			this.tabComp_UOB.Controls.Add(this.lblMdComp_UOBWeekdayPeakStart);
			this.tabComp_UOB.Controls.Add(this.lblMdComp_UOBMthlyBooking);
			this.tabComp_UOB.Name = "tabComp_UOB";
			this.tabComp_UOB.Size = new System.Drawing.Size(962, 219);
			this.tabComp_UOB.Text = "UOB Booking";
			// 
			// btnMd_UOBCompSave
			// 
			this.btnMd_UOBCompSave.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.btnMd_UOBCompSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnMd_UOBCompSave.Appearance.Options.UseBackColor = true;
			this.btnMd_UOBCompSave.Appearance.Options.UseFont = true;
			this.btnMd_UOBCompSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnMd_UOBCompSave.Location = new System.Drawing.Point(8, 184);
			this.btnMd_UOBCompSave.Name = "btnMd_UOBCompSave";
			this.btnMd_UOBCompSave.Size = new System.Drawing.Size(128, 20);
			this.btnMd_UOBCompSave.TabIndex = 94;
			this.btnMd_UOBCompSave.Text = "Update";
			this.btnMd_UOBCompSave.Click += new System.EventHandler(this.btnMd_UOBCompSave_Click);
			// 
			// lblMdComp_ResetDate
			// 
			this.lblMdComp_ResetDate.BackColor = System.Drawing.Color.Transparent;
			this.lblMdComp_ResetDate.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdComp_ResetDate.Location = new System.Drawing.Point(32, 136);
			this.lblMdComp_ResetDate.Name = "lblMdComp_ResetDate";
			this.lblMdComp_ResetDate.Size = new System.Drawing.Size(208, 16);
			this.lblMdComp_ResetDate.TabIndex = 93;
			this.lblMdComp_ResetDate.Text = "* Press the label to reset date";
			this.lblMdComp_ResetDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mdComp_dtUOBWeekendPeakEnd
			// 
			this.mdComp_dtUOBWeekendPeakEnd.EditValue = new System.DateTime(2005, 12, 15, 0, 0, 0, 0);
			this.mdComp_dtUOBWeekendPeakEnd.Location = new System.Drawing.Point(472, 104);
			this.mdComp_dtUOBWeekendPeakEnd.Name = "mdComp_dtUOBWeekendPeakEnd";
			// 
			// mdComp_dtUOBWeekendPeakEnd.Properties
			// 
			this.mdComp_dtUOBWeekendPeakEnd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdComp_dtUOBWeekendPeakEnd.Properties.Appearance.Options.UseFont = true;
			this.mdComp_dtUOBWeekendPeakEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															   new DevExpress.XtraEditors.Controls.EditorButton()});
			this.mdComp_dtUOBWeekendPeakEnd.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdComp_dtUOBWeekendPeakEnd.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdComp_dtUOBWeekendPeakEnd.Size = new System.Drawing.Size(75, 20);
			this.mdComp_dtUOBWeekendPeakEnd.TabIndex = 92;
			// 
			// mdComp_dtUOBWeekdayPeakEnd
			// 
			this.mdComp_dtUOBWeekdayPeakEnd.EditValue = new System.DateTime(2005, 12, 15, 0, 0, 0, 0);
			this.mdComp_dtUOBWeekdayPeakEnd.Location = new System.Drawing.Point(472, 72);
			this.mdComp_dtUOBWeekdayPeakEnd.Name = "mdComp_dtUOBWeekdayPeakEnd";
			// 
			// mdComp_dtUOBWeekdayPeakEnd.Properties
			// 
			this.mdComp_dtUOBWeekdayPeakEnd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdComp_dtUOBWeekdayPeakEnd.Properties.Appearance.Options.UseFont = true;
			this.mdComp_dtUOBWeekdayPeakEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																															   new DevExpress.XtraEditors.Controls.EditorButton()});
			this.mdComp_dtUOBWeekdayPeakEnd.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdComp_dtUOBWeekdayPeakEnd.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdComp_dtUOBWeekdayPeakEnd.Size = new System.Drawing.Size(75, 20);
			this.mdComp_dtUOBWeekdayPeakEnd.TabIndex = 91;
			// 
			// mdComp_dtUOBWeekendPeakStart
			// 
			this.mdComp_dtUOBWeekendPeakStart.EditValue = new System.DateTime(2005, 12, 15, 0, 0, 0, 0);
			this.mdComp_dtUOBWeekendPeakStart.Location = new System.Drawing.Point(248, 104);
			this.mdComp_dtUOBWeekendPeakStart.Name = "mdComp_dtUOBWeekendPeakStart";
			// 
			// mdComp_dtUOBWeekendPeakStart.Properties
			// 
			this.mdComp_dtUOBWeekendPeakStart.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.mdComp_dtUOBWeekendPeakStart.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdComp_dtUOBWeekendPeakStart.Properties.Appearance.Options.UseBackColor = true;
			this.mdComp_dtUOBWeekendPeakStart.Properties.Appearance.Options.UseFont = true;
			this.mdComp_dtUOBWeekendPeakStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																 new DevExpress.XtraEditors.Controls.EditorButton()});
			this.mdComp_dtUOBWeekendPeakStart.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdComp_dtUOBWeekendPeakStart.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdComp_dtUOBWeekendPeakStart.Size = new System.Drawing.Size(75, 20);
			this.mdComp_dtUOBWeekendPeakStart.TabIndex = 90;
			// 
			// mdComp_dtUOBWeekdayPeakStart
			// 
			this.mdComp_dtUOBWeekdayPeakStart.EditValue = new System.DateTime(2005, 12, 15, 0, 0, 0, 0);
			this.mdComp_dtUOBWeekdayPeakStart.Location = new System.Drawing.Point(248, 72);
			this.mdComp_dtUOBWeekdayPeakStart.Name = "mdComp_dtUOBWeekdayPeakStart";
			// 
			// mdComp_dtUOBWeekdayPeakStart.Properties
			// 
			this.mdComp_dtUOBWeekdayPeakStart.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
			this.mdComp_dtUOBWeekdayPeakStart.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.mdComp_dtUOBWeekdayPeakStart.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdComp_dtUOBWeekdayPeakStart.Properties.Appearance.Options.UseBackColor = true;
			this.mdComp_dtUOBWeekdayPeakStart.Properties.Appearance.Options.UseFont = true;
			this.mdComp_dtUOBWeekdayPeakStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																 new DevExpress.XtraEditors.Controls.EditorButton()});
			this.mdComp_dtUOBWeekdayPeakStart.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdComp_dtUOBWeekdayPeakStart.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdComp_dtUOBWeekdayPeakStart.Size = new System.Drawing.Size(75, 20);
			this.mdComp_dtUOBWeekdayPeakStart.TabIndex = 89;
			// 
			// mdComp_txtNUOBMthlyBooking
			// 
			this.mdComp_txtNUOBMthlyBooking.EditValue = "";
			this.mdComp_txtNUOBMthlyBooking.Location = new System.Drawing.Point(296, 32);
			this.mdComp_txtNUOBMthlyBooking.Name = "mdComp_txtNUOBMthlyBooking";
			// 
			// mdComp_txtNUOBMthlyBooking.Properties
			// 
			this.mdComp_txtNUOBMthlyBooking.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.mdComp_txtNUOBMthlyBooking.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdComp_txtNUOBMthlyBooking.Properties.Appearance.Options.UseBackColor = true;
			this.mdComp_txtNUOBMthlyBooking.Properties.Appearance.Options.UseFont = true;
			this.mdComp_txtNUOBMthlyBooking.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdComp_txtNUOBMthlyBooking.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdComp_txtNUOBMthlyBooking.Properties.Mask.BeepOnError = true;
			this.mdComp_txtNUOBMthlyBooking.Properties.Mask.EditMask = "f0";
			this.mdComp_txtNUOBMthlyBooking.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.mdComp_txtNUOBMthlyBooking.Properties.MaxLength = 3;
			this.mdComp_txtNUOBMthlyBooking.Size = new System.Drawing.Size(64, 20);
			this.mdComp_txtNUOBMthlyBooking.TabIndex = 88;
			// 
			// lblMdComp_UOBWeekendPeakEnd
			// 
			this.lblMdComp_UOBWeekendPeakEnd.BackColor = System.Drawing.Color.Transparent;
			this.lblMdComp_UOBWeekendPeakEnd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdComp_UOBWeekendPeakEnd.Location = new System.Drawing.Point(328, 104);
			this.lblMdComp_UOBWeekendPeakEnd.Name = "lblMdComp_UOBWeekendPeakEnd";
			this.lblMdComp_UOBWeekendPeakEnd.Size = new System.Drawing.Size(136, 16);
			this.lblMdComp_UOBWeekendPeakEnd.TabIndex = 87;
			this.lblMdComp_UOBWeekendPeakEnd.Text = "End of peak hours";
			this.lblMdComp_UOBWeekendPeakEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblMdComp_UOBWeekendPeakEnd.Click += new System.EventHandler(this.lblMdComp_UOBWeekendPeakEnd_Click);
			// 
			// lblMdComp_UOBWeekendPeakStart
			// 
			this.lblMdComp_UOBWeekendPeakStart.BackColor = System.Drawing.Color.Transparent;
			this.lblMdComp_UOBWeekendPeakStart.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdComp_UOBWeekendPeakStart.Location = new System.Drawing.Point(32, 104);
			this.lblMdComp_UOBWeekendPeakStart.Name = "lblMdComp_UOBWeekendPeakStart";
			this.lblMdComp_UOBWeekendPeakStart.Size = new System.Drawing.Size(208, 16);
			this.lblMdComp_UOBWeekendPeakStart.TabIndex = 86;
			this.lblMdComp_UOBWeekendPeakStart.Text = "(Weekend) Start of peak hours";
			this.lblMdComp_UOBWeekendPeakStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblMdComp_UOBWeekendPeakStart.Click += new System.EventHandler(this.lblMdComp_UOBWeekendPeakStart_Click);
			// 
			// lblMdComp_UOBWeekdayPeakEnd
			// 
			this.lblMdComp_UOBWeekdayPeakEnd.BackColor = System.Drawing.Color.Transparent;
			this.lblMdComp_UOBWeekdayPeakEnd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdComp_UOBWeekdayPeakEnd.Location = new System.Drawing.Point(328, 72);
			this.lblMdComp_UOBWeekdayPeakEnd.Name = "lblMdComp_UOBWeekdayPeakEnd";
			this.lblMdComp_UOBWeekdayPeakEnd.Size = new System.Drawing.Size(136, 16);
			this.lblMdComp_UOBWeekdayPeakEnd.TabIndex = 85;
			this.lblMdComp_UOBWeekdayPeakEnd.Text = "End of peak hours";
			this.lblMdComp_UOBWeekdayPeakEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblMdComp_UOBWeekdayPeakEnd.Click += new System.EventHandler(this.lblMdComp_UOBWeekdayPeakEnd_Click);
			// 
			// lblMdComp_UOBWeekdayPeakStart
			// 
			this.lblMdComp_UOBWeekdayPeakStart.BackColor = System.Drawing.Color.Transparent;
			this.lblMdComp_UOBWeekdayPeakStart.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdComp_UOBWeekdayPeakStart.Location = new System.Drawing.Point(32, 72);
			this.lblMdComp_UOBWeekdayPeakStart.Name = "lblMdComp_UOBWeekdayPeakStart";
			this.lblMdComp_UOBWeekdayPeakStart.Size = new System.Drawing.Size(224, 16);
			this.lblMdComp_UOBWeekdayPeakStart.TabIndex = 84;
			this.lblMdComp_UOBWeekdayPeakStart.Text = "(Weekdays) Start of peak hours";
			this.lblMdComp_UOBWeekdayPeakStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblMdComp_UOBWeekdayPeakStart.Click += new System.EventHandler(this.lblMdComp_UOBWeekdayPeakStart_Click);
			// 
			// lblMdComp_UOBMthlyBooking
			// 
			this.lblMdComp_UOBMthlyBooking.BackColor = System.Drawing.Color.Transparent;
			this.lblMdComp_UOBMthlyBooking.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdComp_UOBMthlyBooking.Location = new System.Drawing.Point(32, 32);
			this.lblMdComp_UOBMthlyBooking.Name = "lblMdComp_UOBMthlyBooking";
			this.lblMdComp_UOBMthlyBooking.Size = new System.Drawing.Size(256, 16);
			this.lblMdComp_UOBMthlyBooking.TabIndex = 83;
			this.lblMdComp_UOBMthlyBooking.Text = "Allowed number of booking (month)";
			this.lblMdComp_UOBMthlyBooking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mdComp_txtStrCompanyName
			// 
			this.mdComp_txtStrCompanyName.EditValue = "";
			this.mdComp_txtStrCompanyName.Location = new System.Drawing.Point(176, 80);
			this.mdComp_txtStrCompanyName.Name = "mdComp_txtStrCompanyName";
			// 
			// mdComp_txtStrCompanyName.Properties
			// 
			this.mdComp_txtStrCompanyName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdComp_txtStrCompanyName.Properties.Appearance.Options.UseFont = true;
			this.mdComp_txtStrCompanyName.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdComp_txtStrCompanyName.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdComp_txtStrCompanyName.Size = new System.Drawing.Size(272, 20);
			this.mdComp_txtStrCompanyName.TabIndex = 86;
			// 
			// mdComp_txtStrCompanyCode
			// 
			this.mdComp_txtStrCompanyCode.EditValue = "";
			this.mdComp_txtStrCompanyCode.Enabled = false;
			this.mdComp_txtStrCompanyCode.Location = new System.Drawing.Point(176, 48);
			this.mdComp_txtStrCompanyCode.Name = "mdComp_txtStrCompanyCode";
			// 
			// mdComp_txtStrCompanyCode.Properties
			// 
			this.mdComp_txtStrCompanyCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mdComp_txtStrCompanyCode.Properties.Appearance.Options.UseFont = true;
			this.mdComp_txtStrCompanyCode.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.mdComp_txtStrCompanyCode.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.mdComp_txtStrCompanyCode.Size = new System.Drawing.Size(104, 20);
			this.mdComp_txtStrCompanyCode.TabIndex = 85;
			// 
			// lblMdComp_Tax
			// 
			this.lblMdComp_Tax.BackColor = System.Drawing.Color.Transparent;
			this.lblMdComp_Tax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdComp_Tax.Location = new System.Drawing.Point(24, 112);
			this.lblMdComp_Tax.Name = "lblMdComp_Tax";
			this.lblMdComp_Tax.Size = new System.Drawing.Size(136, 16);
			this.lblMdComp_Tax.TabIndex = 83;
			this.lblMdComp_Tax.Text = "Tax Reference";
			this.lblMdComp_Tax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMdCompany
			// 
			this.lblMdCompany.BackColor = System.Drawing.Color.Transparent;
			this.lblMdCompany.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMdCompany.Location = new System.Drawing.Point(24, 48);
			this.lblMdCompany.Name = "lblMdCompany";
			this.lblMdCompany.Size = new System.Drawing.Size(144, 16);
			this.lblMdCompany.TabIndex = 82;
			this.lblMdCompany.Text = "Company Code/Name";
			this.lblMdCompany.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lk_MD_ComTax
			// 
			this.lk_MD_ComTax.Location = new System.Drawing.Point(176, 112);
			this.lk_MD_ComTax.Name = "lk_MD_ComTax";
			// 
			// lk_MD_ComTax.Properties
			// 
			this.lk_MD_ComTax.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lk_MD_ComTax.Size = new System.Drawing.Size(128, 20);
			this.lk_MD_ComTax.TabIndex = 89;
			// 
			// frmCompany
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1000, 570);
			this.Controls.Add(this.grpMdCompanyTop);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmCompany";
			this.Text = "frmCompany";
			((System.ComponentModel.ISupportInitialize)(this.grpMdCompanyTop)).EndInit();
			this.grpMdCompanyTop.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.EmployeeIdLastNo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tabCtrlMd_Company)).EndInit();
			this.tabCtrlMd_Company.ResumeLayout(false);
			this.tabMdComp_Bank.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lk_MD_BankBranchCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_MD_BankCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtStrAccountNo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtStrAccountName.Properties)).EndInit();
			this.tabComp_Payroll.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtStrCPFReferenceNo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtStrCompanyID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtStrCompanyCodeRef.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtStrBatchNo.Properties)).EndInit();
			this.tabComp_Class.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtMInstructorLateDeductionFee.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtNCancelBookingLimit.Properties)).EndInit();
			this.tabComp_Member.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtNClassLeft.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtNDaysToExpire.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtNNonMembershipNo.Properties)).EndInit();
			this.tabComp_Card.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtMRegistrationFees.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtMReplaceCardRate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtMForgetCardRate.Properties)).EndInit();
			this.tabComp_Misc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtNMaxCarryForwardLeaveCF.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtStrPayrollDir.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtStrBJReportBranch.Properties)).EndInit();
			this.tabComp_UOB.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mdComp_dtUOBWeekendPeakEnd.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_dtUOBWeekdayPeakEnd.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_dtUOBWeekendPeakStart.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_dtUOBWeekdayPeakStart.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtNUOBMthlyBooking.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtStrCompanyName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdComp_txtStrCompanyCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lk_MD_ComTax.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Company

		private void mdCompInit()
		{ 
//			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
//
//			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchCode","BranchCode",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
//			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchName","Branch Name",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
		
			string strSQL;
			DataSet _ds = new DataSet();
			strSQL = "Select * from TblTax"; 
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];		
	
			myTax = new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lk_MD_ComTax.Properties,dt,"strDescription","nTaxID","Tax");
			myBankCode = new ACMS.XtraUtils.LookupEditBuilder.BankCodeLookupEditBuilder(lk_MD_BankCode.Properties);
			
			myBankBranchCode = new ACMS.XtraUtils.LookupEditBuilder.BankBranchCodeLookupEditBuilder(lk_MD_BankBranchCode.Properties,"");

			
			DataSet _dsTblCompany = new DataSet();
			strSQL = "select * from tblCompany";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_dsTblCompany,new string[] {"Company"}, new SqlParameter("@strSQL", strSQL) );
						
			foreach(DataRow dr in _dsTblCompany.Tables["Company"].Rows)
			{
				mdComp_txtStrCompanyCode.EditValue = dr["strCompanyCode"].ToString();
				mdComp_txtStrCompanyName.EditValue = dr["strCompanyName"].ToString();
				EmployeeIdLastNo.EditValue = dr["EmployeeIdLastNo"].ToString();
				this.lk_MD_ComTax.EditValue = dr["nTaxID"];
				this.mdComp_txtMForgetCardRate.EditValue = dr["mForgetCardRate"];
				this.mdComp_txtMReplaceCardRate.EditValue = dr["mReplaceCardRate"];
				this.mdComp_txtMRegistrationFees.EditValue = dr["mRegistrationFees"];
				this.lk_MD_BankCode.EditValue = dr["strBankCode"];
				this.lk_MD_BankBranchCode.EditValue = dr["strBranchCode"];
				this.mdComp_txtStrAccountName.EditValue = dr["strAccountName"];
				this.mdComp_txtStrAccountNo.EditValue = dr["strAccountNo"];
				this.mdComp_txtStrBatchNo.EditValue = dr["strBatchNo"];
				this.mdComp_txtStrCompanyCodeRef.EditValue = dr["strCompanyCodeRef"];
				this.mdComp_txtStrCompanyID.EditValue = dr["strCompanyID"];
				this.mdComp_txtStrCPFReferenceNo.EditValue = dr["strCPFReferenceNo"];
				this.mdComp_txtNCancelBookingLimit.EditValue = dr["nCancelBookingLimit"];
				this.mdComp_txtMInstructorLateDeductionFee.EditValue = dr["mInstructorLateDeductionFee"];
				this.mdComp_txtNUOBMthlyBooking.EditValue = dr["nUOBMonthlyBooking"];
				this.mdComp_dtUOBWeekdayPeakStart.EditValue = dr["dtUOBWeekdayPeakStart"];
				this.mdComp_dtUOBWeekdayPeakEnd.EditValue = dr["dtUOBWeekdayPeakEnd"];
				this.mdComp_dtUOBWeekendPeakStart.EditValue = dr["dtUOBWeekendPeakStart"];
				this.mdComp_dtUOBWeekendPeakEnd.EditValue = dr["dtUOBWeekendPeakEnd"];
				this.mdComp_txtNNonMembershipNo.EditValue = dr["nNonMembershipNo"];
				this.mdComp_txtNDaysToExpire.EditValue = dr["nDaysToExpire"];
				this.mdComp_txtNClassLeft.EditValue = dr["nClassLeft"];
				this.mdComp_txtStrBJReportBranch.EditValue = dr["strBJReportDir"];
				this.mdComp_txtStrPayrollDir.EditValue = dr["strPayrollDir"];
				this.mdComp_txtNMaxCarryForwardLeaveCF.EditValue = dr["nMaxCarryForwardLeave"];			
			}


		}

		private void lblMdComp_UOBWeekdayPeakStart_Click(object sender, System.EventArgs e)
		{
			mdComp_dtUOBWeekdayPeakStart.EditValue = System.DBNull.Value;
		}

		private void lblMdComp_UOBWeekendPeakStart_Click(object sender, System.EventArgs e)
		{
			mdComp_dtUOBWeekendPeakStart.EditValue = System.DBNull.Value;
		}

		private void lblMdComp_UOBWeekdayPeakEnd_Click(object sender, System.EventArgs e)
		{
			mdComp_dtUOBWeekdayPeakEnd.EditValue = System.DBNull.Value;
		}

		private void lblMdComp_UOBWeekendPeakEnd_Click(object sender, System.EventArgs e)
		{
			mdComp_dtUOBWeekendPeakEnd.EditValue = System.DBNull.Value;
		}

		private void mdComp_cbStrBankCode_SelectedValueChanged(object sender, System.EventArgs e)
		{
//			string strSQL;
//			strSQL = "select * from tblBankBranch where strBankCode='" + mdComp_cbStrBankCode.EditValue.ToString() + "'";
//			comboBind(mdComp_cbStrBranchCode,strSQL,"strDescription","strBankBranchCode");
		}

		private void lk_MD_BankCode_EditValueChanged(object sender, System.EventArgs e)
		{
			string BankCode = "";

			if (lk_MD_BankCode.EditValue != null) 
				BankCode = lk_MD_BankCode.EditValue.ToString();

			myBankBranchCode.Refresh(BankCode);
		}

		private void btnMdComp_Directory1_Click(object sender, System.EventArgs e)
		{
			//Bug fixed on 11 Jan: issue 1.1.1
			folderBrowserDialog1.ShowDialog();
			this.mdComp_txtStrBJReportBranch.Text = folderBrowserDialog1.SelectedPath;
		}

		private void btnMdComp_Directory2_Click(object sender, System.EventArgs e)
		{
			//Bug fixed on 11 Jan: issue 1.1.2
			folderBrowserDialog1.ShowDialog();
			this.mdComp_txtStrPayrollDir.Text = folderBrowserDialog1.SelectedPath;
		}

		private void btnMd_CompSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (MdComp_FieldValidation())
				{
					SqlHelper.ExecuteNonQuery(connection,"up_tblCompany",
						new SqlParameter("@cmd","U"),
						new SqlParameter("@strCompanyCode",mdComp_txtStrCompanyCode.EditValue.ToString()),
						new SqlParameter("@strCompanyName",mdComp_txtStrCompanyName.EditValue.ToString()),
						new SqlParameter("@nTaxID",Convert.ToInt16(this.lk_MD_ComTax.EditValue)),
						new SqlParameter("@mForgetCardRate",Convert.ToDecimal(this.mdComp_txtMForgetCardRate.EditValue)),
						new SqlParameter("@mReplaceCardRate",Convert.ToDecimal(this.mdComp_txtMReplaceCardRate.EditValue)),
						new SqlParameter("@mRegistrationFees",Convert.ToDecimal(this.mdComp_txtMRegistrationFees.EditValue)),
						new SqlParameter("@strBankCode",this.lk_MD_BankCode.EditValue ),
						new SqlParameter("@strBranchCode",this.lk_MD_BankBranchCode.EditValue ),
						new SqlParameter("@strAccountNo",this.mdComp_txtStrAccountNo.EditValue.ToString()),
						new SqlParameter("@strAccountName",this.mdComp_txtStrAccountName.EditValue.ToString()),
						new SqlParameter("@strBatchNo",Convert.ToInt32(this.mdComp_txtStrBatchNo.EditValue)),
						new SqlParameter("@strCompanyCodeRef",this.mdComp_txtStrCompanyCodeRef.EditValue.ToString()),
						new SqlParameter("@strCompanyID",this.mdComp_txtStrCompanyID.EditValue.ToString()),
						new SqlParameter("@strCPFReferenceNo",this.mdComp_txtStrCPFReferenceNo.EditValue.ToString()),
						new SqlParameter("@nCancelBookingLimit",Convert.ToInt32(this.mdComp_txtNCancelBookingLimit.EditValue)),
						new SqlParameter("@nUOBMonthlyBooking",Convert.ToInt32(this.mdComp_txtNUOBMthlyBooking.EditValue)),
						new SqlParameter("@dtUOBWeekdayPeakStart",ConvertToDateTime(this.mdComp_dtUOBWeekdayPeakStart.EditValue) ),
						new SqlParameter("@dtUOBWeekdayPeakEnd",ConvertToDateTime(this.mdComp_dtUOBWeekdayPeakEnd.EditValue) ),
						new SqlParameter("@dtUOBWeekendPeakStart",ConvertToDateTime(this.mdComp_dtUOBWeekendPeakStart.EditValue) ),
						new SqlParameter("@dtUOBWeekendPeakEnd",ConvertToDateTime(this.mdComp_dtUOBWeekendPeakEnd.EditValue) ),
						new SqlParameter("@nNonMembershipNo",Convert.ToInt32(this.mdComp_txtNNonMembershipNo.EditValue)),
						new SqlParameter("@mInstructorLateDeductionFee",Convert.ToDecimal(this.mdComp_txtMInstructorLateDeductionFee.EditValue)),
						new SqlParameter("@nDaysToExpire",Convert.ToInt32(this.mdComp_txtNDaysToExpire.EditValue)),
						new SqlParameter("@nClassLeft",Convert.ToInt32(this.mdComp_txtNClassLeft.EditValue)),
						new SqlParameter("@strBJReportDir",this.mdComp_txtStrBJReportBranch.EditValue.ToString()),
						new SqlParameter("@strPayrollDir",this.mdComp_txtStrPayrollDir.EditValue.ToString()),
						new SqlParameter("@nMaxCarryForwardLeave",Convert.ToInt32(this.mdComp_txtNMaxCarryForwardLeaveCF.EditValue))
						);
				}

			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message ,"Update Failed");
				return;
			}
			MessageBox.Show("Company Profile Update Successfully","Message");

		}

		private bool MdComp_FieldValidation()
		{
			if (this.lk_MD_ComTax.EditValue.ToString() == "")
			{
				MessageBox.Show("Tax ID is blank.","Error Message");
				return false;
			}
			else if(this.lk_MD_BankBranchCode.EditValue.ToString() == "")
			{
				MessageBox.Show("Branch value is blank.","Error Message");
				return false;
			}
			else if(this.lk_MD_BankCode.EditValue.ToString() == "")
			{
				MessageBox.Show("Bank Code value is blank.","Error Message");
				return false;
			}
			return true;
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

		private void btnMd_BankCompSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (MdComp_FieldValidation())
				{
					string upd = "Update TblCompany Set strCompanyName = '" + mdComp_txtStrCompanyName.EditValue.ToString() + "'" +
						", nTaxID = " + Convert.ToInt32(this.lk_MD_ComTax.EditValue) +
						", employeeIdLastNo = " + Convert.ToInt32(this.EmployeeIdLastNo.EditValue) +
						", strBankCode = '" + this.lk_MD_BankCode.EditValue.ToString() + "'" +
						", strBranchCode = '" + this.lk_MD_BankBranchCode.EditValue.ToString() + "'" +
						", strAccountName = '" + this.mdComp_txtStrAccountName.EditValue.ToString() + "'" +
						", strAccountNo = '" + this.mdComp_txtStrAccountNo.EditValue.ToString() + "'";

					SqlHelper.ExecuteNonQuery(connection,System.Data.CommandType.Text,upd);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message ,"Update Failed");
				return;
			}
			MessageBox.Show("Update Successfully.","Message");
		}

		
		private void btnMd_PayrollCompSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (MdComp_FieldValidation())
				{
					string upd = "Update TblCompany Set strCompanyName = '" + mdComp_txtStrCompanyName.EditValue.ToString() + "'" +
						", nTaxID = " + Convert.ToInt32(this.lk_MD_ComTax.EditValue) +
						", employeeIdLastNo = " + Convert.ToInt32(this.EmployeeIdLastNo.EditValue) +
						", strBatchNo = '" + this.mdComp_txtStrBatchNo.EditValue.ToString() + "'" +
						", strCompanyCodeRef = '" + this.mdComp_txtStrCompanyCodeRef.EditValue.ToString() + "'" +
						", strCompanyID = '" + this.mdComp_txtStrCompanyID.EditValue.ToString() + "'" +
						", strCPFReferenceNo = '" + this.mdComp_txtStrCPFReferenceNo.EditValue.ToString() + "'";

					SqlHelper.ExecuteNonQuery(connection,System.Data.CommandType.Text,upd);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message ,"Update Failed");
				return;
			}
			MessageBox.Show("Update Successfully.","Message");
		}

		private void btnMd_ClassCompSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (MdComp_FieldValidation())
				{
					string upd = "Update TblCompany Set strCompanyName = '" + mdComp_txtStrCompanyName.EditValue.ToString() + "'" +
						", nTaxID = " + Convert.ToInt32(this.lk_MD_ComTax.EditValue) +
						", employeeIdLastNo = " + Convert.ToInt32(this.EmployeeIdLastNo.EditValue) +
						", nCancelBookingLimit = " + this.mdComp_txtNCancelBookingLimit.EditValue.ToString() + 
						", mInstructorLateDeductionFee = " + this.mdComp_txtMInstructorLateDeductionFee.EditValue.ToString();
					
					SqlHelper.ExecuteNonQuery(connection,System.Data.CommandType.Text,upd);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message ,"Update Failed");
				return;
			}
			MessageBox.Show("Update Successfully.","Message");
		}

		

		private void btnMd_MemberCompSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (MdComp_FieldValidation())
				{
					string upd = "Update TblCompany Set strCompanyName = '" + mdComp_txtStrCompanyName.EditValue.ToString() + "'" +
						", nTaxID = " + Convert.ToInt32(this.lk_MD_ComTax.EditValue) +
						", employeeIdLastNo = " + Convert.ToInt32(this.EmployeeIdLastNo.EditValue) +
						", nNonMembershipNo = '" + this.mdComp_txtNNonMembershipNo.EditValue.ToString() + "'" +
						", nDaysToExpire = '" + this.mdComp_txtNDaysToExpire.EditValue.ToString() + "'" +
						", nClassLeft = '" + this.mdComp_txtNClassLeft.EditValue.ToString() + "'";
						
					SqlHelper.ExecuteNonQuery(connection,System.Data.CommandType.Text,upd);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message ,"Update Failed");
				return;
			}
			MessageBox.Show("Update Successfully.","Message");
		}


		private void btnMd_CardCompSave_Click(object sender, System.EventArgs e)
		{
		
			try
			{
				if (MdComp_FieldValidation())
				{
					string upd = "Update TblCompany Set strCompanyName = '" + mdComp_txtStrCompanyName.EditValue.ToString() + "'" +
						", nTaxID = " + Convert.ToInt32(this.lk_MD_ComTax.EditValue) +
						", employeeIdLastNo = " + Convert.ToInt32(this.EmployeeIdLastNo.EditValue) +
						", mForgetCardRate = " + Convert.ToDecimal(this.mdComp_txtMForgetCardRate.EditValue) +
						", mReplaceCardRate = " + Convert.ToDecimal(this.mdComp_txtMReplaceCardRate.EditValue) +
						", mRegistrationFees = " + Convert.ToDecimal(this.mdComp_txtMRegistrationFees.EditValue);
						
						SqlHelper.ExecuteNonQuery(connection,System.Data.CommandType.Text,upd);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message ,"Update Failed");
				return;
			}
			MessageBox.Show("Update Successfully.","Message");
		}

		private void btnMd_UOBCompSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (MdComp_FieldValidation())
				{
					string upd = "Update TblCompany Set strCompanyName = '" + mdComp_txtStrCompanyName.EditValue.ToString() + "'" +
						", nTaxID = " + Convert.ToInt32(this.lk_MD_ComTax.EditValue) +
						", employeeIdLastNo = " + Convert.ToInt32(this.EmployeeIdLastNo.EditValue) +
						", nUOBMonthlyBooking = '" + this.mdComp_txtNUOBMthlyBooking.EditValue.ToString() + "'" +
						", dtUOBWeekdayPeakStart = '" + this.mdComp_dtUOBWeekdayPeakStart.EditValue.ToString() + "'" +
						", dtUOBWeekdayPeakEnd = '" + this.mdComp_dtUOBWeekdayPeakEnd.EditValue.ToString() + "'" +
						", dtUOBWeekendPeakStart = '" + this.mdComp_dtUOBWeekendPeakStart.EditValue.ToString() + "'" +
						", dtUOBWeekendPeakEnd = '" + this.mdComp_dtUOBWeekendPeakEnd.EditValue.ToString() + "'";
					
						SqlHelper.ExecuteNonQuery(connection,System.Data.CommandType.Text,upd);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message ,"Update Failed");
				return;
			}
			MessageBox.Show("Update Successfully.","Message");
		}

		private void btnMd_MiscCompSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (MdComp_FieldValidation())
				{
					string upd = "Update TblCompany Set strCompanyName = '" + mdComp_txtStrCompanyName.EditValue.ToString() + "'" +
						", nTaxID = " + ConvertToInt(this.lk_MD_ComTax.EditValue) +
						", employeeIdLastNo = " + ConvertToInt(this.EmployeeIdLastNo.EditValue) +
						", strBJReportDir = '" + this.mdComp_txtStrBJReportBranch.EditValue.ToString() + "'" +
						", strPayrollDir = '" + this.mdComp_txtStrPayrollDir.EditValue.ToString() + "'" +
						", nMaxCarryForwardLeave = '" + this.mdComp_txtNMaxCarryForwardLeaveCF.EditValue.ToString() + "'";
						
					SqlHelper.ExecuteNonQuery(connection,System.Data.CommandType.Text,upd);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message ,"Update Failed");
				return;
			}
			MessageBox.Show("Update Successfully.","Message");
		}

		private void grpMdCompanyTop_Click(object sender, System.EventArgs e)
		{
		
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
	}
}
