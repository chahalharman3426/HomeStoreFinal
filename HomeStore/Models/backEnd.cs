using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HomeStore.Models
{
    public class backEnd
    {

        SqlConnection sqlConn;
        String connection_String = "Data Source=DESKTOP-G2UGPMF\\SQLEXPRESS;Initial Catalog=BuyHome;Integrated Security=True";
        SqlCommand sqlCmd;
        SqlDataReader sqlDatareader;

        //this statement is related to insert delete update query that is the main statement of any database record 
        public int sendfeedBack(String statement)
        {

            sqlConn = new SqlConnection(connection_String);
            sqlConn.Open();


            sqlCmd = new SqlCommand(statement, sqlConn);
            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();
            return 1;
        }

        // this code is used to in the details of a prticuar query from the table using the sql statement with the help of where clause 
        public int checkAdmin(String statement)
        {
            DataTable tbl = new DataTable();


            sqlConn = new SqlConnection(connection_String);

            sqlConn.Open();
            sqlCmd = new SqlCommand(statement, sqlConn);

            sqlDatareader = sqlCmd.ExecuteReader();

            tbl.Load(sqlDatareader);

            sqlConn.Close();
            if (tbl.Rows.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }


    }
}