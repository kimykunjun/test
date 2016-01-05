using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using Do = Acms.Core.Domain;
using ACMSLogic;
using ACMS.Utils;

namespace ACMS.ACMSBranch.BranchTransaction
{
	/// <summary>
	/// Summary description for frmMemberCard.
	/// </summary>
	public class frmMemberCard : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		/// 			
		private static DataTable dt;
		private static DataRow dr;
		private System.ComponentModel.Container components = null;
		private string connectionString;
		private SqlConnection connection;
		private static Do.Employee employee;
		private static Do.TerminalUser terminalUser;
		internal DevExpress.XtraEditors.GroupControl groupControl43;
		private DevExpress.XtraEditors.ImageComboBoxEdit cmbMemberCard;
		private DevExpress.XtraEditors.GroupControl grpMemberCardBelow;
		internal DevExpress.XtraGrid.GridControl GridMemberCard;
		internal DevExpress.XtraGrid.Views.Grid.GridView GridView41;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn225;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn234;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn235;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.TextEdit txtMemberID;
		private DevExpress.XtraEditors.TextEdit txtMemberName;
		private DevExpress.XtraGrid.Views.Grid.GridView gvTransferMember;
		private DevExpress.XtraGrid.GridControl gcTransferMember; 
		private static User oUser;

