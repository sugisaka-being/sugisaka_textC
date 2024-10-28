using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter6_1_2 {
    internal class Program {
        /* [問題6-1-2]
        　　次のようなリストが定義されています。
        　　var books = new List<Book> {
        　　    new Book { Title = "C#プログラミングの新常識", Price = 3800, Pages = 378 },
        　　    new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
        　　    new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
        　　    new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
        　　    new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
        　　    new Book { Title = "私でも分かったASP.NET MVC", Price = 3200, Pages = 453 },
        　　    new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
        　　};
        　　このbooksのリストに対して、以下のコードを書いてください。

        　　1.
        　　booksの中で、タイトルが"ワンダフル・C#ライフ"である書籍の価格とページ数を表示するコードを書いてください。

        　　2.
        　　booksの中で、タイトルに"C#"が含まれている書籍が何冊あるかカウントするコードを書いてください。

        　　3.
        　　booksの中で、タイトルに"C#"が含まれている書籍の平均ページ数を求めるコードを書いてください。

        　　4.
        　　booksの中で、価格が4000円以上の本で最初に見つかった書籍のタイトルを表示するコードを書いてください。

        　　5.
        　　booksの中で、価格が4000円未満の本で最大のページ数を求めるコードを書いてください。

        　　6.
        　　booksの中で、ページ数が400ページ以上の書籍を、価格の高い順に表示（タイトルと価格を表示）するコードを書いてください。

        　　7.
        　　booksの中で、タイトルに"C#"が含まれていてかつ500ページ以下の本を見つけ、本のタイトルを表示するコードを書いてください。
        　　複数見つかった場合は、そのすべてを表示してください。
        */
        static void Main(string[] args) {
            var wBooks = new List<Book> {
                new Book( "C#プログラミングの新常識", 3800, 378),
                new Book( "C#プログラミングの新常識", 3800,  378),
                new Book( "ラムダ式とLINQの極意", 2500, 312),
                new Book( "ワンダフル・C#ライフ", 2900, 385),
                new Book( "一人で学ぶ並列処理プログラミング", 4800, 464),
                new Book( "フレーズで覚えるC#入門", 5300, 604),
                new Book( "私でも分かったASP.NET MVC", 3200, 453),
                new Book( "楽しいC#プログラミング教室", 2540, 348),
            };

            // 1.
            if (wBooks.Where(x => x.Title == "ワンダフル・C#ライフ").Any()) {
                foreach (var wBook in wBooks.Where(x => x.Title == "ワンダフル・C#ライフ")) {
                    Console.WriteLine($"タイトル：{wBook.Title}、価格：{wBook.Price}、ページ数：{wBook.Pages}");
                }
            } else {
                Console.WriteLine("該当する書籍が見つかりませんでした。");
            }

            // 2.
            Console.WriteLine($"{wBooks.Count(x => x.Title.Contains("C#"))}冊");

            // 3.
            if (wBooks.Where(x => x.Title.Contains("C#")).ToList().Any()) {
                Console.WriteLine($"{wBooks.Where(x => x.Title.Contains("C#")).Average(x => x.Pages)}ページ");
            } else {
                Console.WriteLine("該当する書籍が見つかりませんでした。");
            }

            // 4.
            Console.WriteLine(wBooks.FirstOrDefault(x => x.Price >= 4000).Title ?? "該当する書籍が見つかりませんでした。");

            // 5.
            if (wBooks.Where(x => x.Price < 4000).ToList().Any()) {
                Console.WriteLine($"{wBooks.Where(x => x.Price < 4000).Max(x => x.Pages)}ページ");
            } else {
                Console.WriteLine("該当する書籍が見つかりませんでした。");
            }

            // 6.
            if (wBooks.Where(x => x.Pages >= 400).ToList().Any()) {
                foreach (var wBook in wBooks.Where(x => x.Pages >= 400).OrderByDescending(x => x.Price)) {
                    Console.WriteLine($"タイトル：{wBook.Title}、価格：{wBook.Price}");
                }
            } else {
                Console.WriteLine("該当する書籍が見つかりませんでした。");
            }

            // 7.
            if (wBooks.Where(x => x.Title.Contains("C#") && x.Pages <= 500).ToList().Any()) {
                foreach (var wBook in wBooks.Where(x => x.Title.Contains("C#") && x.Pages <= 500)) {
                    Console.WriteLine($"タイトル：{wBook.Title}、価格：{wBook.Price}、ページ数：{wBook.Pages}");
                }
            } else {
                Console.WriteLine("該当する書籍が見つかりませんでした。");
            }
        }
    }
}
