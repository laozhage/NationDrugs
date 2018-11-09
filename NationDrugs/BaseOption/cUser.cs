using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace NationDrugs.BaseOption
{
    public class cUser
    {
        public int ModiUser(string cmdText, params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, commandParameters);
        }
        static public int GetUserID(string UserGUID)
        {
            int userid = -10;
            string Qstring = "select * from smUser where username = '" + UserGUID + "'";
            try
            {
                SqlDataReader sda = SqlHelper.ExecuteReader(Qstring);
                if (sda.HasRows)
                {
                    sda.Read();
                    userid = Convert.ToInt32(sda["userid"].ToString().Trim());
                }
            }
            catch
            { }
            return userid;
        }
        public DataTable GetUserDatatable(string userid)
        {
            try
            {
                int iuserid = Convert.ToInt32(userid);
                string Qstring = "select * from smUser where userid = " + iuserid;
                return SqlHelper.GetDataTable(Qstring);
            }
            catch
            {
                return null;
            }
        }
        public DataTable GetUserDtByGroupid(int groupid)
        {
            string Qstring = "select * from smUser where Groupid = " + groupid;
            return SqlHelper.GetDataTable(Qstring);
        }
        public DataTable GetAllUserDatatable()
        {
            string Qstring = "select * from smUser where bdel = 'True'  order by userid ASC";
            return SqlHelper.GetDataTable(Qstring);
        }
        public bool JudgUser(string userid, string uPsw, out int groupid)
        {

            DataTable udt = this.GetUserDatatable(userid);
            bool YorN = false;
            
            if (udt.Rows.Count > 0)
            {
                string pwd = udt.Rows[0]["pwd"].ToString().Trim();
                if (string.Equals(pwd,Entry.EncryptByMd5(uPsw)) == true)
              //  if (string.Equals(pwd, uPsw) == true)
                {
                    YorN = true;
                    groupid = Convert.ToInt32(udt.Rows[0]["Groupid"].ToString());
                }
                else
                    groupid = -1;
            }
            else
            {
                groupid = -1;
            }
           
           return YorN;
       
        }
        public DataTable GetUserRight(string userid)
        {
            
            int iuserid = Convert.ToInt32(userid);
            string strFirst = " select LeftParentMenu.* ,smUserRoles.*   from  LeftParentMenu,smUserRoles  " +
                             "where LeftParentMenu.ParentMenuValue = smUserRoles.ParentMenuValue " +
                             "and smUserRoles.userid = " + iuserid + "";
            DataSet ds1 = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strFirst, null);
            return  ds1.Tables[0];           

        }
       

    }
    public class cUserInfor
    {
        private int _userid;
        private int _Groupid;      
        private string _username;      
        private string _truename;       
        private string _pwd;
        private DateTime _tcreat;       
        private DateTime _tdeadline;       
        private bool _bfunc;
        private bool _bdel;

        public cUserInfor(string userid, string pwd)
        {
            cUser cuser = new cUser();
            int groupid = -1;
            if (cuser.JudgUser(userid, pwd, out groupid))
            {
                DataTable dt = cuser.GetUserDatatable(userid);
                if (dt.Rows.Count > 0)
                {
                    _userid = Convert.ToInt32(dt.Rows[0]["userid"].ToString().Trim());
                    _Groupid = Convert.ToInt32(dt.Rows[0]["Groupid"].ToString().Trim());
                    _username = dt.Rows[0]["username"].ToString().Trim();
                    _truename =dt.Rows[0]["truename"].ToString().Trim();
                    _pwd = dt.Rows[0]["pwd"].ToString().Trim();
                    _tcreat = Convert.ToDateTime(dt.Rows[0]["tcreat"].ToString().Trim());
                    _tdeadline =Convert.ToDateTime( dt.Rows[0]["tdeadline"].ToString().Trim());
                    _bfunc = Convert.ToBoolean(dt.Rows[0]["bfunc"].ToString().Trim());
                    _bdel = Convert.ToBoolean(dt.Rows[0]["bdel"].ToString().Trim());
                }
            }
        }
        public string Pwd
        {
            get { return _pwd; }
        }
        public int Userid
        {
            get { return _userid; }
            set { _userid = value; }
        }
        public int Groupid
        {
            get { return _Groupid; }
            set { _Groupid = value; }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Truename
        {
            get { return _truename; }
            set { _truename = value; }
        }
        public DateTime Tcreat
        {
            get { return _tcreat; }
            set { _tcreat = value; }
        }
        public DateTime Tdeadline
        {
            get { return _tdeadline; }
            set { _tdeadline = value; }
        }


    }
}