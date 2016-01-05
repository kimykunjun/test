using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using ACMSDAL;

namespace ACMS
{
	/// <summary>
	/// Summary description for FormNewCVAction.
	/// </summary>
	public class FormNewCVAction : System.Windows.Forms.Form
	{
		internal DevExpress.XtraEditors.SimpleButton sBtnCancel;
		internal DevExpress.XtraEditors.SimpleButton sBtnSave;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private DevExpress.XtraEditors.DateEdit dtEdtCaseDate;
		private DevExpress.XtraEditors.TextEdit txtEdtCaseSubj;
		private ACMSLogic.CustomerVoice myCV;
		private DataTable myDataTable;
		private int myCaseID;
		private DevExpress.XtraEditors.MemoEdit mmEdtActionDtl;
		private DevExpress.XtraEditors.DateEdit dtEdtActionDate;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtActionMode;
		private DevExpress.XtraEditors.TextEdit txtEdtCaseID;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormNewCVAction(ACMSLogic.CustomerVoice cv, int nCaseID, string caseSubj, DateTime caseDate)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myCV = cv;
			myCaseID = nCaseID;
			txtEdtCaseSubj.Text = caseSubj;
			dtEdtCaseDate.DateTime = caseDate;
			this.Text = string.Format("Action of Case - {0}.", caseSubj);
			Init();
		}

		private void Init()
		{
			BindData();

			TblCaseMode caseMode = new TblCaseMode();
			DataTable caseModeTable = caseMode.SelectAll();
			new XtraUtils.LookupEditBuilder.CaseModeLookupEditBuilder(caseModeTable, lkpEdtActionMode.Properties);
			
		}

