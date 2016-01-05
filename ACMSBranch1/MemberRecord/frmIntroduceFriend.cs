using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ACMSDAL;
using ACMSLogic;
using ACMS.Utils;

namespace ACMS.ACMSBranch
{
	/// <summary>
	/// Summary description for frmIntroduceFriend.
	/// </summary>
	public class frmIntroduceFriend : System.Windows.Forms.Form
	{
		private string strMembershipID;
		private string strTerminalBranchCode;
		private int employeeID;
		private MemberRecord myMemberRecord;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.SimpleButton sbtnIntroduce;
		private DevExpress.XtraEditors.SimpleButton sbtnCancel;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtLoyalPoint;
		private ACMS.ucMemberID ucMemberID1;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.LookUpEdit lkFreebie;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmIntroduceFriend(string aMembershipID, int aEmployeeID, MemberRecord aMemberRecord, string aTerminalBranchCode)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			TblRewards rewards = new TblRewards();
			DataTable rewardsTable = rewards.SelectnTypeID(0);
			new XtraUtils.LookupEditBuilder.LoyalPointsLookupEditBuilder(rewardsTable, lkpEdtLoyalPoint.Properties);

			TblReceiptFreebie Freebie = new TblReceiptFreebie();
			DataTable FreebieTable = Freebie.SelectFriendFreebie();
			new XtraUtils.LookupEditBuilder.FriendPromotionLookupEditBuilder(FreebieTable, lkFreebie.Properties);

