using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WebAppCalc.Models;

namespace WebAppCalc
{
    public partial class RatesTable : System.Web.UI.Page
    {
        private readonly IDAL _dal = new EDAL();
        public List<ExchangeRates> Emps { get; set; }    

        protected void Page_Load(object sender, EventArgs e)
        {
            Emps = _dal.GetAllRates().ToList();
            MyGrid.DataBind();
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            MyGrid.Enabled = true;
        }
    }
}