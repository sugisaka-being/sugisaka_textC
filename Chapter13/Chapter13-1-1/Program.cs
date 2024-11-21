using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Chapter13_1_1.Models;

namespace Chapter13_1_1 {
    internal class Program {
        /* [問題13-1-1]
        　　本文で利用したデータベースを利用し、以下のコードを書いてください。

        　　1.
        　　以下の2名の著者と4冊の書籍を追加してください。

        　　（名前）　（生年月日）　　（性別）
        　　菊池寛　　1888年12月26日　男性
        　　川端康成　1899年6月14日 　男性

        　　（タイトル）　　　（発行年）　（著者）
        　　こころ　　　　　　1991　　　　夏目漱石
        　　伊豆の踊子　　　　2003　　　　川端康成
        　　真珠夫人　　　　　2002　　　　菊池寛
        　　注文の多い料理店　2000　　　　宮沢賢治

        　　2.
        　　すべての書籍情報を著者名とともに表示するコードを書き、上記1.のデータが正しく追加されたか確認してください。

        　　3.
        　　タイトルの最も長い書籍を求めてください。
        　　複数ある場合は、すべてを求めて表示してください。

        　　4.
        　　発行年の古い順に3冊だけ書籍を取得し、そのタイトルと著者名を求めてください。

        　　5.
        　　著者ごとに書籍のタイトルと発行年を表示してください。
        　　なお、著者は誕生日の遅い順（降順）に並べてください。
        */
        static void Main(string[] args) {
            using (var wDataBase = new BooksDbContext()) {
                var wSosekiNatsume = AddAuthor("夏目漱石", new DateTime(1867, 2, 9), "男性", wDataBase);
                AddBook("坊ちゃん", 2003, wSosekiNatsume, wDataBase);

                var wOsamudazai = AddAuthor("太宰治", new DateTime(1909, 6, 19), "男性", wDataBase);
                AddBook("人間失格", 1990, wOsamudazai, wDataBase);

                var wAkikoYosano = AddAuthor("与謝野晶子", new DateTime(1878, 12, 7), "女性", wDataBase);
                AddBook("みだれ髪", 2000, wAkikoYosano, wDataBase);

                var wKenjiMiyazawa = AddAuthor("宮沢賢治", new DateTime(1896, 8, 27), "男性", wDataBase);
                AddBook("銀河鉄道の夜", 1989, wKenjiMiyazawa, wDataBase);


                // 1.
                var wHiroshiKikuchi = AddAuthor("菊池寛", new DateTime(1888, 12, 26), "男性", wDataBase);
                var wYasunariKawabata = AddAuthor("川端康成", new DateTime(1899, 6, 14), "男性", wDataBase);

                AddBook("こころ", 1991, wSosekiNatsume, wDataBase);
                AddBook("伊豆の踊子", 2003, wYasunariKawabata, wDataBase);
                AddBook("真珠夫人", 2002, wHiroshiKikuchi, wDataBase);
                AddBook("注文の多い料理店", 2000, wKenjiMiyazawa, wDataBase);

                // 2.
                // データが正しく追加されていることを確認いたしました。

                // 3.
                var wLongTitleBooks = wDataBase.Books.Where(b => b.Title.Length == wDataBase.Books.Max(y => y.Title.Length)).ToList();
                foreach (var wLongTitleBook in wLongTitleBooks) Console.WriteLine($"タイトル：{wLongTitleBook.Title}　発行年：{wLongTitleBook.PublishedYear}　著者：{wLongTitleBook.Author.Name}");

                // 4.
                var wOldTopthreeBooks = wDataBase.Books.OrderBy(b => b.PublishedYear).Take(3).ToList();
                foreach (var wOldTopthreeBook in wOldTopthreeBooks) Console.WriteLine($"タイトル：{wOldTopthreeBook.Title}　発行年：{wOldTopthreeBook.PublishedYear}　著者：{wOldTopthreeBook.Author.Name}");

                // 5.
                var wAuthorGroups = wDataBase.Authors
                    .OrderByDescending(x => x.Birthday)
                    .Select(x => new {
                        Author = x,
                        Books = x.Books,
                    })
                    .ToList();
                foreach (var wAuthorGroup in wAuthorGroups) {
                    Console.WriteLine($"著者：{wAuthorGroup.Author.Name}　誕生日：{wAuthorGroup.Author.Birthday.ToString("yyyy年MM月dd日")}　性別：{wAuthorGroup.Author.Gender}");
                    foreach (var wBook in wAuthorGroup.Books) {
                        Console.WriteLine($"　タイトル：{wBook.Title}　発行年　{wBook.PublishedYear}");
                    }
                }

                // 追加課題
                // ①指定した書籍タイトルを削除するメソッドを追加してください。
                // ②削除された書籍のログを、テキストファイルとして記録する仕組みも実装してみてください。
                Console.WriteLine("削除された書籍のログを記録するテキストファイルのファイル名を入力してください。例）Sample13-1-1.txt");
                var wInputFile = Path.Combine(Environment.CurrentDirectory, Console.ReadLine());
                if (!File.Exists(wInputFile)) {
                    Console.WriteLine("指定されたファイルが存在しませんでした。");
                    return;
                }
                RemoveBook("人間失格", wDataBase, wInputFile);
            }
        }

