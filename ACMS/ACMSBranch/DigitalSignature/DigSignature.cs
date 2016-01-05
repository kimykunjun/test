using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ACMSDAL;
using System.Text.RegularExpressions;
using System.IO;

namespace ACMS.ACMSBranch
{
    public partial class DigSignature : Form
    {
        string strSignatureID;
        DataTable dtCreditPackageUsageTable;
        DataTable dtServiceUtilisationTable;
        string[,] drCrPktUsageTable;
        string strTransaction;
        string strKeyData;
        string strDateTime;
        string data, data2;
        Bitmap sign, ok, clear, please;
        double preBalance;
        int lcdX, lcdY,maxScreen, screen, counter;
        uint lcdSize;         
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

        public DigSignature(string strData, string strTrans, string[,] drCrPktUsage, DataTable dtCreditPackageUsage, DataTable dtServiceUtilisation)
        {
            drCrPktUsageTable = drCrPktUsage;
            strTransaction = strTrans;
            maxScreen=0;
            //File.AppendAllText(@"C:\\Test\log.txt", "dtCreditPackageUsage - " + DateTime.Now + Environment.NewLine);
            if (dtCreditPackageUsage != null)
            {
                if (dtCreditPackageUsage.Rows.Count > 0)
                {
                    DataView dvCreditPackageUsage = dtCreditPackageUsage.DefaultView;
                    dvCreditPackageUsage.Sort = "dtPurchaseDate";
                    dtCreditPackageUsageTable = dvCreditPackageUsage.ToTable();
                }                
            }
            //File.AppendAllText(@"C:\\Test\log.txt", "dtServiceUtilisation - " + DateTime.Now + Environment.NewLine);
            if (dtServiceUtilisation != null)
            {
                if (dtServiceUtilisation.Rows.Count > 0)
                {
                    if (dtServiceUtilisation.Columns.Contains("nSessionID"))
                    {
                        DataView dvServiceUtilisation = dtServiceUtilisation.DefaultView;
                        dvServiceUtilisation.Sort = "nSessionID";
                        dtServiceUtilisationTable = dvServiceUtilisation.ToTable();
                    }
                    else
                        dtServiceUtilisationTable = dtServiceUtilisation;
                }
            }
            //File.AppendAllText(@"C:\\Test\log.txt", "InitializeComponent - " + DateTime.Now + Environment.NewLine);
            InitializeComponent(); //35 sec
            sign = global::ACMS.Properties.Resources.Sign;
            ok = global::ACMS.Properties.Resources.OK;
            clear = global::ACMS.Properties.Resources.CLEAR;
            strKeyData = strData;            
        }

        private void DigSignature_Load(object sender, EventArgs e)
        {
            counter = 1;
            Font f = new System.Drawing.Font("Arial", 9.0F, System.Drawing.FontStyle.Regular);
            string[] s;
            s = strKeyData.Split('|');
            switch (strTransaction)
            {
                case "ServiceUtilisation":
                    data = "Dear member " + s[0] + ", please read and confirm the service(s) utilised before sign";
                    if (dtServiceUtilisationTable != null)
                        maxScreen = dtServiceUtilisationTable.Rows.Count;
                    break;
                case "CreditUtilisation":
                    data = "Dear member " + s[0] + ", please read and confirm the credit(s) utilised before sign";
                    if (dtCreditPackageUsageTable != null)
                    {
                        if (dtCreditPackageUsageTable.Rows.Count > 0)
                            maxScreen = dtCreditPackageUsageTable.Rows.Count;
                        else
                        {
                            if (drCrPktUsageTable != null)
                            {
                                if (drCrPktUsageTable.GetLength(0) > 0)
                                    maxScreen = drCrPktUsageTable.GetLength(0);
                            }
                        }
                    }                    
                    else
                    {
                        if (drCrPktUsageTable != null)
                        {
                            if (drCrPktUsageTable.GetLength(0) > 0)
                                maxScreen = drCrPktUsageTable.GetLength(0);
                        }
                    }
                    break;
                case "Redemption":
                    data = "Dear member " + s[2] + ", please read and confirm the redemption(s) details before sign";
                    maxScreen = 1;
                    break;
            }           

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

            screen = 0;
        }

