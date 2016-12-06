using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCenter.IServices;
using WebCenter.Entities;
using System.Web.Security;
using System.Linq.Expressions;
using Common;
using System.Collections;
using Newtonsoft.Json;

namespace WebCenter.Admin.Controllers
{

    [JsonObject(IsReference = true)]
    public class CompanyController : BaseController
    {


        public CompanyController(IUnitOfWork UOF)
            : base(UOF)
        {
        }


        /// <summary>
        /// 工程微网列表
        /// </summary>
        /// <param name="page_index"></param>
        /// <param name="page_size"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public ActionResult List(int page_index, int page_size, string keyword = "")
        {
            Expression<Func<company, bool>> condition = com => true;
            if (!string.IsNullOrEmpty(keyword))
            {
                Expression<Func<company, bool>> tmp = com => com.name.Contains(keyword);
                condition = tmp;
            }
            PagedList<company> list = Uof.IcompanyService.GetAll(condition).OrderByDescending(item => item.Id).ToPagedList(page_index, page_size);

            List<int> listId= list.Select(p => p.Id).ToList();
            var companyList=Uof.IuserService.GetAll(item=>listId.Contains(item.Id)).GroupBy(item=>item.company_id).Select(item=>new {companyId=(int)item.Key,count=item.Count()}).ToList();
            var obj = new ArrayList();
            foreach (var item in list)
            {
                var it = new
                {
                    id = item.Id,
                    name = item.name,                  
                    type_name = item.sys_dictionary == null ? "" : item.sys_dictionary.value,
                    city_name = item.city == null ? "" : item.city.city_name,
                    author_name=item.user==null?"":item.user.real_name,
                    view_count=0,
                    article_count=item.project_case1.Count,
                    logo_path = item.logo_path,
                    member_count=companyList.FirstOrDefault(x=>x.companyId==item.Id)==null?0:companyList.FirstOrDefault(x=>x.companyId==item.Id).count,
                    create_time=item.create_time 
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
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get(int id = 0)
        {
            if (id > 0)
            {
                company com = Uof.IcompanyService.GetById(id);
                if (com != null)
                {

                    project_case proj = com.project_case;
                    if (proj != null)
                    {
                        var result = new
                          {
                              id = com.Id,
                              name = com.name,
                              type_name = com.sys_dictionary == null ? "" : com.sys_dictionary.value,
                              city_name = com.city == null ? "" : com.city.city_name,
                              phone = com.phone,
                              introduce_page = new
                              {
                                  id = proj.Id,
                                  title = proj.title,
                                  description = proj.descript,
                                  type_name = proj.sys_dictionary == null ? "" : proj.sys_dictionary.value,
                                  view_count = proj.view_count,
                                  main_image_path = proj.main_image_path
                              }
                          };
                        return Json(result,JsonRequestBehavior.AllowGet); 
                    }
                    else
                    {
                        var result = new
                        {
                            id = com.Id,
                            name = com.name,
                            type_name = com.sys_dictionary == null ? "" : com.sys_dictionary.value,
                            city_name = com.city == null ? "" : com.city.city_name,
                            phone = com.phone,
                            introduce_page = new { }
                        };
                        return Json(result, JsonRequestBehavior.AllowGet); 

                    }
                }
            }
            return Json(new {result=false },JsonRequestBehavior.AllowGet);

        }

    }
}