using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ACMS.ACMSPOS2
{

	
	/// <summary>
	/// Summary description for FormForgetCardAction.
	/// </summary>
	public class FormForgetCardAction : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.SimpleButton sBtn_ForgetCardRefund;
		private DevExpress.XtraEditors.SimpleButton sBtnNew_ForgetCardDeposit;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private ACMSLogic.POS myPOS;
		
		public FormForgetCardAction(ACMSLogic.POS pos)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myPOS = pos;
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
			this.sBtn_ForgetCardRefund = new DevExpress.XtraEditors.SimpleButton();
			this.sBtnNew_ForgetCardDeposit = new DevExpress.XtraEditors.SimpleButton();
			this.SuspendLayout();
			// 
			// sBtn_ForgetCardRefund
			// 
			this.sBtn_ForgetCardRefund.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
			this.sBtn_ForgetCardRefund.Appearance.Options.UseFont = true;
			this.sBtn_ForgetCardRefund.Location = new System.Drawing.Point(307, 23);
			this.sBtn_ForgetCardRefund.Name = "sBtn_ForgetCardRefund";
			this.sBtn_ForgetCardRefund.Size = new System.Drawing.Size(186, 48);
			this.sBtn_ForgetCardRefund.TabIndex = 3;
			this.sBtn_ForgetCardRefund.Text = "Forget Card Refund";
			this.sBtn_ForgetCardRefund.Click += new System.EventHandler(this.sBtn_ForgetCardRefund_Click);
			// 
			// sBtnNew_ForgetCardDeposit
			// 
			this.sBtnNew_ForgetCardDeposit.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sBtnNew_ForgetCardDeposit.Appearance.Options.UseFont = true;
			this.sBtnNew_ForgetCardDeposit.Location = new System.Drawing.Point(51, 23);
			this.sBtnNew_ForgetCardDeposit.Name = "sBtnNew_ForgetCardDeposit";
			this.sBtnNew_ForgetCardDeposit.Size = new System.Drawing.Size(208, 48);
			this.sBtnNew_ForgetCardDeposit.TabIndex = 2;
			this.sBtnNew_ForgetCardDeposit.Text = "Forget Card Deposit";
			this.sBtnNew_ForgetCardDeposit.Click += new System.EventHandler(this.sBtnNew_ForgetCardDeposit_Click);
			// 
			// FormForgetCardAction
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(544, 94);
			this.Controls.Add(this.sBtn_ForgetCardRefund);
			this.Controls.Add(this.sBtnNew_ForgetCardDeposit);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormForgetCardAction";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Forget Card Action";
			this.ResumeLayout(false);

		}
		#endregion

		private void sBtnNew_ForgetCardDeposit_Click(object sender, System.EventArgs e)
		{
			if (myPOS.NCategoryID == 17)
			{
				if (myPOS.ReceiptItemsTable.Rows.Count > 0 || myPOS.POSForgetCardAction == ACMSLogic.POS.ForgetCardAction.Refund)
				{
					MessageBox.Show(this, "Only One item is allow for Forget Card Deposit per receipt.");
					return;
				}

//				ACMSDAL.TblReceipt sqlReceipt = new ACMSDAL.TblReceipt();
//				DataTable receipttable = sqlReceipt.GetToDayForgetCardReceipt(myPOS.StrMembershipID, myPOS.NCategoryID);
//				
//				if (receipttable != null && receipttable.Rows.Count > 0)
//				{
//					MessageBox.Show(this, "You have paid the forget card deposit today.");
//					return;	
//				}

				ACMSDAL.TblCompany comp = new ACMSDAL.TblCompany();
				DataTable compTable = comp.SelectAll();
				decimal forgetCardRate = ACMS.Convert.ToDecimal(compTable.Rows[0]["mForgetCardRate"]);
		
				myPOS.NewReceiptEntry(myPOS.StrMembershipID, -1, "Forget Card", 1, forgetCardRate, 
					myPOS.StrMembershipID);
				
				myPOS.POSForgetCardAction = ACMSLogic.POS.ForgetCardAction.ForgetCard;

				this.Close();
			}
		}

		private void sBtn_ForgetCardRefund_Click(object sender, System.EventArgs e)
		{
			if (myPOS.NCategoryID == 17)
			{
				if (myPOS.POSForgetCardAction == ACMSLogic.POS.ForgetCardAction.ForgetCard)
				{
					MessageBox.Show(this, "This receipt is for Forget Card Deposit. \n You are not allow to tender forget card deposit and forget card refund under one receipt.");
					return;
				}

				// New Forget Card Refund	
				FormForgetCardReceiptSelection frm = new FormForgetCardReceiptSelection(myPOS);
				
				try
				{
					frm.ShowDialog(this);
				}
				finally
				{
					if (frm != null)
					{
						if (!frm.IsDisposed)
						{
							frm.Dispose();
						}
					}
				}

				#region COmment
//				if (myPOS.ReceiptItemsTable.Rows.Count > 0)
//				{
//					MessageBox.Show(this, "Only One item is allow for Forget Card Refund per receipt.");
//					return;
//				}
//
//				ACMSDAL.TblClassAttendance classAttendance = new ACMSDAL.TblClassAttendance();
//				DataTable forgetCardClassTable = classAttendance.GetForgetCardClassAttendance(myPOS.StrMembershipID);
//
//				if (forgetCardClassTable != null && forgetCardClassTable.Rows.Count > 0)
//				{
//					DataTable dateTable = new DataTable();
//					DataColumn coldate = new DataColumn("Date", typeof(string));
//					dateTable.Columns.Add(coldate);
//
//					foreach (DataRow r in forgetCardClassTable.Rows)
//					{
//						DateTime forgetCarddate = ACMS.Convert.ToDateTime(r["dtDate"]);
//						
//						DataRow[] rowList = dateTable.Select("Date = '" + forgetCarddate.ToString("ddMMyyyy")+ "'");
//						
//						if (rowList.Length == 0)
//						{
//							DataRow newRow = dateTable.NewRow();
//							newRow["Date"] = ACMS.Convert.ToDateTime(r["dtDate"]).ToString("ddMMyyyy");
//							dateTable.Rows.Add(newRow);
//						}
//						else
//						{
//							r.Delete();
//						}
//					}
//
//					forgetCardClassTable.AcceptChanges();
//
//					ACMSDAL.TblReceipt sqlReceipt = new ACMSDAL.TblReceipt();
//					DataTable table = new DataTable(); 
//					
//					foreach (DataRow r in forgetCardClassTable.Rows)
//					{
//						DateTime dtDate = ACMS.Convert.ToDateTime(r["dtDate"]);
//						
//						DataTable tempTable = sqlReceipt.GetForgetCardReceipt(myPOS.StrMembershipID, 17, dtDate); 		
//						
//						if (tempTable.Rows.Count > 0)
//						{
//							if (table.Rows.Count > 0)
//							{
//								foreach (DataRow tempRow in tempTable.Rows)
//									table.ImportRow(tempRow);
//								
//							}
//							else
//							{
//								table = tempTable.Copy();
//							}
//						}
//					}
//
//					decimal mUnitPrice = 0;
//					string forgotCardReceiptNo = "";
//
//					foreach (DataRow r in table.Rows)
//					{
//						forgotCardReceiptNo += r["strReceiptNo"].ToString() + ",";		
//						mUnitPrice += ACMS.Convert.ToDecimal(r["mNettAmount"]);
//					}
//
//					myPOS.NewReceiptEntry(myPOS.StrMembershipID, -1, "Forget Card Refund", 
//						1, -mUnitPrice, forgotCardReceiptNo);
//
//				}
//				else
//				{
//					MessageBox.Show(this, "No Forget Card Receipt to refund.");
//					return;
//				}
				#endregion
			}
		}
	}
}
