using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Model.FormatModel
{
    public class React
    {
        public object data { get; set; }  //核心数据
        public int code { get; set; }       //状态码 1
        public string msg { get; set; }   //状态信息
        public string gotoUrl { get; set; }   //请求地址
        public string pagedHtml { get; set; }//分页html数据
    }
}
