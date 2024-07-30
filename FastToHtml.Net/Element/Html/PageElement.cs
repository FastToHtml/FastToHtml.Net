using FastToHtml.Net.Element.Dependency;
using FastToHtml.Net.ElementAttribute;
using FastToHtml.Net.ElementProperty.Dependency;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Element.Html
{
    /// <summary>
    /// 页面
    /// </summary>
    public sealed class PageElement : BaseElement
    {
        private HeadElement _head; // 头部
        private BodyElement _body; // 主体
        private int _serialNumberIndexer; // 序号索引器

        /// <summary>
        /// 页面
        /// </summary>
        public PageElement()
        {
            _head = new HeadElement(this);
            _body = new BodyElement(this);
        }

        /// <summary>
        /// 头部元素
        /// </summary>
        /// <returns></returns>
        public HeadElement Head() => _head;

        /// <summary>
        /// 头部元素
        /// </summary>
        /// <returns></returns>
        public BodyElement Body() => _body;

        /// <summary>
        /// 获取新的序号
        /// </summary>
        /// <returns></returns>
        public int GetNewSerialNumber()
        {
            return ++_serialNumberIndexer;
        }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <returns></returns>
        protected override string OnRender()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<html");
            foreach (var Property in Properties)
            {
                // 值类型
                if (Property.Value is ValueProperty valueProperty)
                {
                    sb.Append(' ');
                    sb.Append(Property.Key);
                    sb.Append("=\"");
                    sb.Append(valueProperty.Value);
                    sb.Append('"');
                }
            }
            sb.Append('>');
            sb.Append(_head.Render());
            sb.Append(_body.Render());
            sb.Append("</html>");
            return sb.ToString();
        }
    }
}
