using FastToHtml.Net.Element.Dependency;
using FastToHtml.Net.ElementAttribute;
using FastToHtml.Net.ElementProperty.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Element
{
    /// <summary>
    /// 带标签的容器元素
    /// </summary>
    public abstract class BaseTagContainerElement : BaseContainerElement, IHaveElementTag
    {
        /// <summary>
        /// 带标签的容器元素
        /// </summary>
        /// <param name="parent"></param>
        protected BaseTagContainerElement() : base()
        {
        }

        /// <summary>
        /// 标签名称
        /// </summary>
        public abstract string TagName { get; }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <returns></returns>
        protected override string OnRender()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('<');
            sb.Append(TagName);
            foreach (var Property in Properties)
            {
                // 值类型
                if (Property.Value is ValueProperty valueProperty)
                {
                    sb.Append(' ');
                    sb.Append(Property.Key);
                    sb.Append("=\"");
                    sb.Append(valueProperty.Value);
                    sb.Append('"');
                }
            }
            sb.Append('>');
            sb.Append(Children.Render());
            sb.Append("</");
            sb.Append(TagName);
            sb.Append('>');
            return sb.ToString();
        }
    }
}
