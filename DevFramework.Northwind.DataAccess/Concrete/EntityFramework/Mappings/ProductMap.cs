using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ProductMap:EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable(@"Products",@"dbo");
            HasKey(i => i.ProductId);

            Property(p => p.ProductId).HasColumnName("ProductId");
            Property(p => p.ProductName).HasColumnName("ProductName");
            Property(p => p.CategoryId).HasColumnName("CategoryId");
            Property(p => p.QuantityPerUnit).HasColumnName("QuantityPerUnit");
            Property(p => p.UnitPrice).HasColumnName("UnitPrice");


        }
    }
}
