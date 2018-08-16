using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SimpleMeal.Helpers
{
    public static class YouTubeHelper
    {
        public static string GetVideoIdFromVideoUrl(string url)
        {
            var uri = new Uri(url);
            var query = HttpUtility.ParseQueryString(uri.Query);
            if (query.AllKeys.Contains("v"))
            {
                return query["v"];
            }
            return uri.Segments.Last();
        }

        public static string GetThumbnailUrlFromVideoUrl(string url, Quality quality)
        {
            string qualityExtension;

            switch (quality)
            {
                case Quality.Default:
                    qualityExtension = "/default.jpg";
                    break;
                case Quality.Medium:
                    qualityExtension = "/mqdefault.jpg";
                    break;
                case Quality.High:
                    qualityExtension = "/hqdefault.jpg";
                    break;
                case Quality.Standard:
                    qualityExtension = "/sddefault.jpg";
                    break;
                default:
                    qualityExtension = "/default.jpg";
                    break;
            }

            var id = GetVideoIdFromVideoUrl(url);
            var thumbnailUrl = "https://i.ytimg.com/vi/" + id + qualityExtension;
            return thumbnailUrl;
        }
    }

    public enum Quality
    {
        Default,
        Medium,
        High,
        Standard
    }
}
