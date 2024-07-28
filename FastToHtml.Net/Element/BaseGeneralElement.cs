using FastToHtml.Net.Element.Dependency;

namespace FastToHtml.Net.Element
{
    /// <summary>
    /// 基础简单元素
    /// </summary>
    public abstract class BaseGeneralElement : BaseElement, IFthGeneralElement
    {

        /// <summary>
        /// 带标签的普通元素
        /// </summary>
        /// <param name="parent"></param>
        protected BaseGeneralElement(IFthContainerElement parent)
        {
            Parent = parent;
        }

        /// <summary>
        /// 父元素
        /// </summary>
        public IFthContainerElement Parent { get; }
    }
}
