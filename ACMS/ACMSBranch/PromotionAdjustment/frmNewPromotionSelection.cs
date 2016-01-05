using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
////using Rp = Acms.Core.Repository;
////using Fc = Acms.Core.Factory;
using Acms.Core.Domain;
//using Acms.Core.DataAccess;
using ACMSLogic;
using System.Data.SqlClient;
using ACMS.Utils;
using DevExpress.XtraEditors.Controls;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

namespace ACMS.ACMSBranch.PromotionAdjustment
{
    /// <summary>
    /// Summary description for frmNewPromotionSelection.
    /// </summary>
    public class frmNewPromotionSelection : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private string connectionString;
        private SqlConnection connection;
        private Acms.Core.Domain.Employee employee;
        private Acms.Core.Domain.TerminalUser terminalUser;
        private string mTotalAmount;
        private string strMemberShipId;
        private string nCategoryId;
        private string strReceiptNo;
        private string strItemCode;

        private string strBranchCode;
        private string nEntryID = "0";
        private string panel;
        private string strBillPromotionCode;
        private DevExpress.XtraEditors.LookUpEdit lkpEdtItemFreebiePromotionCode;
        private ACMS.XtraUtils.LookupEditBuilder.ItemFreebiePromotionCodeLookupEditBuilder myItemFreebiePromotionCodeLookupBuilder;
        private ACMS.XtraUtils.LookupEditBuilder.BillFreebiePromotionCodeLookupEditBuilder myFreebiePromotionCodeLookupBuilder;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmNewPromotionSelection()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            connectionString = (string)ConfigurationSettings.AppSettings["Main.ConnectionString"];
            connection = new SqlConnection(connectionString);
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public string StrReceiptNo
        {
            set { strReceiptNo = value; }
        }

        public string StrBillPromotionCode
        {
            set { strBillPromotionCode = value; }
        }

        public string StrItemCode
        {
            set { strItemCode = value; }
        }

        public Employee Employee
        {
            set { employee = value; }
        }

        public TerminalUser TerminalUser
        {
            set { terminalUser = value; }
        }

        public string MTotalAmount
        {
            set { mTotalAmount = value; }
        }

        public string StrMemberShipID
        {
            set { strMemberShipId = value; }
        }

        public string NCategoryID
        {
            set { nCategoryId = value; }
        }


        public void InitData(string strBranchCode, string strReceiptNo, string nEntryID, string panel)
        {
            this.strBranchCode = strBranchCode;
            this.nEntryID = nEntryID;
            this.panel = panel;
            this.strReceiptNo = strReceiptNo;
            if (this.panel != "Adjustment")
                this.nEntryID = "0";
            BindDropDownList();
        }

        private int GetCategoryTypeID(int nCategoryID)
        {
            if (nCategoryID == 1 || nCategoryID == 2 || nCategoryID == 3 ||
                nCategoryID == 4 || nCategoryID == 5 || nCategoryID == 6)
            {
                return 2;
            }
            else if (nCategoryID == 7)
            {
                return 4;
            }
            else if (nCategoryID == 8 || nCategoryID == 9)
            {
                return 3;
            }
            else if (nCategoryID == 11 || nCategoryID == 12)
            {
                return 1;
            }
            else if (nCategoryID == 10)
            {
                return 0;
            }
            else
                return 0;
        }

