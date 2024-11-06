using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Chapter10_1_4 {
    internal class Program {
        /* [問題10-1-4]
        　　テキストファイルを読み込み、version="v4.0"と書かれた箇所を、version="v5.0"に書き換え、同じファイルに保存してください。
        　　なお、入力ファイルの=の前後には任意の数の空白文字が入っていることもあります。
        　　出力時には、=の前後の空白は削除してください。
        　　"version"は、"Version"である可能性もあります。
        */
        static void Main(string[] args) {
            var wVersionTexts = @"..\..\Sample10-1-4.txt";
            var wBeforeConvert = @"[Vv]ersion\s*=\s*""v4.0""";
            var wAfterConvert = @"version=""v5.0""";
            var wVersionLines = File.ReadAllLines(wVersionTexts);
            File.WriteAllLines(wVersionTexts, wVersionLines.Select(x => Regex.Replace(x, wBeforeConvert, wAfterConvert)));
        }
    }
}
