using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using NationDrugs.BaseOption;
using System.Data;
using System.Data.SqlClient;

namespace NationDrugs.DrugHan.Admin.UcFiles
{
    public partial class ucCharacter : System.Web.UI.UserControl
    {
        protected void Page_Disposed(object sender, EventArgs e)
        {
            //销毁这个页面时候要把Session["insertCount1"]
            Session.Remove("insertCount2");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string drugid = string.Empty;
                string drugName = string.Empty;
                if (Session["drugid"] != null)
                {
                    drugid = Session["drugid"].ToString();
                    cpassport cp = new cpassport();
                    drugName = cp.GetDrugName(drugid);
                    //把药材的名称绑定在中药名上
                    Ulable1.TextValue = drugName;
                    //绑定reptear
                    hid_drugid.Value = drugid;
                    //加入存在数据需要绑定过来
                    DataBindText(drugid);
                }
                else
                {
                    Response.Redirect("../AdWeb/APassport.aspx");
                }
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            int insertCount2 = 0;
            if (Session["insertCount2"] != null)
            {
                insertCount2 = Convert.ToInt32(Session["insertCount2"].ToString());
            }
            else
                insertCount2 = 0;
            //保存数据
            if (insertCount2 == 0)
            {//插入操作并且是首次插入
                if (ExcuteInsert() == 1)
                {
                    insertCount2++;
                    Session["insertCount2"] = insertCount2;
                    Script.AjaxAlert(btn_save, "恭喜您，添加资源特征特性描述信息（物质属性）成功！");
                }
            }
            else if (insertCount2 != 0)
            {//插入操作但是已经插入记录生成了一个ppid，只能使用更新操作
                int ccid = Convert.ToInt32(hid_ccid.Value.ToString().Trim());
                if (ExcuteUpdate(ccid) == 1)
                    Script.AjaxAlert(btn_save, "恭喜您，保存资源特征特性描述信息（物质属性）成功！");
            }
            else
            {
                Script.AjaxAlert(btn_save, "对不起，保存资源特征特性描述信息（物质属性）失败！"); ;
                return;
            }
            //保存之后要进行刷新页面
            string drugid = string.Empty;
            if (Session["drugid"] != null)
            {
                drugid = Session["drugid"].ToString();
                DataBindText(drugid);
            }
            else
            {
                Response.Redirect("../AdWeb/APassport.aspx");
            }
        }

        protected void btn_next_Click(object sender, EventArgs e)
        {
            if (hid_ccid.Value == string.Empty)
            {
                Script.AjaxAlert(btn_next, "对不起，请先保存该药品的数据后再进行下一步操作！");
                return;
            }
            else

                Response.Redirect("../AdWeb/AResearch.aspx");
        }
        protected void DataBindText(string drugid)
        {
            cCharacter cchar = new cCharacter();
            try
            {
                DataTable dt = cchar.GetCharacterDatatable(drugid);
                if (dt.Rows.Count > 0)
                {
                    //把检索出来的表数据绑定到控件上,有数据过来就不能再插入操作了，需要的是更新操作
                    Session["insertCount2"] = "1";
                    hid_ccid.Value = cchar.GetCCid(drugid).ToString().Trim();
                    hid_drugid.Value = drugid;

                    CharText14.TextValue = dt.Rows[0]["cc14"].ToString().Trim();
                    CharText15.TextValue = dt.Rows[0]["cc15"].ToString().Trim();
                    CharText16.TextValue = dt.Rows[0]["cc16"].ToString().Trim();
                    CharText17.TextValue = dt.Rows[0]["cc17"].ToString().Trim();
                    RichText18.TextValue = dt.Rows[0]["cc18"].ToString().Trim();
                    RichText19.TextValue = dt.Rows[0]["cc19"].ToString().Trim();
                    RichText20.TextValue = dt.Rows[0]["cc20"].ToString().Trim();
                }
                else
                {
                    Session["insertCount2"] = "0";
                    CharText14.TextValue = "";
                    CharText15.TextValue = "";
                    CharText16.TextValue = "";
                    CharText17.TextValue = "";
                    RichText18.TextValue = "";
                    RichText19.TextValue = "";
                    RichText20.TextValue = "";
                }
            }
            catch
            { }
        }

