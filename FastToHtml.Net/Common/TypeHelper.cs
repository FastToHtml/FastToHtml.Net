using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FastToHtml.Net.Common
{
    /// <summary>
    /// 类型助手
    /// </summary>
    public static class TypeHelper
    {
        /// <summary>
        /// 根据名称查找类型
        /// </summary>
        /// <param name="name">类型名称</param>
        /// <returns></returns>
        public static Type? FindType(string name)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                try
                {
                    var types = assembly.GetTypes();
                    foreach (var type in types)
                        if (type.FullName == name) return type;
                }
                catch { }
            }
            return null;
        }

        /// <summary>
        /// 根据名称查找类型，如不存在，则从目标目录中加载引用程序集后重新查找
        /// </summary>
        /// <param name="name">类型名称</param>
        /// <param name="path">类库文件或文件夹路径</param>
        /// <returns></returns>
        public static Type? FindType(string name, string path)
        {
            // 先进行名称查找类型
            Type? type = FindType(name);
            // 未找到则先加载关联的dll文件，再重新查找
            if (type is null)
            {
                // 目标地址是一个文件
                if (File.Exists(path)) { AssemblyHelper.LoadAssemblyFromFile(path); }
                // 目标地址是一个文件夹
                if (Directory.Exists(path)) { AssemblyHelper.LoadAssemblyFromFolder(path); }
                // 重新查找类型
                type = FindType(name);
            }
            return type;
        }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="TypeInstanceFailException"></exception>
        public static object CreateInstance(Type type)
        {
            var obj = Activator.CreateInstance(type) ?? throw new Exception($"Type '{type.FullName}' instance fail");
            return obj;
        }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="TypeInstanceFailException"></exception>
        public static T CreateInstance<T>(Type type)
        {
            var obj = Activator.CreateInstance(type) ?? throw new Exception($"Type '{type.FullName}' instance fail");
            return (T)obj;
        }
    }
}
