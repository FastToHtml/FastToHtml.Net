using FastToHtml.Net.Script.ExpressionTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Script.Statement.Dependency
{
    /// <summary>
    /// 可值化
    /// </summary>
    public interface IValuable<T>
        where T : System.Linq.Expressions.Expression
    {
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        ExpressionValue GetValue(T expression);
    }
}
