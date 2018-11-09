using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NationDrugs.DrugWei.Ucshared
{
    public partial class FloatDigitalOnlyText : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AddValidNum(TextBox1);
        }
        private void AddValidNum(TextBox txb)
        {
            txb.Attributes["validchars"] = "0123456789.";
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