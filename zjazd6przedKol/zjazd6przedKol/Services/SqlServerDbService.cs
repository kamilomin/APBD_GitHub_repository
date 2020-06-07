using cw6.DTOs;
using cw6.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw6.Services
{
    public class SqlServerDbService : IDoctorsDbService
    {
        private const string ConString = "Data Source=db-mssql;Initial Catalog=s17911;Integrated Security=True";

        public NewDoctorDto AddDoctor(NewDoctorDto newDoctor)
        {
            using (SqlConnection connection = new SqlConnection(ConString))
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                connection.Open();
                var transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                SqlDataReader dataReader = null;

                try
                {
                    command.CommandText = "insert into Doctors(FirstName, LastName, Email) " +
                            "values(@FirstName, @LastName, @Email) ";
                    command.Parameters.AddWithValue("FirstName", newDoctor.FirstName);
                    command.Parameters.AddWithValue("LastName", newDoctor.LastName);
                    command.Parameters.AddWithValue("Email", newDoctor.Email);
                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    if (dataReader != null)
                    {
                        dataReader.Close();
                        transaction.Rollback();
                    }
                    throw e;
                }

                return newDoctor;
            }
        }

        public string DeleteDoctors(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConString))
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                connection.Open();
                var transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                SqlDataReader dataReader = null;

                try
                {
                    command.CommandText = "delete from Doctors " +
                        "where IdDoctor = @IdDoctor";
                    command.Parameters.AddWithValue("IdDoctor", id);
                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    if (dataReader != null)
                    {
                        dataReader.Close();
                        transaction.Rollback();
                    }
                    throw e;
                }
            }

            return "Deleted selected doctor";
        }

        public DoctorDto GetDoctor(int id)
        {
            var doctor = new DoctorDto();

            using (SqlConnection connection = new SqlConnection(ConString))
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "select IdDoctor, FirstName, LastName, Email " +
                    "from Doctors " +
                    "where IdDoctor = @id";
                command.Parameters.AddWithValue("id", id);
                connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();
                if (!dataReader.Read())
                {
                    return null;
                }

                doctor.IdDoctor = int.Parse(dataReader["IdDoctor"].ToString());
                doctor.FirstName = dataReader["FirstName"].ToString();
                doctor.LastName = dataReader["LastName"].ToString();
                doctor.Email = dataReader["Email"].ToString();

                dataReader.Close();
            }

            return doctor;
        }

        public IEnumerable<DoctorDto> GetDoctors()
        {
            var list = new List<DoctorDto>();
            using (SqlConnection connection = new SqlConnection(ConString))
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "select IdDoctor, FirstName, LastName, Email " +
                    "from Doctors";
                connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    var doctor = new DoctorDto
                    {
                        IdDoctor = int.Parse(dataReader["IdDoctor"].ToString()),
                        FirstName = dataReader["FirstName"].ToString(),
                        LastName = dataReader["LastName"].ToString(),
                        Email = dataReader["Email"].ToString()
                    };
                    list.Add(doctor);
                }

                dataReader.Close();
            }

            return list;
        }

        public NewDoctorDto UpdateDoctor(int id, NewDoctorDto updatedDoctor)
        {
            using (SqlConnection connection = new SqlConnection(ConString))
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                connection.Open();
                var transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                SqlDataReader dataReader = null;

                try
                {
                    command.CommandText = "update Doctors " +
                        "set FirstName = @FirstName, LastName = @LastName, Email = @Email " +
                        "where IdDoctor =  @IdDoctor";
                    command.Parameters.AddWithValue("FirstName", updatedDoctor.FirstName);
                    command.Parameters.AddWithValue("LastName", updatedDoctor.LastName);
                    command.Parameters.AddWithValue("Email", updatedDoctor.Email);
                    command.Parameters.AddWithValue("IdDoctor", id);
                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    if (dataReader != null)
                    {
                        dataReader.Close();
                        transaction.Rollback();
                    }
                    throw e;
                }

                return updatedDoctor;
            }
        }
    }
}
