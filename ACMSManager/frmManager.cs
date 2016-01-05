#region using
using System.Diagnostics;
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.IO;
using System.Data.OleDb;
using ACMS.Utils;
using ACMS.XtraUtils.LookupEditBuilder;
using ACMSDAL;
using ACMSLogic;
using ACMSLogic.Staff;
using Do = Acms.Core.Domain;

#endregion

namespace ACMS
{
	public class frmManager : System.Windows.Forms.Form
	{
		#region Screen Painting Inheritance
		[System.Runtime.InteropServices.DllImport("gdi32.dll",EntryPoint="BitBlt")]
		public static extern long BitBlt(IntPtr hdcDest,int xDest,int yDest,int wDest,int hDest,IntPtr hdcSource,int xSrc,int ySrc,int RasterOp);
		#endregion

		#region Variable Initialization

		private int _select;
		private string _category;

		private DataTable dtUserRights;

		private static ACMS.ACMSManager.Human_Resource.frmRosterMain frmRoster;
		private static ACMS.ACMSManager.Human_Resource.frmOvertimeMain frmOvertime;
		private static ACMS.ACMSManager.Human_Resource.frmTimeSheetMain frmTimeSheet;
		private static ACMS.ACMSManager.Human_Resource.frmLeave frmHRLeave;
		private static ACMS.ACMSManager.Human_Resource.frmAppointment frmHRAppointment;
		
		private ACMS.ACMSManager.Operation.frmMemberCard myMemberCard;
		private ACMS.ACMSManager.Operation.frmRoadShow myRoadShow;

		private static ACMS.ACMSManager.MasterData.frmBank frmBank;
		private static ACMS.ACMSManager.MasterData.frmCompany frmComp;
		private static ACMS.ACMSManager.MasterData.frmBranch frmBranch;
		private static ACMS.ACMSManager.MasterData.frmClass frmClass;
		private static ACMS.ACMSManager.MasterData.frmCommission frmCommission;
		private static ACMS.ACMSManager.MasterData.frmDepartment frmDepartment;
		private static ACMS.ACMSManager.MasterData.frmEmployee frmEmployee;
		private static ACMS.ACMSManager.MasterData.frmLeave frmLeave;
		private static ACMS.ACMSManager.MasterData.frmPackage frmPackage;
		private static ACMS.ACMSManager.MasterData.frmPromotion frmPromotion;
		private static ACMS.ACMSManager.MasterData.frmService frmService;
		private static ACMS.ACMSManager.MasterData.frmUserRights frmUserRights;
		private static ACMS.ACMSManager.MasterData.frmPromotionItem frmPromotionItem;
		private static ACMS.ACMSManager.MasterData.frmReward frmReward;
		private static ACMS.ACMSManager.MasterData.frmInventory frmInventory;
		private static ACMS.ACMSManager.MasterData.frmTerminalUser frmTerminalUser;
	
		

		private Do.Employee employee;
		private Do.TerminalUser terminalUser;
		private System.Windows.Forms.Label label6;
		internal DevExpress.XtraTab.XtraTabPage tabManagerOne;
		internal DevExpress.XtraTab.XtraTabPage tabManagerTwo;
		private DevExpress.XtraTab.XtraTabPage tabManagerThree;
		private DevExpress.XtraTab.XtraTabPage tabManagerFour;
		private DevExpress.XtraTab.XtraTabPage tabManagerFive;
		private DevExpress.XtraTab.XtraTabPage tabManagerSix;
		private DevExpress.XtraEditors.SimpleButton lblOne_2;
		private DevExpress.XtraEditors.SimpleButton lblOne_1;
		private DevExpress.XtraEditors.SimpleButton lblFour_2;
		private DevExpress.XtraEditors.SimpleButton lblFour_4;
		private DevExpress.XtraEditors.SimpleButton lblFour_3;
		private DevExpress.XtraEditors.SimpleButton lblFour_1;
		private DevExpress.XtraEditors.SimpleButton lblFour_5;
		private DevExpress.XtraEditors.SimpleButton lblThree_2;
		private DevExpress.XtraEditors.SimpleButton lblThree_1;
		private DevExpress.XtraEditors.SimpleButton lblThree_3;
		private DevExpress.XtraEditors.SimpleButton lblFive_1;
		private DevExpress.XtraEditors.SimpleButton lblFive_2;
		private DevExpress.XtraEditors.SimpleButton lblFive_4;
		private DevExpress.XtraEditors.SimpleButton lblFive_3;
		private DevExpress.XtraEditors.SimpleButton lblFive_8;
		private DevExpress.XtraEditors.SimpleButton lblFive_7;
		private DevExpress.XtraEditors.SimpleButton lblFive_6;
		private DevExpress.XtraEditors.SimpleButton lblFive_5;
		private DevExpress.XtraEditors.SimpleButton lblFive_10;
		private DevExpress.XtraEditors.SimpleButton lblFive_9; 
		User oUser;

		private void lk_ReportView_EditValueChanged(object sender, System.EventArgs e)
		{
			switch(lk_ReportView.EditValue.ToString())
			{
				case "Sales1":
					show_Sales1();
					break;
				case "Sales2":
					show_Sales2();
					break;
				case "Sales3":
					show_Sales3();
					break;
				case "Sales4":
					show_Sales4();
					break;
				case "Sales5":
					show_Sales5();
					break;
				case "Sales6":
					show_Sales6();
					break;
				case "Class1":
					show_Class1();
					break;
				case "Class2":
					show_Class2();
					break;
				case "Class3":
					//show_Class3();
					break;
				case "Class4":
					show_Class4();
					break;
				case "Class5":
					show_Class5();
					break;
                case "Class6":
                    show_Class6();
                    break;
				case "Operations1":
					show_Operations1();
					break;
				case "Operations2":
					show_Operations2();
					break;
				case "Operations3":
					show_Operations3();
					break;
				case "Operations4":
					show_Operations4();
					break;
				case "Operations5":
					show_Operations5();
					break;
				case "Promotion1":
					show_Promotion1();
					break;
				case "Promotion2":
					show_Promotion2();
					break;
				case "Promotion3":
					show_Promotion3();
					break;
				case "Quantity1":
					show_Quantity1();
					break;
				case "Quantity2":
					show_Quantity2();
					break;
				case "Quantity3":
					show_Quantity3();
					break;			
				case "Accounts1":
					show_Accounts1();
					break;
				case "Staff1":
					show_Staff1();
					break;
				case "Staff2":
					show_Staff2();
					break;
				case "Staff3":
					show_Staff3();
					break;
				case "Staff4":
					show_Staff4();
					break;
				case "CV1":
					show_CV1();
					break;
				case "Leave1":
					show_Leave1();
					break;
				case "Member1":
					show_Member1();
					break;
			}

		}

		private Bitmap memoryImage;
		private string _cn;
		string _mode;
		
		Font Font001;
		Font Font002;
		Font Font003;
		Font Font004;
		private ACMS.Utils.Common myCommon;
		private ACMSLogic.IPP IPPs;
		private DataTable _dtClassSchedule= new DataTable();
		private string connectionString;
		private SqlConnection connection;
		private ACMS.Control.ClassComponent classComponent1;


		//report
		private static ACMS.ACMSManager.Reports.RPIncomeAnalysis rptAnalysis;
		private static ACMS.ACMSManager.Reports.RPMtMSales rptMtMSales;
		private static ACMS.ACMSManager.Reports.RPSalesMangement rptComSales;
		private static ACMS.ACMSManager.Reports.RPAllIncome rptAllIncome;
		private static ACMS.ACMSManager.Reports.RPSpaDailyBranchSales rptSpaDailyBranch;
		private static ACMS.ACMSManager.Reports.RPFitnessDailyBranchSales rptFitnessDailyBranch;
		private static ACMS.ACMSManager.Reports.RPOperation rptOperation;
		private static ACMS.ACMSManager.Reports.RPPromotionReport rptPromotion;
		private static ACMS.ACMSManager.Reports.RPAccountsReport rptAccount;
		private static ACMS.ACMSManager.Reports.RPStaffReport rptStaff;
		private static ACMS.ACMSManager.Reports.RPInstructorFees rptInstructor;
		private static ACMS.ACMSManager.Reports.RPInstructorDetails rptInstructorDetail;
		private static ACMS.ACMSManager.Reports.RPStock rptStock;
		private static ACMS.ACMSManager.Reports.RPCustomerVoice rptCustomerVoice;
		private static ACMS.ACMSManager.Reports.RPClassAnalysis rptCASchedule;
		private static ACMS.ACMSManager.Reports.RPDayClassAnalysis rptDayClass;
        private static ACMS.ACMSManager.Reports.RPInsturctorSalary rptInsturctorSalary;
		private static ACMS.ACMSManager.Reports.RPClassInstructor rptCAInstructor;
		private static ACMS.ACMSManager.Reports.RPSpaFitness rptSpaFitness;
		private static ACMS.ACMSManager.Reports.RPInsturctorSalary rptInstructorSalary;
		private static ACMS.ACMSManager.Reports.RPNewMember rptNewMember;
		private static ACMS.ACMSManager.Reports.RPLeave rptLeave;
		private static ACMS.ACMSManager.Reports.RPLateness rptLateness;
		private static ACMS.ACMSManager.Reports.RPStaffTimeOff rptStaffTimeOff;
		private static ACMS.ACMSManager.Reports.RPPromotionSalesPkg rptPromotion2;
		private static ACMS.ACMSManager.Reports.RPPromotionAnalysis rptPromotionAnalysis;
		private static ACMS.ACMSManager.Reports.RPGymAnalysis rptGymAnalysis;
		private static ACMS.ACMSManager.Reports.RPStockSalon rptSalonUse;
		private static ACMS.ACMSManager.Reports.RPClassAnalysisByVariable rptCAVariable;

	
		#endregion

		#region Windows Controls
		private System.Windows.Forms.Panel panelFri;
		private System.Windows.Forms.Panel panelWed;
		private System.Windows.Forms.Panel panelTue;
		private System.Windows.Forms.Panel panelMon;
		private System.Windows.Forms.Label lblFRI;
		private System.Windows.Forms.Label lblTHU;
		private System.Windows.Forms.Label lblWED;
		private System.Windows.Forms.Label lblTUE;
		private System.Windows.Forms.Label lblMON;
		private System.Windows.Forms.Panel panelThu;
		private System.Windows.Forms.Panel panelSat;
		private System.Windows.Forms.Panel panelSun;
		private System.Windows.Forms.Label lblSAT;
		private System.Windows.Forms.Label lblSUN;
		internal DevExpress.XtraEditors.SimpleButton btnPrintClassSchedule;
		internal DevExpress.XtraEditors.SimpleButton btnNewClassSchedule;
		private string connString = string.Empty;
		private DevExpress.XtraBars.BarManager barManager1;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private DevExpress.XtraBars.Bar bar1;
		private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
		private DevExpress.XtraBars.BarButtonItem bbiManagerLoginOut;
		internal DevExpress.XtraEditors.GroupControl groupIPPMaster;
		internal System.Windows.Forms.Label hypReceipts;
		internal System.Windows.Forms.Label hypIPPDetails;
		internal DevExpress.XtraEditors.GroupControl GroupIPPDetails;
		internal DevExpress.XtraEditors.GroupControl groupIPP;
		internal DevExpress.XtraGrid.Views.Grid.GridView IPPGridView;
		internal DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		internal DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		internal DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
		internal DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
		internal DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
		internal DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
		internal DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
		internal DevExpress.XtraEditors.SimpleButton btnReceiveIPP;
		internal DevExpress.XtraEditors.SimpleButton btnSendIPP;
		internal DevExpress.XtraEditors.SimpleButton btnUpdateIPP;
		internal DevExpress.XtraEditors.SimpleButton btnDeleteIPP;
		internal DevExpress.XtraEditors.SimpleButton btnNewIPP;
		private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditYR;
		private System.Windows.Forms.Label lblPQBranch;
		
		internal System.Windows.Forms.MainMenu MainMenu1;
		internal System.Windows.Forms.MenuItem MenuItem1;
		internal System.Windows.Forms.MenuItem MenuItem2;
		internal System.Windows.Forms.MenuItem MenuItem4;
		internal System.Windows.Forms.MenuItem MenuItem6;
		internal System.Windows.Forms.MenuItem MenuItem7;
		internal System.Windows.Forms.MenuItem MenuItem8;
		internal System.Windows.Forms.MenuItem MenuItem9;
		internal System.Windows.Forms.MenuItem MenuItem10;
		internal System.Windows.Forms.MenuItem MenuItem5;

		internal DevExpress.XtraEditors.ComboBoxEdit cmbxPayroll;
		private System.Windows.Forms.Label lblMonth;
		private System.Windows.Forms.Label lblYear;
		private DevExpress.XtraEditors.GroupControl GrpPayroll;
		private System.ComponentModel.IContainer components;
		private DevExpress.XtraEditors.GroupControl grpClassSchedule;
		internal DevExpress.XtraGrid.GridControl IPPGrid;
		private System.Drawing.Printing.PrintDocument printDocument1;
		internal DevExpress.XtraEditors.SimpleButton btnRefreshClassSchedule;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		internal DevExpress.XtraEditors.GroupControl groupIPPReceipt;
		private DevExpress.XtraEditors.GroupControl grpIPP2;
		private System.Windows.Forms.Label IPPlblDtTo;
		private System.Windows.Forms.Label IPPlblDtFrom;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPGE3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPGE2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnPGE1;
		private DevExpress.XtraEditors.TextEdit mdPGE_txtNQuantity;
		private DevExpress.XtraEditors.ImageComboBoxEdit mdPGE_txtStrPackageCode;
		private DevExpress.XtraEditors.ImageComboBoxEdit mdPGE_cdStrPackageGroupCode;
		private System.Windows.Forms.Label mdPGE_lblNQuantity;
		private System.Windows.Forms.Label mdPGE_lblStrPackageCode;
		private System.Windows.Forms.Label mdPGE_lblStrPackageGroupCode;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
		private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
		internal DevExpress.XtraEditors.SimpleButton btnPayrollExport;
		internal DevExpress.XtraEditors.SimpleButton btnPayrollGenerate;
		internal DevExpress.XtraEditors.ComboBoxEdit comboBoxEditMTH;
		internal DevExpress.XtraEditors.SimpleButton btnPayrollDelete;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.PanelControl ReportPanel;
		private System.Windows.Forms.Panel panel2;
		private DevExpress.XtraEditors.ImageComboBoxEdit ComboBoxIPP;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		internal DevExpress.XtraEditors.TextEdit txtCreditCardScr;
		internal DevExpress.XtraEditors.SimpleButton btnSearch;
		private DevExpress.XtraEditors.ImageComboBoxEdit IPPReceiptStatus;
		private System.Windows.Forms.Label label10;
		private DevExpress.XtraBars.BarButtonItem bbiManagerTimeCard;
		private DevExpress.XtraEditors.DateEdit IPPdtStart;
		private DevExpress.XtraEditors.DateEdit IPPdtTo;
		internal DevExpress.XtraEditors.TextEdit IPPStatus;
		internal DevExpress.XtraEditors.TextEdit IPPDateRcv;
		internal DevExpress.XtraEditors.TextEdit IPPDateSent;
		internal DevExpress.XtraEditors.TextEdit IPPBranchCode;
		internal DevExpress.XtraEditors.TextEdit IPPCreatedDate;
		internal System.Windows.Forms.Label IPPLBL1;
		internal System.Windows.Forms.Label IPPLBL16;
		internal DevExpress.XtraEditors.TextEdit IPPMerchantNo;
		internal System.Windows.Forms.Label IPPLBL8;
		internal System.Windows.Forms.Label IPPLBL14;
		internal System.Windows.Forms.Label IPPLBL12;
		internal System.Windows.Forms.Label IPPLBL13;
		internal System.Windows.Forms.Label IPPLBL11;
		internal System.Windows.Forms.Label IPPLBL10;
		internal System.Windows.Forms.Label IPPLBL9;
		internal System.Windows.Forms.Label IPPLBL7;
		internal DevExpress.XtraEditors.TextEdit IPPAmount;
		internal DevExpress.XtraEditors.TextEdit IPPInterest;
		internal DevExpress.XtraEditors.TextEdit IPPNettAmount;
		internal System.Windows.Forms.Label IPPLBL5;
		internal System.Windows.Forms.Label IPPLBL6;
		internal System.Windows.Forms.Label IPPLBL4;
		internal System.Windows.Forms.Label IPPLBL3;
		internal System.Windows.Forms.Label IPPLBL2;
		internal DevExpress.XtraEditors.TextEdit IPPMemberId;
		internal DevExpress.XtraEditors.TextEdit IPPMemberName;
		internal DevExpress.XtraEditors.TextEdit IPPId;
		internal DevExpress.XtraGrid.GridControl gridReceipt;
		internal DevExpress.XtraGrid.Views.Grid.GridView IPPReceiptView;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnIPPR;
		internal DevExpress.XtraGrid.Columns.GridColumn gridColumnIPPR1;
		internal DevExpress.XtraGrid.Columns.GridColumn gridColumnIPPR2;
		internal DevExpress.XtraGrid.Columns.GridColumn gridColumnIPPR3;
		internal DevExpress.XtraGrid.Columns.GridColumn gridColumnIPPR4;
		internal DevExpress.XtraGrid.Columns.GridColumn gridColumnIPPR5;
		internal DevExpress.XtraGrid.Columns.GridColumn gridColumnIPPR6;
		internal DevExpress.XtraGrid.Columns.GridColumn gridColumnIPPR7;
		internal DevExpress.XtraGrid.Columns.GridColumn gridColumnIPPR8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnIPPR9;
		internal DevExpress.XtraEditors.SimpleButton btnReceiptUnlink;
		internal DevExpress.XtraEditors.SimpleButton btnReceiptLink;
		private DevExpress.XtraBars.BarButtonItem barButtonItem1;
		private DevExpress.XtraBars.BarButtonItem barstaticCurrentLogin;
		internal DevExpress.XtraEditors.TextEdit IPPCCNo;
		private DevExpress.XtraEditors.ImageComboBoxEdit IPPNMonths;
		private DevExpress.XtraEditors.GroupControl groupMemCard;
		internal DevExpress.XtraTab.XtraTabControl tabControlManager;
		private DevExpress.XtraEditors.LookUpEdit IPPBankCode;
		private DevExpress.XtraEditors.LookUpEdit comboBoxBranch;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraEditors.LookUpEdit lkBank;
		private DevExpress.XtraEditors.LookUpEdit lkBranch;
		internal DevExpress.XtraEditors.SimpleButton btnReset;
		private DevExpress.XtraEditors.GroupControl grpRoadShow;
		private DevExpress.XtraGrid.GridControl gridPayroll;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewPayroll;
		private DevExpress.XtraGrid.Columns.GridColumn nEmployeeID;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
		private DevExpress.XtraGrid.Columns.GridColumn dtFirstRunDate;
		private DevExpress.XtraGrid.Columns.GridColumn nNormalOT;
		private DevExpress.XtraGrid.Columns.GridColumn nPublicHolidayOT;
		private DevExpress.XtraGrid.Columns.GridColumn nOffDayOT;
		private DevExpress.XtraGrid.Columns.GridColumn nPartTimeWorkHours;
		private DevExpress.XtraGrid.Columns.GridColumn nALEntitlementHours;
		private DevExpress.XtraGrid.Columns.GridColumn nPHEntitlementHours;
		private DevExpress.XtraGrid.Columns.GridColumn mServiceReimbursements;
		private DevExpress.XtraGrid.Columns.GridColumn nTotalLateness;
		private DevExpress.XtraGrid.Columns.GridColumn nUnpaidAL;
		private DevExpress.XtraGrid.Columns.GridColumn nUnpaidTO;
		private DevExpress.XtraGrid.Columns.GridColumn nUnpaidMedical;
		private DevExpress.XtraGrid.Columns.GridColumn mCommission;
		private DevExpress.XtraGrid.Columns.GridColumn mCommissionLatenessPenalty;
		private DevExpress.XtraGrid.Columns.GridColumn dtSecondRunDate;
		private DevExpress.XtraEditors.GroupControl grpGridExcel;
		private DevExpress.XtraGrid.GridControl gridExcel;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn34;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
		private DevExpress.XtraGrid.Columns.GridColumn FirstPayDate;
		private DevExpress.XtraGrid.Columns.GridColumn SecondPayDate;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewExcel;
		private DevExpress.XtraEditors.TextEdit strReferenceNo;
		private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
		private ACMS.ucMemberID ucMemberID1;
		private DevExpress.XtraEditors.LookUpEdit luedtBankBranch;
		private DevExpress.XtraEditors.LookUpEdit luedtBank;
		private DevExpress.XtraEditors.LookUpEdit luedtPackage;
		private DevExpress.XtraEditors.LookUpEdit luedtBranch;
		private System.Windows.Forms.Label label70;
		private DevExpress.XtraEditors.TextEdit txtPackageDesc;
		private DevExpress.XtraEditors.TextEdit txtAccountNo;
		private DevExpress.XtraEditors.TextEdit txtGIROId;
		private DevExpress.XtraEditors.MemoEdit txtRemark;
		private System.Windows.Forms.Label lblGiro_BankBranch;
		private System.Windows.Forms.Label lblGiro_BankACNumber;
		private System.Windows.Forms.Label lblGiro_BankCode;
		private System.Windows.Forms.Label lblGiro_Remark;
		private System.Windows.Forms.Label lblGiro_Package;
		private System.Windows.Forms.Label lblGiro_Branch;
		private System.Windows.Forms.Label lblGiro_MemberID;
		private System.Windows.Forms.Label lblGiroID;
		private DevExpress.XtraTab.XtraTabPage tabGiroTrnsHistory;
		private DevExpress.XtraGrid.GridControl GridTransaction;
		internal DevExpress.XtraEditors.GroupControl GroupGiro;
		private DevExpress.XtraEditors.ImageComboBoxEdit comboBoxGiroStatus;
		private System.Windows.Forms.Label label63;
		internal DevExpress.XtraEditors.SimpleButton btnImport;
		internal DevExpress.XtraEditors.SimpleButton btnGiroExport;
		internal DevExpress.XtraEditors.SimpleButton btnGiroUpdate;
		internal DevExpress.XtraEditors.SimpleButton btnGiroDelete;
		internal DevExpress.XtraEditors.SimpleButton btnGiroNew;
		internal DevExpress.XtraGrid.GridControl GiroGrid;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
		private DevExpress.XtraGrid.Views.Grid.GridView GIROGridView;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraEditors.GroupControl groupGIROMaster;
		private DevExpress.XtraTab.XtraTabPage tabGiroDetails;
		private System.Windows.Forms.Label label8;
		private DevExpress.XtraEditors.ImageComboBoxEdit cbJob;
		private System.Windows.Forms.Label label5;
		private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
		private DevExpress.Utils.ToolTipController toolTipController1;
		private DevExpress.XtraEditors.LookUpEdit lk_MasterData;
		private DevExpress.XtraEditors.LookUpEdit lk_ReportView;
	
		internal System.Windows.Forms.Label label7;
		// 


		#endregion

		#region security
		public void initData (ACMSLogic.User User)
		{
			oUser = User;
			MemberRecord myMemberRecord = new MemberRecord(oUser.StrBranchCode());
		}

		public void SetEmployeeRecord(Do.Employee employee)
		{
			this.employee = employee;
		}

		public void SetTerminalUser(Do.TerminalUser terminalUser)
		{
			this.terminalUser = terminalUser;

		}

		
		#endregion