        private void SigPlusNET1_PenUp(object sender, EventArgs e)
        {
            string strSig;
            
            if (SigPlusNET1.KeyPadQueryHotSpot(0) > 0)//If the Continue hotspot is tapped, then...
            {
                if (screen >= 0 && screen<maxScreen)
                {
                    Font f = new System.Drawing.Font("Arial", 9.0F, System.Drawing.FontStyle.Regular);
                    string data2="";
                    string[] words;
                    string writeData, tempData;
                    int xSize, ySize, i, yPos;

                    SigPlusNET1.ClearSigWindow(1);
                    SigPlusNET1.LCDRefresh(1, 16, 45, 50, 15); //Refresh LCD at 'Continue' to indicate to user that this option has been sucessfully chosen
                    SigPlusNET1.ClearTablet();
                    SigPlusNET1.LCDRefresh(0, 0, 0, 240, 64);
                    string[] s;
                    s = strKeyData.Split('|');
                    switch (strTransaction)
                    {
                        case "ServiceUtilisation":
                            if (dtServiceUtilisationTable.Columns.Contains("strDescription"))
                                data2 = dtServiceUtilisationTable.Rows[screen]["strDescription"].ToString() + " Qty: " + dtServiceUtilisationTable.Rows[screen]["Quantity"].ToString() + " Bal: " + dtServiceUtilisationTable.Rows[screen]["nBalance"].ToString();
                            else
                                data2 = dtServiceUtilisationTable.Rows[screen]["PackageDesc"].ToString() + " Qty: " + dtServiceUtilisationTable.Rows[screen]["Quantity"].ToString() + " Bal: " + dtServiceUtilisationTable.Rows[screen]["Balance"].ToString();

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

                            //Hotspot text
                            SigPlusNET1.LCDWriteString(0, 2, 15, 45, f, "Continue");
                            screen++;
                            SigPlusNET1.SetLCDCaptureMode(2);

                            break;                        
                        case "CreditUtilisation":                            
                            if (dtCreditPackageUsageTable != null)
                            {
                                if (dtCreditPackageUsageTable.Rows.Count > 0)
                                {
                                    if (screen==0)
                                        preBalance = Convert.ToDouble(dtCreditPackageUsageTable.Rows[screen]["preBalance"]);
                                    else
                                        preBalance = preBalance - Convert.ToDouble(dtCreditPackageUsageTable.Rows[screen]["mCreditPackageUsagePrice"]);

                                    data2 = dtCreditPackageUsageTable.Rows[screen]["strDescription"].ToString() + " Pre Bal: " + preBalance + " Usage: " + Convert.ToDouble(dtCreditPackageUsageTable.Rows[screen]["mCreditPackageUsagePrice"]) + " After Bal: " + (preBalance - Convert.ToDouble(dtCreditPackageUsageTable.Rows[screen]["mCreditPackageUsagePrice"])).ToString();
                                }
                                else
                                {
                                    if (drCrPktUsageTable != null)
                                    {
                                        if (drCrPktUsageTable.GetLength(0) > 0)
                                        {
                                            if (screen == 0)
                                                preBalance = Convert.ToDouble(s[2].ToString().Replace("#", ""));
                                            else
                                                preBalance = preBalance - Convert.ToDouble(drCrPktUsageTable[screen,1]);

                                            data2 = drCrPktUsageTable[screen, 0].ToString() + " Pre Bal: " + preBalance + " Usage: " + Convert.ToDouble(drCrPktUsageTable[screen, 1]).ToString() + " After Bal: " + (preBalance - Convert.ToDouble(drCrPktUsageTable[screen, 1])).ToString();
                                        }
                                    }                                    
                                }
                            }
                            else
                            {
                                if (drCrPktUsageTable != null)
                                {
                                    if (drCrPktUsageTable.GetLength(0) > 0)
                                    {
                                        if (screen == 0)                                                                                    
                                            preBalance = Convert.ToDouble(Regex.Split(s[2].ToString(), "##")[0]);                                        
                                        else
                                            preBalance = preBalance - Convert.ToDouble(drCrPktUsageTable[screen, 1]);

                                        data2 = drCrPktUsageTable[screen, 0].ToString() + " Pre Bal: " + preBalance + " Usage: " + Convert.ToDouble(drCrPktUsageTable[screen, 1]).ToString() + " After Bal: " + (preBalance - Convert.ToDouble(drCrPktUsageTable[screen, 1])).ToString();
                                    }
                                }
                            }
                            
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

                            //Hotspot text
                            SigPlusNET1.LCDWriteString(0, 2, 15, 45, f, "Continue");
                            screen++;
                            SigPlusNET1.SetLCDCaptureMode(2);
                            break;
                        case "Redemption":                            
                            data2 = s[3] + " Pre Bal: " + (Convert.ToInt32(s[5]) + Convert.ToInt32(s[6])).ToString() + " Point Redempt: " + s[5] + " After Bal: " + s[6];
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

                            //Hotspot text
                            SigPlusNET1.LCDWriteString(0, 2, 15, 45, f, "Continue");
                            screen++;
                            SigPlusNET1.SetLCDCaptureMode(2);
                            break;
                    }

                    SigPlusNET1.SetLCDCaptureMode(2);
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
                    SigPlusNET1.LCDRefresh(0, 0, 0, 240, 64);
                    Font f = new System.Drawing.Font("Arial", 9.0F, System.Drawing.FontStyle.Regular);
                    SigPlusNET1.LCDWriteString(0, 2, 35, 25, f, "No signature captured.");
                    System.Threading.Thread.Sleep(1000);
                    SigPlusNET1.ClearSigWindow(1);
                    SigPlusNET1.LCDRefresh(0, 0, 0, 240, 64);
                    btnPrint_Click(this, e);
                }                
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SigPlusNET1.ClearTablet();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            //SigPlusNET1.SetTabletState(0);
            try
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
            }
            catch { }

            SigPlusNET1.SetTabletState(0);

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public string ShowSignature()
        {
            if (SigPlusNET1.NumberOfTabletPoints() > 0 == false)
                strSignatureID = "";
            return strSignatureID;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //if (SigPlusNET1.NumberOfTabletPoints() > 0)
            //{  
            DialogResult yes = MessageBox.Show(this, "Confirm to print?", "Warning", MessageBoxButtons.YesNo);
            if (yes == DialogResult.Yes)
            {
                SigPlusNET1.ClearSigWindow(1);                
                SigPlusNET1.LCDRefresh(0, 0, 0, 240, 64);

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

                this.DialogResult = DialogResult.OK;
            }
                
            //}
            //else
            //{
            //    MessageBox.Show(this, "Please sign before continue.");
            //}
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            SigPlusNET1.SetTabletState(1);
        }

    }
}
