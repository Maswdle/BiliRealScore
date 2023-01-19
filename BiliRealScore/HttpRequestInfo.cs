using NPOI.OpenXmlFormats.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpLib;
namespace BiliRealScore
{
    internal class HttpRequest
    {
        public string? media_id;
        public string? coursor;


        private string api = "https://api.bilibili.com/pgc/review/short/list?media_id=[MD]&ps=20&sort=0&cursor=[CR]";
        
        HttpRequest(string m,string c)
        {
            media_id = m;
            coursor = c;
            api.Replace("[MD]", media_id);
            api.Replace("[CR]", coursor);
        }
    }
}
