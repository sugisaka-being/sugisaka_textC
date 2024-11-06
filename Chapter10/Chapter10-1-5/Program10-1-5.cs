using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Chapter10_1_5 {
    internal class Program {
        /* [問題10-1-5]
        　　HTMLファイルを読み込み、<DIV>や<P>などのタグ名が大文字になっているものを<div>、<p>などと小文字のタグ名に変換してください。
        　　可能ならば、<DIV class="myBox" id="myId">のように属性が記述されている場合にも対応してください。
        　　属性の中には'<','>'は含まれていないものとします。
        */
        static void Main(string[] args) {
            var wConvertFile = @"..\..\Sample10-1-5.html";
            var wBeforeConvert = @"<(/?)([A-Z][A-Z0-9]*)(.*?)>";
            var wVersionLines = File.ReadAllLines(wConvertFile);
            File.WriteAllLines(wConvertFile, wVersionLines.Select(x => Regex.Replace(x, wBeforeConvert, y => $"<{y.Groups[1].Value}{y.Groups[2].Value.ToLower()}{y.Groups[3].Value}>")));
        }
    }
}
