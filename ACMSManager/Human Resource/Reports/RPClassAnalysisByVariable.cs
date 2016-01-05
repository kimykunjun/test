using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using ACMS.Utils;

namespace ACMS.ACMSManager.Reports
{
	/// <summary>
	/// Summary description for RPClassAnalysisByVariable.
	/// </summary>
	public class RPClassAnalysisByVariable : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private DevExpress.XtraEditors.DateEdit dateEdit1;
		private DevExpress.XtraEditors.DateEdit dateEdit2;
		private System.Windows.Forms.Label label7;
		private DevExpress.XtraEditors.LookUpEdit lkedtBranch;
		private DevExpress.XtraEditors.LookUpEdit lkedtClassType;
		private DevExpress.XtraEditors.LookUpEdit lkedtInstructor;
		private DevExpress.XtraEditors.SimpleButton btnGenerate;
		private DevExpress.XtraEditors.ComboBoxEdit cmbDayOfWeek;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraEditors.TimeEdit timeEdit1;
		private System.Windows.Forms.Label label5;
		private DevExpress.XtraEditors.HyperLinkEdit PRINT1;
		private System.ComponentModel.IContainer components;
		private bool isFinishBindInit = false;
		private DataTable _dtClassSchedule;
		private string strSQL;
		private DataSet _ds;
		private DataTable dt;
		private DevExpress.XtraGrid.GridControl gcClass;
		private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit1;
		private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
		private DevExpress.XtraEditors.LookUpEdit lkedtClassCode;
		ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder myLookUpEdit;

