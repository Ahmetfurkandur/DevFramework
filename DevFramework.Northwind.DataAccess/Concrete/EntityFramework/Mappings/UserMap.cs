using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserMap:EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable(@"Users",@"dbo");
            HasKey(i => i.Id);
            
            Property(p => p.Email).HasColumnName("Email");
            Property(p => p.LastName).HasColumnName("LastName");
            Property(p => p.Password).HasColumnName("Password");
            Property(p => p.UserName).HasColumnName("UserName");
            Property(p => p.FirstName).HasColumnName("FirstName");
        }
    }
}
