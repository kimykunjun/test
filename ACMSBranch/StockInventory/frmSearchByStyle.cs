using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Security;
////using Rp = Acms.Core.Repository;
////using Fc = Acms.Core.Factory;
//using Do = Acms.Core.Domain;
using DevExpress.XtraEditors.Controls;
using ACMSLogic;

namespace ACMS.ACMSBranch.StockInventory
{
	/// <summary>
	/// Summary description for frmSearchByStyle.
	/// </summary>
	public class frmSearchByStyle : DevExpress.XtraEditors.XtraForm
	{
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSearchByStyle()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.simpleButton1.Enabled=false;
			BindPage();
		}

		private void BindPage()
		{
			//System.Security.Principal.WindowsIdentity wi = System.Security.Principal.WindowsIdentity.GetCurrent();
			
			//Rp.ProductRepository pr = new Rp.ProductRepository();
			//IList list = pr.Find("select distinct s.Id from Product p inner join p.Style s");
			
			ACMSLogic.StockInventory.SearchInventory si = new ACMSLogic.StockInventory.SearchInventory();
			
			this.lookUpEdit1.Properties.DataSource = si.SearchStyle();
			//this.lookUpEdit1.Properties.SearchMode = SearchMode.AutoComplete;
			
			this.lookUpEdit1.Properties.ValueMember = "strStyleCode";
			this.lookUpEdit1.Properties.DisplayMember = "strStyleCode";
			this.lookUpEdit1.EditValue="Select Style";
			this.lookUpEdit1.Text="Select Style";

			//add two columns in the dropdown
			LookUpColumnInfoCollection coll = lookUpEdit1.Properties.Columns;
			//a column to display values of the ProductID field
			coll.Add(new LookUpColumnInfo("strStyleCode","Style Code",4));
			coll.Add(new LookUpColumnInfo("strDescription","Style Description",50));

		
			//a column to display values of the ProductName field
			

			//set column widths according to their contents
			lookUpEdit1.Properties.BestFit();
			//specify the total dropdown width
			lookUpEdit1.Properties.PopupWidth = 300;

			//enable auto completion search mode
			//lookUpEdit1.Properties.SearchMode = SearchMode.AutoComplete;
			//the column against which to perform the search
			lookUpEdit1.Properties.AutoSearchColumnIndex = 0;
		
			//this.cbSearchStyle.DataSource = list;
			
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
			this.label1 = new System.Windows.Forms.Label();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Style";
			// 
			// simpleButton1
			// 
			this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButton1.Location = new System.Drawing.Point(64, 40);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.TabIndex = 2;
			this.simpleButton1.Text = "Search";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// lookUpEdit1
			// 
			this.lookUpEdit1.Location = new System.Drawing.Point(64, 8);
			this.lookUpEdit1.Name = "lookUpEdit1";
			// 
			// lookUpEdit1.Properties
			// 
			this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																												new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lookUpEdit1.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
			this.lookUpEdit1.Properties.NullText = "";
			this.lookUpEdit1.Properties.EditValueChanged += new System.EventHandler(this.EditValueChanged);
			this.lookUpEdit1.Size = new System.Drawing.Size(112, 20);
			this.lookUpEdit1.TabIndex = 3;
			// 
			// simpleButton2
			// 
			this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButton2.Location = new System.Drawing.Point(144, 40);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.TabIndex = 4;
			this.simpleButton2.Text = "Cancel";
			this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
			// 
			// frmSearchByStyle
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.CancelButton = this.simpleButton2;
			this.ClientSize = new System.Drawing.Size(226, 71);
			this.ControlBox = false;
			this.Controls.Add(this.simpleButton2);
			this.Controls.Add(this.lookUpEdit1);
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSearchByStyle";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Search Style";
			((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			if(this.lookUpEdit1.Text=="")
			{
				MessageBox.Show("Please Select Style","Null Value");
			}
			else
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		public string GetSelectedItem()
		{
			return this.lookUpEdit1.EditValue.ToString();
		}

		private void simpleButton2_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void EditValueChanged(object sender, System.EventArgs e)
		{
			if(this.lookUpEdit1.Text!="")
			{
				this.simpleButton1.Enabled=true;
			}
			else
			{
				this.simpleButton1.Enabled=false;
			}
		}
	}
}

