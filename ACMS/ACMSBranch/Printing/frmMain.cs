using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using DevExpress.XtraPrinting;
using System.Configuration;

namespace ACMS.ACMSBranch
{
	public class frmMain : System.Windows.Forms.Form
	{
		//int[] wCustomers = new int[] {90,100,100,100,100,100};
		//string[] sCustomers = new string[] {"Date","RequestNo","FromBranch","ToBranch","RequestedBy","Status"};
		//string[] sOrders = new string[] {"ItemCode", "Description", "Quantity"};

		private MyPrintControl pc = new MyPrintControl();
		
		private PrintingSystem ps = new PrintingSystem();
		//private string DBFileName;
		//private string connectionString;
		private DataView dv;
		private string queryChild="";
		private string tblChild="";
		private int[] w;
		private string[] schild;


		private System.Windows.Forms.ImageList imageList2;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.TabControl PSTab;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private DevExpress.XtraPrinting.Preview.PrintBarManager printPreviewStatus1;
        private DevExpress.XtraPrinting.Preview.PrintBarManager printPreviewStatusPanel1;
		private DevExpress.XtraPrinting.Preview.PrintPreviewFormExBase printPreviewStatusPanel2;
	//	private DevExpress.XtraPrinting.Preview.PrintPreviewStatusPanel printPreviewStatusPanel3;
        private DevExpress.XtraPrinting.Preview.PrintBarManager printPreviewBar1;
       // private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
        private DevExpress.XtraPrinting.Preview.PrintBarManager printPreviewBarButton2;
        //private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton3;
        //private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton4;
        //private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton5;
        //private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton6;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
        //private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton7;
        //private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton8;
        //private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton9;
        //private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton10;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
        //private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton11;
        //private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton12;
        //private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton13;
        //private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton14;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
        //private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton15;
        //private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton16;
		private System.Windows.Forms.ToolBarButton toolBarButton5;
        //private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton17;
        //private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton18;
		private System.Windows.Forms.ToolBarButton toolBarButton6;
        //private DevExpress.XtraPrinting.Preview.PrintPreviewBarButton printPreviewBarButton19;
		private System.ComponentModel.IContainer components;

