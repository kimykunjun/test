namespace ACMS.ACMSManager.Human_Resource.Reports
{
    partial class RPAllIncomeDetail
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
            this.ThirdGridIncomeAnalysis = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivotGridField11 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField12 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField9 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.label1 = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dWVIncomeAnalysisprev10BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.dsAllIncomeDetail = new ACMS.dsAllIncomeDetail();
            this.dWV_IncomeAnalysis_prev10TableAdapter = new ACMS.dsAllIncomeDetailTableAdapters.DWV_IncomeAnalysis_prev10TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ThirdGridIncomeAnalysis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dWVIncomeAnalysisprev10BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAllIncomeDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // ThirdGridIncomeAnalysis
            // 
            this.ThirdGridIncomeAnalysis.Appearance.HeaderGroupLine.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.ThirdGridIncomeAnalysis.Appearance.HeaderGroupLine.Options.UseForeColor = true;
            this.ThirdGridIncomeAnalysis.AppearancePrint.FieldValueGrandTotal.ForeColor = System.Drawing.Color.Black;
            this.ThirdGridIncomeAnalysis.AppearancePrint.FieldValueGrandTotal.Options.UseForeColor = true;
            this.ThirdGridIncomeAnalysis.AppearancePrint.FieldValueTotal.ForeColor = System.Drawing.Color.Black;
            this.ThirdGridIncomeAnalysis.AppearancePrint.FieldValueTotal.Options.UseForeColor = true;
            this.ThirdGridIncomeAnalysis.Cursor = System.Windows.Forms.Cursors.Default;
            this.ThirdGridIncomeAnalysis.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pivotGridField11,
            this.pivotGridField12,
            this.pivotGridField9});
            this.ThirdGridIncomeAnalysis.Location = new System.Drawing.Point(2, 36);
            this.ThirdGridIncomeAnalysis.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.ThirdGridIncomeAnalysis.Name = "ThirdGridIncomeAnalysis";
            this.ThirdGridIncomeAnalysis.OptionsCustomization.AllowDrag = false;
            this.ThirdGridIncomeAnalysis.OptionsCustomization.AllowExpand = false;
            this.ThirdGridIncomeAnalysis.OptionsCustomization.AllowSort = false;
            this.ThirdGridIncomeAnalysis.OptionsDataField.Area = DevExpress.XtraPivotGrid.PivotDataArea.RowArea;
            this.ThirdGridIncomeAnalysis.OptionsDataField.AreaIndex = 1;
            this.ThirdGridIncomeAnalysis.OptionsPrint.PageSettings.Margins = new System.Drawing.Printing.Margins(0, 2, 0, 0);
            this.ThirdGridIncomeAnalysis.OptionsView.ShowColumnHeaders = false;
            this.ThirdGridIncomeAnalysis.OptionsView.ShowDataHeaders = false;
            this.ThirdGridIncomeAnalysis.OptionsView.ShowFilterHeaders = false;
            this.ThirdGridIncomeAnalysis.Size = new System.Drawing.Size(1056, 555);
            this.ThirdGridIncomeAnalysis.TabIndex = 152;
            // 
            // pivotGridField11
            // 
            this.pivotGridField11.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField11.AreaIndex = 0;
            this.pivotGridField11.Caption = "Nett Amount";
            this.pivotGridField11.FieldName = "mNettAmount";
            this.pivotGridField11.Name = "pivotGridField11";
            this.pivotGridField11.Width = 90;
            // 
            // pivotGridField12
            // 
            this.pivotGridField12.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField12.AreaIndex = 0;
            this.pivotGridField12.Caption = "Branch";
            this.pivotGridField12.FieldName = "strBranchCode";
            this.pivotGridField12.Name = "pivotGridField12";
            this.pivotGridField12.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField12.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField12.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField12.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField12.Width = 80;
            // 
            // pivotGridField9
            // 
            this.pivotGridField9.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField9.AreaIndex = 0;
            this.pivotGridField9.Caption = "Date";
            this.pivotGridField9.FieldName = "dtDate";
            this.pivotGridField9.Name = "pivotGridField9";
            this.pivotGridField9.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField9.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField9.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField9.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField9.ValueFormat.FormatString = "d";
            this.pivotGridField9.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.pivotGridField9.Width = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 153;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(2, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(110, 19);
            this.labelControl1.TabIndex = 155;
            this.labelControl1.Text = "labelControl1";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(489, 10);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(69, 23);
            this.simpleButton1.TabIndex = 156;
            this.simpleButton1.Text = "Print";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // dsAllIncomeDetail
            // 
            this.dsAllIncomeDetail.DataSetName = "dsAllIncomeDetail";
            this.dsAllIncomeDetail.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dWV_IncomeAnalysis_prev10TableAdapter
            // 
            this.dWV_IncomeAnalysis_prev10TableAdapter.ClearBeforeFill = true;
            // 
            // RPAllIncomeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 593);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ThirdGridIncomeAnalysis);
            this.Name = "RPAllIncomeDetail";
            this.Text = "RPAllIncomeDetail";
            ((System.ComponentModel.ISupportInitialize)(this.ThirdGridIncomeAnalysis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dWVIncomeAnalysisprev10BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAllIncomeDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraPivotGrid.PivotGridControl ThirdGridIncomeAnalysis;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField11;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField12;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField9;
        private dsAllIncomeDetail dsAllIncomeDetail;
        private System.Windows.Forms.BindingSource dWVIncomeAnalysisprev10BindingSource;
        private ACMS.dsAllIncomeDetailTableAdapters.DWV_IncomeAnalysis_prev10TableAdapter dWV_IncomeAnalysis_prev10TableAdapter;
        private System.Windows.Forms.Label label1;
        //private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
    }
}