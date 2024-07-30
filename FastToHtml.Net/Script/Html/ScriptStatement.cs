using FastToHtml.Net.Element.Html;
using FastToHtml.Net.Script.Dependency;
using FastToHtml.Net.Script.ExpressionTree;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FastToHtml.Net.Script.Html
{
    /// <summary>
    /// 脚本语句
    /// </summary>
    public class ScriptStatement : BaseScript, IHaveScriptExpression
    {
        private readonly ScriptElement _script;

        /// <summary>
        /// 脚本语句
        /// </summary>
        public ScriptStatement(ScriptElement script, Expression expression) : base(script)
        {
            _script = script;
            Expression = expression;
        }

        /// <summary>
        /// 表达式
        /// </summary>
        public Expression Expression { get; }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <returns></returns>
        protected override string OnRender()
        {
            return ExpressionHelper.GetStatement(Expression);
        }
    }
}
