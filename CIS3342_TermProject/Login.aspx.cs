﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using TermProjectLibrary;

namespace CIS3342_TermProject
{
    public partial class Login : System.Web.UI.Page
    {
        SecurityQuestionService pxy = new SecurityQuestionService();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrors.Text = "";
        }

        protected void btnForgotPassword_Click(object sender, EventArgs e)
        {
            retrieveInfoDiv.Style.Add("visibility", "visible");
        }

        protected void btnForgotUsername_Click(object sender, EventArgs e)
        {
            retrieveInfoDiv.Style.Add("visibility", "visible");
        }

        protected void btnSubmitEmail_Click(object sender, EventArgs e)
        {
            if (tboxEmail.Text.Equals(""))
            {
                lblErrors.Text = "*You must enter an email.";
                return;
            }

            Session["email"] = tboxEmail.Text;
            //generate random num 1-3 and get security question
            //get security question answer from email
            //compare answers
            //check if equal, if so send email with requested information, if false error message
            Random rand = new Random();
            int questionID = rand.Next(1, 4);
            securityQuestion.InnerText = pxy.GetSecurityQuestionByID(questionID);
            string correctAnswer = pxy.GetSecurityQuestionAnswerByEmailAndQuestionID(tboxEmail.Text, questionID);

            if (correctAnswer.Equals("-1"))
            {
                lblErrors.Text = "*There was no record found matching your email addres.";
                return;
            }
            retrieveInfoDiv.Style.Add("visibility", "hidden");
            securityQuestionDiv.Style.Add("visibility", "visible");
            Session["answer"] = correctAnswer;

            //lblErrors.Text = Session["email"].ToString();
        }

        protected void btnSubmitAnswer_Click(object sender, EventArgs e)
        {
            if(tboxSecurityQuestionAnswer.Text.Equals(Session["answer"].ToString()))
            {
                lblErrors.Text = "An email has been sent to you containing your login information.";
            }
            else
            {
                lblErrors.Text = "Wrong answer bozo.";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblErrors.Text = "";
            if(tboxUsername.Equals(""))
            {
                lblErrors.Text += "*You must enter your username.";
            }
            if(tboxPassword.Equals(""))
            {
                lblErrors.Text += "*You must enter your password.";
            }

            if(lblErrors.Text.Equals(""))
            {
                WebRequest request = WebRequest.Create("https://localhost:44382/api/user/GetPasswordFromUsername/" + tboxUsername.Text);
                WebResponse response = request.GetResponse();
                Stream ds = response.GetResponseStream();
                StreamReader reader = new StreamReader(ds);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();
                JavaScriptSerializer js = new JavaScriptSerializer();

                string pw = js.Deserialize<string>(data);

                string encryptedPw = Encryption.EncryptPassword(tboxPassword.Text);

                if(pw.Equals(""))
                {
                    lblErrors.Text = "*Your username is incorrect.";
                    return;
                }

                if(!pw.Equals(encryptedPw))
                {
                    lblErrors.Text = "*Your password is incorrect.";
                    return;
                }
                else
                {
                    //log in 
                    lblErrors.Text = "Passwords match, proceed to login.";
                    Response.Redirect("Posts.aspx?Username=" + tboxUsername.Text);
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterAccount.aspx");
        }
    }
}