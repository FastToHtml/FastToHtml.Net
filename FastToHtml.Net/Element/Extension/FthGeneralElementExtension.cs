using FastToHtml.Net.Element.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Element.Extension
{
    /// <summary>
    /// 常规元素扩展
    /// </summary>
    public static class FthGeneralElementExtension
    {
        /// <summary>
        /// 完成定义并返回父元素
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static IFthContainerElement Done(this IFthGeneralElement element)
        {
            return element.Parent;
        }
    }
}
