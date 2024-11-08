using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Chapter11_1_1 {
    internal class Program {
        /* [問題11-1-1]
        　　次のXMLファイルがあります。
        　　このXMLファイルに対して、1.～4.のコードを書いてください。

        　　<?xml version="1.0" encoding="utf-8" ?>
        　　<ballSports>
        　　    <ballsport>
        　　        <name kanji="籠球">バスケットボール</name>
        　　        <teammembers>5</teammembers>
        　　        <firstplayed>1891</firstplayed>
        　　    </ballsport>
        　　    <ballsport>
        　　        <name kanji="排球">バレーボール</name>
        　　        <teammembers>6</teammembers>
        　　        <firstplayed>1895</firstplayed>
        　　    </ballsport>
        　　    <ballsport>
        　　        <name kanji="野球">ベースボール</name>
        　　        <teammembers>9</teammembers>
        　　        <firstplayed>1846</firstplayed>
        　　    </ballsport>
        　　</ballSports>

        　　1.
        　　XMLファイルを読み込み、競技名とチームメンバー数の一覧を表示してください。

        　　2.
        　　最初にプレーされた年の若い順に漢字の競技名を表示してください。

        　　3.
        　　メンバー人数が最も多い競技名を表示してください。

        　　4.
        　　サッカーの情報を追加して、新たなXMLファイルに出力してください。ファイル名は特に問いません。
        　　なお、サッカーの情報はご自身で調べてください。手間を惜しまずに調べることもプログラマーにとっては必要なことです。
        */
        static void Main(string[] args) {
            // 1.
            var wSportsFile = @"..\..\Sample11-1-1.xml";
            if (!File.Exists(wSportsFile)) {
                Console.WriteLine("指定されたファイルが存在しませんでした。");
                return;
            }
            var wSportsDocumement = XDocument.Load(wSportsFile);
            var wSportsElements = wSportsDocumement.Root.Elements();
            foreach (var wSportsElement in wSportsElements) {
                Console.WriteLine($"競技名：{wSportsElement.Element("name").Value}　チームメンバー数：{wSportsElement.Element("teammembers").Value}");
            }

            // 2.
            var wOrderYoungSports = wSportsElements.OrderBy(x => (int)x.Element("firstplayed"));
            foreach (var wOrderYoungSport in wOrderYoungSports) {
                Console.WriteLine($"競技名：{wOrderYoungSport.Element("name").Attribute("kanji").Value}　最初にプレーされた年：{wOrderYoungSport.Element("firstplayed").Value}年");
            }

            // 3.
            var wMaxMemberSport = wSportsElements.OrderByDescending(x => int.Parse(x.Element("teammembers").Value)).First();
            Console.WriteLine($"競技名：{wMaxMemberSport.Element("name").Value}　メンバー人数：{wMaxMemberSport.Element("teammembers").Value}人");

            // 4.
            var wSoccerDocument = new XElement("ballsport",
                new XElement("name", "サッカー", new XAttribute("kanji", "蹴球")),
                new XElement("teammembers", "11"),
                new XElement("firstplayed", "1863")
            );
            wSportsDocumement.Root.Add(wSoccerDocument);
            wSportsDocumement.Save(@"..\..\NewSample11-1-1.xml");
        }
    }
}

