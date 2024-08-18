using FastToHtml.Net.Element.Html;
using FastToHtml.Net.ElementStyle;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Style
{
    /// <summary>
    /// 层叠样式表
    /// </summary>
    public class CascadingStyleSheet
    {

        /// <summary>
        /// 层叠样式表
        /// </summary>
        /// <param name="element"></param>
        /// <param name="name"></param>
        public CascadingStyleSheet(StyleElement element, string name)
        {
            Element = element;
            Name = name;
            Styles = new StyleSet();
        }

        /// <summary>
        /// 层叠样式表
        /// </summary>
        /// <param name="element"></param>
        /// <param name="name"></param>
        /// <param name="styles"></param>
        public CascadingStyleSheet(StyleElement element, string name, StyleSet styles)
        {
            Element = element;
            Name = name;
            Styles = styles;
        }

        /// <summary>
        /// 样式元素
        /// </summary>
        public StyleElement Element { get; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 样式集
        /// </summary>
        public StyleSet Styles { get; }
    }
}
