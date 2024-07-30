using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FastToHtml.Net.Script.ExpressionTree.Enum
{
    /// <summary>
    /// 表达式值类型
    /// </summary>
    [Description("表达式值类型")]
    public enum ExpressionValueType : int
    {
        /// <summary>
        /// 空
        /// </summary>
        [Description("空")]
        Null = 0x0,
        /// <summary>
        /// 常量值
        /// </summary>
        [Description("常量值")]
        ConstantValue = 0x1,
        /// <summary>
        /// 字符串值
        /// </summary>
        [Description("字符串值")]
        StringValue = 0x2,
        /// <summary>
        /// 时间值
        /// </summary>
        [Description("时间值")]
        TimeValue = 0x3,
        /// <summary>
        /// 表达式
        /// </summary>
        [Description("表达式")]
        Expression = 0x10,
        /// <summary>
        /// 对象
        /// </summary>
        [Description("对象")]
        Object = 0x20,
        /// <summary>
        /// 类型
        /// </summary>
        [Description("类型")]
        Type = 0x30,
    }
}
