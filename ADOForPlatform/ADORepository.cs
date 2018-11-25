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

        }
        public ADORepository(SqlConnection con)
        {
            connection = con;
            connection.Open();
        }

        virtual public List<string[]> getFromDatabse(string str, int inRow)
        {
            List<string[]> result = new List<string[]>();
            SqlCommand command = new SqlCommand(str, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string[] s = new string[inRow];
                for (int i = 0; i < inRow; ++i)
                {
                    s[i] = reader[i].ToString();
                }
                result.Add(s);
            }
            reader.Close();
            return result;
        }
        public bool connectionOpen(SqlConnection con)
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                return true;
            }
            else return false;
        }
    }
}
