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
                new Employee {
                    Id = 1,
                    Name = "ああああ 太郎",
                    HireDate = new DateTime(2001, 1, 1),
                },
                new Employee {
                    Id = 100,
                    Name = "いいいい 花子",
                    HireDate = new DateTime(2010, 11, 11),
                },
            };

            // 1.
            Console.WriteLine("XMLファイルのファイル名を入力してください。例）Employees12-1-1-1.xml");
            string wReceivedFile = Path.Combine("..", "..", Console.ReadLine());
            if (!CheckExtension(wReceivedFile, ".xml")) return;
            using (var wEmployeesWriter = XmlWriter.Create(wReceivedFile)) {
                var wEmployeeSerializer = new XmlSerializer(wEmployeesQuestionOne.GetType());
                wEmployeeSerializer.Serialize(wEmployeesWriter, wEmployeesQuestionOne);
            }
            if (!CheckFile(wReceivedFile)) return;

            if (!CheckFileExtension(wReceivedFile, ".xml")) return;
            using (var wEmployeesReader = XmlReader.Create(wReceivedFile)) {
                var wEmployeeSerializer = new XmlSerializer(typeof(Employee[]));
                var wReadEmployees = wEmployeeSerializer.Deserialize(wEmployeesReader) as Employee[];
                foreach (var wReadEmployee in wReadEmployees) {
                    Console.WriteLine(wReadEmployee);
                }
            }

            var wEmployeesQuestionTwo = new Employee[] {
                new Employee {
                    Id = 10,
                    Name = "かかかか 太郎",
                    HireDate = new DateTime(2005, 5, 5),
                },
                new Employee {
                    Id = 50,
                    Name = "きききき 花子",
                    HireDate = new DateTime(2015, 5, 5),
                },
            };

            // 2.
            var wEmployeesSettings = new XmlWriterSettings {
                Encoding = new UTF8Encoding(false),
                Indent = true,
                IndentChars = "  ",
            };
            Console.WriteLine("XMLファイルのファイル名を入力してください。例）Employees12-1-1-2.xml");
            string wReceivedFileQuestionTwo = Path.Combine("..", "..", Console.ReadLine());
            if (!CheckExtension(wReceivedFileQuestionTwo, ".xml")) return;
            using (var wEmployeeWriter = XmlWriter.Create(wReceivedFileQuestionTwo, wEmployeesSettings)) {
                var wEmployeeSerializer = new DataContractSerializer(wEmployeesQuestionTwo.GetType());
                wEmployeeSerializer.WriteObject(wEmployeeWriter, wEmployeesQuestionTwo);
            }
            if (!CheckFile(wReceivedFileQuestionTwo)) return;

            // 3.
            if (!CheckFileExtension(wReceivedFileQuestionTwo, ".xml")) return;
            using (var wEmployeesReader = XmlReader.Create(wReceivedFileQuestionTwo)) {
                var wEmployeeSerializer = new DataContractSerializer(typeof(Employee[]));
                var wReadEmployees = wEmployeeSerializer.ReadObject(wEmployeesReader) as Employee[];
                foreach (var wReadEmployee in wReadEmployees) {
                    Console.WriteLine(wReadEmployee);
                }
            }

            var wEmployeesQuestionFour = new Employee2[] {
                new Employee2 {
                    Id = 30,
                    Name = "ささささ 太郎",
                    HireDate = new DateTime(2020, 1, 1),
                },
                new Employee2 {
                    Id = 80,
                    Name = "しししし 花子",
                    HireDate = new DateTime(2020, 2, 2),
                },
            };

            // 4.
            Console.WriteLine("JSONファイルのファイル名を入力してください。例）Employees12-1-1-4.json");
            string wReceivedJSONFile = Path.Combine("..", "..", Console.ReadLine());
            if (!CheckExtension(wReceivedJSONFile, ".json")) return;
            using (var wEmploeesDataStream = new FileStream(wReceivedJSONFile, FileMode.Create, FileAccess.Write)) {
                var wEmployeeSerializer = new DataContractJsonSerializer(wEmployeesQuestionFour.GetType());
                wEmployeeSerializer.WriteObject(wEmploeesDataStream, wEmployeesQuestionFour);
            }
            if (!CheckFile(wReceivedJSONFile)) return;
            Console.WriteLine("指定されたファイルが出力されました。");
        }
        /// <summary>
        /// ファイルの存在と拡張子をチェックするメソッド
        /// </summary>
        /// <param name="vFilePath">ファイル名</param>
        /// <param name="vExtension">拡張子</param>
        /// <returns>指定された拡張子でファイルが存在している場合、treueを返す</returns>
        static bool CheckFileExtension(string vFile, string vExtension) {
            if (!File.Exists(vFile)) {
                Console.WriteLine("指定されたファイルが存在しませんでした。");
                return false;
            } else if (Path.GetExtension(vFile).ToLower() != vExtension.ToLower()) {
                Console.WriteLine($"指定されたファイルは{vExtension}ファイルではありません。");
                return false;
            }
            return true;
        }
        /// <summary>
        /// ファイルの存在（出力されているか）をチェックするメソッド
        /// </summary>
        /// <param name="vFile">ファイル名</param>
        /// <returns>指定されたファイルが存在している場合（出力された場合）、trueを返す</returns>
        static bool CheckFile(string vFile) {
            if (!File.Exists(vFile)) {
                Console.WriteLine("指定されたファイルが出力されませんでした。");
                return false;
            }
            return true;
        }
        /// <summary>
        /// ファイルの拡張子をチェックするメソッド
        /// </summary>
        /// <param name="vFile">ファイル名</param>
        /// <param name="vExtension">拡張子</param>
        /// <returns>指定した拡張子とファイルの拡張子が一致している場合、trueを返す</returns>
        static bool CheckExtension(string vFile, string vExtension) {
            if (Path.GetExtension(vFile).ToLower() != vExtension.ToLower()) {
                Console.WriteLine($"指定されたファイルは{vExtension}ファイルではありません。");
                return false;
            }
            return true;
        }
    }
}
