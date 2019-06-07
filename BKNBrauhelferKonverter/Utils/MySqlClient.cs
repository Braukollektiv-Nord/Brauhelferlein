using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BKNBrauhelferKonverter.Utils
{
    public class MySqlClient
    {


        public bool Connect()
        {
            var server = "www.braukollektiv-nord.de";
            var database = "d02b898f";
            var uid = "d02b898f";
            var password = "fLznNgaEkzc7fWnk";
            var connectionString = "SERVER=" + server + "; " + "DATABASE=" +
                               database + "; " + "UID=" + uid + "; " + "PASSWORD=" + password + ";";

            var connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();


                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                var msg = string.Empty;
                switch (ex.Number)
                {
                    case 0:
                        msg = "Cannot connect to server.  Contact administrator";
                        break;

                    case 1045:
                        msg = "Invalid username/password, please try again";
                        break;
                }
                return false;
            }

            return true;
        }

        public void Upload()
        {

        }

        public void Download()
        {

        }
    }
}
