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
            wNovelist = DeserializerFromXml(Path.Combine(Environment.CurrentDirectory, Console.ReadLine()));
            if (wNovelist == null) return;
            Console.WriteLine(wNovelist);

            // 2.
            Console.WriteLine("JSONファイルのファイル名を入力してください。例）Sample12-1-2.json");
            SerializeToJson(wNovelist, Path.Combine(Environment.CurrentDirectory, Console.ReadLine()));
        }

        /// <summary>
        /// XMLファイルをデシリアライズするメソッド
        /// </summary>
        /// <param name="vInputFile">デシリアライズしたいフィアル</param>
        /// <returns>作成されたオブジェクト</returns>
        static Novelist DeserializerFromXml(string vInputFile) {
            if (!File.Exists(vInputFile)) {
                Console.WriteLine("指定されたファイルが存在しませんでした。");
                return null;
            } else if (Path.GetExtension(vInputFile).ToLower() != ".xml") {
                Console.WriteLine("指定されたファイルはXMLファイルではありません。");
                return null;
            }
            using (var wReader = XmlReader.Create(vInputFile)) {
                var wSerializer = new XmlSerializer(typeof(Novelist));
                return wSerializer.Deserialize(wReader) as Novelist;
            }
        }

        /// <summary>
        /// JSONファイルにシリアライズするメソッド
        /// </summary>
        /// <param name="vNovelist">シリアライズしたいオブジェクト</param>
        /// <param name="vInputFile">出力先のファイルパス</param>
        static void SerializeToJson(Novelist vNovelist, string vInputFile) {
            if (Path.GetExtension(vInputFile).ToLower() != ".json") {
                Console.WriteLine("指定されたファイルはJSONファイルではありません。");
                return;
            }
            using (var wDataStream = new FileStream(vInputFile, FileMode.Create, FileAccess.Write)) {
                var wSerializer = new DataContractJsonSerializer(typeof(Novelist),
                    new DataContractJsonSerializerSettings { DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ssZ") });
                wSerializer.WriteObject(wDataStream, vNovelist);
            }
            if (!File.Exists(vInputFile)) {
                Console.WriteLine("指定されたファイルの出力に失敗しました。");
                return;
            }
            Console.WriteLine("オブジェクトがJSONファイルにシリアル化されました。");
        }
    }
}
