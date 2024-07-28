using FastToHtml.Net.Element.Dependency;
using FastToHtml.Net.ElementProperty.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Element
{
    /// <summary>
    /// 基础元素
    /// </summary>
    public abstract class BaseElement : IFthElement
    {
        /// <summary>
        /// 基础元素
        /// </summary>
        protected BaseElement()
        {
            Properties = new Dictionary<string, IFthProperty>();
        }

        /// <summary>
        /// 属性集合
        /// </summary>
        public Dictionary<string, IFthProperty> Properties { get; }

        #region HTML渲染

        /// <summary>
        /// HTML渲染
        /// </summary>
        /// <returns></returns>
        public string Render()
        {
            return OnRender();
        }

        /// <summary>
        /// HTML渲染
        /// </summary>
        protected abstract string OnRender();

        #endregion

    }
}
