using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

    public abstract class SqlHelper
    {
        //获取数据库连接字符串，其属于静态变量且只读，项目中的所有文档可以直接使用，但不能修改

        public static readonly string ConnectionStringLocalTransaction =
            ConfigurationManager.ConnectionStrings["MinZuYaoConnectionString"].ConnectionString;

        //哈希表用来存储缓存的参数信息，哈希表可以存储任意类型的参数 

        private static Hashtable ParmCache = Hashtable.Synchronized(new Hashtable());

        //////////因为是抽象类，不能实例化对象
        //////////public SqlHelper()
        //////////{
        //////////    //
        //////////    // TODO: 在此处添加构造函数逻辑
        //////////    //
        //////////}

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(ConnectionStringLocalTransaction);
            if (connection == null)
            {
                connection.Open();
            }
            else if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            else if (connection.State == System.Data.ConnectionState.Broken)
            {
                connection.Close();
                connection.Open();
            }

            return connection;


        }
        /// <summary>
        /// parObject.Par[] 用来存放参数
        /// parObject.Cmdtext 用来存放命令
        /// </summary>
        /// <param name="parObject"></param>
        /// <returns></returns>
        public static int ExecuteNonQueryByTrans(ParmObject[] parObject)
        {
             int val = -1;
             SqlConnection con = GetConnection();
             SqlTransaction trans = null;
                SqlCommand cmd = new SqlCommand();
                try
                {
                    trans = con.BeginTransaction();
                    cmd.Connection = con;
                    cmd.Transaction = trans;
                    for (int i = 0; i < parObject.Length; i++)
                    {
                        cmd.CommandText = parObject[i].Cmdtext;
                        if (parObject[i].Par != null)
                            cmd.Parameters.AddRange(parObject[i].Par);
                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                    val = 1;
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return val;
            
        }

        /// <summary>
        /// 为执行命令准备参数
        /// </summary>
        /// <param name="cmd">SqlCommand 命令</param>
        /// <param name="con">已经存在的数据库连接</param>
        /// <param name="trans">数据库事物处理</param>
        /// <param name="cmdType">SqlCommand 命令类型（StoreProcedure ,T-SQL) </param>
        /// <param name="cmdText">Command Text ,T-SQL 语句
        /// <example>select * from Products</example>
        /// </param>
        /// <param name="cmdParams">返回带参数的命令</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection con, SqlTransaction trans,
            CommandType cmdType, string cmdText, SqlParameter[] cmdParams)
        {
            try
            {
                //判断数据库连接状态
                if (con.State != ConnectionState.Open)
                    con.Open();
            }
            catch
            {
                HttpContext.Current.Response.Redirect("../Log/Login.aspx");
            }
            cmd.Connection = con;
            cmd.CommandText = cmdText;

            //判断是否要事务处理
            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParams != null)
            {
                foreach (SqlParameter parm in cmdParams)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }

        #region "3 个重载方法 ExecuteNonQuery(****,CommandType cmdType,string cmdText,params SqlParameter [] commandParameters)"
        //---------------- "***** ：string connectionString / SqlConneciton conn / SqlTransaction trans  

        /// <summary>
        /// <remarks>
        /// int result = ExecuteNonQuery(connString,CommandType.StoreProcedure,
        /// "PublishOrders",new SqlParameter("@prodid",24));
        /// </remarks>
        /// </summary>
        /// <param name="connectionString">一个有效的数据库连接字符串</param>
        /// <param name="cmdType">SqlCommand 的类型（StoreProcedure,T-SQL)</param>
        /// <param name="cmdText">存储过程的名字或者是T-SQL 语句</param>
        /// <param name="commandParameters">以数组的形式提供 SqlCommand 中用到的参数列表</param>
        /// <returns>返回一个数值表示此 SqlCommand 命令执行后影响的行数</returns>
        /// 
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType,
            string cmdText, params SqlParameter[] commandParameters)
        {
            //SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                ////通过 PrepareCommand 方法将参数逐个加到 SqlCommand 的参数集合中
                //PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                //int val = cmd.ExecuteNonQuery();

                ////清空SqlCommand 中的参数列表
                //cmd.Parameters.Clear();
                //return val;

                return ExecuteNonQuery(conn, cmdType, cmdText, commandParameters);
                //在下面的那个函数的基础上实现方法的重载
            }
        }


        public static int ExecuteNonQuery(SqlConnection conn, CommandType cmdType,
            string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            //通过 PrepareCommand 方法将参数逐个加到 SqlCommand 的参数集合中
            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();

            //清空SqlCommand 中的参数列表
            cmd.Parameters.Clear();
            return val;
        }
        /// <summary>
        /// zhuyc ,2013,8,15  添加一个ExcuteNonQuery 方法
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(CommandType cmdType,
        string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = GetConnection();
            //通过 PrepareCommand 方法将参数逐个加到 SqlCommand 的参数集合中
            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);

            int val = 0;
            try
            {
                val = cmd.ExecuteNonQuery();
            }
            catch
            {
                val = -1;
            }
            //清空SqlCommand 中的参数列表
            cmd.Parameters.Clear();
            return val;
        }



        /// <summary>
        /// 通过已经存在的数据库事务处理，执行一条不返回结果的 SqlCommand ，只返回所影响的行数
        /// 使用参数数组提供参数
        /// </summary>
        /// <remarks>
        /// int result = ExecuteNonQuery(trans,CommandType.StoreProcedure,
        /// "PublishOrders",new SqlParameter("@prodid",24));
        /// </remarks>
        /// <param name="conn">一个已经存在的数据库事务处理</param>
        /// <param name="cmdType">SqlCommand 的类型（StoreProcedure,T-SQL)</param>
        /// <param name="cmdText">存储过程的名字或者是T-SQL 语句</param>
        /// <param name="commandParameters">以数组的形式提供 SqlCommand 中用到的参数列表</param>
        /// <returns>返回一个数值表示此 SqlCommand 命令执行后影响的行数</returns>
        /// 
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType,
            string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            //通过 PrepareCommand 方法将参数逐个加到 SqlCommand 的参数集合中
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();

            //清空SqlCommand 中的参数列表
            cmd.Parameters.Clear();
            return val;
        }
        public static int ExecuteNonQuery(string cmdText)
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand(cmdText, con);

            int val = 0;
            try
            {
                val = cmd.ExecuteNonQuery();
            }
            catch
            {
                val = -1;
            }

            return val;

        }
        #endregion

        #region "ExecuteDataSet(***,CommandType cmdType,string cmdText,params SqlParameter[] commandParameters) 的三个重载方法"

        /// <summary>
        /// 通过一个现有的连接返回一个 DataSet 数据集
        /// </summary>
        /// <param name="conn">一个现有的连接 </param>
        /// <param name="cmdType">SqlCommand 的类型，如：Text,StroeProcedure</param>
        /// <param name="cmdText">存储过程的名字或 T-SQL 语句</param>
        /// <param name="commandParameters">一数组的形式提供的 SqlCommand 用到的参数列表</param>
        /// <returns>返回一个包含结果的 DataSet 数据集</returns>
        public static DataSet ExecuteDataSet(SqlConnection conn, CommandType cmdType,
            string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            // 通过PrepareCommand 方法将参数逐个加到 SqlCommand 的参数集合中
            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            cmd.Parameters.Clear();
            return ds;
        }

        public static DataSet ExecuteDataSet(string connecitonString, CommandType cmdType,
            string cmdText, params SqlParameter[] commandParameters)
        {
            //SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connecitonString))
            {
                return ExecuteDataSet(conn, cmdType, cmdText, commandParameters);
            }
        }

        #endregion

        /// <summary>
        /// 执行一条返回结果集的 SqlCommand 命令，通过专用的连接字符串
        /// 使用参数数组提供参数
        /// </summary>
        /// <remarks>
        /// 使用事例：
        /// SqlDataReader rdr = ExecuteReader(connString ,CommandType.StoreProcedure,
        /// "PublishOrders",new SqlParamete ("@prodid",24))
        /// </remarks>
        /// <param name="connString">一个有效的数据库连接字符串</param>
        /// <param name="cmdType">SqlCommand 的类型 :StoreProcedure ,T-SQL </param>
        /// <param name="cmdText">存储过程的名字或是 T-SQL 语句</param>
        /// <param name="cmdParams">以数组的形式提供 SqlCommand 中用到的参数列表</param>
        /// <returns>返回一个包含结果的 SqlDataReader</returns>
        /// 
        public static SqlDataReader ExecuteReader(string connString, CommandType cmdType,
            string cmdText, params SqlParameter[] cmdParams)
        {
            SqlCommand cmd = new SqlCommand();

            //这里用try/catch 是因为如果方法出现异常，则SqlDataReader 就不存在
            //CommandBehavior.CloseConnection 就不会执行，触发的异常由 catch 捕获
            // 通过 throw 引发捕捉到的异常

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParams);
                    SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    cmd.Parameters.Clear();
                    return rdr;
                }
            }
            catch
            {
                throw;
            }

        }

        public static SqlDataReader ExecuteReader(CommandType cmdType,
        string cmdText, params SqlParameter[] cmdParams)
        {
            SqlCommand cmd = new SqlCommand();

            //这里用try/catch 是因为如果方法出现异常，则SqlDataReader 就不存在
            //CommandBehavior.CloseConnection 就不会执行，触发的异常由 catch 捕获
            // 通过 throw 引发捕捉到的异常

            try
            {
                SqlConnection conn = GetConnection();
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParams);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;

            }
            catch
            {
                throw;
            }

        }





        public static SqlDataReader ExecuteReader(string cmdText)
        {
            try
            {
                SqlConnection con = GetConnection();
                SqlCommand cmd = new SqlCommand(cmdText, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                return rdr;
            }
            catch
            {
                throw;
            }
        }
        #region " 3个 重载方法 ExecuteScalar( ******,CommandType cmdType,string cmdText, params SqlParameter [] cmdParams) "
        //-------------- **** : SqlConnection conn 或者是  string connString   ---------------------------

        public static object ExecuteScalar(string connString, CommandType cmdType,
            string cmdText, params SqlParameter[] cmdParams)
        {
            //SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                //PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParams);
                //Object val = cmd.ExecuteScalar();
                //cmd.Parameters.Clear();
                //return val;

                return ExecuteScalar(conn, cmdType, cmdText, cmdParams);
                //在下面的方法的基础上实现重载
            }
        }

        /// <summary>
        /// 执行一条返回第一条记录的第一列 SqlCommand 命令，通过已经存在的数据库连接
        /// 使用参数数组提供参数
        /// </summary>
        /// <remarks>
        /// 使用事例：
        /// Object object  = ExecuteScalar(conn ,CommandType.StoreProcedure,
        /// "PublishOrders",new SqlParamete ("@prodid",24))
        /// </remarks>
        /// <param name="connString">一个现有的数据库连接</param>
        /// <param name="cmdType">SqlCommand 的类型 :StoreProcedure ,T-SQL </param>
        /// <param name="cmdText">存储过程的名字或是 T-SQL 语句</param>
        /// <param name="cmdParams">以数组的形式提供 SqlCommand 中用到的参数列表</param>
        /// <returns>返回一个object 类型的数据，可以通过 Convert.To{Type}方法转换类型</returns>
        /// 
        public static object ExecuteScalar(SqlConnection conn, CommandType cmdType,
            string cmdText, params SqlParameter[] cmdParams)
        {
            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParams);
            Object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;

        }

        public static object ExecuteScalar(string cmdText)
        {
            SqlConnection con = GetConnection();

            SqlCommand cmd = new SqlCommand(cmdText, con);

            object val = cmd.ExecuteScalar();
            return val;
        }
        #endregion



        /// <summary>
        /// 缓存参数数组
        /// </summary>
        /// <param name="cachKey">参数缓存的键值</param>
        /// <param name="commandParameters">被缓存的参数列表</param>
        public static void CacheParameters(string cachKey, params SqlParameter[] commandParameters)
        {
            ParmCache[cachKey] = commandParameters;

        }

        /// <summary>
        /// 获取被缓存的参数
        /// </summary>
        /// <param name="cacheKey">用于查找参数的 KEY 值</param>
        /// <returns>返回缓存的参数数组</returns>
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParams = (SqlParameter[])ParmCache[cacheKey];
            if (cachedParams == null)
                return null;
            //如果存在，则新建一个参数的克隆列表
            SqlParameter[] clonedParms = new SqlParameter[cachedParams.Length];

            //通过循环为克隆参数赋值
            for (int i = 0; i < cachedParams.Length; i++)
            {
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParams[i]).Clone();
            }
            return clonedParms;
        }

        public static EnumerableRowCollection<DataRow> GetCanForeachTableCollection(string str)
        {
            DataTable dtable = GetDataTable(str);
            EnumerableRowCollection<DataRow> DataRowCollection = from _table in dtable.AsEnumerable()
                                                                 select _table;
            return DataRowCollection;
        }
        public static DataTable GetDataTable(string cmdstr)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = GetConnection();
                SqlDataAdapter da = new SqlDataAdapter(cmdstr, con);//填充DataSet对象或者更新数据库

                da.Fill(ds);
                return (ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        #region ExecuteNonQuery
        /// <summary>
        /// 通过一个存储过程返回一个数组
        /// </summary>
        /// <param name="storeName">存储过程名称</param>
        /// <param name="inParameterName">入参名称</param>
        /// <param name="inParameter">出参名称</param>
        /// <param name="outParameterName">出参名称</param>
        /// <param name="outParameter">出参的值</param>
        /// <returns>数组 ArrayList 的第一项一定是执行的结果。如果returns[0]＝1表示顺利存储过程，
        ///           return[1] = 2表示插入 ，return[1]=1 表示更新</returns>
        ///
        ///// </returns>
        public static ArrayList ExecuteNonQuery(string storeName, string[] inParameterName, string[] inParameter, string[] outParameterName, string[] outParameter)
        {
            ArrayList returns = new ArrayList();
            returns.Add("1");
            SqlConnection myConnection = new SqlConnection(ConnectionStringLocalTransaction);

            try
            {
                myConnection.Open();
            }
            catch
            {
                myConnection.Close();
                myConnection.Dispose();
                returns[0] = "0";
                return returns;
            }



            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;

            //收集入参
            for (int i = 0; i < inParameter.Length; i++)
            {
                SqlParameter p1 = new SqlParameter((string)inParameterName[i], SqlDbType.NVarChar, 32000);

                p1.Direction = System.Data.ParameterDirection.Input;
                p1.Value = (string)inParameter[i];
                myCommand.Parameters.Add(p1);
            }

            ArrayList outParameters = new ArrayList();

            //收集出参
            for (int i = 0; i < outParameter.Length; i++)
            {
                SqlParameter p2 = new SqlParameter((string)outParameterName[i], SqlDbType.NVarChar, 1000);
                p2.Direction = System.Data.ParameterDirection.Output;
                myCommand.Parameters.Add(p2);
                outParameters.Add(p2);
            }
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            myCommand.CommandText = storeName;


            try
            {
                myCommand.ExecuteNonQuery();

                //收集出参的值，放入一个 ArrayList 中去 
                for (int i = 0; i < outParameters.Count; i++)
                {
                    returns.Add(((SqlParameter)outParameters[i]).Value.ToString().Trim());
                }
            }
            catch (Exception ee)
            {
                myCommand.Dispose();
                myConnection.Close();
                myConnection.Dispose();
                returns[0] = ee.ToString() + ee.Source;
                return returns;
            }

            myCommand.Dispose();
            myConnection.Close();
            myConnection.Dispose();
            returns[0] = "1";
            return returns;

        }
        #endregion ExecuteNonQuery
        public static string Encrypt(string plain)//对密码加密
        {

            Entry entry = new Entry("qwerlnldnajfoja9234jkl123@@#@#$%^%$^&%^&;,.,[-=90():;;;lpop#$%%^^%&*yu873");
            return entry.Encrypt(plain);

        }
        public static string Dencrypt(string plain)//对密码解密
        {
            Entry entry = new Entry("qwerlnldnajfoja9234jkl123@@#@#$%^%$^&%^&;,.,[-=90():;;;lpop#$%%^^%&*yu873");
            return entry.Encrypt(plain);
        }

        public static string SaveFile(Page p, FileUpload file, string path, string[] allowExtension, long maxLength, out bool r)
        {
            r = false;
            string result = "";
            try
            {
                if (!file.HasFile)
                {
                    r = false;
                    result = "上传的文件为空！";
                }
                else
                {
                    //获取文件名称
                    string fileName = file.FileName;

                    //获取绝对路径
                    string absolutePath = p.Server.MapPath(path);

                    //获取文件后缀
                    string fileExtension = Path.GetExtension(path + "/" + fileName);

                    bool bExt = false;
                    for (int i = 0; i < allowExtension.Length; i++)
                    {
                        if (fileExtension.ToLower() == allowExtension[i].ToLower())
                        {
                            bExt = true;
                            break;
                        }
                    }
                    if (!bExt)
                    {
                        r = false;
                        result = "文件类型不正确！";
                    }
                    else
                    {
                        long fileSize = file.FileContent.Length;
                        if (fileSize > maxLength)
                        {
                            r = false;
                            result = "文件大小超出限制！最大允许" + maxLength + "字节！";
                        }
                        else
                        {
                            string fileNewName = System.DateTime.Now.ToString("yyyyMMddHHmmssms") + fileExtension;
                            file.SaveAs(absolutePath + "/" + fileNewName);
                            result = fileNewName;
                            r = true;
                        }
                    }

                }
            }
            catch (Exception ee)
            {
                r = false;
                result = ee.ToString();
            }
            return result;
        }

    }
    public class ParmObject
    {
        private SqlParameter[] par;
        private string cmdtext;
        public ParmObject() { }
        public ParmObject(string _cmdtext, SqlParameter[] _par)
        {
            this.cmdtext = _cmdtext;
            this.par = _par;
        }
        public SqlParameter[] Par
        {
            get { return par; }
            set { par = value; }
        }        
        public string Cmdtext
        {
            get { return cmdtext; }
            set { cmdtext = value; }
        }
        
    }
