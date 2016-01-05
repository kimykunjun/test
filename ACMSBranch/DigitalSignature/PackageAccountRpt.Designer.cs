namespace ACMS.ACMSBranch
{
    partial class PackageAccountRpt
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
            this.winControlContainer1 = new DevExpress.XtraReports.UI.WinControlContainer();
            this.SigPlusNET1 = new Topaz.SigPlusNET();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrlblMemberID = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblBranch = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblTherapist = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblPackageCode = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblServiceCode = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblBalance = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlblBalance,
            this.xrlblServiceCode,
            this.xrlblPackageCode,
            this.xrlblTherapist,
            this.xrlblBranch,
            this.xrlblDate,
            this.xrlblMemberID,
            this.xrLine3,
            this.xrLabel8,
            this.winControlContainer1,
            this.xrLine2,
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLine1,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1});
            this.Detail.Height = 359;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLine3
            // 
            this.xrLine3.Location = new System.Drawing.Point(25, 300);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.Size = new System.Drawing.Size(192, 9);
            // 
            // xrLabel8
            // 
            this.xrLabel8.Location = new System.Drawing.Point(25, 308);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.Size = new System.Drawing.Size(125, 25);
            this.xrLabel8.Text = "Member Signature";
            // 
            // winControlContainer1
            // 
            this.winControlContainer1.Location = new System.Drawing.Point(25, 233);
            this.winControlContainer1.Name = "winControlContainer1";
            this.winControlContainer1.Size = new System.Drawing.Size(192, 58);
            this.winControlContainer1.WinControl = this.SigPlusNET1;
            // 
            // SigPlusNET1
            // 
            this.SigPlusNET1.Location = new System.Drawing.Point(12, 12);
            this.SigPlusNET1.Name = "SigPlusNET1";
            this.SigPlusNET1.Size = new System.Drawing.Size(184, 56);
            this.SigPlusNET1.TabIndex = 30;
            this.SigPlusNET1.Text = "sigPlusNET2";
            // 
            // xrLine2
            // 
            this.xrLine2.Location = new System.Drawing.Point(25, 217);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.Size = new System.Drawing.Size(275, 8);
            // 
            // xrLabel7
            // 
            this.xrLabel7.Location = new System.Drawing.Point(25, 183);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.Size = new System.Drawing.Size(100, 25);
            this.xrLabel7.Text = "Balance :";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Location = new System.Drawing.Point(25, 158);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.Size = new System.Drawing.Size(100, 25);
            this.xrLabel6.Text = "Service Code :";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Location = new System.Drawing.Point(25, 133);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.Size = new System.Drawing.Size(100, 25);
            this.xrLabel5.Text = "Package Code :";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Location = new System.Drawing.Point(25, 108);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.Size = new System.Drawing.Size(100, 25);
            this.xrLabel4.Text = "Therapist Name :";
            // 
            // xrLine1
            // 
            this.xrLine1.Location = new System.Drawing.Point(25, 92);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Size = new System.Drawing.Size(275, 8);
            // 
            // xrLabel3
            // 
            this.xrLabel3.Location = new System.Drawing.Point(25, 58);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.Size = new System.Drawing.Size(100, 25);
            this.xrLabel3.Text = "Branch :";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Location = new System.Drawing.Point(25, 33);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.Size = new System.Drawing.Size(100, 25);
            this.xrLabel2.Text = "Date :";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Location = new System.Drawing.Point(25, 8);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.Size = new System.Drawing.Size(100, 25);
            this.xrLabel1.Text = "Member :";
            // 
            // PageHeader
            // 
            this.PageHeader.Height = 30;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 30;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrlblMemberID
            // 
            this.xrlblMemberID.Location = new System.Drawing.Point(133, 8);
            this.xrlblMemberID.Name = "xrlblMemberID";
            this.xrlblMemberID.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrlblMemberID.Size = new System.Drawing.Size(167, 25);
            this.xrlblMemberID.Text = "xrlblMemberID";
            // 
            // xrlblDate
            // 
            this.xrlblDate.Location = new System.Drawing.Point(133, 33);
            this.xrlblDate.Name = "xrlblDate";
            this.xrlblDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrlblDate.Size = new System.Drawing.Size(167, 25);
            this.xrlblDate.Text = "xrlblDate";
            // 
            // xrlblBranch
            // 
            this.xrlblBranch.Location = new System.Drawing.Point(133, 58);
            this.xrlblBranch.Name = "xrlblBranch";
            this.xrlblBranch.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrlblBranch.Size = new System.Drawing.Size(167, 25);
            this.xrlblBranch.Text = "xrlblBranch";
            // 
            // xrlblTherapist
            // 
            this.xrlblTherapist.Location = new System.Drawing.Point(133, 108);
            this.xrlblTherapist.Name = "xrlblTherapist";
            this.xrlblTherapist.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrlblTherapist.Size = new System.Drawing.Size(167, 25);
            this.xrlblTherapist.Text = "xrlblTherapist";
            // 
            // xrlblPackageCode
            // 
            this.xrlblPackageCode.Location = new System.Drawing.Point(133, 133);
            this.xrlblPackageCode.Name = "xrlblPackageCode";
            this.xrlblPackageCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrlblPackageCode.Size = new System.Drawing.Size(167, 25);
            this.xrlblPackageCode.Text = "xrlblPackageCode";
            // 
            // xrlblServiceCode
            // 
            this.xrlblServiceCode.Location = new System.Drawing.Point(133, 158);
            this.xrlblServiceCode.Name = "xrlblServiceCode";
            this.xrlblServiceCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrlblServiceCode.Size = new System.Drawing.Size(167, 25);
            this.xrlblServiceCode.Text = "xrlblServiceCode";
            // 
            // xrlblBalance
            // 
            this.xrlblBalance.Location = new System.Drawing.Point(133, 183);
            this.xrlblBalance.Name = "xrlblBalance";
            this.xrlblBalance.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrlblBalance.Size = new System.Drawing.Size(167, 25);
            this.xrlblBalance.Text = "xrlblBalance";
            // 
            // PackageAccountRpt
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter});
            this.Version = "8.3";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.WinControlContainer winControlContainer1;
        internal Topaz.SigPlusNET SigPlusNET1;
        private DevExpress.XtraReports.UI.XRLine xrLine3;
        private DevExpress.XtraReports.UI.XRLabel xrlblMemberID;
        private DevExpress.XtraReports.UI.XRLabel xrlblBranch;
        private DevExpress.XtraReports.UI.XRLabel xrlblDate;
        private DevExpress.XtraReports.UI.XRLabel xrlblBalance;
        private DevExpress.XtraReports.UI.XRLabel xrlblServiceCode;
        private DevExpress.XtraReports.UI.XRLabel xrlblPackageCode;
        private DevExpress.XtraReports.UI.XRLabel xrlblTherapist;
    }
}
