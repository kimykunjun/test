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

namespace ACMS.ACMSManager.Reports
{
	/// <summary>
	/// Summary description for RPSpaFitness.
	/// </summary>
	public class RPSpaFitness : System.Windows.Forms.Form
	{
		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
		private DevExpress.XtraEditors.ImageComboBoxEdit cmbCategory;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraPivotGrid.PivotGridControl pvSpaFitness;
		private DevExpress.XtraEditors.DateEdit DateFrom;
		private System.Windows.Forms.Label DateTo;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.DateEdit DateRangeTo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		internal DevExpress.XtraEditors.SimpleButton btnReset;
		internal DevExpress.XtraEditors.SimpleButton btnSearch;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.TextEdit txtItemDesc;
		private System.Windows.Forms.Label label6;
		private DevExpress.XtraEditors.TextEdit txtItemCode;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField5;
		private int EmployeeID;

		public RPSpaFitness(int empID)
		{
			//
			// Required for Windows Form Designer support
			//
			EmployeeID = empID;
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
			this.pvSpaFitness = new DevExpress.XtraPivotGrid.PivotGridControl();
			this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField5 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.cmbCategory = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.DateFrom = new DevExpress.XtraEditors.DateEdit();
			this.DateTo = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.DateRangeTo = new DevExpress.XtraEditors.DateEdit();
			this.btnReset = new DevExpress.XtraEditors.SimpleButton();
			this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
			this.label3 = new System.Windows.Forms.Label();
			this.txtItemDesc = new DevExpress.XtraEditors.TextEdit();
			this.label6 = new System.Windows.Forms.Label();
			this.txtItemCode = new DevExpress.XtraEditors.TextEdit();
			((System.ComponentModel.ISupportInitialize)(this.pvSpaFitness)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbCategory.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DateRangeTo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtItemDesc.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtItemCode.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// pvSpaFitness
			// 
			this.pvSpaFitness.Cursor = System.Windows.Forms.Cursors.Default;
			this.pvSpaFitness.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
																								this.pivotGridField1,
																								this.pivotGridField2,
																								this.pivotGridField3,
																								this.pivotGridField4,
																								this.pivotGridField5});
			this.pvSpaFitness.Location = new System.Drawing.Point(8, 48);
			this.pvSpaFitness.Name = "pvSpaFitness";
			this.pvSpaFitness.OptionsCustomization.AllowDrag = false;
			this.pvSpaFitness.OptionsView.ShowDataHeaders = false;
			this.pvSpaFitness.OptionsView.ShowFilterHeaders = false;
			this.pvSpaFitness.Size = new System.Drawing.Size(760, 352);
			this.pvSpaFitness.TabIndex = 0;
			// 
			// pivotGridField1
			// 
			this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField1.AreaIndex = 1;
			this.pivotGridField1.Caption = "Item Code";
			this.pivotGridField1.FieldName = "strCode";
			this.pivotGridField1.Name = "pivotGridField1";
			// 
			// pivotGridField2
			// 
			this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField2.AreaIndex = 2;
			this.pivotGridField2.Caption = "Item Desc";
			this.pivotGridField2.FieldName = "strDescription";
			this.pivotGridField2.Name = "pivotGridField2";
			// 
			// pivotGridField3
			// 
			this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.pivotGridField3.AreaIndex = 0;
			this.pivotGridField3.Caption = "Quantity";
			this.pivotGridField3.FieldName = "nQuantity";
			this.pivotGridField3.Name = "pivotGridField3";
			// 
			// pivotGridField4
			// 
			this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
			this.pivotGridField4.AreaIndex = 0;
			this.pivotGridField4.Caption = "Branch";
			this.pivotGridField4.FieldName = "strBranchCode";
			this.pivotGridField4.Name = "pivotGridField4";
			this.pivotGridField4.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False;
			this.pivotGridField4.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False;
			this.pivotGridField4.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			// 
			// pivotGridField5
			// 
			this.pivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField5.AreaIndex = 0;
			this.pivotGridField5.Caption = "Category";
			this.pivotGridField5.FieldName = "Category";
			this.pivotGridField5.Name = "pivotGridField5";
			// 
			// cmbCategory
			// 
			this.cmbCategory.Location = new System.Drawing.Point(72, 24);
			this.cmbCategory.Name = "cmbCategory";
			// 
			// cmbCategory.Properties
			// 
			this.cmbCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbCategory.Size = new System.Drawing.Size(112, 20);
			this.cmbCategory.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Category";
			// 
			// DateFrom
			// 
			this.DateFrom.EditValue = null;
			this.DateFrom.Location = new System.Drawing.Point(48, 0);
			this.DateFrom.Name = "DateFrom";
			// 
			// DateFrom.Properties
			// 
			this.DateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.DateFrom.Size = new System.Drawing.Size(72, 20);
			this.DateFrom.TabIndex = 13;
			// 
			// DateTo
			// 
			this.DateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.DateTo.Location = new System.Drawing.Point(120, 0);
			this.DateTo.Name = "DateTo";
			this.DateTo.Size = new System.Drawing.Size(24, 16);
			this.DateTo.TabIndex = 12;
			this.DateTo.Text = "To";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(8, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 11;
			this.label2.Text = "From";
			// 
			// DateRangeTo
			// 
			this.DateRangeTo.EditValue = null;
			this.DateRangeTo.Location = new System.Drawing.Point(152, 0);
			this.DateRangeTo.Name = "DateRangeTo";
			// 
			// DateRangeTo.Properties
			// 
			this.DateRangeTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.DateRangeTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.DateRangeTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.DateRangeTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
			this.DateRangeTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.DateRangeTo.Properties.Mask.EditMask = "dd/MM/yyyy";
			this.DateRangeTo.Size = new System.Drawing.Size(64, 20);
			this.DateRangeTo.TabIndex = 10;
			// 
			// btnReset
			// 
			this.btnReset.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnReset.Location = new System.Drawing.Point(520, 24);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(56, 20);
			this.btnReset.TabIndex = 66;
			this.btnReset.Text = "Reset";
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// btnSearch
			// 
			this.btnSearch.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnSearch.Location = new System.Drawing.Point(456, 24);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(56, 20);
			this.btnSearch.TabIndex = 65;
			this.btnSearch.Text = "Search";
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(312, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 60;
			this.label3.Text = "Item Desc";
			// 
			// txtItemDesc
			// 
			this.txtItemDesc.EditValue = "";
			this.txtItemDesc.Location = new System.Drawing.Point(376, 24);
			this.txtItemDesc.Name = "txtItemDesc";
			this.txtItemDesc.Size = new System.Drawing.Size(72, 20);
			this.txtItemDesc.TabIndex = 59;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.Location = new System.Drawing.Point(184, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 16);
			this.label6.TabIndex = 58;
			this.label6.Text = "Item Code";
			// 
			// txtItemCode
			// 
			this.txtItemCode.EditValue = "";
			this.txtItemCode.Location = new System.Drawing.Point(248, 24);
			this.txtItemCode.Name = "txtItemCode";
			this.txtItemCode.Size = new System.Drawing.Size(64, 20);
			this.txtItemCode.TabIndex = 57;
			// 
			// RPSpaFitness
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(864, 501);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtItemDesc);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtItemCode);
			this.Controls.Add(this.DateFrom);
			this.Controls.Add(this.DateTo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.DateRangeTo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbCategory);
			this.Controls.Add(this.pvSpaFitness);
			this.Name = "RPSpaFitness";
			this.Text = "Spa & Fitness";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.RPSpaFitness_Load);
			((System.ComponentModel.ISupportInitialize)(this.pvSpaFitness)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbCategory.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DateRangeTo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtItemDesc.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtItemCode.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void BindReport()
		{
			string strSQL;
			DataSet _ds;

		
			strSQL = "up_get_ReceiptCategoryRpt " + EmployeeID;
			_ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds, new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
			DataTable dt = _ds.Tables["table"];
			DataView dv = new DataView(dt);

			string str = string.Format("dtDate >= '{0}' And dtDate < '{1}'",string.Format("{0:MM/dd/yyyy}",Convert.ToDateTime(DateFrom.EditValue)),string.Format("{0:MM/dd/yyyy}",Convert.ToDateTime(DateRangeTo.EditValue)));

			if (cmbCategory.EditValue != null && cmbCategory.EditValue.ToString() != "")
				str += " And nCategoryID = " + cmbCategory.EditValue;

				
			if (this.txtItemCode.EditValue.ToString() != "")
				str += " And strCode like '%" + txtItemCode.EditValue + "%'";
	
			if (this.txtItemDesc.EditValue.ToString() != "")
				str += " And strDescription like '%" + txtItemDesc.EditValue + "%'";

			dv.RowFilter = str;

			this.pvSpaFitness.DataSource = dv;
		}

		private void RPSpaFitness_Load(object sender, System.EventArgs e)
		{
			BindCategory();
			DateFrom.EditValue = string.Format("{0:dd/MM/yyyy}",Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year));

			DateRangeTo.EditValue = DateTime.Today;
			
			BindReport();
		}

		private void BindCategory()
		{
			string strSQL = "Select * From TblCategory Where strDescription in ('Fitness Package','PT Package','Spa Package','IPL Package')";

			comboBind(cmbCategory, strSQL, "strDescription", "nCategoryID", true);
			cmbCategory.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem("- Please Select -",""));
			cmbCategory.SelectedIndex = 0;
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

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			BindReport();
		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			DateFrom.EditValue = string.Format("{0:dd/MM/yyyy}",Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year));

			DateRangeTo.EditValue = DateTime.Today;

			this.txtItemCode.EditValue = "";
			this.txtItemDesc.EditValue = "";
			this.cmbCategory.SelectedIndex = 0;
			BindReport();
		
		}

	
		

	}
}
