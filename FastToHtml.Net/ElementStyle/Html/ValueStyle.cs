using FastToHtml.Net.ElementStyle.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.ElementStyle.Html
{
    /// <summary>
    /// 值样式
    /// </summary>
    public sealed class ValueStyle : IFthStyle
    {
        /// <summary>
        /// 值样式
        /// </summary>
        public ValueStyle(string value)
        {
            Value = value;
        }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; }
    }
}
