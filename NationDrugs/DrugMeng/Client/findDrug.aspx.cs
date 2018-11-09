using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Data;
using System.Collections;
using System.Data.SqlClient;
using NationDrugs.BaseOption;

namespace NationDrugs.DrugMeng.Client
{
    public partial class findDrug : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
          //  Response.Write( System.Guid.NewGuid().ToString());
          //  Response.Write(charTodi("6:43"));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string drugid = CharText1.TextValue;
            Session["drugid"] = drugid;
            Session["flag"] = "1";
            Response.Redirect("../Admin/AdWeb/APassport.aspx");
        }

        protected int charTodi(string str)
        {
            char[] ch = str.ToCharArray(0, 1);
            return ch[0] - '1';
        }

       
       

    }
}