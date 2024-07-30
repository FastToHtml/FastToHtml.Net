using FastToHtml.Net.Element.Html;
using FastToHtml.Net.ElementAttribute;
using FastToHtml.Net.Script.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Script.Html
{
    /// <summary>
    /// 函数
    /// </summary>
    public class FunctionScript : BaseScript, IFthCollectionScript
    {
        /// <summary>
        /// 函数
        /// </summary>
        /// <param name="script"></param>
        public FunctionScript(ScriptElement script) : base(script)
        {
            Scripts = new List<IFthScript>();
        }

        /// <summary>
        /// 脚本集合
        /// </summary>
        public List<IFthScript> Scripts { get; }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <returns></returns>
        protected override string OnRender()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("function(){");
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
