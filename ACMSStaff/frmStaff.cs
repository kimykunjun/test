#region Using
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
using ACMS.Control;
using DevExpress.XtraGrid.Views.Grid;
using ACMSLogic.Staff;
using Do = Acms.Core.Domain;
using DevExpress.XtraScheduler.Demos;
#endregion

namespace ACMS
{
	public class frmStaff : System.Windows.Forms.Form
	{
		#region User Defined Variable
		private string connectionString;
		private SqlConnection connection;
		private User oUser;
		private Do.Employee employee;
		private Do.TerminalUser terminalUser;
		private CommissionSpaService mySpaCommission;
		private CommissionPTService myPTCommission;
		private SalesCommission mySalesCommission;
		private ACMSLogic.Staff.CV myCV;
		private ACMSLogic.Staff.Memo myMemo;
		private ACMSLogic.Staff.ReceipientGroup myReceipientGroup;
		private ACMSLogic.Staff.Appointment myAppointment;
		private ACMSLogic.Staff.Contacts myContacts;
		private ACMSLogic.Staff.Timesheet myTimesheet;
		private ACMSLogic.Staff.Lateness myLateness;
		private ACMSLogic.Staff.Leave myLeave;
		private DateTime startTime;
		/// <summary>
		/// Current display/use month for roster & leave
		/// </summary>
		private DateTime startLeaveDate;
		private DataRow myEmployeeInfo;
		private DataRow myLeaveEmployeeInfo;
		/// <summary>
		/// Don't not load CV before CV finish initialize
		/// </summary>
		private bool isFinishedCVInit;
		private bool isFinishedLeaveInit;
		private bool isFinishedMemoInit;
		/// <summary>
		/// Save last focus CV key
		/// </summary>
		private int lastCaseID;
		/// <summary>
		/// Save last focus mail key for replies
		/// </summary>
		private int lastMemoIDForReplies;
		/// <summary>
		/// Save last focus mail key for repceipient group
		/// </summary>
		private int lastMemoIDForRepceipientGroup;
		/// <summary>
		/// Save lase receipient group ID
		/// </summary>
		private int lastReceipientGroupID;
//		private Color gvTimesheetDefaultFocusColor;
		#endregion

		#region Windows Designer Generated Variable
		Font Font001;
		Font Font002;
		internal DevExpress.XtraEditors.GroupControl groupControl1;
		internal DevExpress.XtraEditors.GroupControl groupControl5;
		internal DevExpress.XtraEditors.GroupControl groupControl11;
		internal DevExpress.XtraEditors.GroupControl groupLeaveLeaveBalance;
		internal DevExpress.XtraEditors.GroupControl groupLeaveLeaveDetails;
		internal DevExpress.XtraEditors.ComboBoxEdit cbServiceServiceType;
		internal DevExpress.XtraEditors.SimpleButton sbtnServiceInquiry;
		private DevExpress.XtraEditors.GroupControl groupControl3;
		internal DevExpress.XtraEditors.ComboBoxEdit cbServiceMonth;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		internal DevExpress.XtraEditors.ComboBoxEdit cbServiceYear;
		internal DevExpress.XtraGrid.GridControl gctrService;
		internal DevExpress.XtraGrid.Views.Grid.GridView gvService;
		private DevExpress.XtraGrid.Columns.GridColumn colServicedtDate;
		private DevExpress.XtraGrid.Columns.GridColumn colServicestrBranchCode;
		private DevExpress.XtraGrid.Columns.GridColumn colServicestrMembershipID;
		private DevExpress.XtraGrid.Columns.GridColumn colServicestrServiceCode;
		private DevExpress.XtraGrid.Columns.GridColumn colServicestrCommission;
		internal DevExpress.XtraEditors.ComboBoxEdit cbSalesType;
		internal DevExpress.XtraGrid.GridControl gctrSales;
		internal DevExpress.XtraGrid.Views.Grid.GridView gvSales;
		private DevExpress.XtraEditors.GroupControl groupControl7;
		internal DevExpress.XtraEditors.ComboBoxEdit cbSalesYear;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		internal DevExpress.XtraEditors.ComboBoxEdit cbSalesMonth;
		internal DevExpress.XtraEditors.SimpleButton sbtnSalesInquiry;
		private DevExpress.XtraBars.BarButtonItem barbtnTimeCard;
		internal DevExpress.XtraGrid.GridControl gctrCV;
		internal DevExpress.XtraGrid.Views.Grid.GridView gvCV;
		internal DevExpress.XtraGrid.Columns.GridColumn colRefNo;
		internal DevExpress.XtraGrid.Columns.GridColumn colDtReceived;
		internal DevExpress.XtraGrid.Columns.GridColumn colBranch;
		internal DevExpress.XtraGrid.Columns.GridColumn colMemberName;
		internal DevExpress.XtraGrid.Columns.GridColumn colType;
		internal DevExpress.XtraGrid.Columns.GridColumn colCategory;
		internal DevExpress.XtraGrid.Columns.GridColumn colSubject;
		private DevExpress.XtraGrid.Columns.GridColumn colMembershipID;
		private DevExpress.XtraGrid.Columns.GridColumn colDepartment;
		private DevExpress.XtraGrid.Columns.GridColumn colSubmittedBy;
		private DevExpress.XtraGrid.Columns.GridColumn colDepartmentAssignedTo;
		private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedDate;
		private DevExpress.XtraGrid.Columns.GridColumn colStatus;
		internal DevExpress.XtraEditors.ComboBoxEdit cbListCV;
		internal DevExpress.XtraEditors.MemoEdit memoeditSummaryCV;
		internal System.Windows.Forms.Label label9;
		private DevExpress.XtraEditors.TextEdit txtContactNo;
		private DevExpress.XtraEditors.TextEdit txtEmail;
		internal System.Windows.Forms.Label label10;
		internal DevExpress.XtraEditors.SimpleButton sbtnCVPrint;
		internal DevExpress.XtraEditors.SimpleButton sbtnCVEdit;
		internal DevExpress.XtraEditors.SimpleButton sbtnCVDelete;
		internal DevExpress.XtraEditors.SimpleButton sbtnCVNew;
		internal DevExpress.XtraGrid.GridControl gctrCVAction;
		internal DevExpress.XtraGrid.Views.Grid.GridView gvCVAction;
		internal DevExpress.XtraGrid.Columns.GridColumn coldtDate;
		internal DevExpress.XtraGrid.Columns.GridColumn colMode;
		internal DevExpress.XtraGrid.Columns.GridColumn colActionDetail;
		internal DevExpress.XtraGrid.Columns.GridColumn colActionTakenBy;
		private DevExpress.XtraGrid.Columns.GridColumn colActionID;
		private DevExpress.XtraGrid.Columns.GridColumn coldtTime;
		internal DevExpress.XtraEditors.SimpleButton sbtnNewCVAction;
		internal DevExpress.XtraEditors.SimpleButton sbtnReceipientDelete;
		internal DevExpress.XtraEditors.SimpleButton sbtnReceipientNew;
		internal DevExpress.XtraGrid.GridControl gctrReceipient;
		internal DevExpress.XtraGrid.Views.Grid.GridView gvReceipient;
		internal DevExpress.XtraEditors.ComboBoxEdit cbViewMemo;
		internal DevExpress.XtraEditors.SimpleButton sbtnMemoPrint;
		internal DevExpress.XtraEditors.SimpleButton sbtnMemoNew;
		internal DevExpress.XtraGrid.GridControl gctrMemo;
		internal DevExpress.XtraGrid.Views.Grid.GridView gvMemo;
		internal DevExpress.XtraGrid.Columns.GridColumn colnMemoID;
		internal DevExpress.XtraGrid.Columns.GridColumn colTitle;
		internal DevExpress.XtraGrid.Columns.GridColumn colPostUpdateDateTime;
		internal DevExpress.XtraGrid.Columns.GridColumn colRead;
		internal DevExpress.XtraEditors.SimpleButton sbtnUpdate;
		internal DevExpress.XtraEditors.MemoEdit memoedtMessage;
		internal DevExpress.XtraEditors.SimpleButton sbtnRecpGrpDelete;
		internal DevExpress.XtraEditors.SimpleButton sbtnRecpGrpEdit;
		internal DevExpress.XtraEditors.SimpleButton sbtnRecpGrpNew;
		internal DevExpress.XtraGrid.GridControl gctrRecpGrp;
		internal DevExpress.XtraGrid.Views.Grid.GridView gvRecpGrp;
		internal DevExpress.XtraEditors.SimpleButton sbtnRecpEntryDelete;
		internal DevExpress.XtraEditors.SimpleButton sbtnRecpEntryNew;
		internal DevExpress.XtraGrid.GridControl gctrRecpEntry;
		internal DevExpress.XtraGrid.Views.Grid.GridView gvRecpEntry;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
		internal DevExpress.XtraEditors.SimpleButton sbtnMemoUnpost;
		private System.Windows.Forms.Timer timer1;
		internal DevExpress.XtraEditors.SimpleButton sbtnRepliesAdd;
		internal DevExpress.XtraGrid.GridControl gctrReplies;
		internal DevExpress.XtraGrid.Views.Grid.GridView gvReplies;
		internal DevExpress.XtraEditors.SimpleButton sbtnRepliesUpdate;
		internal DevExpress.XtraEditors.SimpleButton sbtnRepliesView;
		internal DevExpress.XtraEditors.SimpleButton sbtnRepliesDelete;
		internal DevExpress.XtraGrid.Columns.GridColumn colRecipientType;
		internal DevExpress.XtraGrid.Columns.GridColumn colRecipient;
		internal DevExpress.XtraGrid.Columns.GridColumn colReceipientGroupID;
		internal DevExpress.XtraGrid.Columns.GridColumn colReceipientGroupCode;
		internal DevExpress.XtraGrid.Columns.GridColumn colDescription;
		internal DevExpress.XtraGrid.Columns.GridColumn colEmployeeID;
		internal DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
		internal DevExpress.XtraGrid.GridControl gridctrContact;
		internal DevExpress.XtraGrid.Views.Grid.GridView gvContact;
		internal DevExpress.XtraGrid.GridControl gridctrAppointment;
		internal DevExpress.XtraGrid.Views.Grid.GridView gvAppointment;
		internal DevExpress.XtraGrid.Columns.GridColumn colSalesDate;
		internal DevExpress.XtraGrid.Columns.GridColumn colSalesReceipt;
		internal DevExpress.XtraGrid.Columns.GridColumn colSalesMembershipID;
		internal DevExpress.XtraEditors.SimpleButton sbtnAppointmentDelete;
		internal DevExpress.XtraEditors.SimpleButton sbtnAppointmentPrint;
		internal DevExpress.XtraEditors.SimpleButton sbtnAppointmentEdit;
		internal DevExpress.XtraEditors.SimpleButton sbtnAppointmentNew;
		internal DevExpress.XtraGrid.Columns.GridColumn colAppointmentDate;
		internal DevExpress.XtraGrid.Columns.GridColumn colAppointmentStartDate;
		internal DevExpress.XtraGrid.Columns.GridColumn colAppointmentEndDate;
		internal DevExpress.XtraGrid.Columns.GridColumn colAppointmentOrganization;
		internal DevExpress.XtraGrid.Columns.GridColumn colAppointmentContact;
		internal DevExpress.XtraGrid.Columns.GridColumn colAppointmentRemarks;
		private DevExpress.XtraGrid.Columns.GridColumn colAppointmentTypeID;
		internal DevExpress.XtraEditors.SimpleButton sbtnContactDelete;
		internal DevExpress.XtraEditors.SimpleButton sbtnContactNew;
		internal DevExpress.XtraGrid.Columns.GridColumn colContactPerson;
		internal DevExpress.XtraGrid.Columns.GridColumn colContactOrganization;
		internal DevExpress.XtraGrid.Columns.GridColumn colContactMobile;
		internal DevExpress.XtraGrid.Columns.GridColumn colContactOfficeNo;
		internal DevExpress.XtraGrid.Columns.GridColumn colContactEmail;
		private DevExpress.XtraGrid.Columns.GridColumn colContactFax;
		private DevExpress.XtraGrid.Columns.GridColumn colContactAddress;
		internal DevExpress.XtraEditors.SimpleButton sbtnContactEdit;
		internal DevExpress.XtraGrid.GridControl gridctrTimesheet;
		internal DevExpress.XtraGrid.Views.Grid.GridView gvTimesheet;
		private DevExpress.XtraEditors.GroupControl groupControl9;
		internal DevExpress.XtraEditors.ComboBoxEdit cbTimesheetYear;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label11;
		internal DevExpress.XtraEditors.ComboBoxEdit cbTimesheetMonth;
		internal DevExpress.XtraEditors.SimpleButton sbtnTimesheetInquiry;
		internal DevExpress.XtraEditors.GroupControl groupLateness;
		internal DevExpress.XtraEditors.GroupControl groupControl13;
		private DevExpress.XtraEditors.GroupControl groupControl14;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		internal DevExpress.XtraEditors.GroupControl groupOvertime;
		internal DevExpress.XtraEditors.GroupControl groupControl15;
		private DevExpress.XtraEditors.GroupControl groupControl16;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		internal DevExpress.XtraGrid.Columns.GridColumn colTimesheetDate;
		internal DevExpress.XtraGrid.Columns.GridColumn colTimesheetRosterIn;
		internal DevExpress.XtraGrid.Columns.GridColumn colTimesheetRosterOut;
		internal DevExpress.XtraGrid.Columns.GridColumn colTimesheetBranchFirstTimeIn;
		internal DevExpress.XtraGrid.Columns.GridColumn colTimesheetFirstTimeIn;
		internal DevExpress.XtraGrid.Columns.GridColumn colTimesheetBranchLastTimeOut;
		private DevExpress.XtraGrid.Columns.GridColumn colTimesheetLastTimeOut;
		private DevExpress.XtraGrid.Columns.GridColumn colActionTakenByID;
		internal DevExpress.XtraEditors.ComboBoxEdit cbOvertimeYear;
		internal DevExpress.XtraEditors.ComboBoxEdit cbOvertimeMonth;
		internal DevExpress.XtraEditors.SimpleButton sbtnOvertimeInquiry;
		internal DevExpress.XtraEditors.SimpleButton sbtnApplyOvertime;
		internal DevExpress.XtraGrid.GridControl gridctrOvertime;
		internal DevExpress.XtraGrid.Views.Grid.GridView gvOvertime;
		internal DevExpress.XtraEditors.ComboBoxEdit cbLatenessYear;
		internal DevExpress.XtraEditors.ComboBoxEdit cbLatenessMonth;
		internal DevExpress.XtraEditors.SimpleButton sbtnLatenessInquiry;
		internal DevExpress.XtraGrid.GridControl gridctrLateness;
		internal DevExpress.XtraGrid.Views.Grid.GridView gvLateness;
		internal DevExpress.XtraEditors.SimpleButton sbtnOvertimeDelete;
		internal DevExpress.XtraGrid.Columns.GridColumn colOvertimeDate;
		internal DevExpress.XtraGrid.Columns.GridColumn colOvertimeHours;
		internal DevExpress.XtraGrid.Columns.GridColumn colOvertimeReason;
		internal DevExpress.XtraGrid.Columns.GridColumn colOvertimeCharging;
		internal DevExpress.XtraGrid.Columns.GridColumn colOvertimeManager;
		internal DevExpress.XtraGrid.Columns.GridColumn colOvertimeApprovingManagerID;
		internal DevExpress.XtraGrid.Columns.GridColumn colOvertimeStatus;
		internal DevExpress.XtraGrid.Columns.GridColumn colLatenessDate;
		internal DevExpress.XtraGrid.Columns.GridColumn colLatenessBranch;
		internal DevExpress.XtraGrid.Columns.GridColumn colLatenessType;
		internal DevExpress.XtraGrid.Columns.GridColumn colLatenessExpected;
		internal DevExpress.XtraGrid.Columns.GridColumn colLatenessActual;
		internal DevExpress.XtraGrid.Columns.GridColumn colLatenessLateness;
		private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit1;
		private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit2;
		internal DevExpress.XtraEditors.SimpleButton sbtnLeaveDelete;
		internal DevExpress.XtraEditors.SimpleButton sbtnLeaveApply;
		internal DevExpress.XtraGrid.GridControl gridctrLeaveDetail;
		internal DevExpress.XtraGrid.GridControl gridctrLeaveBalance;
		private DevExpress.XtraEditors.SimpleButton sbtnLeavePreviousMonth;
		private DevExpress.XtraEditors.SimpleButton sbtnLeaveNextMonth;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private ACMS.Control.ACMSRosterHeader acmsRosterHeader6;
		private ACMS.Control.ACMSRosterHeader acmsRosterHeader5;
		private ACMS.Control.ACMSRosterHeader acmsRosterHeader4;
		private ACMS.Control.ACMSRosterHeader acmsRosterHeader3;
		private ACMS.Control.ACMSRosterHeader acmsRosterHeader2;
		private ACMS.Control.ACMSRosterHeader acmsRosterHeader1;
		private DevExpress.XtraEditors.GroupControl groupControl2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		internal DevExpress.XtraGrid.Columns.GridColumn colLeaveStartTime;
		internal DevExpress.XtraGrid.Columns.GridColumn colLeaveEndTime;
		internal DevExpress.XtraGrid.Columns.GridColumn colLeaveTimeOff;
		internal DevExpress.XtraGrid.Columns.GridColumn colLeaveLeaveType;
		internal DevExpress.XtraGrid.Columns.GridColumn colLeaveReason;
		internal DevExpress.XtraGrid.Columns.GridColumn colLeaveLeaveStatus;
		private DevExpress.XtraGrid.Columns.GridColumn colLeaveApprovingManager;
		internal DevExpress.XtraGrid.Views.Grid.GridView gvLeave;
		private System.Windows.Forms.Label label25;
		internal DevExpress.XtraEditors.SimpleButton sbtnLeaveBalanceInquiry;
		private DevExpress.XtraBars.BarButtonItem barButtonItem1;
		internal System.Windows.Forms.MenuItem MenuItemChangePassword;
		internal DevExpress.XtraEditors.GroupControl groupLeaveRoster;
		private DevExpress.XtraEditors.GroupControl groupLeave;
		private DevExpress.XtraEditors.ComboBoxEdit cbLeaveBalance;
		internal DevExpress.XtraGrid.Views.Grid.GridView gvLeaveBalance;
		internal DevExpress.XtraGrid.Columns.GridColumn colLeaveBalanceDate;
		internal DevExpress.XtraGrid.Columns.GridColumn colLeaveBalanceTransaction;
		internal System.Windows.Forms.MenuItem MenuItemBlockMembershipID;
		internal System.Windows.Forms.MenuItem MenuItemResetMembershipID;
		private DevExpress.XtraEditors.GroupControl groupControl12;
		internal DevExpress.XtraEditors.ComboBoxEdit cbAppointmentYear;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		internal DevExpress.XtraEditors.ComboBoxEdit cbAppointmentMonth;
		internal DevExpress.XtraEditors.SimpleButton sbtnAppointmentInquiry;
		internal DevExpress.XtraGrid.Columns.GridColumn colLeaveBalanceNoOfDays;
		private DevExpress.XtraGrid.Columns.GridColumn colfFullDay;
		internal DevExpress.XtraEditors.SimpleButton sbtnLeaveEdit;
		private DevExpress.XtraBars.BarButtonItem barbtnClose;
		internal System.Windows.Forms.Label lblLeaveEmployeeID;
		private DevExpress.XtraEditors.LookUpEdit luedtLeaveEmployeeID;
		internal DevExpress.XtraGrid.Columns.GridColumn colAuthorID;
		private DevExpress.XtraGrid.Columns.GridColumn colAuthor;
		private DevExpress.XtraGrid.Columns.GridColumn colReplyEmployeeName;
		private DevExpress.XtraBars.BarStaticItem barstaticCurrentLogin;
		internal DevExpress.XtraBars.BarButtonItem bbiClose;
		internal DevExpress.XtraEditors.ComboBoxEdit cbMemoReceipient;
		private DevExpress.XtraGrid.Columns.GridColumn colRecipientID;
		private DevExpress.XtraGrid.Columns.GridColumn colSalesNettAmount;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private DevExpress.XtraEditors.LookUpEdit luedtCVAssignTo;
		private DevExpress.XtraEditors.LookUpEdit luedtSalesBranchCode;
		private DevExpress.XtraEditors.LookUpEdit luedtCommissionServiceBranch;
		private System.Windows.Forms.Label label30;
		internal DevExpress.XtraGrid.Columns.GridColumn colStaffSubject;
		private DevExpress.XtraEditors.TextEdit txtHomeNo;
		internal System.Windows.Forms.Label label31;
		private DevExpress.XtraEditors.ComboBoxEdit cbLeaveNYearID;
		private System.Windows.Forms.Label lblNYearID;
		private System.Windows.Forms.Label label33;
		private DevExpress.XtraEditors.DateEdit dateedtLeaveJoinDate;
		private System.Windows.Forms.Label label34;
		private DevExpress.XtraEditors.TextEdit txtLeaveEntitlement;
		private DevExpress.XtraGrid.Columns.GridColumn colLatenessRosterID;
		private DevExpress.XtraGrid.Columns.GridColumn colTimesheetLateness;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
		private DevExpress.XtraGrid.Columns.GridColumn colLeaveBalanceStatus;
		internal DevExpress.XtraGrid.Columns.GridColumn colReplyDate;
		internal DevExpress.XtraGrid.Columns.GridColumn colReplyEmployeeID;
		internal DevExpress.XtraGrid.Columns.GridColumn colReplyMessage;
		private System.Windows.Forms.Label label35;
		private DevExpress.XtraEditors.ComboBoxEdit cbLeaveStatus;
		private DevExpress.XtraGrid.Columns.GridColumn colLeaveStartDate;
		private DevExpress.XtraEditors.LookUpEdit luedtCVSubmitter;
		private System.Windows.Forms.Label lblCVSubmitter;
		internal DevExpress.XtraGrid.Columns.GridColumn colTimesheetManagerNameIn;
		private DevExpress.XtraGrid.Columns.GridColumn colTimesheetManagerNameOut;
		private DevExpress.XtraEditors.LookUpEdit luedtMemoEmployeeID;
		internal System.Windows.Forms.Label lblMemoEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn colTimesheetTotalLateness;
		internal DevExpress.XtraTab.XtraTabPage tabStaffOne;
		internal DevExpress.XtraTab.XtraTabPage tabStaffTwo;
		internal DevExpress.XtraTab.XtraTabPage tabStaffThree;
		internal DevExpress.XtraTab.XtraTabPage tabStaffFour;
		internal DevExpress.XtraTab.XtraTabPage tabStaffFive;
		internal DevExpress.XtraTab.XtraTabPage tabStaffSix;
		private DevExpress.XtraEditors.SimpleButton lblOne_1;
		private DevExpress.XtraEditors.SimpleButton lblOne_2;
		private DevExpress.XtraEditors.SimpleButton lblTwo_1;
		private DevExpress.XtraEditors.SimpleButton lblTwo_2;
		private DevExpress.XtraEditors.SimpleButton lblThree_1;
		private DevExpress.XtraEditors.SimpleButton lblThree_2;
		private DevExpress.XtraEditors.SimpleButton lblThree_3;
		private DevExpress.XtraEditors.SimpleButton lblSix_2;
		private DevExpress.XtraEditors.SimpleButton lblSix_1;
		private DevExpress.XtraEditors.SimpleButton lblFour_2;
		private DevExpress.XtraEditors.SimpleButton lblFour_1;
		internal DevExpress.XtraGrid.Columns.GridColumn nLeaveQuantity;
		private DevExpress.XtraGrid.Columns.GridColumn nUnpaidLeave;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.TextBox txtLeaveAdjust;
		private System.Windows.Forms.Button btnAdjust;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Button btnConvert;
		private System.Windows.Forms.TextBox txtDaysConvert;
        private DevExpress.XtraTab.XtraTabPage tabStaffSeven;
        private GroupControl groupControl17;
        private DevExpress.XtraTab.XtraTabPage tabStaffEight;
        private GroupControl groupControl18;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private LabelControl labelControl1;
        private MemoEdit memoEdit2;
        private Label label28;
        private LookUpEdit lookUpEdit4;
        private Label label40;
        private LookUpEdit lookUpEdit3;
        private Label label39;
        private LookUpEdit lookUpEdit2;
        private Label label38;
        private LookUpEdit lookUpEdit1;
		internal DevExpress.XtraEditors.SimpleButton sbtnAssign;
		
		#endregion
		
		#region Constructor & Dispose
		public frmStaff() 
		{
			
			//This call is required by the Windows Form Designer.
			InitializeComponent();
			
			//Add any initialization after the InitializeComponent() call
			/////////////////////////////////Initilize Font Styles
			
			
			FontStyle FontStyle001;
			
			FontStyle001 = FontStyle.Bold;
			FontStyle001  = (System.Drawing.FontStyle) System.Convert.ToInt32(FontStyle001  )+System.Convert.ToInt32(  FontStyle.Underline);
			
			Font001 = new Font("Microsoft Sans Serif", 10, FontStyle001);
			Font002 = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
			/////////////////////////////////Initilize Font Styles

			ACMS.XtraUtils.XtraEditors.SetDateEditFormat(this.Controls);			
		}
		
