using FastToHtml.Net.Element.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Element
{
    /// <summary>
    /// 基础带标签的普通容器元素
    /// </summary>
    public abstract class BaseTagGeneralContainerElement : BaseTagContainerElement, IFthGeneralElement
    {
        /// <summary>
        /// 基础带标签的普通容器元素
        /// </summary>
        /// <param name="parent"></param>
        protected BaseTagGeneralContainerElement(IFthContainerElement parent)
        {
            Parent = parent;
        }

        /// <summary>
        /// 父元素
        /// </summary>
        public IFthContainerElement Parent { get; }
    }
}
