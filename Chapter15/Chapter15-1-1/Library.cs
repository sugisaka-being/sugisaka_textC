using System.Collections.Generic;

namespace Chapter15_1_1 {
    /// <summary>
    /// ライブラリクラス
    /// </summary>
    internal class Library {
        /// <summary>
        /// カテゴリの一覧
        /// </summary>
        public static IEnumerable<Category> Categories { get; }

        /// <summary>
        /// 書籍の一覧
        /// </summary>
        public static IEnumerable<Book> Books { get; }

        /// <summary>
        /// ライブラリクラスのコンストラクタ
        /// </summary>
        static Library() {
            // 1.
            Categories = new List<Category> {
                new Category { Id = 1, Name = "Development" },
                new Category { Id = 2, Name = "Serever"  },
                new Category { Id = 3, Name = "Web Design"  },
                new Category { Id = 4, Name = "Windows"  },
                new Category { Id = 5, Name = "Application"  },
            };

            Books = new List<Book> {
                new Book { Title = "Writing C# Solid Code", CategoryId = 1, Price = 2500, PublishedYear = 2016 },
                new Book { Title = "C#開発指南", CategoryId = 1, Price = 3800, PublishedYear = 2014 },
                new Book { Title = "Visual C#再入門", CategoryId = 1, Price = 2780, PublishedYear = 2016 },
                new Book { Title = "フレーズで学ぶC# Book", CategoryId = 1, Price = 2400, PublishedYear = 2016 },
                new Book { Title = "TypeScript初級講座", CategoryId = 1, Price = 2500, PublishedYear = 2015 },
                new Book { Title = "PowerShell 実践レシピ", CategoryId = 2, Price = 4200, PublishedYear = 2013 },
                new Book { Title = "SQL Server 完全入門", CategoryId = 2, Price = 3800, PublishedYear = 2014 },
                new Book { Title = "IIS Webサーバー運用ガイド", CategoryId = 2, Price = 3180, PublishedYear = 2015 },
                new Book { Title = "Microsoft Azureサーバー構築", CategoryId = 2, Price = 4800, PublishedYear = 2016 },
                new Book { Title = "Webデザイン講座 HTML5＆CSS", CategoryId = 3, Price = 2800, PublishedYear = 2013 },
                new Book { Title = "HTML5 Web大百科", CategoryId = 3, Price = 3800, PublishedYear = 2015 },
                new Book { Title = "CSSデザイン 逆引き辞典", CategoryId = 3, Price = 3550, PublishedYear = 2015 },
                new Book { Title = "Windows10で楽しくお仕事", CategoryId = 4, Price = 2280, PublishedYear = 2016 },
                new Book { Title = "Windows10使いこなし術", CategoryId = 4, Price = 1890, PublishedYear = 2015 },
                new Book { Title = "続Windows10使いこなし術", CategoryId = 4, Price = 2080, PublishedYear = 2016 },
                new Book { Title = "Windows10 やさしい操作入門", CategoryId = 4, Price = 2300, PublishedYear = 2015 },
                new Book { Title = "まるわかりMicrosoft Office入門", CategoryId = 5, Price = 1890, PublishedYear = 2015 },
                new Book { Title = "Word・Excel実践テンプレート集", CategoryId = 5, Price = 2600, PublishedYear = 2016 },
                new Book { Title = "たのしく学ぶExcel初級編", CategoryId = 5, Price = 2800, PublishedYear = 2015 },
            };
        }
    }
}
