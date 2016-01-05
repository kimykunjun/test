using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ACMS.ACMSPOS2
{
	/// <summary>
	/// Summary description for FormNew_EditLocker.
	/// </summary>
	public class FormReturnLocker : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.PanelControl pnlCtrlTop;
		private DevExpress.XtraEditors.PanelControl pnlCtrlCenter;
		private DevExpress.XtraEditors.PanelControl pnlCtrlBottom;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private ACMSLogic.POS myPOS;

		public FormReturnLocker(ACMSLogic.POS pos)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			
			myPOS = pos;
		}

		private void Init()
		{
			ACMSDAL.TblLocker sqlLocker = new ACMSDAL.TblLocker();
			DataTable table = sqlLocker.GetOccupiedLocker(myPOS.StrBranchCode, myPOS.StrMembershipID);

			if (table == null || table.Rows.Count == 0)
			{
				MessageBox.Show(this, "No lockers have been rented");
				gridControl1.DataSource = null;
				return;
			}

			if (table.Rows.Count > 0)
			{
				DataColumn colStatus = new DataColumn("Status", typeof(string));
				table.Columns.Add(colStatus);

				// Only show those no yet pass grace period
				ACMSDAL.TblBranch sqlBranch = new ACMSDAL.TblBranch();
			
				sqlBranch.StrBranchCode = myPOS.StrBranchCode;
			
				sqlBranch.SelectOne();

				int gracePeriod =  ACMS.Convert.ToInt32(sqlBranch.NLockerGracePeriod);

				foreach (DataRow lockerRow in table.Rows)
				{
					
					DateTime dtExpiryDate = ACMS.Convert.ToDateTime(lockerRow["dtExpiry"]);

					TimeSpan span = DateTime.Today.Subtract(dtExpiryDate.Date);
			
					if (span.Days > gracePeriod)
					{
						lockerRow["Status"] = "Exceed Grace Period";
					}
					else
					{
						lockerRow["Status"] = "Allow to return.";
					}
				}

				foreach (DataRow detailRow in myPOS.ReceiptItemsTable.Rows)
				{
					string nLockerNoThatReturnCurrently = detailRow["strCode"].ToString();

					DataRow[] rowsToDelete = table.Select("nLockerNo = " + nLockerNoThatReturnCurrently);

					foreach (DataRow rowToDelete in rowsToDelete)
						rowToDelete.Delete();
				}

				gridControl1.DataSource = table;
			}				
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
			this.pnlCtrlTop = new DevExpress.XtraEditors.PanelControl();
			this.pnlCtrlCenter = new DevExpress.XtraEditors.PanelControl();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.pnlCtrlBottom = new DevExpress.XtraEditors.PanelControl();
			this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlTop)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlCenter)).BeginInit();
			this.pnlCtrlCenter.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlBottom)).BeginInit();
			this.pnlCtrlBottom.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlCtrlTop
			// 
			this.pnlCtrlTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnlCtrlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlCtrlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlCtrlTop.Name = "pnlCtrlTop";
			this.pnlCtrlTop.Size = new System.Drawing.Size(838, 16);
			this.pnlCtrlTop.TabIndex = 0;
			this.pnlCtrlTop.Text = "panelControl1";
			// 
			// pnlCtrlCenter
			// 
			this.pnlCtrlCenter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnlCtrlCenter.Controls.Add(this.gridControl1);
			this.pnlCtrlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlCtrlCenter.Location = new System.Drawing.Point(0, 16);
			this.pnlCtrlCenter.Name = "pnlCtrlCenter";
			this.pnlCtrlCenter.Size = new System.Drawing.Size(838, 236);
			this.pnlCtrlCenter.TabIndex = 1;
			this.pnlCtrlCenter.Text = "panelControl2";
			// 
			// gridControl1
			// 
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridControl1.EmbeddedNavigator
			// 
			this.gridControl1.EmbeddedNavigator.Name = "";
			this.gridControl1.Location = new System.Drawing.Point(0, 0);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												  this.repositoryItemDateEdit1});
			this.gridControl1.Size = new System.Drawing.Size(838, 236);
			this.gridControl1.TabIndex = 0;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Branch Code";
			this.gridColumn1.FieldName = "strBranchCode";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsColumn.AllowEdit = false;
			this.gridColumn1.OptionsFilter.AllowFilter = false;
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			this.gridColumn1.Width = 117;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Locker No";
			this.gridColumn2.FieldName = "nLockerNo";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.OptionsColumn.AllowEdit = false;
			this.gridColumn2.OptionsFilter.AllowFilter = false;
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			this.gridColumn2.Width = 93;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Membership ID";
			this.gridColumn3.FieldName = "strMembershipID";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.OptionsColumn.AllowEdit = false;
			this.gridColumn3.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn3.OptionsFilter.AllowFilter = false;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Receipt No";
			this.gridColumn4.FieldName = "strReceiptNo";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.OptionsColumn.AllowEdit = false;
			this.gridColumn4.OptionsFilter.AllowFilter = false;
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 2;
			this.gridColumn4.Width = 143;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "Status ID";
			this.gridColumn5.FieldName = "nStatusID";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.OptionsColumn.AllowEdit = false;
			this.gridColumn5.OptionsColumn.ShowInCustomizationForm = false;
			this.gridColumn5.OptionsFilter.AllowFilter = false;
			this.gridColumn5.Width = 112;
			// 
			// gridColumn6
			// 
			this.gridColumn6.Caption = "Expiry Date";
			this.gridColumn6.ColumnEdit = this.repositoryItemDateEdit1;
			this.gridColumn6.FieldName = "dtExpiry";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.OptionsColumn.AllowEdit = false;
			this.gridColumn6.OptionsFilter.AllowFilter = false;
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 3;
			this.gridColumn6.Width = 144;
			// 
			// repositoryItemDateEdit1
			// 
			this.repositoryItemDateEdit1.AutoHeight = false;
			this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemDateEdit1.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.repositoryItemDateEdit1.Mask.EditMask = "dd/MM/yyyy";
			this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
			// 
			// gridColumn7
			// 
			this.gridColumn7.Caption = "Remark";
			this.gridColumn7.FieldName = "strRemarks";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.OptionsColumn.AllowEdit = false;
			this.gridColumn7.OptionsFilter.AllowFilter = false;
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 4;
			this.gridColumn7.Width = 143;
			// 
			// gridColumn8
			// 
			this.gridColumn8.Caption = "Status";
			this.gridColumn8.FieldName = "Status";
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.Visible = true;
			this.gridColumn8.VisibleIndex = 5;
			this.gridColumn8.Width = 184;
			// 
			// pnlCtrlBottom
			// 
			this.pnlCtrlBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnlCtrlBottom.Controls.Add(this.simpleButtonCancel);
			this.pnlCtrlBottom.Controls.Add(this.simpleButtonOK);
			this.pnlCtrlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlCtrlBottom.Location = new System.Drawing.Point(0, 252);
			this.pnlCtrlBottom.Name = "pnlCtrlBottom";
			this.pnlCtrlBottom.Size = new System.Drawing.Size(838, 44);
			this.pnlCtrlBottom.TabIndex = 2;
			this.pnlCtrlBottom.Text = "panelControl3";
			// 
			// simpleButtonCancel
			// 
			this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButtonCancel.Location = new System.Drawing.Point(752, 14);
			this.simpleButtonCancel.Name = "simpleButtonCancel";
			this.simpleButtonCancel.TabIndex = 8;
			this.simpleButtonCancel.Text = "Cancel";
			this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
			// 
			// simpleButtonOK
			// 
			this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButtonOK.Location = new System.Drawing.Point(666, 14);
			this.simpleButtonOK.Name = "simpleButtonOK";
			this.simpleButtonOK.TabIndex = 7;
			this.simpleButtonOK.Text = "OK";
			this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
			// 
			// FormReturnLocker
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(838, 296);
			this.Controls.Add(this.pnlCtrlCenter);
			this.Controls.Add(this.pnlCtrlTop);
			this.Controls.Add(this.pnlCtrlBottom);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormReturnLocker";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Return Locker";
			this.Load += new System.EventHandler(this.FormNew_ExtendLocker_Load);
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlTop)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlCenter)).EndInit();
			this.pnlCtrlCenter.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlCtrlBottom)).EndInit();
			this.pnlCtrlBottom.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
			DataRow r = gridView1.GetDataRow(gridView1.FocusedRowHandle);
			
			if (r != null)
			{
				if (r["Status"].ToString() == "Exceed Grace Period")
				{
					MessageBox.Show(this, "The locker have exceeded the grace period! She can only extend the locker.");
					return;
				}

				ACMSDAL.TblReceiptEntries sqlReceiptEntries = new ACMSDAL.TblReceiptEntries();
				DataTable table = sqlReceiptEntries.GetLockerDepositBaseStrReceiptNo_N_NLockerNO(r["strReceiptNo"].ToString(), 
					r["nLockerNo"].ToString());

				decimal lockerDeposit = ACMS.Convert.ToDecimal(table.Rows[0]["MSubTotal"]);

				myPOS.NewReceiptEntry(r["nLockerNo"].ToString(), -1, "Return Locker", 1, 
					-lockerDeposit, r["nLockerNo"].ToString());

				this.Close();
			}

			if (myPOS.ReceiptItemsTable.Rows.Count == 0) myPOS.POSLockerAction = ACMSLogic.POS.LockerAction.None;
		}

		private void FormNew_ExtendLocker_Load(object sender, System.EventArgs e)
		{
			Init();
		}

		private void simpleButtonCancel_Click(object sender, System.EventArgs e)
		{
			if (myPOS.ReceiptItemsTable.Rows.Count == 0) myPOS.POSLockerAction = ACMSLogic.POS.LockerAction.None;
		}
	}
}
