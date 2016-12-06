using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Top.Api;

namespace WebCenter.Web.Code
{
    public class TaoKeHelper
    {
        public TaoKeHelper()
        {
            var  serverUrl = "";
            var appKey = "";
            var secret = "";
            this.client = new DefaultTopClient(serverUrl,appKey,secret);
        }


        private ITopClient client
        {
            get;
            set;
        }

        public JsonNetResult getTbkUatmFavoritesItem()
        {
        }
    }
}