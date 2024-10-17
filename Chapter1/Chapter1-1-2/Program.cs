using System;

namespace Chapter1_1_2 {
    internal class Program {
        /* [問題1-1-2]
　　　　　　テキストで定義した、MyClassとMyStructの2つを使い、以下のコードを書いてください。

　　　　　　1.
　　　　　　MyClassとMyStructの2つの型を引数に取るメソッドPrintObjectsを定義してください。
        　　PrintObjectsメソッドでは、2つのオブジェクト内容（プロパティの値）をコンソールに表示するようにしてください。
        　　なお、PrintObjectsメソッドは、Programクラスのメソッドとして定義してください。

　　　　　　2.
　　　　　　Mainメソッドで、PrintObjectsメソッドを呼び出すコードを書いてください。
        　　MyClass、MyStructオブジェクトの値は、自由に決めてかまいません。

　　　　　　3.
　　　　　　PrintObjectsメソッド内で、それぞれのプロパティの値を2倍に変更するコードを追加してください。
        　　MainメソッドではPrintObjects呼び出しの後に、MyClass、MyStructオブジェクトのプロパティの値をコンソールに表示するコードを加えてください。
        
        　　4.
        　　上のコードを実行し、結果を確認してください。
        　　そしてどのような結果になったのか、理由を説明してください。 */

        static void Main(string[] args) {
            // 2.
            MyClass wMyClass1 = new MyClass { X = 10, Y = 20 };
            MyStruct wMyStruct1 = new MyStruct { X = 10, Y = 20 };
            PrintObject(wMyClass1, wMyStruct1);

            // 3.
            PrintDoubleObject(wMyClass1, wMyStruct1);
            Console.WriteLine($"MyClass4: ({wMyClass1.X},{wMyClass1.Y})");
            Console.WriteLine($"MyStruct4: ({wMyStruct1.X},{wMyStruct1.Y})");

            // 4.
            /* 3.の処理を行った後にMyClass、MyStructのオブジェクトを表示させると、
            　 MyClassのオブジェクトの値は2倍された状態で出力されるのに対して、
            　 MyStructのオブジェクトの値はオブジェクトを作成した際のそのままの状態で値が出力された。
            　 このような異なる結果になったのは、MyClassが参照型であり、MyStructが値型であることが理由として挙げられると考える。
            　 MyClassは参照型であるため、PrintDoubleObjectメソッドでオブジェクトの値を変更すると
            　 その参照を経由して呼び出し元のオブジェクトも変更されることとなる。
            　 一方で、MyStructは値型であるため、オブジェクトそのものがコピーされてPrintDoubleObjectメソッドに渡る。
           　  つまり、メソッドの中でオブジェクトの値を変更しても、呼び出し元はその変更の影響を受けないのだ。
            　 以上のようにMyClassとMyStructに参照型と値型の違いがあるということが結果の異なりを生んだ理由であると考える。 */
        }

        // 1.
        /// <summary>
        /// オブジェクトの値を表示
        /// </summary>
        /// <param name="vMyClass">クラス</param>
        /// <param name="vMyStruct">構造体</param>
        static void PrintObject(MyClass vMyClass, MyStruct vMyStruct) {
            Console.WriteLine($"MyClass1: ({vMyClass.X},{vMyClass.Y})");
            Console.WriteLine($"MyStruct1: ({vMyStruct.X},{vMyStruct.Y})");
        }
        // 3.
        /// <summary>
        /// オブジェクトの値を2倍して表示
        /// </summary>
        /// <param name="vMyClass">クラス</param>
        /// <param name="vMyStruct">構造体</param>
        static void PrintDoubleObject(MyClass vMyClass, MyStruct vMyStruct) {
            vMyClass.X *= 2;
            vMyClass.Y *= 2;
            vMyStruct.X *= 2;
            vMyStruct.Y *= 2;
            Console.WriteLine($"MyClass3: ({vMyClass.X},{vMyClass.Y})");
            Console.WriteLine($"MyStruct3: ({vMyStruct.X},{vMyStruct.Y})");
        }

    }
}
