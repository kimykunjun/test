using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ACMS.ACMSBranch
{
    public partial class PackageAccountRpt : DevExpress.XtraReports.UI.XtraReport
    {
        public PackageAccountRpt()
        {
            InitializeComponent();
        }

        public void PrintRpt(string strSigImage, string strMemberID, string strDateTime, string strBranchCode, string strTherapist, string strPackageCode, string strServiceCode, string strBalance)
        {
            SigPlusNET1.SetSigString(strSigImage);

            xrlblMemberID.Text = strMemberID;
            xrlblDate.Text = strDateTime;
            xrlblPackageCode.Text = strPackageCode;
            xrlblServiceCode.Text = strServiceCode;
            xrlblBalance.Text = strBalance;
            xrlblBranch.Text = strBranchCode;
            xrlblTherapist.Text = strTherapist;
        }
    }
}
