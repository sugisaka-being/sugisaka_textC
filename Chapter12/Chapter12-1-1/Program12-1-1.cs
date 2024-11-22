using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Chapter12_1_1 {
    internal class Program {
        /* [問題12-1-1]

        　　1.
        　　以下のEmployeeクラスが定義されています。
        　　このオブジェクトをXMLにシリアル化するコードと逆シリアル化するコードを、XmlSerializerクラスを使って書いてください。
        　　このとき、XMLの要素名（タグ名）は全て小文字にしてください。

        　　public class Employee {
        　　    public int Id { get; set; }
        　　    public string Name { get; set; }
        　　    public DateTime HireDate { get; set; }
        　　}

        　　2.
        　　複数のEmployeeオブジェクトが配列に格納されているとします。
        　　この配列をDataConstractSerializerクラスを使ってXMLファイルにシリアル化してください。

        　　3.
        　　2.で作成したファイルを読み込み、逆シリアル化してください。

        　　4.
        　　複数のEmployeeオブジェクトが配列に格納されているとします。
        　　この配列をDateConstractJsonSerializerを使って、JSONファイルに出力してください。
        　　このときのシリアル化対象にIdは含めないでください。
        */
        static void Main(string[] args) {
            var wEmployeesQuestionOne = new Employee[] {
                new Employee(1, "ああああ 太郎", new DateTime(2001, 1, 1)),
                new Employee(100, "いいいい 花子", new DateTime(2010, 11, 11)),
            };

            // 1.
            Console.WriteLine("XMLファイルのファイル名を入力してください。例）Employees12-1-1-1.xml");
            string wInputFile = Path.Combine(Environment.CurrentDirectory, Console.ReadLine());
            if (!CheckFile(wInputFile, ".xml")) return;
            using (var wEmployeesWriter = XmlWriter.Create(wInputFile)) {
                var wEmployeeSerializer = new XmlSerializer(wEmployeesQuestionOne.GetType());
                wEmployeeSerializer.Serialize(wEmployeesWriter, wEmployeesQuestionOne);
            }
            Console.WriteLine("指定されたファイルが出力されました。");

            using (var wEmployeesReader = XmlReader.Create(wInputFile)) {
                var wEmployeeSerializer = new XmlSerializer(typeof(Employee[]));
                var wReadEmployees = wEmployeeSerializer.Deserialize(wEmployeesReader) as Employee[];
                foreach (var wReadEmployee in wReadEmployees) {
                    Console.WriteLine(wReadEmployee);
                }
            }

            var wEmployeesQuestionTwo = new Employee[] {
                new Employee(10, "かかかか 太郎", new DateTime(2005, 5, 5)),
                new Employee(50, "きききき 花子", new DateTime(2015, 5, 5)),
            };

            // 2.
            var wEmployeesSettings = new XmlWriterSettings {
                Encoding = new UTF8Encoding(false),
                Indent = true,
                IndentChars = "  ",
            };
            Console.WriteLine("XMLファイルのファイル名を入力してください。例）Employees12-1-1-2.xml");
            string wInputQuestionTwo = Path.Combine(Environment.CurrentDirectory, Console.ReadLine());
            if (!CheckFile(wInputFile, ".xml")) return;
            using (var wEmployeeWriter = XmlWriter.Create(wInputQuestionTwo, wEmployeesSettings)) {
                var wEmployeeSerializer = new DataContractSerializer(wEmployeesQuestionTwo.GetType());
                wEmployeeSerializer.WriteObject(wEmployeeWriter, wEmployeesQuestionTwo);
            }
            Console.WriteLine("指定されたファイルが出力されました。");

            // 3.
            using (var wEmployeesReader = XmlReader.Create(wInputQuestionTwo)) {
                var wEmployeeSerializer = new DataContractSerializer(typeof(Employee[]));
                var wReadEmployees = wEmployeeSerializer.ReadObject(wEmployeesReader) as Employee[];
                foreach (var wReadEmployee in wReadEmployees) {
                    Console.WriteLine(wReadEmployee);
                }
            }

            var wEmployeesQuestionFour = new Employee2[] {
                new Employee2(30, "ささささ 太郎", new DateTime(2020, 1, 1)),
                new Employee2(80, "しししし 花子", new DateTime(2020, 2, 2)),
            };

            // 4.
            Console.WriteLine("JSONファイルのファイル名を入力してください。例）Employees12-1-1-4.json");
            string wInputJSONFile = Path.Combine(Environment.CurrentDirectory, Console.ReadLine());
            if (!CheckFile(wInputJSONFile, ".json")) return;
            using (var wEmploeesDataStream = new FileStream(wInputJSONFile, FileMode.Create, FileAccess.Write)) {
                var wEmployeeSerializer = new DataContractJsonSerializer(wEmployeesQuestionFour.GetType());
                wEmployeeSerializer.WriteObject(wEmploeesDataStream, wEmployeesQuestionFour);
            }
            Console.WriteLine("指定されたファイルが出力されました。");
        }

        /// <summary>
        /// ファイルの存在をチェックし、拡張子をオプションでチェックするメソッド
        /// </summary>
        /// <param name="vFilePath">ファイル名</param>
        /// <param name="vExtension">拡張子</param>
        /// <returns>ファイルが一致する場合や拡張子が一致する場合にtureを返す</returns>
        static bool CheckFile(string vFile, string vExtension = null) {
            if (!File.Exists(vFile)) {
                Console.WriteLine("指定されたファイルが存在しませんでした。");
                return false;
            }
            if (vExtension != null && Path.GetExtension(vFile).ToLower() != vExtension.ToLower()) {
                Console.WriteLine($"指定されたファイルは{vExtension}ファイルではありません。");
                return false;
            }
            return true;
        }
    }
}
