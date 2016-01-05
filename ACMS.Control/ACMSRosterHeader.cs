using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ACMS.Utils;
using Microsoft.ApplicationBlocks.Data;

namespace ACMS.Control
{
	/// <summary>
	/// Summary description for ACMSRosterHeader.
	/// </summary>
	public class ACMSRosterHeader : System.Windows.Forms.UserControl
	{
		public DateTime dateSun, dateMon, dateTue, dateWed, dateThu, dateFri, dateSat;
		public bool _IsShowLeave;

		private System.Windows.Forms.Panel panelHeader;
		private System.Windows.Forms.Label lblHOUR;
		private System.Windows.Forms.Label lblSUN;
		private System.Windows.Forms.Label lblSAT;
		private System.Windows.Forms.Label lblFRI;
		private System.Windows.Forms.Label lblTHU;
		private System.Windows.Forms.Label lblWED;
		private System.Windows.Forms.Label lblTUE;
		private System.Windows.Forms.Label lblMON;
		private System.Windows.Forms.Label lblHdr;
		private System.Windows.Forms.Panel panelRosterDetails;
		public ACMS.Control.ACMSRosterDetails ACMSRosterDetails1;
		private System.Windows.Forms.Panel panelSUN;
		private System.Windows.Forms.Panel panelSAT;
		private System.Windows.Forms.Panel panelFRI;
		private System.Windows.Forms.Panel panelTHU;
		private System.Windows.Forms.Panel panelWED;
		private System.Windows.Forms.Panel panelTUE;
		private System.Windows.Forms.Panel panelMON;
		private DevExpress.XtraEditors.TextEdit txtMonDate;
		private DevExpress.XtraEditors.TextEdit txtTueDate;
		private DevExpress.XtraEditors.TextEdit txtWedDate;
		private DevExpress.XtraEditors.TextEdit txtThuDate;
		private DevExpress.XtraEditors.TextEdit txtFriDate;
		private DevExpress.XtraEditors.TextEdit txtSatDate;
		private DevExpress.XtraEditors.TextEdit txtSunDate;
		private System.Windows.Forms.Panel panelHOUR;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ACMSRosterHeader()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

				
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panelHOUR = new System.Windows.Forms.Panel();
			this.lblHOUR = new System.Windows.Forms.Label();
			this.panelSUN = new System.Windows.Forms.Panel();
			this.txtSunDate = new DevExpress.XtraEditors.TextEdit();
			this.lblSUN = new System.Windows.Forms.Label();
			this.panelSAT = new System.Windows.Forms.Panel();
			this.txtSatDate = new DevExpress.XtraEditors.TextEdit();
			this.lblSAT = new System.Windows.Forms.Label();
			this.panelFRI = new System.Windows.Forms.Panel();
			this.txtFriDate = new DevExpress.XtraEditors.TextEdit();
			this.lblFRI = new System.Windows.Forms.Label();
			this.panelTHU = new System.Windows.Forms.Panel();
			this.txtThuDate = new DevExpress.XtraEditors.TextEdit();
			this.lblTHU = new System.Windows.Forms.Label();
			this.panelWED = new System.Windows.Forms.Panel();
			this.txtWedDate = new DevExpress.XtraEditors.TextEdit();
			this.lblWED = new System.Windows.Forms.Label();
			this.panelTUE = new System.Windows.Forms.Panel();
			this.txtTueDate = new DevExpress.XtraEditors.TextEdit();
			this.lblTUE = new System.Windows.Forms.Label();
			this.panelMON = new System.Windows.Forms.Panel();
			this.lblMON = new System.Windows.Forms.Label();
			this.txtMonDate = new DevExpress.XtraEditors.TextEdit();
			this.lblHdr = new System.Windows.Forms.Label();
			this.panelRosterDetails = new System.Windows.Forms.Panel();
			this.panelHeader = new System.Windows.Forms.Panel();
			this.panelHOUR.SuspendLayout();
			this.panelSUN.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtSunDate.Properties)).BeginInit();
			this.panelSAT.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtSatDate.Properties)).BeginInit();
			this.panelFRI.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtFriDate.Properties)).BeginInit();
			this.panelTHU.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtThuDate.Properties)).BeginInit();
			this.panelWED.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtWedDate.Properties)).BeginInit();
			this.panelTUE.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtTueDate.Properties)).BeginInit();
			this.panelMON.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtMonDate.Properties)).BeginInit();
			this.panelHeader.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelHOUR
			// 
			this.panelHOUR.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panelHOUR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelHOUR.Controls.Add(this.lblHOUR);
			this.panelHOUR.Location = new System.Drawing.Point(712, 0);
			this.panelHOUR.Name = "panelHOUR";
			this.panelHOUR.Size = new System.Drawing.Size(80, 32);
			this.panelHOUR.TabIndex = 43;
			// 
			// lblHOUR
			// 
			this.lblHOUR.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblHOUR.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblHOUR.Location = new System.Drawing.Point(0, 0);
			this.lblHOUR.Name = "lblHOUR";
			this.lblHOUR.Size = new System.Drawing.Size(76, 28);
			this.lblHOUR.TabIndex = 19;
			this.lblHOUR.Text = "Total Hours";
			this.lblHOUR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panelSUN
			// 
			this.panelSUN.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panelSUN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelSUN.Controls.Add(this.txtSunDate);
			this.panelSUN.Controls.Add(this.lblSUN);
			this.panelSUN.Location = new System.Drawing.Point(632, 0);
			this.panelSUN.Name = "panelSUN";
			this.panelSUN.Size = new System.Drawing.Size(80, 32);
			this.panelSUN.TabIndex = 42;
			// 
			// txtSunDate
			// 
			this.txtSunDate.EditValue = "12/6/2005";
			this.txtSunDate.Location = new System.Drawing.Point(4, 16);
			this.txtSunDate.Name = "txtSunDate";
			// 
			// txtSunDate.Properties
			// 
			this.txtSunDate.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtSunDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtSunDate.Properties.Appearance.Options.UseBackColor = true;
			this.txtSunDate.Properties.Appearance.Options.UseFont = true;
			this.txtSunDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.txtSunDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
			this.txtSunDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.txtSunDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.txtSunDate.Properties.ReadOnly = true;
			this.txtSunDate.Size = new System.Drawing.Size(72, 15);
			this.txtSunDate.TabIndex = 4;
			// 
			// lblSUN
			// 
			this.lblSUN.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblSUN.Location = new System.Drawing.Point(0, 0);
			this.lblSUN.Name = "lblSUN";
			this.lblSUN.Size = new System.Drawing.Size(80, 16);
			this.lblSUN.TabIndex = 1;
			this.lblSUN.Text = "SUN";
			this.lblSUN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panelSAT
			// 
			this.panelSAT.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panelSAT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelSAT.Controls.Add(this.txtSatDate);
			this.panelSAT.Controls.Add(this.lblSAT);
			this.panelSAT.Location = new System.Drawing.Point(552, 0);
			this.panelSAT.Name = "panelSAT";
			this.panelSAT.Size = new System.Drawing.Size(80, 32);
			this.panelSAT.TabIndex = 41;
			// 
			// txtSatDate
			// 
			this.txtSatDate.EditValue = "18/6/2005";
			this.txtSatDate.Location = new System.Drawing.Point(4, 16);
			this.txtSatDate.Name = "txtSatDate";
			// 
			// txtSatDate.Properties
			// 
			this.txtSatDate.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtSatDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtSatDate.Properties.Appearance.Options.UseBackColor = true;
			this.txtSatDate.Properties.Appearance.Options.UseFont = true;
			this.txtSatDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.txtSatDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.txtSatDate.Properties.Mask.EditMask = "dd/MM/yyyy";
			this.txtSatDate.Properties.ReadOnly = true;
			this.txtSatDate.Size = new System.Drawing.Size(72, 15);
			this.txtSatDate.TabIndex = 4;
			// 
			// lblSAT
			// 
			this.lblSAT.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblSAT.Location = new System.Drawing.Point(0, 0);
			this.lblSAT.Name = "lblSAT";
			this.lblSAT.Size = new System.Drawing.Size(80, 16);
			this.lblSAT.TabIndex = 1;
			this.lblSAT.Text = "SAT";
			this.lblSAT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panelFRI
			// 
			this.panelFRI.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panelFRI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelFRI.Controls.Add(this.txtFriDate);
			this.panelFRI.Controls.Add(this.lblFRI);
			this.panelFRI.Location = new System.Drawing.Point(472, 0);
			this.panelFRI.Name = "panelFRI";
			this.panelFRI.Size = new System.Drawing.Size(80, 32);
			this.panelFRI.TabIndex = 40;
			// 
			// txtFriDate
			// 
			this.txtFriDate.EditValue = "17/6/2005";
			this.txtFriDate.Location = new System.Drawing.Point(4, 16);
			this.txtFriDate.Name = "txtFriDate";
			// 
			// txtFriDate.Properties
			// 
			this.txtFriDate.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtFriDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtFriDate.Properties.Appearance.Options.UseBackColor = true;
			this.txtFriDate.Properties.Appearance.Options.UseFont = true;
			this.txtFriDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.txtFriDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.txtFriDate.Properties.Mask.EditMask = "dd/MM/yyyy";
			this.txtFriDate.Properties.ReadOnly = true;
			this.txtFriDate.Size = new System.Drawing.Size(72, 15);
			this.txtFriDate.TabIndex = 3;
			// 
			// lblFRI
			// 
			this.lblFRI.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblFRI.Location = new System.Drawing.Point(0, 0);
			this.lblFRI.Name = "lblFRI";
			this.lblFRI.Size = new System.Drawing.Size(80, 16);
			this.lblFRI.TabIndex = 1;
			this.lblFRI.Text = "FRI";
			this.lblFRI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panelTHU
			// 
			this.panelTHU.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panelTHU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelTHU.Controls.Add(this.txtThuDate);
			this.panelTHU.Controls.Add(this.lblTHU);
			this.panelTHU.Location = new System.Drawing.Point(392, 0);
			this.panelTHU.Name = "panelTHU";
			this.panelTHU.Size = new System.Drawing.Size(80, 32);
			this.panelTHU.TabIndex = 39;
			// 
			// txtThuDate
			// 
			this.txtThuDate.EditValue = "16/6/2005";
			this.txtThuDate.Location = new System.Drawing.Point(4, 16);
			this.txtThuDate.Name = "txtThuDate";
			// 
			// txtThuDate.Properties
			// 
			this.txtThuDate.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtThuDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtThuDate.Properties.Appearance.Options.UseBackColor = true;
			this.txtThuDate.Properties.Appearance.Options.UseFont = true;
			this.txtThuDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.txtThuDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.txtThuDate.Properties.ReadOnly = true;
			this.txtThuDate.Size = new System.Drawing.Size(72, 15);
			this.txtThuDate.TabIndex = 3;
			// 
			// lblTHU
			// 
			this.lblTHU.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTHU.Location = new System.Drawing.Point(0, 0);
			this.lblTHU.Name = "lblTHU";
			this.lblTHU.Size = new System.Drawing.Size(80, 16);
			this.lblTHU.TabIndex = 1;
			this.lblTHU.Text = "THU";
			this.lblTHU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panelWED
			// 
			this.panelWED.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panelWED.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelWED.Controls.Add(this.txtWedDate);
			this.panelWED.Controls.Add(this.lblWED);
			this.panelWED.Location = new System.Drawing.Point(312, 0);
			this.panelWED.Name = "panelWED";
			this.panelWED.Size = new System.Drawing.Size(80, 32);
			this.panelWED.TabIndex = 38;
			// 
			// txtWedDate
			// 
			this.txtWedDate.EditValue = "15/6/2005";
			this.txtWedDate.Location = new System.Drawing.Point(4, 16);
			this.txtWedDate.Name = "txtWedDate";
			// 
			// txtWedDate.Properties
			// 
			this.txtWedDate.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtWedDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtWedDate.Properties.Appearance.Options.UseBackColor = true;
			this.txtWedDate.Properties.Appearance.Options.UseFont = true;
			this.txtWedDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.txtWedDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.txtWedDate.Properties.Mask.EditMask = "dd/MM/yyyy";
			this.txtWedDate.Properties.ReadOnly = true;
			this.txtWedDate.Size = new System.Drawing.Size(72, 15);
			this.txtWedDate.TabIndex = 3;
			// 
			// lblWED
			// 
			this.lblWED.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblWED.Location = new System.Drawing.Point(0, 0);
			this.lblWED.Name = "lblWED";
			this.lblWED.Size = new System.Drawing.Size(80, 16);
			this.lblWED.TabIndex = 1;
			this.lblWED.Text = "WED";
			this.lblWED.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panelTUE
			// 
			this.panelTUE.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panelTUE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelTUE.Controls.Add(this.txtTueDate);
			this.panelTUE.Controls.Add(this.lblTUE);
			this.panelTUE.Location = new System.Drawing.Point(232, 0);
			this.panelTUE.Name = "panelTUE";
			this.panelTUE.Size = new System.Drawing.Size(80, 32);
			this.panelTUE.TabIndex = 37;
			// 
			// txtTueDate
			// 
			this.txtTueDate.EditValue = "14/6/2005";
			this.txtTueDate.Location = new System.Drawing.Point(4, 16);
			this.txtTueDate.Name = "txtTueDate";
			// 
			// txtTueDate.Properties
			// 
			this.txtTueDate.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtTueDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtTueDate.Properties.Appearance.Options.UseBackColor = true;
			this.txtTueDate.Properties.Appearance.Options.UseFont = true;
			this.txtTueDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.txtTueDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.txtTueDate.Properties.Mask.EditMask = "dd/MM/yyyy";
			this.txtTueDate.Properties.ReadOnly = true;
			this.txtTueDate.Size = new System.Drawing.Size(72, 15);
			this.txtTueDate.TabIndex = 2;
			// 
			// lblTUE
			// 
			this.lblTUE.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTUE.Location = new System.Drawing.Point(0, 0);
			this.lblTUE.Name = "lblTUE";
			this.lblTUE.Size = new System.Drawing.Size(80, 16);
			this.lblTUE.TabIndex = 1;
			this.lblTUE.Text = "TUE";
			this.lblTUE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panelMON
			// 
			this.panelMON.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panelMON.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelMON.Controls.Add(this.lblMON);
			this.panelMON.Controls.Add(this.txtMonDate);
			this.panelMON.Location = new System.Drawing.Point(152, 0);
			this.panelMON.Name = "panelMON";
			this.panelMON.Size = new System.Drawing.Size(80, 32);
			this.panelMON.TabIndex = 36;
			// 
			// lblMON
			// 
			this.lblMON.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMON.Location = new System.Drawing.Point(0, 0);
			this.lblMON.Name = "lblMON";
			this.lblMON.Size = new System.Drawing.Size(80, 16);
			this.lblMON.TabIndex = 1;
			this.lblMON.Text = "MON";
			this.lblMON.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtMonDate
			// 
			this.txtMonDate.EditValue = "13/6/2005";
			this.txtMonDate.Location = new System.Drawing.Point(4, 16);
			this.txtMonDate.Name = "txtMonDate";
			// 
			// txtMonDate.Properties
			// 
			this.txtMonDate.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
			this.txtMonDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtMonDate.Properties.Appearance.Options.UseBackColor = true;
			this.txtMonDate.Properties.Appearance.Options.UseFont = true;
			this.txtMonDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.txtMonDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.txtMonDate.Properties.Mask.EditMask = "dd/MM/yyyy";
			this.txtMonDate.Properties.ReadOnly = true;
			this.txtMonDate.Size = new System.Drawing.Size(72, 15);
			this.txtMonDate.TabIndex = 1;
			// 
			// lblHdr
			// 
			this.lblHdr.BackColor = System.Drawing.Color.LightGray;
			this.lblHdr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblHdr.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblHdr.Location = new System.Drawing.Point(0, 0);
			this.lblHdr.Name = "lblHdr";
			this.lblHdr.Size = new System.Drawing.Size(152, 32);
			this.lblHdr.TabIndex = 0;
			this.lblHdr.Text = "STAFF NAME / DATE";
			this.lblHdr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panelRosterDetails
			// 
			this.panelRosterDetails.AutoScroll = true;
			this.panelRosterDetails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelRosterDetails.Location = new System.Drawing.Point(0, 32);
			this.panelRosterDetails.Name = "panelRosterDetails";
			this.panelRosterDetails.Size = new System.Drawing.Size(800, 384);
			this.panelRosterDetails.TabIndex = 44;
			// 
			// panelHeader
			// 
			this.panelHeader.Controls.Add(this.panelHOUR);
			this.panelHeader.Controls.Add(this.panelSAT);
			this.panelHeader.Controls.Add(this.panelFRI);
			this.panelHeader.Controls.Add(this.panelTHU);
			this.panelHeader.Controls.Add(this.lblHdr);
			this.panelHeader.Controls.Add(this.panelWED);
			this.panelHeader.Controls.Add(this.panelMON);
			this.panelHeader.Controls.Add(this.panelTUE);
			this.panelHeader.Controls.Add(this.panelSUN);
			this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelHeader.Location = new System.Drawing.Point(0, 0);
			this.panelHeader.Name = "panelHeader";
			this.panelHeader.Size = new System.Drawing.Size(800, 32);
			this.panelHeader.TabIndex = 45;
			// 
			// ACMSRosterHeader
			// 
			this.Controls.Add(this.panelRosterDetails);
			this.Controls.Add(this.panelHeader);
			this.Name = "ACMSRosterHeader";
			this.Size = new System.Drawing.Size(800, 416);
			this.Load += new System.EventHandler(this.ACMSRosterHeader_Load);
			this.panelHOUR.ResumeLayout(false);
			this.panelSUN.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtSunDate.Properties)).EndInit();
			this.panelSAT.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtSatDate.Properties)).EndInit();
			this.panelFRI.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtFriDate.Properties)).EndInit();
			this.panelTHU.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtThuDate.Properties)).EndInit();
			this.panelWED.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtWedDate.Properties)).EndInit();
			this.panelTUE.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtTueDate.Properties)).EndInit();
			this.panelMON.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtMonDate.Properties)).EndInit();
			this.panelHeader.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void init()
		{
			init(false, "", "");
		}

		public void init(bool isShowStaffInfo, string year, string weekNo)
		{
			DataSet _ds;

			this.SuspendLayout();
			int y=-1;
			foreach ( DataRow dr in dtRoster.Rows )
			{
			
				int i = Convert.ToInt32( dr["week_day"].ToString() );
				this.txtSunDate.Text = Convert.ToDateTime( dr["today"].ToString() ).AddDays(8-i).ToString("dd-MM-yyyy");
				this.txtMonDate.Text = Convert.ToDateTime( dr["today"].ToString() ).AddDays(2-i).ToString("dd-MM-yyyy");
				this.txtTueDate.Text = Convert.ToDateTime( dr["today"].ToString() ).AddDays(3-i).ToString("dd-MM-yyyy");
				this.txtWedDate.Text = Convert.ToDateTime( dr["today"].ToString() ).AddDays(4-i).ToString("dd-MM-yyyy");
				this.txtThuDate.Text = Convert.ToDateTime( dr["today"].ToString() ).AddDays(5-i).ToString("dd-MM-yyyy");
				this.txtFriDate.Text = Convert.ToDateTime( dr["today"].ToString() ).AddDays(6-i).ToString("dd-MM-yyyy");
				this.txtSatDate.Text = Convert.ToDateTime( dr["today"].ToString() ).AddDays(7-i).ToString("dd-MM-yyyy");
				dateSun = Convert.ToDateTime(dr["today"]).AddDays(8-i);
				dateMon = Convert.ToDateTime(dr["today"]).AddDays(2-i);
				dateTue = Convert.ToDateTime(dr["today"]).AddDays(3-i);
				dateWed = Convert.ToDateTime(dr["today"]).AddDays(4-i);
				dateThu = Convert.ToDateTime(dr["today"]).AddDays(5-i);
				dateFri = Convert.ToDateTime(dr["today"]).AddDays(6-i);
				dateSat = Convert.ToDateTime(dr["today"]).AddDays(7-i);
			}
			panelRosterDetails.DataBindings.Clear();
			panelRosterDetails.Controls.Remove(ACMSRosterDetails1);	
			panelRosterDetails.Controls.Clear();

			foreach ( DataRow dr1 in dtRosterDetail.Rows )
			{
				this.ACMSRosterDetails1 = new ACMSRosterDetails();
				this.ACMSRosterDetails1.Location = new System.Drawing.Point(0, y);
				this.ACMSRosterDetails1.Name = "ACMSRosterDetails1";
				this.ACMSRosterDetails1.Size = new System.Drawing.Size(792, 54);
				this.ACMSRosterDetails1.TabIndex = 0;
				this.ACMSRosterDetails1.Click += new System.EventHandler(this._Click);
				y = y+55;
				this.ACMSRosterDetails1.year = dr1["rYear"].ToString();
				this.ACMSRosterDetails1.WeekNo = dr1["Week_No"].ToString();
				this.ACMSRosterDetails1.lblEmpID.Text = dr1["nEmployeeID"].ToString();
				this.ACMSRosterDetails1.lblJob.Text = "(" + dr1["strJobPositionCode"].ToString() + ")";
				this.ACMSRosterDetails1.lblEmpName.Text = dr1["strEmployeeName"].ToString();
				this.ACMSRosterDetails1.lblEmpDept.Text = "DEPT :" + dr1["DepartmentName"].ToString().ToUpper();
				this.ACMSRosterDetails1.SunTime.Text = ConvertToTime(dr1["sunStartTime"]) + " " + ConvertToTime(dr1["sunEndTime"]);
				this.ACMSRosterDetails1.MonTime.Text = ConvertToTime(dr1["monStartTime"]) + " " + ConvertToTime(dr1["monEndTime"]);
				this.ACMSRosterDetails1.TueTime.Text = ConvertToTime(dr1["tueStartTime"]) + " " + ConvertToTime(dr1["tueEndTime"]) ;
				this.ACMSRosterDetails1.WedTime.Text = ConvertToTime(dr1["wedStartTime"]) + " " + ConvertToTime(dr1["wedEndTime"]);
				this.ACMSRosterDetails1.ThuTime.Text = ConvertToTime(dr1["thuStartTime"]) + " " + ConvertToTime(dr1["thuEndTime"]);
				this.ACMSRosterDetails1.FriTime.Text = ConvertToTime(dr1["friStartTime"]) + " " + ConvertToTime(dr1["friEndTime"]);
				this.ACMSRosterDetails1.SatTime.Text = ConvertToTime(dr1["satStartTime"]) + " " + ConvertToTime(dr1["satEndTime"]);
				this.ACMSRosterDetails1.TotalHourWrk.Text = dr1["totalHour"].ToString();
				this.ACMSRosterDetails1.panelStaffInfo.Visible = isShowStaffInfo;
				this.panelRosterDetails.Controls.Add(ACMSRosterDetails1);
				
				// To Set Grey Color for Multi Shift Roster
				// Monday
				_ds = new DataSet();
				string strSQL="select nRosterID from tblRoster where dtDate='" + dateMon.ToString("yyyy-MM-dd") + "' and nEmployeeID=" + Convert.ToInt32(dr1["nEmployeeID"]);
                SqlHelper.FillDataset(SqlHelperUtils.connectionString,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
				if (_ds.Tables[0].Rows.Count>1)
				{
					ACMSRosterDetails1.panelMON.BackColor = Color.Gray;
				}
				// Tuesday
				_ds = new DataSet();
				strSQL="select nRosterID from tblRoster where dtDate='" + dateTue.ToString("yyyy-MM-dd") + "' and nEmployeeID=" + Convert.ToInt32(dr1["nEmployeeID"]);
				SqlHelper.FillDataset(SqlHelperUtils.connectionString,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
				if (_ds.Tables[0].Rows.Count>1)
				{
					ACMSRosterDetails1.panelTUE.BackColor = Color.Gray;
				}
				// Wednersday
				_ds = new DataSet();
				strSQL="select nRosterID from tblRoster where dtDate='" + dateWed.ToString("yyyy-MM-dd") + "' and nEmployeeID=" + Convert.ToInt32(dr1["nEmployeeID"]);
				SqlHelper.FillDataset(SqlHelperUtils.connectionString,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
				if (_ds.Tables[0].Rows.Count>1)
				{
					ACMSRosterDetails1.panelWED.BackColor = Color.Gray;
				}
				// Thursday
				_ds = new DataSet();
				strSQL="select nRosterID from tblRoster where dtDate='" + dateThu.ToString("yyyy-MM-dd") + "' and nEmployeeID=" + Convert.ToInt32(dr1["nEmployeeID"]);
				SqlHelper.FillDataset(SqlHelperUtils.connectionString,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
				if (_ds.Tables[0].Rows.Count>1)
				{
					ACMSRosterDetails1.panelTHU.BackColor = Color.Gray;
				}
				// Friday
				_ds = new DataSet();
				strSQL="select nRosterID from tblRoster where dtDate='" + dateFri.ToString("yyyy-MM-dd") + "' and nEmployeeID=" + Convert.ToInt32(dr1["nEmployeeID"]);
				SqlHelper.FillDataset(SqlHelperUtils.connectionString,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
				if (_ds.Tables[0].Rows.Count>1)
				{
					ACMSRosterDetails1.panelFRI.BackColor = Color.Gray;
				}
				// Saturday
				_ds = new DataSet();
				strSQL="select nRosterID from tblRoster where dtDate='" + dateSat.ToString("yyyy-MM-dd") + "' and nEmployeeID=" + Convert.ToInt32(dr1["nEmployeeID"]);
				SqlHelper.FillDataset(SqlHelperUtils.connectionString,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
				if (_ds.Tables[0].Rows.Count>1)
				{
					ACMSRosterDetails1.panelSAT.BackColor = Color.Gray;
				}


				// Sunday
				_ds = new DataSet();
				strSQL="select nRosterID from tblRoster where dtDate='" + dateSun.ToString("yyyy-MM-dd") + "' and nEmployeeID=" + Convert.ToInt32(dr1["nEmployeeID"]);
				SqlHelper.FillDataset(SqlHelperUtils.connectionString,CommandType.StoredProcedure,"UP_GETDATA",_ds,new string[] {"Table"}, new SqlParameter("@strSQL", strSQL) );
				if (_ds.Tables[0].Rows.Count>1)
				{
					ACMSRosterDetails1.panelSUN.BackColor = Color.Gray;
				}


				// To Display Leave Color on Roster
				if ( IsShowLeave )
				{
					DateTime startDate, endDate;
					startDate=dateMon;
					endDate = dateSun;

					_ds = new DataSet();

					SqlHelper.FillDataset(SqlHelperUtils.connectionString,CommandType.StoredProcedure,"pr_SelectLeave",_ds,new string[] {"table"}, 
						new SqlParameter("@ddtStartDate", startDate),
						new SqlParameter("@ddtEndDate", endDate),
						new SqlParameter("@inEmployeeID", Convert.ToInt32(dr1["nEmployeeID"]))
						);

					dtLeaveDetails = _ds.Tables[0];
						
					foreach(DataRow row in dtLeaveDetails.Rows)
					{
						SetLeaveColor(row);
					}
				}
			}

			if (dtRosterDetail.Rows.Count == 0)
			{
				this.ACMSRosterDetails1 = new ACMSRosterDetails();
				this.ACMSRosterDetails1.Location = new System.Drawing.Point(0, y);
				this.ACMSRosterDetails1.Name = "ACMSRosterDetails1";
				this.ACMSRosterDetails1.Size = new System.Drawing.Size(792, 54);
				this.ACMSRosterDetails1.TabIndex = 0;
				this.ACMSRosterDetails1.Click += new System.EventHandler(this._Click);
				y = y+55;
				this.ACMSRosterDetails1.year = year;
				this.ACMSRosterDetails1.WeekNo = weekNo;
				this.ACMSRosterDetails1.lblEmpID.Text = string.Empty;
				this.ACMSRosterDetails1.lblEmpName.Text = string.Empty;
				this.ACMSRosterDetails1.lblEmpDept.Text = string.Empty;
				this.ACMSRosterDetails1.SunTime.Text =string.Empty;
				this.ACMSRosterDetails1.MonTime.Text = string.Empty;
				this.ACMSRosterDetails1.TueTime.Text = string.Empty;
				this.ACMSRosterDetails1.WedTime.Text = string.Empty;
				this.ACMSRosterDetails1.ThuTime.Text = string.Empty;
				this.ACMSRosterDetails1.FriTime.Text = string.Empty;
				this.ACMSRosterDetails1.SatTime.Text = string.Empty;
				this.ACMSRosterDetails1.TotalHourWrk.Text = string.Empty;
				this.ACMSRosterDetails1.panelStaffInfo.Visible = false;
				this.panelRosterDetails.Controls.Add(this.ACMSRosterDetails1);
			}
			this.ResumeLayout();
		}

		private string ConvertToTime(object target)
		{
			if (target.ToString() == "" )
				return null;
			else
				return Convert.ToDateTime(target).ToShortTimeString();
		}

		private void _Click(object sender,System.EventArgs e)
		{
			ACMS.Control.ACMSRosterDetails rd = new ACMSRosterDetails();
			rd = (ACMS.Control.ACMSRosterDetails) sender;
			EmpID = rd.lblEmpID.Text;
			year = rd.year;
			WeekNo = rd.WeekNo;
			WeekDay = rd.WeekDay;

			OnClick(e);
		}

		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
		}

		private DataTable _roster;
		private DataTable _rosterDetl;
		private DataTable _leave;
		private string wk;
		private string wd;
		private string id;
		private string yr;
		
		private void ACMSRosterHeader_Load(object sender, System.EventArgs e)
		{
		}
	
		public DataTable dtRoster
		{
			get
			{
				return _roster;
			}
			set
			{
				_roster = value;
			}
		}

		public DataTable dtRosterDetail
		{
			get
			{
				return _rosterDetl;
			}
			set
			{
				_rosterDetl = value;
			}
		}

		public DataTable dtLeaveDetails
		{
			get
			{
				return _leave;
			}
			set
			{
				_leave = value;
			}
		}


		public string EmpID
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}
		public string year
		{
			get
			{
				return yr;
			}
			set
			{
				yr = value;
			}

		}

		public string WeekNo
		{
			get
			{
				return wk;
			}
			set
			{
				wk = value;
			}
		}

		public string WeekDay
		{
			get
			{
				return wd;
			}
			set
			{
				wd = value;
			}
		}

		public bool ShowHeaderLabel
		{
			get
			{
				return lblHdr.Visible;
			}
			set 
			{
				lblHdr.Visible = value;
			}
		}

		public bool IsShowLeave
		{
			get
			{
				return _IsShowLeave;
			}
			set
			{
				_IsShowLeave = value;
			}
		}

		       
		private void SetLeaveColor(DataRow row)
		{
			DateTime dtStartTime = Convert.ToDateTime(row["dtStartTime"]);
			DateTime dtEndTime = Convert.ToDateTime(row["dtEndTime"]);
			DateTime dtStartDate = dtStartTime.Date;
			DateTime dtEndDate = dtEndTime.Date;

			int startWeekDay = (int)dtStartTime.DayOfWeek;
			int endWeekDay = (int)dtEndTime.DayOfWeek;
			bool isTimeOff = row["fTimeOff"] == DBNull.Value ? false : System.Convert.ToBoolean(row["fTimeOff"]);
			int nStatusID = Convert.ToInt32(row["nStatusID"]);
			bool isHalfDay = ACMS.Convert.ToBoolean(row["fFullDay"]) ? false : true;

			if (dateSun.Date >= dtStartDate && dateSun.Date <= dtEndDate) 
			{
				ACMSRosterDetails1.panelSUN.BackColor = LeaveColor(isTimeOff, nStatusID, isHalfDay);
				ACMSRosterDetails1.NLeaveIDSun = Convert.ToInt32(row["nLeaveID"]);
			}
			if (dateMon.Date >= dtStartDate.Date && dateMon.Date <= dtEndDate.Date) 
			{
				ACMSRosterDetails1.panelMON.BackColor = LeaveColor(isTimeOff, nStatusID, isHalfDay);
				ACMSRosterDetails1.NLeaveIDMon = Convert.ToInt32(row["nLeaveID"]);
			}
			if (dateTue.Date >= dtStartDate && dateTue.Date <= dtEndDate) 
			{
				ACMSRosterDetails1.panelTUE.BackColor = LeaveColor(isTimeOff, nStatusID, isHalfDay);
				ACMSRosterDetails1.NLeaveIDTue = Convert.ToInt32(row["nLeaveID"]);
			}
			if (dateWed.Date >= dtStartDate && dateWed.Date <= dtEndDate) 
			{
				ACMSRosterDetails1.panelWED.BackColor = LeaveColor(isTimeOff, nStatusID, isHalfDay);
				ACMSRosterDetails1.NLeaveIDWed = Convert.ToInt32(row["nLeaveID"]);
			}
			if (dateThu.Date >= dtStartDate && dateThu.Date <= dtEndDate) 
			{
				ACMSRosterDetails1.panelTHU.BackColor = LeaveColor(isTimeOff, nStatusID, isHalfDay);
				ACMSRosterDetails1.NLeaveIDThu = Convert.ToInt32(row["nLeaveID"]);
			}
			if (dateFri.Date >= dtStartDate && dateFri.Date <= dtEndDate) 
			{
				ACMSRosterDetails1.panelFRI.BackColor = LeaveColor(isTimeOff, nStatusID, isHalfDay);
				ACMSRosterDetails1.NLeaveIDFri = Convert.ToInt32(row["nLeaveID"]);
			}
			if (dateSat.Date >= dtStartDate && dateSat.Date <= dtEndDate) 
			{
				ACMSRosterDetails1.panelSAT.BackColor = LeaveColor(isTimeOff, nStatusID, isHalfDay);
				ACMSRosterDetails1.NLeaveIDSat = Convert.ToInt32(row["nLeaveID"]);
			}
		}

		private Color LeaveColor(bool fTimeOff, int nStatusID, bool isHalfDay)
		{
			if (nStatusID == 0) //Pending
				return Color.Red;
			else if (fTimeOff)
				return Color.Green;
			else if (isHalfDay)
				return Color.Yellow;
			else
				return Color.LightBlue; //Full day
		}

		

	}
}
