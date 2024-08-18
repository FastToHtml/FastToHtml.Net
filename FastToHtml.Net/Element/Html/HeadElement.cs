using FastToHtml.Net.Element.Extension;

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
            Styles = new StyleElement(this);
            Scripts = new ScriptElement(this);
            Children.Add(Scripts);
            Children.Add(Styles);
        }

        /// <summary>
        /// 页面
        /// </summary>
        public PageElement Page { get; }

        /// <summary>
        /// 样式集合
        /// </summary>
        public StyleElement Styles { get; }

        /// <summary>
        /// 脚本集合
        /// </summary>
        public ScriptElement Scripts { get; }

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
