using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Diagnostics;
using System.Configuration;

namespace updateCheck
{
    public partial class ACMSUpdate : Form
    {
        //private fmProgress m_fmProgress = null;
        public ACMSUpdate()
        {
            //InitializeComponent();
            checksum();
        }

        class ChecksumFile
        {
            public string filename { get; set; }
            public string checksums { get; set; }
            public DateTime lastmodified { get; set;}
            public int filesize { get; set; }
        }

        public void checksum()
        {
            try
            {     
                
                //sourcePath is Server                
                string sourcePath = ConfigurationSettings.AppSettings["ACMSUpdateSourcePath"].ToString();
                
                
                //targetPath is Local
                string targetPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

                int countServer = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories).Length;
                int countLocal = Directory.GetFiles(targetPath, "*.*", SearchOption.AllDirectories).Length;

                string[] filesServer = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories);
                string[] filesLocal = Directory.GetFiles(targetPath, "*.*", SearchOption.AllDirectories);

                Process[] acms = Process.GetProcessesByName("ACMS");
                Process[] updates = Process.GetProcessesByName("updateCheck");

                //BackgroundWorker bw = new BackgroundWorker();
                //bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                //bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

                //m_fmProgress = new fmProgress();
                //bw.RunWorkerAsync();
                //m_fmProgress.ShowDialog(this);
                //m_fmProgress = null;

                //foreach (string a in filesServer)
                //{
                //    MessageBox.Show(Array.Find(filesLocal, s => s.Equals(Path.GetFileName(a))).ToString());
                //    if (results != null)
                //    {
                //        MessageBox.Show(a);
                //    }
                //}
                List<string> filesServerName = new List<string>();
                List<string> filesLocalName = new List<string>();
                List<DateTime> filesServerDate = new List<DateTime>();
                List<DateTime> filesLocalDate = new List<DateTime>();
                List<int> filesServerSize = new List<int>();
                List<int> filesLocalSize = new List<int>();

                foreach (string server in filesServer)
                {
                    filesServerName.Add(Path.GetFileName(server));
                    filesServerDate.Add(File.GetLastWriteTime(server));
                    filesServerSize.Add(Path.GetFileName(server).Length);
                }

                foreach (string local in filesLocal)
                {
                    filesLocalName.Add(Path.GetFileName(local));
                    filesLocalDate.Add(File.GetLastWriteTime(local));
                    filesLocalSize.Add(Path.GetFileName(local).Length);
                }

                foreach (Process app in acms)
                {
                    app.Kill();
                }

                foreach (string local in filesLocal)
                {
                    //server do not have local have, delete local
                    if (!filesServerName.Contains(Path.GetFileName(local)))
                    {                        
                        System.IO.File.Delete(local);
                    }
                }

                foreach (string server in filesServer)
                {
                    string tFile = targetPath + "\\" + Path.GetFileName(server);
                    //local do not have server have, copy server
                    if (!filesLocalName.Contains(Path.GetFileName(server)))
                    {                        
                        System.IO.File.Copy(server, tFile, true);
                    }
                    else
                    {
                        if ((!filesLocalDate.Contains(File.GetLastWriteTime(server))) || (!filesLocalSize.Contains(Path.GetFileName(server).Length)))
                        {                          
                            System.IO.File.Copy(server, tFile, true);
                        }
                    }
                }

                System.Diagnostics.Process.Start(targetPath + "\\ACMS.exe");
                foreach (Process update in updates)
                {
                    update.Kill();
                }
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message);                
            }                        
        }

        //private void bw_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    // Do some long running task...
        //    int iCount = 100;// new Random().Next(20, 50);
        //    for (int i = 0; i < iCount; i++)
        //    {
        //        // The Work to be performed...
        //        Thread.Sleep(100);

        //        m_fmProgress.lblDescription.Invoke(
        //            (MethodInvoker)delegate()
        //            {
        //                m_fmProgress.lblDescription.Text = "Please Wait! Updating files..... " + i.ToString() + "% of " + iCount.ToString() + '%';
        //                m_fmProgress.progressBar1.Value = Convert.ToInt32(i * (100.0 / iCount));
        //            }
        //        );

        //        if (m_fmProgress.Cancel)
        //        {
        //            e.Cancel = true;
        //            return;
        //        }
        //    }
        //}

        //private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    //Hide the Progress Form
        //    if (m_fmProgress != null)
        //    {
        //        m_fmProgress.Hide();
        //        m_fmProgress = null;
        //    }

        //    // Check to see if an error occured in the 
        //    // background process.
        //    if (e.Error != null)
        //    {
        //        MessageBox.Show(e.Error.Message);
        //        return;
        //    }

        //    // Check to see if the background process was cancelled.
        //    if (e.Cancelled)
        //    {
        //        MessageBox.Show("Updating cancelled.");
        //        return;
        //    }

        //    // Everything completed normally.
        //    // process the response using e.Result
        //    //   MessageBox.Show("Processing is complete.");
        //}
    }
}

