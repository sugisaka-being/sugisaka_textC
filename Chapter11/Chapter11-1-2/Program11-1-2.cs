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
            Console.WriteLine("ファイル名を入力してください。例）Sample11-1-2.xml");
            var wOriginalWords = Path.Combine(Environment.CurrentDirectory, Console.ReadLine());
            if (!File.Exists(wOriginalWords)) {
                Console.WriteLine("指定されたファイルが存在しませんでした。");
                return;
            } else if (Path.GetExtension(wOriginalWords).ToLower() != ".xml") {
                Console.WriteLine("指定されたファイルはXMLファイルではありません。");
                return;
            }
            var wWordsDocument = XDocument.Load(wOriginalWords);
            var wNewWordsElements = wWordsDocument.Root.Elements()
                .Select(x => TransformElements(x));
            var wWordsRoot = new XElement("difficultkanji", wNewWordsElements);
            Console.WriteLine("新しい情報を保存するXMLファイルのファイル名を入力してください。例）NewSample11-1-2.xml");
            var wTransformedWords = Path.Combine(Environment.CurrentDirectory, Console.ReadLine());
            if (Path.GetExtension(wTransformedWords).ToLower() != ".xml") {
                Console.WriteLine("指定されたファイルはXMLファイルではありません。");
                return;
            }
            wWordsRoot.Save(wTransformedWords);
            if (!File.Exists(wTransformedWords)) {
                Console.WriteLine("指定されたファイルの保存に失敗しました。");
                return;
            }
            Console.WriteLine("指定されたファイルが保存されました。");
        }
        /// <summary>
        /// XMLデータを新しい形式に変換するメソッド
        /// </summary>
        /// <param name="vOriginalElement">元の要素</param>
        /// <returns>変換後の要素</returns>
        static XElement TransformElements(XElement vOriginalElement) {
            if (vOriginalElement == null) return null;
            return new XElement(vOriginalElement.Name, vOriginalElement.Elements().Select(x => new XAttribute(x.Name , x.Value)));
        }
    }
}
