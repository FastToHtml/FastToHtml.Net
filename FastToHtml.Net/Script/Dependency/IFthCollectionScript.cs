using FastToHtml.Net.Common.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Script.Dependency
{
    /// <summary>
    /// 集合脚本
    /// </summary>
    public interface IFthCollectionScript : IFthScript
    {
        /// <summary>
        /// 脚本集合
        /// </summary>
        List<IFthScript> Scripts { get; }
    }
}
