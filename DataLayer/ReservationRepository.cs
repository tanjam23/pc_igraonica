using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ReservationRepository
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PCigraonicaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Reservation> GetAllReservations()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Reservations";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<Reservation> listToReturn = new List<Reservation>();

                while (sqlDataReader.Read())
                {
                    Reservation r = new Reservation();

                    r.code = sqlDataReader.GetInt32(0);
                    r.date = sqlDataReader.GetString(1);
                    r.time = sqlDataReader.GetString(2);
                    r.username = sqlDataReader.GetString(3);
                    listToReturn.Add(r);
                }

                return listToReturn;
            }
        }
        public int InsertReservation(Reservation r)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO Reservations VALUES(" + string.Format(
                    "'{0}','{1}','{2}','{3}'", r.code, r.date, r.time, r.username) + ")";

                return sqlCommand.ExecuteNonQuery();

            }
        }

        public int UpdateReservation(Reservation r)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "UPDATE Reservations SET date = '" + r.date + "', time = '" + r.time + "', username = '" + r.username + "' WHERE code = " + r.code;

                return sqlCommand.ExecuteNonQuery();

            }
        }

        public void DeleteReservation(Reservation r)
        {
            using (SqlConnection dataConnection = new SqlConnection(connectionString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "DELETE FROM Reservations WHERE code = @code";
                command.Parameters.AddWithValue("@code", r.code);
                command.ExecuteNonQuery();
            }
        }
    }
}
