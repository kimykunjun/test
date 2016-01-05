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
        private ACMS.ACMSManager.Operation.frmMemberCardPhoto myMemberCardPhoto;
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
        //private ACMSLogic.Staff.Timesheet myTimesheet;
        //private ACMSLogic.Staff.Lateness myLateness;
        //private ACMSLogic.Staff.Leave myLeave;
		private DateTime startTime;
		/// <summary>
		/// Current display/use month for roster & leave
		/// </summary>		
		private DataRow myEmployeeInfo;		
		/// <summary>
		/// Don't not load CV before CV finish initialize
		/// </summary>
		private bool isFinishedCVInit;		
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
        internal DevExpress.XtraEditors.SimpleButton sbtnAppointmentVerifiedBy;
		internal DevExpress.XtraEditors.SimpleButton sbtnAppointmentEdit;
		internal DevExpress.XtraEditors.SimpleButton sbtnAppointmentNew;
        internal DevExpress.XtraGrid.Columns.GridColumn colVerifyAppt;
        internal DevExpress.XtraGrid.Columns.GridColumn colAppointmentID;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditUtilizationSelection;
		internal DevExpress.XtraGrid.Columns.GridColumn colAppointmentDate;
		internal DevExpress.XtraGrid.Columns.GridColumn colAppointmentStartDate;
		internal DevExpress.XtraGrid.Columns.GridColumn colAppointmentEndDate;
		internal DevExpress.XtraGrid.Columns.GridColumn colAppointmentOrganization;
		internal DevExpress.XtraGrid.Columns.GridColumn colAppointmentContact;
        internal DevExpress.XtraGrid.Columns.GridColumn colAppointmentMobileNo;
		internal DevExpress.XtraGrid.Columns.GridColumn colAppointmentRemarks;
        internal DevExpress.XtraGrid.Columns.GridColumn colAppointmentServedBy;
        internal DevExpress.XtraGrid.Columns.GridColumn colAppointmentStaffAssign;
        internal DevExpress.XtraGrid.Columns.GridColumn colAppointmentVerifiedBy;
		private DevExpress.XtraGrid.Columns.GridColumn colstrBranchCode;
		internal DevExpress.XtraEditors.SimpleButton sbtnContactDelete;
		internal DevExpress.XtraEditors.SimpleButton sbtnContactNew;
		internal DevExpress.XtraGrid.Columns.GridColumn colContactPerson;
        internal DevExpress.XtraGrid.Columns.GridColumn colStaffAssigned;
		internal DevExpress.XtraGrid.Columns.GridColumn colNRIC;
        internal DevExpress.XtraGrid.Columns.GridColumn colContactMobile;
		private DevExpress.XtraGrid.Columns.GridColumn colMediaSource;
		private DevExpress.XtraGrid.Columns.GridColumn colBranchCode;
		internal DevExpress.XtraEditors.SimpleButton sbtnContactEdit;								
		private DevExpress.XtraGrid.Columns.GridColumn colActionTakenByID;																		
		private DevExpress.XtraBars.BarButtonItem barButtonItem1;
		internal System.Windows.Forms.MenuItem MenuItemChangePassword;		
		internal System.Windows.Forms.MenuItem MenuItemBlockMembershipID;
		internal System.Windows.Forms.MenuItem MenuItemResetMembershipID;
		private DevExpress.XtraEditors.GroupControl groupControl12;
		internal DevExpress.XtraEditors.ComboBoxEdit cbAppointmentYear;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		internal DevExpress.XtraEditors.ComboBoxEdit cbAppointmentMonth;
		internal DevExpress.XtraEditors.SimpleButton sbtnAppointmentInquiry;						
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
		internal DevExpress.XtraGrid.Columns.GridColumn colReplyDate;
		internal DevExpress.XtraGrid.Columns.GridColumn colReplyEmployeeID;
		internal DevExpress.XtraGrid.Columns.GridColumn colReplyMessage;		
		private DevExpress.XtraEditors.LookUpEdit luedtCVSubmitter;
		private System.Windows.Forms.Label lblCVSubmitter;		
		private DevExpress.XtraEditors.LookUpEdit luedtMemoEmployeeID;
		internal System.Windows.Forms.Label lblMemoEmployeeID;        
		internal DevExpress.XtraTab.XtraTabPage tabStaffOne;
		internal DevExpress.XtraTab.XtraTabPage tabStaffTwo;        
		internal DevExpress.XtraTab.XtraTabPage tabStaffFour;
		internal DevExpress.XtraTab.XtraTabPage tabStaffFive;
        internal DevExpress.XtraTab.XtraTabPage tabStaffSeven;		
		private DevExpress.XtraEditors.SimpleButton lblOne_1;
		private DevExpress.XtraEditors.SimpleButton lblOne_2;
		private DevExpress.XtraEditors.SimpleButton lblTwo_1;
		private DevExpress.XtraEditors.SimpleButton lblTwo_2;
		private DevExpress.XtraEditors.SimpleButton lblThree_1;
		private DevExpress.XtraEditors.SimpleButton lblThree_2;
		private DevExpress.XtraEditors.SimpleButton lblThree_3;		
		private DevExpress.XtraEditors.SimpleButton lblFour_2;
		private DevExpress.XtraEditors.SimpleButton lblFour_1;
        private System.Windows.Forms.TextBox txtSearchLead;        				
        private System.Windows.Forms.Label lblSearchLead;        
        private PictureBox pbFileSelect;
        private TextEdit txtImagePath;
        private Label lblFileName;
        private PictureBox pbPreview;
        private PictureBox pbF3Select;
        private TextEdit txtFilePath3;
        private Label label39;
        private PictureBox pbF2Select;
        private TextEdit txtFilePath2;
        private Label label38;
        private PictureBox pbF1Select;
        private TextEdit txtFilePath1;
        private Label label28;
        private Panel panel1;
        private LinkLabel llFile3;
        private LinkLabel llFile2;
        private LinkLabel llFile1;
        private Label label40;
        private ToolTip toolTip1;
        private DevExpress.XtraGrid.Columns.GridColumn colRemarks;
        private DevExpress.XtraGrid.Columns.GridColumn colDOB;
        private DevExpress.XtraGrid.Columns.GridColumn colMediaSourceID;
        private DevExpress.XtraGrid.Columns.GridColumn colAppointmentStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colDNCExpiryDate;
        internal SimpleButton simpleButton1;
        private DevExpress.XtraGrid.Columns.GridColumn ColGender;
        internal DevExpress.XtraGrid.Columns.GridColumn colPhoneCall;
        internal DevExpress.XtraGrid.Columns.GridColumn colSMS;
        internal DevExpress.XtraGrid.Columns.GridColumn colEmail;
        internal DevExpress.XtraGrid.Columns.GridColumn colDNC;
        internal DevExpress.XtraGrid.Columns.GridColumn colDNCLog;
        private ComboBoxEdit cmbStatus;
        
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
		internal DevExpress.XtraEditors.GroupControl groupCustomerVoice;
        internal DevExpress.XtraEditors.GroupControl groupMobileApp;
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
            this.colDNC = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.barstaticCurrentLogin = new DevExpress.XtraBars.BarStaticItem();
            this.BarAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.tabStaff = new DevExpress.XtraTab.XtraTabControl();
            this.tabStaffFour = new DevExpress.XtraTab.XtraTabPage();
            this.lblFour_2 = new DevExpress.XtraEditors.SimpleButton();
            this.lblFour_1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupContact = new DevExpress.XtraEditors.GroupControl();
            this.groupContactEntry = new DevExpress.XtraEditors.GroupControl();
            this.cmbStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.lblSearchLead = new System.Windows.Forms.Label();
            this.txtSearchLead = new System.Windows.Forms.TextBox();
            this.sbtnContactEdit = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnContactDelete = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnContactNew = new DevExpress.XtraEditors.SimpleButton();
            this.gridctrContact = new DevExpress.XtraGrid.GridControl();
            this.gvContact = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhoneCall = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSMS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContactPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStaffAssigned = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNRIC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDOB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContactMobile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemarks = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMediaSourceID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAppointmentStatus = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.sbtnAppointmentVerifiedBy = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnAppointmentEdit = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnAppointmentNew = new DevExpress.XtraEditors.SimpleButton();
            this.gridctrAppointment = new DevExpress.XtraGrid.GridControl();
            this.gvAppointment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVerifyAppt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEditUtilizationSelection = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colAppointmentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAppointmentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAppointmentStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAppointmentEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAppointmentOrganization = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAppointmentContact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAppointmentMobileNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAppointmentRemarks = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAppointmentStaffAssign = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAppointmentServedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAppointmentVerifiedBy = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.groupMessagesMemoInfo = new DevExpress.XtraEditors.GroupControl();
            this.GroupControl8 = new DevExpress.XtraEditors.GroupControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label40 = new System.Windows.Forms.Label();
            this.llFile3 = new System.Windows.Forms.LinkLabel();
            this.llFile2 = new System.Windows.Forms.LinkLabel();
            this.llFile1 = new System.Windows.Forms.LinkLabel();
            this.pbF3Select = new System.Windows.Forms.PictureBox();
            this.txtFilePath3 = new DevExpress.XtraEditors.TextEdit();
            this.label39 = new System.Windows.Forms.Label();
            this.pbF2Select = new System.Windows.Forms.PictureBox();
            this.txtFilePath2 = new DevExpress.XtraEditors.TextEdit();
            this.label38 = new System.Windows.Forms.Label();
            this.pbF1Select = new System.Windows.Forms.PictureBox();
            this.txtFilePath1 = new DevExpress.XtraEditors.TextEdit();
            this.label28 = new System.Windows.Forms.Label();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.pbFileSelect = new System.Windows.Forms.PictureBox();
            this.txtImagePath = new DevExpress.XtraEditors.TextEdit();
            this.lblFileName = new System.Windows.Forms.Label();
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
            this.tabStaffSeven = new DevExpress.XtraTab.XtraTabPage();
            this.groupMobileApp = new DevExpress.XtraEditors.GroupControl();
            this.lblThree_3 = new DevExpress.XtraEditors.SimpleButton();
            this.lblThree_1 = new DevExpress.XtraEditors.SimpleButton();
            this.lblThree_2 = new DevExpress.XtraEditors.SimpleButton();
            this.colDNCExpiryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDNCLog = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColGender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMediaSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstrBranchCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBranchCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabStaff)).BeginInit();
            this.tabStaff.SuspendLayout();
            this.tabStaffFour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupContact)).BeginInit();
            this.groupContact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupContactEntry)).BeginInit();
            this.groupContactEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridctrContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvContact)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditUtilizationSelection)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.groupMessagesMemoInfo)).BeginInit();
            this.groupMessagesMemoInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl8)).BeginInit();
            this.GroupControl8.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbF3Select)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilePath3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbF2Select)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilePath2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbF1Select)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilePath1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFileSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImagePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoedtMessage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupMessagesReceipient)).BeginInit();
            this.groupMessagesReceipient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl6)).BeginInit();
            this.GroupControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbMemoReceipient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gctrReceipient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReceipient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupMessagesFollowUpAction)).BeginInit();
            this.groupMessagesFollowUpAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl4)).BeginInit();
            this.GroupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctrReplies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReplies)).BeginInit();
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
            this.tabStaffSeven.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupMobileApp)).BeginInit();
            this.SuspendLayout();
            // 
            // colDNC
            // 
            this.colDNC.Caption = "DNC";
            this.colDNC.FieldName = "fDNC";
            this.colDNC.Name = "colDNC";
            this.colDNC.Visible = true;
            this.colDNC.VisibleIndex = 4;
            this.colDNC.Width = 35;
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
            this.MenuItem10.Visible = false;
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
            this.barButtonItem1,
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
            // tabStaff
            // 
            this.tabStaff.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabStaff.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabStaff.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tabStaff.Location = new System.Drawing.Point(0, 45);
            this.tabStaff.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tabStaff.Name = "tabStaff";
            this.tabStaff.PaintStyleName = "Skin";
            this.tabStaff.SelectedTabPage = this.tabStaffFour;
            this.tabStaff.Size = new System.Drawing.Size(1016, 648);
            this.tabStaff.TabIndex = 0;
            this.tabStaff.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabStaffOne,
            this.tabStaffTwo,
            this.tabStaffFour,
            this.tabStaffFive,
            this.tabStaffSeven});
            this.tabStaff.VisibleChanged += new System.EventHandler(this.tabStaff_VisibleChanged);
            this.tabStaff.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabStaff_SelectedPageChanged);
            this.tabStaff.Click += new System.EventHandler(this.tabStaff_Click);
            // 
            // tabStaffFour
            // 
            this.tabStaffFour.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabStaffFour.Appearance.Header.Options.UseFont = true;
            this.tabStaffFour.Controls.Add(this.lblFour_2);
            this.tabStaffFour.Controls.Add(this.lblFour_1);
            this.tabStaffFour.Controls.Add(this.groupContact);
            this.tabStaffFour.Controls.Add(this.groupAppointment);
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
            this.lblFour_2.Text = "New Lead Contact";
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
            // groupContact
            // 
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
            this.groupContactEntry.Controls.Add(this.cmbStatus);
            this.groupContactEntry.Controls.Add(this.simpleButton1);
            this.groupContactEntry.Controls.Add(this.lblSearchLead);
            this.groupContactEntry.Controls.Add(this.txtSearchLead);
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
            // cmbStatus
            // 
            this.cmbStatus.EditValue = "";
            this.cmbStatus.Location = new System.Drawing.Point(745, 35);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbStatus.Properties.Items.AddRange(new object[] {
            "Safe to Contact",
            "Waiting List",
            "Do Not Contact",
            "Closed"});
            this.cmbStatus.Size = new System.Drawing.Size(136, 20);
            this.cmbStatus.TabIndex = 16;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButton1.Location = new System.Drawing.Point(887, 33);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(87, 24);
            this.simpleButton1.TabIndex = 7;
            this.simpleButton1.Text = "Search";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click_1);
            // 
            // lblSearchLead
            // 
            this.lblSearchLead.AutoSize = true;
            this.lblSearchLead.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchLead.Location = new System.Drawing.Point(477, 35);
            this.lblSearchLead.Name = "lblSearchLead";
            this.lblSearchLead.Size = new System.Drawing.Size(137, 16);
            this.lblSearchLead.TabIndex = 6;
            this.lblSearchLead.Text = "Name / Mobile No.";
            this.lblSearchLead.Click += new System.EventHandler(this.lblmnuCustomerVoiceCVDetails_Click);
            // 
            // txtSearchLead
            // 
            this.txtSearchLead.Location = new System.Drawing.Point(617, 35);
            this.txtSearchLead.Name = "txtSearchLead";
            this.txtSearchLead.Size = new System.Drawing.Size(126, 20);
            this.txtSearchLead.TabIndex = 6;
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
            this.colDateTime,
            this.colPhoneCall,
            this.colSMS,
            this.colContactPerson,
            this.colStaffAssigned,
            this.colNRIC,
            this.colDOB,
            this.colContactMobile,
            this.colRemarks,
            this.colMediaSourceID,
            this.colAppointmentStatus});
            this.gvContact.GridControl = this.gridctrContact;
            this.gvContact.Name = "gvContact";
            this.gvContact.OptionsBehavior.AllowIncrementalSearch = true;
            this.gvContact.OptionsBehavior.Editable = false;
            this.gvContact.OptionsCustomization.AllowFilter = false;
            this.gvContact.OptionsView.ShowGroupPanel = false;
            this.gvContact.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvContact_RowStyle);
            // 
            // colDateTime
            // 
            this.colDateTime.Caption = "Date";
            this.colDateTime.FieldName = "dDateTime";
            this.colDateTime.Name = "colDateTime";
            this.colDateTime.Visible = true;
            this.colDateTime.VisibleIndex = 0;
            this.colDateTime.Width = 68;
            // 
            // colPhoneCall
            // 
            this.colPhoneCall.Caption = "Call";
            this.colPhoneCall.FieldName = "fPhoneCall";
            this.colPhoneCall.Name = "colPhoneCall";
            this.colPhoneCall.Visible = true;
            this.colPhoneCall.VisibleIndex = 1;
            this.colPhoneCall.Width = 33;
            // 
            // colSMS
            // 
            this.colSMS.Caption = "SMS";
            this.colSMS.FieldName = "fSMS";
            this.colSMS.Name = "colSMS";
            this.colSMS.Visible = true;
            this.colSMS.VisibleIndex = 2;
            this.colSMS.Width = 33;
            // 
            // colContactPerson
            // 
            this.colContactPerson.Caption = "Contact Person";
            this.colContactPerson.FieldName = "strContactName";
            this.colContactPerson.Name = "colContactPerson";
            this.colContactPerson.Visible = true;
            this.colContactPerson.VisibleIndex = 3;
            this.colContactPerson.Width = 112;
            // 
            // colStaffAssigned
            // 
            this.colStaffAssigned.Caption = "Staff Assigned";
            this.colStaffAssigned.FieldName = "strEmployeeName";
            this.colStaffAssigned.Name = "colStaffAssigned";
            this.colStaffAssigned.Visible = true;
            this.colStaffAssigned.VisibleIndex = 4;
            this.colStaffAssigned.Width = 112;
            // 
            // colNRIC
            // 
            this.colNRIC.Caption = "NRICFIN";
            this.colNRIC.FieldName = "strNRICFIN";
            this.colNRIC.Name = "colNRIC";
            this.colNRIC.Width = 89;
            // 
            // colDOB
            // 
            this.colDOB.Caption = "Date-of-Birth";
            this.colDOB.FieldName = "dtDOB";
            this.colDOB.Name = "colDOB";
            this.colDOB.Width = 90;
            // 
            // colContactMobile
            // 
            this.colContactMobile.Caption = "Mobile No.";
            this.colContactMobile.FieldName = "strMobileNo";
            this.colContactMobile.Name = "colContactMobile";
            this.colContactMobile.Visible = true;
            this.colContactMobile.VisibleIndex = 5;
            this.colContactMobile.Width = 94;
            // 
            // colRemarks
            // 
            this.colRemarks.Caption = "Remarks.";
            this.colRemarks.FieldName = "strRemarks";
            this.colRemarks.Name = "colRemarks";
            this.colRemarks.OptionsColumn.FixedWidth = true;
            this.colRemarks.Visible = true;
            this.colRemarks.VisibleIndex = 6;
            this.colRemarks.Width = 200;
            // 
            // colMediaSourceID
            // 
            this.colMediaSourceID.Caption = "MediaSourceID";
            this.colMediaSourceID.FieldName = "nMediaSourceID";
            this.colMediaSourceID.Name = "colMediaSourceID";
            this.colMediaSourceID.Width = 20;
            // 
            // colAppointmentStatus
            // 
            this.colAppointmentStatus.Caption = "Appt. Status";
            this.colAppointmentStatus.FieldName = "strAppointmentStatus";
            this.colAppointmentStatus.Name = "colAppointmentStatus";
            this.colAppointmentStatus.Visible = true;
            this.colAppointmentStatus.VisibleIndex = 7;
            this.colAppointmentStatus.Width = 50;
            // 
            // groupAppointment
            // 
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
            this.groupAppointmentEntry.Controls.Add(this.groupControl12);
            this.groupAppointmentEntry.Controls.Add(this.sbtnAppointmentDelete);
            this.groupAppointmentEntry.Controls.Add(this.sbtnAppointmentPrint);
            this.groupAppointmentEntry.Controls.Add(this.sbtnAppointmentVerifiedBy);
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
            this.groupAppointmentEntry.Paint += new System.Windows.Forms.PaintEventHandler(this.groupAppointmentEntry_Paint);
            // 
            // groupControl12
            // 
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
            // sbtnAppointmentVerifiedBy
            // 
            this.sbtnAppointmentVerifiedBy.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnAppointmentVerifiedBy.Appearance.Options.UseFont = true;
            this.sbtnAppointmentVerifiedBy.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnAppointmentVerifiedBy.Location = new System.Drawing.Point(664, 48);
            this.sbtnAppointmentVerifiedBy.Name = "sbtnAppointmentVerifiedBy";
            this.sbtnAppointmentVerifiedBy.Size = new System.Drawing.Size(72, 20);
            this.sbtnAppointmentVerifiedBy.TabIndex = 3;
            this.sbtnAppointmentVerifiedBy.Text = "Verify";
            this.sbtnAppointmentVerifiedBy.Click += new System.EventHandler(this.sbtnAppointmentVerifiedBy_Click);
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
            this.gridctrAppointment.Location = new System.Drawing.Point(2, 86);
            this.gridctrAppointment.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridctrAppointment.MainView = this.gvAppointment;
            this.gridctrAppointment.Name = "gridctrAppointment";
            this.gridctrAppointment.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEditUtilizationSelection});
            this.gridctrAppointment.Size = new System.Drawing.Size(988, 488);
            this.gridctrAppointment.TabIndex = 4;
            this.gridctrAppointment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAppointment});
            // 
            // gvAppointment
            // 
            this.gvAppointment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVerifyAppt,
            this.colAppointmentID,
            this.colAppointmentDate,
            this.colAppointmentStartDate,
            this.colAppointmentEndDate,
            this.colAppointmentOrganization,
            this.colAppointmentContact,
            this.colAppointmentMobileNo,
            this.colAppointmentRemarks,
            this.colAppointmentStaffAssign,
            this.colAppointmentServedBy,
            this.colAppointmentVerifiedBy});
            this.gvAppointment.GridControl = this.gridctrAppointment;
            this.gvAppointment.Name = "gvAppointment";
            this.gvAppointment.OptionsView.ShowGroupPanel = false;
            this.gvAppointment.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colAppointmentDate, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // colVerifyAppt
            // 
            this.colVerifyAppt.Caption = "Utl";
            this.colVerifyAppt.ColumnEdit = this.repositoryItemCheckEditUtilizationSelection;
            this.colVerifyAppt.FieldName = "UtlCheck";
            this.colVerifyAppt.Name = "colVerifyAppt";
            this.colVerifyAppt.OptionsColumn.ShowCaption = false;
            this.colVerifyAppt.Visible = true;
            this.colVerifyAppt.VisibleIndex = 0;
            this.colVerifyAppt.Width = 25;
            // 
            // repositoryItemCheckEditUtilizationSelection
            // 
            this.repositoryItemCheckEditUtilizationSelection.AutoHeight = false;
            this.repositoryItemCheckEditUtilizationSelection.Name = "repositoryItemCheckEditUtilizationSelection";
            this.repositoryItemCheckEditUtilizationSelection.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // colAppointmentID
            // 
            this.colAppointmentID.FieldName = "nAppointmentID";
            this.colAppointmentID.Name = "colAppointmentID";
            this.colAppointmentID.OptionsColumn.ShowCaption = false;
            this.colAppointmentID.Visible = true;
            this.colAppointmentID.VisibleIndex = 1;
            this.colAppointmentID.Width = 25;
            // 
            // colAppointmentDate
            // 
            this.colAppointmentDate.Caption = "Date";
            this.colAppointmentDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colAppointmentDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colAppointmentDate.FieldName = "dtDate";
            this.colAppointmentDate.Name = "colAppointmentDate";
            this.colAppointmentDate.OptionsColumn.AllowEdit = false;
            this.colAppointmentDate.OptionsColumn.AllowFocus = false;
            this.colAppointmentDate.OptionsFilter.AllowFilter = false;
            this.colAppointmentDate.Visible = true;
            this.colAppointmentDate.VisibleIndex = 2;
            this.colAppointmentDate.Width = 80;
            // 
            // colAppointmentStartDate
            // 
            this.colAppointmentStartDate.Caption = "Start Time";
            this.colAppointmentStartDate.DisplayFormat.FormatString = "hh:mm tt";
            this.colAppointmentStartDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colAppointmentStartDate.FieldName = "dtStartTime";
            this.colAppointmentStartDate.Name = "colAppointmentStartDate";
            this.colAppointmentStartDate.OptionsColumn.AllowEdit = false;
            this.colAppointmentStartDate.OptionsColumn.AllowFocus = false;
            this.colAppointmentStartDate.OptionsFilter.AllowFilter = false;
            this.colAppointmentStartDate.Visible = true;
            this.colAppointmentStartDate.VisibleIndex = 3;
            this.colAppointmentStartDate.Width = 70;
            // 
            // colAppointmentEndDate
            // 
            this.colAppointmentEndDate.Caption = "End Time";
            this.colAppointmentEndDate.DisplayFormat.FormatString = "hh:mm tt";
            this.colAppointmentEndDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colAppointmentEndDate.FieldName = "dtEndTime";
            this.colAppointmentEndDate.Name = "colAppointmentEndDate";
            this.colAppointmentEndDate.OptionsColumn.AllowEdit = false;
            this.colAppointmentEndDate.OptionsColumn.AllowFocus = false;
            this.colAppointmentEndDate.OptionsFilter.AllowFilter = false;
            this.colAppointmentEndDate.Visible = true;
            this.colAppointmentEndDate.VisibleIndex = 4;
            this.colAppointmentEndDate.Width = 70;
            // 
            // colAppointmentOrganization
            // 
            this.colAppointmentOrganization.Caption = "Organization / Place of Appointment";
            this.colAppointmentOrganization.FieldName = "strOrganization";
            this.colAppointmentOrganization.Name = "colAppointmentOrganization";
            this.colAppointmentOrganization.Width = 215;
            // 
            // colAppointmentContact
            // 
            this.colAppointmentContact.Caption = "Contact";
            this.colAppointmentContact.FieldName = "strContactName";
            this.colAppointmentContact.Name = "colAppointmentContact";
            this.colAppointmentContact.OptionsColumn.AllowEdit = false;
            this.colAppointmentContact.OptionsColumn.AllowFocus = false;
            this.colAppointmentContact.OptionsFilter.AllowFilter = false;
            this.colAppointmentContact.Visible = true;
            this.colAppointmentContact.VisibleIndex = 5;
            this.colAppointmentContact.Width = 140;
            // 
            // colAppointmentMobileNo
            // 
            this.colAppointmentMobileNo.Caption = "Mobile No";
            this.colAppointmentMobileNo.FieldName = "strMobileNo";
            this.colAppointmentMobileNo.Name = "colAppointmentMobileNo";
            this.colAppointmentMobileNo.OptionsColumn.AllowEdit = false;
            this.colAppointmentMobileNo.OptionsColumn.AllowFocus = false;
            this.colAppointmentMobileNo.OptionsFilter.AllowFilter = false;
            this.colAppointmentMobileNo.Visible = true;
            this.colAppointmentMobileNo.VisibleIndex = 6;
            // 
            // colAppointmentRemarks
            // 
            this.colAppointmentRemarks.Caption = "Remarks";
            this.colAppointmentRemarks.FieldName = "strRemarks";
            this.colAppointmentRemarks.Name = "colAppointmentRemarks";
            this.colAppointmentRemarks.OptionsColumn.AllowEdit = false;
            this.colAppointmentRemarks.OptionsColumn.AllowFocus = false;
            this.colAppointmentRemarks.OptionsFilter.AllowFilter = false;
            this.colAppointmentRemarks.Visible = true;
            this.colAppointmentRemarks.VisibleIndex = 7;
            this.colAppointmentRemarks.Width = 240;
            // 
            // colAppointmentStaffAssign
            // 
            this.colAppointmentStaffAssign.Caption = "Staff Assigned";
            this.colAppointmentStaffAssign.FieldName = "strStaffAssign";
            this.colAppointmentStaffAssign.Name = "colAppointmentStaffAssign";
            this.colAppointmentStaffAssign.OptionsColumn.AllowEdit = false;
            this.colAppointmentStaffAssign.OptionsColumn.AllowFocus = false;
            this.colAppointmentStaffAssign.OptionsFilter.AllowFilter = false;
            this.colAppointmentStaffAssign.Visible = true;
            this.colAppointmentStaffAssign.VisibleIndex = 8;
            this.colAppointmentStaffAssign.Width = 120;
            // 
            // colAppointmentServedBy
            // 
            this.colAppointmentServedBy.Caption = "Served By";
            this.colAppointmentServedBy.FieldName = "strServedBy";
            this.colAppointmentServedBy.Name = "colAppointmentServedBy";
            this.colAppointmentServedBy.OptionsColumn.AllowEdit = false;
            this.colAppointmentServedBy.OptionsColumn.AllowFocus = false;
            this.colAppointmentServedBy.OptionsFilter.AllowFilter = false;
            this.colAppointmentServedBy.Visible = true;
            this.colAppointmentServedBy.VisibleIndex = 9;
            this.colAppointmentServedBy.Width = 120;
            // 
            // colAppointmentVerifiedBy
            // 
            this.colAppointmentVerifiedBy.Caption = "Verified By";
            this.colAppointmentVerifiedBy.FieldName = "strVerifiedBy";
            this.colAppointmentVerifiedBy.Name = "colAppointmentVerifiedBy";
            this.colAppointmentVerifiedBy.OptionsColumn.AllowEdit = false;
            this.colAppointmentVerifiedBy.OptionsColumn.AllowFocus = false;
            this.colAppointmentVerifiedBy.OptionsFilter.AllowFilter = false;
            this.colAppointmentVerifiedBy.Visible = true;
            this.colAppointmentVerifiedBy.VisibleIndex = 10;
            this.colAppointmentVerifiedBy.Width = 120;
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
            this.groupMessages.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupMessages.Controls.Add(this.lblmnuMessagesReceipient);
            this.groupMessages.Controls.Add(this.lblmnuMessagesFollowUpAction);
            this.groupMessages.Controls.Add(this.lblmnuMessagesMemoInfo);
            this.groupMessages.Controls.Add(this.groupMessagesEntry);
            this.groupMessages.Controls.Add(this.groupMessagesMemoInfo);
            this.groupMessages.Controls.Add(this.groupMessagesReceipient);
            this.groupMessages.Controls.Add(this.groupMessagesFollowUpAction);
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
            this.gctrMemo.Click += new System.EventHandler(this.gctrMemo_Click);
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
            // groupMessagesMemoInfo
            // 
            this.groupMessagesMemoInfo.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupMessagesMemoInfo.Appearance.Options.UseBackColor = true;
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
            this.GroupControl8.Controls.Add(this.panel1);
            this.GroupControl8.Controls.Add(this.pbF3Select);
            this.GroupControl8.Controls.Add(this.txtFilePath3);
            this.GroupControl8.Controls.Add(this.label39);
            this.GroupControl8.Controls.Add(this.pbF2Select);
            this.GroupControl8.Controls.Add(this.txtFilePath2);
            this.GroupControl8.Controls.Add(this.label38);
            this.GroupControl8.Controls.Add(this.pbF1Select);
            this.GroupControl8.Controls.Add(this.txtFilePath1);
            this.GroupControl8.Controls.Add(this.label28);
            this.GroupControl8.Controls.Add(this.pbPreview);
            this.GroupControl8.Controls.Add(this.pbFileSelect);
            this.GroupControl8.Controls.Add(this.txtImagePath);
            this.GroupControl8.Controls.Add(this.lblFileName);
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
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label40);
            this.panel1.Controls.Add(this.llFile3);
            this.panel1.Controls.Add(this.llFile2);
            this.panel1.Controls.Add(this.llFile1);
            this.panel1.Location = new System.Drawing.Point(810, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 135);
            this.panel1.TabIndex = 33;
            // 
            // label40
            // 
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(3, 3);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(125, 18);
            this.label40.TabIndex = 36;
            this.label40.Text = "Attached Files:";
            // 
            // llFile3
            // 
            this.llFile3.AutoSize = true;
            this.llFile3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llFile3.Location = new System.Drawing.Point(3, 90);
            this.llFile3.Name = "llFile3";
            this.llFile3.Size = new System.Drawing.Size(29, 13);
            this.llFile3.TabIndex = 35;
            this.llFile3.TabStop = true;
            this.llFile3.Text = "File3";
            this.llFile3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llFile3_LinkClicked);
            // 
            // llFile2
            // 
            this.llFile2.AutoSize = true;
            this.llFile2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llFile2.Location = new System.Drawing.Point(3, 59);
            this.llFile2.Name = "llFile2";
            this.llFile2.Size = new System.Drawing.Size(29, 13);
            this.llFile2.TabIndex = 34;
            this.llFile2.TabStop = true;
            this.llFile2.Text = "File2";
            this.llFile2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llFile2_LinkClicked);
            // 
            // llFile1
            // 
            this.llFile1.AutoSize = true;
            this.llFile1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llFile1.Location = new System.Drawing.Point(3, 29);
            this.llFile1.Name = "llFile1";
            this.llFile1.Size = new System.Drawing.Size(29, 13);
            this.llFile1.TabIndex = 33;
            this.llFile1.TabStop = true;
            this.llFile1.Text = "File1";
            this.llFile1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llFile1_LinkClicked);
            // 
            // pbF3Select
            // 
            this.pbF3Select.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbF3Select.ErrorImage = global::ACMS.Properties.Resources.open_file_icon;
            this.pbF3Select.Image = global::ACMS.Properties.Resources.open_file_icon;
            this.pbF3Select.InitialImage = global::ACMS.Properties.Resources.open_file_icon;
            this.pbF3Select.Location = new System.Drawing.Point(811, 182);
            this.pbF3Select.Name = "pbF3Select";
            this.pbF3Select.Size = new System.Drawing.Size(20, 20);
            this.pbF3Select.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbF3Select.TabIndex = 29;
            this.pbF3Select.TabStop = false;
            this.pbF3Select.Click += new System.EventHandler(this.pbF3Select_Click);
            // 
            // txtFilePath3
            // 
            this.txtFilePath3.EditValue = "";
            this.txtFilePath3.Location = new System.Drawing.Point(504, 183);
            this.txtFilePath3.Name = "txtFilePath3";
            this.txtFilePath3.Properties.MaxLength = 255;
            this.txtFilePath3.Properties.ReadOnly = true;
            this.txtFilePath3.Size = new System.Drawing.Size(301, 20);
            this.txtFilePath3.TabIndex = 27;
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(451, 184);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(91, 18);
            this.label39.TabIndex = 28;
            this.label39.Text = "File 3:";
            // 
            // pbF2Select
            // 
            this.pbF2Select.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbF2Select.ErrorImage = global::ACMS.Properties.Resources.open_file_icon;
            this.pbF2Select.Image = global::ACMS.Properties.Resources.open_file_icon;
            this.pbF2Select.InitialImage = global::ACMS.Properties.Resources.open_file_icon;
            this.pbF2Select.Location = new System.Drawing.Point(413, 181);
            this.pbF2Select.Name = "pbF2Select";
            this.pbF2Select.Size = new System.Drawing.Size(20, 20);
            this.pbF2Select.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbF2Select.TabIndex = 26;
            this.pbF2Select.TabStop = false;
            this.pbF2Select.Click += new System.EventHandler(this.pbF2Select_Click);
            // 
            // txtFilePath2
            // 
            this.txtFilePath2.EditValue = "";
            this.txtFilePath2.Location = new System.Drawing.Point(106, 182);
            this.txtFilePath2.Name = "txtFilePath2";
            this.txtFilePath2.Properties.MaxLength = 255;
            this.txtFilePath2.Properties.ReadOnly = true;
            this.txtFilePath2.Size = new System.Drawing.Size(301, 20);
            this.txtFilePath2.TabIndex = 24;
            // 
            // label38
            // 
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(18, 183);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(91, 18);
            this.label38.TabIndex = 25;
            this.label38.Text = "File 2:";
            // 
            // pbF1Select
            // 
            this.pbF1Select.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbF1Select.ErrorImage = global::ACMS.Properties.Resources.open_file_icon;
            this.pbF1Select.Image = global::ACMS.Properties.Resources.open_file_icon;
            this.pbF1Select.InitialImage = global::ACMS.Properties.Resources.open_file_icon;
            this.pbF1Select.Location = new System.Drawing.Point(811, 156);
            this.pbF1Select.Name = "pbF1Select";
            this.pbF1Select.Size = new System.Drawing.Size(20, 20);
            this.pbF1Select.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbF1Select.TabIndex = 23;
            this.pbF1Select.TabStop = false;
            this.pbF1Select.Click += new System.EventHandler(this.pbF1Select_Click);
            // 
            // txtFilePath1
            // 
            this.txtFilePath1.EditValue = "";
            this.txtFilePath1.Location = new System.Drawing.Point(504, 157);
            this.txtFilePath1.Name = "txtFilePath1";
            this.txtFilePath1.Properties.MaxLength = 255;
            this.txtFilePath1.Properties.ReadOnly = true;
            this.txtFilePath1.Size = new System.Drawing.Size(301, 20);
            this.txtFilePath1.TabIndex = 21;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(451, 158);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(91, 18);
            this.label28.TabIndex = 22;
            this.label28.Text = "File 1:";
            // 
            // pbPreview
            // 
            this.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPreview.Location = new System.Drawing.Point(669, 16);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(135, 135);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPreview.TabIndex = 20;
            this.pbPreview.TabStop = false;
            this.pbPreview.Click += new System.EventHandler(this.pbPreview_Click);
            // 
            // pbFileSelect
            // 
            this.pbFileSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbFileSelect.ErrorImage = global::ACMS.Properties.Resources.open_file_icon;
            this.pbFileSelect.Image = global::ACMS.Properties.Resources.open_file_icon;
            this.pbFileSelect.InitialImage = global::ACMS.Properties.Resources.open_file_icon;
            this.pbFileSelect.Location = new System.Drawing.Point(413, 156);
            this.pbFileSelect.Name = "pbFileSelect";
            this.pbFileSelect.Size = new System.Drawing.Size(20, 20);
            this.pbFileSelect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFileSelect.TabIndex = 19;
            this.pbFileSelect.TabStop = false;
            this.pbFileSelect.Click += new System.EventHandler(this.pbFileSelect_Click);
            // 
            // txtImagePath
            // 
            this.txtImagePath.EditValue = "";
            this.txtImagePath.Location = new System.Drawing.Point(106, 157);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Properties.MaxLength = 255;
            this.txtImagePath.Properties.ReadOnly = true;
            this.txtImagePath.Size = new System.Drawing.Size(301, 20);
            this.txtImagePath.TabIndex = 17;
            // 
            // lblFileName
            // 
            this.lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.Location = new System.Drawing.Point(18, 158);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(91, 18);
            this.lblFileName.TabIndex = 18;
            this.lblFileName.Text = "Picture File:";
            // 
            // sbtnUpdate
            // 
            this.sbtnUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbtnUpdate.Appearance.Options.UseFont = true;
            this.sbtnUpdate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnUpdate.Location = new System.Drawing.Point(852, 181);
            this.sbtnUpdate.Name = "sbtnUpdate";
            this.sbtnUpdate.Size = new System.Drawing.Size(72, 20);
            this.sbtnUpdate.TabIndex = 1;
            this.sbtnUpdate.Text = "Update";
            this.sbtnUpdate.Click += new System.EventHandler(this.sbtnUpdate_Click);
            // 
            // memoedtMessage
            // 
            this.memoedtMessage.EditValue = "";
            this.memoedtMessage.Location = new System.Drawing.Point(106, 16);
            this.memoedtMessage.Name = "memoedtMessage";
            this.memoedtMessage.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memoedtMessage.Properties.Appearance.Options.UseFont = true;
            this.memoedtMessage.Properties.MaxLength = 1000;
            this.memoedtMessage.Size = new System.Drawing.Size(560, 135);
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
            // groupMessagesFollowUpAction
            // 
            this.groupMessagesFollowUpAction.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.groupMessagesFollowUpAction.Appearance.Options.UseBackColor = true;
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
            // groupReceipientGroup
            // 
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
            this.tabStaffTwo.Controls.Add(this.lblTwo_1);
            this.tabStaffTwo.Controls.Add(this.lblTwo_2);
            this.tabStaffTwo.Controls.Add(this.groupSales);
            this.tabStaffTwo.Controls.Add(this.groupService);
            this.tabStaffTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabStaffTwo.Name = "tabStaffTwo";
            this.tabStaffTwo.PageVisible = false;
            this.tabStaffTwo.Size = new System.Drawing.Size(1007, 612);
            this.tabStaffTwo.Text = "Commission";
            this.tabStaffTwo.VisibleChanged += new System.EventHandler(this.tabStaffCommision_VisibleChanged);
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
            "IPL Package Sales",
            "Holistic Fitness",
            "Holistic Spa"});
            this.cbSalesType.Properties.PopupSizeable = true;
            this.cbSalesType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbSalesType.Size = new System.Drawing.Size(168, 20);
            this.cbSalesType.TabIndex = 0;
            // 
            // gctrSales
            // 
            this.gctrSales.Dock = System.Windows.Forms.DockStyle.Bottom;
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
            // groupService
            // 
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
            // tabStaffSeven
            // 
            this.tabStaffSeven.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabStaffSeven.Appearance.Header.Options.UseFont = true;
            this.tabStaffSeven.Controls.Add(this.groupMobileApp);
            this.tabStaffSeven.Name = "tabStaffSeven";
            this.tabStaffSeven.PageVisible = false;
            this.tabStaffSeven.Size = new System.Drawing.Size(1007, 612);
            this.tabStaffSeven.Text = "Mobile App";
            this.tabStaffSeven.VisibleChanged += new System.EventHandler(this.tabStaffMobileApp_VisibleChanged);
            // 
            // groupMobileApp
            // 
            this.groupMobileApp.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupMobileApp.Location = new System.Drawing.Point(0, 8);
            this.groupMobileApp.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupMobileApp.Name = "groupMobileApp";
            this.groupMobileApp.Size = new System.Drawing.Size(1007, 584);
            this.groupMobileApp.TabIndex = 11;
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
            // colDNCExpiryDate
            // 
            this.colDNCExpiryDate.Caption = "Exp.Date";
            this.colDNCExpiryDate.FieldName = "dtDNCExpiryDate";
            this.colDNCExpiryDate.Name = "colDNCExpiryDate";
            this.colDNCExpiryDate.Visible = true;
            this.colDNCExpiryDate.VisibleIndex = 5;
            this.colDNCExpiryDate.Width = 66;
            // 
            // colEmail
            // 
            this.colEmail.Caption = "Email";
            this.colEmail.FieldName = "fEmail";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 3;
            this.colEmail.Width = 37;
            // 
            // colDNCLog
            // 
            this.colDNCLog.Caption = "Log";
            this.colDNCLog.FieldName = "DNCReplyStatus";
            this.colDNCLog.Name = "colDNCLog";
            this.colDNCLog.Visible = true;
            this.colDNCLog.VisibleIndex = 6;
            this.colDNCLog.Width = 35;
            // 
            // ColGender
            // 
            this.ColGender.Caption = "Sex";
            this.ColGender.FieldName = "Gender";
            this.ColGender.Name = "ColGender";
            this.ColGender.Visible = true;
            this.ColGender.VisibleIndex = 10;
            this.ColGender.Width = 32;
            // 
            // colMediaSource
            // 
            this.colMediaSource.Caption = "Media Source";
            this.colMediaSource.FieldName = "strMediaSource";
            this.colMediaSource.Name = "colMediaSource";
            this.colMediaSource.Visible = true;
            this.colMediaSource.VisibleIndex = 11;
            this.colMediaSource.Width = 125;
            // 
            // colstrBranchCode
            // 
            this.colstrBranchCode.Caption = "BranchCode";
            this.colstrBranchCode.FieldName = "strBranchCode";
            this.colstrBranchCode.Name = "colstrBranchCode";
            this.colstrBranchCode.Visible = true;
            this.colstrBranchCode.VisibleIndex = 5;
            // 
            // colBranchCode
            // 
            this.colBranchCode.Caption = "Br.";
            this.colBranchCode.FieldName = "strBranchCode";
            this.colBranchCode.Name = "colBranchCode";
            this.colBranchCode.Visible = true;
            this.colBranchCode.VisibleIndex = 11;
            this.colBranchCode.Width = 32;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmStaff
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1016, 693);
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
            this.tabStaffFour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupContact)).EndInit();
            this.groupContact.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupContactEntry)).EndInit();
            this.groupContactEntry.ResumeLayout(false);
            this.groupContactEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridctrContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvContact)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditUtilizationSelection)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.groupMessagesMemoInfo)).EndInit();
            this.groupMessagesMemoInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl8)).EndInit();
            this.GroupControl8.ResumeLayout(false);
            this.GroupControl8.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbF3Select)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilePath3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbF2Select)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilePath2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbF1Select)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilePath1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFileSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImagePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoedtMessage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupMessagesReceipient)).EndInit();
            this.groupMessagesReceipient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl6)).EndInit();
            this.GroupControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbMemoReceipient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gctrReceipient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReceipient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupMessagesFollowUpAction)).EndInit();
            this.groupMessagesFollowUpAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl4)).EndInit();
            this.GroupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gctrReplies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReplies)).EndInit();
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
            this.tabStaffSeven.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupMobileApp)).EndInit();
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
            // TODO: This line of code loads data into the 'aCMSDataSet.TblDeliverySchedule' table. You can move, or remove it, as needed.
            //this.tblDeliveryScheduleTableAdapter.Fill(this.aCMSDataSet.TblDeliverySchedule, oUser.NDepartmentID());
			barstaticCurrentLogin.Caption = string.Format(barstaticCurrentLogin.Caption, employee.StrEmployeeName, DateTime.Now.ToString("dd MMMM yyyy"));

			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);

			myEmployeeInfo = Ultis.EmployeeInfo(employee.Id);
			
			TabStaff_init();

			int currentYear = DateTime.Now.Year;
			object[] years = new object[]{currentYear - 3, currentYear - 2, currentYear - 1, currentYear, currentYear + 1};
			cbServiceYear.Properties.Items.AddRange(years);
			cbServiceYear.EditValue = currentYear;
			cbServiceMonth.SelectedIndex = DateTime.Now.Month - 1;
			cbSalesYear.Properties.Items.AddRange(years);
			cbSalesYear.EditValue = currentYear;
			cbSalesMonth.SelectedIndex = DateTime.Now.Month - 1;			
			cbAppointmentYear.Properties.Items.AddRange(years);
			cbAppointmentYear.EditValue = currentYear;
			cbAppointmentMonth.SelectedIndex = DateTime.Now.Month - 1;
			
			mySpaCommission = new CommissionSpaService();
			myPTCommission = new CommissionPTService();
			mySalesCommission = new SalesCommission();
			myCV = new ACMSLogic.Staff.CV();
			myMemo = new ACMSLogic.Staff.Memo();
			myReceipientGroup = new ACMSLogic.Staff.ReceipientGroup();
			myAppointment = new Appointment();
			myContacts = new Contacts();
            //myTimesheet = new Timesheet();
            //myLateness = new Lateness();
            //myLeave = new Leave();

			timer1.Enabled = true;

			luedtSalesBranchCode.EditValue = terminalUser.Branch.Id;
			luedtCommissionServiceBranch.EditValue = terminalUser.Branch.Id;

			new ACMS.XtraUtils.LookupEditBuilder.BranchCodeLookupEditBuilder2(luedtSalesBranchCode.Properties);
			new ACMS.XtraUtils.LookupEditBuilder.BranchCodeLookupEditBuilder2(luedtCommissionServiceBranch.Properties);			
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
            			
