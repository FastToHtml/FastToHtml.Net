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
    public class PseudoCascadingStyleSheet : CascadingStyleSheet
    {

        /// <summary>
        /// 层叠样式表
        /// </summary>
        /// <param name="element"></param>
        /// <param name="name"></param>
        /// <param name="pseudo"></param>
        public PseudoCascadingStyleSheet(StyleElement element, string name, string pseudo) : base(element, name)
        {
            Pseudo = pseudo;
        }

        /// <summary>
        /// 层叠样式表
        /// </summary>
        /// <param name="element"></param>
        /// <param name="name"></param>
        /// <param name="pseudo"></param>
        /// <param name="styles"></param>
        public PseudoCascadingStyleSheet(StyleElement element, string name, string pseudo, StyleSet styles) : base(element, name, styles)
        {
            Pseudo = pseudo;
        }

        /// <summary>
        /// 伪类
        /// </summary>
        public string Pseudo { get; }

    }
}
