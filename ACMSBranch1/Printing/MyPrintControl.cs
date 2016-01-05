using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraPrinting;

namespace ACMS.ACMSBranch {
	public class MyPrintControl : DevExpress.XtraPrinting.Control.PrintControl {
		public event EventHandler ChangeClickBrick;

		public MyPrintControl() {
			this.BrickClick += new DevExpress.XtraPrinting.Control.BrickEventHandler(MyBrickClick);
		}
		
		protected override void Dispose(bool disposing) {
			this.BrickClick -= new DevExpress.XtraPrinting.Control.BrickEventHandler(MyBrickClick);
			base.Dispose(disposing);
		}

		private void MyBrickClick(object sender, DevExpress.XtraPrinting.Control.BrickEventArgs e) {
			if(e.Brick == null) return; 
			if(e.Brick.ID != "") {
				ChangeClickBrick(e.Brick, e);
			}
		}
	}
}
