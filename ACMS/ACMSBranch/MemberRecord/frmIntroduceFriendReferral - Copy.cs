using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ACMSDAL;
using ACMSLogic;
using ACMS.Utils;
using ACMSLogic.Staff;
using System.Collections.Generic;

namespace ACMS.ACMSBranch
{
	/// <summary>
	/// Summary description for frmIntroduceFriendReferral.
	/// </summary>
	public class frmIntroduceFriendReferral : System.Windows.Forms.Form
	{
		private string strMembershipID;
		private string strTerminalBranchCode;
		private int employeeID;
        private MemberRecord myMemberRecord;

        User myUser;
        private string myNewMembershipID;
        private string strIntroFriendSerialNo;
        private string strFreebiz;
        private TabControl tcIntroFriend;
        private ucNonMemberID ucNonMemberID10;
        private ucNonMemberID ucNonMemberID9;
        private ucNonMemberID ucNonMemberID8;
        private ucNonMemberID ucNonMemberID7;
        private ucNonMemberID ucNonMemberID6;
        private ucNonMemberID ucNonMemberID5;
        private ucNonMemberID ucNonMemberID4;
        private ucNonMemberID ucNonMemberID3;
        private ucNonMemberID ucNonMemberID2;
        private ucNonMemberID ucNonMemberID1;
        private TabPage tpReferal;
        private TabPage tpIntroFriend;
        private DevExpress.XtraEditors.TextEdit txtSerialNo;
        private Label label13;
        private DevExpress.XtraEditors.LookUpEdit lkFreebie2;
        private Label label12;
        private Label label10;
        private Label label11;
        private Label label5;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label3;
        private Label label4;
        private Label label1;
        private DevExpress.XtraEditors.LookUpEdit lkFreebie;
        private Label label2;
        private DevExpress.XtraEditors.SimpleButton sbtnCancel;
        private DevExpress.XtraEditors.SimpleButton sbtnIntroduce;
        private Label label6;
        private DevExpress.XtraEditors.TextEdit txtContact8;
        private DevExpress.XtraEditors.TextEdit txtName8;
        private DevExpress.XtraEditors.TextEdit txtContact7;
        private DevExpress.XtraEditors.TextEdit txtName7;
        private DevExpress.XtraEditors.TextEdit txtContact6;
        private DevExpress.XtraEditors.TextEdit txtName6;
        private DevExpress.XtraEditors.TextEdit txtContact5;
        private DevExpress.XtraEditors.TextEdit txtName5;
        private DevExpress.XtraEditors.TextEdit txtContact4;
        private DevExpress.XtraEditors.TextEdit txtName4;
        private DevExpress.XtraEditors.TextEdit txtContact3;
        private DevExpress.XtraEditors.TextEdit txtName3;
        private DevExpress.XtraEditors.TextEdit txtContact2;
        private DevExpress.XtraEditors.TextEdit txtName2;
        private DevExpress.XtraEditors.TextEdit txtContact1;
        private DevExpress.XtraEditors.TextEdit txtName1;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LookUpEdit ddl8Friends;
        private Label label23;
        private DevExpress.XtraEditors.LookUpEdit ddl4Friends;
        private ACMSLogic.Staff.Contacts myContacts;
        private Label label22;
        private ComboBox cbGender1;
        private ComboBox cbGender8;
        private ComboBox cbGender7;
        private ComboBox cbGender6;
        private ComboBox cbGender5;
        private ComboBox cbGender4;
        private ComboBox cbGender3;
        private ComboBox cbGender2;
        private Label label26;
        private Label label25;
        private Label label24;
        private Label label27;
        private DevExpress.XtraEditors.LookUpEdit lkpEdtSalesPersonID;
        //private Do.TerminalUser terminalUser;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private DevExpress.XtraEditors.CheckEdit chkIssued;
        private ACMS.XtraUtils.LookupEditBuilder.TherapistForPOSSalesLookupEditBuilder myEmployeeIDLookupBuilder;
				

        public frmIntroduceFriendReferral(int aEmployeeID,string CurrentMembershipID,MemberRecord aMemberRecord, ACMSLogic.User oUser, string aStrTerminalBranchCode)
       
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
            myEmployeeIDLookupBuilder = new ACMS.XtraUtils.LookupEditBuilder.TherapistForPOSSalesLookupEditBuilder(lkpEdtSalesPersonID.Properties, aStrTerminalBranchCode);

		    TblReceiptFreebie Freebie = new TblReceiptFreebie();
            DataTable FreebieTable = Freebie.SelectIntro5FriendFreebie();
            new XtraUtils.LookupEditBuilder.FriendPromotionLookupEditBuilder(FreebieTable, lkFreebie.Properties);
           
            TblReceiptFreebie Freebie2 = new TblReceiptFreebie();
            DataTable FreebieTable2 = Freebie.SelectIntro10FriendFreebie();
            new XtraUtils.LookupEditBuilder.FriendPromotionLookupEditBuilder(FreebieTable2, lkFreebie2.Properties);

            TblRewards rewards4 = new TblRewards();
            DataTable rewards4Table = rewards4.SelectRewardsForReferral(4, aStrTerminalBranchCode);
            new XtraUtils.LookupEditBuilder.LoyalPointsLookupEditBuilder(rewards4Table, ddl4Friends.Properties);

            TblRewards rewards8 = new TblRewards();
            DataTable rewards8Table = rewards8.SelectRewardsForReferral(8, aStrTerminalBranchCode);
            new XtraUtils.LookupEditBuilder.LoyalPointsLookupEditBuilder(rewards8Table, ddl8Friends.Properties);

            strMembershipID = CurrentMembershipID;
            strTerminalBranchCode = aStrTerminalBranchCode;
			employeeID = aEmployeeID;
            myMemberRecord = aMemberRecord;
            myUser = oUser;
            ucNonMemberID1.StrBranchCode = aStrTerminalBranchCode;
            ucNonMemberID2.StrBranchCode = aStrTerminalBranchCode;
            ucNonMemberID3.StrBranchCode = aStrTerminalBranchCode;
            ucNonMemberID4.StrBranchCode = aStrTerminalBranchCode;
            ucNonMemberID5.StrBranchCode = aStrTerminalBranchCode;
            ucNonMemberID6.StrBranchCode = aStrTerminalBranchCode;
            ucNonMemberID7.StrBranchCode = aStrTerminalBranchCode;
            ucNonMemberID8.StrBranchCode = aStrTerminalBranchCode;
            ucNonMemberID9.StrBranchCode = aStrTerminalBranchCode;
            ucNonMemberID10.StrBranchCode = aStrTerminalBranchCode;

            TblPromotionIntroFriends sqlPromotionIntroFriends = new TblPromotionIntroFriends();
            DataTable PromotionIntroFriends = sqlPromotionIntroFriends.SelectAllPromotionIntroFriends(strMembershipID);
            myContacts = new Contacts();


