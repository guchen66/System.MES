using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace System.MES.Core.Services.GrainSign
{
    public interface IUrlShortenerGrain 
    {
        Task SetUrl(string shortenedRouteSegment, string fullUrl);
        Task<string> GetUrl();
    }

   /* public class UrlShortenerGrain : Grain, IUrlShortenerGrain
    {
        private KeyValuePair<string, string> _cache;

        public Task SetUrl(string shortenedRouteSegment, string fullUrl)
        {
            _cache = new KeyValuePair<string, string>(shortenedRouteSegment, fullUrl);
            return Task.CompletedTask;
        }

        public Task<string?> GetUrl()
        {
            return Task.FromResult(_cache.Value);
        }
    }*/
}
