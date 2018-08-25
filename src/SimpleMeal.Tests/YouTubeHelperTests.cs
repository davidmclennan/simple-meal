using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using FreshMvvm;
using SimpleMeal.Helpers;

namespace SimpleMeal.Tests
{
    public class YouTubeHelperTests
    {
        [Fact]
        public void GetVideoIdFromVideoUrlReturnsNullForNullUrl()
        {
            Assert.Null(YouTubeHelper.GetVideoIdFromVideoUrl(null));
        }

        [Fact]
        public void GetThumbnailUrlFromVideoUrlReturnsNullForNullUrl()
        {
            Assert.Null(YouTubeHelper.GetThumbnailUrlFromVideoUrl(null, Quality.Default));
        }

        [Theory]
        [InlineData("https://www.youtube.com/watch?v=jNQXAC9IVRw", "jNQXAC9IVRw")]
        [InlineData("https://www.youtube.com/watch?v=LeAltgu_pbM", "LeAltgu_pbM")]
        public void GetVideoIdFromVideoUrlReturnsVideoId(string url, string expectedId)
        {
            Assert.Equal(expectedId, YouTubeHelper.GetVideoIdFromVideoUrl(url));
        }

        [Theory]
        [InlineData("https://www.youtube.com/watch?v=jNQXAC9IVRw")]
        [InlineData("http://youtu.be/jNQXAC9IVRw")]
        public void GetVideoIdFromVideoUrlReturnsIdForDifferentUrlFormats(string url)
        {
            Assert.Equal("jNQXAC9IVRw", YouTubeHelper.GetVideoIdFromVideoUrl(url));
        }

        [Theory]
        [InlineData("https://www.youtube.com/watch?v=jNQXAC9IVRw", "https://i.ytimg.com/vi/jNQXAC9IVRw/default.jpg")]
        [InlineData("https://www.youtube.com/watch?v=LeAltgu_pbM", "https://i.ytimg.com/vi/LeAltgu_pbM/default.jpg")]
        public void GetThumbnailUrlFromVideoUrlReturnsThumbnailUrl(string url, string expectedUrl)
        {
            Assert.Equal(expectedUrl, YouTubeHelper.GetThumbnailUrlFromVideoUrl(url, Quality.Default));
        }

        [Theory]
        [InlineData(Quality.Default, "https://i.ytimg.com/vi/jNQXAC9IVRw/default.jpg")]
        [InlineData(Quality.Medium, "https://i.ytimg.com/vi/jNQXAC9IVRw/mqdefault.jpg")]
        [InlineData(Quality.High, "https://i.ytimg.com/vi/jNQXAC9IVRw/hqdefault.jpg")]
        [InlineData(Quality.Standard, "https://i.ytimg.com/vi/jNQXAC9IVRw/sddefault.jpg")]
        public void GetThumbnailUrlFromVideoUrlReturnsDifferentThumbnailQualityUrlBasedOnQualityEnum(Quality quality, string expectedUrl)
        {
            Assert.Equal(expectedUrl, YouTubeHelper.GetThumbnailUrlFromVideoUrl("https://www.youtube.com/watch?v=jNQXAC9IVRw", quality));
        }
    }
}
