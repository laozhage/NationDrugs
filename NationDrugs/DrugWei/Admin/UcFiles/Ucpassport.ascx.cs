using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using NationDrugs.BaseOption;


namespace NationDrugs.DrugWei.Admin.UcFiles
{
    public partial class Ucpassport : System.Web.UI.UserControl
    {

        protected void Page_Disposed(object sender, EventArgs e)
        {
            //销毁这个页面时候要把Session["insertCount"]
            if (Session["insertCount"] != null)
                Session.Remove("insertCount");
            if (Session["PassportGUID"] != null)
                Session.Remove("PassportGUID");
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {          
            if (!IsPostBack)
            {  
                string MIFlag = string.Empty;
                if (Session["UpdateOrInsertFlag"] != null)
                {
                    MIFlag = Session["UpdateOrInsertFlag"].ToString();
                    if (string.Equals(MIFlag, "Update"))
                    {
                        //更新操作说明前一个页面的Session["drugid"]中已经保存了drugid
                        string drugid = string.Empty;
                        if (Session["drugid"].ToString() != null)
                        {
                            drugid = Session["drugid"].ToString();
                            hid_drugid.Value = drugid;
                            DataBindText(drugid);
                        }

                    }
                    else //说明到这个页面是一个插入操作什么都不需要做了
                    {
                        ;
                    }

                }

            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //插入保存完之后要获取刚刚的drguid
            string MIFlag = Session["UpdateOrInsertFlag"].ToString();
            int insertCount = 0;
            if (Session["insertCount"] != null)
            {
                insertCount = Convert.ToInt32(Session["insertCount"].ToString());
            }
            else
                insertCount = 0;



            //保存数据
            if (string.Equals(MIFlag, "Insert") && insertCount == 0 )
            {//插入操作并且是首次插入
                if (ExcuteInsert() == 1)
                {
                    insertCount++;
                    Session["insertCount"] = insertCount;
                    string getGUID = Session["PassportGUID"].ToString();                    
                    hid_drugid.Value = cpassport.Getdrugid(getGUID).ToString();
                    Session["drugid"] = hid_drugid.Value;
                    Script.AjaxAlert(Button1, "恭喜您，添加护照信息成功！");
                }

            }
            else if (string.Equals(MIFlag, "Insert") && insertCount != 0)
            {//插入操作但是已经插入记录生成了一个drugid，只能使用更新操作
                int idrugid = Convert.ToInt32(hid_drugid.Value.ToString().Trim());
                if (ExcuteUpdate(idrugid) == 1)
                    Script.AjaxAlert(Button1, "恭喜您，保存护照信息成功！");
            }
            else if (string.Equals(MIFlag, "Update"))
            {
                int idrugid = Convert.ToInt32(hid_drugid.Value.ToString().Trim());
                if (ExcuteUpdate(idrugid) == 1)
                    Script.AjaxAlert(Button1, "恭喜您，更新护照信息成功！");
            }
            else
            {
                Script.AjaxAlert(Button1, "对不起，保存护照信息失败！"); ;
                return;
            }
           
           
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            // 输入制剂
           // Response.Redirect("../AdWeb/Apreparation.aspx");
            if(Session["drugid"]  != null)
               Server.Transfer("../AdWeb/Apreparation.aspx");
          
            else
               Page.ClientScript.RegisterStartupScript(typeof(Page), "message", "<script languge='javascript'>alert('请先保存该药材！'); </script>");
      
        }
        public void DataBindText(string drugid)
        {
            cpassport cport = new cpassport ();           
            try
            {
                DataTable dt = cport.GetPassportDatatable(drugid);
                if (dt.Rows.Count > 0)
                {
                    CharText1.TextValue = Server.UrlDecode(dt.Rows[0]["nationName"].ToString().Trim());
                    CharText2.TextValue = Server.UrlDecode(dt.Rows[0]["transltName"].ToString().Trim());
                    CharText3.TextValue = Server.UrlDecode(dt.Rows[0]["name"].ToString().Trim());
                    CharText4.TextValue = dt.Rows[0]["position"].ToString().Trim();
                    CharText5.TextValue = dt.Rows[0]["channel"].ToString().Trim();
                    CharText6.TextValue = dt.Rows[0]["effect"].ToString().Trim();
                    CharText7.TextValue = dt.Rows[0]["func"].ToString().Trim();
                    CharText8.TextValue = dt.Rows[0]["usef"].ToString().Trim();
                    CharText9.TextValue = dt.Rows[0]["Observe"].ToString().Trim();
                    CharText10.TextValue = dt.Rows[0]["standard"].ToString().Trim();
                   // CharText11.TextValue = dt.Rows[0][""].ToString().Trim();
                    CharText12.TextValue = dt.Rows[0]["classify"].ToString().Trim();
                    CharText13.TextValue = dt.Rows[0]["subjectno"].ToString().Trim();
                   

                }
            }
            catch
            { }
        }
        public int ExcuteUpdate(int idrugid)//有问题
        {
            int val = 0 ;
            //更新命令 ,更新的参数时候drugid 和preparation 不更新
            string UpdateCommand = "UPDATE [Passport] SET [nationName] = @nationName, [transltName] = @transltName, [name] = @name, [position] = @position, [channel] = @channel, [effect] = @effect, [func] = @func, [usef] = @usef, [Observe] = @Observe, [standard] = @standard, [classify] = @classify, [subjectno] = @subjectno  WHERE [drugid] = @drugid";

            SqlParameter[] par = new SqlParameter[13];

            par[0] = new SqlParameter("@nationName", SqlDbType.NVarChar, 20); par[0].Value = CharText1.TextValue;
            par[1] = new SqlParameter("@transltName", SqlDbType.NVarChar, 20); par[1].Value = CharText2.TextValue;
            par[2] = new SqlParameter("@name", SqlDbType.NVarChar, 40); par[2].Value = CharText3.TextValue;
            par[3] = new SqlParameter("@position", SqlDbType.NVarChar, 20); par[3].Value = CharText4.TextValue;
            par[4] = new SqlParameter("@channel", SqlDbType.NVarChar, 100); par[4].Value = CharText5.TextValue;
            par[5] = new SqlParameter("@effect", SqlDbType.NVarChar, 40); par[5].Value = CharText6.TextValue;
            par[6] = new SqlParameter("@func", SqlDbType.NVarChar, 400); par[6].Value = CharText7.TextValue;
            par[7] = new SqlParameter("@usef", SqlDbType.NVarChar, 100); par[7].Value = CharText8.TextValue;
            par[8] = new SqlParameter("@Observe", SqlDbType.NVarChar, 3000); par[8].Value = CharText9.TextValue;
            par[9] = new SqlParameter("@standard", SqlDbType.NVarChar, 400); par[9].Value = CharText10.TextValue;            
            par[10] = new SqlParameter("@classify", SqlDbType.NVarChar, 40); par[10].Value = CharText12.TextValue;
            par[11] = new SqlParameter("@subjectno", SqlDbType.NVarChar, 30); par[11].Value = CharText13.TextValue;
           
            par[12] = new SqlParameter("@drugid", SqlDbType.Int); par[12].Value =  idrugid;
           

            cpassport _passport = new cpassport();
            try
            {
                val = _passport.Insertpassport(UpdateCommand, par);
            }
            catch
            { }

            return val;
        }
        public int ExcuteInsert()
        {
            int val  = -10;
            //插入命令
            string InsertCommand = "INSERT INTO [Passport] ([nationName], [transltName], [name], [position], [channel], [effect], [func], [usef], [Observe], [standard], [useGUID], [classify], [subjectno], [bdel], [ppbak1], [ppbak2]) VALUES ( @nationName, @transltName, @name, @position, @channel, @effect, @func, @usef, @Observe, @standard, @useGUID, @classify, @subjectno, @bdel, @ppbak1, @ppbak2)";
           
            //生成一个唯一的标识存放在制剂中用来区分该条记录
            string  DisplayGUID =  System.Guid.NewGuid().ToString();
            SqlParameter[] par = new SqlParameter[16];
           
            par[0] = new SqlParameter("@nationName", SqlDbType.NVarChar, 20); par[0].Value = CharText1.TextValue;
            par[1] = new SqlParameter("@transltName", SqlDbType.NVarChar, 20); par[1].Value = CharText2.TextValue;
            par[2] = new SqlParameter("@name", SqlDbType.NVarChar, 40);         par[2].Value = CharText3.TextValue;
            par[3] = new SqlParameter("@position", SqlDbType.NVarChar, 20); par[3].Value = CharText4.TextValue;
            par[4] = new SqlParameter("@channel", SqlDbType.NVarChar, 100); par[4].Value = CharText5.TextValue;
            par[5] = new SqlParameter("@effect", SqlDbType.NVarChar, 40); par[5].Value = CharText6.TextValue;
            par[6] = new SqlParameter("@func", SqlDbType.NVarChar, 400); par[6].Value = CharText7.TextValue;
            par[7] = new SqlParameter("@usef", SqlDbType.NVarChar, 100); par[7].Value = CharText8.TextValue;
            par[8] = new SqlParameter("@Observe", SqlDbType.NVarChar, 3000); par[8].Value = CharText9.TextValue;
            par[9] = new SqlParameter("@standard", SqlDbType.NVarChar, 400); par[9].Value = CharText10.TextValue;
            par[10] = new SqlParameter("@useGUID", SqlDbType.NVarChar, 128); par[10].Value = DisplayGUID;
            par[11] = new SqlParameter("@classify", SqlDbType.NVarChar, 40); par[11].Value = CharText12.TextValue;
            par[12] = new SqlParameter("@subjectno", SqlDbType.NVarChar, 30); par[12].Value = CharText13.TextValue;
            
            par[13] = new SqlParameter("@bdel", SqlDbType.Bit); par[13].Value = 1;
            par[14] = new SqlParameter("@ppbak1", SqlDbType.NVarChar, 30); par[14].Value =string.Empty;
            par[15] = new SqlParameter("@ppbak2", SqlDbType.NVarChar, 30); par[15].Value = string.Empty;         
          

            cpassport _passport = new cpassport();

            try
            {
                val = _passport.Insertpassport(InsertCommand, par);
                Session["PassportGUID"] = DisplayGUID;               
            }
            catch 
            { }
            return val;

        }

 


    }
}