using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace ACMS.Utils
{
    public class Pdfprint
    {
        public Pdfprint()
		{
		}

		public void PrintPdfDocument(string path)
		{
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo()
            {
                CreateNoWindow = true,
                UseShellExecute = true,
                Verb = "print",
                FileName = path

            };
            p.Start();

            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            if (p.HasExited == false)
            {
                p.WaitForExit(10000);
            }
            p.EnableRaisingEvents = true;

            p.Close();
            KillAdobe("AcroRd32");
		}

        public void KillAdobe(string name)
        {
            try
            {
                foreach (Process proc in Process.GetProcessesByName(name))
                {
                    proc.Kill();
                }
            }
            catch
            {
            }
        }
    }
}
