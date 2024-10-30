using System;

namespace Chapter8_1_3 {
    internal class Program {
        /* [問題8-1-3]
        　　ある処理時間を計測するTimeWatchクラスを定義してください。
        　　TimeWatchの使い方を以下に示します。
        
        　　var tw = new TimeWatch();
        　　tw.Start();
        　　//処理
        　　TimeSpan duration = tw.Stop();
        　　Console.WriteLine("処理時間は{0}ミリ秒でした",duration.TotalMilliseconds);
        */
        static void Main(string[] args) {
            var tw = new TimeWatch();
            tw.Start();
            //処理
            TimeSpan wDuration = tw.Stop();
            Console.WriteLine("処理時間は{0}ミリ秒でした", wDuration.TotalMilliseconds);
        }
    }
}
