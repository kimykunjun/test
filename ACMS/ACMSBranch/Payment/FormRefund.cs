using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ACMS
{
    public partial class FormRefund : Form
    {
        public string strReceiptNo;
        public string strChequeNo;
        public double mRefundAmt;
        public FormRefund(DataRow r)
        {
            InitializeComponent();
            txtChequeNo.Text = "";
            txtRefundAmt.Text = r["mTotalAmount"].ToString();
            mRefundAmt = Convert.ToDouble(r["mTotalAmount"]);
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            if (txtChequeNo.Text == "" || txtChequeNo.Text.Length < 8 || txtRefundAmt.Text == "" || txtRefundAmt.Text == "$0.00" || Convert.ToDouble(txtRefundAmt.Text) > mRefundAmt)
            {
                MessageBox.Show(this, "Please enter correct Cheque No and refund amount");
            }
            else
            {
                strChequeNo = txtChequeNo.Text;
                mRefundAmt = Convert.ToDouble(txtRefundAmt.Text); 
            }
        }
    }
}
