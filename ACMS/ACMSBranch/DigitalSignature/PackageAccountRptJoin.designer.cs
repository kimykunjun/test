namespace ACMS.ACMSBranch
{
    partial class PackageAccountRptJoin
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.winControlContainer2 = new DevExpress.XtraReports.UI.WinControlContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.winControlContainer1 = new DevExpress.XtraReports.UI.WinControlContainer();
            this.sigPlusNET1 = new Topaz.SigPlusNET();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblBranch = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblMember = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Height = 0;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLine3
            // 
            this.xrLine3.Location = new System.Drawing.Point(33, 75);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.Size = new System.Drawing.Size(142, 8);
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel8.Location = new System.Drawing.Point(33, 83);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.Size = new System.Drawing.Size(125, 17);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.Text = "Member Signature";
            // 
            // PageHeader
            // 
            this.PageHeader.Height = 0;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // winControlContainer2
            // 
            this.winControlContainer2.Location = new System.Drawing.Point(33, 0);
            this.winControlContainer2.Name = "winControlContainer2";
            this.winControlContainer2.Size = new System.Drawing.Size(127, 73);
            this.winControlContainer2.WinControl = this.pictureBox1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 70);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1,
            this.ReportFooter});
            this.DetailReport.DataMember = "Master.ServiceUtilization_Relation";
            this.DetailReport.Name = "DetailReport";
            // 
            // Detail1
            // 
            this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel25,
            this.xrLabel24,
            this.xrLabel23,
            this.xrLabel22,
            this.xrLabel21,
            this.xrLabel20,
            this.xrLabel19,
            this.xrLabel18,
            this.xrLabel17,
            this.xrLabel16,
            this.xrLabel15,
            this.xrLabel14,
            this.xrLabel13,
            this.xrLabel11});
            this.Detail1.Height = 125;
            this.Detail1.Name = "Detail1";
            // 
            // xrLabel25
            // 
            this.xrLabel25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.ServiceUtilization_Relation.PackageDesc", "")});
            this.xrLabel25.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel25.Location = new System.Drawing.Point(33, 0);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.Size = new System.Drawing.Size(267, 27);
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.StylePriority.UseTextAlignment = false;
            this.xrLabel25.Text = "xrLabel25";
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel24
            // 
            this.xrLabel24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.ServiceUtilization_Relation.Balance", "")});
            this.xrLabel24.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel24.Location = new System.Drawing.Point(142, 108);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.Size = new System.Drawing.Size(180, 17);
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.Text = "xrLabel24";
            // 
            // xrLabel23
            // 
            this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.ServiceUtilization_Relation.Caption_Balance", "")});
            this.xrLabel23.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel23.Location = new System.Drawing.Point(33, 108);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.Size = new System.Drawing.Size(107, 17);
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.Text = "xrLabel23";
            // 
            // xrLabel22
            // 
            this.xrLabel22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.ServiceUtilization_Relation.Quantity", "")});
            this.xrLabel22.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel22.Location = new System.Drawing.Point(142, 92);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.Size = new System.Drawing.Size(180, 17);
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.Text = "xrLabel22";
            // 
            // xrLabel21
            // 
            this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.ServiceUtilization_Relation.Caption_Quantity", "")});
            this.xrLabel21.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel21.Location = new System.Drawing.Point(33, 92);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.Size = new System.Drawing.Size(107, 17);
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.Text = "xrLabel21";
            // 
            // xrLabel20
            // 
            this.xrLabel20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.ServiceUtilization_Relation.ServiceCode", "")});
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel20.Location = new System.Drawing.Point(142, 75);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.Size = new System.Drawing.Size(180, 17);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.Text = "xrLabel20";
            // 
            // xrLabel19
            // 
            this.xrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.ServiceUtilization_Relation.Caption_ServiceCode", "")});
            this.xrLabel19.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel19.Location = new System.Drawing.Point(33, 75);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.Size = new System.Drawing.Size(107, 17);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.Text = "xrLabel19";
            // 
            // xrLabel18
            // 
            this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.ServiceUtilization_Relation.ExpiryDate", "")});
            this.xrLabel18.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel18.Location = new System.Drawing.Point(142, 58);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.Size = new System.Drawing.Size(180, 17);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.Text = "xrLabel18";
            // 
            // xrLabel17
            // 
            this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.ServiceUtilization_Relation.Caption_Expiry", "")});
            this.xrLabel17.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel17.Location = new System.Drawing.Point(33, 58);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.Size = new System.Drawing.Size(107, 17);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.Text = "xrLabel17";
            // 
            // xrLabel16
            // 
            this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.ServiceUtilization_Relation.PackageCode", "")});
            this.xrLabel16.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel16.Location = new System.Drawing.Point(142, 42);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.Size = new System.Drawing.Size(180, 17);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.Text = "xrLabel16";
            // 
            // xrLabel15
            // 
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.ServiceUtilization_Relation.Caption_PackageCode", "")});
            this.xrLabel15.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel15.Location = new System.Drawing.Point(33, 42);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.Size = new System.Drawing.Size(107, 17);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.Text = "xrLabel15";
            // 
            // xrLabel14
            // 
            this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.ServiceUtilization_Relation.StaffName", "")});
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel14.Location = new System.Drawing.Point(142, 25);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.Size = new System.Drawing.Size(180, 17);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.Text = "xrLabel14";
            // 
            // xrLabel13
            // 
            this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.ServiceUtilization_Relation.Line", "")});
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel13.Location = new System.Drawing.Point(25, 117);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.Size = new System.Drawing.Size(267, 5);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.Text = "xrLabel13";
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.ServiceUtilization_Relation.Caption", "")});
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel11.Location = new System.Drawing.Point(33, 25);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.Size = new System.Drawing.Size(107, 17);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.Text = "xrLabel11";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.winControlContainer1,
            this.winControlContainer2,
            this.xrLabel8,
            this.xrLine3});
            this.ReportFooter.Height = 101;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // winControlContainer1
            // 
            this.winControlContainer1.Location = new System.Drawing.Point(187, 73);
            this.winControlContainer1.Name = "winControlContainer1";
            this.winControlContainer1.Size = new System.Drawing.Size(2, 2);
            this.winControlContainer1.WinControl = this.sigPlusNET1;
            // 
            // sigPlusNET1
            // 
            this.sigPlusNET1.BackColor = System.Drawing.Color.White;
            this.sigPlusNET1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sigPlusNET1.ForeColor = System.Drawing.Color.Black;
            this.sigPlusNET1.Location = new System.Drawing.Point(0, 0);
            this.sigPlusNET1.Margin = new System.Windows.Forms.Padding(0);
            this.sigPlusNET1.Name = "sigPlusNET1";
            this.sigPlusNET1.Size = new System.Drawing.Size(2, 2);
            this.sigPlusNET1.TabIndex = 0;
            this.sigPlusNET1.Visible = false;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine1,
            this.xrLabel1,
            this.xrlblBranch,
            this.xrlblDate,
            this.xrlblMember,
            this.xrLabel3,
            this.xrLabel2});
            this.ReportHeader.Height = 58;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLine1
            // 
            this.xrLine1.Location = new System.Drawing.Point(25, 50);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Size = new System.Drawing.Size(280, 8);
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel1.Location = new System.Drawing.Point(33, 2);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.Size = new System.Drawing.Size(100, 17);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "Member :";
            // 
            // xrlblBranch
            // 
            this.xrlblBranch.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.strBranchCode", "")});
            this.xrlblBranch.Location = new System.Drawing.Point(133, 33);
            this.xrlblBranch.Name = "xrlblBranch";
            this.xrlblBranch.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblBranch.Size = new System.Drawing.Size(100, 17);
            this.xrlblBranch.Text = "xrlblBranch";
            // 
            // xrlblDate
            // 
            this.xrlblDate.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.strDateTime", "")});
            this.xrlblDate.Location = new System.Drawing.Point(133, 17);
            this.xrlblDate.Name = "xrlblDate";
            this.xrlblDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblDate.Size = new System.Drawing.Size(167, 17);
            this.xrlblDate.Text = "xrlblDate";
            // 
            // xrlblMember
            // 
            this.xrlblMember.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Master.strMemberID", "")});
            this.xrlblMember.Location = new System.Drawing.Point(133, 2);
            this.xrlblMember.Name = "xrlblMember";
            this.xrlblMember.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblMember.Size = new System.Drawing.Size(100, 17);
            this.xrlblMember.Text = "xrlblMember";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel3.Location = new System.Drawing.Point(33, 33);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.Size = new System.Drawing.Size(100, 17);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.Text = "Branch :";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrLabel2.Location = new System.Drawing.Point(33, 17);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.Size = new System.Drawing.Size(100, 17);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "Date :";
            // 
            // PackageAccountRptJoin
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.DetailReport,
            this.ReportHeader});
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 30, 30);
            this.PageHeight = 3000;
            this.PageWidth = 350;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.PaperName = "Roll Paper 76 x 297 mm";
            this.Version = "8.3";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLine xrLine3;
        private DevExpress.XtraReports.UI.WinControlContainer winControlContainer2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraReports.UI.DetailReportBand DetailReport;
        private DevExpress.XtraReports.UI.DetailBand Detail1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel25;
        private DevExpress.XtraReports.UI.XRLabel xrLabel24;
        private DevExpress.XtraReports.UI.XRLabel xrLabel23;
        private DevExpress.XtraReports.UI.XRLabel xrLabel22;
        private DevExpress.XtraReports.UI.XRLabel xrLabel21;
        private DevExpress.XtraReports.UI.XRLabel xrLabel20;
        private DevExpress.XtraReports.UI.XRLabel xrLabel19;
        private DevExpress.XtraReports.UI.XRLabel xrLabel18;
        private DevExpress.XtraReports.UI.XRLabel xrLabel17;
        private DevExpress.XtraReports.UI.XRLabel xrLabel16;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrlblBranch;
        private DevExpress.XtraReports.UI.XRLabel xrlblDate;
        private DevExpress.XtraReports.UI.XRLabel xrlblMember;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.WinControlContainer winControlContainer1;
        private Topaz.SigPlusNET sigPlusNET1;
    }
}
