using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Demos;
using DevExpress.XtraTreeList.Nodes;
using ACMSDAL;
using DevExpress.XtraScheduler.UI;
using Email = Microsoft.Office.Interop.Outlook;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;


namespace ACMS.ACMSStaff.To_Do_List
{
    public partial class ucWorkFlow : UserControl
    {
        private int nParentNodeID;
        private int nDepartment;
        private int nEmployee;
        private string strType;
        private int nFilterID = 0;
        private int npointer = 0;
        private string strChild;
        private int nKey = 0;
        //private DSWorkFlow.tblWorkFlowDataTable dt = new DSWorkFlow.tblWorkFlowDataTable();
        public ucWorkFlow(int nDepartmentID,int nEmployeeID)
        {
            InitializeComponent();
            nDepartment = nDepartmentID;
            nEmployee = nEmployeeID;
        }

        private void ucWorkFlow_Load(object sender, EventArgs e)
        {
            //tblWorkFlowTableAdapter.Fill(this.dSWorkFlow.tblWorkFlow, nDepartment);
            tblWorkFlowTableAdapter2.Fill(this.dSWorkFlow.tblWorkFlow);
            this.tblDepartmentTableAdapter.Fill(this.aCMSDataSet6.tblDepartment);
            if (treeList1.FocusedNode != null)
            txtDetail.Text = treeList1.FocusedNode.GetValue("strDetail").ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DSWorkFlow.tblWorkFlowDataTable dt = new DSWorkFlow.tblWorkFlowDataTable();
            nKey = System.Convert.ToInt32(tblWorkFlowTableAdapter2.GetKey());
            treeList1.FocusedNode = treeList1.AppendNode(dt.AddtblWorkFlowRow(nKey,0, 0, "", nDepartment, nEmployee, ""), null);
            tblWorkFlowTableAdapter2.Insert(0, 1, "", nDepartment, nEmployee,"");
            //tblWorkFlowTableAdapter.Update(dSWorkFlow);
            //tblWorkFlowTableAdapter.Fill(this.dSWorkFlow.tblWorkFlow, nDepartment);
            tblWorkFlowTableAdapter2.Fill(this.dSWorkFlow.tblWorkFlow);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null)
            {
                if (treeList1.FocusedNode.Level == 0)
                {
                    DSWorkFlow.tblWorkFlowDataTable dt1 = new DSWorkFlow.tblWorkFlowDataTable();
                    nParentNodeID = (int)treeList1.FocusedNode.GetValue("ID");
                    nKey = System.Convert.ToInt32(tblWorkFlowTableAdapter2.GetKey());
                    treeList1.FocusedNode = treeList1.AppendNode(dt1.AddtblWorkFlowRow(nKey,nParentNodeID, 0, "", nDepartment, nEmployee, ""), treeList1.FocusedNode.Id);
                    //treeList1.FocusedNode = treeList1.AppendNode(new object[] {nParentNodeID,0,"",4,3798}, treeList1.FocusedNode.Id);
                    //tblWorkFlowTableAdapter.Insert(nParentNodeID, 1, "", "");
                    tblWorkFlowTableAdapter2.Update(dt1);
                    //tblWorkFlowTableAdapter.Fill(this.dSWorkFlow.tblWorkFlow);
                }
                else
                {
                    DSWorkFlow.tblWorkFlowDataTable dt = new DSWorkFlow.tblWorkFlowDataTable();
                    nKey = System.Convert.ToInt32(tblWorkFlowTableAdapter2.GetKey());
                    nParentNodeID = (int)treeList1.FocusedNode.GetValue("ID");
                    treeList1.FocusedNode = treeList1.AppendNode(dt.AddtblWorkFlowRow(nKey,nParentNodeID, 0, "", nDepartment, nEmployee, ""), treeList1.FocusedNode.Id);
                    //tblWorkFlowTableAdapter.Insert(nParentNodeID, 1, "", "");
                    tblWorkFlowTableAdapter2.Update(dt);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null)
            {
                int nDelete = System.Convert.ToInt32(treeList1.FocusedNode.GetValue("ID"));
                tblWorkFlowTableAdapter2.Delete(System.Convert.ToInt32(treeList1.FocusedNode.GetValue("ID")));
                treeList1.DeleteNode(treeList1.FocusedNode);
                //tblWorkFlowTableAdapter.Update(this.dSWorkFlow.tblWorkFlow);
                GetChild(nDelete);
                if (strChild != null)
                    DeleteSubTask(strChild.Substring(0, strChild.Length - 1));
            }
        }
        private void DeleteSubTask(string strSubTask)
        {
            string[] arrSubTask = strSubTask.Split(',');
            int nSubTask;
            for (int p = 0; p < arrSubTask.Length; p++)
            {
                nSubTask = System.Convert.ToInt32(arrSubTask[p]);
                tblWorkFlowTableAdapter2.Delete(nSubTask);
            }
        }

