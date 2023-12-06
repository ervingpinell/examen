using MvcAnalisisArchivos.Models;
using MvcAnalisisArchivos.Models.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAnalisisArchivos.Models.DAO
{
    public class AtmParameterDAO
    {

        public string CreateAtm(AtmParameterDTO atm)
        {
            string response = "Failed";

            try
            {
                using (MySqlConnection connection = SecurityConfig.GetConnection())
                {
                    connection.Open();

                    string createUserQuery = "INSERT INTO ada_atm (ten_bill, twenty_bill, balance, out_service_message) " +
                                            "VALUES (@pTenBill, @pTwentyBill, @pBalance, @pOutServiceMessage)";

                    using (MySqlCommand command = new MySqlCommand(createUserQuery, connection))
                    {
                        command.Parameters.AddWithValue("@pTenBill", atm.TenBill);
                        command.Parameters.AddWithValue("@pTwentyBill", atm.TwentyBill);
                        command.Parameters.AddWithValue("@pBalance", atm.Balance);
                        command.Parameters.AddWithValue("@pOutServiceMessage", atm.OutServiceMessage);


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


        public List<AtmParameterDTO> ReadAtms()
        {
            List<AtmParameterDTO> atms = new List<AtmParameterDTO>();

            try
            {
                using (MySqlConnection connection = SecurityConfig.GetConnection())
                {
                    connection.Open();
                    string readAtmQuery = "SELECT * FROM ada_atm";
                    using (MySqlCommand command = new MySqlCommand(readAtmQuery, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AtmParameterDTO atm = new AtmParameterDTO();
                            MapAtmFromReader(reader, atm);
                            atms.Add(atm);
                        }
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error in ReadAtms: " + error.Message);
            }

            return atms;
        }
        public AtmParameterDTO ReadAtm(int id)
        {
            AtmParameterDTO atm = new AtmParameterDTO();

            try
            {
                using (MySqlConnection connection = SecurityConfig.GetConnection())
                {
                    connection.Open();
                    string readUserQuery = "SELECT * FROM ada_atm WHERE id = @pId";
                    using (MySqlCommand command = new MySqlCommand(readUserQuery, connection))
                    {
                        command.Parameters.AddWithValue("@pId", id);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MapAtmFromReader(reader, atm);

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

            return atm;
        }
        public string UpdateAtm(int id, UserDTO updatedAtm)
        {
            string response = "Failed";

            try
            {
                using (MySqlConnection connection = SecurityConfig.GetConnection())
                {
                    connection.Open();

                    string updateUserQuery = "UPDATE ada_atm SET name = @pTenBill, @pTwentyBill, @pBalance, @pOutServiceMessage WHERE id = @pId";

                    using (MySqlCommand command = new MySqlCommand(updateUserQuery, connection))
                    {
                        command.Parameters.AddWithValue("@pTenBill", updatedAtm.Name);
                        command.Parameters.AddWithValue("@pTwentyBill", updatedAtm.Email);
                        command.Parameters.AddWithValue("@pBalance", updatedAtm.Balance);
                        command.Parameters.AddWithValue("@pOutServiceMessage", updatedAtm.AttemptsAllowed);
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
        public string DeleteAtm(int id)
        {
            string response = "Failed";

            try
            {
                using (MySqlConnection connection = SecurityConfig.GetConnection())
                {
                    connection.Open();

                    string deleteUserQuery = "DELETE FROM ada_atm WHERE id = @pId";

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

        private void MapAtmFromReader(MySqlDataReader reader, AtmParameterDTO atm)
        {
            atm.Id = reader.GetInt32("id");
            atm.TenBill = reader.GetInt32("ten_bill");
            atm.TwentyBill = reader.GetInt32("twenty_bill");
            atm.Balance = reader.GetInt32("balance");
            atm.OutServiceMessage = reader.GetString("out_service_message");
        }
    }
}