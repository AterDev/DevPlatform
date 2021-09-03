﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace Services.NewsCollectionService
{
    public class TwitterService
    {
        readonly string ConsumerKey = "yIODhSD86nZmZAJNEjTjEV3e2";
        readonly string ConsumerSecretKey = "LMMNULBLjv5bxtuaFnRQwHIu3oD2P0BwApjanAv5cheqQAxObx";
        readonly string AccessToken = "1073272833810169856-0JrCoEWLbPWXCTSpChtqtP2GgGzPcw";
        readonly string AccessSecretToken = "FnXjy66QYuKaKw1ADbRDpHK6CeFEGgyvVoMSZk1DKsiC0";

        readonly TwitterClient client;

        readonly ILogger _logger;
        readonly ContextBase _context;
        /// <summary>
        /// 需要关注的twitters
        /// </summary>
        public string[] Twitters { get; set; }
        public TwitterService(ILogger<TwitterService> logger, ContextBase context)
        {
            _logger = logger;
            _context = context;
            var userCredentials = new TwitterCredentials(ConsumerKey, ConsumerSecretKey, AccessToken, AccessSecretToken);
            client = new TwitterClient(userCredentials);
            Twitters = new string[] { "dotnet", "msdev", "googledevs", "BBCTech" };
        }

        public async Task StartAsync()
        {
            _logger.LogInformation("===Start=== Collect tweets");
            var tweets = await GetLastTweetsAsync();
            _logger.LogInformation("===Result=== collect tweets: " + tweets.Count);
            _logger.LogInformation("===Start=== Add tweets");
            await SaveTweetsAsync(tweets);
            _logger.LogInformation("===Result=== finish!");
        }

        public async Task SaveTweetsAsync(List<ThirdNews> list)
        {
            var result = new List<ThirdNews>(list);
            var news = await _context.ThirdNews.OrderByDescending(n => n.DatePublished)
                .Where(n => n.Type == NewsType.Tweet)
                .Take(50).ToListAsync();

            foreach (var item in list)
            {
                if (news.Any(n => n.IdentityId == item.IdentityId
                    || n.Title.Similarity(item.Title) >= 0.6))
                {
                    result.Remove(item);
                }
            }

            if (result.Count > 0)
            {
                await _context.AddRangeAsync(result);
                await _context.SaveChangesAsync();
                _logger.LogInformation("===Start=== Add tweets " + result.Count);
            }
        }

        public async Task<List<ThirdNews>> GetLastTweetsAsync()
        {
            var messages = new List<ThirdNews>();
            foreach (var keywords in Twitters)
            {
                var resSets = await SearchTwitterAsync("from:" + keywords);
                // Content中带引用链接的处理,如 https://t.co/DBGGs8QFcJ
                var messageSets = resSets.Select(s => new ThirdNews
                {
                    Provider = s.CreatedBy?.ScreenName,
                    AuthorName = s.CreatedBy?.ScreenName,
                    AuthorAvatar = s.CreatedBy.ProfileImageUrl400x400,
                    Description = s.FullText,
                    Title = s.FullText,
                    CreatedTime = s.CreatedAt,
                    Url = s.Url,
                    Category = s.Hashtags.Count > 0 ? s.Hashtags.Select(t => t.Text).FirstOrDefault() : null,
                    ThumbnailUrl = s.Media.FirstOrDefault()?.MediaURL,
                    Type = NewsType.Tweet
                }).ToList();
                messages.AddRange(messageSets);
            }
            // 去除重复的identityId
            messages.GroupBy(m => m.IdentityId).Select(g => g.First()).ToList();
            return messages;
        }


        public async Task<IEnumerable<ITweet>> SearchTwitterAsync(string keywords, int daysBefore = 1)
        {
            var searchParameter = new SearchTweetsParameters(keywords)
            {
                SearchType = SearchResultType.Mixed,
                PageSize = 3,
                // 最近一天的消息
                Since = DateTime.UtcNow.AddDays(-daysBefore)
            };
            //var matchingTweets = Search.SearchTweets(keywords);
            var tweets = await client.Search.SearchTweetsAsync(searchParameter);
            return tweets;
        }
    }
}