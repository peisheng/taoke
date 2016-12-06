using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCenter.IServices;
using Common;
using WebCenter.Entities;
using System.Linq.Expressions;
using System.Collections;
using Newtonsoft.Json;

namespace WebCenter.Admin.Controllers
{
     [JsonObject(IsReference = true)]
    public class ProjectController :BaseController
    {

        public ProjectController(IUnitOfWork UOF)
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
        [HttpGet]
       
        public ActionResult List(int page_index=0,int page_size=20,string keyword="",int company_id=0)
        {
            
            Expression<Func<project_case, bool>> condition = prj => true;
            if (!string.IsNullOrEmpty(keyword))
            {
                Expression<Func<project_case, bool>> tmp = prj => prj.title.Contains(keyword) || prj.descript.Contains(keyword);
                condition = tmp;
            }
            if(company_id>0)
            {
                Expression<Func<project_case, bool>> tmp = prj => prj.company.Id==company_id;
                condition = tmp;
            }
            
            PagedList<project_case> list=Uof.Iproject_caseService.GetAll(condition).OrderByDescending(item=>item.Id).ToPagedList(page_index,page_size);
            var obj = new ArrayList();
            foreach (var item in list)
            {
                var it = new
                {
                    id = item.Id,
                    title=item.title,
                    description=item.descript,
                    type_name=item.sys_dictionary==null?"":item.sys_dictionary.value,
                    view_count=item.view_count,
                    main_image_path=item.main_image_path
                };
                obj.Add(it);                
            }
            var result = new
            {
                total_count = list.TotalCount,
                current_page = page_index,
                page_size = page_size,
                items = obj
            };            
           
            return Json(result,JsonRequestBehavior.AllowGet);  
        }

        /// <summary>
        /// Set project_case view count
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult SetViewCount(int id=0)
        {
            if (id > 0)
            {
                project_case proj=   Uof.Iproject_caseService.GetById(id);
                if (proj != null)
                {
                    if (proj.view_count == null)
                        proj.view_count = 0;
                    proj.view_count = proj.view_count + 1;
                    Uof.Iproject_caseService.UpdateEntity(proj);
                }
                  
            }
            return Json(new { reuslt=true},JsonRequestBehavior.AllowGet);
        }

        //get project_case details with company info
        public ActionResult Get(int id=0)
        {
            if (id > 0)
            {
                project_case proj = Uof.Iproject_caseService.GetById(id);
                if (proj != null)
                {
                    company company = proj.company;
                    if (company != null)
                    {
                        var obj = new
                        {
                            id = proj.Id,
                            title = proj.title,
                            descript = proj.descript,
                            type_name = proj.sys_dictionary == null ? "" : proj.sys_dictionary.value,
                            content = proj.content,
                            user_name = proj.user == null ? "" : proj.user.user_name,
                            company = new {
                                name=company.name,
                                logo_path=company.logo_path,
                                mobile=company.mobile,
                                phone=company.phone,
                                address=company.address
                            }
                        };
                        return Json(obj,JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return Json(new { result=false},JsonRequestBehavior.AllowGet);

        }
       
	}
}