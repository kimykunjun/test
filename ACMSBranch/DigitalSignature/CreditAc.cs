using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ACMS.ACMSBranch
{
    public partial class CreditAc : DevExpress.XtraReports.UI.XtraReport
    {
        public CreditAc()
        {
            InitializeComponent();
        }
        public void PrintRpt(string strSignImage, string strMID, string strDateTime, string strBCode, string strPBalance, string strBal, string strCBalance)
        {
            SigPlusNET1.SetSigString(strSignImage);

            xrlblMember.Text = strMID;
            xrlblDate.Text = strDateTime;
            xrlblBranch.Text = strBCode;
            xrlblPreviousBalance.Text = strPBalance;
            xrlblBalance.Text = strBal;
            xrlblCurrentBalance.Text = strCBalance;

        }
    }
}
