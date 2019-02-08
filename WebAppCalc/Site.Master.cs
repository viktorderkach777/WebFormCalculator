using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppCalc
{
    public partial class SiteMaster : MasterPage
    {
        private readonly IDAL _dal = new EDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void CheckCookies(string address)
        {
            HttpCookie cookie1 = Request.Cookies["name"];
            HttpCookie cookie2 = Request.Cookies["sign"];
            
            if (cookie1 != null && cookie2 != null)
            {
                if (_dal.IsUserNameInDb(cookie1.Value, cookie2.Value))
                {
                    Response.Redirect(address);
                }
                else if(_dal.IsUserNameInDb(cookie1.Value))
                {
                    Response.Redirect("SingIn.aspx");
                }
            }
            else if(cookie1 != null && cookie2 == null && _dal.IsUserNameInDb(cookie1.Value))
            {
                Response.Redirect("SingIn.aspx");               
            }
            else
            {
                Response.Redirect("Registration.aspx");
            }
        }
        
        protected void registrationClick(object sender, EventArgs e)
        {    
            Response.Redirect("Registration.aspx");
        }

        protected void singInClick(object sender, EventArgs e)
        {           
            Response.Redirect("SingIn.aspx");
        }
       

        protected void calculatorClick(object sender, EventArgs e)
        {
            CheckCookies("Calculator.aspx");
        }

        protected void tableClick(object sender, EventArgs e)
        {           
            CheckCookies("CalculationsTable.aspx");
        }

        protected void exchangeRatesClick(object sender, EventArgs e)
        {           
            CheckCookies("RatesTable.aspx");
        }

        protected void logOutClick(object sender, EventArgs e)
        {
            HttpCookie cookie2 = Request.Cookies["sign"];
            HttpCookie cookie1 = Request.Cookies["name"];

            if (cookie2 != null && cookie1 != null)
            {
                _dal.ClearExpressions();
                _dal.ClearExchangeRates();

                cookie2.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie2);
                Response.Redirect("SingIn.aspx");
            }
            else if(cookie2 == null && cookie1 != null)
            {
                Response.Redirect("SingIn.aspx");
            }
            else
            {
                Response.Redirect("Registration.aspx");
            }
        }

        protected void aboutClick(object sender, EventArgs e)
        {
            Response.Redirect("About.aspx");
        }

        protected void contactClick(object sender, EventArgs e)
        {
            Response.Redirect("Contact.aspx");
        }
    }
}