using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace NationDrugs.BaseOption
{
    public class cHeredity
    {
        public int ModiHeredity(string cmdText, params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, commandParameters);
        }
        public int GetHdid(string drugid)
        {
            int idrugid = Convert.ToInt32(drugid);
            int ghdid = -10;
            string Qstring = "select * from Heredity where drugid = " + idrugid;
            try
            {
                SqlDataReader sda = SqlHelper.ExecuteReader(Qstring);
                if (sda.HasRows)
                {
                    sda.Read();
                    ghdid = Convert.ToInt32(sda["hdid"].ToString().Trim());
                }
            }
            catch
            { }
            return ghdid;
        }

        public DataTable GetHdTable(string drugid)
        {
            int idrugid = Convert.ToInt32(drugid);
            string Qstring = "select * from Heredity where drugid = " + idrugid;
            return SqlHelper.GetDataTable(Qstring);
        }
    }
}