		//Form overrides dispose to clean up the component list.
		protected override void Dispose (bool disposing)
		{
			if (disposing)
			{
				if (!(components == null))
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		#endregion

		#region " Windows Form Designer generated code "
		private System.ComponentModel.IContainer components;
		
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		internal System.Windows.Forms.MainMenu MainMenu1;
		internal System.Windows.Forms.MenuItem MenuItem1;
		internal System.Windows.Forms.MenuItem MenuItem2;
		internal System.Windows.Forms.MenuItem MenuItem4;
		internal System.Windows.Forms.MenuItem MenuItem9;
		internal System.Windows.Forms.MenuItem MenuItem10;
		internal System.Windows.Forms.MenuItem MenuItem5;
		internal DevExpress.XtraBars.Bar Bar1;
		internal DevExpress.XtraBars.BarManager BarManager1;
		internal DevExpress.XtraBars.BarDockControl barDockControlTop;
		internal DevExpress.XtraBars.BarDockControl barDockControlBottom;
		internal DevExpress.XtraBars.BarDockControl barDockControlLeft;
		internal DevExpress.XtraBars.BarDockControl barDockControlRight;
		internal DevExpress.XtraBars.Bar Bar2;
		internal DevExpress.XtraBars.BarAndDockingController BarAndDockingController1;
		internal DevExpress.XtraTab.XtraTabControl tabStaff;
		internal DevExpress.XtraEditors.GroupControl groupMessages;
		internal DevExpress.XtraEditors.GroupControl groupMessagesEntry;
		internal DevExpress.XtraEditors.GroupControl GroupControl4;
		internal DevExpress.XtraEditors.GroupControl groupMessagesMemoInfo;
		internal DevExpress.XtraEditors.GroupControl GroupControl8;
		internal System.Windows.Forms.Label Label37;
		internal DevExpress.XtraEditors.GroupControl groupMessagesFollowUpAction;
		internal DevExpress.XtraEditors.GroupControl groupMessagesReceipient;
		internal DevExpress.XtraEditors.GroupControl GroupControl6;
		internal System.Windows.Forms.Label lblmnuMessagesReceipient;
		internal System.Windows.Forms.Label lblmnuMessagesFollowUpAction;
		internal System.Windows.Forms.Label lblmnuMessagesMemoInfo;
		internal DevExpress.XtraEditors.GroupControl groupReceipientGroup;
		internal DevExpress.XtraEditors.GroupControl GroupControl10;
		internal DevExpress.XtraEditors.GroupControl groupReceipientGroupEntry;
		internal DevExpress.XtraEditors.GroupControl groupReceipientGroupReceipientEntries;
		internal DevExpress.XtraEditors.GroupControl groupSales;
		internal DevExpress.XtraEditors.GroupControl groupSalesEntry;
		internal DevExpress.XtraEditors.GroupControl groupService;
		internal DevExpress.XtraEditors.GroupControl groupServiceEntry;
		internal DevExpress.XtraEditors.GroupControl groupContact;
		internal DevExpress.XtraEditors.GroupControl groupContactEntry;
		internal DevExpress.XtraEditors.GroupControl groupAppointment;
		internal DevExpress.XtraEditors.GroupControl groupAppointmentEntry;
		internal DevExpress.XtraEditors.GroupControl groupTimesheet;
		internal DevExpress.XtraEditors.GroupControl groupTimesheetEntry;
		internal DevExpress.XtraEditors.GroupControl groupCustomerVoice;
		internal System.Windows.Forms.Label lblmnuCustomerVoiceActionHistory;
		internal System.Windows.Forms.Label lblmnuCustomerVoiceCVDetails;
		internal DevExpress.XtraEditors.GroupControl GroupControl24;
		internal DevExpress.XtraEditors.GroupControl groupCustomerVoiceActionHistory;
		internal DevExpress.XtraEditors.GroupControl GroupControl26;
		internal DevExpress.XtraEditors.GroupControl groupCustomerVoiceCVDetails;
		internal DevExpress.XtraEditors.GroupControl GroupControl28;
		internal System.Windows.Forms.Label Label32;
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent ()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStaff));
            this.MainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.MenuItem1 = new System.Windows.Forms.MenuItem();
            this.MenuItem2 = new System.Windows.Forms.MenuItem();
            this.MenuItem4 = new System.Windows.Forms.MenuItem();
            this.MenuItemChangePassword = new System.Windows.Forms.MenuItem();
            this.MenuItemBlockMembershipID = new System.Windows.Forms.MenuItem();
            this.MenuItemResetMembershipID = new System.Windows.Forms.MenuItem();
            this.MenuItem9 = new System.Windows.Forms.MenuItem();
            this.MenuItem10 = new System.Windows.Forms.MenuItem();
            this.MenuItem5 = new System.Windows.Forms.MenuItem();
            this.Bar1 = new DevExpress.XtraBars.Bar();
            this.BarManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.Bar2 = new DevExpress.XtraBars.Bar();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnTimeCard = new DevExpress.XtraBars.BarButtonItem();
            this.barstaticCurrentLogin = new DevExpress.XtraBars.BarStaticItem();
            this.BarAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnClose = new DevExpress.XtraBars.BarButtonItem();
            this.tabStaff = new DevExpress.XtraTab.XtraTabControl();
            this.tabStaffOne = new DevExpress.XtraTab.XtraTabPage();
            this.lblOne_2 = new DevExpress.XtraEditors.SimpleButton();
            this.luedtMemoEmployeeID = new DevExpress.XtraEditors.LookUpEdit();
            this.lblMemoEmployeeID = new System.Windows.Forms.Label();
            this.groupMessages = new DevExpress.XtraEditors.GroupControl();
            this.lblmnuMessagesReceipient = new System.Windows.Forms.Label();
            this.lblmnuMessagesFollowUpAction = new System.Windows.Forms.Label();
            this.lblmnuMessagesMemoInfo = new System.Windows.Forms.Label();
            this.groupMessagesEntry = new DevExpress.XtraEditors.GroupControl();
            this.cbViewMemo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.sbtnMemoUnpost = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnMemoPrint = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnMemoNew = new DevExpress.XtraEditors.SimpleButton();
            this.gctrMemo = new DevExpress.XtraGrid.GridControl();
            this.gvMemo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colnMemoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPostUpdateDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuthorID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuthor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRead = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.groupMessagesFollowUpAction = new DevExpress.XtraEditors.GroupControl();
            this.GroupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.sbtnRepliesDelete = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnRepliesView = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnRepliesUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnRepliesAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gctrReplies = new DevExpress.XtraGrid.GridControl();
            this.gvReplies = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colReplyDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReplyEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReplyEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReplyMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupMessagesMemoInfo = new DevExpress.XtraEditors.GroupControl();
            this.GroupControl8 = new DevExpress.XtraEditors.GroupControl();
            this.sbtnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.memoedtMessage = new DevExpress.XtraEditors.MemoEdit();
            this.Label37 = new System.Windows.Forms.Label();
            this.groupMessagesReceipient = new DevExpress.XtraEditors.GroupControl();
            this.GroupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.cbMemoReceipient = new DevExpress.XtraEditors.ComboBoxEdit();
            this.sbtnReceipientDelete = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnReceipientNew = new DevExpress.XtraEditors.SimpleButton();
            this.gctrReceipient = new DevExpress.XtraGrid.GridControl();
            this.gvReceipient = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRecipientType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecipient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecipientID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupReceipientGroup = new DevExpress.XtraEditors.GroupControl();
            this.groupReceipientGroupEntry = new DevExpress.XtraEditors.GroupControl();
            this.sbtnRecpGrpDelete = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnRecpGrpEdit = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnRecpGrpNew = new DevExpress.XtraEditors.SimpleButton();
            this.gctrRecpGrp = new DevExpress.XtraGrid.GridControl();
            this.gvRecpGrp = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colReceipientGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceipientGroupCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupReceipientGroupReceipientEntries = new DevExpress.XtraEditors.GroupControl();
            this.GroupControl10 = new DevExpress.XtraEditors.GroupControl();
            this.sbtnRecpEntryDelete = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnRecpEntryNew = new DevExpress.XtraEditors.SimpleButton();
            this.gctrRecpEntry = new DevExpress.XtraGrid.GridControl();
            this.gvRecpEntry = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblOne_1 = new DevExpress.XtraEditors.SimpleButton();
            this.tabStaffTwo = new DevExpress.XtraTab.XtraTabPage();
            this.groupService = new DevExpress.XtraEditors.GroupControl();
            this.groupServiceEntry = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.luedtCommissionServiceBranch = new DevExpress.XtraEditors.LookUpEdit();
            this.label30 = new System.Windows.Forms.Label();
            this.cbServiceYear = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbServiceMonth = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbServiceServiceType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.sbtnServiceInquiry = new DevExpress.XtraEditors.SimpleButton();
            this.gctrService = new DevExpress.XtraGrid.GridControl();
            this.gvService = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colServicedtDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colServicestrBranchCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colServicestrMembershipID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colServicestrServiceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colServicestrCommission = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblTwo_1 = new DevExpress.XtraEditors.SimpleButton();
            this.lblTwo_2 = new DevExpress.XtraEditors.SimpleButton();
            this.groupSales = new DevExpress.XtraEditors.GroupControl();
            this.groupSalesEntry = new DevExpress.XtraEditors.GroupControl();
            this.groupControl7 = new DevExpress.XtraEditors.GroupControl();
            this.luedtSalesBranchCode = new DevExpress.XtraEditors.LookUpEdit();
            this.label16 = new System.Windows.Forms.Label();
            this.cbSalesYear = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbSalesMonth = new DevExpress.XtraEditors.ComboBoxEdit();
            this.sbtnSalesInquiry = new DevExpress.XtraEditors.SimpleButton();
            this.cbSalesType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gctrSales = new DevExpress.XtraGrid.GridControl();
            this.gvSales = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSalesDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesReceipt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesMembershipID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesNettAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabStaffThree = new DevExpress.XtraTab.XtraTabPage();
            this.lblThree_3 = new DevExpress.XtraEditors.SimpleButton();
            this.lblThree_1 = new DevExpress.XtraEditors.SimpleButton();
            this.lblThree_2 = new DevExpress.XtraEditors.SimpleButton();
            this.groupTimesheet = new DevExpress.XtraEditors.GroupControl();
            this.groupTimesheetEntry = new DevExpress.XtraEditors.GroupControl();
            this.groupControl9 = new DevExpress.XtraEditors.GroupControl();
            this.cbTimesheetYear = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbTimesheetMonth = new DevExpress.XtraEditors.ComboBoxEdit();
            this.sbtnTimesheetInquiry = new DevExpress.XtraEditors.SimpleButton();
            this.gridctrTimesheet = new DevExpress.XtraGrid.GridControl();
            this.gvTimesheet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTimesheetDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimesheetRosterIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimesheetRosterOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimesheetBranchFirstTimeIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimesheetBranchLastTimeOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimesheetFirstTimeIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimesheetLastTimeOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimesheetManagerNameIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimesheetManagerNameOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimesheetLateness = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colTimesheetTotalLateness = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupOvertime = new DevExpress.XtraEditors.GroupControl();
            this.groupControl15 = new DevExpress.XtraEditors.GroupControl();
            this.sbtnOvertimeDelete = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl16 = new DevExpress.XtraEditors.GroupControl();
            this.cbOvertimeYear = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cbOvertimeMonth = new DevExpress.XtraEditors.ComboBoxEdit();
            this.sbtnOvertimeInquiry = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnApplyOvertime = new DevExpress.XtraEditors.SimpleButton();
            this.gridctrOvertime = new DevExpress.XtraGrid.GridControl();
            this.gvOvertime = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOvertimeDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOvertimeHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOvertimeReason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOvertimeCharging = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOvertimeManager = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOvertimeApprovingManagerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOvertimeStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupLateness = new DevExpress.XtraEditors.GroupControl();
            this.groupControl13 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl14 = new DevExpress.XtraEditors.GroupControl();
            this.cbLatenessYear = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbLatenessMonth = new DevExpress.XtraEditors.ComboBoxEdit();
            this.sbtnLatenessInquiry = new DevExpress.XtraEditors.SimpleButton();
            this.gridctrLateness = new DevExpress.XtraGrid.GridControl();
            this.gvLateness = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLatenessRosterID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLatenessDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLatenessBranch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLatenessType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLatenessExpected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTimeEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.colLatenessActual = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTimeEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.colLatenessLateness = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabStaffFour = new DevExpress.XtraTab.XtraTabPage();
            this.lblFour_2 = new DevExpress.XtraEditors.SimpleButton();
            this.lblFour_1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupAppointment = new DevExpress.XtraEditors.GroupControl();
            this.groupAppointmentEntry = new DevExpress.XtraEditors.GroupControl();
            this.groupControl12 = new DevExpress.XtraEditors.GroupControl();
            this.cbAppointmentYear = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.cbAppointmentMonth = new DevExpress.XtraEditors.ComboBoxEdit();
            this.sbtnAppointmentInquiry = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnAppointmentDelete = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnAppointmentPrint = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnAppointmentEdit = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnAppointmentNew = new DevExpress.XtraEditors.SimpleButton();
            this.gridctrAppointment = new DevExpress.XtraGrid.GridControl();
            this.gvAppointment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAppointmentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAppointmentStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAppointmentEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAppointmentOrganization = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAppointmentContact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAppointmentTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAppointmentRemarks = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupContact = new DevExpress.XtraEditors.GroupControl();
            this.groupContactEntry = new DevExpress.XtraEditors.GroupControl();
            this.sbtnContactEdit = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnContactDelete = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnContactNew = new DevExpress.XtraEditors.SimpleButton();
            this.gridctrContact = new DevExpress.XtraGrid.GridControl();
            this.gvContact = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colContactPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContactOrganization = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContactMobile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContactOfficeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContactEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContactFax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContactAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabStaffFive = new DevExpress.XtraTab.XtraTabPage();
            this.groupCustomerVoice = new DevExpress.XtraEditors.GroupControl();
            this.lblmnuCustomerVoiceActionHistory = new System.Windows.Forms.Label();
            this.lblmnuCustomerVoiceCVDetails = new System.Windows.Forms.Label();
            this.GroupControl24 = new DevExpress.XtraEditors.GroupControl();
            this.luedtCVSubmitter = new DevExpress.XtraEditors.LookUpEdit();
            this.sbtnAssign = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnCVPrint = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnCVEdit = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnCVDelete = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnCVNew = new DevExpress.XtraEditors.SimpleButton();
            this.cbListCV = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gctrCV = new DevExpress.XtraGrid.GridControl();
            this.gvCV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRefNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDtReceived = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBranch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMembershipID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMemberName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubmittedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStaffSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentAssignedTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label17 = new System.Windows.Forms.Label();
            this.luedtCVAssignTo = new DevExpress.XtraEditors.LookUpEdit();
            this.lblCVSubmitter = new System.Windows.Forms.Label();
            this.groupCustomerVoiceActionHistory = new DevExpress.XtraEditors.GroupControl();
            this.GroupControl26 = new DevExpress.XtraEditors.GroupControl();
            this.sbtnNewCVAction = new DevExpress.XtraEditors.SimpleButton();
            this.gctrCVAction = new DevExpress.XtraGrid.GridControl();
            this.gvCVAction = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colActionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldtDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldtTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActionDetail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActionTakenBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActionTakenByID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupCustomerVoiceCVDetails = new DevExpress.XtraEditors.GroupControl();
            this.GroupControl28 = new DevExpress.XtraEditors.GroupControl();
            this.txtHomeNo = new DevExpress.XtraEditors.TextEdit();
            this.label31 = new System.Windows.Forms.Label();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.txtContactNo = new DevExpress.XtraEditors.TextEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.memoeditSummaryCV = new DevExpress.XtraEditors.MemoEdit();
            this.Label32 = new System.Windows.Forms.Label();
            this.tabStaffSix = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblSix_2 = new DevExpress.XtraEditors.SimpleButton();
            this.lblSix_1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupLeave = new DevExpress.XtraEditors.GroupControl();
            this.groupLeaveLeaveDetails = new DevExpress.XtraEditors.GroupControl();
            this.groupControl11 = new DevExpress.XtraEditors.GroupControl();
            this.cbLeaveStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label35 = new System.Windows.Forms.Label();
            this.txtLeaveEntitlement = new DevExpress.XtraEditors.TextEdit();
            this.label34 = new System.Windows.Forms.Label();
            this.dateedtLeaveJoinDate = new DevExpress.XtraEditors.DateEdit();
            this.label33 = new System.Windows.Forms.Label();
            this.sbtnLeaveEdit = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnLeaveDelete = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnLeaveApply = new DevExpress.XtraEditors.SimpleButton();
            this.gridctrLeaveDetail = new DevExpress.XtraGrid.GridControl();
            this.gvLeave = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLeaveStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeaveStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeaveEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nLeaveQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nUnpaidLeave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeaveTimeOff = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfFullDay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeaveLeaveType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeaveReason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeaveLeaveStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeaveApprovingManager = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbLeaveNYearID = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblNYearID = new System.Windows.Forms.Label();
            this.groupLeaveLeaveBalance = new DevExpress.XtraEditors.GroupControl();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.btnConvert = new System.Windows.Forms.Button();
            this.txtDaysConvert = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.btnAdjust = new System.Windows.Forms.Button();
            this.txtLeaveAdjust = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.sbtnLeaveBalanceInquiry = new DevExpress.XtraEditors.SimpleButton();
            this.label25 = new System.Windows.Forms.Label();
            this.cbLeaveBalance = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gridctrLeaveBalance = new DevExpress.XtraGrid.GridControl();
            this.gvLeaveBalance = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLeaveBalanceDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeaveBalanceTransaction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeaveBalanceStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeaveBalanceNoOfDays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupLeaveRoster = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.acmsRosterHeader6 = new ACMS.Control.ACMSRosterHeader();
            this.acmsRosterHeader5 = new ACMS.Control.ACMSRosterHeader();
            this.acmsRosterHeader4 = new ACMS.Control.ACMSRosterHeader();
            this.acmsRosterHeader3 = new ACMS.Control.ACMSRosterHeader();
            this.acmsRosterHeader2 = new ACMS.Control.ACMSRosterHeader();
            this.acmsRosterHeader1 = new ACMS.Control.ACMSRosterHeader();
            this.sbtnLeaveNextMonth = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnLeavePreviousMonth = new DevExpress.XtraEditors.SimpleButton();
            this.luedtLeaveEmployeeID = new DevExpress.XtraEditors.LookUpEdit();
            this.lblLeaveEmployeeID = new System.Windows.Forms.Label();
            this.tabStaffSeven = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl17 = new DevExpress.XtraEditors.GroupControl();
            this.tabStaffEight = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.memoEdit2 = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.lookUpEdit4 = new DevExpress.XtraEditors.LookUpEdit();
            this.label40 = new System.Windows.Forms.Label();
            this.lookUpEdit3 = new DevExpress.XtraEditors.LookUpEdit();
            this.label39 = new System.Windows.Forms.Label();
            this.lookUpEdit2 = new DevExpress.XtraEditors.LookUpEdit();
            this.label38 = new System.Windows.Forms.Label();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.label28 = new System.Windows.Forms.Label();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl18 = new DevExpress.XtraEditors.GroupControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabStaff)).BeginInit();
            this.tabStaff.SuspendLayout();
            this.tabStaffOne.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luedtMemoEmployeeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupMessages)).BeginInit();
            this.groupMessages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupMessagesEntry)).BeginInit();
            this.groupMessagesEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbViewMemo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gctrMemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupMessagesFollowUpAction)).BeginInit();
            this.groupMessagesFollowUpAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl4)).BeginInit();
            this.GroupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctrReplies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReplies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupMessagesMemoInfo)).BeginInit();
            this.groupMessagesMemoInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl8)).BeginInit();
            this.GroupControl8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoedtMessage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupMessagesReceipient)).BeginInit();
            this.groupMessagesReceipient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl6)).BeginInit();
            this.GroupControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbMemoReceipient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gctrReceipient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReceipient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupReceipientGroup)).BeginInit();
            this.groupReceipientGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupReceipientGroupEntry)).BeginInit();
            this.groupReceipientGroupEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctrRecpGrp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRecpGrp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupReceipientGroupReceipientEntries)).BeginInit();
            this.groupReceipientGroupReceipientEntries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl10)).BeginInit();
            this.GroupControl10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctrRecpEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRecpEntry)).BeginInit();
            this.tabStaffTwo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupService)).BeginInit();
            this.groupService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupServiceEntry)).BeginInit();
            this.groupServiceEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luedtCommissionServiceBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbServiceYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbServiceMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbServiceServiceType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gctrService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupSales)).BeginInit();
            this.groupSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupSalesEntry)).BeginInit();
            this.groupSalesEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).BeginInit();
            this.groupControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luedtSalesBranchCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSalesYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSalesMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSalesType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gctrSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSales)).BeginInit();
            this.tabStaffThree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupTimesheet)).BeginInit();
            this.groupTimesheet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupTimesheetEntry)).BeginInit();
            this.groupTimesheetEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl9)).BeginInit();
            this.groupControl9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbTimesheetYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTimesheetMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridctrTimesheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTimesheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupOvertime)).BeginInit();
            this.groupOvertime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl15)).BeginInit();
            this.groupControl15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl16)).BeginInit();
            this.groupControl16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbOvertimeYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOvertimeMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridctrOvertime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOvertime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupLateness)).BeginInit();
            this.groupLateness.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl13)).BeginInit();
            this.groupControl13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl14)).BeginInit();
            this.groupControl14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbLatenessYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLatenessMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridctrLateness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLateness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit2)).BeginInit();
            this.tabStaffFour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupAppointment)).BeginInit();
            this.groupAppointment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupAppointmentEntry)).BeginInit();
            this.groupAppointmentEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl12)).BeginInit();
            this.groupControl12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbAppointmentYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAppointmentMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridctrAppointment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAppointment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupContact)).BeginInit();
            this.groupContact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupContactEntry)).BeginInit();
            this.groupContactEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridctrContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvContact)).BeginInit();
            this.tabStaffFive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupCustomerVoice)).BeginInit();
            this.groupCustomerVoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl24)).BeginInit();
            this.GroupControl24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luedtCVSubmitter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbListCV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gctrCV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luedtCVAssignTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupCustomerVoiceActionHistory)).BeginInit();
            this.groupCustomerVoiceActionHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl26)).BeginInit();
            this.GroupControl26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctrCVAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCVAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupCustomerVoiceCVDetails)).BeginInit();
            this.groupCustomerVoiceCVDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl28)).BeginInit();
            this.GroupControl28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHomeNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoeditSummaryCV.Properties)).BeginInit();
            this.tabStaffSix.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupLeave)).BeginInit();
            this.groupLeave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupLeaveLeaveDetails)).BeginInit();
            this.groupLeaveLeaveDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl11)).BeginInit();
            this.groupControl11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbLeaveStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeaveEntitlement.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtLeaveJoinDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtLeaveJoinDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridctrLeaveDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLeave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLeaveNYearID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupLeaveLeaveBalance)).BeginInit();
            this.groupLeaveLeaveBalance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbLeaveBalance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridctrLeaveBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLeaveBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupLeaveRoster)).BeginInit();
            this.groupLeaveRoster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luedtLeaveEmployeeID.Properties)).BeginInit();
            this.tabStaffSeven.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl17)).BeginInit();
            this.tabStaffEight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit2.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl18)).BeginInit();
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
            this.MenuItem2.Click += new System.EventHandler(this.MenuItem2_Click);
            // 
            // MenuItem4
            // 
            this.MenuItem4.Index = 1;
            this.MenuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItemChangePassword,
            this.MenuItemBlockMembershipID,
            this.MenuItemResetMembershipID,
            this.MenuItem9,
            this.MenuItem10});
            this.MenuItem4.Text = "Tools";
            // 
            // MenuItemChangePassword
            // 
            this.MenuItemChangePassword.Index = 0;
            this.MenuItemChangePassword.Text = "Change Password";
            this.MenuItemChangePassword.Click += new System.EventHandler(this.MenuItemChangePassword_Click);
            // 
            // MenuItemBlockMembershipID
            // 
            this.MenuItemBlockMembershipID.Index = 1;
            this.MenuItemBlockMembershipID.Text = "Block Membership ID";
            this.MenuItemBlockMembershipID.Click += new System.EventHandler(this.MenuItemBlockMembershipID_Click);
            // 
            // MenuItemResetMembershipID
            // 
            this.MenuItemResetMembershipID.Index = 2;
            this.MenuItemResetMembershipID.Text = "Reset Membership ID";
            this.MenuItemResetMembershipID.Click += new System.EventHandler(this.MenuItemResetMembershipID_Click);
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
            // Bar1
            // 
            this.Bar1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bar1.Appearance.Options.UseFont = true;
            this.Bar1.BarName = "bnTopBar";
            this.Bar1.DockCol = 0;
            this.Bar1.DockRow = 0;
            this.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.Bar1.OptionsBar.MultiLine = true;
            this.Bar1.OptionsBar.UseWholeRow = true;
            this.Bar1.Text = "TopBar";
            // 
            // BarManager1
            // 
            this.BarManager1.AllowQuickCustomization = false;
            this.BarManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.Bar2});
            this.BarManager1.Controller = this.BarAndDockingController1;
            this.BarManager1.DockControls.Add(this.barDockControlTop);
            this.BarManager1.DockControls.Add(this.barDockControlBottom);
            this.BarManager1.DockControls.Add(this.barDockControlLeft);
            this.BarManager1.DockControls.Add(this.barDockControlRight);
            this.BarManager1.Form = this;
            this.BarManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiClose,
            this.barbtnTimeCard,
            this.barButtonItem1,
            this.barbtnClose,
            this.barstaticCurrentLogin});
            this.BarManager1.MainMenu = this.Bar2;
            this.BarManager1.MaxItemId = 6;
            // 
            // Bar2
            // 
            this.Bar2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bar2.Appearance.Options.UseFont = true;
            this.Bar2.BarName = "Custom 1";
            this.Bar2.DockCol = 0;
            this.Bar2.DockRow = 0;
            this.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.Bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiClose, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barbtnTimeCard, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barstaticCurrentLogin, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard)});
            this.Bar2.OptionsBar.MultiLine = true;
            this.Bar2.OptionsBar.UseWholeRow = true;
            this.Bar2.Text = "Custom 1";
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Close";
            this.bbiClose.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiClose.Glyph")));
            this.bbiClose.Id = 0;
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiLoginOut_ItemClick);
            // 
            // barbtnTimeCard
            // 
            this.barbtnTimeCard.Caption = "Time Card";
            this.barbtnTimeCard.Glyph = ((System.Drawing.Image)(resources.GetObject("barbtnTimeCard.Glyph")));
            this.barbtnTimeCard.Id = 1;
            this.barbtnTimeCard.Name = "barbtnTimeCard";
            this.barbtnTimeCard.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnTimeCard_ItemClick);
            // 
            // barstaticCurrentLogin
            // 
            this.barstaticCurrentLogin.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.barstaticCurrentLogin.Caption = "Current Login: {0}, {1}";
            this.barstaticCurrentLogin.Id = 4;
            this.barstaticCurrentLogin.Name = "barstaticCurrentLogin";
            this.barstaticCurrentLogin.OwnFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barstaticCurrentLogin.TextAlignment = System.Drawing.StringAlignment.Near;
            this.barstaticCurrentLogin.UseOwnFont = true;
            // 
            // BarAndDockingController1
            // 
            this.BarAndDockingController1.PaintStyleName = "WindowsXP";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "ACMS Manager";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 2;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barbtnClose
            // 
            this.barbtnClose.Id = 5;
            this.barbtnClose.Name = "barbtnClose";
            // 
            // tabStaff
            // 
            this.tabStaff.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabStaff.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabStaff.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tabStaff.Location = new System.Drawing.Point(0, 65);
            this.tabStaff.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tabStaff.Name = "tabStaff";
            this.tabStaff.PaintStyleName = "Skin";
            this.tabStaff.SelectedTabPage = this.tabStaffOne;
            this.tabStaff.Size = new System.Drawing.Size(1016, 648);
            this.tabStaff.TabIndex = 0;
            this.tabStaff.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabStaffOne,
            this.tabStaffTwo,
            this.tabStaffThree,
            this.tabStaffFour,
            this.tabStaffFive,
            this.tabStaffSix,
            this.tabStaffSeven,
            this.tabStaffEight});
            this.tabStaff.Text = "tabStaffMailbox";
            this.tabStaff.VisibleChanged += new System.EventHandler(this.tabStaff_VisibleChanged);
            this.tabStaff.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabStaff_SelectedPageChanged);
            this.tabStaff.Click += new System.EventHandler(this.tabStaff_Click);
            // 
            // tabStaffOne
            // 
            this.tabStaffOne.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabStaffOne.Appearance.Header.Options.UseFont = true;
            this.tabStaffOne.Controls.Add(this.lblOne_2);
            this.tabStaffOne.Controls.Add(this.luedtMemoEmployeeID);
            this.tabStaffOne.Controls.Add(this.lblMemoEmployeeID);
            this.tabStaffOne.Controls.Add(this.groupMessages);
            this.tabStaffOne.Controls.Add(this.groupReceipientGroup);
            this.tabStaffOne.Controls.Add(this.lblOne_1);
            this.tabStaffOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabStaffOne.Name = "tabStaffOne";
            this.tabStaffOne.Size = new System.Drawing.Size(1007, 612);
            this.tabStaffOne.Text = "Mailbox";
            this.tabStaffOne.VisibleChanged += new System.EventHandler(this.tabStaffMailbox_VisibleChanged);
            // 
            // lblOne_2
            // 
            this.lblOne_2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblOne_2.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblOne_2.Appearance.Options.UseFont = true;
            this.lblOne_2.Appearance.Options.UseForeColor = true;
            this.lblOne_2.Location = new System.Drawing.Point(160, 8);
            this.lblOne_2.Name = "lblOne_2";
            this.lblOne_2.Size = new System.Drawing.Size(138, 23);
            this.lblOne_2.TabIndex = 142;
            this.lblOne_2.Text = "Receipient Group";
            this.lblOne_2.Click += new System.EventHandler(this.lblOne_2_Click);
            // 
            // luedtMemoEmployeeID
            // 
            this.luedtMemoEmployeeID.Location = new System.Drawing.Point(776, 8);
            this.luedtMemoEmployeeID.Name = "luedtMemoEmployeeID";
            this.luedtMemoEmployeeID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luedtMemoEmployeeID.Size = new System.Drawing.Size(208, 20);
            this.luedtMemoEmployeeID.TabIndex = 33;
            this.luedtMemoEmployeeID.EditValueChanged += new System.EventHandler(this.luedtMemoEmployeeID_EditValueChanged);
            // 
            // lblMemoEmployeeID
            // 
            this.lblMemoEmployeeID.AutoSize = true;
            this.lblMemoEmployeeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemoEmployeeID.Location = new System.Drawing.Point(688, 8);
            this.lblMemoEmployeeID.Name = "lblMemoEmployeeID";
            this.lblMemoEmployeeID.Size = new System.Drawing.Size(88, 16);
            this.lblMemoEmployeeID.TabIndex = 34;
            this.lblMemoEmployeeID.Text = "Staff Name:";
            // 
            // groupMessages
            // 
            this.groupMessages.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupMessages.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupMessages.Controls.Add(this.lblmnuMessagesReceipient);
            this.groupMessages.Controls.Add(this.lblmnuMessagesFollowUpAction);
            this.groupMessages.Controls.Add(this.lblmnuMessagesMemoInfo);
            this.groupMessages.Controls.Add(this.groupMessagesEntry);
            this.groupMessages.Controls.Add(this.groupMessagesFollowUpAction);
            this.groupMessages.Controls.Add(this.groupMessagesMemoInfo);
            this.groupMessages.Controls.Add(this.groupMessagesReceipient);
            this.groupMessages.Location = new System.Drawing.Point(0, 34);
            this.groupMessages.Name = "groupMessages";
            this.groupMessages.ShowCaption = false;
            this.groupMessages.Size = new System.Drawing.Size(1007, 584);
            this.groupMessages.TabIndex = 13;
            this.groupMessages.Text = "GroupControl3";
            // 
            // lblmnuMessagesReceipient
            // 
            this.lblmnuMessagesReceipient.AutoSize = true;
            this.lblmnuMessagesReceipient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmnuMessagesReceipient.Location = new System.Drawing.Point(176, 320);
            this.lblmnuMessagesReceipient.Name = "lblmnuMessagesReceipient";
            this.lblmnuMessagesReceipient.Size = new System.Drawing.Size(83, 16);
            this.lblmnuMessagesReceipient.TabIndex = 2;
            this.lblmnuMessagesReceipient.Text = "Receipient";
            this.lblmnuMessagesReceipient.Click += new System.EventHandler(this.lblmnuMessagesReceipient_Click);
            // 
            // lblmnuMessagesFollowUpAction
            // 
            this.lblmnuMessagesFollowUpAction.AutoSize = true;
            this.lblmnuMessagesFollowUpAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmnuMessagesFollowUpAction.Location = new System.Drawing.Point(112, 320);
            this.lblmnuMessagesFollowUpAction.Name = "lblmnuMessagesFollowUpAction";
            this.lblmnuMessagesFollowUpAction.Size = new System.Drawing.Size(62, 16);
            this.lblmnuMessagesFollowUpAction.TabIndex = 1;
            this.lblmnuMessagesFollowUpAction.Text = "Replies";
            this.lblmnuMessagesFollowUpAction.Click += new System.EventHandler(this.lblmnuMessagesFollowUpAction_Click);
            // 
            // lblmnuMessagesMemoInfo
            // 
            this.lblmnuMessagesMemoInfo.AutoSize = true;
            this.lblmnuMessagesMemoInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmnuMessagesMemoInfo.Location = new System.Drawing.Point(24, 320);
            this.lblmnuMessagesMemoInfo.Name = "lblmnuMessagesMemoInfo";
            this.lblmnuMessagesMemoInfo.Size = new System.Drawing.Size(79, 16);
            this.lblmnuMessagesMemoInfo.TabIndex = 0;
            this.lblmnuMessagesMemoInfo.Text = "Memo Info";
            this.lblmnuMessagesMemoInfo.Click += new System.EventHandler(this.lblmnuMessagesMemoInfo_Click);
            // 
            // groupMessagesEntry
            // 
            this.groupMessagesEntry.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupMessagesEntry.Appearance.Options.UseBackColor = true;
            this.groupMessagesEntry.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupMessagesEntry.Controls.Add(this.cbViewMemo);
            this.groupMessagesEntry.Controls.Add(this.sbtnMemoUnpost);
            this.groupMessagesEntry.Controls.Add(this.sbtnMemoPrint);
            this.groupMessagesEntry.Controls.Add(this.sbtnMemoNew);
            this.groupMessagesEntry.Controls.Add(this.gctrMemo);
            this.groupMessagesEntry.Location = new System.Drawing.Point(8, 0);
            this.groupMessagesEntry.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupMessagesEntry.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupMessagesEntry.Name = "groupMessagesEntry";
            this.groupMessagesEntry.Size = new System.Drawing.Size(992, 312);
            this.groupMessagesEntry.TabIndex = 1;
            this.groupMessagesEntry.Text = "MESSAGES";
            // 
            // cbViewMemo
            // 
            this.cbViewMemo.EditValue = "All";
            this.cbViewMemo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cbViewMemo.Location = new System.Drawing.Point(16, 32);
            this.cbViewMemo.Name = "cbViewMemo";
            this.cbViewMemo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbViewMemo.Properties.Items.AddRange(new object[] {
            "All",
            "Personal Email",
            "Branch Bulletin",
            "Sent Memo"});
            this.cbViewMemo.Properties.PopupSizeable = true;
            this.cbViewMemo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbViewMemo.Size = new System.Drawing.Size(136, 20);
            this.cbViewMemo.TabIndex = 0;
            this.cbViewMemo.SelectedIndexChanged += new System.EventHandler(this.cbViewMemo_SelectedIndexChanged);
            // 
            // sbtnMemoUnpost
            // 
            this.sbtnMemoUnpost.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnMemoUnpost.Appearance.Options.UseFont = true;
            this.sbtnMemoUnpost.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnMemoUnpost.Location = new System.Drawing.Point(320, 32);
            this.sbtnMemoUnpost.Name = "sbtnMemoUnpost";
            this.sbtnMemoUnpost.Size = new System.Drawing.Size(72, 20);
            this.sbtnMemoUnpost.TabIndex = 3;
            this.sbtnMemoUnpost.Text = "Unpost";
            this.sbtnMemoUnpost.Click += new System.EventHandler(this.sbtnMemoUnpost_Click);
            // 
            // sbtnMemoPrint
            // 
            this.sbtnMemoPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnMemoPrint.Appearance.Options.UseFont = true;
            this.sbtnMemoPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnMemoPrint.Location = new System.Drawing.Point(240, 32);
            this.sbtnMemoPrint.Name = "sbtnMemoPrint";
            this.sbtnMemoPrint.Size = new System.Drawing.Size(72, 20);
            this.sbtnMemoPrint.TabIndex = 2;
            this.sbtnMemoPrint.Text = "Print";
            this.sbtnMemoPrint.Click += new System.EventHandler(this.sbtnMemoPrint_Click);
            // 
            // sbtnMemoNew
            // 
            this.sbtnMemoNew.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnMemoNew.Appearance.Options.UseFont = true;
            this.sbtnMemoNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnMemoNew.Location = new System.Drawing.Point(160, 32);
            this.sbtnMemoNew.Name = "sbtnMemoNew";
            this.sbtnMemoNew.Size = new System.Drawing.Size(72, 20);
            this.sbtnMemoNew.TabIndex = 1;
            this.sbtnMemoNew.Text = "New";
            this.sbtnMemoNew.Click += new System.EventHandler(this.sbtnMemoNew_Click);
            // 
            // gctrMemo
            // 
            this.gctrMemo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gctrMemo.EmbeddedNavigator.Name = "";
            this.gctrMemo.Location = new System.Drawing.Point(2, 62);
            this.gctrMemo.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gctrMemo.MainView = this.gvMemo;
            this.gctrMemo.Name = "gctrMemo";
            this.gctrMemo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gctrMemo.Size = new System.Drawing.Size(988, 248);
            this.gctrMemo.TabIndex = 4;
            this.gctrMemo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMemo});
            // 
            // gvMemo
            // 
            this.gvMemo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colnMemoID,
            this.colPostUpdateDateTime,
            this.colAuthorID,
            this.colAuthor,
            this.colTitle,
            this.colRead});
            this.gvMemo.GridControl = this.gctrMemo;
            this.gvMemo.Name = "gvMemo";
            this.gvMemo.OptionsBehavior.AllowIncrementalSearch = true;
            this.gvMemo.OptionsBehavior.Editable = false;
            this.gvMemo.OptionsCustomization.AllowFilter = false;
            this.gvMemo.OptionsView.ShowGroupPanel = false;
            this.gvMemo.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPostUpdateDateTime, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gvMemo.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvMemo_FocusedRowChanged);
            this.gvMemo.DataSourceChanged += new System.EventHandler(this.gvMemo_DataSourceChanged);
            // 
            // colnMemoID
            // 
            this.colnMemoID.Caption = "Memo ID";
            this.colnMemoID.FieldName = "nMemoID";
            this.colnMemoID.Name = "colnMemoID";
            this.colnMemoID.Visible = true;
            this.colnMemoID.VisibleIndex = 0;
            this.colnMemoID.Width = 115;
            // 
            // colPostUpdateDateTime
            // 
            this.colPostUpdateDateTime.Caption = "Post/Update Date Time";
            this.colPostUpdateDateTime.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm tt";
            this.colPostUpdateDateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colPostUpdateDateTime.FieldName = "dtLastEditDate";
            this.colPostUpdateDateTime.Name = "colPostUpdateDateTime";
            this.colPostUpdateDateTime.Visible = true;
            this.colPostUpdateDateTime.VisibleIndex = 1;
            this.colPostUpdateDateTime.Width = 172;
            // 
            // colAuthorID
            // 
            this.colAuthorID.Caption = "Author ID";
            this.colAuthorID.FieldName = "nEmployeeID";
            this.colAuthorID.Name = "colAuthorID";
            this.colAuthorID.Width = 201;
            // 
            // colAuthor
            // 
            this.colAuthor.Caption = "Author";
            this.colAuthor.FieldName = "strEmployeeName";
            this.colAuthor.Name = "colAuthor";
            this.colAuthor.Visible = true;
            this.colAuthor.VisibleIndex = 2;
            this.colAuthor.Width = 229;
            // 
            // colTitle
            // 
            this.colTitle.Caption = "Subject";
            this.colTitle.FieldName = "strTitle";
            this.colTitle.Name = "colTitle";
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 3;
            this.colTitle.Width = 405;
            // 
            // colRead
            // 
            this.colRead.Caption = "Read";
            this.colRead.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colRead.FieldName = "fRead";
            this.colRead.Name = "colRead";
            this.colRead.Visible = true;
            this.colRead.VisibleIndex = 4;
            this.colRead.Width = 46;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // groupMessagesFollowUpAction
            // 
            this.groupMessagesFollowUpAction.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupMessagesFollowUpAction.Appearance.Options.UseBackColor = true;
            this.groupMessagesFollowUpAction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupMessagesFollowUpAction.Controls.Add(this.GroupControl4);
            this.groupMessagesFollowUpAction.Location = new System.Drawing.Point(7, 344);
            this.groupMessagesFollowUpAction.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupMessagesFollowUpAction.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupMessagesFollowUpAction.Name = "groupMessagesFollowUpAction";
            this.groupMessagesFollowUpAction.Size = new System.Drawing.Size(992, 232);
            this.groupMessagesFollowUpAction.TabIndex = 12;
            this.groupMessagesFollowUpAction.Text = "Replies";
            // 
            // GroupControl4
            // 
            this.GroupControl4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.GroupControl4.Controls.Add(this.sbtnRepliesDelete);
            this.GroupControl4.Controls.Add(this.sbtnRepliesView);
            this.GroupControl4.Controls.Add(this.sbtnRepliesUpdate);
            this.GroupControl4.Controls.Add(this.sbtnRepliesAdd);
            this.GroupControl4.Controls.Add(this.gctrReplies);
            this.GroupControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupControl4.Location = new System.Drawing.Point(2, 19);
            this.GroupControl4.Name = "GroupControl4";
            this.GroupControl4.ShowCaption = false;
            this.GroupControl4.Size = new System.Drawing.Size(988, 211);
            this.GroupControl4.TabIndex = 0;
            this.GroupControl4.Text = "GroupControl1";
            // 
            // sbtnRepliesDelete
            // 
            this.sbtnRepliesDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnRepliesDelete.Appearance.Options.UseFont = true;
            this.sbtnRepliesDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnRepliesDelete.Location = new System.Drawing.Point(256, 16);
            this.sbtnRepliesDelete.Name = "sbtnRepliesDelete";
            this.sbtnRepliesDelete.Size = new System.Drawing.Size(72, 20);
            this.sbtnRepliesDelete.TabIndex = 3;
            this.sbtnRepliesDelete.Text = "Delete";
            this.sbtnRepliesDelete.Click += new System.EventHandler(this.sbtnRepliesDelete_Click);
            // 
            // sbtnRepliesView
            // 
            this.sbtnRepliesView.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnRepliesView.Appearance.Options.UseFont = true;
            this.sbtnRepliesView.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnRepliesView.Location = new System.Drawing.Point(96, 16);
            this.sbtnRepliesView.Name = "sbtnRepliesView";
            this.sbtnRepliesView.Size = new System.Drawing.Size(72, 20);
            this.sbtnRepliesView.TabIndex = 1;
            this.sbtnRepliesView.Text = "View";
            this.sbtnRepliesView.Click += new System.EventHandler(this.sbtnRepliesView_Click);
            // 
            // sbtnRepliesUpdate
            // 
            this.sbtnRepliesUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnRepliesUpdate.Appearance.Options.UseFont = true;
            this.sbtnRepliesUpdate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnRepliesUpdate.Location = new System.Drawing.Point(176, 16);
            this.sbtnRepliesUpdate.Name = "sbtnRepliesUpdate";
            this.sbtnRepliesUpdate.Size = new System.Drawing.Size(72, 20);
            this.sbtnRepliesUpdate.TabIndex = 2;
            this.sbtnRepliesUpdate.Text = "Update";
            this.sbtnRepliesUpdate.Click += new System.EventHandler(this.sbtnRepliesUpdate_Click);
            // 
            // sbtnRepliesAdd
            // 
            this.sbtnRepliesAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnRepliesAdd.Appearance.Options.UseFont = true;
            this.sbtnRepliesAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnRepliesAdd.Location = new System.Drawing.Point(16, 16);
            this.sbtnRepliesAdd.Name = "sbtnRepliesAdd";
            this.sbtnRepliesAdd.Size = new System.Drawing.Size(72, 20);
            this.sbtnRepliesAdd.TabIndex = 0;
            this.sbtnRepliesAdd.Text = "Add";
            this.sbtnRepliesAdd.Click += new System.EventHandler(this.sbtnRepliesAdd_Click);
            // 
            // gctrReplies
            // 
            this.gctrReplies.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gctrReplies.EmbeddedNavigator.Name = "";
            this.gctrReplies.Location = new System.Drawing.Point(2, 49);
            this.gctrReplies.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gctrReplies.MainView = this.gvReplies;
            this.gctrReplies.Name = "gctrReplies";
            this.gctrReplies.Size = new System.Drawing.Size(984, 160);
            this.gctrReplies.TabIndex = 4;
            this.gctrReplies.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReplies});
            // 
            // gvReplies
            // 
            this.gvReplies.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colReplyDate,
            this.colReplyEmployeeID,
            this.colReplyEmployeeName,
            this.colReplyMessage});
            this.gvReplies.GridControl = this.gctrReplies;
            this.gvReplies.Name = "gvReplies";
            this.gvReplies.OptionsBehavior.AllowIncrementalSearch = true;
            this.gvReplies.OptionsBehavior.Editable = false;
            this.gvReplies.OptionsCustomization.AllowFilter = false;
            this.gvReplies.OptionsView.ShowGroupPanel = false;
            this.gvReplies.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colReplyDate, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // colReplyDate
            // 
            this.colReplyDate.Caption = "Date";
            this.colReplyDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colReplyDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colReplyDate.FieldName = "dtDate";
            this.colReplyDate.Name = "colReplyDate";
            this.colReplyDate.Visible = true;
            this.colReplyDate.VisibleIndex = 0;
            this.colReplyDate.Width = 143;
            // 
            // colReplyEmployeeID
            // 
            this.colReplyEmployeeID.Caption = "Employee ID";
            this.colReplyEmployeeID.FieldName = "nEmployeeID";
            this.colReplyEmployeeID.Name = "colReplyEmployeeID";
            this.colReplyEmployeeID.Width = 209;
            // 
            // colReplyEmployeeName
            // 
            this.colReplyEmployeeName.Caption = "Employee";
            this.colReplyEmployeeName.FieldName = "strEmployeeName";
            this.colReplyEmployeeName.Name = "colReplyEmployeeName";
            this.colReplyEmployeeName.Visible = true;
            this.colReplyEmployeeName.VisibleIndex = 1;
            this.colReplyEmployeeName.Width = 247;
            // 
            // colReplyMessage
            // 
            this.colReplyMessage.Caption = "Message";
            this.colReplyMessage.FieldName = "strMessage";
            this.colReplyMessage.Name = "colReplyMessage";
            this.colReplyMessage.Visible = true;
            this.colReplyMessage.VisibleIndex = 2;
            this.colReplyMessage.Width = 569;
            // 
            // groupMessagesMemoInfo
            // 
            this.groupMessagesMemoInfo.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupMessagesMemoInfo.Appearance.Options.UseBackColor = true;
            this.groupMessagesMemoInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupMessagesMemoInfo.Controls.Add(this.GroupControl8);
            this.groupMessagesMemoInfo.Location = new System.Drawing.Point(7, 344);
            this.groupMessagesMemoInfo.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupMessagesMemoInfo.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupMessagesMemoInfo.Name = "groupMessagesMemoInfo";
            this.groupMessagesMemoInfo.Size = new System.Drawing.Size(992, 232);
            this.groupMessagesMemoInfo.TabIndex = 13;
            this.groupMessagesMemoInfo.Text = "MEMO INFO";
            this.groupMessagesMemoInfo.VisibleChanged += new System.EventHandler(this.groupMessagesMemoInfo_VisibleChanged);
            // 
            // GroupControl8
            // 
            this.GroupControl8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.GroupControl8.Controls.Add(this.sbtnUpdate);
            this.GroupControl8.Controls.Add(this.memoedtMessage);
            this.GroupControl8.Controls.Add(this.Label37);
            this.GroupControl8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupControl8.Location = new System.Drawing.Point(2, 19);
            this.GroupControl8.Name = "GroupControl8";
            this.GroupControl8.ShowCaption = false;
            this.GroupControl8.Size = new System.Drawing.Size(988, 211);
            this.GroupControl8.TabIndex = 0;
            this.GroupControl8.Text = "GroupControl1";
            // 
            // sbtnUpdate
            // 
            this.sbtnUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnUpdate.Appearance.Options.UseFont = true;
            this.sbtnUpdate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnUpdate.Location = new System.Drawing.Point(656, 180);
            this.sbtnUpdate.Name = "sbtnUpdate";
            this.sbtnUpdate.Size = new System.Drawing.Size(72, 20);
            this.sbtnUpdate.TabIndex = 1;
            this.sbtnUpdate.Text = "Update";
            this.sbtnUpdate.Click += new System.EventHandler(this.sbtnUpdate_Click);
            // 
            // memoedtMessage
            // 
            this.memoedtMessage.EditValue = "";
            this.memoedtMessage.Location = new System.Drawing.Point(88, 16);
            this.memoedtMessage.Name = "memoedtMessage";
            this.memoedtMessage.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memoedtMessage.Properties.Appearance.Options.UseFont = true;
            this.memoedtMessage.Properties.MaxLength = 1000;
            this.memoedtMessage.Size = new System.Drawing.Size(560, 184);
            this.memoedtMessage.TabIndex = 0;
            // 
            // Label37
            // 
            this.Label37.AutoSize = true;
            this.Label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label37.Location = new System.Drawing.Point(16, 16);
            this.Label37.Name = "Label37";
            this.Label37.Size = new System.Drawing.Size(72, 16);
            this.Label37.TabIndex = 16;
            this.Label37.Text = "Message";
            // 
            // groupMessagesReceipient
            // 
            this.groupMessagesReceipient.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupMessagesReceipient.Appearance.Options.UseBackColor = true;
            this.groupMessagesReceipient.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupMessagesReceipient.Controls.Add(this.GroupControl6);
            this.groupMessagesReceipient.Location = new System.Drawing.Point(7, 344);
            this.groupMessagesReceipient.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupMessagesReceipient.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupMessagesReceipient.Name = "groupMessagesReceipient";
            this.groupMessagesReceipient.Size = new System.Drawing.Size(992, 232);
            this.groupMessagesReceipient.TabIndex = 14;
            this.groupMessagesReceipient.Text = "RECEIPIENT";
            // 
            // GroupControl6
            // 
            this.GroupControl6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.GroupControl6.Controls.Add(this.cbMemoReceipient);
            this.GroupControl6.Controls.Add(this.sbtnReceipientDelete);
            this.GroupControl6.Controls.Add(this.sbtnReceipientNew);
            this.GroupControl6.Controls.Add(this.gctrReceipient);
            this.GroupControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupControl6.Location = new System.Drawing.Point(2, 19);
            this.GroupControl6.Name = "GroupControl6";
            this.GroupControl6.ShowCaption = false;
            this.GroupControl6.Size = new System.Drawing.Size(988, 211);
            this.GroupControl6.TabIndex = 0;
            this.GroupControl6.Text = "GroupControl1";
            // 
            // cbMemoReceipient
            // 
            this.cbMemoReceipient.EditValue = "Branch Group";
            this.cbMemoReceipient.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cbMemoReceipient.Location = new System.Drawing.Point(8, 16);
            this.cbMemoReceipient.Name = "cbMemoReceipient";
            this.cbMemoReceipient.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbMemoReceipient.Properties.Items.AddRange(new object[] {
            "Branch Group",
            "Department Group",
            "Personal Group",
            "Employee"});
            this.cbMemoReceipient.Properties.PopupSizeable = true;
            this.cbMemoReceipient.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbMemoReceipient.Size = new System.Drawing.Size(136, 20);
            this.cbMemoReceipient.TabIndex = 0;
            this.cbMemoReceipient.SelectedIndexChanged += new System.EventHandler(this.cbMemoReceipient_SelectedIndexChanged);
            // 
            // sbtnReceipientDelete
            // 
            this.sbtnReceipientDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnReceipientDelete.Appearance.Options.UseFont = true;
            this.sbtnReceipientDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnReceipientDelete.Location = new System.Drawing.Point(232, 16);
            this.sbtnReceipientDelete.Name = "sbtnReceipientDelete";
            this.sbtnReceipientDelete.Size = new System.Drawing.Size(72, 20);
            this.sbtnReceipientDelete.TabIndex = 2;
            this.sbtnReceipientDelete.Text = "Delete";
            this.sbtnReceipientDelete.Click += new System.EventHandler(this.sbtnReceipientDelete_Click);
            // 
            // sbtnReceipientNew
            // 
            this.sbtnReceipientNew.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnReceipientNew.Appearance.Options.UseFont = true;
            this.sbtnReceipientNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnReceipientNew.Location = new System.Drawing.Point(152, 16);
            this.sbtnReceipientNew.Name = "sbtnReceipientNew";
            this.sbtnReceipientNew.Size = new System.Drawing.Size(72, 20);
            this.sbtnReceipientNew.TabIndex = 1;
            this.sbtnReceipientNew.Text = "New";
            this.sbtnReceipientNew.Click += new System.EventHandler(this.sbtnReceipientNew_Click);
            // 
            // gctrReceipient
            // 
            this.gctrReceipient.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gctrReceipient.EmbeddedNavigator.Name = "";
            this.gctrReceipient.Location = new System.Drawing.Point(2, 49);
            this.gctrReceipient.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gctrReceipient.MainView = this.gvReceipient;
            this.gctrReceipient.Name = "gctrReceipient";
            this.gctrReceipient.Size = new System.Drawing.Size(984, 160);
            this.gctrReceipient.TabIndex = 3;
            this.gctrReceipient.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReceipient});
            // 
            // gvReceipient
            // 
            this.gvReceipient.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRecipientType,
            this.colRecipient,
            this.colRecipientID});
            this.gvReceipient.GridControl = this.gctrReceipient;
            this.gvReceipient.Name = "gvReceipient";
            this.gvReceipient.OptionsBehavior.AllowIncrementalSearch = true;
            this.gvReceipient.OptionsBehavior.Editable = false;
            this.gvReceipient.OptionsCustomization.AllowFilter = false;
            this.gvReceipient.OptionsView.ShowGroupPanel = false;
            // 
            // colRecipientType
            // 
            this.colRecipientType.Caption = "Type";
            this.colRecipientType.FieldName = "Type";
            this.colRecipientType.Name = "colRecipientType";
            this.colRecipientType.Visible = true;
            this.colRecipientType.VisibleIndex = 0;
            this.colRecipientType.Width = 223;
            // 
            // colRecipient
            // 
            this.colRecipient.Caption = "Receipient";
            this.colRecipient.FieldName = "Receipient";
            this.colRecipient.Name = "colRecipient";
            this.colRecipient.Visible = true;
            this.colRecipient.VisibleIndex = 1;
            this.colRecipient.Width = 558;
            // 
            // colRecipientID
            // 
            this.colRecipientID.Caption = "Receipient ID";
            this.colRecipientID.FieldName = "nReceipientID";
            this.colRecipientID.Name = "colRecipientID";
            this.colRecipientID.Width = 178;
            // 
            // groupReceipientGroup
            // 
            this.groupReceipientGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupReceipientGroup.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupReceipientGroup.Controls.Add(this.groupReceipientGroupEntry);
            this.groupReceipientGroup.Controls.Add(this.groupReceipientGroupReceipientEntries);
            this.groupReceipientGroup.Location = new System.Drawing.Point(0, 34);
            this.groupReceipientGroup.Name = "groupReceipientGroup";
            this.groupReceipientGroup.ShowCaption = false;
            this.groupReceipientGroup.Size = new System.Drawing.Size(1007, 584);
            this.groupReceipientGroup.TabIndex = 14;
            this.groupReceipientGroup.Text = "GroupControl3";
            // 
            // groupReceipientGroupEntry
            // 
            this.groupReceipientGroupEntry.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupReceipientGroupEntry.Appearance.Options.UseBackColor = true;
            this.groupReceipientGroupEntry.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupReceipientGroupEntry.Controls.Add(this.sbtnRecpGrpDelete);
            this.groupReceipientGroupEntry.Controls.Add(this.sbtnRecpGrpEdit);
            this.groupReceipientGroupEntry.Controls.Add(this.sbtnRecpGrpNew);
            this.groupReceipientGroupEntry.Controls.Add(this.gctrRecpGrp);
            this.groupReceipientGroupEntry.Location = new System.Drawing.Point(8, 0);
            this.groupReceipientGroupEntry.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupReceipientGroupEntry.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupReceipientGroupEntry.Name = "groupReceipientGroupEntry";
            this.groupReceipientGroupEntry.Size = new System.Drawing.Size(992, 312);
            this.groupReceipientGroupEntry.TabIndex = 1;
            this.groupReceipientGroupEntry.Text = "RECEIPIENT GROUP";
            // 
            // sbtnRecpGrpDelete
            // 
            this.sbtnRecpGrpDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnRecpGrpDelete.Appearance.Options.UseFont = true;
            this.sbtnRecpGrpDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnRecpGrpDelete.Location = new System.Drawing.Point(176, 32);
            this.sbtnRecpGrpDelete.Name = "sbtnRecpGrpDelete";
            this.sbtnRecpGrpDelete.Size = new System.Drawing.Size(72, 20);
            this.sbtnRecpGrpDelete.TabIndex = 2;
            this.sbtnRecpGrpDelete.Text = "Delete";
            this.sbtnRecpGrpDelete.Click += new System.EventHandler(this.sbtnRecpGrpDelete_Click);
            // 
            // sbtnRecpGrpEdit
            // 
            this.sbtnRecpGrpEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnRecpGrpEdit.Appearance.Options.UseFont = true;
            this.sbtnRecpGrpEdit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnRecpGrpEdit.Location = new System.Drawing.Point(96, 32);
            this.sbtnRecpGrpEdit.Name = "sbtnRecpGrpEdit";
            this.sbtnRecpGrpEdit.Size = new System.Drawing.Size(72, 20);
            this.sbtnRecpGrpEdit.TabIndex = 1;
            this.sbtnRecpGrpEdit.Text = "Edit";
            this.sbtnRecpGrpEdit.Click += new System.EventHandler(this.sbtnRecpGrpEdit_Click);
            // 
            // sbtnRecpGrpNew
            // 
            this.sbtnRecpGrpNew.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnRecpGrpNew.Appearance.Options.UseFont = true;
            this.sbtnRecpGrpNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnRecpGrpNew.Location = new System.Drawing.Point(16, 32);
            this.sbtnRecpGrpNew.Name = "sbtnRecpGrpNew";
            this.sbtnRecpGrpNew.Size = new System.Drawing.Size(72, 20);
            this.sbtnRecpGrpNew.TabIndex = 0;
            this.sbtnRecpGrpNew.Text = "New";
            this.sbtnRecpGrpNew.Click += new System.EventHandler(this.sbtnRecpGrpNew_Click);
            // 
            // gctrRecpGrp
            // 
            this.gctrRecpGrp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gctrRecpGrp.EmbeddedNavigator.Name = "";
            this.gctrRecpGrp.Location = new System.Drawing.Point(2, 62);
            this.gctrRecpGrp.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gctrRecpGrp.MainView = this.gvRecpGrp;
            this.gctrRecpGrp.Name = "gctrRecpGrp";
            this.gctrRecpGrp.Size = new System.Drawing.Size(988, 248);
            this.gctrRecpGrp.TabIndex = 3;
            this.gctrRecpGrp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRecpGrp});
            // 
            // gvRecpGrp
            // 
            this.gvRecpGrp.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colReceipientGroupID,
            this.colReceipientGroupCode,
            this.colDescription});
            this.gvRecpGrp.GridControl = this.gctrRecpGrp;
            this.gvRecpGrp.Name = "gvRecpGrp";
            this.gvRecpGrp.OptionsBehavior.AllowIncrementalSearch = true;
            this.gvRecpGrp.OptionsBehavior.Editable = false;
            this.gvRecpGrp.OptionsCustomization.AllowFilter = false;
            this.gvRecpGrp.OptionsView.ShowGroupPanel = false;
            this.gvRecpGrp.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvRecpGrp_FocusedRowChanged);
            this.gvRecpGrp.DataSourceChanged += new System.EventHandler(this.gvRecpGrp_DataSourceChanged);
            // 
            // colReceipientGroupID
            // 
            this.colReceipientGroupID.Caption = "Group ID";
            this.colReceipientGroupID.FieldName = "nMemoGroupID";
            this.colReceipientGroupID.Name = "colReceipientGroupID";
            this.colReceipientGroupID.Visible = true;
            this.colReceipientGroupID.VisibleIndex = 0;
            this.colReceipientGroupID.Width = 110;
            // 
            // colReceipientGroupCode
            // 
            this.colReceipientGroupCode.Caption = "Receipient Group Code";
            this.colReceipientGroupCode.FieldName = "strMemoGroupCode";
            this.colReceipientGroupCode.Name = "colReceipientGroupCode";
            this.colReceipientGroupCode.Visible = true;
            this.colReceipientGroupCode.VisibleIndex = 1;
            this.colReceipientGroupCode.Width = 417;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "strDescription";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 2;
            this.colDescription.Width = 440;
            // 
            // groupReceipientGroupReceipientEntries
            // 
            this.groupReceipientGroupReceipientEntries.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupReceipientGroupReceipientEntries.Appearance.Options.UseBackColor = true;
            this.groupReceipientGroupReceipientEntries.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupReceipientGroupReceipientEntries.Controls.Add(this.GroupControl10);
            this.groupReceipientGroupReceipientEntries.Location = new System.Drawing.Point(7, 320);
            this.groupReceipientGroupReceipientEntries.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupReceipientGroupReceipientEntries.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupReceipientGroupReceipientEntries.Name = "groupReceipientGroupReceipientEntries";
            this.groupReceipientGroupReceipientEntries.Size = new System.Drawing.Size(992, 256);
            this.groupReceipientGroupReceipientEntries.TabIndex = 14;
            this.groupReceipientGroupReceipientEntries.Text = "RECEIPIENT ENTRIES";
            // 
            // GroupControl10
            // 
            this.GroupControl10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.GroupControl10.Controls.Add(this.sbtnRecpEntryDelete);
            this.GroupControl10.Controls.Add(this.sbtnRecpEntryNew);
            this.GroupControl10.Controls.Add(this.gctrRecpEntry);
            this.GroupControl10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupControl10.Location = new System.Drawing.Point(2, 19);
            this.GroupControl10.Name = "GroupControl10";
            this.GroupControl10.ShowCaption = false;
            this.GroupControl10.Size = new System.Drawing.Size(988, 235);
            this.GroupControl10.TabIndex = 0;
            this.GroupControl10.Text = "GroupControl1";
            // 
            // sbtnRecpEntryDelete
            // 
            this.sbtnRecpEntryDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnRecpEntryDelete.Appearance.Options.UseFont = true;
            this.sbtnRecpEntryDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnRecpEntryDelete.Location = new System.Drawing.Point(96, 16);
            this.sbtnRecpEntryDelete.Name = "sbtnRecpEntryDelete";
            this.sbtnRecpEntryDelete.Size = new System.Drawing.Size(72, 20);
            this.sbtnRecpEntryDelete.TabIndex = 1;
            this.sbtnRecpEntryDelete.Text = "Delete";
            this.sbtnRecpEntryDelete.Click += new System.EventHandler(this.sbtnRecpEntryDelete_Click);
            // 
            // sbtnRecpEntryNew
            // 
            this.sbtnRecpEntryNew.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnRecpEntryNew.Appearance.Options.UseFont = true;
            this.sbtnRecpEntryNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnRecpEntryNew.Location = new System.Drawing.Point(16, 16);
            this.sbtnRecpEntryNew.Name = "sbtnRecpEntryNew";
            this.sbtnRecpEntryNew.Size = new System.Drawing.Size(72, 20);
            this.sbtnRecpEntryNew.TabIndex = 0;
            this.sbtnRecpEntryNew.Text = "New";
            this.sbtnRecpEntryNew.Click += new System.EventHandler(this.sbtnRecpEntryNew_Click);
            // 
            // gctrRecpEntry
            // 
            this.gctrRecpEntry.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gctrRecpEntry.EmbeddedNavigator.Name = "";
            this.gctrRecpEntry.Location = new System.Drawing.Point(2, 49);
            this.gctrRecpEntry.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gctrRecpEntry.MainView = this.gvRecpEntry;
            this.gctrRecpEntry.Name = "gctrRecpEntry";
            this.gctrRecpEntry.Size = new System.Drawing.Size(984, 184);
            this.gctrRecpEntry.TabIndex = 2;
            this.gctrRecpEntry.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRecpEntry});
            // 
            // gvRecpEntry
            // 
            this.gvRecpEntry.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmployeeID,
            this.colEmployeeName});
            this.gvRecpEntry.GridControl = this.gctrRecpEntry;
            this.gvRecpEntry.Name = "gvRecpEntry";
            this.gvRecpEntry.OptionsBehavior.AllowIncrementalSearch = true;
            this.gvRecpEntry.OptionsBehavior.Editable = false;
            this.gvRecpEntry.OptionsCustomization.AllowFilter = false;
            this.gvRecpEntry.OptionsView.ShowGroupPanel = false;
            // 
            // colEmployeeID
            // 
            this.colEmployeeID.Caption = "EmployeeID";
            this.colEmployeeID.FieldName = "nEmployeeID";
            this.colEmployeeID.Name = "colEmployeeID";
            this.colEmployeeID.Visible = true;
            this.colEmployeeID.VisibleIndex = 0;
            this.colEmployeeID.Width = 90;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Caption = "Employee Name";
            this.colEmployeeName.FieldName = "strEmployeeName";
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 1;
            this.colEmployeeName.Width = 209;
            // 
            // lblOne_1
            // 
            this.lblOne_1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblOne_1.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblOne_1.Appearance.Options.UseFont = true;
            this.lblOne_1.Appearance.Options.UseForeColor = true;
            this.lblOne_1.Location = new System.Drawing.Point(8, 8);
            this.lblOne_1.Name = "lblOne_1";
            this.lblOne_1.Size = new System.Drawing.Size(138, 23);
            this.lblOne_1.TabIndex = 141;
            this.lblOne_1.Text = "Messages";
            this.lblOne_1.Click += new System.EventHandler(this.lblOne_1_Click);
            // 
            // tabStaffTwo
            // 
            this.tabStaffTwo.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabStaffTwo.Appearance.Header.Options.UseFont = true;
            this.tabStaffTwo.Controls.Add(this.groupService);
            this.tabStaffTwo.Controls.Add(this.lblTwo_1);
            this.tabStaffTwo.Controls.Add(this.lblTwo_2);
            this.tabStaffTwo.Controls.Add(this.groupSales);
            this.tabStaffTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabStaffTwo.Name = "tabStaffTwo";
            this.tabStaffTwo.PageVisible = false;
            this.tabStaffTwo.Size = new System.Drawing.Size(1007, 612);
            this.tabStaffTwo.Text = "Commission";
            this.tabStaffTwo.VisibleChanged += new System.EventHandler(this.tabStaffCommision_VisibleChanged);
            // 
            // groupService
            // 
            this.groupService.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupService.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupService.Controls.Add(this.groupServiceEntry);
            this.groupService.Location = new System.Drawing.Point(0, 34);
            this.groupService.Name = "groupService";
            this.groupService.ShowCaption = false;
            this.groupService.Size = new System.Drawing.Size(1007, 584);
            this.groupService.TabIndex = 15;
            this.groupService.Text = "GroupControl3";
            // 
            // groupServiceEntry
            // 
            this.groupServiceEntry.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupServiceEntry.Appearance.Options.UseBackColor = true;
            this.groupServiceEntry.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupServiceEntry.Controls.Add(this.groupControl3);
            this.groupServiceEntry.Controls.Add(this.gctrService);
            this.groupServiceEntry.Location = new System.Drawing.Point(8, 0);
            this.groupServiceEntry.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupServiceEntry.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupServiceEntry.Name = "groupServiceEntry";
            this.groupServiceEntry.Size = new System.Drawing.Size(992, 576);
            this.groupServiceEntry.TabIndex = 1;
            this.groupServiceEntry.Text = "SERVICE";
            // 
            // groupControl3
            // 
            this.groupControl3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupControl3.Controls.Add(this.luedtCommissionServiceBranch);
            this.groupControl3.Controls.Add(this.label30);
            this.groupControl3.Controls.Add(this.cbServiceYear);
            this.groupControl3.Controls.Add(this.label5);
            this.groupControl3.Controls.Add(this.label3);
            this.groupControl3.Controls.Add(this.label2);
            this.groupControl3.Controls.Add(this.cbServiceMonth);
            this.groupControl3.Controls.Add(this.cbServiceServiceType);
            this.groupControl3.Controls.Add(this.sbtnServiceInquiry);
            this.groupControl3.Location = new System.Drawing.Point(6, 24);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(730, 52);
            this.groupControl3.TabIndex = 0;
            this.groupControl3.Text = "Inquiry";
            // 
            // luedtCommissionServiceBranch
            // 
            this.luedtCommissionServiceBranch.Location = new System.Drawing.Point(258, 24);
            this.luedtCommissionServiceBranch.Name = "luedtCommissionServiceBranch";
            this.luedtCommissionServiceBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luedtCommissionServiceBranch.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luedtCommissionServiceBranch.Size = new System.Drawing.Size(150, 20);
            this.luedtCommissionServiceBranch.TabIndex = 1;
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(206, 24);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(50, 20);
            this.label30.TabIndex = 18;
            this.label30.Text = "Branch:";
            // 
            // cbServiceYear
            // 
            this.cbServiceYear.EditValue = "";
            this.cbServiceYear.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cbServiceYear.Location = new System.Drawing.Point(580, 24);
            this.cbServiceYear.Name = "cbServiceYear";
            this.cbServiceYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbServiceYear.Properties.PopupSizeable = true;
            this.cbServiceYear.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbServiceYear.Size = new System.Drawing.Size(64, 20);
            this.cbServiceYear.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(542, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Year:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(414, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Month:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Service Type:";
            // 
            // cbServiceMonth
            // 
            this.cbServiceMonth.EditValue = "January";
            this.cbServiceMonth.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cbServiceMonth.Location = new System.Drawing.Point(458, 24);
            this.cbServiceMonth.Name = "cbServiceMonth";
            this.cbServiceMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbServiceMonth.Properties.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cbServiceMonth.Properties.PopupSizeable = true;
            this.cbServiceMonth.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbServiceMonth.Size = new System.Drawing.Size(80, 20);
            this.cbServiceMonth.TabIndex = 2;
            // 
            // cbServiceServiceType
            // 
            this.cbServiceServiceType.EditValue = "PT Service";
            this.cbServiceServiceType.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cbServiceServiceType.Location = new System.Drawing.Point(88, 24);
            this.cbServiceServiceType.Name = "cbServiceServiceType";
            this.cbServiceServiceType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbServiceServiceType.Properties.Items.AddRange(new object[] {
            "PT Service",
            "Spa Service"});
            this.cbServiceServiceType.Properties.PopupSizeable = true;
            this.cbServiceServiceType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbServiceServiceType.Size = new System.Drawing.Size(112, 20);
            this.cbServiceServiceType.TabIndex = 0;
            // 
            // sbtnServiceInquiry
            // 
            this.sbtnServiceInquiry.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnServiceInquiry.Appearance.Options.UseFont = true;
            this.sbtnServiceInquiry.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnServiceInquiry.Location = new System.Drawing.Point(648, 24);
            this.sbtnServiceInquiry.Name = "sbtnServiceInquiry";
            this.sbtnServiceInquiry.Size = new System.Drawing.Size(72, 20);
            this.sbtnServiceInquiry.TabIndex = 4;
            this.sbtnServiceInquiry.Text = "Inquiry";
            this.sbtnServiceInquiry.Click += new System.EventHandler(this.sbtnServiceInquiry_Click);
            // 
            // gctrService
            // 
            this.gctrService.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gctrService.EmbeddedNavigator.Name = "";
            this.gctrService.Location = new System.Drawing.Point(2, 80);
            this.gctrService.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gctrService.MainView = this.gvService;
            this.gctrService.Name = "gctrService";
            this.gctrService.Size = new System.Drawing.Size(988, 494);
            this.gctrService.TabIndex = 5;
            this.gctrService.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvService});
            // 
            // gvService
            // 
            this.gvService.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colServicedtDate,
            this.colServicestrBranchCode,
            this.colServicestrMembershipID,
            this.colServicestrServiceCode,
            this.colServicestrCommission});
            this.gvService.GridControl = this.gctrService;
            this.gvService.Name = "gvService";
            this.gvService.OptionsBehavior.AllowIncrementalSearch = true;
            this.gvService.OptionsBehavior.Editable = false;
            this.gvService.OptionsCustomization.AllowFilter = false;
            this.gvService.OptionsView.ShowFooter = true;
            this.gvService.OptionsView.ShowGroupPanel = false;
            this.gvService.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colServicedtDate, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colServicedtDate
            // 
            this.colServicedtDate.Caption = "Date";
            this.colServicedtDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colServicedtDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colServicedtDate.FieldName = "dtDate";
            this.colServicedtDate.Name = "colServicedtDate";
            this.colServicedtDate.Visible = true;
            this.colServicedtDate.VisibleIndex = 0;
            // 
            // colServicestrBranchCode
            // 
            this.colServicestrBranchCode.Caption = "Branch";
            this.colServicestrBranchCode.FieldName = "strBranchCode";
            this.colServicestrBranchCode.Name = "colServicestrBranchCode";
            this.colServicestrBranchCode.Visible = true;
            this.colServicestrBranchCode.VisibleIndex = 1;
            // 
            // colServicestrMembershipID
            // 
            this.colServicestrMembershipID.Caption = "Membership ID";
            this.colServicestrMembershipID.FieldName = "strMembershipID";
            this.colServicestrMembershipID.Name = "colServicestrMembershipID";
            this.colServicestrMembershipID.Visible = true;
            this.colServicestrMembershipID.VisibleIndex = 2;
            // 
            // colServicestrServiceCode
            // 
            this.colServicestrServiceCode.Caption = "Transaction Code";
            this.colServicestrServiceCode.FieldName = "strServiceCode";
            this.colServicestrServiceCode.Name = "colServicestrServiceCode";
            this.colServicestrServiceCode.Visible = true;
            this.colServicestrServiceCode.VisibleIndex = 3;
            // 
            // colServicestrCommission
            // 
            this.colServicestrCommission.Caption = "Commission";
            this.colServicestrCommission.FieldName = "mCommission";
            this.colServicestrCommission.Name = "colServicestrCommission";
            this.colServicestrCommission.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colServicestrCommission.Visible = true;
            this.colServicestrCommission.VisibleIndex = 4;
            // 
            // lblTwo_1
            // 
            this.lblTwo_1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTwo_1.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblTwo_1.Appearance.Options.UseFont = true;
            this.lblTwo_1.Appearance.Options.UseForeColor = true;
            this.lblTwo_1.Location = new System.Drawing.Point(8, 8);
            this.lblTwo_1.Name = "lblTwo_1";
            this.lblTwo_1.Size = new System.Drawing.Size(138, 23);
            this.lblTwo_1.TabIndex = 142;
            this.lblTwo_1.Text = "Sales";
            this.lblTwo_1.Click += new System.EventHandler(this.lblTwo_1_Click);
            // 
            // lblTwo_2
            // 
            this.lblTwo_2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTwo_2.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblTwo_2.Appearance.Options.UseFont = true;
            this.lblTwo_2.Appearance.Options.UseForeColor = true;
            this.lblTwo_2.Location = new System.Drawing.Point(160, 8);
            this.lblTwo_2.Name = "lblTwo_2";
            this.lblTwo_2.Size = new System.Drawing.Size(138, 23);
            this.lblTwo_2.TabIndex = 143;
            this.lblTwo_2.Text = "Service";
            this.lblTwo_2.Click += new System.EventHandler(this.lblTwo_2_Click);
            // 
            // groupSales
            // 
            this.groupSales.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupSales.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupSales.Controls.Add(this.groupSalesEntry);
            this.groupSales.Location = new System.Drawing.Point(0, 34);
            this.groupSales.Name = "groupSales";
            this.groupSales.ShowCaption = false;
            this.groupSales.Size = new System.Drawing.Size(1007, 584);
            this.groupSales.TabIndex = 14;
            this.groupSales.Text = "GroupControl3";
            // 
            // groupSalesEntry
            // 
            this.groupSalesEntry.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupSalesEntry.Appearance.Options.UseBackColor = true;
            this.groupSalesEntry.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupSalesEntry.Controls.Add(this.groupControl7);
            this.groupSalesEntry.Controls.Add(this.gctrSales);
            this.groupSalesEntry.Location = new System.Drawing.Point(8, 0);
            this.groupSalesEntry.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupSalesEntry.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupSalesEntry.Name = "groupSalesEntry";
            this.groupSalesEntry.Size = new System.Drawing.Size(992, 576);
            this.groupSalesEntry.TabIndex = 1;
            this.groupSalesEntry.Text = "SALES";
            // 
            // groupControl7
            // 
            this.groupControl7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupControl7.Controls.Add(this.luedtSalesBranchCode);
            this.groupControl7.Controls.Add(this.label16);
            this.groupControl7.Controls.Add(this.cbSalesYear);
            this.groupControl7.Controls.Add(this.label6);
            this.groupControl7.Controls.Add(this.label7);
            this.groupControl7.Controls.Add(this.label8);
            this.groupControl7.Controls.Add(this.cbSalesMonth);
            this.groupControl7.Controls.Add(this.sbtnSalesInquiry);
            this.groupControl7.Controls.Add(this.cbSalesType);
            this.groupControl7.Location = new System.Drawing.Point(6, 24);
            this.groupControl7.Name = "groupControl7";
            this.groupControl7.Size = new System.Drawing.Size(772, 52);
            this.groupControl7.TabIndex = 0;
            this.groupControl7.Text = "Inquiry";
            // 
            // luedtSalesBranchCode
            // 
            this.luedtSalesBranchCode.Location = new System.Drawing.Point(304, 24);
            this.luedtSalesBranchCode.Name = "luedtSalesBranchCode";
            this.luedtSalesBranchCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luedtSalesBranchCode.Size = new System.Drawing.Size(150, 20);
            this.luedtSalesBranchCode.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(252, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 20);
            this.label16.TabIndex = 16;
            this.label16.Text = "Branch:";
            // 
            // cbSalesYear
            // 
            this.cbSalesYear.EditValue = "";
            this.cbSalesYear.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cbSalesYear.Location = new System.Drawing.Point(624, 24);
            this.cbSalesYear.Name = "cbSalesYear";
            this.cbSalesYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbSalesYear.Properties.PopupSizeable = true;
            this.cbSalesYear.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbSalesYear.Size = new System.Drawing.Size(64, 20);
            this.cbSalesYear.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(586, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Year:";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(458, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Month:";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Sales Type:";
            // 
            // cbSalesMonth
            // 
            this.cbSalesMonth.EditValue = "January";
            this.cbSalesMonth.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cbSalesMonth.Location = new System.Drawing.Point(502, 24);
            this.cbSalesMonth.Name = "cbSalesMonth";
            this.cbSalesMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbSalesMonth.Properties.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cbSalesMonth.Properties.PopupSizeable = true;
            this.cbSalesMonth.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbSalesMonth.Size = new System.Drawing.Size(80, 20);
            this.cbSalesMonth.TabIndex = 2;
            // 
            // sbtnSalesInquiry
            // 
            this.sbtnSalesInquiry.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnSalesInquiry.Appearance.Options.UseFont = true;
            this.sbtnSalesInquiry.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnSalesInquiry.Location = new System.Drawing.Point(692, 24);
            this.sbtnSalesInquiry.Name = "sbtnSalesInquiry";
            this.sbtnSalesInquiry.Size = new System.Drawing.Size(72, 20);
            this.sbtnSalesInquiry.TabIndex = 4;
            this.sbtnSalesInquiry.Text = "Inquiry";
            this.sbtnSalesInquiry.Click += new System.EventHandler(this.sbtnSalesInquiry_Click);
            // 
            // cbSalesType
            // 
            this.cbSalesType.EditValue = "Fitness Package Sales";
            this.cbSalesType.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cbSalesType.Location = new System.Drawing.Point(80, 24);
            this.cbSalesType.Name = "cbSalesType";
            this.cbSalesType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbSalesType.Properties.Items.AddRange(new object[] {
            "Fitness Product Sales",
            "Fitness Package Sales",
            "Spa Product Sales",
            "Spa Package Sales",
            "Personal Trainer Package Sales",
            "IPL Package Sales"});
            this.cbSalesType.Properties.PopupSizeable = true;
            this.cbSalesType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbSalesType.Size = new System.Drawing.Size(168, 20);
            this.cbSalesType.TabIndex = 0;
            // 
            // gctrSales
            // 
            this.gctrSales.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gctrSales.EmbeddedNavigator.Name = "";
            this.gctrSales.Location = new System.Drawing.Point(2, 80);
            this.gctrSales.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gctrSales.MainView = this.gvSales;
            this.gctrSales.Name = "gctrSales";
            this.gctrSales.Size = new System.Drawing.Size(988, 494);
            this.gctrSales.TabIndex = 5;
            this.gctrSales.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSales});
            // 
            // gvSales
            // 
            this.gvSales.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSalesDate,
            this.colSalesReceipt,
            this.colSalesMembershipID,
            this.colSalesNettAmount});
            this.gvSales.GridControl = this.gctrSales;
            this.gvSales.Name = "gvSales";
            this.gvSales.OptionsBehavior.AllowIncrementalSearch = true;
            this.gvSales.OptionsBehavior.Editable = false;
            this.gvSales.OptionsCustomization.AllowFilter = false;
            this.gvSales.OptionsView.ShowFooter = true;
            this.gvSales.OptionsView.ShowGroupPanel = false;
            this.gvSales.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSalesDate, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colSalesDate
            // 
            this.colSalesDate.Caption = "Date";
            this.colSalesDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colSalesDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colSalesDate.FieldName = "dtDate";
            this.colSalesDate.Name = "colSalesDate";
            this.colSalesDate.Visible = true;
            this.colSalesDate.VisibleIndex = 0;
            this.colSalesDate.Width = 99;
            // 
            // colSalesReceipt
            // 
            this.colSalesReceipt.Caption = "Receipt No";
            this.colSalesReceipt.FieldName = "strReceiptNo";
            this.colSalesReceipt.Name = "colSalesReceipt";
            this.colSalesReceipt.Visible = true;
            this.colSalesReceipt.VisibleIndex = 1;
            this.colSalesReceipt.Width = 166;
            // 
            // colSalesMembershipID
            // 
            this.colSalesMembershipID.Caption = "Membership ID";
            this.colSalesMembershipID.FieldName = "strMembershipID";
            this.colSalesMembershipID.Name = "colSalesMembershipID";
            this.colSalesMembershipID.Visible = true;
            this.colSalesMembershipID.VisibleIndex = 2;
            this.colSalesMembershipID.Width = 294;
            // 
            // colSalesNettAmount
            // 
            this.colSalesNettAmount.Caption = "Nett Amount";
            this.colSalesNettAmount.FieldName = "mNettAmount";
            this.colSalesNettAmount.Name = "colSalesNettAmount";
            this.colSalesNettAmount.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colSalesNettAmount.Visible = true;
            this.colSalesNettAmount.VisibleIndex = 3;
            this.colSalesNettAmount.Width = 107;
            // 
            // tabStaffThree
            // 
            this.tabStaffThree.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabStaffThree.Appearance.Header.Options.UseFont = true;
            this.tabStaffThree.Controls.Add(this.lblThree_3);
            this.tabStaffThree.Controls.Add(this.lblThree_1);
            this.tabStaffThree.Controls.Add(this.lblThree_2);
            this.tabStaffThree.Controls.Add(this.groupTimesheet);
            this.tabStaffThree.Controls.Add(this.groupOvertime);
            this.tabStaffThree.Controls.Add(this.groupLateness);
            this.tabStaffThree.Name = "tabStaffThree";
            this.tabStaffThree.PageVisible = false;
            this.tabStaffThree.Size = new System.Drawing.Size(1007, 612);
            this.tabStaffThree.Text = "Timesheet";
            this.tabStaffThree.VisibleChanged += new System.EventHandler(this.tabStaffTimesheet_VisibleChanged);
            // 
            // lblThree_3
            // 
            this.lblThree_3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblThree_3.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblThree_3.Appearance.Options.UseFont = true;
            this.lblThree_3.Appearance.Options.UseForeColor = true;
            this.lblThree_3.Location = new System.Drawing.Point(296, 8);
            this.lblThree_3.Name = "lblThree_3";
            this.lblThree_3.Size = new System.Drawing.Size(138, 23);
            this.lblThree_3.TabIndex = 146;
            this.lblThree_3.Text = "Lateness";
            this.lblThree_3.Click += new System.EventHandler(this.lblThree_3_Click);
            // 
            // lblThree_1
            // 
            this.lblThree_1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblThree_1.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblThree_1.Appearance.Options.UseFont = true;
            this.lblThree_1.Appearance.Options.UseForeColor = true;
            this.lblThree_1.Location = new System.Drawing.Point(8, 8);
            this.lblThree_1.Name = "lblThree_1";
            this.lblThree_1.Size = new System.Drawing.Size(138, 23);
            this.lblThree_1.TabIndex = 144;
            this.lblThree_1.Text = "Timesheet";
            this.lblThree_1.Click += new System.EventHandler(this.lblThree_1_Click);
            // 
            // lblThree_2
            // 
            this.lblThree_2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblThree_2.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblThree_2.Appearance.Options.UseFont = true;
            this.lblThree_2.Appearance.Options.UseForeColor = true;
            this.lblThree_2.Location = new System.Drawing.Point(152, 8);
            this.lblThree_2.Name = "lblThree_2";
            this.lblThree_2.Size = new System.Drawing.Size(138, 23);
            this.lblThree_2.TabIndex = 145;
            this.lblThree_2.Text = "Overtime";
            this.lblThree_2.Click += new System.EventHandler(this.lblThree_2_Click);
            // 
            // groupTimesheet
            // 
            this.groupTimesheet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupTimesheet.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupTimesheet.Controls.Add(this.groupTimesheetEntry);
            this.groupTimesheet.Location = new System.Drawing.Point(0, 32);
            this.groupTimesheet.Name = "groupTimesheet";
            this.groupTimesheet.ShowCaption = false;
            this.groupTimesheet.Size = new System.Drawing.Size(1007, 576);
            this.groupTimesheet.TabIndex = 10;
            this.groupTimesheet.Text = "GroupControl1";
            // 
            // groupTimesheetEntry
            // 
            this.groupTimesheetEntry.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupTimesheetEntry.Appearance.Options.UseBackColor = true;
            this.groupTimesheetEntry.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupTimesheetEntry.Controls.Add(this.groupControl9);
            this.groupTimesheetEntry.Controls.Add(this.gridctrTimesheet);
            this.groupTimesheetEntry.Location = new System.Drawing.Point(8, 0);
            this.groupTimesheetEntry.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupTimesheetEntry.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupTimesheetEntry.Name = "groupTimesheetEntry";
            this.groupTimesheetEntry.Size = new System.Drawing.Size(992, 568);
            this.groupTimesheetEntry.TabIndex = 1;
            this.groupTimesheetEntry.Text = "TIMESHEET";
            // 
            // groupControl9
            // 
            this.groupControl9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupControl9.Controls.Add(this.cbTimesheetYear);
            this.groupControl9.Controls.Add(this.label1);
            this.groupControl9.Controls.Add(this.label11);
            this.groupControl9.Controls.Add(this.cbTimesheetMonth);
            this.groupControl9.Controls.Add(this.sbtnTimesheetInquiry);
            this.groupControl9.Location = new System.Drawing.Point(6, 22);
            this.groupControl9.Name = "groupControl9";
            this.groupControl9.Size = new System.Drawing.Size(328, 52);
            this.groupControl9.TabIndex = 0;
            this.groupControl9.Text = "Inquiry";
            // 
            // cbTimesheetYear
            // 
            this.cbTimesheetYear.EditValue = "";
            this.cbTimesheetYear.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cbTimesheetYear.Location = new System.Drawing.Point(178, 24);
            this.cbTimesheetYear.Name = "cbTimesheetYear";
            this.cbTimesheetYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbTimesheetYear.Properties.PopupSizeable = true;
            this.cbTimesheetYear.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbTimesheetYear.Size = new System.Drawing.Size(64, 20);
            this.cbTimesheetYear.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(140, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Year:";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Month:";
            // 
            // cbTimesheetMonth
            // 
            this.cbTimesheetMonth.EditValue = "January";
            this.cbTimesheetMonth.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cbTimesheetMonth.Location = new System.Drawing.Point(56, 24);
            this.cbTimesheetMonth.Name = "cbTimesheetMonth";
            this.cbTimesheetMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbTimesheetMonth.Properties.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cbTimesheetMonth.Properties.PopupSizeable = true;
            this.cbTimesheetMonth.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbTimesheetMonth.Size = new System.Drawing.Size(80, 20);
            this.cbTimesheetMonth.TabIndex = 1;
            // 
            // sbtnTimesheetInquiry
            // 
            this.sbtnTimesheetInquiry.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnTimesheetInquiry.Appearance.Options.UseFont = true;
            this.sbtnTimesheetInquiry.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnTimesheetInquiry.Location = new System.Drawing.Point(246, 24);
            this.sbtnTimesheetInquiry.Name = "sbtnTimesheetInquiry";
            this.sbtnTimesheetInquiry.Size = new System.Drawing.Size(72, 20);
            this.sbtnTimesheetInquiry.TabIndex = 3;
            this.sbtnTimesheetInquiry.Text = "Inquiry";
            this.sbtnTimesheetInquiry.Click += new System.EventHandler(this.sbtnTimesheetInquiry_Click);
            // 
            // gridctrTimesheet
            // 
            this.gridctrTimesheet.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridctrTimesheet.EmbeddedNavigator.Name = "";
            this.gridctrTimesheet.Location = new System.Drawing.Point(2, 76);
            this.gridctrTimesheet.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridctrTimesheet.MainView = this.gvTimesheet;
            this.gridctrTimesheet.Name = "gridctrTimesheet";
            this.gridctrTimesheet.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2});
            this.gridctrTimesheet.Size = new System.Drawing.Size(988, 490);
            this.gridctrTimesheet.TabIndex = 1;
            this.gridctrTimesheet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTimesheet});
            // 
            // gvTimesheet
            // 
            this.gvTimesheet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTimesheetDate,
            this.colTimesheetRosterIn,
            this.colTimesheetRosterOut,
            this.colTimesheetBranchFirstTimeIn,
            this.colTimesheetBranchLastTimeOut,
            this.colTimesheetFirstTimeIn,
            this.colTimesheetLastTimeOut,
            this.colTimesheetManagerNameIn,
            this.colTimesheetManagerNameOut,
            this.colTimesheetLateness,
            this.colTimesheetTotalLateness});
            this.gvTimesheet.GridControl = this.gridctrTimesheet;
            this.gvTimesheet.Name = "gvTimesheet";
            this.gvTimesheet.OptionsBehavior.AllowIncrementalSearch = true;
            this.gvTimesheet.OptionsBehavior.Editable = false;
            this.gvTimesheet.OptionsCustomization.AllowFilter = false;
            this.gvTimesheet.OptionsView.ShowGroupPanel = false;
            this.gvTimesheet.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTimesheetDate, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gvTimesheet.DoubleClick += new System.EventHandler(this.gvTimesheet_DoubleClick);
            this.gvTimesheet.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvTimesheet_RowStyle);
            // 
            // colTimesheetDate
            // 
            this.colTimesheetDate.Caption = "Date";
            this.colTimesheetDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colTimesheetDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTimesheetDate.FieldName = "dtDate";
            this.colTimesheetDate.Name = "colTimesheetDate";
            this.colTimesheetDate.Visible = true;
            this.colTimesheetDate.VisibleIndex = 0;
            this.colTimesheetDate.Width = 119;
            // 
            // colTimesheetRosterIn
            // 
            this.colTimesheetRosterIn.Caption = "Roster In";
            this.colTimesheetRosterIn.DisplayFormat.FormatString = "hh:mm tt";
            this.colTimesheetRosterIn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTimesheetRosterIn.FieldName = "Expected Start Time";
            this.colTimesheetRosterIn.Name = "colTimesheetRosterIn";
            this.colTimesheetRosterIn.Visible = true;
            this.colTimesheetRosterIn.VisibleIndex = 1;
            this.colTimesheetRosterIn.Width = 89;
            // 
            // colTimesheetRosterOut
            // 
            this.colTimesheetRosterOut.Caption = "Roster Out";
            this.colTimesheetRosterOut.DisplayFormat.FormatString = "hh:mm tt";
            this.colTimesheetRosterOut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTimesheetRosterOut.FieldName = "Expected End Time";
            this.colTimesheetRosterOut.Name = "colTimesheetRosterOut";
            this.colTimesheetRosterOut.Visible = true;
            this.colTimesheetRosterOut.VisibleIndex = 2;
            this.colTimesheetRosterOut.Width = 79;
            // 
            // colTimesheetBranchFirstTimeIn
            // 
            this.colTimesheetBranchFirstTimeIn.Caption = "Branch In";
            this.colTimesheetBranchFirstTimeIn.FieldName = "strBranchCodeIn";
            this.colTimesheetBranchFirstTimeIn.Name = "colTimesheetBranchFirstTimeIn";
            this.colTimesheetBranchFirstTimeIn.Visible = true;
            this.colTimesheetBranchFirstTimeIn.VisibleIndex = 3;
            this.colTimesheetBranchFirstTimeIn.Width = 71;
            // 
            // colTimesheetBranchLastTimeOut
            // 
            this.colTimesheetBranchLastTimeOut.Caption = "Branch Out";
            this.colTimesheetBranchLastTimeOut.FieldName = "strBranchCodeOut";
            this.colTimesheetBranchLastTimeOut.Name = "colTimesheetBranchLastTimeOut";
            this.colTimesheetBranchLastTimeOut.Visible = true;
            this.colTimesheetBranchLastTimeOut.VisibleIndex = 5;
            this.colTimesheetBranchLastTimeOut.Width = 66;
            // 
            // colTimesheetFirstTimeIn
            // 
            this.colTimesheetFirstTimeIn.Caption = "Time (In)";
            this.colTimesheetFirstTimeIn.DisplayFormat.FormatString = "hh:mm tt";
            this.colTimesheetFirstTimeIn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTimesheetFirstTimeIn.FieldName = "First Time In";
            this.colTimesheetFirstTimeIn.Name = "colTimesheetFirstTimeIn";
            this.colTimesheetFirstTimeIn.Visible = true;
            this.colTimesheetFirstTimeIn.VisibleIndex = 4;
            this.colTimesheetFirstTimeIn.Width = 83;
            // 
            // colTimesheetLastTimeOut
            // 
            this.colTimesheetLastTimeOut.Caption = "Time (Out)";
            this.colTimesheetLastTimeOut.DisplayFormat.FormatString = "hh:mm tt";
            this.colTimesheetLastTimeOut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTimesheetLastTimeOut.FieldName = "Last Time Out";
            this.colTimesheetLastTimeOut.Name = "colTimesheetLastTimeOut";
            this.colTimesheetLastTimeOut.Visible = true;
            this.colTimesheetLastTimeOut.VisibleIndex = 6;
            this.colTimesheetLastTimeOut.Width = 84;
            // 
            // colTimesheetManagerNameIn
            // 
            this.colTimesheetManagerNameIn.Caption = "Edit (In)";
            this.colTimesheetManagerNameIn.FieldName = "strManagerNameIn";
            this.colTimesheetManagerNameIn.Name = "colTimesheetManagerNameIn";
            this.colTimesheetManagerNameIn.Visible = true;
            this.colTimesheetManagerNameIn.VisibleIndex = 7;
            this.colTimesheetManagerNameIn.Width = 120;
            // 
            // colTimesheetManagerNameOut
            // 
            this.colTimesheetManagerNameOut.Caption = "Edit (Out)";
            this.colTimesheetManagerNameOut.FieldName = "strManagerNameOut";
            this.colTimesheetManagerNameOut.Name = "colTimesheetManagerNameOut";
            this.colTimesheetManagerNameOut.Visible = true;
            this.colTimesheetManagerNameOut.VisibleIndex = 8;
            this.colTimesheetManagerNameOut.Width = 122;
            // 
            // colTimesheetLateness
            // 
            this.colTimesheetLateness.Caption = "Lateness";
            this.colTimesheetLateness.ColumnEdit = this.repositoryItemCheckEdit2;
            this.colTimesheetLateness.FieldName = "fLateness";
            this.colTimesheetLateness.Name = "colTimesheetLateness";
            this.colTimesheetLateness.Visible = true;
            this.colTimesheetLateness.VisibleIndex = 9;
            this.colTimesheetLateness.Width = 54;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            this.repositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // colTimesheetTotalLateness
            // 
            this.colTimesheetTotalLateness.Caption = "Total Lateness";
            this.colTimesheetTotalLateness.DisplayFormat.FormatString = "HH:mm";
            this.colTimesheetTotalLateness.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTimesheetTotalLateness.FieldName = "dtLateness";
            this.colTimesheetTotalLateness.Name = "colTimesheetTotalLateness";
            this.colTimesheetTotalLateness.Visible = true;
            this.colTimesheetTotalLateness.VisibleIndex = 10;
            this.colTimesheetTotalLateness.Width = 80;
            // 
            // groupOvertime
            // 
            this.groupOvertime.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupOvertime.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupOvertime.Controls.Add(this.groupControl15);
            this.groupOvertime.Location = new System.Drawing.Point(0, 32);
            this.groupOvertime.Name = "groupOvertime";
            this.groupOvertime.ShowCaption = false;
            this.groupOvertime.Size = new System.Drawing.Size(1007, 576);
            this.groupOvertime.TabIndex = 15;
            this.groupOvertime.Text = "GroupControl1";
            this.groupOvertime.Visible = false;
            // 
            // groupControl15
            // 
            this.groupControl15.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupControl15.Appearance.Options.UseBackColor = true;
            this.groupControl15.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupControl15.Controls.Add(this.sbtnOvertimeDelete);
            this.groupControl15.Controls.Add(this.groupControl16);
            this.groupControl15.Controls.Add(this.sbtnApplyOvertime);
            this.groupControl15.Controls.Add(this.gridctrOvertime);
            this.groupControl15.Location = new System.Drawing.Point(8, 0);
            this.groupControl15.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupControl15.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl15.Name = "groupControl15";
            this.groupControl15.Size = new System.Drawing.Size(992, 574);
            this.groupControl15.TabIndex = 1;
            this.groupControl15.Text = "OVERTIME";
            // 
            // sbtnOvertimeDelete
            // 
            this.sbtnOvertimeDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnOvertimeDelete.Appearance.Options.UseFont = true;
            this.sbtnOvertimeDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnOvertimeDelete.Location = new System.Drawing.Point(452, 48);
            this.sbtnOvertimeDelete.Name = "sbtnOvertimeDelete";
            this.sbtnOvertimeDelete.Size = new System.Drawing.Size(104, 20);
            this.sbtnOvertimeDelete.TabIndex = 2;
            this.sbtnOvertimeDelete.Text = "Cancel Overtime";
            this.sbtnOvertimeDelete.Click += new System.EventHandler(this.sbtnOvertimeDelete_Click);
            // 
            // groupControl16
            // 
            this.groupControl16.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupControl16.Controls.Add(this.cbOvertimeYear);
            this.groupControl16.Controls.Add(this.label14);
            this.groupControl16.Controls.Add(this.label15);
            this.groupControl16.Controls.Add(this.cbOvertimeMonth);
            this.groupControl16.Controls.Add(this.sbtnOvertimeInquiry);
            this.groupControl16.Location = new System.Drawing.Point(6, 24);
            this.groupControl16.Name = "groupControl16";
            this.groupControl16.Size = new System.Drawing.Size(328, 52);
            this.groupControl16.TabIndex = 0;
            this.groupControl16.Text = "Inquiry";
            // 
            // cbOvertimeYear
            // 
            this.cbOvertimeYear.EditValue = "";
            this.cbOvertimeYear.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cbOvertimeYear.Location = new System.Drawing.Point(178, 24);
            this.cbOvertimeYear.Name = "cbOvertimeYear";
            this.cbOvertimeYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbOvertimeYear.Properties.PopupSizeable = true;
            this.cbOvertimeYear.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbOvertimeYear.Size = new System.Drawing.Size(64, 20);
            this.cbOvertimeYear.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(140, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 20);
            this.label14.TabIndex = 15;
            this.label14.Text = "Year:";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(12, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 20);
            this.label15.TabIndex = 14;
            this.label15.Text = "Month:";
            // 
            // cbOvertimeMonth
            // 
            this.cbOvertimeMonth.EditValue = "January";
            this.cbOvertimeMonth.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cbOvertimeMonth.Location = new System.Drawing.Point(56, 24);
            this.cbOvertimeMonth.Name = "cbOvertimeMonth";
            this.cbOvertimeMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbOvertimeMonth.Properties.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cbOvertimeMonth.Properties.PopupSizeable = true;
            this.cbOvertimeMonth.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbOvertimeMonth.Size = new System.Drawing.Size(80, 20);
            this.cbOvertimeMonth.TabIndex = 0;
            // 
            // sbtnOvertimeInquiry
            // 
            this.sbtnOvertimeInquiry.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnOvertimeInquiry.Appearance.Options.UseFont = true;
            this.sbtnOvertimeInquiry.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnOvertimeInquiry.Location = new System.Drawing.Point(246, 24);
            this.sbtnOvertimeInquiry.Name = "sbtnOvertimeInquiry";
            this.sbtnOvertimeInquiry.Size = new System.Drawing.Size(72, 20);
            this.sbtnOvertimeInquiry.TabIndex = 2;
            this.sbtnOvertimeInquiry.Text = "Inquiry";
            this.sbtnOvertimeInquiry.Click += new System.EventHandler(this.sbtnOvertimeInquiry_Click);
            // 
            // sbtnApplyOvertime
            // 
            this.sbtnApplyOvertime.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnApplyOvertime.Appearance.Options.UseFont = true;
            this.sbtnApplyOvertime.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnApplyOvertime.Location = new System.Drawing.Point(340, 48);
            this.sbtnApplyOvertime.Name = "sbtnApplyOvertime";
            this.sbtnApplyOvertime.Size = new System.Drawing.Size(104, 20);
            this.sbtnApplyOvertime.TabIndex = 1;
            this.sbtnApplyOvertime.Text = "Apply Overtime";
            this.sbtnApplyOvertime.Click += new System.EventHandler(this.sbtnApplyOvertime_Click);
            // 
            // gridctrOvertime
            // 
            this.gridctrOvertime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridctrOvertime.EmbeddedNavigator.Name = "";
            this.gridctrOvertime.Location = new System.Drawing.Point(2, 80);
            this.gridctrOvertime.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridctrOvertime.MainView = this.gvOvertime;
            this.gridctrOvertime.Name = "gridctrOvertime";
            this.gridctrOvertime.Size = new System.Drawing.Size(988, 492);
            this.gridctrOvertime.TabIndex = 3;
            this.gridctrOvertime.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOvertime});
            // 
            // gvOvertime
            // 
            this.gvOvertime.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOvertimeDate,
            this.colOvertimeHours,
            this.colOvertimeReason,
            this.colOvertimeCharging,
            this.colOvertimeManager,
            this.colOvertimeApprovingManagerID,
            this.colOvertimeStatus});
            this.gvOvertime.GridControl = this.gridctrOvertime;
            this.gvOvertime.Name = "gvOvertime";
            this.gvOvertime.OptionsBehavior.AllowIncrementalSearch = true;
            this.gvOvertime.OptionsBehavior.Editable = false;
            this.gvOvertime.OptionsCustomization.AllowFilter = false;
            this.gvOvertime.OptionsView.ShowGroupPanel = false;
            this.gvOvertime.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colOvertimeDate, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // colOvertimeDate
            // 
            this.colOvertimeDate.Caption = "Date";
            this.colOvertimeDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colOvertimeDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colOvertimeDate.FieldName = "dtDate";
            this.colOvertimeDate.Name = "colOvertimeDate";
            this.colOvertimeDate.Visible = true;
            this.colOvertimeDate.VisibleIndex = 0;
            this.colOvertimeDate.Width = 115;
            // 
            // colOvertimeHours
            // 
            this.colOvertimeHours.Caption = "Hours";
            this.colOvertimeHours.FieldName = "nHours";
            this.colOvertimeHours.Name = "colOvertimeHours";
            this.colOvertimeHours.Visible = true;
            this.colOvertimeHours.VisibleIndex = 1;
            this.colOvertimeHours.Width = 96;
            // 
            // colOvertimeReason
            // 
            this.colOvertimeReason.Caption = "Reason";
            this.colOvertimeReason.FieldName = "strReason";
            this.colOvertimeReason.Name = "colOvertimeReason";
            this.colOvertimeReason.Visible = true;
            this.colOvertimeReason.VisibleIndex = 2;
            this.colOvertimeReason.Width = 320;
            // 
            // colOvertimeCharging
            // 
            this.colOvertimeCharging.Caption = "Charging";
            this.colOvertimeCharging.FieldName = "Charging";
            this.colOvertimeCharging.Name = "colOvertimeCharging";
            this.colOvertimeCharging.Visible = true;
            this.colOvertimeCharging.VisibleIndex = 3;
            this.colOvertimeCharging.Width = 84;
            // 
            // colOvertimeManager
            // 
            this.colOvertimeManager.Caption = "Approving Manager";
            this.colOvertimeManager.FieldName = "strEmployeeName";
            this.colOvertimeManager.Name = "colOvertimeManager";
            this.colOvertimeManager.Visible = true;
            this.colOvertimeManager.VisibleIndex = 4;
            this.colOvertimeManager.Width = 194;
            // 
            // colOvertimeApprovingManagerID
            // 
            this.colOvertimeApprovingManagerID.Caption = "Approving Manager ID";
            this.colOvertimeApprovingManagerID.FieldName = "nApprovingManagerID";
            this.colOvertimeApprovingManagerID.Name = "colOvertimeApprovingManagerID";
            this.colOvertimeApprovingManagerID.Visible = true;
            this.colOvertimeApprovingManagerID.VisibleIndex = 5;
            this.colOvertimeApprovingManagerID.Width = 57;
            // 
            // colOvertimeStatus
            // 
            this.colOvertimeStatus.Caption = "Status";
            this.colOvertimeStatus.FieldName = "Status";
            this.colOvertimeStatus.Name = "colOvertimeStatus";
            this.colOvertimeStatus.Visible = true;
            this.colOvertimeStatus.VisibleIndex = 6;
            this.colOvertimeStatus.Width = 101;
            // 
            // groupLateness
            // 
            this.groupLateness.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupLateness.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupLateness.Controls.Add(this.groupControl13);
            this.groupLateness.Location = new System.Drawing.Point(0, 32);
            this.groupLateness.Name = "groupLateness";
            this.groupLateness.ShowCaption = false;
            this.groupLateness.Size = new System.Drawing.Size(1007, 576);
            this.groupLateness.TabIndex = 14;
            this.groupLateness.Text = "GroupControl1";
            // 
            // groupControl13
            // 
            this.groupControl13.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupControl13.Appearance.Options.UseBackColor = true;
            this.groupControl13.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupControl13.Controls.Add(this.groupControl14);
            this.groupControl13.Controls.Add(this.gridctrLateness);
            this.groupControl13.Location = new System.Drawing.Point(8, 0);
            this.groupControl13.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupControl13.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl13.Name = "groupControl13";
            this.groupControl13.Size = new System.Drawing.Size(992, 574);
            this.groupControl13.TabIndex = 1;
            this.groupControl13.Text = "LATENESS";
            // 
            // groupControl14
            // 
            this.groupControl14.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupControl14.Controls.Add(this.cbLatenessYear);
            this.groupControl14.Controls.Add(this.label12);
            this.groupControl14.Controls.Add(this.label13);
            this.groupControl14.Controls.Add(this.cbLatenessMonth);
            this.groupControl14.Controls.Add(this.sbtnLatenessInquiry);
            this.groupControl14.Location = new System.Drawing.Point(6, 24);
            this.groupControl14.Name = "groupControl14";
            this.groupControl14.Size = new System.Drawing.Size(328, 52);
            this.groupControl14.TabIndex = 0;
            this.groupControl14.Text = "Inquiry";
            // 
            // cbLatenessYear
            // 
            this.cbLatenessYear.EditValue = "";
            this.cbLatenessYear.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cbLatenessYear.Location = new System.Drawing.Point(178, 24);
            this.cbLatenessYear.Name = "cbLatenessYear";
            this.cbLatenessYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbLatenessYear.Properties.PopupSizeable = true;
            this.cbLatenessYear.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbLatenessYear.Size = new System.Drawing.Size(64, 20);
            this.cbLatenessYear.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(140, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 20);
            this.label12.TabIndex = 15;
            this.label12.Text = "Year:";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(12, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 20);
            this.label13.TabIndex = 14;
            this.label13.Text = "Month:";
            // 
            // cbLatenessMonth
            // 
            this.cbLatenessMonth.EditValue = "January";
            this.cbLatenessMonth.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cbLatenessMonth.Location = new System.Drawing.Point(56, 24);
            this.cbLatenessMonth.Name = "cbLatenessMonth";
            this.cbLatenessMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbLatenessMonth.Properties.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cbLatenessMonth.Properties.PopupSizeable = true;
            this.cbLatenessMonth.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbLatenessMonth.Size = new System.Drawing.Size(80, 20);
            this.cbLatenessMonth.TabIndex = 0;
            // 
            // sbtnLatenessInquiry
            // 
            this.sbtnLatenessInquiry.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnLatenessInquiry.Appearance.Options.UseFont = true;
            this.sbtnLatenessInquiry.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnLatenessInquiry.Location = new System.Drawing.Point(246, 24);
            this.sbtnLatenessInquiry.Name = "sbtnLatenessInquiry";
            this.sbtnLatenessInquiry.Size = new System.Drawing.Size(72, 20);
            this.sbtnLatenessInquiry.TabIndex = 2;
            this.sbtnLatenessInquiry.Text = "Inquiry";
            this.sbtnLatenessInquiry.Click += new System.EventHandler(this.sbtnLatenessInquiry_Click);
            // 
            // gridctrLateness
            // 
            this.gridctrLateness.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridctrLateness.EmbeddedNavigator.Name = "";
            this.gridctrLateness.Location = new System.Drawing.Point(2, 80);
            this.gridctrLateness.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridctrLateness.MainView = this.gvLateness;
            this.gridctrLateness.Name = "gridctrLateness";
            this.gridctrLateness.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTimeEdit1,
            this.repositoryItemTimeEdit2});
            this.gridctrLateness.Size = new System.Drawing.Size(988, 492);
            this.gridctrLateness.TabIndex = 1;
            this.gridctrLateness.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLateness});
            // 
            // gvLateness
            // 
            this.gvLateness.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLatenessRosterID,
            this.colLatenessDate,
            this.colLatenessBranch,
            this.colLatenessType,
            this.colLatenessExpected,
            this.colLatenessActual,
            this.colLatenessLateness});
            this.gvLateness.GridControl = this.gridctrLateness;
            this.gvLateness.Name = "gvLateness";
            this.gvLateness.OptionsBehavior.AllowIncrementalSearch = true;
            this.gvLateness.OptionsBehavior.Editable = false;
            this.gvLateness.OptionsCustomization.AllowFilter = false;
            this.gvLateness.OptionsView.ShowFooter = true;
            this.gvLateness.OptionsView.ShowGroupPanel = false;
            this.gvLateness.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLatenessDate, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // colLatenessRosterID
            // 
            this.colLatenessRosterID.Caption = "Roster ID";
            this.colLatenessRosterID.FieldName = "nRosterID";
            this.colLatenessRosterID.Name = "colLatenessRosterID";
            // 
            // colLatenessDate
            // 
            this.colLatenessDate.Caption = "Date";
            this.colLatenessDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colLatenessDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colLatenessDate.FieldName = "dtDate";
            this.colLatenessDate.Name = "colLatenessDate";
            this.colLatenessDate.Visible = true;
            this.colLatenessDate.VisibleIndex = 0;
            this.colLatenessDate.Width = 185;
            // 
            // colLatenessBranch
            // 
            this.colLatenessBranch.Caption = "Branch Code";
            this.colLatenessBranch.FieldName = "strBranchCode";
            this.colLatenessBranch.Name = "colLatenessBranch";
            this.colLatenessBranch.Visible = true;
            this.colLatenessBranch.VisibleIndex = 1;
            this.colLatenessBranch.Width = 85;
            // 
            // colLatenessType
            // 
            this.colLatenessType.Caption = "Type";
            this.colLatenessType.FieldName = "strType";
            this.colLatenessType.Name = "colLatenessType";
            this.colLatenessType.Visible = true;
            this.colLatenessType.VisibleIndex = 2;
            this.colLatenessType.Width = 124;
            // 
            // colLatenessExpected
            // 
            this.colLatenessExpected.Caption = "Expected Time";
            this.colLatenessExpected.ColumnEdit = this.repositoryItemTimeEdit1;
            this.colLatenessExpected.FieldName = "dtExpected";
            this.colLatenessExpected.Name = "colLatenessExpected";
            this.colLatenessExpected.Visible = true;
            this.colLatenessExpected.VisibleIndex = 3;
            this.colLatenessExpected.Width = 196;
            // 
            // repositoryItemTimeEdit1
            // 
            this.repositoryItemTimeEdit1.AutoHeight = false;
            this.repositoryItemTimeEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemTimeEdit1.Name = "repositoryItemTimeEdit1";
            // 
            // colLatenessActual
            // 
            this.colLatenessActual.Caption = "Actual Time";
            this.colLatenessActual.ColumnEdit = this.repositoryItemTimeEdit2;
            this.colLatenessActual.FieldName = "dtActual";
            this.colLatenessActual.Name = "colLatenessActual";
            this.colLatenessActual.Visible = true;
            this.colLatenessActual.VisibleIndex = 4;
            this.colLatenessActual.Width = 208;
            // 
            // repositoryItemTimeEdit2
            // 
            this.repositoryItemTimeEdit2.AutoHeight = false;
            this.repositoryItemTimeEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemTimeEdit2.Name = "repositoryItemTimeEdit2";
            // 
            // colLatenessLateness
            // 
            this.colLatenessLateness.Caption = "Lateness (Minutes)";
            this.colLatenessLateness.DisplayFormat.FormatString = "#.00";
            this.colLatenessLateness.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colLatenessLateness.FieldName = "nLateness";
            this.colLatenessLateness.Name = "colLatenessLateness";
            this.colLatenessLateness.SummaryItem.DisplayFormat = "{0:#.00}";
            this.colLatenessLateness.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colLatenessLateness.Visible = true;
            this.colLatenessLateness.VisibleIndex = 5;
            this.colLatenessLateness.Width = 169;
            // 
            // tabStaffFour
            // 
            this.tabStaffFour.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabStaffFour.Appearance.Header.Options.UseFont = true;
            this.tabStaffFour.Controls.Add(this.lblFour_2);
            this.tabStaffFour.Controls.Add(this.lblFour_1);
            this.tabStaffFour.Controls.Add(this.groupAppointment);
            this.tabStaffFour.Controls.Add(this.groupContact);
            this.tabStaffFour.Name = "tabStaffFour";
            this.tabStaffFour.PageVisible = false;
            this.tabStaffFour.Size = new System.Drawing.Size(1007, 612);
            this.tabStaffFour.Text = "Appointments";
            this.tabStaffFour.VisibleChanged += new System.EventHandler(this.tabStaffAppointments_VisibleChanged);
            // 
            // lblFour_2
            // 
            this.lblFour_2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFour_2.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblFour_2.Appearance.Options.UseFont = true;
            this.lblFour_2.Appearance.Options.UseForeColor = true;
            this.lblFour_2.Location = new System.Drawing.Point(160, 8);
            this.lblFour_2.Name = "lblFour_2";
            this.lblFour_2.Size = new System.Drawing.Size(138, 23);
            this.lblFour_2.TabIndex = 144;
            this.lblFour_2.Text = "Contact";
            this.lblFour_2.Click += new System.EventHandler(this.lblFour_2_Click);
            // 
            // lblFour_1
            // 
            this.lblFour_1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFour_1.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblFour_1.Appearance.Options.UseFont = true;
            this.lblFour_1.Appearance.Options.UseForeColor = true;
            this.lblFour_1.Location = new System.Drawing.Point(8, 8);
            this.lblFour_1.Name = "lblFour_1";
            this.lblFour_1.Size = new System.Drawing.Size(138, 23);
            this.lblFour_1.TabIndex = 143;
            this.lblFour_1.Text = "Appointment";
            this.lblFour_1.Click += new System.EventHandler(this.lblFour_1_Click);
            // 
            // groupAppointment
            // 
            this.groupAppointment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupAppointment.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupAppointment.Controls.Add(this.groupAppointmentEntry);
            this.groupAppointment.Location = new System.Drawing.Point(0, 34);
            this.groupAppointment.Name = "groupAppointment";
            this.groupAppointment.ShowCaption = false;
            this.groupAppointment.Size = new System.Drawing.Size(1007, 584);
            this.groupAppointment.TabIndex = 21;
            this.groupAppointment.Text = "GroupControl3";
            // 
            // groupAppointmentEntry
            // 
            this.groupAppointmentEntry.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupAppointmentEntry.Appearance.Options.UseBackColor = true;
            this.groupAppointmentEntry.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupAppointmentEntry.Controls.Add(this.groupControl12);
            this.groupAppointmentEntry.Controls.Add(this.sbtnAppointmentDelete);
            this.groupAppointmentEntry.Controls.Add(this.sbtnAppointmentPrint);
            this.groupAppointmentEntry.Controls.Add(this.sbtnAppointmentEdit);
            this.groupAppointmentEntry.Controls.Add(this.sbtnAppointmentNew);
            this.groupAppointmentEntry.Controls.Add(this.gridctrAppointment);
            this.groupAppointmentEntry.Location = new System.Drawing.Point(8, 0);
            this.groupAppointmentEntry.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupAppointmentEntry.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupAppointmentEntry.Name = "groupAppointmentEntry";
            this.groupAppointmentEntry.Size = new System.Drawing.Size(992, 576);
            this.groupAppointmentEntry.TabIndex = 0;
            this.groupAppointmentEntry.Text = "APPOINTMENT";
            // 
            // groupControl12
            // 
            this.groupControl12.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupControl12.Controls.Add(this.cbAppointmentYear);
            this.groupControl12.Controls.Add(this.label26);
            this.groupControl12.Controls.Add(this.label27);
            this.groupControl12.Controls.Add(this.cbAppointmentMonth);
            this.groupControl12.Controls.Add(this.sbtnAppointmentInquiry);
            this.groupControl12.Location = new System.Drawing.Point(8, 24);
            this.groupControl12.Name = "groupControl12";
            this.groupControl12.Size = new System.Drawing.Size(328, 52);
            this.groupControl12.TabIndex = 0;
            this.groupControl12.Text = "Inquiry";
            // 
            // cbAppointmentYear
            // 
            this.cbAppointmentYear.EditValue = "";
            this.cbAppointmentYear.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cbAppointmentYear.Location = new System.Drawing.Point(178, 24);
            this.cbAppointmentYear.Name = "cbAppointmentYear";
            this.cbAppointmentYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbAppointmentYear.Properties.PopupSizeable = true;
            this.cbAppointmentYear.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbAppointmentYear.Size = new System.Drawing.Size(64, 20);
            this.cbAppointmentYear.TabIndex = 1;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(140, 24);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(34, 20);
            this.label26.TabIndex = 15;
            this.label26.Text = "Year:";
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(12, 24);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(42, 20);
            this.label27.TabIndex = 14;
            this.label27.Text = "Month:";
            // 
            // cbAppointmentMonth
            // 
            this.cbAppointmentMonth.EditValue = "January";
            this.cbAppointmentMonth.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cbAppointmentMonth.Location = new System.Drawing.Point(56, 24);
            this.cbAppointmentMonth.Name = "cbAppointmentMonth";
            this.cbAppointmentMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbAppointmentMonth.Properties.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cbAppointmentMonth.Properties.PopupSizeable = true;
            this.cbAppointmentMonth.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbAppointmentMonth.Size = new System.Drawing.Size(80, 20);
            this.cbAppointmentMonth.TabIndex = 0;
            // 
            // sbtnAppointmentInquiry
            // 
            this.sbtnAppointmentInquiry.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnAppointmentInquiry.Appearance.Options.UseFont = true;
            this.sbtnAppointmentInquiry.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnAppointmentInquiry.Location = new System.Drawing.Point(246, 24);
            this.sbtnAppointmentInquiry.Name = "sbtnAppointmentInquiry";
            this.sbtnAppointmentInquiry.Size = new System.Drawing.Size(72, 20);
            this.sbtnAppointmentInquiry.TabIndex = 2;
            this.sbtnAppointmentInquiry.Text = "Inquiry";
            this.sbtnAppointmentInquiry.Click += new System.EventHandler(this.sbtnAppointmentInquiry_Click);
            // 
            // sbtnAppointmentDelete
            // 
            this.sbtnAppointmentDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnAppointmentDelete.Appearance.Options.UseFont = true;
            this.sbtnAppointmentDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnAppointmentDelete.Location = new System.Drawing.Point(504, 48);
            this.sbtnAppointmentDelete.Name = "sbtnAppointmentDelete";
            this.sbtnAppointmentDelete.Size = new System.Drawing.Size(72, 20);
            this.sbtnAppointmentDelete.TabIndex = 3;
            this.sbtnAppointmentDelete.Text = "Delete";
            this.sbtnAppointmentDelete.Click += new System.EventHandler(this.sbtnAppointmentDelete_Click);
            // 
            // sbtnAppointmentPrint
            // 
            this.sbtnAppointmentPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnAppointmentPrint.Appearance.Options.UseFont = true;
            this.sbtnAppointmentPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnAppointmentPrint.Location = new System.Drawing.Point(584, 48);
            this.sbtnAppointmentPrint.Name = "sbtnAppointmentPrint";
            this.sbtnAppointmentPrint.Size = new System.Drawing.Size(72, 20);
            this.sbtnAppointmentPrint.TabIndex = 3;
            this.sbtnAppointmentPrint.Text = "Print";
            this.sbtnAppointmentPrint.Click += new System.EventHandler(this.sbtnAppointmentPrint_Click);
            // 
            // sbtnAppointmentEdit
            // 
            this.sbtnAppointmentEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnAppointmentEdit.Appearance.Options.UseFont = true;
            this.sbtnAppointmentEdit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnAppointmentEdit.Location = new System.Drawing.Point(424, 48);
            this.sbtnAppointmentEdit.Name = "sbtnAppointmentEdit";
            this.sbtnAppointmentEdit.Size = new System.Drawing.Size(72, 20);
            this.sbtnAppointmentEdit.TabIndex = 2;
            this.sbtnAppointmentEdit.Text = "Edit";
            this.sbtnAppointmentEdit.Click += new System.EventHandler(this.sbtnAppointmentEdit_Click);
            // 
            // sbtnAppointmentNew
            // 
            this.sbtnAppointmentNew.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnAppointmentNew.Appearance.Options.UseFont = true;
            this.sbtnAppointmentNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnAppointmentNew.Location = new System.Drawing.Point(344, 48);
            this.sbtnAppointmentNew.Name = "sbtnAppointmentNew";
            this.sbtnAppointmentNew.Size = new System.Drawing.Size(72, 20);
            this.sbtnAppointmentNew.TabIndex = 1;
            this.sbtnAppointmentNew.Text = "New";
            this.sbtnAppointmentNew.Click += new System.EventHandler(this.sbtnAppointmentNew_Click);
            // 
            // gridctrAppointment
            // 
            this.gridctrAppointment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridctrAppointment.EmbeddedNavigator.Name = "";
            this.gridctrAppointment.Location = new System.Drawing.Point(2, 86);
            this.gridctrAppointment.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridctrAppointment.MainView = this.gvAppointment;
            this.gridctrAppointment.Name = "gridctrAppointment";
            this.gridctrAppointment.Size = new System.Drawing.Size(988, 488);
            this.gridctrAppointment.TabIndex = 4;
            this.gridctrAppointment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAppointment});
            // 
            // gvAppointment
            // 
            this.gvAppointment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAppointmentDate,
            this.colAppointmentStartDate,
            this.colAppointmentEndDate,
            this.colAppointmentOrganization,
            this.colAppointmentContact,
            this.colAppointmentTypeID,
            this.colAppointmentRemarks});
            this.gvAppointment.GridControl = this.gridctrAppointment;
            this.gvAppointment.Name = "gvAppointment";
            this.gvAppointment.OptionsBehavior.AllowIncrementalSearch = true;
            this.gvAppointment.OptionsBehavior.Editable = false;
            this.gvAppointment.OptionsCustomization.AllowFilter = false;
            this.gvAppointment.OptionsView.ShowGroupPanel = false;
            this.gvAppointment.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colAppointmentDate, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // colAppointmentDate
            // 
            this.colAppointmentDate.Caption = "Date";
            this.colAppointmentDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colAppointmentDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colAppointmentDate.FieldName = "dtDate";
            this.colAppointmentDate.Name = "colAppointmentDate";
            this.colAppointmentDate.Visible = true;
            this.colAppointmentDate.VisibleIndex = 0;
            this.colAppointmentDate.Width = 93;
            // 
            // colAppointmentStartDate
            // 
            this.colAppointmentStartDate.Caption = "Start Time";
            this.colAppointmentStartDate.DisplayFormat.FormatString = "hh:mm tt";
            this.colAppointmentStartDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colAppointmentStartDate.FieldName = "dtStartTime";
            this.colAppointmentStartDate.Name = "colAppointmentStartDate";
            this.colAppointmentStartDate.Visible = true;
            this.colAppointmentStartDate.VisibleIndex = 1;
            this.colAppointmentStartDate.Width = 85;
            // 
            // colAppointmentEndDate
            // 
            this.colAppointmentEndDate.Caption = "End Time";
            this.colAppointmentEndDate.DisplayFormat.FormatString = "hh:mm tt";
            this.colAppointmentEndDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colAppointmentEndDate.FieldName = "dtEndTime";
            this.colAppointmentEndDate.Name = "colAppointmentEndDate";
            this.colAppointmentEndDate.Visible = true;
            this.colAppointmentEndDate.VisibleIndex = 2;
            this.colAppointmentEndDate.Width = 79;
            // 
            // colAppointmentOrganization
            // 
            this.colAppointmentOrganization.Caption = "Organization / Place of Appointment";
            this.colAppointmentOrganization.FieldName = "strOrganization";
            this.colAppointmentOrganization.Name = "colAppointmentOrganization";
            this.colAppointmentOrganization.Visible = true;
            this.colAppointmentOrganization.VisibleIndex = 3;
            this.colAppointmentOrganization.Width = 215;
            // 
            // colAppointmentContact
            // 
            this.colAppointmentContact.Caption = "Contact";
            this.colAppointmentContact.FieldName = "strContactName";
            this.colAppointmentContact.Name = "colAppointmentContact";
            this.colAppointmentContact.Visible = true;
            this.colAppointmentContact.VisibleIndex = 4;
            this.colAppointmentContact.Width = 153;
            // 
            // colAppointmentTypeID
            // 
            this.colAppointmentTypeID.Caption = "Appointment Type";
            this.colAppointmentTypeID.FieldName = "nAppointmentTypeId";
            this.colAppointmentTypeID.Name = "colAppointmentTypeID";
            this.colAppointmentTypeID.Visible = true;
            this.colAppointmentTypeID.VisibleIndex = 5;
            // 
            // colAppointmentRemarks
            // 
            this.colAppointmentRemarks.Caption = "Remarks";
            this.colAppointmentRemarks.FieldName = "strRemarks";
            this.colAppointmentRemarks.Name = "colAppointmentRemarks";
            this.colAppointmentRemarks.Visible = true;
            this.colAppointmentRemarks.VisibleIndex = 6;
            this.colAppointmentRemarks.Width = 342;
            // 
            // groupContact
            // 
            this.groupContact.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupContact.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupContact.Controls.Add(this.groupContactEntry);
            this.groupContact.Location = new System.Drawing.Point(0, 34);
            this.groupContact.Name = "groupContact";
            this.groupContact.ShowCaption = false;
            this.groupContact.Size = new System.Drawing.Size(1007, 584);
            this.groupContact.TabIndex = 20;
            this.groupContact.Text = "GroupControl3";
            // 
            // groupContactEntry
            // 
            this.groupContactEntry.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupContactEntry.Appearance.Options.UseBackColor = true;
            this.groupContactEntry.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupContactEntry.Controls.Add(this.sbtnContactEdit);
            this.groupContactEntry.Controls.Add(this.sbtnContactDelete);
            this.groupContactEntry.Controls.Add(this.sbtnContactNew);
            this.groupContactEntry.Controls.Add(this.gridctrContact);
            this.groupContactEntry.Location = new System.Drawing.Point(8, 0);
            this.groupContactEntry.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupContactEntry.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupContactEntry.Name = "groupContactEntry";
            this.groupContactEntry.Size = new System.Drawing.Size(992, 576);
            this.groupContactEntry.TabIndex = 1;
            this.groupContactEntry.Text = "CONTACT";
            // 
            // sbtnContactEdit
            // 
            this.sbtnContactEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnContactEdit.Appearance.Options.UseFont = true;
            this.sbtnContactEdit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnContactEdit.Location = new System.Drawing.Point(96, 32);
            this.sbtnContactEdit.Name = "sbtnContactEdit";
            this.sbtnContactEdit.Size = new System.Drawing.Size(72, 20);
            this.sbtnContactEdit.TabIndex = 1;
            this.sbtnContactEdit.Text = "Edit";
            this.sbtnContactEdit.Click += new System.EventHandler(this.sbtnContactEdit_Click);
            // 
            // sbtnContactDelete
            // 
            this.sbtnContactDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnContactDelete.Appearance.Options.UseFont = true;
            this.sbtnContactDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnContactDelete.Location = new System.Drawing.Point(176, 32);
            this.sbtnContactDelete.Name = "sbtnContactDelete";
            this.sbtnContactDelete.Size = new System.Drawing.Size(72, 20);
            this.sbtnContactDelete.TabIndex = 2;
            this.sbtnContactDelete.Text = "Delete";
            this.sbtnContactDelete.Click += new System.EventHandler(this.sbtnContactDelete_Click);
            // 
            // sbtnContactNew
            // 
            this.sbtnContactNew.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnContactNew.Appearance.Options.UseFont = true;
            this.sbtnContactNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnContactNew.Location = new System.Drawing.Point(16, 32);
            this.sbtnContactNew.Name = "sbtnContactNew";
            this.sbtnContactNew.Size = new System.Drawing.Size(72, 20);
            this.sbtnContactNew.TabIndex = 0;
            this.sbtnContactNew.Text = "New";
            this.sbtnContactNew.Click += new System.EventHandler(this.sbtnContactNew_Click);
            // 
            // gridctrContact
            // 
            this.gridctrContact.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridctrContact.EmbeddedNavigator.Name = "";
            this.gridctrContact.Location = new System.Drawing.Point(2, 62);
            this.gridctrContact.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridctrContact.MainView = this.gvContact;
            this.gridctrContact.Name = "gridctrContact";
            this.gridctrContact.Size = new System.Drawing.Size(988, 512);
            this.gridctrContact.TabIndex = 3;
            this.gridctrContact.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvContact});
            // 
            // gvContact
            // 
            this.gvContact.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colContactPerson,
            this.colContactOrganization,
            this.colContactMobile,
            this.colContactOfficeNo,
            this.colContactEmail,
            this.colContactFax,
            this.colContactAddress});
            this.gvContact.GridControl = this.gridctrContact;
            this.gvContact.Name = "gvContact";
            this.gvContact.OptionsBehavior.AllowIncrementalSearch = true;
            this.gvContact.OptionsBehavior.Editable = false;
            this.gvContact.OptionsCustomization.AllowFilter = false;
            this.gvContact.OptionsView.ShowGroupPanel = false;
            // 
            // colContactPerson
            // 
            this.colContactPerson.Caption = "Contact Person";
            this.colContactPerson.FieldName = "strContactName";
            this.colContactPerson.Name = "colContactPerson";
            this.colContactPerson.Visible = true;
            this.colContactPerson.VisibleIndex = 0;
            this.colContactPerson.Width = 128;
            // 
            // colContactOrganization
            // 
            this.colContactOrganization.Caption = "Organization";
            this.colContactOrganization.FieldName = "strOrganization";
            this.colContactOrganization.Name = "colContactOrganization";
            this.colContactOrganization.Visible = true;
            this.colContactOrganization.VisibleIndex = 1;
            this.colContactOrganization.Width = 150;
            // 
            // colContactMobile
            // 
            this.colContactMobile.Caption = "Mobile No.";
            this.colContactMobile.FieldName = "strMobileNo";
            this.colContactMobile.Name = "colContactMobile";
            this.colContactMobile.Visible = true;
            this.colContactMobile.VisibleIndex = 2;
            this.colContactMobile.Width = 107;
            // 
            // colContactOfficeNo
            // 
            this.colContactOfficeNo.Caption = "Office No.";
            this.colContactOfficeNo.FieldName = "strOfficeNo";
            this.colContactOfficeNo.Name = "colContactOfficeNo";
            this.colContactOfficeNo.Visible = true;
            this.colContactOfficeNo.VisibleIndex = 3;
            this.colContactOfficeNo.Width = 111;
            // 
            // colContactEmail
            // 
            this.colContactEmail.Caption = "Email Address";
            this.colContactEmail.FieldName = "strEmail";
            this.colContactEmail.Name = "colContactEmail";
            this.colContactEmail.Visible = true;
            this.colContactEmail.VisibleIndex = 4;
            this.colContactEmail.Width = 159;
            // 
            // colContactFax
            // 
            this.colContactFax.Caption = "Fax";
            this.colContactFax.FieldName = "strFax";
            this.colContactFax.Name = "colContactFax";
            this.colContactFax.Visible = true;
            this.colContactFax.VisibleIndex = 5;
            this.colContactFax.Width = 102;
            // 
            // colContactAddress
            // 
            this.colContactAddress.Caption = "Address";
            this.colContactAddress.FieldName = "strAddress";
            this.colContactAddress.Name = "colContactAddress";
            this.colContactAddress.Visible = true;
            this.colContactAddress.VisibleIndex = 6;
            this.colContactAddress.Width = 210;
            // 
            // tabStaffFive
            // 
            this.tabStaffFive.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabStaffFive.Appearance.Header.Options.UseFont = true;
            this.tabStaffFive.Controls.Add(this.groupCustomerVoice);
            this.tabStaffFive.Name = "tabStaffFive";
            this.tabStaffFive.PageVisible = false;
            this.tabStaffFive.Size = new System.Drawing.Size(1007, 612);
            this.tabStaffFive.Text = "Customer Voice";
            this.tabStaffFive.VisibleChanged += new System.EventHandler(this.tabStaffCustomerVoice_VisibleChanged);
            // 
            // groupCustomerVoice
            // 
            this.groupCustomerVoice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupCustomerVoice.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupCustomerVoice.Controls.Add(this.lblmnuCustomerVoiceActionHistory);
            this.groupCustomerVoice.Controls.Add(this.lblmnuCustomerVoiceCVDetails);
            this.groupCustomerVoice.Controls.Add(this.GroupControl24);
            this.groupCustomerVoice.Controls.Add(this.groupCustomerVoiceActionHistory);
            this.groupCustomerVoice.Controls.Add(this.groupCustomerVoiceCVDetails);
            this.groupCustomerVoice.Location = new System.Drawing.Point(0, 8);
            this.groupCustomerVoice.Name = "groupCustomerVoice";
            this.groupCustomerVoice.ShowCaption = false;
            this.groupCustomerVoice.Size = new System.Drawing.Size(1007, 584);
            this.groupCustomerVoice.TabIndex = 11;
            this.groupCustomerVoice.Text = "GroupControl1";
            // 
            // lblmnuCustomerVoiceActionHistory
            // 
            this.lblmnuCustomerVoiceActionHistory.AutoSize = true;
            this.lblmnuCustomerVoiceActionHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmnuCustomerVoiceActionHistory.Location = new System.Drawing.Point(184, 320);
            this.lblmnuCustomerVoiceActionHistory.Name = "lblmnuCustomerVoiceActionHistory";
            this.lblmnuCustomerVoiceActionHistory.Size = new System.Drawing.Size(104, 16);
            this.lblmnuCustomerVoiceActionHistory.TabIndex = 10;
            this.lblmnuCustomerVoiceActionHistory.Text = "Action History";
            this.lblmnuCustomerVoiceActionHistory.Click += new System.EventHandler(this.lblmnuCustomerVoiceActionHistory_Click);
            // 
            // lblmnuCustomerVoiceCVDetails
            // 
            this.lblmnuCustomerVoiceCVDetails.AutoSize = true;
            this.lblmnuCustomerVoiceCVDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmnuCustomerVoiceCVDetails.Location = new System.Drawing.Point(24, 320);
            this.lblmnuCustomerVoiceCVDetails.Name = "lblmnuCustomerVoiceCVDetails";
            this.lblmnuCustomerVoiceCVDetails.Size = new System.Drawing.Size(170, 16);
            this.lblmnuCustomerVoiceCVDetails.TabIndex = 9;
            this.lblmnuCustomerVoiceCVDetails.Text = "Customer Voice Details";
            this.lblmnuCustomerVoiceCVDetails.Click += new System.EventHandler(this.lblmnuCustomerVoiceCVDetails_Click);
            // 
            // GroupControl24
            // 
            this.GroupControl24.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.GroupControl24.Appearance.Options.UseBackColor = true;
            this.GroupControl24.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.GroupControl24.Controls.Add(this.luedtCVSubmitter);
            this.GroupControl24.Controls.Add(this.sbtnAssign);
            this.GroupControl24.Controls.Add(this.sbtnCVPrint);
            this.GroupControl24.Controls.Add(this.sbtnCVEdit);
            this.GroupControl24.Controls.Add(this.sbtnCVDelete);
            this.GroupControl24.Controls.Add(this.sbtnCVNew);
            this.GroupControl24.Controls.Add(this.cbListCV);
            this.GroupControl24.Controls.Add(this.gctrCV);
            this.GroupControl24.Controls.Add(this.label17);
            this.GroupControl24.Controls.Add(this.luedtCVAssignTo);
            this.GroupControl24.Controls.Add(this.lblCVSubmitter);
            this.GroupControl24.Location = new System.Drawing.Point(8, 0);
            this.GroupControl24.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.GroupControl24.LookAndFeel.UseDefaultLookAndFeel = false;
            this.GroupControl24.Name = "GroupControl24";
            this.GroupControl24.Size = new System.Drawing.Size(992, 312);
            this.GroupControl24.TabIndex = 0;
            this.GroupControl24.Text = "CUSTOMER VOICE";
            // 
            // luedtCVSubmitter
            // 
            this.luedtCVSubmitter.Location = new System.Drawing.Point(400, 32);
            this.luedtCVSubmitter.Name = "luedtCVSubmitter";
            this.luedtCVSubmitter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luedtCVSubmitter.Size = new System.Drawing.Size(176, 20);
            this.luedtCVSubmitter.TabIndex = 2;
            this.luedtCVSubmitter.EditValueChanged += new System.EventHandler(this.luedtCVSubmiter_EditValueChanged);
            // 
            // sbtnAssign
            // 
            this.sbtnAssign.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnAssign.Appearance.Options.UseFont = true;
            this.sbtnAssign.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnAssign.Location = new System.Drawing.Point(824, 32);
            this.sbtnAssign.Name = "sbtnAssign";
            this.sbtnAssign.Size = new System.Drawing.Size(80, 20);
            this.sbtnAssign.TabIndex = 6;
            this.sbtnAssign.Text = "Assign To";
            this.sbtnAssign.Click += new System.EventHandler(this.sbtnAssign_Click);
            // 
            // sbtnCVPrint
            // 
            this.sbtnCVPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnCVPrint.Appearance.Options.UseFont = true;
            this.sbtnCVPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnCVPrint.Location = new System.Drawing.Point(912, 32);
            this.sbtnCVPrint.Name = "sbtnCVPrint";
            this.sbtnCVPrint.Size = new System.Drawing.Size(72, 20);
            this.sbtnCVPrint.TabIndex = 7;
            this.sbtnCVPrint.Text = "Print";
            this.sbtnCVPrint.Click += new System.EventHandler(this.sbtnCVPrint_Click);
            // 
            // sbtnCVEdit
            // 
            this.sbtnCVEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnCVEdit.Appearance.Options.UseFont = true;
            this.sbtnCVEdit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnCVEdit.Location = new System.Drawing.Point(744, 32);
            this.sbtnCVEdit.Name = "sbtnCVEdit";
            this.sbtnCVEdit.Size = new System.Drawing.Size(72, 20);
            this.sbtnCVEdit.TabIndex = 5;
            this.sbtnCVEdit.Text = "Update";
            this.sbtnCVEdit.Click += new System.EventHandler(this.sbtnCVEdit_Click);
            // 
            // sbtnCVDelete
            // 
            this.sbtnCVDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnCVDelete.Appearance.Options.UseFont = true;
            this.sbtnCVDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnCVDelete.Location = new System.Drawing.Point(664, 32);
            this.sbtnCVDelete.Name = "sbtnCVDelete";
            this.sbtnCVDelete.Size = new System.Drawing.Size(72, 20);
            this.sbtnCVDelete.TabIndex = 4;
            this.sbtnCVDelete.Text = "Delete";
            this.sbtnCVDelete.Click += new System.EventHandler(this.sbtnCVDelete_Click);
            // 
            // sbtnCVNew
            // 
            this.sbtnCVNew.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnCVNew.Appearance.Options.UseFont = true;
            this.sbtnCVNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnCVNew.Location = new System.Drawing.Point(584, 32);
            this.sbtnCVNew.Name = "sbtnCVNew";
            this.sbtnCVNew.Size = new System.Drawing.Size(72, 20);
            this.sbtnCVNew.TabIndex = 3;
            this.sbtnCVNew.Text = "New";
            this.sbtnCVNew.Click += new System.EventHandler(this.sbtnCVNew_Click);
            // 
            // cbListCV
            // 
            this.cbListCV.EditValue = "All";
            this.cbListCV.Location = new System.Drawing.Point(8, 32);
            this.cbListCV.Name = "cbListCV";
            this.cbListCV.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbListCV.Properties.Items.AddRange(new object[] {
            "All",
            "New",
            "Open",
            "Closed"});
            this.cbListCV.Properties.PopupSizeable = true;
            this.cbListCV.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbListCV.Size = new System.Drawing.Size(88, 20);
            this.cbListCV.TabIndex = 0;
            this.cbListCV.SelectedIndexChanged += new System.EventHandler(this.cbListCV_SelectedIndexChanged);
            // 
            // gctrCV
            // 
            this.gctrCV.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gctrCV.EmbeddedNavigator.Name = "";
            this.gctrCV.Location = new System.Drawing.Point(2, 62);
            this.gctrCV.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gctrCV.MainView = this.gvCV;
            this.gctrCV.Name = "gctrCV";
            this.gctrCV.Size = new System.Drawing.Size(988, 248);
            this.gctrCV.TabIndex = 8;
            this.gctrCV.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCV});
            // 
            // gvCV
            // 
            this.gvCV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRefNo,
            this.colDtReceived,
            this.colBranch,
            this.colMembershipID,
            this.colMemberName,
            this.colDepartment,
            this.colType,
            this.colCategory,
            this.colSubject,
            this.colSubmittedBy,
            this.colStaffSubject,
            this.colDepartmentAssignedTo,
            this.colLastUpdatedDate,
            this.colStatus});
            this.gvCV.GridControl = this.gctrCV;
            this.gvCV.Name = "gvCV";
            this.gvCV.OptionsBehavior.AllowIncrementalSearch = true;
            this.gvCV.OptionsBehavior.Editable = false;
            this.gvCV.OptionsCustomization.AllowFilter = false;
            this.gvCV.OptionsView.ColumnAutoWidth = false;
            this.gvCV.OptionsView.ShowGroupPanel = false;
            this.gvCV.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDtReceived, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gvCV.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvCV_FocusedRowChanged);
            this.gvCV.DataSourceChanged += new System.EventHandler(this.gvCV_DataSourceChanged);
            // 
            // colRefNo
            // 
            this.colRefNo.Caption = "Ref No";
            this.colRefNo.FieldName = "nCaseID";
            this.colRefNo.Name = "colRefNo";
            this.colRefNo.Visible = true;
            this.colRefNo.VisibleIndex = 0;
            // 
            // colDtReceived
            // 
            this.colDtReceived.Caption = "Date Received";
            this.colDtReceived.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colDtReceived.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDtReceived.FieldName = "dtDate";
            this.colDtReceived.Name = "colDtReceived";
            this.colDtReceived.Visible = true;
            this.colDtReceived.VisibleIndex = 1;
            this.colDtReceived.Width = 100;
            // 
            // colBranch
            // 
            this.colBranch.Caption = "Branch";
            this.colBranch.FieldName = "strBranchCode";
            this.colBranch.Name = "colBranch";
            this.colBranch.Visible = true;
            this.colBranch.VisibleIndex = 2;
            // 
            // colMembershipID
            // 
            this.colMembershipID.Caption = "Membership Id";
            this.colMembershipID.FieldName = "strMembershipID";
            this.colMembershipID.Name = "colMembershipID";
            this.colMembershipID.Visible = true;
            this.colMembershipID.VisibleIndex = 6;
            this.colMembershipID.Width = 100;
            // 
            // colMemberName
            // 
            this.colMemberName.Caption = "Member Name";
            this.colMemberName.FieldName = "strMembershipName";
            this.colMemberName.Name = "colMemberName";
            this.colMemberName.Visible = true;
            this.colMemberName.VisibleIndex = 3;
            this.colMemberName.Width = 101;
            // 
            // colDepartment
            // 
            this.colDepartment.Caption = "Department";
            this.colDepartment.FieldName = "strDepartmentDescription";
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.Visible = true;
            this.colDepartment.VisibleIndex = 7;
            this.colDepartment.Width = 89;
            // 
            // colType
            // 
            this.colType.Caption = "Type";
            this.colType.FieldName = "strCaseTypeDescription";
            this.colType.Name = "colType";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 4;
            // 
            // colCategory
            // 
            this.colCategory.Caption = "Category";
            this.colCategory.FieldName = "strCaseCategoryDescription";
            this.colCategory.Name = "colCategory";
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 5;
            // 
            // colSubject
            // 
            this.colSubject.Caption = "Subject";
            this.colSubject.FieldName = "strSubject";
            this.colSubject.Name = "colSubject";
            // 
            // colSubmittedBy
            // 
            this.colSubmittedBy.Caption = "Submitted By";
            this.colSubmittedBy.FieldName = "strSubmittedBy";
            this.colSubmittedBy.Name = "colSubmittedBy";
            this.colSubmittedBy.Visible = true;
            this.colSubmittedBy.VisibleIndex = 8;
            this.colSubmittedBy.Width = 97;
            // 
            // colStaffSubject
            // 
            this.colStaffSubject.Caption = "Subject Staff ";
            this.colStaffSubject.FieldName = "strSubjectStaff";
            this.colStaffSubject.Name = "colStaffSubject";
            // 
            // colDepartmentAssignedTo
            // 
            this.colDepartmentAssignedTo.Caption = "Department Assigned To";
            this.colDepartmentAssignedTo.FieldName = "strDepartmentAssignedTo";
            this.colDepartmentAssignedTo.Name = "colDepartmentAssignedTo";
            this.colDepartmentAssignedTo.Visible = true;
            this.colDepartmentAssignedTo.VisibleIndex = 9;
            this.colDepartmentAssignedTo.Width = 130;
            // 
            // colLastUpdatedDate
            // 
            this.colLastUpdatedDate.Caption = "Last Updated Date";
            this.colLastUpdatedDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colLastUpdatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colLastUpdatedDate.FieldName = "dtLastEditDate";
            this.colLastUpdatedDate.Name = "colLastUpdatedDate";
            this.colLastUpdatedDate.Visible = true;
            this.colLastUpdatedDate.VisibleIndex = 10;
            this.colLastUpdatedDate.Width = 100;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "strStatus";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 11;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(104, 32);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 20);
            this.label17.TabIndex = 19;
            this.label17.Text = "Assign To:";
            // 
            // luedtCVAssignTo
            // 
            this.luedtCVAssignTo.Location = new System.Drawing.Point(168, 32);
            this.luedtCVAssignTo.Name = "luedtCVAssignTo";
            this.luedtCVAssignTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luedtCVAssignTo.Size = new System.Drawing.Size(160, 20);
            this.luedtCVAssignTo.TabIndex = 1;
            this.luedtCVAssignTo.EditValueChanged += new System.EventHandler(this.luedtCVAssignTo_EditValueChanged);
            // 
            // lblCVSubmitter
            // 
            this.lblCVSubmitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCVSubmitter.Location = new System.Drawing.Point(336, 32);
            this.lblCVSubmitter.Name = "lblCVSubmitter";
            this.lblCVSubmitter.Size = new System.Drawing.Size(64, 20);
            this.lblCVSubmitter.TabIndex = 16;
            this.lblCVSubmitter.Text = "Submitter:";
            // 
            // groupCustomerVoiceActionHistory
            // 
            this.groupCustomerVoiceActionHistory.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupCustomerVoiceActionHistory.Appearance.Options.UseBackColor = true;
            this.groupCustomerVoiceActionHistory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupCustomerVoiceActionHistory.Controls.Add(this.GroupControl26);
            this.groupCustomerVoiceActionHistory.Location = new System.Drawing.Point(7, 344);
            this.groupCustomerVoiceActionHistory.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupCustomerVoiceActionHistory.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupCustomerVoiceActionHistory.Name = "groupCustomerVoiceActionHistory";
            this.groupCustomerVoiceActionHistory.Size = new System.Drawing.Size(992, 232);
            this.groupCustomerVoiceActionHistory.TabIndex = 11;
            this.groupCustomerVoiceActionHistory.Text = "ACTION HISTORY";
            // 
            // GroupControl26
            // 
            this.GroupControl26.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.GroupControl26.Controls.Add(this.sbtnNewCVAction);
            this.GroupControl26.Controls.Add(this.gctrCVAction);
            this.GroupControl26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupControl26.Location = new System.Drawing.Point(2, 19);
            this.GroupControl26.Name = "GroupControl26";
            this.GroupControl26.ShowCaption = false;
            this.GroupControl26.Size = new System.Drawing.Size(988, 211);
            this.GroupControl26.TabIndex = 0;
            this.GroupControl26.Text = "GroupControl1";
            // 
            // sbtnNewCVAction
            // 
            this.sbtnNewCVAction.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnNewCVAction.Appearance.Options.UseFont = true;
            this.sbtnNewCVAction.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnNewCVAction.Location = new System.Drawing.Point(16, 16);
            this.sbtnNewCVAction.Name = "sbtnNewCVAction";
            this.sbtnNewCVAction.Size = new System.Drawing.Size(72, 20);
            this.sbtnNewCVAction.TabIndex = 0;
            this.sbtnNewCVAction.Text = "New";
            this.sbtnNewCVAction.Click += new System.EventHandler(this.sbtnNewCVAction_Click);
            // 
            // gctrCVAction
            // 
            this.gctrCVAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gctrCVAction.EmbeddedNavigator.Name = "";
            this.gctrCVAction.Location = new System.Drawing.Point(2, 49);
            this.gctrCVAction.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gctrCVAction.MainView = this.gvCVAction;
            this.gctrCVAction.Name = "gctrCVAction";
            this.gctrCVAction.Size = new System.Drawing.Size(984, 160);
            this.gctrCVAction.TabIndex = 1;
            this.gctrCVAction.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCVAction});
            // 
            // gvCVAction
            // 
            this.gvCVAction.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colActionID,
            this.coldtDate,
            this.coldtTime,
            this.colMode,
            this.colActionDetail,
            this.colActionTakenBy,
            this.colActionTakenByID});
            this.gvCVAction.GridControl = this.gctrCVAction;
            this.gvCVAction.Name = "gvCVAction";
            this.gvCVAction.OptionsBehavior.AllowIncrementalSearch = true;
            this.gvCVAction.OptionsBehavior.Editable = false;
            this.gvCVAction.OptionsCustomization.AllowFilter = false;
            this.gvCVAction.OptionsView.ShowGroupPanel = false;
            this.gvCVAction.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.coldtDate, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // colActionID
            // 
            this.colActionID.Caption = "ID";
            this.colActionID.FieldName = "nActionID";
            this.colActionID.Name = "colActionID";
            this.colActionID.Visible = true;
            this.colActionID.VisibleIndex = 0;
            this.colActionID.Width = 64;
            // 
            // coldtDate
            // 
            this.coldtDate.Caption = "Date";
            this.coldtDate.DisplayFormat.FormatString = "dd/MM/yyy";
            this.coldtDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.coldtDate.FieldName = "dtDate";
            this.coldtDate.Name = "coldtDate";
            this.coldtDate.Visible = true;
            this.coldtDate.VisibleIndex = 1;
            this.coldtDate.Width = 117;
            // 
            // coldtTime
            // 
            this.coldtTime.Caption = "Time";
            this.coldtTime.DisplayFormat.FormatString = "hh:mm tt";
            this.coldtTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.coldtTime.FieldName = "dtDate";
            this.coldtTime.GroupFormat.FormatString = "hh:mm tt";
            this.coldtTime.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.coldtTime.Name = "coldtTime";
            this.coldtTime.Visible = true;
            this.coldtTime.VisibleIndex = 2;
            this.coldtTime.Width = 78;
            // 
            // colMode
            // 
            this.colMode.Caption = "Mode";
            this.colMode.FieldName = "strMode";
            this.colMode.Name = "colMode";
            this.colMode.Visible = true;
            this.colMode.VisibleIndex = 3;
            this.colMode.Width = 207;
            // 
            // colActionDetail
            // 
            this.colActionDetail.Caption = "Action Taken";
            this.colActionDetail.FieldName = "strActionDetails";
            this.colActionDetail.Name = "colActionDetail";
            this.colActionDetail.Visible = true;
            this.colActionDetail.VisibleIndex = 4;
            this.colActionDetail.Width = 262;
            // 
            // colActionTakenBy
            // 
            this.colActionTakenBy.Caption = "Action Taken By";
            this.colActionTakenBy.FieldName = "strActionTakenBy";
            this.colActionTakenBy.Name = "colActionTakenBy";
            this.colActionTakenBy.Visible = true;
            this.colActionTakenBy.VisibleIndex = 5;
            this.colActionTakenBy.Width = 231;
            // 
            // colActionTakenByID
            // 
            this.colActionTakenByID.Caption = "Action Taken By ID";
            this.colActionTakenByID.FieldName = "nActionByID";
            this.colActionTakenByID.Name = "colActionTakenByID";
            this.colActionTakenByID.Visible = true;
            this.colActionTakenByID.VisibleIndex = 6;
            // 
            // groupCustomerVoiceCVDetails
            // 
            this.groupCustomerVoiceCVDetails.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupCustomerVoiceCVDetails.Appearance.Options.UseBackColor = true;
            this.groupCustomerVoiceCVDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupCustomerVoiceCVDetails.Controls.Add(this.GroupControl28);
            this.groupCustomerVoiceCVDetails.Location = new System.Drawing.Point(7, 344);
            this.groupCustomerVoiceCVDetails.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupCustomerVoiceCVDetails.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupCustomerVoiceCVDetails.Name = "groupCustomerVoiceCVDetails";
            this.groupCustomerVoiceCVDetails.Size = new System.Drawing.Size(992, 232);
            this.groupCustomerVoiceCVDetails.TabIndex = 6;
            this.groupCustomerVoiceCVDetails.Text = "CUSTOMER VOICE DETAILS";
            // 
            // GroupControl28
            // 
            this.GroupControl28.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.GroupControl28.Controls.Add(this.txtHomeNo);
            this.GroupControl28.Controls.Add(this.label31);
            this.GroupControl28.Controls.Add(this.txtEmail);
            this.GroupControl28.Controls.Add(this.label10);
            this.GroupControl28.Controls.Add(this.txtContactNo);
            this.GroupControl28.Controls.Add(this.label9);
            this.GroupControl28.Controls.Add(this.memoeditSummaryCV);
            this.GroupControl28.Controls.Add(this.Label32);
            this.GroupControl28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupControl28.Location = new System.Drawing.Point(2, 19);
            this.GroupControl28.Name = "GroupControl28";
            this.GroupControl28.ShowCaption = false;
            this.GroupControl28.Size = new System.Drawing.Size(988, 211);
            this.GroupControl28.TabIndex = 0;
            this.GroupControl28.Text = "GroupControl1";
            // 
            // txtHomeNo
            // 
            this.txtHomeNo.EditValue = "";
            this.txtHomeNo.Location = new System.Drawing.Point(360, 16);
            this.txtHomeNo.Name = "txtHomeNo";
            this.txtHomeNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtHomeNo.Properties.Appearance.Options.UseFont = true;
            this.txtHomeNo.Properties.ReadOnly = true;
            this.txtHomeNo.Size = new System.Drawing.Size(152, 22);
            this.txtHomeNo.TabIndex = 18;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(288, 16);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(73, 16);
            this.label31.TabIndex = 19;
            this.label31.Text = "Home No";
            // 
            // txtEmail
            // 
            this.txtEmail.EditValue = "";
            this.txtEmail.Location = new System.Drawing.Point(640, 16);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtEmail.Properties.Appearance.Options.UseFont = true;
            this.txtEmail.Properties.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(280, 22);
            this.txtEmail.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(528, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 16);
            this.label10.TabIndex = 17;
            this.label10.Text = "Email Address";
            // 
            // txtContactNo
            // 
            this.txtContactNo.EditValue = "";
            this.txtContactNo.Location = new System.Drawing.Point(120, 16);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtContactNo.Properties.Appearance.Options.UseFont = true;
            this.txtContactNo.Properties.ReadOnly = true;
            this.txtContactNo.Size = new System.Drawing.Size(152, 22);
            this.txtContactNo.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "Mobile No";
            // 
            // memoeditSummaryCV
            // 
            this.memoeditSummaryCV.EditValue = "";
            this.memoeditSummaryCV.Location = new System.Drawing.Point(120, 48);
            this.memoeditSummaryCV.Name = "memoeditSummaryCV";
            this.memoeditSummaryCV.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.memoeditSummaryCV.Properties.Appearance.Options.UseFont = true;
            this.memoeditSummaryCV.Properties.ReadOnly = true;
            this.memoeditSummaryCV.Size = new System.Drawing.Size(800, 152);
            this.memoeditSummaryCV.TabIndex = 2;
            // 
            // Label32
            // 
            this.Label32.AutoSize = true;
            this.Label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label32.Location = new System.Drawing.Point(8, 56);
            this.Label32.Name = "Label32";
            this.Label32.Size = new System.Drawing.Size(113, 16);
            this.Label32.TabIndex = 13;
            this.Label32.Text = "Summary of CV";
            // 
            // tabStaffSix
            // 
            this.tabStaffSix.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabStaffSix.Appearance.Header.Options.UseFont = true;
            this.tabStaffSix.Controls.Add(this.groupControl1);
            this.tabStaffSix.Name = "tabStaffSix";
            this.tabStaffSix.PageVisible = false;
            this.tabStaffSix.Size = new System.Drawing.Size(1007, 612);
            this.tabStaffSix.Text = "Leave";
            // 
            // groupControl1
            // 
            this.groupControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.lblSix_2);
            this.groupControl1.Controls.Add(this.lblSix_1);
            this.groupControl1.Controls.Add(this.groupLeave);
            this.groupControl1.Controls.Add(this.groupLeaveRoster);
            this.groupControl1.Controls.Add(this.luedtLeaveEmployeeID);
            this.groupControl1.Controls.Add(this.lblLeaveEmployeeID);
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(1007, 610);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "GroupControl1";
            // 
            // lblSix_2
            // 
            this.lblSix_2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblSix_2.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblSix_2.Appearance.Options.UseFont = true;
            this.lblSix_2.Appearance.Options.UseForeColor = true;
            this.lblSix_2.Location = new System.Drawing.Point(156, 4);
            this.lblSix_2.Name = "lblSix_2";
            this.lblSix_2.Size = new System.Drawing.Size(138, 23);
            this.lblSix_2.TabIndex = 144;
            this.lblSix_2.Text = "Roster";
            this.lblSix_2.Click += new System.EventHandler(this.lblSix_2_Click);
            // 
            // lblSix_1
            // 
            this.lblSix_1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblSix_1.Appearance.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblSix_1.Appearance.Options.UseFont = true;
            this.lblSix_1.Appearance.Options.UseForeColor = true;
            this.lblSix_1.Location = new System.Drawing.Point(12, 4);
            this.lblSix_1.Name = "lblSix_1";
            this.lblSix_1.Size = new System.Drawing.Size(138, 23);
            this.lblSix_1.TabIndex = 143;
            this.lblSix_1.Text = "Leave";
            this.lblSix_1.Click += new System.EventHandler(this.lblSix_2_Click);
            // 
            // groupLeave
            // 
            this.groupLeave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupLeave.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupLeave.Controls.Add(this.groupLeaveLeaveDetails);
            this.groupLeave.Controls.Add(this.groupLeaveLeaveBalance);
            this.groupLeave.Location = new System.Drawing.Point(0, 30);
            this.groupLeave.Name = "groupLeave";
            this.groupLeave.Size = new System.Drawing.Size(1004, 578);
            this.groupLeave.TabIndex = 4;
            this.groupLeave.Text = "groupControl12";
            // 
            // groupLeaveLeaveDetails
            // 
            this.groupLeaveLeaveDetails.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupLeaveLeaveDetails.Appearance.Options.UseBackColor = true;
            this.groupLeaveLeaveDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupLeaveLeaveDetails.Controls.Add(this.groupControl11);
            this.groupLeaveLeaveDetails.Location = new System.Drawing.Point(8, 0);
            this.groupLeaveLeaveDetails.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupLeaveLeaveDetails.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupLeaveLeaveDetails.Name = "groupLeaveLeaveDetails";
            this.groupLeaveLeaveDetails.Size = new System.Drawing.Size(990, 282);
            this.groupLeaveLeaveDetails.TabIndex = 5;
            this.groupLeaveLeaveDetails.Text = "LEAVE DETAILS";
            // 
            // groupControl11
            // 
            this.groupControl11.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupControl11.Controls.Add(this.cbLeaveStatus);
            this.groupControl11.Controls.Add(this.label35);
            this.groupControl11.Controls.Add(this.txtLeaveEntitlement);
            this.groupControl11.Controls.Add(this.label34);
            this.groupControl11.Controls.Add(this.dateedtLeaveJoinDate);
            this.groupControl11.Controls.Add(this.label33);
            this.groupControl11.Controls.Add(this.sbtnLeaveEdit);
            this.groupControl11.Controls.Add(this.sbtnLeaveDelete);
            this.groupControl11.Controls.Add(this.sbtnLeaveApply);
            this.groupControl11.Controls.Add(this.gridctrLeaveDetail);
            this.groupControl11.Controls.Add(this.cbLeaveNYearID);
            this.groupControl11.Controls.Add(this.lblNYearID);
            this.groupControl11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl11.Location = new System.Drawing.Point(2, 19);
            this.groupControl11.Name = "groupControl11";
            this.groupControl11.ShowCaption = false;
            this.groupControl11.Size = new System.Drawing.Size(986, 261);
            this.groupControl11.TabIndex = 0;
            this.groupControl11.Text = "GroupControl1";
            // 
            // cbLeaveStatus
            // 
            this.cbLeaveStatus.EditValue = "All";
            this.cbLeaveStatus.Location = new System.Drawing.Point(168, 8);
            this.cbLeaveStatus.Name = "cbLeaveStatus";
            this.cbLeaveStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbLeaveStatus.Properties.Items.AddRange(new object[] {
            "Pending Approval",
            "Approved",
            "Rejected",
            "Cancelled",
            "All"});
            this.cbLeaveStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbLeaveStatus.Size = new System.Drawing.Size(118, 20);
            this.cbLeaveStatus.TabIndex = 19;
            this.cbLeaveStatus.SelectedIndexChanged += new System.EventHandler(this.cbLeaveStatus_SelectedIndexChanged);
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(120, 10);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(46, 18);
            this.label35.TabIndex = 18;
            this.label35.Text = "Status:";
            // 
            // txtLeaveEntitlement
            // 
            this.txtLeaveEntitlement.EditValue = "";
            this.txtLeaveEntitlement.Location = new System.Drawing.Point(884, 8);
            this.txtLeaveEntitlement.Name = "txtLeaveEntitlement";
            this.txtLeaveEntitlement.Properties.ReadOnly = true;
            this.txtLeaveEntitlement.Size = new System.Drawing.Size(52, 20);
            this.txtLeaveEntitlement.TabIndex = 6;
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(702, 10);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(180, 18);
            this.label34.TabIndex = 17;
            this.label34.Text = "Leave Entitlement For This Year:";
            // 
            // dateedtLeaveJoinDate
            // 
            this.dateedtLeaveJoinDate.EditValue = null;
            this.dateedtLeaveJoinDate.Location = new System.Drawing.Point(588, 8);
            this.dateedtLeaveJoinDate.Name = "dateedtLeaveJoinDate";
            this.dateedtLeaveJoinDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateedtLeaveJoinDate.Properties.ReadOnly = true;
            this.dateedtLeaveJoinDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateedtLeaveJoinDate.Size = new System.Drawing.Size(110, 20);
            this.dateedtLeaveJoinDate.TabIndex = 5;
            this.dateedtLeaveJoinDate.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.dateedtLeaveJoinDate_QueryPopUp);
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(526, 10);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(60, 18);
            this.label33.TabIndex = 15;
            this.label33.Text = "Join Date:";
            // 
            // sbtnLeaveEdit
            // 
            this.sbtnLeaveEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnLeaveEdit.Appearance.Options.UseFont = true;
            this.sbtnLeaveEdit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnLeaveEdit.Location = new System.Drawing.Point(370, 8);
            this.sbtnLeaveEdit.Name = "sbtnLeaveEdit";
            this.sbtnLeaveEdit.Size = new System.Drawing.Size(72, 20);
            this.sbtnLeaveEdit.TabIndex = 3;
            this.sbtnLeaveEdit.Text = "Edit";
            this.sbtnLeaveEdit.Click += new System.EventHandler(this.sbtnLeaveEdit_Click);
            // 
            // sbtnLeaveDelete
            // 
            this.sbtnLeaveDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnLeaveDelete.Appearance.Options.UseFont = true;
            this.sbtnLeaveDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnLeaveDelete.Location = new System.Drawing.Point(448, 8);
            this.sbtnLeaveDelete.Name = "sbtnLeaveDelete";
            this.sbtnLeaveDelete.Size = new System.Drawing.Size(72, 20);
            this.sbtnLeaveDelete.TabIndex = 4;
            this.sbtnLeaveDelete.Text = "Cancel";
            this.sbtnLeaveDelete.Click += new System.EventHandler(this.sbtnLeaveDelete_Click);
            // 
            // sbtnLeaveApply
            // 
            this.sbtnLeaveApply.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnLeaveApply.Appearance.Options.UseFont = true;
            this.sbtnLeaveApply.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnLeaveApply.Location = new System.Drawing.Point(292, 8);
            this.sbtnLeaveApply.Name = "sbtnLeaveApply";
            this.sbtnLeaveApply.Size = new System.Drawing.Size(72, 20);
            this.sbtnLeaveApply.TabIndex = 2;
            this.sbtnLeaveApply.Text = "Apply";
            this.sbtnLeaveApply.Click += new System.EventHandler(this.sbtnLeaveApply_Click);
            // 
            // gridctrLeaveDetail
            // 
            this.gridctrLeaveDetail.EmbeddedNavigator.Name = "";
            this.gridctrLeaveDetail.Location = new System.Drawing.Point(4, 36);
            this.gridctrLeaveDetail.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridctrLeaveDetail.MainView = this.gvLeave;
            this.gridctrLeaveDetail.Name = "gridctrLeaveDetail";
            this.gridctrLeaveDetail.Size = new System.Drawing.Size(978, 222);
            this.gridctrLeaveDetail.TabIndex = 7;
            this.gridctrLeaveDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLeave});
            // 
            // gvLeave
            // 
            this.gvLeave.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLeaveStartDate,
            this.colLeaveStartTime,
            this.colLeaveEndTime,
            this.gridColumn2,
            this.gridColumn1,
            this.nLeaveQuantity,
            this.nUnpaidLeave,
            this.colLeaveTimeOff,
            this.colfFullDay,
            this.colLeaveLeaveType,
            this.colLeaveReason,
            this.colLeaveLeaveStatus,
            this.colLeaveApprovingManager});
            this.gvLeave.GridControl = this.gridctrLeaveDetail;
            this.gvLeave.Name = "gvLeave";
            this.gvLeave.OptionsBehavior.AllowIncrementalSearch = true;
            this.gvLeave.OptionsBehavior.Editable = false;
            this.gvLeave.OptionsCustomization.AllowFilter = false;
            this.gvLeave.OptionsView.ShowFooter = true;
            this.gvLeave.OptionsView.ShowGroupPanel = false;
            this.gvLeave.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLeaveStartDate, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colLeaveStartDate
            // 
            this.colLeaveStartDate.Caption = "Date";
            this.colLeaveStartDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colLeaveStartDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colLeaveStartDate.FieldName = "dtStartTime";
            this.colLeaveStartDate.Name = "colLeaveStartDate";
            this.colLeaveStartDate.Visible = true;
            this.colLeaveStartDate.VisibleIndex = 0;
            // 
            // colLeaveStartTime
            // 
            this.colLeaveStartTime.Caption = "Start Time";
            this.colLeaveStartTime.DisplayFormat.FormatString = "hh:mm tt";
            this.colLeaveStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colLeaveStartTime.FieldName = "StartTime";
            this.colLeaveStartTime.Name = "colLeaveStartTime";
            this.colLeaveStartTime.Visible = true;
            this.colLeaveStartTime.VisibleIndex = 1;
            this.colLeaveStartTime.Width = 60;
            // 
            // colLeaveEndTime
            // 
            this.colLeaveEndTime.Caption = "End Time";
            this.colLeaveEndTime.DisplayFormat.FormatString = "hh:mm tt";
            this.colLeaveEndTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colLeaveEndTime.FieldName = "EndTime";
            this.colLeaveEndTime.Name = "colLeaveEndTime";
            this.colLeaveEndTime.Visible = true;
            this.colLeaveEndTime.VisibleIndex = 2;
            this.colLeaveEndTime.Width = 56;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Off (Hrs)";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "nTimeOffQuantity";
            this.gridColumn2.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.SummaryItem.DisplayFormat = "{0}";
            this.gridColumn2.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 70;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Unpaid(Hrs)";
            this.gridColumn1.FieldName = "nUnpaidTimeOff";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.SummaryItem.DisplayFormat = "{0}";
            this.gridColumn1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 73;
            // 
            // nLeaveQuantity
            // 
            this.nLeaveQuantity.Caption = "Leave (Days)";
            this.nLeaveQuantity.FieldName = "nLeaveQuantity";
            this.nLeaveQuantity.Name = "nLeaveQuantity";
            this.nLeaveQuantity.SummaryItem.DisplayFormat = "{0}";
            this.nLeaveQuantity.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.nLeaveQuantity.Visible = true;
            this.nLeaveQuantity.VisibleIndex = 5;
            this.nLeaveQuantity.Width = 78;
            // 
            // nUnpaidLeave
            // 
            this.nUnpaidLeave.Caption = "Unpaid (Days)";
            this.nUnpaidLeave.FieldName = "nUnpaidLeave";
            this.nUnpaidLeave.Name = "nUnpaidLeave";
            this.nUnpaidLeave.SummaryItem.DisplayFormat = "{0}";
            this.nUnpaidLeave.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.nUnpaidLeave.Visible = true;
            this.nUnpaidLeave.VisibleIndex = 6;
            this.nUnpaidLeave.Width = 85;
            // 
            // colLeaveTimeOff
            // 
            this.colLeaveTimeOff.Caption = "Time Off";
            this.colLeaveTimeOff.FieldName = "fTimeOff";
            this.colLeaveTimeOff.Name = "colLeaveTimeOff";
            this.colLeaveTimeOff.Width = 64;
            // 
            // colfFullDay
            // 
            this.colfFullDay.Caption = "Full Day";
            this.colfFullDay.FieldName = "fFullDay";
            this.colfFullDay.Name = "colfFullDay";
            this.colfFullDay.Visible = true;
            this.colfFullDay.VisibleIndex = 7;
            this.colfFullDay.Width = 54;
            // 
            // colLeaveLeaveType
            // 
            this.colLeaveLeaveType.Caption = "Type";
            this.colLeaveLeaveType.FieldName = "strLeaveType";
            this.colLeaveLeaveType.Name = "colLeaveLeaveType";
            this.colLeaveLeaveType.Visible = true;
            this.colLeaveLeaveType.VisibleIndex = 8;
            this.colLeaveLeaveType.Width = 68;
            // 
            // colLeaveReason
            // 
            this.colLeaveReason.Caption = "Reason";
            this.colLeaveReason.FieldName = "strRemarks";
            this.colLeaveReason.Name = "colLeaveReason";
            this.colLeaveReason.Visible = true;
            this.colLeaveReason.VisibleIndex = 9;
            this.colLeaveReason.Width = 62;
            // 
            // colLeaveLeaveStatus
            // 
            this.colLeaveLeaveStatus.Caption = "Status";
            this.colLeaveLeaveStatus.FieldName = "strStatus";
            this.colLeaveLeaveStatus.Name = "colLeaveLeaveStatus";
            this.colLeaveLeaveStatus.Visible = true;
            this.colLeaveLeaveStatus.VisibleIndex = 10;
            this.colLeaveLeaveStatus.Width = 64;
            // 
            // colLeaveApprovingManager
            // 
            this.colLeaveApprovingManager.Caption = "Approving Manager";
            this.colLeaveApprovingManager.FieldName = "strApprovingManager";
            this.colLeaveApprovingManager.Name = "colLeaveApprovingManager";
            this.colLeaveApprovingManager.Visible = true;
            this.colLeaveApprovingManager.VisibleIndex = 11;
            this.colLeaveApprovingManager.Width = 212;
            // 
            // cbLeaveNYearID
            // 
            this.cbLeaveNYearID.EditValue = "1";
            this.cbLeaveNYearID.Location = new System.Drawing.Point(60, 8);
            this.cbLeaveNYearID.Name = "cbLeaveNYearID";
            this.cbLeaveNYearID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbLeaveNYearID.Properties.Items.AddRange(new object[] {
            "1"});
            this.cbLeaveNYearID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbLeaveNYearID.Size = new System.Drawing.Size(56, 20);
            this.cbLeaveNYearID.TabIndex = 1;
            this.cbLeaveNYearID.SelectedIndexChanged += new System.EventHandler(this.cbLeaveNYearID_SelectedIndexChanged);
            // 
            // lblNYearID
            // 
            this.lblNYearID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNYearID.Location = new System.Drawing.Point(6, 10);
            this.lblNYearID.Name = "lblNYearID";
            this.lblNYearID.Size = new System.Drawing.Size(52, 18);
            this.lblNYearID.TabIndex = 15;
            this.lblNYearID.Text = "Year ID:";
            // 
            // groupLeaveLeaveBalance
            // 
            this.groupLeaveLeaveBalance.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupLeaveLeaveBalance.Appearance.Options.UseBackColor = true;
            this.groupLeaveLeaveBalance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupLeaveLeaveBalance.Controls.Add(this.groupControl5);
            this.groupLeaveLeaveBalance.Location = new System.Drawing.Point(8, 286);
            this.groupLeaveLeaveBalance.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupLeaveLeaveBalance.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupLeaveLeaveBalance.Name = "groupLeaveLeaveBalance";
            this.groupLeaveLeaveBalance.Size = new System.Drawing.Size(990, 290);
            this.groupLeaveLeaveBalance.TabIndex = 7;
            this.groupLeaveLeaveBalance.Text = "LEAVE BALANCE";
            // 
            // groupControl5
            // 
            this.groupControl5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupControl5.Controls.Add(this.btnConvert);
            this.groupControl5.Controls.Add(this.txtDaysConvert);
            this.groupControl5.Controls.Add(this.label36);
            this.groupControl5.Controls.Add(this.btnAdjust);
            this.groupControl5.Controls.Add(this.txtLeaveAdjust);
            this.groupControl5.Controls.Add(this.label29);
            this.groupControl5.Controls.Add(this.sbtnLeaveBalanceInquiry);
            this.groupControl5.Controls.Add(this.label25);
            this.groupControl5.Controls.Add(this.cbLeaveBalance);
            this.groupControl5.Controls.Add(this.gridctrLeaveBalance);
            this.groupControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl5.Location = new System.Drawing.Point(2, 19);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.ShowCaption = false;
            this.groupControl5.Size = new System.Drawing.Size(986, 269);
            this.groupControl5.TabIndex = 0;
            this.groupControl5.Text = "GroupControl1";
            // 
            // btnConvert
            // 
            this.btnConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvert.Location = new System.Drawing.Point(822, 10);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(56, 22);
            this.btnConvert.TabIndex = 21;
            this.btnConvert.Text = "Convert";
            this.btnConvert.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtDaysConvert
            // 
            this.txtDaysConvert.Location = new System.Drawing.Point(782, 10);
            this.txtDaysConvert.Name = "txtDaysConvert";
            this.txtDaysConvert.Size = new System.Drawing.Size(36, 20);
            this.txtDaysConvert.TabIndex = 20;
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(642, 12);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(136, 20);
            this.label36.TabIndex = 19;
            this.label36.Text = "Convert Leave to Hours:";
            // 
            // btnAdjust
            // 
            this.btnAdjust.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdjust.Location = new System.Drawing.Point(518, 10);
            this.btnAdjust.Name = "btnAdjust";
            this.btnAdjust.Size = new System.Drawing.Size(46, 22);
            this.btnAdjust.TabIndex = 18;
            this.btnAdjust.Text = "Adjust";
            this.btnAdjust.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtLeaveAdjust
            // 
            this.txtLeaveAdjust.Location = new System.Drawing.Point(478, 10);
            this.txtLeaveAdjust.Name = "txtLeaveAdjust";
            this.txtLeaveAdjust.Size = new System.Drawing.Size(36, 20);
            this.txtLeaveAdjust.TabIndex = 17;
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(288, 12);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(184, 20);
            this.label29.TabIndex = 15;
            this.label29.Text = "Adjustment for selected Year ID :";
            // 
            // sbtnLeaveBalanceInquiry
            // 
            this.sbtnLeaveBalanceInquiry.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnLeaveBalanceInquiry.Appearance.Options.UseFont = true;
            this.sbtnLeaveBalanceInquiry.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnLeaveBalanceInquiry.Location = new System.Drawing.Point(186, 10);
            this.sbtnLeaveBalanceInquiry.Name = "sbtnLeaveBalanceInquiry";
            this.sbtnLeaveBalanceInquiry.Size = new System.Drawing.Size(72, 20);
            this.sbtnLeaveBalanceInquiry.TabIndex = 2;
            this.sbtnLeaveBalanceInquiry.Text = "Inquiry";
            this.sbtnLeaveBalanceInquiry.Click += new System.EventHandler(this.sbtnLeaveBalanceInquiry_Click);
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(8, 12);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(40, 18);
            this.label25.TabIndex = 14;
            this.label25.Text = "Type:";
            // 
            // cbLeaveBalance
            // 
            this.cbLeaveBalance.EditValue = "Annual Leave balance";
            this.cbLeaveBalance.Location = new System.Drawing.Point(52, 10);
            this.cbLeaveBalance.Name = "cbLeaveBalance";
            this.cbLeaveBalance.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbLeaveBalance.Properties.Items.AddRange(new object[] {
            "Annual Leave balance",
            "Time Off balance",
            "Misc Leave balance"});
            this.cbLeaveBalance.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbLeaveBalance.Size = new System.Drawing.Size(130, 20);
            this.cbLeaveBalance.TabIndex = 0;
            // 
            // gridctrLeaveBalance
            // 
            this.gridctrLeaveBalance.EmbeddedNavigator.Name = "";
            this.gridctrLeaveBalance.Location = new System.Drawing.Point(4, 38);
            this.gridctrLeaveBalance.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridctrLeaveBalance.MainView = this.gvLeaveBalance;
            this.gridctrLeaveBalance.Name = "gridctrLeaveBalance";
            this.gridctrLeaveBalance.Size = new System.Drawing.Size(978, 226);
            this.gridctrLeaveBalance.TabIndex = 3;
            this.gridctrLeaveBalance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLeaveBalance});
            // 
            // gvLeaveBalance
            // 
            this.gvLeaveBalance.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLeaveBalanceDate,
            this.colLeaveBalanceTransaction,
            this.colLeaveBalanceStatus,
            this.colLeaveBalanceNoOfDays});
            this.gvLeaveBalance.GridControl = this.gridctrLeaveBalance;
            this.gvLeaveBalance.Name = "gvLeaveBalance";
            this.gvLeaveBalance.OptionsBehavior.AllowIncrementalSearch = true;
            this.gvLeaveBalance.OptionsBehavior.Editable = false;
            this.gvLeaveBalance.OptionsCustomization.AllowFilter = false;
            this.gvLeaveBalance.OptionsCustomization.AllowSort = false;
            this.gvLeaveBalance.OptionsLayout.Columns.AddNewColumns = false;
            this.gvLeaveBalance.OptionsView.ShowFooter = true;
            this.gvLeaveBalance.OptionsView.ShowGroupPanel = false;
            this.gvLeaveBalance.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLeaveBalanceTransaction, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colLeaveBalanceDate
            // 
            this.colLeaveBalanceDate.Caption = "Date";
            this.colLeaveBalanceDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colLeaveBalanceDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colLeaveBalanceDate.FieldName = "dtDate";
            this.colLeaveBalanceDate.Name = "colLeaveBalanceDate";
            this.colLeaveBalanceDate.Visible = true;
            this.colLeaveBalanceDate.VisibleIndex = 0;
            this.colLeaveBalanceDate.Width = 173;
            // 
            // colLeaveBalanceTransaction
            // 
            this.colLeaveBalanceTransaction.Caption = "Transaction";
            this.colLeaveBalanceTransaction.FieldName = "Transaction";
            this.colLeaveBalanceTransaction.Name = "colLeaveBalanceTransaction";
            this.colLeaveBalanceTransaction.Visible = true;
            this.colLeaveBalanceTransaction.VisibleIndex = 1;
            this.colLeaveBalanceTransaction.Width = 512;
            // 
            // colLeaveBalanceStatus
            // 
            this.colLeaveBalanceStatus.Caption = "Status";
            this.colLeaveBalanceStatus.FieldName = "strStatus";
            this.colLeaveBalanceStatus.Name = "colLeaveBalanceStatus";
            this.colLeaveBalanceStatus.Visible = true;
            this.colLeaveBalanceStatus.VisibleIndex = 2;
            this.colLeaveBalanceStatus.Width = 172;
            // 
            // colLeaveBalanceNoOfDays
            // 
            this.colLeaveBalanceNoOfDays.Caption = "No. of Days";
            this.colLeaveBalanceNoOfDays.FieldName = "NoOfDays";
            this.colLeaveBalanceNoOfDays.Name = "colLeaveBalanceNoOfDays";
            this.colLeaveBalanceNoOfDays.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colLeaveBalanceNoOfDays.Visible = true;
            this.colLeaveBalanceNoOfDays.VisibleIndex = 3;
            this.colLeaveBalanceNoOfDays.Width = 100;
            // 
            // groupLeaveRoster
            // 
            this.groupLeaveRoster.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupLeaveRoster.Appearance.Options.UseBackColor = true;
            this.groupLeaveRoster.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupLeaveRoster.Controls.Add(this.groupControl2);
            this.groupLeaveRoster.Controls.Add(this.panelControl1);
            this.groupLeaveRoster.Controls.Add(this.sbtnLeaveNextMonth);
            this.groupLeaveRoster.Controls.Add(this.sbtnLeavePreviousMonth);
            this.groupLeaveRoster.Location = new System.Drawing.Point(8, 30);
            this.groupLeaveRoster.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupLeaveRoster.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupLeaveRoster.Name = "groupLeaveRoster";
            this.groupLeaveRoster.Size = new System.Drawing.Size(994, 576);
            this.groupLeaveRoster.TabIndex = 1;
            this.groupLeaveRoster.Text = "ROSTER";
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.Appearance.Options.UseForeColor = true;
            this.groupControl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupControl2.Controls.Add(this.label23);
            this.groupControl2.Controls.Add(this.label24);
            this.groupControl2.Controls.Add(this.label21);
            this.groupControl2.Controls.Add(this.label22);
            this.groupControl2.Controls.Add(this.label19);
            this.groupControl2.Controls.Add(this.label20);
            this.groupControl2.Controls.Add(this.label18);
            this.groupControl2.Controls.Add(this.label4);
            this.groupControl2.Location = new System.Drawing.Point(694, 38);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(210, 138);
            this.groupControl2.TabIndex = 30;
            this.groupControl2.Text = "Legend";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(42, 114);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(162, 16);
            this.label23.TabIndex = 7;
            this.label23.Text = "Time off";
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.Green;
            this.label24.Location = new System.Drawing.Point(10, 108);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(26, 23);
            this.label24.TabIndex = 6;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(42, 84);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(162, 16);
            this.label21.TabIndex = 5;
            this.label21.Text = "Full day leave";
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.LightBlue;
            this.label22.Location = new System.Drawing.Point(10, 78);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(26, 23);
            this.label22.TabIndex = 4;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(42, 56);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(162, 16);
            this.label19.TabIndex = 3;
            this.label19.Text = "Half day leave";
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Yellow;
            this.label20.Location = new System.Drawing.Point(10, 50);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(26, 23);
            this.label20.TabIndex = 2;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(42, 28);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(162, 16);
            this.label18.TabIndex = 1;
            this.label18.Text = "Applied leave in pending status";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(10, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 23);
            this.label4.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.acmsRosterHeader6);
            this.panelControl1.Controls.Add(this.acmsRosterHeader5);
            this.panelControl1.Controls.Add(this.acmsRosterHeader4);
            this.panelControl1.Controls.Add(this.acmsRosterHeader3);
            this.panelControl1.Controls.Add(this.acmsRosterHeader2);
            this.panelControl1.Controls.Add(this.acmsRosterHeader1);
            this.panelControl1.Location = new System.Drawing.Point(6, 44);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(668, 530);
            this.panelControl1.TabIndex = 29;
            // 
            // acmsRosterHeader6
            // 
            this.acmsRosterHeader6.dtLeaveDetails = null;
            this.acmsRosterHeader6.dtRoster = null;
            this.acmsRosterHeader6.dtRosterDetail = null;
            this.acmsRosterHeader6.EmpID = null;
            this.acmsRosterHeader6.IsShowLeave = false;
            this.acmsRosterHeader6.Location = new System.Drawing.Point(-146, 442);
            this.acmsRosterHeader6.Name = "acmsRosterHeader6";
            this.acmsRosterHeader6.ShowHeaderLabel = false;
            this.acmsRosterHeader6.Size = new System.Drawing.Size(794, 85);
            this.acmsRosterHeader6.TabIndex = 5;
            this.acmsRosterHeader6.WeekDay = null;
            this.acmsRosterHeader6.WeekNo = null;
            this.acmsRosterHeader6.year = null;
            this.acmsRosterHeader6.Click += new System.EventHandler(this.acmsRosterHeader_Click);
            // 
            // acmsRosterHeader5
            // 
            this.acmsRosterHeader5.dtLeaveDetails = null;
            this.acmsRosterHeader5.dtRoster = null;
            this.acmsRosterHeader5.dtRosterDetail = null;
            this.acmsRosterHeader5.EmpID = null;
            this.acmsRosterHeader5.IsShowLeave = false;
            this.acmsRosterHeader5.Location = new System.Drawing.Point(-146, 354);
            this.acmsRosterHeader5.Name = "acmsRosterHeader5";
            this.acmsRosterHeader5.ShowHeaderLabel = false;
            this.acmsRosterHeader5.Size = new System.Drawing.Size(794, 85);
            this.acmsRosterHeader5.TabIndex = 4;
            this.acmsRosterHeader5.WeekDay = null;
            this.acmsRosterHeader5.WeekNo = null;
            this.acmsRosterHeader5.year = null;
            this.acmsRosterHeader5.Click += new System.EventHandler(this.acmsRosterHeader_Click);
            // 
            // acmsRosterHeader4
            // 
            this.acmsRosterHeader4.dtLeaveDetails = null;
            this.acmsRosterHeader4.dtRoster = null;
            this.acmsRosterHeader4.dtRosterDetail = null;
            this.acmsRosterHeader4.EmpID = null;
            this.acmsRosterHeader4.IsShowLeave = false;
            this.acmsRosterHeader4.Location = new System.Drawing.Point(-146, 266);
            this.acmsRosterHeader4.Name = "acmsRosterHeader4";
            this.acmsRosterHeader4.ShowHeaderLabel = false;
            this.acmsRosterHeader4.Size = new System.Drawing.Size(794, 85);
            this.acmsRosterHeader4.TabIndex = 3;
            this.acmsRosterHeader4.WeekDay = null;
            this.acmsRosterHeader4.WeekNo = null;
            this.acmsRosterHeader4.year = null;
            this.acmsRosterHeader4.Click += new System.EventHandler(this.acmsRosterHeader_Click);
            // 
            // acmsRosterHeader3
            // 
            this.acmsRosterHeader3.dtLeaveDetails = null;
            this.acmsRosterHeader3.dtRoster = null;
            this.acmsRosterHeader3.dtRosterDetail = null;
            this.acmsRosterHeader3.EmpID = null;
            this.acmsRosterHeader3.IsShowLeave = false;
            this.acmsRosterHeader3.Location = new System.Drawing.Point(-146, 178);
            this.acmsRosterHeader3.Name = "acmsRosterHeader3";
            this.acmsRosterHeader3.ShowHeaderLabel = false;
            this.acmsRosterHeader3.Size = new System.Drawing.Size(794, 85);
            this.acmsRosterHeader3.TabIndex = 2;
            this.acmsRosterHeader3.WeekDay = null;
            this.acmsRosterHeader3.WeekNo = null;
            this.acmsRosterHeader3.year = null;
            this.acmsRosterHeader3.Click += new System.EventHandler(this.acmsRosterHeader_Click);
            // 
            // acmsRosterHeader2
            // 
            this.acmsRosterHeader2.dtLeaveDetails = null;
            this.acmsRosterHeader2.dtRoster = null;
            this.acmsRosterHeader2.dtRosterDetail = null;
            this.acmsRosterHeader2.EmpID = null;
            this.acmsRosterHeader2.IsShowLeave = false;
            this.acmsRosterHeader2.Location = new System.Drawing.Point(-146, 90);
            this.acmsRosterHeader2.Name = "acmsRosterHeader2";
            this.acmsRosterHeader2.ShowHeaderLabel = false;
            this.acmsRosterHeader2.Size = new System.Drawing.Size(794, 85);
            this.acmsRosterHeader2.TabIndex = 1;
            this.acmsRosterHeader2.WeekDay = null;
            this.acmsRosterHeader2.WeekNo = null;
            this.acmsRosterHeader2.year = null;
            this.acmsRosterHeader2.Click += new System.EventHandler(this.acmsRosterHeader_Click);
            // 
            // acmsRosterHeader1
            // 
            this.acmsRosterHeader1.dtLeaveDetails = null;
            this.acmsRosterHeader1.dtRoster = null;
            this.acmsRosterHeader1.dtRosterDetail = null;
            this.acmsRosterHeader1.EmpID = null;
            this.acmsRosterHeader1.IsShowLeave = false;
            this.acmsRosterHeader1.Location = new System.Drawing.Point(-146, 2);
            this.acmsRosterHeader1.Name = "acmsRosterHeader1";
            this.acmsRosterHeader1.ShowHeaderLabel = false;
            this.acmsRosterHeader1.Size = new System.Drawing.Size(794, 85);
            this.acmsRosterHeader1.TabIndex = 0;
            this.acmsRosterHeader1.WeekDay = null;
            this.acmsRosterHeader1.WeekNo = null;
            this.acmsRosterHeader1.year = null;
            this.acmsRosterHeader1.Click += new System.EventHandler(this.acmsRosterHeader_Click);
            // 
            // sbtnLeaveNextMonth
            // 
            this.sbtnLeaveNextMonth.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.sbtnLeaveNextMonth.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnLeaveNextMonth.Appearance.Options.UseBackColor = true;
            this.sbtnLeaveNextMonth.Appearance.Options.UseFont = true;
            this.sbtnLeaveNextMonth.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnLeaveNextMonth.Location = new System.Drawing.Point(572, 22);
            this.sbtnLeaveNextMonth.Name = "sbtnLeaveNextMonth";
            this.sbtnLeaveNextMonth.Size = new System.Drawing.Size(80, 20);
            this.sbtnLeaveNextMonth.TabIndex = 1;
            this.sbtnLeaveNextMonth.Text = "Next >>";
            this.sbtnLeaveNextMonth.Click += new System.EventHandler(this.sbtnLeaveNextMonth_Click);
            // 
            // sbtnLeavePreviousMonth
            // 
            this.sbtnLeavePreviousMonth.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.sbtnLeavePreviousMonth.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnLeavePreviousMonth.Appearance.Options.UseBackColor = true;
            this.sbtnLeavePreviousMonth.Appearance.Options.UseFont = true;
            this.sbtnLeavePreviousMonth.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnLeavePreviousMonth.Location = new System.Drawing.Point(12, 22);
            this.sbtnLeavePreviousMonth.Name = "sbtnLeavePreviousMonth";
            this.sbtnLeavePreviousMonth.Size = new System.Drawing.Size(80, 20);
            this.sbtnLeavePreviousMonth.TabIndex = 0;
            this.sbtnLeavePreviousMonth.Text = "<<Previous";
            this.sbtnLeavePreviousMonth.Click += new System.EventHandler(this.sbtnLeavePreviousMonth_Click);
            // 
            // luedtLeaveEmployeeID
            // 
            this.luedtLeaveEmployeeID.Location = new System.Drawing.Point(778, 2);
            this.luedtLeaveEmployeeID.Name = "luedtLeaveEmployeeID";
            this.luedtLeaveEmployeeID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luedtLeaveEmployeeID.Size = new System.Drawing.Size(208, 20);
            this.luedtLeaveEmployeeID.TabIndex = 3;
            this.luedtLeaveEmployeeID.EditValueChanged += new System.EventHandler(this.luedtLeaveEmployeeID_EditValueChanged);
            // 
            // lblLeaveEmployeeID
            // 
            this.lblLeaveEmployeeID.AutoSize = true;
            this.lblLeaveEmployeeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeaveEmployeeID.Location = new System.Drawing.Point(690, 6);
            this.lblLeaveEmployeeID.Name = "lblLeaveEmployeeID";
            this.lblLeaveEmployeeID.Size = new System.Drawing.Size(88, 16);
            this.lblLeaveEmployeeID.TabIndex = 32;
            this.lblLeaveEmployeeID.Text = "Staff Name:";
            // 
            // tabStaffSeven
            // 
            this.tabStaffSeven.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.tabStaffSeven.Appearance.Header.Options.UseFont = true;
            this.tabStaffSeven.Controls.Add(this.groupControl17);
            this.tabStaffSeven.Name = "tabStaffSeven";
            this.tabStaffSeven.Size = new System.Drawing.Size(1007, 612);
            this.tabStaffSeven.Text = "To-Do-List";
            // 
            // groupControl17
            // 
            this.groupControl17.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl17.Appearance.Options.UseFont = true;
            this.groupControl17.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupControl17.Location = new System.Drawing.Point(0, 0);
            this.groupControl17.Name = "groupControl17";
            this.groupControl17.Size = new System.Drawing.Size(992, 576);
            this.groupControl17.TabIndex = 1;
            this.groupControl17.Text = "You Won\'t Behind Schedule Anymore";
            // 
            // tabStaffEight
            // 
            this.tabStaffEight.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.tabStaffEight.Appearance.Header.Options.UseFont = true;
            this.tabStaffEight.Controls.Add(this.xtraTabControl1);
            this.tabStaffEight.Controls.Add(this.groupControl18);
            this.tabStaffEight.Name = "tabStaffEight";
            this.tabStaffEight.Size = new System.Drawing.Size(1007, 612);
            this.tabStaffEight.Text = "Work Flow";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 337);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1004, 281);
            this.xtraTabControl1.TabIndex = 3;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            this.xtraTabControl1.Text = "xtraTabControl1";
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.memoEdit2);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage1.Image")));
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(995, 240);
            this.xtraTabPage1.Text = "Detail";
            // 
            // memoEdit2
            // 
            this.memoEdit2.EditValue = "";
            this.memoEdit2.Location = new System.Drawing.Point(10, 33);
            this.memoEdit2.Name = "memoEdit2";
            this.memoEdit2.Size = new System.Drawing.Size(706, 187);
            this.memoEdit2.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(53, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Description";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.lookUpEdit4);
            this.xtraTabPage2.Controls.Add(this.label40);
            this.xtraTabPage2.Controls.Add(this.lookUpEdit3);
            this.xtraTabPage2.Controls.Add(this.label39);
            this.xtraTabPage2.Controls.Add(this.lookUpEdit2);
            this.xtraTabPage2.Controls.Add(this.label38);
            this.xtraTabPage2.Controls.Add(this.lookUpEdit1);
            this.xtraTabPage2.Controls.Add(this.label28);
            this.xtraTabPage2.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage2.Image")));
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(995, 240);
            this.xtraTabPage2.Text = "Attachment";
            // 
            // lookUpEdit4
            // 
            this.lookUpEdit4.Location = new System.Drawing.Point(100, 39);
            this.lookUpEdit4.Name = "lookUpEdit4";
            this.lookUpEdit4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit4.Size = new System.Drawing.Size(139, 20);
            this.lookUpEdit4.TabIndex = 7;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(19, 43);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(61, 13);
            this.label40.TabIndex = 6;
            this.label40.Text = "Attachment";
            // 
            // lookUpEdit3
            // 
            this.lookUpEdit3.Location = new System.Drawing.Point(100, 70);
            this.lookUpEdit3.Name = "lookUpEdit3";
            this.lookUpEdit3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit3.Size = new System.Drawing.Size(139, 20);
            this.lookUpEdit3.TabIndex = 5;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(19, 77);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(61, 13);
            this.label39.TabIndex = 4;
            this.label39.Text = "Attachment";
            // 
            // lookUpEdit2
            // 
            this.lookUpEdit2.Location = new System.Drawing.Point(100, 106);
            this.lookUpEdit2.Name = "lookUpEdit2";
            this.lookUpEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit2.Size = new System.Drawing.Size(139, 20);
            this.lookUpEdit2.TabIndex = 3;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(19, 110);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(61, 13);
            this.label38.TabIndex = 2;
            this.label38.Text = "Attachment";
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(100, 10);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Size = new System.Drawing.Size(139, 20);
            this.lookUpEdit1.TabIndex = 1;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(19, 14);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(61, 13);
            this.label28.TabIndex = 0;
            this.label28.Text = "Attachment";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage3.Image")));
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(995, 240);
            this.xtraTabPage3.Text = "Video";
            // 
            // groupControl18
            // 
            this.groupControl18.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl18.Appearance.Options.UseFont = true;
            this.groupControl18.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupControl18.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl18.Location = new System.Drawing.Point(0, 0);
            this.groupControl18.Name = "groupControl18";
            this.groupControl18.Size = new System.Drawing.Size(1007, 337);
            this.groupControl18.TabIndex = 2;
            this.groupControl18.Text = "You Won\'t Behind Schedule Anymore";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmStaff
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1016, 713);
            this.Controls.Add(this.tabStaff);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.MainMenu1;
            this.Name = "frmStaff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACMS Staff";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmStaff_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmStaff_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.BarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabStaff)).EndInit();
            this.tabStaff.ResumeLayout(false);
            this.tabStaffOne.ResumeLayout(false);
            this.tabStaffOne.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luedtMemoEmployeeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupMessages)).EndInit();
            this.groupMessages.ResumeLayout(false);
            this.groupMessages.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupMessagesEntry)).EndInit();
            this.groupMessagesEntry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbViewMemo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gctrMemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupMessagesFollowUpAction)).EndInit();
            this.groupMessagesFollowUpAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl4)).EndInit();
            this.GroupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gctrReplies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReplies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupMessagesMemoInfo)).EndInit();
            this.groupMessagesMemoInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl8)).EndInit();
            this.GroupControl8.ResumeLayout(false);
            this.GroupControl8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoedtMessage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupMessagesReceipient)).EndInit();
            this.groupMessagesReceipient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl6)).EndInit();
            this.GroupControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbMemoReceipient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gctrReceipient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReceipient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupReceipientGroup)).EndInit();
            this.groupReceipientGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupReceipientGroupEntry)).EndInit();
            this.groupReceipientGroupEntry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gctrRecpGrp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRecpGrp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupReceipientGroupReceipientEntries)).EndInit();
            this.groupReceipientGroupReceipientEntries.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl10)).EndInit();
            this.GroupControl10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gctrRecpEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRecpEntry)).EndInit();
            this.tabStaffTwo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupService)).EndInit();
            this.groupService.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupServiceEntry)).EndInit();
            this.groupServiceEntry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.luedtCommissionServiceBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbServiceYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbServiceMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbServiceServiceType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gctrService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupSales)).EndInit();
            this.groupSales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupSalesEntry)).EndInit();
            this.groupSalesEntry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).EndInit();
            this.groupControl7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.luedtSalesBranchCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSalesYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSalesMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSalesType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gctrSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSales)).EndInit();
            this.tabStaffThree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupTimesheet)).EndInit();
            this.groupTimesheet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupTimesheetEntry)).EndInit();
            this.groupTimesheetEntry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl9)).EndInit();
            this.groupControl9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbTimesheetYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTimesheetMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridctrTimesheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTimesheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupOvertime)).EndInit();
            this.groupOvertime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl15)).EndInit();
            this.groupControl15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl16)).EndInit();
            this.groupControl16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbOvertimeYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOvertimeMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridctrOvertime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOvertime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupLateness)).EndInit();
            this.groupLateness.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl13)).EndInit();
            this.groupControl13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl14)).EndInit();
            this.groupControl14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbLatenessYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLatenessMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridctrLateness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLateness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit2)).EndInit();
            this.tabStaffFour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupAppointment)).EndInit();
            this.groupAppointment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupAppointmentEntry)).EndInit();
            this.groupAppointmentEntry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl12)).EndInit();
            this.groupControl12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbAppointmentYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAppointmentMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridctrAppointment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAppointment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupContact)).EndInit();
            this.groupContact.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupContactEntry)).EndInit();
            this.groupContactEntry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridctrContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvContact)).EndInit();
            this.tabStaffFive.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupCustomerVoice)).EndInit();
            this.groupCustomerVoice.ResumeLayout(false);
            this.groupCustomerVoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl24)).EndInit();
            this.GroupControl24.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.luedtCVSubmitter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbListCV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gctrCV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luedtCVAssignTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupCustomerVoiceActionHistory)).EndInit();
            this.groupCustomerVoiceActionHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl26)).EndInit();
            this.GroupControl26.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gctrCVAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCVAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupCustomerVoiceCVDetails)).EndInit();
            this.groupCustomerVoiceCVDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl28)).EndInit();
            this.GroupControl28.ResumeLayout(false);
            this.GroupControl28.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHomeNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoeditSummaryCV.Properties)).EndInit();
            this.tabStaffSix.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupLeave)).EndInit();
            this.groupLeave.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupLeaveLeaveDetails)).EndInit();
            this.groupLeaveLeaveDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl11)).EndInit();
            this.groupControl11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbLeaveStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeaveEntitlement.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtLeaveJoinDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateedtLeaveJoinDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridctrLeaveDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLeave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLeaveNYearID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupLeaveLeaveBalance)).EndInit();
            this.groupLeaveLeaveBalance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            this.groupControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbLeaveBalance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridctrLeaveBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLeaveBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupLeaveRoster)).EndInit();
            this.groupLeaveRoster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.luedtLeaveEmployeeID.Properties)).EndInit();
            this.tabStaffSeven.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl17)).EndInit();
            this.tabStaffEight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit2.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl18)).EndInit();
            this.ResumeLayout(false);

		}
		
		#endregion
		
		#region Initialize Data from Login
		public void SetEmployeeRecord(Do.Employee employee)
		{
			this.employee = employee;
		}

		public void SetTerminalUser(Do.TerminalUser terminalUser)
		{
			this.terminalUser = terminalUser;
			
		}

		public void initData (ACMSLogic.User User)
		{
			oUser = User;
		}
		#endregion

		#region Form or General Event

		private void frmStaff_Load(object sender, System.EventArgs e)
		{
			barstaticCurrentLogin.Caption = string.Format(barstaticCurrentLogin.Caption, employee.StrEmployeeName, DateTime.Now.ToString("dd MMMM yyyy"));

			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);

			myEmployeeInfo = Ultis.EmployeeInfo(employee.Id);
			myLeaveEmployeeInfo = myEmployeeInfo;

			TabStaff_init();

			int currentYear = DateTime.Now.Year;
			object[] years = new object[]{currentYear - 3, currentYear - 2, currentYear - 1, currentYear, currentYear + 1};
			cbServiceYear.Properties.Items.AddRange(years);
			cbServiceYear.EditValue = currentYear;
			cbServiceMonth.SelectedIndex = DateTime.Now.Month - 1;
			cbSalesYear.Properties.Items.AddRange(years);
			cbSalesYear.EditValue = currentYear;
			cbSalesMonth.SelectedIndex = DateTime.Now.Month - 1;
			cbTimesheetYear.Properties.Items.AddRange(years);
			cbTimesheetYear.EditValue = currentYear;
			cbTimesheetMonth.SelectedIndex = DateTime.Now.Month - 1;
			cbAppointmentYear.Properties.Items.AddRange(years);
			cbAppointmentYear.EditValue = currentYear;
			cbAppointmentMonth.SelectedIndex = DateTime.Now.Month - 1;
			cbOvertimeYear.Properties.Items.AddRange(years);
			cbOvertimeYear.EditValue = currentYear;
			cbOvertimeMonth.SelectedIndex = DateTime.Now.Month - 1;
			cbLatenessYear.Properties.Items.AddRange(years);
			cbLatenessYear.EditValue = currentYear;
			cbLatenessMonth.SelectedIndex = DateTime.Now.Month - 1;

			mySpaCommission = new CommissionSpaService();
			myPTCommission = new CommissionPTService();
			mySalesCommission = new SalesCommission();
			myCV = new ACMSLogic.Staff.CV();
			myMemo = new ACMSLogic.Staff.Memo();
			myReceipientGroup = new ACMSLogic.Staff.ReceipientGroup();
			myAppointment = new Appointment();
			myContacts = new Contacts();
			myTimesheet = new Timesheet();
			myLateness = new Lateness();
			myLeave = new Leave();

			timer1.Enabled = true;

			luedtSalesBranchCode.EditValue = terminalUser.Branch.Id;
			luedtCommissionServiceBranch.EditValue = terminalUser.Branch.Id;

			new ACMS.XtraUtils.LookupEditBuilder.BranchCodeLookupEditBuilder2(luedtSalesBranchCode.Properties);
			new ACMS.XtraUtils.LookupEditBuilder.BranchCodeLookupEditBuilder2(luedtCommissionServiceBranch.Properties);
			new ACMS.XtraUtils.LookupEditBuilder.EmployeeIDLookupEditBuilder(luedtLeaveEmployeeID.Properties);
			new ACMS.XtraUtils.LookupEditBuilder.EmployeeIDLookupEditBuilder(luedtMemoEmployeeID.Properties);
			new ACMS.XtraUtils.LookupEditBuilder.DepartmentLookupEditBuilder2(luedtCVAssignTo.Properties);

