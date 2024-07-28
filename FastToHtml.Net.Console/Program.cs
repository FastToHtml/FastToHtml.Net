using FastToHtml.Net;
using FastToHtml.Net.Element.Extension;
using System.Diagnostics;

// 构建页面
var page = FastToHtmlHelper.CreatePage();
page.Head().Title("First Page");
page.Body()
    .Div().Text("Hello World").Done()
    .Div().Style(new() { Width = "200px", Height = "50px", BackgroundColor = "#009900" }).Text("Line2");

// 输出文件
string fileName = "D:\\hello.html";
System.IO.File.WriteAllText(fileName, page.Render());
// 打开文件
ProcessStartInfo startInfo = new(fileName);
startInfo.UseShellExecute = true;
Process.Start(startInfo);