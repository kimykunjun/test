using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ACMS
{
	/// <summary>
	/// Summary description for FormTransferMemberPackage.
	/// </summary>
	public class FormConvertMemberPackage : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.MemoEdit memoEdit1;
		private System.Windows.Forms.Label labelHeader;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private ACMSLogic.MemberPackage myMemberPackage;
		private string myCurrMemberID;
        private int myPackageID, myMemberPackageSession;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtNewMemberID;
        private Label label3;
        private TextBox txtmember;
        private TextBox txtPackage;
        private TextBox txtAmount;
        public decimal mConvertAmount;     
        public decimal mPayAmount;
        private decimal mUsageAmount;
        private string strChild;
        private int npointer = 0;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public FormConvertMemberPackage(string strCurrMemberID, int packageID, int nSession)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
            txtmember.Text = strCurrMemberID;
            txtPackage.Text = packageID.ToString();
			myCurrMemberID = strCurrMemberID;
			myPackageID = packageID;
            myMemberPackageSession = nSession;
			labelHeader.Text = string.Format("Convert PackageID = {0} of Member {1}.", packageID, strCurrMemberID);
            // calcualte converted amount (pay amount - usage amount)
            CalculateAmount();
            CalculateUsage();
            mConvertAmount = mPayAmount - mUsageAmount;
            txtAmount.Text = ACMS.Convert.ToDecimal(mConvertAmount).ToString("0.00");
		}

        private decimal GetTotalPayment( string strReceipt)
        {
            ACMSDAL.TblReceipt myReceipt = new ACMSDAL.TblReceipt();
            myReceipt.StrReceiptNo = strReceipt;
            DataTable tblReceiptPaid = myReceipt.SelectOne();

            if (tblReceiptPaid.Rows[0]["strParentReceiptNo"].ToString() == "" && tblReceiptPaid.Rows[0]["strChildReceiptNo"].ToString() == "")
                {
                    // Add payment for full payment
                    mPayAmount = GetPayment(strReceipt) / System.Convert.ToDecimal("1.07");                    
                }
            // Get the Parent Total paid amount from tblmemberpackage + this receipt Total Payment
            else if (tblReceiptPaid.Rows[0]["strParentReceiptNo"].ToString() != "")
            {
                ACMSDAL.TblMemberPackage myMemberPackage = new ACMSDAL.TblMemberPackage();
                myMemberPackage.StrReceiptNo = tblReceiptPaid.Rows[0]["strParentReceiptNo"].ToString();
                myMemberPackage.SelectOneReceipt();
                decimal mParentTotal = myMemberPackage.MTotalPaid.ToDecimal();              
                decimal mNetPayAmount;
                if (System.Convert.ToDateTime(tblReceiptPaid.Rows[0]["dtdate"]) < System.Convert.ToDateTime("01/Jul/2007"))
                    mPayAmount = GetPayment(tblReceiptPaid.Rows[0]["strReceiptNo"].ToString()) / System.Convert.ToDecimal("1.05") + mParentTotal;
                else
                    mPayAmount = GetPayment(tblReceiptPaid.Rows[0]["strReceiptNo"].ToString()) / System.Convert.ToDecimal("1.07") + mParentTotal;

                GetChild(tblReceiptPaid.Rows[0]["strReceiptNo"].ToString());
                if (strChild != null)
                {
                    string[] arrSubTask = strChild.Substring(0, strChild.Length - 1).Split(',');
                    for (int j = 0; j < arrSubTask.Length; j++)
                    {
                        mNetPayAmount = GetPayment(arrSubTask[j].ToString());
                        if (System.Convert.ToDateTime(tblReceiptPaid.Rows[0]["dtdate"]) < System.Convert.ToDateTime("01/Jul/2007"))
                            mNetPayAmount = mNetPayAmount / System.Convert.ToDecimal("1.05");
                        else
                            mNetPayAmount = mNetPayAmount / System.Convert.ToDecimal("1.07");

                        mPayAmount = mPayAmount + mNetPayAmount;

                    }
                }
            }
                else if (tblReceiptPaid.Rows[0]["strChildReceiptNo"].ToString() != "")
                {
                    // Add payment for the receipt and find the child receipt and add back
                   // decimal mReceiptAmount;
                    decimal mNetPayAmount;

                    if (System.Convert.ToDateTime(tblReceiptPaid.Rows[0]["dtdate"]) < System.Convert.ToDateTime("01/Jul/2007"))
                        mPayAmount = GetPayment(tblReceiptPaid.Rows[0]["strReceiptNo"].ToString()) / System.Convert.ToDecimal("1.05");
                    else
                        mPayAmount = GetPayment(tblReceiptPaid.Rows[0]["strReceiptNo"].ToString()) / System.Convert.ToDecimal("1.07");
                    
                    //this.a_audit_spaTableAdapter.GetPaidAmount(tblReceiptPaid.Rows[i]["strChildReceiptNo"].ToString());
                    GetChild(tblReceiptPaid.Rows[0]["strReceiptNo"].ToString());
                    string[] arrSubTask = strChild.Substring(0, strChild.Length - 1).Split(',');
                    for (int j = 0; j < arrSubTask.Length; j++)
                    {
                        mNetPayAmount = GetPayment(arrSubTask[j].ToString());
                        if (System.Convert.ToDateTime(tblReceiptPaid.Rows[0]["dtdate"]) < System.Convert.ToDateTime("01/Jul/2007"))
                            mNetPayAmount = mNetPayAmount / System.Convert.ToDecimal("1.05");
                        else
                            mNetPayAmount = mNetPayAmount / System.Convert.ToDecimal("1.07");

                        mPayAmount = mPayAmount + mNetPayAmount;

                       // this.a_audit_spaTableAdapter.updatePaidAmount(mReceiptAmount, tblReceiptPaid.Rows[0]["strReceiptNo"].ToString());

                    }                  
                  
                }

            return mPayAmount;
        }

        private void GetChild(string Parent)
        {
            string[] ChildNodes = new string[100], MultiNodes = new string[100];
            ACMSDAL.TblReceipt myChild = new ACMSDAL.TblReceipt();
            myChild.StrReceiptNo = Parent;
            DataTable tblChild = myChild.SelectOne();
            if (tblChild.Rows.Count > 0 && tblChild.Rows[0]["strChildReceiptNo"].ToString() != "")
            {
                ChildNodes[0] = tblChild.Rows[0]["strChildReceiptNo"].ToString();
                strChild = strChild + ChildNodes[0].ToString() + ",";
            }
            SplitChild(strChild);
            //return tblChild;
        }

        private void SplitChild(string strChildren)
        {
            npointer++;
            if (strChildren != null)
            {
                string[] strChars = strChildren.Substring(0, strChildren.Length - 1).Split(',');
                if (npointer < strChars.Length + 1)
                {
                    GetChild(strChars[npointer - 1]);
                }
            }

            //npointer=+1;
        }
        private decimal GetPayment(string strReceipt)
        {
            ACMSDAL.TblReceiptPayment tblReceiptPayment = new ACMSDAL.TblReceiptPayment();
            tblReceiptPayment.StrReceiptNo = strReceipt;
            DataTable tblPayment = tblReceiptPayment.SelectAllWstrReceiptNoLogic();

            if (tblPayment.Rows.Count > 0)
                return System.Convert.ToDecimal(tblPayment.Rows[0]["mAmount"]);
            else
                return 0;
        }

        private void CalculateUsage()
        {
            ACMSDAL.TblMemberPackage memberPackage = new ACMSDAL.TblMemberPackage();
            memberPackage.NPackageID = myPackageID;
            DataTable tblmemberpackage = memberPackage.SelectOne();
            ACMSDAL.TblPackage myPackage = new ACMSDAL.TblPackage();
            myPackage.StrPackageCode = tblmemberpackage.Rows[0]["strPackageCode"].ToString();
            DataTable tblPackage = myPackage.SelectOne();
            mUsageAmount = ACMS.Convert.ToDecimal(tblPackage.Rows[0]["mBaseUnitPrice"]) * myMemberPackageSession;
        }

        private void CalculateAmount()
        {
            ACMSDAL.TblMemberPackage memberPackage = new ACMSDAL.TblMemberPackage();
            memberPackage.NPackageID = myPackageID;
            DataTable tblmemberpackage = memberPackage.SelectOne();
            mPayAmount = GetTotalPayment(tblmemberpackage.Rows[0]["strReceiptNo"].ToString());
            
        }
            

        private decimal GetTotalUsage(int nPackage)
        {
            //get from defer income formula
            return 0;
        }

		private void Init()
		{
			ACMSLogic.Member member = new ACMSLogic.Member();

			new ACMS.XtraUtils.LookupEditBuilder.MemberIDLookupEditBuilder(member, lkpEdtNewMemberID.Properties);
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lkpEdtNewMemberID = new DevExpress.XtraEditors.LookUpEdit();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.labelHeader = new System.Windows.Forms.Label();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtmember = new System.Windows.Forms.TextBox();
            this.txtPackage = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtNewMemberID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Member ID";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Package";
            // 
            // lkpEdtNewMemberID
            // 
            this.lkpEdtNewMemberID.EditValue = "";
            this.lkpEdtNewMemberID.Location = new System.Drawing.Point(126, 5);
            this.lkpEdtNewMemberID.Name = "lkpEdtNewMemberID";
            this.lkpEdtNewMemberID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpEdtNewMemberID.Size = new System.Drawing.Size(192, 20);
            this.lkpEdtNewMemberID.TabIndex = 2;
            this.lkpEdtNewMemberID.Visible = false;
            // 
            // memoEdit1
            // 
            this.memoEdit1.EditValue = "";
            this.memoEdit1.Location = new System.Drawing.Point(126, 6);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Properties.MaxLength = 255;
            this.memoEdit1.Size = new System.Drawing.Size(192, 10);
            this.memoEdit1.TabIndex = 3;
            this.memoEdit1.Visible = false;
            // 
            // labelHeader
            // 
            this.labelHeader.Location = new System.Drawing.Point(8, 8);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(320, 23);
            this.labelHeader.TabIndex = 4;
            this.labelHeader.Text = "label3";
            // 
            // simpleButton2
            // 
            this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton2.Location = new System.Drawing.Point(211, 134);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 48;
            this.simpleButton2.Text = "Cancel";
            // 
            // simpleButton1
            // 
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButton1.Location = new System.Drawing.Point(122, 134);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 47;
            this.simpleButton1.Text = "Save";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 49;
            this.label3.Text = "Convert Amount";
            // 
            // txtmember
            // 
            this.txtmember.Location = new System.Drawing.Point(123, 31);
            this.txtmember.Name = "txtmember";
            this.txtmember.ReadOnly = true;
            this.txtmember.Size = new System.Drawing.Size(163, 20);
            this.txtmember.TabIndex = 50;
            // 
            // txtPackage
            // 
            this.txtPackage.Location = new System.Drawing.Point(122, 66);
            this.txtPackage.Name = "txtPackage";
            this.txtPackage.ReadOnly = true;
            this.txtPackage.Size = new System.Drawing.Size(163, 20);
            this.txtPackage.TabIndex = 51;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(122, 96);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(163, 20);
            this.txtAmount.TabIndex = 52;
            // 
            // FormConvertMemberPackage
            // 
            this.AcceptButton = this.simpleButton1;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.simpleButton2;
            this.ClientSize = new System.Drawing.Size(330, 180);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtPackage);
            this.Controls.Add(this.txtmember);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this.lkpEdtNewMemberID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConvertMemberPackage";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Convert Member Package";
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtNewMemberID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
           
            

            //if (memoEdit1.Text.Length == 0)
            //{
            //    MessageBox.Show(this, "Please fill in the remark field.");
            //    this.DialogResult = DialogResult.None;
            //    return;
            //}

            //try
            //{
            //    myMemberPackage.TransferMemberPackage(myCurrMemberID, lkpEdtNewMemberID.Text, memoEdit1.Text);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
		}
	}
}
