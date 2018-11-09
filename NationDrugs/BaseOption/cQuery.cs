using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Collections;
using System.Data.SqlClient;


namespace NationDrugs.BaseOption
{
    public class cQuery
    {
        public string GetDrugidByNation(string NationName ,string GroupID)
        {
            string _Drugid = string.Empty;
            string Qstring = "select * from Passport where nationName like '%" + NationName + "%' and ppbak1 = '" + GroupID + "'";
            //*************

            return _Drugid;
        }
        
        private  DataTable GetDTbyNationName(string nationName, string GroupID)
        {
            string Qstring = "select * from Passport where nationName like '%" + nationName + "%' and ppbak1 = '" + GroupID + "'";
            return  SqlHelper.GetDataTable(Qstring);
        }
        private DataTable GetDTbyTransltName(string transltName, string GroupID)
        {
            string Qstring = "select * from Passport where transltName like '%" + transltName + "%' and ppbak1 = '" + GroupID + "'";
            return SqlHelper.GetDataTable(Qstring);
        }
        private DataTable GetDTbyName(string name, string GroupID)
        {
            string Qstring = "select * from Passport where name like '%" + name + "%' and ppbak1 = '" + GroupID + "'";
            return SqlHelper.GetDataTable(Qstring);
        }
        public DataTable GetDTbyNameS(string Names, string GroupID)
        {
            DataTable sumDT;

            DataTable NationDT =  this.GetDTbyNationName(Names, GroupID);           
            DataTable TransDT = this.GetDTbyTransltName(Names, GroupID);
            DataTable nameDT = this.GetDTbyName(Names, GroupID);
            if (NationDT.Rows.Count > 0)
            {//第一个表的行大于0
               sumDT =  NationDT.Copy();
            }
            else
            {
                sumDT = NationDT.Clone();
            }

            if (TransDT.Rows.Count > 0)
            {
                if (sumDT.Rows.Count <= 0)
                    sumDT = TransDT.Copy();
                else
                {//2个表中都有数据

                    for (int j = 0; j < TransDT.Rows.Count; j++)
                    {
                        int i = 0;
                        int tranDrugid = Convert.ToInt32(TransDT.Rows[j][0].ToString().Trim());
                        for ( i = 0; i < sumDT.Rows.Count; i++)
                        {
                            int sumDrugid = Convert.ToInt32(sumDT.Rows[i][0].ToString().Trim());
                            if (tranDrugid == sumDrugid)
                                break;
                        }
                        if (i >= sumDT.Rows.Count)
                        {
                            DataRow drnew = sumDT.NewRow();
                            for (int k = 0; k < TransDT.Columns.Count; k++)
                                drnew[k] = TransDT.Rows[j][k];

                            sumDT.Rows.Add(drnew);                            
                        }
                    }
 
                }
            }
            if (nameDT.Rows.Count > 0)
            {
                if (sumDT.Rows.Count <= 0)
                    sumDT = nameDT.Copy();
                else
                {
                    for (int j = 0; j < nameDT.Rows.Count; j++)
                    {
                        int i = 0;
                        int nameDurgid = Convert.ToInt32(nameDT.Rows[j][0].ToString().Trim());
                        for (i = 0; i < sumDT.Rows.Count; i++)
                        {
                            int sumDrugid = Convert.ToInt32(sumDT.Rows[i][0].ToString().Trim());
                            if (nameDurgid == sumDrugid)
                                break;
                        }
                        if (i >= sumDT.Rows.Count)
                        {
                            

                            DataRow drnew = sumDT.NewRow();
                            for (int k = 0; k < nameDT.Columns.Count; k++)
                                drnew[k] = nameDT.Rows[j][k];


                            sumDT.Rows.Add(drnew);      
                        }
                    }
 
                }
            }
           


            return sumDT;
        }



    }
}