using System.IO;
using System;
namespace ACMS.ACMSBranch
{
    partial class DigSignature
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtImageBinary = new System.Windows.Forms.TextBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.SigPlusNET1 = new Topaz.SigPlusNET();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtImageBinary
            // 
            this.txtImageBinary.Location = new System.Drawing.Point(451, 15);
            this.txtImageBinary.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtImageBinary.Name = "txtImageBinary";
            this.txtImageBinary.Size = new System.Drawing.Size(97, 22);
            this.txtImageBinary.TabIndex = 37;
            this.txtImageBinary.Visible = false;
            // 
            // cmdClose
            // 
			//this.cmdClose.Enabled = false;
            this.cmdClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Location = new System.Drawing.Point(370, 192);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(115, 46);
            this.cmdClose.TabIndex = 36;
            this.cmdClose.Text = "PRINT LATER";
			//this.cmdClose.Visible = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // SigPlusNET1
            // 
            this.SigPlusNET1.BackColor = System.Drawing.Color.White;
            this.SigPlusNET1.ForeColor = System.Drawing.Color.Black;
            this.SigPlusNET1.Location = new System.Drawing.Point(36, 15);
            this.SigPlusNET1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SigPlusNET1.Name = "SigPlusNET1";
            this.SigPlusNET1.Size = new System.Drawing.Size(427, 167);
            this.SigPlusNET1.TabIndex = 30;
            this.SigPlusNET1.Text = "sigPlusNET2";
            this.SigPlusNET1.PenUp += new System.EventHandler(this.SigPlusNET1_PenUp);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(138, 192);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(115, 46);
            this.btnClear.TabIndex = 28;
            this.btnClear.Text = "C L E A R";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(254, 192);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(115, 46);
            this.btnPrint.TabIndex = 26;
            this.btnPrint.Text = "P R I N T";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRefresh.Location = new System.Drawing.Point(23, 192);
            this.cmdRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(115, 46);
            this.cmdRefresh.TabIndex = 38;
            this.cmdRefresh.Text = "S I G N";
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // DigSignature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 252);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.SigPlusNET1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtImageBinary);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DigSignature";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Digital Signature";

            //File.AppendAllText(@"C:\\Test\log.txt", "DigSignature_Load - " + DateTime.Now + Environment.NewLine);
            this.Load += new System.EventHandler(this.DigSignature_Load);
            //File.AppendAllText(@"C:\\Test\log.txt", "Finish DigSignature_Load - " + DateTime.Now + Environment.NewLine);
            this.ResumeLayout(false);
            this.PerformLayout();
            //File.AppendAllText(@"C:\\Test\log.txt", "Finish PerformLayout - " + DateTime.Now + Environment.NewLine);
        }

        #endregion

        private System.Windows.Forms.TextBox txtImageBinary;
        internal System.Windows.Forms.Button cmdClose;
        internal Topaz.SigPlusNET SigPlusNET1;
        internal System.Windows.Forms.Button btnClear;
        internal System.Windows.Forms.Button btnPrint;
        internal System.Windows.Forms.Button cmdRefresh;

    }
}