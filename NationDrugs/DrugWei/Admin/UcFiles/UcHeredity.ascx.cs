using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NationDrugs.BaseOption;
using System.Data;
using System.Data.SqlClient;


namespace NationDrugs.DrugWei.Admin.UcFiles
{
    public partial class UcHeredity : System.Web.UI.UserControl
    {
        private const string insertCountN = "insertCount7";
        protected void Page_Disposed(object sender, EventArgs e)
        {
            //销毁这个页面时候要把Session["insertCount4"]
            Session.Remove(insertCountN);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string drugid = string.Empty;
                string drugName = string.Empty;
                string rsid = string.Empty;
                if (Session["drugid"] != null)
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
        protected int charTodi(string str)
        {
            int re = -1;
            try
            {
                char[] ch = str.ToCharArray(0, 1);
                re =  ch[0] - '1';               
            }
            catch
            { }
            return re;
        }
        protected int charTodiStr(string str, ref TextBox tx)
        {
            int re = -1;
            try
            {
                char[] ch = str.ToCharArray(0, 1);
                re = ch[0] - '1';
                if (str.Length > 1)
                {
                    tx.Enabled = true;
                    tx.Text = str.Substring(2);
                }
                else
                {
                    tx.Enabled = false;
                    tx.Text = string.Empty;
                }
            }
            catch
            { }
            return re;
        }

        protected void DataBindText(string drugid)
        {
            cHeredity chd = new cHeredity();
            try
            {
                DataTable dt = chd.GetHdTable(drugid);
                if (dt.Rows.Count > 0)
                {
                    Session[insertCountN] = 1;
                    hid_drugid.Value = drugid;
                    hid_hdid.Value = dt.Rows[0]["hdid"].ToString().Trim();
                    // 41
                    string shdt41 = dt.Rows[0]["hdt41"].ToString().Trim() ;
                    rbtn_41.SelectedIndex = charTodi(shdt41);
                    //42
                    CharText1.TextValue = dt.Rows[0]["hdt42"].ToString().Trim();
                    //43
                    string shdt43 = dt.Rows[0]["hdt43"].ToString().Trim();
                    rbtn_43.SelectedIndex = charTodi(shdt43);
                    //44
                    string shdt44 = dt.Rows[0]["hdt44"].ToString().Trim();
                    rbtn_44.SelectedIndex = charTodiStr(shdt44, ref txt_44);
                    //45
                    CharText2.TextValue = dt.Rows[0]["hdt45"].ToString().Trim();
                    //46
                    CharText3.TextValue = dt.Rows[0]["hdt46"].ToString().Trim();
                    //47采集时间toShortDate
                    txt_date1.Text = toShortDate(dt.Rows[0]["hdt47"].ToString().Trim());
                    //48
                    CharText5.TextValue = dt.Rows[0]["hdt48"].ToString().Trim();
                    //49
                    CharText6.TextValue = dt.Rows[0]["hdt49"].ToString().Trim();
                    //50
                    CharText7.TextValue = dt.Rows[0]["hdt50"].ToString().Trim();
                    //51
                    CharText8.TextValue = dt.Rows[0]["hdt51"].ToString().Trim();
                    //52
                    CharText9.TextValue = dt.Rows[0]["hdt52"].ToString().Trim();
                    //53
                    CharText10.TextValue = dt.Rows[0]["hdt53"].ToString().Trim();
                    //54
                    CharText11.TextValue = dt.Rows[0]["hdt54"].ToString().Trim();
                    //55
                    CharText12.TextValue = dt.Rows[0]["hdt55"].ToString().Trim();
                    //56 鉴定时间
                    txt_date2.Text = toShortDate(dt.Rows[0]["hdt56"].ToString().Trim());
                    //57
                    string shdt57 = dt.Rows[0]["hdt57"].ToString().Trim();
                    rbtn_57.SelectedIndex = charTodi(shdt57);
                    //58
                    string shdt58 = dt.Rows[0]["hdt58"].ToString().Trim();
                    rbtn_58.SelectedIndex = charTodi(shdt58);
                    //59
                    CharText14.TextValue = dt.Rows[0]["hdt59"].ToString().Trim();
                    //60
                    string shdt60 = dt.Rows[0]["hdt60"].ToString().Trim();
                    rbtn_60.SelectedIndex = charTodi(shdt60);
                    //61
                    string shdt61 = dt.Rows[0]["hdt61"].ToString().Trim();
                    rbtn_61.SelectedIndex = charTodiStr(shdt61, ref txt_61);
                    //62
                    string shdt62 = dt.Rows[0]["htd62"].ToString().Trim();
                    rbtn_62.SelectedIndex = charTodiStr(shdt62, ref txt_62);
                    //63
                    string shdt63 = dt.Rows[0]["htd63"].ToString().Trim();
                    rbtn_63.SelectedIndex = charTodiStr(shdt63, ref txt_63);
                    //64
                    string shdt64 = dt.Rows[0]["htd64"].ToString().Trim();
                    rbtn_64.SelectedIndex = charTodiStr(shdt64, ref txt_64);
                    //65
                    string shdt65 = dt.Rows[0]["htd65"].ToString().Trim();
                    rbtn_65.SelectedIndex = charTodi(shdt65);
                    //66
                    CharText15.TextValue = dt.Rows[0]["htd66"].ToString().Trim();
                    //67
                    string shdt67 = dt.Rows[0]["htd67"].ToString().Trim();
                    rbtn_67.SelectedIndex = charTodi(shdt67);


                }
            }
            catch
            { }
        }
        protected int ExcuteInsert()
        {
            int val = -10;
            string InsertCommand = "INSERT INTO [Heredity] ([drugid], [hdt41], [hdt42], [hdt43], [hdt44], [hdt45], [hdt46], [hdt47], [hdt48], [hdt49], [hdt50], [hdt51], [hdt52], [hdt53], [hdt54], [hdt55], [hdt56], [hdt57], [hdt58], [hdt59], [hdt60], [hdt61], [htd62], [htd63], [htd64], [htd65], [htd66], [htd67]) VALUES (@drugid, @hdt41, @hdt42, @hdt43, @hdt44, @hdt45, @hdt46, @hdt47, @hdt48, @hdt49, @hdt50, @hdt51, @hdt52, @hdt53, @hdt54, @hdt55, @hdt56, @hdt57, @hdt58, @hdt59, @hdt60, @hdt61, @htd62, @htd63, @htd64, @htd65, @htd66, @htd67)";
            SqlParameter[] par = new SqlParameter[28];
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
            if (rbtn_41.SelectedIndex == 0)
            {
                #region 给参数提供数字
                par[0] = new SqlParameter("@drugid", SqlDbType.Int);           par[0].Value = idrugid;
                par[1] = new SqlParameter("@hdt41", SqlDbType.NVarChar, 10);   par[1].Value = rbtn_41.SelectedItem.Value;
                par[2] = new SqlParameter("@hdt42", SqlDbType.NVarChar, 40);   par[2].Value = CharText1.TextValue;
                par[3] = new SqlParameter("@hdt43", SqlDbType.NVarChar, 50);   par[3].Value = rbtn_43.SelectedItem.Value;
                par[4] = new SqlParameter("@hdt44", SqlDbType.NVarChar, 50);   par[4].Value = rbtn_44.SelectedIndex == 4 ? rbtn_44.SelectedItem.Value + ":" + txt_44.Text.ToString().Trim() : rbtn_44.SelectedItem.Value;
                par[5] = new SqlParameter("@hdt45", SqlDbType.NVarChar, 50);   par[5].Value = CharText2.TextValue;
                par[6] = new SqlParameter("@hdt46", SqlDbType.NVarChar, 50);   par[6].Value = CharText3.TextValue;
                par[7] = new SqlParameter("@hdt47", SqlDbType.Date);           par[7].Value = IsDate(txt_date1.Text.ToString().Trim());
                par[8] = new SqlParameter("@hdt48", SqlDbType.NVarChar, 50);   par[8].Value = CharText5.TextValue;
                par[9] = new SqlParameter("@hdt49", SqlDbType.Int);            par[9].Value = isInt(CharText6.TextValue);
                par[10] = new SqlParameter("@hdt50", SqlDbType.NVarChar, 100); par[10].Value = CharText7.TextValue;
                par[11] = new SqlParameter("@hdt51", SqlDbType.NVarChar, 50);  par[11].Value = CharText8.TextValue;
                par[12] = new SqlParameter("@hdt52", SqlDbType.NVarChar, 50);  par[12].Value = CharText9.TextValue;
                par[13] = new SqlParameter("@hdt53", SqlDbType.NVarChar, 50);  par[13].Value = CharText10.TextValue;
                par[14] = new SqlParameter("@hdt54", SqlDbType.Float);         par[14].Value = IsFloat(CharText11.TextValue.ToString().Trim());
                par[15] = new SqlParameter("@hdt55", SqlDbType.NVarChar, 50);  par[15].Value = CharText12.TextValue;
                par[16] = new SqlParameter("@hdt56", SqlDbType.Date);          par[16].Value = IsDate(txt_date2.Text.ToString().Trim());
                par[17] = new SqlParameter("@hdt57", SqlDbType.NVarChar, 50);  par[17].Value = rbtn_57.SelectedItem.Value;
                par[18] = new SqlParameter("@hdt58", SqlDbType.NVarChar, 50);  par[18].Value = rbtn_58.SelectedItem.Value;
                par[19] = new SqlParameter("@hdt59", SqlDbType.NVarChar, 50);  par[19].Value = CharText14.TextValue;
                par[20] = new SqlParameter("@hdt60", SqlDbType.NVarChar, 50);  par[20].Value = rbtn_60.SelectedItem.Value;
                par[21] = new SqlParameter("@hdt61", SqlDbType.NVarChar, 50);  par[21].Value = rbtn_61.SelectedIndex == 5 ? rbtn_61.SelectedItem.Value + ":" + txt_61.Text.ToString().Trim() : rbtn_61.SelectedItem.Value;
                par[22] = new SqlParameter("@htd62", SqlDbType.NVarChar, 50);  par[22].Value = rbtn_62.SelectedIndex == 6 ? rbtn_62.SelectedItem.Value + ":" + txt_62.Text.ToString().Trim() : rbtn_62.SelectedItem.Value;
                par[23] = new SqlParameter("@htd63", SqlDbType.NVarChar, 50);  par[23].Value = rbtn_63.SelectedIndex == 4 ? rbtn_63.SelectedItem.Value + ":" + txt_63.Text.ToString().Trim() : rbtn_63.SelectedItem.Value;
                par[24] = new SqlParameter("@htd64", SqlDbType.NVarChar, 50);  par[24].Value = rbtn_64.SelectedIndex == 5 ? rbtn_64.SelectedItem.Value + ":" + txt_64.Text.ToString().Trim() : rbtn_64.SelectedItem.Value;
                par[25] = new SqlParameter("@htd65", SqlDbType.NVarChar, 50);  par[25].Value = rbtn_65.SelectedItem.Value;
                par[26] = new SqlParameter("@htd66", SqlDbType.NVarChar, 80);  par[26].Value = CharText15.TextValue;
                par[27] = new SqlParameter("@htd67", SqlDbType.NVarChar, 50);  par[27].Value = rbtn_67.SelectedItem.Value;
                #endregion
            }
            else
            {
                //把参数全都设置为空
                #region 给参数提供数字
                par[0] = new SqlParameter("@drugid", SqlDbType.Int); par[0].Value = idrugid;
                par[1] = new SqlParameter("@hdt41", SqlDbType.NVarChar, 10); par[1].Value = rbtn_41.SelectedItem.Value;
                par[2] = new SqlParameter("@hdt42", SqlDbType.NVarChar, 40); par[2].Value = ""; 
                par[3] = new SqlParameter("@hdt43", SqlDbType.NVarChar, 50); par[3].Value = "";
                par[4] = new SqlParameter("@hdt44", SqlDbType.NVarChar, 50); par[4].Value = "";
                par[5] = new SqlParameter("@hdt45", SqlDbType.NVarChar, 50); par[5].Value = "";
                par[6] = new SqlParameter("@hdt46", SqlDbType.NVarChar, 50); par[6].Value = "";
                par[7] = new SqlParameter("@hdt47", SqlDbType.Date);         par[7].Value = DateTime.Now.ToShortDateString();
                par[8] = new SqlParameter("@hdt48", SqlDbType.NVarChar, 50); par[8].Value = "";
                par[9] = new SqlParameter("@hdt49", SqlDbType.Int);          par[9].Value = 0;
                par[10] = new SqlParameter("@hdt50", SqlDbType.NVarChar, 100); par[10].Value = "";
                par[11] = new SqlParameter("@hdt51", SqlDbType.NVarChar, 50); par[11].Value = "";
                par[12] = new SqlParameter("@hdt52", SqlDbType.NVarChar, 50); par[12].Value = "";
                par[13] = new SqlParameter("@hdt53", SqlDbType.NVarChar, 50); par[13].Value = "";
                par[14] = new SqlParameter("@hdt54", SqlDbType.Float);        par[14].Value = 0;
                par[15] = new SqlParameter("@hdt55", SqlDbType.NVarChar, 50); par[15].Value = "";
                par[16] = new SqlParameter("@hdt56", SqlDbType.Date);         par[16].Value = DateTime.Now.ToShortDateString();
                par[17] = new SqlParameter("@hdt57", SqlDbType.NVarChar, 50); par[17].Value = "";
                par[18] = new SqlParameter("@hdt58", SqlDbType.NVarChar, 50); par[18].Value = "";
                par[19] = new SqlParameter("@hdt59", SqlDbType.NVarChar, 50); par[19].Value = "";
                par[20] = new SqlParameter("@hdt60", SqlDbType.NVarChar, 50); par[20].Value = "";
                par[21] = new SqlParameter("@hdt61", SqlDbType.NVarChar, 50); par[21].Value = "";
                par[22] = new SqlParameter("@htd62", SqlDbType.NVarChar, 50); par[22].Value = "";
                par[23] = new SqlParameter("@htd63", SqlDbType.NVarChar, 50); par[23].Value = "";
                par[24] = new SqlParameter("@htd64", SqlDbType.NVarChar, 50); par[24].Value = "";
                par[25] = new SqlParameter("@htd65", SqlDbType.NVarChar, 50); par[25].Value = "";
                par[26] = new SqlParameter("@htd66", SqlDbType.NVarChar, 80); par[26].Value = "";
                par[27] = new SqlParameter("@htd67", SqlDbType.NVarChar, 50); par[27].Value = "";
                #endregion
                
            }
            cHeredity chd = new cHeredity();
            int ghdid = -10;
            try
            {
                val = chd.ModiHeredity(InsertCommand, par);
                ghdid = chd.GetHdid(idrugid.ToString());
                hid_hdid.Value = ghdid.ToString();
            }
            catch
            { }


            return val;
         }
        protected int ExcuteUpdate(int hdid)
         {
             int val = -10;
             string UpdateCommand = "UPDATE [Heredity] SET [drugid] = @drugid, [hdt41] = @hdt41, [hdt42] = @hdt42, [hdt43] = @hdt43, [hdt44] = @hdt44, [hdt45] = @hdt45, [hdt46] = @hdt46, [hdt47] = @hdt47, [hdt48] = @hdt48, [hdt49] = @hdt49, [hdt50] = @hdt50, [hdt51] = @hdt51, [hdt52] = @hdt52, [hdt53] = @hdt53, [hdt54] = @hdt54, [hdt55] = @hdt55, [hdt56] = @hdt56, [hdt57] = @hdt57, [hdt58] = @hdt58, [hdt59] = @hdt59, [hdt60] = @hdt60, [hdt61] = @hdt61, [htd62] = @htd62, [htd63] = @htd63, [htd64] = @htd64, [htd65] = @htd65, [htd66] = @htd66, [htd67] = @htd67 WHERE [hdid] = @hdid";

             SqlParameter[] par = new SqlParameter[29];
             if (Session["drugid"] == null)
             {
                 Response.Redirect("../Admin/AdWeb/APassport.aspx");
                 return 0;
             }
             if (rbtn_41.SelectedIndex == 0)
             {
                 #region 插入数据               
               
                 par[0] = new SqlParameter("@drugid", SqlDbType.Int); par[0].Value = Convert.ToInt32(hid_drugid.Value);
                 par[1] = new SqlParameter("@hdt41", SqlDbType.NVarChar, 10); par[1].Value = rbtn_41.SelectedItem.Value;
                 par[2] = new SqlParameter("@hdt42", SqlDbType.NVarChar, 40); par[2].Value = CharText1.TextValue;
                 par[3] = new SqlParameter("@hdt43", SqlDbType.NVarChar, 50); par[3].Value = rbtn_43.SelectedItem.Value;
                 par[4] = new SqlParameter("@hdt44", SqlDbType.NVarChar, 50); par[4].Value = rbtn_44.SelectedIndex == 4 ? rbtn_44.SelectedItem.Value + ":" + txt_44.Text.ToString().Trim() : rbtn_44.SelectedItem.Value;
                 par[5] = new SqlParameter("@hdt45", SqlDbType.NVarChar, 50); par[5].Value = CharText2.TextValue;
                 par[6] = new SqlParameter("@hdt46", SqlDbType.NVarChar, 50); par[6].Value = CharText3.TextValue;
                 par[7] = new SqlParameter("@hdt47", SqlDbType.Date);         par[7].Value = IsDate(txt_date1.Text.ToString().Trim());
                 par[8] = new SqlParameter("@hdt48", SqlDbType.NVarChar, 50); par[8].Value = CharText5.TextValue;
                 par[9] = new SqlParameter("@hdt49", SqlDbType.Int);          par[9].Value = isInt(CharText6.TextValue);
                 par[10] = new SqlParameter("@hdt50", SqlDbType.NVarChar, 100); par[10].Value = CharText7.TextValue;
                 par[11] = new SqlParameter("@hdt51", SqlDbType.NVarChar, 50); par[11].Value = CharText8.TextValue;
                 par[12] = new SqlParameter("@hdt52", SqlDbType.NVarChar, 50); par[12].Value = CharText9.TextValue;
                 par[13] = new SqlParameter("@hdt53", SqlDbType.NVarChar, 50); par[13].Value = CharText10.TextValue;
                 par[14] = new SqlParameter("@hdt54", SqlDbType.Float);        par[14].Value = IsFloat(CharText11.TextValue.ToString().Trim());
                 par[15] = new SqlParameter("@hdt55", SqlDbType.NVarChar, 50); par[15].Value = CharText12.TextValue;
                 par[16] = new SqlParameter("@hdt56", SqlDbType.Date);         par[16].Value = IsDate(txt_date2.Text.ToString().Trim());
                 par[17] = new SqlParameter("@hdt57", SqlDbType.NVarChar, 50); par[17].Value = rbtn_57.SelectedItem.Value;
                 par[18] = new SqlParameter("@hdt58", SqlDbType.NVarChar, 50); par[18].Value = rbtn_58.SelectedItem.Value;
                 par[19] = new SqlParameter("@hdt59", SqlDbType.NVarChar, 50); par[19].Value = CharText14.TextValue;
                 par[20] = new SqlParameter("@hdt60", SqlDbType.NVarChar, 50); par[20].Value = rbtn_60.SelectedItem.Value;
                 par[21] = new SqlParameter("@hdt61", SqlDbType.NVarChar, 50); par[21].Value = rbtn_61.SelectedIndex == 5 ? rbtn_61.SelectedItem.Value + ":" + txt_61.Text.ToString().Trim() : rbtn_61.SelectedItem.Value;
                 par[22] = new SqlParameter("@htd62", SqlDbType.NVarChar, 50); par[22].Value = rbtn_62.SelectedIndex == 6 ? rbtn_62.SelectedItem.Value + ":" + txt_62.Text.ToString().Trim() : rbtn_62.SelectedItem.Value;
                 par[23] = new SqlParameter("@htd63", SqlDbType.NVarChar, 50); par[23].Value = rbtn_63.SelectedIndex == 4 ? rbtn_63.SelectedItem.Value + ":" + txt_63.Text.ToString().Trim() : rbtn_63.SelectedItem.Value;
                 par[24] = new SqlParameter("@htd64", SqlDbType.NVarChar, 50); par[24].Value = rbtn_64.SelectedIndex == 5 ? rbtn_64.SelectedItem.Value + ":" + txt_64.Text.ToString().Trim() : rbtn_64.SelectedItem.Value;
                 par[25] = new SqlParameter("@htd65", SqlDbType.NVarChar, 50); par[25].Value = rbtn_65.SelectedItem.Value;
                 par[26] = new SqlParameter("@htd66", SqlDbType.NVarChar, 80); par[26].Value = CharText15.TextValue;
                 par[27] = new SqlParameter("@htd67", SqlDbType.NVarChar, 50); par[27].Value = rbtn_67.SelectedItem.Value;
                 par[28] = new SqlParameter("@hdid", SqlDbType.Int);           par[28].Value = hdid;
                 #endregion
             }
             else
             {
                 //把参数全都设置为空
                 #region 给参数提供数字
                 par[0] = new SqlParameter("@drugid", SqlDbType.Int);         par[0].Value = Convert.ToInt32(hid_drugid.Value);
                 par[1] = new SqlParameter("@hdt41", SqlDbType.NVarChar, 10); par[1].Value = rbtn_41.SelectedItem.Value;
                 par[2] = new SqlParameter("@hdt42", SqlDbType.NVarChar, 40); par[2].Value = "";
                 par[3] = new SqlParameter("@hdt43", SqlDbType.NVarChar, 50); par[3].Value = "";
                 par[4] = new SqlParameter("@hdt44", SqlDbType.NVarChar, 50); par[4].Value = "";
                 par[5] = new SqlParameter("@hdt45", SqlDbType.NVarChar, 50); par[5].Value = "";
                 par[6] = new SqlParameter("@hdt46", SqlDbType.NVarChar, 50); par[6].Value = "";
                 par[7] = new SqlParameter("@hdt47", SqlDbType.Date);         par[7].Value = DateTime.Now.ToShortDateString();
                 par[8] = new SqlParameter("@hdt48", SqlDbType.NVarChar, 50); par[8].Value = "";
                 par[9] = new SqlParameter("@hdt49", SqlDbType.Int);          par[9].Value = 0;
                 par[10] = new SqlParameter("@hdt50", SqlDbType.NVarChar, 100); par[10].Value = "";
                 par[11] = new SqlParameter("@hdt51", SqlDbType.NVarChar, 50); par[11].Value = "";
                 par[12] = new SqlParameter("@hdt52", SqlDbType.NVarChar, 50); par[12].Value = "";
                 par[13] = new SqlParameter("@hdt53", SqlDbType.NVarChar, 50); par[13].Value = "";
                 par[14] = new SqlParameter("@hdt54", SqlDbType.Float);        par[14].Value = 0;
                 par[15] = new SqlParameter("@hdt55", SqlDbType.NVarChar, 50); par[15].Value = "";
                 par[16] = new SqlParameter("@hdt56", SqlDbType.Date);         par[16].Value = DateTime.Now.ToShortDateString();
                 par[17] = new SqlParameter("@hdt57", SqlDbType.NVarChar, 50); par[17].Value = "";
                 par[18] = new SqlParameter("@hdt58", SqlDbType.NVarChar, 50); par[18].Value = "";
                 par[19] = new SqlParameter("@hdt59", SqlDbType.NVarChar, 50); par[19].Value = "";
                 par[20] = new SqlParameter("@hdt60", SqlDbType.NVarChar, 50); par[20].Value = "";
                 par[21] = new SqlParameter("@hdt61", SqlDbType.NVarChar, 50); par[21].Value = "";
                 par[22] = new SqlParameter("@htd62", SqlDbType.NVarChar, 50); par[22].Value = "";
                 par[23] = new SqlParameter("@htd63", SqlDbType.NVarChar, 50); par[23].Value = "";
                 par[24] = new SqlParameter("@htd64", SqlDbType.NVarChar, 50); par[24].Value = "";
                 par[25] = new SqlParameter("@htd65", SqlDbType.NVarChar, 50); par[25].Value = "";
                 par[26] = new SqlParameter("@htd66", SqlDbType.NVarChar, 80); par[26].Value = "";
                 par[27] = new SqlParameter("@htd67", SqlDbType.NVarChar, 50); par[27].Value = "";
                 par[28] = new SqlParameter("@hdid", SqlDbType.Int);           par[28].Value = hdid;
                 #endregion
                
             }
             cHeredity chd = new cHeredity();            
             try
             {
                 val = chd.ModiHeredity(UpdateCommand, par);                
             }
             catch
             { }
             return val;
         }
        protected float IsFloat(string sfloat)
         {
             float fa = 0;
             try
             {
                 fa = Convert.ToSingle(sfloat);
             }
             catch
             {
                 fa = 0;
             }
             return fa;
         }
        protected int isInt(string sint)
         {
             int a = 0;
             try
             {
                 a = Convert.ToInt32(sint);
             }
             catch
             {
                 a = 0;
             }
             return a;
         }
        protected DateTime IsDate(string sDate)
         {
             DateTime dt;
             try
             {
                 dt = Convert.ToDateTime(sDate);
             }
             catch
             {
                 dt = Convert.ToDateTime("1900-01-01");
             }
             return dt;
         }
        protected string toShortDate(string str)
        {
            string sdt = "1900-01-01";
            try
            {
                DateTime dt = Convert.ToDateTime(str);
                sdt = dt.ToShortDateString();
            }
            catch
            { }
            return sdt;
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            int insertCount7 = 0;
            if (Session[insertCountN] != null)
            {
                insertCount7 = Convert.ToInt32(Session[insertCountN].ToString());
            }
            else
                insertCount7 = 0;

            if (insertCount7 == 0)
            {//插入操作并且是首次插入
                if (ExcuteInsert() == 1)
                {
                    insertCount7++;
                    Session[insertCountN] = insertCount7;
                    Script.AjaxAlert(btn_save, "恭喜您，添加【种质资源】信息成功！");
                }
            }
            else if (insertCount7 != 0)
            {
                //更新操作
                int ihdid = Convert.ToInt32(hid_hdid.Value.ToString().Trim());
                if (ExcuteUpdate(ihdid) == 1)
                    Script.AjaxAlert(btn_save, "恭喜您，保存【种质资源】信息成功！");
            }
            else
            {
                Script.AjaxAlert(btn_save, "对不起，保存【种质资源】信息失败！");
            }

            //绑定GV
            string drugid = hid_drugid.Value;
            DataBindText(drugid);

        }

        protected void btn_back7_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AdWeb/AReference.aspx");
        }

