using System;
using System.IO;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraScheduler.Outlook;
using DevExpress.XtraScheduler.Outlook.Interop;

namespace DevExpress.XtraScheduler.Demos {
    /// <summary>
    /// Summary description for DemoUtils.
    /// </summary>
    public class DemoUtils {
        public const string aptDataResourceName = "DevExpress.XtraScheduler.Demos.Data.appointments.xml";
        public const string resDataResourceName = "DevExpress.XtraScheduler.Demos.Data.resources.xml";
        public const string sportEventsResourceName = "DevExpress.XtraScheduler.Demos.Data.sportevents.xml";

        public static Random RandomInstance = new Random();

        //public static string[] Users = new string[] {"Peter Dolan", "Ryan Fischer", "Richard Fisher", 
        //                                         "Tom Hamlett", "Mark Hamilton", "Steve Lee", "Jimmy Lewis", "Jeffrey W McClain", 
        //                                         "Andrew Miller", "Dave Murrel", "Bert Parkins", "Mike Roller", "Ray Shipman", 
        //                                         "Paul Bailey", "Brad Barnes", "Carl Lucas", "Jerry Campbell"};
        public static string[] Users = new string[] { "Peter Dolan", "Ryan Fischer", "Andrew Miller", "Tom Hamlett",
                                                        "Jerry Campbell", "Carl Lucas", "Mark Hamilton", "Steve Lee" };

        static string[] taskDescriptions = new string[] {
												   "Implementing Developer Express MasterView control into Accounting System.",
												   "Web Edition: Data Entry Page. The issue with date validation.",
												   "Payables Due Calculator. It is ready for testing.",
												   "Web Edition: Search Page. It is ready for testing.",
												   "Main Menu: Duplicate Items. Somebody has to review all menu items in the system.",
												   "Receivables Calculator. Where can I found the complete specs",
												   "Ledger: Inconsistency. Please fix it.",
												   "Receivables Printing. It is ready for testing.",
												   "Screen Redraw. Somebody has to look at it.",
												   "Email System. What library we are going to use?",
												   "Adding New Vendors Fails. This module doesn't work completely!",
												   "History. Will we track the sales history in our system?",
												   "Main Menu: Add a File menu. File menu is missed!!!",
												   "Currency Mask. The current currency mask in completely inconvinience.",
												   "Drag & Drop. In the schedule module drag & drop is not available.",
												   "Data Import. What competitors databases will we support?",
												   "Reports. The list of incomplete reports.",
												   "Data Archiving. This features is still missed in our application",
												   "Email Attachments. How to add the multiple attachment? I did not find a way to do it.",
												   "Check Register. We are using different paths for different modules.",
												   "Data Export. Our customers asked for export into Excel"}; 


        public static DateTime Date = new DateTime(2005, 7, 13);

		static string[] outlookCalendarPaths = null;

		public static string[] OutlookCalendarPaths { 
			get {
				if (outlookCalendarPaths != null)
					return outlookCalendarPaths;

				try {
					outlookCalendarPaths = OutlookExchangeHelper.GetOutlookCalendarPaths();
				} catch {
					ReportOutlookError("get the list of available calendars from Microsoft Outlook");
					outlookCalendarPaths = new string[0];
				}
				return outlookCalendarPaths;
             }
		}

