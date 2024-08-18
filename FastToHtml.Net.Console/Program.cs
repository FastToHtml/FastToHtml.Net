using FastToHtml.Net;
using FastToHtml.Net.Common.Constant;
using FastToHtml.Net.Element.Extension;
using FastToHtml.Net.Element.Html;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace FastToHtml.Net.Console
{
    class Program()
    {
        static void Main()
        {
            // 构建页面
            var page = FastToHtmlHelper.CreatePage();
            // 设置页面标题
            page.Head().Title("First Page");
            // 设置样式
            var helloCss = page.CreateCss(new() { BackgroundColor = "#ffaa00" });
            var buttonCss = page.CreateCss(new() { Width = "200px", Height = "50px", BackgroundColor = "#009900" });
            // 获取页面主体
            var body = page.Body();
            // 创建Hello World文本块
            var helloDiv = body.Div().Css(helloCss).Text("Hello World");
            // 创建有色区域
            body.Div().Css(buttonCss).Text("Line2")
                .OnClick(() =>
                {
                    var num = page.NumberVariable(2);
                    helloDiv.Text(num + 3);
                });

            #region 调试输出
            // 输出文件
            string fileName = "D:\\hello.html";
            System.IO.File.WriteAllText(fileName, page.Render());
            // 打开文件
            ProcessStartInfo startInfo = new(fileName);
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
            #endregion
        }
    }
}



