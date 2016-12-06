using Common;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebCenter.Entities;
using WebCenter.IServices;
using WebCenter.Web.Controllers;


namespace WebCenter.Web.Areas.Admin.Controllers
{
    public class SettingController : AdminBaseController
    {
        public SettingController(IUnitOfWork UOF)
            : base(UOF)
        {

        }

        /// <summary>
        /// get the project_case List
        /// </summary>
        /// <param name="page_index"></param>
        /// <param name="page_size"></param>
        /// <param name="keyword"></param>
        /// <param name="company_id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]

        public ActionResult List()
        {
           var list= Uof.IsettingService.GetAll().ToList();
           return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get(int id)
        {
            var list = Uof.IsettingService.GetById(id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        
        
        public ActionResult Save(setting set)
        {
            if (set.id > 0)
            {
                var obj = Uof.IsettingService.GetById(set.id);
                obj.id = set.id;
                obj.group = set.group;
                obj.name = set.name;
                obj.value = set.value;
                Uof.IsettingService.UpdateEntity(obj);

            }
            else
            {
                Uof.IsettingService.AddEntity(set);
            }
            return SuccessResult;
            
        }
        



    }
}