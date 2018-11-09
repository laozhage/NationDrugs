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
    public partial class Ucpreparation : System.Web.UI.UserControl
    {
        protected void Page_Disposed(object sender, EventArgs e)
        {
            //销毁这个页面时候要把Session["insertCount1"]
            Session.Remove("insertCount1");
            //新增
            Session.Remove("keyppid");
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
                    DataBindText(drugid);
                }
                else
                {
                    Response.Redirect("../AdWeb/APassport.aspx");
                }
                
   

            }//ispostback
            
        }

        public void DataBindText(string drugid)
        {
            cpreparation cport = new cpreparation();
            try
            {
                DataTable dt = cport.GetPrepatationDT(drugid);
                if (dt.Rows.Count > 0)
                {
                  //绑定到repeater上
                    Rpter_person.DataSource = dt;
                    Rpter_person.DataBind();
                }
                Rpter_person.Visible = (dt.Rows.Count > 0) ? true : false;
            }
            catch
            { }
        }

        protected void bnt_savePreparation_Click(object sender, EventArgs e)
        {            
            int insertCount1 = 0;
            if (Session["insertCount1"] != null)
            {
                insertCount1 = Convert.ToInt32(Session["insertCount1"].ToString());
            }
            else
                insertCount1 = 0;
            //保存数据
            if ( insertCount1 == 0)
            {//插入操作并且是首次插入
                if (ExcuteInsert() == 1)
                {
                    insertCount1++;
                    Session["insertCount1"] = insertCount1;
                    Script.AjaxAlert(bnt_savePreparation, "恭喜您，添加制剂信息成功！");
                }
            }
            else if ( insertCount1 != 0)
            {//插入操作但是已经插入记录生成了一个ppid，只能使用更新操作
                int keyid = Convert.ToInt32(hid_keyid.Value.ToString().Trim());
                if (ExcuteUpdate(keyid) == 1)
                    Script.AjaxAlert(bnt_savePreparation, "恭喜您，保存制剂信息成功！");
            }            
            else
            {
                Script.AjaxAlert(bnt_savePreparation, "对不起，保存制剂信息失败！"); ;
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

        protected void bnt_cancal_Click(object sender, EventArgs e)
        {
            // 输入制剂
            Response.Redirect("ACharacter.aspx");
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            
            CharTextRequired1.TextValue = string.Empty;
            RichText1.TextValue = string.Empty;
            Session["insertCount1"] = "0";
        }
        protected int ExcuteUpdate(int keyid)
        {

            string UpdateCommand = "UPDATE [preparation] SET [pName] = @pName, [about] = @about WHERE [ppid] = @ppid";
            int val = -10;
            SqlParameter[] par = new SqlParameter[3];

          
            if (Session["drugid"] == null)
            {
                //这个地方还需要再次考虑一下，是否要弹出一个窗口
                Response.Redirect("../Admin/AdWeb/APassport.aspx");
                return 0;
            }

            par[0] = new SqlParameter("@pName", SqlDbType.NText); par[0].Value = CharTextRequired1.TextValue;
            par[1] = new SqlParameter("@about", SqlDbType.NText); par[1].Value = RichText1.TextValue;
            par[2] = new SqlParameter("@ppid", SqlDbType.Int); par[2].Value = keyid;

            cpreparation _cpr = new cpreparation();
            try
            {
                val = _cpr.ModiPrepatation(UpdateCommand, par);
            }
            catch
            { }
            return val;

        }

      //Excute在插入操作之后能在 Session["keyppid"] = keyid;和隐藏的值 hid_keyid.Value = keyid.ToString().Trim();保留主键id
        protected int ExcuteInsert()
        {
            int val = -10;
            //插入命令
            string InsertCommand = "INSERT INTO [preparation] ( [drugid], [pName], [about]) VALUES (@drugid, @pName, @about)";
            SqlParameter[] par = new SqlParameter[3];

            int idrugid =0;
            if (Session["drugid"] != null)
            {
                idrugid = Convert.ToInt32(Session["drugid"].ToString());
            }
            else
            {
                //这个地方还需要再次考虑一下，是否要弹出一个窗口
                Response.Redirect("../Admin/AdWeb/APassport.aspx");
            }
            par[0] = new SqlParameter("@drugid", SqlDbType.Int); par[0].Value = idrugid;
            par[1] = new SqlParameter("@pName", SqlDbType.NText); par[1].Value = CharTextRequired1.TextValue;
            par[2] = new SqlParameter("@about", SqlDbType.NText); par[2].Value = RichText1.TextValue;

            cpreparation _cpr = new cpreparation();
            DataTable dtcpre;
            int keyid = 0;
            try
            {
                val = _cpr.ModiPrepatation(InsertCommand, par);
                dtcpre = _cpr.GetPrepatationDT(idrugid.ToString());
                if (dtcpre.Rows.Count > 0)
                {
                    //ppid为自增的主键id，所以要在保存之后立马把它的主键id获取到，以利于更新
                    keyid = Convert.ToInt32(dtcpre.Rows[dtcpre.Rows.Count - 1]["ppid"].ToString().Trim());
                    Session["keyppid"] = keyid;
                    hid_keyid.Value = keyid.ToString().Trim();
                }
            }
            catch
            { }
            return val;

        }


        public void test()
        {
            string MIFlag = Session["UpdateOrInsertFlag"].ToString();
            int insertCount1 = 0;
            if (Session["insertCount1"] != null)
            {
                insertCount1 = Convert.ToInt32(Session["insertCount1"].ToString());
            }
            else
                insertCount1 = 0;

            //保存数据
            if (string.Equals(MIFlag, "Insert") && insertCount1 == 0)
            {//插入操作并且是首次插入
                if (ExcuteInsert() == 1)
                {
                    insertCount1++;
                    Session["insertCount1"] = insertCount1;
                    Script.AjaxAlert(bnt_savePreparation, "恭喜您，添加制剂信息成功！");
                }
            }
            else if (string.Equals(MIFlag, "Insert") && insertCount1 != 0)
            {//插入操作但是已经插入记录生成了一个ppid，只能使用更新操作
                int keyid = Convert.ToInt32(hid_keyid.Value.ToString().Trim());
                if (ExcuteUpdate(keyid) == 1)
                    Script.AjaxAlert(bnt_savePreparation, "恭喜您，保存制剂信息成功！");
            }
            else if (string.Equals(MIFlag, "Update") && insertCount1 != 0)
            {
                //更新操作还要从点击事件中获取一个主键id方法就是放在hid_keyid字段中
                int keyid = Convert.ToInt32(hid_keyid.Value.ToString().Trim());
                if (ExcuteUpdate(keyid) == 1)
                    Script.AjaxAlert(bnt_savePreparation, "恭喜您，更新制剂信息成功！");
            }
            else if (string.Equals(MIFlag, "Update") && insertCount1 == 0)
            {
                //更新操作也可能要插入新记录
                if (ExcuteInsert() == 1)
                {
                    insertCount1++;
                    Session["insertCount1"] = insertCount1;
                    Script.AjaxAlert(bnt_savePreparation, "恭喜您，添加制剂信息成功！");
                }
            }
            else
            {
                Script.AjaxAlert(bnt_savePreparation, "对不起，保存制剂信息失败！"); ;
                return;
            }

        }

        protected void Rpter_person_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                  int  igppid = Convert.ToInt32(e.CommandArgument.ToString().Trim());
                  string delString = "DELETE FROM preparation WHERE ppid =  " + igppid;
                  SqlHelper.ExecuteNonQuery(delString);
                //删除之后要重新加载repeater
                  DataBindText(drugid);
                //删除之后要清除2个文本框的内容
                  CharTextRequired1.TextValue = string.Empty;
                  RichText1.TextValue = string.Empty;
                  Session["insertCount1"] = "0";
                //-----------------------------------
              }
            if (e.CommandName == "detail")
            {
                int igppid = Convert.ToInt32(e.CommandArgument.ToString().Trim());
                //点击了详细资料之后，不可以插入操作，要记住选择的keyid
                Session["keyppid"] = igppid;
                hid_keyid.Value = igppid.ToString().Trim();
                Session["insertCount1"] = "1";
                //---------------------------------
                string selectString = "select * from preparation WHERE ppid =  " + igppid;
                SqlDataReader sda = SqlHelper.ExecuteReader(selectString);
                if (sda.HasRows)
                {
                    sda.Read();
                    CharTextRequired1.TextValue = sda["pName"].ToString();
                    RichText1.TextValue  = sda["about"].ToString();
                }
                  
            }
        }

        protected void btn_back1_Click(object sender, EventArgs e)
        {
            //返回到上一页
            //返回上一页无论是更新操作还是插入操作都一样为更新操作,flag = 1表示更新，flag =0表示插入
            Session["flag"] = "1";            
            Response.Redirect("APassport.aspx");
          
        }

    }
}