using System;
using System.Reflection;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraNavBar;
using DevExpress.Utils.Menu;
using DevExpress.DXperience.Demos;

namespace DevExpress.XtraScheduler.Demos {
	public class DemosInfo : ModulesInfo {
        public static void ShowModule(string name, DevExpress.XtraEditors.GroupControl groupControl, ACMS.ACMSStaff.To_Do_List.SchedulerAppearanceMenu menu, IDXMenuManager menuManager, DevExpress.Utils.Frames.ApplicationCaption caption)
        {
            ModuleInfo item = DemosInfo.GetItem(name);
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Control oldTutorial = null;
                if (Instance.CurrentModuleBase != null)
                {
                    if (Instance.CurrentModuleBase.Name == name) return;
                    oldTutorial = Instance.CurrentModuleBase.TModule;
                }

                TutorialControl tutorial = item.TModule as TutorialControl;
                tutorial.Bounds = groupControl.DisplayRectangle;
                Instance.CurrentModuleBase = item;
                tutorial.Visible = false;
                groupControl.Controls.Add(tutorial);
                tutorial.Dock = DockStyle.Fill;

                //-----Set----
                //tutorial.DemoMainMenu = menu;
                tutorial.TutorialName = name;
                tutorial.Caption = caption;
                tutorial.MenuManager = menuManager;
                //------------

                tutorial.Visible = true;
                item.WasShown = true;
                //menu.SchedulerControl = tutorial.PrintingSchedulerControl;
                if (oldTutorial != null)
                {
                    ((TutorialControl)oldTutorial).DemoMainMenu = null;
                    oldTutorial.Visible = false;
                }
            }
            finally
            {
                Cursor.Current = currentCursor;
            }
            RaiseModuleChanged();
        }
	}
}
