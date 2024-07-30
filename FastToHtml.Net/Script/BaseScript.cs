using FastToHtml.Net.Element.Html;
using FastToHtml.Net.Script.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Script
{
    /// <summary>
    /// 基础脚本对象
    /// </summary>
    public abstract class BaseScript : IFthScript
    {
        /// <summary>
        /// 基础脚本对象
        /// </summary>
        /// <param name="script"></param>
        protected BaseScript(ScriptElement script)
        {
            Script = script;
        }

        /// <summary>
        /// 脚本元素
        /// </summary>
        public ScriptElement Script { get; }

        #region 渲染

        /// <summary>
        /// 渲染
        /// </summary>
        /// <returns></returns>
        public string Render()
        {
            return OnRender();
        }

        /// <summary>
        /// 渲染
        /// </summary>
        protected virtual string OnRender() { throw new NotImplementedException(); }

        #endregion
    }
}
