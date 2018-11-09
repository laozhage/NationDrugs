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
    public partial class UcResearch : System.Web.UI.UserControl
    {
        private const string insertCountN = "insertCount3";
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
            int insertCount3 = 0;
            if (Session[insertCountN] != null)
            {
                insertCount3 = Convert.ToInt32(Session[insertCountN].ToString());
            }
            else
                insertCount3 = 0;

            //------------------------
            if (insertCount3 == 0)
            {//插入操作并且是首次插入
                if (ExcuteInsert() == 1)
                {
                    insertCount3++;
                    Session[insertCountN] = insertCount3;
                    Script.AjaxAlert(btn_save, "恭喜您，添加资源研究成果描述信息（文化属性）成功！");
                }
            }
            else if (insertCount3 != 0)
            {//插入操作但是已经插入记录生成了一个ppid，只能使用更新操作
                int rsid = Convert.ToInt32(hid_rsid.Value.ToString().Trim());
                if (ExcuteUpdate(rsid) == 1)
                    Script.AjaxAlert(btn_save, "恭喜您，保存资源研究成果描述信息（文化属性）成功！");
            }
            else
            {
                Script.AjaxAlert(btn_save, "对不起，保存资源研究成果描述信息（文化属性）失败！"); ;
                return;
            }

            string drugidd =  hid_drugid.Value;
            //加入存在数据需要绑定过来
            DataBindText(drugidd);
        }

        protected void btn_back3_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AdWeb/ACharacter.aspx");
        }

        protected void btn_next4_Click(object sender, EventArgs e)
        {
            Session["rsid"] = hid_rsid.Value;
            Response.Redirect("../AdWeb/AChemistry.aspx");
        }
        protected int ExcuteUpdate(int keyid)
        {
            int val = -10;
            string UpdateCommand = "UPDATE [Research] SET  [rsh21] = @rsh21, [rsh22] = @rsh22, [rsh23] = @rsh23, [rsh24] = @rsh24, [rsh25] = @rsh25, [rsh26] = @rsh26, [rsh27] = @rsh27, [rsh28] = @rsh28, [rsh29] = @rsh29, [rsh30] = @rsh30, [rsh31] = @rsh31 WHERE [rshid] = @rshid";
            SqlParameter[] par = new SqlParameter[12];
            if (Session["drugid"] == null)
            {
                Response.Redirect("../Admin/AdWeb/APassport.aspx");
                return 0;
            }
            par[0] = new SqlParameter("@rshid", SqlDbType.Int); par[0].Value = keyid;

            par[1] = new SqlParameter("@rsh21", SqlDbType.NText); par[1].Value = RichText21.TextValue;
            par[2] = new SqlParameter("@rsh22", SqlDbType.NText); par[2].Value = RichText22.TextValue;
            par[3] = new SqlParameter("@rsh23", SqlDbType.NVarChar, 50); par[3].Value = "";
            par[4] = new SqlParameter("@rsh24", SqlDbType.NText); par[4].Value = RichText24.TextValue;
            par[5] = new SqlParameter("@rsh25", SqlDbType.NText); par[5].Value = RichText25.TextValue;
            par[6] = new SqlParameter("@rsh26", SqlDbType.NText); par[6].Value = RichText26.TextValue;
            par[7] = new SqlParameter("@rsh27", SqlDbType.NText); par[7].Value = RichText27.TextValue;
            par[8] = new SqlParameter("@rsh28", SqlDbType.NText); par[8].Value = RichText28.TextValue;
            par[9] = new SqlParameter("@rsh29", SqlDbType.NText); par[9].Value = RichText29.TextValue;
            par[10] = new SqlParameter("@rsh30", SqlDbType.NText); par[10].Value = RichText30.TextValue;
            par[11] = new SqlParameter("@rsh31", SqlDbType.NVarChar, 50); par[11].Value = "";
            
            
            cResearch crh = new cResearch();           
            try
            {
                val = crh.ModiResearch(UpdateCommand, par);               
            }
            catch
            { }
            return val;
        }
        protected int ExcuteInsert()
        {
            int val = -10;
            string InsertCommand = "INSERT INTO [Research] ([drugid], [rsh21], [rsh22], [rsh23], [rsh24], [rsh25], [rsh26], [rsh27], [rsh28], [rsh29], [rsh30], [rsh31]) VALUES (@drugid, @rsh21, @rsh22, @rsh23, @rsh24, @rsh25, @rsh26, @rsh27, @rsh28, @rsh29, @rsh30, @rsh31)";
            SqlParameter[] par = new SqlParameter[12];

            int idrugid = 0;
            if (Session["drugid"] != null)
            {
                hid_drugid.Value = Session["drugid"].ToString();
                idrugid = Convert.ToInt32(Session["drugid"].ToString());
            }
            else
            {
                //这个地方还需要再次考虑一下，是否要弹出一个窗口
                Response.Redirect("../Admin/AdWeb/APassport.aspx");
            }
            par[0] = new SqlParameter("@drugid", SqlDbType.Int); par[0].Value = idrugid;
            par[1] = new SqlParameter("@rsh21", SqlDbType.NText); par[1].Value = RichText21.TextValue;
            par[2] = new SqlParameter("@rsh22", SqlDbType.NText); par[2].Value = RichText22.TextValue;
            par[3] = new SqlParameter("@rsh23", SqlDbType.NVarChar, 50); par[3].Value = "";
            par[4] = new SqlParameter("@rsh24", SqlDbType.NText); par[4].Value = RichText24.TextValue;
            par[5] = new SqlParameter("@rsh25", SqlDbType.NText); par[5].Value = RichText25.TextValue;
            par[6] = new SqlParameter("@rsh26", SqlDbType.NText); par[6].Value = RichText26.TextValue;
            par[7] = new SqlParameter("@rsh27", SqlDbType.NText); par[7].Value = RichText27.TextValue;
            par[8] = new SqlParameter("@rsh28", SqlDbType.NText); par[8].Value = RichText28.TextValue;
            par[9] = new SqlParameter("@rsh29", SqlDbType.NText); par[9].Value = RichText29.TextValue;
            par[10] = new SqlParameter("@rsh30", SqlDbType.NText); par[10].Value = RichText30.TextValue;
            par[11] = new SqlParameter("@rsh31", SqlDbType.NVarChar, 50); par[11].Value = "";

            cResearch crh = new cResearch();
            int grshid = -10;
            try
            {
                val = crh.ModiResearch(InsertCommand, par);
                //插入成功之后要取出刚刚插入的ccid
                grshid = crh.Getrshid(idrugid.ToString().Trim());
                hid_rsid.Value = grshid.ToString().Trim();
            }
            catch
            { }



            return val;           
        }
        protected void DataBindText(string drugid)
        {
            cResearch crh = new cResearch();
            try
            {
                DataTable dt = crh.GetResearchDatatable(drugid);
                if (dt.Rows.Count > 0)
                {
                    Session[insertCountN] = "1";
                    hid_rsid.Value = crh.Getrshid(drugid).ToString().Trim();                  

                    RichText21.TextValue = dt.Rows[0]["rsh21"].ToString().Trim();
                    RichText22.TextValue = dt.Rows[0]["rsh22"].ToString().Trim();
                    RichText24.TextValue = dt.Rows[0]["rsh24"].ToString().Trim();
                    RichText25.TextValue = dt.Rows[0]["rsh25"].ToString().Trim();
                    RichText26.TextValue = dt.Rows[0]["rsh26"].ToString().Trim();
                    RichText27.TextValue = dt.Rows[0]["rsh27"].ToString().Trim();
                    RichText28.TextValue = dt.Rows[0]["rsh28"].ToString().Trim();
                    RichText29.TextValue = dt.Rows[0]["rsh29"].ToString().Trim();
                    RichText30.TextValue = dt.Rows[0]["rsh30"].ToString().Trim();
                }
                else
                {
                    Session[insertCountN] = "0";

                    RichText21.TextValue ="";
                    RichText22.TextValue ="";
                    RichText24.TextValue ="";
                    RichText25.TextValue ="";
                    RichText26.TextValue ="";
                    RichText27.TextValue ="";
                    RichText28.TextValue ="";
                    RichText29.TextValue ="";
                    RichText30.TextValue = "";
                }

            }
            catch
            { }
        }







    }
}