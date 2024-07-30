using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FastToHtml.Net.Common.Extension
{
    /// <summary>
    /// 类型扩展
    /// </summary>
    public static class TypeExtension
    {
        // 列表类型
        private static readonly Type _listType = typeof(IList<>);
        // 字符串类型
        private static readonly Type _stringType = typeof(string);

        /// <summary>
        /// 是否为列表类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsListType(this Type type)
        {
            if (!type.IsGenericType) { return false; }
            var definitionType = type.GetGenericTypeDefinition();
            var typeInterfaces = definitionType.GetInterfaces();
            foreach (var typeInterface in typeInterfaces)
            {
                if (!typeInterface.IsGenericType) { continue; }
                if (!typeInterface.IsGenericTypeDefinition)
                {
                    var typeInterfaceDefinition = typeInterface.GetGenericTypeDefinition();
                    if (typeInterfaceDefinition.Equals(_listType))
                    {
                        return true;
                    }
                    continue;
                }
                if (typeInterface.Equals(_listType)) { return true; }
            }
            return false;
        }

        /// <summary>
        /// 是否为值或字符串类型
        /// </summary>
        /// <returns></returns>
        public static bool IsValueOrStringType(this Type type)
        {
            if (type.IsValueType) { return true; }
            return _stringType.IsAssignableFrom(type);
        }

        /// <summary>
        /// 获取唯一的公共实例属性
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static PropertyInfo? GetUniquePublicInstanceProperty(this Type type, string name)
        {
            // 在当前类中查找满足条件的属性
            var propertyInfo = type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(d => d.DeclaringType == type && d.Name == name).FirstOrDefault();
            if (propertyInfo != null) { return propertyInfo; }
            // 未找到则在继承类中查找
            if (type.BaseType != null) { return GetUniquePublicInstanceProperty(type.BaseType, name); }
            // 均为找到，则返回空
            return null;
        }
    }
}
