using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Common
{
    public class StringUtil
    {
        /// <summary>
        /// 按固定长度截取字符串
        /// </summary>
        /// <param name="source">需截取的字符串</param>
        /// <param name="length">截取长度</param>
        /// <returns></returns>
        public static string Truncate(string source, int length)
        {
            string temp = string.Empty;
            if (Encoding.Default.GetBytes(source).Length <= length)
                return source;
            else
            {
                int t = 0;
                char[] q = source.ToCharArray();
                for (int i = 0; i < source.Length && t < length; i++)
                {
                        temp += q[i];
                    if ((int)q[i] >= 0x4E00 && (int)q[i] <= 0x9FA5)//汉字两个字节
                        t += 2;
                    else
                        t++;
                }
            }

            return temp + "...";
        }
    }
}
