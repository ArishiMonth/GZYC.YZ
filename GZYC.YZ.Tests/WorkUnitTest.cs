using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Web.Mvc;
using System.Web;
using System.IO;
using System.Linq;
using System.Text;
using Autofac;
using Autofac.Integration.Mvc;
using GZYC.YZ.Models.EFModel;
using GZYC.YZ.Web.Common;

namespace GZYC.YZ.Tests
{
    [TestFixture]
   // [Export]
    public class WorkUnitTest : RollbackAttribute
    {
      
        /// <summary>
        /// 测试基础数据增
        /// </summary>
        [Rollback]
        [Test]
        public void Can_Add_BaseData()
        {

            var builder = new ContainerBuilder();
            builder.RegisterType<GZYC.YZ.DataAccess.LoggerDB>().As<GZYC.YZ.IDataAccess.ILoggerDB>();
            var data= new tb_Log
            {
                Ltype = 1,
                DeleteMark = false,
                Lcontent = "操作日志",
                Ldate = DateTime.Now,
                Lip = "127.0.0.1",
                Ltitle = 2,
                Luser = "admin"
            };
            var data1 = new List<tb_Log>();
            data1.Add(data);
            using (var container = builder.Build())
            {
                // DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
                var manager = container.Resolve<GZYC.YZ.IDataAccess.ILoggerDB>();
                NUnit.Framework.Assert.AreEqual(manager.Insert(data),1);

                NUnit.Framework.Assert.AreEqual(manager.Insert(data1), 1);
            }


        }
        /// <summary>
        /// 测试基础数据删
        /// </summary>
        [Rollback]
        [Test]
        public void Can_Delete_BaseData()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<GZYC.YZ.DataAccess.LoggerDB>().As<GZYC.YZ.IDataAccess.ILoggerDB>();
            var ids = new List<object>();
            var data1 = new tb_Log
            {
                Ltype = 1,
                DeleteMark = false,
                Lcontent = "操作日志",
                Ldate = DateTime.Now,
                Lip = "127.0.0.1",
                Ltitle = 2,
                Luser = "admin"
            };
            using (var container = builder.Build())
            {
                // DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
                var manager = container.Resolve<GZYC.YZ.IDataAccess.ILoggerDB>();
                var data = manager.Search().First();
                NUnit.Framework.Assert.AreEqual(manager.Delete(data.OID), 1);

                manager.Insert(data1);
                data = manager.Search().First();
                ids.Add(data.OID);
                NUnit.Framework.Assert.AreEqual(manager.Deletes(ids), 1);

                manager.Insert(data1);
                data = manager.Search().First();
                NUnit.Framework.Assert.AreEqual(manager.Delete(data), 1);
                //NUnit.Framework.Assert.AreEqual(manager.Insert(data), 1);
            }

        }
        /// <summary>
        /// 测试基础数据改
        /// </summary>
        [Rollback]
        [Test]
        public void Can_Update_BaseData()
        {

            var builder = new ContainerBuilder();
            builder.RegisterType<GZYC.YZ.DataAccess.LoggerDB>().As<GZYC.YZ.IDataAccess.ILoggerDB>();
            
            using (var container = builder.Build())
            {
                // DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
                var manager = container.Resolve<GZYC.YZ.IDataAccess.ILoggerDB>();
                var data = manager.Search().First();
                data.Lcontent = "dsadasas";
            
                NUnit.Framework.Assert.AreEqual(manager.Update(data), 1);
               
            }
        }
        /// <summary>
        /// 测试基础数据查
        /// </summary>
        [Rollback]
        [Test]
        public void Can_Search_BaseData()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<GZYC.YZ.DataAccess.LoggerDB>().As<GZYC.YZ.IDataAccess.ILoggerDB>();
           
            using (var container = builder.Build())
            {
               // DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
                var manager = container.Resolve<GZYC.YZ.IDataAccess.ILoggerDB>();
                NUnit.Framework.Assert.IsTrue(manager.Search().Any());
            }

        }
    }
}