        protected int ExcuteUpdate(int keyid)
        {
            int val = -10;
            string UpdateCommand = "UPDATE [character] SET  [cc14] = @cc14, [cc15] = @cc15, [cc16] = @cc16, [cc17] = @cc17, [cc18] = @cc18, [cc19] = @cc19, [cc20] = @cc20 WHERE [ccid] = @ccid";
            
            if (Session["drugid"] == null)
            {
                Response.Redirect("../Admin/AdWeb/APassport.aspx");
                return 0;
            }
            SqlParameter[] par = new SqlParameter[8];
            par[0] = new SqlParameter("@ccid", SqlDbType.Int); par[0].Value = keyid;

            par[1] = new SqlParameter("@cc14", SqlDbType.NVarChar, 500); par[1].Value = CharText14.TextValue;
            par[2] = new SqlParameter("@cc15", SqlDbType.NVarChar, 500); par[2].Value = CharText15.TextValue;
            par[3] = new SqlParameter("@cc16", SqlDbType.NVarChar, 500); par[3].Value = CharText16.TextValue;
            par[4] = new SqlParameter("@cc17", SqlDbType.NVarChar, 500); par[4].Value = CharText17.TextValue;
            par[5] = new SqlParameter("@cc18", SqlDbType.NText); par[5].Value = RichText18.TextValue;
            par[6] = new SqlParameter("@cc19", SqlDbType.NText); par[6].Value = RichText19.TextValue;
            par[7] = new SqlParameter("@cc20", SqlDbType.NText); par[7].Value = RichText20.TextValue;
              
            cCharacter cchar = new cCharacter();
            
            try
            {
                val = cchar.ModiCharacter(UpdateCommand, par);
                
            }
            catch
            { }

            return val;
        }
        protected int ExcuteInsert()
        {
            int val = -10;

            string InsertCommand = "INSERT INTO [character] ([drugid], [cc14], [cc15], [cc16], [cc17], [cc18], [cc19], [cc20]) VALUES ( @drugid, @cc14, @cc15, @cc16, @cc17, @cc18, @cc19, @cc20)";
           
            SqlParameter[] par = new SqlParameter[8];

            int idrugid = 0;
            if (Session["drugid"] != null)
            {
                hid_drugid.Value =Session["drugid"].ToString(); 
                idrugid = Convert.ToInt32(Session["drugid"].ToString());
            }
            else
            {
                //这个地方还需要再次考虑一下，是否要弹出一个窗口
                Response.Redirect("../Admin/AdWeb/APassport.aspx");
            }
            par[0] = new SqlParameter("@drugid", SqlDbType.Int); par[0].Value = idrugid;
            par[1] = new SqlParameter("@cc14", SqlDbType.NVarChar, 500); par[1].Value = CharText14.TextValue;
            par[2] = new SqlParameter("@cc15", SqlDbType.NVarChar, 500); par[2].Value = CharText15.TextValue;
            par[3] = new SqlParameter("@cc16", SqlDbType.NVarChar, 500); par[3].Value = CharText16.TextValue;
            par[4] = new SqlParameter("@cc17", SqlDbType.NVarChar, 500); par[4].Value = CharText17.TextValue;
            par[5] = new SqlParameter("@cc18", SqlDbType.NText); par[5].Value = RichText18.TextValue;
            par[6] = new SqlParameter("@cc19", SqlDbType.NText); par[6].Value = RichText19.TextValue;
            par[7] = new SqlParameter("@cc20", SqlDbType.NText); par[7].Value = RichText20.TextValue;

            cCharacter cchar = new cCharacter();
            int gccid = -10;
            try
            {
                val = cchar.ModiCharacter(InsertCommand, par);
                //插入成功之后要取出刚刚插入的ccid
                gccid = cchar.GetCCid(idrugid.ToString().Trim());
                hid_ccid.Value = gccid.ToString().Trim();
            }
            catch
            { }



            return val;
        }

        protected void btn_back2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Apreparation.aspx");
        }

    }
}