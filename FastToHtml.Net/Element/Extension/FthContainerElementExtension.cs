using FastToHtml.Net.Element.Dependency;
using FastToHtml.Net.Element.Html;
using FastToHtml.Net.ElementAttribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Element.Extension
{
    /// <summary>
    /// 常规元素扩展
    /// </summary>
    public static class FthContainerElementExtension
    {
        #region div

        /// <summary>
        /// 创建一个Div元素
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static DivElement Div(this IFthContainerElement element)
        {
            DivElement div = new DivElement(element);
            element.Children.Add(div);
            return div;
        }

        #endregion

        #region 文本

        /// <summary>
        /// 设置元素文本
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static TElement Text<TElement>(this TElement element, string text)
            where TElement : IFthContainerElement
        {
            TextElement div = new TextElement(element, text);
            element.Children.Add(div);
            return element;
        }

        #endregion
    }
}
