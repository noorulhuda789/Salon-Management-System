using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalonManagmentSystem
{
    public class utils
    {
        public static bool CheckComboBoxInput(ComboBox cb)
        {
            return cb.SelectedIndex != -1;
        }
        public static void ShowMessage(string message, string title = "Message")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK);
        }
        public static void ShowNameError()
        {
            ShowMessage("Name can only contain only upper or lower case alphabets! \nName must contain more than 2 alphabets!", "Name not valid");
        }
        public static void ShowEmailError()
        {
            ShowMessage("Gmail address is considered only", "Email not valid");
        }
        public static void ShowPasswordError()
        {
            ShowMessage($"Passowrd length must be between 8 and 20 characters.\n" +
                        $"Password should contain at least one uppercase and one lower case letter.\n " +
                        $"Password should contain at least one digit.\n" +
                        $"Password should contain at least one special character.", "Password not valid");
        } 
        public static void ShowPhoneNumberError() 
        {
            ShowMessage("Phone numebr should be 11 digits", "Invalid Phone Number");
        }
        public static void ShowAddressError()
        {
            ShowMessage($"Address can be alphanumeric and may contain #.-\n" +
                        "Address should be more than 5 characters", "Invalid Address Input");
        }

        public static void ShowIntegerError(string att)
        {
            ShowMessage(att+$" should be a non-negative integer.", "Invalid "+ att+" Input");
        }

        public static void ShowDecimalError(string att)
        {
            ShowMessage(att + $" should be non-negative decimal.", "Invalid " + att + " Input");
        }

        public static void ShowUsernameError()
        { 
            ShowMessage($"Username can be alphanumeric and may contain _.#@\n" +
                        "Username should be more than 3 and less than 20 characters", "Invalid Username Input");
        }
    }
}