			strMembershipID = aMembershipID;
			strTerminalBranchCode = aTerminalBranchCode;
			employeeID = aEmployeeID;
			myMemberRecord = aMemberRecord;
			ucMemberID1.StrBranchCode = aTerminalBranchCode;
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
			this.label6 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.sbtnIntroduce = new DevExpress.XtraEditors.SimpleButton();
			this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.lkpEdtLoyalPoint = new DevExpress.XtraEditors.LookUpEdit();
			this.ucMemberID1 = new ACMS.ucMemberID();
			this.label2 = new System.Windows.Forms.Label();
			this.lkFreebie = new DevExpress.XtraEditors.LookUpEdit();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtLoyalPoint.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lkFreebie.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(22, 22);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 16);
			this.label6.TabIndex = 17;
			this.label6.Text = "Introducer ID";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(22, 50);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 20);
			this.label1.TabIndex = 19;
			this.label1.Text = "Loyalty Point";
			// 
			// sbtnIntroduce
			// 
			this.sbtnIntroduce.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnIntroduce.Location = new System.Drawing.Point(54, 120);
			this.sbtnIntroduce.Name = "sbtnIntroduce";
			this.sbtnIntroduce.TabIndex = 3;
			this.sbtnIntroduce.Text = "Introduce";
			this.sbtnIntroduce.Click += new System.EventHandler(this.sbtnIntroduce_Click);
			// 
			// sbtnCancel
			// 
			this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.sbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sbtnCancel.Location = new System.Drawing.Point(164, 120);
			this.sbtnCancel.Name = "sbtnCancel";
			this.sbtnCancel.TabIndex = 4;
			this.sbtnCancel.Text = "Cancel";
			// 
			// lkpEdtLoyalPoint
			// 
			this.lkpEdtLoyalPoint.Location = new System.Drawing.Point(106, 48);
			this.lkpEdtLoyalPoint.Name = "lkpEdtLoyalPoint";
			// 
			// lkpEdtLoyalPoint.Properties
			// 
			this.lkpEdtLoyalPoint.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													 new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtLoyalPoint.Size = new System.Drawing.Size(180, 20);
			this.lkpEdtLoyalPoint.TabIndex = 1;
			this.lkpEdtLoyalPoint.EditValueChanged += new System.EventHandler(this.lkpEdtLoyalPoint_EditValueChanged);
			// 
			// ucMemberID1
			// 
			this.ucMemberID1.EditValue = "";
			this.ucMemberID1.EditValueChanged = null;
			this.ucMemberID1.Location = new System.Drawing.Point(106, 20);
			this.ucMemberID1.Name = "ucMemberID1";
			this.ucMemberID1.Size = new System.Drawing.Size(184, 20);
			this.ucMemberID1.StrBranchCode = null;
			this.ucMemberID1.TabIndex = 0;
			this.ucMemberID1.Load += new System.EventHandler(this.ucMemberID1_Load);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(22, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 20);
			this.label2.TabIndex = 20;
			this.label2.Text = "Freebie";
			// 
			// lkFreebie
			// 
			this.lkFreebie.Location = new System.Drawing.Point(106, 80);
			this.lkFreebie.Name = "lkFreebie";
			// 
			// lkFreebie.Properties
			// 
			this.lkFreebie.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkFreebie.Size = new System.Drawing.Size(180, 20);
			this.lkFreebie.TabIndex = 21;
			this.lkFreebie.EditValueChanged += new System.EventHandler(this.lkFreebie_EditValueChanged);
			// 
			// frmIntroduceFriend
			// 
			this.AcceptButton = this.sbtnIntroduce;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.sbtnCancel;
			this.ClientSize = new System.Drawing.Size(298, 154);
			this.Controls.Add(this.lkFreebie);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.ucMemberID1);
			this.Controls.Add(this.lkpEdtLoyalPoint);
			this.Controls.Add(this.sbtnCancel);
			this.Controls.Add(this.sbtnIntroduce);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label6);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmIntroduceFriend";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Introduce Friend";
			this.Load += new System.EventHandler(this.frmIntroduceFriend_Load);
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtLoyalPoint.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lkFreebie.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void sbtnIntroduce_Click(object sender, System.EventArgs e)
		{
			
			if ((lkpEdtLoyalPoint.EditValue != null || lkFreebie.EditValue != null)  && ucMemberID1.EditValue.ToString().Length != 0)
			{
				if (string.Compare(strMembershipID.Trim(), ucMemberID1.EditValue.ToString().Trim(), true) == 0)
				{
					UI.ShowErrorMessage(this, "Member introduce him/herself is not allow.");
					ucMemberID1.Focus();
					DialogResult = DialogResult.None;
					return;
				}

				string PointType =lkpEdtLoyalPoint.Text;

				double point = 0.0;
				string promoteFreebie = "";
				if (lkpEdtLoyalPoint.EditValue != null)
				{
					point = System.Convert.ToDouble(lkpEdtLoyalPoint.EditValue);
				}
				
				else if (lkFreebie.EditValue != null)
				{
					promoteFreebie = lkFreebie.EditValue.ToString();
				}
					
				string introducerID = ucMemberID1.EditValue.ToString();

				if (point>0)
				{
					if (myMemberRecord.SaveIntroduceFriend(strMembershipID, introducerID, point, employeeID))
					{
						this.DialogResult = DialogResult.OK;
						PrintIntroReceipt(strMembershipID,introducerID,point,PointType);
					}
				}
				else if (promoteFreebie != "")
				{
					DataTable IntroFriendFreebie = myMemberRecord.SaveIntroduceFriend(strMembershipID, introducerID, promoteFreebie, User.BranchCode,employeeID);
					if (IntroFriendFreebie.Rows.Count > 0)
					{
						this.DialogResult = DialogResult.OK;
						PrintIntroReceipt(strMembershipID,introducerID,IntroFriendFreebie);
					}
				}
			}		
			else
			{
				ACMS.Utils.UI.ShowErrorMessage(this, "Please fill in all field.", "Error");
				lkpEdtLoyalPoint.Focus();
				DialogResult = DialogResult.None;
			}
		}

		private void sbtnFind_Click(object sender, System.EventArgs e)
		{
			frmSearchMember myForm = new frmSearchMember(myMemberRecord, 
				myMemberRecord.SearchMember(ucMemberID1.EditValue.ToString(), strTerminalBranchCode, 
				ACMSLogic.MemberRecord.SearchMemberType.AllMember, 1), 
				ucMemberID1.EditValue.ToString(), strTerminalBranchCode);
			if (DialogResult.OK == myForm.ShowDialog(this))
			{
				ucMemberID1.EditValue = myForm.StrMemberShipID;
			}
			myForm.Dispose();
		}
		
		private void PrintIntroReceipt(string CurrentMembershipID, string IntroMembershipID, double pointEarned, string RewardType)
		{
			// MembershipCurrentMemberName
			ACMSLogic.Printing myReceiptPrinting = new  ACMSLogic.Printing();
			myReceiptPrinting.WriteLine(ACMSLogic.Common.ReceiptContent.STR_COMPANY_NAME);
			myReceiptPrinting.WriteLine(ACMSLogic.Common.ReceiptContent.STR_INTRODUCEFRIENDSHEADER);
			myReceiptPrinting.WriteLine(string.Format("Branch : {0}", User.BranchCode));
			myReceiptPrinting.WriteLine("");
			myReceiptPrinting.WriteLine(string.Format("Membership ID : {0}", CurrentMembershipID));
			string strLine = DateTime.Now.ToString("dd/MM/yyyy  hh:mm tt");
			myReceiptPrinting.WriteLine("Rewards Date : " + strLine);
			myReceiptPrinting.WriteLine("");
			myReceiptPrinting.WriteLine(string.Format("Rewards Type : {0}", RewardType));
			myReceiptPrinting.WriteLine("");
			myReceiptPrinting.WriteLine(string.Format("Introducer ID: {0}", IntroMembershipID));
			myReceiptPrinting.WriteLine("");
			myReceiptPrinting.WriteLine(string.Format("Points Earned: {0}", pointEarned));
			myReceiptPrinting.WriteLine("");
			myReceiptPrinting.WriteLine("");
			myReceiptPrinting.WriteLine("");
			myReceiptPrinting.WriteLine("");
			myReceiptPrinting.WriteLine("_________________________________________");
			myReceiptPrinting.WriteLine(string.Format("VERIFIED BY  {0}", CurrentMembershipID));
			myReceiptPrinting.Print();
		}

		
		private void PrintIntroReceipt(string CurrentMembershipID, string IntroMembershipID, DataTable FreebieCode)
		{
			// MembershipCurrentMemberName
			ACMSLogic.Printing myReceiptPrinting = new  ACMSLogic.Printing();
			myReceiptPrinting.WriteLine(ACMSLogic.Common.ReceiptContent.STR_COMPANY_NAME);
			myReceiptPrinting.WriteLine(ACMSLogic.Common.ReceiptContent.STR_INTRODUCEFRIENDSHEADER);
			myReceiptPrinting.WriteLine(string.Format("Branch : {0}", User.BranchCode));
			myReceiptPrinting.WriteLine("");
			myReceiptPrinting.WriteLine(string.Format("Membership ID : {0}", CurrentMembershipID));
			string strLine = DateTime.Now.ToString("dd/MM/yyyy  hh:mm tt");
			myReceiptPrinting.WriteLine("Rewards Date : " + strLine);
			myReceiptPrinting.WriteLine("");
			for( int i = 0; i<FreebieCode.Rows.Count;i++)
			{
				myReceiptPrinting.WriteLine(string.Format("Free Gift : {0}", FreebieCode.Rows[i]["strDescription"].ToString()));
				myReceiptPrinting.WriteLine("");
			}
			myReceiptPrinting.WriteLine(string.Format("Introducer ID: {0}", IntroMembershipID));
//			myReceiptPrinting.WriteLine("");
//			myReceiptPrinting.WriteLine(string.Format("Points Earned: {0}", pointEarned));
			myReceiptPrinting.WriteLine("");
			myReceiptPrinting.WriteLine("");
			myReceiptPrinting.WriteLine("");
			myReceiptPrinting.WriteLine("");
			myReceiptPrinting.WriteLine("_________________________________________");
			myReceiptPrinting.WriteLine(string.Format("VERIFIED BY  {0}", CurrentMembershipID));
			myReceiptPrinting.Print();
		}
		private void frmIntroduceFriend_Load(object sender, System.EventArgs e)
		{
		
		}

		private void ucMemberID1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void lkpEdtLoyalPoint_EditValueChanged(object sender, System.EventArgs e)
		{
			lkFreebie.Enabled = false;
		}

		private void lkFreebie_EditValueChanged(object sender, System.EventArgs e)
		{
			lkpEdtLoyalPoint.Enabled = false;
		}
	}
}
