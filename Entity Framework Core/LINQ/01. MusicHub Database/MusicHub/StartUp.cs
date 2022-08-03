namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here

            // Task 02. Albums Info
            int producerId = 2;
           Console.WriteLine(ExportAlbumsInfo(context,producerId));
        }
        
        // Task 02. Albums Info
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder output = new StringBuilder();

            var albums = context.Albums
                .Where(x => x.ProducerId == producerId)
                .ToArray();

            foreach (var album in albums.OrderByDescending(a => a.Price))
            {
                output.AppendLine($"-AlbumName: {album.Name}");
                output
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate.Date.ToString("MM/dd/yyyy")}");
                output.AppendLine($"-ProducerName: {album.Producer.Name}");

                output.AppendLine("-Songs:");
                int songNum = 0;
                foreach (var song in album.Songs.OrderByDescending(s=>s.Name).ThenBy(w=>w.Writer))
                {
                    output.AppendLine($"---#{++songNum}");
                    output.AppendLine($"---SongName: {song.Name}");
                    output.AppendLine($"---Price: {song.Price:f2}");
                    output.AppendLine($"---Writer: {song.Writer.Name}");
                }

                output.AppendLine($"-AlbumPrice: {album.Price:f2}");
            }
            return output.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var output = new StringBuilder();

            var songs = context.Songs.Where(d => d.Duration.Seconds == duration).ToList();
            int songNum = 0;
            
            foreach (var song in songs)
            {
                output.AppendLine($"-Song #{++songNum}");
                output.AppendLine($"---SongName: {song.Name}");
                output.AppendLine($"---Writer: {song.Writer.Name}");
                //output.AppendLine($"---Performer: {song.SongPerformers");
                output.AppendLine($"---AlbumProducer: {song.Album.Producer.Name}");
                output.AppendLine($"---Duration: {song.Duration}");
            }

            return output.ToString();
        }
    }
}
