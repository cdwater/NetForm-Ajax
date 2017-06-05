using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace NetForm.Ajax.Ajax
{
    /// <summary>
    /// SelectProvinceHandler 的摘要说明
    /// </summary>
    public class SelectProvinceHandler : IHttpHandler
    {
        //数据库连接字符串
        private static readonly string connstring =
        System.Configuration.ConfigurationManager.ConnectionStrings["testConnstring"].ConnectionString;

        public void ProcessRequest(HttpContext context)
        {

            //< option value = "1" > 北京 </ option >
            context.Response.ContentType = "text/html";
            var listProvinces = GetProvinceData();

            //循环
            StringBuilder sdb = new StringBuilder("<option value =\"0\">---请选择---</option>");
            foreach(var item in listProvinces)
            {
                sdb.AppendFormat("<option value=\"{0}\">{1}</option>",item.ProvinceId, item.ProvinceName);
            }

            context.Response.Write(sdb.ToString());
        }

        private List<Province> GetProvinceData()
        {
            string sql = @"select Id,ProvinceId,ProvinceName from TB_Province";

            List<Province> ListPro = null;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(connstring, System.Data.CommandType.Text, sql))
            {
                if(sdr.HasRows)
                {
                    ListPro = new List<Province>();
                    while(sdr.Read())
                    {
                        ListPro.Add(new Province() {
                            Id = Convert.ToInt32(sdr["Id"]),
                            ProvinceId = Convert.ToInt32(sdr["ProvinceId"]),
                            ProvinceName = sdr.GetValue(2).ToString()
                        });
                    }
                }
            }

            return ListPro;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public class Province
        {
            public int Id { get; set; }
            public int ProvinceId { get; set; }
            public string ProvinceName { get; set; }
        }
    }
}