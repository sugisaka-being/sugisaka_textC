using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter7_1_1 {
    internal class Program {
        /* [問題7-1-1]
        　　"Cozy lummox gives smart squid who asks for job pen"という文字列があります。
        　　この文字列に対して、以下のコードを書いてください。

        　　1.
        　　各アルファベット文字（空白などアルファベット以外は除外）が何文字ずつ現れるかカウントするプログラムを書いてください。
        　　このときに、必ずディクショナリクラスを使ってください。
        　　大文字/小文字の区別はしないでください。
        　　以下の形式で出力してください。
        　　'A': 2
        　　'B': 1
        　　'C': 1
        　　'D': 1　...

        　　2.上記プログラムをSotedDictionary<TKey, TValue>を使って書き換えてください。
        */
        static void Main(string[] args) {
            var wSentence = "Cozy lummox gives smart squid who asks for job pen";

            // 1.
            var wLetterCount = new Dictionary<char, int>();
            foreach (var wLetter in wSentence) {
                var wUpperLetter = char.ToUpper(wLetter);
                if ('A' <= wUpperLetter && wUpperLetter <= 'Z') {
                    if (wLetterCount.ContainsKey(wUpperLetter)) {
                        wLetterCount[wUpperLetter]++;
                    } else {
                        wLetterCount[wUpperLetter] = 1;
                    }
                }
            }
            foreach (var wLetter in wLetterCount.OrderBy(x => x.Key)) {
                Console.WriteLine($"{wLetter.Key}: {wLetter.Value}");
            }

            // 2.
            var wLetterCountSort = new SortedDictionary<char, int>();
            foreach (var wLetter in wSentence) {
                var wUpperLetter = char.ToUpper(wLetter);
                if ('A' <= wUpperLetter && wUpperLetter <= 'Z') {
                    if (wLetterCountSort.ContainsKey(wUpperLetter)) {
                        wLetterCountSort[wUpperLetter]++;
                    } else {
                        wLetterCountSort[wUpperLetter] = 1;
                    }
                }
            }
            foreach (var wLetter in wLetterCountSort) {
                Console.WriteLine($"{wLetter.Key}: {wLetter.Value}");
            }
        }
    }
}
