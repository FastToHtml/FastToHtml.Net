using FastToHtml.Net.Element.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Element
{
    /// <summary>
    /// 容器元素
    /// </summary>
    public abstract class BaseContainerElement : BaseElement, IFthContainerElement
    {
        /// <summary>
        /// 容器元素
        /// </summary>
        protected BaseContainerElement()
        {
            Children = new ElementCollection();
        }

        /// <summary>
        /// 子元素集合
        /// </summary>
        public ElementCollection Children { get; }
    }
}
