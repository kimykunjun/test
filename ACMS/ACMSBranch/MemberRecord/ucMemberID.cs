using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using ACMS.ACMSBranch;
using ACMSLogic;
using ACMS.Utils;

namespace ACMS
{
	/// <summary>
	/// Summary description for ucMemberID.
	/// </summary>
	public class ucMemberID : System.Windows.Forms.UserControl
	{
		private MemberRecord myMemberRecord;
        private string strBranchCode;
        private string StrCode;
        
        private ACMSLogic.Common.EditValueChangedDelegate myEditValueChangedEvent;

		public ACMSLogic.Common.EditValueChangedDelegate EditValueChanged
		{
			get { return myEditValueChangedEvent; }
			set { myEditValueChangedEvent = value; }
		}

		public string StrBranchCode
		{
			get { return strBranchCode; }
			set { strBranchCode = value; }
        }

		public object EditValue
		{
			get {return txtMembershipID.EditValue;}
			set {txtMembershipID.EditValue = value;}
		}

		public new ControlBindingsCollection DataBindings
		{
			get { return txtMembershipID.DataBindings; }
		}

		private DevExpress.XtraEditors.SimpleButton sbtnFind;
		private DevExpress.XtraEditors.TextEdit txtMembershipID;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ucMemberID()
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
            this.txtMembershipID = new DevExpress.XtraEditors.TextEdit();
            this.sbtnFind = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtMembershipID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMembershipID
            // 
            this.txtMembershipID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMembershipID.EditValue = "";
            this.txtMembershipID.Location = new System.Drawing.Point(0, 0);
            this.txtMembershipID.Name = "txtMembershipID";
            this.txtMembershipID.Size = new System.Drawing.Size(132, 20);
            this.txtMembershipID.TabIndex = 0;
            this.txtMembershipID.Leave += new System.EventHandler(this.txtMembershipID_Leave);
            // 
            // sbtnFind
            // 
            this.sbtnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnFind.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.sbtnFind.Location = new System.Drawing.Point(134, 0);
            this.sbtnFind.Name = "sbtnFind";
            this.sbtnFind.Size = new System.Drawing.Size(44, 20);
            this.sbtnFind.TabIndex = 1;
            this.sbtnFind.Text = "Find";
            this.sbtnFind.Click += new System.EventHandler(this.sbtnFind_Click);
            // 
            // ucMemberID
            // 
            this.Controls.Add(this.txtMembershipID);
            this.Controls.Add(this.sbtnFind);
            this.Name = "ucMemberID";
            this.Size = new System.Drawing.Size(182, 20);
            ((System.ComponentModel.ISupportInitialize)(this.txtMembershipID.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		public new bool Focus()
		{
			if (txtMembershipID.CanFocus)
			{
				txtMembershipID.Focus();
				return true;
			}
			else
				return false;
		}

		private void sbtnFind_Click(object sender, System.EventArgs e)
		{
			if (strBranchCode == null)
			{
				UI.ShowErrorMessage(this, "You forgot to set StrBranchCode property.");
				return;
			}
			Cursor saveCursor = Cursor.Current;
			Cursor.Current = Cursors.WaitCursor;


          
                try
                {
                    myMemberRecord = new MemberRecord(strBranchCode);

                    //frmSearchMember myForm = new frmSearchMember(myMemberRecord,
                    // myMemberRecord.SearchMember(txtMembershipID.Text, DBNull.Value,
                    // ACMSLogic.MemberRecord.SearchMemberType.AllMember, 0),
                    // txtMembershipID.Text, DBNull.Value, 1);

                            frmSearchMember myForm = new frmSearchMember(myMemberRecord,
                             myMemberRecord.SearchMember(txtMembershipID.Text, DBNull.Value,
                             ACMSLogic.MemberRecord.SearchMemberType.AllMember, 0),
                             txtMembershipID.Text, DBNull.Value,0);

                    if (DialogResult.OK == myForm.ShowDialog(this))
                    {
                        txtMembershipID.Text = myForm.StrMemberShipID;

                        if (myEditValueChangedEvent != null)
                        {
                            myEditValueChangedEvent(txtMembershipID.Text);
                        }
                    }
                    myForm.Dispose();
                }
                finally
                {
                    Cursor.Current = saveCursor;
               

            //}
            //else
            //{
            //    try
            //    {
            //        myMemberRecord = new MemberRecord(strBranchCode);

            //        frmSearchMember myForm = new frmSearchMember(myMemberRecord,
            //         myMemberRecord.SearchMember(txtMembershipID.Text, DBNull.Value,
            //         ACMSLogic.MemberRecord.SearchMemberType.NonMember, 1),
            //         txtMembershipID.Text, DBNull.Value, 1);

            //        if (DialogResult.OK == myForm.ShowDialog(this))
            //        {
            //            txtMembershipID.Text = myForm.StrMemberShipID;

            //            if (myEditValueChangedEvent != null)
            //            {
            //                myEditValueChangedEvent(txtMembershipID.Text);
            //            }
            //        }
            //        myForm.Dispose();
            //    }
            //    finally
            //    {
            //        Cursor.Current = saveCursor;
            //    }
            }
		}

		private void txtMembershipID_Leave(object sender, System.EventArgs e)
		{
			if (myEditValueChangedEvent != null)
			{
				myEditValueChangedEvent(txtMembershipID.Text);
			}
		}
	}
}
