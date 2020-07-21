using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserRepository
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=IgraonicaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<User> GetAllUsers()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Users";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<User> listToReturn = new List<User>();

                while (sqlDataReader.Read())
                {
                    User u = new User();

                    u.username = sqlDataReader.GetString(0);
                    u.name = sqlDataReader.GetString(1);
                    u.surname = sqlDataReader.GetString(2);
                    u.address = sqlDataReader.GetString(3);
                    u.phone_number = sqlDataReader.GetInt32(4);
                    u.gender= sqlDataReader.GetString(5);

                    listToReturn.Add(u);
                }
                return listToReturn;
            }
        }

        public int InsertUser(User u)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO Users VALUES(" + string.Format(
                   "'{0}','{1}','{2}','{3}','{4}','{5}'", u.username, u.name, u.surname, u.address, u.phone_number, u.gender) + ")";


                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int UpdateUser(User u)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "UPDATE Users SET name = '" + u.name + "', surname = '" + u.surname + "', address = '" + u.address + "', phone_number = " + u.phone_number + ", gender = '" + u.gender + "' WHERE username = " + u.username;

                return sqlCommand.ExecuteNonQuery();
            }
        }


            public void DeleteUser(User u)
        {
            using (SqlConnection dataConnection = new SqlConnection(connectionString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "DELETE FROM Users WHERE Username = @username";
                command.Parameters.AddWithValue("@username", u.username);
                command.ExecuteNonQuery();
            }
        }
    }
}
