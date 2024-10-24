using System;
using System.Linq;

namespace Chapter5_1_4 {
    internal class Program {
        /* [問題5-1-4]
        　　"Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886"という文字列から以下の出力を得るコンソールアプリケーションを作成してください。
        　　作家　: 谷崎潤一郎
        　　代表作: 春琴抄
        　　誕生年: 1886
        */
        static void Main(string[] args) {
            var wNovel = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            var wNovelInfos = wNovel.Split(';').Select(x => x.Split('=')[1]).ToArray();
            Console.WriteLine($"作家　: {wNovelInfos[0]}{Environment.NewLine}代表作: {wNovelInfos[1]}{Environment.NewLine}誕生年: {wNovelInfos[2]}");
        }
    }
}
