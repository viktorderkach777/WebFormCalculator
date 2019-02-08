using System;
using System.Web;
using System.Web.UI;
using WebAppCalc.Models;

namespace WebAppCalc
{
    public partial class SingIn : System.Web.UI.Page
    {
        private readonly IDAL _dal = new EDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorButton.Visible = false;

            HttpCookie cookie1 = Request.Cookies["name"];

            if (cookie1 == null)
            {
                ErrorButton.Text = "You should register!";
                ErrorButton.Visible = true;
            }
        }
        

        protected void singIn_Click(object sender, EventArgs e)
        {
            bool IsLogin = _dal.IsUserNameInDb(usernameOrEmail.Text);
            ErrorButton.Visible = true;

            if (String.IsNullOrEmpty(usernameOrEmail.Text) || String.IsNullOrEmpty(pwd.Text))
            {
                if (!ErrorButton.CssClass.Contains("btn-danger"))
                {
                    ErrorButton.CssClass = ErrorButton.CssClass.Replace("btn-success", "btn-danger").TrimEnd();
                }

                ErrorButton.Text = "Fill all fields please!";               
                return;
            }

            if (!IsLogin)
            {
                if (!ErrorButton.CssClass.Contains("btn-danger"))
                {
                    ErrorButton.CssClass = ErrorButton.CssClass.Replace("btn-success", "btn-danger").TrimEnd();
                }

                ErrorButton.Text = "User with this username or email doesn't exists!";              
            }
            else
            {
                Hash.Value = CryptoProvider.GetMD5Hash(pwd.Text + "s@lt");
                bool IsPass = _dal.IsUserNameInDb(usernameOrEmail.Text, Hash.Value); 

                if (IsPass)
                {
                    if (!ErrorButton.CssClass.Contains("btn-success"))
                    {
                       
                        ErrorButton.CssClass = ErrorButton.CssClass.Replace("btn-danger", "btn-success").TrimEnd();
                    }

                    ErrorButton.Text = "You have singed in successfully!";                   
                    goForwardButton.Visible = true;
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
            Response.Redirect("Registration.aspx");            
        }


        protected void GoForward_Click(object sender, EventArgs e)
        {
            AsyncTask slowTask1 = new AsyncTask();            
            PageAsyncTask task1 = new PageAsyncTask(slowTask1.OnBegin, slowTask1.OnEnd, slowTask1.OnTimeOut, null, true);
            RegisterAsyncTask(task1);            
            Page.ExecuteRegisteredAsyncTasks();
           
            HttpCookie cookieName = Request.Cookies["name"];
            HttpCookie cookieSign = new HttpCookie("sign", Hash.Value);
            cookieName.Value = usernameOrEmail.Text;           
            Response.Cookies.Add(cookieName);
            Response.Cookies.Add(cookieSign);

            Response.Redirect("Calculator.aspx");
        }        
    }
}