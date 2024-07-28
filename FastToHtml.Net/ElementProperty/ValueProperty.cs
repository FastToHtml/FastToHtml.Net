using FastToHtml.Net.ElementProperty.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.ElementAttribute
{
    /// <summary>
    /// 值属性
    /// </summary>
    public sealed class ValueProperty : IFthProperty
    {
        /// <summary>
        /// 值属性
        /// </summary>
        public ValueProperty(string value)
        {
            Value = value;
        }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; }
    }
}
