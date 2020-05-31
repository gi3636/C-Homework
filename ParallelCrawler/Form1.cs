using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallelCrawler
{
    public partial class Form1 : Form
    {
        BindingSource result = new BindingSource();
        Crawler crawler;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = result;
            crawler = new Crawler();
            crawler.PageDownloaded += Crawler_PageDownloaded;
            textBox1.Text = "http://www.cnblogs.com/dstang2000/";
        }

        private void Crawler_PageDownloaded(Crawler crawler,int page, string url, string info)
        {
            var pageInfo = new { Index = page, URL = url, Status = info };
            Action action = () => { result.Add(pageInfo); };
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result.Clear();
            crawler.StarUrl = textBox1.Text;

            Match match = Regex.Match(crawler.StarUrl, Crawler.urlParseRegex);
            if (match.Length == 0) return;
            string host = match.Groups["host"].Value;
            crawler.HostFilter = "^" + host + "$";
            crawler.FileFilter = ".html?$";

            Thread thread = new Thread(crawler.start);
            thread.Start();
        }
    }
}
