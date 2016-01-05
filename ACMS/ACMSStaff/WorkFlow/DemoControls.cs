using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.LookAndFeel;
using DevExpress.DXperience.Demos;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList;

namespace DevExpress.XtraTreeList.Demos {
	public class TutorialControl : TutorialControlBase {
		private TreeListAppearanceMenu menu = null;
		private DevExpress.Utils.Frames.NotePanel fDescription = null;
		
		public TutorialControl() {}

		public TreeListAppearanceMenu AppearanceMenu {
			get { return menu; }
			set {
				if(menu == value) return;
				if(menu != null)
					menu.SwitchStyle -= new EventHandler(OnSwitchStyle);
				this.menu = value;
				if(menu != null) {
					OnSwitchStyle(menu, EventArgs.Empty);
					AddMenuManager(menu.MainMenu.Manager);
					menu.SwitchStyle += new EventHandler(OnSwitchStyle);
				}
			}
		}

		public DevExpress.Utils.Frames.NotePanel Description {
			get { return fDescription; }
			set { fDescription = value; 
				OnSetDescription("");	
			}
		}

		protected virtual void OnSetDescription(string fDescription) {
			if(fDescription == string.Empty) return;
			Description.Text = string.Format(fDescription);
		}
		
		public virtual TreeList ExportControl { get { return null; } }
		public virtual TreeList ViewOptionsControl { get { return null; } }
		public virtual bool ShowLookAndFeelMenu { get { return true; }}

		void OnSwitchStyle(object sender, EventArgs e) {
			OnSwitchStyle();
		}
		protected override void DoHide() {
			foreach(Control ctrl in this.Controls)
				if(ctrl is TreeList)
					((TreeList)ctrl).DestroyCustomization();
		}

		protected override void SetControlManager(Control ctrl, BarManager manager) {
			DevExpress.XtraTreeList.TreeList treeList = ctrl as DevExpress.XtraTreeList.TreeList;
			if(treeList != null) treeList.MenuManager = manager;
		}
	}

	public class TreeListAppearanceMenu : LookAndFeelMenu {
		BarSubItem miViewOptions, miExport;
		public TreeListAppearanceMenu(BarManager manager, DefaultLookAndFeel lookAndFeel, string about) : base(manager, lookAndFeel, about) {
			RaiseSwitchStyle();

			miViewOptions = new BarSubItem(this.manager, "&View Options");
			miViewOptions.Popup += new EventHandler(ViewOptions_Popup);
			this.MainMenu.ItemLinks.Insert(2, miViewOptions);

			miExport = new BarSubItem(this.manager, "Print And Export To...");
			miExport.ItemLinks.Add(new ButtonBarItem(this.manager, "Export data to XML file", new ItemClickEventHandler(ExportXML_Click)));

			miExport.ItemLinks.Add(new ButtonBarItem(this.manager, "Export to HTML file", new ItemClickEventHandler(ExportHtml_Click))).BeginGroup = true;
			miExport.ItemLinks.Add(new ButtonBarItem(this.manager, "Export to Portable Document Format file", new ItemClickEventHandler(ExportPdf_Click)));
			miExport.ItemLinks.Add(new ButtonBarItem(this.manager, "Export to Microsoft Excel file", new ItemClickEventHandler(ExportXls_Click)));
			miExport.ItemLinks.Add(new ButtonBarItem(this.manager, "Export to Text file", new ItemClickEventHandler(ExportText_Click)));
			miExport.ItemLinks.Add(new ButtonBarItem(this.manager, "Export to Rich Text Format file", new ItemClickEventHandler(ExportRtf_Click)));

			miExport.ItemLinks.Add(new ButtonBarItem(this.manager, "Print Preview", new ItemClickEventHandler(PrintPreview_OnClick))).BeginGroup = true;
			this.MainMenu.ItemLinks.Insert(3, miExport);
			miFeatures.Caption = "XtraTreeList Features";
			miAboutProduct.Caption = "About &XtraTreeList";
		}

		protected override void miAboutProduct_Click(object sender, ItemClickEventArgs e) {
			DevExpress.Utils.About.AboutForm.Show(typeof(DevExpress.XtraTreeList.TreeList), DevExpress.Utils.About.ProductKind.XtraTreeList, DevExpress.Utils.About.ProductInfoStage.Registered);
		}

		#region Look And Feel menu
		public BarSubItem LookAndFeelMenuItem { get { return miLookAndFeel; }}

