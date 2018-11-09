using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NationDrugs.BaseOption;
using System.Data;
using System.Data.SqlClient;

namespace NationDrugs.DrugWei.Admin.AdWeb
{
    public partial class AChemistry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["drugid"] = "10011";
            //Session["rsid"] = "10000";

            string flag = "0";
            if (Session["flag"] != null)
            {
                flag = Session["flag"].ToString();
            }
            if (flag == "1")
                Session["UpdateOrInsertFlag"] = "Update";
            else
                Session["UpdateOrInsertFlag"] = "Insert";
        }             

    }
}