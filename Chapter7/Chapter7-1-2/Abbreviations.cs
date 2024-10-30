using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Chapter7_1_2 {
    /// <summary>
    /// 略語と対応する日本語を管理するクラス
    /// </summary>
    internal class Abbreviations {

        // テキスト記載のプログラムを記述後、演習問題の解答を作成いたしました。

        /// <summary>
        /// 略語と日本語一覧
        /// </summary>
        private Dictionary<string, string> FAbbreviationCollection = new Dictionary<string, string>();

        /// <summary>
        /// 略語と対応する日本語を管理するクラスのコンストラクタ
        /// </summary>
        public Abbreviations() {
            var wFilePath = @"..\..\Abbreviations.txt";
            if (File.Exists(wFilePath)) {
                var wLines = File.ReadAllLines(wFilePath);
                FAbbreviationCollection = wLines.Select(x => x.Split('=')).ToDictionary(x => x[0], x => x[1]);
            } else {
                Console.WriteLine("ファイルが見つかりませんでした。");
            }
        }

        /// <summary>
        /// 略語と日本語一覧に要素を追加するメソッド
        /// </summary>
        /// <param name="vAbbr">略語</param>
        /// <param name="vJapanese">日本語</param>
        public void Add(string vAbbr, string vJapanese) {
            FAbbreviationCollection[vAbbr] = vJapanese;
        }

        /// <summary>
        /// 略語をキーにとるインデクサ
        /// </summary>
        /// <param name="vAbbr">略語</param>
        /// <returns>略語に対応する日本語（略語が登録されていない場合はnull）</returns>
        public string this[string vAbbr] {
            get {
                return FAbbreviationCollection.ContainsKey(vAbbr) ? FAbbreviationCollection[vAbbr] : null;
            }
        }

        /// <summary>
        /// 日本語から対応する略語を取り出すメソッド
        /// </summary>
        /// <param name="vJapanese">日本語</param>
        /// <returns>日本語に対応する略語</returns>
        public string ToAbbreviation(string vJapanese) {
            return FAbbreviationCollection.FirstOrDefault(x => x.Value == vJapanese).Key;
        }

        /// <summary>
        /// 日本語の位置を引数に与え、それが含まれる要素（Key, Value）を全て取り出すメソッド
        /// </summary>
        /// <param name="vSubstring">部分文字列</param>
        /// <returns>引数で受け取った部分文字列を含む用語全て</returns>
        public IEnumerable<KeyValuePair<string, string>> FindAll(string vSubstring) {
            foreach (var wItem in FAbbreviationCollection) {
                if (wItem.Value.Contains(vSubstring))
                    yield return wItem;
            }
        }

        // 1.
        /// <summary>
        /// 用語の数をカウント
        /// </summary>
        public int Count {
            get {
                return FAbbreviationCollection.Count();
            }
        }

        // 2.
        /// <summary>
        /// 要素を削除するメソッド
        /// </summary>
        /// <param name="vAbbr">略語</param>
        /// <returns>要素を削除できた場合はtrue、できなかった場合はfalse</returns>
        public bool Remove(string vAbbr) {
            return FAbbreviationCollection.Remove(vAbbr);
        }

        // 4.
        public void FetchAbbrsWithKey(Abbreviations vAbbrs, int vKey) {
            foreach (var wAbbr in FAbbreviationCollection.Where(x => x.Key.Length == vKey)) {
                Console.WriteLine($"{wAbbr.Key}={wAbbr.Value}");
            }
        }
    }
}
