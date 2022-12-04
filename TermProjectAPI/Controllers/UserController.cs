﻿using Microsoft.AspNetCore.Http;
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
    }
}
