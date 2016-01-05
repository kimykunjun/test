using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;

//using Rp = Acms.Core.Repository;
//using Fc = Acms.Core.Factory;
using Do = Acms.Core.Domain;
using ACMSLogic;

namespace ACMS.ACMSBranch.BranchTransaction
{
	/// <summary>
	/// Summary description for frmCloseShift.
	/// </summary>
	public class frmCloseShift : System.Windows.Forms.Form
	{
		private Do.Employee employee;
		private Do.TerminalUser terminalUser; 
		User oUser;

		private string connectionString;
		private SqlConnection connection;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraEditors.TextEdit txtDepositMoney;
		internal DevExpress.XtraEditors.SimpleButton Cancel;
		private System.Windows.Forms.Label lblDepositMoney;
		internal DevExpress.XtraEditors.SimpleButton btnClose;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private int ShiftID;

		#region Initialize Data from Login
		public void initData (ACMSLogic.User User)
		{
			oUser = User;
		}

		public void SetEmployeeRecord(Do.Employee employee)
		{
			this.employee = employee;
		}

		public void SetTerminalUser(Do.TerminalUser terminalUser)
		{
			this.terminalUser = terminalUser;
		}

		#endregion

		public frmCloseShift(int SID)
		{
			//
			// Required for Windows Form Designer support
			//
			ShiftID = SID;
			InitializeComponent();
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtDepositMoney = new DevExpress.XtraEditors.TextEdit();
            this.lblDepositMoney = new System.Windows.Forms.Label();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.Cancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepositMoney.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtDepositMoney);
            this.groupControl1.Controls.Add(this.lblDepositMoney);
            this.groupControl1.Controls.Add(this.btnClose);
            this.groupControl1.Controls.Add(this.Cancel);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(416, 102);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "groupControl1";
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // txtDepositMoney
            // 
            this.txtDepositMoney.EditValue = "";
            this.txtDepositMoney.Location = new System.Drawing.Point(230, 28);
            this.txtDepositMoney.Name = "txtDepositMoney";
            this.txtDepositMoney.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtDepositMoney.Size = new System.Drawing.Size(202, 22);
            this.txtDepositMoney.TabIndex = 3;
            // 
            // lblDepositMoney
            // 
            this.lblDepositMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepositMoney.Location = new System.Drawing.Point(38, 28);
            this.lblDepositMoney.Name = "lblDepositMoney";
            this.lblDepositMoney.Size = new System.Drawing.Size(183, 26);
            this.lblDepositMoney.TabIndex = 0;
            this.lblDepositMoney.Text = "Money to be deposited";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnClose.Location = new System.Drawing.Point(115, 74);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Save to Safe Box";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Cancel
            // 
            this.Cancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Cancel.Appearance.Options.UseFont = true;
            this.Cancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.Cancel.Location = new System.Drawing.Point(269, 74);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(86, 23);
            this.Cancel.TabIndex = 6;
            this.Cancel.Text = "Cancel";
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // frmCloseShift
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(416, 102);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmCloseShift";
            this.Text = "Close Shift .....";
            this.Load += new System.EventHandler(this.frmCloseShift_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDepositMoney.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void groupControl1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			int output;
			output = 0;

			SqlHelper.ExecuteNonQuery(connection,"up_ShirtDeposit",
				new SqlParameter("@Amount",output),
				new SqlParameter("@Amount",this.txtDepositMoney.Text),								
				new SqlParameter("@UserID",oUser.NEmployeeID()),								
				new SqlParameter("@ShiftID",ShiftID)
				);
			this.Dispose();
		}

		private void frmCloseShift_Load(object sender, System.EventArgs e)
		{
			

		}

		private void Cancel_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

	
	}
}
