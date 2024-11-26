using Chapter13_1_1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;

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
                var wAuthorsData = new List<Author> {
                    new Author { Name = "夏目漱石", Birthday = new DateTime(1867, 2, 9), Gender = "男性" },
                    new Author { Name = "太宰治", Birthday = new DateTime(1909, 6, 19), Gender = "男性" },
                    new Author { Name = "与謝野晶子", Birthday = new DateTime(1878, 12, 7), Gender = "女性" },
                    new Author { Name = "宮沢賢治", Birthday = new DateTime(1896, 8, 27), Gender = "男性" },
                    new Author { Name = "菊池寛", Birthday = new DateTime(1888, 12, 26), Gender = "男性" },
                    new Author { Name = "川端康成", Birthday = new DateTime(1899, 6, 14), Gender = "男性" },
                };
                var wBooksData = new List<Book> {
                    new Book{ Title = "坊ちゃん", PublishedYear = 2003, Author = wDataBase.Authors.FirstOrDefault(a => a.Name == "夏目漱石") },
                    new Book{ Title = "人間失格", PublishedYear = 1990, Author = wDataBase.Authors.FirstOrDefault(a => a.Name == "太宰治") },
                    new Book{ Title = "みだれ髪", PublishedYear = 2000, Author = wDataBase.Authors.FirstOrDefault(a => a.Name == "与謝野晶子") },
                    new Book{ Title = "銀河鉄道の夜", PublishedYear = 1989, Author = wDataBase.Authors.FirstOrDefault(a => a.Name == "宮沢賢治") },
                    new Book{ Title = "こころ", PublishedYear = 1991, Author = wDataBase.Authors.FirstOrDefault(a => a.Name == "夏目漱石") },
                    new Book{ Title = "伊豆の踊子", PublishedYear = 2003, Author = wDataBase.Authors.FirstOrDefault(a => a.Name == "川端康成") },
                    new Book{ Title = "真珠夫人", PublishedYear = 2002, Author = wDataBase.Authors.FirstOrDefault(a => a.Name == "菊池寛") },
                    new Book{ Title = "注文の多い料理店", PublishedYear = 2000, Author = wDataBase.Authors.FirstOrDefault(a => a.Name == "宮沢賢治") },
                };

                // 1.
                AddAuthors(wAuthorsData, wDataBase);
                AddBooks(wBooksData, wDataBase);

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
                RecordRemoveLog(RemoveBook("人間失格", wDataBase), wInputFile);
            }
        }

        /// <summary>
        /// 著者情報を追加するメソッド
        /// </summary>
        /// <param name="vAuthors">著者情報</param>
        /// <param name="vDataBase">データベース</param>
        static void AddAuthors(IEnumerable<Author> vAuthors, BooksDbContext vDataBase) {
            var wExistingAuthors = vDataBase.Authors.Select(x => x.Name).ToList();
            var wNewAuthors = vAuthors.Where(x => !wExistingAuthors.Contains(x.Name)).ToList();
            if (wNewAuthors == null) return;
            vDataBase.Authors.AddRange(wNewAuthors);
            try {
                vDataBase.SaveChanges();
            } catch (Exception wEx) {
                Console.WriteLine($"データベース保存時にエラーが発生しました: {wEx.Message}");
                return;
            }
        }

        /// <summary>
        /// 書籍情報を追加するメソッド
        /// </summary>
        /// <param name="vBooks">書籍情報</param>
        /// <param name="vDataBase">データベース</param>
        static void AddBooks(IEnumerable<Book> vBooks, BooksDbContext vDataBase) {
            var wExistingBooks = vDataBase.Books.Select(x => new { x.Title, x.PublishedYear, AuthorId = x.Author.Id }).ToList();
            var wNewBooks = vBooks.Where(x => !wExistingBooks.Any(y => y.Title == x.Title && y.PublishedYear == x.PublishedYear && y.AuthorId == x.Author.Id)).ToList();
            if (wNewBooks == null) return;
            vDataBase.Books.AddRange(wNewBooks);
            try {
                vDataBase.SaveChanges();
            } catch (Exception wEx) {
                Console.WriteLine($"データベース保存時にエラーが発生しました: {wEx.Message}");
                return;
            }
        }

        /// <summary>
        /// 書籍情報を削除するメソッド
        /// </summary>
        /// <param name="vTitle">タイトル</param>
        /// <param name="vDataBase">データベース</param>
        /// <returns>削除ログ</returns>
        static string RemoveBook(string vTitle, BooksDbContext vDataBase) {
            var wExistingBook = vDataBase.Books.FirstOrDefault(x => x.Title == vTitle);
            if (wExistingBook == null) {
                Console.WriteLine($"指定された書籍「{vTitle}」が存在しませんでした");
                return null;
            }
            string wOutputLog = $"[{DateTime.Now:yyyy/MM/dd HH:mm:ss}]　書籍削除 ： タイトル - {wExistingBook.Title}　発行年 - {wExistingBook.PublishedYear}　著者 - {wExistingBook.Author.Name}";
            vDataBase.Books.Remove(wExistingBook);
            try {
                vDataBase.SaveChanges();
                return wOutputLog;
            } catch (Exception wEx) {
                Console.WriteLine($"削除処理中にエラーが発生しました: {wEx.Message}");
                return null;
            }
        }

        /// <summary>
        /// 書籍の削除ログを記録するメソッド
        /// </summary>
        /// <param name="vOutputLog">削除ログ</param>
        /// <param name="vInputFile">ファイルパス（削除ログを記録するファイル）</param>
        static void RecordRemoveLog(string vOutputLog, string vInputFile) {
            try {
                File.AppendAllText(vInputFile, vOutputLog + Environment.NewLine);
            } catch (Exception wEx) {
                Console.WriteLine($"削除処理中にエラーが発生しました: {wEx.Message}");
                return;
            }
        }
    }
}
