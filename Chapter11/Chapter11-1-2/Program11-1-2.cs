using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Chapter11_1_2 {
    internal class Program {
        /* [問題11-1-2]
        　　次のようなXMLファイルがあります。

        　　<?xml version="1.0" encoding="utf-8" ?>
        　　<difficultkanji>
        　　    <word>
        　　        <kanji>鬼灯</kanji>
        　　        <yomi>ほおずき</yomi>
        　　    </word>
        　　    <word>
        　　        <kanji>暖簾</kanji>
        　　        <yomi>のれん</yomi>
        　　    </word>
        　　    <word>
        　　        <kanji>杜撰</kanji>
        　　        <yomi>ずさん</yomi>
        　　    </word>
        　　    <word>
        　　        <kanji>坩堝</kanji>
        　　        <yomi>るつぼ</yomi>
        　　    </word>
        　　</difficultkanji>

        　　このXMLファイルを次の形式に変換し、別のファイルに保存してください。

        　　<?xml version="1.0" encoding="utf-8" ?>
        　　<difficultkanji>
        　　    <word kanji="鬼灯" yomi="ほおずき" />
        　　    <word kanji="暖簾" yomi="のれん" />
        　　    <word kanji="杜撰" yomi="ずさん" />
        　　    <word kanji="坩堝" yomi="るつぼ" />
        　　</difficultkanji>
        */
        static void Main(string[] args) {
            Console.WriteLine("ファイルのパスを入力してください。例）..\\..\\Sample11-1-2.xml");
            var wOriginalWords = Console.ReadLine();
            if (!File.Exists(wOriginalWords)) {
                Console.WriteLine("指定されたファイルが存在しませんでした。");
                return;
            } else if (Path.GetExtension(wOriginalWords).ToLower() != ".xml") {
                Console.WriteLine("指定されたファイルはXMLファイルではありません。");
                return;
            }
            var wWordsDocument = XDocument.Load(wOriginalWords);
            var wNewWordsElements = wWordsDocument.Root.Elements()
                .Select(x => TransformeElements(x));
            var wWordsRoot = new XElement("difficultkanji", wNewWordsElements);
            Console.WriteLine("新しい情報を保存するファイルパス名を入力してください。例）..\\..\\NewSample11-1-2.xml");
            wWordsRoot.Save(Console.ReadLine());
            Console.WriteLine("ファイルが保存されました。");
        }
        /// <summary>
        /// XMLデータを新しい形式に変換するメソッド
        /// </summary>
        /// <param name="vOriginalElements">元の要素</param>
        /// <returns>変換後の要素</returns>
        static XElement TransformeElements(XElement vOriginalElements) {
            if (vOriginalElements == null) return null;
            return new XElement("word",
                new XAttribute("kanji", vOriginalElements.Element("kanji")?.Value ?? "不明"),
                new XAttribute("yomi", vOriginalElements.Element("yomi")?.Value ?? "不明")
            );
        }
    }
}