            if (PromotionIntroFriends.Rows.Count > 0)
            {
                txtSerialNo.Text = PromotionIntroFriends.Rows[0]["strSerialNo"].ToString();
                chkIssued.Checked = (PromotionIntroFriends.Rows[0]["fIssued"] == DBNull.Value || PromotionIntroFriends.Rows[0]["fIssued"].ToString() == "False" ? false : true);
                ucNonMemberID1.EditValue = PromotionIntroFriends.Rows[0]["strFriendID01"].ToString();
                ucNonMemberID1.Enabled = (ucNonMemberID1.EditValue == "");
                ucNonMemberID2.EditValue = PromotionIntroFriends.Rows[0]["strFriendID02"].ToString();
                ucNonMemberID2.Enabled = (ucNonMemberID2.EditValue == "");
                ucNonMemberID3.EditValue = PromotionIntroFriends.Rows[0]["strFriendID03"].ToString();
                ucNonMemberID3.Enabled = (ucNonMemberID3.EditValue == "");
                ucNonMemberID4.EditValue = PromotionIntroFriends.Rows[0]["strFriendID04"].ToString();
                ucNonMemberID4.Enabled = (ucNonMemberID4.EditValue == "");
                ucNonMemberID5.EditValue = PromotionIntroFriends.Rows[0]["strFriendID05"].ToString();
                ucNonMemberID5.Enabled = (ucNonMemberID5.EditValue == "");
                ucNonMemberID6.EditValue = PromotionIntroFriends.Rows[0]["strFriendID05"].ToString();
                ucNonMemberID6.Enabled = (ucNonMemberID6.EditValue == "");
                ucNonMemberID7.EditValue = PromotionIntroFriends.Rows[0]["strFriendID05"].ToString();
                ucNonMemberID7.Enabled = (ucNonMemberID7.EditValue == "");
                ucNonMemberID8.EditValue = PromotionIntroFriends.Rows[0]["strFriendID05"].ToString();
                ucNonMemberID8.Enabled = (ucNonMemberID8.EditValue == "");
                ucNonMemberID9.EditValue = PromotionIntroFriends.Rows[0]["strFriendID05"].ToString();
                ucNonMemberID9.Enabled = (ucNonMemberID9.EditValue == "");
                ucNonMemberID10.EditValue = PromotionIntroFriends.Rows[0]["strFriendID05"].ToString();
                ucNonMemberID10.Enabled = (ucNonMemberID10.EditValue == "");
                lkFreebie.EditValue = PromotionIntroFriends.Rows[0]["strFreebieCode"].ToString();
            }
            //if (ACMS.Convert.ToInt32(PromotionIntroFriends.Rows[0]["nMaxSession"]) == 9999)
              //  needtoAddBackOneDayExpiryDate = true;
            //
            //DataTable attendedClassTable = classAttendance.GetAllClassAttendancesBasePackageID(wantToUpgrade_nPackageID, pos.StrMembershipID, pos.StrBranchCode);

            //txtSerialNo.Text = "A1";
            //ucNonMemberID1.EditValue = "aa";
            
            ComboboxItem itemFemale = new ComboboxItem();
            itemFemale.Text = "Female";
            itemFemale.Value = "F";
            ComboboxItem itemMale = new ComboboxItem();
            itemMale.Text = "Male";
            itemMale.Value = "M";

