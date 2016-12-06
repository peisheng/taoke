﻿using Common;
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
    public class DictionaryController : AdminBaseController
    {
        public DictionaryController(IUnitOfWork UOF)
            : base(UOF)
        {

        }
        

        public ActionResult GetTypeDictList(string type)
        {
            var list = Uof.IdictionaryService.GetAll(p => p.group == type).ToList();
            var obj = list.Select(item => new
            {
                id = item.id,
                value = item.value,
                group = item.group
            });
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

      

        public ActionResult GetDictById(int id)
        {
            var dict = Uof.IdictionaryService.GetById(id);
            var obj = new
            {
                id = dict.id,
                name = dict.name,
                value = dict.value,
                group = dict.group
            };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 字典列表
        /// </summary>
        /// <param name="page_index"></param>
        /// <param name="page_size"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public ActionResult List(int page_index = 1, int page_size = 20, string group = "")
        {

            Expression<Func<dictionary, bool>> condition = dict => true;
            if (!string.IsNullOrEmpty(group))
            {
                string gro = group.Trim();
                Expression<Func<dictionary, bool>> tmp = dict => dict.group == gro;
                condition = tmp;
            }
            PagedList<dictionary> list = Uof.IdictionaryService.GetAll(condition).OrderByDescending(item => item.id).ToPagedList(page_index, page_size);
            if (list != null)
            {
                ArrayList al = new ArrayList();
                foreach (var item in list)
                {
                    var obj = new
                    {
                        id = item.id,
                        name = item.name,
                        group = item.group,
                        value = item.value
                    };
                    al.Add(obj);
                }
                var retObj = new
                {
                    total_count = list.TotalCount,
                    curent_page = page_index,
                    page_size = page_size,
                    items = al

                };
                return Json(retObj, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { result = false }, JsonRequestBehavior.AllowGet);
            }

        }


        [HttpGet]
        public ActionResult GroupList()
        {

            var list = Uof.IdictionaryService.GetAll().GroupBy(p => p.group).Select(item => item.Key).ToList();
            return Json(list,JsonRequestBehavior.AllowGet);

        }




        /// <summary>
        /// add & edit
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ActionResult Save(string dict)
        {
            dictionary _dict = new dictionary();    
            _dict = JsonConvert.DeserializeObject<dictionary>(dict);
            if (dict != null && _dict.id > 0)
            {
                Uof.IdictionaryService.UpdateEntity(_dict);
                AddLog("修改配置信息ID:" + _dict.id.ToString(), " 修改配置信息", "成功");

                return Json(new { 
                result=true,
                id=_dict.id                
                });
            }
            else
            {
                AddLog("添加配置信息ID:" + _dict.id.ToString(), " 添加配置信息", "成功");
               _dict= Uof.IdictionaryService.AddEntity(_dict);
                return Json(new
                {
                    result = true,
                    id = _dict.id
                });
            }
            return Json(new { result = false });
        }

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
       
        public ActionResult Delete(int id = 0)
        {
            if (id > 0)
            {
                bool b = Uof.IdictionaryService.DeleteEntity(id);
                if (b)
                {
                    return Json(new { result = true },JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { result = false },JsonRequestBehavior.AllowGet);
        }


    }
}