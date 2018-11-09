using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace NationDrugs.BaseOption
{
    public class cRightss
    {
        public int ModiRightss(string cmdText, params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, commandParameters);
        }
        public DataTable GetCrtDtByDrugid(string drugid)
        {
            int idrugid = Convert.ToInt32(drugid);
            string Qstring = "select * from [right] where drugid = " + idrugid + " ORDER BY  rttype  ASC";
            return SqlHelper.GetDataTable(Qstring);
        }
        public int GetrtidByRsid(string rshid)
        {
            int ggrtid = -10;
            int irshid = Convert.ToInt32(rshid);
            string Qstring = "select * from [right] where rshid = " + irshid + " ORDER BY  rtid  ASC";
            DataTable getRightDT =  SqlHelper.GetDataTable(Qstring);
            if (getRightDT.Rows.Count > 0)
            {
                ggrtid = Convert.ToInt32( getRightDT.Rows[getRightDT.Rows.Count - 1]["rtid"].ToString().Trim());
            }
            return ggrtid;
        }
    }
}