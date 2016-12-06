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
    public class ContactmsgController : AdminBaseController
    {
        public ContactmsgController(IUnitOfWork UOF)
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

            Expression<Func<contact_msg, bool>> condition = cont => true;
            if (!string.IsNullOrEmpty(keyword))
            {
                Expression<Func<contact_msg, bool>> tmp = con => con.content.IndexOf(keyword) > -1 || con.name.IndexOf(keyword) > -1||con.phone.IndexOf(keyword)>-1||con.email.IndexOf(keyword)>-1;
                condition = tmp;
            }

            PagedList<contact_msg> list = Uof.Icontact_msgService.GetAll(condition).OrderByDescending(item => item.id).ToPagedList(page_index, page_size);

            
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
            contact_msg pro = Uof.Icontact_msgService.GetById(id);
            contact_msg result = pro;
            if (pro.is_read == null || pro.is_read == 0)
            {         

                result.is_read = 1;
                Uof.Icontact_msgService.UpdateEntity(pro);
            }
           


            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Save(contact_msg msg)
        {
            contact_msg contMsg = msg;
            if (contMsg != null)
            {
                if (contMsg.id > 0)
                {
                    Uof.Icontact_msgService.Save(contMsg.id, msg);
                }
                else
                {
                    Uof.Icontact_msgService.AddEntity(contMsg);
                }
                return Json(contMsg);
                
            }
            return ErrorResult;
        }
        public ActionResult Delete(int id)
        {
            var b = Uof.Icontact_msgService.DeleteEntity(id);
            if(b)
            {
                return SuccessResult;
            }
            else
                return ErrorResult;
        }



    }
}