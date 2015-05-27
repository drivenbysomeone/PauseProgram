using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PauseProgram
{
    
    class BL
    {
        DAL dal = new DAL();



        internal List<Departments> GetDepartments()
        {

            DataTable dt = dal.GetDeparmentsFromDB();
          
             var l = new List<Departments>();
             foreach (DataRow item in dt.Rows)
             {
                 var theDepartment = new Departments();
                 theDepartment.LocationId = Convert.ToInt32(item["LocationId"].ToString());
                 theDepartment.Location = item["Location"].ToString();
                 l.Add(theDepartment);
 
             }
             return l;
  

        }

        internal List<SchoolStatus> GetSchoolStatus()
        {
            DataTable dt = dal.GetSchoolStatusFromDB();

            var l = new List<SchoolStatus>();
            foreach (DataRow item in dt.Rows)
            {

                var schoolStatus = new SchoolStatus();
                schoolStatus.TypeId = Convert.ToInt32(item["TypeId"].ToString());
                schoolStatus.Text = item["Text"].ToString();
                l.Add(schoolStatus);

            }
            return l;

        }

        internal List<SchoolSystem> GetSchoolSystem(int id)
        {
            DataTable dt = dal.GetInfoInDataGridView(id);

            var l1 = new List<SchoolSystem>();
            foreach (DataRow item in dt.Rows)
            {
                var theSystem = new SchoolSystem();
               
                theSystem.SchoolTime = Convert.ToDateTime(item["AlarmTime"].ToString());
                theSystem.SchoolStatus = item["Text"].ToString();
                l1.Add(theSystem);
            }

            return l1;
        }

     


    }
}
