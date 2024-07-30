using FastToHtml.Net.Script.Statement.Builder;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FastToHtml.Net.Script.ExpressionTree
{
    /// <summary>
    /// 表达式助手
    /// </summary>
    public static class ExpressionHelper
    {
        /// <summary>
        /// 创建语句构建器
        /// </summary>
        /// <typeparam name="TExpression"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static StatementBuilder<TExpression> CreateStatementBuilder<TExpression>(TExpression expression)
            where TExpression : Expression
        {
            return new StatementBuilder<TExpression>(expression);
        }

        /// <summary>
        /// 获取语句
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        /// <exception cref="TypeNotSupportedException"></exception>
        public static string GetStatement(Expression expression)
        {
            return expression switch
            {
                BinaryExpression binaryExpression => CreateStatementBuilder(binaryExpression).GetStatement(),
                ConstantExpression constantExpression => CreateStatementBuilder(constantExpression).GetStatement(),
                ParameterExpression parameterExpression => CreateStatementBuilder(parameterExpression).GetStatement(),
                _ => throw new Exception($"{nameof(Expression)}.{nameof(GetStatement)}不支持的类型:" + expression.GetType().FullName),
            };
        }
    }
}
