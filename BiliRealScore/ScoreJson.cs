using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreJson
{
    public class Vip
    {
        /// <summary>
        /// 
        /// </summary>
        public string avatar_subscript_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nickname_color { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int themeType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int vipStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int vipType { get; set; }
    }

    public class Vip_label
    {
        /// <summary>
        /// 
        /// </summary>
        public string bg_color { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int bg_style { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string border_color { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string label_theme { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string path { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string text_color { get; set; }
    }

    public class Author
    {
        /// <summary>
        /// 
        /// </summary>
        public string avatar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int mid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string uname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Vip vip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Vip_label vip_label { get; set; }
    }

    public class Stat
    {
        /// <summary>
        /// 
        /// </summary>
        public int disliked { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int liked { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int likes { get; set; }
    }

    public class ListItem
    {
        /// <summary>
        /// 
        /// </summary>
        public Author author { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ctime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int media_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int mid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int mtime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string progress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int review_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int score { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Stat stat { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public List<ListItem> list { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int next { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int total { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }
    }

}
