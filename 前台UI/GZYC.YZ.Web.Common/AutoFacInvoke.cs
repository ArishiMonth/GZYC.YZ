using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using GZYC.YZ.Common.XmlHelper;

namespace GZYC.YZ.Web.Common
{
    public  class AutoFacInvoke
    {
      
        public static void Register(string assembyPath)
        {
            //获取容器建立者
            var builder = new ContainerBuilder();
            var assemblyTypeLst = XmlHelper.XmlDeserialize(assembyPath, "/AutoFaceService/ServerModel/param", "ServiceName",
                "ServiceType");
            var assemblyGenericLst= XmlHelper.XmlDeserialize(assembyPath, "/AutoFaceService/RepositoryModel/param", "RepositoryName",
                "RepositoryType");
            var type = Assembly.Load("GZYC.YZ.DataAccess");
            var itype = Assembly.Load("GZYC.YZ.IDataAccess");
            foreach (var generic in assemblyGenericLst)
            {
                //注册 Service
                builder.RegisterType(type.GetType(generic.Key)).As(itype.GetType(generic.Value));
            }
            //foreach (var generic in assemblyGenericLst)
            //{
            //    //注册泛型 Repository<>
            //    builder.RegisterGeneric(type.GetType(generic.Key)).As(itype.GetType(generic.Value))
            //    .InstancePerLifetimeScope();
            //}
            type = Assembly.Load("GZYC.YZ.Business");
            itype = Assembly.Load("GZYC.YZ.IBusiness");
            foreach (var generic in assemblyTypeLst)
            {   
                //注册 Service
                builder.RegisterType(type.GetType(generic.Key)).As(itype.GetType(generic.Value));
            }           
            
            //注册 Controller 
            builder.RegisterControllers(Assembly.Load("GZYC.YZ.Web.Controllers"));
            //创建容器
            var container = builder.Build();
            //将上面的容器设置为一个新的依赖解析器
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
