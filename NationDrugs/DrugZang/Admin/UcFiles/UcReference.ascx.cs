using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NationDrugs.BaseOption;
using System.Data;
using System.Data.SqlClient;

namespace NationDrugs.DrugZang.Admin.UcFiles
{
    public partial class UcReference : System.Web.UI.UserControl
    {
        private const string insertCountN = "insertCount6";
        protected void Page_Disposed(object sender, EventArgs e)
        {
            //销毁这个页面时候要把Session["insertCount3"]
            Session.Remove(insertCountN);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //第一次打开可以考虑来个添加操作
                btn_newRe_Click(sender, e);

                string drugid = string.Empty;
                string drugName = string.Empty;
                string rsid = string.Empty;
                if (Session["drugid"] != null )
                {
                    //获取right表的内容，绑定在gv上
                    drugid = Session["drugid"].ToString().Trim();
                  
                    cpassport cp = new cpassport();
                    drugName = cp.GetDrugName(drugid);
                    //把药材的名称绑定在中药名上
                    Ulable1.TextValue = drugName;
                    //绑定GV
                    DataBindText(drugid);
                    //登陆进来之后就要保存2个参数到隐藏的字段
                    hid_drugid.Value = drugid;
                   
                }
                else
                {
                    Server.Transfer("../AdWeb/APassport.aspx");
                }
            }
        }

        public void DataBindText(string drugid)
        {
            cReference refc = new cReference();
            try
            {
                DataTable dt = refc.GetRefTable(drugid);
                gv.Visible = (dt.Rows.Count > 0) ? true : false;
                if (dt.Rows.Count > 0)
                {
                    //绑定到GV
                    gv.DataSource = dt;
                    gv.DataBind();
                }
            }
            catch
            { }
        }
        protected int ExcuteInsert()
        {
            int val = -10;
            string InsertCommand = "INSERT INTO [Reference] ([drugid], [title], [magazine], [author], [gov], [province], [year], [vol], [page], [abs], [refbak1], [refbak2]) VALUES (@drugid, @title, @magazine, @author, @gov, @province, @year, @vol, @page, @abs, @refbak1, @refbak2)";
            SqlParameter[] par = new SqlParameter[12];
            int idrugid = 0;
            if (Session["drugid"] != null )
            {
                hid_drugid.Value = Session["drugid"].ToString();
                idrugid = Convert.ToInt32(Session["drugid"].ToString());               
            }
            else
            {
                //这个地方还需要再次考虑一下，是否要弹出一个窗口
                Response.Redirect("../Admin/AdWeb/APassport.aspx");
            }
            par[0] = new SqlParameter("@drugid", SqlDbType.Int);             par[0].Value = Convert.ToInt32(hid_drugid.Value);
            par[1] = new SqlParameter("@title", SqlDbType.NVarChar, 1000);    par[1].Value = CharText1.TextValue;
            par[2] = new SqlParameter("@magazine", SqlDbType.NVarChar, 1000); par[2].Value = CharText2.TextValue;
            par[3] = new SqlParameter("@author", SqlDbType.NVarChar, 800);    par[3].Value = CharText3.TextValue;
            par[4] = new SqlParameter("@gov", SqlDbType.NText);               par[4].Value = CharText4.TextValue;
            par[5] = new SqlParameter("@province", SqlDbType.NVarChar, 200);  par[5].Value = CharText5.TextValue;
            par[6] = new SqlParameter("@year", SqlDbType.NVarChar, 200);      par[6].Value = CharText6.TextValue;
            par[7] = new SqlParameter("@vol", SqlDbType.NVarChar, 200);       par[7].Value = CharText7.TextValue;
            par[8] = new SqlParameter("@page", SqlDbType.NVarChar, 400);      par[8].Value = CharText8.TextValue;
            par[9] = new SqlParameter("@abs", SqlDbType.NText);               par[9].Value = CharText9.TextValue;
            par[10] = new SqlParameter("@refbak1", SqlDbType.NVarChar, 400);  par[10].Value ="";
            par[11] = new SqlParameter("@refbak2", SqlDbType.NVarChar, 400);  par[11].Value ="";
           
            cReference cref = new cReference();
            int grefid = -10;
            try
            {
                val = cref.ModiReference(InsertCommand, par);
                //取出刚刚插入的文献编号
                grefid = cref.GetRefID(idrugid.ToString());
                hid_refid.Value = grefid.ToString();

            }
            catch
            { }


            return val;
        }
        protected int ExcuteUpdate(int refid)
        {
            int val = -10;
            string UpdateCommand = "UPDATE [Reference] SET [drugid] = @drugid, [title] = @title, [magazine] = @magazine, [author] = @author, [gov] = @gov, [province] = @province, [year] = @year, [vol] = @vol, [page] = @page, [abs] = @abs, [refbak1] = @refbak1, [refbak2] = @refbak2 WHERE [rfeid] = @rfeid";
            SqlParameter[] par = new SqlParameter[13];
            if (Session["drugid"] == null)
            {
                Response.Redirect("../Admin/AdWeb/APassport.aspx");
                return 0;
            }
            par[0] = new SqlParameter("@drugid", SqlDbType.Int); par[0].Value = Convert.ToInt32(hid_drugid.Value);
            par[1] = new SqlParameter("@title", SqlDbType.NVarChar, 1000); par[1].Value = CharText1.TextValue;
            par[2] = new SqlParameter("@magazine", SqlDbType.NVarChar, 1000); par[2].Value = CharText2.TextValue;
            par[3] = new SqlParameter("@author", SqlDbType.NVarChar, 800); par[3].Value = CharText3.TextValue;
            par[4] = new SqlParameter("@gov", SqlDbType.NText); par[4].Value = CharText4.TextValue;
            par[5] = new SqlParameter("@province", SqlDbType.NVarChar, 200); par[5].Value = CharText5.TextValue;
            par[6] = new SqlParameter("@year", SqlDbType.NVarChar, 200); par[6].Value = CharText6.TextValue;
            par[7] = new SqlParameter("@vol", SqlDbType.NVarChar, 200); par[7].Value = CharText7.TextValue;
            par[8] = new SqlParameter("@page", SqlDbType.NVarChar, 400); par[8].Value = CharText8.TextValue;
            par[9] = new SqlParameter("@abs", SqlDbType.NText); par[9].Value = CharText9.TextValue;
            par[10] = new SqlParameter("@refbak1", SqlDbType.NVarChar, 400); par[10].Value = "";
            par[11] = new SqlParameter("@refbak2", SqlDbType.NVarChar, 400); par[11].Value = "";

            par[12] = new SqlParameter("@rfeid", SqlDbType.Int); par[12].Value = refid;
            cReference cref = new cReference();
           
            try
            {
                val = cref.ModiReference(UpdateCommand, par);
              

            }
            catch
            { }



            return val;
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            int insertCount6 = 0;
            if (Session[insertCountN] != null)
            {
                insertCount6 = Convert.ToInt32(Session[insertCountN].ToString());
            }
            else
                insertCount6 = 0;

            if (insertCount6 == 0)
            {//插入操作并且是首次插入
                if (ExcuteInsert() == 1)
                {
                    insertCount6++;
                    Session[insertCountN] = insertCount6;
                    Script.AjaxAlert(btn_save, "恭喜您，添加文献来源信息成功！");
                }
            }
            else if (insertCount6 != 0)
            {
                //更新操作
                int irefid = Convert.ToInt32(hid_refid.Value.ToString().Trim());
                if (ExcuteUpdate(irefid) == 1)
                    Script.AjaxAlert(btn_save, "恭喜您，保存文献来源信息成功！");
            }
            else
            {
                Script.AjaxAlert(btn_save, "对不起，保存文献来源信息失败！");
            }

            //绑定GV
            string drugid = hid_drugid.Value;
            DataBindText(drugid);



        }

