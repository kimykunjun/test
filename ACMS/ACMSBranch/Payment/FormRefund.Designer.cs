namespace ACMS
{
    partial class FormRefund
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
            this.pnlCtrlCenter = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.txtChequeNo = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRefundAmt = new DevExpress.XtraEditors.TextEdit();
            this.Label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCtrlCenter)).BeginInit();
            this.pnlCtrlCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtChequeNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefundAmt.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCtrlCenter
            // 
            this.pnlCtrlCenter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlCtrlCenter.Controls.Add(this.simpleButtonCancel);
            this.pnlCtrlCenter.Controls.Add(this.simpleButtonOK);
            this.pnlCtrlCenter.Controls.Add(this.txtChequeNo);
            this.pnlCtrlCenter.Controls.Add(this.label1);
            this.pnlCtrlCenter.Controls.Add(this.txtRefundAmt);
            this.pnlCtrlCenter.Controls.Add(this.Label4);
            this.pnlCtrlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCtrlCenter.Location = new System.Drawing.Point(0, 0);
            this.pnlCtrlCenter.Name = "pnlCtrlCenter";
            this.pnlCtrlCenter.Size = new System.Drawing.Size(446, 181);
            this.pnlCtrlCenter.TabIndex = 2;
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButtonCancel.Location = new System.Drawing.Point(308, 126);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(90, 26);
            this.simpleButtonCancel.TabIndex = 4;
            this.simpleButtonCancel.Text = "Cancel";
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButtonOK.Location = new System.Drawing.Point(204, 126);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(90, 26);
            this.simpleButtonOK.TabIndex = 3;
            this.simpleButtonOK.Text = "OK";
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.EditValue = "";
            this.txtChequeNo.Location = new System.Drawing.Point(179, 37);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtChequeNo.Properties.Appearance.Options.UseFont = true;
            this.txtChequeNo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtChequeNo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtChequeNo.Size = new System.Drawing.Size(219, 25);
            this.txtChequeNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 29);
            this.label1.TabIndex = 46;
            this.label1.Text = "Refund Amt.";
            // 
            // txtRefundAmt
            // 
            this.txtRefundAmt.EditValue = "$0.00";
            this.txtRefundAmt.Location = new System.Drawing.Point(179, 80);
            this.txtRefundAmt.Name = "txtRefundAmt";
            this.txtRefundAmt.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtRefundAmt.Properties.Appearance.Options.UseFont = true;
            this.txtRefundAmt.Properties.DisplayFormat.FormatString = "c2";
            this.txtRefundAmt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtRefundAmt.Properties.EditFormat.FormatString = "c2";
            this.txtRefundAmt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtRefundAmt.Size = new System.Drawing.Size(219, 25);
            this.txtRefundAmt.TabIndex = 2;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(24, 30);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(145, 29);
            this.Label4.TabIndex = 43;
            this.Label4.Text = "Cheque No";
            // 
            // FormRefund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 181);
            this.Controls.Add(this.pnlCtrlCenter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRefund";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Refund";
            ((System.ComponentModel.ISupportInitialize)(this.pnlCtrlCenter)).EndInit();
            this.pnlCtrlCenter.ResumeLayout(false);
            this.pnlCtrlCenter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtChequeNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefundAmt.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlCtrlCenter;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtChequeNo;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
        private DevExpress.XtraEditors.TextEdit txtRefundAmt;
    }
}