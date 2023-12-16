using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Configuration;
using System.Net;
using System.Text;
using System.Web;
namespace System.MES.Utils
{
    /// <summary>
    /// 常用的工具类静态方法集合。
    /// </summary>
    public class Tools
    {
        #region 类型验证

        /// <summary>
        /// 判断字符串是否为数字
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static bool IsNumber(string src)
        {
            try
            {
                decimal d = decimal.Parse(src);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断字符串是否为整型
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static bool IsInt(string src)
        {
            try
            {
                int d = int.Parse(src);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断字符串是否为日期
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static bool IsDatetime(string src)
        {
            if (src.Trim() == "")
                return false;
            try
            {
                DateTime d = DateTime.Parse(src);
                d = Convert.ToDateTime(src);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region 类型转换

        /// <summary>
        /// 获得字符串值。
        /// <para>该方法会将 string.Empty 转换为 defaultValue。</para>
        /// <para>该方法用于依据一个对象，始终得到一个不为空的字符串（除非调用者将 defaultVal 设置为空）。</para>
        /// <para>它等价于在程序中对象判空、ToString、IsNullOrEmpty等处理。</para>
        /// </summary>
        /// <param name="src">源对象</param>
        /// <param name="defaultVal">转换失败时期望返回的字符串值</param>
        /// <returns></returns>
        public static string GetStr(object src, string defaultVal)
        {
            return GetStr(src, defaultVal, true);
        }

        /// <summary>
        /// 获得字符串值。
        /// <para>该方法会将 string.Empty 转换为 defaultValue。</para>
        /// <para>该方法用于依据一个对象，始终得到一个不为空的字符串（除非调用者将 defaultVal 设置为空）。</para>
        /// <para>它等价于在程序中对象判空、ToString、IsNullOrEmpty等处理。</para>
        /// </summary>
        /// <param name="src">源对象</param>
        /// <param name="defaultVal">转换失败时期望返回的字符串值</param>
        /// <param name="disallowEmpty">是否不允许空值（将 string.Empty 转换为 defaultValue）</param>
        /// <returns></returns>
        public static string GetStr(object src, string defaultVal, bool disallowEmpty)
        {
            if (src == null)
                return defaultVal;
            if (disallowEmpty && src.ToString().Length == 0)
                return defaultVal;
            return src.ToString();
        }

        /// <summary>
        /// 获取8位整型值。
        /// </summary>
        /// <param name="src">长整型值</param>
        /// <returns></returns>
        public static byte GetByte(long src)
        {
            if (src > byte.MaxValue)
                return byte.MaxValue;
            else if (src < byte.MinValue)
                return byte.MinValue;
            return (byte)src;
        }

        /// <summary>
        /// 获得16位整型值。
        /// </summary>
        /// <param name="src">源对象</param>
        /// <param name="defaultVal">转换失败时期望返回的整型值</param>
        /// <param name="scale">源字符串的进位制，如16、10、8、2等</param>
        /// <returns></returns>
        public static short GetShort(object src, short defaultVal, int scale)
        {
            short rv;
            try
            {
                rv = Convert.ToInt16(src.ToString().Trim(), scale);
            }
            catch
            {
                rv = defaultVal;
            }
            return rv;
        }

        /// <summary>
        /// 获得16位整型值。
        /// </summary>
        /// <param name="src">源对象</param>
        /// <param name="defaultVal">转换失败时期望返回的整型值</param>
        /// <returns></returns>
        public static short GetShort(object src, short defaultVal)
        {
            short rv;
            if (src != null && short.TryParse(src.ToString().Trim(), out rv))
                return rv;
            return defaultVal;
        }

        /// <summary>
        /// 获取16位整型值。
        /// </summary>
        /// <param name="src">长整型值</param>
        /// <returns></returns>
        public static short GetShort(long src)
        {
            if (src > short.MaxValue)
                return short.MaxValue;
            else if (src < short.MinValue)
                return short.MinValue;
            return (short)src;
        }

        /// <summary>
        /// 获得整型值。
        /// </summary>
        /// <param name="src">源对象</param>
        /// <param name="defaultVal">转换失败时期望返回的整型值</param>
        /// <param name="scale">源字符串的进位制，如16、10、8、2等</param>
        /// <returns></returns>
        public static int GetInt(object src, int defaultVal, int scale)
        {
            int rv;
            try
            {
                rv = Convert.ToInt32(src.ToString().Trim(), scale);
            }
            catch
            {
                rv = defaultVal;
            }
            return rv;
        }

        /// <summary>
        /// 获得整型值。
        /// </summary>
        /// <param name="src">源对象</param>
        /// <param name="defaultVal">转换失败时期望返回的整型值</param>
        /// <returns></returns>
        public static int GetInt(object src, int defaultVal)
        {
            int rv;
            if (src != null && int.TryParse(src.ToString().Trim(), out rv))
                return rv;
            return defaultVal;
        }

        /// <summary>
        /// 获取整型值。
        /// </summary>
        /// <param name="src">长整型值</param>
        /// <returns></returns>
        public static int GetInt(long src)
        {
            if (src > int.MaxValue)
                return int.MaxValue;
            else if (src < int.MinValue)
                return int.MinValue;
            return (int)src;
        }

        /// <summary>
        /// 获得长整型值。
        /// </summary>
        /// <param name="src">源对象</param>
        /// <param name="defaultVal">转换失败时期望返回的长整型值</param>
        /// <param name="scale">源字符串的进位制，如16、10、8、2等</param>
        /// <returns></returns>
        public static long GetLong(object src, long defaultVal, int scale)
        {
            long rv;
            try
            {
                rv = Convert.ToInt64(src.ToString().Trim(), scale);
            }
            catch
            {
                rv = defaultVal;
            }
            return rv;
        }

        /// <summary>
        /// 获得长整型值。
        /// </summary>
        /// <param name="src">源对象</param>
        /// <param name="defaultVal">转换失败时期望返回的长整型值</param>
        /// <returns></returns>
        public static long GetLong(object src, long defaultVal)
        {
            long rv;
            if (src != null && long.TryParse(src.ToString(), out rv))
                return rv;
            return defaultVal;
        }

        /// <summary>
        /// 获得双精度值。
        /// </summary>
        /// <param name="src">源对象</param>
        /// <param name="defaultVal">转换失败时期望返回的双精度值</param>
        /// <returns></returns>
        public static double GetDouble(object src, double defaultVal)
        {
            double rv;
            if (src != null && double.TryParse(src.ToString(), out rv))
                return rv;
            return defaultVal;
        }

        /// <summary>
        /// 获得时间类型值
        /// </summary>
        /// <param name="src">源对象</param>
        /// <param name="defaultVal">转换失败时期望返回的时间类型值</param>
        /// <returns></returns>
        public static DateTime GetDatetime(object src, DateTime defaultVal)
        {
            DateTime dt;
            if (src != null && DateTime.TryParse(src.ToString(), out dt))
                return dt;
            return defaultVal;
        }

        #endregion

        #region Byte相关

        /// <summary>
        /// 返回由字节数组中指定位置的两个字节转换来的 16 位有符号整型 (NetworkToHostOrder)。
        /// </summary>
        /// <param name="src">字节数组</param>
        /// <param name="startIndex">读数起始位置</param>
        /// <returns></returns>
        public static short ReadShort(byte[] src, int startIndex)
        {
            return IPAddress.NetworkToHostOrder(BitConverter.ToInt16(src, startIndex));
        }

        /// <summary>
        /// 返回由字节数组中指定位置的两个字节转换来的 32 位有符号整型 (NetworkToHostOrder)。
        /// </summary>
        /// <param name="src">字节数组</param>
        /// <param name="startIndex">读数起始位置</param>
        /// <returns></returns>
        public static int ReadInt(byte[] src, int startIndex)
        {
            return IPAddress.NetworkToHostOrder(BitConverter.ToInt32(src, startIndex));
        }

        /// <summary>
        /// 返回由字节数组中指定位置的两个字节转换来的 32 位无符号整型 (NetworkToHostOrder)。
        /// </summary>
        /// <param name="src">字节数组</param>
        /// <param name="startIndex">读数起始位置</param>
        /// <returns></returns>
        public static uint ReadUInt(byte[] src, int startIndex)
        {
            return (uint)IPAddress.NetworkToHostOrder((long)BitConverter.ToUInt32(src, startIndex));
        }

        /// <summary>
        /// 返回由字节数组中指定位置的两个字节转换来的 64 位有符号整型 (NetworkToHostOrder)。
        /// </summary>
        /// <param name="src">字节数组</param>
        /// <param name="startIndex">读数起始位置</param>
        /// <returns></returns>
        public static long ReadLong(byte[] src, int startIndex)
        {
            return IPAddress.NetworkToHostOrder(BitConverter.ToInt64(src, startIndex));
        }

        /// <summary>
        /// 获得byte数组。
        /// </summary>
        /// <param name="src">整型值</param>
        /// <returns></returns>
        public static byte[] GetBytes(int src)
        {
            return BitConverter.GetBytes(IPAddress.HostToNetworkOrder(src));
        }

        /// <summary>
        /// 获得byte数组。
        /// </summary>
        /// <param name="src">短整型值</param>
        /// <returns></returns>
        public static byte[] GetBytes(short src)
        {
            return BitConverter.GetBytes(IPAddress.HostToNetworkOrder(src));
        }

        /// <summary>
        /// 获得byte数组。
        /// </summary>
        /// <param name="src">长整型值</param>
        /// <returns></returns>
        public static byte[] GetBytes(long src)
        {
            return BitConverter.GetBytes(IPAddress.HostToNetworkOrder(src));
        }

        /// <summary>
        /// 获得byte数组。
        /// </summary>
        /// <param name="src">整型值</param>
        /// <param name="bytesRightLen">要靠右保留的byte个数</param>
        /// <returns></returns>
        public static byte[] RightBytes(byte[] src, int bytesRightLen)
        {
            byte[] retBytes = new byte[bytesRightLen];
            Array.Copy(src, src.Length - bytesRightLen, retBytes, 0, bytesRightLen);
            return retBytes;
        }

        #endregion

        #region 数组相关

        /// <summary>
        /// 将以分隔符分隔的字符串转为int数组
        /// </summary>
        /// <param name="str"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>
        public static int[] SplitToInt32Array(string str, string seperator)
        {
            string[] items = str.Split(new string[] { seperator }, StringSplitOptions.RemoveEmptyEntries);
            int[] array = new int[items.Length];
            for (int i = items.Length - 1; i >= 0; i--)
            {
                int value;
                if (!int.TryParse(items[i], out value))
                    return null;
                array[i] = value;
            }
            return array;
        }

        /// <summary>
        /// 将以分隔符分隔的字符串转为int数组
        /// </summary>
        /// <param name="str"></param>
        /// <param name="seperators"></param>
        /// <returns></returns>
        public static int[] SplitToInt32Array(string str, string[] seperators)
        {
            string[] items = str.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
            int[] array = new int[items.Length];
            for (int i = items.Length - 1; i >= 0; i--)
            {
                int value;
                if (!int.TryParse(items[i], out value))
                    return null;
                array[i] = value;
            }
            return array;
        }

        /// <summary>
        /// 合并一组可枚举的对象为字符串
        /// </summary>
        /// <param name="enumerable">被枚举对象</param>
        /// <param name="seperator">分隔符</param>
        /// <returns></returns>
        public static string ConcatEnumerable(IEnumerable enumerable, string seperator)
        {
            IEnumerator enumerator = enumerable.GetEnumerator();
            if (!enumerator.MoveNext())
                return string.Empty;
            StringBuilder text = new StringBuilder(128);
            text.Append(enumerator.Current.ToString());
            while (enumerator.MoveNext())
            {
                text.Append(seperator + enumerator.Current);
            }
            return text.ToString();
        }

        #endregion

        #region 列表分页相关
        /// <summary>
        /// 获取分页起始索引（同时验证与修改参数）
        /// </summary>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="pageIndex">当前是第几页</param>
        /// <returns></returns>
        public static int GetStartRec(ref int pageSize, ref int pageIndex)
        {
            if (pageSize < 1) pageSize = 20;
            if (pageIndex < 1) pageIndex = 1;
            return pageSize * (pageIndex - 1) + 1;
        }

        /// <summary>
        /// 获取分页终止索引（不验证参数）
        /// </summary>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="pageIndex">当前是第几页</param>
        /// <returns></returns>
        public static int GetEndRec(int pageSize, int pageIndex)
        {
            return pageSize * pageIndex;
        }

        /// <summary>
        /// 获取分页起始索引（同时验证与修改参数）
        /// </summary>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="pageIndex">当前是第几页</param>
        /// <returns></returns>
        public static long GetStartRec(ref long pageSize, ref long pageIndex)
        {
            if (pageSize < 1) pageSize = 20;
            if (pageIndex < 1) pageIndex = 1;
            return pageSize * (pageIndex - 1) + 1;
        }

        /// <summary>
        /// 获取分页终止索引（不验证参数）
        /// </summary>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="pageIndex">当前是第几页</param>
        /// <returns></returns>
        public static long GetEndRec(long pageSize, long pageIndex)
        {
            return pageSize * pageIndex;
        }

        /// <summary>
        /// 根据记录总数与每页记录数，计算分页总数
        /// </summary>
        /// <param name="recordCount">记录总数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <returns></returns>
        public static int GetPageSize(int recordCount, int pageSize)
        {
            return (int)Math.Ceiling((double)recordCount / pageSize);
        }
        #endregion

        #region 其它

        /// <summary>
        /// 得到Request中指定参数的值（返回String值）
        /// </summary>
        /// <param name="keyName">要获取的参数的名称</param>
        /// <param name="defaultVal">当不存在该参数时返回的默认值</param>
        /// <returns></returns>
       /* public static string GetRequestVal(string keyName, string defaultVal)
        {
            string rv = HttpContext.Current.Request[keyName];
            return Tools.GetStr(rv, defaultVal);
        }

        /// <summary>
        /// 得到Request中指定参数的值（返回Int值）
        /// </summary>
        /// <param name="keyName">要获取的参数的名称</param>
        /// <param name="defaultVal">当不存在该参数时返回的默认值</param>
        /// <returns></returns>
        public static int GetRequestVal(string keyName, int defaultVal)
        {
            string rv = HttpContext.Current.Request[keyName];
            return Tools.GetInt(rv, defaultVal);
        }*/

        /// <summary>
        /// 得到一个系统配置项的值
        /// </summary>
        /// <param name="keyName">配置项名称</param>
        /// <param name="defaultVal">在不存在该配置项时返回的默认值</param>
        /// <returns></returns>
        public static string GetAppSetting(string keyName, string defaultVal)
        {
            string rv = System.Configuration.ConfigurationManager.AppSettings[keyName];
            return Tools.GetStr(rv, defaultVal);
        }

        /// <summary>
        /// 得到一个系统配置项的值
        /// </summary>
        /// <param name="keyName">配置项名称</param>
        /// <param name="defaultVal">在不存在该配置项时返回的默认值</param>
        /// <returns></returns>
        public static int GetAppSetting(string keyName, int defaultVal)
        {
            string rv = System.Configuration.ConfigurationManager.AppSettings[keyName];
            return Tools.GetInt(rv, defaultVal);
        }

        /// <summary>
        /// 得到一个连接字符串配置项的值
        /// <para>当配置不存在时，返回Null</para>
        /// </summary>
        /// <param name="keyName">配置项名称</param>
        /// <returns></returns>
        public static string GetConnStrConfig(string keyName)
        {
            if (ConfigurationManager.ConnectionStrings[keyName] != null)
                return System.Configuration.ConfigurationManager.ConnectionStrings[keyName].ConnectionString;
            return null;
        }

        /// <summary>
        /// 获得字符串值的前N位字符
        /// </summary>
        /// <param name="src">指定的字符串</param>
        /// <param name="len">指定的长度</param>
        /// <returns></returns>
        public static string GetLenthStr(string src, int len)
        {
            if (src.Length > len)
                return src.Substring(0, len);
            return src;
        }

        /// <summary>
        /// 对字符串进行编码，以保证SQL参数的安全性
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string EncodeStr4Sql(string src)
        {
            return src.Replace("'", "''");
        }

        #endregion
    }
}