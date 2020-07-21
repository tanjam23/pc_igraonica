using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ComputerRepository
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PCigraonicaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<Computer> GetAllComputers()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Computers";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<Computer> listToReturn = new List<Computer>();

                while (sqlDataReader.Read())
                {
                    Computer c = new Computer();

                    c.number = sqlDataReader.GetInt32(0);
                    c.description = sqlDataReader.GetString(1);
                    c.room = sqlDataReader.GetString(2);

                    listToReturn.Add(c);
                }
                return listToReturn;
            }
        }

        public int InsertComputer(Computer c)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO Computers VALUES(" + string.Format(
                    "'{0}','{1}', '{2}'", c.number, c.description, c.room) + ")";

                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int UpdateComputer(Computer c)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "UPDATE Computers SET description = '" + c.description + "', room = '" + c.room +
                    "' WHERE number = " + c.number;

                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int DeleteComputer(int number)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "DELETE FROM Computers WHERE number = " + number;

                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
