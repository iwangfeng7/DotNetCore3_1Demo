using DotNetCore3_1Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DotNetCore3_1Demo.Controllers
{
    public class ApiShowController : Controller
    {
        public IActionResult Index()
        {
            var result = new List<ApiShow>();

            #region 直接调用

            {
                string url = "http://localhost:2020/api/First";
                var apiResult = WebApiExtend.InvokeApi(url);
                var list = JsonConvert.DeserializeObject<List<Person>>(apiResult);
                result.Add(new ApiShow()
                {
                    Brief = "直接调用",
                    Persons = list,
                    Url = url
                });
            }

            #endregion 直接调用

            #region 轮询

            {
                var agent = ConsulExtend.ConsulAgentAll().AgentRound();
                string url = "http://iwangfeng7api/api/First";
                var agentUrl = agent.InvokeUrl(url);
                var apiResult = WebApiExtend.InvokeApi(agentUrl);
                var list = JsonConvert.DeserializeObject<List<Person>>(apiResult);
                result.Add(new ApiShow()
                {
                    Brief = "轮询",
                    Persons = list,
                    Url = agentUrl
                });
            }

            #endregion 轮询

            #region 权重

            {
                var agent = ConsulExtend.ConsulAgentAll().AgentRound();
                string url = "http://iwangfeng7api/api/First";
                var agentUrl = agent.InvokeUrl(url);
                var apiResult = WebApiExtend.InvokeApi(agentUrl);
                var list = JsonConvert.DeserializeObject<List<Person>>(apiResult);
                result.Add(new ApiShow()
                {
                    Brief = "权重",
                    Persons = list,
                    Url = agentUrl
                });
            }

            #endregion 权重

            return View(result);
        }
    }

    #region 实体

    public class ApiShow
    {
        public string Brief { get; set; }
        public List<Person> Persons { get; set; }
        public string Url { get; set; }
    }

    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }

    #endregion 实体
}