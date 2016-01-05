using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ACMS
{
	/// <summary>
	/// Summary description for FormLockerAction.
	/// </summary>
	public class FormPaymentPlanToOverdueList : System.Windows.Forms.Form
    {
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.Container components = null;
        internal DevExpress.XtraGrid.GridControl GridControlIHPOverdueList;
        internal DevExpress.XtraGrid.Views.Grid.GridView gridViewIHPOverdueList;
        private Label lblOSMsg;
        private Label lblOSAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOK;

        public FormPaymentPlanToOverdueList(string strMembershipID, string strMemberName, string OSAmountText, DataTable dtIPPToOverDue)
		{
			InitializeComponent();

            lblOSMsg.Text = strMemberName + " has Outstanding amount of : ";
            lblOSAmount.Text = OSAmountText;

            GridControlIHPOverdueList.DataSource = dtIPPToOverDue;
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.GridControlIHPOverdueList = new DevExpress.XtraGrid.GridControl();
            this.gridViewIHPOverdueList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblOSMsg = new System.Windows.Forms.Label();
            this.lblOSAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlIHPOverdueList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewIHPOverdueList)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButtonOK.Location = new System.Drawing.Point(565, 239);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonOK.TabIndex = 46;
            this.simpleButtonOK.Text = "OK";
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
            // 
            // GridControlIHPOverdueList
            // 
            gridLevelNode1.RelationName = "Level1";
            this.GridControlIHPOverdueList.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.GridControlIHPOverdueList.Location = new System.Drawing.Point(0, 36);
            this.GridControlIHPOverdueList.LookAndFeel.UseDefaultLookAndFeel = false;
            this.GridControlIHPOverdueList.MainView = this.gridViewIHPOverdueList;
            this.GridControlIHPOverdueList.Name = "GridControlIHPOverdueList";
            this.GridControlIHPOverdueList.Size = new System.Drawing.Size(646, 193);
            this.GridControlIHPOverdueList.TabIndex = 47;
            this.GridControlIHPOverdueList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewIHPOverdueList});
            // 
            // gridViewIHPOverdueList
            // 
            this.gridViewIHPOverdueList.Appearance.FocusedRow.BackColor = System.Drawing.Color.Transparent;
            this.gridViewIHPOverdueList.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewIHPOverdueList.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.Transparent;
            this.gridViewIHPOverdueList.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridViewIHPOverdueList.Appearance.SelectedRow.BackColor = System.Drawing.Color.Transparent;
            this.gridViewIHPOverdueList.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewIHPOverdueList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gridViewIHPOverdueList.GridControl = this.GridControlIHPOverdueList;
            this.gridViewIHPOverdueList.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewIHPOverdueList.Name = "gridViewIHPOverdueList";
            this.gridViewIHPOverdueList.OptionsView.ColumnAutoWidth = false;
            this.gridViewIHPOverdueList.OptionsView.ShowGroupPanel = false;
            this.gridViewIHPOverdueList.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewIHPOverdueList_RowStyle);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Master Receipt";
            this.gridColumn1.FieldName = "strReceiptNo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsFilter.AllowFilter = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 92;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Last Payment Receipt";
            this.gridColumn2.FieldName = "LastPaymentReceiptNo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsFilter.AllowFilter = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 127;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Next Instalment No";
            this.gridColumn3.FieldName = "nInstalmentNo";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsFilter.AllowFilter = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 113;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn4.Caption = "Payable Amount";
            this.gridColumn4.FieldName = "mAdjustedPaymentPlanAmt";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsFilter.AllowFilter = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 98;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Due Date";
            this.gridColumn5.FieldName = "dtDueDate";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsFilter.AllowFilter = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 120;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "Days Left";
            this.gridColumn6.FieldName = "DaysToOverdue";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsFilter.AllowFilter = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // lblOSMsg
            // 
            this.lblOSMsg.AutoSize = true;
            this.lblOSMsg.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblOSMsg.Location = new System.Drawing.Point(9, 8);
            this.lblOSMsg.Name = "lblOSMsg";
            this.lblOSMsg.Size = new System.Drawing.Size(80, 14);
            this.lblOSMsg.TabIndex = 48;
            this.lblOSMsg.Text = "Anonymous";
            // 
            // lblOSAmount
            // 
            this.lblOSAmount.AutoSize = true;
            this.lblOSAmount.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblOSAmount.ForeColor = System.Drawing.Color.Red;
            this.lblOSAmount.Location = new System.Drawing.Point(556, 8);
            this.lblOSAmount.Name = "lblOSAmount";
            this.lblOSAmount.Size = new System.Drawing.Size(80, 14);
            this.lblOSAmount.TabIndex = 49;
            this.lblOSAmount.Text = "Anonymous";
            // 
            // FormPaymentPlanToOverdueList
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(648, 271);
            this.Controls.Add(this.lblOSAmount);
            this.Controls.Add(this.lblOSMsg);
            this.Controls.Add(this.GridControlIHPOverdueList);
            this.Controls.Add(this.simpleButtonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPaymentPlanToOverdueList";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Member\'s Outstanding & IHP to overdue list";
            ((System.ComponentModel.ISupportInitialize)(this.GridControlIHPOverdueList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewIHPOverdueList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            return;
        }

        private void gridViewIHPOverdueList_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView View = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            View.ClearColumnErrors();
            if (View.GetDataRow(e.RowHandle) == null)
                return;
            else
            {
                if (ACMS.Convert.ToInt32(View.GetRowCellValue(e.RowHandle, "DaysToOverdue").ToString()) < 0)
                {
                    e.Appearance.ForeColor = Color.Red;                    
                }                
            }
        }
		
	}
}
