using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using DevExpress.XtraPivotGrid;
using Do = Acms.Core.Domain;
using ACMSLogic;
using ACMS.Utils;
using System.Data.OleDb;

namespace ACMS.ACMSManager.Reports
{
	/// <summary>
	/// Summary description for RPSpaDailyBranchSales.
	/// </summary>
	public class RPSpaDailyBranchSales : System.Windows.Forms.Form
	{
		private Do.Employee employee;
		private Do.TerminalUser terminalUser; 
		User oUser;

		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraGrid.GridControl gridReceipt;
		private DevExpress.XtraGrid.Views.Grid.GridView gvReceipt;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraPivotGrid.PivotGridControl GridTotalCollection;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
		private DevExpress.XtraEditors.DateEdit dateEdit1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private DevExpress.XtraGrid.GridControl GridSingleTreatment;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.GridControl gridSpaPackage;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private DevExpress.XtraGrid.GridControl gridVouchers;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		private DevExpress.XtraGrid.GridControl gridFreeSpa;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
		private System.Windows.Forms.Label label9;
		private DevExpress.XtraGrid.GridControl gridTreatment;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private DevExpress.XtraGrid.GridControl GridIPLPackage;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
		private DevExpress.XtraGrid.GridControl GridSpaProduct;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
		private System.Windows.Forms.Label label12;
		private DevExpress.XtraGrid.GridControl gridCreditPackage;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
		private DevExpress.XtraEditors.ImageComboBoxEdit cmbBranch;
		private System.ComponentModel.IContainer components;
		private DevExpress.XtraGrid.Views.Grid.GridView gvReceiptPayment;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
		private bool isFinishReportInit = false;

		private DataTable SalesCollectionTable;
		private DataTable SpaSingleTreatmentTable;
		private DataTable SpaPackageTable;
		private DataTable SpaProductTable;
		private DataTable SpaFreeMenuTable;
		private DataTable IPLPackageTable;
		private DataTable SpaCreditAccountTable;
		private DataTable VoucherTable;
		private DataTable SpaTreatmentTable;
		private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
		private DevExpress.XtraEditors.HyperLinkEdit PRINT1;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink2;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink3;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink4;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink5;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink6;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink7;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink8;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink9;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink10;
		private DevExpress.XtraEditors.HyperLinkEdit PRINT2;
		private DevExpress.XtraEditors.HyperLinkEdit PRINT3;
		private DevExpress.XtraEditors.HyperLinkEdit PRINT4;
		private DevExpress.XtraEditors.HyperLinkEdit PRINT5;
		private DevExpress.XtraEditors.HyperLinkEdit PRINT6;
		private DevExpress.XtraEditors.HyperLinkEdit PRINT7;
		private DevExpress.XtraEditors.HyperLinkEdit PRINT8;
		private DevExpress.XtraEditors.HyperLinkEdit PRINT9;


		#region Initialize Data from Login
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


