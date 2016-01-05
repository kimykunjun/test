using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ACMS.ACMSManager
{
	/// <summary>
	/// Summary description for frmIPP_View.
	/// </summary>
	public class frmIPP_View : System.Windows.Forms.Form
	{
		internal DevExpress.XtraEditors.SimpleButton btnSave;
		internal DevExpress.XtraEditors.TextEdit txtnMonths;
		internal DevExpress.XtraEditors.TextEdit txtCreditCard;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label CreditCard;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		internal DevExpress.XtraEditors.TextEdit textEdit1;
		internal DevExpress.XtraEditors.TextEdit textEdit2;
		internal DevExpress.XtraEditors.TextEdit textEdit3;
		internal DevExpress.XtraEditors.TextEdit textEdit4;
		internal DevExpress.XtraEditors.TextEdit textEdit5;
		internal DevExpress.XtraEditors.TextEdit textEdit6;
		internal DevExpress.XtraEditors.TextEdit textEdit7;
		internal DevExpress.XtraEditors.TextEdit textEdit8;
		internal DevExpress.XtraEditors.TextEdit textEdit9;
		internal DevExpress.XtraEditors.TextEdit textEdit10;
		internal DevExpress.XtraEditors.TextEdit textEdit11;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmIPP_View()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.txtnMonths = new DevExpress.XtraEditors.TextEdit();
			this.txtCreditCard = new DevExpress.XtraEditors.TextEdit();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.CreditCard = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
			this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
			this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
			this.textEdit4 = new DevExpress.XtraEditors.TextEdit();
			this.textEdit5 = new DevExpress.XtraEditors.TextEdit();
			this.textEdit6 = new DevExpress.XtraEditors.TextEdit();
			this.textEdit7 = new DevExpress.XtraEditors.TextEdit();
			this.textEdit8 = new DevExpress.XtraEditors.TextEdit();
			this.textEdit9 = new DevExpress.XtraEditors.TextEdit();
			this.textEdit10 = new DevExpress.XtraEditors.TextEdit();
			this.textEdit11 = new DevExpress.XtraEditors.TextEdit();
			((System.ComponentModel.ISupportInitialize)(this.txtnMonths.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreditCard.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit5.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit6.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit7.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit8.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit9.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit10.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit11.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.btnSave.Location = new System.Drawing.Point(552, 184);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(72, 20);
			this.btnSave.TabIndex = 31;
			this.btnSave.Text = "Cancel";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// txtnMonths
			// 
			this.txtnMonths.EditValue = "";
			this.txtnMonths.Location = new System.Drawing.Point(160, 32);
			this.txtnMonths.Name = "txtnMonths";
			// 
			// txtnMonths.Properties
			// 
			this.txtnMonths.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtnMonths.Properties.Appearance.Options.UseFont = true;
			this.txtnMonths.Properties.MaxLength = 19;
			this.txtnMonths.Properties.ReadOnly = true;
			this.txtnMonths.Size = new System.Drawing.Size(152, 22);
			this.txtnMonths.TabIndex = 30;
			// 
			// txtCreditCard
			// 
			this.txtCreditCard.EditValue = "";
			this.txtCreditCard.Location = new System.Drawing.Point(160, 56);
			this.txtCreditCard.Name = "txtCreditCard";
			// 
			// txtCreditCard.Properties
			// 
			this.txtCreditCard.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtCreditCard.Properties.Appearance.Options.UseFont = true;
			this.txtCreditCard.Properties.MaxLength = 19;
			this.txtCreditCard.Properties.ReadOnly = true;
			this.txtCreditCard.Size = new System.Drawing.Size(152, 22);
			this.txtCreditCard.TabIndex = 29;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.Location = new System.Drawing.Point(24, 80);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(116, 23);
			this.label5.TabIndex = 27;
			this.label5.Text = "Member Id";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(24, 128);
			this.label4.Name = "label4";
			this.label4.TabIndex = 25;
			this.label4.Text = "Bank Code";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(24, 176);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 23);
			this.label2.TabIndex = 24;
			this.label2.Text = "Number of Months";
			// 
			// CreditCard
			// 
			this.CreditCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.CreditCard.Location = new System.Drawing.Point(24, 152);
			this.CreditCard.Name = "CreditCard";
			this.CreditCard.TabIndex = 23;
			this.CreditCard.Text = "Credit Card No";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(24, 104);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(116, 23);
			this.label1.TabIndex = 35;
			this.label1.Text = "Member Name ";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(328, 32);
			this.label3.Name = "label3";
			this.label3.TabIndex = 34;
			this.label3.Text = "Amount";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.Location = new System.Drawing.Point(328, 80);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(120, 23);
			this.label6.TabIndex = 33;
			this.label6.Text = "Nett Amount";
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label7.Location = new System.Drawing.Point(328, 56);
			this.label7.Name = "label7";
			this.label7.TabIndex = 32;
			this.label7.Text = "Interest";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label8.Location = new System.Drawing.Point(328, 104);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(116, 23);
			this.label8.TabIndex = 39;
			this.label8.Text = "Date Sent To Bank";
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label9.Location = new System.Drawing.Point(24, 32);
			this.label9.Name = "label9";
			this.label9.TabIndex = 38;
			this.label9.Text = "IPP Id";
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label10.Location = new System.Drawing.Point(328, 128);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(120, 23);
			this.label10.TabIndex = 37;
			this.label10.Text = "Date Received Reply";
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label11.Location = new System.Drawing.Point(328, 152);
			this.label11.Name = "label11";
			this.label11.TabIndex = 36;
			this.label11.Text = "Status";
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label12.Location = new System.Drawing.Point(24, 56);
			this.label12.Name = "label12";
			this.label12.TabIndex = 40;
			this.label12.Text = "Date Created";
			// 
			// textEdit1
			// 
			this.textEdit1.EditValue = "";
			this.textEdit1.Location = new System.Drawing.Point(160, 80);
			this.textEdit1.Name = "textEdit1";
			// 
			// textEdit1.Properties
			// 
			this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textEdit1.Properties.Appearance.Options.UseFont = true;
			this.textEdit1.Properties.MaxLength = 19;
			this.textEdit1.Properties.ReadOnly = true;
			this.textEdit1.Size = new System.Drawing.Size(152, 22);
			this.textEdit1.TabIndex = 41;
			// 
			// textEdit2
			// 
			this.textEdit2.EditValue = "";
			this.textEdit2.Location = new System.Drawing.Point(160, 104);
			this.textEdit2.Name = "textEdit2";
			// 
			// textEdit2.Properties
			// 
			this.textEdit2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textEdit2.Properties.Appearance.Options.UseFont = true;
			this.textEdit2.Properties.MaxLength = 19;
			this.textEdit2.Properties.ReadOnly = true;
			this.textEdit2.Size = new System.Drawing.Size(152, 22);
			this.textEdit2.TabIndex = 42;
			// 
			// textEdit3
			// 
			this.textEdit3.EditValue = "";
			this.textEdit3.Location = new System.Drawing.Point(160, 128);
			this.textEdit3.Name = "textEdit3";
			// 
			// textEdit3.Properties
			// 
			this.textEdit3.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textEdit3.Properties.Appearance.Options.UseFont = true;
			this.textEdit3.Properties.MaxLength = 19;
			this.textEdit3.Properties.ReadOnly = true;
			this.textEdit3.Size = new System.Drawing.Size(152, 22);
			this.textEdit3.TabIndex = 43;
			// 
			// textEdit4
			// 
			this.textEdit4.EditValue = "";
			this.textEdit4.Location = new System.Drawing.Point(160, 152);
			this.textEdit4.Name = "textEdit4";
			// 
			// textEdit4.Properties
			// 
			this.textEdit4.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textEdit4.Properties.Appearance.Options.UseFont = true;
			this.textEdit4.Properties.MaxLength = 19;
			this.textEdit4.Properties.ReadOnly = true;
			this.textEdit4.Size = new System.Drawing.Size(152, 22);
			this.textEdit4.TabIndex = 44;
			// 
			// textEdit5
			// 
			this.textEdit5.EditValue = "";
			this.textEdit5.Location = new System.Drawing.Point(472, 152);
			this.textEdit5.Name = "textEdit5";
			// 
			// textEdit5.Properties
			// 
			this.textEdit5.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textEdit5.Properties.Appearance.Options.UseFont = true;
			this.textEdit5.Properties.MaxLength = 19;
			this.textEdit5.Properties.ReadOnly = true;
			this.textEdit5.Size = new System.Drawing.Size(152, 22);
			this.textEdit5.TabIndex = 50;
			// 
			// textEdit6
			// 
			this.textEdit6.EditValue = "";
			this.textEdit6.Location = new System.Drawing.Point(472, 128);
			this.textEdit6.Name = "textEdit6";
			// 
			// textEdit6.Properties
			// 
			this.textEdit6.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textEdit6.Properties.Appearance.Options.UseFont = true;
			this.textEdit6.Properties.MaxLength = 19;
			this.textEdit6.Properties.ReadOnly = true;
			this.textEdit6.Size = new System.Drawing.Size(152, 22);
			this.textEdit6.TabIndex = 49;
			// 
			// textEdit7
			// 
			this.textEdit7.EditValue = "";
			this.textEdit7.Location = new System.Drawing.Point(472, 104);
			this.textEdit7.Name = "textEdit7";
			// 
			// textEdit7.Properties
			// 
			this.textEdit7.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textEdit7.Properties.Appearance.Options.UseFont = true;
			this.textEdit7.Properties.MaxLength = 19;
			this.textEdit7.Properties.ReadOnly = true;
			this.textEdit7.Size = new System.Drawing.Size(152, 22);
			this.textEdit7.TabIndex = 48;
			// 
			// textEdit8
			// 
			this.textEdit8.EditValue = "";
			this.textEdit8.Location = new System.Drawing.Point(472, 80);
			this.textEdit8.Name = "textEdit8";
			// 
			// textEdit8.Properties
			// 
			this.textEdit8.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textEdit8.Properties.Appearance.Options.UseFont = true;
			this.textEdit8.Properties.MaxLength = 19;
			this.textEdit8.Properties.ReadOnly = true;
			this.textEdit8.Size = new System.Drawing.Size(152, 22);
			this.textEdit8.TabIndex = 47;
			// 
			// textEdit9
			// 
			this.textEdit9.EditValue = "";
			this.textEdit9.Location = new System.Drawing.Point(472, 32);
			this.textEdit9.Name = "textEdit9";
			// 
			// textEdit9.Properties
			// 
			this.textEdit9.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textEdit9.Properties.Appearance.Options.UseFont = true;
			this.textEdit9.Properties.MaxLength = 19;
			this.textEdit9.Properties.ReadOnly = true;
			this.textEdit9.Size = new System.Drawing.Size(152, 22);
			this.textEdit9.TabIndex = 46;
			// 
			// textEdit10
			// 
			this.textEdit10.EditValue = "";
			this.textEdit10.Location = new System.Drawing.Point(472, 56);
			this.textEdit10.Name = "textEdit10";
			// 
			// textEdit10.Properties
			// 
			this.textEdit10.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textEdit10.Properties.Appearance.Options.UseFont = true;
			this.textEdit10.Properties.MaxLength = 19;
			this.textEdit10.Properties.ReadOnly = true;
			this.textEdit10.Size = new System.Drawing.Size(152, 22);
			this.textEdit10.TabIndex = 45;
			// 
			// textEdit11
			// 
			this.textEdit11.EditValue = "";
			this.textEdit11.Location = new System.Drawing.Point(160, 176);
			this.textEdit11.Name = "textEdit11";
			// 
			// textEdit11.Properties
			// 
			this.textEdit11.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textEdit11.Properties.Appearance.Options.UseFont = true;
			this.textEdit11.Properties.MaxLength = 19;
			this.textEdit11.Properties.ReadOnly = true;
			this.textEdit11.Size = new System.Drawing.Size(152, 22);
			this.textEdit11.TabIndex = 51;
			// 
			// frmIPP_View
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(648, 254);
			this.Controls.Add(this.textEdit11);
			this.Controls.Add(this.textEdit5);
			this.Controls.Add(this.textEdit6);
			this.Controls.Add(this.textEdit7);
			this.Controls.Add(this.textEdit8);
			this.Controls.Add(this.textEdit9);
			this.Controls.Add(this.textEdit10);
			this.Controls.Add(this.textEdit4);
			this.Controls.Add(this.textEdit3);
			this.Controls.Add(this.textEdit2);
			this.Controls.Add(this.textEdit1);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.txtnMonths);
			this.Controls.Add(this.txtCreditCard);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.CreditCard);
			this.Name = "frmIPP_View";
			this.Text = "View IPP Details";
			((System.ComponentModel.ISupportInitialize)(this.txtnMonths.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreditCard.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit5.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit6.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit7.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit8.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit9.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit10.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEdit11.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
