using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FastToHtml.Net.Script.Dependency
{
    /// <summary>
    /// 包含脚本表达式
    /// </summary>
    public interface IHaveScriptExpression
    {
        /// <summary>
        /// 表达式
        /// </summary>
        System.Linq.Expressions.Expression Expression { get; }
    }
}
