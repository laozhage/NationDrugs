using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace NationDrugs.BaseOption
{
    public class cShared
    {
        public int ModiShared(string cmdText, params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, commandParameters);
        }
        public DataTable GetShareTable(string drugid)
        {
            int idrugid = Convert.ToInt32(drugid);
            string Qstring = "select * from Share where drugid = " + idrugid;
            return SqlHelper.GetDataTable(Qstring);
        }
        public int GetShareid(string drugid)
        {
            int idrugid = Convert.ToInt32(drugid);
            int shareid = -1;
            string Qstring = "select * from Share where drugid = " + idrugid;
            try
            {
                SqlDataReader sda = SqlHelper.ExecuteReader(Qstring);
                if (sda.HasRows)
                {
                    sda.Read();
                    shareid = Convert.ToInt32(sda["ccid"].ToString().Trim());
                }
            }
            catch
            { }
            return shareid;
        }
    }
}