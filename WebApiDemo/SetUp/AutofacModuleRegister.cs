using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;

namespace WebApiDemo.SetUp
{
    public class AutofacModuleRegister: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //注册service
            var assemblysService = Assembly.Load("WebApiDemo.Service");
            builder.RegisterAssemblyTypes(assemblysService)
                .InstancePerDependency() //瞬时单例
                .AsImplementedInterfaces() //自动以其实现的所有接口类型暴露（包括IDisposable接口）
                .EnableInterfaceInterceptors(); //引用Autofac.Extras.DynamicProxy;

            //注册Repository
            var assemblysRepository = Assembly.Load("WebApiDemo.Repository");
            builder.RegisterAssemblyTypes(assemblysRepository)
                .InstancePerDependency() //瞬时单例
                .AsImplementedInterfaces() //自动以其实现的所有接口类型暴露（包括IDisposable接口）
                .EnableInterfaceInterceptors(); //引用Autofac.Extras.DynamicProxy;
        }
    }
}
