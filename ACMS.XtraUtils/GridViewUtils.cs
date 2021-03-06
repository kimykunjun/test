using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ACMS;

namespace ACMS.XtraUtils
{
	/// <summary>
	/// Summary description for GridViewUtils.
	/// </summary>
	public class GridViewUtils
	{
		public GridViewUtils()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		public static void UpdateData(GridView gridView)
		{
			gridView.CloseEditor();
			gridView.UpdateCurrentRow();
		}

		public static GridHitInfo GetGridHitInfo(GridView gridView)
		{
			Point point1 = Control.MousePosition;
			point1 = gridView.GridControl.PointToClient(point1);
			return gridView.CalcHitInfo(new Point(point1.X, point1.Y));
		}

		public static void TblCase_CustomColumnDisplayText(DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
		{
			if (e.Column.FieldName == "nStatusID")
			{
				if (e.Value != null)
				{
					if (ACMS.Convert.ToInt32(e.Value) == 0)
						e.DisplayText = "New";
					else if (ACMS.Convert.ToInt32(e.Value) == 1)
						e.DisplayText = "Pending";
					else if (ACMS.Convert.ToInt32(e.Value) == 2)
						e.DisplayText = "Closed";
				}
			}
		}

		public static void TblClassAttendance_CustomColumnDisplayText(DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
		{

			//0 - Reserved
			//1 - Processed
			//2 - Forfeited
			//3 - Cancelled
			//4 - Inserted
			//5 - Deleted"

			if (e.Column.FieldName == "nStatusID")
			{
				if (e.Value != null)
				{
					if (ACMS.Convert.ToInt32(e.Value) == 0)
						e.DisplayText = "Reserved";
					else if (ACMS.Convert.ToInt32(e.Value) == 1)
						e.DisplayText = "Processed";
					else if (ACMS.Convert.ToInt32(e.Value) == 2)
						e.DisplayText = "Forfeited";
					else if (ACMS.Convert.ToInt32(e.Value) == 3)
						e.DisplayText = "Cancelled";
					else if (ACMS.Convert.ToInt32(e.Value) == 4)
						e.DisplayText = "Inserted";
					else if (ACMS.Convert.ToInt32(e.Value) == 5)
						e.DisplayText = "Deleted";
				}
			}
		}
		
		public static void TblServiceSession_CustomColumnDisplayText(DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
		{
			//
			//0 - Active(Calculate as attended)
			//1- Deleted(No Calculate as attended)
			//2- Booked(No Calculate as attended)
			//3- Waiting List(No Calculate as attended)
			//4- Contacted(No Calculate as attended)
			//5- Processed(Calculated as attended)
			//6- Forfeited(Calculate as attended)
			//7-Cancelled (No Calculate as attended)"


			if (e.Column.FieldName == "nStatusID")
			{
				if (e.Value != null)
				{
					if (ACMS.Convert.ToInt32(e.Value) == 0)
						e.DisplayText = "Active";
					else if (ACMS.Convert.ToInt32(e.Value) == 1)
						e.DisplayText = "Deleted";
					else if (ACMS.Convert.ToInt32(e.Value) == 2)
						e.DisplayText = "Booked";
					else if (ACMS.Convert.ToInt32(e.Value) == 3)
						e.DisplayText = "Waiting";
					else if (ACMS.Convert.ToInt32(e.Value) == 4)
						e.DisplayText = "Contacted";
					else if (ACMS.Convert.ToInt32(e.Value) == 5)
						e.DisplayText = "Processed";
					else if (ACMS.Convert.ToInt32(e.Value) == 6)
						e.DisplayText = "Forfeited";
					else if (ACMS.Convert.ToInt32(e.Value) == 7)
						e.DisplayText = "Cancelled";
				}
			}
		}

		public static void TblMemberPackage_CustomColumnDisplayText(DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
		{
			//
			//0 - Active
			//1- Expiry
			//2- Deleted
            //3- Converted
            //4- Refund

			if (e.Column.FieldName == "nStatusID")
			{
				if (e.Value != null)
				{
                    if (ACMS.Convert.ToInt32(e.Value) == 0)
                    {
                        e.DisplayText = "Active";
                    }
                    else if (ACMS.Convert.ToInt32(e.Value) == 1)
                    {
                        e.DisplayText = "Expiry";
                    }
                    else if (ACMS.Convert.ToInt32(e.Value) == 2)
                    {
                        e.DisplayText = "Deleted";
                    }
                    else if (ACMS.Convert.ToInt32(e.Value) == 3)
                    {
                        e.DisplayText = "Converted";
                    }
                    else if (ACMS.Convert.ToInt32(e.Value) == 9)
                    {
                        e.DisplayText = "Suspended";
                    }
				}
            }
            
		}

		public static void TblMemberCreditPackage_CustomColumnDisplayText(DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
		{
			//
			//0 - Active
			//1- Expiry
			//2- Deleted
			TblMemberPackage_CustomColumnDisplayText(e);
		}
		
	}
}
                                                                                                                                                                                             