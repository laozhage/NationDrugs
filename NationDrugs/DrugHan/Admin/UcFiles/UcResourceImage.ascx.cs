using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NationDrugs.BaseOption;
using System.Data;
using System.Data.SqlClient;
using System.IO;


namespace NationDrugs.DrugHan.Admin.UcFiles
{
    public partial class UcResourceImage : System.Web.UI.UserControl
    {
        private const string insertCountN = "insertCount8";
        protected void Page_Disposed(object sender, EventArgs e)
        {
            //销毁这个页面时候要把Session["insertCount8"]
            if (Session[insertCountN] != null)
                Session.Remove(insertCountN);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string drugid = string.Empty;
                string drugName = string.Empty;
                string ImageCat = string.Empty;
                if (Session["drugid"] != null )
                {
                    //获取right表的内容，绑定在gv上
                    drugid = Session["drugid"].ToString().Trim();
                   
                    cpassport cp = new cpassport();
                    drugName = cp.GetDrugName(drugid);
                    //把药材的名称绑定在中药名上
                    Ulable1.TextValue = drugName;
                    //绑定DataList
                    int itype = Convert.ToInt32(DropDownList1.SelectedItem.Value);
                    DataBindText(drugid,itype);

                    //登陆进来之后就要保存2个参数到隐藏的字段
                    hid_drugid.Value = drugid;
                 

                }
                else
                {
                    Server.Transfer("../AdWeb/APassport.aspx");
                }
            }
        }

