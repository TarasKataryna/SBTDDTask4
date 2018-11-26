namespace ADOForPlatform
{
    using System.Collections.Generic;
    using System.Data.SqlClient;

    /// <summary>
    /// Class for connection with data base
    /// </summary>
    public class ADORepository
{
        /// <summary>
        /// Initializes a new instance of the <see cref="ADORepository" /> class.
        /// </summary>
        ////public SqlCommand command { get; set; }
        public ADORepository()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ADORepository" /> class.
        /// </summary>
        /// <param name="con">SQL connection</param>
        public ADORepository(SqlConnection con)
        {
            this.Connection = con;
            this.Connection.Open();
        }

        /// <summary>
        /// Gets or sets connection
        /// </summary>
        public SqlConnection Connection { get; set; }

        /// <summary>
        /// gets data from data base
        /// </summary>
        /// <param name="str"> Queries to </param>
        /// <param name="inRow"> number of rows </param>
        /// <returns> data from data base </returns>
        public virtual List<string[]> GetFromDatabse(string str, int inRow)
        {
            List<string[]> result = new List<string[]>();
            SqlCommand command = new SqlCommand(str, this.Connection);
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

        /// <summary>
        /// opens connection
        /// </summary>
        /// <param name="con"> SQL connection </param>
        /// <returns> true or false </returns>
        public bool ConnectionOpen(SqlConnection con)
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
