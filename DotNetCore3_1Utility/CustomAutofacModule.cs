using Autofac;
using Autofac.Configuration;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DotNetCore3_1Utility
{
    public class CustomAutofacModule : Autofac.Module
    {
        /// <summary>Override to add registrations to the container.</summary>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        /// <param name="containerBuilder">The builder through which components can be
        /// registered.</param>
        protected override void Load(ContainerBuilder containerBuilder)
        {
            #region 控制器实例化

            var assembly = Assembly.Load("DotNetCore3_1Demo");
            var builder = new ContainerBuilder();
            var manager = new ApplicationPartManager();
            manager.ApplicationParts.Add(new AssemblyPart(assembly));
            manager.FeatureProviders.Add(new ControllerFeatureProvider());
            var feature = new ControllerFeature();
            manager.PopulateFeature(feature);
            builder.RegisterType<ApplicationPartManager>().AsSelf().SingleInstance();
            builder.RegisterTypes(feature.Controllers.Select(ti => ti.AsType()).ToArray()).PropertiesAutowired();

            #endregion 控制器实例化

            #region 批量注册

            //builder.Populate(services);
            List<Type> types = new List<Type>();
            foreach (string item in new List<string>() { "DotNetCore3_1Service" })
            {
                // 加载接口服务实现层。
                Assembly SvrAss = Assembly.Load(item);
                // 反射扫描这个程序集中所有的类，得到这个程序集中所有类的集合。
                types.AddRange(SvrAss.GetTypes());
            }
            // 告诉AutoFac容器，创建stypes这个集合中所有类的对象实例  在一Http请求上下文中,共享一个组件实例
            var register = containerBuilder
                .RegisterTypes(types.ToArray())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .PropertiesAutowired();//指明创建的stypes这个集合中所有类的对象实例，以其接口的形式保存

            #endregion 批量注册

            #region Autofac 基于配置文件的服务注册

            //JSON格式配置文件
            var configurationBuilder = new ConfigurationBuilder(); // 配置文件的读取器
            configurationBuilder.AddJsonFile("autofac.json");
            IConfigurationRoot root = configurationBuilder.Build();

            // 开始读取配置文件里的内容信息
            ConfigurationModule module = new ConfigurationModule(root);
            // 根据配置文件的内容注册服务
            containerBuilder.RegisterModule(module);

            #endregion Autofac 基于配置文件的服务注册
        }
    }
}