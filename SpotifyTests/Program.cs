using System;
using System.Linq;
using System.Threading.Tasks;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;

namespace SpotifyTests
{
    class Program
    {
        static void Main(string[] args)
        {
            UsefulStuff.GetPlaylistByUrl("https://open.spotify.com/user/svr333-be/playlist/3B70EOUreoxQiFNi1v7VIE?si=ypo4zGUaQqOF6HgKxxYccA");

            /*var privateAccount = GetPrivateAccount("BQDxlwlekTTglEMdIJeXQrqKznMaKEwhpP0dQOd1RBLfKnTbWeugdSpieYgkfx5RnoWaitb6isM0cm821Crb-lCAQfHI04CMFOwR1N6DSd_3fNXl8jAjTUdLquVJUL7shgqbYOhz26X6u2mXScVhSA").Result;
            if (privateAccount is null) { Console.WriteLine("Account not found."); }

            var publicAccount = GetPublicAccount("svr333-be");

            Console.WriteLine(privateAccount.Id);*/
            Console.ReadLine();
        }

        /// <summary>
        /// Gets the account name by token.
        /// </summary>
        public static async Task<PrivateProfile> GetPrivateAccount(string token)
        {
            SpotifyWebAPI api = new SpotifyWebAPI
            {
                UseAuth = true,
                AccessToken = token,
                TokenType = "Bearer"
            };

            PrivateProfile profile = await api.GetPrivateProfileAsync();
            if (!profile.HasError()) { return profile; }

            return null;
        }

        public static async Task<PublicProfile> GetPublicAccount(string name)
        {
            SpotifyWebAPI api = new SpotifyWebAPI { UseAuth = false };
            var profile = api.GetPublicProfile(name);
            Console.WriteLine(profile.Id);
            return profile;
        }

        public static async Task GetPlaylist(string userId, string playlistId)
        {
            SpotifyWebAPI api = new SpotifyWebAPI
            {
                UseAuth = true,
                AccessToken = "BQDxlwlekTTglEMdIJeXQrqKznMaKEwhpP0dQOd1RBLfKnTbWeugdSpieYgkfx5RnoWaitb6isM0cm821Crb-lCAQfHI04CMFOwR1N6DSd_3fNXl8jAjTUdLquVJUL7shgqbYOhz26X6u2mXScVhSA",
                TokenType = "Bearer"
            };
            var playlist = api.GetPlaylist(userId, playlistId);
            Console.WriteLine($"{playlist.Tracks.Total}");
        }
    }
}