        protected void btn_next7_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AdWeb/ASourceImage.aspx");
        }

        protected void rbtn_44_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtn_44.SelectedIndex == 4)
                txt_44.Enabled = true;
            else
                txt_44.Enabled = false;
        }

        protected void rbtn_61_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtn_61.SelectedIndex == 5)
                txt_61.Enabled = true;
            else
                txt_61.Enabled = false;
        }

        protected void rbtn_62_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtn_62.SelectedIndex == 6)
                txt_62.Enabled = true;
            else
                txt_62.Enabled = false;
        }

        protected void rbtn_63_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtn_63.SelectedIndex == 4)
                txt_63.Enabled = true;
            else
                txt_63.Enabled = false;
        }

        protected void rbtn_64_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtn_64.SelectedIndex == 5)
                txt_64.Enabled = true;
            else
                txt_64.Enabled = false;
        }

        protected void txt_date1_Init(object sender, EventArgs e)
        {
            txt_date1.Attributes["onfocus"] = "javascript:WdatePicker({isShowWeek:true});";
        }

        protected void txt_date2_Init(object sender, EventArgs e)
        {
            txt_date2.Attributes["onfocus"] = "javascript:WdatePicker({isShowWeek:true});";
        }

        protected void rbtn_41_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtn_41.SelectedIndex == 0)
            {
                //说明有种质资源其他的控件都是可用的。
                //需要改
                btn_save.ValidationGroup = "T";
                RequiredFieldValidator1.ValidationGroup = "T";
                RequiredFieldValidator2.ValidationGroup = "T";
                RequiredFieldValidator3.ValidationGroup = "T";
                RequiredFieldValidator4.ValidationGroup = "T";
                RequiredFieldValidator5.ValidationGroup = "T";
                RequiredFieldValidator6.ValidationGroup = "T";
                RequiredFieldValidator7.ValidationGroup = "T";
                RequiredFieldValidator8.ValidationGroup = "T";
                RequiredFieldValidator9.ValidationGroup = "T";
                RequiredFieldValidator10.ValidationGroup = "T";
                RequiredFieldValidator11.ValidationGroup = "T";
                RequiredFieldValidator12.ValidationGroup = "T";
               
            }
            else if (rbtn_41.SelectedIndex == 1)
            {
                //说明没有种质资源，其他控件不可用。
                RequiredFieldValidator1.ValidationGroup = "F";
                RequiredFieldValidator2.ValidationGroup = "F";
                RequiredFieldValidator3.ValidationGroup = "F";
                RequiredFieldValidator4.ValidationGroup = "F";
                RequiredFieldValidator5.ValidationGroup = "F";
                RequiredFieldValidator6.ValidationGroup = "F";
                RequiredFieldValidator7.ValidationGroup = "F";
                RequiredFieldValidator8.ValidationGroup = "F";
                RequiredFieldValidator9.ValidationGroup = "F";
                RequiredFieldValidator10.ValidationGroup = "F";
                RequiredFieldValidator11.ValidationGroup = "F";
                RequiredFieldValidator12.ValidationGroup = "F";
            }

        }
    }
}