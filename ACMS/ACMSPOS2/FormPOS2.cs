using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraNavBar;
using System.Data;
using ACMSDAL;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using System.Threading;


namespace ACMS
{
	/// <summary>
	/// Summary description for FormPOS2.
	/// </summary>
	public class FormPOS2 : System.Windows.Forms.Form
    {
        #region class initialise
		private string strNewMembershipID;
        private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ImageList imageList1;
		private DevExpress.XtraEditors.PanelControl pnlTop;
		private DevExpress.XtraEditors.PanelControl pnlGrid;
		internal DevExpress.XtraNavBar.NavBarControl NavBarControl1;
		internal DevExpress.XtraNavBar.NavBarGroup nbgPackage;
		internal DevExpress.XtraNavBar.NavBarItem nbiPackage001;
		internal DevExpress.XtraNavBar.NavBarItem nbiPackage002;
		internal DevExpress.XtraNavBar.NavBarItem nbiPackage003;
		internal DevExpress.XtraNavBar.NavBarItem nbiPackage004;
		internal DevExpress.XtraNavBar.NavBarItem nbiPackage005;
		internal DevExpress.XtraNavBar.NavBarItem nbiPackage006;
		internal DevExpress.XtraNavBar.NavBarItem nbiPackage007;
		internal DevExpress.XtraNavBar.NavBarItem nbiPackage008;
		internal DevExpress.XtraNavBar.NavBarItem nbiPackage009;
		internal DevExpress.XtraNavBar.NavBarItem nbiPackage010;
		internal DevExpress.XtraNavBar.NavBarItem nbiPackage011;
		internal DevExpress.XtraNavBar.NavBarItem nbiPackage012;
		internal DevExpress.XtraNavBar.NavBarGroup nbgProduct;
		internal DevExpress.XtraNavBar.NavBarItem nbiProduct001;
		internal DevExpress.XtraNavBar.NavBarItem nbiProduct002;
		internal DevExpress.XtraNavBar.NavBarGroup nbgMiscellaneous;
		internal DevExpress.XtraNavBar.NavBarItem nbiMiscellaneous001;
		internal DevExpress.XtraNavBar.NavBarItem nbiMiscellaneous002;
		internal DevExpress.XtraNavBar.NavBarItem nbiMiscellaneous004;
		internal DevExpress.XtraNavBar.NavBarItem nbiMiscellaneous005;
		internal DevExpress.XtraNavBar.NavBarItem nbiMiscellaneous006;
		internal DevExpress.XtraNavBar.NavBarItem nbiMiscellaneous007;
		internal DevExpress.XtraNavBar.NavBarItem nbiMiscellaneous008;
        internal DevExpress.XtraNavBar.NavBarItem nbiMiscellaneous009;
		internal DevExpress.XtraGrid.GridControl gridItem;
		internal DevExpress.XtraGrid.Views.Grid.GridView GridView1;
		private DevExpress.XtraEditors.PanelControl pnlLeft;
		private DevExpress.XtraEditors.SplitterControl splitterControl1;
		private DevExpress.XtraEditors.PanelControl panelControl2;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		internal DevExpress.XtraEditors.SimpleButton sBtnAdd;
		internal DevExpress.XtraEditors.SimpleButton sBtnSubtract;
		internal System.Windows.Forms.Label Label12;
		internal System.Windows.Forms.Label Label11;
		internal DevExpress.XtraEditors.SimpleButton btnEnter;
		internal DevExpress.XtraEditors.TextEdit txtScannedCode;
		internal DevExpress.XtraEditors.GroupControl GroupControl1;
		internal System.Windows.Forms.Label label14;
		internal System.Windows.Forms.Label lblTherapistName;
		internal System.Windows.Forms.Label label10;
		internal System.Windows.Forms.Label lblTherapistID;
		internal System.Windows.Forms.Label label8;
		internal System.Windows.Forms.Label lblSalesPersonName;
		internal System.Windows.Forms.Label label5;
		internal System.Windows.Forms.Label lblBillReward;
		internal System.Windows.Forms.Label label4;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.Label label2;
		internal System.Windows.Forms.Label lblBillFB;
		internal System.Windows.Forms.Label lblBillDiscCode;
		internal System.Windows.Forms.Label lblDateTime;
		internal System.Windows.Forms.Label lblSalesperson;
		internal DevExpress.XtraEditors.GroupControl GroupControl2;
		internal System.Windows.Forms.Label lblNettAmt;
		internal System.Windows.Forms.Label lblGST;
		internal System.Windows.Forms.Label lblDiscountAmt;
		internal System.Windows.Forms.Label lblTotalAmt;
		internal System.Windows.Forms.Label lblAmountPayable;
		internal System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		internal System.Windows.Forms.Label label7;
		public System.Windows.Forms.Label lblMemberName;
		internal System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lblMembershipID;
		private DevExpress.XtraEditors.GroupControl groupControl3;
		private DevExpress.XtraEditors.GroupControl groupControl4;
		private DevExpress.XtraEditors.GroupControl groupControl5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;

		private ACMSLogic.POS myPOS;	
		private ACMSLogic.POSCommand Command;
        private string myStrMembershipID;
        private string myStrLocation;
		private string myStrBranchCode;
		private int myNTerminalID;
		private int myNEmployeeID;
        private int myNShiftID;
        private int myNPackageID;
		private DevExpress.XtraEditors.PanelControl pnlCtrlBarScanner;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnStrCode;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnDesc;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnListPrice;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnQty;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnDiscountCode;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnFreebieCode;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnSubTotal;
		private DevExpress.XtraEditors.CalcEdit calcEditQty;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnDiscountAmt;
		private DevExpress.XtraNavBar.NavBarItem navGiro;
		private DevExpress.XtraNavBar.NavBarItem navBarItem1;
		private DevExpress.XtraNavBar.NavBarItem navDeposit;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumnExchange;
        private DevExpress.XtraEditors.SimpleButton btnF1;
        private DevExpress.XtraEditors.SimpleButton btnF2;
        private DevExpress.XtraEditors.SimpleButton btnF3;
        private DevExpress.XtraEditors.SimpleButton btnF5;
        private DevExpress.XtraEditors.SimpleButton btnF4;
        private DevExpress.XtraEditors.SimpleButton btnF6;
        private DevExpress.XtraEditors.SimpleButton btnF8;
        private DevExpress.XtraEditors.SimpleButton btnF7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBillDiscount;
        private NavBarItem navSpaGiro;
        private NavBarItem navBarMaintainSpaGiro;
        private NavBarItem navConvertSpa;
        internal Label lblLocation;
        internal Label label9;
        internal Label label13;
        internal Label lblUpgradeFrom;
        private DevExpress.XtraEditors.GroupControl groupControl6;
        internal Label lblUsageBal;
        private DevExpress.XtraEditors.SimpleButton btnF9;
		private bool myIsFinishInitialise = false;
        private string strUp;
        private string connectionString;
        private bool myIsFinishLoadStockRecon = false;
		internal NavBarItem nbiPackage036;
        internal NavBarItem nbiPackage037;
        private SqlConnection connection;
        private fmProgress m_fmProgress = null;

        # endregion
        private void FormInitialise(int nCategoryID, string barItemNameBeenClicked,int iGIRO)
		{
			if (!myIsFinishInitialise)
			{
                //DataSet tabBranchRoadShowTable = new DataSet();
                StrNewMembershipID = "";
                //string strSQL = "select * from tblBranchRoadShow where strBranchCode='" + myStrLocation + "' and getdate() between dtFrom and CONVERT(VARCHAR(10),dtTo,120)+' 23:59:59' ";
                //SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", tabBranchRoadShowTable, new string[] { "Table" }, new SqlParameter("@strSQL", strSQL));

            
                //tabBranchRoadShowTable.Dispose();                

				myPOS = Command.NewPOS(nCategoryID, 
					myNEmployeeID, myStrMembershipID, myStrBranchCode,
                    myNTerminalID, myNShiftID, myStrLocation, myNPackageID, iGIRO);//1503

				Init();
				SetNaviBar(barItemNameBeenClicked);
				DataBinding();
				gridItem.DataSource = myPOS.ReceiptItemsTable;
				myIsFinishInitialise = true;
                                
				if (myPOS.NCategoryID == 1 || //myPOS.NCategoryID == 2 ||
					myPOS.NCategoryID == 3 || myPOS.NCategoryID == 4 ||
					myPOS.NCategoryID == 5 || myPOS.NCategoryID == 6 ||
					myPOS.NCategoryID == 7 || myPOS.NCategoryID == 8 ||
                    myPOS.NCategoryID == 9 || myPOS.NCategoryID == 36 || myPOS.NCategoryID == 37)
				{
					myPOS.AddRegFees();
				}

				if (myPOS.NCategoryID == 1 || myPOS.NCategoryID == 3 || //myPOS.NCategoryID == 3 ||
					myPOS.NCategoryID == 4 || myPOS.NCategoryID == 5 || myPOS.NCategoryID == 6 ||
					myPOS.NCategoryID == 8 || myPOS.NCategoryID == 7 || myPOS.NCategoryID == 9 ||
                    myPOS.NCategoryID == 11 || myPOS.NCategoryID == 12 || myPOS.NCategoryID == 36 || myPOS.NCategoryID == 37)
				{
					pnlCtrlBarScanner.Visible = true;
					calcEditQty.Value = 1;
				}
				else
				{
					pnlCtrlBarScanner.Visible = false;
				}

				
				if (myPOS.NCategoryID == 35 || myPOS.NCategoryID == 24)
				{
					gridColumnListPrice.OptionsColumn.AllowEdit = true;
				}
                
			}
		}

        public string StrNewMembershipID
        {
            get { return strNewMembershipID; }
            set { strNewMembershipID = value; }
        }
		public FormPOS2(string strMembershipID,
            string strBranchCode, int nTerminalID, int nEmployeeID, int nShiftID, string strLocation)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
            //groupControl5.Left = 10; 
			Command = ACMSLogic.POSCommand.Create();
			myNEmployeeID = nEmployeeID;
			myNShiftID = nShiftID;
			myNTerminalID = nTerminalID;
			myStrBranchCode = strBranchCode;
			myStrMembershipID = strMembershipID;
            lblMembershipID.Text = myStrMembershipID;//1503
            lblLocation.Text = strLocation;
            myStrLocation = strLocation;

            connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"];
            connection = new SqlConnection(connectionString);
			TblMember member = new TblMember();
			member.StrMembershipID = myStrMembershipID;
			member.SelectOne();
			lblMemberName.Text = member.StrMemberName.IsNull ? "" : member.StrMemberName.Value; 
		}


