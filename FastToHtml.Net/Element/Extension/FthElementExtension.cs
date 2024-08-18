using FastToHtml.Net.Element.Dependency;
using FastToHtml.Net.Element.Html;
using FastToHtml.Net.ElementAttribute;
using FastToHtml.Net.ElementStyle;
using FastToHtml.Net.ElementStyle.Html;
using FastToHtml.Net.Script.Html;
using FastToHtml.Net.Style;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

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
        /// <param name="cascadingStyleSheets"></param>
        /// <returns></returns>
        public static TElement Css<TElement>(this TElement element, params CascadingStyleSheet[] cascadingStyleSheets)
            where TElement : IFthElement
        {
            StringBuilder sb = new StringBuilder();
            foreach (var cascadingStyleSheet in cascadingStyleSheets)
            {
                if (!cascadingStyleSheet.Name.StartsWith(".")) { continue; }
                if (sb.Length > 0) { sb.Append(' '); }
                sb.Append(cascadingStyleSheet.Name[1..]);
            }
            element.Property("class", sb.ToString());
            return element;
        }

        /// <summary>
        /// 定义样式
        /// </summary>
        /// <param name="element"></param>
        /// <param name="styles"></param>
        /// <returns></returns>
        public static TElement Style<TElement>(this TElement element, StyleSet styles)
            where TElement : IFthElement
        {
            StringBuilder sb = new StringBuilder();
            foreach (var style in styles)
            {
                if (style.Value is ValueStyle valueStyle)
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
        public static StyleElement GetPageStyle(this IFthElement element)
        {
            return element switch
            {
                PageElement page => page.Head().GetPageStyle(),
                BodyElement body => body.Page.GetPageStyle(),
                HeadElement header => header.Styles,
                IFthGeneralElement generalElement => generalElement.Parent.GetPageStyle(),
                _ => throw new Exception($"Element type {element.GetType().FullName} not supported method 'GetStyles'."),
            };
        }

        /// <summary>
        /// 获取页面元素
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static PageElement GetPage(this IFthElement element)
        {
            return element switch
            {
                PageElement page => page,
                BodyElement body => body.Page,
                HeadElement header => header.Page,
                IFthGeneralElement generalElement => generalElement.Parent.GetPage(),
                _ => throw new Exception($"Element type {element.GetType().FullName} not supported method 'GetPage'."),
            };
        }

        /// <summary>
        /// 获取页面元素
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static BodyElement GetBody(this IFthElement element)
        {
            return element switch
            {
                PageElement page => page.Body(),
                BodyElement body => body,
                HeadElement header => header.Page.Body(),
                IFthGeneralElement generalElement => generalElement.Parent.GetBody(),
                _ => throw new Exception($"Element type {element.GetType().FullName} not supported method 'GetBody'."),
            };
        }

        /// <summary>
        /// 获取页面元素
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static HeadElement GetHead(this IFthElement element)
        {
            return element switch
            {
                PageElement page => page.Head(),
                BodyElement body => body.Page.GetHead(),
                HeadElement header => header,
                IFthGeneralElement generalElement => generalElement.Parent.GetHead(),
                _ => throw new Exception($"Element type {element.GetType().FullName} not supported method 'GetHead'."),
            };
        }

        #endregion

        #region 脚本

        /// <summary>
        /// 获取脚本集合
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static ScriptElement GetPageScript(this IFthElement element)
        {
            return element switch
            {
                PageElement page => page.Head().GetPageScript(),
                BodyElement body => body.Page.GetPageScript(),
                HeadElement header => header.Scripts,
                IFthGeneralElement generalElement => generalElement.Parent.GetPageScript(),
                _ => throw new Exception($"Element type {element.GetType().FullName} not supported method 'GetScripts'."),
            };
        }

        #endregion

        #region 事件

        /// <summary>
        /// 元素内置Id键值
        /// </summary>
        private const string EID_KEY = "e-id";

        /// <summary>
        /// 元素内置Id前缀
        /// </summary>
        private const string EID_PREFIX = "e";

        /// <summary>
        /// 获取脚本集合
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static TElement OnClick<TElement>(this TElement element, Action action)
            where TElement : IFthElement
        {
            // 元素挂载
            element.Mount();
            // 设置属性
            var pageScript = element.GetPageScript();
            var elementId = element.GetElementInternalId();
            var functionName = elementId + "_click";
            element.Property("onclick", functionName + "();");
            // 设置当前脚本集合为click函数
            NamedFunctionScript namedFunctionScript = new NamedFunctionScript(pageScript, functionName);
            pageScript.SetCurrentCollection(namedFunctionScript);
            // 执行脚本生成
            action();
            // 清除当前脚本集合
            pageScript.ClearCurrentCollection();
            return element;
        }

        /// <summary>
        /// 获取元素内部Id
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetElementInternalId(this IFthElement element)
        {
            if (!element.Properties.ContainsKey(EID_KEY)) { return string.Empty; }
            var property = element.Properties[EID_KEY];
            if (property is ValueProperty valueProperty) { return valueProperty.Value; }
            return string.Empty;
        }

        /// <summary>
        /// 挂载
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="element"></param>
        /// <returns></returns>
        public static TElement Mount<TElement>(this TElement element)
            where TElement : IFthElement
        {
            if (element.Properties.ContainsKey(EID_KEY)) { return element; }
            var page = element.GetPage();
            element.Properties[EID_KEY] = new ValueProperty(EID_PREFIX + page.GetNewSerialNumber());
            return element;
        }

        #endregion
    }
}
