using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project10
{
    class Crawler
    {
        //表示是否下载成功
        private Dictionary<String, bool> hasDone = new Dictionary<string, bool>();
        private Queue<string> pending = new Queue<string>();
        public event Action<Crawler, string, string> PageDownloaded;

        public Dictionary<string, bool> DownloadedPages { get => hasDone; }
        private readonly string urlDetectRegex = @"(href|HREF)[]*=[]*[""'](?<url>[^""'#>]+)[""']";
        public static readonly string urlParseRegex = @"^(?<site>https?://(?<host>[\w.-]+)(:\d+)?($|/))(\w+/)*(?<file>[^#?]*)";
        public string StarUrl { get; set; }
        public Encoding HtmlEncoding { get; set; }
        public string HostFilter { get; set; } //主机过滤规则
        public string FileFilter { get; set; } //文件过滤规则

        public Crawler()
        {
            HtmlEncoding = Encoding.UTF8;
        }

        public void crawl()
        {
            pending.Enqueue(StarUrl);

            while(hasDone.Count<50 && pending.Count > 0)
            {
                string url = pending.Dequeue();
                string html = download(url);
                hasDone[url] = true;
                PageDownloaded(this, url, "success");
                parse(html, url);
            }
        }


        public string download(string url)
        {
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            string html = webClient.DownloadString(url);
            string fileName = hasDone.Count.ToString();
            File.WriteAllText(fileName, html, Encoding.UTF8);
            return html;
        }

        public void parse(string html, string url)
        {
            var matches = new Regex(urlDetectRegex).Matches(html);
            foreach (Match match in matches)
            {
                string link = match.Groups["url"].Value;
                if (link == null)
                {
                    continue;
                }
                else
                {
                    link = convert(link, url);
                    Match linkUrlMatch = Regex.Match(link, urlParseRegex);
                    string host = linkUrlMatch.Groups["host"].Value;
                    string file = linkUrlMatch.Groups["file"].Value;
                    if (Regex.IsMatch(host, HostFilter) && Regex.IsMatch(file, FileFilter) && !hasDone.ContainsKey(link))
                    {
                        pending.Enqueue(link);
                    }
                }
            }
        }


        public string convert(string link,string  url)
        {
            if (link.Contains("://"))
            {
                return link;
            }
            if (url.StartsWith("/"))
            {
                Match urlMatch = Regex.Match(url, urlParseRegex);
                String site = urlMatch.Groups["site"].Value;
                return site.EndsWith("/") ? site + url.Substring(1) : site + url;
            }

            if (url.StartsWith("../"))
            {
                url = url.Substring(3);
                int idx = url.LastIndexOf('/');
                return convert(url, url.Substring(0, idx));
            }

            if (url.StartsWith("./"))
            {
                return convert(url.Substring(2), url);
            }

            int end = url.LastIndexOf("/");
            return url.Substring(0, end) + "/" + url;
        }
    }


}
