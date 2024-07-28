using FastToHtml.Net.Element.Extension;
using FastToHtml.Net.Script;
using FastToHtml.Net.Style;

namespace FastToHtml.Net.Element.Html
{
    /// <summary>
    /// 头部元素
    /// </summary>
    public sealed class HeadElement : BaseTagContainerElement
    {
        /// <summary>
        /// 头部元素
        /// </summary>
        public HeadElement(PageElement page)
        {
            Page = page;
            Styles = new StyleCollection();
            Scripts = new ScriptCollection();
        }

        /// <summary>
        /// 页面
        /// </summary>
        public PageElement Page { get; }

        /// <summary>
        /// 样式集合
        /// </summary>
        public StyleCollection Styles { get; }

        /// <summary>
        /// 脚本集合
        /// </summary>
        public ScriptCollection Scripts { get; }

        /// <summary>
        /// 标签名称
        /// </summary>
        public override string TagName => "head";

        #region 子元素

        /// <summary>
        /// 设置标题
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public HeadElement Title(string title)
        {
            TitleElement titleElement = new TitleElement(this);
            titleElement.Text(title);
            Children.Add(titleElement);
            return this;
        }

        #endregion
    }
}
