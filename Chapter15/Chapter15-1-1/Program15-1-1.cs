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
        　　GroupByメソッドを使い、カテゴリごとに書籍を分類しカテゴリ名をアルファベット順に並び替え、
        　　その結果をコンソールに出力してください。

        　　7.
        　　カテゴリ"Development"の書籍に対して、発行年ごとに分類し、その結果をコンソールに出力してください。

        　　8.
        　　GroupJoinメソッドを使って4冊以上発行されているカテゴリ名を求め、そのカテゴリ名をコンソールに出力してください。
        */
        static void Main(string[] args) {
            var wLibraryBooks = Library.Books.ToList();
            if (wLibraryBooks == null) {
                Console.WriteLine("書籍のリストにデータが存在しません。データを追加してください。");
                return;
            }

            // 2.
            int wMaxPrice = wLibraryBooks.Max(x => x.Price);
            foreach (var wMaxPriceBook in wLibraryBooks.Where(x => x.Price == wMaxPrice)) {
                Console.WriteLine(wMaxPriceBook);
            }
            Console.WriteLine();

            // 3.
            foreach (var wPublishedYearGroup in wLibraryBooks.GroupBy(x => x.PublishedYear).OrderBy(x => x.Key)) {
                Console.WriteLine($"{wPublishedYearGroup.Key}年　{wPublishedYearGroup.Count()}冊");
            }
            Console.WriteLine();

            // 4.
            foreach (var wSortBook in wLibraryBooks.OrderByDescending(x => x.PublishedYear).ThenByDescending(x => x.Price)) {
                Console.WriteLine(wSortBook);
            }
            Console.WriteLine();

            // 5.
            var wSpecifyYear = 2016;
            IEnumerable<string> wBookCategories = wLibraryBooks
                .Where(vBook => vBook.PublishedYear == wSpecifyYear)
                .Join(Library.Categories,
                    vBook => vBook.CategoryId,
                    vCategory => vCategory.Id,
                    (vBook, vCategory) => vCategory.Name)
                .Distinct();
            foreach (var wBookCategory in wBookCategories) {
                Console.WriteLine(wBookCategory);
            }
            Console.WriteLine();

            // 6.
            var wBooksWithCategories = wLibraryBooks
                .Join(Library.Categories,
                    vBook => vBook.CategoryId,
                    vCategory => vCategory.Id,
                    (vBook, vCategory) => new {
                        Category = vCategory.Name,
                        Title = vBook.Title,
                        Price = vBook.Price,
                        PublishedYear = vBook.PublishedYear,
                    });
            var wGroupedAndSortedBooks = wBooksWithCategories
                .GroupBy(x => x.Category)
                .OrderBy(x => x.Key)
                .ToList();
            foreach (var wCategories in wGroupedAndSortedBooks) {
                Console.WriteLine($"カテゴリ名：{wCategories.Key}");
                foreach (var wBook in wCategories) {
                    Console.WriteLine($"　タイトル：{wBook.Title}, 価格：{wBook.Price}, 発行年：{wBook.PublishedYear}");
                }
            }
            Console.WriteLine();

            // 7.
            var wSpecifyCategory = "Development";
            var wBooksByYearInCategory = wBooksWithCategories
                .Where(x => x.Category == wSpecifyCategory)
                .GroupBy(x => x.PublishedYear);
            foreach (var wBooksByYear in wBooksByYearInCategory) {
                Console.WriteLine($"発行年：{wBooksByYear.Key}");
                foreach (var wBook in wBooksByYear) {
                    Console.WriteLine($"　タイトル：{wBook.Title}, 価格：{wBook.Price}");
                }
            }
            Console.WriteLine();

            // 8.
            var wNumberBooks = 4;
            var wCategoriesWithBooks = Library.Categories
                .GroupJoin(wLibraryBooks,
                    vCategory => vCategory.Id,
                    vBook => vBook.CategoryId,
                    (vCategory, vBook) => new {
                        Category = vCategory.Name,
                        Books = vBook
                    });
            foreach (var wCategoryWithFourMoreBooks in wCategoriesWithBooks.Where(x => x.Books.Count() >= wNumberBooks)) {
                Console.WriteLine($"カテゴリ名：{wCategoryWithFourMoreBooks.Category}（{wCategoryWithFourMoreBooks.Books}冊)");
            }
        }
    }
}
