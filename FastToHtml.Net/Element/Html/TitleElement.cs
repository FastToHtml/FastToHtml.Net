using FastToHtml.Net.Element.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Element.Html
{
    /// <summary>
    /// Div元素
    /// </summary>
    public sealed class TitleElement : BaseTagGeneralContainerElement
    {
        /// <summary>
        /// Div元素
        /// </summary>
        /// <param name="parent"></param>
        public TitleElement(IFthContainerElement parent) : base(parent)
        {
        }

        /// <summary>
        /// 标签名称
        /// </summary>
        public override string TagName => "title";
    }
}