		public frmMain(string queryParent,string tblParent,string queryChild,string tblChild,int[] w,string[] s,string[] schild)
		{
			this.queryChild=queryChild;
			this.tblChild=tblChild;
			this.schild=schild;
			this.w=w;
			//DBFileName = DevExpress.Utils.FilesHelper.FindingFileName(Application.StartupPath,"nwind.mdb");
			InitializeComponent();

			//if(DBFileName != "") {
			//	connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName;
				
				dv = CreateDataView(queryParent,tblParent);
				CreateReport(ps, dv, w, s, imageList1, 0, "Stock Request", imageList2.Images[0]);
				pc.PrintingSystem = ps;
			//}
			
			pc.ChangeClickBrick += new EventHandler(ChangeClickBrick);
			pc.Dock = DockStyle.Fill;
			printPreviewBar1.PrintControl = pc;
			printPreviewStatus1.PrintControl = pc;
			tabPage1.Controls.Add((System.Windows.Forms.Control)pc);
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.PSTab = new System.Windows.Forms.TabControl();
			this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            //this.printPreviewStatus1 = new DevExpress.XtraPrinting.Preview.PrintPreviewStatus();
            //this.printPreviewStatusPanel1 = new DevExpress.XtraPrinting.Preview.PrintPreviewStatusPanel();
            //this.printPreviewStatusPanel2 = new DevExpress.XtraPrinting.Preview.PrintPreviewStatusPanel();
            //this.printPreviewStatusPanel3 = new DevExpress.XtraPrinting.Preview.PrintPreviewStatusPanel();

			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            //this.printPreviewBarButton2 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
            //this.printPreviewBarButton3 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
            //this.printPreviewBarButton4 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
            //this.printPreviewBarButton5 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
            //this.printPreviewBarButton6 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            //this.printPreviewBarButton7 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
            //this.printPreviewBarButton8 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
            //this.printPreviewBarButton9 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
            //this.printPreviewBarButton10 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            //this.printPreviewBarButton11 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
            //this.printPreviewBarButton12 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
            //this.printPreviewBarButton13 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
            //this.printPreviewBarButton14 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
            //this.printPreviewBarButton15 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
            //this.printPreviewBarButton16 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
            //this.printPreviewBarButton17 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
            //this.printPreviewBarButton18 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.toolBarButton6 = new System.Windows.Forms.ToolBarButton();
            //this.printPreviewBarButton19 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarButton();
			this.PSTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.printPreviewStatusPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.printPreviewStatusPanel2)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.printPreviewStatusPanel3)).BeginInit();
			this.SuspendLayout();
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "&About";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// tabPage1
			// 
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(628, 337);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Main Report";
			this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
			// 
			// PSTab
			// 
			this.PSTab.Controls.Add(this.tabPage1);
			this.PSTab.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PSTab.Location = new System.Drawing.Point(0, 28);
			this.PSTab.Name = "PSTab";
			this.PSTab.SelectedIndex = 0;
			this.PSTab.Size = new System.Drawing.Size(636, 363);
			this.PSTab.TabIndex = 2;
			this.PSTab.SelectedIndexChanged += new System.EventHandler(this.PSTab_SelectedIndexChanged);
			// 
			// imageList2
			// 
			this.imageList2.ImageSize = new System.Drawing.Size(32, 32);
			this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
			this.imageList2.TransparentColor = System.Drawing.Color.Magenta;
			// 
			// printPreviewStatus1
			// 
            //this.printPreviewStatus1.Location = new System.Drawing.Point(0, 391);
            //this.printPreviewStatus1.Name = "printPreviewStatus1";
            //this.printPreviewStatus1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            //                                                                                       this.printPreviewStatusPanel1,
            //                                                                                       this.printPreviewStatusPanel2,
            //                                                                                       this.printPreviewStatusPanel3});
            //this.printPreviewStatus1.ShowPanels = true;
            //this.printPreviewStatus1.Size = new System.Drawing.Size(636, 22);
            //this.printPreviewStatus1.TabIndex = 6;
            //this.printPreviewStatus1.Text = "printPreviewStatus1";
			// 
			// printPreviewStatusPanel1
			// 
            //this.printPreviewStatusPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            //this.printPreviewStatusPanel1.ID = "CurrentPageNo";
            //this.printPreviewStatusPanel1.Text = "Current Page No:";
            //this.printPreviewStatusPanel1.Width = 206;
            //// 
			// printPreviewStatusPanel2
			// 
            //this.printPreviewStatusPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            //this.printPreviewStatusPanel2.ID = "TotalPageNo";
            //this.printPreviewStatusPanel2.Text = "Total Page No:";
            //this.printPreviewStatusPanel2.Width = 206;
			// 
			// printPreviewStatusPanel3
			// 
            //this.printPreviewStatusPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            //this.printPreviewStatusPanel3.ID = "ZoomFactor";
            //this.printPreviewStatusPanel3.Text = "Zoom Factor:";
            //this.printPreviewStatusPanel3.Width = 206;
			// 
			// printPreviewBar1
			// 
            //this.printPreviewBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            //this.printPreviewBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            //                                                                                    this.printPreviewBarButton1,
            //                                                                                    this.toolBarButton1,
            //                                                                                    this.printPreviewBarButton2,
            //                                                                                    this.printPreviewBarButton3,
            //                                                                                    this.printPreviewBarButton4,
            //                                                                                    this.printPreviewBarButton5,
            //                                                                                    this.printPreviewBarButton6,
            //                                                                                    this.toolBarButton2,
            //                                                                                    this.printPreviewBarButton7,
            //                                                                                    this.printPreviewBarButton8,
            //                                                                                    this.printPreviewBarButton9,
            //                                                                                    this.printPreviewBarButton10,
            //                                                                                    this.toolBarButton3,
            //                                                                                    this.printPreviewBarButton11,
            //                                                                                    this.printPreviewBarButton12,
            //                                                                                    this.printPreviewBarButton13,
            //                                                                                    this.printPreviewBarButton14,
            //                                                                                    this.toolBarButton4,
            //                                                                                    this.printPreviewBarButton15,
            //                                                                                    this.printPreviewBarButton16,
            //                                                                                    this.toolBarButton5,
            //                                                                                    this.printPreviewBarButton17,
            //                                                                                    this.printPreviewBarButton18,
            //                                                                                    this.toolBarButton6,
            //                                                                                    this.printPreviewBarButton19});
            //this.printPreviewBar1.ButtonSize = new System.Drawing.Size(16, 16);
            //this.printPreviewBar1.DropDownArrows = true;
            //this.printPreviewBar1.Location = new System.Drawing.Point(0, 0);
            //this.printPreviewBar1.Name = "printPreviewBar1";
            //this.printPreviewBar1.ShowToolTips = true;
            //this.printPreviewBar1.Size = new System.Drawing.Size(636, 28);
            //this.printPreviewBar1.TabIndex = 7;
            //// 
            //// printPreviewBarButton1
            //// 
            //this.printPreviewBarButton1.Command = DevExpress.XtraPrinting.PrintingSystemCommand.HandTool;
            //this.printPreviewBarButton1.Enabled = false;
            //this.printPreviewBarButton1.ImageIndex = 16;
            //this.printPreviewBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            //this.printPreviewBarButton1.ToolTipText = "Hand Tool";
            //// 
            //// toolBarButton1
            //// 
            //this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            //// 
            //// printPreviewBarButton2
            //// 
            //this.printPreviewBarButton2.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Customize;
            //this.printPreviewBarButton2.ImageIndex = 14;
            //this.printPreviewBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            //this.printPreviewBarButton2.ToolTipText = "Customize";
            //// 
            //// printPreviewBarButton3
            //// 
            //this.printPreviewBarButton3.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Print;
            //this.printPreviewBarButton3.Enabled = false;
            //this.printPreviewBarButton3.ImageIndex = 0;
            //this.printPreviewBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            //this.printPreviewBarButton3.ToolTipText = "Print";
            //// 
            //// printPreviewBarButton4
            //// 
            //this.printPreviewBarButton4.Command = DevExpress.XtraPrinting.PrintingSystemCommand.PrintDirect;
            //this.printPreviewBarButton4.Enabled = false;
            //this.printPreviewBarButton4.ImageIndex = 1;
            //this.printPreviewBarButton4.ToolTipText = "Print Direct";
            //// 
            //// printPreviewBarButton5
            //// 
            //this.printPreviewBarButton5.Command = DevExpress.XtraPrinting.PrintingSystemCommand.PageSetup;
            //this.printPreviewBarButton5.Enabled = false;
            //this.printPreviewBarButton5.ImageIndex = 2;
            //this.printPreviewBarButton5.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            //this.printPreviewBarButton5.ToolTipText = "Page Setup";
            //// 
            //// printPreviewBarButton6
            //// 
            //this.printPreviewBarButton6.Command = DevExpress.XtraPrinting.PrintingSystemCommand.EditPageHF;
            //this.printPreviewBarButton6.ImageIndex = 15;
            //this.printPreviewBarButton6.ToolTipText = "Header And Footer";
            //// 
			// toolBarButton2
			// 
			this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// printPreviewBarButton7
			// 
            //this.printPreviewBarButton7.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Magnifier;
            //this.printPreviewBarButton7.Enabled = false;
            //this.printPreviewBarButton7.ImageIndex = 3;
            //this.printPreviewBarButton7.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            //this.printPreviewBarButton7.ToolTipText = "Magnifier";
            //// 
            //// printPreviewBarButton8
            //// 
            //this.printPreviewBarButton8.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ZoomIn;
            //this.printPreviewBarButton8.Enabled = false;
            //this.printPreviewBarButton8.ImageIndex = 4;
            //this.printPreviewBarButton8.ToolTipText = "Zoom In";
            //// 
            //// printPreviewBarButton9
            //// 
            //this.printPreviewBarButton9.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ZoomOut;
            //this.printPreviewBarButton9.Enabled = false;
            //this.printPreviewBarButton9.ImageIndex = 5;
            //this.printPreviewBarButton9.ToolTipText = "Zoom Out";
            //// 
            //// printPreviewBarButton10
            //// 
            //this.printPreviewBarButton10.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Zoom;
            //this.printPreviewBarButton10.Enabled = false;
            //this.printPreviewBarButton10.ImageIndex = 6;
            //this.printPreviewBarButton10.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            //this.printPreviewBarButton10.ToolTipText = "Zoom";
            //// 
            //// toolBarButton3
			// 
			this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// printPreviewBarButton11
			// 
            //this.printPreviewBarButton11.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ShowFirstPage;
            //this.printPreviewBarButton11.Enabled = false;
            //this.printPreviewBarButton11.ImageIndex = 7;
            //this.printPreviewBarButton11.ToolTipText = "First Page";
            //// 
            //// printPreviewBarButton12
            //// 
            //this.printPreviewBarButton12.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ShowPrevPage;
            //this.printPreviewBarButton12.Enabled = false;
            //this.printPreviewBarButton12.ImageIndex = 8;
            //this.printPreviewBarButton12.ToolTipText = "Previous Page";
			// 
			// printPreviewBarButton13
			// 
            //this.printPreviewBarButton13.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ShowNextPage;
            //this.printPreviewBarButton13.Enabled = false;
            //this.printPreviewBarButton13.ImageIndex = 9;
            //this.printPreviewBarButton13.ToolTipText = "Next Page";
            //// 
            //// printPreviewBarButton14
            //// 
            //this.printPreviewBarButton14.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ShowLastPage;
            //this.printPreviewBarButton14.Enabled = false;
            //this.printPreviewBarButton14.ImageIndex = 10;
            //this.printPreviewBarButton14.ToolTipText = "Last Page";
			// 
			// toolBarButton4
			// 
			this.toolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// printPreviewBarButton15
			// 
            //this.printPreviewBarButton15.Command = DevExpress.XtraPrinting.PrintingSystemCommand.MultiplePages;
            //this.printPreviewBarButton15.Enabled = false;
            //this.printPreviewBarButton15.ImageIndex = 11;
            //this.printPreviewBarButton15.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            //this.printPreviewBarButton15.ToolTipText = "Multiple Pages";
			// 
			// printPreviewBarButton16
			// 
            //this.printPreviewBarButton16.Command = DevExpress.XtraPrinting.PrintingSystemCommand.FillBackground;
            //this.printPreviewBarButton16.Enabled = false;
            //this.printPreviewBarButton16.ImageIndex = 12;
            //this.printPreviewBarButton16.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            //this.printPreviewBarButton16.ToolTipText = "BackGround";
            //// 
            //// toolBarButton5
            //// 
            //this.toolBarButton5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            //// 
            //// printPreviewBarButton17
            //// 
            //this.printPreviewBarButton17.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportFile;
            //this.printPreviewBarButton17.Enabled = false;
            //this.printPreviewBarButton17.ImageIndex = 18;
            //this.printPreviewBarButton17.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            //this.printPreviewBarButton17.ToolTipText = "Export Document...";
			// 
			// printPreviewBarButton18
			// 
            //this.printPreviewBarButton18.Command = DevExpress.XtraPrinting.PrintingSystemCommand.SendFile;
            //this.printPreviewBarButton18.Enabled = false;
            //this.printPreviewBarButton18.ImageIndex = 17;
            //this.printPreviewBarButton18.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            //this.printPreviewBarButton18.ToolTipText = "Send e-mail...";
            //// 
            //// toolBarButton6
            //// 
            //this.toolBarButton6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            //// 
            //// printPreviewBarButton19
            //// 
            //this.printPreviewBarButton19.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ClosePreview;
            //this.printPreviewBarButton19.ImageIndex = 13;
            //this.printPreviewBarButton19.ToolTipText = "Close Preview";
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(636, 413);
			this.Controls.Add(this.PSTab);
            //this.Controls.Add(this.printPreviewStatus1);
            //this.Controls.Add(this.printPreviewBar1);
			this.Menu = this.mainMenu1;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Print Report";
			this.PSTab.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.printPreviewStatusPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.printPreviewStatusPanel2)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.printPreviewStatusPanel3)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

