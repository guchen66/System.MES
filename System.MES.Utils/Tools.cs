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
    /// ���õĹ����ྲ̬�������ϡ�
    /// </summary>
    public class Tools
    {
        #region ������֤

        /// <summary>
        /// �ж��ַ����Ƿ�Ϊ����
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
        /// �ж��ַ����Ƿ�Ϊ����
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
        /// �ж��ַ����Ƿ�Ϊ����
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

        #region ����ת��

        /// <summary>
        /// ����ַ���ֵ��
        /// <para>�÷����Ὣ string.Empty ת��Ϊ defaultValue��</para>
        /// <para>�÷�����������һ������ʼ�յõ�һ����Ϊ�յ��ַ��������ǵ����߽� defaultVal ����Ϊ�գ���</para>
        /// <para>���ȼ����ڳ����ж����пա�ToString��IsNullOrEmpty�ȴ���</para>
        /// </summary>
        /// <param name="src">Դ����</param>
        /// <param name="defaultVal">ת��ʧ��ʱ�������ص��ַ���ֵ</param>
        /// <returns></returns>
        public static string GetStr(object src, string defaultVal)
        {
            return GetStr(src, defaultVal, true);
        }

        /// <summary>
        /// ����ַ���ֵ��
        /// <para>�÷����Ὣ string.Empty ת��Ϊ defaultValue��</para>
        /// <para>�÷�����������һ������ʼ�յõ�һ����Ϊ�յ��ַ��������ǵ����߽� defaultVal ����Ϊ�գ���</para>
        /// <para>���ȼ����ڳ����ж����пա�ToString��IsNullOrEmpty�ȴ���</para>
        /// </summary>
        /// <param name="src">Դ����</param>
        /// <param name="defaultVal">ת��ʧ��ʱ�������ص��ַ���ֵ</param>
        /// <param name="disallowEmpty">�Ƿ������ֵ���� string.Empty ת��Ϊ defaultValue��</param>
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
        /// ��ȡ8λ����ֵ��
        /// </summary>
        /// <param name="src">������ֵ</param>
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
        /// ���16λ����ֵ��
        /// </summary>
        /// <param name="src">Դ����</param>
        /// <param name="defaultVal">ת��ʧ��ʱ�������ص�����ֵ</param>
        /// <param name="scale">Դ�ַ����Ľ�λ�ƣ���16��10��8��2��</param>
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
        /// ���16λ����ֵ��
        /// </summary>
        /// <param name="src">Դ����</param>
        /// <param name="defaultVal">ת��ʧ��ʱ�������ص�����ֵ</param>
        /// <returns></returns>
        public static short GetShort(object src, short defaultVal)
        {
            short rv;
            if (src != null && short.TryParse(src.ToString().Trim(), out rv))
                return rv;
            return defaultVal;
        }

        /// <summary>
        /// ��ȡ16λ����ֵ��
        /// </summary>
        /// <param name="src">������ֵ</param>
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
        /// �������ֵ��
        /// </summary>
        /// <param name="src">Դ����</param>
        /// <param name="defaultVal">ת��ʧ��ʱ�������ص�����ֵ</param>
        /// <param name="scale">Դ�ַ����Ľ�λ�ƣ���16��10��8��2��</param>
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
        /// �������ֵ��
        /// </summary>
        /// <param name="src">Դ����</param>
        /// <param name="defaultVal">ת��ʧ��ʱ�������ص�����ֵ</param>
        /// <returns></returns>
        public static int GetInt(object src, int defaultVal)
        {
            int rv;
            if (src != null && int.TryParse(src.ToString().Trim(), out rv))
                return rv;
            return defaultVal;
        }

        /// <summary>
        /// ��ȡ����ֵ��
        /// </summary>
        /// <param name="src">������ֵ</param>
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
        /// ��ó�����ֵ��
        /// </summary>
        /// <param name="src">Դ����</param>
        /// <param name="defaultVal">ת��ʧ��ʱ�������صĳ�����ֵ</param>
        /// <param name="scale">Դ�ַ����Ľ�λ�ƣ���16��10��8��2��</param>
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
        /// ��ó�����ֵ��
        /// </summary>
        /// <param name="src">Դ����</param>
        /// <param name="defaultVal">ת��ʧ��ʱ�������صĳ�����ֵ</param>
        /// <returns></returns>
        public static long GetLong(object src, long defaultVal)
        {
            long rv;
            if (src != null && long.TryParse(src.ToString(), out rv))
                return rv;
            return defaultVal;
        }

        /// <summary>
        /// ���˫����ֵ��
        /// </summary>
        /// <param name="src">Դ����</param>
        /// <param name="defaultVal">ת��ʧ��ʱ�������ص�˫����ֵ</param>
        /// <returns></returns>
        public static double GetDouble(object src, double defaultVal)
        {
            double rv;
            if (src != null && double.TryParse(src.ToString(), out rv))
                return rv;
            return defaultVal;
        }

        /// <summary>
        /// ���ʱ������ֵ
        /// </summary>
        /// <param name="src">Դ����</param>
        /// <param name="defaultVal">ת��ʧ��ʱ�������ص�ʱ������ֵ</param>
        /// <returns></returns>
        public static DateTime GetDatetime(object src, DateTime defaultVal)
        {
            DateTime dt;
            if (src != null && DateTime.TryParse(src.ToString(), out dt))
                return dt;
            return defaultVal;
        }

        #endregion

        #region Byte���

        /// <summary>
        /// �������ֽ�������ָ��λ�õ������ֽ�ת������ 16 λ�з������� (NetworkToHostOrder)��
        /// </summary>
        /// <param name="src">�ֽ�����</param>
        /// <param name="startIndex">������ʼλ��</param>
        /// <returns></returns>
        public static short ReadShort(byte[] src, int startIndex)
        {
            return IPAddress.NetworkToHostOrder(BitConverter.ToInt16(src, startIndex));
        }

        /// <summary>
        /// �������ֽ�������ָ��λ�õ������ֽ�ת������ 32 λ�з������� (NetworkToHostOrder)��
        /// </summary>
        /// <param name="src">�ֽ�����</param>
        /// <param name="startIndex">������ʼλ��</param>
        /// <returns></returns>
        public static int ReadInt(byte[] src, int startIndex)
        {
            return IPAddress.NetworkToHostOrder(BitConverter.ToInt32(src, startIndex));
        }

        /// <summary>
        /// �������ֽ�������ָ��λ�õ������ֽ�ת������ 32 λ�޷������� (NetworkToHostOrder)��
        /// </summary>
        /// <param name="src">�ֽ�����</param>
        /// <param name="startIndex">������ʼλ��</param>
        /// <returns></returns>
        public static uint ReadUInt(byte[] src, int startIndex)
        {
            return (uint)IPAddress.NetworkToHostOrder((long)BitConverter.ToUInt32(src, startIndex));
        }

        /// <summary>
        /// �������ֽ�������ָ��λ�õ������ֽ�ת������ 64 λ�з������� (NetworkToHostOrder)��
        /// </summary>
        /// <param name="src">�ֽ�����</param>
        /// <param name="startIndex">������ʼλ��</param>
        /// <returns></returns>
        public static long ReadLong(byte[] src, int startIndex)
        {
            return IPAddress.NetworkToHostOrder(BitConverter.ToInt64(src, startIndex));
        }

        /// <summary>
        /// ���byte���顣
        /// </summary>
        /// <param name="src">����ֵ</param>
        /// <returns></returns>
        public static byte[] GetBytes(int src)
        {
            return BitConverter.GetBytes(IPAddress.HostToNetworkOrder(src));
        }

        /// <summary>
        /// ���byte���顣
        /// </summary>
        /// <param name="src">������ֵ</param>
        /// <returns></returns>
        public static byte[] GetBytes(short src)
        {
            return BitConverter.GetBytes(IPAddress.HostToNetworkOrder(src));
        }

        /// <summary>
        /// ���byte���顣
        /// </summary>
        /// <param name="src">������ֵ</param>
        /// <returns></returns>
        public static byte[] GetBytes(long src)
        {
            return BitConverter.GetBytes(IPAddress.HostToNetworkOrder(src));
        }

        /// <summary>
        /// ���byte���顣
        /// </summary>
        /// <param name="src">����ֵ</param>
        /// <param name="bytesRightLen">Ҫ���ұ�����byte����</param>
        /// <returns></returns>
        public static byte[] RightBytes(byte[] src, int bytesRightLen)
        {
            byte[] retBytes = new byte[bytesRightLen];
            Array.Copy(src, src.Length - bytesRightLen, retBytes, 0, bytesRightLen);
            return retBytes;
        }

        #endregion

        #region �������

        /// <summary>
        /// ���Էָ����ָ����ַ���תΪint����
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
        /// ���Էָ����ָ����ַ���תΪint����
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
        /// �ϲ�һ���ö�ٵĶ���Ϊ�ַ���
        /// </summary>
        /// <param name="enumerable">��ö�ٶ���</param>
        /// <param name="seperator">�ָ���</param>
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

        #region �б��ҳ���
        /// <summary>
        /// ��ȡ��ҳ��ʼ������ͬʱ��֤���޸Ĳ�����
        /// </summary>
        /// <param name="pageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="pageIndex">��ǰ�ǵڼ�ҳ</param>
        /// <returns></returns>
        public static int GetStartRec(ref int pageSize, ref int pageIndex)
        {
            if (pageSize < 1) pageSize = 20;
            if (pageIndex < 1) pageIndex = 1;
            return pageSize * (pageIndex - 1) + 1;
        }

        /// <summary>
        /// ��ȡ��ҳ��ֹ����������֤������
        /// </summary>
        /// <param name="pageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="pageIndex">��ǰ�ǵڼ�ҳ</param>
        /// <returns></returns>
        public static int GetEndRec(int pageSize, int pageIndex)
        {
            return pageSize * pageIndex;
        }

        /// <summary>
        /// ��ȡ��ҳ��ʼ������ͬʱ��֤���޸Ĳ�����
        /// </summary>
        /// <param name="pageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="pageIndex">��ǰ�ǵڼ�ҳ</param>
        /// <returns></returns>
        public static long GetStartRec(ref long pageSize, ref long pageIndex)
        {
            if (pageSize < 1) pageSize = 20;
            if (pageIndex < 1) pageIndex = 1;
            return pageSize * (pageIndex - 1) + 1;
        }

        /// <summary>
        /// ��ȡ��ҳ��ֹ����������֤������
        /// </summary>
        /// <param name="pageSize">ÿҳ��ʾ��¼��</param>
        /// <param name="pageIndex">��ǰ�ǵڼ�ҳ</param>
        /// <returns></returns>
        public static long GetEndRec(long pageSize, long pageIndex)
        {
            return pageSize * pageIndex;
        }

        /// <summary>
        /// ���ݼ�¼������ÿҳ��¼���������ҳ����
        /// </summary>
        /// <param name="recordCount">��¼����</param>
        /// <param name="pageSize">ÿҳ��¼��</param>
        /// <returns></returns>
        public static int GetPageSize(int recordCount, int pageSize)
        {
            return (int)Math.Ceiling((double)recordCount / pageSize);
        }
        #endregion

        #region ����

        /// <summary>
        /// �õ�Request��ָ��������ֵ������Stringֵ��
        /// </summary>
        /// <param name="keyName">Ҫ��ȡ�Ĳ���������</param>
        /// <param name="defaultVal">�������ڸò���ʱ���ص�Ĭ��ֵ</param>
        /// <returns></returns>
       /* public static string GetRequestVal(string keyName, string defaultVal)
        {
            string rv = HttpContext.Current.Request[keyName];
            return Tools.GetStr(rv, defaultVal);
        }

        /// <summary>
        /// �õ�Request��ָ��������ֵ������Intֵ��
        /// </summary>
        /// <param name="keyName">Ҫ��ȡ�Ĳ���������</param>
        /// <param name="defaultVal">�������ڸò���ʱ���ص�Ĭ��ֵ</param>
        /// <returns></returns>
        public static int GetRequestVal(string keyName, int defaultVal)
        {
            string rv = HttpContext.Current.Request[keyName];
            return Tools.GetInt(rv, defaultVal);
        }*/

        /// <summary>
        /// �õ�һ��ϵͳ�������ֵ
        /// </summary>
        /// <param name="keyName">����������</param>
        /// <param name="defaultVal">�ڲ����ڸ�������ʱ���ص�Ĭ��ֵ</param>
        /// <returns></returns>
        public static string GetAppSetting(string keyName, string defaultVal)
        {
            string rv = System.Configuration.ConfigurationManager.AppSettings[keyName];
            return Tools.GetStr(rv, defaultVal);
        }

        /// <summary>
        /// �õ�һ��ϵͳ�������ֵ
        /// </summary>
        /// <param name="keyName">����������</param>
        /// <param name="defaultVal">�ڲ����ڸ�������ʱ���ص�Ĭ��ֵ</param>
        /// <returns></returns>
        public static int GetAppSetting(string keyName, int defaultVal)
        {
            string rv = System.Configuration.ConfigurationManager.AppSettings[keyName];
            return Tools.GetInt(rv, defaultVal);
        }

        /// <summary>
        /// �õ�һ�������ַ����������ֵ
        /// <para>�����ò�����ʱ������Null</para>
        /// </summary>
        /// <param name="keyName">����������</param>
        /// <returns></returns>
        public static string GetConnStrConfig(string keyName)
        {
            if (ConfigurationManager.ConnectionStrings[keyName] != null)
                return System.Configuration.ConfigurationManager.ConnectionStrings[keyName].ConnectionString;
            return null;
        }

        /// <summary>
        /// ����ַ���ֵ��ǰNλ�ַ�
        /// </summary>
        /// <param name="src">ָ�����ַ���</param>
        /// <param name="len">ָ���ĳ���</param>
        /// <returns></returns>
        public static string GetLenthStr(string src, int len)
        {
            if (src.Length > len)
                return src.Substring(0, len);
            return src;
        }

        /// <summary>
        /// ���ַ������б��룬�Ա�֤SQL�����İ�ȫ��
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