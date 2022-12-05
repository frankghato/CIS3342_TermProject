using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using Utilities;

namespace CIS3342_TermProject
{
    /// <summary>
    /// Summary description for SecurityQuestionService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SecurityQuestionService : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetSecurityQuestionByID(int id)
        {
            string securityQuestion = "";

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure; // Set type to procedure
            objCommand.CommandText = "TP_GetSecurityQuestionByID";
            objCommand.Parameters.AddWithValue("@theID", id);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            securityQuestion = myDS.Tables[0].Rows[0]["Question"].ToString();

            return securityQuestion;
        }

        [WebMethod]
        public List<string> GetSecurityQuestionAnswersByEmail(string email)
        {
            List<string> answers = new List<string>();

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure; // Set type to procedure
            objCommand.CommandText = "TP_GetSecurityQuestionAnswersByEmail";
            objCommand.Parameters.AddWithValue("@theEmail", email);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            if(myDS.Tables[0].Rows.Count <= 0)
            {
                return answers;
            }

            answers.Add(myDS.Tables[0].Rows[0]["SecurityQuestion1Answer"].ToString());
            answers.Add(myDS.Tables[0].Rows[0]["SecurityQuestion2Answer"].ToString());
            answers.Add(myDS.Tables[0].Rows[0]["SecurityQuestion3Answer"].ToString());

            return answers;
        }

        [WebMethod]
        public string GetSecurityQuestionAnswerByEmailAndQuestionID(string email, int id)
        {
            List<string> answers = new List<string>();
            answers = GetSecurityQuestionAnswersByEmail(email);
            if(answers.Count <= 0)
            {
                return "-1";
            }
            return answers[id - 1];
        }
    }
}
