using FastToHtml.Net.Element.Html;
using System;

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
    }
}