        public static void FillData(SchedulerControl control) {
            control.Storage.EnableReminders = false;
            FillStorageData(control.Storage);
            control.Start = Date;
            //control.OptionsBehavior.ShowRemindersForm = false;
        }
        public static void FillResources(SchedulerStorage storage, int count) {
            ResourceCollection resources = storage.Resources.Items;
            storage.BeginUpdate();
			try {
				int cnt = Math.Min(count, Users.Length);
				for (int i = 1; i <= cnt; i++)
					resources.Add(new Resource(i, Users[i - 1]));
			}
			finally {
				storage.EndUpdate();
			}
        }
        public static void FillStorageData(SchedulerStorage storage) {
            //FillStorageCollection(storage.Resources.Items, resDataResourceName);
            //FillStorageCollection(storage.Appointments.Items, aptDataResourceName);
        }
        static Stream GetResourceStream(string resourceName) {
            return System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
        }
        static void FillStorageCollection(NotificationCollection c, string resourceName)
        {
            //using (Stream stream = GetResourceStream(resourceName))
            //{
            //    c.ReadXml(stream);
            //    stream.Close();
            //}
        }
        public static void SetConnectionString(System.Data.OleDb.OleDbConnection oleDbConnection, string path) {
            oleDbConnection.ConnectionString = String.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;User ID=Admin;Data Source={0};Mode=Share Deny None;Extended Properties="""";Jet OLEDB:System database="""";Jet OLEDB:Registry Path="""";Jet OLEDB:Database Password="""";Jet OLEDB:Engine Type=5;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Global Bulk Transactions=1;Jet OLEDB:New Database Password="""";Jet OLEDB:Create System Database=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False", path);
        }
        public static string GetRelativePath(string name) {
            name = "Data\\" + name;
            string path = System.Windows.Forms.Application.StartupPath;
            string s = "\\";
            for(int i = 0 ; i <= 10 ; i++) {
                if(System.IO.File.Exists(path + s + name)) 
                    return (path + s + name);
                else 
                    s += "..\\";
            } 
            return "";
        }
        public static CheckState TimeVisibilityToCheckState(AppointmentTimeVisibility visibility) {
            if (visibility == AppointmentTimeVisibility.Always)
                return CheckState.Checked;
            if (visibility == AppointmentTimeVisibility.Never)
                return CheckState.Unchecked;
            return CheckState.Indeterminate;
        }
        public static AppointmentTimeVisibility CheckStateToTimeVisibility(CheckState state) {
            if (state == CheckState.Checked)
                return AppointmentTimeVisibility.Always;
            if (state == CheckState.Unchecked)
                return AppointmentTimeVisibility.Never;
            return AppointmentTimeVisibility.Auto;
        }

        public static DataTable GenerateScheduleTasks() {
            DataTable tbl = new DataTable();
            tbl = new DataTable("ScheduleTasks");
            tbl.Columns.Add("ID", typeof(int));
            tbl.Columns.Add("Subject", typeof(string));
			tbl.Columns.Add("Severity", typeof(int));
            tbl.Columns.Add("Priority", typeof(int));
            tbl.Columns.Add("Duration", typeof(int));
            tbl.Columns.Add("Description", typeof(string));
            for (int i = 0; i < 21; i++) {
				string description = taskDescriptions[i];
				int index = description.IndexOf('.');
				string subject;
				if (index <= 0)
					subject = "task" + Convert.ToInt32(i + 1);
				else
					subject = description.Substring(0, index);
                tbl.Rows.Add(new object[] { i + 1, subject, RandomInstance.Next(3), RandomInstance.Next(3), Math.Max(1, RandomInstance.Next(8)), description });
            }
            return tbl;
        }
        public static DataTable GetSportEventsData() {
            DataSet sportEventDS = new DataSet();
            using (Stream stream = GetResourceStream(sportEventsResourceName)) {
                sportEventDS.ReadXml(stream);
                stream.Close();
            }
            return sportEventDS.Tables[0];
        }
        public static string FormatAppointmentString(Appointment apt) {
            if (apt == null)
                return "Null";
            return String.Format("[{0}] {1}", apt.Type, apt.Subject);
        }
        public static string FormatOutlookAppointmentString(_AppointmentItem olApt) {
            if (olApt == null)
                return "Null";

            string isRecurring = olApt.IsRecurring ? "Recurring" : "NonRecurring";
            return String.Format("[{0}] {1}", isRecurring, olApt.Subject);
        }
        public static void ReportOutlookError(string message) {
            DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("Impossible to {0}. Probably, Microsoft Outlook isn't installed on this machine.", message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