        private DataTable GetChild(int Parent)
        {
            int[] ChildNodes = new int[100], MultiNodes = new int[100];
            this.tblWorkFlowTableAdapter1.GetChild(this.dsWorkFLowDetail.tblWorkFlow, Parent);
            DataTable tblChild = this.dsWorkFLowDetail.tblWorkFlow;
            if (tblChild.Rows.Count > 0)
            {
                for (int i = 0; i <= tblChild.Rows.Count - 1; i++)
                {
                    ChildNodes[i] = System.Convert.ToInt32(tblChild.Rows[i][0]);
                    strChild = strChild + ChildNodes[i].ToString() + ",";
                }
            }
            SplitChild(strChild);
            return tblChild;
        }

        private void SplitChild(string strChildren)
        {
            npointer++;
            if (strChildren != null)
            {
                string[] strChars = strChildren.Substring(0, strChildren.Length - 1).Split(',');
                if (npointer < strChars.Length + 1)
                {
                    GetChild(System.Convert.ToInt32(strChars[npointer - 1]));
                }
            }

            //npointer=+1;
        }
        private void treeList1_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
           // (sender as DevExpress.XtraTreeList.TreeList).EndCurrentEdit();
            //tblWorkFlowTableAdapter.Update(dSWorkFlow.tblWorkFlow);
            DataRow[] rowUpdate = dSWorkFlow.tblWorkFlow.Select("ID = " + treeList1.FocusedNode.GetValue("ID").ToString());
            string strProject = "";
            int nID, nDepartment = 0;
            nID = System.Convert.ToInt32(treeList1.FocusedNode.GetValue("ID"));
            if (rowUpdate[0]["strProject"].ToString() != string.Empty)
                strProject = rowUpdate[0]["strProject"].ToString();
            if (rowUpdate[0]["nDepartmentID"].ToString() != string.Empty)
                nDepartment = System.Convert.ToInt32(rowUpdate[0]["nDepartmentID"]);
            tblWorkFlowTableAdapter2.UpdateValue(strProject,nDepartment,rowUpdate[0]["strDetail"].ToString(),nID);
        }

        private DevExpress.XtraTreeList.Demos.DragObject GetDragObject(IDataObject data)
        {
            return data.GetData(typeof(DevExpress.XtraTreeList.Demos.DragObject)) as DevExpress.XtraTreeList.Demos.DragObject;
        }

        private void treeList1_DragDrop(object sender, DragEventArgs e)
        {
            DevExpress.XtraTreeList.TreeListHitInfo hi = treeList1.CalcHitInfo(treeList1.PointToClient(new Point(e.X, e.Y)));
            //DragObject dobj = GetDragObject(e.Data);
            TreeListNode dragNode = e.Data.GetData(typeof(TreeListNode)) as TreeListNode;
            DragObject dobj = e.Data.GetData(typeof(TreeListNode)) as DragObject;
            if (dragNode != null)
            {
                TreeListNode node = hi.Node;
                if (hi.HitInfoType == HitInfoType.Empty || node != null)
                {                   
                    TreeListNode parentNode = node.ParentNode;                  
                    int index = -1;                   
                    treeList1.MoveNode(dragNode, node, true);
                    treeList1.SetNodeIndex(dragNode, index);                    
                }
                //if (treeList1.FocusedNode.Level == 1)                
                //    treeList1.FocusedNode.ImageIndex = 1;
                //else
                //    treeList1.FocusedNode.ImageIndex = 2;
            }
            (sender as DevExpress.XtraTreeList.TreeList).EndCurrentEdit();
            tblWorkFlowTableAdapter2.Update(dSWorkFlow);
        }

        private void SetDefaultCursor()
        {
            Cursor = Cursors.Default;
        }

     
        private void treeList1_DragOver(object sender, DragEventArgs e)
        {
            DevExpress.XtraTreeList.TreeListHitInfo hi = treeList1.CalcHitInfo(treeList1.PointToClient(new Point(e.X, e.Y)));
            DevExpress.XtraTreeList.Nodes.TreeListNode node = GetDragNode(e.Data);
            if (node != null)
            {
                if (hi.HitInfoType == DevExpress.XtraTreeList.HitInfoType.Empty || hi.Node != null)
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            }
            SetDragCursor(e.Effect);
            tblWorkFlowTableAdapter2.Update(dSWorkFlow);
            
        }

