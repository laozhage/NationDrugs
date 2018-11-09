using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NationDrugs.DrugZang.Ucshared
{
    public partial class BigImage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string ImageURL
        {
            set { this.Image1.ImageUrl = value; }
            get { return this.Image1.ImageUrl.ToString().Trim(); }
        }
        public Unit Hight
        {
            get { return this.Image1.Height; }
            set { this.Image1.Height = value; }
        }
        public Unit Width
        {
            get { return this.Image1.Width; }
            set { this.Image1.Width = value; }
        }
    }
}