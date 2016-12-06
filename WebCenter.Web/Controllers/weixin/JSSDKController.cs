using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Deepleo.Weixin.SDK.Helpers;
using WebCenter.Web.Models;
using Deepleo.Weixin.SDK.JSSDK;
using WebCenter.Web.Controllers;
using WebCenter.IServices;

namespace WebCenter.Web.Controllers
{
    public class JSSDKController : BaseController
    {

        public JSSDKController(IUnitOfWork UOF)
            : base(UOF)
        {
        }     
        
        public ActionResult Index()
        {
            var appId = WeixinConfig.AppID;
            var nonceStr = Util.CreateNonce_str();
            var timestamp = Util.CreateTimestamp();
            var domain = System.Configuration.ConfigurationManager.AppSettings["Domain"];
            var url = domain + Request.Url.PathAndQuery;
            var jsTickect = WeixinConfig.TokenHelper.GetJSTickect();
            var string1 = "";
            var signature = JSAPI.GetSignature(jsTickect, nonceStr, timestamp, url, out string1);
            var model = new JSSDKModel
            {
                appId = appId,
                nonceStr = nonceStr,
                signature = signature,
                timestamp = timestamp,
                shareUrl = url,
                jsapiTicket = jsTickect,
                shareImg = domain + Url.Content("/images/ad.jpg"),
                string1 = string1,
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult JsApi(string shareUrl="")
        {
         
                string url="";
            var appId = WeixinConfig.AppID;
            var nonceStr = Util.CreateNonce_str();
            var timestamp = Util.CreateTimestamp();
            var domain = System.Configuration.ConfigurationManager.AppSettings["Domain"];
            if (string.IsNullOrEmpty(shareUrl))
                url = domain + Request.Url.PathAndQuery;
            else
            {
                url = shareUrl;
            }
            var jsTickect = WeixinConfig.TokenHelper.GetJSTickect();
            var string1 = "";
            var signature = JSAPI.GetSignature(jsTickect, nonceStr, timestamp, url, out string1);
            var model = new JSSDKModel
            {
                appId = appId,
                nonceStr = nonceStr,
                signature = signature,
                timestamp = timestamp,
                shareUrl = url,
                jsapiTicket = jsTickect,
                //shareImg = domain + Url.Content("/images/ad.jpg"),
                string1 = string1,
            };
            return Json(model,JsonRequestBehavior.AllowGet);

        }


        public ActionResult Pay()
        {
            var appId = WeixinConfig.AppID;
            var nonceStr = Util.CreateNonce_str();
            var timestamp = Util.CreateTimestamp();
            var domain = System.Configuration.ConfigurationManager.AppSettings["Domain"];
            var url = domain + Request.Url.PathAndQuery;
            var jsTickect = WeixinConfig.TokenHelper.GetJSTickect();
            var string1 = "";
            var signature = JSAPI.GetSignature(jsTickect, nonceStr, timestamp, url, out string1);
            var userAgent = Request.UserAgent;
            var userVersion = userAgent.Substring(userAgent.LastIndexOf("/") + 1);//微信版本号高于或者等于5.0才支持微信支付
            var model = new JSPayModel
            {
                appId = appId,
                nonceStr = nonceStr,
                signature = signature,
                timestamp = timestamp,
                jsapiTicket = jsTickect,
                string1 = string1,
                userAgent = userAgent,
                userVersion = userVersion,
            };
            return View(model);
        }

    }
}
