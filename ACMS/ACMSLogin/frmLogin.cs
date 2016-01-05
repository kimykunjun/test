using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using ACMSLogic;
using ACMSDAL;
using System.Data.SqlClient;
//using System.Data.OleDb;

//TODO:Irwan
//using Rp = Acms.Core.Repository;
//using Fc = Acms.Core.Factory;
using Do = Acms.Core.Domain;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Reflection;
using System.Configuration;
using System.Threading;
//using log4net;

namespace ACMS
{
	
	public class frmLogin : System.Windows.Forms.Form
	{
        private string connectionString;
        private SqlConnection connection;
        private bool isRequiredUpdate;
        internal DevExpress.XtraEditors.SimpleButton btnLogin;
        private ComboBox cb_Branch;
        private ComboBox cb_Terminal;
        internal DevExpress.XtraEditors.SimpleButton btn_Update;
        internal Label label3;
        private ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        internal Label label5;
		private bool isFinishInitialize;
		[STAThread]
		static void Main()
        {
            //log4net.Config.XmlConfigurator.Configure();
			Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
			Application.EnableVisualStyles();
			Application.DoEvents();
			Application.Run(new frmLogin());
		}
		
		#region " Windows Form Designer generated code "

        private int counter = 15;

		public frmLogin() 
		{
			//This call is required by the Windows Form Designer.
            InitializeComponent();

            MethodInvoker myProcessStarter = new MethodInvoker(InitialDigSignature);

            myProcessStarter.BeginInvoke(null, null);

            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // 1 second
            timer1.Start();
		}

        private void timer1_Tick(object sender, EventArgs e)
        {
            //progressBar1.Increment(+1);
            counter--;
            if (counter == 0)
            {
                timer1.Stop();
            }
        }

        public void ProgressBar()
        {
            int iPercentage = 100;
            progressBar1.Visible = true;
            //Set the total number of steps to 100 (or 100%)
            progressBar1.Maximum = 100;
            //Set the initial value of the progress bar to 0% completed
            progressBar1.Value = 0;
            //If your progress bar is already visible you don't need this. But this is one of those objects I like to hide when I'm not using it
            progressBar1.Visible = true;
            for (int i = 0; i < counter; i++)
            {
                iPercentage = 100 / counter;
                System.Threading.Thread.Sleep(1000);
                progressBar1.Value += iPercentage;
            }
            progressBar1.Visible = false;
        }
		
