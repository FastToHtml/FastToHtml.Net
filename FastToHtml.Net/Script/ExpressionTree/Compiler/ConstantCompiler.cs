using FastToHtml.Net.Script.ExpressionTree.Enum;
using FastToHtml.Net.Script.Statement.Dependency;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FastToHtml.Net.Script.ExpressionTree.Compiler
{
    /// <summary>
    /// 常量
    /// </summary>
    public sealed class ConstantCompiler : BaseExpressionCompiler<ConstantExpression>
        , IStatementable<ConstantExpression>
        , IValuable<ConstantExpression>
    {
        /// <summary>
        /// 获取语句
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public string GetStatement(ConstantExpression expression)
        {
            return GetValueStatement(GetValue(expression));
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        public ExpressionValue GetValue(ConstantExpression expression)
        {
            if (expression.Value is null) return ExpressionValue.Null;
            if (expression.Value is string str) return ExpressionValue.Create(ExpressionValueType.StringValue, str);
            if (expression.Value is DateTime time) return ExpressionValue.Create(ExpressionValueType.TimeValue, time);
            var valueType = expression.Value.GetType();
            if (valueType.IsValueType) return ExpressionValue.Create(ExpressionValueType.ConstantValue, expression.Value);
            return ExpressionValue.Create(ExpressionValueType.Object, expression.Value);
        }
    }
}
