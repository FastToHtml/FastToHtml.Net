using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.ElementProperty.Dependency
{
    /// <summary>
    /// 包含属性集合
    /// </summary>
    public interface IHavePropertyCollection
    {
        /// <summary>
        /// 属性集合
        /// </summary>
        Dictionary<string, IFthProperty> Properties { get; }
    }
}
