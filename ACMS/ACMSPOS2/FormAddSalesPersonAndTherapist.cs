using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ACMS.ACMSPOS2
{
	/// <summary>
	/// Summary description for FormAddSalesPersonAndTherapist.
	/// </summary>
	public class FormAddSalesPersonAndTherapist : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Label Label4;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
		internal System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtSalesPersonID;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtTherapist;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private ACMS.XtraUtils.LookupEditBuilder.TherapistForPOSSalesLookupEditBuilder myTherapistLookupBuilder;
		private ACMS.XtraUtils.LookupEditBuilder.TherapistForPOSSalesLookupEditBuilder myEmployeeIDLookupBuilder;
		
		private ACMSLogic.POS myPOS;        

		public FormAddSalesPersonAndTherapist(ACMSLogic.POS pos)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			myPOS = pos;
			myTherapistLookupBuilder = new ACMS.XtraUtils.LookupEditBuilder.TherapistForPOSSalesLookupEditBuilder(lkpEdtTherapist.Properties,
				myPOS.StrBranchCode);
			myEmployeeIDLookupBuilder = new ACMS.XtraUtils.LookupEditBuilder.TherapistForPOSSalesLookupEditBuilder(lkpEdtSalesPersonID.Properties, 
				myPOS.StrBranchCode);

			Init();

		}

		private void Init()
		{
			if (myPOS.NCategoryID == 4 ||
				myPOS.NCategoryID == 5 ||
				myPOS.NCategoryID == 6 || 
				myPOS.NCategoryID == 7 ||
                myPOS.NCategoryID == 9 ||
                myPOS.NCategoryID == 36 ||
                myPOS.NCategoryID == 37)
			{
				label1.Visible = true;
				lkpEdtTherapist.Visible = true;
				this.Text = "Add Sales Person And Therapist";
			}            
			else if (myPOS.NCategoryID == 10 && (myPOS.NoCredit>=1 || ACMS.Convert.ToInt32(myPOS.WantToUpgradeMemberPackageRow["nCategoryID"])==5 ))
			{
					label1.Visible = true;
					lkpEdtTherapist.Visible = true;
					this.Text = "Add Sales Person And Therapist";
			}
			else
			{
				label1.Visible = false;
				lkpEdtTherapist.Visible = false;
				this.Text = "Add Sales Person";
			}

			if (myPOS.IsStaffPurchase)
			{
				Label4.Visible = false;
				lkpEdtSalesPersonID.Visible = false;
				this.Text = "Add Therapist";
			}
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
            this.Label4 = new System.Windows.Forms.Label();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.lkpEdtSalesPersonID = new DevExpress.XtraEditors.LookUpEdit();
            this.lkpEdtTherapist = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtSalesPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtTherapist.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(14, 10);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(160, 23);
            this.Label4.TabIndex = 41;
            this.Label4.Text = "Sales Person ID";
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButtonCancel.Location = new System.Drawing.Point(288, 84);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonCancel.TabIndex = 44;
            this.simpleButtonCancel.Text = "Cancel";
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButtonOK.Location = new System.Drawing.Point(204, 84);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonOK.TabIndex = 43;
            this.simpleButtonOK.Text = "OK";
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
            // 
            // lkpEdtSalesPersonID
            // 
            this.lkpEdtSalesPersonID.EditValue = "";
            this.lkpEdtSalesPersonID.Location = new System.Drawing.Point(182, 10);
            this.lkpEdtSalesPersonID.Name = "lkpEdtSalesPersonID";
            this.lkpEdtSalesPersonID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lkpEdtSalesPersonID.Properties.Appearance.Options.UseFont = true;
            this.lkpEdtSalesPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpEdtSalesPersonID.Size = new System.Drawing.Size(296, 23);
            this.lkpEdtSalesPersonID.TabIndex = 42;
            this.lkpEdtSalesPersonID.EditValueChanged += new System.EventHandler(this.lkpEdtSalesPersonID_EditValueChanged);
            // 
            // lkpEdtTherapist
            // 
            this.lkpEdtTherapist.EditValue = "";
            this.lkpEdtTherapist.Location = new System.Drawing.Point(182, 48);
            this.lkpEdtTherapist.Name = "lkpEdtTherapist";
            this.lkpEdtTherapist.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lkpEdtTherapist.Properties.Appearance.Options.UseFont = true;
            this.lkpEdtTherapist.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpEdtTherapist.Size = new System.Drawing.Size(296, 23);
            this.lkpEdtTherapist.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 23);
            this.label1.TabIndex = 45;
            this.label1.Text = "Therapist ID";
            // 
            // FormAddSalesPersonAndTherapist
            // 
            this.AcceptButton = this.simpleButtonOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.simpleButtonCancel;
            this.ClientSize = new System.Drawing.Size(490, 118);
            this.Controls.Add(this.lkpEdtTherapist);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.simpleButtonCancel);
            this.Controls.Add(this.simpleButtonOK);
            this.Controls.Add(this.lkpEdtSalesPersonID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddSalesPersonAndTherapist";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Sales Person And Therapist";
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtSalesPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtTherapist.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
			if ((lkpEdtSalesPersonID.EditValue == null || lkpEdtSalesPersonID.Text == "")
				&& (lkpEdtTherapist.EditValue == null || lkpEdtTherapist.Text == ""))
				return;
			
			if (lkpEdtSalesPersonID.Text != "")
				myPOS.NSalespersonID = ACMS.Convert.ToInt32(lkpEdtSalesPersonID.EditValue);

			if (lkpEdtTherapist.Text != "")
				myPOS.NTherapistID = ACMS.Convert.ToInt32(lkpEdtTherapist.EditValue);
		}

        private void lkpEdtSalesPersonID_EditValueChanged(object sender, EventArgs e)
        {
            if (myPOS.NCategoryID == 36 || myPOS.NCategoryID == 37)
            {
                ACMSDAL.TblEmployee emp = new ACMSDAL.TblEmployee();

                if (lkpEdtSalesPersonID.Text != "")
                {
                    if (emp.IsSaleDivisionFit(ACMS.Convert.ToInt32(lkpEdtSalesPersonID.EditValue)))
                    {
                        if (lkpEdtTherapist.Visible)
                        {
                            lkpEdtTherapist.EditValue = null;
                            lkpEdtTherapist.Text = "";
                            label1.Visible = false;
                            lkpEdtTherapist.Visible = false;
                            this.Text = "Add Sales Person";
                        }
                    }
                    else
                    {
                        label1.Visible = true;
                        lkpEdtTherapist.Visible = true;
                        this.Text = "Add Sales Person And Therapist";
                    }
                }
                emp.Dispose();
            }
        }
	}
}
