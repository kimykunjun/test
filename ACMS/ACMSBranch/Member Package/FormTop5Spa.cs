using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using ACMSDAL;



namespace ACMS.ACMSBranch.Member_Package
{
    public partial class FormTop5Spa : DevExpress.XtraEditors.XtraForm
    {
        //Created by Arthur 24Dec2015
        TblServiceSession myServiceSession = new TblServiceSession();
        private string strMemID;

        public FormTop5Spa(string strmemberid)
        {
            InitializeComponent();
            strMemID = strmemberid;
            loadTop5SPAList();
        }
        public void loadTop5SPAList() 
        {

            DataTable dt = new DataTable();
            dt = myServiceSession.selectTop5SpaList(strMemID);
            if (dt.Rows.Count > 0) 
            {
                grdTop5SPA.DataSource = dt;
            }
   
              

        }

        private void FormTop5Spa_Load(object sender, EventArgs e)
        {
            
            //string cs = ConfigurationSettings.AppSettings["RoadShowTerminal"].ToString();

            

            //ArrayList al = new ArrayList();

            //using (SqlDataReader oReader = cmd.ExecuteReader())
            //{

            //    while (oReader.Read())
            //    {
            //        //string packageID = oReader["nPackageID"].ToString();
            //        //string strServiceCode = oReader["strServiceCode"].ToString();
            //        //string dtDate = oReader["dtDate"].ToString();


            //        //lblPackageIDResult.Text = packageID;
            //        //lblServiceCodeResult.Text = strServiceCode;
            //        //lblDateResult.Text = dtDate;

            //        object[] values = new object[oReader.FieldCount];

            //        oReader.GetValues(values);
            //        al.Add(values);
                    
                    

            //        //Label NewLabel = new Label();
            //        ////NewLabel.ID = "Label" + packageID;
            //        //NewLabel.Text = "Label" + packageID;
            //        //this.FormTop5Spa.Controls.Add(NewLabel);
            //    }

            //    oReader.Close();
            //    con.Close();

            //    foreach(object[] row in al){
            //        foreach(object column in row){
            //            lblPackageIDResult.Text = row[6].ToString();
            //            lblServiceCodeResult.Text = row[7].ToString();
            //            lblDateResult.Text = row[2].ToString();

            //            //Label label = new Label();
            //            ////label.Name = "lbl" + row[6].ToString();
            //            //label.Text = row[6].ToString();
            //        }

            //    }


           // }
        }

    }
}