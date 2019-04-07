using System;

namespace SpotifyTests
{
    public static class UsefulStuff
    {
        private static string _userId;
        private static string _playlistId;

        public static void GetPlaylistByUrl(string url)
        {
            if (url.StartsWith("https://open.spotify.com"))
            {
                var parts = url.Split('/', StringSplitOptions.RemoveEmptyEntries);
                _userId = parts[3];
                _playlistId = parts[5].Split("?si=")[0];
            }

            else if (url.StartsWith("spotify:user:"))
            {
                var parts = url.Split(':');
                _userId = parts[2];
                _playlistId = parts[4];
            }

            else return;

            Console.WriteLine($"{_userId} | {_playlistId}");
            Program.GetPlaylist(_userId, _playlistId);
        }
    }
}