using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace NationDrugs.BaseOption
{
    public class cCharacter
    {
        public int ModiCharacter(string cmdText, params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, commandParameters);
        }
        public DataTable GetCharacterDatatable(string drugid)
        {
            int idrugid = Convert.ToInt32(drugid);
            string Qstring = "select * from character where drugid = " + idrugid;
            return SqlHelper.GetDataTable(Qstring);
        }
        public int GetCCid(string drugid)
        {
            int idrugid = Convert.ToInt32(drugid);
            int gccid = -1;
            string Qstring = "select * from character where drugid = " + idrugid;
            try
            {
                SqlDataReader sda = SqlHelper.ExecuteReader(Qstring);
                if (sda.HasRows)
                {
                    sda.Read();
                    gccid = Convert.ToInt32(sda["ccid"].ToString().Trim());
                }
            }
            catch
            { }
            return gccid;
        }
    }

}