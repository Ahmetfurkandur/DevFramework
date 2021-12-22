using System;
using DevFramework.Northwind.DataAccess.Concrete;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevFramework.DataAccess.Tests.EntityFrameworkTests
{
    [TestClass]
    public class EntityFrameworkTests
    {
        [TestMethod]
        public void Get_All_Returns_All_Products()
        {
            EfProductDal productDal = new EfProductDal();

            var result = productDal.GetAll();

            Assert.AreEqual(77,result.Count);
        }

        [TestMethod]
        public void Get_all_with_parameters_returns_filtered_products()
        {
            EfProductDal productDal = new EfProductDal();

            var result = productDal.GetAll(p=>p.ProductName.Contains("ab"));

            Assert.AreEqual(4,result.Count);
        }
    }
}
