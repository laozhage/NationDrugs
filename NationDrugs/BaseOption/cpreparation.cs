using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace NationDrugs.BaseOption
{
    public class cpreparation
    {
        public DataTable GetPrepatationDT(string drugid)
        {
            int idrugid = Convert.ToInt32(drugid);
            string Qstring = "select * from preparation where drugid = " + idrugid + " ORDER BY  ppid  ASC";
            return SqlHelper.GetDataTable(Qstring);
        }
        public int ModiPrepatation( string cmdText, params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, commandParameters);
        }
    }

}