using FastToHtml.Net.Common.Dependency;
using FastToHtml.Net.Element.Dependency;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FastToHtml.Net.Element
{
    /// <summary>
    /// 元素集合
    /// </summary>
    public class ElementCollection : Collection<IFthGeneralElement>, IRenderable
    {
        /// <summary>
        /// 渲染
        /// </summary>
        /// <returns></returns>
        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IFthElement element in this)
            {
                sb.Append(element.Render());
            }
            return sb.ToString();
        }

    }
}