        public bool IsStaffPurchase(string strMembershipID)
        {
            string hder = strMembershipID.Substring(0, 2);

            if (hder == "HQ")
            {
                string ID = strMembershipID.Substring(2, strMembershipID.Length - 2);

                try
                {
                    int numberID = int.Parse(ID);

                    if (numberID > 999)
                    {
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        private void BindDropDownList()
        {
            if (panel == "Adjustment")
            {
                myItemFreebiePromotionCodeLookupBuilder = new ACMS.XtraUtils.LookupEditBuilder.ItemFreebiePromotionCodeLookupEditBuilder(lkpEdtItemFreebiePromotionCode.Properties,
                    this.strMemberShipId, Convert.ToDecimal(this.mTotalAmount), GetCategoryTypeID(Convert.ToInt32(this.nCategoryId)), Convert.ToInt32(this.nCategoryId),
                    this.strItemCode, this.strBranchCode, IsStaffPurchase(this.strMemberShipId), this.strReceiptNo);
            }
            else
            {
                //				myItemFreebiePromotionCodeLookupBuilder = new ACMS.XtraUtils.LookupEditBuilder.ItemFreebiePromotionCodeLookupEditBuilder(lkpEdtItemFreebiePromotionCode.Properties, 
                //					this.strMemberShipId, Convert.ToDecimal(this.mTotalAmount), GetCategoryTypeID(Convert.ToInt32(this.nCategoryId)), Convert.ToInt32(this.nCategoryId), 
                //					this.strItemCode, this.strBranchCode, IsStaffPurchase(this.strMemberShipId));

                myFreebiePromotionCodeLookupBuilder = new ACMS.XtraUtils.LookupEditBuilder.BillFreebiePromotionCodeLookupEditBuilder(lkpEdtItemFreebiePromotionCode.Properties,
                    this.strMemberShipId, Convert.ToDecimal(this.mTotalAmount), this.strBranchCode, Convert.ToInt32(this.nCategoryId), true, this.strReceiptNo);
            }
            //			ACMSLogic.Promotion.Promotion promotion = new ACMSLogic.Promotion.Promotion();
            //
            //			
            //			DataTable dt = promotion.FindPromotionSelectionList(this.terminalUser.Branch.Id,this.mTotalAmount,this.strMemberShipId,this.nCategoryId,this.strBillPromotionCode,panel,this.strReceiptNo,this.strItemCode);
            //			if(dt.Rows.Count==0)
            //				this.simpleButton1.Enabled=false;
            //
            //			this.lkPromotion.Properties.DataSource = dt;
            //
            //
            //			this.lkPromotion.Properties.ValueMember = "strPromotionCode";
            //			this.lkPromotion.Properties.DisplayMember = "strPromotionCode";
            //			
            //			
            //
            //			//add two columns in the dropdown
            //			LookUpColumnInfoCollection coll = lkPromotion.Properties.Columns;
            //			
            //			coll.Add(new LookUpColumnInfo("strPromotionCode","Promotion Code",100));
            //			//a column to display values of the ProductName field
            //			coll.Add(new LookUpColumnInfo("strDescription","Description",300));
            //
            //
            //			//set column widths according to their contents
            //			lkPromotion.Properties.BestFit();
            //			//specify the total dropdown width
            //			lkPromotion.Properties.PopupWidth = 400;
            //
            //			
            //			lkPromotion.Properties.AutoSearchColumnIndex = 0;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.label1 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.lkpEdtItemFreebiePromotionCode = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtItemFreebiePromotionCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 48;
            this.label1.Text = "Promotion Code";
            // 
            // gridControl1
            // 
            // 
            // gridControl1.EmbeddedNavigator
            // 
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(104, 40);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												  this.repositoryItemCheckEdit2});
            this.gridControl1.Size = new System.Drawing.Size(456, 234);
            this.gridControl1.TabIndex = 56;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																										this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																							 this.gridColumn2,
																							 this.gridColumn1,
																							 this.gridColumn3});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Item Code";
            this.gridColumn1.FieldName = "strProductCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Product Description";
            this.gridColumn3.FieldName = "strDescription";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "OutStock";
            this.gridColumn2.ColumnEdit = this.repositoryItemCheckEdit2;
            this.gridColumn2.FieldName = "OutStock";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            this.repositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButton1.Location = new System.Drawing.Point(104, 280);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.TabIndex = 57;
            this.simpleButton1.Text = "Save";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButton2.Location = new System.Drawing.Point(184, 280);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.TabIndex = 58;
            this.simpleButton2.Text = "Cancel";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // lkpEdtItemFreebiePromotionCode
            // 
            this.lkpEdtItemFreebiePromotionCode.EditValue = "";
            this.lkpEdtItemFreebiePromotionCode.Location = new System.Drawing.Point(104, 8);
            this.lkpEdtItemFreebiePromotionCode.Name = "lkpEdtItemFreebiePromotionCode";
            // 
            // lkpEdtItemFreebiePromotionCode.Properties
            // 
            this.lkpEdtItemFreebiePromotionCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lkpEdtItemFreebiePromotionCode.Properties.Appearance.Options.UseFont = true;
            this.lkpEdtItemFreebiePromotionCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																   new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpEdtItemFreebiePromotionCode.Size = new System.Drawing.Size(250, 25);
            this.lkpEdtItemFreebiePromotionCode.TabIndex = 59;
            this.lkpEdtItemFreebiePromotionCode.EditValueChanged += new System.EventHandler(this.PromotionChanged);
            // 
            // frmNewPromotionSelection
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(568, 311);
            this.Controls.Add(this.lkpEdtItemFreebiePromotionCode);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewPromotionSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Promotion Selection";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpEdtItemFreebiePromotionCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void PromotionChanged(object sender, System.EventArgs e)
        {
            ACMSDAL.TblProduct product = new ACMSDAL.TblProduct();
            DataTable table = product.GetPromotionProductBaseOnPromotionCode(this.lkpEdtItemFreebiePromotionCode.EditValue.ToString(), this.strBranchCode);

            if (table != null)
            {
                DataColumn colChecked = new DataColumn("OutStock", typeof(bool));
                table.Columns.Add(colChecked);

                foreach (DataRow r in table.Rows)
                {
                    r["OutStock"] = false;
                }

                if (table.Rows.Count > 0)
                {
                    this.gridControl1.DataSource = table;
                    this.simpleButton1.Enabled = true;
                }
                else
                {
                    UI.ShowErrorMessage(this, "No record(s) found", "Error");
                    this.simpleButton1.Enabled = false;
                }
            }
            else
            {
                UI.ShowErrorMessage(this, "No record(s) found", "Error");
                this.simpleButton1.Enabled = false;
            }

        }

        private void simpleButton1_Click(object sender, System.EventArgs e)
        {
            bool isSave = false;
            bool isError = false;
            DevExpress.XtraGrid.Columns.GridColumn col1 = gridView1.Columns.ColumnByFieldName("strProductCode");
            DevExpress.XtraGrid.Columns.GridColumn col2 = gridView1.Columns.ColumnByFieldName("strDescription");
            DevExpress.XtraGrid.Columns.GridColumn col3 = gridView1.Columns.ColumnByFieldName("OutStock");

            SqlConnection sqlcon = new SqlConnection(SqlHelperUtils.connectionString);
            sqlcon.Open();

            SqlTransaction tran = sqlcon.BeginTransaction();

            ACMSLogic.Promotion.Promotion promotion = new ACMSLogic.Promotion.Promotion();
            //promotion.DeleteAdjustmentPromotion(tran,this.textEdit2.Text,this.textEdit1.Text);

            for (int i = 0; i < this.gridView1.DataRowCount; i++)
            {
                object cellValue1 = gridView1.GetRowCellValue(i, col1);
                object cellValue3 = gridView1.GetRowCellValue(i, col3);

                if (cellValue3 != null)
                {
                    if (Convert.ToBoolean(cellValue3.ToString()))
                    {
                        DataSet dsQty = new DataSet();
                        string strSQL = "select (ISNULL((select nMaxQty from tblPromotionFreebie where strPromotionCode ='" + this.lkpEdtItemFreebiePromotionCode.EditValue.ToString() + "' and strItemCode='" + cellValue1.ToString() + "'),0) - ISNULL((select COUNT(*) from tblReceiptFreebie WITH (NOLOCK) where strReceiptNo ='" + strReceiptNo + "' and strItemCode='" + cellValue1.ToString() + "' group by strReceiptNo),0)) as nQty ";

                        SqlHelper.FillDataset(tran, CommandType.StoredProcedure, "UP_GETDATA", dsQty, new string[] { "Table" }, new SqlParameter("@strSQL", strSQL));
                        DataTable dtQty = dsQty.Tables["Table"];

                        if (Convert.ToInt16(dtQty.Rows[0]["nQty"]) > 0)
                        {
                            if (promotion.UpdateAdjustmentPromotion(tran, strReceiptNo, cellValue1.ToString(), this.lkpEdtItemFreebiePromotionCode.EditValue.ToString(), strBranchCode, Convert.ToInt32(nEntryID), panel))
                            {
                                isSave = true;
                            }
                            else
                            {
                                isError = false;
                            }
                        }
                        else
                            Utils.UI.ShowMessage(this, "Out stock qty exceed maximum qty allowed!");

                        dtQty.Dispose();
                        dsQty.Dispose();
                    }
                }
            }

            if (isError)
            {
                Utils.UI.ShowMessage(this, "Some of the record cannot be saved into database. Please contact System Administrator!");
            }
            else
            {
                if (isSave)
                    Utils.UI.ShowMessage(this, "Record Has Been Updated");

                tran.Commit();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void simpleButton2_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}