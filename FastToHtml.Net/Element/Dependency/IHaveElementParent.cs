using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Element.Dependency
{
    /// <summary>
    /// 含有父元素
    /// </summary>
    public interface IHaveElementParent
    {
        /// <summary>
        /// 父对象
        /// </summary>
        IFthContainerElement Parent { get; }
    }
}
