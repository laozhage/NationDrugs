using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NationDrugs.DrugMeng.Ucshared
{
    public partial class latitudeOnlyText : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AddValidNum(TextBox1);
        }
       
        private void AddValidNum(TextBox txb)
        {
            txb.Attributes["validchars"] = "0°1′2″3度4分5秒6789.\'\"";
            txb.Attributes["onkeypress"] = "javascript:return TextUtil.allowChars(this, event)";
            txb.Attributes["onblur"] = "javascript:return TextUtil.blurAllow(this)";
        }
        public string TextValue
        {
            get { return TextBox1.Text.ToString().Trim(); }
            set { TextBox1.Text = value; }
        }
    }
}