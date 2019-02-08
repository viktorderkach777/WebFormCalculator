using System;
using System.Web;

namespace WebAppCalc
{
    public partial class Registration : System.Web.UI.Page
    {
        private readonly IDAL _dal = new EDAL();        

        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorButton.Visible = false;
        }

        protected void Registration_Click(object sender, EventArgs e)
        {
            bool IsLogin = _dal.IsUserNameInDb(username.Text);
            ErrorButton.Visible = true;

            if (String.IsNullOrEmpty(fullname.Text) || String.IsNullOrEmpty(username.Text) || String.IsNullOrEmpty(email.Text) || String.IsNullOrEmpty(pwd.Text))
            {
                if (!ErrorButton.CssClass.Contains("btn-danger"))
                {
                    ErrorButton.CssClass = ErrorButton.CssClass.Replace("btn-success", "btn-danger").TrimEnd();
                }

                ErrorButton.Text = "Fill all fields please!";               
                return;
            }


            if (IsLogin)
            {
                if (!ErrorButton.CssClass.Contains("btn-danger"))
                {
                    ErrorButton.CssClass = ErrorButton.CssClass.Replace("btn-success", "btn-danger").TrimEnd();
                }
                
                ErrorButton.Text = "User with this username exists!";               
            }
            else
            {
                bool IsSave = _dal.DBUserSaveCredentials(fullname.Text, username.Text, email.Text, CryptoProvider.GetMD5Hash(pwd.Text + "s@lt"));

                if (IsSave)
                {
                    if (!ErrorButton.CssClass.Contains("btn-success"))
                    {
                        ErrorButton.CssClass = ErrorButton.CssClass.Replace("btn-danger", "btn-success").TrimEnd();
                    }

                    ErrorButton.Text = "You have registered successfully!";                   
                    HttpCookie cookieName = new HttpCookie("name", username.Text);
                    Response.Cookies.Add(cookieName);
                }
                else
                {
                    if (!ErrorButton.CssClass.Contains("btn-danger"))
                    {
                        ErrorButton.CssClass = ErrorButton.CssClass.Replace("btn-success", "btn-danger").TrimEnd();
                    }

                    ErrorButton.Text = "Try writing the data again please!";                  
                }
            }
        }


        protected void sing_regist_Click(object sender, EventArgs e)
        {
            HttpCookie cookie1 = Request.Cookies["name"];

            if (cookie1!=null)
            {
                Response.Redirect("SingIn.aspx");
            }
            else
            {
                ErrorButton.Visible = true;

                if (!ErrorButton.CssClass.Contains("btn-danger"))
                {
                    ErrorButton.CssClass = ErrorButton.CssClass.Replace("btn-success", "btn-danger").TrimEnd();
                }

                ErrorButton.Text = "You should register!";
            }
        }        
    }
}