using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;

namespace SalonManagmentSystem
{
    public class validations
    {
        public static bool IsAlphaWithSpaces(string text)
        {

            // Check if it contains at least one non-space character
            if (text.Trim().Length < 1 || text.Length < 3)
                return false;
            // Trim the text to remove leading and trailing spaces
            // Check if the trimmed text contains only alphabets and spaces
            return Regex.IsMatch(text.Trim(), @"^[a-zA-Z ]+$");
        }
        public static bool IsValidGmailAddress(string email)
        {
            // Regular expression for validating Gmail addresses
            string gmailPattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
            return Regex.IsMatch(email, gmailPattern);
        }
        public static bool IsValidAddress(string address)
        {
            // Check if address contains at least one non-space character
            if (address.Trim().Length < 1 || address.Length < 5)
                return false;

            // Check if address contains at least one alphanumeric character, #, ., or -
            if (!Regex.IsMatch(address, @"[A-Za-z0-9#.-]"))
                return false;

            return true;
        }
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            // Remove any non-digit characters
            string cleanedNumber = Regex.Replace(phoneNumber, @"\D", "");

            // Check if the cleaned number contains 10 digits (for a standard US phone number)
            return cleanedNumber.Length == 11;
        }
        public static bool IsValidUsername(string username)
        {
            // Check if username is not null or empty
            if (string.IsNullOrEmpty(username))
                return false;

            // Check if username length is between 3 and 20 characters
            if (username.Length < 3 || username.Length > 20)
                return false;

            // Check if username contains only alphanumeric characters, underscore (_), period (.), hash (#), or at (@)
            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9_.#@]+$"))
                return false;

            // Check if username does not start or end with a space
            if (username.StartsWith(" ") || username.EndsWith(" "))
                return false;

            // Check if username does not contain consecutive spaces
            if (username.Contains("  "))
                return false;

            return true;
        }

      
        public static bool IsValidPassword(string password)
        {
            // Check if password is not null or empty
            if (string.IsNullOrEmpty(password))
                return false;

            // Check if password length is between 8 and 20 characters
            if (password.Length < 8 || password.Length > 20)
                return false;

            // Check if password contains at least one uppercase letter
            if (!Regex.IsMatch(password, "[A-Z]"))
                return false;

            // Check if password contains at least one lowercase letter
            if (!Regex.IsMatch(password, "[a-z]"))
                return false;

            // Check if password contains at least one digit
            if (!Regex.IsMatch(password, "[0-9]"))
                return false;

            // Check if password contains at least one special character
            if (!Regex.IsMatch(password, "[!@#$%^&*()]"))
                return false;

            return true;
        }
      
        public static bool IsValidInteger(string input, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            // Attempt to parse the input string into an integer
            if (int.TryParse(input, out int value))
            {
                // Check if the parsed value is within the specified range
                if (value < minValue || value > maxValue)
                    return false;

                return true;
            }

            // Parsing failed, so the input is not a valid integer
            return false;
        }
        public static bool IsValidDecimal(string input, decimal minValue = decimal.MinValue, decimal maxValue = decimal.MaxValue)
        {
            // Attempt to parse the input string into a decimal
            if (decimal.TryParse(input, out decimal value))
            {
                // Check if the parsed value is within the specified range
                if (value < minValue || value > maxValue)
                    return false;

                return true;
            }

            // Parsing failed, so the input is not a valid decimal
            return false;
        }
        public static bool IsAlphaWithoutSpaces(string text)
        {
            // Check if it contains at least one non-space character
            if (text.Trim().Length < 1)
                return false;

            // Trim the text to remove leading and trailing spaces
            // Check if the trimmed text contains only alphabets (no spaces)
            return Regex.IsMatch(text.Trim(), @"^[a-zA-Z]+$");
        }

    }
}
