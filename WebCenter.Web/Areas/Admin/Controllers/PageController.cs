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
    public class PageController : AdminBaseController
    {
        public PageController(IUnitOfWork UOF)
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

        public ActionResult List(int page_index = 0, int page_size = 20)
        {
            var list = Uof.IpageService.GetAll().OrderByDescending(item => item.id).ToPagedList(page_index, page_size);
            var result = new
            {
                total_count = list.TotalCount,
                current_page = page_index,
                page_size = page_size,
                items = list.ToList()
            };
            return Json(result, JsonRequestBehavior.AllowGet);           
        }
        /// <summary>
        /// 取得产口详细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Get(int id)
        {
            if (id <= 0)
                return ErrorResult;
            page page
                = Uof.IpageService.GetById(id);
            return Json(page, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Save(string page_name,string page_title,string page_content, int id = 0)
        {
            if (id > 0)
            {
                page page = Uof.IpageService.GetById(id);
                page.page_name = page_name;
                page.page_content = page_content;
                page.page_title = page_title;
                Uof.IpageService.UpdateEntity(page);
                return Json(page);
            }
            else
            {
                page page = new page();
                page.page_name = page_name;
                page.page_content = page_content;
                page.page_title = page_title;
                Uof.IpageService.AddEntity(page);
                return Json(page);
            }

        }

        public ActionResult Delete(int id)
        {
            if (id > 0)
                Uof.IpageService.DeleteEntity(id);
            return SuccessResult;
        }
       



    }
}