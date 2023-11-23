using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using MvcAnalisisArchivos.Models.DTO;

namespace MvcAnalisisArchivos.Models.DAO
{
    public class UserDAO
    {
        public string CreateUser(UserDTO user)
        {
            string response = "Failed";

            try
            {
                using (MySqlConnection connection = SecurityConfig.GetConnection())
                {
                    connection.Open();

                    string createUserQuery = "INSERT INTO ada_users (name, email, code, attempts_allowed, balance, account_number) " +
                                            "VALUES (@pName, @pEmail, @pCode, @pAttemptsAllowed, @pBalance, @pAccountNumber)";

                    using (MySqlCommand command = new MySqlCommand(createUserQuery, connection))
                    {
                        command.Parameters.AddWithValue("@pName", user.Name);
                        command.Parameters.AddWithValue("@pEmail", user.Email);
                        command.Parameters.AddWithValue("@pCode", user.ObfuscateCode());
                        command.Parameters.AddWithValue("@pAttemptsAllowed", user.AttemptsAllowed);
                        command.Parameters.AddWithValue("@pBalance", user.Balance);
                        command.Parameters.AddWithValue("@pAccountNumber", user.GenerateAccountNumber());

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            response = "Success";
                    }

                    connection.Close();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error in CreateUser: " + error.Message);
            }

            return response;
        }

        public List<UserDTO> ReadUsers()
        {
            List<UserDTO> users = new List<UserDTO>();

            try
            {
                using (MySqlConnection connection = SecurityConfig.GetConnection())
                {
                    connection.Open();
                    string readUserQuery = "SELECT * FROM ada_users";
                    using (MySqlCommand command = new MySqlCommand(readUserQuery, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserDTO user = new UserDTO();
                                MapUserFromReader(reader, user);
                                users.Add(user);
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error in ReadUsers: " + error.Message);
            }

            return users;
        }

        public UserDTO ReadUser(int id)
        {
            UserDTO user = new UserDTO();

            try
            {
                using (MySqlConnection connection = SecurityConfig.GetConnection())
                {
                    connection.Open();
                    string readUserQuery = "SELECT * FROM ada_users WHERE id = @pId";
                    using (MySqlCommand command = new MySqlCommand(readUserQuery, connection))
                    {
                        command.Parameters.AddWithValue("@pId", id);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MapUserFromReader(reader, user);
                                
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error in ReadUser: " + error.Message);
            }
            // Just to verify if function work well
             user.VerifyCode("5678", user.Code);

            return user;
        }

        public string UpdateUser(int id, UserDTO updatedUser)
        {
            string response = "Failed";

            try
            {
                using (MySqlConnection connection = SecurityConfig.GetConnection())
                {
                    connection.Open();

                    string updateUserQuery = "UPDATE ada_users SET name = @pName, email = @pEmail, " +
                                             "code = @pCode, attempts_allowed = @pAttemptsAllowed, " +
                                             "balance = @pBalance, account_number = @pAccountNumber " +
                                             "WHERE id = @pId";

                    using (MySqlCommand command = new MySqlCommand(updateUserQuery, connection))
                    {
                        command.Parameters.AddWithValue("@pName", updatedUser.Name);
                        command.Parameters.AddWithValue("@pEmail", updatedUser.Email);
                        command.Parameters.AddWithValue("@pCode", updatedUser.ObfuscateCode());
                        command.Parameters.AddWithValue("@pAttemptsAllowed", updatedUser.AttemptsAllowed);
                        command.Parameters.AddWithValue("@pBalance", updatedUser.Balance);
                        command.Parameters.AddWithValue("@pAccountNumber", updatedUser.AccountNumber);
                        command.Parameters.AddWithValue("@pId", id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            response = "Success";
                    }

                    connection.Close();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error in UpdateUser: " + error.Message);
            }

            return response;
        }

        public string DeleteUser(int id)
        {
            string response = "Failed";

            try
            {
                using (MySqlConnection connection = SecurityConfig.GetConnection())
                {
                    connection.Open();

                    string deleteUserQuery = "DELETE FROM ada_users WHERE id = @pId";

                    using (MySqlCommand command = new MySqlCommand(deleteUserQuery, connection))
                    {
                        command.Parameters.AddWithValue("@pId", id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            response = "Success";
                    }

                    connection.Close();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error in DeleteUser: " + error.Message);
            }

            return response;
        }

        private void MapUserFromReader(MySqlDataReader reader, UserDTO user)
        {
            user.Id = reader.GetInt32("id");
            user.Name = reader.GetString("name");
            user.Email = reader.GetString("email");
            user.Code = reader.GetString("code");
            user.AttemptsAllowed = reader.GetInt32("attempts_allowed");
            user.Balance = reader.GetInt32("balance");
            user.AccountNumber = reader.GetInt32("account_number");
        }
    }
}