        protected void btn_newRe_Click(object sender, EventArgs e)
        {
            CharText1.TextValue = "";
            CharText2.TextValue ="";
            CharText3.TextValue ="";
            CharText4.TextValue ="";
            CharText5.TextValue ="";
            CharText6.TextValue ="";
            CharText7.TextValue ="";
            CharText8.TextValue ="";
            CharText9.TextValue = "";

            Session[insertCountN] = "0";
        }

        protected void btn_back6_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AdWeb/AResearch.aspx");
        }

        protected void btn_next6_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AdWeb/AHeredity.aspx");
        }

        protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //绑定GV
            string drugid = hid_drugid.Value;
            DataBindText(drugid);


            gv.PageIndex = e.NewPageIndex;
            gv.DataBind();
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string drugid = string.Empty;
            if (Session["drugid"] != null)
            {
                drugid = Session["drugid"].ToString();
            }
            else
            {
                Response.Redirect("../AdWeb/APassport.aspx");
            }
            if (e.CommandName == "del")
            {
                int irefid = Convert.ToInt32(e.CommandArgument.ToString().Trim());
                string delString ="DELETE FROM [Reference] WHERE [rfeid] = " + irefid;
                // 如果成功删除，那么就要把照片一起删除掉
                try
                {
                    SqlHelper.ExecuteNonQuery(delString);
                }
                catch
                {
                }

                //删除之后要重新加载repeater
                DataBindText(drugid);
                Session[insertCountN] = "0";
                //-----------------------------------
            }
            if (e.CommandName == "detail")
            {
                int irefid = Convert.ToInt32(e.CommandArgument.ToString().Trim());
                hid_refid.Value =  irefid.ToString();
                Session["refid"] = irefid;
                //-------------------------------------
                string selectString = "select * from  [Reference] WHERE [rfeid] =  " + irefid;
                SqlDataReader sda = SqlHelper.ExecuteReader(selectString);
                if (sda.HasRows)
                {
                    sda.Read();

                    hid_drugid.Value = sda["drugid"].ToString();
                    hid_refid.Value = sda["rfeid"].ToString();

                    CharText1.TextValue = sda["title"].ToString();
                    CharText2.TextValue = sda["magazine"].ToString();
                    CharText3.TextValue = sda["author"].ToString();
                    CharText4.TextValue = sda["gov"].ToString();
                    CharText5.TextValue = sda["province"].ToString();
                    CharText6.TextValue = sda["year"].ToString();
                    CharText7.TextValue = sda["vol"].ToString();
                    CharText8.TextValue = sda["page"].ToString();
                    CharText9.TextValue = sda["abs"].ToString();                   
                }

                Session[insertCountN] = "1";
                DataBindText(drugid);

            }





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
            for (int i = 0; i < gv.Rows.Count; i++)
            {

                string con0 = gv.Rows[i].Cells[0].Text.ToString().Trim();
                if (con0.Length >= 12)
                {
                    con0 = con0.Substring(0, 12) + "...";
                }
                gv.Rows[i].Cells[0].Text = con0.Trim();


                string con2= gv.Rows[i].Cells[2].Text.ToString().Trim();
                if (con2.Length >= 8)
                {
                    con2 = con2.Substring(0, 8) + "...";
                }
                gv.Rows[i].Cells[2].Text = con2.Trim();
            }
        }

   

    

       




    }
}