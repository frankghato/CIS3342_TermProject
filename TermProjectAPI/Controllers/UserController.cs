using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TermProjectLibrary;
using Utilities;

namespace TermProjectAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GetPasswordFromUsername/{username}")] // Get a password from username
        public string GetPasswordFromUsername(string username)
        {
            DBConnect objDB = new DBConnect(); // SQL Objects needed for calls
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure; // Set type to procedure
            objCommand.CommandText = "TP_GetPasswordFromUsername";
            objCommand.Parameters.AddWithValue("@theUsername", username);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            string password = "";
            if (myDS.Tables[0].Rows.Count != 0)
            {
                DataRow record = myDS.Tables[0].Rows[0];
                password = record["Password"].ToString();
            }
            return password;
        }

        [HttpGet("GetUsername/{email}")] // Get a username from an Email
        public string GetUsernameFromEmail(string email)
        {
            DBConnect objDB = new DBConnect(); // SQL Objects needed for calls
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure; // Set type to procedure
            objCommand.CommandText = "TP_GetUsernameFromEmail";
            objCommand.Parameters.AddWithValue("@theEmail", email);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            string user = "";
            if (myDS.Tables[0].Rows.Count != 0)
            {
                DataRow record = myDS.Tables[0].Rows[0];
                user = record["Username"].ToString();
            }
            return user;
        }

        [HttpGet("GetIsEmailConfirmed/{username}")] // Get isemailconfirmed field of username
        public string GetIsEmailConfirmed(string username)
        {
            DBConnect objDB = new DBConnect(); // SQL Objects needed for calls
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure; // Set type to procedure
            objCommand.CommandText = "TP_GetIsEmailConfirmed";
            objCommand.Parameters.AddWithValue("@theUsername", username);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            string isEmailConfirmed = "";
            if (myDS.Tables[0].Rows.Count != 0)
            {
                DataRow record = myDS.Tables[0].Rows[0];
                isEmailConfirmed = record["IsEmailConfirmed"].ToString();
            }
            return isEmailConfirmed;
        }

        [HttpPut("ConfirmEmail")] // confirm email of username
        public Boolean ConfirmEmail(string username)
        {
            DBConnect objDB = new DBConnect(); // SQL Objects needed for calls
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure; // Set type to procedure
            objCommand.CommandText = "TP_ConfirmEmail";
            objCommand.Parameters.AddWithValue("@theUsername", username);

            int updated = objDB.DoUpdateUsingCmdObj(objCommand);
            if (updated > 0)
            {
                return true;
            }
            return false;
        }

        [HttpPost("AddUser")] // Post a new post
        public Boolean AddUser([FromBody] UserAccount u)
        {
            DBConnect objDB = new DBConnect(); // SQL Objects needed for calls
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure; // Set type to procedure
            objCommand.CommandText = "TP_AddUser";
            objCommand.Parameters.AddWithValue("@theUsername", u.Username);
            objCommand.Parameters.AddWithValue("@theFirstName", u.FirstName);
            objCommand.Parameters.AddWithValue("@theLastName", u.LastName);
            objCommand.Parameters.AddWithValue("@theEmail", u.Email);
            objCommand.Parameters.AddWithValue("@theProfileImageKey", u.ProfileImageKey);
            objCommand.Parameters.AddWithValue("@thePassword", u.Password);
            objCommand.Parameters.AddWithValue("@theHomeAddress", u.HomeAddress);
            objCommand.Parameters.AddWithValue("@theBillingAddress", u.BillingAddress);
            objCommand.Parameters.AddWithValue("@thePhoneNumber", u.PhoneNumber);
            objCommand.Parameters.AddWithValue("@theIsEmailConfirmed", u.IsEmailConfirmed);
            objCommand.Parameters.AddWithValue("@theSecurityQuestion1Answer", u.SecurityQuestion1Answer);
            objCommand.Parameters.AddWithValue("@theSecurityQuestion2Answer", u.SecurityQuestion2Answer);
            objCommand.Parameters.AddWithValue("@theSecurityQuestion3Answer", u.SecurityQuestion3Answer);

            int updated = objDB.DoUpdateUsingCmdObj(objCommand);
            if (updated > 0)
            {
                return true;
            }
            return false;
        }

        [HttpGet("GetFollowing/{username}")]
        public List<string> GetFollowing(string username) // Get Following
        {
            DBConnect objDB = new DBConnect(); // SQL Objects needed for calls
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure; // Set type to procedure
            objCommand.CommandText = "TP_GetFollowing";
            objCommand.Parameters.AddWithValue("@theUsername", username);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            List<string> usernames = new List<string>();
            string followedUser;

            foreach (DataRow record in myDS.Tables[0].Rows)
            {
                followedUser = record["Username"].ToString();
                usernames.Add(followedUser);
            }
            return usernames;
        }
    }
}
