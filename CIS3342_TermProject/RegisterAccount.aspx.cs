using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TermProjectLibrary;

namespace CIS3342_TermProject
{
    public partial class RegisterAccount : System.Web.UI.Page
    {
        ArrayList profileImageKeys = new ArrayList();
        EmailSender emailSender = new EmailSender();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrors.Text = "";
            lblErrors.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ed5151");

            for (int i = 1; i < 10; i++)
            {
                profileImageKeys.Add(i);
            }
            ddlProfileImage.DataSource = profileImageKeys;
            ddlProfileImage.DataBind();
            profileImage.Src = "assets/profileimages/" + ddlProfileImage.SelectedValue + ".bmp";

        }

        protected void ddlProfileImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            profileImage.Src = "assets/profileimages/" + ddlProfileImage.SelectedValue + ".bmp";
        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string email = tboxEmailAddress.Text;
            string username = tboxUsername.Text;
            string firstName = tboxFirstName.Text;
            string lastName = tboxLastName.Text;
            string password = tboxPassword.Text;
            string passwordConfirm = tboxConfirmPassword.Text;

            string phoneNumber = tboxPhoneNumber.Text;
            string homeAddress = tboxHomeAddress.Text;
            string billingAddress = tboxBillingAddress.Text;

            string question1 = tboxQuestion1.Text;
            string question2 = tboxQuestion2.Text;
            string question3 = tboxQuestion3.Text;

            lblErrors.Text = "";
            lblErrors.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ed5151");
            if (email.Equals(""))
            {
                lblErrors.Text += "*Email cannot be empty.<br>";
            }
            else if(!email.Contains("@") || !email.Contains("."))
            {
                lblErrors.Text += "*Email must be a valid email address.<br>";
            }
            if (username.Equals(""))
            {
                lblErrors.Text += "*Username cannot be empty.<br>";
            }
            if (firstName.Equals(""))
            {
                lblErrors.Text += "*First Name cannot be empty.<br>";
            }
            if (lastName.Equals(""))
            {
                lblErrors.Text += "*Last Name cannot be empty.<br>";
            }
            if (password.Equals(""))
            {
                lblErrors.Text += "*Password cannot be empty.<br>";
            }
            if (!passwordConfirm.Equals(password))
            {
                lblErrors.Text += "*Passwords must match.<br>";
            }
            if (phoneNumber.Equals(""))
            {
                lblErrors.Text += "*Phone Number cannot be empty.<br>";
            }
            if(homeAddress.Equals(""))
            {
                lblErrors.Text += "*Home Address cannot be empty.<br>";
            }
            if (billingAddress.Equals(""))
            {
                lblErrors.Text += "*Billing Address cannot be empty.<br>";
            }
            if (question1.Equals(""))
            {
                lblErrors.Text += "*Question 1 cannot be empty.<br>";
            }
            if (question2.Equals(""))
            {
                lblErrors.Text += "*Question 2 cannot be empty.<br>";
            }
            if (question3.Equals(""))
            {
                lblErrors.Text += "*Question 3 cannot be empty.<br>";
            }

            if(!lblErrors.Text.Equals(""))
            {
                return;
            }
            else
            {
                
                bool sent = emailSender.SendConfirmationEmail(email, "1");
                if(sent)
                {
                    lblErrors.Text = "Account successfully created!<br>Please check your email for the confirmation link.";
                    lblErrors.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6fd656");
                }
                else
                {
                    lblErrors.Text = "Email could not be sent.";
                }
            }    
        }
    }
}