using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

namespace ACMS.ACMSManager.Human_Resource
{
	/// <summary>
	/// Summary description for frmApprovedOvertime.
	/// </summary>
	public class frmApprovedOvertime : System.Windows.Forms.Form
	{
		
		private string connectionString;
		private SqlConnection connection;
		private System.Windows.Forms.Label label1;
		internal DevExpress.XtraEditors.SimpleButton btnApproved;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private DevExpress.XtraEditors.ComboBoxEdit cbChargeID;
		private static int OvertimeID;
		private System.Windows.Forms.GroupBox TimeChargeGroup;
		private System.Windows.Forms.TextBox OTType3;
		private System.Windows.Forms.TextBox OTType2;
		private System.Windows.Forms.TextBox OTType1;
		private System.Windows.Forms.RadioButton rdType1;
		private System.Windows.Forms.RadioButton rdType3;
		private System.Windows.Forms.RadioButton rdType2;
		private static int UserID;
		private int nTimeoffType;
		private double nPayrollHrs;

		public frmApprovedOvertime(int id,int uid)
		{
			//
			// Required for Windows Form Designer support
			//
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);
			InitializeComponent();
			OvertimeID = id;
			UserID = uid;

			TimeChargeGroup.Enabled=false;
	
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
			this.label1 = new System.Windows.Forms.Label();
			this.cbChargeID = new DevExpress.XtraEditors.ComboBoxEdit();
			this.btnApproved = new DevExpress.XtraEditors.SimpleButton();
			this.TimeChargeGroup = new System.Windows.Forms.GroupBox();
			this.OTType3 = new System.Windows.Forms.TextBox();
			this.OTType2 = new System.Windows.Forms.TextBox();
			this.OTType1 = new System.Windows.Forms.TextBox();
			this.rdType3 = new System.Windows.Forms.RadioButton();
			this.rdType2 = new System.Windows.Forms.RadioButton();
			this.rdType1 = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.cbChargeID.Properties)).BeginInit();
			this.TimeChargeGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Charge To";
			// 
			// cbChargeID
			// 
			this.cbChargeID.EditValue = "Overtime";
			this.cbChargeID.Location = new System.Drawing.Point(120, 24);
			this.cbChargeID.Name = "cbChargeID";
			// 
			// cbChargeID.Properties
			// 
			this.cbChargeID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.cbChargeID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																											   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cbChargeID.Properties.Items.AddRange(new object[] {
																	   "Time Off",
																	   "Overtime Pay"});
			this.cbChargeID.Size = new System.Drawing.Size(120, 22);
			this.cbChargeID.TabIndex = 1;
			this.cbChargeID.SelectedIndexChanged += new System.EventHandler(this.cbChargeID_SelectedIndexChanged);
			// 
			// btnApproved
			// 
			this.btnApproved.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.btnApproved.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnApproved.Appearance.Options.UseBackColor = true;
			this.btnApproved.Appearance.Options.UseFont = true;
			this.btnApproved.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnApproved.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnApproved.Location = new System.Drawing.Point(280, 24);
			this.btnApproved.Name = "btnApproved";
			this.btnApproved.Size = new System.Drawing.Size(56, 20);
			this.btnApproved.TabIndex = 125;
			this.btnApproved.Text = "OK";
			this.btnApproved.Click += new System.EventHandler(this.btnApproved_Click);
			// 
			// TimeChargeGroup
			// 
			this.TimeChargeGroup.Controls.Add(this.OTType3);
			this.TimeChargeGroup.Controls.Add(this.OTType2);
			this.TimeChargeGroup.Controls.Add(this.OTType1);
			this.TimeChargeGroup.Controls.Add(this.rdType3);
			this.TimeChargeGroup.Controls.Add(this.rdType2);
			this.TimeChargeGroup.Controls.Add(this.rdType1);
			this.TimeChargeGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.TimeChargeGroup.Location = new System.Drawing.Point(16, 64);
			this.TimeChargeGroup.Name = "TimeChargeGroup";
			this.TimeChargeGroup.Size = new System.Drawing.Size(328, 168);
			this.TimeChargeGroup.TabIndex = 126;
			this.TimeChargeGroup.TabStop = false;
			this.TimeChargeGroup.Text = "Charge Type";
			// 
			// OTType3
			// 
			this.OTType3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.OTType3.Location = new System.Drawing.Point(240, 112);
			this.OTType3.Name = "OTType3";
			this.OTType3.ReadOnly = true;
			this.OTType3.Size = new System.Drawing.Size(48, 20);
			this.OTType3.TabIndex = 5;
			this.OTType3.Text = "";
			// 
			// OTType2
			// 
			this.OTType2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.OTType2.Location = new System.Drawing.Point(240, 72);
			this.OTType2.Name = "OTType2";
			this.OTType2.ReadOnly = true;
			this.OTType2.Size = new System.Drawing.Size(48, 20);
			this.OTType2.TabIndex = 4;
			this.OTType2.Text = "";
			// 
			// OTType1
			// 
			this.OTType1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.OTType1.Location = new System.Drawing.Point(240, 36);
			this.OTType1.Name = "OTType1";
			this.OTType1.ReadOnly = true;
			this.OTType1.Size = new System.Drawing.Size(48, 20);
			this.OTType1.TabIndex = 3;
			this.OTType1.Text = "";
			// 
			// rdType3
			// 
			this.rdType3.Location = new System.Drawing.Point(16, 112);
			this.rdType3.Name = "rdType3";
			this.rdType3.TabIndex = 2;
			this.rdType3.Text = "2.0 Days";
			// 
			// rdType2
			// 
			this.rdType2.Location = new System.Drawing.Point(16, 68);
			this.rdType2.Name = "rdType2";
			this.rdType2.TabIndex = 1;
			this.rdType2.Text = "1.5 Hrs";
			// 
			// rdType1
			// 
			this.rdType1.Location = new System.Drawing.Point(16, 32);
			this.rdType1.Name = "rdType1";
			this.rdType1.Size = new System.Drawing.Size(168, 24);
			this.rdType1.TabIndex = 0;
			this.rdType1.Text = "1.0 Days";
			// 
			// frmApprovedOvertime
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(368, 254);
			this.Controls.Add(this.TimeChargeGroup);
			this.Controls.Add(this.btnApproved);
			this.Controls.Add(this.cbChargeID);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmApprovedOvertime";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Overtime Charging";
			((System.ComponentModel.ISupportInitialize)(this.cbChargeID.Properties)).EndInit();
			this.TimeChargeGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnApproved_Click(object sender, System.EventArgs e)
		{
			int output;
			try
			{
				output = 0;

				SqlHelper.ExecuteNonQuery(connection,"up_tblOverTime",
					new SqlParameter("@retval",output),
					new SqlParameter("@nOverTimeId",OvertimeID),
					new SqlParameter("@nChargingID",cbChargeID.SelectedIndex),	
					new SqlParameter("@nManagerID",UserID),
					new SqlParameter("@nTimeoffType",nTimeoffType),
					new SqlParameter("@nPayrollHrs",nPayrollHrs),
					new SqlParameter("@Status",1));
				}
				
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			this.Dispose();
		}

		private void cbChargeID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cbChargeID.SelectedIndex==1)
			{
				TimeChargeGroup.Enabled=true;
				Check_ChargeType();
			}
			else
			{
				TimeChargeGroup.Enabled=false;
			}
	}
		private int Check_ChargeType()
		{
			DataSet _ds = new DataSet(); 
			
			
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"up_Get_OverTime_Type",_ds,new string[] {"Table"}, new SqlParameter("@OverTimeID", OvertimeID));
			DataTable dtOverTime = _ds.Tables["Table"];
			try 
			{
				foreach (DataRow OTrow in dtOverTime.Rows)
				{
					if (ACMS.Convert.ToInt32(OTrow[1])==1)
					{
						rdType1.Checked=true;
						OTType1.Text=OTrow[0].ToString();
					}
					else if (ACMS.Convert.ToInt32(OTrow[1])==2) 
					{
						rdType2.Checked=true;
						OTType2.Text=OTrow[0].ToString();
					}
					else if (ACMS.Convert.ToInt32(OTrow[1])==3) 
					{
						rdType3.Checked=true;
						OTType3.Text=OTrow[0].ToString();
					}

					nTimeoffType=ACMS.Convert.ToInt32(OTrow[1]);
					nPayrollHrs=ACMS.Convert.ToDouble(OTrow[0]);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return 0;
		}
	}
}
