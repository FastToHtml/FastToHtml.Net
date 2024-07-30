using System;
using System.Collections.Generic;
using System.Text;
using FastToHtml.Net.Script.ExpressionTree.Enum;

namespace FastToHtml.Net.Script.ExpressionTree
{
    /// <summary>
    /// 表达式值
    /// </summary>
    public class ExpressionValue
    {
        /// <summary>
        /// 值设定
        /// </summary>
        /// <param name="valueType"></param>
        /// <param name="value"></param>
        public ExpressionValue(ExpressionValueType valueType, object value)
        {
            ValueType = valueType;
            Value = value;
        }
        /// <summary>
        /// 值类型
        /// </summary>
        public ExpressionValueType ValueType { get; }
        /// <summary>
        /// 值
        /// </summary>
        public object Value { get; }
        /// <summary>
        /// 获取字符串
        /// </summary>
        /// <returns></returns>
        public new string ToString()
        {
            if (Value is null) return string.Empty;
            return Convert.ToString(Value) ?? string.Empty;
        }

        #region 静态方法
        static ExpressionValue()
        {
            Null = new ExpressionValue(ExpressionValueType.Null, new object());
        }
        /// <summary>
        /// 空值设定
        /// </summary>
        public static ExpressionValue Null { get; }

        /// <summary>
        /// 创建值设定
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="valueType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ExpressionValue<T> Create<T>(ExpressionValueType valueType, T value)
        {
            return new ExpressionValue<T>(valueType, value);
        }

        /// <summary>
        /// 创建值设定
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ExpressionValue<T> Create<T>(T value)
        {
            return new ExpressionValue<T>(ExpressionValueType.ConstantValue, value);
        }

        /// <summary>
        /// 构建值设定
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ExpressionValue Build(object? value)
        {
            if (value is null) return Null;
            if (value is string str) return Create(ExpressionValueType.StringValue, str);
            if (value is DateTime time) return Create(ExpressionValueType.TimeValue, time);
            var valueType = value.GetType();
            if (valueType.IsValueType) return Create(ExpressionValueType.ConstantValue, value);
            return Create(ExpressionValueType.Object, value);
        }
        #endregion
    }

    /// <summary>
    /// 表达式值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExpressionValue<T> : ExpressionValue
    {
        /// <summary>
        /// 值设定
        /// </summary>
        /// <param name="valueType"></param>
        /// <param name="value"></param>
        public ExpressionValue(ExpressionValueType valueType, T value) : base(valueType, value!)
        {
        }

        /// <summary>
        /// 值
        /// </summary>
        public new T Value => (T)base.Value;
    }
}