		private void BindData()
		{
			myDataTable = myCV.NewAction(myCaseID);
			
			txtEdtCaseID.DataBindings.Clear();
			dtEdtActionDate.DataBindings.Clear();
			lkpEdtActionMode.DataBindings.Clear();
			mmEdtActionDtl.DataBindings.Clear();
			
			lkpEdtActionMode.DataBindings.Add("EditValue", myDataTable, "nModeID");
			txtEdtCaseID.DataBindings.Add("EditValue", myDataTable, "nCaseID");
			dtEdtActionDate.DataBindings.Add("EditValue", myDataTable, "dtDate");
			mmEdtActionDtl.DataBindings.Add("EditValue", myDataTable, "strActionDetails");
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
			this.sBtnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.sBtnSave = new DevExpress.XtraEditors.SimpleButton();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.mmEdtActionDtl = new DevExpress.XtraEditors.MemoEdit();
			this.dtEdtActionDate = new DevExpress.XtraEditors.DateEdit();
			this.dtEdtCaseDate = new DevExpress.XtraEditors.DateEdit();
			this.lkpEdtActionMode = new DevExpress.XtraEditors.LookUpEdit();
			this.txtEdtCaseSubj = new DevExpress.XtraEditors.TextEdit();
			this.txtEdtCaseID = new DevExpress.XtraEditors.TextEdit();
			((System.ComponentModel.ISupportInitialize)(this.mmEdtActionDtl.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEdtActionDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEdtCaseDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtActionMode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdtCaseSubj.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdtCaseID.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// sBtnCancel
			// 
			this.sBtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sBtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sBtnCancel.Location = new System.Drawing.Point(284, 358);
			this.sBtnCancel.Name = "sBtnCancel";
			this.sBtnCancel.Size = new System.Drawing.Size(72, 20);
			this.sBtnCancel.TabIndex = 29;
			this.sBtnCancel.Text = "Cancel";
			// 
			// sBtnSave
			// 
			this.sBtnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sBtnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.sBtnSave.Location = new System.Drawing.Point(204, 358);
			this.sBtnSave.Name = "sBtnSave";
			this.sBtnSave.Size = new System.Drawing.Size(72, 20);
			this.sBtnSave.TabIndex = 28;
			this.sBtnSave.Text = "Save";
			this.sBtnSave.Click += new System.EventHandler(this.sBtnSave_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.TabIndex = 30;
			this.label1.Text = "Case ID";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 38);
			this.label2.Name = "label2";
			this.label2.TabIndex = 31;
			this.label2.Text = "Case Subject";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 68);
			this.label4.Name = "label4";
			this.label4.TabIndex = 33;
			this.label4.Text = "Case Date";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 98);
			this.label5.Name = "label5";
			this.label5.TabIndex = 34;
			this.label5.Text = "Action Mode";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 130);
			this.label6.Name = "label6";
			this.label6.TabIndex = 35;
			this.label6.Text = "Action Date";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 162);
			this.label7.Name = "label7";
			this.label7.TabIndex = 36;
			this.label7.Text = "Action Detail";
			// 
			// mmEdtActionDtl
			// 
			this.mmEdtActionDtl.EditValue = "memoEdit1";
			this.mmEdtActionDtl.Location = new System.Drawing.Point(114, 162);
			this.mmEdtActionDtl.Name = "mmEdtActionDtl";
			// 
			// mmEdtActionDtl.Properties
			// 
			this.mmEdtActionDtl.Properties.MaxLength = 999;
			this.mmEdtActionDtl.Size = new System.Drawing.Size(244, 182);
			this.mmEdtActionDtl.TabIndex = 37;
			// 
			// dtEdtActionDate
			// 
			this.dtEdtActionDate.EditValue = new System.DateTime(2005, 10, 31, 0, 0, 0, 0);
			this.dtEdtActionDate.Location = new System.Drawing.Point(116, 132);
			this.dtEdtActionDate.Name = "dtEdtActionDate";
			// 
			// dtEdtActionDate.Properties
			// 
			this.dtEdtActionDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dtEdtActionDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.dtEdtActionDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dtEdtActionDate.Size = new System.Drawing.Size(144, 20);
			this.dtEdtActionDate.TabIndex = 38;
			// 
			// dtEdtCaseDate
			// 
			this.dtEdtCaseDate.EditValue = new System.DateTime(2005, 10, 31, 0, 0, 0, 0);
			this.dtEdtCaseDate.Location = new System.Drawing.Point(116, 68);
			this.dtEdtCaseDate.Name = "dtEdtCaseDate";
			// 
			// dtEdtCaseDate.Properties
			// 
			this.dtEdtCaseDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dtEdtCaseDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.dtEdtCaseDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dtEdtCaseDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
			this.dtEdtCaseDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.dtEdtCaseDate.Properties.Mask.EditMask = "";
			this.dtEdtCaseDate.Size = new System.Drawing.Size(144, 20);
			this.dtEdtCaseDate.TabIndex = 39;
			// 
			// lkpEdtActionMode
			// 
			this.lkpEdtActionMode.EditValue = "";
			this.lkpEdtActionMode.Location = new System.Drawing.Point(116, 100);
			this.lkpEdtActionMode.Name = "lkpEdtActionMode";
			// 
			// lkpEdtActionMode.Properties
			// 
			this.lkpEdtActionMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtActionMode.Size = new System.Drawing.Size(144, 20);
			this.lkpEdtActionMode.TabIndex = 40;
			// 
			// txtEdtCaseSubj
			// 
			this.txtEdtCaseSubj.EditValue = "textEdit2";
			this.txtEdtCaseSubj.Location = new System.Drawing.Point(116, 38);
			this.txtEdtCaseSubj.Name = "txtEdtCaseSubj";
			// 
			// txtEdtCaseSubj.Properties
			// 
			this.txtEdtCaseSubj.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.txtEdtCaseSubj.Size = new System.Drawing.Size(144, 18);
			this.txtEdtCaseSubj.TabIndex = 42;
			// 
			// txtEdtCaseID
			// 
			this.txtEdtCaseID.EditValue = "textEdit3";
			this.txtEdtCaseID.Location = new System.Drawing.Point(116, 8);
			this.txtEdtCaseID.Name = "txtEdtCaseID";
			// 
			// txtEdtCaseID.Properties
			// 
			this.txtEdtCaseID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.txtEdtCaseID.Size = new System.Drawing.Size(144, 18);
			this.txtEdtCaseID.TabIndex = 43;
			// 
			// FormNewCVAction
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(368, 388);
			this.Controls.Add(this.txtEdtCaseID);
			this.Controls.Add(this.txtEdtCaseSubj);
			this.Controls.Add(this.lkpEdtActionMode);
			this.Controls.Add(this.dtEdtCaseDate);
			this.Controls.Add(this.dtEdtActionDate);
			this.Controls.Add(this.mmEdtActionDtl);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.sBtnCancel);
			this.Controls.Add(this.sBtnSave);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormNewCVAction";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Action of Case - {0}";
			((System.ComponentModel.ISupportInitialize)(this.mmEdtActionDtl.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEdtActionDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEdtCaseDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtActionMode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdtCaseSubj.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdtCaseID.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void sBtnSave_Click(object sender, System.EventArgs e)
		{
			this.BindingContext[myDataTable].EndCurrentEdit();

			try
			{
				myCV.SaveAction(myDataTable);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