        void DataBindText(string drugid,int itype)
        {
            cSourceImage csimage = new cSourceImage();
            DataTable dt = csimage.GetDTbyNum(drugid, itype);
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        protected void btn_upload_Click(object sender, EventArgs e)
        {
            string picPath;
            picPath = "";
            if (!this.savePicPath(out picPath))
            {
                Script.AjaxAlert(btn_upload, "图片上传失败，请检查文件的大小和类型是否正确！");
                return;
            }
            else
            {
                //表示图片上传成功了
                l1.Text = picPath;
                //插入之前先查看该类别已经插入了几个图片
                //第一次插入，第二次更新，先做插入起
                if (ExcuteInsert() > 0)
                {
                    Script.AjaxAlert(btn_upload, "恭喜您，图片上传成功！");
                    string drugid = hid_drugid.Value;
                    int itype = Convert.ToInt32(DropDownList1.SelectedItem.Value);
                    DataBindText(drugid, itype);
                }
                else
                {
                   //需要删除刚刚上传的图片
                    string savePath = Server.MapPath(picPath);//必须经过这一步操作才能变成有效路径
                    if (System.IO.File.Exists(savePath))//先判断文件是否存在，再执行操作
                    {                       
                        System.IO.File.Delete(savePath);
                    }
                }
            }
            


        }
       
        protected int ExcuteInsert()
        {
            int val = -10;
            string InsertCommand = "INSERT INTO [Image] ([drugid], [imagename], [itype], [inum], [filepath], [ifilesize], [filetype], [filename], [imagebak1], [imagebak2]) VALUES (@drugid, @imagename, @itype, @inum, @filepath, @ifilesize, @filetype, @filename, @imagebak1, @imagebak2)";
            SqlParameter[] par = new SqlParameter[10];
            int idrugid = 0;
            int ginum = 0;
            cSourceImage csimage = new cSourceImage();
            if (Session["drugid"] != null )
            {
                hid_drugid.Value = Session["drugid"].ToString();
                idrugid = Convert.ToInt32(Session["drugid"].ToString());                
                ginum = csimage.GetImageNum(hid_drugid.Value, DropDownList1.SelectedIndex);
            }
            else
            {
                //这个地方还需要再次考虑一下，是否要弹出一个窗口
                Response.Redirect("../Admin/AdWeb/APassport.aspx");
            }

            par[0] = new SqlParameter("@drugid", SqlDbType.Int);            par[0].Value = Convert.ToInt32(hid_drugid.Value);
            par[1] = new SqlParameter("@imagename", SqlDbType.NVarChar, 400); par[1].Value = CharTextRequired1.TextValue;
            par[2] = new SqlParameter("@itype", SqlDbType.Int); par[2].Value = DropDownList1.SelectedIndex;

            par[3] = new SqlParameter("@inum", SqlDbType.Int); par[3].Value = ginum;
            par[4] = new SqlParameter("@filepath", SqlDbType.NVarChar, 200); par[4].Value = l1.Text;

            //以下5项都可以不要
            par[5] = new SqlParameter("@ifilesize", SqlDbType.BigInt); par[5].Value = 0;
            par[6] = new SqlParameter("@filetype", SqlDbType.NVarChar, 40); par[6].Value = "";
            par[7] = new SqlParameter("@filename", SqlDbType.NVarChar, 100); par[7].Value = "";
            par[8] = new SqlParameter("@imagebak1", SqlDbType.NVarChar, 40); par[8].Value = "";
            par[9] = new SqlParameter("@imagebak2", SqlDbType.NVarChar, 40); par[9].Value = "";

            try
            {
                val = csimage.ModiImage(InsertCommand, par);
            }
            catch
            { }



            return val;

        }

        protected bool savePicPath(out string picPath)
        {
            if (this.fupPicPath.HasFile)
            {
                bool r = false;
                string[] allowExtension = System.Configuration.ConfigurationManager.AppSettings["CMPictureAllowExtension"].ToString().Split(',');
                long maxLength = long.Parse(System.Configuration.ConfigurationManager.AppSettings["CMPictureMaxLength"].ToString());
                string path = "~/DrugHan/Admin/SourceImages";
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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string drugid = hid_drugid.Value;
            int itype = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            DataBindText(drugid, itype);
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            cSourceImage csimage = new cSourceImage();
            if (e.CommandName == "del")
            {
                int iimgid = Convert.ToInt32(e.CommandArgument);

                string DeleteCommand = "DELETE FROM [Image] WHERE [imgid] = @imgid";
                SqlParameter[] par = new SqlParameter[1];   

                int val = -10;
                par[0] = new SqlParameter("@imgid", SqlDbType.Int); par[0].Value = iimgid;
                try
                {
                    //
                    string picPath = csimage.GetimgPath(iimgid);
                    val = csimage.ModiImage(DeleteCommand, par);                    
                    if (picPath != "")
                    {
                        string savePath = Server.MapPath(picPath);//必须经过这一步操作才能变成有效路径
                        if (System.IO.File.Exists(savePath))//先判断文件是否存在，再执行操作
                        {
                            System.IO.File.Delete(savePath);
                        }
                    }
                    if (val > 0)
                        Script.AjaxAlert(DataList1, "恭喜您，图片删除成功！");

                    //删除之后要重新绑定
                    string drugid = hid_drugid.Value;
                    int itype = Convert.ToInt32(DropDownList1.SelectedItem.Value);
                    DataBindText(drugid, itype);
                    CharTextRequired1.TextValue = "";

                }
                catch
                { }
            }
            else if (e.CommandName == "detail")
            {
                //如果是点击原图按钮则要放大图像
              //  Response.Redirect("ResponseImage.aspx", "_blank", "menubar=0,width=200,height=200");
                int gimgid = Convert.ToInt32(e.CommandArgument);

                string str = "<script languge='javascript'> window.open('ResponseImage.aspx?imgid=" + gimgid + "','','height = 600,width = 800,top = 0,left = 0,toobar =no,menubar=no,scrollbars=yes,resizable=yes,location = no,status=no')</script>";
                Response.Write(str);
            }


        }

        protected void btn_back8_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AdWeb/AHeredity.aspx");
        }

        protected void btn_next8_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AdWeb/AShared.aspx");
        }





    }
}