using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ACMS.Utils;
using ACMSLogic;
using ACMSDAL;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Cryptography;

namespace ACMS.ACMSBranch
{
	/// <summary>
	/// Summary description for frmNewMember.
	/// </summary>
	public class frmDNCConsent : System.Windows.Forms.Form
	{
		private MemberRecord myMemberRecord;
		private ACMSLogic.User myUser;
		private string strTerminalBranchCode;
        private string strMembershipID;
        private string strMembershipName;
        public string strSignatureID;
        private string strEmail;
        private DevExpress.XtraEditors.SimpleButton sbtnEmail;
        private ACMS.XtraUtils.LookupEditBuilder.MediaSourceLookupEditBuilder myMediaSourceLookupBuilder;
        private DevExpress.XtraEditors.SimpleButton sbtnSigPad;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public string StrMembershipID
		{
			get { return strMembershipID; }
			set { strMembershipID = value; }
		}

        public string StrMembershipName
        {
            get { return strMembershipName; }
            set { strMembershipName = value; }
        }

        public string StrEmail
        {
            get { return strEmail; }
            set { strEmail = value; }
        }

        public frmDNCConsent(string aStrMembershipID, string aStrMembershipName, string aStrEmail, MemberRecord aMemberRecord, ACMSLogic.User oUser, string aStrTerminalBranchCode)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            			
			myMemberRecord = aMemberRecord;
			myUser = oUser;
			strTerminalBranchCode = aStrTerminalBranchCode;
            strMembershipID = aStrMembershipID;
            strMembershipName = aStrMembershipName;
            strEmail = aStrEmail;
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
            this.sbtnEmail = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnSigPad = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // sbtnEmail
            // 
            this.sbtnEmail.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnEmail.Location = new System.Drawing.Point(12, 12);
            this.sbtnEmail.Name = "sbtnEmail";
            this.sbtnEmail.Size = new System.Drawing.Size(179, 69);
            this.sbtnEmail.TabIndex = 5;
            this.sbtnEmail.Text = "Send DNC Consent Email";
            this.sbtnEmail.Click += new System.EventHandler(this.sbtnEmail_Click);
            // 
            // sbtnSigPad
            // 
            this.sbtnSigPad.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnSigPad.Location = new System.Drawing.Point(197, 12);
            this.sbtnSigPad.Name = "sbtnSigPad";
            this.sbtnSigPad.Size = new System.Drawing.Size(179, 69);
            this.sbtnSigPad.TabIndex = 6;
            this.sbtnSigPad.Text = "Signature Pad Get Consent";
            this.sbtnSigPad.Click += new System.EventHandler(this.sbtnSigPad_Click);
            // 
            // frmDNCConsent
            // 
            this.AcceptButton = this.sbtnEmail;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(389, 98);
            this.Controls.Add(this.sbtnSigPad);
            this.Controls.Add(this.sbtnEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDNCConsent";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DNC Consent";
            this.Load += new System.EventHandler(this.frmDNCConsent_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void sbtnCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void sbtnEmail_Click(object sender, System.EventArgs e)
		{
            try
            {
                DialogResult yes = MessageBox.Show(this, string.Format("Are you sure to send DNC Consent email to member {0}?", StrMembershipID),
                    "Warning", MessageBoxButtons.YesNo);
                if (yes == DialogResult.Yes)
                {
                    SendConfirmation(StrMembershipID, StrMembershipName, strEmail.Trim());                    
                }                
            }
            catch (Exception ex)
            {
            }
		}

        protected void SendConfirmation(string strMembershipID, string strMembershipName, string strEmail)
        {
            int nEdmId = 71;
            string tmp_strEncryptionKey = "";
            string tmp_strSubject = "";
            string tmp_strContent = "";
            string tmp_strSender = "";
            Random rnd = new Random();

            DateTime dtToday = DateTime.Today;
            string dtExpiryDate = String.Format("{0:MMM d, yyyy}", dtToday.AddMonths(1));
            
            //Blast the email consent to the leads if email is not null
            if (strEmail.Trim() != "" && IsEmailValid(strEmail.ToLower()))
            {
                DataTable dtEdmContent = new DataTable();
                TblMember myMember = new TblMember();
                dtEdmContent = myMember.GetMemberConfirmationEmail();

                if (dtEdmContent.Rows.Count > 0)
                {
                    foreach (DataRow rs in dtEdmContent.Rows)
                    {
                        tmp_strSender = rs["strSender"].ToString().Trim();
                        tmp_strSubject = rs["strSubject"].ToString().Trim();
                        tmp_strContent = rs["strContent"].ToString().Trim();
                    }
                }

                dtEdmContent.Dispose();
                //nEdmId = myContacts.CreateNewEdm(tmp_strSender, tmp_strSubject, tmp_strContent, 1, 9, "L"); //Insert Into DB

                string tmp_strMembershipID = strMembershipID.ToString();
                string tmp_strMemberName = strMembershipName;
                //Generate random order number 1-5
                int tmp_nOrder = GetRandomOrderNo(rnd);
                string tmp_strDate = GetToday();

                //Generate Encryption Key, status = 0
                tmp_strEncryptionKey = GetEncryptionKey(nEdmId, tmp_strMembershipID, strEmail.Trim(), tmp_strDate);

                //Need to check if email has been sent - from logs     
                if (!IsDuplicatedSubmission(tmp_strMembershipID,
                                                    strEmail.Trim(),
                                                    nEdmId,
                                                    tmp_strEncryptionKey))
                {
                    //Send Email
                    SendEDM(StrMembershipID, tmp_strMemberName.ToUpper(), dtExpiryDate, strEmail,
                                tmp_strSender, tmp_strSubject, tmp_strContent, nEdmId.ToString(),
                                tmp_strEncryptionKey);

                    InsertEmailSendingLog(strEmail.Trim(), nEdmId,
                                                    tmp_strMembershipID, tmp_strMemberName,
                                                    tmp_strDate, tmp_strEncryptionKey,
                                                    "M");
                    MessageBox.Show("Email sent");
                }               
            }
        }

        protected bool IsDuplicatedSubmission(string strMembershipID, string strRecipient, int nEdmId, string strEncryptionKey)
        {
            bool rval = false;

            string connectionString = (string)ConfigurationSettings.AppSettings["AmoreMySQLConnStr"];
            MySqlConnection myConn = new MySqlConnection(connectionString);

            if (myConn.State == ConnectionState.Closed)
            {
                myConn.Open();
            }

            try
            {
                string mysql_DuplicateCheck = @"SELECT strRecipient FROM tbledm_logs 
                                            WHERE nEdmId = @p_nEdmId 
                                                    AND strRecipient = @p_strRecipient 
                                                    AND strMembershipID = @p_strMembershipID
                                                    AND strEncryptionKey = @p_strEncryptionKey;";

                MySqlCommand cmd_DuplicateCheck = myConn.CreateCommand();
                cmd_DuplicateCheck.CommandText = mysql_DuplicateCheck;
                cmd_DuplicateCheck.CommandType = CommandType.Text;

                cmd_DuplicateCheck.Parameters.Add(new MySqlParameter("@p_nEdmId", nEdmId));
                cmd_DuplicateCheck.Parameters.Add(new MySqlParameter("@p_strRecipient", strRecipient));
                cmd_DuplicateCheck.Parameters.Add(new MySqlParameter("@p_strMembershipID", strMembershipID));
                cmd_DuplicateCheck.Parameters.Add(new MySqlParameter("@p_strEncryptionKey", strEncryptionKey));

                MySqlDataReader dr_DuplicateCheck = cmd_DuplicateCheck.ExecuteReader();

                if (dr_DuplicateCheck.HasRows)
                {
                    rval = true;

                    //--Response.Write("--> Error : Duplicate Record Found.... <br>");
                }
                dr_DuplicateCheck.Close();

            }
            catch (Exception ex)
            {
                rval = true;

                //--Response.Write(ex.Message);
            }

            myConn.Close();

            return rval;
        }

        protected void InsertEmailSendingLog(string strRecipient, int nEdmId, string strMembershipID, string strMemberName,
                                            string strDate, string strEncryptionKey, string strTargetGroup)
        {
            string connectionString = (string)ConfigurationSettings.AppSettings["AmoreMySQLConnStr"];
            MySqlConnection myConn = new MySqlConnection(connectionString);

            if (myConn.State == ConnectionState.Closed)
            {
                myConn.Open();
            }

            try
            {
                string mysql_InsEmailSendingLog = @"INSERT INTO tbledm_logs (strRecipient, nEdmId, strMembershipID, strMemberName, 
                                                                         strDate, strEncryptionKey, dtConsentExpiry, strTargetGroup, nStatus)
						                                    VALUES (@p_strRecipient, @p_nEdmId, @p_strMembershipID, @p_strMemberName, 
                                                                         @p_strDate, @p_strEncryptionKey, DATE_ADD(NOW(), INTERVAL 1 MONTH), @p_strTargetGroup, 1);";

                MySqlCommand cmd_InsEmailSendingLog = myConn.CreateCommand();
                cmd_InsEmailSendingLog.CommandText = mysql_InsEmailSendingLog;
                cmd_InsEmailSendingLog.CommandType = CommandType.Text;

                cmd_InsEmailSendingLog.Parameters.Add(new MySqlParameter("@p_strRecipient", strRecipient));
                cmd_InsEmailSendingLog.Parameters.Add(new MySqlParameter("@p_nEdmId", nEdmId));
                cmd_InsEmailSendingLog.Parameters.Add(new MySqlParameter("@p_strMembershipID", strMembershipID));
                cmd_InsEmailSendingLog.Parameters.Add(new MySqlParameter("@p_strMemberName", strMemberName));
                cmd_InsEmailSendingLog.Parameters.Add(new MySqlParameter("@p_strDate", strDate));
                cmd_InsEmailSendingLog.Parameters.Add(new MySqlParameter("@p_strEncryptionKey", strEncryptionKey));
                cmd_InsEmailSendingLog.Parameters.Add(new MySqlParameter("@p_strTargetGroup", strTargetGroup));

                cmd_InsEmailSendingLog.ExecuteNonQuery();

                //--Response.Write("--> Inserted Email Log for " + strRecipient + ".... <br>");

            }
            catch (Exception ex)
            {
                //--Response.Write(ex.Message);
            }

            myConn.Close();

        }
        protected bool IsEmailValid(string strEmail)
        {
            bool rval = false;

            Regex emailRegex = new Regex(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$");

            if (emailRegex.IsMatch(strEmail))
            {
                rval = true;
            }

            return rval;
        }
        protected string GetToday()
        {
            string Today = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            return Today;
        }
        protected int GetRandomOrderNo(Random rnd)
        {
            int rval = 0;

            try
            {
                rval = Convert.ToInt32(rnd.Next(10000000).ToString());
            }
            catch { }

            return rval;
        }
        protected bool SendEDM(string strMembershipID, string strMemberName, string dtExpiryDate, string strEmail,
                                string strSender, string strSubject, string strContent, string strEdmId, string strEncryptedKey)
        {
            bool rval = false;

            string edm_local = "";
            string unsub_local = "";
            string edm_script = "index.php?";            
            edm_local = "http://web.amorefitness.com/amorewa/dnc/consentForm.aspx?";
            unsub_local = "http://web.amorefitness.com/amorewa/edm/unsubForm.aspx?";

            try
            {
                SmtpClient mySmtpClient = new SmtpClient("192.168.0.106");

                // set smtp-client with basicAuthentication
                mySmtpClient.UseDefaultCredentials = false;
                System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential("info", "amore!123");
                mySmtpClient.Credentials = basicAuthenticationInfo;

                // add from,to mailaddresses                
                MailAddress from = new MailAddress(strSender, "INFO");
                MailAddress to = new MailAddress(strEmail, strMemberName);
                MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

                // add ReplyTo
                MailAddress replyto = new MailAddress(strSender);
                myMail.ReplyTo = replyto;

                // set subject and encoding
                myMail.Subject = strSubject;
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                // set body-message and encoding                
                string strMailContent = strContent;

                //strMailContent = strMailContent.Replace("\"", "'");
                //strMailContent = strMailContent.Replace("#strMembershipID#", strMembershipID.ToUpper());
                //strMailContent = strMailContent.Replace("#strMemberName#", strMemberName.ToUpper());
                //strMailContent = strMailContent.Replace("#dtExpiryDate#", dtExpiryDate);
                //strMailContent = strMailContent.Replace("#EDM_LOCAL#", edm_local + "id=" + strEdmId + "&ref=" + strEncryptedKey);
                //strMailContent = strMailContent.R.Replace("#UNSUB_LOCAL#", unsub_local + "id=" + strEdmId + "&ref=" + strEncryptedKey);
                //strMailContent = strMailContent.Replace("#EDM_SCRIPT#", edm_script + "id=" + strEdmId + "&ref=" + strEncryptedKey);

                myMail.Body = strMailContent;
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                // text or html
                myMail.IsBodyHtml = true;

                mySmtpClient.Send(myMail);

                rval = true;

            }
            catch (SmtpException ex)
            {
                rval = false;

                throw new ApplicationException
                  ("SmtpException has occured: " + ex.Message);
            }
            catch (Exception ex)
            {
                rval = false;

                throw ex;
            }

            return rval;
        }

        protected string GetEncryptionKey(int nEdmId, string strMembershipID, string strEmail, string strToday)
        {
            string hash = "";

            //string source = "1-4857-stevenkong@amorefitness.com" + Today;
            string source = nEdmId.ToString() + "-" + strMembershipID.Trim() + "-" + strEmail.Trim() + "-" + strToday.Trim();

            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, source);
            }
            return hash;
        }
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }

        // Verify a hash against a string. 
        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input. 
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void frmDNCConsent_Load(object sender, EventArgs e)
        {
           
        }

        private void sbtnSigPad_Click(object sender, EventArgs e)
        {
            DNCDigSignature frmDNCSig = new DNCDigSignature(strMembershipID);
            DialogResult result1 = frmDNCSig.ShowDialog();

            if (result1 == DialogResult.OK)
            {
                strSignatureID = frmDNCSig.ShowSignature();

                if (strSignatureID == null || strSignatureID == "")
                {
                    MessageBox.Show(this, "Member haven't signed on signature pad. ", "Warning");                    
                }
                this.DialogResult = DialogResult.OK;         
                return;
            }
        }

       
	}
}