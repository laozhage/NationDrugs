using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NationDrugs;

namespace NationDrugs.DrugHan.Ucshared
{
    public partial class UcCalendar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string TextValue
        {
            get
            {
                string rstring = string.Empty;
                try
                {
                    DateTime dt = Convert.ToDateTime(this.TextBox1.Text.ToString().Trim());
                    rstring = this.TextBox1.Text.ToString().Trim();
                }
                catch
                {
                    rstring = "1900-01-01";
                }
                return rstring;
            }
            set { this.TextBox1.Text = value; }
        }
        protected void TextBox1_Init(object sender, EventArgs e)
        {
            TextBox1.Attributes["onfocus"] = "javascript:WdatePicker();";
        }
    }
}