using FastToHtml.Net.Common.Dependency;
using FastToHtml.Net.ElementProperty.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Element.Dependency
{
    /// <summary>
    /// FTH元素
    /// </summary>
    public interface IFthElement : IRenderable, IHavePropertyCollection
    {
    }
}
