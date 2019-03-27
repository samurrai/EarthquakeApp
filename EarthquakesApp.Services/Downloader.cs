using EarthquakesApp.Services.Abstract;
using System;
using System.Net;

namespace EarthquakesApp.Services
{
    public class Downloader : IDownloader
    {
        private readonly ILogger logger;

        public Downloader(ILogger logger)
        {
            this.logger = logger;
        }
        public string Download(string url)
        {
            logger.LogMessage($"Загрузка {url}");
            using (var client = new WebClient())
            {
                try
                {
                    return client.DownloadString(url);
                }
                catch (WebException exception)
                {
                    logger.LogError(exception);
                    return exception.Message;
                }
                catch (Exception exception)
                {
                    return exception.Message;
                }
            }

        }
    }
}
