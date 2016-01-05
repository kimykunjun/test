namespace ACMS.ACMSManager.Human_Resource.Reports
{
    partial class RPCashCardReport
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
            this.gridCashCardUsage = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcMerchant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcBal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRecNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTransType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTimeStamp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPurAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label12 = new System.Windows.Forms.Label();
            this.ToYear = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.ToMonth = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.Year = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.dMonth = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSN = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbCAN = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnGenerate = new DevExpress.XtraEditors.SimpleButton();
            this.gridExcel = new DevExpress.XtraGrid.GridControl();
            this.gridViewExcel = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridCashCardUsage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Year.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCAN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // gridCashCardUsage
            // 
            this.gridCashCardUsage.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridCashCardUsage.EmbeddedNavigator.UseWaitCursor = true;
            this.gridCashCardUsage.Location = new System.Drawing.Point(25, 94);
            this.gridCashCardUsage.MainView = this.gridView1;
            this.gridCashCardUsage.Margin = new System.Windows.Forms.Padding(4);
            this.gridCashCardUsage.Name = "gridCashCardUsage";
            this.gridCashCardUsage.Size = new System.Drawing.Size(971, 316);
            this.gridCashCardUsage.TabIndex = 1;
            this.gridCashCardUsage.UseWaitCursor = true;
            this.gridCashCardUsage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcMerchant,
            this.gcBal,
            this.gcSN,
            this.gcCAN,
            this.gcRecNo,
            this.gcTransType,
            this.gcTimeStamp,
            this.gcPurAmt,
            this.gcTime});
            this.gridView1.GridControl = this.gridCashCardUsage;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gcMerchant
            // 
            this.gcMerchant.Caption = "Merchant";
            this.gcMerchant.FieldName = "strMerchant";
            this.gcMerchant.Name = "gcMerchant";
            this.gcMerchant.Visible = true;
            this.gcMerchant.VisibleIndex = 8;
            // 
            // gcBal
            // 
            this.gcBal.Caption = "Balance";
            this.gcBal.FieldName = "Bal";
            this.gcBal.Name = "gcBal";
            this.gcBal.Visible = true;
            this.gcBal.VisibleIndex = 0;
            // 
            // gcSN
            // 
            this.gcSN.Caption = "Serial Number";
            this.gcSN.FieldName = "strSN";
            this.gcSN.Name = "gcSN";
            this.gcSN.Visible = true;
            this.gcSN.VisibleIndex = 1;
            // 
            // gcCAN
            // 
            this.gcCAN.Caption = "CAN";
            this.gcCAN.FieldName = "strCAN";
            this.gcCAN.Name = "gcCAN";
            this.gcCAN.Visible = true;
            this.gcCAN.VisibleIndex = 2;
            // 
            // gcRecNo
            // 
            this.gcRecNo.Caption = "Record No";
            this.gcRecNo.FieldName = "RecNo";
            this.gcRecNo.Name = "gcRecNo";
            this.gcRecNo.Visible = true;
            this.gcRecNo.VisibleIndex = 3;
            // 
            // gcTransType
            // 
            this.gcTransType.Caption = "Transaction Type";
            this.gcTransType.FieldName = "strTransType";
            this.gcTransType.Name = "gcTransType";
            this.gcTransType.Visible = true;
            this.gcTransType.VisibleIndex = 4;
            // 
            // gcTimeStamp
            // 
            this.gcTimeStamp.Caption = "Date";
            this.gcTimeStamp.FieldName = "dtDate";
            this.gcTimeStamp.Name = "gcTimeStamp";
            this.gcTimeStamp.Visible = true;
            this.gcTimeStamp.VisibleIndex = 5;
            // 
            // gcPurAmt
            // 
            this.gcPurAmt.Caption = "Purchase Amt.";
            this.gcPurAmt.FieldName = "PurAmt";
            this.gcPurAmt.Name = "gcPurAmt";
            this.gcPurAmt.Visible = true;
            this.gcPurAmt.VisibleIndex = 7;
            // 
            // gcTime
            // 
            this.gcTime.Caption = "Time";
            this.gcTime.FieldName = "dtTime";
            this.gcTime.Name = "gcTime";
            this.gcTime.Visible = true;
            this.gcTime.VisibleIndex = 6;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(528, 11);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 23);
            this.label12.TabIndex = 244;
            this.label12.Text = "Year";
            // 
            // ToYear
            // 
            this.ToYear.Location = new System.Drawing.Point(591, 9);
            this.ToYear.Margin = new System.Windows.Forms.Padding(4);
            this.ToYear.Name = "ToYear";
            this.ToYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ToYear.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ToYear.Size = new System.Drawing.Size(75, 22);
            this.ToYear.TabIndex = 247;
            // 
            // ToMonth
            // 
            this.ToMonth.EditValue = 1;
            this.ToMonth.Location = new System.Drawing.Point(424, 10);
            this.ToMonth.Margin = new System.Windows.Forms.Padding(4);
            this.ToMonth.Name = "ToMonth";
            this.ToMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ToMonth.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("January", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("February", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("March", 3, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("April", 4, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("May", 5, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("June", 6, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("July", 7, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("August", 8, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("September", 9, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("October", 10, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("November", 11, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("December", 12, -1)});
            this.ToMonth.Size = new System.Drawing.Size(96, 22);
            this.ToMonth.TabIndex = 246;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(363, 12);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 18);
            this.label11.TabIndex = 245;
            this.label11.Text = "Month";
            // 
            // Year
            // 
            this.Year.Location = new System.Drawing.Point(231, 11);
            this.Year.Margin = new System.Windows.Forms.Padding(4);
            this.Year.Name = "Year";
            this.Year.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Year.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Year.Size = new System.Drawing.Size(75, 22);
            this.Year.TabIndex = 243;
            // 
            // dMonth
            // 
            this.dMonth.EditValue = 1;
            this.dMonth.Location = new System.Drawing.Point(84, 12);
            this.dMonth.Margin = new System.Windows.Forms.Padding(4);
            this.dMonth.Name = "dMonth";
            this.dMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dMonth.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("January", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("February", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("March", 3, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("April", 4, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("May", 5, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("June", 6, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("July", 7, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("August", 8, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("September", 9, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("October", 10, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("November", 11, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("December", 12, -1)});
            this.dMonth.Size = new System.Drawing.Size(85, 22);
            this.dMonth.TabIndex = 242;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 25);
            this.label2.TabIndex = 241;
            this.label2.Text = "Month";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(177, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 240;
            this.label1.Text = "Year";
            // 
            // cbSN
            // 
            this.cbSN.Location = new System.Drawing.Point(84, 41);
            this.cbSN.Margin = new System.Windows.Forms.Padding(4);
            this.cbSN.Name = "cbSN";
            this.cbSN.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbSN.Size = new System.Drawing.Size(221, 22);
            this.cbSN.TabIndex = 239;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(313, 12);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 18);
            this.label10.TabIndex = 238;
            this.label10.Text = "To";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 41);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 25);
            this.label7.TabIndex = 237;
            this.label7.Text = "SN";
            // 
            // cbCAN
            // 
            this.cbCAN.Location = new System.Drawing.Point(424, 42);
            this.cbCAN.Margin = new System.Windows.Forms.Padding(4);
            this.cbCAN.Name = "cbCAN";
            this.cbCAN.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbCAN.Size = new System.Drawing.Size(221, 22);
            this.cbCAN.TabIndex = 249;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(361, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 25);
            this.label3.TabIndex = 248;
            this.label3.Text = "CAN";
            // 
            // btnExport
            // 
            this.btnExport.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExport.Appearance.Options.UseBackColor = true;
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnExport.Location = new System.Drawing.Point(785, 42);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 25);
            this.btnExport.TabIndex = 251;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnGenerate.Appearance.Options.UseBackColor = true;
            this.btnGenerate.Appearance.Options.UseFont = true;
            this.btnGenerate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnGenerate.Location = new System.Drawing.Point(679, 42);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(85, 25);
            this.btnGenerate.TabIndex = 250;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // gridExcel
            // 
            this.gridExcel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridExcel.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridExcel.Location = new System.Drawing.Point(0, 420);
            this.gridExcel.MainView = this.gridViewExcel;
            this.gridExcel.Margin = new System.Windows.Forms.Padding(4);
            this.gridExcel.Name = "gridExcel";
            this.gridExcel.Size = new System.Drawing.Size(1023, 177);
            this.gridExcel.TabIndex = 253;
            this.gridExcel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewExcel});
            this.gridExcel.Visible = false;
            // 
            // gridViewExcel
            // 
            this.gridViewExcel.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.gridViewExcel.GridControl = this.gridExcel;
            this.gridViewExcel.Name = "gridViewExcel";
            this.gridViewExcel.OptionsBehavior.Editable = false;
            this.gridViewExcel.OptionsCustomization.AllowFilter = false;
            this.gridViewExcel.OptionsView.ColumnAutoWidth = false;
            this.gridViewExcel.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Balance";
            this.gridColumn1.FieldName = "Bal";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Serial Number";
            this.gridColumn2.FieldName = "strSN";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "CAN";
            this.gridColumn3.FieldName = "strCAN";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Record No";
            this.gridColumn4.FieldName = "RecNo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Transaction Type";
            this.gridColumn5.FieldName = "strTransType";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Date";
            this.gridColumn6.FieldName = "dtDate";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Purchase Amt.";
            this.gridColumn7.FieldName = "PurAmt";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Merchant";
            this.gridColumn8.FieldName = "strMerchant";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 8;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Time";
            this.gridColumn9.FieldName = "dtTime";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            // 
            // RPCashCardReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 597);
            this.Controls.Add(this.gridExcel);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.cbCAN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ToYear);
            this.Controls.Add(this.ToMonth);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Year);
            this.Controls.Add(this.dMonth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSN);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.gridCashCardUsage);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RPCashCardReport";
            this.Text = "Cash Card Usage Report";
            ((System.ComponentModel.ISupportInitialize)(this.gridCashCardUsage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Year.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCAN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewExcel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridCashCardUsage;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcBal;
        private DevExpress.XtraGrid.Columns.GridColumn gcSN;
        private DevExpress.XtraGrid.Columns.GridColumn gcRecNo;
        private DevExpress.XtraGrid.Columns.GridColumn gcTransType;
        private DevExpress.XtraGrid.Columns.GridColumn gcTimeStamp;
        private DevExpress.XtraGrid.Columns.GridColumn gcPurAmt;
        private DevExpress.XtraGrid.Columns.GridColumn gcMerchant;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.ImageComboBoxEdit ToYear;
        private DevExpress.XtraEditors.ImageComboBoxEdit ToMonth;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.ImageComboBoxEdit Year;
        private DevExpress.XtraEditors.ImageComboBoxEdit dMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbSN;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbCAN;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.Columns.GridColumn gcCAN;
        internal DevExpress.XtraEditors.SimpleButton btnExport;
        internal DevExpress.XtraEditors.SimpleButton btnGenerate;
        private DevExpress.XtraGrid.GridControl gridExcel;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewExcel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gcTime;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;

    }
}