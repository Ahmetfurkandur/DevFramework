using System.Linq;
using DevFramework.Core.Entities;

namespace DevFramework.Core.DataAccess
{
    public interface IQueryableRepository<T> where T:class, IEntity,new()
    {
        IQueryable<T> Table { get; }

    }
}