		public RPClassAnalysisByVariable()
		{
			//
			// Required for Windows Form Designer support
			//
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
			this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
			this.label7 = new System.Windows.Forms.Label();
			this.lkedtBranch = new DevExpress.XtraEditors.LookUpEdit();
			this.lkedtClassType = new DevExpress.XtraEditors.LookUpEdit();
			this.lkedtInstructor = new DevExpress.XtraEditors.LookUpEdit();
			this.btnGenerate = new DevExpress.XtraEditors.SimpleButton();
			this.cmbDayOfWeek = new DevExpress.XtraEditors.ComboBoxEdit();
			this.gcClass = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.timeEdit1 = new DevExpress.XtraEditors.TimeEdit();
			this.label5 = new System.Windows.Forms.Label();
			this.PRINT1 = new DevExpress.XtraEditors.HyperLinkEdit();
			this.hyperLinkEdit1 = new DevExpress.XtraEditors.HyperLinkEdit();
			this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
			this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
			this.lkedtClassCode = new DevExpress.XtraEditors.LookUpEdit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkedtBranch.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkedtClassType.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkedtInstructor.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbDayOfWeek.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gcClass)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.timeEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkedtClassCode.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(464, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 16);
			this.label1.TabIndex = 54;
			this.label1.Text = "DAY OF WEEK";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(576, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 56;
			this.label2.Text = "CLASS TYPE";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(704, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 16);
			this.label3.TabIndex = 58;
			this.label3.Text = "INSTRUCTOR";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(352, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 60;
			this.label4.Text = "BRANCH";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(8, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 16);
			this.label6.TabIndex = 63;
			this.label6.Text = "DATE FROM";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dateEdit1
			// 
			this.dateEdit1.EditValue = null;
			this.dateEdit1.Location = new System.Drawing.Point(8, 24);
			this.dateEdit1.Name = "dateEdit1";
			// 
			// dateEdit1.Properties
			// 
			this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.dateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dateEdit1.Properties.EditFormat.FormatString = "dd/MM/yyyy";
			this.dateEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dateEdit1.Properties.Mask.EditMask = "dd/MM/yyyy";
			this.dateEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			this.dateEdit1.TabIndex = 64;
			// 
			// dateEdit2
			// 
			this.dateEdit2.EditValue = null;
			this.dateEdit2.Location = new System.Drawing.Point(120, 24);
			this.dateEdit2.Name = "dateEdit2";
			// 
			// dateEdit2.Properties
			// 
			this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit2.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.dateEdit2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dateEdit2.Properties.EditFormat.FormatString = "dd/MM/yyyy";
			this.dateEdit2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dateEdit2.Properties.Mask.EditMask = "dd/MM/yyyy";
			this.dateEdit2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			this.dateEdit2.TabIndex = 66;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.Location = new System.Drawing.Point(120, 8);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 16);
			this.label7.TabIndex = 65;
			this.label7.Text = "DATE TO";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lkedtBranch
			// 
			this.lkedtBranch.EditValue = "";
			this.lkedtBranch.Location = new System.Drawing.Point(352, 24);
			this.lkedtBranch.Name = "lkedtBranch";
			// 
			// lkedtBranch.Properties
			// 
			this.lkedtBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkedtBranch.TabIndex = 67;
			// 
			// lkedtClassType
			// 
			this.lkedtClassType.EditValue = "";
			this.lkedtClassType.Location = new System.Drawing.Point(576, 24);
			this.lkedtClassType.Name = "lkedtClassType";
			// 
			// lkedtClassType.Properties
			// 
			this.lkedtClassType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkedtClassType.Size = new System.Drawing.Size(120, 20);
			this.lkedtClassType.TabIndex = 68;
			// 
			// lkedtInstructor
			// 
			this.lkedtInstructor.EditValue = "";
			this.lkedtInstructor.Location = new System.Drawing.Point(704, 24);
			this.lkedtInstructor.Name = "lkedtInstructor";
			// 
			// lkedtInstructor.Properties
			// 
			this.lkedtInstructor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkedtInstructor.Size = new System.Drawing.Size(160, 20);
			this.lkedtInstructor.TabIndex = 69;
			// 
			// btnGenerate
			// 
			this.btnGenerate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnGenerate.Appearance.Options.UseFont = true;
			this.btnGenerate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnGenerate.Location = new System.Drawing.Point(872, 19);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(72, 24);
			this.btnGenerate.TabIndex = 70;
			this.btnGenerate.Text = "Generate";
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			// 
			// cmbDayOfWeek
			// 
			this.cmbDayOfWeek.EditValue = "";
			this.cmbDayOfWeek.Location = new System.Drawing.Point(464, 24);
			this.cmbDayOfWeek.Name = "cmbDayOfWeek";
			// 
			// cmbDayOfWeek.Properties
			// 
			this.cmbDayOfWeek.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbDayOfWeek.Properties.Items.AddRange(new object[] {
																		 "",
																		 "SUN",
																		 "MON",
																		 "TUE",
																		 "WED",
																		 "THU",
																		 "FRI",
																		 "SAT"});
			this.cmbDayOfWeek.TabIndex = 71;
			// 
			// gcClass
			// 
			this.gcClass.Dock = System.Windows.Forms.DockStyle.Bottom;
			// 
			// gcClass.EmbeddedNavigator
			// 
			this.gcClass.EmbeddedNavigator.Name = "";
			this.gcClass.Location = new System.Drawing.Point(0, 68);
			this.gcClass.MainView = this.gridView1;
			this.gcClass.Name = "gcClass";
			this.gcClass.Size = new System.Drawing.Size(945, 432);
			this.gcClass.TabIndex = 72;
			this.gcClass.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																								   this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn1,
																							 this.gridColumn2,
																							 this.gridColumn3,
																							 this.gridColumn4,
																							 this.gridColumn5,
																							 this.gridColumn6,
																							 this.gridColumn7,
																							 this.gridColumn8});
			this.gridView1.GridControl = this.gcClass;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsBehavior.Editable = false;
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsCustomization.AllowSort = false;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "CLASS DATE";
			this.gridColumn1.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.gridColumn1.FieldName = "dtDate";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			this.gridColumn1.Width = 107;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "DOW";
			this.gridColumn2.FieldName = "DOW";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			this.gridColumn2.Width = 97;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "BR";
			this.gridColumn3.FieldName = "strBranchCode";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 2;
			this.gridColumn3.Width = 92;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "TIME";
			this.gridColumn4.DisplayFormat.FormatString = "hh:mm tt";
			this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.gridColumn4.FieldName = "dtStartTime";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 3;
			this.gridColumn4.Width = 99;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "CLASS";
			this.gridColumn5.FieldName = "strClassCode";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 4;
			this.gridColumn5.Width = 110;
			// 
			// gridColumn6
			// 
			this.gridColumn6.Caption = "ATT NO";
			this.gridColumn6.FieldName = "TotalAttendee";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 5;
			this.gridColumn6.Width = 76;
			// 
			// gridColumn7
			// 
			this.gridColumn7.Caption = "INSTRUCTOR";
			this.gridColumn7.FieldName = "InstructorName";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 6;
			this.gridColumn7.Width = 169;
			// 
			// gridColumn8
			// 
			this.gridColumn8.Caption = "ATTENDANCE MARKED BY";
			this.gridColumn8.FieldName = "VerifyName";
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.Visible = true;
			this.gridColumn8.VisibleIndex = 7;
			this.gridColumn8.Width = 198;
			// 
			// timeEdit1
			// 
			this.timeEdit1.EditValue = "";
			this.timeEdit1.Location = new System.Drawing.Point(235, 24);
			this.timeEdit1.Name = "timeEdit1";
			// 
			// timeEdit1.Properties
			// 
			this.timeEdit1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
			this.timeEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton()});
			this.timeEdit1.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
			this.timeEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			this.timeEdit1.TabIndex = 73;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(235, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 16);
			this.label5.TabIndex = 74;
			this.label5.Text = "CLASS TIME";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PRINT1
			// 
			this.PRINT1.EditValue = "PRINT";
			this.PRINT1.Location = new System.Drawing.Point(904, 48);
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
			// hyperLinkEdit1
			// 
			this.hyperLinkEdit1.EditValue = "RESET";
			this.hyperLinkEdit1.Location = new System.Drawing.Point(304, 6);
			this.hyperLinkEdit1.Name = "hyperLinkEdit1";
			// 
			// hyperLinkEdit1.Properties
			// 
			this.hyperLinkEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.hyperLinkEdit1.Properties.Appearance.Options.UseBackColor = true;
			this.hyperLinkEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.hyperLinkEdit1.Size = new System.Drawing.Size(40, 18);
			this.hyperLinkEdit1.TabIndex = 142;
			this.hyperLinkEdit1.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.hyperLinkEdit1_OpenLink);
			// 
			// printingSystem1
			// 
			this.printingSystem1.Links.AddRange(new object[] {
																 this.printableComponentLink1});
			// 
			// printableComponentLink1
			// 
			this.printableComponentLink1.Component = this.gcClass;
			this.printableComponentLink1.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(new DevExpress.XtraPrinting.PageHeaderArea(new string[] {
																																									 "CLASS ANALYSIS REPORT BY VARIABLE (TABLE FORM)",
																																									 "",
																																									 "[Date Printed] [Time Printed]"}, new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), DevExpress.XtraPrinting.BrickAlignment.Near), new DevExpress.XtraPrinting.PageFooterArea(new string[] {
																																																																																																																																  "",
																																																																																																																																  "",
																																																																																																																																  "[Page # of Pages #]"}, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134))), DevExpress.XtraPrinting.BrickAlignment.Near));
			this.printableComponentLink1.PrintingSystem = this.printingSystem1;
			// 
			// lkedtClassCode
			// 
			this.lkedtClassCode.EditValue = "";
			this.lkedtClassCode.Location = new System.Drawing.Point(576, 48);
			this.lkedtClassCode.Name = "lkedtClassCode";
			// 
			// lkedtClassCode.Properties
			// 
			this.lkedtClassCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkedtClassCode.Size = new System.Drawing.Size(120, 20);
			this.lkedtClassCode.TabIndex = 143;
			// 
			// RPClassAnalysisByVariable
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(945, 486);
			this.Controls.Add(this.lkedtClassCode);
			this.Controls.Add(this.hyperLinkEdit1);
			this.Controls.Add(this.PRINT1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.timeEdit1);
			this.Controls.Add(this.gcClass);
			this.Controls.Add(this.cmbDayOfWeek);
			this.Controls.Add(this.btnGenerate);
			this.Controls.Add(this.lkedtInstructor);
			this.Controls.Add(this.lkedtClassType);
			this.Controls.Add(this.lkedtBranch);
			this.Controls.Add(this.dateEdit2);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.dateEdit1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "RPClassAnalysisByVariable";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Class Analysis By Variable (Table Form)";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.RPClassAnalysisByVariable_Load);
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkedtBranch.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkedtClassType.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkedtInstructor.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbDayOfWeek.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gcClass)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.timeEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkedtClassCode.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void RetrieveRecordFromDB()
		{
			if (!isFinishBindInit)
				return;
			SqlParameter[] commandParameters = new SqlParameter[7];
			commandParameters[0] = new SqlParameter("@STARTDATE1",SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed,dateEdit1.EditValue);
			commandParameters[1] = new SqlParameter("@ENDDATE1",SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed,dateEdit2.EditValue);

			int i=2;

			if (timeEdit1.EditValue.ToString() != "")
			{
				commandParameters[i] = new SqlParameter("@CLASSTIME1",SqlDbType.DateTime, 8, ParameterDirection.Input, true, 23, 3, "", DataRowVersion.Proposed,timeEdit1.EditValue);
				i += 1;
			}

			if (lkedtBranch.EditValue.ToString() != "")
			{
				commandParameters[i] = new SqlParameter("@BRANCHCODE1",lkedtBranch.EditValue);
				i += 1;
			}

			if (lkedtClassType.EditValue.ToString() != "")
			{
				commandParameters[i] = new SqlParameter("@CLASSTYPE1",lkedtClassType.EditValue);
				i += 1;
			}

			if (lkedtClassCode.EditValue.ToString() != "")
			{
				commandParameters[i] = new SqlParameter("@CLASSCODE1",lkedtClassCode.EditValue);
				i += 1;
			}

			if (lkedtInstructor.EditValue.ToString() != "")
			{
				commandParameters[i] = new SqlParameter("@INSTRUCTORID1",lkedtInstructor.EditValue);
				i += 1;
			}

			if (cmbDayOfWeek.Text != "")
			{
				commandParameters[i] = new SqlParameter("@DOW1",cmbDayOfWeek.Text);
				i += 1;
			}

			_dtClassSchedule = SqlHelperUtils.ExecuteDataTableSP("up_get_ClassAnalysis_Variable",commandParameters);

		}

		private void LoadInstructorList()
		{
			_ds = new DataSet(); 
			strSQL = "select null [nEmployeeID],'' [strEmployeeName] union select nEmployeeID, strEmployeeName from tblEmployee where fInstructor=1 order by strEmployeeName";
			_ds.Tables.Add("Table");
			_ds = SqlHelperUtils.ExecuteDatasetText(strSQL,null);
			
				
			//(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["Table"];
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nEmployeeID","Employee ID",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strEmployeeName","Name",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			myLookUpEdit = new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lkedtInstructor.Properties,dt,col,"strEmployeeName","nEmployeeID","Instructor");
		
		}
		
		private void LoadBranchCodeList()
		{
			_ds = new DataSet(); 
			strSQL = "select null [strBranchCode],'' [strBranchName] union select strBranchCode, strBranchName from tblBranch";
			_ds = SqlHelperUtils.ExecuteDatasetText(strSQL,null);
			//SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["Table"];
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchCode","Branch Code",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strBranchName","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			myLookUpEdit = new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lkedtBranch.Properties,dt,col,"strBranchName","strBranchCode","Branch");
		}

		private void LoadClassTypeList()
		{
			_ds = new DataSet(); 
			strSQL = "select null [nClassTypeID],'' [strDescription] union select nClassTypeID, strDescription from tblClassType";
			
			_ds = SqlHelperUtils.ExecuteDatasetText(strSQL,null);
			//SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["Table"];
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nClassTypeID","Class Type",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			myLookUpEdit = new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lkedtClassType.Properties,dt,col,"strDescription","nClassTypeID","ClassType");
		}

		private void LoadClassCodeList()
		{
			_ds = new DataSet(); 
			strSQL = "select null [strClassCode],'' [strDescription] union select strClassCode, strDescription from tblClass order by strDescription";
			
			_ds = SqlHelperUtils.ExecuteDatasetText(strSQL,null);
			//SqlHelper.FillDataset(connection,CommandCode.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			dt = _ds.Tables["Table"];
			DevExpress.XtraEditors.Controls.LookUpColumnInfo[] col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo[2];
			col[0] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strClassCode","Class Code",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			col[1] = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("strDescription","Description",15,DevExpress.Utils.FormatType.None,"",true,DevExpress.Utils.HorzAlignment.Default,DevExpress.Data.ColumnSortOrder.None);
			myLookUpEdit = new ACMS.XtraUtils.LookupEditBuilder.CommonLookupEditBuilder(lkedtClassCode.Properties,dt,col,"strDescription","strClassCode","ClassCode");
		}


		private void RPClassAnalysisByVariable_Load(object sender, System.EventArgs e)
		{
			LoadInstructorList();
			LoadBranchCodeList();
			LoadClassTypeList();
			LoadClassCodeList();
			dateEdit1.EditValue = DateTime.Now.Date;
			dateEdit2.EditValue = DateTime.Now.Date;

			isFinishBindInit = true;
		
		}

		private void btnGenerate_Click(object sender, System.EventArgs e)
		{
			RetrieveRecordFromDB();
			gcClass.DataSource = _dtClassSchedule;

		}

		private void hyperLinkEdit1_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
		{
			timeEdit1.EditValue = "";
		}

		private void PRINT1_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
		{
			printableComponentLink1.CreateDocument();
			printableComponentLink1.PrintingSystem.Print();
		}
	}
}