		//Form overrides dispose to clean up the component list.
		protected override void Dispose (bool disposing)
		{
			if (disposing)
			{
				if (!(components == null))
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

        private IContainer components;

        //Required by the Windows Form Designer
		
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label41;
        internal System.Windows.Forms.Label Label2;
		internal DevExpress.XtraEditors.SimpleButton btnCancel;
        internal DevExpress.XtraEditors.TextEdit txtUsername;
		internal System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.ComboBoxEdit cmbLanguage;
        private CheckBox cbRoadShow;
		internal DevExpress.XtraEditors.TextEdit txtPassword;
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent ()
		{
            this.components = new System.ComponentModel.Container();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label41 = new System.Windows.Forms.Label();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbLanguage = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbRoadShow = new System.Windows.Forms.CheckBox();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.cb_Branch = new System.Windows.Forms.ComboBox();
            this.cb_Terminal = new System.Windows.Forms.ComboBox();
            this.btn_Update = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLanguage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Navy;
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Label1.Location = new System.Drawing.Point(0, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(426, 50);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "LOGIN";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // Label41
            // 
            this.Label41.AutoSize = true;
            this.Label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label41.Location = new System.Drawing.Point(83, 81);
            this.Label41.Name = "Label41";
            this.Label41.Size = new System.Drawing.Size(97, 16);
            this.Label41.TabIndex = 7;
            this.Label41.Text = "Employee ID";
            // 
            // txtUsername
            // 
            this.txtUsername.EditValue = "";
            this.txtUsername.Location = new System.Drawing.Point(192, 78);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Properties.Appearance.Options.UseFont = true;
            this.txtUsername.Size = new System.Drawing.Size(152, 22);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsername_KeyDown);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(104, 108);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(76, 16);
            this.Label2.TabIndex = 10;
            this.Label2.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.EditValue = "";
            this.txtPassword.Location = new System.Drawing.Point(192, 105);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(152, 22);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(272, 163);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 20);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(339, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 14;
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.EditValue = "EN";
            this.cmbLanguage.Location = new System.Drawing.Point(77, 163);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbLanguage.Properties.Items.AddRange(new object[] {
            "EN",
            "CN"});
            this.cmbLanguage.Size = new System.Drawing.Size(100, 20);
            this.cmbLanguage.TabIndex = 15;
            // 
            // cbRoadShow
            // 
            this.cbRoadShow.AutoSize = true;
            this.cbRoadShow.Location = new System.Drawing.Point(132, 189);
            this.cbRoadShow.Name = "cbRoadShow";
            this.cbRoadShow.Size = new System.Drawing.Size(88, 17);
            this.cbRoadShow.TabIndex = 16;
            this.cbRoadShow.Text = "Road Show?";
            this.cbRoadShow.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLogin.Appearance.Options.UseFont = true;
            this.btnLogin.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnLogin.Location = new System.Drawing.Point(192, 163);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(72, 20);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // cb_Branch
            // 
            this.cb_Branch.FormattingEnabled = true;
            this.cb_Branch.Location = new System.Drawing.Point(192, 133);
            this.cb_Branch.Name = "cb_Branch";
            this.cb_Branch.Size = new System.Drawing.Size(45, 21);
            this.cb_Branch.TabIndex = 30;
            this.cb_Branch.Visible = false;
            // 
            // cb_Terminal
            // 
            this.cb_Terminal.FormattingEnabled = true;
            this.cb_Terminal.Items.AddRange(new object[] {
            "1",
            "2",
            "4"});
            this.cb_Terminal.Location = new System.Drawing.Point(243, 133);
            this.cb_Terminal.Name = "cb_Terminal";
            this.cb_Terminal.Size = new System.Drawing.Size(44, 21);
            this.cb_Terminal.TabIndex = 29;
            this.cb_Terminal.Visible = false;
            // 
            // btn_Update
            // 
            this.btn_Update.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_Update.Appearance.Options.UseFont = true;
            this.btn_Update.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btn_Update.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Update.Location = new System.Drawing.Point(291, 133);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(51, 20);
            this.btn_Update.TabIndex = 28;
            this.btn_Update.Text = "Update";
            this.btn_Update.Visible = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(58, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "Branch/Terminal";
            this.label3.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Blue;
            this.progressBar1.Location = new System.Drawing.Point(-2, 213);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(428, 23);
            this.progressBar1.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(325, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Ver = 2016.01.05";
            // 
            // frmLogin
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(426, 234);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.cb_Branch);
            this.Controls.Add(this.cb_Terminal);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbRoadShow);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label41);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACMS Login";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.Activated += new System.EventHandler(this.frmLogin_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLanguage.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		
		#endregion

        class ChecksumFile
        {
            public string filename { get; set; }
            public string checksums { get; set; }
        }

        public void checksum()
        {
            isRequiredUpdate = false;
            //sourcePath is Server
            string sourcePath = ConfigurationSettings.AppSettings["ACMSUpdateSourcePath"];
            //targetPath is Local
            string targetPath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);

            string update = targetPath + "\\updateCheck.exe";
            
            int countServer = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories).Length;
            int countLocal = Directory.GetFiles(targetPath, "*.*", SearchOption.AllDirectories).Length;

            string[] filesServer = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories);
            string[] filesLocal = Directory.GetFiles(targetPath, "*.*", SearchOption.AllDirectories);

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

            foreach (string local in filesLocal)
            {
                //server do not have local have, delete local
                if (!filesServerName.Contains(Path.GetFileName(local)))
                {
                    //MessageBox.Show("1 " + local);
                    isRequiredUpdate = true;
                    break;
                }
            }

