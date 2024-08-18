using FastToHtml.Net.Element.Dependency;
using FastToHtml.Net.ElementStyle.Html;
using FastToHtml.Net.ElementStyle;
using FastToHtml.Net.Style;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Linq;

namespace FastToHtml.Net.Element.Html
{
    /// <summary>
    /// 样式元素
    /// </summary>
    public class StyleElement : BaseGeneralElement
    {
        /// <summary>
        /// 变量前缀
        /// </summary>
        private const string VARIABLE_PREFIX = "c";

        // 样式表
        private readonly List<CascadingStyleSheet> _cascadingStyleSheets;
        private readonly PageElement _page;

        /// <summary>
        /// 样式元素
        /// </summary>
        /// <param name="parent"></param>
        public StyleElement(HeadElement parent) : base(parent)
        {
            _cascadingStyleSheets = new List<CascadingStyleSheet>();
            _page = parent.Page;
        }

        /// <summary>
        /// 获取新的样式名称
        /// </summary>
        /// <returns></returns>
        public string GetNewCssName()
        {
            var idx = _page.GetNewSerialNumber();
            return VARIABLE_PREFIX + idx;
        }

        #region 创建样式

        /// <summary>
        /// 创建样式表
        /// </summary>
        /// <returns></returns>
        public CascadingStyleSheet CreateCss()
        {
            var name = "." + GetNewCssName();
            var css = new CascadingStyleSheet(this, name);
            _cascadingStyleSheets.Add(css);
            return css;
        }

        /// <summary>
        /// 创建样式表
        /// </summary>
        /// <returns></returns>
        public CascadingStyleSheet CreateCss(StyleSet styles)
        {
            var name = "." + GetNewCssName();
            var css = new CascadingStyleSheet(this, name, styles);
            _cascadingStyleSheets.Add(css);
            return css;
        }

        /// <summary>
        /// 创建元素样式表
        /// </summary>
        /// <returns></returns>
        public CascadingStyleSheet CreateElementCss(string elementName)
        {
            var css = new CascadingStyleSheet(this, elementName);
            _cascadingStyleSheets.Add(css);
            return css;
        }

        /// <summary>
        /// 创建元素样式表
        /// </summary>
        /// <returns></returns>
        public CascadingStyleSheet CreateElementCss(string elementName, StyleSet styles)
        {
            var css = new CascadingStyleSheet(this, elementName, styles);
            _cascadingStyleSheets.Add(css);
            return css;
        }

        #endregion

        /// <summary>
        /// 渲染
        /// </summary>
        /// <returns></returns>
        protected override string OnRender()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<style>");
            foreach (var cascadingStyleSheet in _cascadingStyleSheets)
            {
                sb.Append(cascadingStyleSheet.Name);
                sb.Append('{');
                foreach (var style in cascadingStyleSheet.Styles)
                {
                    if (style.Value is ValueStyle valueStyle)
                    {
                        sb.Append(style.Key);
                        sb.Append(":");
                        sb.Append(valueStyle.Value);
                        sb.Append(";");
                    }
                }
                sb.Append('}');
            }
            sb.Append("</style>");
            return sb.ToString();
        }
    }
}
