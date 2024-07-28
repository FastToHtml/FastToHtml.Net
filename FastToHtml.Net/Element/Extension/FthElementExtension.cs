using FastToHtml.Net.Element.Dependency;
using FastToHtml.Net.Element.Html;
using FastToHtml.Net.ElementAttribute;
using FastToHtml.Net.ElementStyle;
using FastToHtml.Net.ElementStyle.Html;
using FastToHtml.Net.Script;
using FastToHtml.Net.Style;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Element.Extension
{
    /// <summary>
    /// 常规元素扩展
    /// </summary>
    public static class FthElementExtension
    {
        #region 属性

        /// <summary>
        /// 完成定义并返回父元素
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static TElement Property<TElement>(this TElement element, string name, string value)
            where TElement : IFthElement
        {
            element.Properties[name] = new ValueProperty(value);
            return element;
        }

        #endregion

        #region 样式

        /// <summary>
        /// 定义样式
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static TElement Style<TElement>(this TElement element, StyleSet styles)
            where TElement : IFthElement
        {
            StringBuilder sb = new StringBuilder();
            foreach (var style in styles)
            {
                if(style.Value is ValueStyle valueStyle)
                {
                    sb.Append(style.Key);
                    sb.Append(":");
                    sb.Append(valueStyle.Value);
                    sb.Append(";");
                }
            }
            element.Property("style", sb.ToString());
            return element;
        }

        /// <summary>
        /// 获取样式集合
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static StyleCollection GetPageStyles(this IFthElement element)
        {
            return element switch
            {
                PageElement page => page.Head().GetPageStyles(),
                BodyElement body => body.Page.GetPageStyles(),
                HeadElement header => header.Styles,
                IFthGeneralElement generalElement => generalElement.Parent.GetPageStyles(),
                _ => throw new Exception($"Element type {element.GetType().FullName} not supported method 'GetStyles'."),
            };
        }

        #endregion

        #region 脚本

        /// <summary>
        /// 获取脚本集合
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static ScriptCollection GetPageScripts(this IFthElement element)
        {
            return element switch
            {
                PageElement page => page.Head().GetPageScripts(),
                BodyElement body => body.Page.GetPageScripts(),
                HeadElement header => header.Scripts,
                IFthGeneralElement generalElement => generalElement.Parent.GetPageScripts(),
                _ => throw new Exception($"Element type {element.GetType().FullName} not supported method 'GetScripts'."),
            };
        }

        #endregion
    }
}
