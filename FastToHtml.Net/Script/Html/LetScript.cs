using FastToHtml.Net.Element.Html;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Script.Html
{
    /// <summary>
    /// Let脚本
    /// </summary>
    public sealed class LetScript : BaseScript
    {
        private readonly BaseScriptVariable _variable;
        private readonly ScriptStatement? _statement;

        /// <summary>
        /// Let脚本
        /// </summary>
        public LetScript(ScriptElement script, BaseScriptVariable variable, ScriptStatement? statement) : base(script)
        {
            _variable = variable;
            _statement = statement;
        }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <returns></returns>
        protected override string OnRender()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("let ");
            sb.Append(_variable.Name);
            if (_statement != null)
            {
                sb.Append('=');
                sb.Append(_statement.Render());
            }
            sb.Append(';');
            return sb.ToString();
        }
    }
}
