using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using NationDrugs.BaseOption;
namespace NationDrugs.Log
{
    public partial class bottom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.lblCopyrightName.Text = ConfigurationManager.AppSettings["CopyrightName"];
           
        }
    }
}