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

namespace NationDrugs.DrugHan.Client
{
    public partial class findDrug : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["userinfor"] == null)
            {
                Response.Redirect("../../Log/logout.ashx");
                return;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (Session["userinfor"] != null)
            {
                DataBindGV();
            }
            else
            {
                Response.Redirect("../../Log/logout.ashx");
                return;
            }


        }
        void DataBindGV()
        {
            cUserInfor uinfor = (cUserInfor)(Session["userinfor"]);
            string names = Server.UrlEncode(txtNationName.TextValue);
            string groupid = uinfor.Groupid.ToString();
            cQuery cq = new cQuery();
            DataTable dt = cq.GetDTbyNameS(names, groupid);
            gv.DataKeyNames = new string[] { "drugid" };
            gv.DataSource = dt;
            gv.DataBind();
        }

        protected int charTodi(string str)
        {
            char[] ch = str.ToCharArray(0, 1);
            return ch[0] - '1';
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "detail")
            {
                string drugid = e.CommandArgument.ToString().Trim();
                Session["drugid"] = drugid;
                Session["flag"] = "1";
                Response.Redirect("../Admin/AdWeb/APassport.aspx");

            }
        }
        protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataBindGV();
            gv.PageIndex = e.NewPageIndex;
            gv.DataBind();
        }
        protected void gv_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor = '#e7eaf1';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c;");
            }
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

       

       
       

    }
}