//			employee.RightsLevel.Id = 103;
			if (employee.HasRight("AS_VIEW_ALL_CV"))
			{
				new ACMS.XtraUtils.LookupEditBuilder.EmployeeIDLookupEditBuilder(luedtCVSubmitter.Properties);
				//Add not filter row for Submiter
				DataTable tempTable = luedtCVSubmitter.Properties.DataSource as DataTable;
				DataRow tempRow = tempTable.NewRow();
				tempRow.BeginEdit();
				tempRow["nEmployeeID"] = DBNull.Value;
				tempRow["strEmployeeName"] = "<<No Filter>>";
				tempRow.EndEdit();
				tempTable.Rows.Add(tempRow);
				tempTable.AcceptChanges();
				luedtCVSubmitter.Visible = true;
				lblCVSubmitter.Visible = true;
			}
			else
			{
				luedtCVSubmitter.Visible = false;
				lblCVSubmitter.Visible = false;
			}
			//Add not filter row for AssignTo
			DataTable tempTable2 = luedtCVAssignTo.Properties.DataSource as DataTable;
			DataRow tempRow2 = tempTable2.NewRow();
			tempRow2.BeginEdit();
			tempRow2["nDepartmentID"] = DBNull.Value;
			tempRow2["strDescription"] = "<<No Filter>>";
			tempRow2.EndEdit();
			tempTable2.Rows.Add(tempRow2);
			tempTable2.AcceptChanges();

			startLeaveDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
			luedtLeaveEmployeeID.EditValue = employee.Id;