//		[STAThread]
//		static void Main() 
//		{
//			Application.Run(new frmMain());
//		}

		private DataView CreateDataView(string queryParent,string tblParent) {
			DataSet dataSet1 = new DataSet();	
			//string query = "SELECT * FROM " + tbl + s;
			//System.Data.OleDb.OleDbDataAdapter work1 = new System.Data.OleDb.OleDbDataAdapter(query, connectionString);
			//work1.Fill(dataSet1, tbl);
			SqlConnection sqlcon = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["Main.ConnectionString"].ToString());
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(queryParent,sqlcon);
			sqlAdapter.Fill(dataSet1, tblParent);
			DataViewManager dvManager1 = new DataViewManager(dataSet1);
			return dvManager1.CreateDataView(dataSet1.Tables[tblParent]);
		}

		private int CalcRowHeight(BrickGraphics gr, string s, int w, int h) {
			return Math.Max((int)gr.MeasureString(s, w).Height, h);
		}

		private void CreateReport(PrintingSystem ps, DataView dv, int[] w, string[] s, ImageList iList, int selectColumn, string reportName, Image imgTitle) {
			Brick brick;
			BrickGraphics gr = ps.Graph;
			ps.Begin();

			gr.StringFormat = gr.StringFormat.ChangeLineAlignment(StringAlignment.Center);
			gr.Font = new Font("Arial", 8, FontStyle.Bold);

			int imgW = 0, imgH = 0;
			if(iList != null) {
				imgW = iList.ImageSize.Width;
				imgH = iList.ImageSize.Height;
			}
			int h = gr.Font.Height + 2;

			//header
			int leftCell = 0;
			int headerwidth; 
			gr.Modifier = BrickModifier.DetailHeader;
			gr.StringFormat = gr.StringFormat.ChangeAlignment(StringAlignment.Center);
			gr.BackColor = SystemColors.Highlight;
			for(int j = 0; j < s.Length; j++) {
				headerwidth = w[j];
				if(j == 0) headerwidth += imgW + imgW / 4;
				gr.DrawString(dv.Table.Columns[s[j]].Caption, SystemColors.HighlightText, 
					new RectangleF(leftCell, 0, headerwidth, h), BorderSide.All);
				leftCell += headerwidth;
			}
			
			//strings
			h = Math.Max(h, imgH + imgH / 2);
			gr.Modifier = BrickModifier.Detail;
			gr.StringFormat = gr.StringFormat.ChangeAlignment(StringAlignment.Near);
			gr.Font = new Font("Arial", 8);
					
			int hGeneral = 0;
			int hRow = 0;
			for(int i = 0; i < dv.Count; i++) {
				DataRow row = dv[i].Row;
				leftCell = imgW + imgW / 4;
				
				hRow = 0;
				for(int j = 0; j < s.Length; j++) {
					hRow = Math.Max(hRow, CalcRowHeight(gr, row[s[j]].ToString(), w[j], h));
				}
				if(iList != null) {
					brick = gr.DrawImage(iList.Images[0], new RectangleF(0, hGeneral + (hRow - imgH) / 2, imgW, imgH), BorderSide.None, Color.Transparent);
					brick.ID = row[s[1]].ToString();
					brick.Url = "empty";
					brick.Value = 0;
				}
				for(int j = 0; j < s.Length; j++) {
					if("+Byte+Decimal+Double+Int16+Int32+Int64+SByte+Single+UInt16++UInt32+UInt64+".IndexOf("+" + dv.Table.Columns[s[j]].DataType.Name + "+") > -1) 
						gr.StringFormat = gr.StringFormat.ChangeAlignment(StringAlignment.Far);
					else
						gr.StringFormat = gr.StringFormat.ChangeAlignment(StringAlignment.Near);
					if(j == selectColumn)
						gr.BackColor = (iList != null) ? Color.SkyBlue : Color.Yellow;
					else
						gr.BackColor = SystemColors.Window;
					gr.DrawString(row[s[j]].ToString(), SystemColors.WindowText, new RectangleF(leftCell, hGeneral, w[j], hRow), BorderSide.All);
					leftCell += w[j];
				}
				hGeneral += hRow;
			}
			
			//hyperlink
			if(iList == null) {
				gr.Font = new Font("Arial", 8, FontStyle.Underline);
				gr.StringFormat = gr.StringFormat.ChangeAlignment(StringAlignment.Near);
				gr.BackColor = Color.Transparent;
				string hLink = "Show Main Report...";
				brick = gr.DrawString(hLink, Color.Blue, new RectangleF(0, hGeneral + h, gr.MeasureString(hLink).Width + 5, h), BorderSide.None);
				brick.Value = brick.ID = "Main";
				brick.Url = "empty";
				brick.Printed = false;
			}

			CreatePageHeader(gr, reportName, imgTitle, (iList != null) ? Color.Blue : Color.Red);
			CreatePageFooter(gr);

			ps.End();
		}

		private void CreatePageHeader(BrickGraphics gr, string reportName, Image imgTitle, Color c) {
			gr.BackColor = Color.Transparent;
			gr.Modifier = BrickModifier.MarginalHeader;
			
			gr.Font = new Font("Arial", 16, FontStyle.Bold);
			
			RectangleF r = new RectangleF(0, 0, 0, gr.Font.Height);

			PageTableBrick ptBrick = new PageTableBrick();
			TableRow row = new TableRow();
			PageImageBrick piBrick = new PageImageBrick();
			piBrick.Image = imgTitle;
			piBrick.Rect = new RectangleF(0, 0, imgTitle.Width, imgTitle.Height);
			piBrick.Sides = BorderSide.None;
			piBrick.BackColor = Color.Transparent;
			row.Bricks.Add(piBrick);
			ptBrick.Rows.Add(row);
			row = new TableRow();
			PageInfoBrick pinfBrick = new PageInfoBrick();
			pinfBrick.Format = reportName;
			pinfBrick.ForeColor = c;
			pinfBrick.Rect = r;
			pinfBrick.Sides = BorderSide.None;
            row.Bricks.Add(pinfBrick); 
			ptBrick.Rows.Add(row);
			gr.DrawBrick(ptBrick);
			ptBrick.UpdateSize();
			
			gr.Font = gr.DefaultFont;
			pinfBrick = gr.DrawPageInfo(PageInfo.NumberOfTotal, "Page {0} of {1}", Color.Black, r, BorderSide.None);
			pinfBrick.Alignment = BrickAlignment.Far;
			pinfBrick.LineAlignment = BrickAlignment.Center;
			pinfBrick.AutoWidth = true;
		}

		private void CreatePageFooter(BrickGraphics gr) {
			gr.Font = new Font("Arial", 8, FontStyle.Underline);
			gr.BackColor = Color.Transparent;
			gr.Modifier = BrickModifier.MarginalFooter;
			
			RectangleF r = new RectangleF(0, 0, 0, gr.Font.Height);
			
			PageInfoBrick brick = gr.DrawPageInfo(PageInfo.Number, "XtraPrintingSystem by Developer Express inc.", Color.Blue, r, BorderSide.None);
			brick.Hint = brick.Url = "www.devexpress.com";
			brick.Alignment = BrickAlignment.Far;
			brick.AutoWidth = true;
		}

		private int FindTabPageIndex(string s, TabControl tbc) {
			for(int i = 0; i < tbc.TabPages.Count; i++) 
				if(tbc.TabPages[i].Text == s) return i;
			return -1;
		}

		private void ChangeClickBrick(object sender, EventArgs e) {
			Brick brick = sender as Brick;

			if(brick.Value.Equals("Main")) {
				PSTab.SelectedIndex = 0;
				return;
			}			

			int i = brick.Value.Equals(0) ? 1 : 0; 
			brick.Value = i;
			((ImageBrick)brick).Image = imageList1.Images[i];
			pc.InvalidateBrick(brick);
			string tpName = "StockRequestEntries ID ["+brick.ID+"]";

			if(i == 1) {
				TabPage tp = new TabPage(tpName);
				tp.Tag = brick.ID;
				PSTab.TabPages.Add(tp);
				PrintingSystem ps = new PrintingSystem();
				MyPrintControl pcNew = new MyPrintControl();
				pcNew.ChangeClickBrick += new EventHandler(ChangeClickBrick);
				pcNew.Dock = DockStyle.Fill;
				pcNew.PrintingSystem = ps;
				tp.Controls.Add((System.Windows.Forms.Control)pcNew);
				string queryChild1=queryChild+brick.ID;

				dv = CreateDataView(queryChild1,tblChild);//, " WHERE [CustomerID] ='" + brick.ID + "'");
				CreateReport(ps, dv, w, schild, null, 0, tpName, imageList2.Images[1]);
				
				PSTab.SelectedIndex = FindTabPageIndex(tpName, PSTab);
				this.Focus();
			}
			else {
				PSTab.TabPages.RemoveAt(FindTabPageIndex(tpName, PSTab));
				PSTab.SelectedIndex = 0;
			}
		}

		private void PSTab_SelectedIndexChanged(object sender, System.EventArgs e) {
			TabPage tp = PSTab.TabPages[PSTab.SelectedIndex];
			if(tp.Controls.Count > 0) {
				MyPrintControl pc = tp.Controls[0] as MyPrintControl;
				printPreviewBar1.PrintControl = pc;
				printPreviewStatus1.PrintControl = pc;
				//printPreviewBar1.Buttons[4].Pushed = pc.AutoZoom;
			}
		}

		private void menuItem1_Click(object sender, System.EventArgs e) {
			DevExpress.Utils.About.frmAbout dlg = new DevExpress.Utils.About.frmAbout("HierarchicalReport Demo for the XtraPrintingSystem by Developer Express inc.");
			dlg.ShowDialog();
		}

		private void tabPage1_Click(object sender, System.EventArgs e) {
		
		}
	}
}
