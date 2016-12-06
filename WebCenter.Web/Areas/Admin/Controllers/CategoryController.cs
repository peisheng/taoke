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
    public class CategoryController : AdminBaseController
    {
        public CategoryController(IUnitOfWork UOF)
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

            var list = Uof.IcategoryService.GetAll().Select(p => new {
                category_name=p.category_name,
                id=p.id,
                parent_id=p.parent_id,
                sort=p.sort               
            }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
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
           category cate = Uof.IcategoryService.GetById(id);
            return Json(cate, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Save(string category_name,int? parent_id,int sort,int id=0)
        {
            if (id > 0)
            {
                category cate = Uof.IcategoryService.GetById(id);
                cate.sort = sort;
                cate.parent_id = parent_id;
                cate.category_name = category_name;
                Uof.IcategoryService.UpdateEntity(cate);
                return Json(cate);
            }
            else
            {
                category cate = new category() ;
                cate.category_name = category_name;
                cate.parent_id = parent_id;
                cate.sort = sort;
                Uof.IcategoryService.AddEntity(cate);
                return Json(cate);
            }
            
        }
        public ActionResult Delete(int id)
        {
            var b=Uof.IcategoryService.DeleteEntity(id);
            if(b)
            {
                return SuccessResult;
            }
            else
                return ErrorResult;
        }



    }
}