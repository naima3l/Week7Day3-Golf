using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Day3.Entities;
using Week7Day3.Interfaces;

namespace Week7Day3.AdoRepositories
{
    class UserADORepository : IUserDbManager
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                    "Initial Catalog = Golf;" +
                                    "Integrated Security = true;";
        public void Delete(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = "delete from Subscriber where Id = @id";
                command.Parameters.AddWithValue("@id", user.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<User> Fetch()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "select * from Subscriber";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var name = (string)reader["Name"];
                    var surname = (string)reader["Surname"];
                    var birth = (DateTime)reader["BirthDate"];
                    var sex = (EnumSex)reader["Sex"];
                    var registred = (bool)reader["Registred"];
                    var id = (int)reader["Id"];

                    User user = new User(name,surname,birth,sex,registred,id);

                    users.Add(user);
                }
            }
            return users;
        }

        public User GetById(int? id)
        {
            User user = new User();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "select * from Subscriber where Id = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var name = (string)reader["Name"];
                    var surname = (string)reader["Surname"];
                    var birth = (DateTime)reader["BirthDate"];
                    var sex = (EnumSex)reader["Sex"];
                    var registred = (bool)reader["Registred"];

                    user = new User(name, surname, birth, sex, registred, id);
                }
            }
            return user;
        }

        public void Insert(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Subscriber values (@name,@surname,@birth,@sex,@registred)";
                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@surname", user.Surname);
                command.Parameters.AddWithValue("@birth", user.BirthDate);
                command.Parameters.AddWithValue("@sex", (int)user.Sex);
                command.Parameters.AddWithValue("@registred", user.Registred);

                command.ExecuteNonQuery();
            }
        }

        public void Update(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update Subscriber set Name = @name, Surname = @surname, BirthDate = @birth, Sex = @sex, Registred = @registred where Id = @id";
                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@surname", user.Surname);
                command.Parameters.AddWithValue("@birth", user.BirthDate);
                command.Parameters.AddWithValue("@sex", (int)user.Sex);
                command.Parameters.AddWithValue("@registred", user.Registred);
                command.Parameters.AddWithValue("@id", user.Id);

                command.ExecuteNonQuery();
            }
        }
    }
}
