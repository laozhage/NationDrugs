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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_errorMessage.Visible = false;
          //  Response.Write(Entry.EncryptByMd5("123456"));
        }

        protected void btn_login_Click(object sender, ImageClickEventArgs e)
        {
            if (txt_checkCode.Text.ToString().Trim() != string.Empty)
            {
                if (String.Compare(Session["CheckCode"].ToString(), txt_checkCode.Text, true) != 0)
                {
                    lbl_errorMessage.Text = "验证码错误!";
                    lbl_errorMessage.Visible = true;
                    return;
                }
            }
            else
            {
                return;
            }
            string userID = TextBox1.Text.ToString().Trim();
            string userPass = TextBox2.Text.ToString().Trim();

            cUser cuser = new cUser();
            int groupid = -1;
            
            bool yorn = cuser.JudgUser(userID, userPass, out groupid);
            if (yorn)
            {               
                cUserInfor uinfor = new cUserInfor(userID, userPass);
                Session["userinfor"] = uinfor;
                Response.Redirect("index.aspx");
            }
            else
            {
                // Response.Redirect("login.aspx");
                lbl_errorMessage.Text = "用户名或密码错误!";
                lbl_errorMessage.Visible = true;
            }
        }



       

    }
}