            foreach (string server in filesServer)
            {
                string tFile = targetPath + "\\" + Path.GetFileName(server);
                //local do not have server have, copy server
                if (!filesLocalName.Contains(Path.GetFileName(server)))
                {
                    //MessageBox.Show("2 " + server);
                    isRequiredUpdate = true;
                    break;
                }
                else
                {
                    if ((!filesLocalDate.Contains(File.GetLastWriteTime(server))) || (!filesLocalSize.Contains(Path.GetFileName(server).Length)))
                    {
                        //MessageBox.Show("3 " + server);
                        isRequiredUpdate = true;
                        break;
                    }
                }
            }

            if (isRequiredUpdate == true)
            {
                MessageBox.Show("Latest Version Detected. Restarting ACMS...");
                //this.isFinishInitialize = false;
                System.Diagnostics.Process.Start(update);
            }
        }        

		private void frmLogin_Load (object sender, System.EventArgs e)
		{
            System.Security.Principal.WindowsIdentity userLogin = System.Security.Principal.WindowsIdentity.GetCurrent();
            string strTerminalUser = ConfigurationSettings.AppSettings["TerminalUser"].ToUpper();
            string[] aStrTerminalUser = new string[50];

            if (strTerminalUser.Contains(","))
                aStrTerminalUser = strTerminalUser.Split(',');
            else
                aStrTerminalUser[0] = strTerminalUser;

            for (int i = 0; i < aStrTerminalUser.Length; i++)
            {
                if (userLogin.Name.ToUpper() == aStrTerminalUser[i].ToString())
                {
                    label3.Visible = true;
                    cb_Branch.Visible = true;
                    cb_Terminal.Visible = true;
                    btn_Update.Visible = true;
                    //show terminal branch update
                    break;
                }
            }

			//Init form
            cbRoadShow.Visible = false;
			modInitForms.fLogin = this;
            BranchTerminal();
		}
		
		public void loginCallFromBranch()
		{
			btnLogin_Click(null,new EventArgs());
		}
		
		public void ClearLoginText()
		{
			this.txtUsername.Text="";
			this.txtPassword.Text="";
			this.isFinishInitialize = false;
		}

        public void InitialDigSignature()
        {
            ACMS.ACMSBranch.DigSignature frmSig = new ACMS.ACMSBranch.DigSignature("", "", null, null, null);
        }        

