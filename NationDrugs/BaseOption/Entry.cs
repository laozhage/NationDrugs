using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Text;
using System.IO;
/// <summary>
/// Entry 的摘要说明
/// </summary>
public class Entry
{
    private RC2 rc;
    public string Key;
    public string IV;

    public Entry(string key)
    {
        rc = new RC2CryptoServiceProvider();
        Key = key;
        IV = "#$^%&&*sdfrgth2asdf..//@@#Fgrth34sdytjhh';jk]u[y09-04534k;,'.b234adfxvn,k.,n7(*&(* ";
    }
    ///   <summary> 
    ///   对称加密类的构造函数 
    ///   </summary> 
    public Entry(string key, string iv)
    {
        rc = new RC2CryptoServiceProvider();
        Key = key;
        IV = iv;
    }
    ///   <summary> 
    ///   获得密钥 
    ///   </summary> 
    ///   <returns> 密钥 </returns> 
    private byte[] GetLegalKey()
    {
        string sTemp = Key;
        rc.GenerateKey();
        byte[] bytTemp = rc.Key;
        int KeyLength = bytTemp.Length;
        if (sTemp.Length > KeyLength)
            sTemp = sTemp.Substring(0, KeyLength);
        else if (sTemp.Length < KeyLength)
            sTemp = sTemp.PadRight(KeyLength, ' ');
        return ASCIIEncoding.ASCII.GetBytes(sTemp);
    }
    ///   <summary> 
    ///   获得初始向量IV 
    ///   </summary> 
    ///   <returns> 初试向量IV </returns> 
    private byte[] GetLegalIV()
    {
        string sTemp = IV;
        rc.GenerateIV();
        byte[] bytTemp = rc.IV;
        int IVLength = bytTemp.Length;
        if (sTemp.Length > IVLength)
            sTemp = sTemp.Substring(0, IVLength);
        else if (sTemp.Length < IVLength)
            sTemp = sTemp.PadRight(IVLength, ' ');
        return ASCIIEncoding.ASCII.GetBytes(sTemp);
    }

    public string Encrypt(string Source)
    {
        try
        {
            byte[] bytIn = UTF8Encoding.UTF8.GetBytes(Source);
            MemoryStream ms = new MemoryStream();
            rc.Key = GetLegalKey();
            rc.IV = GetLegalIV();
            ICryptoTransform encrypto = rc.CreateEncryptor();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
            cs.Write(bytIn, 0, bytIn.Length);
            cs.FlushFinalBlock();
            ms.Close();
            byte[] bytOut = ms.ToArray();
            return Convert.ToBase64String(bytOut);
        }
        catch (Exception ex)
        {
            throw new Exception("在文件加密的时候出现错误！错误提示：   \n " + ex.Message);
        }
    }

    ///   <summary> 
    ///   解密方法 
    ///   </summary> 
    ///   <param   name= "Source "> 待解密的串 </param> 
    ///   <returns> 经过解密的串 </returns> 
    public string Decrypt(string Source)
    {
        try
        {
            byte[] bytIn = Convert.FromBase64String(Source);
            MemoryStream ms = new MemoryStream(bytIn, 0, bytIn.Length);
            rc.Key = GetLegalKey();
            rc.IV = GetLegalIV();
            ICryptoTransform encrypto = rc.CreateDecryptor();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }
        catch (Exception ex)
        {
            throw new Exception("在文件解密的时候出现错误！错误提示：   \n " + ex.Message);
        }
    }
    static public  string EncryptByMd5(string source)
    {
        //32位加密
        string cl = source;
        string pwd = "";
        MD5 md5 = MD5.Create();//实例化一个md5对像
        // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
        byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
        // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
        for (int i = 0; i < s.Length; i++)
        {
            // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 

            pwd = pwd + s[i].ToString("X");

        }
        return pwd;
    }
}
