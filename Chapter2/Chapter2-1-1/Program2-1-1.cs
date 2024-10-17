﻿using System;
using System.Collections.Generic;

namespace Chapter2_1_1 {
    internal class Program {
        /* [問題2-1-1]

        　　1.
        　　以下のプロパティを持つ、Songクラスを定義してください。
        　　Tiitle：string型（歌のタイトル）
        　　ArtistName：string型（アーティスト名）
        　　Length：int型（演奏時間、単位は秒）

        　　2.
        　　このとき、3つの引数を持つコンストラクタも定義してください。

        　　3.
        　　作成したSongクラスのインスタンスを複数生成し、配列songsに格納してください。

        　　4.
        　　配列に格納されたすべてのSongオブジェクトの内容をコンソールに出力してください。
        　　演奏時間の表示は、「4:16」のような書式にしてください。
        　　ただし、演奏時間は必ず60分未満と仮定してかまいません。
        */
        static void Main(string[] args) {

            // 3.
            Song[] wSongs = new Song[] {
            new Song("000", "aaa", 60),
            new Song("111", "bbb", 90),
            new Song("222", "ccc", 120),
            };

            // 4.
            foreach (var wSong in wSongs) {
                Console.WriteLine($"歌のタイトル：{wSong.Title}、アーティスト名：{wSong.ArtistName}、演奏時間{new TimeSpan(0, 0, wSong.Length).ToString(@"mm\:ss")}");
            }

            // 追加課題
            List<Song> wSongsList = new List<Song> {
            new Song("333", "ddd", 150),
            new Song("444", "eee", 180),
            new Song("555", "fff", 210)
            };

            foreach (var wSong in wSongsList) {
                Console.WriteLine($"歌のタイトル：{wSong.Title}、アーティスト名：{wSong.ArtistName}、演奏時間{new TimeSpan(0, 0, wSong.Length).ToString(@"mm\:ss")}");
            }
        }
    }
}
