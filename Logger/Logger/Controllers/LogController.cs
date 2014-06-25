using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Logger.Models;

namespace Logger.Controllers
{
    public class LogController : ApiController
    {
        public List<ApiModel> Get()
        {
            var db = new loggerEntities();
            var logs = db.logs.ToList();
            var li = new List<ApiModel>();
            foreach (var log in logs)
            {
                li.Add(new ApiModel
                {
                    action = log.action,
                    dateTime = log.actionDate.ToLongDateString(),
                    location = log.location,
                    page = log.page,
                    result = log.result,
                    userId = log.userId
                });
            }
            return li;
        }

        // POST api/log
        public ApiResultModel Post(List<ApiModel> logs)
        {
            try
            {
                var db = new loggerEntities();
                foreach (var log in logs)
                {
                    var newLog = new log
                    {
                        userId = log.userId,
                        actionDate = Convert.ToDateTime(log.dateTime),
                        location = log.location,
                        page = log.page,
                        action = log.action,
                        result = log.result
                    };
                    db.logs.Add(newLog);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                var strError = string.Format("Loglar kaydedilemedi.\nHata: {0}", e.Message);
                if (e.InnerException != null)
                {
                    strError = string.Format("{0}\nInnerException: {1}", strError, e.InnerException);
                }
                if (e.StackTrace != null)
                {
                    strError = string.Format("{0}\nStackTrace: {1}", strError, e.StackTrace);
                }

                return new ApiResultModel
                {
                    Succeed = false,
                    Reason = strError
                };
            }
            return new ApiResultModel
            {
                Succeed = true,
                Reason = ""
            };
        }
    }
}
