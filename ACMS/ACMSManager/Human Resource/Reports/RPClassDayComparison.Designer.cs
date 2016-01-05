namespace ACMS.ACMSManager.Human_Resource.Reports
{
    partial class RPClassDayComparison
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.lkedtClassType = new DevExpress.XtraEditors.LookUpEdit();
            this.tblClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aCMSDataSet4 = new ACMS.ACMSDataSet4();
            this.label2 = new System.Windows.Forms.Label();
            this.dtDate1 = new System.Windows.Forms.MonthCalendar();
            this.dtDate2 = new System.Windows.Forms.MonthCalendar();
            this.gridMaster = new DevExpress.XtraGrid.GridControl();
            this.tblClassInstanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsClassInstance = new ACMS.dsClassInstance();
            this.gridMasterView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.coldtDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstrBranchCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstrClassCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstrEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldtStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAttendance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lk_Category = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.tblClassTableAdapter = new ACMS.ACMSDataSet4TableAdapters.tblClassTableAdapter();
            this.tblClassInstanceTableAdapter = new ACMS.dsClassInstanceTableAdapters.tblClassInstanceTableAdapter();
            this.tblClassInstanceBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dcClassIns = new ACMS.dcClassIns();
            this.tblClassInstanceTableAdapter1 = new ACMS.dcClassInsTableAdapters.tblClassInstanceTableAdapter();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lkedtClassType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblClassBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCMSDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblClassInstanceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClassInstance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMasterView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_Category)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblClassInstanceBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dcClassIns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // lkedtClassType
            // 
            this.lkedtClassType.EditValue = "";
            this.lkedtClassType.Location = new System.Drawing.Point(12, 35);
            this.lkedtClassType.Name = "lkedtClassType";
            this.lkedtClassType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkedtClassType.Properties.DataSource = this.tblClassBindingSource;
            this.lkedtClassType.Properties.DisplayMember = "strDescription";
            this.lkedtClassType.Properties.ValueMember = "strClassCode";
            this.lkedtClassType.Size = new System.Drawing.Size(120, 20);
            this.lkedtClassType.TabIndex = 145;
            // 
            // tblClassBindingSource
            // 
            this.tblClassBindingSource.DataMember = "tblClass";
            this.tblClassBindingSource.DataSource = this.aCMSDataSet4;
            // 
            // aCMSDataSet4
            // 
            this.aCMSDataSet4.DataSetName = "ACMSDataSet4";
            this.aCMSDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 144;
            this.label2.Text = "CLASS TYPE";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtDate1
            // 
            this.dtDate1.Location = new System.Drawing.Point(275, 0);
            this.dtDate1.Name = "dtDate1";
            this.dtDate1.TabIndex = 147;
            this.dtDate1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.dtDate1_DateSelected);
            // 
            // dtDate2
            // 
            this.dtDate2.Location = new System.Drawing.Point(560, 0);
            this.dtDate2.Name = "dtDate2";
            this.dtDate2.TabIndex = 148;
            this.dtDate2.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.dtDate2_DateSelected);
            // 
            // gridMaster
            // 
            this.gridMaster.DataSource = this.tblClassInstanceBindingSource;
            this.gridMaster.EmbeddedNavigator.Name = "";
            this.gridMaster.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gridLevelNode1.RelationName = "Level1";
            this.gridMaster.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridMaster.Location = new System.Drawing.Point(-6, 149);
            this.gridMaster.MainView = this.gridMasterView;
            this.gridMaster.Name = "gridMaster";
            this.gridMaster.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lk_Category});
            this.gridMaster.Size = new System.Drawing.Size(937, 203);
            this.gridMaster.TabIndex = 149;
            this.gridMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridMasterView});
            this.gridMaster.DoubleClick += new System.EventHandler(this.gridMaster_DoubleClick);
            // 
            // tblClassInstanceBindingSource
            // 
            this.tblClassInstanceBindingSource.DataMember = "tblClassInstance";
            this.tblClassInstanceBindingSource.DataSource = this.dsClassInstance;
            // 
            // dsClassInstance
            // 
            this.dsClassInstance.DataSetName = "dsClassInstance";
            this.dsClassInstance.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridMasterView
            // 
            this.gridMasterView.ActiveFilterEnabled = false;
            this.gridMasterView.Appearance.GroupPanel.BackColor = System.Drawing.Color.White;
            this.gridMasterView.Appearance.GroupPanel.BorderColor = System.Drawing.Color.White;
            this.gridMasterView.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.gridMasterView.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridMasterView.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridMasterView.Appearance.GroupPanel.Options.UseBorderColor = true;
            this.gridMasterView.Appearance.GroupPanel.Options.UseFont = true;
            this.gridMasterView.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridMasterView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridMasterView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridMasterView.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridMasterView.AppearancePrint.HeaderPanel.Options.UseForeColor = true;
            this.gridMasterView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gridMasterView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.coldtDate,
            this.colstrBranchCode,
            this.colstrClassCode,
            this.colstrEmployeeName,
            this.coldtStartTime,
            this.colAttendance});
            this.gridMasterView.GridControl = this.gridMaster;
            this.gridMasterView.Name = "gridMasterView";
            this.gridMasterView.OptionsBehavior.Editable = false;
            this.gridMasterView.OptionsCustomization.AllowFilter = false;
            this.gridMasterView.OptionsCustomization.AllowSort = false;
            this.gridMasterView.OptionsPrint.PrintGroupFooter = false;
            this.gridMasterView.OptionsPrint.UsePrintStyles = true;
            this.gridMasterView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridMasterView.OptionsView.ShowGroupPanel = false;
            // 
            // coldtDate
            // 
            this.coldtDate.Caption = "Date";
            this.coldtDate.FieldName = "dtDate";
            this.coldtDate.Name = "coldtDate";
            this.coldtDate.Visible = true;
            this.coldtDate.VisibleIndex = 0;
            // 
            // colstrBranchCode
            // 
            this.colstrBranchCode.Caption = "Branch Code";
            this.colstrBranchCode.FieldName = "strBranchCode";
            this.colstrBranchCode.Name = "colstrBranchCode";
            this.colstrBranchCode.Visible = true;
            this.colstrBranchCode.VisibleIndex = 1;
            // 
            // colstrClassCode
            // 
            this.colstrClassCode.Caption = "Class Code";
            this.colstrClassCode.FieldName = "strClassCode";
            this.colstrClassCode.Name = "colstrClassCode";
            this.colstrClassCode.Visible = true;
            this.colstrClassCode.VisibleIndex = 2;
            // 
            // colstrEmployeeName
            // 
            this.colstrEmployeeName.Caption = "Insturctor";
            this.colstrEmployeeName.FieldName = "strEmployeeName";
            this.colstrEmployeeName.Name = "colstrEmployeeName";
            this.colstrEmployeeName.Visible = true;
            this.colstrEmployeeName.VisibleIndex = 3;
            // 
            // coldtStartTime
            // 
            this.coldtStartTime.Caption = "Start Time";
            this.coldtStartTime.DisplayFormat.FormatString = "T";
            this.coldtStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.coldtStartTime.FieldName = "dtStartTime";
            this.coldtStartTime.Name = "coldtStartTime";
            this.coldtStartTime.Visible = true;
            this.coldtStartTime.VisibleIndex = 4;
            // 
            // colAttendance
            // 
            this.colAttendance.Caption = "No of Attendance";
            this.colAttendance.FieldName = "Attendance";
            this.colAttendance.Name = "colAttendance";
            this.colAttendance.Visible = true;
            this.colAttendance.VisibleIndex = 5;
            // 
            // lk_Category
            // 
            this.lk_Category.AutoHeight = false;
            this.lk_Category.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_Category.Name = "lk_Category";
            // 
            // tblClassTableAdapter
            // 
            this.tblClassTableAdapter.ClearBeforeFill = true;
            // 
            // tblClassInstanceTableAdapter
            // 
            this.tblClassInstanceTableAdapter.ClearBeforeFill = true;
            // 
            // tblClassInstanceBindingSource1
            // 
            this.tblClassInstanceBindingSource1.DataMember = "tblClassInstance";
            this.tblClassInstanceBindingSource1.DataSource = this.dcClassIns;
            // 
            // dcClassIns
            // 
            this.dcClassIns.DataSetName = "dcClassIns";
            this.dcClassIns.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblClassInstanceTableAdapter1
            // 
            this.tblClassInstanceTableAdapter1.ClearBeforeFill = true;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tblClassInstanceBindingSource1;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gridLevelNode2.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.gridControl1.Location = new System.Drawing.Point(-6, 358);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.gridControl1.Size = new System.Drawing.Size(937, 203);
            this.gridControl1.TabIndex = 150;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.ActiveFilterEnabled = false;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupPanel.BorderColor = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.AppearancePrint.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsPrint.PrintGroupFooter = false;
            this.gridView1.OptionsPrint.UsePrintStyles = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Date";
            this.gridColumn1.FieldName = "dtDate";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Branch Code";
            this.gridColumn2.FieldName = "strBranchCode";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Class Code";
            this.gridColumn3.FieldName = "strClassCode";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Insturctor";
            this.gridColumn4.FieldName = "strEmployeeName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Start Time";
            this.gridColumn5.DisplayFormat.FormatString = "T";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn5.FieldName = "dtStartTime";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "No of Attendance";
            this.gridColumn6.FieldName = "Attendance";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // RPClassDayComparison
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 622);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.gridMaster);
            this.Controls.Add(this.dtDate2);
            this.Controls.Add(this.dtDate1);
            this.Controls.Add(this.lkedtClassType);
            this.Controls.Add(this.label2);
            this.Name = "RPClassDayComparison";
            this.ShowInTaskbar = false;
            this.Text = "RPClassDayComparison";
            this.Load += new System.EventHandler(this.RPClassDayComparison_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lkedtClassType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblClassBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCMSDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblClassInstanceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClassInstance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMasterView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_Category)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblClassInstanceBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dcClassIns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lkedtClassType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MonthCalendar dtDate1;
        private System.Windows.Forms.MonthCalendar dtDate2;
        private DevExpress.XtraGrid.GridControl gridMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView gridMasterView;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lk_Category;
        private ACMSDataSet4 aCMSDataSet4;
        private System.Windows.Forms.BindingSource tblClassBindingSource;
        private ACMS.ACMSDataSet4TableAdapters.tblClassTableAdapter tblClassTableAdapter;
        private dsClassInstance dsClassInstance;
        private System.Windows.Forms.BindingSource tblClassInstanceBindingSource;
        private ACMS.dsClassInstanceTableAdapters.tblClassInstanceTableAdapter tblClassInstanceTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn coldtDate;
        private DevExpress.XtraGrid.Columns.GridColumn colstrBranchCode;
        private DevExpress.XtraGrid.Columns.GridColumn colstrClassCode;
        private DevExpress.XtraGrid.Columns.GridColumn coldtStartTime;
        private dcClassIns dcClassIns;
        private System.Windows.Forms.BindingSource tblClassInstanceBindingSource1;
        private ACMS.dcClassInsTableAdapters.tblClassInstanceTableAdapter tblClassInstanceTableAdapter1;
        private DevExpress.XtraGrid.Columns.GridColumn colAttendance;
        private DevExpress.XtraGrid.Columns.GridColumn colstrEmployeeName;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
    }
}