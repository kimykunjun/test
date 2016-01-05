using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;

namespace ACMS.ACMSManager.Human_Resource.Reports
{
    public partial class RPAllIncomeDetail : Form
    {
        public string strReportHeader;
        public RPAllIncomeDetail(string strReport,int nCategory,DateTime dtSelect,int nEmployee)
        {
            InitializeComponent();
            ini(strReport);
            int nYear = dtSelect.Year;
            int nMonth = dtSelect.Month;
            int nDay = dtSelect.Day;
            DataTable tblSource = this.dWV_IncomeAnalysis_prev10TableAdapter.GetData(nCategory, nMonth, nYear,nDay, nEmployee);
            ThirdGridIncomeAnalysis.DataSource = tblSource;
        }
        public void ini(string Report)
        {
            strReportHeader = "Current Month Sales for " + Report;
            labelControl1.Text = strReportHeader;
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GenerateGrid();
        }
        private void GenerateGrid()
        {            
            CompositeLink composLink = new CompositeLink(new PrintingSystem());
            PrintableComponentLink pcLink1 = new PrintableComponentLink();
            Link linkMainReport = new Link();
            Link linkGrid1Report = new Link();
            linkGrid1Report.CreateDetailArea += new CreateAreaEventHandler(linkGrid1Report_CreateDetailArea);

            // Assign the controls to the printing links.
            pcLink1.Component = this.ThirdGridIncomeAnalysis;


            // Populate the collection of links in the composite link.
            // The order of operations corresponds to the document structure.
            composLink.Links.Add(linkGrid1Report);
            composLink.Links.Add(pcLink1);
            composLink.Links.Add(linkMainReport);

            // Create the report and show the preview window.
            //composLink.PrintingSystem.PreviewFormEx.AutoScale = true;
            composLink.PrintingSystem.PageSettings.Landscape = true;
            composLink.CreateDocument(printingSystem1);
            printingSystem1.PreviewFormEx.PrintingSystem.PageSettings.LeftMargin = 0;
            printingSystem1.PreviewFormEx.PrintingSystem.PageSettings.TopMargin = 30;
            //printingSystem1.PreviewFormEx.AutoScale = true;
            printingSystem1.PageSettings.Landscape = true;
            printingSystem1.PreviewFormEx.ForeColor = System.Drawing.Color.Black;
            printingSystem1.PreviewFormEx.Owner = this;
            printingSystem1.PreviewFormEx.PrintingSystem.Print();
        }

        void linkGrid1Report_CreateDetailArea(object sender, CreateAreaEventArgs e) 
        {
    TextBrick tb = new TextBrick();
    tb.Text = strReportHeader;
    tb.Font = new Font("Arial",15);
    tb.Rect = new RectangleF(0, 0, 500, 25);
    tb.BorderWidth = 0;
    tb.BackColor = Color.Transparent;
    tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
    e.Graph.DrawBrick(tb);
}

        }
    }
