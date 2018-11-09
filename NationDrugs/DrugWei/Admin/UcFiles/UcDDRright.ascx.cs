using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NationDrugs.DrugWei.Admin.UcFiles
{
    public partial class UcDDRright : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public int SelectedValue
        {
            get { return Convert.ToInt32(DropDownList1.SelectedValue); }
        }
        public string SelectedText
        {
            get { return DropDownList1.SelectedItem.Text; }
        }
        public string SetText
        {
            
            set {
                int iv = Convert.ToInt32(value);
                DropDownList1.SelectedIndex = iv;
                 }
        }
    }
}