        private void SetDragCursor(DragDropEffects e)
        {           
                Cursor = Cursors.Hand;
           
        }

        private DevExpress.XtraTreeList.Nodes.TreeListNode GetDragNode(IDataObject data)
        {
            return data.GetData(typeof(DevExpress.XtraTreeList.Nodes.TreeListNode)) as DevExpress.XtraTreeList.Nodes.TreeListNode;
        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            
            if (treeList1.FocusedNode != null)
            {
                nFilterID = System.Convert.ToInt32(treeList1.FocusedNode.GetValue("ID"));
                tblWorkFlowTableAdapter1.Fill(this.dsWorkFLowDetail.tblWorkFlow, nFilterID);
                if (this.dsWorkFLowDetail.tblWorkFlow.Rows.Count > 0)
                txtDetail.Text = this.dsWorkFLowDetail.tblWorkFlow.Rows[0]["strDetail"].ToString();                
                //if (e.OldNode != null)
                //{
                //    nID = System.Convert.ToInt32(e.OldNode.GetValue("ID"));
                //    nDept = System.Convert.ToInt32(e.OldNode.GetValue("nDepartmentID"));
                //    strDesc = txtDetail.Text;
                //    strProj = e.OldNode.GetValue("strProject").ToString();
                //    tblWorkFlowTableAdapter.UpdateValue(strProj, nDept, strDesc, nID);
                //}
 
            }
            
            tblDeliveryScheduleTableAdapter.FillByWorkFlow(this.aCMSDataSet.TblDeliverySchedule, nFilterID);
            this.aCMSDataSet5.EnforceConstraints = false;
            this.tblAttachmentTableAdapter.Fill(this.aCMSDataSet5.tblAttachment, nFilterID);
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi =
                  gridView1.CalcHitInfo((sender as System.Windows.Forms.Control).PointToClient(System.Windows.Forms.Control.MousePosition));
            DataRow FocusRow;
            if (hi.RowHandle >= 0)
            {
                FocusRow = gridView1.GetDataRow(hi.RowHandle);
                ACMS.ACMSStaff.WorkFlow.MyCustomEditForm frm = new ACMS.ACMSStaff.WorkFlow.MyCustomEditForm((int)FocusRow.ItemArray[0], nDepartment);
                frm.Show();
            }
            else if (gridView5.FocusedRowHandle >= 0)
            {
                FocusRow = gridView1.GetDataRow(gridView5.FocusedRowHandle);
                ACMS.ACMSStaff.WorkFlow.MyCustomEditForm frm = new ACMS.ACMSStaff.WorkFlow.MyCustomEditForm((int)FocusRow.ItemArray[0], nDepartment);
                frm.Show();
            }
        }

        private void txtDetail_EditValueChanged(object sender, EventArgs e)
        {
            int nDept = 0, nID = 0;
            string strDesc = "", strProj = "";
            if (treeList1.FocusedNode != null)
            {
                nID = System.Convert.ToInt32(treeList1.FocusedNode.GetValue("ID"));
                nDept = System.Convert.ToInt32(treeList1.FocusedNode.GetValue("nDepartmentID"));
                strDesc = txtDetail.Text;
                strProj = treeList1.FocusedNode.GetValue("strProject").ToString();
                tblWorkFlowTableAdapter2.Connection.Close();
                tblWorkFlowTableAdapter2.UpdateValue(strProj, nDept, strDesc, nID);
                //tblWorkFlowTableAdapter.Fill(this.dSWorkFlow.tblWorkFlow);
            }
        }

