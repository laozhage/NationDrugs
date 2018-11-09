using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using NationDrugs.BaseOption;

namespace NationDrugs.WebS
{
    /// <summary>
    /// WebSHan 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class WebSHan : System.Web.Services.WebService
    {

      
        [WebMethod(Description = "获取药材基本信息")]
        
        public DataTable GetPassport(string ppbak1)
        {
            cpassport cpass = new cpassport();
            return cpass.GetALLPassportDatatable(ppbak1);
        }
    }
}