            cbGender1.Items.Add(itemFemale);
            cbGender1.Items.Add(itemMale);
            cbGender1.SelectedIndex = 0;
            cbGender2.Items.Add(itemFemale);
            cbGender2.Items.Add(itemMale);
            cbGender2.SelectedIndex = 0;
            cbGender3.Items.Add(itemFemale);
            cbGender3.Items.Add(itemMale);
            cbGender3.SelectedIndex = 0;
            cbGender4.Items.Add(itemFemale);
            cbGender4.Items.Add(itemMale);
            cbGender4.SelectedIndex = 0;
            cbGender5.Items.Add(itemFemale);
            cbGender5.Items.Add(itemMale);
            cbGender5.SelectedIndex = 0;
            cbGender6.Items.Add(itemFemale);
            cbGender6.Items.Add(itemMale);
            cbGender6.SelectedIndex = 0;
            cbGender7.Items.Add(itemFemale);
            cbGender7.Items.Add(itemMale);
            cbGender7.SelectedIndex = 0;
            cbGender8.Items.Add(itemFemale);
            cbGender8.Items.Add(itemMale);
            cbGender8.SelectedIndex = 0;
		}

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
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
            this.tcIntroFriend = new System.Windows.Forms.TabControl();
            this.tpIntroFriend = new System.Windows.Forms.TabPage();
            this.ucNonMemberID10 = new ACMS.ucNonMemberID();
            this.ucNonMemberID9 = new ACMS.ucNonMemberID();
            this.ucNonMemberID8 = new ACMS.ucNonMemberID();
            this.ucNonMemberID7 = new ACMS.ucNonMemberID();
            this.ucNonMemberID6 = new ACMS.ucNonMemberID();
            this.ucNonMemberID5 = new ACMS.ucNonMemberID();
            this.ucNonMemberID4 = new ACMS.ucNonMemberID();
            this.ucNonMemberID3 = new ACMS.ucNonMemberID();
            this.ucNonMemberID2 = new ACMS.ucNonMemberID();
            this.ucNonMemberID1 = new ACMS.ucNonMemberID();
            this.chkIssued = new DevExpress.XtraEditors.CheckEdit();
            this.lkFreebie2 = new DevExpress.XtraEditors.LookUpEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lkFreebie = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnIntroduce = new DevExpress.XtraEditors.SimpleButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSerialNo = new DevExpress.XtraEditors.TextEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.tpReferal = new System.Windows.Forms.TabPage();
            this.label27 = new System.Windows.Forms.Label();
            this.lkpEdtSalesPersonID = new DevExpress.XtraEditors.LookUpEdit();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.cbGender8 = new System.Windows.Forms.ComboBox();
            this.cbGender7 = new System.Windows.Forms.ComboBox();
            this.cbGender6 = new System.Windows.Forms.ComboBox();
            this.cbGender5 = new System.Windows.Forms.ComboBox();
            this.cbGender4 = new System.Windows.Forms.ComboBox();
            this.cbGender3 = new System.Windows.Forms.ComboBox();
            this.cbGender2 = new System.Windows.Forms.ComboBox();
            this.cbGender1 = new System.Windows.Forms.ComboBox();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.ddl8Friends = new DevExpress.XtraEditors.LookUpEdit();
            this.label23 = new System.Windows.Forms.Label();
            this.ddl4Friends = new DevExpress.XtraEditors.LookUpEdit();
            this.label22 = new System.Windows.Forms.Label();
            this.txtContact8 = new DevExpress.XtraEditors.TextEdit();
            this.txtName8 = new DevExpress.XtraEditors.TextEdit();
            this.txtContact7 = new DevExpress.XtraEditors.TextEdit();
            this.txtName7 = new DevExpress.XtraEditors.TextEdit();
            this.txtContact6 = new DevExpress.XtraEditors.TextEdit();
            this.txtName6 = new DevExpress.XtraEditors.TextEdit();
            this.txtContact5 = new DevExpress.XtraEditors.TextEdit();
            this.txtName5 = new DevExpress.XtraEditors.TextEdit();
            this.txtContact4 = new DevExpress.XtraEditors.TextEdit();
            this.txtName4 = new DevExpress.XtraEditors.TextEdit();
            this.txtContact3 = new DevExpress.XtraEditors.TextEdit();
            this.txtName3 = new DevExpress.XtraEditors.TextEdit();
            this.txtContact2 = new DevExpress.XtraEditors.TextEdit();
            this.txtName2 = new DevExpress.XtraEditors.TextEdit();
            this.txtContact1 = new DevExpress.XtraEditors.TextEdit();
            this.txtName1 = new DevExpress.XtraEditors.TextEdit();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.tcIntroFriend.SuspendLayout();
            this.tpIntroFriend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIssued.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkFreebie2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkFreebie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerialNo.Properties)).BeginInit();
            this.tpReferal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtSalesPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddl8Friends.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddl4Friends.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContact8.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName8.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContact7.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName7.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContact6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContact5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContact4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContact3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContact2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContact1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tcIntroFriend
            // 
            this.tcIntroFriend.Controls.Add(this.tpIntroFriend);
            this.tcIntroFriend.Location = new System.Drawing.Point(18, 20);
            this.tcIntroFriend.Name = "tcIntroFriend";
            this.tcIntroFriend.SelectedIndex = 0;
            this.tcIntroFriend.Size = new System.Drawing.Size(384, 440);
            this.tcIntroFriend.TabIndex = 68;
            this.tcIntroFriend.Tag = "";
            // 
            // tpIntroFriend
            // 
            this.tpIntroFriend.Controls.Add(this.ucNonMemberID10);
            this.tpIntroFriend.Controls.Add(this.ucNonMemberID9);
            this.tpIntroFriend.Controls.Add(this.ucNonMemberID8);
            this.tpIntroFriend.Controls.Add(this.ucNonMemberID7);
            this.tpIntroFriend.Controls.Add(this.ucNonMemberID6);
            this.tpIntroFriend.Controls.Add(this.ucNonMemberID5);
            this.tpIntroFriend.Controls.Add(this.ucNonMemberID4);
            this.tpIntroFriend.Controls.Add(this.ucNonMemberID3);
            this.tpIntroFriend.Controls.Add(this.ucNonMemberID2);
            this.tpIntroFriend.Controls.Add(this.ucNonMemberID1);
            this.tpIntroFriend.Controls.Add(this.chkIssued);
            this.tpIntroFriend.Controls.Add(this.lkFreebie2);
            this.tpIntroFriend.Controls.Add(this.label12);
            this.tpIntroFriend.Controls.Add(this.label10);
            this.tpIntroFriend.Controls.Add(this.label11);
            this.tpIntroFriend.Controls.Add(this.label5);
            this.tpIntroFriend.Controls.Add(this.label7);
            this.tpIntroFriend.Controls.Add(this.label8);
            this.tpIntroFriend.Controls.Add(this.label9);
            this.tpIntroFriend.Controls.Add(this.label3);
            this.tpIntroFriend.Controls.Add(this.label4);
            this.tpIntroFriend.Controls.Add(this.label1);
            this.tpIntroFriend.Controls.Add(this.lkFreebie);
            this.tpIntroFriend.Controls.Add(this.label2);
            this.tpIntroFriend.Controls.Add(this.sbtnCancel);
            this.tpIntroFriend.Controls.Add(this.sbtnIntroduce);
            this.tpIntroFriend.Controls.Add(this.label6);
            this.tpIntroFriend.Location = new System.Drawing.Point(4, 22);
            this.tpIntroFriend.Name = "tpIntroFriend";
            this.tpIntroFriend.Padding = new System.Windows.Forms.Padding(3);
            this.tpIntroFriend.Size = new System.Drawing.Size(376, 414);
            this.tpIntroFriend.TabIndex = 1;
            this.tpIntroFriend.Text = "Introduce Fitness (NMC)";
            this.tpIntroFriend.UseVisualStyleBackColor = true;
            // 
            // ucNonMemberID10
            // 
            this.ucNonMemberID10.EditValue = "";
            this.ucNonMemberID10.EditValueChanged = null;
            this.ucNonMemberID10.Enabled = false;
            this.ucNonMemberID10.Location = new System.Drawing.Point(120, 322);
            this.ucNonMemberID10.Name = "ucNonMemberID10";
            this.ucNonMemberID10.Size = new System.Drawing.Size(221, 23);
            this.ucNonMemberID10.StrBranchCode = null;
            this.ucNonMemberID10.TabIndex = 95;
            // 
            // ucNonMemberID9
            // 
            this.ucNonMemberID9.EditValue = "";
            this.ucNonMemberID9.EditValueChanged = null;
            this.ucNonMemberID9.Enabled = false;
            this.ucNonMemberID9.Location = new System.Drawing.Point(119, 292);
            this.ucNonMemberID9.Name = "ucNonMemberID9";
            this.ucNonMemberID9.Size = new System.Drawing.Size(221, 23);
            this.ucNonMemberID9.StrBranchCode = null;
            this.ucNonMemberID9.TabIndex = 94;
            // 
            // ucNonMemberID8
            // 
            this.ucNonMemberID8.EditValue = "";
            this.ucNonMemberID8.EditValueChanged = null;
            this.ucNonMemberID8.Enabled = false;
            this.ucNonMemberID8.Location = new System.Drawing.Point(120, 262);
            this.ucNonMemberID8.Name = "ucNonMemberID8";
            this.ucNonMemberID8.Size = new System.Drawing.Size(221, 23);
            this.ucNonMemberID8.StrBranchCode = null;
            this.ucNonMemberID8.TabIndex = 93;
            // 
            // ucNonMemberID7
            // 
            this.ucNonMemberID7.EditValue = "";
            this.ucNonMemberID7.EditValueChanged = null;
            this.ucNonMemberID7.Enabled = false;
            this.ucNonMemberID7.Location = new System.Drawing.Point(120, 232);
            this.ucNonMemberID7.Name = "ucNonMemberID7";
            this.ucNonMemberID7.Size = new System.Drawing.Size(221, 23);
            this.ucNonMemberID7.StrBranchCode = null;
            this.ucNonMemberID7.TabIndex = 92;
            // 
            // ucNonMemberID6
            // 
            this.ucNonMemberID6.EditValue = "";
            this.ucNonMemberID6.EditValueChanged = null;
            this.ucNonMemberID6.Enabled = false;
            this.ucNonMemberID6.Location = new System.Drawing.Point(120, 202);
            this.ucNonMemberID6.Name = "ucNonMemberID6";
            this.ucNonMemberID6.Size = new System.Drawing.Size(221, 23);
            this.ucNonMemberID6.StrBranchCode = null;
            this.ucNonMemberID6.TabIndex = 91;
            // 
            // ucNonMemberID5
            // 
            this.ucNonMemberID5.EditValue = "";
            this.ucNonMemberID5.EditValueChanged = null;
            this.ucNonMemberID5.Enabled = false;
            this.ucNonMemberID5.Location = new System.Drawing.Point(120, 172);
            this.ucNonMemberID5.Name = "ucNonMemberID5";
            this.ucNonMemberID5.Size = new System.Drawing.Size(221, 23);
            this.ucNonMemberID5.StrBranchCode = null;
            this.ucNonMemberID5.TabIndex = 90;
            // 
            // ucNonMemberID4
            // 
            this.ucNonMemberID4.EditValue = "";
            this.ucNonMemberID4.EditValueChanged = null;
            this.ucNonMemberID4.Enabled = false;
            this.ucNonMemberID4.Location = new System.Drawing.Point(120, 142);
            this.ucNonMemberID4.Name = "ucNonMemberID4";
            this.ucNonMemberID4.Size = new System.Drawing.Size(221, 23);
            this.ucNonMemberID4.StrBranchCode = null;
            this.ucNonMemberID4.TabIndex = 89;
            // 
            // ucNonMemberID3
            // 
            this.ucNonMemberID3.EditValue = "";
            this.ucNonMemberID3.EditValueChanged = null;
            this.ucNonMemberID3.Enabled = false;
            this.ucNonMemberID3.Location = new System.Drawing.Point(120, 112);
            this.ucNonMemberID3.Name = "ucNonMemberID3";
            this.ucNonMemberID3.Size = new System.Drawing.Size(221, 23);
            this.ucNonMemberID3.StrBranchCode = null;
            this.ucNonMemberID3.TabIndex = 88;
            // 
            // ucNonMemberID2
            // 
            this.ucNonMemberID2.EditValue = "";
            this.ucNonMemberID2.EditValueChanged = null;
            this.ucNonMemberID2.Enabled = false;
            this.ucNonMemberID2.Location = new System.Drawing.Point(120, 82);
            this.ucNonMemberID2.Name = "ucNonMemberID2";
            this.ucNonMemberID2.Size = new System.Drawing.Size(221, 23);
            this.ucNonMemberID2.StrBranchCode = null;
            this.ucNonMemberID2.TabIndex = 87;
            // 
            // ucNonMemberID1
            // 
            this.ucNonMemberID1.EditValue = "";
            this.ucNonMemberID1.EditValueChanged = null;
            this.ucNonMemberID1.Enabled = false;
            this.ucNonMemberID1.Location = new System.Drawing.Point(120, 54);
            this.ucNonMemberID1.Name = "ucNonMemberID1";
            this.ucNonMemberID1.Size = new System.Drawing.Size(221, 23);
            this.ucNonMemberID1.StrBranchCode = null;
            this.ucNonMemberID1.TabIndex = 86;
            // 
            // chkIssued
            // 
            this.chkIssued.Location = new System.Drawing.Point(24, 20);
            this.chkIssued.Name = "chkIssued";
            this.chkIssued.Properties.Caption = "Issued Fitness Passes";
            this.chkIssued.Size = new System.Drawing.Size(138, 19);
            this.chkIssued.TabIndex = 96;
            // 
            // lkFreebie2
            // 
            this.lkFreebie2.Location = new System.Drawing.Point(142, 328);
            this.lkFreebie2.Name = "lkFreebie2";
            this.lkFreebie2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkFreebie2.Size = new System.Drawing.Size(180, 20);
            this.lkFreebie2.TabIndex = 83;
            this.lkFreebie2.Visible = false;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(17, 331);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(166, 18);
            this.label12.TabIndex = 82;
            this.label12.Text = "Freebie 10 New Friends";
            this.label12.Visible = false;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(22, 324);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 16);
            this.label10.TabIndex = 81;
            this.label10.Text = "10th";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(21, 294);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 16);
            this.label11.TabIndex = 80;
            this.label11.Text = "9th";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(21, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 16);
            this.label5.TabIndex = 79;
            this.label5.Text = "8th";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(21, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 16);
            this.label7.TabIndex = 78;
            this.label7.Text = "7th";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(21, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 16);
            this.label8.TabIndex = 77;
            this.label8.Text = "6th";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(22, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 16);
            this.label9.TabIndex = 76;
            this.label9.Text = "5th";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(22, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 75;
            this.label3.Text = "4th";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(21, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 16);
            this.label4.TabIndex = 74;
            this.label4.Text = "3rd";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(22, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 73;
            this.label1.Text = "2nd";
            // 
            // lkFreebie
            // 
            this.lkFreebie.Location = new System.Drawing.Point(142, 175);
            this.lkFreebie.Name = "lkFreebie";
            this.lkFreebie.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkFreebie.Size = new System.Drawing.Size(180, 20);
            this.lkFreebie.TabIndex = 72;
            this.lkFreebie.Visible = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(21, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 18);
            this.label2.TabIndex = 71;
            this.label2.Text = "Freebie 5 New Friends";
            this.label2.Visible = false;
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sbtnCancel.Location = new System.Drawing.Point(175, 373);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(75, 23);
            this.sbtnCancel.TabIndex = 69;
            this.sbtnCancel.Text = "Cancel";
            // 
            // sbtnIntroduce
            // 
            this.sbtnIntroduce.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnIntroduce.Location = new System.Drawing.Point(66, 373);
            this.sbtnIntroduce.Name = "sbtnIntroduce";
            this.sbtnIntroduce.Size = new System.Drawing.Size(75, 23);
            this.sbtnIntroduce.TabIndex = 68;
            this.sbtnIntroduce.Text = "Save";
            this.sbtnIntroduce.Click += new System.EventHandler(this.sbtnIntroduce_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(21, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 16);
            this.label6.TabIndex = 70;
            this.label6.Text = "1st";
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.EditValue = "";
            this.txtSerialNo.Location = new System.Drawing.Point(141, 466);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtSerialNo.Size = new System.Drawing.Size(131, 20);
            this.txtSerialNo.TabIndex = 85;
            this.txtSerialNo.Visible = false;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(21, 466);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 16);
            this.label13.TabIndex = 84;
            this.label13.Text = "Serial No";
            this.label13.Visible = false;
            // 
            // tpReferal
            // 
            this.tpReferal.Controls.Add(this.label27);
            this.tpReferal.Controls.Add(this.lkpEdtSalesPersonID);
            this.tpReferal.Controls.Add(this.label26);
            this.tpReferal.Controls.Add(this.label25);
            this.tpReferal.Controls.Add(this.label24);
            this.tpReferal.Controls.Add(this.cbGender8);
            this.tpReferal.Controls.Add(this.cbGender7);
            this.tpReferal.Controls.Add(this.cbGender6);
            this.tpReferal.Controls.Add(this.cbGender5);
            this.tpReferal.Controls.Add(this.cbGender4);
            this.tpReferal.Controls.Add(this.cbGender3);
            this.tpReferal.Controls.Add(this.cbGender2);
            this.tpReferal.Controls.Add(this.cbGender1);
            this.tpReferal.Controls.Add(this.btnCancel);
            this.tpReferal.Controls.Add(this.btnSave);
            this.tpReferal.Controls.Add(this.ddl8Friends);
            this.tpReferal.Controls.Add(this.label23);
            this.tpReferal.Controls.Add(this.ddl4Friends);
            this.tpReferal.Controls.Add(this.label22);
            this.tpReferal.Controls.Add(this.txtContact8);
            this.tpReferal.Controls.Add(this.txtName8);
            this.tpReferal.Controls.Add(this.txtContact7);
            this.tpReferal.Controls.Add(this.txtName7);
            this.tpReferal.Controls.Add(this.txtContact6);
            this.tpReferal.Controls.Add(this.txtName6);
            this.tpReferal.Controls.Add(this.txtContact5);
            this.tpReferal.Controls.Add(this.txtName5);
            this.tpReferal.Controls.Add(this.txtContact4);
            this.tpReferal.Controls.Add(this.txtName4);
            this.tpReferal.Controls.Add(this.txtContact3);
            this.tpReferal.Controls.Add(this.txtName3);
            this.tpReferal.Controls.Add(this.txtContact2);
            this.tpReferal.Controls.Add(this.txtName2);
            this.tpReferal.Controls.Add(this.txtContact1);
            this.tpReferal.Controls.Add(this.txtName1);
            this.tpReferal.Controls.Add(this.label14);
            this.tpReferal.Controls.Add(this.label15);
            this.tpReferal.Controls.Add(this.label16);
            this.tpReferal.Controls.Add(this.label17);
            this.tpReferal.Controls.Add(this.label18);
            this.tpReferal.Controls.Add(this.label19);
            this.tpReferal.Controls.Add(this.label20);
            this.tpReferal.Controls.Add(this.label21);
            this.tpReferal.Location = new System.Drawing.Point(4, 25);
            this.tpReferal.Name = "tpReferal";
            this.tpReferal.Padding = new System.Windows.Forms.Padding(3);
            this.tpReferal.Size = new System.Drawing.Size(452, 479);
            this.tpReferal.TabIndex = 0;
            this.tpReferal.Text = "Referral";
            this.tpReferal.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(3, 40);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(102, 19);
            this.label27.TabIndex = 123;
            this.label27.Text = "Sales Person";
            // 
            // lkpEdtSalesPersonID
            // 
            this.lkpEdtSalesPersonID.EditValue = "";
            this.lkpEdtSalesPersonID.Location = new System.Drawing.Point(111, 32);
            this.lkpEdtSalesPersonID.Name = "lkpEdtSalesPersonID";
            this.lkpEdtSalesPersonID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lkpEdtSalesPersonID.Properties.Appearance.Options.UseFont = true;
            this.lkpEdtSalesPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpEdtSalesPersonID.Size = new System.Drawing.Size(326, 23);
            this.lkpEdtSalesPersonID.TabIndex = 122;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(366, 75);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(42, 13);
            this.label26.TabIndex = 121;
            this.label26.Text = "Gender";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(267, 75);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(44, 13);
            this.label25.TabIndex = 120;
            this.label25.Text = "Contact";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(124, 75);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(35, 13);
            this.label24.TabIndex = 119;
            this.label24.Text = "Name";
            // 
            // cbGender8
            // 
            this.cbGender8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender8.FormattingEnabled = true;
            this.cbGender8.Location = new System.Drawing.Point(358, 333);
            this.cbGender8.Name = "cbGender8";
            this.cbGender8.Size = new System.Drawing.Size(79, 21);
            this.cbGender8.TabIndex = 118;
            // 
            // cbGender7
            // 
            this.cbGender7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender7.FormattingEnabled = true;
            this.cbGender7.Location = new System.Drawing.Point(358, 303);
            this.cbGender7.Name = "cbGender7";
            this.cbGender7.Size = new System.Drawing.Size(79, 21);
            this.cbGender7.TabIndex = 117;
            // 
            // cbGender6
            // 
            this.cbGender6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender6.FormattingEnabled = true;
            this.cbGender6.Location = new System.Drawing.Point(358, 276);
            this.cbGender6.Name = "cbGender6";
            this.cbGender6.Size = new System.Drawing.Size(79, 21);
            this.cbGender6.TabIndex = 116;
            // 
            // cbGender5
            // 
            this.cbGender5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender5.FormattingEnabled = true;
            this.cbGender5.Location = new System.Drawing.Point(358, 246);
            this.cbGender5.Name = "cbGender5";
            this.cbGender5.Size = new System.Drawing.Size(79, 21);
            this.cbGender5.TabIndex = 115;
            // 
            // cbGender4
            // 
            this.cbGender4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender4.FormattingEnabled = true;
            this.cbGender4.Location = new System.Drawing.Point(358, 183);
            this.cbGender4.Name = "cbGender4";
            this.cbGender4.Size = new System.Drawing.Size(79, 21);
            this.cbGender4.TabIndex = 114;
            // 
            // cbGender3
            // 
            this.cbGender3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender3.FormattingEnabled = true;
            this.cbGender3.Location = new System.Drawing.Point(358, 153);
            this.cbGender3.Name = "cbGender3";
            this.cbGender3.Size = new System.Drawing.Size(79, 21);
            this.cbGender3.TabIndex = 113;
            // 
            // cbGender2
            // 
            this.cbGender2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender2.FormattingEnabled = true;
            this.cbGender2.Location = new System.Drawing.Point(358, 123);
            this.cbGender2.Name = "cbGender2";
            this.cbGender2.Size = new System.Drawing.Size(79, 21);
            this.cbGender2.TabIndex = 112;
            // 
            // cbGender1
            // 
            this.cbGender1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender1.FormattingEnabled = true;
            this.cbGender1.Location = new System.Drawing.Point(358, 95);
            this.cbGender1.Name = "cbGender1";
            this.cbGender1.Size = new System.Drawing.Size(79, 21);
            this.cbGender1.TabIndex = 111;
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(206, 419);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 27);
            this.btnCancel.TabIndex = 109;
            this.btnCancel.Text = "Cancel";
            // 
            // btnSave
            // 
            this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnSave.Location = new System.Drawing.Point(75, 419);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 27);
            this.btnSave.TabIndex = 108;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ddl8Friends
            // 
            this.ddl8Friends.Location = new System.Drawing.Point(136, 361);
            this.ddl8Friends.Name = "ddl8Friends";
            this.ddl8Friends.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddl8Friends.Size = new System.Drawing.Size(216, 20);
            this.ddl8Friends.TabIndex = 107;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(11, 364);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(169, 20);
            this.label23.TabIndex = 106;
            this.label23.Text = "8 Friends Reward";
            // 
            // ddl4Friends
            // 
            this.ddl4Friends.Location = new System.Drawing.Point(136, 211);
            this.ddl4Friends.Name = "ddl4Friends";
            this.ddl4Friends.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddl4Friends.Size = new System.Drawing.Size(216, 20);
            this.ddl4Friends.TabIndex = 105;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(11, 214);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(169, 20);
            this.label22.TabIndex = 104;
            this.label22.Text = "4 Friends Reward";
            // 
            // txtContact8
            // 
            this.txtContact8.EditValue = "";
            this.txtContact8.Location = new System.Drawing.Point(258, 333);
            this.txtContact8.Name = "txtContact8";
            this.txtContact8.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtContact8.Properties.Mask.EditMask = "(99)00000000";
            this.txtContact8.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtContact8.Size = new System.Drawing.Size(94, 20);
            this.txtContact8.TabIndex = 103;
            // 
            // txtName8
            // 
            this.txtName8.EditValue = "";
            this.txtName8.Location = new System.Drawing.Point(77, 333);
            this.txtName8.Name = "txtName8";
            this.txtName8.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtName8.Size = new System.Drawing.Size(175, 20);
            this.txtName8.TabIndex = 102;
            // 
            // txtContact7
            // 
            this.txtContact7.EditValue = "";
            this.txtContact7.Location = new System.Drawing.Point(258, 304);
            this.txtContact7.Name = "txtContact7";
            this.txtContact7.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtContact7.Properties.Mask.EditMask = "(99)00000000";
            this.txtContact7.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtContact7.Size = new System.Drawing.Size(94, 20);
            this.txtContact7.TabIndex = 101;
            // 
            // txtName7
            // 
            this.txtName7.EditValue = "";
            this.txtName7.Location = new System.Drawing.Point(77, 304);
            this.txtName7.Name = "txtName7";
            this.txtName7.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtName7.Size = new System.Drawing.Size(175, 20);
            this.txtName7.TabIndex = 100;
            // 
            // txtContact6
            // 
            this.txtContact6.EditValue = "";
            this.txtContact6.Location = new System.Drawing.Point(258, 276);
            this.txtContact6.Name = "txtContact6";
            this.txtContact6.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtContact6.Properties.Mask.EditMask = "(99)00000000";
            this.txtContact6.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtContact6.Size = new System.Drawing.Size(94, 20);
            this.txtContact6.TabIndex = 99;
            // 
            // txtName6
            // 
            this.txtName6.EditValue = "";
            this.txtName6.Location = new System.Drawing.Point(77, 276);
            this.txtName6.Name = "txtName6";
            this.txtName6.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtName6.Size = new System.Drawing.Size(175, 20);
            this.txtName6.TabIndex = 98;
            // 
            // txtContact5
            // 
            this.txtContact5.EditValue = "";
            this.txtContact5.Location = new System.Drawing.Point(258, 246);
            this.txtContact5.Name = "txtContact5";
            this.txtContact5.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtContact5.Properties.Mask.EditMask = "(99)00000000";
            this.txtContact5.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtContact5.Size = new System.Drawing.Size(94, 20);
            this.txtContact5.TabIndex = 97;
            // 
            // txtName5
            // 
            this.txtName5.EditValue = "";
            this.txtName5.Location = new System.Drawing.Point(77, 246);
            this.txtName5.Name = "txtName5";
            this.txtName5.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtName5.Size = new System.Drawing.Size(175, 20);
            this.txtName5.TabIndex = 96;
            // 
            // txtContact4
            // 
            this.txtContact4.EditValue = "";
            this.txtContact4.Location = new System.Drawing.Point(258, 183);
            this.txtContact4.Name = "txtContact4";
            this.txtContact4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtContact4.Properties.Mask.EditMask = "(99)00000000";
            this.txtContact4.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtContact4.Size = new System.Drawing.Size(94, 20);
            this.txtContact4.TabIndex = 95;
            // 
            // txtName4
            // 
            this.txtName4.EditValue = "";
            this.txtName4.Location = new System.Drawing.Point(77, 183);
            this.txtName4.Name = "txtName4";
            this.txtName4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtName4.Size = new System.Drawing.Size(175, 20);
            this.txtName4.TabIndex = 94;
            // 
            // txtContact3
            // 
            this.txtContact3.EditValue = "";
            this.txtContact3.Location = new System.Drawing.Point(258, 153);
            this.txtContact3.Name = "txtContact3";
            this.txtContact3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtContact3.Properties.Mask.EditMask = "(99)00000000";
            this.txtContact3.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtContact3.Size = new System.Drawing.Size(94, 20);
            this.txtContact3.TabIndex = 93;
            // 
            // txtName3
            // 
            this.txtName3.EditValue = "";
            this.txtName3.Location = new System.Drawing.Point(77, 153);
            this.txtName3.Name = "txtName3";
            this.txtName3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtName3.Size = new System.Drawing.Size(175, 20);
            this.txtName3.TabIndex = 92;
            // 
            // txtContact2
            // 
            this.txtContact2.EditValue = "";
            this.txtContact2.Location = new System.Drawing.Point(258, 125);
            this.txtContact2.Name = "txtContact2";
            this.txtContact2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtContact2.Properties.Mask.EditMask = "(99)00000000";
            this.txtContact2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtContact2.Size = new System.Drawing.Size(94, 20);
            this.txtContact2.TabIndex = 91;
            // 
            // txtName2
            // 
            this.txtName2.EditValue = "";
            this.txtName2.Location = new System.Drawing.Point(77, 125);
            this.txtName2.Name = "txtName2";
            this.txtName2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtName2.Size = new System.Drawing.Size(175, 20);
            this.txtName2.TabIndex = 90;
            // 
            // txtContact1
            // 
            this.txtContact1.EditValue = "";
            this.txtContact1.Location = new System.Drawing.Point(258, 95);
            this.txtContact1.Name = "txtContact1";
            this.txtContact1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtContact1.Properties.Mask.EditMask = "(99)00000000";
            this.txtContact1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtContact1.Size = new System.Drawing.Size(94, 20);
            this.txtContact1.TabIndex = 89;
            // 
            // txtName1
            // 
            this.txtName1.EditValue = "";
            this.txtName1.Location = new System.Drawing.Point(77, 95);
            this.txtName1.Name = "txtName1";
            this.txtName1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtName1.Size = new System.Drawing.Size(175, 20);
            this.txtName1.TabIndex = 88;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(11, 336);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(132, 18);
            this.label14.TabIndex = 87;
            this.label14.Text = "8th";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(11, 306);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(132, 18);
            this.label15.TabIndex = 86;
            this.label15.Text = "7th";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(11, 279);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(143, 19);
            this.label16.TabIndex = 85;
            this.label16.Text = "6th";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(12, 249);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(132, 18);
            this.label17.TabIndex = 84;
            this.label17.Text = "5th";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(12, 186);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(132, 18);
            this.label18.TabIndex = 83;
            this.label18.Text = "4th";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(11, 158);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(132, 19);
            this.label19.TabIndex = 82;
            this.label19.Text = "3rd";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(12, 128);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(143, 19);
            this.label20.TabIndex = 81;
            this.label20.Text = "2nd";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(11, 98);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(132, 19);
            this.label21.TabIndex = 80;
            this.label21.Text = "1st";
            // 
            // frmIntroduceFriendReferral
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(507, 558);
            this.Controls.Add(this.tcIntroFriend);
            this.Controls.Add(this.txtSerialNo);
            this.Controls.Add(this.label13);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIntroduceFriendReferral";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Introduce Friend Promotion";
            this.tcIntroFriend.ResumeLayout(false);
            this.tpIntroFriend.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkIssued.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkFreebie2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkFreebie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerialNo.Properties)).EndInit();
            this.tpReferal.ResumeLayout(false);
            this.tpReferal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtSalesPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddl8Friends.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddl4Friends.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContact8.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName8.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContact7.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName7.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContact6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContact5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContact4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContact3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContact2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContact1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName1.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


	

		private void lkpEdtLoyalPoint_EditValueChanged(object sender, System.EventArgs e)
		{
			lkFreebie.Enabled = false;
		}

        private void sbtnFind_Click(object sender, System.EventArgs e)
        {
            frmSearchMember myForm = new frmSearchMember(myMemberRecord,
                myMemberRecord.SearchMember(ucNonMemberID1.EditValue.ToString(), strTerminalBranchCode,
                ACMSLogic.MemberRecord.SearchMemberType.NonMember, 1),
                ucNonMemberID1.EditValue.ToString(), strTerminalBranchCode,1);
            if (DialogResult.OK == myForm.ShowDialog(this))
            {
                ucNonMemberID1.EditValue = myForm.StrMemberShipID;
            }
            myForm.Dispose();
        }

   

        private void sbtnIntroduce_Click(object sender, EventArgs e)
        {
            strFreebiz = "";
            
            List<string> lstMemberID = new List<string>();
            //lstMemberID = null;

            if (ucNonMemberID1.Enabled && ucNonMemberID1.EditValue.ToString().Trim()!="")
                lstMemberID.Add(ucNonMemberID1.ToString());
            if (ucNonMemberID2.Enabled && ucNonMemberID2.EditValue.ToString().Trim() != "")
                lstMemberID.Add(ucNonMemberID2.ToString());
            if (ucNonMemberID3.Enabled && ucNonMemberID3.EditValue.ToString().Trim() != "")
                lstMemberID.Add(ucNonMemberID3.ToString());
            if (ucNonMemberID4.Enabled && ucNonMemberID4.EditValue.ToString().Trim() != "")
                lstMemberID.Add(ucNonMemberID4.ToString());
            if (ucNonMemberID5.Enabled && ucNonMemberID5.EditValue.ToString().Trim() != "")
                lstMemberID.Add(ucNonMemberID5.ToString());
            if (ucNonMemberID6.Enabled && ucNonMemberID6.EditValue.ToString().Trim() != "")
                lstMemberID.Add(ucNonMemberID6.ToString());
            if (ucNonMemberID7.Enabled && ucNonMemberID7.EditValue.ToString().Trim() != "")
                lstMemberID.Add(ucNonMemberID7.ToString());
            if (ucNonMemberID8.Enabled && ucNonMemberID8.EditValue.ToString().Trim() != "")
                lstMemberID.Add(ucNonMemberID8.ToString());
            if (ucNonMemberID9.Enabled && ucNonMemberID9.EditValue.ToString().Trim() != "")
                lstMemberID.Add(ucNonMemberID9.ToString());
            if (ucNonMemberID10.Enabled && ucNonMemberID10.EditValue.ToString().Trim() != "")
                lstMemberID.Add(ucNonMemberID10.ToString());

            TblPromotionIntroFriends IntroFriends = new TblPromotionIntroFriends();
            if (lstMemberID.Count > 0)
            {
                foreach (string s in lstMemberID)
                {
                    if (IntroFriends.CheckFriendExist(s))
                    {
                        UI.ShowErrorMessage(this, "NMC member entered already exists in database!");
                        DialogResult = DialogResult.None;
                        return;
                    }
                }
            }
            
            // if ((lkFreebie.Text.Length != 0) && (lkFreebie2.Text.Length != 0))
            // {
            //    UI.ShowErrorMessage(this, "Please select only one Freebiz accordingly!");
            //    lkFreebie.Focus();
            //    DialogResult = DialogResult.None;
            //    return;
            //}		
            //else
   
             //if (lkFreebie.Text.Length != 0)  
             //           {
             //               if ((ucNonMemberID1.EditValue.ToString().Length != 0) && (ucNonMemberID2.EditValue.ToString().Length != 0) && (ucNonMemberID3.EditValue.ToString().Length != 0) && (ucNonMemberID4.EditValue.ToString().Length != 0) && (ucNonMemberID5.EditValue.ToString().Length != 0))
             //               {
             //                  strFreebiz = lkFreebie.EditValue.ToString();
             //               }
             //               else
             //               {
             //                   UI.ShowErrorMessage(this, "Member has to have 5 friends to entitle 5 friends freebiz!");
             //                   lkFreebie.Focus();
             //                   DialogResult = DialogResult.None;
             //                   return;
             //               }

             //           }
             //else

             //    if (lkFreebie2.Text.Length != 0)
             //    {
             //        if ((ucNonMemberID1.EditValue.ToString().Length != 0) && (ucNonMemberID2.EditValue.ToString().Length != 0) && (ucNonMemberID3.EditValue.ToString().Length != 0) && (ucNonMemberID4.EditValue.ToString().Length != 0) && (ucNonMemberID5.EditValue.ToString().Length != 0) && (ucNonMemberID6.EditValue.ToString().Length != 0) && (ucNonMemberID7.EditValue.ToString().Length != 0) && (ucNonMemberID8.EditValue.ToString().Length != 0) && (ucNonMemberID9.EditValue.ToString().Length != 0) && (ucNonMemberID10.EditValue.ToString().Length != 0))
             //        {
             //            strFreebiz = lkFreebie2.EditValue.ToString();
             //        }
             //        else
             //        {
             //            UI.ShowErrorMessage(this, "Member has to have 10 friends to entitle 10 friends freebiz!");
             //            lkFreebie.Focus();
             //            DialogResult = DialogResult.None;
             //            return;
             //        }

             //    }

             try
            {       
                    
                    IntroFriends.StrMembershipID = strMembershipID;
                    IntroFriends.strSerialNo = txtSerialNo.Text;
                    IntroFriends.strFriendID1 = ucNonMemberID1.EditValue.ToString();
                    IntroFriends.strFriendID2 = ucNonMemberID2.EditValue.ToString();
                    IntroFriends.strFriendID3 = ucNonMemberID3.EditValue.ToString();
                    IntroFriends.strFriendID4 = ucNonMemberID4.EditValue.ToString();
                    IntroFriends.strFriendID5 = ucNonMemberID5.EditValue.ToString();
                    IntroFriends.strFriendID6 = ucNonMemberID6.EditValue.ToString();
                    IntroFriends.strFriendID7 = ucNonMemberID7.EditValue.ToString();
                    IntroFriends.strFriendID8 = ucNonMemberID8.EditValue.ToString();
                    IntroFriends.strFriendID9 = ucNonMemberID9.EditValue.ToString();
                    IntroFriends.strFriendID10 = ucNonMemberID10.EditValue.ToString();
                    IntroFriends.StrFreebieCode = strFreebiz;
                    IntroFriends.FIssued = chkIssued.Checked;
                    IntroFriends.strStaffID = employeeID;
                    IntroFriends.DtCreateDate = DateTime.Now;
                    IntroFriends.Insert();

                    MessageBox.Show("IntroFriends save successfully.");
            }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }

             this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            strFreebiz = "";
            bool is4 = false;
            bool is8 = false;
            if (lkpEdtSalesPersonID.Text == "")
            {
                UI.ShowErrorMessage(this, "Please select Sales Person");
                lkpEdtSalesPersonID.Focus();
                DialogResult = DialogResult.None;
                return;
            }
            else
                employeeID = ACMS.Convert.ToInt32(lkpEdtSalesPersonID.EditValue);

            if (txtName1.Text.ToString().Length == 0 && txtContact1.Text.ToString().Length == 0 && txtName2.Text.ToString().Length == 0 && txtContact2.Text.ToString().Length == 0 && txtName3.Text.ToString().Length == 0 && txtContact3.Text.ToString().Length == 0 && txtName4.Text.ToString().Length == 0 && txtContact4.Text.ToString().Length == 0)
            {
                UI.ShowErrorMessage(this, "Please enter 1st friend name & contact");
                txtName1.Focus();
                DialogResult = DialogResult.None;
                return;
            }
            if (txtName1.Text.ToString().Length != 0 || txtContact1.Text.ToString().Length != 0 || txtName2.Text.ToString().Length != 0 || txtContact2.Text.ToString().Length != 0 || txtName3.Text.ToString().Length != 0 || txtContact3.Text.ToString().Length != 0 || txtName4.Text.ToString().Length != 0 || txtContact4.Text.ToString().Length != 0)
            {
                if (txtName1.Text.ToString().Length == 0 && txtContact1.Text.ToString().Length == 0)
                {
                    UI.ShowErrorMessage(this, "Please enter 1st friend name & contact");
                    txtName1.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                else if (txtName2.Text.ToString().Length == 0 && txtContact2.Text.ToString().Length == 0)
                {
                    UI.ShowErrorMessage(this, "Please enter 2nd friend name & contact");
                    txtName2.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                else if (txtName3.Text.ToString().Length == 0 && txtContact3.Text.ToString().Length == 0)
                {
                    UI.ShowErrorMessage(this, "Please enter 3rd friend name & contact");
                    txtName3.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                else if (txtName4.Text.ToString().Length == 0 && txtContact4.Text.ToString().Length == 0)
                {
                    UI.ShowErrorMessage(this, "Please enter 4th friend name & contact");
                    txtName4.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }                
                is4 = true;
            }

            if (txtName5.Text.ToString().Length != 0 || txtContact5.Text.ToString().Length != 0 || txtName6.Text.ToString().Length != 0 || txtContact6.Text.ToString().Length != 0 || txtName7.Text.ToString().Length != 0 || txtContact7.Text.ToString().Length != 0 || txtName8.Text.ToString().Length != 0 || txtContact8.Text.ToString().Length != 0)
            {
                if (txtName5.Text.ToString().Length == 0 && txtContact5.Text.ToString().Length == 0)
                {
                    UI.ShowErrorMessage(this, "Please enter 5th friend name & contact");
                    txtName5.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                else if (txtName6.Text.ToString().Length == 0 && txtContact6.Text.ToString().Length == 0)
                {
                    UI.ShowErrorMessage(this, "Please enter 6th friend name & contact");
                    txtName6.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                else if (txtName7.Text.ToString().Length == 0 && txtContact7.Text.ToString().Length == 0)
                {
                    UI.ShowErrorMessage(this, "Please enter 7th friend name & contact");
                    txtName7.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                else if (txtName8.Text.ToString().Length == 0 && txtContact8.Text.ToString().Length == 0)
                {
                    UI.ShowErrorMessage(this, "Please enter 8th friend name & contact");
                    txtName8.Focus();
                    DialogResult = DialogResult.None;
                    return;
                }
                is4 = false;
                is8 = true;
            }

            if (ddl4Friends.Text.Length == 0 && is4)
            {
                UI.ShowErrorMessage(this, "Please select Reward for 4 friends!");
                ddl4Friends.Focus();
                DialogResult = DialogResult.None;
                return;
            }

            if (ddl8Friends.Text.Length == 0 && is8)
            {
                UI.ShowErrorMessage(this, "Please select Reward for 8 friends!");
                ddl8Friends.Focus();
                DialogResult = DialogResult.None;
                return;
            }

            if ((ddl4Friends.Text.Length != 0) && (ddl8Friends.Text.Length != 0))
            {
                UI.ShowErrorMessage(this, "Please select only one Reward accordingly!");                
                DialogResult = DialogResult.None;
                return;
            }            

            try
            {                
                if (is4)
                {
                    myContacts = new Contacts();
                    myContacts.NewContact(employeeID, txtName1.Text, "", strTerminalBranchCode, "", cbGender1.Text, DateTime.Now, 13, "", txtContact1.Text, "",1);
                    myContacts = new Contacts();
                    myContacts.NewContact(employeeID, txtName2.Text, "", strTerminalBranchCode, "", cbGender2.Text, DateTime.Now, 13, "", txtContact2.Text, "", 1);
                    myContacts = new Contacts();
                    myContacts.NewContact(employeeID, txtName3.Text, "", strTerminalBranchCode, "", cbGender3.Text, DateTime.Now, 13, "", txtContact3.Text, "", 1);
                    myContacts = new Contacts();
                    myContacts.NewContact(employeeID, txtName4.Text, "", strTerminalBranchCode, "", cbGender4.Text, DateTime.Now, 13, "", txtContact4.Text, "", 1);

                    TblRewards tr = new TblRewards();
                   
                    ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();
                    TblMember sqlMember = new TblMember();
                    TblRewardsTransaction sqlRewardsTransaction = new TblRewardsTransaction();
                    sqlRewardsTransaction.DRewardsPoints = Convert.ToInt16(ddl4Friends.EditValue.ToString());
				    sqlRewardsTransaction.DtDate = DateTime.Now;
				    sqlRewardsTransaction.NEmployeeID = employeeID;
				    sqlRewardsTransaction.NTypeID = 0;
                    sqlRewardsTransaction.StrMembershipID = strMembershipID;
				    sqlRewardsTransaction.StrReferenceNo = "4 Referral";
				    sqlRewardsTransaction.Insert();                    
                }
                else if (is8)
                {
                    myContacts = new Contacts();
                    myContacts.NewContact(employeeID, txtName1.Text, "", strTerminalBranchCode, "", cbGender1.Text, DateTime.Now, 13, "", txtContact1.Text, "", 1);
                    myContacts = new Contacts();
                    myContacts.NewContact(employeeID, txtName2.Text, "", strTerminalBranchCode, "", cbGender2.Text, DateTime.Now, 13, "", txtContact2.Text, "", 1);
                    myContacts = new Contacts();
                    myContacts.NewContact(employeeID, txtName3.Text, "", strTerminalBranchCode, "", cbGender3.Text, DateTime.Now, 13, "", txtContact3.Text, "", 1);
                    myContacts = new Contacts();
                    myContacts.NewContact(employeeID, txtName4.Text, "", strTerminalBranchCode, "", cbGender4.Text, DateTime.Now, 13, "", txtContact4.Text, "", 1);
                    myContacts = new Contacts();
                    myContacts.NewContact(employeeID, txtName5.Text, "", strTerminalBranchCode, "", cbGender5.Text, DateTime.Now, 13, "", txtContact5.Text, "", 1);
                    myContacts = new Contacts();
                    myContacts.NewContact(employeeID, txtName6.Text, "", strTerminalBranchCode, "", cbGender6.Text, DateTime.Now, 13, "", txtContact6.Text, "", 1);
                    myContacts = new Contacts();
                    myContacts.NewContact(employeeID, txtName7.Text, "", strTerminalBranchCode, "", cbGender7.Text, DateTime.Now, 13, "", txtContact7.Text, "", 1);
                    myContacts = new Contacts();
                    myContacts.NewContact(employeeID, txtName8.Text, "", strTerminalBranchCode, "", cbGender8.Text, DateTime.Now, 13, "", txtContact8.Text, "", 1);

                    ACMSDAL.ConnectionProvider connProvider = new ConnectionProvider();
                    TblMember sqlMember = new TblMember();
                    TblRewardsTransaction sqlRewardsTransaction = new TblRewardsTransaction();
                    sqlRewardsTransaction.DRewardsPoints = Convert.ToInt16(ddl8Friends.EditValue.ToString());
                    sqlRewardsTransaction.DtDate = DateTime.Now;
                    sqlRewardsTransaction.NEmployeeID = employeeID;
                    sqlRewardsTransaction.NTypeID = 0;
                    sqlRewardsTransaction.StrMembershipID = strMembershipID;
                    sqlRewardsTransaction.StrReferenceNo = "8 Referral";
                    sqlRewardsTransaction.Insert();
                }

                MessageBox.Show("Intro Friends save successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Close();
        }


    }
}