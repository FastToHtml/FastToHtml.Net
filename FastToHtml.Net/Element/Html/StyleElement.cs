using FastToHtml.Net.Element.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Element.Html
{
    /// <summary>
    /// 样式元素
    /// </summary>
    public class StyleElement : BaseGeneralElement
    {
        /// <summary>
        /// 样式元素
        /// </summary>
        /// <param name="parent"></param>
        public StyleElement(IFthContainerElement parent) : base(parent)
        {
        }

        protected override string OnRender()
        {
            throw new NotImplementedException();
        }
    }
}
