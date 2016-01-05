using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ACMS.ACMSBranch
{
    public partial class RedemptionRpt : DevExpress.XtraReports.UI.XtraReport
    {
        public RedemptionRpt()
        {
            InitializeComponent();
        }

        public void PrintRpt(string strCompanyName, string strRedemtionHeader, string strSigImage, string strSigKeyData, string strMemberID, string strTransactionID, string strBranchCode, string strItemCode, string strPointsUsed, string strBalancePoints, string strDateTime, string qtyUsed)
        {


            sigPlusNET1.SetJustifyMode(0);
            sigPlusNET1.SetSigCompressionMode(1);
            sigPlusNET1.AutoKeyStart();
            sigPlusNET1.SetAutoKeyData(strSigKeyData);
            sigPlusNET1.AutoKeyFinish();
            sigPlusNET1.SetEncryptionMode(2);
            sigPlusNET1.SetSigString(strSigImage);
            sigPlusNET1.SetDisplayTimeStamp(true);
            sigPlusNET1.SetImageXSize(152);
            sigPlusNET1.SetImageYSize(80);
            pictureBox1.Image = sigPlusNET1.GetSigImage();

            xrlblCompanyName.Text = strCompanyName;
            xrlblRedemptionHeader.Text = strRedemtionHeader;
            xrlblBranch.Text = strBranchCode;
            xrlblTransactionID.Text = strTransactionID;
            xrlblMembershipID.Text = strMemberID;

            xrlblRedemptionDate.Text = strDateTime;
            xrlblItemCode.Text = strItemCode;
            xrlblQty.Text = qtyUsed;
            xrlblPointsUsed.Text = strPointsUsed;
            xrlblBalancePoints.Text = strBalancePoints;
        }
    }
}
