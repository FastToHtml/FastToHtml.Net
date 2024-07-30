using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Script.Statement.Dependency
{
    /// <summary>
    /// 可语句化
    /// </summary>
    public interface IStatementable<T>
        where T : System.Linq.Expressions.Expression
    {
        /// <summary>
        /// 获取语句
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        string GetStatement(T expression);
    }
}