		private void btnLogin_Click (System.Object sender, System.EventArgs e)
        {
            /*
            MethodInvoker myProcessStarter = new MethodInvoker(InitialDigSignature);

            myProcessStarter.BeginInvoke(null, null);
            */

			if(this.txtUsername.Text=="" | this.txtPassword.Text=="")
			{
				ACMS.Utils.UI.ShowErrorMessage(this,"Empty Username & Password!","Error");
                progressBar1.Value = 0;
			}
			else
			{
                try
                {
                    ProgressBar();

                    ACMSLogic.Login.Login login = new ACMSLogic.Login.Login();
                    //Do.Employee emplogin = login.GetEmployeeByIdAndPassword(this.txtUsername.Text, this.txtPassword.Text);

                    //MessageBox.Show(this, emplogin.Id.ToString()+" "+emplogin.Department.Id+" "+emplogin.RightsLevel.RightsLevelEntrys.Count.ToString());

                    //Rp.EmployeeRepository er = new Rp.EmployeeRepository();
                    Do.Employee emp = login.GetEmployeeByIdAndPassword(this.txtUsername.Text, this.txtPassword.Text);//er.GetEmployeeByIdAndPassword(this.txtUsername.Text, this.txtPassword.Text);

                    System.Security.Principal.WindowsIdentity userLogin = System.Security.Principal.WindowsIdentity.GetCurrent();
                    //System.Security.Principal.WindowsIdentity userLogin = "AFPL\EdithGan";

                    if (login.Check_Concurrent() == false)
                    {
                        ACMS.Utils.UI.ShowErrorMessage(this, "Number of Login Exceed Users Limit!", "Authorisation");

                    }
                    else
                    {
                        //Rp.TerminalUserRepository tup = new Rp.TerminalUserRepository();
                        if (emp != null)
                        {
                            //userLogin.Name="AFPL\EdithGan";

                            //Rev 6.8.0.0 Determine whether is RoadShow or Terminal. Add in 2 config - RoadShow & RoadShowTerminal
                            Acms.Core.Domain.TerminalUser tu = new Acms.Core.Domain.TerminalUser();
                            if (ConfigurationSettings.AppSettings["RoadShow"].ToString() == "1")
                            {
                                tu = login.GetTerminalUserByUserId(ConfigurationSettings.AppSettings["RoadShowTerminal"].ToString()) as Acms.Core.Domain.TerminalUser;
                                ACMSLogic.User.RoadShow = "RS";//jackie 13032012
                            }
                            else
                            {
                                tu = login.GetTerminalUserByUserId(userLogin.Name) as Acms.Core.Domain.TerminalUser;
                                ACMSLogic.User.RoadShow = tu.Branch.Id;
                            }

                            //Acms.Core.Domain.TerminalUser tu = login.GetTerminalUserByUserId("AFPL\\TO-Terminal1") as Acms.Core.Domain.TerminalUser;
                            //Acms.Core.Domain.TerminalUser tu = login.GetTerminalUserByUserId("AFPL\\TO-Terminal2") as Acms.Core.Domain.TerminalUser;

                            //Show AMCS Branch
                            bool Valid = numberUser();
                            //bool Valid = true;
                            if (emp.CanAccess("AB_LOGIN", tu.Branch.Id) && Valid)
                            {
                                //smell tandas code
                                ACMSDAL.TblTerminalUser UserLog = new TblTerminalUser();
                                UserLog.StrTerminalUserCode = userLogin.Name;
                                UserLog.UpdateSession(true, DateTime.Now);

                                modInitForms.fLogin.Hide();
                                ACMSLogic.User.BranchCode = tu.Branch.Id;
                                ACMSLogic.User.EmployeeID = emp.Id;
                                /*
                                //cbRoadShow.Checked = true;
                                if (cbRoadShow.Checked)
                                {
                                    ACMSLogic.User.RoadShow = "RS";//jackie 13032012
                                }
                                else
                                    ACMSLogic.User.RoadShow = tu.Branch.Id;*/

                                if (emp.Department != null)
                                    ACMSLogic.User.DepartmentID = emp.Department.Id;
                                if (emp.StrEmployeeName != null)
                                    ACMSLogic.User.EmployeeName = emp.StrEmployeeName;
                                if (emp.JobPosition.Id != null)
                                    ACMSLogic.User.JobPositionCode = emp.JobPosition.Id;
                                if (emp.RightsLevel != null)
                                    ACMSLogic.User.RightsLevelID = emp.RightsLevel.Id;

                                try
                                {
                                    //ClassAttendance.CreateClassInstance();
                                    //PackageCode.CreateUnLinkPackage();
                                }
                                catch (Exception ex)
                                {
                                    return;
                                }
                                ACMSLogic.User oUser = new User();

                                if (modInitForms.fBranch != null)
                                {
                                    modInitForms.fBranch.IsLogin = true;
                                    modInitForms.fBranch.Close();
                                    modInitForms.fBranch.Dispose();
                                    if (modInitForms.fStaff != null)
                                    {
                                        modInitForms.fStaff.Close();
                                        modInitForms.fStaff.Dispose();
                                    }
                                    if (modInitForms.fManager != null)
                                    {
                                        modInitForms.fManager.Close();
                                        modInitForms.fManager.Dispose();
                                    }
                                }

                                Thread.Sleep(1000);
                                modInitForms.fBranch = new frmBranch(cmbLanguage.EditValue.ToString());
                                modInitForms.fBranch.SetEmployeeRecord(emp);
                                modInitForms.fBranch.SetTerminalUser(tu);
                                modInitForms.fBranch.OpenDayShift();

                                //						if (UnclosedShift == true)
                                //							MessageBox.Show("There is unclosed shift. Please close the shift.");

                                modInitForms.fBranch.initData(oUser);
                                modInitForms.fBranch.Show();

                                //DateTime end = DateTime.Now;
                                //TimeSpan diff = end.Subtract(start);
                                //MessageBox.Show(diff.TotalSeconds.ToString(),"Time");

                            }
                            else if (emp.CanAccess("AB_TIMECARD_LOGIN", tu.Branch.Id))
                            {
                                modInitForms.fLogin.Hide();
                                //Show AMCS Time Card
                                if (modInitForms.fTimeCard == null)
                                {
                                    modInitForms.fTimeCard = new frmTimeCard(tu.Branch.Id);
                                    modInitForms.fTimeCard.Show();
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "Invalid username and password or you don't have access to this Branch, please try again");
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "Invalid username and password, Please try again");
                        }
                    }
                }
                catch (Exception ex)
                {
                    return;
                }
		    }
		}  
	
