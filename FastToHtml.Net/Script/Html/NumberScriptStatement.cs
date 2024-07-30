using FastToHtml.Net.Element.Html;
using FastToHtml.Net.Script.Dependency;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FastToHtml.Net.Script.Html
{
    /// <summary>
    /// 数值脚本语句
    /// </summary>
    public sealed class NumberScriptStatement : ScriptStatement, IHaveNumberScriptExpression
    {
        /// <summary>
        /// 数值脚本语句
        /// </summary>
        /// <param name="script"></param>
        /// <param name="expression"></param>
        public NumberScriptStatement(ScriptElement script, Expression expression) : base(script, expression)
        {
        }

        #region 运算

        /// <summary>
        /// 加
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static NumberScriptStatement operator +(NumberScriptStatement num1, NumberScriptStatement num2)
        {
            return new NumberScriptStatement(num1.Script, System.Linq.Expressions.Expression.Add(num1.Expression, num2.Expression));
        }

        /// <summary>
        /// 减
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static NumberScriptStatement operator -(NumberScriptStatement num1, NumberScriptStatement num2)
        {
            return new NumberScriptStatement(num1.Script, System.Linq.Expressions.Expression.Subtract(num1.Expression, num2.Expression));
        }

        /// <summary>
        /// 乘
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static NumberScriptStatement operator *(NumberScriptStatement num1, NumberScriptStatement num2)
        {
            return new NumberScriptStatement(num1.Script, System.Linq.Expressions.Expression.Multiply(num1.Expression, num2.Expression));
        }

        /// <summary>
        /// 除
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static NumberScriptStatement operator /(NumberScriptStatement num1, NumberScriptStatement num2)
        {
            return new NumberScriptStatement(num1.Script, System.Linq.Expressions.Expression.Divide(num1.Expression, num2.Expression));
        }

        #endregion
    }
}