//			employee.RightsLevel.Id = 105;
            
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
            //ListMemo();
            //ListReceipientGroup();

            int_lblFour();
            lblFour_1.ForeColor = System.Drawing.Color.Firebrick;
            tabStaffFour.TabControl.SelectedTabPage = tabStaffFour;
            groupAppointment.Show();
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
					case "4":	this.tabStaffFour.Text= row["strTabName"].ToString();
						this.tabStaffFour.PageVisible=true;
						break;
					case "5":	this.tabStaffFive.Text= row["strTabName"].ToString();
						this.tabStaffFive.PageVisible=true;
						break;
                    case "7": this.tabStaffSeven.Text = row["strTabName"].ToString();
                        this.tabStaffSeven.PageVisible = true;
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
            else if (tabStaff.SelectedTabPage == tabStaffSeven)
            {
                ListMobileApp();
                //ListAppointment();
                //ListContact();
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
			lblFour_2_Click(this, e);
		}

        private void tabStaffMobileApp_VisibleChanged(object sender, System.EventArgs e)
        {
            //Call clicking event
            lblFour_2_Click(this, e);
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
			//lblSix_1_Click(this, e);
		}
		
		private void bbiLoginOut_ItemClick (System.Object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			this.Close();
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
							
						//ClassAttendance.CreateClassInstance();
						//PackageCode.CreateUnLinkPackage();
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
			else if (cbSalesType.SelectedIndex == 5)
			{
				gctrSales.DataSource = mySalesCommission.GetSalesCommission(employee.Id, luedtSalesBranchCode.EditValue.ToString(), 
					CategoryType.IPLPackage, Ultis.GetMonth(cbSalesMonth.SelectedIndex + 1), 
					ACMS.Convert.ToInt32(cbSalesYear.EditValue));
			}
            else if (cbSalesType.SelectedIndex == 6)
			{
				gctrSales.DataSource = mySalesCommission.GetSalesCommission(employee.Id, luedtSalesBranchCode.EditValue.ToString(), 
					CategoryType.HolisticFitness, Ultis.GetMonth(cbSalesMonth.SelectedIndex + 1), 
					ACMS.Convert.ToInt32(cbSalesYear.EditValue));
			}
            else //if (cbSalesType.SelectedIndex == 7)
            {
                gctrSales.DataSource = mySalesCommission.GetSalesCommission(employee.Id, luedtSalesBranchCode.EditValue.ToString(),
                    CategoryType.HolisticSpa, Ultis.GetMonth(cbSalesMonth.SelectedIndex + 1),
                    ACMS.Convert.ToInt32(cbSalesYear.EditValue));
            }
		}
		#endregion

        #region Mobile App
        public void ListMobileApp()
        {
            groupMobileApp.SuspendLayout();
            myMemberCardPhoto = new ACMS.ACMSManager.Operation.frmMemberCardPhoto();
            myMemberCardPhoto.ListMemberCardPhoto(User.BranchCode);
            myMemberCardPhoto.ListPackageExtensionRequest(User.BranchCode);
            myMemberCardPhoto.SetEmployeeRecord(employee);
            this.groupMobileApp.Controls.Clear();
            myMemberCardPhoto.TopLevel = false;
            myMemberCardPhoto.Dock = DockStyle.Fill;
            myMemberCardPhoto.Parent = groupMobileApp;
            groupMobileApp.Refresh();
            myMemberCardPhoto.Show();
            groupMobileApp.ResumeLayout();
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

            dtblSource.Columns.Add("strFileName1");
            dtblSource.Columns.Add("strFileName2");
            dtblSource.Columns.Add("strFileName3");
            foreach (DataRow dr in dtblSource.Rows)  
            {
                dr["strFileName1"] = System.IO.Path.GetFileName(dr["strFilePath1"].ToString());
                dr["strFileName2"] = System.IO.Path.GetFileName(dr["strFilePath2"].ToString());
                dr["strFileName3"] = System.IO.Path.GetFileName(dr["strFilePath3"].ToString());
            }
            toolTip1.SetToolTip(pbPreview,"Click to view file");
            toolTip1.SetToolTip(llFile1,"Click to view file");
            toolTip1.SetToolTip(llFile2,"Click to view file");
            toolTip1.SetToolTip(llFile3,"Click to view file");
            pbPreview.DataBindings.Clear();
            pbPreview.DataBindings.Add(new Binding("ImageLocation", dtblSource, "strImgPath"));
            llFile1.DataBindings.Clear();
            llFile1.DataBindings.Add(new Binding("Text", dtblSource, "strFileName1"));
            llFile1.DataBindings.Add(new Binding("Tag", dtblSource, "strFilePath1"));
            llFile2.DataBindings.Clear();
            llFile2.DataBindings.Add(new Binding("Text", dtblSource, "strFileName2"));
            llFile2.DataBindings.Add(new Binding("Tag", dtblSource, "strFilePath2"));
            llFile3.DataBindings.Clear();
            llFile3.DataBindings.Add(new Binding("Text", dtblSource, "strFileName3"));                       
            llFile3.DataBindings.Add(new Binding("Tag", dtblSource, "strFilePath3"));
            txtFilePath1.DataBindings.Clear();            
            txtFilePath1.DataBindings.Add(new Binding("EditValue", dtblSource, "strFilePath1"));
            txtFilePath2.DataBindings.Clear();
            txtFilePath2.DataBindings.Add(new Binding("EditValue", dtblSource, "strFilePath2"));
            txtFilePath3.DataBindings.Clear();
            txtFilePath3.DataBindings.Add(new Binding("EditValue", dtblSource, "strFilePath3"));
            txtImagePath.DataBindings.Clear();
            txtImagePath.DataBindings.Add(new Binding("EditValue", dtblSource, "strImgPath"));
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

            if (myMemo.UpdateMessage(Convert.ToInt32(currRow["nMemoID"]), memoedtMessage.Text, txtImagePath.Text, txtFilePath1.Text, txtFilePath2.Text, txtFilePath3.Text))
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
		public void ListAppointment()
		{
			if (cbAppointmentYear.EditValue == null)
				return;
			DateTime startDate, endDate;
			DateRange(out startDate, out endDate, cbAppointmentMonth.SelectedIndex, 
				Convert.ToInt32(cbAppointmentYear.EditValue));
			DataTable dtblSource = myAppointment.ListAppointment(User.BranchCode, startDate, endDate);
            DataColumn dc = new DataColumn("UtlCheck", System.Type.GetType("System.Boolean"));
            dtblSource.Columns.Add(dc);            
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
            ACMS.ACMSStaff.Appointment.frmAppointment form = new ACMS.ACMSStaff.Appointment.frmAppointment(employee.Id, -1, terminalUser.Branch.Id, -1);
			if (DialogResult.OK == form.ShowDialog())
				ListAppointment();
			form.Dispose();
		}

		private void sbtnAppointmentEdit_Click(object sender, System.EventArgs e)
		{
			if (!ValidateRowSelectedAppointment())
				return;

			DataRow row = gvAppointment.GetDataRow(gvAppointment.FocusedRowHandle);
            ACMS.ACMSStaff.Appointment.frmAppointment form = new ACMS.ACMSStaff.Appointment.frmAppointment(employee.Id, Convert.ToInt32(row["nAppointmentId"]), terminalUser.Branch.Id, Convert.ToInt32(row["nContactId"]));
			form.Date = Convert.ToDateTime(row["dtDate"]);
            form.StartTime = Convert.ToDateTime(row["dtStartTime"]);
			form.EndTime = Convert.ToDateTime(row["dtEndTime"]);
            form.BranchCode = row["strBranchCode"].ToString();
            form.ContactID = Convert.ToInt32(row["nContactId"]);
            form.Remark = row["strRemarks"].ToString();
            form.strMembership = row["strMembership"].ToString();
            form.ServedBy = Convert.ToInt32(row["nServedBy"]);

			if (DialogResult.OK == form.ShowDialog())
				ListAppointment();
			form.Dispose();
		}

		private void sbtnAppointmentDelete_Click(object sender, System.EventArgs e)
		{
			if (!ValidateRowSelectedAppointment())
				return;

            if (!employee.HasRight("AB_DELETE_APPOINTMENT"))
            {
                MessageBox.Show(this, "You are not allow to perform this action.");
                return;
            }

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

        private bool VerifyAppointment(int nAppointmentID, string strContactName, string strServedBy, string strVerifiedBy, int nContactID, int nStaffAssign)
        {
            //employee.RightsLevel.Id = 64;
            if (!employee.HasRight("AB_VERIFY_APPOINTMENT"))
            {
                MessageBox.Show(this, "You are not allow to perform this action.");
                return false;
            }

            if (!ValidateRowSelectedAppointment())
                return false;

            DataRow row = gvAppointment.GetDataRow(gvAppointment.FocusedRowHandle);
            //int nAppointmentID = Convert.ToInt32(row["nAppointmentID"]);

            if (strServedBy == "")
            {
                MessageBox.Show(this, "Please update Served By before verify");
                return false;
            }

            if (strVerifiedBy != "")
            {
                MessageBox.Show(this, "Appointment with " + strContactName + " have been verified by other staff : " + strVerifiedBy);
                return false;
            }

            // verify CSE cannot get verified 2 times
            DataSet tabStaffTable = new DataSet();

            string strSQL = "SELECT COUNT(*) nCount FROM [dbo].[tblAppointment] A LEFT OUTER JOIN [dbo].[tblContacts] B ON A.nContactID = B.nContactID LEFT OUTER JOIN tblEmployee e ON B.nEmployeeID=e.nEmployeeID WHERE A.nStatus IN (0,2) AND nVerifiedBy IS NOT NULL AND A.nContactId = " + nContactID.ToString() + " AND B.nEmployeeId=" + nStaffAssign.ToString() + " GROUP by B.nEmployeeId, A.nContactId ";

            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", tabStaffTable, new string[] { "Table" }, new SqlParameter("@strSQL", strSQL));
            DataTable dtVerifyAppt = tabStaffTable.Tables["Table"];

            if (dtVerifyAppt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtVerifyAppt.Rows[0]["nCount"]) == 2)
                {
                    MessageBox.Show(this, "Same staff assigned cannot be verified more than 2 times");
                    return false;
                }
            }
            return true;
        }
        private void sbtnAppointmentVerifiedBy_Click(object sender, System.EventArgs e)
        {            
            VerifyAppointment verifyForm = new VerifyAppointment();
            DialogResult result = verifyForm.ShowDialog(this);
            bool allValid = true;
            bool allNoTick = true;
            if (result == DialogResult.OK)
            {
                    try
                {
                   for (int i = 0; i < this.gvAppointment.RowCount; i++)
                   {
                        int rowHandle = gvAppointment.GetVisibleRowHandle(i);
                        DataRow row = gvAppointment.GetDataRow(rowHandle);

                        if (gvAppointment.IsDataRow(rowHandle))
                        {
                            if (gvAppointment.GetRowCellValue(rowHandle, "UtlCheck").ToString().ToUpper() == "TRUE")
                            {
                                allNoTick = false;
                                if (!VerifyAppointment(Convert.ToInt32(gvAppointment.GetRowCellValue(rowHandle, "nAppointmentId").ToString()),gvAppointment.GetRowCellValue(rowHandle, "strContactName").ToString(),gvAppointment.GetRowCellValue(rowHandle, "strServedBy").ToString(),gvAppointment.GetRowCellValue(rowHandle, "strVerifiedBy").ToString(),Convert.ToInt32(gvAppointment.GetRowCellValue(rowHandle, "nContactId").ToString()),Convert.ToInt32(gvAppointment.GetRowCellValue(rowHandle, "nStaffAssign").ToString())))
                                {
                                    allValid = false;
                                    break;
                                }    
                            }
                        }
                    }
                   if (allNoTick)
                   {
                       MessageBox.Show(this, "Please tick at least one appointment to verify");
                       return;
                   }

                   if (allValid)
                   {
                       DialogResult yes = MessageBox.Show(this, "Confirm to verify?", "Warning", MessageBoxButtons.YesNo);
                       if (yes == DialogResult.Yes)
                       {
                           DialogResult closeYes = MessageBox.Show(this, "Do you want to update these appointments status to Close?\n Lead will be removed from the Contact List as well.", "", MessageBoxButtons.YesNo);

                           for (int i = 0; i < this.gvAppointment.RowCount; i++)
                           {
                               int rowHandle = gvAppointment.GetVisibleRowHandle(i);
                               DataRow row = gvAppointment.GetDataRow(rowHandle);

                               if (gvAppointment.IsDataRow(rowHandle))
                               {
                                   if (gvAppointment.GetRowCellValue(rowHandle, "UtlCheck").ToString().ToUpper() == "TRUE")
                                   {
                                       myAppointment.VerifyAppointment(verifyForm.VerifierID, verifyForm.Password, Convert.ToInt32(gvAppointment.GetRowCellValue(rowHandle, "nAppointmentId").ToString()));

                                       if (closeYes == DialogResult.Yes)
                                           myAppointment.CloseAppointment(Convert.ToInt32(gvAppointment.GetRowCellValue(rowHandle, "nAppointmentId").ToString()));
                                   }
                               }
                           }
                           ListAppointment();
                           MessageBox.Show(this, "Appointment has been verified.");
                       }
                   }                    
                }                
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message);
                }
            }                    
        }
		#endregion

		#region Contact

		private void ListContact()
		{            
            DataTable dtblSource = myContacts.ListContacts(User.BranchCode, getStatusID(cmbStatus.SelectedText), txtSearchLead.Text);
            gridctrContact.DataSource = dtblSource;           
		}

        private int getStatusID(string strStatus)
        {
            if (cmbStatus.SelectedIndex == 0)
                return 1;
            else if (cmbStatus.SelectedIndex == 1)
                return 2;
            else if (cmbStatus.SelectedIndex == 2)
                return 3;
            else
                return 0;
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
            ACMS.ACMSStaff.Contacts.frmContacts form = new ACMS.ACMSStaff.Contacts.frmContacts(employee.Id, -1, terminalUser.Branch.Id,true);

            if (DialogResult.OK == form.ShowDialog())
            {
                ListContact();
                ListAppointment();
            }

			form.Dispose();
		}

        //DEREK DNC Updates 2014-03-18
		private void sbtnContactEdit_Click(object sender, System.EventArgs e)
		{
            if (!ValidateRowSelectedContacts())
            {
                return;
            }

			DataRow row = gvContact.GetDataRow(gvContact.FocusedRowHandle);
            if (row["nStatus"].ToString() == "3")
            {
                UI.ShowMessage("Do Not Contact List cannot be edited.");
                return;
            }
            bool bDisableDNC = true;
            if (row["dtDNCExpiryDate"].ToString() != "")
                bDisableDNC = false;
            ACMS.ACMSStaff.Contacts.frmContacts form = new ACMS.ACMSStaff.Contacts.frmContacts(Convert.ToInt32(row["nEmployeeId"]),
                                                                                                Convert.ToInt32(row["nContactId"]), 
                                                                                                terminalUser.Branch.Id, bDisableDNC);
			form.ContactPerson = row["strContactName"].ToString().Trim();
			form.MobileNo = row["strMobileNo"].ToString().Trim();
			form.Remarks = row["strRemarks"].ToString().Trim();
            form.Email = row["Email"].ToString().Trim();
            form.BranchCode = row["strBranchCode"].ToString();

            if (Convert.ToInt32(row["nStatus"]) == 0)
            {
                form.NStatusInActive = Convert.ToInt32(row["nStatus"]);
            }
            else
            {
                form.NStatusActive = Convert.ToInt32(row["nStatus"]);
            }

            if (row["Sex"].ToString() == "F")
            {
                form.IsGenderFemale = true;
            }
            else
            {
                form.IsGenderMale = true;
            }

            if (row["fPhoneCall"].ToString() == "True")
            {
                form.IsPhoneCall = true;
            }
            else 
            {
                form.IsPhoneCall = false;
            }

            if (row["fSMS"].ToString() == "True")
            {
                form.IsSMS = true;
            }
            else 
            {
                form.IsSMS = false;
            }

            if (row["fEmail"].ToString() == "True")
            {
                form.IsEmail = true;
            }
            else 
            {
                form.IsEmail = false;
            }

            if (row["fDNC"].ToString() == "True")
            {
                form.IsDNCYes = true;
            }
            else if (row["fDNC"].ToString() == "False")
            {
                form.IsDNCNo = true;
            }

            if (row["dtDOB"].ToString() == "")
            {
                //form.DateOfBirth = DateTime.Now.Date;
            }
            else
            {
                form.DateOfBirth = Convert.ToDateTime(row["dtDOB"].ToString());
            }

            form.Nric = row["strNRICFIN"].ToString();            
            form.MediaSourceCategory = row["strCategory"].ToString();
            form.MediaSourceID = Convert.ToInt32(row["nMediaSourceID"]);
            if (DialogResult.OK == form.ShowDialog())
            {
                ListContact();
                ListAppointment();
            }

			form.Dispose();
		}
        
		private void sbtnContactDelete_Click(object sender, System.EventArgs e)
		{
            if (!ValidateRowSelectedContacts())
            {
                return;
            }

            if (!UI.ShowYesNoMessage("Are you sure you want to delete this contact?"))
            {
                return;
            }
			
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
                        + "delete this contact.");
                }
                else
                {
                    //throw;
                    UI.ShowMessage(ex.Message);
                }
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
		}

		private void lblThree_1_Click(object sender, System.EventArgs e)
		{
			int_lblThree();
			lblThree_1.ForeColor=System.Drawing.Color.Firebrick;			
		}

		private void lblThree_2_Click(object sender, System.EventArgs e)
		{
			int_lblThree();
			lblThree_2.ForeColor=System.Drawing.Color.Firebrick;
			//groupOvertime.Show();
			
		}

		private void lblThree_3_Click(object sender, System.EventArgs e)
		{
			int_lblThree();
			lblThree_3.ForeColor=System.Drawing.Color.Firebrick;
			//groupLateness.Show();

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

        //DEREK DNC Updates 2014-03-07
		private void lblFour_2_Click(object sender, System.EventArgs e)
		{
			int_lblFour();
			lblFour_2.ForeColor=System.Drawing.Color.Firebrick;
            //chkInActive.Checked = true;
            cmbStatus.SelectedIndex = 0;
            //ListContact();
			groupContact.Show();
		}
		#endregion        

		private void tabStaff_Click(object sender, System.EventArgs e)
		{
		
		}

        private void gctrMemo_Click(object sender, EventArgs e)
        {

        }

        private void pbFileSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Open Image Files";
            fDialog.Filter = "JPEG Files|*.jpeg|JPG Files|*.jpg|GIF Files|*.gif|BMP Files|*.bmp|TIF Files|*.tif|PNG Files|*.png";
            fDialog.InitialDirectory = @"X:\";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                txtImagePath.Text = fDialog.FileName.ToString();
            }  
        }

        private void pbF1Select_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Open File to attach";
            fDialog.Filter = "All Files|*.*";
            fDialog.InitialDirectory = @"X:\";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath1.Text = fDialog.FileName.ToString();
            }
        }

        private void pbF2Select_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Open File to attach";
            fDialog.Filter = "All Files|*.*";
            fDialog.InitialDirectory = @"X:\";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath2.Text = fDialog.FileName.ToString();
            }
        }


        private void pbF3Select_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Open File to attach";
            fDialog.Filter = "All Files|*.*";
            fDialog.InitialDirectory = @"X:\";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath3.Text = fDialog.FileName.ToString();
            }
        }

        private void llFile1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(llFile1.Tag.ToString());
        }

        private void llFile2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(llFile2.Tag.ToString());
        }

        private void llFile3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(llFile3.Tag.ToString());
        }

        private void pbPreview_Click(object sender, EventArgs e)
        {
            if (pbPreview.ImageLocation != null && pbPreview.ImageLocation != "")
                Process.Start(pbPreview.ImageLocation);            
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            ListContact();
        }

        private void groupAppointmentEntry_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gvContact_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListContact();
        }
    }


}
