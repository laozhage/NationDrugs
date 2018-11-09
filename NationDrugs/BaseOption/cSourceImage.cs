using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace NationDrugs.BaseOption
{
    public class cSourceImage
    {
        public int ModiImage(string cmdText, params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, commandParameters);
        }
        public int GetImageNum(string drugid, int itype)
        {
            int gnum = 0;
            int idrugid = Convert.ToInt32(drugid);
            string Qstring = "select * from [Image] where drugid = " + idrugid + " and itype = " + itype + " ORDER BY  inum  DESC";
            SqlDataReader sdr = SqlHelper.ExecuteReader(Qstring);
            if (sdr.HasRows)
            {
                sdr.Read();
                gnum = Convert.ToInt32(sdr["inum"].ToString());
                //序号＋1
                gnum++;
            }
            else
            {
                gnum = 0;
            }
            return gnum;

        }
        public DataTable GetDTbyNum(string drugid, int itype)
        {
            int idrugid = Convert.ToInt32(drugid);
            string Qstring = "select * from [Image] where drugid = " + idrugid + " and itype = " + itype + " ORDER BY  inum  DESC";
            return SqlHelper.GetDataTable(Qstring);
        }
        public string GetimgPath(int imagid)
        {
            string imgpath = "";
            string Qstring = "select * from [Image] where imgid = " + imagid;
            SqlDataReader sdr = SqlHelper.ExecuteReader(Qstring);
            if (sdr.HasRows)
            {
                sdr.Read();
                imgpath = sdr["filepath"].ToString().Trim();
            }
            else
            {
                imgpath = "";
            }
            return imgpath.Trim();
        }


    }
}