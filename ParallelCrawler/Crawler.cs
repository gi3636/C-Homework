using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParallelCrawler
{
    class Crawler
    {

        //表示是否下载成功
        private Dictionary<String, bool> hasDone = new Dictionary<string, bool>();
        private Queue<string> pending = new Queue<string>();
        public event Action<Crawler,int,string, string> PageDownloaded;

        public Dictionary<string, bool> DownloadedPages { get => hasDone; }
        private readonly string urlDetectRegex = @"(href|HREF)[]*=[]*[""'](?<url>[^""'#>]+)[""']";
        public static readonly string urlParseRegex = @"^(?<site>https?://(?<host>[\w.-]+)(:\d+)?($|/))(\w+/)*(?<file>[^#?]*)";
        public string StarUrl { get; set; }
        public Encoding HtmlEncoding { get; set; }
        public string HostFilter { get; set; } //主机过滤规则
        public string FileFilter { get; set; } //文件过滤规则
        static int countPage=0;
        List<Task> taskList;

        public Crawler()
        {
            HtmlEncoding = Encoding.UTF8;
            taskList = new List<Task>();
        }

        public void start()
        {

            pending.Enqueue(StarUrl);
            string html = download(StarUrl, 1);
            parse(html, StarUrl);
            hasDone[StarUrl] = true;
            PageDownloaded(this, 1, StarUrl, "success");

            while (taskList.Count < 50)
            {
                int index = taskList.Count()+1;
                Task task = Task.Run(() => crawl(index));
                taskList.Add(task);
            }
            Task.WaitAll(taskList.ToArray());
        }

        public void crawl(int page)
        {
          
            while (page < 50)
            {
                string url = pending.Dequeue();
                string html = download(url,page);
                hasDone[url] = true;
                parse(html, url);
                PageDownloaded(this, page,url, "success"); 
            }
        }


        public string download(string url,int page)
        {
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            string html = webClient.DownloadString(url);
            string fileName = page.ToString();
            File.WriteAllText(fileName+".html", html, Encoding.UTF8);
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


        public string convert(string link, string url)
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

