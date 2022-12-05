using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TermProjectLibrary
{
    [Serializable()]
    public class UserAccount : ISerializable
    {
        private string username;
        private string firstName;
        private string lastName;
        private string email;
        private string password;
        private string homeAddress;
        private string billingAddress;
        private string phoneNumber;
        private string profileImageKey;
        private string isEmailConfirmed;
        private string securityQuestion1Answer;
        private string securityQuestion2Answer;
        private string securityQuestion3Answer;

        public UserAccount()
        {

        }

        public UserAccount(string username, string email, string password)
        {
            this.username = username;
            this.email = email;
            this.password = password;
        }

        public UserAccount(string username, string firstName, string lastName, string email, string password, string homeAddress, string billingAddress, string phoneNumber, string profileImageKey, string isEmailConfirmed, string securityQuestion1Answer, string securityQuestion2Answer, string securityQuestion3Answer)
        {
            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.homeAddress = homeAddress;
            this.billingAddress = billingAddress;
            this.phoneNumber = phoneNumber;
            this.profileImageKey = profileImageKey;
            this.isEmailConfirmed = isEmailConfirmed;
            this.securityQuestion1Answer = securityQuestion1Answer;
            this.securityQuestion2Answer = securityQuestion2Answer;
            this.securityQuestion3Answer = securityQuestion3Answer;
        }

        public string Username { get => username; set => username = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string HomeAddress { get => homeAddress; set => homeAddress = value; }
        public string BillingAddress { get => billingAddress; set => billingAddress = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string ProfileImageKey { get => profileImageKey; set => profileImageKey = value; }
        public string IsEmailConfirmed { get => isEmailConfirmed; set => isEmailConfirmed = value; }
        public string SecurityQuestion1Answer { get => securityQuestion1Answer; set => securityQuestion1Answer = value; }
        public string SecurityQuestion2Answer { get => securityQuestion2Answer; set => securityQuestion2Answer = value; }
        public string SecurityQuestion3Answer { get => securityQuestion3Answer; set => securityQuestion3Answer = value; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Username", username);
            info.AddValue("Email", email);
            info.AddValue("Password", password);
        }

        public UserAccount(SerializationInfo info, StreamingContext context)
        {
            username = (string)info.GetValue("Username", typeof(string));
            email = (string)info.GetValue("Email", typeof(string));
            password = (string)info.GetValue("Password", typeof(string));
        }

        public string Serialize()
        {
            return "{email: " + this.email + "; username: " + this.username + "; password: " + this.password + "}";
        }
    }
}
