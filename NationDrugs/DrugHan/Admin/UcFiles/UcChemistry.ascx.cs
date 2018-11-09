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
    public partial class UcChemistry : System.Web.UI.UserControl
    {
        private const string insertCountN = "insertCount4";
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
                if (Session["drugid"] != null && Session["rsid"] != null)
                {
                    drugid = Session["drugid"].ToString().Trim();
                    rsid = Session["rsid"].ToString().Trim();
                    cpassport cp = new cpassport();
                    drugName = cp.GetDrugName(drugid);
                    //把药材的名称绑定在中药名上
                    Ulable1.TextValue = drugName;
                    //绑定GV
                    hid_drugid.Value = drugid;
                    hid_rsid.Value = rsid;

                    DataBindText(drugid);

                    //
                    cmimage.ImageURL = string.Empty;

                    CharText1.Enabled = false;
                    CharText2.Enabled = false;
                    fupPicPath.Enabled = false;
                    btn_upload.Enabled = false;
                }
                else
                {
                    Server.Transfer("../AdWeb/APassport.aspx");
                }
            }
             
        }

        protected void bnt_save_Click(object sender, EventArgs e)
        {
            int insertCount4 = 0;
            //分子结构图不能为空
            if (cmimage.ImageURL == string.Empty)
            {
                Script.AjaxAlert(bnt_save, "对不起，请先上传分子式图片，再保存！");
                return;
            }
            if (Session[insertCountN] != null)
            {
                insertCount4 = Convert.ToInt32(Session[insertCountN].ToString());
            }
            else
                insertCount4 = 0;
            //保存数据
            if (insertCount4 == 0)
            {//插入操作并且是首次插入
                if (ExcuteInsert() == 1)
                {
                    insertCount4++;
                    Session[insertCountN] = insertCount4;
                    Script.AjaxAlert(bnt_save, "恭喜您，添加化学成分信息成功！");
                }
            }
            else if (insertCount4 != 0)
            {
                //更新操作
                int icmid = Convert.ToInt32(hid_cmid.Value.ToString().Trim());
                if (ExcuteUpdate(icmid) == 1)
                    Script.AjaxAlert(bnt_save, "恭喜您，保存化学成分信息成功！");
            }
            else
            {
                Script.AjaxAlert(bnt_save, "对不起，保存化学成分信息失败！");
            }

            CharText1.Enabled = false;
            CharText2.Enabled = false;
            fupPicPath.Enabled = false;
            btn_upload.Enabled = false;

            //插入之后要重新更新数据
            string drugid = hid_drugid.Value;
            DataBindText(drugid);

            

        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            CharText1.Enabled = true;
            CharText2.Enabled = true;
            fupPicPath.Enabled = true;
            btn_upload.Enabled = true;

            CharText1.TextValue = "";
            CharText2.TextValue = "";
            lbl_cmpicURL.Text = "";
            cmimage.ImageURL = "";
            Session[insertCountN] = "0";
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string drugid = hid_drugid.Value;
            DataBindText(drugid);

            gv.PageIndex = e.NewPageIndex;
            gv.DataBind();
        }

        protected void btn_upload_Click(object sender, EventArgs e)
        {
            string picPath;
            if (!this.savePicPath(out picPath))
            {
                Script.AjaxAlert(btn_upload, "化学分子式图片上传失败，请检查文件的大小和类型是否正确！");
                return;
            }
            lbl_cmpicURL.Text = picPath;
            cmimage.ImageURL = picPath;
        }
        protected bool savePicPath(out string picPath)
        {
            if (this.fupPicPath.HasFile)
            {
                bool r = false;
                string[] allowExtension = System.Configuration.ConfigurationManager.AppSettings["CMPictureAllowExtension"].ToString().Split(',');
                long maxLength = long.Parse(System.Configuration.ConfigurationManager.AppSettings["CMPictureMaxLength"].ToString());
                string path = "~/DrugHan/Admin/UploadImages";
                string result = SqlHelper.SaveFile(this.Page, this.fupPicPath, path, allowExtension, maxLength, out r);
                if (r)
                {
                    picPath = path + "/" + result;
                    return true;
                }
                else
                {
                    picPath = "";
                    //Tool.Response.Write.Alert(this.Page, result);
                    return false;
                }
            }
            else
            {
                picPath = "";
                return false;
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

        public void DataBindText(string drugid)
        {
            cChemistry ccm = new cChemistry();
            try
            {
                DataTable dt = ccm.GetCmDtByDrugid(drugid);
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

        protected int ExcuteUpdate(int keyid)
        {
            int val = -10;
            string UpdateCommand = "UPDATE [chemistry] SET [rshid] = @rshid, [drugid] = @drugid, [cmname] = @cmname, [cmformula] = @cmformula, [cmpic] = @cmpic WHERE [cmid] = @cmid";
            
            SqlParameter[] par = new SqlParameter[6];
           
            int idrugid = 0;
            int irsid = 0;
            if (Session["drugid"] != null && Session["rsid"] != null)
            {
                idrugid = Convert.ToInt32(hid_drugid.Value.ToString().Trim());
                irsid = Convert.ToInt32(hid_rsid.Value.ToString().Trim());
            }
            else
            {
                //这个地方还需要再次考虑一下，是否要弹出一个窗口
                Response.Redirect("../Admin/AdWeb/APassport.aspx");
            }
            par[0] = new SqlParameter("@cmid", SqlDbType.Int); par[0].Value = keyid;

            par[1] = new SqlParameter("@rshid", SqlDbType.Int); par[1].Value = irsid;
            par[2] = new SqlParameter("@drugid", SqlDbType.Int); par[2].Value = idrugid;

            par[3] = new SqlParameter("@cmname", SqlDbType.NVarChar, 800); par[3].Value = CharText1.TextValue;
            par[4] = new SqlParameter("@cmformula", SqlDbType.NVarChar, 100); par[4].Value = CharText2.TextValue;
            par[5] = new SqlParameter("@cmpic", SqlDbType.NVarChar, 100); par[5].Value = lbl_cmpicURL.Text.ToString().Trim();


            cResearch crh = new cResearch();
            try
            {
                //在这里要拿到更新之前图片的名字

                string GetsavePath = cChemistry.GetImgID(keyid);//这里是你的相对路径
                string savePath = Server.MapPath(GetsavePath);//必须经过这一步操作才能变成有效路径

                // 更新之后会改变原有的图片
                val = crh.ModiResearch(UpdateCommand, par);
                //更新结束后应该把原来的哪个图片给删除掉，但是图片的名字在更新之前要先拿到
                if (GetsavePath != lbl_cmpicURL.Text.ToString().Trim())
                    if (System.IO.File.Exists(savePath))//先判断文件是否存在，再执行操作
                    {
                        System.IO.File.Delete(savePath);
                    }

            }
            catch
            { }
            return val;
        }
 
        protected int ExcuteInsert()
        {
            int val = -10;
            string InsertCommand = "INSERT INTO [chemistry] ([rshid], [drugid], [cmname], [cmformula], [cmpic]) VALUES (@rshid, @drugid, @cmname, @cmformula, @cmpic)";
            SqlParameter[] par = new SqlParameter[5];

            int idrugid = 0;
            int irsid = 0;
            if (Session["drugid"] != null && Session["rsid"] != null)
            {               
                idrugid = Convert.ToInt32(hid_drugid.Value.ToString().Trim());
                irsid = Convert.ToInt32(hid_rsid.Value.ToString().Trim());
            }
            else
            {
                //这个地方还需要再次考虑一下，是否要弹出一个窗口
                Response.Redirect("../Admin/AdWeb/APassport.aspx");
            }

            par[0] = new SqlParameter("@rshid", SqlDbType.Int); par[0].Value = irsid;
            par[1] = new SqlParameter("@drugid", SqlDbType.Int); par[1].Value = idrugid;

            par[2] = new SqlParameter("@cmname", SqlDbType.NVarChar, 800); par[2].Value = CharText1.TextValue;
            par[3] = new SqlParameter("@cmformula", SqlDbType.NVarChar, 100); par[3].Value = CharText2.TextValue;
            par[4] = new SqlParameter("@cmpic", SqlDbType.NVarChar, 100); par[4].Value = lbl_cmpicURL.Text.ToString().Trim();


            cChemistry ccm = new cChemistry();
            DataTable ccmdt;
            int gcmid = -10;
            try
            {
                val = ccm.ModiChemistry(InsertCommand, par);
                //根据文化属性编号去查询，可能和根据药物编号查询效果一致的，但是效果更好些。
                //此处可能有zhuyc漏洞，因为可能有并发的问题
                ccmdt = ccm.GetCmDtByRshid(irsid.ToString());

                if (ccmdt.Rows.Count > 0)
                {
                    //插入新的数据后马上获取它的自增主关键字,方便更新。
                    gcmid = Convert.ToInt32( ccmdt.Rows[ccmdt.Rows.Count -1]["cmid"].ToString().Trim());
                    Session["cmid"] = gcmid;
                    hid_cmid.Value = gcmid.ToString().Trim();                   
                }
            }
            catch
            { }



            return val;
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
                int icmid = Convert.ToInt32(e.CommandArgument.ToString().Trim());
                string delString = "DELETE FROM chemistry WHERE cmid =  " + icmid;
                // 如果成功删除，那么就要把照片一起删除掉
                try
                {
                   
                    string savePath = cChemistry.GetImgID(icmid);//这里是你的相对路径
                    savePath = Server.MapPath(savePath);//必须经过这一步操作才能变成有效路径
                    if (System.IO.File.Exists(savePath))//先判断文件是否存在，再执行操作
                    {
                        SqlHelper.ExecuteNonQuery(delString);
                        System.IO.File.Delete(savePath);
                        
                    }
                }
                catch
                {
                     
                }
               
      
                
               
                //删除之后要重新加载repeater
                DataBindText(drugid);
                //删除之后要清除4个文本框的内容
                 CharText1.TextValue = string.Empty;
                 CharText2.TextValue = string.Empty;
                 lbl_cmpicURL.Text = string.Empty;
                 cmimage.ImageURL = string.Empty;
                 Session[insertCountN] = "0";
                //-----------------------------------
            }
            if (e.CommandName == "detail")
            {
                int icmid = Convert.ToInt32(e.CommandArgument.ToString().Trim());
                hid_cmid.Value = icmid.ToString();
                Session["cmid"] = icmid;
                //-------------------------------------
                string selectString = "select * from chemistry WHERE cmid =  " + icmid;
                SqlDataReader sda = SqlHelper.ExecuteReader(selectString);
                if (sda.HasRows)
                {
                     sda.Read();
                     CharText1. TextValue = sda["cmname"].ToString();
                     CharText2.TextValue = sda["cmformula"].ToString();
                     lbl_cmpicURL.Text = sda["cmpic"].ToString();
                     cmimage.ImageURL = sda["cmpic"].ToString();
                     Session[insertCountN] = "1";
                }

            }
        }

        protected void btn_back4_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AdWeb/AResearch.aspx");
        }

        protected void btn_next4_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AdWeb/ARights.aspx");
        }



    }
}