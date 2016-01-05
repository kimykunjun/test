namespace ACMS.ACMSBranch.Member_Package
{
    partial class FormTop5Spa
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
            this.grdTop5SPA = new DevExpress.XtraGrid.GridControl();
            this.GridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn299 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEditUtilizationSelection = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.GridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTop5SPA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditUtilizationSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdTop5SPA
            // 
            this.grdTop5SPA.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdTop5SPA.Location = new System.Drawing.Point(0, 5);
            this.grdTop5SPA.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdTop5SPA.MainView = this.GridView7;
            this.grdTop5SPA.Name = "grdTop5SPA";
            this.grdTop5SPA.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEditUtilizationSelection});
            this.grdTop5SPA.Size = new System.Drawing.Size(303, 260);
            this.grdTop5SPA.TabIndex = 8;
            this.grdTop5SPA.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView7});
            // 
            // GridView7
            // 
            this.GridView7.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn299,
            this.GridColumn28,
            this.GridColumn32,
            this.GridColumn33});
            this.GridView7.CustomizationFormBounds = new System.Drawing.Rectangle(1051, 384, 216, 178);
            this.GridView7.GridControl = this.grdTop5SPA;
            this.GridView7.Name = "GridView7";
            this.GridView7.OptionsView.ColumnAutoWidth = false;
            this.GridView7.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn299
            // 
            this.gridColumn299.Caption = "Utl";
            this.gridColumn299.ColumnEdit = this.repositoryItemCheckEditUtilizationSelection;
            this.gridColumn299.FieldName = "UtlCheck";
            this.gridColumn299.Name = "gridColumn299";
            this.gridColumn299.OptionsColumn.ShowCaption = false;
            this.gridColumn299.Visible = true;
            this.gridColumn299.VisibleIndex = 0;
            this.gridColumn299.Width = 25;
            // 
            // repositoryItemCheckEditUtilizationSelection
            // 
            this.repositoryItemCheckEditUtilizationSelection.AutoHeight = false;
            this.repositoryItemCheckEditUtilizationSelection.Name = "repositoryItemCheckEditUtilizationSelection";
            // 
            // GridColumn28
            // 
            this.GridColumn28.Caption = "Package ID";
            this.GridColumn28.FieldName = "nPackageID";
            this.GridColumn28.Name = "GridColumn28";
            this.GridColumn28.OptionsColumn.AllowEdit = false;
            this.GridColumn28.OptionsColumn.AllowFocus = false;
            this.GridColumn28.OptionsFilter.AllowFilter = false;
            this.GridColumn28.Visible = true;
            this.GridColumn28.VisibleIndex = 1;
            this.GridColumn28.Width = 65;
            // 
            // GridColumn32
            // 
            this.GridColumn32.Caption = "Date";
            this.GridColumn32.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.GridColumn32.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.GridColumn32.FieldName = "dtDate";
            this.GridColumn32.Name = "GridColumn32";
            this.GridColumn32.OptionsColumn.AllowEdit = false;
            this.GridColumn32.OptionsColumn.AllowFocus = false;
            this.GridColumn32.OptionsFilter.AllowFilter = false;
            this.GridColumn32.Visible = true;
            this.GridColumn32.VisibleIndex = 2;
            this.GridColumn32.Width = 84;
            // 
            // GridColumn33
            // 
            this.GridColumn33.Caption = "Package Code";
            this.GridColumn33.FieldName = "strServiceCode";
            this.GridColumn33.Name = "GridColumn33";
            this.GridColumn33.OptionsColumn.AllowEdit = false;
            this.GridColumn33.OptionsColumn.AllowFocus = false;
            this.GridColumn33.OptionsFilter.AllowFilter = false;
            this.GridColumn33.Visible = true;
            this.GridColumn33.VisibleIndex = 3;
            this.GridColumn33.Width = 105;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // FormTop5Spa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 265);
            this.Controls.Add(this.grdTop5SPA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormTop5Spa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTop5Spa";
            this.Load += new System.EventHandler(this.FormTop5Spa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdTop5SPA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditUtilizationSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraGrid.GridControl grdTop5SPA;
        internal DevExpress.XtraGrid.Views.Grid.GridView GridView7;
        internal DevExpress.XtraGrid.Columns.GridColumn gridColumn299;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditUtilizationSelection;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn28;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn32;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn33;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;


    }
}