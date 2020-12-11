using System;
using System.Threading.Tasks;
using SpotifyAPI.Web;

namespace SpotifyPlayerConsoleApp
{
    class Program
    {
        static async Task Main()
        {
            var config = SpotifyClientConfig.CreateDefault();

            var request = new ClientCredentialsRequest("f749aaeab36744b6b763119da2cd9d73", "18789c2c949b4008add5a37ddfd6fbef");
            var response = await new OAuthClient(config).RequestToken(request);
            var spotify = new SpotifyClient(config.WithToken(response.AccessToken));

            var track = await spotify.Tracks.Get("6by8WKAE9av5RFQPXacwUS");

            string trackName = track.Name;
            var artists = track.Artists;
            string albumName = track.Album.Name;
            int duration = track.DurationMs;

            /**
            //need to find a way to convert currently playing song Item JSON to values..... if possible
            var currentlyPlayingType = new PlayerCurrentlyPlayingRequest();
            currentlyPlayingType.Market = "EN";
            var currentSong = await spotify.Player.GetCurrentlyPlaying(currentlyPlayingType);
            var currentSongItem = currentSong.Item;
            var itemConverter = new SpotifyAPI.Web.PlayableItemConverter();
            **/
            
            Console.WriteLine($"Track Name is - {trackName} ");
            Console.WriteLine($"Artists are - {artists}");
            Console.WriteLine($"Album is - {albumName} ");
            Console.WriteLine($"Track Duration is - {duration} ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"");

        }
    }
}
