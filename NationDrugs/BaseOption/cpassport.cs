using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



using System.Data.SqlClient;
using System.Data;

namespace NationDrugs.BaseOption
{
    public class cpassport
    {
        public int Insertpassport(string cmdText ,params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteNonQuery(CommandType.Text , cmdText, commandParameters);
        }
        public DataTable GetPassportDatatable(string drugid)
        {
            int idrugid = Convert.ToInt32(drugid);
            string Qstring = "select * from Passport where drugid = " + idrugid + " and bdel = 'True'";
            return SqlHelper.GetDataTable(Qstring);
        }
        public DataTable GetALLPassportDatatable(string ppbak1)
        {
            string Qstring = "select * from Passport where ppbak1 = '" + ppbak1 + "'";
            return SqlHelper.GetDataTable(Qstring);
        }
       static public int Getdrugid(string getGUID)
        {
            int gdrugid = -1;
            string Qstring = "select * from Passport where useGUID = '" + getGUID + "'";
            DataTable dt = SqlHelper.GetDataTable(Qstring);
            if (dt.Rows.Count > 0)
                gdrugid = Convert.ToInt32(dt.Rows[0]["drugid"].ToString().Trim());
            return gdrugid;
        }
       public string GetDrugName(string drugid)
       {
           string DrugName = "Nofound";
           DataTable dt = this.GetPassportDatatable(drugid);
           if (dt.Rows.Count > 0)
               DrugName =  dt.Rows[0]["nationName"].ToString();
          
           return DrugName;
       }

    }
}