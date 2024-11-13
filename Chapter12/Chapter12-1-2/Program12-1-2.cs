using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Serialization;

namespace Chapter12_1_2 {
    internal class Program {
        /* [問題12-1-2]

        　　1.
        　　XmlSerializerクラスを使って、以下のXMLファイルを逆シリアル化し、Novelistオブジェクト作成してください。
        　　Novelistクラスには必要ならば適切な属性を付加してください。

        　　<?xml version="1.0" encoding="utf-8" ?>
        　　<novelist>
        　　    <name>アーサー・C・クラーク</name>
        　　    <birth>1917-12-16</birth>
        　　    <masterpieces>
        　　        <title>2001年宇宙の旅</title>
        　　        <title>幼年期の終り</title>
        　　    </masterpieces>
        　　</novelist>

        　　public class Novelist {
        　　    public string Name { get; set; }
        　　    public DateTime Birth { get; set; }
        　　    public string[] Masterpieces { get; set; }
        　　}

        　　2.
        　　上記Novelistオブジェクトの内容を以下のようなJSONファイルにシリアル化するコードを書いてください。

        　　{"birth":"1917-12-16T00:00:00Z",
        　　 "masterpieces":["2001年宇宙の旅","幼少期の終り"],
        　　 "name":"アーサー・C・クラーク"}
        */
        static void Main(string[] args) {
            var wNovelist = new Novelist();
            // 1.
            Console.WriteLine("XMLファイルのファイル名を入力してください。例）Sample12-1-2.xml");
            string wReceivedXMLFile = Path.Combine("..", "..", Console.ReadLine());
            if (!File.Exists(wReceivedXMLFile)) {
                Console.WriteLine("指定されたファイルが存在しませんでした。");
                return;
            } else if (Path.GetExtension(wReceivedXMLFile).ToLower() != ".xml") {
                Console.WriteLine("指定されたファイルはXMLファイルではありません。");
                return;
            }
            using (var wNovelsReader = XmlReader.Create(wReceivedXMLFile)) {
                var wNovelSerializer = new XmlSerializer(typeof(Novelist));
                wNovelist = wNovelSerializer.Deserialize(wNovelsReader) as Novelist;
                Console.WriteLine($"名前:{wNovelist.Name}");
                Console.WriteLine($"生年月日:{wNovelist.Birth:yyyy/MM/dd}");
                foreach (var wTitle in wNovelist.Masterpieces) Console.WriteLine($"代表作:{wTitle}");
            }

            // 2.
            Console.WriteLine("JSONファイルのファイル名を入力してください。例）Employees12-1-2.json");
            var wReceivedJSONFile = Path.Combine("..", "..", Console.ReadLine());
            if (Path.GetExtension(wReceivedJSONFile).ToLower() != ".json") {
                Console.WriteLine("指定されたファイルはXMLファイルではありません。");
                return;
            }
            using (var wNovelsDataStream = new FileStream(wReceivedJSONFile, FileMode.Create, FileAccess.Write)) {
                var wNovelSerializer = new DataContractJsonSerializer(wNovelist.GetType(), new DataContractJsonSerializerSettings { DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ssZ") });
                wNovelSerializer.WriteObject(wNovelsDataStream, wNovelist);
            }
            if (!File.Exists(wReceivedJSONFile)) {
                Console.WriteLine("指定されたファイルの出力に失敗しました。");
                return;
            }
        }
    }
}
