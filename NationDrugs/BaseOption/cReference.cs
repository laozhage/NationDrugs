using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace NationDrugs.BaseOption
{
    public class cReference
    {
        public int ModiReference(string cmdText, params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, commandParameters);
        }
        public int GetRefID(string drugid)
        {
            int grefid = -10;
            int idrugid = Convert.ToInt32(drugid);
            string Qstring = "SELECT * FROM [Reference] where drugid = " + idrugid + "ORDER BY  rfeid  ASC ";
           
            DataTable getRightDT = SqlHelper.GetDataTable(Qstring);
            if (getRightDT.Rows.Count > 0)
            {
                grefid = Convert.ToInt32(getRightDT.Rows[getRightDT.Rows.Count - 1]["rfeid"].ToString().Trim());
            }
            return grefid;
 
        }
        public DataTable GetRefTable(string drugid)
        {
            int idrugid = Convert.ToInt32(drugid);
            string Qstring = "select * from [Reference] where drugid = " + idrugid + " ORDER BY  rfeid  ASC";
            return SqlHelper.GetDataTable(Qstring);
        }
    }
}