using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.ElementStyle.Attribute
{
    /// <summary>
    /// 样式
    /// </summary>
    public sealed class StyleAttribute : System.Attribute
    {
        /// <summary>
        /// 样式
        /// </summary>
        /// <param name="name"></param>
        public StyleAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; }
    }
}
