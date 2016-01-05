using System;
using System.Collections.Generic;
using System.Text;
using ACMSDAL;
using System.Data;

namespace ACMSLogic
{
     public class Roster
    {
         private TblRoster myRoster;

         public Roster()
		{
			Init();
		}
         public DataTable GetRosterDetail(int WeekNo, string target,string _value,string RosterBranch,int nYear)
         {

             return myRoster.SelectRosterDetail(WeekNo,target,_value,RosterBranch,nYear);
         }

         private void Init()
         {
             myRoster = new TblRoster();
             //myDataTable = myCategory.SelectAll(); 
         }
    }
}
