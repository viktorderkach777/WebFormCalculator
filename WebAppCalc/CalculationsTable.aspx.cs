using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WebAppCalc.Models;


namespace WebAppCalc
{
    public partial class Table : System.Web.UI.Page
    {
        private readonly IDAL _dal = new EDAL();
        public List<Expression> Emps { get; set; } 
        
        protected void Page_Load(object sender, EventArgs e)
        {           
            Emps = _dal.GetAllExpressions().ToList();
            MyGrid.DataBind();
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            MyGrid.Enabled = true;
        }
    }
}