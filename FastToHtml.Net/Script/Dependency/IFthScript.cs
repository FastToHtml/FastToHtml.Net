using FastToHtml.Net.Common.Dependency;
using FastToHtml.Net.Element.Html;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Script.Dependency
{
    /// <summary>
    /// Fth脚本
    /// </summary>
    public interface IFthScript : IRenderable
    {
        /// <summary>
        /// 脚本元素
        /// </summary>
        ScriptElement Script { get; }
    }
}
