using FastToHtml.Net.Common.Constant;
using FastToHtml.Net.Common.Dependency;
using FastToHtml.Net.ElementStyle.Attribute;
using FastToHtml.Net.ElementStyle.Dependency;
using FastToHtml.Net.ElementStyle.Html;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace FastToHtml.Net.ElementStyle
{
    /// <summary>
    /// 样式集
    /// </summary>
    public class StyleSet : Dictionary<string, IFthStyle>
    {
        private static readonly Dictionary<string, string> _bindings;

        // 样式集
        static StyleSet()
        {
            _bindings = new Dictionary<string, string>();
            var type = typeof(StyleSet);
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                var styleAttribute = property.GetCustomAttribute<StyleAttribute>();
                if (styleAttribute is null) { continue; }
                _bindings[property.Name] = styleAttribute.Name;
            }
        }

        #region 样式

        /// <summary>
        /// 宽度
        /// </summary>
        [Style(HtmlStyles.WIDTH)]
        public string Width { get => GetPropertyValue(); set => SetPropertyValue(value); }

        /// <summary>
        /// 宽度
        /// </summary>
        [Style(HtmlStyles.HEIGHT)]
        public string Height { get => GetPropertyValue(); set => SetPropertyValue(value); }

        /// <summary>
        /// 背景
        /// </summary>
        [Style(HtmlStyles.BACKGROUND)]
        public string Background { get => GetPropertyValue(); set => SetPropertyValue(value); }

        /// <summary>
        /// 背景颜色
        /// </summary>
        [Style(HtmlStyles.BACKGROUND_COLOR)]
        public string BackgroundColor { get => GetPropertyValue(); set => SetPropertyValue(value); }

        #endregion

        #region 属性操作基方法

        // 获取属性名称
        private string GetPropertyValue([CallerMemberName] string propertyName = "")
        {
            if (string.IsNullOrWhiteSpace(propertyName)) { return string.Empty; }
            if (!_bindings.ContainsKey(propertyName)) { return string.Empty; }
            var styleName = _bindings[propertyName];
            var style = this[styleName];
            if (style is ValueStyle valueStyle)
            {
                return valueStyle.Value;
            }
            return string.Empty;
        }

        // 设置属性值
        private void SetPropertyValue(string value, [CallerMemberName] string propertyName = "")
        {
            // 检测是否正常绑定
            if (!_bindings.ContainsKey(propertyName)) { return; }
            var styleName = _bindings[propertyName];
            ValueStyle valueStyle = new ValueStyle(value);
            this[styleName] = valueStyle;
        }

        #endregion
    }
}