		public frmMemberCard()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"]; 
			connection = new SqlConnection(connectionString);

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
			this.groupControl43 = new DevExpress.XtraEditors.GroupControl();
			this.cmbMemberCard = new DevExpress.XtraEditors.ImageComboBoxEdit();
			this.grpMemberCardBelow = new DevExpress.XtraEditors.GroupControl();
			this.gcTransferMember = new DevExpress.XtraGrid.GridControl();
			this.gvTransferMember = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.txtMemberName = new DevExpress.XtraEditors.TextEdit();
			this.txtMemberID = new DevExpress.XtraEditors.TextEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.GridMemberCard = new DevExpress.XtraGrid.GridControl();
			this.GridView41 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.GridColumn225 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn234 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.GridColumn235 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.groupControl43)).BeginInit();
			this.groupControl43.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbMemberCard.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grpMemberCardBelow)).BeginInit();
			this.grpMemberCardBelow.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcTransferMember)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvTransferMember)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMemberName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMemberID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridMemberCard)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridView41)).BeginInit();
			this.SuspendLayout();
			// 
			// groupControl43
			// 
			this.groupControl43.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.groupControl43.Appearance.Options.UseBackColor = true;
			this.groupControl43.Controls.Add(this.cmbMemberCard);
			this.groupControl43.Controls.Add(this.grpMemberCardBelow);
			this.groupControl43.Controls.Add(this.GridMemberCard);
			this.groupControl43.Location = new System.Drawing.Point(7, -2);
			this.groupControl43.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.groupControl43.LookAndFeel.UseDefaultLookAndFeel = false;
			this.groupControl43.LookAndFeel.UseWindowsXPTheme = false;
			this.groupControl43.Name = "groupControl43";
			this.groupControl43.Size = new System.Drawing.Size(984, 554);
			this.groupControl43.TabIndex = 2;
			this.groupControl43.Text = "MEMBER CARD";
			// 
			// cmbMemberCard
			// 
			this.cmbMemberCard.EditValue = 7;
			this.cmbMemberCard.Location = new System.Drawing.Point(16, 32);
			this.cmbMemberCard.Name = "cmbMemberCard";
			// 
			// cmbMemberCard.Properties
			// 
			this.cmbMemberCard.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cmbMemberCard.Properties.Items.AddRange(new object[] {
																		  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Transfer Due", 7, -1),
																		  new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Pending Receipt", 3, -1)});
			this.cmbMemberCard.Size = new System.Drawing.Size(144, 22);
			this.cmbMemberCard.TabIndex = 7;
			this.cmbMemberCard.SelectedIndexChanged += new System.EventHandler(this.cmbMemberCard_SelectedIndexChanged);
			// 
			// grpMemberCardBelow
			// 
			this.grpMemberCardBelow.Appearance.BackColor = System.Drawing.Color.White;
			this.grpMemberCardBelow.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.grpMemberCardBelow.Appearance.Options.UseBackColor = true;
			this.grpMemberCardBelow.Controls.Add(this.gcTransferMember);
			this.grpMemberCardBelow.Controls.Add(this.txtMemberName);
			this.grpMemberCardBelow.Controls.Add(this.txtMemberID);
			this.grpMemberCardBelow.Controls.Add(this.label2);
			this.grpMemberCardBelow.Controls.Add(this.label1);
			this.grpMemberCardBelow.Location = new System.Drawing.Point(16, 280);
			this.grpMemberCardBelow.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.grpMemberCardBelow.LookAndFeel.UseDefaultLookAndFeel = false;
			this.grpMemberCardBelow.LookAndFeel.UseWindowsXPTheme = false;
			this.grpMemberCardBelow.Name = "grpMemberCardBelow";
			this.grpMemberCardBelow.Size = new System.Drawing.Size(952, 264);
			this.grpMemberCardBelow.TabIndex = 6;
			this.grpMemberCardBelow.Text = "Transfer Member Card";
			// 
			// gcTransferMember
			// 
			// 
			// gcTransferMember.EmbeddedNavigator
			// 
			this.gcTransferMember.EmbeddedNavigator.Name = "";
			this.gcTransferMember.Location = new System.Drawing.Point(8, 24);
			this.gcTransferMember.MainView = this.gvTransferMember;
			this.gcTransferMember.Name = "gcTransferMember";
			this.gcTransferMember.Size = new System.Drawing.Size(376, 232);
			this.gcTransferMember.TabIndex = 6;
			this.gcTransferMember.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																											this.gvTransferMember});
			// 
			// gvTransferMember
			// 
			this.gvTransferMember.GridControl = this.gcTransferMember;
			this.gvTransferMember.Name = "gvTransferMember";
			this.gvTransferMember.OptionsBehavior.Editable = false;
			this.gvTransferMember.OptionsCustomization.AllowFilter = false;
			this.gvTransferMember.OptionsCustomization.AllowSort = false;
			this.gvTransferMember.OptionsView.ShowGroupPanel = false;
			// 
			// txtMemberName
			// 
			this.txtMemberName.EditValue = "";
			this.txtMemberName.Enabled = false;
			this.txtMemberName.Location = new System.Drawing.Point(528, 120);
			this.txtMemberName.Name = "txtMemberName";
			this.txtMemberName.Size = new System.Drawing.Size(376, 20);
			this.txtMemberName.TabIndex = 5;
			// 
			// txtMemberID
			// 
			this.txtMemberID.EditValue = "";
			this.txtMemberID.Location = new System.Drawing.Point(528, 80);
			this.txtMemberID.Name = "txtMemberID";
			// 
			// txtMemberID.Properties
			// 
			this.txtMemberID.Properties.Appearance.BackColor = System.Drawing.Color.DarkTurquoise;
			this.txtMemberID.Properties.Appearance.Options.UseBackColor = true;
			this.txtMemberID.Size = new System.Drawing.Size(224, 20);
			this.txtMemberID.TabIndex = 4;
			this.txtMemberID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMemberID_KeyPress);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(416, 128);
			this.label2.Name = "label2";
			this.label2.TabIndex = 3;
			this.label2.Text = "Member Name";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(416, 80);
			this.label1.Name = "label1";
			this.label1.TabIndex = 2;
			this.label1.Text = "Member ID";
			// 
			// GridMemberCard
			// 
			// 
			// GridMemberCard.EmbeddedNavigator
			// 
			this.GridMemberCard.EmbeddedNavigator.Name = "";
			this.GridMemberCard.Location = new System.Drawing.Point(16, 64);
			this.GridMemberCard.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
			this.GridMemberCard.LookAndFeel.UseDefaultLookAndFeel = false;
			this.GridMemberCard.LookAndFeel.UseWindowsXPTheme = false;
			this.GridMemberCard.MainView = this.GridView41;
			this.GridMemberCard.Name = "GridMemberCard";
			this.GridMemberCard.Size = new System.Drawing.Size(952, 208);
			this.GridMemberCard.TabIndex = 1;
			this.GridMemberCard.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										  this.GridView41});
			// 
			// GridView41
			// 
			this.GridView41.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							  this.GridColumn225,
																							  this.GridColumn234,
																							  this.GridColumn235,
																							  this.gridColumn25});
			this.GridView41.GridControl = this.GridMemberCard;
			this.GridView41.Name = "GridView41";
			this.GridView41.OptionsBehavior.Editable = false;
			this.GridView41.OptionsCustomization.AllowFilter = false;
			this.GridView41.OptionsView.ShowGroupPanel = false;
			// 
			// GridColumn225
			// 
			this.GridColumn225.Caption = "Membership ID";
			this.GridColumn225.FieldName = "strMembershipId";
			this.GridColumn225.Name = "GridColumn225";
			this.GridColumn225.Visible = true;
			this.GridColumn225.VisibleIndex = 0;
			this.GridColumn225.Width = 147;
			// 
			// GridColumn234
			// 
			this.GridColumn234.Caption = "Member Name";
			this.GridColumn234.FieldName = "strMemberName";
			this.GridColumn234.Name = "GridColumn234";
			this.GridColumn234.Visible = true;
			this.GridColumn234.VisibleIndex = 1;
			this.GridColumn234.Width = 302;
			// 
			// GridColumn235
			// 
			this.GridColumn235.Caption = "Source Branch";
			this.GridColumn235.FieldName = "BranchFrom";
			this.GridColumn235.Name = "GridColumn235";
			this.GridColumn235.Visible = true;
			this.GridColumn235.VisibleIndex = 2;
			this.GridColumn235.Width = 220;
			// 
			// gridColumn25
			// 
			this.gridColumn25.Caption = "Destination Branch";
			this.gridColumn25.FieldName = "Destination";
			this.gridColumn25.Name = "gridColumn25";
			this.gridColumn25.Visible = true;
			this.gridColumn25.VisibleIndex = 3;
			this.gridColumn25.Width = 282;
			// 
			// frmMemberCard
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(999, 557);
			this.Controls.Add(this.groupControl43);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmMemberCard";
			this.Text = "frmMemberCard";
			this.Load += new System.EventHandler(this.frmMemberCard_Load);
			((System.ComponentModel.ISupportInitialize)(this.groupControl43)).EndInit();
			this.groupControl43.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbMemberCard.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grpMemberCardBelow)).EndInit();
			this.grpMemberCardBelow.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gcTransferMember)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvTransferMember)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMemberName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMemberID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridMemberCard)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridView41)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region common
		private string ConvertToDateTime(object target)
		{
			if (target.ToString() == "" )
				return null;
			else
				return Convert.ToDateTime(target).ToString();
		}

		private int ConvertToInt(object target)
		{
			if (target.ToString() == "" )
				return 0;
			else
				return Convert.ToInt32(target);
		}
		
		private void comboBind(DevExpress.XtraEditors.ImageComboBoxEdit control,string strSQL,string display,string strValue)
		{
		
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox properties = control.Properties;
			properties.Items.BeginUpdate();
			properties.Items.Clear();

			try 
			{
				foreach(DataRow dr in _ds.Tables["Table"].Rows)
				{
					//Initialize each item with the display text, value and image index
					properties.Items.Add( new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr[display].ToString(), dr[strValue].ToString(),-1));
				}
			}
			finally 
			{
				properties.Items.EndUpdate();
			}
			//Select the first item
			control.SelectedIndex = 0;
		}

		private void comboBind(DevExpress.XtraEditors.ImageComboBoxEdit control,string strSQL,string display,string strValue,bool fNum)
		{
		
			DataSet _ds = new DataSet();
			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox properties = control.Properties;
			properties.Items.BeginUpdate();
			properties.Items.Clear();

			try 
			{
				foreach(DataRow dr in _ds.Tables["Table"].Rows)
				{
					//Initialize each item with the display text, value and image index
					properties.Items.Add( new DevExpress.XtraEditors.Controls.ImageComboBoxItem(dr[display].ToString(), dr[strValue],-1));
				}
			}
			finally 
			{
				properties.Items.EndUpdate();
			}
			//Select the first item
			control.SelectedIndex = 0;
		}
		

		#endregion

		#region security
		public void initData (ACMSLogic.User User)
		{
			oUser = User;
			MemberRecord myMemberRecord = new MemberRecord(oUser.StrBranchCode());
		}

		public void SetEmployeeRecord(Do.Employee emp)
		{
			employee = emp;
		}

		public void SetTerminalUser(Do.TerminalUser tu)
		{
			terminalUser = tu;

		}

		
		#endregion

		#region Member card
		private void MemberCardInit()
		{
			DataSet _ds = new DataSet();
						
			string strSQL = "up_get_Membership '" + terminalUser.Branch.Id.ToString() + "'";

			SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
			
			DataView dv = new DataView(_ds.Tables["Table"]);
			
			dv.RowFilter = " nStatusID = " + cmbMemberCard.EditValue;

			GridMemberCard.DataSource = dv;

		}

		private void cmbMemberCard_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			MemberCardInit();
		}

		private void btnMemberCard_Transfer_Click(object sender, System.EventArgs e)
		{
			/*
			if (memoEdit1.Text != "")
			{
				string Splitter = memoEdit1.Text.Replace("\r\n","/");
			
				string[]s = new string[4];

				s = Splitter.Split(new char[] {'/'});
			
				for(int x = 0; x < s.Length; x++)
				{

					int output;
					output = 0;
					SqlHelper.ExecuteNonQuery(connection,"up_Branch_CardRequest",
						new SqlParameter("@retval",output),
						new SqlParameter("@empID",employee.Id),
						new SqlParameter("@strMembershipID",s[x] )
						);
				
				
				}
				MemberCardInit();
			{MessageBox.Show("Update Successfully","Transfer Status");}
			}
			else
			{MessageBox.Show("Please enter at least one member Id","Transfer Status");}
			*/
		}

		private void btnMemberCard_Received_Click(object sender, System.EventArgs e)
		{
		/*	if (memoEdit1.Text != "")
			{
				string Splitter = memoEdit1.Text.Replace("\r\n","/");
			
				string[]s = new string[4];

				s = Splitter.Split(new char[] {'/'});
			
				for(int x = 0; x < s.Length; x++)
				{

					int output;
					output = 0;
					SqlHelper.ExecuteNonQuery(connection,"up_Branch_CardRequestReceived",
						new SqlParameter("@retval",output),
						new SqlParameter("@empID",employee.Id),
						new SqlParameter("@BranchCode",oUser.StrBranchCode()),
						new SqlParameter("@strMembershipID",s[x] )
						);
				
				
				}
				MemberCardInit();
			{MessageBox.Show("Update Successfully","Transfer Status");}
			}
			else
			{MessageBox.Show("Please enter at least one member Id","Transfer Status");}
			*/
		}

		#endregion

		private void frmMemberCard_Load(object sender, System.EventArgs e)
		{
			MemberCardInit();
			dt = new DataTable();
			dt.Columns.Add("Membership ID");
			dt.Columns.Add("Member Name");
			dt.Columns.Add("Status");
			
			gcTransferMember.DataSource = dt;
		}



		private void txtMemberID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if ( txtMemberName.Text != "" )
			{
				txtMemberID.Text="";
				txtMemberName.Text="";
			}
			//MessageBox.Show(e.KeyChar.ToString());
			DataSet _ds,_ds2;
			string strSQL;

			if ( e.KeyChar == 13  )
			{
				if( cmbMemberCard.SelectedIndex == 0)
				{
					strSQL="select * from tblMember where nCardStatusID='7' and strMembershipID='" + txtMemberID.Text + "'";
					_ds = new DataSet();
					SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
					if ( _ds.Tables["table"].Rows.Count>0)
					{
						strSQL="select * from tblCardRequest where nStatusID='7' and strMembershipID='" + txtMemberID.Text + "'";
						_ds2 = new DataSet();
						SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds2,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
						if ( _ds2.Tables["table"].Rows.Count>0 )
						{
							int output;
							try
							{			
								output = 0;
								SqlHelper.ExecuteNonQuery(connection,"up_Branch_CardRequest",
									new SqlParameter("@retval",output),
									new SqlParameter("@empID",employee.Id),
									new SqlParameter("@strMembershipID",txtMemberID.Text )
									);
								foreach( DataRow dr2 in _ds.Tables["table"].Rows )
								{
									txtMemberName.Text = dr2["strMemberName"].ToString();
									dr = dt.NewRow();
									dr[0] = txtMemberID.Text;
									dr[1] = dr2["strMemberName"];
									dr[2] = "In Transit";
									dt.Rows.Add(dr);
								}
							}
							catch (Exception ex)
							{
								MessageBox.Show("Update Failed:" + ex.Message );
							}
						}
					}
				}
				else if ( cmbMemberCard.SelectedIndex == 1 )
				{
					strSQL="select * from tblMember where nCardStatusID='3' and strMembershipID='" + txtMemberID.Text + "'";
					_ds = new DataSet();
					SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
					if ( _ds.Tables["table"].Rows.Count>0)
					{
						strSQL="select * from tblCardRequest where nStatusID='3' and strMembershipID='" + txtMemberID.Text + "'";
						_ds2 = new DataSet();
						SqlHelper.FillDataset(connection,CommandType.StoredProcedure,"UP_GETDATA",_ds2,new string[] {"table"}, new SqlParameter("@strSQL", strSQL) );
						if ( _ds2.Tables["table"].Rows.Count>0 )
						{
							int output;
							try
							{			
								output = 0;
								SqlHelper.ExecuteNonQuery(connection,"up_Branch_CardRequestReceived",
									new SqlParameter("@retval",output),
									new SqlParameter("@empID",employee.Id),
									new SqlParameter("@BranchCode",oUser.StrBranchCode()),
									new SqlParameter("@strMembershipID",txtMemberID.Text )
									);
								foreach( DataRow dr2 in _ds.Tables["table"].Rows )
								{
									txtMemberName.Text = dr2["strMemberName"].ToString();
									dr = dt.NewRow();
									dr[0] = txtMemberID.Text;
									dr[1] = dr2["strMemberName"];
									dr[2] = "Card Received";
									dt.Rows.Add(dr);
								}
							}
							catch (Exception ex)
							{
								MessageBox.Show("Update Failed:" + ex.Message );
							}
						}
					}

				}
				//this.txtMemberID.EditValue = "";
				MemberCardInit();
			}
			
		}


	}
}
