namespace ADOForPlatform
{
    using System;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Collections.Generic;

    public class ADORepository
    {

        public SqlConnection connection { get; set; }
        //public SqlCommand command { get; set; }

        public ADORepository()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
        }
        public ADORepository(SqlConnection con)
        {
            connection = con;
        }

        public  List<string[]> getFromDatabse(string str, int inRow)
        {
            List<string[]> result = new List<string[]>();
            SqlCommand command = new SqlCommand (str, connection);
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                string[] s = new string[inRow];
                for(int i=0;i<inRow;++i)
                {
                    s[i] = reader[i].ToString();
                }
                result.Add(s);
            }
            return result;
        }

         
    }
}
