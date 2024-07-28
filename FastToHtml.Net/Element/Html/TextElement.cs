using FastToHtml.Net.Element.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Element.Html
{
    /// <summary>
    /// 文本元素
    /// </summary>
    public sealed class TextElement : BaseGeneralElement
    {
        /// <summary>
        /// 文本元素
        /// </summary>
        /// <param name="parent"></param>
        public TextElement(IFthContainerElement parent, string text) : base(parent)
        {
            Text = text;
        }

        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <returns></returns>
        protected override string OnRender()
        {
            return Text;
        }
    }
}
