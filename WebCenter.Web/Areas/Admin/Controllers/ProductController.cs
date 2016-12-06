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
    public class ProductController : AdminBaseController
    {
        public ProductController(IUnitOfWork UOF)
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

        public ActionResult List(int page_index = 0, int page_size = 20, string keyword = "")
        {

            Expression<Func<product, bool>> condition = pro => true;
            if (!string.IsNullOrEmpty(keyword))
            {
                Expression<Func<product, bool>> tmp = prj => prj.product_name.IndexOf(keyword) > -1 || prj.product_desc.IndexOf(keyword) > -1;
                condition = tmp;
            }

            PagedList<product> list = Uof.IproductService.GetAll(condition).OrderByDescending(item => item.id).ToPagedList(page_index, page_size);

            var obj = new ArrayList();
            foreach (var item in list)
            {
                var it = new
                {
                    id = item.id,
                    product_name = item.product_name,
                    product_desc = item.product_desc,
                    catetgory_name=item.category==null?"":item.category.category_name,
                    seo_link_text=item.seo_link_text,
                    seo_title=item.seo_title,
                    seo_keyword=item.seo_keyword,
                    is_publish=item.is_publish.GetValueOrDefault(0)==0?"未发布":"已发布"
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
        /// <summary>
        /// 取得产口详细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Get(int id)
        {
            if (id <= 0)
                return ErrorResult;
            product pro = Uof.IproductService.GetById(id);
            return Json(pro, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Save(string productObj, List<int> imageIds)
        {
            product prod = JsonConvert.DeserializeObject<product>(productObj);
            if (prod != null)
            {
                if (prod.id > 0)
                {
                   product  getPro= Uof.IproductService.GetById(prod.id);
                   List<int> excepts= getPro.images.ToList().Select(p => p.id).ToList().Except(imageIds).ToList();
                   foreach (var item in excepts)
                   {
                       Uof.IimageService.DeleteEntity(item);
                   };
                   var obj= Uof.IimageService.GetAll(p => imageIds.Contains(p.id)).ToList();
                   foreach (var item in obj)
                   {
                       if (item.product_id != prod.id)
                       {
                           item.product_id = prod.id;
                           Uof.IimageService.Save(item.id,item);
                       }
                   }
                   getPro.main_image_id = prod.main_image_id;
                   getPro.product_desc = prod.product_desc;
                   getPro.product_features = prod.product_features;
                   getPro.product_name = prod.product_name;
                   getPro.product_specification = prod.product_specification;
                   getPro.seo_link_text = prod.seo_link_text;
                   getPro.seo_desc = prod.seo_desc;
                   getPro.seo_keyword = prod.seo_keyword;
                   getPro.seo_title = prod.seo_title;
                   getPro.amazon_url = prod.amazon_url;
                   getPro.franch_amazon_url = prod.franch_amazon_url;
                   getPro.germany_amazon_url = prod.germany_amazon_url;
                   getPro.Italy_amazon_url = prod.Italy_amazon_url;
                   getPro.japan_amazon_url = prod.japan_amazon_url;
                   getPro.spanish_amazon_url = prod.spanish_amazon_url;
                   getPro.uk_amazon_url = prod.uk_amazon_url;
                   getPro.categoryid = prod.categoryid;
                   Uof.IproductService.UpdateEntity(getPro);
                   var img=Uof.IimageService.GetById(prod.main_image_id.GetValueOrDefault(0));
                   if (img!=null)
                   {
                       img.product_id = prod.id;
                       Uof.IimageService.UpdateEntity(img);
                   }
                    
                }
                else
                {
                   prod= Uof.IproductService.AddEntity(prod);
                   var obj = Uof.IimageService.GetAll(p => imageIds.Contains(p.id)).ToList();
                   foreach (var item in obj)
                   {
                       if (item.product_id != prod.id)
                       {
                           item.product_id = prod.id;
                           Uof.IimageService.Save(item.id, item);
                       }
                   }
                   var img = Uof.IimageService.GetById(prod.main_image_id.GetValueOrDefault(0));
                   if (img != null)
                   {
                       img.product_id = prod.id;
                       Uof.IimageService.UpdateEntity(img);
                   }
                   
                   
                }
                return Json(prod);
                
            }
            return ErrorResult;
        }
        public ActionResult Delete(int id)
        {
            product pro = Uof.IproductService.GetById(id); ;
            pro.main_image_id = null;
            Uof.IproductService.UpdateEntity(pro);
            var list = Uof.IimageService.GetAll(p => p.product_id == pro.id).ToList();
            for (int i=0;i<list.Count;i++)
            {
                var item = list[i];
                Uof.IimageService.DeleteEntity(item); 
            }
            var b=Uof.IproductService.DeleteEntity(id);
            if(b)
            {
                return SuccessResult;
            }
            else
                return ErrorResult;
        }

        public ActionResult SetPublish(int type, int id)
        {

            product pro = Uof.IproductService.GetById(id);
            if (pro!=null)
            {
                pro.is_publish = type;
                Uof.IproductService.UpdateEntity(pro);

            }
            return SuccessResult;
                
        }



    }
}