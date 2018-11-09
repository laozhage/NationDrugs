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
    public partial class leftMenu : System.Web.UI.Page
    {
        static DataTable dtFirst;
        static DataView dvSecond;
        public int MenuCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {              
                if (Session["userinfor"] != null)
                {
                    cUserInfor uinfor = (cUserInfor)(Session["userinfor"]);
                    string UserID = uinfor.Userid.ToString().Trim();
                    string UserGrupID = uinfor.Groupid.ToString().Trim();
                    GetDataTable(UserID);
                    InitFirstMenu();
                }
                else
                {
                    Response.Redirect("logout.ashx");
                }
               

            }
        }

        //根据不同的用户的权限来获取不同的模块
        public void GetDataTable(string UserID)
        {
            int iUserID = Convert.ToInt32(UserID);
            //string strFirst = "select * from SM_LeftParentMenu where ParentMenuValue = '" + iParentMenuValue + "'";
            string strFirst = " select LeftParentMenu.* ,smUserRoles.*   from  LeftParentMenu,smUserRoles  " +
                              "where LeftParentMenu.ParentMenuValue = smUserRoles.ParentMenuValue " +
                              "and smUserRoles.userid = " + iUserID + "";
            DataSet ds1 = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strFirst, null);
            dtFirst = ds1.Tables[0];

            string strSecond = "select * from LeftChildMenu";
            DataSet ds2 = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSecond, null);
            dvSecond = new DataView(ds2.Tables[0]);
        }

        public void InitFirstMenu()
        {
            MenuCount = dtFirst.Rows.Count;
            Response.Write("<body scroll='yes' leftmargin='0' topmargin='0' onload='hidden_showmenu(" + MenuCount + "," + MenuCount + ");'>");
            Response.Write("<table width=100% height=100%>");
            Response.Write("<tr>");
            Response.Write("<td valign=top>");
            ///////////////////##
            Response.Write("<table width= 100% border='0' align='center' cellpadding='0' cellspacing='0'>");
            for (int i = 1; i <= dtFirst.Rows.Count; i++)
            {
                DataRow dr = dtFirst.Rows[i - 1];
                Response.Write("<tr>");
                Response.Write("<td onclick='hidden_showmenu(" + i.ToString() + "," + MenuCount + ")' bgcolor='#999999' height='25' class='headtd1'>");
                Response.Write("&nbsp;<img src='" + dr["ParentMenuIco"] + "' width='16' height='16'  align='absmiddle'>&nbsp;&nbsp; ");
                Response.Write(dr["ParentMenuName"].ToString() + "</td>");
                Response.Write("</tr>");

                Response.Write("<tr id='menu" + i.ToString() + "'> ");
                Response.Write("<td>");
                Response.Write("<table width='75%' border='0' align='center' cellpadding='0' cellspacing='0'>");
                Response.Write("<tr>");
                Response.Write("<td height='6'></td>");
                Response.Write("</tr>");
                Response.Write("</table>");
                Response.Write("<table border='0' cellspacing='0' cellpadding='3' width='200px' align='center'>");

                InitSecondMenu(dr["ParentMenuValue"].ToString());

                Response.Write("</table>");
                Response.Write("<table width='75%' border='0' align='center' cellpadding='0' cellspacing='0'>");
                Response.Write("<tr>");
                Response.Write("<td height='6'></td>");
                Response.Write("</tr>");
                Response.Write("</table>");
                Response.Write("</td>");
                Response.Write("</tr>");

            }
            Response.Write("</table>");
            Response.Write("</td>");
            Response.Write("</tr>");
            Response.Write("<tr>");
            Response.Write("<td valign=bottom >");
            //显示时间
            Response.Write("<table width='130' border='0' align='center' cellpadding='0' cellspacing='0'>");
            Response.Write("<tr>");
            Response.Write("<td valign='bottom' height='40'> ");
            Response.Write("<div align='center'> ");
            Response.Write("<table width='90%' border='1' cellspacing='0' cellpadding='5' height='19' bordercolor='888888' bordercolordark='#FFFFFF'>");
            Response.Write("<tr>");
            Response.Write("<td>");
            Response.Write("<div id='face' align='center'> </div>");
            Response.Write("</td>");
            Response.Write("</tr>");
            Response.Write("</table>");
            Response.Write("</div>");
            Response.Write("</td>");
            Response.Write("</tr>");

            Response.Write("</table>");
            Response.Write("</td>");
            Response.Write("</tr>");
            Response.Write("</table>");
        }

        public void InitSecondMenu(string MenuParent)
        {
            dvSecond.RowFilter = "TreeParentID=" + MenuParent;
            foreach (DataRowView dr in dvSecond)
            {
                Response.Write("<tr>");

              // Response.Write("<script   language='javascript'> parent.frames(2).window.location.href='unitModiXC.aspx'; </script>");
           
               // Response.Write("<td class='headtd2' onMouseOver=this.className='headtd1'; onMouseOut=this.className='headtd2'; onClick='javascript:top.right.location.href=" + '"' + dr["ChildTreeLink"].ToString() + '"' + "';> ");
                Response.Write("<td class='headtd2' onMouseOver=this.className='headtd1'; onMouseOut=this.className='headtd2'; onClick='javascript:parent.parent.frames[1].location.href=" + '"' + dr["ChildTreeLink"].ToString() + '"' + "';> ");
              
                Response.Write("<div align='center'><img src='" + dr["ChildTreeIco"] + "' width='35' height='33'> ");
                Response.Write("<table width='100%' border='0' cellspacing='0' cellpadding='0'>");
                Response.Write("<tr>");
                Response.Write("<td height='2'></td>");
                Response.Write("</tr>");
                Response.Write("</table>");
                Response.Write(dr["ChildTreeName"].ToString() + "</div>");
                Response.Write("</td>");
                Response.Write("</tr>");
            }

        }
    }
}