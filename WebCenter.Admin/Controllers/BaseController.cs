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



namespace WebCenter.Admin.Controllers
{
    [JsonObject(IsReference = true)]
    public class BaseController : Controller
    {
      
        protected ICache<object> Cache;
        protected IUnitOfWork Uof;


       
        public BaseController(IUnitOfWork uof)
        {
            Uof = uof;
            Cache = CacheUtil.Cache;
            
        }

       






    }
}