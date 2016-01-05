using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ACMSDAL;


namespace ACMS.ACMSBranch
{
    public partial class DigSignature : Form
    {
        //string strRptType;
        string strSignatureID;
        //string strMemberID;
        //string strDateTime;
        //string strBranchCode;
        //string strTherapist;
        //string strPackageCode;
        //string strServiceCode;
        //string strBalance;

        public DigSignature()
        {
            InitializeComponent();
            //strSignatureID = strSignID;
           // strRptType = rptType;
            //strMemberID = MemberID;            
            //strDateTime = DateTime;
            //strBranchCode = BranchCode;
            //strTherapist = Therapist;
            //strPackageCode = PackageCode;
            //strServiceCode = ServiceCode;
            //strBalance = Balance;
        }

        private void DigSignature_Load(object sender, EventArgs e)
        {
            SigPlusNET1.SetTabletState(1);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SigPlusNET1.ClearTablet();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string ShowSignature()
        {
            return strSignatureID;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            txtImageBinary.Text = SigPlusNET1.GetSigString();
            SigPlusNET1.SetSigString(txtImageBinary.Text);
            strSignatureID = txtImageBinary.Text;


            this.DialogResult = DialogResult.OK;

            //if (strRptType == "PackageAccount")
            //{
            //    return;
            //PackageAccountRpt rpt = new PackageAccountRpt();
            //    ////UpdateSignatureID();
            //rpt.PrintRpt(strSignatureID, strMemberID, strDateTime, strBranchCode, strTherapist, strPackageCode, strServiceCode, strBalance);
            //    //rpt.Print();
            //}
            //else if (strRptType == "CreditAccount")
            //{
            //    CreditAc rpt = new CreditAc();
            //    rpt.PrintRpt(strSignatureID);
            //    rpt.Print();
            //}
       

        }

        //public void UpdateSignatureID()
        //{
        //    string strImageBinary = txtImageBinary.Text;
  
        //    ACMSDAL.ConnectionProvider conProvider = new ConnectionProvider();
        //    TblMemberPackage sqlMemberPackage = new TblMemberPackage();
        //    TblServiceSession sqlServiceSession = new TblServiceSession();

        //    sqlMemberPackage.MainConnectionProvider = conProvider;
        //    //sqlServiceSession.MainConnectionProvider = conProvider;

        //    conProvider.OpenConnection();
        //    conProvider.BeginTransaction("UpdateMemberPackage");

        //    sqlMemberPackage.StrSignatureID = strImageBinary;
        //    sqlMemberPackage.StrMembershipID = strMemberID;

        //    sqlMemberPackage.UpdateSignatureID(strMemberID, strImageBinary);

           
        //}

    }
}
