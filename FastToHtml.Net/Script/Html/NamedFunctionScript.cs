using FastToHtml.Net.Element.Html;
using FastToHtml.Net.Script.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Script.Html
{
    /// <summary>
    /// 命名函数
    /// </summary>
    public sealed class NamedFunctionScript : FunctionScript
    {
        /// <summary>
        /// 命名函数
        /// </summary>
        /// <param name="script"></param>
        public NamedFunctionScript(ScriptElement script, string name) : base(script)
        {
            Name = name;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <returns></returns>
        protected override string OnRender()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("function ");
            sb.Append(Name);
            sb.Append("(){");
            foreach (var script in Scripts)
            {
                var scriptContent = script.Render();
                var cleanScriptContent = FastToHtmlHelper.GetCleanScript(scriptContent);
                sb.Append(cleanScriptContent);
            }
            sb.Append("};");
            return sb.ToString();
        }
    }
}
