using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using Microsoft.Win32.SafeHandles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace System.MES.Utils
{
    /// <summary>
    /// 目录、文件与文件内容相关，常用的处理方法集合。
    /// </summary>
    public class FileHelper
    {
        #region Path & Directory & File

        /// <summary>
        /// 获得指定（文件或目录）相对路径的物理路径。
        /// <para>支持 Web 程序、Windows 服务程序、控制台等程序。</para>
        /// </summary>
        /// <param name="path">相对路径</param>
        /// <returns>返回指定相对路径的物理路径（异常时返回值为 Null）。</returns>
        public static string GetMapPath(string path)
        {
            /*try
            {
                if (HttpContext.Current != null)
                    return HttpContext.Current.Server.MapPath(path);
                else
                    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
            }
            catch (Exception ex)
            {
                LogHelper.Error("Sxmobi.FileHelper", null, ex);
                return null;
            }*/
            return null;
        }

        /// <summary>
        /// 确保目录存在。
        /// <para>如果目录不存在，则创建目录（包括上级目录）。</para>
        /// </summary>
        /// <param name="path">目录路径（不含文件名）</param>
        /// <returns>返回一个 Boolean 值，如果目录不存在且创建目录出现异常时，返回值为 False。</returns>
        public static bool EnsureDir(string path)
        {
            try
            {
                if (Directory.Exists(path))
                    return true;
                if (EnsureDir(Directory.GetParent(path).ToString()))
                {
                    Directory.CreateDirectory(path);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 确保文件存在。
        /// <para>如果文件目录不存在，则创建目录（包括上级目录）。</para>
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>返回一个 Boolean 值，如果目录或文件不存在且创建它们出现异常时，返回值为 False。</returns>
        public static bool EnsureFile(string path)
        {
            try
            {
                if (File.Exists(path))
                    return true;
                if (EnsureDir(Directory.GetParent(path).ToString()))
                {
                    File.Create(path).Close();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region Text 相关

        /// <summary>
        /// 将默认编码类型（Unicode）的字符串，追加至指定文件。
        /// <para>系统推荐使用默认的 Unicode 编码类型格式来进行文字的读取与写入。</para>
        /// <para>方法将确保目录与文件存在</para>
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="text">需要写入的字符</param>
        /// <param name="isNewLine">指定是否将字符串写入新行</param>
        /// <returns>返回一个 Boolean 值，如果指定的目录、文件不存在且创建它们（或写入字符时）出现异常，返回值为 False。</returns>
        public static bool AddFileText(string path, string text, bool isNewLine)
        {
            return AddFileText(path, Encoding.Unicode, text, isNewLine);
        }

        /// <summary>
        /// 将指定编码类型的字符串，追加至指定文件。
        /// <para>方法将确保目录与文件存在。</para>
        /// <para>系统推荐使用默认的 Unicode 编码类型格式来进行文字的读取与写入。</para>
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="encodingType">编码类型</param>
        /// <param name="text">需要写入的字符</param>
        /// <param name="isNewLine">指定是否将字符串写入新行</param>
        /// <returns>返回一个 Boolean 值，如果指定的目录、文件不存在且创建它们（或写入字符时）出现异常，返回值为 False。</returns>
        public static bool AddFileText(string path, Encoding encodingType, string text, bool isNewLine)
        {
            if (!EnsureFile(path))
                return false;

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (StreamWriter sw = new StreamWriter(fs, encodingType))
                    {
                        if (isNewLine)
                            sw.WriteLine(text);
                        else
                            sw.Write(text);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 将默认编码类型（Unicode）的字符串，写入指定文件。
        /// <para>方法将确保目录与文件存在。</para>
        /// <para>系统推荐使用默认的 Unicode 编码类型格式来进行文字的读取与写入。</para>
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="text">需要写入的字符</param>
        /// <returns>返回一个 Boolean 值，如果指定的目录、文件不存在且创建它们（或写入字符时）出现异常，返回值为 False。</returns>
        public static bool SetFileText(string path, string text)
        {
            return SetFileText(path, Encoding.Unicode, text);
        }

        /// <summary>
        /// 将指定编码类型的字符串，写入指定文件。
        /// <para>方法将确保目录与文件存在。</para>
        /// <para>系统推荐使用默认的 Unicode 编码类型格式来进行文字的读取与写入。</para>
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="encodingType">编码类型</param>
        /// <param name="text">需要写入的字符</param>
        /// <returns>返回一个 Boolean 值，如果指定的目录、文件不存在且创建它们（或写入字符时）出现异常，返回值为 False。</returns>
        public static bool SetFileText(string path, Encoding encodingType, string text)
        {
            if (!EnsureDir(Directory.GetParent(path).ToString()))
                return false;

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (StreamWriter sw = new StreamWriter(fs, encodingType))
                    {
                        sw.Write(text);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 依据默认编码类型（Unicode），获取指定文件、指定范围的字符。
        /// <para>系统推荐使用默认的 Unicode 编码类型格式来进行文字的读取与写入。</para>
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="index">指定要获取内容的起始索引位置（例如文件内容：“类型 FileHelper 是...”，如果 index 设置为 3，则取得字符串“FileHelper 是...”）</param>
        /// <param name="count">指定要获取内容的长度，内容读取长度设置不宜过大，以避免内存溢出</param>
        /// <returns>返回 String 类型值，当文件不存在或其它异常时，返回值为 Null。</returns>
        public static string GetFileText(string path, int index, int count)
        {
            return GetFileText(path, Encoding.Unicode, index, count);
        }

        /// <summary>
        /// 依据指定的编码类型，获取指定文件、指定范围的字符。
        /// <para>系统推荐使用默认的 Unicode 编码类型格式来进行文字的读取与写入。</para>
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="encodingType">编码类型</param>
        /// <param name="index">指定要获取内容的起始索引位置（例如文件内容：“类型 FileHelper 是...”，如果 index 设置为 3，则取得字符串“FileHelper 是...”）</param>
        /// <param name="count">指定要获取内容的长度，内容读取长度设置不宜过大，以避免内存溢出</param>
        /// <returns>返回 String 类型值，当文件不存在或其它异常时，返回值为 Null。</returns>
        public static string GetFileText(string path, Encoding encodingType, int index, int count)
        {
            try
            {
                if (!File.Exists(path))
                    return null;

                int maxReads = 10000;
                char[] tempChars = new char[maxReads];
                char[] chars = new char[count];
                int loopCount = index / maxReads;
                int tempIndex = index % maxReads;
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader sr = new StreamReader(fs, encodingType))
                    {
                        // 如果起始索引超过 1W 个字符，则以 1W 个字符为单位，循环丢弃起始索引之前的所有字符，以避免内存开销过大。
                        while (loopCount-- > 0)
                            sr.ReadBlock(tempChars, 0, maxReads);
                        sr.ReadBlock(tempChars, 0, tempIndex);

                        sr.ReadBlock(chars, 0, count);
                    }
                }
                return new string(chars);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region Binary 相关

        /// <summary>
        /// 基于默认编码类型（Unicode），将字节数组追加至指定的二进制文件
        /// </summary>
        /// <param name="path">二进制文件</param>
        /// <param name="bytes">字节数组</param>
        /// <returns>返回一个 Boolean 值，如果指定的目录、文件不存在且创建它们（或写入二进制数据时）出现异常，返回值为 False。</returns>
        public static bool AddFileBinary(string path, byte[] bytes)
        {
            return AddFileBinary(path, Encoding.Unicode, bytes);
        }

        /// <summary>
        /// 基于所提供编码类型，将字节数组追加至指定的二进制文件
        /// </summary>
        /// <param name="path">二进制文件</param>
        /// <param name="encodingType">编码类型</param>
        /// <param name="bytes">字节数组</param>
        /// <returns>返回一个 Boolean 值，如果指定的目录、文件不存在且创建它们（或写入二进制数据时）出现异常，返回值为 False。</returns>
        public static bool AddFileBinary(string path, Encoding encodingType, byte[] bytes)
        {
            if (!EnsureDir(Directory.GetParent(path).ToString()))
                return false;

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs, encodingType))
                    {
                        bw.Write(bytes);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 基于默认编码类型（Unicode），将字节数组写入指定的二进制文件
        /// </summary>
        /// <param name="path">二进制文件</param>
        /// <param name="bytes">字节数组</param>
        /// <returns>返回一个 Boolean 值，如果指定的目录、文件不存在且创建它们（或写入二进制数据时）出现异常，返回值为 False。</returns>
        public static bool SetFileBinary(string path, byte[] bytes)
        {
            return SetFileBinary(path, Encoding.Unicode, bytes);
        }

        /// <summary>
        /// 基于所提供编码类型，将字节数组写入指定的二进制文件
        /// </summary>
        /// <param name="path">二进制文件</param>
        /// <param name="encodingType">编码类型</param>
        /// <param name="bytes">字节数组</param>
        /// <returns>返回一个 Boolean 值，如果指定的目录、文件不存在且创建它们（或写入二进制数据时）出现异常，返回值为 False。</returns>
        public static bool SetFileBinary(string path, Encoding encodingType, byte[] bytes)
        {
            if (!EnsureDir(Directory.GetParent(path).ToString()))
                return false;

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs, encodingType))
                    {
                        bw.Write(bytes);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 依据默认编码类型（Unicode），获取指定文件、指定范围的二进制数据。
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="index">指定要获取数据的起始索引位置</param>
        /// <param name="count">指定要获取数据的长度，内容读取长度设置不宜过大，以避免内存溢出</param>
        /// <returns>返回 byte[] 类型值，当文件不存在或其它异常时，返回值为 Null。</returns>
        public static byte[] GetFileBinary(string path, int index, int count)
        {
            return GetFileBinary(path, Encoding.Unicode, index, count);
        }

        /// <summary>
        /// 依据指定的编码类型，获取指定文件、指定范围的二进制数据。
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="encodingType">编码类型</param>
        /// <param name="index">指定要获取数据的起始索引位置</param>
        /// <param name="count">指定要获取数据的长度，内容读取长度设置不宜过大，以避免内存溢出</param>
        /// <returns>返回 byte[] 类型值，当文件不存在或其它异常时，返回值为 Null。</returns>
        public static byte[] GetFileBinary(string path, Encoding encodingType, int index, int count)
        {
            try
            {
                if (!File.Exists(path))
                    return null;

                int maxReads = 1024000;
                byte[] bytes = new byte[count];
                int loopCount = index / maxReads;
                int tempIndex = index % maxReads;
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (BinaryReader br = new BinaryReader(fs, encodingType))
                    {
                        // 如果起始索引超过1M（1000K），则以1M为单位，循环丢弃起始索引之前的所有字节，以避免内存开销过大。
                        while (loopCount-- > 0)
                            br.ReadBytes(maxReads);
                        br.ReadBytes(tempIndex);

                        bytes = br.ReadBytes(count);
                    }
                }
                return bytes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}