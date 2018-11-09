using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace NationDrugs.BaseOption
{
    public class Script
    {

        /// <summary>
        /// 弹出信息
        /// </summary>
        /// <param name="page">页面</param>
        /// <param name="msg">信息</param>
        public static void Alert(Page page, string msg)
        {
            page.Response.Write("<script lanaguage=\"javascript\">window.alert('" + msg + "')</script>");
        }
        /// <summary>
        /// 跳转
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="url">跳转的路径</param>
        public static void Navigate(Page page, string url)
        {
            page.Response.Write("<script lanaguage=\"javascript\">window.navigate('" + url + "')</script>");
        }
        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="nTimes"></param>
        public static void Back(Page page, int nTimes)
        {
            page.Response.Write("<script lanaguage=\"javascript\">window.history.go(" + nTimes.ToString() + ")</script>");
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="page">当前页</param>
        public static void Close(Page page)
        {
            page.Response.Write("<script lanaguage=\"javascript\">window.close();</script>");
        }


        public static void AjaxAlert(Control Controls, string msg)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(Controls, Controls.GetType(), "alert", "alert('" + msg + "');", true);
        }

        public static void AjaxClose(Control Controls)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(Controls, Controls.GetType(), "test", "window.close();", true);
        }

        public static void GotoLogin(Page page)
        {
            page.Response.Redirect("../Log/Login.aspx");
        }
    }
}