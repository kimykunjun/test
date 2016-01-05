using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using DevExpress.XtraPivotGrid;
using Do = Acms.Core.Domain;
using ACMSLogic;

namespace ACMS.ACMSManager.Reports
{
	/// <summary>
	/// Summary description for XtraForm1.
	/// </summary>
	public class RPMtMSales : DevExpress.XtraEditors.XtraForm
	{
		private Do.Employee employee;
		private Do.TerminalUser terminalUser; 
		User oUser;

		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraPivotGrid.PivotGridControl MtMSalesGrid;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
		private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
		private System.Windows.Forms.Label label63;
		private DevExpress.XtraEditors.ImageComboBoxEdit cmbCategory;
		private bool isFinishBindInit;
		private DevExpress.XtraEditors.HyperLinkEdit PRINT1;
		private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
		private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
		private System.ComponentModel.IContainer components;

		public RPMtMSales()
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
			this.MtMSalesGrid = new DevExpress.XtraPivotGrid.PivotGridControl();
			this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
			this.label63 = new System.Windows.Forms.Label();
			this.cmbCategory = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.PRINT1 = new DevExpress.XtraEditors.HyperLinkEdit();
			this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
			this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
			((System.ComponentModel.ISupportInitialize)(this.MtMSalesGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbCategory.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
			this.SuspendLayout();
			// 
			// MtMSalesGrid
			// 
			this.MtMSalesGrid.Cursor = System.Windows.Forms.Cursors.Default;
			this.MtMSalesGrid.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
																								this.pivotGridField1,
																								this.pivotGridField2,
																								this.pivotGridField3,
																								this.pivotGridField4});
			this.MtMSalesGrid.Location = new System.Drawing.Point(8, 40);
			this.MtMSalesGrid.Name = "MtMSalesGrid";
			this.MtMSalesGrid.OptionsCustomization.AllowDrag = false;
			this.MtMSalesGrid.OptionsCustomization.AllowExpand = false;
			this.MtMSalesGrid.OptionsCustomization.AllowSort = false;
			this.MtMSalesGrid.OptionsView.ShowDataHeaders = false;
			this.MtMSalesGrid.OptionsView.ShowFilterHeaders = false;
			this.MtMSalesGrid.Size = new System.Drawing.Size(960, 424);
			this.MtMSalesGrid.TabIndex = 0;
			// 
			// pivotGridField1
			// 
			this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
			this.pivotGridField1.AreaIndex = 0;
			this.pivotGridField1.Caption = "Year";
			this.pivotGridField1.FieldName = "Year";
			this.pivotGridField1.Name = "pivotGridField1";
			this.pivotGridField1.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False;
			this.pivotGridField1.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			// 
			// pivotGridField2
			// 
			this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField2.AreaIndex = 1;
			this.pivotGridField2.Caption = "Month";
			this.pivotGridField2.FieldName = "Month";
			this.pivotGridField2.Name = "pivotGridField2";
			// 
			// pivotGridField3
			// 
			this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.pivotGridField3.AreaIndex = 0;
			this.pivotGridField3.EmptyValueText = "0";
			this.pivotGridField3.FieldName = "TotalAmount";
			this.pivotGridField3.Name = "pivotGridField3";
			// 
			// pivotGridField4
			// 
			this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.pivotGridField4.AreaIndex = 0;
			this.pivotGridField4.Caption = "Category";
			this.pivotGridField4.FieldName = "strDescription";
			this.pivotGridField4.Name = "pivotGridField4";
			// 
			// label63
			// 
			this.label63.BackColor = System.Drawing.Color.Transparent;
			this.label63.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label63.Location = new System.Drawing.Point(16, 8);
			this.label63.Name = "label63";
			this.label63.Size = new System.Drawing.Size(100, 16);
			this.label63.TabIndex = 38;
			this.label63.Text = "Category";
			// 
			// cmbCategory
			// 
			this.cmbCategory.EditValue = "cbGIROStatus";
			this.cmbCategory.Location = new System.Drawing.Point(96, 8);
			this.cmbCategory.Name = "cmbCategory";
			// 
			// cmbCategory.Properties
			// 
			this.cmbCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbCategory.Properties.Items.AddRange(new object[] {
																		new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Active", 1, -1),
																		new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Inactive", 0, -1)});
			this.cmbCategory.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.cmbCategory.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.cmbCategory.Size = new System.Drawing.Size(176, 20);
			this.cmbCategory.TabIndex = 39;
			this.cmbCategory.SelectedValueChanged += new System.EventHandler(this.cmbCategory_SelectedValueChanged);
			// 
			// PRINT1
			// 
			this.PRINT1.EditValue = "PRINT";
			this.PRINT1.Location = new System.Drawing.Point(288, 8);
			this.PRINT1.Name = "PRINT1";
			// 
			// PRINT1.Properties
			// 
			this.PRINT1.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.PRINT1.Properties.Appearance.Options.UseBackColor = true;
			this.PRINT1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.PRINT1.Size = new System.Drawing.Size(40, 18);
			this.PRINT1.TabIndex = 140;
			this.PRINT1.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.PRINT1_OpenLink);
			// 
			// printingSystem1
			// 
			this.printingSystem1.Links.AddRange(new object[] {
																 this.printableComponentLink1});
			// 
			// printableComponentLink1
			// 
			this.printableComponentLink1.Component = this.MtMSalesGrid;
			this.printableComponentLink1.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(new DevExpress.XtraPrinting.PageHeaderArea(new string[] {
																																									 "Month To Month Sales Report",
																																									 "",
																																									 "[Date Printed] [Time Printed]"}, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134))), DevExpress.XtraPrinting.BrickAlignment.Near), new DevExpress.XtraPrinting.PageFooterArea(new string[] {
																																																																																																																	"",
																																																																																																																	"",
																																																																																																																	"[Page # of Pages #]"}, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134))), DevExpress.XtraPrinting.BrickAlignment.Near));
			this.printableComponentLink1.PrintingSystem = this.printingSystem1;
			this.printableComponentLink1.CreateDetailHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(this.printableComponentLink1_CreateDetailHeaderArea);
			// 
			// RPMtMSales
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(874, 470);
			this.Controls.Add(this.PRINT1);
			this.Controls.Add(this.cmbCategory);
			this.Controls.Add(this.label63);
			this.Controls.Add(this.MtMSalesGrid);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "RPMtMSales";
			this.Text = "Month to Month Sales";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.XtraForm1_Load);
			((System.ComponentModel.ISupportInitialize)(this.MtMSalesGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbCategory.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PRINT1.Properties)).EndInit();
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


		private void XtraForm1_Load(object sender, System.EventArgs e)
		{
			isFinishBindInit = false;
			BindCategory();
			isFinishBindInit = true;
			BindReport();
		}

		private void BindReport()
		{
			Cursor currentCursor = Cursor.Current;
			Cursor.Current = Cursors.WaitCursor;

			try
			{
				if (!isFinishBindInit)
					return;
				if (cmbCategory.EditValue == null)
				{
					MtMSalesGrid.DataSource = null;
					return;
				}

				DataSet _ds = new DataSet();
				SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "up_tblReceipt_rpt3YearsMonthToMonthSales", _ds,
				                      new string[]{"table"});
				DataTable dt = _ds.Tables["table"];
				DataView dv = new DataView(dt);
				string sql = "";
				string Item = "";

				if (cmbCategory.EditValue.ToString() == "All")
				{
					sql = "nCategoryID In (";
				
					for (int i = 1; i <= cmbCategory.Properties.Items.Count - 1; i++)
					{
						Item += cmbCategory.Properties.Items[i].Value + ",";
					}

					sql += Item.Substring(0,Item.Length - 2) + ")"; 
				}
				else if (cmbCategory.EditValue.ToString() != "")
					sql = "nCategoryID = " + cmbCategory.EditValue;

				dv.RowFilter = sql;

				MtMSalesGrid.DataSource = dv;
			}
			finally
			{
				Cursor.Current = currentCursor;
			}
		}

		private void BindCategory()
		{
			bool ViewAll = false;
			isFinishBindInit = false;
			string strSQL = ""; 
			
			if(employee.HasRight("AM_VIEW_INCOME_ANALYSIS_VIEW_ALL_REPORT"))
			{
				strSQL = "up_get_CategoryFilter";
				ViewAll = true;
			}
			else
			{
				strSQL = "up_get_CategoryByRight " + oUser.NEmployeeID();
				ViewAll = true;
			}
			comboBind(cmbCategory, strSQL, "strDescription", "nCategoryID", true);

			if (ViewAll == true)
				cmbCategory.Properties.Items.Insert(0,new DevExpress.XtraEditors.Controls.ImageComboBoxItem("- View All -","All"));

			cmbCategory.SelectedIndex = 0;
			isFinishBindInit = true;

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

		private void cmbCategory_SelectedValueChanged(object sender, System.EventArgs e)
		{
			BindReport();
		}

		private void PRINT1_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
		{
			printableComponentLink1.CreateDocument();
			printableComponentLink1.PrintingSystem.Print();
		}

		private void printableComponentLink1_CreateDetailHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
		{
		
		}

	}
}

