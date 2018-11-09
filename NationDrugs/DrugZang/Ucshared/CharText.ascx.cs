using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NationDrugs.DrugZang.Ucshared
{
    public partial class CharText : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string TextValue
        {
            get { return this.TextBox1.Text.ToString().Trim(); }
            set { this.TextBox1.Text = value; }
        }
        public Unit Width
        {
            get { return this.TextBox1.Width; }
            set { this.TextBox1.Width = value; }
        }
       
        public bool Enabled
        {
            get{return this.TextBox1.Enabled;}
            set { this.TextBox1.Enabled = value; }
        }
    }
}