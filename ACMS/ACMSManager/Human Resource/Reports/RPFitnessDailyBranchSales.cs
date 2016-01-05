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

namespace ACMS.ACMSManager.Reports
{
	/// <summary>
	/// Summary description for RPFitnessDailyBranchSales.
	/// </summary>
	public class RPFitnessDailyBranchSales : System.Windows.Forms.Form
	{
		private Do.Employee employee;
		private Do.TerminalUser terminalUser; 
		User oUser;

		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraEditors.ImageComboBoxEdit cmbBranch;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.DateEdit dateEdit1;
		private DevExpress.XtraPivotGrid.PivotGridControl GridTotalCollection;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
		private DevExpress.XtraGrid.GridControl gridReceipt;
		private DevExpress.XtraGrid.Views.Grid.GridView gvReceipt;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.GridControl GridFitnessProduct;
		private DevExpress.XtraGrid.GridControl GridFitnessPackage;
		private DevExpress.XtraGrid.GridControl GridPTPackage;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
		private DevExpress.XtraGrid.GridControl GridFreeTrial;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private DevExpress.XtraGrid.GridControl GridVoucher;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
		private System.Windows.Forms.Label label10;
		private DevExpress.XtraGrid.Views.Grid.GridView gvReceiptPayment;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
		private System.ComponentModel.IContainer components;
		private DevExpress.XtraEditors.HyperLinkEdit PRINT1;
		private DevExpress.XtraEditors.HyperLinkEdit PRINT2;
		private DevExpress.XtraEditors.HyperLinkEdit PRINT3;
		private DevExpress.XtraEditors.HyperLinkEdit PRINT4;
		private DevExpress.XtraEditors.HyperLinkEdit PRINT7;
		private DevExpress.XtraEditors.HyperLinkEdit PRINT6;
		private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink2;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink3;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink4;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink5;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink6;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink7;
		private bool isFinishReportInit = false;
		