        /// <summary>
        /// 著者情報を追加するメソッド
        /// </summary>
        /// <param name="vName">名前</param>
        /// <param name="vBirthday">誕生日</param>
        /// <param name="vGender">性別</param>
        /// <param name="vDataBase">データベース</param>
        static Author AddAuthor(string vName, DateTime vBirthday, string vGender, BooksDbContext vDataBase) {
            var wAuthor = vDataBase.Authors.FirstOrDefault(x => x.Name == vName);
            if (wAuthor != null) return wAuthor;
            wAuthor = new Author {
                Name = vName,
                Birthday = vBirthday,
                Gender = vGender,
            };
            vDataBase.Authors.Add(wAuthor);
            try {
                vDataBase.SaveChanges();
            } catch (Exception wEx) {
                Console.WriteLine($"データベース保存時にエラーが発生しました: {wEx.Message}");
                return null;
            }
            return wAuthor;
        }

        /// <summary>
        /// 書籍情報を追加するメソッド
        /// </summary>
        /// <param name="vTitle">タイトル</param>
        /// <param name="vPublishedYear">発行年</param>
        /// <param name="vAuthor">著者</param>
        /// <param name="vDataBase">データベース</param>
        static void AddBook(string vTitle, int vPublishedYear, Author vAuthor, BooksDbContext vDataBase) {
            var wExistingBook = vDataBase.Books.FirstOrDefault(x => x.Title == vTitle && x.PublishedYear == vPublishedYear && x.Author.Id == vAuthor.Id);
            if (wExistingBook != null) return;
            var wBook = new Book {
                Title = vTitle,
                PublishedYear = vPublishedYear,
                Author = vAuthor,
            };
            vDataBase.Books.Add(wBook);
            try {
                vDataBase.SaveChanges();
            } catch (Exception wEx) {
                Console.WriteLine($"データベース保存時にエラーが発生しました: {wEx.Message}");
                return ;
            }
        }

        /// <summary>
        /// 書籍情報を削除するメソッド
        /// </summary>
        /// <param name="vTitle">タイトル</param>
        /// <param name="vDataBase">データベース</param>
        /// <param name="vInputFile">ファイルパス（削除ログを記録するファイル）</param>
        static void RemoveBook(string vTitle, BooksDbContext vDataBase, string vInputFile) {
            var wExistingBook = vDataBase.Books.FirstOrDefault(x => x.Title == vTitle);
            if (wExistingBook == null) {
                Console.WriteLine($"指定された書籍「{vTitle}」が存在しませんでした");
                return;
            }
            string wOutputLog = $"[{DateTime.Now:yyyy/MM/dd HH:mm:ss}]　書籍削除 ： タイトル - {wExistingBook.Title}　発行年 - {wExistingBook.PublishedYear}　著者 - {wExistingBook.Author.Name}";
            vDataBase.Books.Remove(wExistingBook);
            try {
                vDataBase.SaveChanges();
                File.AppendAllText(vInputFile, wOutputLog + Environment.NewLine);
            } catch (Exception wEx) {
                Console.WriteLine($"削除処理中にエラーが発生しました: {wEx.Message}");
                return;
            }
        }
    }
}
