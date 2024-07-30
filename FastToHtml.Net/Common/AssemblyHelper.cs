using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FastToHtml.Net.Common
{
    /// <summary>
    /// 程序集助手
    /// </summary>
    public static class AssemblyHelper
    {
        /// <summary>
        /// 从文件中加载程序集
        /// </summary>
        /// <param name="path"></param>
        public static void LoadAssemblyFromFile(string path)
        {
            try
            {
                System.Reflection.Assembly.LoadFrom(path);
            }
            catch { }
        }

        /// <summary>
        /// 从文件夹中加载所有程序集
        /// </summary>
        /// <param name="path"></param>
        public static void LoadAssemblyFromFolder(string path)
        {
            var files = Directory.GetFiles(path, "*.dll");
            foreach (var file in files) LoadAssemblyFromFile(file);
        }
    }
}
