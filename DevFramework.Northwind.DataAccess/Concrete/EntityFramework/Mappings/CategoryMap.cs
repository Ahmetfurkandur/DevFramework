using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class CategoryMap:EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable(@"Categories",@"dbo");
            HasKey(i => i.CategoryId);
            
            Property(p => p.CategoryId).HasColumnName("CategoryId");
            Property(p => p.CategoryName).HasColumnName("CategoryName");


        }
    }
    
}
