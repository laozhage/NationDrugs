using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NationDrugs.DrugZang.Ucshared
{
    public partial class gvPage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public GridView GridView1;
        void bind()
        { }

        /// <summary>
        /// 重新绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GridView1.PageIndex = this.ddlCurrentPage.SelectedIndex;
            bind();
        }
        protected void lnkbtnFrist_Click(object sender, EventArgs e)
        {
            this.GridView1.PageIndex = 0;
            bind();
        }
        protected void lnkbtnPre_Click(object sender, EventArgs e)
        {
            if (this.GridView1.PageIndex > 0)
            {
                this.GridView1.PageIndex = this.GridView1.PageIndex - 1;
                bind();
            }
        }
        protected void lnkbtnNext_Click(object sender, EventArgs e)
        {
            if (this.GridView1.PageIndex < this.GridView1.PageCount)
            {
                this.GridView1.PageIndex = this.GridView1.PageIndex + 1;
                bind();
            }
        }
        protected void lnkbtnLast_Click(object sender, EventArgs e)
        {
            this.GridView1.PageIndex = this.GridView1.PageCount;
            bind();
        } 
    }
}