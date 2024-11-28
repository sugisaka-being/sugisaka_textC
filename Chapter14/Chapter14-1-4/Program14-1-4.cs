using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Chapter14_1_4 {
    internal class Program {
        /* [問題14-1-4]
        　　あなたがよく訪れるWebページのHTMLを取得し、ファイルに保存するプログラムを書いてください。
        */
        static async Task Main(string[] args) {
            Console.WriteLine("保存先のHTMLファイルパスを入力してください。例）Sample14-1-4.html");
            var wHttpClient = new HttpClient();
            File.WriteAllBytes(Console.ReadLine(), await wHttpClient.GetByteArrayAsync("https://www.beingcorp.co.jp/"));
        }
    }
}
