using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ACMS.ACMSPOS2
{
	/// <summary>
	/// Summary description for v.
	/// </summary>
	public class UpdateMemberGiro : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.PanelControl panelControlPackage;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK1;
		internal DevExpress.XtraGrid.Views.Grid.GridView gridViewMemberPackage;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn28;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn30;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn31;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn32;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn33;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn35;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn44;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
		private DevExpress.XtraEditors.PanelControl panelControlTop;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.PanelControl panelControlMemberPackage;
		private DevExpress.XtraEditors.SplitterControl splitterControl1;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraEditors.SimpleButton simpleButton3;
		internal DevExpress.XtraGrid.GridControl GcMemberGiro;

		private DataTable myDataTable;
		private ACMSLogic.MemberPackage myMemberPackage;
		private ACMSLogic.POS myPOS;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public UpdateMemberGiro(ACMSLogic.POS pos)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			myPOS = pos;
			myMemberPackage = new ACMSLogic.MemberPackage();
			Init();
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label2 = new System.Windows.Forms.Label();
            this.panelControlPackage = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOK1 = new DevExpress.XtraEditors.SimpleButton();
            this.GcMemberGiro = new DevExpress.XtraGrid.GridControl();
            this.gridViewMemberPackage = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn44 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panelControlTop = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControlMemberPackage = new DevExpress.XtraEditors.PanelControl();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlPackage)).BeginInit();
            this.panelControlPackage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GcMemberGiro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMemberPackage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlTop)).BeginInit();
            this.panelControlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlMemberPackage)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Location = new System.Drawing.Point(-11, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(864, 42);
            this.panelControl1.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(310, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "CHOOSE A MEMBER PACKAGE TO UPDATE:";
            // 
            // panelControlPackage
            // 
            this.panelControlPackage.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControlPackage.Controls.Add(this.simpleButton1);
            this.panelControlPackage.Controls.Add(this.simpleButton3);
            this.panelControlPackage.Controls.Add(this.simpleButton2);
            this.panelControlPackage.Controls.Add(this.simpleButtonOK1);
            this.panelControlPackage.Controls.Add(this.GcMemberGiro);
            this.panelControlPackage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlPackage.Location = new System.Drawing.Point(0, 44);
            this.panelControlPackage.Name = "panelControlPackage";
            this.panelControlPackage.Size = new System.Drawing.Size(617, 342);
            this.panelControlPackage.TabIndex = 9;
            // 
            // simpleButton1
            // 
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton1.Location = new System.Drawing.Point(280, 304);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 14;
            this.simpleButton1.Text = "Cancel";
            // 
            // simpleButton3
            // 
            this.simpleButton3.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButton3.Location = new System.Drawing.Point(200, 304);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(75, 23);
            this.simpleButton3.TabIndex = 13;
            this.simpleButton3.Text = "OK";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton2.Location = new System.Drawing.Point(778, 502);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 12;
            this.simpleButton2.Text = "Cancel";
            // 
            // simpleButtonOK1
            // 
            this.simpleButtonOK1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButtonOK1.Location = new System.Drawing.Point(692, 504);
            this.simpleButtonOK1.Name = "simpleButtonOK1";
            this.simpleButtonOK1.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonOK1.TabIndex = 11;
            this.simpleButtonOK1.Text = "OK";
            // 
            // GcMemberGiro
            // 
            this.GcMemberGiro.Location = new System.Drawing.Point(0, -4);
            this.GcMemberGiro.LookAndFeel.UseDefaultLookAndFeel = false;
            this.GcMemberGiro.MainView = this.gridViewMemberPackage;
            this.GcMemberGiro.Name = "GcMemberGiro";
            this.GcMemberGiro.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.GcMemberGiro.Size = new System.Drawing.Size(864, 288);
            this.GcMemberGiro.TabIndex = 8;
            this.GcMemberGiro.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMemberPackage});
            // 
            // gridViewMemberPackage
            // 
            this.gridViewMemberPackage.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GridColumn28,
            this.GridColumn30,
            this.GridColumn31,
            this.gridColumn1,
            this.GridColumn44,
            this.GridColumn32,
            this.GridColumn33,
            this.GridColumn35});
            this.gridViewMemberPackage.GridControl = this.GcMemberGiro;
            this.gridViewMemberPackage.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewMemberPackage.Name = "gridViewMemberPackage";
            this.gridViewMemberPackage.OptionsView.ColumnAutoWidth = false;
            this.gridViewMemberPackage.OptionsView.ShowGroupPanel = false;
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
            this.GridColumn28.VisibleIndex = 0;
            this.GridColumn28.Width = 69;
            // 
            // GridColumn30
            // 
            this.GridColumn30.Caption = "Package Code";
            this.GridColumn30.FieldName = "strPackageCode";
            this.GridColumn30.Name = "GridColumn30";
            this.GridColumn30.OptionsColumn.AllowEdit = false;
            this.GridColumn30.OptionsColumn.AllowFocus = false;
            this.GridColumn30.OptionsFilter.AllowFilter = false;
            this.GridColumn30.Visible = true;
            this.GridColumn30.VisibleIndex = 1;
            this.GridColumn30.Width = 90;
            // 
            // GridColumn31
            // 
            this.GridColumn31.Caption = "Package Description";
            this.GridColumn31.FieldName = "strDescription";
            this.GridColumn31.Name = "GridColumn31";
            this.GridColumn31.OptionsColumn.AllowEdit = false;
            this.GridColumn31.OptionsColumn.AllowFocus = false;
            this.GridColumn31.OptionsFilter.AllowFilter = false;
            this.GridColumn31.Visible = true;
            this.GridColumn31.VisibleIndex = 2;
            this.GridColumn31.Width = 108;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "List Price";
            this.gridColumn1.FieldName = "mListPrice";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsFilter.AllowFilter = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            // 
            // GridColumn44
            // 
            this.GridColumn44.Caption = "Expiry Date";
            this.GridColumn44.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.GridColumn44.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.GridColumn44.FieldName = "dtExpiryDate";
            this.GridColumn44.Name = "GridColumn44";
            this.GridColumn44.OptionsColumn.AllowEdit = false;
            this.GridColumn44.OptionsColumn.AllowFocus = false;
            this.GridColumn44.OptionsFilter.AllowFilter = false;
            this.GridColumn44.Visible = true;
            this.GridColumn44.VisibleIndex = 5;
            this.GridColumn44.Width = 90;
            // 
            // GridColumn32
            // 
            this.GridColumn32.Caption = "Purchase Date";
            this.GridColumn32.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.GridColumn32.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.GridColumn32.FieldName = "dtPurchaseDate";
            this.GridColumn32.Name = "GridColumn32";
            this.GridColumn32.OptionsColumn.AllowEdit = false;
            this.GridColumn32.OptionsColumn.AllowFocus = false;
            this.GridColumn32.OptionsFilter.AllowFilter = false;
            this.GridColumn32.Width = 84;
            // 
            // GridColumn33
            // 
            this.GridColumn33.Caption = "Receipt No";
            this.GridColumn33.FieldName = "strReceiptNo";
            this.GridColumn33.Name = "GridColumn33";
            this.GridColumn33.OptionsColumn.AllowEdit = false;
            this.GridColumn33.OptionsColumn.AllowFocus = false;
            this.GridColumn33.OptionsFilter.AllowFilter = false;
            this.GridColumn33.Visible = true;
            this.GridColumn33.VisibleIndex = 3;
            this.GridColumn33.Width = 82;
            // 
            // GridColumn35
            // 
            this.GridColumn35.Caption = "Start Date";
            this.GridColumn35.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.GridColumn35.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.GridColumn35.FieldName = "dtStartDate";
            this.GridColumn35.Name = "GridColumn35";
            this.GridColumn35.OptionsColumn.AllowEdit = false;
            this.GridColumn35.OptionsColumn.AllowFocus = false;
            this.GridColumn35.OptionsFilter.AllowFilter = false;
            this.GridColumn35.Visible = true;
            this.GridColumn35.VisibleIndex = 4;
            this.GridColumn35.Width = 83;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // panelControlTop
            // 
            this.panelControlTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControlTop.Controls.Add(this.label1);
            this.panelControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControlTop.Location = new System.Drawing.Point(0, 6);
            this.panelControlTop.Name = "panelControlTop";
            this.panelControlTop.Size = new System.Drawing.Size(617, 38);
            this.panelControlTop.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Upgrade Package";
            // 
            // panelControlMemberPackage
            // 
            this.panelControlMemberPackage.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControlMemberPackage.Location = new System.Drawing.Point(-5, 0);
            this.panelControlMemberPackage.Name = "panelControlMemberPackage";
            this.panelControlMemberPackage.Size = new System.Drawing.Size(864, 220);
            this.panelControlMemberPackage.TabIndex = 7;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl1.Location = new System.Drawing.Point(0, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(617, 6);
            this.splitterControl1.TabIndex = 8;
            this.splitterControl1.TabStop = false;
            // 
            // UpdateMemberGiro
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(617, 386);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControlPackage);
            this.Controls.Add(this.panelControlTop);
            this.Controls.Add(this.panelControlMemberPackage);
            this.Controls.Add(this.splitterControl1);
            this.Name = "UpdateMemberGiro";
            this.Text = "Update Member Giro Pkg";
            this.Load += new System.EventHandler(this.v_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlPackage)).EndInit();
            this.panelControlPackage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GcMemberGiro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMemberPackage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlTop)).EndInit();
            this.panelControlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlMemberPackage)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void v_Load(object sender, System.EventArgs e)
		{
			
		}
		private void Init()
		{
            //string strReceiptDesc = myPOS.NCategoryID == 2 ? "Extend Member GIRO package" : "Extend SPA GIRO package";
            int iNCategoryID = myPOS.NCategoryID == 34 ?34 : 2;//2704

           // myDataTable = myMemberPackage.GetMemberGiroPackage(myPOS.StrMembershipID, myPOS.NCategoryID);
            myDataTable = myMemberPackage.GetMemberGiroPackage(myPOS.StrMembershipID, iNCategoryID);
			GcMemberGiro.DataSource = myDataTable;
			GcMemberGiro.Show();
			
		}

        //private void panelControlPackage_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        //{
		
        //}

		private void simpleButton3_Click(object sender, System.EventArgs e)
		{
			DataRow r = gridViewMemberPackage.GetDataRow(gridViewMemberPackage.FocusedRowHandle);
			if (r != null)
			{
			    //insert an giro package ID to the myPos
			    myPOS.NExtendGIROpkg = ACMS.Convert.ToInt32(r["nPackageID"]);
                //decimal mUnitPrice = myPOS.NCategoryID == 2 ? 128m : 118m;
                
				if (myPOS.NCategoryID == 35 && r["strPackageCode"].ToString().Contains("GIRO(fit)"))
                {
                    myPOS.NCategoryID = 2;
                }
                else
                {
                    myPOS.NCategoryID = 35;
                }

                decimal mUnitPrice = myPOS.NCategoryID == 34 ? 118m:ACMS.Convert.ToInt32(r["mListPrice"]) ;
                string strReceiptDesc = myPOS.NCategoryID == 34 ? "Extend SPA GIRO package":"Extend Member GIRO package" ;

                //decimal mUnitPrice = myPOS.NCategoryID == 2 ? ACMS.Convert.ToInt32(r["mListPrice"]) : 118m;
                //string strReceiptDesc = myPOS.NCategoryID == 2 ? "Extend Member GIRO package" : "Extend SPA GIRO package";

                myPOS.NewReceiptEntry(r["nPackageID"].ToString(), myPOS.NCategoryID, strReceiptDesc, 1, mUnitPrice, "");

        
			}
			
		}
	}
}
