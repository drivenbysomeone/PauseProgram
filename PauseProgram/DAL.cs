using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace PauseProgram
{
    class DAL
    {

        string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=\\nrh1\users$\aspit1020\dokumenter\AspItDB.mdf;Integrated Security=True;Connect Timeout=30";
     
        public DataTable GetData(string sql)
        {
            DataTable dt = new DataTable();
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;

        }

        internal DataTable GetDeparmentsFromDB()
        {
            string queryString = "SELECT * FROM LocationsDatadesign";
            return GetData(queryString);
        }

        internal DataTable GetSchoolStatusFromDB()
        {
            string queryString = "SELECT * FROM AlarmTypesDesignDB";
            return GetData(queryString);
        }

    
        internal DataTable GetInfoInDataGridView(int id)
        {
            string queryString = "SELECT [Alarms dataDesign].AlarmTime,AlarmTypesDesignDB.Text From [Alarms dataDesign] INNER JOIN AlarmTypesDesignDB ON [Alarms dataDesign].TypeId=AlarmTypesDesignDB.TypeId INNER JOIN LocationsDatadesign ON [Alarms dataDesign].LocationId=LocationsDatadesign.LocationId WHERE LocationsDatadesign.LocationId = " + id + " ORDER BY AlarmTime ASC";
            return GetData(queryString);

        }
 

    }
}
