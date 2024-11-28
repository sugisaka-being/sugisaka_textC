using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter15_1_1 {
    internal class Program {
        /* [問題15-1-1]
        　　本文で利用したBook、Category、Libraryクラスを利用し、以下のコードを書いてください。

        　　1.
        　　Libraryクラスにコンストラクタを追加し、本章の最初に示した書籍のカテゴリデータと書籍データの値を、CategoriesプロパティとBooksプロパティにセットするコードを書いてください。

        　　2.
        　　最も価格の高い書籍を抽出し、その書籍の情報をコンソールに出力してください。

        　　3.
        　　発行年ごとに書籍の数をカウントして、その結果をコンソールに出力してください。

        　　4.
        　　発行年、価格の順（それぞれ値の大きい順）に並べ替え、その結果をコンソールに出力してください。

        　　5.
        　　2016年に発行された書籍のカテゴリ一覧を取得し、コンソールに出力してください。

        　　6.
        　　GroupByメソッドと使い、カテゴリごとに書籍を分類しカテゴリ名をアルファベット順に並び替え、
        　　その結果をコンソールに出力してください。

        　　7.
        　　カテゴリ"Development"の書籍に対して、発行年ごとに分類し、その結果をコンソールに出力してください。

        　　8.
        　　GroupJoinメソッドを使って4冊以上発行されているカテゴリ名を求め、そのカテゴリ名をコンソールに出力してください。
        */
        static void Main(string[] args) {
            // 2.
            var wMaxPrice = Library.Books.Max(x => x.Price);
            foreach (var wMaxPriceBook in Library.Books.Where(x => x.Price == wMaxPrice)) {
                Console.WriteLine(wMaxPriceBook);
            }
            Console.WriteLine(Environment.NewLine);

            // 3.
            foreach (var wPublishedYearGroup in Library.Books.GroupBy(x => x.PublishedYear).OrderBy(x => x.Key)) {
                Console.WriteLine($"{wPublishedYearGroup.Key}年　{wPublishedYearGroup.Count()}冊");
            }
            Console.WriteLine(Environment.NewLine);

            // 4.
            foreach (var wSortBook in Library.Books.OrderByDescending(x => x.PublishedYear).ThenByDescending(x => x.Price)) Console.WriteLine(wSortBook);
            Console.WriteLine(Environment.NewLine);

            // 5.
            var wSpecifyYear = 2016;
            IEnumerable<string> wBookCategories = Library.Books
                .Where(x => x.PublishedYear == wSpecifyYear)
                .Join(Library.Categories,
                x => x.CategoryId,
                y => y.Id,
                (x, y) => y.Name)
                .Distinct();
            foreach (var wBookCategory in wBookCategories) {
                Console.WriteLine(wBookCategory);
            }
            Console.WriteLine(Environment.NewLine);

            // 6.
            var wCategorizedBooks = Library.Books
                .Join(Library.Categories,
                x => x.CategoryId,
                y => y.Id,
                (x, y) => new {
                    Category = y.Name,
                    Title = x.Title,
                    Price = x.Price,
                    PublishedYear = x.PublishedYear,
                })
                .GroupBy(x => x.Category)
                .OrderBy(x => x.Key);
            foreach (var wCategorys in wCategorizedBooks) {
                Console.WriteLine($"カテゴリ名：{wCategorys.Key}");
                foreach (var wBook in wCategorys) {
                    Console.WriteLine($"　タイトル：{wBook.Title}, 価格：{wBook.Price}, 発行年：{wBook.PublishedYear}");
                }
            }
            Console.WriteLine(Environment.NewLine);

            // 7.
            var wSpecifyCategory = "Development";
            var wDevelopmentBooks = Library.Books
                .Join(Library.Categories,
                x => x.CategoryId,
                y => y.Id,
                (x, y) => new {
                    Category = y.Name,
                    Title = x.Title,
                    Price = x.Price,
                    PublishedYear = x.PublishedYear,
                })
                .Where(x => x.Category == wSpecifyCategory)
                .GroupBy(x => x.PublishedYear);
            foreach (var wBooksByYear in wDevelopmentBooks) {
                Console.WriteLine($"発行年：{wBooksByYear.Key}");
                foreach (var wBook in wBooksByYear) {
                    Console.WriteLine($"　タイトル：{wBook.Title}, 価格：{wBook.Price}");
                }
            }
            Console.WriteLine(Environment.NewLine);

            // 8.
            var wNumberBooks = 4;
            var wCategoriesWithFourMoreBooks = Library.Categories
                .GroupJoin(Library.Books,
                x => x.Id,
                y => y.CategoryId,
                (x, z) => new {
                    Category = x.Name,
                    Count = z.Count()
                })
                .Where(x => x.Count >= wNumberBooks);
            foreach (var wCategoryWithFourMoreBooks in wCategoriesWithFourMoreBooks) {
                Console.WriteLine($"カテゴリ名：{wCategoryWithFourMoreBooks.Category}（{wCategoryWithFourMoreBooks.Count}冊)");
            }
        }
    }
}