		private void Init()
		{
			if (myPOS.NCategoryID == 2 || myPOS.NCategoryID == 10 ||
				myPOS.NCategoryID == 15 || myPOS.NCategoryID == 16 ||
				myPOS.NCategoryID == 17 || myPOS.NCategoryID == 18 || 
				myPOS.NCategoryID == 20 || myPOS.NCategoryID == 21 ||
                myPOS.NCategoryID == 19 || myPOS.NCategoryID == 2 || myPOS.NCategoryID == 0 || myPOS.NCategoryID == 38)
			{
				sBtnAdd.Enabled = false;
				sBtnSubtract.Enabled = false;
                if (myPOS.NCategoryID == 38)
                    simpleButton1.Enabled = false;

				gridColumnQty.OptionsColumn.AllowEdit = false;

				if (myPOS.NCategoryID == 18)
					gridColumnListPrice.Caption = "Top Up Amount";
			}
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

		// this is just a temporary method, will remove it if no more depend on Ling part
		private void SetNaviBar(string barItemName)
		{
			for (int i = 0; i < NavBarControl1.Items.Count; i++) 
			{
				NavBarItem item = NavBarControl1.Items[i];

				if (item.Name != barItemName)
				{
					item.Enabled = false;	
					item.Visible = false;
				}
			}
		}

		private void SetNaviBarVisible()
		{
			for (int i = 0; i < NavBarControl1.Items.Count; i++) 
			{
				NavBarItem item = NavBarControl1.Items[i];	
				item.Enabled = false;	
				item.Visible = false;
			}
		}


		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPOS2));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlTop = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lblLocation = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.sBtnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.sBtnSubtract = new DevExpress.XtraEditors.SimpleButton();
            this.GroupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label13 = new System.Windows.Forms.Label();
            this.lblUpgradeFrom = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTherapistName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTherapistID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSalesPersonName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBillReward = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBillFB = new System.Windows.Forms.Label();
            this.lblBillDiscCode = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblSalesperson = new System.Windows.Forms.Label();
            this.GroupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.lblUsageBal = new System.Windows.Forms.Label();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.lblNettAmt = new System.Windows.Forms.Label();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.lblGST = new System.Windows.Forms.Label();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.lblDiscountAmt = new System.Windows.Forms.Label();
            this.lblTotalAmt = new System.Windows.Forms.Label();
            this.lblAmountPayable = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMemberName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMembershipID = new System.Windows.Forms.Label();
            this.pnlCtrlBarScanner = new DevExpress.XtraEditors.PanelControl();
            this.calcEditQty = new DevExpress.XtraEditors.CalcEdit();
            this.Label12 = new System.Windows.Forms.Label();
            this.txtScannedCode = new DevExpress.XtraEditors.TextEdit();
            this.Label11 = new System.Windows.Forms.Label();
            this.btnEnter = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnF9 = new DevExpress.XtraEditors.SimpleButton();
            this.btnF8 = new DevExpress.XtraEditors.SimpleButton();
            this.btnF7 = new DevExpress.XtraEditors.SimpleButton();
            this.btnF6 = new DevExpress.XtraEditors.SimpleButton();
            this.btnF5 = new DevExpress.XtraEditors.SimpleButton();
            this.btnF4 = new DevExpress.XtraEditors.SimpleButton();
            this.btnF3 = new DevExpress.XtraEditors.SimpleButton();
            this.btnF2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnF1 = new DevExpress.XtraEditors.SimpleButton();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.pnlLeft = new DevExpress.XtraEditors.PanelControl();
            this.NavBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.nbgPackage = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbiPackage001 = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiPackage002 = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiPackage003 = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiPackage004 = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiPackage005 = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiPackage006 = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiPackage007 = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiPackage008 = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiPackage009 = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiPackage010 = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiPackage011 = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiPackage012 = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiPackage036 = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiPackage037 = new DevExpress.XtraNavBar.NavBarItem();
            this.navGiro = new DevExpress.XtraNavBar.NavBarItem();
            this.navSpaGiro = new DevExpress.XtraNavBar.NavBarItem();
            this.navConvertSpa = new DevExpress.XtraNavBar.NavBarItem();
            this.nbgProduct = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbiProduct001 = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiProduct002 = new DevExpress.XtraNavBar.NavBarItem();
            this.nbgMiscellaneous = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbiMiscellaneous001 = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiMiscellaneous002 = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiMiscellaneous004 = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiMiscellaneous005 = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiMiscellaneous006 = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiMiscellaneous007 = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiMiscellaneous008 = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiMiscellaneous009 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarMaintainSpaGiro = new DevExpress.XtraNavBar.NavBarItem();
            this.navDeposit = new DevExpress.XtraNavBar.NavBarItem();
            this.pnlGrid = new DevExpress.XtraEditors.PanelControl();
            this.gridItem = new DevExpress.XtraGrid.GridControl();
            this.GridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnStrCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnListPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDiscountCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDiscountAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFreebieCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSubTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnExchange = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnBillDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl1)).BeginInit();
            this.GroupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl2)).BeginInit();
            this.GroupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
            this.groupControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCtrlBarScanner)).BeginInit();
            this.pnlCtrlBarScanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calcEditQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScannedCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeft)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NavBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            // 
            // pnlTop
            // 
            this.pnlTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlTop.Controls.Add(this.panelControl2);
            this.pnlTop.Controls.Add(this.panelControl1);
            this.pnlTop.Controls.Add(this.splitterControl1);
            this.pnlTop.Controls.Add(this.pnlLeft);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1030, 387);
            this.pnlTop.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.lblLocation);
            this.panelControl2.Controls.Add(this.label9);
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Controls.Add(this.sBtnAdd);
            this.panelControl2.Controls.Add(this.sBtnSubtract);
            this.panelControl2.Controls.Add(this.GroupControl1);
            this.panelControl2.Controls.Add(this.GroupControl2);
            this.panelControl2.Controls.Add(this.label7);
            this.panelControl2.Controls.Add(this.lblMemberName);
            this.panelControl2.Controls.Add(this.label6);
            this.panelControl2.Controls.Add(this.lblMembershipID);
            this.panelControl2.Controls.Add(this.pnlCtrlBarScanner);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(182, 113);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(848, 274);
            this.panelControl2.TabIndex = 48;
            // 
            // lblLocation
            // 
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLocation.Location = new System.Drawing.Point(662, 5);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(138, 16);
            this.lblLocation.TabIndex = 57;
            this.lblLocation.Text = "--";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(605, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 14);
            this.label9.TabIndex = 56;
            this.label9.Text = "Location:";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(748, 245);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(52, 30);
            this.simpleButton1.TabIndex = 54;
            this.simpleButton1.Text = "Delete";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // sBtnAdd
            // 
            this.sBtnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sBtnAdd.Appearance.Options.UseFont = true;
            this.sBtnAdd.Appearance.Options.UseTextOptions = true;
            this.sBtnAdd.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.sBtnAdd.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.sBtnAdd.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.sBtnAdd.ImageIndex = 0;
            this.sBtnAdd.ImageList = this.imageList1;
            this.sBtnAdd.Location = new System.Drawing.Point(718, 245);
            this.sBtnAdd.Name = "sBtnAdd";
            this.sBtnAdd.Size = new System.Drawing.Size(30, 30);
            this.sBtnAdd.TabIndex = 53;
            this.sBtnAdd.Click += new System.EventHandler(this.sBtnAdd_Click);
            // 
            // sBtnSubtract
            // 
            this.sBtnSubtract.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sBtnSubtract.Appearance.Options.UseFont = true;
            this.sBtnSubtract.Appearance.Options.UseTextOptions = true;
            this.sBtnSubtract.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.sBtnSubtract.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.sBtnSubtract.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.sBtnSubtract.ImageIndex = 1;
            this.sBtnSubtract.ImageList = this.imageList1;
            this.sBtnSubtract.Location = new System.Drawing.Point(688, 245);
            this.sBtnSubtract.Name = "sBtnSubtract";
            this.sBtnSubtract.Size = new System.Drawing.Size(30, 30);
            this.sBtnSubtract.TabIndex = 52;
            this.sBtnSubtract.Click += new System.EventHandler(this.sBtnSubtract_Click);
            // 
            // GroupControl1
            // 
            this.GroupControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.GroupControl1.Appearance.BorderColor = System.Drawing.Color.Black;
            this.GroupControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GroupControl1.Appearance.Options.UseBackColor = true;
            this.GroupControl1.Appearance.Options.UseBorderColor = true;
            this.GroupControl1.Appearance.Options.UseForeColor = true;
            this.GroupControl1.Controls.Add(this.label13);
            this.GroupControl1.Controls.Add(this.lblUpgradeFrom);
            this.GroupControl1.Controls.Add(this.label14);
            this.GroupControl1.Controls.Add(this.lblTherapistName);
            this.GroupControl1.Controls.Add(this.label10);
            this.GroupControl1.Controls.Add(this.lblTherapistID);
            this.GroupControl1.Controls.Add(this.label8);
            this.GroupControl1.Controls.Add(this.lblSalesPersonName);
            this.GroupControl1.Controls.Add(this.label5);
            this.GroupControl1.Controls.Add(this.lblBillReward);
            this.GroupControl1.Controls.Add(this.label4);
            this.GroupControl1.Controls.Add(this.label3);
            this.GroupControl1.Controls.Add(this.label2);
            this.GroupControl1.Controls.Add(this.lblBillFB);
            this.GroupControl1.Controls.Add(this.lblBillDiscCode);
            this.GroupControl1.Controls.Add(this.lblDateTime);
            this.GroupControl1.Controls.Add(this.lblSalesperson);
            this.GroupControl1.Location = new System.Drawing.Point(7, 22);
            this.GroupControl1.Name = "GroupControl1";
            this.GroupControl1.Size = new System.Drawing.Size(379, 217);
            this.GroupControl1.TabIndex = 45;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(5, 165);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 16);
            this.label13.TabIndex = 45;
            this.label13.Text = "Upgrade From:";
            // 
            // lblUpgradeFrom
            // 
            this.lblUpgradeFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpgradeFrom.Location = new System.Drawing.Point(103, 165);
            this.lblUpgradeFrom.Name = "lblUpgradeFrom";
            this.lblUpgradeFrom.Size = new System.Drawing.Size(269, 50);
            this.lblUpgradeFrom.TabIndex = 44;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(5, 105);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 14);
            this.label14.TabIndex = 43;
            this.label14.Text = "Name:";
            // 
            // lblTherapistName
            // 
            this.lblTherapistName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTherapistName.Location = new System.Drawing.Point(103, 105);
            this.lblTherapistName.Name = "lblTherapistName";
            this.lblTherapistName.Size = new System.Drawing.Size(254, 18);
            this.lblTherapistName.TabIndex = 42;
            this.lblTherapistName.Text = "--";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(5, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 14);
            this.label10.TabIndex = 41;
            this.label10.Text = "Therapist ID:";
            // 
            // lblTherapistID
            // 
            this.lblTherapistID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTherapistID.Location = new System.Drawing.Point(103, 85);
            this.lblTherapistID.Name = "lblTherapistID";
            this.lblTherapistID.Size = new System.Drawing.Size(110, 18);
            this.lblTherapistID.TabIndex = 40;
            this.lblTherapistID.Text = "--";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(5, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 14);
            this.label8.TabIndex = 39;
            this.label8.Text = "Name:";
            // 
            // lblSalesPersonName
            // 
            this.lblSalesPersonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesPersonName.Location = new System.Drawing.Point(103, 65);
            this.lblSalesPersonName.Name = "lblSalesPersonName";
            this.lblSalesPersonName.Size = new System.Drawing.Size(252, 18);
            this.lblSalesPersonName.TabIndex = 38;
            this.lblSalesPersonName.Text = "--";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(212, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 16);
            this.label5.TabIndex = 37;
            this.label5.Text = "Reward Code :";
            // 
            // lblBillReward
            // 
            this.lblBillReward.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillReward.Location = new System.Drawing.Point(295, 145);
            this.lblBillReward.Name = "lblBillReward";
            this.lblBillReward.Size = new System.Drawing.Size(81, 18);
            this.lblBillReward.TabIndex = 36;
            this.lblBillReward.Text = "--";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(5, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 35;
            this.label4.Text = "Freebie Code :";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(5, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 15);
            this.label3.TabIndex = 34;
            this.label3.Text = "Discount Code:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(5, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 18);
            this.label2.TabIndex = 33;
            this.label2.Text = "Sales Person ID:";
            // 
            // lblBillFB
            // 
            this.lblBillFB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillFB.Location = new System.Drawing.Point(103, 145);
            this.lblBillFB.Name = "lblBillFB";
            this.lblBillFB.Size = new System.Drawing.Size(96, 18);
            this.lblBillFB.TabIndex = 27;
            this.lblBillFB.Text = "--";
            // 
            // lblBillDiscCode
            // 
            this.lblBillDiscCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillDiscCode.Location = new System.Drawing.Point(103, 125);
            this.lblBillDiscCode.Name = "lblBillDiscCode";
            this.lblBillDiscCode.Size = new System.Drawing.Size(96, 18);
            this.lblBillDiscCode.TabIndex = 26;
            this.lblBillDiscCode.Text = "--";
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.BackColor = System.Drawing.SystemColors.Control;
            this.lblDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.Location = new System.Drawing.Point(5, 22);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(163, 17);
            this.lblDateTime.TabIndex = 24;
            this.lblDateTime.Text = "31/08/2005 11:30 AM";
            // 
            // lblSalesperson
            // 
            this.lblSalesperson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesperson.Location = new System.Drawing.Point(117, 45);
            this.lblSalesperson.Name = "lblSalesperson";
            this.lblSalesperson.Size = new System.Drawing.Size(110, 18);
            this.lblSalesperson.TabIndex = 32;
            this.lblSalesperson.Text = "--";
            // 
            // GroupControl2
            // 
            this.GroupControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.GroupControl2.Appearance.BorderColor = System.Drawing.Color.Black;
            this.GroupControl2.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GroupControl2.Appearance.Options.UseBackColor = true;
            this.GroupControl2.Appearance.Options.UseBorderColor = true;
            this.GroupControl2.Appearance.Options.UseForeColor = true;
            this.GroupControl2.Controls.Add(this.groupControl6);
            this.GroupControl2.Controls.Add(this.groupControl5);
            this.GroupControl2.Controls.Add(this.groupControl4);
            this.GroupControl2.Controls.Add(this.groupControl3);
            this.GroupControl2.Controls.Add(this.lblTotalAmt);
            this.GroupControl2.Controls.Add(this.lblAmountPayable);
            this.GroupControl2.Controls.Add(this.label1);
            this.GroupControl2.Location = new System.Drawing.Point(389, 22);
            this.GroupControl2.Name = "GroupControl2";
            this.GroupControl2.Size = new System.Drawing.Size(411, 217);
            this.GroupControl2.TabIndex = 46;
            // 
            // groupControl6
            // 
            this.groupControl6.Controls.Add(this.lblUsageBal);
            this.groupControl6.Location = new System.Drawing.Point(112, 140);
            this.groupControl6.Name = "groupControl6";
            this.groupControl6.Size = new System.Drawing.Size(93, 62);
            this.groupControl6.TabIndex = 37;
            this.groupControl6.Text = "Usage Bal:";
            this.groupControl6.Visible = false;
            // 
            // lblUsageBal
            // 
            this.lblUsageBal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsageBal.Location = new System.Drawing.Point(13, 30);
            this.lblUsageBal.Name = "lblUsageBal";
            this.lblUsageBal.Size = new System.Drawing.Size(82, 23);
            this.lblUsageBal.TabIndex = 33;
            this.lblUsageBal.Text = "0";
            this.lblUsageBal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.lblNettAmt);
            this.groupControl5.Location = new System.Drawing.Point(102, 140);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(104, 62);
            this.groupControl5.TabIndex = 36;
            this.groupControl5.Text = "Nett Amt:";
            // 
            // lblNettAmt
            // 
            this.lblNettAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNettAmt.Location = new System.Drawing.Point(13, 30);
            this.lblNettAmt.Name = "lblNettAmt";
            this.lblNettAmt.Size = new System.Drawing.Size(82, 23);
            this.lblNettAmt.TabIndex = 33;
            this.lblNettAmt.Text = "0";
            this.lblNettAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.lblGST);
            this.groupControl4.Location = new System.Drawing.Point(302, 140);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(100, 62);
            this.groupControl4.TabIndex = 35;
            this.groupControl4.Text = "GST:";
            // 
            // lblGST
            // 
            this.lblGST.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGST.Location = new System.Drawing.Point(22, 28);
            this.lblGST.Name = "lblGST";
            this.lblGST.Size = new System.Drawing.Size(70, 23);
            this.lblGST.TabIndex = 32;
            this.lblGST.Text = "0";
            this.lblGST.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.lblDiscountAmt);
            this.groupControl3.Location = new System.Drawing.Point(204, 140);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(100, 62);
            this.groupControl3.TabIndex = 34;
            this.groupControl3.Text = "Total Discount:";
            // 
            // lblDiscountAmt
            // 
            this.lblDiscountAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountAmt.Location = new System.Drawing.Point(23, 30);
            this.lblDiscountAmt.Name = "lblDiscountAmt";
            this.lblDiscountAmt.Size = new System.Drawing.Size(72, 23);
            this.lblDiscountAmt.TabIndex = 31;
            this.lblDiscountAmt.Text = "0";
            this.lblDiscountAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalAmt
            // 
            this.lblTotalAmt.AutoSize = true;
            this.lblTotalAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmt.Location = new System.Drawing.Point(141, 66);
            this.lblTotalAmt.Name = "lblTotalAmt";
            this.lblTotalAmt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotalAmt.Size = new System.Drawing.Size(54, 59);
            this.lblTotalAmt.TabIndex = 27;
            this.lblTotalAmt.Text = "0";
            this.lblTotalAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAmountPayable
            // 
            this.lblAmountPayable.AutoSize = true;
            this.lblAmountPayable.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAmountPayable.Location = new System.Drawing.Point(8, 20);
            this.lblAmountPayable.Name = "lblAmountPayable";
            this.lblAmountPayable.Size = new System.Drawing.Size(170, 31);
            this.lblAmountPayable.TabIndex = 26;
            this.lblAmountPayable.Text = "Sales Total:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 18);
            this.label1.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(289, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 14);
            this.label7.TabIndex = 43;
            this.label7.Text = "Member Name:";
            // 
            // lblMemberName
            // 
            this.lblMemberName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMemberName.Location = new System.Drawing.Point(378, 5);
            this.lblMemberName.Name = "lblMemberName";
            this.lblMemberName.Size = new System.Drawing.Size(224, 16);
            this.lblMemberName.TabIndex = 42;
            this.lblMemberName.Text = "--";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(9, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 16);
            this.label6.TabIndex = 41;
            this.label6.Text = "Membership ID:";
            // 
            // lblMembershipID
            // 
            this.lblMembershipID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMembershipID.Location = new System.Drawing.Point(113, 5);
            this.lblMembershipID.Name = "lblMembershipID";
            this.lblMembershipID.Size = new System.Drawing.Size(178, 16);
            this.lblMembershipID.TabIndex = 40;
            this.lblMembershipID.Text = "--";
            // 
            // pnlCtrlBarScanner
            // 
            this.pnlCtrlBarScanner.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlCtrlBarScanner.Controls.Add(this.calcEditQty);
            this.pnlCtrlBarScanner.Controls.Add(this.Label12);
            this.pnlCtrlBarScanner.Controls.Add(this.txtScannedCode);
            this.pnlCtrlBarScanner.Controls.Add(this.Label11);
            this.pnlCtrlBarScanner.Controls.Add(this.btnEnter);
            this.pnlCtrlBarScanner.Location = new System.Drawing.Point(7, 241);
            this.pnlCtrlBarScanner.Name = "pnlCtrlBarScanner";
            this.pnlCtrlBarScanner.Size = new System.Drawing.Size(508, 36);
            this.pnlCtrlBarScanner.TabIndex = 55;
            this.pnlCtrlBarScanner.Visible = false;
            // 
            // calcEditQty
            // 
            this.calcEditQty.Location = new System.Drawing.Point(382, 4);
            this.calcEditQty.Name = "calcEditQty";
            this.calcEditQty.Properties.AutoHeight = false;
            this.calcEditQty.Properties.Precision = 0;
            this.calcEditQty.Size = new System.Drawing.Size(64, 28);
            this.calcEditQty.TabIndex = 52;
            this.calcEditQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.calcEditQty_KeyDown);
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label12.Location = new System.Drawing.Point(350, 12);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(32, 13);
            this.Label12.TabIndex = 49;
            this.Label12.Text = "QTY";
            // 
            // txtScannedCode
            // 
            this.txtScannedCode.EditValue = "";
            this.txtScannedCode.Location = new System.Drawing.Point(114, 4);
            this.txtScannedCode.Name = "txtScannedCode";
            this.txtScannedCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScannedCode.Properties.Appearance.Options.UseFont = true;
            this.txtScannedCode.Size = new System.Drawing.Size(226, 29);
            this.txtScannedCode.TabIndex = 48;
            this.txtScannedCode.EditValueChanged += new System.EventHandler(this.txtScannedCode_EditValueChanged);
            this.txtScannedCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtScannedCode_KeyDown);
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label11.Location = new System.Drawing.Point(4, 12);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(112, 13);
            this.Label11.TabIndex = 47;
            this.Label11.Text = "SCAN ITEM CODE";
            // 
            // btnEnter
            // 
            this.btnEnter.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnter.Appearance.Options.UseFont = true;
            this.btnEnter.Appearance.Options.UseTextOptions = true;
            this.btnEnter.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnEnter.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.btnEnter.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnEnter.ImageIndex = 6;
            this.btnEnter.ImageList = this.imageList1;
            this.btnEnter.Location = new System.Drawing.Point(454, 4);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(30, 30);
            this.btnEnter.TabIndex = 51;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnF9);
            this.panelControl1.Controls.Add(this.btnF8);
            this.panelControl1.Controls.Add(this.btnF7);
            this.panelControl1.Controls.Add(this.btnF6);
            this.panelControl1.Controls.Add(this.btnF5);
            this.panelControl1.Controls.Add(this.btnF4);
            this.panelControl1.Controls.Add(this.btnF3);
            this.panelControl1.Controls.Add(this.btnF2);
            this.panelControl1.Controls.Add(this.btnF1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(182, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(848, 113);
            this.panelControl1.TabIndex = 47;
            // 
            // btnF9
            // 
            this.btnF9.Appearance.Font = new System.Drawing.Font("Tahoma", 14.35F, System.Drawing.FontStyle.Bold);
            this.btnF9.Appearance.Options.UseFont = true;
            this.btnF9.Location = new System.Drawing.Point(5, 76);
            this.btnF9.Name = "btnF9";
            this.btnF9.Size = new System.Drawing.Size(190, 32);
            this.btnF9.TabIndex = 48;
            this.btnF9.Text = "F9-Convert";
            this.btnF9.Click += new System.EventHandler(this.btnF9_Click);
            // 
            // btnF8
            // 
            this.btnF8.Appearance.Font = new System.Drawing.Font("Tahoma", 14.35F, System.Drawing.FontStyle.Bold);
            this.btnF8.Appearance.Options.UseFont = true;
            this.btnF8.Location = new System.Drawing.Point(608, 40);
            this.btnF8.Name = "btnF8";
            this.btnF8.Size = new System.Drawing.Size(190, 32);
            this.btnF8.TabIndex = 47;
            this.btnF8.Text = "F8-Cancel";
            this.btnF8.Click += new System.EventHandler(this.btnF8_Click);
            // 
            // btnF7
            // 
            this.btnF7.Appearance.Font = new System.Drawing.Font("Tahoma", 14.35F, System.Drawing.FontStyle.Bold);
            this.btnF7.Appearance.Options.UseFont = true;
            this.btnF7.Location = new System.Drawing.Point(406, 40);
            this.btnF7.Name = "btnF7";
            this.btnF7.Size = new System.Drawing.Size(190, 32);
            this.btnF7.TabIndex = 46;
            this.btnF7.Text = "F7-Tender";
            this.btnF7.Click += new System.EventHandler(this.btnF7_Click);
            // 
            // btnF6
            // 
            this.btnF6.Appearance.Font = new System.Drawing.Font("Tahoma", 14.35F, System.Drawing.FontStyle.Bold);
            this.btnF6.Appearance.Options.UseFont = true;
            this.btnF6.Location = new System.Drawing.Point(206, 40);
            this.btnF6.Name = "btnF6";
            this.btnF6.Size = new System.Drawing.Size(190, 32);
            this.btnF6.TabIndex = 45;
            this.btnF6.Text = "F6-IPP";
            this.btnF6.Click += new System.EventHandler(this.btnF6_Click);
            // 
            // btnF5
            // 
            this.btnF5.Appearance.Font = new System.Drawing.Font("Tahoma", 14.35F, System.Drawing.FontStyle.Bold);
            this.btnF5.Appearance.Options.UseFont = true;
            this.btnF5.Location = new System.Drawing.Point(5, 40);
            this.btnF5.Name = "btnF5";
            this.btnF5.Size = new System.Drawing.Size(190, 32);
            this.btnF5.TabIndex = 44;
            this.btnF5.Text = "F5-Rewards";
            this.btnF5.Click += new System.EventHandler(this.btnF5_Click);
            // 
            // btnF4
            // 
            this.btnF4.Appearance.Font = new System.Drawing.Font("Tahoma", 14.35F, System.Drawing.FontStyle.Bold);
            this.btnF4.Appearance.Options.UseFont = true;
            this.btnF4.Location = new System.Drawing.Point(608, 4);
            this.btnF4.Name = "btnF4";
            this.btnF4.Size = new System.Drawing.Size(190, 32);
            this.btnF4.TabIndex = 43;
            this.btnF4.Text = "F4-Bill Freebie";
            this.btnF4.Click += new System.EventHandler(this.btnF4_Click);
            // 
            // btnF3
            // 
            this.btnF3.Appearance.Font = new System.Drawing.Font("Tahoma", 14.35F, System.Drawing.FontStyle.Bold);
            this.btnF3.Appearance.Options.UseFont = true;
            this.btnF3.Location = new System.Drawing.Point(406, 4);
            this.btnF3.Name = "btnF3";
            this.btnF3.Size = new System.Drawing.Size(190, 32);
            this.btnF3.TabIndex = 42;
            this.btnF3.Text = "F3-Bill Discount";
            this.btnF3.Click += new System.EventHandler(this.btnF3_Click);
            // 
            // btnF2
            // 
            this.btnF2.Appearance.Font = new System.Drawing.Font("Tahoma", 14.35F, System.Drawing.FontStyle.Bold);
            this.btnF2.Appearance.Options.UseFont = true;
            this.btnF2.Location = new System.Drawing.Point(206, 4);
            this.btnF2.Name = "btnF2";
            this.btnF2.Size = new System.Drawing.Size(190, 32);
            this.btnF2.TabIndex = 41;
            this.btnF2.Text = "F2-Sales ID";
            this.btnF2.Click += new System.EventHandler(this.btnF2_Click);
            // 
            // btnF1
            // 
            this.btnF1.Appearance.Font = new System.Drawing.Font("Tahoma", 14.35F, System.Drawing.FontStyle.Bold);
            this.btnF1.Appearance.Options.UseFont = true;
            this.btnF1.Location = new System.Drawing.Point(5, 4);
            this.btnF1.Name = "btnF1";
            this.btnF1.Size = new System.Drawing.Size(190, 32);
            this.btnF1.TabIndex = 40;
            this.btnF1.Text = "F1-Item Discount";
            this.btnF1.Click += new System.EventHandler(this.btnF1_Click);
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(176, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(6, 387);
            this.splitterControl1.TabIndex = 46;
            this.splitterControl1.TabStop = false;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlLeft.Controls.Add(this.NavBarControl1);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(176, 387);
            this.pnlLeft.TabIndex = 45;
            // 
            // NavBarControl1
            // 
            this.NavBarControl1.ActiveGroup = this.nbgPackage;
            this.NavBarControl1.Appearance.Background.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NavBarControl1.Appearance.Background.Options.UseFont = true;
            this.NavBarControl1.Appearance.Background.Options.UseTextOptions = true;
            this.NavBarControl1.Appearance.Background.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.NavBarControl1.Appearance.Background.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.NavBarControl1.Appearance.Background.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.NavBarControl1.Appearance.Background.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.NavBarControl1.Appearance.Item.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.NavBarControl1.Appearance.Item.Options.UseFont = true;
            this.NavBarControl1.Appearance.ItemActive.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.NavBarControl1.Appearance.ItemActive.Options.UseFont = true;
            this.NavBarControl1.ContentButtonHint = null;
            this.NavBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NavBarControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NavBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nbgPackage,
            this.nbgProduct,
            this.nbgMiscellaneous});
            this.NavBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nbiPackage001,
            this.nbiPackage002,
            this.nbiPackage003,
            this.nbiPackage004,
            this.nbiPackage005,
            this.nbiPackage006,
            this.nbiPackage007,
            this.nbiPackage008,
            this.nbiPackage009,
            this.nbiPackage010,
            this.nbiPackage011,
            this.nbiPackage012,
            this.nbiProduct001,
            this.nbiProduct002,
            this.nbiMiscellaneous001,
            this.nbiMiscellaneous002,
            this.nbiMiscellaneous004,
            this.nbiMiscellaneous005,
            this.nbiMiscellaneous006,
            this.nbiMiscellaneous007,
            this.nbiMiscellaneous008,
            this.nbiMiscellaneous009,
            this.navGiro,
            this.navBarItem1,
            this.navDeposit,
            this.navSpaGiro,
            this.navBarMaintainSpaGiro,
            this.navConvertSpa,
            this.nbiPackage036,
            this.nbiPackage037});
            this.NavBarControl1.Location = new System.Drawing.Point(0, 0);
            this.NavBarControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.NavBarControl1.Name = "NavBarControl1";
            this.NavBarControl1.OptionsNavPane.ExpandedWidth = 176;
            this.NavBarControl1.Size = new System.Drawing.Size(176, 387);
            this.NavBarControl1.StoreDefaultPaintStyleName = true;
            this.NavBarControl1.TabIndex = 44;
            this.NavBarControl1.Text = "MANTAIN GIROPKG  ";
            this.NavBarControl1.Click += new System.EventHandler(this.NavBarControl1_Click);
            // 
            // nbgPackage
            // 
            this.nbgPackage.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbgPackage.Appearance.Options.UseFont = true;
            this.nbgPackage.Caption = "PACKAGE";
            this.nbgPackage.Expanded = true;
            this.nbgPackage.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiPackage001),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiPackage002),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiPackage003),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiPackage004),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiPackage005),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiPackage006),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiPackage007),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiPackage008),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiPackage009),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiPackage010),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiPackage011),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiPackage012),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiPackage036),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiPackage037),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navGiro),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navSpaGiro),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navConvertSpa)});
            this.nbgPackage.Name = "nbgPackage";
            this.nbgPackage.TopVisibleLinkIndex = 6;
            // 
            // nbiPackage001
            // 
            this.nbiPackage001.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbiPackage001.Appearance.Options.UseFont = true;
            this.nbiPackage001.Caption = "FITNESS PKG";
            this.nbiPackage001.Name = "nbiPackage001";
            this.nbiPackage001.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiPackage001_LinkClicked_1);
            // 
            // nbiPackage002
            // 
            this.nbiPackage002.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbiPackage002.Appearance.Options.UseFont = true;
            this.nbiPackage002.Caption = "FITNESS GIRO";
            this.nbiPackage002.Name = "nbiPackage002";
            this.nbiPackage002.Visible = false;
            this.nbiPackage002.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiPackage002_LinkClicked);
            // 
            // nbiPackage003
            // 
            this.nbiPackage003.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbiPackage003.Appearance.Options.UseFont = true;
            this.nbiPackage003.Caption = "PT PKG";
            this.nbiPackage003.Name = "nbiPackage003";
            this.nbiPackage003.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiPackage003_LinkClicked);
            // 
            // nbiPackage004
            // 
            this.nbiPackage004.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbiPackage004.Appearance.Options.UseFont = true;
            this.nbiPackage004.Caption = "SPA SINGLE TX";
            this.nbiPackage004.Name = "nbiPackage004";
            this.nbiPackage004.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiPackage004_LinkClicked);
            // 
            // nbiPackage005
            // 
            this.nbiPackage005.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.nbiPackage005.Appearance.Options.UseFont = true;
            this.nbiPackage005.Caption = "SPA PKG";
            this.nbiPackage005.Name = "nbiPackage005";
            this.nbiPackage005.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiPackage005_LinkClicked);
            // 
            // nbiPackage006
            // 
            this.nbiPackage006.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.nbiPackage006.Appearance.Options.UseFont = true;
            this.nbiPackage006.Caption = "IPL PKG";
            this.nbiPackage006.Name = "nbiPackage006";
            this.nbiPackage006.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiPackage006_LinkClicked);
            // 
            // nbiPackage007
            // 
            this.nbiPackage007.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.nbiPackage007.Appearance.Options.UseFont = true;
            this.nbiPackage007.Caption = "SPA CREDIT";
            this.nbiPackage007.Name = "nbiPackage007";
            this.nbiPackage007.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiPackage007_LinkClicked);
            // 
            // nbiPackage008
            // 
            this.nbiPackage008.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.nbiPackage008.Appearance.Options.UseFont = true;
            this.nbiPackage008.Appearance.Options.UseTextOptions = true;
            this.nbiPackage008.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.nbiPackage008.Caption = "FITNESS COMBO PKG";
            this.nbiPackage008.Name = "nbiPackage008";
            this.nbiPackage008.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiPackage008_LinkClicked);
            // 
            // nbiPackage009
            // 
            this.nbiPackage009.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.nbiPackage009.Appearance.Options.UseFont = true;
            this.nbiPackage009.Appearance.Options.UseTextOptions = true;
            this.nbiPackage009.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.nbiPackage009.Caption = "SPA COMBO PKG";
            this.nbiPackage009.Name = "nbiPackage009";
            this.nbiPackage009.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiPackage009_LinkClicked);
            // 
            // nbiPackage010
            // 
            this.nbiPackage010.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.nbiPackage010.Appearance.Options.UseFont = true;
            this.nbiPackage010.Caption = "UPGRADE PKG";
            this.nbiPackage010.Name = "nbiPackage010";
            this.nbiPackage010.Visible = false;
            this.nbiPackage010.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiPackage010_LinkClicked);
            // 
            // nbiPackage011
            // 
            this.nbiPackage011.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.nbiPackage011.Appearance.Options.UseFont = true;
            this.nbiPackage011.Caption = "TOP-UP SINGLE TREATMENT";
            this.nbiPackage011.Name = "nbiPackage011";
            this.nbiPackage011.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiPackage011_LinkClicked);
            // 
            // nbiPackage012
            // 
            this.nbiPackage012.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.nbiPackage012.Appearance.Options.UseFont = true;
            this.nbiPackage012.Caption = "TOP-UP SPA CREDIT";
            this.nbiPackage012.Name = "nbiPackage012";
            this.nbiPackage012.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiPackage012_LinkClicked);
            // 
            // nbiPackage036
            // 
            this.nbiPackage036.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.nbiPackage036.Appearance.Options.UseFont = true;
            this.nbiPackage036.Caption = "HOLISTIC FITNESS CREDIT";
            this.nbiPackage036.Name = "nbiPackage036";
            this.nbiPackage036.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiPackage036_LinkClicked);
            // 
            // nbiPackage037
            // 
            this.nbiPackage037.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.nbiPackage037.Appearance.Options.UseFont = true;
            this.nbiPackage037.Caption = "HOLISTIC SPA CREDIT";
            this.nbiPackage037.Name = "nbiPackage037";
            this.nbiPackage037.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiPackage037_LinkClicked);
            // 
            // navGiro
            // 
            this.navGiro.Caption = "GIRO PKG";
            this.navGiro.Name = "navGiro";
            this.navGiro.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navGiro_LinkClicked);
            // 
            // navSpaGiro
            // 
            this.navSpaGiro.Caption = "SPA GIRO";
            this.navSpaGiro.Name = "navSpaGiro";
            this.navSpaGiro.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navSpaGiro_LinkClicked);
            // 
            // navConvertSpa
            // 
            this.navConvertSpa.Caption = "CONVERT SPA PKG";
            this.navConvertSpa.Name = "navConvertSpa";
            this.navConvertSpa.Visible = false;
            this.navConvertSpa.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navConvertSpa_LinkClicked);
            // 
            // nbgProduct
            // 
            this.nbgProduct.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbgProduct.Appearance.Options.UseFont = true;
            this.nbgProduct.AppearanceBackground.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.nbgProduct.AppearanceBackground.Options.UseFont = true;
            this.nbgProduct.Caption = "PRODUCT";
            this.nbgProduct.Expanded = true;
            this.nbgProduct.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiProduct001),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiProduct002)});
            this.nbgProduct.Name = "nbgProduct";
            // 
            // nbiProduct001
            // 
            this.nbiProduct001.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbiProduct001.Appearance.Options.UseFont = true;
            this.nbiProduct001.Caption = "FITNESS PRODUCT";
            this.nbiProduct001.Name = "nbiProduct001";
            this.nbiProduct001.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiProduct001_LinkClicked);
            // 
            // nbiProduct002
            // 
            this.nbiProduct002.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbiProduct002.Appearance.Options.UseFont = true;
            this.nbiProduct002.Caption = "SPA PRODUCT";
            this.nbiProduct002.Name = "nbiProduct002";
            this.nbiProduct002.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiProduct002_LinkClicked);
            // 
            // nbgMiscellaneous
            // 
            this.nbgMiscellaneous.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbgMiscellaneous.Appearance.Options.UseFont = true;
            this.nbgMiscellaneous.Caption = "MISCELLANEOUS";
            this.nbgMiscellaneous.Expanded = true;
            this.nbgMiscellaneous.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiMiscellaneous009),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiMiscellaneous001),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiMiscellaneous002),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiMiscellaneous004),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiMiscellaneous005),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiMiscellaneous006),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiMiscellaneous007),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiMiscellaneous008),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem1),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarMaintainSpaGiro),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navDeposit)});
            this.nbgMiscellaneous.Name = "nbgMiscellaneous";
            // 
            // nbiMiscellaneous001
            // 
            this.nbiMiscellaneous001.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbiMiscellaneous001.Appearance.Options.UseFont = true;
            this.nbiMiscellaneous001.Appearance.Options.UseTextOptions = true;
            this.nbiMiscellaneous001.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.nbiMiscellaneous001.Caption = "COURSES & EVENTS";
            this.nbiMiscellaneous001.Name = "nbiMiscellaneous001";
            this.nbiMiscellaneous001.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiMiscellaneous001_LinkClicked);
            // 
            // nbiMiscellaneous002
            // 
            this.nbiMiscellaneous002.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.nbiMiscellaneous002.Appearance.Options.UseFont = true;
            this.nbiMiscellaneous002.Appearance.Options.UseTextOptions = true;
            this.nbiMiscellaneous002.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.nbiMiscellaneous002.Caption = "LOCKER RENTAL";
            this.nbiMiscellaneous002.Name = "nbiMiscellaneous002";
            this.nbiMiscellaneous002.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiMiscellaneous002_LinkClicked);
            // 
            // nbiMiscellaneous004
            // 
            this.nbiMiscellaneous004.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.nbiMiscellaneous004.Appearance.Options.UseFont = true;
            this.nbiMiscellaneous004.Appearance.Options.UseTextOptions = true;
            this.nbiMiscellaneous004.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.nbiMiscellaneous004.Caption = "FORGET CARD";
            this.nbiMiscellaneous004.Name = "nbiMiscellaneous004";
            this.nbiMiscellaneous004.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiMiscellaneous004_LinkClicked);
            // 
            // nbiMiscellaneous005
            // 
            this.nbiMiscellaneous005.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.nbiMiscellaneous005.Appearance.Options.UseFont = true;
            this.nbiMiscellaneous005.Appearance.Options.UseTextOptions = true;
            this.nbiMiscellaneous005.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.nbiMiscellaneous005.Caption = "LOST CARD";
            this.nbiMiscellaneous005.Name = "nbiMiscellaneous005";
            this.nbiMiscellaneous005.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiMiscellaneous005_LinkClicked);
            // 
            // nbiMiscellaneous006
            // 
            this.nbiMiscellaneous006.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.nbiMiscellaneous006.Appearance.Options.UseFont = true;
            this.nbiMiscellaneous006.Appearance.Options.UseTextOptions = true;
            this.nbiMiscellaneous006.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.nbiMiscellaneous006.Caption = "MINERAL WATER";
            this.nbiMiscellaneous006.Name = "nbiMiscellaneous006";
            this.nbiMiscellaneous006.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiMiscellaneous006_LinkClicked);
            // 
            // nbiMiscellaneous007
            // 
            this.nbiMiscellaneous007.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.nbiMiscellaneous007.Appearance.Options.UseFont = true;
            this.nbiMiscellaneous007.Appearance.Options.UseTextOptions = true;
            this.nbiMiscellaneous007.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.nbiMiscellaneous007.Caption = "OTHERS";
            this.nbiMiscellaneous007.Name = "nbiMiscellaneous007";
            this.nbiMiscellaneous007.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiMiscellaneous007_LinkClicked);
            // 
            // nbiMiscellaneous008
            // 
            this.nbiMiscellaneous008.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.nbiMiscellaneous008.Appearance.Options.UseFont = true;
            this.nbiMiscellaneous008.Appearance.Options.UseTextOptions = true;
            this.nbiMiscellaneous008.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.nbiMiscellaneous008.Caption = "PAY OUTSTANDING";
            this.nbiMiscellaneous008.Name = "nbiMiscellaneous008";
            this.nbiMiscellaneous008.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiMiscellaneous008_LinkClicked);
            // 
            // nbiMiscellaneous009
            // 
            this.nbiMiscellaneous009.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.nbiMiscellaneous009.Appearance.Options.UseFont = true;
            this.nbiMiscellaneous009.Appearance.Options.UseTextOptions = true;
            this.nbiMiscellaneous009.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.nbiMiscellaneous009.Caption = "CASH VOUCHER";
            this.nbiMiscellaneous009.Name = "nbiMiscellaneous009";
            this.nbiMiscellaneous009.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiMiscellaneous009_LinkClicked);
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "MAINTAIN GIRO PKG";
            this.navBarItem1.Name = "navBarItem1";
            this.navBarItem1.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem1_LinkClicked);
            // 
            // navBarMaintainSpaGiro
            // 
            this.navBarMaintainSpaGiro.Caption = "MAINTAIN SPA GIRO";
            this.navBarMaintainSpaGiro.Name = "navBarMaintainSpaGiro";
            this.navBarMaintainSpaGiro.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarMaintainSpaGiro_LinkClicked);
            // 
            // navDeposit
            // 
            this.navDeposit.Caption = "DEPOSIT";
            this.navDeposit.Name = "navDeposit";
            this.navDeposit.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navDeposit_LinkClicked);
            // 
            // pnlGrid
            // 
            this.pnlGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlGrid.Controls.Add(this.gridItem);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 387);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1030, 355);
            this.pnlGrid.TabIndex = 1;
            // 
            // gridItem
            // 
            this.gridItem.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridItem.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridItem.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridItem.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridItem.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridItem.Location = new System.Drawing.Point(0, 0);
            this.gridItem.MainView = this.GridView1;
            this.gridItem.Name = "gridItem";
            this.gridItem.Size = new System.Drawing.Size(990, 269);
            this.gridItem.TabIndex = 40;
            this.gridItem.UseEmbeddedNavigator = true;
            this.gridItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView1});
            // 
            // GridView1
            // 
            this.GridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.GridView1.ColumnPanelRowHeight = 25;
            this.GridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnStrCode,
            this.gridColumnDesc,
            this.gridColumnListPrice,
            this.gridColumn8,
            this.gridColumnQty,
            this.gridColumnDiscountCode,
            this.gridColumnDiscountAmt,
            this.gridColumnFreebieCode,
            this.gridColumnSubTotal,
            this.gridColumnExchange,
            this.gridColumnBillDiscount});
            this.GridView1.CustomizationFormBounds = new System.Drawing.Rectangle(322, 464, 208, 156);
            this.GridView1.GridControl = this.gridItem;
            this.GridView1.Name = "GridView1";
            this.GridView1.RowHeight = 25;
            // 
            // gridColumnStrCode
            // 
            this.gridColumnStrCode.Caption = "Code";
            this.gridColumnStrCode.FieldName = "strCode";
            this.gridColumnStrCode.Name = "gridColumnStrCode";
            this.gridColumnStrCode.OptionsColumn.AllowEdit = false;
            this.gridColumnStrCode.OptionsFilter.AllowFilter = false;
            this.gridColumnStrCode.Visible = true;
            this.gridColumnStrCode.VisibleIndex = 0;
            this.gridColumnStrCode.Width = 104;
            // 
            // gridColumnDesc
            // 
            this.gridColumnDesc.Caption = "Description";
            this.gridColumnDesc.FieldName = "strDescription";
            this.gridColumnDesc.Name = "gridColumnDesc";
            this.gridColumnDesc.OptionsColumn.AllowEdit = false;
            this.gridColumnDesc.OptionsFilter.AllowFilter = false;
            this.gridColumnDesc.Visible = true;
            this.gridColumnDesc.VisibleIndex = 1;
            this.gridColumnDesc.Width = 166;
            // 
            // gridColumnListPrice
            // 
            this.gridColumnListPrice.Caption = "List Price";
            this.gridColumnListPrice.DisplayFormat.FormatString = "n2";
            this.gridColumnListPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnListPrice.FieldName = "mUnitPrice";
            this.gridColumnListPrice.Name = "gridColumnListPrice";
            this.gridColumnListPrice.OptionsColumn.AllowEdit = false;
            this.gridColumnListPrice.OptionsFilter.AllowFilter = false;
            this.gridColumnListPrice.Visible = true;
            this.gridColumnListPrice.VisibleIndex = 2;
            this.gridColumnListPrice.Width = 98;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Old Package Price";
            this.gridColumn8.FieldName = "OldPackagePrice";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Width = 101;
            // 
            // gridColumnQty
            // 
            this.gridColumnQty.Caption = "Quantity";
            this.gridColumnQty.FieldName = "nQuantity";
            this.gridColumnQty.Name = "gridColumnQty";
            this.gridColumnQty.OptionsFilter.AllowFilter = false;
            this.gridColumnQty.Visible = true;
            this.gridColumnQty.VisibleIndex = 3;
            this.gridColumnQty.Width = 58;
            // 
            // gridColumnDiscountCode
            // 
            this.gridColumnDiscountCode.Caption = "Discount Code";
            this.gridColumnDiscountCode.FieldName = "strDiscountCode";
            this.gridColumnDiscountCode.Name = "gridColumnDiscountCode";
            this.gridColumnDiscountCode.OptionsColumn.AllowEdit = false;
            this.gridColumnDiscountCode.OptionsFilter.AllowFilter = false;
            this.gridColumnDiscountCode.Visible = true;
            this.gridColumnDiscountCode.VisibleIndex = 4;
            this.gridColumnDiscountCode.Width = 82;
            // 
            // gridColumnDiscountAmt
            // 
            this.gridColumnDiscountAmt.Caption = "Discount Amt";
            this.gridColumnDiscountAmt.DisplayFormat.FormatString = "n2";
            this.gridColumnDiscountAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnDiscountAmt.FieldName = "DiscountAmt";
            this.gridColumnDiscountAmt.Name = "gridColumnDiscountAmt";
            this.gridColumnDiscountAmt.OptionsColumn.AllowEdit = false;
            this.gridColumnDiscountAmt.OptionsFilter.AllowFilter = false;
            this.gridColumnDiscountAmt.Visible = true;
            this.gridColumnDiscountAmt.VisibleIndex = 5;
            this.gridColumnDiscountAmt.Width = 84;
            // 
            // gridColumnFreebieCode
            // 
            this.gridColumnFreebieCode.Caption = "Freebie Code";
            this.gridColumnFreebieCode.FieldName = "strFreebieCode";
            this.gridColumnFreebieCode.Name = "gridColumnFreebieCode";
            this.gridColumnFreebieCode.OptionsColumn.AllowEdit = false;
            this.gridColumnFreebieCode.OptionsFilter.AllowFilter = false;
            this.gridColumnFreebieCode.Visible = true;
            this.gridColumnFreebieCode.VisibleIndex = 6;
            this.gridColumnFreebieCode.Width = 108;
            // 
            // gridColumnSubTotal
            // 
            this.gridColumnSubTotal.Caption = "SubTotal";
            this.gridColumnSubTotal.DisplayFormat.FormatString = "n2";
            this.gridColumnSubTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnSubTotal.FieldName = "mSubTotal";
            this.gridColumnSubTotal.Name = "gridColumnSubTotal";
            this.gridColumnSubTotal.OptionsColumn.AllowEdit = false;
            this.gridColumnSubTotal.OptionsFilter.AllowFilter = false;
            this.gridColumnSubTotal.Visible = true;
            this.gridColumnSubTotal.VisibleIndex = 7;
            this.gridColumnSubTotal.Width = 95;
            // 
            // gridColumnExchange
            // 
            this.gridColumnExchange.Caption = "Item Ref";
            this.gridColumnExchange.FieldName = "strReferenceNo";
            this.gridColumnExchange.Name = "gridColumnExchange";
            this.gridColumnExchange.OptionsFilter.AllowFilter = false;
            this.gridColumnExchange.Visible = true;
            this.gridColumnExchange.VisibleIndex = 8;
            this.gridColumnExchange.Width = 86;
            // 
            // gridColumnBillDiscount
            // 
            this.gridColumnBillDiscount.Caption = "Bill Ref";
            this.gridColumnBillDiscount.FieldName = "strBillReferenceNo";
            this.gridColumnBillDiscount.Name = "gridColumnBillDiscount";
            this.gridColumnBillDiscount.OptionsFilter.AllowFilter = false;
            this.gridColumnBillDiscount.Visible = true;
            this.gridColumnBillDiscount.VisibleIndex = 9;
            this.gridColumnBillDiscount.Width = 88;
            // 
            // FormPOS2
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1030, 742);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "FormPOS2";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACMS POS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormPOS2_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl1)).EndInit();
            this.GroupControl1.ResumeLayout(false);
            this.GroupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl2)).EndInit();
            this.GroupControl2.ResumeLayout(false);
            this.GroupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
            this.groupControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCtrlBarScanner)).EndInit();
            this.pnlCtrlBarScanner.ResumeLayout(false);
            this.pnlCtrlBarScanner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calcEditQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScannedCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeft)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NavBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		
		private void DataBinding()
		{
			lblSalesperson.DataBindings.Clear();
			lblBillDiscCode.DataBindings.Clear();
			lblBillFB.DataBindings.Clear();
			lblBillReward.DataBindings.Clear();
			lblNettAmt.DataBindings.Clear();
			lblGST.DataBindings.Clear();
			lblDiscountAmt.DataBindings.Clear();
			lblTotalAmt.DataBindings.Clear();
			lblMembershipID.DataBindings.Clear();
			lblTherapistID.DataBindings.Clear();
			lblTherapistName.DataBindings.Clear();
            lblSalesPersonName.DataBindings.Clear();
           			
			lblBillDiscCode.DataBindings.Add("Text", myPOS.ReceiptMasterTable, "strDiscountCode");
			lblBillFB.DataBindings.Add("Text", myPOS.ReceiptMasterTable, "strFreebieCode");
			lblBillReward.DataBindings.Add("Text", myPOS.ReceiptMasterTable, "strRewardsCode");
			lblSalesperson.DataBindings.Add("Text", myPOS.ReceiptMasterTable, "nSalespersonID");
			lblNettAmt.DataBindings.Add("Text", myPOS.ReceiptMasterTable, "mNettAmount");
			lblGST.DataBindings.Add("Text", myPOS.ReceiptMasterTable, "mGSTAmount");
			lblDiscountAmt.DataBindings.Add("Text", myPOS.ReceiptMasterTable, "DiscountAmt");            
			lblTotalAmt.DataBindings.Add("Text", myPOS.ReceiptMasterTable, "mTotalAmount");
			lblMembershipID.DataBindings.Add("Text", myPOS.ReceiptMasterTable, "strMembershipID");
			lblMemberName.DataBindings.Add("Text", myPOS.ReceiptMasterTable, "strMemberName");
			lblTherapistID.DataBindings.Add("Text", myPOS.ReceiptMasterTable, "nTherapistID");
			lblTherapistName.DataBindings.Add("Text", myPOS.ReceiptMasterTable, "strTherapistName");
			lblSalesPersonName.DataBindings.Add("Text", myPOS.ReceiptMasterTable, "strSalesPersonName");
            lblLocation.DataBindings.Add("Text", myPOS.ReceiptMasterTable, "strLocation");
		}

		private void btnF1_Click(object sender, System.EventArgs e)
		{
			if (myPOS == null) return;
			
			if (myPOS.NPOSCategoryID == 3) return;

			AddItemsFreebieAndItemDiscount();
		}

		private void AddNewItem()
		{
            if (myPOS.NCategoryID == 1 || myPOS.NCategoryID == 2 || 
				myPOS.NCategoryID == 3 || myPOS.NCategoryID == 4 || 
				myPOS.NCategoryID == 5 || myPOS.NCategoryID == 6 || 
				myPOS.NCategoryID == 7 || myPOS.NCategoryID == 8 || 
				myPOS.NCategoryID == 9 || myPOS.NCategoryID == 11 ||
                myPOS.NCategoryID == 12 || myPOS.NCategoryID == 14 || 
                myPOS.NCategoryID == 36 || myPOS.NCategoryID == 37 ||
                myPOS.NCategoryID == 23 || myPOS.NCategoryID == 24)
			{

                if (myPOS.NCategoryID == 11 || myPOS.NCategoryID == 12)
                {

                    if (!myIsFinishLoadStockRecon)
                    {
                        connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"];
                        connection = new SqlConnection(connectionString);

                        // StartProgressBar

                        BackgroundWorker bw = new BackgroundWorker();
                        bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                        bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
                      
                        m_fmProgress = new fmProgress();
                        bw.RunWorkerAsync();
                        m_fmProgress.ShowDialog(this);
                        m_fmProgress = null;

                        //StartProgressBar 
                        myIsFinishLoadStockRecon = true;
                    }
                }

				ACMSPOS2.FormAddCreditPackage form = new ACMS.ACMSPOS2.FormAddCreditPackage(myPOS);
			
				form.ShowDialog(this);
                if (myPOS.ReceiptItemsTable.Rows.Count > 0)
                {
                    if (myPOS.ReceiptItemsTable.Rows[myPOS.ReceiptItemsTable.Rows.Count - 1]["strCode"].ToString() == "ADMIN")
                        gridColumnListPrice.OptionsColumn.AllowEdit = true;
                }                
			}
		}


        #region Synchronous BackgroundWorker Thread


        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            // Do some long running task...
            SqlHelper.ExecuteNonQuery(connection, "dw_sp_SCStockRecon");

            if (m_fmProgress.Cancel)
            {
                e.Cancel = true;
                return;
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            // Hide the Progress Form
            if (m_fmProgress != null)
            {
                m_fmProgress.Hide();
                m_fmProgress = null;
            }

            // Check to see if an error occured in the 
            // background process.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                return;
            }

            // Check to see if the background process was cancelled.
            if (e.Cancelled)
            {
                MessageBox.Show("Processing cancelled.");
                return;
            }

            // Everything completed normally.
            // process the response using e.Result
            //   MessageBox.Show("Processing is complete.");
        }

        #endregion

		private void AddItemsFreebieAndItemDiscount()
		{
			if (myPOS.NCategoryID == 14 || myPOS.NCategoryID == 15 ||
				myPOS.NCategoryID == 16 || myPOS.NCategoryID == 17 ||
				myPOS.NCategoryID == 20 || myPOS.NCategoryID == 21 ||
				myPOS.NCategoryID == 22 || myPOS.NCategoryID == 23 ||
                myPOS.NCategoryID == 0)
			{
				MessageBox.Show(string.Format("Category ID : {0} is not allow to apply Item Freebie", myPOS.NCategoryID.ToString()));
				return;
			}
			ACMS.XtraUtils.GridViewUtils.UpdateData(GridView1);

			DataRow r = GridView1.GetDataRow(GridView1.FocusedRowHandle);
			
			if (r != null)
			{
				ACMSPOS2.FormAddItemFreebiesAndDiscount frm =
                    new ACMS.ACMSPOS2.FormAddItemFreebiesAndDiscount(myPOS, r, GetCategoryTypeID(myPOS.NCategoryID), myIsFinishLoadStockRecon);
			
				frm.ShowDialog(this);
			}
		}


		private int GetCategoryTypeID(int nCategoryID)
		{
			if (nCategoryID == 1 || nCategoryID == 2 || nCategoryID == 3 ||
                nCategoryID == 4 || nCategoryID == 5 || nCategoryID == 6 || nCategoryID == 34 || nCategoryID == 36 || nCategoryID == 37)
			{
				return 2;
			}
			else if (nCategoryID == 7)
			{
				return 4;
			}
			else if (nCategoryID == 8 || nCategoryID == 9)
			{
				return 3;
			}
			else if (nCategoryID == 11 || nCategoryID == 12)
			{
				return 1;
			}
			else if (nCategoryID == 10)
			{
				if (myPOS.WantToUpgradeMemberPackageTable != null && myPOS.WantToUpgradeMemberPackageTable.Rows.Count > 0)
				{
					return GetCategoryTypeID(ACMS.Convert.ToInt32(myPOS.WantToUpgradeMemberPackageRow["nCategoryID"]));
				}
				else
					return 0;
			}
			else
				return 0;
		}

		private void sBtnAdd_Click(object sender, System.EventArgs e)
		{
			ACMS.XtraUtils.GridViewUtils.UpdateData(GridView1);

			DataRow r = GridView1.GetDataRow(GridView1.FocusedRowHandle);

			if (r != null)
			{
				decimal qty = ACMS.Convert.ToInt32(r["nQuantity"]);
			
				qty += 1;

				r["nQuantity"] = qty;
			}
		}

		private void sBtnSubtract_Click(object sender, System.EventArgs e)
		{
			ACMS.XtraUtils.GridViewUtils.UpdateData(GridView1);

			DataRow r = GridView1.GetDataRow(GridView1.FocusedRowHandle);

			if (r != null)
			{
				decimal qty = ACMS.Convert.ToInt32(r["nQuantity"]);
			

				qty -= 1;
				
				if ( myPOS.NCategoryID != 11 && myPOS.NCategoryID != 12)
					r["nQuantity"] = qty < 0 ? 0 : qty;
				else
					r["nQuantity"] = qty;
			}
		}

		private void btnF2_Click(object sender, System.EventArgs e)
		{
            DataRow r = GridView1.GetDataRow(GridView1.FocusedRowHandle);//jackie 06032012

            string strDescription = r["strDescription"].ToString();


          //  if (strDescription == "DIGITAL LOCK" || strDescription == "Extend Member GIRO package")
                if (strDescription == "DIGITAL LOCK" )
            {
                return;
            }
            else
            {
                if (myPOS == null) return;

                if (myPOS.NPOSCategoryID == 3) return;

                AddSalesPersonAndTherapist();
            }



            
            //if (myPOS == null) return;

            //if (myPOS.NPOSCategoryID == 3) return;

            //AddSalesPersonAndTherapist();
		}

		private void btnF4_Click(object sender, System.EventArgs e)
		{
			if (myPOS == null) return;

            if (myPOS.NPOSCategoryID == 3) return;
            if (myPOS.NCategoryID == 35) return;

			AddBillFreebies();
		}

		private void AddBillFreebies()
		{
            ACMSPOS2.FormAddBillFreebie frm = new ACMS.ACMSPOS2.FormAddBillFreebie(myPOS, myIsFinishLoadStockRecon);
			frm.ShowDialog(this);
		}

		private void AddNewReward()
		{
			ACMSPOS2.FormAddRewards frm = new ACMS.ACMSPOS2.FormAddRewards(myPOS);
			frm.ShowDialog(this);
		}

		private void AddSalesPersonAndTherapist()
		{
			ACMSPOS2.FormAddSalesPersonAndTherapist frm = new ACMS.ACMSPOS2.FormAddSalesPersonAndTherapist(myPOS);
			frm.ShowDialog(this);
		}

		private void AddBillDiscount(DataRow myRow)
		{
            ACMSPOS2.FormBillDiscount frm = new ACMS.ACMSPOS2.FormBillDiscount(myPOS, myRow);
			frm.ShowDialog(this);
		}

		private void Tender()
		{
			if (myPOS.NCategoryID == 1 || myPOS.NCategoryID == 2 || myPOS.NCategoryID == 3 ||
				myPOS.NCategoryID == 4 || myPOS.NCategoryID == 5 || myPOS.NCategoryID == 6 ||
				myPOS.NCategoryID == 7 || myPOS.NCategoryID == 8 || myPOS.NCategoryID == 9 ||
                myPOS.NCategoryID == 10 || myPOS.NCategoryID == 11 || myPOS.NCategoryID == 12 ||
                myPOS.NCategoryID == 36 || myPOS.NCategoryID == 37 || 
                myPOS.NCategoryID == 18 || myPOS.NCategoryID == 19 || myPOS.NCategoryID == 34)
			{
				if (!myPOS.NSalespersonID.HasValue)
				{
					DialogResult result1 = MessageBox.Show(this, "Sales Person is empty. Do you want to add it now? ", "Warning", 
						MessageBoxButtons.YesNo);

					if (result1 == DialogResult.Yes)
					{
						btnF2.PerformClick();
						return;
					}
					else
					{
						return;
					}
				}
              

			}

			ACMS.ACMSPOS2.FormTender frm = new ACMS.ACMSPOS2.FormTender(myPOS);
			DialogResult result = frm.ShowDialog(this);

			if (result == DialogResult.OK)
			{
				
				ACMSLogic.POSCommand command = ACMSLogic.POSCommand.Create();
				command.SavePOS(myPOS);
				command.PrintReceipt(myPOS);
				this.Close();
			}
		}

		private void btnF5_Click(object sender, System.EventArgs e)
		{
			if (myPOS == null) return;
			
			if (myPOS.NPOSCategoryID == 3) return;
			
			if (myPOS.IsStaffPurchase) return;

			AddNewReward();
		}

		private void btnF3_Click(object sender, System.EventArgs e)
		{

			if (myPOS == null) return;
			
			if (myPOS.NPOSCategoryID == 3) return;

            ACMS.XtraUtils.GridViewUtils.UpdateData(GridView1);

            DataRow r = GridView1.GetDataRow(GridView1.FocusedRowHandle);

            if (r != null)
            {
                AddBillDiscount(r);
            }

			
		}

		private void btnF7_Click(object sender, System.EventArgs e)
		{
            double mDepositAmount = 0;

            if (myPOS.ReceiptMasterTable.Rows[0]["strParentReceiptNo"].ToString() != "")
            {
                DataSet _ds = new DataSet();
                DataTable _dt;
                string cmdText = "Select mTotalAmount from tblReceipt where strReceiptNo=@strReceiptNo ";
                SqlHelper.FillDataset(connection, CommandType.Text, cmdText, _ds, new string[] { "Table" }, new SqlParameter("@strReceiptNo", myPOS.ReceiptMasterTable.Rows[0]["strParentReceiptNo"].ToString()));

                _dt = _ds.Tables["Table"];
                mDepositAmount = Convert.ToDouble(_dt.Rows[0]["mTotalAmount"]);
                _dt.Dispose();
                _ds.Dispose();
            }

            if (Convert.ToDouble(myPOS.ReceiptMasterTable.Rows[0]["mTotalAmount"]) + mDepositAmount < 500 && myPOS.IsNeedMinTopUp && myPOS.WantToUpgradeMemberPackageTable.Rows.Count > 0)
            {
                MessageBox.Show(this, "Bill total must be at least 500.");
                return;
            }
            DataRow r = GridView1.GetDataRow(GridView1.FocusedRowHandle);//jackie
            string strDescription="";
            if (r != null)
            {
                strDescription = r["strDescription"].ToString();

                if (strDescription == "DIGITAL LOCK" || strDescription == "Extend Member GIRO package")
                {
                    TenderLock_DIGITAL_LOCK();
                    return;
                }
                else
                {
                    Tender();
                    return;
                }                       

            }            
		}

        private void TenderLock_DIGITAL_LOCK()
        {
            
            //this.lblSalesperson
            this.lblSalesperson.Text = "";
            this.lblSalesPersonName.Text = "";
            lblSalesperson.DataBindings.Clear();
            lblSalesPersonName.DataBindings.Clear();

            ACMS.ACMSPOS2.FormTender frm = new ACMS.ACMSPOS2.FormTender(myPOS);
            DialogResult result = frm.ShowDialog(this);

            if (result == DialogResult.OK)
            {

                ACMSLogic.POSCommand command = ACMSLogic.POSCommand.Create();
                command.SavePOS(myPOS);
                command.PrintReceipt(myPOS);
                this.Close();
            }
        }

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			Delete();
		}

		private void Delete()
		{
			ACMS.XtraUtils.GridViewUtils.UpdateData(GridView1);

			DataRow r = GridView1.GetDataRow(GridView1.FocusedRowHandle);

			if (r != null)
			{
				int nEntryID = ACMS.Convert.ToInt32(r["nEntryID"]);
				
				if (myPOS.NCategoryID == 15)
				{
					string strDescription = r["strDescription"].ToString();
					if (strDescription == "Locker Deposit")return;
				}
				myPOS.Delete(nEntryID);	
	
			}
		}

		private void btnF8_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

        private void nbiPackage010_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FormInitialise(10, e.Link.ItemName, 0);

            ACMS.ACMSPOS2.FormUpgradePackage frm = new ACMS.ACMSPOS2.FormUpgradePackage(myPOS);
            frm.ShowDialog(this);
        }

		private void nbiPackage012_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
            FormInitialise(18, e.Link.ItemName, 0);

			ACMS.ACMSPOS2.FormTopUpCredit frm = new ACMS.ACMSPOS2.FormTopUpCredit(myPOS);
			frm.ShowDialog(this);
		}

		private void nbiMiscellaneous003_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
            FormInitialise(16, e.Link.ItemName, 0);
			OnConfirmLockerDeposit();
		}
		
		private void OnConfirmLockerDeposit()
		{
			ACMSDAL.TblBranch branch = new ACMSDAL.TblBranch();
			branch.StrBranchCode = myPOS.StrBranchCode;
			branch.SelectOne();

			decimal lockerDeposit = ACMS.Convert.ToDecimal(branch.MLockerDepositRate);

			ACMSDAL.TblMember member = new ACMSDAL.TblMember();
			member.StrMembershipID = myPOS.StrMembershipID;
			member.SelectOne();

			if (myPOS.ReceiptItemsTable.Rows.Count == 0)
			{
				ACMSDAL.TblLocker sqlLocker = new ACMSDAL.TblLocker();

				DataTable table = sqlLocker.GetOccupiedLocker(myPOS.StrBranchCode, myPOS.StrMembershipID);
				
				if (table.Rows.Count > 0)
				{
					MessageBox.Show(this, "Please return your locker before a new Deposit can make.");
					return;
				}

				if (!member.FLockerDeposit.IsNull)
				{
					if (member.FLockerDeposit.IsTrue)
						MessageBox.Show(this, "Deposit has been saved in system.");
					else
					{
						DialogResult result = MessageBox.Show(this, string.Format("Locker Deposit is $ {0}, Continue?", lockerDeposit), "Add Deposit", MessageBoxButtons.OKCancel);
						if (result == DialogResult.OK)			
							myPOS.NewReceiptEntry(myPOS.StrMembershipID, -1, "Locker Deposit", 1, lockerDeposit, myPOS.StrMembershipID);
					}
				}
				else
				{
					DialogResult result = MessageBox.Show(this, string.Format("Locker Deposit is $ {0}, Continue?", lockerDeposit), "Add Deposit", MessageBoxButtons.OKCancel);
					if (result == DialogResult.OK)			
						myPOS.NewReceiptEntry(myPOS.StrMembershipID, -1, "Locker Deposit", 1, lockerDeposit, myPOS.StrMembershipID);
				}
			}
			else
			{
				MessageBox.Show(this, "Only one deposit is allow in one receipt.");
			}
		}

		private void OnConfirmForgetCard()
		{
			ACMSPOS2.FormForgetCardAction frm = new ACMS.ACMSPOS2.FormForgetCardAction(myPOS);
			frm.ShowDialog(this);
		}

		private void OnLockerRental()
		{
			ACMSPOS2.FormLockerAction frm = new ACMS.ACMSPOS2.FormLockerAction(myPOS);
			frm.ShowDialog(this);
		}

		private void OnAddMineralWater()
		{
			if (myPOS.ReceiptItemsTable.Rows.Count > 0)
			{
				DialogResult result = MessageBox.Show(this, 
					"Only one item is allow. Do you want to overwrite the existing one?", "Warning", MessageBoxButtons.YesNo);

				if (result == DialogResult.No)
					return;
				else
					myPOS.ReceiptItemsTable.Rows.Clear();
			}

			ACMSLogic.POSHelper posHelper= new ACMSLogic.POSHelper(myPOS);
			DataTable table = posHelper.GetDataTable();

			if (table.Rows.Count > 0)
			{
				DataRow row = table.Rows[0];
 
				ACMS.ACMSPOS2.FormMineralWaterClosingDayCount frm = new ACMS.ACMSPOS2.FormMineralWaterClosingDayCount();
				
				if (frm.ShowDialog(this) == DialogResult.OK)
				{
					
					//TblProductInventory productInventory = new TblProductInventory();
                    DataSet _ds;                    
                    _ds = new DataSet();
                    DataTable productInventorytable;
                    SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "dw_sp_SCStockReconItem", _ds, new string[] { "Table" }, new SqlParameter("@BranchCode", myPOS.StrBranchCode), new SqlParameter("@strProductCode", "MW"));
					//DataTable productInventorytable = productInventory.GetProductQty(row["strProductCode"].ToString(), myPOS.StrBranchCode);
                    productInventorytable = _ds.Tables["Table"];

					if (productInventorytable.Rows.Count > 0)
					{
						int initialQty = ACMS.Convert.ToInt32(productInventorytable.Rows[0]["nQty"]);

						if (frm.Qty > initialQty)
						{
							//MessageBox.Show(this, "Please Open a carton (hint: Menu > Tools > Open A Carton)");
                            MessageBox.Show(this, "Qty entered is more than current stock balance");
							return;
						}
						else if (initialQty > frm.Qty)
						{
							int diff = initialQty - frm.Qty;
							decimal mineralWaterUnitPrice = ACMS.Convert.ToDecimal(row["mBaseUnitPrice"]);
							decimal totalSales = decimal.Round(diff * mineralWaterUnitPrice, 2);

							ACMSLogic.POSEntries posEntry = myPOS.NewReceiptEntry(row["strProductCode"].ToString(), -1, "Mineral Water Sales", diff, mineralWaterUnitPrice, "");
							posEntry.POSEntryRow["MineralWaterQty"] = diff;
						}
					}
					else
					{
						MessageBox.Show(this, "No Mineral Water in the branch.");
					}
				}
			}
			else
			{
				MessageBox.Show(this, "No Mineral Water in the branch.");
			}
		}

        private void OnAddCashVoucher()
        {
            ACMS.ACMSPOS2.FormCashVoucher frm = new ACMS.ACMSPOS2.FormCashVoucher();
            myPOS.NQty = frm.Qty;
            ACMSLogic.POSHelper posHelper = new ACMSLogic.POSHelper(myPOS);
            DataTable table = posHelper.GetDataTable();

            if (table.Rows.Count > 0)
            {
                //DataRow row = table.Rows[0];               

                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    string cmdText;
                    DataSet _ds;
                    _ds = new DataSet();
                    DataTable cvTable;

                    cmdText = "Select top " + frm.Qty.ToString() + " * from tblCashVoucher where strbranchcode=@strBranchCode and nTerminalID=@nTerminalID and fsell=1 and nstatusid=0 ORDER BY strSN ";
                    SqlHelper.FillDataset(connection, CommandType.Text, cmdText, _ds, new string[] { "Table" }, new SqlParameter("@strBranchCode", myPOS.StrBranchCode), new SqlParameter("@nTerminalID", myPOS.NTerminalID));
                                        
                    cvTable = _ds.Tables["Table"];

                    foreach (DataRow row in cvTable.Rows)                    
                    {                                                
                        //int diff = initialQty - frm.Qty;
                        //decimal mineralWaterUnitPrice = ACMS.Convert.ToDecimal(row["mBaseUnitPrice"]);
                        //decimal totalSales = decimal.Round(diff * mineralWaterUnitPrice, 2);

                        ACMSLogic.POSEntries posEntry = myPOS.NewReceiptEntry(row["strSN"].ToString(), 38, row["strDescription"].ToString(), 1, Convert.ToDecimal(row["mValue"]), "");                        
                    }                    
                }
            }
            else
            {
                MessageBox.Show(this, "No Cash Voucher available in the branch.");
            }
        }

		private void OnReplaceMembershipCard()
		{
			if (myPOS.ReceiptItemsTable.Rows.Count > 0)
			{
				DialogResult result = MessageBox.Show(this, 
					"Only one item is allow. Do you want to overwrite the existing one?", "Warning", MessageBoxButtons.YesNo);

				if (result == DialogResult.No)
					return;
				else
					myPOS.ReceiptItemsTable.Rows.Clear();
			}

			string membershipID = myPOS.StrMembershipID;
			bool isMember = !membershipID.StartsWith("NMC");
		
			TblCompany sqlCompany = new TblCompany();
			DataTable compTable = sqlCompany.SelectAll();
				
			decimal replaceCardRate = ACMS.Convert.ToDecimal(compTable.Rows[0]["mReplaceCardRate"]);

			if (!isMember)
			{

				int nextNonMemberNo = ACMS.Convert.ToInt32(compTable.Rows[0]["nNonMembershipNo"]) + 1;					
				string newStrMembershipID = "NMC" + nextNonMemberNo.ToString();
				string origStrMembershipID = myPOS.StrMembershipID;
				
				myPOS.NewReceiptEntry(newStrMembershipID, -1, 
					string.Format("Replace New Member Card. Possible ID : {0}", newStrMembershipID), 
					1, replaceCardRate, origStrMembershipID);
				
			}
			else
			{
				TblBranch sqlbranch = new TblBranch();
				sqlbranch.StrBranchCode = myPOS.StrBranchCode;
				sqlbranch.SelectOne();

				
				int nextNonMemberNo = sqlbranch.NMembershipNo.Value + 1;					
				string newStrMembershipID = myPOS.StrBranchCode.TrimEnd() + nextNonMemberNo.ToString();
				string origStrMembershipID = myPOS.StrMembershipID;
				
				myPOS.NewReceiptEntry(newStrMembershipID, -1, 
					string.Format("Replace New Member Card. Possible ID : {0}", newStrMembershipID), 
					1, replaceCardRate, origStrMembershipID);
                StrNewMembershipID = newStrMembershipID;
			}
		}

		private void nbiMiscellaneous008_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
            FormInitialise(0, e.Link.ItemName, 0);
			ACMSPOS2.FormPayOutstanding frm = new ACMS.ACMSPOS2.FormPayOutstanding(myPOS);
			frm.ShowDialog(this);
		}

        private void nbiMiscellaneous009_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FormInitialise(38, e.Link.ItemName, 0);
            OnAddCashVoucher();
            //AddNewItem();
        }

		private void nbiPackage001_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
            FormInitialise(1, e.Link.ItemName, 0);
			AddNewItem();
		}

		private void nbiPackage002_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
            FormInitialise(2, e.Link.ItemName, 0);
			AddNewItem();
		}

		private void nbiPackage003_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
            FormInitialise(3, e.Link.ItemName, 0);
			AddNewItem();
		}

		private void nbiPackage004_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
            FormInitialise(4, e.Link.ItemName, 0);
			AddNewItem();
		}

		private void nbiPackage005_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
            FormInitialise(5, e.Link.ItemName, 0);
			AddNewItem();
		}

		private void nbiPackage006_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
            FormInitialise(6, e.Link.ItemName, 0);
			AddNewItem();
		}

		private void nbiPackage007_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
            FormInitialise(7, e.Link.ItemName, 0);
			AddNewItem();
		}

        private void nbiPackage036_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {            
            FormInitialise(36, e.Link.ItemName, 0);            
            AddNewItem();
        }

        private void nbiPackage037_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {   
            FormInitialise(37, e.Link.ItemName, 0);
            AddNewItem();
        }

		private void nbiPackage008_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
            FormInitialise(8, e.Link.ItemName, 0);
			AddNewItem();
		}

		private void nbiPackage009_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
            FormInitialise(9, e.Link.ItemName, 0);
			AddNewItem();
		}

		private void nbiProduct001_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
            FormInitialise(11, e.Link.ItemName, 0);
			AddNewItem();
		}

		private void nbiProduct002_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
            FormInitialise(12, e.Link.ItemName, 0);
			AddNewItem();
		}

		private void nbiMiscellaneous001_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
            FormInitialise(14, e.Link.ItemName, 0);
			AddNewItem();
		}

		private void nbiMiscellaneous007_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
            FormInitialise(23, e.Link.ItemName, 0);
			AddNewItem();
		}

		private void nbiMiscellaneous002_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			//locker rental
            FormInitialise(15, e.Link.ItemName, 0);
			OnLockerRental();
		}

		private void nbiMiscellaneous004_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			//Forget Card Deposit
            FormInitialise(17, e.Link.ItemName, 0);
			OnConfirmForgetCard();
		}

		private void nbiMiscellaneous005_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			//Replace membership Card
            FormInitialise(20, e.Link.ItemName, 0);
			OnReplaceMembershipCard();
		}

		private void nbiMiscellaneous006_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
            FormInitialise(21, e.Link.ItemName, 0);
			OnAddMineralWater();
		}

		private void nbiPackage011_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
            FormInitialise(19, e.Link.ItemName, 0);
			ACMS.ACMSPOS2.FormTopUpSingleTreatment form = new ACMS.ACMSPOS2.FormTopUpSingleTreatment(myPOS);
			form.ShowDialog(this);
		}

		private void btnF6_Click(object sender, System.EventArgs e)
		{
			if (myPOS == null) return;
			OnAddIPP();
		}

		private void OnAddIPP()
		{
			ACMSPOS2.frmIPP_Add frm = new ACMS.ACMSPOS2.frmIPP_Add(myPOS);
			frm.ShowDialog(this);
		}

		private void FormPOS2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			
			if ((e.KeyCode == Keys.F1) &&
				btnF1.Enabled)
			{
				btnF1.PerformClick();
			}
			else if ((e.KeyCode == Keys.F2) &&
				btnF2.Enabled)
			{
				btnF2.PerformClick();
			}
			else if ((e.KeyCode == Keys.F3) && btnF3.Enabled)
			{
				btnF3.PerformClick();
			}
			else if ((e.KeyCode == Keys.F4) &&
				btnF4.Enabled)
			{
				btnF4.PerformClick();
			}
			else if ((e.KeyCode == Keys.F5) &&
				btnF5.Enabled)
			{
				btnF5.PerformClick();
			}
			else if ((e.KeyCode == Keys.F6) &&
				btnF6.Enabled)
			{
				btnF6.PerformClick();
			}
			else if ((e.KeyCode == Keys.F7) &&
				btnF7.Enabled)
			{
				btnF7.PerformClick();
			}
			else if ((e.KeyCode == Keys.F8) &&
				btnF8.Enabled)
			{
				btnF8.PerformClick();
			}
            else if ((e.KeyCode == Keys.F9) &&
                btnF9.Enabled)
            {
                btnF9.PerformClick();
            }
			else if ((e.KeyCode == Keys.Add) &&
				sBtnAdd.Enabled)
			{
				sBtnAdd.PerformClick();
			}
			else if ((e.KeyCode == Keys.Subtract) &&
				sBtnSubtract.Enabled)
			{
				sBtnSubtract.PerformClick();
			}
			else if ((e.KeyCode == Keys.Delete) &&
				simpleButton1.Enabled)
			{
				simpleButton1.PerformClick();
			}
		}

		private void btnEnter_Click(object sender, System.EventArgs e)
		{
			ACMSLogic.POSHelper helper = new ACMSLogic.POSHelper(myPOS);

			DataTable table = null;

			if (myPOS.NCategoryID == 11 || myPOS.NCategoryID == 12)
				table = helper.SearchOneProductCode(txtScannedCode.Text);
			else if (myPOS.NCategoryID == 1 || myPOS.NCategoryID == 2 || myPOS.NCategoryID == 3 ||
				myPOS.NCategoryID == 4 || myPOS.NCategoryID == 5 || myPOS.NCategoryID == 6 ||
				myPOS.NCategoryID == 8 || myPOS.NCategoryID == 7 || myPOS.NCategoryID == 9 )
			{
				table = helper.SearchOnePackageCode(txtScannedCode.Text);
			}

			if (table != null && table.Rows.Count == 1)
			{
				DataRow r = table.Rows[0];
				int qty = ACMS.Convert.ToInt32(calcEditQty.Value);
				
				if (myPOS.NCategoryID == 11 || myPOS.NCategoryID == 12)
				{
					myPOS.NewReceiptEntry(r["strProductCode"].ToString(),
						myPOS.StaffPurchaseCategoryID, r["strDescription"].ToString(),
						qty, ACMS.Convert.ToDecimal(r["mBaseUnitPrice"]), "");
				}
				else if (myPOS.NCategoryID == 1 || myPOS.NCategoryID == 3 || myPOS.NCategoryID == 2 ||
					myPOS.NCategoryID == 4 || myPOS.NCategoryID == 5 || myPOS.NCategoryID == 6)
				{
					myPOS.NewReceiptEntry(r["strPackageCode"].ToString(),
						myPOS.StaffPurchaseCategoryID, r["strDescription"].ToString(),
						qty, ACMS.Convert.ToDecimal(r["mListPrice"]), "");
				}
				if (myPOS.NCategoryID == 7)
				{
					myPOS.NewReceiptEntry(r["strCreditPackageCode"].ToString(),
						myPOS.StaffPurchaseCategoryID, r["strDescription"].ToString(),
						qty, ACMS.Convert.ToDecimal(r["mListPrice"]), "");
				}
				if (myPOS.NCategoryID == 8 || myPOS.NCategoryID == 9)
				{
					myPOS.NewReceiptEntry(r["strPackageGroupCode"].ToString(),
						myPOS.StaffPurchaseCategoryID, r["strDescription"].ToString(),
						qty, ACMS.Convert.ToDecimal(r["mListPrice"]), "");
				}		

				txtScannedCode.Text = "";
				txtScannedCode.Focus();
			}
			else
			{
				MessageBox.Show(this, "Cant Find any product.");
				txtScannedCode.Text = "";
				txtScannedCode.Focus();
			}
		}

		private void txtScannedCode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btnEnter.PerformClick();
				e.Handled = true;
			}
		}

		private void calcEditQty_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btnEnter.PerformClick();
            }
		}

		private void NavBarControl1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void navGiro_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			FormInitialise(2, e.Link.ItemName,0);
            AddNewItem();
		}

		private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			FormInitialise(35, e.Link.ItemName,1);//GIRO Link

			ACMS.ACMSPOS2.UpdateMemberGiro frm = new ACMS.ACMSPOS2.UpdateMemberGiro(myPOS);
			frm.ShowDialog(this);
		}

		private void navDeposit_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
		{
			FormInitialise(24, e.Link.ItemName,0);
			myPOS.NewReceiptEntry("Deposit", -1,"Deposit", 1, 0, "");
		}

		private void txtScannedCode_EditValueChanged(object sender, System.EventArgs e)
		{
		
		}

        private void btnF2_Click_1(object sender, EventArgs e)
        {

        }

        private void btnF3_Click_1(object sender, EventArgs e)
        {

        }

        private void btnF5_Click_1(object sender, EventArgs e)
        {

        }

        private void navSpaGiro_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            FormInitialise(34, e.Link.ItemName,0);

            ACMS.ACMSPOS2.GIROpkg frm = new ACMS.ACMSPOS2.GIROpkg(myPOS);
            frm.ShowDialog(this);
        }

        private void navBarMaintainSpaGiro_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            FormInitialise(34, e.Link.ItemName,0);

            ACMS.ACMSPOS2.UpdateMemberGiro frm = new ACMS.ACMSPOS2.UpdateMemberGiro(myPOS);
            frm.ShowDialog(this);
        }

        private void navConvertSpa_LinkClicked(object sender, NavBarLinkEventArgs e)
        {


                FormInitialise(35, e.Link.ItemName,0);
                ACMS.ACMSPOS2.FormConvertPackage frm = new ACMS.ACMSPOS2.FormConvertPackage(myPOS);
			frm.ShowDialog(this);

        }

        private void btnF9_Click(object sender, EventArgs e)
        {               
            if (myPOS == null) return;

            if (myPOS.NCategoryID != 1 && myPOS.NCategoryID != 3 && myPOS.NCategoryID != 4 && myPOS.NCategoryID != 5 && myPOS.NCategoryID != 6 && myPOS.NCategoryID != 7 && myPOS.NCategoryID != 8 && myPOS.NCategoryID != 9 && myPOS.NCategoryID != 36 && myPOS.NCategoryID != 37) return;
            
            //ACMSDAL.TblMemberPackage sqlCalcAnyOS1 = new ACMSDAL.TblMemberPackage();
            //decimal dOutAmount = sqlCalcAnyOS1.OutstandingAmount(myPOS.StrMembershipID);

            //if (dOutAmount > 0)
            //{
            //    MessageBox.Show("Please clear outstanding balance before proceed to package conversion.");
            //    return;                
            //}                 

            ACMS.ACMSPOS2.FormUpgradePackageNew frm = new ACMS.ACMSPOS2.FormUpgradePackageNew(myPOS);            
            frm.ShowDialog(this);
            

            groupControl5.Left = 122;           
			lblUpgradeFrom.Text = "";
            
            if (myPOS.WantToUpgradeMemberPackageTable.Rows.Count > 0)            
			{         
				groupControl5.Left = 10;
                label13.Visible = true;
                groupControl6.Visible = true;
                myPOS.RecalculateAll();
                string strRemarks = "Convert From:\n";
                for (int i = 0; i < myPOS.WantToUpgradeMemberPackageTable.Rows.Count; i++)
                {
                    string strCatInd = "";
                    int mainSession = Convert.ToInt32(myPOS.WantToUpgradeMemberPackageTable.Rows[i]["nMaxSession"]) - Convert.ToInt32(myPOS.WantToUpgradeMemberPackageTable.Rows[i]["nFreeSession"]);
                    int usedSession = Convert.ToInt32(myPOS.WantToUpgradeMemberPackageTable.Rows[i]["UsedSession"]);
                    int balSession = mainSession - usedSession;
                    if (myPOS.WantToUpgradeMemberPackageTable.Rows[i]["nCategoryID"].ToString() == "7" || myPOS.WantToUpgradeMemberPackageTable.Rows[i]["nCategoryID"].ToString() == "36" || myPOS.WantToUpgradeMemberPackageTable.Rows[i]["nCategoryID"].ToString() == "37")
                        strCatInd = "(C)";
                    if (myPOS.WantToUpgradeMemberPackageTable.Rows[i]["nCategoryID"].ToString() == "8" || myPOS.WantToUpgradeMemberPackageTable.Rows[i]["nCategoryID"].ToString() == "9")
                        strCatInd = "(B)";
                    lblUpgradeFrom.Text += myPOS.WantToUpgradeMemberPackageTable.Rows[i]["nPackageID"].ToString() + strCatInd +  " / " + myPOS.WantToUpgradeMemberPackageTable.Rows[i]["strReceiptNo"].ToString() + " / " + myPOS.WantToUpgradeMemberPackageTable.Rows[i]["strPackageCode"].ToString() + " : " + string.Format("{0:0.00}", myPOS.WantToUpgradeMemberPackageTable.Rows[i]["UsageBalAmt"]) + "\n";
                    strRemarks += myPOS.WantToUpgradeMemberPackageTable.Rows[i]["nPackageID"].ToString() + strCatInd + " / " + myPOS.WantToUpgradeMemberPackageTable.Rows[i]["strReceiptNo"].ToString() + " / " + myPOS.WantToUpgradeMemberPackageTable.Rows[i]["strPackageCode"].ToString() + " : " + string.Format("{0:0.00}", myPOS.WantToUpgradeMemberPackageTable.Rows[i]["UsageBalAmt"]) + "\n";                     
                }                
                myPOS.ReceiptMasterTable.Rows[0]["strRemarks"] = strRemarks;
                myPOS.ReceiptMasterTable.Rows[0]["mUpgradeAmount"] = myPOS.WantToUpgradeMemberPackageTable.Compute("SUM(UsageBalAmt)", "");                
                lblUsageBal.Text = string.Format("{0:0.00}", myPOS.WantToUpgradeMemberPackageTable.Compute("SUM(UsageBalAmt)",""));                             
            }
            else
            {
                myPOS.RecalculateAll();
                groupControl6.Visible = false;
            }
        }
	}
}
