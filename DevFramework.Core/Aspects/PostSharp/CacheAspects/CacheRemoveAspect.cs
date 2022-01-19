using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.CrossCuttingConcerns.Caching;
using PostSharp.Aspects;

namespace DevFramework.Core.Aspects.PostSharp.CacheAspects
{
    [Serializable]
    public class CacheRemoveAspect:OnMethodBoundaryAspect
    {
        private string _pattern;
        private Type _cacheType;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(Type cacheType)
        {
            _cacheType = cacheType;
            
        }

        public CacheRemoveAspect(string pattern,Type cacheType)
        {
            _cacheType = cacheType;
            _pattern = pattern;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            //Gönderilen nesne cache manager türünde değilse hata fırlatır
            if (typeof(ICacheManager).IsAssignableFrom(_cacheType)==false)
            {
                throw new Exception("Wrong Cache Manager");

            }

            //Cache manager nesnesinin instance ını oluşturduk
            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);
            base.RuntimeInitialize(method);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            _cacheManager.RemoveByPattern(String.IsNullOrEmpty(_pattern)?string.Format("{0}.{1}.*",args.Method.ReflectedType.Namespace,args.Method.ReflectedType.Name):_pattern);
        }
    }
}
