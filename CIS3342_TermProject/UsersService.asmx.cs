﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using TermProjectLibrary;
using Utilities;

namespace CIS3342_TermProject
{
    /// <summary>
    /// Summary description for UsersService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UsersService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<UserAccount> GetUsers()
        {
            DBConnect objDB = new DBConnect(); // SQL Objects needed for calls
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure; // Set type to procedure
            objCommand.CommandText = "TP_GetUsers";

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            List<UserAccount> users = new List<UserAccount>();
            UserAccount user;

            foreach (DataRow record in myDS.Tables[0].Rows)
            {
                user = new UserAccount();
                user.Username = record["Username"].ToString();
                user.FirstName = record["FirstName"].ToString();
                user.LastName = record["LastName"].ToString();
                user.Email = record["EmailAddress"].ToString();
                user.ProfileImageKey = record["ProfileImageKey"].ToString();
                user.Password = record["Password"].ToString();
                user.HomeAddress = record["HomeAddress"].ToString();
                user.BillingAddress = record["BillingAddress"].ToString();
                user.PhoneNumber = record["PhoneNumber"].ToString();
                user.IsEmailConfirmed = record["IsEmailConfirmed"].ToString();
                user.SecurityQuestion1Answer = record["SecurityQuestion1Answer"].ToString();
                user.SecurityQuestion2Answer = record["SecurityQuestion2Answer"].ToString();
                user.SecurityQuestion3Answer = record["SecurityQuestion3Answer"].ToString();
                users.Add(user);
            }
            return users;
        }

        [WebMethod]
        public bool IsEmailInUse(string email)
        {
            DBConnect objDB = new DBConnect(); // SQL Objects needed for calls
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure; // Set type to procedure
            objCommand.CommandText = "TP_GetUsernameFromEmail";
            objCommand.Parameters.AddWithValue("@theEmail", email);
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS.Tables[0].Rows.Count > 0;
        }

        [WebMethod] 
        public string GetEmailFromUsername(string username)
        {
            DBConnect objDB = new DBConnect(); // SQL Objects needed for calls
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure; // Set type to procedure
            objCommand.CommandText = "TP_GetEmailFromUsername";
            objCommand.Parameters.AddWithValue("@theUsername", username);
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            if(myDS.Tables[0].Rows.Count > 0)
            {
                return myDS.Tables[0].Rows[0]["EmailAddress"].ToString();
            }

            return "-1";
        }

        [WebMethod]
        public Boolean Unfollow(string username, string account)
        {
            DBConnect objDB = new DBConnect(); // SQL Objects needed for calls
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure; // Set type to procedure
            objCommand.CommandText = "TP_UnfollowUsername";
            objCommand.Parameters.AddWithValue("@theUsername", account);
            objCommand.Parameters.AddWithValue("@theUsernameToUnfollow", username);

            int updated = objDB.DoUpdateUsingCmdObj(objCommand);
            if (updated > 0)
            {
                return true;
            }
            return false;
        }
    }
}
