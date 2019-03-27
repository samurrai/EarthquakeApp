using EarthquakesApp.Models;
using EarthquakesApp.Services;
using EarthquakesApp.Services.Abstract;
using Newtonsoft.Json;


namespace EarthquakesApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new FileLogger();
            IDownloader downloader = new Downloader(logger);
            IRepository<FeatureCollection> repository = new XMLRepository<FeatureCollection>(logger);

            var data = downloader.Download("https://earthquake.usgs.gov/fdsnws/event/1/query?format=geojson&limit=50");

            if (!string.IsNullOrEmpty(data))
            {
                var deserializedData = JsonConvert.DeserializeObject<FeatureCollection>(data);
                repository.Add(deserializedData);
            }
            else
            {
                System.Console.WriteLine("Произошла ошибка, обратитесь к системному администратору");
                System.Console.ReadLine();
            }
        }
    }
}