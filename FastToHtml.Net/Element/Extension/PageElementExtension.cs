using FastToHtml.Net.Element.Dependency;
using FastToHtml.Net.Element.Html;
using FastToHtml.Net.ElementAttribute;
using FastToHtml.Net.Script.Html;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FastToHtml.Net.Element.Extension
{
    /// <summary>
    /// 页面元素扩展
    /// </summary>
    public static class PageElementExtension
    {
        #region 常量

        /// <summary>
        /// 创建一个数值常量
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static NumberScriptConstant Number(this PageElement page, double value = 0)
        {
            return new NumberScriptConstant(page.GetPageScript(), value);
        }

        #endregion

        #region 变量

        /// <summary>
        /// 创建一个数值变量
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static NumberScriptVariable NumberVariable(this PageElement page, NumberScriptStatement statement)
        {
            var pageScript = page.GetPageScript();
            NumberScriptVariable variable = new NumberScriptVariable(pageScript);
            //variable.SetValue(statement);
            LetScript letScript = new LetScript(pageScript, variable, statement);
            pageScript.Scripts.Add(letScript);
            return variable;
        }

        /// <summary>
        /// 创建一个数值变量
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static NumberScriptVariable NumberVariable(this PageElement page, double value)
        {
            var pageScript = page.GetPageScript();
            NumberScriptConstant numberScriptConstant = new NumberScriptConstant(pageScript, value);
            NumberScriptVariable variable = new NumberScriptVariable(page.GetPageScript());
            //variable.SetValue(numberScriptConstant);
            LetScript letScript = new LetScript(pageScript, variable, numberScriptConstant);
            pageScript.Scripts.Add(letScript);
            return variable;
        }

        #endregion

    }
}
