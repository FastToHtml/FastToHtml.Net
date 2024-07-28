using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Element.Html
{
    /// <summary>
    /// 主体元素
    /// </summary>
    public sealed class BodyElement : BaseTagContainerElement
    {
        /// <summary>
        /// 主体元素
        /// </summary>
        public BodyElement(PageElement page)
        {
            Page = page;
        }

        /// <summary>
        /// 页面
        /// </summary>
        public PageElement Page { get; }

        /// <summary>
        /// 标签名称
        /// </summary>
        public override string TagName => "body";
    }
}
