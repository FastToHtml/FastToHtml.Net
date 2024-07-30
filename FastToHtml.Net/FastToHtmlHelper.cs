using FastToHtml.Net.Element.Html;
using System;
using System.Text;

namespace FastToHtml.Net
{
    /// <summary>
    /// FTH助手
    /// </summary>
    public static class FastToHtmlHelper
    {
        /// <summary>
        /// 创建页面
        /// </summary>
        /// <returns></returns>
        public static PageElement CreatePage()
        {
            return new PageElement();
        }

        /// <summary>
        /// 获取整洁脚本
        /// </summary>
        /// <returns></returns>
        public static string GetCleanScript(string script)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder line = new StringBuilder();
            foreach (char chr in script)
            {
                switch (chr)
                {
                    case '\r': break;
                    case '\n':
                        string lineString = line.ToString().Trim();
                        line.Clear();
                        if (!lineString.StartsWith("//")) sb.Append(lineString);
                        break;
                    default:
                        line.Append(chr);
                        break;
                }
            }
            if (line.Length > 0)
            {
                string lineString = line.ToString().Trim();
                line.Clear();
                if (!lineString.StartsWith("//")) sb.Append(lineString);
            }
            return sb.ToString();
        }
    }
}
