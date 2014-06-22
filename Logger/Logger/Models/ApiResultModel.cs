using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logger.Models
{
    public class ApiResultModel
    {
        public bool Succeed { get; set; }
        public string Reason { get; set; }
    }

    public class ApiModel
    {
        public int userId { get; set; }
        public string dateTime { get; set; }
        public string location { get; set; }
        public string page { get; set; }
        public string action { get; set; }
        public string result { get; set; }
    }
}