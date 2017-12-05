using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using GZYC.YZ.IBusiness;
using GZYC.YZ.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GZYC.YZ.Web;

namespace GZYC.YZ.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType(typeof(GZYC.YZ.Business.Logger)).As(Type.GetType("GZYC.YZ.IBusiness.ILogger"));
            //创建容器
            var container = builder.Build();
            //将上面的容器设置为一个新的依赖解析器
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            // Arrange
            HomeController controller = new HomeController((ILogger)container.Tag);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType(typeof(GZYC.YZ.Business.Logger)).As(Type.GetType("GZYC.YZ.IBusiness.ILogger"));
            //创建容器
            var container = builder.Build();
            //将上面的容器设置为一个新的依赖解析器
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            // Arrange
            HomeController controller = new HomeController((ILogger)container.Tag);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType(typeof(GZYC.YZ.Business.Logger)).As(Type.GetType("GZYC.YZ.IBusiness.ILogger"));
            //创建容器
            var container = builder.Build();
            //将上面的容器设置为一个新的依赖解析器
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            // Arrange
            HomeController controller = new HomeController((ILogger)container.Tag);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
