using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ACMS
{
	/// <summary>
	/// Summary description for FormNewMemberCreditPackageUsage.
	/// </summary>
	public class FormNewMemberCreditPackageUsage : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOK;

		private ACMS.XtraUtils.LookupEditBuilder.PackageCodeForCreditPackageLookupEditBuilder myPackageCodeLookupEditBuilder;
		private DevExpress.XtraEditors.LookUpEdit lkpEdtPackageCode;
		private System.Windows.Forms.Label label3;
		private ACMSLogic.PackageCode myPackageCode;
		private int myCreditPackageID;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormNewMemberCreditPackageUsage(string strMembershipID, int nCreditPackageID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			myCreditPackageID = nCreditPackageID;
			label3.Text = string.Format("Please select the package you want to use for Member ID : {0} 's Credit Package with ID : {1}", strMembershipID, nCreditPackageID.ToString());
			Init();
		}

		public string StrPackageCode
		{
			get 
			{
				return lkpEdtPackageCode.EditValue.ToString();
			}
		}

		private void Init()
		{
			myPackageCode = new ACMSLogic.PackageCode();
			myPackageCodeLookupEditBuilder = new ACMS.XtraUtils.LookupEditBuilder.PackageCodeForCreditPackageLookupEditBuilder(lkpEdtPackageCode.Properties, myCreditPackageID);
		
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormNewMemberCreditPackageUsage));
			this.lkpEdtPackageCode = new DevExpress.XtraEditors.LookUpEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtPackageCode.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// lkpEdtPackageCode
			// 
			this.lkpEdtPackageCode.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lkpEdtPackageCode.Anchor")));
			this.lkpEdtPackageCode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lkpEdtPackageCode.BackgroundImage")));
			this.lkpEdtPackageCode.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lkpEdtPackageCode.Dock")));
			this.lkpEdtPackageCode.EditValue = ((object)(resources.GetObject("lkpEdtPackageCode.EditValue")));
			this.lkpEdtPackageCode.Enabled = ((bool)(resources.GetObject("lkpEdtPackageCode.Enabled")));
			this.lkpEdtPackageCode.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lkpEdtPackageCode.ImeMode")));
			this.lkpEdtPackageCode.Location = ((System.Drawing.Point)(resources.GetObject("lkpEdtPackageCode.Location")));
			this.lkpEdtPackageCode.Name = "lkpEdtPackageCode";
			// 
			// lkpEdtPackageCode.Properties
			// 
			this.lkpEdtPackageCode.Properties.AccessibleDescription = resources.GetString("lkpEdtPackageCode.Properties.AccessibleDescription");
			this.lkpEdtPackageCode.Properties.AccessibleName = resources.GetString("lkpEdtPackageCode.Properties.AccessibleName");
			this.lkpEdtPackageCode.Properties.AutoHeight = ((bool)(resources.GetObject("lkpEdtPackageCode.Properties.AutoHeight")));
			this.lkpEdtPackageCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																													  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lkpEdtPackageCode.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("lkpEdtPackageCode.Properties.Mask.AutoComplete")));
			this.lkpEdtPackageCode.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("lkpEdtPackageCode.Properties.Mask.BeepOnError")));
			this.lkpEdtPackageCode.Properties.Mask.EditMask = resources.GetString("lkpEdtPackageCode.Properties.Mask.EditMask");
			this.lkpEdtPackageCode.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("lkpEdtPackageCode.Properties.Mask.IgnoreMaskBlank")));
			this.lkpEdtPackageCode.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("lkpEdtPackageCode.Properties.Mask.MaskType")));
			this.lkpEdtPackageCode.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("lkpEdtPackageCode.Properties.Mask.PlaceHolder")));
			this.lkpEdtPackageCode.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("lkpEdtPackageCode.Properties.Mask.SaveLiteral")));
			this.lkpEdtPackageCode.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("lkpEdtPackageCode.Properties.Mask.ShowPlaceHolders")));
			this.lkpEdtPackageCode.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("lkpEdtPackageCode.Properties.Mask.UseMaskAsDisplayFormat")));
			this.lkpEdtPackageCode.Properties.NullText = resources.GetString("lkpEdtPackageCode.Properties.NullText");
			this.lkpEdtPackageCode.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lkpEdtPackageCode.RightToLeft")));
			this.lkpEdtPackageCode.Size = ((System.Drawing.Size)(resources.GetObject("lkpEdtPackageCode.Size")));
			this.lkpEdtPackageCode.TabIndex = ((int)(resources.GetObject("lkpEdtPackageCode.TabIndex")));
			this.lkpEdtPackageCode.ToolTip = resources.GetString("lkpEdtPackageCode.ToolTip");
			this.lkpEdtPackageCode.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("lkpEdtPackageCode.ToolTipIconType")));
			this.lkpEdtPackageCode.ToolTipTitle = resources.GetString("lkpEdtPackageCode.ToolTipTitle");
			this.lkpEdtPackageCode.Visible = ((bool)(resources.GetObject("lkpEdtPackageCode.Visible")));
			this.lkpEdtPackageCode.EditValueChanged += new System.EventHandler(this.lkpEdtPackageCode_EditValueChanged);
			// 
			// label1
			// 
			this.label1.AccessibleDescription = resources.GetString("label1.AccessibleDescription");
			this.label1.AccessibleName = resources.GetString("label1.AccessibleName");
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label1.Anchor")));
			this.label1.AutoSize = ((bool)(resources.GetObject("label1.AutoSize")));
			this.label1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label1.Dock")));
			this.label1.Enabled = ((bool)(resources.GetObject("label1.Enabled")));
			this.label1.Font = ((System.Drawing.Font)(resources.GetObject("label1.Font")));
			this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
			this.label1.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.ImageAlign")));
			this.label1.ImageIndex = ((int)(resources.GetObject("label1.ImageIndex")));
			this.label1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label1.ImeMode")));
			this.label1.Location = ((System.Drawing.Point)(resources.GetObject("label1.Location")));
			this.label1.Name = "label1";
			this.label1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label1.RightToLeft")));
			this.label1.Size = ((System.Drawing.Size)(resources.GetObject("label1.Size")));
			this.label1.TabIndex = ((int)(resources.GetObject("label1.TabIndex")));
			this.label1.Text = resources.GetString("label1.Text");
			this.label1.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.TextAlign")));
			this.label1.Visible = ((bool)(resources.GetObject("label1.Visible")));
			// 
			// simpleButtonCancel
			// 
			this.simpleButtonCancel.AccessibleDescription = resources.GetString("simpleButtonCancel.AccessibleDescription");
			this.simpleButtonCancel.AccessibleName = resources.GetString("simpleButtonCancel.AccessibleName");
			this.simpleButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("simpleButtonCancel.Anchor")));
			this.simpleButtonCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("simpleButtonCancel.BackgroundImage")));
			this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButtonCancel.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("simpleButtonCancel.Dock")));
			this.simpleButtonCancel.Enabled = ((bool)(resources.GetObject("simpleButtonCancel.Enabled")));
			this.simpleButtonCancel.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("simpleButtonCancel.ImeMode")));
			this.simpleButtonCancel.Location = ((System.Drawing.Point)(resources.GetObject("simpleButtonCancel.Location")));
			this.simpleButtonCancel.Name = "simpleButtonCancel";
			this.simpleButtonCancel.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("simpleButtonCancel.RightToLeft")));
			this.simpleButtonCancel.Size = ((System.Drawing.Size)(resources.GetObject("simpleButtonCancel.Size")));
			this.simpleButtonCancel.TabIndex = ((int)(resources.GetObject("simpleButtonCancel.TabIndex")));
			this.simpleButtonCancel.Text = resources.GetString("simpleButtonCancel.Text");
			this.simpleButtonCancel.ToolTip = resources.GetString("simpleButtonCancel.ToolTip");
			this.simpleButtonCancel.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("simpleButtonCancel.ToolTipIconType")));
			this.simpleButtonCancel.ToolTipTitle = resources.GetString("simpleButtonCancel.ToolTipTitle");
			this.simpleButtonCancel.Visible = ((bool)(resources.GetObject("simpleButtonCancel.Visible")));
			// 
			// simpleButtonOK
			// 
			this.simpleButtonOK.AccessibleDescription = resources.GetString("simpleButtonOK.AccessibleDescription");
			this.simpleButtonOK.AccessibleName = resources.GetString("simpleButtonOK.AccessibleName");
			this.simpleButtonOK.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("simpleButtonOK.Anchor")));
			this.simpleButtonOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("simpleButtonOK.BackgroundImage")));
			this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButtonOK.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("simpleButtonOK.Dock")));
			this.simpleButtonOK.Enabled = ((bool)(resources.GetObject("simpleButtonOK.Enabled")));
			this.simpleButtonOK.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("simpleButtonOK.ImeMode")));
			this.simpleButtonOK.Location = ((System.Drawing.Point)(resources.GetObject("simpleButtonOK.Location")));
			this.simpleButtonOK.Name = "simpleButtonOK";
			this.simpleButtonOK.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("simpleButtonOK.RightToLeft")));
			this.simpleButtonOK.Size = ((System.Drawing.Size)(resources.GetObject("simpleButtonOK.Size")));
			this.simpleButtonOK.TabIndex = ((int)(resources.GetObject("simpleButtonOK.TabIndex")));
			this.simpleButtonOK.Text = resources.GetString("simpleButtonOK.Text");
			this.simpleButtonOK.ToolTip = resources.GetString("simpleButtonOK.ToolTip");
			this.simpleButtonOK.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("simpleButtonOK.ToolTipIconType")));
			this.simpleButtonOK.ToolTipTitle = resources.GetString("simpleButtonOK.ToolTipTitle");
			this.simpleButtonOK.Visible = ((bool)(resources.GetObject("simpleButtonOK.Visible")));
			this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
			// 
			// label3
			// 
			this.label3.AccessibleDescription = resources.GetString("label3.AccessibleDescription");
			this.label3.AccessibleName = resources.GetString("label3.AccessibleName");
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label3.Anchor")));
			this.label3.AutoSize = ((bool)(resources.GetObject("label3.AutoSize")));
			this.label3.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label3.Dock")));
			this.label3.Enabled = ((bool)(resources.GetObject("label3.Enabled")));
			this.label3.Font = ((System.Drawing.Font)(resources.GetObject("label3.Font")));
			this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
			this.label3.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label3.ImageAlign")));
			this.label3.ImageIndex = ((int)(resources.GetObject("label3.ImageIndex")));
			this.label3.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label3.ImeMode")));
			this.label3.Location = ((System.Drawing.Point)(resources.GetObject("label3.Location")));
			this.label3.Name = "label3";
			this.label3.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label3.RightToLeft")));
			this.label3.Size = ((System.Drawing.Size)(resources.GetObject("label3.Size")));
			this.label3.TabIndex = ((int)(resources.GetObject("label3.TabIndex")));
			this.label3.Text = resources.GetString("label3.Text");
			this.label3.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label3.TextAlign")));
			this.label3.Visible = ((bool)(resources.GetObject("label3.Visible")));
			// 
			// FormNewMemberCreditPackageUsage
			// 
			this.AcceptButton = this.simpleButtonOK;
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.CancelButton = this.simpleButtonCancel;
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this.label3);
			this.Controls.Add(this.simpleButtonCancel);
			this.Controls.Add(this.simpleButtonOK);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lkpEdtPackageCode);
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximizeBox = false;
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.MinimizeBox = false;
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "FormNewMemberCreditPackageUsage";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.ShowInTaskbar = false;
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			((System.ComponentModel.ISupportInitialize)(this.lkpEdtPackageCode.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButtonOK_Click(object sender, System.EventArgs e)
		{
			if (lkpEdtPackageCode.Text.Length == 0)
			{
				MessageBox.Show(this, "Please select a Package Code.");
				this.DialogResult = DialogResult.None;
				return;
			}
		}

//		private void lkpEdtCategoryID_EditValueChanged(object sender, System.EventArgs e)
//		{
//			if (lkpEdtCategoryID.EditValue != null && lkpEdtCategoryID.Text.Length > 0)
//			{
//				int categoryID = ACMS.Convert.ToInt32(lkpEdtCategoryID.EditValue);
//				myPackageCodeLookupEditBuilder.Refresh(categoryID);
//				lkpEdtPackageCode.Enabled = true;			
//			}
//			else
//			{
//				lkpEdtPackageCode.Enabled = false;
//			}
//		}
		
		private void lkpEdtPackageCode_EditValueChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
