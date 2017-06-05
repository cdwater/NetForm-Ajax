using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetForm.Ajax.Ajax
{
    /// <summary>
    /// SelectCityHandler 的摘要说明
    /// </summary>
    public class SelectCityHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //1.接收参数，为空，给个字符串"0"
            var provinceId = context.Request["provinceId"]??"0";
            //2.根据选中省ID 获取市区



            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}