//			employee.RightsLevel.Id = 105;
			if (!employee.HasRight("AS_LEAVE_SUPER_RIGHT"))
			{
				lblLeaveEmployeeID.Visible = false;
				luedtLeaveEmployeeID.Visible = false;
			}

			isFinishedMemoInit = false;
            isFinishedCVInit = false;
			luedtMemoEmployeeID.EditValue = employee.Id;
			isFinishedMemoInit = true;

//			employee.RightsLevel.Id = 106;
			if (!employee.HasRight("AS_MEMO_SUPER_RIGHT"))
			{
				lblMemoEmployeeID.Visible = false;
				luedtMemoEmployeeID.Visible = false;
			}
			ListMemo();
			ListReceipientGroup();
		}

		private void TabStaff_init()
		{
			DataSet tabStaffTable = new DataSet(); 

			string strSQL = "select * from tblTabControl where nTabGroup=2 and fShow=0 order by nTabID";
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",tabStaffTable,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dtMaster = tabStaffTable.Tables["Table"];

			foreach (DataRow row in dtMaster.Rows)
			{
				switch(row["nTabId"].ToString())
				{
					case "1":	this.tabStaffOne.Text= row["strTabName"].ToString();
						this.tabStaffOne.PageVisible=true;	
						break;
					case "2":	this.tabStaffTwo.Text= row["strTabName"].ToString();
						this.tabStaffTwo.PageVisible=true;
						break;
					case "3":	this.tabStaffThree.Text= row["strTabName"].ToString();
						this.tabStaffThree.PageVisible=true;
						break;
					case "4":	this.tabStaffFour.Text= row["strTabName"].ToString();
						this.tabStaffFour.PageVisible=true;
						break;
					case "5":	this.tabStaffFive.Text= row["strTabName"].ToString();
						this.tabStaffFive.PageVisible=true;
						break;
					case "6": this.tabStaffSix.Text= row["strTabName"].ToString();
						this.tabStaffSix.PageVisible=true;
						break;
                    case "7": this.tabStaffSeven.Text = row["strTabName"].ToString();
                        this.tabStaffSeven.PageVisible = true;
                        break;
                    case "8": this.tabStaffEight.Text = row["strTabName"].ToString();
                        this.tabStaffEight.PageVisible = true;
                        break;
				}
			}
			
		}


		private void tabStaff_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
		{
			if (tabStaff.SelectedTabPage == tabStaffFive)
			{
				if (!isFinishedCVInit)
				{
					luedtCVSubmitter.EditValue = employee.Id;
					luedtCVAssignTo.EditValue = myEmployeeInfo["nDepartmentID"];
					isFinishedCVInit = true;
				}

				ListCV();
			}
			else if (tabStaff.SelectedTabPage == tabStaffOne)
			{
				ListMemo();
				ListReceipientGroup();
			}
			else if (tabStaff.SelectedTabPage == tabStaffFour)
			{
				ListAppointment();
				ListContact();
			}
			else if (tabStaff.SelectedTabPage == tabStaffThree)
			{
				ListTimesheet();
				//ListTimesheetDetail();
				ListOvertime();
			}
			else if (tabStaff.SelectedTabPage == tabStaffSix)
			{
				InitRoster(startLeaveDate);
				acmsRosterHeader1.ShowHeaderLabel = false;
				acmsRosterHeader2.ShowHeaderLabel = false;
				acmsRosterHeader3.ShowHeaderLabel = false;
				acmsRosterHeader4.ShowHeaderLabel = false;
				acmsRosterHeader5.ShowHeaderLabel = false;
				ListAllLeaveDetail();
			}
            else if (tabStaff.SelectedTabPage == tabStaffSeven)
            {
                DateNavigatorModule uc1 = new DateNavigatorModule();
                groupControl17.Controls.Add(uc1);
                groupControl17.Dock = System.Windows.Forms.DockStyle.None;
                
            }
            else if (tabStaff.SelectedTabPage == tabStaffEight)
            {
                DevExpress.XtraTreeList.Demos.TreeListDragDrop uc2 = new DevExpress.XtraTreeList.Demos.TreeListDragDrop();
                groupControl18.Controls.Add(uc2);
                groupControl18.Dock = System.Windows.Forms.DockStyle.None;

            }
		}

		#endregion

		#region HelperMethod
		private bool CheckGvRepliesFocusRow()
		{
			if (gvReplies.FocusedRowHandle < 0)
			{
				UI.ShowErrorMessage(this, "Please select a reply first.");
				return false;
			}
			else
				return true;
		}

		private bool CheckGvMemoFocusRow()
		{
			if (gvMemo.FocusedRowHandle < 0)
			{
				UI.ShowErrorMessage(this, "Please select a memo first.");
				return false;
			}
			else
				return true;
		}

		private bool CheckGvOvertimeFocusRow()
		{
			if (gvOvertime.FocusedRowHandle < 0)
			{
				UI.ShowErrorMessage(this, "Please select an Overtime first.");
				return false;
			}
			else
				return true;
		}

		private bool CheckGvLeaveFocusRow()
		{
			if (gvLeave.FocusedRowHandle < 0)
			{
				UI.ShowErrorMessage(this, "Please select a Leave Detail first.");
				return false;
			}
			else
				return true;
		}

		private void DateRange(out DateTime startDate, out DateTime endDate, int month, int year)
		{
			ACMSLogic.Staff.Ultis.DatesRange(out startDate, out endDate, (Month)month, year);
		}
		#endregion

		#region System Generated & old events
		private void MenuItem2_Click (System.Object sender, System.EventArgs e)
		{
			//Terminate application
			//Application.Exit();
		}
		
		private void frmStaff_Closing (object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Terminate Application
			//Application.Exit();
		}
		
		private void lblmnuMessages_Click (System.Object sender, System.EventArgs e)
		{
			lblOne_1_Click(this,e);
		}
		
		private void lblmnuMessagesMemoInfo_Click (System.Object sender, System.EventArgs e)
		{
			//Initilize Groups
			groupMessagesMemoInfo.Show();
			groupMessagesFollowUpAction.Hide();
			groupMessagesReceipient.Hide();
			
			//Set font styles
			lblmnuMessagesMemoInfo.Font = Font001;
			lblmnuMessagesFollowUpAction.Font = Font002;
			lblmnuMessagesReceipient.Font = Font002;
		}
		
		private void lblmnuMessagesFollowUpAction_Click (System.Object sender, System.EventArgs e)
		{
			//Initilize Groups
			groupMessagesMemoInfo.Hide();
			groupMessagesFollowUpAction.Show();
			groupMessagesReceipient.Hide();
			
			//Set font styles
			lblmnuMessagesMemoInfo.Font = Font002;
			lblmnuMessagesFollowUpAction.Font = Font001;
			lblmnuMessagesReceipient.Font = Font002;
		}
		
		private void lblmnuMessagesReceipient_Click (System.Object sender, System.EventArgs e)
		{
			//Initilize Groups
			groupMessagesMemoInfo.Hide();
			groupMessagesFollowUpAction.Hide();
			groupMessagesReceipient.Show();
			
			//Set font styles
			lblmnuMessagesMemoInfo.Font = Font002;
			lblmnuMessagesFollowUpAction.Font = Font002;
			lblmnuMessagesReceipient.Font = Font001;
		}
		
		private void lblmnuCustomerVoiceCVDetails_Click (System.Object sender, System.EventArgs e)
		{
			//Initilize Groups
			groupCustomerVoiceCVDetails.Show();
			groupCustomerVoiceActionHistory.Hide();
			
			//Set font styles
			lblmnuCustomerVoiceCVDetails.Font = Font001;
			lblmnuCustomerVoiceActionHistory.Font = Font002;
		}
		
		private void lblmnuCustomerVoiceActionHistory_Click (System.Object sender, System.EventArgs e)
		{
			//Initilize Groups
			groupCustomerVoiceCVDetails.Hide();
			groupCustomerVoiceActionHistory.Show();
			
			//Set font styles
			lblmnuCustomerVoiceCVDetails.Font = Font002;
			lblmnuCustomerVoiceActionHistory.Font = Font001;
		}
		
		private void tabStaffMailbox_VisibleChanged (object sender, System.EventArgs e)
		{
			//Call clicking event
			this.lblmnuMessages_Click(this, e);
		}
		
		private void tabStaffCommision_VisibleChanged (object sender, System.EventArgs e)
		{
			//Call clicking event
			lblTwo_1_Click(this, e);
		}
		
		private void tabStaffAppointments_VisibleChanged (object sender, System.EventArgs e)
		{
			//Call clicking event
			lblFour_1_Click(this, e);
		}
		
		private void tabStaffCustomerVoice_VisibleChanged (object sender, System.EventArgs e)
		{
			//Call clicking event
			this.lblmnuCustomerVoiceCVDetails_Click(this, e);
		}

		private void tabStaffTimesheet_VisibleChanged(object sender, System.EventArgs e)
		{
			//Call clicking event
			lblThree_1_Click(this, e);
		}

		
		private void tabStaff_VisibleChanged(object sender, System.EventArgs e)
		{
			//Call clicking event
			lblSix_1_Click(this, e);
		}
		
		private void bbiLoginOut_ItemClick (System.Object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			this.Close();
		}

		private void barbtnTimeCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			frmTimeCard myFormTimeCard = new frmTimeCard(terminalUser.Branch.Id);
			myFormTimeCard.ShowDialog();
			myFormTimeCard.Dispose();
		}

		//ACMS Manager
		private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if(employee!=null)
			{
				if(employee.CanAccess("AM_LOGIN",terminalUser.Branch.Id))
				{
					if (modInitForms.fManager == null || modInitForms.fManager.IsDisposed)
					{		
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
							
						ClassAttendance.CreateClassInstance();
						PackageCode.CreateUnLinkPackage();
						ACMSLogic.User oUser = new User();
						modInitForms.fManager = new frmManager();
						modInitForms.fManager.SetEmployeeRecord(employee);
						modInitForms.fManager.SetTerminalUser(terminalUser);
						modInitForms.fManager.initData(oUser);
						modInitForms.fManager.Show();
					}
					else
						modInitForms.fManager.Activate();
				}
				else
				{
					MessageBox.Show(this, "Incorrect username and password or you don't have access to this Branch, please try again");
				}	
			}
		}

		#endregion

		#region Commission
		private void sbtnServiceInquiry_Click(object sender, System.EventArgs e)
		{
			// PT Service Commission
			if (cbServiceServiceType.SelectedIndex == 0)
			{
				myPTCommission.CalculatePTServiceCommission(oUser.NEmployeeID(), luedtCommissionServiceBranch.EditValue.ToString(), 
					Ultis.GetMonth(cbServiceMonth.SelectedIndex + 1), ACMS.Convert.ToInt32(cbServiceYear.EditValue));
				gctrService.DataSource = myPTCommission.ResultTableInDetail;
			}
			else
			{
				mySpaCommission.CalculateSpaServiceCommission(oUser.NEmployeeID(), luedtCommissionServiceBranch.EditValue.ToString(), 
					Ultis.GetMonth(cbServiceMonth.SelectedIndex + 1), ACMS.Convert.ToInt32(cbServiceYear.EditValue), false);
				gctrService.DataSource = mySpaCommission.ResultTableInDetail;
			}
		}

		private void sbtnSalesInquiry_Click(object sender, System.EventArgs e)
		{
			if (cbSalesType.SelectedIndex == 0)
			{
				gctrSales.DataSource = mySalesCommission.GetSalesCommission(employee.Id, luedtSalesBranchCode.EditValue.ToString(), 
					CategoryType.FitnessProduct, Ultis.GetMonth(cbSalesMonth.SelectedIndex + 1), 
					ACMS.Convert.ToInt32(cbSalesYear.EditValue));
			}
			else if (cbSalesType.SelectedIndex == 1)
			{
				gctrSales.DataSource = mySalesCommission.GetSalesCommission(employee.Id, luedtSalesBranchCode.EditValue.ToString(), 
					CategoryType.FitnessPackage, Ultis.GetMonth(cbSalesMonth.SelectedIndex + 1), 
					ACMS.Convert.ToInt32(cbSalesYear.EditValue));
			}
			else if (cbSalesType.SelectedIndex == 2)
			{
				gctrSales.DataSource = mySalesCommission.GetSalesCommission(employee.Id, luedtSalesBranchCode.EditValue.ToString(), 
					CategoryType.SpaProduct, Ultis.GetMonth(cbSalesMonth.SelectedIndex + 1), 
					ACMS.Convert.ToInt32(cbSalesYear.EditValue));
			}
			else if (cbSalesType.SelectedIndex == 3)
			{
				gctrSales.DataSource = mySalesCommission.GetSalesCommission(employee.Id, luedtSalesBranchCode.EditValue.ToString(), 
					CategoryType.SpaPackage, Ultis.GetMonth(cbSalesMonth.SelectedIndex + 1), 
					ACMS.Convert.ToInt32(cbSalesYear.EditValue));
			}
			else if (cbSalesType.SelectedIndex == 4)
			{
				gctrSales.DataSource = mySalesCommission.GetSalesCommission(employee.Id, luedtSalesBranchCode.EditValue.ToString(), 
					CategoryType.PTPackage, Ultis.GetMonth(cbSalesMonth.SelectedIndex + 1), 
					ACMS.Convert.ToInt32(cbSalesYear.EditValue));
			}
			else //if (cbSalesType.SelectedIndex == 5)
			{
				gctrSales.DataSource = mySalesCommission.GetSalesCommission(employee.Id, luedtSalesBranchCode.EditValue.ToString(), 
					CategoryType.IPLPackage, Ultis.GetMonth(cbSalesMonth.SelectedIndex + 1), 
					ACMS.Convert.ToInt32(cbSalesYear.EditValue));
			}
		}
		#endregion

		#region Customer Voice
		///<summary>
		/// Refactored from tabStaff_SelectedPageChanged
		///</summary>
		private void ListCV()
		{
			if (!isFinishedCVInit)
				return;

			Cursor saveCursor = Cursor.Current;
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				CVStatusID myCVStatusID;
				if (cbListCV.SelectedIndex == 0)
					myCVStatusID = CVStatusID.All;
				else if (cbListCV.SelectedIndex == 1)
					myCVStatusID = CVStatusID.New;
				else if (cbListCV.SelectedIndex == 2)
					myCVStatusID = CVStatusID.Pending;
				else
					myCVStatusID = CVStatusID.Closed;
				bool isManager = false;
				if (myEmployeeInfo["nManagerID"] != DBNull.Value && 
					ACMS.Convert.ToInt32(myEmployeeInfo["nManagerID"]) == ACMS.Convert.ToInt32(luedtCVSubmitter.EditValue))
					isManager = true;
				myCV.ListCV(oUser.NEmployeeID(), luedtCVSubmitter.EditValue, luedtCVAssignTo.EditValue, myCVStatusID, isManager);
				gctrCV.DataSource = myCV.ListCVTable;

				txtContactNo.DataBindings.Clear();
				txtContactNo.DataBindings.Add(new Binding("EditValue", myCV.ListCVTable, "strContactNumber"));
				txtHomeNo.DataBindings.Clear();
				txtHomeNo.DataBindings.Add(new Binding("EditValue", myCV.ListCVTable, "strHomeNo"));
				txtEmail.DataBindings.Clear();
				txtEmail.DataBindings.Add(new Binding("EditValue", myCV.ListCVTable, "strEmailAddress"));
				memoeditSummaryCV.DataBindings.Clear();
				memoeditSummaryCV.DataBindings.Add(new Binding("EditValue", myCV.ListCVTable, "strDetails"));
			}
			finally
			{
				Cursor.Current = saveCursor;
			}
		}

		private void cbListCV_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ListCV();
		}

		private void luedtCVSubmiter_EditValueChanged(object sender, System.EventArgs e)
		{
			ListCV();
		}

		private void luedtCVAssignTo_EditValueChanged(object sender, System.EventArgs e)
		{
			ListCV();
		}

		private void sbtnCVNew_Click(object sender, System.EventArgs e)
		{
			ACMS.frmNewCV  myfrmNewCV = new frmNewCV(oUser.NEmployeeID(), -1, terminalUser.Branch.Id);
			if (DialogResult.OK == myfrmNewCV.ShowDialog())
			{
				ListCV();
			}
			myfrmNewCV.Dispose();
		}

		private void sbtnCVDelete_Click(object sender, System.EventArgs e)
		{
			if (!UI.ShowYesNoMessage(this, "Are you sure you want to delete this Customer voice?"))
				return;

			int focusIndex = gvCV.FocusedRowHandle;
			if (focusIndex >= 0)
			{
				employee.RightsLevel.Id = 107;
				if (employee.HasRight("AS_DELETE_CV"))
				{
					int nCaseID = (int)gvCV.GetDataRow(focusIndex)["nCaseID"];
					if (myCV.DeleteFullCV(nCaseID))
					{
						UI.ShowMessage(this, "Delete record successfully.");
						ListCV();
					}
				}
				else
				{
					UI.ShowMessage(this, "You don't have right to perform this action.");
				}
			}
			else
			{
				UI.ShowErrorMessage(this, "Please select a record first.", "Error");
			}
		}

		private void sbtnAssign_Click(object sender, System.EventArgs e)
		{
			int focusIndex = gvCV.FocusedRowHandle;
			if (focusIndex >= 0)
			{
				employee.RightsLevel.Id = 104;
				if (employee.HasRight("AS_ASSIGN_CV"))
				{
					ACMSStaff.CV.frmAssignCV myfrmAssignCV = new ACMS.ACMSStaff.CV.frmAssignCV(
						gvCV.GetDataRow(focusIndex)["nDepartmentAssignedID"]);
					if (myfrmAssignCV.ShowDialog() == DialogResult.OK)
					{
						int nCaseID = (int)gvCV.GetDataRow(focusIndex)["nCaseID"];
						myCV.AssignCV(myfrmAssignCV.SelectedDepartmentID, employee.Id, nCaseID);
						ListCV();
					}
					myfrmAssignCV.Dispose();
				}
				else
				{
					UI.ShowMessage(this, "You don't have right to perform this action.");
				}
			}
			else
			{
				UI.ShowErrorMessage(this, "Please select a record first.", "Error");
			}
		}

		private void sbtnCVEdit_Click(object sender, System.EventArgs e)
		{
			int focusIndex = gvCV.FocusedRowHandle;
			if (focusIndex >= 0)
			{
				DataRow row = gvCV.GetDataRow(focusIndex);
				if (Convert.ToInt32(row["nSubmittedByID"]) == employee.Id)
				{
					int nCaseID = (int)row["nCaseID"];
					ACMS.frmNewCV  myfrmNewCV = new frmNewCV(oUser.NEmployeeID(), nCaseID, terminalUser.Branch.Id);
					if (DialogResult.OK == myfrmNewCV.ShowDialog())
						ListCV();
					myfrmNewCV.Dispose();
				}
				else
				{
					UI.ShowMessage(this, "You don't have right to perform this action.");
				}
			}
			else
			{
				UI.ShowErrorMessage(this, "Please select a record first.", "Error");
			}
		}

		private void gvCV_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			LoadCVAction();
		}

		private void gvCV_DataSourceChanged(object sender, System.EventArgs e)
		{
			LoadCVAction();
		}

		///<summary>
		/// Refactored from  gvCV_FocusedRowChanged
		///</summary>
		private void LoadCVAction()
		{
			Cursor saveCursor = Cursor.Current;
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				int focusIndex = gvCV.FocusedRowHandle;
				if (focusIndex >= 0)
				{
					int nCaseID = (int)gvCV.GetDataRow(focusIndex)["nCaseID"];
					if (nCaseID != lastCaseID)
					{
						gctrCVAction.DataSource = myCV.LoadCVAction(nCaseID).Tables[0];
						lastCaseID = nCaseID; 
					}
				}
				else
				{
					gctrCVAction.DataSource = null;
					lastCaseID = -1;
				}
			}
			finally
			{
				Cursor.Current = saveCursor;
			}
		}

		private void sbtnNewCVAction_Click(object sender, System.EventArgs e)
		{
			int focusIndex = gvCV.FocusedRowHandle;
			if (focusIndex >= 0)
			{
				int nCaseID = (int)gvCV.GetDataRow(focusIndex)["nCaseID"];
				ACMS.CV.frmNewCVAction myfrmNewCV = new ACMS.CV.frmNewCVAction(oUser.NEmployeeID(), nCaseID);
				if (DialogResult.OK == myfrmNewCV.ShowDialog())
				{
					//ListCV();
					DataRow rowCV = gvCV.GetDataRow(focusIndex);
					rowCV.BeginEdit();
					rowCV["strStatus"] = myfrmNewCV.CaseStatus;
					rowCV.EndEdit();
					lastCaseID = -1;
					LoadCVAction();
				}
				myfrmNewCV.Dispose();
			}
			else
			{
				UI.ShowErrorMessage(this, "Please select a record first.", "Error");
			}
		}

		private void sbtnCVPrint_Click(object sender, System.EventArgs e)
		{
			int focusIndex = gvCV.FocusedRowHandle;
			if (focusIndex < 0)
			{
				UI.ShowErrorMessage(this, "Please select a record first");
				return;
			}

			DataRow row = gvCV.GetDataRow(focusIndex);

			DataSet dsPrintCV = myCV.PrintCV(Convert.ToInt32(row["nCaseID"]));

			ACMS.ACMSStaff.Report.ReportCV report = new ACMS.ACMSStaff.Report.ReportCV();
			report.DataSource = dsPrintCV;
			//report.RunDesigner();
			report.Print();
			report.Dispose();
		}
		#endregion

		#region Memo
		
		private void luedtMemoEmployeeID_EditValueChanged(object sender, System.EventArgs e)
		{
			if (!isFinishedMemoInit)
				return;
			ListMemo();
			ListReplies();
			ListRecipients();
			ListReceipientGroup();
			ListReceipientGroupEntries();
		}

		private void ListMemo()
		{
			ViewMemoType myType;
			if (cbViewMemo.SelectedIndex == 0)
				myType = ViewMemoType.All;
			else if (cbViewMemo.SelectedIndex == 1)
				myType = ViewMemoType.PersonalMail;
			else if (cbViewMemo.SelectedIndex == 2)
				myType = ViewMemoType.BranchBulletin;
			else 
				myType = ViewMemoType.SentMemo;

			DataTable dtblSource = myMemo.ViewMemo(Convert.ToInt32(luedtMemoEmployeeID.EditValue), myType);
			gctrMemo.DataSource = dtblSource;

			memoedtMessage.DataBindings.Clear();
			memoedtMessage.DataBindings.Add(new Binding("EditValue", dtblSource, "strMessage"));
		}

		private void ListReplies()
		{
			if (gvMemo.FocusedRowHandle < 0)
			{
				gctrReplies.DataSource = null;
				lastMemoIDForReplies = -1;
				return;
			}

			int nMemoID = Convert.ToInt32(gvMemo.GetDataRow(gvMemo.FocusedRowHandle)["nMemoID"]);
			if (nMemoID != lastMemoIDForReplies)
			{
				DataTable dtblSource = myMemo.ViewReply(nMemoID);
				gctrReplies.DataSource = dtblSource;
				lastMemoIDForReplies = nMemoID;
			}
		}

		private void cbViewMemo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ListMemo();
			ListReplies();
			ListRecipients();
		}

		private void sbtnMemoNew_Click(object sender, System.EventArgs e)
		{
			ACMSStaff.Memo.frmNewMemo2 myForm = new ACMS.ACMSStaff.Memo.frmNewMemo2(Convert.ToInt32(ACMSLogic.User.EmployeeID));
			if (DialogResult.OK == myForm.ShowDialog())
				ListMemo();
			myForm.Dispose();
		}

		private void gvMemo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			ListReplies();
			ListRecipients();

			if (gvMemo.FocusedRowHandle < 0)
				return;

			timer1.Stop();
			StartReadTimeCount();
			//DataRow currRow = gvMemo.GetDataRow(gvMemo.FocusedRowHandle);
		}

		
		private void gvMemo_DataSourceChanged(object sender, System.EventArgs e)
		{
			if (gvMemo.FocusedRowHandle < 0)
				return;

			timer1.Stop();
			StartReadTimeCount();

			ListReplies();
			ListRecipients();
		}

		private void StartReadTimeCount()
		{
			if (gvMemo.FocusedRowHandle < 0)
				return;
			if (groupMessagesMemoInfo.Visible)
			{
				if (!Convert.ToBoolean(gvMemo.GetDataRow(gvMemo.FocusedRowHandle)["fRead"]))
				{
					timer1.Start();
					startTime = DateTime.Now;
				}
			}
			else
			{
				timer1.Stop();
			}
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if (gvMemo.FocusedRowHandle < 0)
				return;

			TimeSpan span = DateTime.Now - startTime;
			if (span.Seconds >= 5 && span.Seconds < 6)
			{
				DataRow currMemoRow = gvMemo.GetDataRow(gvMemo.FocusedRowHandle);
				if (!Convert.ToBoolean(currMemoRow["fRead"]))
				{
					myMemo.ReadMessage(Convert.ToInt32(currMemoRow["nMemoID"]), Convert.ToInt32(luedtMemoEmployeeID.EditValue));
					currMemoRow.BeginEdit();
					currMemoRow["fRead"] = true;
					currMemoRow.EndEdit();
				}
				//ListMemo();
				timer1.Stop();
			}
		}

		private void groupMessagesMemoInfo_VisibleChanged(object sender, System.EventArgs e)
		{
			StartReadTimeCount();
		}

		private void sbtnUpdate_Click(object sender, System.EventArgs e)
		{
			if (gvMemo.FocusedRowHandle < 0)
				return;
			DataRow currRow = gvMemo.GetDataRow(gvMemo.FocusedRowHandle);

			if (Convert.ToInt32(currRow["nEmployeeID"]) != Convert.ToInt32(luedtMemoEmployeeID.EditValue))
			{
				UI.ShowErrorMessage(this, "You are not author of this memo, so you can't update this memo.");
				return;
			}

			if (myMemo.UpdateMessage(Convert.ToInt32(currRow["nMemoID"]), memoedtMessage.Text))
			{
				UI.ShowMessage(this, "Update successfully.");
				ListMemo();
			}
		}

		private void sbtnMemoUnpost_Click(object sender, System.EventArgs e)
		{
			if (gvMemo.FocusedRowHandle < 0)
				return;
			if (!UI.ShowYesNoMessage(this, "Are you sure you want to unpost?"))
				return;
			
			DataRow row = gvMemo.GetDataRow(gvMemo.FocusedRowHandle);
			employee.RightsLevel.Id = 102;
			if (Convert.ToInt32(row["nEmployeeID"]) == Convert.ToInt32(luedtMemoEmployeeID.EditValue) || 
				employee.HasRight("AS_UNPOST_MESSAGE"))
			{
				if (myMemo.UnpostMessage(Convert.ToInt32(row["nMemoID"])))
				{
					UI.ShowMessage(this, "Unpost successfully.");
				}
				ListMemo();
			}
			else
			{
				UI.ShowMessage(this, "You don't have right to perform this action.");
			}
		}

		private void sbtnRepliesAdd_Click(object sender, System.EventArgs e)
		{
			if (gvMemo.FocusedRowHandle < 0)
				return;

			DataRow rFocus = gvMemo.GetDataRow(gvMemo.FocusedRowHandle);
			ACMS.ACMSStaff.Memo.frmReplies myForm = new ACMS.ACMSStaff.Memo.frmReplies(-1, 
				Convert.ToInt32(rFocus["nMemoID"]), Convert.ToInt32(luedtMemoEmployeeID.EditValue),
				ACMSLogic.Staff.MemoReplyAction.Add);
			if (DialogResult.OK == myForm.ShowDialog())
			{
				rFocus.BeginEdit();
				rFocus["fRead"] = false;
				rFocus.EndEdit();
				lastMemoIDForReplies = -1;
				ListReplies();
			}
			myForm.Dispose();
		}

		private void sbtnRepliesView_Click(object sender, System.EventArgs e)
		{
			if (!CheckGvRepliesFocusRow())
				return;

			ACMS.ACMSStaff.Memo.frmReplies myForm = new ACMS.ACMSStaff.Memo.frmReplies(
				Convert.ToInt32(gvReplies.GetDataRow(gvReplies.FocusedRowHandle)["nBulletinID"]), 
				Convert.ToInt32(gvMemo.GetDataRow(gvMemo.FocusedRowHandle)["nMemoID"]), 
				Convert.ToInt32(luedtMemoEmployeeID.EditValue), ACMSLogic.Staff.MemoReplyAction.View);
			myForm.ShowDialog();
			myForm.Dispose();
		}

		private void sbtnRepliesUpdate_Click(object sender, System.EventArgs e)
		{
			if (!CheckGvRepliesFocusRow())
				return;

			DataRow row = gvMemo.GetDataRow(gvMemo.FocusedRowHandle);

			if (Convert.ToInt32(row["nEmployeeID"]) == Convert.ToInt32(luedtMemoEmployeeID.EditValue))
			{
				ACMS.ACMSStaff.Memo.frmReplies myForm = new ACMS.ACMSStaff.Memo.frmReplies(
					Convert.ToInt32(gvReplies.GetDataRow(gvReplies.FocusedRowHandle)["nBulletinID"]), 
					Convert.ToInt32(row["nMemoID"]), Convert.ToInt32(luedtMemoEmployeeID.EditValue),
					ACMSLogic.Staff.MemoReplyAction.Update);
				if (DialogResult.OK == myForm.ShowDialog())
				{
					row.BeginEdit();
					row["fRead"] = false;
					row.EndEdit();
					lastMemoIDForReplies = -1;
					ListReplies();
				}
				myForm.Dispose();
			}
			else
			{
				UI.ShowErrorMessage(this, "You are not author of this reply, so you can't update this reply.");
				return;
			}
		}

		private void sbtnRepliesDelete_Click(object sender, System.EventArgs e)
		{
			if (!CheckGvRepliesFocusRow())
				return;
			if (!UI.ShowYesNoMessage(this, "Are you sure you want to delete?"))
				return;

			DataRow row = gvReplies.GetDataRow(gvReplies.FocusedRowHandle);

			if (Convert.ToInt32(row["nEmployeeID"]) == Convert.ToInt32(luedtMemoEmployeeID.EditValue))
			{
				if(myMemo.DeleteReply(Convert.ToInt32(row["nBulletinID"])))
					UI.ShowMessage(this, "Delete reply successfully.");
				else
					UI.ShowErrorMessage(this, "Failed to delete reply.");
				lastMemoIDForReplies = -1;
				ListReplies();
			}
			else
			{
				UI.ShowErrorMessage(this, "You are not author of this reply, so you can't delete this reply.");
				return;
			}
		}

		
		private void sbtnMemoPrint_Click(object sender, System.EventArgs e)
		{
			if (!CheckGvMemoFocusRow())
				return;

			DataRow row = gvMemo.GetDataRow(gvMemo.FocusedRowHandle);

			DataSet dsPrintMemo = myMemo.PrintMemo(Convert.ToInt32(row["nMemoID"]));

			ACMS.ACMSStaff.Report.ReportMemo report = 
				new ACMS.ACMSStaff.Report.ReportMemo();//employee.Id, employee.StrEmployeeName);
			report.DataSource = dsPrintMemo;
			//report.RunDesigner();
			report.Print();
			report.Dispose();
		}
		#endregion

		#region Memo Receipient
		private void ListRecipients()
		{
			if (gvMemo.FocusedRowHandle < 0)
			{
				gctrReceipient.DataSource = null;
				lastMemoIDForRepceipientGroup = -1;
				return;
			}

			int nMemoID = Convert.ToInt32(gvMemo.GetDataRow(gvMemo.FocusedRowHandle)["nMemoID"]);
			DataTable dtblSource = myMemo.ViewRecipient(nMemoID, (ReceipientType)cbMemoReceipient.SelectedIndex);
			gctrReceipient.DataSource = dtblSource;
			lastMemoIDForRepceipientGroup = nMemoID;
		}

		private void cbMemoReceipient_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lastMemoIDForRepceipientGroup = -1;
			ListRecipients();
		}

		private void sbtnReceipientDelete_Click(object sender, System.EventArgs e)
		{
			if (gvReceipient.FocusedRowHandle < 0)
			{
				UI.ShowErrorMessage(this, "Please select a Receipient to delete.");
				return;
			}

			if (!UI.ShowYesNoMessage(this, "Are you sure you want to delete this Receipient?"))
				return;

			if (employee.Id != Convert.ToInt32(gvMemo.GetDataRow(gvMemo.FocusedRowHandle)["nEmployeeID"]))
			{
				UI.ShowErrorMessage(this, "You don't have right to delete receipient.");
				return;
			}

			DataRow row = gvReceipient.GetDataRow(gvReceipient.FocusedRowHandle);

			if (myMemo.DeleteReceipient(Convert.ToInt32(row["nTypeID"]), row["nReceipientID"].ToString(), Convert.ToInt32(row["nMemoID"])))
			{
				UI.ShowMessage(this, "Delete Receipient successfully.");
			}
			else
				UI.ShowMessage(this, "Failed to delete Receipient.");
			
			lastMemoIDForRepceipientGroup = -1;
			ListRecipients();
		}

		private void sbtnReceipientNew_Click(object sender, System.EventArgs e)
		{
			if (!CheckGvMemoFocusRow())
				return;

			int nMemoID = Convert.ToInt32(gvMemo.GetDataRow(gvMemo.FocusedRowHandle)["nMemoID"]);

			ACMSStaff.Memo.frmNewReceipient2 myForm = new ACMS.ACMSStaff.Memo.frmNewReceipient2(nMemoID, 
				Convert.ToInt32(luedtMemoEmployeeID.EditValue));
			if (DialogResult.OK == myForm.ShowDialog())
			{
				lastMemoIDForRepceipientGroup = -1;
				ListRecipients();
			}
			myForm.Dispose();	
		}
		#endregion

		#region Receipient Group
		private bool ValidateRowSelectedReceipientGroup()
		{
			if (gvRecpGrp.FocusedRowHandle < 0)
			{
				UI.ShowErrorMessage("Please select a record at Group Receipient.");
				return false;
			}
			return true;
		}

		private void ListReceipientGroup()
		{
			DataTable dtblSource = myReceipientGroup.ViewReceipientGroup(Convert.ToInt32(luedtMemoEmployeeID.EditValue));
			gctrRecpGrp.DataSource = dtblSource;
		}

		private void ListReceipientGroupEntries()
		{
			if (gvRecpGrp.FocusedRowHandle >= 0)
			{
				int nReceipientGroupID = Convert.ToInt32(gvRecpGrp.GetDataRow(gvRecpGrp.FocusedRowHandle)["nMemoGroupID"]);
				if (nReceipientGroupID != lastReceipientGroupID)
				{
					DataTable dtblSource = myReceipientGroup.ViewReceipientGroupEntries(nReceipientGroupID);
					gctrRecpEntry.DataSource = dtblSource;
					lastReceipientGroupID = nReceipientGroupID;
				}
			}
			else
			{
				gctrRecpEntry.DataSource = null;
				lastReceipientGroupID = -1;
			}
		}

		private void sbtnRecpGrpNew_Click(object sender, System.EventArgs e)
		{
			ACMS.ACMSStaff.ReceipientGroup.frmReceipientGroup form = 
				new ACMS.ACMSStaff.ReceipientGroup.frmReceipientGroup(Convert.ToInt32(luedtMemoEmployeeID.EditValue), -1, "New");
			if (DialogResult.OK == form.ShowDialog())
				ListReceipientGroup();
			form.Dispose();
		}

		private void sbtnRecpGrpEdit_Click(object sender, System.EventArgs e)
		{
			if (!ValidateRowSelectedReceipientGroup())
				return;

			DataRow row = gvRecpGrp.GetDataRow(gvRecpGrp.FocusedRowHandle);

			ACMS.ACMSStaff.ReceipientGroup.frmReceipientGroup form = 
				new ACMS.ACMSStaff.ReceipientGroup.frmReceipientGroup(Convert.ToInt32(luedtMemoEmployeeID.EditValue), 
				Convert.ToInt32(row["nMemoGroupID"]), "Edit");
			form.MemoGroupCode = row["strMemoGroupCode"].ToString();
			form.Description = row["strDescription"].ToString();
			if (DialogResult.OK == form.ShowDialog())
				ListReceipientGroup();
			form.Dispose();
		}

		private void sbtnRecpGrpDelete_Click(object sender, System.EventArgs e)
		{
			if (!ValidateRowSelectedReceipientGroup())
				return;

			if (!UI.ShowYesNoMessage("Are you sure you want to delete?"))
				return;

			DataRow row = gvRecpGrp.GetDataRow(gvRecpGrp.FocusedRowHandle);
			if	(myReceipientGroup.DeleteReceipientGroup(Convert.ToInt32(row["nMemoGroupID"])))
			{
				UI.ShowMessage("Delete Receipient Group successfully.");
			}
			else
				UI.ShowMessage("Failed to delete Receipient Group.");

			ListReceipientGroup();
		}

		private void gvRecpGrp_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			ListReceipientGroupEntries();
		}

		
		private void gvRecpGrp_DataSourceChanged(object sender, System.EventArgs e)
		{
			ListReceipientGroupEntries();
		}

		private void sbtnRecpEntryNew_Click(object sender, System.EventArgs e)
		{
			if (!ValidateRowSelectedReceipientGroup())
				return;

			DataRow row = gvRecpGrp.GetDataRow(gvRecpGrp.FocusedRowHandle);
			ACMS.ACMSStaff.ReceipientGroup.frmReceipientGroupEntries form = 
				new ACMS.ACMSStaff.ReceipientGroup.frmReceipientGroupEntries(Convert.ToInt32(row["nMemoGroupID"]));
			if (DialogResult.OK == form.ShowDialog())
			{
				lastReceipientGroupID = -1;
				ListReceipientGroupEntries();
			}
			form.Dispose();
		}

		private void sbtnRecpEntryDelete_Click(object sender, System.EventArgs e)
		{
			if (!ValidateRowSelectedReceipientGroup())
				return;

			if (!UI.ShowYesNoMessage("Are you sure you want to delete?"))
				return;

			DataRow row = gvRecpEntry.GetDataRow(gvRecpEntry.FocusedRowHandle);
			if	(myReceipientGroup.DeleteReceipientGroupEntries(Convert.ToInt32(row["nMemoGroupID"]), 
				Convert.ToInt32(row["nEmployeeID"])))
			{
				UI.ShowMessage("Delete Receipient Group Entries successfully.");
			}
			else
				UI.ShowMessage("Failed to delete Receipient Group Entries.");
			lastReceipientGroupID = -1;
			ListReceipientGroupEntries();
		}
				
		#endregion

		#region Appointment
		private void ListAppointment()
		{
			if (cbAppointmentYear.EditValue == null)
				return;
			DateTime startDate, endDate;
			DateRange(out startDate, out endDate, cbAppointmentMonth.SelectedIndex, 
				Convert.ToInt32(cbAppointmentYear.EditValue));
			DataTable dtblSource = myAppointment.ListAppointment(employee.Id, startDate, endDate);
			gridctrAppointment.DataSource = dtblSource;
		}

		private bool ValidateRowSelectedAppointment()
		{
			if (gvAppointment.FocusedRowHandle < 0)
			{
				UI.ShowErrorMessage("Please select a record at Appointment.");
				return false;
			}
			return true;
		}

		private void sbtnAppointmentInquiry_Click(object sender, System.EventArgs e)
		{
			ListAppointment();
		}

		private void sbtnAppointmentNew_Click(object sender, System.EventArgs e)
		{
			ACMS.ACMSStaff.Appointment.frmAppointment form = new ACMS.ACMSStaff.Appointment.frmAppointment(employee.Id, -1);
			if (DialogResult.OK == form.ShowDialog())
				ListAppointment();
			form.Dispose();
		}

		private void sbtnAppointmentEdit_Click(object sender, System.EventArgs e)
		{
			if (!ValidateRowSelectedAppointment())
				return;

			DataRow row = gvAppointment.GetDataRow(gvAppointment.FocusedRowHandle);
			ACMS.ACMSStaff.Appointment.frmAppointment form = new ACMS.ACMSStaff.Appointment.frmAppointment(employee.Id, 
				Convert.ToInt32(row["nAppointmentId"]));
			form.Date = Convert.ToDateTime(row["dtDate"]);
			form.StartTime = Convert.ToDateTime(row["dtStartTime"]);
			form.EndTime = Convert.ToDateTime(row["dtEndTime"]);
			form.Organization = row["strOrganization"].ToString();
			form.AppointmetnType = Convert.ToInt32(row["nAppointmentTypeId"]);
			form.ContactID = Convert.ToInt32(row["nContactId"]);
			form.Remark = row["strRemarks"].ToString();
			if (DialogResult.OK == form.ShowDialog())
				ListAppointment();
			form.Dispose();
		}

		private void sbtnAppointmentDelete_Click(object sender, System.EventArgs e)
		{
			if (!ValidateRowSelectedAppointment())
				return;

			if (!UI.ShowYesNoMessage("Are you sure you want to delete this appointment?"))
				return;
			
			DataRow row = gvAppointment.GetDataRow(gvAppointment.FocusedRowHandle);
			DateTime date = Convert.ToDateTime(row["dtDate"]);
			DateTime time = Convert.ToDateTime(row["dtEndTime"]);
			DateTime validateDate = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Month, time.Second);

			if (validateDate < DateTime.Now)
			{
				UI.ShowErrorMessage("This appointment already pass, so it is not allow to delete.");
				return;
			}

			if (myAppointment.DeleteAppointment(Convert.ToInt32(row["nAppointmentId"])))
			{
				UI.ShowMessage("Delete Appointment successfully.");
				ListAppointment();
			}
			else
				UI.ShowErrorMessage("Failed to delete appointment.");
		}

		private void sbtnAppointmentPrint_Click(object sender, System.EventArgs e)
		{
			ACMS.ACMSStaff.Report.ReportAppointment report = 
				new ACMS.ACMSStaff.Report.ReportAppointment(employee.Id, employee.StrEmployeeName);
			report.DataSource = (gvAppointment.DataSource as DataView).Table;
			report.CreateDataBindings();
			report.Print();
			report.Dispose();
		}
		#endregion

		#region Contact
		private void ListContact()
		{
			DataTable dtblSource = myContacts.ListContacts(employee.Id);
			gridctrContact.DataSource = dtblSource;
		}

		private bool ValidateRowSelectedContacts()
		{
			if (gvContact.FocusedRowHandle < 0)
			{
				UI.ShowErrorMessage("Please select a record at Contact.");
				return false;
			}
			return true;
		}

		private void sbtnContactNew_Click(object sender, System.EventArgs e)
		{
			ACMS.ACMSStaff.Contacts.frmContacts form = new ACMS.ACMSStaff.Contacts.frmContacts(employee.Id, -1);
			if (DialogResult.OK == form.ShowDialog())
				ListContact();
			form.Dispose();
		}

		private void sbtnContactEdit_Click(object sender, System.EventArgs e)
		{
			if (!ValidateRowSelectedContacts())
				return;

			DataRow row = gvContact.GetDataRow(gvContact.FocusedRowHandle);
			ACMS.ACMSStaff.Contacts.frmContacts form = new ACMS.ACMSStaff.Contacts.frmContacts(employee.Id, 
				Convert.ToInt32(row["nContactId"]));
			form.ContactPerson = row["strContactName"].ToString();
			form.Organization = row["strOrganization"].ToString();
			form.OfficeNo = row["strOfficeNo"].ToString();
			form.MobileNo = row["strMobileNo"].ToString();
			form.Fax = row["strFax"].ToString();
			form.Email = row["strEmail"].ToString();
			form.Address = row["strAddress"].ToString();
			if (DialogResult.OK == form.ShowDialog())
				ListContact();
			form.Dispose();
		}

		private void sbtnContactDelete_Click(object sender, System.EventArgs e)
		{
			if (!ValidateRowSelectedContacts())
				return;

			if (!UI.ShowYesNoMessage("Are you sure you want to delete this contact?"))
				return;
			
			DataRow row = gvContact.GetDataRow(gvContact.FocusedRowHandle);

			try
			{
				if (myContacts.DeleteContact(Convert.ToInt32(row["nContactId"])))
				{
					UI.ShowMessage("Delete Contact successfully.");
					ListContact();
				}
			}
			catch (SqlException ex)
			{ 
				if (ex.Message.IndexOf("DELETE statement conflicted with COLUMN REFERENCE constraint 'FK_tblAppointment_tblContacts'.")
					>= 0)
				{
					UI.ShowErrorMessage(this, "This contact is still use in appointment. Please delete appointment before you can "
						+"delete this contact.");
				}
				else
					throw;
			}
		}
		#endregion

		#region Timesheet
		private void ListTimesheet()
		{
			if (cbTimesheetYear.EditValue == null)
				return;
//			DateTime startDate, endDate;
//			DateRange(out startDate, out endDate, cbTimesheetMonth.SelectedIndex, 
//				Convert.ToInt32(cbTimesheetYear.EditValue));
//			DataTable dtblSource = myTimesheet.ListTimesheet(employee.Id, startDate, endDate);
			DataTable dtblSource = myTimesheet.ListTimesheetWithLateness(employee.Id, (Month)cbTimesheetMonth.SelectedIndex,
				Convert.ToInt32(cbTimesheetYear.EditValue));
			gridctrTimesheet.DataSource = dtblSource;
		}

		private void sbtnTimesheetInquiry_Click(object sender, System.EventArgs e)
		{
			ListTimesheet();
			//ListTimesheetDetail();
		}

		private void ListTimesheetDetail()
		{
			if (gvTimesheet.FocusedRowHandle < 0)
				return;

			DataRow row = gvTimesheet.GetDataRow(gvTimesheet.FocusedRowHandle);
			DateTime date = ACMS.Convert.ToDateTime(row["dtDate"]);
			DataTable timesheetTable, timeCardTable;
			myTimesheet.ListTimesheetDetail(employee.Id, date.Date, date.Date.AddDays(1), out timesheetTable, out timeCardTable);
			ACMS.ACMSStaff.frmTimeSheetDetail frm = new ACMS.ACMSStaff.frmTimeSheetDetail(timesheetTable, timeCardTable);
			frm.ShowDialog();
			frm.Dispose();
		}

		private void gvTimesheet_DoubleClick(object sender, System.EventArgs e)
		{
			DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hitInfo = ACMS.XtraUtils.GridViewUtils.GetGridHitInfo(gvTimesheet);

			if (hitInfo.InRow)
			{
				ListTimesheetDetail();
			}
		}

		private void gvTimesheet_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
		{
			GridView view = sender as GridView;

			if(e.RowHandle >= 0) 
			{
				DataRow r = view.GetDataRow(e.RowHandle);
				if(r != null && ACMS.Convert.ToBoolean(r["fLateness"])) 
				{
					e.Appearance.ForeColor = Color.Red;
				}
			}
		}
		#endregion

		#region Overtime - Part of Timesheet
		private void ListOvertime()
		{
			if (cbOvertimeYear.EditValue == null)
				return;
			DateTime startDate, endDate;
			DateRange(out startDate, out endDate, cbOvertimeMonth.SelectedIndex, 
				Convert.ToInt32(cbOvertimeYear.EditValue));
			DataTable dtblSource = myTimesheet.ListOvertime(employee.Id, startDate, endDate);
			gridctrOvertime.DataSource = dtblSource;
		}

		private void sbtnOvertimeInquiry_Click(object sender, System.EventArgs e)
		{
			ListOvertime();
		}

		private void sbtnApplyOvertime_Click(object sender, System.EventArgs e)
		{
			ACMS.ACMSStaff.Timesheet.frmOvertime frm = new ACMS.ACMSStaff.Timesheet.frmOvertime(employee, myTimesheet, 
				myEmployeeInfo);
			if (DialogResult.OK == frm.ShowDialog())
				ListOvertime();
			frm.Dispose();
		}

		private void sbtnOvertimeDelete_Click(object sender, System.EventArgs e)
		{
			if (!CheckGvOvertimeFocusRow())
				return;

			DataRow rCurrent = gvOvertime.GetDataRow(gvOvertime.FocusedRowHandle);

			if (rCurrent["nStatusID"].ToString() != "0")
			{
				UI.ShowErrorMessage("This is not a pending overtime, you can't cancel it.");
				return;
			}

			if (UI.ShowYesNoMessage("Are you sure you want to delete this overtime?"))
			{
				if (myTimesheet.DeleteOvertime(Convert.ToInt32(rCurrent["nOvertimeID"]), employee.Id))
				{
					UI.ShowMessage("Cancel overtime successfully.");
					ListOvertime();
				}
				else
					UI.ShowErrorMessage("Failed to cancel overtime.");
			}
		}
		#endregion

		#region Lateness - Part of Timesheet
		private void sbtnLatenessInquiry_Click(object sender, System.EventArgs e)
		{
			myLateness.GetLateness(employee.Id, Ultis.GetMonth(cbLatenessMonth.SelectedIndex + 1), 
				Convert.ToInt32(cbLatenessYear.EditValue));
			gridctrLateness.DataSource = myLateness.LatenessTable;
		}
		#endregion

		#region Leave
		private void RefreshLeave()
		{
			InitRoster(new DateTime(startLeaveDate.Year, startLeaveDate.Month, 1));
			ListAllLeaveDetail();
		}
		private void ListAllLeaveDetail()
		{
			if ((tabStaff.SelectedTabPage != tabStaffSix) || !isFinishedLeaveInit)
				return;

			DataTable dtblSource;
			dtblSource = myLeave.ListLeaveByYearIDStatus(ACMS.Convert.ToInt32(luedtLeaveEmployeeID.EditValue.ToString()), 
				ACMS.Convert.ToInt32(cbLeaveNYearID.EditValue), (ACMSLogic.Staff.Leave.ListLeaveStatus)cbLeaveStatus.SelectedIndex);

			gridctrLeaveDetail.DataSource = dtblSource;
		}

		private void sbtnLeaveNextMonth_Click(object sender, System.EventArgs e)
		{
			int monthDiff = startLeaveDate.Month - DateTime.Today.Month;
			if (monthDiff < 3)
			{
				startLeaveDate = startLeaveDate.AddMonths(1);
				InitRoster(new DateTime(startLeaveDate.Year, startLeaveDate.Month, 1));
				//ListAllLeaveDetail();
			}
			else
			{
				UI.ShowErrorMessage("You can see maximum 3 next months only.");
			}
		}

		private void sbtnLeavePreviousMonth_Click(object sender, System.EventArgs e)
		{
			int monthDiff = DateTime.Now.Month - startLeaveDate.Month;
			if (monthDiff < 3)
			{
				startLeaveDate = startLeaveDate.AddMonths(-1);
				InitRoster(new DateTime(startLeaveDate.Year, startLeaveDate.Month, 1));
				//ListAllLeaveDetail();
			}
			else
			{
				UI.ShowErrorMessage("You can see maximum 3 previous months only.");
			}
		}

		private void sbtnLeaveApply_Click(object sender, System.EventArgs e)
		{
			ACMS.ACMSStaff.Leave.frmLeave form = new ACMS.ACMSStaff.Leave.frmLeave(-1, 
				ACMS.Convert.ToInt32(luedtLeaveEmployeeID.EditValue), myLeaveEmployeeInfo);
			if (DialogResult.OK == form.ShowDialog())
				RefreshLeave();
			form.Dispose();
		}

		private void sbtnLeaveEdit_Click(object sender, System.EventArgs e)
		{
			if (!CheckGvLeaveFocusRow())
				return;

			DataRow rLeave = gvLeave.GetDataRow(gvLeave.FocusedRowHandle);

			if (Convert.ToInt32(rLeave["nStatusID"]) != 0)
			{
				UI.ShowErrorMessage(this, "You can edit Pending Approval leave only.");
				return;
			}

			int nLeaveID = Convert.ToInt32(rLeave["nLeaveID"]);

			ACMS.ACMSStaff.Leave.frmLeave frm = new ACMS.ACMSStaff.Leave.frmLeave(nLeaveID, 
				ACMS.Convert.ToInt32(luedtLeaveEmployeeID.EditValue), myLeaveEmployeeInfo);
			frm.Text = "Edit Leave";
			frm.LeaveType = rLeave["strLeaveCode"];
			frm.StartDate = Convert.ToDateTime(rLeave["dtStartTime"]);
			frm.StartTime = Convert.ToDateTime(rLeave["dtStartTime"]);
			frm.EndTime = Convert.ToDateTime(rLeave["dtEndTime"]);
			frm.Reason = rLeave["strRemarks"].ToString();
			frm.IsHalfDay = !System.Convert.ToBoolean(rLeave["fFullDay"]);
			if (System.Convert.ToBoolean(rLeave["fFullDay"]))
				frm.EnableTime = false;
			if (System.Convert.ToBoolean(rLeave["fTimeOff"]))
			{
				frm.ShowIsHalfDay = false;
				frm.EnableTime = true;
			}
			if (DialogResult.Cancel != frm.ShowDialog())
				RefreshLeave();

			frm.Dispose();
		}

		private void sbtnLeaveDelete_Click(object sender, System.EventArgs e)
		{
			if (!CheckGvLeaveFocusRow())
				return;

			if (!UI.ShowYesNoMessage("Are you sure you want to cancel this leave?"))
				return;
			
			DataRow row = gvLeave.GetDataRow(gvLeave.FocusedRowHandle);

			if (Convert.ToInt32(row["nStatusID"]) != 0)
			{
				UI.ShowErrorMessage(this, "Can't cancel Approved, Rejected or Cancelled leave.");
				return;
			}

			if (myLeave.CancelLeave(ACMS.Convert.ToInt32(luedtLeaveEmployeeID.EditValue), Convert.ToInt32(row["nLeaveID"])))
			{
				UI.ShowMessage(this, "Cancel leave successfully.");
				RefreshLeave();
			}
			else
			{
				UI.ShowErrorMessage(this, "Failed to cancel leave.");
			}
		}

		private void sbtnLeaveBalanceInquiry_Click(object sender, System.EventArgs e)
		{
			if (cbLeaveBalance.SelectedIndex == 0)
			{
				int nEmployeeID = ACMS.Convert.ToInt32(luedtLeaveEmployeeID.EditValue);
				gridctrLeaveBalance.DataSource = myLeave.dwGetAnnualLeaveBalance(nEmployeeID,ACMS.Convert.ToInt32(cbLeaveNYearID.EditValue));
				colLeaveBalanceNoOfDays.Caption = "No. Of Days";
				decimal PrevBal = ACMS.Convert.ToDecimal(colLeaveBalanceNoOfDays.SummaryItem.SummaryValue);
				myLeave.UpdatePreviousBal(nEmployeeID,ACMS.Convert.ToInt32(cbLeaveNYearID.EditValue),PrevBal);
			}
			else if (cbLeaveBalance.SelectedIndex == 1)
			{
				gridctrLeaveBalance.DataSource = myLeave.GetTimeOffBalance(ACMS.Convert.ToInt32(luedtLeaveEmployeeID.EditValue));
				colLeaveBalanceNoOfDays.Caption = "No. Of Hours";
			}
			else
			{
				int nEmployeeID = ACMS.Convert.ToInt32(luedtLeaveEmployeeID.EditValue);
				gridctrLeaveBalance.DataSource = myLeave.GetMiscBalance(nEmployeeID);
				colLeaveBalanceNoOfDays.Caption = "No. Of Days";
			}
		}

		private void luedtLeaveEmployeeID_EditValueChanged(object sender, System.EventArgs e)
		{
			isFinishedLeaveInit = false;
			int nEmployeeID = ACMS.Convert.ToInt32(luedtLeaveEmployeeID.EditValue);
			myLeaveEmployeeInfo = Ultis.EmployeeInfo(nEmployeeID);
			InitRoster(startLeaveDate);
			acmsRosterHeader1.ShowHeaderLabel = false;
			acmsRosterHeader2.ShowHeaderLabel = false;
			acmsRosterHeader3.ShowHeaderLabel = false;
			acmsRosterHeader4.ShowHeaderLabel = false;
			acmsRosterHeader5.ShowHeaderLabel = false;

			int nYearID = myLeave.GetNYearID(nEmployeeID);
			cbLeaveNYearID.Properties.Items.Clear();
			for (int i = 1; i <= nYearID; i++)
			{
				cbLeaveNYearID.Properties.Items.Add(i+1);
			}
			cbLeaveNYearID.SelectedIndex = nYearID - 2;
            //cbLeaveNYearID.SelectedIndex = 0;

			dateedtLeaveJoinDate.EditValue = myLeaveEmployeeInfo["dtEmployeeStartDate"];
			txtLeaveEntitlement.EditValue = myLeave.GetLeaveEntitlement(nYearID,nEmployeeID);
			isFinishedLeaveInit = true;

			ListAllLeaveDetail();
		}

		private void dateedtLeaveJoinDate_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = true;
		}

		private void cbLeaveNYearID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ListAllLeaveDetail();
		}

		private void cbLeaveStatus_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ListAllLeaveDetail();
		}
		#endregion

		#region Roster - Part of Leave
		private void InitRoster(DateTime aFirstOfMonth)
		{
			Cursor lastCursor = Cursor.Current;
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				this.SuspendLayout();
				DateTime currentDate = aFirstOfMonth;
				for (int i = 0; i < 6; i++)
				{
					DateTime addDate = i==0 ? currentDate : currentDate.AddDays(7);
					ACMSRosterHeader myACMSRosterHeader;
					if (i == 0)
						myACMSRosterHeader = acmsRosterHeader1;
					else if (i == 1)
						myACMSRosterHeader = acmsRosterHeader2;
					else if (i == 2)
						myACMSRosterHeader = acmsRosterHeader3;
					else if (i == 3)
						myACMSRosterHeader = acmsRosterHeader4;
					else if (i == 4)
						myACMSRosterHeader = acmsRosterHeader5;
					else //if (i == 5)
						myACMSRosterHeader = acmsRosterHeader6;

					myACMSRosterHeader.SuspendLayout();

					if ((aFirstOfMonth.AddMonths(1).Month == addDate.Month && addDate.Day < (((int)addDate.DayOfWeek))+1) ||
						aFirstOfMonth.Month == addDate.Month)
					{
						AddRoster(myACMSRosterHeader, addDate);
						myACMSRosterHeader.Visible = true;
					}
					else
					{
						myACMSRosterHeader.Visible = false;
					}

					myACMSRosterHeader.ResumeLayout();
					currentDate = addDate;
				}

				AddLeave(aFirstOfMonth);

				groupLeaveRoster.Text = "ROSTER (" +aFirstOfMonth.ToString("MMMM, yyyy") +")";

				this.ResumeLayout();
			}
			finally
			{
				Cursor.Current = lastCursor;
			}
		}

		private void AddRoster(ACMSRosterHeader aAcmsRosterHeader, DateTime aDate)
		{
			string strSQL;
			DataSet _ds;

			strSQL = "SELECT @Date AS Today, DATEPART(weekday, @Date) AS Week_Day";
			SqlParameter date1 = new SqlParameter("@Date", SqlDbType.DateTime);
			date1.Value = aDate;
			_ds = new DataSet();
			SqlHelper.FillDataset(SqlHelperUtils.connectionString, CommandType.Text, strSQL, _ds, new string[] {"table"}, date1);
			aAcmsRosterHeader.dtRoster = _ds.Tables["table"];

			strSQL = "SELECT * FROM SV_StaffRosterDetail WHERE nEmployeeID = @nEmployeeID AND rYear = @rYear "
				+"AND week_no = DATEPART(week, @Date)";
			_ds = new DataSet();
			SqlParameter nEmployeeID = new SqlParameter("@nEmployeeID", SqlDbType.Int);
			nEmployeeID.Value = luedtLeaveEmployeeID.EditValue;//employee.Id;
			SqlParameter rYear = new SqlParameter("@rYear", SqlDbType.Int);
			rYear.Value = aDate.Year;
			SqlParameter date = new SqlParameter("@Date", SqlDbType.DateTime);
			date.Value = aDate;
			SqlHelper.FillDataset(SqlHelperUtils.connectionString, CommandType.Text, strSQL, _ds, new string[] {"table"}, 
				nEmployeeID, rYear, date);
			aAcmsRosterHeader.dtRosterDetail = _ds.Tables["table"];
			aAcmsRosterHeader.init(false, aDate.Year.ToString(), Ultis.WeekNumber(aDate).ToString());
		}

		private void AddLeave(DateTime aDate)
		{
			DateTime startDate, endDate;
			Ultis.FirstAndLastOfMonth(out startDate, out endDate, (Month)(aDate.Month - 1), aDate.Year);
			SqlParameter paramStartDate = new SqlParameter("@ddtStartDate", SqlDbType.DateTime);
			paramStartDate.Value = startDate;
			SqlParameter paramEndDate = new SqlParameter("@ddtEndDate", SqlDbType.DateTime);
			paramEndDate.Value = endDate;
			SqlParameter paramEmployeeID = new SqlParameter("@inEmployeeID", SqlDbType.Int);
			paramEmployeeID.Value = luedtLeaveEmployeeID.EditValue;//employee.Id;

			DataSet _ds = new DataSet();

			SqlHelper.FillDataset(SqlHelperUtils.connectionString, "pr_SelectLeave", _ds, new string[] {"table"}, paramEmployeeID,
				paramStartDate, paramEndDate);

			foreach (DataRow row in _ds.Tables[0].Rows)
			{
				DateTime dtStartTime = Convert.ToDateTime(row["dtStartTime"]);
				DateTime dtEndTime = Convert.ToDateTime(row["dtEndTime"]);

				if (acmsRosterHeader1.ACMSRosterDetails1 != null && 
					(Convert.ToInt32(acmsRosterHeader1.ACMSRosterDetails1.WeekNo) >= Ultis.WeekNumber(dtStartTime) &&
					Convert.ToInt32(acmsRosterHeader1.ACMSRosterDetails1.WeekNo) <= Ultis.WeekNumber(dtEndTime)))
				{
					SetLeaveColor(acmsRosterHeader1, row);
				}
				if (acmsRosterHeader2.ACMSRosterDetails1 != null && 
					(Convert.ToInt32(acmsRosterHeader2.ACMSRosterDetails1.WeekNo) >= Ultis.WeekNumber(dtStartTime) &&
					Convert.ToInt32(acmsRosterHeader2.ACMSRosterDetails1.WeekNo) <= Ultis.WeekNumber(dtEndTime)))
				{
					SetLeaveColor(acmsRosterHeader2, row);
				}
				if (acmsRosterHeader3.ACMSRosterDetails1 != null && 
					(Convert.ToInt32(acmsRosterHeader3.ACMSRosterDetails1.WeekNo) >= Ultis.WeekNumber(dtStartTime) &&
					Convert.ToInt32(acmsRosterHeader3.ACMSRosterDetails1.WeekNo) <= Ultis.WeekNumber(dtEndTime)))
				{
					SetLeaveColor(acmsRosterHeader3, row);
				}
				if (acmsRosterHeader4.ACMSRosterDetails1 != null && 
					(Convert.ToInt32(acmsRosterHeader4.ACMSRosterDetails1.WeekNo) >= Ultis.WeekNumber(dtStartTime) &&
					Convert.ToInt32(acmsRosterHeader4.ACMSRosterDetails1.WeekNo) <= Ultis.WeekNumber(dtEndTime)))
				{
					SetLeaveColor(acmsRosterHeader4, row);
				}
				if (acmsRosterHeader5.ACMSRosterDetails1 != null && 
					(Convert.ToInt32(acmsRosterHeader5.ACMSRosterDetails1.WeekNo) >= Ultis.WeekNumber(dtStartTime) &&
					Convert.ToInt32(acmsRosterHeader5.ACMSRosterDetails1.WeekNo) <= Ultis.WeekNumber(dtEndTime)))
				{
					SetLeaveColor(acmsRosterHeader5, row);
				}
				if (acmsRosterHeader6.ACMSRosterDetails1 != null && 
					(Convert.ToInt32(acmsRosterHeader6.ACMSRosterDetails1.WeekNo) >= Ultis.WeekNumber(dtStartTime) &&
					Convert.ToInt32(acmsRosterHeader6.ACMSRosterDetails1.WeekNo) <= Ultis.WeekNumber(dtEndTime)))
				{
					SetLeaveColor(acmsRosterHeader6, row);
				}
			}
		}

		///<summary>
		/// Refactored from AddLeave
		///</summary>
		private void SetLeaveColor(ACMSRosterHeader acmsRosterHeader, DataRow row)
		{
			DateTime dtStartTime = Convert.ToDateTime(row["dtStartTime"]);
			DateTime dtEndTime = Convert.ToDateTime(row["dtEndTime"]);
			DateTime dtStartDate = dtStartTime.Date;
			DateTime dtEndDate = dtEndTime.Date;

			int startWeekDay = (int)dtStartTime.DayOfWeek;
			int endWeekDay = (int)dtEndTime.DayOfWeek;
			bool isTimeOff = row["fTimeOff"] == DBNull.Value ? false : System.Convert.ToBoolean(row["fTimeOff"]);
			int nStatusID = Convert.ToInt32(row["nStatusID"]);
			bool isHalfDay = ACMS.Convert.ToBoolean(row["fFullDay"]) ? false : true;

			if (acmsRosterHeader.dateSun >= dtStartDate && acmsRosterHeader.dateSun <= dtEndDate) 
			{
				acmsRosterHeader.ACMSRosterDetails1.panelSUN.BackColor = LeaveColor(isTimeOff, nStatusID, isHalfDay);
				acmsRosterHeader.ACMSRosterDetails1.NLeaveIDSun = Convert.ToInt32(row["nLeaveID"]);
			}
			if (acmsRosterHeader.dateMon >= dtStartDate && acmsRosterHeader.dateMon <= dtEndDate) 
			{
				acmsRosterHeader.ACMSRosterDetails1.panelMON.BackColor = LeaveColor(isTimeOff, nStatusID, isHalfDay);
				acmsRosterHeader.ACMSRosterDetails1.NLeaveIDMon = Convert.ToInt32(row["nLeaveID"]);
			}
			if (acmsRosterHeader.dateTue >= dtStartDate && acmsRosterHeader.dateTue <= dtEndDate) 
			{
				acmsRosterHeader.ACMSRosterDetails1.panelTUE.BackColor = LeaveColor(isTimeOff, nStatusID, isHalfDay);
				acmsRosterHeader.ACMSRosterDetails1.NLeaveIDTue = Convert.ToInt32(row["nLeaveID"]);
			}
			if (acmsRosterHeader.dateWed >= dtStartDate && acmsRosterHeader.dateWed <= dtEndDate) 
			{
				acmsRosterHeader.ACMSRosterDetails1.panelWED.BackColor = LeaveColor(isTimeOff, nStatusID, isHalfDay);
				acmsRosterHeader.ACMSRosterDetails1.NLeaveIDWed = Convert.ToInt32(row["nLeaveID"]);
			}
			if (acmsRosterHeader.dateThu >= dtStartDate && acmsRosterHeader.dateThu <= dtEndDate) 
			{
				acmsRosterHeader.ACMSRosterDetails1.panelTHU.BackColor = LeaveColor(isTimeOff, nStatusID, isHalfDay);
				acmsRosterHeader.ACMSRosterDetails1.NLeaveIDThu = Convert.ToInt32(row["nLeaveID"]);
			}
			if (acmsRosterHeader.dateFri >= dtStartDate && acmsRosterHeader.dateFri <= dtEndDate) 
			{
				acmsRosterHeader.ACMSRosterDetails1.panelFRI.BackColor = LeaveColor(isTimeOff, nStatusID, isHalfDay);
				acmsRosterHeader.ACMSRosterDetails1.NLeaveIDFri = Convert.ToInt32(row["nLeaveID"]);
			}
			if (acmsRosterHeader.dateSat >= dtStartDate && acmsRosterHeader.dateSat <= dtEndDate) 
			{
				acmsRosterHeader.ACMSRosterDetails1.panelSAT.BackColor = LeaveColor(isTimeOff, nStatusID, isHalfDay);
				acmsRosterHeader.ACMSRosterDetails1.NLeaveIDSat = Convert.ToInt32(row["nLeaveID"]);
			}
		}

		private Color LeaveColor(bool fTimeOff, int nStatusID, bool isHalfDay)
		{
			if (nStatusID == 0) //Pending
				return Color.Red;
			else if (fTimeOff)
				return Color.Green;
			else if (isHalfDay)
				return Color.Yellow;
			else
				return Color.LightBlue; //Full day
		}

		private void acmsRosterHeader_Click(object sender, System.EventArgs e)
		{
			ACMS.Control.ACMSRosterHeader rh = (ACMS.Control.ACMSRosterHeader) sender;
//			MessageBox.Show(rh.WeekDay);
//			MessageBox.Show(rh.WeekNo);
//			MessageBox.Show(rh.EmpID);
//			MessageBox.Show(rh.EmpID + rh.WeekNo + rh.WeekDay );
//			MessageBox.Show(rh.ACMSRosterDetails1.NLeaveID.ToString());
			

			DataTable myTable = myLeave.ListOneDetail(rh.ACMSRosterDetails1.NLeaveID);

			if (myTable.Rows.Count == 1)
			{
				ACMSStaff.Leave.frmLeaveDetail frm = new ACMS.ACMSStaff.Leave.frmLeaveDetail();
				frm.IsHalfDay = !System.Convert.ToBoolean(myTable.Rows[0]["fFullDay"]);
				frm.LeaveType = myTable.Rows[0]["strLeaveType"].ToString();
				frm.StartDate = Convert.ToDateTime(myTable.Rows[0]["dtStartTime"]);
				frm.StartTime = Convert.ToDateTime(myTable.Rows[0]["dtStartTime"]);
				frm.EndTime = Convert.ToDateTime(myTable.Rows[0]["dtEndTime"]);
				frm.Status = myTable.Rows[0]["strStatus"].ToString();
				frm.ApprovingManager = myTable.Rows[0]["strApprovingManagerName"].ToString();
				frm.Reason = myTable.Rows[0]["strRemarks"].ToString();
				if (System.Convert.ToBoolean(myTable.Rows[0]["fFullDay"]))
					frm.EnableTime = false;
				if (System.Convert.ToBoolean(myTable.Rows[0]["fTimeOff"]))
				{
					frm.ShowIsHalfDay = false;
					frm.EnableTime = true;
				}
				frm.ShowDialog();
				frm.Dispose();
			}
		}
		#endregion

		#region Menu
		private void MenuItemChangePassword_Click(object sender, System.EventArgs e)
		{
			ACMS.ACMSStaff.frmChangePassword frm = new ACMS.ACMSStaff.frmChangePassword(employee.Id);
			frm.ShowDialog();
			frm.Dispose();
		}

		private void MenuItemBlockMembershipID_Click(object sender, System.EventArgs e)
		{
			employee.RightsLevel.Id = 42;
			if (!employee.HasRight("AB_BLOCK_MEMBERSHIP_ID"))
			{
				UI.ShowErrorMessage(this, "You don't have right to block membership ID.");
				return;
			}

			ACMS.ACMSBranch.frmBlockMembershipID frm = new ACMS.ACMSBranch.frmBlockMembershipID(terminalUser.Branch.Id);
			if (frm.ShowDialog() == DialogResult.OK)
			{
				MemberRecord.BlockMembershipID(frm.NumberOfNonMemberID, frm.NumberOfMemberID, 
					frm.StrBranchCode != null ? frm.StrBranchCode.ToString() : "");
			}
			frm.Dispose();
		}		

		private void MenuItemResetMembershipID_Click(object sender, System.EventArgs e)
		{
			employee.RightsLevel.Id = 41;
			if (!employee.HasRight("AB_RESET_MEMBERSHIP_ID"))
			{
				UI.ShowErrorMessage(this, "You don't have right to reset membership ID.");
				return;
			}

			ACMS.ACMSBranch.frmResetMembershipID frm = new ACMS.ACMSBranch.frmResetMembershipID(terminalUser.Branch.Id);
			if (frm.ShowDialog() == DialogResult.OK)
			{
				MemberRecord.ResetMembershipID(frm.LastNonMemberID, frm.LastMemberID, terminalUser.Branch.Id);
			}
			frm.Dispose();
		}
		#endregion

		#region lblOne

		private void int_lblOne()
		{
			lblOne_1.ForeColor=System.Drawing.Color.MediumBlue;
			lblOne_2.ForeColor=System.Drawing.Color.MediumBlue;
			
			groupMessages.Hide();
			groupReceipientGroup.Hide();
		}

		private void lblOne_1_Click(object sender, System.EventArgs e)
		{
			int_lblOne();
			
			lblOne_1.ForeColor=System.Drawing.Color.Firebrick;
			//Intilize SubGroups
			this.lblmnuMessagesMemoInfo_Click(this, e);
			groupMessages.Show();
		}

		private void lblOne_2_Click(object sender, System.EventArgs e)
		{
			int_lblOne();
			lblOne_2.ForeColor=System.Drawing.Color.Firebrick;

			//Initilize Groups
			groupReceipientGroup.Show();
		}
		#endregion
		
		#region lblTwo

		private void int_lblTwo()
		{
			lblTwo_1.ForeColor=System.Drawing.Color.MediumBlue;
			lblTwo_2.ForeColor=System.Drawing.Color.MediumBlue;
			
			groupSales.Hide();
			groupService.Hide();
		}

		private void lblTwo_1_Click(object sender, System.EventArgs e)
		{
			int_lblTwo();
			lblTwo_1.ForeColor=System.Drawing.Color.Firebrick;
			//Initilize Groups
			groupSales.Show();
		}

		private void lblTwo_2_Click(object sender, System.EventArgs e)
		{
			int_lblTwo();
			lblTwo_2.ForeColor=System.Drawing.Color.Firebrick;
			groupService.Show();
			
		}
		#endregion

		#region lblThree

		private void int_lblThree()
		{
			lblThree_1.ForeColor=System.Drawing.Color.MediumBlue;
			lblThree_2.ForeColor=System.Drawing.Color.MediumBlue;
			lblThree_3.ForeColor=System.Drawing.Color.MediumBlue;
			
			groupTimesheet.Hide();
			groupLateness.Hide();
			groupOvertime.Hide();
		}

		private void lblThree_1_Click(object sender, System.EventArgs e)
		{
			int_lblThree();
			lblThree_1.ForeColor=System.Drawing.Color.Firebrick;
			groupTimesheet.Show();
		}

		private void lblThree_2_Click(object sender, System.EventArgs e)
		{
			int_lblThree();
			lblThree_2.ForeColor=System.Drawing.Color.Firebrick;
			groupOvertime.Show();
			
		}

		private void lblThree_3_Click(object sender, System.EventArgs e)
		{
			int_lblThree();
			lblThree_3.ForeColor=System.Drawing.Color.Firebrick;
			groupLateness.Show();

		}
		#endregion

		#region lblFour

		private void int_lblFour()
		{
			lblFour_1.ForeColor=System.Drawing.Color.MediumBlue;
			lblFour_2.ForeColor=System.Drawing.Color.MediumBlue;
			
			groupAppointment.Hide();
			groupContact.Hide();
		}

		private void lblFour_1_Click(object sender, System.EventArgs e)
		{
			int_lblFour();
			lblFour_1.ForeColor=System.Drawing.Color.Firebrick;

			groupAppointment.Show();
		}

		private void lblFour_2_Click(object sender, System.EventArgs e)
		{
			int_lblFour();
			lblFour_2.ForeColor=System.Drawing.Color.Firebrick;
			
			groupContact.Show();
		}
		#endregion

		#region lblSix

		private void int_lblSix()
		{
			lblSix_1.ForeColor=System.Drawing.Color.MediumBlue;
			lblSix_2.ForeColor=System.Drawing.Color.MediumBlue;
			
			groupLeave.Hide();
			groupLeaveRoster.Hide();
		}

		private void lblSix_1_Click(object sender, System.EventArgs e)
		{
			int_lblSix();
			lblSix_1.ForeColor=System.Drawing.Color.Firebrick;
			groupLeave.Show();
	
		}

		private void lblSix_2_Click(object sender, System.EventArgs e)
		{
			int_lblSix();
			lblSix_2.ForeColor=System.Drawing.Color.Firebrick;
			groupLeaveRoster.Show();
		}
		#endregion

		private void tabStaff_Click(object sender, System.EventArgs e)
		{
		
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			
			if (!employee.HasRight("AS_ADD_LEAVE"))
			{
				UI.ShowErrorMessage(this, "You don't have right to edit Leave.");
				return;
			}
			int nEmployeeID = ACMS.Convert.ToInt32(luedtLeaveEmployeeID.EditValue);
			int nYearID = ACMS.Convert.ToInt32(cbLeaveNYearID.EditValue)-1;
			decimal AdjustDay = ACMS.Convert.ToDecimal(txtLeaveAdjust.Text);
			myLeave.ManualUpdatePreviousBal(nEmployeeID,ACMS.Convert.ToInt32(cbLeaveNYearID.EditValue),AdjustDay);
			
				UI.ShowMessage(this, "Adjust leave days successfully.");
				RefreshLeave();
			
			}

		private void button1_Click_1(object sender, System.EventArgs e)
		{

			try
			{
				int nEmployeeID = ACMS.Convert.ToInt32(luedtLeaveEmployeeID.EditValue);			
				if (ACMS.Convert.ToDecimal(colLeaveBalanceNoOfDays.SummaryItem.SummaryValue.ToString()) >= ACMS.Convert.ToInt32(txtDaysConvert.Text))
				{
					myLeave.ConvertLeavetoTimeOff(nEmployeeID,ACMS.Convert.ToInt32(cbLeaveNYearID.EditValue),ACMS.Convert.ToInt32(txtDaysConvert.Text));

				}
				else 
				{
				UI.ShowMessage("You dont have enough days to convert to Time off");
				}
			}

			catch
			{
				UI.ShowErrorMessage(this, "Please Click the 'Inquiry' button before you convert Your leave.");
				
			}

		}

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ACMSStaff.To_Do_List.frmTodolist frm = new ACMS.ACMSStaff.To_Do_List.frmTodolist();
            frm.Show();
        }
		}

		
	}
	

