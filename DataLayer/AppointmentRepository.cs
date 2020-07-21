using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AppointmentRepository
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PCigraonicaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<Appointment> GetAllAppointments()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Appointments";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<Appointment> listToReturn = new List<Appointment>();

                while (sqlDataReader.Read())
                {
                    Appointment a = new Appointment();

                    a.id = sqlDataReader.GetInt32(0);
                    a.date = sqlDataReader.GetString(1);
                    a.time = sqlDataReader.GetString(2);
                    a.bill = sqlDataReader.GetInt32(3);
                    a.res_code = sqlDataReader.GetInt32(4);

                    listToReturn.Add(a);
                }
                return listToReturn;
            }
        }

        public int InsertAppointments(Appointment a)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO Appointments VALUES(" + string.Format(
                    "'{0}','{1}', '{2},'{3}','{4}','{5}'", a.id, a.date, a.time, a.bill, a.res_code) + ")";

                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int UpdateAppointment(Appointment a)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "UPDATE Appointments SET id = '" + a.id + "', date = '" + a.date + "', time = '" + a.time + "', bill = " + a.bill + ", reservation code = '" + a.res_code;

                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int DeleteAppointment(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "DELETE FROM Appointments WHERE id = " + id;

                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
