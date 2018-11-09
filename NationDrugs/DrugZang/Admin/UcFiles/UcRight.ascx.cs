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
    public partial class UcRight : System.Web.UI.UserControl
    {
        private const string insertCountN = "insertCount5";
        protected void Page_Disposed(object sender, EventArgs e)
        {
            //销毁这个页面时候要把Session["insertCount3"]
            Session.Remove(insertCountN);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string drugid = string.Empty;
                string drugName = string.Empty;
                string rsid = string.Empty;
                if (Session["drugid"] != null && Session["rsid"] != null)
                {
                    //获取right表的内容，绑定在gv上
                    drugid = Session["drugid"].ToString().Trim();
                    rsid = Session["rsid"].ToString().Trim();
                    cpassport cp = new cpassport();
                    drugName = cp.GetDrugName(drugid);
                    //把药材的名称绑定在中药名上
                    Ulable1.TextValue = drugName;
                    //绑定GV
                    DataBindText(drugid);


                    //登陆进来之后就要保存2个参数到隐藏的字段
                    hid_drugid.Value = drugid;
                    hid_rsid.Value = rsid;

                   
                }
                else
                {
                    Server.Transfer("../AdWeb/APassport.aspx");
                }
            }
        }
        public void DataBindText(string drugid)
        {
            cRightss ccrt = new cRightss();
            try
            {
                DataTable dt = ccrt.GetCrtDtByDrugid(drugid);
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
        protected void bnt_save_Click(object sender, EventArgs e)
        {
            if (UcDDRright1.SelectedValue <= 0)
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "message", "<script languge='javascript'>alert('请选择知识产权分类！'); </script>");
                return ;
            }
            int insertCount5 = 0;
            if (Session[insertCountN] != null)
            {
                insertCount5 = Convert.ToInt32(Session[insertCountN].ToString());
            }
            else
                insertCount5 = 0;

            if (insertCount5 == 0)
            {//插入操作并且是首次插入
                if (ExcuteInsert() == 1)
                {
                    insertCount5++;
                    Session[insertCountN] = insertCount5;
                    Script.AjaxAlert(bnt_save, "恭喜您，添加知识产权信息成功！");
                }
            }
            else if (insertCount5 != 0)
            {
                //更新操作
                int irightid = Convert.ToInt32(hid_rightid.Value.ToString().Trim());
                if (ExcuteUpdate(irightid) == 1)
                    Script.AjaxAlert(bnt_save, "恭喜您，保存知识产权信息成功！");
            }
            else
            {
                Script.AjaxAlert(bnt_save, "对不起，保存知识产权信息失败！");                 
            }

            //绑定GV
            string drugid = hid_drugid.Value;
            DataBindText(drugid);
        }
        protected int ExcuteUpdate(int rightid)
        {
            int val = -10;
            string UpdateCommand = "UPDATE [right] SET [rshid] = @rshid, [drugid] = @drugid, [rttype] = @rttype, [rtname] = @rtname, [rtcontent] = @rtcontent WHERE [rtid] = @rtid";

            SqlParameter[] par = new SqlParameter[6];
            if (Session["drugid"] == null)
            {
                Response.Redirect("../Admin/AdWeb/APassport.aspx");
                return 0;
            }
          
            par[0] = new SqlParameter("@rtid", SqlDbType.Int); par[0].Value = rightid;
            par[1] = new SqlParameter("@rshid", SqlDbType.Int); par[1].Value = Convert.ToInt32(hid_rsid.Value);
            par[2] = new SqlParameter("@drugid", SqlDbType.Int); par[2].Value = Convert.ToInt32(hid_drugid.Value);
            par[3] = new SqlParameter("@rttype", SqlDbType.Int); par[3].Value = UcDDRright1.SelectedValue;
            par[4] = new SqlParameter("@rtname", SqlDbType.NVarChar, 800); par[4].Value = CharTextRequired1.TextValue;
            par[5] = new SqlParameter("@rtcontent", SqlDbType.NText); par[5].Value = RichText1.TextValue;
            
            cRightss crght = new cRightss();
            try
            {
                val = crght.ModiRightss(UpdateCommand, par);
            }
            catch
            { }


            return val;
        }
        protected int ExcuteInsert()
        {
            int val = -10;
            string InsertCommand = "INSERT INTO [right] ([rshid], [drugid], [rttype], [rtname], [rtcontent]) VALUES (@rshid, @drugid, @rttype, @rtname, @rtcontent)";

            SqlParameter[] par = new SqlParameter[5];
            int idrugid = 0;
            if (Session["drugid"] != null && Session["rsid"] != null)
            {
                hid_drugid.Value = Session["drugid"].ToString();
                idrugid = Convert.ToInt32(Session["drugid"].ToString());

                hid_rsid.Value = Session["rsid"].ToString().Trim();
            }
            else
            {
                //这个地方还需要再次考虑一下，是否要弹出一个窗口
                Response.Redirect("../Admin/AdWeb/APassport.aspx");
            }
            par[0] = new SqlParameter("@rshid", SqlDbType.Int); par[0].Value = Convert.ToInt32(hid_rsid.Value);
            par[1] = new SqlParameter("@drugid", SqlDbType.Int); par[1].Value = Convert.ToInt32(hid_drugid.Value);
            par[2] = new SqlParameter("@rttype", SqlDbType.Int); par[2].Value = UcDDRright1.SelectedValue;
            par[3] = new SqlParameter("@rtname", SqlDbType.NVarChar, 800); par[3].Value = CharTextRequired1.TextValue;
            par[4] = new SqlParameter("@rtcontent", SqlDbType.NText); par[4].Value = RichText1.TextValue;

            cRightss crght = new cRightss();
            int grtid = -10;
            try
            {
                val = crght.ModiRightss(InsertCommand, par);
                //插入成功之后要取出刚刚插入的rtid
                grtid = crght.GetrtidByRsid(hid_rsid.Value);

                hid_rightid.Value = grtid.ToString();
               // Session["rtid"] = grtid;
            }
            catch
            { }

            return val;
        }


        protected void btn_back5_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AdWeb/AChemistry.aspx");
        }

        protected void btn_next5_Click(object sender, EventArgs e)
        {
            Server.Transfer("../AdWeb/AReference.aspx"); 
        }

        protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataBindText(hid_drugid.Value);           

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
                int irtid = Convert.ToInt32(e.CommandArgument.ToString().Trim());
                string delString = "DELETE FROM [right] WHERE [rtid] = " + irtid;
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
                int irtid = Convert.ToInt32(e.CommandArgument.ToString().Trim());
                hid_rightid.Value = irtid.ToString();
                Session["rtid"] = irtid;
                //-------------------------------------
                string selectString = "select * from  [right] WHERE [rtid] =  " + irtid;
                SqlDataReader sda = SqlHelper.ExecuteReader(selectString);
                if (sda.HasRows)
                {
                    sda.Read();

                    hid_drugid.Value = sda["drugid"].ToString();
                    hid_rsid.Value = sda["rshid"].ToString();

                    UcDDRright1.SetText = sda["rttype"].ToString();
                    CharTextRequired1.TextValue = sda["rtname"].ToString();
                    RichText1.TextValue = sda["rtcontent"].ToString();                  
                    Session[insertCountN] = "1";

                    DataBindText(drugid);
                }
              
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
                string stypeName = gv.Rows[i].Cells[0].Text.ToString();
                if (stypeName == "1")
                    gv.Rows[i].Cells[0].Text = "品名";
                else if (stypeName == "2")
                    gv.Rows[i].Cells[0].Text = "产品";
                else if (stypeName == "3")
                    gv.Rows[i].Cells[0].Text = "专利";
                else if (stypeName == "4")
                    gv.Rows[i].Cells[0].Text = "标准";
                else if (stypeName == "5")
                    gv.Rows[i].Cells[0].Text = "规范";

                string conName = gv.Rows[i].Cells[2].Text.ToString();
                if (conName.Length >= 6)
                {
                    conName = conName.Substring(0, 6) + "...";
                }
                gv.Rows[i].Cells[2].Text = conName;
                
            }
        }

        protected void btn_addnew_Click(object sender, EventArgs e)
        {
            CharTextRequired1.TextValue = "";
            RichText1.TextValue = "";
            Session[insertCountN] = "0";

            CharTextRequired1.Enabled = true;
            RichText1.Enabled = true;
        }
    }
}