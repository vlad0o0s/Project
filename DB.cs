using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kurse
{
    internal class DB
    {
        MySqlConnection connection = new MySqlConnection("server=185.179.190.242;port=3310;username=u147874_program1;password=program1;database=u147874_program1;SSL Mode=None;"); 

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