		private void btnCancel_Click (System.Object sender, System.EventArgs e)
		{
			//Close only if Branch Form nothing
			if (modInitForms.fBranch == null)
			{
				//Terminate Application
				Application.Exit();
			}
			else
			{
				this.Hide();
			}
		}

		public bool numberUser()
		{
			bool status = false;
			DataTable NumUser = new DataTable();
			ACMSDAL.TblTerminalUser UserLog = new TblTerminalUser();
			NumUser = UserLog.ValidLogin();
			if (NumUser.Rows.Count < 100)
			{
				status = true;
			}
			else
			{
					//int Limit = 5;
				int Now = DateTime.Now.Minute;
				int Loged;
				//int DeathTime;
				for (int i=0; i <=NumUser.Rows.Count-1;i++)
				{
					Loged = Convert.ToDateTime(NumUser.Rows[i]["SessionTime"]).Minute;
					if ((Now>Loged && Now - Loged > 5)||(Loged>Now && (Now + 60 - Loged)>5))
					{				 
						
						UserLog.StrTerminalUserCode =  NumUser.Rows[i]["strTerminalUserCode"].ToString();					
						UserLog.UpdateSession(false, DateTime.Now);
						status = true;						
					}
					
				}
				
			}
			return status;
			
		}
		private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
//			MessageBox.Show(
//				e.Exception.ToString(), "ERROR",
//				MessageBoxButtons.OK, MessageBoxIcon.Error);
			ACMS.ACMSLogin.frmException form = new ACMS.ACMSLogin.frmException(e.Exception.Message, e.Exception.ToString());
			form.ShowDialog();
			form.Dispose();
		}

		private void frmLogin_Activated(object sender, System.EventArgs e)
		{
			if (!this.isFinishInitialize)
			{
				txtUsername.Focus();
				this.isFinishInitialize = true;
                string allowUpdate = ConfigurationSettings.AppSettings["AllowVersionUpdate"];
                if (allowUpdate.ToUpper() == "YES")
                {
                    checksum();
                }
			}
		}

		private void txtUsername_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode.ToString()=="Return")
			{
				//to add send key
                //SendKeys.Send("%{TAB}");
                //this.isFinishInitialize = true;
                txtPassword.Focus();
			}
		}

        private void txtPassword_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                //to add send key
                //SendKeys.Send("{TAB}");
                btnLogin_Click(sender, e);
            }
        }


        public void BranchTerminal()
        {
            connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"];
            connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlDataReader myBranchReader = null;
                SqlCommand myBranchCommand = new SqlCommand("select * from tblBranch where nBrStatusID = 1", connection);
                myBranchReader = myBranchCommand.ExecuteReader();
                while (myBranchReader.Read())
                {
                    cb_Branch.Items.Add(myBranchReader["strBranchCode"]);
                }
            }
            catch (Exception b)
            {
                MessageBox.Show(b.ToString());
            }

        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            System.Security.Principal.WindowsIdentity userLogin = System.Security.Principal.WindowsIdentity.GetCurrent();
            string selectedBranch = cb_Branch.SelectedItem.ToString();
            string selectedTerminal = cb_Terminal.SelectedItem.ToString();
            connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"];
            connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                using (SqlCommand cmd =
                    new SqlCommand("UPDATE tblTerminalUser SET strBranchCode=@branch, nTerminalID=@terminal WHERE strTerminalUserCode=@strTerminalUserCode", connection))
                {
                    cmd.Parameters.AddWithValue("@Branch", selectedBranch);
                    cmd.Parameters.AddWithValue("@Terminal", selectedTerminal);
                    cmd.Parameters.AddWithValue("@strTerminalUserCode", userLogin.Name);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated");
                    //rows number of record got updated
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Update Failed");
                //Log exception
                //Display Error message
            }
        }

    }

}
