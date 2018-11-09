using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using NationDrugs.BaseOption;
using System.Data;
using System.Data.SqlClient;


namespace NationDrugs.Log
{
    public partial class top : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userinfor"] != null)
            {
                cUserInfor uinfor = (cUserInfor)(Session["userinfor"]);
                this.lblUserId.Text = uinfor.Truename;
            }
            else
            {
               Response.Redirect("logout.ashx");
            }
            
        }
    }
}