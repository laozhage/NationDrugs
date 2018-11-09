using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NationDrugs.DrugHan.Ucshared
{
    public partial class Ulable : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string TextValue
        {
            get { return this.Label1.Text.ToString().Trim(); }
            set { this.Label1.Text = value; }
        }
    }
}