using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
//using Rp = Acms.Core.Repository;
//using Fc = Acms.Core.Factory;
using Do = Acms.Core.Domain;
using DevExpress.XtraEditors.Controls;

namespace ACMS.ACMSBranch.StockInventory
{
	/// <summary>
	/// Summary description for frmSearchByItemCode.
	/// </summary>
	public class frmSearchByItemCode : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSearchByItemCode()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.simpleButton1.Enabled=false;
			BindPage();
		}

		private void BindPage()
		{
			//System.Security.Principal.WindowsIdentity wi = System.Security.Principal.WindowsIdentity.GetCurrent();
			
			ACMSLogic.StockInventory.SearchInventory si = new ACMSLogic.StockInventory.SearchInventory();
			
			this.lookUpEdit1.Properties.DataSource = si.SearchItemCode();
			//this.lookUpEdit1.Properties.SearchMode = SearchMode.AutoComplete;
			
			this.lookUpEdit1.Properties.ValueMember = "strProductCode";
			this.lookUpEdit1.Properties.DisplayMember = "strProductCode";
			

			//add two columns in the dropdown
			LookUpColumnInfoCollection coll = lookUpEdit1.Properties.Columns;
			//a column to display values of the ProductID field
			coll.Add(new LookUpColumnInfo("strProductCode","Item Code",100));

			
			//a column to display values of the ProductName field
			

			//set column widths according to their contents
			lookUpEdit1.Properties.BestFit();
			//specify the total dropdown width
			lookUpEdit1.Properties.PopupWidth = 100;
			
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
			this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.label1 = new System.Windows.Forms.Label();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// lookUpEdit1
			// 
			this.lookUpEdit1.Location = new System.Drawing.Point(72, 8);
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
			this.lookUpEdit1.TabIndex = 6;
			// 
			// simpleButton1
			// 
			this.simpleButton1.Location = new System.Drawing.Point(72, 40);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.TabIndex = 5;
			this.simpleButton1.Text = "Search";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Item Code";
			// 
			// simpleButton2
			// 
			this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButton2.Location = new System.Drawing.Point(152, 40);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.TabIndex = 7;
			this.simpleButton2.Text = "Cancel";
			this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
			// 
			// frmSearchByItemCode
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(234, 69);
			this.ControlBox = false;
			this.Controls.Add(this.simpleButton2);
			this.Controls.Add(this.lookUpEdit1);
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSearchByItemCode";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Search By ItemCode";
			((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void simpleButton1_Click(object sender, System.EventArgs e)
		{
			if(this.lookUpEdit1.Text=="")
			{
				MessageBox.Show("Please select Item Code","Null Value");
				return;
			}
			this.DialogResult = DialogResult.OK;
			this.Close();
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
