using FastToHtml.Net.Common.Extension;
using FastToHtml.Net.Script.ExpressionTree.Compiler.Dependency;
using FastToHtml.Net.Script.ExpressionTree.Enum;
using FastToHtml.Net.Script.Statement.Builder;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace FastToHtml.Net.Script.ExpressionTree.Compiler
{
    /// <summary>
    /// 表达式编译器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseExpressionCompiler<TExpression> : IExpressionCompiler
        where TExpression : Expression
    {

        // 编译器工厂
        private static readonly CompilerFactory _compilerFactory = new CompilerFactory();

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="variableBuilder"></param>
        public void Initialize()
        {
        }

        #region 值获取

        /// <summary>
        /// 获取值语句
        /// </summary>
        /// <param name="variableBuilder"></param>
        /// <param name="valueSet"></param>
        /// <returns></returns>
        public string GetValueStatement(ExpressionValue expressionValue)
        {
            return expressionValue.ValueType switch
            {
                ExpressionValueType.Null => "null",
                ExpressionValueType.StringValue => CreateStringValue((string)expressionValue.Value),
                ExpressionValueType.TimeValue => CreateTimeValue((DateTime)expressionValue.Value),
                ExpressionValueType.ConstantValue => CreateValue(expressionValue.Value),
                ExpressionValueType.Expression => CreateExpressionValue(expressionValue.Value),
                ExpressionValueType.Object => CreateObjectValue(expressionValue.Value),
                _ => throw new Exception($"GetValue - type {expressionValue.ValueType} not supported."),
            };
        }

        /// <summary>
        /// 创建字符串值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string CreateStringValue(string? value)
        {
            if (value is null) { return "null"; }
            return "\"" + value + "\"";
        }

        /// <summary>
        /// 创建Sql值
        /// </summary>
        /// <param name="variableBuilder"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string CreateValue(object? value)
        {
            if (value is null) { return "null"; }
            var type = value.GetType();
            if (type.IsEnum) { return ((int)value).ToString(); }
            return Convert.ToString(value);
        }

        /// <summary>
        /// 创建时间值
        /// </summary>
        /// <param name="variableBuilder"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private string CreateTimeValue(DateTime value)
        {
            var datetime = CreateStringValue(value.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            return $"new Date({datetime})";
        }

        /// <summary>
        /// 创建表达式值
        /// </summary>
        /// <param name="variableBuilder"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private string CreateExpressionValue(object value)
        {
            return value switch
            {
                string strValue => strValue,
                _ => throw new Exception($"CreateExpressionValue - not supported value type {value.GetType().FullName}."),
            };
        }

        /// <summary>
        /// 创建表达式值
        /// </summary>
        /// <param name="variableBuilder"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private string CreateObjectValue(object value)
        {
            return value switch
            {
                _ => throw new Exception($"CreateObjectValue - not supported value type {value.GetType().FullName}."),
            };
        }

        #endregion

        #region 获取表达式的值

        /// <summary>
        /// 获取表达式的值
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        public ExpressionValue GetExpressionValue(Expression expression)
        {
            return expression switch
            {
                // 一元表达式
                UnaryExpression unaryExpression => ExpressionHelper.CreateStatementBuilder(unaryExpression).GetValue(),
                // 二元表达式
                BinaryExpression binaryExpression => GetBinaryExpressionValue(binaryExpression),
                // 函数表达式
                MethodCallExpression methodCallExpression => ExpressionHelper.CreateStatementBuilder(methodCallExpression).GetValue(),
                // 成员变量
                MemberExpression memberExpression => ExpressionHelper.CreateStatementBuilder(memberExpression).GetValue(),
                // 常量
                ConstantExpression constantExpression => ExpressionHelper.CreateStatementBuilder(constantExpression).GetValue(),
                // 建模参数
                ParameterExpression parameterExpression => ExpressionHelper.CreateStatementBuilder(parameterExpression).GetValue(),
                _ => throw new Exception($"不支持的节点类型:'{expression.NodeType}'"),
            };
        }

        // 获取二元表达式的值
        private ExpressionValue GetBinaryExpressionValue(BinaryExpression binaryExpression)
        {
            var valueSet = ExpressionHelper.CreateStatementBuilder(binaryExpression).GetValue();
            return valueSet.ValueType switch
            {
                ExpressionValueType.Expression => GetExpressionValue(valueSet),
                _ => throw new Exception($"GetBinaryExpressionValue - {nameof(BinaryExpression)} not supported value type {valueSet.ValueType}."),
            };
        }

        // 获取表达式的值
        private ExpressionValue GetExpressionValue(ExpressionValue valueSet)
        {
            return valueSet.Value switch
            {
                string strValue => ExpressionValue.Create(ExpressionValueType.Expression, "(" + strValue + ")"),
                _ => throw new Exception($"GetExpressionValue - not supported value type {valueSet.Value.GetType().FullName}."),
            };
        }

        #endregion

        #region 获取字段或属性值

        /// <summary>
        /// 从对象字段或属性中获取内容
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        protected static object? GetFieldOrPropertyValue(ExpressionValue value, string name)
        {
            if (value.Value is null) return null;
            // 根据数据对象类型处理
            return value.Value switch
            {
                _ => GetObjectFieldOrPropertyValue(value.Value, name),
            };
        }

        /// <summary>
        /// 从对象字段或属性中获取内容
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private static object? GetObjectFieldOrPropertyValue(object obj, string name)
        {
            Type type = obj.GetType();
            // 尝试从标准字段获取
            var field = type.GetField(name);
            if (field != null) return field.GetValue(obj);
            // 尝试从私有字段获取
            var fieldPrivate = type.GetField(name, BindingFlags.Instance | BindingFlags.NonPublic);
            if (fieldPrivate != null) return fieldPrivate.GetValue(obj);
            // 尝试从属性获取
            var pro = type.GetUniquePublicInstanceProperty(name);
            if (pro != null) return pro.GetValue(obj);
            return null;
        }

        #endregion
    }
}
