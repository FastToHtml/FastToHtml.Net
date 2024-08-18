using FastToHtml.Net.Common.Dependency;
using FastToHtml.Net.Element;
using FastToHtml.Net.Element.Dependency;
using FastToHtml.Net.Element.Extension;
using FastToHtml.Net.ElementAttribute;
using FastToHtml.Net.Script.Common;
using FastToHtml.Net.Script.Dependency;
using FastToHtml.Net.Script.Html;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FastToHtml.Net.Element.Html
{
    /// <summary>
    /// 脚本元素
    /// </summary>
    public sealed class ScriptElement : BaseGeneralElement
    {
        /// <summary>
        /// 变量前缀
        /// </summary>
        private const string VARIABLE_PREFIX = "v";

        private readonly FunctionScript _globalScript;
        private IFthCollectionScript _currentCollectionScript;
        private readonly PageElement _page;

        /// <summary>
        /// 脚本集合
        /// </summary>
        public ScriptElement(HeadElement parent) : base(parent)
        {
            _page = parent.Page;
            // 全局脚本
            _globalScript = new FunctionScript(this);
            _globalScript.Scripts.Add(new EidSuportedScript(this));
            // 设置当前脚本集合
            _currentCollectionScript = _globalScript;
            this.Property("type", "text/javascript");
        }

        /// <summary>
        /// 全局脚本
        /// </summary>
        public List<IFthScript> Scripts => _currentCollectionScript.Scripts;

        /// <summary>
        /// 获取新的变量名称
        /// </summary>
        /// <returns></returns>
        public string GetNewVariableName()
        {
            var idx = _page.GetNewSerialNumber();
            return VARIABLE_PREFIX + idx;
        }

        /// <summary>
        /// 设置当前脚本集合
        /// </summary>
        /// <param name="collectionScript"></param>
        public void SetCurrentCollection(IFthCollectionScript collectionScript)
        {
            if (!_globalScript.Scripts.Contains(collectionScript))
            {
                _globalScript.Scripts.Add(collectionScript);
            }
            _currentCollectionScript = collectionScript;
        }

        /// <summary>
        /// 清理当前脚本集合
        /// </summary>
        public void ClearCurrentCollection()
        {
            _currentCollectionScript = _globalScript;
        }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <returns></returns>
        protected override string OnRender()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script");
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
            foreach (var script in _globalScript.Scripts)
            {
                var scriptContent = script.Render();
                var cleanScriptContent = FastToHtmlHelper.GetCleanScript(scriptContent);
                sb.Append(cleanScriptContent);
            }
            sb.Append("</script>");
            return sb.ToString();
        }
    }
}
