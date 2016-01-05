using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ACMS.ACMSBranch
{
    public partial class PackageAccountRptJoin : DevExpress.XtraReports.UI.XtraReport
    {
        public PackageAccountRptJoin()
        {
            InitializeComponent();
        }

        public void PrintSignatureImage(string strSigImage, string strSigKeyData)
        {
            sigPlusNET1.SetJustifyMode(0);
            sigPlusNET1.SetSigCompressionMode(1);
            sigPlusNET1.AutoKeyStart();
            sigPlusNET1.SetAutoKeyData(strSigKeyData);
            sigPlusNET1.AutoKeyFinish();
            sigPlusNET1.SetEncryptionMode(2);
            sigPlusNET1.SetSigString(strSigImage);
            //sigPlusNET1.SetDisplayTimeStamp(true);
            sigPlusNET1.SetImageXSize(160);
            sigPlusNET1.SetImageYSize(80);
            if (strSigImage != "")
                pictureBox1.Image = sigPlusNET1.GetSigImage();

            //xrlblMember.Text = strMID;
            //xrlblDate.Text = strDateTime;
            //xrlblBranch.Text = strBCode;
            //xrlblPreviousBalance.Text = strPBalance;

            //xrlblCurrentBalance.Text = strCBalance;

        }

        /*public void PrintRpt(string strCaption, string strSigImage, string strSigKeyData, string strMemberID, string strDateTime, string strExpiryDate, string strBranchCode, string strTherapist, string strPackageCode, string strServiceCode, string strBalance, int nQuantity)
        {            
            sigPlusNET1.SetJustifyMode(0);
            sigPlusNET1.SetSigCompressionMode(1);
            sigPlusNET1.AutoKeyStart();
            sigPlusNET1.SetAutoKeyData(strSigKeyData);
            sigPlusNET1.AutoKeyFinish();
            sigPlusNET1.SetEncryptionMode(2);            
            sigPlusNET1.SetSigString(strSigImage);                                   
            
            sigPlusNET1.SetImageXSize(152);
            sigPlusNET1.SetImageYSize(80);            
            if (strSigImage != "")
                pictureBox1.Image = sigPlusNET1.GetSigImage();                      
            xrLabel4.Text = strCaption;
            xrlblMemberID.Text = strMemberID;
            xrlblDate.Text = strDateTime;
            xrlblExpiryDate.Text = strExpiryDate;
            xrlblPackageCode.Text = strPackageCode;
            xrlblServiceCode.Text = strServiceCode;
            xrlblBalance.Text = strBalance;
            xrlblBranch.Text = strBranchCode;
            xrlblTherapist.Text = strTherapist;
            xrlblQuantity.Text = nQuantity.ToString();
        }*/
    }
}
