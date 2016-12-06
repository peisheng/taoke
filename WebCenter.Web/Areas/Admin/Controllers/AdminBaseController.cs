using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCenter.IServices;
using WebCenter.Entities;
using CacheManager.Core;
using System.Configuration;
using Common;
using Newtonsoft.Json;
using WebCenter.Web.Code;
using System.Collections;



namespace WebCenter.Web.Controllers
{
    [JsonObject(IsReference = true)]
    public class AdminBaseController : Controller
    {

        protected ICache<object> Cache;
        protected IUnitOfWork Uof;



        public AdminBaseController(IUnitOfWork uof)
        {
            Uof = uof;
            Cache = CacheUtil.Cache;            
             
        }
        
        

        public ActionResult ErrorResult
        {
            get { return Json(new { result = false }, JsonRequestBehavior.AllowGet); }
        }
        public ActionResult SuccessResult
        {
            get { return Json(new { result = true }, JsonRequestBehavior.AllowGet); }
        }

        public void AddLog(string name, string descipt, string result)
        {
            operate_log log = new operate_log();
            log.create_time = DateTime.Now;
            log.desript = descipt;
            log.user_name = ControllerContext.HttpContext.User.Identity.Name;
            log.name = name;
            log.result = result;
            //Request.LogonUserIdentity
            //log.user_name = user_name;
            //log.user_id = user_id;
            Uof.Ioperate_logService.AddEntity(log);

        }

        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonNetResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }








    }
}