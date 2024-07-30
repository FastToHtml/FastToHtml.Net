using FastToHtml.Net.Script.ExpressionTree.Enum;
using FastToHtml.Net.Script.Statement.Dependency;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FastToHtml.Net.Script.ExpressionTree.Compiler
{
    /// <summary>
    /// 二元表达式
    /// </summary>
    public sealed class BinaryCompiler : BaseExpressionCompiler<BinaryExpression>
        , IStatementable<BinaryExpression>
        , IValuable<BinaryExpression>
        , IPredicatable<BinaryExpression>
    {
        /// <summary>
        /// 获取判断条件
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        public string GetPredicate(BinaryExpression expression)
        {
            StringBuilder sb = new StringBuilder();
            var expLeft = GetValueStatement(GetExpressionValue(expression.Left));
            var expRight = GetValueStatement(GetExpressionValue(expression.Right));
            sb.Append(expLeft);
            switch (expression.NodeType)
            {
                case ExpressionType.AndAlso:
                    sb.Append(" && ");
                    break;
                case ExpressionType.OrElse:
                    sb.Append(" || ");
                    break;
                case ExpressionType.Equal:
                    sb.Append(" === ");
                    break;
                case ExpressionType.NotEqual:
                    sb.Append(" !== ");
                    break;
                case ExpressionType.GreaterThan:
                    sb.Append(" > ");
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    sb.Append(" >= ");
                    break;
                case ExpressionType.LessThan:
                    sb.Append(" < ");
                    break;
                case ExpressionType.LessThanOrEqual:
                    sb.Append(" <= ");
                    break;
                default: throw new System.Exception($"不支持的节点类型'{expression.NodeType}'");
            }
            sb.Append(expRight);
            return sb.ToString();
        }

        /// <summary>
        /// 获取语句
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public string GetStatement(BinaryExpression expression)
        {
            StringBuilder sb = new StringBuilder();
            var expLeft = GetValueStatement(GetExpressionValue(expression.Left));
            var expRight = GetValueStatement(GetExpressionValue(expression.Right));
            sb.Append(expLeft);
            switch (expression.NodeType)
            {
                case ExpressionType.Assign:
                    sb.Append(" = ");
                    break;
                case ExpressionType.Add:
                    sb.Append(" + ");
                    break;
                case ExpressionType.Subtract:
                    sb.Append(" - ");
                    break;
                case ExpressionType.Multiply:
                    sb.Append(" * ");
                    break;
                case ExpressionType.Divide:
                    sb.Append(" / ");
                    break;
                default: throw new System.Exception($"不支持的节点类型'{expression.NodeType}'");
            }
            sb.Append(expRight);
            return sb.ToString();
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        public ExpressionValue GetValue(BinaryExpression expression)
        {
            return ExpressionValue.Create(ExpressionValueType.Expression, GetPredicate(expression));
        }
    }
}
