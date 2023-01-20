using NPOI.OpenXmlFormats.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpLib;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.SS.Formula.Functions;
using System.Threading;
namespace BiliRealScore
{
    internal class RequestData: ExportExcel
    {
        public string? media_id;
        private string? coursor;
        private long total = 0;
        private long cnt = 0;
        public int average;
        public int sleepTime = 400;
        private const string base_url = "https://api.bilibili.com/pgc/review/[TYPE]/list?media_id=[MD]&ps=20&sort=0";
        private string url = "";
        private string? appendArg = "&cursor=[CR]";
        private long[] scores  = new long[12];

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="m">media id</param>
        ///
        public RequestData(string m)
        {
            media_id = m;
        }
        /// <summary>
        /// 设置获取类型
        /// </summary>
        /// <param name="Short">是否为短评</param>
        public void setType(bool Short)
        {
            if (Short) url = base_url.Replace("[TYPE]", "short");
            else url = base_url.Replace("[TYPE]", "long");
            url = url.Replace("[MD]", media_id);
        }
        private string getSingleData()
        {
            string finalUrl;
            if (coursor != null && coursor != "0")
            {
                string s_appendArg = appendArg.Replace("[CR]", coursor);
                finalUrl = url + s_appendArg;
            }
            else
            {
                finalUrl = url;
            }
            string? content = Http.Get(finalUrl).request();
            return content;
        }

        /// <summary>
        /// 获取所有的评价并记录
        /// </summary>
        /// <exception cref="Exception">获取失败</exception>
        public void getAllData()
        {
            string? content = getSingleData();
            JObject jobj;
            if (content == null)
            {
                throw new Exception("获取数据失败");
            }

            jobj = JObject.Parse(content);
            coursor = jobj["data"]["next"].ToString();
            try
            {
                while (true)
                {
                    foreach (var c in jobj["data"]["list"])
                    {
                        int t = int.Parse(c["score"].ToString());
                        total += t;
                        scores[t-1]++;
                        cnt++;
                    }
                    // 统计20个评价
                    Console.WriteLine("已下载了{0}条", cnt);
                    content = getSingleData();
                    jobj = null;
                    jobj = JObject.Parse(content);
                    coursor = jobj["data"]["next"].ToString();
                    if (coursor == "0") break;
                    Thread.Sleep(sleepTime);
                }
            }
            catch (Exception e)
            {

                throw new Exception("解析过程中出错", e);
            }

        }
        /// <summary>
        /// 获取平均值
        /// </summary>
        /// <returns>平均值: int</returns>
        public double getAverage()
        {
            return (double)total / cnt;
        }

        public void showScores()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(String.Format("{0} : {1}", i+1, scores[i]));
            }
        }

    }
}
