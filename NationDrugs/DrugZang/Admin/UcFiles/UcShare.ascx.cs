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
    public partial class UcShare : System.Web.UI.UserControl
    {
        private const string insertCountN = "insertCount9";
        protected void Page_Disposed(object sender, EventArgs e)
        {
            //销毁这个页面时候要把Session["insertCount4"]
            if (Session[insertCountN] != null)
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
                    //绑定

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
            cShared cshare = new cShared();
            try
            {
                DataTable dt = cshare.GetShareTable(drugid);
                if (dt.Rows.Count > 0)
                {
                    Session[insertCountN] = 1;
                    hid_drugid.Value = drugid;
                    hid_shareid.Value = dt.Rows[0]["shid"].ToString().Trim();
                    
                    string shareway = dt.Rows[0]["ishareway"].ToString().Trim();
                    string[] sway = shareway.Split(new Char[] { ','});
                    for (int i = 0; i < sway.Length; i++)
                    {
                        try
                        {
                            int iselect = Convert.ToInt32(sway[i]);
                            CheckBoxList1.Items[iselect -1].Selected = true;
                        }
                        catch
                        { }
                    }

                    string rbtlist = dt.Rows[0]["iobtainway"].ToString().Trim();
                    RadioButtonList1.SelectedIndex = charTodiStr(rbtlist, ref txt_73);

                    TextBox1.Text = dt.Rows[0]["man"].ToString().Trim();
                    TextBox2.Text = dt.Rows[0]["depart"].ToString().Trim();
                    TextBox3.Text = dt.Rows[0]["mcode"].ToString().Trim();
                    TextBox4.Text = dt.Rows[0]["tel"].ToString().Trim();
                    TextBox5.Text = dt.Rows[0]["email"].ToString().Trim();
                }
            }
            catch
            { }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == 3)
                txt_73.Enabled = true;
            else
                txt_73.Enabled = false;
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            int insertCount9 = 0;
            if (Session[insertCountN] != null)
            {
                insertCount9 = Convert.ToInt32(Session[insertCountN].ToString());
            }
            else
                insertCount9 = 0;

            if (insertCount9 == 0)
            {//插入操作并且是首次插入
                if (ExcuteInsert() == 1)
                {
                    insertCount9++;
                    Session[insertCountN] = insertCount9;
                    Script.AjaxAlert(btn_save, "恭喜您，添加【共享利用信息】信息成功！");
                }
            }
            else if (insertCount9 != 0)
            {
                //更新操作
                int ishareid = Convert.ToInt32(hid_shareid.Value.ToString().Trim());
                if (ExcuteUpdate(ishareid) == 1)
                    Script.AjaxAlert(btn_save, "恭喜您，保存【共享利用信息】信息成功！");
            }
            else
            {
                Script.AjaxAlert(btn_save, "对不起，保存【共享利用信息】信息失败！");
            }

            string drugid = hid_drugid.Value;
            DataBindText(drugid);



        }

        protected int ExcuteInsert()
        {
            int val = -10;
            string InsertCommand = "INSERT INTO [Share] ([drugid], [ishareway], [iobtainway], [man], [depart], [mcode], [tel], [email], [Sharebak1], [Sharebak2]) VALUES (@drugid, @ishareway, @iobtainway, @man, @depart, @mcode, @tel, @email, @Sharebak1, @Sharebak2)";
            SqlParameter[] par = new SqlParameter[10];
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
            par[0] = new SqlParameter("@drugid", SqlDbType.Int);              par[0].Value = idrugid;
            string shareWay = "";
            foreach (ListItem li in CheckBoxList1.Items)
                if (li.Selected)
                    shareWay += li.Value+",";
            if(shareWay.Length >0) 
                shareWay = shareWay.Substring(0,shareWay.Length -1);
            par[1] = new SqlParameter("@ishareway", SqlDbType.NVarChar, 40);   par[1].Value = shareWay;
            par[2] = new SqlParameter("@iobtainway", SqlDbType.NVarChar, 400);  par[2].Value = RadioButtonList1.SelectedIndex == 3 ? RadioButtonList1.SelectedItem.Value + ":" + txt_73.Text.ToString() : RadioButtonList1.SelectedItem.Value;
            par[3] = new SqlParameter("@man", SqlDbType.NVarChar, 400);         par[3].Value = TextBox1.Text.ToString().Trim();
            par[4] = new SqlParameter("@depart", SqlDbType.NVarChar, 400);      par[4].Value = TextBox2.Text.ToString().Trim();
            par[5] = new SqlParameter("@mcode", SqlDbType.NVarChar, 40);       par[5].Value = TextBox3.Text.ToString().Trim();
            par[6] = new SqlParameter("@tel", SqlDbType.NVarChar, 40);         par[6].Value = TextBox4.Text.ToString().Trim();
            par[7] = new SqlParameter("@email", SqlDbType.NVarChar, 40);       par[7].Value = TextBox5.Text.ToString().Trim();
            par[8] = new SqlParameter("@Sharebak1", SqlDbType.NVarChar, 100);  par[8].Value ="";
            par[9] = new SqlParameter("@Sharebak2", SqlDbType.NVarChar, 40);   par[9].Value = "";

            cShared cshar = new cShared();
            int gshareid = -10;
            try
            {
                val = cshar.ModiShared(InsertCommand, par);
                gshareid = cshar.GetShareid(idrugid.ToString());
                hid_shareid.Value = gshareid.ToString() ;
            }
            catch
            { }
            return val;
        }
        protected int ExcuteUpdate(int shareid)
        {
            int val = -10;
            string UpdateCommand = "UPDATE [Share] SET [drugid] = @drugid, [ishareway] = @ishareway, [iobtainway] = @iobtainway, [man] = @man, [depart] = @depart, [mcode] = @mcode, [tel] = @tel, [email] = @email, [Sharebak1] = @Sharebak1, [Sharebak2] = @Sharebak2 WHERE [shid] = @shid";
            SqlParameter[] par = new SqlParameter[11];
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
            string shareWay = "";
            foreach (ListItem li in CheckBoxList1.Items)
                if (li.Selected)
                    shareWay += li.Value + ",";
            if (shareWay.Length > 0)
                shareWay = shareWay.Substring(0, shareWay.Length - 1);
            par[1] = new SqlParameter("@ishareway", SqlDbType.NVarChar, 40); par[1].Value = shareWay;
            par[2] = new SqlParameter("@iobtainway", SqlDbType.NVarChar, 400); par[2].Value = RadioButtonList1.SelectedIndex == 3 ? RadioButtonList1.SelectedItem.Value + ":" + txt_73.Text.ToString() : RadioButtonList1.SelectedItem.Value;
            par[3] = new SqlParameter("@man", SqlDbType.NVarChar, 400); par[3].Value = TextBox1.Text.ToString().Trim();
            par[4] = new SqlParameter("@depart", SqlDbType.NVarChar, 400); par[4].Value = TextBox2.Text.ToString().Trim();
            par[5] = new SqlParameter("@mcode", SqlDbType.NVarChar, 40); par[5].Value = TextBox3.Text.ToString().Trim();
            par[6] = new SqlParameter("@tel", SqlDbType.NVarChar, 40); par[6].Value = TextBox4.Text.ToString().Trim();
            par[7] = new SqlParameter("@email", SqlDbType.NVarChar, 40); par[7].Value = TextBox5.Text.ToString().Trim();
            par[8] = new SqlParameter("@Sharebak1", SqlDbType.NVarChar, 100); par[8].Value = "";
            par[9] = new SqlParameter("@Sharebak2", SqlDbType.NVarChar, 40); par[9].Value = "";
            par[10] = new SqlParameter("@shid", SqlDbType.Int); par[10].Value = shareid;

            cShared cshar = new cShared();
            try
            {
                val = cshar.ModiShared(UpdateCommand, par);               
            }
            catch
            { }
            return val;           
        }

        protected void btn_back9_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AdWeb/ASourceImage.aspx");
        }

        protected void btn_next9_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../../Log/main.aspx");
        }


    }
}