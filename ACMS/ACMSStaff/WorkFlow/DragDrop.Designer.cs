namespace DevExpress.XtraTreeList.Demos {
    partial class TreeListDragDrop {
        protected override void Dispose(bool disposing) {
            if(disposing) {
                if(components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Project"}, -1, System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft Sans Serif", 8.25F));
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Deliverable"}, -1, System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft Sans Serif", 8.25F));
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "Task"}, -1, System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft Sans Serif", 8.25F));
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeListDragDrop));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelControl1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.panel1.Size = new System.Drawing.Size(1004, 52);
            this.panel1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.panelControl1.Controls.Add(this.listView1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(671, 48);
            this.panelControl1.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.Checked = true;
            listViewItem2.StateImageIndex = 1;
            listViewItem3.Checked = true;
            listViewItem3.StateImageIndex = 2;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.listView1.Location = new System.Drawing.Point(5, 3);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Scrollable = false;
            this.listView1.Size = new System.Drawing.Size(661, 42);
            this.listView1.StateImageList = this.imageList1;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            this.listView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseMove);
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            this.listView1.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.listView1_GiveFeedback);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.ImageIndex = 0;
            this.label1.ImageList = this.imageList3;
            this.label1.Location = new System.Drawing.Point(777, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 48);
            this.label1.TabIndex = 1;
            this.label1.DragDrop += new System.Windows.Forms.DragEventHandler(this.label1_DragDrop);
            this.label1.DragLeave += new System.EventHandler(this.label1_DragLeave);
            this.label1.DragEnter += new System.Windows.Forms.DragEventHandler(this.label1_DragEnter);
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList3.Images.SetKeyName(0, "");
            this.imageList3.Images.SetKeyName(1, "");
            // 
            // treeList1
            // 
            this.treeList1.AllowDrop = true;
            this.treeList1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.treeList1.Appearance.Empty.Options.UseBackColor = true;
            this.treeList1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.treeList1.Appearance.EvenRow.BackColor2 = System.Drawing.Color.GhostWhite;
            this.treeList1.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.treeList1.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.treeList1.Appearance.EvenRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.treeList1.Appearance.EvenRow.Options.UseBackColor = true;
            this.treeList1.Appearance.EvenRow.Options.UseFont = true;
            this.treeList1.Appearance.EvenRow.Options.UseForeColor = true;
            this.treeList1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(225)))));
            this.treeList1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.treeList1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.treeList1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeList1.Appearance.FocusedCell.Options.UseFont = true;
            this.treeList1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treeList1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Navy;
            this.treeList1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(178)))));
            this.treeList1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.treeList1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treeList1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeList1.Appearance.FocusedRow.Options.UseFont = true;
            this.treeList1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treeList1.Appearance.FooterPanel.BackColor = System.Drawing.Color.Silver;
            this.treeList1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.Silver;
            this.treeList1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.treeList1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.treeList1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treeList1.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.treeList1.Appearance.FooterPanel.Options.UseFont = true;
            this.treeList1.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treeList1.Appearance.GroupButton.BackColor = System.Drawing.Color.Silver;
            this.treeList1.Appearance.GroupButton.BorderColor = System.Drawing.Color.Silver;
            this.treeList1.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.treeList1.Appearance.GroupButton.Options.UseBackColor = true;
            this.treeList1.Appearance.GroupButton.Options.UseBorderColor = true;
            this.treeList1.Appearance.GroupButton.Options.UseForeColor = true;
            this.treeList1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(202)))), ((int)(((byte)(202)))));
            this.treeList1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(202)))), ((int)(((byte)(202)))));
            this.treeList1.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.treeList1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treeList1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.treeList1.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treeList1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Silver;
            this.treeList1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Silver;
            this.treeList1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.treeList1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.treeList1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treeList1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.treeList1.Appearance.HeaderPanel.Options.UseFont = true;
            this.treeList1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treeList1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.Gray;
            this.treeList1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.treeList1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.treeList1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treeList1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treeList1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treeList1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.treeList1.Appearance.HorzLine.Options.UseBackColor = true;
            this.treeList1.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            this.treeList1.Appearance.OddRow.BackColor2 = System.Drawing.Color.White;
            this.treeList1.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.treeList1.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.treeList1.Appearance.OddRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.treeList1.Appearance.OddRow.Options.UseBackColor = true;
            this.treeList1.Appearance.OddRow.Options.UseFont = true;
            this.treeList1.Appearance.OddRow.Options.UseForeColor = true;
            this.treeList1.Appearance.Preview.BackColor = System.Drawing.Color.White;
            this.treeList1.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 10F);
            this.treeList1.Appearance.Preview.ForeColor = System.Drawing.Color.Navy;
            this.treeList1.Appearance.Preview.Options.UseBackColor = true;
            this.treeList1.Appearance.Preview.Options.UseFont = true;
            this.treeList1.Appearance.Preview.Options.UseForeColor = true;
            this.treeList1.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.treeList1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.treeList1.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.treeList1.Appearance.Row.Options.UseBackColor = true;
            this.treeList1.Appearance.Row.Options.UseFont = true;
            this.treeList1.Appearance.Row.Options.UseForeColor = true;
            this.treeList1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(138)))));
            this.treeList1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.treeList1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.treeList1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.treeList1.Appearance.SelectedRow.Options.UseFont = true;
            this.treeList1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treeList1.Appearance.TreeLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.treeList1.Appearance.TreeLine.Options.UseBackColor = true;
            this.treeList1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.treeList1.Appearance.VertLine.Options.UseBackColor = true;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn3});
            this.treeList1.Location = new System.Drawing.Point(0, 49);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.CanCloneNodesOnDrop = true;
            this.treeList1.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treeList1.OptionsBehavior.DragNodes = true;
            this.treeList1.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList1.OptionsBehavior.ShowEditorOnMouseUp = true;
            this.treeList1.OptionsBehavior.SmartMouseHover = false;
            this.treeList1.OptionsView.EnableAppearanceEvenRow = true;
            this.treeList1.OptionsView.EnableAppearanceOddRow = true;
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryImageComboBox1});
            this.treeList1.Size = new System.Drawing.Size(1007, 286);
            this.treeList1.StateImageList = this.imageList1;
            this.treeList1.TabIndex = 1;
            this.treeList1.DragOver += new System.Windows.Forms.DragEventHandler(this.treeList1_DragOver);
            this.treeList1.DragLeave += new System.EventHandler(this.treeList1_DragLeave);
            this.treeList1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeList1_DragDrop);
            this.treeList1.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.treeList1_GiveFeedback);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Name";
            this.treeListColumn1.FieldName = "Name";
            this.treeListColumn1.MinWidth = 27;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "Department";
            this.treeListColumn3.ColumnEdit = this.repositoryImageComboBox1;
            this.treeListColumn3.FieldName = "Priority";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 1;
            // 
            // repositoryImageComboBox1
            // 
            this.repositoryImageComboBox1.AllowFocused = false;
            this.repositoryImageComboBox1.AutoHeight = false;
            this.repositoryImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Account", 0, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("COO", 1, 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Marketing", 2, 1)});
            this.repositoryImageComboBox1.Name = "repositoryImageComboBox1";
            this.repositoryImageComboBox1.SmallImages = this.imageList2;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList2.Images.SetKeyName(0, "animation_texture_24.ico");
            this.imageList2.Images.SetKeyName(1, "bridge_write_24.ico");
            this.imageList2.Images.SetKeyName(2, "circle_24.ico");
            this.imageList2.Images.SetKeyName(3, "byu_ok_24.ico");
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AllowFocused = false;
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // TreeListDragDrop
            // 
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.panel1);
            this.Name = "TreeListDragDrop";
            this.Size = new System.Drawing.Size(1007, 343);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryImageComboBox1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.ComponentModel.IContainer components;
    }
}
