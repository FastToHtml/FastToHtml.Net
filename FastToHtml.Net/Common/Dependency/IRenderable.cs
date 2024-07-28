using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Common.Dependency
{
    /// <summary>
    /// 可渲染
    /// </summary>
    public interface IRenderable
    {
        /// <summary>
        /// 渲染
        /// </summary>
        /// <returns></returns>
        string Render();
    }
}
