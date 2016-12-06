using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCenter.IServices;
using WebCenter.Entities;
using Common;
using System.Web.Security;

namespace WebCenter.Web.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork UOF)
            : base(UOF)
        {

        }
        [HttpGet]
        public ActionResult List(string keyword, int pageSize = 20, int pageIndex = 1)
        {
            PagedList<product> page = Uof.IproductService.GetAll(p => p.coupon_start <= DateTime.Today && p.coupon_end<=DateTime.Today).OrderByDescending(p=>p.salary).ToPagedList(pageIndex, pageSize);
            return Json(page,JsonRequestBehavior.AllowGet);
        }


    }
}