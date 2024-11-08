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
            var wWordsFile = @"..\..\Sample11-1-2.xml";
            if (!File.Exists(wWordsFile)) {
                Console.WriteLine("指定されたファイルが存在しませんでした。");
                return;
            }
            var wWordsDocument = XDocument.Load(wWordsFile);
            var wNewWordsElements = wWordsDocument.Root.Elements()
                .Select(x => new XElement("word",
                    new XAttribute("kanji", x.Element("kanji").Value),
                    new XAttribute("yomi", x.Element("yomi").Value)
                ));
            var wWordsRoot = new XElement("difficultkanji", wNewWordsElements);
            wWordsRoot.Save(@"..\..\NewSample11-1-2.xml");
        }
    }
}
