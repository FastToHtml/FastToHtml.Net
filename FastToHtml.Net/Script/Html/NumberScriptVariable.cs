using FastToHtml.Net.Element.Html;
using FastToHtml.Net.Script.Dependency;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FastToHtml.Net.Script.Html
{
    /// <summary>
    /// 数值脚本变量
    /// </summary>
    public sealed class NumberScriptVariable : BaseScriptVariable
    {
        private static readonly Type _doubleType = typeof(double);

        private readonly ScriptElement _script;

        /// <summary>
        /// 数值脚本变量
        /// </summary>
        /// <param name="expression"></param>
        public NumberScriptVariable(ScriptElement script) : base(script, _doubleType)
        {
            _script = script;
        }

        /// <summary>
        /// 设置值
        /// </summary>
        public NumberScriptVariable SetValue(NumberScriptStatement statement)
        {
            NumberScriptStatement scriptStatement = new NumberScriptStatement(_script, Expression.Assign(Expression, statement.Expression));
            _script.Scripts.Add(scriptStatement);
            return this;
        }

        #region 运算

        /// <summary>
        /// 加
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static NumberScriptStatement operator +(NumberScriptVariable num1, double num2)
        {
            NumberScriptConstant numberScriptConstant = new NumberScriptConstant(num1.Script, num2);
            return new NumberScriptStatement(num1.Script, Expression.Add(num1.Expression, numberScriptConstant.Expression));
        }

        /// <summary>
        /// 减
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static NumberScriptStatement operator -(NumberScriptVariable num1, double num2)
        {
            NumberScriptConstant numberScriptConstant = new NumberScriptConstant(num1.Script, num2);
            return new NumberScriptStatement(num1.Script, Expression.Subtract(num1.Expression, numberScriptConstant.Expression));
        }

        /// <summary>
        /// 乘
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static NumberScriptStatement operator *(NumberScriptVariable num1, double num2)
        {
            NumberScriptConstant numberScriptConstant = new NumberScriptConstant(num1.Script, num2);
            return new NumberScriptStatement(num1.Script, Expression.Multiply(num1.Expression, numberScriptConstant.Expression));
        }

        /// <summary>
        /// 除
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static NumberScriptStatement operator /(NumberScriptVariable num1, double num2)
        {
            NumberScriptConstant numberScriptConstant = new NumberScriptConstant(num1.Script, num2);
            return new NumberScriptStatement(num1.Script, Expression.Divide(num1.Expression, numberScriptConstant.Expression));
        }

        #endregion

        #region 语句转换

        /// <summary>
        /// 将数值转为脚本常量
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator NumberScriptStatement(NumberScriptVariable variable)
        {
            return new NumberScriptStatement(variable.Script, variable.Expression);
        }

        #endregion

    }
}
