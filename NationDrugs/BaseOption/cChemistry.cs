using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace NationDrugs.BaseOption
{
    public class cChemistry
    {
        public int ModiChemistry(string cmdText, params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, commandParameters);
        }
        public DataTable GetCmDtByDrugid(string drugid)
        {
            int idrugid = Convert.ToInt32(drugid);
            string Qstring = "select * from chemistry where drugid = " + idrugid + "ORDER BY  cmid  ASC";
            return SqlHelper.GetDataTable(Qstring);
        }
        public DataTable GetCmDtByRshid(string rshid)
        {
            int irshid = Convert.ToInt32(rshid);
            string Qstring = "select * from chemistry where rshid = " + irshid + "ORDER BY  cmid  ASC";
            return SqlHelper.GetDataTable(Qstring);
        }
        public static string  GetImgID(int cmid)
        {
            string Qstring = "select * from chemistry where cmid = " + cmid + "ORDER BY  cmid  ASC";
            SqlDataReader sdr =  SqlHelper.ExecuteReader(Qstring);
            string gcmpid = string.Empty;
             if (sdr.HasRows)
                {
                    sdr.Read();                     
                    gcmpid = sdr["cmpic"].ToString();                   
                }
            return gcmpid;
        }
    }
}