		public RPSpaDailyBranchSales()
		{
			//
			// Required for Windows Form Designer support
			//
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.components = new System.ComponentModel.Container();
			DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
			this.gvReceiptPayment = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridReceipt = new DevExpress.XtraGrid.GridControl();
			this.gvReceipt = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridTotalCollection = new DevExpress.XtraPivotGrid.PivotGridControl();
			this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.GridSingleTreatment = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridSpaPackage = new DevExpress.XtraGrid.GridControl();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.gridVouchers = new DevExpress.XtraGrid.GridControl();
			this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridFreeSpa = new DevExpress.XtraGrid.GridControl();
			this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.label9 = new System.Windows.Forms.Label();
			this.gridTreatment = new DevExpress.XtraGrid.GridControl();
			this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.GridIPLPackage = new DevExpress.XtraGrid.GridControl();
			this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridSpaProduct = new DevExpress.XtraGrid.GridControl();
			this.gridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.label12 = new System.Windows.Forms.Label();
			this.gridCreditPackage = new DevExpress.XtraGrid.GridControl();
			this.gridView8 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.cmbBranch = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
			this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
			this.printableComponentLink2 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
			this.printableComponentLink3 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
			this.printableComponentLink4 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
			this.printableComponentLink5 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
			this.printableComponentLink6 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
			this.printableComponentLink7 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
			this.printableComponentLink8 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
			this.printableComponentLink9 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
			this.printableComponentLink10 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
			this.PRINT1 = new DevExpress.XtraEditors.HyperLinkEdit();
			this.PRINT2 = new DevExpress.XtraEditors.HyperLinkEdit();
			this.PRINT3 = new DevExpress.XtraEditors.HyperLinkEdit();
			this.PRINT4 = new DevExpress.XtraEditors.HyperLinkEdit();
			this.PRINT5 = new DevExpress.XtraEditors.HyperLinkEdit();
			this.PRINT6 = new DevExpress.XtraEditors.HyperLinkEdit();
			this.PRINT7 = new DevExpress.XtraEditors.HyperLinkEdit();
			this.PRINT8 = new DevExpress.XtraEditors.HyperLinkEdit();
			this.PRINT9 = new DevExpress.XtraEditors.HyperLinkEdit();
			((System.ComponentModel.ISupportInitialize)(this.gvReceiptPayment)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridReceipt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvReceipt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridTotalCollection)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridSingleTreatment)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridSpaPackage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridVouchers)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridFreeSpa)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridTreatment)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridIPLPackage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridSpaProduct)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridCreditPackage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView8)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbBranch.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT2.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT3.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT4.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT5.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT6.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT7.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT8.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT9.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// gvReceiptPayment
			// 
			this.gvReceiptPayment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									this.gridColumn27,
																									this.gridColumn28});
			this.gvReceiptPayment.GridControl = this.gridReceipt;
			this.gvReceiptPayment.Name = "gvReceiptPayment";
			this.gvReceiptPayment.OptionsBehavior.Editable = false;
			this.gvReceiptPayment.OptionsCustomization.AllowColumnMoving = false;
			this.gvReceiptPayment.OptionsCustomization.AllowColumnResizing = false;
			this.gvReceiptPayment.OptionsCustomization.AllowFilter = false;
			this.gvReceiptPayment.OptionsCustomization.AllowSort = false;
			this.gvReceiptPayment.OptionsMenu.EnableColumnMenu = false;
			this.gvReceiptPayment.OptionsMenu.EnableGroupPanelMenu = false;
			this.gvReceiptPayment.OptionsPrint.ExpandAllDetails = true;
			this.gvReceiptPayment.OptionsPrint.PrintDetails = true;
			this.gvReceiptPayment.OptionsPrint.UsePrintStyles = true;
			this.gvReceiptPayment.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn27
			// 
			this.gridColumn27.Caption = "Payment Code";
			this.gridColumn27.FieldName = "Payment Code";
			this.gridColumn27.Name = "gridColumn27";
			this.gridColumn27.Visible = true;
			this.gridColumn27.VisibleIndex = 0;
			// 
			// gridColumn28
			// 
			this.gridColumn28.Caption = "Amount";
			this.gridColumn28.FieldName = "Amount";
			this.gridColumn28.Name = "gridColumn28";
			this.gridColumn28.Visible = true;
			this.gridColumn28.VisibleIndex = 1;
			// 
			// gridReceipt
			// 
			// 
			// gridReceipt.EmbeddedNavigator
			// 
			this.gridReceipt.EmbeddedNavigator.Name = "";
			gridLevelNode1.LevelTemplate = this.gvReceiptPayment;
			gridLevelNode1.RelationName = "ReceiptPayment";
			this.gridReceipt.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
																								  gridLevelNode1});
			this.gridReceipt.Location = new System.Drawing.Point(16, 56);
			this.gridReceipt.MainView = this.gvReceipt;
			this.gridReceipt.Name = "gridReceipt";
			this.gridReceipt.Size = new System.Drawing.Size(624, 184);
			this.gridReceipt.TabIndex = 0;
			this.gridReceipt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									   this.gvReceipt,
																									   this.gvReceiptPayment});
			// gvReceipt
			// 
			this.gvReceipt.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn1,
																							 this.gridColumn2});
			this.gvReceipt.GridControl = this.gridReceipt;
			this.gvReceipt.Name = "gvReceipt";
			this.gvReceipt.OptionsBehavior.AutoExpandAllGroups = true;
			this.gvReceipt.OptionsCustomization.AllowSort = false;
			this.gvReceipt.OptionsPrint.ExpandAllDetails = true;
			this.gvReceipt.OptionsPrint.PrintDetails = true;
			this.gvReceipt.OptionsPrint.UsePrintStyles = true;
			this.gvReceipt.OptionsView.ShowGroupedColumns = true;
			this.gvReceipt.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Receipt No";
			this.gridColumn1.FieldName = "strReceiptNo";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			this.gridColumn1.Width = 297;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Shift";
			this.gridColumn2.FieldName = "nShiftID";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			this.gridColumn2.Width = 313;
			// 
			// GridTotalCollection
			// 
			this.GridTotalCollection.Cursor = System.Windows.Forms.Cursors.Default;
			this.GridTotalCollection.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
																									   this.pivotGridField1,
																									   this.pivotGridField2});
			this.GridTotalCollection.Location = new System.Drawing.Point(648, 56);
			this.GridTotalCollection.Name = "GridTotalCollection";
			this.GridTotalCollection.OptionsCustomization.AllowDrag = false;
			this.GridTotalCollection.OptionsCustomization.AllowExpand = false;
			this.GridTotalCollection.OptionsCustomization.AllowFilter = false;
			this.GridTotalCollection.OptionsCustomization.AllowSort = false;
			this.GridTotalCollection.OptionsView.ShowColumnHeaders = false;
			this.GridTotalCollection.OptionsView.ShowDataHeaders = false;
			this.GridTotalCollection.OptionsView.ShowFilterHeaders = false;
			this.GridTotalCollection.Size = new System.Drawing.Size(272, 184);
			this.GridTotalCollection.TabIndex = 1;
			// 
			// pivotGridField1
			// 
			this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField1.AreaIndex = 0;
			this.pivotGridField1.Caption = "Payment Mode";
			this.pivotGridField1.FieldName = "strPaymentCode";
			this.pivotGridField1.Name = "pivotGridField1";
			// 
			// pivotGridField2
			// 
			this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.pivotGridField2.AreaIndex = 0;
			this.pivotGridField2.Caption = "Amount";
			this.pivotGridField2.FieldName = "mAmount";
			this.pivotGridField2.Name = "pivotGridField2";
			// 
			// dateEdit1
			// 
			this.dateEdit1.EditValue = null;
			this.dateEdit1.Location = new System.Drawing.Point(56, 8);
			this.dateEdit1.Name = "dateEdit1";
			// 
			// dateEdit1.Properties
			// 
			this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit1.Size = new System.Drawing.Size(96, 20);
			this.dateEdit1.TabIndex = 2;
			this.dateEdit1.EditValueChanged += new System.EventHandler(this.dateEdit1_EditValueChanged);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Date";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(168, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Branch";
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(24, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(144, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Receipt Generated";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(648, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(176, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Total Collection";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// GridSingleTreatment
			// 
			// 
			// GridSingleTreatment.EmbeddedNavigator
			// 
			this.GridSingleTreatment.EmbeddedNavigator.Name = "";
			this.GridSingleTreatment.Location = new System.Drawing.Point(16, 272);
			this.GridSingleTreatment.MainView = this.gridView1;
			this.GridSingleTreatment.Name = "GridSingleTreatment";
			this.GridSingleTreatment.Size = new System.Drawing.Size(464, 184);
			this.GridSingleTreatment.TabIndex = 8;
			this.GridSingleTreatment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											   this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn3,
																							 this.gridColumn4,
																							 this.gridColumn5});
			this.gridView1.GridControl = this.GridSingleTreatment;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsBehavior.Editable = false;
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsCustomization.AllowSort = false;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Code";
			this.gridColumn3.FieldName = "Code";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 0;
			this.gridColumn3.Width = 55;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Description";
			this.gridColumn4.FieldName = "Description";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 1;
			this.gridColumn4.Width = 155;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "Total";
			this.gridColumn5.FieldName = "Quantity";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 2;
			this.gridColumn5.Width = 80;
			// 
			// gridSpaPackage
			// 
			// 
			// gridSpaPackage.EmbeddedNavigator
			// 
			this.gridSpaPackage.EmbeddedNavigator.Name = "";
			this.gridSpaPackage.Location = new System.Drawing.Point(488, 272);
			this.gridSpaPackage.MainView = this.gridView2;
			this.gridSpaPackage.Name = "gridSpaPackage";
			this.gridSpaPackage.Size = new System.Drawing.Size(432, 184);
			this.gridSpaPackage.TabIndex = 9;
			this.gridSpaPackage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										  this.gridView2});
			// 
			// gridView2
			// 
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn6,
																							 this.gridColumn7,
																							 this.gridColumn8});
			this.gridView2.GridControl = this.gridSpaPackage;
			this.gridView2.Name = "gridView2";
			this.gridView2.OptionsBehavior.Editable = false;
			this.gridView2.OptionsCustomization.AllowFilter = false;
			this.gridView2.OptionsCustomization.AllowSort = false;
			this.gridView2.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn6
			// 
			this.gridColumn6.Caption = "Code";
			this.gridColumn6.FieldName = "Code";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 0;
			this.gridColumn6.Width = 55;
			// 
			// gridColumn7
			// 
			this.gridColumn7.Caption = "Description";
			this.gridColumn7.FieldName = "Description";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 1;
			this.gridColumn7.Width = 155;
			// 
			// gridColumn8
			// 
			this.gridColumn8.Caption = "Total";
			this.gridColumn8.FieldName = "Quantity";
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.Visible = true;
			this.gridColumn8.VisibleIndex = 2;
			this.gridColumn8.Width = 80;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.Location = new System.Drawing.Point(24, 248);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(176, 23);
			this.label5.TabIndex = 10;
			this.label5.Text = "Spa Single Treatment";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.Location = new System.Drawing.Point(488, 248);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(176, 23);
			this.label6.TabIndex = 11;
			this.label6.Text = "Spa Package";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label7.Location = new System.Drawing.Point(488, 912);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(176, 23);
			this.label7.TabIndex = 15;
			this.label7.Text = "Vouchers";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label8.Location = new System.Drawing.Point(24, 912);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(176, 23);
			this.label8.TabIndex = 14;
			this.label8.Text = "Free Spa Menu Trial";
			// 
			// gridVouchers
			// 
			// 
			// gridVouchers.EmbeddedNavigator
			// 
			this.gridVouchers.EmbeddedNavigator.Name = "";
			this.gridVouchers.Location = new System.Drawing.Point(488, 936);
			this.gridVouchers.MainView = this.gridView3;
			this.gridVouchers.Name = "gridVouchers";
			this.gridVouchers.Size = new System.Drawing.Size(432, 160);
			this.gridVouchers.TabIndex = 13;
			this.gridVouchers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView3});
			// 
			// gridView3
			// 
			this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn9,
																							 this.gridColumn10,
																							 this.gridColumn11});
			this.gridView3.GridControl = this.gridVouchers;
			this.gridView3.Name = "gridView3";
			this.gridView3.OptionsBehavior.Editable = false;
			this.gridView3.OptionsCustomization.AllowFilter = false;
			this.gridView3.OptionsCustomization.AllowSort = false;
			this.gridView3.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn9
			// 
			this.gridColumn9.Caption = "Code";
			this.gridColumn9.FieldName = "Code";
			this.gridColumn9.Name = "gridColumn9";
			this.gridColumn9.Visible = true;
			this.gridColumn9.VisibleIndex = 0;
			this.gridColumn9.Width = 55;
			// 
			// gridColumn10
			// 
			this.gridColumn10.Caption = "Description";
			this.gridColumn10.FieldName = "Description";
			this.gridColumn10.Name = "gridColumn10";
			this.gridColumn10.Visible = true;
			this.gridColumn10.VisibleIndex = 1;
			this.gridColumn10.Width = 155;
			// 
			// gridColumn11
			// 
			this.gridColumn11.Caption = "Total";
			this.gridColumn11.FieldName = "Quantity";
			this.gridColumn11.Name = "gridColumn11";
			this.gridColumn11.Visible = true;
			this.gridColumn11.VisibleIndex = 2;
			this.gridColumn11.Width = 80;
			// 
			// gridFreeSpa
			// 
			// 
			// gridFreeSpa.EmbeddedNavigator
			// 
			this.gridFreeSpa.EmbeddedNavigator.Name = "";
			this.gridFreeSpa.Location = new System.Drawing.Point(16, 936);
			this.gridFreeSpa.MainView = this.gridView4;
			this.gridFreeSpa.Name = "gridFreeSpa";
			this.gridFreeSpa.Size = new System.Drawing.Size(464, 160);
			this.gridFreeSpa.TabIndex = 12;
			this.gridFreeSpa.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									   this.gridView4});
			// 
			// gridView4
			// 
			this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn12,
																							 this.gridColumn13,
																							 this.gridColumn14});
			this.gridView4.GridControl = this.gridFreeSpa;
			this.gridView4.Name = "gridView4";
			this.gridView4.OptionsBehavior.Editable = false;
			this.gridView4.OptionsCustomization.AllowFilter = false;
			this.gridView4.OptionsCustomization.AllowSort = false;
			this.gridView4.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn12
			// 
			this.gridColumn12.Caption = "Code";
			this.gridColumn12.FieldName = "Code";
			this.gridColumn12.Name = "gridColumn12";
			this.gridColumn12.Visible = true;
			this.gridColumn12.VisibleIndex = 0;
			this.gridColumn12.Width = 55;
			// 
			// gridColumn13
			// 
			this.gridColumn13.Caption = "Description";
			this.gridColumn13.FieldName = "Description";
			this.gridColumn13.Name = "gridColumn13";
			this.gridColumn13.Visible = true;
			this.gridColumn13.VisibleIndex = 1;
			this.gridColumn13.Width = 155;
			// 
			// gridColumn14
			// 
			this.gridColumn14.Caption = "Total";
			this.gridColumn14.FieldName = "Quantity";
			this.gridColumn14.Name = "gridColumn14";
			this.gridColumn14.Visible = true;
			this.gridColumn14.VisibleIndex = 2;
			this.gridColumn14.Width = 80;
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label9.Location = new System.Drawing.Point(24, 688);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(176, 23);
			this.label9.TabIndex = 17;
			this.label9.Text = "Treatment";
			// 
			// gridTreatment
			// 
			// 
			// gridTreatment.EmbeddedNavigator
			// 
			this.gridTreatment.EmbeddedNavigator.Name = "";
			this.gridTreatment.Location = new System.Drawing.Point(16, 704);
			this.gridTreatment.MainView = this.gridView5;
			this.gridTreatment.Name = "gridTreatment";
			this.gridTreatment.Size = new System.Drawing.Size(464, 192);
			this.gridTreatment.TabIndex = 16;
			this.gridTreatment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										 this.gridView5});
			// 
			// gridView5
			// 
			this.gridView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn15,
																							 this.gridColumn16,
																							 this.gridColumn17});
			this.gridView5.GridControl = this.gridTreatment;
			this.gridView5.Name = "gridView5";
			this.gridView5.OptionsBehavior.Editable = false;
			this.gridView5.OptionsCustomization.AllowFilter = false;
			this.gridView5.OptionsCustomization.AllowSort = false;
			this.gridView5.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn15
			// 
			this.gridColumn15.Caption = "Code";
			this.gridColumn15.FieldName = "Code";
			this.gridColumn15.Name = "gridColumn15";
			this.gridColumn15.Visible = true;
			this.gridColumn15.VisibleIndex = 0;
			this.gridColumn15.Width = 55;
			// 
			// gridColumn16
			// 
			this.gridColumn16.Caption = "Description";
			this.gridColumn16.FieldName = "Description";
			this.gridColumn16.Name = "gridColumn16";
			this.gridColumn16.Visible = true;
			this.gridColumn16.VisibleIndex = 1;
			this.gridColumn16.Width = 155;
			// 
			// gridColumn17
			// 
			this.gridColumn17.Caption = "Total";
			this.gridColumn17.FieldName = "Quantity";
			this.gridColumn17.Name = "gridColumn17";
			this.gridColumn17.Visible = true;
			this.gridColumn17.VisibleIndex = 2;
			this.gridColumn17.Width = 80;
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label10.Location = new System.Drawing.Point(488, 464);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(224, 23);
			this.label10.TabIndex = 21;
			this.label10.Text = "IPL Package";
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label11.Location = new System.Drawing.Point(24, 464);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(176, 23);
			this.label11.TabIndex = 20;
			this.label11.Text = "Spa Product";
			// 
			// GridIPLPackage
			// 
			// 
			// GridIPLPackage.EmbeddedNavigator
			// 
			this.GridIPLPackage.EmbeddedNavigator.Name = "";
			this.GridIPLPackage.Location = new System.Drawing.Point(488, 488);
			this.GridIPLPackage.MainView = this.gridView6;
			this.GridIPLPackage.Name = "GridIPLPackage";
			this.GridIPLPackage.Size = new System.Drawing.Size(432, 192);
			this.GridIPLPackage.TabIndex = 19;
			this.GridIPLPackage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										  this.gridView6});
			// 
			// gridView6
			// 
			this.gridView6.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn18,
																							 this.gridColumn19,
																							 this.gridColumn20});
			this.gridView6.GridControl = this.GridIPLPackage;
			this.gridView6.Name = "gridView6";
			this.gridView6.OptionsBehavior.Editable = false;
			this.gridView6.OptionsCustomization.AllowFilter = false;
			this.gridView6.OptionsCustomization.AllowSort = false;
			this.gridView6.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn18
			// 
			this.gridColumn18.Caption = "Code";
			this.gridColumn18.FieldName = "Code";
			this.gridColumn18.Name = "gridColumn18";
			this.gridColumn18.Visible = true;
			this.gridColumn18.VisibleIndex = 0;
			this.gridColumn18.Width = 55;
			// 
			// gridColumn19
			// 
			this.gridColumn19.Caption = "Description";
			this.gridColumn19.FieldName = "Description";
			this.gridColumn19.Name = "gridColumn19";
			this.gridColumn19.Visible = true;
			this.gridColumn19.VisibleIndex = 1;
			this.gridColumn19.Width = 155;
			// 
			// gridColumn20
			// 
			this.gridColumn20.Caption = "Total";
			this.gridColumn20.FieldName = "Quantity";
			this.gridColumn20.Name = "gridColumn20";
			this.gridColumn20.Visible = true;
			this.gridColumn20.VisibleIndex = 2;
			this.gridColumn20.Width = 80;
			// 
			// GridSpaProduct
			// 
			// 
			// GridSpaProduct.EmbeddedNavigator
			// 
			this.GridSpaProduct.EmbeddedNavigator.Name = "";
			this.GridSpaProduct.Location = new System.Drawing.Point(16, 488);
			this.GridSpaProduct.MainView = this.gridView7;
			this.GridSpaProduct.Name = "GridSpaProduct";
			this.GridSpaProduct.Size = new System.Drawing.Size(464, 192);
			this.GridSpaProduct.TabIndex = 18;
			this.GridSpaProduct.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										  this.gridView7});
			// 
			// gridView7
			// 
			this.gridView7.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn21,
																							 this.gridColumn22,
																							 this.gridColumn23});
			this.gridView7.GridControl = this.GridSpaProduct;
			this.gridView7.Name = "gridView7";
			this.gridView7.OptionsBehavior.Editable = false;
			this.gridView7.OptionsCustomization.AllowFilter = false;
			this.gridView7.OptionsCustomization.AllowSort = false;
			this.gridView7.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn21
			// 
			this.gridColumn21.Caption = "Code";
			this.gridColumn21.FieldName = "Code";
			this.gridColumn21.Name = "gridColumn21";
			this.gridColumn21.Visible = true;
			this.gridColumn21.VisibleIndex = 0;
			this.gridColumn21.Width = 55;
			// 
			// gridColumn22
			// 
			this.gridColumn22.Caption = "Description";
			this.gridColumn22.FieldName = "Description";
			this.gridColumn22.Name = "gridColumn22";
			this.gridColumn22.Visible = true;
			this.gridColumn22.VisibleIndex = 1;
			this.gridColumn22.Width = 155;
			// 
			// gridColumn23
			// 
			this.gridColumn23.Caption = "Total";
			this.gridColumn23.FieldName = "Quantity";
			this.gridColumn23.Name = "gridColumn23";
			this.gridColumn23.Visible = true;
			this.gridColumn23.VisibleIndex = 2;
			this.gridColumn23.Width = 80;
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label12.Location = new System.Drawing.Point(488, 688);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(176, 23);
			this.label12.TabIndex = 25;
			this.label12.Text = "Credit Package Sales";
			// 
			// gridCreditPackage
			// 
			// 
			// gridCreditPackage.EmbeddedNavigator
			// 
			this.gridCreditPackage.EmbeddedNavigator.Name = "";
			this.gridCreditPackage.Location = new System.Drawing.Point(488, 704);
			this.gridCreditPackage.MainView = this.gridView8;
			this.gridCreditPackage.Name = "gridCreditPackage";
			this.gridCreditPackage.Size = new System.Drawing.Size(432, 192);
			this.gridCreditPackage.TabIndex = 23;
			this.gridCreditPackage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											 this.gridView8});
			// 
			// gridView8
			// 
			this.gridView8.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn24,
																							 this.gridColumn25,
																							 this.gridColumn26});
			this.gridView8.GridControl = this.gridCreditPackage;
			this.gridView8.Name = "gridView8";
			this.gridView8.OptionsBehavior.Editable = false;
			this.gridView8.OptionsCustomization.AllowFilter = false;
			this.gridView8.OptionsCustomization.AllowSort = false;
			this.gridView8.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn24
			// 
			this.gridColumn24.Caption = "Code";
			this.gridColumn24.FieldName = "Code";
			this.gridColumn24.Name = "gridColumn24";
			this.gridColumn24.Visible = true;
			this.gridColumn24.VisibleIndex = 0;
			this.gridColumn24.Width = 55;
			// 
			// gridColumn25
			// 
			this.gridColumn25.Caption = "Description";
			this.gridColumn25.FieldName = "Description";
			this.gridColumn25.Name = "gridColumn25";
			this.gridColumn25.Visible = true;
			this.gridColumn25.VisibleIndex = 1;
			this.gridColumn25.Width = 155;
			// 
			// gridColumn26
			// 
			this.gridColumn26.Caption = "Total";
			this.gridColumn26.FieldName = "Quantity";
			this.gridColumn26.Name = "gridColumn26";
			this.gridColumn26.Visible = true;
			this.gridColumn26.VisibleIndex = 2;
			this.gridColumn26.Width = 80;
			// 
			// cmbBranch
			// 
			this.cmbBranch.Location = new System.Drawing.Point(232, 8);
			this.cmbBranch.Name = "cmbBranch";
			// 
			// cmbBranch.Properties
			// 
			this.cmbBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbBranch.Size = new System.Drawing.Size(144, 20);
			this.cmbBranch.TabIndex = 26;
			this.cmbBranch.SelectedValueChanged += new System.EventHandler(this.cmbBranch_SelectedValueChanged);
			// 
			// printingSystem1
			// 
			this.printingSystem1.Links.AddRange(new object[] {
																 this.printableComponentLink1,
																 this.printableComponentLink2,
																 this.printableComponentLink3,
																 this.printableComponentLink4,
																 this.printableComponentLink5,
																 this.printableComponentLink6,
																 this.printableComponentLink7,
																 this.printableComponentLink8,
																 this.printableComponentLink9,
																 this.printableComponentLink10});
			// 
			// printableComponentLink1
			// 
			this.printableComponentLink1.Component = this.gridReceipt;
			this.printableComponentLink1.EnablePageDialog = false;
			this.printableComponentLink1.PrintingSystem = this.printingSystem1;
			this.printableComponentLink1.CreateReportHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(this.printableComponentLink1_CreateReportHeaderArea);
			// 
			// printableComponentLink2
			// 
			this.printableComponentLink2.Component = this.GridTotalCollection;
			this.printableComponentLink2.PrintingSystem = this.printingSystem1;
			this.printableComponentLink2.CreateReportHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(this.printableComponentLink2_CreateReportHeaderArea);
			// 
			// printableComponentLink3
			// 
			this.printableComponentLink3.Component = this.GridSingleTreatment;
			this.printableComponentLink3.PrintingSystem = this.printingSystem1;
			this.printableComponentLink3.CreateReportHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(this.printableComponentLink3_CreateReportHeaderArea);
			// 
			// printableComponentLink4
			// 
			this.printableComponentLink4.Component = this.gridSpaPackage;
			this.printableComponentLink4.PrintingSystem = this.printingSystem1;
			this.printableComponentLink4.CreateReportHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(this.printableComponentLink4_CreateReportHeaderArea);
			// 
			// printableComponentLink5
			// 
			this.printableComponentLink5.Component = this.GridSpaProduct;
			this.printableComponentLink5.PrintingSystem = this.printingSystem1;
			this.printableComponentLink5.CreateReportHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(this.printableComponentLink5_CreateReportHeaderArea);
			// 
			// printableComponentLink6
			// 
			this.printableComponentLink6.Component = this.GridIPLPackage;
			this.printableComponentLink6.PrintingSystem = this.printingSystem1;
			this.printableComponentLink6.CreateReportHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(this.printableComponentLink6_CreateReportHeaderArea);
			// 
			// printableComponentLink7
			// 
			this.printableComponentLink7.Component = this.gridTreatment;
			this.printableComponentLink7.PrintingSystem = this.printingSystem1;
			this.printableComponentLink7.CreateReportHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(this.printableComponentLink7_CreateReportHeaderArea);
			// 
			// printableComponentLink8
			// 
			this.printableComponentLink8.Component = this.gridCreditPackage;
			this.printableComponentLink8.PrintingSystem = this.printingSystem1;
			this.printableComponentLink8.CreateReportHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(this.printableComponentLink8_CreateReportHeaderArea);
			// 
			// printableComponentLink9
			// 
			this.printableComponentLink9.Component = this.gridFreeSpa;
			this.printableComponentLink9.PrintingSystem = this.printingSystem1;
			this.printableComponentLink9.CreateReportHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(this.printableComponentLink9_CreateReportHeaderArea);
			// 
			// printableComponentLink10
			// 
			this.printableComponentLink10.Component = this.gridVouchers;
			this.printableComponentLink10.PrintingSystem = this.printingSystem1;
			this.printableComponentLink10.CreateReportHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(this.printableComponentLink10_CreateReportHeaderArea);
			// 
			// PRINT1
			// 
			this.PRINT1.EditValue = "PRINT";
			this.PRINT1.Location = new System.Drawing.Point(424, 8);
			this.PRINT1.Name = "PRINT1";
			// 
			// PRINT1.Properties
			// 
			this.PRINT1.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.PRINT1.Properties.Appearance.Options.UseBackColor = true;
			this.PRINT1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.PRINT1.Size = new System.Drawing.Size(40, 18);
			this.PRINT1.TabIndex = 141;
			this.PRINT1.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.PRINT1_OpenLink);
			// 
			// PRINT2
			// 
			this.PRINT2.EditValue = "PRINT";
			this.PRINT2.Location = new System.Drawing.Point(432, 248);
			this.PRINT2.Name = "PRINT2";
			// 
			// PRINT2.Properties
			// 
			this.PRINT2.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.PRINT2.Properties.Appearance.Options.UseBackColor = true;
			this.PRINT2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.PRINT2.Size = new System.Drawing.Size(40, 18);
			this.PRINT2.TabIndex = 142;
			this.PRINT2.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.PRINT2_OpenLink);
			// 
			// PRINT3
			// 
			this.PRINT3.EditValue = "PRINT";
			this.PRINT3.Location = new System.Drawing.Point(848, 248);
			this.PRINT3.Name = "PRINT3";
			// 
			// PRINT3.Properties
			// 
			this.PRINT3.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.PRINT3.Properties.Appearance.Options.UseBackColor = true;
			this.PRINT3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.PRINT3.Size = new System.Drawing.Size(40, 18);
			this.PRINT3.TabIndex = 143;
			this.PRINT3.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.PRINT3_OpenLink);
			// 
			// PRINT4
			// 
			this.PRINT4.EditValue = "PRINT";
			this.PRINT4.Location = new System.Drawing.Point(432, 464);
			this.PRINT4.Name = "PRINT4";
			// 
			// PRINT4.Properties
			// 
			this.PRINT4.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.PRINT4.Properties.Appearance.Options.UseBackColor = true;
			this.PRINT4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.PRINT4.Size = new System.Drawing.Size(40, 18);
			this.PRINT4.TabIndex = 144;
			this.PRINT4.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.PRINT4_OpenLink);
			// 
			// PRINT5
			// 
			this.PRINT5.EditValue = "PRINT";
			this.PRINT5.Location = new System.Drawing.Point(848, 464);
			this.PRINT5.Name = "PRINT5";
			// 
			// PRINT5.Properties
			// 
			this.PRINT5.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.PRINT5.Properties.Appearance.Options.UseBackColor = true;
			this.PRINT5.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.PRINT5.Size = new System.Drawing.Size(40, 18);
			this.PRINT5.TabIndex = 145;
			this.PRINT5.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.PRINT5_OpenLink);
			// 
			// PRINT6
			// 
			this.PRINT6.EditValue = "PRINT";
			this.PRINT6.Location = new System.Drawing.Point(432, 680);
			this.PRINT6.Name = "PRINT6";
			// 
			// PRINT6.Properties
			// 
			this.PRINT6.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.PRINT6.Properties.Appearance.Options.UseBackColor = true;
			this.PRINT6.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.PRINT6.Size = new System.Drawing.Size(40, 18);
			this.PRINT6.TabIndex = 146;
			this.PRINT6.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.PRINT6_OpenLink);
			// 
			// PRINT7
			// 
			this.PRINT7.EditValue = "PRINT";
			this.PRINT7.Location = new System.Drawing.Point(848, 680);
			this.PRINT7.Name = "PRINT7";
			// 
			// PRINT7.Properties
			// 
			this.PRINT7.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.PRINT7.Properties.Appearance.Options.UseBackColor = true;
			this.PRINT7.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.PRINT7.Size = new System.Drawing.Size(40, 18);
			this.PRINT7.TabIndex = 147;
			this.PRINT7.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.PRINT7_OpenLink);
			// 
			// PRINT8
			// 
			this.PRINT8.EditValue = "PRINT";
			this.PRINT8.Location = new System.Drawing.Point(432, 912);
			this.PRINT8.Name = "PRINT8";
			// 
			// PRINT8.Properties
			// 
			this.PRINT8.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.PRINT8.Properties.Appearance.Options.UseBackColor = true;
			this.PRINT8.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.PRINT8.Size = new System.Drawing.Size(40, 18);
			this.PRINT8.TabIndex = 148;
			this.PRINT8.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.PRINT8_OpenLink);
			// 
			// PRINT9
			// 
			this.PRINT9.EditValue = "PRINT";
			this.PRINT9.Location = new System.Drawing.Point(848, 912);
			this.PRINT9.Name = "PRINT9";
			// 
			// PRINT9.Properties
			// 
			this.PRINT9.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.PRINT9.Properties.Appearance.Options.UseBackColor = true;
			this.PRINT9.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.PRINT9.Size = new System.Drawing.Size(40, 18);
			this.PRINT9.TabIndex = 149;
			this.PRINT9.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.PRINT9_OpenLink);
			// 
			// RPSpaDailyBranchSales
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(859, 384);
			this.Controls.Add(this.GridSingleTreatment);
			this.Controls.Add(this.gridSpaPackage);
			this.Controls.Add(this.gridVouchers);
			this.Controls.Add(this.gridFreeSpa);
			this.Controls.Add(this.gridTreatment);
			this.Controls.Add(this.GridIPLPackage);
			this.Controls.Add(this.GridSpaProduct);
			this.Controls.Add(this.gridCreditPackage);
			this.Controls.Add(this.PRINT9);
			this.Controls.Add(this.PRINT8);
			this.Controls.Add(this.PRINT7);
			this.Controls.Add(this.PRINT6);
			this.Controls.Add(this.PRINT5);
			this.Controls.Add(this.PRINT4);
			this.Controls.Add(this.PRINT3);
			this.Controls.Add(this.PRINT2);
			this.Controls.Add(this.PRINT1);
			this.Controls.Add(this.cmbBranch);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dateEdit1);
			this.Controls.Add(this.GridTotalCollection);
			this.Controls.Add(this.gridReceipt);
			this.DockPadding.Bottom = 20;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "RPSpaDailyBranchSales";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Spa Daily Branch Sales";
			this.TopMost = true;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.RPSpaDailyBranchSales_Load);
			((System.ComponentModel.ISupportInitialize)(this.gvReceiptPayment)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridReceipt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvReceipt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridTotalCollection)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridSingleTreatment)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridSpaPackage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridVouchers)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridFreeSpa)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridTreatment)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridIPLPackage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridSpaProduct)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridCreditPackage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView8)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbBranch.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT2.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT3.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT4.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT5.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT6.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT7.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT8.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT9.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	
		private void RPSpaDailyBranchSales_Load(object sender, System.EventArgs e)
		{
			dateEdit1.EditValue = DateTime.Today;
			isFinishReportInit = false;
			BindCategory();
			isFinishReportInit = true;
			LoadReport();
		} 


		private void LoadReport()
		{
			if (!isFinishReportInit)
				return;
			
			DataSet dsSpaBranchSales = SqlHelperUtils.ExecuteDatasetSP("up_get_SpaBranchSales",
				new SqlParameter("@instrBranchCode", cmbBranch.EditValue.ToString()),
				new SqlParameter("@indtDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, dateEdit1.EditValue));
	
			SalesCollectionTable = dsSpaBranchSales.Tables[0];			
			SpaSingleTreatmentTable = dsSpaBranchSales.Tables[1];
			SpaPackageTable = dsSpaBranchSales.Tables[2];
			SpaProductTable = dsSpaBranchSales.Tables[3];
			SpaFreeMenuTable = dsSpaBranchSales.Tables[4];
			IPLPackageTable = dsSpaBranchSales.Tables[5];
			SpaCreditAccountTable = dsSpaBranchSales.Tables[6];
			VoucherTable = dsSpaBranchSales.Tables[7];
			SpaTreatmentTable = dsSpaBranchSales.Tables[8];
			
			

			//*** Receipt Table

			SqlCommand myCmd2 = new SqlCommand("up_get_SpaBranchSalesReceipt", connection);
			myCmd2.CommandTimeout = 0;
			myCmd2.CommandType = CommandType.StoredProcedure;
			myCmd2.Parameters.Add("@strBranchCode", cmbBranch.EditValue.ToString()); 
			myCmd2.Parameters.Add("@dtDate",Convert.ToDateTime(dateEdit1.EditValue).ToString("yyyy/MM/dd")); 
			SqlDataAdapter SpaBranchSalesReceiptDA = new SqlDataAdapter(myCmd2); 
			DataSet dsSpaBranchSalesReceipt = new DataSet();
			SpaBranchSalesReceiptDA.Fill(dsSpaBranchSalesReceipt);
/*
			DataSet dsSpaBranchSalesReceipt = SqlHelperUtils.ExecuteDatasetSP("up_get_SpaBranchSalesReceipt",
				new SqlParameter("@strBranchCode", cmbBranch.EditValue.ToString()),
				new SqlParameter("@dtDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, dateEdit1.EditValue));
			*/	

			DataTable dtReceipt = dsSpaBranchSalesReceipt.Tables[0];
			DataTable dtPayment = dsSpaBranchSalesReceipt.Tables[1];

			string[] parentColNames = {"strReceiptNo"};
			string[] childColNames = {"Receipt No"};
		
			DataColumn[] pc = new DataColumn[1];
			pc[0] = dtReceipt.Columns["strReceiptNo"];

			DataColumn[] cc = new DataColumn[1];
			cc[0] = dtPayment.Columns["Receipt No"];

			if(!dsSpaBranchSalesReceipt.Relations.Contains("ShiftPayment")) 
			{ 
				if (dtPayment.Rows.Count > 0) 
				{ 
					DataRelation relation = new DataRelation ("ReceiptPayment",pc,cc,false); 
					dsSpaBranchSalesReceipt.Relations.Add(relation); 
				} 
			} 
			gridReceipt.DataSource = dtReceipt;
			//*******************
			

			GridTotalCollection.DataSource = SalesCollectionTable;
			GridSingleTreatment.DataSource = SpaSingleTreatmentTable;
			gridSpaPackage.DataSource = SpaPackageTable;
			GridSpaProduct.DataSource = SpaProductTable;
			gridFreeSpa.DataSource = SpaFreeMenuTable;
			GridIPLPackage.DataSource = IPLPackageTable;
			gridCreditPackage.DataSource = SpaCreditAccountTable;
			gridVouchers.DataSource = VoucherTable;
			gridTreatment.DataSource = SpaTreatmentTable;

			this.ResumeLayout();


		}
		
		private void BindCategory()
		{
			string strSQL = "select * from tblEmployeeBranchRights where nEmployeeID='" + employee.Id + "'";
			
			comboBind(cmbBranch, strSQL, "strBranchCode", "strBranchCode", true);
			cmbBranch.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem("- Please Select -",""));
			cmbBranch.SelectedIndex = 0;
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

		private void dateEdit1_EditValueChanged(object sender, System.EventArgs e)
		{
			LoadReport();
		}

		private void cmbBranch_SelectedValueChanged(object sender, System.EventArgs e)
		{
			LoadReport();
		}

		private void PRINT1_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
		{
			
			//compositeLink1.Links[0].PageHeaderFooter = "Receipt";
			printableComponentLink1.CreateDocument();
			printableComponentLink1.PrintingSystem.Print();

			printableComponentLink2.CreateDocument();
			printableComponentLink2.PrintingSystem.Print();
		}


		private void printableComponentLink1_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
		{
			string reportHeader = "Receipt Generated";
			e.Graph.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(System.Drawing.StringAlignment.Center);
			e.Graph.Font = new Font("Tahoma", 10, FontStyle.Bold);
			RectangleF rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50);
			e.Graph.DrawString(reportHeader, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None);
		
		}

		private void printableComponentLink2_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
		{
			string reportHeader = "Total Collection";
			e.Graph.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(System.Drawing.StringAlignment.Center);
			e.Graph.Font = new Font("Tahoma", 10, FontStyle.Bold);
			RectangleF rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50);
			e.Graph.DrawString(reportHeader, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None);
		
		}

		private void printableComponentLink3_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
		{
			string reportHeader = "SPA Single Treatment";
			e.Graph.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(System.Drawing.StringAlignment.Center);
			e.Graph.Font = new Font("Tahoma", 10, FontStyle.Bold);
			RectangleF rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50);
			e.Graph.DrawString(reportHeader, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None);
		
		}

		private void printableComponentLink4_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
		{
			string reportHeader = "Spa Package";
			e.Graph.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(System.Drawing.StringAlignment.Center);
			e.Graph.Font = new Font("Tahoma", 10, FontStyle.Bold);
			RectangleF rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50);
			e.Graph.DrawString(reportHeader, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None);
		
		}

		private void printableComponentLink5_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
		{
			string reportHeader = "Spa Product";
			e.Graph.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(System.Drawing.StringAlignment.Center);
			e.Graph.Font = new Font("Tahoma", 10, FontStyle.Bold);
			RectangleF rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50);
			e.Graph.DrawString(reportHeader, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None);
		
		}

		private void printableComponentLink6_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
		{
			string reportHeader = "IPL Package";
			e.Graph.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(System.Drawing.StringAlignment.Center);
			e.Graph.Font = new Font("Tahoma", 10, FontStyle.Bold);
			RectangleF rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50);
			e.Graph.DrawString(reportHeader, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None);
		
		}

		private void printableComponentLink7_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
		{
			string reportHeader = "Treatment";
			e.Graph.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(System.Drawing.StringAlignment.Center);
			e.Graph.Font = new Font("Tahoma", 10, FontStyle.Bold);
			RectangleF rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50);
			e.Graph.DrawString(reportHeader, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None);
		
		}

		private void printableComponentLink8_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
		{
			string reportHeader = "Credit Package Sales";
			e.Graph.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(System.Drawing.StringAlignment.Center);
			e.Graph.Font = new Font("Tahoma", 10, FontStyle.Bold);
			RectangleF rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50);
			e.Graph.DrawString(reportHeader, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None);
		
		}

		private void printableComponentLink9_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
		{
			string reportHeader = "Free Spa manu Trial";
			e.Graph.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(System.Drawing.StringAlignment.Center);
			e.Graph.Font = new Font("Tahoma", 10, FontStyle.Bold);
			RectangleF rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50);
			e.Graph.DrawString(reportHeader, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None);
		
		}

		private void printableComponentLink10_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
		{
			string reportHeader = "Vouchers";
			e.Graph.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(System.Drawing.StringAlignment.Center);
			e.Graph.Font = new Font("Tahoma", 10, FontStyle.Bold);
			RectangleF rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50);
			e.Graph.DrawString(reportHeader, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None);
		
		}

		private void PRINT2_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
		{
			printableComponentLink3.CreateDocument();
			printableComponentLink3.PrintingSystem.Print();
		
		}

		private void PRINT3_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
		{
			printableComponentLink4.CreateDocument();
			printableComponentLink4.PrintingSystem.Print();
		}

		private void PRINT4_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
		{
			printableComponentLink5.CreateDocument();
			printableComponentLink5.PrintingSystem.Print();
		}

		private void PRINT5_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
		{
			printableComponentLink6.CreateDocument();
			printableComponentLink6.PrintingSystem.Print();
		}

		private void PRINT6_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
		{
			printableComponentLink7.CreateDocument();
			printableComponentLink7.PrintingSystem.Print();
		}

		private void PRINT7_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
		{
			printableComponentLink8.CreateDocument();
			printableComponentLink8.PrintingSystem.Print();
		}

		private void PRINT8_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
		{
			printableComponentLink9.CreateDocument();
			printableComponentLink9.PrintingSystem.Print();
		}

		private void PRINT9_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
		{
			printableComponentLink10.CreateDocument();
			printableComponentLink10.PrintingSystem.Print();
		}

	
	}


}