		public event EventHandler SwitchStyle;
		void RaiseSwitchStyle() {
			if(SwitchStyle != null) SwitchStyle(this, EventArgs.Empty);
		}
		
		protected override void OnSwitchStyle_Click(object sender, ItemClickEventArgs e) {
			base.OnSwitchStyle_Click(sender, e);
			ActiveLookAndFeelStyle style  = ((CheckBarItem)e.Item).Style;
			RaiseSwitchStyle();
		}
		#endregion
		#region View Options
		TreeList viewTreeList = null;
		public void RefreshViewOptions(TreeList treeList) {
			this.viewTreeList = treeList;
			if(treeList != null && miViewOptions.ItemLinks.Count == 0)
				AddOptionsMenu(miViewOptions, treeList.OptionsView, new ItemClickEventHandler(ViewOptionsItem_Click));
			miViewOptions.Visibility = treeList != null ? BarItemVisibility.Always : BarItemVisibility.Never;
		}

		void ViewOptions_Popup(object sender, EventArgs e) {
			if(viewTreeList == null) return;
			InitOptionsMenu(miViewOptions, viewTreeList.OptionsView);
		}

		void ViewOptionsItem_Click(object sender, ItemClickEventArgs e) {
			OptionBarItem item = e.Item as OptionBarItem;
			if(viewTreeList == null || item == null) return;
			DevExpress.Utils.SetOptions.SetOptionValueByString(item.Caption, viewTreeList.OptionsView, item.Checked);
		}
		#endregion
		#region Print And Export
		TreeList exportTreeList = null;
		public void RefreshExport(TreeList treeList) {
			this.exportTreeList = treeList;
			miExport.Visibility = treeList != null ? BarItemVisibility.Always : BarItemVisibility.Never;
		}
		
		Thread thread;
		bool stop;
		void ExportTo(string title, string filter, string exportFormat) {
			if(exportTreeList == null) return;
			string fileName = ShowSaveFileDialog(title, filter);
			if(fileName != "") {
				this.MenuForm.Refresh();
				stop = false;
				thread = new Thread(new ThreadStart(StartExport));	
				thread.Start();
				Cursor currentCursor = Cursor.Current;
				Cursor.Current = Cursors.WaitCursor;
				
				switch(exportFormat) {
					case "XML": exportTreeList.ExportToXml(fileName);
						break;
					case "HTML": exportTreeList.ExportToHtml(fileName);
						break;
					case "PDF": exportTreeList.ExportToPdf(fileName);
						break;
					case "RTF": exportTreeList.ExportToRtf(fileName);
						break;
					case "XLS": exportTreeList.ExportToXls(fileName);
						break;
					case "TEXT": exportTreeList.ExportToText(fileName);
						break;
				}
				EndExport();
				Cursor.Current = currentCursor;
				OpenFile(fileName);
			}
		}
		void ExportXML_Click(object sender, ItemClickEventArgs e) {
			ExportTo("XML file", "XML Files|*.xml", "XML");
		}
		void ExportHtml_Click(object sender, ItemClickEventArgs e) {
			ExportTo("HTML file", "HTML Files|*.htm", "HTML");
		}
		void ExportPdf_Click(object sender, ItemClickEventArgs e) {
			ExportTo("Portable Document Format file", "PDF Files|*.pdf", "PDF");
		}
		void ExportRtf_Click(object sender, ItemClickEventArgs e) {
			ExportTo("Rich Text Format file", "PTF Files|*.rtf", "RTF");
		}
		void ExportXls_Click(object sender, ItemClickEventArgs e) {
			ExportTo("Microsoft Excel file", "XLS Files|*.xls", "XLS");
		}
		void ExportText_Click(object sender, ItemClickEventArgs e) {
			ExportTo("Text file", "Text Files|*.txt", "TEXT");
		}
		void PrintPreview_OnClick(object sender, ItemClickEventArgs e) {
			if(exportTreeList == null) return;
			exportTreeList.ShowPrintPreview();
		}
		void StartExport() {
			Thread.Sleep(400); 
			if(stop)
				return;
			ExportForm progressForm = new ExportForm(this.MenuForm);
			progressForm.Show();
			try {
				while(!stop) { 
					Application.DoEvents();
					Thread.Sleep(100); 
				}
			}
			catch {
			}
			progressForm.Dispose();
		}
		void EndExport() {
			stop = true;
			thread.Join();
		}
		#endregion
	}
}
