using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Element.Dependency
{
    /// <summary>
    /// 包含元素标签
    /// </summary>
    public interface IHaveElementTag
    {
        /// <summary>
        /// 标签名称
        /// </summary>
        string TagName { get; }
    }
}
