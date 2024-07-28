using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Element.Dependency
{
    /// <summary>
    /// 包含元素集合
    /// </summary>
    public interface IHaveElementCollection
    {
        /// <summary>
        /// 子元素
        /// </summary>
        ElementCollection Children { get; }
    }
}
