using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NationDrugs.DrugWei.Admin.AdWeb
{
    public partial class APassport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string flag = string.Empty;
                if (Request.QueryString["flag"] != null)
                {
                    //如果不为空说明是新添加的药材，这个时候要移除flag属性
                    //还要移除加入存在的drugid
                     flag = Request.QueryString["flag"].ToString();
                     if (Session["flag"] != null)
                         Session.Remove("flag");
                     if (Session["drugid"] != null)
                         Session.Remove("drugid");
                }
               else  if (Session["flag"] != null)
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
}