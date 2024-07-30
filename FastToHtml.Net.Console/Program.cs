using FastToHtml.Net;
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
            page.Head().Title("First Page");
            var body = page.Body();
            var helloDiv = body.Div().Text("Hello World");
            body.Div()
                .Style(new()
                {
                    Width = "200px",
                    Height = "50px",
                    BackgroundColor = "#009900"
                })
                .Text("Line2")
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



