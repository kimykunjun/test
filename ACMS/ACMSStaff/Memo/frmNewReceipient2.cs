using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ACMSLogic;
using ACMS.Utils;
using ACMS.XtraUtils.LookupEditBuilder;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace ACMS.ACMSStaff.Memo
{
	/// <summary>
	/// Summary description for frmNewMemo2.
	/// </summary>
	public class frmNewReceipient2 : System.Windows.Forms.Form
	{
		private ACMSLogic.Staff.Memo myMemo;
		private int nMemoID;
		private int nEmployeeID;
		private DataTable dtBranch, dtPersonalGroup, dtDepartmentGroup, dtEmployee;

		#region Windows Designer Generated Variables

		private DevExpress.XtraEditors.GroupControl groupControl1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraGrid.GridControl gridctrBranchReceipient;
		private DevExpress.XtraGrid.Views.Grid.GridView gvBranchReceipient;
		private DevExpress.XtraGrid.GridControl gridctrBranchReceipient2;
		private DevExpress.XtraGrid.Views.Grid.GridView gvBranchReceipient2;
		private DevExpress.XtraGrid.Columns.GridColumn colBranchCode;
		private DevExpress.XtraGrid.Columns.GridColumn colBranchName;
		private DevExpress.XtraGrid.Columns.GridColumn colBranchCode2;
		private DevExpress.XtraGrid.Columns.GridColumn colBranchName2;
		private DevExpress.XtraEditors.SimpleButton sbtnBGAdd;
		private DevExpress.XtraEditors.SimpleButton sbtnBGAllAdd;
		private DevExpress.XtraEditors.SimpleButton sbtnBGAllDel;
		private DevExpress.XtraEditors.SimpleButton sbtnBGDel;
		private DevExpress.XtraEditors.SimpleButton sbtnDGDel;
		private DevExpress.XtraEditors.SimpleButton sbtnDGAllDel;
		private DevExpress.XtraEditors.SimpleButton sbtnDGAllAdd;
		private DevExpress.XtraEditors.SimpleButton sbtnDGAdd;
		private DevExpress.XtraGrid.GridControl gridctrDepartmentGroup2;
		private DevExpress.XtraGrid.Views.Grid.GridView gvDepartmentGroup2;
		private DevExpress.XtraGrid.GridControl gridctrDepartmentGroup;
		private DevExpress.XtraGrid.Views.Grid.GridView gvDepartmentGroup;
		private DevExpress.XtraEditors.SimpleButton sbtnPGDel;
		private DevExpress.XtraEditors.SimpleButton sbtnPGAllDel;
		private DevExpress.XtraEditors.SimpleButton sbtnPGAllAdd;
		private DevExpress.XtraEditors.SimpleButton sbtnPGAdd;
		private DevExpress.XtraGrid.GridControl gridctrPersonalGroup2;
		private DevExpress.XtraGrid.Views.Grid.GridView gvPersonalGroup2;
		private DevExpress.XtraGrid.GridControl gridctrPersonalGroup;
		private DevExpress.XtraGrid.Views.Grid.GridView gvPersonalGroup;
		private DevExpress.XtraEditors.SimpleButton sbtnEmpDel;
		private DevExpress.XtraEditors.SimpleButton sbtnEmpAllDel;
		private DevExpress.XtraEditors.SimpleButton sbtnEmpAllAdd;
		private DevExpress.XtraEditors.SimpleButton sbtnEmpAdd;
		private DevExpress.XtraGrid.GridControl gridctrEmployee2;
		private DevExpress.XtraGrid.Views.Grid.GridView gvEmployee2;
		private DevExpress.XtraGrid.GridControl gridctrEmployee;
		private DevExpress.XtraGrid.Views.Grid.GridView gvEmployee;
		private DevExpress.XtraGrid.Columns.GridColumn colDepartmentGroup;
		private DevExpress.XtraGrid.Columns.GridColumn colDepartmentGroupCode;
		private DevExpress.XtraGrid.Columns.GridColumn colDepartmentID2;
		private DevExpress.XtraGrid.Columns.GridColumn colDepartmentGroupDesc2;
		private DevExpress.XtraGrid.Columns.GridColumn colDepartmentGroupDesc;
		private DevExpress.XtraGrid.Columns.GridColumn colDepartmentGroupCode2;
		private DevExpress.XtraGrid.Columns.GridColumn colPersonalGroupID;
		private DevExpress.XtraGrid.Columns.GridColumn colPersonalGroupCode;
		private DevExpress.XtraGrid.Columns.GridColumn colPersonalGroupDesc;
		private DevExpress.XtraGrid.Columns.GridColumn colPersonalGroupID2;
		private DevExpress.XtraGrid.Columns.GridColumn colPersonalGroupCode3;
		private DevExpress.XtraGrid.Columns.GridColumn colPersonalGroupDesc2;
		private DevExpress.XtraGrid.Columns.GridColumn colEmployeeID;
		private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
		private DevExpress.XtraGrid.Columns.GridColumn colEmployeeID2;
		private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName2;
		private DevExpress.XtraEditors.SimpleButton sbtnAdd;
		private DevExpress.XtraEditors.SimpleButton sbtnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#endregion

		public frmNewReceipient2(int nMemoID, int nEmployeeID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.nMemoID = nMemoID;
			this.nEmployeeID = nEmployeeID;
			myMemo = new ACMSLogic.Staff.Memo();

			myMemo.InitNewReceipient(out dtBranch, out dtDepartmentGroup, out dtPersonalGroup, out dtEmployee);

			gridctrBranchReceipient2.DataSource = dtBranch;
			gridctrDepartmentGroup2.DataSource = dtDepartmentGroup;
			gridctrPersonalGroup2.DataSource = dtPersonalGroup;
			gridctrEmployee2.DataSource = dtEmployee;

			gridctrBranchReceipient.DataSource = myMemo.GetBranchLookupEdit();
			gridctrDepartmentGroup.DataSource = myMemo.GetDepartmentGroupLookupEdit();
			gridctrPersonalGroup.DataSource = myMemo.GetPersonalGroupLookupEdit(nEmployeeID);
			gridctrEmployee.DataSource = myMemo.GetEmployeeLookupEditForMemoGroup();
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
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.sbtnEmpDel = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnEmpAllDel = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnEmpAllAdd = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnEmpAdd = new DevExpress.XtraEditors.SimpleButton();
			this.gridctrEmployee2 = new DevExpress.XtraGrid.GridControl();
			this.gvEmployee2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colEmployeeID2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colEmployeeName2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridctrEmployee = new DevExpress.XtraGrid.GridControl();
			this.gvEmployee = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.sbtnPGDel = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnPGAllDel = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnPGAllAdd = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnPGAdd = new DevExpress.XtraEditors.SimpleButton();
			this.gridctrPersonalGroup2 = new DevExpress.XtraGrid.GridControl();
			this.gvPersonalGroup2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colPersonalGroupID2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPersonalGroupCode3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPersonalGroupDesc2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridctrPersonalGroup = new DevExpress.XtraGrid.GridControl();
			this.gvPersonalGroup = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colPersonalGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPersonalGroupCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPersonalGroupDesc = new DevExpress.XtraGrid.Columns.GridColumn();
			this.sbtnDGDel = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnDGAllDel = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnDGAllAdd = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnDGAdd = new DevExpress.XtraEditors.SimpleButton();
			this.gridctrDepartmentGroup2 = new DevExpress.XtraGrid.GridControl();
			this.gvDepartmentGroup2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colDepartmentID2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDepartmentGroupCode2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDepartmentGroupDesc2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridctrDepartmentGroup = new DevExpress.XtraGrid.GridControl();
			this.gvDepartmentGroup = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colDepartmentGroup = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDepartmentGroupCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDepartmentGroupDesc = new DevExpress.XtraGrid.Columns.GridColumn();
			this.sbtnBGDel = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnBGAllDel = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnBGAllAdd = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnBGAdd = new DevExpress.XtraEditors.SimpleButton();
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.gridctrBranchReceipient2 = new DevExpress.XtraGrid.GridControl();
			this.gvBranchReceipient2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colBranchCode2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colBranchName2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.label3 = new System.Windows.Forms.Label();
			this.gridctrBranchReceipient = new DevExpress.XtraGrid.GridControl();
			this.gvBranchReceipient = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colBranchCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colBranchName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.sbtnAdd = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridctrEmployee2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvEmployee2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridctrEmployee)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvEmployee)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridctrPersonalGroup2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPersonalGroup2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridctrPersonalGroup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPersonalGroup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridctrDepartmentGroup2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvDepartmentGroup2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridctrDepartmentGroup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvDepartmentGroup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridctrBranchReceipient2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvBranchReceipient2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridctrBranchReceipient)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvBranchReceipient)).BeginInit();
			this.SuspendLayout();
			// 
			// groupControl1
			// 
			this.groupControl1.Controls.Add(this.sbtnEmpDel);
			this.groupControl1.Controls.Add(this.sbtnEmpAllDel);
			this.groupControl1.Controls.Add(this.sbtnEmpAllAdd);
			this.groupControl1.Controls.Add(this.sbtnEmpAdd);
			this.groupControl1.Controls.Add(this.gridctrEmployee2);
			this.groupControl1.Controls.Add(this.gridctrEmployee);
			this.groupControl1.Controls.Add(this.sbtnPGDel);
			this.groupControl1.Controls.Add(this.sbtnPGAllDel);
			this.groupControl1.Controls.Add(this.sbtnPGAllAdd);
			this.groupControl1.Controls.Add(this.sbtnPGAdd);
			this.groupControl1.Controls.Add(this.gridctrPersonalGroup2);
			this.groupControl1.Controls.Add(this.gridctrPersonalGroup);
			this.groupControl1.Controls.Add(this.sbtnDGDel);
			this.groupControl1.Controls.Add(this.sbtnDGAllDel);
			this.groupControl1.Controls.Add(this.sbtnDGAllAdd);
			this.groupControl1.Controls.Add(this.sbtnDGAdd);
			this.groupControl1.Controls.Add(this.gridctrDepartmentGroup2);
			this.groupControl1.Controls.Add(this.gridctrDepartmentGroup);
			this.groupControl1.Controls.Add(this.sbtnBGDel);
			this.groupControl1.Controls.Add(this.sbtnBGAllDel);
			this.groupControl1.Controls.Add(this.sbtnBGAllAdd);
			this.groupControl1.Controls.Add(this.sbtnBGAdd);
			this.groupControl1.Controls.Add(this.label6);
			this.groupControl1.Controls.Add(this.label4);
			this.groupControl1.Controls.Add(this.label5);
			this.groupControl1.Controls.Add(this.gridctrBranchReceipient2);
			this.groupControl1.Controls.Add(this.label3);
			this.groupControl1.Controls.Add(this.gridctrBranchReceipient);
			this.groupControl1.Location = new System.Drawing.Point(4, 8);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(914, 384);
			this.groupControl1.TabIndex = 0;
			this.groupControl1.Text = "Recepients";
			// 
			// sbtnEmpDel
			// 
			this.sbtnEmpDel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnEmpDel.Location = new System.Drawing.Point(476, 358);
			this.sbtnEmpDel.Name = "sbtnEmpDel";
			this.sbtnEmpDel.Size = new System.Drawing.Size(30, 20);
			this.sbtnEmpDel.TabIndex = 22;
			this.sbtnEmpDel.Text = "<";
			this.sbtnEmpDel.Click += new System.EventHandler(this.sbtnEmpDel_Click);
			// 
			// sbtnEmpAllDel
			// 
			this.sbtnEmpAllDel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnEmpAllDel.Location = new System.Drawing.Point(476, 336);
			this.sbtnEmpAllDel.Name = "sbtnEmpAllDel";
			this.sbtnEmpAllDel.Size = new System.Drawing.Size(30, 20);
			this.sbtnEmpAllDel.TabIndex = 21;
			this.sbtnEmpAllDel.Text = "<<";
			this.sbtnEmpAllDel.Click += new System.EventHandler(this.sbtnEmpAllDel_Click);
			// 
			// sbtnEmpAllAdd
			// 
			this.sbtnEmpAllAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnEmpAllAdd.Location = new System.Drawing.Point(476, 314);
			this.sbtnEmpAllAdd.Name = "sbtnEmpAllAdd";
			this.sbtnEmpAllAdd.Size = new System.Drawing.Size(30, 20);
			this.sbtnEmpAllAdd.TabIndex = 20;
			this.sbtnEmpAllAdd.Text = ">>";
			this.sbtnEmpAllAdd.Click += new System.EventHandler(this.sbtnEmpAllAdd_Click);
			// 
			// sbtnEmpAdd
			// 
			this.sbtnEmpAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnEmpAdd.Location = new System.Drawing.Point(476, 292);
			this.sbtnEmpAdd.Name = "sbtnEmpAdd";
			this.sbtnEmpAdd.Size = new System.Drawing.Size(30, 20);
			this.sbtnEmpAdd.TabIndex = 19;
			this.sbtnEmpAdd.Text = ">";
			this.sbtnEmpAdd.Click += new System.EventHandler(this.sbtnEmpAdd_Click);
			// 
			// gridctrEmployee2
			// 
			// 
			// gridctrEmployee2.EmbeddedNavigator
			// 
			this.gridctrEmployee2.EmbeddedNavigator.Name = "";
			this.gridctrEmployee2.Location = new System.Drawing.Point(510, 290);
			this.gridctrEmployee2.MainView = this.gvEmployee2;
			this.gridctrEmployee2.Name = "gridctrEmployee2";
			this.gridctrEmployee2.Size = new System.Drawing.Size(400, 88);
			this.gridctrEmployee2.TabIndex = 23;
			this.gridctrEmployee2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											this.gvEmployee2});
			// 
			// gvEmployee2
			// 
			this.gvEmployee2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							   this.colEmployeeID2,
																							   this.colEmployeeName2});
			this.gvEmployee2.GridControl = this.gridctrEmployee2;
			this.gvEmployee2.Name = "gvEmployee2";
			this.gvEmployee2.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvEmployee2.OptionsBehavior.Editable = false;
			this.gvEmployee2.OptionsCustomization.AllowFilter = false;
			this.gvEmployee2.OptionsSelection.MultiSelect = true;
			this.gvEmployee2.OptionsView.ShowGroupPanel = false;
			this.gvEmployee2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																										new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colEmployeeID2, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// colEmployeeID2
			// 
			this.colEmployeeID2.Caption = "Employee ID";
			this.colEmployeeID2.FieldName = "nEmployeeID";
			this.colEmployeeID2.Name = "colEmployeeID2";
			this.colEmployeeID2.Visible = true;
			this.colEmployeeID2.VisibleIndex = 0;
			this.colEmployeeID2.Width = 78;
			// 
			// colEmployeeName2
			// 
			this.colEmployeeName2.Caption = "Name";
			this.colEmployeeName2.FieldName = "strEmployeeName";
			this.colEmployeeName2.Name = "colEmployeeName2";
			this.colEmployeeName2.Visible = true;
			this.colEmployeeName2.VisibleIndex = 1;
			this.colEmployeeName2.Width = 308;
			// 
			// gridctrEmployee
			// 
			// 
			// gridctrEmployee.EmbeddedNavigator
			// 
			this.gridctrEmployee.EmbeddedNavigator.Name = "";
			this.gridctrEmployee.Location = new System.Drawing.Point(72, 290);
			this.gridctrEmployee.MainView = this.gvEmployee;
			this.gridctrEmployee.Name = "gridctrEmployee";
			this.gridctrEmployee.Size = new System.Drawing.Size(400, 88);
			this.gridctrEmployee.TabIndex = 18;
			this.gridctrEmployee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										   this.gvEmployee});
			// 
			// gvEmployee
			// 
			this.gvEmployee.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							  this.colEmployeeID,
																							  this.colEmployeeName});
			this.gvEmployee.GridControl = this.gridctrEmployee;
			this.gvEmployee.Name = "gvEmployee";
			this.gvEmployee.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvEmployee.OptionsBehavior.Editable = false;
			this.gvEmployee.OptionsCustomization.AllowFilter = false;
			this.gvEmployee.OptionsSelection.MultiSelect = true;
			this.gvEmployee.OptionsView.ShowGroupPanel = false;
			this.gvEmployee.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																									   new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colEmployeeID, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// colEmployeeID
			// 
			this.colEmployeeID.Caption = "Employee ID";
			this.colEmployeeID.FieldName = "nEmployeeID";
			this.colEmployeeID.Name = "colEmployeeID";
			this.colEmployeeID.Visible = true;
			this.colEmployeeID.VisibleIndex = 0;
			this.colEmployeeID.Width = 79;
			// 
			// colEmployeeName
			// 
			this.colEmployeeName.Caption = "Name";
			this.colEmployeeName.FieldName = "strEmployeeName";
			this.colEmployeeName.Name = "colEmployeeName";
			this.colEmployeeName.Visible = true;
			this.colEmployeeName.VisibleIndex = 1;
			this.colEmployeeName.Width = 307;
			// 
			// sbtnPGDel
			// 
			this.sbtnPGDel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnPGDel.Location = new System.Drawing.Point(476, 268);
			this.sbtnPGDel.Name = "sbtnPGDel";
			this.sbtnPGDel.Size = new System.Drawing.Size(30, 20);
			this.sbtnPGDel.TabIndex = 16;
			this.sbtnPGDel.Text = "<";
			this.sbtnPGDel.Click += new System.EventHandler(this.sbtnPGDel_Click);
			// 
			// sbtnPGAllDel
			// 
			this.sbtnPGAllDel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnPGAllDel.Location = new System.Drawing.Point(476, 246);
			this.sbtnPGAllDel.Name = "sbtnPGAllDel";
			this.sbtnPGAllDel.Size = new System.Drawing.Size(30, 20);
			this.sbtnPGAllDel.TabIndex = 15;
			this.sbtnPGAllDel.Text = "<<";
			this.sbtnPGAllDel.Click += new System.EventHandler(this.sbtnPGAllDel_Click);
			// 
			// sbtnPGAllAdd
			// 
			this.sbtnPGAllAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnPGAllAdd.Location = new System.Drawing.Point(476, 224);
			this.sbtnPGAllAdd.Name = "sbtnPGAllAdd";
			this.sbtnPGAllAdd.Size = new System.Drawing.Size(30, 20);
			this.sbtnPGAllAdd.TabIndex = 14;
			this.sbtnPGAllAdd.Text = ">>";
			this.sbtnPGAllAdd.Click += new System.EventHandler(this.sbtnPGAllAdd_Click);
			// 
			// sbtnPGAdd
			// 
			this.sbtnPGAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnPGAdd.Location = new System.Drawing.Point(476, 202);
			this.sbtnPGAdd.Name = "sbtnPGAdd";
			this.sbtnPGAdd.Size = new System.Drawing.Size(30, 20);
			this.sbtnPGAdd.TabIndex = 13;
			this.sbtnPGAdd.Text = ">";
			this.sbtnPGAdd.Click += new System.EventHandler(this.sbtnPGAdd_Click);
			// 
			// gridctrPersonalGroup2
			// 
			// 
			// gridctrPersonalGroup2.EmbeddedNavigator
			// 
			this.gridctrPersonalGroup2.EmbeddedNavigator.Name = "";
			this.gridctrPersonalGroup2.Location = new System.Drawing.Point(510, 200);
			this.gridctrPersonalGroup2.MainView = this.gvPersonalGroup2;
			this.gridctrPersonalGroup2.Name = "gridctrPersonalGroup2";
			this.gridctrPersonalGroup2.Size = new System.Drawing.Size(400, 88);
			this.gridctrPersonalGroup2.TabIndex = 17;
			this.gridctrPersonalGroup2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																												 this.gvPersonalGroup2});
			// 
			// gvPersonalGroup2
			// 
			this.gvPersonalGroup2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									this.colPersonalGroupID2,
																									this.colPersonalGroupCode3,
																									this.colPersonalGroupDesc2});
			this.gvPersonalGroup2.GridControl = this.gridctrPersonalGroup2;
			this.gvPersonalGroup2.Name = "gvPersonalGroup2";
			this.gvPersonalGroup2.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvPersonalGroup2.OptionsBehavior.Editable = false;
			this.gvPersonalGroup2.OptionsCustomization.AllowFilter = false;
			this.gvPersonalGroup2.OptionsSelection.MultiSelect = true;
			this.gvPersonalGroup2.OptionsView.ShowGroupPanel = false;
			this.gvPersonalGroup2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																											 new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPersonalGroupID2, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// colPersonalGroupID2
			// 
			this.colPersonalGroupID2.Caption = "ID";
			this.colPersonalGroupID2.FieldName = "nMemoGroupID";
			this.colPersonalGroupID2.Name = "colPersonalGroupID2";
			this.colPersonalGroupID2.Visible = true;
			this.colPersonalGroupID2.VisibleIndex = 0;
			this.colPersonalGroupID2.Width = 71;
			// 
			// colPersonalGroupCode3
			// 
			this.colPersonalGroupCode3.Caption = "Code";
			this.colPersonalGroupCode3.FieldName = "strMemoGroupCode";
			this.colPersonalGroupCode3.Name = "colPersonalGroupCode3";
			this.colPersonalGroupCode3.Visible = true;
			this.colPersonalGroupCode3.VisibleIndex = 1;
			this.colPersonalGroupCode3.Width = 92;
			// 
			// colPersonalGroupDesc2
			// 
			this.colPersonalGroupDesc2.Caption = "Description";
			this.colPersonalGroupDesc2.FieldName = "strDescription";
			this.colPersonalGroupDesc2.Name = "colPersonalGroupDesc2";
			this.colPersonalGroupDesc2.Visible = true;
			this.colPersonalGroupDesc2.VisibleIndex = 2;
			this.colPersonalGroupDesc2.Width = 223;
			// 
			// gridctrPersonalGroup
			// 
			// 
			// gridctrPersonalGroup.EmbeddedNavigator
			// 
			this.gridctrPersonalGroup.EmbeddedNavigator.Name = "";
			this.gridctrPersonalGroup.Location = new System.Drawing.Point(72, 200);
			this.gridctrPersonalGroup.MainView = this.gvPersonalGroup;
			this.gridctrPersonalGroup.Name = "gridctrPersonalGroup";
			this.gridctrPersonalGroup.Size = new System.Drawing.Size(400, 88);
			this.gridctrPersonalGroup.TabIndex = 12;
			this.gridctrPersonalGroup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																												this.gvPersonalGroup});
			// 
			// gvPersonalGroup
			// 
			this.gvPersonalGroup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																								   this.colPersonalGroupID,
																								   this.colPersonalGroupCode,
																								   this.colPersonalGroupDesc});
			this.gvPersonalGroup.GridControl = this.gridctrPersonalGroup;
			this.gvPersonalGroup.Name = "gvPersonalGroup";
			this.gvPersonalGroup.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvPersonalGroup.OptionsBehavior.Editable = false;
			this.gvPersonalGroup.OptionsCustomization.AllowFilter = false;
			this.gvPersonalGroup.OptionsSelection.MultiSelect = true;
			this.gvPersonalGroup.OptionsView.ShowGroupPanel = false;
			this.gvPersonalGroup.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																											new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPersonalGroupID, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// colPersonalGroupID
			// 
			this.colPersonalGroupID.Caption = "ID";
			this.colPersonalGroupID.FieldName = "nMemoGroupID";
			this.colPersonalGroupID.Name = "colPersonalGroupID";
			this.colPersonalGroupID.Visible = true;
			this.colPersonalGroupID.VisibleIndex = 0;
			this.colPersonalGroupID.Width = 63;
			// 
			// colPersonalGroupCode
			// 
			this.colPersonalGroupCode.Caption = "Code";
			this.colPersonalGroupCode.FieldName = "strMemoGroupCode";
			this.colPersonalGroupCode.Name = "colPersonalGroupCode";
			this.colPersonalGroupCode.Visible = true;
			this.colPersonalGroupCode.VisibleIndex = 1;
			this.colPersonalGroupCode.Width = 97;
			// 
			// colPersonalGroupDesc
			// 
			this.colPersonalGroupDesc.Caption = "Description";
			this.colPersonalGroupDesc.FieldName = "strDescription";
			this.colPersonalGroupDesc.Name = "colPersonalGroupDesc";
			this.colPersonalGroupDesc.Visible = true;
			this.colPersonalGroupDesc.VisibleIndex = 2;
			this.colPersonalGroupDesc.Width = 226;
			// 
			// sbtnDGDel
			// 
			this.sbtnDGDel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnDGDel.Location = new System.Drawing.Point(476, 178);
			this.sbtnDGDel.Name = "sbtnDGDel";
			this.sbtnDGDel.Size = new System.Drawing.Size(30, 20);
			this.sbtnDGDel.TabIndex = 10;
			this.sbtnDGDel.Text = "<";
			this.sbtnDGDel.Click += new System.EventHandler(this.sbtnDGDel_Click);
			// 
			// sbtnDGAllDel
			// 
			this.sbtnDGAllDel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnDGAllDel.Location = new System.Drawing.Point(476, 156);
			this.sbtnDGAllDel.Name = "sbtnDGAllDel";
			this.sbtnDGAllDel.Size = new System.Drawing.Size(30, 20);
			this.sbtnDGAllDel.TabIndex = 9;
			this.sbtnDGAllDel.Text = "<<";
			this.sbtnDGAllDel.Click += new System.EventHandler(this.sbtnDGAllDel_Click);
			// 
			// sbtnDGAllAdd
			// 
			this.sbtnDGAllAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnDGAllAdd.Location = new System.Drawing.Point(476, 134);
			this.sbtnDGAllAdd.Name = "sbtnDGAllAdd";
			this.sbtnDGAllAdd.Size = new System.Drawing.Size(30, 20);
			this.sbtnDGAllAdd.TabIndex = 8;
			this.sbtnDGAllAdd.Text = ">>";
			this.sbtnDGAllAdd.Click += new System.EventHandler(this.sbtnDGAllAdd_Click);
			// 
			// sbtnDGAdd
			// 
			this.sbtnDGAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnDGAdd.Location = new System.Drawing.Point(476, 112);
			this.sbtnDGAdd.Name = "sbtnDGAdd";
			this.sbtnDGAdd.Size = new System.Drawing.Size(30, 20);
			this.sbtnDGAdd.TabIndex = 7;
			this.sbtnDGAdd.Text = ">";
			this.sbtnDGAdd.Click += new System.EventHandler(this.sbtnDGAdd_Click);
			// 
			// gridctrDepartmentGroup2
			// 
			// 
			// gridctrDepartmentGroup2.EmbeddedNavigator
			// 
			this.gridctrDepartmentGroup2.EmbeddedNavigator.Name = "";
			this.gridctrDepartmentGroup2.Location = new System.Drawing.Point(510, 110);
			this.gridctrDepartmentGroup2.MainView = this.gvDepartmentGroup2;
			this.gridctrDepartmentGroup2.Name = "gridctrDepartmentGroup2";
			this.gridctrDepartmentGroup2.Size = new System.Drawing.Size(400, 88);
			this.gridctrDepartmentGroup2.TabIndex = 11;
			this.gridctrDepartmentGroup2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																												   this.gvDepartmentGroup2});
			// 
			// gvDepartmentGroup2
			// 
			this.gvDepartmentGroup2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									  this.colDepartmentID2,
																									  this.colDepartmentGroupCode2,
																									  this.colDepartmentGroupDesc2});
			this.gvDepartmentGroup2.GridControl = this.gridctrDepartmentGroup2;
			this.gvDepartmentGroup2.Name = "gvDepartmentGroup2";
			this.gvDepartmentGroup2.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvDepartmentGroup2.OptionsBehavior.Editable = false;
			this.gvDepartmentGroup2.OptionsCustomization.AllowFilter = false;
			this.gvDepartmentGroup2.OptionsSelection.MultiSelect = true;
			this.gvDepartmentGroup2.OptionsView.ShowGroupPanel = false;
			this.gvDepartmentGroup2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																											   new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDepartmentID2, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// colDepartmentID2
			// 
			this.colDepartmentID2.Caption = "ID";
			this.colDepartmentID2.FieldName = "nMemoGroupID";
			this.colDepartmentID2.Name = "colDepartmentID2";
			this.colDepartmentID2.Visible = true;
			this.colDepartmentID2.VisibleIndex = 0;
			this.colDepartmentID2.Width = 70;
			// 
			// colDepartmentGroupCode2
			// 
			this.colDepartmentGroupCode2.Caption = "Code";
			this.colDepartmentGroupCode2.FieldName = "strMemoGroupCode";
			this.colDepartmentGroupCode2.Name = "colDepartmentGroupCode2";
			this.colDepartmentGroupCode2.Visible = true;
			this.colDepartmentGroupCode2.VisibleIndex = 1;
			this.colDepartmentGroupCode2.Width = 92;
			// 
			// colDepartmentGroupDesc2
			// 
			this.colDepartmentGroupDesc2.Caption = "Description";
			this.colDepartmentGroupDesc2.FieldName = "strDescription";
			this.colDepartmentGroupDesc2.Name = "colDepartmentGroupDesc2";
			this.colDepartmentGroupDesc2.Visible = true;
			this.colDepartmentGroupDesc2.VisibleIndex = 2;
			this.colDepartmentGroupDesc2.Width = 224;
			// 
			// gridctrDepartmentGroup
			// 
			// 
			// gridctrDepartmentGroup.EmbeddedNavigator
			// 
			this.gridctrDepartmentGroup.EmbeddedNavigator.Name = "";
			this.gridctrDepartmentGroup.Location = new System.Drawing.Point(72, 110);
			this.gridctrDepartmentGroup.MainView = this.gvDepartmentGroup;
			this.gridctrDepartmentGroup.Name = "gridctrDepartmentGroup";
			this.gridctrDepartmentGroup.Size = new System.Drawing.Size(400, 88);
			this.gridctrDepartmentGroup.TabIndex = 6;
			this.gridctrDepartmentGroup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																												  this.gvDepartmentGroup});
			// 
			// gvDepartmentGroup
			// 
			this.gvDepartmentGroup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									 this.colDepartmentGroup,
																									 this.colDepartmentGroupCode,
																									 this.colDepartmentGroupDesc});
			this.gvDepartmentGroup.GridControl = this.gridctrDepartmentGroup;
			this.gvDepartmentGroup.Name = "gvDepartmentGroup";
			this.gvDepartmentGroup.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvDepartmentGroup.OptionsBehavior.Editable = false;
			this.gvDepartmentGroup.OptionsCustomization.AllowFilter = false;
			this.gvDepartmentGroup.OptionsSelection.MultiSelect = true;
			this.gvDepartmentGroup.OptionsView.ShowGroupPanel = false;
			this.gvDepartmentGroup.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																											  new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDepartmentGroup, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// colDepartmentGroup
			// 
			this.colDepartmentGroup.Caption = "ID";
			this.colDepartmentGroup.FieldName = "nMemoGroupID";
			this.colDepartmentGroup.Name = "colDepartmentGroup";
			this.colDepartmentGroup.Visible = true;
			this.colDepartmentGroup.VisibleIndex = 0;
			this.colDepartmentGroup.Width = 66;
			// 
			// colDepartmentGroupCode
			// 
			this.colDepartmentGroupCode.Caption = "Code";
			this.colDepartmentGroupCode.FieldName = "strMemoGroupCode";
			this.colDepartmentGroupCode.Name = "colDepartmentGroupCode";
			this.colDepartmentGroupCode.Visible = true;
			this.colDepartmentGroupCode.VisibleIndex = 1;
			this.colDepartmentGroupCode.Width = 95;
			// 
			// colDepartmentGroupDesc
			// 
			this.colDepartmentGroupDesc.Caption = "Description";
			this.colDepartmentGroupDesc.FieldName = "strDescription";
			this.colDepartmentGroupDesc.Name = "colDepartmentGroupDesc";
			this.colDepartmentGroupDesc.Visible = true;
			this.colDepartmentGroupDesc.VisibleIndex = 2;
			this.colDepartmentGroupDesc.Width = 225;
			// 
			// sbtnBGDel
			// 
			this.sbtnBGDel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnBGDel.Location = new System.Drawing.Point(476, 88);
			this.sbtnBGDel.Name = "sbtnBGDel";
			this.sbtnBGDel.Size = new System.Drawing.Size(30, 20);
			this.sbtnBGDel.TabIndex = 4;
			this.sbtnBGDel.Text = "<";
			this.sbtnBGDel.Click += new System.EventHandler(this.sbtnBGDel_Click);
			// 
			// sbtnBGAllDel
			// 
			this.sbtnBGAllDel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnBGAllDel.Location = new System.Drawing.Point(476, 66);
			this.sbtnBGAllDel.Name = "sbtnBGAllDel";
			this.sbtnBGAllDel.Size = new System.Drawing.Size(30, 20);
			this.sbtnBGAllDel.TabIndex = 3;
			this.sbtnBGAllDel.Text = "<<";
			this.sbtnBGAllDel.Click += new System.EventHandler(this.sbtnBGAllDel_Click);
			// 
			// sbtnBGAllAdd
			// 
			this.sbtnBGAllAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnBGAllAdd.Location = new System.Drawing.Point(476, 44);
			this.sbtnBGAllAdd.Name = "sbtnBGAllAdd";
			this.sbtnBGAllAdd.Size = new System.Drawing.Size(30, 20);
			this.sbtnBGAllAdd.TabIndex = 2;
			this.sbtnBGAllAdd.Text = ">>";
			this.sbtnBGAllAdd.Click += new System.EventHandler(this.sbtnBGAllAdd_Click);
			// 
			// sbtnBGAdd
			// 
			this.sbtnBGAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnBGAdd.Location = new System.Drawing.Point(476, 22);
			this.sbtnBGAdd.Name = "sbtnBGAdd";
			this.sbtnBGAdd.Size = new System.Drawing.Size(30, 20);
			this.sbtnBGAdd.TabIndex = 1;
			this.sbtnBGAdd.Text = ">";
			this.sbtnBGAdd.Click += new System.EventHandler(this.sbtnBGAdd_Click);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(10, 292);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(60, 18);
			this.label6.TabIndex = 20;
			this.label6.Text = "Employee:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 202);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 30);
			this.label4.TabIndex = 19;
			this.label4.Text = "Personal Group:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 112);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 30);
			this.label5.TabIndex = 18;
			this.label5.Text = "Department Group:";
			// 
			// gridctrBranchReceipient2
			// 
			// 
			// gridctrBranchReceipient2.EmbeddedNavigator
			// 
			this.gridctrBranchReceipient2.EmbeddedNavigator.Name = "";
			this.gridctrBranchReceipient2.Location = new System.Drawing.Point(510, 20);
			this.gridctrBranchReceipient2.MainView = this.gvBranchReceipient2;
			this.gridctrBranchReceipient2.Name = "gridctrBranchReceipient2";
			this.gridctrBranchReceipient2.Size = new System.Drawing.Size(400, 88);
			this.gridctrBranchReceipient2.TabIndex = 5;
			this.gridctrBranchReceipient2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																													this.gvBranchReceipient2});
			// 
			// gvBranchReceipient2
			// 
			this.gvBranchReceipient2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									   this.colBranchCode2,
																									   this.colBranchName2});
			this.gvBranchReceipient2.GridControl = this.gridctrBranchReceipient2;
			this.gvBranchReceipient2.Name = "gvBranchReceipient2";
			this.gvBranchReceipient2.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvBranchReceipient2.OptionsBehavior.Editable = false;
			this.gvBranchReceipient2.OptionsCustomization.AllowFilter = false;
			this.gvBranchReceipient2.OptionsSelection.MultiSelect = true;
			this.gvBranchReceipient2.OptionsView.ShowGroupPanel = false;
			this.gvBranchReceipient2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																												new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colBranchCode2, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// colBranchCode2
			// 
			this.colBranchCode2.Caption = "Branch";
			this.colBranchCode2.FieldName = "strBranchCode";
			this.colBranchCode2.Name = "colBranchCode2";
			this.colBranchCode2.Visible = true;
			this.colBranchCode2.VisibleIndex = 0;
			this.colBranchCode2.Width = 104;
			// 
			// colBranchName2
			// 
			this.colBranchName2.Caption = "Branch Name";
			this.colBranchName2.FieldName = "strBranchName";
			this.colBranchName2.Name = "colBranchName2";
			this.colBranchName2.Visible = true;
			this.colBranchName2.VisibleIndex = 1;
			this.colBranchName2.Width = 282;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 34);
			this.label3.TabIndex = 16;
			this.label3.Text = "Branch Group:";
			// 
			// gridctrBranchReceipient
			// 
			// 
			// gridctrBranchReceipient.EmbeddedNavigator
			// 
			this.gridctrBranchReceipient.EmbeddedNavigator.Name = "";
			this.gridctrBranchReceipient.Location = new System.Drawing.Point(72, 20);
			this.gridctrBranchReceipient.MainView = this.gvBranchReceipient;
			this.gridctrBranchReceipient.Name = "gridctrBranchReceipient";
			this.gridctrBranchReceipient.Size = new System.Drawing.Size(400, 88);
			this.gridctrBranchReceipient.TabIndex = 0;
			this.gridctrBranchReceipient.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																												   this.gvBranchReceipient});
			// 
			// gvBranchReceipient
			// 
			this.gvBranchReceipient.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																									  this.colBranchCode,
																									  this.colBranchName});
			this.gvBranchReceipient.GridControl = this.gridctrBranchReceipient;
			this.gvBranchReceipient.Name = "gvBranchReceipient";
			this.gvBranchReceipient.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvBranchReceipient.OptionsBehavior.Editable = false;
			this.gvBranchReceipient.OptionsCustomization.AllowFilter = false;
			this.gvBranchReceipient.OptionsSelection.MultiSelect = true;
			this.gvBranchReceipient.OptionsView.ShowGroupPanel = false;
			this.gvBranchReceipient.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
																											   new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colBranchCode, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// colBranchCode
			// 
			this.colBranchCode.Caption = "Branch";
			this.colBranchCode.FieldName = "strBranchCode";
			this.colBranchCode.Name = "colBranchCode";
			this.colBranchCode.Visible = true;
			this.colBranchCode.VisibleIndex = 0;
			this.colBranchCode.Width = 107;
			// 
			// colBranchName
			// 
			this.colBranchName.Caption = "Branch Name";
			this.colBranchName.FieldName = "strBranchName";
			this.colBranchName.Name = "colBranchName";
			this.colBranchName.Visible = true;
			this.colBranchName.VisibleIndex = 1;
			this.colBranchName.Width = 279;
			// 
			// sbtnAdd
			// 
			this.sbtnAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnAdd.Location = new System.Drawing.Point(760, 396);
			this.sbtnAdd.Name = "sbtnAdd";
			this.sbtnAdd.TabIndex = 1;
			this.sbtnAdd.Text = "Add";
			this.sbtnAdd.Click += new System.EventHandler(this.sbtnAdd_Click);
			// 
			// sbtnCancel
			// 
			this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sbtnCancel.Location = new System.Drawing.Point(842, 396);
			this.sbtnCancel.Name = "sbtnCancel";
			this.sbtnCancel.TabIndex = 2;
			this.sbtnCancel.Text = "Cancel";
			// 
			// frmNewReceipient2
			// 
			this.AcceptButton = this.sbtnAdd;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.sbtnCancel;
			this.ClientSize = new System.Drawing.Size(920, 424);
			this.Controls.Add(this.sbtnAdd);
			this.Controls.Add(this.sbtnCancel);
			this.Controls.Add(this.groupControl1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmNewReceipient2";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Receipient";
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridctrEmployee2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvEmployee2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridctrEmployee)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvEmployee)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridctrPersonalGroup2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPersonalGroup2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridctrPersonalGroup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPersonalGroup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridctrDepartmentGroup2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvDepartmentGroup2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridctrDepartmentGroup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvDepartmentGroup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridctrBranchReceipient2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvBranchReceipient2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridctrBranchReceipient)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvBranchReceipient)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private bool ValidateBeforeSave()
		{
			if (gvBranchReceipient2.RowCount == 0 && gvDepartmentGroup2.RowCount == 0 && gvEmployee2.RowCount == 0 &&
				gvPersonalGroup2.RowCount == 0)
			{
				UI.ShowErrorMessage(this, "Please add at least one recepient.");
				return false;
			}

			return true;
		}

		private void sbtnBGAdd_Click(object sender, System.EventArgs e)
		{
			int[] rowsHandle = gvBranchReceipient.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gvBranchReceipient.GetDataRow(index);
				DataRow rNew = dtBranch.NewRow();
				rNew.BeginEdit();
				rNew["strBranchCode"] = rCopy["strBranchCode"];
				rNew["strBranchName"] = rCopy["strBranchName"];
				rNew.EndEdit();
				dtBranch.Rows.Add(rNew);
			}
			gvBranchReceipient.DeleteSelectedRows();
		}

		private void sbtnDGAdd_Click(object sender, System.EventArgs e)
		{
			int[] rowsHandle = gvDepartmentGroup.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gvDepartmentGroup.GetDataRow(index);
				DataRow rNew = dtDepartmentGroup.NewRow();
				rNew.BeginEdit();
				rNew["nMemoGroupID"] = rCopy["nMemoGroupID"];
				rNew["strMemoGroupCode"] = rCopy["strMemoGroupCode"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtDepartmentGroup.Rows.Add(rNew);
			}
			gvDepartmentGroup.DeleteSelectedRows();
		}

		private void sbtnPGAdd_Click(object sender, System.EventArgs e)
		{
			int[] rowsHandle = gvPersonalGroup.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gvPersonalGroup.GetDataRow(index);
				DataRow rNew = dtPersonalGroup.NewRow();
				rNew.BeginEdit();
				rNew["nMemoGroupID"] = rCopy["nMemoGroupID"];
				rNew["strMemoGroupCode"] = rCopy["strMemoGroupCode"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtPersonalGroup.Rows.Add(rNew);
			}
			gvPersonalGroup.DeleteSelectedRows();
		}

		private void sbtnEmpAdd_Click(object sender, System.EventArgs e)
		{
			int[] rowsHandle = gvEmployee.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gvEmployee.GetDataRow(index);
				DataRow rNew = dtEmployee.NewRow();
				rNew.BeginEdit();
				rNew["nEmployeeID"] = rCopy["nEmployeeID"];
				rNew["strEmployeeName"] = rCopy["strEmployeeName"];
				rNew.EndEdit();
				dtEmployee.Rows.Add(rNew);
			}
			gvEmployee.DeleteSelectedRows();
		}

		private void sbtnBGDel_Click(object sender, System.EventArgs e)
		{
			int[] rowsHandle = gvBranchReceipient2.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			DataTable dtTemp = (gvBranchReceipient.DataSource as DataView).Table;
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gvBranchReceipient2.GetDataRow(index);
				DataRow rNew = dtTemp.NewRow();
				rNew.BeginEdit();
				rNew["strBranchCode"] = rCopy["strBranchCode"];
				rNew["strBranchName"] = rCopy["strBranchName"];
				rNew.EndEdit();
				dtTemp.Rows.Add(rNew);
			}
			gvBranchReceipient2.DeleteSelectedRows();
		}

		private void sbtnDGDel_Click(object sender, System.EventArgs e)
		{
			int[] rowsHandle = gvDepartmentGroup2.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			DataTable dtTemp = (gvDepartmentGroup.DataSource as DataView).Table;
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gvDepartmentGroup2.GetDataRow(index);
				DataRow rNew = dtTemp.NewRow();
				rNew.BeginEdit();
				rNew["nMemoGroupID"] = rCopy["nMemoGroupID"];
				rNew["strMemoGroupCode"] = rCopy["strMemoGroupCode"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtTemp.Rows.Add(rNew);
			}
			gvDepartmentGroup2.DeleteSelectedRows();
		}

		private void sbtnPGDel_Click(object sender, System.EventArgs e)
		{
			int[] rowsHandle = gvPersonalGroup2.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			DataTable dtTemp = (gvPersonalGroup.DataSource as DataView).Table;
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gvPersonalGroup2.GetDataRow(index);
				DataRow rNew = dtTemp.NewRow();
				rNew.BeginEdit();
				rNew["nMemoGroupID"] = rCopy["nMemoGroupID"];
				rNew["strMemoGroupCode"] = rCopy["strMemoGroupCode"];
				rNew["strDescription"] = rCopy["strDescription"];
				rNew.EndEdit();
				dtTemp.Rows.Add(rNew);
			}
			gvPersonalGroup2.DeleteSelectedRows();
		}

		private void sbtnEmpDel_Click(object sender, System.EventArgs e)
		{
			int[] rowsHandle = gvEmployee2.GetSelectedRows();
			if (rowsHandle == null || rowsHandle.Length == 0)
			{
				UI.ShowErrorMessage(this, "Please select at least one row.");
				return;
			}
			DataTable dtTemp = (gvEmployee.DataSource as DataView).Table;
			foreach(int index in rowsHandle)
			{
				DataRow rCopy = gvEmployee2.GetDataRow(index);
				DataRow rNew = dtTemp.NewRow();
				rNew.BeginEdit();
				rNew["nEmployeeID"] = rCopy["nEmployeeID"];
				rNew["strEmployeeName"] = rCopy["strEmployeeName"];
				rNew.EndEdit();
				dtTemp.Rows.Add(rNew);
			}
			gvEmployee2.DeleteSelectedRows();
		}

		private void AddAll(GridView gvFrom, GridView gvTo, ref DataTable tableTo)
		{
			gvFrom.BeginDataUpdate();
			gvTo.BeginDataUpdate();
			DataTable dtTemp = (gvFrom.DataSource as DataView).Table;
			dtTemp.RejectChanges();

			for (int i = tableTo.Rows.Count - 1; i >= 0; i--)
			{
				if (tableTo.Rows[i].RowState != DataRowState.Deleted)
					tableTo.Rows[i].Delete();
			}
			tableTo = dtTemp.Copy();
			gvTo.GridControl.DataSource = tableTo;

			for (int i = dtTemp.Rows.Count - 1; i >= 0; i--)
			{
				if (dtTemp.Rows[i].RowState != DataRowState.Deleted)
					dtTemp.Rows[i].Delete();
			}
			gvFrom.EndDataUpdate();
			gvTo.EndDataUpdate();
		}

		private void DeleteAll(GridView gvFrom, GridView gvTo, ref DataTable tableTo)
		{
			gvFrom.BeginDataUpdate();
			gvTo.BeginDataUpdate();
			DataTable dtTemp = (gvFrom.DataSource as DataView).Table;
			dtTemp.RejectChanges();

			for (int i = tableTo.Rows.Count - 1; i >= 0; i--)
			{
				if (tableTo.Rows[i].RowState != DataRowState.Deleted)
					tableTo.Rows[i].Delete();
			}
			gvFrom.EndDataUpdate();
			gvTo.EndDataUpdate();
		}

		private void sbtnBGAllAdd_Click(object sender, System.EventArgs e)
		{
			AddAll(gvBranchReceipient, gvBranchReceipient2, ref dtBranch);
		}

		private void sbtnBGAllDel_Click(object sender, System.EventArgs e)
		{
			DeleteAll(gvBranchReceipient, gvBranchReceipient2, ref dtBranch);
		}

		private void sbtnDGAllAdd_Click(object sender, System.EventArgs e)
		{
			AddAll(gvDepartmentGroup, gvDepartmentGroup2, ref dtDepartmentGroup);
		}

		private void sbtnDGAllDel_Click(object sender, System.EventArgs e)
		{
			DeleteAll(gvDepartmentGroup, gvDepartmentGroup2, ref dtDepartmentGroup);
		}

		private void sbtnPGAllAdd_Click(object sender, System.EventArgs e)
		{
			AddAll(gvPersonalGroup, gvPersonalGroup2, ref dtPersonalGroup);
		}

		private void sbtnPGAllDel_Click(object sender, System.EventArgs e)
		{
			DeleteAll(gvPersonalGroup, gvPersonalGroup2, ref dtPersonalGroup);
		}

		private void sbtnEmpAllAdd_Click(object sender, System.EventArgs e)
		{
			AddAll(gvEmployee, gvEmployee2, ref dtEmployee);
		}

		private void sbtnEmpAllDel_Click(object sender, System.EventArgs e)
		{
			DeleteAll(gvEmployee, gvEmployee2, ref dtEmployee);
		}

		private void sbtnAdd_Click(object sender, System.EventArgs e)
		{
			if (!ValidateBeforeSave())
				return;

			try
			{
				if (!myMemo.AddReceipient(nMemoID, dtBranch, dtDepartmentGroup, dtPersonalGroup, dtEmployee))
				{
					UI.ShowErrorMessage(this, "Add new operation failed.");
				}
				else
					this.DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				UI.ShowErrorMessage(this, ex.Message);
			}
		}
	}
}
