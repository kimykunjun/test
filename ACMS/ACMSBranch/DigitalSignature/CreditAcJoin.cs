using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ACMS.ACMSBranch
{
    public partial class CreditAcJoin : DevExpress.XtraReports.UI.XtraReport
    {
        public CreditAcJoin()
        {
            InitializeComponent();
        }
        public void PrintSignatureImage(string strSignImage)
        {
           // SigPlusNET1.SetSigString(strSignImage);

            //xrlblMember.Text = strMID;
            //xrlblDate.Text = strDateTime;
            //xrlblBranch.Text = strBCode;
            //xrlblPreviousBalance.Text = strPBalance;
            
            //xrlblCurrentBalance.Text = strCBalance;

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
    }
}
