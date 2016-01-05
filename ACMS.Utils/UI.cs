using System;
using System.Collections;
using System.Windows.Forms;

namespace ACMS.Utils
{
	/// <summary>
	/// Summary description for UI.
	/// </summary>
	public class UI
	{
		#region Clear Data Binding
		public static void ClearDataBinding(IEnumerable controls)
		{
			foreach (Control control1 in controls)
			{
				control1.DataBindings.Clear();
				if (control1.Controls.Count > 0)
				{
					ClearDataBinding(control1.Controls);
				}
			}
		}
		#endregion

		#region Show Error Message
		/// <summary>
		/// Show error with Exclamation Icon
		/// </summary>
		/// <param name="text"></param>
		public static void ShowErrorMessage(string text)
		{
			ShowErrorMessage(null, text, "Error");
		}

		/// <summary>
		/// Show error with Exclamation Icon
		/// </summary>
		/// <param name="owner"></param>
		/// <param name="text"></param>
		public static void ShowErrorMessage(System.Windows.Forms.IWin32Window owner, string text)
		{
			ShowErrorMessage(owner, text, "Error");
		}

		/// <summary>
		/// Show error with Exclamation Icon
		/// </summary>
		/// <param name="owner"></param>
		/// <param name="text"></param>
		/// <param name="caption"></param>
		public static void ShowErrorMessage(System.Windows.Forms.IWin32Window owner, string text, string caption)
		{
			MessageBox.Show(owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		#endregion

		#region Show Yes/No Message
		public static bool ShowYesNoMessage(string text)
		{
			return ShowYesNoMessage(null, text, "Question");
		}

		public static bool ShowYesNoMessage(System.Windows.Forms.IWin32Window owner, string text)
		{
			return ShowYesNoMessage(owner, text, "Question");
		}

		public static bool ShowYesNoMessage(System.Windows.Forms.IWin32Window owner, string text, string caption)
		{
            //string strMsg = MessageBox.Show(owner, text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
			if (MessageBox.Show(owner, text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
           // if (MessageBox.Show(text) == DialogResult.Yes)
				return true;
			else
				return false;
		}
		#endregion

		#region Show Fatal Error Message
		/// <summary>
		/// Show error with Warning Icon
		/// </summary>
		/// <param name="text"></param>
		public static void ShowFatalErrorMessage(string text)
		{
			ShowFatalErrorMessage(null, text);
		}

		/// <summary>
		/// Show error with Warning Icon
		/// </summary>
		/// <param name="owner"></param>
		/// <param name="text"></param>
		public static void ShowFatalErrorMessage(System.Windows.Forms.IWin32Window owner, string text)
		{
			MessageBox.Show(owner, text, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		#endregion

		#region Show Warning Message
		/// <summary>
		/// Show error with Warning Icon
		/// </summary>
		/// <param name="text"></param>
		public static void ShowWarningMessage(string text)
		{
			ShowWarningMessage(null, text, "Warning");
		}

		/// <summary>
		/// Show error with Warning Icon
		/// </summary>
		/// <param name="owner"></param>
		/// <param name="text"></param>
		public static void ShowWarningMessage(System.Windows.Forms.IWin32Window owner, string text)
		{
			ShowWarningMessage(owner, text, "Warning");
		}

		/// <summary>
		/// Show error with Warning Icon
		/// </summary>
		/// <param name="owner"></param>
		/// <param name="text"></param>
		/// <param name="caption"></param>
		public static void ShowWarningMessage(System.Windows.Forms.IWin32Window owner, string text, string caption)
		{
			MessageBox.Show(owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
		#endregion

		#region Show Message
		/// <summary>
		/// Show Message without any icon
		/// </summary>
		/// <param name="owner"></param>
		/// <param name="text"></param>
		public static void ShowMessage(string text)
		{
			ShowMessage(null, text);
		}

		/// <summary>
		/// Show Message without any icon
		/// </summary>
		/// <param name="owner"></param>
		/// <param name="text"></param>
		public static void ShowMessage(System.Windows.Forms.IWin32Window owner, string text)
		{
			MessageBox.Show(owner, text); 
		}
		#endregion
	}
}
