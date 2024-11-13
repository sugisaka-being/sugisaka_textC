﻿using System;
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
            Console.WriteLine("XMLファイルのファイル名を入力してください。例）Sample11-1-1.xml");
            var wSportsFile = Path.Combine("..", "..", Console.ReadLine());
            if (!File.Exists(wSportsFile)) {
                Console.WriteLine("指定されたファイルが存在しませんでした。");
                return;
            } else if (Path.GetExtension(wSportsFile).ToLower() != ".xml") {
                Console.WriteLine("指定されたファイルはXMLファイルではありません。");
                return;
            }
            var wSportsDocument = XDocument.Load(wSportsFile);
            var wSportsElements = wSportsDocument.Root.Elements();
            foreach (var wSportsElement in wSportsElements) {
                Console.WriteLine($"競技名：{wSportsElement.Element("name").Value}　チームメンバー数：{wSportsElement.Element("teammembers").Value}");
            }

            // 2.
            var wOrderYoungSports = wSportsElements.OrderBy(x => (int)x.Element("firstplayed"));
            foreach (var wOrderYoungSport in wOrderYoungSports) {
                Console.WriteLine($"競技名：{wOrderYoungSport.Element("name").Attribute("kanji").Value}　最初にプレーされた年：{wOrderYoungSport.Element("firstplayed").Value}年");
            }

            // 3.
            var wMaxMemberSport = wSportsElements.OrderByDescending(x => {
                if (int.TryParse(x.Element("teammembers").Value, out int wTeamMembers)) {
                    return wTeamMembers;
                } else {
                    Console.WriteLine("メンバー人数を数値に変換できませんでした。");
                    return 0;
                }
            })
            .First();
            Console.WriteLine($"競技名：{wMaxMemberSport.Element("name").Value}　メンバー人数：{wMaxMemberSport.Element("teammembers").Value}人");

            // 4.
            AddSportElement(wSportsDocument, "サッカー", "蹴球", 11, 1863);
            Console.WriteLine("新しい情報を保存するXMLファイルのファイル名を入力してください。例）NewSample11-1-1.xml");
            wSportsFile = Path.Combine("..", "..", Console.ReadLine());
            if (Path.GetExtension(wSportsFile).ToLower() != ".xml") {
                Console.WriteLine("指定されたファイルはXMLファイルではありません。");
                return;
            }
            wSportsDocument.Save(wSportsFile);
            if (!File.Exists(wSportsFile)) {
                Console.WriteLine("指定されたファイルの保存に失敗しました。");
                return;
            }
            Console.WriteLine("指定されたファイルが保存されました。");
        }
        /// <summary>
        /// スポーツを追加するメソッド
        /// </summary>
        /// <param name="vDocument">スポーツの情報の記録</param>
        /// <param name="vName">スポーツの名前</param>
        /// <param name="vKanji">漢字の名前</param>
        /// <param name="vTeamMembers">チームのメンバー数</param>
        /// <param name="vFirstPlayed">最初にプレーされた年</param>
        static void AddSportElement(XDocument vDocument, string vName, string vKanji, int vTeamMembers, int vFirstPlayed) {
            var wSportsElements = new XElement("ballsport",
                new XElement("name", vName, new XAttribute("kanji", vKanji)),
                new XElement("teammembers", vTeamMembers.ToString()),
                new XElement("firstplayed", vFirstPlayed.ToString())
            );
            vDocument.Root.Add(wSportsElements);
        }
    }
}

