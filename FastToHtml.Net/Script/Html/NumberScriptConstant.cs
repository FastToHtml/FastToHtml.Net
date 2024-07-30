using FastToHtml.Net.Element.Html;
using FastToHtml.Net.Script.Dependency;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FastToHtml.Net.Script.Html
{
    /// <summary>
    /// 数值脚本常量
    /// </summary>
    public sealed class NumberScriptConstant : BaseScript, IHaveNumberScriptExpression
    {

        /// <summary>
        /// 数值脚本常量
        /// </summary>
        public NumberScriptConstant(ScriptElement script, double value) : base(script)
        {
            Expression = System.Linq.Expressions.Expression.Constant(value);
            Value = value;
        }

        /// <summary>
        /// 表达式
        /// </summary>
        public System.Linq.Expressions.Expression Expression { get; }

        /// <summary>
        /// 值
        /// </summary>
        public double Value { get; }

        #region 运算

        /// <summary>
        /// 加
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static NumberScriptStatement operator +(NumberScriptConstant num1, NumberScriptStatement num2)
        {
            return new NumberScriptStatement(num1.Script, System.Linq.Expressions.Expression.Add(num1.Expression, num2.Expression));
        }

        /// <summary>
        /// 减
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static NumberScriptStatement operator -(NumberScriptConstant num1, NumberScriptStatement num2)
        {
            return new NumberScriptStatement(num1.Script, System.Linq.Expressions.Expression.Subtract(num1.Expression, num2.Expression));
        }

        /// <summary>
        /// 乘
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static NumberScriptStatement operator *(NumberScriptConstant num1, NumberScriptStatement num2)
        {
            return new NumberScriptStatement(num1.Script, System.Linq.Expressions.Expression.Multiply(num1.Expression, num2.Expression));
        }

        /// <summary>
        /// 除
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static NumberScriptStatement operator /(NumberScriptConstant num1, NumberScriptStatement num2)
        {
            return new NumberScriptStatement(num1.Script, System.Linq.Expressions.Expression.Divide(num1.Expression, num2.Expression));
        }

        #endregion

        #region 语句转换

        /// <summary>
        /// 将数值转为脚本常量
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator NumberScriptStatement(NumberScriptConstant constant)
        {
            return new NumberScriptStatement(constant.Script, constant.Expression);
        }

        #endregion
    }
}
