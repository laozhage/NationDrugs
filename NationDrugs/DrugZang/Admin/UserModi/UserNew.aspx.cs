using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



using NationDrugs.BaseOption;
using System.Data;
using System.Data.SqlClient;

namespace NationDrugs.DrugZang.Admin.UserModi
{
    public partial class UserNew : System.Web.UI.Page
    {
        protected void Page_Disposed(object sender, EventArgs e)
        {
            //销毁这个页面时候要把Session["insertCount"]
            if (Session["UserTitleName"] != null)
                Session.Remove("UserTitleName");         

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //-------------------------------------------------
                string flag = string.Empty;
                if (Request.QueryString["flag"] != null)
                {
                    flag = Request.QueryString["flag"].ToString();
                }
                else
                    flag = "1";

                if (flag == "1")
                    Session["UserTitleName"] = "添加新用户";
                else
                    Session["UserTitleName"] = "修改用户密码";
                ////--------------------------------------------------
                if (Session["userinfor"] != null)
                {
                    cUserInfor uinfor = (cUserInfor)(Session["userinfor"]);
                    string UserID = uinfor.Userid.ToString().Trim();
                }
                else
                {
                    Response.Redirect("../../../Log/logout.ashx");
                }
                ////----------------------------------------------------------
            }
        }
    }
}