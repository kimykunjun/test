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
            this.SuspendLayout();
            // 
            // txtImageBinary
            // 
            this.txtImageBinary.Location = new System.Drawing.Point(338, 12);
            this.txtImageBinary.Name = "txtImageBinary";
            this.txtImageBinary.Size = new System.Drawing.Size(74, 20);
            this.txtImageBinary.TabIndex = 37;
            this.txtImageBinary.Visible = false;
            // 
            // cmdClose
            // 
            this.cmdClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Location = new System.Drawing.Point(195, 156);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(86, 37);
            this.cmdClose.TabIndex = 36;
            this.cmdClose.Text = "C L O S E";
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // SigPlusNET1
            // 
            this.SigPlusNET1.Location = new System.Drawing.Point(12, 12);
            this.SigPlusNET1.Name = "SigPlusNET1";
            this.SigPlusNET1.Size = new System.Drawing.Size(320, 136);
            this.SigPlusNET1.TabIndex = 30;
            this.SigPlusNET1.Text = "sigPlusNET2";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(103, 156);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(86, 37);
            this.btnClear.TabIndex = 28;
            this.btnClear.Text = "C L E A R";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(12, 156);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(85, 37);
            this.btnPrint.TabIndex = 26;
            this.btnPrint.Text = "P R I N T";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // DigSignature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 196);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.SigPlusNET1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtImageBinary);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DigSignature";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Digital Signature";
            this.Load += new System.EventHandler(this.DigSignature_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtImageBinary;
        internal System.Windows.Forms.Button cmdClose;
        internal Topaz.SigPlusNET SigPlusNET1;
        internal System.Windows.Forms.Button btnClear;
        internal System.Windows.Forms.Button btnPrint;

    }
}