using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1_1_1 {
    internal class Program {
        /*[問題1-1-1]
        　テキストで定義したProductクラスを使い、以下のコードを書いてください。

        　1.
        　どら焼きオブジェクトを生成するコードを書いてください。
        　このときの商品番号は"98"、商品価格は"210"としてください。

        　2.
        　どら焼きオブジェクトの消費税額を求め、コンソールに出力するコードを書いてください。

        　3.
        　Productクラスが属する名前空間を別の名前空間に変更し、Maiaメソッドから呼び出すようにしてください。
        　ただし、MainメソッドのあるProgramクラスの名前空間はそのままとしてください*/

        static void Main(string[] args) {
            /*1.→Product wDorayaki = new Product(98, "どら焼き", 210);

            　3.で名前空間を別の名前空間に変更したため、1.の解答はコメントとして表示しております。*/

            //3.
            ReChapter1_1_1.Product wDorayaki = new ReChapter1_1_1.Product(98, "どら焼き", 210);

            //2.
            int wDorayakiTax = wDorayaki.GetTax();
            Console.WriteLine(wDorayakiTax);           
        }
    }
}
