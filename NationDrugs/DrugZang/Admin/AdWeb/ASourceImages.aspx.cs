﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NationDrugs.DrugZang.Admin.AdWeb
{
    public partial class ASourceImages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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