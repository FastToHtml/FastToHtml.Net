using FastToHtml.Net.Element.Dependency;
using FastToHtml.Net.Element.Extension;
using FastToHtml.Net.Element.Html;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Script.Html
{
    /// <summary>
    /// 元素属性设置脚本
    /// </summary>
    public sealed class ElementPropertySetScript : BaseScript
    {
        private readonly IFthElement _element;
        private readonly string _propertyName;
        private readonly ScriptStatement _statement;

        /// <summary>
        /// 元素属性设置脚本
        /// </summary>
        /// <param name="script"></param>
        /// <param name="element"></param>
        /// <param name="propertyName"></param>
        public ElementPropertySetScript(ScriptElement script, IFthElement element, string propertyName, ScriptStatement statement) : base(script)
        {
            _element = element;
            _propertyName = propertyName;
            _statement = statement;
        }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <returns></returns>
        protected override string OnRender()
        {
            var statement = _statement.Render();
            var eid = _element.GetElementInternalId();
            return $"eids.elements.{eid}.{_propertyName}={statement};";
        }
    }
}
