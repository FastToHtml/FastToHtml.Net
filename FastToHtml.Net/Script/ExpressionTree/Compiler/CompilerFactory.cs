using FastToHtml.Net.Common;
using FastToHtml.Net.Script.ExpressionTree.Compiler.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastToHtml.Net.Script.ExpressionTree.Compiler
{
    /// <summary>
    /// 编译器工厂
    /// </summary>
    public sealed class CompilerFactory
    {
        // 表达式编译器类型
        private static readonly Type _expressionCompilerType = typeof(IExpressionCompiler);
        // 编译器集合
        private readonly Dictionary<Type, Type> _compilers;

        /// <summary>
        /// 编译器工厂
        /// </summary>
        public CompilerFactory()
        {
            _compilers = new Dictionary<Type, Type>();
            // 初始化
            Initialize();
        }

        // 注册
        private void Reg(Type compilerType)
        {
            // 注册所有接口
            var ifcs = compilerType.GetInterfaces();
            foreach (var ifc in ifcs)
            {
                _compilers[ifc] = compilerType;
            }
        }

        /// <summary>
        /// 获取编译器类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Type? GetCompilerType(Type type)
        {
            if (!_compilers.ContainsKey(type)) { return null; }
            return _compilers[type];
        }

        /// <summary>
        /// 获取编译器类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Type? GetCompilerType<T>()
        {
            return GetCompilerType(typeof(T));
        }

        /// <summary>
        /// 获取编译器类型
        /// </summary>
        /// <returns></returns>
        public Type GetCompilerTypeRequired(Type type)
        {
            return GetCompilerType(type) ?? throw new Exception($"Type '{type.FullName}' not supported.");
        }

        /// <summary>
        /// 获取编译器类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Type GetCompilerTypeRequired<T>()
        {
            var type = typeof(T);
            return GetCompilerType(type) ?? throw new Exception($"Type '{type.FullName}' not supported.");
        }

        /// <summary>
        /// 获取编译器类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IExpressionCompiler? GetCompiler(Type type)
        {
            var compilerType = GetCompilerType(type);
            if (compilerType is null) { return null; }
            return TypeHelper.CreateInstance<IExpressionCompiler>(compilerType);
        }

        /// <summary>
        /// 获取编译器类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IExpressionCompiler GetCompilerRequired(Type type)
        {
            var compilerType = GetCompilerTypeRequired(type);
            return TypeHelper.CreateInstance<IExpressionCompiler>(compilerType);
        }

        /// <summary>
        /// 获取编译器类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetCompilerRequired<T>()
        {
            var type = GetCompilerTypeRequired<T>();
            return TypeHelper.CreateInstance<T>(type);
        }

        // 初始化
        private void Initialize()
        {
            // 读取当前程序集
            var assembly = typeof(CompilerFactory).Assembly;
            // 获取程序集下所有的类
            var compilerTypes = assembly.GetTypes().Where(d => _expressionCompilerType.IsAssignableFrom(d) && !d.IsAbstract && !d.IsInterface);
            // 注册所有的类
            foreach (var compilerType in compilerTypes)
            {
                Reg(compilerType);
            }
        }
    }
}
