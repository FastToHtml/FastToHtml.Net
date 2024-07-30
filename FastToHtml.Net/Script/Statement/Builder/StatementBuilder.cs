using FastToHtml.Net.Script.ExpressionTree;
using FastToHtml.Net.Script.ExpressionTree.Compiler;
using FastToHtml.Net.Script.Statement.Dependency;

namespace FastToHtml.Net.Script.Statement.Builder
{

    /// <summary>
    /// 表达式编译器构建器
    /// </summary>
    public sealed class StatementBuilder<TExpression>
        where TExpression : System.Linq.Expressions.Expression
    {
        private static readonly CompilerFactory _compilerFactory;
        private readonly TExpression _expression;

        // 表达式编译器构建器
        static StatementBuilder()
        {
            _compilerFactory=new CompilerFactory();
        }

        /// <summary>
        /// 表达式编译器构建器
        /// </summary>
        /// <param name="compilerFactory"></param>
        /// <param name="provider"></param>
        /// <param name="expression"></param>
        public StatementBuilder(TExpression expression)
        {
            _expression = expression;
        }

        /// <summary>
        /// 获取语句
        /// </summary>
        /// <returns></returns>
        public string GetStatement()
        {
            var compiler = _compilerFactory.GetCompilerRequired<IStatementable<TExpression>>();
            return compiler.GetStatement(_expression);
        }

        /// <summary>
        /// 获取表达式值
        /// </summary>
        /// <returns></returns>
        public ExpressionValue GetValue()
        {
            var compiler = _compilerFactory.GetCompilerRequired<IValuable<TExpression>>();
            return compiler.GetValue(_expression);
        }

    }
}
