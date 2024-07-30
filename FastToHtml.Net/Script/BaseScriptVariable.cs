using FastToHtml.Net.Element.Html;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Linq;

namespace FastToHtml.Net.Script
{
    /// <summary>
    /// 脚本变量
    /// </summary>
    public abstract class BaseScriptVariable : BaseScript
    {
        /// <summary>
        /// 脚本变量
        /// </summary>
        /// <param name="script"></param>
        protected BaseScriptVariable(ScriptElement script, Type type) : base(script)
        {
            Name = script.GetNewVariableName();
            Expression = Expression.Parameter(type, Name);
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 表达式
        /// </summary>
        public Expression Expression { get; }
    }
}
