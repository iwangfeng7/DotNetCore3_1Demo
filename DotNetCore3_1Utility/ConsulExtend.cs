using Consul;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCore3_1Utility
{
    public static class ConsulExtend
    {
        private static int _RoundSeed { get; set; }
        private static int _WeightSeed { get; set; }

        /// <summary>
        /// 轮询
        /// </summary>
        /// <param name="consuldic"></param>
        /// <returns></returns>
        public static KeyValuePair<string, AgentService> AgentRound(this Dictionary<string, AgentService> consuldic)
        {
            var index = _RoundSeed++ % consuldic.Count;
            var result = consuldic.ToArray()[index];
            return result;
        }

        /// <summary>
        /// 权重
        /// </summary>
        /// <param name="consuldic"></param>
        /// <returns></returns>
        public static KeyValuePair<string, AgentService> AgentWeight(this Dictionary<string, AgentService> consuldic)
        {
            var list = consuldic.ToList();
            var pairsList = new List<KeyValuePair<string, AgentService>>();
            foreach (var pair in list)
            {
                int count = int.Parse(pair.Value.Tags?[0]);
                for (int i = 0; i < count; i++)
                {
                    pairsList.Add(pair);
                }
            }
            var result = pairsList.ToArray()[new Random(_WeightSeed++).Next(0, pairsList.Count())];
            return result;
        }

        /// <summary>
        /// 得到Consul所有实例
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, AgentService> ConsulAgentAll()
        {
            using (var client = new ConsulClient(c =>
            {
                c.Address = new Uri("http://localhost:8500/");
                c.Datacenter = "dc1";
            }))
            {
                var dictionary = client.Agent.Services().Result.Response;
                return dictionary;
            }
        }

        /// <summary>
        /// 注册Consul
        /// </summary>
        /// <param name="configuration"></param>
        public static void ConsulRegist(this IConfiguration configuration)
        {
            ConsulClient client = new ConsulClient(c =>
            {
                c.Address = new Uri("http://localhost:8500/");
                c.Datacenter = "dc1";
            });
            string ip = configuration["ip"];
            int port = int.Parse(configuration["port"]);//命令行参数必须传入
            int weight = string.IsNullOrWhiteSpace(configuration["weight"])
                ? 1
                : int.Parse(configuration["weight"]);//命令行参数必须传入
            client.Agent.ServiceRegister(new AgentServiceRegistration()
            {
                ID = "service" + port,//唯一的
                Name = "iwangfeng7api",//组名称-Group
                Address = ip,//其实应该写ip地址
                Port = port,//不同实例
                Tags = new string[] { weight.ToString() },//标签
                Check = new AgentServiceCheck()//配置心跳检查的
                {
                    Interval = TimeSpan.FromSeconds(12),
                    HTTP = $"http://{ip}:{port}/Api/Health/Index",
                    Timeout = TimeSpan.FromSeconds(5),
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5)
                }
            });
            Console.WriteLine($"http://{ip}:{port}完成注册");
        }

        public static string InvokeUrl(this KeyValuePair<string, AgentService> agent, string url)
        {
            var uri = new Uri(url);
            string groupName = uri.Host;
            var resultUrl = $"{uri.Scheme}://{agent.Value.Address}:{agent.Value.Port}{uri.PathAndQuery}";
            return resultUrl;
        }
    }
}