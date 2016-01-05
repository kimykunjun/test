using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace ACMS.XtraUtils
{
	/// <summary>
	/// Summary description for XtraEditors.
	/// </summary>
	public class XtraEditors
	{
		public static void SetDateEditFormat(DateEdit dateEdit)
		{
			dateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			dateEdit.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
			dateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			dateEdit.Properties.EditFormat.FormatString = "dd/MM/yyyy";
			dateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
			dateEdit.Properties.Mask.EditMask = "dd/MM/yyyy";
		}

		public static void SetDateEditFormat(IEnumerable controls)
		{
			foreach (Control control1 in controls)
			{
				if (control1 is DateEdit)
				{
					XtraEditors.SetDateEditFormat((DateEdit) control1);
				}
				else if (control1.Controls.Count > 0)
				{
					XtraEditors.SetDateEditFormat(control1.Controls);
				}
			}
		}
	}
}