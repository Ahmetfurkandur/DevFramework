using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Core.Aspects.PostSharp;
using DevFramework.Core.DataAccess;

namespace DevFramework.Northwind.Business.Concrete.Managers
{
    public class ProductManager:IProductService
    {
        
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            
            return _productDal.GetAll();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(i => i.ProductId == id);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }
        
        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }
    }
}
