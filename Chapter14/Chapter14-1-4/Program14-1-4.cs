using System;
using System.Net;

namespace Chapter14_1_4 {
    internal class Program {
        /* [問題14-1-4]
        　　あなたがよく訪れるWebページのHTMLを取得し、ファイルに保存するプログラムを書いてください。
        */
        static void Main(string[] args) {
            Console.WriteLine("保存先のHTMLファイル名を入力してください。例）Sample14-1-4.html");
            var wWebClient = new WebClient();
            wWebClient.DownloadFile("https://www.beingcorp.co.jp/", Console.ReadLine());
        }
    }
}
