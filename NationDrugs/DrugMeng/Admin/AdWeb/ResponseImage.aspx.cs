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

namespace NationDrugs.DrugMeng.Admin.AdWeb
{
    public partial class ResponseImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string cid = Request.Params.Keys[0].ToString();
            //string strid = Request.QueryString[cid];

            //string strid = Request.QueryString["imgid"];

            string strid = Request.Params["imgid"];
            cSourceImage csimage = new cSourceImage();
            string imgPath = csimage.GetimgPath(Convert.ToInt32(strid));

            Image1.ImageUrl = imgPath;
        }
    }
}