		#region Constructor & Dispose
		public frmManager()
		{
	
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}


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
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManager));
            this.MainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.MenuItem1 = new System.Windows.Forms.MenuItem();
            this.MenuItem2 = new System.Windows.Forms.MenuItem();
            this.MenuItem4 = new System.Windows.Forms.MenuItem();
            this.MenuItem6 = new System.Windows.Forms.MenuItem();
            this.MenuItem7 = new System.Windows.Forms.MenuItem();
            this.MenuItem8 = new System.Windows.Forms.MenuItem();
            this.MenuItem9 = new System.Windows.Forms.MenuItem();
            this.MenuItem10 = new System.Windows.Forms.MenuItem();
            this.MenuItem5 = new System.Windows.Forms.MenuItem();
            this.tabControlManager = new DevExpress.XtraTab.XtraTabControl();
            this.tabManagerOne = new DevExpress.XtraTab.XtraTabPage();
            this.lblOne_2 = new DevExpress.XtraEditors.SimpleButton();
            this.lblOne_1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupIPPMaster = new DevExpress.XtraEditors.GroupControl();
            this.groupIPP = new DevExpress.XtraEditors.GroupControl();
            this.ComboBoxIPP = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.grpIPP2 = new DevExpress.XtraEditors.GroupControl();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.lkBranch = new DevExpress.XtraEditors.LookUpEdit();
            this.lkBank = new DevExpress.XtraEditors.LookUpEdit();
            this.IPPdtTo = new DevExpress.XtraEditors.DateEdit();
            this.IPPdtStart = new DevExpress.XtraEditors.DateEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtCreditCardScr = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IPPlblDtTo = new System.Windows.Forms.Label();
            this.IPPlblDtFrom = new System.Windows.Forms.Label();
            this.btnReceiveIPP = new DevExpress.XtraEditors.SimpleButton();
            this.btnSendIPP = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdateIPP = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteIPP = new DevExpress.XtraEditors.SimpleButton();
            this.btnNewIPP = new DevExpress.XtraEditors.SimpleButton();
            this.IPPGrid = new DevExpress.XtraGrid.GridControl();
            this.IPPGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.hypReceipts = new System.Windows.Forms.Label();
            this.hypIPPDetails = new System.Windows.Forms.Label();
            this.GroupIPPDetails = new DevExpress.XtraEditors.GroupControl();
            this.strReferenceNo = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.IPPBankCode = new DevExpress.XtraEditors.LookUpEdit();
            this.IPPNMonths = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.IPPCCNo = new DevExpress.XtraEditors.TextEdit();
            this.IPPStatus = new DevExpress.XtraEditors.TextEdit();
            this.IPPDateRcv = new DevExpress.XtraEditors.TextEdit();
            this.IPPDateSent = new DevExpress.XtraEditors.TextEdit();
            this.IPPBranchCode = new DevExpress.XtraEditors.TextEdit();
            this.IPPCreatedDate = new DevExpress.XtraEditors.TextEdit();
            this.IPPLBL1 = new System.Windows.Forms.Label();
            this.IPPLBL16 = new System.Windows.Forms.Label();
            this.IPPMerchantNo = new DevExpress.XtraEditors.TextEdit();
            this.IPPLBL8 = new System.Windows.Forms.Label();
            this.IPPLBL14 = new System.Windows.Forms.Label();
            this.IPPLBL12 = new System.Windows.Forms.Label();
            this.IPPLBL13 = new System.Windows.Forms.Label();
            this.IPPLBL11 = new System.Windows.Forms.Label();
            this.IPPLBL10 = new System.Windows.Forms.Label();
            this.IPPLBL9 = new System.Windows.Forms.Label();
            this.IPPLBL7 = new System.Windows.Forms.Label();
            this.IPPAmount = new DevExpress.XtraEditors.TextEdit();
            this.IPPInterest = new DevExpress.XtraEditors.TextEdit();
            this.IPPNettAmount = new DevExpress.XtraEditors.TextEdit();
            this.IPPLBL5 = new System.Windows.Forms.Label();
            this.IPPLBL6 = new System.Windows.Forms.Label();
            this.IPPLBL4 = new System.Windows.Forms.Label();
            this.IPPLBL3 = new System.Windows.Forms.Label();
            this.IPPLBL2 = new System.Windows.Forms.Label();
            this.IPPMemberId = new DevExpress.XtraEditors.TextEdit();
            this.IPPMemberName = new DevExpress.XtraEditors.TextEdit();
            this.IPPId = new DevExpress.XtraEditors.TextEdit();
            this.groupIPPReceipt = new DevExpress.XtraEditors.GroupControl();
            this.btnReceiptUnlink = new DevExpress.XtraEditors.SimpleButton();
            this.btnReceiptLink = new DevExpress.XtraEditors.SimpleButton();
            this.gridReceipt = new DevExpress.XtraGrid.GridControl();
            this.IPPReceiptView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnIPPR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnIPPR1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnIPPR2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnIPPR3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnIPPR4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnIPPR5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnIPPR6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnIPPR7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnIPPR8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnIPPR9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.IPPReceiptStatus = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.groupGIROMaster = new DevExpress.XtraEditors.GroupControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabGiroDetails = new DevExpress.XtraTab.XtraTabPage();
            this.luedtBankBranch = new DevExpress.XtraEditors.LookUpEdit();
            this.luedtBank = new DevExpress.XtraEditors.LookUpEdit();
            this.luedtPackage = new DevExpress.XtraEditors.LookUpEdit();
            this.luedtBranch = new DevExpress.XtraEditors.LookUpEdit();
            this.label70 = new System.Windows.Forms.Label();
            this.txtPackageDesc = new DevExpress.XtraEditors.TextEdit();
            this.txtAccountNo = new DevExpress.XtraEditors.TextEdit();
            this.txtGIROId = new DevExpress.XtraEditors.TextEdit();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.lblGiro_BankBranch = new System.Windows.Forms.Label();
            this.lblGiro_BankACNumber = new System.Windows.Forms.Label();
            this.lblGiro_BankCode = new System.Windows.Forms.Label();
            this.lblGiro_Remark = new System.Windows.Forms.Label();
            this.lblGiro_Package = new System.Windows.Forms.Label();
            this.lblGiro_Branch = new System.Windows.Forms.Label();
            this.lblGiro_MemberID = new System.Windows.Forms.Label();
            this.lblGiroID = new System.Windows.Forms.Label();
            this.tabGiroTrnsHistory = new DevExpress.XtraTab.XtraTabPage();
            this.GridTransaction = new DevExpress.XtraGrid.GridControl();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GroupGiro = new DevExpress.XtraEditors.GroupControl();
            this.comboBoxGiroStatus = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label63 = new System.Windows.Forms.Label();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.btnGiroExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnGiroUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnGiroDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnGiroNew = new DevExpress.XtraEditors.SimpleButton();
            this.GiroGrid = new DevExpress.XtraGrid.GridControl();
            this.GIROGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabManagerTwo = new DevExpress.XtraTab.XtraTabPage();
            this.GrpPayroll = new DevExpress.XtraEditors.GroupControl();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.cbJob = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.grpGridExcel = new DevExpress.XtraEditors.GroupControl();
            this.gridExcel = new DevExpress.XtraGrid.GridControl();
            this.gridViewExcel = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FirstPayDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SecondPayDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnPayrollExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnPayrollGenerate = new DevExpress.XtraEditors.SimpleButton();
            this.btnPayrollDelete = new DevExpress.XtraEditors.SimpleButton();
            this.comboBoxEditMTH = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEditYR = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.cmbxPayroll = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gridPayroll = new DevExpress.XtraGrid.GridControl();
            this.gridViewPayroll = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.nEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtFirstRunDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nNormalOT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nPublicHolidayOT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nOffDayOT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nPartTimeWorkHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nALEntitlementHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nPHEntitlementHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mServiceReimbursements = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nTotalLateness = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nUnpaidAL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nUnpaidTO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nUnpaidMedical = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mCommission = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mCommissionLatenessPenalty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtSecondRunDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabManagerThree = new DevExpress.XtraTab.XtraTabPage();
            this.lblThree_2 = new DevExpress.XtraEditors.SimpleButton();
            this.lblThree_1 = new DevExpress.XtraEditors.SimpleButton();
            this.lblThree_3 = new DevExpress.XtraEditors.SimpleButton();
            this.grpClassSchedule = new DevExpress.XtraEditors.GroupControl();
            this.comboBoxBranch = new DevExpress.XtraEditors.LookUpEdit();
            this.btnRefreshClassSchedule = new DevExpress.XtraEditors.SimpleButton();
            this.lblPQBranch = new System.Windows.Forms.Label();
            this.lblSUN = new System.Windows.Forms.Label();
            this.panelSun = new System.Windows.Forms.Panel();
            this.panelSat = new System.Windows.Forms.Panel();
            this.lblFRI = new System.Windows.Forms.Label();
            this.lblTHU = new System.Windows.Forms.Label();
            this.lblWED = new System.Windows.Forms.Label();
            this.lblTUE = new System.Windows.Forms.Label();
            this.panelFri = new System.Windows.Forms.Panel();
            this.panelThu = new System.Windows.Forms.Panel();
            this.panelWed = new System.Windows.Forms.Panel();
            this.panelTue = new System.Windows.Forms.Panel();
            this.panelMon = new System.Windows.Forms.Panel();
            this.lblMON = new System.Windows.Forms.Label();
            this.btnPrintClassSchedule = new DevExpress.XtraEditors.SimpleButton();
            this.btnNewClassSchedule = new DevExpress.XtraEditors.SimpleButton();
            this.lblSAT = new System.Windows.Forms.Label();
            this.groupMemCard = new DevExpress.XtraEditors.GroupControl();
            this.grpRoadShow = new DevExpress.XtraEditors.GroupControl();
            this.tabManagerFour = new DevExpress.XtraTab.XtraTabPage();
            this.lblFour_2 = new DevExpress.XtraEditors.SimpleButton();
            this.lblFour_1 = new DevExpress.XtraEditors.SimpleButton();
            this.lblFour_3 = new DevExpress.XtraEditors.SimpleButton();
            this.lblFour_4 = new DevExpress.XtraEditors.SimpleButton();
            this.lblFour_5 = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabManagerFive = new DevExpress.XtraTab.XtraTabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.ReportPanel = new DevExpress.XtraEditors.PanelControl();
            this.lk_ReportView = new DevExpress.XtraEditors.LookUpEdit();
            this.lblFive_9 = new DevExpress.XtraEditors.SimpleButton();
            this.lblFive_10 = new DevExpress.XtraEditors.SimpleButton();
            this.lblFive_4 = new DevExpress.XtraEditors.SimpleButton();
            this.lblFive_2 = new DevExpress.XtraEditors.SimpleButton();
            this.lblFive_8 = new DevExpress.XtraEditors.SimpleButton();
            this.lblFive_7 = new DevExpress.XtraEditors.SimpleButton();
            this.lblFive_3 = new DevExpress.XtraEditors.SimpleButton();
            this.lblFive_6 = new DevExpress.XtraEditors.SimpleButton();
            this.lblFive_1 = new DevExpress.XtraEditors.SimpleButton();
            this.lblFive_5 = new DevExpress.XtraEditors.SimpleButton();
            this.tabManagerSix = new DevExpress.XtraTab.XtraTabPage();
            this.lk_MasterData = new DevExpress.XtraEditors.LookUpEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bbiManagerLoginOut = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barstaticCurrentLogin = new DevExpress.XtraBars.BarButtonItem();
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bbiManagerTimeCard = new DevExpress.XtraBars.BarButtonItem();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gridColumnPGE3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPGE2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPGE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mdPGE_txtNQuantity = new DevExpress.XtraEditors.TextEdit();
            this.mdPGE_txtStrPackageCode = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.mdPGE_cdStrPackageGroupCode = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.mdPGE_lblNQuantity = new System.Windows.Forms.Label();
            this.mdPGE_lblStrPackageCode = new System.Windows.Forms.Label();
            this.mdPGE_lblStrPackageGroupCode = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tabControlManager)).BeginInit();
            this.tabControlManager.SuspendLayout();
            this.tabManagerOne.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupIPPMaster)).BeginInit();
            this.groupIPPMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupIPP)).BeginInit();
            this.groupIPP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxIPP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpIPP2)).BeginInit();
            this.grpIPP2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkBank.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPdtTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPdtTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPdtStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPdtStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditCardScr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupIPPDetails)).BeginInit();
            this.GroupIPPDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.strReferenceNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPBankCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPNMonths.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPCCNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPDateRcv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPDateSent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPBranchCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPCreatedDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPMerchantNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPInterest.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPNettAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPMemberId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPMemberName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupIPPReceipt)).BeginInit();
            this.groupIPPReceipt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReceipt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPReceiptView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPReceiptStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupGIROMaster)).BeginInit();
            this.groupGIROMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabGiroDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luedtBankBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luedtBank.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luedtPackage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luedtBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPackageDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGIROId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            this.tabGiroTrnsHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupGiro)).BeginInit();
            this.GroupGiro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxGiroStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GiroGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GIROGridView)).BeginInit();
            this.tabManagerTwo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrpPayroll)).BeginInit();
            this.GrpPayroll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbJob.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpGridExcel)).BeginInit();
            this.grpGridExcel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditMTH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditYR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbxPayroll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPayroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPayroll)).BeginInit();
            this.tabManagerThree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpClassSchedule)).BeginInit();
            this.grpClassSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupMemCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpRoadShow)).BeginInit();
            this.tabManagerFour.SuspendLayout();
            this.tabManagerFive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReportPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_ReportView.Properties)).BeginInit();
            this.tabManagerSix.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lk_MasterData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdPGE_txtNQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdPGE_txtStrPackageCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdPGE_cdStrPackageGroupCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu1
            // 
            this.MainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem1,
            this.MenuItem4,
            this.MenuItem5});
            // 
            // MenuItem1
            // 
            this.MenuItem1.Index = 0;
            this.MenuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem2});
            this.MenuItem1.Text = "File";
            // 
            // MenuItem2
            // 
            this.MenuItem2.Index = 0;
            this.MenuItem2.Text = "Quit";
            // 
            // MenuItem4
            // 
            this.MenuItem4.Index = 1;
            this.MenuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem6,
            this.MenuItem7,
            this.MenuItem8,
            this.MenuItem9,
            this.MenuItem10});
            this.MenuItem4.Text = "Tools";
            // 
            // MenuItem6
            // 
            this.MenuItem6.Index = 0;
            this.MenuItem6.Text = "Change Password";
            // 
            // MenuItem7
            // 
            this.MenuItem7.Index = 1;
            this.MenuItem7.Text = "Block Membership ID";
            // 
            // MenuItem8
            // 
            this.MenuItem8.Index = 2;
            this.MenuItem8.Text = "Reset Membership ID";
            // 
            // MenuItem9
            // 
            this.MenuItem9.Index = 3;
            this.MenuItem9.Text = "Re-print receipt";
            // 
            // MenuItem10
            // 
            this.MenuItem10.Index = 4;
            this.MenuItem10.Text = "Open Carton";
            // 
            // MenuItem5
            // 
            this.MenuItem5.Index = 2;
            this.MenuItem5.Text = "Help";
            // 
            // tabControlManager
            // 
            this.tabControlManager.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlManager.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.tabControlManager.Appearance.Options.UseFont = true;
            this.tabControlManager.Appearance.Options.UseForeColor = true;
            this.tabControlManager.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlManager.AppearancePage.Header.Options.UseFont = true;
            this.tabControlManager.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabControlManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlManager.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tabControlManager.Location = new System.Drawing.Point(0, 40);
            this.tabControlManager.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tabControlManager.Name = "tabControlManager";
            this.tabControlManager.PaintStyleName = "Skin";
            this.tabControlManager.SelectedTabPage = this.tabManagerOne;
            this.tabControlManager.Size = new System.Drawing.Size(1016, 672);
            this.tabControlManager.TabIndex = 5;
            this.tabControlManager.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabManagerOne,
            this.tabManagerTwo,
            this.tabManagerThree,
            this.tabManagerFour,
            this.tabManagerFive,
            this.tabManagerSix});
            this.tabControlManager.Text = "tabAccount";
            this.tabControlManager.Click += new System.EventHandler(this.tabControlManager_Click);
            // 
            // tabManagerOne
            // 
            this.tabManagerOne.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabManagerOne.Appearance.Header.Options.UseFont = true;
            this.tabManagerOne.Appearance.PageClient.BackColor = System.Drawing.Color.DimGray;
            this.tabManagerOne.Appearance.PageClient.Options.UseBackColor = true;
            this.tabManagerOne.Controls.Add(this.lblOne_2);
            this.tabManagerOne.Controls.Add(this.lblOne_1);
            this.tabManagerOne.Controls.Add(this.groupIPPMaster);
            this.tabManagerOne.Controls.Add(this.groupGIROMaster);
            this.tabManagerOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabManagerOne.Name = "tabManagerOne";
            this.tabManagerOne.PageVisible = false;
            this.tabManagerOne.Size = new System.Drawing.Size(1007, 637);
            this.tabManagerOne.Text = "Account";
            // 
            // lblOne_2
            // 
            this.lblOne_2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblOne_2.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblOne_2.Appearance.Options.UseFont = true;
            this.lblOne_2.Appearance.Options.UseForeColor = true;
            this.lblOne_2.Location = new System.Drawing.Point(152, 0);
            this.lblOne_2.Name = "lblOne_2";
            this.lblOne_2.Size = new System.Drawing.Size(138, 23);
            this.lblOne_2.TabIndex = 144;
            this.lblOne_2.Text = "GIRO";
            this.lblOne_2.Click += new System.EventHandler(this.lblOne_2_Click);
            // 
            // lblOne_1
            // 
            this.lblOne_1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblOne_1.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblOne_1.Appearance.Options.UseFont = true;
            this.lblOne_1.Appearance.Options.UseForeColor = true;
            this.lblOne_1.Location = new System.Drawing.Point(8, 0);
            this.lblOne_1.Name = "lblOne_1";
            this.lblOne_1.Size = new System.Drawing.Size(138, 23);
            this.lblOne_1.TabIndex = 143;
            this.lblOne_1.Text = "IPP";
            this.lblOne_1.Click += new System.EventHandler(this.lblOne_1_Click);
            // 
            // groupIPPMaster
            // 
            this.groupIPPMaster.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupIPPMaster.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupIPPMaster.Controls.Add(this.groupIPP);
            this.groupIPPMaster.Controls.Add(this.hypReceipts);
            this.groupIPPMaster.Controls.Add(this.hypIPPDetails);
            this.groupIPPMaster.Controls.Add(this.GroupIPPDetails);
            this.groupIPPMaster.Controls.Add(this.groupIPPReceipt);
            this.groupIPPMaster.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupIPPMaster.Location = new System.Drawing.Point(0, 29);
            this.groupIPPMaster.Name = "groupIPPMaster";
            this.groupIPPMaster.ShowCaption = false;
            this.groupIPPMaster.Size = new System.Drawing.Size(1007, 608);
            this.toolTipController1.SetSuperTip(this.groupIPPMaster, null);
            this.groupIPPMaster.TabIndex = 20;
            this.groupIPPMaster.Text = "GroupControl3";
            // 
            // groupIPP
            // 
            this.groupIPP.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupIPP.Appearance.Options.UseBackColor = true;
            this.groupIPP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupIPP.Controls.Add(this.ComboBoxIPP);
            this.groupIPP.Controls.Add(this.grpIPP2);
            this.groupIPP.Controls.Add(this.btnReceiveIPP);
            this.groupIPP.Controls.Add(this.btnSendIPP);
            this.groupIPP.Controls.Add(this.btnUpdateIPP);
            this.groupIPP.Controls.Add(this.btnDeleteIPP);
            this.groupIPP.Controls.Add(this.btnNewIPP);
            this.groupIPP.Controls.Add(this.IPPGrid);
            this.groupIPP.Location = new System.Drawing.Point(4, 0);
            this.groupIPP.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupIPP.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupIPP.Name = "groupIPP";
            this.groupIPP.Size = new System.Drawing.Size(996, 290);
            this.toolTipController1.SetSuperTip(this.groupIPP, null);
            this.groupIPP.TabIndex = 16;
            this.groupIPP.Text = "IPP";
            // 
            // ComboBoxIPP
            // 
            this.ComboBoxIPP.Location = new System.Drawing.Point(8, 56);
            this.ComboBoxIPP.Name = "ComboBoxIPP";
            this.ComboBoxIPP.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComboBoxIPP.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Show All", null, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Not Sent", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Sent, Not Received", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Success", 2, -1)});
            this.ComboBoxIPP.Size = new System.Drawing.Size(136, 20);
            this.ComboBoxIPP.TabIndex = 130;
            this.ComboBoxIPP.SelectedIndexChanged += new System.EventHandler(this.ComboBoxIPP_SelectedIndexChanged);
            // 
            // grpIPP2
            // 
            this.grpIPP2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.grpIPP2.Controls.Add(this.btnReset);
            this.grpIPP2.Controls.Add(this.lkBranch);
            this.grpIPP2.Controls.Add(this.lkBank);
            this.grpIPP2.Controls.Add(this.IPPdtTo);
            this.grpIPP2.Controls.Add(this.IPPdtStart);
            this.grpIPP2.Controls.Add(this.btnSearch);
            this.grpIPP2.Controls.Add(this.txtCreditCardScr);
            this.grpIPP2.Controls.Add(this.label4);
            this.grpIPP2.Controls.Add(this.label3);
            this.grpIPP2.Controls.Add(this.label2);
            this.grpIPP2.Controls.Add(this.IPPlblDtTo);
            this.grpIPP2.Controls.Add(this.IPPlblDtFrom);
            this.grpIPP2.Location = new System.Drawing.Point(0, 16);
            this.grpIPP2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpIPP2.Name = "grpIPP2";
            this.grpIPP2.ShowCaption = false;
            this.grpIPP2.Size = new System.Drawing.Size(1000, 34);
            this.toolTipController1.SetSuperTip(this.grpIPP2, null);
            this.grpIPP2.TabIndex = 128;
            this.grpIPP2.Text = "groupControl4";
            // 
            // btnReset
            // 
            this.btnReset.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnReset.Appearance.Options.UseFont = true;
            this.btnReset.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnReset.Location = new System.Drawing.Point(928, 8);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(56, 20);
            this.btnReset.TabIndex = 148;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lkBranch
            // 
            this.lkBranch.Location = new System.Drawing.Point(608, 8);
            this.lkBranch.Name = "lkBranch";
            this.lkBranch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.lkBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkBranch.Size = new System.Drawing.Size(64, 22);
            this.lkBranch.TabIndex = 147;
            // 
            // lkBank
            // 
            this.lkBank.Location = new System.Drawing.Point(336, 8);
            this.lkBank.Name = "lkBank";
            this.lkBank.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.lkBank.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkBank.Size = new System.Drawing.Size(216, 22);
            this.lkBank.TabIndex = 146;
            // 
            // IPPdtTo
            // 
            this.IPPdtTo.EditValue = new System.DateTime(2006, 5, 19, 0, 0, 0, 0);
            this.IPPdtTo.Location = new System.Drawing.Point(200, 8);
            this.IPPdtTo.Name = "IPPdtTo";
            this.IPPdtTo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.IPPdtTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.IPPdtTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.IPPdtTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.IPPdtTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.IPPdtTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.IPPdtTo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.IPPdtTo.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.IPPdtTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.IPPdtTo.Size = new System.Drawing.Size(96, 22);
            this.IPPdtTo.TabIndex = 138;
            // 
            // IPPdtStart
            // 
            this.IPPdtStart.EditValue = new System.DateTime(2006, 5, 19, 0, 0, 0, 0);
            this.IPPdtStart.Location = new System.Drawing.Point(80, 8);
            this.IPPdtStart.Name = "IPPdtStart";
            this.IPPdtStart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.IPPdtStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.IPPdtStart.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.IPPdtStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.IPPdtStart.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.IPPdtStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.IPPdtStart.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.IPPdtStart.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.IPPdtStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.IPPdtStart.Size = new System.Drawing.Size(96, 22);
            this.IPPdtStart.TabIndex = 137;
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnSearch.Location = new System.Drawing.Point(864, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(56, 20);
            this.btnSearch.TabIndex = 135;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCreditCardScr
            // 
            this.txtCreditCardScr.EditValue = "";
            this.txtCreditCardScr.Location = new System.Drawing.Point(760, 8);
            this.txtCreditCardScr.Name = "txtCreditCardScr";
            this.txtCreditCardScr.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditCardScr.Properties.Appearance.Options.UseFont = true;
            this.txtCreditCardScr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtCreditCardScr.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtCreditCardScr.Size = new System.Drawing.Size(96, 22);
            this.txtCreditCardScr.TabIndex = 134;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(680, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.toolTipController1.SetSuperTip(this.label4, null);
            this.label4.TabIndex = 132;
            this.label4.Text = "Credit Card";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(552, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.toolTipController1.SetSuperTip(this.label3, null);
            this.label3.TabIndex = 131;
            this.label3.Text = "Branch";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(296, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.toolTipController1.SetSuperTip(this.label2, null);
            this.label2.TabIndex = 130;
            this.label2.Text = "Bank";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IPPlblDtTo
            // 
            this.IPPlblDtTo.BackColor = System.Drawing.Color.Transparent;
            this.IPPlblDtTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPlblDtTo.Location = new System.Drawing.Point(176, 8);
            this.IPPlblDtTo.Name = "IPPlblDtTo";
            this.IPPlblDtTo.Size = new System.Drawing.Size(24, 16);
            this.toolTipController1.SetSuperTip(this.IPPlblDtTo, null);
            this.IPPlblDtTo.TabIndex = 125;
            this.IPPlblDtTo.Text = "To";
            this.IPPlblDtTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IPPlblDtFrom
            // 
            this.IPPlblDtFrom.BackColor = System.Drawing.Color.Transparent;
            this.IPPlblDtFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPlblDtFrom.Location = new System.Drawing.Point(8, 8);
            this.IPPlblDtFrom.Name = "IPPlblDtFrom";
            this.IPPlblDtFrom.Size = new System.Drawing.Size(72, 16);
            this.toolTipController1.SetSuperTip(this.IPPlblDtFrom, null);
            this.IPPlblDtFrom.TabIndex = 124;
            this.IPPlblDtFrom.Text = "Date From";
            this.IPPlblDtFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnReceiveIPP
            // 
            this.btnReceiveIPP.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnReceiveIPP.Appearance.Options.UseFont = true;
            this.btnReceiveIPP.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnReceiveIPP.Enabled = false;
            this.btnReceiveIPP.Location = new System.Drawing.Point(408, 56);
            this.btnReceiveIPP.Name = "btnReceiveIPP";
            this.btnReceiveIPP.Size = new System.Drawing.Size(62, 20);
            this.btnReceiveIPP.TabIndex = 13;
            this.btnReceiveIPP.Text = "Receive";
            this.btnReceiveIPP.Click += new System.EventHandler(this.btnReceiveIPP_Click);
            // 
            // btnSendIPP
            // 
            this.btnSendIPP.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSendIPP.Appearance.Options.UseFont = true;
            this.btnSendIPP.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnSendIPP.Enabled = false;
            this.btnSendIPP.Location = new System.Drawing.Point(344, 56);
            this.btnSendIPP.Name = "btnSendIPP";
            this.btnSendIPP.Size = new System.Drawing.Size(62, 20);
            this.btnSendIPP.TabIndex = 12;
            this.btnSendIPP.Text = "Send";
            this.btnSendIPP.Click += new System.EventHandler(this.btnSendIPP_Click);
            // 
            // btnUpdateIPP
            // 
            this.btnUpdateIPP.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnUpdateIPP.Appearance.Options.UseFont = true;
            this.btnUpdateIPP.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnUpdateIPP.Location = new System.Drawing.Point(216, 56);
            this.btnUpdateIPP.Name = "btnUpdateIPP";
            this.btnUpdateIPP.Size = new System.Drawing.Size(62, 20);
            this.btnUpdateIPP.TabIndex = 10;
            this.btnUpdateIPP.Text = "Update";
            this.btnUpdateIPP.Click += new System.EventHandler(this.btnUpdateIPP_Click);
            // 
            // btnDeleteIPP
            // 
            this.btnDeleteIPP.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnDeleteIPP.Appearance.Options.UseFont = true;
            this.btnDeleteIPP.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnDeleteIPP.Location = new System.Drawing.Point(280, 56);
            this.btnDeleteIPP.Name = "btnDeleteIPP";
            this.btnDeleteIPP.Size = new System.Drawing.Size(62, 20);
            this.btnDeleteIPP.TabIndex = 5;
            this.btnDeleteIPP.Text = "Delete";
            this.btnDeleteIPP.Click += new System.EventHandler(this.btnDeleteIPP_Click);
            // 
            // btnNewIPP
            // 
            this.btnNewIPP.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnNewIPP.Appearance.Options.UseFont = true;
            this.btnNewIPP.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnNewIPP.Location = new System.Drawing.Point(152, 56);
            this.btnNewIPP.Name = "btnNewIPP";
            this.btnNewIPP.Size = new System.Drawing.Size(62, 20);
            this.btnNewIPP.TabIndex = 2;
            this.btnNewIPP.Text = "New";
            this.btnNewIPP.Click += new System.EventHandler(this.btnNewIPP_Click);
            // 
            // IPPGrid
            // 
            this.IPPGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.IPPGrid.EmbeddedNavigator.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.IPPGrid.EmbeddedNavigator.Name = "";
            gridLevelNode1.RelationName = "Level1";
            this.IPPGrid.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.IPPGrid.Location = new System.Drawing.Point(2, 80);
            this.IPPGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.IPPGrid.MainView = this.IPPGridView;
            this.IPPGrid.Name = "IPPGrid";
            this.IPPGrid.Size = new System.Drawing.Size(992, 208);
            this.IPPGrid.TabIndex = 0;
            this.IPPGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.IPPGridView});
            // 
            // IPPGridView
            // 
            this.IPPGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn8});
            this.IPPGridView.GridControl = this.IPPGrid;
            this.IPPGridView.Name = "IPPGridView";
            this.IPPGridView.OptionsBehavior.Editable = false;
            this.IPPGridView.OptionsCustomization.AllowFilter = false;
            this.IPPGridView.OptionsFilter.AllowColumnMRUFilterList = false;
            this.IPPGridView.OptionsFilter.AllowMRUFilterList = false;
            this.IPPGridView.OptionsView.ShowGroupPanel = false;
            this.IPPGridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.IPPGridView_FocusedRowChanged);
            this.IPPGridView.Click += new System.EventHandler(this.IPPGridView_Click);
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "ID";
            this.gridColumn10.FieldName = "nIPPID";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Date Created";
            this.gridColumn11.FieldName = "dtDate";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 6;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Member Id";
            this.gridColumn12.FieldName = "strMembershipID";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 1;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Member Name";
            this.gridColumn13.FieldName = "strMemberName";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 2;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Bank";
            this.gridColumn14.FieldName = "strBankDesc";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 3;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Credit Card No.";
            this.gridColumn15.DisplayFormat.FormatString = "####-####-####-####";
            this.gridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn15.FieldName = "strCreditCardNo";
            this.gridColumn15.GroupFormat.FormatString = "####-####-####-####";
            this.gridColumn15.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn15.MinWidth = 24;
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 4;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "No. of Months";
            this.gridColumn16.FieldName = "nMonths";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 5;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "gridColumn8";
            this.gridColumn8.FieldName = "strIPP";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // hypReceipts
            // 
            this.hypReceipts.AutoSize = true;
            this.hypReceipts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hypReceipts.Location = new System.Drawing.Point(128, 296);
            this.hypReceipts.Name = "hypReceipts";
            this.hypReceipts.Size = new System.Drawing.Size(83, 16);
            this.toolTipController1.SetSuperTip(this.hypReceipts, null);
            this.hypReceipts.TabIndex = 13;
            this.hypReceipts.Text = "RECEIPTS";
            this.hypReceipts.Click += new System.EventHandler(this.hypReceipts_Click);
            // 
            // hypIPPDetails
            // 
            this.hypIPPDetails.AutoSize = true;
            this.hypIPPDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hypIPPDetails.Location = new System.Drawing.Point(16, 296);
            this.hypIPPDetails.Name = "hypIPPDetails";
            this.hypIPPDetails.Size = new System.Drawing.Size(99, 16);
            this.toolTipController1.SetSuperTip(this.hypIPPDetails, null);
            this.hypIPPDetails.TabIndex = 10;
            this.hypIPPDetails.Text = "IPP DETAILS";
            this.hypIPPDetails.Click += new System.EventHandler(this.hypIPPDetails_Click);
            // 
            // GroupIPPDetails
            // 
            this.GroupIPPDetails.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.GroupIPPDetails.Appearance.Options.UseBackColor = true;
            this.GroupIPPDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.GroupIPPDetails.Controls.Add(this.strReferenceNo);
            this.GroupIPPDetails.Controls.Add(this.label7);
            this.GroupIPPDetails.Controls.Add(this.IPPBankCode);
            this.GroupIPPDetails.Controls.Add(this.IPPNMonths);
            this.GroupIPPDetails.Controls.Add(this.IPPCCNo);
            this.GroupIPPDetails.Controls.Add(this.IPPStatus);
            this.GroupIPPDetails.Controls.Add(this.IPPDateRcv);
            this.GroupIPPDetails.Controls.Add(this.IPPDateSent);
            this.GroupIPPDetails.Controls.Add(this.IPPBranchCode);
            this.GroupIPPDetails.Controls.Add(this.IPPCreatedDate);
            this.GroupIPPDetails.Controls.Add(this.IPPLBL1);
            this.GroupIPPDetails.Controls.Add(this.IPPLBL16);
            this.GroupIPPDetails.Controls.Add(this.IPPMerchantNo);
            this.GroupIPPDetails.Controls.Add(this.IPPLBL8);
            this.GroupIPPDetails.Controls.Add(this.IPPLBL14);
            this.GroupIPPDetails.Controls.Add(this.IPPLBL12);
            this.GroupIPPDetails.Controls.Add(this.IPPLBL13);
            this.GroupIPPDetails.Controls.Add(this.IPPLBL11);
            this.GroupIPPDetails.Controls.Add(this.IPPLBL10);
            this.GroupIPPDetails.Controls.Add(this.IPPLBL9);
            this.GroupIPPDetails.Controls.Add(this.IPPLBL7);
            this.GroupIPPDetails.Controls.Add(this.IPPAmount);
            this.GroupIPPDetails.Controls.Add(this.IPPInterest);
            this.GroupIPPDetails.Controls.Add(this.IPPNettAmount);
            this.GroupIPPDetails.Controls.Add(this.IPPLBL5);
            this.GroupIPPDetails.Controls.Add(this.IPPLBL6);
            this.GroupIPPDetails.Controls.Add(this.IPPLBL4);
            this.GroupIPPDetails.Controls.Add(this.IPPLBL3);
            this.GroupIPPDetails.Controls.Add(this.IPPLBL2);
            this.GroupIPPDetails.Controls.Add(this.IPPMemberId);
            this.GroupIPPDetails.Controls.Add(this.IPPMemberName);
            this.GroupIPPDetails.Controls.Add(this.IPPId);
            this.GroupIPPDetails.ImeMode = System.Windows.Forms.ImeMode.On;
            this.GroupIPPDetails.Location = new System.Drawing.Point(8, 320);
            this.GroupIPPDetails.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.GroupIPPDetails.LookAndFeel.UseDefaultLookAndFeel = false;
            this.GroupIPPDetails.Name = "GroupIPPDetails";
            this.GroupIPPDetails.Size = new System.Drawing.Size(992, 240);
            this.toolTipController1.SetSuperTip(this.GroupIPPDetails, null);
            this.GroupIPPDetails.TabIndex = 14;
            this.GroupIPPDetails.Text = "IPP Details";
            // 
            // strReferenceNo
            // 
            this.strReferenceNo.EditValue = "";
            this.strReferenceNo.Location = new System.Drawing.Point(600, 200);
            this.strReferenceNo.Name = "strReferenceNo";
            this.strReferenceNo.Size = new System.Drawing.Size(168, 20);
            this.strReferenceNo.TabIndex = 150;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(424, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 16);
            this.toolTipController1.SetSuperTip(this.label7, null);
            this.label7.TabIndex = 149;
            this.label7.Text = "Reference Number  :";
            // 
            // IPPBankCode
            // 
            this.IPPBankCode.Location = new System.Drawing.Point(600, 128);
            this.IPPBankCode.Name = "IPPBankCode";
            this.IPPBankCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.IPPBankCode.Size = new System.Drawing.Size(168, 20);
            this.IPPBankCode.TabIndex = 145;
            this.IPPBankCode.EditValueChanged += new System.EventHandler(this.IPPBankCode_EditValueChanged);
            // 
            // IPPNMonths
            // 
            this.IPPNMonths.Location = new System.Drawing.Point(600, 176);
            this.IPPNMonths.Name = "IPPNMonths";
            this.IPPNMonths.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.IPPNMonths.Size = new System.Drawing.Size(168, 20);
            this.IPPNMonths.TabIndex = 144;
            // 
            // IPPCCNo
            // 
            this.IPPCCNo.AllowDrop = true;
            this.IPPCCNo.EditValue = "";
            this.IPPCCNo.Location = new System.Drawing.Point(600, 152);
            this.IPPCCNo.Name = "IPPCCNo";
            this.IPPCCNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPCCNo.Properties.Appearance.Options.UseFont = true;
            this.IPPCCNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.IPPCCNo.Properties.Mask.BeepOnError = true;
            this.IPPCCNo.Properties.Mask.EditMask = "\\d{4}-\\d{4}-\\d{4}-\\d{4}";
            this.IPPCCNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.IPPCCNo.Properties.Mask.SaveLiteral = false;
            this.IPPCCNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.IPPCCNo.Properties.MaxLength = 19;
            this.IPPCCNo.Size = new System.Drawing.Size(168, 20);
            this.IPPCCNo.TabIndex = 143;
            // 
            // IPPStatus
            // 
            this.IPPStatus.EditValue = "";
            this.IPPStatus.Enabled = false;
            this.IPPStatus.Location = new System.Drawing.Point(600, 104);
            this.IPPStatus.Name = "IPPStatus";
            this.IPPStatus.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.IPPStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPStatus.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.IPPStatus.Properties.Appearance.Options.UseBackColor = true;
            this.IPPStatus.Properties.Appearance.Options.UseFont = true;
            this.IPPStatus.Properties.Appearance.Options.UseForeColor = true;
            this.IPPStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.IPPStatus.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.IPPStatus.Properties.ReadOnly = true;
            this.IPPStatus.ShowToolTips = false;
            this.IPPStatus.Size = new System.Drawing.Size(168, 18);
            this.IPPStatus.TabIndex = 141;
            // 
            // IPPDateRcv
            // 
            this.IPPDateRcv.EditValue = "";
            this.IPPDateRcv.Enabled = false;
            this.IPPDateRcv.Location = new System.Drawing.Point(600, 80);
            this.IPPDateRcv.Name = "IPPDateRcv";
            this.IPPDateRcv.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.IPPDateRcv.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPDateRcv.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.IPPDateRcv.Properties.Appearance.Options.UseBackColor = true;
            this.IPPDateRcv.Properties.Appearance.Options.UseFont = true;
            this.IPPDateRcv.Properties.Appearance.Options.UseForeColor = true;
            this.IPPDateRcv.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.IPPDateRcv.Properties.DisplayFormat.FormatString = "d";
            this.IPPDateRcv.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.IPPDateRcv.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.IPPDateRcv.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.IPPDateRcv.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.IPPDateRcv.Properties.ReadOnly = true;
            this.IPPDateRcv.ShowToolTips = false;
            this.IPPDateRcv.Size = new System.Drawing.Size(168, 18);
            this.IPPDateRcv.TabIndex = 140;
            // 
            // IPPDateSent
            // 
            this.IPPDateSent.EditValue = "";
            this.IPPDateSent.Enabled = false;
            this.IPPDateSent.Location = new System.Drawing.Point(600, 56);
            this.IPPDateSent.Name = "IPPDateSent";
            this.IPPDateSent.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.IPPDateSent.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPDateSent.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.IPPDateSent.Properties.Appearance.Options.UseBackColor = true;
            this.IPPDateSent.Properties.Appearance.Options.UseFont = true;
            this.IPPDateSent.Properties.Appearance.Options.UseForeColor = true;
            this.IPPDateSent.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.IPPDateSent.Properties.DisplayFormat.FormatString = "d";
            this.IPPDateSent.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.IPPDateSent.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.IPPDateSent.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.IPPDateSent.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.IPPDateSent.Properties.ReadOnly = true;
            this.IPPDateSent.ShowToolTips = false;
            this.IPPDateSent.Size = new System.Drawing.Size(168, 18);
            this.IPPDateSent.TabIndex = 139;
            // 
            // IPPBranchCode
            // 
            this.IPPBranchCode.EditValue = "";
            this.IPPBranchCode.Enabled = false;
            this.IPPBranchCode.Location = new System.Drawing.Point(184, 128);
            this.IPPBranchCode.Name = "IPPBranchCode";
            this.IPPBranchCode.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.IPPBranchCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPBranchCode.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.IPPBranchCode.Properties.Appearance.Options.UseBackColor = true;
            this.IPPBranchCode.Properties.Appearance.Options.UseFont = true;
            this.IPPBranchCode.Properties.Appearance.Options.UseForeColor = true;
            this.IPPBranchCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.IPPBranchCode.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.IPPBranchCode.Properties.ReadOnly = true;
            this.IPPBranchCode.Size = new System.Drawing.Size(168, 18);
            this.IPPBranchCode.TabIndex = 138;
            // 
            // IPPCreatedDate
            // 
            this.IPPCreatedDate.EditValue = "";
            this.IPPCreatedDate.Enabled = false;
            this.IPPCreatedDate.Location = new System.Drawing.Point(184, 56);
            this.IPPCreatedDate.Name = "IPPCreatedDate";
            this.IPPCreatedDate.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.IPPCreatedDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPCreatedDate.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.IPPCreatedDate.Properties.Appearance.Options.UseBackColor = true;
            this.IPPCreatedDate.Properties.Appearance.Options.UseFont = true;
            this.IPPCreatedDate.Properties.Appearance.Options.UseForeColor = true;
            this.IPPCreatedDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.IPPCreatedDate.Properties.DisplayFormat.FormatString = "d";
            this.IPPCreatedDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.IPPCreatedDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.IPPCreatedDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.IPPCreatedDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.IPPCreatedDate.Properties.ReadOnly = true;
            this.IPPCreatedDate.Size = new System.Drawing.Size(168, 18);
            this.IPPCreatedDate.TabIndex = 137;
            // 
            // IPPLBL1
            // 
            this.IPPLBL1.AutoSize = true;
            this.IPPLBL1.BackColor = System.Drawing.Color.Transparent;
            this.IPPLBL1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPLBL1.Location = new System.Drawing.Point(32, 32);
            this.IPPLBL1.Name = "IPPLBL1";
            this.IPPLBL1.Size = new System.Drawing.Size(55, 16);
            this.toolTipController1.SetSuperTip(this.IPPLBL1, null);
            this.IPPLBL1.TabIndex = 136;
            this.IPPLBL1.Text = "IPP Id :";
            // 
            // IPPLBL16
            // 
            this.IPPLBL16.AutoSize = true;
            this.IPPLBL16.BackColor = System.Drawing.Color.Transparent;
            this.IPPLBL16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPLBL16.Location = new System.Drawing.Point(32, 128);
            this.IPPLBL16.Name = "IPPLBL16";
            this.IPPLBL16.Size = new System.Drawing.Size(98, 16);
            this.toolTipController1.SetSuperTip(this.IPPLBL16, null);
            this.IPPLBL16.TabIndex = 135;
            this.IPPLBL16.Text = "Branch Code :";
            // 
            // IPPMerchantNo
            // 
            this.IPPMerchantNo.EditValue = "";
            this.IPPMerchantNo.Enabled = false;
            this.IPPMerchantNo.Location = new System.Drawing.Point(184, 152);
            this.IPPMerchantNo.Name = "IPPMerchantNo";
            this.IPPMerchantNo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.IPPMerchantNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPMerchantNo.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.IPPMerchantNo.Properties.Appearance.Options.UseBackColor = true;
            this.IPPMerchantNo.Properties.Appearance.Options.UseFont = true;
            this.IPPMerchantNo.Properties.Appearance.Options.UseForeColor = true;
            this.IPPMerchantNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.IPPMerchantNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.IPPMerchantNo.Properties.ReadOnly = true;
            this.IPPMerchantNo.Size = new System.Drawing.Size(166, 18);
            this.IPPMerchantNo.TabIndex = 133;
            // 
            // IPPLBL8
            // 
            this.IPPLBL8.AutoSize = true;
            this.IPPLBL8.BackColor = System.Drawing.Color.Transparent;
            this.IPPLBL8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPLBL8.Location = new System.Drawing.Point(32, 152);
            this.IPPLBL8.Name = "IPPLBL8";
            this.IPPLBL8.Size = new System.Drawing.Size(99, 16);
            this.toolTipController1.SetSuperTip(this.IPPLBL8, null);
            this.IPPLBL8.TabIndex = 132;
            this.IPPLBL8.Text = "Merchant No :";
            // 
            // IPPLBL14
            // 
            this.IPPLBL14.AutoSize = true;
            this.IPPLBL14.BackColor = System.Drawing.Color.Transparent;
            this.IPPLBL14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPLBL14.Location = new System.Drawing.Point(424, 104);
            this.IPPLBL14.Name = "IPPLBL14";
            this.IPPLBL14.Size = new System.Drawing.Size(60, 16);
            this.toolTipController1.SetSuperTip(this.IPPLBL14, null);
            this.IPPLBL14.TabIndex = 131;
            this.IPPLBL14.Text = "Status :";
            // 
            // IPPLBL12
            // 
            this.IPPLBL12.AutoSize = true;
            this.IPPLBL12.BackColor = System.Drawing.Color.Transparent;
            this.IPPLBL12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPLBL12.Location = new System.Drawing.Point(424, 56);
            this.IPPLBL12.Name = "IPPLBL12";
            this.IPPLBL12.Size = new System.Drawing.Size(135, 16);
            this.toolTipController1.SetSuperTip(this.IPPLBL12, null);
            this.IPPLBL12.TabIndex = 130;
            this.IPPLBL12.Text = "Date Sent to Bank :";
            // 
            // IPPLBL13
            // 
            this.IPPLBL13.AutoSize = true;
            this.IPPLBL13.BackColor = System.Drawing.Color.Transparent;
            this.IPPLBL13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPLBL13.Location = new System.Drawing.Point(424, 80);
            this.IPPLBL13.Name = "IPPLBL13";
            this.IPPLBL13.Size = new System.Drawing.Size(151, 16);
            this.toolTipController1.SetSuperTip(this.IPPLBL13, null);
            this.IPPLBL13.TabIndex = 129;
            this.IPPLBL13.Text = "Date Received Reply :";
            // 
            // IPPLBL11
            // 
            this.IPPLBL11.AutoSize = true;
            this.IPPLBL11.BackColor = System.Drawing.Color.Transparent;
            this.IPPLBL11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPLBL11.Location = new System.Drawing.Point(424, 32);
            this.IPPLBL11.Name = "IPPLBL11";
            this.IPPLBL11.Size = new System.Drawing.Size(100, 16);
            this.toolTipController1.SetSuperTip(this.IPPLBL11, null);
            this.IPPLBL11.TabIndex = 128;
            this.IPPLBL11.Text = "Nett Amount :";
            // 
            // IPPLBL10
            // 
            this.IPPLBL10.AutoSize = true;
            this.IPPLBL10.BackColor = System.Drawing.Color.Transparent;
            this.IPPLBL10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPLBL10.Location = new System.Drawing.Point(32, 200);
            this.IPPLBL10.Name = "IPPLBL10";
            this.IPPLBL10.Size = new System.Drawing.Size(71, 16);
            this.toolTipController1.SetSuperTip(this.IPPLBL10, null);
            this.IPPLBL10.TabIndex = 127;
            this.IPPLBL10.Text = "Interest :";
            // 
            // IPPLBL9
            // 
            this.IPPLBL9.AutoSize = true;
            this.IPPLBL9.BackColor = System.Drawing.Color.Transparent;
            this.IPPLBL9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPLBL9.Location = new System.Drawing.Point(32, 176);
            this.IPPLBL9.Name = "IPPLBL9";
            this.IPPLBL9.Size = new System.Drawing.Size(68, 16);
            this.toolTipController1.SetSuperTip(this.IPPLBL9, null);
            this.IPPLBL9.TabIndex = 126;
            this.IPPLBL9.Text = "Amount :";
            this.IPPLBL9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // IPPLBL7
            // 
            this.IPPLBL7.AutoSize = true;
            this.IPPLBL7.BackColor = System.Drawing.Color.Transparent;
            this.IPPLBL7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPLBL7.Location = new System.Drawing.Point(424, 176);
            this.IPPLBL7.Name = "IPPLBL7";
            this.IPPLBL7.Size = new System.Drawing.Size(139, 16);
            this.toolTipController1.SetSuperTip(this.IPPLBL7, null);
            this.IPPLBL7.TabIndex = 125;
            this.IPPLBL7.Text = "Number of Months  :";
            // 
            // IPPAmount
            // 
            this.IPPAmount.EditValue = "";
            this.IPPAmount.Enabled = false;
            this.IPPAmount.Location = new System.Drawing.Point(184, 176);
            this.IPPAmount.Name = "IPPAmount";
            this.IPPAmount.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.IPPAmount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPAmount.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.IPPAmount.Properties.Appearance.Options.UseBackColor = true;
            this.IPPAmount.Properties.Appearance.Options.UseFont = true;
            this.IPPAmount.Properties.Appearance.Options.UseForeColor = true;
            this.IPPAmount.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.IPPAmount.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.IPPAmount.Properties.ReadOnly = true;
            this.IPPAmount.Size = new System.Drawing.Size(166, 18);
            this.IPPAmount.TabIndex = 124;
            // 
            // IPPInterest
            // 
            this.IPPInterest.EditValue = "";
            this.IPPInterest.Enabled = false;
            this.IPPInterest.Location = new System.Drawing.Point(184, 200);
            this.IPPInterest.Name = "IPPInterest";
            this.IPPInterest.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.IPPInterest.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPInterest.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.IPPInterest.Properties.Appearance.Options.UseBackColor = true;
            this.IPPInterest.Properties.Appearance.Options.UseFont = true;
            this.IPPInterest.Properties.Appearance.Options.UseForeColor = true;
            this.IPPInterest.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.IPPInterest.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.IPPInterest.Properties.ReadOnly = true;
            this.IPPInterest.Size = new System.Drawing.Size(166, 18);
            this.IPPInterest.TabIndex = 123;
            // 
            // IPPNettAmount
            // 
            this.IPPNettAmount.EditValue = "";
            this.IPPNettAmount.Enabled = false;
            this.IPPNettAmount.Location = new System.Drawing.Point(600, 32);
            this.IPPNettAmount.Name = "IPPNettAmount";
            this.IPPNettAmount.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.IPPNettAmount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPNettAmount.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.IPPNettAmount.Properties.Appearance.Options.UseBackColor = true;
            this.IPPNettAmount.Properties.Appearance.Options.UseFont = true;
            this.IPPNettAmount.Properties.Appearance.Options.UseForeColor = true;
            this.IPPNettAmount.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.IPPNettAmount.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.IPPNettAmount.Properties.ReadOnly = true;
            this.IPPNettAmount.Size = new System.Drawing.Size(166, 18);
            this.IPPNettAmount.TabIndex = 122;
            // 
            // IPPLBL5
            // 
            this.IPPLBL5.AutoSize = true;
            this.IPPLBL5.BackColor = System.Drawing.Color.Transparent;
            this.IPPLBL5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPLBL5.Location = new System.Drawing.Point(424, 128);
            this.IPPLBL5.Name = "IPPLBL5";
            this.IPPLBL5.Size = new System.Drawing.Size(84, 16);
            this.toolTipController1.SetSuperTip(this.IPPLBL5, null);
            this.IPPLBL5.TabIndex = 121;
            this.IPPLBL5.Text = "Bank Code :";
            // 
            // IPPLBL6
            // 
            this.IPPLBL6.AutoSize = true;
            this.IPPLBL6.BackColor = System.Drawing.Color.Transparent;
            this.IPPLBL6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPLBL6.Location = new System.Drawing.Point(424, 152);
            this.IPPLBL6.Name = "IPPLBL6";
            this.IPPLBL6.Size = new System.Drawing.Size(114, 16);
            this.toolTipController1.SetSuperTip(this.IPPLBL6, null);
            this.IPPLBL6.TabIndex = 120;
            this.IPPLBL6.Text = "Credit Card No. :";
            // 
            // IPPLBL4
            // 
            this.IPPLBL4.AutoSize = true;
            this.IPPLBL4.BackColor = System.Drawing.Color.Transparent;
            this.IPPLBL4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPLBL4.Location = new System.Drawing.Point(32, 104);
            this.IPPLBL4.Name = "IPPLBL4";
            this.IPPLBL4.Size = new System.Drawing.Size(108, 16);
            this.toolTipController1.SetSuperTip(this.IPPLBL4, null);
            this.IPPLBL4.TabIndex = 119;
            this.IPPLBL4.Text = "Member Name :";
            // 
            // IPPLBL3
            // 
            this.IPPLBL3.AutoSize = true;
            this.IPPLBL3.BackColor = System.Drawing.Color.Transparent;
            this.IPPLBL3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPLBL3.Location = new System.Drawing.Point(32, 80);
            this.IPPLBL3.Name = "IPPLBL3";
            this.IPPLBL3.Size = new System.Drawing.Size(86, 16);
            this.toolTipController1.SetSuperTip(this.IPPLBL3, null);
            this.IPPLBL3.TabIndex = 118;
            this.IPPLBL3.Text = "Member Id :";
            // 
            // IPPLBL2
            // 
            this.IPPLBL2.AutoSize = true;
            this.IPPLBL2.BackColor = System.Drawing.Color.Transparent;
            this.IPPLBL2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPLBL2.Location = new System.Drawing.Point(32, 56);
            this.IPPLBL2.Name = "IPPLBL2";
            this.IPPLBL2.Size = new System.Drawing.Size(104, 16);
            this.toolTipController1.SetSuperTip(this.IPPLBL2, null);
            this.IPPLBL2.TabIndex = 117;
            this.IPPLBL2.Text = "Date Created :";
            this.IPPLBL2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // IPPMemberId
            // 
            this.IPPMemberId.EditValue = "";
            this.IPPMemberId.Enabled = false;
            this.IPPMemberId.Location = new System.Drawing.Point(184, 80);
            this.IPPMemberId.Name = "IPPMemberId";
            this.IPPMemberId.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.IPPMemberId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPMemberId.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.IPPMemberId.Properties.Appearance.Options.UseBackColor = true;
            this.IPPMemberId.Properties.Appearance.Options.UseFont = true;
            this.IPPMemberId.Properties.Appearance.Options.UseForeColor = true;
            this.IPPMemberId.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.IPPMemberId.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.IPPMemberId.Properties.ReadOnly = true;
            this.IPPMemberId.Size = new System.Drawing.Size(168, 18);
            this.IPPMemberId.TabIndex = 115;
            // 
            // IPPMemberName
            // 
            this.IPPMemberName.EditValue = "";
            this.IPPMemberName.Enabled = false;
            this.IPPMemberName.Location = new System.Drawing.Point(184, 104);
            this.IPPMemberName.Name = "IPPMemberName";
            this.IPPMemberName.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.IPPMemberName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPMemberName.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.IPPMemberName.Properties.Appearance.Options.UseBackColor = true;
            this.IPPMemberName.Properties.Appearance.Options.UseFont = true;
            this.IPPMemberName.Properties.Appearance.Options.UseForeColor = true;
            this.IPPMemberName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.IPPMemberName.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.IPPMemberName.Properties.ReadOnly = true;
            this.IPPMemberName.Size = new System.Drawing.Size(168, 18);
            this.IPPMemberName.TabIndex = 114;
            // 
            // IPPId
            // 
            this.IPPId.EditValue = "";
            this.IPPId.Enabled = false;
            this.IPPId.Location = new System.Drawing.Point(184, 32);
            this.IPPId.Name = "IPPId";
            this.IPPId.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.IPPId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPPId.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.IPPId.Properties.Appearance.Options.UseBackColor = true;
            this.IPPId.Properties.Appearance.Options.UseFont = true;
            this.IPPId.Properties.Appearance.Options.UseForeColor = true;
            this.IPPId.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.IPPId.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.IPPId.Properties.ReadOnly = true;
            this.IPPId.Size = new System.Drawing.Size(168, 18);
            this.IPPId.TabIndex = 113;
            // 
            // groupIPPReceipt
            // 
            this.groupIPPReceipt.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupIPPReceipt.Appearance.Options.UseBackColor = true;
            this.groupIPPReceipt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupIPPReceipt.Controls.Add(this.btnReceiptUnlink);
            this.groupIPPReceipt.Controls.Add(this.btnReceiptLink);
            this.groupIPPReceipt.Controls.Add(this.gridReceipt);
            this.groupIPPReceipt.Controls.Add(this.label10);
            this.groupIPPReceipt.Controls.Add(this.IPPReceiptStatus);
            this.groupIPPReceipt.ImeMode = System.Windows.Forms.ImeMode.On;
            this.groupIPPReceipt.Location = new System.Drawing.Point(8, 320);
            this.groupIPPReceipt.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupIPPReceipt.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupIPPReceipt.Name = "groupIPPReceipt";
            this.groupIPPReceipt.Size = new System.Drawing.Size(992, 240);
            this.toolTipController1.SetSuperTip(this.groupIPPReceipt, null);
            this.groupIPPReceipt.TabIndex = 17;
            this.groupIPPReceipt.Text = "Receipt Entry";
            // 
            // btnReceiptUnlink
            // 
            this.btnReceiptUnlink.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnReceiptUnlink.Appearance.Options.UseFont = true;
            this.btnReceiptUnlink.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnReceiptUnlink.Location = new System.Drawing.Point(272, 24);
            this.btnReceiptUnlink.Name = "btnReceiptUnlink";
            this.btnReceiptUnlink.Size = new System.Drawing.Size(67, 20);
            this.btnReceiptUnlink.TabIndex = 128;
            this.btnReceiptUnlink.Text = "Unlink";
            this.btnReceiptUnlink.Click += new System.EventHandler(this.btnReceiptUnlink_Click);
            // 
            // btnReceiptLink
            // 
            this.btnReceiptLink.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnReceiptLink.Appearance.Options.UseFont = true;
            this.btnReceiptLink.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnReceiptLink.Enabled = false;
            this.btnReceiptLink.Location = new System.Drawing.Point(200, 24);
            this.btnReceiptLink.Name = "btnReceiptLink";
            this.btnReceiptLink.Size = new System.Drawing.Size(67, 20);
            this.btnReceiptLink.TabIndex = 127;
            this.btnReceiptLink.Text = "Link";
            this.btnReceiptLink.Click += new System.EventHandler(this.btnReceiptLink_Click);
            // 
            // gridReceipt
            // 
            this.gridReceipt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridReceipt.EmbeddedNavigator.Name = "";
            gridLevelNode2.RelationName = "Level1";
            this.gridReceipt.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.gridReceipt.Location = new System.Drawing.Point(2, 54);
            this.gridReceipt.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridReceipt.MainView = this.IPPReceiptView;
            this.gridReceipt.Name = "gridReceipt";
            this.gridReceipt.Size = new System.Drawing.Size(988, 184);
            this.gridReceipt.TabIndex = 126;
            this.gridReceipt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.IPPReceiptView});
            // 
            // IPPReceiptView
            // 
            this.IPPReceiptView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnIPPR,
            this.gridColumnIPPR1,
            this.gridColumnIPPR2,
            this.gridColumnIPPR3,
            this.gridColumnIPPR4,
            this.gridColumnIPPR5,
            this.gridColumnIPPR6,
            this.gridColumnIPPR7,
            this.gridColumnIPPR8,
            this.gridColumnIPPR9});
            this.IPPReceiptView.GridControl = this.gridReceipt;
            this.IPPReceiptView.Name = "IPPReceiptView";
            this.IPPReceiptView.OptionsBehavior.Editable = false;
            this.IPPReceiptView.OptionsCustomization.AllowFilter = false;
            this.IPPReceiptView.OptionsCustomization.AllowSort = false;
            this.IPPReceiptView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.IPPReceiptView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnIPPR
            // 
            this.gridColumnIPPR.Caption = "IPP ID";
            this.gridColumnIPPR.FieldName = "nIPPID";
            this.gridColumnIPPR.Name = "gridColumnIPPR";
            // 
            // gridColumnIPPR1
            // 
            this.gridColumnIPPR1.Caption = "Date";
            this.gridColumnIPPR1.FieldName = "dtDate";
            this.gridColumnIPPR1.Name = "gridColumnIPPR1";
            this.gridColumnIPPR1.Visible = true;
            this.gridColumnIPPR1.VisibleIndex = 0;
            this.gridColumnIPPR1.Width = 109;
            // 
            // gridColumnIPPR2
            // 
            this.gridColumnIPPR2.Caption = "Receipt No";
            this.gridColumnIPPR2.FieldName = "strReceiptNo";
            this.gridColumnIPPR2.Name = "gridColumnIPPR2";
            this.gridColumnIPPR2.Visible = true;
            this.gridColumnIPPR2.VisibleIndex = 1;
            this.gridColumnIPPR2.Width = 109;
            // 
            // gridColumnIPPR3
            // 
            this.gridColumnIPPR3.Caption = "Category";
            this.gridColumnIPPR3.FieldName = "Category";
            this.gridColumnIPPR3.Name = "gridColumnIPPR3";
            this.gridColumnIPPR3.Visible = true;
            this.gridColumnIPPR3.VisibleIndex = 2;
            this.gridColumnIPPR3.Width = 109;
            // 
            // gridColumnIPPR4
            // 
            this.gridColumnIPPR4.Caption = "Nett";
            this.gridColumnIPPR4.FieldName = "mNettAmount";
            this.gridColumnIPPR4.Name = "gridColumnIPPR4";
            this.gridColumnIPPR4.Visible = true;
            this.gridColumnIPPR4.VisibleIndex = 3;
            this.gridColumnIPPR4.Width = 109;
            // 
            // gridColumnIPPR5
            // 
            this.gridColumnIPPR5.Caption = "GST";
            this.gridColumnIPPR5.FieldName = "mGSTAmount";
            this.gridColumnIPPR5.Name = "gridColumnIPPR5";
            this.gridColumnIPPR5.Visible = true;
            this.gridColumnIPPR5.VisibleIndex = 4;
            this.gridColumnIPPR5.Width = 64;
            // 
            // gridColumnIPPR6
            // 
            this.gridColumnIPPR6.Caption = "Total";
            this.gridColumnIPPR6.FieldName = "mTotalAmount";
            this.gridColumnIPPR6.Name = "gridColumnIPPR6";
            this.gridColumnIPPR6.Visible = true;
            this.gridColumnIPPR6.VisibleIndex = 5;
            this.gridColumnIPPR6.Width = 123;
            // 
            // gridColumnIPPR7
            // 
            this.gridColumnIPPR7.Caption = "O/S Amount";
            this.gridColumnIPPR7.FieldName = "mGSTAmount";
            this.gridColumnIPPR7.Name = "gridColumnIPPR7";
            this.gridColumnIPPR7.Visible = true;
            this.gridColumnIPPR7.VisibleIndex = 6;
            this.gridColumnIPPR7.Width = 85;
            // 
            // gridColumnIPPR8
            // 
            this.gridColumnIPPR8.Caption = "Member";
            this.gridColumnIPPR8.FieldName = "SalesPerson";
            this.gridColumnIPPR8.Name = "gridColumnIPPR8";
            this.gridColumnIPPR8.Visible = true;
            this.gridColumnIPPR8.VisibleIndex = 7;
            this.gridColumnIPPR8.Width = 167;
            // 
            // gridColumnIPPR9
            // 
            this.gridColumnIPPR9.Caption = "Payment ID";
            this.gridColumnIPPR9.FieldName = "nPaymentID";
            this.gridColumnIPPR9.Name = "gridColumnIPPR9";
            this.gridColumnIPPR9.Visible = true;
            this.gridColumnIPPR9.VisibleIndex = 8;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 16);
            this.toolTipController1.SetSuperTip(this.label10, null);
            this.label10.TabIndex = 125;
            this.label10.Text = "Status";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IPPReceiptStatus
            // 
            this.IPPReceiptStatus.EditValue = 0;
            this.IPPReceiptStatus.Location = new System.Drawing.Point(80, 24);
            this.IPPReceiptStatus.Name = "IPPReceiptStatus";
            this.IPPReceiptStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.IPPReceiptStatus.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Linked", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Unlink", 1, -1)});
            this.IPPReceiptStatus.Size = new System.Drawing.Size(100, 20);
            this.IPPReceiptStatus.TabIndex = 24;
            this.IPPReceiptStatus.SelectedIndexChanged += new System.EventHandler(this.IPPReceiptStatus_SelectedIndexChanged);
            // 
            // groupGIROMaster
            // 
            this.groupGIROMaster.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupGIROMaster.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupGIROMaster.Controls.Add(this.xtraTabControl1);
            this.groupGIROMaster.Controls.Add(this.GroupGiro);
            this.groupGIROMaster.ImeMode = System.Windows.Forms.ImeMode.On;
            this.groupGIROMaster.Location = new System.Drawing.Point(0, 32);
            this.groupGIROMaster.Name = "groupGIROMaster";
            this.groupGIROMaster.Size = new System.Drawing.Size(1007, 608);
            this.toolTipController1.SetSuperTip(this.groupGIROMaster, null);
            this.groupGIROMaster.TabIndex = 24;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtraTabControl1.AppearancePage.Header.Options.UseFont = true;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 344);
            this.xtraTabControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabGiroDetails;
            this.xtraTabControl1.Size = new System.Drawing.Size(1007, 264);
            this.xtraTabControl1.TabIndex = 36;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabGiroDetails,
            this.tabGiroTrnsHistory});
            this.xtraTabControl1.Text = "xtraTabControl1";
            // 
            // tabGiroDetails
            // 
            this.tabGiroDetails.Controls.Add(this.luedtBankBranch);
            this.tabGiroDetails.Controls.Add(this.luedtBank);
            this.tabGiroDetails.Controls.Add(this.luedtPackage);
            this.tabGiroDetails.Controls.Add(this.luedtBranch);
            this.tabGiroDetails.Controls.Add(this.label70);
            this.tabGiroDetails.Controls.Add(this.txtPackageDesc);
            this.tabGiroDetails.Controls.Add(this.txtAccountNo);
            this.tabGiroDetails.Controls.Add(this.txtGIROId);
            this.tabGiroDetails.Controls.Add(this.txtRemark);
            this.tabGiroDetails.Controls.Add(this.lblGiro_BankBranch);
            this.tabGiroDetails.Controls.Add(this.lblGiro_BankACNumber);
            this.tabGiroDetails.Controls.Add(this.lblGiro_BankCode);
            this.tabGiroDetails.Controls.Add(this.lblGiro_Remark);
            this.tabGiroDetails.Controls.Add(this.lblGiro_Package);
            this.tabGiroDetails.Controls.Add(this.lblGiro_Branch);
            this.tabGiroDetails.Controls.Add(this.lblGiro_MemberID);
            this.tabGiroDetails.Controls.Add(this.lblGiroID);
            this.tabGiroDetails.Name = "tabGiroDetails";
            this.tabGiroDetails.Size = new System.Drawing.Size(998, 230);
            this.tabGiroDetails.Text = "Giro Details";
            // 
            // luedtBankBranch
            // 
            this.luedtBankBranch.Location = new System.Drawing.Point(520, 40);
            this.luedtBankBranch.Name = "luedtBankBranch";
            this.luedtBankBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luedtBankBranch.Size = new System.Drawing.Size(184, 20);
            this.luedtBankBranch.TabIndex = 142;
            // 
            // luedtBank
            // 
            this.luedtBank.Location = new System.Drawing.Point(520, 16);
            this.luedtBank.Name = "luedtBank";
            this.luedtBank.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luedtBank.Size = new System.Drawing.Size(184, 20);
            this.luedtBank.TabIndex = 141;
            // 
            // luedtPackage
            // 
            this.luedtPackage.Location = new System.Drawing.Point(176, 88);
            this.luedtPackage.Name = "luedtPackage";
            this.luedtPackage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luedtPackage.Size = new System.Drawing.Size(184, 20);
            this.luedtPackage.TabIndex = 140;
            // 
            // luedtBranch
            // 
            this.luedtBranch.Location = new System.Drawing.Point(176, 64);
            this.luedtBranch.Name = "luedtBranch";
            this.luedtBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luedtBranch.Size = new System.Drawing.Size(184, 20);
            this.luedtBranch.TabIndex = 139;
            // 
            // label70
            // 
            this.label70.BackColor = System.Drawing.Color.Transparent;
            this.label70.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.Location = new System.Drawing.Point(32, 112);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(144, 16);
            this.toolTipController1.SetSuperTip(this.label70, null);
            this.label70.TabIndex = 119;
            this.label70.Text = "Package Description";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPackageDesc
            // 
            this.txtPackageDesc.EditValue = "";
            this.txtPackageDesc.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPackageDesc.Location = new System.Drawing.Point(176, 112);
            this.txtPackageDesc.Name = "txtPackageDesc";
            this.txtPackageDesc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPackageDesc.Properties.Appearance.Options.UseFont = true;
            this.txtPackageDesc.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtPackageDesc.Size = new System.Drawing.Size(184, 20);
            this.txtPackageDesc.TabIndex = 117;
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.EditValue = "";
            this.txtAccountNo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtAccountNo.Location = new System.Drawing.Point(520, 64);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountNo.Properties.Appearance.Options.UseFont = true;
            this.txtAccountNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtAccountNo.Size = new System.Drawing.Size(184, 20);
            this.txtAccountNo.TabIndex = 116;
            // 
            // txtGIROId
            // 
            this.txtGIROId.EditValue = "";
            this.txtGIROId.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtGIROId.Location = new System.Drawing.Point(176, 16);
            this.txtGIROId.Name = "txtGIROId";
            this.txtGIROId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGIROId.Properties.Appearance.Options.UseFont = true;
            this.txtGIROId.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtGIROId.Size = new System.Drawing.Size(184, 20);
            this.txtGIROId.TabIndex = 111;
            // 
            // txtRemark
            // 
            this.txtRemark.EditValue = "";
            this.txtRemark.Location = new System.Drawing.Point(176, 136);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Properties.Appearance.Options.UseFont = true;
            this.txtRemark.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtRemark.Size = new System.Drawing.Size(528, 56);
            this.txtRemark.TabIndex = 110;
            // 
            // lblGiro_BankBranch
            // 
            this.lblGiro_BankBranch.BackColor = System.Drawing.Color.Transparent;
            this.lblGiro_BankBranch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiro_BankBranch.Location = new System.Drawing.Point(392, 40);
            this.lblGiro_BankBranch.Name = "lblGiro_BankBranch";
            this.lblGiro_BankBranch.Size = new System.Drawing.Size(128, 16);
            this.toolTipController1.SetSuperTip(this.lblGiro_BankBranch, null);
            this.lblGiro_BankBranch.TabIndex = 101;
            this.lblGiro_BankBranch.Text = "Bank Branch";
            this.lblGiro_BankBranch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGiro_BankACNumber
            // 
            this.lblGiro_BankACNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblGiro_BankACNumber.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiro_BankACNumber.Location = new System.Drawing.Point(392, 64);
            this.lblGiro_BankACNumber.Name = "lblGiro_BankACNumber";
            this.lblGiro_BankACNumber.Size = new System.Drawing.Size(128, 16);
            this.toolTipController1.SetSuperTip(this.lblGiro_BankACNumber, null);
            this.lblGiro_BankACNumber.TabIndex = 100;
            this.lblGiro_BankACNumber.Text = "Account Number";
            this.lblGiro_BankACNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGiro_BankCode
            // 
            this.lblGiro_BankCode.BackColor = System.Drawing.Color.Transparent;
            this.lblGiro_BankCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiro_BankCode.Location = new System.Drawing.Point(392, 16);
            this.lblGiro_BankCode.Name = "lblGiro_BankCode";
            this.lblGiro_BankCode.Size = new System.Drawing.Size(128, 16);
            this.toolTipController1.SetSuperTip(this.lblGiro_BankCode, null);
            this.lblGiro_BankCode.TabIndex = 99;
            this.lblGiro_BankCode.Text = "Bank Code/Name";
            this.lblGiro_BankCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGiro_Remark
            // 
            this.lblGiro_Remark.BackColor = System.Drawing.Color.Transparent;
            this.lblGiro_Remark.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiro_Remark.Location = new System.Drawing.Point(32, 144);
            this.lblGiro_Remark.Name = "lblGiro_Remark";
            this.lblGiro_Remark.Size = new System.Drawing.Size(128, 16);
            this.toolTipController1.SetSuperTip(this.lblGiro_Remark, null);
            this.lblGiro_Remark.TabIndex = 98;
            this.lblGiro_Remark.Text = "Remark";
            this.lblGiro_Remark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGiro_Package
            // 
            this.lblGiro_Package.BackColor = System.Drawing.Color.Transparent;
            this.lblGiro_Package.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiro_Package.Location = new System.Drawing.Point(32, 88);
            this.lblGiro_Package.Name = "lblGiro_Package";
            this.lblGiro_Package.Size = new System.Drawing.Size(144, 16);
            this.toolTipController1.SetSuperTip(this.lblGiro_Package, null);
            this.lblGiro_Package.TabIndex = 97;
            this.lblGiro_Package.Text = "Package";
            this.lblGiro_Package.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGiro_Branch
            // 
            this.lblGiro_Branch.BackColor = System.Drawing.Color.Transparent;
            this.lblGiro_Branch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiro_Branch.Location = new System.Drawing.Point(32, 64);
            this.lblGiro_Branch.Name = "lblGiro_Branch";
            this.lblGiro_Branch.Size = new System.Drawing.Size(144, 16);
            this.toolTipController1.SetSuperTip(this.lblGiro_Branch, null);
            this.lblGiro_Branch.TabIndex = 96;
            this.lblGiro_Branch.Text = "Branch";
            this.lblGiro_Branch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGiro_MemberID
            // 
            this.lblGiro_MemberID.BackColor = System.Drawing.Color.Transparent;
            this.lblGiro_MemberID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiro_MemberID.Location = new System.Drawing.Point(32, 40);
            this.lblGiro_MemberID.Name = "lblGiro_MemberID";
            this.lblGiro_MemberID.Size = new System.Drawing.Size(144, 16);
            this.toolTipController1.SetSuperTip(this.lblGiro_MemberID, null);
            this.lblGiro_MemberID.TabIndex = 95;
            this.lblGiro_MemberID.Text = "Member ID /Name";
            this.lblGiro_MemberID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGiroID
            // 
            this.lblGiroID.BackColor = System.Drawing.Color.Transparent;
            this.lblGiroID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiroID.Location = new System.Drawing.Point(32, 16);
            this.lblGiroID.Name = "lblGiroID";
            this.lblGiroID.Size = new System.Drawing.Size(144, 16);
            this.toolTipController1.SetSuperTip(this.lblGiroID, null);
            this.lblGiroID.TabIndex = 93;
            this.lblGiroID.Text = "Giro ID";
            this.lblGiroID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabGiroTrnsHistory
            // 
            this.tabGiroTrnsHistory.Controls.Add(this.GridTransaction);
            this.tabGiroTrnsHistory.Name = "tabGiroTrnsHistory";
            this.tabGiroTrnsHistory.Size = new System.Drawing.Size(998, 230);
            this.tabGiroTrnsHistory.Text = "Transaction History";
            // 
            // GridTransaction
            // 
            this.GridTransaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridTransaction.EmbeddedNavigator.Name = "";
            this.GridTransaction.Location = new System.Drawing.Point(0, 0);
            this.GridTransaction.LookAndFeel.UseDefaultLookAndFeel = false;
            this.GridTransaction.MainView = this.gridView4;
            this.GridTransaction.Name = "GridTransaction";
            this.GridTransaction.Size = new System.Drawing.Size(998, 230);
            this.GridTransaction.TabIndex = 0;
            this.GridTransaction.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.GridTransaction;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsBehavior.Editable = false;
            this.gridView4.OptionsCustomization.AllowFilter = false;
            this.gridView4.OptionsCustomization.AllowSort = false;
            // 
            // GroupGiro
            // 
            this.GroupGiro.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.GroupGiro.Appearance.Options.UseBackColor = true;
            this.GroupGiro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.GroupGiro.Controls.Add(this.comboBoxGiroStatus);
            this.GroupGiro.Controls.Add(this.label63);
            this.GroupGiro.Controls.Add(this.btnImport);
            this.GroupGiro.Controls.Add(this.btnGiroExport);
            this.GroupGiro.Controls.Add(this.btnGiroUpdate);
            this.GroupGiro.Controls.Add(this.btnGiroDelete);
            this.GroupGiro.Controls.Add(this.btnGiroNew);
            this.GroupGiro.Controls.Add(this.GiroGrid);
            this.GroupGiro.ImeMode = System.Windows.Forms.ImeMode.On;
            this.GroupGiro.Location = new System.Drawing.Point(4, 0);
            this.GroupGiro.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.GroupGiro.LookAndFeel.UseDefaultLookAndFeel = false;
            this.GroupGiro.Name = "GroupGiro";
            this.GroupGiro.Size = new System.Drawing.Size(996, 336);
            this.toolTipController1.SetSuperTip(this.GroupGiro, null);
            this.GroupGiro.TabIndex = 19;
            this.GroupGiro.Text = "GIRO";
            // 
            // comboBoxGiroStatus
            // 
            this.comboBoxGiroStatus.EditValue = 1;
            this.comboBoxGiroStatus.Location = new System.Drawing.Point(8, 40);
            this.comboBoxGiroStatus.Name = "comboBoxGiroStatus";
            this.comboBoxGiroStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxGiroStatus.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Pending Approval", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Active", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Rejected", 3, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Deleted", 4, -1)});
            this.comboBoxGiroStatus.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.comboBoxGiroStatus.Size = new System.Drawing.Size(128, 20);
            this.comboBoxGiroStatus.TabIndex = 35;
            this.comboBoxGiroStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxGiroStatus_SelectedIndexChanged);
            // 
            // label63
            // 
            this.label63.BackColor = System.Drawing.Color.Transparent;
            this.label63.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label63.Location = new System.Drawing.Point(8, 24);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(100, 16);
            this.toolTipController1.SetSuperTip(this.label63, null);
            this.label63.TabIndex = 34;
            this.label63.Text = "Filter by Status";
            // 
            // btnImport
            // 
            this.btnImport.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnImport.Appearance.Options.UseFont = true;
            this.btnImport.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnImport.Location = new System.Drawing.Point(264, 48);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(72, 18);
            this.btnImport.TabIndex = 12;
            this.btnImport.Text = "Import";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnGiroExport
            // 
            this.btnGiroExport.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnGiroExport.Appearance.Options.UseFont = true;
            this.btnGiroExport.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnGiroExport.Location = new System.Drawing.Point(192, 48);
            this.btnGiroExport.Name = "btnGiroExport";
            this.btnGiroExport.Size = new System.Drawing.Size(64, 18);
            this.btnGiroExport.TabIndex = 11;
            this.btnGiroExport.Text = "Export";
            this.btnGiroExport.Click += new System.EventHandler(this.btnGiroExport_Click);
            // 
            // btnGiroUpdate
            // 
            this.btnGiroUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnGiroUpdate.Appearance.Options.UseFont = true;
            this.btnGiroUpdate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnGiroUpdate.Location = new System.Drawing.Point(344, 24);
            this.btnGiroUpdate.Name = "btnGiroUpdate";
            this.btnGiroUpdate.Size = new System.Drawing.Size(64, 18);
            this.btnGiroUpdate.TabIndex = 10;
            this.btnGiroUpdate.Text = "Update";
            this.btnGiroUpdate.Click += new System.EventHandler(this.btnGiroUpdate_Click);
            // 
            // btnGiroDelete
            // 
            this.btnGiroDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnGiroDelete.Appearance.Options.UseFont = true;
            this.btnGiroDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnGiroDelete.Location = new System.Drawing.Point(264, 24);
            this.btnGiroDelete.Name = "btnGiroDelete";
            this.btnGiroDelete.Size = new System.Drawing.Size(72, 18);
            this.btnGiroDelete.TabIndex = 5;
            this.btnGiroDelete.Text = "Delete";
            this.btnGiroDelete.Click += new System.EventHandler(this.btnGiroDelete_Click);
            // 
            // btnGiroNew
            // 
            this.btnGiroNew.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnGiroNew.Appearance.Options.UseFont = true;
            this.btnGiroNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnGiroNew.Location = new System.Drawing.Point(192, 24);
            this.btnGiroNew.Name = "btnGiroNew";
            this.btnGiroNew.Size = new System.Drawing.Size(64, 18);
            this.btnGiroNew.TabIndex = 2;
            this.btnGiroNew.Text = "New";
            this.btnGiroNew.Click += new System.EventHandler(this.btnGiroNew_Click);
            // 
            // GiroGrid
            // 
            this.GiroGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GiroGrid.EmbeddedNavigator.Name = "";
            gridLevelNode3.RelationName = "Level1";
            this.GiroGrid.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode3});
            this.GiroGrid.Location = new System.Drawing.Point(2, 78);
            this.GiroGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.GiroGrid.MainView = this.GIROGridView;
            this.GiroGrid.Name = "GiroGrid";
            this.GiroGrid.Size = new System.Drawing.Size(992, 256);
            this.GiroGrid.TabIndex = 0;
            this.GiroGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GIROGridView});
            // 
            // GIROGridView
            // 
            this.GIROGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.GIROGridView.GridControl = this.GiroGrid;
            this.GIROGridView.Name = "GIROGridView";
            this.GIROGridView.OptionsBehavior.Editable = false;
            this.GIROGridView.OptionsCustomization.AllowFilter = false;
            this.GIROGridView.OptionsSelection.MultiSelect = true;
            this.GIROGridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Giro Id";
            this.gridColumn1.FieldName = "nGIRORefID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Date";
            this.gridColumn2.FieldName = "dtDate";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Member ID";
            this.gridColumn3.FieldName = "strMembershipID";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Member Name";
            this.gridColumn4.FieldName = "strMemberName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Branch";
            this.gridColumn5.FieldName = "strBranchCode";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Package Code";
            this.gridColumn6.FieldName = "strPackageCode";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Package Description";
            this.gridColumn7.FieldName = "strDescription";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // tabManagerTwo
            // 
            this.tabManagerTwo.Controls.Add(this.GrpPayroll);
            this.tabManagerTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabManagerTwo.Name = "tabManagerTwo";
            this.tabManagerTwo.PageVisible = false;
            this.tabManagerTwo.Size = new System.Drawing.Size(1007, 637);
            this.tabManagerTwo.Text = "Payroll";
            // 
            // GrpPayroll
            // 
            this.GrpPayroll.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.GrpPayroll.Appearance.Options.UseBackColor = true;
            this.GrpPayroll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.GrpPayroll.Controls.Add(this.progressBarControl1);
            this.GrpPayroll.Controls.Add(this.cbJob);
            this.GrpPayroll.Controls.Add(this.label8);
            this.GrpPayroll.Controls.Add(this.grpGridExcel);
            this.GrpPayroll.Controls.Add(this.btnPayrollExport);
            this.GrpPayroll.Controls.Add(this.btnPayrollGenerate);
            this.GrpPayroll.Controls.Add(this.btnPayrollDelete);
            this.GrpPayroll.Controls.Add(this.comboBoxEditMTH);
            this.GrpPayroll.Controls.Add(this.comboBoxEditYR);
            this.GrpPayroll.Controls.Add(this.lblYear);
            this.GrpPayroll.Controls.Add(this.lblMonth);
            this.GrpPayroll.Controls.Add(this.cmbxPayroll);
            this.GrpPayroll.Controls.Add(this.gridPayroll);
            this.GrpPayroll.Location = new System.Drawing.Point(0, 0);
            this.GrpPayroll.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.GrpPayroll.LookAndFeel.UseDefaultLookAndFeel = false;
            this.GrpPayroll.Name = "GrpPayroll";
            this.GrpPayroll.Size = new System.Drawing.Size(994, 616);
            this.toolTipController1.SetSuperTip(this.GrpPayroll, null);
            this.GrpPayroll.TabIndex = 0;
            this.GrpPayroll.Text = "PAYROLL";
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Location = new System.Drawing.Point(784, 24);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Properties.ShowTitle = true;
            this.progressBarControl1.Size = new System.Drawing.Size(200, 16);
            this.progressBarControl1.TabIndex = 17;
            this.progressBarControl1.Visible = false;
            // 
            // cbJob
            // 
            this.cbJob.Location = new System.Drawing.Point(432, 24);
            this.cbJob.Name = "cbJob";
            this.cbJob.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.cbJob.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbJob.Size = new System.Drawing.Size(128, 22);
            this.cbJob.TabIndex = 16;
            this.cbJob.SelectedIndexChanged += new System.EventHandler(this.cbJob_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(344, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.toolTipController1.SetSuperTip(this.label8, null);
            this.label8.TabIndex = 15;
            this.label8.Text = "Job Position";
            // 
            // grpGridExcel
            // 
            this.grpGridExcel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.grpGridExcel.Controls.Add(this.gridExcel);
            this.grpGridExcel.Location = new System.Drawing.Point(72, 144);
            this.grpGridExcel.Name = "grpGridExcel";
            this.grpGridExcel.Size = new System.Drawing.Size(544, 176);
            this.toolTipController1.SetSuperTip(this.grpGridExcel, null);
            this.grpGridExcel.TabIndex = 13;
            this.grpGridExcel.Text = "groupControl1";
            this.grpGridExcel.Visible = false;
            // 
            // gridExcel
            // 
            this.gridExcel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridExcel.EmbeddedNavigator.Name = "";
            this.gridExcel.Location = new System.Drawing.Point(2, 30);
            this.gridExcel.MainView = this.gridViewExcel;
            this.gridExcel.Name = "gridExcel";
            this.gridExcel.Size = new System.Drawing.Size(540, 144);
            this.gridExcel.TabIndex = 12;
            this.gridExcel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewExcel});
            this.gridExcel.Visible = false;
            // 
            // gridViewExcel
            // 
            this.gridViewExcel.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn19,
            this.FirstPayDate,
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn26,
            this.gridColumn27,
            this.gridColumn28,
            this.gridColumn29,
            this.gridColumn30,
            this.gridColumn31,
            this.gridColumn32,
            this.gridColumn33,
            this.gridColumn34,
            this.gridColumn35,
            this.gridColumn36,
            this.SecondPayDate});
            this.gridViewExcel.GridControl = this.gridExcel;
            this.gridViewExcel.Name = "gridViewExcel";
            this.gridViewExcel.OptionsBehavior.Editable = false;
            this.gridViewExcel.OptionsCustomization.AllowFilter = false;
            this.gridViewExcel.OptionsView.ColumnAutoWidth = false;
            this.gridViewExcel.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Emp ID";
            this.gridColumn19.FieldName = "nEmployeeID";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 0;
            this.gridColumn19.Width = 68;
            // 
            // FirstPayDate
            // 
            this.FirstPayDate.Caption = "Payroll Date";
            this.FirstPayDate.FieldName = "dtFirstRunDate";
            this.FirstPayDate.Name = "FirstPayDate";
            this.FirstPayDate.Visible = true;
            this.FirstPayDate.VisibleIndex = 1;
            this.FirstPayDate.Width = 76;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "OT-1.5 (HRS)";
            this.gridColumn24.FieldName = "nNormalOT";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 2;
            this.gridColumn24.Width = 77;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "OT-1.0 (DAYS)";
            this.gridColumn25.FieldName = "nPublicHolidayOT";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 3;
            this.gridColumn25.Width = 83;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "OT-2.0 (DAYS)";
            this.gridColumn26.FieldName = "nOffDayOT";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 4;
            this.gridColumn26.Width = 82;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "Part-Time Salary (HRS)";
            this.gridColumn27.FieldName = "nPartTimeWorkHours";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 5;
            this.gridColumn27.Width = 85;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "AL Entitlement (HRS)";
            this.gridColumn28.FieldName = "nALEntitlementHours";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 6;
            this.gridColumn28.Width = 77;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "PH Entitlement (HRS)";
            this.gridColumn29.FieldName = "nPHEntitlementHours";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 7;
            this.gridColumn29.Width = 64;
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "Service Reimbursement (AMT)";
            this.gridColumn30.FieldName = "mServiceReimbursements";
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.Visible = true;
            this.gridColumn30.VisibleIndex = 8;
            this.gridColumn30.Width = 74;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "Lateness (HRS)";
            this.gridColumn31.FieldName = "nTotalLateness";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 9;
            this.gridColumn31.Width = 61;
            // 
            // gridColumn32
            // 
            this.gridColumn32.Caption = "Unpaid AL (DAYS)";
            this.gridColumn32.FieldName = "nUnpaidAL";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.Visible = true;
            this.gridColumn32.VisibleIndex = 10;
            this.gridColumn32.Width = 78;
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "Unpaid T/O (HRS)";
            this.gridColumn33.FieldName = "nUnpaidTO";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 11;
            this.gridColumn33.Width = 74;
            // 
            // gridColumn34
            // 
            this.gridColumn34.Caption = "Unpaid Medical Absent (DAYS)";
            this.gridColumn34.FieldName = "nUnpaidMedical";
            this.gridColumn34.Name = "gridColumn34";
            this.gridColumn34.Visible = true;
            this.gridColumn34.VisibleIndex = 12;
            this.gridColumn34.Width = 83;
            // 
            // gridColumn35
            // 
            this.gridColumn35.Caption = "Commision (AMT)";
            this.gridColumn35.FieldName = "mCommission";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.Width = 50;
            // 
            // gridColumn36
            // 
            this.gridColumn36.Caption = "Commission Lateness Penalty (AMT)";
            this.gridColumn36.FieldName = "nTotalLateness";
            this.gridColumn36.Name = "gridColumn36";
            this.gridColumn36.Width = 109;
            // 
            // SecondPayDate
            // 
            this.SecondPayDate.Caption = "Payroll Date";
            this.SecondPayDate.FieldName = "dtSecondRunDate";
            this.SecondPayDate.Name = "SecondPayDate";
            // 
            // btnPayrollExport
            // 
            this.btnPayrollExport.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnPayrollExport.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnPayrollExport.Appearance.Options.UseBackColor = true;
            this.btnPayrollExport.Appearance.Options.UseFont = true;
            this.btnPayrollExport.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnPayrollExport.Location = new System.Drawing.Point(648, 24);
            this.btnPayrollExport.Name = "btnPayrollExport";
            this.btnPayrollExport.Size = new System.Drawing.Size(56, 20);
            this.btnPayrollExport.TabIndex = 9;
            this.btnPayrollExport.Text = "Export";
            this.btnPayrollExport.Click += new System.EventHandler(this.btnPayrollExport_Click);
            // 
            // btnPayrollGenerate
            // 
            this.btnPayrollGenerate.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnPayrollGenerate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnPayrollGenerate.Appearance.Options.UseBackColor = true;
            this.btnPayrollGenerate.Appearance.Options.UseFont = true;
            this.btnPayrollGenerate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnPayrollGenerate.Location = new System.Drawing.Point(568, 24);
            this.btnPayrollGenerate.Name = "btnPayrollGenerate";
            this.btnPayrollGenerate.Size = new System.Drawing.Size(64, 20);
            this.btnPayrollGenerate.TabIndex = 8;
            this.btnPayrollGenerate.Text = "Generate";
            this.btnPayrollGenerate.Click += new System.EventHandler(this.btnPayrollGenerate_Click);
            // 
            // btnPayrollDelete
            // 
            this.btnPayrollDelete.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnPayrollDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnPayrollDelete.Appearance.Options.UseBackColor = true;
            this.btnPayrollDelete.Appearance.Options.UseFont = true;
            this.btnPayrollDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnPayrollDelete.ImeMode = System.Windows.Forms.ImeMode.On;
            this.btnPayrollDelete.Location = new System.Drawing.Point(720, 24);
            this.btnPayrollDelete.Name = "btnPayrollDelete";
            this.btnPayrollDelete.Size = new System.Drawing.Size(56, 20);
            this.btnPayrollDelete.TabIndex = 7;
            this.btnPayrollDelete.Text = "Delete";
            this.btnPayrollDelete.Click += new System.EventHandler(this.btnPayrollDelete_Click);
            // 
            // comboBoxEditMTH
            // 
            this.comboBoxEditMTH.EditValue = "1";
            this.comboBoxEditMTH.Location = new System.Drawing.Point(288, 24);
            this.comboBoxEditMTH.Name = "comboBoxEditMTH";
            this.comboBoxEditMTH.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.comboBoxEditMTH.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditMTH.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBoxEditMTH.Properties.PopupSizeable = true;
            this.comboBoxEditMTH.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditMTH.Size = new System.Drawing.Size(48, 22);
            this.comboBoxEditMTH.TabIndex = 6;
            this.comboBoxEditMTH.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditMTH_SelectedIndexChanged);
            // 
            // comboBoxEditYR
            // 
            this.comboBoxEditYR.EditValue = "2006";
            this.comboBoxEditYR.Location = new System.Drawing.Point(176, 24);
            this.comboBoxEditYR.Name = "comboBoxEditYR";
            this.comboBoxEditYR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.comboBoxEditYR.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditYR.Properties.Items.AddRange(new object[] {
            "1990",
            "1991",
            "1992",
            "1993",
            "1994",
            "1995",
            "1996",
            "1997",
            "1998",
            "1999",
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.comboBoxEditYR.Properties.PopupSizeable = true;
            this.comboBoxEditYR.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditYR.Size = new System.Drawing.Size(64, 22);
            this.comboBoxEditYR.TabIndex = 5;
            this.comboBoxEditYR.SelectedValueChanged += new System.EventHandler(this.comboBoxEditYR_SelectedValueChanged);
            // 
            // lblYear
            // 
            this.lblYear.BackColor = System.Drawing.Color.Transparent;
            this.lblYear.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.ForeColor = System.Drawing.Color.Black;
            this.lblYear.Location = new System.Drawing.Point(136, 24);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(56, 16);
            this.toolTipController1.SetSuperTip(this.lblYear, null);
            this.lblYear.TabIndex = 4;
            this.lblYear.Text = "Year";
            // 
            // lblMonth
            // 
            this.lblMonth.BackColor = System.Drawing.Color.Transparent;
            this.lblMonth.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonth.Location = new System.Drawing.Point(248, 24);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(48, 16);
            this.toolTipController1.SetSuperTip(this.lblMonth, null);
            this.lblMonth.TabIndex = 3;
            this.lblMonth.Text = "Month";
            // 
            // cmbxPayroll
            // 
            this.cmbxPayroll.EditValue = "First Run";
            this.cmbxPayroll.Location = new System.Drawing.Point(8, 24);
            this.cmbxPayroll.Name = "cmbxPayroll";
            this.cmbxPayroll.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.cmbxPayroll.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbxPayroll.Properties.Items.AddRange(new object[] {
            "First Run",
            "Second Run"});
            this.cmbxPayroll.Properties.PopupSizeable = true;
            this.cmbxPayroll.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbxPayroll.Size = new System.Drawing.Size(120, 22);
            this.cmbxPayroll.TabIndex = 2;
            this.cmbxPayroll.SelectedValueChanged += new System.EventHandler(this.cmbxPayroll_SelectedValueChanged);
            // 
            // gridPayroll
            // 
            this.gridPayroll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridPayroll.EmbeddedNavigator.Name = "";
            this.gridPayroll.Location = new System.Drawing.Point(2, 62);
            this.gridPayroll.MainView = this.gridViewPayroll;
            this.gridPayroll.Name = "gridPayroll";
            this.gridPayroll.Size = new System.Drawing.Size(990, 552);
            this.gridPayroll.TabIndex = 11;
            this.gridPayroll.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPayroll});
            // 
            // gridViewPayroll
            // 
            this.gridViewPayroll.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.nEmployeeID,
            this.gridColumn9,
            this.gridColumn17,
            this.gridColumn18,
            this.dtFirstRunDate,
            this.nNormalOT,
            this.nPublicHolidayOT,
            this.nOffDayOT,
            this.nPartTimeWorkHours,
            this.nALEntitlementHours,
            this.nPHEntitlementHours,
            this.mServiceReimbursements,
            this.nTotalLateness,
            this.nUnpaidAL,
            this.nUnpaidTO,
            this.nUnpaidMedical,
            this.mCommission,
            this.mCommissionLatenessPenalty,
            this.dtSecondRunDate});
            this.gridViewPayroll.GridControl = this.gridPayroll;
            this.gridViewPayroll.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewPayroll.Name = "gridViewPayroll";
            this.gridViewPayroll.OptionsBehavior.Editable = false;
            this.gridViewPayroll.OptionsCustomization.AllowFilter = false;
            this.gridViewPayroll.OptionsView.ColumnAutoWidth = false;
            this.gridViewPayroll.OptionsView.ShowGroupPanel = false;
            this.gridViewPayroll.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewPayroll.Click += new System.EventHandler(this.gridViewPayroll_Click);
            // 
            // nEmployeeID
            // 
            this.nEmployeeID.Caption = "Emp ID";
            this.nEmployeeID.FieldName = "nEmployeeID";
            this.nEmployeeID.Name = "nEmployeeID";
            this.nEmployeeID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.nEmployeeID.Visible = true;
            this.nEmployeeID.VisibleIndex = 0;
            this.nEmployeeID.Width = 68;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Name";
            this.gridColumn9.FieldName = "strEmployeeName";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Job Title";
            this.gridColumn17.FieldName = "strJobPosition";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 2;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Branch";
            this.gridColumn18.FieldName = "strBranchCode";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 3;
            // 
            // dtFirstRunDate
            // 
            this.dtFirstRunDate.Caption = "Payroll Date";
            this.dtFirstRunDate.FieldName = "dtFirstRunDate";
            this.dtFirstRunDate.Name = "dtFirstRunDate";
            this.dtFirstRunDate.Width = 76;
            // 
            // nNormalOT
            // 
            this.nNormalOT.Caption = "OT-1.5 (HRS)";
            this.nNormalOT.FieldName = "nNormalOT";
            this.nNormalOT.Name = "nNormalOT";
            this.nNormalOT.Visible = true;
            this.nNormalOT.VisibleIndex = 4;
            this.nNormalOT.Width = 77;
            // 
            // nPublicHolidayOT
            // 
            this.nPublicHolidayOT.Caption = "OT-1.0 (DAYS)";
            this.nPublicHolidayOT.FieldName = "nPublicHolidayOT";
            this.nPublicHolidayOT.Name = "nPublicHolidayOT";
            this.nPublicHolidayOT.Visible = true;
            this.nPublicHolidayOT.VisibleIndex = 5;
            this.nPublicHolidayOT.Width = 83;
            // 
            // nOffDayOT
            // 
            this.nOffDayOT.Caption = "OT-2.0 (DAYS)";
            this.nOffDayOT.FieldName = "nOffDayOT";
            this.nOffDayOT.Name = "nOffDayOT";
            this.nOffDayOT.Visible = true;
            this.nOffDayOT.VisibleIndex = 6;
            this.nOffDayOT.Width = 82;
            // 
            // nPartTimeWorkHours
            // 
            this.nPartTimeWorkHours.Caption = "Part-Time Salary (HRS)";
            this.nPartTimeWorkHours.FieldName = "nPartTimeWorkHours";
            this.nPartTimeWorkHours.Name = "nPartTimeWorkHours";
            this.nPartTimeWorkHours.Visible = true;
            this.nPartTimeWorkHours.VisibleIndex = 7;
            this.nPartTimeWorkHours.Width = 85;
            // 
            // nALEntitlementHours
            // 
            this.nALEntitlementHours.Caption = "AL Entitlement (HRS)";
            this.nALEntitlementHours.FieldName = "nALEntitlementHours";
            this.nALEntitlementHours.Name = "nALEntitlementHours";
            this.nALEntitlementHours.Visible = true;
            this.nALEntitlementHours.VisibleIndex = 8;
            this.nALEntitlementHours.Width = 77;
            // 
            // nPHEntitlementHours
            // 
            this.nPHEntitlementHours.Caption = "PH Entitlement (HRS)";
            this.nPHEntitlementHours.FieldName = "nPHEntitlementHours";
            this.nPHEntitlementHours.Name = "nPHEntitlementHours";
            this.nPHEntitlementHours.Visible = true;
            this.nPHEntitlementHours.VisibleIndex = 9;
            this.nPHEntitlementHours.Width = 64;
            // 
            // mServiceReimbursements
            // 
            this.mServiceReimbursements.Caption = "Service Reimbursement (AMT)";
            this.mServiceReimbursements.FieldName = "mServiceReimbursements";
            this.mServiceReimbursements.Name = "mServiceReimbursements";
            this.mServiceReimbursements.Visible = true;
            this.mServiceReimbursements.VisibleIndex = 10;
            this.mServiceReimbursements.Width = 74;
            // 
            // nTotalLateness
            // 
            this.nTotalLateness.Caption = "Lateness (HRS)";
            this.nTotalLateness.FieldName = "nTotalLateness";
            this.nTotalLateness.Name = "nTotalLateness";
            this.nTotalLateness.Visible = true;
            this.nTotalLateness.VisibleIndex = 11;
            this.nTotalLateness.Width = 61;
            // 
            // nUnpaidAL
            // 
            this.nUnpaidAL.Caption = "Unpaid AL (DAYS)";
            this.nUnpaidAL.FieldName = "nUnpaidAL";
            this.nUnpaidAL.Name = "nUnpaidAL";
            this.nUnpaidAL.Visible = true;
            this.nUnpaidAL.VisibleIndex = 12;
            this.nUnpaidAL.Width = 78;
            // 
            // nUnpaidTO
            // 
            this.nUnpaidTO.Caption = "Unpaid T/O (HRS)";
            this.nUnpaidTO.FieldName = "nUnpaidTO";
            this.nUnpaidTO.Name = "nUnpaidTO";
            this.nUnpaidTO.Visible = true;
            this.nUnpaidTO.VisibleIndex = 13;
            this.nUnpaidTO.Width = 74;
            // 
            // nUnpaidMedical
            // 
            this.nUnpaidMedical.Caption = "Unpaid Medical Absent (DAYS)";
            this.nUnpaidMedical.FieldName = "nUnpaidMedical";
            this.nUnpaidMedical.Name = "nUnpaidMedical";
            this.nUnpaidMedical.Visible = true;
            this.nUnpaidMedical.VisibleIndex = 14;
            this.nUnpaidMedical.Width = 83;
            // 
            // mCommission
            // 
            this.mCommission.Caption = "Commision (AMT)";
            this.mCommission.FieldName = "mCommission";
            this.mCommission.Name = "mCommission";
            this.mCommission.Width = 50;
            // 
            // mCommissionLatenessPenalty
            // 
            this.mCommissionLatenessPenalty.Caption = "Commission Lateness Penalty (AMT)";
            this.mCommissionLatenessPenalty.FieldName = "nTotalLateness";
            this.mCommissionLatenessPenalty.Name = "mCommissionLatenessPenalty";
            this.mCommissionLatenessPenalty.Width = 109;
            // 
            // dtSecondRunDate
            // 
            this.dtSecondRunDate.Caption = "Payroll Date";
            this.dtSecondRunDate.FieldName = "dtSecondRunDate";
            this.dtSecondRunDate.Name = "dtSecondRunDate";
            // 
            // tabManagerThree
            // 
            this.tabManagerThree.Appearance.PageClient.BackColor = System.Drawing.Color.DimGray;
            this.tabManagerThree.Appearance.PageClient.Options.UseBackColor = true;
            this.tabManagerThree.Controls.Add(this.lblThree_2);
            this.tabManagerThree.Controls.Add(this.lblThree_1);
            this.tabManagerThree.Controls.Add(this.lblThree_3);
            this.tabManagerThree.Controls.Add(this.grpClassSchedule);
            this.tabManagerThree.Controls.Add(this.groupMemCard);
            this.tabManagerThree.Controls.Add(this.grpRoadShow);
            this.tabManagerThree.Name = "tabManagerThree";
            this.tabManagerThree.PageVisible = false;
            this.tabManagerThree.Size = new System.Drawing.Size(1007, 637);
            this.tabManagerThree.Text = "Operation";
            // 
            // lblThree_2
            // 
            this.lblThree_2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblThree_2.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblThree_2.Appearance.Options.UseFont = true;
            this.lblThree_2.Appearance.Options.UseForeColor = true;
            this.lblThree_2.Location = new System.Drawing.Point(152, 0);
            this.lblThree_2.Name = "lblThree_2";
            this.lblThree_2.Size = new System.Drawing.Size(138, 23);
            this.lblThree_2.TabIndex = 144;
            this.lblThree_2.Text = "Member Card";
            this.lblThree_2.Click += new System.EventHandler(this.lblThree_2_Click);
            // 
            // lblThree_1
            // 
            this.lblThree_1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblThree_1.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblThree_1.Appearance.Options.UseFont = true;
            this.lblThree_1.Appearance.Options.UseForeColor = true;
            this.lblThree_1.Location = new System.Drawing.Point(8, 0);
            this.lblThree_1.Name = "lblThree_1";
            this.lblThree_1.Size = new System.Drawing.Size(138, 23);
            this.lblThree_1.TabIndex = 143;
            this.lblThree_1.Text = "Class Schedule";
            this.lblThree_1.Click += new System.EventHandler(this.lblThree_1_Click);
            // 
            // lblThree_3
            // 
            this.lblThree_3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblThree_3.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblThree_3.Appearance.Options.UseFont = true;
            this.lblThree_3.Appearance.Options.UseForeColor = true;
            this.lblThree_3.Location = new System.Drawing.Point(296, 0);
            this.lblThree_3.Name = "lblThree_3";
            this.lblThree_3.Size = new System.Drawing.Size(138, 23);
            this.lblThree_3.TabIndex = 145;
            this.lblThree_3.Text = "Admin Operation";
            this.lblThree_3.Click += new System.EventHandler(this.lblThree_3_Click);
            // 
            // grpClassSchedule
            // 
            this.grpClassSchedule.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.grpClassSchedule.Appearance.ForeColor = System.Drawing.Color.Black;
            this.grpClassSchedule.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.grpClassSchedule.Appearance.Options.UseBackColor = true;
            this.grpClassSchedule.Appearance.Options.UseForeColor = true;
            this.grpClassSchedule.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpClassSchedule.AppearanceCaption.Options.UseFont = true;
            this.grpClassSchedule.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.grpClassSchedule.Controls.Add(this.comboBoxBranch);
            this.grpClassSchedule.Controls.Add(this.btnRefreshClassSchedule);
            this.grpClassSchedule.Controls.Add(this.lblPQBranch);
            this.grpClassSchedule.Controls.Add(this.lblSUN);
            this.grpClassSchedule.Controls.Add(this.panelSun);
            this.grpClassSchedule.Controls.Add(this.panelSat);
            this.grpClassSchedule.Controls.Add(this.lblFRI);
            this.grpClassSchedule.Controls.Add(this.lblTHU);
            this.grpClassSchedule.Controls.Add(this.lblWED);
            this.grpClassSchedule.Controls.Add(this.lblTUE);
            this.grpClassSchedule.Controls.Add(this.panelFri);
            this.grpClassSchedule.Controls.Add(this.panelThu);
            this.grpClassSchedule.Controls.Add(this.panelWed);
            this.grpClassSchedule.Controls.Add(this.panelTue);
            this.grpClassSchedule.Controls.Add(this.panelMon);
            this.grpClassSchedule.Controls.Add(this.lblMON);
            this.grpClassSchedule.Controls.Add(this.btnPrintClassSchedule);
            this.grpClassSchedule.Controls.Add(this.btnNewClassSchedule);
            this.grpClassSchedule.Controls.Add(this.lblSAT);
            this.grpClassSchedule.Location = new System.Drawing.Point(16, 32);
            this.grpClassSchedule.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.grpClassSchedule.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpClassSchedule.Name = "grpClassSchedule";
            this.grpClassSchedule.Size = new System.Drawing.Size(996, 592);
            this.toolTipController1.SetSuperTip(this.grpClassSchedule, null);
            this.grpClassSchedule.TabIndex = 5;
            this.grpClassSchedule.Text = "Class Schedule";
            // 
            // comboBoxBranch
            // 
            this.comboBoxBranch.Location = new System.Drawing.Point(16, 40);
            this.comboBoxBranch.Name = "comboBoxBranch";
            this.comboBoxBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxBranch.Size = new System.Drawing.Size(104, 20);
            this.comboBoxBranch.TabIndex = 122;
            this.comboBoxBranch.EditValueChanged += new System.EventHandler(this.comboBoxBranch_SelectedValueChanged);
            // 
            // btnRefreshClassSchedule
            // 
            this.btnRefreshClassSchedule.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.btnRefreshClassSchedule.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshClassSchedule.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnRefreshClassSchedule.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnRefreshClassSchedule.Appearance.Options.UseBackColor = true;
            this.btnRefreshClassSchedule.Appearance.Options.UseFont = true;
            this.btnRefreshClassSchedule.Appearance.Options.UseForeColor = true;
            this.btnRefreshClassSchedule.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnRefreshClassSchedule.Location = new System.Drawing.Point(16, 112);
            this.btnRefreshClassSchedule.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRefreshClassSchedule.Name = "btnRefreshClassSchedule";
            this.btnRefreshClassSchedule.Size = new System.Drawing.Size(104, 20);
            this.btnRefreshClassSchedule.TabIndex = 121;
            this.btnRefreshClassSchedule.Text = "Refresh";
            this.btnRefreshClassSchedule.Click += new System.EventHandler(this.btnRefreshClassSchedule_Click);
            // 
            // lblPQBranch
            // 
            this.lblPQBranch.BackColor = System.Drawing.Color.Transparent;
            this.lblPQBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPQBranch.Location = new System.Drawing.Point(16, 24);
            this.lblPQBranch.Name = "lblPQBranch";
            this.lblPQBranch.Size = new System.Drawing.Size(100, 16);
            this.toolTipController1.SetSuperTip(this.lblPQBranch, null);
            this.lblPQBranch.TabIndex = 33;
            this.lblPQBranch.Text = "Filter by Branch";
            // 
            // lblSUN
            // 
            this.lblSUN.BackColor = System.Drawing.Color.PowderBlue;
            this.lblSUN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSUN.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSUN.Location = new System.Drawing.Point(760, 24);
            this.lblSUN.Name = "lblSUN";
            this.lblSUN.Size = new System.Drawing.Size(104, 16);
            this.toolTipController1.SetSuperTip(this.lblSUN, null);
            this.lblSUN.TabIndex = 30;
            this.lblSUN.Text = "SUN";
            // 
            // panelSun
            // 
            this.panelSun.BackColor = System.Drawing.Color.White;
            this.panelSun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSun.Location = new System.Drawing.Point(760, 40);
            this.panelSun.Name = "panelSun";
            this.panelSun.Size = new System.Drawing.Size(104, 512);
            this.toolTipController1.SetSuperTip(this.panelSun, null);
            this.panelSun.TabIndex = 28;
            // 
            // panelSat
            // 
            this.panelSat.BackColor = System.Drawing.Color.White;
            this.panelSat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSat.Location = new System.Drawing.Point(656, 40);
            this.panelSat.Name = "panelSat";
            this.panelSat.Size = new System.Drawing.Size(104, 512);
            this.toolTipController1.SetSuperTip(this.panelSat, null);
            this.panelSat.TabIndex = 27;
            // 
            // lblFRI
            // 
            this.lblFRI.BackColor = System.Drawing.Color.PowderBlue;
            this.lblFRI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFRI.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFRI.Location = new System.Drawing.Point(552, 24);
            this.lblFRI.Name = "lblFRI";
            this.lblFRI.Size = new System.Drawing.Size(104, 16);
            this.toolTipController1.SetSuperTip(this.lblFRI, null);
            this.lblFRI.TabIndex = 26;
            this.lblFRI.Text = "FRI";
            // 
            // lblTHU
            // 
            this.lblTHU.BackColor = System.Drawing.Color.PowderBlue;
            this.lblTHU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTHU.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTHU.Location = new System.Drawing.Point(448, 24);
            this.lblTHU.Name = "lblTHU";
            this.lblTHU.Size = new System.Drawing.Size(104, 16);
            this.toolTipController1.SetSuperTip(this.lblTHU, null);
            this.lblTHU.TabIndex = 25;
            this.lblTHU.Text = "THU";
            // 
            // lblWED
            // 
            this.lblWED.BackColor = System.Drawing.Color.PowderBlue;
            this.lblWED.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWED.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWED.Location = new System.Drawing.Point(344, 24);
            this.lblWED.Name = "lblWED";
            this.lblWED.Size = new System.Drawing.Size(104, 16);
            this.toolTipController1.SetSuperTip(this.lblWED, null);
            this.lblWED.TabIndex = 24;
            this.lblWED.Text = "WED";
            // 
            // lblTUE
            // 
            this.lblTUE.BackColor = System.Drawing.Color.PowderBlue;
            this.lblTUE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTUE.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTUE.Location = new System.Drawing.Point(240, 24);
            this.lblTUE.Name = "lblTUE";
            this.lblTUE.Size = new System.Drawing.Size(104, 16);
            this.toolTipController1.SetSuperTip(this.lblTUE, null);
            this.lblTUE.TabIndex = 23;
            this.lblTUE.Text = "TUE";
            // 
            // panelFri
            // 
            this.panelFri.BackColor = System.Drawing.Color.White;
            this.panelFri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFri.Location = new System.Drawing.Point(552, 40);
            this.panelFri.Name = "panelFri";
            this.panelFri.Size = new System.Drawing.Size(104, 512);
            this.toolTipController1.SetSuperTip(this.panelFri, null);
            this.panelFri.TabIndex = 18;
            // 
            // panelThu
            // 
            this.panelThu.BackColor = System.Drawing.Color.White;
            this.panelThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelThu.Location = new System.Drawing.Point(448, 40);
            this.panelThu.Name = "panelThu";
            this.panelThu.Size = new System.Drawing.Size(104, 512);
            this.toolTipController1.SetSuperTip(this.panelThu, null);
            this.panelThu.TabIndex = 17;
            // 
            // panelWed
            // 
            this.panelWed.BackColor = System.Drawing.Color.White;
            this.panelWed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWed.Location = new System.Drawing.Point(344, 40);
            this.panelWed.Name = "panelWed";
            this.panelWed.Size = new System.Drawing.Size(104, 512);
            this.toolTipController1.SetSuperTip(this.panelWed, null);
            this.panelWed.TabIndex = 16;
            // 
            // panelTue
            // 
            this.panelTue.BackColor = System.Drawing.Color.White;
            this.panelTue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTue.Location = new System.Drawing.Point(240, 40);
            this.panelTue.Name = "panelTue";
            this.panelTue.Size = new System.Drawing.Size(104, 512);
            this.toolTipController1.SetSuperTip(this.panelTue, null);
            this.panelTue.TabIndex = 15;
            // 
            // panelMon
            // 
            this.panelMon.BackColor = System.Drawing.Color.White;
            this.panelMon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMon.Location = new System.Drawing.Point(136, 40);
            this.panelMon.Name = "panelMon";
            this.panelMon.Size = new System.Drawing.Size(104, 512);
            this.toolTipController1.SetSuperTip(this.panelMon, null);
            this.panelMon.TabIndex = 14;
            // 
            // lblMON
            // 
            this.lblMON.BackColor = System.Drawing.Color.PowderBlue;
            this.lblMON.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMON.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMON.Location = new System.Drawing.Point(136, 24);
            this.lblMON.Name = "lblMON";
            this.lblMON.Size = new System.Drawing.Size(104, 16);
            this.toolTipController1.SetSuperTip(this.lblMON, null);
            this.lblMON.TabIndex = 12;
            this.lblMON.Text = "MON";
            // 
            // btnPrintClassSchedule
            // 
            this.btnPrintClassSchedule.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.btnPrintClassSchedule.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintClassSchedule.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnPrintClassSchedule.Appearance.Options.UseBackColor = true;
            this.btnPrintClassSchedule.Appearance.Options.UseFont = true;
            this.btnPrintClassSchedule.Appearance.Options.UseForeColor = true;
            this.btnPrintClassSchedule.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnPrintClassSchedule.Location = new System.Drawing.Point(16, 88);
            this.btnPrintClassSchedule.Name = "btnPrintClassSchedule";
            this.btnPrintClassSchedule.Size = new System.Drawing.Size(104, 20);
            this.btnPrintClassSchedule.TabIndex = 11;
            this.btnPrintClassSchedule.Text = "Print";
            this.btnPrintClassSchedule.Click += new System.EventHandler(this.btnPrintClassSchedule_Click);
            // 
            // btnNewClassSchedule
            // 
            this.btnNewClassSchedule.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.btnNewClassSchedule.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewClassSchedule.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnNewClassSchedule.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnNewClassSchedule.Appearance.Options.UseBackColor = true;
            this.btnNewClassSchedule.Appearance.Options.UseFont = true;
            this.btnNewClassSchedule.Appearance.Options.UseForeColor = true;
            this.btnNewClassSchedule.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnNewClassSchedule.Location = new System.Drawing.Point(16, 64);
            this.btnNewClassSchedule.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnNewClassSchedule.Name = "btnNewClassSchedule";
            this.btnNewClassSchedule.Size = new System.Drawing.Size(104, 20);
            this.btnNewClassSchedule.TabIndex = 8;
            this.btnNewClassSchedule.Text = "New";
            this.btnNewClassSchedule.Click += new System.EventHandler(this.btnNewClassSchedule_Click);
            // 
            // lblSAT
            // 
            this.lblSAT.BackColor = System.Drawing.Color.PowderBlue;
            this.lblSAT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSAT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSAT.Location = new System.Drawing.Point(656, 24);
            this.lblSAT.Name = "lblSAT";
            this.lblSAT.Size = new System.Drawing.Size(104, 16);
            this.toolTipController1.SetSuperTip(this.lblSAT, null);
            this.lblSAT.TabIndex = 29;
            this.lblSAT.Text = "SAT";
            // 
            // groupMemCard
            // 
            this.groupMemCard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupMemCard.Location = new System.Drawing.Point(16, 32);
            this.groupMemCard.Name = "groupMemCard";
            this.groupMemCard.Size = new System.Drawing.Size(1000, 592);
            this.toolTipController1.SetSuperTip(this.groupMemCard, null);
            this.groupMemCard.TabIndex = 127;
            // 
            // grpRoadShow
            // 
            this.grpRoadShow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.grpRoadShow.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grpRoadShow.Location = new System.Drawing.Point(16, 32);
            this.grpRoadShow.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpRoadShow.Name = "grpRoadShow";
            this.grpRoadShow.Size = new System.Drawing.Size(984, 592);
            this.toolTipController1.SetSuperTip(this.grpRoadShow, null);
            this.grpRoadShow.TabIndex = 129;
            // 
            // tabManagerFour
            // 
            this.tabManagerFour.Controls.Add(this.lblFour_2);
            this.tabManagerFour.Controls.Add(this.lblFour_1);
            this.tabManagerFour.Controls.Add(this.lblFour_3);
            this.tabManagerFour.Controls.Add(this.lblFour_4);
            this.tabManagerFour.Controls.Add(this.lblFour_5);
            this.tabManagerFour.Controls.Add(this.panel2);
            this.tabManagerFour.Name = "tabManagerFour";
            this.tabManagerFour.PageVisible = false;
            this.tabManagerFour.Size = new System.Drawing.Size(1007, 637);
            this.tabManagerFour.Text = "Human Resource";
            // 
            // lblFour_2
            // 
            this.lblFour_2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFour_2.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblFour_2.Appearance.Options.UseFont = true;
            this.lblFour_2.Appearance.Options.UseForeColor = true;
            this.lblFour_2.Location = new System.Drawing.Point(152, 0);
            this.lblFour_2.Name = "lblFour_2";
            this.lblFour_2.Size = new System.Drawing.Size(138, 23);
            this.lblFour_2.TabIndex = 144;
            this.lblFour_2.Text = "TimeSheet";
            this.lblFour_2.Click += new System.EventHandler(this.lblFour_2_Click);
            // 
            // lblFour_1
            // 
            this.lblFour_1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFour_1.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblFour_1.Appearance.Options.UseFont = true;
            this.lblFour_1.Appearance.Options.UseForeColor = true;
            this.lblFour_1.Location = new System.Drawing.Point(8, 0);
            this.lblFour_1.Name = "lblFour_1";
            this.lblFour_1.Size = new System.Drawing.Size(138, 23);
            this.lblFour_1.TabIndex = 143;
            this.lblFour_1.Text = "Roster";
            this.lblFour_1.Click += new System.EventHandler(this.lblFour_1_Click);
            // 
            // lblFour_3
            // 
            this.lblFour_3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFour_3.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblFour_3.Appearance.Options.UseFont = true;
            this.lblFour_3.Appearance.Options.UseForeColor = true;
            this.lblFour_3.Location = new System.Drawing.Point(296, 0);
            this.lblFour_3.Name = "lblFour_3";
            this.lblFour_3.Size = new System.Drawing.Size(138, 23);
            this.lblFour_3.TabIndex = 145;
            this.lblFour_3.Text = "OverTime";
            this.lblFour_3.Click += new System.EventHandler(this.lblFour_3_Click);
            // 
            // lblFour_4
            // 
            this.lblFour_4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFour_4.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblFour_4.Appearance.Options.UseFont = true;
            this.lblFour_4.Appearance.Options.UseForeColor = true;
            this.lblFour_4.Location = new System.Drawing.Point(440, 0);
            this.lblFour_4.Name = "lblFour_4";
            this.lblFour_4.Size = new System.Drawing.Size(138, 23);
            this.lblFour_4.TabIndex = 146;
            this.lblFour_4.Text = "Leave";
            this.lblFour_4.Click += new System.EventHandler(this.lblFour_4_Click);
            // 
            // lblFour_5
            // 
            this.lblFour_5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFour_5.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblFour_5.Appearance.Options.UseFont = true;
            this.lblFour_5.Appearance.Options.UseForeColor = true;
            this.lblFour_5.Location = new System.Drawing.Point(584, 0);
            this.lblFour_5.Name = "lblFour_5";
            this.lblFour_5.Size = new System.Drawing.Size(138, 23);
            this.lblFour_5.TabIndex = 147;
            this.lblFour_5.Text = "Appointment";
            this.lblFour_5.Click += new System.EventHandler(this.lblFour_5_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 600);
            this.toolTipController1.SetSuperTip(this.panel2, null);
            this.panel2.TabIndex = 125;
            // 
            // tabManagerFive
            // 
            this.tabManagerFive.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabManagerFive.BackgroundImage")));
            this.tabManagerFive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabManagerFive.Controls.Add(this.label6);
            this.tabManagerFive.Controls.Add(this.ReportPanel);
            this.tabManagerFive.Controls.Add(this.lk_ReportView);
            this.tabManagerFive.Controls.Add(this.lblFive_9);
            this.tabManagerFive.Controls.Add(this.lblFive_10);
            this.tabManagerFive.Controls.Add(this.lblFive_4);
            this.tabManagerFive.Controls.Add(this.lblFive_2);
            this.tabManagerFive.Controls.Add(this.lblFive_8);
            this.tabManagerFive.Controls.Add(this.lblFive_7);
            this.tabManagerFive.Controls.Add(this.lblFive_3);
            this.tabManagerFive.Controls.Add(this.lblFive_6);
            this.tabManagerFive.Controls.Add(this.lblFive_1);
            this.tabManagerFive.Controls.Add(this.lblFive_5);
            this.tabManagerFive.Name = "tabManagerFive";
            this.tabManagerFive.PageVisible = false;
            this.tabManagerFive.Size = new System.Drawing.Size(1007, 637);
            this.tabManagerFive.Text = "Report";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Monotype Corsiva", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label6.Location = new System.Drawing.Point(16, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 16);
            this.toolTipController1.SetSuperTip(this.label6, null);
            this.label6.TabIndex = 57;
            this.label6.Text = "Option >>";
            // 
            // ReportPanel
            // 
            this.ReportPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.ReportPanel.Location = new System.Drawing.Point(8, 56);
            this.ReportPanel.Name = "ReportPanel";
            this.ReportPanel.Size = new System.Drawing.Size(984, 560);
            this.toolTipController1.SetSuperTip(this.ReportPanel, null);
            this.ReportPanel.TabIndex = 28;
            // 
            // lk_ReportView
            // 
            this.lk_ReportView.Location = new System.Drawing.Point(88, 32);
            this.lk_ReportView.Name = "lk_ReportView";
            this.lk_ReportView.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lk_ReportView.Properties.Appearance.Options.UseFont = true;
            this.lk_ReportView.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.lk_ReportView.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_ReportView.Properties.NullText = "";
            this.lk_ReportView.Size = new System.Drawing.Size(272, 22);
            this.lk_ReportView.TabIndex = 53;
            this.lk_ReportView.EditValueChanged += new System.EventHandler(this.lk_ReportView_EditValueChanged);
            this.lk_ReportView.DoubleClick += new System.EventHandler(this.lk_ReportView_EditValueChanged);
            // 
            // lblFive_9
            // 
            this.lblFive_9.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFive_9.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblFive_9.Appearance.Options.UseFont = true;
            this.lblFive_9.Appearance.Options.UseForeColor = true;
            this.lblFive_9.Location = new System.Drawing.Point(712, 0);
            this.lblFive_9.Name = "lblFive_9";
            this.lblFive_9.Size = new System.Drawing.Size(80, 23);
            this.lblFive_9.TabIndex = 152;
            this.lblFive_9.Text = "Leave";
            this.lblFive_9.Click += new System.EventHandler(this.lblFive_9_Click);
            // 
            // lblFive_10
            // 
            this.lblFive_10.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFive_10.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblFive_10.Appearance.Options.UseFont = true;
            this.lblFive_10.Appearance.Options.UseForeColor = true;
            this.lblFive_10.Location = new System.Drawing.Point(800, 0);
            this.lblFive_10.Name = "lblFive_10";
            this.lblFive_10.Size = new System.Drawing.Size(80, 23);
            this.lblFive_10.TabIndex = 153;
            this.lblFive_10.Text = "Member";
            this.lblFive_10.Click += new System.EventHandler(this.lblFive_10_Click);
            // 
            // lblFive_4
            // 
            this.lblFive_4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFive_4.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblFive_4.Appearance.Options.UseFont = true;
            this.lblFive_4.Appearance.Options.UseForeColor = true;
            this.lblFive_4.Location = new System.Drawing.Point(272, 0);
            this.lblFive_4.Name = "lblFive_4";
            this.lblFive_4.Size = new System.Drawing.Size(80, 23);
            this.lblFive_4.TabIndex = 147;
            this.lblFive_4.Text = "Promotion";
            this.lblFive_4.Click += new System.EventHandler(this.lblFive_4_Click);
            // 
            // lblFive_2
            // 
            this.lblFive_2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFive_2.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblFive_2.Appearance.Options.UseFont = true;
            this.lblFive_2.Appearance.Options.UseForeColor = true;
            this.lblFive_2.Location = new System.Drawing.Point(96, 0);
            this.lblFive_2.Name = "lblFive_2";
            this.lblFive_2.Size = new System.Drawing.Size(80, 23);
            this.lblFive_2.TabIndex = 145;
            this.lblFive_2.Text = "Attendance";
            this.lblFive_2.Click += new System.EventHandler(this.lblFive_2_Click);
            // 
            // lblFive_8
            // 
            this.lblFive_8.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFive_8.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblFive_8.Appearance.Options.UseFont = true;
            this.lblFive_8.Appearance.Options.UseForeColor = true;
            this.lblFive_8.Location = new System.Drawing.Point(624, 0);
            this.lblFive_8.Name = "lblFive_8";
            this.lblFive_8.Size = new System.Drawing.Size(80, 23);
            this.lblFive_8.TabIndex = 151;
            this.lblFive_8.Text = "Stock";
            this.lblFive_8.Click += new System.EventHandler(this.lblFive_8_Click);
            // 
            // lblFive_7
            // 
            this.lblFive_7.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFive_7.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblFive_7.Appearance.Options.UseFont = true;
            this.lblFive_7.Appearance.Options.UseForeColor = true;
            this.lblFive_7.Location = new System.Drawing.Point(536, 0);
            this.lblFive_7.Name = "lblFive_7";
            this.lblFive_7.Size = new System.Drawing.Size(80, 23);
            this.lblFive_7.TabIndex = 150;
            this.lblFive_7.Text = "Voice";
            this.lblFive_7.Click += new System.EventHandler(this.lblFive_7_Click);
            // 
            // lblFive_3
            // 
            this.lblFive_3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFive_3.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblFive_3.Appearance.Options.UseFont = true;
            this.lblFive_3.Appearance.Options.UseForeColor = true;
            this.lblFive_3.Location = new System.Drawing.Point(184, 0);
            this.lblFive_3.Name = "lblFive_3";
            this.lblFive_3.Size = new System.Drawing.Size(80, 23);
            this.lblFive_3.TabIndex = 146;
            this.lblFive_3.Text = "Operation";
            this.lblFive_3.Click += new System.EventHandler(this.lblFive_3_Click);
            // 
            // lblFive_6
            // 
            this.lblFive_6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFive_6.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblFive_6.Appearance.Options.UseFont = true;
            this.lblFive_6.Appearance.Options.UseForeColor = true;
            this.lblFive_6.Location = new System.Drawing.Point(448, 0);
            this.lblFive_6.Name = "lblFive_6";
            this.lblFive_6.Size = new System.Drawing.Size(80, 23);
            this.lblFive_6.TabIndex = 149;
            this.lblFive_6.Text = "Staff";
            this.lblFive_6.Click += new System.EventHandler(this.lblFive_6_Click);
            // 
            // lblFive_1
            // 
            this.lblFive_1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFive_1.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblFive_1.Appearance.Options.UseFont = true;
            this.lblFive_1.Appearance.Options.UseForeColor = true;
            this.lblFive_1.Location = new System.Drawing.Point(8, 0);
            this.lblFive_1.Name = "lblFive_1";
            this.lblFive_1.Size = new System.Drawing.Size(80, 23);
            this.lblFive_1.TabIndex = 144;
            this.lblFive_1.Text = "Sales";
            this.lblFive_1.Click += new System.EventHandler(this.lblFive_1_Click);
            // 
            // lblFive_5
            // 
            this.lblFive_5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFive_5.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblFive_5.Appearance.Options.UseFont = true;
            this.lblFive_5.Appearance.Options.UseForeColor = true;
            this.lblFive_5.Location = new System.Drawing.Point(360, 0);
            this.lblFive_5.Name = "lblFive_5";
            this.lblFive_5.Size = new System.Drawing.Size(80, 23);
            this.lblFive_5.TabIndex = 148;
            this.lblFive_5.Text = "Account";
            this.lblFive_5.Click += new System.EventHandler(this.lblFive_5_Click);
            // 
            // tabManagerSix
            // 
            this.tabManagerSix.Appearance.PageClient.BackColor = System.Drawing.Color.Gray;
            this.tabManagerSix.Appearance.PageClient.Options.UseBackColor = true;
            this.tabManagerSix.Controls.Add(this.lk_MasterData);
            this.tabManagerSix.Controls.Add(this.panel1);
            this.tabManagerSix.Controls.Add(this.label1);
            this.tabManagerSix.Name = "tabManagerSix";
            this.tabManagerSix.PageVisible = false;
            this.tabManagerSix.Size = new System.Drawing.Size(1007, 637);
            this.tabManagerSix.Text = "Master Data";
            // 
            // lk_MasterData
            // 
            this.lk_MasterData.Location = new System.Drawing.Point(88, 7);
            this.lk_MasterData.Name = "lk_MasterData";
            this.lk_MasterData.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lk_MasterData.Properties.Appearance.Options.UseFont = true;
            this.lk_MasterData.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.lk_MasterData.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_MasterData.Size = new System.Drawing.Size(160, 22);
            this.lk_MasterData.TabIndex = 52;
            this.lk_MasterData.EditValueChanged += new System.EventHandler(this.lk_MasterData_EditValueChanged);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(3, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 592);
            this.toolTipController1.SetSuperTip(this.panel1, null);
            this.panel1.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(19, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.toolTipController1.SetSuperTip(this.label1, null);
            this.label1.TabIndex = 40;
            this.label1.Text = "Option >>";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.Controller = this.barAndDockingController1;
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiManagerLoginOut,
            this.bbiManagerTimeCard,
            this.barButtonItem1,
            this.barstaticCurrentLogin});
            this.barManager1.MainMenu = this.bar1;
            this.barManager1.MaxItemId = 5;
            // 
            // bar1
            // 
            this.bar1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.bar1.Appearance.Options.UseBackColor = true;
            this.bar1.BarName = "Custom 1";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiManagerLoginOut, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barstaticCurrentLogin, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Caption)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Custom 1";
            // 
            // bbiManagerLoginOut
            // 
            this.bbiManagerLoginOut.Caption = "Close";
            this.bbiManagerLoginOut.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiManagerLoginOut.Glyph")));
            this.bbiManagerLoginOut.Id = 0;
            this.bbiManagerLoginOut.Name = "bbiManagerLoginOut";
            this.bbiManagerLoginOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiManagerLoginOut_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Time Card";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnTimeCard_ItemClick);
            // 
            // barstaticCurrentLogin
            // 
            this.barstaticCurrentLogin.Caption = "Current Login: {0}, {1}";
            this.barstaticCurrentLogin.Id = 4;
            this.barstaticCurrentLogin.Name = "barstaticCurrentLogin";
            this.barstaticCurrentLogin.OwnFont = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.barstaticCurrentLogin.UseOwnFont = true;
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.AppearancesBar.ItemsFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barAndDockingController1.PaintStyleName = "WindowsXP";
            // 
            // barDockControlTop
            // 
            this.toolTipController1.SetSuperTip(this.barDockControlTop, null);
            // 
            // barDockControlBottom
            // 
            this.toolTipController1.SetSuperTip(this.barDockControlBottom, null);
            // 
            // barDockControlLeft
            // 
            this.toolTipController1.SetSuperTip(this.barDockControlLeft, null);
            // 
            // barDockControlRight
            // 
            this.toolTipController1.SetSuperTip(this.barDockControlRight, null);
            // 
            // bbiManagerTimeCard
            // 
            this.bbiManagerTimeCard.Caption = "Time Card";
            this.bbiManagerTimeCard.Id = 2;
            this.bbiManagerTimeCard.Name = "bbiManagerTimeCard";
            this.bbiManagerTimeCard.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiManagerTimeCard_ItemClick);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // gridColumnPGE3
            // 
            this.gridColumnPGE3.Caption = "Quantity";
            this.gridColumnPGE3.FieldName = "nQuantity";
            this.gridColumnPGE3.Name = "gridColumnPGE3";
            this.gridColumnPGE3.Visible = true;
            this.gridColumnPGE3.VisibleIndex = 2;
            // 
            // gridColumnPGE2
            // 
            this.gridColumnPGE2.Caption = "Package Code";
            this.gridColumnPGE2.FieldName = "strPackageCode";
            this.gridColumnPGE2.Name = "gridColumnPGE2";
            this.gridColumnPGE2.Visible = true;
            this.gridColumnPGE2.VisibleIndex = 1;
            // 
            // gridColumnPGE1
            // 
            this.gridColumnPGE1.Caption = "Package Group Code";
            this.gridColumnPGE1.FieldName = "strPackageGroupCode";
            this.gridColumnPGE1.Name = "gridColumnPGE1";
            this.gridColumnPGE1.Visible = true;
            this.gridColumnPGE1.VisibleIndex = 0;
            // 
            // mdPGE_txtNQuantity
            // 
            this.mdPGE_txtNQuantity.EditValue = "";
            this.mdPGE_txtNQuantity.Location = new System.Drawing.Point(32, 152);
            this.mdPGE_txtNQuantity.Name = "mdPGE_txtNQuantity";
            this.mdPGE_txtNQuantity.Properties.Mask.EditMask = "######0";
            this.mdPGE_txtNQuantity.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.mdPGE_txtNQuantity.Size = new System.Drawing.Size(144, 20);
            this.mdPGE_txtNQuantity.TabIndex = 122;
            // 
            // mdPGE_txtStrPackageCode
            // 
            this.mdPGE_txtStrPackageCode.EditValue = "imageComboBoxEdit2";
            this.mdPGE_txtStrPackageCode.Location = new System.Drawing.Point(32, 96);
            this.mdPGE_txtStrPackageCode.Name = "mdPGE_txtStrPackageCode";
            this.mdPGE_txtStrPackageCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mdPGE_txtStrPackageCode.Size = new System.Drawing.Size(144, 20);
            this.mdPGE_txtStrPackageCode.TabIndex = 121;
            // 
            // mdPGE_cdStrPackageGroupCode
            // 
            this.mdPGE_cdStrPackageGroupCode.EditValue = "imageComboBoxEdit1";
            this.mdPGE_cdStrPackageGroupCode.Location = new System.Drawing.Point(32, 48);
            this.mdPGE_cdStrPackageGroupCode.Name = "mdPGE_cdStrPackageGroupCode";
            this.mdPGE_cdStrPackageGroupCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mdPGE_cdStrPackageGroupCode.Size = new System.Drawing.Size(144, 20);
            this.mdPGE_cdStrPackageGroupCode.TabIndex = 120;
            // 
            // mdPGE_lblNQuantity
            // 
            this.mdPGE_lblNQuantity.BackColor = System.Drawing.Color.Transparent;
            this.mdPGE_lblNQuantity.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mdPGE_lblNQuantity.ForeColor = System.Drawing.Color.Black;
            this.mdPGE_lblNQuantity.Location = new System.Drawing.Point(32, 136);
            this.mdPGE_lblNQuantity.Name = "mdPGE_lblNQuantity";
            this.mdPGE_lblNQuantity.Size = new System.Drawing.Size(120, 16);
            this.toolTipController1.SetSuperTip(this.mdPGE_lblNQuantity, null);
            this.mdPGE_lblNQuantity.TabIndex = 119;
            this.mdPGE_lblNQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mdPGE_lblStrPackageCode
            // 
            this.mdPGE_lblStrPackageCode.BackColor = System.Drawing.Color.Transparent;
            this.mdPGE_lblStrPackageCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mdPGE_lblStrPackageCode.ForeColor = System.Drawing.Color.Black;
            this.mdPGE_lblStrPackageCode.Location = new System.Drawing.Point(32, 80);
            this.mdPGE_lblStrPackageCode.Name = "mdPGE_lblStrPackageCode";
            this.mdPGE_lblStrPackageCode.Size = new System.Drawing.Size(120, 16);
            this.toolTipController1.SetSuperTip(this.mdPGE_lblStrPackageCode, null);
            this.mdPGE_lblStrPackageCode.TabIndex = 118;
            this.mdPGE_lblStrPackageCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mdPGE_lblStrPackageGroupCode
            // 
            this.mdPGE_lblStrPackageGroupCode.BackColor = System.Drawing.Color.Transparent;
            this.mdPGE_lblStrPackageGroupCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mdPGE_lblStrPackageGroupCode.ForeColor = System.Drawing.Color.Black;
            this.mdPGE_lblStrPackageGroupCode.Location = new System.Drawing.Point(32, 32);
            this.mdPGE_lblStrPackageGroupCode.Name = "mdPGE_lblStrPackageGroupCode";
            this.mdPGE_lblStrPackageGroupCode.Size = new System.Drawing.Size(120, 16);
            this.toolTipController1.SetSuperTip(this.mdPGE_lblStrPackageGroupCode, null);
            this.mdPGE_lblStrPackageGroupCode.TabIndex = 117;
            this.mdPGE_lblStrPackageGroupCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(888, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 24);
            this.toolTipController1.SetSuperTip(this.label5, null);
            this.label5.TabIndex = 25;
            this.label5.Text = "HeadStart";
            // 
            // frmManager
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1012, 691);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tabControlManager);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.MainMenu1;
            this.Name = "frmManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.toolTipController1.SetSuperTip(this, null);
            this.Text = "ACMS Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabControlManager)).EndInit();
            this.tabControlManager.ResumeLayout(false);
            this.tabManagerOne.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupIPPMaster)).EndInit();
            this.groupIPPMaster.ResumeLayout(false);
            this.groupIPPMaster.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupIPP)).EndInit();
            this.groupIPP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxIPP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpIPP2)).EndInit();
            this.grpIPP2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkBank.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPdtTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPdtTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPdtStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPdtStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditCardScr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupIPPDetails)).EndInit();
            this.GroupIPPDetails.ResumeLayout(false);
            this.GroupIPPDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.strReferenceNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPBankCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPNMonths.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPCCNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPDateRcv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPDateSent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPBranchCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPCreatedDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPMerchantNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPInterest.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPNettAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPMemberId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPMemberName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupIPPReceipt)).EndInit();
            this.groupIPPReceipt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridReceipt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPReceiptView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPPReceiptStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupGIROMaster)).EndInit();
            this.groupGIROMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabGiroDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.luedtBankBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luedtBank.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luedtPackage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luedtBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPackageDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGIROId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            this.tabGiroTrnsHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupGiro)).EndInit();
            this.GroupGiro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxGiroStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GiroGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GIROGridView)).EndInit();
            this.tabManagerTwo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrpPayroll)).EndInit();
            this.GrpPayroll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbJob.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpGridExcel)).EndInit();
            this.grpGridExcel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditMTH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditYR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbxPayroll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPayroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPayroll)).EndInit();
            this.tabManagerThree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpClassSchedule)).EndInit();
            this.grpClassSchedule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupMemCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpRoadShow)).EndInit();
            this.tabManagerFour.ResumeLayout(false);
            this.tabManagerFive.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ReportPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_ReportView.Properties)).EndInit();
            this.tabManagerSix.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lk_MasterData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdPGE_txtNQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdPGE_txtStrPackageCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdPGE_cdStrPackageGroupCode.Properties)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		#region Form_Load & TabPageChanged

		private void frmManager_Load(object sender, System.EventArgs e)
		{
			barstaticCurrentLogin.Caption = string.Format(barstaticCurrentLogin.Caption, employee.StrEmployeeName, DateTime.Now.ToString("dd MMMM yyyy"));

			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);

			TabManager_init();
		
			FontStyle FontStyle001;			
			FontStyle001 = FontStyle.Bold;
			FontStyle001  = (System.Drawing.FontStyle) System.Convert.ToInt32(FontStyle001)+System.Convert.ToInt32(FontStyle.Underline);
			Font001 = new Font("Microsoft Sans Serif", 10, FontStyle001);
			Font002 = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
			Font003 = new Font("Microsoft Sans Serif", (float)8.25, FontStyle001);
			Font004 = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Bold);

			myCommon = new ACMS.Utils.Common();

			frmRoster = new ACMS.ACMSManager.Human_Resource.frmRosterMain();
			frmTimeSheet = new ACMS.ACMSManager.Human_Resource.frmTimeSheetMain();
			frmOvertime = new ACMS.ACMSManager.Human_Resource.frmOvertimeMain();
			frmHRLeave = new  ACMS.ACMSManager.Human_Resource.frmLeave();
			frmHRAppointment = new  ACMS.ACMSManager.Human_Resource.frmAppointment();

			//IPP 
			InitIPP();
			LoadIPP();
			
			//Payroll
			Init_Payroll_cmbJob();

			//Master Data
			mdInit();
			Init_Master_lookUp();
		}

		private void UserRightTable_Load() 	
		{
			DataSet tabManagerRights = new DataSet();
			string strSQL = "Select nRightsID from tblRightsLevelEntries where nRightsLevelID = "+ oUser.NRightsLevelID();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",tabManagerRights,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			dtUserRights = tabManagerRights.Tables["Table"];
		}

		private bool AccessTab(int Rightno)
		{
			DataRow[] AccessRows = dtUserRights.Select("nRightsID="+Rightno);
			if (AccessRows.Length==1) 
				return true;
			else 
				return false;
		}

		private void TabManager_init()
		{
			UserRightTable_Load();

			DataSet tabManagerTable = new DataSet(); 

			string strSQL = "select * from tblTabControl where nTabGroup=3 and fShow=0 order by nTabID";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",tabManagerTable,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dtMaster = tabManagerTable.Tables["Table"];

			foreach (DataRow row in dtMaster.Rows)
			{
				switch(row["nTabId"].ToString())
				{
					case "1":	this.tabManagerOne.Text= row["strTabName"].ToString();
						if (AccessTab(260)==true)this.tabManagerOne.PageVisible=true;
						break;
					case "2":	this.tabManagerTwo.Text= row["strTabName"].ToString();
						if (AccessTab(261)==true)this.tabManagerTwo.PageVisible=true;
						break;
					case "3":	this.tabManagerThree.Text= row["strTabName"].ToString();
						if (AccessTab(262)==true)this.tabManagerThree.PageVisible=true;
						break;
					case "4":	this.tabManagerFour.Text= row["strTabName"].ToString();
						if (AccessTab(263)==true)this.tabManagerFour.PageVisible=true;
						break;
					case "5":	this.tabManagerFive.Text= row["strTabName"].ToString();
						if (AccessTab(264)==true)this.tabManagerFive.PageVisible=true;
						break;
					case "6": this.tabManagerSix.Text= row["strTabName"].ToString();
						if (AccessTab(265)==true)this.tabManagerSix.PageVisible=true;
						break;
				}
			}
			
		}
		
		#endregion

		#region Member
		public string Category
		{
			get
			{
				return _category;
			}
			set
			{
				_category = value;
			}
		}

		public int Selection
		{
			get
			{
				return _select;
			}
			set
			{
				_select = value;
			}
		}

		public string fMode
		{
			get
			{
				return _mode;
			}
			set
			{
				_mode = value;
			}
		}

		public string ClassName
		{
			get
			{
				return _cn;
			}
			set
			{
				_cn = value;
			}
		}

		#endregion

		#region ** Accounts **
		private string ControlRecord;
		private string[] linedata2 = new string[1];
		private string BatchCode;
		private string SummaryRecord;
		private string month;

		private void InitIPP()
		{
			oUser = new User();
            ucMemberID1 = new ucMemberID();           
            ucMemberID1.StrBranchCode = oUser.StrBranchCode();

			IPPdtStart.EditValue = DateTime.Today.Date;
			IPPdtTo.EditValue = DateTime.Today.Date;
			//string strSQL;
			//			myRP = new ACMSLogic.ReceiptPayment();
			//			gridReceipt.DataSource = myRP.SelectPresetTable;

			DataTable dt = myCommon.ExecuteQuery("Select * from tblBank");
			new ManagerBankLookupEditBuilder(dt, IPPBankCode.Properties);
			new ManagerBankLookupEditBuilder(dt, lkBank.Properties);
		
			dt = myCommon.ExecuteQuery("Select strBranchCode,strBranchName from tblBranch");
			new ManagerBranchCodeLookupEditBuilder(dt, lkBranch.Properties);
			
		}

		private string MonthDesc(int month)
		{
			switch (month)
			{
				case 1: return "JANUARY";
				case 2: return "FEBRUARY";
				case 3: return "MARCH";
				case 4: return "APRIL";
				case 5: return "MAY";
				case 6: return "JUNE";
				case 7: return "JULY";
				case 8: return "AUGUST";
				case 9: return "SEPTEMBER";
				case 10: return "OCTOBER";
				case 11: return "NOVEMBER";
				case 12: return "DECEMBER";
				
			}
			return null;
						 
		}

		public enum IPPStatusEnum
		{
			New = 0,
			Sent = 1,
			Received = 2
		}

		private void IPPDataBind(DataTable dt)
		{
			IPPId.EditValue = "";
			IPPMemberId.EditValue = "";
			IPPMemberName.EditValue = "";
			IPPBranchCode.EditValue = "";
			IPPBankCode.EditValue = "";
			IPPCCNo.EditValue = "";
			IPPCreatedDate.EditValue = "";
			IPPNMonths.EditValue = "";
			IPPDateRcv.EditValue = "";
			IPPDateSent.EditValue = "";
			//IPPMerchantNo.DataBindings.Add("EditValue", dt, "strMerchantNo") ;
			IPPStatus.EditValue = "";
			IPPMerchantNo.EditValue = "";
			IPPBranchCode.EditValue = "";
			strReferenceNo.EditValue = "";


			IPPGrid.DataSource = dt;
			UI.ClearDataBinding(GroupGiro.Controls);
			UI.ClearDataBinding(IPPGrid.Controls);
			UI.ClearDataBinding(GroupIPPDetails.Controls);
			IPPMerchantNo.DataBindings.Clear();
			IPPBranchCode.DataBindings.Clear();

			
			if (dt == null) return;

			IPPId.DataBindings.Add(new Binding("EditValue", dt, "nIPPID"));
			IPPMemberId.DataBindings.Add(new Binding("EditValue", dt, "strMembershipID"));
			IPPMemberName.DataBindings.Add(new Binding("EditValue", dt, "strMemberName"));
			IPPBranchCode.DataBindings.Add(new Binding("EditValue", dt, "strBranchCode"));
			IPPBankCode.DataBindings.Add(new Binding("EditValue", dt, "strBankCode"));
			IPPCCNo.DataBindings.Add(new Binding("EditValue", dt, "strCreditCardNo"));
			IPPCreatedDate.DataBindings.Add(new Binding("EditValue", dt, "dtDate"));
			IPPNMonths.DataBindings.Add(new Binding("EditValue", dt, "nMonths"));
			IPPDateRcv.DataBindings.Add(new Binding("EditValue", dt, "dtReceivedDate"));
			IPPDateSent.DataBindings.Add(new Binding("EditValue", dt, "dtSentDate"));
			IPPMerchantNo.DataBindings.Add("EditValue", dt, "strMerchantNo") ;
			IPPAmount.DataBindings.Add("EditValue", dt, "Amount") ;
			IPPInterest.DataBindings.Add("EditValue", dt, "dInterestRate");
			IPPNettAmount.DataBindings.Add("EditValue", dt, "NettAmount");
			IPPStatus.DataBindings.Add("EditValue", dt, "txtStatus") ;
			strReferenceNo.DataBindings.Add("EditValue",dt,"strReferenceNo");

			
		}
		private void LoadIPP()
		{
			//IPPCurrentMonth.Text = "Current Month:" + MonthDesc(DateTime.Today.Month);
			
			string strSQL;
			
			strSQL = "Select strIPP, cast(sum(mAmount) as decimal(8,2)) as Amount, dInterestRate, cast(sum(mAmount) - (sum(mAmount) * dInterestRate/100) as decimal(8,2)) as NettAmount, TblIPP.nIPPID, tblBank.strDescription as strBankDesc, txtStatus = case nIPPStatus" +
				" when 0 then 'New'" +
				" when 1 then 'Sent'" +
				" when 2 then 'Received'" +
				" end, tblIPP.strMembershipID, strMemberName, tblIPP.strBranchCode, tblIPP.strBankCode, strMerchantNo, tblIPP.strCreditCardNo, tblIPP.dtDate, nMonths, dtReceivedDate, dtSentDate,tblIPP.strReferenceNo from tblIPP" +
				" Inner Join tblMember On TblMember.strMembershipID = tblIPP.strMembershipID " + 
				" Inner Join tblBank On tblBank.strBankCode = tblIPP.strBankCode " +
				" left Join tblReceiptPayment P On P.nIPPID = TblIPP.nIPPID " +
				" Inner Join tblReceipt Re On P.strReceiptNo = Re.strReceiptNo " +
				" Left Join " +
				" ( " +
				" Select dInterestRate, strBankCode, nMonth from TblBankIPPRate " +
				" ) " +
				" R On (R.strBankCode = TblIPP.strBankCode And R.nMonth = TblIPP.nMonths) ";
				

			if (month == "current")
			{
				strSQL += " where Re.fvoid = 0 and month(tblIPP.dtDate) = month(current_timestamp)";
			}
			else
			{
				strSQL += " Where Re.fvoid = 0 and (Convert(varchar(10),tblIPP.dtDate,120) >= '" + string.Format("{0:yyyy-MM-dd}",Convert.ToDateTime(IPPdtStart.EditValue)) + "'" +
					" And  Convert(varchar(10),tblIPP.dtDate,120) <= '" + string.Format("{0:yyyy-MM-dd}",Convert.ToDateTime(IPPdtTo.EditValue)) + "')";
			}
			
				     
			if (ComboBoxIPP.SelectedIndex == 1)
			{
				strSQL += " And nIPPStatus = 0";
			}
			else if (ComboBoxIPP.SelectedIndex == 2)
			{
				strSQL += " And nIPPStatus = 1";
			}
			else if (ComboBoxIPP.SelectedIndex == 3)
			{
				strSQL += " And nIPPStatus = 2";
			}
		
			if (lkBranch.EditValue != null && this.lkBranch.EditValue.ToString() != "")
			{
				strSQL += " And tblIPP.strBranchCode like '%" + lkBranch.EditValue + "%'";
			}
			if(lkBank.EditValue != null && this.lkBank.EditValue.ToString() != "")
			{
				strSQL += " And tblIPP.strBankCode like '%" + lkBank.EditValue + "%'";
			}
			if(txtCreditCardScr.EditValue != null && this.txtCreditCardScr.EditValue.ToString() != "")
			{
				strSQL += " And TblIPP.strCreditCardNo like '%" + txtCreditCardScr.EditValue + "%'";
			}

			strSQL += " group by strIPP, TblIPP.nIPPID, tblBank.strDescription, nIPPStatus, tblIPP.strMembershipID, strMemberName, tblIPP.strBranchCode, tblIPP.strBankCode, strMerchantNo, tblIPP.strCreditCardNo, tblIPP.dtDate, nMonths, dtReceivedDate, dtSentDate, dInterestRate,tblIPP.strReferenceNo" + 
				" Order By TblIpp.nIPPID asc";


			
			SqlCommand myCmd = new SqlCommand(strSQL, connection);
			myCmd.CommandType = CommandType.Text;
			
			SqlDataAdapter adpIPP = new SqlDataAdapter(myCmd); 

			//connection.Open(); 

			DataSet _ds = new DataSet("IPP"); 
			adpIPP.Fill(_ds, "IPP"); 

			//SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			IPPDataBind(_ds.Tables["IPP"]);
				
		}

		private void LoadIPPReceipt()
		{
			DataTable dt;
			DataRow row = IPPGridView.GetDataRow(IPPGridView.FocusedRowHandle);
			if (row != null)
			{
				string strSQL="select * from sv_getIPPReceiptPayment Where convert(Varchar(10),dtDate,120) = '" + string.Format("{0:yyyy-MM-dd}",Convert.ToDateTime(row["dtDate"])) + "'";

				if (IPPReceiptStatus.SelectedIndex == 0)
				{
					strSQL += " And nIPPID = " + row["nIPPId"];
				}
				else if (IPPReceiptStatus.SelectedIndex == 1)
				{
					strSQL += " And nIPPID is null And strPaymentCode = '" + row["strIPP"] + "'";
				}

				DataSet _ds = new DataSet();
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
				dt = _ds.Tables["table"];
				gridReceipt.DataSource = dt;
			}
			else
			{
				gridReceipt.DataSource = null;
			}
		}

		private void RefreshIPPGrid()
		{
			LoadIPP();
		}

		private void merchantNoReset()
		{
		
			string strSQL="select * from tblBanklPPMerchant where strBankCode='" + IPPBankCode.EditValue +"' and nMonth='" + IPPNMonths.Text + "' and strBranchCode='" + IPPBranchCode.EditValue + "'" ;
			DataSet _ds = new DataSet();
			IPPMerchantNo.DataBindings.Clear();
			IPPMerchantNo.Text = "";
	
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			if (_ds.Tables["table"].Rows.Count>0)
			{
				IPPMerchantNo.DataBindings.Add("EditValue",_ds.Tables["table"],"strMerchantNo");
			}

		}

		private void IPPBankCode_EditValueChanged(object sender, System.EventArgs e)
		{
			string strSQL;
			strSQL = "select distinct nMonth from tblBankIPPRate where strBankCode='" + IPPBankCode.EditValue.ToString() + "'";
			comboBind(IPPNMonths, strSQL, "nMonth", "nMonth", true);
		}

		private void IPPBankCode_SelectedValueChanged(object sender, System.EventArgs e)
		{
			merchantNoReset();
		}

		private void IPPNMonths_TextChanged(object sender, System.EventArgs e)
		{
			LoadIPPReceipt();
			merchantNoReset();
		}
	
		private void IPPCurrentMonth_Click(object sender, System.EventArgs e)
		{
			month = "current";
			LoadIPP();
		}

		private void ComboBoxIPP_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//IPPs.RefreshPreset(ComboBoxIPP.SelectedIndex,"");
			if (ComboBoxIPP.EditValue == null)
			{
				this.btnSendIPP.Enabled = false;
				this.btnReceiveIPP.Enabled = false;
			}
			else if (ComboBoxIPP.EditValue.ToString() == "0")
			{
				this.btnSendIPP.Enabled = true;
				this.btnReceiveIPP.Enabled = false;
			}
			else if (ComboBoxIPP.EditValue.ToString() == "1")
			{
				this.btnReceiveIPP.Enabled = true;
				this.btnSendIPP.Enabled = false;
			} 
			else if (ComboBoxIPP.EditValue.ToString() == "2")
			{
				this.btnSendIPP.Enabled = false;
				this.btnReceiveIPP.Enabled = false;
			}

			UI.ClearDataBinding(IPPGrid.Controls);
			UI.ClearDataBinding(GroupIPPDetails.Controls);
			LoadIPP();

		}

		private void btnNewIPP_Click(object sender, System.EventArgs e)
		{
			frmIPP_Add myNewIPP = new frmIPP_Add(IPPs,terminalUser.Branch.Id);
			myNewIPP.ShowDialog();
			myNewIPP.Dispose();
			RefreshIPPGrid();
		}

		private void btnUpdateIPP_Click(object sender, System.EventArgs e)
		{
			int output;
			output = 0;

			int nMonths;
			nMonths = Convert.ToInt32(this.IPPNMonths.EditValue);

			SqlHelper.ExecuteNonQuery(connection,"up_UpdateIPP",
				new SqlParameter("@RET_VAL",output),
				new SqlParameter("@nIPPID",Convert.ToInt32(IPPId.Text)),
				new SqlParameter("@strBankCode", IPPBankCode.EditValue.ToString() ),
				new SqlParameter("@nMonths", nMonths ),
				new SqlParameter("@strCreditCardNo",IPPCCNo.EditValue.ToString().Replace("-","")),
				new SqlParameter("@strReferenceNo",strReferenceNo.Text)
				);

			LoadIPP();
		}

		private void btnDeleteIPP_Click(object sender, System.EventArgs e)
		{
			IPPs = new IPP();
			DataTable dt;
			ACMS.XtraUtils.GridViewUtils.UpdateData(IPPGridView);
			DataRow row = IPPGridView.GetDataRow(IPPGridView.FocusedRowHandle);
			if (row != null)
			{
				string strSQL="select * from tblReceiptPayment where nIPPId = " + Convert.ToInt32(row["nIPPId"]);
				DataSet _ds = new DataSet();
			
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
				dt = _ds.Tables["table"];

				if (dt.Rows.Count > 0)
				{
					MessageBox.Show(this, "Cannot be deleted. Please unlink all the receipt from the IPP."); 
					return;
				}

				DialogResult result = MessageBox.Show(this, "Do you really want to delete record with IPP ID = " + row["NIPPID"].ToString() + "?",
					"Delete?", MessageBoxButtons.YesNo);
			
				if (result == DialogResult.Yes)
				{
					if (IPPs.Delete(ACMS.Convert.ToInt32(row["NIPPID"])))
					{
						MessageBox.Show(this, "Record deleted"); 
					}
				}
			}
			LoadIPP();
			
		}

		private void btnSendIPP_Click(object sender, System.EventArgs e)
		{
			DataRow row = IPPGridView.GetDataRow(IPPGridView.FocusedRowHandle);

			if (row != null)
			{
			}

			frmIPP_Send frmSend = new frmIPP_Send(row["nIPPID"].ToString());
			frmSend.ShowDialog();
			frmSend.Dispose();
			RefreshIPPGrid();
			
			
		}

		private void btnReceiveIPP_Click(object sender, System.EventArgs e)
		{
			DataRow row = IPPGridView.GetDataRow(IPPGridView.FocusedRowHandle);
			frmIPP_Received frmReceived = new frmIPP_Received(row["nIPPID"].ToString());
			frmReceived.ShowDialog();
			frmReceived.Dispose();	
			RefreshIPPGrid();
		}

		private void hypIPPDetails_Click(object sender, System.EventArgs e)
		{
			GroupIPPDetails.Show();
			groupIPPReceipt.Hide();
			
			hypIPPDetails.Font = Font001;
			hypReceipts.Font = Font002; 
		}


		//IPP first search
		private void btnIPPSearchDate_Click(object sender, System.EventArgs e)
		{
			//			string strSQL;
			//
			//			strSQL = "Select * from tblIPP " +
			//				"Inner Join tblMember On TblMember.strMembershipID = tblIPP.strMembershipID " +
			//				"where month(tblIPP.dtDate) = month(current_timestamp) and (Convert(varchar(10),dtDate,101) >= '" + string.Format("{0:yyyy-MM-dd}",Convert.ToDateTime(IPPdtStart.EditValue)) + 
			//				"' and  Convert(varchar(10),dtDate,101) < '" + string.Format("{0:yyyy-MM-dd}",Convert.ToDateTime(IPPdtTo.EditValue)) + "') " +
			//				"Order By nIPPID asc";
			//			DataSet _ds = new DataSet();
			//			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			//			IPPDataBind(_ds.Tables["table"]);
		}

		//IPP Second search
		private void btnIPPSearch_Click(object sender, System.EventArgs e)
		{
			//			string strSQL;
			//			strSQL = "";
			//			if (cbIPPSearchTarget.SelectedText == "Branch")
			//			{
			//				strSQL = "Select * from tblIPP " +
			//					"Inner Join tblMember On TblMember.strMembershipID = tblIPP.strMembershipID " +
			//					"where month(tblIPP.dtDate) = month(current_timestamp) and tblIPP.strBranchCode like '%" + txtIPPSearchValue.Text + "%' " +
			//					"Order By nIPPID asc";
			//			}
			//			else if(cbIPPSearchTarget.SelectedText == "Bank")
			//			{
			//				strSQL = "Select * from tblIPP " +
			//					"Inner Join tblMember On TblMember.strMembershipID = tblIPP.strMembershipID " +
			//					"where month(tblIPP.dtDate) = month(current_timestamp) and strBankCode like '%" + txtIPPSearchValue.Text + "%' " +
			//					"Order By nIPPID asc";
			//			}
			//			else if(cbIPPSearchTarget.SelectedText == "Credit Card")
			//			{
			//				strSQL = "Select * from tblIPP " +
			//					"Inner Join tblMember On TblMember.strMembershipID = tblIPP.strMembershipID " +
			//					"where month(tblIPP.dtDate) = month(current_timestamp) and strCreditCardNo like '%" + txtIPPSearchValue.Text + "%' " +
			//					"Order By nIPPID asc";
			//			}
			//
			//
			//			DataSet _ds = new DataSet();
			//			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			//			IPPDataBind(_ds.Tables["table"]);
		
		}

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			month = "";
			LoadIPP();
		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			this.lkBranch.EditValue = null;
			this.lkBank.EditValue = null;
			this.txtCreditCardScr.EditValue = null;
			LoadIPP();
		}

		private void IPPId_TextChanged(object sender, System.EventArgs e)
		{
			ACMS.XtraUtils.GridViewUtils.UpdateData(IPPGridView);
			DataRow row = IPPGridView.GetDataRow(IPPGridView.FocusedRowHandle);
		
			string strSQL="select isnull(sum(mAmount),0.00) as amt from tblReceiptPayment where nIPPID='" + row["NIPPID"].ToString() +"'";
			DataSet _ds = new DataSet();
			IPPAmount.DataBindings.Clear();
			IPPAmount.Text = "0.00";
	
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			if (_ds.Tables["table"].Rows.Count>0)
			{
				IPPAmount.DataBindings.Add("EditValue",_ds.Tables["table"],"amt");
			}
			_ds = new DataSet();
			IPPInterest.DataBindings.Clear();
			IPPInterest.Text = "0.00";
			strSQL="select dInterestRate as rate from tblBankIPPRate where strBankCode='" + row["strBankCode"].ToString() + "' and nMonth='" + row["nMonths"] + "'";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			if (_ds.Tables["table"].Rows.Count > 0 )
			{
				IPPInterest.DataBindings.Add("EditValue",_ds.Tables["table"],"rate");								
			}
			string rate = IPPInterest.Text;
				
			decimal sum;
			sum = Convert.ToDecimal(IPPAmount.Text) - (Convert.ToDecimal(IPPAmount.Text)*Convert.ToDecimal(rate));
			IPPNettAmount.Text = sum.ToString();
			
			LoadIPPReceipt();
		}

		private void IPPGridView_Click(object sender, System.EventArgs e)
		{
			
		}

		private void comboBoxGiroStatus_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LoadGIRO();
		}

		private void LoadGIRO()
		{
			RefreshGiroGrid();
			LoadGIRODetail();
			DataTable dt;
			string sql = "Select * from TBLGIRO Inner Join TBLMember On TBLMember.strMembershipID = TBLGiro.strMembershipID Left Join TBLPackage On TBLPackage.strPackageCode = TBLGiro.strPackageCode";
			sql += " Where TBLGIRO.nStatusID = " + ConvertToInt(comboBoxGiroStatus.EditValue);

			dt = myCommon.ExecuteQuery(sql);
			GiroGrid.DataSource = dt;
							
			txtGIROId.DataBindings.Add(new Binding("EditValue", dt, "nGIRORefID"));
			luedtBankBranch.DataBindings.Add(new Binding("EditValue", dt, "strBankBranchCode"));
			luedtBank.DataBindings.Add(new Binding("EditValue", dt, "strBankCode"));
			luedtBranch.DataBindings.Add(new Binding("EditValue", dt, "strBranchCode"));
			ucMemberID1.DataBindings.Add(new Binding("EditValue", dt, "strMembershipID"));
			luedtPackage.DataBindings.Add(new Binding("EditValue", dt, "strPackageCode"));
			txtAccountNo.DataBindings.Add(new Binding("EditValue", dt, "strAccountNo"));
			txtRemark.DataBindings.Add(new Binding("EditValue", dt, "strRemarks"));
			txtPackageDesc.DataBindings.Add(new Binding("EditValue",dt,"strDescription"));
		}

		private void LoadGIRODetail()
		{
			DataTable dt;

			dt = myCommon.ExecuteQuery("Select * from tblBank");
			new ManagerBankLookupEditBuilder(dt, luedtBank.Properties);

			dt = myCommon.ExecuteQuery("Select * from tblBankBranch");
			new ManagerBankBranchLookupEditBuilder(dt, luedtBankBranch.Properties);

			dt = myCommon.ExecuteQuery("Select strBranchCode,strBranchName from tblBranch");
			new ManagerBranchCodeLookupEditBuilder(dt, luedtBranch.Properties);

			dt = myCommon.ExecuteQuery("Select strPackageCode,strDescription from tblPackage");
			new ManagerPackageLookupEditBuilder(dt, luedtPackage.Properties);	
		}

		private void RefreshGiroGrid()
		{
			GiroGrid.DataBindings.Clear();
			txtGIROId.Text = "";
			luedtBankBranch.EditValue = "";
			luedtBank.EditValue = "";
			luedtBranch.EditValue = "";
			ucMemberID1.EditValue = "";
			luedtPackage.EditValue = "";
			txtAccountNo.EditValue = "";
			txtRemark.EditValue = "";
			txtPackageDesc.EditValue = "";

			UI.ClearDataBinding(tabGiroDetails.Controls);
		}



		private void IPPReceiptStatus_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (IPPReceiptStatus.SelectedIndex == 0)
			{
				btnReceiptLink.Enabled = false;
				btnReceiptUnlink.Enabled = true;
			}
			else
			{
				btnReceiptLink.Enabled = true;
				btnReceiptUnlink.Enabled = false;
			}
			LoadIPPReceipt();
		}

		private void IPPGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			LoadIPPReceipt();
		}

		
		private void btnReceiptLink_Click(object sender, System.EventArgs e)
		{
			DataRow row = IPPGridView.GetDataRow(IPPGridView.FocusedRowHandle);

			DataRow rr = IPPReceiptView.GetDataRow(IPPReceiptView.FocusedRowHandle);

			if (row != null && rr != null)
			{
				SqlHelper.ExecuteNonQuery(connection,"sp_UpdateReceipt_IPPPaymentStatus",
					new SqlParameter("@inIPPID",Convert.ToInt32(row["nIPPId"])),
					new SqlParameter("@PaymentID",Convert.ToInt32(rr["nPaymentID"]))
					);	
				MessageBox.Show("Receipt linked", "Link");
			}

			//			frmIPPReceipt myNewRL = new frmIPPReceipt(row["nIPPID"].ToString());
			//			myNewRL.ShowDialog();
			//			myNewRL.Dispose();

			LoadIPPReceipt();
		}

		private void btnReceiptUnlink_Click(object sender, System.EventArgs e)
		{
			DataRow row = IPPReceiptView.GetDataRow(IPPReceiptView.FocusedRowHandle);
			
			if (row != null)
			{
				SqlHelper.ExecuteNonQuery(connection,"sp_UpdateReceipt_IPPPaymentStatus",
					new SqlParameter("@inIPPID",System.DBNull.Value),
					new SqlParameter("@PaymentID",Convert.ToInt32(row["nPaymentID"]))
					);	

				MessageBox.Show("Receipt Unlinked", "Unlink");
			}
			LoadIPPReceipt();
		}
		private void hypReceipts_Click(object sender, System.EventArgs e)
		{
			GroupIPPDetails.Hide();
			groupIPPReceipt.Show();
			hypIPPDetails.Font = Font002;
			hypReceipts.Font = Font001; 

			LoadIPPReceipt();
		}

		private void hypGiroDetails_Click(object sender, System.EventArgs e)
		{
			GroupIPPDetails.Hide();
			groupIPPReceipt.Hide();
			//			GroupGiroDetails.Show();
			hypIPPDetails.Font = Font002;
			//			hypGiroDetails.Font = Font001;
			hypReceipts.Font = Font002; 
		}

		private decimal SumHash(decimal OrigAccNo,decimal RecAccNo)
		{
			string a="";
			a = OrigAccNo.ToString();
			for (int i = 0;i<11 - OrigAccNo.ToString().Length;i++)
			{
				a += "0"; 	
			}
			
			char[] b;
			string OrigBLeft = "";
			string OrigBRight = "";
		
			b = a.ToCharArray();

			for (int i=0;i<6;i++)
			{
				OrigBLeft += b[i];
			}

			for (int i=6;i<b.Length;i++)
			{
				OrigBRight += b[i];
			}
			


			string c="";
			c = RecAccNo.ToString();
			for (int i = 0;i<11 - RecAccNo.ToString().Length;i++)
			{
				c += "0"; 	
			}
			
			char[] d;
			string RevBLeft = "";
			string RevBRight = "";
		
			d = c.ToCharArray();

			for (int i=0;i<6;i++)
			{
				RevBLeft += d[i];
			}

			for (int i=6;i<b.Length;i++)
			{
				RevBRight += d[i];
			}



			//decimal OrigB = Convert.ToDecimal(a.PadRight(5));
			//			decimal ReceiA = Convert.ToDecimal(RecAccNo.ToString().Substring(0,6));
			//			decimal ReceiB = Convert.ToDecimal(RecAccNo.ToString().Substring(7,RecAccNo.ToString().Length));

			decimal OrigAccNo1 = Convert.ToDecimal(OrigBLeft) - Convert.ToDecimal(OrigBRight);
			decimal RecAccNo1 = Convert.ToDecimal(RevBLeft) - Convert.ToDecimal(RevBRight);

			decimal Total = OrigAccNo1 + RecAccNo1;
			return Total;


		}

		private void WriteFile()
		{
			string path;
			path = "C:\\GIRO.txt";
			
			StreamWriter sw;
			sw = File.CreateText(path);
			
			sw.WriteLine(ControlRecord);
			

			for(long i = 0;i<linedata2.Length;i++)
			{
				sw.WriteLine(linedata2[i]);
			}
			
			sw.WriteLine(SummaryRecord);
			linedata2 = new string[1];
			sw.Flush();
			sw.Close();
		}

		private void GIROBatchInsert(decimal TaxRate)
		{
		
			string[] col = {"strBatchCode","dtDate","dtSendDate","dtReceiveDate","nEmployeeID"};
			object[] val = {BatchCode,DateTime.Now,DateTime.Now,DateTime.Now,employee.Id.ToString()};

			myCommon.Insert("tblGIROBatch",col,val);
			
		
			DataRow row = GIROGridView.GetDataRow(GIROGridView.FocusedRowHandle);
			string GIROId;
			decimal NetAmount;
			int Id;
			GIROId = "";
			for(int i=0;i<GIROGridView.SelectedRowsCount;i++)
			{
				Id = Convert.ToInt32(GIROGridView.GetSelectedRows().GetValue(i));
				GIROId = GIROGridView.GetRowCellValue(Id,"nGIRORefID").ToString();

				NetAmount = nGIROListPrice(GIROId);
				string[] col1 = {"strBatchCode","nGIRORefID","mNettAmount","mGSTAmount","mTotalAmount","nStatusID"};
				object[] val1 = {BatchCode,GIROId,NetAmount,NetAmount * TaxRate,NetAmount + (NetAmount * TaxRate),1};
			
				myCommon.Insert("tblGiroBatchEntries",col1,val1);
	
			}	

		}

		private decimal nGIROListPrice(string GIROId)
		{
			DataTable dt;
			dt = myCommon.ExecuteQuery("Select * from tblGIRO Inner Join TblPackage On TblPackage.strPackageCode = tblGIRO.strPackageCode Where nGIRORefID = '" + GIROId + "'");
			return Convert.ToDecimal(dt.Rows[0]["mListPrice"]);

		}

		private string BatchCodeGenerate()
		{
			DataTable dt;
			string Code="";
			dt = myCommon.ExecuteQuery("Select isnull(max(strBatchCode) + 1,1) as BatchCode from tblGIROBatch");
			
			for(int i = 0;i<5-dt.Rows[0]["BatchCode"].ToString().Length;i++)
			{
				Code += "0"; 
			}

			return Code + dt.Rows[0]["BatchCode"].ToString();
		}

		private void btnGiroNew_Click(object sender, System.EventArgs e)
		{
			
			ACMSLogic.User oUser = new User();
			frmGIRO_Add myform;
			myform = new frmGIRO_Add(employee.Id,terminalUser.Branch.Id);
			//myform.SetEmployeeRecord(employee);
			//myform.SetTerminalUser(terminalUser);
			//myform.initData(oUser);
			myform.ShowDialog();

			//frmGIRO_Add myNewGIRO = new frmGIRO_Add();
			//myNewGIRO.ShowDialog();
			//myNewGIRO.Dispose();
			LoadGIRO();
		}

		private void btnGiroDelete_Click(object sender, System.EventArgs e)
		{
			DataRow row = GIROGridView.GetDataRow(GIROGridView.FocusedRowHandle);
		
			if (row != null)
			{
				DialogResult result = MessageBox.Show(this, "Do you really want to delete record with GIRO ID = " + row["nGIRORefID"].ToString() + "",
					"Delete?", MessageBoxButtons.YesNo);

				if (result == DialogResult.Yes)
				{
					try 
					{ 
						myCommon.Delete("tblGIRO","nGIRORefID='" + row["nGIRORefID"].ToString() + "'");
						MessageBox.Show(this, "Record is successful deleted"); 
					} 
					catch (Exception ex) 
					{ 
						throw new Exception(ex.Message); 
					} 
			
				}
			}
			LoadGIRO();
		}

		private void btnGiroUpdate_Click(object sender, System.EventArgs e)
		{
			if (GIROGridView.FocusedRowHandle < 0)
			{
				UI.ShowErrorMessage(this, "Please select a row at Giro first.");
				return;
			}

			DataRow row = GIROGridView.GetDataRow(GIROGridView.FocusedRowHandle);
	
			string[] col = {"strMembershipID","strPackageCode","strBranchCode","strBankCode","strBankBranchCode","strAccountNo","strRemarks"};
			object[] val = {ucMemberID1.EditValue.ToString(),luedtPackage.EditValue.ToString(),luedtBranch.EditValue.ToString(),luedtBank.EditValue.ToString(),luedtBankBranch.EditValue.ToString(),txtAccountNo.Text,txtRemark.Text};

			myCommon.Update("TblGIRO",col,val,"nGIRORefID='" + row["nGIRORefID"].ToString() + "'");
			RefreshGiroGrid();
			LoadGIRO();
		}

		private void btnGiroExport_Click(object sender, System.EventArgs e)
		{
			BatchCode = BatchCodeGenerate();
			
			DataTable dtCompany;
			dtCompany = myCommon.ExecuteQuery("Select * from tblCompany Inner Join tblTax On tblTax.nTaxID = tblCompany.nTaxID");
			GIROBatchInsert(Convert.ToDecimal(dtCompany.Rows[0]["dTaxRate"]));


			DataRow row = GIROGridView.GetDataRow(GIROGridView.FocusedRowHandle);
			string GIROId;
			int Id;
			GIROId = "";
				
			string DateValue = "";
			string OriginateBankNo = "";
			string OriginateBranchNo = "";
			string OriginateAccNo = "";
			string OriginatorName = "";
			string BatchNo = "";
			string CompanyId = "";
			string RecordType = "";
			string Filler1 = "";
			string Filler2 = "";
			string Filler3 = "";
			string ReceiveBankNo = "";
			string BranchNo = "";
			string AccNo = "";
			string AccName = "";
			string TransactionCode = "";
			string Amount = "";
			string Filler4 = "";
			string Particular = "";
			string Reference = "";
			string RecordType2 = "";
			string DebitNo = "";
			string DebitAmt = "";
			string HashNo = "";
			string TotalAmt = "";
			decimal SumAccNo = 0;


			DataTable dt;
			WriteGiro Write = new WriteGiro();
			dt = myCommon.ExecuteQuery("Select * from tblCompany");

			DateValue = string.Format("{0:yyMMdd}",DateTime.Today.Date);
			Filler1 = Write.PadValue("",45,"");
			OriginateBankNo = "7171";
			OriginateBranchNo = Write.PadValue(dt.Rows[0]["strBranchCode"].ToString(),3,"0");
			OriginateAccNo = Write.PadValue(dt.Rows[0]["strAccountNo"].ToString(),11,"0");
			Filler2 = Write.PadValue("",2,"");
			OriginatorName = Write.PadValue(dt.Rows[0]["straccountname"].ToString(),20,"");
			BatchNo = Write.PadValue(BatchNo,5,"");
			CompanyId = Write.PadValue("COMPANYID",5,"");
			Filler3 = Write.PadValue("",9,"");
			RecordType = "0";
               
				
			ControlRecord = DateValue + Filler1 + OriginateBankNo + OriginateBranchNo + OriginateAccNo + Filler2 + OriginatorName + BatchNo + CompanyId + Filler3 + RecordType;
			for(int i=0;i<GIROGridView.SelectedRowsCount;i++)
			{
				Id = Convert.ToInt32(GIROGridView.GetSelectedRows().GetValue(i));
				GIROId = GIROGridView.GetRowCellValue(Id,"nGIRORefID").ToString();
				dt = myCommon.ExecuteQuery("Select * from tblGIRO Inner Join tblEmployee On TblEmployee.nEmployeeID = tblGIRO.nEmployeeID Inner Join tblGiroBatchEntries E On E.nGIRORefID = tblGiro.nGIRORefID Where tblGIRO.nGIRORefID = '" + GIROId + "'");
		
				ReceiveBankNo = "7171";
				BranchNo = Write.PadValue(dt.Rows[0]["strBankBranchCode"].ToString(),3,"0");
				AccNo = Write.PadValue(dt.Rows[0]["strAccountNo"].ToString(),11,"_");
				AccName = Write.PadValue(dt.Rows[0]["strEmployeeName"].ToString(),20,"_");
				TransactionCode =Write.PadValue("30",2,"0");
				Amount = Write.PadValue((Convert.ToDecimal(dt.Rows[0]["mNettAmount"]) * 100).ToString(),11,"0");
				Filler4 = Write.PadValue("",38,"0");
				Particular = Write.PadValue(dt.Rows[0]["nEntryID"].ToString(),12,"0");
				Reference = Write.PadValue(dt.Rows[0]["nEmployeeID"].ToString(),12,"0");
				RecordType2 = Write.PadValue("1",1,"0");
				TotalAmt += (Convert.ToDecimal(dt.Rows[0]["mNettAmount"]) * 100).ToString();

				SumAccNo += SumHash(Convert.ToDecimal(OriginateAccNo),Convert.ToDecimal(AccNo));

				string[] AdviceRecord = new string[i+1];
				//linedata = new string[glino + 1];
				linedata2.CopyTo(AdviceRecord,0);
				AdviceRecord[i] = ReceiveBankNo + BranchNo + AccNo + AccName + TransactionCode + Amount + Filler4 + Particular + Reference + RecordType2;
				linedata2 = AdviceRecord;

			}
			
			string CreditNo = "";
			string CreditAmt = "";
			
			CreditNo = Write.PadValue("0",8,"_");
			CreditAmt = Write.PadValue("0",11,"_");
			Filler1 = Write.PadValue("",5,"_");
			DebitNo = Write.PadValue(GIROGridView.SelectedRowsCount.ToString(),8,"0");
			DebitAmt = Write.PadValue(TotalAmt,11,"0");
			Filler2 = Write.PadValue("",26,"_");
			HashNo =  Write.PadValue(SumAccNo.ToString(),11,"_");
			Filler3 = Write.PadValue("",33,"_");
			RecordType = Write.PadValue("9",1,""); 

		
			SummaryRecord = CreditNo + CreditAmt + Filler1 + DebitNo + DebitAmt + Filler2 + HashNo + Filler3 + RecordType;
			WriteFile();

		}





		#region GiroImport

		private void btnImport_Click(object sender, System.EventArgs e)
		{
			GetLineCount();
		}

		private string line;
		private int Count = 0;
		private string ImportBatchCode = "";
		private string AccNo = "";
		private string SuccessIndicator = "";
		private string ReasonCode = "";
		private string ValueDate = "";
		bool FirstRun;
		
		private void GetLineCount()
		{

			string FilePath;
			openFileDialog1.ShowDialog();
			FilePath = openFileDialog1.FileName;
		
			// open files for streamreader
			FileStream fs = new FileStream(FilePath,FileMode.Open,FileAccess.Read);
			StreamReader sr = new StreamReader(fs);
					
			line = sr.ReadLine();
		
			while(line !=null)
			{
				ParseClean(line);
				line = sr.ReadLine();
				Count++;
			}

			//close the streamreader
			sr.Close();
			ImportBatchCode = "";
			line = "";
			Count = 0;
			AccNo = "";
			SuccessIndicator = "";
			ReasonCode = "";
			ValueDate = "";
			FirstRun = true;
		}

		private void ParseClean(string strline)
		{
			
			DataSet _ds;
			string strSQL = "";
			DataTable dt;
			int Status = 0;
			
            	
			if (strline.Substring(0,1) == "0")
			{
				ValueDate = strline.Substring(19,6);
				ImportBatchCode = strline.Substring(25,5);
				strSQL = "select dtReceiveDate from tblGiroBatch Where strBatchCode = '" + ImportBatchCode + "'";
				_ds = new DataSet();
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
				dt = _ds.Tables["table"];
				if (dt.Rows[0][0].ToString() != "")
					FirstRun = false;
				else
					FirstRun = true;
				
			}
			else if (strline.Substring(0,1) == "1")
			{
				SuccessIndicator = strline.Substring(76,1);
				AccNo = strline.Substring(8,11).Trim();
				ReasonCode = strline.Substring(77,2);
				if (SuccessIndicator == "1")
					Status = 2;
				else
					Status = 0;
				UpdateGiroStatus(Status);
			}
		
		}
		//07171---         12306040400001--------
		//1-------        123                    --30200000000          11            130  
		private void UpdateGiroStatus(int GiroStatus)
		{
			int output;
			output = 0;
			string Remarks = "";
		
			switch (ReasonCode)
			{
				case "10":
					Remarks = "INVALID REC ACCOUNT NUMBER";
					break;
				case "20":
					Remarks = "ERROR IN REEV BANK CODE";
					break;
				case "21":
					Remarks = "ERROR IN RECV BR CODE";
					break;
				case "30":
					Remarks = "AMT EXCEEDED";
					break;
				case "31":
					Remarks = "ERROR IN AMOUNT";
					break;
				case "40":
					Remarks = "NO DDA";
					break;
				case "41":
					Remarks = "DDA TERMINATED";
					break;
				case "42":
					Remarks = "INV ORIG A/C NO";
					break;
				case "43":
					Remarks = "ERROR IN ORIG BANK CODE";
					break;
				case "44":
					Remarks = "NON-ORIG BANK CODE";
					break;
				case "45":
					Remarks = "ERROR IN ORIG BRANCH CODE";
					break;
				case "46":
					Remarks = "UNMATCHED REF NO";
					break;
				case "47":
					Remarks = "REF NO MISSING";
					break;
				case "50":
					Remarks = "REF PAYING PARTY";
					break;
				case "51":
					Remarks = "EFFECTS NOT CLEARED";
					break;
				case "60":
					Remarks = "ACCOUNT CLOSED";
					break;
				case "61":
					Remarks = "ACCOUNT DOES NOT EXIST";
					break;
				case "90":
					Remarks = "ANY OTHER REASONS";
					break;
				case "97":
					Remarks = "MISCELLANEOUS ERRORS";
					break;
				default:
					Remarks = "";
					break;

			}

			SqlHelper.ExecuteNonQuery(connection,"up_GiroEntries",
				new SqlParameter("@retval",output),
				new SqlParameter("@AccNo",AccNo),
				new SqlParameter("@BatchCode",ImportBatchCode),
				new SqlParameter("@Status",GiroStatus),
				new SqlParameter("@FirstRun",FirstRun),
				new SqlParameter("@Remarks",Remarks)
				);
			ReasonCode = "";
		}


		#endregion

		#endregion

		#region ** Operation **
		private void OperationInit()
		{
			ClassScheduleInit();
		}

		private void ClassScheduleInit()
		{
			string strSQL;

			strSQL = "select strBranchName, strBranchCode from tblBranch";
			DataTable dt = myCommon.ExecuteQuery(strSQL);
			new ManagerBranchCodeLookupEditBuilder(dt, comboBoxBranch.Properties);
			if (dt.Rows.Count > 0)
				comboBoxBranch.EditValue = dt.Rows[0]["strBranchCode"];
			//comboBind(comboBoxBranch,strSQL,"strBranchName","strBranchCode");
		}

		private void _Click(object sender,System.EventArgs e)
		{
			ACMS.Control.ClassComponent cc;
			cc = (ACMS.Control.ClassComponent) sender;
			
			string strSQL = "select * from tblClassSchedule where strClassCode='" + cc.ClassName + "' and nDay="+ cc.Day + " and nHallNo='" + cc.ClassHall + "' and convert(varchar,dtStartTime,108)='" + Convert.ToDateTime(cc.StartTime).ToString("HH:mm:ss") + "'";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			ACMSManager.frmClassSchedule myform = new ACMS.ACMSManager.frmClassSchedule(_ds.Tables["table"]);
			myform.ShowDialog();		}

		private void btnNewClassSchedule_Click(object sender, System.EventArgs e)
		{
			ACMSManager.frmClassSchedule myform = new ACMS.ACMSManager.frmClassSchedule('I');
			myform.Show();
			
		}

		private void btnPrintClassSchedule_Click(object sender, System.EventArgs e)
		{
			
			try
			{
				capturescreen();
				printDocument1.Print();
			}
			catch
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				//throw new Exception("Default Printer not ready.", ex);
				MessageBox.Show(this,"Default printer not ready.");
			}
			finally
			{
			}

		}

		private void btnEditClassSchedule_Click(object sender, System.EventArgs e)
		{
			ACMSManager.frmClassSchedule myform = new ACMS.ACMSManager.frmClassSchedule('U');
			myform.Show();
		}

		private string getInstructorName(int nEmployeeID)
		{
			string strSQL = "select strEmployeeName from tblEmployee where nEmployeeID=" + nEmployeeID;
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			foreach(DataRow dr in _ds.Tables["Table"].Rows)
			{
				return dr["strEmployeeName"].ToString();
			}
			return null;
				
		}

		private void scheduleRefresh()
		{
			this.SuspendLayout();

			panelMon.Controls.Clear();
			panelTue.Controls.Clear();
			panelWed.Controls.Clear();
			panelThu.Controls.Clear();
			panelFri.Controls.Clear();
			panelSat.Controls.Clear();
			panelSun.Controls.Clear();

			string strSQL;
			strSQL = "select strBranchCode,nDay,dtStartTime,dtEndTime," + 
				"strClassCode,nHallNo,nInstructorID,fFree,fPeak,fAllowStudentOnPeak,fReservation," +
				"nMaxNo,fAllowUOBBooking,nCommissionTypeID from tblClassSchedule " +
				"where strBranchCode='" + comboBoxBranch.EditValue.ToString() + "'";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			_dtClassSchedule = _ds.Tables["table"];
			int nMon,nTue,nWed,nThu,nFri,nSat,nSun;
			nMon = 2;
			nTue = 2;
			nWed = 2;
			nThu = 2;
			nFri = 2;
			nSat = 2;
			nSun = 2;
		

			foreach(DataRow dr in _dtClassSchedule.Rows)
			{
				if (dr["nDay"].ToString()=="1")
				{
					classComponent1 = new ACMS.Control.ClassComponent();
					panelMon.Controls.Add(classComponent1);
					// 
					// classComponent1
					// 
					classComponent1.BackColor = System.Drawing.Color.Silver;
					classComponent1.Location = new System.Drawing.Point(2, nMon);
					classComponent1.Name = "classComponent1";
					classComponent1.Size = new System.Drawing.Size(97, 50);
					classComponent1.TabIndex = 0;
					classComponent1.Click += new System.EventHandler(_Click);
					classComponent1.lblClassTime.Text = Convert.ToDateTime(dr["dtStartTime"]).ToShortTimeString() + "-" + Convert.ToDateTime(dr["dtEndTime"]).ToShortTimeString();
					classComponent1.lblClassName.Text = dr["strClassCode"].ToString();
					classComponent1.lblClassInstructor.Text = getInstructorName(Convert.ToInt32(dr["nInstructorID"]));
					classComponent1.lblClassHall.Text = "Hall " + dr["nHallNo"].ToString();
					nMon = nMon + 50;
					classComponent1.Day = Convert.ToInt32(dr["nDay"]);
					classComponent1.StartTime = dr["dtStartTime"].ToString();
					classComponent1.Branch = comboBoxBranch.EditValue.ToString();
					
				}
				else if (dr["nDay"].ToString()=="2")
				{
					classComponent1 = new ACMS.Control.ClassComponent();
					panelTue.Controls.Add(classComponent1);
					// 
					// classComponent1
					// 
					classComponent1.BackColor = System.Drawing.Color.Silver;
					classComponent1.Location = new System.Drawing.Point(2, nTue);
					classComponent1.Name = "classComponent1";
					classComponent1.Size = new System.Drawing.Size(97, 50);
					classComponent1.TabIndex = 0;
					classComponent1.Click += new System.EventHandler(_Click);
					classComponent1.lblClassTime.Text = Convert.ToDateTime(dr["dtStartTime"]).ToShortTimeString() + "-" + Convert.ToDateTime(dr["dtEndTime"]).ToShortTimeString();
					classComponent1.lblClassName.Text = dr["strClassCode"].ToString();
					classComponent1.lblClassInstructor.Text = getInstructorName(Convert.ToInt32(dr["nInstructorID"]));
					classComponent1.lblClassHall.Text = "Hall " + dr["nHallNo"].ToString();
					nTue = nTue + 50;
					classComponent1.Day = Convert.ToInt32(dr["nDay"]);
					classComponent1.StartTime = dr["dtStartTime"].ToString();
					classComponent1.Branch = comboBoxBranch.EditValue.ToString();
			
					//classComponent1.init(_dtClassSchedule);
		
				}
				else if (dr["nDay"].ToString()=="3")
				{
					classComponent1 = new ACMS.Control.ClassComponent();
					panelWed.Controls.Add(classComponent1);
					// 
					// classComponent1
					// 
					classComponent1.BackColor = System.Drawing.Color.Silver;
					classComponent1.Location = new System.Drawing.Point(2, nWed);
					classComponent1.Name = "classComponent1";
					classComponent1.Size = new System.Drawing.Size(97, 50);
					classComponent1.TabIndex = 0;
					classComponent1.Click += new System.EventHandler(_Click);
					classComponent1.lblClassTime.Text = Convert.ToDateTime(dr["dtStartTime"]).ToShortTimeString() + "-" + Convert.ToDateTime(dr["dtEndTime"]).ToShortTimeString();
					classComponent1.lblClassName.Text = dr["strClassCode"].ToString();
					classComponent1.lblClassInstructor.Text = getInstructorName(Convert.ToInt32(dr["nInstructorID"]));
					classComponent1.lblClassHall.Text = "Hall " + dr["nHallNo"].ToString();
					nWed = nWed + 50;
					classComponent1.Day = Convert.ToInt32(dr["nDay"]);
					classComponent1.StartTime = dr["dtStartTime"].ToString();
					classComponent1.Branch = comboBoxBranch.EditValue.ToString();
			
					//classComponent1.init(_dtClassSchedule);
		
				}
				else if (dr["nDay"].ToString()=="4")
				{
					classComponent1 = new ACMS.Control.ClassComponent();
					panelThu.Controls.Add(classComponent1);
					// 
					// classComponent1
					// 
					classComponent1.BackColor = System.Drawing.Color.Silver;
					classComponent1.Location = new System.Drawing.Point(2, nThu);
					classComponent1.Name = "classComponent1";
					classComponent1.Size = new System.Drawing.Size(97, 50);
					classComponent1.TabIndex = 0;
					classComponent1.Click += new System.EventHandler(_Click);
					classComponent1.lblClassTime.Text = Convert.ToDateTime(dr["dtStartTime"]).ToShortTimeString() + "-" + Convert.ToDateTime(dr["dtEndTime"]).ToShortTimeString();
					classComponent1.lblClassName.Text = dr["strClassCode"].ToString();
					classComponent1.lblClassInstructor.Text = getInstructorName(Convert.ToInt32(dr["nInstructorID"]));
					classComponent1.lblClassHall.Text = "Hall " + dr["nHallNo"].ToString();
					nThu = nThu + 50;
					classComponent1.Day = Convert.ToInt32(dr["nDay"]);
					classComponent1.StartTime = dr["dtStartTime"].ToString();
					classComponent1.Branch = comboBoxBranch.EditValue.ToString();
		
				}
				else if (dr["nDay"].ToString()=="5")
				{
					classComponent1 = new ACMS.Control.ClassComponent();
					panelFri.Controls.Add(classComponent1);
					// 
					// classComponent1
					// 
					classComponent1.BackColor = System.Drawing.Color.Silver;
					classComponent1.Location = new System.Drawing.Point(2, nFri);
					classComponent1.Name = "classComponent1";
					classComponent1.Size = new System.Drawing.Size(97, 50);
					classComponent1.TabIndex = 0;
					classComponent1.Click += new System.EventHandler(_Click);
					classComponent1.lblClassTime.Text = Convert.ToDateTime(dr["dtStartTime"]).ToShortTimeString() + "-" + Convert.ToDateTime(dr["dtEndTime"]).ToShortTimeString();
					classComponent1.lblClassName.Text = dr["strClassCode"].ToString();
					classComponent1.lblClassInstructor.Text = getInstructorName(Convert.ToInt32(dr["nInstructorID"]));
					classComponent1.lblClassHall.Text = "Hall " + dr["nHallNo"].ToString();
					nFri = nFri + 50;
					classComponent1.Day = Convert.ToInt32(dr["nDay"]);
					classComponent1.StartTime = dr["dtStartTime"].ToString();
					classComponent1.Branch = comboBoxBranch.EditValue.ToString();
		
				}
				else if (dr["nDay"].ToString()=="6")
				{
					classComponent1 = new ACMS.Control.ClassComponent();
					panelSat.Controls.Add(classComponent1);
					// 
					// classComponent1
					// 
					classComponent1.BackColor = System.Drawing.Color.Silver;
					classComponent1.Location = new System.Drawing.Point(2, nSat);
					classComponent1.Name = "classComponent1";
					classComponent1.Size = new System.Drawing.Size(97, 50);
					classComponent1.TabIndex = 0;
					classComponent1.Click += new System.EventHandler(_Click);
					classComponent1.lblClassTime.Text = Convert.ToDateTime(dr["dtStartTime"]).ToShortTimeString() + "-" + Convert.ToDateTime(dr["dtEndTime"]).ToShortTimeString();
					classComponent1.lblClassName.Text = dr["strClassCode"].ToString();
					classComponent1.lblClassInstructor.Text = getInstructorName(Convert.ToInt32(dr["nInstructorID"]));
					classComponent1.lblClassHall.Text = "Hall " + dr["nHallNo"].ToString();
					nSat = nSat + 50;
					classComponent1.Day = Convert.ToInt32(dr["nDay"]);
					classComponent1.StartTime = dr["dtStartTime"].ToString();
					classComponent1.Branch = comboBoxBranch.EditValue.ToString();
		
				}
				else if (dr["nDay"].ToString()=="0")
				{
					classComponent1 = new ACMS.Control.ClassComponent();
					panelSun.Controls.Add(classComponent1);
					// 
					// classComponent1
					// 
					classComponent1.BackColor = System.Drawing.Color.Silver;
					classComponent1.Location = new System.Drawing.Point(2, nSun);
					classComponent1.Name = "classComponent1";
					classComponent1.Size = new System.Drawing.Size(97, 50);
					classComponent1.TabIndex = 0;
					classComponent1.Click += new System.EventHandler(_Click);
					classComponent1.lblClassTime.Text = Convert.ToDateTime(dr["dtStartTime"]).ToShortTimeString() + "-" + Convert.ToDateTime(dr["dtEndTime"]).ToShortTimeString();
					classComponent1.lblClassName.Text = dr["strClassCode"].ToString();
					classComponent1.lblClassInstructor.Text = getInstructorName(Convert.ToInt32(dr["nInstructorID"]));
					classComponent1.lblClassHall.Text = "Hall " + dr["nHallNo"].ToString();
					nSun = nSun + 50;
					classComponent1.Day = Convert.ToInt32(dr["nDay"]);
					classComponent1.StartTime = dr["dtStartTime"].ToString();
					classComponent1.Branch = comboBoxBranch.EditValue.ToString();
		
				}

			}
			this.ResumeLayout();
		}
		private void comboBoxBranch_SelectedValueChanged(object sender, System.EventArgs e)
		{
			scheduleRefresh();
		}
		private void btnRefreshClassSchedule_Click(object sender, System.EventArgs e)
		{
			scheduleRefresh();
		}
		private void capturescreen()
		{
			
			Graphics mygraphics = ActiveForm.CreateGraphics();
			Size s = Size;
			memoryImage = new Bitmap(s.Width,s.Height,mygraphics);
			Graphics memoryGraphics = Graphics.FromImage(memoryImage);
			IntPtr dc1 = mygraphics.GetHdc();
			IntPtr dc2 = memoryGraphics.GetHdc();

			BitBlt(dc2, 0, 0, ClientRectangle.Width,ClientRectangle.Height, dc1, 0, 0, 13369376);
			mygraphics.ReleaseHdc(dc1);
			memoryGraphics.ReleaseHdc(dc2);
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			e.Graphics.DrawImage(memoryImage,0,0,1100,800);

		}

		#region Member card 
		/*
			private void MemberCardInit()
			{
				//Member Card
				string strSQL = "select tblCardRequest.*,strMemberName from tblCardRequest Inner Join tblMember On TblMember.strMembershipID = tblCardRequest.strMembershipID";
				DataSet _ds = new DataSet();
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
				gridControlMemberCard.DataSource = _ds.Tables["table"];

			}


			private void btnMemberCardTransfer_Click(object sender, System.EventArgs e)
			{
				ACMSManager.frmMemberCard myMemberCard = new ACMSManager.frmMemberCard();
				myMemberCard.Show();
			}

		
			private void btnMemberCard_Print_Click(object sender, System.EventArgs e)
			{
			
				if (gridViewMemberCard.SelectedRowsCount != 0)
				{
					openFileDialog1.ShowDialog();
					string s = openFileDialog1.FileName;

					OleDbConnection aConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + s);
					OleDbCommand aCommand = new OleDbCommand("Insert Into tblMemberCard(Membership_ID,Member_Name,Branch_ID) values (@Membership_ID,@Member_Name,@Branch_ID)", aConnection);
					aCommand.Connection = aConnection;
					aConnection.Open();
					DataRow row = gridViewMemberCard.GetDataRow(gridViewMemberCard.FocusedRowHandle);

					string MembershipId;
					string MembershipName;
					string BranchId;

					for(int i=0;i<gridViewMemberCard.SelectedRowsCount;i++)
					{
						row = gridViewMemberCard.GetDataRow(gridViewMemberCard.GetRowHandle(i));
						MembershipId = (row["strMembershipId"]).ToString();
						MembershipName = (row["strMemberName"]).ToString();
						BranchId = (row["strBranchCode"]).ToString();
						aCommand.Parameters.Add(new OleDbParameter("@Membership_ID",MembershipId));
						aCommand.Parameters.Add(new OleDbParameter("@Member_Name",MembershipName));
						aCommand.Parameters.Add(new OleDbParameter("@Branch_ID",BranchId));
						 aCommand.ExecuteNonQuery();
						aCommand.Parameters.Clear();
				


						int output;
						output = 0;

						SqlHelper.ExecuteNonQuery(connection,"up_tblCardRequest",
							new SqlParameter("@retval",output),
							new SqlParameter("@nStatusID",1 ),
							new SqlParameter("@dtLastEditDate",DateTime.Now ),
							new SqlParameter("@nEmployeeID",((row["nEmployeeID"]).ToString()) == "" ? DBNull.Value.ToString() : (row["nEmployeeID"]).ToString()),
							new SqlParameter("@nRequestID",(row["nRequestID"]).ToString() )
							);
						//	cmdToExecute.Parameters.Add(new SqlParameter("@" + column[i], (value[i]==null) ? DBNull.Value : value[i])); 

						SqlHelper.ExecuteNonQuery(connection,"up_tblMember",
							new SqlParameter("@retval",output),
							new SqlParameter("@nCardStatusID",1 ),
							new SqlParameter("@strCardBranchCode", "HQ" ),
							new SqlParameter("@strMembershipID",MembershipId )
							);

			

					}
					MessageBox.Show("Print Successfully!","Print Message");
					LoadMemberCard();
					aConnection.Close();
				}
				else
				{
					MessageBox.Show("Please select at least one member!","Print Message");
				}

			}

			private void btnMemberCard_Transfer_Click(object sender, System.EventArgs e)
			{
				if (memoEdit1.Text != "")
				{
					string Splitter = memoEdit1.Text.Replace("\r\n","/");
			
					string[]s = new string[4];

					s = Splitter.Split(new char[] {'/'});
			
					for(int x = 0; x < s.Length; x++)
					{
						int output;
						output = 0;
						SqlHelper.ExecuteNonQuery(connection,"up_tblStatusCardRequest",
							new SqlParameter("@retval",output),
							new SqlParameter("@nStatusID",3 ),
							new SqlParameter("@strMembershipID",s[x] )
							);
				
						SqlHelper.ExecuteNonQuery(connection,"up_tblMemberCardRequest",
							new SqlParameter("@retval",output),
							new SqlParameter("@nCardStatusID",3 ),
							new SqlParameter("@strMembershipID",s[x] )
							);	
					}
					LoadMemberCard();
				{MessageBox.Show("Update Successfully","Transfer Status");}
				}
				else
				{MessageBox.Show("Please enter at least one member Id","Transfer Status");}


			}

			private void btnMemberCard_Reprint_Click(object sender, System.EventArgs e)
			{
				if (gridViewMemberCard.SelectedRowsCount != 0)
				{
					openFileDialog1.ShowDialog();
					string s = openFileDialog1.FileName;

					OleDbConnection aConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + s);
					OleDbCommand aCommand = new OleDbCommand("Insert Into tblMemberCard(Membership_ID,Member_Name,Branch_ID) values (@Membership_ID,@Member_Name,@Branch_ID)", aConnection);
					aCommand.Connection = aConnection;
					aConnection.Open();
					DataRow row = gridViewMemberCard.GetDataRow(gridViewMemberCard.FocusedRowHandle);

					string MembershipId;
					string MembershipName;
					string BranchId;

					for(int i=0;i<gridViewMemberCard.SelectedRowsCount;i++)
					{
						row = gridViewMemberCard.GetDataRow(gridViewMemberCard.GetRowHandle(i));
						MembershipId = (row["strMembershipId"]).ToString();
						MembershipName = (row["strMemberName"]).ToString();
						BranchId = (row["strBranchCode"]).ToString();
						aCommand.Parameters.Add(new OleDbParameter("@Membership_ID",MembershipId));
						aCommand.Parameters.Add(new OleDbParameter("@Member_Name",MembershipName));
						aCommand.Parameters.Add(new OleDbParameter("@Branch_ID",BranchId));
						aCommand.ExecuteNonQuery();
						aCommand.Parameters.Clear();
				


						int output;
						output = 0;

						SqlHelper.ExecuteNonQuery(connection,"up_tblCardRequest",
							new SqlParameter("@retval",output),
							new SqlParameter("@nStatusID",1 ),
							new SqlParameter("@dtLastEditDate",DateTime.Now ),
							new SqlParameter("@nEmployeeID",((row["nEmployeeID"]).ToString()) == "" ? DBNull.Value.ToString() : (row["nEmployeeID"]).ToString()),
							new SqlParameter("@nRequestID",(row["nRequestID"]).ToString() )
							);
						//	cmdToExecute.Parameters.Add(new SqlParameter("@" + column[i], (value[i]==null) ? DBNull.Value : value[i])); 

						SqlHelper.ExecuteNonQuery(connection,"up_tblMember",
							new SqlParameter("@retval",output),
							new SqlParameter("@nCardStatusID",1 ),
							new SqlParameter("@strCardBranchCode", "HQ" ),
							new SqlParameter("@strMembershipID",MembershipId )
							);

			

					}
				
				LoadMemberCard();
				{MessageBox.Show("Reprint successfully!","Reprint Status");}
					aConnection.Close();
				}
				else
				{
		
					MessageBox.Show("Please select at least one member!","Reprint Status");

				}
			}

			private void mcard_cbNStatusID_SelectedValueChanged(object sender, System.EventArgs e)
			{
				LoadMemberCard();
			}
			private void LoadMemberCard()
			{
				RefreshMemberCard();
				string strSQL;
				if (mcard_cbNStatusID.SelectedIndex != -1)
				{
					strSQL = "select tblCardRequest.*,strMemberName from tblCardRequest Inner Join tblMember On TblMember.strMembershipID = tblCardRequest.strMembershipID Where tblCardRequest.nStatusId = " + mcard_cbNStatusID.EditValue.ToString();
				
				
				}
				else
				{
					strSQL = "select tblCardRequest.*,strMemberName from tblCardRequest Inner Join tblMember On TblMember.strMembershipID = tblCardRequest.strMembershipID";
				}
				//Member Card

			
				DataSet _ds = new DataSet();
				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
				gridControlMemberCard.DataSource = _ds.Tables["table"];
					
				MemberId.DataBindings.Add(new Binding("EditValue", _ds.Tables["table"], "strMembershipId"));
				Status.DataBindings.Add(new Binding("EditValue", _ds.Tables["table"], "nStatusId"));
	

			}
			private void RefreshMemberCard()
			{
				gridControlMemberCard.DataBindings.Clear();
						
				UI.ClearDataBinding(grpMemberCardBelow3.Controls);
				MemberId.Text = "";
				Status.EditValue = "";			
			}

			private void btnMemberCard_Update_Click(object sender, System.EventArgs e)
			{
				if (MemberId.Text != "")
				{
					int output;
					output = 0;
					DataRow row = gridViewMemberCard.GetDataRow(gridViewMemberCard.FocusedRowHandle);
			
					SqlHelper.ExecuteNonQuery(connection,"up_tblStatusCardRequest",
						new SqlParameter("@retval",output),
						new SqlParameter("@nStatusID",Status.EditValue.ToString() ),
						new SqlParameter("@nRequestID",(row["strMembershipID"]).ToString() )
						);
					LoadMemberCard();
				{MessageBox.Show("Update Successfully","Update");}
				}
			}
	*/
		#endregion


		#endregion

		#region ** Master Data **
		private void mdInit()
		{
			frmBank = new ACMS.ACMSManager.MasterData.frmBank();
			frmComp = new ACMS.ACMSManager.MasterData.frmCompany();
			frmBranch = new ACMS.ACMSManager.MasterData.frmBranch();
			frmCommission = new ACMS.ACMSManager.MasterData.frmCommission();
			frmPackage = new ACMS.ACMSManager.MasterData.frmPackage();
			frmPromotion = new ACMS.ACMSManager.MasterData.frmPromotion();
			frmEmployee = new ACMS.ACMSManager.MasterData.frmEmployee(this.employee.Id.ToString());
			frmDepartment = new ACMS.ACMSManager.MasterData.frmDepartment();
			frmService = new ACMS.ACMSManager.MasterData.frmService();
			frmLeave = new ACMS.ACMSManager.MasterData.frmLeave();
			frmUserRights = new ACMS.ACMSManager.MasterData.frmUserRights();
			frmClass = new ACMS.ACMSManager.MasterData.frmClass();
			frmPromotionItem = new ACMS.ACMSManager.MasterData.frmPromotionItem();
			frmReward = new ACMS.ACMSManager.MasterData.frmReward();
			frmInventory = new ACMS.ACMSManager.MasterData.frmInventory();
			frmTerminalUser = new ACMS.ACMSManager.MasterData.frmTerminalUser();


			panel1.Controls.Clear();
			frmComp.TopLevel = false;
			frmComp.Dock = DockStyle.Fill;
			frmComp.Parent = panel1;
			frmComp.Show();
			panel1.Refresh();

		}

		private void mnuMdBank()
		{
			if(!frmBank.IsDisposed)
			{
				frmBank.Dispose();
			}
			
			frmBank = new ACMS.ACMSManager.MasterData.frmBank();
			panel1.Controls.Clear();
			frmBank.TopLevel = false;
			frmBank.Dock = DockStyle.Fill;
			frmBank.Parent = panel1;
			frmBank.Show();
			panel1.Refresh();

		}


		private void mnuMdLeave()
		{
			if(!frmLeave.IsDisposed)
			{
				frmLeave.Dispose();
			}
			
			frmLeave = new ACMS.ACMSManager.MasterData.frmLeave();
			panel1.Controls.Clear();
			frmLeave.TopLevel = false;
			frmLeave.Dock = DockStyle.Fill;
			frmLeave.Parent = panel1;
			frmLeave.Show();
			panel1.Refresh();

		}

		private void mnuMdService()
		{
			if(!frmService.IsDisposed)
			{
				frmService.Dispose();
			}
			
			frmService = new ACMS.ACMSManager.MasterData.frmService();
			panel1.Controls.Clear();
			frmService.TopLevel = false;
			frmService.Dock = DockStyle.Fill;
			frmService.Parent = panel1;
			frmService.Show();
			panel1.Refresh();

		}

		private void mnuMdUserRight()
		{
			if(!frmUserRights.IsDisposed)
			{
				frmUserRights.Dispose();
			}
			
			frmUserRights = new ACMS.ACMSManager.MasterData.frmUserRights();
			panel1.Controls.Clear();
			frmUserRights.TopLevel = false;
			frmUserRights.Dock = DockStyle.Fill;
			frmUserRights.Parent = panel1;
			frmUserRights.Show();
			panel1.Refresh();
		}

		private void mnuMdClass()
		{
			if(!frmClass.IsDisposed)
			{
				frmClass.Dispose();
			}
			
			frmClass = new ACMS.ACMSManager.MasterData.frmClass();
			panel1.Controls.Clear();
			frmClass.TopLevel = false;
			frmClass.Dock = DockStyle.Fill;
			frmClass.Parent = panel1;
			frmClass.Show();
			panel1.Refresh();

		}

		private void mnuMdEmployee()
		{
			if(!frmEmployee.IsDisposed)
			{
				frmEmployee.Dispose();
			}
			
			frmEmployee = new ACMS.ACMSManager.MasterData.frmEmployee(this.employee.Id.ToString());
			panel1.Controls.Clear();
			frmEmployee.TopLevel = false;
			frmEmployee.Dock = DockStyle.Fill;
			frmEmployee.Parent = panel1;
			frmEmployee.Show();
			panel1.Refresh();
		}

		private void mnuMdPromotion()
		{
			if(!frmPromotion.IsDisposed)
			{
				frmPromotion.Dispose();
			}
			
			frmPromotion = new ACMS.ACMSManager.MasterData.frmPromotion();
			panel1.Controls.Clear();
			frmPromotion.TopLevel = false;
			frmPromotion.Dock = DockStyle.Fill;
			frmPromotion.Parent = panel1;
			frmPromotion.Show();
			panel1.Refresh();
		}


		private void mnuMdItemPromotion()
		{
			if(!frmPromotionItem.IsDisposed)
			{
				frmPromotionItem.Dispose();
			}
			
			frmPromotionItem = new ACMS.ACMSManager.MasterData.frmPromotionItem();
			panel1.Controls.Clear();
			frmPromotionItem.TopLevel = false;
			frmPromotionItem.Dock = DockStyle.Fill;
			frmPromotionItem.Parent = panel1;
			frmPromotionItem.Show();
			panel1.Refresh();
		}

		
		private void mnuMdPackage()
		{
			if(!frmPackage.IsDisposed)
			{
				frmPackage.Dispose();
			}
			
			frmPackage = new ACMS.ACMSManager.MasterData.frmPackage();
			panel1.Controls.Clear();
			frmPackage.TopLevel = false;
			frmPackage.Dock = DockStyle.Fill;
			frmPackage.Parent = panel1;
			frmPackage.Show();
			panel1.Refresh();
		}

		private void mnuMdCommission()
		{	
			if(!frmCommission.IsDisposed)
			{
				frmCommission.Dispose();
			}

			frmCommission.initData(oUser);
			frmCommission.SetEmployeeRecord(employee);
			frmCommission.SetTerminalUser(terminalUser);
			frmCommission = new ACMS.ACMSManager.MasterData.frmCommission();
			panel1.Controls.Clear();
			frmCommission.TopLevel = false;
			frmCommission.Dock = DockStyle.Fill;
			frmCommission.Parent = panel1;
			frmCommission.Show();
			panel1.Refresh();
		}

		private void mnuMdBranch()
		{
			if(!frmBranch.IsDisposed)
			{
				frmBranch.Dispose();
			}

			ACMSLogic.User.BranchCode = terminalUser.Branch.Id;
			ACMSLogic.User.EmployeeID = employee.Id;
			if (employee.Department != null)
				ACMSLogic.User.DepartmentID = employee.Department.Id;
			if (employee.StrEmployeeName != null)
				ACMSLogic.User.EmployeeName = employee.StrEmployeeName;
			if (employee.JobPosition.Id != null)
				ACMSLogic.User.JobPositionCode = employee.JobPosition.Id;
			if (employee.RightsLevel != null)
				ACMSLogic.User.RightsLevelID = employee.RightsLevel.Id;

			ACMSLogic.User oUser = new User();
					
			frmBranch = new ACMS.ACMSManager.MasterData.frmBranch();
			panel1.Controls.Clear();
			frmBranch.TopLevel = false;
			frmBranch.Dock = DockStyle.Fill;
			frmBranch.Parent = panel1;
			frmBranch.Show();
			panel1.Refresh();
		}

		private void mnuMdCompany()
		{
			if (!frmComp.IsDisposed)
			{
				frmComp.Close();
			}
			panel1.Controls.Clear();
			frmComp = new ACMS.ACMSManager.MasterData.frmCompany();
			frmComp.TopLevel = false;
			frmComp.Dock = DockStyle.Fill;
			frmComp.Parent = panel1;
			frmComp.Show();
			panel1.Refresh();
		
		}

		private void mnuMdDepartment()
		{
			if (!frmDepartment.IsDisposed)
			{
				frmDepartment.Close();
			}
			panel1.Controls.Clear();
			frmDepartment = new ACMS.ACMSManager.MasterData.frmDepartment();
			frmDepartment.TopLevel = false;
			frmDepartment.Dock = DockStyle.Fill;
			frmDepartment.Parent = panel1;
			frmDepartment.Show();
			panel1.Refresh();
		}

		private void mnuMdTerminalUser()
		{
			if(!frmTerminalUser.IsDisposed)
			{
				frmTerminalUser.Dispose();
			}
			
			frmTerminalUser = new ACMS.ACMSManager.MasterData.frmTerminalUser();
			panel1.Controls.Clear();
			frmTerminalUser.TopLevel = false;
			frmTerminalUser.Dock = DockStyle.Fill;
			frmTerminalUser.Parent = panel1;
			frmTerminalUser.Show();
			panel1.Refresh();
		}

		private void mnuMdInventory()
		{
		
			if(!frmInventory.IsDisposed)
			{
				frmInventory.Dispose();
			}
			
			frmInventory = new ACMS.ACMSManager.MasterData.frmInventory();
			panel1.Controls.Clear();
			frmInventory.TopLevel = false;
			frmInventory.Dock = DockStyle.Fill;
			frmInventory.Parent = panel1;
			frmInventory.Show();
			panel1.Refresh();
		}


		private void mnuMdReward()
		{
			if(!frmReward.IsDisposed)
			{
				frmReward.Dispose();
			}
			
			frmReward = new ACMS.ACMSManager.MasterData.frmReward();
			panel1.Controls.Clear();
			frmReward.TopLevel = false;
			frmReward.Dock = DockStyle.Fill;
			frmReward.Parent = panel1;
			frmReward.Show();
			panel1.Refresh();

		}

		private void lk_MasterData_EditValueChanged(object sender, System.EventArgs e)
		{
			switch(lk_MasterData.EditValue.ToString().Trim())
			{
				case "Bank":
					mnuMdBank();
					break;
				case "Promotion":
					mnuMdPromotion();
					break;
				case "Promotion Item":
					mnuMdItemPromotion();
					break;
				case "Package":
					mnuMdPackage();
					break;
				case "Inventory":
					mnuMdInventory();
					break;
				case "Reward":
					mnuMdReward();
					break;
				case "Leave":
					mnuMdLeave();
					break;
				case "Class":
					mnuMdClass();
					break;
				case "Commission":
					mnuMdCommission();
					break;
				case "Department":
					mnuMdDepartment();
					break;
				case "Company":
					mnuMdCompany();
					break;
				case "UserRight":
					mnuMdUserRight();
					break;
				case "Service":
					mnuMdService();
					break;
				case "Terminal User":
					mnuMdTerminalUser();
					break;
				case "Employee":
					mnuMdEmployee();
					break;
				case "Branch":
					mnuMdBranch();
					break;

			}
		}
	

		#endregion	

		#region ** Exit to Branch **
		private void bbiManagerBranch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			// Modified By Matt
			ACMSLogic.Login.Login login = new ACMSLogic.Login.Login();
			System.Security.Principal.WindowsIdentity userLogin = System.Security.Principal.WindowsIdentity.GetCurrent();
			
			Acms.Core.Domain.TerminalUser tu = login.GetTerminalUserByUserId(userLogin.Name) as Acms.Core.Domain.TerminalUser;
			//Acms.Core.Domain.TerminalUser tu = tup.GetTerminalUserByUserId(userLogin.Name) as Acms.Core.Domain.TerminalUser;

			//Show AMCS Branch
			if(employee.CanAccess("AB_LOGIN",tu.Branch.Id))
			{
				if (modInitForms.fBranch == null)
				{
							
					ACMSLogic.User.BranchCode = tu.Branch.Id;
					ACMSLogic.User.EmployeeID = employee.Id;
					if (employee.Department != null)
						ACMSLogic.User.DepartmentID = employee.Department.Id;
					if (employee.StrEmployeeName != null)
						ACMSLogic.User.EmployeeName = employee.StrEmployeeName;
					if (employee.JobPosition.Id != null)
						ACMSLogic.User.JobPositionCode = employee.JobPosition.Id;
					if (employee.RightsLevel != null)
						ACMSLogic.User.RightsLevelID = employee.RightsLevel.Id;
							
					ClassAttendance.CreateClassInstance();
					PackageCode.CreateUnLinkPackage();
					ACMSLogic.User oUser = new User();
					modInitForms.fBranch = new frmBranch("EN");
					modInitForms.fBranch.SetEmployeeRecord(employee);
					modInitForms.fBranch.SetTerminalUser(tu);
					modInitForms.fBranch.initData(oUser);
					modInitForms.fBranch.Show();
				}
				modInitForms.fLogin.Hide();
			}

		}

		#endregion

		#region ** bar **
		private void bbiManagerLoginOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			this.Dispose(true);
		}

		private void barbtnTimeCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			frmTimeCard myFormTimeCard = new frmTimeCard(terminalUser.Branch.Id);
			myFormTimeCard.ShowDialog();
			myFormTimeCard.Dispose();
		}
		
		#endregion

		#region ** payroll **
		private bool isFinishedPayrollInit = false;
		private DataTable dtPayroll;
		private DataView dvPayroll;
		private ACMS.ACMSManager.Payroll.frmCommissionDetails frmCommDetl = new ACMS.ACMSManager.Payroll.frmCommissionDetails();
	
		private void Init_Payroll_cmbJob()
		{
			string	strSQL = "select * from tblJobPosition";
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			comboBind(cbJob,strSQL,"strDescription","strJobPositionCode");
			cbJob.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem("- View All -","ALL",-1));
			cbJob.SelectedIndex = 0 ; 
		}
		
		private void gridViewPayroll_Click(object sender, System.EventArgs e)
		{
			string strSQL;
			DataSet _ds;
			DataRow dr = gridViewPayroll.GetDataRow(gridViewPayroll.FocusedRowHandle);
			if ( dr!= null)
			{
				//mServiceReimbursements
				if( gridViewPayroll.FocusedColumn.Name=="mServiceReimbursements")
				{
					strSQL="select * from sv_Payr_ServiceReimbursement_Detl where (nStandinInstructorID='" + Convert.ToInt32(dr["nEmployeeID"]) + "' or nActualInstructorID='" + Convert.ToInt32(dr["nEmployeeID"]) + "') and pYear='" + comboBoxEditYR.EditValue + "' and pMonth='" + comboBoxEditMTH.EditValue + "'";
					_ds = new DataSet();
					SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
					ACMS.ACMSManager.Payroll.frmServiceReimbursement frmSrvcReimbursement = new ACMS.ACMSManager.Payroll.frmServiceReimbursement(ACMS.Convert.ToInt32(dr["nEmployeeID"]),Convert.ToInt32(dr["nPayrollID"]));
					frmSrvcReimbursement.dtServiceReim = _ds.Tables["table"];
					frmSrvcReimbursement.ShowDialog();
					InitPayroll(0);
				}

				if( gridViewPayroll.FocusedColumn.Name=="mCommission")
				{
					//PT Service Commission
					strSQL = "select * from tblPayrollPTServiceCommDetails where nPayrollID='" + Convert.ToInt32(dr["nPayrollID"]) + "' and nEmployeeID=" + Convert.ToInt32(dr["nEmployeeID"]) + "";
					_ds = new DataSet();

					SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
					frmCommDetl.dtPTServiceComm = _ds.Tables["table"];    

					// SPA Service Commission     
					strSQL = "select * from tblPayrollSpaServiceCommDetails where nPayrollID='" + Convert.ToInt32(dr["nPayrollID"]) + "' and nEmployeeID=" + Convert.ToInt32(dr["nEmployeeID"]) + "";
					_ds = new DataSet();

					SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
					frmCommDetl.dtSPAServiceComm = _ds.Tables["table"];

					// SPA Service Commission     
					strSQL = "select * from tblPayrollSalesCommDetails where nPayrollID='" + Convert.ToInt32(dr["nPayrollID"]) + "' and nEmployeeID=" + Convert.ToInt32(dr["nEmployeeID"]) + "";
					_ds = new DataSet();

					SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
					frmCommDetl.dtSalesComm = _ds.Tables["table"];
					frmCommDetl.ShowDialog();
					InitPayroll(2);

				}
			}
		}

		private void InitPayroll(int status)//status: 1=First Run , 2=Second Run
		{
			string strSQL;
					
			if (status==1)
			{
				gridViewPayroll.Columns[0].Visible = true;
				gridViewPayroll.Columns[1].Visible = true;
				gridViewPayroll.Columns[2].Visible = true;
				gridViewPayroll.Columns[3].Visible = true;
				gridViewPayroll.Columns[4].Visible = false;
				gridViewPayroll.Columns[5].Visible = true;
				gridViewPayroll.Columns[6].Visible = true;
				gridViewPayroll.Columns[7].Visible = true;
				gridViewPayroll.Columns[8].Visible = true;
				gridViewPayroll.Columns[9].Visible = true;
				gridViewPayroll.Columns[10].Visible = true;
				gridViewPayroll.Columns[11].Visible = true;
				gridViewPayroll.Columns[12].Visible = true;
				gridViewPayroll.Columns[13].Visible = true;
				gridViewPayroll.Columns[14].Visible = true;
				gridViewPayroll.Columns[15].Visible = true;
				gridViewPayroll.Columns[16].Visible = false;
				gridViewPayroll.Columns[17].Visible = false;
				gridViewPayroll.Columns[18].Visible = false;

				gridViewExcel.Columns[1].Visible = true;
				gridViewExcel.Columns[15].Visible = false;


			}
			else if (status==2)
			{
				gridViewPayroll.Columns[0].Visible = true;
				gridViewPayroll.Columns[1].Visible = true;
				gridViewPayroll.Columns[2].Visible = true;
				gridViewPayroll.Columns[3].Visible = true;
				gridViewPayroll.Columns[4].Visible = false;
				gridViewPayroll.Columns[5].Visible = false;
				gridViewPayroll.Columns[6].Visible = false;
				gridViewPayroll.Columns[7].Visible = false;
				gridViewPayroll.Columns[8].Visible = false;
				gridViewPayroll.Columns[9].Visible = false;
				gridViewPayroll.Columns[10].Visible = false;
				gridViewPayroll.Columns[11].Visible = false;
				gridViewPayroll.Columns[12].Visible = false;
				gridViewPayroll.Columns[13].Visible = false;
				gridViewPayroll.Columns[14].Visible = false;
				gridViewPayroll.Columns[15].Visible = false;
				gridViewPayroll.Columns[16].Visible = true;
				gridViewPayroll.Columns[16].BestFit();
				gridViewPayroll.Columns[17].Visible = true;
				gridViewPayroll.Columns[17].BestFit();
				gridViewPayroll.Columns[18].Visible = false;

				gridViewExcel.Columns[15].Visible = true;
				gridViewExcel.Columns[1].Visible = false;
			}

			try
			{
				if(!isFinishedPayrollInit)
				{	
					if (cbJob.SelectedIndex != 0)
					{
						strSQL = "select A.*,B.*,E.*,J.strDescription as strJobPosition from tblPayroll A join tblPayrollEntries B on A.nPayrollID=B.nPayrollID Inner Join TblEmployee E On E.nEmployeeID = B.nEmployeeID Left Outer Join TblJobPosition J on J.strJobPositionCode=E.strJobPositionCode where E.nStatusID=1 and nYear='" + comboBoxEditYR.Text + "' and nMonth='" + comboBoxEditMTH.Text + "' and E.strJobPositionCode='" + cbJob.EditValue.ToString() + "'";
					}
					else
					{
						strSQL = "select A.*,B.*,E.*,J.strDescription as strJobPosition from tblPayroll A join tblPayrollEntries B on A.nPayrollID=B.nPayrollID Inner Join TblEmployee E On E.nEmployeeID = B.nEmployeeID Left Outer Join TblJobPosition J on J.strJobPositionCode=E.strJobPositionCode where E.nStatusID=1 and nYear='" + comboBoxEditYR.Text + "' and nMonth='" + comboBoxEditMTH.Text + "'";
					}
					
					DataSet _ds = new DataSet();
					SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
					gridPayroll.DataSource = _ds.Tables["table"];
					gridExcel.DataSource = _ds.Tables["table"];
					dtPayroll =  _ds.Tables["table"];
				}
				else
				{
					dvPayroll = new DataView(dtPayroll);
					dvPayroll.RowFilter = "strJobPositionCode='" + cbJob.EditValue.ToString() + "'";
					gridPayroll.DataSource = dvPayroll;
					gridExcel.DataSource = dvPayroll;
					isFinishedPayrollInit = false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btnPayrollExport_Click(object sender, System.EventArgs e)
		{ 
			string strSQL,path;
			DataSet _ds;
			strSQL = "select strPayrollDir from tblCompany";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataRow dr = _ds.Tables["table"].Rows[0];

			if (cmbxPayroll.SelectedIndex.ToString() =="0")
			{
				path = dr["strPayrollDir"].ToString() + "\\FirstRun"+comboBoxEditYR.EditValue.ToString() + comboBoxEditMTH.EditValue.ToString()+".xls";
				if (Directory.Exists(dr["strPayrollDir"].ToString()))
				{
					init_FirstRun();
					gridExcel.MainView.ExportToXls(path);
					MessageBox.Show("File had been exported to " + path);
				}
				else
				{	
					MessageBox.Show("Directory not exist. Please check the payroll directory setting on company master.");
				}
			}//end if

			if (cmbxPayroll.SelectedIndex.ToString() =="1")
			{
				path = dr["strPayrollDir"].ToString() + "\\SecondRun"+comboBoxEditYR.EditValue.ToString() + comboBoxEditMTH.EditValue.ToString()+".xls";
				if (Directory.Exists(dr["strPayrollDir"].ToString()))
				{
					init_SecondRun();
					gridExcel.MainView.ExportToXls(path);
					MessageBox.Show("File had been exported to " + path);
				}
				else
				{	
					MessageBox.Show("Directory not exist. Please check the payroll directory setting on company master.");
				}
			}//end if


		}

		private void init_FirstRun()
		{
			gridColumn24.Visible=true;
			gridColumn25.Visible=true;
			gridColumn26.Visible=true;
			gridColumn27.Visible=true;
			gridColumn28.Visible=true;
			gridColumn29.Visible=true;
			gridColumn30.Visible=true;
			gridColumn31.Visible=true;
			gridColumn32.Visible=true;
			gridColumn33.Visible=true;
			gridColumn34.Visible=true;
			gridColumn35.Visible=false;
			gridColumn36.Visible=false;
		}

		
		private void init_SecondRun()
		{
			gridColumn24.Visible=false;
			gridColumn25.Visible=false;
			gridColumn26.Visible=false;
			gridColumn27.Visible=false;
			gridColumn28.Visible=false;
			gridColumn29.Visible=false;
			gridColumn30.Visible=false;
			gridColumn31.Visible=false;
			gridColumn32.Visible=false;
			gridColumn33.Visible=false;
			gridColumn34.Visible=false;
			gridColumn35.Visible=true;
			gridColumn36.Visible=true;
		}

		private void btnPayrollGenerate_Click(object sender, System.EventArgs e)
		{
			progressBarControl1.Visible = false;
			DateTime today = DateTime.Today.Date;
			string strSQL;
			DataSet _ds;
			int nPayrollID = 0;
			int nFirstRunStaff=0;
			int nSecondRunStaff=0;
			
			//Checking status of first run payroll
			strSQL = "select nPayrollID,nFirstRunStaff,nSecondRunStaff from tblPayroll where nYear=" + Convert.ToInt32(comboBoxEditYR.Text) + " and nMonth=" + Convert.ToInt32(comboBoxEditMTH.Text);
			_ds = new DataSet();

			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			
			if( _ds.Tables["table"].Rows.Count>0)
			{					
				foreach( DataRow dr in _ds.Tables["table"].Rows )
				{
					nPayrollID =ACMS.Convert.ToInt32(dr[0]);
					nFirstRunStaff=ACMS.Convert.ToInt32(dr[1]);
					nSecondRunStaff=ACMS.Convert.ToInt32(dr[2]);
				}
					#region Frist
				if (cmbxPayroll.Text=="First Run" && nFirstRunStaff>0)					
				{
					DialogResult result1 = MessageBox.Show(this, "Would you like to recompute payroll for Year " + comboBoxEditYR.Text + " Month " + comboBoxEditMTH.Text + " ?",
						"Re-compute Payroll?", MessageBoxButtons.YesNo);
							
					if (result1 == DialogResult.Yes)
					{
						try
						{
							regen_Payroll();
							strSQL = "Delete tblPayrollEntries where nPayrollID in (select nPayrollID from tblPayroll where nYear=" + Convert.ToInt32(comboBoxEditYR.EditValue) + " and nMonth=" + Convert.ToInt32(comboBoxEditMTH.EditValue) + ")";
							_ds = new DataSet();
							SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );

							strSQL = "Delete tblPayroll where nYear=" + Convert.ToInt32(comboBoxEditYR.EditValue) + " and nMonth=" + Convert.ToInt32(comboBoxEditMTH.EditValue);
							_ds = new DataSet();
							SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
							gen_FirstRun(nPayrollID);
							return;
						}//end 2nd run
						
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message);
						}
					}
					else if (result1 == DialogResult.No)
					{
						return;
					}
	
				}
					#endregion 

					#region Second

				else if (cmbxPayroll.Text=="Second Run" && nSecondRunStaff>0)					
				{
					DialogResult result2 = MessageBox.Show(this, "Would you like to recompute payroll for Year " + comboBoxEditYR.Text + " Month " + comboBoxEditMTH.Text + " ?",
						"Re-compute Payroll?", MessageBoxButtons.YesNo);
							
					if (result2 == DialogResult.Yes)
					{		
						try
						{
							regen_Payroll();
							strSQL = "Update tblPayrollEntries Set mCommission=0.00, mCommissionLatenessPenalty=0.00 where nPayrollID=(select nPayrollID from tblPayroll where nYear=" + Convert.ToInt32(comboBoxEditYR.EditValue) + " and nMonth=" + Convert.ToInt32(comboBoxEditMTH.EditValue) + ")";
							_ds = new DataSet();
							SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );

							strSQL = "Update tblPayroll Set dtSecondRunDate=null,nSecondRunStaff=null where nYear=" + Convert.ToInt32(comboBoxEditYR.EditValue) + " and nMonth=" + Convert.ToInt32(comboBoxEditMTH.EditValue);
							_ds = new DataSet();
							SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			
							gen_SecondRun(nPayrollID);
							return;
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message);
						}
					}
					else if (result2 == DialogResult.No)
					{
						return;
					}
				}
					#endregion
				else if (cmbxPayroll.Text=="Second Run" && nSecondRunStaff==0)					
				{
					gen_SecondRun(nPayrollID);
					return;
					
				}

				}
				gen_newPayroll();
			}
			
		
		private void gen_newPayroll()
		{
			string strSQL;
			DataSet _ds;
			int nPayrollID = 0;
			
			strSQL = "select max(nPayrollID)+1 from tblPayroll";
			_ds = new DataSet();

			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
	
			if( _ds.Tables["table"].Rows.Count>0)
			{					
				foreach( DataRow dr in _ds.Tables["table"].Rows )
				{
					nPayrollID =ACMS.Convert.ToInt32(dr[0]);
				}

				if (cmbxPayroll.Text=="First Run")
				{
					gen_FirstRun(nPayrollID);
					return;
				}

				else if(cmbxPayroll.Text=="Second Run")
				{
					gen_SecondRun(nPayrollID);	
					return;
				}
				
			}

		}
	
		private void regen_Payroll()
		{
			string strSQL;
			DataSet _ds;

			strSQL = "Delete tblPayrollPTServiceCommDetails where nPayrollID in (select nPayrollID from tblPayroll where nYear=" + Convert.ToInt32(comboBoxEditYR.EditValue) + " and nMonth=" + Convert.ToInt32(comboBoxEditMTH.EditValue) + ")";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
								
			strSQL = "Delete tblPayrollSPAServiceCommDetails where nPayrollID in (select nPayrollID from tblPayroll where nYear=" + Convert.ToInt32(comboBoxEditYR.EditValue) + " and nMonth=" + Convert.ToInt32(comboBoxEditMTH.EditValue) + ")";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );

			strSQL = "Delete tblPayrollSalesCommDetails where nPayrollID in (select nPayrollID from tblPayroll where nYear=" + Convert.ToInt32(comboBoxEditYR.EditValue) + " and nMonth=" + Convert.ToInt32(comboBoxEditMTH.EditValue) + ")";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );

		}

		private void gen_FirstRun(int nPayrollID)
		{
			//init Function
			string strSQL;
			DataSet _ds;
			int output;

				try
		 {
			 //Checking status of second run payroll
					
			 output = 0;
					
			 SqlHelper.ExecuteNonQuery(connection,"UP_tblPayroll",
				 new SqlParameter("@RET_VAL",output),
				 new SqlParameter("@CMD","I"),
				 new SqlParameter("@nPayrollID",nPayrollID),
				 new SqlParameter("@nMonth",Convert.ToInt32(comboBoxEditMTH.Text)),
				 new SqlParameter("@nYear",Convert.ToInt32(comboBoxEditYR.Text)),
				 new SqlParameter("@dtFirstRunDate",DateTime.Now.ToShortDateString()),
				 new SqlParameter("@nFirstRunStaff",employee.Id.ToString()),
				 new SqlParameter("@dtSecondRunDate",null),
				 new SqlParameter("@nSecondRunStaff",null)
				 );

					
			 if (cbJob.SelectedIndex != 0)
			 {
				 strSQL = "select nEmployeeID,fPartTime,strBranchCode from tblEmployee where nStatusID=1 and strJobPositionCode='" + cbJob.EditValue.ToString() + "'";
			 }
			 else
			 {
				 strSQL = "select nEmployeeID,fPartTime,strBranchCode from tblEmployee where nStatusID=1 ";

			 }
			 _ds = new DataSet();
			 SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
					
			 progressBarControl1.Properties.Minimum = 0;
			 progressBarControl1.Properties.Maximum = _ds.Tables["table"].Rows.Count;
			 progressBarControl1.Properties.Step = 1;
			 progressBarControl1.Visible = true;

			 foreach( DataRow dr in _ds.Tables["table"].Rows )
			 {
				 Lateness myLateness = new Lateness();
				 myLateness.GetLateness(Convert.ToInt32(dr[0]), (Month)comboBoxEditMTH.SelectedIndex, 
					 Convert.ToInt32(comboBoxEditYR.EditValue));
				 decimal totalLateness = 0;
				 foreach (DataRow row in myLateness.LatenessTable.Rows)
				 {
					 totalLateness += Convert.ToDecimal(row["nLateness"]);
				 }
						
				 SqlHelper.ExecuteNonQuery(connection,"UP_CALC_PAYROLL",
					 new SqlParameter("@RET_VAL",output),
					 new SqlParameter("@nPayrollID",nPayrollID),
					 new SqlParameter("@nEmployeeID",dr[0]),
					 new SqlParameter("@fparttime",dr[1]),
					 new SqlParameter("@nYear",Convert.ToInt32(comboBoxEditYR.Text)),
					 new SqlParameter("@nMonth",Convert.ToInt32(comboBoxEditMTH.Text)),
					 new SqlParameter("@TotalLateness", totalLateness)

					 );
				 progressBarControl1.PerformStep();
				 progressBarControl1.Update();
						
			 }
			 progressBarControl1.Visible = false;
			 InitPayroll(1);

		 }
		 catch (Exception ex)
		 {
			 MessageBox.Show(ex.Message);
		 }
		}

		private void gen_SecondRun(int nPayrollID)
		{
			//init Function
			string strSQL;
			DataSet _ds;
			int output;
			DataRow[] DrMSEList;
			DataRow[] DrSPACList;
			DataRow[] DrThepList;
			DataRow[] DrPTList;
			DataRow[] DrBMList;
			DataRow[] DrABMList;

			try
			{//Checking status of second run payroll
				
				if (cbJob.SelectedIndex != 0)
				{
					strSQL = "select nEmployeeID,fPartTime,strBranchCode,strJobPositionCode from tblEmployee where nStatusID=1 and strJobPositionCode='" + cbJob.EditValue.ToString() + "'";
				}
					else
					{
						strSQL = "select nEmployeeID,fPartTime,strBranchCode,strJobPositionCode,fPtInstructor,fSpaConsult,fTherapist,fMSE from tblEmployee where nStatusID=1 ";
					}

				_ds = new DataSet();

				SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );

				//Init Payroll 2nd Run
				progressBarControl1.Properties.Minimum = 0;
				progressBarControl1.Properties.Maximum = _ds.Tables["table"].Rows.Count;
				progressBarControl1.Properties.Step = 1;
				progressBarControl1.Visible = true;

				DrMSEList = _ds.Tables["table"].Select("fMSE = true");
				foreach( DataRow dr in DrMSEList )
				{
					try
					{
						/// 3. MSE COMMISSION
						CommissionSpaService comm3 = new CommissionSpaService();
						comm3.CalculateSpaServiceCommission(ConvertToInt(dr[0]),System.Convert.ToString(dr[2]),(ACMSLogic.Staff.Month)(ConvertToInt(comboBoxEditMTH.SelectedIndex)),ConvertToInt(comboBoxEditYR.Text),true);

						// To Generate Spa Service Comm Detais
						// To Generate Commission Details and store to table tblPayrollPTServiceCommDetails
						output = 0;
						if (comm3.MSECommDetail.Rows.Count>0)
						{
							foreach (DataRow drMSE in comm3.MSECommDetail.Rows)
							{
								SqlHelper.ExecuteNonQuery(connection,"UP_tblPayrollEntries_SecondRun",
									new SqlParameter("@RET_VAL",output),
									new SqlParameter("@CMD","U"),
									new SqlParameter("@nPayrollID",nPayrollID),
									new SqlParameter("@nEmployeeID",Convert.ToInt32(drMSE[0])),
									new SqlParameter("@mCommission",Convert.ToDecimal(drMSE[1])),
									//	new SqlParameter("@mCommissionLatenessPenalty",CommissionPenalty * 2),
									new SqlParameter("@dtSecondRunDate",DateTime.Now.ToShortDateString()),
									new SqlParameter("@nSecondRunStaff",employee.Id.ToString())	);
						
							}
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(dr[0].ToString()+ " "+ex.Message);
					}
				}

//					output = 0;
//					SqlHelper.ExecuteNonQuery(connection,"UP_tblPayrollEntries_SecondRun",
//						new SqlParameter("@RET_VAL",output),
//						new SqlParameter("@CMD","U"),
//						new SqlParameter("@nPayrollID",nPayrollID),
//						new SqlParameter("@nEmployeeID",Convert.ToInt32(dr[0])),
//						new SqlParameter("@mCommission",0),
//						//new SqlParameter("@mCommissionLatenessPenalty",0),
//						new SqlParameter("@dtSecondRunDate",DateTime.Now.ToShortDateString()),
//						new SqlParameter("@nSecondRunStaff",employee.Id.ToString())
//						//Commission * (total lateness in mins)/100
//						);
//					try
//					{
//						/// 1. PT SERVICE COMMISSION
//						CommissionPTService comm1 = new CommissionPTService();
//						comm1.CalculatePTServiceCommission(Convert.ToInt32(dr[0]),(ACMSLogic.Staff.Month)(Convert.ToInt32(comboBoxEditMTH.EditValue)),Convert.ToInt32(comboBoxEditYR.Text));
//						
//						// To Generate Commission Details and store to table tblPayrollPTServiceCommDetails
//						output = 0;
//						foreach (DataRow drDetl in comm1.ResultTableInDetail.Rows)
//						{
//							SqlHelper.ExecuteNonQuery(connection,"UP_tblPayrollPTServiceCommDetails",
//								new SqlParameter("@RET_VAL",output),
//								new SqlParameter("@CMD","I"),
//								new SqlParameter("@nPayrollID",nPayrollID),
//								new SqlParameter("@nEmployeeID",Convert.ToInt32(drDetl["nEmployeeID"])),
//								new SqlParameter("@dtDate",ConvertToDateTime(drDetl["dtDate"])),
//								new SqlParameter("@strBranchCode",drDetl["strBranchCode"].ToString()),
//								new SqlParameter("@strServiceCode",drDetl["strServiceCode"].ToString()),
//								new SqlParameter("@mCommission",Convert.ToDecimal(drDetl["mCommission"]))
//								);
//						}
//					}
//					catch (Exception ex)
//					{
//						MessageBox.Show(dr[0].ToString()+ " " + ex.Message);
//					}

				DrSPACList = _ds.Tables["table"].Select("fSpaConsult = true");					
				foreach( DataRow dr in DrSPACList )
				{
					try 
					{
						/// 2. SPA Consultant COMMISSION:
						CommissionSpaService comm2 = new CommissionSpaService();
						comm2.CalculateSpaServiceCommission(ConvertToInt(dr[0]),System.Convert.ToString(dr[2]),(ACMSLogic.Staff.Month)(ConvertToInt(comboBoxEditMTH.SelectedIndex)),ConvertToInt(comboBoxEditYR.Text),true);

						// To Generate Spa Service Comm Detais
						// To Generate Commission Details and store to table tblPayrollPTServiceCommDetails
						output = 0;
						if (comm2.SPACCommDetail.Rows.Count>0)
						{
							foreach (DataRow drSPAC in comm2.SPACCommDetail.Rows)
							{
								SqlHelper.ExecuteNonQuery(connection,"UP_tblPayrollEntries_SecondRun",
									new SqlParameter("@RET_VAL",output),
									new SqlParameter("@CMD","U"),
									new SqlParameter("@nPayrollID",nPayrollID),
									new SqlParameter("@nEmployeeID",Convert.ToInt32(drSPAC[0])),
									new SqlParameter("@mCommission",Convert.ToDecimal(drSPAC[1])),
									//	new SqlParameter("@mCommissionLatenessPenalty",CommissionPenalty * 2),
									new SqlParameter("@dtSecondRunDate",DateTime.Now.ToShortDateString()),
									new SqlParameter("@nSecondRunStaff",employee.Id.ToString())	);
						
							}
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(dr[0].ToString()+ " "+ex.Message);
					}
				}
                    				
				
				DrThepList = _ds.Tables["table"].Select("fTherapist = true");					
				foreach( DataRow dr in DrThepList )
				{
					try 
					{
						/// 2. THerapist COMMISSION:
						CommissionSpaService comm4 = new CommissionSpaService();
						comm4.CalculateSpaServiceCommission(ConvertToInt(dr[0]),System.Convert.ToString(dr[2]),(ACMSLogic.Staff.Month)(ConvertToInt(comboBoxEditMTH.SelectedIndex)),ConvertToInt(comboBoxEditYR.Text),true);

						// To Generate Spa Service Comm Detais
						// To Generate Commission Details and store to table tblPayrollPTServiceCommDetails
						output = 0;
						if (comm4.THEPCommDetail.Rows.Count>0)
						{
							foreach (DataRow drTHEP in comm4.THEPCommDetail.Rows)
							{
								SqlHelper.ExecuteNonQuery(connection,"UP_tblPayrollEntries_SecondRun",
									new SqlParameter("@RET_VAL",output),
									new SqlParameter("@CMD","U"),
									new SqlParameter("@nPayrollID",nPayrollID),
									new SqlParameter("@nEmployeeID",Convert.ToInt32(drTHEP[0])),
									new SqlParameter("@mCommission",Convert.ToDecimal(drTHEP[1])),
									//	new SqlParameter("@mCommissionLatenessPenalty",CommissionPenalty * 2),
									new SqlParameter("@dtSecondRunDate",DateTime.Now.ToShortDateString()),
									new SqlParameter("@nSecondRunStaff",employee.Id.ToString())	);
						
							}
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(dr[0].ToString()+ " "+ex.Message);
					}
				}

				DrBMList = _ds.Tables["table"].Select("strJobPositionCode = 'BRM'");
				foreach( DataRow dr in DrBMList )
				{
					try 
					{
						/// 2. BM COMMISSION:
						CommissionSpaService comm5 = new CommissionSpaService();
						comm5.CalculateSpaServiceCommission(ConvertToInt(dr[0]),(ACMSLogic.Staff.Month)(ConvertToInt(comboBoxEditMTH.SelectedIndex)),ConvertToInt(comboBoxEditYR.Text),true);

						// To Generate Spa Service Comm Detais
						// To Generate Commission Details and store to table tblPayrollPTServiceCommDetails
						output = 0;
						if (comm5.BMCommDetail.Rows.Count>0)
						{
							foreach (DataRow drBM in comm5.BMCommDetail.Rows)
							{
								SqlHelper.ExecuteNonQuery(connection,"UP_tblPayrollEntries_SecondRun",
									new SqlParameter("@RET_VAL",output),
									new SqlParameter("@CMD","U"),
									new SqlParameter("@nPayrollID",nPayrollID),
									new SqlParameter("@nEmployeeID",Convert.ToInt32(drBM[0])),
									new SqlParameter("@mCommission",Convert.ToDecimal(drBM[1])),
									//	new SqlParameter("@mCommissionLatenessPenalty",CommissionPenalty * 2),
									new SqlParameter("@dtSecondRunDate",DateTime.Now.ToShortDateString()),
									new SqlParameter("@nSecondRunStaff",employee.Id.ToString())	);
						
							}
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(dr[0].ToString()+ " "+ex.Message);
					}
				}

				DrBMList = _ds.Tables["table"].Select("strJobPositionCode = 'ABMGR'");
				foreach( DataRow dr in DrBMList )
				{
					try 
					{
						/// 2. BM COMMISSION:
						CommissionSpaService comm5 = new CommissionSpaService();
						comm5.CalculateSpaServiceCommission(ConvertToInt(dr[0]),System.Convert.ToString(dr[2]),(ACMSLogic.Staff.Month)(ConvertToInt(comboBoxEditMTH.SelectedIndex)),ConvertToInt(comboBoxEditYR.Text),false);

						// To Generate Spa Service Comm Detais
						// To Generate Commission Details and store to table tblPayrollPTServiceCommDetails
						output = 0;
						if (comm5.BMCommDetail.Rows.Count>0)
						{
							foreach (DataRow drBM in comm5.BMCommDetail.Rows)
							{
								SqlHelper.ExecuteNonQuery(connection,"UP_tblPayrollEntries_SecondRun",
									new SqlParameter("@RET_VAL",output),
									new SqlParameter("@CMD","U"),
									new SqlParameter("@nPayrollID",nPayrollID),
									new SqlParameter("@nEmployeeID",Convert.ToInt32(drBM[0])),
									new SqlParameter("@mCommission",Convert.ToDecimal(drBM[1])),
									//	new SqlParameter("@mCommissionLatenessPenalty",CommissionPenalty * 2),
									new SqlParameter("@dtSecondRunDate",DateTime.Now.ToShortDateString()),
									new SqlParameter("@nSecondRunStaff",employee.Id.ToString())	);
						
							}
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(dr[0].ToString()+ " "+ex.Message);
					}
				}

				DrPTList = _ds.Tables["table"].Select("fPtInstructor = 'true'");
				foreach( DataRow dr in DrPTList )
				{
					try 
					{
						bool IsPT = false;
						if(System.Convert.ToString(dr["strJobPositionCode"]).Trim() == "PT")
							 IsPT = true;
							
						/// 2. PT COMMISSION:
						CommissionSpaService commPT = new CommissionSpaService();
						commPT.CalculateSpaServiceCommission(ConvertToInt(dr[0]),System.Convert.ToString(dr[2]),(ACMSLogic.Staff.Month)(ConvertToInt(comboBoxEditMTH.SelectedIndex)),ConvertToInt(comboBoxEditYR.Text),IsPT);

						// To Generate Spa Service Comm Detais
						// To Generate Commission Details and store to table tblPayrollPTServiceCommDetails
						output = 0;
						if (commPT.PTCommDetail.Rows.Count>0)
						{
							foreach (DataRow drPT in commPT.PTCommDetail.Rows)
							{
								SqlHelper.ExecuteNonQuery(connection,"UP_tblPayrollEntries_SecondRun",
									new SqlParameter("@RET_VAL",output),
									new SqlParameter("@CMD","U"),
									new SqlParameter("@nPayrollID",nPayrollID),
									new SqlParameter("@nEmployeeID",Convert.ToInt32(drPT[0])),
									new SqlParameter("@mCommission",Convert.ToDecimal(drPT[1])),
									//	new SqlParameter("@mCommissionLatenessPenalty",CommissionPenalty * 2),
									new SqlParameter("@dtSecondRunDate",DateTime.Now.ToShortDateString()),
									new SqlParameter("@nSecondRunStaff",employee.Id.ToString())	);
						
							}
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(dr[0].ToString()+ " "+ex.Message);
					}
				}
					//..LATENESS PENATLY
//					try
//					{
//						output = 0;
//						SqlHelper.ExecuteNonQuery(connection,"UP_tblPayrollCommissionPenalty",
//							new SqlParameter("@RET_VAL",output),
//							new SqlParameter("@CMD","I"),
//							new SqlParameter("@nPayrollID",nPayrollID),
//							new SqlParameter("@nEmployeeID",Convert.ToInt32(dr[0])),
//							new SqlParameter("@Month",comboBoxEditMTH.EditValue),
//							new SqlParameter("@Year",comboBoxEditYR.Text));
//					}
//					catch (Exception ex)
//					{
//						MessageBox.Show(employee.Id.ToString()+" "+ex.Message);
//					}
//
//					try
//					{
//						decimal SpaServiceAmount,PTServiceAmount,SalesCommissionAmount,TotalCommission;
//						SpaServiceAmount=0;
//						PTServiceAmount=0;
//						SalesCommissionAmount=0;
//						TotalCommission=0;
//
//						//Spa Service Comm
//						strSQL = "Select sum(mCommission) as totalCommission from tblPayrollSpaServiceCommDetails where nPayrollID='" + nPayrollID + "' and nEmployeeID='" + Convert.ToInt32(dr[0]) + "'";
//						_ds = new DataSet();
//						SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
//						foreach(DataRow row1 in _ds.Tables["table"].Rows)
//						{
//							SpaServiceAmount=Convert.ToDecimal(row1[0]);	
//						}
//
//						//PT Service Comm
//						strSQL = "Select sum(mCommission) as totalCommission from tblPayrollPTServiceCommDetails where nPayrollID='" + nPayrollID + "' and nEmployeeID='" + Convert.ToInt32(dr[0]) + "'";
//						_ds = new DataSet();
//						SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
//						foreach(DataRow row2 in _ds.Tables["table"].Rows)
//						{
//							PTServiceAmount=Convert.ToDecimal(row2[0]);	
//						}
//
//						//Sales Comm
//						strSQL = "Select sum(mTotalCommission) as totalCommission from tblPayrollSalesCommDetails where nPayrollID='" + nPayrollID + "' and nEmployeeID='" + Convert.ToInt32(dr[0]) + "'";
//						_ds = new DataSet();
//						SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
//						foreach(DataRow row3 in _ds.Tables["table"].Rows)
//						{
//							SalesCommissionAmount=Convert.ToDecimal(row3[0]);	
//						}
//
//						TotalCommission = SpaServiceAmount + PTServiceAmount + SalesCommissionAmount;
//						output = 0;
//						SqlHelper.ExecuteNonQuery(connection,"UP_tblPayrollEntries_SecondRun",
//							new SqlParameter("@RET_VAL",output),
//							new SqlParameter("@CMD","U"),
//							new SqlParameter("@nPayrollID",nPayrollID),
//							new SqlParameter("@nEmployeeID",Convert.ToInt32(dr[0])),
//							new SqlParameter("@mCommission",TotalCommission),
//						//	new SqlParameter("@mCommissionLatenessPenalty",CommissionPenalty * 2),
//							new SqlParameter("@dtSecondRunDate",DateTime.Now.ToShortDateString()),
//							new SqlParameter("@nSecondRunStaff",employee.Id.ToString())	);
//
//					}
//					catch (Exception ex)
//					{
//						MessageBox.Show(employee.Id.ToString()+" "+ex.Message);
//					}

					progressBarControl1.PerformStep();
					progressBarControl1.Update();
				
				progressBarControl1.Visible = false;
				InitPayroll(2);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void cmbxPayroll_SelectedValueChanged(object sender, System.EventArgs e)
		{
			Payroll_Refresh();
		}

		public void Payroll_Refresh()
		{
			if (cmbxPayroll.Text=="First Run")
			{
				InitPayroll(1);

			}
			else if(cmbxPayroll.Text=="Second Run")
			{
				InitPayroll(2);
			}
		
		}

		private void comboBoxEditYR_SelectedValueChanged(object sender, System.EventArgs e)
		{
			Payroll_Refresh();
		}

		private void comboBoxEditMTH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Payroll_Refresh();
		}

		private void cbJob_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			isFinishedPayrollInit = true;
			Payroll_Refresh();
		
		}
		private void btnPayrollDelete_Click(object sender, System.EventArgs e)
		{
			string strSQL;
			DataSet _ds;

			strSQL = "select nPayrollID from tblPayroll where nYear=" + Convert.ToInt32(comboBoxEditYR.Text) + " and nMonth=" + Convert.ToInt32(comboBoxEditMTH.Text);
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			if( _ds.Tables["table"].Rows.Count>0)
			{
				DialogResult result = MessageBox.Show(this, "Would you like to delete payroll for Year " + comboBoxEditYR.Text + " Month " + comboBoxEditMTH.Text + " ?",
					"Delete Payroll?", MessageBoxButtons.YesNo);
			
				if (result == DialogResult.Yes)
				{
					try
					{
						strSQL = "Delete tblPayrollEntries where nPayrollID=(select nPayrollID from tblPayroll where nYear=" + Convert.ToInt32(comboBoxEditYR.Text) + " and nMonth=" + Convert.ToInt32(comboBoxEditMTH.Text) + ")";
						_ds = new DataSet();
						SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );

						strSQL = "Delete tblPayroll where nYear=" + Convert.ToInt32(comboBoxEditYR.Text) + " and nMonth=" + Convert.ToInt32(comboBoxEditMTH.Text);
						_ds = new DataSet();
						SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
						Payroll_Refresh();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
				else
				{
					return;
				}
			}
		}

		#endregion 

		#region ** Report **

		private void lookup_Report(int ReportID)
		{
			DataSet mdr = new DataSet(); 

			lk_ReportView.Properties.DataSource = "";
			lk_ReportView.Properties.Columns.Clear();

			string strSQL = "select * from tblReportView where nReportID=" + ReportID +" and fShow=0 order by nReportID,strReportCode";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",mdr,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL));
			DataTable dtMaster = mdr.Tables["Table"];

			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strReportCode","Screen ID",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strReportName","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
		
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_ReportView.Properties,dtMaster,col,"strReportName","strReportCode","Report");
			}
	
		

		private void InitReport()
		{
			rptAnalysis = new ACMS.ACMSManager.Reports.RPIncomeAnalysis(employee.Id);
			
			ReportPanel.Controls.Clear();
			rptAnalysis.TopLevel = false;
			rptAnalysis.Dock = DockStyle.Fill;
			rptAnalysis.Parent = ReportPanel;
			rptAnalysis.SetEmployeeRecord(employee);
			rptAnalysis.SetTerminalUser(terminalUser);
			rptAnalysis.initData(oUser);
			rptAnalysis.Show();
			ReportPanel.Refresh();
		}

		private void show_Sales1()
		{
			if(employee.CanAccess("AM_VIEW_INCOME_ANALYSIS_REPORT",terminalUser.Branch.Id))
			{
				try
				{
					ReportPanel.Controls.Clear();
					rptAnalysis = new ACMS.ACMSManager.Reports.RPIncomeAnalysis(employee.Id);
					rptAnalysis.TopLevel = false;
					rptAnalysis.Dock = DockStyle.Fill;
					rptAnalysis.Parent = ReportPanel;
					rptAnalysis.SetEmployeeRecord(employee);
					rptAnalysis.SetTerminalUser(terminalUser);
					rptAnalysis.initData(oUser);
					rptAnalysis.Show();
					ReportPanel.Refresh();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			else
			{
				MessageBox.Show("You don't have sufficient right to insert new roster for this staff");
			}

		}
		
		private void show_Sales2()
		{
			ReportPanel.Controls.Clear();
			rptMtMSales = new ACMS.ACMSManager.Reports.RPMtMSales();
			rptMtMSales.TopLevel = false;
			rptMtMSales.Dock = DockStyle.Fill;
			rptMtMSales.Parent = ReportPanel;
			rptMtMSales.SetEmployeeRecord(employee);
			rptMtMSales.SetTerminalUser(terminalUser);
			rptMtMSales.initData(oUser);
			rptMtMSales.Show();
			ReportPanel.Refresh();
		}

		private void show_Sales6()
		{
			ReportPanel.Controls.Clear();
			rptComSales = new ACMS.ACMSManager.Reports.RPSalesMangement();
			rptComSales.TopLevel = false;
			rptComSales.Dock = DockStyle.Fill;
			rptComSales.Parent = ReportPanel;
			rptComSales.Show();
			ReportPanel.Refresh();
		}

		private void show_Sales3()
		{
			if(employee.CanAccess("AM_VIEW_ALL_INCOME_LISTING_REPORT", terminalUser.Branch.Id))
			{
				try
				{
					ReportPanel.Controls.Clear();
					rptAllIncome = new ACMS.ACMSManager.Reports.RPAllIncome();
					rptAllIncome.TopLevel = false;
					rptAllIncome.Dock = DockStyle.Fill;
					rptAllIncome.Parent = ReportPanel;
					rptAllIncome.Show();
					ReportPanel.Refresh();
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			else
			{
				MessageBox.Show("You don't have sufficient right to view all income listing report.");
			}
		}

		private void show_Sales4()
		{
			ACMSLogic.User oUser = new User();
			ReportPanel.Controls.Clear();
			rptSpaDailyBranch = new ACMS.ACMSManager.Reports.RPSpaDailyBranchSales();
			rptSpaDailyBranch.TopLevel = false;
			rptSpaDailyBranch.Dock = DockStyle.Fill;
			rptSpaDailyBranch.Parent = ReportPanel;
			rptSpaDailyBranch.SetEmployeeRecord(employee);
			rptSpaDailyBranch.SetTerminalUser(terminalUser);
			rptSpaDailyBranch.initData(oUser);
			rptSpaDailyBranch.Show();
			ReportPanel.Refresh();
		}

		private void show_Sales5()
		{
			ACMSLogic.User oUser = new User();

			ReportPanel.Controls.Clear();
			rptFitnessDailyBranch = new ACMS.ACMSManager.Reports.RPFitnessDailyBranchSales();
			rptFitnessDailyBranch.TopLevel = false;
			rptFitnessDailyBranch.Dock = DockStyle.Fill;
			rptFitnessDailyBranch.Parent = ReportPanel;
			rptFitnessDailyBranch.SetEmployeeRecord(employee);
			rptFitnessDailyBranch.SetTerminalUser(terminalUser);
			rptFitnessDailyBranch.initData(oUser);
			rptFitnessDailyBranch.Show();
			ReportPanel.Refresh();
		}

		private void show_Promotion1()
		{
			ACMSLogic.User oUser = new User();

			ReportPanel.Controls.Clear();
			rptPromotion = new ACMS.ACMSManager.Reports.RPPromotionReport(employee.Id);
			rptPromotion.TopLevel = false;
			rptPromotion.Dock = DockStyle.Fill;
			rptPromotion.Parent = ReportPanel;
			rptPromotion.Show();
			ReportPanel.Refresh();
		}

		private void show_Promotion2()
		{
			ACMSLogic.User oUser = new User();
		
			ReportPanel.Controls.Clear();
			rptPromotion2 = new  ACMS.ACMSManager.Reports.RPPromotionSalesPkg(employee.Id);
			rptPromotion2.TopLevel = false;
			rptPromotion2.Dock = DockStyle.Fill;
			rptPromotion2.Parent = ReportPanel;
			rptPromotion2.Show();
			ReportPanel.Refresh();
			
		}

		private void show_Promotion3()
		{
			ACMSLogic.User oUser = new User();
			
			ReportPanel.Controls.Clear();
			rptPromotionAnalysis = new  ACMS.ACMSManager.Reports.RPPromotionAnalysis(employee.Id);
			rptPromotionAnalysis.TopLevel = false;
			rptPromotionAnalysis.Dock = DockStyle.Fill;
			rptPromotionAnalysis.Parent = ReportPanel;
			rptPromotionAnalysis.Show();
			ReportPanel.Refresh();
		}

		private void show_Accounts1()
		{
			ACMSLogic.User oUser = new User();

			ReportPanel.Controls.Clear();
			rptAccount = new ACMS.ACMSManager.Reports.RPAccountsReport(employee.Id);
			rptAccount.TopLevel = false;
			rptAccount.Dock = DockStyle.Fill;
			rptAccount.Parent = ReportPanel;
			rptAccount.Show();
			ReportPanel.Refresh();
		}

		private void show_Staff1()
		{
			ACMSLogic.User oUser = new User();
			ACMS.ACMSManager.Reports.RPCommission rptComm;
			ReportPanel.Controls.Clear();
			rptComm = new ACMS.ACMSManager.Reports.RPCommission();
			rptComm.TopLevel = false;
			rptComm.Dock = DockStyle.Fill;
			rptComm.Parent = ReportPanel;
			rptComm.Show();
			ReportPanel.Refresh();
		
		}
		
		private void show_Staff2()
		{
			ACMSLogic.User oUser = new User();

			ReportPanel.Controls.Clear();
			rptStaff = new ACMS.ACMSManager.Reports.RPStaffReport(employee.Id);
			rptStaff.TopLevel = false;
			rptStaff.Dock = DockStyle.Fill;
			rptStaff.Parent = ReportPanel;
			rptStaff.Show();
			ReportPanel.Refresh();
		}
		
		private void show_Staff3()
		{
			ACMSLogic.User oUser = new User();

			ReportPanel.Controls.Clear();
			rptStaffTimeOff = new ACMS.ACMSManager.Reports.RPStaffTimeOff(employee.Id);
			rptStaffTimeOff.TopLevel = false;
			rptStaffTimeOff.Dock = DockStyle.Fill;
			rptStaffTimeOff.Parent = ReportPanel;
			rptStaffTimeOff.Show();
			ReportPanel.Refresh();
		}

		private void show_Operations5()
		{
			ACMSLogic.User oUser = new User();

			ReportPanel.Controls.Clear();
			rptInstructor = new ACMS.ACMSManager.Reports.RPInstructorFees(employee.Id);
			rptInstructor.TopLevel = false;
			rptInstructor.Dock = DockStyle.Fill;
			rptInstructor.Parent = ReportPanel;
			rptInstructor.Show();
			ReportPanel.Refresh();
		}

		private void show_Staff4()
		{
			ACMSLogic.User oUser = new User();

			ReportPanel.Controls.Clear();
			rptLateness = new ACMS.ACMSManager.Reports.RPLateness(employee.Id);
			rptLateness.TopLevel = false;
			rptLateness.Dock = DockStyle.Fill;
			rptLateness.Parent = ReportPanel;
			rptLateness.Show();
			ReportPanel.Refresh();
		}

		private void show_CV1()
		{
			ACMSLogic.User oUser = new User();

			ReportPanel.Controls.Clear();
			rptCustomerVoice = new ACMS.ACMSManager.Reports.RPCustomerVoice(employee.Id);
			rptCustomerVoice.TopLevel = false;
			rptCustomerVoice.Dock = DockStyle.Fill;
			rptCustomerVoice.Parent = ReportPanel;
			rptCustomerVoice.Show();
			ReportPanel.Refresh();
		}

		private void show_Class1()
		{
			ACMSLogic.User oUser = new User();

			ReportPanel.Controls.Clear();
			rptCASchedule = new ACMS.ACMSManager.Reports.RPClassAnalysis(employee.Id,oUser.StrBranchCode());
			rptCASchedule.TopLevel = false;
			rptCASchedule.Dock = DockStyle.Fill;
			rptCASchedule.Parent = ReportPanel;
			rptCASchedule.Show();
			ReportPanel.Refresh();
		}

		private void show_Class2()
		{
			ACMSLogic.User oUser = new User();

			ReportPanel.Controls.Clear();
			rptCAInstructor = new ACMS.ACMSManager.Reports.RPClassInstructor(employee.Id);
			rptCAInstructor.TopLevel = false;
			rptCAInstructor.Dock = DockStyle.Fill;
			rptCAInstructor.Parent = ReportPanel;
			rptCAInstructor.Show();
			ReportPanel.Refresh();
		}

		/*private void show_Class3()
		{
			ACMSLogic.User oUser = new User();

			ReportPanel.Controls.Clear();
			rptCAClassType = new ACMS.ACMSManager.Reports.RPClassAnalysisCT(employee.Id);
			rptCAClassType.TopLevel = false;
			rptCAClassType.Dock = DockStyle.Fill;
			rptCAClassType.Parent = ReportPanel;
			rptCAClassType.Show();
			ReportPanel.Refresh();
		}*/

		private void show_Class4()
		{
			ReportPanel.Controls.Clear();
			rptGymAnalysis = new ACMS.ACMSManager.Reports.RPGymAnalysis(employee.Id);
			rptGymAnalysis.TopLevel = false;
			rptGymAnalysis.Dock = DockStyle.Fill;
			rptGymAnalysis.Parent = ReportPanel;
			rptGymAnalysis.Show();
			ReportPanel.Refresh();
		}

		private void show_Class5()
		{

			ACMSLogic.User oUser = new User();
			ReportPanel.Controls.Clear();
			rptDayClass = new ACMS.ACMSManager.Reports.RPDayClassAnalysis(employee.Id,oUser.StrBranchCode());
			rptDayClass.TopLevel = false;
			rptDayClass.Dock = DockStyle.Fill;
			rptDayClass.Parent = ReportPanel;
			rptDayClass.Show();
			ReportPanel.Refresh();
		}

        private void show_Class6()
        {

            ACMSLogic.User oUser = new User();
        	ReportPanel.Refresh();
            ReportPanel.Controls.Clear();
            rptInsturctorSalary = new ACMS.ACMSManager.Reports.RPInsturctorSalary();
            rptInsturctorSalary.TopLevel = false;
            rptInsturctorSalary.Dock = DockStyle.Fill;
            rptInsturctorSalary.Parent = ReportPanel;
            rptInsturctorSalary.Show();
            ReportPanel.Refresh();
        }
	
		private void show_Quantity1()
		{
			ACMSLogic.User oUser = new User();

			ReportPanel.Controls.Clear();
			rptStock = new ACMS.ACMSManager.Reports.RPStock(employee.Id);
			rptStock.TopLevel = false;
			rptStock.Dock = DockStyle.Fill;
			rptStock.Parent = ReportPanel;
			rptStock.Show();
			ReportPanel.Refresh();
		}

		private void show_Quantity2()
		{
			ACMSLogic.User oUser = new User();

			ReportPanel.Controls.Clear();
			rptSpaFitness = new ACMS.ACMSManager.Reports.RPSpaFitness(employee.Id);
			rptSpaFitness.TopLevel = false;
			rptSpaFitness.Dock = DockStyle.Fill;
			rptSpaFitness.Parent = ReportPanel;
			rptSpaFitness.Show();
			ReportPanel.Refresh();
		}

		private void show_Quantity3()
		{
			ACMSLogic.User oUser = new User();

			ReportPanel.Controls.Clear();
			rptSalonUse = new ACMS.ACMSManager.Reports.RPStockSalon();
			rptSalonUse.TopLevel = false;
			rptSalonUse.Dock = DockStyle.Fill;
			rptSalonUse.Parent = ReportPanel;
			rptSalonUse.Show();
			ReportPanel.Refresh();
		}

		private void show_Leave1()
		{
			ACMSLogic.User oUser = new User();

			ReportPanel.Controls.Clear();
			rptLeave = new ACMS.ACMSManager.Reports.RPLeave(employee.Id);
			rptLeave.TopLevel = false;
			rptLeave.Dock = DockStyle.Fill;
			rptLeave.Parent = ReportPanel;
			rptLeave.Show();
			ReportPanel.Refresh();
		}

		private void show_Member1()
		{
			ACMSLogic.User oUser = new User();

			ReportPanel.Controls.Clear();
			rptNewMember = new ACMS.ACMSManager.Reports.RPNewMember();
			rptNewMember.TopLevel = false;
			rptNewMember.Dock = DockStyle.Fill;
			rptNewMember.Parent = ReportPanel;
			rptNewMember.Show();
			ReportPanel.Refresh();
		}

		private void show_Operations1()
		{
			ACMSLogic.User oUser = new User();

			ReportPanel.Controls.Clear();
			rptSpaFitness = new ACMS.ACMSManager.Reports.RPSpaFitness(employee.Id);
			rptSpaFitness.TopLevel = false;
			rptSpaFitness.Dock = DockStyle.Fill;
			rptSpaFitness.Parent = ReportPanel;
			rptSpaFitness.Show();
			ReportPanel.Refresh();
		}

		private void show_Operations2()
		{
			ACMSLogic.User oUser = new User();

			ReportPanel.Controls.Clear();
			rptOperation = new ACMS.ACMSManager.Reports.RPOperation(employee.Id);
			rptOperation.TopLevel = false;
			rptOperation.Dock = DockStyle.Fill;
			rptOperation.Parent = ReportPanel;
			rptOperation.Show();
			ReportPanel.Refresh();
		}
	
		private void show_Operations3()
		{

			ACMSLogic.User oUser = new User();

			ReportPanel.Controls.Clear();
			rptInstructorDetail = new ACMS.ACMSManager.Reports.RPInstructorDetails();
			rptInstructorDetail.TopLevel = false;
			rptInstructorDetail.Dock = DockStyle.Fill;
			rptInstructorDetail.Parent = ReportPanel;
			rptInstructorDetail.Show();
			ReportPanel.Refresh();
		}

		private void show_Operations4()
		{
			ACMSLogic.User oUser = new User();

			ReportPanel.Controls.Clear();
			rptInstructorSalary = new ACMS.ACMSManager.Reports.RPInsturctorSalary();
			rptInstructorSalary.TopLevel = false;
			rptInstructorSalary.Dock = DockStyle.Fill;
			rptInstructorSalary.Parent = ReportPanel;
			rptInstructorSalary.Show();
			ReportPanel.Refresh();
		
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
	
		private void tabControlManager_Click(object sender, System.EventArgs e)
		{
			if (tabControlManager.SelectedTabPage == tabManagerTwo)
			{
				InitPayroll(0);
				comboBoxEditMTH.EditValue=DateTime.Now.Month.ToString();
			}
			else if (tabControlManager.SelectedTabPage == tabManagerThree)
			{
				lblThree_1_Click(sender,e);
			}
			else if (tabControlManager.SelectedTabPage == tabManagerFour)
			{
				lblFour_1_Click(sender,e);
			}
			else if (tabControlManager.SelectedTabPage == tabManagerFive)
			{
				ReportPanel.Controls.Clear();
				lblFive_1_Click(sender,e);
				ReportPanel.Refresh();
			}
			else if (tabControlManager.SelectedTabPage == tabManagerSix)
			{
				lk_MasterData.ItemIndex=0;
			}

		}

		private void Init_Master_lookUp()
		{
			DataSet mds = new DataSet(); 

			lk_MasterData.Properties.DataSource = "";
			lk_MasterData.Properties.Columns.Clear();
			
			string strSQL = "select * from tblMasterData where fShow=0 order by pkMasterData";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",mds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dtMaster = mds.Tables["Table"];

			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("pkMasterData","Screen ID",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
		
			new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(this.lk_MasterData.Properties,dtMaster,col,"strDescription","pkMasterData","Master Data");
		}


	private void bbiManagerTimeCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			frmTimeCard myFormTimeCard = new frmTimeCard(terminalUser.Branch.Id);
			myFormTimeCard.ShowDialog();
			myFormTimeCard.Dispose();
		}
		
		private void comboBind(DevExpress.XtraEditors.ImageComboBoxEdit 
			control,string strSQL,string display,string strValue,bool fNum)
		{
		
			DataSet _ds = new DataSet();
			
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) 
				);
			DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox 
				properties = control.Properties;
			properties.Items.BeginUpdate();
			properties.Items.Clear();

			try 
			{
				foreach(DataRow dr in _ds.Tables["Table"].Rows)
				{
					//Initialize each item with the display text, value and image index
					properties.Items.Add( new 
						DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr[display].ToString(), dr[strValue],-1));
				}
			}
			finally 
			{
				properties.Items.EndUpdate();
			}
			//Select the first item
			try
			{
				control.SelectedIndex = 0;
			}
			catch
			{}
		}
		
		#endregion

		#region lblOne

		private void int_lblOne()
		{
			groupIPPMaster.Hide();
			groupGIROMaster.Hide();
			lblOne_1.ForeColor=System.Drawing.Color.MediumBlue;
			lblOne_2.ForeColor=System.Drawing.Color.MediumBlue;
		}

		private void lblOne_1_Click(object sender, System.EventArgs e)
		{
			int_lblOne();
			lblOne_1.ForeColor=System.Drawing.Color.Firebrick;
			groupIPPMaster.Show();
		}

		private void lblOne_2_Click(object sender, System.EventArgs e)
		{
			int_lblOne();
			lblOne_2.ForeColor=System.Drawing.Color.Firebrick;
			LoadGIRO();
			groupGIROMaster.Show();
		
		}

		#endregion 

		#region lblThree

		private void int_lblThree()
		{
			this.groupMemCard.Hide();
			grpClassSchedule.Hide();
			grpRoadShow.Hide();
		
			lblThree_1.ForeColor=System.Drawing.Color.MediumBlue;
			lblThree_2.ForeColor=System.Drawing.Color.MediumBlue;
			lblThree_3.ForeColor=System.Drawing.Color.MediumBlue;
		}

		private void lblThree_1_Click(object sender, System.EventArgs e)
		{
			int_lblThree();
			lblThree_1.ForeColor=System.Drawing.Color.Firebrick;
			OperationInit();
			grpClassSchedule.Show();
		}

		private void lblThree_2_Click(object sender, System.EventArgs e)
		{
			int_lblThree();
			lblThree_2.ForeColor=System.Drawing.Color.Firebrick;
			groupMemCard.Show();
	
			groupMemCard.SuspendLayout();

			ACMSLogic.User.BranchCode = terminalUser.Branch.Id;
			ACMSLogic.User.EmployeeID = employee.Id;
			if (employee.Department != null)
				ACMSLogic.User.DepartmentID = employee.Department.Id;
			if (employee.StrEmployeeName != null)
				ACMSLogic.User.EmployeeName = employee.StrEmployeeName;
			if (employee.JobPosition.Id != null)
				ACMSLogic.User.JobPositionCode = employee.JobPosition.Id;
			if (employee.RightsLevel != null)
				ACMSLogic.User.RightsLevelID = employee.RightsLevel.Id;
			
			ACMSLogic.User oUser = new User();
			myMemberCard = new ACMS.ACMSManager.Operation.frmMemberCard();
			myMemberCard.initData(oUser);
			myMemberCard.SetEmployeeRecord(employee);
			myMemberCard.SetTerminalUser(terminalUser);
			
			groupMemCard.Controls.Clear();
			myMemberCard.TopLevel = false;
			myMemberCard.Dock = DockStyle.Fill;
			myMemberCard.Parent = groupMemCard;
			groupMemCard.Refresh();
			groupMemCard.ResumeLayout();
			myMemberCard.Show();
	
		}

		private void lblThree_3_Click(object sender, System.EventArgs e)
		{
			int_lblThree();
			lblThree_3.ForeColor=System.Drawing.Color.Firebrick;
			this.grpRoadShow.Show();

			grpRoadShow.SuspendLayout();

			ACMSLogic.User.BranchCode = terminalUser.Branch.Id;
			ACMSLogic.User.EmployeeID = employee.Id;
			if (employee.Department != null)
				ACMSLogic.User.DepartmentID = employee.Department.Id;
			if (employee.StrEmployeeName != null)
				ACMSLogic.User.EmployeeName = employee.StrEmployeeName;
			if (employee.JobPosition.Id != null)
				ACMSLogic.User.JobPositionCode = employee.JobPosition.Id;
			if (employee.RightsLevel != null)
				ACMSLogic.User.RightsLevelID = employee.RightsLevel.Id;
			
			ACMSLogic.User oUser = new User();
			myRoadShow = new ACMS.ACMSManager.Operation.frmRoadShow();
			myRoadShow.initData(oUser);
			myRoadShow.SetEmployeeRecord(employee);
			myRoadShow.SetTerminalUser(terminalUser);
			
			grpRoadShow.Controls.Clear();
			myRoadShow.TopLevel = false;
			myRoadShow.Dock = DockStyle.Fill;
			myRoadShow.Parent = grpRoadShow;
			grpRoadShow.Refresh();
			myRoadShow.Show();
			grpRoadShow.ResumeLayout();

		}

		#endregion 

		#region lblFour

		public void RefreshRoster()
		{
			this.SuspendLayout();
			int n=frmRoster.WeekNo;
			
			if (!frmRoster.IsDisposed)
			{
				frmRoster.Close();
			}
			
			frmRoster.initData(oUser);
			frmRoster.SetEmployeeRecord(employee);
			frmRoster.SetTerminalUser(terminalUser);
			frmRoster = new ACMS.ACMSManager.Human_Resource.frmRosterMain();
			frmRoster.WeekNo = n;
			panel2.Controls.Clear();
			frmRoster.TopLevel = false;
			frmRoster.Dock = DockStyle.Fill;
			frmRoster.Parent = panel2;
			frmRoster.Show();
			panel2.Refresh();
			this.ResumeLayout();
		}

		private void int_lblFour()
		{
			panel2.Controls.Clear();
			lblFour_1.ForeColor=System.Drawing.Color.MediumBlue;
			lblFour_2.ForeColor=System.Drawing.Color.MediumBlue;
			lblFour_3.ForeColor=System.Drawing.Color.MediumBlue;
			lblFour_4.ForeColor=System.Drawing.Color.MediumBlue;
			lblFour_5.ForeColor=System.Drawing.Color.MediumBlue;
		}

		private void lblFour_1_Click(object sender, System.EventArgs e)
		{
			int_lblFour();
			lblFour_1.ForeColor=System.Drawing.Color.Firebrick;
			RefreshRoster();
		}

		private void lblFour_2_Click(object sender, System.EventArgs e)
		{
			int_lblFour();
			lblFour_2.ForeColor=System.Drawing.Color.Firebrick;

			if (!frmTimeSheet.IsDisposed)
			{
				frmTimeSheet.Close();
			}
			frmTimeSheet = new ACMS.ACMSManager.Human_Resource.frmTimeSheetMain();
			frmTimeSheet.initData(oUser);
			frmTimeSheet.SetEmployeeRecord(employee);
			frmTimeSheet.SetTerminalUser(terminalUser);
			frmTimeSheet.TopLevel = false;
			frmTimeSheet.Dock = DockStyle.Fill;
			frmTimeSheet.Parent = panel2;
			frmTimeSheet.Show();
			panel2.Refresh();

		}

		private void lblFour_3_Click(object sender, System.EventArgs e)
		{
			int_lblFour();
			lblFour_3.ForeColor=System.Drawing.Color.Firebrick;

			if (!frmOvertime.IsDisposed)
			{
				frmOvertime.Close();
			}
			frmOvertime.initData(oUser);
			frmOvertime.SetEmployeeRecord(employee);
			frmOvertime.SetTerminalUser(terminalUser);
			frmOvertime = new ACMS.ACMSManager.Human_Resource.frmOvertimeMain();
			frmOvertime.TopLevel = false;
			frmOvertime.Dock = DockStyle.Fill;
			frmOvertime.Parent = panel2;
			frmOvertime.Show();
			panel2.Refresh();

		}
		private void lblFour_4_Click(object sender, System.EventArgs e)
		{
			int_lblFour();
			lblFour_4.ForeColor=System.Drawing.Color.Firebrick;
					
			if (!frmHRLeave.IsDisposed)
			{
				frmHRLeave.Close();
			}

			frmHRLeave.initData(oUser);
			frmHRLeave.SetEmployeeRecord(employee);
			frmHRLeave.SetTerminalUser(terminalUser);
			frmHRLeave = new ACMS.ACMSManager.Human_Resource.frmLeave();
			frmHRLeave.TopLevel = false;
			frmHRLeave.Dock = DockStyle.Fill;
			frmHRLeave.Parent = panel2;
			frmHRLeave.Show();
			panel2.Refresh();

		}
		private void lblFour_5_Click(object sender, System.EventArgs e)
		{
			int_lblFour();
			lblFour_5.ForeColor=System.Drawing.Color.Firebrick;
			if (!frmHRLeave.IsDisposed)
			{
				frmHRLeave.Close();
			}
			frmHRAppointment.initData(oUser);
			frmHRAppointment.SetEmployeeRecord(employee);
			frmHRAppointment.SetTerminalUser(terminalUser);
			frmHRAppointment = new ACMS.ACMSManager.Human_Resource.frmAppointment();
			frmHRAppointment.TopLevel = false;
			frmHRAppointment.Dock = DockStyle.Fill;
			frmHRAppointment.Parent = panel2;
			frmHRAppointment.Show();
			panel2.Refresh();
		}
	
		#endregion

		#region lblFive

		private void int_lblFive()
		{
			ReportPanel.Controls.Clear();
			
			lblFive_1.ForeColor=System.Drawing.Color.MediumBlue;
			lblFive_2.ForeColor=System.Drawing.Color.MediumBlue;
			lblFive_3.ForeColor=System.Drawing.Color.MediumBlue;
			lblFive_4.ForeColor=System.Drawing.Color.MediumBlue;
			lblFive_5.ForeColor=System.Drawing.Color.MediumBlue;
			lblFive_6.ForeColor=System.Drawing.Color.MediumBlue;
			lblFive_7.ForeColor=System.Drawing.Color.MediumBlue;
			lblFive_8.ForeColor=System.Drawing.Color.MediumBlue;
			lblFive_9.ForeColor=System.Drawing.Color.MediumBlue;
			lblFive_10.ForeColor=System.Drawing.Color.MediumBlue;
		}

		private void lblFive_1_Click(object sender, System.EventArgs e)
		{
			int_lblFive();
			lblFive_1.ForeColor=System.Drawing.Color.Firebrick;
			lookup_Report(1);
		}

		private void lblFive_2_Click(object sender, System.EventArgs e)
		{
			int_lblFive();
			lblFive_2.ForeColor=System.Drawing.Color.Firebrick;
			lookup_Report(2);
//			ACMSLogic.User oUser = new User();
//			rptCASchedule = new ACMS.ACMSManager.Reports.RPClassAnalysis(employee.Id,oUser.StrBranchCode());
//			rptCASchedule.TopLevel = false;
//			rptCASchedule.Dock = DockStyle.Fill;
//			rptCASchedule.Parent = ReportPanel;
//			rptCASchedule.Show();
//			ReportPanel.Refresh();
		}

		private void lblFive_3_Click(object sender, System.EventArgs e)
		{
			int_lblFive();
			lblFive_3.ForeColor=System.Drawing.Color.Firebrick;
			lookup_Report(3);
//			ACMSLogic.User oUser = new User();
//			rptOperation = new ACMS.ACMSManager.Reports.RPOperation(employee.Id);
//			rptOperation.TopLevel = false;
//			rptOperation.Dock = DockStyle.Fill;
//			rptOperation.Parent = ReportPanel;
//			rptOperation.Show();
//			ReportPanel.Refresh();
		}

		private void lblFive_4_Click(object sender, System.EventArgs e)
		{
			int_lblFive();
			lblFive_4.ForeColor=System.Drawing.Color.Firebrick;
			lookup_Report(4);
//			ACMSLogic.User oUser = new User();
//			rptPromotion = new ACMS.ACMSManager.Reports.RPPromotionReport(employee.Id);
//			rptPromotion.TopLevel = false;
//			rptPromotion.Dock = DockStyle.Fill;
//			rptPromotion.Parent = ReportPanel;
//			rptPromotion.Show();
//			ReportPanel.Refresh();
		}

		private void lblFive_5_Click(object sender, System.EventArgs e)
		{
			int_lblFive();
			lblFive_5.ForeColor=System.Drawing.Color.Firebrick;
			lookup_Report(5);
//			ACMSLogic.User oUser = new User();
//			rptAccount = new ACMS.ACMSManager.Reports.RPAccountsReport(employee.Id);
//			rptAccount.TopLevel = false;
//			rptAccount.Dock = DockStyle.Fill;
//			rptAccount.Parent = ReportPanel;
//			rptAccount.Show();
//			ReportPanel.Refresh();

		}

		private void lblFive_6_Click(object sender, System.EventArgs e)
		{
			int_lblFive();
			lblFive_6.ForeColor=System.Drawing.Color.Firebrick;
			lookup_Report(6);
//			ACMSLogic.User oUser = new User();
//			ACMS.ACMSManager.Reports.RPCommission rptComm;
//			rptComm = new ACMS.ACMSManager.Reports.RPCommission();
//			rptComm.TopLevel = false;
//			rptComm.Dock = DockStyle.Fill;
//			rptComm.Parent = ReportPanel;
//			rptComm.Show();
//			ReportPanel.Refresh();
		}

		private void lblFive_7_Click(object sender, System.EventArgs e)
		 {
			int_lblFive();
			lblFive_7.ForeColor=System.Drawing.Color.Firebrick;
			lookup_Report(7);
//			ACMSLogic.User oUser = new User();
//
//			rptCustomerVoice = new ACMS.ACMSManager.Reports.RPCustomerVoice(employee.Id);
//			rptCustomerVoice.TopLevel = false;
//			rptCustomerVoice.Dock = DockStyle.Fill;
//			rptCustomerVoice.Parent = ReportPanel;
//			rptCustomerVoice.Show();
//			ReportPanel.Refresh();
		}
		
		private void lblFive_8_Click(object sender, System.EventArgs e)
		  {
			int_lblFive();
			lblFive_8.ForeColor=System.Drawing.Color.Firebrick;
			lookup_Report(8);
//
//			ACMSLogic.User oUser = new User();
//			rptStock = new ACMS.ACMSManager.Reports.RPStock(employee.Id);
//			rptStock.TopLevel = false;
//			rptStock.Dock = DockStyle.Fill;
//			rptStock.Parent = ReportPanel;
//			rptStock.Show();
//			ReportPanel.Refresh();
		}
		
		private void lblFive_9_Click(object sender, System.EventArgs e)
		   {
			int_lblFive();
			lblFive_9.ForeColor=System.Drawing.Color.Firebrick;
			lookup_Report(9);
//			ACMSLogic.User oUser = new User();
//			rptLeave = new ACMS.ACMSManager.Reports.RPLeave(employee.Id);
//			rptLeave.TopLevel = false;
//			rptLeave.Dock = DockStyle.Fill;
//			rptLeave.Parent = ReportPanel;
//			rptLeave.Show();
//			ReportPanel.Refresh();
		}
		private void lblFive_10_Click(object sender, System.EventArgs e)
			{
			int_lblFive();
			lblFive_10.ForeColor=System.Drawing.Color.Firebrick;
			lookup_Report(10);
//			ACMSLogic.User oUser = new User();
//
//			rptNewMember = new ACMS.ACMSManager.Reports.RPNewMember();
//			rptNewMember.TopLevel = false;
//			rptNewMember.Dock = DockStyle.Fill;
//			rptNewMember.Parent = ReportPanel;
//			rptNewMember.Show();
//			ReportPanel.Refresh();
		}
		#endregion 
	
	
	}
}