        private void comboBoxEdit1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Words (*.doc)|*.doc|PdF (*.pdf)|*.pdf|Excel (*.xls)|*.xls|OutLook (*.msg)|*.msg|Video (*.avi)|*.avi";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                if ((openFileDialog1.OpenFile()) != null)
                {
                    if (openFileDialog1.FileName.Length > 255)
                    {
                        ACMS.Utils.UI.ShowErrorMessage(this, "The file name character is larger than 255. Please "
                            + "select a file less or equal to 255 character.");
                        // sbtnBeforePhoto.Focus();
                        return;
                    }
                    comboBoxEdit1.Text = openFileDialog1.FileName.ToString();

                }
            } 
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string strAttachType = comboBoxEdit1.Text.Substring(comboBoxEdit1.Text.Length - 3, 3);
            strType = "";
            if (strAttachType == "pdf")
                strType = "PDF";
            else if (strAttachType == "xls")
                strType = "EXCEL";
            else if (strAttachType == "doc")
                strType = "WORD";
            else if (strAttachType == "msg")
                strType = "OUTLOOK";
            else if (strAttachType == "avi")
                strType = "VIDEO";

            this.tblAttachmentTableAdapter.Insert(nFilterID, DateTime.Now, strType, comboBoxEdit1.Text);
            this.tblAttachmentTableAdapter.Fill(this.aCMSDataSet5.tblAttachment, nFilterID);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi =
         gridView5.CalcHitInfo((sender as System.Windows.Forms.Control).PointToClient(System.Windows.Forms.Control.MousePosition));
            DataRow FocusRow;
            if (hi.RowHandle >= 0)
            {
                FocusRow = gridView5.GetDataRow(hi.RowHandle);
                int nAttachment = System.Convert.ToInt32(FocusRow.ItemArray[0]);
                this.tblAttachmentTableAdapter.DeleteQuery(nAttachment);
            }
            else if (gridView5.FocusedRowHandle >= 0)
            {
                FocusRow = gridView5.GetDataRow(gridView5.FocusedRowHandle);
                int nAttachment = System.Convert.ToInt32(FocusRow.ItemArray[0]);
                this.tblAttachmentTableAdapter.DeleteQuery(nAttachment);

            }
            this.tblAttachmentTableAdapter.Fill(this.aCMSDataSet5.tblAttachment, nFilterID);
        }

        private void gridControl3_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi =
           gridView5.CalcHitInfo((sender as System.Windows.Forms.Control).PointToClient(System.Windows.Forms.Control.MousePosition));
            DataRow FocusRow;
            if (hi.RowHandle >= 0)
            {
                FocusRow = gridView5.GetDataRow(hi.RowHandle);
                string strType = FocusRow.ItemArray[3].ToString();
                string strPath = FocusRow.ItemArray[4].ToString();
                if (strType == "OUTLOOK")
                {
                    try
                    {
                        Email.Application oApp = new Email.Application();
                        Email._MailItem oMailItem = (Email._MailItem)oApp.CreateItemFromTemplate(strPath, Type.Missing);
                        //oMailItem.Subject = "abc";

                        oMailItem.Display(false);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (strType == "WORD")
                {
                    try
                    {
                        Word.Application wordApp;
                        Word.Document doc;
                        wordApp = new Word.ApplicationClass();
                        wordApp.Visible = true;
                        object fileName = strPath;
                        object missing = Type.Missing;
                        object fReadOnly = false;
                        doc = wordApp.Documents.Open(ref fileName,
                            ref missing, ref fReadOnly, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref missing, ref missing);
                        //doc.Activate();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (strType == "EXCEL")
                {
                    try
                    {
                        Excel.ApplicationClass oExcel = new Excel.ApplicationClass();
                        Excel.Workbook workBook = oExcel.Workbooks.Open(strPath, 0, true, 5, null, null, true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, null, null);
                        //Excel.Worksheet ws = (Excel.Worksheet)oExcel.ActiveSheet;
                        //ws.Activate();
                        //ws.get_Range("A1", "IV65536").Font.Size = 8;
                        oExcel.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (strType == "PDF")
                {
                    ACMS.ACMSStaff.To_Do_List.frmPDFviewer frm = new ACMS.ACMSStaff.To_Do_List.frmPDFviewer(strPath);
                    frm.Show();
                }
                else if (strType == "VIDEO")
                {
                    ACMS.ACMSStaff.To_Do_List.frmVideoPlayer frmPlayer = new ACMS.ACMSStaff.To_Do_List.frmVideoPlayer(strPath);
                    frmPlayer.Show();
                }
            }
            else if (gridView5.FocusedRowHandle >= 0)
            {
                FocusRow = gridView5.GetDataRow(gridView5.FocusedRowHandle);
                string strType = FocusRow.ItemArray[3].ToString();
                string strPath = FocusRow.ItemArray[4].ToString();
                //ACMS.ACMSStaff.WorkFlow.MyCustomEditForm frm = new ACMS.ACMSStaff.WorkFlow.MyCustomEditForm((int)FocusRow.ItemArray[0], oUser.NDepartmentID());
                //frm.Show();
            }
        }
    }
}
