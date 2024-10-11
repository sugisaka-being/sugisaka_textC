using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1_1_3 {
    internal class Program {
        /*[問題1-1-3]
        　テキストで示したPersonクラスを使い、以下のコードを書いてください。

        　1.
        　Personクラスを継承し、Studentクラスを定義してください。
        　Studentには、2つのプロパティ、Grage（学年）とClassNumber（組）を追加してください。
        　2つのプロパティとも型はintとします。

        　2.
        　Studentクラスのインスタンスを生成するコードを書いてください。
        　このとき、すべてのプロパティに値を設定してください。

        　3.
        　2.で生成したインスタンスの各プロパティの値をコンソールに出力するコードを書いてください。

        　4.
        　2.で生成したインスタンスをPerson型およびObject型の変数に代入できることを確認してください。*/

        static void Main(string[] args) {
            //2.
            Student wStudent = new Student {
                Name = "Reina",
                Birthday = new DateTime(2001, 11, 21),
                Grade = 1,
                ClassNumber = 1,
            };

            //3.
            Console.WriteLine("Student: ({0},{1},{2},{3})", wStudent.Name, wStudent.Birthday, wStudent.Grade, wStudent.ClassNumber);

            //4.
            object wStudent1 = wStudent;
            Person wStudent2 = wStudent;
        }
    }
}
