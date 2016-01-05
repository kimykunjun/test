using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace DevExpress.XtraTreeList.Demos
{
    public partial class TreeListDragDrop : TutorialControl
    {
        public TreeListDragDrop()
        {
            InitializeComponent();
            InitData();
        }
        private ListViewItem newItem = null;
        public override TreeList ExportControl { get { return treeList1; } }

        private void InitData()
        {
            TreeListNode Mainnode = null;
            TreeListNode node = null;
            Mainnode = treeList1.AppendNode(new object[] { "Setup Road Show", 2 }, null);
            Mainnode.StateImageIndex = 0;
            node = treeList1.AppendNode(new object[] { "Find Location", 2 }, Mainnode);
            node.StateImageIndex = 1;
            treeList1.AppendNode(new object[] { "Compare rental", 2 }, node).StateImageIndex = 2;
            treeList1.AppendNode(new object[] { "Evaluate region population", 2 }, node).StateImageIndex = 2;
            node = treeList1.AppendNode(new object[] { "Budget Costing", 0 }, Mainnode);
            node.StateImageIndex = 1;
            treeList1.AppendNode(new object[] { "Previous Road Show Cost", 0 }, node).StateImageIndex = 2;
            treeList1.AppendNode(new object[] { "Current ROad Show Cost", 2 }, node).StateImageIndex = 2;
            treeList1.AppendNode(new object[] { "Approved By COO", 1 }, node).StateImageIndex = 2;
            treeList1.AppendNode(new object[] { "Prepare Payment to Vendor", 2 }, node).StateImageIndex = 2;
            node = treeList1.AppendNode(new object[] { "Promotion Adv", 2 }, Mainnode);
            node.StateImageIndex = 1;


            treeList1.ExpandAll();
            treeList1.BestFitColumns();
        }
        private void SetDefaultCursor()
        {
            Cursor = Cursors.Default;
        }
        private void SetDragCursor(DragDropEffects e)
        {

            if (e == DragDropEffects.Move)
                //Cursor = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DevExpress.XtraTreeList.Demos.Images.move.ico"));
                Cursor = Cursors.Hand;
            if (e == DragDropEffects.Copy)
                //Cursor = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DevExpress.XtraTreeList.Demos.Images.copy.ico"));
                Cursor = Cursors.Hand;
            if (e == DragDropEffects.None)
                Cursor = Cursors.No;
        }
        private DragObject GetDragObject(IDataObject data)
        {
            return data.GetData(typeof(DragObject)) as DragObject;
        }
        private TreeListNode GetDragNode(IDataObject data)
        {
            return data.GetData(typeof(TreeListNode)) as TreeListNode;
        }
        private TreeListNode GetVisibleNodeAbove(TreeListNode node)
        {
            int visIndex = treeList1.GetVisibleIndexByNode(node);
            return treeList1.GetNodeByVisibleIndex(visIndex - 1);
        }

        private void listView1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            newItem = listView1.GetItemAt(e.X, e.Y);
        }

        private void listView1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (newItem == null || e.Button != MouseButtons.Left) return;
            listView1.DoDragDrop(new DragObject(newItem.Index), DragDropEffects.Copy);
        }

        private void listView1_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
        }
        //
        private void treeList1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            TreeListHitInfo hi = treeList1.CalcHitInfo(treeList1.PointToClient(new Point(e.X, e.Y)));
            DragObject dobj = GetDragObject(e.Data);
            if (dobj != null)
            {
                TreeListNode node = hi.Node;
                if (hi.HitInfoType == HitInfoType.Empty || node != null)
                {
                    node = treeList1.AppendNode(dobj.DragData, node);
                    node.StateImageIndex = dobj.ImageIndex;
                    treeList1.MakeNodeVisible(node);
                    TreeListNode parentNode = node.ParentNode;
                    if (parentNode != null && (e.KeyState & 4) != 0)
                    {
                        int index = -1;
                        if (parentNode.ParentNode != null)
                            index = parentNode.ParentNode.Nodes.IndexOf(parentNode);
                        treeList1.MoveNode(node, parentNode.ParentNode);
                        treeList1.SetNodeIndex(node, index);
                    }
                }
            }
            SetDefaultCursor();
        }

        private void treeList1_DragLeave(object sender, System.EventArgs e)
        {
            SetDefaultCursor();
        }

        private void treeList1_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            TreeListHitInfo hi = treeList1.CalcHitInfo(treeList1.PointToClient(new Point(e.X, e.Y)));
            TreeListNode node = GetDragNode(e.Data);
            if (node == null)
            {
                if (hi.HitInfoType == HitInfoType.Empty || hi.Node != null)
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            }
            SetDragCursor(e.Effect);
        }
        private void treeList1_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
        }
        //
        private void label1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            TreeListNode node = GetDragNode(e.Data);
            if (node != null)
            {
                e.Effect = DragDropEffects.Copy;
                Cursor = Cursors.Hand;
                label1.ImageIndex = 1;
            }
            else
                Cursor = Cursors.No;
        }
        private void SetDefaultLabel()
        {
            label1.ImageIndex = 0;
            SetDefaultCursor();
        }
        private void label1_DragLeave(object sender, System.EventArgs e)
        {
            SetDefaultLabel();
        }

        private void label1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            TreeListNode node = GetDragNode(e.Data);
            if (node != null)
            {
                treeList1.DeleteNode(node);
            }
            SetDefaultLabel();
        }
    }
}
