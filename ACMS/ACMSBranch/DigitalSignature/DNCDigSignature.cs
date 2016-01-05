using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ACMSDAL;
using System.Text.RegularExpressions;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ACMS.ACMSBranch
{
    public partial class DNCDigSignature : Form
    {
       private string connectionString;
       private SqlConnection connection;
       string strSignatureID;
       bool fDNC;
       Bitmap sign, ok, clear, please, yes, no;
       string data, data2, strMembershipID;
       int lcdX, lcdY, maxScreen, screen, counter;
       uint lcdSize;
       string strKeyData;
       string strDateTime;
       private Topaz.SigPlusNET SigPlusNET1;
       internal Button btnClear;
       private TextBox txtImageBinary;
       internal Button btnCancel;
       internal Button btnPrint;
       private const int CP_NOCLOSE_BUTTON = 0x200;
       protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public DNCDigSignature(string sMembershipID)
        {           
            InitializeComponent();
            sign = global::ACMS.Properties.Resources.Sign;
            ok = global::ACMS.Properties.Resources.OK;
            clear = global::ACMS.Properties.Resources.CLEAR;
            yes = global::ACMS.Properties.Resources.Sign;
            no = global::ACMS.Properties.Resources.OK;

            strKeyData = sMembershipID;
            strMembershipID = sMembershipID;
            connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"];
            connection = new SqlConnection(connectionString);
        }

        public string ShowSignature()
        {
            if (SigPlusNET1.NumberOfTabletPoints() > 0 == false)
                strSignatureID = "";
            return strSignatureID;
        }

        private void DNCDigSignature_Load(object sender, EventArgs e)
        {
            counter = 1;
            
            data = "Dear member " + strMembershipID + ", due to Do Not Call Registry (DNC), your consent is needed for future telemarketing purposes.";
            
            Font f = new System.Drawing.Font("Arial", 9.0F, System.Drawing.FontStyle.Regular);
            
            SigPlusNET1.SetTabletState(1);
            SigPlusNET1.SetImagePenWidth(8);
            SigPlusNET1.SetDisplayPenWidth(8);
            SigPlusNET1.LCDRefresh(0, 0, 0, 240, 64);
            SigPlusNET1.SetTranslateBitmapEnable(false);

            //Images sent to the background
            SigPlusNET1.LCDSendGraphic(1, 2, 0, 20, sign);
            SigPlusNET1.LCDSendGraphic(1, 2, 207, 4, ok);
            SigPlusNET1.LCDSendGraphic(1, 2, 15, 4, clear);
            
            //Get LCD size in pixels.
            lcdSize = SigPlusNET1.LCDGetLCDSize();
            lcdX = (int)(lcdSize & 0xFFFF);
            lcdY = (int)((lcdSize >> 16) & 0xFFFF);

            string[] words = data.Split(new char[] { ' ' });
            string writeData = "", tempData = "";

            int xSize, ySize, i, yPos = 0;

            for (i = 0; i < words.Length; i++)
            {
                tempData += words[i];

                xSize = SigPlusNET1.LCDStringWidth(f, tempData);

                if (xSize < lcdX)
                {
                    writeData = tempData;
                    tempData += " ";

                    xSize = SigPlusNET1.LCDStringWidth(f, tempData);

                    if (xSize < lcdX)
                    {
                        writeData = tempData;
                    }
                }
                else
                {
                    ySize = SigPlusNET1.LCDStringHeight(f, tempData);

                    SigPlusNET1.LCDWriteString(0, 2, 0, yPos, f, writeData);

                    tempData = "";
                    writeData = "";
                    yPos += (short)ySize;
                    i--;
                }
            }

            if (writeData != "")
            {
                SigPlusNET1.LCDWriteString(0, 2, 0, yPos, f, writeData);
            }

            //Hotspot text
            SigPlusNET1.LCDWriteString(0, 2, 15, 45, f, "Continue");

            //Create the hot spots for the Continue button
            SigPlusNET1.KeyPadAddHotSpot(0, 1, 12, 40, 40, 15); //For Continue button
            
            SigPlusNET1.ClearTablet();

            SigPlusNET1.LCDSetWindow(0, 0, 1, 1);
            SigPlusNET1.SetSigWindow(1, 0, 0, 1, 1); //Sets the area where ink is permitted in the SigPlus object
            SigPlusNET1.SetLCDCaptureMode(2);   //Sets mode so ink will not disappear after a few seconds
            maxScreen = 2;
            screen = 0;
        }

        private void SigPlusNET1_PenUp(object sender, EventArgs e)
        {
            string strSig;

            if (SigPlusNET1.KeyPadQueryHotSpot(0) > 0)//If the Continue hotspot is tapped, then...
            {
                if (screen == 0)
                {
                    Font f = new System.Drawing.Font("Arial", 9.0F, System.Drawing.FontStyle.Regular);
                    string data2 = "";
                    string[] words;
                    string writeData, tempData;
                    int xSize, ySize, i, yPos;

                    SigPlusNET1.ClearSigWindow(1);
                    SigPlusNET1.LCDRefresh(1, 16, 45, 50, 15); //Refresh LCD at 'Continue' to indicate to user that this option has been sucessfully chosen
                    SigPlusNET1.ClearTablet();
                    SigPlusNET1.LCDRefresh(0, 0, 0, 240, 64);

                    data2 = "Are you DNC Registrant?";

                    words = data2.Split(new char[] { ' ' });
                    writeData = "";
                    tempData = "";

                    xSize = 0; ySize = 0; i = 0; yPos = 0;

                    for (i = 0; i < words.Length; i++)
                    {
                        tempData += words[i];

                        xSize = SigPlusNET1.LCDStringWidth(f, tempData);

                        if (xSize < lcdX)
                        {
                            writeData = tempData;
                            tempData += " ";

                            xSize = SigPlusNET1.LCDStringWidth(f, tempData);

                            if (xSize < lcdX)
                            {
                                writeData = tempData;
                            }
                        }
                        else
                        {
                            ySize = SigPlusNET1.LCDStringHeight(f, tempData);

                            SigPlusNET1.LCDWriteString(0, 2, 0, yPos, f, writeData);

                            tempData = "";
                            writeData = "";
                            yPos += (short)ySize;
                            i--;
                        }
                    }

                    if (writeData != "")
                    {
                        SigPlusNET1.LCDWriteString(0, 2, 0, yPos, f, writeData);
                    }
                                        
                    SigPlusNET1.KeyPadClearHotSpotList();
                    //Hotspot text
                    SigPlusNET1.LCDWriteString(0, 2, 75, 25, f, "Yes");
                    SigPlusNET1.LCDWriteString(0, 2, 145, 25, f, "No");

                    SigPlusNET1.KeyPadAddHotSpot(4, 1, 70, 20, 22, 15); //For Yes button
                    SigPlusNET1.KeyPadAddHotSpot(5, 1, 140, 20, 20, 15); //For No button
                    SigPlusNET1.ClearTablet();

                    SigPlusNET1.LCDSetWindow(0, 0, 1, 1);
                    SigPlusNET1.SetSigWindow(1, 0, 0, 1, 1); //Sets the area where ink is permitted in the SigPlus object
                    SigPlusNET1.SetLCDCaptureMode(2);   //Sets mode so ink will not disappear after a few seconds
                    screen++;                    
                }                
                else
                {
                    SigPlusNET1.ClearSigWindow(1);
                    SigPlusNET1.LCDRefresh(1, 16, 45, 50, 15); //Refresh LCD at 'Continue' to indicate to user that this option has been sucessfully chosen
                    SigPlusNET1.LCDRefresh(2, 0, 0, 240, 64); //Brings the background image already loaded into foreground
                    SigPlusNET1.ClearTablet();
                    SigPlusNET1.KeyPadClearHotSpotList();
                    SigPlusNET1.KeyPadAddHotSpot(2, 1, 10, 5, 53, 17); //For CLEAR button
                    SigPlusNET1.KeyPadAddHotSpot(3, 1, 197, 5, 19, 17); //For OK button
                    SigPlusNET1.LCDSetWindow(2, 22, 236, 40);
                    SigPlusNET1.SetSigWindow(1, 0, 22, 240, 40); //Sets the area where ink is permitted in the SigPlus object
                }
            }
            else if (SigPlusNET1.KeyPadQueryHotSpot(2) > 0) //If the CLEAR hotspot is tapped, then...
            {
                SigPlusNET1.ClearSigWindow(1);
                SigPlusNET1.LCDRefresh(1, 10, 0, 53, 17); //Refresh LCD at 'CLEAR' to indicate to user that this option has been sucessfully chosen
                SigPlusNET1.LCDRefresh(2, 0, 0, 240, 64); //Brings the background image already loaded into foreground
                SigPlusNET1.ClearTablet();
            }
            else if (SigPlusNET1.KeyPadQueryHotSpot(3) > 0) //If the OK hotspot is tapped, then...
            {
                if (SigPlusNET1.NumberOfTabletPoints() > 0)
                {
                    strKeyData += "|By signing on this signature pad, you are giving us consent to call/sms you.";
                    SigPlusNET1.LCDRefresh(0, 0, 0, 240, 64);
                    Font f = new System.Drawing.Font("Arial", 9.0F, System.Drawing.FontStyle.Regular);
                    SigPlusNET1.LCDWriteString(0, 2, 35, 25, f, "Signature capture complete.\nThank you!");
                    System.Threading.Thread.Sleep(1000);
                    SigPlusNET1.ClearSigWindow(1);
                    SigPlusNET1.LCDRefresh(0, 0, 0, 240, 64);
                    btnPrint_Click(this, e);
                }
                else
                {                    
                    SqlHelper.ExecuteNonQuery(connection, "sp_DNCMemberSubscriptionUpdateWithLogs",
                    new SqlParameter("@strMembershipID", strMembershipID),
                    new SqlParameter("@fPhoneCall", false),
                    new SqlParameter("@fSMS", false),
                    new SqlParameter("@fEmail", true),
                    new SqlParameter("@fPostalMail", true),
                    new SqlParameter("@fDNC", fDNC),
                    new SqlParameter("@nTypeID", 5)
                    );
                 
                    SigPlusNET1.LCDRefresh(0, 0, 0, 240, 64);
                    Font f = new System.Drawing.Font("Arial", 9.0F, System.Drawing.FontStyle.Regular);
                    SigPlusNET1.LCDWriteString(0, 2, 35, 25, f, "No signature captured.");
                    System.Threading.Thread.Sleep(1000);
                    SigPlusNET1.ClearSigWindow(1);
                    SigPlusNET1.LCDRefresh(0, 0, 0, 240, 64);
                    this.DialogResult = DialogResult.OK;         
                    //btnPrint_Click(this, e);
                }
            }
            else if (SigPlusNET1.KeyPadQueryHotSpot(4) > 0) //If the Yes hotspot is tapped, then...
            {
                SigPlusNET1.ClearSigWindow(1);
                SigPlusNET1.LCDRefresh(1, 74, 25, 25, 15); //Refresh LCD at 'Yes' to indicate to user that this option has been sucessfully chosen
                fDNC = true;
                strKeyData = strKeyData + "|DNC:Y";                              
                Font f = new System.Drawing.Font("Arial", 9.0F, System.Drawing.FontStyle.Regular);
                string data3 = "";
                string[] words;
                string writeData, tempData;
                int xSize, ySize, i, yPos;

                SigPlusNET1.ClearSigWindow(1);
                
                SigPlusNET1.ClearTablet();
                SigPlusNET1.LCDRefresh(0, 0, 0, 240, 64);

                data3 = "By signing on this signature pad, you are giving us consent to call/sms you.";

                words = data3.Split(new char[] { ' ' });
                writeData = "";
                tempData = "";

                xSize = 0; ySize = 0; i = 0; yPos = 0;

                for (i = 0; i < words.Length; i++)
                {
                    tempData += words[i];

                    xSize = SigPlusNET1.LCDStringWidth(f, tempData);

                    if (xSize < lcdX)
                    {
                        writeData = tempData;
                        tempData += " ";

                        xSize = SigPlusNET1.LCDStringWidth(f, tempData);

                        if (xSize < lcdX)
                        {
                            writeData = tempData;
                        }
                    }
                    else
                    {
                        ySize = SigPlusNET1.LCDStringHeight(f, tempData);

                        SigPlusNET1.LCDWriteString(0, 2, 0, yPos, f, writeData);

                        tempData = "";
                        writeData = "";
                        yPos += (short)ySize;
                        i--;
                    }
                }

                if (writeData != "")
                {
                    SigPlusNET1.LCDWriteString(0, 2, 0, yPos, f, writeData);
                }

                SigPlusNET1.KeyPadClearHotSpotList();
                //Hotspot text
                SigPlusNET1.LCDWriteString(0, 2, 15, 45, f, "Continue");
                SigPlusNET1.KeyPadAddHotSpot(0, 1, 12, 40, 40, 15); //For Continue button
                
                screen++;
                SigPlusNET1.SetLCDCaptureMode(2);                                           
                
            }
            else if (SigPlusNET1.KeyPadQueryHotSpot(5) > 0) //If the No hotspot is tapped, then...
            {
                SigPlusNET1.ClearSigWindow(1);
                SigPlusNET1.LCDRefresh(1, 144, 25, 23, 15); //Refresh LCD at 'No' to indicate to user that this option has been sucessfully chosen
                fDNC = false;
                strKeyData = strKeyData + "|DNC:N";
                Font f = new System.Drawing.Font("Arial", 9.0F, System.Drawing.FontStyle.Regular);
                string data3 = "";
                string[] words;
                string writeData, tempData;
                int xSize, ySize, i, yPos;

                SigPlusNET1.ClearSigWindow(1);

                SigPlusNET1.ClearTablet();
                SigPlusNET1.LCDRefresh(0, 0, 0, 240, 64);

                data3 = "By signing on this signature pad, you are giving us consent to call/sms you.";

                words = data3.Split(new char[] { ' ' });
                writeData = "";
                tempData = "";

                xSize = 0; ySize = 0; i = 0; yPos = 0;

                for (i = 0; i < words.Length; i++)
                {
                    tempData += words[i];

                    xSize = SigPlusNET1.LCDStringWidth(f, tempData);

                    if (xSize < lcdX)
                    {
                        writeData = tempData;
                        tempData += " ";

                        xSize = SigPlusNET1.LCDStringWidth(f, tempData);

                        if (xSize < lcdX)
                        {
                            writeData = tempData;
                        }
                    }
                    else
                    {
                        ySize = SigPlusNET1.LCDStringHeight(f, tempData);

                        SigPlusNET1.LCDWriteString(0, 2, 0, yPos, f, writeData);

                        tempData = "";
                        writeData = "";
                        yPos += (short)ySize;
                        i--;
                    }
                }

                if (writeData != "")
                {
                    SigPlusNET1.LCDWriteString(0, 2, 0, yPos, f, writeData);
                }

                SigPlusNET1.KeyPadClearHotSpotList();
                //Hotspot text
                SigPlusNET1.LCDWriteString(0, 2, 15, 45, f, "Continue");
                SigPlusNET1.KeyPadAddHotSpot(0, 1, 12, 40, 40, 15); //For Continue button

                screen++;
                SigPlusNET1.SetLCDCaptureMode(2);                                           
                
            }
        }

        private void InitializeComponent()
        {
            this.SigPlusNET1 = new Topaz.SigPlusNET();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtImageBinary = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SigPlusNET1
            // 
            this.SigPlusNET1.BackColor = System.Drawing.Color.White;
            this.SigPlusNET1.ForeColor = System.Drawing.Color.Black;
            this.SigPlusNET1.Location = new System.Drawing.Point(27, 12);
            this.SigPlusNET1.Name = "SigPlusNET1";
            this.SigPlusNET1.Size = new System.Drawing.Size(320, 136);
            this.SigPlusNET1.TabIndex = 0;
            this.SigPlusNET1.Text = "SigPlusNET1";
            this.SigPlusNET1.PenUp += new System.EventHandler(this.SigPlusNET1_PenUp);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(127, 151);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(86, 37);
            this.btnClear.TabIndex = 40;
            this.btnClear.Text = "C L E A R";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtImageBinary
            // 
            this.txtImageBinary.Location = new System.Drawing.Point(330, 7);
            this.txtImageBinary.Name = "txtImageBinary";
            this.txtImageBinary.Size = new System.Drawing.Size(74, 20);
            this.txtImageBinary.TabIndex = 42;
            this.txtImageBinary.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(213, 151);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 37);
            this.btnCancel.TabIndex = 39;
            this.btnCancel.Text = "C A N C E L";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(40, 151);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(86, 37);
            this.btnPrint.TabIndex = 43;
            this.btnPrint.Text = "S A V E";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // DNCDigSignature
            // 
            this.ClientSize = new System.Drawing.Size(364, 195);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtImageBinary);
            this.Controls.Add(this.SigPlusNET1);
            this.Name = "DNCDigSignature";
            this.ResumeLayout(false);
            this.PerformLayout();

            this.Load += new System.EventHandler(this.DNCDigSignature_Load);
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            SigPlusNET1.ClearTablet();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            SigPlusNET1.ClearSigWindow(1);
            SigPlusNET1.LCDRefresh(0, 0, 0, 240, 64);
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {            
            SigPlusNET1.ClearSigWindow(1);

            strDateTime = DateTime.Now.ToString("dd/MM/yyyy  hh:mm tt");
            SigPlusNET1.SetTimeStamp(strDateTime);
            SigPlusNET1.SetSaveSigInfo(true);

            SigPlusNET1.SetSigCompressionMode(1);
            SigPlusNET1.AutoKeyStart();
            SigPlusNET1.SetAutoKeyData(strKeyData);
            SigPlusNET1.AutoKeyFinish();
            SigPlusNET1.SetEncryptionMode(2);

            txtImageBinary.Text = SigPlusNET1.GetSigString();
            strSignatureID = txtImageBinary.Text;
            SigPlusNET1.SetTabletState(0);

            string strSQL = "Update tblMember Set strDNCConsentSignatureID='" + strSignatureID + "',strDNCConsentSigKey='" + strKeyData + "' where strMembershipID='" + strMembershipID +"'";
            DataSet _ds;
            _ds = new DataSet();
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "UP_GETDATA", _ds, new string[] { "table" }, new SqlParameter("@strSQL", strSQL));

            SqlHelper.ExecuteNonQuery(connection, "sp_DNCMemberSubscriptionUpdateWithLogs",
                new SqlParameter("@strMembershipID", strMembershipID),
                new SqlParameter("@fPhoneCall", true),
                new SqlParameter("@fSMS", true),
                new SqlParameter("@fEmail", true),
                new SqlParameter("@fPostalMail", true),
                new SqlParameter("@fDNC", fDNC),
                new SqlParameter("@nTypeID", 5)
                );
            
            MessageBox.Show("DNC Consent successfully saved", "Save");

            this.DialogResult = DialogResult.OK;         
        }
    }
}
