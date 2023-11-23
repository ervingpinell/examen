using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace MvcAnalisisArchivos.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The 'Name' field is required.")]
        [MaxLength(50, ErrorMessage = "The 'Name' field cannot exceed 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The 'Email' field is required.")]
        [MaxLength(50, ErrorMessage = "The 'Email' field cannot exceed 50 characters.")]
        [EmailAddress(ErrorMessage = "The 'Email' field is not in a valid format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The 'Code' field is required.")]
        [MaxLength(6, ErrorMessage = "The 'Code' field cannot exceed 6 characters.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "The 'Attempts Allowed' field is required.")]
        [Range(1, 10, ErrorMessage = "The 'Attempts Allowed' field must be between 1 and 10")]
        public int AttemptsAllowed { get; set; }

        [Required(ErrorMessage = "The 'Balance' field is required.")]
        [Range(0, 999999, ErrorMessage = "The 'Balance' field must be between 0 and 999999.")]
        public int Balance { get; set; }

        public int AccountNumber { get; set; }

        // Method to obfuscate the code
        public string ObfuscateCode()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Change the code to byte and get the hash
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Code));

                // Get the first 3 bytes (24 bits) from the hash and convert to hexadecimal
                string hexHash = BitConverter.ToString(hashBytes, 0, 3).Replace("-", "").ToLower();

                return hexHash;
            }
        }

        public bool VerifyCode(string userProvidedCode, string storedHashedCode)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Calculate the hash of the user-supplied code
                byte[] userProvidedCodeBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(userProvidedCode));
                string hashedUserCode =  BitConverter.ToString(userProvidedCodeBytes, 0, 3).Replace("-", "").ToLower();

                // Compare the calculated hash with the hash stored in the database
                return hashedUserCode == storedHashedCode;
            }
        }

        // Method to generate the account number
        public int GenerateAccountNumber()
        {
            // Simple example: Generating a random 5-digit number
            Random random = new Random();
            return random.Next(10000, 99999);
        }
    }
}
