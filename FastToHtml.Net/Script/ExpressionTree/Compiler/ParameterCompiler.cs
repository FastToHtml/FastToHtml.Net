using FastToHtml.Net.Script.ExpressionTree.Enum;
using FastToHtml.Net.Script.Statement.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FastToHtml.Net.Script.ExpressionTree.Compiler
{
    /// <summary>
    /// 参数处理器
    /// </summary>
    public sealed class ParameterCompiler : BaseExpressionCompiler<ParameterExpression>
        , IStatementable<ParameterExpression>
        , IValuable<ParameterExpression>
    {
        /// <summary>
        /// 获取语句
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public string GetStatement(ParameterExpression expression)
        {
            return GetValueStatement(GetValue(expression));
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public ExpressionValue GetValue(ParameterExpression expression)
        {
            return ExpressionValue.Create(ExpressionValueType.Expression, expression.Name);
        }
    }
}
