namespace Chapter2_1_1 {
    /// <summary>
    /// 歌クラス
    /// </summary>
    internal class Song {
        // 1.
        /// <summary>
        /// 歌のタイトル
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// アーティスト名
        /// </summary>
        public string ArtistName { get; }

        /// <summary>
        /// 演奏時間（単位は秒）
        /// </summary>
        public int Length { get; }
        
        // 2.
        /// <summary>
        /// 歌クラスのコンストラクタ
        /// </summary>
        /// <param name="vTitle">歌のタイトル</param>
        /// <param name="vArtistname">アーティスト名</param>
        /// <param name="vLength">演奏時間（単位は秒）</param>
        public Song(string vTitle, string vArtistname, int vLength) {
            this.Title = vTitle;
            this.ArtistName = vArtistname;
            this.Length = vLength;
        }
    }
}
