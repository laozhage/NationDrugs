﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NationDrugs.DrugMeng.Admin.AdWeb
{
    public partial class AReference : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // Session["drugid"] = "10033";
          //  Session["rsid"] = "10000";

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