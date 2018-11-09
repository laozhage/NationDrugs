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
    public partial class UcUserNew : System.Web.UI.UserControl
    {
        protected void Page_Disposed(object sender, EventArgs e)
        {
            //销毁这个页面时候要把Session["insertCount"]
            if (Session["insertCountUser"] != null)
                Session.Remove("insertCountUser");
            if (Session["UserGUID"] != null)
                Session.Remove("UserGUID");

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserTitleName"] != null)
            {
                lbl_titleName.Text = Session["UserTitleName"].ToString();
            }
            else
                lbl_titleName.Text = "添加新用户";
            if (Session["userinfor"] != null)
            {
                cUserInfor uinfor = (cUserInfor)(Session["userinfor"]);
                string Groupid = uinfor.Groupid.ToString().Trim();
                Session["SelectGroupid"] = Groupid;
            }
            else
            {
                Response.Redirect("../../../Log/logout.ashx");
            }
            
               
            DataBindGV();
        }
        protected void DataBindGV()
        {
            cUser cuser = new cUser();
            int Groupid = 0;
            if (Session["userinfor"] != null)
            {
                cUserInfor uinfor = (cUserInfor)(Session["userinfor"]);
                Groupid = uinfor.Groupid;
            }
            else
            {
                Response.Redirect("../../../Log/logout.ashx");
            }
            try
            {
                DataTable dt = cuser.GetUserDtByGroupid(Groupid);
                gv.DataSource = dt;
                gv.DataBind();
            }
            catch
            { }
        }
        protected void DataBindText(string userid)
        {
            cUser cuser = new cUser();
            try
            {
                DataTable dt = cuser.GetUserDatatable(userid);
                DataTable dtRight = cuser.GetUserRight(userid);  
            
                 RadioButtonList1.SelectedIndex = -1;
                 RadioButtonList2.SelectedIndex = -1;

                if (dt.Rows.Count > 0)
                {
                    Session["insertCountUser"] = 1;
                    Ulable1.TextValue = userid;
                    txt_tname.TextValue = dt.Rows[0]["truename"].ToString().Trim();
                    txt_pass.Text = "";
                    DropDownList1.SelectedIndex = charTodii(dt.Rows[0]["Groupid"].ToString().Trim());
                    txt_stDate.Text = toShortDate(dt.Rows[0]["tcreat"].ToString().Trim());
                    txt_endDate.Text = toShortDate(dt.Rows[0]["tdeadline"].ToString().Trim());
                    RadioButtonList1.SelectedIndex = dt.Rows[0]["bfunc"].ToString().Trim() == "True" ? 0 : 1;
                    RadioButtonList2.SelectedIndex = dt.Rows[0]["bdel"].ToString().Trim() == "True" ? 0 : 1;

                    if (dtRight.Rows.Count > 0)
                    {
                        check_right.SelectedIndex = -1;
                        for (int i = 0; i < dtRight.Rows.Count; i++)
                        {
                            int rightid = charTodi(dtRight.Rows[i]["ParentMenuValue"].ToString().Trim());
                            check_right.Items[rightid].Selected = true;
                        }
                    }
                    else
                    {
                        check_right.SelectedIndex = -1;
                    }
                    
                }
            }
            catch
            { }
        }
        protected int charTodii(string str)
        {
            int re = -1;
            try
            {
                char[] ch = str.ToCharArray(0, 1);
                re = ch[0] - '1';
            }
            catch
            { }
            return re;
        }
        protected int charTodi(string str)
        {
            int re = -1;
            try
            {
                char[] ch = str.ToCharArray(2, 1);
                re = ch[0] - '1';
            }
            catch
            { }
            return re;
        }
        protected void btn_new_Click(object sender, EventArgs e)
        {
            Session["insertCountUser"] = "0";
            Ulable1.TextValue = "";
            txt_tname.TextValue = "";
            DropDownList1.SelectedIndex = 0;
            txt_stDate.Text = "";
            txt_endDate.Text = "";
            RadioButtonList1.SelectedIndex = 0;
            RadioButtonList2.SelectedIndex = 0;
            check_right.SelectedIndex = -1;
                    
        }
        public int ExcuteUpdate(int iuserid)
        {
            int val = -10;
            string UpdateCommand = "UPDATE [smUser] SET [Groupid] = @Groupid,  [truename] = @truename, [pwd] = @pwd, [tcreat] = @tcreat, [tdeadline] = @tdeadline, [bfunc] = @bfunc, [bdel] = @bdel WHERE [userid] = @userid";
            SqlParameter[] par = new SqlParameter[8];
            try
            {
                par[0] = new SqlParameter("@Groupid", SqlDbType.Int);           par[0].Value = Convert.ToInt32(DropDownList1.SelectedItem.Value.ToString().Trim());
                par[1] = new SqlParameter("@truename", SqlDbType.NVarChar, 400); par[1].Value = txt_tname.TextValue;
                par[2] = new SqlParameter("@pwd", SqlDbType.NVarChar, 40);      par[2].Value = Entry.EncryptByMd5(txt_pass.Text.ToString().Trim());
                par[3] = new SqlParameter("@tcreat", SqlDbType.Date);           par[3].Value = IsDate(txt_stDate.Text.ToString().Trim());
                par[4] = new SqlParameter("@tdeadline", SqlDbType.Date);        par[4].Value = IsDate(txt_endDate.Text.ToString().Trim());
                par[5] = new SqlParameter("@bfunc", SqlDbType.Bit);             par[5].Value = Convert.ToByte(RadioButtonList1.SelectedItem.Value);
                par[6] = new SqlParameter("@bdel", SqlDbType.Bit);              par[6].Value = Convert.ToByte(RadioButtonList2.SelectedItem.Value);
                par[7] = new SqlParameter("@userid", SqlDbType.Int);            par[7].Value = iuserid;         
                cUser cuser = new cUser();

                //----------------------------------
                SqlConnection con = SqlHelper.GetConnection();
                SqlTransaction trans = null;
                SqlCommand cmd = new SqlCommand();                
                try
                {                    
                    trans = con.BeginTransaction();
                    cmd.Connection = con;
                    cmd.Transaction = trans;
                    //1、更新操作用户各种信息
                    cmd.CommandText = UpdateCommand;
                    foreach (SqlParameter parm in par)
                    {
                        cmd.Parameters.Add(parm);
                    }                    
                    cmd.ExecuteNonQuery();
                    //2、删除用户的权限
                    string DeleteCommand =  "DELETE FROM [smUserRoles] WHERE [userid] = " + iuserid;
                    cmd.CommandText = DeleteCommand;                    
                    cmd.ExecuteNonQuery();
                    //3、插入用户的权限
                    //插入
                    for (int i = 0; i < check_right.Items.Count; i++)
                    {
                        if (check_right.Items[i].Selected)
                        {
                            string  InsertCommand = "INSERT INTO [smUserRoles] ([userid], [ParentMenuValue]) VALUES  ( " + iuserid + "," + check_right.Items[i].Value + ")";
                            cmd.CommandText = InsertCommand;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    trans.Commit();
                    val = 1;
                }
                catch
                {                   
                    trans.Rollback();
                    throw;
                }
                finally
                {
                    con.Close();
                }
                //-----------------------------------
                #region 可以使用的代码，但是有漏洞的代码，换成能上面完成并发的代码        
                 //try
                //{
                //    val = cuser.ModiUser(UpdateCommand, par);
                //    //更新权限会很麻烦的，可以考虑,方法一、先删除后插入的方法
                //    SqlDataSource srcUser = new SqlDataSource();
                //    srcUser.ConnectionString = SqlHelper.GetConnection().ConnectionString;
                //    //删除
                //    srcUser.DeleteCommand = "DELETE FROM [smUserRoles] WHERE [userid] = " + iuserid;                   
                //    srcUser.Delete();
                //    //插入
                //    for (int i = 0; i < check_right.Items.Count; i++)
                //    {
                //        if (check_right.Items[i].Selected)
                //        {
                //            srcUser.InsertCommand = "INSERT INTO [smUserRoles] ([userid], [ParentMenuValue]) VALUES  ( " + iuserid + "," + check_right.Items[i].Value + ")";
                //            srcUser.Insert();
                //        }
                //    }

                //}
                //catch { }
                #endregion
            }
            catch
            { }


            return val;
        }
        protected int ExcuteInsert()
        {
            int val = -10;
            string InsertCommand = "INSERT INTO [smUser] ([Groupid], [username], [truename], [pwd], [tcreat], [tdeadline], [bfunc], [bdel]) VALUES (@Groupid, @username, @truename, @pwd, @tcreat, @tdeadline, @bfunc, @bdel)";
            SqlParameter[] par = new SqlParameter[8];
            //生成一个唯一的标识存放在用户表用来区分该条记录
            string UserGUID = System.Guid.NewGuid().ToString();            
            try
            {
                par[0] = new SqlParameter("@Groupid", SqlDbType.Int); par[0].Value = Convert.ToInt32(DropDownList1.SelectedItem.Value.ToString().Trim());
                par[1] = new SqlParameter("@username", SqlDbType.NVarChar, 400); par[1].Value = UserGUID;
                par[2] = new SqlParameter("@truename", SqlDbType.NVarChar, 400); par[2].Value = txt_tname.TextValue;
                par[3] = new SqlParameter("@pwd", SqlDbType.NVarChar, 40); par[3].Value = Entry.EncryptByMd5(txt_pass.Text.ToString().Trim());
                par[4] = new SqlParameter("@tcreat", SqlDbType.Date); par[4].Value = IsDate(txt_stDate.Text.ToString().Trim());
                par[5] = new SqlParameter("@tdeadline", SqlDbType.Date); par[5].Value = IsDate(txt_endDate.Text.ToString().Trim());
                par[6] = new SqlParameter("@bfunc", SqlDbType.Bit); par[6].Value = Convert.ToByte(RadioButtonList1.SelectedItem.Value);
                par[7] = new SqlParameter("@bdel", SqlDbType.Bit); par[7].Value = Convert.ToByte(RadioButtonList2.SelectedItem.Value);
                cUser cuser = new cUser();

               
                
               
                
                //插入用户的权限存在风险再循环过程中出现问题就比较麻烦了。
                
               
                #region  一种老的插入方法
                ////----------------------------------------------------
                SqlDataSource srcUser = new SqlDataSource();
                srcUser.ConnectionString = SqlHelper.GetConnection().ConnectionString;
                try
                {
                    //插入用户信息表
                    val = cuser.ModiUser(InsertCommand, par);
                    Session["UserGUID"] = UserGUID;
                    //插入用户的权限存在风险再循环过程中出现问题就比较麻烦了。
                    int iiuserid = cUser.GetUserID(UserGUID);
                    //---------------
                    int checkCount = 0;
                    for (int i = 0; i < check_right.Items.Count; i++)
                    {
                        if (check_right.Items[i].Selected)
                        {
                            checkCount++;
                        }
                    }
                    ParmObject[] pobj = new ParmObject[checkCount];
                    for (int i = 0; i < pobj.Length; i++)
                    {
                        pobj[i] = new ParmObject();
                        pobj[i].Cmdtext = "INSERT INTO [smUserRoles] ([userid], [ParentMenuValue]) VALUES  ( " + iiuserid + "," + check_right.Items[i].Value + ")";
                        pobj[i].Par = null;
                    }
                    val = SqlHelper.ExecuteNonQueryByTrans(pobj);

                    //-----------------

                    //for (int i = 0; i < check_right.Items.Count; i++)
                    //{
                    //    if (check_right.Items[i].Selected)
                    //    {
                    //        srcUser.InsertCommand = "INSERT INTO [smUserRoles] ([userid], [ParentMenuValue]) VALUES  ( " + iiuserid + "," + check_right.Items[i].Value + ")";
                    //        srcUser.Insert();
                    //    }
                    //}


                }
                catch
                { }
                //----------------------------------------------------
                #endregion


            }
            catch
            { }

            return val;
       
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
        protected void txt_stDate_Init(object sender, EventArgs e)
        {
            txt_stDate.Attributes["onfocus"] = "javascript:WdatePicker({isShowWeek:true});";     
        }
        protected void txt_endDate_Init(object sender, EventArgs e)
        {
            txt_endDate.Attributes["onfocus"] = "javascript:WdatePicker({isShowWeek:true});";     
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            int insertCountUser = 0;
            if (Session["insertCountUser"] != null)
            {
                insertCountUser = Convert.ToInt32(Session["insertCountUser"].ToString());
            }
            else
                insertCountUser = 0;

            //保存数据
            if (insertCountUser == 0)
            {//插入操作并且是首次插入
                if (ExcuteInsert() == 1)
                {
                    insertCountUser++;
                    Session["insertCountUser"] = insertCountUser;
                    string getGUID = Session["UserGUID"].ToString();
                    hid_userid.Value = cUser.GetUserID(getGUID).ToString();
                    Script.AjaxAlert(btn_new, "恭喜您，添加新用户成功！");
                }

            }
            else if (insertCountUser != 0)
            {
                int iuserid = Convert.ToInt32(hid_userid.Value.ToString().Trim());
                if (ExcuteUpdate(iuserid) == 1)
                    Script.AjaxAlert(btn_new, "恭喜您，更新用户信息成功！");
            }
            else
            {
                Script.AjaxAlert(btn_new, "对不起，保存用户信息失败！"); ;
                return;
            }
            int useriddd = Convert.ToInt32(hid_userid.Value);
            DataBindText(useriddd.ToString());
            DataBindGV();
        }

        protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int useriddd = Convert.ToInt32(hid_userid.Value);
            DataBindText(useriddd.ToString());
            DataBindGV();

            gv.PageIndex = e.NewPageIndex;
            gv.DataBind();
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {           
            if (e.CommandName == "detail")
            {
                int iuserid = Convert.ToInt32(e.CommandArgument.ToString().Trim());
                hid_userid.Value = iuserid.ToString();
                Session["userid"] = iuserid;
                //-------------------------------------
                string selectString = "select * from smUser where userid = " + iuserid;
                SqlDataReader sda = SqlHelper.ExecuteReader(selectString);
                if (sda.HasRows)
                {
                    //sda.Read();//= sda[""].ToString();
                    //Ulable1.TextValue = sda["userid"].ToString();
                    //txt_tname.TextValue = sda["truename"].ToString();
                    //DropDownList1.SelectedIndex = charTodi(sda["Groupid"].ToString());
                    //txt_stDate.Text = toShortDate(sda["tcreat"].ToString());
                    //txt_endDate.Text = toShortDate(sda["tdeadline"].ToString());
                    //RadioButtonList1.SelectedIndex = charTodi(sda["bfunc"].ToString());
                    //RadioButtonList2.SelectedIndex = charTodi(sda["bdel"].ToString());
                    Session["insertCountUser"] = "1";
                    DataBindText(iuserid.ToString());
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

        }
    }
}