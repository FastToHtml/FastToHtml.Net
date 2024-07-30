using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FastToHtml.Net.Script.Statement.Dependency
{
    /// <summary>
    /// 可查询
    /// </summary>
    public interface IPredicatable<T>
        where T : Expression
    {
        /// <summary>
        /// 获取查询语句
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        string GetPredicate(T expression);
    }
}