		public RPFitnessDailyBranchSales()
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
			this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridReceipt = new DevExpress.XtraGrid.GridControl();
			this.gvReceipt = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.cmbBranch = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.GridFitnessProduct = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridFitnessPackage = new DevExpress.XtraGrid.GridControl();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
			this.GridTotalCollection = new DevExpress.XtraPivotGrid.PivotGridControl();
			this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.GridPTPackage = new DevExpress.XtraGrid.GridControl();
			this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridFreeTrial = new DevExpress.XtraGrid.GridControl();
			this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.GridVoucher = new DevExpress.XtraGrid.GridControl();
			this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.label10 = new System.Windows.Forms.Label();
			this.PRINT1 = new DevExpress.XtraEditors.HyperLinkEdit();
			this.PRINT2 = new DevExpress.XtraEditors.HyperLinkEdit();
			this.PRINT3 = new DevExpress.XtraEditors.HyperLinkEdit();
			this.PRINT4 = new DevExpress.XtraEditors.HyperLinkEdit();
			this.PRINT7 = new DevExpress.XtraEditors.HyperLinkEdit();
			this.PRINT6 = new DevExpress.XtraEditors.HyperLinkEdit();
			this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
			this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
			this.printableComponentLink2 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
			this.printableComponentLink3 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
			this.printableComponentLink4 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
			this.printableComponentLink5 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
			this.printableComponentLink6 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
			this.printableComponentLink7 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
			((System.ComponentModel.ISupportInitialize)(this.gvReceiptPayment)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridReceipt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvReceipt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbBranch.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridFitnessProduct)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridFitnessPackage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridTotalCollection)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridPTPackage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridFreeTrial)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridVoucher)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT2.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT3.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT4.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT7.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT6.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
			this.SuspendLayout();
			// 
			// gvReceiptPayment
			// 
			this.gvReceiptPayment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									this.gridColumn15,
																									this.gridColumn16});
			this.gvReceiptPayment.GridControl = this.gridReceipt;
			this.gvReceiptPayment.Name = "gvReceiptPayment";
			this.gvReceiptPayment.OptionsBehavior.Editable = false;
			this.gvReceiptPayment.OptionsCustomization.AllowColumnMoving = false;
			this.gvReceiptPayment.OptionsCustomization.AllowSort = false;
			this.gvReceiptPayment.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn15
			// 
			this.gridColumn15.Caption = "Payment Code";
			this.gridColumn15.FieldName = "Payment Code";
			this.gridColumn15.Name = "gridColumn15";
			this.gridColumn15.Visible = true;
			this.gridColumn15.VisibleIndex = 0;
			// 
			// gridColumn16
			// 
			this.gridColumn16.Caption = "Amount";
			this.gridColumn16.FieldName = "Amount";
			this.gridColumn16.Name = "gridColumn16";
			this.gridColumn16.Visible = true;
			this.gridColumn16.VisibleIndex = 1;
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
			this.gridReceipt.TabIndex = 41;
			this.gridReceipt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									   this.gvReceipt,
																									   this.gvReceiptPayment});
			// 
			// gvReceipt
			// 
			this.gvReceipt.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn1,
																							 this.gridColumn2});
			this.gvReceipt.GridControl = this.gridReceipt;
			this.gvReceipt.Name = "gvReceipt";
			this.gvReceipt.OptionsBehavior.AutoExpandAllGroups = true;
			this.gvReceipt.OptionsBehavior.Editable = false;
			this.gvReceipt.OptionsCustomization.AllowColumnMoving = false;
			this.gvReceipt.OptionsCustomization.AllowFilter = false;
			this.gvReceipt.OptionsCustomization.AllowSort = false;
			this.gvReceipt.OptionsView.ShowFilterPanel = false;
			this.gvReceipt.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Receipt No";
			this.gridColumn1.FieldName = "strReceiptNo";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Shift";
			this.gridColumn2.FieldName = "nShiftID";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			// 
			// cmbBranch
			// 
			this.cmbBranch.EditValue = "cbGIROStatus";
			this.cmbBranch.Location = new System.Drawing.Point(232, 8);
			this.cmbBranch.Name = "cmbBranch";
			// 
			// cmbBranch.Properties
			// 
			this.cmbBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbBranch.Properties.Items.AddRange(new object[] {
																	  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Active", 1, -1),
																	  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Inactive", 0, -1)});
			this.cmbBranch.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.cmbBranch.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.cmbBranch.Size = new System.Drawing.Size(144, 20);
			this.cmbBranch.TabIndex = 52;
			this.cmbBranch.SelectedValueChanged += new System.EventHandler(this.cmbBranch_SelectedValueChanged);
			// 
			// GridFitnessProduct
			// 
			// 
			// GridFitnessProduct.EmbeddedNavigator
			// 
			this.GridFitnessProduct.EmbeddedNavigator.Name = "";
			this.GridFitnessProduct.Location = new System.Drawing.Point(16, 272);
			this.GridFitnessProduct.MainView = this.gridView1;
			this.GridFitnessProduct.Name = "GridFitnessProduct";
			this.GridFitnessProduct.Size = new System.Drawing.Size(464, 184);
			this.GridFitnessProduct.TabIndex = 48;
			this.GridFitnessProduct.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											  this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn3,
																							 this.gridColumn4,
																							 this.gridColumn5});
			this.gridView1.GridControl = this.GridFitnessProduct;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsBehavior.Editable = false;
			this.gridView1.OptionsCustomization.AllowColumnMoving = false;
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
			// GridFitnessPackage
			// 
			// 
			// GridFitnessPackage.EmbeddedNavigator
			// 
			this.GridFitnessPackage.EmbeddedNavigator.Name = "";
			this.GridFitnessPackage.Location = new System.Drawing.Point(496, 272);
			this.GridFitnessPackage.MainView = this.gridView2;
			this.GridFitnessPackage.Name = "GridFitnessPackage";
			this.GridFitnessPackage.Size = new System.Drawing.Size(424, 184);
			this.GridFitnessPackage.TabIndex = 49;
			this.GridFitnessPackage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											  this.gridView2});
			// 
			// gridView2
			// 
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn6,
																							 this.gridColumn7,
																							 this.gridColumn8});
			this.gridView2.GridControl = this.GridFitnessPackage;
			this.gridView2.Name = "gridView2";
			this.gridView2.OptionsBehavior.Editable = false;
			this.gridView2.OptionsCustomization.AllowColumnMoving = false;
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
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.Location = new System.Drawing.Point(496, 248);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(200, 23);
			this.label6.TabIndex = 51;
			this.label6.Text = "Fitness Package Sales";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.Location = new System.Drawing.Point(16, 248);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(152, 23);
			this.label5.TabIndex = 50;
			this.label5.Text = "Fitness Product Sales";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(648, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(168, 23);
			this.label4.TabIndex = 47;
			this.label4.Text = "Total Collection";
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(24, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(144, 23);
			this.label3.TabIndex = 46;
			this.label3.Text = "Receipt Generated";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(168, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 23);
			this.label2.TabIndex = 45;
			this.label2.Text = "Branch";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 23);
			this.label1.TabIndex = 44;
			this.label1.Text = "Date";
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
			this.dateEdit1.TabIndex = 43;
			this.dateEdit1.EditValueChanged += new System.EventHandler(this.dateEdit1_EditValueChanged);
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
			this.GridTotalCollection.OptionsView.ShowDataHeaders = false;
			this.GridTotalCollection.OptionsView.ShowFilterHeaders = false;
			this.GridTotalCollection.Size = new System.Drawing.Size(272, 184);
			this.GridTotalCollection.TabIndex = 42;
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
			// GridPTPackage
			// 
			// 
			// GridPTPackage.EmbeddedNavigator
			// 
			this.GridPTPackage.EmbeddedNavigator.Name = "";
			this.GridPTPackage.Location = new System.Drawing.Point(16, 496);
			this.GridPTPackage.MainView = this.gridView3;
			this.GridPTPackage.Name = "GridPTPackage";
			this.GridPTPackage.Size = new System.Drawing.Size(464, 200);
			this.GridPTPackage.TabIndex = 53;
			this.GridPTPackage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										 this.gridView3});
			// 
			// gridView3
			// 
			this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn9,
																							 this.gridColumn10,
																							 this.gridColumn11});
			this.gridView3.GridControl = this.GridPTPackage;
			this.gridView3.Name = "gridView3";
			this.gridView3.OptionsBehavior.Editable = false;
			this.gridView3.OptionsCustomization.AllowColumnMoving = false;
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
			// GridFreeTrial
			// 
			// 
			// GridFreeTrial.EmbeddedNavigator
			// 
			this.GridFreeTrial.EmbeddedNavigator.Name = "";
			this.GridFreeTrial.Location = new System.Drawing.Point(496, 496);
			this.GridFreeTrial.MainView = this.gridView4;
			this.GridFreeTrial.Name = "GridFreeTrial";
			this.GridFreeTrial.Size = new System.Drawing.Size(424, 200);
			this.GridFreeTrial.TabIndex = 54;
			this.GridFreeTrial.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										 this.gridView4});
			// 
			// gridView4
			// 
			this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn12,
																							 this.gridColumn13,
																							 this.gridColumn14});
			this.gridView4.GridControl = this.GridFreeTrial;
			this.gridView4.Name = "gridView4";
			this.gridView4.OptionsBehavior.Editable = false;
			this.gridView4.OptionsCustomization.AllowColumnMoving = false;
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
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label7.Location = new System.Drawing.Point(496, 472);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(96, 23);
			this.label7.TabIndex = 56;
			this.label7.Text = "Free Trials";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label8.Location = new System.Drawing.Point(16, 464);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(128, 23);
			this.label8.TabIndex = 55;
			this.label8.Text = "PT Package Sales";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// GridVoucher
			// 
			// 
			// GridVoucher.EmbeddedNavigator
			// 
			this.GridVoucher.EmbeddedNavigator.Name = "";
			this.GridVoucher.Location = new System.Drawing.Point(16, 736);
			this.GridVoucher.MainView = this.gridView6;
			this.GridVoucher.Name = "GridVoucher";
			this.GridVoucher.Size = new System.Drawing.Size(464, 200);
			this.GridVoucher.TabIndex = 59;
			this.GridVoucher.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																									   this.gridView6});
			// 
			// gridView6
			// 
			this.gridView6.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn18,
																							 this.gridColumn19,
																							 this.gridColumn20});
			this.gridView6.GridControl = this.GridVoucher;
			this.gridView6.Name = "gridView6";
			this.gridView6.OptionsBehavior.Editable = false;
			this.gridView6.OptionsCustomization.AllowColumnMoving = false;
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
			// label10
			// 
			this.label10.BackColor = System.Drawing.Color.Transparent;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label10.Location = new System.Drawing.Point(16, 712);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(88, 23);
			this.label10.TabIndex = 60;
			this.label10.Text = "Vouchers";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PRINT1
			// 
			this.PRINT1.EditValue = "PRINT";
			this.PRINT1.Location = new System.Drawing.Point(432, 8);
			this.PRINT1.Name = "PRINT1";
			// 
			// PRINT1.Properties
			// 
			this.PRINT1.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.PRINT1.Properties.Appearance.Options.UseBackColor = true;
			this.PRINT1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.PRINT1.Size = new System.Drawing.Size(40, 18);
			this.PRINT1.TabIndex = 142;
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
			this.PRINT2.TabIndex = 143;
			this.PRINT2.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.PRINT2_OpenLink);
			// 
			// PRINT3
			// 
			this.PRINT3.EditValue = "PRINT";
			this.PRINT3.Location = new System.Drawing.Point(872, 248);
			this.PRINT3.Name = "PRINT3";
			// 
			// PRINT3.Properties
			// 
			this.PRINT3.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.PRINT3.Properties.Appearance.Options.UseBackColor = true;
			this.PRINT3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.PRINT3.Size = new System.Drawing.Size(40, 18);
			this.PRINT3.TabIndex = 144;
			this.PRINT3.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.PRINT3_OpenLink);
			// 
			// PRINT4
			// 
			this.PRINT4.EditValue = "PRINT";
			this.PRINT4.Location = new System.Drawing.Point(432, 472);
			this.PRINT4.Name = "PRINT4";
			// 
			// PRINT4.Properties
			// 
			this.PRINT4.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.PRINT4.Properties.Appearance.Options.UseBackColor = true;
			this.PRINT4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.PRINT4.Size = new System.Drawing.Size(40, 18);
			this.PRINT4.TabIndex = 145;
			this.PRINT4.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.PRINT4_OpenLink);
			// 
			// PRINT7
			// 
			this.PRINT7.EditValue = "PRINT";
			this.PRINT7.Location = new System.Drawing.Point(872, 472);
			this.PRINT7.Name = "PRINT7";
			// 
			// PRINT7.Properties
			// 
			this.PRINT7.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.PRINT7.Properties.Appearance.Options.UseBackColor = true;
			this.PRINT7.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.PRINT7.Size = new System.Drawing.Size(40, 18);
			this.PRINT7.TabIndex = 148;
			this.PRINT7.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.PRINT7_OpenLink);
			// 
			// PRINT6
			// 
			this.PRINT6.EditValue = "PRINT";
			this.PRINT6.Location = new System.Drawing.Point(432, 712);
			this.PRINT6.Name = "PRINT6";
			// 
			// PRINT6.Properties
			// 
			this.PRINT6.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.PRINT6.Properties.Appearance.Options.UseBackColor = true;
			this.PRINT6.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.PRINT6.Size = new System.Drawing.Size(40, 18);
			this.PRINT6.TabIndex = 149;
			this.PRINT6.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.PRINT6_OpenLink);
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
																 this.printableComponentLink7});
			// 
			// printableComponentLink1
			// 
			this.printableComponentLink1.Component = this.gridReceipt;
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
			this.printableComponentLink3.Component = this.GridFitnessProduct;
			this.printableComponentLink3.PrintingSystem = this.printingSystem1;
			this.printableComponentLink3.CreateReportHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(this.printableComponentLink3_CreateReportHeaderArea);
			// 
			// printableComponentLink4
			// 
			this.printableComponentLink4.Component = this.GridFitnessPackage;
			this.printableComponentLink4.PrintingSystem = this.printingSystem1;
			this.printableComponentLink4.CreateReportHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(this.printableComponentLink4_CreateReportHeaderArea);
			// 
			// printableComponentLink5
			// 
			this.printableComponentLink5.Component = this.GridPTPackage;
			this.printableComponentLink5.PrintingSystem = this.printingSystem1;
			this.printableComponentLink5.CreateReportHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(this.printableComponentLink5_CreateReportHeaderArea);
			// 
			// printableComponentLink6
			// 
			this.printableComponentLink6.Component = this.GridFreeTrial;
			this.printableComponentLink6.PrintingSystem = this.printingSystem1;
			this.printableComponentLink6.CreateReportHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(this.printableComponentLink6_CreateReportHeaderArea);
			// 
			// printableComponentLink7
			// 
			this.printableComponentLink7.Component = this.GridVoucher;
			this.printableComponentLink7.PrintingSystem = this.printingSystem1;
			this.printableComponentLink7.CreateReportHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(this.printableComponentLink7_CreateReportHeaderArea);
			// 
			// RPFitnessDailyBranchSales
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(901, 427);
			this.Controls.Add(this.PRINT6);
			this.Controls.Add(this.PRINT7);
			this.Controls.Add(this.PRINT4);
			this.Controls.Add(this.PRINT3);
			this.Controls.Add(this.PRINT2);
			this.Controls.Add(this.PRINT1);
			this.Controls.Add(this.GridFitnessProduct);
			this.Controls.Add(this.GridFitnessPackage);
			this.Controls.Add(this.GridPTPackage);
			this.Controls.Add(this.GridFreeTrial);
			this.Controls.Add(this.GridVoucher);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.cmbBranch);
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
			this.Name = "RPFitnessDailyBranchSales";
			this.Text = "Fitness Daily Branch Sales";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.RPFitnessDailyBranchSales_Load);
			((System.ComponentModel.ISupportInitialize)(this.gvReceiptPayment)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridReceipt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvReceipt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbBranch.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridFitnessProduct)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridFitnessPackage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridTotalCollection)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridPTPackage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridFreeTrial)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridVoucher)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT2.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT3.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT4.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT7.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT6.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

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

		private void LoadReport()
		{
			if (!isFinishReportInit)
				return;

			DataSet dsFitnessBranchSales = SqlHelperUtils.ExecuteDatasetSP("up_get_FitnessBranchSales",
				new SqlParameter("@instrBranchCode", cmbBranch.EditValue.ToString()),
				new SqlParameter("@indtDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, dateEdit1.EditValue));

			GridTotalCollection.DataSource = dsFitnessBranchSales.Tables[0];
			GridFitnessPackage.DataSource = dsFitnessBranchSales.Tables[1];
			GridFreeTrial.DataSource = dsFitnessBranchSales.Tables[2];
			GridFitnessProduct.DataSource = dsFitnessBranchSales.Tables[3];
			GridVoucher.DataSource = dsFitnessBranchSales.Tables[4];
			GridPTPackage.DataSource = dsFitnessBranchSales.Tables[5];

			//*** Receipt Table

			SqlCommand myCmd2 = new SqlCommand("up_get_FitnessBranchSalesReceipt", connection);
			myCmd2.CommandTimeout = 0;
			myCmd2.CommandType = CommandType.StoredProcedure;
			myCmd2.Parameters.Add("@strBranchCode", cmbBranch.EditValue.ToString()); 
			myCmd2.Parameters.Add("@dtDate",Convert.ToDateTime(dateEdit1.EditValue).ToString("yyyy/MM/dd")); 
			SqlDataAdapter FitnessBranchSalesReceiptDA = new SqlDataAdapter(myCmd2); 
			DataSet dsFitnessBranchSalesReceipt = new DataSet();
			FitnessBranchSalesReceiptDA.Fill(dsFitnessBranchSalesReceipt);
			/*
						DataSet dsSpaBranchSalesReceipt = SqlHelperUtils.ExecuteDatasetSP("up_get_SpaBranchSalesReceipt",
							new SqlParameter("@strBranchCode", cmbBranch.EditValue.ToString()),
							new SqlParameter("@dtDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed, dateEdit1.EditValue));
						*/	

			DataTable dtReceipt = dsFitnessBranchSalesReceipt.Tables[0];
			DataTable dtPayment = dsFitnessBranchSalesReceipt.Tables[1];

			string[] parentColNames = {"strReceiptNo"};
			string[] childColNames = {"Receipt No"};
		
			DataColumn[] pc = new DataColumn[1];
			pc[0] = dtReceipt.Columns["strReceiptNo"];

			DataColumn[] cc = new DataColumn[1];
			cc[0] = dtPayment.Columns["Receipt No"];

			if(!dsFitnessBranchSalesReceipt.Relations.Contains("ShiftPayment")) 
			{ 
				if (dtPayment.Rows.Count > 0) 
				{ 
					DataRelation relation = new DataRelation ("ReceiptPayment",pc,cc,false); 
					dsFitnessBranchSalesReceipt.Relations.Add(relation); 
				} 
			} 
			gridReceipt.DataSource = dtReceipt;
			//*******************
		}

		private void _LoadReport()
		{
			if (!isFinishReportInit)
				return;

			string strSQL;
			DataSet _ds;
			string Filtering;

			LoadReceipt();

			// Total sales Collection
			strSQL = "select P.*, Convert(varchar(10),dtDate,103) as dtDate, R.strBranchCode from tblreceiptpayment P ";
			strSQL = strSQL + " inner join tblreceipt R On R.strReceiptNo = P.strReceiptNo Where R.nCategoryID";
			strSQL = strSQL + " In (Select nCategoryID From tblCategory Where nSalesCategoryID = 1 or nSalesCategoryID = 3)";
			strSQL = strSQL + " And R.strBranchCode In (Select strBranchCode From TblEmployeeBranchRights Where nEmployeeID = " + employee.Id + ")";
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
			DataView dv = new DataView(dt);

			//dv.RowFilter = "dtDate = '" + string.Format("{0:dd/MM/yyyy}",Convert.ToDateTime(dateEdit1.EditValue)) + "'";
			Filtering = "dtDate = '" + string.Format("{0:dd/MM/yyyy}",Convert.ToDateTime(dateEdit1.EditValue)) + "'";

			if (cmbBranch.EditValue != null && cmbBranch.EditValue.ToString() != "")
				Filtering += " And strBranchCode = '" + cmbBranch.EditValue + "'";
                
			dv.RowFilter = Filtering;

			GridTotalCollection.DataSource = dv;
		
			//fitness Package
			strSQL = "up_get_FitnessPackage " + employee.Id;
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
			dv = new DataView(dt);

			Filtering = "dtDate = '" + string.Format("{0:dd/MM/yyyy}",Convert.ToDateTime(dateEdit1.EditValue)) + "'";

			if (cmbBranch.EditValue != null && cmbBranch.EditValue.ToString() != "")
				Filtering += " And strBranchCode = '" + cmbBranch.EditValue + "'";
                
			dv.RowFilter = Filtering;


			this.GridFitnessPackage.DataSource = dv;
			//nSalesCategoryID = 1 or nSalesCategoryID = 3 and fFree = 1
	    	//Free Trial
			strSQL = "up_get_FitnessTrial " + employee.Id;
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
			dv = new DataView(dt);

			//dv.RowFilter = "dtDate = '" + string.Format("{0:dd/MM/yyyy}",Convert.ToDateTime(dateEdit1.EditValue)) + "'";

			Filtering = "dtDate = '" + string.Format("{0:dd/MM/yyyy}",Convert.ToDateTime(dateEdit1.EditValue)) + "'";

			if (cmbBranch.EditValue != null && cmbBranch.EditValue.ToString() != "")
				Filtering += " And strBranchCode = '" + cmbBranch.EditValue + "'";
                
			dv.RowFilter = Filtering;


			this.GridFreeTrial.DataSource = dv;


			//fitness product
			strSQL = "up_get_FitnessProduct " + employee.Id;
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
			dv = new DataView(dt);
			Filtering = "dtDate = '" + string.Format("{0:dd/MM/yyyy}",Convert.ToDateTime(dateEdit1.EditValue)) + "'";

			if (cmbBranch.EditValue != null && cmbBranch.EditValue.ToString() != "")
				Filtering += " And strBranchCode = '" + cmbBranch.EditValue + "'";
                
			dv.RowFilter = Filtering;


			this.GridFitnessProduct.DataSource = dv;

			
				
			//Spa Voucher

			strSQL =  "Select nVoucherTypeID as Code, strDescription as Description,count(nVoucherTypeID) as Quantity, Convert(varchar(10),dtDate,103) as dtDate, strBranchCode  from tblreceipt R";
			strSQL += " Inner Join TblVoucherType V On V.nVoucherTypeID = R.mVoucherTypeID";
			strSQL += " Where R.nCategoryID In (Select nCategoryID From tblCategory Where nSalesCategoryID = 1 or nSalesCategoryID = 3)";
			strSQL += " And R.strBranchCode In (Select strBranchCode from TblEmployeeBranchRights Where nEmployeeID = " + employee.Id + ")";
			strSQL += " group by nVoucherTypeID,strDescription,dtDate,strBranchCode";

			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
			dv = new DataView(dt);

			Filtering = "dtDate = '" + string.Format("{0:dd/MM/yyyy}",Convert.ToDateTime(dateEdit1.EditValue)) + "'";

			if (cmbBranch.EditValue != null && cmbBranch.EditValue.ToString() != "")
				Filtering += " And strBranchCode = '" + cmbBranch.EditValue + "'";
                
			dv.RowFilter = Filtering;


			this.GridVoucher.DataSource = dv;

			//PT Package
			strSQL = "up_get_FitnessPTPackage " + employee.Id;
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["table"];
			dv = new DataView(dt);

			Filtering = "dtDate = '" + string.Format("{0:dd/MM/yyyy}",Convert.ToDateTime(dateEdit1.EditValue)) + "'";

			if (cmbBranch.EditValue != null && cmbBranch.EditValue.ToString() != "")
				Filtering += " And strBranchCode = '" + cmbBranch.EditValue + "'";
                
			dv.RowFilter = Filtering;
			
			this.GridPTPackage.DataSource = dv;
		
		}

		private void LoadReceipt()
		{ 
			
			string sqlReceipt;
			string sqlPayment;
			
			sqlReceipt = "select strReceiptNo,nShiftID,(mNettAMount + mGSTAmount) as TotalAmount,Convert(varchar(10),dtDate,103) as dtDate,strBranchCode from TblReceipt";
			sqlReceipt += " Where nCategoryID In (Select nCategoryID from tblCategory Where nSalesCategoryID = 1 or nSalesCategoryID = 3)";
			sqlReceipt += " And strBranchCode In (Select strBranchCode From TblEmployeeBranchRights Where nEmployeeID = " + employee.Id + ")";

			sqlPayment = "select strReceiptNo as [Receipt No], strPaymentCode as [Payment Code], sum(mAmount) as Amount from TblReceiptPayment group by strPaymentCode,strReceiptNo,strPaymentCode";

		
			SqlDataAdapter ReceiptDA = new SqlDataAdapter(sqlReceipt,connection); 
			SqlDataAdapter PaymentMode = new SqlDataAdapter(sqlPayment, connection); 

			connection.Open(); 

			DataSet _ds = new DataSet("ReceiptPayment"); 
			ReceiptDA.Fill(_ds, "Receipt"); 
			PaymentMode.Fill(_ds, "Payment"); 

			connection.Close(); 

			DataTable dtReceipt = _ds.Tables["Receipt"];
			DataTable dtPayment = _ds.Tables["Payment"];


			string[] parentColNames = {"strReceiptNo"};
			string[] childColNames = {"Receipt No"};
		

			DataColumn[] pc = new DataColumn[1];
			pc[0] = dtReceipt.Columns["strReceiptNo"];
		
			DataColumn[] cc = new DataColumn[1];
			cc[0] = dtPayment.Columns["Receipt No"];

			if(!_ds.Relations.Contains("ShiftPayment")) 
			{ 
				if (dtPayment.Rows.Count > 0) 
				{ 
					DataRelation relation = new DataRelation ("ReceiptPayment",pc,cc,false); 
					_ds.Relations.Add(relation); 
				} 
			} 

			DataView dv = new DataView(_ds.Tables["Receipt"]);

			string Filtering = "dtDate = '" + string.Format("{0:dd/MM/yyyy}",Convert.ToDateTime(dateEdit1.EditValue)) + "'";

			if (cmbBranch.EditValue.ToString() != "")
				Filtering += " And strBranchCode = '" + cmbBranch.EditValue + "'";
                
			dv.RowFilter = Filtering;

		
			this.gridReceipt.DataSource = dv; 
	
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

		private void RPFitnessDailyBranchSales_Load(object sender, System.EventArgs e)
		{
			dateEdit1.EditValue = DateTime.Today;
			isFinishReportInit = false;
			BindCategory();
			isFinishReportInit = true;
			LoadReport();

		}

		private void PRINT1_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
		{
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
			string reportHeader = "Fitness Product Sales";
			e.Graph.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(System.Drawing.StringAlignment.Center);
			e.Graph.Font = new Font("Tahoma", 10, FontStyle.Bold);
			RectangleF rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50);
			e.Graph.DrawString(reportHeader, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None);
		
		}

		private void printableComponentLink4_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
		{
			string reportHeader = "Fitness Package Sales";
			e.Graph.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(System.Drawing.StringAlignment.Center);
			e.Graph.Font = new Font("Tahoma", 10, FontStyle.Bold);
			RectangleF rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50);
			e.Graph.DrawString(reportHeader, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None);
		
		}

		private void printableComponentLink5_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
		{
			string reportHeader = "PT Package Sales";
			e.Graph.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(System.Drawing.StringAlignment.Center);
			e.Graph.Font = new Font("Tahoma", 10, FontStyle.Bold);
			RectangleF rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50);
			e.Graph.DrawString(reportHeader, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None);
		
		}

		private void printableComponentLink6_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
		{
			string reportHeader = "Free Trials";
			e.Graph.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(System.Drawing.StringAlignment.Center);
			e.Graph.Font = new Font("Tahoma", 10, FontStyle.Bold);
			RectangleF rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50);
			e.Graph.DrawString(reportHeader, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None);
		
		}

		private void printableComponentLink7_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
		{
			string reportHeader = "Voucher";
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

		private void PRINT7_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
		{
			printableComponentLink6.CreateDocument();
			printableComponentLink6.PrintingSystem.Print();
		}

		private void PRINT6_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
		{
			printableComponentLink7.CreateDocument();
			printableComponentLink7.PrintingSystem.Print();
		}

		
	}
}
