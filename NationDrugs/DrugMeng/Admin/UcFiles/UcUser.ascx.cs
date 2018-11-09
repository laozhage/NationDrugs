using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NationDrugs.BaseOption;
using System.Data;
using System.Data.SqlClient;

namespace NationDrugs.DrugMeng.Admin.UcFiles
{
    public partial class UcUser : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userinfor"] != null)
            {
                cUserInfor uinfor = (cUserInfor)(Session["userinfor"]);
                Ulable1.TextValue = uinfor.Userid.ToString().Trim();
                Ulable2.TextValue = uinfor.Truename;
                Ulable3.TextValue = uinfor.Groupid.ToString();
            }
            else
            {
                Response.Redirect("logout.ashx");
            }
               
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Session["userinfor"] != null)
            {
                cUserInfor uinfor = (cUserInfor)(Session["userinfor"]);
                if (string.Equals(uinfor.Pwd, Entry.EncryptByMd5(txt_oldpass.Text.ToString() ) ))
                {
                    args.IsValid = true;                    
                }
                else
                {
                    args.IsValid = false;                   
                }
            }
            else
            {
                Response.Redirect("logout.ashx");
            }
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (txt_newpass1.Text.ToString().Length < 6)
            {
                args.IsValid = false;               
            }
            else
            {
                args.IsValid = true;                
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            string UpdateCommand = "UPDATE [smUser] SET  [pwd] = @pwd    WHERE [userid] = @userid";
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@pwd", SqlDbType.NVarChar, 40);      par[0].Value = Entry.EncryptByMd5(txt_newpass1.Text.ToString().Trim());
            par[1] = new SqlParameter("@userid", SqlDbType.Int); par[1].Value = Ulable1.TextValue;
            cUser cus = new cUser();
            int val = -10;
            try
            {
                if (this.Page.IsValid == false)
                    return;
               val =   cus.ModiUser(UpdateCommand, par);
               if (val > 0)
                   Script.AjaxAlert(btn_save, "恭喜您，密码修改成功，请牢记您的密码！");
            }
            catch
            {
                Script.AjaxAlert(btn_save, "对不起，密码修改失败，请联系系统管理员！");    
            }

        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../../Log/main.aspx");
        }

    }
}