using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;

namespace ACMS.ACMSBranch
{
	/// <summary>
	/// Summary description for XtraReportMemberCard.
	/// </summary>
	public class XtraReportMemberCard : DevExpress.XtraReports.UI.XtraReport
	{
		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.XRBarCode xrBarCode2;
		private DevExpress.XtraReports.UI.XRLabel xrLabel3;
		private DevExpress.XtraReports.UI.XRLabel xrLabel2;
		private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private XRPictureBox xrPictureBox2;
        private string connectionString;
        private SqlConnection connection;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public XtraReportMemberCard()
		{
			//
			// Required for Designer support
			//
			InitializeComponent();              
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        public void CreateBindLeisureLogo()
        {
            connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"];
            connection = new SqlConnection(connectionString);

            DataSet _ds = new DataSet();
            string strSQL = "select COUNT(*) as npCount from tblMemberPackage mp,tblPackage p where mp.strPackageCode=p.strPackageCode and mp.strMembershipID='" + ((DataTable)DataSource).Rows[0]["strMembershipID"].ToString() + "' and nStatusID=0 and fPeak=0 and p.nCategoryID=1 ";
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "Table" }, new SqlParameter("@strSQL", strSQL));

            if (Convert.ToInt32(_ds.Tables["Table"].Rows[0]["npCount"]) > 0)
                xrPictureBox2.Image = global::ACMS.Properties.Resources.Final_Leisure_logo_01;  
        }
		public void CreateBind()
		{
			xrPictureBox1.DataBindings.Add("Image", DataSource, "imgPhoto");            
			xrLabel1.DataBindings.Add("Text",DataSource, "strMembershipID");
			xrLabel2.DataBindings.Add("Text",DataSource, "strCardName");
			xrBarCode2.DataBindings.Add("Text",DataSource, "strMembershipID");
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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrPictureBox2 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrBarCode2 = new DevExpress.XtraReports.UI.XRBarCode();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.BackColor = System.Drawing.Color.Transparent;
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox2,
            this.xrBarCode2,
            this.xrLabel3,
            this.xrLabel2,
            this.xrPictureBox1,
            this.xrLabel1});
            this.Detail.Height = 349;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPictureBox2
            // 
            this.xrPictureBox2.Location = new System.Drawing.Point(248, 27);
            this.xrPictureBox2.Name = "xrPictureBox2";
            this.xrPictureBox2.Size = new System.Drawing.Size(90, 30);
            // 
            // xrBarCode2
            // 
            this.xrBarCode2.Alignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrBarCode2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "strMembershipID", "")});
            this.xrBarCode2.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrBarCode2.Location = new System.Drawing.Point(50, 227);
            this.xrBarCode2.Module = 1F;
            this.xrBarCode2.Name = "xrBarCode2";
            this.xrBarCode2.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
            this.xrBarCode2.Size = new System.Drawing.Size(233, 42);
            this.xrBarCode2.Symbology = code128Generator1;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.xrLabel3.Location = new System.Drawing.Point(0, 142);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.Size = new System.Drawing.Size(17, 17);
            this.xrLabel3.Text = ".";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "strCardName", "")});
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel2.Location = new System.Drawing.Point(11, 177);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.Size = new System.Drawing.Size(209, 19);
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Image", null, "imgPhoto", "")});
            this.xrPictureBox1.Location = new System.Drawing.Point(22, 19);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrPictureBox1.Size = new System.Drawing.Size(99, 119);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "strMembershipID", "")});
            this.xrLabel1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.xrLabel1.Location = new System.Drawing.Point(11, 162);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.Size = new System.Drawing.Size(209, 19);
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // XtraReportMemberCard
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 1, 0);
            this.PageHeight = 353;
            this.PageWidth = 214;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.PaperName = "CR-79";
            this.Version = "8.3";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion
	}
}

