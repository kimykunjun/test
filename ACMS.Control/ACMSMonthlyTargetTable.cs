using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace ACMS.Control
{
	/// <summary>
	/// Summary description for ACMSMonthlyTargetTable.
	/// </summary>
	public class ACMSMonthlyTargetTable : System.Windows.Forms.UserControl
	{
		#region user variable
		private DataTable _dt;
		public DataTable MonthTargetDataTable
		{
			get{return _dt;}
			set{_dt=value;}
		}
		#endregion

		#region window control
		private DevExpress.XtraEditors.TextEdit BT4;
		private DevExpress.XtraEditors.TextEdit BT12;
		private DevExpress.XtraEditors.TextEdit BT11;
		private DevExpress.XtraEditors.TextEdit BT10;
		private DevExpress.XtraEditors.TextEdit BT9;
		private DevExpress.XtraEditors.TextEdit BT8;
		private DevExpress.XtraEditors.TextEdit BT7;
		private DevExpress.XtraEditors.TextEdit BT6;
		private DevExpress.XtraEditors.TextEdit BT5;
		private DevExpress.XtraEditors.TextEdit BT3;
		private DevExpress.XtraEditors.TextEdit BT2;
		private DevExpress.XtraEditors.TextEdit BT1;
		private System.Windows.Forms.Label label81;
		private System.Windows.Forms.Label label86;
		private System.Windows.Forms.Label label87;
		private System.Windows.Forms.Label label88;
		private System.Windows.Forms.Label label89;
		private System.Windows.Forms.Label label90;
		private System.Windows.Forms.Label label98;
		private System.Windows.Forms.Label label99;
		private System.Windows.Forms.Label label100;
		private System.Windows.Forms.Label label101;
		private System.Windows.Forms.Label WEEKFOUR;
		private System.Windows.Forms.Label WEEKTHREE;
		private System.Windows.Forms.Label WEEKTWO;
		private System.Windows.Forms.Label label102;
		private System.Windows.Forms.Label label103;
		private System.Windows.Forms.Label WEEKONE;
		private System.Windows.Forms.Label label104;
		private System.Windows.Forms.Label label105;
		#endregion


		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ACMSMonthlyTargetTable()
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
			this.BT4 = new DevExpress.XtraEditors.TextEdit();
			this.BT12 = new DevExpress.XtraEditors.TextEdit();
			this.BT11 = new DevExpress.XtraEditors.TextEdit();
			this.BT10 = new DevExpress.XtraEditors.TextEdit();
			this.BT9 = new DevExpress.XtraEditors.TextEdit();
			this.BT8 = new DevExpress.XtraEditors.TextEdit();
			this.BT7 = new DevExpress.XtraEditors.TextEdit();
			this.BT6 = new DevExpress.XtraEditors.TextEdit();
			this.BT5 = new DevExpress.XtraEditors.TextEdit();
			this.BT3 = new DevExpress.XtraEditors.TextEdit();
			this.BT2 = new DevExpress.XtraEditors.TextEdit();
			this.BT1 = new DevExpress.XtraEditors.TextEdit();
			this.label81 = new System.Windows.Forms.Label();
			this.label86 = new System.Windows.Forms.Label();
			this.label87 = new System.Windows.Forms.Label();
			this.label88 = new System.Windows.Forms.Label();
			this.label89 = new System.Windows.Forms.Label();
			this.label90 = new System.Windows.Forms.Label();
			this.label98 = new System.Windows.Forms.Label();
			this.label99 = new System.Windows.Forms.Label();
			this.label100 = new System.Windows.Forms.Label();
			this.label101 = new System.Windows.Forms.Label();
			this.WEEKFOUR = new System.Windows.Forms.Label();
			this.WEEKTHREE = new System.Windows.Forms.Label();
			this.WEEKTWO = new System.Windows.Forms.Label();
			this.label102 = new System.Windows.Forms.Label();
			this.label103 = new System.Windows.Forms.Label();
			this.WEEKONE = new System.Windows.Forms.Label();
			this.label104 = new System.Windows.Forms.Label();
			this.label105 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.BT4.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BT12.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BT11.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BT10.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BT9.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BT8.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BT7.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BT6.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BT5.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BT3.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BT2.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BT1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// BT4
			// 
			this.BT4.EditValue = "0.00";
			this.BT4.Location = new System.Drawing.Point(232, 48);
			this.BT4.Name = "BT4";
			// 
			// BT4.Properties
			// 
			this.BT4.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BT4.Properties.Appearance.Options.UseFont = true;
			this.BT4.Properties.Appearance.Options.UseTextOptions = true;
			this.BT4.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.BT4.Properties.DisplayFormat.FormatString = "f2";
			this.BT4.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.BT4.Properties.Mask.EditMask = "f2";
			this.BT4.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.BT4.Properties.ReadOnly = true;
			this.BT4.Size = new System.Drawing.Size(72, 22);
			this.BT4.TabIndex = 62;
			// 
			// BT12
			// 
			this.BT12.EditValue = "0.00";
			this.BT12.Location = new System.Drawing.Point(840, 48);
			this.BT12.Name = "BT12";
			// 
			// BT12.Properties
			// 
			this.BT12.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BT12.Properties.Appearance.Options.UseFont = true;
			this.BT12.Properties.Appearance.Options.UseTextOptions = true;
			this.BT12.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.BT12.Properties.DisplayFormat.FormatString = "f2";
			this.BT12.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.BT12.Properties.Mask.EditMask = "f2";
			this.BT12.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.BT12.Properties.ReadOnly = true;
			this.BT12.Size = new System.Drawing.Size(112, 22);
			this.BT12.TabIndex = 61;
			// 
			// BT11
			// 
			this.BT11.EditValue = "0.00";
			this.BT11.Location = new System.Drawing.Point(768, 48);
			this.BT11.Name = "BT11";
			// 
			// BT11.Properties
			// 
			this.BT11.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BT11.Properties.Appearance.Options.UseFont = true;
			this.BT11.Properties.Appearance.Options.UseTextOptions = true;
			this.BT11.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.BT11.Properties.DisplayFormat.FormatString = "f2";
			this.BT11.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.BT11.Properties.Mask.EditMask = "f2";
			this.BT11.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.BT11.Properties.ReadOnly = true;
			this.BT11.Size = new System.Drawing.Size(72, 22);
			this.BT11.TabIndex = 60;
			// 
			// BT10
			// 
			this.BT10.EditValue = "0.00";
			this.BT10.Location = new System.Drawing.Point(688, 48);
			this.BT10.Name = "BT10";
			// 
			// BT10.Properties
			// 
			this.BT10.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BT10.Properties.Appearance.Options.UseFont = true;
			this.BT10.Properties.Appearance.Options.UseTextOptions = true;
			this.BT10.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.BT10.Properties.DisplayFormat.FormatString = "f2";
			this.BT10.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.BT10.Properties.Mask.EditMask = "f2";
			this.BT10.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.BT10.Properties.ReadOnly = true;
			this.BT10.Size = new System.Drawing.Size(80, 22);
			this.BT10.TabIndex = 59;
			// 
			// BT9
			// 
			this.BT9.EditValue = "0.00";
			this.BT9.Location = new System.Drawing.Point(608, 48);
			this.BT9.Name = "BT9";
			// 
			// BT9.Properties
			// 
			this.BT9.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BT9.Properties.Appearance.Options.UseFont = true;
			this.BT9.Properties.Appearance.Options.UseTextOptions = true;
			this.BT9.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.BT9.Properties.DisplayFormat.FormatString = "f2";
			this.BT9.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.BT9.Properties.Mask.EditMask = "f2";
			this.BT9.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.BT9.Properties.ReadOnly = true;
			this.BT9.Size = new System.Drawing.Size(80, 22);
			this.BT9.TabIndex = 58;
			// 
			// BT8
			// 
			this.BT8.EditValue = "0.00";
			this.BT8.Location = new System.Drawing.Point(536, 48);
			this.BT8.Name = "BT8";
			// 
			// BT8.Properties
			// 
			this.BT8.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BT8.Properties.Appearance.Options.UseFont = true;
			this.BT8.Properties.Appearance.Options.UseTextOptions = true;
			this.BT8.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.BT8.Properties.DisplayFormat.FormatString = "f2";
			this.BT8.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.BT8.Properties.Mask.EditMask = "f2";
			this.BT8.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.BT8.Properties.ReadOnly = true;
			this.BT8.Size = new System.Drawing.Size(72, 22);
			this.BT8.TabIndex = 57;
			// 
			// BT7
			// 
			this.BT7.EditValue = "0.00";
			this.BT7.Location = new System.Drawing.Point(456, 48);
			this.BT7.Name = "BT7";
			// 
			// BT7.Properties
			// 
			this.BT7.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BT7.Properties.Appearance.Options.UseFont = true;
			this.BT7.Properties.Appearance.Options.UseTextOptions = true;
			this.BT7.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.BT7.Properties.DisplayFormat.FormatString = "f2";
			this.BT7.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.BT7.Properties.Mask.EditMask = "f2";
			this.BT7.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.BT7.Properties.ReadOnly = true;
			this.BT7.Size = new System.Drawing.Size(80, 22);
			this.BT7.TabIndex = 56;
			// 
			// BT6
			// 
			this.BT6.EditValue = "0.00";
			this.BT6.Location = new System.Drawing.Point(384, 48);
			this.BT6.Name = "BT6";
			// 
			// BT6.Properties
			// 
			this.BT6.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BT6.Properties.Appearance.Options.UseFont = true;
			this.BT6.Properties.Appearance.Options.UseTextOptions = true;
			this.BT6.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.BT6.Properties.DisplayFormat.FormatString = "f2";
			this.BT6.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.BT6.Properties.Mask.EditMask = "f2";
			this.BT6.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.BT6.Properties.ReadOnly = true;
			this.BT6.Size = new System.Drawing.Size(72, 22);
			this.BT6.TabIndex = 55;
			// 
			// BT5
			// 
			this.BT5.EditValue = "0.00";
			this.BT5.Location = new System.Drawing.Point(304, 48);
			this.BT5.Name = "BT5";
			// 
			// BT5.Properties
			// 
			this.BT5.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BT5.Properties.Appearance.Options.UseFont = true;
			this.BT5.Properties.Appearance.Options.UseTextOptions = true;
			this.BT5.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.BT5.Properties.DisplayFormat.FormatString = "f2";
			this.BT5.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.BT5.Properties.Mask.EditMask = "f2";
			this.BT5.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.BT5.Properties.ReadOnly = true;
			this.BT5.Size = new System.Drawing.Size(80, 22);
			this.BT5.TabIndex = 54;
			// 
			// BT3
			// 
			this.BT3.EditValue = "0.00";
			this.BT3.Location = new System.Drawing.Point(152, 48);
			this.BT3.Name = "BT3";
			// 
			// BT3.Properties
			// 
			this.BT3.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BT3.Properties.Appearance.Options.UseFont = true;
			this.BT3.Properties.Appearance.Options.UseTextOptions = true;
			this.BT3.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.BT3.Properties.DisplayFormat.FormatString = "f2";
			this.BT3.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.BT3.Properties.Mask.EditMask = "f2";
			this.BT3.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.BT3.Properties.ReadOnly = true;
			this.BT3.Size = new System.Drawing.Size(80, 22);
			this.BT3.TabIndex = 53;
			// 
			// BT2
			// 
			this.BT2.EditValue = "0.00";
			this.BT2.Location = new System.Drawing.Point(80, 48);
			this.BT2.Name = "BT2";
			// 
			// BT2.Properties
			// 
			this.BT2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BT2.Properties.Appearance.Options.UseFont = true;
			this.BT2.Properties.Appearance.Options.UseTextOptions = true;
			this.BT2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.BT2.Properties.DisplayFormat.FormatString = "f2";
			this.BT2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.BT2.Properties.ReadOnly = true;
			this.BT2.Size = new System.Drawing.Size(72, 22);
			this.BT2.TabIndex = 52;
			// 
			// BT1
			// 
			this.BT1.EditValue = "0.00";
			this.BT1.Location = new System.Drawing.Point(0, 48);
			this.BT1.Name = "BT1";
			// 
			// BT1.Properties
			// 
			this.BT1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BT1.Properties.Appearance.Options.UseFont = true;
			this.BT1.Properties.Appearance.Options.UseTextOptions = true;
			this.BT1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.BT1.Properties.DisplayFormat.FormatString = "f2";
			this.BT1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.BT1.Properties.Mask.EditMask = "n2";
			this.BT1.Properties.ReadOnly = true;
			this.BT1.Size = new System.Drawing.Size(80, 22);
			this.BT1.TabIndex = 51;
			// 
			// label81
			// 
			this.label81.BackColor = System.Drawing.Color.Transparent;
			this.label81.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label81.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label81.Location = new System.Drawing.Point(840, 0);
			this.label81.Name = "label81";
			this.label81.Size = new System.Drawing.Size(112, 47);
			this.label81.TabIndex = 50;
			this.label81.Text = "TOTAL REVENUE";
			this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label86
			// 
			this.label86.BackColor = System.Drawing.Color.Transparent;
			this.label86.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label86.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label86.Location = new System.Drawing.Point(768, 24);
			this.label86.Name = "label86";
			this.label86.Size = new System.Drawing.Size(72, 23);
			this.label86.TabIndex = 49;
			this.label86.Text = "MONTH";
			this.label86.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label87
			// 
			this.label87.BackColor = System.Drawing.Color.Transparent;
			this.label87.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label87.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label87.Location = new System.Drawing.Point(688, 24);
			this.label87.Name = "label87";
			this.label87.Size = new System.Drawing.Size(80, 23);
			this.label87.TabIndex = 48;
			this.label87.Text = "THIS WEEK";
			this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label88
			// 
			this.label88.BackColor = System.Drawing.Color.Transparent;
			this.label88.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label88.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label88.Location = new System.Drawing.Point(688, 0);
			this.label88.Name = "label88";
			this.label88.Size = new System.Drawing.Size(152, 23);
			this.label88.TabIndex = 47;
			this.label88.Text = "DAILY TARGET";
			this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label89
			// 
			this.label89.BackColor = System.Drawing.Color.Transparent;
			this.label89.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label89.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label89.Location = new System.Drawing.Point(608, 24);
			this.label89.Name = "label89";
			this.label89.Size = new System.Drawing.Size(80, 23);
			this.label89.TabIndex = 46;
			this.label89.Text = "ACTUAL";
			this.label89.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label90
			// 
			this.label90.BackColor = System.Drawing.Color.Transparent;
			this.label90.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label90.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label90.Location = new System.Drawing.Point(536, 24);
			this.label90.Name = "label90";
			this.label90.Size = new System.Drawing.Size(72, 23);
			this.label90.TabIndex = 45;
			this.label90.Text = "15%";
			this.label90.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label98
			// 
			this.label98.BackColor = System.Drawing.Color.Transparent;
			this.label98.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label98.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label98.Location = new System.Drawing.Point(456, 24);
			this.label98.Name = "label98";
			this.label98.Size = new System.Drawing.Size(80, 23);
			this.label98.TabIndex = 44;
			this.label98.Text = "ACTUAL";
			this.label98.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label99
			// 
			this.label99.BackColor = System.Drawing.Color.Transparent;
			this.label99.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label99.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label99.Location = new System.Drawing.Point(384, 24);
			this.label99.Name = "label99";
			this.label99.Size = new System.Drawing.Size(72, 23);
			this.label99.TabIndex = 43;
			this.label99.Text = "25%";
			this.label99.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label100
			// 
			this.label100.BackColor = System.Drawing.Color.Transparent;
			this.label100.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label100.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label100.Location = new System.Drawing.Point(304, 24);
			this.label100.Name = "label100";
			this.label100.Size = new System.Drawing.Size(80, 23);
			this.label100.TabIndex = 42;
			this.label100.Text = "ACTUAL";
			this.label100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label101
			// 
			this.label101.BackColor = System.Drawing.Color.Transparent;
			this.label101.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label101.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label101.Location = new System.Drawing.Point(232, 24);
			this.label101.Name = "label101";
			this.label101.Size = new System.Drawing.Size(72, 23);
			this.label101.TabIndex = 41;
			this.label101.Text = "30%";
			this.label101.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// WEEKFOUR
			// 
			this.WEEKFOUR.BackColor = System.Drawing.Color.Transparent;
			this.WEEKFOUR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.WEEKFOUR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.WEEKFOUR.Location = new System.Drawing.Point(536, 0);
			this.WEEKFOUR.Name = "WEEKFOUR";
			this.WEEKFOUR.Size = new System.Drawing.Size(152, 23);
			this.WEEKFOUR.TabIndex = 40;
			this.WEEKFOUR.Text = "03 MAY 06 - 30 MAY 06";
			this.WEEKFOUR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// WEEKTHREE
			// 
			this.WEEKTHREE.BackColor = System.Drawing.Color.Transparent;
			this.WEEKTHREE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.WEEKTHREE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.WEEKTHREE.Location = new System.Drawing.Point(384, 0);
			this.WEEKTHREE.Name = "WEEKTHREE";
			this.WEEKTHREE.Size = new System.Drawing.Size(152, 23);
			this.WEEKTHREE.TabIndex = 39;
			this.WEEKTHREE.Text = "03 MAY 06 - 30 MAY 06";
			this.WEEKTHREE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// WEEKTWO
			// 
			this.WEEKTWO.BackColor = System.Drawing.Color.Transparent;
			this.WEEKTWO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.WEEKTWO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.WEEKTWO.Location = new System.Drawing.Point(232, 0);
			this.WEEKTWO.Name = "WEEKTWO";
			this.WEEKTWO.Size = new System.Drawing.Size(152, 23);
			this.WEEKTWO.TabIndex = 38;
			this.WEEKTWO.Text = "03 MAY 06 - 30 MAY 06";
			this.WEEKTWO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label102
			// 
			this.label102.BackColor = System.Drawing.Color.Transparent;
			this.label102.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label102.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label102.Location = new System.Drawing.Point(152, 24);
			this.label102.Name = "label102";
			this.label102.Size = new System.Drawing.Size(80, 23);
			this.label102.TabIndex = 37;
			this.label102.Text = "ACTUAL";
			this.label102.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label103
			// 
			this.label103.BackColor = System.Drawing.Color.Transparent;
			this.label103.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label103.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label103.Location = new System.Drawing.Point(80, 24);
			this.label103.Name = "label103";
			this.label103.Size = new System.Drawing.Size(72, 23);
			this.label103.TabIndex = 36;
			this.label103.Text = "30%";
			this.label103.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// WEEKONE
			// 
			this.WEEKONE.BackColor = System.Drawing.Color.Transparent;
			this.WEEKONE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.WEEKONE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.WEEKONE.Location = new System.Drawing.Point(80, 0);
			this.WEEKONE.Name = "WEEKONE";
			this.WEEKONE.Size = new System.Drawing.Size(152, 23);
			this.WEEKONE.TabIndex = 35;
			this.WEEKONE.Text = "03 MAY 06 - 30 MAY 06";
			this.WEEKONE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label104
			// 
			this.label104.BackColor = System.Drawing.Color.Transparent;
			this.label104.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label104.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label104.Location = new System.Drawing.Point(0, 24);
			this.label104.Name = "label104";
			this.label104.Size = new System.Drawing.Size(88, 23);
			this.label104.TabIndex = 34;
			this.label104.Text = "TARGET";
			this.label104.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label105
			// 
			this.label105.BackColor = System.Drawing.Color.Transparent;
			this.label105.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label105.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label105.Location = new System.Drawing.Point(0, 0);
			this.label105.Name = "label105";
			this.label105.Size = new System.Drawing.Size(88, 23);
			this.label105.TabIndex = 33;
			this.label105.Text = "MONTHLY";
			this.label105.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ACMSMonthlyTargetTable
			// 
			this.Controls.Add(this.BT4);
			this.Controls.Add(this.BT12);
			this.Controls.Add(this.BT11);
			this.Controls.Add(this.BT10);
			this.Controls.Add(this.BT9);
			this.Controls.Add(this.BT8);
			this.Controls.Add(this.BT7);
			this.Controls.Add(this.BT6);
			this.Controls.Add(this.BT5);
			this.Controls.Add(this.BT3);
			this.Controls.Add(this.BT2);
			this.Controls.Add(this.BT1);
			this.Controls.Add(this.label81);
			this.Controls.Add(this.label86);
			this.Controls.Add(this.label87);
			this.Controls.Add(this.label88);
			this.Controls.Add(this.label89);
			this.Controls.Add(this.label90);
			this.Controls.Add(this.label98);
			this.Controls.Add(this.label99);
			this.Controls.Add(this.label100);
			this.Controls.Add(this.label101);
			this.Controls.Add(this.WEEKFOUR);
			this.Controls.Add(this.WEEKTHREE);
			this.Controls.Add(this.WEEKTWO);
			this.Controls.Add(this.label102);
			this.Controls.Add(this.label103);
			this.Controls.Add(this.WEEKONE);
			this.Controls.Add(this.label104);
			this.Controls.Add(this.label105);
			this.Name = "ACMSMonthlyTargetTable";
			this.Size = new System.Drawing.Size(840, 72);
			this.Load += new System.EventHandler(this.ACMSMonthlyTargetTable_Load);
			((System.ComponentModel.ISupportInitialize)(this.BT4.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BT12.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BT11.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BT10.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BT9.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BT8.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BT7.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BT6.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BT5.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BT3.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BT2.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BT1.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		private string GetMonthDesc(int Month)
		{
			if (Month==1)
			{
				return "Jan";
			}
			else if (Month==2)
			{
				return "Feb";
			}
			else if (Month==3)
			{
				return "Mac";
			}
			else if (Month==4)
			{
				return "Apr";
			}
			else if (Month==5)
			{
				return "May";
			}
			else if (Month==6)
			{
				return "Jun";
			}
			else if (Month==7)
			{
				return "July";
			}
			else if( Month==8)
			{
				return "Aug";
			}
			else if (Month==9)
			{
				return "Sept";
			}
			else if (Month==10)
			{
				return "Oct";
			}
			else if (Month==11)
			{
				return "Nov";
			}
			else if (Month==12)
			{
				return "Dec";
			}
			return "";
						  
		}

		public void init()
		{
			WEEKONE.Text = string.Format("{0}","01 " + GetMonthDesc(DateTime.Today.Month) + " " + DateTime.Today.ToString("yy") + " - " + "07 " + GetMonthDesc(DateTime.Today.Month) + " " + DateTime.Today.ToString("yy"));
			WEEKTWO.Text = string.Format("{0}","08 " + GetMonthDesc(DateTime.Today.Month) + " " + DateTime.Today.ToString("yy") + " - " + "14 " + GetMonthDesc(DateTime.Today.Month) + " " + DateTime.Today.ToString("yy"));
			WEEKTHREE.Text = string.Format("{0}","15 " + GetMonthDesc(DateTime.Today.Month) + " " + DateTime.Today.ToString("yy") + " - " + "21 " + GetMonthDesc(DateTime.Today.Month) + " " + DateTime.Today.ToString("yy"));
			WEEKFOUR.Text = string.Format("{0}","22 " + GetMonthDesc(DateTime.Today.Month) + " " + DateTime.Today.ToString("yy") + " - " + DateTime.DaysInMonth(DateTime.Today.Year,DateTime.Today.Month) + GetMonthDesc(DateTime.Today.Month) + " " + DateTime.Today.ToString("yy"));
			foreach(DataRow dr in MonthTargetDataTable.Rows)
			{
				BT1.EditValue = dr["MONTHLY_TARGET"];
				BT2.EditValue = dr["WEEK1TARGET"];
				BT3.EditValue = dr["WEEK1REVENUE"];
				BT4.EditValue = dr["WEEK2TARGET"];
				BT5.EditValue = dr["WEEK2REVENUE"];
				BT6.EditValue = dr["WEEK3TARGET"];
				BT7.EditValue = dr["WEEK3REVENUE"];
				BT8.EditValue = dr["WEEK4TARGET"];
				BT9.EditValue = dr["WEEK4REVENUE"];
				BT10.EditValue = dr["WEEKLY_DAILYAVERAGE"];
				BT11.EditValue = dr["MONHTLY_DAILYAVERAGE"];
				BT12.EditValue = dr["TOTAL_REVENUE"];
			
			}
		}

		private void ACMSMonthlyTargetTable_Load(object sender, System.EventArgs e)
		{
			
		}
	
	}
}
