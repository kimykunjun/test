using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
//using Rp = Acms.Core.Repository;
//using Fc = Acms.Core.Factory;

namespace Acms.WinForm.AcmsManager
{
	/// <summary>
	/// Summary description for frmPackage_Add.
	/// </summary>
	public class frmPackage_Add : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.TextEdit StrPackageCode;
		private System.Windows.Forms.Label LblStrPackageCode;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraEditors.TextEdit StrDescription;
		private System.Windows.Forms.ComboBox comboBox1;
		
		protected bool isEdit = false;
		protected string strPackageCode;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmPackage_Add()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			BindPage();
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

		private void BindPage()
		{
//			Rp.CategoryRepository cr = new Acms.Core.Repository.CategoryRepository();
//			this.comboBox1.DataSource = cr.GetListByDomain(typeof(Acms.Core.Domain.Category));
//			this.comboBox1.DisplayMember = "StrDescription";
//			this.comboBox1.ValueMember = "Id";
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.StrPackageCode = new DevExpress.XtraEditors.TextEdit();
			this.LblStrPackageCode = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.StrDescription = new DevExpress.XtraEditors.TextEdit();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.StrPackageCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.StrDescription.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// StrPackageCode
			// 
			this.StrPackageCode.EditValue = "";
			this.StrPackageCode.Location = new System.Drawing.Point(128, 8);
			this.StrPackageCode.Name = "StrPackageCode";
			this.StrPackageCode.Size = new System.Drawing.Size(128, 20);
			this.StrPackageCode.TabIndex = 0;
			// 
			// LblStrPackageCode
			// 
			this.LblStrPackageCode.Location = new System.Drawing.Point(8, 8);
			this.LblStrPackageCode.Name = "LblStrPackageCode";
			this.LblStrPackageCode.TabIndex = 1;
			this.LblStrPackageCode.Text = "Package Code";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(272, 8);
			this.label1.Name = "label1";
			this.label1.TabIndex = 3;
			this.label1.Text = "Category";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Package Description";
			// 
			// StrDescription
			// 
			this.StrDescription.EditValue = "";
			this.StrDescription.Location = new System.Drawing.Point(128, 40);
			this.StrDescription.Name = "StrDescription";
			this.StrDescription.Size = new System.Drawing.Size(128, 20);
			this.StrDescription.TabIndex = 5;
			// 
			// simpleButton1
			// 
			this.simpleButton1.Location = new System.Drawing.Point(128, 88);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.TabIndex = 6;
			this.simpleButton1.Text = "Save";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(376, 8);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 7;
			this.comboBox1.Text = "comboBox1";
			// 
			// frmPackage_Add
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(528, 133);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.StrDescription);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.LblStrPackageCode);
			this.Controls.Add(this.StrPackageCode);
			this.Name = "frmPackage_Add";
			this.Text = "frmPackage_Add";
			((System.ComponentModel.ISupportInitialize)(this.StrPackageCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.StrDescription.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public void AddPackageRefId(string strPackageCode)
		{
	/*		this.strPackageCode=strPackageCode;
			isEdit=true;
			this.StrPackageCode.Text = strPackageCode;
			this.StrPackageCode.Enabled = false;

			Rp.PackageRepository pr = new Rp.PackageRepository();
			Acms.Core.Domain.Package p = pr.GetPackageById(strPackageCode);

			this.StrDescription.Text = p.StrDescription;*/
			//Binding record here ...
			
		}

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
	/*		try
			{
				Hashtable htPackage = new Hashtable();
				//htstring
				htPackage.Add("Id",this.StrPackageCode.Text);
		
				//string
				htPackage.Add("strDescription",this.StrDescription.Text);
				//string
				htPackage.Add("strReceiptDesc","");
		
				//decimal
				htPackage.Add("mListPrice",1);
				//int
				htPackage.Add("nMaxSession",1);
				//int
				htPackage.Add("nPackageDuration",1);
				//decimal
				htPackage.Add("mBaseUnitPrice",1);
				//DateTime
				htPackage.Add("dtValidStart","1/1/2005");
				//DateTime
				htPackage.Add("dtValidEnd","1/1/2006");
				//boolean
				htPackage.Add("fPeak",true);
				//int
				htPackage.Add("nValidMonths",1);
				//int
				htPackage.Add("nWarrantyMonths",1);
				//boolean
				htPackage.Add("fGIRO",false);
				//boolean
				htPackage.Add("fNoRestrictionUpgrade",false);

				//int
				htPackage.Add("Category_nCategoryID",this.comboBox1.SelectedValue.ToString());

				Fc.PackageFactory pf = new Fc.PackageFactory();
				if(!isEdit)
				{
					pf.MakeSavePackage(htPackage);
					MessageBox.Show("Record Has Been Saved", "Save");
				}
				else
				{
					pf.MakeUpdatePackage(htPackage);
					MessageBox.Show("Record Has Been Updated", "Save");
				}
				
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message, "Error");
			}
			*/
		}
	}
}
